/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *   Copyright (C) 2008 Peter L Jones                                      *
 *   pljones@users.sf.net                                                  *
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
using System.Windows.Forms;
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public class LtxtUI : IPackedFileUI
	{
		#region Code to Startup the UI

		/// <summary>
		/// Holds a reference to the Form containing the UI Panel
		/// </summary>
		internal LtxtForm form;

		/// <summary>
		/// Constructor for the Class
		/// </summary>
		public LtxtUI()
		{
			//form = WrapperFactory.form;
			form = new LtxtForm();

			/* Ltxt.LotType[] ts = (Ltxt.LotType[])System.Enum.GetValues(typeof(Ltxt.LotType));
			foreach (Ltxt.LotType t in ts)
				if (t==Ltxt.LotType.Unknown) form.cbtype.Items.Insert(0, t);
				else form.cbtype.Items.Add(t); */

			form.cbtype.Items.Clear();
			form.cbtype.Items.Add(Ltxt.LotType.Unknown);
			form.cbtype.Items.Add(Ltxt.LotType.Residential);
			form.cbtype.Items.Add(Ltxt.LotType.Community);
			if (SimPe.PathProvider.Global.EPInstalled > 0)
			{
				form.cbtype.Items.Add(Ltxt.LotType.Dorm);
				form.cbtype.Items.Add(Ltxt.LotType.GreekHouse);
				form.cbtype.Items.Add(Ltxt.LotType.SecretSociety);
			}
			if (SimPe.PathProvider.Global.EPInstalled > 9)
			{
				form.cbtype.Items.Add(Ltxt.LotType.Hotel);
				form.cbtype.Items.Add(Ltxt.LotType.SecretHoliday);
			}
			if (SimPe.PathProvider.Global.EPInstalled > 11)
			{
				form.cbtype.Items.Add(Ltxt.LotType.Hobby);
			}
			if (SimPe.PathProvider.Global.EPInstalled > 15)
			{
				form.cbtype.Items.Add(Ltxt.LotType.ApartmentBase);
				form.cbtype.Items.Add(Ltxt.LotType.ApartmentSublot);
				form.cbtype.Items.Add(Ltxt.LotType.Witches);
			}
		}
		#endregion

		#region IPackedFileUI Member

		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle
		{
			get { return form.ltxtPanel; }
		}

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <param name="wrapper">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrapper)
		{
			Ltxt wrp = (Ltxt)wrapper;
			form.wrapper = null;
			form.tbver.Text = wrp.Version.ToString();
			form.tbsubver.Text = wrp.SubVersion.ToString();

			if (form.cbtype.Items.Contains(wrp.Type))
				form.cbtype.SelectedIndex = form.cbtype.Items.IndexOf(wrp.Type);
			else
				form.cbtype.SelectedIndex = 0;
			form.tbtype.Text = "0x" + Helper.HexString((byte)wrp.Type);

			form.btnAddApt.Enabled = form.btnDelApt.Enabled = (
				wrp.Type == Ltxt.LotType.ApartmentBase
			);
			form.tbRoads.Text = "0x" + Helper.HexString(wrp.LotRoads);
			form.tbwd.Text = wrp.LotSize.Width.ToString();
			form.tbhg.Text = wrp.LotSize.Height.ToString();
			form.tbtop.Text = wrp.LotPosition.Y.ToString();
			form.tbleft.Text = wrp.LotPosition.X.ToString();
			form.tbz.Text = wrp.LotElevation.ToString();
			form.cborient.SelectedValue = wrp.Orientation;
			form.tbrotation.Text = "0x" + Helper.HexString(wrp.LotRotation);
			form.tbu0.Text = "0x" + Helper.HexString(wrp.Unknown0);
			Boolset bby = wrp.Unknown0;
			form.cbhidim.Checked = bby[4];
			form.cbBeachy.Checked = bby[7];
			if (
				wrp.Version >= LtxtVersion.Apartment
				|| wrp.SubVersion >= LtxtSubVersion.Apartment
			)
			{
				form.cbLotClas.Enabled = true;
				if (bby[12])
					form.cbLotClas.SelectedIndex = 1;
				else if (bby[13])
					form.cbLotClas.SelectedIndex = 2;
				else if (bby[14])
					form.cbLotClas.SelectedIndex = 3;
				else
					form.cbLotClas.SelectedIndex = 0;
			}
			else
			{
				form.cbLotClas.SelectedIndex = 0;
				form.cbLotClas.Enabled = false;
			}

			if (
				(
					wrp.Version >= LtxtVersion.Apartment
					|| wrp.SubVersion >= LtxtSubVersion.Apartment
				)
				&& (
					wrp.Type == Ltxt.LotType.ApartmentBase
					|| wrp.Type == Ltxt.LotType.ApartmentSublot
				)
			)
			{
				form.gbApart.Visible = true;
				form.gbunown.Location = new System.Drawing.Point(116, 408);
				form.llunknone.Location = new System.Drawing.Point(41, 408);
				form.gbhobby.Location = new System.Drawing.Point(30, 408);
				form.gbtravel.Location = new System.Drawing.Point(372, 408);
			}
			else
			{
				form.gbApart.Visible = false;
				form.gbunown.Location = new System.Drawing.Point(116, 333);
				form.llunknone.Location = new System.Drawing.Point(41, 333);
				form.gbhobby.Location = new System.Drawing.Point(30, 333);
				form.gbtravel.Location = new System.Drawing.Point(372, 333);
			}

			form.lbPlayim.Visible = wrp.appendage != null;
			form.tblotname.Text = wrp.LotName;
			form.tbTexture.Text = wrp.Texture;
			form.tbdesc.Text = wrp.LotDesc;
			form.tbinst.Text = "0x" + Helper.HexString(wrp.LotInstance);
			form.tbu3.Text = wrp.Unknown3.ToString();
			form.tbu4.Text = "0x" + Helper.HexString(wrp.Unknown4);
			Boolset tty = wrp.Unknown4;
			if (wrp.SubVersion >= LtxtSubVersion.Freetime)
			{
				form.cbtrjflag5.Checked = tty[30];
				form.cbtrjflag4.Checked = tty[28];
				form.cbtrjflag3.Checked = tty[27];
				form.cbtrjflag2.Checked = tty[26];
				form.cbtrjflag1.Checked = tty[25];
				form.cbtrjungle.Checked = tty[24];
				form.cbtrhidec.Checked = tty[23];
				form.cbtrpool.Checked = tty[22];
				form.cbtrmale.Checked = tty[21];
				form.cbtrfem.Checked = tty[20];
				form.cbtrbeach.Checked = tty[19];
				form.cbtrformal.Checked = tty[18];
				form.cbtrteen.Checked = tty[17];
				form.cbtrnude.Checked = tty[16];
				form.cbtrpern.Checked = tty[15];
				form.cgtrwhite.Checked = tty[14];
				form.cbtrblue.Checked = tty[13];
				form.cbtrredred.Checked = tty[12];
				form.cbtradult.Checked = tty[11];
				form.cbtrclub.Checked = tty[10];
				form.cbhbmusic.Checked = tty[9];
				form.cbhbscience.Checked = tty[8];
				form.cbhbfitness.Checked = tty[7];
				form.cbhbtinker.Checked = tty[6];
				form.cbhbnature.Checked = tty[5];
				form.cbhbgames.Checked = tty[4];
				form.cbhbsport.Checked = tty[3];
				form.cbhbfilm.Checked = tty[2];
				form.cbhbart.Checked = tty[1];
				form.cbhbcook.Checked = tty[0];

				if (wrp.Type != Ltxt.LotType.Hobby)
					form.gbtravel.Visible = form.gbhobby.Visible = false;
				form.cbtrmale.Enabled = !form.cbtrfem.Checked;
				form.cbtrfem.Enabled = !form.cbtrmale.Checked;
				form.cbtrclub.Enabled = (wrp.Type == Ltxt.LotType.Hobby);
				form.cbtrhidec.Enabled = (wrp.Type == Ltxt.LotType.Hobby);
				form.gbhobby.Enabled = (wrp.Type == Ltxt.LotType.Hobby);
				form.bthbytrvl.Enabled = (wrp.Type == Ltxt.LotType.Hobby);
			}
			else
			{
				form.bthbytrvl.Enabled = false;
				form.gbhobby.Visible = false;
				form.gbtravel.Visible = false;
			}

			form.cbBeachy.Enabled = (wrp.SubVersion >= LtxtSubVersion.Voyage);
			form.bthbytrvl.Text = "Hobby Flags:";
			form.tbu5.Text = Helper.BytesToHexList(wrp.Unknown5);
			//form.tblotclass.Text = "0x" + Helper.HexString(wrp.LotClass);
			form.tblotclass.Text = Convert.ToString(wrp.LotClass);
			form.tbcset.Text = Convert.ToBoolean(wrp.Clset).ToString();
			//form.tbcset.Text = Convert.ToString(wrp.Clset);
			form.lb.Items.Clear();
			int x = 0,
				y = 0;
			foreach (float i in wrp.Unknown1) // form.lb.Items.Add("0x" + Helper.HexString(i));
			{
				form.lb.Items.Add("(" + x + "," + y + ") " + i);
				x++;
				if ((y + 1) * (wrp.LotSize.Width + 1) == form.lb.Items.Count)
				{
					y++;
					x = 0;
				}
			}
			form.tbElevationAt.Text = "";

			form.tbu2.Text = "0x" + Helper.HexString(wrp.Unknown2);
			form.tbowner.Text = "0x" + Helper.HexString(wrp.OwnerInstance);
			form.tbApBase.Text = "0x" + Helper.HexString(wrp.ApartmentBase);
			form.tbu6.Text = Helper.BytesToHexList(wrp.Unknown6);

			if (wrp.OwnerInstance > 0)
				form.label25.ForeColor = System.Drawing.Color.Blue;
			else
				form.label25.ForeColor = System.Drawing.SystemColors.ControlText;

			form.lbApts.Items.Clear();
			foreach (Ltxt.SubLot sl in wrp.SubLots)
				form.lbApts.Items.Add("0x" + Helper.HexString(sl.ApartmentSublot));
			form.tbApartment.Text =
				form.tbSAFamily.Text =
				form.tbSAu2.Text =
				form.tbSAu3.Text =
					"";

			form.lbu7.Items.Clear();
			foreach (uint i in wrp.Unknown7)
				form.lbu7.Items.Add("0x" + Helper.HexString(i));
			form.tbu7.Text = "";

			form.tbData.Text = Helper.BytesToHexList(wrp.Followup);

			form.tbowner.ReadOnly = !(wrp.Version >= LtxtVersion.Business);
			form.tbu3.ReadOnly = !(wrp.SubVersion >= LtxtSubVersion.Voyage);
			form.tbu4.ReadOnly = !(wrp.SubVersion >= LtxtSubVersion.Freetime);

			form.lbApts.Enabled =
				form.gbApartment.Enabled =
				form.lbu7.Enabled =
					(
						wrp.Version >= LtxtVersion.Apartment
						|| wrp.SubVersion >= LtxtSubVersion.Apartment
					);
			form.tbu5.ReadOnly =
				form.tbApBase.ReadOnly =
				form.tbu6.ReadOnly =
				form.tbu7.ReadOnly =
					!form.lbApts.Enabled;

			form.llAptBase.Enabled = (wrp.ApartmentBase != 0);
			form.btnAddApt.Visible = form.btnDelApt.Visible =
				(
					wrp.Version >= LtxtVersion.Apartment
					|| wrp.SubVersion >= LtxtSubVersion.Apartment
				) && Helper.WindowsRegistry.HiddenMode;
			form.btnAddApt.Enabled = form.btnDelApt.Enabled = (
				wrp.Type == Ltxt.LotType.ApartmentBase
			);
			form.btnDelApt.Enabled =
				form.llFamily.Enabled =
				form.llSubLot.Enabled =
					false;

			form.pb.Image = wrp.LotDescription.Image;

			form.wrapper = wrp;
		}

		#endregion

		#region IDisposable Member
		public virtual void Dispose()
		{
			this.form.Dispose();
		}
		#endregion
	}
}
