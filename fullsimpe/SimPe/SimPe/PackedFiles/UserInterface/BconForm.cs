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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for BconForm.
	/// </summary>
	public class BconForm : System.Windows.Forms.Form, IPackedFileUI
	{
		#region Form variables
		private System.Windows.Forms.TextBox tbFilename;
		private System.Windows.Forms.Panel bconPanel;
		private System.Windows.Forms.Button btnCommit;
		private System.Windows.Forms.ListView lvConstants;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbValueHex;
		private System.Windows.Forms.TextBox tbValueDec;
		private System.Windows.Forms.ColumnHeader chID;
		private System.Windows.Forms.ColumnHeader chValue;
		private System.Windows.Forms.ColumnHeader chLabel;
		private System.Windows.Forms.Button btnStrDelete;
		private System.Windows.Forms.Button btnStrAdd;
		private System.Windows.Forms.Label lbFilename;
		private System.Windows.Forms.GroupBox gbValue;
		private System.Windows.Forms.CheckBox cbFlag;
		private System.Windows.Forms.Button btnStrPrev;
		private System.Windows.Forms.Button btnStrNext;
		private System.Windows.Forms.Button btnTRCNMaker;
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
			pjse.FileTable.GFT.FiletableRefresh += new System.EventHandler(
				this.FiletableRefresh
			);
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
				wrapper.WrapperChanged -= new System.EventHandler(this.WrapperChanged);
				setHandler = false;
			}
			wrapper = null;
			trcnres = null;
		}

		#region Controller
		private Bcon wrapper = null;
		private Trcn trcnres = null;
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
				"0x" + SimPe.Helper.HexString(currentItem);
			if (doHex)
				tbValueHex.Text = lvConstants.SelectedItems[0].SubItems[1].Text;
			if (doDec)
				tbValueDec.Text = currentItem.ToString();
			internalchg = false;
		}

		private ListViewItem lvItem(int i)
		{
			string cID = "0x" + i.ToString("X") + " (" + i + ")";
			string cValue = "0x" + SimPe.Helper.HexString(wrapper[i]);
			string cLabel =
				(trcnres != null && !trcnres.TextOnly && i < trcnres.Count)
					? trcnres[i].ConstName
					: "";
			string[] v = { cID, cValue, cLabel };
			return new ListViewItem(v);
		}

		private void updateLists()
		{
			index = -1;
			trcnres = (Trcn)(
				wrapper == null ? null : wrapper.SiblingResource(Trcn.Trcntype)
			);

			this.lvConstants.Items.Clear();
			int nItems = wrapper == null ? 0 : wrapper.Count;
			for (int i = 0; i < nItems; i++)
				this.lvConstants.Items.Add(lvItem(i));
		}

		private void setIndex(int i)
		{
			internalchg = true;
			if (i >= 0)
				this.lvConstants.Items[i].Selected = true;
			else if (index >= 0)
				this.lvConstants.Items[index].Selected = false;
			internalchg = false;

			if (this.lvConstants.SelectedItems.Count > 0)
			{
				if (this.lvConstants.Focused)
					this.lvConstants.SelectedItems[0].Focused = true;
				this.lvConstants.SelectedItems[0].EnsureVisible();
			}

			if (index == i)
				return;
			index = i;
			displayBconItem();
		}

		private void displayBconItem()
		{
			internalchg = true;
			if (index >= 0 && index < wrapper.Count)
			{
				origItem = currentItem = wrapper[index];

				this.tbValueHex.Text = "0x" + SimPe.Helper.HexString(currentItem);
				this.tbValueDec.Text = currentItem.ToString();

				this.tbValueHex.Enabled = this.tbValueDec.Enabled = true;
			}
			else
			{
				origItem = currentItem = -1;
				this.tbValueHex.Text = this.tbValueDec.Text = "";
				this.tbValueHex.Enabled = this.tbValueDec.Enabled = false;
			}
			this.btnStrPrev.Enabled = (index > 0);
			this.btnStrNext.Enabled = (index < this.lvConstants.Items.Count - 1);
			internalchg = false;

			this.btnCancel.Enabled = false;
		}

		private bool isPopup => this.Tag == null
					? false
					: ((string)(this.Tag)).StartsWith("Popup");
		private bool isNoOverride => this.Tag == null
					? false
					: ((string)(this.Tag)).Contains(";noOverride");
		private string expName
		{
			get
			{
				if (this.Tag != null)
				{
					string s = (string)this.Tag;
					int i = s.IndexOf(";expName=+");
					if (i >= 0)
						return s.Substring(i + 10).TrimEnd(new char[] { '+' });
				}
				foreach (
					pjse.FileTable.Entry item in pjse.FileTable.GFT[
						wrapper.Package,
						wrapper.FileDescriptor
					]
				)
					if (item.PFD == wrapper.FileDescriptor)
					{
						if (item.IsMaxis)
							return pjse.Localization.GetString("expCurrent");
						else
							break;
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
					return false;

				pjse.FileTable.Entry item = items[items.Length - 1]; // currentpkg, other, fixed, maxis
				if (item.PFD == wrapper.FileDescriptor)
					return false;
				if (
					!item.IsMaxis /*&& !item.IsFixed*/
				)
					return false; // only supporting objects.package really

				llIsOverride.Tag = item;
				return true;
			}
		}

		private void common_Popup(
			pjse.FileTable.Entry item,
			SimPe.ExpansionItem exp,
			bool noOverride
		)
		{
			if (item == null)
				return; // this should never happen
			Bcon bcon = new Bcon();
			bcon.ProcessData(item.PFD, item.Package);

			BconForm ui = (BconForm)bcon.UIHandler;
			string tag = "Popup"; // tells the SetReadOnly function it's in a popup - so everything locked down
			if (noOverride)
				tag += ";noOverride"; //
			if (exp != null)
				tag += ";expName=+" + exp.NameShort + "+";
			ui.Tag = tag;

			bcon.RefreshUI();
			ui.Show();
		}

		private String formTitle => pjse.Localization.GetString(
					"pjseWindowTitle",
					expName // EP Name or Custom
					,
					System.IO.Path.GetFileName(
						wrapper.Package.SaveFileName
					) // package Filename without path
					,
					wrapper
						.FileDescriptor
						.TypeName
						.shortname // Type (short name)
					,
					"0x"
						+ SimPe.Helper.HexString(
							wrapper.FileDescriptor.Group
						) // Group Number
					,
					"0x"
						+ SimPe.Helper.HexString(
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
				return; // this should never happen
			pjse.FileTable.Entry item = (pjse.FileTable.Entry)llIsOverride.Tag;
			Bcon bcon = new Bcon();
			bcon.ProcessData(item.PFD, item.Package);
			internalchg = true;
			while (wrapper.Count < bcon.Count)
				wrapper.Add(new BconItem(bcon[wrapper.Count]));
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
				this.lvConstants.Items.Add(lvItem(wrapper.Count - 1));
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

			setIndex((i >= lvConstants.Items.Count) ? lvConstants.Items.Count - 1 : i);
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

			setIndex((i >= lvConstants.Items.Count) ? lvConstants.Items.Count - 1 : i);
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
				Trcn trcn = (Trcn)wrapper.SiblingResource(Trcn.Trcntype); // find Trcn for this Bcon

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
						return;
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
						return;

					if (!trcn.Package.Equals(wrapper.Package))
					{
						// Clone the original into this package
						if (dr == DialogResult.Yes)
							Wait.MaxProgress = trcn.Count;
						SimPe.Interfaces.Files.IPackedFileDescriptor npfd =
							trcn.FileDescriptor.Clone();
						Trcn ntrcn = new Trcn();
						ntrcn.FileDescriptor = npfd;
						wrapper.Package.Add(npfd, true);
						ntrcn.ProcessData(npfd, wrapper.Package);
						if (dr == DialogResult.Yes)
							foreach (TrcnItem item in trcn)
							{
								ntrcn.Add(item);
								Wait.Progress++;
							}
						trcn = ntrcn;
						trcn.SynchronizeUserData();
						Wait.MaxProgress = 0;
					}

					if (dr == DialogResult.Yes)
						minArgc = trcn.Count;
					else
						trcn.Clear();
				}
				else
				{
					// create a new Trcn file
					SimPe.Interfaces.Files.IPackedFileDescriptor npfd =
						wrapper.FileDescriptor.Clone();
					trcn = new Trcn();
					npfd.Type = Trcn.Trcntype;
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

		private void FiletableRefresh(object sender, System.EventArgs e)
		{
			pjse_banner1.SiblingEnabled =
				wrapper != null && wrapper.SiblingResource(Trcn.Trcntype) != null;
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
				wrapper.SiblingResource(Trcn.Trcntype) != null;

			internalchg = true;
			updateLists();
			internalchg = false;

			setIndex(lvConstants.Items.Count > 0 ? 0 : -1);

			//tbFilename.Enabled = cbFlag.Enabled = tbValueHex.Enabled = tbValueDec.Enabled = !isPopup;
			btnClose.Visible = isPopup;

			if (!setHandler)
			{
				wrapper.WrapperChanged += new System.EventHandler(this.WrapperChanged);
				setHandler = true;
			}
		}

		private void WrapperChanged(object sender, System.EventArgs e)
		{
			if (isPopup)
				wrapper.Changed = false;

			this.btnCommit.Enabled = wrapper.Changed;
			if (
				index >= 0
				&& sender is BconItem
				&& wrapper.IndexOf((BconItem)sender) == index
			)
			{
				this.btnCancel.Enabled = true;
				return;
			}

			if (internalchg)
				return;

			if (sender.Equals(wrapper))
			{
				internalchg = true;
				this.Text = formTitle;
				this.cbFlag.Checked = wrapper.Flag;
				this.llIsOverride.Visible = !isNoOverride && isOverride;
				tbFilename.Text = wrapper.FileName;
				cmpBCON.Wrapper = wrapper;
				cmpBCON.WrapperName = wrapper.FileName;
				internalchg = false;
			}
			else
				updateLists();
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
			this.lbFilename = new System.Windows.Forms.Label();
			this.tbFilename = new System.Windows.Forms.TextBox();
			this.tbValueDec = new System.Windows.Forms.TextBox();
			this.tbValueHex = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.gbValue = new System.Windows.Forms.GroupBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.bconPanel = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.cmpBCON = new pjse.CompareButton();
			this.llIsOverride = new System.Windows.Forms.LinkLabel();
			this.btnUpdateBCON = new System.Windows.Forms.Button();
			this.pjse_banner1 = new pjse.pjse_banner();
			this.btnStrPrev = new System.Windows.Forms.Button();
			this.btnStrNext = new System.Windows.Forms.Button();
			this.cbFlag = new System.Windows.Forms.CheckBox();
			this.btnStrDelete = new System.Windows.Forms.Button();
			this.btnStrAdd = new System.Windows.Forms.Button();
			this.lvConstants = new System.Windows.Forms.ListView();
			this.chID = new System.Windows.Forms.ColumnHeader();
			this.chValue = new System.Windows.Forms.ColumnHeader();
			this.chLabel = new System.Windows.Forms.ColumnHeader();
			this.btnCommit = new System.Windows.Forms.Button();
			this.btnTRCNMaker = new System.Windows.Forms.Button();
			this.gbValue.SuspendLayout();
			this.bconPanel.SuspendLayout();
			this.SuspendLayout();
			//
			// lbFilename
			//
			resources.ApplyResources(this.lbFilename, "lbFilename");
			this.lbFilename.Name = "lbFilename";
			//
			// tbFilename
			//
			resources.ApplyResources(this.tbFilename, "tbFilename");
			this.tbFilename.Name = "tbFilename";
			this.tbFilename.TextChanged += new System.EventHandler(
				this.tbFilename_TextChanged
			);
			this.tbFilename.Enter += new System.EventHandler(this.tbText_Enter);
			//
			// tbValueDec
			//
			resources.ApplyResources(this.tbValueDec, "tbValueDec");
			this.tbValueDec.Name = "tbValueDec";
			this.tbValueDec.TextChanged += new System.EventHandler(
				this.dec16_TextChanged
			);
			this.tbValueDec.Validated += new System.EventHandler(this.dec16_Validated);
			this.tbValueDec.Enter += new System.EventHandler(this.tbText_Enter);
			this.tbValueDec.Validating += new System.ComponentModel.CancelEventHandler(
				this.dec16_Validating
			);
			//
			// tbValueHex
			//
			resources.ApplyResources(this.tbValueHex, "tbValueHex");
			this.tbValueHex.Name = "tbValueHex";
			this.tbValueHex.TextChanged += new System.EventHandler(
				this.hex16_TextChanged
			);
			this.tbValueHex.Validated += new System.EventHandler(this.hex16_Validated);
			this.tbValueHex.Enter += new System.EventHandler(this.tbText_Enter);
			this.tbValueHex.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			//
			// label5
			//
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			//
			// gbValue
			//
			this.gbValue.Controls.Add(this.btnCancel);
			this.gbValue.Controls.Add(this.tbValueDec);
			this.gbValue.Controls.Add(this.tbValueHex);
			this.gbValue.Controls.Add(this.label5);
			this.gbValue.Controls.Add(this.label6);
			this.gbValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
			resources.ApplyResources(this.gbValue, "gbValue");
			this.gbValue.Name = "gbValue";
			this.gbValue.TabStop = false;
			//
			// btnCancel
			//
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			//
			// label6
			//
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			//
			// bconPanel
			//
			resources.ApplyResources(this.bconPanel, "bconPanel");
			this.bconPanel.BackColor = System.Drawing.SystemColors.Control;
			this.bconPanel.Controls.Add(this.btnClose);
			this.bconPanel.Controls.Add(this.cmpBCON);
			this.bconPanel.Controls.Add(this.llIsOverride);
			this.bconPanel.Controls.Add(this.btnUpdateBCON);
			this.bconPanel.Controls.Add(this.pjse_banner1);
			this.bconPanel.Controls.Add(this.btnStrPrev);
			this.bconPanel.Controls.Add(this.btnStrNext);
			this.bconPanel.Controls.Add(this.cbFlag);
			this.bconPanel.Controls.Add(this.btnStrDelete);
			this.bconPanel.Controls.Add(this.btnStrAdd);
			this.bconPanel.Controls.Add(this.lvConstants);
			this.bconPanel.Controls.Add(this.btnCommit);
			this.bconPanel.Controls.Add(this.lbFilename);
			this.bconPanel.Controls.Add(this.tbFilename);
			this.bconPanel.Controls.Add(this.gbValue);
			this.bconPanel.Controls.Add(this.btnTRCNMaker);
			this.bconPanel.Name = "bconPanel";
			//
			// btnClose
			//
			resources.ApplyResources(this.btnClose, "btnClose");
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Name = "btnClose";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			//
			// cmpBCON
			//
			resources.ApplyResources(this.cmpBCON, "cmpBCON");
			this.cmpBCON.Name = "cmpBCON";
			this.cmpBCON.UseVisualStyleBackColor = true;
			this.cmpBCON.Wrapper = null;
			this.cmpBCON.WrapperName = null;
			this.cmpBCON.CompareWith += new pjse.CompareButton.CompareWithEventHandler(
				this.cmpBCON_CompareWith
			);
			//
			// llIsOverride
			//
			resources.ApplyResources(this.llIsOverride, "llIsOverride");
			this.llIsOverride.Name = "llIsOverride";
			this.llIsOverride.TabStop = true;
			this.llIsOverride.UseCompatibleTextRendering = true;
			this.llIsOverride.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.llIsOverride_LinkClicked
				);
			//
			// btnUpdateBCON
			//
			resources.ApplyResources(this.btnUpdateBCON, "btnUpdateBCON");
			this.btnUpdateBCON.Name = "btnUpdateBCON";
			this.btnUpdateBCON.Click += new System.EventHandler(
				this.btnUpdateBCON_Click
			);
			//
			// pjse_banner1
			//
			resources.ApplyResources(this.pjse_banner1, "pjse_banner1");
			this.pjse_banner1.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pjse_banner1.Name = "pjse_banner1";
			this.pjse_banner1.SiblingVisible = true;
			this.pjse_banner1.SiblingClick += new System.EventHandler(
				this.pjse_banner1_SiblingClick
			);
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
			// cbFlag
			//
			resources.ApplyResources(this.cbFlag, "cbFlag");
			this.cbFlag.Name = "cbFlag";
			this.cbFlag.CheckedChanged += new System.EventHandler(
				this.cbFlag_CheckedChanged
			);
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
			// lvConstants
			//
			resources.ApplyResources(this.lvConstants, "lvConstants");
			this.lvConstants.Columns.AddRange(
				new System.Windows.Forms.ColumnHeader[]
				{
					this.chID,
					this.chValue,
					this.chLabel,
				}
			);
			this.lvConstants.FullRowSelect = true;
			this.lvConstants.GridLines = true;
			this.lvConstants.HeaderStyle = System
				.Windows
				.Forms
				.ColumnHeaderStyle
				.Nonclickable;
			this.lvConstants.HideSelection = false;
			this.lvConstants.Items.AddRange(
				new System.Windows.Forms.ListViewItem[]
				{
					(
						(System.Windows.Forms.ListViewItem)(
							resources.GetObject("lvConstants.Items")
						)
					),
				}
			);
			this.lvConstants.MultiSelect = false;
			this.lvConstants.Name = "lvConstants";
			this.lvConstants.UseCompatibleStateImageBehavior = false;
			this.lvConstants.View = System.Windows.Forms.View.Details;
			this.lvConstants.SelectedIndexChanged += new System.EventHandler(
				this.lvConstants_SelectedIndexChanged
			);
			//
			// chID
			//
			resources.ApplyResources(this.chID, "chID");
			//
			// chValue
			//
			resources.ApplyResources(this.chValue, "chValue");
			//
			// chLabel
			//
			resources.ApplyResources(this.chLabel, "chLabel");
			//
			// btnCommit
			//
			resources.ApplyResources(this.btnCommit, "btnCommit");
			this.btnCommit.Name = "btnCommit";
			this.btnCommit.Click += new System.EventHandler(this.btnCommit_Clicked);
			//
			// btnTRCNMaker
			//
			resources.ApplyResources(this.btnTRCNMaker, "btnTRCNMaker");
			this.btnTRCNMaker.Name = "btnTRCNMaker";
			this.btnTRCNMaker.Click += new System.EventHandler(this.btnTRCNMaker_Click);
			//
			// BconForm
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.CancelButton = this.btnClose;
			this.Controls.Add(this.bconPanel);
			this.FormBorderStyle = System
				.Windows
				.Forms
				.FormBorderStyle
				.SizableToolWindow;
			this.Name = "BconForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.gbValue.ResumeLayout(false);
			this.gbValue.PerformLayout();
			this.bconPanel.ResumeLayout(false);
			this.bconPanel.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion

		private void lvConstants_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
				return;
			setIndex(
				(this.lvConstants.SelectedIndices.Count > 0)
					? this.lvConstants.SelectedIndices[0]
					: -1
			);
		}

		private void btnCommit_Clicked(object sender, System.EventArgs e)
		{
			this.Commit();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Cancel();
			this.tbValueHex.SelectAll();
			this.tbValueHex.Focus();
		}

		private void btnTRCNMaker_Click(object sender, System.EventArgs e)
		{
			this.TRCNMaker();
		}

		private void pjse_banner1_SiblingClick(object sender, EventArgs e)
		{
			Trcn trcn = (Trcn)wrapper.SiblingResource(Trcn.Trcntype);
			if (trcn == null)
				return;
			if (trcn.Package != wrapper.Package)
			{
				DialogResult dr = MessageBox.Show(
					Localization.GetString("OpenOtherPkg"),
					pjse_banner1.TitleText,
					MessageBoxButtons.YesNo
				);
				if (dr != DialogResult.Yes)
					return;
			}
			SimPe.RemoteControl.OpenPackedFile(trcn.FileDescriptor, trcn.Package);
		}

		private void btnStrPrev_Click(object sender, System.EventArgs e)
		{
			this.setIndex(index - 1);
		}

		private void btnStrNext_Click(object sender, System.EventArgs e)
		{
			this.setIndex(index + 1);
		}

		private void btnStrAdd_Click(object sender, System.EventArgs e)
		{
			this.BconItemAdd();
			this.tbValueHex.SelectAll();
			this.tbValueHex.Focus();
		}

		private void btnStrDelete_Click(object sender, System.EventArgs e)
		{
			this.BconItemDelete();
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

		private void cbFlag_CheckedChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
				return;
			internalchg = true;
			wrapper.Flag = ((CheckBox)sender).Checked;
			internalchg = false;
		}

		private void tbText_Enter(object sender, System.EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		private void tbFilename_TextChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
				return;

			internalchg = true;
			wrapper.FileName = tbFilename.Text;
			internalchg = false;
		}

		private void hex16_TextChanged(object sender, System.EventArgs ev)
		{
			if (internalchg)
				return;
			if (!hex16_IsValid(sender))
				return;
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
				return;
			e.Cancel = true;
			hex16_Validated(sender, null);
		}

		private void hex16_Validated(object sender, System.EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = "0x" + Helper.HexString(currentItem);
			internalchg = origstate;
		}

		private void dec16_TextChanged(object sender, System.EventArgs ev)
		{
			if (internalchg)
				return;
			if (!dec16_IsValid(sender))
				return;
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
				return;
			e.Cancel = true;
			dec16_Validated(sender, null);
		}

		private void dec16_Validated(object sender, System.EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = currentItem.ToString();
			internalchg = origstate;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if (this.isPopup)
				Close();
		}
	}
}
