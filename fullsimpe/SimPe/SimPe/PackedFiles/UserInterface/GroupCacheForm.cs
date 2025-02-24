using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Zusammenfassung für GroupCacheForm.
	/// </summary>
	internal class GroupCacheForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.ListBox lbgroup;
		private System.Windows.Forms.Panel panel4;
		internal System.Windows.Forms.Label label12;
		internal System.Windows.Forms.Panel GropPanel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GroupCacheForm()
		{
			InitializeComponent();

			//
			// TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
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
			this.GropPanel = new System.Windows.Forms.Panel();
			this.lbgroup = new System.Windows.Forms.ListBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label12 = new System.Windows.Forms.Label();
			this.GropPanel.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// GropPanel
			// 
			this.GropPanel.Controls.Add(this.lbgroup);
			this.GropPanel.Controls.Add(this.panel4);
			this.GropPanel.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.GropPanel.Location = new System.Drawing.Point(14, 29);
			this.GropPanel.Name = "GropPanel";
			this.GropPanel.Size = new System.Drawing.Size(264, 208);
			this.GropPanel.TabIndex = 8;
			// 
			// lbgroup
			// 
			this.lbgroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lbgroup.HorizontalScrollbar = true;
			this.lbgroup.IntegralHeight = false;
			this.lbgroup.Location = new System.Drawing.Point(8, 32);
			this.lbgroup.Name = "lbgroup";
			this.lbgroup.Size = new System.Drawing.Size(248, 168);
			this.lbgroup.TabIndex = 3;
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel4.Controls.Add(this.label12);
			this.panel4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
			this.panel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(264, 24);
			this.panel4.TabIndex = 0;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label12.Location = new System.Drawing.Point(0, 4);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(157, 19);
			this.label12.TabIndex = 0;
			this.label12.Text = "Group Cache Viewer";
			// 
			// GroupCacheForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.GropPanel);
			this.Name = "GroupCacheForm";
			this.Text = "GroupCacheForm";
			this.GropPanel.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
