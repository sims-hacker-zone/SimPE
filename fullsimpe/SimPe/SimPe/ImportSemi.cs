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
using System.Windows.Forms;

namespace SimPe
{
	/// <summary>
	/// Summary description for ImportSemi.
	/// </summary>
	public class ImportSemi : Form
	{
		private Button btimport;
		private ComboBox cbsemi;
		private Label label1;
		private LinkLabel llscan;
		private CheckedListBox lbfiles;
		private Label label2;
		private LinkLabel linkLabel1;
		private CheckBox cbfix;
		private ToolTip toolTip1;
		private CheckBox cbname;
		private Panel panel1;
		private System.ComponentModel.IContainer components;

		public ImportSemi()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			WaitingScreen.Wait();
			try
			{
				WaitingScreen.UpdateMessage("getting all SemiGlobal Groups");
				FileTableBase.FileIndex.Load();

				Interfaces.Scenegraph.IScenegraphFileIndexItem[] globs =
					FileTableBase.FileIndex.FindFile(Data.MetaData.GLOB_FILE, true);
				ArrayList names = new ArrayList();
				string max = " / " + globs.Length.ToString();
				int ct = 0;
				foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in globs)
				{
					if (ct % 17 == 0)
					{
						WaitingScreen.UpdateMessage(ct.ToString() + max);
					}

					ct++;

					Plugin.NamedGlob glob = new Plugin.NamedGlob();
					glob.ProcessData(item.FileDescriptor, item.Package);

					if (!names.Contains(glob.SemiGlobalName.Trim().ToLower()))
					{
						cbsemi.Items.Add(glob);
						names.Add(glob.SemiGlobalName.Trim().ToLower());
					}
				}
				cbsemi.Sorted = true;
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
				new System.ComponentModel.ComponentResourceManager(typeof(ImportSemi));
			this.btimport = new Button();
			this.cbsemi = new ComboBox();
			this.label1 = new Label();
			this.llscan = new LinkLabel();
			this.lbfiles = new CheckedListBox();
			this.label2 = new Label();
			this.linkLabel1 = new LinkLabel();
			this.cbfix = new CheckBox();
			this.toolTip1 = new ToolTip(this.components);
			this.cbname = new CheckBox();
			this.panel1 = new Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			//
			// btimport
			//
			this.btimport.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			this.btimport.FlatStyle = FlatStyle.System;
			this.btimport.Location = new System.Drawing.Point(698, 471);
			this.btimport.Name = "btimport";
			this.btimport.Size = new System.Drawing.Size(75, 23);
			this.btimport.TabIndex = 1;
			this.btimport.Text = "Import";
			this.btimport.Click += new EventHandler(this.ImportFiles);
			//
			// cbsemi
			//
			this.cbsemi.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.cbsemi.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbsemi.Location = new System.Drawing.Point(16, 32);
			this.cbsemi.Name = "cbsemi";
			this.cbsemi.Size = new System.Drawing.Size(758, 24);
			this.cbsemi.TabIndex = 2;
			//
			// label1
			//
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label1.Location = new System.Drawing.Point(16, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Semi Global:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// llscan
			//
			this.llscan.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			this.llscan.AutoSize = true;
			this.llscan.BackColor = System.Drawing.Color.Transparent;
			this.llscan.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.llscan.Location = new System.Drawing.Point(730, 59);
			this.llscan.Name = "llscan";
			this.llscan.Size = new System.Drawing.Size(42, 16);
			this.llscan.TabIndex = 4;
			this.llscan.TabStop = true;
			this.llscan.Text = "scan";
			this.llscan.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.ScanSemiGlobals
				);
			//
			// lbfiles
			//
			this.lbfiles.Anchor = (
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
			this.lbfiles.CheckOnClick = true;
			this.lbfiles.HorizontalScrollbar = true;
			this.lbfiles.IntegralHeight = false;
			this.lbfiles.Location = new System.Drawing.Point(16, 96);
			this.lbfiles.Name = "lbfiles";
			this.lbfiles.Size = new System.Drawing.Size(758, 365);
			this.lbfiles.TabIndex = 5;
			//
			// label2
			//
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label2.Location = new System.Drawing.Point(16, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Files:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// linkLabel1
			//
			this.linkLabel1.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)
				)
			);
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel1.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.linkLabel1.Location = new System.Drawing.Point(16, 471);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(89, 16);
			this.linkLabel1.TabIndex = 7;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "uncheck all";
			this.linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.linkLabel1_LinkClicked
				);
			//
			// cbfix
			//
			this.cbfix.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			this.cbfix.FlatStyle = FlatStyle.System;
			this.cbfix.Location = new System.Drawing.Point(506, 470);
			this.cbfix.Name = "cbfix";
			this.cbfix.Size = new System.Drawing.Size(176, 24);
			this.cbfix.TabIndex = 8;
			this.cbfix.Text = "Fix Package References";
			this.toolTip1.SetToolTip(
				this.cbfix,
				"Check this Option if you want to Fix references form TTABs and BHAVs in this pack"
					+ "age to the imported SemiGLobals."
			);
			//
			// cbname
			//
			this.cbname.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)
				)
			);
			this.cbname.FlatStyle = FlatStyle.System;
			this.cbname.Location = new System.Drawing.Point(362, 470);
			this.cbname.Name = "cbname";
			this.cbname.Size = new System.Drawing.Size(128, 24);
			this.cbname.TabIndex = 9;
			this.cbname.Text = "Add name Prefix";
			this.toolTip1.SetToolTip(
				this.cbname,
				"Check this Option if you want to Fix references form TTABs and BHAVs in this pack"
					+ "age to the imported SemiGLobals."
			);
			//
			// panel1
			//
			this.panel1.Anchor = (
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
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.lbfiles);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.cbname);
			this.panel1.Controls.Add(this.cbfix);
			this.panel1.Controls.Add(this.llscan);
			this.panel1.Controls.Add(this.linkLabel1);
			this.panel1.Controls.Add(this.cbsemi);
			this.panel1.Controls.Add(this.btimport);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(787, 503);
			this.panel1.TabIndex = 10;
			//
			// ImportSemi
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(784, 501);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ImportSemi";
			this.Text = "Import SemiGlobals";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		Interfaces.Files.IPackageFile package;
		Interfaces.IWrapperRegistry reg;
		Interfaces.IProviderRegistry prov;

		public void Execute(
			Interfaces.Files.IPackageFile package,
			Interfaces.IWrapperRegistry reg,
			Interfaces.IProviderRegistry prov
		)
		{
			this.package = package;
			this.reg = reg;
			this.prov = prov;

			btimport.Enabled = false;
			lbfiles.Items.Clear();
			this.ShowDialog();
		}

		private void ScanSemiGlobals(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			this.Cursor = Cursors.WaitCursor;
			lbfiles.Items.Clear();
			this.btimport.Enabled = false;

			if (cbsemi.SelectedIndex < 0)
			{
				return;
			}

			ArrayList loaded = new ArrayList();

			try
			{
				Plugin.NamedGlob glob = (Plugin.NamedGlob)
					cbsemi.Items[cbsemi.SelectedIndex];
				Interfaces.Scenegraph.IScenegraphFileIndexItem[] items =
					FileTableBase.FileIndex.FindFileByGroup(glob.SemiGlobalGroup);

				lbfiles.Sorted = false;
				foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in items)
				{
					if (item.FileDescriptor.Type == Data.MetaData.BHAV_FILE)
					{
						Plugin.Bhav bhav = new Plugin.Bhav(null);
						bhav.ProcessData(item);
						item.FileDescriptor.Filename =
							item.FileDescriptor.TypeName.shortname
							+ ": "
							+ bhav.FileName
							+ " ("
							+ item.FileDescriptor.ToString()
							+ ")";
					}
					else if (item.FileDescriptor.Type == Data.MetaData.STRING_FILE)
					{
						PackedFiles.Wrapper.Str str =
							new PackedFiles.Wrapper.Str();
						str.ProcessData(item);
						item.FileDescriptor.Filename =
							item.FileDescriptor.TypeName.shortname
							+ ": "
							+ str.FileName
							+ " ("
							+ item.FileDescriptor.ToString()
							+ ")";
					}
					else if (item.FileDescriptor.Type == 0x42434F4E) //BCON
					{
						Plugin.Bcon bcon = new Plugin.Bcon();
						bcon.ProcessData(item);
						item.FileDescriptor.Filename =
							item.FileDescriptor.TypeName.shortname
							+ ": "
							+ bcon.FileName
							+ " ("
							+ item.FileDescriptor.ToString()
							+ ")";
					}
					else
					{
						item.FileDescriptor.Filename = item.FileDescriptor.ToString();
					}

					if (!loaded.Contains(item.FileDescriptor))
					{
						lbfiles.Items.Add(
							item,
							(
								(item.FileDescriptor.Type == Data.MetaData.BHAV_FILE)
								|| (item.FileDescriptor.Type == 0x42434F4E)
							)
						);
						loaded.Add(item.FileDescriptor);
					}
				}
				lbfiles.Sorted = true;
				this.btimport.Enabled = (lbfiles.Items.Count > 0);
			}
			catch (Exception) { }

			this.Cursor = Cursors.Default;
		}

		private void ImportFiles(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			//first find the highest Instance of a BHAV, BCON in the package
			Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFiles(
				Data.MetaData.BHAV_FILE
			);
			uint maxbhavinst = 0x1000;
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				if ((pfd.Instance < 0x2000) && (pfd.Instance > maxbhavinst))
				{
					maxbhavinst = pfd.Instance;
				}
			}

			Hashtable bhavalias = new Hashtable();
			maxbhavinst++;

			//her is the BCOn part
			pfds = package.FindFiles(0x42434F4E);
			uint maxbconinst = 0x1000;
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				if ((pfd.Instance < 0x2000) && (pfd.Instance > maxbconinst))
				{
					maxbconinst = pfd.Instance;
				}
			}

			Hashtable bconalias = new Hashtable();
			maxbconinst++;

			ArrayList bhavs = new ArrayList();
			ArrayList ttabs = new ArrayList();
			package.BeginUpdate();
			try
			{
				for (int i = 0; i < lbfiles.Items.Count; i++)
				{
					if (!lbfiles.GetItemChecked(i))
					{
						continue;
					}

					Interfaces.Scenegraph.IScenegraphFileIndexItem item =
						(Interfaces.Scenegraph.IScenegraphFileIndexItem)
							lbfiles.Items[i];
					Packages.PackedFileDescriptor npfd =
						new Packages.PackedFileDescriptor();
					npfd.Type = item.FileDescriptor.Type;
					npfd.Group = item.FileDescriptor.Group;
					npfd.Instance = item.FileDescriptor.Instance;
					npfd.SubType = item.FileDescriptor.SubType;
					npfd.UserData = item
						.Package.Read(item.FileDescriptor)
						.UncompressedData;
					package.Add(npfd);

					if (npfd.Type == Data.MetaData.BHAV_FILE)
					{
						maxbhavinst++;
						npfd.Group = 0xffffffff;
						bhavalias[(ushort)npfd.Instance] = (ushort)maxbhavinst;
						npfd.Instance = maxbhavinst;

						Plugin.Bhav bhav = new Plugin.Bhav(
							prov.OpcodeProvider
						);
						bhav.ProcessData(npfd, package);
						if (cbname.Checked)
						{
							bhav.FileName = "[" + cbsemi.Text + "] " + bhav.FileName;
						}

						bhav.SynchronizeUserData();

						bhavs.Add(bhav);
					}
					else if (npfd.Type == 0x42434F4E) //BCON
					{
						npfd.Instance = maxbconinst++;
						npfd.Group = 0xffffffff;
						bconalias[(ushort)npfd.Instance] = (ushort)npfd.Instance;

						Plugin.Bcon bcon = new Plugin.Bcon();
						bcon.ProcessData(npfd, package);
						if (cbname.Checked)
						{
							bcon.FileName = "[" + cbsemi.Text + "] " + bcon.FileName;
						}

						bcon.SynchronizeUserData();
					}
					else if (npfd.Type == 0x54544142) //TTAB
					{
						Plugin.Ttab ttab = new Plugin.Ttab(
							prov.OpcodeProvider
						);
						ttab.ProcessData(npfd, package);

						ttabs.Add(ttab);
					}
				}

				if (cbfix.Checked)
				{
					pfds = package.FindFiles(Data.MetaData.BHAV_FILE);
					foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
					{
						Plugin.Bhav bhav = new Plugin.Bhav(
							prov.OpcodeProvider
						);
						bhav.ProcessData(pfd, package);

						bhavs.Add(bhav);
					}

					pfds = package.FindFiles(0x54544142);
					foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
					{
						Plugin.Ttab ttab = new Plugin.Ttab(
							prov.OpcodeProvider
						);
						ttab.ProcessData(pfd, package);

						ttabs.Add(ttab);
					}
				}

				//Relink all SemiGlobals in imported BHAV's
				foreach (Plugin.Bhav bhav in bhavs)
				{
					foreach (PackedFiles.Wrapper.Instruction i in bhav)
					{
						if (bhavalias.Contains(i.OpCode))
						{
							i.OpCode = (ushort)bhavalias[i.OpCode];
						}
					}
					bhav.SynchronizeUserData();
				}

				//Relink all TTAbs
				foreach (Plugin.Ttab ttab in ttabs)
				{
					foreach (PackedFiles.Wrapper.TtabItem item in ttab)
					{
						if (bhavalias.Contains(item.Guardian))
						{
							item.Guardian = (ushort)bhavalias[item.Guardian];
						}

						if (bhavalias.Contains(item.Action))
						{
							item.Action = (ushort)bhavalias[item.Action];
						}
					}
					ttab.SynchronizeUserData();
				}
			}
			finally
			{
				package.EndUpdate();
			}
			this.Cursor = Cursors.Default;
			Close();
		}

		private void linkLabel1_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			for (int i = 0; i < lbfiles.Items.Count; i++)
			{
				lbfiles.SetItemChecked(i, false);
			}
		}
	}
}
