using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Summary description for DockableWindow1.
	/// </summary>
	public class dcPackageDetails : Ambertation.Windows.Forms.DockPanel
	{
		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel1;
		protected SimPe.Plugin.Tool.Dockable.NeighborhoodPreview np;
		private SimPe.Plugin.Tool.Dockable.ObjectPreview op;
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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dcPackageDetails));
			this.xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			this.np = new SimPe.Plugin.Tool.Dockable.NeighborhoodPreview();
			this.op = new SimPe.Plugin.Tool.Dockable.ObjectPreview();
			this.xpGradientPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// xpGradientPanel1
			// 
			this.xpGradientPanel1.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.xpGradientPanel1, "xpGradientPanel1");
			this.xpGradientPanel1.BackgroundImageZoomToFit = true;
			this.xpGradientPanel1.Controls.Add(this.np);
			this.xpGradientPanel1.Controls.Add(this.op);
			this.xpGradientPanel1.Name = "xpGradientPanel1";
			// 
			// np
			// 
			this.np.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.np, "np");
			this.np.Name = "np";
			// 
			// op
			// 
			resources.ApplyResources(this.op, "op");
			this.op.BackColor = System.Drawing.Color.Transparent;
			this.op.LoadCustomImage = true;
			this.op.Name = "op";
			this.op.SelectedObject = null;
			this.op.SelectedXObject = null;
			// 
			// dcPackageDetails
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.xpGradientPanel1);
			this.FloatingSize = new System.Drawing.Size(592, 376);
			this.Image = ((System.Drawing.Image)(resources.GetObject("$this.Image")));
			this.Name = "dcPackageDetails";
			this.TabImage = ((System.Drawing.Image)(resources.GetObject("$this.TabImage")));
			this.TabText = "Details";
			this.VisibleChanged += new System.EventHandler(this.dcPackageDetails_VisibleChanged);
			this.xpGradientPanel1.ResumeLayout(false);
			this.xpGradientPanel1.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private void dcPackageDetails_VisibleChanged(object sender, System.EventArgs e)
		{
			this.op.LoadCustomImage = this.Visible;
		}

		internal void SetPackage(SimPe.Interfaces.Files.IPackageFile pkg) // CJH
		{
			this.op.SetFromPackage(pkg);
			this.np.SetFromPackage(pkg);
			op.Visible = op.Loaded;
			np.Visible = np.Loaded;
		}
	}
}
