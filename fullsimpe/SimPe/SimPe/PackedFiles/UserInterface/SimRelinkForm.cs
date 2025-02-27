using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.PackedFiles.UserInterface
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(SimRelinkForm)
				);
			this.label1 = new Label();
			this.lv = new ListView();
			this.ilist = new ImageList(this.components);
			this.label2 = new Label();
			this.cbfile = new CheckBox();
			this.btlink = new Button();
			this.SuspendLayout();
			//
			// label1
			//
			this.label1.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label1.Location = new Point(8, 76);
			this.label1.Name = "label1";
			this.label1.Size = new Size(110, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Character File:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// lv
			//
			this.lv.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.lv.HideSelection = false;
			this.lv.LargeImageList = this.ilist;
			this.lv.Location = new Point(32, 96);
			this.lv.MultiSelect = false;
			this.lv.Name = "lv";
			this.lv.Size = new Size(556, 306);
			this.lv.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lv.TabIndex = 1;
			this.lv.UseCompatibleStateImageBehavior = false;
			this.lv.SelectedIndexChanged += new System.EventHandler(
				this.lv_SelectedIndexChanged
			);
			//
			// ilist
			//
			this.ilist.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.ilist.ImageSize = new Size(64, 64);
			this.ilist.TransparentColor = System.Drawing.Color.Transparent;
			//
			// label2
			//
			this.label2.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.label2.Font = new Font(
				"Georgia",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new Size(604, 64);
			this.label2.TabIndex = 2;
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			//
			// cbfile
			//
			this.cbfile.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Left
					)
				)
			);
			this.cbfile.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbfile.Location = new Point(12, 407);
			this.cbfile.Name = "cbfile";
			this.cbfile.Size = new Size(235, 24);
			this.cbfile.TabIndex = 3;
			this.cbfile.Text = "Change GUID in Character File";
			//
			// btlink
			//
			this.btlink.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.btlink.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btlink.Location = new Point(537, 408);
			this.btlink.Name = "btlink";
			this.btlink.Size = new Size(75, 23);
			this.btlink.TabIndex = 4;
			this.btlink.Text = "Re-Map";
			this.btlink.Click += new System.EventHandler(this.btlink_Click);
			//
			// SimRelinkForm
			//
			this.AutoScaleBaseSize = new Size(6, 14);
			this.ClientSize = new Size(624, 442);
			this.Controls.Add(this.btlink);
			this.Controls.Add(this.cbfile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lv);
			this.Controls.Add(this.label1);
			this.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SimRelinkForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SimReMapForm";
			this.ResumeLayout(false);
		}
		#endregion

		bool ok = false;

		/// <summary>
		/// Show the Relink Screen
		/// </summary>
		/// <param name="path">The Path where to look for character Files</param>
		/// <param name="wrp">The Sim Description Wrapper</param>
		/// <returns>The new SimID</returns>
		public static uint Execute(Wrapper.SDesc wrp)
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
						);
						lvi.Tag = a;

						if (a.Tag[1] != null)
						{
							lvi.ImageIndex = srf.ilist.Images.Count;
							Image img = SimPe.Plugin.ImageLoader.Preview(
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
					SimPe.Packages.GeneratableFile.LoadFromFile((string)a.Tag[0]);

				Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
					Data.MetaData.OBJD_FILE
				);
				if (pfds.Length == 1)
				{
					Wrapper.ExtObjd objd =
						new Wrapper.ExtObjd();
					objd.ProcessData(pfds[0], pkg);

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
			btlink.Enabled = (lv.SelectedItems.Count == 1);
		}

		private void btlink_Click(object sender, System.EventArgs e)
		{
			ok = true;
			Close();
		}
	}
}
