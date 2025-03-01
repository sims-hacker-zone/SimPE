// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.Forms.PackedFileEditors
{
	/// <summary>
	/// Summary description for BconForm.
	/// </summary>
	public class ClstForm : System.Windows.Forms.Form, IPackedFileUI
	{
		#region Form elements
		private System.Windows.Forms.Label lbformat;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ListBox lbclst;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Panel clstPanel;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public ClstForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			if (Helper.WindowsRegistry.UseBigIcons)
			{
				lbclst.Font = new System.Drawing.Font("Verdana", 11F);
			}
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

		#region CompressedFileList
		private CompressedFileList wrapper;
		#endregion

		#region IPackedFileUI Member
		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle => clstPanel;

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <remarks>attr.Tag is used to let TextChanged event handlers know the change is being
		/// made internally rather than by the users.</remarks>
		/// <param name="wrp">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrp)
		{
			wrapper = (CompressedFileList)wrp;

			lbformat.Text = wrapper.IndexType.ToString();

			lbclst.Items.Clear();
			foreach (ClstItem i in wrapper.Items)
			{
				if (i != null)
				{
					lbclst.Items.Add(i);
				}
				else
				{
					lbclst.Items.Add("Error");
				}
			}
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
				new System.ComponentModel.ComponentResourceManager(typeof(ClstForm));
			clstPanel = new System.Windows.Forms.Panel();
			lbformat = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			lbclst = new System.Windows.Forms.ListBox();
			panel4 = new System.Windows.Forms.Panel();
			clstPanel.SuspendLayout();
			SuspendLayout();
			//
			// clstPanel
			//
			clstPanel.BackColor = System.Drawing.Color.Transparent;
			clstPanel.Controls.Add(lbformat);
			clstPanel.Controls.Add(label9);
			clstPanel.Controls.Add(lbclst);
			clstPanel.Controls.Add(panel4);
			resources.ApplyResources(clstPanel, "clstPanel");
			clstPanel.Name = "clstPanel";
			//
			// lbformat
			//
			resources.ApplyResources(lbformat, "lbformat");
			lbformat.BackColor = System.Drawing.Color.Transparent;
			lbformat.Name = "lbformat";
			//
			// label9
			//
			resources.ApplyResources(label9, "label9");
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.Name = "label9";
			//
			// lbclst
			//
			resources.ApplyResources(lbclst, "lbclst");
			lbclst.Name = "lbclst";
			lbclst.Sorted = true;
			//
			// panel4
			//
			resources.ApplyResources(panel4, "panel4");
			panel4.Name = "panel4";
			//
			// ClstForm
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(clstPanel);
			Name = "ClstForm";
			clstPanel.ResumeLayout(false);
			clstPanel.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
	}
}
