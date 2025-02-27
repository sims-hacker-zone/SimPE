namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Summary description for DockableWindow1.
	/// </summary>
	public class dcPackageDetails : Ambertation.Windows.Forms.DockPanel
	{
		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel1;
		protected NeighborhoodPreview np;
		private ObjectPreview op;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public dcPackageDetails()
		{
			// This call is required by the Windows.Forms Form Designer.
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

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(dcPackageDetails)
				);
			xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			np = new NeighborhoodPreview();
			op = new ObjectPreview();
			xpGradientPanel1.SuspendLayout();
			SuspendLayout();
			//
			// xpGradientPanel1
			//
			xpGradientPanel1.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(xpGradientPanel1, "xpGradientPanel1");
			xpGradientPanel1.Controls.Add(np);
			xpGradientPanel1.Controls.Add(op);
			xpGradientPanel1.Name = "xpGradientPanel1";
			//
			// np
			//
			np.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(np, "np");
			np.Name = "np";
			//
			// op
			//
			resources.ApplyResources(op, "op");
			op.BackColor = System.Drawing.Color.Transparent;
			op.LoadCustomImage = true;
			op.Name = "op";
			op.SelectedObject = null;
			op.SelectedXObject = null;
			//
			// dcPackageDetails
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(xpGradientPanel1);
			FloatingSize = new System.Drawing.Size(592, 376);
			Image = (System.Drawing.Image)resources.GetObject("$this.Image");
			Name = "dcPackageDetails";
			TabImage =
				(System.Drawing.Image)resources.GetObject("$this.TabImage")
			;
			TabText = "Details";
			VisibleChanged += new System.EventHandler(
				dcPackageDetails_VisibleChanged
			);
			xpGradientPanel1.ResumeLayout(false);
			xpGradientPanel1.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		private void dcPackageDetails_VisibleChanged(object sender, System.EventArgs e)
		{
			op.LoadCustomImage = Visible;
		}

		internal void SetPackage(Interfaces.Files.IPackageFile pkg) // CJH
		{
			op.SetFromPackage(pkg);
			np.SetFromPackage(pkg);
			op.Visible = op.Loaded;
			np.Visible = np.Loaded;
		}
	}
}
