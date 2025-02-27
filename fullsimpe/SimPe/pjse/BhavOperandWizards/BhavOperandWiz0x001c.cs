/***************************************************************************
 *   Copyright (C) 2005-2008 by Peter L Jones                              *
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
 *   59 Temple Place - Suite 330, Boston, MA  1c111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x001c
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		internal Panel pnWiz0x001c;
		private Label label1;
		private ComboBox cbScope;
		private Label label2;
		private CheckBox tfPrivate;
		private CheckBox tfGlobal;
		private CheckBox tfSemiGlobal;
		private Label label3;
		private ComboBox cbRTBNType;
		private Label label4;
		private CheckBox tfParams;
		private CheckBox tfArgs;
		private Label label8;
		private TextBox tbTree;
		private Label lbTreeName;
		private Button btnTreeName;
		private LabelledDataOwner ldocArg1;
		private LabelledDataOwner ldocArg2;
		private LabelledDataOwner ldocArg3;
		private FlowLayoutPanel flpArgs;
		private FlowLayoutPanel flowLayoutPanel2;
		private TableLayoutPanel tableLayoutPanel1;
		private FlowLayoutPanel flowLayoutPanel4;
		private FlowLayoutPanel flowLayoutPanel3;
		private FlowLayoutPanel flowLayoutPanel6;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public UI()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			cbRTBNType.Items.Clear();
			cbRTBNType.Items.AddRange(
				BhavWiz.readStr(GS.BhavStr.RTBNType).ToArray()
			);

			ldocArg3.Decimal =
				ldocArg2.Decimal =
				ldocArg1.Decimal =
					Settings.PJSE.DecimalDOValue;
			ldocArg3.UseInstancePicker =
				ldocArg2.UseInstancePicker =
				ldocArg1.UseInstancePicker =
					Settings.PJSE.InstancePickerAsText;
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

		private Instruction inst = null;
		private bool internalchg = false;
		private DataOwnerControl doidTree = null;

		void doidTree_DataOwnerControlChanged(object sender, EventArgs e)
		{
			lbTreeName.Text = ((BhavWiz)inst).readStr(
				Scope,
				GS.GlobalStr.NamedTree,
				(ushort)(doidTree.Value - 1),
				-1,
				Detail.ErrorNames
			);
		}

		private Scope Scope
		{
			get
			{
				Scope scope = Scope.Private;
				switch (cbScope.SelectedIndex)
				{
					case 1:
						scope = Scope.SemiGlobal;
						break;
					case 2:
						scope = Scope.Global;
						break;
				}
				return scope;
			}
		}

		private void doStrChooser()
		{
			FileTable.Entry[] items = FileTable.GFT[
				SimPe.Data.MetaData.STRING_FILE,
				inst.Parent.GroupForScope(Scope),
				(uint)GS.GlobalStr.NamedTree
			];

			if (items == null || items.Length == 0)
			{
				MessageBox.Show(
					Localization.GetString("bow_noStrings")
						+ " ("
						+ Localization.GetString(Scope.ToString())
						+ ")"
				);
				return; // eek!
			}

			StrWrapper str = new StrWrapper();
			str.ProcessData(items[0].PFD, items[0].Package);

			int i = new StrChooser(true).Strnum(str);
			if (i >= 0)
			{
				tbTree.Text = "0x" + SimPe.Helper.HexString((ushort)(i + 1));
				lbTreeName.Text = ((BhavWiz)inst).readStr(
					Scope,
					GS.GlobalStr.NamedTree,
					(ushort)i,
					-1,
					Detail.ErrorNames
				);
			}
		}

		#region iBhavOperandWizForm
		public Panel WizPanel => pnWiz0x001c;

		public void Execute(Instruction inst)
		{
			this.inst =
				ldocArg1.Instruction =
				ldocArg2.Instruction =
				ldocArg3.Instruction =
					inst;

			wrappedByteArray ops1 = inst.Operands;
			wrappedByteArray ops2 = inst.Reserved1;

			internalchg = true;

			Boolset options = (byte)(ops1[0x02] & 0x3f);

			cbScope.SelectedIndex = 0; // Private
			if (options[0])
			{
				cbScope.SelectedIndex = 2; // Global
			}
			else if (options[1])
			{
				cbScope.SelectedIndex = 1; // SemiGlobal
			}

			tfSemiGlobal.Checked = !options[3];
			tfGlobal.Checked = !options[2];

			cbRTBNType.SelectedIndex =
				ops1[0x05] < cbRTBNType.Items.Count ? ops1[0x05] : -1;

			flpArgs.Enabled = tfArgs.Checked = options[4];
			tfParams.Checked = options[5];

			doidTree = new DataOwnerControl(
				null,
				null,
				null,
				tbTree,
				null,
				null,
				null,
				0x07,
				BhavWiz.ToShort(ops1[0x04], (byte)((ops1[0x02] >> 6) & 0x01))
			);
			doidTree.DataOwnerControlChanged += new EventHandler(
				doidTree_DataOwnerControlChanged
			);
			doidTree_DataOwnerControlChanged(null, null);

			ldocArg1.Value = BhavWiz.ToShort(ops1[0x07], ops2[0x00]);
			ldocArg1.DataOwner = ops1[0x06];
			ldocArg2.Value = BhavWiz.ToShort(ops2[0x02], ops2[0x03]);
			ldocArg2.DataOwner = ops2[0x01];
			ldocArg3.Value = BhavWiz.ToShort(ops2[0x05], ops2[0x06]);
			ldocArg3.DataOwner = ops2[0x04];

			internalchg = false;
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops1 = inst.Operands;
				wrappedByteArray ops2 = inst.Reserved1;

				Boolset options = (Boolset)(ops1[0x02] & 0xbf);
				int scope = cbScope.SelectedIndex;
				options[0] = scope == 2;
				options[1] = scope == 1;
				options[2] = !tfGlobal.Checked;
				options[3] = !tfSemiGlobal.Checked;
				options[4] = tfArgs.Checked;
				options[5] = tfParams.Checked;
				ops1[0x02] = options;
				ops1[0x02] |= (byte)((doidTree.Value >> 2) & 0x40);

				ops1[0x04] = (byte)(doidTree.Value & 0xff);

				if (cbRTBNType.SelectedIndex >= 0)
				{
					ops1[0x05] = (byte)cbRTBNType.SelectedIndex;
				}

				byte[] lohi = { 0, 0 };
				ops1[0x06] = ldocArg1.DataOwner;
				BhavWiz.FromShort(ref lohi, 0, ldocArg1.Value);
				ops1[0x07] = lohi[0];
				ops2[0x00] = lohi[1];
				ops2[0x01] = ldocArg2.DataOwner;
				BhavWiz.FromShort(ref ops2, 2, ldocArg2.Value);
				ops2[0x04] = ldocArg3.DataOwner;
				BhavWiz.FromShort(ref ops2, 5, ldocArg3.Value);
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
			pnWiz0x001c = new Panel();
			flpArgs = new FlowLayoutPanel();
			ldocArg1 = new LabelledDataOwner();
			ldocArg2 = new LabelledDataOwner();
			ldocArg3 = new LabelledDataOwner();
			btnTreeName = new Button();
			tbTree = new TextBox();
			tfGlobal = new CheckBox();
			tfParams = new CheckBox();
			tfArgs = new CheckBox();
			tfSemiGlobal = new CheckBox();
			tfPrivate = new CheckBox();
			cbRTBNType = new ComboBox();
			cbScope = new ComboBox();
			label3 = new Label();
			lbTreeName = new Label();
			label2 = new Label();
			label4 = new Label();
			label8 = new Label();
			label1 = new Label();
			tableLayoutPanel1 = new TableLayoutPanel();
			flowLayoutPanel2 = new FlowLayoutPanel();
			flowLayoutPanel3 = new FlowLayoutPanel();
			flowLayoutPanel4 = new FlowLayoutPanel();
			flowLayoutPanel6 = new FlowLayoutPanel();
			pnWiz0x001c.SuspendLayout();
			flpArgs.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			flowLayoutPanel2.SuspendLayout();
			flowLayoutPanel3.SuspendLayout();
			flowLayoutPanel4.SuspendLayout();
			flowLayoutPanel6.SuspendLayout();
			SuspendLayout();
			//
			// pnWiz0x001c
			//
			resources.ApplyResources(pnWiz0x001c, "pnWiz0x001c");
			pnWiz0x001c.Controls.Add(tableLayoutPanel1);
			pnWiz0x001c.Name = "pnWiz0x001c";
			//
			// flpArgs
			//
			resources.ApplyResources(flpArgs, "flpArgs");
			tableLayoutPanel1.SetColumnSpan(flpArgs, 2);
			flpArgs.Controls.Add(ldocArg1);
			flpArgs.Controls.Add(ldocArg2);
			flpArgs.Controls.Add(ldocArg3);
			flpArgs.Name = "flpArgs";
			//
			// ldocArg1
			//
			resources.ApplyResources(ldocArg1, "ldocArg1");
			ldocArg1.DataOwner = 255;
			ldocArg1.DataOwnerEnabled = true;
			ldocArg1.DecimalVisible = false;
			ldocArg1.Instruction = null;
			ldocArg1.LabelSize = new System.Drawing.Size(61, 13);
			ldocArg1.Name = "ldocArg1";
			ldocArg1.UseFlagNames = false;
			ldocArg1.UseInstancePickerVisible = false;
			ldocArg1.Value = 0;
			//
			// ldocArg2
			//
			resources.ApplyResources(ldocArg2, "ldocArg2");
			ldocArg2.DataOwner = 255;
			ldocArg2.DataOwnerEnabled = true;
			ldocArg2.DecimalVisible = false;
			ldocArg2.Instruction = null;
			ldocArg2.LabelSize = new System.Drawing.Size(61, 13);
			ldocArg2.Name = "ldocArg2";
			ldocArg2.UseFlagNames = false;
			ldocArg2.UseInstancePickerVisible = false;
			ldocArg2.Value = 0;
			//
			// ldocArg3
			//
			resources.ApplyResources(ldocArg3, "ldocArg3");
			ldocArg3.DataOwner = 255;
			ldocArg3.DataOwnerEnabled = true;
			ldocArg3.Instruction = null;
			ldocArg3.LabelSize = new System.Drawing.Size(61, 13);
			ldocArg3.Name = "ldocArg3";
			ldocArg3.UseFlagNames = false;
			ldocArg3.Value = 0;
			//
			// btnTreeName
			//
			resources.ApplyResources(btnTreeName, "btnTreeName");
			btnTreeName.Name = "btnTreeName";
			btnTreeName.Click += new EventHandler(btnTreeName_Click);
			//
			// tbTree
			//
			resources.ApplyResources(tbTree, "tbTree");
			tbTree.Name = "tbTree";
			//
			// tfGlobal
			//
			resources.ApplyResources(tfGlobal, "tfGlobal");
			tfGlobal.Name = "tfGlobal";
			tfGlobal.UseVisualStyleBackColor = true;
			//
			// tfParams
			//
			resources.ApplyResources(tfParams, "tfParams");
			tfParams.Name = "tfParams";
			tfParams.UseVisualStyleBackColor = true;
			//
			// tfArgs
			//
			resources.ApplyResources(tfArgs, "tfArgs");
			tfArgs.Name = "tfArgs";
			tfArgs.UseVisualStyleBackColor = true;
			tfArgs.CheckedChanged += new EventHandler(
				tfArgs_CheckedChanged
			);
			//
			// tfSemiGlobal
			//
			resources.ApplyResources(tfSemiGlobal, "tfSemiGlobal");
			tfSemiGlobal.Name = "tfSemiGlobal";
			tfSemiGlobal.UseVisualStyleBackColor = true;
			//
			// tfPrivate
			//
			resources.ApplyResources(tfPrivate, "tfPrivate");
			tfPrivate.Checked = true;
			tfPrivate.CheckState = CheckState.Checked;
			tfPrivate.Name = "tfPrivate";
			tfPrivate.UseVisualStyleBackColor = true;
			//
			// cbRTBNType
			//
			cbRTBNType.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbRTBNType.FormattingEnabled = true;
			cbRTBNType.Items.AddRange(
				new object[]
				{
					resources.GetString("cbRTBNType.Items"),
					resources.GetString("cbRTBNType.Items1"),
					resources.GetString("cbRTBNType.Items2"),
				}
			);
			resources.ApplyResources(cbRTBNType, "cbRTBNType");
			cbRTBNType.Name = "cbRTBNType";
			//
			// cbScope
			//
			resources.ApplyResources(cbScope, "cbScope");
			cbScope.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbScope.FormattingEnabled = true;
			cbScope.Items.AddRange(
				new object[]
				{
					resources.GetString("cbScope.Items"),
					resources.GetString("cbScope.Items1"),
					resources.GetString("cbScope.Items2"),
				}
			);
			cbScope.Name = "cbScope";
			cbScope.SelectedIndexChanged += new EventHandler(
				cbScope_SelectedIndexChanged
			);
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// lbTreeName
			//
			resources.ApplyResources(lbTreeName, "lbTreeName");
			lbTreeName.Name = "lbTreeName";
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// label4
			//
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// label8
			//
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// tableLayoutPanel1
			//
			resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
			tableLayoutPanel1.Controls.Add(flpArgs, 0, 5);
			tableLayoutPanel1.Controls.Add(label1, 0, 0);
			tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 1, 0);
			tableLayoutPanel1.Controls.Add(label2, 0, 1);
			tableLayoutPanel1.Controls.Add(cbRTBNType, 1, 3);
			tableLayoutPanel1.Controls.Add(flowLayoutPanel4, 1, 1);
			tableLayoutPanel1.Controls.Add(label4, 0, 3);
			tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 2);
			tableLayoutPanel1.Controls.Add(flowLayoutPanel6, 0, 4);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			//
			// flowLayoutPanel2
			//
			resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
			flowLayoutPanel2.Controls.Add(cbScope);
			flowLayoutPanel2.Controls.Add(label8);
			flowLayoutPanel2.Name = "flowLayoutPanel2";
			//
			// flowLayoutPanel3
			//
			resources.ApplyResources(flowLayoutPanel3, "flowLayoutPanel3");
			tableLayoutPanel1.SetColumnSpan(flowLayoutPanel3, 2);
			flowLayoutPanel3.Controls.Add(label3);
			flowLayoutPanel3.Controls.Add(tfPrivate);
			flowLayoutPanel3.Controls.Add(tfSemiGlobal);
			flowLayoutPanel3.Controls.Add(tfGlobal);
			flowLayoutPanel3.Name = "flowLayoutPanel3";
			//
			// flowLayoutPanel4
			//
			resources.ApplyResources(flowLayoutPanel4, "flowLayoutPanel4");
			flowLayoutPanel4.Controls.Add(tbTree);
			flowLayoutPanel4.Controls.Add(btnTreeName);
			flowLayoutPanel4.Controls.Add(lbTreeName);
			flowLayoutPanel4.Name = "flowLayoutPanel4";
			//
			// flowLayoutPanel6
			//
			resources.ApplyResources(flowLayoutPanel6, "flowLayoutPanel6");
			tableLayoutPanel1.SetColumnSpan(flowLayoutPanel6, 2);
			flowLayoutPanel6.Controls.Add(tfArgs);
			flowLayoutPanel6.Controls.Add(tfParams);
			flowLayoutPanel6.Name = "flowLayoutPanel6";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(pnWiz0x001c);
			Name = "UI";
			pnWiz0x001c.ResumeLayout(false);
			pnWiz0x001c.PerformLayout();
			flpArgs.ResumeLayout(false);
			flpArgs.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			flowLayoutPanel2.ResumeLayout(false);
			flowLayoutPanel2.PerformLayout();
			flowLayoutPanel3.ResumeLayout(false);
			flowLayoutPanel3.PerformLayout();
			flowLayoutPanel4.ResumeLayout(false);
			flowLayoutPanel4.PerformLayout();
			flowLayoutPanel6.ResumeLayout(false);
			flowLayoutPanel6.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		private void btnTreeName_Click(object sender, EventArgs e)
		{
			doStrChooser();
		}

		private void tfArgs_CheckedChanged(object sender, EventArgs e)
		{
			flpArgs.Enabled = tfArgs.Checked;
		}

		private void cbScope_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			lbTreeName.Text = ((BhavWiz)inst).readStr(
				Scope,
				GS.GlobalStr.NamedTree,
				(ushort)(doidTree.Value - 1),
				-1,
				Detail.ErrorNames
			);
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x001c : ABhavOperandWiz
	{
		public BhavOperandWiz0x001c(Instruction i)
			: base(i)
		{
			myForm = new Wiz0x001c.UI();
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
