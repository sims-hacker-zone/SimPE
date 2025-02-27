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
using System.Windows.Forms;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// Summary description for AnimationMeshBlock.
	/// </summary>
	public class AnimMeshBlockControl : UserControl
	{
		private Panel panel2;
		internal ComboBox cbJoint;
		private Label label1;
		private Panel pnJoint;
		private Panel pnSubMesh;
		private Label label2;
		internal ComboBox cbSubMesh;
		private AnimFrameBlockControl pnFrames;
		private LinkLabel llExport;
		private LinkLabel llImport;
		private CheckBox cbCorrect;
		private MenuItem miAdd;
		private MenuItem miRem;
		private ContextMenu cmJoint;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AnimMeshBlockControl()
		{
			SetStyle(
				ControlStyles.SupportsTransparentBackColor
					| ControlStyles.AllPaintingInWmPaint
					|
					//ControlStyles.Opaque |
					ControlStyles.UserPaint
					| ControlStyles.ResizeRedraw
					| ControlStyles.DoubleBuffer,
				true
			);

			// Required designer variable.
			InitializeComponent();

			pnFrames = new AnimFrameBlockControl();
			pnFrames.Dock = DockStyle.Fill;
			pnFrames.FrameBlock = null;
			pnFrames.Location = new System.Drawing.Point(0, 32);
			pnFrames.Name = "pnFrames";
			pnFrames.Size = new System.Drawing.Size(776, 368);
			pnFrames.TabIndex = 3;
			pnFrames.Changed += new System.EventHandler(pnFrames_Changed);
			Controls.Add(pnFrames);
			pnFrames.BringToFront();

			Clear();

			cbCorrect.Checked = Helper
				.WindowsRegistry
				.CorrectJointDefinitionOnExport;
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
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			panel2 = new Panel();
			cbCorrect = new CheckBox();
			llExport = new LinkLabel();
			llImport = new LinkLabel();
			pnJoint = new Panel();
			cbJoint = new ComboBox();
			label1 = new Label();
			pnSubMesh = new Panel();
			cbSubMesh = new ComboBox();
			label2 = new Label();
			cmJoint = new ContextMenu();
			miAdd = new MenuItem();
			miRem = new MenuItem();
			panel2.SuspendLayout();
			pnJoint.SuspendLayout();
			pnSubMesh.SuspendLayout();
			SuspendLayout();
			//
			// panel2
			//
			panel2.Controls.Add(cbCorrect);
			panel2.Controls.Add(llExport);
			panel2.Controls.Add(llImport);
			panel2.Controls.Add(pnJoint);
			panel2.Controls.Add(pnSubMesh);
			panel2.Dock = DockStyle.Top;
			panel2.Location = new System.Drawing.Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(776, 32);
			panel2.TabIndex = 4;
			//
			// cbCorrect
			//
			cbCorrect.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			cbCorrect.Location = new System.Drawing.Point(584, 0);
			cbCorrect.Name = "cbCorrect";
			cbCorrect.Size = new System.Drawing.Size(88, 32);
			cbCorrect.TabIndex = 44;
			cbCorrect.Text = "correct Joint Definition";
			cbCorrect.CheckedChanged += new System.EventHandler(
				cbCorrect_CheckedChanged
			);
			//
			// llExport
			//
			llExport.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			llExport.Enabled = false;
			llExport.Location = new System.Drawing.Point(672, 8);
			llExport.Name = "llExport";
			llExport.Size = new System.Drawing.Size(48, 16);
			llExport.TabIndex = 42;
			llExport.TabStop = true;
			llExport.Text = "Export";
			llExport.TextAlign = System.Drawing.ContentAlignment.TopRight;
			llExport.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llExport_LinkClicked
				);
			//
			// llImport
			//
			llImport.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			llImport.Enabled = false;
			llImport.Location = new System.Drawing.Point(728, 8);
			llImport.Name = "llImport";
			llImport.Size = new System.Drawing.Size(40, 16);
			llImport.TabIndex = 43;
			llImport.TabStop = true;
			llImport.Text = "Import";
			llImport.TextAlign = System.Drawing.ContentAlignment.TopRight;
			llImport.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llImport_LinkClicked
				);
			//
			// pnJoint
			//
			pnJoint.Controls.Add(cbJoint);
			pnJoint.Controls.Add(label1);
			pnJoint.Dock = DockStyle.Left;
			pnJoint.Location = new System.Drawing.Point(256, 0);
			pnJoint.Name = "pnJoint";
			pnJoint.Size = new System.Drawing.Size(248, 32);
			pnJoint.TabIndex = 7;
			//
			// cbJoint
			//
			cbJoint.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			cbJoint.ContextMenu = cmJoint;
			cbJoint.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbJoint.Location = new System.Drawing.Point(34, 0);
			cbJoint.Name = "cbJoint";
			cbJoint.Size = new System.Drawing.Size(214, 21);
			cbJoint.Sorted = true;
			cbJoint.TabIndex = 3;
			cbJoint.SelectedIndexChanged += new System.EventHandler(
				cbSubMesh_SelectedIndexChanged
			);
			//
			// label1
			//
			label1.Location = new System.Drawing.Point(0, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(40, 23);
			label1.TabIndex = 4;
			label1.Text = "Joint:";
			label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// pnSubMesh
			//
			pnSubMesh.Controls.Add(cbSubMesh);
			pnSubMesh.Controls.Add(label2);
			pnSubMesh.Dock = DockStyle.Left;
			pnSubMesh.Location = new System.Drawing.Point(0, 0);
			pnSubMesh.Name = "pnSubMesh";
			pnSubMesh.Size = new System.Drawing.Size(256, 32);
			pnSubMesh.TabIndex = 8;
			//
			// cbSubMesh
			//
			cbSubMesh.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			cbSubMesh.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbSubMesh.Location = new System.Drawing.Point(56, 0);
			cbSubMesh.Name = "cbSubMesh";
			cbSubMesh.Size = new System.Drawing.Size(190, 21);
			cbSubMesh.TabIndex = 5;
			cbSubMesh.SelectedIndexChanged += new System.EventHandler(
				cbSubMesh_SelectedIndexChanged_1
			);
			//
			// label2
			//
			label2.Location = new System.Drawing.Point(0, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 23);
			label2.TabIndex = 6;
			label2.Text = "SubMesh:";
			label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// cmJoint
			//
			cmJoint.MenuItems.AddRange(
				new MenuItem[] { miAdd, miRem }
			);
			//
			// miAdd
			//
			miAdd.Enabled = false;
			miAdd.Index = 0;
			miAdd.Text = "&Create Joint";
			miAdd.Click += new System.EventHandler(miAdd_Click);
			//
			// miRem
			//
			miRem.Enabled = false;
			miRem.Index = 1;
			miRem.Text = "&Remove Joint";
			miRem.Click += new System.EventHandler(miRem_Click);
			//
			// AnimMeshBlockControl
			//
			Controls.Add(panel2);
			Name = "AnimMeshBlockControl";
			Size = new System.Drawing.Size(776, 400);
			panel2.ResumeLayout(false);
			pnJoint.ResumeLayout(false);
			pnSubMesh.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		#region public Properties
		AnimationMeshBlock[] ambs;
		public AnimationMeshBlock[] MeshBlocks
		{
			get
			{
				return ambs;
			}
			set
			{
				ambs = value;
				RefreshData();
				pnSubMesh.Visible = (ambs != null);
			}
		}

		AnimationMeshBlock amb;
		public AnimationMeshBlock MeshBlock
		{
			get
			{
				return amb;
			}
			set
			{
				amb = value;
				RefreshData(amb);
				pnSubMesh.Visible = false;
			}
		}
		#endregion
		internal void ClearJoint()
		{
			cbJoint.Items.Clear();
			pnFrames.Clear();
		}

		internal void Clear()
		{
			ClearJoint();

			cbSubMesh.Items.Clear();
			llImport.Enabled = false;
			llExport.Enabled = llImport.Enabled;
		}

		public void RefreshData()
		{
			Clear();
			if (ambs != null)
			{
				foreach (AnimationMeshBlock amb in ambs)
				{
					cbSubMesh.Items.Add(amb);
				}

				if (cbSubMesh.Items.Count > 0)
				{
					cbSubMesh.SelectedIndex = 0;
				}
			}
		}

		protected void RefreshData(AnimationMeshBlock amb)
		{
			ClearJoint();
			if (amb != null)
			{
				foreach (AnimationFrameBlock afb in amb.Part2)
				{
					cbJoint.Items.Add(afb);
				}

				if (cbJoint.Items.Count > 0)
				{
					cbJoint.SelectedIndex = 0;
				}
			}
		}

		private void cbSubMesh_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			pnFrames.FrameBlock = (AnimationFrameBlock)cbJoint.SelectedItem;
		}

		private void cbSubMesh_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			RefreshData((AnimationMeshBlock)cbSubMesh.SelectedItem);
			llImport.Enabled = cbSubMesh.SelectedItem != null;
			llExport.Enabled = llImport.Enabled;

			miAdd.Enabled = (cbJoint.Items.Count > 0);
			miRem.Enabled = (cbJoint.Items.Count > 0);
		}

		#region Events
		public event System.EventHandler Changed;
		#endregion

		private void pnFrames_Changed(object sender, System.EventArgs e)
		{
			if (Changed != null)
			{
				Changed(this, e);
			}
		}

		private void llExport_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			AnimationMeshBlock ab1 = (AnimationMeshBlock)cbSubMesh.SelectedItem;
			GenericRcol gmdc = ab1.FindUsedGMDC(ab1.FindDefiningCRES());
			if (gmdc != null)
			{
				GeometryDataContainer gdc = (GeometryDataContainer)gmdc.Blocks[0];
				gdc.LinkedAnimation = ab1;

				fGeometryDataContainer.StartExport(
					new SaveFileDialog(),
					gdc,
					".txt",
					gdc.Groups,
					(Gmdc.ElementSorting)
						fGeometryDataContainer.DefaultSelectedAxisIndex,
					cbCorrect.Checked
				);
			}
			else
			{
				Helper.ExceptionMessage(
					new Warning(
						"Unable to Find Model File for \"" + ab1.Name + "\".",
						"SimPe was not able to Find the Model File that defines the specified Hirarchy. The Animation will not get exported!"
					)
				);
			}
		}

		private void llImport_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			AnimationMeshBlock ab1 = (AnimationMeshBlock)cbSubMesh.SelectedItem;
			GenericRcol gmdc = ab1.FindUsedGMDC(ab1.FindDefiningCRES());
			if (gmdc != null)
			{
				GeometryDataContainer gdc = (GeometryDataContainer)gmdc.Blocks[0];
				gdc.LinkedAnimation = ab1;

				fGeometryDataContainer.StartImport(
					new OpenFileDialog(),
					gdc,
					".txt",
					(Gmdc.ElementSorting)
						fGeometryDataContainer.DefaultSelectedAxisIndex,
					true
				);
				ab1.Parent.Changed = true;
				RefreshData();
			}
			else
			{
				Helper.ExceptionMessage(
					new Warning(
						"Unable to Find Model File for \"" + ab1.Name + "\".",
						"SimPe was not able to Find the Model File that defines the specified Hirarchy. The Animation will not get imported!"
					)
				);
			}
		}

		private void miAdd_Click(object sender, System.EventArgs e)
		{
			AnimationMeshBlock ab1 = (AnimationMeshBlock)cbSubMesh.SelectedItem;
			if (ab1 != null)
			{
				AnimationFrameBlock afb = new AnimationFrameBlock(ab1);
				afb.Name = "SimPE Dummy";
				afb.TransformationType = FrameType.Rotation;
				afb.CreateBaseAxisSet();

				ab1.Part2 = (AnimationFrameBlock[])Helper.Add(ab1.Part2, afb);

				cbJoint.SelectedIndex = -1;
				cbJoint.Items.Add(afb);
				cbJoint.SelectedIndex = cbJoint.Items.Count - 1;
			}
		}

		private void miRem_Click(object sender, System.EventArgs e)
		{
			AnimationMeshBlock ab1 = (AnimationMeshBlock)cbSubMesh.SelectedItem;
			AnimationFrameBlock afb = (AnimationFrameBlock)cbJoint.SelectedItem;
			if (ab1 != null && afb != null)
			{
				ab1.Part2 = (AnimationFrameBlock[])Helper.Delete(ab1.Part2, afb);
				int sel = cbJoint.SelectedIndex + 1;
				if (sel >= cbJoint.Items.Count)
				{
					sel = cbJoint.Items.Count - 1;
				}

				cbJoint.Items.Remove(afb);
				cbJoint.SelectedIndex = sel;
			}
		}

		private void cbCorrect_CheckedChanged(object sender, System.EventArgs e)
		{
			Helper.WindowsRegistry.CorrectJointDefinitionOnExport =
				cbCorrect.Checked;
		}
	}
}
