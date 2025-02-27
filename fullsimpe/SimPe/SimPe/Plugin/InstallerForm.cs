namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for InstallerForm.
	/// </summary>
	public class InstallerForm : System.Windows.Forms.Form
	{
		private InstallerControl installerControl1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InstallerForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			//
			// TODO: F�gen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(InstallerForm)
				);
			this.installerControl1 = new InstallerControl();
			this.SuspendLayout();
			//
			// installerControl1
			//
			this.installerControl1.BackgroundImage = (
				(System.Drawing.Image)(
					resources.GetObject("installerControl1.BackgroundImage")
				)
			);
			this.installerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.installerControl1.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.installerControl1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.installerControl1.Location = new System.Drawing.Point(0, 0);
			this.installerControl1.Name = "installerControl1";
			this.installerControl1.Size = new System.Drawing.Size(624, 334);
			this.installerControl1.TabIndex = 0;
			//
			// InstallerForm
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(624, 334);
			this.Controls.Add(this.installerControl1);
			this.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "InstallerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Content Preview";
			this.ResumeLayout(false);
		}
		#endregion
	}
}
