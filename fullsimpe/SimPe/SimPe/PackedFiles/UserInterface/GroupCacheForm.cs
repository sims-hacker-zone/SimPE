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
			GropPanel = new System.Windows.Forms.Panel();
			lbgroup = new System.Windows.Forms.ListBox();
			panel4 = new System.Windows.Forms.Panel();
			label12 = new System.Windows.Forms.Label();
			GropPanel.SuspendLayout();
			panel4.SuspendLayout();
			SuspendLayout();
			//
			// GropPanel
			//
			GropPanel.Controls.Add(lbgroup);
			GropPanel.Controls.Add(panel4);
			GropPanel.Font = new System.Drawing.Font("Verdana", 8.25F);
			GropPanel.Location = new System.Drawing.Point(14, 29);
			GropPanel.Name = "GropPanel";
			GropPanel.Size = new System.Drawing.Size(264, 208);
			GropPanel.TabIndex = 8;
			//
			// lbgroup
			//
			lbgroup.Anchor =

					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)

			;
			lbgroup.HorizontalScrollbar = true;
			lbgroup.IntegralHeight = false;
			lbgroup.Location = new System.Drawing.Point(8, 32);
			lbgroup.Name = "lbgroup";
			lbgroup.Size = new System.Drawing.Size(248, 168);
			lbgroup.TabIndex = 3;
			//
			// panel4
			//
			panel4.Anchor =

					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)

			;
			panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
			panel4.Controls.Add(label12);
			panel4.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold
			);
			panel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel4.Location = new System.Drawing.Point(0, 0);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(264, 24);
			panel4.TabIndex = 0;
			//
			// label12
			//
			label12.AutoSize = true;
			label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			label12.Location = new System.Drawing.Point(0, 4);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(157, 19);
			label12.TabIndex = 0;
			label12.Text = "Group Cache Viewer";
			//
			// GroupCacheForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(292, 266);
			Controls.Add(GropPanel);
			Name = "GroupCacheForm";
			Text = "GroupCacheForm";
			GropPanel.ResumeLayout(false);
			panel4.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion
	}
}
