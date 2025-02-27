/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Drawing;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

using Bhav = SimPe.PackedFiles.Wrapper.Bhav;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for TPRPForm.
	/// </summary>
	public class TPRPForm : System.Windows.Forms.Form, IPackedFileUI
	{
		#region Form variables

		private System.Windows.Forms.Label lbFilename;
		private System.Windows.Forms.TextBox tbFilename;
		private System.Windows.Forms.Button btnStrDelete;
		private System.Windows.Forms.Button btnStrAdd;
		private System.Windows.Forms.Label lbLabel;
		private System.Windows.Forms.TextBox tbLabel;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnCommit;
		private System.Windows.Forms.Label lbVersion;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpParams;
		private System.Windows.Forms.TabPage tpLocals;
		private System.Windows.Forms.Panel tprpPanel;
		private System.Windows.Forms.TextBox tbVersion;
		private System.Windows.Forms.ListView lvParams;
		private System.Windows.Forms.ListView lvLocals;
		private System.Windows.Forms.ColumnHeader chPID;
		private System.Windows.Forms.ColumnHeader chPLabel;
		private System.Windows.Forms.ColumnHeader chLID;
		private System.Windows.Forms.ColumnHeader chLLabel;
		private System.Windows.Forms.Button btnStrPrev;
		private System.Windows.Forms.Button btnStrNext;
		private System.Windows.Forms.Button btnTabNext;
		private System.Windows.Forms.Button btnTabPrev;
		private pjse.pjse_banner pjse_banner1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public TPRPForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			TextBox[] t = { tbFilename, tbLabel };
			alText = new ArrayList(t);

			TextBox[] dw = { tbVersion };
			alHex32 = new ArrayList(dw);

			pjse.FileTable.GFT.FiletableRefresh += new EventHandler(
				GFT_FiletableRefresh
			);
			if (SimPe.Helper.WindowsRegistry.UseBigIcons)
			{
				this.lvParams.Font = new System.Drawing.Font(
					"Microsoft Sans Serif",
					11F
				);
				this.lvLocals.Font = new System.Drawing.Font(
					"Microsoft Sans Serif",
					11F
				);
			}
		}

		void GFT_FiletableRefresh(object sender, EventArgs e)
		{
			pjse_banner1.SiblingEnabled =
				wrapper != null && wrapper.SiblingResource(Bhav.Bhavtype) != null;
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

		#region Controller
		private TPRP wrapper = null;
		private bool setHandler = false;
		private bool internalchg = false;

		private ArrayList alText = null;
		private ArrayList alHex32 = null;

		private int index = -1;
		private int tab = 0;
		private TPRPItem origItem = null;
		private TPRPItem currentItem = null;

		private int InitialTab
		{
			get
			{
				XmlRegistryKey rkf =
					Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey("PJSE\\TPRP");
				object o = rkf.GetValue("initialTab", 1);
				return Convert.ToInt16(o);
			}
			set
			{
				XmlRegistryKey rkf =
					Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey("PJSE\\TPRP");
				rkf.SetValue("initialTab", value);
			}
		}

		private bool hex32_IsValid(object sender)
		{
			if (alHex32.IndexOf(sender) < 0)
			{
				throw new Exception(
					"hex32_IsValid not applicable to control " + sender.ToString()
				);
			}

			try
			{
				Convert.ToUInt32(((TextBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		private void doTextOnly()
		{
			tprpPanel.SuspendLayout();
			tprpPanel.Controls.Clear();
			tprpPanel.Controls.Add(this.pjse_banner1);
			tprpPanel.Controls.Add(this.lbFilename);
			tbFilename.ReadOnly = true;
			tbFilename.Text = wrapper.FileName;
			tprpPanel.Controls.Add(this.tbFilename);

			Label lb = new Label();
			lb.AutoSize = true;
			lb.Location = new Point(0, tbFilename.Bottom + 6);
			lb.Text = pjse.Localization.GetString("tprpTextOnly");

			TextBox tb = new TextBox();
			tb.Anchor =
				AnchorStyles.Top
				| AnchorStyles.Bottom
				| AnchorStyles.Left
				| AnchorStyles.Right;
			tb.Multiline = true;
			tb.Location = new Point(0, lb.Bottom + 6);
			tb.ReadOnly = true;
			tb.ScrollBars = ScrollBars.Both;
			tb.Size = tprpPanel.Size;
			tb.Height -= tb.Top;

			tb.Text = getText(wrapper.StoredData);

			tprpPanel.Controls.Add(lb);
			tprpPanel.Controls.Add(tb);
			tprpPanel.ResumeLayout(true);
		}

		private string getText(System.IO.BinaryReader br)
		{
			br.BaseStream.Seek(0x50, System.IO.SeekOrigin.Begin); // Skip filename, header and item count
			string s = "";
			bool hadNL = true;
			while (br.BaseStream.Position < br.BaseStream.Length)
			{
				byte b = br.ReadByte();
				if (b < 0x20 || b > 0x7e)
				{
					if (!hadNL)
					{
						s += "\r\n";
						hadNL = true;
					}
				}
				else
				{
					s += Convert.ToChar(b);
					hadNL = false;
				}
			}
			return s;
		}

		private ListView lvCurrent => (ListView)(
					(tabControl1.SelectedIndex != 0) ? lvLocals : lvParams
				);

		private void LVAdd(ListView lv, TPRPItem item)
		{
			string[] s =
			{
				"0x" + lv.Items.Count.ToString("X") + " (" + lv.Items.Count + ")",
				item.Label,
			};
			lv.Items.Add(new ListViewItem(s));
		}

		private void updateLists()
		{
			wrapper.CleanUp();

			index = -1;

			lvParams.Items.Clear();
			lvLocals.Items.Clear();
			foreach (TPRPItem item in wrapper)
			{
				LVAdd((item is TPRPLocalLabel) ? lvLocals : lvParams, item);
			}
		}

		private void setTab(int l)
		{
			internalchg = true;
			InitialTab = this.tabControl1.SelectedIndex = tab = l;
			internalchg = false;

			if (this.lvCurrent.SelectedIndices.Count == 0)
			{
				index = -1;
				setIndex(lvCurrent.Items.Count > 0 ? 0 : -1);
			}
			else
			{
				index = this.lvCurrent.SelectedIndices[0];
			}

			displayTPRPItem();
		}

		private void setIndex(int i)
		{
			internalchg = true;
			if (i >= 0)
			{
				this.lvCurrent.Items[i].Selected = true;
			}
			else if (index >= 0)
			{
				this.lvCurrent.Items[index].Selected = false;
			}

			internalchg = false;

			if (this.lvCurrent.SelectedItems.Count > 0)
			{
				if (this.lvCurrent.Focused)
				{
					this.lvCurrent.SelectedItems[0].Focused = true;
				}

				this.lvCurrent.SelectedItems[0].EnsureVisible();
			}

			if (index == i)
			{
				return;
			}

			index = i;
			displayTPRPItem();
		}

		private void displayTPRPItem()
		{
			currentItem =
				(index < 0)
					? null
					: wrapper[tabControl1.SelectedIndex.Equals(1), index];

			internalchg = true;
			if (currentItem != null)
			{
				origItem = currentItem.Clone();
				this.tbLabel.Text = currentItem.Label;
				this.btnStrDelete.Enabled = this.tbLabel.Enabled = true;
				this.tbLabel.SelectAll();
			}
			else
			{
				origItem = null;
				this.tbLabel.Text = "";
				this.btnStrDelete.Enabled = this.tbLabel.Enabled = false;
			}
			this.btnStrPrev.Enabled = (index > 0);
			this.btnStrNext.Enabled = (index < lvCurrent.Items.Count - 1);
			this.btnTabPrev.Enabled = tab > 0;
			this.btnTabNext.Enabled = tab < this.tabControl1.TabCount - 1;

			internalchg = false;

			this.btnCancel.Enabled = false;
		}

		private void TPRPItemAdd()
		{
			bool savedstate = internalchg;
			internalchg = true;

			TPRPItem newItem = tabControl1.SelectedIndex.Equals(1)
				? (TPRPItem)new TPRPLocalLabel(wrapper)
				: (TPRPItem)new TPRPParamLabel(wrapper);

			try
			{
				wrapper.Add(newItem);
				LVAdd(lvCurrent, newItem);
			}
			catch { }

			internalchg = savedstate;

			setIndex(lvCurrent.Items.Count - 1);
		}

		private void TPRPItemDelete()
		{
			bool savedstate = internalchg;
			internalchg = true;

			wrapper.Remove(currentItem);
			int i = index;
			updateLists();

			internalchg = savedstate;

			setIndex((i >= lvCurrent.Items.Count) ? lvCurrent.Items.Count - 1 : i);
		}

		private void Commit()
		{
			bool savedstate = internalchg;
			internalchg = true;

			try
			{
				wrapper.SynchronizeUserData();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					pjse.Localization.GetString("errwritingfile"),
					ex
				);
			}

			btnCommit.Enabled = wrapper.Changed;

			int i = index;
			updateLists();

			internalchg = savedstate;

			setIndex((i >= lvCurrent.Items.Count) ? lvCurrent.Items.Count - 1 : i);
		}

		private void Cancel()
		{
			bool savedstate = internalchg;
			internalchg = true;

			lvCurrent.SelectedItems[0].SubItems[1].Text = currentItem.Label =
				origItem.Label;

			internalchg = savedstate;

			displayTPRPItem();
		}

		#endregion

		#region IPackedFileUI Member
		/// <summary>
		/// Returns the Control that will be displayed within SimPe
		/// </summary>
		public Control GUIHandle => tprpPanel;

		/// <summary>
		/// Called by the AbstractWrapper when the file should be displayed to the user.
		/// </summary>
		/// <param name="wrp">Reference to the wrapper to be displayed.</param>
		public void UpdateGUI(IFileWrapper wrp)
		{
			wrapper = (TPRP)wrp;
			WrapperChanged(wrapper, null);
			pjse_banner1.SiblingEnabled =
				wrapper.SiblingResource(Bhav.Bhavtype) != null;

			if (!wrapper.TextOnly)
			{
				internalchg = true;
				updateLists();
				internalchg = false;

				setTab(InitialTab);
			}

			if (!setHandler)
			{
				wrapper.WrapperChanged += new System.EventHandler(this.WrapperChanged);
				setHandler = true;
			}
		}

		private void WrapperChanged(object sender, System.EventArgs e)
		{
			if (wrapper.TextOnly)
			{
				doTextOnly();
				return;
			}
			this.btnCommit.Enabled = wrapper.Changed;
			if (sender.Equals(currentItem))
			{
				this.btnCancel.Enabled = true;
			}

			if (internalchg)
			{
				return;
			}

			if (sender.Equals(wrapper))
			{
				internalchg = true;
				this.Text = tbFilename.Text = wrapper.FileName;
				this.tbVersion.Text = "0x" + SimPe.Helper.HexString(wrapper.Version);
				internalchg = false;
			}
			else if (!sender.Equals(currentItem))
			{
				updateLists();
			}
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(TPRPForm));
			this.btnCommit = new System.Windows.Forms.Button();
			this.tprpPanel = new System.Windows.Forms.Panel();
			this.pjse_banner1 = new pjse.pjse_banner();
			this.btnTabNext = new System.Windows.Forms.Button();
			this.btnTabPrev = new System.Windows.Forms.Button();
			this.btnStrPrev = new System.Windows.Forms.Button();
			this.btnStrNext = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpParams = new System.Windows.Forms.TabPage();
			this.lvParams = new System.Windows.Forms.ListView();
			this.chPID = new System.Windows.Forms.ColumnHeader();
			this.chPLabel = new System.Windows.Forms.ColumnHeader();
			this.tpLocals = new System.Windows.Forms.TabPage();
			this.lvLocals = new System.Windows.Forms.ListView();
			this.chLID = new System.Windows.Forms.ColumnHeader();
			this.chLLabel = new System.Windows.Forms.ColumnHeader();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tbLabel = new System.Windows.Forms.TextBox();
			this.btnStrDelete = new System.Windows.Forms.Button();
			this.btnStrAdd = new System.Windows.Forms.Button();
			this.lbVersion = new System.Windows.Forms.Label();
			this.tbVersion = new System.Windows.Forms.TextBox();
			this.tbFilename = new System.Windows.Forms.TextBox();
			this.lbFilename = new System.Windows.Forms.Label();
			this.lbLabel = new System.Windows.Forms.Label();
			this.tprpPanel.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tpParams.SuspendLayout();
			this.tpLocals.SuspendLayout();
			this.SuspendLayout();
			//
			// btnCommit
			//
			resources.ApplyResources(this.btnCommit, "btnCommit");
			this.btnCommit.Name = "btnCommit";
			this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
			//
			// tprpPanel
			//
			resources.ApplyResources(this.tprpPanel, "tprpPanel");
			this.tprpPanel.Controls.Add(this.pjse_banner1);
			this.tprpPanel.Controls.Add(this.btnTabNext);
			this.tprpPanel.Controls.Add(this.btnTabPrev);
			this.tprpPanel.Controls.Add(this.btnStrPrev);
			this.tprpPanel.Controls.Add(this.btnStrNext);
			this.tprpPanel.Controls.Add(this.tabControl1);
			this.tprpPanel.Controls.Add(this.btnCancel);
			this.tprpPanel.Controls.Add(this.tbLabel);
			this.tprpPanel.Controls.Add(this.btnStrDelete);
			this.tprpPanel.Controls.Add(this.btnStrAdd);
			this.tprpPanel.Controls.Add(this.lbVersion);
			this.tprpPanel.Controls.Add(this.tbVersion);
			this.tprpPanel.Controls.Add(this.tbFilename);
			this.tprpPanel.Controls.Add(this.lbFilename);
			this.tprpPanel.Controls.Add(this.btnCommit);
			this.tprpPanel.Controls.Add(this.lbLabel);
			this.tprpPanel.Name = "tprpPanel";
			//
			// pjse_banner1
			//
			resources.ApplyResources(this.pjse_banner1, "pjse_banner1");
			this.pjse_banner1.Name = "pjse_banner1";
			this.pjse_banner1.SiblingVisible = true;
			this.pjse_banner1.SiblingClick += new System.EventHandler(
				this.pjse_banner1_SiblingClick
			);
			//
			// btnTabNext
			//
			resources.ApplyResources(this.btnTabNext, "btnTabNext");
			this.btnTabNext.Name = "btnTabNext";
			this.btnTabNext.TabStop = false;
			this.btnTabNext.Click += new System.EventHandler(this.btnTabNext_Click);
			//
			// btnTabPrev
			//
			resources.ApplyResources(this.btnTabPrev, "btnTabPrev");
			this.btnTabPrev.Name = "btnTabPrev";
			this.btnTabPrev.TabStop = false;
			this.btnTabPrev.Click += new System.EventHandler(this.btnTabPrev_Click);
			//
			// btnStrPrev
			//
			resources.ApplyResources(this.btnStrPrev, "btnStrPrev");
			this.btnStrPrev.Name = "btnStrPrev";
			this.btnStrPrev.TabStop = false;
			this.btnStrPrev.Click += new System.EventHandler(this.btnStrPrev_Click);
			//
			// btnStrNext
			//
			resources.ApplyResources(this.btnStrNext, "btnStrNext");
			this.btnStrNext.Name = "btnStrNext";
			this.btnStrNext.TabStop = false;
			this.btnStrNext.Click += new System.EventHandler(this.btnStrNext_Click);
			//
			// tabControl1
			//
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.Controls.Add(this.tpParams);
			this.tabControl1.Controls.Add(this.tpLocals);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(
				this.tabControl1_SelectedIndexChanged
			);
			//
			// tpParams
			//
			this.tpParams.Controls.Add(this.lvParams);
			resources.ApplyResources(this.tpParams, "tpParams");
			this.tpParams.Name = "tpParams";
			//
			// lvParams
			//
			this.lvParams.Columns.AddRange(
				new System.Windows.Forms.ColumnHeader[] { this.chPID, this.chPLabel }
			);
			resources.ApplyResources(this.lvParams, "lvParams");
			this.lvParams.FullRowSelect = true;
			this.lvParams.GridLines = true;
			this.lvParams.HeaderStyle = System
				.Windows
				.Forms
				.ColumnHeaderStyle
				.Nonclickable;
			this.lvParams.HideSelection = false;
			this.lvParams.Items.AddRange(
				new System.Windows.Forms.ListViewItem[]
				{
					(
						(System.Windows.Forms.ListViewItem)(
							resources.GetObject("lvParams.Items")
						)
					),
				}
			);
			this.lvParams.MultiSelect = false;
			this.lvParams.Name = "lvParams";
			this.lvParams.UseCompatibleStateImageBehavior = false;
			this.lvParams.View = System.Windows.Forms.View.Details;
			this.lvParams.ItemActivate += new System.EventHandler(
				this.ListView_ItemActivate
			);
			this.lvParams.SelectedIndexChanged += new System.EventHandler(
				this.ListView_SelectedIndexChanged
			);
			//
			// chPID
			//
			resources.ApplyResources(this.chPID, "chPID");
			//
			// chPLabel
			//
			resources.ApplyResources(this.chPLabel, "chPLabel");
			//
			// tpLocals
			//
			this.tpLocals.Controls.Add(this.lvLocals);
			resources.ApplyResources(this.tpLocals, "tpLocals");
			this.tpLocals.Name = "tpLocals";
			//
			// lvLocals
			//
			this.lvLocals.Columns.AddRange(
				new System.Windows.Forms.ColumnHeader[] { this.chLID, this.chLLabel }
			);
			resources.ApplyResources(this.lvLocals, "lvLocals");
			this.lvLocals.FullRowSelect = true;
			this.lvLocals.GridLines = true;
			this.lvLocals.HeaderStyle = System
				.Windows
				.Forms
				.ColumnHeaderStyle
				.Nonclickable;
			this.lvLocals.HideSelection = false;
			this.lvLocals.MultiSelect = false;
			this.lvLocals.Name = "lvLocals";
			this.lvLocals.UseCompatibleStateImageBehavior = false;
			this.lvLocals.View = System.Windows.Forms.View.Details;
			this.lvLocals.ItemActivate += new System.EventHandler(
				this.ListView_ItemActivate
			);
			this.lvLocals.SelectedIndexChanged += new System.EventHandler(
				this.ListView_SelectedIndexChanged
			);
			//
			// chLID
			//
			resources.ApplyResources(this.chLID, "chLID");
			//
			// chLLabel
			//
			resources.ApplyResources(this.chLLabel, "chLLabel");
			//
			// btnCancel
			//
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			//
			// tbLabel
			//
			resources.ApplyResources(this.tbLabel, "tbLabel");
			this.tbLabel.Name = "tbLabel";
			this.tbLabel.TextChanged += new System.EventHandler(
				this.tbText_TextChanged
			);
			this.tbLabel.Validated += new System.EventHandler(this.tbText_Enter);
			this.tbLabel.Enter += new System.EventHandler(this.tbText_Enter);
			//
			// btnStrDelete
			//
			resources.ApplyResources(this.btnStrDelete, "btnStrDelete");
			this.btnStrDelete.Name = "btnStrDelete";
			this.btnStrDelete.Click += new System.EventHandler(this.btnStrDelete_Click);
			//
			// btnStrAdd
			//
			resources.ApplyResources(this.btnStrAdd, "btnStrAdd");
			this.btnStrAdd.Name = "btnStrAdd";
			this.btnStrAdd.Click += new System.EventHandler(this.btnStrAdd_Click);
			//
			// lbVersion
			//
			resources.ApplyResources(this.lbVersion, "lbVersion");
			this.lbVersion.Name = "lbVersion";
			//
			// tbVersion
			//
			resources.ApplyResources(this.tbVersion, "tbVersion");
			this.tbVersion.Name = "tbVersion";
			this.tbVersion.ReadOnly = true;
			this.tbVersion.TextChanged += new System.EventHandler(
				this.hex32_TextChanged
			);
			this.tbVersion.Validated += new System.EventHandler(this.hex32_Validated);
			this.tbVersion.Enter += new System.EventHandler(this.tbText_Enter);
			this.tbVersion.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex32_Validating
			);
			//
			// tbFilename
			//
			resources.ApplyResources(this.tbFilename, "tbFilename");
			this.tbFilename.Name = "tbFilename";
			this.tbFilename.TextChanged += new System.EventHandler(
				this.tbText_TextChanged
			);
			this.tbFilename.Validated += new System.EventHandler(this.tbText_Enter);
			this.tbFilename.Enter += new System.EventHandler(this.tbText_Enter);
			//
			// lbFilename
			//
			resources.ApplyResources(this.lbFilename, "lbFilename");
			this.lbFilename.Name = "lbFilename";
			//
			// lbLabel
			//
			resources.ApplyResources(this.lbLabel, "lbLabel");
			this.lbLabel.Name = "lbLabel";
			//
			// TPRPForm
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.tprpPanel);
			this.FormBorderStyle = System
				.Windows
				.Forms
				.FormBorderStyle
				.SizableToolWindow;
			this.Name = "TPRPForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.tprpPanel.ResumeLayout(false);
			this.tprpPanel.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tpParams.ResumeLayout(false);
			this.tpLocals.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		#endregion

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setTab(tabControl1.SelectedIndex);
		}

		private void ListView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setIndex(
				(this.lvCurrent.SelectedIndices.Count > 0)
					? this.lvCurrent.SelectedIndices[0]
					: -1
			);
		}

		private void ListView_ItemActivate(object sender, System.EventArgs e)
		{
			this.tbLabel.Focus();
		}

		private void btnCommit_Click(object sender, System.EventArgs e)
		{
			this.Commit();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Cancel();
			this.tbLabel.SelectAll();
			this.tbLabel.Focus();
		}

		private void pjse_banner1_SiblingClick(object sender, EventArgs e)
		{
			Bhav bhav = (Bhav)wrapper.SiblingResource(Bhav.Bhavtype);
			if (bhav == null)
			{
				return;
			}

			if (bhav.Package != wrapper.Package)
			{
				DialogResult dr = MessageBox.Show(
					Localization.GetString("OpenOtherPkg"),
					pjse_banner1.TitleText,
					MessageBoxButtons.YesNo
				);
				if (dr != DialogResult.Yes)
				{
					return;
				}
			}
			SimPe.RemoteControl.OpenPackedFile(bhav.FileDescriptor, bhav.Package);
		}

		private void btnStrPrev_Click(object sender, System.EventArgs e)
		{
			setIndex(index - 1);
		}

		private void btnStrNext_Click(object sender, System.EventArgs e)
		{
			setIndex(index + 1);
		}

		private void btnTabPrev_Click(object sender, System.EventArgs e)
		{
			this.setTab(tab - 1);
		}

		private void btnTabNext_Click(object sender, System.EventArgs e)
		{
			this.setTab(tab + 1);
		}

		private void btnStrAdd_Click(object sender, System.EventArgs e)
		{
			this.TPRPItemAdd();
			this.tbLabel.SelectAll();
			this.tbLabel.Focus();
		}

		private void btnStrDelete_Click(object sender, System.EventArgs e)
		{
			this.TPRPItemDelete();
		}

		private void tbText_Enter(object sender, System.EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		private void tbText_TextChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			internalchg = true;
			switch (alText.IndexOf(sender))
			{
				case 0:
					wrapper.FileName = ((TextBox)sender).Text;
					break;
				case 1:
					lvCurrent.SelectedItems[0].SubItems[1].Text = currentItem.Label = (
						(TextBox)sender
					).Text;
					break;
			}
			internalchg = false;
		}

		private void hex32_TextChanged(object sender, System.EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!hex32_IsValid(sender))
			{
				return;
			}

			internalchg = true;
			uint val = Convert.ToUInt32(((TextBox)sender).Text, 16);
			switch (alHex32.IndexOf(sender))
			{
				case 0:
					wrapper.Version = val;
					break;
			}
			internalchg = false;
		}

		private void hex32_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (hex32_IsValid(sender))
			{
				return;
			}

			e.Cancel = true;
			hex32_Validated(sender, null);
		}

		private void hex32_Validated(object sender, System.EventArgs e)
		{
			uint val = 0;
			switch (alHex32.IndexOf(sender))
			{
				case 0:
					val = wrapper.Version;
					break;
			}

			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = "0x" + Helper.HexString(val);
			internalchg = origstate;
		}
	}
}
