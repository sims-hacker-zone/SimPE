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
using System.Collections.Generic;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for StrForm.
	/// </summary>
	public class StrForm : Form, IPackedFileUI
	{
		#region Form variables
		private Panel strPanel;
		private Button btnCommit;
		private Label lbFilename;
		private TextBox tbFilename;
		private Label lbFormat;
		private TextBox tbFormat;
		private Label lbStringNum;
		private Button btnStrDelete;
		private Button btnStrAdd;
		private Button btnClearAll;
		private Label lbLngSelect;
		private ComboBox cbLngSelect;
		private Button btnLngNext;
		private Button btnLngPrev;
		private Button btnLngClear;
		private RichTextBox rtbTitle;
		private RichTextBox rtbDescription;
		private Label label1;
		private Button btnBigString;
		private Button btnBigDesc;
		private Button btnAppend;
		private ColumnHeader chString;
		private ColumnHeader chDefault;
		private ColumnHeader chLang;
		private ListView lvStrItems;
		private Button btnStrClear;
		private Label lbDesc;
		private CheckBox ckbDefault;
		private Button btnStrPrev;
		private Button btnStrNext;
		private Button btnReplace;
		private Button btnLngFirst;
		private Button btnStrDefault;
		private ColumnHeader chLangDesc;
		private ColumnHeader chDefaultDesc;
		private CheckBox ckbDescription;
		private Button btnImport;
		private Button btnExport;
		private Button btnStrCopy;
		private pjse.pjse_banner pjse_banner1;
		private Button BtnClean;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public StrForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			Control[] af = { tbFormat };
			alHex16 = new ArrayList(af);

			Control[] at = { tbFilename, rtbTitle, rtbDescription };
			alTextBoxBase = new ArrayList(at);

			Control[] ab = { btnBigString, btnBigDesc };
			alBigBtn = new ArrayList(ab);

			pjse.FileTable.GFT.FiletableRefresh += new EventHandler(
				GFT_FiletableRefresh
			);
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				this.lvStrItems.Font = new System.Drawing.Font(
					"Microsoft Sans Serif",
					11F
				);
			}
		}

		void GFT_FiletableRefresh(object sender, EventArgs e)
		{
			if (wrapper.FileDescriptor == null)
			{
				return;
			}

			byte oldLid = lid;
			int oldIndex = index;
			bool savedchg = internalchg;
			internalchg = true;

			updateLists();

			setLid(oldLid); // sets internalchg to false
			setIndex(oldIndex);

			internalchg = savedchg;
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
		private StrWrapper wrapper = null;
		private bool setHandler = false;
		private bool internalchg = false;

		private ArrayList alHex16 = null;
		private ArrayList alTextBoxBase = null;
		private ArrayList alBigBtn = null;

		private byte lid = 1;
		private int index = -1;
		private int count = 0;
		private bool[] isEmpty = new bool[45];
		private String langName = pjse.BhavWiz.readStr(pjse.GS.BhavStr.Languages, 1);

		private bool hex16_IsValid(object sender)
		{
			if (alHex16.IndexOf(sender) < 0)
			{
				throw new Exception(
					"hex16_IsValid not applicable to control " + sender.ToString()
				);
			}

			try
			{
				Convert.ToUInt16(((TextBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		private void updateSelectedItem()
		{
			if (lid == 1)
			{
				this.lvStrItems.Items[index].SubItems[3].Text = wrapper[1, index].Title;
				this.lvStrItems.Items[index].SubItems[4].Text = wrapper[
					1,
					index
				].Description;
			}
			this.lvStrItems.Items[index].SubItems[1].Text = wrapper[lid, index].Title;
			this.lvStrItems.Items[index].SubItems[2].Text = wrapper[
				lid,
				index
			].Description;

			isEmpty[lid] = true;
			List<StrItem> sa = wrapper[lid];
			for (int j = count - 1; j >= 0 && isEmpty[lid]; j--)
			{
				if (
					sa[j] != null
					&& (sa[j].Title.Trim().Length + sa[j].Description.Trim().Length > 0)
				)
				{
					isEmpty[lid] = false;
				}
			}

			this.cbLngSelect.Items[lid - 1] =
				langName
				+ (
					isEmpty[lid]
						? " (" + pjse.Localization.GetString("empty") + ")"
						: ""
				);

			doButtons();
		}

		private void doButtons()
		{
			// (index >= 0) means row selected
			// isEmpty[lid] means rows exist
			// empty means only default language has strings

			bool empty = true;
			foreach (StrItem s in wrapper)
			{
				if (
					(s.LanguageID != 1)
					&& (s.Title.Trim().Length + s.Description.Trim().Length > 0)
				)
				{
					empty = false;
				}
			}

			this.btnStrPrev.Enabled = (index > 0);
			this.btnStrNext.Enabled = (index < count - 1);

			this.btnClearAll.Enabled = !empty; // "Default lang only"
			this.btnLngClear.Enabled = (lid != 1) && !isEmpty[lid]; // "Clear this lang"

			this.btnStrAdd.Enabled = (lid == 1);
			this.btnStrDelete.Enabled = (lid == 1) && (index >= 0);
			this.btnStrDefault.Enabled = (lid != 1) && !isEmpty[lid] && (index >= 0); // "Make default"
			this.btnStrClear.Enabled =
				(wrapper.Format != 0x0000) && !empty && (index >= 0); // "Default string only"
			this.btnStrCopy.Enabled =
				(wrapper.Format != 0x0000) && !isEmpty[lid] && (index >= 0);
			this.btnReplace.Enabled = (lid == 1);
			this.BtnClean.Enabled = (
				wrapper.Format != 0x0000 && wrapper.Format != 0xFFFE
			);
		}

		private void updateLists()
		{
			wrapper.CleanUp();

			lid = 0;
			index = -1;
			count = 0;

			bool onlyDefault = true;

			this.cbLngSelect.Items.Clear();
			this.cbLngSelect.Items.AddRange(
				pjse.BhavWiz.readStr(pjse.GS.BhavStr.Languages).ToArray()
			);

			// I really wish there were a nicer way...
			for (byte i = 0; i < 44; i++)
			{
				isEmpty[i] = !wrapper.HasLanguage(i);
				if (!isEmpty[i] && i > 1)
				{
					onlyDefault = false;
				}

				while (i >= this.cbLngSelect.Items.Count)
				{
					this.cbLngSelect.Items.Add(
						"0x"
							+ Helper.HexString((byte)this.cbLngSelect.Items.Count)
							+ " ("
							+ pjse.Localization.GetString("unk")
							+ ")"
					);
				}

				this.cbLngSelect.Items[i] += isEmpty[i]
					? " (" + pjse.Localization.GetString("empty") + ")"
					: "";

				if (i > 0)
				{
					count = Math.Max(count, wrapper.CountOf(i));
				}
			}

			this.btnClearAll.Enabled = !onlyDefault;
			this.cbLngSelect.Items.RemoveAt(0);
			while (wrapper.CountOf(1) < count)
			{
				wrapper.Add(1, "", "");
			}

			this.lvStrItems.Columns.Clear();
			this.lvStrItems.Columns.AddRange(
				new ColumnHeader[]
				{
					this.chString,
					this.chLang,
					this.chLangDesc,
					this.chDefault,
					this.chDefaultDesc,
				}
			);
			this.lvStrItems.Columns[1].Text = "";
			this.lvStrItems.Items.Clear();
			for (int i = 0; i < count; i++)
			{
				StrItem si = wrapper[1, i];
				this.lvStrItems.Items.Add(
					new ListViewItem(
						new string[]
						{
							"0x" + Helper.HexString((ushort)i) + " (" + i + ")",
							"",
							"",
							((si == null) ? "" : si.Title),
							((si == null) ? "" : si.Description),
						}
					)
				);
				this.lvStrItems.Items[i].UseItemStyleForSubItems = false;
				this.lvStrItems.Items[i].SubItems[2].ForeColor = System
					.Drawing
					.SystemColors
					.ControlDark;
				this.lvStrItems.Items[i].SubItems[3].ForeColor = System
					.Drawing
					.SystemColors
					.ControlDark;
				this.lvStrItems.Items[i].SubItems[4].ForeColor = System
					.Drawing
					.SystemColors
					.ControlDark;
			}
		}

		private void setLid(byte l)
		{
			if (lid == l)
			{
				return;
			}

			lid = l;
			langName = pjse.BhavWiz.readStr(pjse.GS.BhavStr.Languages, lid);

			internalchg = true;
			if (lid > 0)
			{
				this.cbLngSelect.SelectedIndex = l - 1;
			}

			internalchg = false;
			this.btnLngFirst.Enabled = this.btnLngPrev.Enabled = (
				this.cbLngSelect.SelectedIndex > 0
			);
			this.btnLngNext.Enabled =
				(wrapper.Format != 0x0000)
				&& (this.cbLngSelect.Items.Count > 0)
				&& (this.cbLngSelect.SelectedIndex < this.cbLngSelect.Items.Count - 1);

			this.btnLngClear.Text =
				pjse.Localization.GetString("Clear") + " " + langName;

			while (wrapper.CountOf(lid) < count)
			{
				wrapper.Add(lid, "", "");
			}

			this.lvStrItems.Columns[1].Text = this.cbLngSelect.SelectedItem.ToString();
			for (int i = 0; i < count; i++)
			{
				this.lvStrItems.Items[i].SubItems[1].Text = wrapper[lid, i].Title;
				this.lvStrItems.Items[i].SubItems[2].Text = wrapper[lid, i].Description;
			}

			displayStrItem();
		}

		private void setIndex(int i)
		{
			internalchg = true;
			if (i >= 0)
			{
				this.lvStrItems.Items[i].Selected = true;
			}
			else if (index >= 0)
			{
				this.lvStrItems.Items[index].Selected = false;
			}

			internalchg = false;

			if (this.lvStrItems.SelectedItems.Count > 0)
			{
				if (this.lvStrItems.Focused)
				{
					this.lvStrItems.SelectedItems[0].Focused = true;
				}

				this.lvStrItems.SelectedItems[0].EnsureVisible();
			}

			if (index == i)
			{
				return;
			}

			index = i;
			displayStrItem();
		}

		private void displayStrItem()
		{
			StrItem s = (index < 0) ? null : wrapper[lid, index];

			internalchg = true;
			if (s != null)
			{
				this.lbStringNum.Text =
					pjse.Localization.GetString("String")
					+ " 0x"
					+ Helper.HexString((ushort)index)
					+ " ("
					+ langName
					+ ")";
				this.rtbTitle.Text = s.Title;
				this.rtbTitle.SelectAll();
				this.btnBigString.Enabled = this.rtbTitle.Enabled = true;
				this.rtbDescription.Text = s.Description;
				this.rtbDescription.SelectAll();
				this.btnBigDesc.Enabled = this.rtbDescription.Enabled = (
					wrapper.Format != 0x0000 && wrapper.Format != 0xFFFE
				);
			}
			else
			{
				this.lbStringNum.Text = "";
				this.rtbDescription.Text = this.rtbTitle.Text = "";
				this.btnBigDesc.Enabled =
					this.rtbDescription.Enabled =
					this.btnBigString.Enabled =
					this.rtbTitle.Enabled =
						false;
			}
			internalchg = false;

			doButtons();
		}

		private void LngClear()
		{
			bool savedstate = internalchg;
			internalchg = true;

			wrapper.Remove(lid);

			byte l = lid;
			int i = index;
			updateLists();

			internalchg = savedstate;

			setLid(l);
			setIndex((i >= count) ? count - 1 : i);
		}

		private void LngClearAll()
		{
			bool savedstate = internalchg;
			internalchg = true;

			wrapper.DefaultOnly();

			byte l = lid;
			int i = index;
			updateLists();

			internalchg = savedstate;

			setLid(l);
			setIndex((i >= count) ? count - 1 : i);
		}

		private void CleanAll()
		{
			bool savedstate = internalchg;
			internalchg = true;

			wrapper.CleanHim();

			byte l = lid;
			int i = index;
			updateLists();

			internalchg = savedstate;

			setLid(l);
			setIndex((i >= count) ? count - 1 : i);
		}

		private void StrAdd()
		{
			bool savedstate = internalchg;
			internalchg = true;

			string title,
				desc;
			if (index >= 0)
			{
				StrItem si = (StrItem)wrapper[1, index];
				if (si != null)
				{
					title = si.Title;
					desc = si.Description;
				}
				else
				{
					title = desc = "";
				}
			}
			else
			{
				title = desc = "";
			}

			try
			{
				wrapper.Add(1, title, desc);
				count++;
				this.lvStrItems.Items.Add(
					new ListViewItem(
						new string[]
						{
							"0x"
								+ Helper.HexString((ushort)(count - 1))
								+ " ("
								+ ((ushort)(count - 1))
								+ ")",
							title,
							desc,
							title,
							desc,
						}
					)
				);
			}
			catch { }

			internalchg = savedstate;

			//setLid(1);
			setIndex(count - 1);
		}

		private void StrDelete()
		{
			bool savedstate = internalchg;
			internalchg = true;

			for (byte j = 1; j < 44; j++)
			{
				for (int ix = index; ix < count - 1; ix++)
				{
					StrItem s1 = wrapper[j, ix];
					if (s1 != null)
					{
						StrItem s2 = wrapper[j, ix + 1];
						if (s2 != null)
						{
							s1.Title = s2.Title;
							s1.Description = s2.Description;
						}
						else
						{
							s1.Title = s1.Description = "";
						}
					}
				}
				wrapper.Remove(wrapper[j, count - 1]);
			}

			byte l = lid;
			int i = index;
			updateLists();

			internalchg = savedstate;

			setLid(l);
			setIndex((i >= count) ? count - 1 : i);
		}

		private void StrCopy()
		{
			bool savedstate = internalchg;
			internalchg = true;

			for (byte m = 1; m < 44; m++)
			{
				if (m == lid)
				{
					continue;
				}

				while (wrapper[m, index] == null)
				{
					wrapper.Add(m, "", "");
				}

				wrapper[m, index].Title = wrapper[lid, index].Title;
				wrapper[m, index].Description = wrapper[lid, index].Description;
			}

			byte l = lid;
			int i = index;
			updateLists();

			internalchg = savedstate;

			setLid(l);
			setIndex((i >= count) ? count - 1 : i);
		}

		private void StrReplace()
		{
			pjse.FileTable.Entry e = (new pjse.ResourceChooser()).Execute(
				wrapper.FileDescriptor.Type,
				wrapper.FileDescriptor.Group,
				strPanel,
				true
			);
			if (e == null || !(e.Wrapper is StrWrapper))
			{
				return;
			}

			StrWrapper b = (StrWrapper)e.Wrapper;
			int strnum = (new pjse.StrChooser()).Strnum(b);
			if (strnum < 0)
			{
				return;
			}

			bool savedstate = internalchg;
			internalchg = true;

			if (wrapper.Format == 0x0000)
			{
				wrapper[1, index].Title = b[1, strnum].Title;
				wrapper[1, index].Description = b[1, strnum].Description;
			}
			else
			{
				for (byte m = 1; m < 44; m++)
				{
					while (wrapper[m, index] == null)
					{
						wrapper.Add(m, "", "");
					}

					if (b[m, strnum] == null)
					{
						wrapper[m, index].Title = "";
						wrapper[m, index].Description = "";
					}
					else
					{
						wrapper[m, index].Title = b[m, strnum].Title;
						wrapper[m, index].Description = b[m, strnum].Description;
					}
				}
			}

			byte l = lid;
			int i = index;
			updateLists();

			internalchg = savedstate;

			setLid(l);
			setIndex((i >= count) ? count - 1 : i);
		}

		private void StrClear()
		{
			bool savedstate = internalchg;
			internalchg = true;

			for (byte m = 2; m < 44; m++)
			{
				StrItem s = wrapper[m, index];
				if (s != null)
				{
					s.Description = s.Title = "";
				}
			}

			byte l = lid;
			int i = index;
			updateLists();

			internalchg = savedstate;

			setLid(l);
			setIndex((i >= count) ? count - 1 : i);
		}

		private void StrDefault()
		{
			StrItem di = wrapper[1, index];
			StrItem si = wrapper[lid, index];

			di.Title = si.Title;
			di.Description = si.Description;

			this.lvStrItems.Items[index].SubItems[3].Text = wrapper[1, index].Title;
			this.lvStrItems.Items[index].SubItems[4].Text = wrapper[
				1,
				index
			].Description;

			isEmpty[1] = true;
			List<StrItem> sa = wrapper[(byte)1];
			for (int j = count - 1; j >= 0 && isEmpty[1]; j--)
			{
				if (
					sa[j] != null
					&& (sa[j].Title.Trim().Length + sa[j].Description.Trim().Length > 0)
				)
				{
					isEmpty[1] = false;
				}
			}

			this.cbLngSelect.Items[0] =
				pjse.BhavWiz.readStr(pjse.GS.BhavStr.Languages, 1)
				+ (isEmpty[1] ? " (" + pjse.Localization.GetString("empty") + ")" : "");
		}

		private void Append(pjse.FileTable.Entry e)
		{
			if (e == null)
			{
				return;
			}

			bool savedstate = internalchg;
			internalchg = true;

			strPanel.Parent.Cursor = Cursors.WaitCursor;

			using (StrWrapper b = (StrWrapper)e.Wrapper)
			{
				if (wrapper.Format != 0x0000)
				{
					for (byte m = 1; m < 44; m++)
					{
						while (wrapper[m, count - 1] == null)
						{
							wrapper.Add(m, "", "");
						}
					}
				}

				for (int bi = 0; bi < b.Count; bi++)
				{
					if (wrapper.Format == 0x0000 && b[bi].LanguageID != 1)
					{
						continue;
					}

					try
					{
						wrapper.Add(b[bi]);
					}
					catch
					{
						break;
					}
				}
			}

			strPanel.Parent.Cursor = Cursors.Default;

			byte l = lid;
			int i = index;
			updateLists();

			internalchg = savedstate;

			setLid(l);
			setIndex((i >= count) ? count - 1 : i);
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

			byte l = lid;
			int i = index;
			updateLists();

			internalchg = savedstate;

			setLid(l);
			setIndex((i >= count) ? count - 1 : i);
		}

		private void StringFile(bool load)
		{
			FileDialog fd = load
				? (FileDialog)new OpenFileDialog()
				: (FileDialog)new SaveFileDialog();
			fd.AddExtension = true;
			fd.CheckFileExists = load;
			fd.CheckPathExists = true;
			fd.DefaultExt = "txt";
			fd.DereferenceLinks = true;
			fd.FileName = langName + ".txt";
			fd.Filter = pjse.Localization.GetString("strLangFilter");
			fd.FilterIndex = 1;
			fd.RestoreDirectory = false;
			fd.ShowHelp = false;
			//fd.SupportMultiDottedExtensions = false; // Methods missing from Mono
			fd.Title = load
				? pjse.Localization.GetString("strLangLoad")
				: pjse.Localization.GetString("strLangSave");
			fd.ValidateNames = true;
			DialogResult dr = fd.ShowDialog();

			if (dr == DialogResult.OK)
			{
				if (load)
				{
					bool savedstate = internalchg;
					internalchg = true;

					wrapper.ImportLanguage(lid, fd.FileName);

					byte l = lid;
					int i = index;
					updateLists();

					internalchg = savedstate;

					setLid(l);
					setIndex((i >= count) ? count - 1 : i);
				}
				else
				{
					wrapper.ExportLanguage(lid, fd.FileName);
				}
			}
		}

		#endregion

		#region IPackedFileUI Member
		/// <summary>
		/// Returns the Control that will be displayed within SimPe
		/// </summary>
		public Control GUIHandle => strPanel;

		/// <summary>
		/// Called by the AbstractWrapper when the file should be displayed to the user.
		/// </summary>
		/// <param name="wrp">Reference to the wrapper to be displayed.</param>
		public void UpdateGUI(IFileWrapper wrp)
		{
			wrapper = (StrWrapper)wrp;
			this.WrapperChanged(wrapper, null);

			internalchg = true;
			updateLists();
			this.ckbDefault.Checked = pjse.Settings.PJSE.StrShowDefault;
			this.ckbDescription.Checked = pjse.Settings.PJSE.StrShowDesc;
			internalchg = false;

			setLid(1);
			setIndex(count > 0 ? 0 : -1);
			ckb_CheckedChanged(null, null);

			if (!setHandler)
			{
				wrapper.WrapperChanged += new EventHandler(this.WrapperChanged);
				setHandler = true;
			}
		}

		private void WrapperChanged(object sender, EventArgs e)
		{
			this.btnCommit.Enabled = wrapper.Changed;

			if (internalchg)
			{
				return;
			}

			internalchg = true;
			this.Text = this.tbFilename.Text = wrapper.FileName;
			this.tbFormat.Text = "0x" + Helper.HexString(wrapper.Format);
			if (wrapper.Format == 0x0000)
			{
				this.btnBigDesc.Enabled =
					this.rtbDescription.Enabled =
					this.ckbDefault.Enabled =
					this.cbLngSelect.Enabled =
						false;
			}
			else if (wrapper.Format == 0xFFFE)
			{
				this.btnBigDesc.Enabled = this.rtbDescription.Enabled = false;
				this.ckbDefault.Enabled = this.cbLngSelect.Enabled = true;
			}
			else
			{
				this.btnBigDesc.Enabled =
					this.rtbDescription.Enabled =
					this.ckbDefault.Enabled =
					this.cbLngSelect.Enabled =
						true;
			}
			internalchg = false;

			this.ckbDefault.Enabled = this.cbLngSelect.Enabled = (
				wrapper.Format != 0x0000
			);
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
				new System.ComponentModel.ComponentResourceManager(typeof(StrForm));
			this.strPanel = new Panel();
			this.BtnClean = new Button();
			this.pjse_banner1 = new pjse.pjse_banner();
			this.ckbDescription = new CheckBox();
			this.btnLngFirst = new Button();
			this.btnStrPrev = new Button();
			this.btnStrNext = new Button();
			this.ckbDefault = new CheckBox();
			this.btnStrClear = new Button();
			this.lvStrItems = new ListView();
			this.chString = new ColumnHeader();
			this.chLang = new ColumnHeader();
			this.chLangDesc = new ColumnHeader();
			this.chDefault = new ColumnHeader();
			this.chDefaultDesc = new ColumnHeader();
			this.btnBigDesc = new Button();
			this.btnBigString = new Button();
			this.lbDesc = new Label();
			this.label1 = new Label();
			this.rtbDescription = new RichTextBox();
			this.rtbTitle = new RichTextBox();
			this.btnLngNext = new Button();
			this.btnLngPrev = new Button();
			this.btnLngClear = new Button();
			this.cbLngSelect = new ComboBox();
			this.lbLngSelect = new Label();
			this.btnClearAll = new Button();
			this.lbStringNum = new Label();
			this.tbFilename = new TextBox();
			this.lbFilename = new Label();
			this.btnCommit = new Button();
			this.lbFormat = new Label();
			this.tbFormat = new TextBox();
			this.btnImport = new Button();
			this.btnExport = new Button();
			this.btnAppend = new Button();
			this.btnStrDelete = new Button();
			this.btnStrAdd = new Button();
			this.btnReplace = new Button();
			this.btnStrCopy = new Button();
			this.btnStrDefault = new Button();
			this.strPanel.SuspendLayout();
			this.SuspendLayout();
			//
			// strPanel
			//
			resources.ApplyResources(this.strPanel, "strPanel");
			this.strPanel.Controls.Add(this.BtnClean);
			this.strPanel.Controls.Add(this.pjse_banner1);
			this.strPanel.Controls.Add(this.ckbDescription);
			this.strPanel.Controls.Add(this.btnLngFirst);
			this.strPanel.Controls.Add(this.btnStrPrev);
			this.strPanel.Controls.Add(this.btnStrNext);
			this.strPanel.Controls.Add(this.ckbDefault);
			this.strPanel.Controls.Add(this.btnStrClear);
			this.strPanel.Controls.Add(this.lvStrItems);
			this.strPanel.Controls.Add(this.btnBigDesc);
			this.strPanel.Controls.Add(this.btnBigString);
			this.strPanel.Controls.Add(this.lbDesc);
			this.strPanel.Controls.Add(this.label1);
			this.strPanel.Controls.Add(this.rtbDescription);
			this.strPanel.Controls.Add(this.rtbTitle);
			this.strPanel.Controls.Add(this.btnLngNext);
			this.strPanel.Controls.Add(this.btnLngPrev);
			this.strPanel.Controls.Add(this.btnLngClear);
			this.strPanel.Controls.Add(this.cbLngSelect);
			this.strPanel.Controls.Add(this.lbLngSelect);
			this.strPanel.Controls.Add(this.btnClearAll);
			this.strPanel.Controls.Add(this.lbStringNum);
			this.strPanel.Controls.Add(this.tbFilename);
			this.strPanel.Controls.Add(this.lbFilename);
			this.strPanel.Controls.Add(this.btnCommit);
			this.strPanel.Controls.Add(this.lbFormat);
			this.strPanel.Controls.Add(this.tbFormat);
			this.strPanel.Controls.Add(this.btnImport);
			this.strPanel.Controls.Add(this.btnExport);
			this.strPanel.Controls.Add(this.btnAppend);
			this.strPanel.Controls.Add(this.btnStrDelete);
			this.strPanel.Controls.Add(this.btnStrAdd);
			this.strPanel.Controls.Add(this.btnReplace);
			this.strPanel.Controls.Add(this.btnStrCopy);
			this.strPanel.Controls.Add(this.btnStrDefault);
			this.strPanel.Name = "strPanel";
			this.strPanel.Paint += new PaintEventHandler(
				this.strPanel_Paint
			);
			this.strPanel.Resize += new EventHandler(this.strPanel_Resize);
			//
			// BtnClean
			//
			resources.ApplyResources(this.BtnClean, "BtnClean");
			this.BtnClean.Name = "BtnClean";
			this.BtnClean.Click += new EventHandler(this.btnClean_Click);
			//
			// pjse_banner1
			//
			resources.ApplyResources(this.pjse_banner1, "pjse_banner1");
			this.pjse_banner1.Name = "pjse_banner1";
			//
			// ckbDescription
			//
			resources.ApplyResources(this.ckbDescription, "ckbDescription");
			this.ckbDescription.Name = "ckbDescription";
			this.ckbDescription.CheckedChanged += new EventHandler(
				this.ckb_CheckedChanged
			);
			//
			// btnLngFirst
			//
			resources.ApplyResources(this.btnLngFirst, "btnLngFirst");
			this.btnLngFirst.Name = "btnLngFirst";
			this.btnLngFirst.Click += new EventHandler(this.btnLngFirst_Click);
			//
			// btnStrPrev
			//
			resources.ApplyResources(this.btnStrPrev, "btnStrPrev");
			this.btnStrPrev.Name = "btnStrPrev";
			this.btnStrPrev.Click += new EventHandler(this.btnStrPrev_Click);
			//
			// btnStrNext
			//
			resources.ApplyResources(this.btnStrNext, "btnStrNext");
			this.btnStrNext.Name = "btnStrNext";
			this.btnStrNext.Click += new EventHandler(this.btnStrNext_Click);
			//
			// ckbDefault
			//
			resources.ApplyResources(this.ckbDefault, "ckbDefault");
			this.ckbDefault.Name = "ckbDefault";
			this.ckbDefault.CheckedChanged += new EventHandler(
				this.ckb_CheckedChanged
			);
			//
			// btnStrClear
			//
			resources.ApplyResources(this.btnStrClear, "btnStrClear");
			this.btnStrClear.Name = "btnStrClear";
			this.btnStrClear.Click += new EventHandler(this.btnStrClear_Click);
			//
			// lvStrItems
			//
			this.lvStrItems.Activation = ItemActivation.OneClick;
			resources.ApplyResources(this.lvStrItems, "lvStrItems");
			this.lvStrItems.Columns.AddRange(
				new ColumnHeader[]
				{
					this.chString,
					this.chLang,
					this.chLangDesc,
					this.chDefault,
					this.chDefaultDesc,
				}
			);
			this.lvStrItems.FullRowSelect = true;
			this.lvStrItems.GridLines = true;
			this.lvStrItems.HeaderStyle =
				ColumnHeaderStyle
				.Nonclickable;
			this.lvStrItems.HideSelection = false;
			this.lvStrItems.Items.AddRange(
				new ListViewItem[]
				{
					(
						(ListViewItem)(
							resources.GetObject("lvStrItems.Items")
						)
					),
				}
			);
			this.lvStrItems.MultiSelect = false;
			this.lvStrItems.Name = "lvStrItems";
			this.lvStrItems.UseCompatibleStateImageBehavior = false;
			this.lvStrItems.View = View.Details;
			this.lvStrItems.ItemActivate += new EventHandler(
				this.lvStrItems_ItemActivate
			);
			this.lvStrItems.SelectedIndexChanged += new EventHandler(
				this.lvStrItems_SelectedIndexChanged
			);
			//
			// chString
			//
			resources.ApplyResources(this.chString, "chString");
			//
			// chLang
			//
			resources.ApplyResources(this.chLang, "chLang");
			//
			// chLangDesc
			//
			resources.ApplyResources(this.chLangDesc, "chLangDesc");
			//
			// chDefault
			//
			resources.ApplyResources(this.chDefault, "chDefault");
			//
			// chDefaultDesc
			//
			resources.ApplyResources(this.chDefaultDesc, "chDefaultDesc");
			//
			// btnBigDesc
			//
			resources.ApplyResources(this.btnBigDesc, "btnBigDesc");
			this.btnBigDesc.Name = "btnBigDesc";
			this.btnBigDesc.Click += new EventHandler(this.btnBigString_Click);
			//
			// btnBigString
			//
			resources.ApplyResources(this.btnBigString, "btnBigString");
			this.btnBigString.Name = "btnBigString";
			this.btnBigString.Click += new EventHandler(this.btnBigString_Click);
			//
			// lbDesc
			//
			resources.ApplyResources(this.lbDesc, "lbDesc");
			this.lbDesc.Name = "lbDesc";
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// rtbDescription
			//
			resources.ApplyResources(this.rtbDescription, "rtbDescription");
			this.rtbDescription.Name = "rtbDescription";
			this.rtbDescription.Enter += new EventHandler(
				this.textBoxBase_Enter
			);
			this.rtbDescription.TextChanged += new EventHandler(
				this.textBoxBase_TextChanged
			);
			//
			// rtbTitle
			//
			resources.ApplyResources(this.rtbTitle, "rtbTitle");
			this.rtbTitle.Name = "rtbTitle";
			this.rtbTitle.Enter += new EventHandler(this.textBoxBase_Enter);
			this.rtbTitle.TextChanged += new EventHandler(
				this.textBoxBase_TextChanged
			);
			//
			// btnLngNext
			//
			resources.ApplyResources(this.btnLngNext, "btnLngNext");
			this.btnLngNext.Name = "btnLngNext";
			this.btnLngNext.Click += new EventHandler(this.btnLngNext_Click);
			//
			// btnLngPrev
			//
			resources.ApplyResources(this.btnLngPrev, "btnLngPrev");
			this.btnLngPrev.Name = "btnLngPrev";
			this.btnLngPrev.Click += new EventHandler(this.btnLngPrev_Click);
			//
			// btnLngClear
			//
			resources.ApplyResources(this.btnLngClear, "btnLngClear");
			this.btnLngClear.Name = "btnLngClear";
			this.btnLngClear.Click += new EventHandler(this.btnLngClear_Click);
			//
			// cbLngSelect
			//
			this.cbLngSelect.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbLngSelect.DropDownWidth = 200;
			resources.ApplyResources(this.cbLngSelect, "cbLngSelect");
			this.cbLngSelect.Name = "cbLngSelect";
			this.cbLngSelect.SelectedIndexChanged += new EventHandler(
				this.cbLngSelect_SelectedIndexChanged
			);
			//
			// lbLngSelect
			//
			resources.ApplyResources(this.lbLngSelect, "lbLngSelect");
			this.lbLngSelect.Name = "lbLngSelect";
			//
			// btnClearAll
			//
			resources.ApplyResources(this.btnClearAll, "btnClearAll");
			this.btnClearAll.Name = "btnClearAll";
			this.btnClearAll.Click += new EventHandler(this.btnClearAll_Click);
			//
			// lbStringNum
			//
			resources.ApplyResources(this.lbStringNum, "lbStringNum");
			this.lbStringNum.Name = "lbStringNum";
			//
			// tbFilename
			//
			resources.ApplyResources(this.tbFilename, "tbFilename");
			this.tbFilename.Name = "tbFilename";
			this.tbFilename.TextChanged += new EventHandler(
				this.textBoxBase_TextChanged
			);
			this.tbFilename.Enter += new EventHandler(this.textBoxBase_Enter);
			//
			// lbFilename
			//
			resources.ApplyResources(this.lbFilename, "lbFilename");
			this.lbFilename.Name = "lbFilename";
			//
			// btnCommit
			//
			resources.ApplyResources(this.btnCommit, "btnCommit");
			this.btnCommit.Name = "btnCommit";
			this.btnCommit.Click += new EventHandler(this.btnCommit_Click);
			//
			// lbFormat
			//
			resources.ApplyResources(this.lbFormat, "lbFormat");
			this.lbFormat.Name = "lbFormat";
			//
			// tbFormat
			//
			resources.ApplyResources(this.tbFormat, "tbFormat");
			this.tbFormat.Name = "tbFormat";
			this.tbFormat.TextChanged += new EventHandler(
				this.hex16_TextChanged
			);
			this.tbFormat.Validated += new EventHandler(this.hex16_Validated);
			this.tbFormat.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			//
			// btnImport
			//
			resources.ApplyResources(this.btnImport, "btnImport");
			this.btnImport.Name = "btnImport";
			this.btnImport.Click += new EventHandler(this.btnStringFile_Click);
			//
			// btnExport
			//
			resources.ApplyResources(this.btnExport, "btnExport");
			this.btnExport.Name = "btnExport";
			this.btnExport.Click += new EventHandler(this.btnStringFile_Click);
			//
			// btnAppend
			//
			resources.ApplyResources(this.btnAppend, "btnAppend");
			this.btnAppend.Name = "btnAppend";
			this.btnAppend.Click += new EventHandler(this.btnAppend_Click);
			//
			// btnStrDelete
			//
			resources.ApplyResources(this.btnStrDelete, "btnStrDelete");
			this.btnStrDelete.Name = "btnStrDelete";
			this.btnStrDelete.Click += new EventHandler(this.btnStrDelete_Click);
			//
			// btnStrAdd
			//
			resources.ApplyResources(this.btnStrAdd, "btnStrAdd");
			this.btnStrAdd.Name = "btnStrAdd";
			this.btnStrAdd.Click += new EventHandler(this.btnStrAdd_Click);
			//
			// btnReplace
			//
			resources.ApplyResources(this.btnReplace, "btnReplace");
			this.btnReplace.Name = "btnReplace";
			this.btnReplace.Click += new EventHandler(this.btnImport_Click);
			//
			// btnStrCopy
			//
			resources.ApplyResources(this.btnStrCopy, "btnStrCopy");
			this.btnStrCopy.Name = "btnStrCopy";
			this.btnStrCopy.Click += new EventHandler(this.btnStrCopy_Click);
			//
			// btnStrDefault
			//
			resources.ApplyResources(this.btnStrDefault, "btnStrDefault");
			this.btnStrDefault.Name = "btnStrDefault";
			this.btnStrDefault.Click += new EventHandler(
				this.btnStrDefault_Click
			);
			//
			// StrForm
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = AutoScaleMode.Dpi;
			this.Controls.Add(this.strPanel);
			this.FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			this.Name = "StrForm";
			this.strPanel.ResumeLayout(false);
			this.strPanel.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private void strPanel_Resize(object sender, EventArgs e)
		{
			this.btnBigDesc.Left = this.btnCommit.Right - this.btnBigDesc.Width;

			int width =
				this.btnBigDesc.Left - this.rtbTitle.Left - this.lbDesc.Width - 8;

			this.rtbDescription.Width = this.rtbTitle.Width = width / 2;
			this.btnBigString.Left = this.rtbTitle.Right;
			this.lbDesc.Left = this.rtbTitle.Right + 4;
			this.rtbDescription.Left = this.lbDesc.Right + 4;
		}

		private void textBoxBase_Enter(object sender, EventArgs e)
		{
			((TextBoxBase)sender).SelectAll();
		}

		private void textBoxBase_TextChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			internalchg = true;
			switch (alTextBoxBase.IndexOf(sender))
			{
				case 0:
					wrapper.FileName = ((TextBoxBase)sender).Text;
					break;
				case 1:
					wrapper[lid, index].Title = ((TextBoxBase)sender).Text;
					updateSelectedItem();
					break;
				case 2:
					wrapper[lid, index].Description = ((TextBoxBase)sender).Text;
					updateSelectedItem();
					break;
			}
			internalchg = false;
		}

		private void hex16_TextChanged(object sender, EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!hex16_IsValid(sender))
			{
				return;
			}

			ushort val = Convert.ToUInt16(((TextBox)sender).Text, 16);
			internalchg = true;
			switch (alHex16.IndexOf(sender))
			{
				case 0:
					wrapper.Format = val;
					break;
			}
			internalchg = false;
		}

		private void hex16_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (hex16_IsValid(sender))
			{
				return;
			}

			e.Cancel = true;
			hex16_Validated(sender, null);
		}

		private void hex16_Validated(object sender, EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			ushort val = 0;
			switch (alHex16.IndexOf(sender))
			{
				case 0:
					val = wrapper.Format;
					break;
			}

			((TextBox)sender).Text = "0x" + Helper.HexString(val);
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void cbLngSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			if (this.cbLngSelect.SelectedIndex >= 0)
			{
				setLid((byte)(this.cbLngSelect.SelectedIndex + 1));
			}
		}

		private void lvStrItems_ItemActivate(object sender, EventArgs e)
		{
			this.rtbTitle.Focus();
		}

		private void lvStrItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setIndex(
				(this.lvStrItems.SelectedIndices.Count > 0)
					? this.lvStrItems.SelectedIndices[0]
					: -1
			);
		}

		private void ckb_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			pjse.Settings.PJSE.StrShowDefault = this.ckbDefault.Checked;
			pjse.Settings.PJSE.StrShowDesc = this.ckbDescription.Checked;

			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(StrForm));

			int w1 =
				this.lvStrItems.ClientRectangle.Width
				- (int)(resources.GetObject("chString.Width"))
				- 18;
			int w2 = this.ckbDescription.Checked
				? (int)(resources.GetObject("chLangDesc.Width"))
				: 0;

			if (this.ckbDefault.Checked)
			{
				w1 /= 2;
			}

			w1 -= w2;

			this.chLangDesc.Width = this.chDefault.Width = this.chDefaultDesc.Width = 0;
			this.chLang.Width = w1;
			this.chLangDesc.Width = w2;
			if (this.ckbDefault.Checked)
			{
				this.chDefault.Width = w1;
				this.chDefaultDesc.Width = w2;
			}
		}

		private void btnBigString_Click(object sender, EventArgs e)
		{
			int index = alBigBtn.IndexOf(sender);
			if (index < 0)
			{
				throw new Exception(
					"btnBigString_Click not applicable to control " + sender.ToString()
				);
			}

			RichTextBox[] rtb = { rtbTitle, rtbDescription };
			string result = (new pjse.StrBig()).doBig(rtb[index].Text);
			if (result != null)
			{
				rtb[index].Text = result;
			}
		}

		private void btnStrPrev_Click(object sender, EventArgs e)
		{
			setIndex(index - 1);
		}

		private void btnStrNext_Click(object sender, EventArgs e)
		{
			setIndex(index + 1);
		}

		private void btnLngFirst_Click(object sender, EventArgs e)
		{
			setLid(1);
		}

		private void btnLngPrev_Click(object sender, EventArgs e)
		{
			setLid((byte)(lid - 1));
		}

		private void btnLngNext_Click(object sender, EventArgs e)
		{
			setLid((byte)(lid + 1));
		}

		private void btnLngClear_Click(object sender, EventArgs e)
		{
			this.LngClear();
		}

		private void btnClearAll_Click(object sender, EventArgs e)
		{
			this.LngClearAll();
		}

		private void btnStrAdd_Click(object sender, EventArgs e)
		{
			this.StrAdd();
			this.rtbTitle.Focus();
		}

		private void btnStrDelete_Click(object sender, EventArgs e)
		{
			this.StrDelete();
		}

		private void btnStrDefault_Click(object sender, EventArgs e)
		{
			StrDefault();
		}

		private void btnClean_Click(object sender, EventArgs e)
		{
			CleanAll();
		}

		private void btnStrClear_Click(object sender, EventArgs e)
		{
			this.StrClear();
		}

		private void btnAppend_Click(object sender, EventArgs e)
		{
			this.Append(
				(new pjse.ResourceChooser()).Execute(
					wrapper.FileDescriptor.Type,
					wrapper.FileDescriptor.Group,
					strPanel,
					true
				)
			);
		}

		private void btnStrCopy_Click(object sender, EventArgs e)
		{
			this.StrCopy();
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			this.StrReplace();
		}

		private void btnCommit_Click(object sender, EventArgs e)
		{
			this.Commit();
		}

		private void btnStringFile_Click(object sender, EventArgs e)
		{
			this.StringFile(sender.Equals(this.btnImport));
		}

		private void strPanel_Paint(object sender, PaintEventArgs e)
		{
		}
	}
}
