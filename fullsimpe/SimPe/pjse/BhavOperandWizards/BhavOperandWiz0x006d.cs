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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x006d
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	internal class UI : System.Windows.Forms.Form, iBhavOperandWizForm
	{
		#region Form variables

		internal System.Windows.Forms.Panel pnWiz0x006d;
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
				new Control[] { this.rb1ScrShot, this.rb1Me, this.rb1Object }
			);
			rb3group = new ArrayList(new Control[] { this.rb3Me, this.rb3Object });
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
			pjse.GS.GlobalStr instance,
			TextBox tbVal,
			TextBox strText
		)
		{
			Scope[] s = { Scope.Private, Scope.SemiGlobal, Scope.Global };
			pjse.FileTable.Entry[] items =
				(scope.SelectedIndex < 0)
					? null
					: pjse.FileTable.GFT[
						(uint)SimPe.Data.MetaData.STRING_FILE,
						inst.Parent.GroupForScope(s[scope.SelectedIndex]),
						(uint)instance
					];

			if (items == null || items.Length == 0)
			{
				MessageBox.Show(
					pjse.Localization.GetString("bow_noStrings")
						+ " ("
						+ pjse.Localization.GetString(s[scope.SelectedIndex].ToString())
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
				doStrValue(scope, instance, (ushort)i, strText);
				internalchg = savedState;
			}
		}

		private void doStrValue(
			ComboBox scope,
			pjse.GS.GlobalStr instance,
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
						pjse.Detail.ErrorNames
					);
		}

		private void MaterialFrom()
		{
			this.pnNotScrShot.Enabled = !this.rb1ScrShot.Checked;
			this.tbVal3.Enabled = !this.ckbMaterialTemp.Checked;
			this.btnMaterial.Enabled = this.tbMaterial.Visible =
				this.rb1Me.Checked && !this.ckbMaterialTemp.Checked;
		}

		private void MeshFrom()
		{
			this.pnNotAllOver.Enabled = !this.ckbAllOver.Checked;
			this.tbVal5.Enabled = !this.ckbMeshTemp.Checked;
			this.btnMesh.Enabled = this.tbMesh.Visible =
				!this.ckbAllOver.Checked
				&& this.rb3Me.Checked
				&& !this.ckbMeshTemp.Checked;
		}

		#region iBhavOperandWizForm
		public Panel WizPanel => this.pnWiz0x006d;

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
				this.tbVal3,
				this.cbDecimal,
				this.cbAttrPicker,
				null,
				0x07,
				BhavWiz.ToShort(ops1[0x00], ops1[0x01])
			);

			this.rb3Object.Checked = ((ops1[0x02] & 0x01) != 0);
			this.btnMesh.Visible =
				this.tbMesh.Visible =
				this.rb3Me.Checked =
					!this.rb3Object.Checked;

			this.cbMatScope.SelectedIndex = -1;
			switch (ops1[0x02] & 0x06)
			{
				case 0x00:
					this.cbMatScope.SelectedIndex = 0;
					break; // Private
				case 0x02:
					this.cbMatScope.SelectedIndex = 2;
					break; // Global
				case 0x04:
					this.cbMatScope.SelectedIndex = 1;
					break; // SemiGlobal
			}

			this.rb1ScrShot.Checked = ((ops2[0x05] & 0x02) != 0);
			this.rb1Me.Checked = !this.rb1ScrShot.Checked && ((ops1[0x02] & 0x08) == 0);
			this.rb1Object.Checked = !this.rb1ScrShot.Checked && !this.rb1Me.Checked;

			this.rb2MovingTexture.Checked = ((ops2[0x05] & 0x01) != 0);
			this.rb2Material.Checked = !this.rb2MovingTexture.Checked;

			this.ckbMaterialTemp.Checked = ((ops1[0x02] & 0x10) != 0);
			this.ckbMeshTemp.Checked = ((ops1[0x02] & 0x20) != 0);

			this.cbMeshScope.SelectedIndex = -1;
			switch (ops1[0x02] & 0xc0)
			{
				case 0x00:
					this.cbMeshScope.SelectedIndex = 0;
					break; // Private
				case 0x40:
					this.cbMeshScope.SelectedIndex = 2;
					break; // Global
				case 0x80:
					this.cbMeshScope.SelectedIndex = 1;
					break; // SemiGlobal
			}

			doid5 = new DataOwnerControl(
				inst,
				null,
				null,
				this.tbVal5,
				this.cbDecimal,
				this.cbAttrPicker,
				null,
				0x07,
				(ushort)(BhavWiz.ToShort(ops1[0x03], ops1[0x04]) & 0x7fff)
			);
			this.ckbAllOver.Checked = (ops1[0x04] & 0x80) != 0;

			doid1 = new DataOwnerControl(
				inst,
				this.cbDataOwner1,
				this.cbPicker1,
				this.tbVal1,
				this.cbDecimal,
				this.cbAttrPicker,
				null,
				ops1[0x05],
				BhavWiz.ToShort(ops1[0x06], ops1[0x07])
			);
			doid2 = new DataOwnerControl(
				inst,
				this.cbDataOwner2,
				this.cbPicker2,
				this.tbVal2,
				this.cbDecimal,
				this.cbAttrPicker,
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

			this.MaterialFrom();
			this.MeshFrom();
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops1 = inst.Operands;
				wrappedByteArray ops2 = inst.Reserved1;

				BhavWiz.FromShort(ref ops1, 0, doid3.Value);

				ops1[0x02] = 0x00;
				ops1[0x02] |= (byte)(this.rb3Object.Checked ? 0x01 : 0x00);
				switch (this.cbMatScope.SelectedIndex)
				{
					case 2:
						ops1[0x02] |= 0x02;
						break; // Global
					case 1:
						ops1[0x02] |= 0x04;
						break; // SemiGlobal
				}
				ops1[0x02] |= (byte)(this.rb1Object.Checked ? 0x08 : 0x00);
				ops1[0x02] |= (byte)(this.ckbMaterialTemp.Checked ? 0x10 : 0x00);
				ops1[0x02] |= (byte)(this.ckbMeshTemp.Checked ? 0x20 : 0x00);
				switch (this.cbMeshScope.SelectedIndex)
				{
					case 2:
						ops1[0x02] |= 0x40;
						break; // Global
					case 1:
						ops1[0x02] |= 0x80;
						break; // SemiGlobal
				}

				BhavWiz.FromShort(ref ops1, 3, (ushort)(doid5.Value & 0x7fff));
				ops1[0x04] |= (byte)(this.ckbAllOver.Checked ? 0x80 : 0x00);

				ops1[0x05] = doid1.DataOwner;
				BhavWiz.FromShort(ref ops1, 6, doid1.Value);

				ops2[0x00] = doid2.DataOwner;
				BhavWiz.FromShort(ref ops2, 1, doid2.Value);

				ops2[0x05] &= 0xfc;
				ops2[0x05] |= (byte)(this.rb2MovingTexture.Checked ? 0x01 : 0x00);
				ops2[0x05] |= (byte)(this.rb1ScrShot.Checked ? 0x02 : 0x00);
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
			this.pnWiz0x006d = new System.Windows.Forms.Panel();
			this.cbPicker2 = new System.Windows.Forms.ComboBox();
			this.cbAttrPicker = new System.Windows.Forms.CheckBox();
			this.cbDecimal = new System.Windows.Forms.CheckBox();
			this.tbVal2 = new System.Windows.Forms.TextBox();
			this.cbDataOwner2 = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pnNotAllOver = new System.Windows.Forms.Panel();
			this.tbMesh = new System.Windows.Forms.TextBox();
			this.btnMesh = new System.Windows.Forms.Button();
			this.tbVal5 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.ckbMeshTemp = new System.Windows.Forms.CheckBox();
			this.cbMeshScope = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ckbAllOver = new System.Windows.Forms.CheckBox();
			this.rb3Object = new System.Windows.Forms.RadioButton();
			this.rb3Me = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.cbPicker1 = new System.Windows.Forms.ComboBox();
			this.tbVal1 = new System.Windows.Forms.TextBox();
			this.cbDataOwner1 = new System.Windows.Forms.ComboBox();
			this.pnMaterial = new System.Windows.Forms.Panel();
			this.pnNotScrShot = new System.Windows.Forms.Panel();
			this.tbMaterial = new System.Windows.Forms.TextBox();
			this.btnMaterial = new System.Windows.Forms.Button();
			this.tbVal3 = new System.Windows.Forms.TextBox();
			this.cbMatScope = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.ckbMaterialTemp = new System.Windows.Forms.CheckBox();
			this.rb2MovingTexture = new System.Windows.Forms.RadioButton();
			this.rb2Material = new System.Windows.Forms.RadioButton();
			this.rb1Object = new System.Windows.Forms.RadioButton();
			this.rb1Me = new System.Windows.Forms.RadioButton();
			this.rb1ScrShot = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pnWiz0x006d.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnNotAllOver.SuspendLayout();
			this.pnMaterial.SuspendLayout();
			this.pnNotScrShot.SuspendLayout();
			this.SuspendLayout();
			//
			// pnWiz0x006d
			//
			this.pnWiz0x006d.Controls.Add(this.cbPicker2);
			this.pnWiz0x006d.Controls.Add(this.cbAttrPicker);
			this.pnWiz0x006d.Controls.Add(this.cbDecimal);
			this.pnWiz0x006d.Controls.Add(this.tbVal2);
			this.pnWiz0x006d.Controls.Add(this.cbDataOwner2);
			this.pnWiz0x006d.Controls.Add(this.panel1);
			this.pnWiz0x006d.Controls.Add(this.cbPicker1);
			this.pnWiz0x006d.Controls.Add(this.tbVal1);
			this.pnWiz0x006d.Controls.Add(this.cbDataOwner1);
			this.pnWiz0x006d.Controls.Add(this.pnMaterial);
			this.pnWiz0x006d.Controls.Add(this.label9);
			this.pnWiz0x006d.Controls.Add(this.label1);
			resources.ApplyResources(this.pnWiz0x006d, "pnWiz0x006d");
			this.pnWiz0x006d.Name = "pnWiz0x006d";
			//
			// cbPicker2
			//
			this.cbPicker2.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbPicker2.DropDownWidth = 384;
			resources.ApplyResources(this.cbPicker2, "cbPicker2");
			this.cbPicker2.Name = "cbPicker2";
			//
			// cbAttrPicker
			//
			resources.ApplyResources(this.cbAttrPicker, "cbAttrPicker");
			this.cbAttrPicker.Name = "cbAttrPicker";
			//
			// cbDecimal
			//
			resources.ApplyResources(this.cbDecimal, "cbDecimal");
			this.cbDecimal.Name = "cbDecimal";
			//
			// tbVal2
			//
			resources.ApplyResources(this.tbVal2, "tbVal2");
			this.tbVal2.Name = "tbVal2";
			//
			// cbDataOwner2
			//
			this.cbDataOwner2.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbDataOwner2.DropDownWidth = 384;
			resources.ApplyResources(this.cbDataOwner2, "cbDataOwner2");
			this.cbDataOwner2.Name = "cbDataOwner2";
			//
			// panel1
			//
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Controls.Add(this.pnNotAllOver);
			this.panel1.Controls.Add(this.ckbAllOver);
			this.panel1.Controls.Add(this.rb3Object);
			this.panel1.Controls.Add(this.rb3Me);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Name = "panel1";
			//
			// pnNotAllOver
			//
			resources.ApplyResources(this.pnNotAllOver, "pnNotAllOver");
			this.pnNotAllOver.Controls.Add(this.tbMesh);
			this.pnNotAllOver.Controls.Add(this.btnMesh);
			this.pnNotAllOver.Controls.Add(this.tbVal5);
			this.pnNotAllOver.Controls.Add(this.label8);
			this.pnNotAllOver.Controls.Add(this.ckbMeshTemp);
			this.pnNotAllOver.Controls.Add(this.cbMeshScope);
			this.pnNotAllOver.Controls.Add(this.label4);
			this.pnNotAllOver.Name = "pnNotAllOver";
			//
			// tbMesh
			//
			resources.ApplyResources(this.tbMesh, "tbMesh");
			this.tbMesh.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbMesh.Name = "tbMesh";
			this.tbMesh.ReadOnly = true;
			this.tbMesh.TabStop = false;
			//
			// btnMesh
			//
			resources.ApplyResources(this.btnMesh, "btnMesh");
			this.btnMesh.Name = "btnMesh";
			this.btnMesh.Click += new System.EventHandler(this.btnMesh_Click);
			//
			// tbVal5
			//
			resources.ApplyResources(this.tbVal5, "tbVal5");
			this.tbVal5.Name = "tbVal5";
			//
			// label8
			//
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			//
			// ckbMeshTemp
			//
			resources.ApplyResources(this.ckbMeshTemp, "ckbMeshTemp");
			this.ckbMeshTemp.Name = "ckbMeshTemp";
			this.ckbMeshTemp.UseVisualStyleBackColor = true;
			this.ckbMeshTemp.CheckedChanged += new System.EventHandler(
				this.ckbMeshTemp_CheckedChanged
			);
			//
			// cbMeshScope
			//
			this.cbMeshScope.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbMeshScope.FormattingEnabled = true;
			this.cbMeshScope.Items.AddRange(
				new object[]
				{
					resources.GetString("cbMeshScope.Items"),
					resources.GetString("cbMeshScope.Items1"),
					resources.GetString("cbMeshScope.Items2"),
				}
			);
			resources.ApplyResources(this.cbMeshScope, "cbMeshScope");
			this.cbMeshScope.Name = "cbMeshScope";
			this.cbMeshScope.SelectedIndexChanged += new System.EventHandler(
				this.cbMatMeshScope_SelectedIndexChanged
			);
			//
			// label4
			//
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			//
			// ckbAllOver
			//
			resources.ApplyResources(this.ckbAllOver, "ckbAllOver");
			this.ckbAllOver.Name = "ckbAllOver";
			this.ckbAllOver.UseVisualStyleBackColor = true;
			this.ckbAllOver.CheckedChanged += new System.EventHandler(
				this.ckbAllOver_CheckedChanged
			);
			//
			// rb3Object
			//
			resources.ApplyResources(this.rb3Object, "rb3Object");
			this.rb3Object.Name = "rb3Object";
			this.rb3Object.TabStop = true;
			this.rb3Object.UseVisualStyleBackColor = true;
			this.rb3Object.CheckedChanged += new System.EventHandler(
				this.rb3group_CheckedChanged
			);
			//
			// rb3Me
			//
			resources.ApplyResources(this.rb3Me, "rb3Me");
			this.rb3Me.Name = "rb3Me";
			this.rb3Me.TabStop = true;
			this.rb3Me.UseVisualStyleBackColor = true;
			this.rb3Me.CheckedChanged += new System.EventHandler(
				this.rb3group_CheckedChanged
			);
			//
			// label2
			//
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			//
			// cbPicker1
			//
			this.cbPicker1.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbPicker1.DropDownWidth = 384;
			resources.ApplyResources(this.cbPicker1, "cbPicker1");
			this.cbPicker1.Name = "cbPicker1";
			//
			// tbVal1
			//
			resources.ApplyResources(this.tbVal1, "tbVal1");
			this.tbVal1.Name = "tbVal1";
			//
			// cbDataOwner1
			//
			this.cbDataOwner1.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbDataOwner1.DropDownWidth = 384;
			resources.ApplyResources(this.cbDataOwner1, "cbDataOwner1");
			this.cbDataOwner1.Name = "cbDataOwner1";
			//
			// pnMaterial
			//
			resources.ApplyResources(this.pnMaterial, "pnMaterial");
			this.pnMaterial.Controls.Add(this.pnNotScrShot);
			this.pnMaterial.Controls.Add(this.rb1Object);
			this.pnMaterial.Controls.Add(this.rb1Me);
			this.pnMaterial.Controls.Add(this.rb1ScrShot);
			this.pnMaterial.Controls.Add(this.label3);
			this.pnMaterial.Name = "pnMaterial";
			//
			// pnNotScrShot
			//
			resources.ApplyResources(this.pnNotScrShot, "pnNotScrShot");
			this.pnNotScrShot.Controls.Add(this.tbMaterial);
			this.pnNotScrShot.Controls.Add(this.btnMaterial);
			this.pnNotScrShot.Controls.Add(this.tbVal3);
			this.pnNotScrShot.Controls.Add(this.cbMatScope);
			this.pnNotScrShot.Controls.Add(this.label7);
			this.pnNotScrShot.Controls.Add(this.label6);
			this.pnNotScrShot.Controls.Add(this.label5);
			this.pnNotScrShot.Controls.Add(this.ckbMaterialTemp);
			this.pnNotScrShot.Controls.Add(this.rb2MovingTexture);
			this.pnNotScrShot.Controls.Add(this.rb2Material);
			this.pnNotScrShot.Name = "pnNotScrShot";
			//
			// tbMaterial
			//
			resources.ApplyResources(this.tbMaterial, "tbMaterial");
			this.tbMaterial.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbMaterial.Name = "tbMaterial";
			this.tbMaterial.ReadOnly = true;
			this.tbMaterial.TabStop = false;
			//
			// btnMaterial
			//
			resources.ApplyResources(this.btnMaterial, "btnMaterial");
			this.btnMaterial.Name = "btnMaterial";
			this.btnMaterial.Click += new System.EventHandler(this.btnMaterial_Click);
			//
			// tbVal3
			//
			resources.ApplyResources(this.tbVal3, "tbVal3");
			this.tbVal3.Name = "tbVal3";
			//
			// cbMatScope
			//
			this.cbMatScope.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbMatScope.FormattingEnabled = true;
			this.cbMatScope.Items.AddRange(
				new object[]
				{
					resources.GetString("cbMatScope.Items"),
					resources.GetString("cbMatScope.Items1"),
					resources.GetString("cbMatScope.Items2"),
				}
			);
			resources.ApplyResources(this.cbMatScope, "cbMatScope");
			this.cbMatScope.Name = "cbMatScope";
			this.cbMatScope.SelectedIndexChanged += new System.EventHandler(
				this.cbMatMeshScope_SelectedIndexChanged
			);
			//
			// label7
			//
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			//
			// label6
			//
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			//
			// label5
			//
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			//
			// ckbMaterialTemp
			//
			resources.ApplyResources(this.ckbMaterialTemp, "ckbMaterialTemp");
			this.ckbMaterialTemp.Name = "ckbMaterialTemp";
			this.ckbMaterialTemp.UseVisualStyleBackColor = true;
			this.ckbMaterialTemp.CheckedChanged += new System.EventHandler(
				this.ckbMaterialTemp_CheckedChanged
			);
			//
			// rb2MovingTexture
			//
			resources.ApplyResources(this.rb2MovingTexture, "rb2MovingTexture");
			this.rb2MovingTexture.Name = "rb2MovingTexture";
			this.rb2MovingTexture.TabStop = true;
			this.rb2MovingTexture.UseVisualStyleBackColor = true;
			//
			// rb2Material
			//
			resources.ApplyResources(this.rb2Material, "rb2Material");
			this.rb2Material.Name = "rb2Material";
			this.rb2Material.TabStop = true;
			this.rb2Material.UseVisualStyleBackColor = true;
			//
			// rb1Object
			//
			resources.ApplyResources(this.rb1Object, "rb1Object");
			this.rb1Object.Name = "rb1Object";
			this.rb1Object.TabStop = true;
			this.rb1Object.UseVisualStyleBackColor = true;
			this.rb1Object.CheckedChanged += new System.EventHandler(
				this.rb1group_CheckedChanged
			);
			//
			// rb1Me
			//
			resources.ApplyResources(this.rb1Me, "rb1Me");
			this.rb1Me.Name = "rb1Me";
			this.rb1Me.TabStop = true;
			this.rb1Me.UseVisualStyleBackColor = true;
			this.rb1Me.CheckedChanged += new System.EventHandler(
				this.rb1group_CheckedChanged
			);
			//
			// rb1ScrShot
			//
			resources.ApplyResources(this.rb1ScrShot, "rb1ScrShot");
			this.rb1ScrShot.Name = "rb1ScrShot";
			this.rb1ScrShot.TabStop = true;
			this.rb1ScrShot.UseVisualStyleBackColor = true;
			this.rb1ScrShot.CheckedChanged += new System.EventHandler(
				this.rb1group_CheckedChanged
			);
			//
			// label3
			//
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			//
			// label9
			//
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.pnWiz0x006d);
			this.Name = "UI";
			this.pnWiz0x006d.ResumeLayout(false);
			this.pnWiz0x006d.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnNotAllOver.ResumeLayout(false);
			this.pnNotAllOver.PerformLayout();
			this.pnMaterial.ResumeLayout(false);
			this.pnMaterial.PerformLayout();
			this.pnNotScrShot.ResumeLayout(false);
			this.pnNotScrShot.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private void rb1group_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			this.MaterialFrom();
		}

		private void ckbMaterialTemp_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			this.MaterialFrom();
		}

		private void btnMaterial_Click(object sender, EventArgs e)
		{
			this.doStrChooser(
				this.cbMatScope,
				GS.GlobalStr.MaterialName,
				this.tbVal3,
				this.tbMaterial
			);
		}

		private void rb3group_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			this.MeshFrom();
		}

		private void ckbAllOver_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			this.MeshFrom();
		}

		private void ckbMeshTemp_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			this.MeshFrom();
		}

		private void btnMesh_Click(object sender, EventArgs e)
		{
			this.doStrChooser(
				this.cbMeshScope,
				GS.GlobalStr.MeshGroup,
				this.tbVal5,
				this.tbMesh
			);
		}

		private void cbMatMeshScope_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			if (sender.Equals(this.cbMatScope))
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
	public class BhavOperandWiz0x006d : pjse.ABhavOperandWiz
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
