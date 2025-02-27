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
using System.Drawing;
using System.Windows.Forms;

using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// handles Packed XmlFiles
	/// </summary>
	public class Fami : UIBase, IPackedFileUI
	{
		#region IPackedFileHandler Member

		public Control GUIHandle => form.famiPanel;

		public void UpdateGUI(IFileWrapper wrapper)
		{
			Wrapper.Fami fami = (Wrapper.Fami)wrapper;
			form.wrapper = fami;

			if (fami.FamiThumb != null)
			{
				form.pbImage.Image =
					Ambertation.Windows.Forms.Graph.ImagePanel.CreateThumbnail(
						fami.FamiThumb,
						form.pbImage.Size,
						12,
						Color.FromArgb(90, Color.Black),
						SystemColors.ControlDarkDark,
						Color.White,
						Color.FromArgb(80, Color.White),
						true,
						4,
						0
					);
			}
			else if (fami.FileDescriptor.Instance > 32511)
			{
				form.pbImage.Image = GetImage.Cassie;
			}
			else
			{
				form.pbImage.Image = null;
			}

			form.tbname.Text = fami.Name;
			form.tbmoney.Text = fami.Money.ToString();
			form.tbfamily.Text = fami.Friends.ToString();
			if (
				Helper.WindowsRegistry.AllowLotZero
				&& fami.LotInstance == 0
				&& fami.FileDescriptor.Instance > 0
				&& fami.FileDescriptor.Instance < 32512
			)
			{
				form.tblotinst.Text = "Sim Bin";
			}
			else
			{
				form.tblotinst.Text = "0x" + Helper.HexString(fami.LotInstance);
			}

			form.tbalbum.Text = "0x" + Helper.HexString(fami.AlbumGUID);
			form.tbflag.Text = "0x" + Helper.HexString(fami.Flags);
			form.tbsubhood.Text = "0x" + Helper.HexString(fami.SubHoodNumber);
			form.tbvac.Text = "0x" + Helper.HexString(fami.VacationLotInstance);
			form.tbblot.Text = "0x" + Helper.HexString(fami.CurrentlyOnLotInstance);
			form.tbbmoney.Text = fami.BusinessMoney.ToString();
			form.lbmembers.Items.Clear();
			form.tbcafood1.Text = fami.CastAwayFood.ToString();
			form.tbcares.Text = fami.CastAwayResources.ToString();
			form.tbcaunk.Text = "0x" + Helper.HexString(fami.CastAwayFoodDecay);
			form.label14.Visible = form.tbblot.Visible =
				(int)fami.Version
				>= (int)Wrapper.FamiVersions.Business;
			form.label7.Visible = form.tbvac.Visible =
				(int)fami.Version == (int)Wrapper.FamiVersions.Voyage;
			form.tbsubhood.Enabled =
				(int)fami.Version
				>= (int)Wrapper.FamiVersions.University;
			form.gbCastaway.Visible =
				(int)fami.Version
				== (int)Wrapper.FamiVersions.Castaway;
			form.label3.Visible = form.tbmoney.Visible =
				(int)fami.Version
				< (int)Wrapper.FamiVersions.Castaway;
			form.label16.Visible = form.tbbmoney.Visible = (
				(int)fami.Version
					>= (int)Wrapper.FamiVersions.Business
				&& (int)fami.Version
					< (int)Wrapper.FamiVersions.Castaway
			);
			//form.panel4.HeaderText = Data.MetaData.NPCFamily(fami.FileDescriptor.Instance);
			form.btOpenHistory.Visible = (
				fami.Package.FindFile(
					0x46414D68,
					fami.FileDescriptor.SubType,
					fami.FileDescriptor.Group,
					fami.FileDescriptor.Instance
				) != null
			);
			if (
				fami.LotInstance == 0
				|| fami.Package.FindFile(0x0BF999E7, 0, 0xFFFFFFFF, fami.LotInstance)
					== null
			)
			{
				form.label15.ForeColor = SystemColors.ControlText;
			}
			else
			{
				form.label15.ForeColor = Color.Blue;
			}

			form.lbmembers.Sorted = false;
			string[] names = fami.SimNames;
			for (int i = 0; i < fami.Members.Length; i++)
			{
				Data.Alias a = new Data.Alias(fami.Members[i], fami.SimNames[i]);
				form.lbmembers.Items.Add(a);
			}
			if (fami.Members.Length > 5)
			{
				form.lbmembers.Sorted = true;
			}

			form.cbsims.Items.Clear();
			form.cbsims.Sorted = false;
			foreach (IAlias a in fami.NameProvider.StoredData.Values)
			{
				form.cbsims.Items.Add(a);
			}
			form.cbsims.Sorted = true;
			form.cbsims.Text = "";
		}

		#endregion
	}
}
