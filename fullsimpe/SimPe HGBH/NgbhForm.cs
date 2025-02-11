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
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NgbhForm.
	/// </summary>
	public class NgbhForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		

		public NgbhForm()
		{
			InitializeComponent();

			this.cbtype.SelectedIndex = cbtype.Items.Count-1;

#if DEBUG
#else
			/*this.lbdata.Visible = false;
			this.tbFlag.Enabled = false;
			this.tbguid.Visible = false;
			this.tbsub.Visible = false;
			this.tbsubid.Visible = false;
			this.tbown.Visible = false;*/
#endif

			SimPe.RemoteControl.HookToMessageQueue(0x4E474248, new SimPe.RemoteControl.ControlEvent(ControlEvent));
		}

		protected void ControlEvent(object sender, SimPe.RemoteControl.ControlEventArgs e)
		{			
			object[] os = e.Items as object[];
			if (os!=null) 
			{
				this.cbtype.SelectedIndex = (int)((Data.NeighborhoodSlots)os[1]);
				uint inst = (uint)os[0];
				foreach (ListViewItem lvi in this.lv.Items)
				{
					
					PackedFiles.Wrapper.SDesc sdesc = lvi.Tag as PackedFiles.Wrapper.SDesc;
					if (sdesc.FileDescriptor.Instance == inst) 
					{
						lvi.Selected = true;
						lvi.EnsureVisible();						
					} else lvi.Selected = false;
				}

				lv.Refresh();
			}			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				SimPe.RemoteControl.UnhookFromMessageQueue(0x4E474248, new SimPe.RemoteControl.ControlEvent(ControlEvent));
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NgbhForm));
            this.ngbhPanel = new System.Windows.Forms.Panel();
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.lbname = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gbmem = new System.Windows.Forms.GroupBox();
            this.cbown = new System.Windows.Forms.ComboBox();
            this.tbval = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbUnk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btdown = new System.Windows.Forms.Button();
            this.btup = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.lbmem = new System.Windows.Forms.ListView();
            this.memilist = new System.Windows.Forms.ImageList(this.components);
            this.tbown = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lladd = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tbsubid = new System.Windows.Forms.TextBox();
            this.cbsub = new System.Windows.Forms.ComboBox();
            this.tbsub = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbguid = new System.Windows.Forms.ComboBox();
            this.tbguid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbaction = new System.Windows.Forms.CheckBox();
            this.cbvis = new System.Windows.Forms.CheckBox();
            this.tbFlag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.PictureBox();
            this.lbdata = new System.Windows.Forms.TextBox();
            this.lv = new System.Windows.Forms.ListView();
            this.ilist = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.ngbhPanel.SuspendLayout();
            this.gbmem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ngbhPanel
            // 
            resources.ApplyResources(this.ngbhPanel, "ngbhPanel");
            this.ngbhPanel.Controls.Add(this.cbtype);
            this.ngbhPanel.Controls.Add(this.lbname);
            this.ngbhPanel.Controls.Add(this.button1);
            this.ngbhPanel.Controls.Add(this.gbmem);
            this.ngbhPanel.Controls.Add(this.lv);
            this.ngbhPanel.Controls.Add(this.panel2);
            this.ngbhPanel.Name = "ngbhPanel";
            // 
            // cbtype
            // 
            this.cbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbtype, "cbtype");
            this.cbtype.Items.AddRange(new object[] {
            resources.GetString("cbtype.Items"),
            resources.GetString("cbtype.Items1"),
            resources.GetString("cbtype.Items2"),
            resources.GetString("cbtype.Items3"),
            resources.GetString("cbtype.Items4"),
            resources.GetString("cbtype.Items5")});
            this.cbtype.Name = "cbtype";
            this.cbtype.SelectedIndexChanged += new System.EventHandler(this.SelectSim);
            // 
            // lbname
            // 
            resources.ApplyResources(this.lbname, "lbname");
            this.lbname.Name = "lbname";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.Click += new System.EventHandler(this.Commit);
            // 
            // gbmem
            // 
            resources.ApplyResources(this.gbmem, "gbmem");
            this.gbmem.Controls.Add(this.cbown);
            this.gbmem.Controls.Add(this.tbval);
            this.gbmem.Controls.Add(this.label6);
            this.gbmem.Controls.Add(this.tbUnk);
            this.gbmem.Controls.Add(this.label5);
            this.gbmem.Controls.Add(this.btdown);
            this.gbmem.Controls.Add(this.btup);
            this.gbmem.Controls.Add(this.linkLabel2);
            this.gbmem.Controls.Add(this.lbmem);
            this.gbmem.Controls.Add(this.tbown);
            this.gbmem.Controls.Add(this.label4);
            this.gbmem.Controls.Add(this.lladd);
            this.gbmem.Controls.Add(this.linkLabel1);
            this.gbmem.Controls.Add(this.tbsubid);
            this.gbmem.Controls.Add(this.cbsub);
            this.gbmem.Controls.Add(this.tbsub);
            this.gbmem.Controls.Add(this.label3);
            this.gbmem.Controls.Add(this.cbguid);
            this.gbmem.Controls.Add(this.tbguid);
            this.gbmem.Controls.Add(this.label2);
            this.gbmem.Controls.Add(this.cbaction);
            this.gbmem.Controls.Add(this.cbvis);
            this.gbmem.Controls.Add(this.tbFlag);
            this.gbmem.Controls.Add(this.label1);
            this.gbmem.Controls.Add(this.pb);
            this.gbmem.Controls.Add(this.lbdata);
            this.gbmem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbmem.Name = "gbmem";
            this.gbmem.TabStop = false;
            // 
            // cbown
            // 
            resources.ApplyResources(this.cbown, "cbown");
            this.cbown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbown.Name = "cbown";
            this.cbown.SelectedIndexChanged += new System.EventHandler(this.ChgOwnerItem);
            // 
            // tbval
            // 
            resources.ApplyResources(this.tbval, "tbval");
            this.tbval.Name = "tbval";
            this.tbval.TextChanged += new System.EventHandler(this.tbval_TextChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tbUnk
            // 
            resources.ApplyResources(this.tbUnk, "tbUnk");
            this.tbUnk.Name = "tbUnk";
            this.tbUnk.TextChanged += new System.EventHandler(this.tbUnk_TextChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // btdown
            // 
            resources.ApplyResources(this.btdown, "btdown");
            this.btdown.Name = "btdown";
            this.btdown.Click += new System.EventHandler(this.ItemDown);
            // 
            // btup
            // 
            resources.ApplyResources(this.btup, "btup");
            this.btup.Name = "btup";
            this.btup.Click += new System.EventHandler(this.ItemUp);
            // 
            // linkLabel2
            // 
            resources.ApplyResources(this.linkLabel2, "linkLabel2");
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.TabStop = true;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.IOwn);
            // 
            // lbmem
            // 
            resources.ApplyResources(this.lbmem, "lbmem");
            this.lbmem.HideSelection = false;
            this.lbmem.LargeImageList = this.memilist;
            this.lbmem.MultiSelect = false;
            this.lbmem.Name = "lbmem";
            this.lbmem.SmallImageList = this.memilist;
            this.lbmem.StateImageList = this.memilist;
            this.lbmem.UseCompatibleStateImageBehavior = false;
            this.lbmem.View = System.Windows.Forms.View.List;
            this.lbmem.SelectedIndexChanged += new System.EventHandler(this.SelectMemory);
            // 
            // memilist
            // 
            this.memilist.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.memilist, "memilist");
            this.memilist.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tbown
            // 
            resources.ApplyResources(this.tbown, "tbown");
            this.tbown.Name = "tbown";
            this.tbown.TextChanged += new System.EventHandler(this.ChgOwner);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // lladd
            // 
            resources.ApplyResources(this.lladd, "lladd");
            this.lladd.Name = "lladd";
            this.lladd.TabStop = true;
            this.lladd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddItem);
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DeleteItem);
            // 
            // tbsubid
            // 
            resources.ApplyResources(this.tbsubid, "tbsubid");
            this.tbsubid.Name = "tbsubid";
            this.tbsubid.TextChanged += new System.EventHandler(this.ChgSubjectID);
            // 
            // cbsub
            // 
            resources.ApplyResources(this.cbsub, "cbsub");
            this.cbsub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsub.Name = "cbsub";
            this.cbsub.SelectedIndexChanged += new System.EventHandler(this.ChgSubjectItem);
            // 
            // tbsub
            // 
            resources.ApplyResources(this.tbsub, "tbsub");
            this.tbsub.Name = "tbsub";
            this.tbsub.TextChanged += new System.EventHandler(this.ChgSubject);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cbguid
            // 
            resources.ApplyResources(this.cbguid, "cbguid");
            this.cbguid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbguid.Name = "cbguid";
            this.cbguid.SelectedIndexChanged += new System.EventHandler(this.ChgGuidItem);
            // 
            // tbguid
            // 
            resources.ApplyResources(this.tbguid, "tbguid");
            this.tbguid.Name = "tbguid";
            this.tbguid.TextChanged += new System.EventHandler(this.ChgGuid);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cbaction
            // 
            resources.ApplyResources(this.cbaction, "cbaction");
            this.cbaction.Name = "cbaction";
            this.cbaction.CheckedChanged += new System.EventHandler(this.ChgFlags);
            // 
            // cbvis
            // 
            resources.ApplyResources(this.cbvis, "cbvis");
            this.cbvis.Name = "cbvis";
            this.cbvis.CheckedChanged += new System.EventHandler(this.ChgFlags);
            // 
            // tbFlag
            // 
            resources.ApplyResources(this.tbFlag, "tbFlag");
            this.tbFlag.Name = "tbFlag";
            this.tbFlag.TextChanged += new System.EventHandler(this.ChgFlag);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pb
            // 
            resources.ApplyResources(this.pb, "pb");
            this.pb.Name = "pb";
            this.pb.TabStop = false;
            // 
            // lbdata
            // 
            resources.ApplyResources(this.lbdata, "lbdata");
            this.lbdata.Name = "lbdata";
            this.lbdata.TextChanged += new System.EventHandler(this.ChgData);
            // 
            // lv
            // 
            resources.ApplyResources(this.lv, "lv");
            this.lv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv.HideSelection = false;
            this.lv.LargeImageList = this.ilist;
            this.lv.Name = "lv";
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.SelectedIndexChanged += new System.EventHandler(this.SelectSim);
            // 
            // ilist
            // 
            this.ilist.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.ilist, "ilist");
            this.ilist.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.label27);
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Name = "panel2";
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // NgbhForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.ngbhPanel);
            this.Name = "NgbhForm";
            this.ngbhPanel.ResumeLayout(false);
            this.ngbhPanel.PerformLayout();
            this.gbmem.ResumeLayout(false);
            this.gbmem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label27;
		internal System.Windows.Forms.Panel ngbhPanel;
		internal System.Windows.Forms.ListView lv;
		internal System.Windows.Forms.ImageList ilist;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbFlag;
		private System.Windows.Forms.CheckBox cbvis;
		private System.Windows.Forms.CheckBox cbaction;
		private System.Windows.Forms.TextBox tbguid;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.ComboBox cbguid;
		internal System.Windows.Forms.ComboBox cbsub;
		private System.Windows.Forms.TextBox tbsub;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox lbdata;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tbsubid;
		internal System.Windows.Forms.GroupBox gbmem;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel lladd;
		private System.Windows.Forms.PictureBox pb;
		internal System.Windows.Forms.ComboBox cbown;
		private System.Windows.Forms.TextBox tbown;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbname;
		private System.Windows.Forms.ImageList memilist;
		internal System.Windows.Forms.ListView lbmem;
		private System.Windows.Forms.LinkLabel linkLabel2;
		internal System.Windows.Forms.Button btdown;
		internal System.Windows.Forms.Button btup;
		internal System.Windows.Forms.ComboBox cbtype;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbUnk;
		private System.Windows.Forms.TextBox tbval;
		private System.Windows.Forms.Label label6;

		internal IFileWrapperSaveExtension wrapper;

		protected void AddItem(NgbhItem item)
		{
			if (item==null) return;
			ListViewItem lvi = new ListViewItem();
			lvi.Text = item.ToString();
			lvi.Tag = item;

			if (item.MemoryCacheItem.Icon!=null) 
			{
				lvi.ImageIndex = memilist.Images.Count;

				memilist.Images.Add(item.MemoryCacheItem.Icon);
			}

			lbmem.Items.Add(lvi);
		}

		private void tbval_TextChanged(object sender, System.EventArgs e)
		{
			if (tbFlag.Tag!=null) return;
			try 
			{
				if (Helper.WindowsRegistry.HiddenMode)
					GetSelectedItem().Value = Helper.StringToUInt16(tbval.Text, GetSelectedItem().Value, 16);
				else
					GetSelectedItem().Value = Helper.StringToUInt16(tbval.Text, GetSelectedItem().Value, 10);
			} 
			catch (Exception ex) 
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void tbUnk_TextChanged(object sender, System.EventArgs e)
		{
			if (tbFlag.Tag!=null) return;
			try 
			{
				GetSelectedItem().InventoryNumber = Helper.StringToUInt32(tbUnk.Text, GetSelectedItem().InventoryNumber, 16);
			} 
			catch (Exception ex) 
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void ItemUp(object sender, System.EventArgs e)
		{
			if (lbmem.SelectedItems.Count==0) return;
			int SelectedIndex = lbmem.SelectedItems[0].Index;
			if (SelectedIndex<1) return;

			ListViewItem lvi = (ListViewItem)lbmem.Items[SelectedIndex];
			
			lbmem.Items[SelectedIndex] = (ListViewItem)lbmem.Items[SelectedIndex-1].Clone();
			lbmem.Items[SelectedIndex-1] = (ListViewItem)lvi.Clone();
			lbmem.Items[SelectedIndex-1].Selected = true;


			try 
			{
				//change also in the Items List
				Ngbh wrp = (Ngbh)wrapper;
				PackedFiles.Wrapper.SDesc sdesc = (PackedFiles.Wrapper.SDesc)lv.SelectedItems[0].Tag;
				NgbhSlot slot = wrp.Sims.GetInstanceSlot(sdesc.Instance);
				NgbhItem i = slot.ItemsB[SelectedIndex- 1];
				slot.ItemsB[SelectedIndex-1] = slot.ItemsB[SelectedIndex];
				slot.ItemsB[SelectedIndex] = i;
			} 
			catch (Exception ex)
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void ItemDown(object sender, System.EventArgs e)
		{
			if (lbmem.SelectedItems.Count==0) return;
			int SelectedIndex = lbmem.SelectedItems[0].Index;
			if (SelectedIndex<0) return;
			if (SelectedIndex>lbmem.Items.Count-2) return;

			ListViewItem lvi = (ListViewItem)lbmem.Items[SelectedIndex];
			lbmem.Items[SelectedIndex] = (ListViewItem)lbmem.Items[SelectedIndex+1].Clone();
			lbmem.Items[SelectedIndex+1] = (ListViewItem)lvi.Clone();
			lbmem.Items[SelectedIndex+1].Selected = true;

			try 
			{
				//change also in the Items List
				Ngbh wrp = (Ngbh)wrapper;
				PackedFiles.Wrapper.SDesc sdesc = (PackedFiles.Wrapper.SDesc)lv.SelectedItems[0].Tag;
				NgbhSlot slot = wrp.Sims.GetInstanceSlot(sdesc.Instance);
				NgbhItem i = slot.ItemsB[SelectedIndex + 1];
				slot.ItemsB[SelectedIndex + 1] = slot.ItemsB[SelectedIndex];
				slot.ItemsB[SelectedIndex] = i;
			} 
			catch (Exception ex)
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		protected void UpdateMemItem(NgbhItem item)
		{
			if (lbmem.SelectedItems.Count>0) 
			{
				lbmem.SelectedItems[0].Text = item.ToString();

				if ((item.MemoryCacheItem.Icon!=null) && (lbmem.SelectedItems[0].ImageIndex>=0)) 
				{
					int id = lbmem.SelectedItems[0].ImageIndex;
					lbmem.SelectedItems[0].ImageIndex = -1;
					System.Drawing.Image simg = item.MemoryCacheItem.Icon;
					Bitmap img = new Bitmap(memilist.ImageSize.Width, memilist.ImageSize.Height);
					Graphics gr = Graphics.FromImage(img);
					gr.DrawImage(
						simg, 
						0,
						0,
						memilist.ImageSize.Width, 
						memilist.ImageSize.Height
						);


					memilist.Images[id] = img;
					pb.Image = simg;
					lbmem.SelectedItems[0].ImageIndex = id;
				}
			}
		}

		private void IOwn(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (lv.SelectedItems.Count==0) return;
			try 
			{
				PackedFiles.Wrapper.SDesc sdesc = (PackedFiles.Wrapper.SDesc)lv.SelectedItems[0].Tag;

				cbown.SelectedIndex = 0;
				for(int i=0; i<cbown.Items.Count; i++)
				{
					Interfaces.IAlias a = (Interfaces.IAlias)cbown.Items[i];
					if (a.Tag==null) continue;
					ushort inst = (ushort)a.Tag[0];
					if (inst == sdesc.Instance) 
					{
						cbown.SelectedIndex = i;
						break;
					}
				}
			} 
			catch (Exception ex)
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void SelectSim(object sender, System.EventArgs e)
		{
			gbmem.Enabled = false;
			memilist.Images.Clear();
			if (lv.SelectedItems.Count < 1) return;
			gbmem.Enabled = true;

			this.Cursor = Cursors.WaitCursor;
			try 
			{
				lbname.Text = lv.SelectedItems[0].Text;
				PackedFiles.Wrapper.SDesc sdesc = (PackedFiles.Wrapper.SDesc)lv.SelectedItems[0].Tag;
				lbmem.Items.Clear();
			
				Ngbh wrp = (Ngbh)wrapper;
				Collections.NgbhItems items = wrp.GetItems((Data.NeighborhoodSlots)cbtype.SelectedIndex, sdesc.Instance);							
				
				if (items!=null)
					foreach (NgbhItem item in items) this.AddItem(item);				

				if (lbmem.Items.Count>0) lbmem.Items[0].Selected = true;
			} 
			catch (Exception ex) 
			{
				this.Cursor = Cursors.Default;
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
			this.Cursor = Cursors.Default;
		}

		protected NgbhItem GetSelectedItem()
		{
			if (this.lbmem.SelectedItems.Count==0) return new NgbhItem(new NgbhSlot((Ngbh)wrapper, (Data.NeighborhoodSlots)this.cbtype.SelectedValue));
			return (NgbhItem)lbmem.SelectedItems[0].Tag;
		}

		

		private void SelectMemory(object sender, System.EventArgs e)
		{
			tbFlag.Tag = true;
			this.cbvis.Checked = GetSelectedItem().Flags.IsVisible;
			this.cbaction.Checked = GetSelectedItem().Flags.IsControler;
			this.tbFlag.Text = "0x"+Helper.HexString(GetSelectedItem().Flags.Value);

			this.tbUnk.Enabled = (uint)GetSelectedItem().ParentSlot.Version >= (uint)NgbhVersion.Nightlife;
			this.tbUnk.Text = "0x"+Helper.HexString(GetSelectedItem().InventoryNumber);
			if (Helper.WindowsRegistry.HiddenMode)
				this.tbval.Text = "0x"+Helper.HexString(GetSelectedItem().Value);
			else
				this.tbval.Text = GetSelectedItem().Value.ToString();

			tbFlag.Tag = null;

			tbguid.Tag = true;
			tbguid.Text = "0x"+Helper.HexString(GetSelectedItem().Guid);
			cbguid.SelectedIndex = 0;
			for(int i=0; i<cbguid.Items.Count; i++)
			{
				Interfaces.IAlias a = (Interfaces.IAlias)cbguid.Items[i];
				if (a.Id == GetSelectedItem().Guid) 
				{
					cbguid.SelectedIndex = i;
					break;
				}
			}
			tbguid.Tag = null;

			tbsub.Tag = true;
			tbsub.Text = "0x"+Helper.HexString(GetSelectedItem().SimInstance);
			tbsubid.Text = "0x"+Helper.HexString(GetSelectedItem().SimID);
			cbsub.SelectedIndex = 0;
			for(int i=0; i<cbsub.Items.Count; i++)
			{
				Interfaces.IAlias a = (Interfaces.IAlias)cbsub.Items[i];
				if (a.Id == GetSelectedItem().SimID) 
				{
					cbsub.SelectedIndex = i;
					break;
				}
			}
			tbsub.Tag = null;

			tbown.Tag = true;
			tbown.Text = "0x"+Helper.HexString(GetSelectedItem().OwnerInstance);
			cbown.SelectedIndex = 0;
			for(int i=0; i<cbown.Items.Count; i++)
			{
				Interfaces.IAlias a = (Interfaces.IAlias)cbown.Items[i];
				if (a.Tag==null) continue;
				ushort inst = (ushort)a.Tag[0];
				if (inst == GetSelectedItem().OwnerInstance) 
				{
					cbown.SelectedIndex = i;
					break;
				}
			}
			tbown.Tag = null;

			lbdata.Tag = true;
			lbdata.Text = "";
			foreach (ushort s in GetSelectedItem().Data) lbdata.Text += Helper.HexString(s) + " ";
			lbdata.Tag = null;

			pb.Image = GetSelectedItem().MemoryCacheItem.Icon;
		}

		private void ChgFlags(object sender, System.EventArgs e)
		{
			if (tbFlag.Tag!=null) return;
			tbFlag.Tag = true;
			GetSelectedItem().Flags.IsVisible = this.cbvis.Checked;
			GetSelectedItem().Flags.IsControler = this.cbaction.Checked;
			this.tbFlag.Text = "0x"+Helper.HexString(GetSelectedItem().Flags.Value);
			this.UpdateMemItem(GetSelectedItem());
			tbFlag.Tag = null;
		}

		private void ChgFlag(object sender, System.EventArgs e)
		{
			if (tbFlag.Tag!=null) return;
			try 
			{
				GetSelectedItem().Flags.Value = Convert.ToUInt16(tbFlag.Text, 16);
			} 
			catch (Exception ex) 
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void ChgGuidItem(object sender, System.EventArgs e)
		{
			if (tbguid.Tag != null) return;
			
			if (cbguid.SelectedIndex<1) return;
			Interfaces.IAlias a = (Interfaces.IAlias)cbguid.Items[cbguid.SelectedIndex];
			tbguid.Text = "0x"+Helper.HexString(a.Id);
		}

		private void ChgGuid(object sender, System.EventArgs e)
		{
			if (tbguid.Tag!=null) return;

			try 
			{
				GetSelectedItem().Guid = Convert.ToUInt32(tbguid.Text, 16);
				this.UpdateMemItem(GetSelectedItem());
			} 
			catch (Exception ex) 
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void ChgSubjectItem(object sender, System.EventArgs e)
		{
			if (tbsub.Tag != null) return;
			
			if (cbsub.SelectedIndex<1) return;
			Interfaces.IAlias a = (Interfaces.IAlias)cbsub.Items[cbsub.SelectedIndex];
			tbsubid.Text = "0x"+Helper.HexString(a.Id);
			if (a.Tag!=null)
				tbsub.Text = "0x"+Helper.HexString((ushort)a.Tag[0]);
			else
				tbsub.Text = "0x0000";
		}

		private void ChgSubject(object sender, System.EventArgs e)
		{
			if (tbsub.Tag!=null) return;

			try 
			{
				GetSelectedItem().SimInstance = Convert.ToUInt16(tbsub.Text, 16);
				this.UpdateMemItem(GetSelectedItem());
			} 
			catch (Exception ex) 
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void ChgSubjectID(object sender, System.EventArgs e)
		{
			if (tbsub.Tag!=null) return;

			try 
			{
				GetSelectedItem().SimID = Convert.ToUInt32(tbsubid.Text, 16);
				this.UpdateMemItem(GetSelectedItem());
			} 
			catch (Exception ex) 
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void ChgOwnerItem(object sender, System.EventArgs e)
		{
			if (tbown.Tag != null) return;
			
			if (cbown.SelectedIndex<1) return;
			Interfaces.IAlias a = (Interfaces.IAlias)cbown.Items[cbown.SelectedIndex];
			if (a.Tag!=null)
				tbown.Text = "0x"+Helper.HexString((ushort)a.Tag[0]);
			else
				tbown.Text = "0x0000";
		}

		private void ChgOwner(object sender, System.EventArgs e)
		{
			if (tbown.Tag!=null) return;

			try 
			{
				GetSelectedItem().OwnerInstance = Convert.ToUInt16(tbown.Text, 16);
				this.UpdateMemItem(GetSelectedItem());
			} 
			catch (Exception ex) 
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}


		private void ChgData(object sender, System.EventArgs e)
		{
			if (lbdata.Tag != null) return;

			string[] tokens = lbdata.Text.Split(" ".ToCharArray());
			ushort[] data = new ushort[tokens.Length];

			try 
			{
				for(int i=0; i<tokens.Length; i++)
				{
					if (tokens[i].Trim()!="")
						data[i] = Convert.ToUInt16(tokens[i], 16);
					else
						data[i] = 0;
				}

				this.GetSelectedItem().Data = data;
			} 
			catch (Exception ex) 
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void Commit(object sender, System.EventArgs e)
		{
			try 
			{
				Ngbh wrp = (Ngbh)wrapper;
				wrp.SynchronizeUserData();MessageBox.Show(Localization.Manager.GetString("commited"));
			} 
			catch (Exception ex) 
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errwritingfile"), ex);
			}
		}

		private void DeleteItem(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (lbmem.SelectedItems.Count==0) return;
			if (cbtype.SelectedIndex%2==1)
				GetSelectedItem().RemoveFromParentB();
			else
				GetSelectedItem().RemoveFromParentA();

			lbmem.Items.Remove(lbmem.SelectedItems[0]);
		}

		private void AddItem(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (lv.SelectedItems.Count<=0) return;

			this.Cursor = Cursors.WaitCursor;
			try 
			{
				PackedFiles.Wrapper.SDesc sdesc = (PackedFiles.Wrapper.SDesc)lv.SelectedItems[0].Tag;
			
				Ngbh wrp = (Ngbh)wrapper;
				NgbhSlot slot = wrp.GetSlots((Data.NeighborhoodSlots)cbtype.SelectedIndex).GetInstanceSlot(sdesc.Instance, true);
				if (slot!=null) 
				{
					NgbhItem item = slot.GetItems((Data.NeighborhoodSlots)cbtype.SelectedIndex).AddNew();
				 
					item.PutValue(0x01, 0x07CD);
					item.PutValue(0x02, 0x0007);
					item.PutValue(0x0B, 0);
					item.Flags.IsVisible = true;
					item.Flags.IsControler = false;
					this.AddItem(item);
					lbmem.Items[lbmem.Items.Count-1].Selected = true;
				}
			} 
			catch (Exception ex) 
			{
				this.Cursor = Cursors.Default;
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
			this.Cursor = Cursors.Default;

		}

		
	}
}
