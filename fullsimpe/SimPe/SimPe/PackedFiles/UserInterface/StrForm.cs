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
				lvStrItems.Font = new System.Drawing.Font(
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
				components?.Dispose();
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
				lvStrItems.Items[index].SubItems[3].Text = wrapper[1, index].Title;
				lvStrItems.Items[index].SubItems[4].Text = wrapper[
					1,
					index
				].Description;
			}
			lvStrItems.Items[index].SubItems[1].Text = wrapper[lid, index].Title;
			lvStrItems.Items[index].SubItems[2].Text = wrapper[
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

			cbLngSelect.Items[lid - 1] =
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

			btnStrPrev.Enabled = (index > 0);
			btnStrNext.Enabled = (index < count - 1);

			btnClearAll.Enabled = !empty; // "Default lang only"
			btnLngClear.Enabled = (lid != 1) && !isEmpty[lid]; // "Clear this lang"

			btnStrAdd.Enabled = (lid == 1);
			btnStrDelete.Enabled = (lid == 1) && (index >= 0);
			btnStrDefault.Enabled = (lid != 1) && !isEmpty[lid] && (index >= 0); // "Make default"
			btnStrClear.Enabled =
				(wrapper.Format != 0x0000) && !empty && (index >= 0); // "Default string only"
			btnStrCopy.Enabled =
				(wrapper.Format != 0x0000) && !isEmpty[lid] && (index >= 0);
			btnReplace.Enabled = (lid == 1);
			BtnClean.Enabled = (
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

			cbLngSelect.Items.Clear();
			cbLngSelect.Items.AddRange(
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

				while (i >= cbLngSelect.Items.Count)
				{
					cbLngSelect.Items.Add(
						"0x"
							+ Helper.HexString((byte)cbLngSelect.Items.Count)
							+ " ("
							+ pjse.Localization.GetString("unk")
							+ ")"
					);
				}

				cbLngSelect.Items[i] += isEmpty[i]
					? " (" + pjse.Localization.GetString("empty") + ")"
					: "";

				if (i > 0)
				{
					count = Math.Max(count, wrapper.CountOf(i));
				}
			}

			btnClearAll.Enabled = !onlyDefault;
			cbLngSelect.Items.RemoveAt(0);
			while (wrapper.CountOf(1) < count)
			{
				wrapper.Add(1, "", "");
			}

			lvStrItems.Columns.Clear();
			lvStrItems.Columns.AddRange(
				new ColumnHeader[]
				{
					chString,
					chLang,
					chLangDesc,
					chDefault,
					chDefaultDesc,
				}
			);
			lvStrItems.Columns[1].Text = "";
			lvStrItems.Items.Clear();
			for (int i = 0; i < count; i++)
			{
				StrItem si = wrapper[1, i];
				lvStrItems.Items.Add(
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
				lvStrItems.Items[i].UseItemStyleForSubItems = false;
				lvStrItems.Items[i].SubItems[2].ForeColor = System
					.Drawing
					.SystemColors
					.ControlDark;
				lvStrItems.Items[i].SubItems[3].ForeColor = System
					.Drawing
					.SystemColors
					.ControlDark;
				lvStrItems.Items[i].SubItems[4].ForeColor = System
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
				cbLngSelect.SelectedIndex = l - 1;
			}

			internalchg = false;
			btnLngFirst.Enabled = btnLngPrev.Enabled = (
				cbLngSelect.SelectedIndex > 0
			);
			btnLngNext.Enabled =
				(wrapper.Format != 0x0000)
				&& (cbLngSelect.Items.Count > 0)
				&& (cbLngSelect.SelectedIndex < cbLngSelect.Items.Count - 1);

			btnLngClear.Text =
				pjse.Localization.GetString("Clear") + " " + langName;

			while (wrapper.CountOf(lid) < count)
			{
				wrapper.Add(lid, "", "");
			}

			lvStrItems.Columns[1].Text = cbLngSelect.SelectedItem.ToString();
			for (int i = 0; i < count; i++)
			{
				lvStrItems.Items[i].SubItems[1].Text = wrapper[lid, i].Title;
				lvStrItems.Items[i].SubItems[2].Text = wrapper[lid, i].Description;
			}

			displayStrItem();
		}

		private void setIndex(int i)
		{
			internalchg = true;
			if (i >= 0)
			{
				lvStrItems.Items[i].Selected = true;
			}
			else if (index >= 0)
			{
				lvStrItems.Items[index].Selected = false;
			}

			internalchg = false;

			if (lvStrItems.SelectedItems.Count > 0)
			{
				if (lvStrItems.Focused)
				{
					lvStrItems.SelectedItems[0].Focused = true;
				}

				lvStrItems.SelectedItems[0].EnsureVisible();
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
				lbStringNum.Text =
					pjse.Localization.GetString("String")
					+ " 0x"
					+ Helper.HexString((ushort)index)
					+ " ("
					+ langName
					+ ")";
				rtbTitle.Text = s.Title;
				rtbTitle.SelectAll();
				btnBigString.Enabled = rtbTitle.Enabled = true;
				rtbDescription.Text = s.Description;
				rtbDescription.SelectAll();
				btnBigDesc.Enabled = rtbDescription.Enabled = (
					wrapper.Format != 0x0000 && wrapper.Format != 0xFFFE
				);
			}
			else
			{
				lbStringNum.Text = "";
				rtbDescription.Text = rtbTitle.Text = "";
				btnBigDesc.Enabled =
					rtbDescription.Enabled =
					btnBigString.Enabled =
					rtbTitle.Enabled =
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
				StrItem si = wrapper[1, index];
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
				lvStrItems.Items.Add(
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

			lvStrItems.Items[index].SubItems[3].Text = wrapper[1, index].Title;
			lvStrItems.Items[index].SubItems[4].Text = wrapper[
				1,
				index
			].Description;

			isEmpty[1] = true;
			List<StrItem> sa = wrapper[1];
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

			cbLngSelect.Items[0] =
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
				? new OpenFileDialog()
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
			WrapperChanged(wrapper, null);

			internalchg = true;
			updateLists();
			ckbDefault.Checked = pjse.Settings.PJSE.StrShowDefault;
			ckbDescription.Checked = pjse.Settings.PJSE.StrShowDesc;
			internalchg = false;

			setLid(1);
			setIndex(count > 0 ? 0 : -1);
			ckb_CheckedChanged(null, null);

			if (!setHandler)
			{
				wrapper.WrapperChanged += new EventHandler(WrapperChanged);
				setHandler = true;
			}
		}

		private void WrapperChanged(object sender, EventArgs e)
		{
			btnCommit.Enabled = wrapper.Changed;

			if (internalchg)
			{
				return;
			}

			internalchg = true;
			Text = tbFilename.Text = wrapper.FileName;
			tbFormat.Text = "0x" + Helper.HexString(wrapper.Format);
			if (wrapper.Format == 0x0000)
			{
				btnBigDesc.Enabled =
					rtbDescription.Enabled =
					ckbDefault.Enabled =
					cbLngSelect.Enabled =
						false;
			}
			else if (wrapper.Format == 0xFFFE)
			{
				btnBigDesc.Enabled = rtbDescription.Enabled = false;
				ckbDefault.Enabled = cbLngSelect.Enabled = true;
			}
			else
			{
				btnBigDesc.Enabled =
					rtbDescription.Enabled =
					ckbDefault.Enabled =
					cbLngSelect.Enabled =
						true;
			}
			internalchg = false;

			ckbDefault.Enabled = cbLngSelect.Enabled = (
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
			strPanel = new Panel();
			BtnClean = new Button();
			pjse_banner1 = new pjse.pjse_banner();
			ckbDescription = new CheckBox();
			btnLngFirst = new Button();
			btnStrPrev = new Button();
			btnStrNext = new Button();
			ckbDefault = new CheckBox();
			btnStrClear = new Button();
			lvStrItems = new ListView();
			chString = new ColumnHeader();
			chLang = new ColumnHeader();
			chLangDesc = new ColumnHeader();
			chDefault = new ColumnHeader();
			chDefaultDesc = new ColumnHeader();
			btnBigDesc = new Button();
			btnBigString = new Button();
			lbDesc = new Label();
			label1 = new Label();
			rtbDescription = new RichTextBox();
			rtbTitle = new RichTextBox();
			btnLngNext = new Button();
			btnLngPrev = new Button();
			btnLngClear = new Button();
			cbLngSelect = new ComboBox();
			lbLngSelect = new Label();
			btnClearAll = new Button();
			lbStringNum = new Label();
			tbFilename = new TextBox();
			lbFilename = new Label();
			btnCommit = new Button();
			lbFormat = new Label();
			tbFormat = new TextBox();
			btnImport = new Button();
			btnExport = new Button();
			btnAppend = new Button();
			btnStrDelete = new Button();
			btnStrAdd = new Button();
			btnReplace = new Button();
			btnStrCopy = new Button();
			btnStrDefault = new Button();
			strPanel.SuspendLayout();
			SuspendLayout();
			//
			// strPanel
			//
			resources.ApplyResources(strPanel, "strPanel");
			strPanel.Controls.Add(BtnClean);
			strPanel.Controls.Add(pjse_banner1);
			strPanel.Controls.Add(ckbDescription);
			strPanel.Controls.Add(btnLngFirst);
			strPanel.Controls.Add(btnStrPrev);
			strPanel.Controls.Add(btnStrNext);
			strPanel.Controls.Add(ckbDefault);
			strPanel.Controls.Add(btnStrClear);
			strPanel.Controls.Add(lvStrItems);
			strPanel.Controls.Add(btnBigDesc);
			strPanel.Controls.Add(btnBigString);
			strPanel.Controls.Add(lbDesc);
			strPanel.Controls.Add(label1);
			strPanel.Controls.Add(rtbDescription);
			strPanel.Controls.Add(rtbTitle);
			strPanel.Controls.Add(btnLngNext);
			strPanel.Controls.Add(btnLngPrev);
			strPanel.Controls.Add(btnLngClear);
			strPanel.Controls.Add(cbLngSelect);
			strPanel.Controls.Add(lbLngSelect);
			strPanel.Controls.Add(btnClearAll);
			strPanel.Controls.Add(lbStringNum);
			strPanel.Controls.Add(tbFilename);
			strPanel.Controls.Add(lbFilename);
			strPanel.Controls.Add(btnCommit);
			strPanel.Controls.Add(lbFormat);
			strPanel.Controls.Add(tbFormat);
			strPanel.Controls.Add(btnImport);
			strPanel.Controls.Add(btnExport);
			strPanel.Controls.Add(btnAppend);
			strPanel.Controls.Add(btnStrDelete);
			strPanel.Controls.Add(btnStrAdd);
			strPanel.Controls.Add(btnReplace);
			strPanel.Controls.Add(btnStrCopy);
			strPanel.Controls.Add(btnStrDefault);
			strPanel.Name = "strPanel";
			strPanel.Paint += new PaintEventHandler(
				strPanel_Paint
			);
			strPanel.Resize += new EventHandler(strPanel_Resize);
			//
			// BtnClean
			//
			resources.ApplyResources(BtnClean, "BtnClean");
			BtnClean.Name = "BtnClean";
			BtnClean.Click += new EventHandler(btnClean_Click);
			//
			// pjse_banner1
			//
			resources.ApplyResources(pjse_banner1, "pjse_banner1");
			pjse_banner1.Name = "pjse_banner1";
			//
			// ckbDescription
			//
			resources.ApplyResources(ckbDescription, "ckbDescription");
			ckbDescription.Name = "ckbDescription";
			ckbDescription.CheckedChanged += new EventHandler(
				ckb_CheckedChanged
			);
			//
			// btnLngFirst
			//
			resources.ApplyResources(btnLngFirst, "btnLngFirst");
			btnLngFirst.Name = "btnLngFirst";
			btnLngFirst.Click += new EventHandler(btnLngFirst_Click);
			//
			// btnStrPrev
			//
			resources.ApplyResources(btnStrPrev, "btnStrPrev");
			btnStrPrev.Name = "btnStrPrev";
			btnStrPrev.Click += new EventHandler(btnStrPrev_Click);
			//
			// btnStrNext
			//
			resources.ApplyResources(btnStrNext, "btnStrNext");
			btnStrNext.Name = "btnStrNext";
			btnStrNext.Click += new EventHandler(btnStrNext_Click);
			//
			// ckbDefault
			//
			resources.ApplyResources(ckbDefault, "ckbDefault");
			ckbDefault.Name = "ckbDefault";
			ckbDefault.CheckedChanged += new EventHandler(
				ckb_CheckedChanged
			);
			//
			// btnStrClear
			//
			resources.ApplyResources(btnStrClear, "btnStrClear");
			btnStrClear.Name = "btnStrClear";
			btnStrClear.Click += new EventHandler(btnStrClear_Click);
			//
			// lvStrItems
			//
			lvStrItems.Activation = ItemActivation.OneClick;
			resources.ApplyResources(lvStrItems, "lvStrItems");
			lvStrItems.Columns.AddRange(
				new ColumnHeader[]
				{
					chString,
					chLang,
					chLangDesc,
					chDefault,
					chDefaultDesc,
				}
			);
			lvStrItems.FullRowSelect = true;
			lvStrItems.GridLines = true;
			lvStrItems.HeaderStyle =
				ColumnHeaderStyle
				.Nonclickable;
			lvStrItems.HideSelection = false;
			lvStrItems.Items.AddRange(
				new ListViewItem[]
				{
					(
						(ListViewItem)(
							resources.GetObject("lvStrItems.Items")
						)
					),
				}
			);
			lvStrItems.MultiSelect = false;
			lvStrItems.Name = "lvStrItems";
			lvStrItems.UseCompatibleStateImageBehavior = false;
			lvStrItems.View = View.Details;
			lvStrItems.ItemActivate += new EventHandler(
				lvStrItems_ItemActivate
			);
			lvStrItems.SelectedIndexChanged += new EventHandler(
				lvStrItems_SelectedIndexChanged
			);
			//
			// chString
			//
			resources.ApplyResources(chString, "chString");
			//
			// chLang
			//
			resources.ApplyResources(chLang, "chLang");
			//
			// chLangDesc
			//
			resources.ApplyResources(chLangDesc, "chLangDesc");
			//
			// chDefault
			//
			resources.ApplyResources(chDefault, "chDefault");
			//
			// chDefaultDesc
			//
			resources.ApplyResources(chDefaultDesc, "chDefaultDesc");
			//
			// btnBigDesc
			//
			resources.ApplyResources(btnBigDesc, "btnBigDesc");
			btnBigDesc.Name = "btnBigDesc";
			btnBigDesc.Click += new EventHandler(btnBigString_Click);
			//
			// btnBigString
			//
			resources.ApplyResources(btnBigString, "btnBigString");
			btnBigString.Name = "btnBigString";
			btnBigString.Click += new EventHandler(btnBigString_Click);
			//
			// lbDesc
			//
			resources.ApplyResources(lbDesc, "lbDesc");
			lbDesc.Name = "lbDesc";
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// rtbDescription
			//
			resources.ApplyResources(rtbDescription, "rtbDescription");
			rtbDescription.Name = "rtbDescription";
			rtbDescription.Enter += new EventHandler(
				textBoxBase_Enter
			);
			rtbDescription.TextChanged += new EventHandler(
				textBoxBase_TextChanged
			);
			//
			// rtbTitle
			//
			resources.ApplyResources(rtbTitle, "rtbTitle");
			rtbTitle.Name = "rtbTitle";
			rtbTitle.Enter += new EventHandler(textBoxBase_Enter);
			rtbTitle.TextChanged += new EventHandler(
				textBoxBase_TextChanged
			);
			//
			// btnLngNext
			//
			resources.ApplyResources(btnLngNext, "btnLngNext");
			btnLngNext.Name = "btnLngNext";
			btnLngNext.Click += new EventHandler(btnLngNext_Click);
			//
			// btnLngPrev
			//
			resources.ApplyResources(btnLngPrev, "btnLngPrev");
			btnLngPrev.Name = "btnLngPrev";
			btnLngPrev.Click += new EventHandler(btnLngPrev_Click);
			//
			// btnLngClear
			//
			resources.ApplyResources(btnLngClear, "btnLngClear");
			btnLngClear.Name = "btnLngClear";
			btnLngClear.Click += new EventHandler(btnLngClear_Click);
			//
			// cbLngSelect
			//
			cbLngSelect.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbLngSelect.DropDownWidth = 200;
			resources.ApplyResources(cbLngSelect, "cbLngSelect");
			cbLngSelect.Name = "cbLngSelect";
			cbLngSelect.SelectedIndexChanged += new EventHandler(
				cbLngSelect_SelectedIndexChanged
			);
			//
			// lbLngSelect
			//
			resources.ApplyResources(lbLngSelect, "lbLngSelect");
			lbLngSelect.Name = "lbLngSelect";
			//
			// btnClearAll
			//
			resources.ApplyResources(btnClearAll, "btnClearAll");
			btnClearAll.Name = "btnClearAll";
			btnClearAll.Click += new EventHandler(btnClearAll_Click);
			//
			// lbStringNum
			//
			resources.ApplyResources(lbStringNum, "lbStringNum");
			lbStringNum.Name = "lbStringNum";
			//
			// tbFilename
			//
			resources.ApplyResources(tbFilename, "tbFilename");
			tbFilename.Name = "tbFilename";
			tbFilename.TextChanged += new EventHandler(
				textBoxBase_TextChanged
			);
			tbFilename.Enter += new EventHandler(textBoxBase_Enter);
			//
			// lbFilename
			//
			resources.ApplyResources(lbFilename, "lbFilename");
			lbFilename.Name = "lbFilename";
			//
			// btnCommit
			//
			resources.ApplyResources(btnCommit, "btnCommit");
			btnCommit.Name = "btnCommit";
			btnCommit.Click += new EventHandler(btnCommit_Click);
			//
			// lbFormat
			//
			resources.ApplyResources(lbFormat, "lbFormat");
			lbFormat.Name = "lbFormat";
			//
			// tbFormat
			//
			resources.ApplyResources(tbFormat, "tbFormat");
			tbFormat.Name = "tbFormat";
			tbFormat.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			tbFormat.Validated += new EventHandler(hex16_Validated);
			tbFormat.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			//
			// btnImport
			//
			resources.ApplyResources(btnImport, "btnImport");
			btnImport.Name = "btnImport";
			btnImport.Click += new EventHandler(btnStringFile_Click);
			//
			// btnExport
			//
			resources.ApplyResources(btnExport, "btnExport");
			btnExport.Name = "btnExport";
			btnExport.Click += new EventHandler(btnStringFile_Click);
			//
			// btnAppend
			//
			resources.ApplyResources(btnAppend, "btnAppend");
			btnAppend.Name = "btnAppend";
			btnAppend.Click += new EventHandler(btnAppend_Click);
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
			// btnReplace
			//
			resources.ApplyResources(btnReplace, "btnReplace");
			btnReplace.Name = "btnReplace";
			btnReplace.Click += new EventHandler(btnImport_Click);
			//
			// btnStrCopy
			//
			resources.ApplyResources(btnStrCopy, "btnStrCopy");
			btnStrCopy.Name = "btnStrCopy";
			btnStrCopy.Click += new EventHandler(btnStrCopy_Click);
			//
			// btnStrDefault
			//
			resources.ApplyResources(btnStrDefault, "btnStrDefault");
			btnStrDefault.Name = "btnStrDefault";
			btnStrDefault.Click += new EventHandler(
				btnStrDefault_Click
			);
			//
			// StrForm
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(strPanel);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "StrForm";
			strPanel.ResumeLayout(false);
			strPanel.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		private void strPanel_Resize(object sender, EventArgs e)
		{
			btnBigDesc.Left = btnCommit.Right - btnBigDesc.Width;

			int width =
				btnBigDesc.Left - rtbTitle.Left - lbDesc.Width - 8;

			rtbDescription.Width = rtbTitle.Width = width / 2;
			btnBigString.Left = rtbTitle.Right;
			lbDesc.Left = rtbTitle.Right + 4;
			rtbDescription.Left = lbDesc.Right + 4;
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

			if (cbLngSelect.SelectedIndex >= 0)
			{
				setLid((byte)(cbLngSelect.SelectedIndex + 1));
			}
		}

		private void lvStrItems_ItemActivate(object sender, EventArgs e)
		{
			rtbTitle.Focus();
		}

		private void lvStrItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setIndex(
				(lvStrItems.SelectedIndices.Count > 0)
					? lvStrItems.SelectedIndices[0]
					: -1
			);
		}

		private void ckb_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			pjse.Settings.PJSE.StrShowDefault = ckbDefault.Checked;
			pjse.Settings.PJSE.StrShowDesc = ckbDescription.Checked;

			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(StrForm));

			int w1 =
				lvStrItems.ClientRectangle.Width
				- (int)(resources.GetObject("chString.Width"))
				- 18;
			int w2 = ckbDescription.Checked
				? (int)(resources.GetObject("chLangDesc.Width"))
				: 0;

			if (ckbDefault.Checked)
			{
				w1 /= 2;
			}

			w1 -= w2;

			chLangDesc.Width = chDefault.Width = chDefaultDesc.Width = 0;
			chLang.Width = w1;
			chLangDesc.Width = w2;
			if (ckbDefault.Checked)
			{
				chDefault.Width = w1;
				chDefaultDesc.Width = w2;
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
			LngClear();
		}

		private void btnClearAll_Click(object sender, EventArgs e)
		{
			LngClearAll();
		}

		private void btnStrAdd_Click(object sender, EventArgs e)
		{
			StrAdd();
			rtbTitle.Focus();
		}

		private void btnStrDelete_Click(object sender, EventArgs e)
		{
			StrDelete();
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
			StrClear();
		}

		private void btnAppend_Click(object sender, EventArgs e)
		{
			Append(
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
			StrCopy();
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			StrReplace();
		}

		private void btnCommit_Click(object sender, EventArgs e)
		{
			Commit();
		}

		private void btnStringFile_Click(object sender, EventArgs e)
		{
			StringFile(sender.Equals(btnImport));
		}

		private void strPanel_Paint(object sender, PaintEventArgs e)
		{
		}
	}
}
