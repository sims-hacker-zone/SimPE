/***************************************************************************
 *   Original (C) Bidou, assumed to be licenced as part of SimPE           *
 *   Pet updates copyright (C) 2007 by Peter L Jones                       *
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
using System.Drawing;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using SimPe;
using SimPe.Data;
using SimPe.Interfaces;
using SimPe.PackedFiles.Wrapper;


namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class CareerEditor : System.Windows.Forms.Form
	{
		#region Windows Form Designer generated code

		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TextBox CareerTitle;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CareerLvls;
        private System.Windows.Forms.GroupBox gbJLDetails;
		private System.Windows.Forms.ComboBox Language;
        private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox gbJLHoursWages;
        private System.Windows.Forms.GroupBox gbJLPromo;
		private System.Windows.Forms.NumericUpDown PromoBody;
		private System.Windows.Forms.NumericUpDown PromoMechanical;
		private System.Windows.Forms.NumericUpDown PromoCooking;
		private System.Windows.Forms.NumericUpDown PromoCharisma;
		private System.Windows.Forms.NumericUpDown PromoFriends;
		private System.Windows.Forms.NumericUpDown PromoCleaning;
		private System.Windows.Forms.NumericUpDown PromoLogic;
		private System.Windows.Forms.NumericUpDown PromoCreativity;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
		private System.Windows.Forms.ListView JobDetailList;
		private System.Windows.Forms.ColumnHeader JdLvl;
		private System.Windows.Forms.ColumnHeader JdJobTitle;
		private System.Windows.Forms.ColumnHeader JdDesc;
		private System.Windows.Forms.ColumnHeader JdOutfit;
		private System.Windows.Forms.ColumnHeader JdVehicle;
		private System.Windows.Forms.ListView HoursWagesList;
		private System.Windows.Forms.ColumnHeader HwLvl;
		private System.Windows.Forms.ColumnHeader HwStart;
		private System.Windows.Forms.ColumnHeader HwHours;
		private System.Windows.Forms.ColumnHeader HwEnd;
		private System.Windows.Forms.ColumnHeader HwWages;
        private ColumnHeader HwCatWages;
        private ColumnHeader HwDogWages;
        private System.Windows.Forms.ColumnHeader HwSun;
		private System.Windows.Forms.ColumnHeader HwMon;
		private System.Windows.Forms.ColumnHeader HwTue;
		private System.Windows.Forms.ColumnHeader HwWed;
		private System.Windows.Forms.ColumnHeader HwThu;
		private System.Windows.Forms.ColumnHeader HwFri;
		private System.Windows.Forms.ColumnHeader HwSat;
		private System.Windows.Forms.ListView PromoList;
		private System.Windows.Forms.ColumnHeader PrLvl;
		private System.Windows.Forms.ColumnHeader PrCooking;
		private System.Windows.Forms.ColumnHeader PrMechanical;
		private System.Windows.Forms.ColumnHeader PrCharisma;
		private System.Windows.Forms.ColumnHeader PrBody;
		private System.Windows.Forms.ColumnHeader PrCreativity;
		private System.Windows.Forms.ColumnHeader PrLogic;
		private System.Windows.Forms.ColumnHeader PrCleaning;
		private System.Windows.Forms.ColumnHeader PrFriends;
        private System.Windows.Forms.GroupBox gbPromo;
        private System.Windows.Forms.GroupBox gbJobDetails;
        private System.Windows.Forms.MenuStrip mainMenu1;
        private System.Windows.Forms.ToolStripMenuItem menuItem1;
        private System.Windows.Forms.ToolStripMenuItem miEnglishOnly;
        private System.Windows.Forms.ToolStripMenuItem menuItem6;
        private System.Windows.Forms.ToolStripMenuItem miAddLvl;
        private System.Windows.Forms.ToolStripMenuItem miRemoveLvl;
        private Label label101;
        private ComboBox cbTrick;
        private ColumnHeader PrTrick;
        private JobDescPanel jdpMale;
        private JobDescPanel jdpFemale;
        private LinkLabel JobDetailsCopy;
        private LabelledNumericUpDown lnudChanceCurrentLevel;
        private LabelledNumericUpDown lnudChancePercent;
        private ChoicePanel cpChoiceA;
        private ChoicePanel cpChoiceB;
        private Label label51;
        private TextBox ChanceTextMale;
        private LinkLabel ChanceCopy;
        private Label label52;
        private TextBox ChanceTextFemale;
        private TabControl tcChanceOutcome;
        private TabPage tabPage5;
        private EffectPanel epPassA;
        private TabPage tabPage6;
        private EffectPanel epFailA;
        private TabPage tabPage7;
        private EffectPanel epPassB;
        private TabPage tabPage8;
        private EffectPanel epFailB;
        private GroupBox gbHoursWages;
        private LabelledNumericUpDown lnudWorkStart;
        private LabelledNumericUpDown lnudWorkHours;
        private LabelledNumericUpDown lnudWages;
        private LabelledNumericUpDown lnudWagesDog;
        private LabelledNumericUpDown lnudWagesCat;
        private CheckBox WorkMonday;
        private CheckBox WorkTuesday;
        private CheckBox WorkWednesday;
        private CheckBox WorkThursday;
        private CheckBox WorkFriday;
        private CheckBox WorkSaturday;
        private CheckBox WorkSunday;
        private GroupBox gbHWMotives;
        private Label label27;
        private Label label24;
        private NumericUpDown ComfortHours;
        private NumericUpDown HygieneTotal;
        private NumericUpDown BladderTotal;
        private Label label21;
        private NumericUpDown WorkBladder;
        private Label label23;
        private Label label19;
        private NumericUpDown WorkComfort;
        private NumericUpDown HungerHours;
        private NumericUpDown EnergyHours;
        private Label label25;
        private NumericUpDown WorkPublic;
        private NumericUpDown WorkHunger;
        private NumericUpDown BladderHours;
        private NumericUpDown ComfortTotal;
        private Label label22;
        private NumericUpDown HungerTotal;
        private NumericUpDown HygieneHours;
        private NumericUpDown WorkEnergy;
        private NumericUpDown WorkFun;
        private NumericUpDown WorkSunshine;
        private NumericUpDown PublicHours;
        private Label label20;
        private NumericUpDown SunshineTotal;
        private NumericUpDown EnergyTotal;
        private NumericUpDown FunTotal;
        private NumericUpDown PublicTotal;
        private Label label33;
        private Label label32;
        private Label label31;
        private Label label30;
        private Label label28;
        private Label label26;
        private NumericUpDown FunHours;
        private NumericUpDown WorkHygiene;
        private NumericUpDown SunshineHours;
        private GUIDChooser gcReward;
        private GUIDChooser gcUpgrade;
        private GUIDChooser gcOutfit;
        private GUIDChooser gcVehicle;
        private Label lbcrap;
        private Label lbPTO;
        private Label lbLscore;
        private NumericUpDown numLscore;
        private NumericUpDown numPTO;
        private PictureBox pictureBox1;
        private CheckBox checkBox1;
        private Label label2;
        private CheckBox checkBox3;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox42;
        private CheckBox checkBox43;
        private CheckBox checkBox44;
        private CheckBox checkBox45;
        private TextBox textBox17;
        private TextBox textBox18;
        private Label label46;
        private CheckBox checkBox38;
        private CheckBox checkBox39;
        private CheckBox checkBox40;
        private CheckBox checkBox41;
        private TextBox textBox15;
        private TextBox textBox16;
        private Label label45;
        private CheckBox checkBox34;
        private CheckBox checkBox35;
        private CheckBox checkBox36;
        private CheckBox checkBox37;
        private TextBox textBox13;
        private TextBox textBox14;
        private Label label44;
        private CheckBox checkBox30;
        private CheckBox checkBox31;
        private CheckBox checkBox32;
        private CheckBox checkBox33;
        private TextBox textBox11;
        private TextBox textBox12;
        private Label label43;
        private CheckBox checkBox26;
        private CheckBox checkBox27;
        private CheckBox checkBox28;
        private CheckBox checkBox29;
        private TextBox textBox9;
        private TextBox textBox10;
        private Label label42;
        private CheckBox checkBox22;
        private CheckBox checkBox23;
        private CheckBox checkBox24;
        private CheckBox checkBox25;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label label17;
        private CheckBox checkBox18;
        private CheckBox checkBox19;
        private CheckBox checkBox20;
        private CheckBox checkBox21;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label16;
        private CheckBox checkBox14;
        private CheckBox checkBox15;
        private CheckBox checkBox16;
        private CheckBox checkBox17;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label15;
        private CheckBox checkBox10;
        private CheckBox checkBox11;
        private CheckBox checkBox12;
        private CheckBox checkBox13;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label14;
        private Label lbrewguid;
        private Button btexApply;
        private Button btUgrade;
        private TabPage tabPagMajor;
        private GroupBox gbmajaffil;
        private GroupBox gbrequir;
        private CheckBox cbrdrama;
        private CheckBox cbrbiol;
        private CheckBox cbrArt;
        private CheckBox cbrecon;
        private CheckBox cbrhisto;
        private CheckBox cbrliter;
        private CheckBox cbrmaths;
        private CheckBox cbrphilo;
        private CheckBox cbrphysi;
        private CheckBox cbrphyco;
        private CheckBox cbrpolit;
        private CheckBox cbaphyco;
        private CheckBox cbapolit;
        private CheckBox cbaphysi;
        private CheckBox cbrahilo;
        private CheckBox cbamaths;
        private CheckBox cbaliter;
        private CheckBox cbahisto;
        private CheckBox cbaecon;
        private CheckBox cbadrama;
        private CheckBox cbabiol;
        private CheckBox cbaArt;
        private Label label29;
        private Button btmajApply;
        private Label label47;
        private LabelledNumericUpDown lnudPetChancePercent;
        private CheckBox cbischance;
        private LabelledNumericUpDown lnudFoods;
        private ToolTip toolTip1;
        private TextBox tbWorkFinish;
        private Label label48;
        private PictureBox pictureBox2;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public CareerEditor()
		{
			//
			// Required for Windows Form Designer support
			//
            InitializeComponent();

			englishOnly = false;

            internalchg = true;
            languageString = new List<string>(pjse.BhavWiz.readStr(pjse.GS.BhavStr.Languages));
            languageString.RemoveAt(0);

            gcReward.KnownObjects = new object[] { new List<String>(rewardName), new List<UInt32>(rewardGUID) };
            gcUpgrade.KnownObjects = new object[] { new List<String>(upgradeName), new List<UInt32>(upgradeGUID) };
            gcOutfit.KnownObjects = new object[] { new List<String>(outfitName), new List<UInt32>(outfitGUID) };
            gcVehicle.KnownObjects = new object[] { new List<String>(vehicleName), new List<UInt32>(vehicleGUID) };
            internalchg = false;

            this.gcUpgrade.ComboBoxWidth = this.gcReward.ComboBoxWidth = 220;
            this.gcOutfit.ComboBoxWidth = this.gcVehicle.ComboBoxWidth = 300;
            this.pictureBox2.Image = GetIcon.Information;
        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CareerEditor));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lnudPetChancePercent = new SimPe.Plugin.LabelledNumericUpDown();
            this.cbischance = new System.Windows.Forms.CheckBox();
            this.lnudChanceCurrentLevel = new SimPe.Plugin.LabelledNumericUpDown();
            this.lnudChancePercent = new SimPe.Plugin.LabelledNumericUpDown();
            this.cpChoiceA = new SimPe.Plugin.ChoicePanel();
            this.cpChoiceB = new SimPe.Plugin.ChoicePanel();
            this.ChanceTextMale = new System.Windows.Forms.TextBox();
            this.ChanceCopy = new System.Windows.Forms.LinkLabel();
            this.ChanceTextFemale = new System.Windows.Forms.TextBox();
            this.tcChanceOutcome = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.epPassA = new SimPe.Plugin.EffectPanel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.epFailA = new SimPe.Plugin.EffectPanel();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.epPassB = new SimPe.Plugin.EffectPanel();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.epFailB = new SimPe.Plugin.EffectPanel();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gbJLPromo = new System.Windows.Forms.GroupBox();
            this.PromoList = new System.Windows.Forms.ListView();
            this.PrLvl = new System.Windows.Forms.ColumnHeader();
            this.PrCooking = new System.Windows.Forms.ColumnHeader();
            this.PrMechanical = new System.Windows.Forms.ColumnHeader();
            this.PrBody = new System.Windows.Forms.ColumnHeader();
            this.PrCharisma = new System.Windows.Forms.ColumnHeader();
            this.PrCreativity = new System.Windows.Forms.ColumnHeader();
            this.PrLogic = new System.Windows.Forms.ColumnHeader();
            this.PrCleaning = new System.Windows.Forms.ColumnHeader();
            this.PrFriends = new System.Windows.Forms.ColumnHeader();
            this.PrTrick = new System.Windows.Forms.ColumnHeader();
            this.gbPromo = new System.Windows.Forms.GroupBox();
            this.cbTrick = new System.Windows.Forms.ComboBox();
            this.label101 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.PromoFriends = new System.Windows.Forms.NumericUpDown();
            this.PromoCleaning = new System.Windows.Forms.NumericUpDown();
            this.PromoLogic = new System.Windows.Forms.NumericUpDown();
            this.PromoCreativity = new System.Windows.Forms.NumericUpDown();
            this.PromoCharisma = new System.Windows.Forms.NumericUpDown();
            this.PromoBody = new System.Windows.Forms.NumericUpDown();
            this.PromoMechanical = new System.Windows.Forms.NumericUpDown();
            this.PromoCooking = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbHoursWages = new System.Windows.Forms.GroupBox();
            this.tbWorkFinish = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.lnudFoods = new SimPe.Plugin.LabelledNumericUpDown();
            this.lnudWorkStart = new SimPe.Plugin.LabelledNumericUpDown();
            this.lnudWorkHours = new SimPe.Plugin.LabelledNumericUpDown();
            this.lnudWages = new SimPe.Plugin.LabelledNumericUpDown();
            this.lnudWagesDog = new SimPe.Plugin.LabelledNumericUpDown();
            this.lbPTO = new System.Windows.Forms.Label();
            this.lnudWagesCat = new SimPe.Plugin.LabelledNumericUpDown();
            this.WorkMonday = new System.Windows.Forms.CheckBox();
            this.WorkTuesday = new System.Windows.Forms.CheckBox();
            this.WorkWednesday = new System.Windows.Forms.CheckBox();
            this.WorkThursday = new System.Windows.Forms.CheckBox();
            this.WorkFriday = new System.Windows.Forms.CheckBox();
            this.WorkSaturday = new System.Windows.Forms.CheckBox();
            this.WorkSunday = new System.Windows.Forms.CheckBox();
            this.gbHWMotives = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.ComfortHours = new System.Windows.Forms.NumericUpDown();
            this.HygieneTotal = new System.Windows.Forms.NumericUpDown();
            this.BladderTotal = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.WorkBladder = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.WorkComfort = new System.Windows.Forms.NumericUpDown();
            this.HungerHours = new System.Windows.Forms.NumericUpDown();
            this.EnergyHours = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.WorkPublic = new System.Windows.Forms.NumericUpDown();
            this.WorkHunger = new System.Windows.Forms.NumericUpDown();
            this.BladderHours = new System.Windows.Forms.NumericUpDown();
            this.ComfortTotal = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.HungerTotal = new System.Windows.Forms.NumericUpDown();
            this.HygieneHours = new System.Windows.Forms.NumericUpDown();
            this.WorkEnergy = new System.Windows.Forms.NumericUpDown();
            this.WorkFun = new System.Windows.Forms.NumericUpDown();
            this.WorkSunshine = new System.Windows.Forms.NumericUpDown();
            this.PublicHours = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.SunshineTotal = new System.Windows.Forms.NumericUpDown();
            this.EnergyTotal = new System.Windows.Forms.NumericUpDown();
            this.FunTotal = new System.Windows.Forms.NumericUpDown();
            this.PublicTotal = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.FunHours = new System.Windows.Forms.NumericUpDown();
            this.WorkHygiene = new System.Windows.Forms.NumericUpDown();
            this.SunshineHours = new System.Windows.Forms.NumericUpDown();
            this.lbLscore = new System.Windows.Forms.Label();
            this.numLscore = new System.Windows.Forms.NumericUpDown();
            this.numPTO = new System.Windows.Forms.NumericUpDown();
            this.gbJLHoursWages = new System.Windows.Forms.GroupBox();
            this.HoursWagesList = new System.Windows.Forms.ListView();
            this.HwLvl = new System.Windows.Forms.ColumnHeader();
            this.HwStart = new System.Windows.Forms.ColumnHeader();
            this.HwHours = new System.Windows.Forms.ColumnHeader();
            this.HwEnd = new System.Windows.Forms.ColumnHeader();
            this.HwWages = new System.Windows.Forms.ColumnHeader();
            this.HwDogWages = new System.Windows.Forms.ColumnHeader();
            this.HwCatWages = new System.Windows.Forms.ColumnHeader();
            this.HwMon = new System.Windows.Forms.ColumnHeader();
            this.HwTue = new System.Windows.Forms.ColumnHeader();
            this.HwWed = new System.Windows.Forms.ColumnHeader();
            this.HwThu = new System.Windows.Forms.ColumnHeader();
            this.HwFri = new System.Windows.Forms.ColumnHeader();
            this.HwSat = new System.Windows.Forms.ColumnHeader();
            this.HwSun = new System.Windows.Forms.ColumnHeader();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbJobDetails = new System.Windows.Forms.GroupBox();
            this.gcVehicle = new SimPe.Plugin.GUIDChooser();
            this.gcOutfit = new SimPe.Plugin.GUIDChooser();
            this.JobDetailsCopy = new System.Windows.Forms.LinkLabel();
            this.jdpFemale = new SimPe.Plugin.JobDescPanel();
            this.jdpMale = new SimPe.Plugin.JobDescPanel();
            this.gbJLDetails = new System.Windows.Forms.GroupBox();
            this.JobDetailList = new System.Windows.Forms.ListView();
            this.JdLvl = new System.Windows.Forms.ColumnHeader();
            this.JdJobTitle = new System.Windows.Forms.ColumnHeader();
            this.JdDesc = new System.Windows.Forms.ColumnHeader();
            this.JdOutfit = new System.Windows.Forms.ColumnHeader();
            this.JdVehicle = new System.Windows.Forms.ColumnHeader();
            this.tabPagMajor = new System.Windows.Forms.TabPage();
            this.btmajApply = new System.Windows.Forms.Button();
            this.gbmajaffil = new System.Windows.Forms.GroupBox();
            this.label47 = new System.Windows.Forms.Label();
            this.cbaphyco = new System.Windows.Forms.CheckBox();
            this.cbapolit = new System.Windows.Forms.CheckBox();
            this.cbaphysi = new System.Windows.Forms.CheckBox();
            this.cbrahilo = new System.Windows.Forms.CheckBox();
            this.cbamaths = new System.Windows.Forms.CheckBox();
            this.cbaliter = new System.Windows.Forms.CheckBox();
            this.cbahisto = new System.Windows.Forms.CheckBox();
            this.cbaecon = new System.Windows.Forms.CheckBox();
            this.cbadrama = new System.Windows.Forms.CheckBox();
            this.cbabiol = new System.Windows.Forms.CheckBox();
            this.cbaArt = new System.Windows.Forms.CheckBox();
            this.gbrequir = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cbrphyco = new System.Windows.Forms.CheckBox();
            this.cbrpolit = new System.Windows.Forms.CheckBox();
            this.cbrphysi = new System.Windows.Forms.CheckBox();
            this.cbrphilo = new System.Windows.Forms.CheckBox();
            this.cbrmaths = new System.Windows.Forms.CheckBox();
            this.cbrliter = new System.Windows.Forms.CheckBox();
            this.cbrhisto = new System.Windows.Forms.CheckBox();
            this.cbrecon = new System.Windows.Forms.CheckBox();
            this.cbrdrama = new System.Windows.Forms.CheckBox();
            this.cbrbiol = new System.Windows.Forms.CheckBox();
            this.cbrArt = new System.Windows.Forms.CheckBox();
            this.btexApply = new System.Windows.Forms.Button();
            this.lbrewguid = new System.Windows.Forms.Label();
            this.checkBox42 = new System.Windows.Forms.CheckBox();
            this.checkBox43 = new System.Windows.Forms.CheckBox();
            this.checkBox44 = new System.Windows.Forms.CheckBox();
            this.checkBox45 = new System.Windows.Forms.CheckBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.checkBox38 = new System.Windows.Forms.CheckBox();
            this.checkBox39 = new System.Windows.Forms.CheckBox();
            this.checkBox40 = new System.Windows.Forms.CheckBox();
            this.checkBox41 = new System.Windows.Forms.CheckBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.checkBox34 = new System.Windows.Forms.CheckBox();
            this.checkBox35 = new System.Windows.Forms.CheckBox();
            this.checkBox36 = new System.Windows.Forms.CheckBox();
            this.checkBox37 = new System.Windows.Forms.CheckBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.checkBox30 = new System.Windows.Forms.CheckBox();
            this.checkBox31 = new System.Windows.Forms.CheckBox();
            this.checkBox32 = new System.Windows.Forms.CheckBox();
            this.checkBox33 = new System.Windows.Forms.CheckBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.checkBox26 = new System.Windows.Forms.CheckBox();
            this.checkBox27 = new System.Windows.Forms.CheckBox();
            this.checkBox28 = new System.Windows.Forms.CheckBox();
            this.checkBox29 = new System.Windows.Forms.CheckBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.checkBox23 = new System.Windows.Forms.CheckBox();
            this.checkBox24 = new System.Windows.Forms.CheckBox();
            this.checkBox25 = new System.Windows.Forms.CheckBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.checkBox21 = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.CareerLvls = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CareerTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Language = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MenuStrip();
            this.menuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddLvl = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemoveLvl = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miEnglishOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.gcUpgrade = new SimPe.Plugin.GUIDChooser();
            this.gcReward = new SimPe.Plugin.GUIDChooser();
            this.lbcrap = new System.Windows.Forms.Label();
            this.btUgrade = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tcChanceOutcome.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gbJLPromo.SuspendLayout();
            this.gbPromo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PromoFriends)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoCleaning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoLogic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoCreativity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoCharisma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoBody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoMechanical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoCooking)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.gbHoursWages.SuspendLayout();
            this.gbHWMotives.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComfortHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HygieneTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BladderTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkBladder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkComfort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HungerHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkPublic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkHunger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BladderHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComfortTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HungerTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HygieneHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkFun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkSunshine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PublicHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SunshineTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FunTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PublicTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FunHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkHygiene)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SunshineHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLscore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPTO)).BeginInit();
            this.gbJLHoursWages.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbJobDetails.SuspendLayout();
            this.gbJLDetails.SuspendLayout();
            this.tabPagMajor.SuspendLayout();
            this.gbmajaffil.SuspendLayout();
            this.gbrequir.SuspendLayout();
            this.mainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pictureBox2);
            this.tabPage4.Controls.Add(this.lnudPetChancePercent);
            this.tabPage4.Controls.Add(this.cbischance);
            this.tabPage4.Controls.Add(this.lnudChanceCurrentLevel);
            this.tabPage4.Controls.Add(this.lnudChancePercent);
            this.tabPage4.Controls.Add(this.cpChoiceA);
            this.tabPage4.Controls.Add(this.cpChoiceB);
            this.tabPage4.Controls.Add(this.ChanceTextMale);
            this.tabPage4.Controls.Add(this.ChanceCopy);
            this.tabPage4.Controls.Add(this.ChanceTextFemale);
            this.tabPage4.Controls.Add(this.tcChanceOutcome);
            this.tabPage4.Controls.Add(this.label51);
            this.tabPage4.Controls.Add(this.label52);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1092, 534);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Chance Cards";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(343, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, resources.GetString("pictureBox2.ToolTip"));
            // 
            // lnudPetChancePercent
            // 
            this.lnudPetChancePercent.AutoSize = true;
            this.lnudPetChancePercent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lnudPetChancePercent.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.lnudPetChancePercent.Label = "Chance for B %";
            this.lnudPetChancePercent.LabelAnchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lnudPetChancePercent.Location = new System.Drawing.Point(379, 2);
            this.lnudPetChancePercent.Margin = new System.Windows.Forms.Padding(0);
            this.lnudPetChancePercent.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.lnudPetChancePercent.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lnudPetChancePercent.Name = "lnudPetChancePercent";
            this.lnudPetChancePercent.NoLabel = false;
            this.lnudPetChancePercent.ReadOnly = false;
            this.lnudPetChancePercent.Size = new System.Drawing.Size(167, 27);
            this.lnudPetChancePercent.TabIndex = 7;
            this.lnudPetChancePercent.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lnudPetChancePercent.ValueSize = new System.Drawing.Size(57, 21);
            this.lnudPetChancePercent.Visible = false;
            // 
            // cbischance
            // 
            this.cbischance.AutoSize = true;
            this.cbischance.Location = new System.Drawing.Point(276, 100);
            this.cbischance.Name = "cbischance";
            this.cbischance.Size = new System.Drawing.Size(172, 17);
            this.cbischance.TabIndex = 6;
            this.cbischance.Text = "Is Available at this Level?";
            this.toolTip1.SetToolTip(this.cbischance, "Unset this if there is to be\r\nno Chance Card for this level.");
            this.cbischance.UseVisualStyleBackColor = true;
            this.cbischance.CheckedChanged += new System.EventHandler(this.cbischance_CheckedChanged);
            // 
            // lnudChanceCurrentLevel
            // 
            this.lnudChanceCurrentLevel.AutoSize = true;
            this.lnudChanceCurrentLevel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lnudChanceCurrentLevel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.lnudChanceCurrentLevel.Label = "Current Level";
            this.lnudChanceCurrentLevel.LabelAnchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lnudChanceCurrentLevel.Location = new System.Drawing.Point(7, 2);
            this.lnudChanceCurrentLevel.Margin = new System.Windows.Forms.Padding(0);
            this.lnudChanceCurrentLevel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.lnudChanceCurrentLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lnudChanceCurrentLevel.Name = "lnudChanceCurrentLevel";
            this.lnudChanceCurrentLevel.NoLabel = false;
            this.lnudChanceCurrentLevel.ReadOnly = false;
            this.lnudChanceCurrentLevel.Size = new System.Drawing.Size(154, 27);
            this.lnudChanceCurrentLevel.TabIndex = 1;
            this.lnudChanceCurrentLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lnudChanceCurrentLevel.ValueSize = new System.Drawing.Size(57, 21);
            this.lnudChanceCurrentLevel.ValueChanged += new System.EventHandler(this.lnudChanceCurrentLevel_ValueChanged);
            // 
            // lnudChancePercent
            // 
            this.lnudChancePercent.AutoSize = true;
            this.lnudChancePercent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lnudChancePercent.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.lnudChancePercent.Label = "Chance for A %";
            this.lnudChancePercent.LabelAnchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lnudChancePercent.Location = new System.Drawing.Point(170, 2);
            this.lnudChancePercent.Margin = new System.Windows.Forms.Padding(0);
            this.lnudChancePercent.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.lnudChancePercent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.lnudChancePercent.Name = "lnudChancePercent";
            this.lnudChancePercent.NoLabel = false;
            this.lnudChancePercent.ReadOnly = false;
            this.lnudChancePercent.Size = new System.Drawing.Size(167, 27);
            this.lnudChancePercent.TabIndex = 2;
            this.lnudChancePercent.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lnudChancePercent.ValueSize = new System.Drawing.Size(57, 21);
            this.lnudChancePercent.ValueChanged += new System.EventHandler(this.lnudChancePercent_ValueChanged);
            // 
            // cpChoiceA
            // 
            this.cpChoiceA.AutoSize = true;
            this.cpChoiceA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cpChoiceA.BackColor = System.Drawing.Color.Transparent;
            this.cpChoiceA.Body = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceA.Charisma = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceA.Cleaning = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceA.Cooking = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceA.Creativity = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceA.HaveSkills = true;
            this.cpChoiceA.Label = "ChoiceA";
            this.cpChoiceA.Labels = true;
            this.cpChoiceA.Location = new System.Drawing.Point(4, 15);
            this.cpChoiceA.Logic = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceA.Margin = new System.Windows.Forms.Padding(0);
            this.cpChoiceA.MaximumSize = new System.Drawing.Size(1160, 48);
            this.cpChoiceA.Mechanical = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceA.Name = "cpChoiceA";
            this.cpChoiceA.Size = new System.Drawing.Size(1060, 48);
            this.cpChoiceA.TabIndex = 2;
            this.cpChoiceA.Value = "ChoiceA";
            // 
            // cpChoiceB
            // 
            this.cpChoiceB.AutoSize = true;
            this.cpChoiceB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cpChoiceB.BackColor = System.Drawing.Color.Transparent;
            this.cpChoiceB.Body = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceB.Charisma = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceB.Cleaning = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceB.Cooking = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceB.Creativity = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceB.HaveSkills = true;
            this.cpChoiceB.Label = "ChoiceB";
            this.cpChoiceB.Labels = false;
            this.cpChoiceB.Location = new System.Drawing.Point(4, 68);
            this.cpChoiceB.Logic = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceB.Margin = new System.Windows.Forms.Padding(0);
            this.cpChoiceB.MaximumSize = new System.Drawing.Size(1160, 27);
            this.cpChoiceB.Mechanical = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cpChoiceB.Name = "cpChoiceB";
            this.cpChoiceB.Size = new System.Drawing.Size(1060, 27);
            this.cpChoiceB.TabIndex = 3;
            this.cpChoiceB.Value = "ChoiceB";
            // 
            // ChanceTextMale
            // 
            this.ChanceTextMale.Location = new System.Drawing.Point(593, 121);
            this.ChanceTextMale.Multiline = true;
            this.ChanceTextMale.Name = "ChanceTextMale";
            this.ChanceTextMale.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChanceTextMale.Size = new System.Drawing.Size(490, 134);
            this.ChanceTextMale.TabIndex = 2;
            this.ChanceTextMale.Text = "textBox3";
            // 
            // ChanceCopy
            // 
            this.ChanceCopy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ChanceCopy.AutoSize = true;
            this.ChanceCopy.Location = new System.Drawing.Point(547, 146);
            this.ChanceCopy.Name = "ChanceCopy";
            this.ChanceCopy.Size = new System.Drawing.Size(50, 13);
            this.ChanceCopy.TabIndex = 3;
            this.ChanceCopy.TabStop = true;
            this.ChanceCopy.Text = "Copy >";
            this.ChanceCopy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChanceCopy_LinkClicked);
            // 
            // ChanceTextFemale
            // 
            this.ChanceTextFemale.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChanceTextFemale.Location = new System.Drawing.Point(7, 121);
            this.ChanceTextFemale.Multiline = true;
            this.ChanceTextFemale.Name = "ChanceTextFemale";
            this.ChanceTextFemale.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChanceTextFemale.Size = new System.Drawing.Size(540, 134);
            this.ChanceTextFemale.TabIndex = 2;
            this.ChanceTextFemale.Text = "textBox4";
            // 
            // tcChanceOutcome
            // 
            this.tcChanceOutcome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcChanceOutcome.Controls.Add(this.tabPage5);
            this.tcChanceOutcome.Controls.Add(this.tabPage6);
            this.tcChanceOutcome.Controls.Add(this.tabPage7);
            this.tcChanceOutcome.Controls.Add(this.tabPage8);
            this.tcChanceOutcome.Location = new System.Drawing.Point(3, 261);
            this.tcChanceOutcome.Name = "tcChanceOutcome";
            this.tcChanceOutcome.SelectedIndex = 0;
            this.tcChanceOutcome.Size = new System.Drawing.Size(1084, 264);
            this.tcChanceOutcome.TabIndex = 5;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.epPassA);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1076, 238);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Pass A";
            // 
            // epPassA
            // 
            this.epPassA.AutoSize = true;
            this.epPassA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.epPassA.Body = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassA.Charisma = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassA.Cleaning = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassA.Cooking = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassA.Creativity = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassA.Female = "textBox2";
            this.epPassA.Food = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassA.IsCastaway = false;
            this.epPassA.IsPetCareer = false;
            this.epPassA.JobLevels = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassA.Location = new System.Drawing.Point(0, 0);
            this.epPassA.Logic = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassA.Male = "textBox1";
            this.epPassA.Margin = new System.Windows.Forms.Padding(0);
            this.epPassA.Mechanical = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassA.Money = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassA.Name = "epPassA";
            this.epPassA.Size = new System.Drawing.Size(1076, 238);
            this.epPassA.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.epFailA);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1076, 238);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Fail A";
            // 
            // epFailA
            // 
            this.epFailA.AutoSize = true;
            this.epFailA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.epFailA.Body = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailA.Charisma = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailA.Cleaning = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailA.Cooking = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailA.Creativity = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailA.Female = "textBox2";
            this.epFailA.Food = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailA.IsCastaway = false;
            this.epFailA.IsPetCareer = false;
            this.epFailA.JobLevels = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailA.Location = new System.Drawing.Point(0, 0);
            this.epFailA.Logic = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailA.Male = "textBox1";
            this.epFailA.Margin = new System.Windows.Forms.Padding(0);
            this.epFailA.Mechanical = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailA.Money = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailA.Name = "epFailA";
            this.epFailA.Size = new System.Drawing.Size(1076, 238);
            this.epFailA.TabIndex = 1;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.epPassB);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1076, 238);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Pass B";
            // 
            // epPassB
            // 
            this.epPassB.AutoSize = true;
            this.epPassB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.epPassB.Body = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassB.Charisma = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassB.Cleaning = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassB.Cooking = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassB.Creativity = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassB.Female = "textBox2";
            this.epPassB.Food = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassB.IsCastaway = false;
            this.epPassB.IsPetCareer = false;
            this.epPassB.JobLevels = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassB.Location = new System.Drawing.Point(0, 0);
            this.epPassB.Logic = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassB.Male = "textBox1";
            this.epPassB.Margin = new System.Windows.Forms.Padding(0);
            this.epPassB.Mechanical = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassB.Money = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epPassB.Name = "epPassB";
            this.epPassB.Size = new System.Drawing.Size(1076, 238);
            this.epPassB.TabIndex = 1;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.epFailB);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1076, 238);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "Fail B";
            // 
            // epFailB
            // 
            this.epFailB.AutoSize = true;
            this.epFailB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.epFailB.Body = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailB.Charisma = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailB.Cleaning = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailB.Cooking = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailB.Creativity = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailB.Female = "textBox2";
            this.epFailB.Food = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailB.IsCastaway = false;
            this.epFailB.IsPetCareer = false;
            this.epFailB.JobLevels = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailB.Location = new System.Drawing.Point(0, 0);
            this.epFailB.Logic = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailB.Male = "textBox1";
            this.epFailB.Margin = new System.Windows.Forms.Padding(0);
            this.epFailB.Mechanical = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailB.Money = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.epFailB.Name = "epFailB";
            this.epFailB.Size = new System.Drawing.Size(1076, 238);
            this.epFailB.TabIndex = 1;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(590, 102);
            this.label51.Margin = new System.Windows.Forms.Padding(0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(61, 13);
            this.label51.TabIndex = 1;
            this.label51.Text = "Text Male";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(6, 102);
            this.label52.Margin = new System.Windows.Forms.Padding(0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(76, 13);
            this.label52.TabIndex = 1;
            this.label52.Text = "Text Female";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gbJLPromo);
            this.tabPage3.Controls.Add(this.gbPromo);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1092, 534);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Promotion";
            // 
            // gbJLPromo
            // 
            this.gbJLPromo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbJLPromo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbJLPromo.BackColor = System.Drawing.Color.Transparent;
            this.gbJLPromo.Controls.Add(this.PromoList);
            this.gbJLPromo.Location = new System.Drawing.Point(10, 6);
            this.gbJLPromo.Name = "gbJLPromo";
            this.gbJLPromo.Size = new System.Drawing.Size(1069, 262);
            this.gbJLPromo.TabIndex = 1;
            this.gbJLPromo.TabStop = false;
            this.gbJLPromo.Text = "Job Levels";
            // 
            // PromoList
            // 
            this.PromoList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PromoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PrLvl,
            this.PrCooking,
            this.PrMechanical,
            this.PrBody,
            this.PrCharisma,
            this.PrCreativity,
            this.PrLogic,
            this.PrCleaning,
            this.PrFriends,
            this.PrTrick});
            this.PromoList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PromoList.FullRowSelect = true;
            this.PromoList.GridLines = true;
            this.PromoList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.PromoList.HideSelection = false;
            this.PromoList.Location = new System.Drawing.Point(10, 18);
            this.PromoList.MultiSelect = false;
            this.PromoList.Name = "PromoList";
            this.PromoList.Size = new System.Drawing.Size(1048, 232);
            this.PromoList.TabIndex = 1;
            this.PromoList.UseCompatibleStateImageBehavior = false;
            this.PromoList.View = System.Windows.Forms.View.Details;
            this.PromoList.SelectedIndexChanged += new System.EventHandler(this.PromoList_SelectedIndexChanged);
            // 
            // PrLvl
            // 
            this.PrLvl.Text = "Lvl";
            // 
            // PrCooking
            // 
            this.PrCooking.Text = "Cooking";
            this.PrCooking.Width = 82;
            // 
            // PrMechanical
            // 
            this.PrMechanical.Text = "Mechanical";
            this.PrMechanical.Width = 101;
            // 
            // PrBody
            // 
            this.PrBody.Text = "Body";
            this.PrBody.Width = 90;
            // 
            // PrCharisma
            // 
            this.PrCharisma.Text = "Charisma";
            this.PrCharisma.Width = 99;
            // 
            // PrCreativity
            // 
            this.PrCreativity.Text = "Creativity";
            this.PrCreativity.Width = 108;
            // 
            // PrLogic
            // 
            this.PrLogic.Text = "Logic";
            this.PrLogic.Width = 98;
            // 
            // PrCleaning
            // 
            this.PrCleaning.Text = "Cleaning";
            this.PrCleaning.Width = 117;
            // 
            // PrFriends
            // 
            this.PrFriends.Text = "Friends";
            this.PrFriends.Width = 100;
            // 
            // PrTrick
            // 
            this.PrTrick.Text = "Trick";
            this.PrTrick.Width = 152;
            // 
            // gbPromo
            // 
            this.gbPromo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPromo.BackColor = System.Drawing.Color.Transparent;
            this.gbPromo.Controls.Add(this.cbTrick);
            this.gbPromo.Controls.Add(this.label101);
            this.gbPromo.Controls.Add(this.label41);
            this.gbPromo.Controls.Add(this.label40);
            this.gbPromo.Controls.Add(this.label39);
            this.gbPromo.Controls.Add(this.label38);
            this.gbPromo.Controls.Add(this.label37);
            this.gbPromo.Controls.Add(this.label36);
            this.gbPromo.Controls.Add(this.label35);
            this.gbPromo.Controls.Add(this.label34);
            this.gbPromo.Controls.Add(this.PromoFriends);
            this.gbPromo.Controls.Add(this.PromoCleaning);
            this.gbPromo.Controls.Add(this.PromoLogic);
            this.gbPromo.Controls.Add(this.PromoCreativity);
            this.gbPromo.Controls.Add(this.PromoCharisma);
            this.gbPromo.Controls.Add(this.PromoBody);
            this.gbPromo.Controls.Add(this.PromoMechanical);
            this.gbPromo.Controls.Add(this.PromoCooking);
            this.gbPromo.Location = new System.Drawing.Point(10, 285);
            this.gbPromo.Name = "gbPromo";
            this.gbPromo.Size = new System.Drawing.Size(1069, 240);
            this.gbPromo.TabIndex = 2;
            this.gbPromo.TabStop = false;
            this.gbPromo.Text = "Current Level";
            // 
            // cbTrick
            // 
            this.cbTrick.FormattingEnabled = true;
            this.cbTrick.Items.AddRange(new object[] {
            "None",
            "Stay",
            "Come Here",
            "Play Dead",
            "Speak",
            "Shake",
            "Sit Up",
            "Roll Over"});
            this.cbTrick.Location = new System.Drawing.Point(322, 51);
            this.cbTrick.Name = "cbTrick";
            this.cbTrick.Size = new System.Drawing.Size(157, 21);
            this.cbTrick.TabIndex = 18;
            this.cbTrick.SelectedIndexChanged += new System.EventHandler(this.cbTrick_SelectedIndexChanged);
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(184, 54);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(34, 13);
            this.label101.TabIndex = 17;
            this.label101.Text = "Trick";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(184, 25);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(88, 13);
            this.label41.TabIndex = 15;
            this.label41.Text = "Family Friends";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(10, 191);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(57, 13);
            this.label40.TabIndex = 13;
            this.label40.Text = "Cleaning";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(10, 163);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(36, 13);
            this.label39.TabIndex = 11;
            this.label39.Text = "Logic";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(10, 135);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(63, 13);
            this.label38.TabIndex = 9;
            this.label38.Text = "Creativity";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(10, 107);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(62, 13);
            this.label37.TabIndex = 7;
            this.label37.Text = "Charisma";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(10, 79);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(36, 13);
            this.label36.TabIndex = 5;
            this.label36.Text = "Body";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(10, 51);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(69, 13);
            this.label35.TabIndex = 3;
            this.label35.Text = "Mechanical";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(10, 23);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(54, 13);
            this.label34.TabIndex = 1;
            this.label34.Text = "Cooking";
            // 
            // PromoFriends
            // 
            this.PromoFriends.Location = new System.Drawing.Point(322, 23);
            this.PromoFriends.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.PromoFriends.Name = "PromoFriends";
            this.PromoFriends.Size = new System.Drawing.Size(57, 21);
            this.PromoFriends.TabIndex = 16;
            this.PromoFriends.ValueChanged += new System.EventHandler(this.Promo_ValueChanged);
            this.PromoFriends.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Promo_KeyUp);
            // 
            // PromoCleaning
            // 
            this.PromoCleaning.Location = new System.Drawing.Point(104, 189);
            this.PromoCleaning.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PromoCleaning.Name = "PromoCleaning";
            this.PromoCleaning.Size = new System.Drawing.Size(57, 21);
            this.PromoCleaning.TabIndex = 14;
            this.PromoCleaning.ValueChanged += new System.EventHandler(this.Promo_ValueChanged);
            this.PromoCleaning.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Promo_KeyUp);
            // 
            // PromoLogic
            // 
            this.PromoLogic.Location = new System.Drawing.Point(104, 161);
            this.PromoLogic.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PromoLogic.Name = "PromoLogic";
            this.PromoLogic.Size = new System.Drawing.Size(57, 21);
            this.PromoLogic.TabIndex = 12;
            this.PromoLogic.ValueChanged += new System.EventHandler(this.Promo_ValueChanged);
            this.PromoLogic.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Promo_KeyUp);
            // 
            // PromoCreativity
            // 
            this.PromoCreativity.Location = new System.Drawing.Point(104, 133);
            this.PromoCreativity.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PromoCreativity.Name = "PromoCreativity";
            this.PromoCreativity.Size = new System.Drawing.Size(57, 21);
            this.PromoCreativity.TabIndex = 10;
            this.PromoCreativity.ValueChanged += new System.EventHandler(this.Promo_ValueChanged);
            this.PromoCreativity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Promo_KeyUp);
            // 
            // PromoCharisma
            // 
            this.PromoCharisma.Location = new System.Drawing.Point(104, 105);
            this.PromoCharisma.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PromoCharisma.Name = "PromoCharisma";
            this.PromoCharisma.Size = new System.Drawing.Size(57, 21);
            this.PromoCharisma.TabIndex = 8;
            this.PromoCharisma.ValueChanged += new System.EventHandler(this.Promo_ValueChanged);
            this.PromoCharisma.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Promo_KeyUp);
            // 
            // PromoBody
            // 
            this.PromoBody.Location = new System.Drawing.Point(104, 77);
            this.PromoBody.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PromoBody.Name = "PromoBody";
            this.PromoBody.Size = new System.Drawing.Size(57, 21);
            this.PromoBody.TabIndex = 6;
            this.PromoBody.ValueChanged += new System.EventHandler(this.Promo_ValueChanged);
            this.PromoBody.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Promo_KeyUp);
            // 
            // PromoMechanical
            // 
            this.PromoMechanical.Location = new System.Drawing.Point(104, 49);
            this.PromoMechanical.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PromoMechanical.Name = "PromoMechanical";
            this.PromoMechanical.Size = new System.Drawing.Size(57, 21);
            this.PromoMechanical.TabIndex = 4;
            this.PromoMechanical.ValueChanged += new System.EventHandler(this.Promo_ValueChanged);
            this.PromoMechanical.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Promo_KeyUp);
            // 
            // PromoCooking
            // 
            this.PromoCooking.Location = new System.Drawing.Point(104, 21);
            this.PromoCooking.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PromoCooking.Name = "PromoCooking";
            this.PromoCooking.Size = new System.Drawing.Size(57, 21);
            this.PromoCooking.TabIndex = 2;
            this.PromoCooking.ValueChanged += new System.EventHandler(this.Promo_ValueChanged);
            this.PromoCooking.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Promo_KeyUp);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbHoursWages);
            this.tabPage2.Controls.Add(this.gbJLHoursWages);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1092, 534);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hours & Wages";
            // 
            // gbHoursWages
            // 
            this.gbHoursWages.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbHoursWages.BackColor = System.Drawing.Color.Transparent;
            this.gbHoursWages.Controls.Add(this.tbWorkFinish);
            this.gbHoursWages.Controls.Add(this.label48);
            this.gbHoursWages.Controls.Add(this.lnudFoods);
            this.gbHoursWages.Controls.Add(this.lnudWorkStart);
            this.gbHoursWages.Controls.Add(this.lnudWorkHours);
            this.gbHoursWages.Controls.Add(this.lnudWages);
            this.gbHoursWages.Controls.Add(this.lnudWagesDog);
            this.gbHoursWages.Controls.Add(this.lbPTO);
            this.gbHoursWages.Controls.Add(this.lnudWagesCat);
            this.gbHoursWages.Controls.Add(this.WorkMonday);
            this.gbHoursWages.Controls.Add(this.WorkTuesday);
            this.gbHoursWages.Controls.Add(this.WorkWednesday);
            this.gbHoursWages.Controls.Add(this.WorkThursday);
            this.gbHoursWages.Controls.Add(this.WorkFriday);
            this.gbHoursWages.Controls.Add(this.WorkSaturday);
            this.gbHoursWages.Controls.Add(this.WorkSunday);
            this.gbHoursWages.Controls.Add(this.gbHWMotives);
            this.gbHoursWages.Controls.Add(this.lbLscore);
            this.gbHoursWages.Controls.Add(this.numLscore);
            this.gbHoursWages.Controls.Add(this.numPTO);
            this.gbHoursWages.Location = new System.Drawing.Point(10, 285);
            this.gbHoursWages.Name = "gbHoursWages";
            this.gbHoursWages.Size = new System.Drawing.Size(1069, 240);
            this.gbHoursWages.TabIndex = 2;
            this.gbHoursWages.TabStop = false;
            this.gbHoursWages.Text = "Current Level";
            // 
            // tbWorkFinish
            // 
            this.tbWorkFinish.BackColor = System.Drawing.SystemColors.Window;
            this.tbWorkFinish.Location = new System.Drawing.Point(281, 30);
            this.tbWorkFinish.Name = "tbWorkFinish";
            this.tbWorkFinish.ReadOnly = true;
            this.tbWorkFinish.Size = new System.Drawing.Size(41, 21);
            this.tbWorkFinish.TabIndex = 14;
            this.tbWorkFinish.Text = "88";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(236, 34);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(39, 13);
            this.label48.TabIndex = 13;
            this.label48.Text = "Finish";
            // 
            // lnudFoods
            // 
            this.lnudFoods.AutoSize = true;
            this.lnudFoods.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lnudFoods.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.lnudFoods.Label = "Food";
            this.lnudFoods.LabelAnchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnudFoods.Location = new System.Drawing.Point(239, 71);
            this.lnudFoods.Margin = new System.Windows.Forms.Padding(0);
            this.lnudFoods.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.lnudFoods.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lnudFoods.Name = "lnudFoods";
            this.lnudFoods.NoLabel = false;
            this.lnudFoods.ReadOnly = false;
            this.lnudFoods.Size = new System.Drawing.Size(146, 27);
            this.lnudFoods.TabIndex = 12;
            this.lnudFoods.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lnudFoods.ValueSize = new System.Drawing.Size(100, 21);
            this.lnudFoods.Visible = false;
            this.lnudFoods.ValueChanged += new System.EventHandler(this.lnudFoods_ValueChanged);
            // 
            // lnudWorkStart
            // 
            this.lnudWorkStart.AutoSize = true;
            this.lnudWorkStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lnudWorkStart.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.lnudWorkStart.Label = "Start";
            this.lnudWorkStart.LabelAnchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnudWorkStart.Location = new System.Drawing.Point(10, 27);
            this.lnudWorkStart.Margin = new System.Windows.Forms.Padding(0);
            this.lnudWorkStart.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.lnudWorkStart.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lnudWorkStart.Name = "lnudWorkStart";
            this.lnudWorkStart.NoLabel = false;
            this.lnudWorkStart.ReadOnly = false;
            this.lnudWorkStart.Size = new System.Drawing.Size(104, 27);
            this.lnudWorkStart.TabIndex = 1;
            this.lnudWorkStart.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lnudWorkStart.ValueSize = new System.Drawing.Size(57, 21);
            this.lnudWorkStart.ValueChanged += new System.EventHandler(this.lnudWork_ValueChanged);
            this.lnudWorkStart.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lnudWork_KeyUp);
            // 
            // lnudWorkHours
            // 
            this.lnudWorkHours.AutoSize = true;
            this.lnudWorkHours.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lnudWorkHours.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.lnudWorkHours.Label = "Hours";
            this.lnudWorkHours.LabelAnchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnudWorkHours.Location = new System.Drawing.Point(114, 27);
            this.lnudWorkHours.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lnudWorkHours.Maximum = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.lnudWorkHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lnudWorkHours.Name = "lnudWorkHours";
            this.lnudWorkHours.NoLabel = false;
            this.lnudWorkHours.ReadOnly = false;
            this.lnudWorkHours.Size = new System.Drawing.Size(109, 27);
            this.lnudWorkHours.TabIndex = 2;
            this.lnudWorkHours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lnudWorkHours.ValueSize = new System.Drawing.Size(57, 21);
            this.lnudWorkHours.ValueChanged += new System.EventHandler(this.lnudWork_ValueChanged);
            this.lnudWorkHours.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lnudWork_KeyUp);
            // 
            // lnudWages
            // 
            this.lnudWages.AutoSize = true;
            this.lnudWages.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lnudWages.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.lnudWages.Label = "Wages";
            this.lnudWages.LabelAnchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnudWages.Location = new System.Drawing.Point(61, 71);
            this.lnudWages.Margin = new System.Windows.Forms.Padding(0);
            this.lnudWages.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.lnudWages.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lnudWages.Name = "lnudWages";
            this.lnudWages.NoLabel = false;
            this.lnudWages.ReadOnly = false;
            this.lnudWages.Size = new System.Drawing.Size(156, 27);
            this.lnudWages.TabIndex = 1;
            this.lnudWages.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lnudWages.ValueSize = new System.Drawing.Size(100, 21);
            this.lnudWages.ValueChanged += new System.EventHandler(this.lnudWork_ValueChanged);
            this.lnudWages.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lnudWork_KeyUp);
            // 
            // lnudWagesDog
            // 
            this.lnudWagesDog.AutoSize = true;
            this.lnudWagesDog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lnudWagesDog.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.lnudWagesDog.Label = "Wages (Dog)";
            this.lnudWagesDog.LabelAnchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lnudWagesDog.Location = new System.Drawing.Point(24, 103);
            this.lnudWagesDog.Margin = new System.Windows.Forms.Padding(0);
            this.lnudWagesDog.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.lnudWagesDog.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lnudWagesDog.Name = "lnudWagesDog";
            this.lnudWagesDog.NoLabel = false;
            this.lnudWagesDog.ReadOnly = false;
            this.lnudWagesDog.Size = new System.Drawing.Size(193, 27);
            this.lnudWagesDog.TabIndex = 2;
            this.lnudWagesDog.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lnudWagesDog.ValueSize = new System.Drawing.Size(100, 21);
            this.lnudWagesDog.ValueChanged += new System.EventHandler(this.lnudWork_ValueChanged);
            this.lnudWagesDog.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lnudWork_KeyUp);
            // 
            // lbPTO
            // 
            this.lbPTO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPTO.AutoSize = true;
            this.lbPTO.Location = new System.Drawing.Point(466, 207);
            this.lbPTO.Name = "lbPTO";
            this.lbPTO.Size = new System.Drawing.Size(226, 13);
            this.lbPTO.TabIndex = 11;
            this.lbPTO.Text = "Paid Time Off (PTO) Daily Accruement";
            this.lbPTO.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lnudWagesCat
            // 
            this.lnudWagesCat.AutoSize = true;
            this.lnudWagesCat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lnudWagesCat.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.lnudWagesCat.Label = "Wages (Cat)";
            this.lnudWagesCat.LabelAnchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lnudWagesCat.Location = new System.Drawing.Point(27, 138);
            this.lnudWagesCat.Margin = new System.Windows.Forms.Padding(0);
            this.lnudWagesCat.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.lnudWagesCat.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lnudWagesCat.Name = "lnudWagesCat";
            this.lnudWagesCat.NoLabel = false;
            this.lnudWagesCat.ReadOnly = false;
            this.lnudWagesCat.Size = new System.Drawing.Size(190, 27);
            this.lnudWagesCat.TabIndex = 3;
            this.lnudWagesCat.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lnudWagesCat.ValueSize = new System.Drawing.Size(100, 21);
            this.lnudWagesCat.ValueChanged += new System.EventHandler(this.lnudWork_ValueChanged);
            this.lnudWagesCat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lnudWork_KeyUp);
            // 
            // WorkMonday
            // 
            this.WorkMonday.AutoSize = true;
            this.WorkMonday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WorkMonday.Location = new System.Drawing.Point(13, 206);
            this.WorkMonday.Name = "WorkMonday";
            this.WorkMonday.Size = new System.Drawing.Size(49, 17);
            this.WorkMonday.TabIndex = 1;
            this.WorkMonday.Text = "Mon";
            this.WorkMonday.CheckedChanged += new System.EventHandler(this.Workday_CheckedChanged);
            // 
            // WorkTuesday
            // 
            this.WorkTuesday.AutoSize = true;
            this.WorkTuesday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WorkTuesday.Location = new System.Drawing.Point(77, 206);
            this.WorkTuesday.Name = "WorkTuesday";
            this.WorkTuesday.Size = new System.Drawing.Size(46, 17);
            this.WorkTuesday.TabIndex = 2;
            this.WorkTuesday.Text = "Tue";
            this.WorkTuesday.CheckedChanged += new System.EventHandler(this.Workday_CheckedChanged);
            // 
            // WorkWednesday
            // 
            this.WorkWednesday.AutoSize = true;
            this.WorkWednesday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WorkWednesday.Location = new System.Drawing.Point(138, 206);
            this.WorkWednesday.Name = "WorkWednesday";
            this.WorkWednesday.Size = new System.Drawing.Size(50, 17);
            this.WorkWednesday.TabIndex = 3;
            this.WorkWednesday.Text = "Wed";
            this.WorkWednesday.CheckedChanged += new System.EventHandler(this.Workday_CheckedChanged);
            // 
            // WorkThursday
            // 
            this.WorkThursday.AutoSize = true;
            this.WorkThursday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WorkThursday.Location = new System.Drawing.Point(203, 206);
            this.WorkThursday.Name = "WorkThursday";
            this.WorkThursday.Size = new System.Drawing.Size(47, 17);
            this.WorkThursday.TabIndex = 4;
            this.WorkThursday.Text = "Thu";
            this.WorkThursday.CheckedChanged += new System.EventHandler(this.Workday_CheckedChanged);
            // 
            // WorkFriday
            // 
            this.WorkFriday.AutoSize = true;
            this.WorkFriday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WorkFriday.Location = new System.Drawing.Point(265, 206);
            this.WorkFriday.Name = "WorkFriday";
            this.WorkFriday.Size = new System.Drawing.Size(40, 17);
            this.WorkFriday.TabIndex = 5;
            this.WorkFriday.Text = "Fri";
            this.WorkFriday.CheckedChanged += new System.EventHandler(this.Workday_CheckedChanged);
            // 
            // WorkSaturday
            // 
            this.WorkSaturday.AutoSize = true;
            this.WorkSaturday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WorkSaturday.Location = new System.Drawing.Point(320, 206);
            this.WorkSaturday.Name = "WorkSaturday";
            this.WorkSaturday.Size = new System.Drawing.Size(45, 17);
            this.WorkSaturday.TabIndex = 6;
            this.WorkSaturday.Text = "Sat";
            this.WorkSaturday.CheckedChanged += new System.EventHandler(this.Workday_CheckedChanged);
            // 
            // WorkSunday
            // 
            this.WorkSunday.AutoSize = true;
            this.WorkSunday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WorkSunday.Location = new System.Drawing.Point(380, 206);
            this.WorkSunday.Name = "WorkSunday";
            this.WorkSunday.Size = new System.Drawing.Size(48, 17);
            this.WorkSunday.TabIndex = 7;
            this.WorkSunday.Text = "Sun";
            this.WorkSunday.CheckedChanged += new System.EventHandler(this.Workday_CheckedChanged);
            // 
            // gbHWMotives
            // 
            this.gbHWMotives.Controls.Add(this.label27);
            this.gbHWMotives.Controls.Add(this.label24);
            this.gbHWMotives.Controls.Add(this.ComfortHours);
            this.gbHWMotives.Controls.Add(this.HygieneTotal);
            this.gbHWMotives.Controls.Add(this.BladderTotal);
            this.gbHWMotives.Controls.Add(this.label21);
            this.gbHWMotives.Controls.Add(this.WorkBladder);
            this.gbHWMotives.Controls.Add(this.label23);
            this.gbHWMotives.Controls.Add(this.label19);
            this.gbHWMotives.Controls.Add(this.WorkComfort);
            this.gbHWMotives.Controls.Add(this.HungerHours);
            this.gbHWMotives.Controls.Add(this.EnergyHours);
            this.gbHWMotives.Controls.Add(this.label25);
            this.gbHWMotives.Controls.Add(this.WorkPublic);
            this.gbHWMotives.Controls.Add(this.WorkHunger);
            this.gbHWMotives.Controls.Add(this.BladderHours);
            this.gbHWMotives.Controls.Add(this.ComfortTotal);
            this.gbHWMotives.Controls.Add(this.label22);
            this.gbHWMotives.Controls.Add(this.HungerTotal);
            this.gbHWMotives.Controls.Add(this.HygieneHours);
            this.gbHWMotives.Controls.Add(this.WorkEnergy);
            this.gbHWMotives.Controls.Add(this.WorkFun);
            this.gbHWMotives.Controls.Add(this.WorkSunshine);
            this.gbHWMotives.Controls.Add(this.PublicHours);
            this.gbHWMotives.Controls.Add(this.label20);
            this.gbHWMotives.Controls.Add(this.SunshineTotal);
            this.gbHWMotives.Controls.Add(this.EnergyTotal);
            this.gbHWMotives.Controls.Add(this.FunTotal);
            this.gbHWMotives.Controls.Add(this.PublicTotal);
            this.gbHWMotives.Controls.Add(this.label33);
            this.gbHWMotives.Controls.Add(this.label32);
            this.gbHWMotives.Controls.Add(this.label31);
            this.gbHWMotives.Controls.Add(this.label30);
            this.gbHWMotives.Controls.Add(this.label28);
            this.gbHWMotives.Controls.Add(this.label26);
            this.gbHWMotives.Controls.Add(this.FunHours);
            this.gbHWMotives.Controls.Add(this.WorkHygiene);
            this.gbHWMotives.Controls.Add(this.SunshineHours);
            this.gbHWMotives.Location = new System.Drawing.Point(453, 20);
            this.gbHWMotives.Name = "gbHWMotives";
            this.gbHWMotives.Size = new System.Drawing.Size(594, 174);
            this.gbHWMotives.TabIndex = 4;
            this.gbHWMotives.TabStop = false;
            this.gbHWMotives.Text = "Motives";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(432, 14);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(75, 13);
            this.label27.TabIndex = 64;
            this.label27.Text = "times Hours";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(129, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(75, 13);
            this.label24.TabIndex = 41;
            this.label24.Text = "times Hours";
            // 
            // ComfortHours
            // 
            this.ComfortHours.AutoSize = true;
            this.ComfortHours.Enabled = false;
            this.ComfortHours.Location = new System.Drawing.Point(142, 61);
            this.ComfortHours.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ComfortHours.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.ComfortHours.Name = "ComfortHours";
            this.ComfortHours.ReadOnly = true;
            this.ComfortHours.Size = new System.Drawing.Size(60, 21);
            this.ComfortHours.TabIndex = 0;
            this.ComfortHours.TabStop = false;
            // 
            // HygieneTotal
            // 
            this.HygieneTotal.AutoSize = true;
            this.HygieneTotal.Enabled = false;
            this.HygieneTotal.Location = new System.Drawing.Point(208, 89);
            this.HygieneTotal.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.HygieneTotal.Minimum = new decimal(new int[] {
            20000,
            0,
            0,
            -2147483648});
            this.HygieneTotal.Name = "HygieneTotal";
            this.HygieneTotal.ReadOnly = true;
            this.HygieneTotal.Size = new System.Drawing.Size(68, 21);
            this.HygieneTotal.TabIndex = 0;
            this.HygieneTotal.TabStop = false;
            // 
            // BladderTotal
            // 
            this.BladderTotal.AutoSize = true;
            this.BladderTotal.Enabled = false;
            this.BladderTotal.Location = new System.Drawing.Point(208, 116);
            this.BladderTotal.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.BladderTotal.Minimum = new decimal(new int[] {
            20000,
            0,
            0,
            -2147483648});
            this.BladderTotal.Name = "BladderTotal";
            this.BladderTotal.ReadOnly = true;
            this.BladderTotal.Size = new System.Drawing.Size(68, 21);
            this.BladderTotal.TabIndex = 0;
            this.BladderTotal.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 93);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 7;
            this.label21.Text = "Hygiene";
            // 
            // WorkBladder
            // 
            this.WorkBladder.AutoSize = true;
            this.WorkBladder.Location = new System.Drawing.Point(75, 116);
            this.WorkBladder.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WorkBladder.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.WorkBladder.Name = "WorkBladder";
            this.WorkBladder.Size = new System.Drawing.Size(60, 21);
            this.WorkBladder.TabIndex = 10;
            this.WorkBladder.ValueChanged += new System.EventHandler(this.nudMotive_ValueChanged);
            this.WorkBladder.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudMotive_KeyUp);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(72, 14);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 13);
            this.label23.TabIndex = 40;
            this.label23.Text = "PerHour";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Hunger";
            // 
            // WorkComfort
            // 
            this.WorkComfort.AutoSize = true;
            this.WorkComfort.Location = new System.Drawing.Point(75, 61);
            this.WorkComfort.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WorkComfort.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.WorkComfort.Name = "WorkComfort";
            this.WorkComfort.Size = new System.Drawing.Size(60, 21);
            this.WorkComfort.TabIndex = 6;
            this.WorkComfort.ValueChanged += new System.EventHandler(this.nudMotive_ValueChanged);
            this.WorkComfort.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudMotive_KeyUp);
            // 
            // HungerHours
            // 
            this.HungerHours.AutoSize = true;
            this.HungerHours.Enabled = false;
            this.HungerHours.Location = new System.Drawing.Point(142, 34);
            this.HungerHours.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.HungerHours.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.HungerHours.Name = "HungerHours";
            this.HungerHours.ReadOnly = true;
            this.HungerHours.Size = new System.Drawing.Size(60, 21);
            this.HungerHours.TabIndex = 0;
            this.HungerHours.TabStop = false;
            // 
            // EnergyHours
            // 
            this.EnergyHours.AutoSize = true;
            this.EnergyHours.Enabled = false;
            this.EnergyHours.Location = new System.Drawing.Point(445, 34);
            this.EnergyHours.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.EnergyHours.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.EnergyHours.Name = "EnergyHours";
            this.EnergyHours.ReadOnly = true;
            this.EnergyHours.Size = new System.Drawing.Size(60, 21);
            this.EnergyHours.TabIndex = 0;
            this.EnergyHours.TabStop = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(205, 14);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 13);
            this.label25.TabIndex = 42;
            this.label25.Text = "= Total";
            // 
            // WorkPublic
            // 
            this.WorkPublic.AutoSize = true;
            this.WorkPublic.Location = new System.Drawing.Point(378, 89);
            this.WorkPublic.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WorkPublic.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.WorkPublic.Name = "WorkPublic";
            this.WorkPublic.Size = new System.Drawing.Size(60, 21);
            this.WorkPublic.TabIndex = 16;
            this.WorkPublic.ValueChanged += new System.EventHandler(this.nudMotive_ValueChanged);
            this.WorkPublic.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudMotive_KeyUp);
            // 
            // WorkHunger
            // 
            this.WorkHunger.AutoSize = true;
            this.WorkHunger.Location = new System.Drawing.Point(75, 34);
            this.WorkHunger.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WorkHunger.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.WorkHunger.Name = "WorkHunger";
            this.WorkHunger.Size = new System.Drawing.Size(60, 21);
            this.WorkHunger.TabIndex = 2;
            this.WorkHunger.ValueChanged += new System.EventHandler(this.nudMotive_ValueChanged);
            this.WorkHunger.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudMotive_KeyUp);
            // 
            // BladderHours
            // 
            this.BladderHours.AutoSize = true;
            this.BladderHours.Enabled = false;
            this.BladderHours.Location = new System.Drawing.Point(142, 116);
            this.BladderHours.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.BladderHours.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.BladderHours.Name = "BladderHours";
            this.BladderHours.ReadOnly = true;
            this.BladderHours.Size = new System.Drawing.Size(60, 21);
            this.BladderHours.TabIndex = 0;
            this.BladderHours.TabStop = false;
            // 
            // ComfortTotal
            // 
            this.ComfortTotal.AutoSize = true;
            this.ComfortTotal.Enabled = false;
            this.ComfortTotal.Location = new System.Drawing.Point(208, 62);
            this.ComfortTotal.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.ComfortTotal.Minimum = new decimal(new int[] {
            20000,
            0,
            0,
            -2147483648});
            this.ComfortTotal.Name = "ComfortTotal";
            this.ComfortTotal.ReadOnly = true;
            this.ComfortTotal.Size = new System.Drawing.Size(68, 21);
            this.ComfortTotal.TabIndex = 0;
            this.ComfortTotal.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 120);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 13);
            this.label22.TabIndex = 9;
            this.label22.Text = "Bladder";
            // 
            // HungerTotal
            // 
            this.HungerTotal.AutoSize = true;
            this.HungerTotal.Enabled = false;
            this.HungerTotal.Location = new System.Drawing.Point(208, 34);
            this.HungerTotal.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.HungerTotal.Minimum = new decimal(new int[] {
            20000,
            0,
            0,
            -2147483648});
            this.HungerTotal.Name = "HungerTotal";
            this.HungerTotal.ReadOnly = true;
            this.HungerTotal.Size = new System.Drawing.Size(68, 21);
            this.HungerTotal.TabIndex = 0;
            this.HungerTotal.TabStop = false;
            // 
            // HygieneHours
            // 
            this.HygieneHours.AutoSize = true;
            this.HygieneHours.Enabled = false;
            this.HygieneHours.Location = new System.Drawing.Point(142, 89);
            this.HygieneHours.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.HygieneHours.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.HygieneHours.Name = "HygieneHours";
            this.HygieneHours.ReadOnly = true;
            this.HygieneHours.Size = new System.Drawing.Size(60, 21);
            this.HygieneHours.TabIndex = 0;
            this.HygieneHours.TabStop = false;
            // 
            // WorkEnergy
            // 
            this.WorkEnergy.AutoSize = true;
            this.WorkEnergy.Location = new System.Drawing.Point(378, 34);
            this.WorkEnergy.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WorkEnergy.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.WorkEnergy.Name = "WorkEnergy";
            this.WorkEnergy.Size = new System.Drawing.Size(60, 21);
            this.WorkEnergy.TabIndex = 12;
            this.WorkEnergy.ValueChanged += new System.EventHandler(this.nudMotive_ValueChanged);
            this.WorkEnergy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudMotive_KeyUp);
            // 
            // WorkFun
            // 
            this.WorkFun.AutoSize = true;
            this.WorkFun.Location = new System.Drawing.Point(378, 61);
            this.WorkFun.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WorkFun.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.WorkFun.Name = "WorkFun";
            this.WorkFun.Size = new System.Drawing.Size(60, 21);
            this.WorkFun.TabIndex = 14;
            this.WorkFun.ValueChanged += new System.EventHandler(this.nudMotive_ValueChanged);
            this.WorkFun.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudMotive_KeyUp);
            // 
            // WorkSunshine
            // 
            this.WorkSunshine.AutoSize = true;
            this.WorkSunshine.Location = new System.Drawing.Point(378, 116);
            this.WorkSunshine.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WorkSunshine.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.WorkSunshine.Name = "WorkSunshine";
            this.WorkSunshine.Size = new System.Drawing.Size(60, 21);
            this.WorkSunshine.TabIndex = 18;
            this.WorkSunshine.ValueChanged += new System.EventHandler(this.nudMotive_ValueChanged);
            this.WorkSunshine.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudMotive_KeyUp);
            // 
            // PublicHours
            // 
            this.PublicHours.AutoSize = true;
            this.PublicHours.Enabled = false;
            this.PublicHours.Location = new System.Drawing.Point(445, 89);
            this.PublicHours.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PublicHours.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.PublicHours.Name = "PublicHours";
            this.PublicHours.ReadOnly = true;
            this.PublicHours.Size = new System.Drawing.Size(60, 21);
            this.PublicHours.TabIndex = 0;
            this.PublicHours.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 65);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 13);
            this.label20.TabIndex = 5;
            this.label20.Text = "Comfort";
            // 
            // SunshineTotal
            // 
            this.SunshineTotal.AutoSize = true;
            this.SunshineTotal.Enabled = false;
            this.SunshineTotal.Location = new System.Drawing.Point(512, 116);
            this.SunshineTotal.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.SunshineTotal.Minimum = new decimal(new int[] {
            20000,
            0,
            0,
            -2147483648});
            this.SunshineTotal.Name = "SunshineTotal";
            this.SunshineTotal.ReadOnly = true;
            this.SunshineTotal.Size = new System.Drawing.Size(68, 21);
            this.SunshineTotal.TabIndex = 0;
            this.SunshineTotal.TabStop = false;
            // 
            // EnergyTotal
            // 
            this.EnergyTotal.AutoSize = true;
            this.EnergyTotal.Enabled = false;
            this.EnergyTotal.Location = new System.Drawing.Point(512, 34);
            this.EnergyTotal.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.EnergyTotal.Minimum = new decimal(new int[] {
            20000,
            0,
            0,
            -2147483648});
            this.EnergyTotal.Name = "EnergyTotal";
            this.EnergyTotal.ReadOnly = true;
            this.EnergyTotal.Size = new System.Drawing.Size(68, 21);
            this.EnergyTotal.TabIndex = 0;
            this.EnergyTotal.TabStop = false;
            // 
            // FunTotal
            // 
            this.FunTotal.AutoSize = true;
            this.FunTotal.Enabled = false;
            this.FunTotal.Location = new System.Drawing.Point(512, 61);
            this.FunTotal.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.FunTotal.Minimum = new decimal(new int[] {
            20000,
            0,
            0,
            -2147483648});
            this.FunTotal.Name = "FunTotal";
            this.FunTotal.ReadOnly = true;
            this.FunTotal.Size = new System.Drawing.Size(68, 21);
            this.FunTotal.TabIndex = 0;
            this.FunTotal.TabStop = false;
            // 
            // PublicTotal
            // 
            this.PublicTotal.AutoSize = true;
            this.PublicTotal.Enabled = false;
            this.PublicTotal.Location = new System.Drawing.Point(512, 89);
            this.PublicTotal.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.PublicTotal.Minimum = new decimal(new int[] {
            20000,
            0,
            0,
            -2147483648});
            this.PublicTotal.Name = "PublicTotal";
            this.PublicTotal.ReadOnly = true;
            this.PublicTotal.Size = new System.Drawing.Size(68, 21);
            this.PublicTotal.TabIndex = 0;
            this.PublicTotal.TabStop = false;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(312, 65);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(27, 13);
            this.label33.TabIndex = 13;
            this.label33.Text = "Fun";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(312, 38);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(47, 13);
            this.label32.TabIndex = 11;
            this.label32.Text = "Energy";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(312, 93);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(41, 13);
            this.label31.TabIndex = 15;
            this.label31.Text = "Social";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(312, 120);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(59, 13);
            this.label30.TabIndex = 17;
            this.label30.Text = "Sunshine";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(375, 14);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 13);
            this.label28.TabIndex = 63;
            this.label28.Text = "PerHour";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(509, 14);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 13);
            this.label26.TabIndex = 65;
            this.label26.Text = "= Total";
            // 
            // FunHours
            // 
            this.FunHours.AutoSize = true;
            this.FunHours.Enabled = false;
            this.FunHours.Location = new System.Drawing.Point(445, 61);
            this.FunHours.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.FunHours.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.FunHours.Name = "FunHours";
            this.FunHours.ReadOnly = true;
            this.FunHours.Size = new System.Drawing.Size(60, 21);
            this.FunHours.TabIndex = 0;
            this.FunHours.TabStop = false;
            // 
            // WorkHygiene
            // 
            this.WorkHygiene.AutoSize = true;
            this.WorkHygiene.Location = new System.Drawing.Point(75, 89);
            this.WorkHygiene.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WorkHygiene.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.WorkHygiene.Name = "WorkHygiene";
            this.WorkHygiene.Size = new System.Drawing.Size(60, 21);
            this.WorkHygiene.TabIndex = 8;
            this.WorkHygiene.ValueChanged += new System.EventHandler(this.nudMotive_ValueChanged);
            this.WorkHygiene.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudMotive_KeyUp);
            // 
            // SunshineHours
            // 
            this.SunshineHours.AutoSize = true;
            this.SunshineHours.Enabled = false;
            this.SunshineHours.Location = new System.Drawing.Point(445, 116);
            this.SunshineHours.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SunshineHours.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.SunshineHours.Name = "SunshineHours";
            this.SunshineHours.ReadOnly = true;
            this.SunshineHours.Size = new System.Drawing.Size(60, 21);
            this.SunshineHours.TabIndex = 0;
            this.SunshineHours.TabStop = false;
            // 
            // lbLscore
            // 
            this.lbLscore.AutoSize = true;
            this.lbLscore.Location = new System.Drawing.Point(790, 207);
            this.lbLscore.Name = "lbLscore";
            this.lbLscore.Size = new System.Drawing.Size(64, 13);
            this.lbLscore.TabIndex = 3;
            this.lbLscore.Text = "Life Score";
            this.lbLscore.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numLscore
            // 
            this.numLscore.AutoSize = true;
            this.numLscore.Location = new System.Drawing.Point(860, 204);
            this.numLscore.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numLscore.Name = "numLscore";
            this.numLscore.Size = new System.Drawing.Size(60, 21);
            this.numLscore.TabIndex = 5;
            this.numLscore.ValueChanged += new System.EventHandler(this.numLscore_ValueChanged);
            // 
            // numPTO
            // 
            this.numPTO.AutoSize = true;
            this.numPTO.Location = new System.Drawing.Point(694, 204);
            this.numPTO.Name = "numPTO";
            this.numPTO.Size = new System.Drawing.Size(60, 21);
            this.numPTO.TabIndex = 6;
            this.toolTip1.SetToolTip(this.numPTO, "It takes 100 of these points for\r\none day off.");
            this.numPTO.ValueChanged += new System.EventHandler(this.numPTO_ValueChanged);
            // 
            // gbJLHoursWages
            // 
            this.gbJLHoursWages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbJLHoursWages.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbJLHoursWages.BackColor = System.Drawing.Color.Transparent;
            this.gbJLHoursWages.Controls.Add(this.HoursWagesList);
            this.gbJLHoursWages.Location = new System.Drawing.Point(10, 6);
            this.gbJLHoursWages.Name = "gbJLHoursWages";
            this.gbJLHoursWages.Size = new System.Drawing.Size(1069, 262);
            this.gbJLHoursWages.TabIndex = 1;
            this.gbJLHoursWages.TabStop = false;
            this.gbJLHoursWages.Text = "Job Levels";
            // 
            // HoursWagesList
            // 
            this.HoursWagesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HoursWagesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HwLvl,
            this.HwStart,
            this.HwHours,
            this.HwEnd,
            this.HwWages,
            this.HwDogWages,
            this.HwCatWages,
            this.HwMon,
            this.HwTue,
            this.HwWed,
            this.HwThu,
            this.HwFri,
            this.HwSat,
            this.HwSun});
            this.HoursWagesList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoursWagesList.FullRowSelect = true;
            this.HoursWagesList.GridLines = true;
            this.HoursWagesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.HoursWagesList.HideSelection = false;
            this.HoursWagesList.Location = new System.Drawing.Point(10, 18);
            this.HoursWagesList.MultiSelect = false;
            this.HoursWagesList.Name = "HoursWagesList";
            this.HoursWagesList.Size = new System.Drawing.Size(1048, 232);
            this.HoursWagesList.TabIndex = 1;
            this.HoursWagesList.UseCompatibleStateImageBehavior = false;
            this.HoursWagesList.View = System.Windows.Forms.View.Details;
            this.HoursWagesList.SelectedIndexChanged += new System.EventHandler(this.HoursWagesList_SelectedIndexChanged);
            // 
            // HwLvl
            // 
            this.HwLvl.Text = "Lvl";
            this.HwLvl.Width = 49;
            // 
            // HwStart
            // 
            this.HwStart.Text = "Start";
            this.HwStart.Width = 74;
            // 
            // HwHours
            // 
            this.HwHours.Text = "Hours";
            this.HwHours.Width = 77;
            // 
            // HwEnd
            // 
            this.HwEnd.Text = "End";
            this.HwEnd.Width = 73;
            // 
            // HwWages
            // 
            this.HwWages.Text = "Wages";
            this.HwWages.Width = 75;
            // 
            // HwDogWages
            // 
            this.HwDogWages.Text = "Wages (Dog)";
            this.HwDogWages.Width = 106;
            // 
            // HwCatWages
            // 
            this.HwCatWages.Text = "Wages (Cat)";
            this.HwCatWages.Width = 106;
            // 
            // HwMon
            // 
            this.HwMon.Text = "Mon";
            this.HwMon.Width = 63;
            // 
            // HwTue
            // 
            this.HwTue.Text = "Tue";
            this.HwTue.Width = 62;
            // 
            // HwWed
            // 
            this.HwWed.Text = "Wed";
            this.HwWed.Width = 63;
            // 
            // HwThu
            // 
            this.HwThu.Text = "Thu";
            this.HwThu.Width = 63;
            // 
            // HwFri
            // 
            this.HwFri.Text = "Fri";
            this.HwFri.Width = 62;
            // 
            // HwSat
            // 
            this.HwSat.Text = "Sat";
            this.HwSat.Width = 62;
            // 
            // HwSun
            // 
            this.HwSun.Text = "Sun";
            this.HwSun.Width = 56;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPagMajor);
            this.tabControl1.ItemSize = new System.Drawing.Size(64, 18);
            this.tabControl1.Location = new System.Drawing.Point(1, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1100, 560);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.gbJobDetails);
            this.tabPage1.Controls.Add(this.gbJLDetails);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1092, 534);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Job Details";
            // 
            // gbJobDetails
            // 
            this.gbJobDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbJobDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbJobDetails.BackColor = System.Drawing.Color.Transparent;
            this.gbJobDetails.Controls.Add(this.gcVehicle);
            this.gbJobDetails.Controls.Add(this.gcOutfit);
            this.gbJobDetails.Controls.Add(this.JobDetailsCopy);
            this.gbJobDetails.Controls.Add(this.jdpFemale);
            this.gbJobDetails.Controls.Add(this.jdpMale);
            this.gbJobDetails.Location = new System.Drawing.Point(10, 285);
            this.gbJobDetails.Name = "gbJobDetails";
            this.gbJobDetails.Size = new System.Drawing.Size(1069, 240);
            this.gbJobDetails.TabIndex = 2;
            this.gbJobDetails.TabStop = false;
            this.gbJobDetails.Text = "Current Level";
            // 
            // gcVehicle
            // 
            this.gcVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gcVehicle.AutoSize = true;
            this.gcVehicle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gcVehicle.ComboBoxWidth = 300;
            this.gcVehicle.DropDownHeight = 250;
            this.gcVehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.gcVehicle.DropDownWidth = 300;
            this.gcVehicle.Label = "Vehicle";
            this.gcVehicle.Location = new System.Drawing.Point(620, 208);
            this.gcVehicle.Margin = new System.Windows.Forms.Padding(0);
            this.gcVehicle.Name = "gcVehicle";
            this.gcVehicle.Size = new System.Drawing.Size(442, 21);
            this.gcVehicle.TabIndex = 5;
            this.gcVehicle.Value = ((uint)(3722304989u));
            this.gcVehicle.GUIDChooserValueChanged += new System.EventHandler(this.gcVehicle_GUIDChooserValueChanged);
            // 
            // gcOutfit
            // 
            this.gcOutfit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gcOutfit.AutoSize = true;
            this.gcOutfit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gcOutfit.ComboBoxWidth = 300;
            this.gcOutfit.DropDownHeight = 250;
            this.gcOutfit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.gcOutfit.DropDownWidth = 300;
            this.gcOutfit.Label = "Outfit";
            this.gcOutfit.Location = new System.Drawing.Point(81, 208);
            this.gcOutfit.Margin = new System.Windows.Forms.Padding(0);
            this.gcOutfit.Name = "gcOutfit";
            this.gcOutfit.Size = new System.Drawing.Size(433, 21);
            this.gcOutfit.TabIndex = 4;
            this.gcOutfit.Value = ((uint)(3722304989u));
            this.gcOutfit.GUIDChooserValueChanged += new System.EventHandler(this.gcOutfit_GUIDChooserValueChanged);
            // 
            // JobDetailsCopy
            // 
            this.JobDetailsCopy.AutoSize = true;
            this.JobDetailsCopy.Location = new System.Drawing.Point(584, 100);
            this.JobDetailsCopy.Name = "JobDetailsCopy";
            this.JobDetailsCopy.Size = new System.Drawing.Size(50, 13);
            this.JobDetailsCopy.TabIndex = 3;
            this.JobDetailsCopy.TabStop = true;
            this.JobDetailsCopy.Text = "Copy >";
            this.JobDetailsCopy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.JobDetailsCopy_LinkClicked);
            // 
            // jdpFemale
            // 
            this.jdpFemale.AutoSize = true;
            this.jdpFemale.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.jdpFemale.BackColor = System.Drawing.Color.Transparent;
            this.jdpFemale.DescLabel = "Desc Female";
            this.jdpFemale.DescValue = "JobDescFemale";
            this.jdpFemale.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jdpFemale.Location = new System.Drawing.Point(2, 18);
            this.jdpFemale.Margin = new System.Windows.Forms.Padding(2);
            this.jdpFemale.Name = "jdpFemale";
            this.jdpFemale.Size = new System.Drawing.Size(573, 181);
            this.jdpFemale.TabIndex = 2;
            this.jdpFemale.TitleLabel = "Title Female";
            this.jdpFemale.TitleValue = "JobTitleFemale";
            this.jdpFemale.TitleValueChanged += new System.EventHandler(this.jdpFemale_TitleValueChanged);
            this.jdpFemale.DescValueChanged += new System.EventHandler(this.jdpFemale_DescValueChanged);
            // 
            // jdpMale
            // 
            this.jdpMale.AutoSize = true;
            this.jdpMale.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.jdpMale.BackColor = System.Drawing.Color.Transparent;
            this.jdpMale.DescLabel = "Desc Male";
            this.jdpMale.DescValue = "JobDescMale";
            this.jdpMale.Location = new System.Drawing.Point(561, 18);
            this.jdpMale.Margin = new System.Windows.Forms.Padding(2);
            this.jdpMale.Name = "jdpMale";
            this.jdpMale.Size = new System.Drawing.Size(505, 179);
            this.jdpMale.TabIndex = 1;
            this.jdpMale.TitleLabel = "Title Male";
            this.jdpMale.TitleValue = "JobTitleMale";
            this.jdpMale.TitleValueChanged += new System.EventHandler(this.jdpMale_TitleValueChanged);
            this.jdpMale.DescValueChanged += new System.EventHandler(this.jdpMale_DescValueChanged);
            // 
            // gbJLDetails
            // 
            this.gbJLDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbJLDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbJLDetails.BackColor = System.Drawing.Color.Transparent;
            this.gbJLDetails.Controls.Add(this.JobDetailList);
            this.gbJLDetails.Location = new System.Drawing.Point(10, 6);
            this.gbJLDetails.Name = "gbJLDetails";
            this.gbJLDetails.Size = new System.Drawing.Size(1069, 262);
            this.gbJLDetails.TabIndex = 1;
            this.gbJLDetails.TabStop = false;
            this.gbJLDetails.Text = "Job Levels";
            // 
            // JobDetailList
            // 
            this.JobDetailList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.JobDetailList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.JdLvl,
            this.JdJobTitle,
            this.JdDesc,
            this.JdOutfit,
            this.JdVehicle});
            this.JobDetailList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JobDetailList.FullRowSelect = true;
            this.JobDetailList.GridLines = true;
            this.JobDetailList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.JobDetailList.HideSelection = false;
            this.JobDetailList.Location = new System.Drawing.Point(10, 18);
            this.JobDetailList.MultiSelect = false;
            this.JobDetailList.Name = "JobDetailList";
            this.JobDetailList.Size = new System.Drawing.Size(1056, 232);
            this.JobDetailList.TabIndex = 1;
            this.JobDetailList.UseCompatibleStateImageBehavior = false;
            this.JobDetailList.View = System.Windows.Forms.View.Details;
            this.JobDetailList.SelectedIndexChanged += new System.EventHandler(this.JobDetailList_SelectedIndexChanged);
            // 
            // JdLvl
            // 
            this.JdLvl.Text = "Lvl";
            this.JdLvl.Width = 43;
            // 
            // JdJobTitle
            // 
            this.JdJobTitle.Text = "Job Title (female)";
            this.JdJobTitle.Width = 205;
            // 
            // JdDesc
            // 
            this.JdDesc.Text = "Job Description (female)";
            this.JdDesc.Width = 473;
            // 
            // JdOutfit
            // 
            this.JdOutfit.Text = "Outfit";
            this.JdOutfit.Width = 160;
            // 
            // JdVehicle
            // 
            this.JdVehicle.Text = "Vehicle";
            this.JdVehicle.Width = 160;
            // 
            // tabPagMajor
            // 
            this.tabPagMajor.Location = new System.Drawing.Point(4, 22);
            this.tabPagMajor.Name = "tabPagMajor";
            this.tabPagMajor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagMajor.Size = new System.Drawing.Size(1092, 534);
            this.tabPagMajor.TabIndex = 5;
            this.tabPagMajor.Text = "Majors";
            this.tabPagMajor.UseVisualStyleBackColor = true;
            // 
            // btmajApply
            // 
            this.btmajApply.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmajApply.Location = new System.Drawing.Point(972, 12);
            this.btmajApply.Name = "btmajApply";
            this.btmajApply.Size = new System.Drawing.Size(87, 23);
            this.btmajApply.TabIndex = 2;
            this.btmajApply.Text = "Apply";
            this.btmajApply.UseVisualStyleBackColor = true;
            this.btmajApply.Click += new System.EventHandler(this.btmajApply_Click);
            // 
            // gbmajaffil
            // 
            this.gbmajaffil.Controls.Add(this.label47);
            this.gbmajaffil.Controls.Add(this.cbaphyco);
            this.gbmajaffil.Controls.Add(this.cbapolit);
            this.gbmajaffil.Controls.Add(this.cbaphysi);
            this.gbmajaffil.Controls.Add(this.cbrahilo);
            this.gbmajaffil.Controls.Add(this.cbamaths);
            this.gbmajaffil.Controls.Add(this.cbaliter);
            this.gbmajaffil.Controls.Add(this.cbahisto);
            this.gbmajaffil.Controls.Add(this.cbaecon);
            this.gbmajaffil.Controls.Add(this.cbadrama);
            this.gbmajaffil.Controls.Add(this.cbabiol);
            this.gbmajaffil.Controls.Add(this.cbaArt);
            this.gbmajaffil.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbmajaffil.Location = new System.Drawing.Point(596, 27);
            this.gbmajaffil.Name = "gbmajaffil";
            this.gbmajaffil.Size = new System.Drawing.Size(341, 449);
            this.gbmajaffil.TabIndex = 1;
            this.gbmajaffil.TabStop = false;
            this.gbmajaffil.Text = "Majors Affiliated";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(8, 37);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(317, 32);
            this.label47.TabIndex = 22;
            this.label47.Text = "A sim that has graduated one of these majors\r\nwiil get a level boost when startin" +
                "g this career";
            // 
            // cbaphyco
            // 
            this.cbaphyco.AutoSize = true;
            this.cbaphyco.Location = new System.Drawing.Point(27, 408);
            this.cbaphyco.Name = "cbaphyco";
            this.cbaphyco.Size = new System.Drawing.Size(110, 20);
            this.cbaphyco.TabIndex = 21;
            this.cbaphyco.Text = "Psychology";
            this.cbaphyco.UseVisualStyleBackColor = true;
            // 
            // cbapolit
            // 
            this.cbapolit.AutoSize = true;
            this.cbapolit.Location = new System.Drawing.Point(27, 376);
            this.cbapolit.Name = "cbapolit";
            this.cbapolit.Size = new System.Drawing.Size(79, 20);
            this.cbapolit.TabIndex = 20;
            this.cbapolit.Text = "Politics";
            this.cbapolit.UseVisualStyleBackColor = true;
            // 
            // cbaphysi
            // 
            this.cbaphysi.AutoSize = true;
            this.cbaphysi.Location = new System.Drawing.Point(27, 344);
            this.cbaphysi.Name = "cbaphysi";
            this.cbaphysi.Size = new System.Drawing.Size(82, 20);
            this.cbaphysi.TabIndex = 19;
            this.cbaphysi.Text = "Physics";
            this.cbaphysi.UseVisualStyleBackColor = true;
            // 
            // cbrahilo
            // 
            this.cbrahilo.AutoSize = true;
            this.cbrahilo.Location = new System.Drawing.Point(27, 312);
            this.cbrahilo.Name = "cbrahilo";
            this.cbrahilo.Size = new System.Drawing.Size(106, 20);
            this.cbrahilo.TabIndex = 18;
            this.cbrahilo.Text = "Philosophy";
            this.cbrahilo.UseVisualStyleBackColor = true;
            // 
            // cbamaths
            // 
            this.cbamaths.AutoSize = true;
            this.cbamaths.Location = new System.Drawing.Point(27, 280);
            this.cbamaths.Name = "cbamaths";
            this.cbamaths.Size = new System.Drawing.Size(121, 20);
            this.cbamaths.TabIndex = 17;
            this.cbamaths.Text = "Mathematics";
            this.cbamaths.UseVisualStyleBackColor = true;
            // 
            // cbaliter
            // 
            this.cbaliter.AutoSize = true;
            this.cbaliter.Location = new System.Drawing.Point(27, 248);
            this.cbaliter.Name = "cbaliter";
            this.cbaliter.Size = new System.Drawing.Size(99, 20);
            this.cbaliter.TabIndex = 16;
            this.cbaliter.Text = "Literature";
            this.cbaliter.UseVisualStyleBackColor = true;
            // 
            // cbahisto
            // 
            this.cbahisto.AutoSize = true;
            this.cbahisto.Location = new System.Drawing.Point(27, 216);
            this.cbahisto.Name = "cbahisto";
            this.cbahisto.Size = new System.Drawing.Size(80, 20);
            this.cbahisto.TabIndex = 15;
            this.cbahisto.Text = "History";
            this.cbahisto.UseVisualStyleBackColor = true;
            // 
            // cbaecon
            // 
            this.cbaecon.AutoSize = true;
            this.cbaecon.Location = new System.Drawing.Point(27, 184);
            this.cbaecon.Name = "cbaecon";
            this.cbaecon.Size = new System.Drawing.Size(105, 20);
            this.cbaecon.TabIndex = 14;
            this.cbaecon.Text = "Economics";
            this.cbaecon.UseVisualStyleBackColor = true;
            // 
            // cbadrama
            // 
            this.cbadrama.AutoSize = true;
            this.cbadrama.Location = new System.Drawing.Point(27, 152);
            this.cbadrama.Name = "cbadrama";
            this.cbadrama.Size = new System.Drawing.Size(75, 20);
            this.cbadrama.TabIndex = 13;
            this.cbadrama.Text = "Drama";
            this.cbadrama.UseVisualStyleBackColor = true;
            // 
            // cbabiol
            // 
            this.cbabiol.AutoSize = true;
            this.cbabiol.Location = new System.Drawing.Point(27, 120);
            this.cbabiol.Name = "cbabiol";
            this.cbabiol.Size = new System.Drawing.Size(81, 20);
            this.cbabiol.TabIndex = 12;
            this.cbabiol.Text = "Biology";
            this.cbabiol.UseVisualStyleBackColor = true;
            // 
            // cbaArt
            // 
            this.cbaArt.AutoSize = true;
            this.cbaArt.Location = new System.Drawing.Point(27, 88);
            this.cbaArt.Name = "cbaArt";
            this.cbaArt.Size = new System.Drawing.Size(49, 20);
            this.cbaArt.TabIndex = 11;
            this.cbaArt.Text = "Art";
            this.cbaArt.UseVisualStyleBackColor = true;
            // 
            // gbrequir
            // 
            this.gbrequir.Controls.Add(this.label29);
            this.gbrequir.Controls.Add(this.cbrphyco);
            this.gbrequir.Controls.Add(this.cbrpolit);
            this.gbrequir.Controls.Add(this.cbrphysi);
            this.gbrequir.Controls.Add(this.cbrphilo);
            this.gbrequir.Controls.Add(this.cbrmaths);
            this.gbrequir.Controls.Add(this.cbrliter);
            this.gbrequir.Controls.Add(this.cbrhisto);
            this.gbrequir.Controls.Add(this.cbrecon);
            this.gbrequir.Controls.Add(this.cbrdrama);
            this.gbrequir.Controls.Add(this.cbrbiol);
            this.gbrequir.Controls.Add(this.cbrArt);
            this.gbrequir.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbrequir.Location = new System.Drawing.Point(44, 27);
            this.gbrequir.Name = "gbrequir";
            this.gbrequir.Size = new System.Drawing.Size(341, 449);
            this.gbrequir.TabIndex = 0;
            this.gbrequir.TabStop = false;
            this.gbrequir.Text = "Major Required";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(18, 37);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(307, 32);
            this.label29.TabIndex = 11;
            this.label29.Text = "A sim needs to have graduated from any one\r\nof these majors to be offered this ca" +
                "reer.";
            // 
            // cbrphyco
            // 
            this.cbrphyco.AutoSize = true;
            this.cbrphyco.Location = new System.Drawing.Point(24, 408);
            this.cbrphyco.Name = "cbrphyco";
            this.cbrphyco.Size = new System.Drawing.Size(110, 20);
            this.cbrphyco.TabIndex = 10;
            this.cbrphyco.Text = "Psychology";
            this.cbrphyco.UseVisualStyleBackColor = true;
            // 
            // cbrpolit
            // 
            this.cbrpolit.AutoSize = true;
            this.cbrpolit.Location = new System.Drawing.Point(24, 376);
            this.cbrpolit.Name = "cbrpolit";
            this.cbrpolit.Size = new System.Drawing.Size(79, 20);
            this.cbrpolit.TabIndex = 9;
            this.cbrpolit.Text = "Politics";
            this.cbrpolit.UseVisualStyleBackColor = true;
            // 
            // cbrphysi
            // 
            this.cbrphysi.AutoSize = true;
            this.cbrphysi.Location = new System.Drawing.Point(24, 344);
            this.cbrphysi.Name = "cbrphysi";
            this.cbrphysi.Size = new System.Drawing.Size(82, 20);
            this.cbrphysi.TabIndex = 8;
            this.cbrphysi.Text = "Physics";
            this.cbrphysi.UseVisualStyleBackColor = true;
            // 
            // cbrphilo
            // 
            this.cbrphilo.AutoSize = true;
            this.cbrphilo.Location = new System.Drawing.Point(24, 312);
            this.cbrphilo.Name = "cbrphilo";
            this.cbrphilo.Size = new System.Drawing.Size(106, 20);
            this.cbrphilo.TabIndex = 7;
            this.cbrphilo.Text = "Philosophy";
            this.cbrphilo.UseVisualStyleBackColor = true;
            // 
            // cbrmaths
            // 
            this.cbrmaths.AutoSize = true;
            this.cbrmaths.Location = new System.Drawing.Point(24, 280);
            this.cbrmaths.Name = "cbrmaths";
            this.cbrmaths.Size = new System.Drawing.Size(121, 20);
            this.cbrmaths.TabIndex = 6;
            this.cbrmaths.Text = "Mathematics";
            this.cbrmaths.UseVisualStyleBackColor = true;
            // 
            // cbrliter
            // 
            this.cbrliter.AutoSize = true;
            this.cbrliter.Location = new System.Drawing.Point(24, 248);
            this.cbrliter.Name = "cbrliter";
            this.cbrliter.Size = new System.Drawing.Size(99, 20);
            this.cbrliter.TabIndex = 5;
            this.cbrliter.Text = "Literature";
            this.cbrliter.UseVisualStyleBackColor = true;
            // 
            // cbrhisto
            // 
            this.cbrhisto.AutoSize = true;
            this.cbrhisto.Location = new System.Drawing.Point(24, 216);
            this.cbrhisto.Name = "cbrhisto";
            this.cbrhisto.Size = new System.Drawing.Size(80, 20);
            this.cbrhisto.TabIndex = 4;
            this.cbrhisto.Text = "History";
            this.cbrhisto.UseVisualStyleBackColor = true;
            // 
            // cbrecon
            // 
            this.cbrecon.AutoSize = true;
            this.cbrecon.Location = new System.Drawing.Point(24, 184);
            this.cbrecon.Name = "cbrecon";
            this.cbrecon.Size = new System.Drawing.Size(105, 20);
            this.cbrecon.TabIndex = 3;
            this.cbrecon.Text = "Economics";
            this.cbrecon.UseVisualStyleBackColor = true;
            // 
            // cbrdrama
            // 
            this.cbrdrama.AutoSize = true;
            this.cbrdrama.Location = new System.Drawing.Point(24, 152);
            this.cbrdrama.Name = "cbrdrama";
            this.cbrdrama.Size = new System.Drawing.Size(75, 20);
            this.cbrdrama.TabIndex = 2;
            this.cbrdrama.Text = "Drama";
            this.cbrdrama.UseVisualStyleBackColor = true;
            // 
            // cbrbiol
            // 
            this.cbrbiol.AutoSize = true;
            this.cbrbiol.Location = new System.Drawing.Point(24, 120);
            this.cbrbiol.Name = "cbrbiol";
            this.cbrbiol.Size = new System.Drawing.Size(81, 20);
            this.cbrbiol.TabIndex = 1;
            this.cbrbiol.Text = "Biology";
            this.cbrbiol.UseVisualStyleBackColor = true;
            // 
            // cbrArt
            // 
            this.cbrArt.AutoSize = true;
            this.cbrArt.Location = new System.Drawing.Point(24, 88);
            this.cbrArt.Name = "cbrArt";
            this.cbrArt.Size = new System.Drawing.Size(49, 20);
            this.cbrArt.TabIndex = 0;
            this.cbrArt.Text = "Art";
            this.cbrArt.UseVisualStyleBackColor = true;
            // 
            // btexApply
            // 
            this.btexApply.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btexApply.Location = new System.Drawing.Point(972, 12);
            this.btexApply.Name = "btexApply";
            this.btexApply.Size = new System.Drawing.Size(87, 23);
            this.btexApply.TabIndex = 4;
            this.btexApply.Text = "Apply";
            this.btexApply.UseVisualStyleBackColor = true;
            this.btexApply.Click += new System.EventHandler(this.exApply_Click);
            // 
            // CareerLvls
            // 
            this.CareerLvls.BackColor = System.Drawing.SystemColors.Window;
            this.CareerLvls.Location = new System.Drawing.Point(430, 35);
            this.CareerLvls.Name = "CareerLvls";
            this.CareerLvls.ReadOnly = true;
            this.CareerLvls.Size = new System.Drawing.Size(30, 21);
            this.CareerLvls.TabIndex = 25;
            this.CareerLvls.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(354, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Career Lvls";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CareerTitle
            // 
            this.CareerTitle.Location = new System.Drawing.Point(157, 35);
            this.CareerTitle.Name = "CareerTitle";
            this.CareerTitle.Size = new System.Drawing.Size(181, 21);
            this.CareerTitle.TabIndex = 2;
            this.CareerTitle.TextChanged += new System.EventHandler(this.CareerTitle_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Career Title";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Language
            // 
            this.Language.Location = new System.Drawing.Point(565, 35);
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(188, 21);
            this.Language.TabIndex = 6;
            this.Language.SelectedIndexChanged += new System.EventHandler(this.Language_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(503, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Language";
            // 
            // mainMenu1
            // 
            this.mainMenu1.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem6,
            this.menuItem1});
            this.mainMenu1.Location = new System.Drawing.Point(0, 0);
            this.mainMenu1.Name = "mainMenu1";
            this.mainMenu1.Size = new System.Drawing.Size(1104, 24);
            this.mainMenu1.TabIndex = 0;
            this.mainMenu1.Text = "mainMenu1";
            // 
            // menuItem6
            // 
            this.menuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddLvl,
            this.miRemoveLvl});
            this.menuItem6.Name = "menuItem6";
            this.menuItem6.Size = new System.Drawing.Size(51, 20);
            this.menuItem6.Text = "&Levels";
            // 
            // miAddLvl
            // 
            this.miAddLvl.Name = "miAddLvl";
            this.miAddLvl.Size = new System.Drawing.Size(147, 22);
            this.miAddLvl.Text = "&Add Level";
            this.miAddLvl.Click += new System.EventHandler(this.miAddLvl_Click);
            // 
            // miRemoveLvl
            // 
            this.miRemoveLvl.Name = "miRemoveLvl";
            this.miRemoveLvl.Size = new System.Drawing.Size(147, 22);
            this.miRemoveLvl.Text = "&Remove Level";
            this.miRemoveLvl.Click += new System.EventHandler(this.miRemoveLvl_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEnglishOnly});
            this.menuItem1.Name = "menuItem1";
            this.menuItem1.Size = new System.Drawing.Size(76, 20);
            this.menuItem1.Text = "L&anguages";
            // 
            // miEnglishOnly
            // 
            this.miEnglishOnly.Name = "miEnglishOnly";
            this.miEnglishOnly.Size = new System.Drawing.Size(155, 22);
            this.miEnglishOnly.Text = "US English only";
            this.miEnglishOnly.Click += new System.EventHandler(this.miEnglishOnly_Click);
            // 
            // gcUpgrade
            // 
            this.gcUpgrade.AutoSize = true;
            this.gcUpgrade.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gcUpgrade.ComboBoxWidth = 220;
            this.gcUpgrade.DropDownHeight = 250;
            this.gcUpgrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.gcUpgrade.DropDownWidth = 220;
            this.gcUpgrade.Label = "Upgrade";
            this.gcUpgrade.Location = new System.Drawing.Point(449, 68);
            this.gcUpgrade.Margin = new System.Windows.Forms.Padding(0);
            this.gcUpgrade.Name = "gcUpgrade";
            this.gcUpgrade.Size = new System.Drawing.Size(370, 21);
            this.gcUpgrade.TabIndex = 13;
            this.gcUpgrade.Value = ((uint)(3722304989u));
            // 
            // gcReward
            // 
            this.gcReward.AutoSize = true;
            this.gcReward.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gcReward.ComboBoxWidth = 220;
            this.gcReward.DropDownHeight = 250;
            this.gcReward.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.gcReward.DropDownWidth = 220;
            this.gcReward.Label = "Reward";
            this.gcReward.Location = new System.Drawing.Point(76, 68);
            this.gcReward.Margin = new System.Windows.Forms.Padding(0);
            this.gcReward.Name = "gcReward";
            this.gcReward.Size = new System.Drawing.Size(365, 21);
            this.gcReward.TabIndex = 12;
            this.gcReward.Value = ((uint)(3722304989u));
            // 
            // lbcrap
            // 
            this.lbcrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbcrap.AutoSize = true;
            this.lbcrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcrap.ForeColor = System.Drawing.Color.DarkRed;
            this.lbcrap.Location = new System.Drawing.Point(823, 62);
            this.lbcrap.Name = "lbcrap";
            this.lbcrap.Size = new System.Drawing.Size(274, 30);
            this.lbcrap.TabIndex = 14;
            this.lbcrap.Text = "Old Career Type!\r\nNot compatible with Seasons EP or above";
            this.lbcrap.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbcrap.Visible = false;
            // 
            // btUgrade
            // 
            this.btUgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUgrade.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUgrade.Location = new System.Drawing.Point(936, 30);
            this.btUgrade.Name = "btUgrade";
            this.btUgrade.Size = new System.Drawing.Size(162, 23);
            this.btUgrade.TabIndex = 24;
            this.btUgrade.Text = "Upgrade to Latest EP";
            this.btUgrade.UseVisualStyleBackColor = true;
            this.btUgrade.Visible = false;
            this.btUgrade.Click += new System.EventHandler(this.btUgrade_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Note";
            // 
            // CareerEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1104, 661);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(1120, 700);
            this.Name = "CareerEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Career Editor (by Bidou)";
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tcChanceOutcome.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.gbJLPromo.ResumeLayout(false);
            this.gbPromo.ResumeLayout(false);
            this.gbPromo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PromoFriends)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoCleaning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoLogic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoCreativity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoCharisma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoBody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoMechanical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PromoCooking)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.gbHoursWages.ResumeLayout(false);
            this.gbHoursWages.PerformLayout();
            this.gbHWMotives.ResumeLayout(false);
            this.gbHWMotives.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComfortHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HygieneTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BladderTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkBladder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkComfort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HungerHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkPublic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkHunger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BladderHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComfortTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HungerTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HygieneHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkFun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkSunshine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PublicHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SunshineTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnergyTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FunTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PublicTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FunHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkHygiene)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SunshineHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLscore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPTO)).EndInit();
            this.gbJLHoursWages.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbJobDetails.ResumeLayout(false);
            this.gbJobDetails.PerformLayout();
            this.gbJLDetails.ResumeLayout(false);
            this.tabPagMajor.ResumeLayout(false);
            this.gbmajaffil.ResumeLayout(false);
            this.gbmajaffil.PerformLayout();
            this.gbrequir.ResumeLayout(false);
            this.gbrequir.PerformLayout();
            this.mainMenu1.ResumeLayout(false);
            this.mainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region Global
        private SimPe.Packages.GeneratableFile package;
        private uint groupId;
        private StrWrapper catalogueDesc;
        private Bcon tuning;
        private Bcon lifeScore;
        private Bcon PTO;
        private Bcon goodRew;
        private Bcon badRew;
        private Bcon extraAG;
        private Bcon extraAB;
        private Bcon extraBG;
        private Bcon extraBB;
        private Bcon exinit;
        private Bcon majors;
        private Bcon cclevels;
        private bool preuniv = false;
        private bool isCastaway = false;
        static TextBox tbox;

        #region Reward and Upgrade

        private static String[] rewardName = new String[] {
                "Biotech Station",
                "Camera",
                "Candy Factory",
                "Cow Plant",
                "Fingerprint Kit",
                "Home Plastic Surgery Kit",
                "Hydroponic Garden",
                "Obstacle Course",
                "Polygraph",
                "Putting Green",
                "Punching Bag",
                "Resurrectonomitron",
                "Surgical Dummy",
                "Teleprompter",
                "Drafting Table",
                "Ballet Bar",
                "Books First Bookshelf",
                "Starstruck Fame Star Rug",
                "Guitar",
                "Journalism Award",
                "Carefree Koi Pond",
                "Lectern",
                "Pinball",
                "Surveillance Mic",
                "Golden Skull of Jumbok IV",
        };
        private static UInt32[] rewardGUID = new UInt32[] {
                0x0C6E194A, 0xAEB9F591, 0x8C4D2997, 0xCEA505BB,
                0xD1CD15C8, 0x4E9FBE5D, 0xCC58DF85, 0x6C2979FB,
                0xCC16D816, 0xCC20426A, 0x4C2148B0, 0xAE8D50B2,
                0x6C6CE31F, 0xAC314A3A, 0xB3FD5372, 0x33EC6E0A,
                0x524E1066, 0x33E2E4E8, 0x324D0D87, 0xD24CE39C,
                0x53EDA12F, 0x124E3138, 0xF24CFF80, 0xB3FEC1B6,
                0xD24D09FD,
        };

        private static String[] upgradeName = new String[] {
            "Adventurer", "Artist", "Athletics", "Business",
            "Construction", "Criminal", "Culinary", "Dance",
            "Economy", "Entertainment", "Education", "Gamer",
            "Intelligence", "Journalism", "Law", "Law Enforcement",
            "Medicine", "Military", "Music", "NaturalScientist",
            "Ocenography", "Paranormal", "Politics", "Science",
            "ShowBiz", "Slacker", "Owned Business",
        };
        private static UInt32[] upgradeGUID = new UInt32[] {
            0x3240CBA5, 0x4E6FFFBC, 0x2C89E95F, 0x45196555,
            0xF3E1C301, 0x6C9EBD0E, 0xEC9EBD5F, 0xD3E09422,
            0x45196555, 0xB3E09417, 0x72428B30, 0xF240C306,
            0x33E0940E, 0x7240D944, 0x12428B19, 0xAC9EBCE3,
            0x0C7761FD, 0x6C9EBD32, 0xB2428B0C, 0xEE70001C,
            0x73E09404, 0x2E6FFF87, 0x2C945B14, 0x0C9EBD47,
            0xAE6FFFB0, 0xEC77620B, 0xD08F400A,
        };

        // end crap, start goody

        private static String[] TArewardName = new String[] {
                "Biotech Station",
                "Camera",
                "Candy Factory",
                "Cow Plant",
                "Fingerprint Kit",
                "Home Plastic Surgery Kit",
                "Hydroponic Garden",
                "Obstacle Course",
                "Polygraph",
                "Putting Green",
                "Punching Bag",
                "Resurrectonomitron",
                "Surgical Dummy",
                "Teleprompter",
                "Drafting Table",
                "Ballet Bar",
                "Books First Bookshelf",
                "Starstruck Fame Star Rug",
                "Guitar",
                "Journalism Award",
                "Carefree Koi Pond",
                "Lectern",
                "Pinball",
                "Surveillance Mic",
                "Golden Skull of Jumbok IV",
                "Frankensim Maker",
        };
        private static UInt32[] TArewardGUID = new UInt32[] {
                0x0C6E194A, 0xAEB9F591, 0x8C4D2997, 0xCEA505BB,
                0xD1CD15C8, 0x4E9FBE5D, 0xCC58DF85, 0x6C2979FB,
                0xCC16D816, 0xCC20426A, 0x4C2148B0, 0xAE8D50B2,
                0x6C6CE31F, 0xAC314A3A, 0xB3FD5372, 0x33EC6E0A,
                0x524E1066, 0x33E2E4E8, 0x324D0D87, 0xD24CE39C,
                0x53EDA12F, 0x124E3138, 0xF24CFF80, 0xB3FEC1B6,
                0xD24D09FD, 0x00845D23,
        };

        private static String[] TAupgradeName = new String[] {
            "Adventurer", "Artist", "Athletics", "Business",
            "Construction", "Criminal", "Culinary", "Dance",
            "Economy", "Entertainment", "Education", "Gamer",
            "Intelligence", "Journalism", "Law", "Law Enforcement",
            "Medicine", "Military", "Music", "NaturalScientist",
            "Ocenography", "Paranormal", "Politics", "Science",
            "ShowBiz", "Slacker",
            "Owned Business", "Party Industry",
        };

        private static UInt32[] TAupgradeGUID = new UInt32[] {
            0x3240CBA5, 0x4E6FFFBC, 0x2C89E95F, 0x45196555,
            0xF3E1C301, 0x6C9EBD0E, 0xEC9EBD5F, 0xD3E09422,
            0x45196555, 0xB3E09417, 0x72428B30, 0xF240C306,
            0x33E0940E, 0x7240D944, 0x12428B19, 0xAC9EBCE3,
            0x0C7761FD, 0x6C9EBD32, 0xB2428B0C, 0xEE70001C,
            0x73E09404, 0x2E6FFF87, 0x2C945B14, 0x0C9EBD47,
            0xAE6FFFB0, 0xEC77620B,
            0xD08F400A, 0x00845D10,
        };

        // end goody, start Castaawy

        private static String[] CSrewardName = new String[] { "Shaman Station", "Electronic Crafting Station", "Obstacle Course", };
        private static UInt32[] CSrewardGUID = new UInt32[] { 0xB3ED7E27, 0xD3CF5048, 0xB3D1BACF, };
        private static String[] CSupgradeName = new String[] { "Gatherer", "Crafter", "Hunter", };
        private static UInt32[] CSupgradeGUID = new UInt32[] { 0x738D6245, 0xD38D6534, 0x93701850, };

        private Instruction AddRewardToInventory = null;
        private Instruction JobUpgrade = null;

        private void setRewardFromGUID() { setGCFromIns(gcReward, AddRewardToInventory, 5); }
        private void getGUIDFromReward() { setInsFromGC(gcReward, AddRewardToInventory, 5); }
        private void setUpgradeFromGUID() { setGCFromIns(gcUpgrade, JobUpgrade, 0); }
        private void getGUIDFromUpgrade() { setInsFromGC(gcUpgrade, JobUpgrade, 0); }

        #endregion

        private void setGCFromIns(GUIDChooser gc, Instruction ins, int op)
        {
            if (ins == null)
            {
                gc.Value = 0;
                gc.Enabled = false;
                return;
            }
            byte[] o = new byte[16];
            ((byte[])ins.Operands).CopyTo(o, 0);
            ((byte[])ins.Reserved1).CopyTo(o, 8);
            gc.Value = (UInt32)(o[op] | (o[op + 1] << 8) | (o[op + 2] << 16) | (o[op + 3] << 24));
        }
        private void setInsFromGC(GUIDChooser gc, Instruction ins, int op)
        {
            if (ins == null) return; // Should never happen
            if (gc.Value == 0) // Was something, now "None"
            {
                ins.Parent.FileDescriptor.MarkForDelete = true;
                ins.Parent.Changed = true;
                return;
            }
            UInt32 guid = gc.Value;
            for (int i = 0; i < 4; i++)
                if (op + i < 8) ins.Operands[op + i] = (byte)((guid >> (i * 8)) & 0xff);
                else ins.Reserved1[op + i - 8] = (byte)((guid >> (i * 8)) & 0xff);
        }

        private bool isPetCareer = false;
        private bool isTeenCareer = false;

        private ushort noLevels;
        private ushort femaleOffset;
        private void noLevelsChanged(ushort l)
        {
            ushort oldNoLevels = noLevels;
            ushort oldLevel = currentLevel;
            if (l > oldNoLevels) oldLevel++; else if (oldLevel > 1) oldLevel--;

            noLevels = l;
            femaleOffset = (ushort)(2 * noLevels);

            miAddLvl.Enabled = (noLevels < 100);
            miRemoveLvl.Enabled = (noLevels > 1);

            CareerLvls.Text = Convert.ToString(noLevels);
            //CareerLvls.Value = noLevels;

            fillJobDetails();
            fillHoursAndWages();
            fillPromotionDetails();
            lnudChanceCurrentLevel.Maximum = noLevels;

            currentLevel = 0;
            levelChanged(oldLevel > noLevels ? noLevels : oldLevel);
        }

        private ushort currentLevel;
        private bool levelChanging = false;
        private void levelChanged(ushort newLevel)
        {
            if (levelChanging || newLevel == currentLevel) return;
            internalchg = levelChanging = true;

            //lbPTO.Text = "Paid Time Off (PTO) Daily Accruement " + PTO[newLevel];
            numPTO.Value = PTO[newLevel];

            if (lifeScore != null) numLscore.Value = lifeScore[newLevel];
            else lbLscore.Visible = numLscore.Visible = false;

            #region job details
            JobDetailList.SelectedIndices.Clear();
            JobDetailList.Items[newLevel - 1].Selected = true;
            gbJobDetails.Text = "Current Level: " + newLevel;

            List<StrItem> items = jobTitles[currentLanguage];
            jdpMale.TitleValue = items[(newLevel - 1) * 2 + 1].Title;
            jdpMale.DescValue = items[(newLevel - 1) * 2 + 2].Title;
            jdpFemale.TitleValue = items[femaleOffset + (newLevel - 1) * 2 + 1].Title;
            jdpFemale.DescValue = items[femaleOffset + (newLevel - 1) * 2 + 2].Title;

            setOutfitFromGUID(newLevel);
            setVehicleFromGUID(newLevel);
            #endregion

            #region hours & wages
            HoursWagesList.SelectedIndices.Clear();
            HoursWagesList.Items[newLevel - 1].Selected = true;
            gbHoursWages.Text = "Current Level: " + newLevel;
            lnudWorkStart.Value = startHour[newLevel];
            lnudWorkHours.Value = hoursWorked[newLevel];
            tbWorkFinish.Text = Convert.ToString((startHour[newLevel] + hoursWorked[newLevel]) % 24);
            if (isCastaway)
                lnudFoods.Value = foodinc[newLevel];

            if (!isPetCareer)
            {
                if (wages[newLevel] > lnudWages.Maximum)
                    lnudWages.Value = lnudWages.Maximum;
                else
                    lnudWages.Value = wages[newLevel];

                lnudWagesDog.Visible = lnudWagesCat.Visible = false;
            }
            else
            {
                lnudWages.Enabled = false;
                if (wagesDog[newLevel] > lnudWagesDog.Maximum)
                    lnudWagesDog.Value = lnudWagesDog.Maximum;
                else
                    lnudWagesDog.Value = wagesDog[newLevel];

                if (wagesCat[newLevel] > lnudWagesCat.Maximum)
                    lnudWagesCat.Value = lnudWagesCat.Maximum;
                else
                    lnudWagesCat.Value = wagesCat[newLevel];
            }

            Boolset dw = getDaysArray(daysWorked[newLevel]);
            WorkMonday.Checked = dw[MONDAY];
            WorkTuesday.Checked = dw[TUESDAY];
            WorkWednesday.Checked = dw[WEDNESDAY];
            WorkThursday.Checked = dw[THURSDAY];
            WorkFriday.Checked = dw[FRIDAY];
            WorkSaturday.Checked = dw[SATURDAY];
            WorkSunday.Checked = dw[SUNDAY];

            WorkHunger.Value = motiveDeltas[HUNGER][newLevel];
            WorkComfort.Value = motiveDeltas[COMFORT][newLevel];
            WorkHygiene.Value = motiveDeltas[HYGIENE][newLevel];
            WorkBladder.Value = motiveDeltas[BLADDER][newLevel];
            WorkEnergy.Value = motiveDeltas[ENERGY][newLevel];
            WorkFun.Value = motiveDeltas[FUN][newLevel];
            WorkPublic.Value = motiveDeltas[PUBLIC][newLevel];
            WorkSunshine.Value = motiveDeltas[SUNSHINE][newLevel];

            WorkChanged(newLevel);
            #endregion

            #region promotion
            PromoList.SelectedIndices.Clear();
            PromoList.Items[newLevel - 1].Selected = true;
            gbPromo.Text = "Current Level: " + newLevel;
            if (!isPetCareer) // people
            {
                PromoCooking.Value = skillReq[COOKING][newLevel] / 100;
                PromoMechanical.Value = skillReq[MECHANICAL][newLevel] / 100;
                PromoBody.Value = skillReq[BODY][newLevel] / 100;
                PromoCharisma.Value = skillReq[CHARISMA][newLevel] / 100;
                PromoCreativity.Value = skillReq[CREATIVITY][newLevel] / 100;
                PromoLogic.Value = skillReq[LOGIC][newLevel] / 100;
                PromoCleaning.Value = skillReq[CLEANING][newLevel] / 100;
                cbTrick.Enabled = false;
            }
            else // pets
            {
                PromoCooking.Enabled =
                PromoMechanical.Enabled =
                PromoBody.Enabled =
                PromoCharisma.Enabled =
                PromoCreativity.Enabled =
                PromoLogic.Enabled =
                PromoCleaning.Enabled =
                false;
                cbTrick.SelectedIndex = 0;
                for (int i = 0; i * 2 < trick.Count; i++)
                    if (trick[i * 2 + 1] == newLevel)
                        cbTrick.SelectedIndex = trick[i * 2];
            }

            PromoFriends.Value = friends[newLevel];
            #endregion

            //chance cards
            chanceCardsLevelChanged(newLevel);

            currentLevel = newLevel;
            internalchg = levelChanging = false;
        }

        private byte currentLanguage;
        private List<String> languageString;
        private bool englishOnly;

        #endregion

        #region Job Details
        #region Job Titles
        private StrWrapper jobTitles;
        private void fillJobDetails()
        {
            JobDetailList.Items.Clear();
            for (int i = jobTitles[currentLanguage].Count; i < noLevels * 4 + 1; i++) jobTitles.Add(currentLanguage, "", "");
            List<StrItem> items = jobTitles[currentLanguage];
            for (ushort i = 0; i < noLevels; i++)
            {
                ListViewItem item1 = new ListViewItem("" + (i + 1), 0);
                item1.SubItems.Add(items[femaleOffset + (i * 2) + 1].Title);
                item1.SubItems.Add(items[femaleOffset + (i * 2) + 2].Title);
                item1.SubItems.Add(getOutfitTextFromGUIDAt(i + 1));
                if (isCastaway)
                    item1.SubItems.Add("");
                else
                    item1.SubItems.Add(getVehicleTextFromGUID(i + 1));
                JobDetailList.Items.Add(item1);
            }
        }
        #endregion

        #region Outfits Vehicles

        private Bcon outfit;
        private Bcon vehicle;

        private string getOutfitTextFromGUIDAt(int i)
        {
            if (isCastaway)
                return StringFromGUID(GUIDfromBCON(outfit, i), CSoutfitGUID, CSoutfitName);
            return StringFromGUID(GUIDfromBCON(outfit, i), outfitGUID, outfitName);        
        }

        private void setOutfitFromGUID(int i)
        {
            gcOutfit.Value = GUIDfromBCON(outfit, i);
        }

        private string getVehicleTextFromGUID(int i)
        {
            return StringFromGUID(GUIDfromBCON(vehicle, i), vehicleGUID, vehicleName);
        }

        private void setVehicleFromGUID(int i)
        {
            gcVehicle.Value = GUIDfromBCON(vehicle, i);
        }

        private static UInt32[] outfitGUID = {
            0x526A1BC5, 0x0CC8FB0A, 0x6CF36A28, 0xACCFBA59,
            0x4CC8D355, 0x6CC1394A, 0x6CDB4D89, 0xACCFB5BA,
            0x6CE5E896, 0x7260F377, 0x5260F2CD, 0x2DC106EF,
            0xD2648300, 0xB2648347, 0x926A15C0, 0x325B8C8C,
            0x8CC8D510, 0xD26477D7, 0x8EBB1D6F, 0x6EBE0635,
            0x2ED4954E, 0xCEBA9C6C, 0x8EBE06F7, 0xEEBE33C6,
            0x6ED49951, 0xEEC0D438, 0xEEC0C883, 0xEEC0E1F1,
            0xAEC0D9E1, 0x52647796, 0xACCFB61B, 0xCCC8FA1E,
            0x926475B2, 0x526A0B4A, 0x0CCFB4F4, 0x4CF368BE,
            0x526481A6, 0x8CCFA3D8, 0xD264817E, 0xF25F7774,
            0x12648223, 0x92647699, 0x325F70DC, 0xB25F60C2,
            0x8CCFA130, 0x8CCFA223, 0xCCE5E90F, 0x52647657,
            0x8CCFA318, 0x2CD4EE5D, 0x8CE5EA26, 0xCCCF9FA7,
            0xECE5EB2F, 0xB25F6141, 0x8CCFA387, 0x925F75C9,
            0x925F7806, 0x72647706, 0x92647B25, 0x6CC13C27,
            0xACD4EEE6, 0x3260F41C, 0x7260F192, 0xACC8EE11,
            0x726483E4, 0x6CC8CFBD, 0x0DCC7C4D, 0x126A202D,
            0x525F71A7, 0xD260F3D9, 0xB2647B72, 0x7260F460,
            0xACCFB97C, 0xACE5EB8C, 0x0CCFA643, 0x52647818,
            0xECCFA694, 0xECCFB386, 0x125F7704, 
            0xEDED8493, 0x6DD1D04B,
            0xECA45D6D, 0x2CA45AE2, 0x0DB8AE38, 0x8CC13127,
            0x2CD89D6B, 0x2DC0FCD7, 0x8DC3893C, 0x0CA45C86,
            0xCDC38723, 0x8CDA36DA, 0xCD65FD9F, 0x6CC13409,
            0x6DC38A6C, 0xECD0F3FC, 0xCCD0F227, 0x6CC1322B,
            0xACD0F47C, 0x6CD0F537, 0x0CA45C32, 0x6CC130A6,
            
            0xECD7C130, 0xCE029001, 0x2E02903A, 0x6CD4EDE8,
            0xEE028B7C, 0x2E028C23, 0xAE028CB9, 0x6D771A13,
        };

        private static String[] outfitName = new String[] {
            "Adventurer", "Astronaut", "Blue Scrubs", "Burglar",
            "Captain Hero", "Cheap Suit", "Chef", "Clerk",
            "Coach", "Concert Pianist", "Conductor", "Cop",
            "Senior Professor", "Dean of Students", "Diver", "Dread Pirate",
            "EMT", "Entertainment Attorney", "EP1 Bartender", "EP1 Commercial Mascot",
            "EP1 Cultleader", "EP1 Graduation", "EP1 Natural Scientist", "EP1 Paranormal",
            "EP1 Photographer", "EP1 Post Graduation", "EP1 Secret Society", "EP1 TogaParty Casual",
            "EP1 TogaParty Outgoing", "Family Attorney", "Fast Food", "Fatigues",
            "File Clerk", "Gamer", "Gas Station", "Green Scrubs",
            "Guest Lecturer", "High-Rank", "Highschool", "Hostage",
            "Highschool Principal", "Injury Attorney", "Intern", "Journalist",
            "Lab Coat1", "Lab Coat2", "Leather Jacket", "Legal Secretary",
            "Low-Rank", "Mad-Lab", "Mascot", "Mastcot Evil",
            "Mayor", "Media", "Mid-Rank", "Multi-Regional",
            "Mystery", "Paralegal", "Playground Monitor", "Power-Suit",
            "Restaurant", "Roadie", "Rockstar", "Scrubs",
            "Secretary of Education", "Security Guard", "Slick-Suit", "Space Pirate",
            "Spelunker", "Studio Musician", "Substitute Teacher", "Summercamp",
            "Super Chef", "Swat", "Sweat-Suit", "The Law",
            "Tracksuit", "Tweed Jacket", "Warhead",
            "Electrocution", "Maternity",
            "NPC Ambulance Driver (Paramedic)", "NPC Bartender", "NPC Burglar", "NPC BusDriver",
            "NPC Clerk", "NPC Cop", "NPC DeliveryPerson", "NPC Exterminator",
            "NPC FireFighter", "NPC Gardener", "NPC HandyPerson", "NPC HeadMaster", 
            "NPC Maid", "NPC Mail Delivery", "NPC Nanny", "NPC Paper Delivery",
            "NPC Pizza Delivery", "NPC Repo", "NPC Salesperson", "NPC SocialWorker",
            "PrivateSchool", "Reaper Lei", "Reaper NoLei", "SkeletonGlow",
            "SocialBunny Blue", "SocialBunny Pink", "SocialBunny Yellow", "Wedding Outfit",
        };

        private static UInt32[] vehicleGUID = new UInt32[] {
			0xAD0AB49C, 0x0D099B93, 0xAC43E058, 0x4CA1487C,
            0x6C6CDEC6, 0xCC69FDA3, 0xEC860630, 0x0CA42373,
            0x8C5A4D9E, 0x4D50E553, 0x4C03451A, 0x6CA4110A,
            0x4C413B80, 0x0C85AE14, 0xCD08624E, 0x4D09B954,
        };
        private static String[] vehicleName = new String[] {
			"Captain Hero Flyaway", "Helicopter - Executive", "Helicopter - Army", "Town Car",
			"Sports Car - Super", "Sports Car - Mid", "Sports Car - Low", "Sports Team Bus",
			"Sedan", "Taxi", "Minivan", "Limo", 
            "HMV", "Hatchback", "Police", "Ambulance",
		};

        // End Shit - Start good

        private static UInt32[] TAoutfitGUID = {
            0x526A1BC5, 0x0CC8FB0A, 0x6CF36A28, 0xACCFBA59,
            0x4CC8D355, 0x6CC1394A, 0x6CDB4D89, 0xACCFB5BA,
            0x6CE5E896, 0x7260F377, 0x5260F2CD, 0x2DC106EF,
            0xD2648300, 0xB2648347, 0x926A15C0, 0x325B8C8C,
            0x8CC8D510, 0xD26477D7, 0x8EBB1D6F, 0x6EBE0635,
            0x2ED4954E, 0xCEBA9C6C, 0x8EBE06F7, 0xEEBE33C6,
            0x6ED49951, 0xEEC0D438, 0xEEC0C883, 0xEEC0E1F1,
            0xAEC0D9E1, 0x52647796, 0xACCFB61B, 0xCCC8FA1E,
            0x926475B2, 0x526A0B4A, 0x0CCFB4F4, 0x4CF368BE,
            0x526481A6, 0x8CCFA3D8, 0xD264817E, 0xF25F7774,
            0x12648223, 0x92647699, 0x325F70DC, 0xB25F60C2,
            0x8CCFA130, 0x8CCFA223, 0xCCE5E90F, 0x52647657,
            0x8CCFA318, 0x2CD4EE5D, 0x8CE5EA26, 0xCCCF9FA7,
            0xECE5EB2F, 0xB25F6141, 0x8CCFA387, 0x925F75C9,
            0x925F7806, 0x72647706, 0x92647B25, 0x6CC13C27,
            0xACD4EEE6, 0x3260F41C, 0x7260F192, 0xACC8EE11,
            0x726483E4, 0x6CC8CFBD, 0x0DCC7C4D, 0x126A202D,
            0x525F71A7, 0xD260F3D9, 0xB2647B72, 0x7260F460,
            0xACCFB97C, 0xACE5EB8C, 0x0CCFA643, 0x52647818,
            0xECCFA694, 0xECCFB386, 0x125F7704, 0xEDED8493,
            0x6DD1D04B, 0xECA45D6D, 0x2CA45AE2, 0x0DB8AE38,
            0x8CC13127, 0x2CD89D6B, 0x2DC0FCD7, 0x8DC3893C,
            0x0CA45C86, 0xCDC38723, 0x8CDA36DA, 0xCD65FD9F,
            0x6CC13409, 0x6DC38A6C, 0xECD0F3FC, 0xCCD0F227,
            0x6CC1322B, 0xACD0F47C, 0x6CD0F537, 0x0CA45C32,
            0x6CC130A6, 0xECD7C130, 0xCE029001, 0x2E02903A,
            0x6CD4EDE8, 0xEE028B7C, 0x2E028C23, 0xAE028CB9,
            0x6D771A13, 0x00845D77, 0x8F73B607, 0xF46C3CDD,
            0x008BB233,
        };

        private static String[] TAoutfitName = new String[] {
            "Adventurer", "Astronaut", "Blue Scrubs", "Burglar",
            "Captain Hero", "Cheap Suit", "Chef", "Clerk",
            "Coach", "Concert Pianist", "Conductor", "Cop",
            "Senior Professor", "Dean of Students", "Diver", "Dread Pirate",
            "EMT", "Entertainment Attorney", "EP1 Bartender", "EP1 Commercial Mascot",
            "EP1 Cultleader", "EP1 Graduation", "EP1 Natural Scientist", "EP1 Paranormal",
            "EP1 Photographer", "EP1 Post Graduation", "EP1 Secret Society", "EP1 TogaParty Casual",
            "EP1 TogaParty Outgoing", "Family Attorney", "Fast Food", "Fatigues",
            "File Clerk", "Gamer", "Gas Station", "Green Scrubs",
            "Guest Lecturer", "High-Rank", "Highschool", "Hostage",
            "Highschool Principal", "Injury Attorney", "Intern", "Journalist",
            "Lab Coat1", "Lab Coat2", "Leather Jacket", "Legal Secretary",
            "Low-Rank", "Mad-Lab", "Mascot", "Mastcot Evil",
            "Mayor", "Media", "Mid-Rank", "Multi-Regional",
            "Mystery", "Paralegal", "Playground Monitor", "Power-Suit",
            "Restaurant", "Roadie", "Rockstar", "Scrubs",
            "Secretary of Education", "Security Guard", "Slick-Suit", "Space Pirate",
            "Spelunker", "Studio Musician", "Substitute Teacher", "Summercamp",
            "Super Chef", "Swat", "Sweat-Suit", "The Law",
            "Tracksuit", "Tweed Jacket", "Warhead",
            "Electrocution", "Maternity",
            "NPC Ambulance Driver (Paramedic)", "NPC Bartender", "NPC Burglar", "NPC BusDriver",
            "NPC Clerk", "NPC Cop", "NPC DeliveryPerson", "NPC Exterminator",
            "NPC FireFighter", "NPC Gardener", "NPC HandyPerson", "NPC HeadMaster", 
            "NPC Maid", "NPC Mail Delivery", "NPC Nanny", "NPC Paper Delivery",
            "NPC Pizza Delivery", "NPC Repo", "NPC Salesperson", "NPC SocialWorker",
            "Private School Uniform", "Reaper Lei", "Reaper NoLei", "Skeleton Glow",
            "SocialBunny Blue", "SocialBunny Pink", "SocialBunny Yellow", "Wedding Outfit",            
            "High Society Escort", "EP2 Date Diva", "EP7 Diva", "St.Trinians Uniform",
        };

        private static UInt32[] TAvehicleGUID = new UInt32[] {
			0xAD0AB49C, 0x0D099B93, 0xAC43E058, 0x4CA1487C,
            0x6C6CDEC6, 0xCC69FDA3, 0xEC860630, 0x0CA42373,
            0x8C5A4D9E, 0x4D50E553, 0x4C03451A, 0x6CA4110A,
            0x4C413B80, 0x0C85AE14, 0xCD08624E, 0x4D09B954,
            0x00845D0F, 0x00845D41,
        };
        private static String[] TAvehicleName = new String[] {
			"Captain Hero Flyaway", "Helicopter - Executive", "Helicopter - Army", "Town Car",
			"Sports Car - Super", "Sports Car - Mid", "Sports Car - Low", "Sports Team Bus",
			"Sedan", "Taxi", "Minivan", "Limo", 
            "HMV", "Hatchback", "Police", "Ambulance",
            "Princess Van", "White Limo",
		};

        private static UInt32[] CSoutfitGUID = { 0xB431D8A0, 0x9431D91A, 0x7431D945, };
        private static String[] CSoutfitName = new String[] { "Career Crafter", "Career Gatherer", "Career Hunter", };

        #endregion

        private uint GUIDfromBCON(Bcon bcon, int i)
        {
            return (uint)(((ushort)bcon[i * 2 + 1] << 16) | ((ushort)bcon[i * 2]));
        }
        private string StringFromGUID(uint guid, UInt32[] guids, String[] strings)
        {
            if (guid == 0) return "";
            int index = (new List<uint>(guids)).IndexOf(guid);
            return index >= 0 ? strings[index] : "Other";
        }
        private void insertGuid(Bcon bcon, int index, uint guid)
        {
            List<short> bconItem = new List<short>();
            foreach (short i in bcon) bconItem.Add(i);
            bconItem.Insert((index + 1) * 2, (short)(guid & 0xffff));
            bconItem.Insert((index + 1) * 2 + 1, (short)(guid >> 16 & 0xffff));
            bcon.Clear();
            foreach (short i in bconItem) bcon.Add(i);
        }
        #endregion


        #region Hours & Wages
        private Bcon startHour;
        private Bcon hoursWorked;
        private Bcon daysWorked;
        private Bcon wages;
        private Bcon wagesCat;
        private Bcon wagesDog;
        private Bcon foodinc;
        private Bcon resinc;
        private Bcon[] motiveDeltas;

        private void fillHoursAndWages()
        {
            HoursWagesList.Items.Clear();
            for (ushort i = 1; i <= noLevels; i++)
            {
                ListViewItem item1 = new ListViewItem("" + i, 0);

                item1.SubItems.Add("" + startHour[i]);
                item1.SubItems.Add("" + hoursWorked[i]);
                item1.SubItems.Add("" + (startHour[i] + hoursWorked[i]) % 24);
                if (isCastaway)
                {
                    item1.SubItems.Add("" + wages[i]);
                    item1.SubItems.Add("" + foodinc[i]);
                    item1.SubItems.Add("");
                }
                else if (!isPetCareer)
                {
                    item1.SubItems.Add("" + wages[i]);
                    item1.SubItems.Add("");
                    item1.SubItems.Add("");
                }
                else
                {
                    item1.SubItems.Add("");
                    item1.SubItems.Add("" + wagesDog[i]);
                    item1.SubItems.Add("" + wagesCat[i]);
                }

                Boolset dw = getDaysArray(daysWorked[i]);
                item1.SubItems.Add("" + dw[MONDAY]);
                item1.SubItems.Add("" + dw[TUESDAY]);
                item1.SubItems.Add("" + dw[WEDNESDAY]);
                item1.SubItems.Add("" + dw[THURSDAY]);
                item1.SubItems.Add("" + dw[FRIDAY]);
                item1.SubItems.Add("" + dw[SATURDAY]);
                item1.SubItems.Add("" + dw[SUNDAY]);

                HoursWagesList.Items.Add(item1);
            }
        }

        private Boolset getDaysArray(short val)
        {
            return new Boolset((byte)((val >= 0) ? val : val + 65536));
        }
        private void WorkChanged(int level)
        {
            HungerHours.Value = hoursWorked[level];
            ComfortHours.Value = hoursWorked[level];
            HygieneHours.Value = hoursWorked[level];
            BladderHours.Value = hoursWorked[level];
            EnergyHours.Value = hoursWorked[level];
            FunHours.Value = hoursWorked[level];
            PublicHours.Value = hoursWorked[level];
            SunshineHours.Value = hoursWorked[level];

            HungerTotal.Value = motiveDeltas[HUNGER][level] * hoursWorked[level];
            ComfortTotal.Value = motiveDeltas[COMFORT][level] * hoursWorked[level];
            HygieneTotal.Value = motiveDeltas[HYGIENE][level] * hoursWorked[level];
            BladderTotal.Value = motiveDeltas[BLADDER][level] * hoursWorked[level];
            EnergyTotal.Value = motiveDeltas[ENERGY][level] * hoursWorked[level];
            FunTotal.Value = motiveDeltas[FUN][level] * hoursWorked[level];
            PublicTotal.Value = motiveDeltas[PUBLIC][level] * hoursWorked[level];
            SunshineTotal.Value = motiveDeltas[SUNSHINE][level] * hoursWorked[level];
        }
        #endregion


        #region Promotion
        private Bcon[] skillReq;
        private Bcon friends;
        private Bcon trick;

        private void fillPromotionDetails()
        {
            PromoList.Items.Clear();
            for (ushort i = 1; i <= noLevels; i++)
            {
                ListViewItem item1 = new ListViewItem("" + i, 0);

                if (!isPetCareer) // people
                {
                    item1.SubItems.Add("" + skillReq[COOKING][i] / 100);
                    item1.SubItems.Add("" + skillReq[MECHANICAL][i] / 100);
                    item1.SubItems.Add("" + skillReq[BODY][i] / 100);
                    item1.SubItems.Add("" + skillReq[CHARISMA][i] / 100);
                    item1.SubItems.Add("" + skillReq[CREATIVITY][i] / 100);
                    item1.SubItems.Add("" + skillReq[LOGIC][i] / 100);
                    item1.SubItems.Add("" + skillReq[CLEANING][i] / 100);
                    item1.SubItems.Add("" + friends[i]);
                    item1.SubItems.Add("");
                }
                else // pets
                {
                    item1.SubItems.Add("");
                    item1.SubItems.Add("");
                    item1.SubItems.Add("");
                    item1.SubItems.Add("");
                    item1.SubItems.Add("");
                    item1.SubItems.Add("");
                    item1.SubItems.Add("");
                    item1.SubItems.Add("" + friends[i]);
                    String tr = (String)cbTrick.Items[0];
                    for (int j = 0; j * 2 < trick.Count; j++)
                        if (trick[j * 2 + 1] == i)
                            tr = (String)cbTrick.Items[trick[j * 2]];
                    item1.SubItems.Add(tr);
                }

                PromoList.Items.Add(item1);
            }
        }
        #endregion


        #region Chance Cards
        private StrWrapper chanceCardsText;
        private Bcon[] chanceASkills;
        private Bcon[] chanceAGood;
        private Bcon[] chanceABad;

        private Bcon[] chanceBSkills;
        private Bcon[] chanceBGood;
        private Bcon[] chanceBBad;

        private Bcon chanceChance;
        private Bcon chanceAchance;
        private Bcon chanceBchance;

        private void chanceCardsLevelChanged(ushort newLevel)
        {
            if (currentLevel != 0 && currentLevel <= noLevels) chanceCardsToFiles();

            lnudChanceCurrentLevel.Value = newLevel;
            if (isPetCareer)
            {
                lnudPetChancePercent.Value = chanceAchance[newLevel];
                lnudPetChancePercent.Visible = true;
                lnudChancePercent.Value = chanceBchance[newLevel];
            }
            else
                lnudChancePercent.Value = chanceChance[newLevel];

            cpChoiceA.HaveSkills = cpChoiceB.HaveSkills = (chanceChance[newLevel] < 0 && !isPetCareer);

            if (preuniv)
                cbischance.Visible = false;
            else 
                cbischance.Checked = cclevels[newLevel] > 0;

            for (int i = chanceCardsText[currentLanguage].Count; i < newLevel * 12 + 19; i++)
                chanceCardsText.Add(currentLanguage, "", "");
            List<StrItem> items = chanceCardsText[currentLanguage];

            cpChoiceA.setValues(true, cpChoiceA.Label, items[newLevel * 12 + 7].Title, chanceASkills, newLevel);
            cpChoiceB.setValues(false, cpChoiceB.Label, items[newLevel * 12 + 8].Title, chanceBSkills, newLevel);

            ChanceTextMale.Text = items[newLevel * 12 + 9].Title;
            ChanceTextFemale.Text = items[newLevel * 12 + 10].Title;

            epPassA.setValues(noLevels, newLevel, chanceAGood, items[newLevel * 12 + 11].Title, items[newLevel * 12 + 12].Title);
            epFailA.setValues(noLevels, newLevel, chanceABad, items[newLevel * 12 + 13].Title, items[newLevel * 12 + 14].Title);
            epPassB.setValues(noLevels, newLevel, chanceBGood, items[newLevel * 12 + 15].Title, items[newLevel * 12 + 16].Title);
            epFailB.setValues(noLevels, newLevel, chanceBBad, items[newLevel * 12 + 17].Title, items[newLevel * 12 + 18].Title);
        }
        private void chanceCardsToFiles()
        {
            List<StrItem> items = chanceCardsText[currentLanguage];
            if (isPetCareer)
            {
                chanceAchance[currentLevel] = (short)lnudPetChancePercent.Value;
                chanceBchance[currentLevel] = (short)lnudChancePercent.Value;
            }
            else
                chanceChance[currentLevel] = (short)lnudChancePercent.Value;

            items[currentLevel * 12 + 7].Title = cpChoiceA.Value;
            if (!isPetCareer)
                cpChoiceA.getValues(chanceASkills, currentLevel);

            items[currentLevel * 12 + 8].Title = cpChoiceB.Value;
            if (!isPetCareer)
                cpChoiceB.getValues(chanceBSkills, currentLevel);

            items[currentLevel * 12 + 9].Title = ChanceTextMale.Text;
            items[currentLevel * 12 + 10].Title = ChanceTextFemale.Text;

            string male = "", female = "";
            epPassA.getValues(chanceAGood, currentLevel, ref male, ref female);
            items[currentLevel * 12 + 11].Title = male;
            items[currentLevel * 12 + 12].Title = female;

            epFailA.getValues(chanceABad, currentLevel, ref male, ref female);
            items[currentLevel * 12 + 13].Title = male;
            items[currentLevel * 12 + 14].Title = female;

            epPassB.getValues(chanceBGood, currentLevel, ref male, ref female);
            items[currentLevel * 12 + 15].Title = male;
            items[currentLevel * 12 + 16].Title = female;

            epFailB.getValues(chanceBBad, currentLevel, ref male, ref female);
            items[currentLevel * 12 + 17].Title = male;
            items[currentLevel * 12 + 18].Title = female;
        }
        #endregion


        #region program constants
        private const byte COOKING = 0;
        private const byte MECHANICAL = 1;
        private const byte BODY = 2;
        private const byte CHARISMA = 3;
        private const byte CREATIVITY = 4;
        private const byte LOGIC = 5;
        private const byte CLEANING = 6;

        private const byte MONEY = 7;
        private const byte JOB = 8;
        private const byte FOOD = 9;

        private const byte HUNGER = 0;
        private const byte AMOROUS = 1;
        private const byte COMFORT = 2;
        private const byte HYGIENE = 3;
        private const byte BLADDER = 4;
        private const byte ENERGY = 5;
        private const byte FUN = 6;
        private const byte PUBLIC = 7;
        private const byte SUNSHINE = 8;

        private const byte MONDAY = 0;
        private const byte TUESDAY = 1;
        private const byte WEDNESDAY = 2;
        private const byte THURSDAY = 3;
        private const byte FRIDAY = 4;
        private const byte SATURDAY = 5;
        private const byte SUNDAY = 6;
        #endregion


        private bool internalchg = false;
		public Interfaces.Plugin.IToolResult Execute(ref SimPe.Interfaces.Files.IPackedFileDescriptor pfd, ref SimPe.Interfaces.Files.IPackageFile package, Interfaces.IProviderRegistry prov) 
		{
			bool newpackage = false;

			this.package = (SimPe.Packages.GeneratableFile)package;
			
			WaitingScreen.Wait();
			try 
			{
                if (this.package == null || this.package.FileName == null)
				{
                    System.IO.Stream s = typeof(CareerEditor).Assembly.GetManifestResourceStream(CareerTool.DefaultCareerFile);
                    System.IO.BinaryReader br = new BinaryReader(s);
                    this.package = SimPe.Packages.GeneratableFile.LoadFromStream(br);
                    newpackage = true;
                    this.package = (SimPe.Packages.GeneratableFile)this.package.Clone();
				}
                if (!pjse.GUIDIndex.TheGUIDIndex.IsLoaded) pjse.GUIDIndex.TheGUIDIndex.Load(pjse.GUIDIndex.DefaultGUIDFile);

                loadFiles();
                if (isCastaway)
                {
                    gcReward.KnownObjects = new object[] { new List<String>(CSrewardName), new List<UInt32>(CSrewardGUID) };
                    gcUpgrade.KnownObjects = new object[] { new List<String>(CSupgradeName), new List<UInt32>(CSupgradeGUID) };
                    gcOutfit.KnownObjects = new object[] { new List<String>(CSoutfitName), new List<UInt32>(CSoutfitGUID) };
                    this.tabControl1.Controls.Remove(this.tabPagMajor);
                    this.gcVehicle.Visible = false;
                    if (isTeenCareer)
                    {
                        if (tuning[0] == 4) this.Text = "Career Editor (by Bidou) - Castaway Orangutan Career";
                        else this.Text = "Career Editor (by Bidou) - Castaway Teen, Elder Career";
                    }
                    else this.Text = "Career Editor (by Bidou) - Castaway Stories Adult Career";
                    this.lnudWages.Label = "Resource";
                    this.lnudWages.Location = new System.Drawing.Point(39, 71);
                    this.lnudFoods.Visible = true;
                    this.HwWages.Text = "Resource";
                    this.HwDogWages.Text = "Food";
                }
                else
                {

                    if (preuniv || isPetCareer || isTeenCareer) this.tabControl1.Controls.Remove(this.tabPagMajor);
                    else setmajors();

                    if (isPetCareer) this.Text = "Career Editor (by Bidou) - Pet Career";
                    else if (isTeenCareer) this.Text = "Career Editor (by Bidou) - Teen, Elder Career";
                    else this.Text = "Career Editor (by Bidou) - Adult Career";
                }
                SimPe.Interfaces.Files.IPackedFileDescriptor bfd = this.package.FindFile(0x856DDBAC, 0, groupId, 1);
                if (bfd != null)
                {
                    SimPe.PackedFiles.Wrapper.Picture pic = new SimPe.PackedFiles.Wrapper.Picture();
                    pic.ProcessData(bfd, this.package);
                    pictureBox1.Image = pic.Image;
                }
                else pictureBox1.Image = null;

                //menuItem6.Enabled = !isPetCareer;
				miEnglishOnly.Checked = englishOnly;

                if (catalogueDesc.Languages.Length <= 1) currentLanguage = 1;
                else currentLanguage = (byte)Helper.WindowsRegistry.LanguageCode; // CJH

                internalchg = true;

                setRewardFromGUID();
                setUpgradeFromGUID();

                Language.DataSource = languageString;
                Language.SelectedIndex = currentLanguage - 1;

                CareerTitle.Text = (((List<StrItem>)catalogueDesc[currentLanguage]).Count == 0) ? "" : catalogueDesc[currentLanguage, 0].Title;

                // englishOnly = (catalogueDesc.Languages.Length <= 1);
                englishOnly = false;
                miEnglishOnly.Checked = englishOnly;
                Language.Enabled = !englishOnly;
                
                internalchg = false;
                noLevelsChanged((ushort)tuning[0]);
			}
			catch (Exception e)
			{
				Helper.ExceptionMessage("Error Loading Career", e);
				return new Plugin.ToolResult(false, false);
			} 
			finally 
			{
                internalchg = false; // Should already be done.
				WaitingScreen.Stop(this);
			}

			ShowDialog();

            getGUIDFromReward();
            getGUIDFromUpgrade();
            chanceCardsToFiles();

			if (englishOnly)
            {
                jobTitles.DefaultOnly();
                chanceCardsText.DefaultOnly();
                catalogueDesc.DefaultOnly();
            }

			saveFiles();

			if (newpackage) package = this.package;
			return new Plugin.ToolResult(true, newpackage);
		}


        private Bcon getBcon(uint instance)
		{
			Interfaces.Files.IPackedFileDescriptor pfd = package.FindFile(0x42434F4E, 0, groupId, instance);
            if (pfd == null) return null;

			Bcon bcon = new Bcon();
			bcon.ProcessData(pfd, package);
			return bcon;
		}
        private bool makeBcon(uint instance, int lvls, string flname)
        {
            package.Add(package.NewDescriptor(0x42434F4E, 0, groupId, instance));
            Interfaces.Files.IPackedFileDescriptor pfd = package.FindFile(0x42434F4E, 0, groupId, instance);
            if (pfd == null) return false;
            lvls++;
            Bcon bcon = new Bcon();
            bcon.ProcessData(pfd, package);
            bcon.FileName = flname;
            for (int i = 0; i < lvls; i++)
                bcon.Add(0);
            bcon.SynchronizeUserData();
            return true;
        }
        private void insertBcon(Bcon bcon, int index, short value)
        {
            List<short> bconItem = new List<short>();
            foreach (short i in bcon) bconItem.Add(i);
            bconItem.Insert(index, value);
            bcon.Clear();
            foreach (short i in bconItem) bcon.Add(i);
        }

        private SimPe.PackedFiles.Wrapper.StrWrapper getCtss() { return getStr(package.FindFiles(Data.MetaData.CTSS_FILE)[0]); }
        private SimPe.PackedFiles.Wrapper.StrWrapper getStr(uint instance) { return getStr(package.FindFile(0x53545223, 0, groupId, instance)); }
        private SimPe.PackedFiles.Wrapper.StrWrapper getStr(Interfaces.Files.IPackedFileDescriptor pfd)
		{
            if (pfd == null) return null;

            SimPe.PackedFiles.Wrapper.StrWrapper str = new SimPe.PackedFiles.Wrapper.StrWrapper();
			str.ProcessData(pfd, package);

            // This makes sure US English is as long the longest str[lng] array
            int count = 0;
            for (byte i = 1; i <= languageString.Count; i++) count = Math.Max(count, str[i].Count);
            while (count > 0 && str[1, count - 1] == null) str.Add(1, "", "");

            return str;
		}

        private void loadFiles()
        {
            catalogueDesc = getCtss();
            groupId = catalogueDesc.FileDescriptor.Group;

            lifeScore = getBcon(0x100D); // not pets
            PTO = getBcon(0x1054);
            goodRew = getBcon(0x105A);
            badRew = getBcon(0x105B);
            extraAG = getBcon(0x1034);
            extraAB = getBcon(0x103E);
            extraBG = getBcon(0x1048);
            extraBB = getBcon(0x1052);
            majors = getBcon(0x1056);
            cclevels = getBcon(0x1057);

            Bhav bhav;

            foreach (Interfaces.Files.IPackedFileDescriptor p in package.FindFiles(0x42484156))
            {
                if (p.MarkForDelete || p.Invalid || p.Group != groupId) continue;
                bhav = new Bhav();
                bhav.ProcessData(p, package);

                #region Find Career Reward
                if (bhav.FileName.Equals("CT - Career Reward")) // Must be adult career
                {
                    isTeenCareer = false;
                    foreach (Instruction ins in bhav)
                        if (ins.OpCode == 0x0033) // Manage Inventory
                        {
                            AddRewardToInventory = ins;
                            break;
                        }
                    continue;
                }
                #endregion

                #region Find Job Ugrade
                if (bhav.FileName.Equals("CT - Upgrade Job to Adult")) // Must be Teen - Elder career
                {
                    isTeenCareer = true;
                    foreach (Instruction ins in bhav)
                        if (ins.OpCode == 0x001f || // Set To Next
                            ins.OpCode == 0x0020) // Test Object Of Type (Owned Business uses this)
                        {
                            JobUpgrade = ins;
                            break;
                        }
                    continue;
                }
                #endregion

                #region Check if Pet career
                if (bhav.FileName.Equals("CT - Command Needed?"))
                {
                    isTeenCareer = false;
                    isPetCareer = true;
                    continue;
                }
                #endregion
            }

            tuning = getBcon(0x1019);

            // Job Details
            jobTitles = getStr(0x0093);
            outfit = getBcon(0x1055);
            vehicle = getBcon(0x100C);

            // Promotion
            if (!isPetCareer)
            {
                skillReq = new Bcon[7];
                skillReq[COOKING] = getBcon(0x1004);
                skillReq[MECHANICAL] = getBcon(0x1005);
                skillReq[BODY] = getBcon(0x1006);
                skillReq[CHARISMA] = getBcon(0x1007);
                skillReq[CREATIVITY] = getBcon(0x1008);
                skillReq[LOGIC] = getBcon(0x1009);
                skillReq[CLEANING] = getBcon(0x100B);
                trick = null;
            }
            else
            {
                trick = getBcon(0x1004);
            }
            friends = getBcon(0x1003);

            // Hours & Wages
            startHour = getBcon(0x1001);
            hoursWorked = getBcon(0x1002);
            if (!isPetCareer)
            {
                wages = getBcon(0x1000);
                wagesDog = wagesCat = null;
            }
            else
            {
                wagesDog = getBcon(0x1000);
                wagesCat = getBcon(0x1005);
                wages = null;
            }
            foodinc = getBcon(0x105E);
            resinc = getBcon(0x105F);

            daysWorked = getBcon(0x101A);

            motiveDeltas = new Bcon[9];
            motiveDeltas[HUNGER] = getBcon(0x100E);
            motiveDeltas[AMOROUS] = getBcon(0x1016);
            motiveDeltas[COMFORT] = getBcon(0x1010);
            motiveDeltas[HYGIENE] = getBcon(0x1011);
            motiveDeltas[BLADDER] = getBcon(0x1012);
            motiveDeltas[ENERGY] = getBcon(0x1013);
            motiveDeltas[FUN] = getBcon(0x1014);
            motiveDeltas[PUBLIC] = getBcon(0x1015);
            if (getBcon(0x105F) != null)
            {
                isCastaway = true;
                motiveDeltas[SUNSHINE] = getBcon(0x1059);
                menuItem6.Enabled = false;                
                this.lbcrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                this.lbcrap.ForeColor = System.Drawing.Color.DarkMagenta;
                this.lbcrap.Text = "Castaway Stories Career";
                this.lbcrap.Visible = true;
            }
            else
            {
                if (getBcon(0x1059) == null)
                {
                    motiveDeltas[SUNSHINE] = getBcon(0x100F); // CJH
                    this.WorkSunshine.Enabled = false;
                    this.lbcrap.Visible = this.btUgrade.Visible = !isPetCareer;
                }
                else
                {
                    motiveDeltas[SUNSHINE] = getBcon(0x1059);
                    this.WorkSunshine.Enabled = true;
                    if (getBcon(0x105B) == null) this.lbcrap.Visible = false;
                }
                if (getBcon(0x1056) == null)
                {
                    this.btUgrade.Visible = true;
                    this.lbcrap.Text = "Really Old Career Type!\r\nIncompatible with University EP or above";
                    preuniv = true;
                }
            }

            // Chance cards
            chanceCardsText = getStr(0x012D);
            chanceChance = getBcon(0x101B); // Seasons - not % chance of happening but % chance true is good answer. if -1 then use skill instead
            // Seasons uses current season to determine % chance of happening, set by semiglobal constant not in career
            if (!isPetCareer)
            {
                chanceASkills = new Bcon[7]; // not pets
                chanceASkills[COOKING] = getBcon(0x101C);
                chanceASkills[MECHANICAL] = getBcon(0x101D);
                chanceASkills[BODY] = getBcon(0x101E);
                chanceASkills[CHARISMA] = getBcon(0x101F);
                chanceASkills[CREATIVITY] = getBcon(0x1020);
                chanceASkills[LOGIC] = getBcon(0x1021);
                chanceASkills[CLEANING] = getBcon(0x1023);

                chanceBSkills = new Bcon[7]; // not pets
                chanceBSkills[COOKING] = getBcon(0x1024);
                chanceBSkills[MECHANICAL] = getBcon(0x1025);
                chanceBSkills[BODY] = getBcon(0x1026);
                chanceBSkills[CHARISMA] = getBcon(0x1027);
                chanceBSkills[CREATIVITY] = getBcon(0x1028);
                chanceBSkills[LOGIC] = getBcon(0x1029);
                chanceBSkills[CLEANING] = getBcon(0x102B);
            }
            else // not people
            {
                chanceAchance = getBcon(0x103A);
                chanceBchance = getBcon(0x104E);
            }

            chanceAGood = new Bcon[10];
            chanceAGood[MONEY] = getBcon(0x102C);
            chanceAGood[JOB] = getBcon(0x102D);
            chanceABad = new Bcon[10]; // not pets
            chanceABad[MONEY] = getBcon(0x1036);
            chanceABad[JOB] = getBcon(0x1037);
            chanceBGood = new Bcon[10];
            chanceBGood[MONEY] = getBcon(0x1040);
            chanceBGood[JOB] = getBcon(0x1041);
            chanceBBad = new Bcon[10];
            chanceBBad[MONEY] = getBcon(0x104A);
            chanceBBad[JOB] = getBcon(0x104B);
            if (!isPetCareer) // not pets
            {
                chanceAGood[COOKING] = getBcon(0x102E);
                chanceAGood[MECHANICAL] = getBcon(0x102F);
                chanceAGood[BODY] = getBcon(0x1030);
                chanceAGood[CHARISMA] = getBcon(0x1031);
                chanceAGood[CREATIVITY] = getBcon(0x1032);
                chanceAGood[LOGIC] = getBcon(0x1033);
                chanceAGood[CLEANING] = getBcon(0x1035);
                chanceABad[COOKING] = getBcon(0x1038);
                chanceABad[MECHANICAL] = getBcon(0x1039);
                chanceABad[BODY] = getBcon(0x103A);
                chanceABad[CHARISMA] = getBcon(0x103B);
                chanceABad[CREATIVITY] = getBcon(0x103C);
                chanceABad[LOGIC] = getBcon(0x103D);
                chanceABad[CLEANING] = getBcon(0x103F);
                chanceBGood[COOKING] = getBcon(0x1042);
                chanceBGood[MECHANICAL] = getBcon(0x1043);
                chanceBGood[BODY] = getBcon(0x1044);
                chanceBGood[CHARISMA] = getBcon(0x1045);
                chanceBGood[CREATIVITY] = getBcon(0x1046);
                chanceBGood[LOGIC] = getBcon(0x1047);
                chanceBGood[CLEANING] = getBcon(0x1049);
                chanceBBad[COOKING] = getBcon(0x104C);
                chanceBBad[MECHANICAL] = getBcon(0x104D);
                chanceBBad[BODY] = getBcon(0x104E);
                chanceBBad[CHARISMA] = getBcon(0x104F);
                chanceBBad[CREATIVITY] = getBcon(0x1050);
                chanceBBad[LOGIC] = getBcon(0x1051);
                chanceBBad[CLEANING] = getBcon(0x1053);
            }
            if (isCastaway)
            {
                chanceAGood[FOOD] = getBcon(0x105A);
                chanceABad[FOOD] = getBcon(0x105B);
                chanceBGood[FOOD] = getBcon(0x105C);
                chanceBBad[FOOD] = getBcon(0x105D);
            }
        }

		private void saveFiles()
		{
            //if (isCastaway) return;
			if (catalogueDesc.Changed) catalogueDesc.SynchronizeUserData();

            if (lifeScore != null && lifeScore.Changed)
                lifeScore.SynchronizeUserData();
            if (PTO.Changed) PTO.SynchronizeUserData();

            if (AddRewardToInventory != null && AddRewardToInventory.Parent.Changed)
                AddRewardToInventory.Parent.SynchronizeUserData();

            if (JobUpgrade != null && JobUpgrade.Parent.Changed)
                JobUpgrade.Parent.SynchronizeUserData();

            if (tuning.Changed) tuning.SynchronizeUserData();

            // Job Details
            if (jobTitles.Changed) jobTitles.SynchronizeUserData();
            if (vehicle.Changed) vehicle.SynchronizeUserData();
			if (outfit.Changed) outfit.SynchronizeUserData();

            // Hours & Wages
            if (startHour.Changed) startHour.SynchronizeUserData();
			if (hoursWorked.Changed) hoursWorked.SynchronizeUserData();
            if (!isPetCareer)
            {
                if (wages.Changed) wages.SynchronizeUserData();
            }
            else
            {
                if (wagesDog.Changed) wagesDog.SynchronizeUserData();
                if (wagesCat.Changed) wagesCat.SynchronizeUserData();
            }
            if (isCastaway)
            {
                if (foodinc.Changed) foodinc.SynchronizeUserData();
                if (resinc.Changed) resinc.SynchronizeUserData();
            }
			if (daysWorked.Changed) daysWorked.SynchronizeUserData();

            for (int i = 0; i < 9; i++)
                if (motiveDeltas[i].Changed) motiveDeltas[i].SynchronizeUserData();

            // Promotion
            if (!isPetCareer)
            {
                foreach (Bcon b in skillReq)
                    if (b.Changed) b.SynchronizeUserData();
            }
            else
            {
                if (trick.Changed)
                {
                    trick.Clear();
                    for (short i = 0; i < noLevels; i++)
                    {
                        ListViewItem item = PromoList.Items[i];
                        short tr = (short)cbTrick.Items.IndexOf(item.SubItems[9].Text);
                        if (tr > 0)
                        {
                            trick.Add(tr);
                            trick.Add((short)(i + 1));
                        }
                    }
                    trick.SynchronizeUserData();
                }
            }
			if (friends.Changed) friends.SynchronizeUserData();
            if (!preuniv)
            {
                if (majors.Changed) majors.SynchronizeUserData();
                if (cclevels.Changed) cclevels.SynchronizeUserData();
            }

            // Chance Cards
            if (chanceCardsText.Changed) chanceCardsText.SynchronizeUserData();
			if (chanceChance.Changed) chanceChance.SynchronizeUserData();
            for (int i = 7; i < 9; i++)
            {
                if (chanceAGood[i].Changed) chanceAGood[i].SynchronizeUserData();
                if (chanceABad[i].Changed) chanceABad[i].SynchronizeUserData();
                if (chanceBGood[i].Changed) chanceBGood[i].SynchronizeUserData();
                if (chanceBBad[i].Changed) chanceBBad[i].SynchronizeUserData();
            }
            if (!isPetCareer)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (skillReq[i].Changed) skillReq[i].SynchronizeUserData();
                    if (chanceASkills[i].Changed) chanceASkills[i].SynchronizeUserData();
                    if (chanceBSkills[i].Changed) chanceBSkills[i].SynchronizeUserData();
                }
                for (int i = 0; i < 7; i++)
                {
                    // if (i == 6) continue;
                    if (chanceAGood[i].Changed) chanceAGood[i].SynchronizeUserData();
                    if (chanceABad[i].Changed) chanceABad[i].SynchronizeUserData();
                    if (chanceBGood[i].Changed) chanceBGood[i].SynchronizeUserData();
                    if (chanceBBad[i].Changed) chanceBBad[i].SynchronizeUserData();
                }
            }
            else
            {
                if (chanceAchance.Changed) chanceAchance.SynchronizeUserData();
                if (chanceBchance.Changed) chanceBchance.SynchronizeUserData();
            }
            if (isCastaway)
            {
                if (chanceAGood[9].Changed) chanceAGood[9].SynchronizeUserData();
                if (chanceABad[9].Changed) chanceABad[9].SynchronizeUserData();
                if (chanceBGood[9].Changed) chanceBGood[9].SynchronizeUserData();
                if (chanceBBad[9].Changed) chanceBBad[9].SynchronizeUserData();
            }
		}

        private void miAddLvl_Click(object sender, System.EventArgs e)
        {
            if (internalchg) return;
            internalchg = true;

            byte us = 1;
            List<StrItem> usitems = null;
            ushort newNoLevels = (ushort)(noLevels + 1);
            ushort newLevel = (ushort)(currentLevel + 1);
            tuning[0] = (short)newNoLevels;

            #region Job Details
            ushort newFemaleOffset = (ushort)(newNoLevels * 2);
            for (byte l = 1; l <= languageString.Count; l++)
            {
                // Make safe for empty languages
                for (int i = jobTitles[l].Count; i < newNoLevels * 4 + 1; i++) jobTitles.Add(l, "", "");
                List<StrItem> items = jobTitles[l];
                // Shift all female entries up to free male entries
                for (int i = noLevels - 1; i > 0; i--)
                {
                    items[newFemaleOffset + (i * 2) + 1].Title = items[femaleOffset + (i * 2) + 1].Title;
                    items[newFemaleOffset + (i * 2) + 2].Title = items[femaleOffset + (i * 2) + 2].Title;
                }
                // Shift female entries up to free new level
                for (int i = newNoLevels - 1; i > currentLevel; i--)
                {
                    items[newFemaleOffset + (i * 2) + 1].Title = items[newFemaleOffset + (i - 1) * 2 + 1].Title;
                    items[newFemaleOffset + (i * 2) + 2].Title = items[newFemaleOffset + (i - 1) * 2 + 2].Title;
                }
                // Shift male entries up to free new level
                for (int i = newNoLevels - 1; i > currentLevel; i--)
                {
                    items[i * 2 + 1].Title = items[(i - 1) * 2 + 1].Title;
                    items[i * 2 + 2].Title = items[(i - 1) * 2 + 2].Title;
                }
                // Clear text out of new level fields
                // (new level is currentLevel + 1, index is that - 1, so just use currentLevel)
                items[currentLevel * 2 + 1].Title = "";
                items[currentLevel * 2 + 2].Title = "";
                items[newFemaleOffset + currentLevel * 2 + 1].Title = "";
                items[newFemaleOffset + currentLevel * 2 + 2].Title = "";
            }
            usitems = jobTitles[us];
            // (new level is currentLevel + 1, index is that - 1, so just use currentLevel)
            usitems[currentLevel * 2 + 1].Title = "New Male Job Title";
            usitems[currentLevel * 2 + 2].Title = "New Male Job Desc";
            usitems[newFemaleOffset + currentLevel * 2 + 1].Title = "New Female Job Title";
            usitems[newFemaleOffset + currentLevel * 2 + 2].Title = "New Female Job Desc";
            #endregion

            insertGuid(outfit, currentLevel, 0);
            insertGuid(vehicle, currentLevel, 0x0C85AE14);

            #region Hours & Wages
            insertBcon(PTO, newLevel, 15);
            if (lifeScore != null)
                insertBcon(lifeScore, newLevel, 0);
            insertBcon(startHour, currentLevel + 1, 0);
            insertBcon(hoursWorked, currentLevel + 1, 1);
            if (!isPetCareer) // Currently Pet careers can't ever get here
            {
                insertBcon(wages, currentLevel + 1, 0);
            }
            else
            {
                insertBcon(wagesDog, currentLevel + 1, 0);
                insertBcon(wagesCat, currentLevel + 1, 0);
            }
            insertBcon(daysWorked, currentLevel + 1, 0);

            for (int i = 0; i < motiveDeltas.Length; i++)
                insertBcon(motiveDeltas[i], currentLevel + 1, 0);
            #endregion

            if (!preuniv) insertBcon(cclevels, currentLevel + 1, 0);

            #region Promotion
            if (!isPetCareer) // people
                for (int i = 0; i < skillReq.Length; i++)
                    insertBcon(skillReq[i], currentLevel + 1, 0);
            // nothing to do for Pets
            insertBcon(friends, currentLevel + 1, 0);
            #endregion

            #region Chance Cards
            insertBcon(chanceChance, currentLevel + 1, 0);
            if (!isPetCareer)
                for (int i = 0; i < chanceASkills.Length; i++)
                {
                    insertBcon(chanceASkills[i], currentLevel + 1, 0);
                    insertBcon(chanceBSkills[i], currentLevel + 1, 0);
                }

            if (!isPetCareer)
            {
                for (int i = 0; i < 7; i++)
                {
                    insertBcon(chanceAGood[i], currentLevel + 1, 0);
                    insertBcon(chanceABad[i], currentLevel + 1, 0);
                    insertBcon(chanceBGood[i], currentLevel + 1, 0);
                    insertBcon(chanceBBad[i], currentLevel + 1, 0);
                }
            }
            else
            {
                insertBcon(chanceAchance, currentLevel + 1, 50);
                insertBcon(chanceBchance, currentLevel + 1, 50);
            }

            for (int i = 7; i < chanceAGood.Length; i++)
            {
                insertBcon(chanceAGood[i], currentLevel + 1, 0);
                insertBcon(chanceABad[i], currentLevel + 1, 0);
                insertBcon(chanceBGood[i], currentLevel + 1, 0);
                insertBcon(chanceBBad[i], currentLevel + 1, 0);
            }
            #endregion

            #region Chance Cards Texts
            for (byte i = 1; i <= languageString.Count; i++)
            {
                for (int k = chanceCardsText[i].Count; k < newNoLevels * 12 + 19; k++)
                    chanceCardsText.Add(i, "", "");
                List<StrItem> items = chanceCardsText[i];
                for (int j = newNoLevels; j > newLevel; j--)
                    for (int k = 7; k < 19; k++)
                        items[j * 12 + k].Title = items[(j - 1) * 12 + k].Title;
                for (int k = 7; k < 19; k++)
                    items[newLevel * 12 + k].Title = "";
            }

            usitems = chanceCardsText[us];
            usitems[newLevel * 12 + 7].Title = "Choice A";
            usitems[newLevel * 12 + 8].Title = "Choice B";
            usitems[newLevel * 12 + 9].Title = "Male Text";
            usitems[newLevel * 12 + 10].Title = "Female Text";
            usitems[newLevel * 12 + 11].Title = "Pass A Male";
            usitems[newLevel * 12 + 12].Title = "Pass A Female";
            usitems[newLevel * 12 + 13].Title = "Fail A Male";
            usitems[newLevel * 12 + 14].Title = "Fail A Female";
            usitems[newLevel * 12 + 15].Title = "Pass B Male";
            usitems[newLevel * 12 + 16].Title = "Pass B Female";
            usitems[newLevel * 12 + 17].Title = "Fail B Male";
            usitems[newLevel * 12 + 18].Title = "Fail B Female";
            #endregion

            noLevelsChanged(newNoLevels);

            internalchg = false;

            stabalizecount();
        }

        private void miRemoveLvl_Click(object sender, System.EventArgs e)
        {
            if (internalchg) return;
            internalchg = true;
            this.tabControl1.Enabled = menuItem6.Enabled = false;
            this.lbcrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbcrap.ForeColor = System.Drawing.Color.HotPink;
            this.lbcrap.Text = "You now need to close\r\nCareer Editor then restart it";
            this.lbcrap.Visible = true;

            ushort newNoLevels = (ushort)(noLevels - 1);

            tuning[0] = (short)newNoLevels;

            PTO.RemoveAt(currentLevel);
            if (lifeScore != null)
                lifeScore.RemoveAt(currentLevel);

            #region Job Details
            ushort newFemaleOffset = (ushort)(newNoLevels * 2);
            for (byte l = 1; l <= languageString.Count; l++)
            {
                // Make safe for empty languages
                //for (int i = jobTitles[l].Count; i < noLevels * 4 + 1; i++) jobTitles.Add(l, "", ""); // this does nuffin, writing an empty string does not add a string
                try
                {
                    List<StrItem> items = jobTitles[l];
                    if (items.Count > noLevels * 4) // trying to clean an empty language chucks a wobbly
                    {
                        // Shift all entries down over removed level
                        for (int i = currentLevel; i < (noLevels * 2); i++)
                        {
                            items[(i - 1) * 2 + 1].Title = items[i * 2 + 1].Title;
                            items[(i - 1) * 2 + 2].Title = items[i * 2 + 2].Title;
                        }
                        // Shift female entries down over removed level
                        for (int i = currentLevel; i < noLevels; i++)
                        {
                            items[newFemaleOffset + (i - 1) * 2 + 1].Title = items[newFemaleOffset + (i * 2) + 1].Title;
                            items[newFemaleOffset + (i - 1) * 2 + 2].Title = items[newFemaleOffset + (i * 2) + 2].Title;
                        }
                        // Remove unused entries, must start at last and work back
                        int k = items.Count - 1;
                        for (int i = k; i > k - 4; i--)
                            jobTitles.Remove(items[i]);
                    }
                }
                catch { }
            }
            
            outfit.RemoveAt(currentLevel - 1);
            outfit.RemoveAt(currentLevel - 1);
            vehicle.RemoveAt(currentLevel - 1);
            vehicle.RemoveAt(currentLevel - 1);

            if (!preuniv) cclevels.RemoveAt(currentLevel);
            
            #endregion

            #region Hours & Wages
            startHour.RemoveAt(currentLevel);
            hoursWorked.RemoveAt(currentLevel);
            if (!isPetCareer)
            {
                wages.RemoveAt(currentLevel);
            }
            else
            {
                wagesDog.RemoveAt(currentLevel);
                wagesCat.RemoveAt(currentLevel);
            }
            daysWorked.RemoveAt(currentLevel);

            for (int i = 0; i < 9; i++)
                motiveDeltas[i].RemoveAt(currentLevel);
            #endregion

            #region Promotion
            if (!isPetCareer)
                for (int i = 0; i < skillReq.Length; i++)
                    skillReq[i].RemoveAt(currentLevel);
            // nothing to do for Pets
            friends.RemoveAt(currentLevel);
            #endregion

            #region Chance Cards

            chanceChance.RemoveAt(currentLevel);
            if (!isPetCareer)
                for (int i = 0; i < chanceASkills.Length; i++)
                {
                    chanceASkills[i].RemoveAt(currentLevel);
                    chanceBSkills[i].RemoveAt(currentLevel);
                }

            if (!isPetCareer)
                for (int i = 0; i < 7; i++)
                {
                    chanceAGood[i].RemoveAt(currentLevel);
                    chanceABad[i].RemoveAt(currentLevel);
                    chanceBGood[i].RemoveAt(currentLevel);
                    chanceBBad[i].RemoveAt(currentLevel);
                }
            else
            {
                chanceAchance.RemoveAt(currentLevel);
                chanceBchance.RemoveAt(currentLevel);
            }

            for (int i = 7; i < chanceAGood.Length; i++)
            {
                chanceAGood[i].RemoveAt(currentLevel);
                chanceABad[i].RemoveAt(currentLevel);
                chanceBGood[i].RemoveAt(currentLevel);
                chanceBBad[i].RemoveAt(currentLevel);
            }

            for (byte i = 1; i <= languageString.Count; i++)
            {
                // Make safe for empty languages
                //for (int k = chanceCardsText[i].Count; k < noLevels * 12 + 19; k++) // this does nuffing and no point trying
                //    chanceCardsText.Add(i, "", "");
                try
                {
                    List<StrItem> items = chanceCardsText[i];
                    if (items.Count > noLevels * 12) // trying to clean an empty language chucks a wobbly
                    {
                        // Shift entries down over removed level
                        for (int j = currentLevel; j < noLevels; j++)
                            for (int k = 7; k < 19; k++)
                                items[j * 12 + k].Title = items[(j + 1) * 12 + k].Title;

                        // Remove unused entries, must start at last and work back
                        for (int k = 18; k > 6; k--)
                            chanceCardsText.Remove(items[noLevels * 12 + k]);
                    }
                }
                catch { }
            }

            #endregion

            noLevelsChanged(newNoLevels);

            internalchg = false;

            stabalizecount();
        }

        private void stabalizecount()
        {
            if (noLevels > 10) return; // leave extras
            if (friends.Count < 11)
                friends.Add(0);
            if (friends.Count > 11)
                friends.RemoveAt(11);
            if (outfit.Count < 22)
            {
                outfit.Add(0);
                outfit.Add(0);
            }
            if (outfit.Count > 23)
            {
                outfit.RemoveAt(23);
                outfit.RemoveAt(22);
            }
            if (vehicle.Count < 22)
            {
                vehicle.Add(0);
                vehicle.Add(0);
            }
            if (vehicle.Count > 23)
            {
                vehicle.RemoveAt(23);
                vehicle.RemoveAt(22);
            }
            if (PTO.Count < 11)
                PTO.Add(0);
            if (PTO.Count > 11)
                PTO.RemoveAt(11);
            if (lifeScore != null)
            {
                if (lifeScore.Count < 11)
                    lifeScore.Add(0);
                if (lifeScore.Count > 11)
                    lifeScore.RemoveAt(11);
            }
            if (hoursWorked.Count > 11)
                hoursWorked.RemoveAt(11);
            if (hoursWorked.Count < 11)
                hoursWorked.Add(0);
            if (startHour.Count > 11)
                startHour.RemoveAt(11);
            if (startHour.Count < 11)
                startHour.Add(0);
            if (daysWorked.Count < 11)
                daysWorked.Add(0);
            if (daysWorked.Count > 11)
                daysWorked.RemoveAt(11);

            if (!preuniv)
            {
                if (cclevels.Count < 11)
                    cclevels.Add(0);
                if (cclevels.Count > 11)
                    cclevels.RemoveAt(11);
            }

            if (!isPetCareer)
            {
                if (wages.Count < 11)
                    wages.Add(0);
                if (wages.Count > 11)
                    wages.RemoveAt(11);
                for (int i = 0; i < chanceASkills.Length; i++)
                {
                    if (chanceASkills[i].Count > 11)
                        chanceASkills[i].RemoveAt(11);
                    if (chanceASkills[i].Count < 11)
                        chanceASkills[i].Add(0);
                    if (chanceBSkills[i].Count > 11)
                        chanceBSkills[i].RemoveAt(11);
                    if (chanceBSkills[i].Count < 11)
                        chanceBSkills[i].Add(0);
                }
                for (int i = 0; i < 7; i++)
                {
                    if (chanceAGood[i].Count > 11)
                        chanceAGood[i].RemoveAt(11);
                    if (chanceAGood[i].Count < 11)
                        chanceAGood[i].Add(0);
                    if (chanceABad[i].Count > 11)
                        chanceABad[i].RemoveAt(11);
                    if (chanceABad[i].Count < 11)
                        chanceABad[i].Add(0);
                    if (chanceBGood[i].Count > 11)
                        chanceBGood[i].RemoveAt(11);
                    if (chanceBGood[i].Count < 11)
                        chanceBGood[i].Add(0);
                    if (chanceBBad[i].Count > 11)
                        chanceBBad[i].RemoveAt(11);
                    if (chanceBBad[i].Count < 11)
                        chanceBBad[i].Add(0);
                }
                for (int i = 0; i < skillReq.Length; i++)
                {
                    if (skillReq[i].Count > 11)
                        skillReq[i].RemoveAt(11);
                    if (skillReq[i].Count < 11)
                        skillReq[i].Add(0);
                }
            }
            else
            {
                if (wagesDog.Count < 11)
                    wagesDog.Add(0);
                if (wagesDog.Count > 11)
                    wagesDog.RemoveAt(11);
                if (wagesCat.Count < 11)
                    wagesCat.Add(0);
                if (wagesCat.Count > 11)
                    wagesCat.RemoveAt(11);
            }
            for (int i = 0; i < SUNSHINE; i++)
            {
                if (motiveDeltas[i].Count < 11)
                    motiveDeltas[i].Add(0);
                if (motiveDeltas[i].Count > 11)
                    motiveDeltas[i].RemoveAt(11);
            }
            if (motiveDeltas[SUNSHINE].Count < 12)
                motiveDeltas[SUNSHINE].Add(0);
            if (motiveDeltas[SUNSHINE].Count > 12)
                motiveDeltas[SUNSHINE].RemoveAt(12);
            if (chanceChance.Count > 11)
                chanceChance.RemoveAt(11);
            if (chanceChance.Count < 11)
                chanceChance.Add(0);

            for (int i = 7; i < chanceAGood.Length; i++)
            {
                if (chanceAGood[i].Count > 11)
                    chanceAGood[i].RemoveAt(11);
                if (chanceAGood[i].Count < 11)
                    chanceAGood[i].Add(0);
                if (chanceABad[i].Count > 11)
                    chanceABad[i].RemoveAt(11);
                if (chanceABad[i].Count < 11)
                    chanceABad[i].Add(0);
                if (chanceBGood[i].Count > 11)
                    chanceBGood[i].RemoveAt(11);
                if (chanceBGood[i].Count < 11)
                    chanceBGood[i].Add(0);
                if (chanceBBad[i].Count > 11)
                    chanceBBad[i].RemoveAt(11);
                if (chanceBBad[i].Count < 11)
                    chanceBBad[i].Add(0);
            }
        }

        private void miEnglishOnly_Click(object sender, System.EventArgs e)
        {
            englishOnly = !englishOnly;
            // System.InvalidCastException: Unable to cast object of type 'System.Windows.Forms.ToolStripMenuItem' to type 'System.Windows.Forms.MenuItem'.
            ((System.Windows.Forms.ToolStripMenuItem)sender).Checked = englishOnly;
            if (englishOnly) Language.SelectedIndex = 0;
            Language.Enabled = !englishOnly;
        }

		private void CareerTitle_TextChanged(object sender, System.EventArgs e)
		{
            if (internalchg) return;
			string text = ((System.Windows.Forms.TextBox)sender).Text;
            if (((List<StrItem>)catalogueDesc[currentLanguage]).Count == 0)
                ((List<StrItem>)catalogueDesc[currentLanguage]).Add(new StrItem(catalogueDesc));
            catalogueDesc[currentLanguage][0].Title = text;
		}
        private void Language_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (internalchg) return;
            internalchg = true;

            int index = ((System.Windows.Forms.ComboBox)sender).SelectedIndex;
            currentLanguage = (byte)(index + 1);
            JobDetailList.Items.Clear();
            fillJobDetails();

            CareerTitle.Text = (((List<StrItem>)catalogueDesc[currentLanguage]).Count == 0) ? "" : catalogueDesc[currentLanguage, 0].Title;
            internalchg = false;

            ushort newLevel = currentLevel;
            currentLevel = 0;
            levelChanged(newLevel);
        }

        private void JobDetailList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (levelChanging) return;
            System.Windows.Forms.ListView.SelectedIndexCollection indices = ((System.Windows.Forms.ListView)sender).SelectedIndices;
			if ((indices.Count > 0) && (indices[0] < noLevels))
                levelChanged((ushort)(indices[0] + 1));
        }
        private void JobDetailsCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            jdpMale.DescValue = jdpFemale.DescValue;
        }
        private void jdpMale_TitleValueChanged(object sender, EventArgs e)
        {
            if (internalchg) return;
            string text = jdpMale.TitleValue;
            jobTitles[currentLanguage][currentLevel * 2 - 1].Title = text;
        }
        private void jdpMale_DescValueChanged(object sender, EventArgs e)
        {
            if (internalchg) return;
            string text = jdpMale.DescValue;
            jobTitles[currentLanguage][currentLevel * 2].Title = text;
        }
        private void jdpFemale_TitleValueChanged(object sender, EventArgs e)
        {
            if (internalchg) return;
            string text = jdpFemale.TitleValue;
            ListViewItem item = JobDetailList.Items[currentLevel - 1];
            item.SubItems[1].Text = text;
            jobTitles[currentLanguage][currentLevel * 2 - 1 + femaleOffset].Title = text;
		}
        private void jdpFemale_DescValueChanged(object sender, EventArgs e)
        {
            if (internalchg) return;
            string text = jdpFemale.DescValue;
            ListViewItem item = JobDetailList.Items[currentLevel - 1];
            item.SubItems[2].Text = text;
            jobTitles[currentLanguage][currentLevel * 2 + femaleOffset].Title = text;
		}
        private void gcOutfit_GUIDChooserValueChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            ListViewItem item = JobDetailList.Items[currentLevel - 1];
            if (isCastaway)
                item.SubItems[3].Text = StringFromGUID(gcOutfit.Value, CSoutfitGUID, CSoutfitName);
            else
                item.SubItems[3].Text = StringFromGUID(gcOutfit.Value, outfitGUID, outfitName);

            outfit[currentLevel * 2] = (short)(gcOutfit.Value & 0xffff);
            outfit[currentLevel * 2 + 1] = (short)(gcOutfit.Value >> 16 & 0xffff);
        }
        private void gcVehicle_GUIDChooserValueChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            ListViewItem item = JobDetailList.Items[currentLevel - 1];
            item.SubItems[4].Text = StringFromGUID(gcVehicle.Value, vehicleGUID, vehicleName);

            vehicle[currentLevel * 2] = (short)(gcVehicle.Value & 0xffff);
            vehicle[currentLevel * 2 + 1] = (short)(gcVehicle.Value >> 16 & 0xffff);
        }

        private void HoursWagesList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (levelChanging) return;
            System.Windows.Forms.ListView.SelectedIndexCollection indices = ((System.Windows.Forms.ListView)sender).SelectedIndices;
			if ((indices.Count > 0) && (indices[0] < noLevels))
                levelChanged((ushort)(indices[0] + 1));
        }
        private void lnudWork_ValueChanged(object sender, System.EventArgs e)
        {
            if (levelChanging || internalchg) return;
            if (isCastaway)
                resinc[currentLevel] = (short)lnudWages.Value;
            LabelledNumericUpDown nud = (LabelledNumericUpDown)sender;
            ListViewItem item = HoursWagesList.Items[currentLevel - 1];
            int i = -1;

            #region Hours
            List<LabelledNumericUpDown> lHours = new List<LabelledNumericUpDown>(new LabelledNumericUpDown[] {
                lnudWorkStart, lnudWorkHours,
            });
            List<Bcon> lbHours = new List<Bcon>(new Bcon[] { startHour, hoursWorked, });
            i = lHours.IndexOf(nud);
            if (i >= 0)
            {
                lbHours[i][currentLevel] = (short)nud.Value;
                item.SubItems[i + 1].Text = "" + nud.Value;
                tbWorkFinish.Text = Convert.ToString((startHour[currentLevel] + hoursWorked[currentLevel]) % 24);
                item.SubItems[3].Text = tbWorkFinish.Text;
                WorkChanged(currentLevel);
                return;
            }
            #endregion

            #region Wages
            if (isCastaway)
            {
                List<LabelledNumericUpDown> lWages = new List<LabelledNumericUpDown>(new LabelledNumericUpDown[] {
                lnudWages, lnudFoods, lnudWagesCat, });
                List<Bcon> lbWages = new List<Bcon>(new Bcon[] { wages, foodinc, wagesCat, });
                i = lWages.IndexOf(nud);
                if (i >= 0)
                {
                    lbWages[i][currentLevel] = (short)nud.Value;
                    item.SubItems[i + 4].Text = "" + nud.Value;
                    return;
                }
            }
            else
            {
                List<LabelledNumericUpDown> lWages = new List<LabelledNumericUpDown>(new LabelledNumericUpDown[] {
                lnudWages, lnudWagesDog, lnudWagesCat,
            });
                List<Bcon> lbWages = new List<Bcon>(new Bcon[] { wages, wagesDog, wagesCat, });
                i = lWages.IndexOf(nud);
                if (i >= 0)
                {
                    lbWages[i][currentLevel] = (short)nud.Value;
                    item.SubItems[i + 4].Text = "" + nud.Value;
                    return;
                }
            }

            #endregion
        }
        private void lnudWork_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            lnudWork_ValueChanged(sender, new EventArgs());
        }
		private void Workday_CheckedChanged(object sender, System.EventArgs e)
		{
            if (levelChanging || internalchg) return;

            List<CheckBox> lcb = new List<CheckBox>(new CheckBox[] {
                WorkMonday, WorkTuesday, WorkWednesday, WorkThursday, WorkFriday, WorkSaturday, WorkSunday, 
            });

            int index = lcb.IndexOf((CheckBox)sender);
            if (index < 0 || index > 6) return; // crash!

            Boolset dw = new Boolset((byte)daysWorked[currentLevel]);
            dw[index] = ((CheckBox)sender).Checked;
            daysWorked[currentLevel] = (byte)dw;

            ListViewItem item = HoursWagesList.Items[currentLevel - 1];
            item.SubItems[index + 7].Text = "" + ((CheckBox)sender).Checked;
        }
        private void numPTO_ValueChanged(object sender, System.EventArgs e)
        {
            if (levelChanging || internalchg) return;
            PTO[currentLevel] = (short)numPTO.Value;
        }
        private void numLscore_ValueChanged(object sender, System.EventArgs e)
        {
            if (levelChanging || internalchg) return;
            lifeScore[currentLevel] = (short)numLscore.Value;
        }
		private void nudMotive_ValueChanged(object sender, System.EventArgs e)
		{
            if (levelChanging || internalchg) return;
            NumericUpDown nud = (NumericUpDown)sender;
            ListViewItem item = HoursWagesList.Items[currentLevel - 1];
            int i = -1;

            #region Motives
            List<NumericUpDown> lMotive = new List<NumericUpDown>(new NumericUpDown[] {
                WorkHunger, WorkComfort, WorkHygiene, WorkBladder,
                WorkEnergy, WorkFun, WorkPublic, WorkSunshine,
            });
            List<NumericUpDown> lMotiveTotal = new List<NumericUpDown>(new NumericUpDown[] {
                HungerTotal, ComfortTotal, HygieneTotal, BladderTotal,
                EnergyTotal, FunTotal, PublicTotal, SunshineTotal,
            });
            i = lMotive.IndexOf(nud);
            if (i >= 0)
            {
                motiveDeltas[i][currentLevel] = (short)nud.Value;
                lMotiveTotal[i].Value = motiveDeltas[i][currentLevel] * hoursWorked[currentLevel];
                return;
            }
            #endregion
        }
        private void nudMotive_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            nudMotive_ValueChanged(sender, new EventArgs());
		}

        private void PromoList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (levelChanging) return;
            System.Windows.Forms.ListView.SelectedIndexCollection indices = ((System.Windows.Forms.ListView)sender).SelectedIndices;
            if ((indices.Count > 0) && (indices[0] < noLevels))
                levelChanged((ushort)(indices[0] + 1));
        }
		private void Promo_ValueChanged(object sender, System.EventArgs e)
		{
            if (levelChanging || internalchg || sender == null) return;
            if (isPetCareer)
            {
                friends[currentLevel] = (short)PromoFriends.Value;
                ListViewItem itemx = PromoList.Items[currentLevel - 1];
                itemx.SubItems[8].Text = "" + (short)PromoFriends.Value;
                return;
            }
            ArrayList alNud = new ArrayList(new NumericUpDown[] {
                PromoCooking, PromoMechanical, PromoBody, PromoCharisma,
                PromoCreativity, PromoLogic, PromoCleaning, PromoFriends,
            });
            int i = alNud.IndexOf((NumericUpDown)sender);
            if (i == -1) return; // crash!

            ListViewItem item = PromoList.Items[currentLevel - 1];
            short val = (short)((NumericUpDown)sender).Value;
            item.SubItems[i + 1].Text = "" + val;

            if (i < skillReq.Length)
                skillReq[i][currentLevel] = (short)(val * 100);
            else switch (i - skillReq.Length)
                {
                    case 0:
                        friends[currentLevel] = val;
                        break;
                }
        }
		private void Promo_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            Promo_ValueChanged(sender, e);		
		}
        private void cbTrick_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (levelChanging || internalchg) return;
            ListViewItem item = PromoList.Items[currentLevel - 1];
            item.SubItems[9].Text = (String)((ComboBox)sender).SelectedItem;

            List<short[]> lTrick = new List<short[]>();
            for (int i = 0; i < trick.Count / 2; i++)
                lTrick.Add(new short[] { trick[i * 2], trick[i * 2 + 1] });

            short[] result = new short[] { (short)((ComboBox)sender).SelectedIndex, (short)currentLevel };

            int insPtr = 0;
            while (insPtr < lTrick.Count && currentLevel > lTrick[insPtr][1])
                insPtr++;

            if (insPtr < lTrick.Count)
            {
                if (currentLevel == lTrick[insPtr][1])
                    lTrick[insPtr] = result;
                else
                    lTrick.Insert(insPtr, result);
            }
            else
                lTrick.Add(result);

            trick.Clear();
            foreach (short[] pair in lTrick)
            {
                trick.Add(pair[0]);
                trick.Add(pair[1]);
            }
        }

        private void lnudChanceCurrentLevel_ValueChanged(object sender, EventArgs e)
        {
            if (levelChanging || internalchg) return;
            levelChanged((ushort)lnudChanceCurrentLevel.Value);
        }
        private void ChanceCopy_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
            ChanceTextFemale.Text = ChanceTextMale.Text;
        }

        private void textBox1g_TextChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if (sender.GetType() == typeof(TextBox))
                {
                    tbox = sender as TextBox;
                    lbrewguid.Text = pjse.GUIDIndex.TheGUIDIndex[SimPe.Helper.HexStringToUInt(tbox.Text)];
                }
            }
        }

        private void exApply_Click(object sender, EventArgs e)
        {   
            exinit = getBcon(0x1000);

            for (int i = 1; i < 11; i++)
            {
                extraAG[i] = 0;
                extraAB[i] = 0;
                extraBG[i] = 0;
                extraBB[i] = 0;
            }

            short boob1 = 0;
            exinit[0] = boob1;

            exinit.SynchronizeUserData();
            extraAG.SynchronizeUserData();
            extraAB.SynchronizeUserData();
            extraBG.SynchronizeUserData();
            extraBB.SynchronizeUserData();
        }

        private void setmajors()
        {
            int boobr = getBcon(0x1056)[1];
            if (boobr >= 32768) boobr -= 32768;
            if (boobr >= 16384) boobr -= 16384;
            if (boobr >= 8192) boobr -= 8192;
            if (boobr >= 4096) boobr -= 4096;
            if (boobr >= 2048) boobr -= 2048;
            if (boobr >= 1024) { boobr -= 1024; this.cbrphyco.Checked = true; } else this.cbrphyco.Checked = false;
            if (boobr >= 512) { boobr -= 512; this.cbrpolit.Checked = true; } else this.cbrpolit.Checked = false;
            if (boobr >= 256) { boobr -= 256; this.cbrphysi.Checked = true; } else this.cbrphysi.Checked = false;
            if (boobr >= 128) { boobr -= 128; this.cbrphilo.Checked = true; } else this.cbrphilo.Checked = false;
            if (boobr >= 64) { boobr -= 64; this.cbrmaths.Checked = true; } else this.cbrmaths.Checked = false;
            if (boobr >= 32) { boobr -= 32; this.cbrliter.Checked = true; } else this.cbrliter.Checked = false;
            if (boobr >= 16) { boobr -= 16; this.cbrhisto.Checked = true; } else this.cbrhisto.Checked = false;
            if (boobr >= 8) { boobr -= 8; this.cbrecon.Checked = true; } else this.cbrecon.Checked = false;
            if (boobr >= 4) { boobr -= 4; this.cbrdrama.Checked = true; } else this.cbrdrama.Checked = false;
            if (boobr >= 2) { boobr -= 2; this.cbrbiol.Checked = true; } else this.cbrbiol.Checked = false;
            if (boobr >= 1) this.cbrArt.Checked = true; else this.cbrArt.Checked = false;

            int booba = getBcon(0x1056)[2];
            if (booba >= 32768) booba -= 32768;
            if (booba >= 16384) booba -= 16384;
            if (booba >= 8192) booba -= 8192;
            if (booba >= 4096) booba -= 4096;
            if (booba >= 2048) booba -= 2048;
            if (booba >= 1024) { booba -= 1024; this.cbaphyco.Checked = true; } else this.cbaphyco.Checked = false;
            if (booba >= 512) { booba -= 512; this.cbapolit.Checked = true; } else this.cbapolit.Checked = false;
            if (booba >= 256) { booba -= 256; this.cbaphysi.Checked = true; } else this.cbaphysi.Checked = false;
            if (booba >= 128) { booba -= 128; this.cbrahilo.Checked = true; } else this.cbrahilo.Checked = false;
            if (booba >= 64) { booba -= 64; this.cbamaths.Checked = true; } else this.cbamaths.Checked = false;
            if (booba >= 32) { booba -= 32; this.cbaliter.Checked = true; } else this.cbaliter.Checked = false;
            if (booba >= 16) { booba -= 16; this.cbahisto.Checked = true; } else this.cbahisto.Checked = false;
            if (booba >= 8) { booba -= 8; this.cbaecon.Checked = true; } else this.cbaecon.Checked = false;
            if (booba >= 4) { booba -= 4; this.cbadrama.Checked = true; } else this.cbadrama.Checked = false;
            if (booba >= 2) { booba -= 2; this.cbabiol.Checked = true; } else this.cbabiol.Checked = false;
            if (booba >= 1) this.cbaArt.Checked = true; else this.cbaArt.Checked = false;
        }

        private void btmajApply_Click(object sender, EventArgs e)
        {
            majors[1] = majors[2] = 0;
            if (cbrArt.Checked) majors[1] = 1;
            if (cbrbiol.Checked) majors[1] += 2;
            if (cbrdrama.Checked) majors[1] += 4;
            if (cbrecon.Checked) majors[1] += 8;
            if (cbrhisto.Checked) majors[1] += 16;
            if (cbrliter.Checked) majors[1] += 32;
            if (cbrmaths.Checked) majors[1] += 64;
            if (cbrhisto.Checked) majors[1] += 128;
            if (cbrphysi.Checked) majors[1] += 256;
            if (cbrpolit.Checked) majors[1] += 512;
            if (cbrphyco.Checked) majors[1] += 1024;

            if (cbaArt.Checked) majors[2] = 1;
            if (cbabiol.Checked) majors[2] += 2;
            if (cbadrama.Checked) majors[2] += 4;
            if (cbaecon.Checked) majors[2] += 8;
            if (cbahisto.Checked) majors[2] += 16;
            if (cbaliter.Checked) majors[2] += 32;
            if (cbamaths.Checked) majors[2] += 64;
            if (cbrahilo.Checked) majors[2] += 128;
            if (cbaphysi.Checked) majors[2] += 256;
            if (cbapolit.Checked) majors[2] += 512;
            if (cbaphyco.Checked) majors[2] += 1024;

            majors.SynchronizeUserData();
        }

        private void btUgrade_Click(object sender, EventArgs e)
        {
            bool ok = false;
            if (getBcon(0x1056) == null)
                ok = makeBcon(0x1056, 2, "Tuning - Flags");
            if (getBcon(0x1057) == null)
                ok = makeBcon(0x1057, 10, "Tuning - Chance Card Levels");
            if (getBcon(0x1058) == null)
                ok = makeBcon(0x1058, 1, "Top Memory");
            if (getBcon(0x1059) == null && !isPetCareer)
                ok = makeBcon(0x1059, 11, "Motive Deltas - Plantsim Sunshine");
            if (ok)
            {
                this.btUgrade.Visible = false;
                this.tabControl1.Enabled = menuItem6.Enabled = false;
                this.lbcrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                this.lbcrap.ForeColor = System.Drawing.Color.HotPink;
                this.lbcrap.Text = "You now need to close\r\nCareer Editor then restart it";
                this.lbcrap.Visible = true;
            }
        }

        private void cbischance_CheckedChanged(object sender, EventArgs e)
        {
            if (internalchg) return;
            if (cbischance.Checked) cclevels[currentLevel] = (short)1;
            else cclevels[currentLevel] = (short)0;
        }

        private void lnudChancePercent_ValueChanged(object sender, EventArgs e)
        {
            cpChoiceA.HaveSkills = cpChoiceB.HaveSkills = (lnudChancePercent.Value < 0 && !isPetCareer);
        }

        private void lnudFoods_ValueChanged(object sender, EventArgs e)
        {
            if (internalchg) return;
            foodinc[currentLevel] = (short)lnudFoods.Value;
            lnudWork_ValueChanged(sender, e);
        }
    }
}
