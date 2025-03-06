// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using SimPe.Data;
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
			lvTrcnItem.Items.Clear();

			TextBox[] t = { tbFilename, tbLabel };
			alText = new ArrayList(t);

			TextBox[] w = { tbDefValue, tbMinValue, tbMaxValue };
			alHex16 = new ArrayList(w);

			TextBox[] dw = { tbFormat, tbID };
			alHex32 = new ArrayList(dw);

			pjse.FileTable.GFT.FiletableRefresh += new EventHandler(
				FiletableRefresh
			);
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				lvTrcnItem.Font = new Font(
					"Microsoft Sans Serif",
					11F
				);
				chUsed.Width = 48;
				chDefValue.Width = 72;
				chMinValue.Width = 72;
				chMaxValue.Width = 78;
				chLine.Width = 84;
			}
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
			if (setHandler && wrapper != null)
			{
				wrapper.WrapperChanged -= new EventHandler(WrapperChanged);
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
			trcnPanel.Controls.Add(pjse_banner1);
			trcnPanel.Controls.Add(lbFilename);
			tbFilename.ReadOnly = true;
			tbFilename.Text = wrapper.FileName;
			tbFormat.Text = Helper.HexString(wrapper.Version);
			trcnPanel.Controls.Add(tbFilename);
			trcnPanel.Controls.Add(lbFormat);
			trcnPanel.Controls.Add(tbFormat);

			Label lb = new Label
			{
				AutoSize = true,
				Location = new Point(0, tbFormat.Bottom + 6),
				Text = pjse.Localization.GetString("trcnTextOnly")
			};

			TextBox tb = new TextBox
			{
				Anchor =
				AnchorStyles.Top
				| AnchorStyles.Bottom
				| AnchorStyles.Left
				| AnchorStyles.Right,
				Multiline = true,
				Location = new Point(0, lb.Bottom + 6),
				ReadOnly = true,
				ScrollBars = ScrollBars.Both,
				Size = trcnPanel.Size
			};
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
			ListViewItem lv = lvTrcnItem.SelectedItems[0];
			if (lv == null)
			{
				return;
			}

			lv.SubItems[3].Text = "0x" + Helper.HexString(currentItem.ConstId);
			lv.SubItems[4].Text = "0x" + currentItem.Used.ToString("X");
			lv.SubItems[5].Text = wrapper.Version > 0x53 ? "0x" + Helper.HexString((byte)currentItem.DefValue) : "0x" + Helper.HexString(currentItem.DefValue);

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
			wrapper?.CleanUp();

			index = -1;
			bconres = (Bcon)(
				wrapper?.SiblingResource(FileTypes.BCON)
			);

			lvTrcnItem.Items.Clear();
			int nItems = wrapper == null ? 0 : wrapper.Count;
			for (int i = 0; i < nItems; i++)
			{
				lvTrcnItem.Items.Add(new ListViewItem(trcnItemToStringArray(i)));
			}
		}

		private void setIndex(int i)
		{
			internalchg = true;
			if (i >= 0)
			{
				lvTrcnItem.Items[i].Selected = true;
			}
			else if (index >= 0)
			{
				lvTrcnItem.Items[index].Selected = false;
			}

			internalchg = false;

			if (lvTrcnItem.SelectedItems.Count > 0)
			{
				if (lvTrcnItem.Focused)
				{
					lvTrcnItem.SelectedItems[0].Focused = true;
				}

				lvTrcnItem.SelectedItems[0].EnsureVisible();
			}
			else
			{
				internalchg = true;
				tbLabel.Text = "";
				tbID.Text = "";
				cbUsed.CheckState = CheckState.Indeterminate;
				tbDesc.Text = "";
				tbDefValue.Text = "";
				tbMinValue.Text = "";
				tbMaxValue.Text = "";
				btnCancel.Enabled = false;
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
				tbLabel.Text = s[2];
				tbID.Text = s[3];
				cbUsed.CheckState =
					currentItem.Used != 0
						? CheckState.Checked
						: CheckState.Unchecked;
				tbDesc.Text = currentItem.ConstDesc;
				tbDefValue.Text = s[5];
				tbMinValue.Text = s[6];
				tbMaxValue.Text = s[7];

				tbID.Enabled =
					tbLabel.Enabled =
					tbDefValue.Enabled =
					tbMinValue.Enabled =
					tbMaxValue.Enabled =
					btnStrDelete.Enabled =
						true;
				cbUsed.Enabled = wrapper.Version > 0x3e;
				tbDefValue.Enabled =
					tbID.Enabled =
					tbMinValue.Enabled =
					tbMaxValue.Enabled =
						wrapper.Version > 1;
			}
			else
			{
				origItem = null;

				tbID.Text =
					tbLabel.Text =
					tbDefValue.Text =
					tbMinValue.Text =
					tbMaxValue.Text =
						"";
				cbUsed.CheckState = CheckState.Indeterminate;

				tbID.Enabled =
					tbLabel.Enabled =
					cbUsed.Enabled =
					tbDefValue.Enabled =
					tbMinValue.Enabled =
					tbMaxValue.Enabled =
					btnStrDelete.Enabled =
						false;
			}
			btnStrPrev.Enabled = index > 0;
			btnStrNext.Enabled = index < lvTrcnItem.Items.Count - 1;
			internalchg = false;

			btnCancel.Enabled = false;
		}

		private void TrcnItemAdd()
		{
			bool savedstate = internalchg;
			internalchg = true;

			try
			{
				wrapper.Add(new TrcnItem(wrapper));
				lvTrcnItem.Items.Add(
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

			lvTrcnItem.SelectedItems[0].SubItems[2].Text = currentItem.ConstName =
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
				wrapper != null && wrapper.SiblingResource(FileTypes.BCON) != null;
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
				wrapper.SiblingResource(FileTypes.BCON) != null;

			internalchg = true;
			updateLists();
			internalchg = false;

			setIndex(lvTrcnItem.Items.Count > 0 ? 0 : -1);

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

			tbDesc.ReadOnly = wrapper.Version <= 0x53;
			btnCommit.Enabled = wrapper.Changed || wrapper.Version == 1;
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
				tbFormat.Text = "0x" + Helper.HexString(wrapper.Version);
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
			btnCommit = new Button();
			trcnPanel = new Panel();
			panel2 = new Panel();
			btnStrAdd = new Button();
			lbLabel = new Label();
			btnStrDelete = new Button();
			tbLabel = new TextBox();
			btnCancel = new Button();
			btnStrPrev = new Button();
			btnStrNext = new Button();
			tlpUnused = new TableLayoutPanel();
			label5 = new Label();
			lbID = new Label();
			tbID = new TextBox();
			lbDesc = new Label();
			tbDesc = new TextBox();
			lbDefValue = new Label();
			tbDefValue = new TextBox();
			panel1 = new Panel();
			lbMinValue = new Label();
			tbMinValue = new TextBox();
			lbMaxValue = new Label();
			tbMaxValue = new TextBox();
			cbUsed = new CheckBox();
			tbFormat = new TextBox();
			lbFormat = new Label();
			tbFilename = new TextBox();
			lbFilename = new Label();
			pjse_banner1 = new pjse.pjse_banner();
			lvTrcnItem = new ListView();
			chLine = new ColumnHeader();
			chValue = new ColumnHeader();
			chConstName = new ColumnHeader();
			chConstId = new ColumnHeader();
			chUsed = new ColumnHeader();
			chDefValue = new ColumnHeader();
			chMinValue = new ColumnHeader();
			chMaxValue = new ColumnHeader();
			btSetAll = new Button();
			trcnPanel.SuspendLayout();
			panel2.SuspendLayout();
			tlpUnused.SuspendLayout();
			SuspendLayout();
			//
			// btnCommit
			//
			resources.ApplyResources(btnCommit, "btnCommit");
			btnCommit.Name = "btnCommit";
			btnCommit.Click += new EventHandler(btnCommit_Click);
			//
			// trcnPanel
			//
			resources.ApplyResources(trcnPanel, "trcnPanel");
			trcnPanel.Controls.Add(btSetAll);
			trcnPanel.Controls.Add(panel2);
			trcnPanel.Controls.Add(tlpUnused);
			trcnPanel.Controls.Add(btnCommit);
			trcnPanel.Controls.Add(tbFormat);
			trcnPanel.Controls.Add(lbFormat);
			trcnPanel.Controls.Add(tbFilename);
			trcnPanel.Controls.Add(lbFilename);
			trcnPanel.Controls.Add(pjse_banner1);
			trcnPanel.Controls.Add(lvTrcnItem);
			trcnPanel.Name = "trcnPanel";
			//
			// panel2
			//
			resources.ApplyResources(panel2, "panel2");
			panel2.Controls.Add(btnStrAdd);
			panel2.Controls.Add(lbLabel);
			panel2.Controls.Add(btnStrDelete);
			panel2.Controls.Add(tbLabel);
			panel2.Controls.Add(btnCancel);
			panel2.Controls.Add(btnStrPrev);
			panel2.Controls.Add(btnStrNext);
			panel2.Name = "panel2";
			//
			// btnStrAdd
			//
			resources.ApplyResources(btnStrAdd, "btnStrAdd");
			btnStrAdd.Name = "btnStrAdd";
			btnStrAdd.Click += new EventHandler(btnStrAdd_Click);
			//
			// lbLabel
			//
			resources.ApplyResources(lbLabel, "lbLabel");
			lbLabel.Name = "lbLabel";
			//
			// btnStrDelete
			//
			resources.ApplyResources(btnStrDelete, "btnStrDelete");
			btnStrDelete.Name = "btnStrDelete";
			btnStrDelete.Click += new EventHandler(btnStrDelete_Click);
			//
			// tbLabel
			//
			resources.ApplyResources(tbLabel, "tbLabel");
			tbLabel.Name = "tbLabel";
			tbLabel.TextChanged += new EventHandler(
				tbText_TextChanged
			);
			tbLabel.Enter += new EventHandler(tbText_Enter);
			//
			// btnCancel
			//
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.Click += new EventHandler(btnCancel_Click);
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
			// tlpUnused
			//
			resources.ApplyResources(tlpUnused, "tlpUnused");
			tlpUnused.Controls.Add(label5, 0, 1);
			tlpUnused.Controls.Add(lbID, 0, 2);
			tlpUnused.Controls.Add(tbID, 1, 2);
			tlpUnused.Controls.Add(lbDesc, 0, 4);
			tlpUnused.Controls.Add(tbDesc, 1, 4);
			tlpUnused.Controls.Add(lbDefValue, 0, 5);
			tlpUnused.Controls.Add(tbDefValue, 1, 5);
			tlpUnused.Controls.Add(panel1, 0, 0);
			tlpUnused.Controls.Add(lbMinValue, 0, 6);
			tlpUnused.Controls.Add(tbMinValue, 1, 6);
			tlpUnused.Controls.Add(lbMaxValue, 0, 7);
			tlpUnused.Controls.Add(tbMaxValue, 1, 7);
			tlpUnused.Controls.Add(cbUsed, 0, 3);
			tlpUnused.Name = "tlpUnused";
			//
			// label5
			//
			resources.ApplyResources(label5, "label5");
			tlpUnused.SetColumnSpan(label5, 2);
			label5.Name = "label5";
			//
			// lbID
			//
			resources.ApplyResources(lbID, "lbID");
			lbID.Name = "lbID";
			//
			// tbID
			//
			resources.ApplyResources(tbID, "tbID");
			tbID.Name = "tbID";
			tbID.TextChanged += new EventHandler(hex32_TextChanged);
			tbID.Validated += new EventHandler(hex32_Validated);
			tbID.Enter += new EventHandler(tbText_Enter);
			tbID.Validating += new System.ComponentModel.CancelEventHandler(
				hex32_Validating
			);
			//
			// lbDesc
			//
			resources.ApplyResources(lbDesc, "lbDesc");
			lbDesc.Name = "lbDesc";
			//
			// tbDesc
			//
			resources.ApplyResources(tbDesc, "tbDesc");
			tbDesc.Name = "tbDesc";
			tbDesc.ReadOnly = true;
			tbDesc.TextChanged += new EventHandler(tbDesc_TextChanged);
			//
			// lbDefValue
			//
			resources.ApplyResources(lbDefValue, "lbDefValue");
			lbDefValue.Name = "lbDefValue";
			//
			// tbDefValue
			//
			resources.ApplyResources(tbDefValue, "tbDefValue");
			tbDefValue.Name = "tbDefValue";
			tbDefValue.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			tbDefValue.Validated += new EventHandler(hex16_Validated);
			tbDefValue.Enter += new EventHandler(tbText_Enter);
			tbDefValue.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			//
			// panel1
			//
			panel1.BorderStyle = BorderStyle.FixedSingle;
			tlpUnused.SetColumnSpan(panel1, 2);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			//
			// lbMinValue
			//
			resources.ApplyResources(lbMinValue, "lbMinValue");
			lbMinValue.Name = "lbMinValue";
			//
			// tbMinValue
			//
			resources.ApplyResources(tbMinValue, "tbMinValue");
			tbMinValue.Name = "tbMinValue";
			tbMinValue.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			tbMinValue.Validated += new EventHandler(hex16_Validated);
			tbMinValue.Enter += new EventHandler(tbText_Enter);
			tbMinValue.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			//
			// lbMaxValue
			//
			resources.ApplyResources(lbMaxValue, "lbMaxValue");
			lbMaxValue.Name = "lbMaxValue";
			//
			// tbMaxValue
			//
			resources.ApplyResources(tbMaxValue, "tbMaxValue");
			tbMaxValue.Name = "tbMaxValue";
			tbMaxValue.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			tbMaxValue.Validated += new EventHandler(hex16_Validated);
			tbMaxValue.Enter += new EventHandler(tbText_Enter);
			tbMaxValue.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			//
			// cbUsed
			//
			resources.ApplyResources(cbUsed, "cbUsed");
			tlpUnused.SetColumnSpan(cbUsed, 2);
			cbUsed.Name = "cbUsed";
			cbUsed.CheckedChanged += new EventHandler(
				cbUsed_CheckedChanged
			);
			//
			// tbFormat
			//
			resources.ApplyResources(tbFormat, "tbFormat");
			tbFormat.Name = "tbFormat";
			tbFormat.ReadOnly = true;
			tbFormat.TextChanged += new EventHandler(
				hex32_TextChanged
			);
			tbFormat.Validated += new EventHandler(hex32_Validated);
			tbFormat.Enter += new EventHandler(tbText_Enter);
			tbFormat.Validating += new System.ComponentModel.CancelEventHandler(
				hex32_Validating
			);
			//
			// lbFormat
			//
			resources.ApplyResources(lbFormat, "lbFormat");
			lbFormat.Name = "lbFormat";
			//
			// tbFilename
			//
			resources.ApplyResources(tbFilename, "tbFilename");
			tbFilename.Name = "tbFilename";
			tbFilename.TextChanged += new EventHandler(
				tbText_TextChanged
			);
			tbFilename.Enter += new EventHandler(tbText_Enter);
			//
			// lbFilename
			//
			resources.ApplyResources(lbFilename, "lbFilename");
			lbFilename.Name = "lbFilename";
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
			// lvTrcnItem
			//
			resources.ApplyResources(lvTrcnItem, "lvTrcnItem");
			lvTrcnItem.Columns.AddRange(
				new ColumnHeader[]
				{
					chLine,
					chValue,
					chConstName,
					chConstId,
					chUsed,
					chDefValue,
					chMinValue,
					chMaxValue,
				}
			);
			lvTrcnItem.FullRowSelect = true;
			lvTrcnItem.GridLines = true;
			lvTrcnItem.HeaderStyle =
				ColumnHeaderStyle
				.Nonclickable;
			lvTrcnItem.HideSelection = false;
			lvTrcnItem.Items.AddRange(
				new ListViewItem[]
				{

						(ListViewItem)
							resources.GetObject("lvTrcnItem.Items")

					,
				}
			);
			lvTrcnItem.MultiSelect = false;
			lvTrcnItem.Name = "lvTrcnItem";
			lvTrcnItem.UseCompatibleStateImageBehavior = false;
			lvTrcnItem.View = View.Details;
			lvTrcnItem.Resize += new EventHandler(lvTrcnItem_Resize);
			lvTrcnItem.SelectedIndexChanged += new EventHandler(
				lvTrcnItem_SelectedIndexChanged
			);
			//
			// chLine
			//
			resources.ApplyResources(chLine, "chLine");
			//
			// chValue
			//
			resources.ApplyResources(chValue, "chValue");
			//
			// chConstName
			//
			resources.ApplyResources(chConstName, "chConstName");
			//
			// chConstId
			//
			resources.ApplyResources(chConstId, "chConstId");
			//
			// chUsed
			//
			resources.ApplyResources(chUsed, "chUsed");
			//
			// chDefValue
			//
			resources.ApplyResources(chDefValue, "chDefValue");
			//
			// chMinValue
			//
			resources.ApplyResources(chMinValue, "chMinValue");
			//
			// chMaxValue
			//
			resources.ApplyResources(chMaxValue, "chMaxValue");
			//
			// btSetAll
			//
			resources.ApplyResources(btSetAll, "btSetAll");
			btSetAll.Name = "btSetAll";
			btSetAll.UseVisualStyleBackColor = true;
			btSetAll.Click += new EventHandler(btSetAll_Click);
			//
			// TrcnForm
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(trcnPanel);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "TrcnForm";
			WindowState = FormWindowState.Maximized;
			trcnPanel.ResumeLayout(false);
			trcnPanel.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			tlpUnused.ResumeLayout(false);
			tlpUnused.PerformLayout();
			ResumeLayout(false);
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
				(lvTrcnItem.SelectedIndices.Count > 0)
					? lvTrcnItem.SelectedIndices[0]
					: -1
			);
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
			Bcon bcon = (Bcon)wrapper.SiblingResource(FileTypes.BCON);
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
			setIndex(index - 1);
		}

		private void btnStrNext_Click(object sender, EventArgs e)
		{
			setIndex(index + 1);
		}

		private void btnStrAdd_Click(object sender, EventArgs e)
		{
			TrcnItemAdd();
			tbLabel.SelectAll();
			tbLabel.Focus();
		}

		private void btnStrDelete_Click(object sender, EventArgs e)
		{
			TrcnItemDelete();
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
				currentItem.ConstDesc = tbDesc.Text;
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
