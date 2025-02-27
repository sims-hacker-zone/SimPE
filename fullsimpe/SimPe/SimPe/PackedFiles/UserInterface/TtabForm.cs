/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections.Generic;
using System.Windows.Forms;

using pjse;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

using Str = pjse.Str;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for BconForm.
	/// </summary>
	public class TtabForm : Form, IPackedFileUI
	{
		#region Form variables

		private Panel ttabPanel;
		private TabControl tabControl1;
		private TabPage tpSettings;
		private Label lbaction;
		private Label lbguard;
		private Label label40;
		private Label label33;
		private Label label34;
		private Label label35;
		private Label label29;
		private Label label30;
		private Label label31;
		private Label label32;
		private TextBox tbGuardian;
		private CheckBox cbBitE;
		private CheckBox cbBitF;
		private CheckBox cbBitC;
		private CheckBox cbBitD;
		private CheckBox cbBitB;
		private CheckBox cbBitA;
		private CheckBox cbBit9;
		private CheckBox cbBit8;
		private CheckBox cbBit7;
		private CheckBox cbBit6;
		private CheckBox cbBit5;
		private CheckBox cbBit4;
		private CheckBox cbBit3;
		private CheckBox cbBit2;
		private CheckBox cbBit1;
		private TabPage tpHumanMotives;
		private CheckBox cbBit0;
		private Label label24;
		private TextBox tbAction;
		private TextBox tbStringIndex;
		private GroupBox gbFlags;
		private TextBox tbFlags;
		private TextBox tbAttenuationValue;
		private TextBox tbAutonomy;
		private Label label1;
		private TextBox tbJoinIndex;
		private Label label2;
		private Button btnGuardian;
		private Button btnAction;
		private ComboBox cbAttenuationCode;
		private ListBox lbttab;
		private Button btnAdd;
		private Label label26;
		private Button btnDelete;
		private Label lbFilename;
		private TextBox tbFilename;
		private TextBox tbFormat;
		private Label label41;
		private Button btnCommit;
		private Button btnAppend;
		private TextBox tbUIDispType;
		private TextBox tbFaceAnimID;
		private TextBox tbMemIterMult;
		private TextBox tbObjType;
		private TextBox tbModelTabID;
		private ComboBox cbStringIndex;
		private LinkLabel llAction;
		private LinkLabel llGuardian;
		private Button btnNoFlags;
		private Button btnStrPrev;
		private Button btnStrNext;
		private TabPage tpAnimalMotives;
		private TtabItemMotiveTableUI timtuiHuman;
		private TtabItemMotiveTableUI timtuiAnimal;
		private GroupBox gbFlags2;
		private TextBox tbFlags2;
		private Button btnNoFlags2;
		private Label label3;
		private CheckBox cb2Bit0;
		private CheckBox cb2BitE;
		private CheckBox cb2BitF;
		private CheckBox cb2BitC;
		private CheckBox cb2BitD;
		private CheckBox cb2BitB;
		private CheckBox cb2BitA;
		private CheckBox cb2Bit9;
		private CheckBox cb2Bit8;
		private CheckBox cb2Bit7;
		private CheckBox cb2Bit6;
		private CheckBox cb2Bit5;
		private CheckBox cb2Bit4;
		private CheckBox cb2Bit3;
		private CheckBox cb2Bit2;
		private CheckBox cb2Bit1;
		private Label lbPieString;
		private pjse_banner pjse_banner1;
		private Button btnMoveDown;
		private Button btnMoveUp;
		private SplitContainer splitContainer1;
		private TableLayoutPanel tlpSettingsHead;
		private Label label4;
		private Label lbTTABEntry;
		private FlowLayoutPanel flpPieStringID;
		private FlowLayoutPanel flpAction;
		private FlowLayoutPanel flpGuard;
		private FlowLayoutPanel flpFileCtrl;
		private TableLayoutPanel tableLayoutPanel1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public TtabForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			TextBox[] tbua = { tbAction, tbGuardian, tbFlags, tbFlags2, tbUIDispType };
			alHex16 = new ArrayList(tbua);

			TextBox[] tbia =
			{
				tbFormat,
				tbStringIndex,
				tbAutonomy,
				tbFaceAnimID,
				tbObjType,
				tbModelTabID,
				tbJoinIndex,
			};
			alHex32 = new ArrayList(tbia);

			TextBox[] tbfa = { tbAttenuationValue, tbMemIterMult };
			alFloats = new ArrayList(tbfa);

			CheckBox[] cba =
			{
				cbBit0,
				cbBit1,
				cbBit2,
				cbBit3,
				cbBit4,
				cbBit5,
				cbBit6,
				cbBit7,
				cbBit8,
				cbBit9,
				cbBitA,
				cbBitB,
				cbBitC,
				cbBitD,
				cbBitE,
				cbBitF,
				cb2Bit0,
				cb2Bit1,
				cb2Bit2,
				cb2Bit3,
				cb2Bit4,
				cb2Bit5,
				cb2Bit6,
				cb2Bit7,
				cb2Bit8,
				cb2Bit9,
				cb2BitA,
				cb2BitB,
				cb2BitC,
				cb2BitD,
				cb2BitE,
				cb2BitF,
			};
			alFlags = new ArrayList(cba);

			ComboBox[] cbb = { cbStringIndex, cbAttenuationCode };
			alHex32cb = new ArrayList(cbb);

			label40.Left = tbStringIndex.Left - label40.Width - 6;
			llAction.Left = tbStringIndex.Left - llAction.Width - 6;
			llGuardian.Left = tbStringIndex.Left - llGuardian.Width - 6;

			Label[] al =
			{
				label32,
				label31,
				label1,
				label35,
				label30,
				label2,
				label29,
				label34,
				label33,
			};
			//foreach (Label l in al)
			//    l.Left = cbAttenuationCode.Left - l.Width - 6;
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
			if (setHandler)
			{
				wrapper.WrapperChanged -= new EventHandler(WrapperChanged);
				pjse.FileTable.GFT.FiletableRefresh -= new EventHandler(
					GFT_FiletableRefresh
				);
				setHandler = false;
			}
		}

		#region TtabForm
		/// <summary>
		/// Stores the currently active Wrapper
		/// </summary>
		private Ttab wrapper = null;
		private bool internalchg;
		private bool setHandler = false;
		private ArrayList alHex16;
		private ArrayList alHex32;
		private ArrayList alFloats;
		private ArrayList alFlags;
		private ArrayList alHex32cb;
		private TtabItem origItem;
		private TtabItem currentItem;

		private bool cbHex32_IsValid(object sender)
		{
			if (alHex32cb.IndexOf(sender) < 0)
			{
				throw new Exception(
					"cbHex32_IsValid not applicable to control " + sender.ToString()
				);
			}

			if (((ComboBox)sender).FindStringExact(((ComboBox)sender).Text) >= 0)
			{
				return true;
			}

			try
			{
				Convert.ToUInt32(((ComboBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

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

		private bool float_IsValid(object sender)
		{
			if (alFloats.IndexOf(sender) < 0)
			{
				throw new Exception(
					"float_IsValid not applicable to control " + sender.ToString()
				);
			}

			try
			{
				Convert.ToSingle(((TextBox)sender).Text);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public void Append(pjse.FileTable.Entry e)
		{
			if (e == null || !(e.Wrapper is Ttab))
			{
				return;
			}

			uint offset = getTTAsCount();
			uint maxtti = getMaxTtabItemStringIndex() + 1;
			//if (maxtti != wrapper.Count)
			offset = getUserChoice(offset, maxtti, (uint)wrapper.Count);
			if (offset >= 0x8000)
			{
				return;
			}

			bool savedstate = internalchg;
			internalchg = true;

			ttabPanel.Parent.Cursor = Cursors.WaitCursor;

			Ttab b = (Ttab)e.Wrapper;

			for (int bi = 0; bi < b.Count; bi++)
			{
				wrapper.Add(b[bi]);
				wrapper[wrapper.Count - 1].StringIndex += offset;
				addItem(wrapper.Count - 1);
			}
			ttabPanel.Parent.Cursor = Cursors.Default;

			internalchg = savedstate;
		}

		private Str str = null;
		private Str StrRes
		{
			get
			{
				if (str == null)
				{
					str = new Str(wrapper, wrapper.FileDescriptor.Instance, 0x54544173);
				}

				return str;
			}
		}

		private uint getTTAsCount()
		{
			Str w = StrRes;
			if (w == null)
			{
				return 0;
			}

			uint max = 0;
			for (byte lid = 1; lid < 44; lid++)
			{
				max = (uint)Math.Max(max, w[lid].Count);
			}

			return max;
		}

		private uint getMaxTtabItemStringIndex()
		{
			uint m = 0;
			foreach (TtabItem ti in wrapper)
			{
				if (ti.StringIndex > m)
				{
					m = ti.StringIndex;
				}
			}

			return m;
		}

		private uint getUserChoice(uint offset, uint maxtti, uint nr)
		{
			PickANumber pan = new PickANumber(
				new ushort[] { (ushort)(maxtti & 0x7fff) },
				new String[] { "Increase new Pie String IDs by" }
			)
			{
				Title = "\"Pie String ID\" increment",
				Prompt = ""
			};
			return pan.ShowDialog() == DialogResult.OK ? pan.Value : 0xffffffff;
		}

		private void populateCbStringIndex()
		{
			bool prev = internalchg;
			internalchg = true;

			int cbStringIndexSelectedIndex = cbStringIndex.SelectedIndex;

			cbStringIndex.Items.Clear();

			uint c = getTTAsCount();
			Str w = StrRes;
			for (int i = 0; i < c; i++)
			{
				FallbackStrItem si = w[1, i];
				cbStringIndex.Items.Add(
					"0x"
						+ i.ToString("X")
						+ " ("
						+ i
						+ "): "
						+ (
							(si == null)
								? "*!no default string!*"
								: si.strItem.Title
									+ (si.lidFallback ? " [LID=1]" : "")
									+ (si.fallback.Count > 0 ? " [*]" : "")
						)
				);
			}

			cbStringIndex.SelectedIndex = cbStringIndexSelectedIndex >= 0
				&& cbStringIndexSelectedIndex < cbStringIndex.Items.Count
				? cbStringIndexSelectedIndex
				: -1;

			internalchg = prev;
		}

		private void populateLbttab()
		{
			bool prev = internalchg;
			internalchg = true;
			ttabPanel.SuspendLayout();

			int lbttabSelectedIndex = lbttab.SelectedIndex;

			lbttab.Items.Clear();
			for (int i = 0; i < wrapper.Count; i++)
			{
				addItem(i);
			}

			if (lbttabSelectedIndex >= 0)
			{
				lbttab.SelectedIndex = lbttabSelectedIndex < lbttab.Items.Count ? lbttabSelectedIndex : lbttab.Items.Count - 1;
			}

			ttabPanel.ResumeLayout();
			internalchg = false;
			TtabSelect(null, null);

			internalchg = prev;
		}

		private void doFlags()
		{
			internalchg = true;
			Boolset flags = new Boolset(currentItem.Flags);
			if (wrapper.Format < 0x54)
			{
				flags.flip(new int[] { 4, 5, 6 });
			}

			for (int i = 0; i < flags.Length; i++)
			{
				((CheckBox)alFlags[i]).Checked = flags[i];
			}

			internalchg = false;
		}

		private void doFlags2()
		{
			internalchg = true;
			Boolset flags = new Boolset(currentItem.Flags2);
			for (int i = 0; i < flags.Length; i++)
			{
				((CheckBox)alFlags[i + 16]).Checked = flags[i];
			}

			internalchg = false;
		}

		private uint previousFormat;

		private void resetFormat()
		{
			bool saved = internalchg;
			internalchg = true;

			currentItem = null;
			lbttab.SelectedIndex = -1;

			for (int i = 0; i < wrapper.Count; i++)
			{
				wrapper[i] = wrapper[i].Clone();
			}

			// Flip those flags
			if (
				previousFormat < 0x54 && wrapper.Format >= 0x54
				|| previousFormat >= 0x54 && wrapper.Format < 0x54
			)
			{
				Boolset flags;
				foreach (TtabItem ti in wrapper)
				{
					flags = new Boolset(ti.Flags);
					flags.flip(new int[] { 4, 5, 6 });
					ti.Flags = flags;
				}
			}

			previousFormat = wrapper.Format;

			internalchg = saved;
		}

		private void setFormat()
		{
			int siWas = lbttab.SelectedIndex;

			if (wrapper.Format < 0x44 && previousFormat >= 0x44)
			{
				DialogResult dr = MessageBox.Show(
					pjse.Localization.GetString("ttabForm_Sure"),
					pjse.Localization.GetString("ttabForm_Single"),
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button2
				);
				if (!DialogResult.OK.Equals(dr))
				{
					wrapper.Format = previousFormat;
				}
				else
				{
					resetFormat();
				}
			}
			else if (
				wrapper.Format >= 0x44
				&& wrapper.Format < 0x54
				&& (previousFormat < 0x44 || previousFormat >= 0x54)
			)
			{
				DialogResult dr = MessageBox.Show(
					pjse.Localization.GetString("ttabForm_Sure"),
					pjse.Localization.GetString("ttabForm_MultipleFixed"),
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button2
				);
				if (!DialogResult.OK.Equals(dr))
				{
					wrapper.Format = previousFormat;
				}
				else
				{
					resetFormat();
				}
			}
			else if (wrapper.Format >= 0x54 && previousFormat < 0x54)
			{
				DialogResult dr = MessageBox.Show(
					pjse.Localization.GetString("ttabForm_Sure"),
					pjse.Localization.GetString("ttabForm_MultipleVaries"),
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button2
				);
				if (!DialogResult.OK.Equals(dr))
				{
					wrapper.Format = previousFormat;
				}
				else
				{
					resetFormat();
				}
			}

			tbUIDispType.Enabled =
				tbFaceAnimID.Enabled =
				tbModelTabID.Enabled =
				tbMemIterMult.Enabled =
				tbObjType.Enabled =
					false;

			tabControl1.TabPages.Remove(tpAnimalMotives);

			int index = 0;

			if (wrapper.Format >= 0x45)
			{
				tbUIDispType.Enabled = true;
				if (wrapper.Format >= 0x46)
				{
					tbModelTabID.Enabled = true;
					if (wrapper.Format >= 0x4a)
					{
						tbFaceAnimID.Enabled = true;
						if (wrapper.Format >= 0x4c)
						{
							tbMemIterMult.Enabled = tbObjType.Enabled = true;
							if (wrapper.Format >= 0x54)
							{
								tabControl1.TabPages.Add(tpAnimalMotives);
								index = 1;
							}
						}
					}
				}
			}
			tpHumanMotives.Text = ((String)tpHumanMotives.Tag).Split(new char[] { '/' })[
				index
			];
			for (int i = 0; i < alFlags.Count; i++)
			{
				CheckBox lcb = (CheckBox)alFlags[i];
				if (lcb.Tag != null && lcb.Tag.ToString().Length > 0)
				{
					lcb.Text = ((String)lcb.Tag).Split(new char[] { '/' })[index];
				}
			}

			if (
				wrapper.Count > 0
				&& lbttab.Items.Count > siWas
				&& lbttab.SelectedIndex == -1
			)
			{
				lbttab.SelectedIndex = siWas;
			}
		}

		/// <summary>
		/// Add the ith TtabItem to the lbttab listbox
		/// </summary>
		/// <param name="i">index of TtabItem to add</param>
		private void addItem(int i)
		{
			lbttab.Items.Add(lbttabItem(i));
		}

		private string lbttabItem(int i)
		{
			return wrapper[i] != null
				&& wrapper[i].StringIndex < cbStringIndex.Items.Count
				? (string)cbStringIndex.Items[(int)wrapper[i].StringIndex]
				: "[0x"
					+ i.ToString("X")
					+ " ("
					+ i
					+ "): "
					+ pjse.Localization.GetString("unk")
					+ ": 0x"
					+ Helper.HexString(wrapper[i].StringIndex)
					+ "]";
		}

		private void setBHAV(int which, ushort target, bool notxt)
		{
			TextBox[] tbaGA = { tbAction, tbGuardian };
			if (!notxt)
			{
				tbaGA[which].Text = "0x" + Helper.HexString(target);
			}

			bool found = false;
			Label[] lbaGA = { lbaction, lbguard };
			lbaGA[which].Text = BhavWiz.bhavName(wrapper, target, ref found);

			LinkLabel[] llaGA = { llAction, llGuardian };
			llaGA[which].Enabled = found;
		}

		private void setStringIndex(uint si, bool doText, bool doCB)
		{
			currentItem.StringIndex = si;
			lbttab.Items[lbttab.SelectedIndex] = lbPieString.Text = lbttabItem(
				lbttab.SelectedIndex
			);

			if (doText)
			{
				tbStringIndex.Text = "0x" + Helper.HexString(si);
			}

			if (doCB)
			{
				if (si >= 0 && si < cbStringIndex.Items.Count)
				{
					cbStringIndex.SelectedIndex = (int)si;
				}
				else
				{
					cbStringIndex.SelectedIndex = -1;
					cbStringIndex.Text = tbStringIndex.Text;
				}
			}
		}

		#endregion

		#region IPackedFileUI Member
		/// <summary>
		/// Returns the Control that will be displayed within SimPe
		/// </summary>
		public Control GUIHandle => ttabPanel;

		/// <summary>
		/// Called by the AbstractWrapper when the file should be displayed to the user.
		/// </summary>
		/// <param name="wrp">Reference to the wrapper to be displayed.</param>
		public void UpdateGUI(IFileWrapper wrp)
		{
			wrapper = (Ttab)wrp;

			// We don't repopulate cbStringIndex on WrapperChanged
			cbStringIndex.SelectedIndex = -1;
			populateCbStringIndex();

			// Avoid warning popups from setFormat()!
			previousFormat = wrapper.Format;
			// WrapperChanged() calls populateLbttab(), so set lbttab.SelectedIndex to -1
			lbttab.SelectedIndex = -1;
			WrapperChanged(wrapper, null);

			internalchg = true;
			populateLbttab();
			internalchg = false;

			// Now call TtabSelect (one way or another)
			if (lbttab.Items.Count > 0)
			{
				lbttab.SelectedIndex = 0;
			}
			else
			{
				TtabSelect(null, null);
			}

			if (!setHandler)
			{
				wrapper.WrapperChanged += new EventHandler(WrapperChanged);
				pjse.FileTable.GFT.FiletableRefresh += new EventHandler(
					GFT_FiletableRefresh
				);
				setHandler = true;
			}
		}

		private void GFT_FiletableRefresh(object sender, EventArgs e)
		{
			str = null;
			if (wrapper == null || wrapper.FileDescriptor == null)
			{
				return;
			}

			populateCbStringIndex();
			populateLbttab();
		}

		private void WrapperChanged(object sender, EventArgs e)
		{
			btnCommit.Enabled = wrapper.Changed;

			if (internalchg)
			{
				return;
			}

			internalchg = true;

			if (sender == wrapper)
			{
				Text = tbFilename.Text = wrapper.FileName;
				tbFormat.Text = "0x" + Helper.HexString(wrapper.Format);
				setFormat();
			}
			else if (sender is List<TtabItem>)
			{
				populateLbttab();
			}
			else if (
				lbttab.SelectedIndex >= 0
				&& sender == wrapper[lbttab.SelectedIndex]
			)
			{
				TtabSelect(null, null);
			}

			internalchg = false;
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
				new System.ComponentModel.ComponentResourceManager(typeof(TtabForm));
			ttabPanel = new Panel();
			splitContainer1 = new SplitContainer();
			tableLayoutPanel1 = new TableLayoutPanel();
			lbttab = new ListBox();
			flpFileCtrl = new FlowLayoutPanel();
			lbFilename = new Label();
			tbFilename = new TextBox();
			label41 = new Label();
			tbFormat = new TextBox();
			btnCommit = new Button();
			label26 = new Label();
			btnStrPrev = new Button();
			btnMoveUp = new Button();
			btnAdd = new Button();
			btnStrNext = new Button();
			btnMoveDown = new Button();
			btnDelete = new Button();
			btnAppend = new Button();
			tabControl1 = new TabControl();
			tpSettings = new TabPage();
			tlpSettingsHead = new TableLayoutPanel();
			label4 = new Label();
			lbTTABEntry = new Label();
			llGuardian = new LinkLabel();
			label40 = new Label();
			llAction = new LinkLabel();
			flpPieStringID = new FlowLayoutPanel();
			tbStringIndex = new TextBox();
			cbStringIndex = new ComboBox();
			lbPieString = new Label();
			flpAction = new FlowLayoutPanel();
			tbAction = new TextBox();
			btnAction = new Button();
			lbaction = new Label();
			flpGuard = new FlowLayoutPanel();
			tbGuardian = new TextBox();
			btnGuardian = new Button();
			lbguard = new Label();
			gbFlags2 = new GroupBox();
			tbFlags2 = new TextBox();
			btnNoFlags2 = new Button();
			label3 = new Label();
			cb2Bit0 = new CheckBox();
			cb2BitE = new CheckBox();
			cb2BitF = new CheckBox();
			cb2BitC = new CheckBox();
			cb2BitD = new CheckBox();
			cb2BitB = new CheckBox();
			cb2BitA = new CheckBox();
			cb2Bit9 = new CheckBox();
			cb2Bit8 = new CheckBox();
			cb2Bit7 = new CheckBox();
			cb2Bit6 = new CheckBox();
			cb2Bit5 = new CheckBox();
			cb2Bit4 = new CheckBox();
			cb2Bit3 = new CheckBox();
			cb2Bit2 = new CheckBox();
			cb2Bit1 = new CheckBox();
			cbAttenuationCode = new ComboBox();
			tbModelTabID = new TextBox();
			label33 = new Label();
			tbObjType = new TextBox();
			label34 = new Label();
			tbUIDispType = new TextBox();
			label35 = new Label();
			tbAutonomy = new TextBox();
			tbMemIterMult = new TextBox();
			label29 = new Label();
			tbFaceAnimID = new TextBox();
			label30 = new Label();
			tbAttenuationValue = new TextBox();
			label31 = new Label();
			label32 = new Label();
			gbFlags = new GroupBox();
			btnNoFlags = new Button();
			tbFlags = new TextBox();
			label24 = new Label();
			cbBit0 = new CheckBox();
			cbBitE = new CheckBox();
			cbBitF = new CheckBox();
			cbBitC = new CheckBox();
			cbBitD = new CheckBox();
			cbBitB = new CheckBox();
			cbBitA = new CheckBox();
			cbBit9 = new CheckBox();
			cbBit8 = new CheckBox();
			cbBit7 = new CheckBox();
			cbBit6 = new CheckBox();
			cbBit5 = new CheckBox();
			cbBit4 = new CheckBox();
			cbBit3 = new CheckBox();
			cbBit2 = new CheckBox();
			cbBit1 = new CheckBox();
			label1 = new Label();
			tbJoinIndex = new TextBox();
			label2 = new Label();
			tpHumanMotives = new TabPage();
			timtuiHuman =
				new TtabItemMotiveTableUI();
			tpAnimalMotives = new TabPage();
			timtuiAnimal =
				new TtabItemMotiveTableUI();
			pjse_banner1 = new pjse_banner();
			ttabPanel.SuspendLayout();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			flpFileCtrl.SuspendLayout();
			tabControl1.SuspendLayout();
			tpSettings.SuspendLayout();
			tlpSettingsHead.SuspendLayout();
			flpPieStringID.SuspendLayout();
			flpAction.SuspendLayout();
			flpGuard.SuspendLayout();
			gbFlags2.SuspendLayout();
			gbFlags.SuspendLayout();
			tpHumanMotives.SuspendLayout();
			tpAnimalMotives.SuspendLayout();
			SuspendLayout();
			//
			// ttabPanel
			//
			resources.ApplyResources(ttabPanel, "ttabPanel");
			ttabPanel.BackColor = System.Drawing.SystemColors.Control;
			ttabPanel.Controls.Add(splitContainer1);
			ttabPanel.Controls.Add(pjse_banner1);
			ttabPanel.Name = "ttabPanel";
			//
			// splitContainer1
			//
			resources.ApplyResources(splitContainer1, "splitContainer1");
			splitContainer1.FixedPanel = FixedPanel.Panel1;
			splitContainer1.Name = "splitContainer1";
			//
			// splitContainer1.Panel1
			//
			splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
			//
			// splitContainer1.Panel2
			//
			splitContainer1.Panel2.Controls.Add(tabControl1);
			//
			// tableLayoutPanel1
			//
			resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
			tableLayoutPanel1.Controls.Add(lbttab, 0, 1);
			tableLayoutPanel1.Controls.Add(flpFileCtrl, 0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			//
			// lbttab
			//
			resources.ApplyResources(lbttab, "lbttab");
			lbttab.Name = "lbttab";
			lbttab.SelectedIndexChanged += new EventHandler(
				TtabSelect
			);
			//
			// flpFileCtrl
			//
			resources.ApplyResources(flpFileCtrl, "flpFileCtrl");
			flpFileCtrl.Controls.Add(lbFilename);
			flpFileCtrl.Controls.Add(tbFilename);
			flpFileCtrl.Controls.Add(label41);
			flpFileCtrl.Controls.Add(tbFormat);
			flpFileCtrl.Controls.Add(btnCommit);
			flpFileCtrl.Controls.Add(label26);
			flpFileCtrl.Controls.Add(btnStrPrev);
			flpFileCtrl.Controls.Add(btnMoveUp);
			flpFileCtrl.Controls.Add(btnAdd);
			flpFileCtrl.Controls.Add(btnStrNext);
			flpFileCtrl.Controls.Add(btnMoveDown);
			flpFileCtrl.Controls.Add(btnDelete);
			flpFileCtrl.Controls.Add(btnAppend);
			flpFileCtrl.Name = "flpFileCtrl";
			//
			// lbFilename
			//
			resources.ApplyResources(lbFilename, "lbFilename");
			flpFileCtrl.SetFlowBreak(lbFilename, true);
			lbFilename.Name = "lbFilename";
			//
			// tbFilename
			//
			resources.ApplyResources(tbFilename, "tbFilename");
			flpFileCtrl.SetFlowBreak(tbFilename, true);
			tbFilename.Name = "tbFilename";
			tbFilename.TextChanged += new EventHandler(
				tbFilename_TextChanged
			);
			tbFilename.Validated += new EventHandler(
				tbFilename_Validated
			);
			//
			// label41
			//
			resources.ApplyResources(label41, "label41");
			label41.Name = "label41";
			//
			// tbFormat
			//
			resources.ApplyResources(tbFormat, "tbFormat");
			tbFormat.Name = "tbFormat";
			tbFormat.TextChanged += new EventHandler(
				hex32_TextChanged
			);
			tbFormat.Validated += new EventHandler(hex32_Validated);
			tbFormat.Validating += new System.ComponentModel.CancelEventHandler(
				hex32_Validating
			);
			//
			// btnCommit
			//
			resources.ApplyResources(btnCommit, "btnCommit");
			flpFileCtrl.SetFlowBreak(btnCommit, true);
			btnCommit.Name = "btnCommit";
			btnCommit.Click += new EventHandler(btnCommit_Click);
			//
			// label26
			//
			resources.ApplyResources(label26, "label26");
			flpFileCtrl.SetFlowBreak(label26, true);
			label26.Name = "label26";
			//
			// btnStrPrev
			//
			resources.ApplyResources(btnStrPrev, "btnStrPrev");
			btnStrPrev.Name = "btnStrPrev";
			btnStrPrev.Click += new EventHandler(btnStrPrev_Click);
			//
			// btnMoveUp
			//
			resources.ApplyResources(btnMoveUp, "btnMoveUp");
			btnMoveUp.Name = "btnMoveUp";
			btnMoveUp.Click += new EventHandler(btnMoveUp_Click);
			//
			// btnAdd
			//
			resources.ApplyResources(btnAdd, "btnAdd");
			flpFileCtrl.SetFlowBreak(btnAdd, true);
			btnAdd.Name = "btnAdd";
			btnAdd.Click += new EventHandler(btnAdd_Click);
			//
			// btnStrNext
			//
			resources.ApplyResources(btnStrNext, "btnStrNext");
			btnStrNext.Name = "btnStrNext";
			btnStrNext.Click += new EventHandler(btnStrNext_Click);
			//
			// btnMoveDown
			//
			resources.ApplyResources(btnMoveDown, "btnMoveDown");
			btnMoveDown.Name = "btnMoveDown";
			btnMoveDown.Click += new EventHandler(btnMoveDown_Click);
			//
			// btnDelete
			//
			resources.ApplyResources(btnDelete, "btnDelete");
			btnDelete.Name = "btnDelete";
			btnDelete.Click += new EventHandler(btnDelete_Click);
			//
			// btnAppend
			//
			resources.ApplyResources(btnAppend, "btnAppend");
			btnAppend.Name = "btnAppend";
			btnAppend.Click += new EventHandler(btnAppend_Click);
			//
			// tabControl1
			//
			resources.ApplyResources(tabControl1, "tabControl1");
			tabControl1.Controls.Add(tpSettings);
			tabControl1.Controls.Add(tpHumanMotives);
			tabControl1.Controls.Add(tpAnimalMotives);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			//
			// tpSettings
			//
			resources.ApplyResources(tpSettings, "tpSettings");
			tpSettings.Controls.Add(tlpSettingsHead);
			tpSettings.Controls.Add(gbFlags2);
			tpSettings.Controls.Add(cbAttenuationCode);
			tpSettings.Controls.Add(tbModelTabID);
			tpSettings.Controls.Add(label33);
			tpSettings.Controls.Add(tbObjType);
			tpSettings.Controls.Add(label34);
			tpSettings.Controls.Add(tbUIDispType);
			tpSettings.Controls.Add(label35);
			tpSettings.Controls.Add(tbAutonomy);
			tpSettings.Controls.Add(tbMemIterMult);
			tpSettings.Controls.Add(label29);
			tpSettings.Controls.Add(tbFaceAnimID);
			tpSettings.Controls.Add(label30);
			tpSettings.Controls.Add(tbAttenuationValue);
			tpSettings.Controls.Add(label31);
			tpSettings.Controls.Add(label32);
			tpSettings.Controls.Add(gbFlags);
			tpSettings.Controls.Add(label1);
			tpSettings.Controls.Add(tbJoinIndex);
			tpSettings.Controls.Add(label2);
			tpSettings.Name = "tpSettings";
			tpSettings.UseVisualStyleBackColor = true;
			//
			// tlpSettingsHead
			//
			resources.ApplyResources(tlpSettingsHead, "tlpSettingsHead");
			tlpSettingsHead.Controls.Add(label4, 0, 0);
			tlpSettingsHead.Controls.Add(lbTTABEntry, 1, 0);
			tlpSettingsHead.Controls.Add(llGuardian, 0, 3);
			tlpSettingsHead.Controls.Add(label40, 0, 1);
			tlpSettingsHead.Controls.Add(llAction, 0, 2);
			tlpSettingsHead.Controls.Add(flpPieStringID, 1, 1);
			tlpSettingsHead.Controls.Add(flpAction, 1, 2);
			tlpSettingsHead.Controls.Add(flpGuard, 1, 3);
			tlpSettingsHead.Name = "tlpSettingsHead";
			//
			// label4
			//
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// lbTTABEntry
			//
			resources.ApplyResources(lbTTABEntry, "lbTTABEntry");
			lbTTABEntry.Name = "lbTTABEntry";
			//
			// llGuardian
			//
			resources.ApplyResources(llGuardian, "llGuardian");
			llGuardian.Name = "llGuardian";
			llGuardian.TabStop = true;
			llGuardian.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llBhav_LinkClicked
				);
			//
			// label40
			//
			resources.ApplyResources(label40, "label40");
			label40.Name = "label40";
			//
			// llAction
			//
			resources.ApplyResources(llAction, "llAction");
			llAction.Name = "llAction";
			llAction.TabStop = true;
			llAction.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llBhav_LinkClicked
				);
			//
			// flpPieStringID
			//
			resources.ApplyResources(flpPieStringID, "flpPieStringID");
			flpPieStringID.Controls.Add(tbStringIndex);
			flpPieStringID.Controls.Add(cbStringIndex);
			flpPieStringID.Controls.Add(lbPieString);
			flpPieStringID.Name = "flpPieStringID";
			//
			// tbStringIndex
			//
			resources.ApplyResources(tbStringIndex, "tbStringIndex");
			tbStringIndex.Name = "tbStringIndex";
			tbStringIndex.TextChanged += new EventHandler(
				hex32_TextChanged
			);
			tbStringIndex.Validated += new EventHandler(
				hex32_Validated
			);
			tbStringIndex.Validating +=
				new System.ComponentModel.CancelEventHandler(hex32_Validating);
			//
			// cbStringIndex
			//
			resources.ApplyResources(cbStringIndex, "cbStringIndex");
			cbStringIndex.DisplayMember = "Display";
			cbStringIndex.DropDownWidth = 240;
			cbStringIndex.Items.AddRange(
				new object[]
				{
					resources.GetString("cbStringIndex.Items"),
					resources.GetString("cbStringIndex.Items1"),
					resources.GetString("cbStringIndex.Items2"),
				}
			);
			cbStringIndex.Name = "cbStringIndex";
			cbStringIndex.TabStop = false;
			cbStringIndex.ValueMember = "Value";
			cbStringIndex.Validating +=
				new System.ComponentModel.CancelEventHandler(cbHex32_Validating);
			cbStringIndex.SelectedIndexChanged += new EventHandler(
				cbHex32_SelectedIndexChanged
			);
			cbStringIndex.Enter += new EventHandler(cbHex32_Enter);
			cbStringIndex.Validated += new EventHandler(
				cbHex32_Validated
			);
			cbStringIndex.TextChanged += new EventHandler(
				cbHex32_TextChanged
			);
			//
			// lbPieString
			//
			resources.ApplyResources(lbPieString, "lbPieString");
			lbPieString.Name = "lbPieString";
			lbPieString.UseMnemonic = false;
			//
			// flpAction
			//
			resources.ApplyResources(flpAction, "flpAction");
			flpAction.Controls.Add(tbAction);
			flpAction.Controls.Add(btnAction);
			flpAction.Controls.Add(lbaction);
			flpAction.Name = "flpAction";
			//
			// tbAction
			//
			resources.ApplyResources(tbAction, "tbAction");
			tbAction.Name = "tbAction";
			tbAction.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			tbAction.Validated += new EventHandler(hex16_Validated);
			tbAction.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			//
			// btnAction
			//
			resources.ApplyResources(btnAction, "btnAction");
			btnAction.Name = "btnAction";
			btnAction.Click += new EventHandler(GetTTABAction);
			//
			// lbaction
			//
			resources.ApplyResources(lbaction, "lbaction");
			lbaction.Name = "lbaction";
			lbaction.UseMnemonic = false;
			//
			// flpGuard
			//
			resources.ApplyResources(flpGuard, "flpGuard");
			flpGuard.Controls.Add(tbGuardian);
			flpGuard.Controls.Add(btnGuardian);
			flpGuard.Controls.Add(lbguard);
			flpGuard.Name = "flpGuard";
			//
			// tbGuardian
			//
			resources.ApplyResources(tbGuardian, "tbGuardian");
			tbGuardian.Name = "tbGuardian";
			tbGuardian.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			tbGuardian.Validated += new EventHandler(hex16_Validated);
			tbGuardian.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			//
			// btnGuardian
			//
			resources.ApplyResources(btnGuardian, "btnGuardian");
			btnGuardian.Name = "btnGuardian";
			btnGuardian.Click += new EventHandler(GetTTABGuard);
			//
			// lbguard
			//
			resources.ApplyResources(lbguard, "lbguard");
			lbguard.Name = "lbguard";
			lbguard.UseMnemonic = false;
			//
			// gbFlags2
			//
			gbFlags2.Controls.Add(tbFlags2);
			gbFlags2.Controls.Add(btnNoFlags2);
			gbFlags2.Controls.Add(label3);
			gbFlags2.Controls.Add(cb2Bit0);
			gbFlags2.Controls.Add(cb2BitE);
			gbFlags2.Controls.Add(cb2BitF);
			gbFlags2.Controls.Add(cb2BitC);
			gbFlags2.Controls.Add(cb2BitD);
			gbFlags2.Controls.Add(cb2BitB);
			gbFlags2.Controls.Add(cb2BitA);
			gbFlags2.Controls.Add(cb2Bit9);
			gbFlags2.Controls.Add(cb2Bit8);
			gbFlags2.Controls.Add(cb2Bit7);
			gbFlags2.Controls.Add(cb2Bit6);
			gbFlags2.Controls.Add(cb2Bit5);
			gbFlags2.Controls.Add(cb2Bit4);
			gbFlags2.Controls.Add(cb2Bit3);
			gbFlags2.Controls.Add(cb2Bit2);
			gbFlags2.Controls.Add(cb2Bit1);
			resources.ApplyResources(gbFlags2, "gbFlags2");
			gbFlags2.Name = "gbFlags2";
			gbFlags2.TabStop = false;
			//
			// tbFlags2
			//
			resources.ApplyResources(tbFlags2, "tbFlags2");
			tbFlags2.Name = "tbFlags2";
			tbFlags2.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			tbFlags2.Validated += new EventHandler(hex16_Validated);
			tbFlags2.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			//
			// btnNoFlags2
			//
			resources.ApplyResources(btnNoFlags2, "btnNoFlags2");
			btnNoFlags2.Name = "btnNoFlags2";
			btnNoFlags2.Click += new EventHandler(btnNoFlags2_Click);
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// cb2Bit0
			//
			resources.ApplyResources(cb2Bit0, "cb2Bit0");
			cb2Bit0.Name = "cb2Bit0";
			cb2Bit0.Tag = "";
			cb2Bit0.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2BitE
			//
			resources.ApplyResources(cb2BitE, "cb2BitE");
			cb2BitE.Name = "cb2BitE";
			cb2BitE.Tag = "";
			cb2BitE.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2BitF
			//
			resources.ApplyResources(cb2BitF, "cb2BitF");
			cb2BitF.Name = "cb2BitF";
			cb2BitF.Tag = "";
			cb2BitF.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2BitC
			//
			resources.ApplyResources(cb2BitC, "cb2BitC");
			cb2BitC.Name = "cb2BitC";
			cb2BitC.Tag = "?/adult small dogs";
			cb2BitC.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2BitD
			//
			resources.ApplyResources(cb2BitD, "cb2BitD");
			cb2BitD.Name = "cb2BitD";
			cb2BitD.Tag = "?/elder small dogs";
			cb2BitD.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2BitB
			//
			resources.ApplyResources(cb2BitB, "cb2BitB");
			cb2BitB.Name = "cb2BitB";
			cb2BitB.Tag = "?/elder cats";
			cb2BitB.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2BitA
			//
			resources.ApplyResources(cb2BitA, "cb2BitA");
			cb2BitA.Name = "cb2BitA";
			cb2BitA.Tag = "?/elder big dogs";
			cb2BitA.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2Bit9
			//
			resources.ApplyResources(cb2Bit9, "cb2Bit9");
			cb2Bit9.Name = "cb2Bit9";
			cb2Bit9.Tag = "?/kittens";
			cb2Bit9.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2Bit8
			//
			resources.ApplyResources(cb2Bit8, "cb2Bit8");
			cb2Bit8.Name = "cb2Bit8";
			cb2Bit8.Tag = "?/puppies";
			cb2Bit8.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2Bit7
			//
			resources.ApplyResources(cb2Bit7, "cb2Bit7");
			cb2Bit7.Name = "cb2Bit7";
			cb2Bit7.Tag = "";
			cb2Bit7.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2Bit6
			//
			resources.ApplyResources(cb2Bit6, "cb2Bit6");
			cb2Bit6.Name = "cb2Bit6";
			cb2Bit6.Tag = "";
			cb2Bit6.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2Bit5
			//
			resources.ApplyResources(cb2Bit5, "cb2Bit5");
			cb2Bit5.Name = "cb2Bit5";
			cb2Bit5.Tag = "";
			cb2Bit5.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2Bit4
			//
			resources.ApplyResources(cb2Bit4, "cb2Bit4");
			cb2Bit4.Name = "cb2Bit4";
			cb2Bit4.Tag = "";
			cb2Bit4.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2Bit3
			//
			resources.ApplyResources(cb2Bit3, "cb2Bit3");
			cb2Bit3.Name = "cb2Bit3";
			cb2Bit3.Tag = "";
			cb2Bit3.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2Bit2
			//
			resources.ApplyResources(cb2Bit2, "cb2Bit2");
			cb2Bit2.Name = "cb2Bit2";
			cb2Bit2.Tag = "";
			cb2Bit2.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cb2Bit1
			//
			resources.ApplyResources(cb2Bit1, "cb2Bit1");
			cb2Bit1.Name = "cb2Bit1";
			cb2Bit1.Tag = "";
			cb2Bit1.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbAttenuationCode
			//
			resources.ApplyResources(cbAttenuationCode, "cbAttenuationCode");
			cbAttenuationCode.Items.AddRange(
				new object[]
				{
					resources.GetString("cbAttenuationCode.Items"),
					resources.GetString("cbAttenuationCode.Items1"),
					resources.GetString("cbAttenuationCode.Items2"),
					resources.GetString("cbAttenuationCode.Items3"),
					resources.GetString("cbAttenuationCode.Items4"),
				}
			);
			cbAttenuationCode.Name = "cbAttenuationCode";
			cbAttenuationCode.Validating +=
				new System.ComponentModel.CancelEventHandler(cbHex32_Validating);
			cbAttenuationCode.SelectedIndexChanged += new EventHandler(
				cbHex32_SelectedIndexChanged
			);
			cbAttenuationCode.Enter += new EventHandler(cbHex32_Enter);
			cbAttenuationCode.Validated += new EventHandler(
				cbHex32_Validated
			);
			cbAttenuationCode.TextChanged += new EventHandler(
				cbHex32_TextChanged
			);
			//
			// tbModelTabID
			//
			resources.ApplyResources(tbModelTabID, "tbModelTabID");
			tbModelTabID.Name = "tbModelTabID";
			tbModelTabID.TextChanged += new EventHandler(
				hex32_TextChanged
			);
			tbModelTabID.Validated += new EventHandler(
				hex32_Validated
			);
			tbModelTabID.Validating +=
				new System.ComponentModel.CancelEventHandler(hex32_Validating);
			//
			// label33
			//
			resources.ApplyResources(label33, "label33");
			label33.Name = "label33";
			//
			// tbObjType
			//
			resources.ApplyResources(tbObjType, "tbObjType");
			tbObjType.Name = "tbObjType";
			tbObjType.TextChanged += new EventHandler(
				hex32_TextChanged
			);
			tbObjType.Validated += new EventHandler(hex32_Validated);
			tbObjType.Validating += new System.ComponentModel.CancelEventHandler(
				hex32_Validating
			);
			//
			// label34
			//
			resources.ApplyResources(label34, "label34");
			label34.Name = "label34";
			//
			// tbUIDispType
			//
			resources.ApplyResources(tbUIDispType, "tbUIDispType");
			tbUIDispType.Name = "tbUIDispType";
			tbUIDispType.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			tbUIDispType.Validated += new EventHandler(
				hex16_Validated
			);
			tbUIDispType.Validating +=
				new System.ComponentModel.CancelEventHandler(hex16_Validating);
			//
			// label35
			//
			resources.ApplyResources(label35, "label35");
			label35.Name = "label35";
			//
			// tbAutonomy
			//
			resources.ApplyResources(tbAutonomy, "tbAutonomy");
			tbAutonomy.Name = "tbAutonomy";
			tbAutonomy.TextChanged += new EventHandler(
				hex32_TextChanged
			);
			tbAutonomy.Validated += new EventHandler(hex32_Validated);
			tbAutonomy.Validating += new System.ComponentModel.CancelEventHandler(
				hex32_Validating
			);
			//
			// tbMemIterMult
			//
			resources.ApplyResources(tbMemIterMult, "tbMemIterMult");
			tbMemIterMult.Name = "tbMemIterMult";
			tbMemIterMult.TextChanged += new EventHandler(
				float_TextChanged
			);
			tbMemIterMult.Validated += new EventHandler(
				float_Validated
			);
			tbMemIterMult.Validating +=
				new System.ComponentModel.CancelEventHandler(float_Validating);
			//
			// label29
			//
			resources.ApplyResources(label29, "label29");
			label29.Name = "label29";
			//
			// tbFaceAnimID
			//
			resources.ApplyResources(tbFaceAnimID, "tbFaceAnimID");
			tbFaceAnimID.Name = "tbFaceAnimID";
			tbFaceAnimID.TextChanged += new EventHandler(
				hex32_TextChanged
			);
			tbFaceAnimID.Validated += new EventHandler(
				hex32_Validated
			);
			tbFaceAnimID.Validating +=
				new System.ComponentModel.CancelEventHandler(hex32_Validating);
			//
			// label30
			//
			resources.ApplyResources(label30, "label30");
			label30.Name = "label30";
			//
			// tbAttenuationValue
			//
			resources.ApplyResources(tbAttenuationValue, "tbAttenuationValue");
			tbAttenuationValue.Name = "tbAttenuationValue";
			tbAttenuationValue.TextChanged += new EventHandler(
				float_TextChanged
			);
			tbAttenuationValue.Validated += new EventHandler(
				float_Validated
			);
			tbAttenuationValue.Validating +=
				new System.ComponentModel.CancelEventHandler(float_Validating);
			//
			// label31
			//
			resources.ApplyResources(label31, "label31");
			label31.Name = "label31";
			//
			// label32
			//
			resources.ApplyResources(label32, "label32");
			label32.Name = "label32";
			//
			// gbFlags
			//
			gbFlags.Controls.Add(btnNoFlags);
			gbFlags.Controls.Add(tbFlags);
			gbFlags.Controls.Add(label24);
			gbFlags.Controls.Add(cbBit0);
			gbFlags.Controls.Add(cbBitE);
			gbFlags.Controls.Add(cbBitF);
			gbFlags.Controls.Add(cbBitC);
			gbFlags.Controls.Add(cbBitD);
			gbFlags.Controls.Add(cbBitB);
			gbFlags.Controls.Add(cbBitA);
			gbFlags.Controls.Add(cbBit9);
			gbFlags.Controls.Add(cbBit8);
			gbFlags.Controls.Add(cbBit7);
			gbFlags.Controls.Add(cbBit6);
			gbFlags.Controls.Add(cbBit5);
			gbFlags.Controls.Add(cbBit4);
			gbFlags.Controls.Add(cbBit3);
			gbFlags.Controls.Add(cbBit2);
			gbFlags.Controls.Add(cbBit1);
			resources.ApplyResources(gbFlags, "gbFlags");
			gbFlags.Name = "gbFlags";
			gbFlags.TabStop = false;
			//
			// btnNoFlags
			//
			resources.ApplyResources(btnNoFlags, "btnNoFlags");
			btnNoFlags.Name = "btnNoFlags";
			btnNoFlags.Click += new EventHandler(btnNoFlags_Click);
			//
			// tbFlags
			//
			resources.ApplyResources(tbFlags, "tbFlags");
			tbFlags.Name = "tbFlags";
			tbFlags.TextChanged += new EventHandler(hex16_TextChanged);
			tbFlags.Validated += new EventHandler(hex16_Validated);
			tbFlags.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			//
			// label24
			//
			resources.ApplyResources(label24, "label24");
			label24.Name = "label24";
			//
			// cbBit0
			//
			resources.ApplyResources(cbBit0, "cbBit0");
			cbBit0.Name = "cbBit0";
			cbBit0.Tag = "";
			cbBit0.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBitE
			//
			resources.ApplyResources(cbBitE, "cbBitE");
			cbBitE.Name = "cbBitE";
			cbBitE.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBitF
			//
			resources.ApplyResources(cbBitF, "cbBitF");
			cbBitF.Name = "cbBitF";
			cbBitF.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBitC
			//
			resources.ApplyResources(cbBitC, "cbBitC");
			cbBitC.Name = "cbBitC";
			cbBitC.Tag = "dogs/adult big dogs";
			cbBitC.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBitD
			//
			resources.ApplyResources(cbBitD, "cbBitD");
			cbBitD.Name = "cbBitD";
			cbBitD.Tag = "cats/adult cats";
			cbBitD.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBitB
			//
			resources.ApplyResources(cbBitB, "cbBitB");
			cbBitB.Name = "cbBitB";
			cbBitB.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBitA
			//
			resources.ApplyResources(cbBitA, "cbBitA");
			cbBitA.Name = "cbBitA";
			cbBitA.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBit9
			//
			resources.ApplyResources(cbBit9, "cbBit9");
			cbBit9.Name = "cbBit9";
			cbBit9.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBit8
			//
			resources.ApplyResources(cbBit8, "cbBit8");
			cbBit8.Name = "cbBit8";
			cbBit8.Tag = "auto first/auto first?";
			cbBit8.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBit7
			//
			resources.ApplyResources(cbBit7, "cbBit7");
			cbBit7.Name = "cbBit7";
			cbBit7.Tag = "debug menu/debug menu?";
			cbBit7.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBit6
			//
			resources.ApplyResources(cbBit6, "cbBit6");
			cbBit6.Name = "cbBit6";
			cbBit6.Tag = "";
			cbBit6.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBit5
			//
			resources.ApplyResources(cbBit5, "cbBit5");
			cbBit5.Name = "cbBit5";
			cbBit5.Tag = "demo child/2-way?";
			cbBit5.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBit4
			//
			resources.ApplyResources(cbBit4, "cbBit4");
			cbBit4.Name = "cbBit4";
			cbBit4.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBit3
			//
			resources.ApplyResources(cbBit3, "cbBit3");
			cbBit3.Name = "cbBit3";
			cbBit3.Tag = "consecutive/consecutive?";
			cbBit3.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBit2
			//
			resources.ApplyResources(cbBit2, "cbBit2");
			cbBit2.Name = "cbBit2";
			cbBit2.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// cbBit1
			//
			resources.ApplyResources(cbBit1, "cbBit1");
			cbBit1.Name = "cbBit1";
			cbBit1.Tag = "joinable/joinable?";
			cbBit1.CheckedChanged += new EventHandler(
				checkbox_CheckedChanged
			);
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// tbJoinIndex
			//
			resources.ApplyResources(tbJoinIndex, "tbJoinIndex");
			tbJoinIndex.Name = "tbJoinIndex";
			tbJoinIndex.TextChanged += new EventHandler(
				hex32_TextChanged
			);
			tbJoinIndex.Validated += new EventHandler(hex32_Validated);
			tbJoinIndex.Validating += new System.ComponentModel.CancelEventHandler(
				hex32_Validating
			);
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// tpHumanMotives
			//
			resources.ApplyResources(tpHumanMotives, "tpHumanMotives");
			tpHumanMotives.Controls.Add(timtuiHuman);
			tpHumanMotives.Name = "tpHumanMotives";
			tpHumanMotives.Tag = "Motives/Human Motives";
			tpHumanMotives.UseVisualStyleBackColor = true;
			//
			// timtuiHuman
			//
			resources.ApplyResources(timtuiHuman, "timtuiHuman");
			timtuiHuman.MotiveTable = null;
			timtuiHuman.Name = "timtuiHuman";
			//
			// tpAnimalMotives
			//
			resources.ApplyResources(tpAnimalMotives, "tpAnimalMotives");
			tpAnimalMotives.Controls.Add(timtuiAnimal);
			tpAnimalMotives.Name = "tpAnimalMotives";
			tpAnimalMotives.UseVisualStyleBackColor = true;
			//
			// timtuiAnimal
			//
			resources.ApplyResources(timtuiAnimal, "timtuiAnimal");
			timtuiAnimal.MotiveTable = null;
			timtuiAnimal.Name = "timtuiAnimal";
			//
			// pjse_banner1
			//
			resources.ApplyResources(pjse_banner1, "pjse_banner1");
			pjse_banner1.Name = "pjse_banner1";
			//
			// TtabForm
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(ttabPanel);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "TtabForm";
			WindowState = FormWindowState.Maximized;
			ttabPanel.ResumeLayout(false);
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			flpFileCtrl.ResumeLayout(false);
			flpFileCtrl.PerformLayout();
			tabControl1.ResumeLayout(false);
			tpSettings.ResumeLayout(false);
			tpSettings.PerformLayout();
			tlpSettingsHead.ResumeLayout(false);
			tlpSettingsHead.PerformLayout();
			flpPieStringID.ResumeLayout(false);
			flpPieStringID.PerformLayout();
			flpAction.ResumeLayout(false);
			flpAction.PerformLayout();
			flpGuard.ResumeLayout(false);
			flpGuard.PerformLayout();
			gbFlags2.ResumeLayout(false);
			gbFlags2.PerformLayout();
			gbFlags.ResumeLayout(false);
			gbFlags.PerformLayout();
			tpHumanMotives.ResumeLayout(false);
			tpAnimalMotives.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion


		// -------------- wrapper
		//
		// wrapper
		//
		// --------------

		private void btnCommit_Click(object sender, EventArgs e)
		{
			try
			{
				wrapper.SynchronizeUserData();
				btnCommit.Enabled = wrapper.Changed;
				//TtabSelect(null, null);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					pjse.Localization.GetString("errwritingfile"),
					ex
				);
			}
		}

		private void tbFilename_TextChanged(object sender, EventArgs e)
		{
			internalchg = true;
			wrapper.FileName = tbFilename.Text;
			internalchg = false;
		}

		private void tbFilename_Validated(object sender, EventArgs e)
		{
			tbFilename.SelectAll();
		}

		// Format is a hex32 field, currently handled with ttabItem
		private void doFormat()
		{
		}

		// -------------- wrapper[]
		//
		// wrapper[]
		//
		// --------------

		private void btnStrPrev_Click(object sender, EventArgs e)
		{
			lbttab.SelectedIndex--;
		}

		private void btnStrNext_Click(object sender, EventArgs e)
		{
			lbttab.SelectedIndex++;
		}

		private void btnMoveUp_Click(object sender, EventArgs e)
		{
			int i = lbttab.SelectedIndex;
			object a,
				b;

			internalchg = true;
			a = lbttab.Items[i];
			b = lbttab.Items[i - 1];
			wrapper.Move(i, i - 1);
			lbttab.Items[i] = b;
			lbttab.Items[i - 1] = a;
			internalchg = false;

			lbttab.SelectedIndex--;
		}

		private void btnMoveDown_Click(object sender, EventArgs e)
		{
			int i = lbttab.SelectedIndex;
			object a,
				b;

			internalchg = true;
			a = lbttab.Items[i];
			b = lbttab.Items[i + 1];
			wrapper.Move(i, i + 1);
			lbttab.Items[i] = b;
			lbttab.Items[i + 1] = a;
			internalchg = false;

			lbttab.SelectedIndex++;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			ttabPanel.SuspendLayout();
			internalchg = true;
			wrapper.Add(
				(lbttab.SelectedIndex == -1)
					? new TtabItem(wrapper)
					: wrapper[lbttab.SelectedIndex].Clone()
			);
			addItem(wrapper.Count - 1);
			internalchg = false;
			lbttab.SelectedIndex = wrapper.Count - 1;
			ttabPanel.ResumeLayout();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			wrapper.RemoveAt(lbttab.SelectedIndex);
		}

		private void btnAppend_Click(object sender, EventArgs e)
		{
			Append(
				(new ResourceChooser()).Execute(
					wrapper.FileDescriptor.Type,
					wrapper.FileDescriptor.Group,
					ttabPanel,
					true
				)
			);
		}

		// -------------- ttabItem
		//
		// ttabItem
		//
		// --------------

		private void TtabSelect(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			internalchg = true;

			ttabPanel.SuspendLayout();
			ttabPanel.Cursor = Cursors.AppStarting;

			btnMoveUp.Enabled = btnStrPrev.Enabled = (
				lbttab.SelectedIndex > 0
			);
			btnMoveDown.Enabled = btnStrNext.Enabled = (
				lbttab.SelectedIndex < lbttab.Items.Count - 1
			);

			if (lbttab.SelectedIndex >= 0)
			{
				lbTTABEntry.Text = "0x" + lbttab.SelectedIndex.ToString("X");

				tabControl1.Enabled = btnDelete.Enabled = true;

				currentItem = wrapper[lbttab.SelectedIndex];
				origItem = currentItem.Clone();

				setStringIndex(currentItem.StringIndex, true, true);

				setBHAV(0, currentItem.Action, false);
				setBHAV(1, currentItem.Guardian, false);

				tbFlags.Text = "0x" + Helper.HexString(currentItem.Flags);
				tbFlags2.Text = "0x" + Helper.HexString(currentItem.Flags2);
				if (currentItem.AttenuationCode < cbAttenuationCode.Items.Count)
				{
					cbAttenuationCode.SelectedIndex = (int)currentItem.AttenuationCode;
				}
				else
				{
					cbAttenuationCode.SelectedIndex = -1;
					cbAttenuationCode.Text =
						"0x" + Helper.HexString(currentItem.AttenuationCode);
				}
				tbAttenuationValue.Text = currentItem.AttenuationValue.ToString("N8");
				tbAutonomy.Text = "0x" + Helper.HexString(currentItem.Autonomy);
				tbJoinIndex.Text = "0x" + Helper.HexString(currentItem.JoinIndex);
				tbUIDispType.Text = "0x" + Helper.HexString(currentItem.UIDisplayType);
				tbFaceAnimID.Text =
					"0x" + Helper.HexString(currentItem.FacialAnimationID);
				tbMemIterMult.Text = currentItem.MemoryIterativeMultiplier.ToString(
					"N8"
				);
				tbObjType.Text = "0x" + Helper.HexString(currentItem.ObjectType);
				tbModelTabID.Text = "0x" + Helper.HexString(currentItem.ModelTableID);

				doFlags();
				doFlags2();

				timtuiHuman.MotiveTable = wrapper[lbttab.SelectedIndex].HumanMotives;
				timtuiAnimal.MotiveTable = wrapper[lbttab.SelectedIndex].AnimalMotives;
			}
			else
			{
				lbTTABEntry.Text = "---";

				tabControl1.Enabled = btnDelete.Enabled = false;

				cbAttenuationCode.SelectedIndex = -1;
				tbGuardian.Text =
					tbAction.Text =
					lbguard.Text =
					lbaction.Text =
					tbFlags.Text =
					tbFlags2.Text =
					tbStringIndex.Text =
					tbAttenuationValue.Text =
					tbAutonomy.Text =
					tbJoinIndex.Text =
					tbUIDispType.Text =
					tbFaceAnimID.Text =
					tbMemIterMult.Text =
					tbObjType.Text =
					tbModelTabID.Text =
						"";
				for (int i = 0; i < alFlags.Count; i++)
				{
					((CheckBox)alFlags[i]).Checked = false;
				}
			}

			ttabPanel.ResumeLayout();
			ttabPanel.Cursor = Cursors.Default;

			internalchg = false;
		}

		/*
		 * By way of reminder:
		 * action           - ushort - 4 hex digits (BHAV number)
		 * guard            - ushort - 4 hex digits (BHAV number)
		 * flags            - ushort - 4 hex digits
		 * flags2           - ushort - 4 hex digits
		 * strindex         - uint   - 8 hex digits
		 * attenuationcode  - uint   - 8 hex digits
		 * attenuationvalue - uint   - 8 hex digits
		 * autonomy         - uint   - 8 hex digits
		 * joinindex        - uint   - 8 hex digits
		 * uidisplaytype    - ushort - 4 hex digits
		 * facialanimation  - uint   - 8 hex digits
		 * memoryitermult   - float  - decimal digits and "."
		 * objecttype       - uint   - 8 hex digits
		 * modeltableid     - uint   - 8 hex digits
		 */

		private void GetTTABGuard(object sender, EventArgs e)
		{
			pjse.FileTable.Entry item = new ResourceChooser().Execute(
				Data.MetaData.BHAV_FILE,
				wrapper.FileDescriptor.Group,
				ttabPanel.Parent,
				false
			);
			if (item != null)
			{
				setBHAV(1, (ushort)item.Instance, false);
			}
		}

		private void GetTTABAction(object sender, EventArgs e)
		{
			pjse.FileTable.Entry item = new ResourceChooser().Execute(
				Data.MetaData.BHAV_FILE,
				wrapper.FileDescriptor.Group,
				ttabPanel.Parent,
				false
			);
			if (item != null)
			{
				setBHAV(0, (ushort)item.Instance, false);
			}
		}

		private void llBhav_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			pjse.FileTable.Entry item = wrapper.ResourceByInstance(
				Data.MetaData.BHAV_FILE,
				(sender == llAction) ? currentItem.Action : currentItem.Guardian
			);
			Bhav b = new Bhav();
			b.ProcessData(item.PFD, item.Package);

			BhavForm ui = (BhavForm)b.UIHandler;
			ui.Tag =
				"Popup" // tells the SetReadOnly function it's in a popup - so everything locked down
				+ ";callerID=+"
				+ wrapper.FileDescriptor.ExportFileName
				+ "+";
			ui.Text =
				pjse.Localization.GetString("viewbhav")
				+ ": "
				+ b.FileName
				+ " ["
				+ b.Package.SaveFileName
				+ "]";
			b.RefreshUI();
			ui.Show();
		}

		private void btnNoFlags_Click(object sender, EventArgs e)
		{
			internalchg = true;
			currentItem.Flags = (ushort)(wrapper.Format < 0x54 ? 0x0070 : 0x0000);
			tbFlags.Text = "0x" + Helper.HexString(currentItem.Flags);
			doFlags();
			internalchg = false;
		}

		private void btnNoFlags2_Click(object sender, EventArgs e)
		{
			internalchg = true;
			currentItem.Flags2 = 0x0000;
			tbFlags2.Text = "0x" + Helper.HexString(currentItem.Flags2);
			doFlags2();
			internalchg = false;
		}

		private void checkbox_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			if (!(sender is CheckBox))
			{
				return;
			}

			int i = alFlags.IndexOf(sender);
			if (i < 0)
			{
				throw new Exception(
					"checkbox_CheckedChanged not applicable to control "
						+ sender.ToString()
				);
			}

			internalchg = true;
			if (i < 16)
			{
				Boolset flags = new Boolset(currentItem.Flags);
				flags.flip(i);
				currentItem.Flags = flags;
				tbFlags.Text = "0x" + Helper.HexString(currentItem.Flags);
			}
			else if (i < 32)
			{
				Boolset flags = new Boolset(currentItem.Flags2);
				flags.flip(i - 16);
				currentItem.Flags2 = flags;
				tbFlags2.Text = "0x" + Helper.HexString(currentItem.Flags2);
			}
			internalchg = false;
		}

		private void cbHex32_Enter(object sender, EventArgs e)
		{
			((ComboBox)sender).SelectAll();
		}

		private void cbHex32_TextChanged(object sender, EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!cbHex32_IsValid(sender))
			{
				return;
			}

			if (((ComboBox)sender).FindStringExact(((ComboBox)sender).Text) >= 0)
			{
				return;
			}

			uint val = Convert.ToUInt32(((ComboBox)sender).Text, 16);
			internalchg = true;
			switch (alHex32cb.IndexOf(sender))
			{
				case 0:
					currentItem.StringIndex = val;
					setStringIndex(val, true, false);
					lbttab.Items[lbttab.SelectedIndex] = currentItem;
					break;
				case 1:
					currentItem.AttenuationCode = val;
					break;
			}
			internalchg = false;
		}

		private void cbHex32_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (cbHex32_IsValid(sender))
			{
				return;
			}

			e.Cancel = true;

			int i = alHex32cb.IndexOf(sender);
			if (i < 0)
			{
				throw new Exception(
					"cbHex32_Validating not applicable to control " + sender.ToString()
				);
			}

			uint val = 0;
			switch (i)
			{
				case 0:
					val = origItem.StringIndex;
					currentItem.StringIndex = val;
					break;
				case 1:
					val = origItem.AttenuationCode;
					currentItem.AttenuationCode = val;
					break;
			}

			bool origstate = internalchg;
			internalchg = true;
			if (i == 0)
			{
				setStringIndex(val, true, true);
				lbttab.Items[lbttab.SelectedIndex] = currentItem;
			}
			else if (i == 1)
			{
				if (val < ((ComboBox)sender).Items.Count)
				{
					((ComboBox)sender).SelectedIndex = (int)val;
				}
				else
				{
					((ComboBox)sender).SelectedIndex = -1;
					((ComboBox)sender).Text = "0x" + Helper.HexString(val);
				}
			}
			internalchg = origstate;
			((ComboBox)sender).SelectAll();
		}

		private void cbHex32_Validated(object sender, EventArgs e)
		{
			int i = alHex32cb.IndexOf(sender);
			if (i < 0)
			{
				throw new Exception(
					"cbHex32_Validated not applicable to control " + sender.ToString()
				);
			}

			if (((ComboBox)sender).FindStringExact(((ComboBox)sender).Text) >= 0)
			{
				return;
			}

			uint val = Convert.ToUInt32(((ComboBox)sender).Text, 16);

			bool origstate = internalchg;
			internalchg = true;
			if (i == 0)
			{
				setStringIndex(val, true, true);
			}
			else if (i == 1)
			{
				if (val < ((ComboBox)sender).Items.Count)
				{
					((ComboBox)sender).SelectedIndex = (int)val;
				}
				else
				{
					((ComboBox)sender).SelectedIndex = -1;
					((ComboBox)sender).Text = "0x" + Helper.HexString(val);
				}
			}
			internalchg = origstate;
			((ComboBox)sender).Select(0, 0);
		}

		private void cbHex32_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			int i = alHex32cb.IndexOf(sender);
			if (i < 0)
			{
				throw new Exception(
					"cbHex32_SelectedIndexChanged not applicable to control "
						+ sender.ToString()
				);
			}

			if (((ComboBox)sender).SelectedIndex == -1)
			{
				return;
			}

			int val = ((ComboBox)sender).SelectedIndex;

			internalchg = true;
			if (i == 0)
			{
				setStringIndex((uint)val, true, false);
				tbStringIndex.Focus();
			}
			else if (i == 1)
			{
				currentItem.AttenuationCode = (uint)val;
			}
			internalchg = false;

			((ComboBox)sender).SelectAll();
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
					currentItem.Action = val;
					setBHAV(0, val, true);
					break;
				case 1:
					currentItem.Guardian = val;
					setBHAV(1, val, true);
					break;
				case 2:
					currentItem.Flags = val;
					doFlags();
					break;
				case 3:
					currentItem.Flags2 = val;
					doFlags2();
					break;
				case 4:
					currentItem.UIDisplayType = val;
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

			internalchg = true;
			ushort val = 0;
			switch (alHex16.IndexOf(sender))
			{
				case 0:
					currentItem.Action = val = origItem.Action;
					setBHAV(0, val, true);
					break;
				case 1:
					currentItem.Guardian = val = origItem.Guardian;
					setBHAV(1, val, true);
					break;
				case 2:
					currentItem.Flags = val = origItem.Flags;
					doFlags();
					break;
				case 3:
					currentItem.Flags2 = val = origItem.Flags2;
					break;
				case 4:
					currentItem.UIDisplayType = val = origItem.UIDisplayType;
					break;
			}
			((TextBox)sender).Text = "0x" + Helper.HexString(val);
			((TextBox)sender).SelectAll();
			internalchg = false;
		}

		private void hex16_Validated(object sender, EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x" + Helper.HexString(Convert.ToUInt16(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
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

			uint val = Convert.ToUInt32(((TextBox)sender).Text, 16);
			internalchg = true;
			switch (alHex32.IndexOf(sender))
			{
				case 0:
					wrapper.Format = val;
					break;
				case 1:
					setStringIndex(val, false, true);
					break;
				case 2:
					currentItem.Autonomy = val;
					break;
				case 3:
					currentItem.FacialAnimationID = val;
					break;
				case 4:
					currentItem.ObjectType = val;
					break;
				case 5:
					currentItem.ModelTableID = val;
					break;
				case 6:
					currentItem.JoinIndex = val;
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

			internalchg = true;
			uint val = 0;
			switch (alHex32.IndexOf(sender))
			{
				case 0:
					val = wrapper.Format;
					break;
				case 1:
					currentItem.StringIndex = val = origItem.StringIndex;
					lbttab.Items[lbttab.SelectedIndex] = currentItem;
					break;
				case 2:
					currentItem.Autonomy = val = origItem.Autonomy;
					break;
				case 3:
					currentItem.FacialAnimationID = val = origItem.FacialAnimationID;
					break;
				case 4:
					currentItem.ObjectType = val = origItem.ObjectType;
					break;
				case 5:
					currentItem.ModelTableID = val = origItem.ModelTableID;
					break;
				case 6:
					currentItem.JoinIndex = val = origItem.JoinIndex;
					break;
			}

			((TextBox)sender).Text = "0x" + Helper.HexString(val);
			((TextBox)sender).SelectAll();
			internalchg = false;
		}

		private void hex32_Validated(object sender, EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x" + Helper.HexString(Convert.ToUInt32(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
			if (alHex32.IndexOf(sender) == 0)
			{
				setFormat();
			}
		}

		private void float_TextChanged(object sender, EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!float_IsValid(sender))
			{
				return;
			}

			float val = Convert.ToSingle(((TextBox)sender).Text);
			internalchg = true;
			switch (alFloats.IndexOf(sender))
			{
				case 0:
					currentItem.AttenuationValue = val;
					break;
				case 1:
					currentItem.MemoryIterativeMultiplier = val;
					break;
			}
			internalchg = false;
		}

		private void float_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (float_IsValid(sender))
			{
				return;
			}

			e.Cancel = true;

			internalchg = true;
			float val = 0.0f;
			switch (alFloats.IndexOf(sender))
			{
				case 0:
					currentItem.AttenuationValue = val = origItem.AttenuationValue;
					break;
				case 1:
					currentItem.MemoryIterativeMultiplier = val =
						origItem.MemoryIterativeMultiplier;
					break;
			}

			((TextBox)sender).Text = val.ToString("N8");
			((TextBox)sender).SelectAll();
			internalchg = false;
		}

		private void float_Validated(object sender, EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = Convert
				.ToSingle(((TextBox)sender).Text)
				.ToString("N8");
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}
	}
}
