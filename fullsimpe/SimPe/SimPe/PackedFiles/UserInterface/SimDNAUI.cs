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
using System.Windows.Forms;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for SimDNAUI.
	/// </summary>
	public class SimDNAUI
		:
		//System.Windows.Forms.UserControl
		Windows.Forms.WrapperBaseControl,
			Interfaces.Plugin.IPackedFileUI
	{
		private Label label1;
		private PropertyGrid pbDom;
		private Label label2;
		private PropertyGrid pbRec;
		private Label lbbody;
		private ListBox lbcpf;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SimDNAUI()
		{
			// Required designer variable.
			InitializeComponent();

			this.Text = "Sim DNA";
			this.Commited += new EventHandler(SimDNAUI_Commited);
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
			this.pbDom = new PropertyGrid();
			this.label1 = new Label();
			this.label2 = new Label();
			this.pbRec = new PropertyGrid();
			this.lbbody = new Label();
			this.lbcpf = new ListBox();
			this.SuspendLayout();
			//
			// pbDom
			//
			this.pbDom.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.pbDom.HelpVisible = false;
			this.pbDom.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pbDom.Location = new System.Drawing.Point(16, 50);
			this.pbDom.Name = "pbDom";
			this.pbDom.PropertySort = PropertySort.Alphabetical;
			this.pbDom.Size = new System.Drawing.Size(648, 96);
			this.pbDom.TabIndex = 0;
			this.pbDom.ToolbarVisible = false;
			//
			// label1
			//
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label1.Location = new System.Drawing.Point(8, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Dominant Gene:";
			//
			// label2
			//
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label2.Location = new System.Drawing.Point(8, 154);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Recessive Gene:";
			//
			// pbRec
			//
			this.pbRec.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.pbRec.HelpVisible = false;
			this.pbRec.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pbRec.Location = new System.Drawing.Point(16, 170);
			this.pbRec.Name = "pbRec";
			this.pbRec.PropertySort = PropertySort.Alphabetical;
			this.pbRec.Size = new System.Drawing.Size(648, 96);
			this.pbRec.TabIndex = 2;
			this.pbRec.ToolbarVisible = false;
			//
			// lbbody
			//
			this.lbbody.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			this.lbbody.AutoSize = true;
			this.lbbody.BackColor = System.Drawing.Color.Transparent;
			this.lbbody.Font = new System.Drawing.Font(
				"Tahoma",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.lbbody.Location = new System.Drawing.Point(282, 28);
			this.lbbody.Name = "lbbody";
			this.lbbody.Size = new System.Drawing.Size(66, 16);
			this.lbbody.TabIndex = 4;
			this.lbbody.Text = "Unknown";
			this.lbbody.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lbbody.Visible = false;
			//
			// lbcpf
			//
			this.lbcpf.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.lbcpf.Location = new System.Drawing.Point(8, 40);
			this.lbcpf.Name = "lbcpf";
			this.lbcpf.Size = new System.Drawing.Size(260, 225);
			this.lbcpf.TabIndex = 3;
			this.lbcpf.Visible = false;
			//
			// SimDNAUI
			//
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pbRec);
			this.Controls.Add(this.lbbody);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pbDom);
			this.Controls.Add(this.lbcpf);
			this.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.Name = "SimDNAUI";
			this.Size = new System.Drawing.Size(672, 272);
			this.Controls.SetChildIndex(this.lbcpf, 0);
			this.Controls.SetChildIndex(this.pbDom, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.lbbody, 0);
			this.Controls.SetChildIndex(this.pbRec, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		#region IPackedFileUI Member


		public Wrapper.SimDNA Sdna => (Wrapper.SimDNA)Wrapper;

		private Wrapper.Cpf wrp => (Wrapper.Cpf)Wrapper;

		protected override void RefreshGUI()
		{
			if (Sdna.Dominant.Skintone != "" || Sdna.Dominant.Hair != "")
			{
				label2.Visible = pbRec.Visible = label1.Visible = pbDom.Visible = true;
				lbcpf.Visible = false;
				this.pbDom.SelectedObject = Sdna.Dominant;
				this.pbRec.SelectedObject = Sdna.Recessive;

				this.lbbody.Text =
					"Bodyshape = "
					+ Data.MetaData.GetBodyName(
						Data.MetaData.GetBodyShapeid(Sdna.Dominant.Skintone)
					);
				if (
					this.lbbody.Text == "Bodyshape = Unknown"
					|| this.lbbody.Text == "Bodyshape =  Maxis : Default"
				)
				{
					this.lbbody.Visible = false;
				}
				else
				{
					this.lbbody.Visible = true;
				}

				Wrapper.SDesc sdsc =
					FileTableBase.ProviderRegistry.SimDescriptionProvider.FindSim(
						(ushort)Wrapper.FileDescriptor.Instance
					) as Wrapper.SDesc;
				if (sdsc == null)
				{
					this.CanCommit = true;
					this.HeaderText = "Sim DNA";
				}
				else
				{
					this.HeaderText =
						"Sim DNA (" + sdsc.SimName + " " + sdsc.SimFamilyName + ")";
					this.CanCommit = sdsc.Nightlife.IsHuman;
				}
			}
			else
			{
				this.CanCommit = false;
				label2.Visible =
					pbRec.Visible =
					lbbody.Visible =
					label1.Visible =
					pbDom.Visible =
						false;
				lbcpf.Visible = true;
				lbcpf.Items.Clear();
				Wrapper.SDesc sdsc =
					FileTableBase.ProviderRegistry.SimDescriptionProvider.FindSim(
						(ushort)Wrapper.FileDescriptor.Instance
					) as Wrapper.SDesc;
				if (sdsc == null)
				{
					this.HeaderText = "CPF Viewer";
				}
				else
				{
					this.HeaderText =
						"CPF Viewer ("
						+ sdsc.SimName
						+ " "
						+ sdsc.SimFamilyName
						+ " DNA)";
				}

				foreach (Wrapper.CpfItem item in wrp.Items)
				{
					lbcpf.Items.Add(item);
				}
			}
		}

		#endregion

		private void SimDNAUI_Commited(object sender, EventArgs e)
		{
			Sdna.SynchronizeUserData();
			RefreshGUI();
		}
	}
}
