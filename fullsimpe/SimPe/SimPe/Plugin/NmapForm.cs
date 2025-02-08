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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NmapForm.
	/// </summary>
	public class NmapForm : System.Windows.Forms.Form
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

			if (Helper.WindowsRegistry.UseBigIcons) this.lblist.Font = new System.Drawing.Font(this.lblist.Font.FontFamily, 11F);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NmapForm));
			this.wrapperPanel = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.tbfindname = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btref = new System.Windows.Forms.Button();
			this.gbtypes = new System.Windows.Forms.GroupBox();
			this.pntypes = new System.Windows.Forms.Panel();
			this.tbname = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lladd = new System.Windows.Forms.LinkLabel();
			this.lldelete = new System.Windows.Forms.LinkLabel();
			this.tbinstance = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tbgroup = new System.Windows.Forms.TextBox();
			this.llcommit = new System.Windows.Forms.LinkLabel();
			this.lblist = new System.Windows.Forms.ListBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.wrapperPanel.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gbtypes.SuspendLayout();
			this.pntypes.SuspendLayout();
			this.SuspendLayout();
			// 
			// wrapperPanel
			// 
			resources.ApplyResources(this.wrapperPanel, "wrapperPanel");
			this.wrapperPanel.BackColor = System.Drawing.Color.Transparent;
			this.wrapperPanel.Controls.Add(this.groupBox1);
			this.wrapperPanel.Controls.Add(this.btref);
			this.wrapperPanel.Controls.Add(this.gbtypes);
			this.wrapperPanel.Controls.Add(this.lblist);
			this.wrapperPanel.Controls.Add(this.panel3);
			this.wrapperPanel.Name = "wrapperPanel";
			// 
			// groupBox1
			// 
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.linkLabel1);
			this.groupBox1.Controls.Add(this.tbfindname);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// linkLabel1
			// 
			resources.ApplyResources(this.linkLabel1, "linkLabel1");
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabStop = true;
			this.linkLabel1.UseCompatibleTextRendering = true;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateTextFile);
			// 
			// tbfindname
			// 
			resources.ApplyResources(this.tbfindname, "tbfindname");
			this.tbfindname.Name = "tbfindname";
			this.tbfindname.TextChanged += new System.EventHandler(this.tbfindname_TextChanged);
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// btref
			// 
			resources.ApplyResources(this.btref, "btref");
			this.btref.Name = "btref";
			this.btref.Click += new System.EventHandler(this.ShowPackageSelector);
			// 
			// gbtypes
			// 
			resources.ApplyResources(this.gbtypes, "gbtypes");
			this.gbtypes.BackColor = System.Drawing.Color.Transparent;
			this.gbtypes.Controls.Add(this.pntypes);
			this.gbtypes.Name = "gbtypes";
			this.gbtypes.TabStop = false;
			// 
			// pntypes
			// 
			resources.ApplyResources(this.pntypes, "pntypes");
			this.pntypes.Controls.Add(this.tbname);
			this.pntypes.Controls.Add(this.label2);
			this.pntypes.Controls.Add(this.lladd);
			this.pntypes.Controls.Add(this.lldelete);
			this.pntypes.Controls.Add(this.tbinstance);
			this.pntypes.Controls.Add(this.label11);
			this.pntypes.Controls.Add(this.label9);
			this.pntypes.Controls.Add(this.tbgroup);
			this.pntypes.Controls.Add(this.llcommit);
			this.pntypes.Name = "pntypes";
			// 
			// tbname
			// 
			resources.ApplyResources(this.tbname, "tbname");
			this.tbname.Name = "tbname";
			this.tbname.TextChanged += new System.EventHandler(this.AutoChange);
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// lladd
			// 
			resources.ApplyResources(this.lladd, "lladd");
			this.lladd.Name = "lladd";
			this.lladd.TabStop = true;
			this.lladd.UseCompatibleTextRendering = true;
			this.lladd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddFile);
			// 
			// lldelete
			// 
			resources.ApplyResources(this.lldelete, "lldelete");
			this.lldelete.Name = "lldelete";
			this.lldelete.TabStop = true;
			this.lldelete.UseCompatibleTextRendering = true;
			this.lldelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DeleteFile);
			// 
			// tbinstance
			// 
			resources.ApplyResources(this.tbinstance, "tbinstance");
			this.tbinstance.Name = "tbinstance";
			this.tbinstance.TextChanged += new System.EventHandler(this.AutoChange);
			// 
			// label11
			// 
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			// 
			// label9
			// 
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			// 
			// tbgroup
			// 
			resources.ApplyResources(this.tbgroup, "tbgroup");
			this.tbgroup.Name = "tbgroup";
			this.tbgroup.TextChanged += new System.EventHandler(this.AutoChange);
			// 
			// llcommit
			// 
			resources.ApplyResources(this.llcommit, "llcommit");
			this.llcommit.Name = "llcommit";
			this.llcommit.TabStop = true;
			this.llcommit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChangeFile);
			// 
			// lblist
			// 
			this.lblist.AllowDrop = true;
			resources.ApplyResources(this.lblist, "lblist");
			this.lblist.Name = "lblist";
			this.lblist.SelectedIndexChanged += new System.EventHandler(this.SelectFile);
			this.lblist.DragDrop += new System.Windows.Forms.DragEventHandler(this.PackageItemDrop);
			this.lblist.DragEnter += new System.Windows.Forms.DragEventHandler(this.PackageItemDragEnter);
			// 
			// panel3
			// 
			resources.ApplyResources(this.panel3, "panel3");
			this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel3.ForeColor = System.Drawing.Color.White;
			this.panel3.Name = "panel3";
			// 
			// sfd
			// 
			resources.ApplyResources(this.sfd, "sfd");
			// 
			// NmapForm
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.wrapperPanel);
			this.Name = "NmapForm";
			this.wrapperPanel.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gbtypes.ResumeLayout(false);
			this.pntypes.ResumeLayout(false);
			this.pntypes.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		internal System.Windows.Forms.Panel wrapperPanel;
		internal System.Windows.Forms.ListBox lblist;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox gbtypes;
		internal System.Windows.Forms.LinkLabel lladd;
		internal System.Windows.Forms.LinkLabel lldelete;
		internal System.Windows.Forms.TextBox tbinstance;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label9;
		internal System.Windows.Forms.TextBox tbgroup;
		internal System.Windows.Forms.LinkLabel llcommit;
		private System.Windows.Forms.Panel pntypes;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox tbname;
		private System.Windows.Forms.Button btref;
		private System.Windows.Forms.GroupBox groupBox1;
		internal System.Windows.Forms.TextBox tbfindname;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.SaveFileDialog sfd;

		internal SimPe.Plugin.Nmap wrapper;

		private void SelectFile(object sender, System.EventArgs e)
		{
			llcommit.Enabled = false;
			lldelete.Enabled = false;
			if (lblist.SelectedIndex<0) return;
			llcommit.Enabled = true;
			lldelete.Enabled = true;

			if (tbgroup.Tag!=null) return;
			try 
			{
				tbgroup.Tag = true;
				Interfaces.Files.IPackedFileDescriptor pfd = (Interfaces.Files.IPackedFileDescriptor)lblist.Items[lblist.SelectedIndex];
				this.tbgroup.Text = "0x"+Helper.HexString(pfd.Group);
				this.tbinstance.Text = "0x"+Helper.HexString(pfd.Instance);
				this.tbname.Text = pfd.Filename;
			} 
			catch (Exception ex) 
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			} 
			finally 
			{
				tbgroup.Tag = null;
			}
		}

		private void ChangeFile(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			try 
			{
				Packages.PackedFileDescriptor pfd = null;
				if (lblist.SelectedIndex>=0) pfd = (Packages.PackedFileDescriptor)lblist.Items[lblist.SelectedIndex];
				else pfd = new NmapItem(wrapper);

				pfd.Group = Convert.ToUInt32(this.tbgroup.Text, 16);
				pfd.Instance = Convert.ToUInt32(this.tbinstance.Text, 16);
				pfd.Filename = this.tbname.Text;

				if (lblist.SelectedIndex>=0) lblist.Items[lblist.SelectedIndex] = pfd;
				else lblist.Items.Add(pfd);
			} 
			catch (Exception ex) 
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void AddFile(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			lblist.SelectedIndex = -1;
			ChangeFile(null, null);
			lblist.SelectedIndex = lblist.Items.Count - 1;
		}

		private void DeleteFile(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			llcommit.Enabled = false;
			lldelete.Enabled = false;
			if (lblist.SelectedIndex<0) return;
			llcommit.Enabled = true;
			lldelete.Enabled = true;

			lblist.Items.Remove(lblist.Items[lblist.SelectedIndex]);
		}

		private void AutoChange(object sender, System.EventArgs e)
		{
			if (tbgroup.Tag != null) return;

			tbgroup.Tag = true;
			if (lblist.SelectedIndex>=0) ChangeFile(null, null);
			tbgroup.Tag = null;
		}

		private void CommitAll(object sender, System.EventArgs e)
		{
			try 
			{
				Interfaces.Files.IPackedFileDescriptor[] pfds = new Interfaces.Files.IPackedFileDescriptor[lblist.Items.Count];
				for (int i=0; i<pfds.Length; i++) 
				{
					pfds[i] = (Interfaces.Files.IPackedFileDescriptor)lblist.Items[i];
				}

				wrapper.Items = pfds;
				wrapper.SynchronizeUserData();
				MessageBox.Show(Localization.Manager.GetString("commited"));
			} 
			catch (Exception ex) 
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errwritingfile"), ex);
			}	
		}

		#region Package Selector
		private void ShowPackageSelector(object sender, System.EventArgs e)
		{
			SimPe.PackageSelectorForm form = new SimPe.PackageSelectorForm();
			form.Execute(wrapper.Package);
		}

		private void PackageItemDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(SimPe.Packages.PackedFileDescriptor))) 
			{				
				e.Effect = DragDropEffects.Copy;	
			}
			else 
			{
				e.Effect = DragDropEffects.None;
			}					
		}

		private void PackageItemDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			try 
			{
				Interfaces.Files.IPackedFileDescriptor pfd = null;
				pfd = (Interfaces.Files.IPackedFileDescriptor)e.Data.GetData(typeof(SimPe.Packages.PackedFileDescriptor));
				
				NmapItem nmi = new NmapItem(wrapper);
				nmi.Group = pfd.Group;
				nmi.Type = pfd.Type;
				nmi.SubType = pfd.SubType;
				nmi.Instance = pfd.Instance;
				nmi.Filename = Data.MetaData.FindTypeAlias(pfd.Type).Name;
				lblist.Items.Add(nmi);
			}
			catch (Exception ex) 
			{
				Helper.ExceptionMessage("", ex);
			}
		}
		#endregion

		private void tbfindname_TextChanged(object sender, System.EventArgs e)
		{
			
			string name = tbfindname.Text.Trim().ToLower();
			for (int i=0; i<lblist.Items.Count; i++)
			{
				Packages.PackedFileDescriptor pfd = (Packages.PackedFileDescriptor)lblist.Items[i];
				if (pfd.Filename.Trim().ToLower().StartsWith(name)) 
				{
					tbfindname.Text = pfd.Filename.Trim();
					tbfindname.SelectionStart = name.Length;
					tbfindname.SelectionLength = Math.Max(0, tbfindname.Text.Length - name.Length);
					lblist.SelectedIndex = i;
					break;
				}
			}
		}

		private void CreateTextFile(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(wrapper.Package.FileName) + "_NameMap.txt";
			if (sfd.ShowDialog()==DialogResult.OK)
			{
				try 
				{
					
					System.IO.TextWriter tw = System.IO.File.CreateText(sfd.FileName);
					try 
					{
						tw.WriteLine(
							"Filename; "+
							"Group; "+
							"Instance; "
							);
						foreach (Packages.PackedFileDescriptor pfd in lblist.Items) 
						{
							tw.WriteLine(
								pfd.Filename + "; "+
								"0x"+Helper.HexString(pfd.Group) + "; "+
								"0x"+Helper.HexString(pfd.Instance) + "; "
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
