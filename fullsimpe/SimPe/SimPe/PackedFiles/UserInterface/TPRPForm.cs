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
	public class TPRPForm : Form, IPackedFileUI
	{
		#region Form variables

		private Label lbFilename;
		private TextBox tbFilename;
		private Button btnStrDelete;
		private Button btnStrAdd;
		private Label lbLabel;
		private TextBox tbLabel;
		private Button btnCancel;
		private Button btnCommit;
		private Label lbVersion;
		private TabControl tabControl1;
		private TabPage tpParams;
		private TabPage tpLocals;
		private Panel tprpPanel;
		private TextBox tbVersion;
		private ListView lvParams;
		private ListView lvLocals;
		private ColumnHeader chPID;
		private ColumnHeader chPLabel;
		private ColumnHeader chLID;
		private ColumnHeader chLLabel;
		private Button btnStrPrev;
		private Button btnStrNext;
		private Button btnTabNext;
		private Button btnTabPrev;
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
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				lvParams.Font = new Font(
					"Microsoft Sans Serif",
					11F
				);
				lvLocals.Font = new Font(
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
			tprpPanel.Controls.Add(pjse_banner1);
			tprpPanel.Controls.Add(lbFilename);
			tbFilename.ReadOnly = true;
			tbFilename.Text = wrapper.FileName;
			tprpPanel.Controls.Add(tbFilename);

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

		private ListView lvCurrent =>
					(tabControl1.SelectedIndex != 0) ? lvLocals : lvParams
				;

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
			InitialTab = tabControl1.SelectedIndex = tab = l;
			internalchg = false;

			if (lvCurrent.SelectedIndices.Count == 0)
			{
				index = -1;
				setIndex(lvCurrent.Items.Count > 0 ? 0 : -1);
			}
			else
			{
				index = lvCurrent.SelectedIndices[0];
			}

			displayTPRPItem();
		}

		private void setIndex(int i)
		{
			internalchg = true;
			if (i >= 0)
			{
				lvCurrent.Items[i].Selected = true;
			}
			else if (index >= 0)
			{
				lvCurrent.Items[index].Selected = false;
			}

			internalchg = false;

			if (lvCurrent.SelectedItems.Count > 0)
			{
				if (lvCurrent.Focused)
				{
					lvCurrent.SelectedItems[0].Focused = true;
				}

				lvCurrent.SelectedItems[0].EnsureVisible();
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
				tbLabel.Text = currentItem.Label;
				btnStrDelete.Enabled = tbLabel.Enabled = true;
				tbLabel.SelectAll();
			}
			else
			{
				origItem = null;
				tbLabel.Text = "";
				btnStrDelete.Enabled = tbLabel.Enabled = false;
			}
			btnStrPrev.Enabled = (index > 0);
			btnStrNext.Enabled = (index < lvCurrent.Items.Count - 1);
			btnTabPrev.Enabled = tab > 0;
			btnTabNext.Enabled = tab < tabControl1.TabCount - 1;

			internalchg = false;

			btnCancel.Enabled = false;
		}

		private void TPRPItemAdd()
		{
			bool savedstate = internalchg;
			internalchg = true;

			TPRPItem newItem = tabControl1.SelectedIndex.Equals(1)
				? new TPRPLocalLabel(wrapper)
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
				wrapper.WrapperChanged += new EventHandler(WrapperChanged);
				setHandler = true;
			}
		}

		private void WrapperChanged(object sender, EventArgs e)
		{
			if (wrapper.TextOnly)
			{
				doTextOnly();
				return;
			}
			btnCommit.Enabled = wrapper.Changed;
			if (sender.Equals(currentItem))
			{
				btnCancel.Enabled = true;
			}

			if (internalchg)
			{
				return;
			}

			if (sender.Equals(wrapper))
			{
				internalchg = true;
				Text = tbFilename.Text = wrapper.FileName;
				tbVersion.Text = "0x" + Helper.HexString(wrapper.Version);
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
			btnCommit = new Button();
			tprpPanel = new Panel();
			pjse_banner1 = new pjse.pjse_banner();
			btnTabNext = new Button();
			btnTabPrev = new Button();
			btnStrPrev = new Button();
			btnStrNext = new Button();
			tabControl1 = new TabControl();
			tpParams = new TabPage();
			lvParams = new ListView();
			chPID = new ColumnHeader();
			chPLabel = new ColumnHeader();
			tpLocals = new TabPage();
			lvLocals = new ListView();
			chLID = new ColumnHeader();
			chLLabel = new ColumnHeader();
			btnCancel = new Button();
			tbLabel = new TextBox();
			btnStrDelete = new Button();
			btnStrAdd = new Button();
			lbVersion = new Label();
			tbVersion = new TextBox();
			tbFilename = new TextBox();
			lbFilename = new Label();
			lbLabel = new Label();
			tprpPanel.SuspendLayout();
			tabControl1.SuspendLayout();
			tpParams.SuspendLayout();
			tpLocals.SuspendLayout();
			SuspendLayout();
			//
			// btnCommit
			//
			resources.ApplyResources(btnCommit, "btnCommit");
			btnCommit.Name = "btnCommit";
			btnCommit.Click += new EventHandler(btnCommit_Click);
			//
			// tprpPanel
			//
			resources.ApplyResources(tprpPanel, "tprpPanel");
			tprpPanel.Controls.Add(pjse_banner1);
			tprpPanel.Controls.Add(btnTabNext);
			tprpPanel.Controls.Add(btnTabPrev);
			tprpPanel.Controls.Add(btnStrPrev);
			tprpPanel.Controls.Add(btnStrNext);
			tprpPanel.Controls.Add(tabControl1);
			tprpPanel.Controls.Add(btnCancel);
			tprpPanel.Controls.Add(tbLabel);
			tprpPanel.Controls.Add(btnStrDelete);
			tprpPanel.Controls.Add(btnStrAdd);
			tprpPanel.Controls.Add(lbVersion);
			tprpPanel.Controls.Add(tbVersion);
			tprpPanel.Controls.Add(tbFilename);
			tprpPanel.Controls.Add(lbFilename);
			tprpPanel.Controls.Add(btnCommit);
			tprpPanel.Controls.Add(lbLabel);
			tprpPanel.Name = "tprpPanel";
			//
			// pjse_banner1
			//
			resources.ApplyResources(pjse_banner1, "pjse_banner1");
			pjse_banner1.Name = "pjse_banner1";
			pjse_banner1.SiblingVisible = true;
			pjse_banner1.SiblingClick += new EventHandler(
				pjse_banner1_SiblingClick
			);
			//
			// btnTabNext
			//
			resources.ApplyResources(btnTabNext, "btnTabNext");
			btnTabNext.Name = "btnTabNext";
			btnTabNext.TabStop = false;
			btnTabNext.Click += new EventHandler(btnTabNext_Click);
			//
			// btnTabPrev
			//
			resources.ApplyResources(btnTabPrev, "btnTabPrev");
			btnTabPrev.Name = "btnTabPrev";
			btnTabPrev.TabStop = false;
			btnTabPrev.Click += new EventHandler(btnTabPrev_Click);
			//
			// btnStrPrev
			//
			resources.ApplyResources(btnStrPrev, "btnStrPrev");
			btnStrPrev.Name = "btnStrPrev";
			btnStrPrev.TabStop = false;
			btnStrPrev.Click += new EventHandler(btnStrPrev_Click);
			//
			// btnStrNext
			//
			resources.ApplyResources(btnStrNext, "btnStrNext");
			btnStrNext.Name = "btnStrNext";
			btnStrNext.TabStop = false;
			btnStrNext.Click += new EventHandler(btnStrNext_Click);
			//
			// tabControl1
			//
			resources.ApplyResources(tabControl1, "tabControl1");
			tabControl1.Controls.Add(tpParams);
			tabControl1.Controls.Add(tpLocals);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.SelectedIndexChanged += new EventHandler(
				tabControl1_SelectedIndexChanged
			);
			//
			// tpParams
			//
			tpParams.Controls.Add(lvParams);
			resources.ApplyResources(tpParams, "tpParams");
			tpParams.Name = "tpParams";
			//
			// lvParams
			//
			lvParams.Columns.AddRange(
				new ColumnHeader[] { chPID, chPLabel }
			);
			resources.ApplyResources(lvParams, "lvParams");
			lvParams.FullRowSelect = true;
			lvParams.GridLines = true;
			lvParams.HeaderStyle =
				ColumnHeaderStyle
				.Nonclickable;
			lvParams.HideSelection = false;
			lvParams.Items.AddRange(
				new ListViewItem[]
				{
					(
						(ListViewItem)(
							resources.GetObject("lvParams.Items")
						)
					),
				}
			);
			lvParams.MultiSelect = false;
			lvParams.Name = "lvParams";
			lvParams.UseCompatibleStateImageBehavior = false;
			lvParams.View = View.Details;
			lvParams.ItemActivate += new EventHandler(
				ListView_ItemActivate
			);
			lvParams.SelectedIndexChanged += new EventHandler(
				ListView_SelectedIndexChanged
			);
			//
			// chPID
			//
			resources.ApplyResources(chPID, "chPID");
			//
			// chPLabel
			//
			resources.ApplyResources(chPLabel, "chPLabel");
			//
			// tpLocals
			//
			tpLocals.Controls.Add(lvLocals);
			resources.ApplyResources(tpLocals, "tpLocals");
			tpLocals.Name = "tpLocals";
			//
			// lvLocals
			//
			lvLocals.Columns.AddRange(
				new ColumnHeader[] { chLID, chLLabel }
			);
			resources.ApplyResources(lvLocals, "lvLocals");
			lvLocals.FullRowSelect = true;
			lvLocals.GridLines = true;
			lvLocals.HeaderStyle =
				ColumnHeaderStyle
				.Nonclickable;
			lvLocals.HideSelection = false;
			lvLocals.MultiSelect = false;
			lvLocals.Name = "lvLocals";
			lvLocals.UseCompatibleStateImageBehavior = false;
			lvLocals.View = View.Details;
			lvLocals.ItemActivate += new EventHandler(
				ListView_ItemActivate
			);
			lvLocals.SelectedIndexChanged += new EventHandler(
				ListView_SelectedIndexChanged
			);
			//
			// chLID
			//
			resources.ApplyResources(chLID, "chLID");
			//
			// chLLabel
			//
			resources.ApplyResources(chLLabel, "chLLabel");
			//
			// btnCancel
			//
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.DialogResult = DialogResult.Cancel;
			btnCancel.Name = "btnCancel";
			btnCancel.Click += new EventHandler(btnCancel_Click);
			//
			// tbLabel
			//
			resources.ApplyResources(tbLabel, "tbLabel");
			tbLabel.Name = "tbLabel";
			tbLabel.TextChanged += new EventHandler(
				tbText_TextChanged
			);
			tbLabel.Validated += new EventHandler(tbText_Enter);
			tbLabel.Enter += new EventHandler(tbText_Enter);
			//
			// btnStrDelete
			//
			resources.ApplyResources(btnStrDelete, "btnStrDelete");
			btnStrDelete.Name = "btnStrDelete";
			btnStrDelete.Click += new EventHandler(btnStrDelete_Click);
			//
			// btnStrAdd
			//
			resources.ApplyResources(btnStrAdd, "btnStrAdd");
			btnStrAdd.Name = "btnStrAdd";
			btnStrAdd.Click += new EventHandler(btnStrAdd_Click);
			//
			// lbVersion
			//
			resources.ApplyResources(lbVersion, "lbVersion");
			lbVersion.Name = "lbVersion";
			//
			// tbVersion
			//
			resources.ApplyResources(tbVersion, "tbVersion");
			tbVersion.Name = "tbVersion";
			tbVersion.ReadOnly = true;
			tbVersion.TextChanged += new EventHandler(
				hex32_TextChanged
			);
			tbVersion.Validated += new EventHandler(hex32_Validated);
			tbVersion.Enter += new EventHandler(tbText_Enter);
			tbVersion.Validating += new System.ComponentModel.CancelEventHandler(
				hex32_Validating
			);
			//
			// tbFilename
			//
			resources.ApplyResources(tbFilename, "tbFilename");
			tbFilename.Name = "tbFilename";
			tbFilename.TextChanged += new EventHandler(
				tbText_TextChanged
			);
			tbFilename.Validated += new EventHandler(tbText_Enter);
			tbFilename.Enter += new EventHandler(tbText_Enter);
			//
			// lbFilename
			//
			resources.ApplyResources(lbFilename, "lbFilename");
			lbFilename.Name = "lbFilename";
			//
			// lbLabel
			//
			resources.ApplyResources(lbLabel, "lbLabel");
			lbLabel.Name = "lbLabel";
			//
			// TPRPForm
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			CancelButton = btnCancel;
			Controls.Add(tprpPanel);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "TPRPForm";
			WindowState = FormWindowState.Maximized;
			tprpPanel.ResumeLayout(false);
			tprpPanel.PerformLayout();
			tabControl1.ResumeLayout(false);
			tpParams.ResumeLayout(false);
			tpLocals.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setTab(tabControl1.SelectedIndex);
		}

		private void ListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setIndex(
				(lvCurrent.SelectedIndices.Count > 0)
					? lvCurrent.SelectedIndices[0]
					: -1
			);
		}

		private void ListView_ItemActivate(object sender, EventArgs e)
		{
			tbLabel.Focus();
		}

		private void btnCommit_Click(object sender, EventArgs e)
		{
			Commit();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Cancel();
			tbLabel.SelectAll();
			tbLabel.Focus();
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
			RemoteControl.OpenPackedFile(bhav.FileDescriptor, bhav.Package);
		}

		private void btnStrPrev_Click(object sender, EventArgs e)
		{
			setIndex(index - 1);
		}

		private void btnStrNext_Click(object sender, EventArgs e)
		{
			setIndex(index + 1);
		}

		private void btnTabPrev_Click(object sender, EventArgs e)
		{
			setTab(tab - 1);
		}

		private void btnTabNext_Click(object sender, EventArgs e)
		{
			setTab(tab + 1);
		}

		private void btnStrAdd_Click(object sender, EventArgs e)
		{
			TPRPItemAdd();
			tbLabel.SelectAll();
			tbLabel.Focus();
		}

		private void btnStrDelete_Click(object sender, EventArgs e)
		{
			TPRPItemDelete();
		}

		private void tbText_Enter(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		private void tbText_TextChanged(object sender, EventArgs e)
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

		private void hex32_TextChanged(object sender, EventArgs ev)
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

		private void hex32_Validated(object sender, EventArgs e)
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
