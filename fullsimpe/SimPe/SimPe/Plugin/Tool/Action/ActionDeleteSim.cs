/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections;

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
							!= Data.MetaData.SIM_DESCRIPTION_FILE
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
					this.ToString()
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

			deleteInvalidDna = (
				Message.Show(
					"Delete all orphan DNA, Scores and Wants records as well?",
					"Clean Up",
					System.Windows.Forms.MessageBoxButtons.YesNo
				) == System.Windows.Forms.DialogResult.Yes
			);
			int c = 0;
			if (e.Items.Count > 0)
			{
				for (int i = 0; i < e.Items.Count; i++)
				{
					PackedFiles.Wrapper.ExtSDesc victim =
						new PackedFiles.Wrapper.ExtSDesc();
					victim.ProcessData(e.Items[i].Resource);

					c += DeleteSim(victim);
				}
			}
			else
			{
				PackedFiles.Wrapper.ExtSDesc victim =
					new PackedFiles.Wrapper.ExtSDesc();
				Interfaces.Files.IPackedFileDescriptor[] pfds =
					e.LoadedPackage.Package.FindFiles(
						Data.MetaData.SIM_DESCRIPTION_FILE
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

		int DeleteSim(PackedFiles.Wrapper.ExtSDesc victim)
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
				DeleteRes(0xCD95548E, inst, guid, victim.Package, victim); //want & fear
				DeleteRes(0xEBFEE33F, inst, guid, victim.Package, victim); //DNA
				DeleteRes(0x3053CF74, inst, guid, victim.Package, victim); //Scores
				ret = DeleteCharacterFile(inst, guid, victim.Package, victim);
				victim.FileDescriptor.MarkForDelete = true;
			}
			return ret;
		}

		int DeleteCharacterFile(
			uint inst,
			uint guid,
			Interfaces.Files.IPackageFile pkg,
			PackedFiles.Wrapper.ExtSDesc victim
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
			PackedFiles.Wrapper.ExtSDesc victim
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				Data.MetaData.RELATION_FILE
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				uint up = (pfd.Instance & 0xFFFF0000u) >> 16;
				uint low = (pfd.Instance & 0x0000FFFFFu);

				if (up == inst || low == inst)
				{
					pfd.MarkForDelete = true;
				}
			}
		}

		void DeleteRes(
			uint type,
			uint inst,
			uint guid,
			Interfaces.Files.IPackageFile pkg,
			PackedFiles.Wrapper.ExtSDesc victim
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
			PackedFiles.Wrapper.ExtSDesc victim
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				0x8C870743
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				PackedFiles.Wrapper.FamilyTies ft =
					new PackedFiles.Wrapper.FamilyTies(null);
				ft.ProcessData(pfd, pkg);

				ArrayList sims = new ArrayList();
				foreach (
					PackedFiles.Wrapper.Supporting.FamilyTieSim fts in ft.Sims
				)
				{
					if (fts.Instance != inst)
					{
						sims.Add(fts);

						ArrayList items = new ArrayList();
						foreach (
							PackedFiles.Wrapper.Supporting.FamilyTieItem fti in fts.Ties
						)
						{
							if (fti.Instance != inst)
							{
								items.Add(fti);
							}
						}

						fts.Ties =
							new PackedFiles.Wrapper.Supporting.FamilyTieItem[
								items.Count
							];
						items.CopyTo(fts.Ties);
					}
				}

				PackedFiles.Wrapper.Supporting.FamilyTieSim[] fsims =
					new PackedFiles.Wrapper.Supporting.FamilyTieSim[sims.Count];
				sims.CopyTo(fsims);

				ft.Sims = fsims;

				ft.SynchronizeUserData();
			}
		}

		void DeleteMemories(
			uint inst,
			uint guid,
			Interfaces.Files.IPackageFile pkg,
			PackedFiles.Wrapper.ExtSDesc victim
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				0x4E474248
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				Ngbh n = new Ngbh(null);
				n.ProcessData(pfd, pkg);

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
			PackedFiles.Wrapper.ExtSDesc victim
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				0x46414D49
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				PackedFiles.Wrapper.Fami f = new PackedFiles.Wrapper.Fami(
					null
				);
				f.ProcessData(pfd, pkg);

				ArrayList list = new ArrayList();
				foreach (uint i in f.Members)
				{
					if (i != guid)
					{
						list.Add(i);
					}
				}

				f.Members = new uint[list.Count];
				list.CopyTo(f.Members);

				f.SynchronizeUserData();
			}
		}

		void DeleteRelations(
			uint inst,
			uint guid,
			Interfaces.Files.IPackageFile pkg,
			PackedFiles.Wrapper.ExtSDesc victim
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				Data.MetaData.SIM_DESCRIPTION_FILE
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				if (pfd.Instance == inst)
				{
					continue;
				}

				ArrayList list = new ArrayList();
				PackedFiles.Wrapper.ExtSDesc sdsc =
					new PackedFiles.Wrapper.ExtSDesc();
				sdsc.ProcessData(pfd, pkg);

				foreach (uint i in sdsc.Relations.SimInstances)
				{
					if (i != inst)
					{
						list.Add((ushort)i);
					}
				}

				if (list.Count < sdsc.Relations.SimInstances.Length)
				{
					sdsc.Relations.SimInstances = new ushort[list.Count];
					list.CopyTo(sdsc.Relations.SimInstances);

					sdsc.SynchronizeUserData();
				}
			}
		}

		void DeleteOrphanDna(Interfaces.Files.IPackageFile pkg)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfdSim = pkg.FindFiles(
				0xAACE2EFBu
			); // get the existing SDSCs
			ArrayList simInstances = new ArrayList();
			foreach (Interfaces.Files.IPackedFileDescriptor pSim in pfdSim)
			{
				simInstances.Add(pSim.Instance);
			}

			Interfaces.Files.IPackedFileDescriptor[] pfdDna = pkg.FindFiles(
				0xEBFEE33Fu
			); // get the existing SDNAs
			Interfaces.Files.IPackedFileDescriptor[] pfdSco = pkg.FindFiles(
				0x3053CF74u
			); // get the existing Scores
			Interfaces.Files.IPackedFileDescriptor[] pfdWaF = pkg.FindFiles(
				0xCD95548Eu
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
