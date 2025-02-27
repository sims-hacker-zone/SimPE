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
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for MyPackedFileForm.
	/// </summary>
	public class RefFileForm : Form
	{
		internal Panel wrapperPanel;
		private Panel panel3;
		private Label label1;
		internal ListBox lblist;
		private GroupBox gbtypes;
		private Panel pntypes;
		internal TextBox tbsubtype;
		internal TextBox tbinstance;
		private Label label11;
		internal TextBox tbtype;
		private Label label8;
		private Label label9;
		private Label label10;
		internal TextBox tbgroup;
		internal ComboBox cbtypes;
		internal LinkLabel llcommit;
		internal LinkLabel lldelete;
		internal LinkLabel lladd;
		private Button button1;
		internal Button btup;
		internal Button btdown;
		private Button button4;
		private Button button2;
		internal PictureBox pb;
		private ContextMenu contextMenu1;
		private MenuItem miAdd;
		internal MenuItem miRem;
		private System.ComponentModel.IContainer components;
		internal System.Drawing.Image imge;

		public RefFileForm()
		{
			components = null;
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
			wrapperPanel = new Panel();
			pb = new PictureBox();
			button2 = new Button();
			button4 = new Button();
			btdown = new Button();
			btup = new Button();
			button1 = new Button();
			gbtypes = new GroupBox();
			pntypes = new Panel();
			lladd = new LinkLabel();
			lldelete = new LinkLabel();
			tbsubtype = new TextBox();
			tbinstance = new TextBox();
			label11 = new Label();
			tbtype = new TextBox();
			label8 = new Label();
			label9 = new Label();
			label10 = new Label();
			tbgroup = new TextBox();
			cbtypes = new ComboBox();
			llcommit = new LinkLabel();
			lblist = new ListBox();
			contextMenu1 = new ContextMenu();
			miAdd = new MenuItem();
			miRem = new MenuItem();
			panel3 = new Panel();
			label1 = new Label();
			wrapperPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(pb)).BeginInit();
			gbtypes.SuspendLayout();
			pntypes.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			//
			// wrapperPanel
			//
			wrapperPanel.AutoScroll = true;
			wrapperPanel.BackColor = System.Drawing.Color.Transparent;
			wrapperPanel.Controls.Add(pb);
			wrapperPanel.Controls.Add(button2);
			wrapperPanel.Controls.Add(button4);
			wrapperPanel.Controls.Add(btdown);
			wrapperPanel.Controls.Add(btup);
			wrapperPanel.Controls.Add(button1);
			wrapperPanel.Controls.Add(gbtypes);
			wrapperPanel.Controls.Add(lblist);
			wrapperPanel.Controls.Add(panel3);
			wrapperPanel.Location = new System.Drawing.Point(8, 8);
			wrapperPanel.Name = "wrapperPanel";
			wrapperPanel.Size = new System.Drawing.Size(664, 328);
			wrapperPanel.TabIndex = 3;
			//
			// pb
			//
			pb.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Right
					)

			;
			pb.BorderStyle = BorderStyle.FixedSingle;
			pb.ImeMode = ImeMode.NoControl;
			pb.Location = new System.Drawing.Point(240, 168);
			pb.Name = "pb";
			pb.Size = new System.Drawing.Size(152, 152);
			pb.SizeMode = PictureBoxSizeMode.Zoom;
			pb.TabIndex = 43;
			pb.TabStop = false;
			pb.SizeChanged += new EventHandler(pb_SizeChanged);
			//
			// button2
			//
			button2.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			button2.FlatStyle = FlatStyle.Popup;
			button2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			button2.ImeMode = ImeMode.NoControl;
			button2.Location = new System.Drawing.Point(320, 28);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(72, 21);
			button2.TabIndex = 42;
			button2.Text = "Package";
			button2.Click += new EventHandler(ShowPackageSelector);
			//
			// button4
			//
			button4.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			button4.FlatStyle = FlatStyle.Popup;
			button4.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			button4.ImeMode = ImeMode.NoControl;
			button4.Location = new System.Drawing.Point(288, 28);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(21, 21);
			button4.TabIndex = 41;
			button4.Text = "u";
			button4.Click += new EventHandler(ChooseFile);
			//
			// btdown
			//
			btdown.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			btdown.FlatStyle = FlatStyle.System;
			btdown.ImeMode = ImeMode.NoControl;
			btdown.Location = new System.Drawing.Point(176, 192);
			btdown.Name = "btdown";
			btdown.Size = new System.Drawing.Size(48, 23);
			btdown.TabIndex = 22;
			btdown.Text = "down";
			btdown.Click += new EventHandler(MoveDown);
			//
			// btup
			//
			btup.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			btup.FlatStyle = FlatStyle.System;
			btup.ImeMode = ImeMode.NoControl;
			btup.Location = new System.Drawing.Point(176, 168);
			btup.Name = "btup";
			btup.Size = new System.Drawing.Size(48, 23);
			btup.TabIndex = 21;
			btup.Text = "up";
			btup.Click += new EventHandler(MoveUp);
			//
			// button1
			//
			button1.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			button1.FlatStyle = FlatStyle.System;
			button1.ImeMode = ImeMode.NoControl;
			button1.Location = new System.Drawing.Point(176, 224);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(56, 23);
			button1.TabIndex = 20;
			button1.Text = "Commit";
			button1.Click += new EventHandler(CommitAll);
			//
			// gbtypes
			//
			gbtypes.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			gbtypes.Controls.Add(pntypes);
			gbtypes.FlatStyle = FlatStyle.System;
			gbtypes.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			gbtypes.Location = new System.Drawing.Point(176, 32);
			gbtypes.Name = "gbtypes";
			gbtypes.Size = new System.Drawing.Size(480, 128);
			gbtypes.TabIndex = 19;
			gbtypes.TabStop = false;
			gbtypes.Text = "File Properties";
			//
			// pntypes
			//
			pntypes.Controls.Add(lladd);
			pntypes.Controls.Add(lldelete);
			pntypes.Controls.Add(tbsubtype);
			pntypes.Controls.Add(tbinstance);
			pntypes.Controls.Add(label11);
			pntypes.Controls.Add(tbtype);
			pntypes.Controls.Add(label8);
			pntypes.Controls.Add(label9);
			pntypes.Controls.Add(label10);
			pntypes.Controls.Add(tbgroup);
			pntypes.Controls.Add(cbtypes);
			pntypes.Controls.Add(llcommit);
			pntypes.Location = new System.Drawing.Point(8, 24);
			pntypes.Name = "pntypes";
			pntypes.Size = new System.Drawing.Size(464, 96);
			pntypes.TabIndex = 19;
			//
			// lladd
			//
			lladd.AutoSize = true;
			lladd.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			lladd.ImeMode = ImeMode.NoControl;
			lladd.LinkArea = new LinkArea(0, 6);
			lladd.Location = new System.Drawing.Point(384, 80);
			lladd.Name = "lladd";
			lladd.Size = new System.Drawing.Size(28, 18);
			lladd.TabIndex = 19;
			lladd.TabStop = true;
			lladd.Text = "add";
			lladd.UseCompatibleTextRendering = true;
			lladd.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(AddFile);
			//
			// lldelete
			//
			lldelete.AutoSize = true;
			lldelete.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			lldelete.ImeMode = ImeMode.NoControl;
			lldelete.LinkArea = new LinkArea(0, 6);
			lldelete.Location = new System.Drawing.Point(416, 80);
			lldelete.Name = "lldelete";
			lldelete.Size = new System.Drawing.Size(48, 13);
			lldelete.TabIndex = 18;
			lldelete.TabStop = true;
			lldelete.Text = "delete";
			lldelete.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					DeleteFile
				);
			//
			// tbsubtype
			//
			tbsubtype.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F
			);
			tbsubtype.Location = new System.Drawing.Point(120, 24);
			tbsubtype.Name = "tbsubtype";
			tbsubtype.Size = new System.Drawing.Size(100, 20);
			tbsubtype.TabIndex = 12;
			tbsubtype.TextChanged += new EventHandler(AutoChange);
			//
			// tbinstance
			//
			tbinstance.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F
			);
			tbinstance.Location = new System.Drawing.Point(120, 72);
			tbinstance.Name = "tbinstance";
			tbinstance.Size = new System.Drawing.Size(100, 20);
			tbinstance.TabIndex = 14;
			tbinstance.TextChanged += new EventHandler(AutoChange);
			//
			// label11
			//
			label11.Font = new System.Drawing.Font("Verdana", 8.25F);
			label11.ImeMode = ImeMode.NoControl;
			label11.Location = new System.Drawing.Point(0, 72);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(112, 17);
			label11.TabIndex = 10;
			label11.Text = "Instance:";
			label11.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbtype
			//
			tbtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			tbtype.Location = new System.Drawing.Point(120, 0);
			tbtype.Name = "tbtype";
			tbtype.Size = new System.Drawing.Size(100, 20);
			tbtype.TabIndex = 11;
			tbtype.TextChanged += new EventHandler(tbtype_TextChanged);
			//
			// label8
			//
			label8.Font = new System.Drawing.Font("Verdana", 8.25F);
			label8.ImeMode = ImeMode.NoControl;
			label8.Location = new System.Drawing.Point(0, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(112, 17);
			label8.TabIndex = 7;
			label8.Text = "File Type:";
			label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label9
			//
			label9.Font = new System.Drawing.Font("Verdana", 8.25F);
			label9.ImeMode = ImeMode.NoControl;
			label9.Location = new System.Drawing.Point(0, 24);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(112, 17);
			label9.TabIndex = 8;
			label9.Text = "SubType/Class ID:";
			label9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label10
			//
			label10.Font = new System.Drawing.Font("Verdana", 8.25F);
			label10.ImeMode = ImeMode.NoControl;
			label10.Location = new System.Drawing.Point(0, 48);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(112, 17);
			label10.TabIndex = 9;
			label10.Text = "Group:";
			label10.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbgroup
			//
			tbgroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			tbgroup.Location = new System.Drawing.Point(120, 48);
			tbgroup.Name = "tbgroup";
			tbgroup.Size = new System.Drawing.Size(100, 20);
			tbgroup.TabIndex = 13;
			tbgroup.TextChanged += new EventHandler(AutoChange);
			//
			// cbtypes
			//
			cbtypes.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbtypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			cbtypes.ItemHeight = 13;
			cbtypes.Location = new System.Drawing.Point(224, 0);
			cbtypes.Name = "cbtypes";
			cbtypes.Size = new System.Drawing.Size(240, 21);
			cbtypes.Sorted = true;
			cbtypes.TabIndex = 16;
			cbtypes.SelectedIndexChanged += new EventHandler(
				SelectType
			);
			//
			// llcommit
			//
			llcommit.AutoSize = true;
			llcommit.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold
			);
			llcommit.ImeMode = ImeMode.NoControl;
			llcommit.LinkArea = new LinkArea(0, 6);
			llcommit.Location = new System.Drawing.Point(328, 80);
			llcommit.Name = "llcommit";
			llcommit.Size = new System.Drawing.Size(54, 13);
			llcommit.TabIndex = 17;
			llcommit.TabStop = true;
			llcommit.Text = "change";
			llcommit.Visible = false;
			llcommit.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					ChangeFile
				);
			//
			// lblist
			//
			lblist.AllowDrop = true;
			lblist.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lblist.ContextMenu = contextMenu1;
			lblist.HorizontalScrollbar = true;
			lblist.IntegralHeight = false;
			lblist.Location = new System.Drawing.Point(8, 32);
			lblist.Name = "lblist";
			lblist.Size = new System.Drawing.Size(160, 288);
			lblist.TabIndex = 1;
			lblist.DragDrop += new DragEventHandler(
				PackageItemDrop
			);
			lblist.DragEnter += new DragEventHandler(
				PackageItemDragEnter
			);
			lblist.SelectedIndexChanged += new EventHandler(
				SelectFile
			);
			//
			// contextMenu1
			//
			contextMenu1.MenuItems.AddRange(
				new MenuItem[] { miAdd, miRem }
			);
			//
			// miAdd
			//
			miAdd.Index = 0;
			miAdd.Text = "&Add";
			miAdd.Click += new EventHandler(miAdd_Click);
			//
			// miRem
			//
			miRem.Index = 1;
			miRem.Text = "&Delete";
			miRem.Click += new EventHandler(menuItem1_Click);
			//
			// panel3
			//
			panel3.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
			panel3.Controls.Add(label1);
			panel3.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold
			);
			panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel3.Location = new System.Drawing.Point(0, 0);
			panel3.Margin = new Padding(0);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(664, 24);
			panel3.TabIndex = 0;
			//
			// label1
			//
			label1.AutoSize = true;
			label1.ImeMode = ImeMode.NoControl;
			label1.Location = new System.Drawing.Point(0, 4);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(201, 19);
			label1.TabIndex = 0;
			label1.Text = "3D Referencing File Editor";
			//
			// RefFileForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(856, 350);
			Controls.Add(wrapperPanel);
			Font = new System.Drawing.Font("Verdana", 8.25F);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "RefFileForm";
			Text = "MyPackedFileForm";
			WindowState = FormWindowState.Maximized;
			wrapperPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(pb)).EndInit();
			gbtypes.ResumeLayout(false);
			pntypes.ResumeLayout(false);
			panel3.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion


		/// <summary>
		/// Stores the currently active Wrapper
		/// </summary>
		internal IFileWrapperSaveExtension wrapper = null;

		private void SelectType(object sender, EventArgs e)
		{
			if (cbtypes.Tag != null)
			{
				return;
			}

			tbtype.Text =
				"0x"
				+ Helper.HexString(
					((Data.TypeAlias)cbtypes.Items[cbtypes.SelectedIndex]).Id
				);
		}

		private void tbtype_TextChanged(object sender, EventArgs e)
		{
			cbtypes.Tag = true;
			Data.TypeAlias a = Data.MetaData.FindTypeAlias(
				Helper.HexStringToUInt(tbtype.Text)
			);

			AutoChange(sender, e);
			int ct = 0;
			foreach (Data.TypeAlias i in cbtypes.Items)
			{
				if (i == a)
				{
					cbtypes.SelectedIndex = ct;
					cbtypes.Tag = null;
					return;
				}
				ct++;
			}

			cbtypes.SelectedIndex = -1;
			cbtypes.Tag = null;
		}

		private void SelectFile(object sender, EventArgs e)
		{
			if (lblist.SelectedIndex < 0)
			{
				llcommit.Enabled =
					lldelete.Enabled =
					btup.Enabled =
					btdown.Enabled =
					miAdd.Enabled =
					miRem.Enabled =
						false;
				return;
			}
			llcommit.Enabled =
				lldelete.Enabled =
				btup.Enabled =
				btdown.Enabled =
				miAdd.Enabled =
				miRem.Enabled =
					true;

			if (tbtype.Tag != null)
			{
				return;
			}

			try
			{
				tbtype.Tag = true;
				Interfaces.Files.IPackedFileDescriptor pfd =
					(Interfaces.Files.IPackedFileDescriptor)
						lblist.Items[lblist.SelectedIndex];
				tbgroup.Text = "0x" + Helper.HexString(pfd.Group);
				tbinstance.Text = "0x" + Helper.HexString(pfd.Instance);
				tbsubtype.Text = "0x" + Helper.HexString(pfd.SubType);
				tbtype.Text = "0x" + Helper.HexString(pfd.Type);

				//get Texture
				if (pfd.GetType() == typeof(RefFileItem))
				{
					RefFile wrp = (RefFile)wrapper;
					SkinChain sc = ((RefFileItem)pfd).Skin;
					GenericRcol txtr = null;
					if (sc != null)
					{
						txtr = sc.TXTR;
					}

					//show the Image
					if (txtr == null)
					{
						pb.Image = imge;
					}
					else
					{
						MipMap mm = ((ImageData)txtr.Blocks[0]).GetLargestTexture(
							pb.Size
						);
						pb.Image = mm != null ? mm.Texture : imge;
					}
				}
				else
				{
					pb.Image = imge;
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
			finally
			{
				tbtype.Tag = null;
			}
		}

		private void ChangeFile(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			try
			{
				Packages.PackedFileDescriptor pfd = lblist.SelectedIndex >= 0
					? (Packages.PackedFileDescriptor)
						lblist.Items[lblist.SelectedIndex]
					: new Packages.PackedFileDescriptor();

				pfd.Group = Convert.ToUInt32(tbgroup.Text, 16);
				pfd.Instance = Convert.ToUInt32(tbinstance.Text, 16);
				pfd.SubType = Convert.ToUInt32(tbsubtype.Text, 16);
				pfd.Type = Convert.ToUInt32(tbtype.Text, 16);

				if (lblist.SelectedIndex >= 0)
				{
					lblist.Items[lblist.SelectedIndex] = pfd;
					try
					{
						RefFileItem rfi = (RefFileItem)pfd;
						rfi.Skin = null;
					}
					catch { }
				}
				else
				{
					lblist.Items.Add(pfd);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
		}

		private void DeleteFile(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			llcommit.Enabled = false;
			lldelete.Enabled = false;
			btup.Enabled = false;
			btdown.Enabled = false;
			miRem.Enabled = lldelete.Enabled;
			if (lblist.SelectedIndex < 0)
			{
				return;
			}

			llcommit.Enabled = true;
			lldelete.Enabled = true;
			btup.Enabled = true;
			btdown.Enabled = true;
			miRem.Enabled = lldelete.Enabled;

			lblist.Items.Remove(lblist.Items[lblist.SelectedIndex]);
		}

		private void AddFile(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			lblist.SelectedIndex = -1;
			ChangeFile(null, null);
			lblist.SelectedIndex = lblist.Items.Count - 1;
		}

		private void CommitAll(object sender, EventArgs e)
		{
			try
			{
				RefFile wrp = (RefFile)wrapper;

				Interfaces.Files.IPackedFileDescriptor[] pfds =
					new Interfaces.Files.IPackedFileDescriptor[lblist.Items.Count];
				for (int i = 0; i < pfds.Length; i++)
				{
					pfds[i] = (Interfaces.Files.IPackedFileDescriptor)lblist.Items[i];
				}

				wrp.Items = pfds;
				wrapper.SynchronizeUserData();
				MessageBox.Show(Localization.Manager.GetString("commited"));
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errwritingfile"),
					ex
				);
			}
		}

		private void MoveUp(object sender, EventArgs e)
		{
			if (lblist.SelectedIndex < 1)
			{
				return;
			}

			Interfaces.Files.IPackedFileDescriptor pfd =
				(Interfaces.Files.IPackedFileDescriptor)
					lblist.Items[lblist.SelectedIndex];
			lblist.Items[lblist.SelectedIndex] = lblist.Items[lblist.SelectedIndex - 1];
			lblist.Items[lblist.SelectedIndex - 1] = pfd;
			lblist.SelectedIndex--;
		}

		private void MoveDown(object sender, EventArgs e)
		{
			if (lblist.SelectedIndex < 0)
			{
				return;
			}

			if (lblist.SelectedIndex > lblist.Items.Count - 2)
			{
				return;
			}

			Interfaces.Files.IPackedFileDescriptor pfd =
				(Interfaces.Files.IPackedFileDescriptor)
					lblist.Items[lblist.SelectedIndex];
			lblist.Items[lblist.SelectedIndex] = lblist.Items[lblist.SelectedIndex + 1];
			lblist.Items[lblist.SelectedIndex + 1] = pfd;
			lblist.SelectedIndex++;
		}

		private void AutoChange(object sender, EventArgs e)
		{
			if (tbtype.Tag != null)
			{
				return;
			}

			tbtype.Tag = true;
			if (lblist.SelectedIndex >= 0)
			{
				ChangeFile(null, null);
			}

			tbtype.Tag = null;
		}

		private void ChooseFile(object sender, EventArgs e)
		{
			try
			{
				RefFile wrp = (RefFile)wrapper;
				Interfaces.Files.IPackedFileDescriptor pfd = FileSelect.Execute();
				if (pfd != null)
				{
					tbtype.Tag = true;
					tbgroup.Text = "0x" + Helper.HexString(pfd.Group);
					tbinstance.Text = "0x" + Helper.HexString(pfd.Instance);
					tbsubtype.Text = "0x" + Helper.HexString(pfd.SubType);
					tbtype.Text = "0x" + Helper.HexString(pfd.Type);
					tbtype.Tag = null;
					AutoChange(sender, e);
				}
			}
			catch (Exception) { }
			finally
			{
				tbtype.Tag = null;
			}
		}

		#region Package Selector
		private void ShowPackageSelector(object sender, EventArgs e)
		{
			PackageSelectorForm form = new PackageSelectorForm();
			form.Execute(((RefFile)wrapper).Package);
		}

		private void PackageItemDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.Data.GetDataPresent(typeof(Packages.PackedFileDescriptor)) ? DragDropEffects.Copy : DragDropEffects.None;
		}

		private void PackageItemDrop(
			object sender,
			DragEventArgs e
		)
		{
			try
			{
				Interfaces.Files.IPackedFileDescriptor pfd = null;
				pfd = (Interfaces.Files.IPackedFileDescriptor)
					e.Data.GetData(typeof(Packages.PackedFileDescriptor));
				lblist.Items.Add(pfd);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}
		#endregion

		private void pb_SizeChanged(object sender, EventArgs e)
		{
			pb.Width = pb.Height < 421 ? pb.Height : 420;
		}

		private void miAdd_Click(object sender, EventArgs e)
		{
			AddFile(null, null);
		}

		private void menuItem1_Click(object sender, EventArgs e)
		{
			DeleteFile(null, null);
		}
	}
}
