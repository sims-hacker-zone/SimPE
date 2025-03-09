// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SimPe.PackedFiles.Bhav;
using SimPe.PackedFiles.Str;

namespace pjse.BhavOperandWizards.WizAnimate
{
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		internal Panel pnWizAnimate;
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
		public UI(string mode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			#region AnimNames
			cbAnimType.Items.Clear();
			cbAnimType.Items.AddRange(
				new string[]
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
					flpnMain.Controls.Remove(flpnAnimType);
					flpnMain.Controls.Remove(pnIKObject);
					flpnOptions.Controls.Remove(gbPriority);
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
					flpnMain.Controls.Remove(pnObject);
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
					flpnMain.Controls.Remove(pnIKObject);
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
				components?.Dispose();
			}
			base.Dispose(disposing);

			inst = null;
		}

		private string mode = "";
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
				lbParam.Text = ((string)lbParam.Tag).Split(new char[] { '|' })[0];
			}
			else
			{
				lbParam.Text = ((string)lbParam.Tag).Split(new char[] { '|' })[1];
				doStrValue(doidAnim.Value, tbAnim);
			}
			btnAnim.Visible = tbAnim.Visible = !ckbParam.Checked;
		}

		private void doStrChooser(TextBox tbVal, TextBox strText)
		{
			FileTable.Entry[] items = FileTable.GFT[
				SimPe.Data.FileTypes.STR,
				inst.Parent.GroupForScope(AnimScope()),
				(uint)AnimInstance()
			];

			if (items == null || items.Length == 0)
			{
				MessageBox.Show(
					Localization.GetString("bow_noStrings")
						+ " ("
						+ Localization.GetString(AnimScope().ToString())
						+ ")"
				);
				return; // eek!
			}

			StrWrapper str = new StrWrapper();
			str.ProcessData(items[0].PFD, items[0].Package);

			int i = new StrChooser(true).Strnum(str);
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

		private bool IsAnim(string s)
		{
			return s.EndsWith("Anims");
		}

		private Scope AnimScope()
		{
			return mode.Equals("bwp_Object") ? Scope.Private : (doidAnimType.Value == 0x80) ? Scope.Global : Scope.Private;
		}

		private GS.GlobalStr AnimInstance()
		{
			return mode.Equals("bwp_Object")
				? GS.GlobalStr.ObjectAnims
				: doidAnimType.Value == 0x80
				? GS.GlobalStr.AdultAnims
				: IsAnim(doidAnimType.Value) ? (GS.GlobalStr)doidAnimType.Value : GS.GlobalStr.ObjectAnims;
		}

		private void doStrValue(ushort strno, TextBox strText)
		{
			strText.Text = ((BhavWiz)inst).readStr(
				AnimScope(),
				AnimInstance(),
				strno,
				-1,
				Detail.ErrorNames
			);
		}

		private void doidAnimType_DataOwnerControlChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			internalchg = true;

			try
			{
				cbAnimType.SelectedIndex = cbAnimType.Items.IndexOf(
					((GS.GlobalStr)doidAnimType.Value).ToString()
				);
				tbAnimType.Text =
					(cbAnimType.SelectedIndex >= 0)
						? cbAnimType.SelectedItem.ToString()
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
			{
				return;
			}

			doStrValue(doidAnim.Value, tbAnim);
		}

		private void doidEvent_DataOwnerControlChanged(object sender, EventArgs e)
		{
			bool found = false;
			tbEventTree.Text = BhavWiz.bhavName(
				inst.Parent,
				doidEvent.Value,
				ref found
			);
			if (!found)
			{
				tbEventTree.Text = "---";
			}

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
			{
				if (lckbOptions[i] != null)
				{
					options[i] = lckbOptions[i].Checked;
				}
			}

			return options;
		}

		#region iBhavOperandWizForm
		public Panel WizPanel => pnWizAnimate;

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
			{
				c.Visible = false;
			}

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
						ops1[6]
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
						ops2[1]
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
					{
						priority = ops2[4];
					}

					scope = ops2[6];
					options2 = ops2[7];
					break;
			}

			for (int i = 0; i < lckbOptions1.Count; i++)
			{
				if (lckbOptions1[i] != null)
				{
					lckbOptions1[i].Visible = true;
					lckbOptions1[i].Checked = options1[i];
				}
			}

			for (int i = 0; i < lckbOptions2.Count; i++)
			{
				if (lckbOptions2[i] != null)
				{
					lckbOptions2[i].Visible = true;
					lckbOptions2[i].Checked = options2[i];
				}
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
			{
				doidAnimType_DataOwnerControlChanged(null, null);
			}
			else
			{
				doidAnim_DataOwnerControlChanged(null, null);
			}

			doidEvent_DataOwnerControlChanged(null, null);
			ckbParam_CheckedChanged(null, null);
			ckbFlipTemp3_CheckedChanged(null, null);
			if (priority < cbPriority.Items.Count)
			{
				cbPriority.SelectedIndex = priority;
			}
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
						{
							ops2[4] = getPriority(ops2[4]);
						}

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
			pnWizAnimate = new Panel();
			flpnMain = new FlowLayoutPanel();
			pnObject = new Panel();
			cbPickerObject = new ComboBox();
			tbValObject = new TextBox();
			cbdoObject = new ComboBox();
			label1 = new Label();
			pnIKObject = new Panel();
			cbPickerIK = new ComboBox();
			tbValIK = new TextBox();
			cbdoIK = new ComboBox();
			label3 = new Label();
			pnDoidOptions = new Panel();
			ckbAttrPicker = new CheckBox();
			ckbDecimal = new CheckBox();
			flpnAnimType = new FlowLayoutPanel();
			label4 = new Label();
			tbValAnimType = new TextBox();
			cbAnimType = new ComboBox();
			tbAnimType = new TextBox();
			flpnAnim = new FlowLayoutPanel();
			lbParam = new Label();
			tbValAnim = new TextBox();
			btnAnim = new Button();
			tbAnim = new TextBox();
			flpnEventScope = new FlowLayoutPanel();
			label2 = new Label();
			cbEventScope = new ComboBox();
			flpnEventTree = new FlowLayoutPanel();
			llEvent = new LinkLabel();
			tbValEventTree = new TextBox();
			btnEventTree = new Button();
			tbEventTree = new TextBox();
			flpnOptions = new FlowLayoutPanel();
			groupBox1 = new GroupBox();
			flpnOptions1 = new FlowLayoutPanel();
			ckbFlipped = new CheckBox();
			ckbAnimSpeed = new CheckBox();
			ckbParam = new CheckBox();
			ckbInterruptible = new CheckBox();
			ckbStartTag = new CheckBox();
			ckbLoopCount = new CheckBox();
			ckbTransToIdle = new CheckBox();
			ckbBlendOut = new CheckBox();
			ckbBlendIn = new CheckBox();
			groupBox2 = new GroupBox();
			flpnOptions2 = new FlowLayoutPanel();
			ckbFlipTemp3 = new CheckBox();
			ckbSync = new CheckBox();
			ckbAlignBlend = new CheckBox();
			ckbControllerIsSource = new CheckBox();
			ckbNotHurryable = new CheckBox();
			gbPriority = new GroupBox();
			cbPriority = new ComboBox();
			pnWizAnimate.SuspendLayout();
			flpnMain.SuspendLayout();
			pnObject.SuspendLayout();
			pnIKObject.SuspendLayout();
			pnDoidOptions.SuspendLayout();
			flpnAnimType.SuspendLayout();
			flpnAnim.SuspendLayout();
			flpnEventScope.SuspendLayout();
			flpnEventTree.SuspendLayout();
			flpnOptions.SuspendLayout();
			groupBox1.SuspendLayout();
			flpnOptions1.SuspendLayout();
			groupBox2.SuspendLayout();
			flpnOptions2.SuspendLayout();
			gbPriority.SuspendLayout();
			SuspendLayout();
			//
			// pnWizAnimate
			//
			resources.ApplyResources(pnWizAnimate, "pnWizAnimate");
			pnWizAnimate.Controls.Add(flpnMain);
			pnWizAnimate.Name = "pnWizAnimate";
			//
			// flpnMain
			//
			resources.ApplyResources(flpnMain, "flpnMain");
			flpnMain.Controls.Add(pnObject);
			flpnMain.Controls.Add(pnIKObject);
			flpnMain.Controls.Add(pnDoidOptions);
			flpnMain.Controls.Add(flpnAnimType);
			flpnMain.Controls.Add(flpnAnim);
			flpnMain.Controls.Add(flpnEventScope);
			flpnMain.Controls.Add(flpnEventTree);
			flpnMain.Controls.Add(flpnOptions);
			flpnMain.Name = "flpnMain";
			//
			// pnObject
			//
			pnObject.Controls.Add(cbPickerObject);
			pnObject.Controls.Add(tbValObject);
			pnObject.Controls.Add(cbdoObject);
			pnObject.Controls.Add(label1);
			resources.ApplyResources(pnObject, "pnObject");
			pnObject.Name = "pnObject";
			//
			// cbPickerObject
			//
			cbPickerObject.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPickerObject.DropDownWidth = 384;
			resources.ApplyResources(cbPickerObject, "cbPickerObject");
			cbPickerObject.Name = "cbPickerObject";
			cbPickerObject.TabStop = false;
			//
			// tbValObject
			//
			resources.ApplyResources(tbValObject, "tbValObject");
			tbValObject.Name = "tbValObject";
			tbValObject.TabStop = false;
			//
			// cbdoObject
			//
			cbdoObject.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbdoObject.DropDownWidth = 384;
			resources.ApplyResources(cbdoObject, "cbdoObject");
			cbdoObject.Name = "cbdoObject";
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// pnIKObject
			//
			pnIKObject.Controls.Add(cbPickerIK);
			pnIKObject.Controls.Add(tbValIK);
			pnIKObject.Controls.Add(cbdoIK);
			pnIKObject.Controls.Add(label3);
			resources.ApplyResources(pnIKObject, "pnIKObject");
			pnIKObject.Name = "pnIKObject";
			//
			// cbPickerIK
			//
			cbPickerIK.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPickerIK.DropDownWidth = 384;
			resources.ApplyResources(cbPickerIK, "cbPickerIK");
			cbPickerIK.Name = "cbPickerIK";
			cbPickerIK.TabStop = false;
			//
			// tbValIK
			//
			resources.ApplyResources(tbValIK, "tbValIK");
			tbValIK.Name = "tbValIK";
			tbValIK.TabStop = false;
			//
			// cbdoIK
			//
			cbdoIK.DropDownStyle = ComboBoxStyle.DropDownList;
			cbdoIK.DropDownWidth = 384;
			resources.ApplyResources(cbdoIK, "cbdoIK");
			cbdoIK.Name = "cbdoIK";
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// pnDoidOptions
			//
			pnDoidOptions.Controls.Add(ckbAttrPicker);
			pnDoidOptions.Controls.Add(ckbDecimal);
			resources.ApplyResources(pnDoidOptions, "pnDoidOptions");
			pnDoidOptions.Name = "pnDoidOptions";
			//
			// ckbAttrPicker
			//
			resources.ApplyResources(ckbAttrPicker, "ckbAttrPicker");
			ckbAttrPicker.Name = "ckbAttrPicker";
			//
			// ckbDecimal
			//
			resources.ApplyResources(ckbDecimal, "ckbDecimal");
			ckbDecimal.Name = "ckbDecimal";
			//
			// flpnAnimType
			//
			resources.ApplyResources(flpnAnimType, "flpnAnimType");
			flpnAnimType.Controls.Add(label4);
			flpnAnimType.Controls.Add(tbValAnimType);
			flpnAnimType.Controls.Add(cbAnimType);
			flpnAnimType.Controls.Add(tbAnimType);
			flpnAnimType.Name = "flpnAnimType";
			//
			// label4
			//
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// tbValAnimType
			//
			resources.ApplyResources(tbValAnimType, "tbValAnimType");
			tbValAnimType.Name = "tbValAnimType";
			//
			// cbAnimType
			//
			cbAnimType.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbAnimType.DropDownWidth = 200;
			cbAnimType.FormattingEnabled = true;
			resources.ApplyResources(cbAnimType, "cbAnimType");
			cbAnimType.Name = "cbAnimType";
			cbAnimType.TabStop = false;
			cbAnimType.SelectedIndexChanged += new EventHandler(
				cbAnimType_SelectedIndexChanged
			);
			//
			// tbAnimType
			//
			resources.ApplyResources(tbAnimType, "tbAnimType");
			tbAnimType.BorderStyle = BorderStyle.None;
			tbAnimType.Name = "tbAnimType";
			tbAnimType.ReadOnly = true;
			tbAnimType.TabStop = false;
			//
			// flpnAnim
			//
			resources.ApplyResources(flpnAnim, "flpnAnim");
			flpnAnim.Controls.Add(lbParam);
			flpnAnim.Controls.Add(tbValAnim);
			flpnAnim.Controls.Add(btnAnim);
			flpnAnim.Controls.Add(tbAnim);
			flpnAnim.Name = "flpnAnim";
			//
			// lbParam
			//
			resources.ApplyResources(lbParam, "lbParam");
			lbParam.Name = "lbParam";
			lbParam.Tag = "Param|Animation String";
			//
			// tbValAnim
			//
			resources.ApplyResources(tbValAnim, "tbValAnim");
			tbValAnim.Name = "tbValAnim";
			//
			// btnAnim
			//
			resources.ApplyResources(btnAnim, "btnAnim");
			btnAnim.Name = "btnAnim";
			btnAnim.Click += new EventHandler(btnAnim_Click);
			//
			// tbAnim
			//
			resources.ApplyResources(tbAnim, "tbAnim");
			tbAnim.BorderStyle = BorderStyle.None;
			tbAnim.Name = "tbAnim";
			tbAnim.ReadOnly = true;
			tbAnim.TabStop = false;
			//
			// flpnEventScope
			//
			resources.ApplyResources(flpnEventScope, "flpnEventScope");
			flpnEventScope.Controls.Add(label2);
			flpnEventScope.Controls.Add(cbEventScope);
			flpnEventScope.Name = "flpnEventScope";
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			label2.Tag = "";
			//
			// cbEventScope
			//
			cbEventScope.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbEventScope.FormattingEnabled = true;
			cbEventScope.Items.AddRange(
				new object[]
				{
					resources.GetString("cbEventScope.Items"),
					resources.GetString("cbEventScope.Items1"),
					resources.GetString("cbEventScope.Items2"),
				}
			);
			resources.ApplyResources(cbEventScope, "cbEventScope");
			cbEventScope.Name = "cbEventScope";
			//
			// flpnEventTree
			//
			resources.ApplyResources(flpnEventTree, "flpnEventTree");
			flpnEventTree.Controls.Add(llEvent);
			flpnEventTree.Controls.Add(tbValEventTree);
			flpnEventTree.Controls.Add(btnEventTree);
			flpnEventTree.Controls.Add(tbEventTree);
			flpnEventTree.Name = "flpnEventTree";
			//
			// llEvent
			//
			resources.ApplyResources(llEvent, "llEvent");
			llEvent.Name = "llEvent";
			llEvent.TabStop = true;
			llEvent.UseCompatibleTextRendering = true;
			llEvent.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llEvent_LinkClicked
				);
			//
			// tbValEventTree
			//
			resources.ApplyResources(tbValEventTree, "tbValEventTree");
			tbValEventTree.Name = "tbValEventTree";
			//
			// btnEventTree
			//
			resources.ApplyResources(btnEventTree, "btnEventTree");
			btnEventTree.Name = "btnEventTree";
			btnEventTree.Click += new EventHandler(btnEventTree_Click);
			//
			// tbEventTree
			//
			resources.ApplyResources(tbEventTree, "tbEventTree");
			tbEventTree.BorderStyle = BorderStyle.None;
			tbEventTree.Name = "tbEventTree";
			tbEventTree.ReadOnly = true;
			tbEventTree.TabStop = false;
			//
			// flpnOptions
			//
			resources.ApplyResources(flpnOptions, "flpnOptions");
			flpnOptions.Controls.Add(groupBox1);
			flpnOptions.Controls.Add(groupBox2);
			flpnOptions.Controls.Add(gbPriority);
			flpnOptions.Name = "flpnOptions";
			//
			// groupBox1
			//
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Controls.Add(flpnOptions1);
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			//
			// flpnOptions1
			//
			resources.ApplyResources(flpnOptions1, "flpnOptions1");
			flpnOptions1.Controls.Add(ckbFlipped);
			flpnOptions1.Controls.Add(ckbAnimSpeed);
			flpnOptions1.Controls.Add(ckbParam);
			flpnOptions1.Controls.Add(ckbInterruptible);
			flpnOptions1.Controls.Add(ckbStartTag);
			flpnOptions1.Controls.Add(ckbLoopCount);
			flpnOptions1.Controls.Add(ckbTransToIdle);
			flpnOptions1.Controls.Add(ckbBlendOut);
			flpnOptions1.Controls.Add(ckbBlendIn);
			flpnOptions1.Name = "flpnOptions1";
			//
			// ckbFlipped
			//
			resources.ApplyResources(ckbFlipped, "ckbFlipped");
			ckbFlipped.Name = "ckbFlipped";
			ckbFlipped.UseVisualStyleBackColor = true;
			//
			// ckbAnimSpeed
			//
			resources.ApplyResources(ckbAnimSpeed, "ckbAnimSpeed");
			ckbAnimSpeed.Name = "ckbAnimSpeed";
			ckbAnimSpeed.UseVisualStyleBackColor = true;
			//
			// ckbParam
			//
			resources.ApplyResources(ckbParam, "ckbParam");
			ckbParam.Name = "ckbParam";
			ckbParam.UseVisualStyleBackColor = true;
			ckbParam.CheckedChanged += new EventHandler(
				ckbParam_CheckedChanged
			);
			//
			// ckbInterruptible
			//
			resources.ApplyResources(ckbInterruptible, "ckbInterruptible");
			ckbInterruptible.Name = "ckbInterruptible";
			ckbInterruptible.UseVisualStyleBackColor = true;
			//
			// ckbStartTag
			//
			resources.ApplyResources(ckbStartTag, "ckbStartTag");
			ckbStartTag.Name = "ckbStartTag";
			ckbStartTag.UseVisualStyleBackColor = true;
			//
			// ckbLoopCount
			//
			resources.ApplyResources(ckbLoopCount, "ckbLoopCount");
			ckbLoopCount.Name = "ckbLoopCount";
			ckbLoopCount.UseVisualStyleBackColor = true;
			//
			// ckbTransToIdle
			//
			resources.ApplyResources(ckbTransToIdle, "ckbTransToIdle");
			ckbTransToIdle.Name = "ckbTransToIdle";
			ckbTransToIdle.UseVisualStyleBackColor = true;
			//
			// ckbBlendOut
			//
			resources.ApplyResources(ckbBlendOut, "ckbBlendOut");
			ckbBlendOut.Name = "ckbBlendOut";
			ckbBlendOut.UseVisualStyleBackColor = true;
			//
			// ckbBlendIn
			//
			resources.ApplyResources(ckbBlendIn, "ckbBlendIn");
			ckbBlendIn.Name = "ckbBlendIn";
			ckbBlendIn.UseVisualStyleBackColor = true;
			//
			// groupBox2
			//
			resources.ApplyResources(groupBox2, "groupBox2");
			groupBox2.Controls.Add(flpnOptions2);
			groupBox2.Name = "groupBox2";
			groupBox2.TabStop = false;
			//
			// flpnOptions2
			//
			resources.ApplyResources(flpnOptions2, "flpnOptions2");
			flpnOptions2.Controls.Add(ckbFlipTemp3);
			flpnOptions2.Controls.Add(ckbSync);
			flpnOptions2.Controls.Add(ckbAlignBlend);
			flpnOptions2.Controls.Add(ckbControllerIsSource);
			flpnOptions2.Controls.Add(ckbNotHurryable);
			flpnOptions2.Name = "flpnOptions2";
			//
			// ckbFlipTemp3
			//
			resources.ApplyResources(ckbFlipTemp3, "ckbFlipTemp3");
			ckbFlipTemp3.Name = "ckbFlipTemp3";
			ckbFlipTemp3.UseVisualStyleBackColor = true;
			ckbFlipTemp3.CheckedChanged += new EventHandler(
				ckbFlipTemp3_CheckedChanged
			);
			//
			// ckbSync
			//
			resources.ApplyResources(ckbSync, "ckbSync");
			ckbSync.Name = "ckbSync";
			ckbSync.UseVisualStyleBackColor = true;
			//
			// ckbAlignBlend
			//
			resources.ApplyResources(ckbAlignBlend, "ckbAlignBlend");
			ckbAlignBlend.Name = "ckbAlignBlend";
			ckbAlignBlend.UseVisualStyleBackColor = true;
			//
			// ckbControllerIsSource
			//
			resources.ApplyResources(
				ckbControllerIsSource,
				"ckbControllerIsSource"
			);
			ckbControllerIsSource.Name = "ckbControllerIsSource";
			ckbControllerIsSource.UseVisualStyleBackColor = true;
			//
			// ckbNotHurryable
			//
			resources.ApplyResources(ckbNotHurryable, "ckbNotHurryable");
			ckbNotHurryable.Name = "ckbNotHurryable";
			ckbNotHurryable.UseVisualStyleBackColor = true;
			//
			// gbPriority
			//
			resources.ApplyResources(gbPriority, "gbPriority");
			gbPriority.Controls.Add(cbPriority);
			gbPriority.Name = "gbPriority";
			gbPriority.TabStop = false;
			//
			// cbPriority
			//
			cbPriority.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPriority.FormattingEnabled = true;
			cbPriority.Items.AddRange(
				new object[]
				{
					resources.GetString("cbPriority.Items"),
					resources.GetString("cbPriority.Items1"),
					resources.GetString("cbPriority.Items2"),
				}
			);
			resources.ApplyResources(cbPriority, "cbPriority");
			cbPriority.Name = "cbPriority";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(pnWizAnimate);
			Name = "UI";
			pnWizAnimate.ResumeLayout(false);
			pnWizAnimate.PerformLayout();
			flpnMain.ResumeLayout(false);
			flpnMain.PerformLayout();
			pnObject.ResumeLayout(false);
			pnObject.PerformLayout();
			pnIKObject.ResumeLayout(false);
			pnIKObject.PerformLayout();
			pnDoidOptions.ResumeLayout(false);
			pnDoidOptions.PerformLayout();
			flpnAnimType.ResumeLayout(false);
			flpnAnimType.PerformLayout();
			flpnAnim.ResumeLayout(false);
			flpnAnim.PerformLayout();
			flpnEventScope.ResumeLayout(false);
			flpnEventScope.PerformLayout();
			flpnEventTree.ResumeLayout(false);
			flpnEventTree.PerformLayout();
			flpnOptions.ResumeLayout(false);
			flpnOptions.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			flpnOptions1.ResumeLayout(false);
			flpnOptions1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			flpnOptions2.ResumeLayout(false);
			flpnOptions2.PerformLayout();
			gbPriority.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		private void llEvent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			FileTable.Entry item = inst.Parent.ResourceByInstance(
				SimPe.Data.FileTypes.BHAV,
				doidEvent.Value
			);
			Bhav b = new Bhav();
			b.ProcessData(item.PFD, item.Package);

			BhavForm ui =
				(BhavForm)b.UIHandler;
			ui.Tag = "Popup"; // tells the SetReadOnly function it's in a popup - so everything locked down
			ui.Text =
				Localization.GetString("viewbhav")
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
			FileTable.Entry item = new ResourceChooser().Execute(
				SimPe.Data.FileTypes.BHAV,
				inst.Parent.FileDescriptor.Group,
				this,
				false
			);
			if (item != null)
			{
				tbValEventTree.Text =
					"0x" + SimPe.Helper.HexString((ushort)item.Instance);
			}
		}

		private void btnAnim_Click(object sender, EventArgs e)
		{
			doStrChooser(tbValAnim, tbAnim);
		}

		private void ckbParam_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			doCkbParam();
		}

		private void ckbFlipTemp3_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			ckbFlipped.Enabled = !ckbFlipTemp3.Checked;
		}

		private void cbAnimType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			internalchg = true;

			try
			{
				if (cbAnimType.SelectedIndex >= 0)
				{
					GS.GlobalStr gs = (GS.GlobalStr)
						Enum.Parse(
							typeof(GS.GlobalStr),
							cbAnimType.SelectedItem.ToString()
						);
					tbValAnimType.Text = "0x" + ((ushort)gs).ToString("X");
				}
			}
			finally
			{
				tbAnimType.Text =
					(cbAnimType.SelectedIndex >= 0)
						? cbAnimType.SelectedItem.ToString()
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
	public class BhavOperandWizAnimate : ABhavOperandWiz
	{
		public BhavOperandWizAnimate(Instruction i, string mode)
			: base(i)
		{
			myForm = new WizAnimate.UI(mode);
		}

		#region IDisposable Members
		public override void Dispose()
		{
			if (myForm != null)
			{
				myForm = null;
			}
		}
		#endregion
	}
}
