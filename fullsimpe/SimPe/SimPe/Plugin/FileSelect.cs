// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.ThreeIdr;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for FileSelect.
	/// </summary>
	public class FileSelect : Form
	{
		private Button button1;
		private TabControl tc;
		private PictureBox pb;
		private Label lbname;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private TreeView tvfemale;
		private TreeView tvmale;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FileSelect()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			Hashtable map = new Hashtable();

			CreateCategoryNodes(ref map, tvfemale, 1);
			CreateCategoryNodes(ref map, tvmale, 2);

			FillCategoryNodes(map);
		}

		/// <summary>
		/// Add the category Nodes to the Treeview
		/// </summary>
		/// <param name="map">a map that can be used to fill thenodes</param>
		/// <param name="tv">the TreeView to fill</param>
		void CreateCategoryNodes(ref Hashtable map, TreeView tv, uint gender)
		{
			Array cats = Enum.GetValues(typeof(Data.SkinCategories));
			Array ages = Enum.GetValues(typeof(Data.Ages));

			foreach (Data.Ages a in ages)
			{
				TreeNode node = new TreeNode(a.ToString());
				Hashtable catmap = (Hashtable)map[(uint)a];
				if (catmap == null)
				{
					catmap = new Hashtable();
					map[(uint)a] = catmap;
				}

				tv.Nodes.Add(node);

				foreach (Data.SkinCategories c in cats)
				{
					TreeNode catnode = new TreeNode(c.ToString());
					Hashtable list = (Hashtable)catmap[(uint)c];
					if (list == null)
					{
						list = new Hashtable();
						catmap[(uint)c] = list;
					}
					list[gender] = catnode;

					node.Nodes.Add(catnode);
				}
			}
		}

		void FillCategoryNodes(Hashtable mmap)
		{
			WaitingScreen.Wait();
			WaitingScreen.UpdateMessage("Loading File Table");
			try
			{
				FileTableBase.FileIndex.Load();
				System.Collections.Generic.IEnumerable<Interfaces.Scenegraph.IScenegraphFileIndexItem> items =
					FileTableBase.FileIndex.FindFile(Data.FileTypes.GZPS, true);
				WaitingScreen.UpdateMessage("Loading Clothing..");
				foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in items)
				{
					Cpf skin =
						new Cpf().ProcessFile(item);

					if (
						skin.GetSaveItem("type").StringValue == "skin"
						&& skin.GetSaveItem("species").UIntegerValue == 1
						&& skin.GetSaveItem("name").StringValue != ""
					)
					{
						// bool added = false;
						uint skinage = skin.GetSaveItem("age").UIntegerValue;
						uint skincat = skin.GetSaveItem("category").UIntegerValue;
						if (
							(skincat & (uint)Data.SkinCategories.Skin)
							== (uint)Data.SkinCategories.Skin
						)
						{
							skincat = (uint)Data.SkinCategories.Skin;
						}

						if (
							skincat != 128
							&& (
								skin.GetSaveItem("outfit").UIntegerValue == 1
								|| skin.GetSaveItem("parts").UIntegerValue == 1
							)
						)
						{
							skincat = (uint)Data.SkinCategories.Hair;
						}
						//if (skin.GetSaveItem("override0subset").StringValue.Trim().ToLower().StartsWith("hair")) skincat = (uint)Data.SkinCategories.Skin;
						//if (skin.GetSaveItem("override0subset").StringValue.Trim().ToLower().StartsWith("bang")) skincat = (uint)Data.SkinCategories.Skin; // these don't work
						uint skinsex = skin.GetSaveItem("gender").UIntegerValue;
						string name = skin.GetSaveItem("name").StringValue;
						foreach (uint age in mmap.Keys)
						{
							if ((age & skinage) == age)
							{
								Hashtable cats = (Hashtable)mmap[age];
								foreach (uint cat in cats.Keys)
								{
									if ((cat & skincat) == cat)
									{
										Hashtable sex = (Hashtable)cats[cat];
										foreach (uint g in sex.Keys)
										{
											if ((g & skinsex) == g)
											{
												TreeNode parent = (TreeNode)sex[g];
												TreeNode node = new TreeNode(name)
												{
													Tag = skin
												};
												parent.Nodes.Add(node);
												// added = true;
											}
										}
									}
								}
							}
						} //foreach age
					}
				}
			}
			finally
			{
				WaitingScreen.Stop();
			}
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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(FileSelect));
			button1 = new Button();
			tc = new TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tvfemale = new TreeView();
			tabPage2 = new System.Windows.Forms.TabPage();
			tvmale = new TreeView();
			pb = new PictureBox();
			lbname = new Label();
			tc.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pb).BeginInit();
			SuspendLayout();
			//
			// button1
			//
			button1.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			button1.FlatStyle = FlatStyle.System;
			button1.Location = new System.Drawing.Point(776, 579);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 1;
			button1.Text = "Use";
			button1.Click += new EventHandler(button1_Click);
			//
			// tc
			//
			tc.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tc.Controls.Add(tabPage1);
			tc.Controls.Add(tabPage2);
			tc.Location = new System.Drawing.Point(8, 8);
			tc.Name = "tc";
			tc.SelectedIndex = 0;
			tc.Size = new System.Drawing.Size(677, 595);
			tc.TabIndex = 2;
			//
			// tabPage1
			//
			tabPage1.Controls.Add(tvfemale);
			tabPage1.Location = new System.Drawing.Point(4, 22);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new System.Drawing.Size(669, 569);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Female";
			//
			// tvfemale
			//
			tvfemale.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tvfemale.BackColor = System.Drawing.Color.FromArgb(
				(byte)255,
				(byte)248,
				(byte)254
			);
			tvfemale.Font = new System.Drawing.Font(
				"Verdana",
				11.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tvfemale.HideSelection = false;
			tvfemale.Location = new System.Drawing.Point(8, 8);
			tvfemale.Name = "tvfemale";
			tvfemale.Size = new System.Drawing.Size(653, 555);
			tvfemale.TabIndex = 0;
			tvfemale.AfterSelect += new TreeViewEventHandler(
				Select
			);
			//
			// tabPage2
			//
			tabPage2.Controls.Add(tvmale);
			tabPage2.Location = new System.Drawing.Point(4, 22);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new System.Drawing.Size(669, 569);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Male";
			//
			// tvmale
			//
			tvmale.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tvmale.BackColor = System.Drawing.Color.FromArgb(
				(byte)248,
				(byte)252,
				(byte)255
			);
			tvmale.Font = new System.Drawing.Font(
				"Verdana",
				11.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tvmale.HideSelection = false;
			tvmale.Location = new System.Drawing.Point(8, 7);
			tvmale.Name = "tvmale";
			tvmale.Size = new System.Drawing.Size(653, 555);
			tvmale.TabIndex = 1;
			tvmale.AfterSelect += new TreeViewEventHandler(
				Select
			);
			//
			// pb
			//
			pb.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			pb.BorderStyle = BorderStyle.FixedSingle;
			pb.Location = new System.Drawing.Point(690, 8);
			pb.Name = "pb";
			pb.Size = new System.Drawing.Size(300, 300);
			pb.SizeMode = PictureBoxSizeMode.Zoom;
			pb.TabIndex = 3;
			pb.TabStop = false;
			//
			// lbname
			//
			lbname.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Bottom
						 | AnchorStyles.Right


			;
			lbname.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbname.Location = new System.Drawing.Point(690, 323);
			lbname.Name = "lbname";
			lbname.Size = new System.Drawing.Size(300, 253);
			lbname.TabIndex = 5;
			lbname.Text = "label1";
			//
			// FileSelect
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(994, 611);
			Controls.Add(lbname);
			Controls.Add(pb);
			Controls.Add(tc);
			Controls.Add(button1);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Name = "FileSelect";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Skin Select";
			tc.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pb).EndInit();
			ResumeLayout(false);
		}
		#endregion

		bool ok;

		static FileSelect form = null;

		public static Interfaces.Files.IPackedFileDescriptor Execute()
		{
			if (form == null)
			{
				form = new FileSelect();
			}

			return form.DoExecute();
		}

		TreeNode last;

		protected Interfaces.Files.IPackedFileDescriptor DoExecute()
		{
			lbname.Text = "";
			ok = false;
			last = null;
			button1.Enabled = false;
			ShowDialog();

			if (ok && (last != null))
			{
				Cpf cpf = (Cpf)
					last.Tag;
				return cpf.FileDescriptor;
			}

			return null;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ok = true;
			Close();
		}

		private void Select(object sender, TreeViewEventArgs e)
		{
			pb.Image = null;
			button1.Enabled = false;
			lbname.Text = "";
			last = null;
			if (e == null)
			{
				return;
			}

			if (e.Node == null)
			{
				return;
			}

			if (e.Node.Tag == null)
			{
				return;
			}

			button1.Enabled = true;
			last = e.Node;

			SkinChain sc = new SkinChain((Cpf)e.Node.Tag);
			GenericRcol rcol = sc.TXTR;

			if (rcol != null)
			{
				ImageData id = (ImageData)rcol.Blocks[0];
				MipMap mm = id.GetLargestTexture(pb.Size);
				if (mm != null)
				{
					pb.Image = ImageLoader.Preview(mm.Texture, pb.Size);
				}
			}

			lbname.Text = "Name: " + Helper.lbr + sc.Name + Helper.lbr + Helper.lbr;
			lbname.Text +=
				"Category: " + Helper.lbr + sc.CategoryNames + Helper.lbr + Helper.lbr;
			lbname.Text += "Age: " + Helper.lbr + sc.AgeNames + Helper.lbr + Helper.lbr;
			lbname.Text +=
				"Override: "
				+ Helper.lbr
				+ sc.Cpf.GetSaveItem("override0subset").StringValue
				+ Helper.lbr
				+ Helper.lbr;
			lbname.Text +=
				"Group: "
				+ Helper.lbr
				+ Helper.HexString(sc.Cpf.FileDescriptor.Group)
				+ Helper.lbr
				+ Helper.lbr;
		}
	}
}
