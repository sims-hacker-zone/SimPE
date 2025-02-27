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
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Windows.Forms;

namespace pj
{
	public class GetMeshName : Form
	{
		private Label label1;
		private TextBox tbMeshName;
		private Label label2;
		private Button btnOK;
		private Button btnBrowse;
		private Button btnCancel;
		private Label label3;
		private CheckBox cbusecres;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(GetMeshName));
			label1 = new Label();
			tbMeshName = new TextBox();
			label2 = new Label();
			btnOK = new Button();
			btnBrowse = new Button();
			btnCancel = new Button();
			label3 = new Label();
			cbusecres = new CheckBox();
			SuspendLayout();
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// tbMeshName
			//
			resources.ApplyResources(tbMeshName, "tbMeshName");
			tbMeshName.Name = "tbMeshName";
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// btnOK
			//
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.DialogResult = DialogResult.OK;
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			//
			// btnBrowse
			//
			resources.ApplyResources(btnBrowse, "btnBrowse");
			btnBrowse.DialogResult = DialogResult.Retry;
			btnBrowse.Name = "btnBrowse";
			btnBrowse.UseVisualStyleBackColor = true;
			//
			// btnCancel
			//
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// GetMeshName
			//
			AcceptButton = btnOK;
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ControlBox = false;
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(btnOK);
			Controls.Add(btnBrowse);
			Controls.Add(btnCancel);
			Controls.Add(tbMeshName);
			Controls.Add(label1);
			Controls.Add(cbusecres);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Name = "GetMeshName";
			ShowInTaskbar = false;
			ResumeLayout(false);
		}

		#endregion

		public GetMeshName()
		{
			InitializeComponent();

			cbusecres.Checked = Settings.BodyMeshExtractUseCres;
		}

		public string MeshName => tbMeshName.Text;

		private void cbusecres_CheckedChanged(object sender, EventArgs e)
		{
			Settings.BodyMeshExtractUseCres = cbusecres.Checked;
		}
	}
}
