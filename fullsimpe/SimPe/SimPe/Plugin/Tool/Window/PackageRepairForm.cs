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
			this.resources1 = new System.ComponentModel.ComponentResourceManager(
				typeof(PreviewForm)
			);
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(PackageRepairForm)
				);
			this.xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			this.tbs = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.llOpen = new LinkLabel();
			this.pg = new PropertyGrid();
			this.llRepair = new LinkLabel();
			this.btBrowse = new Button();
			this.tbPkg = new TextBox();
			this.label1 = new Label();
			this.xpGradientPanel1.SuspendLayout();
			this.tbs.SuspendLayout();
			this.SuspendLayout();
			//
			// xpGradientPanel1
			//
			this.xpGradientPanel1.BackColor = System.Drawing.Color.Transparent;
			this.xpGradientPanel1.Controls.Add(this.tbs);
			this.xpGradientPanel1.Controls.Add(this.btBrowse);
			this.xpGradientPanel1.Controls.Add(this.tbPkg);
			this.xpGradientPanel1.Controls.Add(this.label1);
			this.xpGradientPanel1.Dock = DockStyle.Fill;
			this.xpGradientPanel1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.xpGradientPanel1.Location = new System.Drawing.Point(0, 0);
			this.xpGradientPanel1.Name = "xpGradientPanel1";
			this.xpGradientPanel1.Size = new System.Drawing.Size(594, 361);
			this.xpGradientPanel1.TabIndex = 0;
			//
			// tbs
			//
			this.tbs.Anchor = (
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
			this.tbs.BackColor = System.Drawing.Color.Transparent;
			this.tbs.BodyColor = System.Drawing.SystemColors.ControlLight;
			this.tbs.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			this.tbs.Controls.Add(this.llOpen);
			this.tbs.Controls.Add(this.pg);
			this.tbs.Controls.Add(this.llRepair);
			this.tbs.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			this.tbs.HeaderText = "";
			this.tbs.HeaderTextColor = System.Drawing.SystemColors.ControlText;
			this.tbs.Icon = ((System.Drawing.Image)(resources.GetObject("tbs.Icon")));
			this.tbs.IconLocation = new System.Drawing.Point(4, 12);
			this.tbs.IconSize = new System.Drawing.Size(32, 32);
			this.tbs.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
			this.tbs.Location = new System.Drawing.Point(8, 40);
			this.tbs.Name = "tbs";
			this.tbs.Padding = new Padding(4, 36, 4, 4);
			this.tbs.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
			this.tbs.Size = new System.Drawing.Size(576, 313);
			this.tbs.TabIndex = 3;
			//
			// llOpen
			//
			this.llOpen.Font = new System.Drawing.Font(
				"Tahoma",
				12F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.llOpen.LinkColor = System.Drawing.SystemColors.ControlText;
			this.llOpen.Location = new System.Drawing.Point(500, 6);
			this.llOpen.Name = "llOpen";
			this.llOpen.Size = new System.Drawing.Size(61, 23);
			this.llOpen.TabIndex = 2;
			this.llOpen.TabStop = true;
			this.llOpen.Text = "Open";
			this.llOpen.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.llOpen.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.llOpen_LinkClicked
				);
			//
			// pg
			//
			this.pg.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)
				)
			);
			this.pg.BackColor = System.Drawing.SystemColors.Control;
			this.pg.CommandsBackColor = System.Drawing.SystemColors.InactiveCaption;
			this.pg.HelpVisible = false;
			this.pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pg.Location = new System.Drawing.Point(8, 48);
			this.pg.Name = "pg";
			this.pg.PropertySort = PropertySort.Alphabetical;
			this.pg.Size = new System.Drawing.Size(558, 256);
			this.pg.TabIndex = 1;
			this.pg.ToolbarVisible = false;
			this.pg.ViewBackColor = System.Drawing.SystemColors.Control;
			//
			// llRepair
			//
			this.llRepair.Font = new System.Drawing.Font(
				"Tahoma",
				12F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.llRepair.LinkColor = System.Drawing.SystemColors.ControlText;
			this.llRepair.Location = new System.Drawing.Point(420, 6);
			this.llRepair.Name = "llRepair";
			this.llRepair.Size = new System.Drawing.Size(72, 23);
			this.llRepair.TabIndex = 0;
			this.llRepair.TabStop = true;
			this.llRepair.Text = "Repair";
			this.llRepair.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.llRepair.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.llRepair_LinkClicked
				);
			//
			// btBrowse
			//
			this.btBrowse.FlatStyle = FlatStyle.System;
			this.btBrowse.Location = new System.Drawing.Point(509, 16);
			this.btBrowse.Name = "btBrowse";
			this.btBrowse.Size = new System.Drawing.Size(75, 23);
			this.btBrowse.TabIndex = 2;
			this.btBrowse.Text = "Browse...";
			this.btBrowse.Click += new EventHandler(this.btBrowse_Click);
			//
			// tbPkg
			//
			this.tbPkg.Location = new System.Drawing.Point(80, 16);
			this.tbPkg.Name = "tbPkg";
			this.tbPkg.ReadOnly = true;
			this.tbPkg.Size = new System.Drawing.Size(420, 21);
			this.tbPkg.TabIndex = 1;
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
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Package:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// PackageRepairForm
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(594, 361);
			this.Controls.Add(this.xpGradientPanel1);
			this.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources1.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "PackageRepairForm";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Package Repair";
			this.xpGradientPanel1.ResumeLayout(false);
			this.xpGradientPanel1.PerformLayout();
			this.tbs.ResumeLayout(false);
			this.ResumeLayout(false);
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

			this.tbPkg.Text = pkgname;
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
