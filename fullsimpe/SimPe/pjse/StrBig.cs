// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Windows.Forms;

namespace pjse
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	public class StrBig : Form
	{
		#region Form variables
		private Panel panel1;
		private RichTextBox richTextBox1;
		private Panel panel2;
		private Button OK;
		private Button Cancel;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public StrBig()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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

		#region StrBig
		public string doBig(string init)
		{
			DialogResult = DialogResult.Cancel;
			richTextBox1.Text = init;

			DialogResult dr = ShowDialog();
			Close();

			switch (dr)
			{
				case DialogResult.Ignore:
					return null;
				default:
					return richTextBox1.Text;
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
				new System.ComponentModel.ComponentResourceManager(typeof(StrBig));
			panel1 = new Panel();
			OK = new Button();
			Cancel = new Button();
			panel2 = new Panel();
			richTextBox1 = new RichTextBox();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// panel1
			//
			panel1.BackColor = System.Drawing.Color.Transparent;
			panel1.Controls.Add(OK);
			panel1.Controls.Add(Cancel);
			panel1.Controls.Add(panel2);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			//
			// OK
			//
			resources.ApplyResources(OK, "OK");
			OK.DialogResult = DialogResult.OK;
			OK.Name = "OK";
			//
			// Cancel
			//
			resources.ApplyResources(Cancel, "Cancel");
			Cancel.DialogResult = DialogResult.Ignore;
			Cancel.Name = "Cancel";
			//
			// panel2
			//
			resources.ApplyResources(panel2, "panel2");
			panel2.BorderStyle = BorderStyle.FixedSingle;
			panel2.Name = "panel2";
			//
			// richTextBox1
			//
			richTextBox1.AcceptsTab = true;
			richTextBox1.DetectUrls = false;
			resources.ApplyResources(richTextBox1, "richTextBox1");
			richTextBox1.Name = "richTextBox1";
			//
			// StrBig
			//
			AcceptButton = OK;
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			CancelButton = Cancel;
			Controls.Add(richTextBox1);
			Controls.Add(panel1);
			MinimizeBox = false;
			Name = "StrBig";
			ShowInTaskbar = false;
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion
	}
}
