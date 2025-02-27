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

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NmapForm.
	/// </summary>
	public class NmapForm : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NmapForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			if (Helper.WindowsRegistry.UseBigIcons)
			{
				lblist.Font = new System.Drawing.Font(
					lblist.Font.FontFamily,
					11F
				);
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
				new System.ComponentModel.ComponentResourceManager(typeof(NmapForm));
			wrapperPanel = new Panel();
			groupBox1 = new GroupBox();
			linkLabel1 = new LinkLabel();
			tbfindname = new TextBox();
			label3 = new Label();
			btref = new Button();
			gbtypes = new GroupBox();
			pntypes = new Panel();
			tbname = new TextBox();
			label2 = new Label();
			lladd = new LinkLabel();
			lldelete = new LinkLabel();
			tbinstance = new TextBox();
			label11 = new Label();
			label9 = new Label();
			tbgroup = new TextBox();
			llcommit = new LinkLabel();
			lblist = new ListBox();
			panel3 = new Panel();
			sfd = new SaveFileDialog();
			wrapperPanel.SuspendLayout();
			groupBox1.SuspendLayout();
			gbtypes.SuspendLayout();
			pntypes.SuspendLayout();
			SuspendLayout();
			//
			// wrapperPanel
			//
			resources.ApplyResources(wrapperPanel, "wrapperPanel");
			wrapperPanel.BackColor = System.Drawing.Color.Transparent;
			wrapperPanel.Controls.Add(groupBox1);
			wrapperPanel.Controls.Add(btref);
			wrapperPanel.Controls.Add(gbtypes);
			wrapperPanel.Controls.Add(lblist);
			wrapperPanel.Controls.Add(panel3);
			wrapperPanel.Name = "wrapperPanel";
			//
			// groupBox1
			//
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.BackColor = System.Drawing.Color.Transparent;
			groupBox1.Controls.Add(linkLabel1);
			groupBox1.Controls.Add(tbfindname);
			groupBox1.Controls.Add(label3);
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			//
			// linkLabel1
			//
			resources.ApplyResources(linkLabel1, "linkLabel1");
			linkLabel1.Name = "linkLabel1";
			linkLabel1.TabStop = true;
			linkLabel1.UseCompatibleTextRendering = true;
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					CreateTextFile
				);
			//
			// tbfindname
			//
			resources.ApplyResources(tbfindname, "tbfindname");
			tbfindname.Name = "tbfindname";
			tbfindname.TextChanged += new EventHandler(
				tbfindname_TextChanged
			);
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// btref
			//
			resources.ApplyResources(btref, "btref");
			btref.Name = "btref";
			btref.Click += new EventHandler(ShowPackageSelector);
			//
			// gbtypes
			//
			resources.ApplyResources(gbtypes, "gbtypes");
			gbtypes.BackColor = System.Drawing.Color.Transparent;
			gbtypes.Controls.Add(pntypes);
			gbtypes.Name = "gbtypes";
			gbtypes.TabStop = false;
			//
			// pntypes
			//
			resources.ApplyResources(pntypes, "pntypes");
			pntypes.Controls.Add(tbname);
			pntypes.Controls.Add(label2);
			pntypes.Controls.Add(lladd);
			pntypes.Controls.Add(lldelete);
			pntypes.Controls.Add(tbinstance);
			pntypes.Controls.Add(label11);
			pntypes.Controls.Add(label9);
			pntypes.Controls.Add(tbgroup);
			pntypes.Controls.Add(llcommit);
			pntypes.Name = "pntypes";
			//
			// tbname
			//
			resources.ApplyResources(tbname, "tbname");
			tbname.Name = "tbname";
			tbname.TextChanged += new EventHandler(AutoChange);
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// lladd
			//
			resources.ApplyResources(lladd, "lladd");
			lladd.Name = "lladd";
			lladd.TabStop = true;
			lladd.UseCompatibleTextRendering = true;
			lladd.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(AddFile);
			//
			// lldelete
			//
			resources.ApplyResources(lldelete, "lldelete");
			lldelete.Name = "lldelete";
			lldelete.TabStop = true;
			lldelete.UseCompatibleTextRendering = true;
			lldelete.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					DeleteFile
				);
			//
			// tbinstance
			//
			resources.ApplyResources(tbinstance, "tbinstance");
			tbinstance.Name = "tbinstance";
			tbinstance.TextChanged += new EventHandler(AutoChange);
			//
			// label11
			//
			resources.ApplyResources(label11, "label11");
			label11.Name = "label11";
			//
			// label9
			//
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			//
			// tbgroup
			//
			resources.ApplyResources(tbgroup, "tbgroup");
			tbgroup.Name = "tbgroup";
			tbgroup.TextChanged += new EventHandler(AutoChange);
			//
			// llcommit
			//
			resources.ApplyResources(llcommit, "llcommit");
			llcommit.Name = "llcommit";
			llcommit.TabStop = true;
			llcommit.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					ChangeFile
				);
			//
			// lblist
			//
			lblist.AllowDrop = true;
			resources.ApplyResources(lblist, "lblist");
			lblist.Name = "lblist";
			lblist.SelectedIndexChanged += new EventHandler(
				SelectFile
			);
			lblist.DragDrop += new DragEventHandler(
				PackageItemDrop
			);
			lblist.DragEnter += new DragEventHandler(
				PackageItemDragEnter
			);
			//
			// panel3
			//
			resources.ApplyResources(panel3, "panel3");
			panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
			panel3.ForeColor = System.Drawing.Color.White;
			panel3.Name = "panel3";
			//
			// sfd
			//
			resources.ApplyResources(sfd, "sfd");
			//
			// NmapForm
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(wrapperPanel);
			Name = "NmapForm";
			wrapperPanel.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			gbtypes.ResumeLayout(false);
			pntypes.ResumeLayout(false);
			pntypes.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		internal Panel wrapperPanel;
		internal ListBox lblist;
		private Panel panel3;
		private GroupBox gbtypes;
		internal LinkLabel lladd;
		internal LinkLabel lldelete;
		internal TextBox tbinstance;
		private Label label11;
		private Label label9;
		internal TextBox tbgroup;
		internal LinkLabel llcommit;
		private Panel pntypes;
		private Label label2;
		internal TextBox tbname;
		private Button btref;
		private GroupBox groupBox1;
		internal TextBox tbfindname;
		private Label label3;
		internal LinkLabel linkLabel1;
		private SaveFileDialog sfd;

		internal Nmap wrapper;

		private void SelectFile(object sender, EventArgs e)
		{
			llcommit.Enabled = false;
			lldelete.Enabled = false;
			if (lblist.SelectedIndex < 0)
			{
				return;
			}

			llcommit.Enabled = true;
			lldelete.Enabled = true;

			if (tbgroup.Tag != null)
			{
				return;
			}

			try
			{
				tbgroup.Tag = true;
				Interfaces.Files.IPackedFileDescriptor pfd =
					(Interfaces.Files.IPackedFileDescriptor)
						lblist.Items[lblist.SelectedIndex];
				tbgroup.Text = "0x" + Helper.HexString(pfd.Group);
				tbinstance.Text = "0x" + Helper.HexString(pfd.Instance);
				tbname.Text = pfd.Filename;
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
				tbgroup.Tag = null;
			}
		}

		private void ChangeFile(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			try
			{
				Packages.PackedFileDescriptor pfd = null;
				if (lblist.SelectedIndex >= 0)
				{
					pfd = (Packages.PackedFileDescriptor)
						lblist.Items[lblist.SelectedIndex];
				}
				else
				{
					pfd = new NmapItem(wrapper);
				}

				pfd.Group = Convert.ToUInt32(tbgroup.Text, 16);
				pfd.Instance = Convert.ToUInt32(tbinstance.Text, 16);
				pfd.Filename = tbname.Text;

				if (lblist.SelectedIndex >= 0)
				{
					lblist.Items[lblist.SelectedIndex] = pfd;
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

		private void AddFile(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			lblist.SelectedIndex = -1;
			ChangeFile(null, null);
			lblist.SelectedIndex = lblist.Items.Count - 1;
		}

		private void DeleteFile(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			llcommit.Enabled = false;
			lldelete.Enabled = false;
			if (lblist.SelectedIndex < 0)
			{
				return;
			}

			llcommit.Enabled = true;
			lldelete.Enabled = true;

			lblist.Items.Remove(lblist.Items[lblist.SelectedIndex]);
		}

		private void AutoChange(object sender, EventArgs e)
		{
			if (tbgroup.Tag != null)
			{
				return;
			}

			tbgroup.Tag = true;
			if (lblist.SelectedIndex >= 0)
			{
				ChangeFile(null, null);
			}

			tbgroup.Tag = null;
		}

		private void CommitAll(object sender, EventArgs e)
		{
			try
			{
				Interfaces.Files.IPackedFileDescriptor[] pfds =
					new Interfaces.Files.IPackedFileDescriptor[lblist.Items.Count];
				for (int i = 0; i < pfds.Length; i++)
				{
					pfds[i] = (Interfaces.Files.IPackedFileDescriptor)lblist.Items[i];
				}

				wrapper.Items = pfds;
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

		#region Package Selector
		private void ShowPackageSelector(object sender, EventArgs e)
		{
			PackageSelectorForm form = new PackageSelectorForm();
			form.Execute(wrapper.Package);
		}

		private void PackageItemDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(Packages.PackedFileDescriptor)))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
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

				NmapItem nmi = new NmapItem(wrapper)
				{
					Group = pfd.Group,
					Type = pfd.Type,
					SubType = pfd.SubType,
					Instance = pfd.Instance,
					Filename = Data.MetaData.FindTypeAlias(pfd.Type).Name
				};
				lblist.Items.Add(nmi);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}
		#endregion

		private void tbfindname_TextChanged(object sender, EventArgs e)
		{
			string name = tbfindname.Text.Trim().ToLower();
			for (int i = 0; i < lblist.Items.Count; i++)
			{
				Packages.PackedFileDescriptor pfd = (Packages.PackedFileDescriptor)
					lblist.Items[i];
				if (pfd.Filename.Trim().ToLower().StartsWith(name))
				{
					tbfindname.Text = pfd.Filename.Trim();
					tbfindname.SelectionStart = name.Length;
					tbfindname.SelectionLength = Math.Max(
						0,
						tbfindname.Text.Length - name.Length
					);
					lblist.SelectedIndex = i;
					break;
				}
			}
		}

		private void CreateTextFile(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			sfd.FileName =
				System.IO.Path.GetFileNameWithoutExtension(wrapper.Package.FileName)
				+ "_NameMap.txt";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					System.IO.TextWriter tw = System.IO.File.CreateText(sfd.FileName);
					try
					{
						tw.WriteLine("Filename; " + "Group; " + "Instance; ");
						foreach (Packages.PackedFileDescriptor pfd in lblist.Items)
						{
							tw.WriteLine(
								pfd.Filename
									+ "; "
									+ "0x"
									+ Helper.HexString(pfd.Group)
									+ "; "
									+ "0x"
									+ Helper.HexString(pfd.Instance)
									+ "; "
							);
						}
					}
					finally
					{
						tw.Close();
						tw.Dispose();
						tw = null;
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage("", ex);
				}
			}
		}
	}
}
