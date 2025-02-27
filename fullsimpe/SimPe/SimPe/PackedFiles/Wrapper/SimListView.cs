using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Summary description for SimListView.
	/// </summary>
	public class SimListView : SteepValley.Windows.Forms.XPListView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		static Size ICON_SIZE = new Size(64, 64);

		SimPe.ColumnsSorter s;

		public SimListView()
		{
			SetStyle(ControlStyles.UserMouse, true);
			// Required designer variable.
			InitializeComponent();

			this.HideSelection = false;
			this.FullRowSelect = true;
			this.MultiSelect = false;

			this.LargeImageList = new ImageList();

			LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
			LargeImageList.ImageSize = ICON_SIZE;

			s = new SimPe.ColumnsSorter(new int[] { 1, 0 });
			this.ListViewItemSorter = s;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Clear();
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
			components = new System.ComponentModel.Container();
		}
		#endregion

		public new void Clear()
		{
			Items.Clear();
			LargeImageList.Images.Clear();
			this.ListViewItemSorter = s;
		}

		public SteepValley.Windows.Forms.XPListViewItem Add(
			SimPe.PackedFiles.Wrapper.ExtSDesc sdesc
		)
		{
			return Add(
				sdesc,
				SimPe.PackedFiles.Wrapper.SimPoolControl.GetImagePanelColor(sdesc)
			);
		}

		public Image GetSimIcon(SimPe.PackedFiles.Wrapper.ExtSDesc sdesc, Color bgcol)
		{
			return BuildSimPreviewImage(bgcol, sdesc.Image, sdesc.SimId, sdesc);
		}

		public SteepValley.Windows.Forms.XPListViewItem Add(
			SimPe.PackedFiles.Wrapper.ExtSDesc sdesc,
			Color bgcol
		)
		{
			Image imgbig = BuildSimPreviewImage(bgcol, sdesc.Image, sdesc.SimId, sdesc);
			return Add(sdesc, imgbig);
		}

		public SteepValley.Windows.Forms.XPListViewItem Add(
			SimPe.PackedFiles.Wrapper.ExtSDesc sdesc,
			Image imgbig
		)
		{
			SteepValley.Windows.Forms.XPListViewItem lvi =
				new SteepValley.Windows.Forms.XPListViewItem();
			try
			{
				this.LargeImageList.Images.Add(imgbig);
				lvi.ImageIndex = LargeImageList.Images.Count - 1;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			lvi.Text = " " + sdesc.SimName + " " + sdesc.SimFamilyName;
			if (this.Columns.Count > 1)
			{
				lvi.SubItems.Add("    " + Columns[1].Text + ": " + sdesc.HouseholdName);
			}

			if (this.Columns.Count > 2)
			{
				lvi.SubItems.Add(
					"    " + Columns[2].Text + ": 0x" + Helper.HexString(sdesc.SimId)
				);
			}

			if (this.Columns.Count > 3)
			{
				lvi.SubItems.Add(
					"    "
						+ Columns[3].Text
						+ ": 0x"
						+ Helper.HexString((ushort)sdesc.FileDescriptor.Instance)
				);
			}

			if (this.Columns.Count > 4)
			{
				if (sdesc.University.OnCampus == 0x1)
				{
					lvi.SubItems.Add(
						"    "
							+ Columns[4].Text
							+ ": "
							+ Localization.Manager.GetString("YoungAdult")
					);
				}
				else
				{
					lvi.SubItems.Add(
						"    "
							+ Columns[4].Text
							+ ": "
							+ new Data.LocalizedLifeSections(
								sdesc.CharacterDescription.LifeSection
							).ToString()
					);
				}
			}

			this.Items.Add(lvi);
			return lvi;
		}

		static System.Collections.Generic.Dictionary<uint, Image> simicons =
			new System.Collections.Generic.Dictionary<uint, Image>();

		public static Image BuildSimPreviewImage(
			SimPe.PackedFiles.Wrapper.ExtSDesc sdesc,
			Color bgcol
		)
		{
			return BuildSimPreviewImage(bgcol, sdesc.Image, sdesc.SimId, sdesc);
		}

		protected static Image BuildSimPreviewImage(
			Color bgcol,
			Image imgbig,
			uint guid,
			SimPe.PackedFiles.Wrapper.ExtSDesc sdesc
		)
		{
			if (simicons.ContainsKey(guid))
			{
				Image img = simicons[guid];
				if (img != null)
				{
					return (Image)img.Clone();
				}
			}

			if (imgbig != null)
			{
				if (imgbig.Width < 16)
				{
					imgbig = null;
				}
			}

			if (imgbig != null)
			{
				imgbig = Ambertation.Drawing.GraphicRoutines.KnockoutImage(
					imgbig,
					new Point(0, 0),
					Color.Magenta
				);
			}
			else
			{
				imgbig = SimPe.GetImage.NoOne;
			}

			imgbig = Ambertation.Windows.Forms.Graph.ImagePanel.CreateThumbnail(
				imgbig,
				ICON_SIZE,
				8,
				Color.FromArgb(90, Color.Black),
				bgcol,
				Color.White,
				Color.FromArgb(80, Color.White),
				true,
				0,
				0
			);

			simicons[guid] = imgbig;
			return (Image)imgbig.Clone();
		}
	}
}
