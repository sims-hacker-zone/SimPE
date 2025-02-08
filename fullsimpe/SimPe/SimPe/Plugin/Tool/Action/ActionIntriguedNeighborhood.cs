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
using System.Media;

namespace SimPe.Plugin.Tool.Action
{
	/// <summary>
	/// The Intrigued Neighbourhood Action
	/// </summary>
	public class ActionIntriguedNeighborhood : SimPe.Interfaces.IToolAction
	{
		
		#region IToolAction Member

		public virtual bool ChangeEnabledStateEventHandler(object sender, SimPe.Events.ResourceEventArgs es)
		{
            if (es.Loaded && Helper.IsNeighborhoodFile(es.LoadedPackage.FileName)) return true;

			return false;
		}

        private bool RealChangeEnabledStateEventHandler(object sender, SimPe.Events.ResourceEventArgs es)
        {
            if (!es.Loaded) return false;

            return es.LoadedPackage.Package.FindFiles(Data.MetaData.SIM_DESCRIPTION_FILE).Length > 0;
        }

		public void ExecuteEventHandler(object sender, SimPe.Events.ResourceEventArgs e)
		{
            if (!RealChangeEnabledStateEventHandler(null, e))
            {
                System.Windows.Forms.MessageBox.Show(SimPe.Localization.GetString("This is not an appropriate context in which to use this tool"),
                    this.ToString());
                return;
            }
            SimPe.PackedFiles.Wrapper.SimDNA sdna; // Fuck

			SimPe.Interfaces.Files.IPackedFileDescriptor[] pfds = e.LoadedPackage.Package.FindFiles(Data.MetaData.SIM_DESCRIPTION_FILE);

            SimPe.PackedFiles.Wrapper.SDesc sdesc = new SimPe.PackedFiles.Wrapper.SDesc(null, null, null);
            Random slt = new Random();
            foreach (SimPe.Interfaces.Files.IPackedFileDescriptor pfd in pfds)
            {
                sdesc.ProcessData(pfd, e.LoadedPackage.Package);
                if (sdesc.Nightlife.Species != 0 || ((int)sdesc.Version == (int)SimPe.PackedFiles.Wrapper.SDescVersions.Castaway && sdesc.Castaway.Subspecies > 0)) continue;
                SimPe.Interfaces.Files.IPackedFileDescriptor pfb = e.LoadedPackage.Package.FindFileAnyGroup(Data.MetaData.SDNA, 0, pfd.Instance);
                if (pfb != null)
                {
                    sdna = new SimPe.PackedFiles.Wrapper.SimDNA();
                    sdna.ProcessData(pfb, e.LoadedPackage.Package, true);
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
		public System.Windows.Forms.Shortcut Shortcut
		{
			get
			{
				return System.Windows.Forms.Shortcut.None;
			}
		}

		public System.Drawing.Image Icon
		{
			get
			{
				return System.Drawing.Image.FromStream(this.GetType().Assembly.GetManifestResourceStream("SimPe.img.emoticon.png"));
			}
		}

		public virtual bool Visible 
		{
			get {return true;}
		}

		#endregion
	}
}
