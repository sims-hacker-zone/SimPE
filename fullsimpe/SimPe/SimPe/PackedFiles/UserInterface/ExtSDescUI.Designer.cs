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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces;
using SimPe.PackedFiles.Wrapper.Supporting;
using SimPe.Data;
using Ambertation.Windows.Forms;
using SimPe.Windows.Forms;

namespace SimPe.PackedFiles.UserInterface
{
    partial class ExtSDesc
    {

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
        }

        #region Windows Form Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtSDesc));
            this.pnPetInt = new System.Windows.Forms.Panel();
            this.pbPetEating = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbPetOutside = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbPetPlaying = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbPetSpooky = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbPetSleep = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbPetToy = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbPetWeather = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbPetPets = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbPetAnimals = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.toolBar1 = new System.Windows.Forms.ToolStrip();
            this.biId = new System.Windows.Forms.ToolStripButton();
            this.biCareer = new System.Windows.Forms.ToolStripButton();
            this.biRel = new System.Windows.Forms.ToolStripButton();
            this.biInt = new System.Windows.Forms.ToolStripButton();
            this.biChar = new System.Windows.Forms.ToolStripButton();
            this.biSkill = new System.Windows.Forms.ToolStripButton();
            this.biMisc = new System.Windows.Forms.ToolStripButton();
            this.biEP1 = new System.Windows.Forms.ToolStripButton();
            this.biEP2 = new System.Windows.Forms.ToolStripButton();
            this.biEP3 = new System.Windows.Forms.ToolStripButton();
            this.biEP6 = new System.Windows.Forms.ToolStripButton();
            this.biEP7 = new System.Windows.Forms.ToolStripButton();
            this.biEP9 = new System.Windows.Forms.ToolStripButton();
            this.biMore = new System.Windows.Forms.ToolStripButton();
            this.biMax = new System.Windows.Forms.ToolStripButton();
            this.biLezby = new System.Windows.Forms.ToolStripButton();
            this.mbiMax = new System.Windows.Forms.ToolStripMenuItem();
            this.pnId = new System.Windows.Forms.Panel();
            this.btOriGuid = new System.Windows.Forms.Button();
            this.lbHousname = new System.Windows.Forms.Label();
            this.lbSplitChar = new System.Windows.Forms.Label();
            this.lbFixedRes = new System.Windows.Forms.Label();
            this.tbsinstance = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.lbsubspec = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbSpecies = new Ambertation.Windows.Forms.EnumComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbsimdescfamname = new System.Windows.Forms.TextBox();
            this.tbfaminst = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.rbmale = new System.Windows.Forms.RadioButton();
            this.rbfemale = new System.Windows.Forms.RadioButton();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.tbsimdescname = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbsim = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbage = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.cblifesection = new System.Windows.Forms.ComboBox();
            this.pnSkill = new System.Windows.Forms.Panel();
            this.pbBody = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbRomance = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbFat = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbClean = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbCreative = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbCharisma = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbMech = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbLogic = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbCooking = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pnChar = new System.Windows.Forms.Panel();
            this.pnPetChar = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.ptPigpen = new SimPe.PackedFiles.Wrapper.PetTraitSelect();
            this.ptAggres = new SimPe.PackedFiles.Wrapper.PetTraitSelect();
            this.ptIndep = new SimPe.PackedFiles.Wrapper.PetTraitSelect();
            this.ptHyper = new SimPe.PackedFiles.Wrapper.PetTraitSelect();
            this.ptGifted = new SimPe.PackedFiles.Wrapper.PetTraitSelect();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pnHumanChar = new System.Windows.Forms.Panel();
            this.pbNeat = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbOutgoing = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbActive = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbPlayful = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbGNice = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbNice = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbGPlayful = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbGNeat = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbGActive = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbGOutgoing = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbMan = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbWoman = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.cbzodiac = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label69 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
            this.mbiLink = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRand = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miOpenChar = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenWf = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenMem = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenBadge = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenDNA = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenSCOR = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenFamily = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenCloth = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miMore = new System.Windows.Forms.ToolStripMenuItem();
            this.miRelink = new System.Windows.Forms.ToolStripMenuItem();
            this.miRel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAddRelation = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemRelation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mbiMaxThisRel = new System.Windows.Forms.ToolStripMenuItem();
            this.mbiMaxKnownRel = new System.Windows.Forms.ToolStripMenuItem();
            this.pnCareer = new System.Windows.Forms.Panel();
            this.lbRetcareer = new System.Windows.Forms.Label();
            this.lpRetirement = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.cbRetirement = new System.Windows.Forms.ComboBox();
            this.tbpension = new System.Windows.Forms.TextBox();
            this.lbpension = new System.Windows.Forms.Label();
            this.lbaccholidays = new System.Windows.Forms.Label();
            this.tbaccholidays = new System.Windows.Forms.TextBox();
            this.pbAspBliz = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.label60 = new System.Windows.Forms.Label();
            this.cbaspiration = new System.Windows.Forms.ComboBox();
            this.pbAspCur = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.label46 = new System.Windows.Forms.Label();
            this.tblifelinescore = new System.Windows.Forms.TextBox();
            this.pbCareerPerformance = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbCareerLevel = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.label78 = new System.Windows.Forms.Label();
            this.tbschooltype = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.cbgrade = new System.Windows.Forms.ComboBox();
            this.cbschooltype = new System.Windows.Forms.ComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.cbcareer = new System.Windows.Forms.ComboBox();
            this.tbcareervalue = new System.Windows.Forms.TextBox();
            this.pnInt = new System.Windows.Forms.Panel();
            this.pnSimInt = new System.Windows.Forms.Panel();
            this.pbSciFi = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbTravel = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbToys = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbEnvironment = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbSchool = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbParanormal = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbAnimals = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbEntertainment = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbWeather = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbCulture = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbWork = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbMoney = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbPolitics = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbCrime = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbFood = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbSports = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbHealth = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbFashion = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pnRel = new System.Windows.Forms.Panel();
            this.lv = new SimPe.PackedFiles.Wrapper.SimRelationPoolControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.srcTb = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.dstTb = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.pnMisc = new System.Windows.Forms.Panel();
            this.tbMotiveDec = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.lbdecScratc = new System.Windows.Forms.Label();
            this.tbdecScratc = new System.Windows.Forms.TextBox();
            this.lbdecAmor = new System.Windows.Forms.Label();
            this.tbdecAmor = new System.Windows.Forms.TextBox();
            this.lbdecFun = new System.Windows.Forms.Label();
            this.tbdecFun = new System.Windows.Forms.TextBox();
            this.lbdecShop = new System.Windows.Forms.Label();
            this.tbdecShop = new System.Windows.Forms.TextBox();
            this.lbdecSocial = new System.Windows.Forms.Label();
            this.tbdecSocial = new System.Windows.Forms.TextBox();
            this.lbdecHygiene = new System.Windows.Forms.Label();
            this.tbdecHygiene = new System.Windows.Forms.TextBox();
            this.tbdecEnergy = new System.Windows.Forms.TextBox();
            this.lbdecEnergy = new System.Windows.Forms.Label();
            this.tbdecBladder = new System.Windows.Forms.TextBox();
            this.lbdecBladder = new System.Windows.Forms.Label();
            this.tbdecComfort = new System.Windows.Forms.TextBox();
            this.lbdecComfort = new System.Windows.Forms.Label();
            this.tbdecHunger = new System.Windows.Forms.TextBox();
            this.lbdecHunger = new System.Windows.Forms.Label();
            this.tbpersonflags = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.cbpfwitch = new System.Windows.Forms.CheckBox();
            this.cbpfroomy = new System.Windows.Forms.CheckBox();
            this.cbpfBigf = new System.Windows.Forms.CheckBox();
            this.cbpfPlant = new System.Windows.Forms.CheckBox();
            this.cbpfrunaw = new System.Windows.Forms.CheckBox();
            this.cbpflyact = new System.Windows.Forms.CheckBox();
            this.cbpflycar = new System.Windows.Forms.CheckBox();
            this.cbpfwants = new System.Windows.Forms.CheckBox();
            this.cbpfvsmoke = new System.Windows.Forms.CheckBox();
            this.cbpfvamp = new System.Windows.Forms.CheckBox();
            this.cbpfperma = new System.Windows.Forms.CheckBox();
            this.cbpfZomb = new System.Windows.Forms.CheckBox();
            this.bTaskBox3 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.label3 = new System.Windows.Forms.Label();
            this.tbstatmot = new System.Windows.Forms.TextBox();
            this.label96 = new System.Windows.Forms.Label();
            this.tbunlinked = new System.Windows.Forms.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.tbagedur = new System.Windows.Forms.TextBox();
            this.tbprevdays = new System.Windows.Forms.TextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.tbvoice = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.tbnpc = new System.Windows.Forms.TextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.tbautonomy = new System.Windows.Forms.TextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.bTaskBox2 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.cbfit = new System.Windows.Forms.CheckBox();
            this.cbpreginv = new System.Windows.Forms.CheckBox();
            this.cbpreghalf = new System.Windows.Forms.CheckBox();
            this.cbpregfull = new System.Windows.Forms.CheckBox();
            this.cbfat = new System.Windows.Forms.CheckBox();
            this.bTaskBox1 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.cbisghost = new System.Windows.Forms.CheckBox();
            this.cbignoretraversal = new System.Windows.Forms.CheckBox();
            this.cbpasspeople = new System.Windows.Forms.CheckBox();
            this.cbpasswalls = new System.Windows.Forms.CheckBox();
            this.cbpassobject = new System.Windows.Forms.CheckBox();
            this.pnEP1 = new System.Windows.Forms.Panel();
            this.tbSeminfo = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.cbexpelled = new System.Windows.Forms.CheckBox();
            this.cbdroped = new System.Windows.Forms.CheckBox();
            this.cbatclass = new System.Windows.Forms.CheckBox();
            this.cbgraduate = new System.Windows.Forms.CheckBox();
            this.cbprobation = new System.Windows.Forms.CheckBox();
            this.cbGoodsem = new System.Windows.Forms.CheckBox();
            this.cbSenior = new System.Windows.Forms.CheckBox();
            this.cbJunior = new System.Windows.Forms.CheckBox();
            this.cbSopho = new System.Windows.Forms.CheckBox();
            this.cbfreshman = new System.Windows.Forms.CheckBox();
            this.pbLastGrade = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbUniTime = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.pbEffort = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.tbinfluence = new System.Windows.Forms.TextBox();
            this.tbsemester = new System.Windows.Forms.TextBox();
            this.label103 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.cboncampus = new System.Windows.Forms.CheckBox();
            this.cbmajor = new System.Windows.Forms.ComboBox();
            this.label98 = new System.Windows.Forms.Label();
            this.tbmajor = new System.Windows.Forms.TextBox();
            this.pnEP7 = new System.Windows.Forms.Panel();
            this.pbhbenth = new Ambertation.Windows.Forms.LabeledProgressBar();
            this.label41 = new System.Windows.Forms.Label();
            this.cbaspiration2 = new System.Windows.Forms.ComboBox();
            this.cbHobbyPre = new Ambertation.Windows.Forms.EnumComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.bTaskBox4 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.label33 = new System.Windows.Forms.Label();
            this.tb7social = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tb7fun = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.tb7hygiene = new System.Windows.Forms.TextBox();
            this.tb7energy = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.tb7bladder = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tb7comfort = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.tb7hunger = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.tbBugColl = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tbUnlocksUsed = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tbUnlockPts = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbLtAsp = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.cbHobbyEnth = new System.Windows.Forms.ComboBox();
            this.pnEP2 = new System.Windows.Forms.Panel();
            this.tbNTLove = new System.Windows.Forms.TextBox();
            this.tbNTPerfume = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbTurnOff = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTurnOn = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTraits = new System.Windows.Forms.CheckedListBox();
            this.pbtraits = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnEP3 = new System.Windows.Forms.Panel();
            this.llep3openinfo = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.sblb = new SimPe.PackedFiles.Wrapper.SimBusinessList();
            this.tbEp3Salery = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbEp3Asgn = new Ambertation.Windows.Forms.EnumComboBox();
            this.tbEp3Flag = new System.Windows.Forms.TextBox();
            this.tbEp3Lot = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnVoyage = new System.Windows.Forms.Panel();
            this.lvCollectibles = new System.Windows.Forms.ListView();
            this.ilCollectibles = new System.Windows.Forms.ImageList(this.components);
            this.tbhdaysleft = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.labelcol = new System.Windows.Forms.Label();
            this.pnEP9 = new System.Windows.Forms.Panel();
            this.lbfaithinfo = new System.Windows.Forms.Label();
            this.tbfemdik = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.lbFemcolour = new System.Windows.Forms.Label();
            this.cbfembaldy = new System.Windows.Forms.CheckBox();
            this.cbfemsmall = new System.Windows.Forms.CheckBox();
            this.cbfembig = new System.Windows.Forms.CheckBox();
            this.cbfemcirc = new System.Windows.Forms.CheckBox();
            this.cbFemColour = new System.Windows.Forms.ComboBox();
            this.Various = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.lbVBFriend = new System.Windows.Forms.Label();
            this.cbVBFriend = new System.Windows.Forms.ComboBox();
            this.cbisslave = new System.Windows.Forms.CheckBox();
            this.cbstaynude = new System.Windows.Forms.CheckBox();
            this.lbReligion = new System.Windows.Forms.Label();
            this.lbpostTitle = new System.Windows.Forms.Label();
            this.cbpostTitle = new System.Windows.Forms.ComboBox();
            this.cbSuburbs = new System.Windows.Forms.ComboBox();
            this.cbFaiths = new System.Windows.Forms.ComboBox();
            this.lbalcsub = new System.Windows.Forms.Label();
            this.cbhospital = new System.Windows.Forms.CheckBox();
            this.pbicon = new System.Windows.Forms.PictureBox();
            this.cbonpill = new System.Windows.Forms.CheckBox();
            this.cbmarker = new System.Windows.Forms.CheckBox();
            this.lbBodee = new System.Windows.Forms.Label();
            this.cbBody = new System.Windows.Forms.ComboBox();
            this.Nipples = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.labelnipple = new System.Windows.Forms.Label();
            this.cbnipsit = new System.Windows.Forms.CheckBox();
            this.cbnipssi = new System.Windows.Forms.CheckBox();
            this.cbnipsma = new System.Windows.Forms.CheckBox();
            this.cbnipswi = new System.Windows.Forms.CheckBox();
            this.cbnipsfo = new System.Windows.Forms.CheckBox();
            this.cbnipsgy = new System.Windows.Forms.CheckBox();
            this.cbnipsun = new System.Windows.Forms.CheckBox();
            this.cbnipspy = new System.Windows.Forms.CheckBox();
            this.cbnipssw = new System.Windows.Forms.CheckBox();
            this.cbnipsca = new System.Windows.Forms.CheckBox();
            this.cbnipsna = new System.Windows.Forms.CheckBox();
            this.Pubes = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.pnPenis = new System.Windows.Forms.Panel();
            this.cbdickless = new System.Windows.Forms.CheckBox();
            this.labelpenis = new System.Windows.Forms.Label();
            this.lbBallsize = new System.Windows.Forms.Label();
            this.cbDiklength = new System.Windows.Forms.ComboBox();
            this.lbDikgirth = new System.Windows.Forms.Label();
            this.cbDikgirth = new System.Windows.Forms.ComboBox();
            this.lbDikcolour = new System.Windows.Forms.Label();
            this.cbBallsize = new System.Windows.Forms.ComboBox();
            this.lbDikstate = new System.Windows.Forms.Label();
            this.cbDikstate = new System.Windows.Forms.ComboBox();
            this.lbDiklength = new System.Windows.Forms.Label();
            this.cbDikcolour = new System.Windows.Forms.ComboBox();
            this.pnMuffy = new System.Windows.Forms.Panel();
            this.btpubedic = new System.Windows.Forms.Button();
            this.labelpubes = new System.Windows.Forms.Label();
            this.cbpubesh = new System.Windows.Forms.CheckBox();
            this.cbpubetr = new System.Windows.Forms.CheckBox();
            this.cbpubetf = new System.Windows.Forms.CheckBox();
            this.cbpubebk = new System.Windows.Forms.CheckBox();
            this.cbpubebn = new System.Windows.Forms.CheckBox();
            this.cbpubebd = new System.Windows.Forms.CheckBox();
            this.cbpuberd = new System.Windows.Forms.CheckBox();
            this.labelgenital = new System.Windows.Forms.Label();
            this.cbpubeal = new System.Windows.Forms.CheckBox();
            this.cbpubegy = new System.Windows.Forms.CheckBox();
            this.cbpubeun = new System.Windows.Forms.CheckBox();
            this.cbpubepy = new System.Windows.Forms.CheckBox();
            this.cbpubesw = new System.Windows.Forms.CheckBox();
            this.cbpubeca = new System.Windows.Forms.CheckBox();
            this.btProfile = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnPetInt.SuspendLayout();
            this.toolBar1.SuspendLayout();
            this.pnId.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.pnSkill.SuspendLayout();
            this.pnChar.SuspendLayout();
            this.pnPetChar.SuspendLayout();
            this.pnHumanChar.SuspendLayout();
            this.mbiLink.SuspendLayout();
            this.miRel.SuspendLayout();
            this.pnCareer.SuspendLayout();
            this.pnInt.SuspendLayout();
            this.pnSimInt.SuspendLayout();
            this.pnRel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnMisc.SuspendLayout();
            this.tbMotiveDec.SuspendLayout();
            this.tbpersonflags.SuspendLayout();
            this.bTaskBox3.SuspendLayout();
            this.bTaskBox2.SuspendLayout();
            this.bTaskBox1.SuspendLayout();
            this.pnEP1.SuspendLayout();
            this.tbSeminfo.SuspendLayout();
            this.pnEP7.SuspendLayout();
            this.bTaskBox4.SuspendLayout();
            this.pnEP2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtraits)).BeginInit();
            this.pnEP3.SuspendLayout();
            this.pnVoyage.SuspendLayout();
            this.pnEP9.SuspendLayout();
            this.tbfemdik.SuspendLayout();
            this.Various.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbicon)).BeginInit();
            this.Nipples.SuspendLayout();
            this.Pubes.SuspendLayout();
            this.pnPenis.SuspendLayout();
            this.pnMuffy.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnPetInt
            // 
            this.pnPetInt.BackColor = System.Drawing.Color.Transparent;
            this.pnPetInt.Controls.Add(this.pbPetEating);
            this.pnPetInt.Controls.Add(this.pbPetOutside);
            this.pnPetInt.Controls.Add(this.pbPetPlaying);
            this.pnPetInt.Controls.Add(this.pbPetSpooky);
            this.pnPetInt.Controls.Add(this.pbPetSleep);
            this.pnPetInt.Controls.Add(this.pbPetToy);
            this.pnPetInt.Controls.Add(this.pbPetWeather);
            this.pnPetInt.Controls.Add(this.pbPetPets);
            this.pnPetInt.Controls.Add(this.pbPetAnimals);
            resources.ApplyResources(this.pnPetInt, "pnPetInt");
            this.pnPetInt.Name = "pnPetInt";
            this.pnPetInt.VisibleChanged += new System.EventHandler(this.pnSimInt_VisibleChanged);
            // 
            // pbPetEating
            // 
            this.pbPetEating.BackColor = System.Drawing.Color.Transparent;
            this.pbPetEating.DisplayOffset = 0;
            resources.ApplyResources(this.pbPetEating, "pbPetEating");
            this.pbPetEating.Maximum = 1000;
            this.pbPetEating.Name = "pbPetEating";
            this.pbPetEating.NumberFormat = "N1";
            this.pbPetEating.NumberOffset = 0;
            this.pbPetEating.NumberScale = 0.01;
            this.pbPetEating.SelectedColor = System.Drawing.Color.Lime;
            this.pbPetEating.Style = Ambertation.Windows.Forms.ProgresBarStyle.Increase;
            this.pbPetEating.TokenCount = 10;
            this.pbPetEating.UnselectedColor = System.Drawing.Color.Black;
            this.pbPetEating.Value = 500;
            // 
            // pbPetOutside
            // 
            this.pbPetOutside.BackColor = System.Drawing.Color.Transparent;
            this.pbPetOutside.DisplayOffset = 0;
            resources.ApplyResources(this.pbPetOutside, "pbPetOutside");
            this.pbPetOutside.Maximum = 1000;
            this.pbPetOutside.Name = "pbPetOutside";
            this.pbPetOutside.NumberFormat = "N1";
            this.pbPetOutside.NumberOffset = 0;
            this.pbPetOutside.NumberScale = 0.01;
            this.pbPetOutside.SelectedColor = System.Drawing.Color.Lime;
            this.pbPetOutside.Style = Ambertation.Windows.Forms.ProgresBarStyle.Increase;
            this.pbPetOutside.TokenCount = 10;
            this.pbPetOutside.UnselectedColor = System.Drawing.Color.Black;
            this.pbPetOutside.Value = 500;
            // 
            // pbPetPlaying
            // 
            this.pbPetPlaying.BackColor = System.Drawing.Color.Transparent;
            this.pbPetPlaying.DisplayOffset = 0;
            resources.ApplyResources(this.pbPetPlaying, "pbPetPlaying");
            this.pbPetPlaying.Maximum = 1000;
            this.pbPetPlaying.Name = "pbPetPlaying";
            this.pbPetPlaying.NumberFormat = "N1";
            this.pbPetPlaying.NumberOffset = 0;
            this.pbPetPlaying.NumberScale = 0.01;
            this.pbPetPlaying.SelectedColor = System.Drawing.Color.Lime;
            this.pbPetPlaying.Style = Ambertation.Windows.Forms.ProgresBarStyle.Increase;
            this.pbPetPlaying.TokenCount = 10;
            this.pbPetPlaying.UnselectedColor = System.Drawing.Color.Black;
            this.pbPetPlaying.Value = 500;
            // 
            // pbPetSpooky
            // 
            this.pbPetSpooky.BackColor = System.Drawing.Color.Transparent;
            this.pbPetSpooky.DisplayOffset = 0;
            resources.ApplyResources(this.pbPetSpooky, "pbPetSpooky");
            this.pbPetSpooky.Maximum = 1000;
            this.pbPetSpooky.Name = "pbPetSpooky";
            this.pbPetSpooky.NumberFormat = "N1";
            this.pbPetSpooky.NumberOffset = 0;
            this.pbPetSpooky.NumberScale = 0.01;
            this.pbPetSpooky.SelectedColor = System.Drawing.Color.Lime;
            this.pbPetSpooky.Style = Ambertation.Windows.Forms.ProgresBarStyle.Increase;
            this.pbPetSpooky.TokenCount = 10;
            this.pbPetSpooky.UnselectedColor = System.Drawing.Color.Black;
            this.pbPetSpooky.Value = 500;
            // 
            // pbPetSleep
            // 
            this.pbPetSleep.BackColor = System.Drawing.Color.Transparent;
            this.pbPetSleep.DisplayOffset = 0;
            resources.ApplyResources(this.pbPetSleep, "pbPetSleep");
            this.pbPetSleep.Maximum = 1000;
            this.pbPetSleep.Name = "pbPetSleep";
            this.pbPetSleep.NumberFormat = "N1";
            this.pbPetSleep.NumberOffset = 0;
            this.pbPetSleep.NumberScale = 0.01;
            this.pbPetSleep.SelectedColor = System.Drawing.Color.Lime;
            this.pbPetSleep.Style = Ambertation.Windows.Forms.ProgresBarStyle.Increase;
            this.pbPetSleep.TokenCount = 10;
            this.pbPetSleep.UnselectedColor = System.Drawing.Color.Black;
            this.pbPetSleep.Value = 500;
            // 
            // pbPetToy
            // 
            this.pbPetToy.BackColor = System.Drawing.Color.Transparent;
            this.pbPetToy.DisplayOffset = 0;
            resources.ApplyResources(this.pbPetToy, "pbPetToy");
            this.pbPetToy.Maximum = 1000;
            this.pbPetToy.Name = "pbPetToy";
            this.pbPetToy.NumberFormat = "N1";
            this.pbPetToy.NumberOffset = 0;
            this.pbPetToy.NumberScale = 0.01;
            this.pbPetToy.SelectedColor = System.Drawing.Color.Lime;
            this.pbPetToy.Style = Ambertation.Windows.Forms.ProgresBarStyle.Increase;
            this.pbPetToy.TokenCount = 10;
            this.pbPetToy.UnselectedColor = System.Drawing.Color.Black;
            this.pbPetToy.Value = 500;
            // 
            // pbPetWeather
            // 
            this.pbPetWeather.BackColor = System.Drawing.Color.Transparent;
            this.pbPetWeather.DisplayOffset = 0;
            resources.ApplyResources(this.pbPetWeather, "pbPetWeather");
            this.pbPetWeather.Maximum = 1000;
            this.pbPetWeather.Name = "pbPetWeather";
            this.pbPetWeather.NumberFormat = "N1";
            this.pbPetWeather.NumberOffset = 0;
            this.pbPetWeather.NumberScale = 0.01;
            this.pbPetWeather.SelectedColor = System.Drawing.Color.Lime;
            this.pbPetWeather.Style = Ambertation.Windows.Forms.ProgresBarStyle.Increase;
            this.pbPetWeather.TokenCount = 10;
            this.pbPetWeather.UnselectedColor = System.Drawing.Color.Black;
            this.pbPetWeather.Value = 500;
            // 
            // pbPetPets
            // 
            this.pbPetPets.BackColor = System.Drawing.Color.Transparent;
            this.pbPetPets.DisplayOffset = 0;
            resources.ApplyResources(this.pbPetPets, "pbPetPets");
            this.pbPetPets.Maximum = 1000;
            this.pbPetPets.Name = "pbPetPets";
            this.pbPetPets.NumberFormat = "N1";
            this.pbPetPets.NumberOffset = 0;
            this.pbPetPets.NumberScale = 0.01;
            this.pbPetPets.SelectedColor = System.Drawing.Color.Lime;
            this.pbPetPets.Style = Ambertation.Windows.Forms.ProgresBarStyle.Increase;
            this.pbPetPets.TokenCount = 10;
            this.pbPetPets.UnselectedColor = System.Drawing.Color.Black;
            this.pbPetPets.Value = 500;
            // 
            // pbPetAnimals
            // 
            this.pbPetAnimals.BackColor = System.Drawing.Color.Transparent;
            this.pbPetAnimals.DisplayOffset = 0;
            resources.ApplyResources(this.pbPetAnimals, "pbPetAnimals");
            this.pbPetAnimals.Maximum = 1000;
            this.pbPetAnimals.Name = "pbPetAnimals";
            this.pbPetAnimals.NumberFormat = "N1";
            this.pbPetAnimals.NumberOffset = 0;
            this.pbPetAnimals.NumberScale = 0.01;
            this.pbPetAnimals.SelectedColor = System.Drawing.Color.Lime;
            this.pbPetAnimals.Style = Ambertation.Windows.Forms.ProgresBarStyle.Increase;
            this.pbPetAnimals.TokenCount = 10;
            this.pbPetAnimals.UnselectedColor = System.Drawing.Color.Black;
            this.pbPetAnimals.Value = 500;
            // 
            // toolBar1
            // 
            resources.ApplyResources(this.toolBar1, "toolBar1");
            this.toolBar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBar1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.biId,
            this.biCareer,
            this.biRel,
            this.biInt,
            this.biChar,
            this.biSkill,
            this.biMisc,
            this.biEP1,
            this.biEP2,
            this.biEP3,
            this.biEP6,
            this.biEP7,
            this.biEP9,
            this.biMore,
            this.biMax,
            this.biLezby});
            this.toolBar1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolBar1.Name = "toolBar1";
            // 
            // biId
            // 
            resources.ApplyResources(this.biId, "biId");
            this.biId.Name = "biId";
            this.biId.Click += new System.EventHandler(this.ChoosePage);
            // 
            // biCareer
            // 
            resources.ApplyResources(this.biCareer, "biCareer");
            this.biCareer.Name = "biCareer";
            this.biCareer.Click += new System.EventHandler(this.ChoosePage);
            // 
            // biRel
            // 
            resources.ApplyResources(this.biRel, "biRel");
            this.biRel.Name = "biRel";
            this.biRel.Click += new System.EventHandler(this.ChoosePage);
            // 
            // biInt
            // 
            resources.ApplyResources(this.biInt, "biInt");
            this.biInt.Name = "biInt";
            this.biInt.Click += new System.EventHandler(this.ChoosePage);
            // 
            // biChar
            // 
            resources.ApplyResources(this.biChar, "biChar");
            this.biChar.Name = "biChar";
            this.biChar.Click += new System.EventHandler(this.ChoosePage);
            // 
            // biSkill
            // 
            resources.ApplyResources(this.biSkill, "biSkill");
            this.biSkill.Name = "biSkill";
            this.biSkill.Click += new System.EventHandler(this.ChoosePage);
            // 
            // biMisc
            // 
            resources.ApplyResources(this.biMisc, "biMisc");
            this.biMisc.Name = "biMisc";
            this.biMisc.Click += new System.EventHandler(this.ChoosePage);
            // 
            // biEP1
            // 
            resources.ApplyResources(this.biEP1, "biEP1");
            this.biEP1.Name = "biEP1";
            this.biEP1.Click += new System.EventHandler(this.ChoosePage);
            // 
            // biEP2
            // 
            resources.ApplyResources(this.biEP2, "biEP2");
            this.biEP2.Name = "biEP2";
            this.biEP2.Click += new System.EventHandler(this.ChoosePage);
            // 
            // biEP3
            // 
            resources.ApplyResources(this.biEP3, "biEP3");
            this.biEP3.Name = "biEP3";
            this.biEP3.Click += new System.EventHandler(this.ChoosePage);
            // 
            // biEP6
            // 
            resources.ApplyResources(this.biEP6, "biEP6");
            this.biEP6.Name = "biEP6";
            this.biEP6.Click += new System.EventHandler(this.ChoosePage);
            // 
            // biEP7
            // 
            resources.ApplyResources(this.biEP7, "biEP7");
            this.biEP7.Name = "biEP7";
            this.biEP7.Click += new System.EventHandler(this.ChoosePage);
            // 
            // biEP9
            // 
            resources.ApplyResources(this.biEP9, "biEP9");
            this.biEP9.Name = "biEP9";
            this.biEP9.Click += new System.EventHandler(this.ChoosePage);
            // 
            // biMore
            // 
            resources.ApplyResources(this.biMore, "biMore");
            this.biMore.Name = "biMore";
            this.biMore.Click += new System.EventHandler(this.Activate_biMore);
            // 
            // biMax
            // 
            resources.ApplyResources(this.biMax, "biMax");
            this.biMax.Margin = new System.Windows.Forms.Padding(48, 1, 0, 2);
            this.biMax.Name = "biMax";
            this.biMax.Click += new System.EventHandler(this.Activate_biMax);
            // 
            // biLezby
            // 
            resources.ApplyResources(this.biLezby, "biLezby");
            this.biLezby.Name = "biLezby";
            this.biLezby.Click += new System.EventHandler(this.Activate_biLezby);
            // 
            // mbiMax
            // 
            resources.ApplyResources(this.mbiMax, "mbiMax");
            this.mbiMax.Name = "mbiMax";
            this.mbiMax.Click += new System.EventHandler(this.Activate_biMax);
            // 
            // pnId
            // 
            resources.ApplyResources(this.pnId, "pnId");
            this.pnId.BackColor = System.Drawing.Color.Transparent;
            this.pnId.Controls.Add(this.btOriGuid);
            this.pnId.Controls.Add(this.lbHousname);
            this.pnId.Controls.Add(this.lbSplitChar);
            this.pnId.Controls.Add(this.lbFixedRes);
            this.pnId.Controls.Add(this.tbsinstance);
            this.pnId.Controls.Add(this.label42);
            this.pnId.Controls.Add(this.lbsubspec);
            this.pnId.Controls.Add(this.label16);
            this.pnId.Controls.Add(this.cbSpecies);
            this.pnId.Controls.Add(this.label2);
            this.pnId.Controls.Add(this.label1);
            this.pnId.Controls.Add(this.tbsimdescfamname);
            this.pnId.Controls.Add(this.tbfaminst);
            this.pnId.Controls.Add(this.label49);
            this.pnId.Controls.Add(this.rbmale);
            this.pnId.Controls.Add(this.rbfemale);
            this.pnId.Controls.Add(this.pbImage);
            this.pnId.Controls.Add(this.tbsimdescname);
            this.pnId.Controls.Add(this.label13);
            this.pnId.Controls.Add(this.tbsim);
            this.pnId.Controls.Add(this.label10);
            this.pnId.Controls.Add(this.tbage);
            this.pnId.Controls.Add(this.label48);
            this.pnId.Controls.Add(this.cblifesection);
            this.pnId.Controls.Add(this.lbservice);
            this.pnId.Controls.Add(this.cbservice);
            this.pnId.Name = "pnId";
            // 
            // btOriGuid
            // 
            resources.ApplyResources(this.btOriGuid, "btOriGuid");
            this.btOriGuid.Name = "btOriGuid";
            this.toolTip1.SetToolTip(this.btOriGuid, resources.GetString("btOriGuid.ToolTip"));
            this.btOriGuid.UseVisualStyleBackColor = true;
            this.btOriGuid.Click += new System.EventHandler(this.btOriGuid_Click);
            // 
            // lbHousname
            // 
            resources.ApplyResources(this.lbHousname, "lbHousname");
            this.lbHousname.Name = "lbHousname";
            // 
            // lbSplitChar
            // 
            resources.ApplyResources(this.lbSplitChar, "lbSplitChar");
            this.lbSplitChar.ForeColor = System.Drawing.Color.Maroon;
            this.lbSplitChar.Name = "lbSplitChar";
            this.toolTip1.SetToolTip(this.lbSplitChar, resources.GetString("lbSplitChar.ToolTip"));
            // 
            // lbFixedRes
            // 
            resources.ApplyResources(this.lbFixedRes, "lbFixedRes");
            this.lbFixedRes.Name = "lbFixedRes";
            // 
            // tbsinstance
            // 
            resources.ApplyResources(this.tbsinstance, "tbsinstance");
            this.tbsinstance.Name = "tbsinstance";
            this.toolTip1.SetToolTip(this.tbsinstance, resources.GetString("tbsinstance.ToolTip"));
            this.tbsinstance.TextChanged += new System.EventHandler(this.ChangedId);
            // 
            // label42
            // 
            resources.ApplyResources(this.label42, "label42");
            this.label42.Name = "label42";
            // 
            // lbsubspec
            // 
            resources.ApplyResources(this.lbsubspec, "lbsubspec");
            this.lbsubspec.Name = "lbsubspec";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // cbSpecies
            // 
            this.cbSpecies.Enum = null;
            resources.ApplyResources(this.cbSpecies, "cbSpecies");
            this.cbSpecies.Name = "cbSpecies";
            this.cbSpecies.ResourceManager = null;
            this.cbSpecies.SelectionChangeCommitted += new System.EventHandler(this.ChangedEP2);
            this.cbSpecies.SelectedIndexChanged += new System.EventHandler(this.cbSpecies_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tbsimdescfamname
            // 
            resources.ApplyResources(this.tbsimdescfamname, "tbsimdescfamname");
            this.tbsimdescfamname.MaximumSize = new System.Drawing.Size(416, 21);
            this.tbsimdescfamname.MinimumSize = new System.Drawing.Size(200, 21);
            this.tbsimdescfamname.Name = "tbsimdescfamname";
            this.tbsimdescfamname.TextChanged += new System.EventHandler(this.ChangedId);
            // 
            // tbfaminst
            // 
            resources.ApplyResources(this.tbfaminst, "tbfaminst");
            this.tbfaminst.Name = "tbfaminst";
            this.tbfaminst.TextChanged += new System.EventHandler(this.ChangedId);
            // 
            // label49
            // 
            resources.ApplyResources(this.label49, "label49");
            this.label49.Name = "label49";
            // 
            // rbmale
            // 
            resources.ApplyResources(this.rbmale, "rbmale");
            this.rbmale.Name = "rbmale";
            this.rbmale.CheckedChanged += new System.EventHandler(this.ChangedId);
            // 
            // rbfemale
            // 
            resources.ApplyResources(this.rbfemale, "rbfemale");
            this.rbfemale.Name = "rbfemale";
            this.rbfemale.CheckedChanged += new System.EventHandler(this.ChangedId);
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pbImage, "pbImage");
            this.pbImage.Name = "pbImage";
            this.pbImage.TabStop = false;
            // 
            // tbsimdescname
            // 
            resources.ApplyResources(this.tbsimdescname, "tbsimdescname");
            this.tbsimdescname.Name = "tbsimdescname";
            this.tbsimdescname.TextChanged += new System.EventHandler(this.ChangedId);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // tbsim
            // 
            resources.ApplyResources(this.tbsim, "tbsim");
            this.tbsim.Name = "tbsim";
            this.tbsim.TextChanged += new System.EventHandler(this.ChangedId);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // tbage
            // 
            resources.ApplyResources(this.tbage, "tbage");
            this.tbage.Name = "tbage";
            this.tbage.TextChanged += new System.EventHandler(this.ChangedId);
            // 
            // label48
            // 
            resources.ApplyResources(this.label48, "label48");
            this.label48.Name = "label48";
            // 
            // cblifesection
            // 
            resources.ApplyResources(this.cblifesection, "cblifesection");
            this.cblifesection.Name = "cblifesection";
            this.cblifesection.SelectedValueChanged += new System.EventHandler(this.ChangedId);
            // 
            // lbservice
            // 
            resources.ApplyResources(this.lbservice, "lbservice");
            this.lbservice.Name = "lbservice";
            // 
            // cbservice
            // 
            resources.ApplyResources(this.cbservice, "cbservice");
            this.cbservice.FormattingEnabled = true;
            this.cbservice.Name = "cbservice";
            this.toolTip1.SetToolTip(this.cbservice, resources.GetString("cbservice.ToolTip"));
            this.cbservice.SelectedIndexChanged += new System.EventHandler(this.cbservice_SelectedIndexChanged);
            // 
            // pnSkill
            // 
            resources.ApplyResources(this.pnSkill, "pnSkill");
            this.pnSkill.BackColor = System.Drawing.Color.Transparent;
            this.pnSkill.Controls.Add(this.pbArty);
            this.pnSkill.Controls.Add(this.pbMusic);
            this.pnSkill.Controls.Add(this.pbPupbody);
            this.pnSkill.Controls.Add(this.pbPupClean);
            this.pnSkill.Controls.Add(this.pbPupCreative);
            this.pnSkill.Controls.Add(this.pbPupCharisma);
            this.pnSkill.Controls.Add(this.pbPupMech);
            this.pnSkill.Controls.Add(this.pbPupLogic);
            this.pnSkill.Controls.Add(this.pbBody);
            this.pnSkill.Controls.Add(this.pbFat);
            this.pnSkill.Controls.Add(this.pbClean);
            this.pnSkill.Controls.Add(this.pbCreative);
            this.pnSkill.Controls.Add(this.pbCharisma);
            this.pnSkill.Controls.Add(this.pbMech);
            this.pnSkill.Controls.Add(this.pbLogic);
            this.pnSkill.Controls.Add(this.pbCooking);
            this.pnSkill.Controls.Add(this.pbReputate);
            this.pnSkill.Name = "pnSkill";
            // 
            // pbArty
            // 
            this.pbArty.BackColor = System.Drawing.Color.Transparent;
            this.pbArty.DisplayOffset = 0;
            resources.ApplyResources(this.pbArty, "pbArty");
            this.pbArty.Maximum = 1000;
            this.pbArty.Name = "pbArty";
            this.pbArty.NumberFormat = "N2";
            this.pbArty.NumberOffset = 0;
            this.pbArty.NumberScale = 0.01;
            this.pbArty.SelectedColor = System.Drawing.Color.Lime;
            this.pbArty.TokenCount = 21;
            this.pbArty.UnselectedColor = System.Drawing.Color.Black;
            this.pbArty.Value = 500;
            this.pbArty.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbMusic
            // 
            this.pbMusic.BackColor = System.Drawing.Color.Transparent;
            this.pbMusic.DisplayOffset = 0;
            resources.ApplyResources(this.pbMusic, "pbMusic");
            this.pbMusic.Maximum = 1000;
            this.pbMusic.Name = "pbMusic";
            this.pbMusic.NumberFormat = "N2";
            this.pbMusic.NumberOffset = 0;
            this.pbMusic.NumberScale = 0.01;
            this.pbMusic.SelectedColor = System.Drawing.Color.Lime;
            this.pbMusic.TokenCount = 21;
            this.pbMusic.UnselectedColor = System.Drawing.Color.Black;
            this.pbMusic.Value = 500;
            this.pbMusic.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbPupbody
            // 
            this.pbPupbody.BackColor = System.Drawing.Color.Transparent;
            this.pbPupbody.DisplayOffset = 0;
            resources.ApplyResources(this.pbPupbody, "pbPupbody");
            this.pbPupbody.Maximum = 1000;
            this.pbPupbody.Name = "pbPupbody";
            this.pbPupbody.NumberFormat = "N2";
            this.pbPupbody.NumberOffset = 0;
            this.pbPupbody.NumberScale = 0.01;
            this.pbPupbody.SelectedColor = System.Drawing.Color.Lime;
            this.pbPupbody.TokenCount = 21;
            this.toolTip1.SetToolTip(this.pbPupbody, resources.GetString("pbPupbody.ToolTip"));
            this.pbPupbody.UnselectedColor = System.Drawing.Color.Black;
            this.pbPupbody.Value = 500;
            this.pbPupbody.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbPupClean
            // 
            this.pbPupClean.BackColor = System.Drawing.Color.Transparent;
            this.pbPupClean.DisplayOffset = 0;
            resources.ApplyResources(this.pbPupClean, "pbPupClean");
            this.pbPupClean.Maximum = 1000;
            this.pbPupClean.Name = "pbPupClean";
            this.pbPupClean.NumberFormat = "N2";
            this.pbPupClean.NumberOffset = 0;
            this.pbPupClean.NumberScale = 0.01;
            this.pbPupClean.SelectedColor = System.Drawing.Color.Lime;
            this.pbPupClean.TokenCount = 21;
            this.toolTip1.SetToolTip(this.pbPupClean, resources.GetString("pbPupClean.ToolTip"));
            this.pbPupClean.UnselectedColor = System.Drawing.Color.Black;
            this.pbPupClean.Value = 500;
            this.pbPupClean.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbPupCreative
            // 
            this.pbPupCreative.BackColor = System.Drawing.Color.Transparent;
            this.pbPupCreative.DisplayOffset = 0;
            resources.ApplyResources(this.pbPupCreative, "pbPupCreative");
            this.pbPupCreative.Maximum = 1000;
            this.pbPupCreative.Name = "pbPupCreative";
            this.pbPupCreative.NumberFormat = "N2";
            this.pbPupCreative.NumberOffset = 0;
            this.pbPupCreative.NumberScale = 0.01;
            this.pbPupCreative.SelectedColor = System.Drawing.Color.Lime;
            this.pbPupCreative.TokenCount = 21;
            this.toolTip1.SetToolTip(this.pbPupCreative, resources.GetString("pbPupCreative.ToolTip"));
            this.pbPupCreative.UnselectedColor = System.Drawing.Color.Black;
            this.pbPupCreative.Value = 500;
            this.pbPupCreative.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbPupCharisma
            // 
            this.pbPupCharisma.BackColor = System.Drawing.Color.Transparent;
            this.pbPupCharisma.DisplayOffset = 0;
            resources.ApplyResources(this.pbPupCharisma, "pbPupCharisma");
            this.pbPupCharisma.Maximum = 1000;
            this.pbPupCharisma.Name = "pbPupCharisma";
            this.pbPupCharisma.NumberFormat = "N2";
            this.pbPupCharisma.NumberOffset = 0;
            this.pbPupCharisma.NumberScale = 0.01;
            this.pbPupCharisma.SelectedColor = System.Drawing.Color.Lime;
            this.pbPupCharisma.TokenCount = 21;
            this.toolTip1.SetToolTip(this.pbPupCharisma, resources.GetString("pbPupCharisma.ToolTip"));
            this.pbPupCharisma.UnselectedColor = System.Drawing.Color.Black;
            this.pbPupCharisma.Value = 500;
            this.pbPupCharisma.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbPupMech
            // 
            this.pbPupMech.BackColor = System.Drawing.Color.Transparent;
            this.pbPupMech.DisplayOffset = 0;
            resources.ApplyResources(this.pbPupMech, "pbPupMech");
            this.pbPupMech.Maximum = 1000;
            this.pbPupMech.Name = "pbPupMech";
            this.pbPupMech.NumberFormat = "N2";
            this.pbPupMech.NumberOffset = 0;
            this.pbPupMech.NumberScale = 0.01;
            this.pbPupMech.SelectedColor = System.Drawing.Color.Lime;
            this.pbPupMech.TokenCount = 21;
            this.toolTip1.SetToolTip(this.pbPupMech, resources.GetString("pbPupMech.ToolTip"));
            this.pbPupMech.UnselectedColor = System.Drawing.Color.Black;
            this.pbPupMech.Value = 500;
            this.pbPupMech.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbPupLogic
            // 
            this.pbPupLogic.BackColor = System.Drawing.Color.Transparent;
            this.pbPupLogic.DisplayOffset = 0;
            resources.ApplyResources(this.pbPupLogic, "pbPupLogic");
            this.pbPupLogic.Maximum = 1000;
            this.pbPupLogic.Name = "pbPupLogic";
            this.pbPupLogic.NumberFormat = "N2";
            this.pbPupLogic.NumberOffset = 0;
            this.pbPupLogic.NumberScale = 0.01;
            this.pbPupLogic.SelectedColor = System.Drawing.Color.Lime;
            this.pbPupLogic.TokenCount = 21;
            this.toolTip1.SetToolTip(this.pbPupLogic, resources.GetString("pbPupLogic.ToolTip"));
            this.pbPupLogic.UnselectedColor = System.Drawing.Color.Black;
            this.pbPupLogic.Value = 500;
            this.pbPupLogic.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbBody
            // 
            this.pbBody.BackColor = System.Drawing.Color.Transparent;
            this.pbBody.DisplayOffset = 0;
            resources.ApplyResources(this.pbBody, "pbBody");
            this.pbBody.Maximum = 1000;
            this.pbBody.Name = "pbBody";
            this.pbBody.NumberFormat = "N2";
            this.pbBody.NumberOffset = 0;
            this.pbBody.NumberScale = 0.01;
            this.pbBody.SelectedColor = System.Drawing.Color.Lime;
            this.pbBody.Style = Ambertation.Windows.Forms.ProgresBarStyle.Flat;
            this.pbBody.UnselectedColor = System.Drawing.Color.Black;
            this.pbBody.Value = 500;
            this.pbBody.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbFat
            // 
            this.pbFat.BackColor = System.Drawing.Color.Transparent;
            this.pbFat.DisplayOffset = 0;
            resources.ApplyResources(this.pbFat, "pbFat");
            this.pbFat.Maximum = 1000;
            this.pbFat.Name = "pbFat";
            this.pbFat.NumberFormat = "N1";
            this.pbFat.NumberOffset = 0;
            this.pbFat.NumberScale = 0.01;
            this.pbFat.SelectedColor = System.Drawing.Color.Orange;
            this.pbFat.Style = Ambertation.Windows.Forms.ProgresBarStyle.Increase;
            this.pbFat.TokenCount = 10;
            this.pbFat.UnselectedColor = System.Drawing.Color.Black;
            this.pbFat.Value = 500;
            this.pbFat.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbClean
            // 
            this.pbClean.BackColor = System.Drawing.Color.Transparent;
            this.pbClean.DisplayOffset = 0;
            resources.ApplyResources(this.pbClean, "pbClean");
            this.pbClean.Maximum = 1000;
            this.pbClean.Name = "pbClean";
            this.pbClean.NumberFormat = "N2";
            this.pbClean.NumberOffset = 0;
            this.pbClean.NumberScale = 0.01;
            this.pbClean.SelectedColor = System.Drawing.Color.Lime;
            this.pbClean.TokenCount = 21;
            this.pbClean.UnselectedColor = System.Drawing.Color.Black;
            this.pbClean.Value = 500;
            this.pbClean.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbCreative
            // 
            this.pbCreative.BackColor = System.Drawing.Color.Transparent;
            this.pbCreative.DisplayOffset = 0;
            resources.ApplyResources(this.pbCreative, "pbCreative");
            this.pbCreative.Maximum = 1000;
            this.pbCreative.Name = "pbCreative";
            this.pbCreative.NumberFormat = "N2";
            this.pbCreative.NumberOffset = 0;
            this.pbCreative.NumberScale = 0.01;
            this.pbCreative.SelectedColor = System.Drawing.Color.Lime;
            this.pbCreative.Style = Ambertation.Windows.Forms.ProgresBarStyle.Flat;
            this.pbCreative.TokenCount = 21;
            this.pbCreative.UnselectedColor = System.Drawing.Color.Black;
            this.pbCreative.Value = 500;
            this.pbCreative.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbCharisma
            // 
            this.pbCharisma.BackColor = System.Drawing.Color.Transparent;
            this.pbCharisma.DisplayOffset = 0;
            resources.ApplyResources(this.pbCharisma, "pbCharisma");
            this.pbCharisma.Maximum = 1000;
            this.pbCharisma.Name = "pbCharisma";
            this.pbCharisma.NumberFormat = "N2";
            this.pbCharisma.NumberOffset = 0;
            this.pbCharisma.NumberScale = 0.01;
            this.pbCharisma.SelectedColor = System.Drawing.Color.Lime;
            this.pbCharisma.TokenCount = 21;
            this.pbCharisma.UnselectedColor = System.Drawing.Color.Black;
            this.pbCharisma.Value = 500;
            this.pbCharisma.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbMech
            // 
            this.pbMech.BackColor = System.Drawing.Color.Transparent;
            this.pbMech.DisplayOffset = 0;
            resources.ApplyResources(this.pbMech, "pbMech");
            this.pbMech.Maximum = 1000;
            this.pbMech.Name = "pbMech";
            this.pbMech.NumberFormat = "N2";
            this.pbMech.NumberOffset = 0;
            this.pbMech.NumberScale = 0.01;
            this.pbMech.SelectedColor = System.Drawing.Color.Lime;
            this.pbMech.TokenCount = 21;
            this.pbMech.UnselectedColor = System.Drawing.Color.Black;
            this.pbMech.Value = 500;
            this.pbMech.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbLogic
            // 
            this.pbLogic.BackColor = System.Drawing.Color.Transparent;
            this.pbLogic.DisplayOffset = 0;
            resources.ApplyResources(this.pbLogic, "pbLogic");
            this.pbLogic.Maximum = 1000;
            this.pbLogic.Name = "pbLogic";
            this.pbLogic.NumberFormat = "N2";
            this.pbLogic.NumberOffset = 0;
            this.pbLogic.NumberScale = 0.01;
            this.pbLogic.SelectedColor = System.Drawing.Color.Lime;
            this.pbLogic.TokenCount = 21;
            this.pbLogic.UnselectedColor = System.Drawing.Color.Black;
            this.pbLogic.Value = 500;
            this.pbLogic.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbCooking
            // 
            this.pbCooking.BackColor = System.Drawing.Color.Transparent;
            this.pbCooking.DisplayOffset = 0;
            resources.ApplyResources(this.pbCooking, "pbCooking");
            this.pbCooking.Maximum = 1000;
            this.pbCooking.Name = "pbCooking";
            this.pbCooking.NumberFormat = "N2";
            this.pbCooking.NumberOffset = 0;
            this.pbCooking.NumberScale = 0.01;
            this.pbCooking.SelectedColor = System.Drawing.Color.Lime;
            this.pbCooking.TokenCount = 21;
            this.pbCooking.UnselectedColor = System.Drawing.Color.Black;
            this.pbCooking.Value = 500;
            this.pbCooking.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbReputate
            // 
            this.pbReputate.BackColor = System.Drawing.Color.Transparent;
            this.pbReputate.DisplayOffset = 0;
            resources.ApplyResources(this.pbReputate, "pbReputate");
            this.pbReputate.Maximum = 200;
            this.pbReputate.Name = "pbReputate";
            this.pbReputate.NumberFormat = "N0";
            this.pbReputate.NumberOffset = -100;
            this.pbReputate.NumberScale = 1;
            this.pbReputate.SelectedColor = System.Drawing.Color.Gold;
            this.pbReputate.TokenCount = 19;
            this.pbReputate.UnselectedColor = System.Drawing.Color.Black;
            this.pbReputate.Value = 0;
            this.pbReputate.Changed += new System.EventHandler(this.ChangedSkill);
            // 
            // pbRomance
            // 
            this.pbRomance.BackColor = System.Drawing.Color.Transparent;
            this.pbRomance.DisplayOffset = 0;
            resources.ApplyResources(this.pbRomance, "pbRomance");
            this.pbRomance.Maximum = 1000;
            this.pbRomance.Name = "pbRomance";
            this.pbRomance.NumberFormat = "N2";
            this.pbRomance.NumberOffset = 0;
            this.pbRomance.NumberScale = 0.01;
            this.pbRomance.SelectedColor = System.Drawing.Color.HotPink;
            this.pbRomance.TokenCount = 21;
            this.pbRomance.UnselectedColor = System.Drawing.Color.Black;
            this.pbRomance.Value = 500;
            // 
            // pnChar
            // 
            resources.ApplyResources(this.pnChar, "pnChar");
            this.pnChar.BackColor = System.Drawing.Color.Transparent;
            this.pnChar.Controls.Add(this.btProfile);
            this.pnChar.Controls.Add(this.pnPetChar);
            this.pnChar.Controls.Add(this.pnHumanChar);
            this.pnChar.Controls.Add(this.pbMan);
            this.pnChar.Controls.Add(this.pbWoman);
            this.pnChar.Controls.Add(this.cbzodiac);
            this.pnChar.Controls.Add(this.label47);
            this.pnChar.Controls.Add(this.panel2);
            this.pnChar.Controls.Add(this.label69);
            this.pnChar.Controls.Add(this.panel1);
            this.pnChar.Controls.Add(this.label70);
            this.pnChar.Name = "pnChar";
            this.pnChar.VisibleChanged += new System.EventHandler(this.pnInt_VisibleChanged);
            // 
            // pnPetChar
            // 
            resources.ApplyResources(this.pnPetChar, "pnPetChar");
            this.pnPetChar.BackColor = System.Drawing.Color.Transparent;
            this.pnPetChar.Controls.Add(this.label26);
            this.pnPetChar.Controls.Add(this.label25);
            this.pnPetChar.Controls.Add(this.label24);
            this.pnPetChar.Controls.Add(this.label23);
            this.pnPetChar.Controls.Add(this.label22);
            this.pnPetChar.Controls.Add(this.ptPigpen);
            this.pnPetChar.Controls.Add(this.ptAggres);
            this.pnPetChar.Controls.Add(this.ptIndep);
            this.pnPetChar.Controls.Add(this.ptHyper);
            this.pnPetChar.Controls.Add(this.ptGifted);
            this.pnPetChar.Controls.Add(this.label21);
            this.pnPetChar.Controls.Add(this.label20);
            this.pnPetChar.Controls.Add(this.label19);
            this.pnPetChar.Controls.Add(this.label18);
            this.pnPetChar.Controls.Add(this.label17);
            this.pnPetChar.Name = "pnPetChar";
            // 
            // btProfile
            // 
            resources.ApplyResources(this.btProfile, "btProfile");
            this.btProfile.Name = "btProfile";
            this.btProfile.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // ptPigpen
            // 
            resources.ApplyResources(this.ptPigpen, "ptPigpen");
            this.ptPigpen.Level = SimPe.PackedFiles.Wrapper.PetTraitSelect.Levels.Normal;
            this.ptPigpen.Name = "ptPigpen";
            this.ptPigpen.LevelChanged += new System.EventHandler(this.ChangedEP4);
            // 
            // ptAggres
            // 
            resources.ApplyResources(this.ptAggres, "ptAggres");
            this.ptAggres.Level = SimPe.PackedFiles.Wrapper.PetTraitSelect.Levels.Normal;
            this.ptAggres.Name = "ptAggres";
            this.ptAggres.LevelChanged += new System.EventHandler(this.ChangedEP4);
            // 
            // ptIndep
            // 
            resources.ApplyResources(this.ptIndep, "ptIndep");
            this.ptIndep.Level = SimPe.PackedFiles.Wrapper.PetTraitSelect.Levels.Normal;
            this.ptIndep.Name = "ptIndep";
            this.ptIndep.LevelChanged += new System.EventHandler(this.ChangedEP4);
            // 
            // ptHyper
            // 
            resources.ApplyResources(this.ptHyper, "ptHyper");
            this.ptHyper.Level = SimPe.PackedFiles.Wrapper.PetTraitSelect.Levels.Normal;
            this.ptHyper.Name = "ptHyper";
            this.ptHyper.LevelChanged += new System.EventHandler(this.ChangedEP4);
            // 
            // ptGifted
            // 
            resources.ApplyResources(this.ptGifted, "ptGifted");
            this.ptGifted.Level = SimPe.PackedFiles.Wrapper.PetTraitSelect.Levels.Normal;
            this.ptGifted.Name = "ptGifted";
            this.ptGifted.LevelChanged += new System.EventHandler(this.ChangedEP4);
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // pnHumanChar
            // 
            this.pnHumanChar.Controls.Add(this.pbNeat);
            this.pnHumanChar.Controls.Add(this.pbOutgoing);
            this.pnHumanChar.Controls.Add(this.pbActive);
            this.pnHumanChar.Controls.Add(this.pbPlayful);
            this.pnHumanChar.Controls.Add(this.pbGNice);
            this.pnHumanChar.Controls.Add(this.pbNice);
            this.pnHumanChar.Controls.Add(this.pbGPlayful);
            this.pnHumanChar.Controls.Add(this.pbGNeat);
            this.pnHumanChar.Controls.Add(this.pbGActive);
            this.pnHumanChar.Controls.Add(this.pbGOutgoing);
            resources.ApplyResources(this.pnHumanChar, "pnHumanChar");
            this.pnHumanChar.Name = "pnHumanChar";
            // 
            // pbNeat
            // 
            this.pbNeat.BackColor = System.Drawing.Color.Transparent;
            this.pbNeat.DisplayOffset = 0;
            resources.ApplyResources(this.pbNeat, "pbNeat");
            this.pbNeat.Maximum = 1000;
            this.pbNeat.Name = "pbNeat";
            this.pbNeat.NumberFormat = "N1";
            this.pbNeat.NumberOffset = 0;
            this.pbNeat.NumberScale = 0.01;
            this.pbNeat.SelectedColor = System.Drawing.Color.Lime;
            this.pbNeat.TokenCount = 10;
            this.pbNeat.UnselectedColor = System.Drawing.Color.Black;
            this.pbNeat.Value = 50;
            this.pbNeat.Changed += new System.EventHandler(this.ChangedChar);
            // 
            // pbOutgoing
            // 
            this.pbOutgoing.BackColor = System.Drawing.Color.Transparent;
            this.pbOutgoing.DisplayOffset = 0;
            resources.ApplyResources(this.pbOutgoing, "pbOutgoing");
            this.pbOutgoing.Maximum = 1000;
            this.pbOutgoing.Name = "pbOutgoing";
            this.pbOutgoing.NumberFormat = "N1";
            this.pbOutgoing.NumberOffset = 0;
            this.pbOutgoing.NumberScale = 0.01;
            this.pbOutgoing.SelectedColor = System.Drawing.Color.Lime;
            this.pbOutgoing.TokenCount = 10;
            this.pbOutgoing.UnselectedColor = System.Drawing.Color.Black;
            this.pbOutgoing.Value = 50;
            this.pbOutgoing.Changed += new System.EventHandler(this.ChangedChar);
            // 
            // pbActive
            // 
            this.pbActive.BackColor = System.Drawing.Color.Transparent;
            this.pbActive.DisplayOffset = 0;
            resources.ApplyResources(this.pbActive, "pbActive");
            this.pbActive.Maximum = 1000;
            this.pbActive.Name = "pbActive";
            this.pbActive.NumberFormat = "N1";
            this.pbActive.NumberOffset = 0;
            this.pbActive.NumberScale = 0.01;
            this.pbActive.SelectedColor = System.Drawing.Color.Lime;
            this.pbActive.TokenCount = 10;
            this.pbActive.UnselectedColor = System.Drawing.Color.Black;
            this.pbActive.Value = 50;
            this.pbActive.Changed += new System.EventHandler(this.ChangedChar);
            // 
            // pbPlayful
            // 
            this.pbPlayful.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayful.DisplayOffset = 0;
            resources.ApplyResources(this.pbPlayful, "pbPlayful");
            this.pbPlayful.Maximum = 1000;
            this.pbPlayful.Name = "pbPlayful";
            this.pbPlayful.NumberFormat = "N1";
            this.pbPlayful.NumberOffset = 0;
            this.pbPlayful.NumberScale = 0.01;
            this.pbPlayful.SelectedColor = System.Drawing.Color.Lime;
            this.pbPlayful.TokenCount = 10;
            this.pbPlayful.UnselectedColor = System.Drawing.Color.Black;
            this.pbPlayful.Value = 50;
            this.pbPlayful.Changed += new System.EventHandler(this.ChangedChar);
            // 
            // pbGNice
            // 
            this.pbGNice.BackColor = System.Drawing.Color.Transparent;
            this.pbGNice.DisplayOffset = 0;
            resources.ApplyResources(this.pbGNice, "pbGNice");
            this.pbGNice.Maximum = 1000;
            this.pbGNice.Name = "pbGNice";
            this.pbGNice.NumberFormat = "N1";
            this.pbGNice.NumberOffset = 0;
            this.pbGNice.NumberScale = 0.01;
            this.pbGNice.SelectedColor = System.Drawing.Color.Lime;
            this.pbGNice.TokenCount = 10;
            this.pbGNice.UnselectedColor = System.Drawing.Color.Black;
            this.pbGNice.Value = 50;
            this.pbGNice.Changed += new System.EventHandler(this.ChangedChar);
            // 
            // pbNice
            // 
            this.pbNice.BackColor = System.Drawing.Color.Transparent;
            this.pbNice.DisplayOffset = 0;
            resources.ApplyResources(this.pbNice, "pbNice");
            this.pbNice.Maximum = 1000;
            this.pbNice.Name = "pbNice";
            this.pbNice.NumberFormat = "N1";
            this.pbNice.NumberOffset = 0;
            this.pbNice.NumberScale = 0.01;
            this.pbNice.SelectedColor = System.Drawing.Color.Lime;
            this.pbNice.TokenCount = 10;
            this.pbNice.UnselectedColor = System.Drawing.Color.Black;
            this.pbNice.Value = 50;
            this.pbNice.Changed += new System.EventHandler(this.ChangedChar);
            // 
            // pbGPlayful
            // 
            this.pbGPlayful.BackColor = System.Drawing.Color.Transparent;
            this.pbGPlayful.DisplayOffset = 0;
            resources.ApplyResources(this.pbGPlayful, "pbGPlayful");
            this.pbGPlayful.Maximum = 1000;
            this.pbGPlayful.Name = "pbGPlayful";
            this.pbGPlayful.NumberFormat = "N1";
            this.pbGPlayful.NumberOffset = 0;
            this.pbGPlayful.NumberScale = 0.01;
            this.pbGPlayful.SelectedColor = System.Drawing.Color.Lime;
            this.pbGPlayful.TokenCount = 10;
            this.pbGPlayful.UnselectedColor = System.Drawing.Color.Black;
            this.pbGPlayful.Value = 50;
            this.pbGPlayful.Changed += new System.EventHandler(this.ChangedChar);
            // 
            // pbGNeat
            // 
            this.pbGNeat.BackColor = System.Drawing.Color.Transparent;
            this.pbGNeat.DisplayOffset = 0;
            resources.ApplyResources(this.pbGNeat, "pbGNeat");
            this.pbGNeat.Maximum = 1000;
            this.pbGNeat.Name = "pbGNeat";
            this.pbGNeat.NumberFormat = "N1";
            this.pbGNeat.NumberOffset = 0;
            this.pbGNeat.NumberScale = 0.01;
            this.pbGNeat.SelectedColor = System.Drawing.Color.Lime;
            this.pbGNeat.TokenCount = 10;
            this.pbGNeat.UnselectedColor = System.Drawing.Color.Black;
            this.pbGNeat.Value = 50;
            this.pbGNeat.Changed += new System.EventHandler(this.ChangedChar);
            // 
            // pbGActive
            // 
            this.pbGActive.BackColor = System.Drawing.Color.Transparent;
            this.pbGActive.DisplayOffset = 0;
            resources.ApplyResources(this.pbGActive, "pbGActive");
            this.pbGActive.Maximum = 1000;
            this.pbGActive.Name = "pbGActive";
            this.pbGActive.NumberFormat = "N1";
            this.pbGActive.NumberOffset = 0;
            this.pbGActive.NumberScale = 0.01;
            this.pbGActive.SelectedColor = System.Drawing.Color.Lime;
            this.pbGActive.TokenCount = 10;
            this.pbGActive.UnselectedColor = System.Drawing.Color.Black;
            this.pbGActive.Value = 50;
            this.pbGActive.Changed += new System.EventHandler(this.ChangedChar);
            // 
            // pbGOutgoing
            // 
            this.pbGOutgoing.BackColor = System.Drawing.Color.Transparent;
            this.pbGOutgoing.DisplayOffset = 0;
            resources.ApplyResources(this.pbGOutgoing, "pbGOutgoing");
            this.pbGOutgoing.Maximum = 1000;
            this.pbGOutgoing.Name = "pbGOutgoing";
            this.pbGOutgoing.NumberFormat = "N1";
            this.pbGOutgoing.NumberOffset = 0;
            this.pbGOutgoing.NumberScale = 0.01;
            this.pbGOutgoing.SelectedColor = System.Drawing.Color.Lime;
            this.pbGOutgoing.TokenCount = 10;
            this.pbGOutgoing.UnselectedColor = System.Drawing.Color.Black;
            this.pbGOutgoing.Value = 50;
            this.pbGOutgoing.Changed += new System.EventHandler(this.ChangedChar);
            // 
            // pbMan
            // 
            this.pbMan.BackColor = System.Drawing.Color.Transparent;
            this.pbMan.DisplayOffset = 0;
            resources.ApplyResources(this.pbMan, "pbMan");
            this.pbMan.Maximum = 2000;
            this.pbMan.Name = "pbMan";
            this.pbMan.NumberFormat = "N1";
            this.pbMan.NumberOffset = -1000;
            this.pbMan.NumberScale = 0.01;
            this.pbMan.SelectedColor = System.Drawing.Color.OrangeRed;
            this.pbMan.TokenCount = 19;
            this.pbMan.UnselectedColor = System.Drawing.Color.Black;
            this.pbMan.Value = 0;
            this.pbMan.Changed += new System.EventHandler(this.ChangedChar);
            // 
            // pbWoman
            // 
            this.pbWoman.BackColor = System.Drawing.Color.Transparent;
            this.pbWoman.DisplayOffset = 0;
            resources.ApplyResources(this.pbWoman, "pbWoman");
            this.pbWoman.Maximum = 2000;
            this.pbWoman.Name = "pbWoman";
            this.pbWoman.NumberFormat = "N1";
            this.pbWoman.NumberOffset = -1000;
            this.pbWoman.NumberScale = 0.01;
            this.pbWoman.SelectedColor = System.Drawing.Color.OrangeRed;
            this.pbWoman.TokenCount = 19;
            this.pbWoman.UnselectedColor = System.Drawing.Color.Black;
            this.pbWoman.Value = 0;
            this.pbWoman.Changed += new System.EventHandler(this.ChangedChar);
            // 
            // cbzodiac
            // 
            resources.ApplyResources(this.cbzodiac, "cbzodiac");
            this.cbzodiac.Name = "cbzodiac";
            this.cbzodiac.SelectedIndexChanged += new System.EventHandler(this.ChangedChar);
            // 
            // label47
            // 
            resources.ApplyResources(this.label47, "label47");
            this.label47.Name = "label47";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label69
            // 
            this.label69.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.label69, "label69");
            this.label69.Name = "label69";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label70
            // 
            this.label70.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.label70, "label70");
            this.label70.Name = "label70";
            // 
            // mbiLink
            // 
            this.mbiLink.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbiMax,
            this.miRand,
            this.toolStripMenuItem1,
            this.miOpenChar,
            this.miOpenWf,
            this.miOpenMem,
            this.miOpenBadge,
            this.miOpenDNA,
            this.miOpenSCOR,
            this.miOpenFamily,
            this.miOpenCloth,
            this.toolStripMenuItem2,
            this.miMore,
            this.miRelink});
            this.mbiLink.Name = "mbiLink";
            resources.ApplyResources(this.mbiLink, "mbiLink");
            // 
            // miRand
            // 
            resources.ApplyResources(this.miRand, "miRand");
            this.miRand.Name = "miRand";
            this.miRand.Click += new System.EventHandler(this.Activate_biRand);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // miOpenChar
            // 
            resources.ApplyResources(this.miOpenChar, "miOpenChar");
            this.miOpenChar.Name = "miOpenChar";
            this.miOpenChar.Click += new System.EventHandler(this.Activate_miOpenCHar);
            // 
            // miOpenWf
            // 
            resources.ApplyResources(this.miOpenWf, "miOpenWf");
            this.miOpenWf.Name = "miOpenWf";
            this.miOpenWf.Click += new System.EventHandler(this.Activate_miOpenWf);
            // 
            // miOpenMem
            // 
            resources.ApplyResources(this.miOpenMem, "miOpenMem");
            this.miOpenMem.Name = "miOpenMem";
            this.miOpenMem.Click += new System.EventHandler(this.Activate_miOpenMem);
            // 
            // miOpenBadge
            // 
            resources.ApplyResources(this.miOpenBadge, "miOpenBadge");
            this.miOpenBadge.Name = "miOpenBadge";
            this.miOpenBadge.Click += new System.EventHandler(this.Activate_miOpenBadge);
            // 
            // miOpenDNA
            // 
            resources.ApplyResources(this.miOpenDNA, "miOpenDNA");
            this.miOpenDNA.Name = "miOpenDNA";
            this.miOpenDNA.Click += new System.EventHandler(this.Activate_miOpenDNA);
            // 
            // miOpenSCOR
            // 
            resources.ApplyResources(this.miOpenSCOR, "miOpenSCOR");
            this.miOpenSCOR.Name = "miOpenSCOR";
            this.miOpenSCOR.Click += new System.EventHandler(this.activate_miOpenScore);
            // 
            // miOpenFamily
            // 
            resources.ApplyResources(this.miOpenFamily, "miOpenFamily");
            this.miOpenFamily.Name = "miOpenFamily";
            this.miOpenFamily.Click += new System.EventHandler(this.Activate_miFamily);
            // 
            // miOpenCloth
            // 
            this.miOpenCloth.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.miOpenCloth, "miOpenCloth");
            this.miOpenCloth.Name = "miOpenCloth";
            this.miOpenCloth.Click += new System.EventHandler(this.Activate_miOpenCloth);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // miMore
            // 
            resources.ApplyResources(this.miMore, "miMore");
            this.miMore.Name = "miMore";
            this.miMore.Click += new System.EventHandler(this.Activate_miMore);
            // 
            // miRelink
            // 
            resources.ApplyResources(this.miRelink, "miRelink");
            this.miRelink.Name = "miRelink";
            this.miRelink.Click += new System.EventHandler(this.Activate_miRelink);
            // 
            // miRel
            // 
            this.miRel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddRelation,
            this.miRemRelation,
            this.toolStripMenuItem3,
            this.mbiMaxThisRel,
            this.mbiMaxKnownRel});
            this.miRel.Name = "miRel";
            resources.ApplyResources(this.miRel, "miRel");
            this.miRel.VisibleChanged += new System.EventHandler(this.miRel_BeforePopup);
            // 
            // miAddRelation
            // 
            resources.ApplyResources(this.miAddRelation, "miAddRelation");
            this.miAddRelation.Name = "miAddRelation";
            this.miAddRelation.Click += new System.EventHandler(this.Activate_miAddRelation);
            // 
            // miRemRelation
            // 
            resources.ApplyResources(this.miRemRelation, "miRemRelation");
            this.miRemRelation.Name = "miRemRelation";
            this.miRemRelation.Click += new System.EventHandler(this.Activate_miRemRelation);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // mbiMaxThisRel
            // 
            this.mbiMaxThisRel.Name = "mbiMaxThisRel";
            resources.ApplyResources(this.mbiMaxThisRel, "mbiMaxThisRel");
            this.mbiMaxThisRel.Click += new System.EventHandler(this.Activate_mbiMaxThisRel);
            // 
            // mbiMaxKnownRel
            // 
            this.mbiMaxKnownRel.Name = "mbiMaxKnownRel";
            resources.ApplyResources(this.mbiMaxKnownRel, "mbiMaxKnownRel");
            this.mbiMaxKnownRel.Click += new System.EventHandler(this.Activate_mbiMaxKnownRel);
            // 
            // pnCareer
            // 
            resources.ApplyResources(this.pnCareer, "pnCareer");
            this.pnCareer.BackColor = System.Drawing.Color.Transparent;
            this.pnCareer.Controls.Add(this.lbRetcareer);
            this.pnCareer.Controls.Add(this.lpRetirement);
            this.pnCareer.Controls.Add(this.cbRetirement);
            this.pnCareer.Controls.Add(this.tbpension);
            this.pnCareer.Controls.Add(this.lbpension);
            this.pnCareer.Controls.Add(this.lbaccholidays);
            this.pnCareer.Controls.Add(this.tbaccholidays);
            this.pnCareer.Controls.Add(this.pbAspBliz);
            this.pnCareer.Controls.Add(this.label60);
            this.pnCareer.Controls.Add(this.cbaspiration);
            this.pnCareer.Controls.Add(this.pbAspCur);
            this.pnCareer.Controls.Add(this.label46);
            this.pnCareer.Controls.Add(this.tblifelinescore);
            this.pnCareer.Controls.Add(this.pbCareerPerformance);
            this.pnCareer.Controls.Add(this.pbCareerLevel);
            this.pnCareer.Controls.Add(this.label78);
            this.pnCareer.Controls.Add(this.tbschooltype);
            this.pnCareer.Controls.Add(this.label77);
            this.pnCareer.Controls.Add(this.cbgrade);
            this.pnCareer.Controls.Add(this.cbschooltype);
            this.pnCareer.Controls.Add(this.label50);
            this.pnCareer.Controls.Add(this.cbcareer);
            this.pnCareer.Controls.Add(this.tbcareervalue);
            this.pnCareer.Name = "pnCareer";
            // 
            // lbRetcareer
            // 
            resources.ApplyResources(this.lbRetcareer, "lbRetcareer");
            this.lbRetcareer.Name = "lbRetcareer";
            // 
            // lpRetirement
            // 
            this.lpRetirement.BackColor = System.Drawing.Color.Transparent;
            this.lpRetirement.DisplayOffset = 0;
            resources.ApplyResources(this.lpRetirement, "lpRetirement");
            this.lpRetirement.Maximum = 10;
            this.lpRetirement.Name = "lpRetirement";
            this.lpRetirement.NumberFormat = "N0";
            this.lpRetirement.NumberOffset = 0;
            this.lpRetirement.NumberScale = 1;
            this.lpRetirement.SelectedColor = System.Drawing.Color.YellowGreen;
            this.lpRetirement.TokenCount = 10;
            this.lpRetirement.UnselectedColor = System.Drawing.Color.Black;
            this.lpRetirement.Value = 10;
            this.lpRetirement.Changed += new System.EventHandler(this.ChangedCareer);
            // 
            // cbRetirement
            // 
            resources.ApplyResources(this.cbRetirement, "cbRetirement");
            this.cbRetirement.Name = "cbRetirement";
            this.cbRetirement.SelectedIndexChanged += new System.EventHandler(this.cbRetirement_SelectedIndexChanged);
            // 
            // tbpension
            // 
            this.tbpension.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbpension, "tbpension");
            this.tbpension.Name = "tbpension";
            this.tbpension.TextChanged += new System.EventHandler(this.ChangedCareer);
            // 
            // lbpension
            // 
            resources.ApplyResources(this.lbpension, "lbpension");
            this.lbpension.Name = "lbpension";
            // 
            // lbaccholidays
            // 
            resources.ApplyResources(this.lbaccholidays, "lbaccholidays");
            this.lbaccholidays.Name = "lbaccholidays";
            // 
            // tbaccholidays
            // 
            this.tbaccholidays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbaccholidays, "tbaccholidays");
            this.tbaccholidays.Name = "tbaccholidays";
            this.tbaccholidays.TextChanged += new System.EventHandler(this.ChangedCareer);
            // 
            // pbAspBliz
            // 
            this.pbAspBliz.BackColor = System.Drawing.Color.Transparent;
            this.pbAspBliz.DisplayOffset = 0;
            resources.ApplyResources(this.pbAspBliz, "pbAspBliz");
            this.pbAspBliz.Maximum = 1200;
            this.pbAspBliz.Name = "pbAspBliz";
            this.pbAspBliz.NumberFormat = "N0";
            this.pbAspBliz.NumberOffset = 0;
            this.pbAspBliz.NumberScale = 1;
            this.pbAspBliz.SelectedColor = System.Drawing.Color.YellowGreen;
            this.pbAspBliz.TokenCount = 21;
            this.pbAspBliz.UnselectedColor = System.Drawing.Color.Black;
            this.pbAspBliz.Value = 10;
            this.pbAspBliz.Changed += new System.EventHandler(this.ChangedCareer);
            // 
            // label60
            // 
            resources.ApplyResources(this.label60, "label60");
            this.label60.Name = "label60";
            // 
            // cbaspiration
            // 
            resources.ApplyResources(this.cbaspiration, "cbaspiration");
            this.cbaspiration.Name = "cbaspiration";
            this.cbaspiration.SelectedValueChanged += new System.EventHandler(this.ChangedAspiration);
            // 
            // pbAspCur
            // 
            this.pbAspCur.BackColor = System.Drawing.Color.Transparent;
            this.pbAspCur.DisplayOffset = 0;
            resources.ApplyResources(this.pbAspCur, "pbAspCur");
            this.pbAspCur.Maximum = 1200;
            this.pbAspCur.Name = "pbAspCur";
            this.pbAspCur.NumberFormat = "N0";
            this.pbAspCur.NumberOffset = -600;
            this.pbAspCur.NumberScale = 1;
            this.pbAspCur.SelectedColor = System.Drawing.Color.YellowGreen;
            this.pbAspCur.TokenCount = 21;
            this.pbAspCur.UnselectedColor = System.Drawing.Color.Black;
            this.pbAspCur.Value = 0;
            this.pbAspCur.Changed += new System.EventHandler(this.ChangedCareer);
            // 
            // label46
            // 
            resources.ApplyResources(this.label46, "label46");
            this.label46.Name = "label46";
            // 
            // tblifelinescore
            // 
            this.tblifelinescore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tblifelinescore, "tblifelinescore");
            this.tblifelinescore.Name = "tblifelinescore";
            this.tblifelinescore.TextChanged += new System.EventHandler(this.ChangedCareer);
            // 
            // pbCareerPerformance
            // 
            this.pbCareerPerformance.BackColor = System.Drawing.Color.Transparent;
            this.pbCareerPerformance.DisplayOffset = 0;
            resources.ApplyResources(this.pbCareerPerformance, "pbCareerPerformance");
            this.pbCareerPerformance.Maximum = 1000;
            this.pbCareerPerformance.Name = "pbCareerPerformance";
            this.pbCareerPerformance.NumberFormat = "N0";
            this.pbCareerPerformance.NumberOffset = 0;
            this.pbCareerPerformance.NumberScale = 1;
            this.pbCareerPerformance.SelectedColor = System.Drawing.Color.YellowGreen;
            this.pbCareerPerformance.TokenCount = 20;
            this.pbCareerPerformance.UnselectedColor = System.Drawing.Color.Black;
            this.pbCareerPerformance.Value = 10;
            this.pbCareerPerformance.Changed += new System.EventHandler(this.ChangedCareer);
            // 
            // pbCareerLevel
            // 
            this.pbCareerLevel.BackColor = System.Drawing.Color.Transparent;
            this.pbCareerLevel.DisplayOffset = 0;
            resources.ApplyResources(this.pbCareerLevel, "pbCareerLevel");
            this.pbCareerLevel.Maximum = 10;
            this.pbCareerLevel.Name = "pbCareerLevel";
            this.pbCareerLevel.NumberFormat = "N0";
            this.pbCareerLevel.NumberOffset = 0;
            this.pbCareerLevel.NumberScale = 1;
            this.pbCareerLevel.SelectedColor = System.Drawing.Color.YellowGreen;
            this.pbCareerLevel.TokenCount = 10;
            this.pbCareerLevel.UnselectedColor = System.Drawing.Color.Black;
            this.pbCareerLevel.Value = 10;
            this.pbCareerLevel.Changed += new System.EventHandler(this.ChangedCareer);
            // 
            // label78
            // 
            resources.ApplyResources(this.label78, "label78");
            this.label78.Name = "label78";
            // 
            // tbschooltype
            // 
            this.tbschooltype.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbschooltype, "tbschooltype");
            this.tbschooltype.Name = "tbschooltype";
            this.tbschooltype.TextChanged += new System.EventHandler(this.ChangedCareer);
            // 
            // label77
            // 
            resources.ApplyResources(this.label77, "label77");
            this.label77.Name = "label77";
            // 
            // cbgrade
            // 
            resources.ApplyResources(this.cbgrade, "cbgrade");
            this.cbgrade.Name = "cbgrade";
            this.cbgrade.SelectedValueChanged += new System.EventHandler(this.ChangedCareer);
            // 
            // cbschooltype
            // 
            resources.ApplyResources(this.cbschooltype, "cbschooltype");
            this.cbschooltype.Name = "cbschooltype";
            this.cbschooltype.SelectedIndexChanged += new System.EventHandler(this.cbschooltype_SelectedIndexChanged);
            // 
            // label50
            // 
            resources.ApplyResources(this.label50, "label50");
            this.label50.Name = "label50";
            // 
            // cbcareer
            // 
            resources.ApplyResources(this.cbcareer, "cbcareer");
            this.cbcareer.Name = "cbcareer";
            this.cbcareer.SelectedIndexChanged += new System.EventHandler(this.cbcareer_SelectedIndexChanged);
            // 
            // tbcareervalue
            // 
            this.tbcareervalue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbcareervalue, "tbcareervalue");
            this.tbcareervalue.Name = "tbcareervalue";
            this.tbcareervalue.TextChanged += new System.EventHandler(this.ChangedCareer);
            // 
            // pnInt
            // 
            resources.ApplyResources(this.pnInt, "pnInt");
            this.pnInt.BackColor = System.Drawing.Color.Transparent;
            this.pnInt.Controls.Add(this.pnSimInt);
            this.pnInt.Controls.Add(this.pnPetInt);
            this.pnInt.Name = "pnInt";
            this.pnInt.VisibleChanged += new System.EventHandler(this.pnInt_VisibleChanged);
            // 
            // pnSimInt
            // 
            this.pnSimInt.BackColor = System.Drawing.Color.Transparent;
            this.pnSimInt.Controls.Add(this.pbSciFi);
            this.pnSimInt.Controls.Add(this.pbTravel);
            this.pnSimInt.Controls.Add(this.pbToys);
            this.pnSimInt.Controls.Add(this.pbEnvironment);
            this.pnSimInt.Controls.Add(this.pbSchool);
            this.pnSimInt.Controls.Add(this.pbParanormal);
            this.pnSimInt.Controls.Add(this.pbAnimals);
            this.pnSimInt.Controls.Add(this.pbEntertainment);
            this.pnSimInt.Controls.Add(this.pbWeather);
            this.pnSimInt.Controls.Add(this.pbCulture);
            this.pnSimInt.Controls.Add(this.pbWork);
            this.pnSimInt.Controls.Add(this.pbMoney);
            this.pnSimInt.Controls.Add(this.pbPolitics);
            this.pnSimInt.Controls.Add(this.pbCrime);
            this.pnSimInt.Controls.Add(this.pbFood);
            this.pnSimInt.Controls.Add(this.pbSports);
            this.pnSimInt.Controls.Add(this.pbHealth);
            this.pnSimInt.Controls.Add(this.pbFashion);
            resources.ApplyResources(this.pnSimInt, "pnSimInt");
            this.pnSimInt.Name = "pnSimInt";
            this.pnSimInt.VisibleChanged += new System.EventHandler(this.pnSimInt_VisibleChanged);
            // 
            // pbSciFi
            // 
            this.pbSciFi.BackColor = System.Drawing.Color.Transparent;
            this.pbSciFi.DisplayOffset = 0;
            resources.ApplyResources(this.pbSciFi, "pbSciFi");
            this.pbSciFi.Maximum = 1000;
            this.pbSciFi.Name = "pbSciFi";
            this.pbSciFi.NumberFormat = "N1";
            this.pbSciFi.NumberOffset = 0;
            this.pbSciFi.NumberScale = 0.01;
            this.pbSciFi.SelectedColor = System.Drawing.Color.Lime;
            this.pbSciFi.TokenCount = 10;
            this.pbSciFi.UnselectedColor = System.Drawing.Color.Black;
            this.pbSciFi.Value = 500;
            this.pbSciFi.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbTravel
            // 
            this.pbTravel.BackColor = System.Drawing.Color.Transparent;
            this.pbTravel.DisplayOffset = 0;
            resources.ApplyResources(this.pbTravel, "pbTravel");
            this.pbTravel.Maximum = 1000;
            this.pbTravel.Name = "pbTravel";
            this.pbTravel.NumberFormat = "N1";
            this.pbTravel.NumberOffset = 0;
            this.pbTravel.NumberScale = 0.01;
            this.pbTravel.SelectedColor = System.Drawing.Color.Lime;
            this.pbTravel.TokenCount = 10;
            this.pbTravel.UnselectedColor = System.Drawing.Color.Black;
            this.pbTravel.Value = 500;
            this.pbTravel.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbToys
            // 
            this.pbToys.BackColor = System.Drawing.Color.Transparent;
            this.pbToys.DisplayOffset = 0;
            resources.ApplyResources(this.pbToys, "pbToys");
            this.pbToys.Maximum = 1000;
            this.pbToys.Name = "pbToys";
            this.pbToys.NumberFormat = "N1";
            this.pbToys.NumberOffset = 0;
            this.pbToys.NumberScale = 0.01;
            this.pbToys.SelectedColor = System.Drawing.Color.Lime;
            this.pbToys.TokenCount = 10;
            this.pbToys.UnselectedColor = System.Drawing.Color.Black;
            this.pbToys.Value = 500;
            this.pbToys.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbEnvironment
            // 
            this.pbEnvironment.BackColor = System.Drawing.Color.Transparent;
            this.pbEnvironment.DisplayOffset = 0;
            resources.ApplyResources(this.pbEnvironment, "pbEnvironment");
            this.pbEnvironment.Maximum = 1000;
            this.pbEnvironment.Name = "pbEnvironment";
            this.pbEnvironment.NumberFormat = "N1";
            this.pbEnvironment.NumberOffset = 0;
            this.pbEnvironment.NumberScale = 0.01;
            this.pbEnvironment.SelectedColor = System.Drawing.Color.Lime;
            this.pbEnvironment.TokenCount = 10;
            this.pbEnvironment.UnselectedColor = System.Drawing.Color.Black;
            this.pbEnvironment.Value = 500;
            this.pbEnvironment.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbSchool
            // 
            this.pbSchool.BackColor = System.Drawing.Color.Transparent;
            this.pbSchool.DisplayOffset = 0;
            resources.ApplyResources(this.pbSchool, "pbSchool");
            this.pbSchool.Maximum = 1000;
            this.pbSchool.Name = "pbSchool";
            this.pbSchool.NumberFormat = "N1";
            this.pbSchool.NumberOffset = 0;
            this.pbSchool.NumberScale = 0.01;
            this.pbSchool.SelectedColor = System.Drawing.Color.Lime;
            this.pbSchool.TokenCount = 10;
            this.pbSchool.UnselectedColor = System.Drawing.Color.Black;
            this.pbSchool.Value = 500;
            this.pbSchool.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbParanormal
            // 
            this.pbParanormal.BackColor = System.Drawing.Color.Transparent;
            this.pbParanormal.DisplayOffset = 0;
            resources.ApplyResources(this.pbParanormal, "pbParanormal");
            this.pbParanormal.Maximum = 1000;
            this.pbParanormal.Name = "pbParanormal";
            this.pbParanormal.NumberFormat = "N1";
            this.pbParanormal.NumberOffset = 0;
            this.pbParanormal.NumberScale = 0.01;
            this.pbParanormal.SelectedColor = System.Drawing.Color.Lime;
            this.pbParanormal.TokenCount = 10;
            this.pbParanormal.UnselectedColor = System.Drawing.Color.Black;
            this.pbParanormal.Value = 500;
            this.pbParanormal.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbAnimals
            // 
            this.pbAnimals.BackColor = System.Drawing.Color.Transparent;
            this.pbAnimals.DisplayOffset = 0;
            resources.ApplyResources(this.pbAnimals, "pbAnimals");
            this.pbAnimals.Maximum = 1000;
            this.pbAnimals.Name = "pbAnimals";
            this.pbAnimals.NumberFormat = "N1";
            this.pbAnimals.NumberOffset = 0;
            this.pbAnimals.NumberScale = 0.01;
            this.pbAnimals.SelectedColor = System.Drawing.Color.Lime;
            this.pbAnimals.TokenCount = 10;
            this.pbAnimals.UnselectedColor = System.Drawing.Color.Black;
            this.pbAnimals.Value = 500;
            this.pbAnimals.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbEntertainment
            // 
            this.pbEntertainment.BackColor = System.Drawing.Color.Transparent;
            this.pbEntertainment.DisplayOffset = 0;
            resources.ApplyResources(this.pbEntertainment, "pbEntertainment");
            this.pbEntertainment.Maximum = 1000;
            this.pbEntertainment.Name = "pbEntertainment";
            this.pbEntertainment.NumberFormat = "N1";
            this.pbEntertainment.NumberOffset = 0;
            this.pbEntertainment.NumberScale = 0.01;
            this.pbEntertainment.SelectedColor = System.Drawing.Color.Lime;
            this.pbEntertainment.TokenCount = 10;
            this.pbEntertainment.UnselectedColor = System.Drawing.Color.Black;
            this.pbEntertainment.Value = 500;
            this.pbEntertainment.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbWeather
            // 
            this.pbWeather.BackColor = System.Drawing.Color.Transparent;
            this.pbWeather.DisplayOffset = 0;
            resources.ApplyResources(this.pbWeather, "pbWeather");
            this.pbWeather.Maximum = 1000;
            this.pbWeather.Name = "pbWeather";
            this.pbWeather.NumberFormat = "N1";
            this.pbWeather.NumberOffset = 0;
            this.pbWeather.NumberScale = 0.01;
            this.pbWeather.SelectedColor = System.Drawing.Color.Lime;
            this.pbWeather.TokenCount = 10;
            this.pbWeather.UnselectedColor = System.Drawing.Color.Black;
            this.pbWeather.Value = 500;
            this.pbWeather.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbCulture
            // 
            this.pbCulture.BackColor = System.Drawing.Color.Transparent;
            this.pbCulture.DisplayOffset = 0;
            resources.ApplyResources(this.pbCulture, "pbCulture");
            this.pbCulture.Maximum = 1000;
            this.pbCulture.Name = "pbCulture";
            this.pbCulture.NumberFormat = "N1";
            this.pbCulture.NumberOffset = 0;
            this.pbCulture.NumberScale = 0.01;
            this.pbCulture.SelectedColor = System.Drawing.Color.Lime;
            this.pbCulture.TokenCount = 10;
            this.pbCulture.UnselectedColor = System.Drawing.Color.Black;
            this.pbCulture.Value = 500;
            this.pbCulture.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbWork
            // 
            this.pbWork.BackColor = System.Drawing.Color.Transparent;
            this.pbWork.DisplayOffset = 0;
            resources.ApplyResources(this.pbWork, "pbWork");
            this.pbWork.Maximum = 1000;
            this.pbWork.Name = "pbWork";
            this.pbWork.NumberFormat = "N1";
            this.pbWork.NumberOffset = 0;
            this.pbWork.NumberScale = 0.01;
            this.pbWork.SelectedColor = System.Drawing.Color.Lime;
            this.pbWork.TokenCount = 10;
            this.pbWork.UnselectedColor = System.Drawing.Color.Black;
            this.pbWork.Value = 500;
            this.pbWork.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbMoney
            // 
            this.pbMoney.BackColor = System.Drawing.Color.Transparent;
            this.pbMoney.DisplayOffset = 0;
            resources.ApplyResources(this.pbMoney, "pbMoney");
            this.pbMoney.Maximum = 1000;
            this.pbMoney.Name = "pbMoney";
            this.pbMoney.NumberFormat = "N1";
            this.pbMoney.NumberOffset = 0;
            this.pbMoney.NumberScale = 0.01;
            this.pbMoney.SelectedColor = System.Drawing.Color.Lime;
            this.pbMoney.TokenCount = 10;
            this.pbMoney.UnselectedColor = System.Drawing.Color.Black;
            this.pbMoney.Value = 500;
            this.pbMoney.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbPolitics
            // 
            this.pbPolitics.BackColor = System.Drawing.Color.Transparent;
            this.pbPolitics.DisplayOffset = 0;
            resources.ApplyResources(this.pbPolitics, "pbPolitics");
            this.pbPolitics.Maximum = 1000;
            this.pbPolitics.Name = "pbPolitics";
            this.pbPolitics.NumberFormat = "N1";
            this.pbPolitics.NumberOffset = 0;
            this.pbPolitics.NumberScale = 0.01;
            this.pbPolitics.SelectedColor = System.Drawing.Color.Lime;
            this.pbPolitics.TokenCount = 10;
            this.pbPolitics.UnselectedColor = System.Drawing.Color.Black;
            this.pbPolitics.Value = 500;
            this.pbPolitics.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbCrime
            // 
            this.pbCrime.BackColor = System.Drawing.Color.Transparent;
            this.pbCrime.DisplayOffset = 0;
            resources.ApplyResources(this.pbCrime, "pbCrime");
            this.pbCrime.Maximum = 1000;
            this.pbCrime.Name = "pbCrime";
            this.pbCrime.NumberFormat = "N1";
            this.pbCrime.NumberOffset = 0;
            this.pbCrime.NumberScale = 0.01;
            this.pbCrime.SelectedColor = System.Drawing.Color.Lime;
            this.pbCrime.TokenCount = 10;
            this.pbCrime.UnselectedColor = System.Drawing.Color.Black;
            this.pbCrime.Value = 500;
            this.pbCrime.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbFood
            // 
            this.pbFood.BackColor = System.Drawing.Color.Transparent;
            this.pbFood.DisplayOffset = 0;
            resources.ApplyResources(this.pbFood, "pbFood");
            this.pbFood.Maximum = 1000;
            this.pbFood.Name = "pbFood";
            this.pbFood.NumberFormat = "N1";
            this.pbFood.NumberOffset = 0;
            this.pbFood.NumberScale = 0.01;
            this.pbFood.SelectedColor = System.Drawing.Color.Lime;
            this.pbFood.TokenCount = 10;
            this.pbFood.UnselectedColor = System.Drawing.Color.Black;
            this.pbFood.Value = 500;
            this.pbFood.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbSports
            // 
            this.pbSports.BackColor = System.Drawing.Color.Transparent;
            this.pbSports.DisplayOffset = 0;
            resources.ApplyResources(this.pbSports, "pbSports");
            this.pbSports.Maximum = 1000;
            this.pbSports.Name = "pbSports";
            this.pbSports.NumberFormat = "N1";
            this.pbSports.NumberOffset = 0;
            this.pbSports.NumberScale = 0.01;
            this.pbSports.SelectedColor = System.Drawing.Color.Lime;
            this.pbSports.TokenCount = 10;
            this.pbSports.UnselectedColor = System.Drawing.Color.Black;
            this.pbSports.Value = 500;
            this.pbSports.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbHealth
            // 
            this.pbHealth.BackColor = System.Drawing.Color.Transparent;
            this.pbHealth.DisplayOffset = 0;
            resources.ApplyResources(this.pbHealth, "pbHealth");
            this.pbHealth.Maximum = 1000;
            this.pbHealth.Name = "pbHealth";
            this.pbHealth.NumberFormat = "N1";
            this.pbHealth.NumberOffset = 0;
            this.pbHealth.NumberScale = 0.01;
            this.pbHealth.SelectedColor = System.Drawing.Color.Lime;
            this.pbHealth.TokenCount = 10;
            this.pbHealth.UnselectedColor = System.Drawing.Color.Black;
            this.pbHealth.Value = 500;
            this.pbHealth.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pbFashion
            // 
            this.pbFashion.BackColor = System.Drawing.Color.Transparent;
            this.pbFashion.DisplayOffset = 0;
            resources.ApplyResources(this.pbFashion, "pbFashion");
            this.pbFashion.Maximum = 1000;
            this.pbFashion.Name = "pbFashion";
            this.pbFashion.NumberFormat = "N1";
            this.pbFashion.NumberOffset = 0;
            this.pbFashion.NumberScale = 0.01;
            this.pbFashion.SelectedColor = System.Drawing.Color.Lime;
            this.pbFashion.TokenCount = 10;
            this.pbFashion.UnselectedColor = System.Drawing.Color.Black;
            this.pbFashion.Value = 500;
            this.pbFashion.Changed += new System.EventHandler(this.ChangedInt);
            // 
            // pnRel
            // 
            resources.ApplyResources(this.pnRel, "pnRel");
            this.pnRel.BackColor = System.Drawing.Color.Transparent;
            this.pnRel.Controls.Add(this.lv);
            this.pnRel.Controls.Add(this.panel3);
            this.pnRel.Name = "pnRel";
            this.pnRel.VisibleChanged += new System.EventHandler(this.pnRel_VisibleChanged);
            // 
            // lv
            // 
            this.lv.ContextMenuStrip = this.miRel;
            resources.ApplyResources(this.lv, "lv");
            this.lv.Name = "lv";
            this.lv.Package = null;
            this.lv.RightClickSelect = true;
            this.lv.SelectedElement = null;
            this.lv.SelectedSim = null;
            this.lv.ShowNotRelatedSims = false;
            this.lv.ShowRelatedSims = true;
            this.lv.Sim = null;
            this.lv.SimDetails = false;
            this.lv.TileColumns = new int[] {
        1};
            this.lv.SelectedSimChanged += new SimPe.PackedFiles.Wrapper.SimPoolControl.SelectedSimHandler(this.lv_SelectedSimChanged);
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.srcTb);
            this.panel3.Controls.Add(this.dstTb);
            this.panel3.Name = "panel3";
            // 
            // srcTb
            // 
            resources.ApplyResources(this.srcTb, "srcTb");
            this.srcTb.BackColor = System.Drawing.Color.Transparent;
            this.srcTb.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.srcTb.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.srcTb.IconLocation = new System.Drawing.Point(4, 6);
            this.srcTb.IconSize = new System.Drawing.Size(48, 32);
            this.srcTb.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.srcTb.Name = "srcTb";
            this.srcTb.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            // 
            // dstTb
            // 
            resources.ApplyResources(this.dstTb, "dstTb");
            this.dstTb.BackColor = System.Drawing.Color.Transparent;
            this.dstTb.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.dstTb.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dstTb.IconLocation = new System.Drawing.Point(4, 6);
            this.dstTb.IconSize = new System.Drawing.Size(48, 32);
            this.dstTb.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.dstTb.Name = "dstTb";
            this.dstTb.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            // 
            // pnMisc
            // 
            resources.ApplyResources(this.pnMisc, "pnMisc");
            this.pnMisc.BackColor = System.Drawing.Color.Transparent;
            this.pnMisc.Controls.Add(this.tbMotiveDec);
            this.pnMisc.Controls.Add(this.tbpersonflags);
            this.pnMisc.Controls.Add(this.bTaskBox3);
            this.pnMisc.Controls.Add(this.bTaskBox2);
            this.pnMisc.Controls.Add(this.bTaskBox1);
            this.pnMisc.Name = "pnMisc";
            // 
            // tbMotiveDec
            // 
            this.tbMotiveDec.BackColor = System.Drawing.Color.Transparent;
            this.tbMotiveDec.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.tbMotiveDec.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbMotiveDec.Controls.Add(this.lbdecScratc);
            this.tbMotiveDec.Controls.Add(this.tbdecScratc);
            this.tbMotiveDec.Controls.Add(this.lbdecAmor);
            this.tbMotiveDec.Controls.Add(this.tbdecAmor);
            this.tbMotiveDec.Controls.Add(this.lbdecFun);
            this.tbMotiveDec.Controls.Add(this.tbdecFun);
            this.tbMotiveDec.Controls.Add(this.lbdecShop);
            this.tbMotiveDec.Controls.Add(this.tbdecShop);
            this.tbMotiveDec.Controls.Add(this.lbdecSocial);
            this.tbMotiveDec.Controls.Add(this.tbdecSocial);
            this.tbMotiveDec.Controls.Add(this.lbdecHygiene);
            this.tbMotiveDec.Controls.Add(this.tbdecHygiene);
            this.tbMotiveDec.Controls.Add(this.tbdecEnergy);
            this.tbMotiveDec.Controls.Add(this.lbdecEnergy);
            this.tbMotiveDec.Controls.Add(this.tbdecBladder);
            this.tbMotiveDec.Controls.Add(this.lbdecBladder);
            this.tbMotiveDec.Controls.Add(this.tbdecComfort);
            this.tbMotiveDec.Controls.Add(this.lbdecComfort);
            this.tbMotiveDec.Controls.Add(this.tbdecHunger);
            this.tbMotiveDec.Controls.Add(this.lbdecHunger);
            resources.ApplyResources(this.tbMotiveDec, "tbMotiveDec");
            this.tbMotiveDec.IconLocation = new System.Drawing.Point(4, 0);
            this.tbMotiveDec.IconSize = new System.Drawing.Size(32, 32);
            this.tbMotiveDec.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.tbMotiveDec.Name = "tbMotiveDec";
            this.tbMotiveDec.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.toolTip1.SetToolTip(this.tbMotiveDec, resources.GetString("tbMotiveDec.ToolTip"));
            // 
            // lbdecScratc
            // 
            resources.ApplyResources(this.lbdecScratc, "lbdecScratc");
            this.lbdecScratc.Name = "lbdecScratc";
            // 
            // tbdecScratc
            // 
            this.tbdecScratc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbdecScratc, "tbdecScratc");
            this.tbdecScratc.Name = "tbdecScratc";
            // 
            // lbdecAmor
            // 
            resources.ApplyResources(this.lbdecAmor, "lbdecAmor");
            this.lbdecAmor.Name = "lbdecAmor";
            // 
            // tbdecAmor
            // 
            this.tbdecAmor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbdecAmor, "tbdecAmor");
            this.tbdecAmor.Name = "tbdecAmor";
            this.tbdecAmor.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // lbdecFun
            // 
            resources.ApplyResources(this.lbdecFun, "lbdecFun");
            this.lbdecFun.Name = "lbdecFun";
            // 
            // tbdecFun
            // 
            this.tbdecFun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbdecFun, "tbdecFun");
            this.tbdecFun.Name = "tbdecFun";
            this.tbdecFun.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // lbdecShop
            // 
            resources.ApplyResources(this.lbdecShop, "lbdecShop");
            this.lbdecShop.Name = "lbdecShop";
            // 
            // tbdecShop
            // 
            this.tbdecShop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbdecShop, "tbdecShop");
            this.tbdecShop.Name = "tbdecShop";
            this.tbdecShop.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // lbdecSocial
            // 
            resources.ApplyResources(this.lbdecSocial, "lbdecSocial");
            this.lbdecSocial.Name = "lbdecSocial";
            // 
            // tbdecSocial
            // 
            this.tbdecSocial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbdecSocial, "tbdecSocial");
            this.tbdecSocial.Name = "tbdecSocial";
            this.tbdecSocial.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // lbdecHygiene
            // 
            resources.ApplyResources(this.lbdecHygiene, "lbdecHygiene");
            this.lbdecHygiene.Name = "lbdecHygiene";
            // 
            // tbdecHygiene
            // 
            this.tbdecHygiene.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbdecHygiene, "tbdecHygiene");
            this.tbdecHygiene.Name = "tbdecHygiene";
            this.tbdecHygiene.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // tbdecEnergy
            // 
            this.tbdecEnergy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbdecEnergy, "tbdecEnergy");
            this.tbdecEnergy.Name = "tbdecEnergy";
            this.tbdecEnergy.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // lbdecEnergy
            // 
            resources.ApplyResources(this.lbdecEnergy, "lbdecEnergy");
            this.lbdecEnergy.Name = "lbdecEnergy";
            // 
            // tbdecBladder
            // 
            this.tbdecBladder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbdecBladder, "tbdecBladder");
            this.tbdecBladder.Name = "tbdecBladder";
            this.tbdecBladder.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // lbdecBladder
            // 
            resources.ApplyResources(this.lbdecBladder, "lbdecBladder");
            this.lbdecBladder.Name = "lbdecBladder";
            // 
            // tbdecComfort
            // 
            this.tbdecComfort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbdecComfort, "tbdecComfort");
            this.tbdecComfort.Name = "tbdecComfort";
            this.tbdecComfort.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // lbdecComfort
            // 
            resources.ApplyResources(this.lbdecComfort, "lbdecComfort");
            this.lbdecComfort.Name = "lbdecComfort";
            // 
            // tbdecHunger
            // 
            this.tbdecHunger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbdecHunger, "tbdecHunger");
            this.tbdecHunger.Name = "tbdecHunger";
            this.tbdecHunger.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // lbdecHunger
            // 
            resources.ApplyResources(this.lbdecHunger, "lbdecHunger");
            this.lbdecHunger.Name = "lbdecHunger";
            // 
            // tbpersonflags
            // 
            this.tbpersonflags.BackColor = System.Drawing.Color.Transparent;
            this.tbpersonflags.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.tbpersonflags.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbpersonflags.Controls.Add(this.cbpfwitch);
            this.tbpersonflags.Controls.Add(this.cbpfroomy);
            this.tbpersonflags.Controls.Add(this.cbpfBigf);
            this.tbpersonflags.Controls.Add(this.cbpfPlant);
            this.tbpersonflags.Controls.Add(this.cbpfrunaw);
            this.tbpersonflags.Controls.Add(this.cbpflyact);
            this.tbpersonflags.Controls.Add(this.cbpflycar);
            this.tbpersonflags.Controls.Add(this.cbpfwants);
            this.tbpersonflags.Controls.Add(this.cbpfvsmoke);
            this.tbpersonflags.Controls.Add(this.cbpfvamp);
            this.tbpersonflags.Controls.Add(this.cbpfperma);
            this.tbpersonflags.Controls.Add(this.cbpfZomb);
            resources.ApplyResources(this.tbpersonflags, "tbpersonflags");
            this.tbpersonflags.IconLocation = new System.Drawing.Point(4, 0);
            this.tbpersonflags.IconSize = new System.Drawing.Size(32, 32);
            this.tbpersonflags.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.tbpersonflags.Name = "tbpersonflags";
            this.tbpersonflags.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            // 
            // cbpfwitch
            // 
            resources.ApplyResources(this.cbpfwitch, "cbpfwitch");
            this.cbpfwitch.Name = "cbpfwitch";
            this.cbpfwitch.UseVisualStyleBackColor = true;
            this.cbpfwitch.CheckedChanged += new System.EventHandler(this.cbdataflag1_CheckedChanged);
            // 
            // cbpfroomy
            // 
            resources.ApplyResources(this.cbpfroomy, "cbpfroomy");
            this.cbpfroomy.Name = "cbpfroomy";
            this.cbpfroomy.UseVisualStyleBackColor = true;
            this.cbpfroomy.CheckedChanged += new System.EventHandler(this.cbdataflag1_CheckedChanged);
            // 
            // cbpfBigf
            // 
            resources.ApplyResources(this.cbpfBigf, "cbpfBigf");
            this.cbpfBigf.Name = "cbpfBigf";
            this.cbpfBigf.UseVisualStyleBackColor = true;
            this.cbpfBigf.CheckedChanged += new System.EventHandler(this.cbdataflag1_CheckedChanged);
            // 
            // cbpfPlant
            // 
            resources.ApplyResources(this.cbpfPlant, "cbpfPlant");
            this.cbpfPlant.Name = "cbpfPlant";
            this.cbpfPlant.UseVisualStyleBackColor = true;
            this.cbpfPlant.CheckedChanged += new System.EventHandler(this.cbdataflag1_CheckedChanged);
            // 
            // cbpfrunaw
            // 
            resources.ApplyResources(this.cbpfrunaw, "cbpfrunaw");
            this.cbpfrunaw.Name = "cbpfrunaw";
            this.toolTip1.SetToolTip(this.cbpfrunaw, resources.GetString("cbpfrunaw.ToolTip"));
            this.cbpfrunaw.UseVisualStyleBackColor = true;
            this.cbpfrunaw.CheckedChanged += new System.EventHandler(this.cbdataflag1_CheckedChanged);
            // 
            // cbpflyact
            // 
            resources.ApplyResources(this.cbpflyact, "cbpflyact");
            this.cbpflyact.Name = "cbpflyact";
            this.cbpflyact.UseVisualStyleBackColor = true;
            this.cbpflyact.CheckedChanged += new System.EventHandler(this.cbdataflag1_CheckedChanged);
            // 
            // cbpflycar
            // 
            resources.ApplyResources(this.cbpflycar, "cbpflycar");
            this.cbpflycar.Name = "cbpflycar";
            this.cbpflycar.UseVisualStyleBackColor = true;
            this.cbpflycar.CheckedChanged += new System.EventHandler(this.cbdataflag1_CheckedChanged);
            // 
            // cbpfwants
            // 
            resources.ApplyResources(this.cbpfwants, "cbpfwants");
            this.cbpfwants.Name = "cbpfwants";
            this.cbpfwants.UseVisualStyleBackColor = true;
            this.cbpfwants.CheckedChanged += new System.EventHandler(this.cbdataflag1_CheckedChanged);
            // 
            // cbpfvsmoke
            // 
            resources.ApplyResources(this.cbpfvsmoke, "cbpfvsmoke");
            this.cbpfvsmoke.Name = "cbpfvsmoke";
            this.cbpfvsmoke.UseVisualStyleBackColor = true;
            this.cbpfvsmoke.CheckedChanged += new System.EventHandler(this.cbdataflag1_CheckedChanged);
            // 
            // cbpfvamp
            // 
            resources.ApplyResources(this.cbpfvamp, "cbpfvamp");
            this.cbpfvamp.Name = "cbpfvamp";
            this.cbpfvamp.UseVisualStyleBackColor = true;
            this.cbpfvamp.CheckedChanged += new System.EventHandler(this.cbdataflag1_CheckedChanged);
            // 
            // cbpfperma
            // 
            resources.ApplyResources(this.cbpfperma, "cbpfperma");
            this.cbpfperma.Name = "cbpfperma";
            this.cbpfperma.UseVisualStyleBackColor = true;
            this.cbpfperma.CheckedChanged += new System.EventHandler(this.cbdataflag1_CheckedChanged);
            // 
            // cbpfZomb
            // 
            resources.ApplyResources(this.cbpfZomb, "cbpfZomb");
            this.cbpfZomb.Name = "cbpfZomb";
            this.cbpfZomb.UseVisualStyleBackColor = true;
            this.cbpfZomb.CheckedChanged += new System.EventHandler(this.cbdataflag1_CheckedChanged);
            // 
            // bTaskBox3
            // 
            this.bTaskBox3.BackColor = System.Drawing.Color.Transparent;
            this.bTaskBox3.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.bTaskBox3.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bTaskBox3.Controls.Add(this.label3);
            this.bTaskBox3.Controls.Add(this.tbstatmot);
            this.bTaskBox3.Controls.Add(this.label96);
            this.bTaskBox3.Controls.Add(this.tbunlinked);
            this.bTaskBox3.Controls.Add(this.label95);
            this.bTaskBox3.Controls.Add(this.tbagedur);
            this.bTaskBox3.Controls.Add(this.tbprevdays);
            this.bTaskBox3.Controls.Add(this.label94);
            this.bTaskBox3.Controls.Add(this.tbvoice);
            this.bTaskBox3.Controls.Add(this.label90);
            this.bTaskBox3.Controls.Add(this.tbnpc);
            this.bTaskBox3.Controls.Add(this.label87);
            this.bTaskBox3.Controls.Add(this.tbautonomy);
            this.bTaskBox3.Controls.Add(this.label86);
            resources.ApplyResources(this.bTaskBox3, "bTaskBox3");
            this.bTaskBox3.IconLocation = new System.Drawing.Point(4, 0);
            this.bTaskBox3.IconSize = new System.Drawing.Size(32, 32);
            this.bTaskBox3.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.bTaskBox3.Name = "bTaskBox3";
            this.bTaskBox3.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tbstatmot
            // 
            this.tbstatmot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbstatmot, "tbstatmot");
            this.tbstatmot.Name = "tbstatmot";
            this.tbstatmot.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // label96
            // 
            resources.ApplyResources(this.label96, "label96");
            this.label96.Name = "label96";
            // 
            // tbunlinked
            // 
            this.tbunlinked.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbunlinked, "tbunlinked");
            this.tbunlinked.Name = "tbunlinked";
            this.tbunlinked.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // label95
            // 
            resources.ApplyResources(this.label95, "label95");
            this.label95.Name = "label95";
            // 
            // tbagedur
            // 
            this.tbagedur.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbagedur, "tbagedur");
            this.tbagedur.Name = "tbagedur";
            this.tbagedur.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // tbprevdays
            // 
            this.tbprevdays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbprevdays, "tbprevdays");
            this.tbprevdays.Name = "tbprevdays";
            this.tbprevdays.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // label94
            // 
            resources.ApplyResources(this.label94, "label94");
            this.label94.Name = "label94";
            // 
            // tbvoice
            // 
            this.tbvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbvoice, "tbvoice");
            this.tbvoice.Name = "tbvoice";
            this.tbvoice.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // label90
            // 
            resources.ApplyResources(this.label90, "label90");
            this.label90.Name = "label90";
            // 
            // tbnpc
            // 
            this.tbnpc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbnpc, "tbnpc");
            this.tbnpc.Name = "tbnpc";
            this.tbnpc.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // label87
            // 
            resources.ApplyResources(this.label87, "label87");
            this.label87.Name = "label87";
            // 
            // tbautonomy
            // 
            this.tbautonomy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbautonomy, "tbautonomy");
            this.tbautonomy.Name = "tbautonomy";
            this.tbautonomy.TextChanged += new System.EventHandler(this.ChangedOther);
            // 
            // label86
            // 
            resources.ApplyResources(this.label86, "label86");
            this.label86.Name = "label86";
            // 
            // bTaskBox2
            // 
            this.bTaskBox2.BackColor = System.Drawing.Color.Transparent;
            this.bTaskBox2.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.bTaskBox2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bTaskBox2.Controls.Add(this.cbfit);
            this.bTaskBox2.Controls.Add(this.cbpreginv);
            this.bTaskBox2.Controls.Add(this.cbpreghalf);
            this.bTaskBox2.Controls.Add(this.cbpregfull);
            this.bTaskBox2.Controls.Add(this.cbfat);
            resources.ApplyResources(this.bTaskBox2, "bTaskBox2");
            this.bTaskBox2.IconLocation = new System.Drawing.Point(4, 0);
            this.bTaskBox2.IconSize = new System.Drawing.Size(32, 32);
            this.bTaskBox2.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.bTaskBox2.Name = "bTaskBox2";
            this.bTaskBox2.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            // 
            // cbfit
            // 
            resources.ApplyResources(this.cbfit, "cbfit");
            this.cbfit.Name = "cbfit";
            this.cbfit.UseVisualStyleBackColor = false;
            this.cbfit.CheckedChanged += new System.EventHandler(this.ChangedOther);
            // 
            // cbpreginv
            // 
            resources.ApplyResources(this.cbpreginv, "cbpreginv");
            this.cbpreginv.Name = "cbpreginv";
            this.cbpreginv.UseVisualStyleBackColor = false;
            this.cbpreginv.CheckedChanged += new System.EventHandler(this.ChangedOther);
            // 
            // cbpreghalf
            // 
            resources.ApplyResources(this.cbpreghalf, "cbpreghalf");
            this.cbpreghalf.Name = "cbpreghalf";
            this.cbpreghalf.UseVisualStyleBackColor = false;
            this.cbpreghalf.CheckedChanged += new System.EventHandler(this.ChangedOther);
            // 
            // cbpregfull
            // 
            resources.ApplyResources(this.cbpregfull, "cbpregfull");
            this.cbpregfull.Name = "cbpregfull";
            this.cbpregfull.UseVisualStyleBackColor = false;
            this.cbpregfull.CheckedChanged += new System.EventHandler(this.ChangedOther);
            // 
            // cbfat
            // 
            resources.ApplyResources(this.cbfat, "cbfat");
            this.cbfat.Name = "cbfat";
            this.cbfat.UseVisualStyleBackColor = false;
            this.cbfat.CheckedChanged += new System.EventHandler(this.ChangedOther);
            // 
            // bTaskBox1
            // 
            this.bTaskBox1.BackColor = System.Drawing.Color.Transparent;
            this.bTaskBox1.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.bTaskBox1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bTaskBox1.Controls.Add(this.cbisghost);
            this.bTaskBox1.Controls.Add(this.cbignoretraversal);
            this.bTaskBox1.Controls.Add(this.cbpasspeople);
            this.bTaskBox1.Controls.Add(this.cbpasswalls);
            this.bTaskBox1.Controls.Add(this.cbpassobject);
            resources.ApplyResources(this.bTaskBox1, "bTaskBox1");
            this.bTaskBox1.IconLocation = new System.Drawing.Point(4, 0);
            this.bTaskBox1.IconSize = new System.Drawing.Size(32, 32);
            this.bTaskBox1.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.bTaskBox1.Name = "bTaskBox1";
            this.bTaskBox1.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            // 
            // cbisghost
            // 
            resources.ApplyResources(this.cbisghost, "cbisghost");
            this.cbisghost.Name = "cbisghost";
            this.cbisghost.UseVisualStyleBackColor = false;
            this.cbisghost.CheckedChanged += new System.EventHandler(this.ChangedOther);
            // 
            // cbignoretraversal
            // 
            resources.ApplyResources(this.cbignoretraversal, "cbignoretraversal");
            this.cbignoretraversal.Name = "cbignoretraversal";
            this.cbignoretraversal.UseVisualStyleBackColor = false;
            this.cbignoretraversal.CheckedChanged += new System.EventHandler(this.ChangedOther);
            // 
            // cbpasspeople
            // 
            resources.ApplyResources(this.cbpasspeople, "cbpasspeople");
            this.cbpasspeople.Name = "cbpasspeople";
            this.cbpasspeople.UseVisualStyleBackColor = false;
            this.cbpasspeople.CheckedChanged += new System.EventHandler(this.ChangedOther);
            // 
            // cbpasswalls
            // 
            resources.ApplyResources(this.cbpasswalls, "cbpasswalls");
            this.cbpasswalls.Name = "cbpasswalls";
            this.cbpasswalls.UseVisualStyleBackColor = false;
            this.cbpasswalls.CheckedChanged += new System.EventHandler(this.ChangedOther);
            // 
            // cbpassobject
            // 
            resources.ApplyResources(this.cbpassobject, "cbpassobject");
            this.cbpassobject.Name = "cbpassobject";
            this.cbpassobject.UseVisualStyleBackColor = false;
            this.cbpassobject.CheckedChanged += new System.EventHandler(this.ChangedOther);
            // 
            // pnEP1
            // 
            resources.ApplyResources(this.pnEP1, "pnEP1");
            this.pnEP1.BackColor = System.Drawing.Color.Transparent;
            this.pnEP1.Controls.Add(this.tbSeminfo);
            this.pnEP1.Controls.Add(this.pbLastGrade);
            this.pnEP1.Controls.Add(this.pbUniTime);
            this.pnEP1.Controls.Add(this.pbEffort);
            this.pnEP1.Controls.Add(this.tbinfluence);
            this.pnEP1.Controls.Add(this.tbsemester);
            this.pnEP1.Controls.Add(this.label103);
            this.pnEP1.Controls.Add(this.label101);
            this.pnEP1.Controls.Add(this.cboncampus);
            this.pnEP1.Controls.Add(this.cbmajor);
            this.pnEP1.Controls.Add(this.label98);
            this.pnEP1.Controls.Add(this.tbmajor);
            this.pnEP1.Name = "pnEP1";
            // 
            // tbSeminfo
            // 
            this.tbSeminfo.BackColor = System.Drawing.Color.Transparent;
            this.tbSeminfo.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.tbSeminfo.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbSeminfo.Controls.Add(this.cbexpelled);
            this.tbSeminfo.Controls.Add(this.cbdroped);
            this.tbSeminfo.Controls.Add(this.cbatclass);
            this.tbSeminfo.Controls.Add(this.cbgraduate);
            this.tbSeminfo.Controls.Add(this.cbprobation);
            this.tbSeminfo.Controls.Add(this.cbGoodsem);
            this.tbSeminfo.Controls.Add(this.cbSenior);
            this.tbSeminfo.Controls.Add(this.cbJunior);
            this.tbSeminfo.Controls.Add(this.cbSopho);
            this.tbSeminfo.Controls.Add(this.cbfreshman);
            resources.ApplyResources(this.tbSeminfo, "tbSeminfo");
            this.tbSeminfo.IconLocation = new System.Drawing.Point(4, 12);
            this.tbSeminfo.IconSize = new System.Drawing.Size(32, 32);
            this.tbSeminfo.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.tbSeminfo.Name = "tbSeminfo";
            this.tbSeminfo.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            // 
            // cbexpelled
            // 
            resources.ApplyResources(this.cbexpelled, "cbexpelled");
            this.cbexpelled.Name = "cbexpelled";
            this.cbexpelled.UseVisualStyleBackColor = true;
            this.cbexpelled.CheckedChanged += new System.EventHandler(this.ChangedEP1);
            // 
            // cbdroped
            // 
            resources.ApplyResources(this.cbdroped, "cbdroped");
            this.cbdroped.Name = "cbdroped";
            this.cbdroped.UseVisualStyleBackColor = true;
            this.cbdroped.CheckedChanged += new System.EventHandler(this.ChangedEP1);
            // 
            // cbatclass
            // 
            resources.ApplyResources(this.cbatclass, "cbatclass");
            this.cbatclass.Name = "cbatclass";
            this.cbatclass.UseVisualStyleBackColor = true;
            this.cbatclass.CheckedChanged += new System.EventHandler(this.ChangedEP1);
            // 
            // cbgraduate
            // 
            resources.ApplyResources(this.cbgraduate, "cbgraduate");
            this.cbgraduate.Name = "cbgraduate";
            this.cbgraduate.UseVisualStyleBackColor = true;
            this.cbgraduate.CheckedChanged += new System.EventHandler(this.ChangedEP1);
            // 
            // cbprobation
            // 
            resources.ApplyResources(this.cbprobation, "cbprobation");
            this.cbprobation.Name = "cbprobation";
            this.cbprobation.UseVisualStyleBackColor = true;
            this.cbprobation.CheckedChanged += new System.EventHandler(this.ChangedEP1);
            // 
            // cbGoodsem
            // 
            resources.ApplyResources(this.cbGoodsem, "cbGoodsem");
            this.cbGoodsem.Name = "cbGoodsem";
            this.cbGoodsem.UseVisualStyleBackColor = true;
            this.cbGoodsem.CheckedChanged += new System.EventHandler(this.ChangedEP1);
            // 
            // cbSenior
            // 
            resources.ApplyResources(this.cbSenior, "cbSenior");
            this.cbSenior.Name = "cbSenior";
            this.cbSenior.UseVisualStyleBackColor = true;
            this.cbSenior.CheckedChanged += new System.EventHandler(this.ChangedSenior);
            // 
            // cbJunior
            // 
            resources.ApplyResources(this.cbJunior, "cbJunior");
            this.cbJunior.Name = "cbJunior";
            this.cbJunior.UseVisualStyleBackColor = true;
            this.cbJunior.CheckedChanged += new System.EventHandler(this.ChangedJunior);
            // 
            // cbSopho
            // 
            resources.ApplyResources(this.cbSopho, "cbSopho");
            this.cbSopho.Name = "cbSopho";
            this.cbSopho.UseVisualStyleBackColor = true;
            this.cbSopho.CheckedChanged += new System.EventHandler(this.ChangedSopho);
            // 
            // cbfreshman
            // 
            resources.ApplyResources(this.cbfreshman, "cbfreshman");
            this.cbfreshman.Name = "cbfreshman";
            this.cbfreshman.UseVisualStyleBackColor = true;
            this.cbfreshman.CheckedChanged += new System.EventHandler(this.Changedfreshman);
            // 
            // pbLastGrade
            // 
            this.pbLastGrade.BackColor = System.Drawing.Color.Transparent;
            this.pbLastGrade.DisplayOffset = 0;
            resources.ApplyResources(this.pbLastGrade, "pbLastGrade");
            this.pbLastGrade.Maximum = 1000;
            this.pbLastGrade.Name = "pbLastGrade";
            this.pbLastGrade.NumberFormat = "N1";
            this.pbLastGrade.NumberOffset = 0;
            this.pbLastGrade.NumberScale = 0.004;
            this.pbLastGrade.SelectedColor = System.Drawing.Color.OrangeRed;
            this.pbLastGrade.TokenCount = 4;
            this.pbLastGrade.UnselectedColor = System.Drawing.Color.Black;
            this.pbLastGrade.Value = 0;
            this.pbLastGrade.Changed += new System.EventHandler(this.ChangedEP1);
            // 
            // pbUniTime
            // 
            this.pbUniTime.BackColor = System.Drawing.Color.Transparent;
            this.pbUniTime.DisplayOffset = 0;
            resources.ApplyResources(this.pbUniTime, "pbUniTime");
            this.pbUniTime.Maximum = 72;
            this.pbUniTime.Name = "pbUniTime";
            this.pbUniTime.NumberFormat = "N0";
            this.pbUniTime.NumberOffset = 0;
            this.pbUniTime.NumberScale = 1;
            this.pbUniTime.SelectedColor = System.Drawing.Color.Lime;
            this.pbUniTime.TokenCount = 18;
            this.pbUniTime.UnselectedColor = System.Drawing.Color.Black;
            this.pbUniTime.Value = 0;
            this.pbUniTime.Changed += new System.EventHandler(this.ChangedEP1);
            // 
            // pbEffort
            // 
            this.pbEffort.BackColor = System.Drawing.Color.Transparent;
            this.pbEffort.DisplayOffset = 0;
            resources.ApplyResources(this.pbEffort, "pbEffort");
            this.pbEffort.Maximum = 1000;
            this.pbEffort.Name = "pbEffort";
            this.pbEffort.NumberFormat = "N2";
            this.pbEffort.NumberOffset = 0;
            this.pbEffort.NumberScale = 0.01;
            this.pbEffort.SelectedColor = System.Drawing.Color.Lime;
            this.pbEffort.TokenCount = 10;
            this.pbEffort.UnselectedColor = System.Drawing.Color.Black;
            this.pbEffort.Value = 0;
            this.pbEffort.Changed += new System.EventHandler(this.ChangedEP1);
            // 
            // tbinfluence
            // 
            resources.ApplyResources(this.tbinfluence, "tbinfluence");
            this.tbinfluence.Name = "tbinfluence";
            this.tbinfluence.TextChanged += new System.EventHandler(this.ChangedEP1);
            // 
            // tbsemester
            // 
            resources.ApplyResources(this.tbsemester, "tbsemester");
            this.tbsemester.Name = "tbsemester";
            this.tbsemester.TextChanged += new System.EventHandler(this.ChangedEP1);
            // 
            // label103
            // 
            resources.ApplyResources(this.label103, "label103");
            this.label103.Name = "label103";
            // 
            // label101
            // 
            resources.ApplyResources(this.label101, "label101");
            this.label101.Name = "label101";
            // 
            // cboncampus
            // 
            resources.ApplyResources(this.cboncampus, "cboncampus");
            this.cboncampus.Name = "cboncampus";
            this.cboncampus.UseVisualStyleBackColor = false;
            this.cboncampus.CheckedChanged += new System.EventHandler(this.ChangedEP1);
            // 
            // cbmajor
            // 
            resources.ApplyResources(this.cbmajor, "cbmajor");
            this.cbmajor.Name = "cbmajor";
            this.cbmajor.SelectedIndexChanged += new System.EventHandler(this.cbmajor_SelectedIndexChanged);
            // 
            // label98
            // 
            resources.ApplyResources(this.label98, "label98");
            this.label98.Name = "label98";
            // 
            // tbmajor
            // 
            this.tbmajor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbmajor, "tbmajor");
            this.tbmajor.Name = "tbmajor";
            this.tbmajor.TextChanged += new System.EventHandler(this.ChangedEP1);
            // 
            // pnEP7
            // 
            resources.ApplyResources(this.pnEP7, "pnEP7");
            this.pnEP7.BackColor = System.Drawing.Color.Transparent;
            this.pnEP7.Controls.Add(this.pbhbenth);
            this.pnEP7.Controls.Add(this.label41);
            this.pnEP7.Controls.Add(this.cbaspiration2);
            this.pnEP7.Controls.Add(this.cbHobbyPre);
            this.pnEP7.Controls.Add(this.label40);
            this.pnEP7.Controls.Add(this.bTaskBox4);
            this.pnEP7.Controls.Add(this.tbBugColl);
            this.pnEP7.Controls.Add(this.label32);
            this.pnEP7.Controls.Add(this.tbUnlocksUsed);
            this.pnEP7.Controls.Add(this.label31);
            this.pnEP7.Controls.Add(this.tbUnlockPts);
            this.pnEP7.Controls.Add(this.label30);
            this.pnEP7.Controls.Add(this.tbLtAsp);
            this.pnEP7.Controls.Add(this.label28);
            this.pnEP7.Controls.Add(this.label27);
            this.pnEP7.Controls.Add(this.cbHobbyEnth);
            this.pnEP7.Name = "pnEP7";
            // 
            // pbhbenth
            // 
            this.pbhbenth.BackColor = System.Drawing.Color.Transparent;
            this.pbhbenth.DisplayOffset = 0;
            resources.ApplyResources(this.pbhbenth, "pbhbenth");
            this.pbhbenth.Maximum = 1000;
            this.pbhbenth.Name = "pbhbenth";
            this.pbhbenth.NumberFormat = "N0";
            this.pbhbenth.NumberOffset = 0;
            this.pbhbenth.NumberScale = 1;
            this.pbhbenth.SelectedColor = System.Drawing.Color.YellowGreen;
            this.pbhbenth.TokenCount = 14;
            this.pbhbenth.UnselectedColor = System.Drawing.Color.Black;
            this.pbhbenth.Value = 500;
            this.pbhbenth.ChangedValue += new System.EventHandler(this.ChangedHobbyEnthProgress);
            // 
            // label41
            // 
            resources.ApplyResources(this.label41, "label41");
            this.label41.Name = "label41";
            // 
            // cbaspiration2
            // 
            resources.ApplyResources(this.cbaspiration2, "cbaspiration2");
            this.cbaspiration2.Name = "cbaspiration2";
            this.cbaspiration2.SelectedIndexChanged += new System.EventHandler(this.ChangedEP7);
            // 
            // cbHobbyPre
            // 
            this.cbHobbyPre.Enum = null;
            this.cbHobbyPre.FormattingEnabled = true;
            resources.ApplyResources(this.cbHobbyPre, "cbHobbyPre");
            this.cbHobbyPre.Name = "cbHobbyPre";
            this.cbHobbyPre.ResourceManager = null;
            this.cbHobbyPre.SelectedIndexChanged += new System.EventHandler(this.PredistinedHobbyIndexChanged);
            // 
            // label40
            // 
            resources.ApplyResources(this.label40, "label40");
            this.label40.Name = "label40";
            // 
            // bTaskBox4
            // 
            this.bTaskBox4.BackColor = System.Drawing.Color.Transparent;
            this.bTaskBox4.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.bTaskBox4.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bTaskBox4.Controls.Add(this.label33);
            this.bTaskBox4.Controls.Add(this.tb7social);
            this.bTaskBox4.Controls.Add(this.label34);
            this.bTaskBox4.Controls.Add(this.tb7fun);
            this.bTaskBox4.Controls.Add(this.label35);
            this.bTaskBox4.Controls.Add(this.tb7hygiene);
            this.bTaskBox4.Controls.Add(this.tb7energy);
            this.bTaskBox4.Controls.Add(this.label36);
            this.bTaskBox4.Controls.Add(this.tb7bladder);
            this.bTaskBox4.Controls.Add(this.label37);
            this.bTaskBox4.Controls.Add(this.tb7comfort);
            this.bTaskBox4.Controls.Add(this.label38);
            this.bTaskBox4.Controls.Add(this.tb7hunger);
            this.bTaskBox4.Controls.Add(this.label39);
            resources.ApplyResources(this.bTaskBox4, "bTaskBox4");
            this.bTaskBox4.IconLocation = new System.Drawing.Point(4, 12);
            this.bTaskBox4.IconSize = new System.Drawing.Size(32, 32);
            this.bTaskBox4.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.bTaskBox4.Name = "bTaskBox4";
            this.bTaskBox4.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            // 
            // label33
            // 
            resources.ApplyResources(this.label33, "label33");
            this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label33.Name = "label33";
            // 
            // tb7social
            // 
            this.tb7social.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tb7social, "tb7social");
            this.tb7social.Name = "tb7social";
            this.tb7social.TextChanged += new System.EventHandler(this.ChangedEP7);
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Name = "label34";
            // 
            // tb7fun
            // 
            this.tb7fun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tb7fun, "tb7fun");
            this.tb7fun.Name = "tb7fun";
            this.tb7fun.TextChanged += new System.EventHandler(this.ChangedEP7);
            // 
            // label35
            // 
            resources.ApplyResources(this.label35, "label35");
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Name = "label35";
            // 
            // tb7hygiene
            // 
            this.tb7hygiene.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tb7hygiene, "tb7hygiene");
            this.tb7hygiene.Name = "tb7hygiene";
            this.tb7hygiene.TextChanged += new System.EventHandler(this.ChangedEP7);
            // 
            // tb7energy
            // 
            this.tb7energy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tb7energy, "tb7energy");
            this.tb7energy.Name = "tb7energy";
            this.tb7energy.TextChanged += new System.EventHandler(this.ChangedEP7);
            // 
            // label36
            // 
            resources.ApplyResources(this.label36, "label36");
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Name = "label36";
            // 
            // tb7bladder
            // 
            this.tb7bladder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tb7bladder, "tb7bladder");
            this.tb7bladder.Name = "tb7bladder";
            this.tb7bladder.TextChanged += new System.EventHandler(this.ChangedEP7);
            // 
            // label37
            // 
            resources.ApplyResources(this.label37, "label37");
            this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label37.Name = "label37";
            // 
            // tb7comfort
            // 
            this.tb7comfort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tb7comfort, "tb7comfort");
            this.tb7comfort.Name = "tb7comfort";
            this.tb7comfort.TextChanged += new System.EventHandler(this.ChangedEP7);
            // 
            // label38
            // 
            resources.ApplyResources(this.label38, "label38");
            this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label38.Name = "label38";
            // 
            // tb7hunger
            // 
            this.tb7hunger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tb7hunger, "tb7hunger");
            this.tb7hunger.Name = "tb7hunger";
            this.tb7hunger.TextChanged += new System.EventHandler(this.ChangedEP7);
            // 
            // label39
            // 
            resources.ApplyResources(this.label39, "label39");
            this.label39.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label39.Name = "label39";
            // 
            // tbBugColl
            // 
            resources.ApplyResources(this.tbBugColl, "tbBugColl");
            this.tbBugColl.Name = "tbBugColl";
            this.tbBugColl.TextChanged += new System.EventHandler(this.ChangedEP7);
            // 
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.Name = "label32";
            // 
            // tbUnlocksUsed
            // 
            resources.ApplyResources(this.tbUnlocksUsed, "tbUnlocksUsed");
            this.tbUnlocksUsed.Name = "tbUnlocksUsed";
            this.tbUnlocksUsed.TextChanged += new System.EventHandler(this.ChangedEP7);
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            // 
            // tbUnlockPts
            // 
            resources.ApplyResources(this.tbUnlockPts, "tbUnlockPts");
            this.tbUnlockPts.Name = "tbUnlockPts";
            this.tbUnlockPts.TextChanged += new System.EventHandler(this.ChangedEP7);
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // tbLtAsp
            // 
            resources.ApplyResources(this.tbLtAsp, "tbLtAsp");
            this.tbLtAsp.Name = "tbLtAsp";
            this.tbLtAsp.TextChanged += new System.EventHandler(this.ChangedEP7);
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // cbHobbyEnth
            // 
            this.cbHobbyEnth.FormattingEnabled = true;
            this.cbHobbyEnth.Items.AddRange(new object[] {
            resources.GetString("cbHobbyEnth.Items"),
            resources.GetString("cbHobbyEnth.Items1"),
            resources.GetString("cbHobbyEnth.Items2"),
            resources.GetString("cbHobbyEnth.Items3"),
            resources.GetString("cbHobbyEnth.Items4"),
            resources.GetString("cbHobbyEnth.Items5"),
            resources.GetString("cbHobbyEnth.Items6"),
            resources.GetString("cbHobbyEnth.Items7"),
            resources.GetString("cbHobbyEnth.Items8"),
            resources.GetString("cbHobbyEnth.Items9"),
            resources.GetString("cbHobbyEnth.Items10")});
            resources.ApplyResources(this.cbHobbyEnth, "cbHobbyEnth");
            this.cbHobbyEnth.Name = "cbHobbyEnth";
            this.cbHobbyEnth.SelectedIndexChanged += new System.EventHandler(this.EnthusiasmIndexChanged);
            // 
            // pnEP2
            // 
            resources.ApplyResources(this.pnEP2, "pnEP2");
            this.pnEP2.BackColor = System.Drawing.Color.Transparent;
            this.pnEP2.Controls.Add(this.tbNTLove);
            this.pnEP2.Controls.Add(this.tbNTPerfume);
            this.pnEP2.Controls.Add(this.label8);
            this.pnEP2.Controls.Add(this.label7);
            this.pnEP2.Controls.Add(this.lbTurnOff);
            this.pnEP2.Controls.Add(this.label6);
            this.pnEP2.Controls.Add(this.lbTurnOn);
            this.pnEP2.Controls.Add(this.label5);
            this.pnEP2.Controls.Add(this.lbTraits);
            this.pnEP2.Controls.Add(this.pbtraits);
            this.pnEP2.Controls.Add(this.label4);
            this.pnEP2.Name = "pnEP2";
            // 
            // tbNTLove
            // 
            resources.ApplyResources(this.tbNTLove, "tbNTLove");
            this.tbNTLove.Name = "tbNTLove";
            this.tbNTLove.TextChanged += new System.EventHandler(this.ChangedEP2);
            // 
            // tbNTPerfume
            // 
            resources.ApplyResources(this.tbNTPerfume, "tbNTPerfume");
            this.tbNTPerfume.Name = "tbNTPerfume";
            this.tbNTPerfume.TextChanged += new System.EventHandler(this.ChangedEP2);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lbTurnOff
            // 
            resources.ApplyResources(this.lbTurnOff, "lbTurnOff");
            this.lbTurnOff.CheckOnClick = true;
            this.lbTurnOff.Name = "lbTurnOff";
            this.lbTurnOff.SelectedIndexChanged += new System.EventHandler(this.lbTurnOff_SelectedIndexChanged);
            this.lbTurnOff.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklb_ItemCheck);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // lbTurnOn
            // 
            resources.ApplyResources(this.lbTurnOn, "lbTurnOn");
            this.lbTurnOn.CheckOnClick = true;
            this.lbTurnOn.Name = "lbTurnOn";
            this.lbTurnOn.SelectedIndexChanged += new System.EventHandler(this.lbTurnOn_SelectedIndexChanged);
            this.lbTurnOn.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklb_ItemCheck);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lbTraits
            // 
            resources.ApplyResources(this.lbTraits, "lbTraits");
            this.lbTraits.CheckOnClick = true;
            this.lbTraits.Name = "lbTraits";
            this.lbTraits.SelectedIndexChanged += new System.EventHandler(this.lbTraits_SelectedIndexChanged);
            this.lbTraits.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklb_ItemCheck);
            // 
            // pbtraits
            // 
            resources.ApplyResources(this.pbtraits, "pbtraits");
            this.pbtraits.Name = "pbtraits";
            this.pbtraits.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // pnEP3
            // 
            resources.ApplyResources(this.pnEP3, "pnEP3");
            this.pnEP3.BackColor = System.Drawing.Color.Transparent;
            this.pnEP3.Controls.Add(this.llep3openinfo);
            this.pnEP3.Controls.Add(this.label15);
            this.pnEP3.Controls.Add(this.sblb);
            this.pnEP3.Controls.Add(this.tbEp3Salery);
            this.pnEP3.Controls.Add(this.label14);
            this.pnEP3.Controls.Add(this.label12);
            this.pnEP3.Controls.Add(this.cbEp3Asgn);
            this.pnEP3.Controls.Add(this.tbEp3Flag);
            this.pnEP3.Controls.Add(this.tbEp3Lot);
            this.pnEP3.Controls.Add(this.label9);
            this.pnEP3.Controls.Add(this.label11);
            this.pnEP3.Name = "pnEP3";
            // 
            // llep3openinfo
            // 
            resources.ApplyResources(this.llep3openinfo, "llep3openinfo");
            this.llep3openinfo.BackColor = System.Drawing.Color.Transparent;
            this.llep3openinfo.ForeColor = System.Drawing.Color.Black;
            this.llep3openinfo.Name = "llep3openinfo";
            this.llep3openinfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llep3openinfo_LinkClicked);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // sblb
            // 
            resources.ApplyResources(this.sblb, "sblb");
            this.sblb.Name = "sblb";
            this.sblb.SimDescription = null;
            this.sblb.SelectedBusinessChanged += new System.EventHandler(this.sblb_SelectedBusinessChanged);
            // 
            // tbEp3Salery
            // 
            resources.ApplyResources(this.tbEp3Salery, "tbEp3Salery");
            this.tbEp3Salery.Name = "tbEp3Salery";
            this.tbEp3Salery.TextChanged += new System.EventHandler(this.ChangedEP3);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // cbEp3Asgn
            // 
            this.cbEp3Asgn.Enum = null;
            this.cbEp3Asgn.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.cbEp3Asgn, "cbEp3Asgn");
            this.cbEp3Asgn.Name = "cbEp3Asgn";
            this.cbEp3Asgn.ResourceManager = null;
            this.cbEp3Asgn.SelectedValueChanged += new System.EventHandler(this.ChangedEP3);
            // 
            // tbEp3Flag
            // 
            resources.ApplyResources(this.tbEp3Flag, "tbEp3Flag");
            this.tbEp3Flag.Name = "tbEp3Flag";
            this.tbEp3Flag.TextChanged += new System.EventHandler(this.ChangedEP3);
            // 
            // tbEp3Lot
            // 
            resources.ApplyResources(this.tbEp3Lot, "tbEp3Lot");
            this.tbEp3Lot.Name = "tbEp3Lot";
            this.tbEp3Lot.TextChanged += new System.EventHandler(this.ChangedEP3);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // pnVoyage
            // 
            resources.ApplyResources(this.pnVoyage, "pnVoyage");
            this.pnVoyage.BackColor = System.Drawing.Color.Transparent;
            this.pnVoyage.Controls.Add(this.lvCollectibles);
            this.pnVoyage.Controls.Add(this.tbhdaysleft);
            this.pnVoyage.Controls.Add(this.label29);
            this.pnVoyage.Controls.Add(this.labelcol);
            this.pnVoyage.Name = "pnVoyage";
            // 
            // lvCollectibles
            // 
            resources.ApplyResources(this.lvCollectibles, "lvCollectibles");
            this.lvCollectibles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvCollectibles.CheckBoxes = true;
            this.lvCollectibles.HideSelection = false;
            this.lvCollectibles.LargeImageList = this.ilCollectibles;
            this.lvCollectibles.MultiSelect = false;
            this.lvCollectibles.Name = "lvCollectibles";
            this.lvCollectibles.ShowGroups = false;
            this.lvCollectibles.SmallImageList = this.ilCollectibles;
            this.lvCollectibles.UseCompatibleStateImageBehavior = false;
            this.lvCollectibles.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvCollectibles_ItemChecked);
            this.lvCollectibles.SelectedIndexChanged += new System.EventHandler(this.ChangedEP6);
            // 
            // ilCollectibles
            // 
            this.ilCollectibles.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.ilCollectibles, "ilCollectibles");
            this.ilCollectibles.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tbhdaysleft
            // 
            resources.ApplyResources(this.tbhdaysleft, "tbhdaysleft");
            this.tbhdaysleft.Name = "tbhdaysleft";
            this.tbhdaysleft.TextChanged += new System.EventHandler(this.ChangedEP6);
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // labelcol
            // 
            resources.ApplyResources(this.labelcol, "labelcol");
            this.labelcol.Name = "labelcol";
            // 
            // pnEP9
            // 
            resources.ApplyResources(this.pnEP9, "pnEP9");
            this.pnEP9.BackColor = System.Drawing.Color.Transparent;
            this.pnEP9.Controls.Add(this.lbfaithinfo);
            this.pnEP9.Controls.Add(this.tbfemdik);
            this.pnEP9.Controls.Add(this.Various);
            this.pnEP9.Controls.Add(this.Nipples);
            this.pnEP9.Controls.Add(this.Pubes);
            this.pnEP9.Name = "pnEP9";
            // 
            // lbfaithinfo
            // 
            resources.ApplyResources(this.lbfaithinfo, "lbfaithinfo");
            this.lbfaithinfo.Name = "lbfaithinfo";
            // 
            // tbfemdik
            // 
            this.tbfemdik.BackColor = System.Drawing.Color.Transparent;
            this.tbfemdik.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.tbfemdik.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbfemdik.Controls.Add(this.lbFemcolour);
            this.tbfemdik.Controls.Add(this.cbfembaldy);
            this.tbfemdik.Controls.Add(this.cbfemsmall);
            this.tbfemdik.Controls.Add(this.cbfembig);
            this.tbfemdik.Controls.Add(this.cbfemcirc);
            this.tbfemdik.Controls.Add(this.cbFemColour);
            resources.ApplyResources(this.tbfemdik, "tbfemdik");
            this.tbfemdik.IconLocation = new System.Drawing.Point(4, 0);
            this.tbfemdik.IconSize = new System.Drawing.Size(32, 32);
            this.tbfemdik.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.tbfemdik.Name = "tbfemdik";
            this.tbfemdik.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            // 
            // lbFemcolour
            // 
            resources.ApplyResources(this.lbFemcolour, "lbFemcolour");
            this.lbFemcolour.Name = "lbFemcolour";
            // 
            // Various
            // 
            this.Various.BackColor = System.Drawing.Color.Transparent;
            this.Various.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.Various.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Various.Controls.Add(this.lbVBFriend);
            this.Various.Controls.Add(this.cbVBFriend);
            this.Various.Controls.Add(this.cbisslave);
            this.Various.Controls.Add(this.cbstaynude);
            this.Various.Controls.Add(this.lbReligion);
            this.Various.Controls.Add(this.lbpostTitle);
            this.Various.Controls.Add(this.cbpostTitle);
            this.Various.Controls.Add(this.cbSuburbs);
            this.Various.Controls.Add(this.pbRomance);
            this.Various.Controls.Add(this.cbFaiths);
            this.Various.Controls.Add(this.lbalcsub);
            this.Various.Controls.Add(this.cbhospital);
            this.Various.Controls.Add(this.pbicon);
            this.Various.Controls.Add(this.cbonpill);
            this.Various.Controls.Add(this.cbmarker);
            this.Various.Controls.Add(this.lbBodee);
            this.Various.Controls.Add(this.cbBody);
            resources.ApplyResources(this.Various, "Various");
            this.Various.IconLocation = new System.Drawing.Point(4, 0);
            this.Various.IconSize = new System.Drawing.Size(32, 32);
            this.Various.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.Various.Name = "Various";
            this.Various.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            // 
            // lbVBFriend
            // 
            resources.ApplyResources(this.lbVBFriend, "lbVBFriend");
            this.lbVBFriend.Name = "lbVBFriend";
            // 
            // cbVBFriend
            // 
            resources.ApplyResources(this.cbVBFriend, "cbVBFriend");
            this.cbVBFriend.FormattingEnabled = true;
            this.cbVBFriend.Name = "cbVBFriend";
            // 
            // cbisslave
            // 
            resources.ApplyResources(this.cbisslave, "cbisslave");
            this.cbisslave.Name = "cbisslave";
            this.cbisslave.UseVisualStyleBackColor = true;
            // 
            // cbstaynude
            // 
            resources.ApplyResources(this.cbstaynude, "cbstaynude");
            this.cbstaynude.Name = "cbstaynude";
            this.cbstaynude.UseVisualStyleBackColor = true;
            // 
            // lbReligion
            // 
            resources.ApplyResources(this.lbReligion, "lbReligion");
            this.lbReligion.Name = "lbReligion";
            // 
            // lbpostTitle
            // 
            resources.ApplyResources(this.lbpostTitle, "lbpostTitle");
            this.lbpostTitle.Name = "lbpostTitle";
            // 
            // cbpostTitle
            // 
            resources.ApplyResources(this.cbpostTitle, "cbpostTitle");
            this.cbpostTitle.FormattingEnabled = true;
            this.cbpostTitle.Name = "cbpostTitle";
            // 
            // cbSuburbs
            // 
            this.cbSuburbs.FormattingEnabled = true;
            resources.ApplyResources(this.cbSuburbs, "cbSuburbs");
            this.cbSuburbs.Name = "cbSuburbs";
            // 
            // cbFaiths
            // 
            resources.ApplyResources(this.cbFaiths, "cbFaiths");
            this.cbFaiths.FormattingEnabled = true;
            this.cbFaiths.Name = "cbFaiths";
            // 
            // lbalcsub
            // 
            resources.ApplyResources(this.lbalcsub, "lbalcsub");
            this.lbalcsub.Name = "lbalcsub";
            // 
            // cbhospital
            // 
            resources.ApplyResources(this.cbhospital, "cbhospital");
            this.cbhospital.Name = "cbhospital";
            this.cbhospital.UseVisualStyleBackColor = true;
            // 
            // pbicon
            // 
            resources.ApplyResources(this.pbicon, "pbicon");
            this.pbicon.Name = "pbicon";
            this.pbicon.TabStop = false;
            // 
            // cbonpill
            // 
            resources.ApplyResources(this.cbonpill, "cbonpill");
            this.cbonpill.Name = "cbonpill";
            this.cbonpill.UseVisualStyleBackColor = true;
            // 
            // cbmarker
            // 
            resources.ApplyResources(this.cbmarker, "cbmarker");
            this.cbmarker.Name = "cbmarker";
            this.cbmarker.UseVisualStyleBackColor = true;
            // 
            // lbBodee
            // 
            resources.ApplyResources(this.lbBodee, "lbBodee");
            this.lbBodee.Name = "lbBodee";
            // 
            // cbBody
            // 
            resources.ApplyResources(this.cbBody, "cbBody");
            this.cbBody.FormattingEnabled = true;
            this.cbBody.Name = "cbBody";
            // 
            // Nipples
            // 
            this.Nipples.BackColor = System.Drawing.Color.Transparent;
            this.Nipples.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.Nipples.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Nipples.Controls.Add(this.labelnipple);
            this.Nipples.Controls.Add(this.cbnipsit);
            this.Nipples.Controls.Add(this.cbnipssi);
            this.Nipples.Controls.Add(this.cbnipsma);
            this.Nipples.Controls.Add(this.cbnipswi);
            this.Nipples.Controls.Add(this.cbnipsfo);
            this.Nipples.Controls.Add(this.cbnipsgy);
            this.Nipples.Controls.Add(this.cbnipsun);
            this.Nipples.Controls.Add(this.cbnipspy);
            this.Nipples.Controls.Add(this.cbnipssw);
            this.Nipples.Controls.Add(this.cbnipsca);
            this.Nipples.Controls.Add(this.cbnipsna);
            resources.ApplyResources(this.Nipples, "Nipples");
            this.Nipples.IconLocation = new System.Drawing.Point(4, 0);
            this.Nipples.IconSize = new System.Drawing.Size(32, 32);
            this.Nipples.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.Nipples.Name = "Nipples";
            this.Nipples.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            // 
            // labelnipple
            // 
            resources.ApplyResources(this.labelnipple, "labelnipple");
            this.labelnipple.Name = "labelnipple";
            // 
            // cbnipsit
            // 
            resources.ApplyResources(this.cbnipsit, "cbnipsit");
            this.cbnipsit.Name = "cbnipsit";
            this.cbnipsit.UseVisualStyleBackColor = true;
            // 
            // cbnipssi
            // 
            resources.ApplyResources(this.cbnipssi, "cbnipssi");
            this.cbnipssi.Name = "cbnipssi";
            this.cbnipssi.UseVisualStyleBackColor = true;
            // 
            // cbnipsma
            // 
            resources.ApplyResources(this.cbnipsma, "cbnipsma");
            this.cbnipsma.Name = "cbnipsma";
            this.cbnipsma.UseVisualStyleBackColor = true;
            // 
            // cbnipswi
            // 
            resources.ApplyResources(this.cbnipswi, "cbnipswi");
            this.cbnipswi.Name = "cbnipswi";
            this.cbnipswi.UseVisualStyleBackColor = true;
            // 
            // cbnipsfo
            // 
            resources.ApplyResources(this.cbnipsfo, "cbnipsfo");
            this.cbnipsfo.Name = "cbnipsfo";
            this.cbnipsfo.UseVisualStyleBackColor = true;
            // 
            // cbnipsgy
            // 
            resources.ApplyResources(this.cbnipsgy, "cbnipsgy");
            this.cbnipsgy.Name = "cbnipsgy";
            this.cbnipsgy.UseVisualStyleBackColor = true;
            // 
            // cbnipsun
            // 
            resources.ApplyResources(this.cbnipsun, "cbnipsun");
            this.cbnipsun.Name = "cbnipsun";
            this.cbnipsun.UseVisualStyleBackColor = true;
            // 
            // cbnipspy
            // 
            resources.ApplyResources(this.cbnipspy, "cbnipspy");
            this.cbnipspy.Name = "cbnipspy";
            this.cbnipspy.UseVisualStyleBackColor = true;
            // 
            // cbnipssw
            // 
            resources.ApplyResources(this.cbnipssw, "cbnipssw");
            this.cbnipssw.Name = "cbnipssw";
            this.cbnipssw.UseVisualStyleBackColor = true;
            // 
            // cbnipsca
            // 
            resources.ApplyResources(this.cbnipsca, "cbnipsca");
            this.cbnipsca.Name = "cbnipsca";
            this.cbnipsca.UseVisualStyleBackColor = true;
            // 
            // cbnipsna
            // 
            resources.ApplyResources(this.cbnipsna, "cbnipsna");
            this.cbnipsna.Name = "cbnipsna";
            this.cbnipsna.UseVisualStyleBackColor = true;
            // 
            // Pubes
            // 
            this.Pubes.BackColor = System.Drawing.Color.Transparent;
            this.Pubes.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.Pubes.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Pubes.Controls.Add(this.pnPenis);
            this.Pubes.Controls.Add(this.pnMuffy);
            this.Pubes.Controls.Add(this.labelgenital);
            this.Pubes.Controls.Add(this.cbpubeal);
            this.Pubes.Controls.Add(this.cbpubegy);
            this.Pubes.Controls.Add(this.cbpubeun);
            this.Pubes.Controls.Add(this.cbpubepy);
            this.Pubes.Controls.Add(this.cbpubesw);
            this.Pubes.Controls.Add(this.cbpubeca);
            resources.ApplyResources(this.Pubes, "Pubes");
            this.Pubes.IconLocation = new System.Drawing.Point(4, 0);
            this.Pubes.IconSize = new System.Drawing.Size(32, 32);
            this.Pubes.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.Pubes.Name = "Pubes";
            this.Pubes.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            // 
            // pnPenis
            // 
            this.pnPenis.Controls.Add(this.cbdickless);
            this.pnPenis.Controls.Add(this.labelpenis);
            this.pnPenis.Controls.Add(this.lbBallsize);
            this.pnPenis.Controls.Add(this.cbDiklength);
            this.pnPenis.Controls.Add(this.lbDikgirth);
            this.pnPenis.Controls.Add(this.cbDikgirth);
            this.pnPenis.Controls.Add(this.lbDikcolour);
            this.pnPenis.Controls.Add(this.cbBallsize);
            this.pnPenis.Controls.Add(this.lbDikstate);
            this.pnPenis.Controls.Add(this.cbDikstate);
            this.pnPenis.Controls.Add(this.lbDiklength);
            this.pnPenis.Controls.Add(this.cbDikcolour);
            resources.ApplyResources(this.pnPenis, "pnPenis");
            this.pnPenis.Name = "pnPenis";
            // 
            // cbdickless
            // 
            resources.ApplyResources(this.cbdickless, "cbdickless");
            this.cbdickless.Name = "cbdickless";
            this.cbdickless.UseVisualStyleBackColor = true;
            // 
            // labelpenis
            // 
            resources.ApplyResources(this.labelpenis, "labelpenis");
            this.labelpenis.Name = "labelpenis";
            // 
            // lbBallsize
            // 
            resources.ApplyResources(this.lbBallsize, "lbBallsize");
            this.lbBallsize.Name = "lbBallsize";
            // 
            // cbDiklength
            // 
            resources.ApplyResources(this.cbDiklength, "cbDiklength");
            this.cbDiklength.FormattingEnabled = true;
            this.cbDiklength.Name = "cbDiklength";
            // 
            // lbDikgirth
            // 
            resources.ApplyResources(this.lbDikgirth, "lbDikgirth");
            this.lbDikgirth.Name = "lbDikgirth";
            // 
            // cbDikgirth
            // 
            resources.ApplyResources(this.cbDikgirth, "cbDikgirth");
            this.cbDikgirth.FormattingEnabled = true;
            this.cbDikgirth.Name = "cbDikgirth";
            // 
            // lbDikcolour
            // 
            resources.ApplyResources(this.lbDikcolour, "lbDikcolour");
            this.lbDikcolour.Name = "lbDikcolour";
            // 
            // cbBallsize
            // 
            resources.ApplyResources(this.cbBallsize, "cbBallsize");
            this.cbBallsize.FormattingEnabled = true;
            this.cbBallsize.Name = "cbBallsize";
            // 
            // lbDikstate
            // 
            resources.ApplyResources(this.lbDikstate, "lbDikstate");
            this.lbDikstate.Name = "lbDikstate";
            // 
            // cbDikstate
            // 
            resources.ApplyResources(this.cbDikstate, "cbDikstate");
            this.cbDikstate.FormattingEnabled = true;
            this.cbDikstate.Name = "cbDikstate";
            // 
            // lbDiklength
            // 
            resources.ApplyResources(this.lbDiklength, "lbDiklength");
            this.lbDiklength.Name = "lbDiklength";
            // 
            // cbDikcolour
            // 
            resources.ApplyResources(this.cbDikcolour, "cbDikcolour");
            this.cbDikcolour.FormattingEnabled = true;
            this.cbDikcolour.Name = "cbDikcolour";
            // 
            // pnMuffy
            // 
            this.pnMuffy.Controls.Add(this.btpubedic);
            this.pnMuffy.Controls.Add(this.labelpubes);
            this.pnMuffy.Controls.Add(this.cbpubesh);
            this.pnMuffy.Controls.Add(this.cbpubetr);
            this.pnMuffy.Controls.Add(this.cbpubetf);
            this.pnMuffy.Controls.Add(this.cbpubebk);
            this.pnMuffy.Controls.Add(this.cbpubebn);
            this.pnMuffy.Controls.Add(this.cbpubebd);
            this.pnMuffy.Controls.Add(this.cbpuberd);
            resources.ApplyResources(this.pnMuffy, "pnMuffy");
            this.pnMuffy.Name = "pnMuffy";
            this.toolTip1.SetToolTip(this.pnMuffy, resources.GetString("pnMuffy.ToolTip"));
            // 
            // btpubedic
            // 
            resources.ApplyResources(this.btpubedic, "btpubedic");
            this.btpubedic.Name = "btpubedic";
            this.btpubedic.UseVisualStyleBackColor = true;
            // 
            // labelpubes
            // 
            resources.ApplyResources(this.labelpubes, "labelpubes");
            this.labelpubes.Name = "labelpubes";
            // 
            // cbpubesh
            // 
            resources.ApplyResources(this.cbpubesh, "cbpubesh");
            this.cbpubesh.Name = "cbpubesh";
            this.cbpubesh.UseVisualStyleBackColor = true;
            // 
            // cbpubetr
            // 
            resources.ApplyResources(this.cbpubetr, "cbpubetr");
            this.cbpubetr.Name = "cbpubetr";
            this.cbpubetr.UseVisualStyleBackColor = true;
            // 
            // cbpubetf
            // 
            resources.ApplyResources(this.cbpubetf, "cbpubetf");
            this.cbpubetf.Name = "cbpubetf";
            this.cbpubetf.UseVisualStyleBackColor = true;
            // 
            // cbpubebk
            // 
            resources.ApplyResources(this.cbpubebk, "cbpubebk");
            this.cbpubebk.Name = "cbpubebk";
            this.cbpubebk.UseVisualStyleBackColor = true;
            // 
            // cbpubebn
            // 
            resources.ApplyResources(this.cbpubebn, "cbpubebn");
            this.cbpubebn.Name = "cbpubebn";
            this.cbpubebn.UseVisualStyleBackColor = true;
            // 
            // cbpubebd
            // 
            resources.ApplyResources(this.cbpubebd, "cbpubebd");
            this.cbpubebd.Name = "cbpubebd";
            this.cbpubebd.UseVisualStyleBackColor = true;
            // 
            // cbpuberd
            // 
            resources.ApplyResources(this.cbpuberd, "cbpuberd");
            this.cbpuberd.Name = "cbpuberd";
            this.cbpuberd.UseVisualStyleBackColor = true;
            // 
            // labelgenital
            // 
            resources.ApplyResources(this.labelgenital, "labelgenital");
            this.labelgenital.Name = "labelgenital";
            // 
            // cbpubeal
            // 
            resources.ApplyResources(this.cbpubeal, "cbpubeal");
            this.cbpubeal.Name = "cbpubeal";
            this.cbpubeal.UseVisualStyleBackColor = true;
            // 
            // cbpubegy
            // 
            resources.ApplyResources(this.cbpubegy, "cbpubegy");
            this.cbpubegy.Name = "cbpubegy";
            this.cbpubegy.UseVisualStyleBackColor = true;
            // 
            // cbpubeun
            // 
            resources.ApplyResources(this.cbpubeun, "cbpubeun");
            this.cbpubeun.Name = "cbpubeun";
            this.cbpubeun.UseVisualStyleBackColor = true;
            // 
            // cbpubepy
            // 
            resources.ApplyResources(this.cbpubepy, "cbpubepy");
            this.cbpubepy.Name = "cbpubepy";
            this.cbpubepy.UseVisualStyleBackColor = true;
            // 
            // cbpubesw
            // 
            resources.ApplyResources(this.cbpubesw, "cbpubesw");
            this.cbpubesw.Name = "cbpubesw";
            this.cbpubesw.UseVisualStyleBackColor = true;
            // 
            // cbpubeca
            // 
            resources.ApplyResources(this.cbpubeca, "cbpubeca");
            this.cbpubeca.Name = "cbpubeca";
            this.cbpubeca.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Note:";
            // 
            // ExtSDesc
            // 
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.pnId);
            this.Controls.Add(this.pnCareer);
            this.Controls.Add(this.pnRel);
            this.Controls.Add(this.pnInt);
            this.Controls.Add(this.pnChar);
            this.Controls.Add(this.pnSkill);
            this.Controls.Add(this.pnMisc);
            this.Controls.Add(this.pnEP1);
            this.Controls.Add(this.pnEP2);
            this.Controls.Add(this.pnEP3);
            this.Controls.Add(this.pnVoyage);
            this.Controls.Add(this.pnEP7);
            this.Controls.Add(this.pnEP9);
            resources.ApplyResources(this, "$this");
            this.HeaderText = null;
            this.Name = "ExtSDesc";
            this.Controls.SetChildIndex(this.pnEP9, 0);
            this.Controls.SetChildIndex(this.pnEP7, 0);
            this.Controls.SetChildIndex(this.pnVoyage, 0);
            this.Controls.SetChildIndex(this.pnEP3, 0);
            this.Controls.SetChildIndex(this.pnEP2, 0);
            this.Controls.SetChildIndex(this.pnEP1, 0);
            this.Controls.SetChildIndex(this.pnMisc, 0);
            this.Controls.SetChildIndex(this.pnSkill, 0);
            this.Controls.SetChildIndex(this.pnChar, 0);
            this.Controls.SetChildIndex(this.pnInt, 0);
            this.Controls.SetChildIndex(this.pnRel, 0);
            this.Controls.SetChildIndex(this.pnCareer, 0);
            this.Controls.SetChildIndex(this.pnId, 0);
            this.Controls.SetChildIndex(this.toolBar1, 0);
            this.pnPetInt.ResumeLayout(false);
            this.toolBar1.ResumeLayout(false);
            this.toolBar1.PerformLayout();
            this.pnId.ResumeLayout(false);
            this.pnId.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.pnSkill.ResumeLayout(false);
            this.pnChar.ResumeLayout(false);
            this.pnPetChar.ResumeLayout(false);
            this.pnPetChar.PerformLayout();
            this.pnHumanChar.ResumeLayout(false);
            this.mbiLink.ResumeLayout(false);
            this.miRel.ResumeLayout(false);
            this.pnCareer.ResumeLayout(false);
            this.pnCareer.PerformLayout();
            this.pnInt.ResumeLayout(false);
            this.pnSimInt.ResumeLayout(false);
            this.pnRel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnMisc.ResumeLayout(false);
            this.tbMotiveDec.ResumeLayout(false);
            this.tbMotiveDec.PerformLayout();
            this.tbpersonflags.ResumeLayout(false);
            this.tbpersonflags.PerformLayout();
            this.bTaskBox3.ResumeLayout(false);
            this.bTaskBox3.PerformLayout();
            this.bTaskBox2.ResumeLayout(false);
            this.bTaskBox1.ResumeLayout(false);
            this.pnEP1.ResumeLayout(false);
            this.pnEP1.PerformLayout();
            this.tbSeminfo.ResumeLayout(false);
            this.tbSeminfo.PerformLayout();
            this.pnEP7.ResumeLayout(false);
            this.pnEP7.PerformLayout();
            this.bTaskBox4.ResumeLayout(false);
            this.bTaskBox4.PerformLayout();
            this.pnEP2.ResumeLayout(false);
            this.pnEP2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtraits)).EndInit();
            this.pnEP3.ResumeLayout(false);
            this.pnEP3.PerformLayout();
            this.pnVoyage.ResumeLayout(false);
            this.pnVoyage.PerformLayout();
            this.pnEP9.ResumeLayout(false);
            this.pnEP9.PerformLayout();
            this.tbfemdik.ResumeLayout(false);
            this.tbfemdik.PerformLayout();
            this.Various.ResumeLayout(false);
            this.Various.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbicon)).EndInit();
            this.Nipples.ResumeLayout(false);
            this.Nipples.PerformLayout();
            this.Pubes.ResumeLayout(false);
            this.Pubes.PerformLayout();
            this.pnPenis.ResumeLayout(false);
            this.pnPenis.PerformLayout();
            this.pnMuffy.ResumeLayout(false);
            this.pnMuffy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private ToolStrip toolBar1;
        private ToolStripButton biId;
        private ToolStripButton biRel;
        private ToolStripButton biInt;
        private ToolStripButton biChar;
        private ToolStripButton biSkill;
        private ToolStripButton biMisc;
        private ToolStripButton biEP1;
        private ToolStripButton biEP2;
        private ToolStripButton biEP3;
        private ToolStripButton biEP6;
        private ToolStripButton biEP7;
        private ToolStripButton biEP9;
        private ToolStripButton biMax;
        private ToolStripButton biLezby;
        private ToolStripButton biCareer;
        private ToolStripButton biMore;
        private System.Windows.Forms.Panel pnId;
        private System.Windows.Forms.Panel pnCareer;
        private System.Windows.Forms.Panel pnSkill;
        private System.Windows.Forms.Panel pnChar;
        private System.Windows.Forms.Panel pnInt;
        private System.Windows.Forms.Panel pnRel;
        private System.Windows.Forms.Panel pnMisc;
        private System.Windows.Forms.Panel pnEP1;
        private System.Windows.Forms.Panel pnEP2;
        private System.Windows.Forms.Panel pnEP3;
        private System.Windows.Forms.Panel pnVoyage;
        private System.Windows.Forms.Panel pnEP7;
        private System.Windows.Forms.Panel pnEP9;
        private Ambertation.Windows.Forms.LabeledProgressBar pbRomance;
        private Ambertation.Windows.Forms.LabeledProgressBar pbFat;
        private Ambertation.Windows.Forms.LabeledProgressBar pbClean;
        private Ambertation.Windows.Forms.LabeledProgressBar pbCreative;
        private Ambertation.Windows.Forms.LabeledProgressBar pbBody;
        private Ambertation.Windows.Forms.LabeledProgressBar pbCharisma;
        private Ambertation.Windows.Forms.LabeledProgressBar pbMech;
        private Ambertation.Windows.Forms.LabeledProgressBar pbLogic;
        private Ambertation.Windows.Forms.LabeledProgressBar pbCooking;
        private Ambertation.Windows.Forms.LabeledProgressBar pbCareerLevel;
        private Ambertation.Windows.Forms.LabeledProgressBar pbCareerPerformance;
        private Ambertation.Windows.Forms.LabeledProgressBar pbAspBliz;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPolitics;
        private Ambertation.Windows.Forms.LabeledProgressBar pbMoney;
        private Ambertation.Windows.Forms.LabeledProgressBar pbCulture;
        private Ambertation.Windows.Forms.LabeledProgressBar pbEntertainment;
        private Ambertation.Windows.Forms.LabeledProgressBar pbEnvironment;
        private Ambertation.Windows.Forms.LabeledProgressBar pbFashion;
        private Ambertation.Windows.Forms.LabeledProgressBar pbFood;
        private Ambertation.Windows.Forms.LabeledProgressBar pbTravel;
        private Ambertation.Windows.Forms.LabeledProgressBar pbCrime;
        private Ambertation.Windows.Forms.LabeledProgressBar pbSports;
        private Ambertation.Windows.Forms.LabeledProgressBar pbAnimals;
        private Ambertation.Windows.Forms.LabeledProgressBar pbWeather;
        private Ambertation.Windows.Forms.LabeledProgressBar pbWork;
        private Ambertation.Windows.Forms.LabeledProgressBar pbSciFi;
        private Ambertation.Windows.Forms.LabeledProgressBar pbToys;
        private Ambertation.Windows.Forms.LabeledProgressBar pbSchool;
        private Ambertation.Windows.Forms.LabeledProgressBar pbHealth;
        private Ambertation.Windows.Forms.LabeledProgressBar pbParanormal;
        private Ambertation.Windows.Forms.LabeledProgressBar pbGNice;
        private Ambertation.Windows.Forms.LabeledProgressBar pbGPlayful;
        private Ambertation.Windows.Forms.LabeledProgressBar pbGActive;
        private Ambertation.Windows.Forms.LabeledProgressBar pbGOutgoing;
        private Ambertation.Windows.Forms.LabeledProgressBar pbGNeat;
        private Ambertation.Windows.Forms.LabeledProgressBar pbNice;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPlayful;
        private Ambertation.Windows.Forms.LabeledProgressBar pbActive;
        private Ambertation.Windows.Forms.LabeledProgressBar pbOutgoing;
        private Ambertation.Windows.Forms.LabeledProgressBar pbNeat;
        private Ambertation.Windows.Forms.LabeledProgressBar pbWoman;
        private Ambertation.Windows.Forms.LabeledProgressBar pbMan;
        private Ambertation.Windows.Forms.LabeledProgressBar pbAspCur;
        private Ambertation.Windows.Forms.LabeledProgressBar pbLastGrade;
        private Ambertation.Windows.Forms.LabeledProgressBar pbEffort;
        private Ambertation.Windows.Forms.LabeledProgressBar pbUniTime;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPetEating;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPetOutside;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPetPlaying;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPetSpooky;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPetSleep;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPetToy;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPetWeather;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPetPets;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPetAnimals;
        private Ambertation.Windows.Forms.LabeledProgressBar pbhbenth;
        private Ambertation.Windows.Forms.LabeledProgressBar pbReputate;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPupbody;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPupClean;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPupCreative;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPupCharisma;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPupMech;
        private Ambertation.Windows.Forms.LabeledProgressBar pbPupLogic;
        private Ambertation.Windows.Forms.LabeledProgressBar pbArty;
        private Ambertation.Windows.Forms.LabeledProgressBar pbMusic;
        private Ambertation.Windows.Forms.LabeledProgressBar lpRetirement;
        private Ambertation.Windows.Forms.XPTaskBoxSimple bTaskBox1;
        private Ambertation.Windows.Forms.XPTaskBoxSimple bTaskBox2;
        private Ambertation.Windows.Forms.XPTaskBoxSimple bTaskBox3;
        private Ambertation.Windows.Forms.XPTaskBoxSimple bTaskBox4;
        private Ambertation.Windows.Forms.XPTaskBoxSimple srcTb;
        private Ambertation.Windows.Forms.XPTaskBoxSimple dstTb;
        private Ambertation.Windows.Forms.XPTaskBoxSimple Pubes;
        private Ambertation.Windows.Forms.XPTaskBoxSimple Nipples;
        private Ambertation.Windows.Forms.XPTaskBoxSimple tbfemdik;
        private Ambertation.Windows.Forms.XPTaskBoxSimple Various;
        private Ambertation.Windows.Forms.XPTaskBoxSimple tbpersonflags;
        private Ambertation.Windows.Forms.XPTaskBoxSimple tbSeminfo;
        private Ambertation.Windows.Forms.XPTaskBoxSimple tbMotiveDec;
        private System.Windows.Forms.LinkLabel llep3openinfo;
        private ContextMenuStrip mbiLink;
        private ContextMenuStrip miRel;
        private ToolStripMenuItem miAddRelation;
        private ToolStripMenuItem mbiMax;
        private ToolStripMenuItem miRand;
        private ToolStripMenuItem miOpenChar;
        private ToolStripMenuItem miOpenDNA;
        private ToolStripMenuItem miOpenFamily;
        private ToolStripMenuItem miOpenCloth;
        private ToolStripMenuItem miMore;
        private ToolStripMenuItem miRelink;
        private ToolStripMenuItem miOpenWf;
        private ToolStripMenuItem miOpenMem;
        private ToolStripMenuItem miOpenBadge;
        private ToolStripMenuItem mbiMaxThisRel;
        private ToolStripMenuItem mbiMaxKnownRel;
        private ToolStripMenuItem miOpenSCOR;
        private ToolStripMenuItem miRemRelation;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem3;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel pnHumanChar;
        private Panel pnPetChar;
        private Panel pnSimInt;
        private Panel pnPetInt;
        private Panel pnPenis;
        private Panel pnMuffy;
        private TextBox tbNTPerfume;
        private TextBox tbNTLove;
        private TextBox tbEp3Flag;
        private TextBox tbEp3Lot;
        private TextBox tbEp3Salery;
        private TextBox tbhdaysleft;
        private TextBox tbUnlocksUsed;
        private TextBox tbUnlockPts;
        private TextBox tbLtAsp;
        private TextBox tbBugColl;
        private TextBox tbpension;
        internal TextBox tbaccholidays;
        internal TextBox tbsinstance;
        internal TextBox tb7social;
        internal TextBox tb7fun;
        internal TextBox tb7hygiene;
        internal TextBox tb7energy;
        internal TextBox tb7bladder;
        internal TextBox tb7comfort;
        internal TextBox tb7hunger;
        internal TextBox tbsimdescfamname;
        internal TextBox tbfaminst;
        internal TextBox tbsim;
        internal TextBox tbage;
        internal TextBox tbsimdescname;
        internal TextBox tbschooltype;
        internal TextBox tbcareervalue;
        internal TextBox tblifelinescore;
        internal TextBox tbunlinked;
        internal TextBox tbagedur;
        internal TextBox tbprevdays;
        internal TextBox tbvoice;
        internal TextBox tbnpc;
        internal TextBox tbautonomy;
        internal TextBox tbinfluence;
        internal TextBox tbsemester;
        internal TextBox tbmajor;
        internal TextBox tbstatmot;
        internal TextBox tbdecScratc;
        internal TextBox tbdecAmor;
        internal TextBox tbdecFun;
        internal TextBox tbdecShop;
        internal TextBox tbdecSocial;
        internal TextBox tbdecHygiene;
        internal TextBox tbdecEnergy;
        internal TextBox tbdecBladder;
        internal TextBox tbdecComfort;
        internal TextBox tbdecHunger;
        private Label label49;
        internal RadioButton rbmale;
        internal RadioButton rbfemale;
        private Label label48;
        internal ComboBox cblifesection;
        internal PictureBox pbImage;
        private Label label13;
        private Label label10;
        private Label label1;
        private Label label2;
        internal ComboBox cbzodiac;
        private Label label47;
        private Label label77;
        internal ComboBox cbgrade;
        internal ComboBox cbschooltype;
        private Label label78;
        private Label label50;
        internal ComboBox cbcareer;
        private Label label60;
        internal ComboBox cbaspiration;
        private Label label46;
        private Label label70;
        private Label label69;
        private CheckBox cbignoretraversal;
        private CheckBox cbpasspeople;
        private CheckBox cbpasswalls;
        private CheckBox cbpassobject;
        private CheckBox cbisghost;
        private CheckBox cbfit;
        private CheckBox cbpreginv;
        private CheckBox cbpreghalf;
        private CheckBox cbpregfull;
        private CheckBox cbfat;
        private Label label96;
        private Label label95;
        private Label label94;
        private Label label90;
        private Label label87;
        private Label label86;
        internal Label label103;
        internal Label label101;
        internal CheckBox cboncampus;
        internal ComboBox cbmajor;
        internal Label label98;
        private Label label3;
        private SimPe.PackedFiles.Wrapper.SimBusinessList sblb;
        private SimPe.PackedFiles.Wrapper.SimRelationPoolControl lv;
        private SimPe.PackedFiles.Wrapper.PetTraitSelect ptPigpen;
        private SimPe.PackedFiles.Wrapper.PetTraitSelect ptAggres;
        private SimPe.PackedFiles.Wrapper.PetTraitSelect ptIndep;
        private SimPe.PackedFiles.Wrapper.PetTraitSelect ptHyper;
        private SimPe.PackedFiles.Wrapper.PetTraitSelect ptGifted;
        private SimPe.PackedFiles.UserInterface.CommonSrel srcRel;
        private SimPe.PackedFiles.UserInterface.CommonSrel dstRel;
        private EnumComboBox cbEp3Asgn;
        public EnumComboBox cbSpecies;
        private EnumComboBox cbHobbyPre;
        private System.ComponentModel.IContainer components;
        private CheckedListBox lbTraits;
        private PictureBox pbtraits;
        private Label label4;
        private CheckedListBox lbTurnOn;
        private Label label5;
        private CheckedListBox lbTurnOff;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label11;
        private Label label12;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label21;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label26;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label29;
        private Label labelcol;
        private ListView lvCollectibles;
        private ImageList ilCollectibles;
        private ComboBox cbHobbyEnth;
        private Label label27;
        private Label label31;
        private Label label30;
        private Label label28;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label40;
        private Label label41;
        internal ComboBox cbaspiration2;
        private ComboBox cbBody;
        private ComboBox cbFaiths;
        private ComboBox cbDikcolour;
        private ComboBox cbDikstate;
        private ComboBox cbBallsize;
        private ComboBox cbDikgirth;
        private ComboBox cbDiklength;
        private Label lbDiklength;
        private Label lbBallsize;
        private Label lbDikgirth;
        private Label lbDikcolour;
        private Label lbDikstate;
        private Label lbBodee;
        private Label labelpubes;
        private Label labelgenital;
        private CheckBox cbpubetr;
        private CheckBox cbpuberd;
        private CheckBox cbpubebd;
        private CheckBox cbpubebn;
        private CheckBox cbpubebk;
        private CheckBox cbpubesh;
        private CheckBox cbpubeun;
        private CheckBox cbpubepy;
        private CheckBox cbpubesw;
        private CheckBox cbpubeca;
        private CheckBox cbpubeal;
        private CheckBox cbpubegy;
        private CheckBox cbpubetf;
        private CheckBox cbnipsgy;
        private CheckBox cbnipsun;
        private CheckBox cbnipspy;
        private CheckBox cbnipssw;
        private CheckBox cbnipsca;
        private CheckBox cbnipsna;
        private CheckBox cbnipssi;
        private CheckBox cbnipsma;
        private CheckBox cbnipswi;
        private CheckBox cbnipsfo;
        private CheckBox cbnipsit;
        private Label labelnipple;
        private Button btpubedic;
        private Button btProfile;
        private ToolTip toolTip1;
        private CheckBox cbhospital;
        private CheckBox cbonpill;
        private CheckBox cbmarker;
        private ComboBox cbSuburbs;
        private Label lbalcsub;
        private ComboBox cbservice;
        private Label lbservice;
        private Label lbaccholidays;
        private Label lbsubspec;
        private Label label42;
        private Label lbSplitChar;
        private Label lbFixedRes;
        private Label lbHousname;
        private PictureBox pbicon;
        private Label lbpostTitle;
        private Label lbReligion;
        private ComboBox cbpostTitle;
        private Label lbRetcareer;
        internal ComboBox cbRetirement;
        private Label lbpension;
        private Button btOriGuid;
        private CheckBox cbpfZomb;
        private CheckBox cbpfwants;
        private CheckBox cbpfvsmoke;
        private CheckBox cbpfvamp;
        private CheckBox cbpfperma;
        private CheckBox cbpfBigf;
        private CheckBox cbpfPlant;
        private CheckBox cbpfrunaw;
        private CheckBox cbpflyact;
        private CheckBox cbpflycar;
        private CheckBox cbpfwitch;
        private CheckBox cbpfroomy;
        private CheckBox cbstaynude;
        private CheckBox cbisslave;
        private Label lbVBFriend;
        private ComboBox cbVBFriend;
        private Label labelpenis;
        private CheckBox cbdickless;
        private CheckBox cbSenior;
        private CheckBox cbJunior;
        private CheckBox cbSopho;
        private CheckBox cbfreshman;
        private CheckBox cbexpelled;
        private CheckBox cbdroped;
        private CheckBox cbatclass;
        private CheckBox cbgraduate;
        private CheckBox cbprobation;
        private CheckBox cbGoodsem;
        private Label lbFemcolour;
        private CheckBox cbfembaldy;
        private CheckBox cbfemsmall;
        private CheckBox cbfembig;
        private CheckBox cbfemcirc;
        private ComboBox cbFemColour;
        private Label lbfaithinfo;
        private Label lbdecScratc;
        private Label lbdecAmor;
        private Label lbdecFun;
        private Label lbdecShop;
        private Label lbdecSocial;
        private Label lbdecHygiene;
        private Label lbdecEnergy;
        private Label lbdecBladder;
        private Label lbdecComfort;
        private Label lbdecHunger;
    }
}
