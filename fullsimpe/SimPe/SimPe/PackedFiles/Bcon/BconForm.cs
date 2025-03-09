// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Trcn;

namespace SimPe.PackedFiles.Bcon
{
	/// <summary>
	/// Summary description for BconForm.
	/// </summary>
	public class BconForm : Form, IPackedFileUI
	{
		#region Form variables
		private TextBox tbFilename;
		private Panel bconPanel;
		private Button btnCommit;
		private ListView lvConstants;
		private Label label5;
		private Label label6;
		private TextBox tbValueHex;
		private TextBox tbValueDec;
		private ColumnHeader chID;
		private ColumnHeader chValue;
		private ColumnHeader chLabel;
		private Button btnStrDelete;
		private Button btnStrAdd;
		private Label lbFilename;
		private GroupBox gbValue;
		private CheckBox cbFlag;
		private Button btnStrPrev;
		private Button btnStrNext;
		private Button btnTRCNMaker;
		private Button btnCancel;
		private pjse.pjse_banner pjse_banner1;
		private Button btnUpdateBCON;
		private LinkLabel llIsOverride;
		private pjse.CompareButton cmpBCON;
		private Button btnClose;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public BconForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			pjse.FileTable.GFT.FiletableRefresh += new EventHandler(
				FiletableRefresh
			);
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
			trcnres = null;
		}

		#region Controller
		private Bcon wrapper = null;
		private Trcn.Trcn trcnres = null;
		private bool setHandler = false;
		private bool internalchg = false;

		private int index = -1;
		private short origItem = -1;
		private short currentItem = -1;

		private bool hex16_IsValid(object sender)
		{
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

		private bool dec16_IsValid(object sender)
		{
			try
			{
				Convert.ToInt16(((TextBox)sender).Text, 10);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		private void UpdateBconItem_Value(short val, bool doHex, bool doDec)
		{
			internalchg = true;
			wrapper[index] = currentItem = val;
			lvConstants.SelectedItems[0].SubItems[1].Text =
				"0x" + Helper.HexString(currentItem);
			if (doHex)
			{
				tbValueHex.Text = lvConstants.SelectedItems[0].SubItems[1].Text;
			}

			if (doDec)
			{
				tbValueDec.Text = currentItem.ToString();
			}

			internalchg = false;
		}

		private ListViewItem lvItem(int i)
		{
			string cID = "0x" + i.ToString("X") + " (" + i + ")";
			string cValue = "0x" + Helper.HexString(wrapper[i]);
			string cLabel =
				trcnres != null && !trcnres.TextOnly && i < trcnres.Count
					? trcnres[i].ConstName
					: "";
			string[] v = { cID, cValue, cLabel };
			return new ListViewItem(v);
		}

		private void updateLists()
		{
			index = -1;
			trcnres = (Trcn.Trcn)(
				wrapper?.SiblingResource(FileTypes.TRCN)
			);

			lvConstants.Items.Clear();
			int nItems = wrapper == null ? 0 : wrapper.Count;
			for (int i = 0; i < nItems; i++)
			{
				lvConstants.Items.Add(lvItem(i));
			}
		}

		private void setIndex(int i)
		{
			internalchg = true;
			if (i >= 0)
			{
				lvConstants.Items[i].Selected = true;
			}
			else if (index >= 0)
			{
				lvConstants.Items[index].Selected = false;
			}

			internalchg = false;

			if (lvConstants.SelectedItems.Count > 0)
			{
				if (lvConstants.Focused)
				{
					lvConstants.SelectedItems[0].Focused = true;
				}

				lvConstants.SelectedItems[0].EnsureVisible();
			}

			if (index == i)
			{
				return;
			}

			index = i;
			displayBconItem();
		}

		private void displayBconItem()
		{
			internalchg = true;
			if (index >= 0 && index < wrapper.Count)
			{
				origItem = currentItem = wrapper[index];

				tbValueHex.Text = "0x" + Helper.HexString(currentItem);
				tbValueDec.Text = currentItem.ToString();

				tbValueHex.Enabled = tbValueDec.Enabled = true;
			}
			else
			{
				origItem = currentItem = -1;
				tbValueHex.Text = tbValueDec.Text = "";
				tbValueHex.Enabled = tbValueDec.Enabled = false;
			}
			btnStrPrev.Enabled = index > 0;
			btnStrNext.Enabled = index < lvConstants.Items.Count - 1;
			internalchg = false;

			btnCancel.Enabled = false;
		}

		private bool isPopup => Tag != null && ((string)Tag).StartsWith("Popup");
		private bool isNoOverride => Tag != null && ((string)Tag).Contains(";noOverride");
		private string expName
		{
			get
			{
				if (Tag != null)
				{
					string s = (string)Tag;
					int i = s.IndexOf(";expName=+");
					if (i >= 0)
					{
						return s.Substring(i + 10).TrimEnd(new char[] { '+' });
					}
				}
				foreach (
					pjse.FileTable.Entry item in pjse.FileTable.GFT[
						wrapper.Package,
						wrapper.FileDescriptor
					]
				)
				{
					if (item.PFD == wrapper.FileDescriptor)
					{
						if (item.IsMaxis)
						{
							return pjse.Localization.GetString("expCurrent");
						}
						else
						{
							break;
						}
					}
				}

				return pjse.Localization.GetString("expCustom");
			}
		}

		private bool isOverride
		{
			get
			{
				llIsOverride.Tag = null;
				pjse.FileTable.Entry[] items = pjse.FileTable.GFT[
					wrapper.Package,
					wrapper.FileDescriptor
				];
				if (items.Length <= 1)
				{
					return false;
				}

				pjse.FileTable.Entry item = items[items.Length - 1]; // currentpkg, other, fixed, maxis
				if (item.PFD == wrapper.FileDescriptor)
				{
					return false;
				}

				if (
					!item.IsMaxis /*&& !item.IsFixed*/
				)
				{
					return false; // only supporting objects.package really
				}

				llIsOverride.Tag = item;
				return true;
			}
		}

		private void common_Popup(
			pjse.FileTable.Entry item,
			ExpansionItem exp,
			bool noOverride
		)
		{
			if (item == null)
			{
				return; // this should never happen
			}

			Bcon bcon = new Bcon().ProcessFile(item.PFD, item.Package);

			BconForm ui = (BconForm)bcon.UIHandler;
			string tag = "Popup"; // tells the SetReadOnly function it's in a popup - so everything locked down
			if (noOverride)
			{
				tag += ";noOverride"; //
			}

			if (exp != null)
			{
				tag += ";expName=+" + exp.NameShort + "+";
			}

			ui.Tag = tag;

			bcon.RefreshUI();
			ui.Show();
		}

		private string formTitle => pjse.Localization.GetString(
					"pjseWindowTitle",
					expName // EP Name or Custom
					,
					System.IO.Path.GetFileName(
						wrapper.Package.SaveFileName
					) // package Filename without path
					,
					wrapper
						.FileDescriptor
						.TypeInfo
						.ShortName // Type (short name)
					,
					"0x"
						+ Helper.HexString(
							wrapper.FileDescriptor.Group
						) // Group Number
					,
					"0x"
						+ Helper.HexString(
							(ushort)wrapper.FileDescriptor.Instance
						) // Instance Number
					,
					wrapper.FileName,
					pjse.Localization.GetString(
						isPopup ? "pjseWindowTitleView" : "pjseWindowTitleEdit"
					)
				);

		private void doUpdateBCON()
		{
			if (!isOverride)
			{
				return; // this should never happen
			}

			pjse.FileTable.Entry item = (pjse.FileTable.Entry)llIsOverride.Tag;
			Bcon bcon = new Bcon().ProcessFile(item.PFD, item.Package);
			internalchg = true;
			while (wrapper.Count < bcon.Count)
			{
				wrapper.Add(new BconItem(bcon[wrapper.Count]));
			}

			internalchg = false;
			updateLists();
		}

		private void BconItemAdd()
		{
			bool savedstate = internalchg;
			internalchg = true;

			try
			{
				wrapper.Add(0);
				lvConstants.Items.Add(lvItem(wrapper.Count - 1));
			}
			catch { }

			internalchg = savedstate;

			setIndex(lvConstants.Items.Count - 1);
		}

		private void BconItemDelete()
		{
			bool savedstate = internalchg;
			internalchg = true;

			int i = index;
			wrapper.RemoveAt(i);
			updateLists();

			internalchg = savedstate;

			setIndex(i >= lvConstants.Items.Count ? lvConstants.Items.Count - 1 : i);
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

			setIndex(i >= lvConstants.Items.Count ? lvConstants.Items.Count - 1 : i);
		}

		private void Cancel()
		{
			bool savedstate = internalchg;
			internalchg = true;

			UpdateBconItem_Value(origItem, true, true);

			internalchg = savedstate;

			displayBconItem();
		}

		private void TRCNMaker()
		{
			bconPanel.Cursor = Cursors.WaitCursor;
			Application.UseWaitCursor = true;
			try
			{
				int minArgc = 0;
				Trcn.Trcn trcn = (Trcn.Trcn)wrapper.SiblingResource(FileTypes.TRCN); // find Trcn for this Bcon

				wrapper.Package.BeginUpdate();

				if (trcn != null && trcn.TextOnly)
				{
					// if it exists but is unreadable, as if user wants to overwrite
					DialogResult dr = MessageBox.Show(
						pjse.Localization.GetString("ml_overwriteduff"),
						btnTRCNMaker.Text,
						MessageBoxButtons.OKCancel,
						MessageBoxIcon.Warning
					);
					if (dr != DialogResult.OK)
					{
						return;
					}

					wrapper.Package.Remove(trcn.FileDescriptor);
					trcn = null;
				}
				if (trcn != null)
				{
					// if it exists ask if user wants to preserve content
					DialogResult dr = MessageBox.Show(
						pjse.Localization.GetString("ml_keeplabels"),
						btnTRCNMaker.Text,
						MessageBoxButtons.YesNoCancel,
						MessageBoxIcon.Warning
					);
					if (dr == DialogResult.Cancel)
					{
						return;
					}

					if (!trcn.Package.Equals(wrapper.Package))
					{
						// Clone the original into this package
						if (dr == DialogResult.Yes)
						{
							Wait.MaxProgress = trcn.Count;
						}

						Interfaces.Files.IPackedFileDescriptor npfd =
							trcn.FileDescriptor.Clone();
						Trcn.Trcn ntrcn = new Trcn.Trcn
						{
							FileDescriptor = npfd
						};
						wrapper.Package.Add(npfd, true);
						ntrcn.ProcessData(npfd, wrapper.Package);
						if (dr == DialogResult.Yes)
						{
							foreach (TrcnItem item in trcn)
							{
								ntrcn.Add(item);
								Wait.Progress++;
							}
						}

						trcn = ntrcn;
						trcn.SynchronizeUserData();
						Wait.MaxProgress = 0;
					}

					if (dr == DialogResult.Yes)
					{
						minArgc = trcn.Count;
					}
					else
					{
						trcn.Clear();
					}
				}
				else
				{
					// create a new Trcn file
					Interfaces.Files.IPackedFileDescriptor npfd =
						wrapper.FileDescriptor.Clone();
					trcn = new Trcn.Trcn();
					npfd.Type = FileTypes.TRCN;
					trcn.FileDescriptor = npfd;
					wrapper.Package.Add(npfd, true);
					trcn.SynchronizeUserData();
				}

				Wait.MaxProgress = wrapper.Count - minArgc;
				trcn.FileName = wrapper.FileName;

				for (int arg = minArgc; arg < wrapper.Count; arg++)
				{
					trcn.Add(new TrcnItem(trcn));
					trcn[arg].ConstId = (uint)arg;
					trcn[arg].ConstName = "Label " + arg.ToString();
					trcn[arg].DefValue = trcn[arg].MaxValue = trcn[arg].MinValue = 0;
					Wait.Progress++;
				}
				trcn.SynchronizeUserData();
				wrapper.Package.EndUpdate();
			}
			finally
			{
				Wait.SubStop();
				bconPanel.Cursor = Cursors.Default;
				Application.UseWaitCursor = false;
			}
			MessageBox.Show(
				pjse.Localization.GetString("ml_done"),
				btnTRCNMaker.Text,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}

		private void FiletableRefresh(object sender, EventArgs e)
		{
			pjse_banner1.SiblingEnabled =
				wrapper != null && wrapper.SiblingResource(FileTypes.TRCN) != null;
			updateLists();
		}
		#endregion

		#region IPackedFileUI Member
		/// <summary>
		/// Returns the Control that will be displayed within SimPe
		/// </summary>
		public Control GUIHandle => bconPanel;

		/// <summary>
		/// Called by the AbstractWrapper when the file should be displayed to the user.
		/// </summary>
		/// <param name="wrp">Reference to the wrapper to be displayed.</param>
		public void UpdateGUI(IFileWrapper wrp)
		{
			wrapper = (Bcon)wrp;
			WrapperChanged(wrapper, null);
			pjse_banner1.SiblingEnabled =
				wrapper.SiblingResource(FileTypes.TRCN) != null;

			internalchg = true;
			updateLists();
			internalchg = false;

			setIndex(lvConstants.Items.Count > 0 ? 0 : -1);

			//tbFilename.Enabled = cbFlag.Enabled = tbValueHex.Enabled = tbValueDec.Enabled = !isPopup;
			btnClose.Visible = isPopup;

			if (!setHandler)
			{
				wrapper.WrapperChanged += new EventHandler(WrapperChanged);
				setHandler = true;
			}
		}

		private void WrapperChanged(object sender, EventArgs e)
		{
			if (isPopup)
			{
				wrapper.Changed = false;
			}

			btnCommit.Enabled = wrapper.Changed;
			if (
				index >= 0
				&& sender is BconItem
				&& wrapper.IndexOf((BconItem)sender) == index
			)
			{
				btnCancel.Enabled = true;
				return;
			}

			if (internalchg)
			{
				return;
			}

			if (sender.Equals(wrapper))
			{
				internalchg = true;
				Text = formTitle;
				cbFlag.Checked = wrapper.Flag;
				llIsOverride.Visible = !isNoOverride && isOverride;
				tbFilename.Text = wrapper.FileName;
				cmpBCON.Wrapper = wrapper;
				cmpBCON.WrapperName = wrapper.FileName;
				internalchg = false;
			}
			else
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
				new System.ComponentModel.ComponentResourceManager(typeof(BconForm));
			lbFilename = new Label();
			tbFilename = new TextBox();
			tbValueDec = new TextBox();
			tbValueHex = new TextBox();
			label5 = new Label();
			gbValue = new GroupBox();
			btnCancel = new Button();
			label6 = new Label();
			bconPanel = new Panel();
			btnClose = new Button();
			cmpBCON = new pjse.CompareButton();
			llIsOverride = new LinkLabel();
			btnUpdateBCON = new Button();
			pjse_banner1 = new pjse.pjse_banner();
			btnStrPrev = new Button();
			btnStrNext = new Button();
			cbFlag = new CheckBox();
			btnStrDelete = new Button();
			btnStrAdd = new Button();
			lvConstants = new ListView();
			chID = new ColumnHeader();
			chValue = new ColumnHeader();
			chLabel = new ColumnHeader();
			btnCommit = new Button();
			btnTRCNMaker = new Button();
			gbValue.SuspendLayout();
			bconPanel.SuspendLayout();
			SuspendLayout();
			//
			// lbFilename
			//
			resources.ApplyResources(lbFilename, "lbFilename");
			lbFilename.Name = "lbFilename";
			//
			// tbFilename
			//
			resources.ApplyResources(tbFilename, "tbFilename");
			tbFilename.Name = "tbFilename";
			tbFilename.TextChanged += new EventHandler(
				tbFilename_TextChanged
			);
			tbFilename.Enter += new EventHandler(tbText_Enter);
			//
			// tbValueDec
			//
			resources.ApplyResources(tbValueDec, "tbValueDec");
			tbValueDec.Name = "tbValueDec";
			tbValueDec.TextChanged += new EventHandler(
				dec16_TextChanged
			);
			tbValueDec.Validated += new EventHandler(dec16_Validated);
			tbValueDec.Enter += new EventHandler(tbText_Enter);
			tbValueDec.Validating += new System.ComponentModel.CancelEventHandler(
				dec16_Validating
			);
			//
			// tbValueHex
			//
			resources.ApplyResources(tbValueHex, "tbValueHex");
			tbValueHex.Name = "tbValueHex";
			tbValueHex.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			tbValueHex.Validated += new EventHandler(hex16_Validated);
			tbValueHex.Enter += new EventHandler(tbText_Enter);
			tbValueHex.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			//
			// label5
			//
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			//
			// gbValue
			//
			gbValue.Controls.Add(btnCancel);
			gbValue.Controls.Add(tbValueDec);
			gbValue.Controls.Add(tbValueHex);
			gbValue.Controls.Add(label5);
			gbValue.Controls.Add(label6);
			gbValue.FlatStyle = FlatStyle.System;
			resources.ApplyResources(gbValue, "gbValue");
			gbValue.Name = "gbValue";
			gbValue.TabStop = false;
			//
			// btnCancel
			//
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.Click += new EventHandler(btnCancel_Click);
			//
			// label6
			//
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			//
			// bconPanel
			//
			resources.ApplyResources(bconPanel, "bconPanel");
			bconPanel.BackColor = System.Drawing.SystemColors.Control;
			bconPanel.Controls.Add(btnClose);
			bconPanel.Controls.Add(cmpBCON);
			bconPanel.Controls.Add(llIsOverride);
			bconPanel.Controls.Add(btnUpdateBCON);
			bconPanel.Controls.Add(pjse_banner1);
			bconPanel.Controls.Add(btnStrPrev);
			bconPanel.Controls.Add(btnStrNext);
			bconPanel.Controls.Add(cbFlag);
			bconPanel.Controls.Add(btnStrDelete);
			bconPanel.Controls.Add(btnStrAdd);
			bconPanel.Controls.Add(lvConstants);
			bconPanel.Controls.Add(btnCommit);
			bconPanel.Controls.Add(lbFilename);
			bconPanel.Controls.Add(tbFilename);
			bconPanel.Controls.Add(gbValue);
			bconPanel.Controls.Add(btnTRCNMaker);
			bconPanel.Name = "bconPanel";
			//
			// btnClose
			//
			resources.ApplyResources(btnClose, "btnClose");
			btnClose.DialogResult = DialogResult.Cancel;
			btnClose.Name = "btnClose";
			btnClose.Click += new EventHandler(btnClose_Click);
			//
			// cmpBCON
			//
			resources.ApplyResources(cmpBCON, "cmpBCON");
			cmpBCON.Name = "cmpBCON";
			cmpBCON.UseVisualStyleBackColor = true;
			cmpBCON.Wrapper = null;
			cmpBCON.WrapperName = null;
			cmpBCON.CompareWith += new pjse.CompareButton.CompareWithEventHandler(
				cmpBCON_CompareWith
			);
			//
			// llIsOverride
			//
			resources.ApplyResources(llIsOverride, "llIsOverride");
			llIsOverride.Name = "llIsOverride";
			llIsOverride.TabStop = true;
			llIsOverride.UseCompatibleTextRendering = true;
			llIsOverride.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llIsOverride_LinkClicked
				);
			//
			// btnUpdateBCON
			//
			resources.ApplyResources(btnUpdateBCON, "btnUpdateBCON");
			btnUpdateBCON.Name = "btnUpdateBCON";
			btnUpdateBCON.Click += new EventHandler(
				btnUpdateBCON_Click
			);
			//
			// pjse_banner1
			//
			resources.ApplyResources(pjse_banner1, "pjse_banner1");
			pjse_banner1.BackColor = System.Drawing.SystemColors.AppWorkspace;
			pjse_banner1.Name = "pjse_banner1";
			pjse_banner1.SiblingVisible = true;
			pjse_banner1.SiblingClick += new EventHandler(
				pjse_banner1_SiblingClick
			);
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
			// cbFlag
			//
			resources.ApplyResources(cbFlag, "cbFlag");
			cbFlag.Name = "cbFlag";
			cbFlag.CheckedChanged += new EventHandler(
				cbFlag_CheckedChanged
			);
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
			// lvConstants
			//
			resources.ApplyResources(lvConstants, "lvConstants");
			lvConstants.Columns.AddRange(
				new ColumnHeader[]
				{
					chID,
					chValue,
					chLabel,
				}
			);
			lvConstants.FullRowSelect = true;
			lvConstants.GridLines = true;
			lvConstants.HeaderStyle =
				ColumnHeaderStyle
				.Nonclickable;
			lvConstants.HideSelection = false;
			lvConstants.Items.AddRange(
				new ListViewItem[]
				{

						(ListViewItem)
							resources.GetObject("lvConstants.Items")

					,
				}
			);
			lvConstants.MultiSelect = false;
			lvConstants.Name = "lvConstants";
			lvConstants.UseCompatibleStateImageBehavior = false;
			lvConstants.View = View.Details;
			lvConstants.SelectedIndexChanged += new EventHandler(
				lvConstants_SelectedIndexChanged
			);
			//
			// chID
			//
			resources.ApplyResources(chID, "chID");
			//
			// chValue
			//
			resources.ApplyResources(chValue, "chValue");
			//
			// chLabel
			//
			resources.ApplyResources(chLabel, "chLabel");
			//
			// btnCommit
			//
			resources.ApplyResources(btnCommit, "btnCommit");
			btnCommit.Name = "btnCommit";
			btnCommit.Click += new EventHandler(btnCommit_Clicked);
			//
			// btnTRCNMaker
			//
			resources.ApplyResources(btnTRCNMaker, "btnTRCNMaker");
			btnTRCNMaker.Name = "btnTRCNMaker";
			btnTRCNMaker.Click += new EventHandler(btnTRCNMaker_Click);
			//
			// BconForm
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			CancelButton = btnClose;
			Controls.Add(bconPanel);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "BconForm";
			WindowState = FormWindowState.Maximized;
			gbValue.ResumeLayout(false);
			gbValue.PerformLayout();
			bconPanel.ResumeLayout(false);
			bconPanel.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private void lvConstants_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setIndex(
				lvConstants.SelectedIndices.Count > 0
					? lvConstants.SelectedIndices[0]
					: -1
			);
		}

		private void btnCommit_Clicked(object sender, EventArgs e)
		{
			Commit();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Cancel();
			tbValueHex.SelectAll();
			tbValueHex.Focus();
		}

		private void btnTRCNMaker_Click(object sender, EventArgs e)
		{
			TRCNMaker();
		}

		private void pjse_banner1_SiblingClick(object sender, EventArgs e)
		{
			Trcn.Trcn trcn = (Trcn.Trcn)wrapper.SiblingResource(FileTypes.TRCN);
			if (trcn == null)
			{
				return;
			}

			if (trcn.Package != wrapper.Package)
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
			RemoteControl.OpenPackedFile(trcn.FileDescriptor, trcn.Package);
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
			BconItemAdd();
			tbValueHex.SelectAll();
			tbValueHex.Focus();
		}

		private void btnStrDelete_Click(object sender, EventArgs e)
		{
			BconItemDelete();
		}

		private void cmpBCON_CompareWith(
			object sender,
			pjse.CompareButton.CompareWithEventArgs e
		)
		{
			common_Popup(e.Item, e.ExpansionItem, true);
		}

		private void llIsOverride_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			common_Popup((pjse.FileTable.Entry)((LinkLabel)sender).Tag, null, false);
		}

		private void btnUpdateBCON_Click(object sender, EventArgs e)
		{
			doUpdateBCON();
		}

		private void cbFlag_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			internalchg = true;
			wrapper.Flag = ((CheckBox)sender).Checked;
			internalchg = false;
		}

		private void tbText_Enter(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		private void tbFilename_TextChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			internalchg = true;
			wrapper.FileName = tbFilename.Text;
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

			UpdateBconItem_Value(
				Convert.ToInt16(((TextBox)sender).Text, 16),
				false,
				true
			);
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
			((TextBox)sender).Text = "0x" + Helper.HexString(currentItem);
			internalchg = origstate;
		}

		private void dec16_TextChanged(object sender, EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!dec16_IsValid(sender))
			{
				return;
			}

			UpdateBconItem_Value(
				Convert.ToInt16(((TextBox)sender).Text, 10),
				true,
				false
			);
		}

		private void dec16_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (dec16_IsValid(sender))
			{
				return;
			}

			e.Cancel = true;
			dec16_Validated(sender, null);
		}

		private void dec16_Validated(object sender, EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = currentItem.ToString();
			internalchg = origstate;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if (isPopup)
			{
				Close();
			}
		}
	}
}
