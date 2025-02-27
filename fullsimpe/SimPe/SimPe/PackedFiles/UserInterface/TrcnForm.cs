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

using Bcon = SimPe.PackedFiles.Wrapper.Bcon;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for TrcnForm.
	/// </summary>
	public class TrcnForm : Form, IPackedFileUI
	{
		#region Form variables

		private Panel trcnPanel;
		private Label lbFilename;
		private TextBox tbFilename;
		private ListView lvTrcnItem;
		private ColumnHeader chConstName;
		private ColumnHeader chUsed;
		private ColumnHeader chConstId;
		private ColumnHeader chDefValue;
		private ColumnHeader chMinValue;
		private ColumnHeader chMaxValue;
		private Label lbFormat;
		private TextBox tbFormat;
		private Button btnStrDelete;
		private Button btnStrAdd;
		private Label lbID;
		private Label lbDefValue;
		private Label lbMinValue;
		private Label lbMaxValue;
		private Label lbLabel;
		private TextBox tbDefValue;
		private TextBox tbMinValue;
		private TextBox tbMaxValue;
		private TextBox tbLabel;
		private CheckBox cbUsed;
		private Button btnCancel;
		private Button btnCommit;
		private ColumnHeader chValue;
		private TextBox tbID;
		private ColumnHeader chLine;
		private Panel panel1;
		private Label label5;
		private Button btnStrPrev;
		private Button btnStrNext;
		private TextBox tbDesc;
		private Label lbDesc;
		private pjse.pjse_banner pjse_banner1;
		private TableLayoutPanel tlpUnused;
		private Panel panel2;
		private Button btSetAll;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public TrcnForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.lvTrcnItem.Items.Clear();

			TextBox[] t = { tbFilename, tbLabel };
			alText = new ArrayList(t);

			TextBox[] w = { tbDefValue, tbMinValue, tbMaxValue };
			alHex16 = new ArrayList(w);

			TextBox[] dw = { tbFormat, tbID };
			alHex32 = new ArrayList(dw);

			pjse.FileTable.GFT.FiletableRefresh += new EventHandler(
				this.FiletableRefresh
			);
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				this.lvTrcnItem.Font = new Font(
					"Microsoft Sans Serif",
					11F
				);
				this.chUsed.Width = 48;
				this.chDefValue.Width = 72;
				this.chMinValue.Width = 72;
				this.chMaxValue.Width = 78;
				this.chLine.Width = 84;
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
			if (setHandler && wrapper != null)
			{
				wrapper.WrapperChanged -= new EventHandler(this.WrapperChanged);
				setHandler = false;
			}
			wrapper = null;
			bconres = null;
		}

		#region Controller
		private Trcn wrapper = null;
		private Bcon bconres = null;
		private bool setHandler = false;
		private bool internalchg = false;

		private ArrayList alText = null;
		private ArrayList alHex16 = null;
		private ArrayList alHex32 = null;

		private int index = -1;
		private TrcnItem origItem = null;
		private TrcnItem currentItem = null;

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

		private void doTextOnly()
		{
			trcnPanel.SuspendLayout();
			trcnPanel.Controls.Clear();
			trcnPanel.Controls.Add(this.pjse_banner1);
			trcnPanel.Controls.Add(this.lbFilename);
			tbFilename.ReadOnly = true;
			tbFilename.Text = wrapper.FileName;
			tbFormat.Text = Helper.HexString(wrapper.Version);
			trcnPanel.Controls.Add(this.tbFilename);
			trcnPanel.Controls.Add(this.lbFormat);
			trcnPanel.Controls.Add(this.tbFormat);

			Label lb = new Label();
			lb.AutoSize = true;
			lb.Location = new Point(0, tbFormat.Bottom + 6);
			lb.Text = pjse.Localization.GetString("trcnTextOnly");

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
			tb.Size = trcnPanel.Size;
			tb.Height -= tb.Top;

			tb.Text = getText(wrapper.StoredData);

			trcnPanel.Controls.Add(lb);
			trcnPanel.Controls.Add(tb);
			trcnPanel.ResumeLayout(true);
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

		private void updateSelectedItem()
		{
			ListViewItem lv = this.lvTrcnItem.SelectedItems[0];
			if (lv == null)
			{
				return;
			}

			lv.SubItems[3].Text = "0x" + Helper.HexString(currentItem.ConstId);
			lv.SubItems[4].Text = "0x" + currentItem.Used.ToString("X");
			if (wrapper.Version > 0x53)
			{
				lv.SubItems[5].Text =
					"0x" + Helper.HexString((byte)currentItem.DefValue);
			}
			else
			{
				lv.SubItems[5].Text =
					"0x" + Helper.HexString(currentItem.DefValue);
			}

			lv.SubItems[6].Text = "0x" + Helper.HexString(currentItem.MinValue);
			lv.SubItems[7].Text = "0x" + Helper.HexString(currentItem.MaxValue);
		}

		private string[] trcnItemToStringArray(int i)
		{
			if (i < 0 || i >= wrapper.Count)
			{
				return new string[] { "", "", "", "", "", "", "", "" };
			}

			TrcnItem ti = wrapper[i];
			string tiValue =
				(bconres != null && i < bconres.Count)
					? "0x" + Helper.HexString(bconres[i])
					: "?";

			return new string[]
			{
				"0x" + i.ToString("X") + " (" + i + ")",
				tiValue,
				ti.ConstName,
				"0x"
					+ Helper.HexString(
						ti.ConstId & (wrapper.Version == 0x3f ? 0x000f : 0xffffffff)
					),
				"0x" + ti.Used.ToString("X"),
				"0x"
					+ (
						wrapper.Version > 0x53
							? Helper.HexString((byte)ti.DefValue)
							: Helper.HexString(ti.DefValue)
					),
				"0x" + Helper.HexString(ti.MinValue),
				"0x" + Helper.HexString(ti.MaxValue),
			};
		}

		private void updateLists()
		{
			if (wrapper != null)
			{
				wrapper.CleanUp();
			}

			index = -1;
			bconres = (Bcon)(
				wrapper == null ? null : wrapper.SiblingResource(Bcon.Bcontype)
			);

			this.lvTrcnItem.Items.Clear();
			int nItems = wrapper == null ? 0 : wrapper.Count;
			for (int i = 0; i < nItems; i++)
			{
				this.lvTrcnItem.Items.Add(new ListViewItem(trcnItemToStringArray(i)));
			}
		}

		private void setIndex(int i)
		{
			internalchg = true;
			if (i >= 0)
			{
				this.lvTrcnItem.Items[i].Selected = true;
			}
			else if (index >= 0)
			{
				this.lvTrcnItem.Items[index].Selected = false;
			}

			internalchg = false;

			if (this.lvTrcnItem.SelectedItems.Count > 0)
			{
				if (this.lvTrcnItem.Focused)
				{
					this.lvTrcnItem.SelectedItems[0].Focused = true;
				}

				this.lvTrcnItem.SelectedItems[0].EnsureVisible();
			}
			else
			{
				internalchg = true;
				this.tbLabel.Text = "";
				this.tbID.Text = "";
				this.cbUsed.CheckState = CheckState.Indeterminate;
				this.tbDesc.Text = "";
				this.tbDefValue.Text = "";
				this.tbMinValue.Text = "";
				this.tbMaxValue.Text = "";
				this.btnCancel.Enabled = false;
				internalchg = false;
			}

			if (index == i)
			{
				return;
			}

			index = i;
			displayTrcnItem();
		}

		private void displayTrcnItem()
		{
			currentItem = (index < 0) ? null : wrapper[index];

			internalchg = true;
			if (currentItem != null)
			{
				origItem = currentItem.Clone();

				string[] s = trcnItemToStringArray(index);
				this.tbLabel.Text = s[2];
				this.tbID.Text = s[3];
				this.cbUsed.CheckState =
					currentItem.Used != 0
						? CheckState.Checked
						: CheckState.Unchecked;
				this.tbDesc.Text = currentItem.ConstDesc;
				this.tbDefValue.Text = s[5];
				this.tbMinValue.Text = s[6];
				this.tbMaxValue.Text = s[7];

				this.tbID.Enabled =
					this.tbLabel.Enabled =
					this.tbDefValue.Enabled =
					this.tbMinValue.Enabled =
					this.tbMaxValue.Enabled =
					this.btnStrDelete.Enabled =
						true;
				this.cbUsed.Enabled = (wrapper.Version > 0x3e);
				this.tbDefValue.Enabled =
					this.tbID.Enabled =
					this.tbMinValue.Enabled =
					this.tbMaxValue.Enabled =
						(wrapper.Version > 1);
			}
			else
			{
				origItem = null;

				this.tbID.Text =
					this.tbLabel.Text =
					this.tbDefValue.Text =
					this.tbMinValue.Text =
					this.tbMaxValue.Text =
						"";
				this.cbUsed.CheckState = CheckState.Indeterminate;

				this.tbID.Enabled =
					this.tbLabel.Enabled =
					this.cbUsed.Enabled =
					this.tbDefValue.Enabled =
					this.tbMinValue.Enabled =
					this.tbMaxValue.Enabled =
					this.btnStrDelete.Enabled =
						false;
			}
			this.btnStrPrev.Enabled = (index > 0);
			this.btnStrNext.Enabled = (index < lvTrcnItem.Items.Count - 1);
			internalchg = false;

			this.btnCancel.Enabled = false;
		}

		private void TrcnItemAdd()
		{
			bool savedstate = internalchg;
			internalchg = true;

			try
			{
				wrapper.Add(new TrcnItem(wrapper));
				this.lvTrcnItem.Items.Add(
					new ListViewItem(trcnItemToStringArray(wrapper.Count - 1))
				);
			}
			catch { }

			internalchg = savedstate;

			setIndex(lvTrcnItem.Items.Count - 1);
		}

		private void TrcnItemDelete()
		{
			bool savedstate = internalchg;
			internalchg = true;

			wrapper.Remove(currentItem);
			int i = index;
			updateLists();

			internalchg = savedstate;

			setIndex((i >= lvTrcnItem.Items.Count) ? lvTrcnItem.Items.Count - 1 : i);
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
			if (tbFormat.Text == "0x00000001")
			{
				tbFormat.Text = "0x" + Helper.HexString(wrapper.Version);
			}

			internalchg = savedstate;

			setIndex((i >= lvTrcnItem.Items.Count) ? lvTrcnItem.Items.Count - 1 : i);
		}

		private void Cancel()
		{
			bool savedstate = internalchg;
			internalchg = true;

			this.lvTrcnItem.SelectedItems[0].SubItems[2].Text = currentItem.ConstName =
				origItem.ConstName;
			currentItem.ConstId = origItem.ConstId;
			currentItem.Used = origItem.Used;
			currentItem.DefValue = origItem.DefValue;
			currentItem.MaxValue = origItem.MaxValue;
			currentItem.MinValue = origItem.MinValue;
			updateSelectedItem();

			internalchg = savedstate;

			displayTrcnItem();
		}

		void FiletableRefresh(object sender, EventArgs e)
		{
			pjse_banner1.SiblingEnabled =
				wrapper != null && wrapper.SiblingResource(Bcon.Bcontype) != null;
			updateLists();
		}
		#endregion

		#region IPackedFileUI Member
		/// <summary>
		/// Returns the Control that will be displayed within SimPe
		/// </summary>
		public Control GUIHandle => trcnPanel;

		/// <summary>
		/// Called by the AbstractWrapper when the file should be displayed to the user.
		/// </summary>
		/// <param name="wrp">Reference to the wrapper to be displayed.</param>
		public void UpdateGUI(IFileWrapper wrp)
		{
			wrapper = (Trcn)wrp;
			WrapperChanged(wrapper, null);
			pjse_banner1.SiblingEnabled =
				wrapper.SiblingResource(Bcon.Bcontype) != null;

			internalchg = true;
			updateLists();
			internalchg = false;

			setIndex(lvTrcnItem.Items.Count > 0 ? 0 : -1);

			if (!setHandler)
			{
				wrapper.WrapperChanged += new EventHandler(this.WrapperChanged);
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

			this.tbDesc.ReadOnly = (wrapper.Version <= 0x53);
			this.btnCommit.Enabled = (wrapper.Changed || wrapper.Version == 1);
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
				this.tbFormat.Text = "0x" + Helper.HexString(wrapper.Version);
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
				new System.ComponentModel.ComponentResourceManager(typeof(TrcnForm));
			this.btnCommit = new Button();
			this.trcnPanel = new Panel();
			this.panel2 = new Panel();
			this.btnStrAdd = new Button();
			this.lbLabel = new Label();
			this.btnStrDelete = new Button();
			this.tbLabel = new TextBox();
			this.btnCancel = new Button();
			this.btnStrPrev = new Button();
			this.btnStrNext = new Button();
			this.tlpUnused = new TableLayoutPanel();
			this.label5 = new Label();
			this.lbID = new Label();
			this.tbID = new TextBox();
			this.lbDesc = new Label();
			this.tbDesc = new TextBox();
			this.lbDefValue = new Label();
			this.tbDefValue = new TextBox();
			this.panel1 = new Panel();
			this.lbMinValue = new Label();
			this.tbMinValue = new TextBox();
			this.lbMaxValue = new Label();
			this.tbMaxValue = new TextBox();
			this.cbUsed = new CheckBox();
			this.tbFormat = new TextBox();
			this.lbFormat = new Label();
			this.tbFilename = new TextBox();
			this.lbFilename = new Label();
			this.pjse_banner1 = new pjse.pjse_banner();
			this.lvTrcnItem = new ListView();
			this.chLine = new ColumnHeader();
			this.chValue = new ColumnHeader();
			this.chConstName = new ColumnHeader();
			this.chConstId = new ColumnHeader();
			this.chUsed = new ColumnHeader();
			this.chDefValue = new ColumnHeader();
			this.chMinValue = new ColumnHeader();
			this.chMaxValue = new ColumnHeader();
			this.btSetAll = new Button();
			this.trcnPanel.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tlpUnused.SuspendLayout();
			this.SuspendLayout();
			//
			// btnCommit
			//
			resources.ApplyResources(this.btnCommit, "btnCommit");
			this.btnCommit.Name = "btnCommit";
			this.btnCommit.Click += new EventHandler(this.btnCommit_Click);
			//
			// trcnPanel
			//
			resources.ApplyResources(this.trcnPanel, "trcnPanel");
			this.trcnPanel.Controls.Add(this.btSetAll);
			this.trcnPanel.Controls.Add(this.panel2);
			this.trcnPanel.Controls.Add(this.tlpUnused);
			this.trcnPanel.Controls.Add(this.btnCommit);
			this.trcnPanel.Controls.Add(this.tbFormat);
			this.trcnPanel.Controls.Add(this.lbFormat);
			this.trcnPanel.Controls.Add(this.tbFilename);
			this.trcnPanel.Controls.Add(this.lbFilename);
			this.trcnPanel.Controls.Add(this.pjse_banner1);
			this.trcnPanel.Controls.Add(this.lvTrcnItem);
			this.trcnPanel.Name = "trcnPanel";
			//
			// panel2
			//
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.Controls.Add(this.btnStrAdd);
			this.panel2.Controls.Add(this.lbLabel);
			this.panel2.Controls.Add(this.btnStrDelete);
			this.panel2.Controls.Add(this.tbLabel);
			this.panel2.Controls.Add(this.btnCancel);
			this.panel2.Controls.Add(this.btnStrPrev);
			this.panel2.Controls.Add(this.btnStrNext);
			this.panel2.Name = "panel2";
			//
			// btnStrAdd
			//
			resources.ApplyResources(this.btnStrAdd, "btnStrAdd");
			this.btnStrAdd.Name = "btnStrAdd";
			this.btnStrAdd.Click += new EventHandler(this.btnStrAdd_Click);
			//
			// lbLabel
			//
			resources.ApplyResources(this.lbLabel, "lbLabel");
			this.lbLabel.Name = "lbLabel";
			//
			// btnStrDelete
			//
			resources.ApplyResources(this.btnStrDelete, "btnStrDelete");
			this.btnStrDelete.Name = "btnStrDelete";
			this.btnStrDelete.Click += new EventHandler(this.btnStrDelete_Click);
			//
			// tbLabel
			//
			resources.ApplyResources(this.tbLabel, "tbLabel");
			this.tbLabel.Name = "tbLabel";
			this.tbLabel.TextChanged += new EventHandler(
				this.tbText_TextChanged
			);
			this.tbLabel.Enter += new EventHandler(this.tbText_Enter);
			//
			// btnCancel
			//
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
			//
			// btnStrPrev
			//
			resources.ApplyResources(this.btnStrPrev, "btnStrPrev");
			this.btnStrPrev.Name = "btnStrPrev";
			this.btnStrPrev.TabStop = false;
			this.btnStrPrev.Click += new EventHandler(this.btnStrPrev_Click);
			//
			// btnStrNext
			//
			resources.ApplyResources(this.btnStrNext, "btnStrNext");
			this.btnStrNext.Name = "btnStrNext";
			this.btnStrNext.TabStop = false;
			this.btnStrNext.Click += new EventHandler(this.btnStrNext_Click);
			//
			// tlpUnused
			//
			resources.ApplyResources(this.tlpUnused, "tlpUnused");
			this.tlpUnused.Controls.Add(this.label5, 0, 1);
			this.tlpUnused.Controls.Add(this.lbID, 0, 2);
			this.tlpUnused.Controls.Add(this.tbID, 1, 2);
			this.tlpUnused.Controls.Add(this.lbDesc, 0, 4);
			this.tlpUnused.Controls.Add(this.tbDesc, 1, 4);
			this.tlpUnused.Controls.Add(this.lbDefValue, 0, 5);
			this.tlpUnused.Controls.Add(this.tbDefValue, 1, 5);
			this.tlpUnused.Controls.Add(this.panel1, 0, 0);
			this.tlpUnused.Controls.Add(this.lbMinValue, 0, 6);
			this.tlpUnused.Controls.Add(this.tbMinValue, 1, 6);
			this.tlpUnused.Controls.Add(this.lbMaxValue, 0, 7);
			this.tlpUnused.Controls.Add(this.tbMaxValue, 1, 7);
			this.tlpUnused.Controls.Add(this.cbUsed, 0, 3);
			this.tlpUnused.Name = "tlpUnused";
			//
			// label5
			//
			resources.ApplyResources(this.label5, "label5");
			this.tlpUnused.SetColumnSpan(this.label5, 2);
			this.label5.Name = "label5";
			//
			// lbID
			//
			resources.ApplyResources(this.lbID, "lbID");
			this.lbID.Name = "lbID";
			//
			// tbID
			//
			resources.ApplyResources(this.tbID, "tbID");
			this.tbID.Name = "tbID";
			this.tbID.TextChanged += new EventHandler(this.hex32_TextChanged);
			this.tbID.Validated += new EventHandler(this.hex32_Validated);
			this.tbID.Enter += new EventHandler(this.tbText_Enter);
			this.tbID.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex32_Validating
			);
			//
			// lbDesc
			//
			resources.ApplyResources(this.lbDesc, "lbDesc");
			this.lbDesc.Name = "lbDesc";
			//
			// tbDesc
			//
			resources.ApplyResources(this.tbDesc, "tbDesc");
			this.tbDesc.Name = "tbDesc";
			this.tbDesc.ReadOnly = true;
			this.tbDesc.TextChanged += new EventHandler(this.tbDesc_TextChanged);
			//
			// lbDefValue
			//
			resources.ApplyResources(this.lbDefValue, "lbDefValue");
			this.lbDefValue.Name = "lbDefValue";
			//
			// tbDefValue
			//
			resources.ApplyResources(this.tbDefValue, "tbDefValue");
			this.tbDefValue.Name = "tbDefValue";
			this.tbDefValue.TextChanged += new EventHandler(
				this.hex16_TextChanged
			);
			this.tbDefValue.Validated += new EventHandler(this.hex16_Validated);
			this.tbDefValue.Enter += new EventHandler(this.tbText_Enter);
			this.tbDefValue.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			//
			// panel1
			//
			this.panel1.BorderStyle = BorderStyle.FixedSingle;
			this.tlpUnused.SetColumnSpan(this.panel1, 2);
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Name = "panel1";
			//
			// lbMinValue
			//
			resources.ApplyResources(this.lbMinValue, "lbMinValue");
			this.lbMinValue.Name = "lbMinValue";
			//
			// tbMinValue
			//
			resources.ApplyResources(this.tbMinValue, "tbMinValue");
			this.tbMinValue.Name = "tbMinValue";
			this.tbMinValue.TextChanged += new EventHandler(
				this.hex16_TextChanged
			);
			this.tbMinValue.Validated += new EventHandler(this.hex16_Validated);
			this.tbMinValue.Enter += new EventHandler(this.tbText_Enter);
			this.tbMinValue.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			//
			// lbMaxValue
			//
			resources.ApplyResources(this.lbMaxValue, "lbMaxValue");
			this.lbMaxValue.Name = "lbMaxValue";
			//
			// tbMaxValue
			//
			resources.ApplyResources(this.tbMaxValue, "tbMaxValue");
			this.tbMaxValue.Name = "tbMaxValue";
			this.tbMaxValue.TextChanged += new EventHandler(
				this.hex16_TextChanged
			);
			this.tbMaxValue.Validated += new EventHandler(this.hex16_Validated);
			this.tbMaxValue.Enter += new EventHandler(this.tbText_Enter);
			this.tbMaxValue.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			//
			// cbUsed
			//
			resources.ApplyResources(this.cbUsed, "cbUsed");
			this.tlpUnused.SetColumnSpan(this.cbUsed, 2);
			this.cbUsed.Name = "cbUsed";
			this.cbUsed.CheckedChanged += new EventHandler(
				this.cbUsed_CheckedChanged
			);
			//
			// tbFormat
			//
			resources.ApplyResources(this.tbFormat, "tbFormat");
			this.tbFormat.Name = "tbFormat";
			this.tbFormat.ReadOnly = true;
			this.tbFormat.TextChanged += new EventHandler(
				this.hex32_TextChanged
			);
			this.tbFormat.Validated += new EventHandler(this.hex32_Validated);
			this.tbFormat.Enter += new EventHandler(this.tbText_Enter);
			this.tbFormat.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex32_Validating
			);
			//
			// lbFormat
			//
			resources.ApplyResources(this.lbFormat, "lbFormat");
			this.lbFormat.Name = "lbFormat";
			//
			// tbFilename
			//
			resources.ApplyResources(this.tbFilename, "tbFilename");
			this.tbFilename.Name = "tbFilename";
			this.tbFilename.TextChanged += new EventHandler(
				this.tbText_TextChanged
			);
			this.tbFilename.Enter += new EventHandler(this.tbText_Enter);
			//
			// lbFilename
			//
			resources.ApplyResources(this.lbFilename, "lbFilename");
			this.lbFilename.Name = "lbFilename";
			//
			// pjse_banner1
			//
			resources.ApplyResources(this.pjse_banner1, "pjse_banner1");
			this.pjse_banner1.Name = "pjse_banner1";
			this.pjse_banner1.SiblingVisible = true;
			this.pjse_banner1.SiblingClick += new EventHandler(
				this.pjse_banner1_SiblingClick
			);
			//
			// lvTrcnItem
			//
			resources.ApplyResources(this.lvTrcnItem, "lvTrcnItem");
			this.lvTrcnItem.Columns.AddRange(
				new ColumnHeader[]
				{
					this.chLine,
					this.chValue,
					this.chConstName,
					this.chConstId,
					this.chUsed,
					this.chDefValue,
					this.chMinValue,
					this.chMaxValue,
				}
			);
			this.lvTrcnItem.FullRowSelect = true;
			this.lvTrcnItem.GridLines = true;
			this.lvTrcnItem.HeaderStyle =
				ColumnHeaderStyle
				.Nonclickable;
			this.lvTrcnItem.HideSelection = false;
			this.lvTrcnItem.Items.AddRange(
				new ListViewItem[]
				{
					(
						(ListViewItem)(
							resources.GetObject("lvTrcnItem.Items")
						)
					),
				}
			);
			this.lvTrcnItem.MultiSelect = false;
			this.lvTrcnItem.Name = "lvTrcnItem";
			this.lvTrcnItem.UseCompatibleStateImageBehavior = false;
			this.lvTrcnItem.View = View.Details;
			this.lvTrcnItem.Resize += new EventHandler(this.lvTrcnItem_Resize);
			this.lvTrcnItem.SelectedIndexChanged += new EventHandler(
				this.lvTrcnItem_SelectedIndexChanged
			);
			//
			// chLine
			//
			resources.ApplyResources(this.chLine, "chLine");
			//
			// chValue
			//
			resources.ApplyResources(this.chValue, "chValue");
			//
			// chConstName
			//
			resources.ApplyResources(this.chConstName, "chConstName");
			//
			// chConstId
			//
			resources.ApplyResources(this.chConstId, "chConstId");
			//
			// chUsed
			//
			resources.ApplyResources(this.chUsed, "chUsed");
			//
			// chDefValue
			//
			resources.ApplyResources(this.chDefValue, "chDefValue");
			//
			// chMinValue
			//
			resources.ApplyResources(this.chMinValue, "chMinValue");
			//
			// chMaxValue
			//
			resources.ApplyResources(this.chMaxValue, "chMaxValue");
			//
			// btSetAll
			//
			resources.ApplyResources(this.btSetAll, "btSetAll");
			this.btSetAll.Name = "btSetAll";
			this.btSetAll.UseVisualStyleBackColor = true;
			this.btSetAll.Click += new EventHandler(this.btSetAll_Click);
			//
			// TrcnForm
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = AutoScaleMode.Dpi;
			this.Controls.Add(this.trcnPanel);
			this.FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			this.Name = "TrcnForm";
			this.WindowState = FormWindowState.Maximized;
			this.trcnPanel.ResumeLayout(false);
			this.trcnPanel.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.tlpUnused.ResumeLayout(false);
			this.tlpUnused.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion

		private void lvTrcnItem_Resize(object sender, EventArgs e)
		{
			int before = lvTrcnItem.Columns[0].Width + lvTrcnItem.Columns[1].Width;
			int after = 0;
			for (int i = 3; i < lvTrcnItem.Columns.Count; i++)
			{
				after += lvTrcnItem.Columns[i].Width;
			}

			lvTrcnItem.Columns[2].Width = lvTrcnItem.Width - (before + after + 36);
		}

		private void lvTrcnItem_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setIndex(
				(this.lvTrcnItem.SelectedIndices.Count > 0)
					? this.lvTrcnItem.SelectedIndices[0]
					: -1
			);
		}

		private void btnCommit_Click(object sender, EventArgs e)
		{
			this.Commit();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Cancel();
			this.tbLabel.SelectAll();
			this.tbLabel.Focus();
		}

		private void pjse_banner1_SiblingClick(object sender, EventArgs e)
		{
			Bcon bcon = (Bcon)wrapper.SiblingResource(Bcon.Bcontype);
			if (bcon == null)
			{
				return;
			}

			if (bcon.Package != wrapper.Package)
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
			RemoteControl.OpenPackedFile(bcon.FileDescriptor, bcon.Package);
		}

		private void btnStrPrev_Click(object sender, EventArgs e)
		{
			this.setIndex(index - 1);
		}

		private void btnStrNext_Click(object sender, EventArgs e)
		{
			this.setIndex(index + 1);
		}

		private void btnStrAdd_Click(object sender, EventArgs e)
		{
			this.TrcnItemAdd();
			this.tbLabel.SelectAll();
			this.tbLabel.Focus();
		}

		private void btnStrDelete_Click(object sender, EventArgs e)
		{
			this.TrcnItemDelete();
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
					lvTrcnItem.SelectedItems[0].SubItems[2].Text =
						currentItem.ConstName = ((TextBox)sender).Text;
					break;
			}
			internalchg = false;
		}

		private void cbUsed_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			currentItem.Used = (uint)(((CheckBox)sender).Checked ? 1 : 0);
			updateSelectedItem();
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

			internalchg = true;
			ushort val = Convert.ToUInt16(((TextBox)sender).Text, 16);
			switch (alHex16.IndexOf(sender))
			{
				case 0:
					currentItem.DefValue = val;
					updateSelectedItem();
					break;
				case 1:
					currentItem.MinValue = val;
					updateSelectedItem();
					break;
				case 2:
					currentItem.MaxValue = val;
					updateSelectedItem();
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
			ushort val = 0;
			switch (alHex16.IndexOf(sender))
			{
				case 0:
					val = currentItem.DefValue;
					break;
				case 1:
					val = currentItem.MinValue;
					break;
				case 2:
					val = currentItem.MaxValue;
					break;
			}

			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = "0x" + Helper.HexString(val);
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

			internalchg = true;
			uint val = Convert.ToUInt32(((TextBox)sender).Text, 16);
			switch (alHex32.IndexOf(sender))
			{
				case 0:
					wrapper.Version = val;
					break;
				case 1:
					currentItem.ConstId = val;
					updateSelectedItem();
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
				case 1:
					val = currentItem.ConstId;
					break;
			}

			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = "0x" + Helper.HexString(val);
			internalchg = origstate;
		}

		private void tbDesc_TextChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			if (wrapper.Version > 0x53)
			{
				currentItem.ConstDesc = this.tbDesc.Text;
			}
		}

		private void btSetAll_Click(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			internalchg = true;
			uint fid = 0;
			foreach (TrcnItem fing in wrapper)
			{
				fid++;
				fing.Used = 1;
				if (fing.MaxValue == 0)
				{
					fing.MaxValue = 100;
				}

				if (fing.ConstId == 0)
				{
					fing.ConstId = fid;
				}
			}
			internalchg = false;
			updateLists();
		}
	}
}
