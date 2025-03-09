// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Linq;

using SimPe.Data;
using SimPe.Forms.MainUI;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Fami;
using SimPe.PackedFiles.Famt;
using SimPe.PackedFiles.Sdsc;

namespace SimPe.Plugin.Tool.Action
{
	/// <summary>
	/// The Delete Sims Action
	/// </summary>
	public class ActionDeleteSim : Interfaces.IToolAction
	{
		bool deleteInvalidDna = false;

		#region IToolAction Member
		public virtual bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			if (es.Loaded && Helper.IsNeighborhoodFile(es.LoadedPackage.FileName))
			{
				if (es.Count > 0)
				{
					int i = -1;
					while (++i < es.Count)
					{
						if (
							es.Items[i].Resource.FileDescriptor.Type
							!= Data.FileTypes.SDSC
						)
						{
							return false;
						}
					}

					return true;
				}
			}
			return false;
		}

		public void ExecuteEventHandler(object sender, Events.ResourceEventArgs e)
		{
			if (!ChangeEnabledStateEventHandler(null, e))
			{
				System.Windows.Forms.MessageBox.Show(
					Localization.GetString(
						"This is not an appropriate context in which to use this tool"
					),
					ToString()
				);
				return;
			}
			string messige = "All ";
			if (e.Items.Count > 0)
			{
				messige = "The selected ";
			}

			if (
				Message.Show(
					messige
						+ "sims will be deleted from your Neighbourhood!\nYou MUST commit the changes to the neighbourhood after this procedure.\nYou can not undo this, so make sure you have created a Backup!\n\nDelete the Sims?",
					"Warning",
					System.Windows.Forms.MessageBoxButtons.YesNo
				) == System.Windows.Forms.DialogResult.No
			)
			{
				return;
			}

			deleteInvalidDna =
				Message.Show(
					"Delete all orphan DNA, Scores and Wants records as well?",
					"Clean Up",
					System.Windows.Forms.MessageBoxButtons.YesNo
				) == System.Windows.Forms.DialogResult.Yes
			;
			int c = 0;
			if (e.Items.Count > 0)
			{
				for (int i = 0; i < e.Items.Count; i++)
				{
					c += DeleteSim(new PackedFiles.Sdsc.ExtSDesc().ProcessFile(e.Items[i].Resource));
				}
			}
			else
			{
				ExtSDesc victim =
					new PackedFiles.Sdsc.ExtSDesc();
				Interfaces.Files.IPackedFileDescriptor[] pfds =
					e.LoadedPackage.Package.FindFiles(
						Data.FileTypes.SDSC
					);
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					victim.ProcessData(pfd, e.LoadedPackage.Package);
					if (
						victim.CharacterDescription.Gender == Data.MetaData.Gender.Male
						&& !victim.IsNPC
					)
					{
						c += DeleteSim(victim);
					}
				}
			}

			if (deleteInvalidDna)
			{
				DeleteOrphanDna(e.LoadedPackage.Package);
			}

			Message.Show(
				string.Format("Done. {0} sim character file(s) deleted", c),
				"Notice",
				System.Windows.Forms.MessageBoxButtons.OK
			);
		}
		#endregion

		int DeleteSim(ExtSDesc victim)
		{
			int ret = 0;
			uint inst = victim.FileDescriptor.Instance;
			uint guid = victim.SimId;

			if (!victim.IsNPC)
			{
				DeleteSRels(inst, guid, victim.Package, victim);
				DeleteRelations(inst, guid, victim.Package, victim);
				DeleteFamilyTies(inst, guid, victim.Package, victim);
				DeleteMemories(inst, guid, victim.Package, victim);
				DeleteFamMembers(inst, guid, victim.Package, victim);
				DeleteRes(FileTypes.SWAF, inst, guid, victim.Package, victim); //want & fear
				DeleteRes(FileTypes.SDNA, inst, guid, victim.Package, victim); //DNA
				DeleteRes(FileTypes.SCOR, inst, guid, victim.Package, victim); //Scores
				ret = DeleteCharacterFile(inst, guid, victim.Package, victim);
				victim.FileDescriptor.MarkForDelete = true;
			}
			return ret;
		}

		int DeleteCharacterFile(
			uint inst,
			uint guid,
			Interfaces.Files.IPackageFile pkg,
			ExtSDesc victim
		)
		{
			int ret = 0;
			//do not delete for NPCs
			//if (victim.IsNPC) return;

			if (System.IO.File.Exists(victim.CharacterFileName))
			{
				try
				{
					Packages.StreamItem si =
						Packages.StreamFactory.UseStream(
							victim.CharacterFileName,
							System.IO.FileAccess.Read
						);
					si.Close();
					System.IO.File.Delete(victim.CharacterFileName);
					ret++;
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(ex);
				}
			}

			return ret;
		}

		void DeleteSRels(
			uint inst,
			uint guid,
			Interfaces.Files.IPackageFile pkg,
			ExtSDesc victim
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				Data.FileTypes.SREL
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				uint up = (pfd.Instance & 0xFFFF0000u) >> 16;
				uint low = pfd.Instance & 0x0000FFFFFu;

				if (up == inst || low == inst)
				{
					pfd.MarkForDelete = true;
				}
			}
		}

		void DeleteRes(
			FileTypes type,
			uint inst,
			uint guid,
			Interfaces.Files.IPackageFile pkg,
			ExtSDesc victim
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(type);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				if (pfd.Instance == inst)
				{
					pfd.MarkForDelete = true;
				}
			}
		}

		void DeleteFamilyTies(
			uint inst,
			uint guid,
			Interfaces.Files.IPackageFile pkg,
			ExtSDesc victim
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				FileTypes.FAMT
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				Famt ft =
					new PackedFiles.Famt.Famt(null).ProcessFile(pfd, pkg);

				ArrayList sims = new ArrayList();
				foreach (
					FamilyTieSim fts in ft.Sims
				)
				{
					if (fts.Instance != inst)
					{
						sims.Add(fts);
						fts.Ties = (from fti in fts.Ties where fti.Instance != inst select fti).ToList();
					}
				}

				FamilyTieSim[] fsims =
					new FamilyTieSim[sims.Count];
				sims.CopyTo(fsims);

				ft.Sims = fsims;

				ft.SynchronizeUserData();
			}
		}

		void DeleteMemories(
			uint inst,
			uint guid,
			Interfaces.Files.IPackageFile pkg,
			ExtSDesc victim
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				FileTypes.NGBH
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				Ngbh n = new Ngbh(null).ProcessFile(pfd, pkg);

				ArrayList slotsToRemove = new ArrayList();

				foreach (NgbhSlot s in n.Sims)
				{
					if (s.SlotID == inst)
					{
						slotsToRemove.Add(s); // remove all my memories and tokens ?!
					}
					else
					{
						// process other sims memories and tokens

						ArrayList list = new ArrayList();

						foreach (NgbhItem i in s.ItemsA)
						{
							if (
								i.SimID == guid
								|| i.SimInstance == inst
								|| i.OwnerInstance == inst
							)
							{
								list.Add(i);
							}
						}

						foreach (NgbhItem i in list)
						{
							s.ItemsA.Remove(i);
						}

						list.Clear();

						foreach (NgbhItem i in s.ItemsB)
						{
							if (
								i.SimID == guid
								|| i.SimInstance == inst
								|| i.OwnerInstance == inst
							)
							{
								list.Add(i);
							}
						}

						foreach (NgbhItem i in list)
						{
							s.ItemsB.Remove(i);
						}
					}
				}

				foreach (NgbhSlot s in slotsToRemove)
				{
					n.Sims.Remove(s);
				}
				//n.Sims = slots;

				n.SynchronizeUserData();
			}
		}

		void DeleteFamMembers(
			uint inst,
			uint guid,
			Interfaces.Files.IPackageFile pkg,
			ExtSDesc victim
		)
		{
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pkg.FindFiles(FileTypes.FAMI))
			{
				Fami f = new Fami(null).ProcessFile(pfd, pkg);
				if (f.Members.Contains(guid))
				{
					f.Members.Remove(guid);
					f.SynchronizeUserData();
				}
			}
		}

		void DeleteRelations(
			uint inst,
			uint guid,
			Interfaces.Files.IPackageFile pkg,
			ExtSDesc victim
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				Data.FileTypes.SDSC
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				if (pfd.Instance == inst)
				{
					continue;
				}

				ArrayList list = new ArrayList();
				ExtSDesc sdsc =
					new PackedFiles.Sdsc.ExtSDesc().ProcessFile(pfd, pkg);

				sdsc.Relations.SimInstances = (from i in sdsc.Relations.SimInstances
											   where i != inst
											   select i).ToList();

				sdsc.SynchronizeUserData();
			}
		}

		void DeleteOrphanDna(Interfaces.Files.IPackageFile pkg)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfdSim = pkg.FindFiles(
				FileTypes.SDSC
			); // get the existing SDSCs
			ArrayList simInstances = new ArrayList();
			foreach (Interfaces.Files.IPackedFileDescriptor pSim in pfdSim)
			{
				simInstances.Add(pSim.Instance);
			}

			Interfaces.Files.IPackedFileDescriptor[] pfdDna = pkg.FindFiles(
				FileTypes.SDNA
			); // get the existing SDNAs
			Interfaces.Files.IPackedFileDescriptor[] pfdSco = pkg.FindFiles(
				FileTypes.SCOR
			); // get the existing Scores
			Interfaces.Files.IPackedFileDescriptor[] pfdWaF = pkg.FindFiles(
				FileTypes.SWAF
			); // get the wants & fears

			foreach (Interfaces.Files.IPackedFileDescriptor pDna in pfdDna)
			{
				if (!simInstances.Contains(pDna.Instance))
				{
					pDna.MarkForDelete = true;
				}
			}

			foreach (Interfaces.Files.IPackedFileDescriptor pSco in pfdSco)
			{
				if (!simInstances.Contains(pSco.Instance))
				{
					pSco.MarkForDelete = true;
				}
			}

			foreach (Interfaces.Files.IPackedFileDescriptor pWaF in pfdWaF)
			{
				if (!simInstances.Contains(pWaF.Instance))
				{
					pWaF.MarkForDelete = true;
				}
			}
		}

		#region IToolPlugin Member
		public override string ToString()
		{
			return "Delete Sims";
		}
		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => GetIcon.DeleteSim;

		public virtual bool Visible => true;

		#endregion
	}
}
