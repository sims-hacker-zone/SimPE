/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for ExtObjdForm.
	/// </summary>
	internal class ExtObjdForm : System.Windows.Forms.Form, IPackedFileUI
	{
		#region Form variables
		private System.Windows.Forms.Button btnUpdateMMAT;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.PropertyGrid pg;
		internal System.Windows.Forms.TabControl tc;
		internal System.Windows.Forms.TabPage tpcatalogsort;
		private System.Windows.Forms.TabPage tpraw;
		internal System.Windows.Forms.CheckBox cbhobby;
		internal System.Windows.Forms.CheckBox cbaspiration;
		internal System.Windows.Forms.CheckBox cbcareer;
		internal System.Windows.Forms.CheckBox cbkids;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton rbbin;
		private System.Windows.Forms.RadioButton rbdec;
		private System.Windows.Forms.RadioButton rbhex;
		private System.Windows.Forms.CheckBox cball;
		internal System.Windows.Forms.Label lbIsOk;
		private System.Windows.Forms.Label label1;
		internal Ambertation.Windows.Forms.EnumComboBox cbsort;
		private System.Windows.Forms.Label label63;
		internal System.Windows.Forms.TextBox tbproxguid;
		private System.Windows.Forms.Label label97;
		internal System.Windows.Forms.TextBox tborgguid;
		private System.Windows.Forms.LinkLabel llgetGUID;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel6;
		internal System.Windows.Forms.TextBox tbflname;
		internal System.Windows.Forms.TextBox tbguid;
		internal System.Windows.Forms.ComboBox cbtype;
		internal System.Windows.Forms.TextBox tbtype;
		internal System.Windows.Forms.Panel pnobjd;
		internal System.Windows.Forms.CheckBox cbbathroom;
		internal System.Windows.Forms.CheckBox cbbedroom;
		internal System.Windows.Forms.CheckBox cbdinigroom;
		internal System.Windows.Forms.CheckBox cbkitchen;
		internal System.Windows.Forms.CheckBox cbstudy;
		internal System.Windows.Forms.CheckBox cblivingroom;
		internal System.Windows.Forms.CheckBox cboutside;
		internal System.Windows.Forms.CheckBox cbmisc;
		internal System.Windows.Forms.CheckBox cbgeneral;
		internal System.Windows.Forms.CheckBox cbelectronics;
		internal System.Windows.Forms.CheckBox cbdecorative;
		internal System.Windows.Forms.CheckBox cbappliances;
		internal System.Windows.Forms.CheckBox cbsurfaces;
		internal System.Windows.Forms.CheckBox cbseating;
		internal System.Windows.Forms.CheckBox cbplumbing;
		internal System.Windows.Forms.CheckBox cblightning;
		private Ambertation.Windows.Forms.XPTaskBoxSimple groupBox1;
		private Ambertation.Windows.Forms.XPTaskBoxSimple groupBox2;
		internal TextBox tbdiag;
		private Label label3;
		internal TextBox tbgrid;
		private Label label4;
		private System.Windows.Forms.Panel pngradient;
		private LinkLabel lladdgooee;
		private ComboBox cbBuildSort;
		private Label label5;
		private Ambertation.Windows.Forms.XPTaskBoxSimple taskBox1;
		private CheckBox cbcMisc;
		private CheckBox cbcStreet;
		private CheckBox cbcOuts;
		private CheckBox cbcShop;
		private CheckBox cbcDine;
		private TabPage tpreqeps;
		private System.Windows.Forms.Panel pnpritty;
		private Ambertation.Windows.Forms.XPTaskBoxSimple tbreqeps;
		private Label lbepnote;
		private Label lbgamef2;
		private CheckBox cbStoreEd;
		private CheckBox cbMansion;
		private CheckBox cbApartments;
		private CheckBox cbIkeaHome;
		private CheckBox cbKitchens;
		private CheckBox cbFreeTime;
		private CheckBox cbExtras;
		private CheckBox cbTeenStyle;
		private CheckBox cbBonVoyage;
		private CheckBox cbFashion;
		private CheckBox cbCelebrations;
		private CheckBox cbSeasons;
		private CheckBox cbPets;
		private CheckBox cbGlamour;
		private CheckBox cbFamilyFun;
		private CheckBox cbBusiness;
		private CheckBox cbNightlife;
		private CheckBox cbUniversity;
		private CheckBox cbBase;
		#endregion
		private ToolTip toolTip1;
		private Label lbprise;
		internal TextBox tbPrice;
		private IContainer components;

		public ExtObjdForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			this.cbtype.Items.Add(Data.ObjectTypes.Unknown);
			this.cbtype.Items.Add(Data.ObjectTypes.ArchitecturalSupport);
			this.cbtype.Items.Add(Data.ObjectTypes.Door);
			this.cbtype.Items.Add(Data.ObjectTypes.Memory);
			this.cbtype.Items.Add(Data.ObjectTypes.ModularStairs);
			this.cbtype.Items.Add(Data.ObjectTypes.ModularStairsPortal);
			this.cbtype.Items.Add(Data.ObjectTypes.Normal);
			this.cbtype.Items.Add(Data.ObjectTypes.Outfit);
			this.cbtype.Items.Add(Data.ObjectTypes.Person);
			this.cbtype.Items.Add(Data.ObjectTypes.SimType);
			this.cbtype.Items.Add(Data.ObjectTypes.Stairs);
			this.cbtype.Items.Add(Data.ObjectTypes.Template);
			this.cbtype.Items.Add(Data.ObjectTypes.Vehicle);
			this.cbtype.Items.Add(Data.ObjectTypes.Window);
			this.cbtype.Items.Add(Data.ObjectTypes.UnlinkedSim);
			this.cbtype.Items.Add(Data.ObjectTypes.Tiles);

			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(Data.BuildFunctionSubSort.none)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Columns
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Stairs
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Pool
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_TallColumns
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Arch
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Driveway
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Elevator
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Architectural
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Garden_Trees
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Garden_Shrubs
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Garden_Flowers
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Garden_Objects
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Openings_Door
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Openings_TallWindow
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Openings_Window
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Openings_Gate
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Openings_Arch
				)
			);
			this.cbBuildSort.Items.Add(
				new SimPe.Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Openings_TallDoor
				)
			);
			if (Helper.WindowsRegistry.HiddenMode)
				this.cbBuildSort.Items.Add(
					new SimPe.Data.LocalizedBuildSubSort(
						Data.BuildFunctionSubSort.unknown
					)
				);

			this.cbsort.Enum = typeof(Data.ObjFunctionSubSort);
			this.cbsort.ResourceManager = SimPe.Localization.Manager;

			if (Helper.ECCorNewSEfound)
				this.cbExtras.Text = "Extra Stuff";

			if (Helper.WindowsRegistry.UseBigIcons)
				this.pg.Font = new System.Drawing.Font(
					"Verdana",
					10.25F,
					System.Drawing.FontStyle.Regular
				);
			if (
				!UserVerification.HaveUserId
				|| SimPe.PathProvider.Global.EPInstalled <= 1
			)
			{
				this.cbBuildSort.Visible = this.taskBox1.Visible = false;
				this.groupBox1.Height = 176;
				this.groupBox2.Height = 176;
				this.tbPrice.Location = new System.Drawing.Point(140, 144);
				this.lbprise.Location = new System.Drawing.Point(94, 148);
				this.tc.Controls.Remove(this.tpreqeps);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);

			wrapper = null;
		}

		#region ExtObjdForm
		internal ExtObjd wrapper = null;
		internal uint initialguid;
		Ambertation.PropertyObjectBuilderExt pob;
		bool propchanged;

		void ShowData()
		{
			propchanged = false;
			this.pg.SelectedObject = null;

			Hashtable ht = new Hashtable();
			for (int i = 0; i < wrapper.Data.Length; i++)
			{
				Ambertation.PropertyDescription pf =
					ExtObjd.PropertyParser.GetDescriptor((ushort)i);
				if (pf == null)
					pf = new Ambertation.PropertyDescription(
						"Unknown",
						null,
						wrapper.Data[i]
					);
				else
					pf.Property = wrapper.Data[i];

				ht[GetName(i)] = pf;
			}

			pob = new Ambertation.PropertyObjectBuilderExt(ht);
			this.pg.SelectedObject = pob.Instance;
		}

		void UpdateData()
		{
			if (!propchanged)
				return;
			propchanged = false;

			try
			{
				Hashtable ht = pob.Properties;

				for (int i = 0; i < wrapper.Data.Length; i++)
				{
					string name = GetName(i);
					try
					{
						if (ht.Contains(name))
						{
							object o = ht[name];
							if (o is SimPe.FlagBase)
								wrapper.Data[i] = ((SimPe.FlagBase)ht[name]);
							else
								wrapper.Data[i] = Convert.ToInt16(ht[name]);
						}
					}
					catch (Exception ex)
					{
						if (Helper.WindowsRegistry.HiddenMode)
							Helper.ExceptionMessage("Error converting " + name, ex);
					}
				}

				wrapper.Changed = true;
				wrapper.UpdateFlags();
				wrapper.RefreshUI();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private static Dictionary<int, string> names = null;

		private string GetName(int i)
		{
			string name = null;
			if (names == null)
				readPJSEGlobalStringObjDef();
			if (names == null)
				readGLUAObjDef();
			if (names == null || names[i] == null)
			{
				Ambertation.PropertyDescription pf =
					ExtObjd.PropertyParser.GetDescriptor((ushort)i);
				name = pf == null ? null : pf.Description;
			}
			else
				name = names[i];
			return "0x"
				+ Helper.HexString((ushort)i)
				+ ((name != null) ? ": " + name : "")
				+ " ";
		}

		private static void readGLUAObjDef()
		{
			names = null;
			string objDefGLUAFile = System.IO.Path.Combine(
				SimPe.PathProvider.Global.Latest.InstallFolder,
				"TSData\\Res\\ObjectScripts\\ObjectScripts.package"
			);
			if (!System.IO.File.Exists(objDefGLUAFile))
			{
				return;
			}
			IPackageFile glua = SimPe.Packages.File.LoadFromFile(objDefGLUAFile);
			if (glua == null)
			{
				return;
			}
			IPackedFileDescriptor objDefPFD = glua.FindFile(
				Data.MetaData.GLUA,
				0x49fa1f15,
				0xffffffff,
				0xff89f911
			);
			if (objDefPFD == null)
			{
				return;
			}
			SimPe.PackedFiles.Wrapper.ObjLua objDef =
				new SimPe.PackedFiles.Wrapper.ObjLua();
			objDef.ProcessData(objDefPFD, glua);

			List<ObjLuaConstant> loc = new List<ObjLuaConstant>(
				(ObjLuaConstant[])objDef.Root.Constants.ToArray(typeof(ObjLuaConstant))
			);
			if (loc[0].String != "ObjDef")
			{
				return;
			}
			loc.RemoveAt(0);

			names = new Dictionary<int, string>();

			bool started = false;
			while (loc.Count > 0)
			{
				string value = loc[0].String;
				loc.RemoveAt(0);
				int key = Convert.ToInt32(loc[0].Value);
				loc.RemoveAt(0);
				if (started)
					names[key] = value;
				else if (key == 0)
				{
					started = true;
					names[key] = value;
				}
			}
		}

		private static void readPJSEGlobalStringObjDef()
		{
			names = null;
			string pjseGlobalStringFile;
			pjseGlobalStringFile = System.IO.Path.Combine(
				SimPe.Helper.SimPePluginPath,
				"pjse.coder.plugin\\GlobalStrings.package"
			);
			if (!System.IO.File.Exists(pjseGlobalStringFile))
			{
				return;
			}
			IPackageFile gs = SimPe.Packages.File.LoadFromFile(pjseGlobalStringFile);
			if (gs == null)
			{
				return;
			}
			IPackedFileDescriptor objDefPFD = gs.FindFile(
				0x53545223,
				0,
				0xfeedf00d,
				0xcc
			);
			if (objDefPFD == null)
			{
				return;
			}
			Str objDef = new SimPe.PackedFiles.Wrapper.Str();
			objDef.ProcessData(objDefPFD, gs);
			if (objDef.LanguageItems(1) == null)
			{
				return;
			}

			List<StrToken> lST = new List<StrToken>(
				(StrToken[])objDef.LanguageItems(1).ToArray(typeof(StrToken))
			);
			names = new Dictionary<int, string>();
			for (int i = 0; i < lST.Count; i++)
				names[i] = lST[i].Title;
		}

		internal void SetFunctionCb(Wrapper.ExtObjd objd)
		{
			this.cbappliances.Checked = objd.FunctionSort.InAppliances;
			this.cbdecorative.Checked = objd.FunctionSort.InDecorative;
			this.cbelectronics.Checked = objd.FunctionSort.InElectronics;
			this.cbgeneral.Checked = objd.FunctionSort.InGeneral;
			this.cblightning.Checked = objd.FunctionSort.InLighting;
			this.cbplumbing.Checked = objd.FunctionSort.InPlumbing;
			this.cbseating.Checked = objd.FunctionSort.InSeating;
			this.cbsurfaces.Checked = objd.FunctionSort.InSurfaces;
			this.cbhobby.Checked = objd.FunctionSort.InHobbies;
			this.cbaspiration.Checked = objd.FunctionSort.InAspirationRewards;
			this.cbcareer.Checked = objd.FunctionSort.InCareerRewards;
		}

		internal void SetExpansionsCb(Wrapper.ExtObjd objd)
		{
			this.cbBase.Checked = objd.EpRequired1.Basegame;
			this.cbUniversity.Checked = objd.EpRequired1.University;
			this.cbNightlife.Checked = objd.EpRequired1.Nightlife;
			this.cbBusiness.Checked = objd.EpRequired1.Business;
			this.cbFamilyFun.Checked = objd.EpRequired1.FamilyFun;
			this.cbGlamour.Checked = objd.EpRequired1.GlamourLife;
			this.cbSeasons.Checked = objd.EpRequired1.Seasons;
			this.cbCelebrations.Checked = objd.EpRequired1.Celebration;
			this.cbFashion.Checked = objd.EpRequired1.Fashion;
			this.cbBonVoyage.Checked = objd.EpRequired1.BonVoyage;
			this.cbTeenStyle.Checked = objd.EpRequired1.TeenStyle;
			this.cbExtras.Checked = objd.EpRequired1.StoreEdition_old;
			this.cbFreeTime.Checked = objd.EpRequired1.Freetime;
			this.cbKitchens.Checked = objd.EpRequired1.KitchenBath;
			this.cbIkeaHome.Checked = objd.EpRequired1.IkeaHome;
			this.cbApartments.Checked = objd.EpRequired2.ApartmentLife;
			this.cbMansion.Checked = objd.EpRequired2.MansionGarden;
			this.cbStoreEd.Checked = objd.EpRequired2.StoreEdition;
		}

		static string subKey = "ExtObdjForm";
		private int InitialTab
		{
			get
			{
				XmlRegistryKey rkf = Helper.WindowsRegistry.RegistryKey.CreateSubKey(
					subKey
				);
				object o = rkf.GetValue("initialTab", 0);
				return Convert.ToInt16(o);
			}
			set
			{
				XmlRegistryKey rkf = Helper.WindowsRegistry.RegistryKey.CreateSubKey(
					subKey
				);
				rkf.SetValue("initialTab", value);
			}
		}
		#endregion

		#region IPackedFileUI Member

		public Control GUIHandle
		{
			get { return this.pnobjd; }
		}

		public void UpdateGUI(SimPe.Interfaces.Plugin.IFileWrapper wrapper)
		{
			Wrapper.ExtObjd objd = (Wrapper.ExtObjd)wrapper;
			this.wrapper = objd;
			this.initialguid = objd.Guid;
			this.Tag = true;

			try
			{
				if (objd.Ok != Wrapper.ObjdHealth.Ok)
				{
					this.lbIsOk.Text = "Please commit! (" + objd.Ok.ToString() + ")";
					this.lbIsOk.Visible = true;
				}
				else
				{
					this.lbIsOk.Text = "Please commit!";
					this.lbIsOk.Visible = false;
				}
				this.pg.SelectedObject = null;
				this.tc.SelectedIndex = InitialTab;
				this.cbtype.SelectedIndex = 0;
				for (int i = 0; i < this.cbtype.Items.Count; i++)
				{
					Data.ObjectTypes ot = (Data.ObjectTypes)this.cbtype.Items[i];
					if (ot == objd.Type)
					{
						this.cbtype.SelectedIndex = i;
						break;
					}
				}

				this.tbtype.Text = "0x" + Helper.HexString((ushort)(objd.Type));
				this.tbguid.Text = "0x" + Helper.HexString(objd.Guid);
				this.tbproxguid.Text = "0x" + Helper.HexString(objd.ProxyGuid);
				this.tborgguid.Text = "0x" + Helper.HexString(objd.OriginalGuid);
				this.tbdiag.Text = "0x" + Helper.HexString(objd.DiagonalGuid);
				this.tbgrid.Text = "0x" + Helper.HexString(objd.GridAlignedGuid);
				this.tbflname.Text = objd.FileName;

				this.cbbathroom.Checked = (objd.RoomSort.InBathroom);
				this.cbbedroom.Checked = (objd.RoomSort.InBedroom);
				this.cbdinigroom.Checked = (objd.RoomSort.InDiningRoom);
				this.cbkitchen.Checked = (objd.RoomSort.InKitchen);
				this.cblivingroom.Checked = (objd.RoomSort.InLivingRoom);
				this.cbmisc.Checked = (objd.RoomSort.InMisc);
				this.cboutside.Checked = (objd.RoomSort.InOutside);
				this.cbstudy.Checked = (objd.RoomSort.InStudy);
				this.cbkids.Checked = (objd.RoomSort.InKids);

				this.cbcDine.Checked = (objd.CommSort.InDining);
				this.cbcShop.Checked = (objd.CommSort.InShopping);
				this.cbcOuts.Checked = (objd.CommSort.InOutdoors);
				this.cbcStreet.Checked = (objd.CommSort.InStreet);
				this.cbcMisc.Checked = (objd.CommSort.InMiscel);

				tbPrice.Text = "�" + Convert.ToString(objd.Price);

				this.tbreqeps.Enabled = (objd.Version > 0x008b);
				this.SetExpansionsCb(objd);
				this.SetFunctionCb(objd);
				this.cbsort.SelectedValue = objd.FunctionSubSort;
				this.cbBuildSort.SelectedIndex = 0;
				if (objd.BuildType.Value != 0)
				{
					if (Helper.WindowsRegistry.HiddenMode)
						this.cbBuildSort.SelectedIndex = 19; // set to unknown
					for (int i = 0; i < this.cbBuildSort.Items.Count; i++)
					{
						object o = this.cbBuildSort.Items[i];
						Data.BuildFunctionSubSort at;
						if (o.GetType() == typeof(SimPe.Data.Alias))
							at = (Data.LocalizedBuildSubSort)(
								(uint)((SimPe.Data.Alias)o).Id
							);
						else
							at = (Data.LocalizedBuildSubSort)o;
						if (at == objd.BuildSubSort)
						{
							this.cbBuildSort.SelectedIndex = i;
							break;
						}
					}
				}
				if (!Helper.WindowsRegistry.HiddenMode && UserVerification.HaveUserId)
				{
					//this.toolTip1.SetToolTip(this.tbgrid, SimPe.Plugin.Subhoods.getgooee(objd.GridAlignedGuid));
					//this.toolTip1.SetToolTip(this.tbdiag, SimPe.Plugin.Subhoods.getgooee(objd.DiagonalGuid));
					//this.toolTip1.SetToolTip(this.tbproxguid, SimPe.Plugin.Subhoods.getgooee(objd.ProxyGuid));
					//this.toolTip1.SetToolTip(this.tborgguid, SimPe.Plugin.Subhoods.getgooee(objd.OriginalGuid));
				}

				this.llgetGUID.Visible = (
					UserVerification.HaveUserId
					&& objd.Type != SimPe.Data.ObjectTypes.Person
					&& objd.Type != SimPe.Data.ObjectTypes.UnlinkedSim
				);
				//this.lladdgooee.Visible = (UserVerification.HaveUserId && !SimPe.Plugin.Subhoods.GuidExists(objd.Guid) && objd.Type != SimPe.Data.ObjectTypes.Person && objd.Type != SimPe.Data.ObjectTypes.UnlinkedSim);
			}
			finally
			{
				this.Tag = null;
			}
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pnobjd = new System.Windows.Forms.Panel();
			this.lladdgooee = new System.Windows.Forms.LinkLabel();
			this.tbgrid = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbdiag = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnUpdateMMAT = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lbIsOk = new System.Windows.Forms.Label();
			this.cball = new System.Windows.Forms.CheckBox();
			this.tc = new System.Windows.Forms.TabControl();
			this.tpcatalogsort = new System.Windows.Forms.TabPage();
			this.pngradient = new System.Windows.Forms.Panel();
			this.taskBox1 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.cbcMisc = new System.Windows.Forms.CheckBox();
			this.cbcStreet = new System.Windows.Forms.CheckBox();
			this.cbcOuts = new System.Windows.Forms.CheckBox();
			this.cbcShop = new System.Windows.Forms.CheckBox();
			this.cbcDine = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.cbBuildSort = new System.Windows.Forms.ComboBox();
			this.cbaspiration = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbhobby = new System.Windows.Forms.CheckBox();
			this.cbappliances = new System.Windows.Forms.CheckBox();
			this.cbdecorative = new System.Windows.Forms.CheckBox();
			this.cbelectronics = new System.Windows.Forms.CheckBox();
			this.cbgeneral = new System.Windows.Forms.CheckBox();
			this.cblightning = new System.Windows.Forms.CheckBox();
			this.cbplumbing = new System.Windows.Forms.CheckBox();
			this.cbseating = new System.Windows.Forms.CheckBox();
			this.cbsurfaces = new System.Windows.Forms.CheckBox();
			this.cbcareer = new System.Windows.Forms.CheckBox();
			this.cbsort = new Ambertation.Windows.Forms.EnumComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.lbprise = new System.Windows.Forms.Label();
			this.tbPrice = new System.Windows.Forms.TextBox();
			this.cbkids = new System.Windows.Forms.CheckBox();
			this.cbbathroom = new System.Windows.Forms.CheckBox();
			this.cbbedroom = new System.Windows.Forms.CheckBox();
			this.cbdinigroom = new System.Windows.Forms.CheckBox();
			this.cbkitchen = new System.Windows.Forms.CheckBox();
			this.cbmisc = new System.Windows.Forms.CheckBox();
			this.cboutside = new System.Windows.Forms.CheckBox();
			this.cblivingroom = new System.Windows.Forms.CheckBox();
			this.cbstudy = new System.Windows.Forms.CheckBox();
			this.tpreqeps = new System.Windows.Forms.TabPage();
			this.pnpritty = new System.Windows.Forms.Panel();
			this.tbreqeps = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.lbepnote = new System.Windows.Forms.Label();
			this.lbgamef2 = new System.Windows.Forms.Label();
			this.cbStoreEd = new System.Windows.Forms.CheckBox();
			this.cbMansion = new System.Windows.Forms.CheckBox();
			this.cbApartments = new System.Windows.Forms.CheckBox();
			this.cbIkeaHome = new System.Windows.Forms.CheckBox();
			this.cbKitchens = new System.Windows.Forms.CheckBox();
			this.cbFreeTime = new System.Windows.Forms.CheckBox();
			this.cbExtras = new System.Windows.Forms.CheckBox();
			this.cbTeenStyle = new System.Windows.Forms.CheckBox();
			this.cbBonVoyage = new System.Windows.Forms.CheckBox();
			this.cbFashion = new System.Windows.Forms.CheckBox();
			this.cbCelebrations = new System.Windows.Forms.CheckBox();
			this.cbSeasons = new System.Windows.Forms.CheckBox();
			this.cbPets = new System.Windows.Forms.CheckBox();
			this.cbGlamour = new System.Windows.Forms.CheckBox();
			this.cbFamilyFun = new System.Windows.Forms.CheckBox();
			this.cbBusiness = new System.Windows.Forms.CheckBox();
			this.cbNightlife = new System.Windows.Forms.CheckBox();
			this.cbUniversity = new System.Windows.Forms.CheckBox();
			this.cbBase = new System.Windows.Forms.CheckBox();
			this.tpraw = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rbhex = new System.Windows.Forms.RadioButton();
			this.rbdec = new System.Windows.Forms.RadioButton();
			this.rbbin = new System.Windows.Forms.RadioButton();
			this.pg = new System.Windows.Forms.PropertyGrid();
			this.tbtype = new System.Windows.Forms.TextBox();
			this.cbtype = new System.Windows.Forms.ComboBox();
			this.label63 = new System.Windows.Forms.Label();
			this.tbproxguid = new System.Windows.Forms.TextBox();
			this.label97 = new System.Windows.Forms.Label();
			this.tborgguid = new System.Windows.Forms.TextBox();
			this.llgetGUID = new System.Windows.Forms.LinkLabel();
			this.label65 = new System.Windows.Forms.Label();
			this.tbflname = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbguid = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.pnobjd.SuspendLayout();
			this.tc.SuspendLayout();
			this.tpcatalogsort.SuspendLayout();
			this.pngradient.SuspendLayout();
			this.taskBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tpreqeps.SuspendLayout();
			this.pnpritty.SuspendLayout();
			this.tbreqeps.SuspendLayout();
			this.tpraw.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			//
			// pnobjd
			//
			this.pnobjd.AutoScroll = true;
			this.pnobjd.BackColor = System.Drawing.Color.Transparent;
			this.pnobjd.Controls.Add(this.lladdgooee);
			this.pnobjd.Controls.Add(this.tbgrid);
			this.pnobjd.Controls.Add(this.label4);
			this.pnobjd.Controls.Add(this.tbdiag);
			this.pnobjd.Controls.Add(this.label3);
			this.pnobjd.Controls.Add(this.btnUpdateMMAT);
			this.pnobjd.Controls.Add(this.label2);
			this.pnobjd.Controls.Add(this.lbIsOk);
			this.pnobjd.Controls.Add(this.cball);
			this.pnobjd.Controls.Add(this.tc);
			this.pnobjd.Controls.Add(this.tbtype);
			this.pnobjd.Controls.Add(this.cbtype);
			this.pnobjd.Controls.Add(this.label63);
			this.pnobjd.Controls.Add(this.tbproxguid);
			this.pnobjd.Controls.Add(this.label97);
			this.pnobjd.Controls.Add(this.tborgguid);
			this.pnobjd.Controls.Add(this.llgetGUID);
			this.pnobjd.Controls.Add(this.label65);
			this.pnobjd.Controls.Add(this.tbflname);
			this.pnobjd.Controls.Add(this.label9);
			this.pnobjd.Controls.Add(this.tbguid);
			this.pnobjd.Controls.Add(this.label8);
			this.pnobjd.Controls.Add(this.panel6);
			this.pnobjd.Dock = System.Windows.Forms.DockStyle.Fill;
			//this.pnobjd.EndColour = System.Drawing.SystemColors.Control;
			this.pnobjd.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.pnobjd.Location = new System.Drawing.Point(0, 0);
			//this.pnobjd.MiddleColour = System.Drawing.SystemColors.Control;
			this.pnobjd.Name = "pnobjd";
			this.pnobjd.Size = new System.Drawing.Size(984, 325);
			//this.pnobjd.StartColour = System.Drawing.SystemColors.Control;
			this.pnobjd.TabIndex = 6;
			//
			// lladdgooee
			//
			this.lladdgooee.AutoSize = true;
			this.lladdgooee.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			this.lladdgooee.LinkArea = new System.Windows.Forms.LinkArea(0, 6);
			this.lladdgooee.Location = new System.Drawing.Point(125, 170);
			this.lladdgooee.Name = "lladdgooee";
			this.lladdgooee.Size = new System.Drawing.Size(153, 18);
			this.lladdgooee.TabIndex = 37;
			this.lladdgooee.TabStop = true;
			this.lladdgooee.Text = "Add To pjse Guid Index";
			this.lladdgooee.UseCompatibleTextRendering = true;
			this.lladdgooee.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.lladdgooee_LinkClicked
				);
			//
			// tbgrid
			//
			this.tbgrid.Location = new System.Drawing.Point(122, 285);
			this.tbgrid.Name = "tbgrid";
			this.tbgrid.Size = new System.Drawing.Size(96, 21);
			this.tbgrid.TabIndex = 36;
			this.tbgrid.Text = "0xDDDDDDDD";
			this.tbgrid.TextChanged += new System.EventHandler(this.SetGuid);
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(8, 288);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(108, 13);
			this.label4.TabIndex = 35;
			this.label4.Text = "Grid Align GUID";
			//
			// tbdiag
			//
			this.tbdiag.Location = new System.Drawing.Point(122, 258);
			this.tbdiag.Name = "tbdiag";
			this.tbdiag.Size = new System.Drawing.Size(96, 21);
			this.tbdiag.TabIndex = 34;
			this.tbdiag.Text = "0xDDDDDDDD";
			this.tbdiag.TextChanged += new System.EventHandler(this.SetGuid);
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label3.Location = new System.Drawing.Point(15, 261);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 13);
			this.label3.TabIndex = 33;
			this.label3.Text = "Diagonal GUID";
			//
			// btnUpdateMMAT
			//
			this.btnUpdateMMAT.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdateMMAT.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.btnUpdateMMAT.Location = new System.Drawing.Point(50, 117);
			this.btnUpdateMMAT.Name = "btnUpdateMMAT";
			this.btnUpdateMMAT.Size = new System.Drawing.Size(62, 24);
			this.btnUpdateMMAT.TabIndex = 32;
			this.btnUpdateMMAT.Text = "Update";
			this.btnUpdateMMAT.Visible = false;
			this.btnUpdateMMAT.Click += new System.EventHandler(
				this.btnUpdateMMAT_Click
			);
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.label2.Location = new System.Drawing.Point(114, 124);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 13);
			this.label2.TabIndex = 31;
			this.label2.Text = "MMATs and commit";
			this.label2.Visible = false;
			//
			// lbIsOk
			//
			this.lbIsOk.BackColor = System.Drawing.Color.Transparent;
			this.lbIsOk.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.lbIsOk.Location = new System.Drawing.Point(6, 60);
			this.lbIsOk.Name = "lbIsOk";
			this.lbIsOk.Size = new System.Drawing.Size(284, 23);
			this.lbIsOk.TabIndex = 29;
			this.lbIsOk.Text = "Please commit!";
			this.lbIsOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbIsOk.Visible = false;
			//
			// cball
			//
			this.cball.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.cball.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cball.Location = new System.Drawing.Point(98, 142);
			this.cball.Name = "cball";
			this.cball.Size = new System.Drawing.Size(120, 21);
			this.cball.TabIndex = 28;
			this.cball.Text = "update all MMATs";
			this.cball.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cball.Visible = false;
			//
			// tc
			//
			this.tc.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tc.Controls.Add(this.tpcatalogsort);
			this.tc.Controls.Add(this.tpreqeps);
			this.tc.Controls.Add(this.tpraw);
			this.tc.Location = new System.Drawing.Point(296, 56);
			this.tc.Name = "tc";
			this.tc.SelectedIndex = 0;
			this.tc.Size = new System.Drawing.Size(688, 268);
			this.tc.TabIndex = 26;
			this.tc.SelectedIndexChanged += new System.EventHandler(this.CangedTab);
			//
			// tpcatalogsort
			//
			this.tpcatalogsort.BackColor = System.Drawing.Color.Transparent;
			this.tpcatalogsort.BackgroundImageLayout = System
				.Windows
				.Forms
				.ImageLayout
				.Zoom;
			this.tpcatalogsort.Controls.Add(this.pngradient);
			this.tpcatalogsort.Location = new System.Drawing.Point(4, 22);
			this.tpcatalogsort.Name = "tpcatalogsort";
			this.tpcatalogsort.Size = new System.Drawing.Size(680, 242);
			this.tpcatalogsort.TabIndex = 0;
			this.tpcatalogsort.Text = "Catalogue Sort";
			//
			// pngradient
			//
			this.pngradient.BackColor = System.Drawing.Color.Transparent;
			//this.pngradient.BackgroundImageAnchor = System.Windows.Forms.Panel.ImageLayout.TopRight;
			//this.pngradient.BackgroundImageZoomToFit = true;
			this.pngradient.Controls.Add(this.taskBox1);
			this.pngradient.Controls.Add(this.groupBox2);
			this.pngradient.Controls.Add(this.groupBox1);
			this.pngradient.Dock = System.Windows.Forms.DockStyle.Fill;
			//this.pngradient.EndColour = System.Drawing.SystemColors.Control;
			this.pngradient.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.pngradient.Location = new System.Drawing.Point(0, 0);
			//this.pngradient.MiddleColour = System.Drawing.SystemColors.Control;
			this.pngradient.Name = "pngradient";
			this.pngradient.Size = new System.Drawing.Size(680, 242);
			//this.pngradient.StartColour = System.Drawing.SystemColors.Control;
			this.pngradient.TabIndex = 18;
			//
			// taskBox1
			//
			this.taskBox1.BackColor = System.Drawing.Color.Transparent;
			this.taskBox1.BodyColor = System.Drawing.SystemColors.ControlLight;
			this.taskBox1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			this.taskBox1.Controls.Add(this.cbcMisc);
			this.taskBox1.Controls.Add(this.cbcStreet);
			this.taskBox1.Controls.Add(this.cbcOuts);
			this.taskBox1.Controls.Add(this.cbcShop);
			this.taskBox1.Controls.Add(this.cbcDine);
			this.taskBox1.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			this.taskBox1.HeaderText = "Community Sort";
			this.taskBox1.HeaderTextColor = System.Drawing.SystemColors.ControlText;
			this.taskBox1.IconLocation = new System.Drawing.Point(4, 12);
			this.taskBox1.IconSize = new System.Drawing.Size(32, 32);
			this.taskBox1.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
			this.taskBox1.Location = new System.Drawing.Point(516, 8);
			this.taskBox1.Name = "taskBox1";
			this.taskBox1.Padding = new System.Windows.Forms.Padding(4, 28, 4, 4);
			this.taskBox1.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
			this.taskBox1.Size = new System.Drawing.Size(142, 200);
			this.taskBox1.TabIndex = 18;
			//this.taskBox1.TopGap = 2;
			//
			// cbcMisc
			//
			this.cbcMisc.AutoSize = true;
			this.cbcMisc.Location = new System.Drawing.Point(18, 131);
			this.cbcMisc.Name = "cbcMisc";
			this.cbcMisc.Size = new System.Drawing.Size(54, 17);
			this.cbcMisc.TabIndex = 4;
			this.cbcMisc.Text = "Misc.";
			this.cbcMisc.UseVisualStyleBackColor = true;
			this.cbcMisc.CheckedChanged += new System.EventHandler(this.SetCommFlags);
			//
			// cbcStreet
			//
			this.cbcStreet.AutoSize = true;
			this.cbcStreet.Location = new System.Drawing.Point(18, 106);
			this.cbcStreet.Name = "cbcStreet";
			this.cbcStreet.Size = new System.Drawing.Size(61, 17);
			this.cbcStreet.TabIndex = 3;
			this.cbcStreet.Text = "Street";
			this.cbcStreet.UseVisualStyleBackColor = true;
			this.cbcStreet.CheckedChanged += new System.EventHandler(this.SetCommFlags);
			//
			// cbcOuts
			//
			this.cbcOuts.AutoSize = true;
			this.cbcOuts.Location = new System.Drawing.Point(18, 81);
			this.cbcOuts.Name = "cbcOuts";
			this.cbcOuts.Size = new System.Drawing.Size(78, 17);
			this.cbcOuts.TabIndex = 2;
			this.cbcOuts.Text = "Outdoors";
			this.cbcOuts.UseVisualStyleBackColor = true;
			this.cbcOuts.CheckedChanged += new System.EventHandler(this.SetCommFlags);
			//
			// cbcShop
			//
			this.cbcShop.AutoSize = true;
			this.cbcShop.Location = new System.Drawing.Point(18, 56);
			this.cbcShop.Name = "cbcShop";
			this.cbcShop.Size = new System.Drawing.Size(79, 17);
			this.cbcShop.TabIndex = 1;
			this.cbcShop.Text = "Shopping";
			this.cbcShop.UseVisualStyleBackColor = true;
			this.cbcShop.CheckedChanged += new System.EventHandler(this.SetCommFlags);
			//
			// cbcDine
			//
			this.cbcDine.AutoSize = true;
			this.cbcDine.Location = new System.Drawing.Point(18, 31);
			this.cbcDine.Name = "cbcDine";
			this.cbcDine.Size = new System.Drawing.Size(62, 17);
			this.cbcDine.TabIndex = 0;
			this.cbcDine.Text = "Dining";
			this.cbcDine.UseVisualStyleBackColor = true;
			this.cbcDine.CheckedChanged += new System.EventHandler(this.SetCommFlags);
			//
			// groupBox2
			//
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.BodyColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			this.groupBox2.Controls.Add(this.cbBuildSort);
			this.groupBox2.Controls.Add(this.cbaspiration);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.cbhobby);
			this.groupBox2.Controls.Add(this.cbappliances);
			this.groupBox2.Controls.Add(this.cbdecorative);
			this.groupBox2.Controls.Add(this.cbelectronics);
			this.groupBox2.Controls.Add(this.cbgeneral);
			this.groupBox2.Controls.Add(this.cblightning);
			this.groupBox2.Controls.Add(this.cbplumbing);
			this.groupBox2.Controls.Add(this.cbseating);
			this.groupBox2.Controls.Add(this.cbsurfaces);
			this.groupBox2.Controls.Add(this.cbcareer);
			this.groupBox2.Controls.Add(this.cbsort);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.groupBox2.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			this.groupBox2.HeaderText = "Function Sort";
			this.groupBox2.HeaderTextColor = System.Drawing.SystemColors.ControlText;
			this.groupBox2.IconLocation = new System.Drawing.Point(4, 12);
			this.groupBox2.IconSize = new System.Drawing.Size(32, 32);
			this.groupBox2.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
			this.groupBox2.Location = new System.Drawing.Point(225, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 28, 4, 4);
			this.groupBox2.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
			this.groupBox2.Size = new System.Drawing.Size(285, 200);
			this.groupBox2.TabIndex = 17;
			//this.groupBox2.TopGap = 2;
			//
			// cbBuildSort
			//
			this.cbBuildSort.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.cbBuildSort.FormattingEnabled = true;
			this.cbBuildSort.Location = new System.Drawing.Point(118, 169);
			this.cbBuildSort.Name = "cbBuildSort";
			this.cbBuildSort.Size = new System.Drawing.Size(160, 21);
			this.cbBuildSort.TabIndex = 20;
			this.cbBuildSort.SelectedIndexChanged += new System.EventHandler(
				this.cbBuildSort_SelectedIndexChanged
			);
			//
			// cbaspiration
			//
			this.cbaspiration.AutoSize = true;
			this.cbaspiration.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbaspiration.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbaspiration.Location = new System.Drawing.Point(140, 104);
			this.cbaspiration.Name = "cbaspiration";
			this.cbaspiration.Size = new System.Drawing.Size(89, 18);
			this.cbaspiration.TabIndex = 17;
			this.cbaspiration.Text = "Aspiration";
			this.cbaspiration.CheckedChanged += new System.EventHandler(
				this.SetFunctionFlags
			);
			//
			// label5
			//
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			this.label5.Location = new System.Drawing.Point(6, 173);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 13);
			this.label5.TabIndex = 19;
			this.label5.Text = "Build Mode Sort:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// cbhobby
			//
			this.cbhobby.AutoSize = true;
			this.cbhobby.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbhobby.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbhobby.Location = new System.Drawing.Point(140, 84);
			this.cbhobby.Name = "cbhobby";
			this.cbhobby.Size = new System.Drawing.Size(77, 18);
			this.cbhobby.TabIndex = 16;
			this.cbhobby.Text = "Hobbies";
			this.cbhobby.CheckedChanged += new System.EventHandler(
				this.SetFunctionFlags
			);
			//
			// cbappliances
			//
			this.cbappliances.AutoSize = true;
			this.cbappliances.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbappliances.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbappliances.Location = new System.Drawing.Point(18, 24);
			this.cbappliances.Name = "cbappliances";
			this.cbappliances.Size = new System.Drawing.Size(93, 18);
			this.cbappliances.TabIndex = 8;
			this.cbappliances.Text = "Appliances";
			this.cbappliances.CheckedChanged += new System.EventHandler(
				this.SetFunctionFlags
			);
			//
			// cbdecorative
			//
			this.cbdecorative.AutoSize = true;
			this.cbdecorative.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbdecorative.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbdecorative.Location = new System.Drawing.Point(18, 44);
			this.cbdecorative.Name = "cbdecorative";
			this.cbdecorative.Size = new System.Drawing.Size(94, 18);
			this.cbdecorative.TabIndex = 9;
			this.cbdecorative.Text = "Decorative";
			this.cbdecorative.CheckedChanged += new System.EventHandler(
				this.SetFunctionFlags
			);
			//
			// cbelectronics
			//
			this.cbelectronics.AutoSize = true;
			this.cbelectronics.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbelectronics.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbelectronics.Location = new System.Drawing.Point(18, 64);
			this.cbelectronics.Name = "cbelectronics";
			this.cbelectronics.Size = new System.Drawing.Size(93, 18);
			this.cbelectronics.TabIndex = 10;
			this.cbelectronics.Text = "Electronics";
			this.cbelectronics.CheckedChanged += new System.EventHandler(
				this.SetFunctionFlags
			);
			//
			// cbgeneral
			//
			this.cbgeneral.AutoSize = true;
			this.cbgeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbgeneral.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbgeneral.Location = new System.Drawing.Point(18, 84);
			this.cbgeneral.Name = "cbgeneral";
			this.cbgeneral.Size = new System.Drawing.Size(77, 18);
			this.cbgeneral.TabIndex = 11;
			this.cbgeneral.Text = "General";
			this.cbgeneral.CheckedChanged += new System.EventHandler(
				this.SetFunctionFlags
			);
			//
			// cblightning
			//
			this.cblightning.AutoSize = true;
			this.cblightning.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cblightning.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cblightning.Location = new System.Drawing.Point(18, 104);
			this.cblightning.Name = "cblightning";
			this.cblightning.Size = new System.Drawing.Size(65, 18);
			this.cblightning.TabIndex = 12;
			this.cblightning.Text = "Lights";
			this.cblightning.CheckedChanged += new System.EventHandler(
				this.SetFunctionFlags
			);
			//
			// cbplumbing
			//
			this.cbplumbing.AutoSize = true;
			this.cbplumbing.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbplumbing.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbplumbing.Location = new System.Drawing.Point(140, 24);
			this.cbplumbing.Name = "cbplumbing";
			this.cbplumbing.Size = new System.Drawing.Size(84, 18);
			this.cbplumbing.TabIndex = 13;
			this.cbplumbing.Text = "Plumbing";
			this.cbplumbing.CheckedChanged += new System.EventHandler(
				this.SetFunctionFlags
			);
			//
			// cbseating
			//
			this.cbseating.AutoSize = true;
			this.cbseating.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbseating.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbseating.Location = new System.Drawing.Point(140, 44);
			this.cbseating.Name = "cbseating";
			this.cbseating.Size = new System.Drawing.Size(75, 18);
			this.cbseating.TabIndex = 14;
			this.cbseating.Text = "Seating";
			this.cbseating.CheckedChanged += new System.EventHandler(
				this.SetFunctionFlags
			);
			//
			// cbsurfaces
			//
			this.cbsurfaces.AutoSize = true;
			this.cbsurfaces.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbsurfaces.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbsurfaces.Location = new System.Drawing.Point(140, 64);
			this.cbsurfaces.Name = "cbsurfaces";
			this.cbsurfaces.Size = new System.Drawing.Size(82, 18);
			this.cbsurfaces.TabIndex = 15;
			this.cbsurfaces.Text = "Surfaces";
			this.cbsurfaces.CheckedChanged += new System.EventHandler(
				this.SetFunctionFlags
			);
			//
			// cbcareer
			//
			this.cbcareer.AutoSize = true;
			this.cbcareer.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.cbcareer.Location = new System.Drawing.Point(18, 124);
			this.cbcareer.Name = "cbcareer";
			this.cbcareer.Size = new System.Drawing.Size(113, 17);
			this.cbcareer.TabIndex = 0;
			this.cbcareer.Text = "Career Reward";
			this.cbcareer.CheckedChanged += new System.EventHandler(
				this.SetFunctionFlags
			);
			//
			// cbsort
			//
			this.cbsort.Enum = null;
			this.cbsort.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbsort.Location = new System.Drawing.Point(118, 144);
			this.cbsort.Name = "cbsort";
			this.cbsort.ResourceManager = null;
			this.cbsort.Size = new System.Drawing.Size(160, 21);
			this.cbsort.TabIndex = 19;
			this.cbsort.SelectedIndexChanged += new System.EventHandler(
				this.cbsort_SelectedIndexChanged
			);
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label1.Location = new System.Drawing.Point(29, 148);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 18;
			this.label1.Text = "Overall Sort:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// groupBox1
			//
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.BodyColor = System.Drawing.SystemColors.ControlLight;
			this.groupBox1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			this.groupBox1.Controls.Add(this.lbprise);
			this.groupBox1.Controls.Add(this.tbPrice);
			this.groupBox1.Controls.Add(this.cbkids);
			this.groupBox1.Controls.Add(this.cbbathroom);
			this.groupBox1.Controls.Add(this.cbbedroom);
			this.groupBox1.Controls.Add(this.cbdinigroom);
			this.groupBox1.Controls.Add(this.cbkitchen);
			this.groupBox1.Controls.Add(this.cbmisc);
			this.groupBox1.Controls.Add(this.cboutside);
			this.groupBox1.Controls.Add(this.cblivingroom);
			this.groupBox1.Controls.Add(this.cbstudy);
			this.groupBox1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.groupBox1.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			this.groupBox1.HeaderText = "Room Sort";
			this.groupBox1.HeaderTextColor = System.Drawing.SystemColors.ControlText;
			this.groupBox1.IconLocation = new System.Drawing.Point(4, 12);
			this.groupBox1.IconSize = new System.Drawing.Size(32, 32);
			this.groupBox1.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 28, 4, 4);
			this.groupBox1.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
			this.groupBox1.Size = new System.Drawing.Size(211, 200);
			this.groupBox1.TabIndex = 16;
			//this.groupBox1.TopGap = 2;
			//
			// lbprise
			//
			this.lbprise.AutoSize = true;
			this.lbprise.BackColor = System.Drawing.Color.Transparent;
			this.lbprise.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			this.lbprise.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbprise.Location = new System.Drawing.Point(94, 173);
			this.lbprise.Name = "lbprise";
			this.lbprise.Size = new System.Drawing.Size(44, 13);
			this.lbprise.TabIndex = 24;
			this.lbprise.Text = "Price:";
			//
			// tbPrice
			//
			this.tbPrice.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbPrice.Location = new System.Drawing.Point(140, 169);
			this.tbPrice.Name = "tbPrice";
			this.tbPrice.Size = new System.Drawing.Size(64, 21);
			this.tbPrice.TabIndex = 23;
			this.tbPrice.Text = "0";
			this.tbPrice.TextChanged += new System.EventHandler(
				this.tbPrice_TextChanged
			);
			//
			// cbkids
			//
			this.cbkids.AutoSize = true;
			this.cbkids.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbkids.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbkids.Location = new System.Drawing.Point(122, 105);
			this.cbkids.Name = "cbkids";
			this.cbkids.Size = new System.Drawing.Size(56, 18);
			this.cbkids.TabIndex = 8;
			this.cbkids.Text = "Kids";
			this.cbkids.CheckedChanged += new System.EventHandler(this.SetRoomFlags);
			//
			// cbbathroom
			//
			this.cbbathroom.AutoSize = true;
			this.cbbathroom.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbbathroom.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbbathroom.Location = new System.Drawing.Point(17, 30);
			this.cbbathroom.Name = "cbbathroom";
			this.cbbathroom.Size = new System.Drawing.Size(88, 18);
			this.cbbathroom.TabIndex = 0;
			this.cbbathroom.Text = "Bathroom";
			this.cbbathroom.CheckedChanged += new System.EventHandler(
				this.SetRoomFlags
			);
			//
			// cbbedroom
			//
			this.cbbedroom.AutoSize = true;
			this.cbbedroom.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbbedroom.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbbedroom.Location = new System.Drawing.Point(17, 55);
			this.cbbedroom.Name = "cbbedroom";
			this.cbbedroom.Size = new System.Drawing.Size(84, 18);
			this.cbbedroom.TabIndex = 1;
			this.cbbedroom.Text = "Bedroom";
			this.cbbedroom.CheckedChanged += new System.EventHandler(this.SetRoomFlags);
			//
			// cbdinigroom
			//
			this.cbdinigroom.AutoSize = true;
			this.cbdinigroom.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbdinigroom.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbdinigroom.Location = new System.Drawing.Point(17, 80);
			this.cbdinigroom.Name = "cbdinigroom";
			this.cbdinigroom.Size = new System.Drawing.Size(98, 18);
			this.cbdinigroom.TabIndex = 2;
			this.cbdinigroom.Text = "Diningroom";
			this.cbdinigroom.CheckedChanged += new System.EventHandler(
				this.SetRoomFlags
			);
			//
			// cbkitchen
			//
			this.cbkitchen.AutoSize = true;
			this.cbkitchen.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbkitchen.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbkitchen.Location = new System.Drawing.Point(17, 105);
			this.cbkitchen.Name = "cbkitchen";
			this.cbkitchen.Size = new System.Drawing.Size(74, 18);
			this.cbkitchen.TabIndex = 3;
			this.cbkitchen.Text = "Kitchen";
			this.cbkitchen.CheckedChanged += new System.EventHandler(this.SetRoomFlags);
			//
			// cbmisc
			//
			this.cbmisc.AutoSize = true;
			this.cbmisc.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbmisc.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbmisc.Location = new System.Drawing.Point(122, 30);
			this.cbmisc.Name = "cbmisc";
			this.cbmisc.Size = new System.Drawing.Size(60, 18);
			this.cbmisc.TabIndex = 4;
			this.cbmisc.Text = "Misc.";
			this.cbmisc.CheckedChanged += new System.EventHandler(this.SetRoomFlags);
			//
			// cboutside
			//
			this.cboutside.AutoSize = true;
			this.cboutside.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cboutside.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cboutside.Location = new System.Drawing.Point(122, 55);
			this.cboutside.Name = "cboutside";
			this.cboutside.Size = new System.Drawing.Size(75, 18);
			this.cboutside.TabIndex = 5;
			this.cboutside.Text = "Outside";
			this.cboutside.CheckedChanged += new System.EventHandler(this.SetRoomFlags);
			//
			// cblivingroom
			//
			this.cblivingroom.AutoSize = true;
			this.cblivingroom.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cblivingroom.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cblivingroom.Location = new System.Drawing.Point(17, 130);
			this.cblivingroom.Name = "cblivingroom";
			this.cblivingroom.Size = new System.Drawing.Size(95, 18);
			this.cblivingroom.TabIndex = 6;
			this.cblivingroom.Text = "Livingroom";
			this.cblivingroom.CheckedChanged += new System.EventHandler(
				this.SetRoomFlags
			);
			//
			// cbstudy
			//
			this.cbstudy.AutoSize = true;
			this.cbstudy.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbstudy.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbstudy.Location = new System.Drawing.Point(122, 80);
			this.cbstudy.Name = "cbstudy";
			this.cbstudy.Size = new System.Drawing.Size(65, 18);
			this.cbstudy.TabIndex = 7;
			this.cbstudy.Text = "Study";
			this.cbstudy.CheckedChanged += new System.EventHandler(this.SetRoomFlags);
			//
			// tpreqeps
			//
			this.tpreqeps.Controls.Add(this.pnpritty);
			this.tpreqeps.Location = new System.Drawing.Point(4, 22);
			this.tpreqeps.Name = "tpreqeps";
			this.tpreqeps.Size = new System.Drawing.Size(680, 242);
			this.tpreqeps.TabIndex = 2;
			this.tpreqeps.Text = "Required Ep";
			this.tpreqeps.UseVisualStyleBackColor = true;
			//
			// pnpritty
			//
			this.pnpritty.BackColor = System.Drawing.Color.Transparent;
			//this.pnpritty.BackgroundImageAnchor = System.Windows.Forms.Panel.ImageLayout.TopRight;
			//this.pnpritty.BackgroundImageZoomToFit = true;
			this.pnpritty.Controls.Add(this.tbreqeps);
			this.pnpritty.Dock = System.Windows.Forms.DockStyle.Fill;
			//this.pnpritty.EndColour = System.Drawing.SystemColors.Control;
			this.pnpritty.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.pnpritty.Location = new System.Drawing.Point(0, 0);
			//this.pnpritty.MiddleColour = System.Drawing.SystemColors.Control;
			this.pnpritty.Name = "pnpritty";
			this.pnpritty.Size = new System.Drawing.Size(680, 242);
			//this.pnpritty.StartColour = System.Drawing.SystemColors.Control;
			this.pnpritty.TabIndex = 0;
			//
			// tbreqeps
			//
			this.tbreqeps.BackColor = System.Drawing.Color.Transparent;
			this.tbreqeps.BodyColor = System.Drawing.SystemColors.ControlLight;
			this.tbreqeps.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			this.tbreqeps.Controls.Add(this.lbepnote);
			this.tbreqeps.Controls.Add(this.lbgamef2);
			this.tbreqeps.Controls.Add(this.cbStoreEd);
			this.tbreqeps.Controls.Add(this.cbMansion);
			this.tbreqeps.Controls.Add(this.cbApartments);
			this.tbreqeps.Controls.Add(this.cbIkeaHome);
			this.tbreqeps.Controls.Add(this.cbKitchens);
			this.tbreqeps.Controls.Add(this.cbFreeTime);
			this.tbreqeps.Controls.Add(this.cbExtras);
			this.tbreqeps.Controls.Add(this.cbTeenStyle);
			this.tbreqeps.Controls.Add(this.cbBonVoyage);
			this.tbreqeps.Controls.Add(this.cbFashion);
			this.tbreqeps.Controls.Add(this.cbCelebrations);
			this.tbreqeps.Controls.Add(this.cbSeasons);
			this.tbreqeps.Controls.Add(this.cbPets);
			this.tbreqeps.Controls.Add(this.cbGlamour);
			this.tbreqeps.Controls.Add(this.cbFamilyFun);
			this.tbreqeps.Controls.Add(this.cbBusiness);
			this.tbreqeps.Controls.Add(this.cbNightlife);
			this.tbreqeps.Controls.Add(this.cbUniversity);
			this.tbreqeps.Controls.Add(this.cbBase);
			this.tbreqeps.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			this.tbreqeps.HeaderText = "Required Ep or Sp";
			this.tbreqeps.HeaderTextColor = System.Drawing.SystemColors.ControlText;
			this.tbreqeps.IconLocation = new System.Drawing.Point(4, 12);
			this.tbreqeps.IconSize = new System.Drawing.Size(32, 32);
			this.tbreqeps.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
			this.tbreqeps.Location = new System.Drawing.Point(8, 8);
			this.tbreqeps.Name = "tbreqeps";
			this.tbreqeps.Padding = new System.Windows.Forms.Padding(4, 28, 4, 4);
			this.tbreqeps.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
			this.tbreqeps.Size = new System.Drawing.Size(442, 228);
			this.tbreqeps.TabIndex = 0;
			//this.tbreqeps.TopGap = 2;
			//
			// lbepnote
			//
			this.lbepnote.AutoSize = true;
			this.lbepnote.Location = new System.Drawing.Point(3, 30);
			this.lbepnote.Name = "lbepnote";
			this.lbepnote.Size = new System.Drawing.Size(435, 13);
			this.lbepnote.TabIndex = 40;
			this.lbepnote.Text =
				"These Flags are \'OR\' If you set two EPs then either EP is required, not both";
			//
			// lbgamef2
			//
			this.lbgamef2.AutoSize = true;
			this.lbgamef2.Location = new System.Drawing.Point(289, 133);
			this.lbgamef2.Name = "lbgamef2";
			this.lbgamef2.Size = new System.Drawing.Size(127, 13);
			this.lbgamef2.TabIndex = 39;
			this.lbgamef2.Text = "Game Edition Flags 2";
			//
			// cbStoreEd
			//
			this.cbStoreEd.AutoSize = true;
			this.cbStoreEd.Location = new System.Drawing.Point(289, 200);
			this.cbStoreEd.Name = "cbStoreEd";
			this.cbStoreEd.Size = new System.Drawing.Size(136, 17);
			this.cbStoreEd.TabIndex = 38;
			this.cbStoreEd.Text = "Store Edition (new)";
			this.cbStoreEd.UseVisualStyleBackColor = true;
			this.cbStoreEd.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbMansion
			//
			this.cbMansion.AutoSize = true;
			this.cbMansion.Location = new System.Drawing.Point(289, 177);
			this.cbMansion.Name = "cbMansion";
			this.cbMansion.Size = new System.Drawing.Size(131, 17);
			this.cbMansion.TabIndex = 37;
			this.cbMansion.Text = "Mansion + Garden";
			this.cbMansion.UseVisualStyleBackColor = true;
			this.cbMansion.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbApartments
			//
			this.cbApartments.AutoSize = true;
			this.cbApartments.Location = new System.Drawing.Point(289, 154);
			this.cbApartments.Name = "cbApartments";
			this.cbApartments.Size = new System.Drawing.Size(110, 17);
			this.cbApartments.TabIndex = 36;
			this.cbApartments.Text = "Apartment Life";
			this.cbApartments.UseVisualStyleBackColor = true;
			this.cbApartments.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbIkeaHome
			//
			this.cbIkeaHome.AutoSize = true;
			this.cbIkeaHome.Location = new System.Drawing.Point(289, 85);
			this.cbIkeaHome.Name = "cbIkeaHome";
			this.cbIkeaHome.Size = new System.Drawing.Size(91, 17);
			this.cbIkeaHome.TabIndex = 35;
			this.cbIkeaHome.Text = "IKEA Home";
			this.cbIkeaHome.UseVisualStyleBackColor = true;
			this.cbIkeaHome.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbKitchens
			//
			this.cbKitchens.AutoSize = true;
			this.cbKitchens.Location = new System.Drawing.Point(289, 62);
			this.cbKitchens.Name = "cbKitchens";
			this.cbKitchens.Size = new System.Drawing.Size(141, 17);
			this.cbKitchens.TabIndex = 34;
			this.cbKitchens.Text = "Kitchen + Bathroom";
			this.cbKitchens.UseVisualStyleBackColor = true;
			this.cbKitchens.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbFreeTime
			//
			this.cbFreeTime.AutoSize = true;
			this.cbFreeTime.Location = new System.Drawing.Point(152, 200);
			this.cbFreeTime.Name = "cbFreeTime";
			this.cbFreeTime.Size = new System.Drawing.Size(83, 17);
			this.cbFreeTime.TabIndex = 33;
			this.cbFreeTime.Text = "Free Time";
			this.cbFreeTime.UseVisualStyleBackColor = true;
			this.cbFreeTime.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbExtras
			//
			this.cbExtras.AutoSize = true;
			this.cbExtras.Location = new System.Drawing.Point(152, 177);
			this.cbExtras.Name = "cbExtras";
			this.cbExtras.Size = new System.Drawing.Size(130, 17);
			this.cbExtras.TabIndex = 32;
			this.cbExtras.Text = "Store Edition (old)";
			this.cbExtras.UseVisualStyleBackColor = true;
			this.cbExtras.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbTeenStyle
			//
			this.cbTeenStyle.AutoSize = true;
			this.cbTeenStyle.Location = new System.Drawing.Point(152, 154);
			this.cbTeenStyle.Name = "cbTeenStyle";
			this.cbTeenStyle.Size = new System.Drawing.Size(86, 17);
			this.cbTeenStyle.TabIndex = 31;
			this.cbTeenStyle.Text = "Teen Style";
			this.cbTeenStyle.UseVisualStyleBackColor = true;
			this.cbTeenStyle.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbBonVoyage
			//
			this.cbBonVoyage.AutoSize = true;
			this.cbBonVoyage.Location = new System.Drawing.Point(152, 131);
			this.cbBonVoyage.Name = "cbBonVoyage";
			this.cbBonVoyage.Size = new System.Drawing.Size(94, 17);
			this.cbBonVoyage.TabIndex = 30;
			this.cbBonVoyage.Text = "Bon Voyage";
			this.cbBonVoyage.UseVisualStyleBackColor = true;
			this.cbBonVoyage.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbFashion
			//
			this.cbFashion.AutoSize = true;
			this.cbFashion.Location = new System.Drawing.Point(152, 108);
			this.cbFashion.Name = "cbFashion";
			this.cbFashion.Size = new System.Drawing.Size(131, 17);
			this.cbFashion.TabIndex = 29;
			this.cbFashion.Text = "HM� Fashion Stuff";
			this.cbFashion.UseVisualStyleBackColor = true;
			this.cbFashion.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbCelebrations
			//
			this.cbCelebrations.AutoSize = true;
			this.cbCelebrations.Location = new System.Drawing.Point(152, 85);
			this.cbCelebrations.Name = "cbCelebrations";
			this.cbCelebrations.Size = new System.Drawing.Size(96, 17);
			this.cbCelebrations.TabIndex = 28;
			this.cbCelebrations.Text = "Celebration!";
			this.cbCelebrations.UseVisualStyleBackColor = true;
			this.cbCelebrations.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbSeasons
			//
			this.cbSeasons.AutoSize = true;
			this.cbSeasons.Location = new System.Drawing.Point(152, 62);
			this.cbSeasons.Name = "cbSeasons";
			this.cbSeasons.Size = new System.Drawing.Size(74, 17);
			this.cbSeasons.TabIndex = 27;
			this.cbSeasons.Text = "Seasons";
			this.cbSeasons.UseVisualStyleBackColor = true;
			this.cbSeasons.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbPets
			//
			this.cbPets.AutoSize = true;
			this.cbPets.Location = new System.Drawing.Point(10, 200);
			this.cbPets.Name = "cbPets";
			this.cbPets.Size = new System.Drawing.Size(50, 17);
			this.cbPets.TabIndex = 26;
			this.cbPets.Text = "Pets";
			this.cbPets.UseVisualStyleBackColor = true;
			this.cbPets.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbGlamour
			//
			this.cbGlamour.AutoSize = true;
			this.cbGlamour.Location = new System.Drawing.Point(10, 177);
			this.cbGlamour.Name = "cbGlamour";
			this.cbGlamour.Size = new System.Drawing.Size(99, 17);
			this.cbGlamour.TabIndex = 25;
			this.cbGlamour.Text = "Glamour Life";
			this.cbGlamour.UseVisualStyleBackColor = true;
			this.cbGlamour.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbFamilyFun
			//
			this.cbFamilyFun.AutoSize = true;
			this.cbFamilyFun.Location = new System.Drawing.Point(10, 154);
			this.cbFamilyFun.Name = "cbFamilyFun";
			this.cbFamilyFun.Size = new System.Drawing.Size(86, 17);
			this.cbFamilyFun.TabIndex = 24;
			this.cbFamilyFun.Text = "Family Fun";
			this.cbFamilyFun.UseVisualStyleBackColor = true;
			this.cbFamilyFun.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbBusiness
			//
			this.cbBusiness.AutoSize = true;
			this.cbBusiness.Location = new System.Drawing.Point(10, 131);
			this.cbBusiness.Name = "cbBusiness";
			this.cbBusiness.Size = new System.Drawing.Size(130, 17);
			this.cbBusiness.TabIndex = 23;
			this.cbBusiness.Text = "Open for Business";
			this.cbBusiness.UseVisualStyleBackColor = true;
			this.cbBusiness.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbNightlife
			//
			this.cbNightlife.AutoSize = true;
			this.cbNightlife.Location = new System.Drawing.Point(10, 108);
			this.cbNightlife.Name = "cbNightlife";
			this.cbNightlife.Size = new System.Drawing.Size(72, 17);
			this.cbNightlife.TabIndex = 22;
			this.cbNightlife.Text = "Nightlife";
			this.cbNightlife.UseVisualStyleBackColor = true;
			this.cbNightlife.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbUniversity
			//
			this.cbUniversity.AutoSize = true;
			this.cbUniversity.Location = new System.Drawing.Point(10, 85);
			this.cbUniversity.Name = "cbUniversity";
			this.cbUniversity.Size = new System.Drawing.Size(83, 17);
			this.cbUniversity.TabIndex = 21;
			this.cbUniversity.Text = "University";
			this.cbUniversity.UseVisualStyleBackColor = true;
			this.cbUniversity.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// cbBase
			//
			this.cbBase.AutoSize = true;
			this.cbBase.Location = new System.Drawing.Point(10, 62);
			this.cbBase.Name = "cbBase";
			this.cbBase.Size = new System.Drawing.Size(92, 17);
			this.cbBase.TabIndex = 20;
			this.cbBase.Text = "Base Game";
			this.cbBase.UseVisualStyleBackColor = true;
			this.cbBase.CheckedChanged += new System.EventHandler(
				this.SetExpansionFlags
			);
			//
			// tpraw
			//
			this.tpraw.Controls.Add(this.panel1);
			this.tpraw.Controls.Add(this.pg);
			this.tpraw.Location = new System.Drawing.Point(4, 22);
			this.tpraw.Name = "tpraw";
			this.tpraw.Size = new System.Drawing.Size(680, 242);
			this.tpraw.TabIndex = 1;
			this.tpraw.Text = "RAW Data";
			//
			// panel1
			//
			this.panel1.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.panel1.Controls.Add(this.rbhex);
			this.panel1.Controls.Add(this.rbdec);
			this.panel1.Controls.Add(this.rbbin);
			this.panel1.Location = new System.Drawing.Point(420, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(256, 16);
			this.panel1.TabIndex = 4;
			//
			// rbhex
			//
			this.rbhex.BackColor = System.Drawing.Color.Transparent;
			this.rbhex.Location = new System.Drawing.Point(152, 0);
			this.rbhex.Name = "rbhex";
			this.rbhex.Size = new System.Drawing.Size(104, 16);
			this.rbhex.TabIndex = 6;
			this.rbhex.Text = "Hexadecimal";
			this.rbhex.UseVisualStyleBackColor = false;
			this.rbhex.CheckedChanged += new System.EventHandler(this.DigitChanged);
			//
			// rbdec
			//
			this.rbdec.BackColor = System.Drawing.Color.Transparent;
			this.rbdec.Location = new System.Drawing.Point(72, 0);
			this.rbdec.Name = "rbdec";
			this.rbdec.Size = new System.Drawing.Size(72, 16);
			this.rbdec.TabIndex = 5;
			this.rbdec.Text = "Decimal";
			this.rbdec.UseVisualStyleBackColor = false;
			this.rbdec.CheckedChanged += new System.EventHandler(this.DigitChanged);
			//
			// rbbin
			//
			this.rbbin.BackColor = System.Drawing.Color.Transparent;
			this.rbbin.Location = new System.Drawing.Point(0, 0);
			this.rbbin.Name = "rbbin";
			this.rbbin.Size = new System.Drawing.Size(64, 16);
			this.rbbin.TabIndex = 4;
			this.rbbin.Text = "Binary";
			this.rbbin.UseVisualStyleBackColor = false;
			this.rbbin.CheckedChanged += new System.EventHandler(this.DigitChanged);
			//
			// pg
			//
			this.pg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pg.HelpVisible = false;
			this.pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pg.Location = new System.Drawing.Point(0, 0);
			this.pg.Name = "pg";
			this.pg.Size = new System.Drawing.Size(680, 242);
			this.pg.TabIndex = 0;
			this.pg.PropertyValueChanged +=
				new System.Windows.Forms.PropertyValueChangedEventHandler(
					this.PropChanged
				);
			//
			// tbtype
			//
			this.tbtype.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbtype.Location = new System.Drawing.Point(920, 32);
			this.tbtype.Name = "tbtype";
			this.tbtype.ReadOnly = true;
			this.tbtype.Size = new System.Drawing.Size(56, 21);
			this.tbtype.TabIndex = 25;
			this.tbtype.Text = "0xDDDD";
			//
			// cbtype
			//
			this.cbtype.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.cbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbtype.Location = new System.Drawing.Point(752, 32);
			this.cbtype.Name = "cbtype";
			this.cbtype.Size = new System.Drawing.Size(168, 21);
			this.cbtype.TabIndex = 24;
			this.cbtype.SelectedIndexChanged += new System.EventHandler(
				this.ChangeType
			);
			//
			// label63
			//
			this.label63.AutoSize = true;
			this.label63.BackColor = System.Drawing.Color.Transparent;
			this.label63.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			this.label63.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label63.Location = new System.Drawing.Point(41, 207);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(75, 13);
			this.label63.TabIndex = 22;
			this.label63.Text = "Orig. GUID";
			//
			// tbproxguid
			//
			this.tbproxguid.Location = new System.Drawing.Point(122, 231);
			this.tbproxguid.Name = "tbproxguid";
			this.tbproxguid.Size = new System.Drawing.Size(96, 21);
			this.tbproxguid.TabIndex = 21;
			this.tbproxguid.Text = "0xDDDDDDDD";
			this.tbproxguid.TextChanged += new System.EventHandler(this.SetGuid);
			//
			// label97
			//
			this.label97.AutoSize = true;
			this.label97.BackColor = System.Drawing.Color.Transparent;
			this.label97.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			this.label97.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label97.Location = new System.Drawing.Point(17, 234);
			this.label97.Name = "label97";
			this.label97.Size = new System.Drawing.Size(99, 13);
			this.label97.TabIndex = 20;
			this.label97.Text = "Fallback GUID";
			//
			// tborgguid
			//
			this.tborgguid.Location = new System.Drawing.Point(122, 204);
			this.tborgguid.Name = "tborgguid";
			this.tborgguid.Size = new System.Drawing.Size(96, 21);
			this.tborgguid.TabIndex = 19;
			this.tborgguid.Text = "0xDDDDDDDD";
			this.tborgguid.TextChanged += new System.EventHandler(this.SetGuid);
			//
			// llgetGUID
			//
			this.llgetGUID.AutoSize = true;
			this.llgetGUID.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.llgetGUID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.llgetGUID.LinkArea = new System.Windows.Forms.LinkArea(0, 9);
			this.llgetGUID.Location = new System.Drawing.Point(213, 99);
			this.llgetGUID.Name = "llgetGUID";
			this.llgetGUID.Size = new System.Drawing.Size(80, 13);
			this.llgetGUID.TabIndex = 16;
			this.llgetGUID.TabStop = true;
			this.llgetGUID.Text = "make GUID";
			this.llgetGUID.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GetGuid);
			//
			// label65
			//
			this.label65.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.label65.AutoSize = true;
			this.label65.BackColor = System.Drawing.Color.Transparent;
			this.label65.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			this.label65.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label65.Location = new System.Drawing.Point(661, 35);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(85, 13);
			this.label65.TabIndex = 12;
			this.label65.Text = "Object Type";
			//
			// tbflname
			//
			this.tbflname.Location = new System.Drawing.Point(112, 32);
			this.tbflname.Name = "tbflname";
			this.tbflname.Size = new System.Drawing.Size(543, 21);
			this.tbflname.TabIndex = 11;
			this.tbflname.TextChanged += new System.EventHandler(this.SetFlName);
			//
			// label9
			//
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label9.Location = new System.Drawing.Point(45, 35);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(67, 13);
			this.label9.TabIndex = 10;
			this.label9.Text = "Filename";
			//
			// tbguid
			//
			this.tbguid.Location = new System.Drawing.Point(112, 96);
			this.tbguid.Name = "tbguid";
			this.tbguid.Size = new System.Drawing.Size(96, 21);
			this.tbguid.TabIndex = 9;
			this.tbguid.Text = "0xDDDDDDDD";
			this.tbguid.TextChanged += new System.EventHandler(this.SetGuide);
			//
			// label8
			//
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label8.Location = new System.Drawing.Point(69, 99);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "GUID";
			//
			// panel6
			//
			this.panel6.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			//this.panel6.CanCommit = true;
			//this.panel6.HeaderText = "Object Data Editor";
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Margin = new System.Windows.Forms.Padding(0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(984, 24);
			this.panel6.TabIndex = 0;
			//this.panel6.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.OnCommit);
			//
			// toolTip1
			//
			this.toolTip1.AutomaticDelay = 200;
			this.toolTip1.AutoPopDelay = 6000;
			this.toolTip1.InitialDelay = 200;
			this.toolTip1.ReshowDelay = 40;
			//
			// ExtObjdForm
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(984, 325);
			this.Controls.Add(this.pnobjd);
			this.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.Name = "ExtObjdForm";
			this.Text = "ExtObjdForm";
			this.pnobjd.ResumeLayout(false);
			this.pnobjd.PerformLayout();
			this.tc.ResumeLayout(false);
			this.tpcatalogsort.ResumeLayout(false);
			this.pngradient.ResumeLayout(false);
			this.taskBox1.ResumeLayout(false);
			this.taskBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tpreqeps.ResumeLayout(false);
			this.pnpritty.ResumeLayout(false);
			this.tbreqeps.ResumeLayout(false);
			this.tbreqeps.PerformLayout();
			this.tpraw.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private void ChangeType(object sender, System.EventArgs e)
		{
			if (this.Tag != null)
				return;
			this.Tag = true;

			try
			{
				if (cbtype.SelectedIndex < 0)
					return;
				Data.ObjectTypes ot = (Data.ObjectTypes)
					cbtype.Items[cbtype.SelectedIndex];
				tbtype.Text = "0x" + Helper.HexString((ushort)ot);

				wrapper.Type = ot;
				wrapper.Changed = true;
				this.btnUpdateMMAT.Visible =
					this.label2.Visible =
					this.cball.Visible =
					this.lbIsOk.Visible =
						false;
				this.llgetGUID.Visible = (
					UserVerification.HaveUserId
					&& wrapper.Type != SimPe.Data.ObjectTypes.Person
					&& wrapper.Type != SimPe.Data.ObjectTypes.UnlinkedSim
				);
				//this.lladdgooee.Visible = (UserVerification.HaveUserId && !SimPe.Plugin.Subhoods.GuidExists(wrapper.Guid) && wrapper.Type != SimPe.Data.ObjectTypes.Person && wrapper.Type != SimPe.Data.ObjectTypes.UnlinkedSim);
				this.Tag = null;
			}
			finally
			{
				this.Tag = null;
			}
		}

		private void OnCommit(object sender, System.EventArgs e)
		{
			this.lbIsOk.Visible = false;
			if (this.pg.SelectedObject != null)
				UpdateData();
			wrapper.SynchronizeUserData();
		}

		private void SetRoomFlags(object sender, System.EventArgs e)
		{
			if (this.Tag != null)
				return;
			this.Tag = true;

			try
			{
				wrapper.RoomSort.InBathroom = cbbathroom.Checked;
				wrapper.RoomSort.InBedroom = cbbedroom.Checked;
				wrapper.RoomSort.InDiningRoom = cbdinigroom.Checked;
				wrapper.RoomSort.InKitchen = cbkitchen.Checked;
				wrapper.RoomSort.InLivingRoom = cblivingroom.Checked;
				wrapper.RoomSort.InMisc = cbmisc.Checked;
				wrapper.RoomSort.InOutside = cboutside.Checked;
				wrapper.RoomSort.InStudy = cbstudy.Checked;
				wrapper.RoomSort.InKids = cbkids.Checked;

				wrapper.Changed = true;
			}
			finally
			{
				this.Tag = null;
			}
		}

		private void SetCommFlags(object sender, System.EventArgs e)
		{
			if (this.Tag != null)
				return;
			this.Tag = true;
			try
			{
				wrapper.CommSort.InDining = cbcDine.Checked;
				wrapper.CommSort.InShopping = cbcShop.Checked;
				wrapper.CommSort.InOutdoors = cbcOuts.Checked;
				wrapper.CommSort.InStreet = cbcStreet.Checked;
				wrapper.CommSort.InMiscel = cbcMisc.Checked;

				wrapper.Changed = true;
			}
			finally
			{
				this.Tag = null;
			}
		}

		private void SetFunctionFlags(object sender, System.EventArgs e)
		{
			if (this.Tag != null)
				return;
			this.Tag = true;

			try
			{
				wrapper.FunctionSort.InAppliances = this.cbappliances.Checked;
				wrapper.FunctionSort.InDecorative = this.cbdecorative.Checked;
				wrapper.FunctionSort.InElectronics = this.cbelectronics.Checked;
				wrapper.FunctionSort.InGeneral = this.cbgeneral.Checked;
				wrapper.FunctionSort.InLighting = this.cblightning.Checked;
				wrapper.FunctionSort.InPlumbing = this.cbplumbing.Checked;
				wrapper.FunctionSort.InSeating = this.cbseating.Checked;
				wrapper.FunctionSort.InSurfaces = this.cbsurfaces.Checked;
				wrapper.FunctionSort.InHobbies = this.cbhobby.Checked;
				wrapper.FunctionSort.InAspirationRewards = this.cbaspiration.Checked;
				wrapper.FunctionSort.InCareerRewards = this.cbcareer.Checked;

				wrapper.Changed = true;
			}
			finally
			{
				this.Tag = null;
			}
		}

		private void SetExpansionFlags(object sender, System.EventArgs e)
		{
			if (this.Tag != null)
				return;
			this.Tag = true;

			try
			{
				if (cbBase.Checked)
				{
					cbUniversity.Checked =
						cbNightlife.Checked =
						cbBusiness.Checked =
						cbFamilyFun.Checked =
						cbGlamour.Checked =
						cbSeasons.Checked =
							false;
					cbCelebrations.Checked =
						cbFashion.Checked =
						cbBonVoyage.Checked =
						cbTeenStyle.Checked =
						cbExtras.Checked =
						cbFreeTime.Checked =
							false;
					cbPets.Checked =
						cbKitchens.Checked =
						cbIkeaHome.Checked =
						cbApartments.Checked =
						cbMansion.Checked =
						cbStoreEd.Checked =
							false;
				}
				wrapper.EpRequired1.Basegame = cbBase.Checked;
				wrapper.EpRequired1.University = cbUniversity.Checked;
				wrapper.EpRequired1.Nightlife = cbNightlife.Checked;
				wrapper.EpRequired1.Business = cbBusiness.Checked;
				wrapper.EpRequired1.FamilyFun = cbFamilyFun.Checked;
				wrapper.EpRequired1.GlamourLife = cbGlamour.Checked;
				wrapper.EpRequired1.Pets = cbPets.Checked;
				wrapper.EpRequired1.Seasons = cbSeasons.Checked;
				wrapper.EpRequired1.Celebration = cbCelebrations.Checked;
				wrapper.EpRequired1.Fashion = cbFashion.Checked;
				wrapper.EpRequired1.BonVoyage = cbBonVoyage.Checked;
				wrapper.EpRequired1.TeenStyle = cbTeenStyle.Checked;
				wrapper.EpRequired1.StoreEdition_old = cbExtras.Checked;
				wrapper.EpRequired1.Freetime = cbFreeTime.Checked;
				wrapper.EpRequired1.KitchenBath = cbKitchens.Checked;
				wrapper.EpRequired1.IkeaHome = cbIkeaHome.Checked;
				wrapper.EpRequired2.ApartmentLife = cbApartments.Checked;
				wrapper.EpRequired2.MansionGarden = cbMansion.Checked;
				wrapper.EpRequired2.StoreEdition = cbStoreEd.Checked;

				wrapper.Changed = true;
			}
			finally
			{
				this.Tag = null;
			}
		}

		private void SetGuide(object sender, System.EventArgs e)
		{
			if (this.Tag != null)
				return;
			this.Tag = true;
			try
			{
				wrapper.Guid = Convert.ToUInt32(tbguid.Text, 16);
				wrapper.Changed = true;
			}
			catch (Exception) { }
			finally
			{
				if (
					wrapper.Type != SimPe.Data.ObjectTypes.Person
					&& wrapper.Type != SimPe.Data.ObjectTypes.UnlinkedSim
				)
				{
					this.btnUpdateMMAT.Visible =
						this.label2.Visible =
						this.cball.Visible =
						this.lbIsOk.Visible =
							true;
					//this.lladdgooee.Visible = (UserVerification.HaveUserId && !SimPe.Plugin.Subhoods.GuidExists(wrapper.Guid));
				}
				this.Tag = null;
			}
		}

		private void SetGuid(object sender, System.EventArgs e)
		{
			if (this.Tag != null)
				return;
			this.Tag = true;
			try
			{
				wrapper.ProxyGuid = Convert.ToUInt32(this.tbproxguid.Text, 16);
				wrapper.OriginalGuid = Convert.ToUInt32(this.tborgguid.Text, 16);
				wrapper.DiagonalGuid = Convert.ToUInt32(this.tbdiag.Text, 16);
				wrapper.GridAlignedGuid = Convert.ToUInt32(this.tbgrid.Text, 16);
				wrapper.Changed = true;
				if (!Helper.WindowsRegistry.HiddenMode && UserVerification.HaveUserId)
				{
					//this.toolTip1.SetToolTip(this.tbgrid, SimPe.Plugin.Subhoods.getgooee(wrapper.GridAlignedGuid));
					//this.toolTip1.SetToolTip(this.tbdiag, SimPe.Plugin.Subhoods.getgooee(wrapper.DiagonalGuid));
					//this.toolTip1.SetToolTip(this.tbproxguid, SimPe.Plugin.Subhoods.getgooee(wrapper.ProxyGuid));
					//this.toolTip1.SetToolTip(this.tborgguid, SimPe.Plugin.Subhoods.getgooee(wrapper.OriginalGuid));
				}
			}
			catch (Exception) { }
			finally
			{
				this.lbIsOk.Visible = true;
				this.Tag = null;
			}
		}

		private void GetGuid(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			uint gooy = wrapper.createguid;
			if (gooy != 0)
			{
				this.tbguid.Text = "0x" + Helper.HexString(gooy);
				this.llgetGUID.LinkVisited = true;
			}
			else
				this.llgetGUID.Links[0].Enabled = false;
		}

		private void lladdgooee_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			//if (SimPe.Plugin.Subhoods.GuidAdd(wrapper.Guid, wrapper.FileDescriptor.Group, (ushort)(wrapper.Type), wrapper.FileName))
			//    this.lladdgooee.LinkVisited = true;
			//else this.lladdgooee.Links[0].Enabled = false;
		}

		private void btnUpdateMMAT_Click(object sender, System.EventArgs e)
		{
			if ((wrapper.Guid != initialguid) || (cball.Checked))
			{
				SimPe.Plugin.FixGuid fg = new SimPe.Plugin.FixGuid(wrapper.Package);
				if (cball.Checked)
				{
					fg.FixGuids(wrapper.Guid);
				}
				else
				{
					ArrayList al = new ArrayList();
					SimPe.Plugin.GuidSet gs = new SimPe.Plugin.GuidSet();
					gs.oldguid = initialguid;
					gs.guid = wrapper.Guid;
					al.Add(gs);

					fg.FixGuids(al);
				}
				initialguid = wrapper.Guid;
			}
			this.lbIsOk.Visible = false;
			wrapper.SynchronizeUserData();
		}

		private void CangedTab(object sender, System.EventArgs e)
		{
			InitialTab = tc.SelectedIndex;
			if (tc.SelectedTab == tpraw)
			{
				rbhex.Checked = (Ambertation.BaseChangeableNumber.DigitBase == 16);
				rbbin.Checked = (Ambertation.BaseChangeableNumber.DigitBase == 2);
				rbdec.Checked = (!rbhex.Checked && !rbbin.Checked);

				//if (this.pg.SelectedObject==null)
				ShowData();
			}
			else
			{
				if (this.pg.SelectedObject != null)
					UpdateData();
				this.pg.SelectedObject = null;
			}
		}

		private void PropChanged(
			object s,
			System.Windows.Forms.PropertyValueChangedEventArgs e
		)
		{
			propchanged = true;
		}

		private void SetFlName(object sender, System.EventArgs e)
		{
			if (this.Tag != null)
				return;
			wrapper.FileName = tbflname.Text;
			wrapper.Changed = true;
		}

		private void DigitChanged(object sender, System.EventArgs e)
		{
			if (rbhex.Checked)
				Ambertation.BaseChangeableNumber.DigitBase = 16;
			else if (rbbin.Checked)
				Ambertation.BaseChangeableNumber.DigitBase = 2;
			else
				Ambertation.BaseChangeableNumber.DigitBase = 10;

			this.pg.Refresh();
		}

		private void cbsort_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (Tag != null)
				return;
			this.Tag = true;
			wrapper.FunctionSubSort = (Data.ObjFunctionSubSort)cbsort.SelectedValue;
			wrapper.Changed = true;
			this.SetFunctionCb(wrapper);
			this.Tag = null;
		}

		private void cbBuildSort_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Tag != null)
				return;
			this.Tag = true;

			if (cbBuildSort.SelectedIndex < 0)
				return;
			bool skippy = false;
			if (cbBuildSort.SelectedIndex == 0) // none
			{
				wrapper.BuildSubSort = 0;
				wrapper.Type = SimPe.Data.ObjectTypes.Normal;
			}
			if (cbBuildSort.SelectedIndex == 1)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.General_Columns;
				wrapper.Type = SimPe.Data.ObjectTypes.ArchitecturalSupport;
			}
			if (cbBuildSort.SelectedIndex == 2)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.General_Stairs;
				wrapper.Type = SimPe.Data.ObjectTypes.Stairs;
			}
			if (cbBuildSort.SelectedIndex == 3)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.General_Pool;
				skippy = true;
			}
			if (cbBuildSort.SelectedIndex == 4)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.General_TallColumns;
				wrapper.Type = SimPe.Data.ObjectTypes.ArchitecturalSupport;
			}
			if (cbBuildSort.SelectedIndex == 5)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.General_Arch;
				wrapper.Type = SimPe.Data.ObjectTypes.ArchitecturalSupport;
			}
			if (cbBuildSort.SelectedIndex == 6)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.General_Driveway;
				skippy = true;
			}
			if (cbBuildSort.SelectedIndex == 7)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.General_Elevator;
				skippy = true;
			}
			if (cbBuildSort.SelectedIndex == 8)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.General_Architectural;
				wrapper.Type = SimPe.Data.ObjectTypes.Normal;
			}
			if (cbBuildSort.SelectedIndex == 9)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Garden_Trees;
				wrapper.Type = SimPe.Data.ObjectTypes.Normal;
			}
			if (cbBuildSort.SelectedIndex == 10)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Garden_Shrubs;
				wrapper.Type = SimPe.Data.ObjectTypes.Normal;
			}
			if (cbBuildSort.SelectedIndex == 11)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Garden_Flowers;
				wrapper.Type = SimPe.Data.ObjectTypes.Normal;
			}
			if (cbBuildSort.SelectedIndex == 12)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Garden_Objects;
				wrapper.Type = SimPe.Data.ObjectTypes.Normal;
			}
			if (cbBuildSort.SelectedIndex == 13)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Openings_Door;
				wrapper.Type = SimPe.Data.ObjectTypes.Door;
			}
			if (cbBuildSort.SelectedIndex == 14)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Openings_TallWindow;
				wrapper.Type = SimPe.Data.ObjectTypes.Window;
			}
			if (cbBuildSort.SelectedIndex == 15)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Openings_Window;
				wrapper.Type = SimPe.Data.ObjectTypes.Window;
			}
			if (cbBuildSort.SelectedIndex == 16)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Openings_Gate;
				wrapper.Type = SimPe.Data.ObjectTypes.Door;
			}
			if (cbBuildSort.SelectedIndex == 17)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Openings_Arch;
				wrapper.Type = SimPe.Data.ObjectTypes.Door;
			}
			if (cbBuildSort.SelectedIndex == 18)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Openings_TallDoor;
				wrapper.Type = SimPe.Data.ObjectTypes.Door;
			}
			if (cbBuildSort.SelectedIndex == 19) // Unknown - won't change anything
				skippy = true;

			if (!skippy)
			{
				this.cbtype.SelectedIndex = 0;
				for (int i = 0; i < this.cbtype.Items.Count; i++)
				{
					Data.ObjectTypes ot = (Data.ObjectTypes)this.cbtype.Items[i];
					if (ot == wrapper.Type)
					{
						this.cbtype.SelectedIndex = i;
						break;
					}
				}

				this.tbtype.Text = "0x" + Helper.HexString((ushort)(wrapper.Type));
			}
			else
				this.cbtype.Select();

			this.Tag = null;
			wrapper.Changed = true;
		}

		private void tbPrice_TextChanged(object sender, EventArgs e)
		{
			this.tbPrice.ForeColor = System.Drawing.SystemColors.WindowText;
			if (this.Tag != null)
				return;
			try
			{
				string prise = this.tbPrice.Text;
				if (prise.StartsWith("�"))
					prise = prise.Remove(0, 1);
				wrapper.Price = Convert.ToInt16(prise);
			}
			catch
			{
				this.tbPrice.ForeColor = System.Drawing.Color.OrangeRed;
			}
		}
	}
}
