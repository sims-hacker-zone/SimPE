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
				new System.ComponentModel.ComponentResourceManager(typeof(ImportSemi));
			btimport = new Button();
			cbsemi = new ComboBox();
			label1 = new Label();
			llscan = new LinkLabel();
			lbfiles = new CheckedListBox();
			label2 = new Label();
			linkLabel1 = new LinkLabel();
			cbfix = new CheckBox();
			toolTip1 = new ToolTip(components);
			cbname = new CheckBox();
			panel1 = new Panel();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// btimport
			//
			btimport.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			btimport.FlatStyle = FlatStyle.System;
			btimport.Location = new System.Drawing.Point(698, 471);
			btimport.Name = "btimport";
			btimport.Size = new System.Drawing.Size(75, 23);
			btimport.TabIndex = 1;
			btimport.Text = "Import";
			btimport.Click += new EventHandler(ImportFiles);
			//
			// cbsemi
			//
			cbsemi.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			cbsemi.DropDownStyle = ComboBoxStyle.DropDownList;
			cbsemi.Location = new System.Drawing.Point(16, 32);
			cbsemi.Name = "cbsemi";
			cbsemi.Size = new System.Drawing.Size(758, 24);
			cbsemi.TabIndex = 2;
			//
			// label1
			//
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(16, 6);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(100, 23);
			label1.TabIndex = 3;
			label1.Text = "Semi Global:";
			label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// llscan
			//
			llscan.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			llscan.AutoSize = true;
			llscan.BackColor = System.Drawing.Color.Transparent;
			llscan.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			llscan.Location = new System.Drawing.Point(730, 59);
			llscan.Name = "llscan";
			llscan.Size = new System.Drawing.Size(42, 16);
			llscan.TabIndex = 4;
			llscan.TabStop = true;
			llscan.Text = "scan";
			llscan.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					ScanSemiGlobals
				);
			//
			// lbfiles
			//
			lbfiles.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lbfiles.CheckOnClick = true;
			lbfiles.HorizontalScrollbar = true;
			lbfiles.IntegralHeight = false;
			lbfiles.Location = new System.Drawing.Point(16, 96);
			lbfiles.Name = "lbfiles";
			lbfiles.Size = new System.Drawing.Size(758, 365);
			lbfiles.TabIndex = 5;
			//
			// label2
			//
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(16, 70);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(100, 23);
			label2.TabIndex = 6;
			label2.Text = "Files:";
			label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// linkLabel1
			//
			linkLabel1.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			linkLabel1.AutoSize = true;
			linkLabel1.BackColor = System.Drawing.Color.Transparent;
			linkLabel1.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel1.Location = new System.Drawing.Point(16, 471);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(89, 16);
			linkLabel1.TabIndex = 7;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "uncheck all";
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel1_LinkClicked
				);
			//
			// cbfix
			//
			cbfix.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			cbfix.FlatStyle = FlatStyle.System;
			cbfix.Location = new System.Drawing.Point(506, 470);
			cbfix.Name = "cbfix";
			cbfix.Size = new System.Drawing.Size(176, 24);
			cbfix.TabIndex = 8;
			cbfix.Text = "Fix Package References";
			toolTip1.SetToolTip(
				cbfix,
				"Check this Option if you want to Fix references form TTABs and BHAVs in this pack"
					+ "age to the imported SemiGLobals."
			);
			//
			// cbname
			//
			cbname.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			cbname.FlatStyle = FlatStyle.System;
			cbname.Location = new System.Drawing.Point(362, 470);
			cbname.Name = "cbname";
			cbname.Size = new System.Drawing.Size(128, 24);
			cbname.TabIndex = 9;
			cbname.Text = "Add name Prefix";
			toolTip1.SetToolTip(
				cbname,
				"Check this Option if you want to Fix references form TTABs and BHAVs in this pack"
					+ "age to the imported SemiGLobals."
			);
			//
			// panel1
			//
			panel1.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			panel1.BackColor = System.Drawing.Color.Transparent;
			panel1.Controls.Add(lbfiles);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(cbname);
			panel1.Controls.Add(cbfix);
			panel1.Controls.Add(llscan);
			panel1.Controls.Add(linkLabel1);
			panel1.Controls.Add(cbsemi);
			panel1.Controls.Add(btimport);
			panel1.Controls.Add(label1);
			panel1.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(787, 503);
			panel1.TabIndex = 10;
			//
			// ImportSemi
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(784, 501);
			Controls.Add(panel1);
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
			Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			Name = "ImportSemi";
			Text = "Import SemiGlobals";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
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
			ShowDialog();
		}

		private void ScanSemiGlobals(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			Cursor = Cursors.WaitCursor;
			lbfiles.Items.Clear();
			btimport.Enabled = false;

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
				btimport.Enabled = (lbfiles.Items.Count > 0);
			}
			catch (Exception) { }

			Cursor = Cursors.Default;
		}

		private void ImportFiles(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

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
						new Packages.PackedFileDescriptor
						{
							Type = item.FileDescriptor.Type,
							Group = item.FileDescriptor.Group,
							Instance = item.FileDescriptor.Instance,
							SubType = item.FileDescriptor.SubType,
							UserData = item
						.Package.Read(item.FileDescriptor)
						.UncompressedData
						};
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
			Cursor = Cursors.Default;
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
