// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;


namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class CareerEditor : Form
	{
		#region Windows Form Designer generated code

		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private TabControl tabControl1;
		private TextBox CareerTitle;
		private Label label3;
		private System.Windows.Forms.TabPage tabPage1;
		private Label label1;
		private TextBox CareerLvls;
		private GroupBox gbJLDetails;
		private ComboBox Language;
		private Label label10;
		private GroupBox gbJLHoursWages;
		private GroupBox gbJLPromo;
		private NumericUpDown PromoBody;
		private NumericUpDown PromoMechanical;
		private NumericUpDown PromoCooking;
		private NumericUpDown PromoCharisma;
		private NumericUpDown PromoFriends;
		private NumericUpDown PromoCleaning;
		private NumericUpDown PromoLogic;
		private NumericUpDown PromoCreativity;
		private Label label34;
		private Label label35;
		private Label label36;
		private Label label37;
		private Label label38;
		private Label label39;
		private Label label40;
		private Label label41;
		private ListView JobDetailList;
		private ColumnHeader JdLvl;
		private ColumnHeader JdJobTitle;
		private ColumnHeader JdDesc;
		private ColumnHeader JdOutfit;
		private ColumnHeader JdVehicle;
		private ListView HoursWagesList;
		private ColumnHeader HwLvl;
		private ColumnHeader HwStart;
		private ColumnHeader HwHours;
		private ColumnHeader HwEnd;
		private ColumnHeader HwWages;
		private ColumnHeader HwCatWages;
		private ColumnHeader HwDogWages;
		private ColumnHeader HwSun;
		private ColumnHeader HwMon;
		private ColumnHeader HwTue;
		private ColumnHeader HwWed;
		private ColumnHeader HwThu;
		private ColumnHeader HwFri;
		private ColumnHeader HwSat;
		private ListView PromoList;
		private ColumnHeader PrLvl;
		private ColumnHeader PrCooking;
		private ColumnHeader PrMechanical;
		private ColumnHeader PrCharisma;
		private ColumnHeader PrBody;
		private ColumnHeader PrCreativity;
		private ColumnHeader PrLogic;
		private ColumnHeader PrCleaning;
		private ColumnHeader PrFriends;
		private GroupBox gbPromo;
		private GroupBox gbJobDetails;
		private MenuStrip mainMenu1;
		private ToolStripMenuItem menuItem1;
		private ToolStripMenuItem miEnglishOnly;
		private ToolStripMenuItem menuItem6;
		private ToolStripMenuItem miAddLvl;
		private ToolStripMenuItem miRemoveLvl;
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
		private System.Windows.Forms.TabPage tabPage5;
		private EffectPanel epPassA;
		private System.Windows.Forms.TabPage tabPage6;
		private EffectPanel epFailA;
		private System.Windows.Forms.TabPage tabPage7;
		private EffectPanel epPassB;
		private System.Windows.Forms.TabPage tabPage8;
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
		private System.Windows.Forms.TabPage tabPagMajor;
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
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
			}
			base.Dispose(disposing);
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

			gcReward.KnownObjects = new object[] { new List<string>(rewardName), new List<uint>(rewardGUID) };
			gcUpgrade.KnownObjects = new object[] { new List<string>(upgradeName), new List<uint>(upgradeGUID) };
			gcOutfit.KnownObjects = new object[] { new List<string>(outfitName), new List<uint>(outfitGUID) };
			gcVehicle.KnownObjects = new object[] { new List<string>(vehicleName), new List<uint>(vehicleGUID) };
			internalchg = false;

			gcUpgrade.ComboBoxWidth = gcReward.ComboBoxWidth = 220;
			gcOutfit.ComboBoxWidth = gcVehicle.ComboBoxWidth = 300;
			pictureBox2.Image = GetIcon.Information;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CareerEditor));
			tabPage4 = new System.Windows.Forms.TabPage();
			pictureBox2 = new PictureBox();
			lnudPetChancePercent = new LabelledNumericUpDown();
			cbischance = new CheckBox();
			lnudChanceCurrentLevel = new LabelledNumericUpDown();
			lnudChancePercent = new LabelledNumericUpDown();
			cpChoiceA = new ChoicePanel();
			cpChoiceB = new ChoicePanel();
			ChanceTextMale = new TextBox();
			ChanceCopy = new LinkLabel();
			ChanceTextFemale = new TextBox();
			tcChanceOutcome = new TabControl();
			tabPage5 = new System.Windows.Forms.TabPage();
			epPassA = new EffectPanel();
			tabPage6 = new System.Windows.Forms.TabPage();
			epFailA = new EffectPanel();
			tabPage7 = new System.Windows.Forms.TabPage();
			epPassB = new EffectPanel();
			tabPage8 = new System.Windows.Forms.TabPage();
			epFailB = new EffectPanel();
			label51 = new Label();
			label52 = new Label();
			tabPage3 = new System.Windows.Forms.TabPage();
			gbJLPromo = new GroupBox();
			PromoList = new ListView();
			PrLvl = new ColumnHeader();
			PrCooking = new ColumnHeader();
			PrMechanical = new ColumnHeader();
			PrBody = new ColumnHeader();
			PrCharisma = new ColumnHeader();
			PrCreativity = new ColumnHeader();
			PrLogic = new ColumnHeader();
			PrCleaning = new ColumnHeader();
			PrFriends = new ColumnHeader();
			PrTrick = new ColumnHeader();
			gbPromo = new GroupBox();
			cbTrick = new ComboBox();
			label101 = new Label();
			label41 = new Label();
			label40 = new Label();
			label39 = new Label();
			label38 = new Label();
			label37 = new Label();
			label36 = new Label();
			label35 = new Label();
			label34 = new Label();
			PromoFriends = new NumericUpDown();
			PromoCleaning = new NumericUpDown();
			PromoLogic = new NumericUpDown();
			PromoCreativity = new NumericUpDown();
			PromoCharisma = new NumericUpDown();
			PromoBody = new NumericUpDown();
			PromoMechanical = new NumericUpDown();
			PromoCooking = new NumericUpDown();
			tabPage2 = new System.Windows.Forms.TabPage();
			gbHoursWages = new GroupBox();
			tbWorkFinish = new TextBox();
			label48 = new Label();
			lnudFoods = new LabelledNumericUpDown();
			lnudWorkStart = new LabelledNumericUpDown();
			lnudWorkHours = new LabelledNumericUpDown();
			lnudWages = new LabelledNumericUpDown();
			lnudWagesDog = new LabelledNumericUpDown();
			lbPTO = new Label();
			lnudWagesCat = new LabelledNumericUpDown();
			WorkMonday = new CheckBox();
			WorkTuesday = new CheckBox();
			WorkWednesday = new CheckBox();
			WorkThursday = new CheckBox();
			WorkFriday = new CheckBox();
			WorkSaturday = new CheckBox();
			WorkSunday = new CheckBox();
			gbHWMotives = new GroupBox();
			label27 = new Label();
			label24 = new Label();
			ComfortHours = new NumericUpDown();
			HygieneTotal = new NumericUpDown();
			BladderTotal = new NumericUpDown();
			label21 = new Label();
			WorkBladder = new NumericUpDown();
			label23 = new Label();
			label19 = new Label();
			WorkComfort = new NumericUpDown();
			HungerHours = new NumericUpDown();
			EnergyHours = new NumericUpDown();
			label25 = new Label();
			WorkPublic = new NumericUpDown();
			WorkHunger = new NumericUpDown();
			BladderHours = new NumericUpDown();
			ComfortTotal = new NumericUpDown();
			label22 = new Label();
			HungerTotal = new NumericUpDown();
			HygieneHours = new NumericUpDown();
			WorkEnergy = new NumericUpDown();
			WorkFun = new NumericUpDown();
			WorkSunshine = new NumericUpDown();
			PublicHours = new NumericUpDown();
			label20 = new Label();
			SunshineTotal = new NumericUpDown();
			EnergyTotal = new NumericUpDown();
			FunTotal = new NumericUpDown();
			PublicTotal = new NumericUpDown();
			label33 = new Label();
			label32 = new Label();
			label31 = new Label();
			label30 = new Label();
			label28 = new Label();
			label26 = new Label();
			FunHours = new NumericUpDown();
			WorkHygiene = new NumericUpDown();
			SunshineHours = new NumericUpDown();
			lbLscore = new Label();
			numLscore = new NumericUpDown();
			numPTO = new NumericUpDown();
			gbJLHoursWages = new GroupBox();
			HoursWagesList = new ListView();
			HwLvl = new ColumnHeader();
			HwStart = new ColumnHeader();
			HwHours = new ColumnHeader();
			HwEnd = new ColumnHeader();
			HwWages = new ColumnHeader();
			HwDogWages = new ColumnHeader();
			HwCatWages = new ColumnHeader();
			HwMon = new ColumnHeader();
			HwTue = new ColumnHeader();
			HwWed = new ColumnHeader();
			HwThu = new ColumnHeader();
			HwFri = new ColumnHeader();
			HwSat = new ColumnHeader();
			HwSun = new ColumnHeader();
			tabControl1 = new TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			gbJobDetails = new GroupBox();
			gcVehicle = new GUIDChooser();
			gcOutfit = new GUIDChooser();
			JobDetailsCopy = new LinkLabel();
			jdpFemale = new JobDescPanel();
			jdpMale = new JobDescPanel();
			gbJLDetails = new GroupBox();
			JobDetailList = new ListView();
			JdLvl = new ColumnHeader();
			JdJobTitle = new ColumnHeader();
			JdDesc = new ColumnHeader();
			JdOutfit = new ColumnHeader();
			JdVehicle = new ColumnHeader();
			tabPagMajor = new System.Windows.Forms.TabPage();
			btmajApply = new Button();
			gbmajaffil = new GroupBox();
			label47 = new Label();
			cbaphyco = new CheckBox();
			cbapolit = new CheckBox();
			cbaphysi = new CheckBox();
			cbrahilo = new CheckBox();
			cbamaths = new CheckBox();
			cbaliter = new CheckBox();
			cbahisto = new CheckBox();
			cbaecon = new CheckBox();
			cbadrama = new CheckBox();
			cbabiol = new CheckBox();
			cbaArt = new CheckBox();
			gbrequir = new GroupBox();
			label29 = new Label();
			cbrphyco = new CheckBox();
			cbrpolit = new CheckBox();
			cbrphysi = new CheckBox();
			cbrphilo = new CheckBox();
			cbrmaths = new CheckBox();
			cbrliter = new CheckBox();
			cbrhisto = new CheckBox();
			cbrecon = new CheckBox();
			cbrdrama = new CheckBox();
			cbrbiol = new CheckBox();
			cbrArt = new CheckBox();
			btexApply = new Button();
			lbrewguid = new Label();
			checkBox42 = new CheckBox();
			checkBox43 = new CheckBox();
			checkBox44 = new CheckBox();
			checkBox45 = new CheckBox();
			textBox17 = new TextBox();
			textBox18 = new TextBox();
			label46 = new Label();
			checkBox38 = new CheckBox();
			checkBox39 = new CheckBox();
			checkBox40 = new CheckBox();
			checkBox41 = new CheckBox();
			textBox15 = new TextBox();
			textBox16 = new TextBox();
			label45 = new Label();
			checkBox34 = new CheckBox();
			checkBox35 = new CheckBox();
			checkBox36 = new CheckBox();
			checkBox37 = new CheckBox();
			textBox13 = new TextBox();
			textBox14 = new TextBox();
			label44 = new Label();
			checkBox30 = new CheckBox();
			checkBox31 = new CheckBox();
			checkBox32 = new CheckBox();
			checkBox33 = new CheckBox();
			textBox11 = new TextBox();
			textBox12 = new TextBox();
			label43 = new Label();
			checkBox26 = new CheckBox();
			checkBox27 = new CheckBox();
			checkBox28 = new CheckBox();
			checkBox29 = new CheckBox();
			textBox9 = new TextBox();
			textBox10 = new TextBox();
			label42 = new Label();
			checkBox22 = new CheckBox();
			checkBox23 = new CheckBox();
			checkBox24 = new CheckBox();
			checkBox25 = new CheckBox();
			textBox7 = new TextBox();
			textBox8 = new TextBox();
			label17 = new Label();
			checkBox18 = new CheckBox();
			checkBox19 = new CheckBox();
			checkBox20 = new CheckBox();
			checkBox21 = new CheckBox();
			textBox5 = new TextBox();
			textBox6 = new TextBox();
			label16 = new Label();
			checkBox14 = new CheckBox();
			checkBox15 = new CheckBox();
			checkBox16 = new CheckBox();
			checkBox17 = new CheckBox();
			textBox3 = new TextBox();
			textBox4 = new TextBox();
			label15 = new Label();
			checkBox10 = new CheckBox();
			checkBox11 = new CheckBox();
			checkBox12 = new CheckBox();
			checkBox13 = new CheckBox();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			label14 = new Label();
			label9 = new Label();
			label8 = new Label();
			label7 = new Label();
			label6 = new Label();
			label5 = new Label();
			label4 = new Label();
			checkBox6 = new CheckBox();
			checkBox5 = new CheckBox();
			checkBox4 = new CheckBox();
			checkBox3 = new CheckBox();
			label2 = new Label();
			checkBox1 = new CheckBox();
			CareerLvls = new TextBox();
			label1 = new Label();
			CareerTitle = new TextBox();
			label3 = new Label();
			Language = new ComboBox();
			label10 = new Label();
			mainMenu1 = new MenuStrip();
			menuItem6 = new ToolStripMenuItem();
			miAddLvl = new ToolStripMenuItem();
			miRemoveLvl = new ToolStripMenuItem();
			menuItem1 = new ToolStripMenuItem();
			miEnglishOnly = new ToolStripMenuItem();
			gcUpgrade = new GUIDChooser();
			gcReward = new GUIDChooser();
			lbcrap = new Label();
			btUgrade = new Button();
			pictureBox1 = new PictureBox();
			toolTip1 = new ToolTip(components);
			tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			tcChanceOutcome.SuspendLayout();
			tabPage5.SuspendLayout();
			tabPage6.SuspendLayout();
			tabPage7.SuspendLayout();
			tabPage8.SuspendLayout();
			tabPage3.SuspendLayout();
			gbJLPromo.SuspendLayout();
			gbPromo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)PromoFriends).BeginInit();
			((System.ComponentModel.ISupportInitialize)PromoCleaning).BeginInit();
			((System.ComponentModel.ISupportInitialize)PromoLogic).BeginInit();
			((System.ComponentModel.ISupportInitialize)PromoCreativity).BeginInit();
			((System.ComponentModel.ISupportInitialize)PromoCharisma).BeginInit();
			((System.ComponentModel.ISupportInitialize)PromoBody).BeginInit();
			((System.ComponentModel.ISupportInitialize)PromoMechanical).BeginInit();
			((System.ComponentModel.ISupportInitialize)PromoCooking).BeginInit();
			tabPage2.SuspendLayout();
			gbHoursWages.SuspendLayout();
			gbHWMotives.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ComfortHours).BeginInit();
			((System.ComponentModel.ISupportInitialize)HygieneTotal).BeginInit();
			((System.ComponentModel.ISupportInitialize)BladderTotal).BeginInit();
			((System.ComponentModel.ISupportInitialize)WorkBladder).BeginInit();
			((System.ComponentModel.ISupportInitialize)WorkComfort).BeginInit();
			((System.ComponentModel.ISupportInitialize)HungerHours).BeginInit();
			((System.ComponentModel.ISupportInitialize)EnergyHours).BeginInit();
			((System.ComponentModel.ISupportInitialize)WorkPublic).BeginInit();
			((System.ComponentModel.ISupportInitialize)WorkHunger).BeginInit();
			((System.ComponentModel.ISupportInitialize)BladderHours).BeginInit();
			((System.ComponentModel.ISupportInitialize)ComfortTotal).BeginInit();
			((System.ComponentModel.ISupportInitialize)HungerTotal).BeginInit();
			((System.ComponentModel.ISupportInitialize)HygieneHours).BeginInit();
			((System.ComponentModel.ISupportInitialize)WorkEnergy).BeginInit();
			((System.ComponentModel.ISupportInitialize)WorkFun).BeginInit();
			((System.ComponentModel.ISupportInitialize)WorkSunshine).BeginInit();
			((System.ComponentModel.ISupportInitialize)PublicHours).BeginInit();
			((System.ComponentModel.ISupportInitialize)SunshineTotal).BeginInit();
			((System.ComponentModel.ISupportInitialize)EnergyTotal).BeginInit();
			((System.ComponentModel.ISupportInitialize)FunTotal).BeginInit();
			((System.ComponentModel.ISupportInitialize)PublicTotal).BeginInit();
			((System.ComponentModel.ISupportInitialize)FunHours).BeginInit();
			((System.ComponentModel.ISupportInitialize)WorkHygiene).BeginInit();
			((System.ComponentModel.ISupportInitialize)SunshineHours).BeginInit();
			((System.ComponentModel.ISupportInitialize)numLscore).BeginInit();
			((System.ComponentModel.ISupportInitialize)numPTO).BeginInit();
			gbJLHoursWages.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			gbJobDetails.SuspendLayout();
			gbJLDetails.SuspendLayout();
			tabPagMajor.SuspendLayout();
			gbmajaffil.SuspendLayout();
			gbrequir.SuspendLayout();
			mainMenu1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			//
			// tabPage4
			//
			tabPage4.Controls.Add(pictureBox2);
			tabPage4.Controls.Add(lnudPetChancePercent);
			tabPage4.Controls.Add(cbischance);
			tabPage4.Controls.Add(lnudChanceCurrentLevel);
			tabPage4.Controls.Add(lnudChancePercent);
			tabPage4.Controls.Add(cpChoiceA);
			tabPage4.Controls.Add(cpChoiceB);
			tabPage4.Controls.Add(ChanceTextMale);
			tabPage4.Controls.Add(ChanceCopy);
			tabPage4.Controls.Add(ChanceTextFemale);
			tabPage4.Controls.Add(tcChanceOutcome);
			tabPage4.Controls.Add(label51);
			tabPage4.Controls.Add(label52);
			tabPage4.Location = new System.Drawing.Point(4, 22);
			tabPage4.Name = "tabPage4";
			tabPage4.Size = new System.Drawing.Size(1092, 534);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "Chance Cards";
			//
			// pictureBox2
			//
			pictureBox2.Location = new System.Drawing.Point(343, 0);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(30, 30);
			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 8;
			pictureBox2.TabStop = false;
			toolTip1.SetToolTip(pictureBox2, resources.GetString("pictureBox2.ToolTip"));
			//
			// lnudPetChancePercent
			//
			lnudPetChancePercent.AutoSize = true;
			lnudPetChancePercent.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			lnudPetChancePercent.FlowDirection = FlowDirection.LeftToRight;
			lnudPetChancePercent.Label = "Chance for B %";
			lnudPetChancePercent.LabelAnchor = AnchorStyles.Top | AnchorStyles.Left;
			lnudPetChancePercent.Location = new System.Drawing.Point(379, 2);
			lnudPetChancePercent.Margin = new Padding(0);
			lnudPetChancePercent.Maximum = new decimal(new int[] {
			100,
			0,
			0,
			0});
			lnudPetChancePercent.Minimum = new decimal(new int[] {
			0,
			0,
			0,
			0});
			lnudPetChancePercent.Name = "lnudPetChancePercent";
			lnudPetChancePercent.NoLabel = false;
			lnudPetChancePercent.ReadOnly = false;
			lnudPetChancePercent.Size = new System.Drawing.Size(167, 27);
			lnudPetChancePercent.TabIndex = 7;
			lnudPetChancePercent.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			lnudPetChancePercent.ValueSize = new System.Drawing.Size(57, 21);
			lnudPetChancePercent.Visible = false;
			//
			// cbischance
			//
			cbischance.AutoSize = true;
			cbischance.Location = new System.Drawing.Point(276, 100);
			cbischance.Name = "cbischance";
			cbischance.Size = new System.Drawing.Size(172, 17);
			cbischance.TabIndex = 6;
			cbischance.Text = "Is Available at this Level?";
			toolTip1.SetToolTip(cbischance, "Unset this if there is to be\r\nno Chance Card for this level.");
			cbischance.UseVisualStyleBackColor = true;
			cbischance.CheckedChanged += new EventHandler(cbischance_CheckedChanged);
			//
			// lnudChanceCurrentLevel
			//
			lnudChanceCurrentLevel.AutoSize = true;
			lnudChanceCurrentLevel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			lnudChanceCurrentLevel.FlowDirection = FlowDirection.LeftToRight;
			lnudChanceCurrentLevel.Label = "Current Level";
			lnudChanceCurrentLevel.LabelAnchor = AnchorStyles.Top | AnchorStyles.Left;
			lnudChanceCurrentLevel.Location = new System.Drawing.Point(7, 2);
			lnudChanceCurrentLevel.Margin = new Padding(0);
			lnudChanceCurrentLevel.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			lnudChanceCurrentLevel.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			lnudChanceCurrentLevel.Name = "lnudChanceCurrentLevel";
			lnudChanceCurrentLevel.NoLabel = false;
			lnudChanceCurrentLevel.ReadOnly = false;
			lnudChanceCurrentLevel.Size = new System.Drawing.Size(154, 27);
			lnudChanceCurrentLevel.TabIndex = 1;
			lnudChanceCurrentLevel.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			lnudChanceCurrentLevel.ValueSize = new System.Drawing.Size(57, 21);
			lnudChanceCurrentLevel.ValueChanged += new EventHandler(lnudChanceCurrentLevel_ValueChanged);
			//
			// lnudChancePercent
			//
			lnudChancePercent.AutoSize = true;
			lnudChancePercent.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			lnudChancePercent.FlowDirection = FlowDirection.LeftToRight;
			lnudChancePercent.Label = "Chance for A %";
			lnudChancePercent.LabelAnchor = AnchorStyles.Top | AnchorStyles.Left;
			lnudChancePercent.Location = new System.Drawing.Point(170, 2);
			lnudChancePercent.Margin = new Padding(0);
			lnudChancePercent.Maximum = new decimal(new int[] {
			100,
			0,
			0,
			0});
			lnudChancePercent.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			-2147483648});
			lnudChancePercent.Name = "lnudChancePercent";
			lnudChancePercent.NoLabel = false;
			lnudChancePercent.ReadOnly = false;
			lnudChancePercent.Size = new System.Drawing.Size(167, 27);
			lnudChancePercent.TabIndex = 2;
			lnudChancePercent.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			lnudChancePercent.ValueSize = new System.Drawing.Size(57, 21);
			lnudChancePercent.ValueChanged += new EventHandler(lnudChancePercent_ValueChanged);
			//
			// cpChoiceA
			//
			cpChoiceA.AutoSize = true;
			cpChoiceA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			cpChoiceA.BackColor = System.Drawing.Color.Transparent;
			cpChoiceA.Body = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceA.Charisma = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceA.Cleaning = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceA.Cooking = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceA.Creativity = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceA.HaveSkills = true;
			cpChoiceA.Label = "ChoiceA";
			cpChoiceA.Labels = true;
			cpChoiceA.Location = new System.Drawing.Point(4, 15);
			cpChoiceA.Logic = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceA.Margin = new Padding(0);
			cpChoiceA.MaximumSize = new System.Drawing.Size(1160, 48);
			cpChoiceA.Mechanical = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceA.Name = "cpChoiceA";
			cpChoiceA.Size = new System.Drawing.Size(1060, 48);
			cpChoiceA.TabIndex = 2;
			cpChoiceA.Value = "ChoiceA";
			//
			// cpChoiceB
			//
			cpChoiceB.AutoSize = true;
			cpChoiceB.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			cpChoiceB.BackColor = System.Drawing.Color.Transparent;
			cpChoiceB.Body = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceB.Charisma = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceB.Cleaning = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceB.Cooking = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceB.Creativity = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceB.HaveSkills = true;
			cpChoiceB.Label = "ChoiceB";
			cpChoiceB.Labels = false;
			cpChoiceB.Location = new System.Drawing.Point(4, 68);
			cpChoiceB.Logic = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceB.Margin = new Padding(0);
			cpChoiceB.MaximumSize = new System.Drawing.Size(1160, 27);
			cpChoiceB.Mechanical = new decimal(new int[] {
			0,
			0,
			0,
			0});
			cpChoiceB.Name = "cpChoiceB";
			cpChoiceB.Size = new System.Drawing.Size(1060, 27);
			cpChoiceB.TabIndex = 3;
			cpChoiceB.Value = "ChoiceB";
			//
			// ChanceTextMale
			//
			ChanceTextMale.Location = new System.Drawing.Point(593, 121);
			ChanceTextMale.Multiline = true;
			ChanceTextMale.Name = "ChanceTextMale";
			ChanceTextMale.ScrollBars = ScrollBars.Vertical;
			ChanceTextMale.Size = new System.Drawing.Size(490, 134);
			ChanceTextMale.TabIndex = 2;
			ChanceTextMale.Text = "textBox3";
			//
			// ChanceCopy
			//
			ChanceCopy.Anchor = AnchorStyles.Left;
			ChanceCopy.AutoSize = true;
			ChanceCopy.Location = new System.Drawing.Point(547, 146);
			ChanceCopy.Name = "ChanceCopy";
			ChanceCopy.Size = new System.Drawing.Size(50, 13);
			ChanceCopy.TabIndex = 3;
			ChanceCopy.TabStop = true;
			ChanceCopy.Text = "Copy >";
			ChanceCopy.LinkClicked += new LinkLabelLinkClickedEventHandler(ChanceCopy_LinkClicked);
			//
			// ChanceTextFemale
			//
			ChanceTextFemale.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ChanceTextFemale.Location = new System.Drawing.Point(7, 121);
			ChanceTextFemale.Multiline = true;
			ChanceTextFemale.Name = "ChanceTextFemale";
			ChanceTextFemale.ScrollBars = ScrollBars.Vertical;
			ChanceTextFemale.Size = new System.Drawing.Size(540, 134);
			ChanceTextFemale.TabIndex = 2;
			ChanceTextFemale.Text = "textBox4";
			//
			// tcChanceOutcome
			//
			tcChanceOutcome.Anchor = AnchorStyles.Top | AnchorStyles.Left
						| AnchorStyles.Right;
			tcChanceOutcome.Controls.Add(tabPage5);
			tcChanceOutcome.Controls.Add(tabPage6);
			tcChanceOutcome.Controls.Add(tabPage7);
			tcChanceOutcome.Controls.Add(tabPage8);
			tcChanceOutcome.Location = new System.Drawing.Point(3, 261);
			tcChanceOutcome.Name = "tcChanceOutcome";
			tcChanceOutcome.SelectedIndex = 0;
			tcChanceOutcome.Size = new System.Drawing.Size(1084, 264);
			tcChanceOutcome.TabIndex = 5;
			//
			// tabPage5
			//
			tabPage5.Controls.Add(epPassA);
			tabPage5.Location = new System.Drawing.Point(4, 22);
			tabPage5.Name = "tabPage5";
			tabPage5.Size = new System.Drawing.Size(1076, 238);
			tabPage5.TabIndex = 0;
			tabPage5.Text = "Pass A";
			//
			// epPassA
			//
			epPassA.AutoSize = true;
			epPassA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			epPassA.Body = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassA.Charisma = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassA.Cleaning = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassA.Cooking = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassA.Creativity = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassA.Female = "textBox2";
			epPassA.Food = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassA.IsCastaway = false;
			epPassA.IsPetCareer = false;
			epPassA.JobLevels = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassA.Location = new System.Drawing.Point(0, 0);
			epPassA.Logic = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassA.Male = "textBox1";
			epPassA.Margin = new Padding(0);
			epPassA.Mechanical = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassA.Money = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassA.Name = "epPassA";
			epPassA.Size = new System.Drawing.Size(1076, 238);
			epPassA.TabIndex = 0;
			//
			// tabPage6
			//
			tabPage6.Controls.Add(epFailA);
			tabPage6.Location = new System.Drawing.Point(4, 22);
			tabPage6.Name = "tabPage6";
			tabPage6.Size = new System.Drawing.Size(1076, 238);
			tabPage6.TabIndex = 1;
			tabPage6.Text = "Fail A";
			//
			// epFailA
			//
			epFailA.AutoSize = true;
			epFailA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			epFailA.Body = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailA.Charisma = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailA.Cleaning = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailA.Cooking = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailA.Creativity = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailA.Female = "textBox2";
			epFailA.Food = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailA.IsCastaway = false;
			epFailA.IsPetCareer = false;
			epFailA.JobLevels = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailA.Location = new System.Drawing.Point(0, 0);
			epFailA.Logic = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailA.Male = "textBox1";
			epFailA.Margin = new Padding(0);
			epFailA.Mechanical = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailA.Money = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailA.Name = "epFailA";
			epFailA.Size = new System.Drawing.Size(1076, 238);
			epFailA.TabIndex = 1;
			//
			// tabPage7
			//
			tabPage7.Controls.Add(epPassB);
			tabPage7.Location = new System.Drawing.Point(4, 22);
			tabPage7.Name = "tabPage7";
			tabPage7.Size = new System.Drawing.Size(1076, 238);
			tabPage7.TabIndex = 2;
			tabPage7.Text = "Pass B";
			//
			// epPassB
			//
			epPassB.AutoSize = true;
			epPassB.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			epPassB.Body = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassB.Charisma = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassB.Cleaning = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassB.Cooking = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassB.Creativity = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassB.Female = "textBox2";
			epPassB.Food = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassB.IsCastaway = false;
			epPassB.IsPetCareer = false;
			epPassB.JobLevels = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassB.Location = new System.Drawing.Point(0, 0);
			epPassB.Logic = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassB.Male = "textBox1";
			epPassB.Margin = new Padding(0);
			epPassB.Mechanical = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassB.Money = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epPassB.Name = "epPassB";
			epPassB.Size = new System.Drawing.Size(1076, 238);
			epPassB.TabIndex = 1;
			//
			// tabPage8
			//
			tabPage8.Controls.Add(epFailB);
			tabPage8.Location = new System.Drawing.Point(4, 22);
			tabPage8.Name = "tabPage8";
			tabPage8.Size = new System.Drawing.Size(1076, 238);
			tabPage8.TabIndex = 3;
			tabPage8.Text = "Fail B";
			//
			// epFailB
			//
			epFailB.AutoSize = true;
			epFailB.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			epFailB.Body = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailB.Charisma = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailB.Cleaning = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailB.Cooking = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailB.Creativity = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailB.Female = "textBox2";
			epFailB.Food = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailB.IsCastaway = false;
			epFailB.IsPetCareer = false;
			epFailB.JobLevels = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailB.Location = new System.Drawing.Point(0, 0);
			epFailB.Logic = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailB.Male = "textBox1";
			epFailB.Margin = new Padding(0);
			epFailB.Mechanical = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailB.Money = new decimal(new int[] {
			0,
			0,
			0,
			0});
			epFailB.Name = "epFailB";
			epFailB.Size = new System.Drawing.Size(1076, 238);
			epFailB.TabIndex = 1;
			//
			// label51
			//
			label51.AutoSize = true;
			label51.Location = new System.Drawing.Point(590, 102);
			label51.Margin = new Padding(0);
			label51.Name = "label51";
			label51.Size = new System.Drawing.Size(61, 13);
			label51.TabIndex = 1;
			label51.Text = "Text Male";
			//
			// label52
			//
			label52.AutoSize = true;
			label52.Location = new System.Drawing.Point(6, 102);
			label52.Margin = new Padding(0);
			label52.Name = "label52";
			label52.Size = new System.Drawing.Size(76, 13);
			label52.TabIndex = 1;
			label52.Text = "Text Female";
			//
			// tabPage3
			//
			tabPage3.Controls.Add(gbJLPromo);
			tabPage3.Controls.Add(gbPromo);
			tabPage3.Location = new System.Drawing.Point(4, 22);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new System.Drawing.Size(1092, 534);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Promotion";
			//
			// gbJLPromo
			//
			gbJLPromo.Anchor = AnchorStyles.Top | AnchorStyles.Left
						| AnchorStyles.Right;
			gbJLPromo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			gbJLPromo.BackColor = System.Drawing.Color.Transparent;
			gbJLPromo.Controls.Add(PromoList);
			gbJLPromo.Location = new System.Drawing.Point(10, 6);
			gbJLPromo.Name = "gbJLPromo";
			gbJLPromo.Size = new System.Drawing.Size(1069, 262);
			gbJLPromo.TabIndex = 1;
			gbJLPromo.TabStop = false;
			gbJLPromo.Text = "Job Levels";
			//
			// PromoList
			//
			PromoList.Anchor = AnchorStyles.Top | AnchorStyles.Left
						| AnchorStyles.Right;
			PromoList.Columns.AddRange(new ColumnHeader[] {
			PrLvl,
			PrCooking,
			PrMechanical,
			PrBody,
			PrCharisma,
			PrCreativity,
			PrLogic,
			PrCleaning,
			PrFriends,
			PrTrick});
			PromoList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			PromoList.FullRowSelect = true;
			PromoList.GridLines = true;
			PromoList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			PromoList.HideSelection = false;
			PromoList.Location = new System.Drawing.Point(10, 18);
			PromoList.MultiSelect = false;
			PromoList.Name = "PromoList";
			PromoList.Size = new System.Drawing.Size(1048, 232);
			PromoList.TabIndex = 1;
			PromoList.UseCompatibleStateImageBehavior = false;
			PromoList.View = View.Details;
			PromoList.SelectedIndexChanged += new EventHandler(PromoList_SelectedIndexChanged);
			//
			// PrLvl
			//
			PrLvl.Text = "Lvl";
			//
			// PrCooking
			//
			PrCooking.Text = "Cooking";
			PrCooking.Width = 82;
			//
			// PrMechanical
			//
			PrMechanical.Text = "Mechanical";
			PrMechanical.Width = 101;
			//
			// PrBody
			//
			PrBody.Text = "Body";
			PrBody.Width = 90;
			//
			// PrCharisma
			//
			PrCharisma.Text = "Charisma";
			PrCharisma.Width = 99;
			//
			// PrCreativity
			//
			PrCreativity.Text = "Creativity";
			PrCreativity.Width = 108;
			//
			// PrLogic
			//
			PrLogic.Text = "Logic";
			PrLogic.Width = 98;
			//
			// PrCleaning
			//
			PrCleaning.Text = "Cleaning";
			PrCleaning.Width = 117;
			//
			// PrFriends
			//
			PrFriends.Text = "Friends";
			PrFriends.Width = 100;
			//
			// PrTrick
			//
			PrTrick.Text = "Trick";
			PrTrick.Width = 152;
			//
			// gbPromo
			//
			gbPromo.Anchor = AnchorStyles.Top | AnchorStyles.Left
						| AnchorStyles.Right;
			gbPromo.BackColor = System.Drawing.Color.Transparent;
			gbPromo.Controls.Add(cbTrick);
			gbPromo.Controls.Add(label101);
			gbPromo.Controls.Add(label41);
			gbPromo.Controls.Add(label40);
			gbPromo.Controls.Add(label39);
			gbPromo.Controls.Add(label38);
			gbPromo.Controls.Add(label37);
			gbPromo.Controls.Add(label36);
			gbPromo.Controls.Add(label35);
			gbPromo.Controls.Add(label34);
			gbPromo.Controls.Add(PromoFriends);
			gbPromo.Controls.Add(PromoCleaning);
			gbPromo.Controls.Add(PromoLogic);
			gbPromo.Controls.Add(PromoCreativity);
			gbPromo.Controls.Add(PromoCharisma);
			gbPromo.Controls.Add(PromoBody);
			gbPromo.Controls.Add(PromoMechanical);
			gbPromo.Controls.Add(PromoCooking);
			gbPromo.Location = new System.Drawing.Point(10, 285);
			gbPromo.Name = "gbPromo";
			gbPromo.Size = new System.Drawing.Size(1069, 240);
			gbPromo.TabIndex = 2;
			gbPromo.TabStop = false;
			gbPromo.Text = "Current Level";
			//
			// cbTrick
			//
			cbTrick.FormattingEnabled = true;
			cbTrick.Items.AddRange(new object[] {
			"None",
			"Stay",
			"Come Here",
			"Play Dead",
			"Speak",
			"Shake",
			"Sit Up",
			"Roll Over"});
			cbTrick.Location = new System.Drawing.Point(322, 51);
			cbTrick.Name = "cbTrick";
			cbTrick.Size = new System.Drawing.Size(157, 21);
			cbTrick.TabIndex = 18;
			cbTrick.SelectedIndexChanged += new EventHandler(cbTrick_SelectedIndexChanged);
			//
			// label101
			//
			label101.AutoSize = true;
			label101.Location = new System.Drawing.Point(184, 54);
			label101.Name = "label101";
			label101.Size = new System.Drawing.Size(34, 13);
			label101.TabIndex = 17;
			label101.Text = "Trick";
			//
			// label41
			//
			label41.AutoSize = true;
			label41.Location = new System.Drawing.Point(184, 25);
			label41.Name = "label41";
			label41.Size = new System.Drawing.Size(88, 13);
			label41.TabIndex = 15;
			label41.Text = "Family Friends";
			//
			// label40
			//
			label40.AutoSize = true;
			label40.Location = new System.Drawing.Point(10, 191);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(57, 13);
			label40.TabIndex = 13;
			label40.Text = "Cleaning";
			//
			// label39
			//
			label39.AutoSize = true;
			label39.Location = new System.Drawing.Point(10, 163);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(36, 13);
			label39.TabIndex = 11;
			label39.Text = "Logic";
			//
			// label38
			//
			label38.AutoSize = true;
			label38.Location = new System.Drawing.Point(10, 135);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(63, 13);
			label38.TabIndex = 9;
			label38.Text = "Creativity";
			//
			// label37
			//
			label37.AutoSize = true;
			label37.Location = new System.Drawing.Point(10, 107);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(62, 13);
			label37.TabIndex = 7;
			label37.Text = "Charisma";
			//
			// label36
			//
			label36.AutoSize = true;
			label36.Location = new System.Drawing.Point(10, 79);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(36, 13);
			label36.TabIndex = 5;
			label36.Text = "Body";
			//
			// label35
			//
			label35.AutoSize = true;
			label35.Location = new System.Drawing.Point(10, 51);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(69, 13);
			label35.TabIndex = 3;
			label35.Text = "Mechanical";
			//
			// label34
			//
			label34.AutoSize = true;
			label34.Location = new System.Drawing.Point(10, 23);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(54, 13);
			label34.TabIndex = 1;
			label34.Text = "Cooking";
			//
			// PromoFriends
			//
			PromoFriends.Location = new System.Drawing.Point(322, 23);
			PromoFriends.Maximum = new decimal(new int[] {
			99,
			0,
			0,
			0});
			PromoFriends.Name = "PromoFriends";
			PromoFriends.Size = new System.Drawing.Size(57, 21);
			PromoFriends.TabIndex = 16;
			PromoFriends.ValueChanged += new EventHandler(Promo_ValueChanged);
			PromoFriends.KeyUp += new KeyEventHandler(Promo_KeyUp);
			//
			// PromoCleaning
			//
			PromoCleaning.Location = new System.Drawing.Point(104, 189);
			PromoCleaning.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			PromoCleaning.Name = "PromoCleaning";
			PromoCleaning.Size = new System.Drawing.Size(57, 21);
			PromoCleaning.TabIndex = 14;
			PromoCleaning.ValueChanged += new EventHandler(Promo_ValueChanged);
			PromoCleaning.KeyUp += new KeyEventHandler(Promo_KeyUp);
			//
			// PromoLogic
			//
			PromoLogic.Location = new System.Drawing.Point(104, 161);
			PromoLogic.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			PromoLogic.Name = "PromoLogic";
			PromoLogic.Size = new System.Drawing.Size(57, 21);
			PromoLogic.TabIndex = 12;
			PromoLogic.ValueChanged += new EventHandler(Promo_ValueChanged);
			PromoLogic.KeyUp += new KeyEventHandler(Promo_KeyUp);
			//
			// PromoCreativity
			//
			PromoCreativity.Location = new System.Drawing.Point(104, 133);
			PromoCreativity.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			PromoCreativity.Name = "PromoCreativity";
			PromoCreativity.Size = new System.Drawing.Size(57, 21);
			PromoCreativity.TabIndex = 10;
			PromoCreativity.ValueChanged += new EventHandler(Promo_ValueChanged);
			PromoCreativity.KeyUp += new KeyEventHandler(Promo_KeyUp);
			//
			// PromoCharisma
			//
			PromoCharisma.Location = new System.Drawing.Point(104, 105);
			PromoCharisma.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			PromoCharisma.Name = "PromoCharisma";
			PromoCharisma.Size = new System.Drawing.Size(57, 21);
			PromoCharisma.TabIndex = 8;
			PromoCharisma.ValueChanged += new EventHandler(Promo_ValueChanged);
			PromoCharisma.KeyUp += new KeyEventHandler(Promo_KeyUp);
			//
			// PromoBody
			//
			PromoBody.Location = new System.Drawing.Point(104, 77);
			PromoBody.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			PromoBody.Name = "PromoBody";
			PromoBody.Size = new System.Drawing.Size(57, 21);
			PromoBody.TabIndex = 6;
			PromoBody.ValueChanged += new EventHandler(Promo_ValueChanged);
			PromoBody.KeyUp += new KeyEventHandler(Promo_KeyUp);
			//
			// PromoMechanical
			//
			PromoMechanical.Location = new System.Drawing.Point(104, 49);
			PromoMechanical.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			PromoMechanical.Name = "PromoMechanical";
			PromoMechanical.Size = new System.Drawing.Size(57, 21);
			PromoMechanical.TabIndex = 4;
			PromoMechanical.ValueChanged += new EventHandler(Promo_ValueChanged);
			PromoMechanical.KeyUp += new KeyEventHandler(Promo_KeyUp);
			//
			// PromoCooking
			//
			PromoCooking.Location = new System.Drawing.Point(104, 21);
			PromoCooking.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			PromoCooking.Name = "PromoCooking";
			PromoCooking.Size = new System.Drawing.Size(57, 21);
			PromoCooking.TabIndex = 2;
			PromoCooking.ValueChanged += new EventHandler(Promo_ValueChanged);
			PromoCooking.KeyUp += new KeyEventHandler(Promo_KeyUp);
			//
			// tabPage2
			//
			tabPage2.Controls.Add(gbHoursWages);
			tabPage2.Controls.Add(gbJLHoursWages);
			tabPage2.Location = new System.Drawing.Point(4, 22);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new System.Drawing.Size(1092, 534);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Hours & Wages";
			//
			// gbHoursWages
			//
			gbHoursWages.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			gbHoursWages.BackColor = System.Drawing.Color.Transparent;
			gbHoursWages.Controls.Add(tbWorkFinish);
			gbHoursWages.Controls.Add(label48);
			gbHoursWages.Controls.Add(lnudFoods);
			gbHoursWages.Controls.Add(lnudWorkStart);
			gbHoursWages.Controls.Add(lnudWorkHours);
			gbHoursWages.Controls.Add(lnudWages);
			gbHoursWages.Controls.Add(lnudWagesDog);
			gbHoursWages.Controls.Add(lbPTO);
			gbHoursWages.Controls.Add(lnudWagesCat);
			gbHoursWages.Controls.Add(WorkMonday);
			gbHoursWages.Controls.Add(WorkTuesday);
			gbHoursWages.Controls.Add(WorkWednesday);
			gbHoursWages.Controls.Add(WorkThursday);
			gbHoursWages.Controls.Add(WorkFriday);
			gbHoursWages.Controls.Add(WorkSaturday);
			gbHoursWages.Controls.Add(WorkSunday);
			gbHoursWages.Controls.Add(gbHWMotives);
			gbHoursWages.Controls.Add(lbLscore);
			gbHoursWages.Controls.Add(numLscore);
			gbHoursWages.Controls.Add(numPTO);
			gbHoursWages.Location = new System.Drawing.Point(10, 285);
			gbHoursWages.Name = "gbHoursWages";
			gbHoursWages.Size = new System.Drawing.Size(1069, 240);
			gbHoursWages.TabIndex = 2;
			gbHoursWages.TabStop = false;
			gbHoursWages.Text = "Current Level";
			//
			// tbWorkFinish
			//
			tbWorkFinish.BackColor = System.Drawing.SystemColors.Window;
			tbWorkFinish.Location = new System.Drawing.Point(281, 30);
			tbWorkFinish.Name = "tbWorkFinish";
			tbWorkFinish.ReadOnly = true;
			tbWorkFinish.Size = new System.Drawing.Size(41, 21);
			tbWorkFinish.TabIndex = 14;
			tbWorkFinish.Text = "88";
			//
			// label48
			//
			label48.AutoSize = true;
			label48.Location = new System.Drawing.Point(236, 34);
			label48.Name = "label48";
			label48.Size = new System.Drawing.Size(39, 13);
			label48.TabIndex = 13;
			label48.Text = "Finish";
			//
			// lnudFoods
			//
			lnudFoods.AutoSize = true;
			lnudFoods.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			lnudFoods.FlowDirection = FlowDirection.LeftToRight;
			lnudFoods.Label = "Food";
			lnudFoods.LabelAnchor = AnchorStyles.Top | AnchorStyles.Right;
			lnudFoods.Location = new System.Drawing.Point(239, 71);
			lnudFoods.Margin = new Padding(0);
			lnudFoods.Maximum = new decimal(new int[] {
			10000,
			0,
			0,
			0});
			lnudFoods.Minimum = new decimal(new int[] {
			0,
			0,
			0,
			0});
			lnudFoods.Name = "lnudFoods";
			lnudFoods.NoLabel = false;
			lnudFoods.ReadOnly = false;
			lnudFoods.Size = new System.Drawing.Size(146, 27);
			lnudFoods.TabIndex = 12;
			lnudFoods.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			lnudFoods.ValueSize = new System.Drawing.Size(100, 21);
			lnudFoods.Visible = false;
			lnudFoods.ValueChanged += new EventHandler(lnudFoods_ValueChanged);
			//
			// lnudWorkStart
			//
			lnudWorkStart.AutoSize = true;
			lnudWorkStart.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			lnudWorkStart.FlowDirection = FlowDirection.LeftToRight;
			lnudWorkStart.Label = "Start";
			lnudWorkStart.LabelAnchor = AnchorStyles.Top | AnchorStyles.Right;
			lnudWorkStart.Location = new System.Drawing.Point(10, 27);
			lnudWorkStart.Margin = new Padding(0);
			lnudWorkStart.Maximum = new decimal(new int[] {
			23,
			0,
			0,
			0});
			lnudWorkStart.Minimum = new decimal(new int[] {
			0,
			0,
			0,
			0});
			lnudWorkStart.Name = "lnudWorkStart";
			lnudWorkStart.NoLabel = false;
			lnudWorkStart.ReadOnly = false;
			lnudWorkStart.Size = new System.Drawing.Size(104, 27);
			lnudWorkStart.TabIndex = 1;
			lnudWorkStart.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			lnudWorkStart.ValueSize = new System.Drawing.Size(57, 21);
			lnudWorkStart.ValueChanged += new EventHandler(lnudWork_ValueChanged);
			lnudWorkStart.KeyUp += new KeyEventHandler(lnudWork_KeyUp);
			//
			// lnudWorkHours
			//
			lnudWorkHours.AutoSize = true;
			lnudWorkHours.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			lnudWorkHours.FlowDirection = FlowDirection.LeftToRight;
			lnudWorkHours.Label = "Hours";
			lnudWorkHours.LabelAnchor = AnchorStyles.Top | AnchorStyles.Right;
			lnudWorkHours.Location = new System.Drawing.Point(114, 27);
			lnudWorkHours.Margin = new Padding(6, 0, 0, 0);
			lnudWorkHours.Maximum = new decimal(new int[] {
			22,
			0,
			0,
			0});
			lnudWorkHours.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			lnudWorkHours.Name = "lnudWorkHours";
			lnudWorkHours.NoLabel = false;
			lnudWorkHours.ReadOnly = false;
			lnudWorkHours.Size = new System.Drawing.Size(109, 27);
			lnudWorkHours.TabIndex = 2;
			lnudWorkHours.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			lnudWorkHours.ValueSize = new System.Drawing.Size(57, 21);
			lnudWorkHours.ValueChanged += new EventHandler(lnudWork_ValueChanged);
			lnudWorkHours.KeyUp += new KeyEventHandler(lnudWork_KeyUp);
			//
			// lnudWages
			//
			lnudWages.AutoSize = true;
			lnudWages.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			lnudWages.FlowDirection = FlowDirection.LeftToRight;
			lnudWages.Label = "Wages";
			lnudWages.LabelAnchor = AnchorStyles.Top | AnchorStyles.Right;
			lnudWages.Location = new System.Drawing.Point(61, 71);
			lnudWages.Margin = new Padding(0);
			lnudWages.Maximum = new decimal(new int[] {
			20000,
			0,
			0,
			0});
			lnudWages.Minimum = new decimal(new int[] {
			0,
			0,
			0,
			0});
			lnudWages.Name = "lnudWages";
			lnudWages.NoLabel = false;
			lnudWages.ReadOnly = false;
			lnudWages.Size = new System.Drawing.Size(156, 27);
			lnudWages.TabIndex = 1;
			lnudWages.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			lnudWages.ValueSize = new System.Drawing.Size(100, 21);
			lnudWages.ValueChanged += new EventHandler(lnudWork_ValueChanged);
			lnudWages.KeyUp += new KeyEventHandler(lnudWork_KeyUp);
			//
			// lnudWagesDog
			//
			lnudWagesDog.AutoSize = true;
			lnudWagesDog.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			lnudWagesDog.FlowDirection = FlowDirection.LeftToRight;
			lnudWagesDog.Label = "Wages (Dog)";
			lnudWagesDog.LabelAnchor = AnchorStyles.Top | AnchorStyles.Left;
			lnudWagesDog.Location = new System.Drawing.Point(24, 103);
			lnudWagesDog.Margin = new Padding(0);
			lnudWagesDog.Maximum = new decimal(new int[] {
			20000,
			0,
			0,
			0});
			lnudWagesDog.Minimum = new decimal(new int[] {
			0,
			0,
			0,
			0});
			lnudWagesDog.Name = "lnudWagesDog";
			lnudWagesDog.NoLabel = false;
			lnudWagesDog.ReadOnly = false;
			lnudWagesDog.Size = new System.Drawing.Size(193, 27);
			lnudWagesDog.TabIndex = 2;
			lnudWagesDog.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			lnudWagesDog.ValueSize = new System.Drawing.Size(100, 21);
			lnudWagesDog.ValueChanged += new EventHandler(lnudWork_ValueChanged);
			lnudWagesDog.KeyUp += new KeyEventHandler(lnudWork_KeyUp);
			//
			// lbPTO
			//
			lbPTO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			lbPTO.AutoSize = true;
			lbPTO.Location = new System.Drawing.Point(466, 207);
			lbPTO.Name = "lbPTO";
			lbPTO.Size = new System.Drawing.Size(226, 13);
			lbPTO.TabIndex = 11;
			lbPTO.Text = "Paid Time Off (PTO) Daily Accruement";
			lbPTO.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lnudWagesCat
			//
			lnudWagesCat.AutoSize = true;
			lnudWagesCat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			lnudWagesCat.FlowDirection = FlowDirection.LeftToRight;
			lnudWagesCat.Label = "Wages (Cat)";
			lnudWagesCat.LabelAnchor = AnchorStyles.Top | AnchorStyles.Left;
			lnudWagesCat.Location = new System.Drawing.Point(27, 138);
			lnudWagesCat.Margin = new Padding(0);
			lnudWagesCat.Maximum = new decimal(new int[] {
			20000,
			0,
			0,
			0});
			lnudWagesCat.Minimum = new decimal(new int[] {
			0,
			0,
			0,
			0});
			lnudWagesCat.Name = "lnudWagesCat";
			lnudWagesCat.NoLabel = false;
			lnudWagesCat.ReadOnly = false;
			lnudWagesCat.Size = new System.Drawing.Size(190, 27);
			lnudWagesCat.TabIndex = 3;
			lnudWagesCat.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			lnudWagesCat.ValueSize = new System.Drawing.Size(100, 21);
			lnudWagesCat.ValueChanged += new EventHandler(lnudWork_ValueChanged);
			lnudWagesCat.KeyUp += new KeyEventHandler(lnudWork_KeyUp);
			//
			// WorkMonday
			//
			WorkMonday.AutoSize = true;
			WorkMonday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			WorkMonday.Location = new System.Drawing.Point(13, 206);
			WorkMonday.Name = "WorkMonday";
			WorkMonday.Size = new System.Drawing.Size(49, 17);
			WorkMonday.TabIndex = 1;
			WorkMonday.Text = "Mon";
			WorkMonday.CheckedChanged += new EventHandler(Workday_CheckedChanged);
			//
			// WorkTuesday
			//
			WorkTuesday.AutoSize = true;
			WorkTuesday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			WorkTuesday.Location = new System.Drawing.Point(77, 206);
			WorkTuesday.Name = "WorkTuesday";
			WorkTuesday.Size = new System.Drawing.Size(46, 17);
			WorkTuesday.TabIndex = 2;
			WorkTuesday.Text = "Tue";
			WorkTuesday.CheckedChanged += new EventHandler(Workday_CheckedChanged);
			//
			// WorkWednesday
			//
			WorkWednesday.AutoSize = true;
			WorkWednesday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			WorkWednesday.Location = new System.Drawing.Point(138, 206);
			WorkWednesday.Name = "WorkWednesday";
			WorkWednesday.Size = new System.Drawing.Size(50, 17);
			WorkWednesday.TabIndex = 3;
			WorkWednesday.Text = "Wed";
			WorkWednesday.CheckedChanged += new EventHandler(Workday_CheckedChanged);
			//
			// WorkThursday
			//
			WorkThursday.AutoSize = true;
			WorkThursday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			WorkThursday.Location = new System.Drawing.Point(203, 206);
			WorkThursday.Name = "WorkThursday";
			WorkThursday.Size = new System.Drawing.Size(47, 17);
			WorkThursday.TabIndex = 4;
			WorkThursday.Text = "Thu";
			WorkThursday.CheckedChanged += new EventHandler(Workday_CheckedChanged);
			//
			// WorkFriday
			//
			WorkFriday.AutoSize = true;
			WorkFriday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			WorkFriday.Location = new System.Drawing.Point(265, 206);
			WorkFriday.Name = "WorkFriday";
			WorkFriday.Size = new System.Drawing.Size(40, 17);
			WorkFriday.TabIndex = 5;
			WorkFriday.Text = "Fri";
			WorkFriday.CheckedChanged += new EventHandler(Workday_CheckedChanged);
			//
			// WorkSaturday
			//
			WorkSaturday.AutoSize = true;
			WorkSaturday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			WorkSaturday.Location = new System.Drawing.Point(320, 206);
			WorkSaturday.Name = "WorkSaturday";
			WorkSaturday.Size = new System.Drawing.Size(45, 17);
			WorkSaturday.TabIndex = 6;
			WorkSaturday.Text = "Sat";
			WorkSaturday.CheckedChanged += new EventHandler(Workday_CheckedChanged);
			//
			// WorkSunday
			//
			WorkSunday.AutoSize = true;
			WorkSunday.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			WorkSunday.Location = new System.Drawing.Point(380, 206);
			WorkSunday.Name = "WorkSunday";
			WorkSunday.Size = new System.Drawing.Size(48, 17);
			WorkSunday.TabIndex = 7;
			WorkSunday.Text = "Sun";
			WorkSunday.CheckedChanged += new EventHandler(Workday_CheckedChanged);
			//
			// gbHWMotives
			//
			gbHWMotives.Controls.Add(label27);
			gbHWMotives.Controls.Add(label24);
			gbHWMotives.Controls.Add(ComfortHours);
			gbHWMotives.Controls.Add(HygieneTotal);
			gbHWMotives.Controls.Add(BladderTotal);
			gbHWMotives.Controls.Add(label21);
			gbHWMotives.Controls.Add(WorkBladder);
			gbHWMotives.Controls.Add(label23);
			gbHWMotives.Controls.Add(label19);
			gbHWMotives.Controls.Add(WorkComfort);
			gbHWMotives.Controls.Add(HungerHours);
			gbHWMotives.Controls.Add(EnergyHours);
			gbHWMotives.Controls.Add(label25);
			gbHWMotives.Controls.Add(WorkPublic);
			gbHWMotives.Controls.Add(WorkHunger);
			gbHWMotives.Controls.Add(BladderHours);
			gbHWMotives.Controls.Add(ComfortTotal);
			gbHWMotives.Controls.Add(label22);
			gbHWMotives.Controls.Add(HungerTotal);
			gbHWMotives.Controls.Add(HygieneHours);
			gbHWMotives.Controls.Add(WorkEnergy);
			gbHWMotives.Controls.Add(WorkFun);
			gbHWMotives.Controls.Add(WorkSunshine);
			gbHWMotives.Controls.Add(PublicHours);
			gbHWMotives.Controls.Add(label20);
			gbHWMotives.Controls.Add(SunshineTotal);
			gbHWMotives.Controls.Add(EnergyTotal);
			gbHWMotives.Controls.Add(FunTotal);
			gbHWMotives.Controls.Add(PublicTotal);
			gbHWMotives.Controls.Add(label33);
			gbHWMotives.Controls.Add(label32);
			gbHWMotives.Controls.Add(label31);
			gbHWMotives.Controls.Add(label30);
			gbHWMotives.Controls.Add(label28);
			gbHWMotives.Controls.Add(label26);
			gbHWMotives.Controls.Add(FunHours);
			gbHWMotives.Controls.Add(WorkHygiene);
			gbHWMotives.Controls.Add(SunshineHours);
			gbHWMotives.Location = new System.Drawing.Point(453, 20);
			gbHWMotives.Name = "gbHWMotives";
			gbHWMotives.Size = new System.Drawing.Size(594, 174);
			gbHWMotives.TabIndex = 4;
			gbHWMotives.TabStop = false;
			gbHWMotives.Text = "Motives";
			//
			// label27
			//
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(432, 14);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(75, 13);
			label27.TabIndex = 64;
			label27.Text = "times Hours";
			//
			// label24
			//
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(129, 14);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(75, 13);
			label24.TabIndex = 41;
			label24.Text = "times Hours";
			//
			// ComfortHours
			//
			ComfortHours.AutoSize = true;
			ComfortHours.Enabled = false;
			ComfortHours.Location = new System.Drawing.Point(142, 61);
			ComfortHours.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			ComfortHours.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			ComfortHours.Name = "ComfortHours";
			ComfortHours.ReadOnly = true;
			ComfortHours.Size = new System.Drawing.Size(60, 21);
			ComfortHours.TabIndex = 0;
			ComfortHours.TabStop = false;
			//
			// HygieneTotal
			//
			HygieneTotal.AutoSize = true;
			HygieneTotal.Enabled = false;
			HygieneTotal.Location = new System.Drawing.Point(208, 89);
			HygieneTotal.Maximum = new decimal(new int[] {
			20000,
			0,
			0,
			0});
			HygieneTotal.Minimum = new decimal(new int[] {
			20000,
			0,
			0,
			-2147483648});
			HygieneTotal.Name = "HygieneTotal";
			HygieneTotal.ReadOnly = true;
			HygieneTotal.Size = new System.Drawing.Size(68, 21);
			HygieneTotal.TabIndex = 0;
			HygieneTotal.TabStop = false;
			//
			// BladderTotal
			//
			BladderTotal.AutoSize = true;
			BladderTotal.Enabled = false;
			BladderTotal.Location = new System.Drawing.Point(208, 116);
			BladderTotal.Maximum = new decimal(new int[] {
			20000,
			0,
			0,
			0});
			BladderTotal.Minimum = new decimal(new int[] {
			20000,
			0,
			0,
			-2147483648});
			BladderTotal.Name = "BladderTotal";
			BladderTotal.ReadOnly = true;
			BladderTotal.Size = new System.Drawing.Size(68, 21);
			BladderTotal.TabIndex = 0;
			BladderTotal.TabStop = false;
			//
			// label21
			//
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(9, 93);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(53, 13);
			label21.TabIndex = 7;
			label21.Text = "Hygiene";
			//
			// WorkBladder
			//
			WorkBladder.AutoSize = true;
			WorkBladder.Location = new System.Drawing.Point(75, 116);
			WorkBladder.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			WorkBladder.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			WorkBladder.Name = "WorkBladder";
			WorkBladder.Size = new System.Drawing.Size(60, 21);
			WorkBladder.TabIndex = 10;
			WorkBladder.ValueChanged += new EventHandler(nudMotive_ValueChanged);
			WorkBladder.KeyUp += new KeyEventHandler(nudMotive_KeyUp);
			//
			// label23
			//
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(72, 14);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(53, 13);
			label23.TabIndex = 40;
			label23.Text = "PerHour";
			//
			// label19
			//
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(9, 38);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(48, 13);
			label19.TabIndex = 1;
			label19.Text = "Hunger";
			//
			// WorkComfort
			//
			WorkComfort.AutoSize = true;
			WorkComfort.Location = new System.Drawing.Point(75, 61);
			WorkComfort.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			WorkComfort.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			WorkComfort.Name = "WorkComfort";
			WorkComfort.Size = new System.Drawing.Size(60, 21);
			WorkComfort.TabIndex = 6;
			WorkComfort.ValueChanged += new EventHandler(nudMotive_ValueChanged);
			WorkComfort.KeyUp += new KeyEventHandler(nudMotive_KeyUp);
			//
			// HungerHours
			//
			HungerHours.AutoSize = true;
			HungerHours.Enabled = false;
			HungerHours.Location = new System.Drawing.Point(142, 34);
			HungerHours.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			HungerHours.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			HungerHours.Name = "HungerHours";
			HungerHours.ReadOnly = true;
			HungerHours.Size = new System.Drawing.Size(60, 21);
			HungerHours.TabIndex = 0;
			HungerHours.TabStop = false;
			//
			// EnergyHours
			//
			EnergyHours.AutoSize = true;
			EnergyHours.Enabled = false;
			EnergyHours.Location = new System.Drawing.Point(445, 34);
			EnergyHours.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			EnergyHours.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			EnergyHours.Name = "EnergyHours";
			EnergyHours.ReadOnly = true;
			EnergyHours.Size = new System.Drawing.Size(60, 21);
			EnergyHours.TabIndex = 0;
			EnergyHours.TabStop = false;
			//
			// label25
			//
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(205, 14);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(47, 13);
			label25.TabIndex = 42;
			label25.Text = "= Total";
			//
			// WorkPublic
			//
			WorkPublic.AutoSize = true;
			WorkPublic.Location = new System.Drawing.Point(378, 89);
			WorkPublic.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			WorkPublic.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			WorkPublic.Name = "WorkPublic";
			WorkPublic.Size = new System.Drawing.Size(60, 21);
			WorkPublic.TabIndex = 16;
			WorkPublic.ValueChanged += new EventHandler(nudMotive_ValueChanged);
			WorkPublic.KeyUp += new KeyEventHandler(nudMotive_KeyUp);
			//
			// WorkHunger
			//
			WorkHunger.AutoSize = true;
			WorkHunger.Location = new System.Drawing.Point(75, 34);
			WorkHunger.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			WorkHunger.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			WorkHunger.Name = "WorkHunger";
			WorkHunger.Size = new System.Drawing.Size(60, 21);
			WorkHunger.TabIndex = 2;
			WorkHunger.ValueChanged += new EventHandler(nudMotive_ValueChanged);
			WorkHunger.KeyUp += new KeyEventHandler(nudMotive_KeyUp);
			//
			// BladderHours
			//
			BladderHours.AutoSize = true;
			BladderHours.Enabled = false;
			BladderHours.Location = new System.Drawing.Point(142, 116);
			BladderHours.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			BladderHours.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			BladderHours.Name = "BladderHours";
			BladderHours.ReadOnly = true;
			BladderHours.Size = new System.Drawing.Size(60, 21);
			BladderHours.TabIndex = 0;
			BladderHours.TabStop = false;
			//
			// ComfortTotal
			//
			ComfortTotal.AutoSize = true;
			ComfortTotal.Enabled = false;
			ComfortTotal.Location = new System.Drawing.Point(208, 62);
			ComfortTotal.Maximum = new decimal(new int[] {
			20000,
			0,
			0,
			0});
			ComfortTotal.Minimum = new decimal(new int[] {
			20000,
			0,
			0,
			-2147483648});
			ComfortTotal.Name = "ComfortTotal";
			ComfortTotal.ReadOnly = true;
			ComfortTotal.Size = new System.Drawing.Size(68, 21);
			ComfortTotal.TabIndex = 0;
			ComfortTotal.TabStop = false;
			//
			// label22
			//
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(9, 120);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(51, 13);
			label22.TabIndex = 9;
			label22.Text = "Bladder";
			//
			// HungerTotal
			//
			HungerTotal.AutoSize = true;
			HungerTotal.Enabled = false;
			HungerTotal.Location = new System.Drawing.Point(208, 34);
			HungerTotal.Maximum = new decimal(new int[] {
			20000,
			0,
			0,
			0});
			HungerTotal.Minimum = new decimal(new int[] {
			20000,
			0,
			0,
			-2147483648});
			HungerTotal.Name = "HungerTotal";
			HungerTotal.ReadOnly = true;
			HungerTotal.Size = new System.Drawing.Size(68, 21);
			HungerTotal.TabIndex = 0;
			HungerTotal.TabStop = false;
			//
			// HygieneHours
			//
			HygieneHours.AutoSize = true;
			HygieneHours.Enabled = false;
			HygieneHours.Location = new System.Drawing.Point(142, 89);
			HygieneHours.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			HygieneHours.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			HygieneHours.Name = "HygieneHours";
			HygieneHours.ReadOnly = true;
			HygieneHours.Size = new System.Drawing.Size(60, 21);
			HygieneHours.TabIndex = 0;
			HygieneHours.TabStop = false;
			//
			// WorkEnergy
			//
			WorkEnergy.AutoSize = true;
			WorkEnergy.Location = new System.Drawing.Point(378, 34);
			WorkEnergy.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			WorkEnergy.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			WorkEnergy.Name = "WorkEnergy";
			WorkEnergy.Size = new System.Drawing.Size(60, 21);
			WorkEnergy.TabIndex = 12;
			WorkEnergy.ValueChanged += new EventHandler(nudMotive_ValueChanged);
			WorkEnergy.KeyUp += new KeyEventHandler(nudMotive_KeyUp);
			//
			// WorkFun
			//
			WorkFun.AutoSize = true;
			WorkFun.Location = new System.Drawing.Point(378, 61);
			WorkFun.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			WorkFun.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			WorkFun.Name = "WorkFun";
			WorkFun.Size = new System.Drawing.Size(60, 21);
			WorkFun.TabIndex = 14;
			WorkFun.ValueChanged += new EventHandler(nudMotive_ValueChanged);
			WorkFun.KeyUp += new KeyEventHandler(nudMotive_KeyUp);
			//
			// WorkSunshine
			//
			WorkSunshine.AutoSize = true;
			WorkSunshine.Location = new System.Drawing.Point(378, 116);
			WorkSunshine.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			WorkSunshine.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			WorkSunshine.Name = "WorkSunshine";
			WorkSunshine.Size = new System.Drawing.Size(60, 21);
			WorkSunshine.TabIndex = 18;
			WorkSunshine.ValueChanged += new EventHandler(nudMotive_ValueChanged);
			WorkSunshine.KeyUp += new KeyEventHandler(nudMotive_KeyUp);
			//
			// PublicHours
			//
			PublicHours.AutoSize = true;
			PublicHours.Enabled = false;
			PublicHours.Location = new System.Drawing.Point(445, 89);
			PublicHours.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			PublicHours.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			PublicHours.Name = "PublicHours";
			PublicHours.ReadOnly = true;
			PublicHours.Size = new System.Drawing.Size(60, 21);
			PublicHours.TabIndex = 0;
			PublicHours.TabStop = false;
			//
			// label20
			//
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(9, 65);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(54, 13);
			label20.TabIndex = 5;
			label20.Text = "Comfort";
			//
			// SunshineTotal
			//
			SunshineTotal.AutoSize = true;
			SunshineTotal.Enabled = false;
			SunshineTotal.Location = new System.Drawing.Point(512, 116);
			SunshineTotal.Maximum = new decimal(new int[] {
			20000,
			0,
			0,
			0});
			SunshineTotal.Minimum = new decimal(new int[] {
			20000,
			0,
			0,
			-2147483648});
			SunshineTotal.Name = "SunshineTotal";
			SunshineTotal.ReadOnly = true;
			SunshineTotal.Size = new System.Drawing.Size(68, 21);
			SunshineTotal.TabIndex = 0;
			SunshineTotal.TabStop = false;
			//
			// EnergyTotal
			//
			EnergyTotal.AutoSize = true;
			EnergyTotal.Enabled = false;
			EnergyTotal.Location = new System.Drawing.Point(512, 34);
			EnergyTotal.Maximum = new decimal(new int[] {
			20000,
			0,
			0,
			0});
			EnergyTotal.Minimum = new decimal(new int[] {
			20000,
			0,
			0,
			-2147483648});
			EnergyTotal.Name = "EnergyTotal";
			EnergyTotal.ReadOnly = true;
			EnergyTotal.Size = new System.Drawing.Size(68, 21);
			EnergyTotal.TabIndex = 0;
			EnergyTotal.TabStop = false;
			//
			// FunTotal
			//
			FunTotal.AutoSize = true;
			FunTotal.Enabled = false;
			FunTotal.Location = new System.Drawing.Point(512, 61);
			FunTotal.Maximum = new decimal(new int[] {
			20000,
			0,
			0,
			0});
			FunTotal.Minimum = new decimal(new int[] {
			20000,
			0,
			0,
			-2147483648});
			FunTotal.Name = "FunTotal";
			FunTotal.ReadOnly = true;
			FunTotal.Size = new System.Drawing.Size(68, 21);
			FunTotal.TabIndex = 0;
			FunTotal.TabStop = false;
			//
			// PublicTotal
			//
			PublicTotal.AutoSize = true;
			PublicTotal.Enabled = false;
			PublicTotal.Location = new System.Drawing.Point(512, 89);
			PublicTotal.Maximum = new decimal(new int[] {
			20000,
			0,
			0,
			0});
			PublicTotal.Minimum = new decimal(new int[] {
			20000,
			0,
			0,
			-2147483648});
			PublicTotal.Name = "PublicTotal";
			PublicTotal.ReadOnly = true;
			PublicTotal.Size = new System.Drawing.Size(68, 21);
			PublicTotal.TabIndex = 0;
			PublicTotal.TabStop = false;
			//
			// label33
			//
			label33.AutoSize = true;
			label33.Location = new System.Drawing.Point(312, 65);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(27, 13);
			label33.TabIndex = 13;
			label33.Text = "Fun";
			//
			// label32
			//
			label32.AutoSize = true;
			label32.Location = new System.Drawing.Point(312, 38);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(47, 13);
			label32.TabIndex = 11;
			label32.Text = "Energy";
			//
			// label31
			//
			label31.AutoSize = true;
			label31.Location = new System.Drawing.Point(312, 93);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(41, 13);
			label31.TabIndex = 15;
			label31.Text = "Social";
			//
			// label30
			//
			label30.AutoSize = true;
			label30.Location = new System.Drawing.Point(312, 120);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(59, 13);
			label30.TabIndex = 17;
			label30.Text = "Sunshine";
			//
			// label28
			//
			label28.AutoSize = true;
			label28.Location = new System.Drawing.Point(375, 14);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(53, 13);
			label28.TabIndex = 63;
			label28.Text = "PerHour";
			//
			// label26
			//
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(509, 14);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(47, 13);
			label26.TabIndex = 65;
			label26.Text = "= Total";
			//
			// FunHours
			//
			FunHours.AutoSize = true;
			FunHours.Enabled = false;
			FunHours.Location = new System.Drawing.Point(445, 61);
			FunHours.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			FunHours.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			FunHours.Name = "FunHours";
			FunHours.ReadOnly = true;
			FunHours.Size = new System.Drawing.Size(60, 21);
			FunHours.TabIndex = 0;
			FunHours.TabStop = false;
			//
			// WorkHygiene
			//
			WorkHygiene.AutoSize = true;
			WorkHygiene.Location = new System.Drawing.Point(75, 89);
			WorkHygiene.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			WorkHygiene.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			WorkHygiene.Name = "WorkHygiene";
			WorkHygiene.Size = new System.Drawing.Size(60, 21);
			WorkHygiene.TabIndex = 8;
			WorkHygiene.ValueChanged += new EventHandler(nudMotive_ValueChanged);
			WorkHygiene.KeyUp += new KeyEventHandler(nudMotive_KeyUp);
			//
			// SunshineHours
			//
			SunshineHours.AutoSize = true;
			SunshineHours.Enabled = false;
			SunshineHours.Location = new System.Drawing.Point(445, 116);
			SunshineHours.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			SunshineHours.Minimum = new decimal(new int[] {
			1000,
			0,
			0,
			-2147483648});
			SunshineHours.Name = "SunshineHours";
			SunshineHours.ReadOnly = true;
			SunshineHours.Size = new System.Drawing.Size(60, 21);
			SunshineHours.TabIndex = 0;
			SunshineHours.TabStop = false;
			//
			// lbLscore
			//
			lbLscore.AutoSize = true;
			lbLscore.Location = new System.Drawing.Point(790, 207);
			lbLscore.Name = "lbLscore";
			lbLscore.Size = new System.Drawing.Size(64, 13);
			lbLscore.TabIndex = 3;
			lbLscore.Text = "Life Score";
			lbLscore.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// numLscore
			//
			numLscore.AutoSize = true;
			numLscore.Location = new System.Drawing.Point(860, 204);
			numLscore.Maximum = new decimal(new int[] {
			200,
			0,
			0,
			0});
			numLscore.Name = "numLscore";
			numLscore.Size = new System.Drawing.Size(60, 21);
			numLscore.TabIndex = 5;
			numLscore.ValueChanged += new EventHandler(numLscore_ValueChanged);
			//
			// numPTO
			//
			numPTO.AutoSize = true;
			numPTO.Location = new System.Drawing.Point(694, 204);
			numPTO.Name = "numPTO";
			numPTO.Size = new System.Drawing.Size(60, 21);
			numPTO.TabIndex = 6;
			toolTip1.SetToolTip(numPTO, "It takes 100 of these points for\r\none day off.");
			numPTO.ValueChanged += new EventHandler(numPTO_ValueChanged);
			//
			// gbJLHoursWages
			//
			gbJLHoursWages.Anchor = AnchorStyles.Top | AnchorStyles.Left
						| AnchorStyles.Right;
			gbJLHoursWages.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			gbJLHoursWages.BackColor = System.Drawing.Color.Transparent;
			gbJLHoursWages.Controls.Add(HoursWagesList);
			gbJLHoursWages.Location = new System.Drawing.Point(10, 6);
			gbJLHoursWages.Name = "gbJLHoursWages";
			gbJLHoursWages.Size = new System.Drawing.Size(1069, 262);
			gbJLHoursWages.TabIndex = 1;
			gbJLHoursWages.TabStop = false;
			gbJLHoursWages.Text = "Job Levels";
			//
			// HoursWagesList
			//
			HoursWagesList.Anchor = AnchorStyles.Top | AnchorStyles.Left
						| AnchorStyles.Right;
			HoursWagesList.Columns.AddRange(new ColumnHeader[] {
			HwLvl,
			HwStart,
			HwHours,
			HwEnd,
			HwWages,
			HwDogWages,
			HwCatWages,
			HwMon,
			HwTue,
			HwWed,
			HwThu,
			HwFri,
			HwSat,
			HwSun});
			HoursWagesList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			HoursWagesList.FullRowSelect = true;
			HoursWagesList.GridLines = true;
			HoursWagesList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			HoursWagesList.HideSelection = false;
			HoursWagesList.Location = new System.Drawing.Point(10, 18);
			HoursWagesList.MultiSelect = false;
			HoursWagesList.Name = "HoursWagesList";
			HoursWagesList.Size = new System.Drawing.Size(1048, 232);
			HoursWagesList.TabIndex = 1;
			HoursWagesList.UseCompatibleStateImageBehavior = false;
			HoursWagesList.View = View.Details;
			HoursWagesList.SelectedIndexChanged += new EventHandler(HoursWagesList_SelectedIndexChanged);
			//
			// HwLvl
			//
			HwLvl.Text = "Lvl";
			HwLvl.Width = 49;
			//
			// HwStart
			//
			HwStart.Text = "Start";
			HwStart.Width = 74;
			//
			// HwHours
			//
			HwHours.Text = "Hours";
			HwHours.Width = 77;
			//
			// HwEnd
			//
			HwEnd.Text = "End";
			HwEnd.Width = 73;
			//
			// HwWages
			//
			HwWages.Text = "Wages";
			HwWages.Width = 75;
			//
			// HwDogWages
			//
			HwDogWages.Text = "Wages (Dog)";
			HwDogWages.Width = 106;
			//
			// HwCatWages
			//
			HwCatWages.Text = "Wages (Cat)";
			HwCatWages.Width = 106;
			//
			// HwMon
			//
			HwMon.Text = "Mon";
			HwMon.Width = 63;
			//
			// HwTue
			//
			HwTue.Text = "Tue";
			HwTue.Width = 62;
			//
			// HwWed
			//
			HwWed.Text = "Wed";
			HwWed.Width = 63;
			//
			// HwThu
			//
			HwThu.Text = "Thu";
			HwThu.Width = 63;
			//
			// HwFri
			//
			HwFri.Text = "Fri";
			HwFri.Width = 62;
			//
			// HwSat
			//
			HwSat.Text = "Sat";
			HwSat.Width = 62;
			//
			// HwSun
			//
			HwSun.Text = "Sun";
			HwSun.Width = 56;
			//
			// tabControl1
			//
			tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
						| AnchorStyles.Left
						| AnchorStyles.Right;
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Controls.Add(tabPage4);
			tabControl1.Controls.Add(tabPagMajor);
			tabControl1.ItemSize = new System.Drawing.Size(64, 18);
			tabControl1.Location = new System.Drawing.Point(1, 100);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(1100, 560);
			tabControl1.TabIndex = 9;
			//
			// tabPage1
			//
			tabPage1.BackColor = System.Drawing.SystemColors.Control;
			tabPage1.Controls.Add(gbJobDetails);
			tabPage1.Controls.Add(gbJLDetails);
			tabPage1.Location = new System.Drawing.Point(4, 22);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new System.Drawing.Size(1092, 534);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Job Details";
			//
			// gbJobDetails
			//
			gbJobDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left
						| AnchorStyles.Right;
			gbJobDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			gbJobDetails.BackColor = System.Drawing.Color.Transparent;
			gbJobDetails.Controls.Add(gcVehicle);
			gbJobDetails.Controls.Add(gcOutfit);
			gbJobDetails.Controls.Add(JobDetailsCopy);
			gbJobDetails.Controls.Add(jdpFemale);
			gbJobDetails.Controls.Add(jdpMale);
			gbJobDetails.Location = new System.Drawing.Point(10, 285);
			gbJobDetails.Name = "gbJobDetails";
			gbJobDetails.Size = new System.Drawing.Size(1069, 240);
			gbJobDetails.TabIndex = 2;
			gbJobDetails.TabStop = false;
			gbJobDetails.Text = "Current Level";
			//
			// gcVehicle
			//
			gcVehicle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			gcVehicle.AutoSize = true;
			gcVehicle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			gcVehicle.ComboBoxWidth = 300;
			gcVehicle.DropDownHeight = 250;
			gcVehicle.DropDownStyle = ComboBoxStyle.DropDown;
			gcVehicle.DropDownWidth = 300;
			gcVehicle.Label = "Vehicle";
			gcVehicle.Location = new System.Drawing.Point(620, 208);
			gcVehicle.Margin = new Padding(0);
			gcVehicle.Name = "gcVehicle";
			gcVehicle.Size = new System.Drawing.Size(442, 21);
			gcVehicle.TabIndex = 5;
			gcVehicle.Value = 3722304989u;
			gcVehicle.GUIDChooserValueChanged += new EventHandler(gcVehicle_GUIDChooserValueChanged);
			//
			// gcOutfit
			//
			gcOutfit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			gcOutfit.AutoSize = true;
			gcOutfit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			gcOutfit.ComboBoxWidth = 300;
			gcOutfit.DropDownHeight = 250;
			gcOutfit.DropDownStyle = ComboBoxStyle.DropDown;
			gcOutfit.DropDownWidth = 300;
			gcOutfit.Label = "Outfit";
			gcOutfit.Location = new System.Drawing.Point(81, 208);
			gcOutfit.Margin = new Padding(0);
			gcOutfit.Name = "gcOutfit";
			gcOutfit.Size = new System.Drawing.Size(433, 21);
			gcOutfit.TabIndex = 4;
			gcOutfit.Value = 3722304989u;
			gcOutfit.GUIDChooserValueChanged += new EventHandler(gcOutfit_GUIDChooserValueChanged);
			//
			// JobDetailsCopy
			//
			JobDetailsCopy.AutoSize = true;
			JobDetailsCopy.Location = new System.Drawing.Point(584, 100);
			JobDetailsCopy.Name = "JobDetailsCopy";
			JobDetailsCopy.Size = new System.Drawing.Size(50, 13);
			JobDetailsCopy.TabIndex = 3;
			JobDetailsCopy.TabStop = true;
			JobDetailsCopy.Text = "Copy >";
			JobDetailsCopy.LinkClicked += new LinkLabelLinkClickedEventHandler(JobDetailsCopy_LinkClicked);
			//
			// jdpFemale
			//
			jdpFemale.AutoSize = true;
			jdpFemale.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			jdpFemale.BackColor = System.Drawing.Color.Transparent;
			jdpFemale.DescLabel = "Desc Female";
			jdpFemale.DescValue = "JobDescFemale";
			jdpFemale.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			jdpFemale.Location = new System.Drawing.Point(2, 18);
			jdpFemale.Margin = new Padding(2);
			jdpFemale.Name = "jdpFemale";
			jdpFemale.Size = new System.Drawing.Size(573, 181);
			jdpFemale.TabIndex = 2;
			jdpFemale.TitleLabel = "Title Female";
			jdpFemale.TitleValue = "JobTitleFemale";
			jdpFemale.TitleValueChanged += new EventHandler(jdpFemale_TitleValueChanged);
			jdpFemale.DescValueChanged += new EventHandler(jdpFemale_DescValueChanged);
			//
			// jdpMale
			//
			jdpMale.AutoSize = true;
			jdpMale.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			jdpMale.BackColor = System.Drawing.Color.Transparent;
			jdpMale.DescLabel = "Desc Male";
			jdpMale.DescValue = "JobDescMale";
			jdpMale.Location = new System.Drawing.Point(561, 18);
			jdpMale.Margin = new Padding(2);
			jdpMale.Name = "jdpMale";
			jdpMale.Size = new System.Drawing.Size(505, 179);
			jdpMale.TabIndex = 1;
			jdpMale.TitleLabel = "Title Male";
			jdpMale.TitleValue = "JobTitleMale";
			jdpMale.TitleValueChanged += new EventHandler(jdpMale_TitleValueChanged);
			jdpMale.DescValueChanged += new EventHandler(jdpMale_DescValueChanged);
			//
			// gbJLDetails
			//
			gbJLDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left
						| AnchorStyles.Right;
			gbJLDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			gbJLDetails.BackColor = System.Drawing.Color.Transparent;
			gbJLDetails.Controls.Add(JobDetailList);
			gbJLDetails.Location = new System.Drawing.Point(10, 6);
			gbJLDetails.Name = "gbJLDetails";
			gbJLDetails.Size = new System.Drawing.Size(1069, 262);
			gbJLDetails.TabIndex = 1;
			gbJLDetails.TabStop = false;
			gbJLDetails.Text = "Job Levels";
			//
			// JobDetailList
			//
			JobDetailList.Anchor = AnchorStyles.Top | AnchorStyles.Left
						| AnchorStyles.Right;
			JobDetailList.Columns.AddRange(new ColumnHeader[] {
			JdLvl,
			JdJobTitle,
			JdDesc,
			JdOutfit,
			JdVehicle});
			JobDetailList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			JobDetailList.FullRowSelect = true;
			JobDetailList.GridLines = true;
			JobDetailList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			JobDetailList.HideSelection = false;
			JobDetailList.Location = new System.Drawing.Point(10, 18);
			JobDetailList.MultiSelect = false;
			JobDetailList.Name = "JobDetailList";
			JobDetailList.Size = new System.Drawing.Size(1056, 232);
			JobDetailList.TabIndex = 1;
			JobDetailList.UseCompatibleStateImageBehavior = false;
			JobDetailList.View = View.Details;
			JobDetailList.SelectedIndexChanged += new EventHandler(JobDetailList_SelectedIndexChanged);
			//
			// JdLvl
			//
			JdLvl.Text = "Lvl";
			JdLvl.Width = 43;
			//
			// JdJobTitle
			//
			JdJobTitle.Text = "Job Title (female)";
			JdJobTitle.Width = 205;
			//
			// JdDesc
			//
			JdDesc.Text = "Job Description (female)";
			JdDesc.Width = 473;
			//
			// JdOutfit
			//
			JdOutfit.Text = "Outfit";
			JdOutfit.Width = 160;
			//
			// JdVehicle
			//
			JdVehicle.Text = "Vehicle";
			JdVehicle.Width = 160;
			//
			// tabPagMajor
			//
			tabPagMajor.Location = new System.Drawing.Point(4, 22);
			tabPagMajor.Name = "tabPagMajor";
			tabPagMajor.Padding = new Padding(3);
			tabPagMajor.Size = new System.Drawing.Size(1092, 534);
			tabPagMajor.TabIndex = 5;
			tabPagMajor.Text = "Majors";
			tabPagMajor.UseVisualStyleBackColor = true;
			//
			// btmajApply
			//
			btmajApply.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btmajApply.Location = new System.Drawing.Point(972, 12);
			btmajApply.Name = "btmajApply";
			btmajApply.Size = new System.Drawing.Size(87, 23);
			btmajApply.TabIndex = 2;
			btmajApply.Text = "Apply";
			btmajApply.UseVisualStyleBackColor = true;
			btmajApply.Click += new EventHandler(btmajApply_Click);
			//
			// gbmajaffil
			//
			gbmajaffil.Controls.Add(label47);
			gbmajaffil.Controls.Add(cbaphyco);
			gbmajaffil.Controls.Add(cbapolit);
			gbmajaffil.Controls.Add(cbaphysi);
			gbmajaffil.Controls.Add(cbrahilo);
			gbmajaffil.Controls.Add(cbamaths);
			gbmajaffil.Controls.Add(cbaliter);
			gbmajaffil.Controls.Add(cbahisto);
			gbmajaffil.Controls.Add(cbaecon);
			gbmajaffil.Controls.Add(cbadrama);
			gbmajaffil.Controls.Add(cbabiol);
			gbmajaffil.Controls.Add(cbaArt);
			gbmajaffil.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
			gbmajaffil.Location = new System.Drawing.Point(596, 27);
			gbmajaffil.Name = "gbmajaffil";
			gbmajaffil.Size = new System.Drawing.Size(341, 449);
			gbmajaffil.TabIndex = 1;
			gbmajaffil.TabStop = false;
			gbmajaffil.Text = "Majors Affiliated";
			//
			// label47
			//
			label47.AutoSize = true;
			label47.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label47.Location = new System.Drawing.Point(8, 37);
			label47.Name = "label47";
			label47.Size = new System.Drawing.Size(317, 32);
			label47.TabIndex = 22;
			label47.Text = "A sim that has graduated one of these majors\r\nwiil get a level boost when startin" +
				"g this career";
			//
			// cbaphyco
			//
			cbaphyco.AutoSize = true;
			cbaphyco.Location = new System.Drawing.Point(27, 408);
			cbaphyco.Name = "cbaphyco";
			cbaphyco.Size = new System.Drawing.Size(110, 20);
			cbaphyco.TabIndex = 21;
			cbaphyco.Text = "Psychology";
			cbaphyco.UseVisualStyleBackColor = true;
			//
			// cbapolit
			//
			cbapolit.AutoSize = true;
			cbapolit.Location = new System.Drawing.Point(27, 376);
			cbapolit.Name = "cbapolit";
			cbapolit.Size = new System.Drawing.Size(79, 20);
			cbapolit.TabIndex = 20;
			cbapolit.Text = "Politics";
			cbapolit.UseVisualStyleBackColor = true;
			//
			// cbaphysi
			//
			cbaphysi.AutoSize = true;
			cbaphysi.Location = new System.Drawing.Point(27, 344);
			cbaphysi.Name = "cbaphysi";
			cbaphysi.Size = new System.Drawing.Size(82, 20);
			cbaphysi.TabIndex = 19;
			cbaphysi.Text = "Physics";
			cbaphysi.UseVisualStyleBackColor = true;
			//
			// cbrahilo
			//
			cbrahilo.AutoSize = true;
			cbrahilo.Location = new System.Drawing.Point(27, 312);
			cbrahilo.Name = "cbrahilo";
			cbrahilo.Size = new System.Drawing.Size(106, 20);
			cbrahilo.TabIndex = 18;
			cbrahilo.Text = "Philosophy";
			cbrahilo.UseVisualStyleBackColor = true;
			//
			// cbamaths
			//
			cbamaths.AutoSize = true;
			cbamaths.Location = new System.Drawing.Point(27, 280);
			cbamaths.Name = "cbamaths";
			cbamaths.Size = new System.Drawing.Size(121, 20);
			cbamaths.TabIndex = 17;
			cbamaths.Text = "Mathematics";
			cbamaths.UseVisualStyleBackColor = true;
			//
			// cbaliter
			//
			cbaliter.AutoSize = true;
			cbaliter.Location = new System.Drawing.Point(27, 248);
			cbaliter.Name = "cbaliter";
			cbaliter.Size = new System.Drawing.Size(99, 20);
			cbaliter.TabIndex = 16;
			cbaliter.Text = "Literature";
			cbaliter.UseVisualStyleBackColor = true;
			//
			// cbahisto
			//
			cbahisto.AutoSize = true;
			cbahisto.Location = new System.Drawing.Point(27, 216);
			cbahisto.Name = "cbahisto";
			cbahisto.Size = new System.Drawing.Size(80, 20);
			cbahisto.TabIndex = 15;
			cbahisto.Text = "History";
			cbahisto.UseVisualStyleBackColor = true;
			//
			// cbaecon
			//
			cbaecon.AutoSize = true;
			cbaecon.Location = new System.Drawing.Point(27, 184);
			cbaecon.Name = "cbaecon";
			cbaecon.Size = new System.Drawing.Size(105, 20);
			cbaecon.TabIndex = 14;
			cbaecon.Text = "Economics";
			cbaecon.UseVisualStyleBackColor = true;
			//
			// cbadrama
			//
			cbadrama.AutoSize = true;
			cbadrama.Location = new System.Drawing.Point(27, 152);
			cbadrama.Name = "cbadrama";
			cbadrama.Size = new System.Drawing.Size(75, 20);
			cbadrama.TabIndex = 13;
			cbadrama.Text = "Drama";
			cbadrama.UseVisualStyleBackColor = true;
			//
			// cbabiol
			//
			cbabiol.AutoSize = true;
			cbabiol.Location = new System.Drawing.Point(27, 120);
			cbabiol.Name = "cbabiol";
			cbabiol.Size = new System.Drawing.Size(81, 20);
			cbabiol.TabIndex = 12;
			cbabiol.Text = "Biology";
			cbabiol.UseVisualStyleBackColor = true;
			//
			// cbaArt
			//
			cbaArt.AutoSize = true;
			cbaArt.Location = new System.Drawing.Point(27, 88);
			cbaArt.Name = "cbaArt";
			cbaArt.Size = new System.Drawing.Size(49, 20);
			cbaArt.TabIndex = 11;
			cbaArt.Text = "Art";
			cbaArt.UseVisualStyleBackColor = true;
			//
			// gbrequir
			//
			gbrequir.Controls.Add(label29);
			gbrequir.Controls.Add(cbrphyco);
			gbrequir.Controls.Add(cbrpolit);
			gbrequir.Controls.Add(cbrphysi);
			gbrequir.Controls.Add(cbrphilo);
			gbrequir.Controls.Add(cbrmaths);
			gbrequir.Controls.Add(cbrliter);
			gbrequir.Controls.Add(cbrhisto);
			gbrequir.Controls.Add(cbrecon);
			gbrequir.Controls.Add(cbrdrama);
			gbrequir.Controls.Add(cbrbiol);
			gbrequir.Controls.Add(cbrArt);
			gbrequir.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
			gbrequir.Location = new System.Drawing.Point(44, 27);
			gbrequir.Name = "gbrequir";
			gbrequir.Size = new System.Drawing.Size(341, 449);
			gbrequir.TabIndex = 0;
			gbrequir.TabStop = false;
			gbrequir.Text = "Major Required";
			//
			// label29
			//
			label29.AutoSize = true;
			label29.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label29.Location = new System.Drawing.Point(18, 37);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(307, 32);
			label29.TabIndex = 11;
			label29.Text = "A sim needs to have graduated from any one\r\nof these majors to be offered this ca" +
				"reer.";
			//
			// cbrphyco
			//
			cbrphyco.AutoSize = true;
			cbrphyco.Location = new System.Drawing.Point(24, 408);
			cbrphyco.Name = "cbrphyco";
			cbrphyco.Size = new System.Drawing.Size(110, 20);
			cbrphyco.TabIndex = 10;
			cbrphyco.Text = "Psychology";
			cbrphyco.UseVisualStyleBackColor = true;
			//
			// cbrpolit
			//
			cbrpolit.AutoSize = true;
			cbrpolit.Location = new System.Drawing.Point(24, 376);
			cbrpolit.Name = "cbrpolit";
			cbrpolit.Size = new System.Drawing.Size(79, 20);
			cbrpolit.TabIndex = 9;
			cbrpolit.Text = "Politics";
			cbrpolit.UseVisualStyleBackColor = true;
			//
			// cbrphysi
			//
			cbrphysi.AutoSize = true;
			cbrphysi.Location = new System.Drawing.Point(24, 344);
			cbrphysi.Name = "cbrphysi";
			cbrphysi.Size = new System.Drawing.Size(82, 20);
			cbrphysi.TabIndex = 8;
			cbrphysi.Text = "Physics";
			cbrphysi.UseVisualStyleBackColor = true;
			//
			// cbrphilo
			//
			cbrphilo.AutoSize = true;
			cbrphilo.Location = new System.Drawing.Point(24, 312);
			cbrphilo.Name = "cbrphilo";
			cbrphilo.Size = new System.Drawing.Size(106, 20);
			cbrphilo.TabIndex = 7;
			cbrphilo.Text = "Philosophy";
			cbrphilo.UseVisualStyleBackColor = true;
			//
			// cbrmaths
			//
			cbrmaths.AutoSize = true;
			cbrmaths.Location = new System.Drawing.Point(24, 280);
			cbrmaths.Name = "cbrmaths";
			cbrmaths.Size = new System.Drawing.Size(121, 20);
			cbrmaths.TabIndex = 6;
			cbrmaths.Text = "Mathematics";
			cbrmaths.UseVisualStyleBackColor = true;
			//
			// cbrliter
			//
			cbrliter.AutoSize = true;
			cbrliter.Location = new System.Drawing.Point(24, 248);
			cbrliter.Name = "cbrliter";
			cbrliter.Size = new System.Drawing.Size(99, 20);
			cbrliter.TabIndex = 5;
			cbrliter.Text = "Literature";
			cbrliter.UseVisualStyleBackColor = true;
			//
			// cbrhisto
			//
			cbrhisto.AutoSize = true;
			cbrhisto.Location = new System.Drawing.Point(24, 216);
			cbrhisto.Name = "cbrhisto";
			cbrhisto.Size = new System.Drawing.Size(80, 20);
			cbrhisto.TabIndex = 4;
			cbrhisto.Text = "History";
			cbrhisto.UseVisualStyleBackColor = true;
			//
			// cbrecon
			//
			cbrecon.AutoSize = true;
			cbrecon.Location = new System.Drawing.Point(24, 184);
			cbrecon.Name = "cbrecon";
			cbrecon.Size = new System.Drawing.Size(105, 20);
			cbrecon.TabIndex = 3;
			cbrecon.Text = "Economics";
			cbrecon.UseVisualStyleBackColor = true;
			//
			// cbrdrama
			//
			cbrdrama.AutoSize = true;
			cbrdrama.Location = new System.Drawing.Point(24, 152);
			cbrdrama.Name = "cbrdrama";
			cbrdrama.Size = new System.Drawing.Size(75, 20);
			cbrdrama.TabIndex = 2;
			cbrdrama.Text = "Drama";
			cbrdrama.UseVisualStyleBackColor = true;
			//
			// cbrbiol
			//
			cbrbiol.AutoSize = true;
			cbrbiol.Location = new System.Drawing.Point(24, 120);
			cbrbiol.Name = "cbrbiol";
			cbrbiol.Size = new System.Drawing.Size(81, 20);
			cbrbiol.TabIndex = 1;
			cbrbiol.Text = "Biology";
			cbrbiol.UseVisualStyleBackColor = true;
			//
			// cbrArt
			//
			cbrArt.AutoSize = true;
			cbrArt.Location = new System.Drawing.Point(24, 88);
			cbrArt.Name = "cbrArt";
			cbrArt.Size = new System.Drawing.Size(49, 20);
			cbrArt.TabIndex = 0;
			cbrArt.Text = "Art";
			cbrArt.UseVisualStyleBackColor = true;
			//
			// btexApply
			//
			btexApply.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btexApply.Location = new System.Drawing.Point(972, 12);
			btexApply.Name = "btexApply";
			btexApply.Size = new System.Drawing.Size(87, 23);
			btexApply.TabIndex = 4;
			btexApply.Text = "Apply";
			btexApply.UseVisualStyleBackColor = true;
			btexApply.Click += new EventHandler(exApply_Click);
			//
			// CareerLvls
			//
			CareerLvls.BackColor = System.Drawing.SystemColors.Window;
			CareerLvls.Location = new System.Drawing.Point(430, 35);
			CareerLvls.Name = "CareerLvls";
			CareerLvls.ReadOnly = true;
			CareerLvls.Size = new System.Drawing.Size(30, 21);
			CareerLvls.TabIndex = 25;
			CareerLvls.Text = "00";
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(354, 39);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(72, 13);
			label1.TabIndex = 3;
			label1.Text = "Career Lvls";
			label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// CareerTitle
			//
			CareerTitle.Location = new System.Drawing.Point(157, 35);
			CareerTitle.Name = "CareerTitle";
			CareerTitle.Size = new System.Drawing.Size(181, 21);
			CareerTitle.TabIndex = 2;
			CareerTitle.TextChanged += new EventHandler(CareerTitle_TextChanged);
			//
			// label3
			//
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(79, 39);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(75, 13);
			label3.TabIndex = 1;
			label3.Text = "Career Title";
			label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// Language
			//
			Language.Location = new System.Drawing.Point(565, 35);
			Language.Name = "Language";
			Language.Size = new System.Drawing.Size(188, 21);
			Language.TabIndex = 6;
			Language.SelectedIndexChanged += new EventHandler(Language_SelectedIndexChanged);
			//
			// label10
			//
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(503, 39);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(62, 13);
			label10.TabIndex = 5;
			label10.Text = "Language";
			//
			// mainMenu1
			//
			mainMenu1.BackColor = System.Drawing.SystemColors.Control;
			mainMenu1.Items.AddRange(new ToolStripItem[] {
			menuItem6,
			menuItem1});
			mainMenu1.Location = new System.Drawing.Point(0, 0);
			mainMenu1.Name = "mainMenu1";
			mainMenu1.Size = new System.Drawing.Size(1104, 24);
			mainMenu1.TabIndex = 0;
			mainMenu1.Text = "mainMenu1";
			//
			// menuItem6
			//
			menuItem6.DropDownItems.AddRange(new ToolStripItem[] {
			miAddLvl,
			miRemoveLvl});
			menuItem6.Name = "menuItem6";
			menuItem6.Size = new System.Drawing.Size(51, 20);
			menuItem6.Text = "&Levels";
			//
			// miAddLvl
			//
			miAddLvl.Name = "miAddLvl";
			miAddLvl.Size = new System.Drawing.Size(147, 22);
			miAddLvl.Text = "&Add Level";
			miAddLvl.Click += new EventHandler(miAddLvl_Click);
			//
			// miRemoveLvl
			//
			miRemoveLvl.Name = "miRemoveLvl";
			miRemoveLvl.Size = new System.Drawing.Size(147, 22);
			miRemoveLvl.Text = "&Remove Level";
			miRemoveLvl.Click += new EventHandler(miRemoveLvl_Click);
			//
			// menuItem1
			//
			menuItem1.DropDownItems.AddRange(new ToolStripItem[] {
			miEnglishOnly});
			menuItem1.Name = "menuItem1";
			menuItem1.Size = new System.Drawing.Size(76, 20);
			menuItem1.Text = "L&anguages";
			//
			// miEnglishOnly
			//
			miEnglishOnly.Name = "miEnglishOnly";
			miEnglishOnly.Size = new System.Drawing.Size(155, 22);
			miEnglishOnly.Text = "US English only";
			miEnglishOnly.Click += new EventHandler(miEnglishOnly_Click);
			//
			// gcUpgrade
			//
			gcUpgrade.AutoSize = true;
			gcUpgrade.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			gcUpgrade.ComboBoxWidth = 220;
			gcUpgrade.DropDownHeight = 250;
			gcUpgrade.DropDownStyle = ComboBoxStyle.DropDown;
			gcUpgrade.DropDownWidth = 220;
			gcUpgrade.Label = "Upgrade";
			gcUpgrade.Location = new System.Drawing.Point(449, 68);
			gcUpgrade.Margin = new Padding(0);
			gcUpgrade.Name = "gcUpgrade";
			gcUpgrade.Size = new System.Drawing.Size(370, 21);
			gcUpgrade.TabIndex = 13;
			gcUpgrade.Value = 3722304989u;
			//
			// gcReward
			//
			gcReward.AutoSize = true;
			gcReward.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			gcReward.ComboBoxWidth = 220;
			gcReward.DropDownHeight = 250;
			gcReward.DropDownStyle = ComboBoxStyle.DropDown;
			gcReward.DropDownWidth = 220;
			gcReward.Label = "Reward";
			gcReward.Location = new System.Drawing.Point(76, 68);
			gcReward.Margin = new Padding(0);
			gcReward.Name = "gcReward";
			gcReward.Size = new System.Drawing.Size(365, 21);
			gcReward.TabIndex = 12;
			gcReward.Value = 3722304989u;
			//
			// lbcrap
			//
			lbcrap.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			lbcrap.AutoSize = true;
			lbcrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lbcrap.ForeColor = System.Drawing.Color.DarkRed;
			lbcrap.Location = new System.Drawing.Point(823, 62);
			lbcrap.Name = "lbcrap";
			lbcrap.Size = new System.Drawing.Size(274, 30);
			lbcrap.TabIndex = 14;
			lbcrap.Text = "Old Career Type!\r\nNot compatible with Seasons EP or above";
			lbcrap.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lbcrap.Visible = false;
			//
			// btUgrade
			//
			btUgrade.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btUgrade.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btUgrade.Location = new System.Drawing.Point(936, 30);
			btUgrade.Name = "btUgrade";
			btUgrade.Size = new System.Drawing.Size(162, 23);
			btUgrade.TabIndex = 24;
			btUgrade.Text = "Upgrade to Latest EP";
			btUgrade.UseVisualStyleBackColor = true;
			btUgrade.Visible = false;
			btUgrade.Click += new EventHandler(btUgrade_Click);
			//
			// pictureBox1
			//
			pictureBox1.Location = new System.Drawing.Point(8, 30);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(64, 64);
			pictureBox1.TabIndex = 3;
			pictureBox1.TabStop = false;
			//
			// toolTip1
			//
			toolTip1.AutoPopDelay = 20000;
			toolTip1.InitialDelay = 500;
			toolTip1.ReshowDelay = 100;
			toolTip1.ToolTipIcon = ToolTipIcon.Info;
			toolTip1.ToolTipTitle = "Note";
			//
			// CareerEditor
			//
			AutoScaleMode = AutoScaleMode.Inherit;
			AutoScroll = true;
			ClientSize = new System.Drawing.Size(1104, 661);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = mainMenu1;
			MinimumSize = new System.Drawing.Size(1120, 700);
			Name = "CareerEditor";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Career Editor (by Bidou)";
			tabPage4.ResumeLayout(false);
			tabPage4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			tcChanceOutcome.ResumeLayout(false);
			tabPage5.ResumeLayout(false);
			tabPage5.PerformLayout();
			tabPage6.ResumeLayout(false);
			tabPage6.PerformLayout();
			tabPage7.ResumeLayout(false);
			tabPage7.PerformLayout();
			tabPage8.ResumeLayout(false);
			tabPage8.PerformLayout();
			tabPage3.ResumeLayout(false);
			gbJLPromo.ResumeLayout(false);
			gbPromo.ResumeLayout(false);
			gbPromo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)PromoFriends).EndInit();
			((System.ComponentModel.ISupportInitialize)PromoCleaning).EndInit();
			((System.ComponentModel.ISupportInitialize)PromoLogic).EndInit();
			((System.ComponentModel.ISupportInitialize)PromoCreativity).EndInit();
			((System.ComponentModel.ISupportInitialize)PromoCharisma).EndInit();
			((System.ComponentModel.ISupportInitialize)PromoBody).EndInit();
			((System.ComponentModel.ISupportInitialize)PromoMechanical).EndInit();
			((System.ComponentModel.ISupportInitialize)PromoCooking).EndInit();
			tabPage2.ResumeLayout(false);
			gbHoursWages.ResumeLayout(false);
			gbHoursWages.PerformLayout();
			gbHWMotives.ResumeLayout(false);
			gbHWMotives.PerformLayout();
			((System.ComponentModel.ISupportInitialize)ComfortHours).EndInit();
			((System.ComponentModel.ISupportInitialize)HygieneTotal).EndInit();
			((System.ComponentModel.ISupportInitialize)BladderTotal).EndInit();
			((System.ComponentModel.ISupportInitialize)WorkBladder).EndInit();
			((System.ComponentModel.ISupportInitialize)WorkComfort).EndInit();
			((System.ComponentModel.ISupportInitialize)HungerHours).EndInit();
			((System.ComponentModel.ISupportInitialize)EnergyHours).EndInit();
			((System.ComponentModel.ISupportInitialize)WorkPublic).EndInit();
			((System.ComponentModel.ISupportInitialize)WorkHunger).EndInit();
			((System.ComponentModel.ISupportInitialize)BladderHours).EndInit();
			((System.ComponentModel.ISupportInitialize)ComfortTotal).EndInit();
			((System.ComponentModel.ISupportInitialize)HungerTotal).EndInit();
			((System.ComponentModel.ISupportInitialize)HygieneHours).EndInit();
			((System.ComponentModel.ISupportInitialize)WorkEnergy).EndInit();
			((System.ComponentModel.ISupportInitialize)WorkFun).EndInit();
			((System.ComponentModel.ISupportInitialize)WorkSunshine).EndInit();
			((System.ComponentModel.ISupportInitialize)PublicHours).EndInit();
			((System.ComponentModel.ISupportInitialize)SunshineTotal).EndInit();
			((System.ComponentModel.ISupportInitialize)EnergyTotal).EndInit();
			((System.ComponentModel.ISupportInitialize)FunTotal).EndInit();
			((System.ComponentModel.ISupportInitialize)PublicTotal).EndInit();
			((System.ComponentModel.ISupportInitialize)FunHours).EndInit();
			((System.ComponentModel.ISupportInitialize)WorkHygiene).EndInit();
			((System.ComponentModel.ISupportInitialize)SunshineHours).EndInit();
			((System.ComponentModel.ISupportInitialize)numLscore).EndInit();
			((System.ComponentModel.ISupportInitialize)numPTO).EndInit();
			gbJLHoursWages.ResumeLayout(false);
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			gbJobDetails.ResumeLayout(false);
			gbJobDetails.PerformLayout();
			gbJLDetails.ResumeLayout(false);
			tabPagMajor.ResumeLayout(false);
			gbmajaffil.ResumeLayout(false);
			gbmajaffil.PerformLayout();
			gbrequir.ResumeLayout(false);
			gbrequir.PerformLayout();
			mainMenu1.ResumeLayout(false);
			mainMenu1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);

		}
		#endregion

		#region Global
		private Packages.GeneratableFile package;
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

		private static string[] rewardName = new string[] {
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
		private static uint[] rewardGUID = new uint[] {
				0x0C6E194A, 0xAEB9F591, 0x8C4D2997, 0xCEA505BB,
				0xD1CD15C8, 0x4E9FBE5D, 0xCC58DF85, 0x6C2979FB,
				0xCC16D816, 0xCC20426A, 0x4C2148B0, 0xAE8D50B2,
				0x6C6CE31F, 0xAC314A3A, 0xB3FD5372, 0x33EC6E0A,
				0x524E1066, 0x33E2E4E8, 0x324D0D87, 0xD24CE39C,
				0x53EDA12F, 0x124E3138, 0xF24CFF80, 0xB3FEC1B6,
				0xD24D09FD,
		};

		private static string[] upgradeName = new string[] {
			"Adventurer", "Artist", "Athletics", "Business",
			"Construction", "Criminal", "Culinary", "Dance",
			"Economy", "Entertainment", "Education", "Gamer",
			"Intelligence", "Journalism", "Law", "Law Enforcement",
			"Medicine", "Military", "Music", "NaturalScientist",
			"Ocenography", "Paranormal", "Politics", "Science",
			"ShowBiz", "Slacker", "Owned Business",
		};
		private static uint[] upgradeGUID = new uint[] {
			0x3240CBA5, 0x4E6FFFBC, 0x2C89E95F, 0x45196555,
			0xF3E1C301, 0x6C9EBD0E, 0xEC9EBD5F, 0xD3E09422,
			0x45196555, 0xB3E09417, 0x72428B30, 0xF240C306,
			0x33E0940E, 0x7240D944, 0x12428B19, 0xAC9EBCE3,
			0x0C7761FD, 0x6C9EBD32, 0xB2428B0C, 0xEE70001C,
			0x73E09404, 0x2E6FFF87, 0x2C945B14, 0x0C9EBD47,
			0xAE6FFFB0, 0xEC77620B, 0xD08F400A,
		};

		// end crap, start goody

		private static string[] TArewardName = new string[] {
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
		private static uint[] TArewardGUID = new uint[] {
				0x0C6E194A, 0xAEB9F591, 0x8C4D2997, 0xCEA505BB,
				0xD1CD15C8, 0x4E9FBE5D, 0xCC58DF85, 0x6C2979FB,
				0xCC16D816, 0xCC20426A, 0x4C2148B0, 0xAE8D50B2,
				0x6C6CE31F, 0xAC314A3A, 0xB3FD5372, 0x33EC6E0A,
				0x524E1066, 0x33E2E4E8, 0x324D0D87, 0xD24CE39C,
				0x53EDA12F, 0x124E3138, 0xF24CFF80, 0xB3FEC1B6,
				0xD24D09FD, 0x00845D23,
		};

		private static string[] TAupgradeName = new string[] {
			"Adventurer", "Artist", "Athletics", "Business",
			"Construction", "Criminal", "Culinary", "Dance",
			"Economy", "Entertainment", "Education", "Gamer",
			"Intelligence", "Journalism", "Law", "Law Enforcement",
			"Medicine", "Military", "Music", "NaturalScientist",
			"Ocenography", "Paranormal", "Politics", "Science",
			"ShowBiz", "Slacker",
			"Owned Business", "Party Industry",
		};

		private static uint[] TAupgradeGUID = new uint[] {
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

		private static string[] CSrewardName = new string[] { "Shaman Station", "Electronic Crafting Station", "Obstacle Course", };
		private static uint[] CSrewardGUID = new uint[] { 0xB3ED7E27, 0xD3CF5048, 0xB3D1BACF, };
		private static string[] CSupgradeName = new string[] { "Gatherer", "Crafter", "Hunter", };
		private static uint[] CSupgradeGUID = new uint[] { 0x738D6245, 0xD38D6534, 0x93701850, };

		private Instruction AddRewardToInventory = null;
		private Instruction JobUpgrade = null;

		private void setRewardFromGUID()
		{
			setGCFromIns(gcReward, AddRewardToInventory, 5);
		}
		private void getGUIDFromReward()
		{
			setInsFromGC(gcReward, AddRewardToInventory, 5);
		}
		private void setUpgradeFromGUID()
		{
			setGCFromIns(gcUpgrade, JobUpgrade, 0);
		}
		private void getGUIDFromUpgrade()
		{
			setInsFromGC(gcUpgrade, JobUpgrade, 0);
		}

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
			gc.Value = (uint)(o[op] | (o[op + 1] << 8) | (o[op + 2] << 16) | (o[op + 3] << 24));
		}
		private void setInsFromGC(GUIDChooser gc, Instruction ins, int op)
		{
			if (ins == null)
			{
				return; // Should never happen
			}

			if (gc.Value == 0) // Was something, now "None"
			{
				ins.Parent.FileDescriptor.MarkForDelete = true;
				ins.Parent.Changed = true;
				return;
			}
			uint guid = gc.Value;
			for (int i = 0; i < 4; i++)
			{
				if (op + i < 8)
				{
					ins.Operands[op + i] = (byte)((guid >> (i * 8)) & 0xff);
				}
				else
				{
					ins.Reserved1[op + i - 8] = (byte)((guid >> (i * 8)) & 0xff);
				}
			}
		}

		private bool isPetCareer = false;
		private bool isTeenCareer = false;

		private ushort noLevels;
		private ushort femaleOffset;
		private void noLevelsChanged(ushort l)
		{
			ushort oldNoLevels = noLevels;
			ushort oldLevel = currentLevel;
			if (l > oldNoLevels)
			{
				oldLevel++;
			}
			else if (oldLevel > 1)
			{
				oldLevel--;
			}

			noLevels = l;
			femaleOffset = (ushort)(2 * noLevels);

			miAddLvl.Enabled = noLevels < 100;
			miRemoveLvl.Enabled = noLevels > 1;

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
			if (levelChanging || newLevel == currentLevel)
			{
				return;
			}

			internalchg = levelChanging = true;

			//lbPTO.Text = "Paid Time Off (PTO) Daily Accruement " + PTO[newLevel];
			numPTO.Value = PTO[newLevel];

			if (lifeScore != null)
			{
				numLscore.Value = lifeScore[newLevel];
			}
			else
			{
				lbLscore.Visible = numLscore.Visible = false;
			}

			#region job details
			JobDetailList.SelectedIndices.Clear();
			JobDetailList.Items[newLevel - 1].Selected = true;
			gbJobDetails.Text = "Current Level: " + newLevel;

			List<StrItem> items = jobTitles[currentLanguage];
			jdpMale.TitleValue = items[((newLevel - 1) * 2) + 1].Title;
			jdpMale.DescValue = items[((newLevel - 1) * 2) + 2].Title;
			jdpFemale.TitleValue = items[femaleOffset + ((newLevel - 1) * 2) + 1].Title;
			jdpFemale.DescValue = items[femaleOffset + ((newLevel - 1) * 2) + 2].Title;

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
			{
				lnudFoods.Value = foodinc[newLevel];
			}

			if (!isPetCareer)
			{
				lnudWages.Value = wages[newLevel] > lnudWages.Maximum ? lnudWages.Maximum : wages[newLevel];

				lnudWagesDog.Visible = lnudWagesCat.Visible = false;
			}
			else
			{
				lnudWages.Enabled = false;
				lnudWagesDog.Value = wagesDog[newLevel] > lnudWagesDog.Maximum ? lnudWagesDog.Maximum : wagesDog[newLevel];

				lnudWagesCat.Value = wagesCat[newLevel] > lnudWagesCat.Maximum ? lnudWagesCat.Maximum : wagesCat[newLevel];
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
				{
					if (trick[(i * 2) + 1] == newLevel)
					{
						cbTrick.SelectedIndex = trick[i * 2];
					}
				}
			}

			PromoFriends.Value = friends[newLevel];
			#endregion

			//chance cards
			chanceCardsLevelChanged(newLevel);

			currentLevel = newLevel;
			internalchg = levelChanging = false;
		}

		private byte currentLanguage;
		private List<string> languageString;
		private bool englishOnly;

		#endregion

		#region Job Details
		#region Job Titles
		private StrWrapper jobTitles;
		private void fillJobDetails()
		{
			JobDetailList.Items.Clear();
			for (int i = jobTitles[currentLanguage].Count; i < (noLevels * 4) + 1; i++)
			{
				jobTitles.Add(currentLanguage, "", "");
			}

			List<StrItem> items = jobTitles[currentLanguage];
			for (ushort i = 0; i < noLevels; i++)
			{
				ListViewItem item1 = new ListViewItem("" + (i + 1), 0);
				item1.SubItems.Add(items[femaleOffset + (i * 2) + 1].Title);
				item1.SubItems.Add(items[femaleOffset + (i * 2) + 2].Title);
				item1.SubItems.Add(getOutfitTextFromGUIDAt(i + 1));
				if (isCastaway)
				{
					item1.SubItems.Add("");
				}
				else
				{
					item1.SubItems.Add(getVehicleTextFromGUID(i + 1));
				}

				JobDetailList.Items.Add(item1);
			}
		}
		#endregion

		#region Outfits Vehicles

		private Bcon outfit;
		private Bcon vehicle;

		private string getOutfitTextFromGUIDAt(int i)
		{
			return isCastaway
				? StringFromGUID(GUIDfromBCON(outfit, i), CSoutfitGUID, CSoutfitName)
				: StringFromGUID(GUIDfromBCON(outfit, i), outfitGUID, outfitName);
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

		private static uint[] outfitGUID = {
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

		private static string[] outfitName = new string[] {
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

		private static uint[] vehicleGUID = new uint[] {
			0xAD0AB49C, 0x0D099B93, 0xAC43E058, 0x4CA1487C,
			0x6C6CDEC6, 0xCC69FDA3, 0xEC860630, 0x0CA42373,
			0x8C5A4D9E, 0x4D50E553, 0x4C03451A, 0x6CA4110A,
			0x4C413B80, 0x0C85AE14, 0xCD08624E, 0x4D09B954,
		};
		private static string[] vehicleName = new string[] {
			"Captain Hero Flyaway", "Helicopter - Executive", "Helicopter - Army", "Town Car",
			"Sports Car - Super", "Sports Car - Mid", "Sports Car - Low", "Sports Team Bus",
			"Sedan", "Taxi", "Minivan", "Limo",
			"HMV", "Hatchback", "Police", "Ambulance",
		};

		// End Shit - Start good

		private static uint[] TAoutfitGUID = {
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

		private static string[] TAoutfitName = new string[] {
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

		private static uint[] TAvehicleGUID = new uint[] {
			0xAD0AB49C, 0x0D099B93, 0xAC43E058, 0x4CA1487C,
			0x6C6CDEC6, 0xCC69FDA3, 0xEC860630, 0x0CA42373,
			0x8C5A4D9E, 0x4D50E553, 0x4C03451A, 0x6CA4110A,
			0x4C413B80, 0x0C85AE14, 0xCD08624E, 0x4D09B954,
			0x00845D0F, 0x00845D41,
		};
		private static string[] TAvehicleName = new string[] {
			"Captain Hero Flyaway", "Helicopter - Executive", "Helicopter - Army", "Town Car",
			"Sports Car - Super", "Sports Car - Mid", "Sports Car - Low", "Sports Team Bus",
			"Sedan", "Taxi", "Minivan", "Limo",
			"HMV", "Hatchback", "Police", "Ambulance",
			"Princess Van", "White Limo",
		};

		private static uint[] CSoutfitGUID = { 0xB431D8A0, 0x9431D91A, 0x7431D945, };
		private static string[] CSoutfitName = new string[] { "Career Crafter", "Career Gatherer", "Career Hunter", };

		#endregion

		private uint GUIDfromBCON(Bcon bcon, int i)
		{
			return (uint)(((ushort)bcon[(i * 2) + 1] << 16) | ((ushort)bcon[i * 2]));
		}
		private string StringFromGUID(uint guid, uint[] guids, string[] strings)
		{
			if (guid == 0)
			{
				return "";
			}

			int index = new List<uint>(guids).IndexOf(guid);
			return index >= 0 ? strings[index] : "Other";
		}
		private void insertGuid(Bcon bcon, int index, uint guid)
		{
			List<short> bconItem = new List<short>();
			foreach (short i in bcon)
			{
				bconItem.Add(i);
			}

			bconItem.Insert((index + 1) * 2, (short)(guid & 0xffff));
			bconItem.Insert(((index + 1) * 2) + 1, (short)((guid >> 16) & 0xffff));
			bcon.Clear();
			foreach (short i in bconItem)
			{
				bcon.Add(i);
			}
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
				item1.SubItems.Add("" + ((startHour[i] + hoursWorked[i]) % 24));
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
					item1.SubItems.Add("" + (skillReq[COOKING][i] / 100));
					item1.SubItems.Add("" + (skillReq[MECHANICAL][i] / 100));
					item1.SubItems.Add("" + (skillReq[BODY][i] / 100));
					item1.SubItems.Add("" + (skillReq[CHARISMA][i] / 100));
					item1.SubItems.Add("" + (skillReq[CREATIVITY][i] / 100));
					item1.SubItems.Add("" + (skillReq[LOGIC][i] / 100));
					item1.SubItems.Add("" + (skillReq[CLEANING][i] / 100));
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
					string tr = (string)cbTrick.Items[0];
					for (int j = 0; j * 2 < trick.Count; j++)
					{
						if (trick[(j * 2) + 1] == i)
						{
							tr = (string)cbTrick.Items[trick[j * 2]];
						}
					}

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
			if (currentLevel != 0 && currentLevel <= noLevels)
			{
				chanceCardsToFiles();
			}

			lnudChanceCurrentLevel.Value = newLevel;
			if (isPetCareer)
			{
				lnudPetChancePercent.Value = chanceAchance[newLevel];
				lnudPetChancePercent.Visible = true;
				lnudChancePercent.Value = chanceBchance[newLevel];
			}
			else
			{
				lnudChancePercent.Value = chanceChance[newLevel];
			}

			cpChoiceA.HaveSkills = cpChoiceB.HaveSkills = chanceChance[newLevel] < 0 && !isPetCareer;

			if (preuniv)
			{
				cbischance.Visible = false;
			}
			else
			{
				cbischance.Checked = cclevels[newLevel] > 0;
			}

			for (int i = chanceCardsText[currentLanguage].Count; i < (newLevel * 12) + 19; i++)
			{
				chanceCardsText.Add(currentLanguage, "", "");
			}

			List<StrItem> items = chanceCardsText[currentLanguage];

			cpChoiceA.setValues(true, cpChoiceA.Label, items[(newLevel * 12) + 7].Title, chanceASkills, newLevel);
			cpChoiceB.setValues(false, cpChoiceB.Label, items[(newLevel * 12) + 8].Title, chanceBSkills, newLevel);

			ChanceTextMale.Text = items[(newLevel * 12) + 9].Title;
			ChanceTextFemale.Text = items[(newLevel * 12) + 10].Title;

			epPassA.setValues(noLevels, newLevel, chanceAGood, items[(newLevel * 12) + 11].Title, items[(newLevel * 12) + 12].Title);
			epFailA.setValues(noLevels, newLevel, chanceABad, items[(newLevel * 12) + 13].Title, items[(newLevel * 12) + 14].Title);
			epPassB.setValues(noLevels, newLevel, chanceBGood, items[(newLevel * 12) + 15].Title, items[(newLevel * 12) + 16].Title);
			epFailB.setValues(noLevels, newLevel, chanceBBad, items[(newLevel * 12) + 17].Title, items[(newLevel * 12) + 18].Title);
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
			{
				chanceChance[currentLevel] = (short)lnudChancePercent.Value;
			}

			items[(currentLevel * 12) + 7].Title = cpChoiceA.Value;
			if (!isPetCareer)
			{
				cpChoiceA.getValues(chanceASkills, currentLevel);
			}

			items[(currentLevel * 12) + 8].Title = cpChoiceB.Value;
			if (!isPetCareer)
			{
				cpChoiceB.getValues(chanceBSkills, currentLevel);
			}

			items[(currentLevel * 12) + 9].Title = ChanceTextMale.Text;
			items[(currentLevel * 12) + 10].Title = ChanceTextFemale.Text;

			string male = "", female = "";
			epPassA.getValues(chanceAGood, currentLevel, ref male, ref female);
			items[(currentLevel * 12) + 11].Title = male;
			items[(currentLevel * 12) + 12].Title = female;

			epFailA.getValues(chanceABad, currentLevel, ref male, ref female);
			items[(currentLevel * 12) + 13].Title = male;
			items[(currentLevel * 12) + 14].Title = female;

			epPassB.getValues(chanceBGood, currentLevel, ref male, ref female);
			items[(currentLevel * 12) + 15].Title = male;
			items[(currentLevel * 12) + 16].Title = female;

			epFailB.getValues(chanceBBad, currentLevel, ref male, ref female);
			items[(currentLevel * 12) + 17].Title = male;
			items[(currentLevel * 12) + 18].Title = female;
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
		public Interfaces.Plugin.IToolResult Execute(ref Interfaces.Files.IPackedFileDescriptor pfd, ref Interfaces.Files.IPackageFile package, Interfaces.IProviderRegistry prov)
		{
			bool newpackage = false;

			this.package = (Packages.GeneratableFile)package;

			WaitingScreen.Wait();
			try
			{
				if (this.package == null || this.package.FileName == null)
				{
					Stream s = typeof(CareerEditor).Assembly.GetManifestResourceStream(CareerTool.DefaultCareerFile);
					BinaryReader br = new BinaryReader(s);
					this.package = Packages.File.LoadFromStream(br);
					newpackage = true;
					this.package = (Packages.GeneratableFile)this.package.Clone();
				}
				if (!pjse.GUIDIndex.TheGUIDIndex.IsLoaded)
				{
					pjse.GUIDIndex.TheGUIDIndex.Load(pjse.GUIDIndex.DefaultGUIDFile);
				}

				loadFiles();
				if (isCastaway)
				{
					gcReward.KnownObjects = new object[] { new List<string>(CSrewardName), new List<uint>(CSrewardGUID) };
					gcUpgrade.KnownObjects = new object[] { new List<string>(CSupgradeName), new List<uint>(CSupgradeGUID) };
					gcOutfit.KnownObjects = new object[] { new List<string>(CSoutfitName), new List<uint>(CSoutfitGUID) };
					tabControl1.Controls.Remove(tabPagMajor);
					gcVehicle.Visible = false;
					Text = isTeenCareer
						? tuning[0] == 4
							? "Career Editor (by Bidou) - Castaway Orangutan Career"
							: "Career Editor (by Bidou) - Castaway Teen, Elder Career"
						: "Career Editor (by Bidou) - Castaway Stories Adult Career";

					lnudWages.Label = "Resource";
					lnudWages.Location = new System.Drawing.Point(39, 71);
					lnudFoods.Visible = true;
					HwWages.Text = "Resource";
					HwDogWages.Text = "Food";
				}
				else
				{

					if (preuniv || isPetCareer || isTeenCareer)
					{
						tabControl1.Controls.Remove(tabPagMajor);
					}
					else
					{
						setmajors();
					}

					if (isPetCareer)
					{
						Text = "Career Editor (by Bidou) - Pet Career";
					}
					else
					{
						Text = isTeenCareer ? "Career Editor (by Bidou) - Teen, Elder Career" : "Career Editor (by Bidou) - Adult Career";
					}
				}
				Interfaces.Files.IPackedFileDescriptor bfd = this.package.FindFile(0x856DDBAC, 0, groupId, 1);
				if (bfd != null)
				{
					Picture pic = new Picture();
					pic.ProcessData(bfd, this.package);
					pictureBox1.Image = pic.Image;
				}
				else
				{
					pictureBox1.Image = null;
				}

				//menuItem6.Enabled = !isPetCareer;
				miEnglishOnly.Checked = englishOnly;

				if (catalogueDesc.Languages.Length <= 1)
				{
					currentLanguage = 1;
				}
				else
				{
					currentLanguage = (byte)Helper.WindowsRegistry.LanguageCode; // CJH
				}

				internalchg = true;

				setRewardFromGUID();
				setUpgradeFromGUID();

				Language.DataSource = languageString;
				Language.SelectedIndex = currentLanguage - 1;

				CareerTitle.Text = (catalogueDesc[currentLanguage].Count == 0) ? "" : catalogueDesc[currentLanguage, 0].Title;

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
				return new ToolResult(false, false);
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

			if (newpackage)
			{
				package = this.package;
			}

			return new ToolResult(true, newpackage);
		}


		private Bcon getBcon(uint instance)
		{
			Interfaces.Files.IPackedFileDescriptor pfd = package.FindFile(0x42434F4E, 0, groupId, instance);
			if (pfd == null)
			{
				return null;
			}

			Bcon bcon = new Bcon();
			bcon.ProcessData(pfd, package);
			return bcon;
		}
		private bool makeBcon(uint instance, int lvls, string flname)
		{
			package.Add(package.NewDescriptor(0x42434F4E, 0, groupId, instance));
			Interfaces.Files.IPackedFileDescriptor pfd = package.FindFile(0x42434F4E, 0, groupId, instance);
			if (pfd == null)
			{
				return false;
			}

			lvls++;
			Bcon bcon = new Bcon();
			bcon.ProcessData(pfd, package);
			bcon.FileName = flname;
			for (int i = 0; i < lvls; i++)
			{
				bcon.Add(0);
			}

			bcon.SynchronizeUserData();
			return true;
		}
		private void insertBcon(Bcon bcon, int index, short value)
		{
			List<short> bconItem = new List<short>();
			foreach (short i in bcon)
			{
				bconItem.Add(i);
			}

			bconItem.Insert(index, value);
			bcon.Clear();
			foreach (short i in bconItem)
			{
				bcon.Add(i);
			}
		}

		private StrWrapper getCtss()
		{
			return getStr(package.FindFiles(Data.MetaData.CTSS_FILE)[0]);
		}
		private StrWrapper getStr(uint instance)
		{
			return getStr(package.FindFile(0x53545223, 0, groupId, instance));
		}
		private StrWrapper getStr(Interfaces.Files.IPackedFileDescriptor pfd)
		{
			if (pfd == null)
			{
				return null;
			}

			StrWrapper str = new StrWrapper();
			str.ProcessData(pfd, package);

			// This makes sure US English is as long the longest str[lng] array
			int count = 0;
			for (byte i = 1; i <= languageString.Count; i++)
			{
				count = Math.Max(count, str[i].Count);
			}

			while (count > 0 && str[1, count - 1] == null)
			{
				str.Add(1, "", "");
			}

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
				if (p.MarkForDelete || p.Invalid || p.Group != groupId)
				{
					continue;
				}

				bhav = new Bhav();
				bhav.ProcessData(p, package);

				#region Find Career Reward
				if (bhav.FileName.Equals("CT - Career Reward")) // Must be adult career
				{
					isTeenCareer = false;
					foreach (Instruction ins in bhav)
					{
						if (ins.OpCode == 0x0033) // Manage Inventory
						{
							AddRewardToInventory = ins;
							break;
						}
					}

					continue;
				}
				#endregion

				#region Find Job Ugrade
				if (bhav.FileName.Equals("CT - Upgrade Job to Adult")) // Must be Teen - Elder career
				{
					isTeenCareer = true;
					foreach (Instruction ins in bhav)
					{
						if (ins.OpCode == 0x001f || // Set To Next
							ins.OpCode == 0x0020) // Test Object Of Type (Owned Business uses this)
						{
							JobUpgrade = ins;
							break;
						}
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
				lbcrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
				lbcrap.ForeColor = System.Drawing.Color.DarkMagenta;
				lbcrap.Text = "Castaway Stories Career";
				lbcrap.Visible = true;
			}
			else
			{
				if (getBcon(0x1059) == null)
				{
					motiveDeltas[SUNSHINE] = getBcon(0x100F); // CJH
					WorkSunshine.Enabled = false;
					lbcrap.Visible = btUgrade.Visible = !isPetCareer;
				}
				else
				{
					motiveDeltas[SUNSHINE] = getBcon(0x1059);
					WorkSunshine.Enabled = true;
					if (getBcon(0x105B) == null)
					{
						lbcrap.Visible = false;
					}
				}
				if (getBcon(0x1056) == null)
				{
					btUgrade.Visible = true;
					lbcrap.Text = "Really Old Career Type!\r\nIncompatible with University EP or above";
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
			if (catalogueDesc.Changed)
			{
				catalogueDesc.SynchronizeUserData();
			}

			if (lifeScore != null && lifeScore.Changed)
			{
				lifeScore.SynchronizeUserData();
			}

			if (PTO.Changed)
			{
				PTO.SynchronizeUserData();
			}

			if (AddRewardToInventory != null && AddRewardToInventory.Parent.Changed)
			{
				AddRewardToInventory.Parent.SynchronizeUserData();
			}

			if (JobUpgrade != null && JobUpgrade.Parent.Changed)
			{
				JobUpgrade.Parent.SynchronizeUserData();
			}

			if (tuning.Changed)
			{
				tuning.SynchronizeUserData();
			}

			// Job Details
			if (jobTitles.Changed)
			{
				jobTitles.SynchronizeUserData();
			}

			if (vehicle.Changed)
			{
				vehicle.SynchronizeUserData();
			}

			if (outfit.Changed)
			{
				outfit.SynchronizeUserData();
			}

			// Hours & Wages
			if (startHour.Changed)
			{
				startHour.SynchronizeUserData();
			}

			if (hoursWorked.Changed)
			{
				hoursWorked.SynchronizeUserData();
			}

			if (!isPetCareer)
			{
				if (wages.Changed)
				{
					wages.SynchronizeUserData();
				}
			}
			else
			{
				if (wagesDog.Changed)
				{
					wagesDog.SynchronizeUserData();
				}

				if (wagesCat.Changed)
				{
					wagesCat.SynchronizeUserData();
				}
			}
			if (isCastaway)
			{
				if (foodinc.Changed)
				{
					foodinc.SynchronizeUserData();
				}

				if (resinc.Changed)
				{
					resinc.SynchronizeUserData();
				}
			}
			if (daysWorked.Changed)
			{
				daysWorked.SynchronizeUserData();
			}

			for (int i = 0; i < 9; i++)
			{
				if (motiveDeltas[i].Changed)
				{
					motiveDeltas[i].SynchronizeUserData();
				}
			}

			// Promotion
			if (!isPetCareer)
			{
				foreach (Bcon b in skillReq)
				{
					if (b.Changed)
					{
						b.SynchronizeUserData();
					}
				}
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
			if (friends.Changed)
			{
				friends.SynchronizeUserData();
			}

			if (!preuniv)
			{
				if (majors.Changed)
				{
					majors.SynchronizeUserData();
				}

				if (cclevels.Changed)
				{
					cclevels.SynchronizeUserData();
				}
			}

			// Chance Cards
			if (chanceCardsText.Changed)
			{
				chanceCardsText.SynchronizeUserData();
			}

			if (chanceChance.Changed)
			{
				chanceChance.SynchronizeUserData();
			}

			for (int i = 7; i < 9; i++)
			{
				if (chanceAGood[i].Changed)
				{
					chanceAGood[i].SynchronizeUserData();
				}

				if (chanceABad[i].Changed)
				{
					chanceABad[i].SynchronizeUserData();
				}

				if (chanceBGood[i].Changed)
				{
					chanceBGood[i].SynchronizeUserData();
				}

				if (chanceBBad[i].Changed)
				{
					chanceBBad[i].SynchronizeUserData();
				}
			}
			if (!isPetCareer)
			{
				for (int i = 0; i < 7; i++)
				{
					if (skillReq[i].Changed)
					{
						skillReq[i].SynchronizeUserData();
					}

					if (chanceASkills[i].Changed)
					{
						chanceASkills[i].SynchronizeUserData();
					}

					if (chanceBSkills[i].Changed)
					{
						chanceBSkills[i].SynchronizeUserData();
					}
				}
				for (int i = 0; i < 7; i++)
				{
					// if (i == 6) continue;
					if (chanceAGood[i].Changed)
					{
						chanceAGood[i].SynchronizeUserData();
					}

					if (chanceABad[i].Changed)
					{
						chanceABad[i].SynchronizeUserData();
					}

					if (chanceBGood[i].Changed)
					{
						chanceBGood[i].SynchronizeUserData();
					}

					if (chanceBBad[i].Changed)
					{
						chanceBBad[i].SynchronizeUserData();
					}
				}
			}
			else
			{
				if (chanceAchance.Changed)
				{
					chanceAchance.SynchronizeUserData();
				}

				if (chanceBchance.Changed)
				{
					chanceBchance.SynchronizeUserData();
				}
			}
			if (isCastaway)
			{
				if (chanceAGood[9].Changed)
				{
					chanceAGood[9].SynchronizeUserData();
				}

				if (chanceABad[9].Changed)
				{
					chanceABad[9].SynchronizeUserData();
				}

				if (chanceBGood[9].Changed)
				{
					chanceBGood[9].SynchronizeUserData();
				}

				if (chanceBBad[9].Changed)
				{
					chanceBBad[9].SynchronizeUserData();
				}
			}
		}

		private void miAddLvl_Click(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

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
				for (int i = jobTitles[l].Count; i < (newNoLevels * 4) + 1; i++)
				{
					jobTitles.Add(l, "", "");
				}

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
					items[newFemaleOffset + (i * 2) + 1].Title = items[newFemaleOffset + ((i - 1) * 2) + 1].Title;
					items[newFemaleOffset + (i * 2) + 2].Title = items[newFemaleOffset + ((i - 1) * 2) + 2].Title;
				}
				// Shift male entries up to free new level
				for (int i = newNoLevels - 1; i > currentLevel; i--)
				{
					items[(i * 2) + 1].Title = items[((i - 1) * 2) + 1].Title;
					items[(i * 2) + 2].Title = items[((i - 1) * 2) + 2].Title;
				}
				// Clear text out of new level fields
				// (new level is currentLevel + 1, index is that - 1, so just use currentLevel)
				items[(currentLevel * 2) + 1].Title = "";
				items[(currentLevel * 2) + 2].Title = "";
				items[newFemaleOffset + (currentLevel * 2) + 1].Title = "";
				items[newFemaleOffset + (currentLevel * 2) + 2].Title = "";
			}
			usitems = jobTitles[us];
			// (new level is currentLevel + 1, index is that - 1, so just use currentLevel)
			usitems[(currentLevel * 2) + 1].Title = "New Male Job Title";
			usitems[(currentLevel * 2) + 2].Title = "New Male Job Desc";
			usitems[newFemaleOffset + (currentLevel * 2) + 1].Title = "New Female Job Title";
			usitems[newFemaleOffset + (currentLevel * 2) + 2].Title = "New Female Job Desc";
			#endregion

			insertGuid(outfit, currentLevel, 0);
			insertGuid(vehicle, currentLevel, 0x0C85AE14);

			#region Hours & Wages
			insertBcon(PTO, newLevel, 15);
			if (lifeScore != null)
			{
				insertBcon(lifeScore, newLevel, 0);
			}

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
			{
				insertBcon(motiveDeltas[i], currentLevel + 1, 0);
			}
			#endregion

			if (!preuniv)
			{
				insertBcon(cclevels, currentLevel + 1, 0);
			}

			#region Promotion
			if (!isPetCareer) // people
			{
				for (int i = 0; i < skillReq.Length; i++)
				{
					insertBcon(skillReq[i], currentLevel + 1, 0);
				}
			}
			// nothing to do for Pets
			insertBcon(friends, currentLevel + 1, 0);
			#endregion

			#region Chance Cards
			insertBcon(chanceChance, currentLevel + 1, 0);
			if (!isPetCareer)
			{
				for (int i = 0; i < chanceASkills.Length; i++)
				{
					insertBcon(chanceASkills[i], currentLevel + 1, 0);
					insertBcon(chanceBSkills[i], currentLevel + 1, 0);
				}
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
				for (int k = chanceCardsText[i].Count; k < (newNoLevels * 12) + 19; k++)
				{
					chanceCardsText.Add(i, "", "");
				}

				List<StrItem> items = chanceCardsText[i];
				for (int j = newNoLevels; j > newLevel; j--)
				{
					for (int k = 7; k < 19; k++)
					{
						items[(j * 12) + k].Title = items[((j - 1) * 12) + k].Title;
					}
				}

				for (int k = 7; k < 19; k++)
				{
					items[(newLevel * 12) + k].Title = "";
				}
			}

			usitems = chanceCardsText[us];
			usitems[(newLevel * 12) + 7].Title = "Choice A";
			usitems[(newLevel * 12) + 8].Title = "Choice B";
			usitems[(newLevel * 12) + 9].Title = "Male Text";
			usitems[(newLevel * 12) + 10].Title = "Female Text";
			usitems[(newLevel * 12) + 11].Title = "Pass A Male";
			usitems[(newLevel * 12) + 12].Title = "Pass A Female";
			usitems[(newLevel * 12) + 13].Title = "Fail A Male";
			usitems[(newLevel * 12) + 14].Title = "Fail A Female";
			usitems[(newLevel * 12) + 15].Title = "Pass B Male";
			usitems[(newLevel * 12) + 16].Title = "Pass B Female";
			usitems[(newLevel * 12) + 17].Title = "Fail B Male";
			usitems[(newLevel * 12) + 18].Title = "Fail B Female";
			#endregion

			noLevelsChanged(newNoLevels);

			internalchg = false;

			stabalizecount();
		}

		private void miRemoveLvl_Click(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			internalchg = true;
			tabControl1.Enabled = menuItem6.Enabled = false;
			lbcrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			lbcrap.ForeColor = System.Drawing.Color.HotPink;
			lbcrap.Text = "You now need to close\r\nCareer Editor then restart it";
			lbcrap.Visible = true;

			ushort newNoLevels = (ushort)(noLevels - 1);

			tuning[0] = (short)newNoLevels;

			PTO.RemoveAt(currentLevel);
			lifeScore?.RemoveAt(currentLevel);

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
							items[((i - 1) * 2) + 1].Title = items[(i * 2) + 1].Title;
							items[((i - 1) * 2) + 2].Title = items[(i * 2) + 2].Title;
						}
						// Shift female entries down over removed level
						for (int i = currentLevel; i < noLevels; i++)
						{
							items[newFemaleOffset + ((i - 1) * 2) + 1].Title = items[newFemaleOffset + (i * 2) + 1].Title;
							items[newFemaleOffset + ((i - 1) * 2) + 2].Title = items[newFemaleOffset + (i * 2) + 2].Title;
						}
						// Remove unused entries, must start at last and work back
						int k = items.Count - 1;
						for (int i = k; i > k - 4; i--)
						{
							jobTitles.Remove(items[i]);
						}
					}
				}
				catch { }
			}

			outfit.RemoveAt(currentLevel - 1);
			outfit.RemoveAt(currentLevel - 1);
			vehicle.RemoveAt(currentLevel - 1);
			vehicle.RemoveAt(currentLevel - 1);

			if (!preuniv)
			{
				cclevels.RemoveAt(currentLevel);
			}

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
			{
				motiveDeltas[i].RemoveAt(currentLevel);
			}
			#endregion

			#region Promotion
			if (!isPetCareer)
			{
				for (int i = 0; i < skillReq.Length; i++)
				{
					skillReq[i].RemoveAt(currentLevel);
				}
			}
			// nothing to do for Pets
			friends.RemoveAt(currentLevel);
			#endregion

			#region Chance Cards

			chanceChance.RemoveAt(currentLevel);
			if (!isPetCareer)
			{
				for (int i = 0; i < chanceASkills.Length; i++)
				{
					chanceASkills[i].RemoveAt(currentLevel);
					chanceBSkills[i].RemoveAt(currentLevel);
				}
			}

			if (!isPetCareer)
			{
				for (int i = 0; i < 7; i++)
				{
					chanceAGood[i].RemoveAt(currentLevel);
					chanceABad[i].RemoveAt(currentLevel);
					chanceBGood[i].RemoveAt(currentLevel);
					chanceBBad[i].RemoveAt(currentLevel);
				}
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
						{
							for (int k = 7; k < 19; k++)
							{
								items[(j * 12) + k].Title = items[((j + 1) * 12) + k].Title;
							}
						}

						// Remove unused entries, must start at last and work back
						for (int k = 18; k > 6; k--)
						{
							chanceCardsText.Remove(items[(noLevels * 12) + k]);
						}
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
			if (noLevels > 10)
			{
				return; // leave extras
			}

			if (friends.Count < 11)
			{
				friends.Add(0);
			}

			if (friends.Count > 11)
			{
				friends.RemoveAt(11);
			}

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
			{
				PTO.Add(0);
			}

			if (PTO.Count > 11)
			{
				PTO.RemoveAt(11);
			}

			if (lifeScore != null)
			{
				if (lifeScore.Count < 11)
				{
					lifeScore.Add(0);
				}

				if (lifeScore.Count > 11)
				{
					lifeScore.RemoveAt(11);
				}
			}
			if (hoursWorked.Count > 11)
			{
				hoursWorked.RemoveAt(11);
			}

			if (hoursWorked.Count < 11)
			{
				hoursWorked.Add(0);
			}

			if (startHour.Count > 11)
			{
				startHour.RemoveAt(11);
			}

			if (startHour.Count < 11)
			{
				startHour.Add(0);
			}

			if (daysWorked.Count < 11)
			{
				daysWorked.Add(0);
			}

			if (daysWorked.Count > 11)
			{
				daysWorked.RemoveAt(11);
			}

			if (!preuniv)
			{
				if (cclevels.Count < 11)
				{
					cclevels.Add(0);
				}

				if (cclevels.Count > 11)
				{
					cclevels.RemoveAt(11);
				}
			}

			if (!isPetCareer)
			{
				if (wages.Count < 11)
				{
					wages.Add(0);
				}

				if (wages.Count > 11)
				{
					wages.RemoveAt(11);
				}

				for (int i = 0; i < chanceASkills.Length; i++)
				{
					if (chanceASkills[i].Count > 11)
					{
						chanceASkills[i].RemoveAt(11);
					}

					if (chanceASkills[i].Count < 11)
					{
						chanceASkills[i].Add(0);
					}

					if (chanceBSkills[i].Count > 11)
					{
						chanceBSkills[i].RemoveAt(11);
					}

					if (chanceBSkills[i].Count < 11)
					{
						chanceBSkills[i].Add(0);
					}
				}
				for (int i = 0; i < 7; i++)
				{
					if (chanceAGood[i].Count > 11)
					{
						chanceAGood[i].RemoveAt(11);
					}

					if (chanceAGood[i].Count < 11)
					{
						chanceAGood[i].Add(0);
					}

					if (chanceABad[i].Count > 11)
					{
						chanceABad[i].RemoveAt(11);
					}

					if (chanceABad[i].Count < 11)
					{
						chanceABad[i].Add(0);
					}

					if (chanceBGood[i].Count > 11)
					{
						chanceBGood[i].RemoveAt(11);
					}

					if (chanceBGood[i].Count < 11)
					{
						chanceBGood[i].Add(0);
					}

					if (chanceBBad[i].Count > 11)
					{
						chanceBBad[i].RemoveAt(11);
					}

					if (chanceBBad[i].Count < 11)
					{
						chanceBBad[i].Add(0);
					}
				}
				for (int i = 0; i < skillReq.Length; i++)
				{
					if (skillReq[i].Count > 11)
					{
						skillReq[i].RemoveAt(11);
					}

					if (skillReq[i].Count < 11)
					{
						skillReq[i].Add(0);
					}
				}
			}
			else
			{
				if (wagesDog.Count < 11)
				{
					wagesDog.Add(0);
				}

				if (wagesDog.Count > 11)
				{
					wagesDog.RemoveAt(11);
				}

				if (wagesCat.Count < 11)
				{
					wagesCat.Add(0);
				}

				if (wagesCat.Count > 11)
				{
					wagesCat.RemoveAt(11);
				}
			}
			for (int i = 0; i < SUNSHINE; i++)
			{
				if (motiveDeltas[i].Count < 11)
				{
					motiveDeltas[i].Add(0);
				}

				if (motiveDeltas[i].Count > 11)
				{
					motiveDeltas[i].RemoveAt(11);
				}
			}
			if (motiveDeltas[SUNSHINE].Count < 12)
			{
				motiveDeltas[SUNSHINE].Add(0);
			}

			if (motiveDeltas[SUNSHINE].Count > 12)
			{
				motiveDeltas[SUNSHINE].RemoveAt(12);
			}

			if (chanceChance.Count > 11)
			{
				chanceChance.RemoveAt(11);
			}

			if (chanceChance.Count < 11)
			{
				chanceChance.Add(0);
			}

			for (int i = 7; i < chanceAGood.Length; i++)
			{
				if (chanceAGood[i].Count > 11)
				{
					chanceAGood[i].RemoveAt(11);
				}

				if (chanceAGood[i].Count < 11)
				{
					chanceAGood[i].Add(0);
				}

				if (chanceABad[i].Count > 11)
				{
					chanceABad[i].RemoveAt(11);
				}

				if (chanceABad[i].Count < 11)
				{
					chanceABad[i].Add(0);
				}

				if (chanceBGood[i].Count > 11)
				{
					chanceBGood[i].RemoveAt(11);
				}

				if (chanceBGood[i].Count < 11)
				{
					chanceBGood[i].Add(0);
				}

				if (chanceBBad[i].Count > 11)
				{
					chanceBBad[i].RemoveAt(11);
				}

				if (chanceBBad[i].Count < 11)
				{
					chanceBBad[i].Add(0);
				}
			}
		}

		private void miEnglishOnly_Click(object sender, EventArgs e)
		{
			englishOnly = !englishOnly;
			// System.InvalidCastException: Unable to cast object of type 'System.Windows.Forms.ToolStripMenuItem' to type 'System.Windows.Forms.MenuItem'.
			((ToolStripMenuItem)sender).Checked = englishOnly;
			if (englishOnly)
			{
				Language.SelectedIndex = 0;
			}

			Language.Enabled = !englishOnly;
		}

		private void CareerTitle_TextChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			string text = ((TextBox)sender).Text;
			if (catalogueDesc[currentLanguage].Count == 0)
			{
				catalogueDesc[currentLanguage].Add(new StrItem(catalogueDesc));
			}

			catalogueDesc[currentLanguage][0].Title = text;
		}
		private void Language_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			internalchg = true;

			int index = ((ComboBox)sender).SelectedIndex;
			currentLanguage = (byte)(index + 1);
			JobDetailList.Items.Clear();
			fillJobDetails();

			CareerTitle.Text = (catalogueDesc[currentLanguage].Count == 0) ? "" : catalogueDesc[currentLanguage, 0].Title;
			internalchg = false;

			ushort newLevel = currentLevel;
			currentLevel = 0;
			levelChanged(newLevel);
		}

		private void JobDetailList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (levelChanging)
			{
				return;
			}

			ListView.SelectedIndexCollection indices = ((ListView)sender).SelectedIndices;
			if ((indices.Count > 0) && (indices[0] < noLevels))
			{
				levelChanged((ushort)(indices[0] + 1));
			}
		}
		private void JobDetailsCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			jdpMale.DescValue = jdpFemale.DescValue;
		}
		private void jdpMale_TitleValueChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			string text = jdpMale.TitleValue;
			jobTitles[currentLanguage][(currentLevel * 2) - 1].Title = text;
		}
		private void jdpMale_DescValueChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			string text = jdpMale.DescValue;
			jobTitles[currentLanguage][currentLevel * 2].Title = text;
		}
		private void jdpFemale_TitleValueChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			string text = jdpFemale.TitleValue;
			ListViewItem item = JobDetailList.Items[currentLevel - 1];
			item.SubItems[1].Text = text;
			jobTitles[currentLanguage][(currentLevel * 2) - 1 + femaleOffset].Title = text;
		}
		private void jdpFemale_DescValueChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			string text = jdpFemale.DescValue;
			ListViewItem item = JobDetailList.Items[currentLevel - 1];
			item.SubItems[2].Text = text;
			jobTitles[currentLanguage][(currentLevel * 2) + femaleOffset].Title = text;
		}
		private void gcOutfit_GUIDChooserValueChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			ListViewItem item = JobDetailList.Items[currentLevel - 1];
			item.SubItems[3].Text = isCastaway
				? StringFromGUID(gcOutfit.Value, CSoutfitGUID, CSoutfitName)
				: StringFromGUID(gcOutfit.Value, outfitGUID, outfitName);

			outfit[currentLevel * 2] = (short)(gcOutfit.Value & 0xffff);
			outfit[(currentLevel * 2) + 1] = (short)((gcOutfit.Value >> 16) & 0xffff);
		}
		private void gcVehicle_GUIDChooserValueChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			ListViewItem item = JobDetailList.Items[currentLevel - 1];
			item.SubItems[4].Text = StringFromGUID(gcVehicle.Value, vehicleGUID, vehicleName);

			vehicle[currentLevel * 2] = (short)(gcVehicle.Value & 0xffff);
			vehicle[(currentLevel * 2) + 1] = (short)((gcVehicle.Value >> 16) & 0xffff);
		}

		private void HoursWagesList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (levelChanging)
			{
				return;
			}

			ListView.SelectedIndexCollection indices = ((ListView)sender).SelectedIndices;
			if ((indices.Count > 0) && (indices[0] < noLevels))
			{
				levelChanged((ushort)(indices[0] + 1));
			}
		}
		private void lnudWork_ValueChanged(object sender, EventArgs e)
		{
			if (levelChanging || internalchg)
			{
				return;
			}

			if (isCastaway)
			{
				resinc[currentLevel] = (short)lnudWages.Value;
			}

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
		private void lnudWork_KeyUp(object sender, KeyEventArgs e)
		{
			lnudWork_ValueChanged(sender, new EventArgs());
		}
		private void Workday_CheckedChanged(object sender, EventArgs e)
		{
			if (levelChanging || internalchg)
			{
				return;
			}

			List<CheckBox> lcb = new List<CheckBox>(new CheckBox[] {
				WorkMonday, WorkTuesday, WorkWednesday, WorkThursday, WorkFriday, WorkSaturday, WorkSunday,
			});

			int index = lcb.IndexOf((CheckBox)sender);
			if (index < 0 || index > 6)
			{
				return; // crash!
			}

			Boolset dw = new Boolset((byte)daysWorked[currentLevel]);
			dw[index] = ((CheckBox)sender).Checked;
			daysWorked[currentLevel] = (byte)dw;

			ListViewItem item = HoursWagesList.Items[currentLevel - 1];
			item.SubItems[index + 7].Text = "" + ((CheckBox)sender).Checked;
		}
		private void numPTO_ValueChanged(object sender, EventArgs e)
		{
			if (levelChanging || internalchg)
			{
				return;
			}

			PTO[currentLevel] = (short)numPTO.Value;
		}
		private void numLscore_ValueChanged(object sender, EventArgs e)
		{
			if (levelChanging || internalchg)
			{
				return;
			}

			lifeScore[currentLevel] = (short)numLscore.Value;
		}
		private void nudMotive_ValueChanged(object sender, EventArgs e)
		{
			if (levelChanging || internalchg)
			{
				return;
			}

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
		private void nudMotive_KeyUp(object sender, KeyEventArgs e)
		{
			nudMotive_ValueChanged(sender, new EventArgs());
		}

		private void PromoList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (levelChanging)
			{
				return;
			}

			ListView.SelectedIndexCollection indices = ((ListView)sender).SelectedIndices;
			if ((indices.Count > 0) && (indices[0] < noLevels))
			{
				levelChanged((ushort)(indices[0] + 1));
			}
		}
		private void Promo_ValueChanged(object sender, EventArgs e)
		{
			if (levelChanging || internalchg || sender == null)
			{
				return;
			}

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
			if (i == -1)
			{
				return; // crash!
			}

			ListViewItem item = PromoList.Items[currentLevel - 1];
			short val = (short)((NumericUpDown)sender).Value;
			item.SubItems[i + 1].Text = "" + val;

			if (i < skillReq.Length)
			{
				skillReq[i][currentLevel] = (short)(val * 100);
			}
			else
			{
				switch (i - skillReq.Length)
				{
					case 0:
						friends[currentLevel] = val;
						break;
				}
			}
		}
		private void Promo_KeyUp(object sender, KeyEventArgs e)
		{
			Promo_ValueChanged(sender, e);
		}
		private void cbTrick_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (levelChanging || internalchg)
			{
				return;
			}

			ListViewItem item = PromoList.Items[currentLevel - 1];
			item.SubItems[9].Text = (string)((ComboBox)sender).SelectedItem;

			List<short[]> lTrick = new List<short[]>();
			for (int i = 0; i < trick.Count / 2; i++)
			{
				lTrick.Add(new short[] { trick[i * 2], trick[(i * 2) + 1] });
			}

			short[] result = new short[] { (short)((ComboBox)sender).SelectedIndex, (short)currentLevel };

			int insPtr = 0;
			while (insPtr < lTrick.Count && currentLevel > lTrick[insPtr][1])
			{
				insPtr++;
			}

			if (insPtr < lTrick.Count)
			{
				if (currentLevel == lTrick[insPtr][1])
				{
					lTrick[insPtr] = result;
				}
				else
				{
					lTrick.Insert(insPtr, result);
				}
			}
			else
			{
				lTrick.Add(result);
			}

			trick.Clear();
			foreach (short[] pair in lTrick)
			{
				trick.Add(pair[0]);
				trick.Add(pair[1]);
			}
		}

		private void lnudChanceCurrentLevel_ValueChanged(object sender, EventArgs e)
		{
			if (levelChanging || internalchg)
			{
				return;
			}

			levelChanged((ushort)lnudChanceCurrentLevel.Value);
		}
		private void ChanceCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
					lbrewguid.Text = pjse.GUIDIndex.TheGUIDIndex[Helper.HexStringToUInt(tbox.Text)];
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
			if (boobr >= 32768)
			{
				boobr -= 32768;
			}

			if (boobr >= 16384)
			{
				boobr -= 16384;
			}

			if (boobr >= 8192)
			{
				boobr -= 8192;
			}

			if (boobr >= 4096)
			{
				boobr -= 4096;
			}

			if (boobr >= 2048)
			{
				boobr -= 2048;
			}

			if (boobr >= 1024)
			{
				boobr -= 1024;
				cbrphyco.Checked = true;
			}
			else
			{
				cbrphyco.Checked = false;
			}

			if (boobr >= 512)
			{
				boobr -= 512;
				cbrpolit.Checked = true;
			}
			else
			{
				cbrpolit.Checked = false;
			}

			if (boobr >= 256)
			{
				boobr -= 256;
				cbrphysi.Checked = true;
			}
			else
			{
				cbrphysi.Checked = false;
			}

			if (boobr >= 128)
			{
				boobr -= 128;
				cbrphilo.Checked = true;
			}
			else
			{
				cbrphilo.Checked = false;
			}

			if (boobr >= 64)
			{
				boobr -= 64;
				cbrmaths.Checked = true;
			}
			else
			{
				cbrmaths.Checked = false;
			}

			if (boobr >= 32)
			{
				boobr -= 32;
				cbrliter.Checked = true;
			}
			else
			{
				cbrliter.Checked = false;
			}

			if (boobr >= 16)
			{
				boobr -= 16;
				cbrhisto.Checked = true;
			}
			else
			{
				cbrhisto.Checked = false;
			}

			if (boobr >= 8)
			{
				boobr -= 8;
				cbrecon.Checked = true;
			}
			else
			{
				cbrecon.Checked = false;
			}

			if (boobr >= 4)
			{
				boobr -= 4;
				cbrdrama.Checked = true;
			}
			else
			{
				cbrdrama.Checked = false;
			}

			if (boobr >= 2)
			{
				boobr -= 2;
				cbrbiol.Checked = true;
			}
			else
			{
				cbrbiol.Checked = false;
			}

			cbrArt.Checked = boobr >= 1;

			int booba = getBcon(0x1056)[2];
			if (booba >= 32768)
			{
				booba -= 32768;
			}

			if (booba >= 16384)
			{
				booba -= 16384;
			}

			if (booba >= 8192)
			{
				booba -= 8192;
			}

			if (booba >= 4096)
			{
				booba -= 4096;
			}

			if (booba >= 2048)
			{
				booba -= 2048;
			}

			if (booba >= 1024)
			{
				booba -= 1024;
				cbaphyco.Checked = true;
			}
			else
			{
				cbaphyco.Checked = false;
			}

			if (booba >= 512)
			{
				booba -= 512;
				cbapolit.Checked = true;
			}
			else
			{
				cbapolit.Checked = false;
			}

			if (booba >= 256)
			{
				booba -= 256;
				cbaphysi.Checked = true;
			}
			else
			{
				cbaphysi.Checked = false;
			}

			if (booba >= 128)
			{
				booba -= 128;
				cbrahilo.Checked = true;
			}
			else
			{
				cbrahilo.Checked = false;
			}

			if (booba >= 64)
			{
				booba -= 64;
				cbamaths.Checked = true;
			}
			else
			{
				cbamaths.Checked = false;
			}

			if (booba >= 32)
			{
				booba -= 32;
				cbaliter.Checked = true;
			}
			else
			{
				cbaliter.Checked = false;
			}

			if (booba >= 16)
			{
				booba -= 16;
				cbahisto.Checked = true;
			}
			else
			{
				cbahisto.Checked = false;
			}

			if (booba >= 8)
			{
				booba -= 8;
				cbaecon.Checked = true;
			}
			else
			{
				cbaecon.Checked = false;
			}

			if (booba >= 4)
			{
				booba -= 4;
				cbadrama.Checked = true;
			}
			else
			{
				cbadrama.Checked = false;
			}

			if (booba >= 2)
			{
				booba -= 2;
				cbabiol.Checked = true;
			}
			else
			{
				cbabiol.Checked = false;
			}

			cbaArt.Checked = booba >= 1;
		}

		private void btmajApply_Click(object sender, EventArgs e)
		{
			majors[1] = majors[2] = 0;
			if (cbrArt.Checked)
			{
				majors[1] = 1;
			}

			if (cbrbiol.Checked)
			{
				majors[1] += 2;
			}

			if (cbrdrama.Checked)
			{
				majors[1] += 4;
			}

			if (cbrecon.Checked)
			{
				majors[1] += 8;
			}

			if (cbrhisto.Checked)
			{
				majors[1] += 16;
			}

			if (cbrliter.Checked)
			{
				majors[1] += 32;
			}

			if (cbrmaths.Checked)
			{
				majors[1] += 64;
			}

			if (cbrhisto.Checked)
			{
				majors[1] += 128;
			}

			if (cbrphysi.Checked)
			{
				majors[1] += 256;
			}

			if (cbrpolit.Checked)
			{
				majors[1] += 512;
			}

			if (cbrphyco.Checked)
			{
				majors[1] += 1024;
			}

			if (cbaArt.Checked)
			{
				majors[2] = 1;
			}

			if (cbabiol.Checked)
			{
				majors[2] += 2;
			}

			if (cbadrama.Checked)
			{
				majors[2] += 4;
			}

			if (cbaecon.Checked)
			{
				majors[2] += 8;
			}

			if (cbahisto.Checked)
			{
				majors[2] += 16;
			}

			if (cbaliter.Checked)
			{
				majors[2] += 32;
			}

			if (cbamaths.Checked)
			{
				majors[2] += 64;
			}

			if (cbrahilo.Checked)
			{
				majors[2] += 128;
			}

			if (cbaphysi.Checked)
			{
				majors[2] += 256;
			}

			if (cbapolit.Checked)
			{
				majors[2] += 512;
			}

			if (cbaphyco.Checked)
			{
				majors[2] += 1024;
			}

			majors.SynchronizeUserData();
		}

		private void btUgrade_Click(object sender, EventArgs e)
		{
			bool ok = false;
			if (getBcon(0x1056) == null)
			{
				ok = makeBcon(0x1056, 2, "Tuning - Flags");
			}

			if (getBcon(0x1057) == null)
			{
				ok = makeBcon(0x1057, 10, "Tuning - Chance Card Levels");
			}

			if (getBcon(0x1058) == null)
			{
				ok = makeBcon(0x1058, 1, "Top Memory");
			}

			if (getBcon(0x1059) == null && !isPetCareer)
			{
				ok = makeBcon(0x1059, 11, "Motive Deltas - Plantsim Sunshine");
			}

			if (ok)
			{
				btUgrade.Visible = false;
				tabControl1.Enabled = menuItem6.Enabled = false;
				lbcrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
				lbcrap.ForeColor = System.Drawing.Color.HotPink;
				lbcrap.Text = "You now need to close\r\nCareer Editor then restart it";
				lbcrap.Visible = true;
			}
		}

		private void cbischance_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			cclevels[currentLevel] = cbischance.Checked ? (BconItem)1 : (BconItem)0;
		}

		private void lnudChancePercent_ValueChanged(object sender, EventArgs e)
		{
			cpChoiceA.HaveSkills = cpChoiceB.HaveSkills = lnudChancePercent.Value < 0 && !isPetCareer;
		}

		private void lnudFoods_ValueChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			foodinc[currentLevel] = (short)lnudFoods.Value;
			lnudWork_ValueChanged(sender, e);
		}
	}
}
