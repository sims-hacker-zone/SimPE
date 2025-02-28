// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Windows.Forms;

namespace SimPe
{
	/// <summary>
	/// Summary description for PackageSelectorForm.
	/// </summary>
	public class PackageSelectorForm : Form
	{
		private Label label1;
		private Label lbfile;
		private ListBox lbfiles;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PackageSelectorForm()
		{
			//
			// Required designer variable.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(PackageSelectorForm));
			label1 = new Label();
			lbfile = new Label();
			lbfiles = new ListBox();
			SuspendLayout();
			//
			// label1
			//
			label1.Anchor =



							AnchorStyles.Bottom
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			label1.Location = new System.Drawing.Point(8, 286);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(576, 32);
			label1.TabIndex = 0;
			label1.Text =
				"You can use this Helper to Drag && Drop the Files from the current Package to "
				+ "a Reference List. The Item will be added to the List.";
			//
			// lbfile
			//
			lbfile.AutoSize = true;
			lbfile.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbfile.Location = new System.Drawing.Point(16, 16);
			lbfile.Name = "lbfile";
			lbfile.Size = new System.Drawing.Size(67, 17);
			lbfile.TabIndex = 1;
			lbfile.Text = "Filename:";
			//
			// lbfiles
			//
			lbfiles.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lbfiles.Location = new System.Drawing.Point(24, 32);
			lbfiles.Name = "lbfiles";
			lbfiles.Size = new System.Drawing.Size(552, 238);
			lbfiles.TabIndex = 2;
			lbfiles.MouseMove += new MouseEventHandler(
				StartDrop
			);
			//
			// PackageSelectorForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(592, 324);
			Controls.Add(lbfiles);
			Controls.Add(lbfile);
			Controls.Add(label1);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MinimumSize = new System.Drawing.Size(440, 232);
			Name = "PackageSelectorForm";
			Text = "PackageSelectorForm";
			ResumeLayout(false);
		}
		#endregion

		/// <summary>
		/// Displays the Tool with the content of the passed Package
		/// </summary>
		/// <param name="package">The package you want to list</param>
		public void Execute(Interfaces.Files.IPackageFile package)
		{
			lbfiles.Sorted = false;
			lbfiles.Items.Clear();
			lbfile.Text = package.FileName;

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in package.Index)
			{
				lbfiles.Items.Add(pfd);
			}

			lbfiles.Sorted = true;
			Show();
		}

		private void StartDrop(object sender, MouseEventArgs e)
		{
			if (lbfiles.SelectedIndex < 0)
			{
				return;
			}

			if (e.Button == MouseButtons.Left)
			{
				lbfiles.DoDragDrop(
					(Interfaces.Files.IPackedFileDescriptor)
						lbfiles.Items[lbfiles.SelectedIndex],
					DragDropEffects.Copy | DragDropEffects.Link
				);
			}
		}
	}
}
