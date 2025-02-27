using System;
using System.Windows.Forms;

namespace SimPe.Plugin.Tool.Window
{
	/// <summary>
	/// Summary description for PackageRepairForm.
	/// </summary>
	class PackageRepairForm : Form
	{
		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel1;
		private Label label1;
		private TextBox tbPkg;
		private Button btBrowse;
		private Ambertation.Windows.Forms.XPTaskBoxSimple tbs;
		private LinkLabel llRepair;
		internal PropertyGrid pg;
		private LinkLabel llOpen;
		private System.ComponentModel.ComponentResourceManager resources1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PackageRepairForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			Setup(null);
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
			resources1 = new System.ComponentModel.ComponentResourceManager(
				typeof(PreviewForm)
			);
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(PackageRepairForm)
				);
			xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			tbs = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			llOpen = new LinkLabel();
			pg = new PropertyGrid();
			llRepair = new LinkLabel();
			btBrowse = new Button();
			tbPkg = new TextBox();
			label1 = new Label();
			xpGradientPanel1.SuspendLayout();
			tbs.SuspendLayout();
			SuspendLayout();
			//
			// xpGradientPanel1
			//
			xpGradientPanel1.BackColor = System.Drawing.Color.Transparent;
			xpGradientPanel1.Controls.Add(tbs);
			xpGradientPanel1.Controls.Add(btBrowse);
			xpGradientPanel1.Controls.Add(tbPkg);
			xpGradientPanel1.Controls.Add(label1);
			xpGradientPanel1.Dock = DockStyle.Fill;
			xpGradientPanel1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			xpGradientPanel1.Location = new System.Drawing.Point(0, 0);
			xpGradientPanel1.Name = "xpGradientPanel1";
			xpGradientPanel1.Size = new System.Drawing.Size(594, 361);
			xpGradientPanel1.TabIndex = 0;
			//
			// tbs
			//
			tbs.Anchor = (
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
			tbs.BackColor = System.Drawing.Color.Transparent;
			tbs.BodyColor = System.Drawing.SystemColors.ControlLight;
			tbs.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			tbs.Controls.Add(llOpen);
			tbs.Controls.Add(pg);
			tbs.Controls.Add(llRepair);
			tbs.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			tbs.HeaderText = "";
			tbs.HeaderTextColor = System.Drawing.SystemColors.ControlText;
			tbs.Icon = ((System.Drawing.Image)(resources.GetObject("tbs.Icon")));
			tbs.IconLocation = new System.Drawing.Point(4, 12);
			tbs.IconSize = new System.Drawing.Size(32, 32);
			tbs.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
			tbs.Location = new System.Drawing.Point(8, 40);
			tbs.Name = "tbs";
			tbs.Padding = new Padding(4, 36, 4, 4);
			tbs.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
			tbs.Size = new System.Drawing.Size(576, 313);
			tbs.TabIndex = 3;
			//
			// llOpen
			//
			llOpen.Font = new System.Drawing.Font(
				"Tahoma",
				12F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			llOpen.LinkColor = System.Drawing.SystemColors.ControlText;
			llOpen.Location = new System.Drawing.Point(500, 6);
			llOpen.Name = "llOpen";
			llOpen.Size = new System.Drawing.Size(61, 23);
			llOpen.TabIndex = 2;
			llOpen.TabStop = true;
			llOpen.Text = "Open";
			llOpen.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			llOpen.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llOpen_LinkClicked
				);
			//
			// pg
			//
			pg.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)
				)
			);
			pg.BackColor = System.Drawing.SystemColors.Control;
			pg.CommandsBackColor = System.Drawing.SystemColors.InactiveCaption;
			pg.HelpVisible = false;
			pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			pg.Location = new System.Drawing.Point(8, 48);
			pg.Name = "pg";
			pg.PropertySort = PropertySort.Alphabetical;
			pg.Size = new System.Drawing.Size(558, 256);
			pg.TabIndex = 1;
			pg.ToolbarVisible = false;
			pg.ViewBackColor = System.Drawing.SystemColors.Control;
			//
			// llRepair
			//
			llRepair.Font = new System.Drawing.Font(
				"Tahoma",
				12F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			llRepair.LinkColor = System.Drawing.SystemColors.ControlText;
			llRepair.Location = new System.Drawing.Point(420, 6);
			llRepair.Name = "llRepair";
			llRepair.Size = new System.Drawing.Size(72, 23);
			llRepair.TabIndex = 0;
			llRepair.TabStop = true;
			llRepair.Text = "Repair";
			llRepair.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			llRepair.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llRepair_LinkClicked
				);
			//
			// btBrowse
			//
			btBrowse.FlatStyle = FlatStyle.System;
			btBrowse.Location = new System.Drawing.Point(509, 16);
			btBrowse.Name = "btBrowse";
			btBrowse.Size = new System.Drawing.Size(75, 23);
			btBrowse.TabIndex = 2;
			btBrowse.Text = "Browse...";
			btBrowse.Click += new EventHandler(btBrowse_Click);
			//
			// tbPkg
			//
			tbPkg.Location = new System.Drawing.Point(80, 16);
			tbPkg.Name = "tbPkg";
			tbPkg.ReadOnly = true;
			tbPkg.Size = new System.Drawing.Size(420, 21);
			tbPkg.TabIndex = 1;
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
			label1.Location = new System.Drawing.Point(16, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(64, 24);
			label1.TabIndex = 0;
			label1.Text = "Package:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// PackageRepairForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			ClientSize = new System.Drawing.Size(594, 361);
			Controls.Add(xpGradientPanel1);
			Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Icon = ((System.Drawing.Icon)(resources1.GetObject("$this.Icon")));
			MaximizeBox = false;
			Name = "PackageRepairForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Package Repair";
			xpGradientPanel1.ResumeLayout(false);
			xpGradientPanel1.PerformLayout();
			tbs.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		Packages.StreamItem si;
		Packages.PackageRepair pr;

		public void Setup(string pkgname)
		{
			if (pkgname == null)
			{
				pkgname = "";
			}

			tbPkg.Text = pkgname;
			tbs.HeaderText = System.IO.Path.GetFileNameWithoutExtension(pkgname);

			si = null;
			pr = null;
			pg.SelectedObject = null;
			llOpen.Enabled = false;
			try
			{
				if (System.IO.File.Exists(pkgname))
				{
					si = Packages.StreamFactory.UseStream(
						pkgname,
						System.IO.FileAccess.ReadWrite,
						false
					);
				}

				if (!si.FileStream.CanWrite || !si.FileStream.CanRead)
				{
					si = null;
				}

				if (si != null)
				{
					pr = new Packages.PackageRepair(
						Packages.File.LoadFromFile(pkgname)
					);

					pg.SelectedObject = pr.IndexDetailsAdvanced;
					llOpen.Enabled = (pr.Package != null);
				}
			}
			catch { }

			llRepair.Enabled = (si != null);
		}

		private void btBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					ExtensionType.Package,
					ExtensionType.AllFiles,
				}
			);
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				Setup(ofd.FileName);
			}
		}

		private void llRepair_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			try
			{
				pr.UseIndexData(pr.FindIndexOffset());
				Message.Show(Localization.GetString("FinishedPackageRepair"));

				pg.SelectedObject = pr.IndexDetailsAdvanced;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		private void llOpen_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			try
			{
				RemoteControl.OpenMemoryPackageFkt(pr.Package);
				Close();
			}
			catch (Exception x)
			{
				Helper.ExceptionMessage(x);
			}
		}
	}
}
