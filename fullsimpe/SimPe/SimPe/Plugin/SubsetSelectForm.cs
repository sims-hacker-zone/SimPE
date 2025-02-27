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
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for SubsetSelectForm.
	/// </summary>
	public class SubsetSelectForm : Form
	{
		private Panel panel1;
		public Panel pnselect;
		public Button button1;
		public CheckBox cbauto;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		internal SubsetSelectForm()
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
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(SubsetSelectForm));
			panel1 = new Panel();
			cbauto = new CheckBox();
			button1 = new Button();
			pnselect = new Panel();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// panel1
			//
			panel1.Anchor = (
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
			panel1.Controls.Add(cbauto);
			panel1.Controls.Add(button1);
			panel1.Controls.Add(pnselect);
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(536, 440);
			panel1.TabIndex = 0;
			//
			// cbauto
			//
			cbauto.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)
				)
			);
			cbauto.Checked = true;
			cbauto.CheckState = CheckState.Checked;
			cbauto.FlatStyle = FlatStyle.System;
			cbauto.Location = new Point(8, 408);
			cbauto.Name = "cbauto";
			cbauto.Size = new Size(240, 24);
			cbauto.TabIndex = 3;
			cbauto.Text = "Autoselect matching Textures";
			//
			// button1
			//
			button1.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			button1.FlatStyle = FlatStyle.System;
			button1.Location = new Point(456, 416);
			button1.Name = "button1";
			button1.TabIndex = 2;
			button1.Text = "OK";
			button1.Click += new EventHandler(button1_Click);
			//
			// pnselect
			//
			pnselect.Anchor = (
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
			pnselect.AutoScroll = true;
			pnselect.Location = new Point(0, 0);
			pnselect.Name = "pnselect";
			pnselect.Size = new Size(536, 408);
			pnselect.TabIndex = 1;
			//
			// SubsetSelectForm
			//
			AutoScaleBaseSize = new Size(6, 14);
			ClientSize = new Size(544, 446);
			Controls.Add(panel1);
			Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((System.Byte)(0))
			);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Icon = ((Icon)(resources.GetObject("$this.Icon")));
			Name = "SubsetSelectForm";
			Text = "Subset Selection";
			Closing += new System.ComponentModel.CancelEventHandler(
				DoClosing
			);
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion



		/// <summary>
		/// Returns a list of all availabel ListViews
		/// </summary>
		public ArrayList ListViews
		{
			get; private set;
		}

		public static Size ImageSize = new Size(128, 128);

		/// <summary>
		/// Add a new Selection for a Subset
		/// </summary>
		/// <param name="ssf">The for you want to add the Selection to</param>
		/// <param name="subset">The name of the Subset</param>
		/// <param name="top">the top coordinate for the Selection Panel</param>
		/// <returns>the ListView you can use to add Items to</returns>
		protected ListView AddSelection(
			SubsetSelectForm ssf,
			string subset,
			ref int top
		)
		{
			Panel pn = new Panel();
			pn.Parent = ssf.pnselect;
			pn.Top = top;
			pn.Left = 8;
			pn.Width = ssf.pnselect.Width - 16;
			pn.Height = ImageSize.Height + 64;
			pn.Visible = false;
			pn.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

			CheckBox cb = new CheckBox();
			cb.Parent = pn;
			cb.Top = 0;
			cb.Left = 0;
			cb.Checked = true;
			cb.Width = pn.Width;
			cb.Text = subset;
			cb.Anchor = pn.Anchor;
			cb.FlatStyle = FlatStyle.System;
			cb.CheckedChanged += new EventHandler(CheckedChanged);

			ListView lv = new ListView();
			lv.Parent = pn;
			lv.Tag = subset;
			lv.Left = 8;
			lv.Top = cb.Height + cb.Top;
			lv.Width = pn.Width - lv.Left;
			lv.Height = pn.Height - lv.Top;
			lv.Anchor =
				AnchorStyles.Left
				| AnchorStyles.Top
				| AnchorStyles.Right
				| AnchorStyles.Bottom;
			lv.HideSelection = false;
			lv.MultiSelect = false;
			lv.SelectedIndexChanged += new EventHandler(SelectedIndexChanged);
			cb.Tag = lv;

			ImageList il = new ImageList();
			il.ImageSize = ImageSize;
			il.ColorDepth = ColorDepth.Depth32Bit;
			lv.LargeImageList = il;

			top += pn.Height + 8;
			pn.Visible = true;

			ListViews.Add(lv);
			return lv;
		}

		/// <summary>
		/// Return the Thumbnail for the mmat with the passed Index
		/// </summary>
		/// <param name="index"></param>
		/// <param name="mmats"></param>
		/// <param name="sz">Size of the Thumbnail</param>
		/// <returns>a valid Image</returns>
		protected Image GetItemThumb(int index, ArrayList mmats, Size sz)
		{
			if ((index < 0) || (index >= mmats.Count))
			{
				return new Bitmap(sz.Width, sz.Height);
			}

			MmatWrapper mmat = (MmatWrapper)mmats[index];
			GenericRcol txtr = mmat.TXTR;
			if (txtr != null)
			{
				ImageData id = (ImageData)txtr.Blocks[0];
				MipMap mm = id.LargestTexture;

				if (mm != null)
				{
					return ImageLoader.Preview(mm.Texture, sz);
				}
			}

			return new Bitmap(sz.Width, sz.Height);
		}

		/// <summary>
		/// Creates a Thumbnail for the current Texture
		/// </summary>
		/// <param name="il">The ImageList that will hold the Thumbnail</param>
		/// <param name="lvi">The ListView Item that will get the Thumbnail Image</param>
		/// <param name="mmats">The Materials</param>
		protected void MakePreview(ImageList il, ListViewItem lvi, ArrayList mmats)
		{
			if (mmats.Count == 1)
			{
				Image img = GetItemThumb(0, mmats, il.ImageSize);
				lvi.ImageIndex = il.Images.Count;
				il.Images.Add(img);
			}
			else if (mmats.Count > 1)
			{
				Image img1 = GetItemThumb(0, mmats, il.ImageSize);
				Image img2 = GetItemThumb(1, mmats, il.ImageSize);

				Bitmap bm = new Bitmap(il.ImageSize.Width, il.ImageSize.Height);
				Graphics gr = Graphics.FromImage(bm);
				gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				gr.CompositingQuality = System
					.Drawing
					.Drawing2D
					.CompositingQuality
					.HighQuality;

				Rectangle source = new Rectangle(
					0,
					0,
					il.ImageSize.Width / 2,
					il.ImageSize.Height
				);
				gr.DrawImage(img1, source, source, GraphicsUnit.Pixel);

				source = new Rectangle(
					il.ImageSize.Width / 2,
					0,
					il.ImageSize.Width / 2,
					il.ImageSize.Height
				);
				gr.DrawImage(img2, source, source, GraphicsUnit.Pixel);

				gr.DrawLine(
					new Pen(Color.Orange, 2),
					il.ImageSize.Width / 2,
					0,
					il.ImageSize.Width / 2,
					il.ImageSize.Height
				);

				gr.FillEllipse(
					new Pen(Color.Orange, 1).Brush,
					(ImageSize.Width - 24) / 2,
					4,
					24,
					24
				);
				Font ft = new Font(
					"Verdana",
					16.0f,
					FontStyle.Bold | FontStyle.Italic,
					GraphicsUnit.Pixel
				);

				gr.DrawString(
					mmats.Count.ToString(),
					ft,
					new Pen(Color.White).Brush,
					new RectangleF((ImageSize.Width - 24) / 2 + 2, 6, 20, 20)
				);

				lvi.ImageIndex = il.Images.Count;
				il.Images.Add(bm);
			}
		}

		Hashtable txmtnames;

		/// <summary>
		/// Add a New Item to the ListView
		/// </summary>
		/// <param name="lv">the list view you want to add the items to</param>
		/// <param name="mmats">an array of MmatWraper Objects having all possible states</param>
		protected void AddItem(ListView lv, ArrayList mmats)
		{
			if (mmats.Count == 0)
			{
				return;
			}

			ListViewItem lvi = new ListViewItem();
			GenericRcol txtr = ((MmatWrapper)mmats[0]).TXTR;
			GenericRcol txmt = ((MmatWrapper)mmats[0]).TXMT;
			if (txmt != null)
			{
				string txmtname = Hashes.StripHashFromName(
					txmt.FileName.Trim().ToLower()
				);
				if (!txmtnames.ContainsKey(txmtname))
				{
					if (txtr != null)
					{
						lvi.Text = txtr.FileName;
						lvi.Tag = mmats;

						MakePreview(lv.LargeImageList, lvi, mmats);

						lv.Items.Add(lvi);
					}
					else
					{
						lvi.Text = txmt.FileName;
						lvi.Tag = mmats;
						lv.Items.Add(lvi);
					}

					txmtnames.Add(txmtname, lvi);
				} //txmtnames
				else
				{
					ListViewItem l = (ListViewItem)txmtnames[txmtname];
					ArrayList ls = (ArrayList)l.Tag;
					ls.AddRange(mmats);
				}
			}
		}

		/// <summary>
		/// Setup the Form
		/// </summary>
		/// <param name="map">The subset map</param>
		/// <param name="subsets">the subsets you want to present</param>
		/// <returns>Returns a New Instance of the selection Form</returns>
		public static SubsetSelectForm Prepare(Hashtable map, ArrayList subsets)
		{
			SubsetSelectForm ssf = new SubsetSelectForm();
			ssf.ListViews = new ArrayList();
			ssf.txmtnames = new Hashtable();
			WaitingScreen.Wait();
			try
			{
				WaitingScreen.UpdateMessage("Show Subset Selection");
				ssf.button1.Enabled = false;

				int top = 0;
				foreach (string subset in map.Keys)
				{
					if (!subsets.Contains(subset))
					{
						continue;
					}

					ListView lv = ssf.AddSelection(ssf, subset, ref top);
					Hashtable families = (Hashtable)map[subset];
					foreach (string family in families.Keys)
					{
						ArrayList mmats = (ArrayList)families[family];
						mmats.Sort(new MmatListCompare());
						ssf.AddItem(lv, mmats);
					}

					if (lv.Items.Count > 0)
					{
						lv.Items[0].Selected = true;
					}
				}
			}
			finally
			{
				WaitingScreen.Stop();
			}

			return ssf;
		}

		/// <summary>
		/// Builds a new Hashtable based on the Users Selection
		/// </summary>
		/// <param name="ssf">The Form that was used</param>
		/// <returns>The new Hashtable</returns>
		public static Hashtable Finish(SubsetSelectForm ssf)
		{
			//now rebuild the Hashtable with the stored Infos
			Hashtable ret = new Hashtable();
			foreach (ListView lv in ssf.ListViews)
			{
				if (!lv.Enabled)
				{
					continue;
				}

				if (lv.SelectedItems.Count > 0)
				{
					Hashtable sub = new Hashtable
					{
						["user-selection"] = lv.SelectedItems[0].Tag
					};
					ret[(string)lv.Tag] = sub;
				}
			}

			return ret;
		}

		/// <summary>
		/// Show the Selection Form
		/// </summary>
		/// <param name="map">The subset map</param>
		/// <param name="package">the opened source package</param>
		/// <param name="subsets">List of all Subsets you want to present</param>
		/// <returns>the map with all the selected Items</returns>
		public static Hashtable Execute(Hashtable map, ArrayList subsets)
		{
			SubsetSelectForm ssf = Prepare(map, subsets);
			ssf.ShowDialog();
			return Finish(ssf);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// true, if a SubSet is selected in each ListView
		/// </summary>
		private bool CanContinue
		{
			get
			{
				if (ListViews.Count == 0)
				{
					return true;
				}

				foreach (ListView lv in ListViews)
				{
					if (
						(lv.SelectedItems.Count == 0)
						&& lv.Enabled
						&& lv.Items.Count != 0
					)
					{
						return false;
					}
				}

				return true;
			}
		}

		private void CheckedChanged(object sender, EventArgs e)
		{
			CheckBox cb = (CheckBox)sender;
			ListView lv = (ListView)cb.Tag;

			lv.Enabled = cb.Checked;
			button1.Enabled = CanContinue;
		}

		bool internalupdate = false;

		private void SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalupdate)
			{
				return;
			}

			internalupdate = true;
			try
			{
				ListView lv = (ListView)sender;

				//autoselect matching Textures
				if ((cbauto.Checked) && (lv.SelectedItems.Count > 0))
				{
					string name = lv.SelectedItems[0].Text;
					foreach (ListView lv2 in ListViews)
					{
						if (lv2 == lv)
						{
							continue;
						}

						foreach (ListViewItem lvi in lv2.Items)
						{
							if (lvi.Text == name)
							{
								lvi.Selected = true;
							}
						}
					}
				}

				button1.Enabled = CanContinue;
			}
			finally
			{
				internalupdate = false;
			}
		}

		private void DoClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!CanContinue)
			{
				MessageBox.Show(
					"Please select a Texture in each Subset!",
					"Warning"
				);
				e.Cancel = true;
			}
		}
	}
}
