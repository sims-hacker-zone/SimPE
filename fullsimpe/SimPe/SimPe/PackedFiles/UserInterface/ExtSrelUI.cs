/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System.Drawing;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for ExtSrelUI.
	/// </summary>
	public class ExtSrel : Windows.Forms.WrapperBaseControl, IPackedFileUI
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbsims;
		private CommonSrel sc;
		private System.Windows.Forms.PictureBox pb;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ExtSrel()
		{
			Text = Localization.GetString("Sim Relation Editor");

			InitializeComponent();

			if (Helper.WindowsRegistry.UseBigIcons)
			{
				lbsims.Font = new Font("Tahoma", 12);
			}
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
				new System.ComponentModel.ComponentResourceManager(typeof(ExtSrel));
			label1 = new System.Windows.Forms.Label();
			lbsims = new System.Windows.Forms.Label();
			sc = new CommonSrel();
			pb = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(pb)).BeginInit();
			SuspendLayout();
			//
			// label1
			//
			label1.AutoEllipsis = true;
			label1.BackColor = Color.Transparent;
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// lbsims
			//
			resources.ApplyResources(lbsims, "lbsims");
			lbsims.BackColor = Color.Transparent;
			lbsims.Name = "lbsims";
			//
			// sc
			//
			resources.ApplyResources(sc, "sc");
			sc.BackColor = Color.Transparent;
			sc.Name = "sc";
			sc.Srel = null;
			//
			// pb
			//
			pb.BackColor = Color.Transparent;
			resources.ApplyResources(pb, "pb");
			pb.Name = "pb";
			pb.TabStop = false;
			//
			// ExtSrel
			//
			Controls.Add(pb);
			Controls.Add(label1);
			Controls.Add(sc);
			Controls.Add(lbsims);
			resources.ApplyResources(this, "$this");
			Name = "ExtSrel";
			Commited += new System.EventHandler(ExtSrel_Commited);
			Controls.SetChildIndex(lbsims, 0);
			Controls.SetChildIndex(sc, 0);
			Controls.SetChildIndex(label1, 0);
			Controls.SetChildIndex(pb, 0);
			((System.ComponentModel.ISupportInitialize)(pb)).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		public Wrapper.ExtSrel Srel => (Wrapper.ExtSrel)Wrapper;

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			sc.Srel = Srel;

			lbsims.Text =
				sc.SourceSimName
				+ " "
				+ Localization.GetString("towards")
				+ " "
				+ sc.TargetSimName;
			pb.Image = Ambertation.Drawing.GraphicRoutines.ScaleImage(
				sc.Image,
				pb.Size,
				true
			);

			pb.Image = Ambertation.Windows.Forms.Graph.ImagePanel.CreateThumbnail(
				sc.Image,
				pb.Size,
				12,
				Color.FromArgb(90, Color.Black),
				ThemeManager.Global.ThemeColorDark,
				Color.White,
				Color.FromArgb(80, Color.White),
				true,
				2,
				0
			);
		}

		private void ExtSrel_Commited(object sender, System.EventArgs e)
		{
			Srel.SynchronizeUserData();
		}
	}
}
