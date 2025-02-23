using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SimPe.Wizards
{
	/// <summary>
	/// Summary description for CheckForm.
	/// </summary>
	public class CheckForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		SimPe.CheckControl chk;

		public CheckForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CheckForm));
			this.chk = new SimPe.CheckControl();
			this.SuspendLayout();
			// 
			// chk
			// 
			this.chk.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chk.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.chk.Location = new System.Drawing.Point(0, 0);
			this.chk.Name = "chk";
			this.chk.Size = new System.Drawing.Size(346, 232);
			this.chk.TabIndex = 0;
			// 
			// CheckForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(346, 232);
			this.Controls.Add(this.chk);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CheckForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "System Check";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
