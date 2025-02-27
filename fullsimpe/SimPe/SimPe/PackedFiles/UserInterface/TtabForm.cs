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
	public class TtabForm : System.Windows.Forms.Form, IPackedFileUI
	{
		#region Form variables

		private System.Windows.Forms.Panel ttabPanel;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpSettings;
		private System.Windows.Forms.Label lbaction;
		private System.Windows.Forms.Label lbguard;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox tbGuardian;
		private System.Windows.Forms.CheckBox cbBitE;
		private System.Windows.Forms.CheckBox cbBitF;
		private System.Windows.Forms.CheckBox cbBitC;
		private System.Windows.Forms.CheckBox cbBitD;
		private System.Windows.Forms.CheckBox cbBitB;
		private System.Windows.Forms.CheckBox cbBitA;
		private System.Windows.Forms.CheckBox cbBit9;
		private System.Windows.Forms.CheckBox cbBit8;
		private System.Windows.Forms.CheckBox cbBit7;
		private System.Windows.Forms.CheckBox cbBit6;
		private System.Windows.Forms.CheckBox cbBit5;
		private System.Windows.Forms.CheckBox cbBit4;
		private System.Windows.Forms.CheckBox cbBit3;
		private System.Windows.Forms.CheckBox cbBit2;
		private System.Windows.Forms.CheckBox cbBit1;
		private System.Windows.Forms.TabPage tpHumanMotives;
		private System.Windows.Forms.CheckBox cbBit0;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox tbAction;
		private System.Windows.Forms.TextBox tbStringIndex;
		private System.Windows.Forms.GroupBox gbFlags;
		private System.Windows.Forms.TextBox tbFlags;
		private System.Windows.Forms.TextBox tbAttenuationValue;
		private System.Windows.Forms.TextBox tbAutonomy;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbJoinIndex;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnGuardian;
		private System.Windows.Forms.Button btnAction;
		private System.Windows.Forms.ComboBox cbAttenuationCode;
		private System.Windows.Forms.ListBox lbttab;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Label lbFilename;
		private System.Windows.Forms.TextBox tbFilename;
		private System.Windows.Forms.TextBox tbFormat;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Button btnCommit;
		private System.Windows.Forms.Button btnAppend;
		private System.Windows.Forms.TextBox tbUIDispType;
		private System.Windows.Forms.TextBox tbFaceAnimID;
		private System.Windows.Forms.TextBox tbMemIterMult;
		private System.Windows.Forms.TextBox tbObjType;
		private System.Windows.Forms.TextBox tbModelTabID;
		private System.Windows.Forms.ComboBox cbStringIndex;
		private System.Windows.Forms.LinkLabel llAction;
		private System.Windows.Forms.LinkLabel llGuardian;
		private System.Windows.Forms.Button btnNoFlags;
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

			this.label40.Left = this.tbStringIndex.Left - this.label40.Width - 6;
			this.llAction.Left = this.tbStringIndex.Left - this.llAction.Width - 6;
			this.llGuardian.Left = this.tbStringIndex.Left - this.llGuardian.Width - 6;

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
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
			if (setHandler)
			{
				wrapper.WrapperChanged -= new System.EventHandler(this.WrapperChanged);
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
			);
			pan.Title = "\"Pie String ID\" increment";
			pan.Prompt = "";
			DialogResult dr = pan.ShowDialog();
			if (dr == DialogResult.OK)
			{
				return pan.Value;
			}

			return 0xffffffff;
		}

		private void populateCbStringIndex()
		{
			bool prev = internalchg;
			internalchg = true;

			int cbStringIndexSelectedIndex = this.cbStringIndex.SelectedIndex;

			this.cbStringIndex.Items.Clear();

			uint c = getTTAsCount();
			Str w = StrRes;
			for (int i = 0; i < c; i++)
			{
				FallbackStrItem si = w[1, i];
				this.cbStringIndex.Items.Add(
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

			if (
				cbStringIndexSelectedIndex >= 0
				&& cbStringIndexSelectedIndex < this.cbStringIndex.Items.Count
			)
			{
				this.cbStringIndex.SelectedIndex = cbStringIndexSelectedIndex;
			}
			else
			{
				this.cbStringIndex.SelectedIndex = -1;
			}

			internalchg = prev;
		}

		private void populateLbttab()
		{
			bool prev = internalchg;
			internalchg = true;
			this.ttabPanel.SuspendLayout();

			int lbttabSelectedIndex = this.lbttab.SelectedIndex;

			lbttab.Items.Clear();
			for (int i = 0; i < wrapper.Count; i++)
			{
				addItem(i);
			}

			if (lbttabSelectedIndex >= 0)
			{
				if (lbttabSelectedIndex < lbttab.Items.Count)
				{
					this.lbttab.SelectedIndex = lbttabSelectedIndex;
				}
				else
				{
					this.lbttab.SelectedIndex = lbttab.Items.Count - 1;
				}
			}

			this.ttabPanel.ResumeLayout();
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

			this.tbUIDispType.Enabled =
				this.tbFaceAnimID.Enabled =
				this.tbModelTabID.Enabled =
				this.tbMemIterMult.Enabled =
				this.tbObjType.Enabled =
					false;

			this.tabControl1.TabPages.Remove(this.tpAnimalMotives);

			int index = 0;

			if (wrapper.Format >= 0x45)
			{
				this.tbUIDispType.Enabled = true;
				if (wrapper.Format >= 0x46)
				{
					this.tbModelTabID.Enabled = true;
					if (wrapper.Format >= 0x4a)
					{
						this.tbFaceAnimID.Enabled = true;
						if (wrapper.Format >= 0x4c)
						{
							this.tbMemIterMult.Enabled = this.tbObjType.Enabled = true;
							if (wrapper.Format >= 0x54)
							{
								this.tabControl1.TabPages.Add(this.tpAnimalMotives);
								index = 1;
							}
						}
					}
				}
			}
			this.tpHumanMotives.Text = ((String)this.tpHumanMotives.Tag).Split(new char[] { '/' })[
				index
			];
			for (int i = 0; i < this.alFlags.Count; i++)
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

		private String lbttabItem(int i)
		{
			if (
				wrapper[i] != null
				&& wrapper[i].StringIndex < cbStringIndex.Items.Count
			)
			{
				return (String)cbStringIndex.Items[(int)wrapper[i].StringIndex];
			}
			else
			{
				return "[0x"
					+ i.ToString("X")
					+ " ("
					+ i
					+ "): "
					+ pjse.Localization.GetString("unk")
					+ ": 0x"
					+ SimPe.Helper.HexString(wrapper[i].StringIndex)
					+ "]";
			}
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
			lbaGA[which].Text = pjse.BhavWiz.bhavName(wrapper, target, ref found);

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
					this.cbStringIndex.SelectedIndex = (int)si;
				}
				else
				{
					this.cbStringIndex.SelectedIndex = -1;
					this.cbStringIndex.Text = tbStringIndex.Text;
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
			this.cbStringIndex.SelectedIndex = -1;
			populateCbStringIndex();

			// Avoid warning popups from setFormat()!
			previousFormat = wrapper.Format;
			// WrapperChanged() calls populateLbttab(), so set lbttab.SelectedIndex to -1
			this.lbttab.SelectedIndex = -1;
			WrapperChanged(wrapper, null);

			internalchg = true;
			populateLbttab();
			internalchg = false;

			// Now call TtabSelect (one way or another)
			if (this.lbttab.Items.Count > 0)
			{
				this.lbttab.SelectedIndex = 0;
			}
			else
			{
				TtabSelect(null, null);
			}

			if (!setHandler)
			{
				wrapper.WrapperChanged += new System.EventHandler(this.WrapperChanged);
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

		private void WrapperChanged(object sender, System.EventArgs e)
		{
			this.btnCommit.Enabled = wrapper.Changed;

			if (internalchg)
			{
				return;
			}

			internalchg = true;

			if (sender == wrapper)
			{
				this.Text = tbFilename.Text = wrapper.FileName;
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
			this.ttabPanel = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lbttab = new System.Windows.Forms.ListBox();
			this.flpFileCtrl = new System.Windows.Forms.FlowLayoutPanel();
			this.lbFilename = new System.Windows.Forms.Label();
			this.tbFilename = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.tbFormat = new System.Windows.Forms.TextBox();
			this.btnCommit = new System.Windows.Forms.Button();
			this.label26 = new System.Windows.Forms.Label();
			this.btnStrPrev = new System.Windows.Forms.Button();
			this.btnMoveUp = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnStrNext = new System.Windows.Forms.Button();
			this.btnMoveDown = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnAppend = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpSettings = new System.Windows.Forms.TabPage();
			this.tlpSettingsHead = new System.Windows.Forms.TableLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.lbTTABEntry = new System.Windows.Forms.Label();
			this.llGuardian = new System.Windows.Forms.LinkLabel();
			this.label40 = new System.Windows.Forms.Label();
			this.llAction = new System.Windows.Forms.LinkLabel();
			this.flpPieStringID = new System.Windows.Forms.FlowLayoutPanel();
			this.tbStringIndex = new System.Windows.Forms.TextBox();
			this.cbStringIndex = new System.Windows.Forms.ComboBox();
			this.lbPieString = new System.Windows.Forms.Label();
			this.flpAction = new System.Windows.Forms.FlowLayoutPanel();
			this.tbAction = new System.Windows.Forms.TextBox();
			this.btnAction = new System.Windows.Forms.Button();
			this.lbaction = new System.Windows.Forms.Label();
			this.flpGuard = new System.Windows.Forms.FlowLayoutPanel();
			this.tbGuardian = new System.Windows.Forms.TextBox();
			this.btnGuardian = new System.Windows.Forms.Button();
			this.lbguard = new System.Windows.Forms.Label();
			this.gbFlags2 = new System.Windows.Forms.GroupBox();
			this.tbFlags2 = new System.Windows.Forms.TextBox();
			this.btnNoFlags2 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cb2Bit0 = new System.Windows.Forms.CheckBox();
			this.cb2BitE = new System.Windows.Forms.CheckBox();
			this.cb2BitF = new System.Windows.Forms.CheckBox();
			this.cb2BitC = new System.Windows.Forms.CheckBox();
			this.cb2BitD = new System.Windows.Forms.CheckBox();
			this.cb2BitB = new System.Windows.Forms.CheckBox();
			this.cb2BitA = new System.Windows.Forms.CheckBox();
			this.cb2Bit9 = new System.Windows.Forms.CheckBox();
			this.cb2Bit8 = new System.Windows.Forms.CheckBox();
			this.cb2Bit7 = new System.Windows.Forms.CheckBox();
			this.cb2Bit6 = new System.Windows.Forms.CheckBox();
			this.cb2Bit5 = new System.Windows.Forms.CheckBox();
			this.cb2Bit4 = new System.Windows.Forms.CheckBox();
			this.cb2Bit3 = new System.Windows.Forms.CheckBox();
			this.cb2Bit2 = new System.Windows.Forms.CheckBox();
			this.cb2Bit1 = new System.Windows.Forms.CheckBox();
			this.cbAttenuationCode = new System.Windows.Forms.ComboBox();
			this.tbModelTabID = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.tbObjType = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.tbUIDispType = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.tbAutonomy = new System.Windows.Forms.TextBox();
			this.tbMemIterMult = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.tbFaceAnimID = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.tbAttenuationValue = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.gbFlags = new System.Windows.Forms.GroupBox();
			this.btnNoFlags = new System.Windows.Forms.Button();
			this.tbFlags = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.cbBit0 = new System.Windows.Forms.CheckBox();
			this.cbBitE = new System.Windows.Forms.CheckBox();
			this.cbBitF = new System.Windows.Forms.CheckBox();
			this.cbBitC = new System.Windows.Forms.CheckBox();
			this.cbBitD = new System.Windows.Forms.CheckBox();
			this.cbBitB = new System.Windows.Forms.CheckBox();
			this.cbBitA = new System.Windows.Forms.CheckBox();
			this.cbBit9 = new System.Windows.Forms.CheckBox();
			this.cbBit8 = new System.Windows.Forms.CheckBox();
			this.cbBit7 = new System.Windows.Forms.CheckBox();
			this.cbBit6 = new System.Windows.Forms.CheckBox();
			this.cbBit5 = new System.Windows.Forms.CheckBox();
			this.cbBit4 = new System.Windows.Forms.CheckBox();
			this.cbBit3 = new System.Windows.Forms.CheckBox();
			this.cbBit2 = new System.Windows.Forms.CheckBox();
			this.cbBit1 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbJoinIndex = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tpHumanMotives = new System.Windows.Forms.TabPage();
			this.timtuiHuman =
				new SimPe.PackedFiles.UserInterface.TtabItemMotiveTableUI();
			this.tpAnimalMotives = new System.Windows.Forms.TabPage();
			this.timtuiAnimal =
				new SimPe.PackedFiles.UserInterface.TtabItemMotiveTableUI();
			this.pjse_banner1 = new pjse.pjse_banner();
			this.ttabPanel.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.flpFileCtrl.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tpSettings.SuspendLayout();
			this.tlpSettingsHead.SuspendLayout();
			this.flpPieStringID.SuspendLayout();
			this.flpAction.SuspendLayout();
			this.flpGuard.SuspendLayout();
			this.gbFlags2.SuspendLayout();
			this.gbFlags.SuspendLayout();
			this.tpHumanMotives.SuspendLayout();
			this.tpAnimalMotives.SuspendLayout();
			this.SuspendLayout();
			//
			// ttabPanel
			//
			resources.ApplyResources(this.ttabPanel, "ttabPanel");
			this.ttabPanel.BackColor = System.Drawing.SystemColors.Control;
			this.ttabPanel.Controls.Add(this.splitContainer1);
			this.ttabPanel.Controls.Add(this.pjse_banner1);
			this.ttabPanel.Name = "ttabPanel";
			//
			// splitContainer1
			//
			resources.ApplyResources(this.splitContainer1, "splitContainer1");
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Name = "splitContainer1";
			//
			// splitContainer1.Panel1
			//
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
			//
			// splitContainer1.Panel2
			//
			this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
			//
			// tableLayoutPanel1
			//
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.lbttab, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.flpFileCtrl, 0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			//
			// lbttab
			//
			resources.ApplyResources(this.lbttab, "lbttab");
			this.lbttab.Name = "lbttab";
			this.lbttab.SelectedIndexChanged += new System.EventHandler(
				this.TtabSelect
			);
			//
			// flpFileCtrl
			//
			resources.ApplyResources(this.flpFileCtrl, "flpFileCtrl");
			this.flpFileCtrl.Controls.Add(this.lbFilename);
			this.flpFileCtrl.Controls.Add(this.tbFilename);
			this.flpFileCtrl.Controls.Add(this.label41);
			this.flpFileCtrl.Controls.Add(this.tbFormat);
			this.flpFileCtrl.Controls.Add(this.btnCommit);
			this.flpFileCtrl.Controls.Add(this.label26);
			this.flpFileCtrl.Controls.Add(this.btnStrPrev);
			this.flpFileCtrl.Controls.Add(this.btnMoveUp);
			this.flpFileCtrl.Controls.Add(this.btnAdd);
			this.flpFileCtrl.Controls.Add(this.btnStrNext);
			this.flpFileCtrl.Controls.Add(this.btnMoveDown);
			this.flpFileCtrl.Controls.Add(this.btnDelete);
			this.flpFileCtrl.Controls.Add(this.btnAppend);
			this.flpFileCtrl.Name = "flpFileCtrl";
			//
			// lbFilename
			//
			resources.ApplyResources(this.lbFilename, "lbFilename");
			this.flpFileCtrl.SetFlowBreak(this.lbFilename, true);
			this.lbFilename.Name = "lbFilename";
			//
			// tbFilename
			//
			resources.ApplyResources(this.tbFilename, "tbFilename");
			this.flpFileCtrl.SetFlowBreak(this.tbFilename, true);
			this.tbFilename.Name = "tbFilename";
			this.tbFilename.TextChanged += new System.EventHandler(
				this.tbFilename_TextChanged
			);
			this.tbFilename.Validated += new System.EventHandler(
				this.tbFilename_Validated
			);
			//
			// label41
			//
			resources.ApplyResources(this.label41, "label41");
			this.label41.Name = "label41";
			//
			// tbFormat
			//
			resources.ApplyResources(this.tbFormat, "tbFormat");
			this.tbFormat.Name = "tbFormat";
			this.tbFormat.TextChanged += new System.EventHandler(
				this.hex32_TextChanged
			);
			this.tbFormat.Validated += new System.EventHandler(this.hex32_Validated);
			this.tbFormat.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex32_Validating
			);
			//
			// btnCommit
			//
			resources.ApplyResources(this.btnCommit, "btnCommit");
			this.flpFileCtrl.SetFlowBreak(this.btnCommit, true);
			this.btnCommit.Name = "btnCommit";
			this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
			//
			// label26
			//
			resources.ApplyResources(this.label26, "label26");
			this.flpFileCtrl.SetFlowBreak(this.label26, true);
			this.label26.Name = "label26";
			//
			// btnStrPrev
			//
			resources.ApplyResources(this.btnStrPrev, "btnStrPrev");
			this.btnStrPrev.Name = "btnStrPrev";
			this.btnStrPrev.Click += new System.EventHandler(this.btnStrPrev_Click);
			//
			// btnMoveUp
			//
			resources.ApplyResources(this.btnMoveUp, "btnMoveUp");
			this.btnMoveUp.Name = "btnMoveUp";
			this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
			//
			// btnAdd
			//
			resources.ApplyResources(this.btnAdd, "btnAdd");
			this.flpFileCtrl.SetFlowBreak(this.btnAdd, true);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			//
			// btnStrNext
			//
			resources.ApplyResources(this.btnStrNext, "btnStrNext");
			this.btnStrNext.Name = "btnStrNext";
			this.btnStrNext.Click += new System.EventHandler(this.btnStrNext_Click);
			//
			// btnMoveDown
			//
			resources.ApplyResources(this.btnMoveDown, "btnMoveDown");
			this.btnMoveDown.Name = "btnMoveDown";
			this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
			//
			// btnDelete
			//
			resources.ApplyResources(this.btnDelete, "btnDelete");
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			//
			// btnAppend
			//
			resources.ApplyResources(this.btnAppend, "btnAppend");
			this.btnAppend.Name = "btnAppend";
			this.btnAppend.Click += new System.EventHandler(this.btnAppend_Click);
			//
			// tabControl1
			//
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.Controls.Add(this.tpSettings);
			this.tabControl1.Controls.Add(this.tpHumanMotives);
			this.tabControl1.Controls.Add(this.tpAnimalMotives);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			//
			// tpSettings
			//
			resources.ApplyResources(this.tpSettings, "tpSettings");
			this.tpSettings.Controls.Add(this.tlpSettingsHead);
			this.tpSettings.Controls.Add(this.gbFlags2);
			this.tpSettings.Controls.Add(this.cbAttenuationCode);
			this.tpSettings.Controls.Add(this.tbModelTabID);
			this.tpSettings.Controls.Add(this.label33);
			this.tpSettings.Controls.Add(this.tbObjType);
			this.tpSettings.Controls.Add(this.label34);
			this.tpSettings.Controls.Add(this.tbUIDispType);
			this.tpSettings.Controls.Add(this.label35);
			this.tpSettings.Controls.Add(this.tbAutonomy);
			this.tpSettings.Controls.Add(this.tbMemIterMult);
			this.tpSettings.Controls.Add(this.label29);
			this.tpSettings.Controls.Add(this.tbFaceAnimID);
			this.tpSettings.Controls.Add(this.label30);
			this.tpSettings.Controls.Add(this.tbAttenuationValue);
			this.tpSettings.Controls.Add(this.label31);
			this.tpSettings.Controls.Add(this.label32);
			this.tpSettings.Controls.Add(this.gbFlags);
			this.tpSettings.Controls.Add(this.label1);
			this.tpSettings.Controls.Add(this.tbJoinIndex);
			this.tpSettings.Controls.Add(this.label2);
			this.tpSettings.Name = "tpSettings";
			this.tpSettings.UseVisualStyleBackColor = true;
			//
			// tlpSettingsHead
			//
			resources.ApplyResources(this.tlpSettingsHead, "tlpSettingsHead");
			this.tlpSettingsHead.Controls.Add(this.label4, 0, 0);
			this.tlpSettingsHead.Controls.Add(this.lbTTABEntry, 1, 0);
			this.tlpSettingsHead.Controls.Add(this.llGuardian, 0, 3);
			this.tlpSettingsHead.Controls.Add(this.label40, 0, 1);
			this.tlpSettingsHead.Controls.Add(this.llAction, 0, 2);
			this.tlpSettingsHead.Controls.Add(this.flpPieStringID, 1, 1);
			this.tlpSettingsHead.Controls.Add(this.flpAction, 1, 2);
			this.tlpSettingsHead.Controls.Add(this.flpGuard, 1, 3);
			this.tlpSettingsHead.Name = "tlpSettingsHead";
			//
			// label4
			//
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			//
			// lbTTABEntry
			//
			resources.ApplyResources(this.lbTTABEntry, "lbTTABEntry");
			this.lbTTABEntry.Name = "lbTTABEntry";
			//
			// llGuardian
			//
			resources.ApplyResources(this.llGuardian, "llGuardian");
			this.llGuardian.Name = "llGuardian";
			this.llGuardian.TabStop = true;
			this.llGuardian.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.llBhav_LinkClicked
				);
			//
			// label40
			//
			resources.ApplyResources(this.label40, "label40");
			this.label40.Name = "label40";
			//
			// llAction
			//
			resources.ApplyResources(this.llAction, "llAction");
			this.llAction.Name = "llAction";
			this.llAction.TabStop = true;
			this.llAction.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.llBhav_LinkClicked
				);
			//
			// flpPieStringID
			//
			resources.ApplyResources(this.flpPieStringID, "flpPieStringID");
			this.flpPieStringID.Controls.Add(this.tbStringIndex);
			this.flpPieStringID.Controls.Add(this.cbStringIndex);
			this.flpPieStringID.Controls.Add(this.lbPieString);
			this.flpPieStringID.Name = "flpPieStringID";
			//
			// tbStringIndex
			//
			resources.ApplyResources(this.tbStringIndex, "tbStringIndex");
			this.tbStringIndex.Name = "tbStringIndex";
			this.tbStringIndex.TextChanged += new System.EventHandler(
				this.hex32_TextChanged
			);
			this.tbStringIndex.Validated += new System.EventHandler(
				this.hex32_Validated
			);
			this.tbStringIndex.Validating +=
				new System.ComponentModel.CancelEventHandler(this.hex32_Validating);
			//
			// cbStringIndex
			//
			resources.ApplyResources(this.cbStringIndex, "cbStringIndex");
			this.cbStringIndex.DisplayMember = "Display";
			this.cbStringIndex.DropDownWidth = 240;
			this.cbStringIndex.Items.AddRange(
				new object[]
				{
					resources.GetString("cbStringIndex.Items"),
					resources.GetString("cbStringIndex.Items1"),
					resources.GetString("cbStringIndex.Items2"),
				}
			);
			this.cbStringIndex.Name = "cbStringIndex";
			this.cbStringIndex.TabStop = false;
			this.cbStringIndex.ValueMember = "Value";
			this.cbStringIndex.Validating +=
				new System.ComponentModel.CancelEventHandler(this.cbHex32_Validating);
			this.cbStringIndex.SelectedIndexChanged += new System.EventHandler(
				this.cbHex32_SelectedIndexChanged
			);
			this.cbStringIndex.Enter += new System.EventHandler(this.cbHex32_Enter);
			this.cbStringIndex.Validated += new System.EventHandler(
				this.cbHex32_Validated
			);
			this.cbStringIndex.TextChanged += new System.EventHandler(
				this.cbHex32_TextChanged
			);
			//
			// lbPieString
			//
			resources.ApplyResources(this.lbPieString, "lbPieString");
			this.lbPieString.Name = "lbPieString";
			this.lbPieString.UseMnemonic = false;
			//
			// flpAction
			//
			resources.ApplyResources(this.flpAction, "flpAction");
			this.flpAction.Controls.Add(this.tbAction);
			this.flpAction.Controls.Add(this.btnAction);
			this.flpAction.Controls.Add(this.lbaction);
			this.flpAction.Name = "flpAction";
			//
			// tbAction
			//
			resources.ApplyResources(this.tbAction, "tbAction");
			this.tbAction.Name = "tbAction";
			this.tbAction.TextChanged += new System.EventHandler(
				this.hex16_TextChanged
			);
			this.tbAction.Validated += new System.EventHandler(this.hex16_Validated);
			this.tbAction.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			//
			// btnAction
			//
			resources.ApplyResources(this.btnAction, "btnAction");
			this.btnAction.Name = "btnAction";
			this.btnAction.Click += new System.EventHandler(this.GetTTABAction);
			//
			// lbaction
			//
			resources.ApplyResources(this.lbaction, "lbaction");
			this.lbaction.Name = "lbaction";
			this.lbaction.UseMnemonic = false;
			//
			// flpGuard
			//
			resources.ApplyResources(this.flpGuard, "flpGuard");
			this.flpGuard.Controls.Add(this.tbGuardian);
			this.flpGuard.Controls.Add(this.btnGuardian);
			this.flpGuard.Controls.Add(this.lbguard);
			this.flpGuard.Name = "flpGuard";
			//
			// tbGuardian
			//
			resources.ApplyResources(this.tbGuardian, "tbGuardian");
			this.tbGuardian.Name = "tbGuardian";
			this.tbGuardian.TextChanged += new System.EventHandler(
				this.hex16_TextChanged
			);
			this.tbGuardian.Validated += new System.EventHandler(this.hex16_Validated);
			this.tbGuardian.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			//
			// btnGuardian
			//
			resources.ApplyResources(this.btnGuardian, "btnGuardian");
			this.btnGuardian.Name = "btnGuardian";
			this.btnGuardian.Click += new System.EventHandler(this.GetTTABGuard);
			//
			// lbguard
			//
			resources.ApplyResources(this.lbguard, "lbguard");
			this.lbguard.Name = "lbguard";
			this.lbguard.UseMnemonic = false;
			//
			// gbFlags2
			//
			this.gbFlags2.Controls.Add(this.tbFlags2);
			this.gbFlags2.Controls.Add(this.btnNoFlags2);
			this.gbFlags2.Controls.Add(this.label3);
			this.gbFlags2.Controls.Add(this.cb2Bit0);
			this.gbFlags2.Controls.Add(this.cb2BitE);
			this.gbFlags2.Controls.Add(this.cb2BitF);
			this.gbFlags2.Controls.Add(this.cb2BitC);
			this.gbFlags2.Controls.Add(this.cb2BitD);
			this.gbFlags2.Controls.Add(this.cb2BitB);
			this.gbFlags2.Controls.Add(this.cb2BitA);
			this.gbFlags2.Controls.Add(this.cb2Bit9);
			this.gbFlags2.Controls.Add(this.cb2Bit8);
			this.gbFlags2.Controls.Add(this.cb2Bit7);
			this.gbFlags2.Controls.Add(this.cb2Bit6);
			this.gbFlags2.Controls.Add(this.cb2Bit5);
			this.gbFlags2.Controls.Add(this.cb2Bit4);
			this.gbFlags2.Controls.Add(this.cb2Bit3);
			this.gbFlags2.Controls.Add(this.cb2Bit2);
			this.gbFlags2.Controls.Add(this.cb2Bit1);
			resources.ApplyResources(this.gbFlags2, "gbFlags2");
			this.gbFlags2.Name = "gbFlags2";
			this.gbFlags2.TabStop = false;
			//
			// tbFlags2
			//
			resources.ApplyResources(this.tbFlags2, "tbFlags2");
			this.tbFlags2.Name = "tbFlags2";
			this.tbFlags2.TextChanged += new System.EventHandler(
				this.hex16_TextChanged
			);
			this.tbFlags2.Validated += new System.EventHandler(this.hex16_Validated);
			this.tbFlags2.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			//
			// btnNoFlags2
			//
			resources.ApplyResources(this.btnNoFlags2, "btnNoFlags2");
			this.btnNoFlags2.Name = "btnNoFlags2";
			this.btnNoFlags2.Click += new System.EventHandler(this.btnNoFlags2_Click);
			//
			// label3
			//
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			//
			// cb2Bit0
			//
			resources.ApplyResources(this.cb2Bit0, "cb2Bit0");
			this.cb2Bit0.Name = "cb2Bit0";
			this.cb2Bit0.Tag = "";
			this.cb2Bit0.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2BitE
			//
			resources.ApplyResources(this.cb2BitE, "cb2BitE");
			this.cb2BitE.Name = "cb2BitE";
			this.cb2BitE.Tag = "";
			this.cb2BitE.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2BitF
			//
			resources.ApplyResources(this.cb2BitF, "cb2BitF");
			this.cb2BitF.Name = "cb2BitF";
			this.cb2BitF.Tag = "";
			this.cb2BitF.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2BitC
			//
			resources.ApplyResources(this.cb2BitC, "cb2BitC");
			this.cb2BitC.Name = "cb2BitC";
			this.cb2BitC.Tag = "?/adult small dogs";
			this.cb2BitC.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2BitD
			//
			resources.ApplyResources(this.cb2BitD, "cb2BitD");
			this.cb2BitD.Name = "cb2BitD";
			this.cb2BitD.Tag = "?/elder small dogs";
			this.cb2BitD.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2BitB
			//
			resources.ApplyResources(this.cb2BitB, "cb2BitB");
			this.cb2BitB.Name = "cb2BitB";
			this.cb2BitB.Tag = "?/elder cats";
			this.cb2BitB.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2BitA
			//
			resources.ApplyResources(this.cb2BitA, "cb2BitA");
			this.cb2BitA.Name = "cb2BitA";
			this.cb2BitA.Tag = "?/elder big dogs";
			this.cb2BitA.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2Bit9
			//
			resources.ApplyResources(this.cb2Bit9, "cb2Bit9");
			this.cb2Bit9.Name = "cb2Bit9";
			this.cb2Bit9.Tag = "?/kittens";
			this.cb2Bit9.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2Bit8
			//
			resources.ApplyResources(this.cb2Bit8, "cb2Bit8");
			this.cb2Bit8.Name = "cb2Bit8";
			this.cb2Bit8.Tag = "?/puppies";
			this.cb2Bit8.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2Bit7
			//
			resources.ApplyResources(this.cb2Bit7, "cb2Bit7");
			this.cb2Bit7.Name = "cb2Bit7";
			this.cb2Bit7.Tag = "";
			this.cb2Bit7.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2Bit6
			//
			resources.ApplyResources(this.cb2Bit6, "cb2Bit6");
			this.cb2Bit6.Name = "cb2Bit6";
			this.cb2Bit6.Tag = "";
			this.cb2Bit6.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2Bit5
			//
			resources.ApplyResources(this.cb2Bit5, "cb2Bit5");
			this.cb2Bit5.Name = "cb2Bit5";
			this.cb2Bit5.Tag = "";
			this.cb2Bit5.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2Bit4
			//
			resources.ApplyResources(this.cb2Bit4, "cb2Bit4");
			this.cb2Bit4.Name = "cb2Bit4";
			this.cb2Bit4.Tag = "";
			this.cb2Bit4.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2Bit3
			//
			resources.ApplyResources(this.cb2Bit3, "cb2Bit3");
			this.cb2Bit3.Name = "cb2Bit3";
			this.cb2Bit3.Tag = "";
			this.cb2Bit3.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2Bit2
			//
			resources.ApplyResources(this.cb2Bit2, "cb2Bit2");
			this.cb2Bit2.Name = "cb2Bit2";
			this.cb2Bit2.Tag = "";
			this.cb2Bit2.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cb2Bit1
			//
			resources.ApplyResources(this.cb2Bit1, "cb2Bit1");
			this.cb2Bit1.Name = "cb2Bit1";
			this.cb2Bit1.Tag = "";
			this.cb2Bit1.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbAttenuationCode
			//
			resources.ApplyResources(this.cbAttenuationCode, "cbAttenuationCode");
			this.cbAttenuationCode.Items.AddRange(
				new object[]
				{
					resources.GetString("cbAttenuationCode.Items"),
					resources.GetString("cbAttenuationCode.Items1"),
					resources.GetString("cbAttenuationCode.Items2"),
					resources.GetString("cbAttenuationCode.Items3"),
					resources.GetString("cbAttenuationCode.Items4"),
				}
			);
			this.cbAttenuationCode.Name = "cbAttenuationCode";
			this.cbAttenuationCode.Validating +=
				new System.ComponentModel.CancelEventHandler(this.cbHex32_Validating);
			this.cbAttenuationCode.SelectedIndexChanged += new System.EventHandler(
				this.cbHex32_SelectedIndexChanged
			);
			this.cbAttenuationCode.Enter += new System.EventHandler(this.cbHex32_Enter);
			this.cbAttenuationCode.Validated += new System.EventHandler(
				this.cbHex32_Validated
			);
			this.cbAttenuationCode.TextChanged += new System.EventHandler(
				this.cbHex32_TextChanged
			);
			//
			// tbModelTabID
			//
			resources.ApplyResources(this.tbModelTabID, "tbModelTabID");
			this.tbModelTabID.Name = "tbModelTabID";
			this.tbModelTabID.TextChanged += new System.EventHandler(
				this.hex32_TextChanged
			);
			this.tbModelTabID.Validated += new System.EventHandler(
				this.hex32_Validated
			);
			this.tbModelTabID.Validating +=
				new System.ComponentModel.CancelEventHandler(this.hex32_Validating);
			//
			// label33
			//
			resources.ApplyResources(this.label33, "label33");
			this.label33.Name = "label33";
			//
			// tbObjType
			//
			resources.ApplyResources(this.tbObjType, "tbObjType");
			this.tbObjType.Name = "tbObjType";
			this.tbObjType.TextChanged += new System.EventHandler(
				this.hex32_TextChanged
			);
			this.tbObjType.Validated += new System.EventHandler(this.hex32_Validated);
			this.tbObjType.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex32_Validating
			);
			//
			// label34
			//
			resources.ApplyResources(this.label34, "label34");
			this.label34.Name = "label34";
			//
			// tbUIDispType
			//
			resources.ApplyResources(this.tbUIDispType, "tbUIDispType");
			this.tbUIDispType.Name = "tbUIDispType";
			this.tbUIDispType.TextChanged += new System.EventHandler(
				this.hex16_TextChanged
			);
			this.tbUIDispType.Validated += new System.EventHandler(
				this.hex16_Validated
			);
			this.tbUIDispType.Validating +=
				new System.ComponentModel.CancelEventHandler(this.hex16_Validating);
			//
			// label35
			//
			resources.ApplyResources(this.label35, "label35");
			this.label35.Name = "label35";
			//
			// tbAutonomy
			//
			resources.ApplyResources(this.tbAutonomy, "tbAutonomy");
			this.tbAutonomy.Name = "tbAutonomy";
			this.tbAutonomy.TextChanged += new System.EventHandler(
				this.hex32_TextChanged
			);
			this.tbAutonomy.Validated += new System.EventHandler(this.hex32_Validated);
			this.tbAutonomy.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex32_Validating
			);
			//
			// tbMemIterMult
			//
			resources.ApplyResources(this.tbMemIterMult, "tbMemIterMult");
			this.tbMemIterMult.Name = "tbMemIterMult";
			this.tbMemIterMult.TextChanged += new System.EventHandler(
				this.float_TextChanged
			);
			this.tbMemIterMult.Validated += new System.EventHandler(
				this.float_Validated
			);
			this.tbMemIterMult.Validating +=
				new System.ComponentModel.CancelEventHandler(this.float_Validating);
			//
			// label29
			//
			resources.ApplyResources(this.label29, "label29");
			this.label29.Name = "label29";
			//
			// tbFaceAnimID
			//
			resources.ApplyResources(this.tbFaceAnimID, "tbFaceAnimID");
			this.tbFaceAnimID.Name = "tbFaceAnimID";
			this.tbFaceAnimID.TextChanged += new System.EventHandler(
				this.hex32_TextChanged
			);
			this.tbFaceAnimID.Validated += new System.EventHandler(
				this.hex32_Validated
			);
			this.tbFaceAnimID.Validating +=
				new System.ComponentModel.CancelEventHandler(this.hex32_Validating);
			//
			// label30
			//
			resources.ApplyResources(this.label30, "label30");
			this.label30.Name = "label30";
			//
			// tbAttenuationValue
			//
			resources.ApplyResources(this.tbAttenuationValue, "tbAttenuationValue");
			this.tbAttenuationValue.Name = "tbAttenuationValue";
			this.tbAttenuationValue.TextChanged += new System.EventHandler(
				this.float_TextChanged
			);
			this.tbAttenuationValue.Validated += new System.EventHandler(
				this.float_Validated
			);
			this.tbAttenuationValue.Validating +=
				new System.ComponentModel.CancelEventHandler(this.float_Validating);
			//
			// label31
			//
			resources.ApplyResources(this.label31, "label31");
			this.label31.Name = "label31";
			//
			// label32
			//
			resources.ApplyResources(this.label32, "label32");
			this.label32.Name = "label32";
			//
			// gbFlags
			//
			this.gbFlags.Controls.Add(this.btnNoFlags);
			this.gbFlags.Controls.Add(this.tbFlags);
			this.gbFlags.Controls.Add(this.label24);
			this.gbFlags.Controls.Add(this.cbBit0);
			this.gbFlags.Controls.Add(this.cbBitE);
			this.gbFlags.Controls.Add(this.cbBitF);
			this.gbFlags.Controls.Add(this.cbBitC);
			this.gbFlags.Controls.Add(this.cbBitD);
			this.gbFlags.Controls.Add(this.cbBitB);
			this.gbFlags.Controls.Add(this.cbBitA);
			this.gbFlags.Controls.Add(this.cbBit9);
			this.gbFlags.Controls.Add(this.cbBit8);
			this.gbFlags.Controls.Add(this.cbBit7);
			this.gbFlags.Controls.Add(this.cbBit6);
			this.gbFlags.Controls.Add(this.cbBit5);
			this.gbFlags.Controls.Add(this.cbBit4);
			this.gbFlags.Controls.Add(this.cbBit3);
			this.gbFlags.Controls.Add(this.cbBit2);
			this.gbFlags.Controls.Add(this.cbBit1);
			resources.ApplyResources(this.gbFlags, "gbFlags");
			this.gbFlags.Name = "gbFlags";
			this.gbFlags.TabStop = false;
			//
			// btnNoFlags
			//
			resources.ApplyResources(this.btnNoFlags, "btnNoFlags");
			this.btnNoFlags.Name = "btnNoFlags";
			this.btnNoFlags.Click += new System.EventHandler(this.btnNoFlags_Click);
			//
			// tbFlags
			//
			resources.ApplyResources(this.tbFlags, "tbFlags");
			this.tbFlags.Name = "tbFlags";
			this.tbFlags.TextChanged += new System.EventHandler(this.hex16_TextChanged);
			this.tbFlags.Validated += new System.EventHandler(this.hex16_Validated);
			this.tbFlags.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			//
			// label24
			//
			resources.ApplyResources(this.label24, "label24");
			this.label24.Name = "label24";
			//
			// cbBit0
			//
			resources.ApplyResources(this.cbBit0, "cbBit0");
			this.cbBit0.Name = "cbBit0";
			this.cbBit0.Tag = "";
			this.cbBit0.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBitE
			//
			resources.ApplyResources(this.cbBitE, "cbBitE");
			this.cbBitE.Name = "cbBitE";
			this.cbBitE.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBitF
			//
			resources.ApplyResources(this.cbBitF, "cbBitF");
			this.cbBitF.Name = "cbBitF";
			this.cbBitF.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBitC
			//
			resources.ApplyResources(this.cbBitC, "cbBitC");
			this.cbBitC.Name = "cbBitC";
			this.cbBitC.Tag = "dogs/adult big dogs";
			this.cbBitC.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBitD
			//
			resources.ApplyResources(this.cbBitD, "cbBitD");
			this.cbBitD.Name = "cbBitD";
			this.cbBitD.Tag = "cats/adult cats";
			this.cbBitD.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBitB
			//
			resources.ApplyResources(this.cbBitB, "cbBitB");
			this.cbBitB.Name = "cbBitB";
			this.cbBitB.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBitA
			//
			resources.ApplyResources(this.cbBitA, "cbBitA");
			this.cbBitA.Name = "cbBitA";
			this.cbBitA.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBit9
			//
			resources.ApplyResources(this.cbBit9, "cbBit9");
			this.cbBit9.Name = "cbBit9";
			this.cbBit9.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBit8
			//
			resources.ApplyResources(this.cbBit8, "cbBit8");
			this.cbBit8.Name = "cbBit8";
			this.cbBit8.Tag = "auto first/auto first?";
			this.cbBit8.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBit7
			//
			resources.ApplyResources(this.cbBit7, "cbBit7");
			this.cbBit7.Name = "cbBit7";
			this.cbBit7.Tag = "debug menu/debug menu?";
			this.cbBit7.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBit6
			//
			resources.ApplyResources(this.cbBit6, "cbBit6");
			this.cbBit6.Name = "cbBit6";
			this.cbBit6.Tag = "";
			this.cbBit6.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBit5
			//
			resources.ApplyResources(this.cbBit5, "cbBit5");
			this.cbBit5.Name = "cbBit5";
			this.cbBit5.Tag = "demo child/2-way?";
			this.cbBit5.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBit4
			//
			resources.ApplyResources(this.cbBit4, "cbBit4");
			this.cbBit4.Name = "cbBit4";
			this.cbBit4.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBit3
			//
			resources.ApplyResources(this.cbBit3, "cbBit3");
			this.cbBit3.Name = "cbBit3";
			this.cbBit3.Tag = "consecutive/consecutive?";
			this.cbBit3.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBit2
			//
			resources.ApplyResources(this.cbBit2, "cbBit2");
			this.cbBit2.Name = "cbBit2";
			this.cbBit2.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// cbBit1
			//
			resources.ApplyResources(this.cbBit1, "cbBit1");
			this.cbBit1.Name = "cbBit1";
			this.cbBit1.Tag = "joinable/joinable?";
			this.cbBit1.CheckedChanged += new System.EventHandler(
				this.checkbox_CheckedChanged
			);
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// tbJoinIndex
			//
			resources.ApplyResources(this.tbJoinIndex, "tbJoinIndex");
			this.tbJoinIndex.Name = "tbJoinIndex";
			this.tbJoinIndex.TextChanged += new System.EventHandler(
				this.hex32_TextChanged
			);
			this.tbJoinIndex.Validated += new System.EventHandler(this.hex32_Validated);
			this.tbJoinIndex.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex32_Validating
			);
			//
			// label2
			//
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			//
			// tpHumanMotives
			//
			resources.ApplyResources(this.tpHumanMotives, "tpHumanMotives");
			this.tpHumanMotives.Controls.Add(this.timtuiHuman);
			this.tpHumanMotives.Name = "tpHumanMotives";
			this.tpHumanMotives.Tag = "Motives/Human Motives";
			this.tpHumanMotives.UseVisualStyleBackColor = true;
			//
			// timtuiHuman
			//
			resources.ApplyResources(this.timtuiHuman, "timtuiHuman");
			this.timtuiHuman.MotiveTable = null;
			this.timtuiHuman.Name = "timtuiHuman";
			//
			// tpAnimalMotives
			//
			resources.ApplyResources(this.tpAnimalMotives, "tpAnimalMotives");
			this.tpAnimalMotives.Controls.Add(this.timtuiAnimal);
			this.tpAnimalMotives.Name = "tpAnimalMotives";
			this.tpAnimalMotives.UseVisualStyleBackColor = true;
			//
			// timtuiAnimal
			//
			resources.ApplyResources(this.timtuiAnimal, "timtuiAnimal");
			this.timtuiAnimal.MotiveTable = null;
			this.timtuiAnimal.Name = "timtuiAnimal";
			//
			// pjse_banner1
			//
			resources.ApplyResources(this.pjse_banner1, "pjse_banner1");
			this.pjse_banner1.Name = "pjse_banner1";
			//
			// TtabForm
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.ttabPanel);
			this.FormBorderStyle = System
				.Windows
				.Forms
				.FormBorderStyle
				.SizableToolWindow;
			this.Name = "TtabForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ttabPanel.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.flpFileCtrl.ResumeLayout(false);
			this.flpFileCtrl.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tpSettings.ResumeLayout(false);
			this.tpSettings.PerformLayout();
			this.tlpSettingsHead.ResumeLayout(false);
			this.tlpSettingsHead.PerformLayout();
			this.flpPieStringID.ResumeLayout(false);
			this.flpPieStringID.PerformLayout();
			this.flpAction.ResumeLayout(false);
			this.flpAction.PerformLayout();
			this.flpGuard.ResumeLayout(false);
			this.flpGuard.PerformLayout();
			this.gbFlags2.ResumeLayout(false);
			this.gbFlags2.PerformLayout();
			this.gbFlags.ResumeLayout(false);
			this.gbFlags.PerformLayout();
			this.tpHumanMotives.ResumeLayout(false);
			this.tpAnimalMotives.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		#endregion


		// -------------- wrapper
		//
		// wrapper
		//
		// --------------

		private void btnCommit_Click(object sender, System.EventArgs e)
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

		private void tbFilename_TextChanged(object sender, System.EventArgs e)
		{
			internalchg = true;
			wrapper.FileName = tbFilename.Text;
			internalchg = false;
		}

		private void tbFilename_Validated(object sender, System.EventArgs e)
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

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			this.ttabPanel.SuspendLayout();
			internalchg = true;
			wrapper.Add(
				(lbttab.SelectedIndex == -1)
					? new TtabItem(wrapper)
					: wrapper[lbttab.SelectedIndex].Clone()
			);
			addItem(wrapper.Count - 1);
			internalchg = false;
			lbttab.SelectedIndex = wrapper.Count - 1;
			this.ttabPanel.ResumeLayout();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			wrapper.RemoveAt(lbttab.SelectedIndex);
		}

		private void btnAppend_Click(object sender, System.EventArgs e)
		{
			this.Append(
				(new pjse.ResourceChooser()).Execute(
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

		private void TtabSelect(object sender, System.EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			internalchg = true;

			this.ttabPanel.SuspendLayout();
			this.ttabPanel.Cursor = Cursors.AppStarting;

			this.btnMoveUp.Enabled = this.btnStrPrev.Enabled = (
				lbttab.SelectedIndex > 0
			);
			this.btnMoveDown.Enabled = this.btnStrNext.Enabled = (
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

				this.tbFlags.Text = "0x" + Helper.HexString(currentItem.Flags);
				this.tbFlags2.Text = "0x" + Helper.HexString(currentItem.Flags2);
				if (currentItem.AttenuationCode < this.cbAttenuationCode.Items.Count)
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

				tabControl1.Enabled = this.btnDelete.Enabled = false;

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

			this.ttabPanel.ResumeLayout();
			this.ttabPanel.Cursor = Cursors.Default;

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

		private void GetTTABGuard(object sender, System.EventArgs e)
		{
			pjse.FileTable.Entry item = new pjse.ResourceChooser().Execute(
				SimPe.Data.MetaData.BHAV_FILE,
				wrapper.FileDescriptor.Group,
				ttabPanel.Parent,
				false
			);
			if (item != null)
			{
				setBHAV(1, (ushort)item.Instance, false);
			}
		}

		private void GetTTABAction(object sender, System.EventArgs e)
		{
			pjse.FileTable.Entry item = new pjse.ResourceChooser().Execute(
				SimPe.Data.MetaData.BHAV_FILE,
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
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			pjse.FileTable.Entry item = wrapper.ResourceByInstance(
				SimPe.Data.MetaData.BHAV_FILE,
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

		private void btnNoFlags_Click(object sender, System.EventArgs e)
		{
			internalchg = true;
			currentItem.Flags = (ushort)(wrapper.Format < 0x54 ? 0x0070 : 0x0000);
			this.tbFlags.Text = "0x" + Helper.HexString(currentItem.Flags);
			doFlags();
			internalchg = false;
		}

		private void btnNoFlags2_Click(object sender, EventArgs e)
		{
			internalchg = true;
			currentItem.Flags2 = (ushort)0x0000;
			this.tbFlags2.Text = "0x" + Helper.HexString(currentItem.Flags2);
			doFlags2();
			internalchg = false;
		}

		private void checkbox_CheckedChanged(object sender, System.EventArgs e)
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
				this.tbFlags.Text = "0x" + Helper.HexString(currentItem.Flags);
			}
			else if (i < 32)
			{
				Boolset flags = new Boolset(currentItem.Flags2);
				flags.flip(i - 16);
				currentItem.Flags2 = flags;
				this.tbFlags2.Text = "0x" + Helper.HexString(currentItem.Flags2);
			}
			internalchg = false;
		}

		private void cbHex32_Enter(object sender, System.EventArgs e)
		{
			((ComboBox)sender).SelectAll();
		}

		private void cbHex32_TextChanged(object sender, System.EventArgs ev)
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

		private void cbHex32_Validated(object sender, System.EventArgs e)
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

		private void cbHex32_SelectedIndexChanged(object sender, System.EventArgs e)
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

		private void hex16_TextChanged(object sender, System.EventArgs ev)
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

		private void hex16_Validated(object sender, System.EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x" + Helper.HexString(Convert.ToUInt16(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
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

		private void hex32_Validated(object sender, System.EventArgs e)
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

		private void float_TextChanged(object sender, System.EventArgs ev)
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

		private void float_Validated(object sender, System.EventArgs e)
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
