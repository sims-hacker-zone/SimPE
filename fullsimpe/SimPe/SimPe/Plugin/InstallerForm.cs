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
			installerControl1 = new InstallerControl();
			SuspendLayout();
			//
			// installerControl1
			//
			installerControl1.BackgroundImage = (
				(System.Drawing.Image)(
					resources.GetObject("installerControl1.BackgroundImage")
				)
			);
			installerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			installerControl1.Font = new System.Drawing.Font("Tahoma", 8.25F);
			installerControl1.ForeColor = System.Drawing.SystemColors.ControlText;
			installerControl1.Location = new System.Drawing.Point(0, 0);
			installerControl1.Name = "installerControl1";
			installerControl1.Size = new System.Drawing.Size(624, 334);
			installerControl1.TabIndex = 0;
			//
			// InstallerForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			ClientSize = new System.Drawing.Size(624, 334);
			Controls.Add(installerControl1);
			Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			Name = "InstallerForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Content Preview";
			ResumeLayout(false);
		}
		#endregion
	}
}
