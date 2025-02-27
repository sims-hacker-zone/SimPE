/***************************************************************************
 *   Copyright (C) 2007 by Peter L Jones                                   *
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
 *   59 Temple Place - Suite 330, Boston, MA  32111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.WizAnimate
{
	internal class UI : System.Windows.Forms.Form, iBhavOperandWizForm
	{
		#region Form variables

		internal System.Windows.Forms.Panel pnWizAnimate;
		private FlowLayoutPanel flpnMain;
		private Panel pnObject;
		private ComboBox cbPickerObject;
		private TextBox tbValObject;
		private ComboBox cbdoObject;
		private Label label1;
		private FlowLayoutPanel flpnAnimType;
		private Label label4;
		private TextBox tbValAnimType;
		private ComboBox cbAnimType;
		private TextBox tbAnimType;
		private FlowLayoutPanel flpnAnim;
		private Label lbParam;
		private TextBox tbValAnim;
		private Button btnAnim;
		private TextBox tbAnim;
		private FlowLayoutPanel flpnEventScope;
		private Label label2;
		private ComboBox cbEventScope;
		private FlowLayoutPanel flpnEventTree;
		private LinkLabel llEvent;
		private TextBox tbValEventTree;
		private Button btnEventTree;
		private TextBox tbEventTree;
		private FlowLayoutPanel flpnOptions;
		private GroupBox groupBox1;
		private FlowLayoutPanel flpnOptions1;
		private CheckBox ckbFlipped;
		private CheckBox ckbAnimSpeed;
		private CheckBox ckbParam;
		private CheckBox ckbInterruptible;
		private CheckBox ckbStartTag;
		private CheckBox ckbLoopCount;
		private CheckBox ckbTransToIdle;
		private CheckBox ckbBlendOut;
		private CheckBox ckbBlendIn;
		private GroupBox groupBox2;
		private FlowLayoutPanel flpnOptions2;
		private CheckBox ckbFlipTemp3;
		private CheckBox ckbSync;
		private CheckBox ckbAlignBlend;
		private CheckBox ckbControllerIsSource;
		private CheckBox ckbNotHurryable;
		private Panel pnDoidOptions;
		private CheckBox ckbAttrPicker;
		private CheckBox ckbDecimal;
		private Panel pnIKObject;
		private ComboBox cbPickerIK;
		private TextBox tbValIK;
		private ComboBox cbdoIK;
		private Label label3;
		private GroupBox gbPriority;
		private ComboBox cbPriority;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion


		/// <summary>
		/// Initialise the Wizard user interface
		/// </summary>
		/// <param name="mode">Specify whether the wizard is for Animate Object, Sim or Overlay</param>
		public UI(String mode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			#region AnimNames
			cbAnimType.Items.Clear();
			cbAnimType.Items.AddRange(
				new String[]
				{
					"AdultAnims",
					"ChildAnims",
					"SocialAnims",
					"LocoAnims",
					"ObjectAnims",
					"ToddlerAnims",
					"TeenAnims",
					"ElderAnims",
					"CatAnims",
					"DogAnims",
					"BabyAnims",
					"ReachAnims",
					"PuppyAnims",
					"KittenAnims",
					"SmallDogAnims",
					"ElderLargeDogAnims",
					"ElderSmallDogAnims",
					"ElderCatAnims",
				}
			);
			// Two-byte values
			//cbAnimType.Items.AddRange(new String[] {
			//            "ObjectElderAnims",
			//            "ObjectTeenAnims",
			//            "ObjectChildAnims",
			//            "ObjectToddlerAnims",
			//            "ObjectLargeDogAnims",
			//            "ObjectCatAnims",
			//            "ObjectPuppyAnims",
			//            "ObjectKittenAnims",
			//            "ObjectSmallDogAnims",
			//        });
			#endregion

			this.mode = mode;
			switch (mode)
			{
				case "bwp_Object":
					lckbOptions1 = new List<CheckBox>(
						new CheckBox[]
						{
							ckbFlipped,
							ckbAnimSpeed,
							ckbParam,
							ckbInterruptible,
							ckbStartTag,
							ckbLoopCount,
							ckbBlendOut,
							ckbBlendIn,
						}
					);
					lckbOptions2 = new List<CheckBox>(
						new CheckBox[]
						{
							ckbFlipTemp3,
							null,
							ckbSync,
							ckbAlignBlend,
							ckbNotHurryable,
						}
					);
					this.flpnMain.Controls.Remove(flpnAnimType);
					this.flpnMain.Controls.Remove(pnIKObject);
					this.flpnOptions.Controls.Remove(gbPriority);
					break;
				case "bwp_Sim":
					lckbOptions1 = new List<CheckBox>(
						new CheckBox[]
						{
							ckbFlipped,
							ckbAnimSpeed,
							ckbParam,
							ckbInterruptible,
							ckbStartTag,
							ckbTransToIdle,
							ckbBlendOut,
							ckbBlendIn,
						}
					);
					lckbOptions2 = new List<CheckBox>(
						new CheckBox[]
						{
							ckbFlipTemp3,
							ckbSync,
							null,
							null,
							ckbSync,
							ckbControllerIsSource,
							ckbNotHurryable,
						}
					);
					this.flpnMain.Controls.Remove(pnObject);
					break;
				case "bwp_Overlay":
					lckbOptions1 = new List<CheckBox>(
						new CheckBox[]
						{
							ckbFlipped,
							ckbAnimSpeed,
							ckbParam,
							ckbInterruptible,
							ckbStartTag,
							ckbLoopCount,
							ckbBlendOut,
							ckbBlendIn,
						}
					);
					lckbOptions2 = new List<CheckBox>(
						new CheckBox[]
						{
							ckbFlipTemp3,
							null,
							null,
							null,
							ckbSync,
							ckbAlignBlend,
						}
					);
					this.flpnMain.Controls.Remove(pnIKObject);
					break;
				default:
					throw new ArgumentException(
						"Argument must match bwp_{Object,Sim,Overlay}",
						"mode"
					);
			}
			lckb = new List<CheckBox>(
				new CheckBox[]
				{
					ckbAnimSpeed,
					ckbInterruptible,
					ckbStartTag,
					ckbLoopCount,
					ckbTransToIdle,
					ckbBlendOut,
					ckbBlendIn,
					ckbFlipTemp3,
					ckbSync,
					ckbAlignBlend,
					ckbControllerIsSource,
					ckbNotHurryable,
				}
			);

			pnWizAnimate.Height = flpnOptions.Bottom;
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

			inst = null;
		}

		private String mode = "";
		private Instruction inst = null;

		private DataOwnerControl doidObject = null;
		private DataOwnerControl doidAnim = null;
		private DataOwnerControl doidEvent = null;
		private DataOwnerControl doidAnimType = null;
		private DataOwnerControl doidIK = null;

		private bool internalchg = false;

		private List<CheckBox> lckbOptions1;
		private List<CheckBox> lckbOptions2;
		private List<CheckBox> lckb;

		private void doCkbParam()
		{
			if (ckbParam.Checked)
			{
				lbParam.Text = ((String)lbParam.Tag).Split(new char[] { '|' })[0];
			}
			else
			{
				lbParam.Text = ((String)lbParam.Tag).Split(new char[] { '|' })[1];
				doStrValue(doidAnim.Value, tbAnim);
			}
			btnAnim.Visible = tbAnim.Visible = !ckbParam.Checked;
		}

		private void doStrChooser(TextBox tbVal, TextBox strText)
		{
			pjse.FileTable.Entry[] items = pjse.FileTable.GFT[
				(uint)SimPe.Data.MetaData.STRING_FILE,
				inst.Parent.GroupForScope(AnimScope()),
				(uint)AnimInstance()
			];

			if (items == null || items.Length == 0)
			{
				MessageBox.Show(
					pjse.Localization.GetString("bow_noStrings")
						+ " ("
						+ pjse.Localization.GetString(AnimScope().ToString())
						+ ")"
				);
				return; // eek!
			}

			SimPe.PackedFiles.Wrapper.StrWrapper str = new StrWrapper();
			str.ProcessData(items[0].PFD, items[0].Package);

			int i = (new StrChooser(true)).Strnum(str);
			if (i >= 0)
			{
				bool savedState = internalchg;
				internalchg = true;
				tbVal.Text = "0x" + SimPe.Helper.HexString((ushort)i);
				doStrValue((ushort)i, strText);
				internalchg = savedState;
			}
		}

		private bool IsAnim(ushort i)
		{
			try
			{
				return IsAnim((GS.GlobalStr)i);
			}
			catch { }
			return false;
		}

		private bool IsAnim(GS.GlobalStr g)
		{
			return IsAnim(g.ToString());
		}

		private bool IsAnim(String s)
		{
			return s.EndsWith("Anims");
		}

		private Scope AnimScope()
		{
			if (mode.Equals("bwp_Object"))
				return Scope.Private;
			return (this.doidAnimType.Value == 0x80) ? Scope.Global : Scope.Private;
		}

		private GS.GlobalStr AnimInstance()
		{
			if (mode.Equals("bwp_Object"))
				return GS.GlobalStr.ObjectAnims;

			if (this.doidAnimType.Value == 0x80)
				return GS.GlobalStr.AdultAnims;
			if (IsAnim(this.doidAnimType.Value))
				return (GS.GlobalStr)this.doidAnimType.Value;
			return GS.GlobalStr.ObjectAnims;
		}

		private void doStrValue(ushort strno, TextBox strText)
		{
			strText.Text = ((BhavWiz)inst).readStr(
				AnimScope(),
				AnimInstance(),
				strno,
				-1,
				pjse.Detail.ErrorNames
			);
		}

		private void doidAnimType_DataOwnerControlChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;
			internalchg = true;

			try
			{
				cbAnimType.SelectedIndex = cbAnimType.Items.IndexOf(
					((GS.GlobalStr)doidAnimType.Value).ToString()
				);
				tbAnimType.Text =
					(cbAnimType.SelectedIndex >= 0)
						? this.cbAnimType.SelectedItem.ToString()
						: "---";
			}
			finally
			{
				internalchg = false;
				doStrValue(doidAnim.Value, tbAnim);
			}
		}

		private void doidAnim_DataOwnerControlChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;
			doStrValue(doidAnim.Value, tbAnim);
		}

		private void doidEvent_DataOwnerControlChanged(object sender, EventArgs e)
		{
			bool found = false;
			tbEventTree.Text = pjse.BhavWiz.bhavName(
				inst.Parent,
				doidEvent.Value,
				ref found
			);
			if (!found)
				tbEventTree.Text = "---";
			llEvent.Enabled = found;
		}

		private byte getScope(byte scope)
		{
			return (byte)(
				(cbEventScope.SelectedIndex >= 0) ? cbEventScope.SelectedIndex : scope
			);
		}

		private byte getPriority(byte priority)
		{
			return (byte)(
				(cbPriority.SelectedIndex >= 0) ? cbPriority.SelectedIndex : priority
			);
		}

		private byte getOptions(List<CheckBox> lckbOptions, Boolset options)
		{
			for (int i = 0; i < lckbOptions.Count; i++)
				if (lckbOptions[i] != null)
					options[i] = lckbOptions[i].Checked;
			return options;
		}

		#region iBhavOperandWizForm
		public Panel WizPanel => this.pnWizAnimate;

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			wrappedByteArray ops1 = inst.Operands;
			wrappedByteArray ops2 = inst.Reserved1;
			Boolset options1 = null;
			Boolset options2 = null;
			int scope = 0;
			int priority = -1;

			internalchg = true;

			foreach (CheckBox c in lckb)
				c.Visible = false;

			doidAnim = new DataOwnerControl(
				inst,
				null,
				null,
				tbValAnim,
				ckbDecimal,
				ckbAttrPicker,
				null,
				0x07,
				BhavWiz.ToShort(ops1[0], ops1[1])
			);
			doidAnim.DataOwnerControlChanged += new EventHandler(
				doidAnim_DataOwnerControlChanged
			);

			options1 = ops1[2];

			doidEvent = new DataOwnerControl(
				inst,
				null,
				null,
				tbValEventTree,
				ckbDecimal,
				ckbAttrPicker,
				null,
				0x07,
				BhavWiz.ToShort(ops1[4], ops1[5])
			);
			doidEvent.DataOwnerControlChanged += new EventHandler(
				doidEvent_DataOwnerControlChanged
			);

			switch (mode)
			{
				case "bwp_Object":
					doidObject = new DataOwnerControl(
						inst,
						cbdoObject,
						cbPickerObject,
						tbValObject,
						ckbDecimal,
						ckbAttrPicker,
						null,
						ops1[6],
						BhavWiz.ToShort(ops1[7], ops2[0])
					);
					scope = ops2[1];
					options2 = ops2[2];
					break;

				case "bwp_Sim":
					doidAnimType = new DataOwnerControl(
						inst,
						null,
						null,
						tbValAnimType,
						ckbDecimal,
						ckbAttrPicker,
						null,
						0x07,
						(byte)ops1[6]
					);
					doidAnimType.DataOwnerControlChanged += new EventHandler(
						doidAnimType_DataOwnerControlChanged
					);
					scope = ops1[7];
					options2 = ops2[0];
					doidIK = new DataOwnerControl(
						inst,
						cbdoIK,
						cbPickerIK,
						tbValIK,
						ckbDecimal,
						ckbAttrPicker,
						null,
						ops2[1],
						BhavWiz.ToShort(ops2[2], ops2[3])
					);
					priority = ops2[4];
					break;

				case "bwp_Overlay":
					doidObject = new DataOwnerControl(
						inst,
						cbdoObject,
						cbPickerObject,
						tbValObject,
						ckbDecimal,
						ckbAttrPicker,
						null,
						ops1[6],
						BhavWiz.ToShort(ops1[7], ops2[0])
					);
					doidAnimType = new DataOwnerControl(
						inst,
						null,
						null,
						tbValAnimType,
						ckbDecimal,
						ckbAttrPicker,
						null,
						0x07,
						(byte)ops2[1]
					);
					doidAnimType.DataOwnerControlChanged += new EventHandler(
						doidAnimType_DataOwnerControlChanged
					);
					if (inst.NodeVersion != 0)
					{
						priority = ops2[3];
						ckbNotHurryable.Checked = (ops2[4] & 0x01) != 0;
						ckbNotHurryable.Visible = true;
					}
					else
						priority = ops2[4];
					scope = ops2[6];
					options2 = ops2[7];
					break;
			}

			for (int i = 0; i < lckbOptions1.Count; i++)
				if (lckbOptions1[i] != null)
				{
					lckbOptions1[i].Visible = true;
					lckbOptions1[i].Checked = options1[i];
				}

			for (int i = 0; i < lckbOptions2.Count; i++)
				if (lckbOptions2[i] != null)
				{
					lckbOptions2[i].Visible = true;
					lckbOptions2[i].Checked = options2[i];
				}

			switch (scope)
			{
				case 0:
					cbEventScope.SelectedIndex = 0;
					break;
				case 1:
					cbEventScope.SelectedIndex = 1;
					break;
				default:
					cbEventScope.SelectedIndex = 2;
					break;
			}

			internalchg = false;

			if (!mode.Equals("bwp_Object"))
				doidAnimType_DataOwnerControlChanged(null, null);
			else
				doidAnim_DataOwnerControlChanged(null, null);
			doidEvent_DataOwnerControlChanged(null, null);
			ckbParam_CheckedChanged(null, null);
			ckbFlipTemp3_CheckedChanged(null, null);
			if (priority < cbPriority.Items.Count)
				cbPriority.SelectedIndex = priority;
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops1 = inst.Operands;
				wrappedByteArray ops2 = inst.Reserved1;

				BhavWiz.FromShort(ref ops1, 0, doidAnim.Value);

				ops1[2] = getOptions(lckbOptions1, ops1[2]);

				BhavWiz.FromShort(ref ops1, 4, doidEvent.Value);
				byte[] lohi = { 0, 0 };

				switch (mode)
				{
					case "bwp_Object":
						ops1[6] = doidObject.DataOwner;
						BhavWiz.FromShort(ref lohi, 0, doidObject.Value);
						ops1[7] = lohi[0];
						ops2[0] = lohi[1];
						ops2[1] = getScope(ops2[1]);
						ops2[2] = getOptions(lckbOptions2, ops2[2]);
						break;

					case "bwp_Sim":
						ops1[6] = (byte)(doidAnimType.Value & 0xff);
						ops1[7] = getScope(ops1[7]);
						ops2[0] = getOptions(lckbOptions2, ops2[0]);
						ops2[1] = doidIK.DataOwner;
						BhavWiz.FromShort(ref ops2, 2, doidIK.Value);
						ops2[4] = getPriority(ops2[4]);
						break;

					case "bwp_Overlay":
						ops1[6] = doidObject.DataOwner;
						BhavWiz.FromShort(ref lohi, 0, doidObject.Value);
						ops1[7] = lohi[0];
						ops2[0] = lohi[1];
						ops2[1] = (byte)(doidAnimType.Value & 0xff);

						if (inst.NodeVersion != 0)
						{
							ops2[3] = getPriority(ops2[3]);
							Boolset options3 = ops2[4];
							options3[0] = ckbNotHurryable.Checked;
							ops2[4] = options3;
						}
						else
							ops2[4] = getPriority(ops2[4]);

						ops2[6] = getScope(ops2[6]);
						ops2[7] = getOptions(lckbOptions2, ops2[7]);
						break;
				}
			}
			return inst;
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(UI));
			this.pnWizAnimate = new System.Windows.Forms.Panel();
			this.flpnMain = new System.Windows.Forms.FlowLayoutPanel();
			this.pnObject = new System.Windows.Forms.Panel();
			this.cbPickerObject = new System.Windows.Forms.ComboBox();
			this.tbValObject = new System.Windows.Forms.TextBox();
			this.cbdoObject = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pnIKObject = new System.Windows.Forms.Panel();
			this.cbPickerIK = new System.Windows.Forms.ComboBox();
			this.tbValIK = new System.Windows.Forms.TextBox();
			this.cbdoIK = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.pnDoidOptions = new System.Windows.Forms.Panel();
			this.ckbAttrPicker = new System.Windows.Forms.CheckBox();
			this.ckbDecimal = new System.Windows.Forms.CheckBox();
			this.flpnAnimType = new System.Windows.Forms.FlowLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.tbValAnimType = new System.Windows.Forms.TextBox();
			this.cbAnimType = new System.Windows.Forms.ComboBox();
			this.tbAnimType = new System.Windows.Forms.TextBox();
			this.flpnAnim = new System.Windows.Forms.FlowLayoutPanel();
			this.lbParam = new System.Windows.Forms.Label();
			this.tbValAnim = new System.Windows.Forms.TextBox();
			this.btnAnim = new System.Windows.Forms.Button();
			this.tbAnim = new System.Windows.Forms.TextBox();
			this.flpnEventScope = new System.Windows.Forms.FlowLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.cbEventScope = new System.Windows.Forms.ComboBox();
			this.flpnEventTree = new System.Windows.Forms.FlowLayoutPanel();
			this.llEvent = new System.Windows.Forms.LinkLabel();
			this.tbValEventTree = new System.Windows.Forms.TextBox();
			this.btnEventTree = new System.Windows.Forms.Button();
			this.tbEventTree = new System.Windows.Forms.TextBox();
			this.flpnOptions = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.flpnOptions1 = new System.Windows.Forms.FlowLayoutPanel();
			this.ckbFlipped = new System.Windows.Forms.CheckBox();
			this.ckbAnimSpeed = new System.Windows.Forms.CheckBox();
			this.ckbParam = new System.Windows.Forms.CheckBox();
			this.ckbInterruptible = new System.Windows.Forms.CheckBox();
			this.ckbStartTag = new System.Windows.Forms.CheckBox();
			this.ckbLoopCount = new System.Windows.Forms.CheckBox();
			this.ckbTransToIdle = new System.Windows.Forms.CheckBox();
			this.ckbBlendOut = new System.Windows.Forms.CheckBox();
			this.ckbBlendIn = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.flpnOptions2 = new System.Windows.Forms.FlowLayoutPanel();
			this.ckbFlipTemp3 = new System.Windows.Forms.CheckBox();
			this.ckbSync = new System.Windows.Forms.CheckBox();
			this.ckbAlignBlend = new System.Windows.Forms.CheckBox();
			this.ckbControllerIsSource = new System.Windows.Forms.CheckBox();
			this.ckbNotHurryable = new System.Windows.Forms.CheckBox();
			this.gbPriority = new System.Windows.Forms.GroupBox();
			this.cbPriority = new System.Windows.Forms.ComboBox();
			this.pnWizAnimate.SuspendLayout();
			this.flpnMain.SuspendLayout();
			this.pnObject.SuspendLayout();
			this.pnIKObject.SuspendLayout();
			this.pnDoidOptions.SuspendLayout();
			this.flpnAnimType.SuspendLayout();
			this.flpnAnim.SuspendLayout();
			this.flpnEventScope.SuspendLayout();
			this.flpnEventTree.SuspendLayout();
			this.flpnOptions.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.flpnOptions1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.flpnOptions2.SuspendLayout();
			this.gbPriority.SuspendLayout();
			this.SuspendLayout();
			//
			// pnWizAnimate
			//
			resources.ApplyResources(this.pnWizAnimate, "pnWizAnimate");
			this.pnWizAnimate.Controls.Add(this.flpnMain);
			this.pnWizAnimate.Name = "pnWizAnimate";
			//
			// flpnMain
			//
			resources.ApplyResources(this.flpnMain, "flpnMain");
			this.flpnMain.Controls.Add(this.pnObject);
			this.flpnMain.Controls.Add(this.pnIKObject);
			this.flpnMain.Controls.Add(this.pnDoidOptions);
			this.flpnMain.Controls.Add(this.flpnAnimType);
			this.flpnMain.Controls.Add(this.flpnAnim);
			this.flpnMain.Controls.Add(this.flpnEventScope);
			this.flpnMain.Controls.Add(this.flpnEventTree);
			this.flpnMain.Controls.Add(this.flpnOptions);
			this.flpnMain.Name = "flpnMain";
			//
			// pnObject
			//
			this.pnObject.Controls.Add(this.cbPickerObject);
			this.pnObject.Controls.Add(this.tbValObject);
			this.pnObject.Controls.Add(this.cbdoObject);
			this.pnObject.Controls.Add(this.label1);
			resources.ApplyResources(this.pnObject, "pnObject");
			this.pnObject.Name = "pnObject";
			//
			// cbPickerObject
			//
			this.cbPickerObject.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbPickerObject.DropDownWidth = 384;
			resources.ApplyResources(this.cbPickerObject, "cbPickerObject");
			this.cbPickerObject.Name = "cbPickerObject";
			this.cbPickerObject.TabStop = false;
			//
			// tbValObject
			//
			resources.ApplyResources(this.tbValObject, "tbValObject");
			this.tbValObject.Name = "tbValObject";
			this.tbValObject.TabStop = false;
			//
			// cbdoObject
			//
			this.cbdoObject.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbdoObject.DropDownWidth = 384;
			resources.ApplyResources(this.cbdoObject, "cbdoObject");
			this.cbdoObject.Name = "cbdoObject";
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// pnIKObject
			//
			this.pnIKObject.Controls.Add(this.cbPickerIK);
			this.pnIKObject.Controls.Add(this.tbValIK);
			this.pnIKObject.Controls.Add(this.cbdoIK);
			this.pnIKObject.Controls.Add(this.label3);
			resources.ApplyResources(this.pnIKObject, "pnIKObject");
			this.pnIKObject.Name = "pnIKObject";
			//
			// cbPickerIK
			//
			this.cbPickerIK.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbPickerIK.DropDownWidth = 384;
			resources.ApplyResources(this.cbPickerIK, "cbPickerIK");
			this.cbPickerIK.Name = "cbPickerIK";
			this.cbPickerIK.TabStop = false;
			//
			// tbValIK
			//
			resources.ApplyResources(this.tbValIK, "tbValIK");
			this.tbValIK.Name = "tbValIK";
			this.tbValIK.TabStop = false;
			//
			// cbdoIK
			//
			this.cbdoIK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbdoIK.DropDownWidth = 384;
			resources.ApplyResources(this.cbdoIK, "cbdoIK");
			this.cbdoIK.Name = "cbdoIK";
			//
			// label3
			//
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			//
			// pnDoidOptions
			//
			this.pnDoidOptions.Controls.Add(this.ckbAttrPicker);
			this.pnDoidOptions.Controls.Add(this.ckbDecimal);
			resources.ApplyResources(this.pnDoidOptions, "pnDoidOptions");
			this.pnDoidOptions.Name = "pnDoidOptions";
			//
			// ckbAttrPicker
			//
			resources.ApplyResources(this.ckbAttrPicker, "ckbAttrPicker");
			this.ckbAttrPicker.Name = "ckbAttrPicker";
			//
			// ckbDecimal
			//
			resources.ApplyResources(this.ckbDecimal, "ckbDecimal");
			this.ckbDecimal.Name = "ckbDecimal";
			//
			// flpnAnimType
			//
			resources.ApplyResources(this.flpnAnimType, "flpnAnimType");
			this.flpnAnimType.Controls.Add(this.label4);
			this.flpnAnimType.Controls.Add(this.tbValAnimType);
			this.flpnAnimType.Controls.Add(this.cbAnimType);
			this.flpnAnimType.Controls.Add(this.tbAnimType);
			this.flpnAnimType.Name = "flpnAnimType";
			//
			// label4
			//
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			//
			// tbValAnimType
			//
			resources.ApplyResources(this.tbValAnimType, "tbValAnimType");
			this.tbValAnimType.Name = "tbValAnimType";
			//
			// cbAnimType
			//
			this.cbAnimType.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbAnimType.DropDownWidth = 200;
			this.cbAnimType.FormattingEnabled = true;
			resources.ApplyResources(this.cbAnimType, "cbAnimType");
			this.cbAnimType.Name = "cbAnimType";
			this.cbAnimType.TabStop = false;
			this.cbAnimType.SelectedIndexChanged += new System.EventHandler(
				this.cbAnimType_SelectedIndexChanged
			);
			//
			// tbAnimType
			//
			resources.ApplyResources(this.tbAnimType, "tbAnimType");
			this.tbAnimType.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbAnimType.Name = "tbAnimType";
			this.tbAnimType.ReadOnly = true;
			this.tbAnimType.TabStop = false;
			//
			// flpnAnim
			//
			resources.ApplyResources(this.flpnAnim, "flpnAnim");
			this.flpnAnim.Controls.Add(this.lbParam);
			this.flpnAnim.Controls.Add(this.tbValAnim);
			this.flpnAnim.Controls.Add(this.btnAnim);
			this.flpnAnim.Controls.Add(this.tbAnim);
			this.flpnAnim.Name = "flpnAnim";
			//
			// lbParam
			//
			resources.ApplyResources(this.lbParam, "lbParam");
			this.lbParam.Name = "lbParam";
			this.lbParam.Tag = "Param|Animation String";
			//
			// tbValAnim
			//
			resources.ApplyResources(this.tbValAnim, "tbValAnim");
			this.tbValAnim.Name = "tbValAnim";
			//
			// btnAnim
			//
			resources.ApplyResources(this.btnAnim, "btnAnim");
			this.btnAnim.Name = "btnAnim";
			this.btnAnim.Click += new System.EventHandler(this.btnAnim_Click);
			//
			// tbAnim
			//
			resources.ApplyResources(this.tbAnim, "tbAnim");
			this.tbAnim.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbAnim.Name = "tbAnim";
			this.tbAnim.ReadOnly = true;
			this.tbAnim.TabStop = false;
			//
			// flpnEventScope
			//
			resources.ApplyResources(this.flpnEventScope, "flpnEventScope");
			this.flpnEventScope.Controls.Add(this.label2);
			this.flpnEventScope.Controls.Add(this.cbEventScope);
			this.flpnEventScope.Name = "flpnEventScope";
			//
			// label2
			//
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			this.label2.Tag = "";
			//
			// cbEventScope
			//
			this.cbEventScope.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbEventScope.FormattingEnabled = true;
			this.cbEventScope.Items.AddRange(
				new object[]
				{
					resources.GetString("cbEventScope.Items"),
					resources.GetString("cbEventScope.Items1"),
					resources.GetString("cbEventScope.Items2"),
				}
			);
			resources.ApplyResources(this.cbEventScope, "cbEventScope");
			this.cbEventScope.Name = "cbEventScope";
			//
			// flpnEventTree
			//
			resources.ApplyResources(this.flpnEventTree, "flpnEventTree");
			this.flpnEventTree.Controls.Add(this.llEvent);
			this.flpnEventTree.Controls.Add(this.tbValEventTree);
			this.flpnEventTree.Controls.Add(this.btnEventTree);
			this.flpnEventTree.Controls.Add(this.tbEventTree);
			this.flpnEventTree.Name = "flpnEventTree";
			//
			// llEvent
			//
			resources.ApplyResources(this.llEvent, "llEvent");
			this.llEvent.Name = "llEvent";
			this.llEvent.TabStop = true;
			this.llEvent.UseCompatibleTextRendering = true;
			this.llEvent.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.llEvent_LinkClicked
				);
			//
			// tbValEventTree
			//
			resources.ApplyResources(this.tbValEventTree, "tbValEventTree");
			this.tbValEventTree.Name = "tbValEventTree";
			//
			// btnEventTree
			//
			resources.ApplyResources(this.btnEventTree, "btnEventTree");
			this.btnEventTree.Name = "btnEventTree";
			this.btnEventTree.Click += new System.EventHandler(this.btnEventTree_Click);
			//
			// tbEventTree
			//
			resources.ApplyResources(this.tbEventTree, "tbEventTree");
			this.tbEventTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbEventTree.Name = "tbEventTree";
			this.tbEventTree.ReadOnly = true;
			this.tbEventTree.TabStop = false;
			//
			// flpnOptions
			//
			resources.ApplyResources(this.flpnOptions, "flpnOptions");
			this.flpnOptions.Controls.Add(this.groupBox1);
			this.flpnOptions.Controls.Add(this.groupBox2);
			this.flpnOptions.Controls.Add(this.gbPriority);
			this.flpnOptions.Name = "flpnOptions";
			//
			// groupBox1
			//
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Controls.Add(this.flpnOptions1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			//
			// flpnOptions1
			//
			resources.ApplyResources(this.flpnOptions1, "flpnOptions1");
			this.flpnOptions1.Controls.Add(this.ckbFlipped);
			this.flpnOptions1.Controls.Add(this.ckbAnimSpeed);
			this.flpnOptions1.Controls.Add(this.ckbParam);
			this.flpnOptions1.Controls.Add(this.ckbInterruptible);
			this.flpnOptions1.Controls.Add(this.ckbStartTag);
			this.flpnOptions1.Controls.Add(this.ckbLoopCount);
			this.flpnOptions1.Controls.Add(this.ckbTransToIdle);
			this.flpnOptions1.Controls.Add(this.ckbBlendOut);
			this.flpnOptions1.Controls.Add(this.ckbBlendIn);
			this.flpnOptions1.Name = "flpnOptions1";
			//
			// ckbFlipped
			//
			resources.ApplyResources(this.ckbFlipped, "ckbFlipped");
			this.ckbFlipped.Name = "ckbFlipped";
			this.ckbFlipped.UseVisualStyleBackColor = true;
			//
			// ckbAnimSpeed
			//
			resources.ApplyResources(this.ckbAnimSpeed, "ckbAnimSpeed");
			this.ckbAnimSpeed.Name = "ckbAnimSpeed";
			this.ckbAnimSpeed.UseVisualStyleBackColor = true;
			//
			// ckbParam
			//
			resources.ApplyResources(this.ckbParam, "ckbParam");
			this.ckbParam.Name = "ckbParam";
			this.ckbParam.UseVisualStyleBackColor = true;
			this.ckbParam.CheckedChanged += new System.EventHandler(
				this.ckbParam_CheckedChanged
			);
			//
			// ckbInterruptible
			//
			resources.ApplyResources(this.ckbInterruptible, "ckbInterruptible");
			this.ckbInterruptible.Name = "ckbInterruptible";
			this.ckbInterruptible.UseVisualStyleBackColor = true;
			//
			// ckbStartTag
			//
			resources.ApplyResources(this.ckbStartTag, "ckbStartTag");
			this.ckbStartTag.Name = "ckbStartTag";
			this.ckbStartTag.UseVisualStyleBackColor = true;
			//
			// ckbLoopCount
			//
			resources.ApplyResources(this.ckbLoopCount, "ckbLoopCount");
			this.ckbLoopCount.Name = "ckbLoopCount";
			this.ckbLoopCount.UseVisualStyleBackColor = true;
			//
			// ckbTransToIdle
			//
			resources.ApplyResources(this.ckbTransToIdle, "ckbTransToIdle");
			this.ckbTransToIdle.Name = "ckbTransToIdle";
			this.ckbTransToIdle.UseVisualStyleBackColor = true;
			//
			// ckbBlendOut
			//
			resources.ApplyResources(this.ckbBlendOut, "ckbBlendOut");
			this.ckbBlendOut.Name = "ckbBlendOut";
			this.ckbBlendOut.UseVisualStyleBackColor = true;
			//
			// ckbBlendIn
			//
			resources.ApplyResources(this.ckbBlendIn, "ckbBlendIn");
			this.ckbBlendIn.Name = "ckbBlendIn";
			this.ckbBlendIn.UseVisualStyleBackColor = true;
			//
			// groupBox2
			//
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.Controls.Add(this.flpnOptions2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			//
			// flpnOptions2
			//
			resources.ApplyResources(this.flpnOptions2, "flpnOptions2");
			this.flpnOptions2.Controls.Add(this.ckbFlipTemp3);
			this.flpnOptions2.Controls.Add(this.ckbSync);
			this.flpnOptions2.Controls.Add(this.ckbAlignBlend);
			this.flpnOptions2.Controls.Add(this.ckbControllerIsSource);
			this.flpnOptions2.Controls.Add(this.ckbNotHurryable);
			this.flpnOptions2.Name = "flpnOptions2";
			//
			// ckbFlipTemp3
			//
			resources.ApplyResources(this.ckbFlipTemp3, "ckbFlipTemp3");
			this.ckbFlipTemp3.Name = "ckbFlipTemp3";
			this.ckbFlipTemp3.UseVisualStyleBackColor = true;
			this.ckbFlipTemp3.CheckedChanged += new System.EventHandler(
				this.ckbFlipTemp3_CheckedChanged
			);
			//
			// ckbSync
			//
			resources.ApplyResources(this.ckbSync, "ckbSync");
			this.ckbSync.Name = "ckbSync";
			this.ckbSync.UseVisualStyleBackColor = true;
			//
			// ckbAlignBlend
			//
			resources.ApplyResources(this.ckbAlignBlend, "ckbAlignBlend");
			this.ckbAlignBlend.Name = "ckbAlignBlend";
			this.ckbAlignBlend.UseVisualStyleBackColor = true;
			//
			// ckbControllerIsSource
			//
			resources.ApplyResources(
				this.ckbControllerIsSource,
				"ckbControllerIsSource"
			);
			this.ckbControllerIsSource.Name = "ckbControllerIsSource";
			this.ckbControllerIsSource.UseVisualStyleBackColor = true;
			//
			// ckbNotHurryable
			//
			resources.ApplyResources(this.ckbNotHurryable, "ckbNotHurryable");
			this.ckbNotHurryable.Name = "ckbNotHurryable";
			this.ckbNotHurryable.UseVisualStyleBackColor = true;
			//
			// gbPriority
			//
			resources.ApplyResources(this.gbPriority, "gbPriority");
			this.gbPriority.Controls.Add(this.cbPriority);
			this.gbPriority.Name = "gbPriority";
			this.gbPriority.TabStop = false;
			//
			// cbPriority
			//
			this.cbPriority.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbPriority.FormattingEnabled = true;
			this.cbPriority.Items.AddRange(
				new object[]
				{
					resources.GetString("cbPriority.Items"),
					resources.GetString("cbPriority.Items1"),
					resources.GetString("cbPriority.Items2"),
				}
			);
			resources.ApplyResources(this.cbPriority, "cbPriority");
			this.cbPriority.Name = "cbPriority";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.pnWizAnimate);
			this.Name = "UI";
			this.pnWizAnimate.ResumeLayout(false);
			this.pnWizAnimate.PerformLayout();
			this.flpnMain.ResumeLayout(false);
			this.flpnMain.PerformLayout();
			this.pnObject.ResumeLayout(false);
			this.pnObject.PerformLayout();
			this.pnIKObject.ResumeLayout(false);
			this.pnIKObject.PerformLayout();
			this.pnDoidOptions.ResumeLayout(false);
			this.pnDoidOptions.PerformLayout();
			this.flpnAnimType.ResumeLayout(false);
			this.flpnAnimType.PerformLayout();
			this.flpnAnim.ResumeLayout(false);
			this.flpnAnim.PerformLayout();
			this.flpnEventScope.ResumeLayout(false);
			this.flpnEventScope.PerformLayout();
			this.flpnEventTree.ResumeLayout(false);
			this.flpnEventTree.PerformLayout();
			this.flpnOptions.ResumeLayout(false);
			this.flpnOptions.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.flpnOptions1.ResumeLayout(false);
			this.flpnOptions1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.flpnOptions2.ResumeLayout(false);
			this.flpnOptions2.PerformLayout();
			this.gbPriority.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		private void llEvent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			pjse.FileTable.Entry item = inst.Parent.ResourceByInstance(
				SimPe.Data.MetaData.BHAV_FILE,
				doidEvent.Value
			);
			Bhav b = new Bhav();
			b.ProcessData(item.PFD, item.Package);

			SimPe.PackedFiles.UserInterface.BhavForm ui =
				(SimPe.PackedFiles.UserInterface.BhavForm)b.UIHandler;
			ui.Tag = "Popup"; // tells the SetReadOnly function it's in a popup - so everything locked down
			ui.Text =
				pjse.Localization.GetString("viewbhav")
				+ ": "
				+ b.FileName
				+ " ["
				+ b.Package.SaveFileName
				+ "]";
			b.RefreshUI();
			ui.Show();
		}

		private void btnEventTree_Click(object sender, EventArgs e)
		{
			pjse.FileTable.Entry item = new pjse.ResourceChooser().Execute(
				SimPe.Data.MetaData.BHAV_FILE,
				inst.Parent.FileDescriptor.Group,
				this,
				false
			);
			if (item != null)
				tbValEventTree.Text =
					"0x" + SimPe.Helper.HexString((ushort)item.Instance);
		}

		private void btnAnim_Click(object sender, EventArgs e)
		{
			this.doStrChooser(this.tbValAnim, this.tbAnim);
		}

		private void ckbParam_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;
			doCkbParam();
		}

		private void ckbFlipTemp3_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;
			ckbFlipped.Enabled = !ckbFlipTemp3.Checked;
		}

		private void cbAnimType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
				return;
			internalchg = true;

			try
			{
				if (this.cbAnimType.SelectedIndex >= 0)
				{
					GS.GlobalStr gs = (GS.GlobalStr)
						Enum.Parse(
							typeof(GS.GlobalStr),
							this.cbAnimType.SelectedItem.ToString()
						);
					tbValAnimType.Text = "0x" + ((ushort)gs).ToString("X");
				}
			}
			finally
			{
				tbAnimType.Text =
					(this.cbAnimType.SelectedIndex >= 0)
						? this.cbAnimType.SelectedItem.ToString()
						: "---";
			}
			doStrValue(doidAnim.Value, tbAnim);
			tbValAnimType.Focus();

			internalchg = false;
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWizAnimate : pjse.ABhavOperandWiz
	{
		public BhavOperandWizAnimate(Instruction i, String mode)
			: base(i)
		{
			myForm = new WizAnimate.UI(mode);
		}

		#region IDisposable Members
		public override void Dispose()
		{
			if (myForm != null)
				myForm = null;
		}
		#endregion
	}
}
