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
using System.Windows.Forms;

using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for ExtObjdForm.
	/// </summary>
	internal class ExtObjdForm : Form, IPackedFileUI
	{
		#region Form variables
		private Button btnUpdateMMAT;
		private Label label2;
		internal PropertyGrid pg;
		internal TabControl tc;
		internal TabPage tpcatalogsort;
		private TabPage tpraw;
		internal CheckBox cbhobby;
		internal CheckBox cbaspiration;
		internal CheckBox cbcareer;
		internal CheckBox cbkids;
		private Panel panel1;
		private RadioButton rbbin;
		private RadioButton rbdec;
		private RadioButton rbhex;
		private CheckBox cball;
		internal Label lbIsOk;
		private Label label1;
		internal Ambertation.Windows.Forms.EnumComboBox cbsort;
		private Label label63;
		internal TextBox tbproxguid;
		private Label label97;
		internal TextBox tborgguid;
		private LinkLabel llgetGUID;
		private Label label65;
		private Label label9;
		private Label label8;
		private Panel panel6;
		internal TextBox tbflname;
		internal TextBox tbguid;
		internal ComboBox cbtype;
		internal TextBox tbtype;
		internal Panel pnobjd;
		internal CheckBox cbbathroom;
		internal CheckBox cbbedroom;
		internal CheckBox cbdinigroom;
		internal CheckBox cbkitchen;
		internal CheckBox cbstudy;
		internal CheckBox cblivingroom;
		internal CheckBox cboutside;
		internal CheckBox cbmisc;
		internal CheckBox cbgeneral;
		internal CheckBox cbelectronics;
		internal CheckBox cbdecorative;
		internal CheckBox cbappliances;
		internal CheckBox cbsurfaces;
		internal CheckBox cbseating;
		internal CheckBox cbplumbing;
		internal CheckBox cblightning;
		private Ambertation.Windows.Forms.XPTaskBoxSimple groupBox1;
		private Ambertation.Windows.Forms.XPTaskBoxSimple groupBox2;
		internal TextBox tbdiag;
		private Label label3;
		internal TextBox tbgrid;
		private Label label4;
		private Panel pngradient;
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
		private Panel pnpritty;
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

			cbtype.Items.Add(Data.ObjectTypes.Unknown);
			cbtype.Items.Add(Data.ObjectTypes.ArchitecturalSupport);
			cbtype.Items.Add(Data.ObjectTypes.Door);
			cbtype.Items.Add(Data.ObjectTypes.Memory);
			cbtype.Items.Add(Data.ObjectTypes.ModularStairs);
			cbtype.Items.Add(Data.ObjectTypes.ModularStairsPortal);
			cbtype.Items.Add(Data.ObjectTypes.Normal);
			cbtype.Items.Add(Data.ObjectTypes.Outfit);
			cbtype.Items.Add(Data.ObjectTypes.Person);
			cbtype.Items.Add(Data.ObjectTypes.SimType);
			cbtype.Items.Add(Data.ObjectTypes.Stairs);
			cbtype.Items.Add(Data.ObjectTypes.Template);
			cbtype.Items.Add(Data.ObjectTypes.Vehicle);
			cbtype.Items.Add(Data.ObjectTypes.Window);
			cbtype.Items.Add(Data.ObjectTypes.UnlinkedSim);
			cbtype.Items.Add(Data.ObjectTypes.Tiles);

			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(Data.BuildFunctionSubSort.none)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Columns
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Stairs
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Pool
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_TallColumns
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Arch
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Driveway
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Elevator
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.General_Architectural
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Garden_Trees
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Garden_Shrubs
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Garden_Flowers
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Garden_Objects
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Openings_Door
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Openings_TallWindow
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Openings_Window
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Openings_Gate
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Openings_Arch
				)
			);
			cbBuildSort.Items.Add(
				new Data.LocalizedBuildSubSort(
					Data.BuildFunctionSubSort.Openings_TallDoor
				)
			);
			if (Helper.WindowsRegistry.HiddenMode)
			{
				cbBuildSort.Items.Add(
					new Data.LocalizedBuildSubSort(
						Data.BuildFunctionSubSort.unknown
					)
				);
			}

			cbsort.Enum = typeof(Data.ObjFunctionSubSort);
			cbsort.ResourceManager = Localization.Manager;

			if (Helper.ECCorNewSEfound)
			{
				cbExtras.Text = "Extra Stuff";
			}

			if (Helper.WindowsRegistry.UseBigIcons)
			{
				pg.Font = new System.Drawing.Font(
					"Verdana",
					10.25F,
					System.Drawing.FontStyle.Regular
				);
			}

			if (
				!UserVerification.HaveUserId
				|| PathProvider.Global.EPInstalled <= 1
			)
			{
				cbBuildSort.Visible = taskBox1.Visible = false;
				groupBox1.Height = 176;
				groupBox2.Height = 176;
				tbPrice.Location = new System.Drawing.Point(140, 144);
				lbprise.Location = new System.Drawing.Point(94, 148);
				tc.Controls.Remove(tpreqeps);
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
			pg.SelectedObject = null;

			Hashtable ht = new Hashtable();
			for (int i = 0; i < wrapper.Data.Length; i++)
			{
				Ambertation.PropertyDescription pf =
					ExtObjd.PropertyParser.GetDescriptor((ushort)i);
				if (pf == null)
				{
					pf = new Ambertation.PropertyDescription(
						"Unknown",
						null,
						wrapper.Data[i]
					);
				}
				else
				{
					pf.Property = wrapper.Data[i];
				}

				ht[GetName(i)] = pf;
			}

			pob = new Ambertation.PropertyObjectBuilderExt(ht);
			pg.SelectedObject = pob.Instance;
		}

		void UpdateData()
		{
			if (!propchanged)
			{
				return;
			}

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
							if (o is FlagBase)
							{
								wrapper.Data[i] = ((FlagBase)ht[name]);
							}
							else
							{
								wrapper.Data[i] = Convert.ToInt16(ht[name]);
							}
						}
					}
					catch (Exception ex)
					{
						if (Helper.WindowsRegistry.HiddenMode)
						{
							Helper.ExceptionMessage("Error converting " + name, ex);
						}
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
			{
				readPJSEGlobalStringObjDef();
			}

			if (names == null)
			{
				readGLUAObjDef();
			}

			if (names == null || names[i] == null)
			{
				Ambertation.PropertyDescription pf =
					ExtObjd.PropertyParser.GetDescriptor((ushort)i);
				name = pf == null ? null : pf.Description;
			}
			else
			{
				name = names[i];
			}

			return "0x"
				+ Helper.HexString((ushort)i)
				+ ((name != null) ? ": " + name : "")
				+ " ";
		}

		private static void readGLUAObjDef()
		{
			names = null;
			string objDefGLUAFile = System.IO.Path.Combine(
				PathProvider.Global.Latest.InstallFolder,
				"TSData\\Res\\ObjectScripts\\ObjectScripts.package"
			);
			if (!System.IO.File.Exists(objDefGLUAFile))
			{
				return;
			}
			IPackageFile glua = Packages.File.LoadFromFile(objDefGLUAFile);
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
			Wrapper.ObjLua objDef =
				new Wrapper.ObjLua();
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
				{
					names[key] = value;
				}
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
				Helper.SimPePluginPath,
				"pjse.coder.plugin\\GlobalStrings.package"
			);
			if (!System.IO.File.Exists(pjseGlobalStringFile))
			{
				return;
			}
			IPackageFile gs = Packages.File.LoadFromFile(pjseGlobalStringFile);
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
			Str objDef = new Str();
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
			{
				names[i] = lST[i].Title;
			}
		}

		internal void SetFunctionCb(ExtObjd objd)
		{
			cbappliances.Checked = objd.FunctionSort.InAppliances;
			cbdecorative.Checked = objd.FunctionSort.InDecorative;
			cbelectronics.Checked = objd.FunctionSort.InElectronics;
			cbgeneral.Checked = objd.FunctionSort.InGeneral;
			cblightning.Checked = objd.FunctionSort.InLighting;
			cbplumbing.Checked = objd.FunctionSort.InPlumbing;
			cbseating.Checked = objd.FunctionSort.InSeating;
			cbsurfaces.Checked = objd.FunctionSort.InSurfaces;
			cbhobby.Checked = objd.FunctionSort.InHobbies;
			cbaspiration.Checked = objd.FunctionSort.InAspirationRewards;
			cbcareer.Checked = objd.FunctionSort.InCareerRewards;
		}

		internal void SetExpansionsCb(ExtObjd objd)
		{
			cbBase.Checked = objd.EpRequired1.Basegame;
			cbUniversity.Checked = objd.EpRequired1.University;
			cbNightlife.Checked = objd.EpRequired1.Nightlife;
			cbBusiness.Checked = objd.EpRequired1.Business;
			cbFamilyFun.Checked = objd.EpRequired1.FamilyFun;
			cbGlamour.Checked = objd.EpRequired1.GlamourLife;
			cbSeasons.Checked = objd.EpRequired1.Seasons;
			cbCelebrations.Checked = objd.EpRequired1.Celebration;
			cbFashion.Checked = objd.EpRequired1.Fashion;
			cbBonVoyage.Checked = objd.EpRequired1.BonVoyage;
			cbTeenStyle.Checked = objd.EpRequired1.TeenStyle;
			cbExtras.Checked = objd.EpRequired1.StoreEdition_old;
			cbFreeTime.Checked = objd.EpRequired1.Freetime;
			cbKitchens.Checked = objd.EpRequired1.KitchenBath;
			cbIkeaHome.Checked = objd.EpRequired1.IkeaHome;
			cbApartments.Checked = objd.EpRequired2.ApartmentLife;
			cbMansion.Checked = objd.EpRequired2.MansionGarden;
			cbStoreEd.Checked = objd.EpRequired2.StoreEdition;
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

		public Control GUIHandle => pnobjd;

		public void UpdateGUI(IFileWrapper wrapper)
		{
			ExtObjd objd = (ExtObjd)wrapper;
			this.wrapper = objd;
			initialguid = objd.Guid;
			Tag = true;

			try
			{
				if (objd.Ok != ObjdHealth.Ok)
				{
					lbIsOk.Text = "Please commit! (" + objd.Ok.ToString() + ")";
					lbIsOk.Visible = true;
				}
				else
				{
					lbIsOk.Text = "Please commit!";
					lbIsOk.Visible = false;
				}
				pg.SelectedObject = null;
				tc.SelectedIndex = InitialTab;
				cbtype.SelectedIndex = 0;
				for (int i = 0; i < cbtype.Items.Count; i++)
				{
					Data.ObjectTypes ot = (Data.ObjectTypes)cbtype.Items[i];
					if (ot == objd.Type)
					{
						cbtype.SelectedIndex = i;
						break;
					}
				}

				tbtype.Text = "0x" + Helper.HexString((ushort)(objd.Type));
				tbguid.Text = "0x" + Helper.HexString(objd.Guid);
				tbproxguid.Text = "0x" + Helper.HexString(objd.ProxyGuid);
				tborgguid.Text = "0x" + Helper.HexString(objd.OriginalGuid);
				tbdiag.Text = "0x" + Helper.HexString(objd.DiagonalGuid);
				tbgrid.Text = "0x" + Helper.HexString(objd.GridAlignedGuid);
				tbflname.Text = objd.FileName;

				cbbathroom.Checked = (objd.RoomSort.InBathroom);
				cbbedroom.Checked = (objd.RoomSort.InBedroom);
				cbdinigroom.Checked = (objd.RoomSort.InDiningRoom);
				cbkitchen.Checked = (objd.RoomSort.InKitchen);
				cblivingroom.Checked = (objd.RoomSort.InLivingRoom);
				cbmisc.Checked = (objd.RoomSort.InMisc);
				cboutside.Checked = (objd.RoomSort.InOutside);
				cbstudy.Checked = (objd.RoomSort.InStudy);
				cbkids.Checked = (objd.RoomSort.InKids);

				cbcDine.Checked = (objd.CommSort.InDining);
				cbcShop.Checked = (objd.CommSort.InShopping);
				cbcOuts.Checked = (objd.CommSort.InOutdoors);
				cbcStreet.Checked = (objd.CommSort.InStreet);
				cbcMisc.Checked = (objd.CommSort.InMiscel);

				tbPrice.Text = "�" + Convert.ToString(objd.Price);

				tbreqeps.Enabled = (objd.Version > 0x008b);
				SetExpansionsCb(objd);
				SetFunctionCb(objd);
				cbsort.SelectedValue = objd.FunctionSubSort;
				cbBuildSort.SelectedIndex = 0;
				if (objd.BuildType.Value != 0)
				{
					if (Helper.WindowsRegistry.HiddenMode)
					{
						cbBuildSort.SelectedIndex = 19; // set to unknown
					}

					for (int i = 0; i < cbBuildSort.Items.Count; i++)
					{
						object o = cbBuildSort.Items[i];
						Data.BuildFunctionSubSort at;
						if (o.GetType() == typeof(Data.Alias))
						{
							at = (Data.LocalizedBuildSubSort)
								((Data.Alias)o).Id
							;
						}
						else
						{
							at = (Data.LocalizedBuildSubSort)o;
						}

						if (at == objd.BuildSubSort)
						{
							cbBuildSort.SelectedIndex = i;
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

				llgetGUID.Visible = (
					UserVerification.HaveUserId
					&& objd.Type != Data.ObjectTypes.Person
					&& objd.Type != Data.ObjectTypes.UnlinkedSim
				);
				//this.lladdgooee.Visible = (UserVerification.HaveUserId && !SimPe.Plugin.Subhoods.GuidExists(objd.Guid) && objd.Type != SimPe.Data.ObjectTypes.Person && objd.Type != SimPe.Data.ObjectTypes.UnlinkedSim);
			}
			finally
			{
				Tag = null;
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
			components = new Container();
			pnobjd = new Panel();
			lladdgooee = new LinkLabel();
			tbgrid = new TextBox();
			label4 = new Label();
			tbdiag = new TextBox();
			label3 = new Label();
			btnUpdateMMAT = new Button();
			label2 = new Label();
			lbIsOk = new Label();
			cball = new CheckBox();
			tc = new TabControl();
			tpcatalogsort = new TabPage();
			pngradient = new Panel();
			taskBox1 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			cbcMisc = new CheckBox();
			cbcStreet = new CheckBox();
			cbcOuts = new CheckBox();
			cbcShop = new CheckBox();
			cbcDine = new CheckBox();
			groupBox2 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			cbBuildSort = new ComboBox();
			cbaspiration = new CheckBox();
			label5 = new Label();
			cbhobby = new CheckBox();
			cbappliances = new CheckBox();
			cbdecorative = new CheckBox();
			cbelectronics = new CheckBox();
			cbgeneral = new CheckBox();
			cblightning = new CheckBox();
			cbplumbing = new CheckBox();
			cbseating = new CheckBox();
			cbsurfaces = new CheckBox();
			cbcareer = new CheckBox();
			cbsort = new Ambertation.Windows.Forms.EnumComboBox();
			label1 = new Label();
			groupBox1 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			lbprise = new Label();
			tbPrice = new TextBox();
			cbkids = new CheckBox();
			cbbathroom = new CheckBox();
			cbbedroom = new CheckBox();
			cbdinigroom = new CheckBox();
			cbkitchen = new CheckBox();
			cbmisc = new CheckBox();
			cboutside = new CheckBox();
			cblivingroom = new CheckBox();
			cbstudy = new CheckBox();
			tpreqeps = new TabPage();
			pnpritty = new Panel();
			tbreqeps = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			lbepnote = new Label();
			lbgamef2 = new Label();
			cbStoreEd = new CheckBox();
			cbMansion = new CheckBox();
			cbApartments = new CheckBox();
			cbIkeaHome = new CheckBox();
			cbKitchens = new CheckBox();
			cbFreeTime = new CheckBox();
			cbExtras = new CheckBox();
			cbTeenStyle = new CheckBox();
			cbBonVoyage = new CheckBox();
			cbFashion = new CheckBox();
			cbCelebrations = new CheckBox();
			cbSeasons = new CheckBox();
			cbPets = new CheckBox();
			cbGlamour = new CheckBox();
			cbFamilyFun = new CheckBox();
			cbBusiness = new CheckBox();
			cbNightlife = new CheckBox();
			cbUniversity = new CheckBox();
			cbBase = new CheckBox();
			tpraw = new TabPage();
			panel1 = new Panel();
			rbhex = new RadioButton();
			rbdec = new RadioButton();
			rbbin = new RadioButton();
			pg = new PropertyGrid();
			tbtype = new TextBox();
			cbtype = new ComboBox();
			label63 = new Label();
			tbproxguid = new TextBox();
			label97 = new Label();
			tborgguid = new TextBox();
			llgetGUID = new LinkLabel();
			label65 = new Label();
			tbflname = new TextBox();
			label9 = new Label();
			tbguid = new TextBox();
			label8 = new Label();
			panel6 = new Panel();
			toolTip1 = new ToolTip(components);
			pnobjd.SuspendLayout();
			tc.SuspendLayout();
			tpcatalogsort.SuspendLayout();
			pngradient.SuspendLayout();
			taskBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			tpreqeps.SuspendLayout();
			pnpritty.SuspendLayout();
			tbreqeps.SuspendLayout();
			tpraw.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// pnobjd
			//
			pnobjd.AutoScroll = true;
			pnobjd.BackColor = System.Drawing.Color.Transparent;
			pnobjd.Controls.Add(lladdgooee);
			pnobjd.Controls.Add(tbgrid);
			pnobjd.Controls.Add(label4);
			pnobjd.Controls.Add(tbdiag);
			pnobjd.Controls.Add(label3);
			pnobjd.Controls.Add(btnUpdateMMAT);
			pnobjd.Controls.Add(label2);
			pnobjd.Controls.Add(lbIsOk);
			pnobjd.Controls.Add(cball);
			pnobjd.Controls.Add(tc);
			pnobjd.Controls.Add(tbtype);
			pnobjd.Controls.Add(cbtype);
			pnobjd.Controls.Add(label63);
			pnobjd.Controls.Add(tbproxguid);
			pnobjd.Controls.Add(label97);
			pnobjd.Controls.Add(tborgguid);
			pnobjd.Controls.Add(llgetGUID);
			pnobjd.Controls.Add(label65);
			pnobjd.Controls.Add(tbflname);
			pnobjd.Controls.Add(label9);
			pnobjd.Controls.Add(tbguid);
			pnobjd.Controls.Add(label8);
			pnobjd.Controls.Add(panel6);
			pnobjd.Dock = DockStyle.Fill;
			//this.pnobjd.EndColour = System.Drawing.SystemColors.Control;
			pnobjd.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			pnobjd.Location = new System.Drawing.Point(0, 0);
			//this.pnobjd.MiddleColour = System.Drawing.SystemColors.Control;
			pnobjd.Name = "pnobjd";
			pnobjd.Size = new System.Drawing.Size(984, 325);
			//this.pnobjd.StartColour = System.Drawing.SystemColors.Control;
			pnobjd.TabIndex = 6;
			//
			// lladdgooee
			//
			lladdgooee.AutoSize = true;
			lladdgooee.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			lladdgooee.LinkArea = new LinkArea(0, 6);
			lladdgooee.Location = new System.Drawing.Point(125, 170);
			lladdgooee.Name = "lladdgooee";
			lladdgooee.Size = new System.Drawing.Size(153, 18);
			lladdgooee.TabIndex = 37;
			lladdgooee.TabStop = true;
			lladdgooee.Text = "Add To pjse Guid Index";
			lladdgooee.UseCompatibleTextRendering = true;
			lladdgooee.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					lladdgooee_LinkClicked
				);
			//
			// tbgrid
			//
			tbgrid.Location = new System.Drawing.Point(122, 285);
			tbgrid.Name = "tbgrid";
			tbgrid.Size = new System.Drawing.Size(96, 21);
			tbgrid.TabIndex = 36;
			tbgrid.Text = "0xDDDDDDDD";
			tbgrid.TextChanged += new EventHandler(SetGuid);
			//
			// label4
			//
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			label4.ImeMode = ImeMode.NoControl;
			label4.Location = new System.Drawing.Point(8, 288);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(108, 13);
			label4.TabIndex = 35;
			label4.Text = "Grid Align GUID";
			//
			// tbdiag
			//
			tbdiag.Location = new System.Drawing.Point(122, 258);
			tbdiag.Name = "tbdiag";
			tbdiag.Size = new System.Drawing.Size(96, 21);
			tbdiag.TabIndex = 34;
			tbdiag.Text = "0xDDDDDDDD";
			tbdiag.TextChanged += new EventHandler(SetGuid);
			//
			// label3
			//
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			label3.ImeMode = ImeMode.NoControl;
			label3.Location = new System.Drawing.Point(15, 261);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(101, 13);
			label3.TabIndex = 33;
			label3.Text = "Diagonal GUID";
			//
			// btnUpdateMMAT
			//
			btnUpdateMMAT.FlatStyle = FlatStyle.System;
			btnUpdateMMAT.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			btnUpdateMMAT.Location = new System.Drawing.Point(50, 117);
			btnUpdateMMAT.Name = "btnUpdateMMAT";
			btnUpdateMMAT.Size = new System.Drawing.Size(62, 24);
			btnUpdateMMAT.TabIndex = 32;
			btnUpdateMMAT.Text = "Update";
			btnUpdateMMAT.Visible = false;
			btnUpdateMMAT.Click += new EventHandler(
				btnUpdateMMAT_Click
			);
			//
			// label2
			//
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font("Verdana", 8.25F);
			label2.Location = new System.Drawing.Point(114, 124);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(115, 13);
			label2.TabIndex = 31;
			label2.Text = "MMATs and commit";
			label2.Visible = false;
			//
			// lbIsOk
			//
			lbIsOk.BackColor = System.Drawing.Color.Transparent;
			lbIsOk.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbIsOk.Location = new System.Drawing.Point(6, 60);
			lbIsOk.Name = "lbIsOk";
			lbIsOk.Size = new System.Drawing.Size(284, 23);
			lbIsOk.TabIndex = 29;
			lbIsOk.Text = "Please commit!";
			lbIsOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lbIsOk.Visible = false;
			//
			// cball
			//
			cball.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
			cball.FlatStyle = FlatStyle.System;
			cball.Location = new System.Drawing.Point(98, 142);
			cball.Name = "cball";
			cball.Size = new System.Drawing.Size(120, 21);
			cball.TabIndex = 28;
			cball.Text = "update all MMATs";
			cball.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			cball.Visible = false;
			//
			// tc
			//
			tc.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tc.Controls.Add(tpcatalogsort);
			tc.Controls.Add(tpreqeps);
			tc.Controls.Add(tpraw);
			tc.Location = new System.Drawing.Point(296, 56);
			tc.Name = "tc";
			tc.SelectedIndex = 0;
			tc.Size = new System.Drawing.Size(688, 268);
			tc.TabIndex = 26;
			tc.SelectedIndexChanged += new EventHandler(CangedTab);
			//
			// tpcatalogsort
			//
			tpcatalogsort.BackColor = System.Drawing.Color.Transparent;
			tpcatalogsort.BackgroundImageLayout =
				ImageLayout
				.Zoom;
			tpcatalogsort.Controls.Add(pngradient);
			tpcatalogsort.Location = new System.Drawing.Point(4, 22);
			tpcatalogsort.Name = "tpcatalogsort";
			tpcatalogsort.Size = new System.Drawing.Size(680, 242);
			tpcatalogsort.TabIndex = 0;
			tpcatalogsort.Text = "Catalogue Sort";
			//
			// pngradient
			//
			pngradient.BackColor = System.Drawing.Color.Transparent;
			//this.pngradient.BackgroundImageAnchor = System.Windows.Forms.Panel.ImageLayout.TopRight;
			//this.pngradient.BackgroundImageZoomToFit = true;
			pngradient.Controls.Add(taskBox1);
			pngradient.Controls.Add(groupBox2);
			pngradient.Controls.Add(groupBox1);
			pngradient.Dock = DockStyle.Fill;
			//this.pngradient.EndColour = System.Drawing.SystemColors.Control;
			pngradient.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			pngradient.Location = new System.Drawing.Point(0, 0);
			//this.pngradient.MiddleColour = System.Drawing.SystemColors.Control;
			pngradient.Name = "pngradient";
			pngradient.Size = new System.Drawing.Size(680, 242);
			//this.pngradient.StartColour = System.Drawing.SystemColors.Control;
			pngradient.TabIndex = 18;
			//
			// taskBox1
			//
			taskBox1.BackColor = System.Drawing.Color.Transparent;
			taskBox1.BodyColor = System.Drawing.SystemColors.ControlLight;
			taskBox1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			taskBox1.Controls.Add(cbcMisc);
			taskBox1.Controls.Add(cbcStreet);
			taskBox1.Controls.Add(cbcOuts);
			taskBox1.Controls.Add(cbcShop);
			taskBox1.Controls.Add(cbcDine);
			taskBox1.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			taskBox1.HeaderText = "Community Sort";
			taskBox1.HeaderTextColor = System.Drawing.SystemColors.ControlText;
			taskBox1.IconLocation = new System.Drawing.Point(4, 12);
			taskBox1.IconSize = new System.Drawing.Size(32, 32);
			taskBox1.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
			taskBox1.Location = new System.Drawing.Point(516, 8);
			taskBox1.Name = "taskBox1";
			taskBox1.Padding = new Padding(4, 28, 4, 4);
			taskBox1.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
			taskBox1.Size = new System.Drawing.Size(142, 200);
			taskBox1.TabIndex = 18;
			//this.taskBox1.TopGap = 2;
			//
			// cbcMisc
			//
			cbcMisc.AutoSize = true;
			cbcMisc.Location = new System.Drawing.Point(18, 131);
			cbcMisc.Name = "cbcMisc";
			cbcMisc.Size = new System.Drawing.Size(54, 17);
			cbcMisc.TabIndex = 4;
			cbcMisc.Text = "Misc.";
			cbcMisc.UseVisualStyleBackColor = true;
			cbcMisc.CheckedChanged += new EventHandler(SetCommFlags);
			//
			// cbcStreet
			//
			cbcStreet.AutoSize = true;
			cbcStreet.Location = new System.Drawing.Point(18, 106);
			cbcStreet.Name = "cbcStreet";
			cbcStreet.Size = new System.Drawing.Size(61, 17);
			cbcStreet.TabIndex = 3;
			cbcStreet.Text = "Street";
			cbcStreet.UseVisualStyleBackColor = true;
			cbcStreet.CheckedChanged += new EventHandler(SetCommFlags);
			//
			// cbcOuts
			//
			cbcOuts.AutoSize = true;
			cbcOuts.Location = new System.Drawing.Point(18, 81);
			cbcOuts.Name = "cbcOuts";
			cbcOuts.Size = new System.Drawing.Size(78, 17);
			cbcOuts.TabIndex = 2;
			cbcOuts.Text = "Outdoors";
			cbcOuts.UseVisualStyleBackColor = true;
			cbcOuts.CheckedChanged += new EventHandler(SetCommFlags);
			//
			// cbcShop
			//
			cbcShop.AutoSize = true;
			cbcShop.Location = new System.Drawing.Point(18, 56);
			cbcShop.Name = "cbcShop";
			cbcShop.Size = new System.Drawing.Size(79, 17);
			cbcShop.TabIndex = 1;
			cbcShop.Text = "Shopping";
			cbcShop.UseVisualStyleBackColor = true;
			cbcShop.CheckedChanged += new EventHandler(SetCommFlags);
			//
			// cbcDine
			//
			cbcDine.AutoSize = true;
			cbcDine.Location = new System.Drawing.Point(18, 31);
			cbcDine.Name = "cbcDine";
			cbcDine.Size = new System.Drawing.Size(62, 17);
			cbcDine.TabIndex = 0;
			cbcDine.Text = "Dining";
			cbcDine.UseVisualStyleBackColor = true;
			cbcDine.CheckedChanged += new EventHandler(SetCommFlags);
			//
			// groupBox2
			//
			groupBox2.BackColor = System.Drawing.Color.Transparent;
			groupBox2.BodyColor = System.Drawing.SystemColors.ControlLight;
			groupBox2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			groupBox2.Controls.Add(cbBuildSort);
			groupBox2.Controls.Add(cbaspiration);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(cbhobby);
			groupBox2.Controls.Add(cbappliances);
			groupBox2.Controls.Add(cbdecorative);
			groupBox2.Controls.Add(cbelectronics);
			groupBox2.Controls.Add(cbgeneral);
			groupBox2.Controls.Add(cblightning);
			groupBox2.Controls.Add(cbplumbing);
			groupBox2.Controls.Add(cbseating);
			groupBox2.Controls.Add(cbsurfaces);
			groupBox2.Controls.Add(cbcareer);
			groupBox2.Controls.Add(cbsort);
			groupBox2.Controls.Add(label1);
			groupBox2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox2.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			groupBox2.HeaderText = "Function Sort";
			groupBox2.HeaderTextColor = System.Drawing.SystemColors.ControlText;
			groupBox2.IconLocation = new System.Drawing.Point(4, 12);
			groupBox2.IconSize = new System.Drawing.Size(32, 32);
			groupBox2.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
			groupBox2.Location = new System.Drawing.Point(225, 8);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(4, 28, 4, 4);
			groupBox2.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
			groupBox2.Size = new System.Drawing.Size(285, 200);
			groupBox2.TabIndex = 17;
			//this.groupBox2.TopGap = 2;
			//
			// cbBuildSort
			//
			cbBuildSort.Font = new System.Drawing.Font("Verdana", 8.25F);
			cbBuildSort.FormattingEnabled = true;
			cbBuildSort.Location = new System.Drawing.Point(118, 169);
			cbBuildSort.Name = "cbBuildSort";
			cbBuildSort.Size = new System.Drawing.Size(160, 21);
			cbBuildSort.TabIndex = 20;
			cbBuildSort.SelectedIndexChanged += new EventHandler(
				cbBuildSort_SelectedIndexChanged
			);
			//
			// cbaspiration
			//
			cbaspiration.AutoSize = true;
			cbaspiration.FlatStyle = FlatStyle.System;
			cbaspiration.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbaspiration.Location = new System.Drawing.Point(140, 104);
			cbaspiration.Name = "cbaspiration";
			cbaspiration.Size = new System.Drawing.Size(89, 18);
			cbaspiration.TabIndex = 17;
			cbaspiration.Text = "Aspiration";
			cbaspiration.CheckedChanged += new EventHandler(
				SetFunctionFlags
			);
			//
			// label5
			//
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			label5.Location = new System.Drawing.Point(6, 173);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(112, 13);
			label5.TabIndex = 19;
			label5.Text = "Build Mode Sort:";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// cbhobby
			//
			cbhobby.AutoSize = true;
			cbhobby.FlatStyle = FlatStyle.System;
			cbhobby.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbhobby.Location = new System.Drawing.Point(140, 84);
			cbhobby.Name = "cbhobby";
			cbhobby.Size = new System.Drawing.Size(77, 18);
			cbhobby.TabIndex = 16;
			cbhobby.Text = "Hobbies";
			cbhobby.CheckedChanged += new EventHandler(
				SetFunctionFlags
			);
			//
			// cbappliances
			//
			cbappliances.AutoSize = true;
			cbappliances.FlatStyle = FlatStyle.System;
			cbappliances.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbappliances.Location = new System.Drawing.Point(18, 24);
			cbappliances.Name = "cbappliances";
			cbappliances.Size = new System.Drawing.Size(93, 18);
			cbappliances.TabIndex = 8;
			cbappliances.Text = "Appliances";
			cbappliances.CheckedChanged += new EventHandler(
				SetFunctionFlags
			);
			//
			// cbdecorative
			//
			cbdecorative.AutoSize = true;
			cbdecorative.FlatStyle = FlatStyle.System;
			cbdecorative.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbdecorative.Location = new System.Drawing.Point(18, 44);
			cbdecorative.Name = "cbdecorative";
			cbdecorative.Size = new System.Drawing.Size(94, 18);
			cbdecorative.TabIndex = 9;
			cbdecorative.Text = "Decorative";
			cbdecorative.CheckedChanged += new EventHandler(
				SetFunctionFlags
			);
			//
			// cbelectronics
			//
			cbelectronics.AutoSize = true;
			cbelectronics.FlatStyle = FlatStyle.System;
			cbelectronics.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbelectronics.Location = new System.Drawing.Point(18, 64);
			cbelectronics.Name = "cbelectronics";
			cbelectronics.Size = new System.Drawing.Size(93, 18);
			cbelectronics.TabIndex = 10;
			cbelectronics.Text = "Electronics";
			cbelectronics.CheckedChanged += new EventHandler(
				SetFunctionFlags
			);
			//
			// cbgeneral
			//
			cbgeneral.AutoSize = true;
			cbgeneral.FlatStyle = FlatStyle.System;
			cbgeneral.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbgeneral.Location = new System.Drawing.Point(18, 84);
			cbgeneral.Name = "cbgeneral";
			cbgeneral.Size = new System.Drawing.Size(77, 18);
			cbgeneral.TabIndex = 11;
			cbgeneral.Text = "General";
			cbgeneral.CheckedChanged += new EventHandler(
				SetFunctionFlags
			);
			//
			// cblightning
			//
			cblightning.AutoSize = true;
			cblightning.FlatStyle = FlatStyle.System;
			cblightning.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cblightning.Location = new System.Drawing.Point(18, 104);
			cblightning.Name = "cblightning";
			cblightning.Size = new System.Drawing.Size(65, 18);
			cblightning.TabIndex = 12;
			cblightning.Text = "Lights";
			cblightning.CheckedChanged += new EventHandler(
				SetFunctionFlags
			);
			//
			// cbplumbing
			//
			cbplumbing.AutoSize = true;
			cbplumbing.FlatStyle = FlatStyle.System;
			cbplumbing.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbplumbing.Location = new System.Drawing.Point(140, 24);
			cbplumbing.Name = "cbplumbing";
			cbplumbing.Size = new System.Drawing.Size(84, 18);
			cbplumbing.TabIndex = 13;
			cbplumbing.Text = "Plumbing";
			cbplumbing.CheckedChanged += new EventHandler(
				SetFunctionFlags
			);
			//
			// cbseating
			//
			cbseating.AutoSize = true;
			cbseating.FlatStyle = FlatStyle.System;
			cbseating.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbseating.Location = new System.Drawing.Point(140, 44);
			cbseating.Name = "cbseating";
			cbseating.Size = new System.Drawing.Size(75, 18);
			cbseating.TabIndex = 14;
			cbseating.Text = "Seating";
			cbseating.CheckedChanged += new EventHandler(
				SetFunctionFlags
			);
			//
			// cbsurfaces
			//
			cbsurfaces.AutoSize = true;
			cbsurfaces.FlatStyle = FlatStyle.System;
			cbsurfaces.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbsurfaces.Location = new System.Drawing.Point(140, 64);
			cbsurfaces.Name = "cbsurfaces";
			cbsurfaces.Size = new System.Drawing.Size(82, 18);
			cbsurfaces.TabIndex = 15;
			cbsurfaces.Text = "Surfaces";
			cbsurfaces.CheckedChanged += new EventHandler(
				SetFunctionFlags
			);
			//
			// cbcareer
			//
			cbcareer.AutoSize = true;
			cbcareer.Font = new System.Drawing.Font("Verdana", 8.25F);
			cbcareer.Location = new System.Drawing.Point(18, 124);
			cbcareer.Name = "cbcareer";
			cbcareer.Size = new System.Drawing.Size(113, 17);
			cbcareer.TabIndex = 0;
			cbcareer.Text = "Career Reward";
			cbcareer.CheckedChanged += new EventHandler(
				SetFunctionFlags
			);
			//
			// cbsort
			//
			cbsort.Enum = null;
			cbsort.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbsort.Location = new System.Drawing.Point(118, 144);
			cbsort.Name = "cbsort";
			cbsort.ResourceManager = null;
			cbsort.Size = new System.Drawing.Size(160, 21);
			cbsort.TabIndex = 19;
			cbsort.SelectedIndexChanged += new EventHandler(
				cbsort_SelectedIndexChanged
			);
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(29, 148);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(89, 13);
			label1.TabIndex = 18;
			label1.Text = "Overall Sort:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// groupBox1
			//
			groupBox1.BackColor = System.Drawing.Color.Transparent;
			groupBox1.BodyColor = System.Drawing.SystemColors.ControlLight;
			groupBox1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			groupBox1.Controls.Add(lbprise);
			groupBox1.Controls.Add(tbPrice);
			groupBox1.Controls.Add(cbkids);
			groupBox1.Controls.Add(cbbathroom);
			groupBox1.Controls.Add(cbbedroom);
			groupBox1.Controls.Add(cbdinigroom);
			groupBox1.Controls.Add(cbkitchen);
			groupBox1.Controls.Add(cbmisc);
			groupBox1.Controls.Add(cboutside);
			groupBox1.Controls.Add(cblivingroom);
			groupBox1.Controls.Add(cbstudy);
			groupBox1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox1.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			groupBox1.HeaderText = "Room Sort";
			groupBox1.HeaderTextColor = System.Drawing.SystemColors.ControlText;
			groupBox1.IconLocation = new System.Drawing.Point(4, 12);
			groupBox1.IconSize = new System.Drawing.Size(32, 32);
			groupBox1.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
			groupBox1.Location = new System.Drawing.Point(8, 8);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(4, 28, 4, 4);
			groupBox1.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
			groupBox1.Size = new System.Drawing.Size(211, 200);
			groupBox1.TabIndex = 16;
			//this.groupBox1.TopGap = 2;
			//
			// lbprise
			//
			lbprise.AutoSize = true;
			lbprise.BackColor = System.Drawing.Color.Transparent;
			lbprise.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			lbprise.ImeMode = ImeMode.NoControl;
			lbprise.Location = new System.Drawing.Point(94, 173);
			lbprise.Name = "lbprise";
			lbprise.Size = new System.Drawing.Size(44, 13);
			lbprise.TabIndex = 24;
			lbprise.Text = "Price:";
			//
			// tbPrice
			//
			tbPrice.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbPrice.Location = new System.Drawing.Point(140, 169);
			tbPrice.Name = "tbPrice";
			tbPrice.Size = new System.Drawing.Size(64, 21);
			tbPrice.TabIndex = 23;
			tbPrice.Text = "0";
			tbPrice.TextChanged += new EventHandler(
				tbPrice_TextChanged
			);
			//
			// cbkids
			//
			cbkids.AutoSize = true;
			cbkids.FlatStyle = FlatStyle.System;
			cbkids.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbkids.Location = new System.Drawing.Point(122, 105);
			cbkids.Name = "cbkids";
			cbkids.Size = new System.Drawing.Size(56, 18);
			cbkids.TabIndex = 8;
			cbkids.Text = "Kids";
			cbkids.CheckedChanged += new EventHandler(SetRoomFlags);
			//
			// cbbathroom
			//
			cbbathroom.AutoSize = true;
			cbbathroom.FlatStyle = FlatStyle.System;
			cbbathroom.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbbathroom.Location = new System.Drawing.Point(17, 30);
			cbbathroom.Name = "cbbathroom";
			cbbathroom.Size = new System.Drawing.Size(88, 18);
			cbbathroom.TabIndex = 0;
			cbbathroom.Text = "Bathroom";
			cbbathroom.CheckedChanged += new EventHandler(
				SetRoomFlags
			);
			//
			// cbbedroom
			//
			cbbedroom.AutoSize = true;
			cbbedroom.FlatStyle = FlatStyle.System;
			cbbedroom.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbbedroom.Location = new System.Drawing.Point(17, 55);
			cbbedroom.Name = "cbbedroom";
			cbbedroom.Size = new System.Drawing.Size(84, 18);
			cbbedroom.TabIndex = 1;
			cbbedroom.Text = "Bedroom";
			cbbedroom.CheckedChanged += new EventHandler(SetRoomFlags);
			//
			// cbdinigroom
			//
			cbdinigroom.AutoSize = true;
			cbdinigroom.FlatStyle = FlatStyle.System;
			cbdinigroom.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbdinigroom.Location = new System.Drawing.Point(17, 80);
			cbdinigroom.Name = "cbdinigroom";
			cbdinigroom.Size = new System.Drawing.Size(98, 18);
			cbdinigroom.TabIndex = 2;
			cbdinigroom.Text = "Diningroom";
			cbdinigroom.CheckedChanged += new EventHandler(
				SetRoomFlags
			);
			//
			// cbkitchen
			//
			cbkitchen.AutoSize = true;
			cbkitchen.FlatStyle = FlatStyle.System;
			cbkitchen.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbkitchen.Location = new System.Drawing.Point(17, 105);
			cbkitchen.Name = "cbkitchen";
			cbkitchen.Size = new System.Drawing.Size(74, 18);
			cbkitchen.TabIndex = 3;
			cbkitchen.Text = "Kitchen";
			cbkitchen.CheckedChanged += new EventHandler(SetRoomFlags);
			//
			// cbmisc
			//
			cbmisc.AutoSize = true;
			cbmisc.FlatStyle = FlatStyle.System;
			cbmisc.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbmisc.Location = new System.Drawing.Point(122, 30);
			cbmisc.Name = "cbmisc";
			cbmisc.Size = new System.Drawing.Size(60, 18);
			cbmisc.TabIndex = 4;
			cbmisc.Text = "Misc.";
			cbmisc.CheckedChanged += new EventHandler(SetRoomFlags);
			//
			// cboutside
			//
			cboutside.AutoSize = true;
			cboutside.FlatStyle = FlatStyle.System;
			cboutside.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cboutside.Location = new System.Drawing.Point(122, 55);
			cboutside.Name = "cboutside";
			cboutside.Size = new System.Drawing.Size(75, 18);
			cboutside.TabIndex = 5;
			cboutside.Text = "Outside";
			cboutside.CheckedChanged += new EventHandler(SetRoomFlags);
			//
			// cblivingroom
			//
			cblivingroom.AutoSize = true;
			cblivingroom.FlatStyle = FlatStyle.System;
			cblivingroom.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cblivingroom.Location = new System.Drawing.Point(17, 130);
			cblivingroom.Name = "cblivingroom";
			cblivingroom.Size = new System.Drawing.Size(95, 18);
			cblivingroom.TabIndex = 6;
			cblivingroom.Text = "Livingroom";
			cblivingroom.CheckedChanged += new EventHandler(
				SetRoomFlags
			);
			//
			// cbstudy
			//
			cbstudy.AutoSize = true;
			cbstudy.FlatStyle = FlatStyle.System;
			cbstudy.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbstudy.Location = new System.Drawing.Point(122, 80);
			cbstudy.Name = "cbstudy";
			cbstudy.Size = new System.Drawing.Size(65, 18);
			cbstudy.TabIndex = 7;
			cbstudy.Text = "Study";
			cbstudy.CheckedChanged += new EventHandler(SetRoomFlags);
			//
			// tpreqeps
			//
			tpreqeps.Controls.Add(pnpritty);
			tpreqeps.Location = new System.Drawing.Point(4, 22);
			tpreqeps.Name = "tpreqeps";
			tpreqeps.Size = new System.Drawing.Size(680, 242);
			tpreqeps.TabIndex = 2;
			tpreqeps.Text = "Required Ep";
			tpreqeps.UseVisualStyleBackColor = true;
			//
			// pnpritty
			//
			pnpritty.BackColor = System.Drawing.Color.Transparent;
			//this.pnpritty.BackgroundImageAnchor = System.Windows.Forms.Panel.ImageLayout.TopRight;
			//this.pnpritty.BackgroundImageZoomToFit = true;
			pnpritty.Controls.Add(tbreqeps);
			pnpritty.Dock = DockStyle.Fill;
			//this.pnpritty.EndColour = System.Drawing.SystemColors.Control;
			pnpritty.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			pnpritty.Location = new System.Drawing.Point(0, 0);
			//this.pnpritty.MiddleColour = System.Drawing.SystemColors.Control;
			pnpritty.Name = "pnpritty";
			pnpritty.Size = new System.Drawing.Size(680, 242);
			//this.pnpritty.StartColour = System.Drawing.SystemColors.Control;
			pnpritty.TabIndex = 0;
			//
			// tbreqeps
			//
			tbreqeps.BackColor = System.Drawing.Color.Transparent;
			tbreqeps.BodyColor = System.Drawing.SystemColors.ControlLight;
			tbreqeps.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			tbreqeps.Controls.Add(lbepnote);
			tbreqeps.Controls.Add(lbgamef2);
			tbreqeps.Controls.Add(cbStoreEd);
			tbreqeps.Controls.Add(cbMansion);
			tbreqeps.Controls.Add(cbApartments);
			tbreqeps.Controls.Add(cbIkeaHome);
			tbreqeps.Controls.Add(cbKitchens);
			tbreqeps.Controls.Add(cbFreeTime);
			tbreqeps.Controls.Add(cbExtras);
			tbreqeps.Controls.Add(cbTeenStyle);
			tbreqeps.Controls.Add(cbBonVoyage);
			tbreqeps.Controls.Add(cbFashion);
			tbreqeps.Controls.Add(cbCelebrations);
			tbreqeps.Controls.Add(cbSeasons);
			tbreqeps.Controls.Add(cbPets);
			tbreqeps.Controls.Add(cbGlamour);
			tbreqeps.Controls.Add(cbFamilyFun);
			tbreqeps.Controls.Add(cbBusiness);
			tbreqeps.Controls.Add(cbNightlife);
			tbreqeps.Controls.Add(cbUniversity);
			tbreqeps.Controls.Add(cbBase);
			tbreqeps.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			tbreqeps.HeaderText = "Required Ep or Sp";
			tbreqeps.HeaderTextColor = System.Drawing.SystemColors.ControlText;
			tbreqeps.IconLocation = new System.Drawing.Point(4, 12);
			tbreqeps.IconSize = new System.Drawing.Size(32, 32);
			tbreqeps.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
			tbreqeps.Location = new System.Drawing.Point(8, 8);
			tbreqeps.Name = "tbreqeps";
			tbreqeps.Padding = new Padding(4, 28, 4, 4);
			tbreqeps.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
			tbreqeps.Size = new System.Drawing.Size(442, 228);
			tbreqeps.TabIndex = 0;
			//this.tbreqeps.TopGap = 2;
			//
			// lbepnote
			//
			lbepnote.AutoSize = true;
			lbepnote.Location = new System.Drawing.Point(3, 30);
			lbepnote.Name = "lbepnote";
			lbepnote.Size = new System.Drawing.Size(435, 13);
			lbepnote.TabIndex = 40;
			lbepnote.Text =
				"These Flags are \'OR\' If you set two EPs then either EP is required, not both";
			//
			// lbgamef2
			//
			lbgamef2.AutoSize = true;
			lbgamef2.Location = new System.Drawing.Point(289, 133);
			lbgamef2.Name = "lbgamef2";
			lbgamef2.Size = new System.Drawing.Size(127, 13);
			lbgamef2.TabIndex = 39;
			lbgamef2.Text = "Game Edition Flags 2";
			//
			// cbStoreEd
			//
			cbStoreEd.AutoSize = true;
			cbStoreEd.Location = new System.Drawing.Point(289, 200);
			cbStoreEd.Name = "cbStoreEd";
			cbStoreEd.Size = new System.Drawing.Size(136, 17);
			cbStoreEd.TabIndex = 38;
			cbStoreEd.Text = "Store Edition (new)";
			cbStoreEd.UseVisualStyleBackColor = true;
			cbStoreEd.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbMansion
			//
			cbMansion.AutoSize = true;
			cbMansion.Location = new System.Drawing.Point(289, 177);
			cbMansion.Name = "cbMansion";
			cbMansion.Size = new System.Drawing.Size(131, 17);
			cbMansion.TabIndex = 37;
			cbMansion.Text = "Mansion + Garden";
			cbMansion.UseVisualStyleBackColor = true;
			cbMansion.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbApartments
			//
			cbApartments.AutoSize = true;
			cbApartments.Location = new System.Drawing.Point(289, 154);
			cbApartments.Name = "cbApartments";
			cbApartments.Size = new System.Drawing.Size(110, 17);
			cbApartments.TabIndex = 36;
			cbApartments.Text = "Apartment Life";
			cbApartments.UseVisualStyleBackColor = true;
			cbApartments.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbIkeaHome
			//
			cbIkeaHome.AutoSize = true;
			cbIkeaHome.Location = new System.Drawing.Point(289, 85);
			cbIkeaHome.Name = "cbIkeaHome";
			cbIkeaHome.Size = new System.Drawing.Size(91, 17);
			cbIkeaHome.TabIndex = 35;
			cbIkeaHome.Text = "IKEA Home";
			cbIkeaHome.UseVisualStyleBackColor = true;
			cbIkeaHome.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbKitchens
			//
			cbKitchens.AutoSize = true;
			cbKitchens.Location = new System.Drawing.Point(289, 62);
			cbKitchens.Name = "cbKitchens";
			cbKitchens.Size = new System.Drawing.Size(141, 17);
			cbKitchens.TabIndex = 34;
			cbKitchens.Text = "Kitchen + Bathroom";
			cbKitchens.UseVisualStyleBackColor = true;
			cbKitchens.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbFreeTime
			//
			cbFreeTime.AutoSize = true;
			cbFreeTime.Location = new System.Drawing.Point(152, 200);
			cbFreeTime.Name = "cbFreeTime";
			cbFreeTime.Size = new System.Drawing.Size(83, 17);
			cbFreeTime.TabIndex = 33;
			cbFreeTime.Text = "Free Time";
			cbFreeTime.UseVisualStyleBackColor = true;
			cbFreeTime.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbExtras
			//
			cbExtras.AutoSize = true;
			cbExtras.Location = new System.Drawing.Point(152, 177);
			cbExtras.Name = "cbExtras";
			cbExtras.Size = new System.Drawing.Size(130, 17);
			cbExtras.TabIndex = 32;
			cbExtras.Text = "Store Edition (old)";
			cbExtras.UseVisualStyleBackColor = true;
			cbExtras.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbTeenStyle
			//
			cbTeenStyle.AutoSize = true;
			cbTeenStyle.Location = new System.Drawing.Point(152, 154);
			cbTeenStyle.Name = "cbTeenStyle";
			cbTeenStyle.Size = new System.Drawing.Size(86, 17);
			cbTeenStyle.TabIndex = 31;
			cbTeenStyle.Text = "Teen Style";
			cbTeenStyle.UseVisualStyleBackColor = true;
			cbTeenStyle.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbBonVoyage
			//
			cbBonVoyage.AutoSize = true;
			cbBonVoyage.Location = new System.Drawing.Point(152, 131);
			cbBonVoyage.Name = "cbBonVoyage";
			cbBonVoyage.Size = new System.Drawing.Size(94, 17);
			cbBonVoyage.TabIndex = 30;
			cbBonVoyage.Text = "Bon Voyage";
			cbBonVoyage.UseVisualStyleBackColor = true;
			cbBonVoyage.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbFashion
			//
			cbFashion.AutoSize = true;
			cbFashion.Location = new System.Drawing.Point(152, 108);
			cbFashion.Name = "cbFashion";
			cbFashion.Size = new System.Drawing.Size(131, 17);
			cbFashion.TabIndex = 29;
			cbFashion.Text = "HM� Fashion Stuff";
			cbFashion.UseVisualStyleBackColor = true;
			cbFashion.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbCelebrations
			//
			cbCelebrations.AutoSize = true;
			cbCelebrations.Location = new System.Drawing.Point(152, 85);
			cbCelebrations.Name = "cbCelebrations";
			cbCelebrations.Size = new System.Drawing.Size(96, 17);
			cbCelebrations.TabIndex = 28;
			cbCelebrations.Text = "Celebration!";
			cbCelebrations.UseVisualStyleBackColor = true;
			cbCelebrations.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbSeasons
			//
			cbSeasons.AutoSize = true;
			cbSeasons.Location = new System.Drawing.Point(152, 62);
			cbSeasons.Name = "cbSeasons";
			cbSeasons.Size = new System.Drawing.Size(74, 17);
			cbSeasons.TabIndex = 27;
			cbSeasons.Text = "Seasons";
			cbSeasons.UseVisualStyleBackColor = true;
			cbSeasons.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbPets
			//
			cbPets.AutoSize = true;
			cbPets.Location = new System.Drawing.Point(10, 200);
			cbPets.Name = "cbPets";
			cbPets.Size = new System.Drawing.Size(50, 17);
			cbPets.TabIndex = 26;
			cbPets.Text = "Pets";
			cbPets.UseVisualStyleBackColor = true;
			cbPets.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbGlamour
			//
			cbGlamour.AutoSize = true;
			cbGlamour.Location = new System.Drawing.Point(10, 177);
			cbGlamour.Name = "cbGlamour";
			cbGlamour.Size = new System.Drawing.Size(99, 17);
			cbGlamour.TabIndex = 25;
			cbGlamour.Text = "Glamour Life";
			cbGlamour.UseVisualStyleBackColor = true;
			cbGlamour.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbFamilyFun
			//
			cbFamilyFun.AutoSize = true;
			cbFamilyFun.Location = new System.Drawing.Point(10, 154);
			cbFamilyFun.Name = "cbFamilyFun";
			cbFamilyFun.Size = new System.Drawing.Size(86, 17);
			cbFamilyFun.TabIndex = 24;
			cbFamilyFun.Text = "Family Fun";
			cbFamilyFun.UseVisualStyleBackColor = true;
			cbFamilyFun.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbBusiness
			//
			cbBusiness.AutoSize = true;
			cbBusiness.Location = new System.Drawing.Point(10, 131);
			cbBusiness.Name = "cbBusiness";
			cbBusiness.Size = new System.Drawing.Size(130, 17);
			cbBusiness.TabIndex = 23;
			cbBusiness.Text = "Open for Business";
			cbBusiness.UseVisualStyleBackColor = true;
			cbBusiness.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbNightlife
			//
			cbNightlife.AutoSize = true;
			cbNightlife.Location = new System.Drawing.Point(10, 108);
			cbNightlife.Name = "cbNightlife";
			cbNightlife.Size = new System.Drawing.Size(72, 17);
			cbNightlife.TabIndex = 22;
			cbNightlife.Text = "Nightlife";
			cbNightlife.UseVisualStyleBackColor = true;
			cbNightlife.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbUniversity
			//
			cbUniversity.AutoSize = true;
			cbUniversity.Location = new System.Drawing.Point(10, 85);
			cbUniversity.Name = "cbUniversity";
			cbUniversity.Size = new System.Drawing.Size(83, 17);
			cbUniversity.TabIndex = 21;
			cbUniversity.Text = "University";
			cbUniversity.UseVisualStyleBackColor = true;
			cbUniversity.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// cbBase
			//
			cbBase.AutoSize = true;
			cbBase.Location = new System.Drawing.Point(10, 62);
			cbBase.Name = "cbBase";
			cbBase.Size = new System.Drawing.Size(92, 17);
			cbBase.TabIndex = 20;
			cbBase.Text = "Base Game";
			cbBase.UseVisualStyleBackColor = true;
			cbBase.CheckedChanged += new EventHandler(
				SetExpansionFlags
			);
			//
			// tpraw
			//
			tpraw.Controls.Add(panel1);
			tpraw.Controls.Add(pg);
			tpraw.Location = new System.Drawing.Point(4, 22);
			tpraw.Name = "tpraw";
			tpraw.Size = new System.Drawing.Size(680, 242);
			tpraw.TabIndex = 1;
			tpraw.Text = "RAW Data";
			//
			// panel1
			//
			panel1.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			panel1.Controls.Add(rbhex);
			panel1.Controls.Add(rbdec);
			panel1.Controls.Add(rbbin);
			panel1.Location = new System.Drawing.Point(420, 6);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(256, 16);
			panel1.TabIndex = 4;
			//
			// rbhex
			//
			rbhex.BackColor = System.Drawing.Color.Transparent;
			rbhex.Location = new System.Drawing.Point(152, 0);
			rbhex.Name = "rbhex";
			rbhex.Size = new System.Drawing.Size(104, 16);
			rbhex.TabIndex = 6;
			rbhex.Text = "Hexadecimal";
			rbhex.UseVisualStyleBackColor = false;
			rbhex.CheckedChanged += new EventHandler(DigitChanged);
			//
			// rbdec
			//
			rbdec.BackColor = System.Drawing.Color.Transparent;
			rbdec.Location = new System.Drawing.Point(72, 0);
			rbdec.Name = "rbdec";
			rbdec.Size = new System.Drawing.Size(72, 16);
			rbdec.TabIndex = 5;
			rbdec.Text = "Decimal";
			rbdec.UseVisualStyleBackColor = false;
			rbdec.CheckedChanged += new EventHandler(DigitChanged);
			//
			// rbbin
			//
			rbbin.BackColor = System.Drawing.Color.Transparent;
			rbbin.Location = new System.Drawing.Point(0, 0);
			rbbin.Name = "rbbin";
			rbbin.Size = new System.Drawing.Size(64, 16);
			rbbin.TabIndex = 4;
			rbbin.Text = "Binary";
			rbbin.UseVisualStyleBackColor = false;
			rbbin.CheckedChanged += new EventHandler(DigitChanged);
			//
			// pg
			//
			pg.Dock = DockStyle.Fill;
			pg.HelpVisible = false;
			pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			pg.Location = new System.Drawing.Point(0, 0);
			pg.Name = "pg";
			pg.Size = new System.Drawing.Size(680, 242);
			pg.TabIndex = 0;
			pg.PropertyValueChanged +=
				new PropertyValueChangedEventHandler(
					PropChanged
				);
			//
			// tbtype
			//
			tbtype.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tbtype.Location = new System.Drawing.Point(920, 32);
			tbtype.Name = "tbtype";
			tbtype.ReadOnly = true;
			tbtype.Size = new System.Drawing.Size(56, 21);
			tbtype.TabIndex = 25;
			tbtype.Text = "0xDDDD";
			//
			// cbtype
			//
			cbtype.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			cbtype.DropDownStyle = ComboBoxStyle.DropDownList;
			cbtype.Location = new System.Drawing.Point(752, 32);
			cbtype.Name = "cbtype";
			cbtype.Size = new System.Drawing.Size(168, 21);
			cbtype.TabIndex = 24;
			cbtype.SelectedIndexChanged += new EventHandler(
				ChangeType
			);
			//
			// label63
			//
			label63.AutoSize = true;
			label63.BackColor = System.Drawing.Color.Transparent;
			label63.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			label63.ImeMode = ImeMode.NoControl;
			label63.Location = new System.Drawing.Point(41, 207);
			label63.Name = "label63";
			label63.Size = new System.Drawing.Size(75, 13);
			label63.TabIndex = 22;
			label63.Text = "Orig. GUID";
			//
			// tbproxguid
			//
			tbproxguid.Location = new System.Drawing.Point(122, 231);
			tbproxguid.Name = "tbproxguid";
			tbproxguid.Size = new System.Drawing.Size(96, 21);
			tbproxguid.TabIndex = 21;
			tbproxguid.Text = "0xDDDDDDDD";
			tbproxguid.TextChanged += new EventHandler(SetGuid);
			//
			// label97
			//
			label97.AutoSize = true;
			label97.BackColor = System.Drawing.Color.Transparent;
			label97.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			label97.ImeMode = ImeMode.NoControl;
			label97.Location = new System.Drawing.Point(17, 234);
			label97.Name = "label97";
			label97.Size = new System.Drawing.Size(99, 13);
			label97.TabIndex = 20;
			label97.Text = "Fallback GUID";
			//
			// tborgguid
			//
			tborgguid.Location = new System.Drawing.Point(122, 204);
			tborgguid.Name = "tborgguid";
			tborgguid.Size = new System.Drawing.Size(96, 21);
			tborgguid.TabIndex = 19;
			tborgguid.Text = "0xDDDDDDDD";
			tborgguid.TextChanged += new EventHandler(SetGuid);
			//
			// llgetGUID
			//
			llgetGUID.AutoSize = true;
			llgetGUID.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			llgetGUID.ImeMode = ImeMode.NoControl;
			llgetGUID.LinkArea = new LinkArea(0, 9);
			llgetGUID.Location = new System.Drawing.Point(213, 99);
			llgetGUID.Name = "llgetGUID";
			llgetGUID.Size = new System.Drawing.Size(80, 13);
			llgetGUID.TabIndex = 16;
			llgetGUID.TabStop = true;
			llgetGUID.Text = "make GUID";
			llgetGUID.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(GetGuid);
			//
			// label65
			//
			label65.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label65.AutoSize = true;
			label65.BackColor = System.Drawing.Color.Transparent;
			label65.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			label65.ImeMode = ImeMode.NoControl;
			label65.Location = new System.Drawing.Point(661, 35);
			label65.Name = "label65";
			label65.Size = new System.Drawing.Size(85, 13);
			label65.TabIndex = 12;
			label65.Text = "Object Type";
			//
			// tbflname
			//
			tbflname.Location = new System.Drawing.Point(112, 32);
			tbflname.Name = "tbflname";
			tbflname.Size = new System.Drawing.Size(543, 21);
			tbflname.TabIndex = 11;
			tbflname.TextChanged += new EventHandler(SetFlName);
			//
			// label9
			//
			label9.AutoSize = true;
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			label9.ImeMode = ImeMode.NoControl;
			label9.Location = new System.Drawing.Point(45, 35);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(67, 13);
			label9.TabIndex = 10;
			label9.Text = "Filename";
			//
			// tbguid
			//
			tbguid.Location = new System.Drawing.Point(112, 96);
			tbguid.Name = "tbguid";
			tbguid.Size = new System.Drawing.Size(96, 21);
			tbguid.TabIndex = 9;
			tbguid.Text = "0xDDDDDDDD";
			tbguid.TextChanged += new EventHandler(SetGuide);
			//
			// label8
			//
			label8.AutoSize = true;
			label8.BackColor = System.Drawing.Color.Transparent;
			label8.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			label8.ImeMode = ImeMode.NoControl;
			label8.Location = new System.Drawing.Point(69, 99);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(40, 13);
			label8.TabIndex = 8;
			label8.Text = "GUID";
			//
			// panel6
			//
			panel6.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			//this.panel6.CanCommit = true;
			//this.panel6.HeaderText = "Object Data Editor";
			panel6.Location = new System.Drawing.Point(0, 0);
			panel6.Margin = new Padding(0);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(984, 24);
			panel6.TabIndex = 0;
			//this.panel6.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.OnCommit);
			//
			// toolTip1
			//
			toolTip1.AutomaticDelay = 200;
			toolTip1.AutoPopDelay = 6000;
			toolTip1.InitialDelay = 200;
			toolTip1.ReshowDelay = 40;
			//
			// ExtObjdForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(984, 325);
			Controls.Add(pnobjd);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Name = "ExtObjdForm";
			Text = "ExtObjdForm";
			pnobjd.ResumeLayout(false);
			pnobjd.PerformLayout();
			tc.ResumeLayout(false);
			tpcatalogsort.ResumeLayout(false);
			pngradient.ResumeLayout(false);
			taskBox1.ResumeLayout(false);
			taskBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			tpreqeps.ResumeLayout(false);
			pnpritty.ResumeLayout(false);
			tbreqeps.ResumeLayout(false);
			tbreqeps.PerformLayout();
			tpraw.ResumeLayout(false);
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		private void ChangeType(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			Tag = true;

			try
			{
				if (cbtype.SelectedIndex < 0)
				{
					return;
				}

				Data.ObjectTypes ot = (Data.ObjectTypes)
					cbtype.Items[cbtype.SelectedIndex];
				tbtype.Text = "0x" + Helper.HexString((ushort)ot);

				wrapper.Type = ot;
				wrapper.Changed = true;
				btnUpdateMMAT.Visible =
					label2.Visible =
					cball.Visible =
					lbIsOk.Visible =
						false;
				llgetGUID.Visible = (
					UserVerification.HaveUserId
					&& wrapper.Type != Data.ObjectTypes.Person
					&& wrapper.Type != Data.ObjectTypes.UnlinkedSim
				);
				//this.lladdgooee.Visible = (UserVerification.HaveUserId && !SimPe.Plugin.Subhoods.GuidExists(wrapper.Guid) && wrapper.Type != SimPe.Data.ObjectTypes.Person && wrapper.Type != SimPe.Data.ObjectTypes.UnlinkedSim);
				Tag = null;
			}
			finally
			{
				Tag = null;
			}
		}

		private void OnCommit(object sender, EventArgs e)
		{
			lbIsOk.Visible = false;
			if (pg.SelectedObject != null)
			{
				UpdateData();
			}

			wrapper.SynchronizeUserData();
		}

		private void SetRoomFlags(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			Tag = true;

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
				Tag = null;
			}
		}

		private void SetCommFlags(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			Tag = true;
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
				Tag = null;
			}
		}

		private void SetFunctionFlags(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			Tag = true;

			try
			{
				wrapper.FunctionSort.InAppliances = cbappliances.Checked;
				wrapper.FunctionSort.InDecorative = cbdecorative.Checked;
				wrapper.FunctionSort.InElectronics = cbelectronics.Checked;
				wrapper.FunctionSort.InGeneral = cbgeneral.Checked;
				wrapper.FunctionSort.InLighting = cblightning.Checked;
				wrapper.FunctionSort.InPlumbing = cbplumbing.Checked;
				wrapper.FunctionSort.InSeating = cbseating.Checked;
				wrapper.FunctionSort.InSurfaces = cbsurfaces.Checked;
				wrapper.FunctionSort.InHobbies = cbhobby.Checked;
				wrapper.FunctionSort.InAspirationRewards = cbaspiration.Checked;
				wrapper.FunctionSort.InCareerRewards = cbcareer.Checked;

				wrapper.Changed = true;
			}
			finally
			{
				Tag = null;
			}
		}

		private void SetExpansionFlags(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			Tag = true;

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
				Tag = null;
			}
		}

		private void SetGuide(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			Tag = true;
			try
			{
				wrapper.Guid = Convert.ToUInt32(tbguid.Text, 16);
				wrapper.Changed = true;
			}
			catch (Exception) { }
			finally
			{
				if (
					wrapper.Type != Data.ObjectTypes.Person
					&& wrapper.Type != Data.ObjectTypes.UnlinkedSim
				)
				{
					btnUpdateMMAT.Visible =
						label2.Visible =
						cball.Visible =
						lbIsOk.Visible =
							true;
					//this.lladdgooee.Visible = (UserVerification.HaveUserId && !SimPe.Plugin.Subhoods.GuidExists(wrapper.Guid));
				}
				Tag = null;
			}
		}

		private void SetGuid(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			Tag = true;
			try
			{
				wrapper.ProxyGuid = Convert.ToUInt32(tbproxguid.Text, 16);
				wrapper.OriginalGuid = Convert.ToUInt32(tborgguid.Text, 16);
				wrapper.DiagonalGuid = Convert.ToUInt32(tbdiag.Text, 16);
				wrapper.GridAlignedGuid = Convert.ToUInt32(tbgrid.Text, 16);
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
				lbIsOk.Visible = true;
				Tag = null;
			}
		}

		private void GetGuid(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			uint gooy = wrapper.createguid;
			if (gooy != 0)
			{
				tbguid.Text = "0x" + Helper.HexString(gooy);
				llgetGUID.LinkVisited = true;
			}
			else
			{
				llgetGUID.Links[0].Enabled = false;
			}
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

		private void btnUpdateMMAT_Click(object sender, EventArgs e)
		{
			if ((wrapper.Guid != initialguid) || (cball.Checked))
			{
				Plugin.FixGuid fg = new Plugin.FixGuid(wrapper.Package);
				if (cball.Checked)
				{
					fg.FixGuids(wrapper.Guid);
				}
				else
				{
					ArrayList al = new ArrayList();
					Plugin.GuidSet gs = new Plugin.GuidSet
					{
						oldguid = initialguid,
						guid = wrapper.Guid
					};
					al.Add(gs);

					fg.FixGuids(al);
				}
				initialguid = wrapper.Guid;
			}
			lbIsOk.Visible = false;
			wrapper.SynchronizeUserData();
		}

		private void CangedTab(object sender, EventArgs e)
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
				if (pg.SelectedObject != null)
				{
					UpdateData();
				}

				pg.SelectedObject = null;
			}
		}

		private void PropChanged(
			object s,
			PropertyValueChangedEventArgs e
		)
		{
			propchanged = true;
		}

		private void SetFlName(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			wrapper.FileName = tbflname.Text;
			wrapper.Changed = true;
		}

		private void DigitChanged(object sender, EventArgs e)
		{
			if (rbhex.Checked)
			{
				Ambertation.BaseChangeableNumber.DigitBase = 16;
			}
			else if (rbbin.Checked)
			{
				Ambertation.BaseChangeableNumber.DigitBase = 2;
			}
			else
			{
				Ambertation.BaseChangeableNumber.DigitBase = 10;
			}

			pg.Refresh();
		}

		private void cbsort_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			Tag = true;
			wrapper.FunctionSubSort = (Data.ObjFunctionSubSort)cbsort.SelectedValue;
			wrapper.Changed = true;
			SetFunctionCb(wrapper);
			Tag = null;
		}

		private void cbBuildSort_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			Tag = true;

			if (cbBuildSort.SelectedIndex < 0)
			{
				return;
			}

			bool skippy = false;
			if (cbBuildSort.SelectedIndex == 0) // none
			{
				wrapper.BuildSubSort = 0;
				wrapper.Type = Data.ObjectTypes.Normal;
			}
			if (cbBuildSort.SelectedIndex == 1)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.General_Columns;
				wrapper.Type = Data.ObjectTypes.ArchitecturalSupport;
			}
			if (cbBuildSort.SelectedIndex == 2)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.General_Stairs;
				wrapper.Type = Data.ObjectTypes.Stairs;
			}
			if (cbBuildSort.SelectedIndex == 3)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.General_Pool;
				skippy = true;
			}
			if (cbBuildSort.SelectedIndex == 4)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.General_TallColumns;
				wrapper.Type = Data.ObjectTypes.ArchitecturalSupport;
			}
			if (cbBuildSort.SelectedIndex == 5)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.General_Arch;
				wrapper.Type = Data.ObjectTypes.ArchitecturalSupport;
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
				wrapper.Type = Data.ObjectTypes.Normal;
			}
			if (cbBuildSort.SelectedIndex == 9)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Garden_Trees;
				wrapper.Type = Data.ObjectTypes.Normal;
			}
			if (cbBuildSort.SelectedIndex == 10)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Garden_Shrubs;
				wrapper.Type = Data.ObjectTypes.Normal;
			}
			if (cbBuildSort.SelectedIndex == 11)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Garden_Flowers;
				wrapper.Type = Data.ObjectTypes.Normal;
			}
			if (cbBuildSort.SelectedIndex == 12)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Garden_Objects;
				wrapper.Type = Data.ObjectTypes.Normal;
			}
			if (cbBuildSort.SelectedIndex == 13)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Openings_Door;
				wrapper.Type = Data.ObjectTypes.Door;
			}
			if (cbBuildSort.SelectedIndex == 14)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Openings_TallWindow;
				wrapper.Type = Data.ObjectTypes.Window;
			}
			if (cbBuildSort.SelectedIndex == 15)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Openings_Window;
				wrapper.Type = Data.ObjectTypes.Window;
			}
			if (cbBuildSort.SelectedIndex == 16)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Openings_Gate;
				wrapper.Type = Data.ObjectTypes.Door;
			}
			if (cbBuildSort.SelectedIndex == 17)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Openings_Arch;
				wrapper.Type = Data.ObjectTypes.Door;
			}
			if (cbBuildSort.SelectedIndex == 18)
			{
				wrapper.BuildSubSort = Data.BuildFunctionSubSort.Openings_TallDoor;
				wrapper.Type = Data.ObjectTypes.Door;
			}
			if (cbBuildSort.SelectedIndex == 19) // Unknown - won't change anything
			{
				skippy = true;
			}

			if (!skippy)
			{
				cbtype.SelectedIndex = 0;
				for (int i = 0; i < cbtype.Items.Count; i++)
				{
					Data.ObjectTypes ot = (Data.ObjectTypes)cbtype.Items[i];
					if (ot == wrapper.Type)
					{
						cbtype.SelectedIndex = i;
						break;
					}
				}

				tbtype.Text = "0x" + Helper.HexString((ushort)(wrapper.Type));
			}
			else
			{
				cbtype.Select();
			}

			Tag = null;
			wrapper.Changed = true;
		}

		private void tbPrice_TextChanged(object sender, EventArgs e)
		{
			tbPrice.ForeColor = System.Drawing.SystemColors.WindowText;
			if (Tag != null)
			{
				return;
			}

			try
			{
				string prise = tbPrice.Text;
				if (prise.StartsWith("�"))
				{
					prise = prise.Remove(0, 1);
				}

				wrapper.Price = Convert.ToInt16(prise);
			}
			catch
			{
				tbPrice.ForeColor = System.Drawing.Color.OrangeRed;
			}
		}
	}
}
