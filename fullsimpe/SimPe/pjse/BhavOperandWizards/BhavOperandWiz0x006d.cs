/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
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
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x006d
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		internal Panel pnWiz0x006d;
		private Label label1;
		private Panel pnMaterial;
		private Label label3;
		private ComboBox cbPicker1;
		private CheckBox cbDecimal;
		private TextBox tbVal1;
		private CheckBox cbAttrPicker;
		private ComboBox cbDataOwner1;
		private RadioButton rb1Object;
		private RadioButton rb1Me;
		private RadioButton rb1ScrShot;
		private Panel pnNotScrShot;
		private CheckBox ckbMaterialTemp;
		private RadioButton rb2MovingTexture;
		private RadioButton rb2Material;
		private Label label5;
		private TextBox tbVal3;
		private ComboBox cbMatScope;
		private Label label6;
		private Button btnMaterial;
		private TextBox tbMaterial;
		private Panel panel1;
		private Label label2;
		private RadioButton rb3Object;
		private RadioButton rb3Me;
		private Panel pnNotAllOver;
		private CheckBox ckbAllOver;
		private ComboBox cbMeshScope;
		private Label label4;
		private Label label7;
		private TextBox tbMesh;
		private Button btnMesh;
		private TextBox tbVal5;
		private Label label8;
		private CheckBox ckbMeshTemp;
		private Label label9;
		private ComboBox cbPicker2;
		private TextBox tbVal2;
		private ComboBox cbDataOwner2;

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

			rb1group = new ArrayList(
				new Control[] { rb1ScrShot, rb1Me, rb1Object }
			);
			rb3group = new ArrayList(new Control[] { rb3Me, rb3Object });
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

		private DataOwnerControl doid1 = null;
		private DataOwnerControl doid2 = null;
		private DataOwnerControl doid3 = null;
		private DataOwnerControl doid5 = null;

		ArrayList rb1group = null;
		ArrayList rb3group = null;
		private bool internalchg = false;

		void doid3_DataOwnerControlChanged(object sender, EventArgs e)
		{
			doStrValue(cbMatScope, GS.GlobalStr.MaterialName, doid3.Value, tbMaterial);
		}

		void doid5_DataOwnerControlChanged(object sender, EventArgs e)
		{
			doStrValue(cbMeshScope, GS.GlobalStr.MeshGroup, doid5.Value, tbMesh);
		}

		private void doStrChooser(
			ComboBox scope,
			GS.GlobalStr instance,
			TextBox tbVal,
			TextBox strText
		)
		{
			Scope[] s = { Scope.Private, Scope.SemiGlobal, Scope.Global };
			FileTable.Entry[] items =
				(scope.SelectedIndex < 0)
					? null
					: FileTable.GFT[
						SimPe.Data.MetaData.STRING_FILE,
						inst.Parent.GroupForScope(s[scope.SelectedIndex]),
						(uint)instance
					];

			if (items == null || items.Length == 0)
			{
				MessageBox.Show(
					Localization.GetString("bow_noStrings")
						+ " ("
						+ Localization.GetString(s[scope.SelectedIndex].ToString())
						+ ")"
				);
				return; // eek!
			}

			StrWrapper str = new StrWrapper();
			str.ProcessData(items[0].PFD, items[0].Package);

			int i = (new StrChooser(true)).Strnum(str);
			if (i >= 0)
			{
				bool savedState = internalchg;
				internalchg = true;
				tbVal.Text = "0x" + SimPe.Helper.HexString((ushort)i);
				doStrValue(scope, instance, (ushort)i, strText);
				internalchg = savedState;
			}
		}

		private void doStrValue(
			ComboBox scope,
			GS.GlobalStr instance,
			ushort strno,
			TextBox strText
		)
		{
			Scope[] s = { Scope.Private, Scope.Global, Scope.SemiGlobal };
			strText.Text =
				(scope.SelectedIndex < 0)
					? ""
					: ((BhavWiz)inst).readStr(
						s[scope.SelectedIndex],
						instance,
						strno,
						-1,
						Detail.ErrorNames
					);
		}

		private void MaterialFrom()
		{
			pnNotScrShot.Enabled = !rb1ScrShot.Checked;
			tbVal3.Enabled = !ckbMaterialTemp.Checked;
			btnMaterial.Enabled = tbMaterial.Visible =
				rb1Me.Checked && !ckbMaterialTemp.Checked;
		}

		private void MeshFrom()
		{
			pnNotAllOver.Enabled = !ckbAllOver.Checked;
			tbVal5.Enabled = !ckbMeshTemp.Checked;
			btnMesh.Enabled = tbMesh.Visible =
				!ckbAllOver.Checked
				&& rb3Me.Checked
				&& !ckbMeshTemp.Checked;
		}

		#region iBhavOperandWizForm
		public Panel WizPanel => pnWiz0x006d;

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			wrappedByteArray ops1 = inst.Operands;
			wrappedByteArray ops2 = inst.Reserved1;

			internalchg = true;

			doid3 = new DataOwnerControl(
				inst,
				null,
				null,
				tbVal3,
				cbDecimal,
				cbAttrPicker,
				null,
				0x07,
				BhavWiz.ToShort(ops1[0x00], ops1[0x01])
			);

			rb3Object.Checked = ((ops1[0x02] & 0x01) != 0);
			btnMesh.Visible =
				tbMesh.Visible =
				rb3Me.Checked =
					!rb3Object.Checked;

			cbMatScope.SelectedIndex = -1;
			switch (ops1[0x02] & 0x06)
			{
				case 0x00:
					cbMatScope.SelectedIndex = 0;
					break; // Private
				case 0x02:
					cbMatScope.SelectedIndex = 2;
					break; // Global
				case 0x04:
					cbMatScope.SelectedIndex = 1;
					break; // SemiGlobal
			}

			rb1ScrShot.Checked = ((ops2[0x05] & 0x02) != 0);
			rb1Me.Checked = !rb1ScrShot.Checked && ((ops1[0x02] & 0x08) == 0);
			rb1Object.Checked = !rb1ScrShot.Checked && !rb1Me.Checked;

			rb2MovingTexture.Checked = ((ops2[0x05] & 0x01) != 0);
			rb2Material.Checked = !rb2MovingTexture.Checked;

			ckbMaterialTemp.Checked = ((ops1[0x02] & 0x10) != 0);
			ckbMeshTemp.Checked = ((ops1[0x02] & 0x20) != 0);

			cbMeshScope.SelectedIndex = -1;
			switch (ops1[0x02] & 0xc0)
			{
				case 0x00:
					cbMeshScope.SelectedIndex = 0;
					break; // Private
				case 0x40:
					cbMeshScope.SelectedIndex = 2;
					break; // Global
				case 0x80:
					cbMeshScope.SelectedIndex = 1;
					break; // SemiGlobal
			}

			doid5 = new DataOwnerControl(
				inst,
				null,
				null,
				tbVal5,
				cbDecimal,
				cbAttrPicker,
				null,
				0x07,
				(ushort)(BhavWiz.ToShort(ops1[0x03], ops1[0x04]) & 0x7fff)
			);
			ckbAllOver.Checked = (ops1[0x04] & 0x80) != 0;

			doid1 = new DataOwnerControl(
				inst,
				cbDataOwner1,
				cbPicker1,
				tbVal1,
				cbDecimal,
				cbAttrPicker,
				null,
				ops1[0x05],
				BhavWiz.ToShort(ops1[0x06], ops1[0x07])
			);
			doid2 = new DataOwnerControl(
				inst,
				cbDataOwner2,
				cbPicker2,
				tbVal2,
				cbDecimal,
				cbAttrPicker,
				null,
				ops2[0x00],
				BhavWiz.ToShort(ops2[0x01], ops2[0x02])
			);

			doid3.DataOwnerControlChanged += new EventHandler(
				doid3_DataOwnerControlChanged
			);
			doid3_DataOwnerControlChanged(null, null);
			doid5.DataOwnerControlChanged += new EventHandler(
				doid5_DataOwnerControlChanged
			);
			doid5_DataOwnerControlChanged(null, null);

			internalchg = false;

			MaterialFrom();
			MeshFrom();
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops1 = inst.Operands;
				wrappedByteArray ops2 = inst.Reserved1;

				BhavWiz.FromShort(ref ops1, 0, doid3.Value);

				ops1[0x02] = 0x00;
				ops1[0x02] |= (byte)(rb3Object.Checked ? 0x01 : 0x00);
				switch (cbMatScope.SelectedIndex)
				{
					case 2:
						ops1[0x02] |= 0x02;
						break; // Global
					case 1:
						ops1[0x02] |= 0x04;
						break; // SemiGlobal
				}
				ops1[0x02] |= (byte)(rb1Object.Checked ? 0x08 : 0x00);
				ops1[0x02] |= (byte)(ckbMaterialTemp.Checked ? 0x10 : 0x00);
				ops1[0x02] |= (byte)(ckbMeshTemp.Checked ? 0x20 : 0x00);
				switch (cbMeshScope.SelectedIndex)
				{
					case 2:
						ops1[0x02] |= 0x40;
						break; // Global
					case 1:
						ops1[0x02] |= 0x80;
						break; // SemiGlobal
				}

				BhavWiz.FromShort(ref ops1, 3, (ushort)(doid5.Value & 0x7fff));
				ops1[0x04] |= (byte)(ckbAllOver.Checked ? 0x80 : 0x00);

				ops1[0x05] = doid1.DataOwner;
				BhavWiz.FromShort(ref ops1, 6, doid1.Value);

				ops2[0x00] = doid2.DataOwner;
				BhavWiz.FromShort(ref ops2, 1, doid2.Value);

				ops2[0x05] &= 0xfc;
				ops2[0x05] |= (byte)(rb2MovingTexture.Checked ? 0x01 : 0x00);
				ops2[0x05] |= (byte)(rb1ScrShot.Checked ? 0x02 : 0x00);
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
			pnWiz0x006d = new Panel();
			cbPicker2 = new ComboBox();
			cbAttrPicker = new CheckBox();
			cbDecimal = new CheckBox();
			tbVal2 = new TextBox();
			cbDataOwner2 = new ComboBox();
			panel1 = new Panel();
			pnNotAllOver = new Panel();
			tbMesh = new TextBox();
			btnMesh = new Button();
			tbVal5 = new TextBox();
			label8 = new Label();
			ckbMeshTemp = new CheckBox();
			cbMeshScope = new ComboBox();
			label4 = new Label();
			ckbAllOver = new CheckBox();
			rb3Object = new RadioButton();
			rb3Me = new RadioButton();
			label2 = new Label();
			cbPicker1 = new ComboBox();
			tbVal1 = new TextBox();
			cbDataOwner1 = new ComboBox();
			pnMaterial = new Panel();
			pnNotScrShot = new Panel();
			tbMaterial = new TextBox();
			btnMaterial = new Button();
			tbVal3 = new TextBox();
			cbMatScope = new ComboBox();
			label7 = new Label();
			label6 = new Label();
			label5 = new Label();
			ckbMaterialTemp = new CheckBox();
			rb2MovingTexture = new RadioButton();
			rb2Material = new RadioButton();
			rb1Object = new RadioButton();
			rb1Me = new RadioButton();
			rb1ScrShot = new RadioButton();
			label3 = new Label();
			label9 = new Label();
			label1 = new Label();
			pnWiz0x006d.SuspendLayout();
			panel1.SuspendLayout();
			pnNotAllOver.SuspendLayout();
			pnMaterial.SuspendLayout();
			pnNotScrShot.SuspendLayout();
			SuspendLayout();
			//
			// pnWiz0x006d
			//
			pnWiz0x006d.Controls.Add(cbPicker2);
			pnWiz0x006d.Controls.Add(cbAttrPicker);
			pnWiz0x006d.Controls.Add(cbDecimal);
			pnWiz0x006d.Controls.Add(tbVal2);
			pnWiz0x006d.Controls.Add(cbDataOwner2);
			pnWiz0x006d.Controls.Add(panel1);
			pnWiz0x006d.Controls.Add(cbPicker1);
			pnWiz0x006d.Controls.Add(tbVal1);
			pnWiz0x006d.Controls.Add(cbDataOwner1);
			pnWiz0x006d.Controls.Add(pnMaterial);
			pnWiz0x006d.Controls.Add(label9);
			pnWiz0x006d.Controls.Add(label1);
			resources.ApplyResources(pnWiz0x006d, "pnWiz0x006d");
			pnWiz0x006d.Name = "pnWiz0x006d";
			//
			// cbPicker2
			//
			cbPicker2.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPicker2.DropDownWidth = 384;
			resources.ApplyResources(cbPicker2, "cbPicker2");
			cbPicker2.Name = "cbPicker2";
			//
			// cbAttrPicker
			//
			resources.ApplyResources(cbAttrPicker, "cbAttrPicker");
			cbAttrPicker.Name = "cbAttrPicker";
			//
			// cbDecimal
			//
			resources.ApplyResources(cbDecimal, "cbDecimal");
			cbDecimal.Name = "cbDecimal";
			//
			// tbVal2
			//
			resources.ApplyResources(tbVal2, "tbVal2");
			tbVal2.Name = "tbVal2";
			//
			// cbDataOwner2
			//
			cbDataOwner2.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbDataOwner2.DropDownWidth = 384;
			resources.ApplyResources(cbDataOwner2, "cbDataOwner2");
			cbDataOwner2.Name = "cbDataOwner2";
			//
			// panel1
			//
			resources.ApplyResources(panel1, "panel1");
			panel1.Controls.Add(pnNotAllOver);
			panel1.Controls.Add(ckbAllOver);
			panel1.Controls.Add(rb3Object);
			panel1.Controls.Add(rb3Me);
			panel1.Controls.Add(label2);
			panel1.Name = "panel1";
			//
			// pnNotAllOver
			//
			resources.ApplyResources(pnNotAllOver, "pnNotAllOver");
			pnNotAllOver.Controls.Add(tbMesh);
			pnNotAllOver.Controls.Add(btnMesh);
			pnNotAllOver.Controls.Add(tbVal5);
			pnNotAllOver.Controls.Add(label8);
			pnNotAllOver.Controls.Add(ckbMeshTemp);
			pnNotAllOver.Controls.Add(cbMeshScope);
			pnNotAllOver.Controls.Add(label4);
			pnNotAllOver.Name = "pnNotAllOver";
			//
			// tbMesh
			//
			resources.ApplyResources(tbMesh, "tbMesh");
			tbMesh.BorderStyle = BorderStyle.None;
			tbMesh.Name = "tbMesh";
			tbMesh.ReadOnly = true;
			tbMesh.TabStop = false;
			//
			// btnMesh
			//
			resources.ApplyResources(btnMesh, "btnMesh");
			btnMesh.Name = "btnMesh";
			btnMesh.Click += new EventHandler(btnMesh_Click);
			//
			// tbVal5
			//
			resources.ApplyResources(tbVal5, "tbVal5");
			tbVal5.Name = "tbVal5";
			//
			// label8
			//
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			//
			// ckbMeshTemp
			//
			resources.ApplyResources(ckbMeshTemp, "ckbMeshTemp");
			ckbMeshTemp.Name = "ckbMeshTemp";
			ckbMeshTemp.UseVisualStyleBackColor = true;
			ckbMeshTemp.CheckedChanged += new EventHandler(
				ckbMeshTemp_CheckedChanged
			);
			//
			// cbMeshScope
			//
			cbMeshScope.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbMeshScope.FormattingEnabled = true;
			cbMeshScope.Items.AddRange(
				new object[]
				{
					resources.GetString("cbMeshScope.Items"),
					resources.GetString("cbMeshScope.Items1"),
					resources.GetString("cbMeshScope.Items2"),
				}
			);
			resources.ApplyResources(cbMeshScope, "cbMeshScope");
			cbMeshScope.Name = "cbMeshScope";
			cbMeshScope.SelectedIndexChanged += new EventHandler(
				cbMatMeshScope_SelectedIndexChanged
			);
			//
			// label4
			//
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// ckbAllOver
			//
			resources.ApplyResources(ckbAllOver, "ckbAllOver");
			ckbAllOver.Name = "ckbAllOver";
			ckbAllOver.UseVisualStyleBackColor = true;
			ckbAllOver.CheckedChanged += new EventHandler(
				ckbAllOver_CheckedChanged
			);
			//
			// rb3Object
			//
			resources.ApplyResources(rb3Object, "rb3Object");
			rb3Object.Name = "rb3Object";
			rb3Object.TabStop = true;
			rb3Object.UseVisualStyleBackColor = true;
			rb3Object.CheckedChanged += new EventHandler(
				rb3group_CheckedChanged
			);
			//
			// rb3Me
			//
			resources.ApplyResources(rb3Me, "rb3Me");
			rb3Me.Name = "rb3Me";
			rb3Me.TabStop = true;
			rb3Me.UseVisualStyleBackColor = true;
			rb3Me.CheckedChanged += new EventHandler(
				rb3group_CheckedChanged
			);
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// cbPicker1
			//
			cbPicker1.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbPicker1.DropDownWidth = 384;
			resources.ApplyResources(cbPicker1, "cbPicker1");
			cbPicker1.Name = "cbPicker1";
			//
			// tbVal1
			//
			resources.ApplyResources(tbVal1, "tbVal1");
			tbVal1.Name = "tbVal1";
			//
			// cbDataOwner1
			//
			cbDataOwner1.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbDataOwner1.DropDownWidth = 384;
			resources.ApplyResources(cbDataOwner1, "cbDataOwner1");
			cbDataOwner1.Name = "cbDataOwner1";
			//
			// pnMaterial
			//
			resources.ApplyResources(pnMaterial, "pnMaterial");
			pnMaterial.Controls.Add(pnNotScrShot);
			pnMaterial.Controls.Add(rb1Object);
			pnMaterial.Controls.Add(rb1Me);
			pnMaterial.Controls.Add(rb1ScrShot);
			pnMaterial.Controls.Add(label3);
			pnMaterial.Name = "pnMaterial";
			//
			// pnNotScrShot
			//
			resources.ApplyResources(pnNotScrShot, "pnNotScrShot");
			pnNotScrShot.Controls.Add(tbMaterial);
			pnNotScrShot.Controls.Add(btnMaterial);
			pnNotScrShot.Controls.Add(tbVal3);
			pnNotScrShot.Controls.Add(cbMatScope);
			pnNotScrShot.Controls.Add(label7);
			pnNotScrShot.Controls.Add(label6);
			pnNotScrShot.Controls.Add(label5);
			pnNotScrShot.Controls.Add(ckbMaterialTemp);
			pnNotScrShot.Controls.Add(rb2MovingTexture);
			pnNotScrShot.Controls.Add(rb2Material);
			pnNotScrShot.Name = "pnNotScrShot";
			//
			// tbMaterial
			//
			resources.ApplyResources(tbMaterial, "tbMaterial");
			tbMaterial.BorderStyle = BorderStyle.None;
			tbMaterial.Name = "tbMaterial";
			tbMaterial.ReadOnly = true;
			tbMaterial.TabStop = false;
			//
			// btnMaterial
			//
			resources.ApplyResources(btnMaterial, "btnMaterial");
			btnMaterial.Name = "btnMaterial";
			btnMaterial.Click += new EventHandler(btnMaterial_Click);
			//
			// tbVal3
			//
			resources.ApplyResources(tbVal3, "tbVal3");
			tbVal3.Name = "tbVal3";
			//
			// cbMatScope
			//
			cbMatScope.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbMatScope.FormattingEnabled = true;
			cbMatScope.Items.AddRange(
				new object[]
				{
					resources.GetString("cbMatScope.Items"),
					resources.GetString("cbMatScope.Items1"),
					resources.GetString("cbMatScope.Items2"),
				}
			);
			resources.ApplyResources(cbMatScope, "cbMatScope");
			cbMatScope.Name = "cbMatScope";
			cbMatScope.SelectedIndexChanged += new EventHandler(
				cbMatMeshScope_SelectedIndexChanged
			);
			//
			// label7
			//
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			//
			// label6
			//
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			//
			// label5
			//
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			//
			// ckbMaterialTemp
			//
			resources.ApplyResources(ckbMaterialTemp, "ckbMaterialTemp");
			ckbMaterialTemp.Name = "ckbMaterialTemp";
			ckbMaterialTemp.UseVisualStyleBackColor = true;
			ckbMaterialTemp.CheckedChanged += new EventHandler(
				ckbMaterialTemp_CheckedChanged
			);
			//
			// rb2MovingTexture
			//
			resources.ApplyResources(rb2MovingTexture, "rb2MovingTexture");
			rb2MovingTexture.Name = "rb2MovingTexture";
			rb2MovingTexture.TabStop = true;
			rb2MovingTexture.UseVisualStyleBackColor = true;
			//
			// rb2Material
			//
			resources.ApplyResources(rb2Material, "rb2Material");
			rb2Material.Name = "rb2Material";
			rb2Material.TabStop = true;
			rb2Material.UseVisualStyleBackColor = true;
			//
			// rb1Object
			//
			resources.ApplyResources(rb1Object, "rb1Object");
			rb1Object.Name = "rb1Object";
			rb1Object.TabStop = true;
			rb1Object.UseVisualStyleBackColor = true;
			rb1Object.CheckedChanged += new EventHandler(
				rb1group_CheckedChanged
			);
			//
			// rb1Me
			//
			resources.ApplyResources(rb1Me, "rb1Me");
			rb1Me.Name = "rb1Me";
			rb1Me.TabStop = true;
			rb1Me.UseVisualStyleBackColor = true;
			rb1Me.CheckedChanged += new EventHandler(
				rb1group_CheckedChanged
			);
			//
			// rb1ScrShot
			//
			resources.ApplyResources(rb1ScrShot, "rb1ScrShot");
			rb1ScrShot.Name = "rb1ScrShot";
			rb1ScrShot.TabStop = true;
			rb1ScrShot.UseVisualStyleBackColor = true;
			rb1ScrShot.CheckedChanged += new EventHandler(
				rb1group_CheckedChanged
			);
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// label9
			//
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(pnWiz0x006d);
			Name = "UI";
			pnWiz0x006d.ResumeLayout(false);
			pnWiz0x006d.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			pnNotAllOver.ResumeLayout(false);
			pnNotAllOver.PerformLayout();
			pnMaterial.ResumeLayout(false);
			pnMaterial.PerformLayout();
			pnNotScrShot.ResumeLayout(false);
			pnNotScrShot.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		private void rb1group_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			MaterialFrom();
		}

		private void ckbMaterialTemp_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			MaterialFrom();
		}

		private void btnMaterial_Click(object sender, EventArgs e)
		{
			doStrChooser(
				cbMatScope,
				GS.GlobalStr.MaterialName,
				tbVal3,
				tbMaterial
			);
		}

		private void rb3group_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			MeshFrom();
		}

		private void ckbAllOver_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			MeshFrom();
		}

		private void ckbMeshTemp_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			MeshFrom();
		}

		private void btnMesh_Click(object sender, EventArgs e)
		{
			doStrChooser(
				cbMeshScope,
				GS.GlobalStr.MeshGroup,
				tbVal5,
				tbMesh
			);
		}

		private void cbMatMeshScope_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			if (sender.Equals(cbMatScope))
			{
				doStrValue(
					cbMatScope,
					GS.GlobalStr.MaterialName,
					doid3.Value,
					tbMaterial
				);
			}
			else
			{
				doStrValue(cbMeshScope, GS.GlobalStr.MeshGroup, doid5.Value, tbMesh);
			}
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x006d : ABhavOperandWiz
	{
		public BhavOperandWiz0x006d(Instruction i)
			: base(i)
		{
			myForm = new Wiz0x006d.UI();
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
