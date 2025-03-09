// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Objd;

namespace SimPe.PackedFiles.Sdsc
{
	/// <summary>
	/// Summary description for SimRelinkForm.
	/// </summary>
	public class SimRelinkForm : Form
	{
		private Label label1;
		private ListView lv;
		private ImageList ilist;
		private Label label2;
		private CheckBox cbfile;
		private Button btlink;
		private System.ComponentModel.IContainer components;

		public SimRelinkForm()
		{
			//
			// Required designer variable.
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(SimRelinkForm)
				);
			label1 = new Label();
			lv = new ListView();
			ilist = new ImageList(components);
			label2 = new Label();
			cbfile = new CheckBox();
			btlink = new Button();
			SuspendLayout();
			//
			// label1
			//
			label1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label1.Location = new Point(8, 76);
			label1.Name = "label1";
			label1.Size = new Size(110, 19);
			label1.TabIndex = 0;
			label1.Text = "Character File:";
			label1.TextAlign = ContentAlignment.BottomLeft;
			//
			// lv
			//
			lv.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lv.HideSelection = false;
			lv.LargeImageList = ilist;
			lv.Location = new Point(32, 96);
			lv.MultiSelect = false;
			lv.Name = "lv";
			lv.Size = new Size(556, 306);
			lv.Sorting = SortOrder.Ascending;
			lv.TabIndex = 1;
			lv.UseCompatibleStateImageBehavior = false;
			lv.SelectedIndexChanged += new System.EventHandler(
				lv_SelectedIndexChanged
			);
			//
			// ilist
			//
			ilist.ColorDepth = ColorDepth.Depth8Bit;
			ilist.ImageSize = new Size(64, 64);
			ilist.TransparentColor = Color.Transparent;
			//
			// label2
			//
			label2.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			label2.Font = new Font(
				"Georgia",
				9.75F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label2.ForeColor = Color.Red;
			label2.Location = new Point(8, 8);
			label2.Name = "label2";
			label2.Size = new Size(604, 64);
			label2.TabIndex = 2;
			label2.Text = resources.GetString("label2.Text");
			label2.TextAlign = ContentAlignment.MiddleCenter;
			//
			// cbfile
			//
			cbfile.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Left


			;
			cbfile.FlatStyle = FlatStyle.System;
			cbfile.Location = new Point(12, 407);
			cbfile.Name = "cbfile";
			cbfile.Size = new Size(235, 24);
			cbfile.TabIndex = 3;
			cbfile.Text = "Change GUID in Character File";
			//
			// btlink
			//
			btlink.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			btlink.FlatStyle = FlatStyle.System;
			btlink.Location = new Point(537, 408);
			btlink.Name = "btlink";
			btlink.Size = new Size(75, 23);
			btlink.TabIndex = 4;
			btlink.Text = "Re-Map";
			btlink.Click += new System.EventHandler(btlink_Click);
			//
			// SimRelinkForm
			//
			AutoScaleBaseSize = new Size(6, 14);
			ClientSize = new Size(624, 442);
			Controls.Add(btlink);
			Controls.Add(cbfile);
			Controls.Add(label2);
			Controls.Add(lv);
			Controls.Add(label1);
			Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "SimRelinkForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "SimReMapForm";
			ResumeLayout(false);
		}
		#endregion

		bool ok = false;

		/// <summary>
		/// Show the Relink Screen
		/// </summary>
		/// <param name="path">The Path where to look for character Files</param>
		/// <param name="wrp">The Sim Description Wrapper</param>
		/// <returns>The new SimID</returns>
		public static uint Execute(SDesc wrp)
		{
			Hashtable ht = wrp.nameprovider.StoredData;
			SimRelinkForm srf = new SimRelinkForm();
			WaitingScreen.Wait();
			try
			{
				foreach (Data.Alias a in ht.Values)
				{
					if (!(a.Tag[2] as string).Contains("(NPC)"))
					{
						ListViewItem lvi = new ListViewItem(
							a.Name + " " + (string)a.Tag[2]
						)
						{
							Tag = a
						};

						if (a.Tag[1] != null)
						{
							lvi.ImageIndex = srf.ilist.Images.Count;
							Image img = Plugin.ImageLoader.Preview(
								(Image)a.Tag[1],
								srf.ilist.ImageSize
							);

							if (wrp.sdescprovider.FindSim(a.Id) != null)
							{
								Graphics gr = Graphics.FromImage(img);
								gr.FillRectangle(
									new Pen(Color.FromArgb(0x40, Color.Red), 1).Brush,
									0,
									0,
									img.Width,
									img.Height
								);
							}

							srf.ilist.Images.Add(img);
						}

						srf.lv.Items.Add(lvi);
					}
					srf.lv.Sort();
					srf.btlink.Enabled = false;
					srf.ok = false;
				}
			}
			finally
			{
				WaitingScreen.Stop(srf);
			}

			srf.ShowDialog();

			if (srf.ok)
			{
				Data.Alias a = (Data.Alias)srf.lv.SelectedItems[0].Tag;
				Packages.GeneratableFile pkg =
					Packages.File.LoadFromFile((string)a.Tag[0]);

				Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
					Data.FileTypes.OBJD
				);
				if (pfds.Length == 1)
				{
					ExtObjd objd =
						new ExtObjd().ProcessFile(pfds[0], pkg);

					if (srf.cbfile.Checked)
					{
						objd.Guid = wrp.SimId;
						objd.ProxyGuid = wrp.SimId;
						objd.SynchronizeUserData();
						pkg.Save();
					}
					else
					{
						wrp.SimId = objd.Guid;
					}
				}
			}

			return wrp.SimId;
		}

		private void lv_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			btlink.Enabled = lv.SelectedItems.Count == 1;
		}

		private void btlink_Click(object sender, System.EventArgs e)
		{
			ok = true;
			Close();
		}
	}
}
