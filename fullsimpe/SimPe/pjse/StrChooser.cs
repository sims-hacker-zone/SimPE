// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse
{
	/// <summary>
	/// Summary description for StrBig.
	/// </summary>
	public class StrChooser : Form
	{
		#region Form variables
		private Panel panel1;
		private Panel panel2;
		private Button OK;
		private Button Cancel;
		private ListBox lbItemList;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public StrChooser()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		public StrChooser(bool sortflag)
			: this()
		{
			this.sortflag = sortflag;
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

		#region StrChooser
		private bool sortflag = false;

		public int Strnum(StrWrapper wrapper)
		{
			fill(wrapper);

			DialogResult dr = ShowDialog();
			Close();

			switch (dr)
			{
				case DialogResult.OK:
					if (lbItemList.SelectedIndex >= 0)
					{
						return (int)((SimPe.Data.Alias)lbItemList.SelectedItem).Id;
					}

					return -1;
				default:
					return -1;
			}
		}

		private void fill(StrWrapper wrapper)
		{
			lbItemList.Items.Clear();

			for (int i = 0; wrapper[1, i] != null; i++)
			{
				lbItemList.Items.Add(
					new SimPe.Data.Alias((uint)i, wrapper[1, i].Title)
				);
			}

			lbItemList.Sorted = sortflag;
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
				new System.ComponentModel.ComponentResourceManager(typeof(StrChooser));
			panel1 = new Panel();
			OK = new Button();
			Cancel = new Button();
			panel2 = new Panel();
			lbItemList = new ListBox();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// panel1
			//
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
			Cancel.DialogResult = DialogResult.Cancel;
			Cancel.Name = "Cancel";
			//
			// panel2
			//
			panel2.BorderStyle = BorderStyle.FixedSingle;
			resources.ApplyResources(panel2, "panel2");
			panel2.Name = "panel2";
			//
			// lbItemList
			//
			resources.ApplyResources(lbItemList, "lbItemList");
			lbItemList.Name = "lbItemList";
			lbItemList.DoubleClick += new System.EventHandler(
				lbItemList_DoubleClick
			);
			//
			// StrChooser
			//
			AcceptButton = OK;
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			CancelButton = Cancel;
			Controls.Add(lbItemList);
			Controls.Add(panel1);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "StrChooser";
			ShowInTaskbar = false;
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		private void lbItemList_DoubleClick(object sender, System.EventArgs e)
		{
			if (lbItemList.SelectedIndex >= 0)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
