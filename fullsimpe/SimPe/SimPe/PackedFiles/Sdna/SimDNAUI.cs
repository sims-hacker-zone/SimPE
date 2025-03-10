// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Sdsc;

namespace SimPe.PackedFiles.Sdna
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

			Text = "Sim DNA";
			Commited += new EventHandler(SimDNAUI_Commited);
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
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			pbDom = new PropertyGrid();
			label1 = new Label();
			label2 = new Label();
			pbRec = new PropertyGrid();
			lbbody = new Label();
			lbcpf = new ListBox();
			SuspendLayout();
			//
			// pbDom
			//
			pbDom.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			pbDom.HelpVisible = false;
			pbDom.LineColor = System.Drawing.SystemColors.ScrollBar;
			pbDom.Location = new System.Drawing.Point(16, 50);
			pbDom.Name = "pbDom";
			pbDom.PropertySort = PropertySort.Alphabetical;
			pbDom.Size = new System.Drawing.Size(648, 96);
			pbDom.TabIndex = 0;
			pbDom.ToolbarVisible = false;
			//
			// label1
			//
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(8, 34);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(100, 16);
			label1.TabIndex = 1;
			label1.Text = "Dominant Gene:";
			//
			// label2
			//
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(8, 154);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(100, 16);
			label2.TabIndex = 3;
			label2.Text = "Recessive Gene:";
			//
			// pbRec
			//
			pbRec.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			pbRec.HelpVisible = false;
			pbRec.LineColor = System.Drawing.SystemColors.ScrollBar;
			pbRec.Location = new System.Drawing.Point(16, 170);
			pbRec.Name = "pbRec";
			pbRec.PropertySort = PropertySort.Alphabetical;
			pbRec.Size = new System.Drawing.Size(648, 96);
			pbRec.TabIndex = 2;
			pbRec.ToolbarVisible = false;
			//
			// lbbody
			//
			lbbody.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			lbbody.AutoSize = true;
			lbbody.BackColor = System.Drawing.Color.Transparent;
			lbbody.Font = new System.Drawing.Font(
				"Tahoma",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbbody.Location = new System.Drawing.Point(282, 28);
			lbbody.Name = "lbbody";
			lbbody.Size = new System.Drawing.Size(66, 16);
			lbbody.TabIndex = 4;
			lbbody.Text = "Unknown";
			lbbody.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			lbbody.Visible = false;
			//
			// lbcpf
			//
			lbcpf.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lbcpf.Location = new System.Drawing.Point(8, 40);
			lbcpf.Name = "lbcpf";
			lbcpf.Size = new System.Drawing.Size(260, 225);
			lbcpf.TabIndex = 3;
			lbcpf.Visible = false;
			//
			// SimDNAUI
			//
			Controls.Add(label2);
			Controls.Add(pbRec);
			Controls.Add(lbbody);
			Controls.Add(label1);
			Controls.Add(pbDom);
			Controls.Add(lbcpf);
			Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Name = "SimDNAUI";
			Size = new System.Drawing.Size(672, 272);
			Controls.SetChildIndex(lbcpf, 0);
			Controls.SetChildIndex(pbDom, 0);
			Controls.SetChildIndex(label1, 0);
			Controls.SetChildIndex(lbbody, 0);
			Controls.SetChildIndex(pbRec, 0);
			Controls.SetChildIndex(label2, 0);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		#region IPackedFileUI Member


		public SimDNA Sdna => (SimDNA)Wrapper;

		private Cpf.Cpf wrp => (Cpf.Cpf)Wrapper;

		protected override void RefreshGUI()
		{
			if (Sdna.Dominant.Skintone != "" || Sdna.Dominant.Hair != "")
			{
				label2.Visible = pbRec.Visible = label1.Visible = pbDom.Visible = true;
				lbcpf.Visible = false;
				pbDom.SelectedObject = Sdna.Dominant;
				pbRec.SelectedObject = Sdna.Recessive;

				lbbody.Text =
					"Bodyshape = "
					+ Data.MetaData.GetBodyName(
						Data.MetaData.GetBodyShapeid(Sdna.Dominant.Skintone)
					);
				lbbody.Visible = lbbody.Text != "Bodyshape = Unknown"
					&& lbbody.Text != "Bodyshape =  Maxis : Default";

				if (!(FileTableBase.ProviderRegistry.SimDescriptionProvider.FindSim(
						(ushort)Wrapper.FileDescriptor.Instance
					) is SDesc sdsc))
				{
					CanCommit = true;
					HeaderText = "Sim DNA";
				}
				else
				{
					HeaderText =
						"Sim DNA (" + sdsc.SimName + " " + sdsc.SimFamilyName + ")";
					CanCommit = sdsc.Nightlife.IsHuman;
				}
			}
			else
			{
				CanCommit = false;
				label2.Visible =
					pbRec.Visible =
					lbbody.Visible =
					label1.Visible =
					pbDom.Visible =
						false;
				lbcpf.Visible = true;
				lbcpf.Items.Clear();
				HeaderText = !(FileTableBase.ProviderRegistry.SimDescriptionProvider.FindSim(
						(ushort)Wrapper.FileDescriptor.Instance
					) is SDesc sdsc)
					? "CPF Viewer"
					: "CPF Viewer ("
						+ sdsc.SimName
						+ " "
						+ sdsc.SimFamilyName
						+ " DNA)";

				foreach (CpfItem item in wrp.Items)
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
