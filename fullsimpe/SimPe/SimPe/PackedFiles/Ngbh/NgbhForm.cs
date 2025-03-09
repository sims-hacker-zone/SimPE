// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Sdsc;

namespace SimPe.PackedFiles.Ngbh
{
	/// <summary>
	/// Summary description for NgbhForm.
	/// </summary>
	public class NgbhForm : Form
	{
		private System.ComponentModel.IContainer components;

		public NgbhForm()
		{
			InitializeComponent();

			cbtype.SelectedIndex = cbtype.Items.Count - 1;

#if DEBUG
#else
			/*this.lbdata.Visible = false;
			this.tbFlag.Enabled = false;
			this.tbguid.Visible = false;
			this.tbsub.Visible = false;
			this.tbsubid.Visible = false;
			this.tbown.Visible = false;*/
#endif

			RemoteControl.HookToMessageQueue(
				FileTypes.NGBH,
				new RemoteControl.ControlEvent(ControlEvent)
			);
		}

		protected void ControlEvent(
			object sender,
			RemoteControl.ControlEventArgs e
		)
		{
			if (e.Items is object[] os)
			{
				cbtype.SelectedIndex = (int)(NeighborhoodSlots)os[1];
				uint inst = (uint)os[0];
				foreach (ListViewItem lvi in lv.Items)
				{
					SDesc sdesc =
						lvi.Tag as SDesc;
					if (sdesc.FileDescriptor.Instance == inst)
					{
						lvi.Selected = true;
						lvi.EnsureVisible();
					}
					else
					{
						lvi.Selected = false;
					}
				}

				lv.Refresh();
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				RemoteControl.UnhookFromMessageQueue(
					FileTypes.NGBH,
					new RemoteControl.ControlEvent(ControlEvent)
				);
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
				new System.ComponentModel.ComponentResourceManager(typeof(NgbhForm));
			ngbhPanel = new Panel();
			cbtype = new ComboBox();
			lbname = new Label();
			button1 = new Button();
			gbmem = new GroupBox();
			cbown = new ComboBox();
			tbval = new TextBox();
			label6 = new Label();
			tbUnk = new TextBox();
			label5 = new Label();
			btdown = new Button();
			btup = new Button();
			linkLabel2 = new LinkLabel();
			lbmem = new ListView();
			memilist = new ImageList(components);
			tbown = new TextBox();
			label4 = new Label();
			lladd = new LinkLabel();
			linkLabel1 = new LinkLabel();
			tbsubid = new TextBox();
			cbsub = new ComboBox();
			tbsub = new TextBox();
			label3 = new Label();
			cbguid = new ComboBox();
			tbguid = new TextBox();
			label2 = new Label();
			cbaction = new CheckBox();
			cbvis = new CheckBox();
			tbFlag = new TextBox();
			label1 = new Label();
			pb = new PictureBox();
			lbdata = new TextBox();
			lv = new ListView();
			ilist = new ImageList(components);
			panel2 = new Panel();
			label27 = new Label();
			ngbhPanel.SuspendLayout();
			gbmem.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pb).BeginInit();
			panel2.SuspendLayout();
			SuspendLayout();
			//
			// ngbhPanel
			//
			resources.ApplyResources(ngbhPanel, "ngbhPanel");
			ngbhPanel.Controls.Add(cbtype);
			ngbhPanel.Controls.Add(lbname);
			ngbhPanel.Controls.Add(button1);
			ngbhPanel.Controls.Add(gbmem);
			ngbhPanel.Controls.Add(lv);
			ngbhPanel.Controls.Add(panel2);
			ngbhPanel.Name = "ngbhPanel";
			//
			// cbtype
			//
			cbtype.DropDownStyle = ComboBoxStyle.DropDownList;
			resources.ApplyResources(cbtype, "cbtype");
			cbtype.Items.AddRange(
				new object[]
				{
					resources.GetString("cbtype.Items"),
					resources.GetString("cbtype.Items1"),
					resources.GetString("cbtype.Items2"),
					resources.GetString("cbtype.Items3"),
					resources.GetString("cbtype.Items4"),
					resources.GetString("cbtype.Items5"),
				}
			);
			cbtype.Name = "cbtype";
			cbtype.SelectedIndexChanged += new EventHandler(SelectSim);
			//
			// lbname
			//
			resources.ApplyResources(lbname, "lbname");
			lbname.Name = "lbname";
			//
			// button1
			//
			resources.ApplyResources(button1, "button1");
			button1.Name = "button1";
			button1.Click += new EventHandler(Commit);
			//
			// gbmem
			//
			resources.ApplyResources(gbmem, "gbmem");
			gbmem.Controls.Add(cbown);
			gbmem.Controls.Add(tbval);
			gbmem.Controls.Add(label6);
			gbmem.Controls.Add(tbUnk);
			gbmem.Controls.Add(label5);
			gbmem.Controls.Add(btdown);
			gbmem.Controls.Add(btup);
			gbmem.Controls.Add(linkLabel2);
			gbmem.Controls.Add(lbmem);
			gbmem.Controls.Add(tbown);
			gbmem.Controls.Add(label4);
			gbmem.Controls.Add(lladd);
			gbmem.Controls.Add(linkLabel1);
			gbmem.Controls.Add(tbsubid);
			gbmem.Controls.Add(cbsub);
			gbmem.Controls.Add(tbsub);
			gbmem.Controls.Add(label3);
			gbmem.Controls.Add(cbguid);
			gbmem.Controls.Add(tbguid);
			gbmem.Controls.Add(label2);
			gbmem.Controls.Add(cbaction);
			gbmem.Controls.Add(cbvis);
			gbmem.Controls.Add(tbFlag);
			gbmem.Controls.Add(label1);
			gbmem.Controls.Add(pb);
			gbmem.Controls.Add(lbdata);
			gbmem.FlatStyle = FlatStyle.System;
			gbmem.Name = "gbmem";
			gbmem.TabStop = false;
			//
			// cbown
			//
			resources.ApplyResources(cbown, "cbown");
			cbown.DropDownStyle = ComboBoxStyle.DropDownList;
			cbown.Name = "cbown";
			cbown.SelectedIndexChanged += new EventHandler(
				ChgOwnerItem
			);
			//
			// tbval
			//
			resources.ApplyResources(tbval, "tbval");
			tbval.Name = "tbval";
			tbval.TextChanged += new EventHandler(tbval_TextChanged);
			//
			// label6
			//
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			//
			// tbUnk
			//
			resources.ApplyResources(tbUnk, "tbUnk");
			tbUnk.Name = "tbUnk";
			tbUnk.TextChanged += new EventHandler(tbUnk_TextChanged);
			//
			// label5
			//
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			//
			// btdown
			//
			resources.ApplyResources(btdown, "btdown");
			btdown.Name = "btdown";
			btdown.Click += new EventHandler(ItemDown);
			//
			// btup
			//
			resources.ApplyResources(btup, "btup");
			btup.Name = "btup";
			btup.Click += new EventHandler(ItemUp);
			//
			// linkLabel2
			//
			resources.ApplyResources(linkLabel2, "linkLabel2");
			linkLabel2.Name = "linkLabel2";
			linkLabel2.TabStop = true;
			linkLabel2.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(IOwn);
			//
			// lbmem
			//
			resources.ApplyResources(lbmem, "lbmem");
			lbmem.HideSelection = false;
			lbmem.LargeImageList = memilist;
			lbmem.MultiSelect = false;
			lbmem.Name = "lbmem";
			lbmem.SmallImageList = memilist;
			lbmem.StateImageList = memilist;
			lbmem.UseCompatibleStateImageBehavior = false;
			lbmem.View = View.List;
			lbmem.SelectedIndexChanged += new EventHandler(
				SelectMemory
			);
			//
			// memilist
			//
			memilist.ColorDepth = ColorDepth.Depth32Bit;
			resources.ApplyResources(memilist, "memilist");
			memilist.TransparentColor = Color.Transparent;
			//
			// tbown
			//
			resources.ApplyResources(tbown, "tbown");
			tbown.Name = "tbown";
			tbown.TextChanged += new EventHandler(ChgOwner);
			//
			// label4
			//
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// lladd
			//
			resources.ApplyResources(lladd, "lladd");
			lladd.Name = "lladd";
			lladd.TabStop = true;
			lladd.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(AddItem);
			//
			// linkLabel1
			//
			resources.ApplyResources(linkLabel1, "linkLabel1");
			linkLabel1.Name = "linkLabel1";
			linkLabel1.TabStop = true;
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					DeleteItem
				);
			//
			// tbsubid
			//
			resources.ApplyResources(tbsubid, "tbsubid");
			tbsubid.Name = "tbsubid";
			tbsubid.TextChanged += new EventHandler(ChgSubjectID);
			//
			// cbsub
			//
			resources.ApplyResources(cbsub, "cbsub");
			cbsub.DropDownStyle = ComboBoxStyle.DropDownList;
			cbsub.Name = "cbsub";
			cbsub.SelectedIndexChanged += new EventHandler(
				ChgSubjectItem
			);
			//
			// tbsub
			//
			resources.ApplyResources(tbsub, "tbsub");
			tbsub.Name = "tbsub";
			tbsub.TextChanged += new EventHandler(ChgSubject);
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// cbguid
			//
			resources.ApplyResources(cbguid, "cbguid");
			cbguid.DropDownStyle = ComboBoxStyle.DropDownList;
			cbguid.Name = "cbguid";
			cbguid.SelectedIndexChanged += new EventHandler(
				ChgGuidItem
			);
			//
			// tbguid
			//
			resources.ApplyResources(tbguid, "tbguid");
			tbguid.Name = "tbguid";
			tbguid.TextChanged += new EventHandler(ChgGuid);
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// cbaction
			//
			resources.ApplyResources(cbaction, "cbaction");
			cbaction.Name = "cbaction";
			cbaction.CheckedChanged += new EventHandler(ChgFlags);
			//
			// cbvis
			//
			resources.ApplyResources(cbvis, "cbvis");
			cbvis.Name = "cbvis";
			cbvis.CheckedChanged += new EventHandler(ChgFlags);
			//
			// tbFlag
			//
			resources.ApplyResources(tbFlag, "tbFlag");
			tbFlag.Name = "tbFlag";
			tbFlag.TextChanged += new EventHandler(ChgFlag);
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// pb
			//
			resources.ApplyResources(pb, "pb");
			pb.Name = "pb";
			pb.TabStop = false;
			//
			// lbdata
			//
			resources.ApplyResources(lbdata, "lbdata");
			lbdata.Name = "lbdata";
			lbdata.TextChanged += new EventHandler(ChgData);
			//
			// lv
			//
			resources.ApplyResources(lv, "lv");
			lv.BorderStyle = BorderStyle.None;
			lv.HideSelection = false;
			lv.LargeImageList = ilist;
			lv.Name = "lv";
			lv.UseCompatibleStateImageBehavior = false;
			lv.SelectedIndexChanged += new EventHandler(SelectSim);
			//
			// ilist
			//
			ilist.ColorDepth = ColorDepth.Depth32Bit;
			resources.ApplyResources(ilist, "ilist");
			ilist.TransparentColor = Color.Transparent;
			//
			// panel2
			//
			resources.ApplyResources(panel2, "panel2");
			panel2.BackColor = SystemColors.AppWorkspace;
			panel2.Controls.Add(label27);
			panel2.ForeColor = SystemColors.ActiveCaptionText;
			panel2.Name = "panel2";
			//
			// label27
			//
			resources.ApplyResources(label27, "label27");
			label27.Name = "label27";
			//
			// NgbhForm
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(ngbhPanel);
			Name = "NgbhForm";
			ngbhPanel.ResumeLayout(false);
			ngbhPanel.PerformLayout();
			gbmem.ResumeLayout(false);
			gbmem.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pb).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		private Panel panel2;
		private Label label27;
		internal Panel ngbhPanel;
		internal ListView lv;
		internal ImageList ilist;
		private Label label1;
		private TextBox tbFlag;
		private CheckBox cbvis;
		private CheckBox cbaction;
		private TextBox tbguid;
		private Label label2;
		internal ComboBox cbguid;
		internal ComboBox cbsub;
		private TextBox tbsub;
		private Label label3;
		private TextBox lbdata;
		private Button button1;
		private TextBox tbsubid;
		internal GroupBox gbmem;
		private LinkLabel linkLabel1;
		private LinkLabel lladd;
		private PictureBox pb;
		internal ComboBox cbown;
		private TextBox tbown;
		private Label label4;
		private Label lbname;
		private ImageList memilist;
		internal ListView lbmem;
		private LinkLabel linkLabel2;
		internal Button btdown;
		internal Button btup;
		internal ComboBox cbtype;
		private Label label5;
		private TextBox tbUnk;
		private TextBox tbval;
		private Label label6;

		internal IFileWrapperSaveExtension wrapper;

		protected void AddItem(NgbhItem item)
		{
			if (item == null)
			{
				return;
			}

			ListViewItem lvi = new ListViewItem
			{
				Text = item.ToString(),
				Tag = item
			};

			if (item.MemoryCacheItem.Icon != null)
			{
				lvi.ImageIndex = memilist.Images.Count;

				memilist.Images.Add(item.MemoryCacheItem.Icon);
			}

			lbmem.Items.Add(lvi);
		}

		private void tbval_TextChanged(object sender, EventArgs e)
		{
			if (tbFlag.Tag != null)
			{
				return;
			}

			try
			{
				GetSelectedItem().Value = Helper.WindowsRegistry.Config.HiddenMode
					? Helper.StringToUInt16(
						tbval.Text,
						GetSelectedItem().Value,
						16
					)
					: Helper.StringToUInt16(
						tbval.Text,
						GetSelectedItem().Value,
						10
					);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
		}

		private void tbUnk_TextChanged(object sender, EventArgs e)
		{
			if (tbFlag.Tag != null)
			{
				return;
			}

			try
			{
				GetSelectedItem().InventoryNumber = Helper.StringToUInt32(
					tbUnk.Text,
					GetSelectedItem().InventoryNumber,
					16
				);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
		}

		private void ItemUp(object sender, EventArgs e)
		{
			if (lbmem.SelectedItems.Count == 0)
			{
				return;
			}

			int SelectedIndex = lbmem.SelectedItems[0].Index;
			if (SelectedIndex < 1)
			{
				return;
			}

			ListViewItem lvi = lbmem.Items[SelectedIndex];

			lbmem.Items[SelectedIndex] = (ListViewItem)
				lbmem.Items[SelectedIndex - 1].Clone();
			lbmem.Items[SelectedIndex - 1] = (ListViewItem)lvi.Clone();
			lbmem.Items[SelectedIndex - 1].Selected = true;

			try
			{
				//change also in the Items List
				Ngbh wrp = (Ngbh)wrapper;
				SDesc sdesc = (SDesc)
					lv.SelectedItems[0].Tag;
				NgbhSlot slot = wrp.Sims.GetInstanceSlot(sdesc.Instance);
				(slot.ItemsB[SelectedIndex], slot.ItemsB[SelectedIndex - 1]) = (slot.ItemsB[SelectedIndex - 1], slot.ItemsB[SelectedIndex]);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
		}

		private void ItemDown(object sender, EventArgs e)
		{
			if (lbmem.SelectedItems.Count == 0)
			{
				return;
			}

			int SelectedIndex = lbmem.SelectedItems[0].Index;
			if (SelectedIndex < 0)
			{
				return;
			}

			if (SelectedIndex > lbmem.Items.Count - 2)
			{
				return;
			}

			ListViewItem lvi = lbmem.Items[SelectedIndex];
			lbmem.Items[SelectedIndex] = (ListViewItem)
				lbmem.Items[SelectedIndex + 1].Clone();
			lbmem.Items[SelectedIndex + 1] = (ListViewItem)lvi.Clone();
			lbmem.Items[SelectedIndex + 1].Selected = true;

			try
			{
				//change also in the Items List
				Ngbh wrp = (Ngbh)wrapper;
				SDesc sdesc = (SDesc)
					lv.SelectedItems[0].Tag;
				NgbhSlot slot = wrp.Sims.GetInstanceSlot(sdesc.Instance);
				(slot.ItemsB[SelectedIndex], slot.ItemsB[SelectedIndex + 1]) = (slot.ItemsB[SelectedIndex + 1], slot.ItemsB[SelectedIndex]);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
		}

		protected void UpdateMemItem(NgbhItem item)
		{
			if (lbmem.SelectedItems.Count > 0)
			{
				lbmem.SelectedItems[0].Text = item.ToString();

				if (
					item.MemoryCacheItem.Icon != null
					&& lbmem.SelectedItems[0].ImageIndex >= 0
				)
				{
					int id = lbmem.SelectedItems[0].ImageIndex;
					lbmem.SelectedItems[0].ImageIndex = -1;
					Image simg = item.MemoryCacheItem.Icon;
					Bitmap img = new Bitmap(
						memilist.ImageSize.Width,
						memilist.ImageSize.Height
					);
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

		private void IOwn(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lv.SelectedItems.Count == 0)
			{
				return;
			}

			try
			{
				SDesc sdesc = (SDesc)
					lv.SelectedItems[0].Tag;

				cbown.SelectedIndex = 0;
				for (int i = 0; i < cbown.Items.Count; i++)
				{
					Interfaces.IAlias a = (Interfaces.IAlias)cbown.Items[i];
					if (a.Tag == null)
					{
						continue;
					}

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
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
		}

		private void SelectSim(object sender, EventArgs e)
		{
			gbmem.Enabled = false;
			memilist.Images.Clear();
			if (lv.SelectedItems.Count < 1)
			{
				return;
			}

			gbmem.Enabled = true;

			Cursor = Cursors.WaitCursor;
			try
			{
				lbname.Text = lv.SelectedItems[0].Text;
				SDesc sdesc = (SDesc)
					lv.SelectedItems[0].Tag;
				lbmem.Items.Clear();

				Ngbh wrp = (Ngbh)wrapper;
				NgbhItems items = wrp.GetItems(
					(NeighborhoodSlots)cbtype.SelectedIndex,
					sdesc.Instance
				);

				if (items != null)
				{
					foreach (NgbhItem item in items)
					{
						AddItem(item);
					}
				}

				if (lbmem.Items.Count > 0)
				{
					lbmem.Items[0].Selected = true;
				}
			}
			catch (Exception ex)
			{
				Cursor = Cursors.Default;
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
			Cursor = Cursors.Default;
		}

		protected NgbhItem GetSelectedItem()
		{
			return lbmem.SelectedItems.Count == 0
				? new NgbhItem(
					new NgbhSlot(
						(Ngbh)wrapper,
						(NeighborhoodSlots)cbtype.SelectedValue
					)
				)
				: (NgbhItem)lbmem.SelectedItems[0].Tag;
		}

		private void SelectMemory(object sender, EventArgs e)
		{
			tbFlag.Tag = true;
			cbvis.Checked = GetSelectedItem().Flags.IsVisible;
			cbaction.Checked = GetSelectedItem().Flags.IsControler;
			tbFlag.Text = "0x" + Helper.HexString(GetSelectedItem().Flags.Value);

			tbUnk.Enabled =
				(uint)GetSelectedItem().ParentSlot.Version
				>= (uint)NgbhVersion.Nightlife;
			tbUnk.Text =
				"0x" + Helper.HexString(GetSelectedItem().InventoryNumber);
			tbval.Text = Helper.WindowsRegistry.Config.HiddenMode ? "0x" + Helper.HexString(GetSelectedItem().Value) : GetSelectedItem().Value.ToString();

			tbFlag.Tag = null;

			tbguid.Tag = true;
			tbguid.Text = "0x" + Helper.HexString(GetSelectedItem().Guid);
			cbguid.SelectedIndex = 0;
			for (int i = 0; i < cbguid.Items.Count; i++)
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
			tbsub.Text = "0x" + Helper.HexString(GetSelectedItem().SimInstance);
			tbsubid.Text = "0x" + Helper.HexString(GetSelectedItem().SimID);
			cbsub.SelectedIndex = 0;
			for (int i = 0; i < cbsub.Items.Count; i++)
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
			tbown.Text = "0x" + Helper.HexString(GetSelectedItem().OwnerInstance);
			cbown.SelectedIndex = 0;
			for (int i = 0; i < cbown.Items.Count; i++)
			{
				Interfaces.IAlias a = (Interfaces.IAlias)cbown.Items[i];
				if (a.Tag == null)
				{
					continue;
				}

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
			foreach (ushort s in GetSelectedItem().Data)
			{
				lbdata.Text += Helper.HexString(s) + " ";
			}

			lbdata.Tag = null;

			pb.Image = GetSelectedItem().MemoryCacheItem.Icon;
		}

		private void ChgFlags(object sender, EventArgs e)
		{
			if (tbFlag.Tag != null)
			{
				return;
			}

			tbFlag.Tag = true;
			GetSelectedItem().Flags.IsVisible = cbvis.Checked;
			GetSelectedItem().Flags.IsControler = cbaction.Checked;
			tbFlag.Text = "0x" + Helper.HexString(GetSelectedItem().Flags.Value);
			UpdateMemItem(GetSelectedItem());
			tbFlag.Tag = null;
		}

		private void ChgFlag(object sender, EventArgs e)
		{
			if (tbFlag.Tag != null)
			{
				return;
			}

			try
			{
				GetSelectedItem().Flags.Value = Convert.ToUInt16(tbFlag.Text, 16);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
		}

		private void ChgGuidItem(object sender, EventArgs e)
		{
			if (tbguid.Tag != null)
			{
				return;
			}

			if (cbguid.SelectedIndex < 1)
			{
				return;
			}

			Interfaces.IAlias a = (Interfaces.IAlias)cbguid.Items[cbguid.SelectedIndex];
			tbguid.Text = "0x" + Helper.HexString(a.Id);
		}

		private void ChgGuid(object sender, EventArgs e)
		{
			if (tbguid.Tag != null)
			{
				return;
			}

			try
			{
				GetSelectedItem().Guid = Convert.ToUInt32(tbguid.Text, 16);
				UpdateMemItem(GetSelectedItem());
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
		}

		private void ChgSubjectItem(object sender, EventArgs e)
		{
			if (tbsub.Tag != null)
			{
				return;
			}

			if (cbsub.SelectedIndex < 1)
			{
				return;
			}

			Interfaces.IAlias a = (Interfaces.IAlias)cbsub.Items[cbsub.SelectedIndex];
			tbsubid.Text = "0x" + Helper.HexString(a.Id);
			tbsub.Text = a.Tag != null ? "0x" + Helper.HexString((ushort)a.Tag[0]) : "0x0000";
		}

		private void ChgSubject(object sender, EventArgs e)
		{
			if (tbsub.Tag != null)
			{
				return;
			}

			try
			{
				GetSelectedItem().SimInstance = Convert.ToUInt16(tbsub.Text, 16);
				UpdateMemItem(GetSelectedItem());
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
		}

		private void ChgSubjectID(object sender, EventArgs e)
		{
			if (tbsub.Tag != null)
			{
				return;
			}

			try
			{
				GetSelectedItem().SimID = Convert.ToUInt32(tbsubid.Text, 16);
				UpdateMemItem(GetSelectedItem());
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
		}

		private void ChgOwnerItem(object sender, EventArgs e)
		{
			if (tbown.Tag != null)
			{
				return;
			}

			if (cbown.SelectedIndex < 1)
			{
				return;
			}

			Interfaces.IAlias a = (Interfaces.IAlias)cbown.Items[cbown.SelectedIndex];
			tbown.Text = a.Tag != null ? "0x" + Helper.HexString((ushort)a.Tag[0]) : "0x0000";
		}

		private void ChgOwner(object sender, EventArgs e)
		{
			if (tbown.Tag != null)
			{
				return;
			}

			try
			{
				GetSelectedItem().OwnerInstance = Convert.ToUInt16(tbown.Text, 16);
				UpdateMemItem(GetSelectedItem());
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
		}

		private void ChgData(object sender, EventArgs e)
		{
			if (lbdata.Tag != null)
			{
				return;
			}

			string[] tokens = lbdata.Text.Split(" ".ToCharArray());
			ushort[] data = new ushort[tokens.Length];

			try
			{
				for (int i = 0; i < tokens.Length; i++)
				{
					data[i] = tokens[i].Trim() != "" ? Convert.ToUInt16(tokens[i], 16) : (ushort)0;
				}

				GetSelectedItem().Data = data;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
		}

		private void Commit(object sender, EventArgs e)
		{
			try
			{
				Ngbh wrp = (Ngbh)wrapper;
				wrp.SynchronizeUserData();
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

		private void DeleteItem(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lbmem.SelectedItems.Count == 0)
			{
				return;
			}

			if (cbtype.SelectedIndex % 2 == 1)
			{
				GetSelectedItem().RemoveFromParentB();
			}
			else
			{
				GetSelectedItem().RemoveFromParentA();
			}

			lbmem.Items.Remove(lbmem.SelectedItems[0]);
		}

		private void AddItem(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lv.SelectedItems.Count <= 0)
			{
				return;
			}

			Cursor = Cursors.WaitCursor;
			try
			{
				SDesc sdesc = (SDesc)
					lv.SelectedItems[0].Tag;

				Ngbh wrp = (Ngbh)wrapper;
				NgbhSlot slot = wrp.GetSlots(
						(NeighborhoodSlots)cbtype.SelectedIndex
					)
					.GetInstanceSlot(sdesc.Instance, true);
				if (slot != null)
				{
					NgbhItem item = slot.GetItems(
							(NeighborhoodSlots)cbtype.SelectedIndex
						)
						.AddNew();

					item.PutValue(0x01, 0x07CD);
					item.PutValue(0x02, 0x0007);
					item.PutValue(0x0B, 0);
					item.Flags.IsVisible = true;
					item.Flags.IsControler = false;
					AddItem(item);
					lbmem.Items[lbmem.Items.Count - 1].Selected = true;
				}
			}
			catch (Exception ex)
			{
				Cursor = Cursors.Default;
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
			Cursor = Cursors.Default;
		}
	}
}
