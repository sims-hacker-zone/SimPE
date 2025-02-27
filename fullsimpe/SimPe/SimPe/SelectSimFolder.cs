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

namespace SimPe
{
	/// <summary>
	/// Summary description for SelectSimFolder.
	/// </summary>
	class SelectSimFolder : Form
	{
		class FolderWrapper
		{
			string name;

			public FolderWrapper(string name, string folder)
			{
				this.name = Localization.GetString(name);
				Folder = folder;
			}

			public string Folder
			{
				get;
			}

			public override string ToString()
			{
				return Folder;
				//return name+": "+folder;
			}
		}

		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel1;
		private Label label1;
		private Button button1;
		private FolderBrowserDialog fbd;
		private ComboBox tbFolder;
		private Button btCancel;
		private Button btOK;
		private SteepValley.Windows.Forms.XPLine xpLine1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SelectSimFolder()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			foreach (ExpansionItem ei in PathProvider.Global.Expansions)
			{
				tbFolder.Items.Add(
					new FolderWrapper(ei.Name, ei.RealInstallFolder)
				);
			}
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
			xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			btOK = new Button();
			btCancel = new Button();
			xpLine1 = new SteepValley.Windows.Forms.XPLine();
			tbFolder = new ComboBox();
			button1 = new Button();
			label1 = new Label();
			fbd = new FolderBrowserDialog();
			xpGradientPanel1.SuspendLayout();
			SuspendLayout();
			//
			// xpGradientPanel1
			//
			xpGradientPanel1.Controls.Add(btOK);
			xpGradientPanel1.Controls.Add(btCancel);
			xpGradientPanel1.Controls.Add(xpLine1);
			xpGradientPanel1.Controls.Add(tbFolder);
			xpGradientPanel1.Controls.Add(button1);
			xpGradientPanel1.Controls.Add(label1);
			xpGradientPanel1.Dock = DockStyle.Fill;
			xpGradientPanel1.Location = new System.Drawing.Point(0, 0);
			xpGradientPanel1.Name = "xpGradientPanel1";
			xpGradientPanel1.Size = new System.Drawing.Size(674, 80);
			xpGradientPanel1.TabIndex = 0;
			//
			// btOK
			//
			btOK.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			btOK.FlatStyle = FlatStyle.System;
			btOK.Location = new System.Drawing.Point(512, 52);
			btOK.Name = "btOK";
			btOK.Size = new System.Drawing.Size(75, 23);
			btOK.TabIndex = 6;
			btOK.Text = "OK";
			btOK.Click += new System.EventHandler(btOK_Click);
			//
			// btCancel
			//
			btCancel.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			btCancel.DialogResult = DialogResult.Cancel;
			btCancel.FlatStyle = FlatStyle.System;
			btCancel.Location = new System.Drawing.Point(592, 52);
			btCancel.Name = "btCancel";
			btCancel.Size = new System.Drawing.Size(75, 23);
			btCancel.TabIndex = 5;
			btCancel.Text = "Cancel";
			btCancel.Click += new System.EventHandler(btCancel_Click);
			//
			// xpLine1
			//
			xpLine1.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			xpLine1.BackColor = System.Drawing.Color.Transparent;
			xpLine1.ForeColor = System.Drawing.SystemColors.Desktop;
			xpLine1.LineColor = System.Drawing.SystemColors.Desktop;
			xpLine1.Location = new System.Drawing.Point(0, 32);
			xpLine1.Name = "xpLine1";
			xpLine1.ShadowColor = System.Drawing.Color.Transparent;
			xpLine1.Size = new System.Drawing.Size(672, 16);
			xpLine1.TabIndex = 4;
			//
			// tbFolder
			//
			tbFolder.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			tbFolder.Location = new System.Drawing.Point(64, 8);
			tbFolder.Name = "tbFolder";
			tbFolder.Size = new System.Drawing.Size(520, 21);
			tbFolder.TabIndex = 3;
			//
			// button1
			//
			button1.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			button1.FlatStyle = FlatStyle.System;
			button1.Location = new System.Drawing.Point(592, 8);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 2;
			button1.Text = "Browse...";
			button1.Click += new System.EventHandler(button1_Click);
			//
			// label1
			//
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label1.Location = new System.Drawing.Point(8, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(48, 23);
			label1.TabIndex = 0;
			label1.Text = "Folder:";
			label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// SelectSimFolder
			//
			AcceptButton = btOK;
			AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			CancelButton = btCancel;
			ClientSize = new System.Drawing.Size(674, 80);
			Controls.Add(xpGradientPanel1);
			Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "SelectSimFolder";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Select Sim Folder";
			xpGradientPanel1.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		public static string ShowDialog(string path)
		{
			SelectSimFolder f = new SelectSimFolder();
			f.tbFolder.Text = path;

			if (f.ShowDialog() == DialogResult.OK)
			{
				return f.tbFolder.Text;
			}

			return path;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (System.IO.Directory.Exists(tbFolder.Text))
			{
				fbd.SelectedPath = tbFolder.Text;
			}

			if (fbd.ShowDialog() == DialogResult.OK)
			{
				tbFolder.Text = fbd.SelectedPath;
			}
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}

	/// <summary>
	/// a type editor for db connections
	/// </summary>
	public class SelectSimFolderUITypeEditor : System.Drawing.Design.UITypeEditor
	{
		/// <summary>
		/// constructor
		/// </summary>
		public SelectSimFolderUITypeEditor()
		{
		}

		/// <summary>
		/// display a modal form
		/// </summary>
		/// <param name="context">
		/// see documentation on ITypeDescriptorContext
		/// </param>
		/// <returns>
		/// the style of the editor
		/// </returns>
		public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(
			System.ComponentModel.ITypeDescriptorContext context
		)
		{
			return System.Drawing.Design.UITypeEditorEditStyle.Modal;
		}

		/// <summary>
		/// used to show the connection
		/// </summary>
		/// <param name="context">
		/// see documentation on ITypeDescriptorContext
		/// </param>
		/// <param name="provider">
		/// see documentation on IServiceProvider
		/// </param>
		/// <param name="value">
		/// the value prior to editing
		/// </param>
		/// <returns>
		/// the new connection string after editing
		/// </returns>
		public override object EditValue(
			System.ComponentModel.ITypeDescriptorContext context,
			System.IServiceProvider provider,
			object value
		)
		{
			return EditValue(value as string);
		}

		/// <summary>
		/// show the form for the new connection
		/// string based on an an existing one
		/// </summary>
		/// <param name="value">
		/// the value prior to editing
		/// </param>
		/// <returns>
		/// the new connection string after editing
		/// </returns>
		public string EditValue(string value)
		{
			return SelectSimFolder.ShowDialog(value);
		}
	}
}
