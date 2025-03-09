// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Sdna;
using SimPe.PackedFiles.Sdsc;

namespace SimPe.Plugin.Tool.Action
{
	/// <summary>
	/// The Intrigued Neighbourhood Action
	/// </summary>
	public class ActionIntriguedNeighborhood : Interfaces.IToolAction
	{
		#region IToolAction Member

		public virtual bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			return es.Loaded && Helper.IsNeighborhoodFile(es.LoadedPackage.FileName);
		}

		private bool RealChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			return es.Loaded
&& es.LoadedPackage.Package.FindFiles(
					Data.FileTypes.SDSC
				).Length > 0;
		}

		public void ExecuteEventHandler(object sender, Events.ResourceEventArgs e)
		{
			if (!RealChangeEnabledStateEventHandler(null, e))
			{
				System.Windows.Forms.MessageBox.Show(
					Localization.GetString(
						"This is not an appropriate context in which to use this tool"
					),
					ToString()
				);
				return;
			}
			SimDNA sdna; // Fuck

			Interfaces.Files.IPackedFileDescriptor[] pfds =
				e.LoadedPackage.Package.FindFiles(Data.FileTypes.SDSC);

			SDesc sdesc = new PackedFiles.Sdsc.SDesc(
				null,
				null,
				null
			);
			Random slt = new Random();
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				sdesc.ProcessData(pfd, e.LoadedPackage.Package);
				if (
					sdesc.Nightlife.Species != 0
					|| (
						(int)sdesc.Version
							== (int)SDescVersions.Castaway
						&& sdesc.Castaway.Subspecies > 0
					)
				)
				{
					continue;
				}

				Interfaces.Files.IPackedFileDescriptor pfb =
					e.LoadedPackage.Package.FindFileAnyGroup(
						Data.FileTypes.SDNA,
						0,
						pfd.Instance
					);
				if (pfb != null)
				{
					sdna = new SimDNA().ProcessFile(pfb, e.LoadedPackage.Package, true);
				}

				sdesc.Interests.Animals = 1000;
				sdesc.Interests.Crime = 1000;
				sdesc.Interests.Culture = 1000;
				sdesc.Interests.Entertainment = 1000;
				sdesc.Interests.Environment = 1000;
				sdesc.Interests.Fashion = 1000;
				sdesc.Interests.Food = 1000;
				sdesc.Interests.Health = 1000;
				sdesc.Interests.Money = 1000;
				sdesc.Interests.Paranormal = 1000;
				sdesc.Interests.Politics = 1000;
				sdesc.Interests.School = 1000;
				sdesc.Interests.Scifi = 1000;
				sdesc.Interests.Sports = 1000;
				sdesc.Interests.Toys = 1000;
				sdesc.Interests.Travel = 1000;
				sdesc.Interests.Weather = 1000;
				sdesc.Interests.Work = 1000;

				sdesc.SynchronizeUserData();
			}
		}

		#endregion


		#region IToolPlugin Member
		public override string ToString()
		{
			return "Intrigued Neighborhood";
		}
		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.emoticon.png")
				);

		public virtual bool Visible => true;

		#endregion
	}
}
