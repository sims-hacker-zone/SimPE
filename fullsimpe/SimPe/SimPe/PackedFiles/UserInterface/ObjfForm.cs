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
	/// Summary description for ObjfForm.
	/// </summary>
	public class ObjfForm : System.Windows.Forms.Form, IPackedFileUI
	{
		#region Form variables

		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Panel objfPanel;
		private System.Windows.Forms.Label lbFilename;
		private System.Windows.Forms.TextBox tbFilename;
		private System.Windows.Forms.LinkLabel llGuardian;
		private System.Windows.Forms.LinkLabel llAction;
		private System.Windows.Forms.Button btnAction;
		private System.Windows.Forms.Button btnGuardian;
		private System.Windows.Forms.TextBox tbGuardian;
		private System.Windows.Forms.TextBox tbAction;
		private System.Windows.Forms.Button btnCommit;
		private System.Windows.Forms.Label lbAction;
		private System.Windows.Forms.Label lbGuardian;
		private System.Windows.Forms.ListView lvObjfItem;
		private System.Windows.Forms.ColumnHeader chFunction;
		private System.Windows.Forms.ColumnHeader chGuardian;
		private System.Windows.Forms.ColumnHeader chAction;
		private Label lbFunction;
		private pjse.pjse_banner pjse_banner1;
		private TableLayoutPanel tableLayoutPanel1;
		private FlowLayoutPanel flowLayoutPanel1;
		private FlowLayoutPanel flowLayoutPanel2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;
		#endregion

		public ObjfForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lbFunction.Text = "";

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			TextBox[] tbua = { tbAction, tbGuardian };
			alHex16 = new ArrayList(tbua);

			pjse.FileTable.GFT.FiletableRefresh += new EventHandler(
				GFT_FiletableRefresh
			);
		}

		void GFT_FiletableRefresh(object sender, EventArgs e)
		{
			if (wrapper.FileDescriptor == null)
			{
				return;
			}

			bool savedchg = internalchg;
			internalchg = true;

			bool parm = false;

			funcDescs = new pjse.Str(pjse.GS.BhavStr.OBJFDescs);
			if (wrapper.Count == 0)
			{
				int max = pjse.BhavWiz.readStr(pjse.GS.BhavStr.OBJFDescs).Count;
				for (int i = 0; i < max; i++)
				{
					wrapper.Add(new ObjfItem(wrapper));
				}

				lvObjfItem.Items[0].Selected = true;
			}
			for (ushort i = 0; i < lvObjfItem.Items.Count; i++)
			{
				lvObjfItem.Items[i].SubItems[0].Text = pjse.BhavWiz.readStr(
					pjse.GS.BhavStr.OBJFDescs,
					i
				);
				lvObjfItem.Items[i].SubItems[1].Text = pjse.BhavWiz.bhavName(
					wrapper,
					wrapper[i].Action,
					ref parm
				);
				lvObjfItem.Items[i].SubItems[2].Text = pjse.BhavWiz.bhavName(
					wrapper,
					wrapper[i].Guardian,
					ref parm
				);
			}

			if (lvObjfItem.SelectedIndices.Count > 0)
			{
				setLabel(lvObjfItem.SelectedIndices[0]);
			}

			if (currentItem != null)
			{
				setBHAV(0, currentItem.Action, false);
				setBHAV(1, currentItem.Guardian, false);
			}

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

		#region ObjfForm
		/// <summary>
		/// Stores the currently active Wrapper
		/// </summary>
		private Objf wrapper = null;
		private bool internalchg;
		private bool setHandler = false;
		private ArrayList alHex16;
		private ObjfItem origItem;
		private ObjfItem currentItem;

		private static pjse.Str funcDescs = new pjse.Str(pjse.GS.BhavStr.OBJFDescs);

		private void setLabel(int index)
		{
			lbFunction.Text = "";
			if (
				funcDescs == null
				|| index < 0
				|| ((pjse.FallbackStrItem)funcDescs[index]) == null
			)
			{
				return;
			}

			StrItem s = ((pjse.FallbackStrItem)funcDescs[index]).strItem;
			if (s != null)
			{
				lbFunction.Text = s.Description;
			}
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

		private void setBHAV(int which, ushort target, bool notxt)
		{
			TextBox[] tbaAG = { tbAction, tbGuardian };
			if (!notxt)
			{
				tbaAG[which].Text = "0x" + Helper.HexString(target);
			}

			Label[] lbaAG = { lbAction, lbGuardian };
			LinkLabel[] llaAG = { llAction, llGuardian };
			bool found = false;
			this.lvObjfItem.SelectedItems[0].SubItems[1 + which].Text = lbaAG[
				which
			].Text = pjse.BhavWiz.bhavName(wrapper, target, ref found);
			llaAG[which].Enabled = found;
		}

		#endregion

		#region IPackedFileUI Member
		/// <summary>
		/// Returns the Control that will be displayed within SimPe
		/// </summary>
		public Control GUIHandle => objfPanel;

		/// <summary>
		/// Called by the AbstractWrapper when the file should be displayed to the user.
		/// </summary>
		/// <param name="wrp">Reference to the wrapper to be displayed.</param>
		public void UpdateGUI(IFileWrapper wrp)
		{
			wrapper = (Objf)wrp;
			WrapperChanged(wrapper, null);

			internalchg = true;

			this.lvObjfItem.Items.Clear();
			bool parm = false;

			// There appears to be no clean way to handle a "new" resource being created in the wrapper
			// so this is in here.  Yuck.
			if (wrapper.Count == 0)
			{
				int max = pjse.BhavWiz.readStr(pjse.GS.BhavStr.OBJFDescs).Count;
				for (int i = 0; i < max; i++)
				{
					wrapper.Add(new ObjfItem(wrapper));
				}
			}
			for (ushort i = 0; i < wrapper.Count; i++)
			{
				this.lvObjfItem.Items.Add(
					new ListViewItem(
						new string[]
						{
							pjse.BhavWiz.readStr(pjse.GS.BhavStr.OBJFDescs, i),
							pjse.BhavWiz.bhavName(wrapper, wrapper[i].Action, ref parm),
							pjse.BhavWiz.bhavName(
								wrapper,
								wrapper[i].Guardian,
								ref parm
							),
						}
					)
				);
			}

			internalchg = false;

			lvObjfItem.Items[0].Selected = true;

			if (!setHandler)
			{
				wrapper.WrapperChanged += new System.EventHandler(this.WrapperChanged);
				setHandler = true;
			}
		}

		private void WrapperChanged(object sender, System.EventArgs e)
		{
			this.btnCommit.Enabled = wrapper.Changed;

			if (internalchg)
			{
				return;
			}

			internalchg = true;
			this.Text = tbFilename.Text = wrapper.FileName;
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
				new System.ComponentModel.ComponentResourceManager(typeof(ObjfForm));
			this.objfPanel = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.llAction = new System.Windows.Forms.LinkLabel();
			this.llGuardian = new System.Windows.Forms.LinkLabel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.tbAction = new System.Windows.Forms.TextBox();
			this.btnAction = new System.Windows.Forms.Button();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.tbGuardian = new System.Windows.Forms.TextBox();
			this.btnGuardian = new System.Windows.Forms.Button();
			this.lbAction = new System.Windows.Forms.Label();
			this.lbGuardian = new System.Windows.Forms.Label();
			this.pjse_banner1 = new pjse.pjse_banner();
			this.lbFunction = new System.Windows.Forms.Label();
			this.lvObjfItem = new System.Windows.Forms.ListView();
			this.chFunction = new System.Windows.Forms.ColumnHeader();
			this.chAction = new System.Windows.Forms.ColumnHeader();
			this.chGuardian = new System.Windows.Forms.ColumnHeader();
			this.btnCommit = new System.Windows.Forms.Button();
			this.lbFilename = new System.Windows.Forms.Label();
			this.tbFilename = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.objfPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			//
			// objfPanel
			//
			resources.ApplyResources(this.objfPanel, "objfPanel");
			this.objfPanel.BackColor = System.Drawing.SystemColors.Control;
			this.objfPanel.Controls.Add(this.tableLayoutPanel1);
			this.objfPanel.Controls.Add(this.pjse_banner1);
			this.objfPanel.Controls.Add(this.lbFunction);
			this.objfPanel.Controls.Add(this.lvObjfItem);
			this.objfPanel.Controls.Add(this.btnCommit);
			this.objfPanel.Controls.Add(this.lbFilename);
			this.objfPanel.Controls.Add(this.tbFilename);
			this.objfPanel.Controls.Add(this.label19);
			this.objfPanel.Name = "objfPanel";
			//
			// tableLayoutPanel1
			//
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.llAction, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.llGuardian, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.lbAction, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.lbGuardian, 0, 4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
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
			// flowLayoutPanel1
			//
			resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
			this.flowLayoutPanel1.Controls.Add(this.tbAction);
			this.flowLayoutPanel1.Controls.Add(this.btnAction);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
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
			this.btnAction.UseCompatibleTextRendering = true;
			this.btnAction.Click += new System.EventHandler(this.GetObjfAction);
			//
			// flowLayoutPanel2
			//
			resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
			this.flowLayoutPanel2.Controls.Add(this.tbGuardian);
			this.flowLayoutPanel2.Controls.Add(this.btnGuardian);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
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
			this.btnGuardian.UseCompatibleTextRendering = true;
			this.btnGuardian.Click += new System.EventHandler(this.GetObjfGuard);
			//
			// lbAction
			//
			this.tableLayoutPanel1.SetColumnSpan(this.lbAction, 2);
			resources.ApplyResources(this.lbAction, "lbAction");
			this.lbAction.Name = "lbAction";
			this.lbAction.UseMnemonic = false;
			//
			// lbGuardian
			//
			this.tableLayoutPanel1.SetColumnSpan(this.lbGuardian, 2);
			resources.ApplyResources(this.lbGuardian, "lbGuardian");
			this.lbGuardian.Name = "lbGuardian";
			this.lbGuardian.UseMnemonic = false;
			//
			// pjse_banner1
			//
			resources.ApplyResources(this.pjse_banner1, "pjse_banner1");
			this.pjse_banner1.Name = "pjse_banner1";
			//
			// lbFunction
			//
			resources.ApplyResources(this.lbFunction, "lbFunction");
			this.lbFunction.AutoEllipsis = true;
			this.lbFunction.Name = "lbFunction";
			//
			// lvObjfItem
			//
			resources.ApplyResources(this.lvObjfItem, "lvObjfItem");
			this.lvObjfItem.Columns.AddRange(
				new System.Windows.Forms.ColumnHeader[]
				{
					this.chFunction,
					this.chAction,
					this.chGuardian,
				}
			);
			this.lvObjfItem.FullRowSelect = true;
			this.lvObjfItem.GridLines = true;
			this.lvObjfItem.HeaderStyle = System
				.Windows
				.Forms
				.ColumnHeaderStyle
				.Nonclickable;
			this.lvObjfItem.HideSelection = false;
			this.lvObjfItem.MultiSelect = false;
			this.lvObjfItem.Name = "lvObjfItem";
			this.lvObjfItem.UseCompatibleStateImageBehavior = false;
			this.lvObjfItem.View = System.Windows.Forms.View.Details;
			this.lvObjfItem.SelectedIndexChanged += new System.EventHandler(
				this.lvObjfItem_SelectedIndexChanged
			);
			//
			// chFunction
			//
			resources.ApplyResources(this.chFunction, "chFunction");
			//
			// chAction
			//
			resources.ApplyResources(this.chAction, "chAction");
			//
			// chGuardian
			//
			resources.ApplyResources(this.chGuardian, "chGuardian");
			//
			// btnCommit
			//
			resources.ApplyResources(this.btnCommit, "btnCommit");
			this.btnCommit.Name = "btnCommit";
			this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
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
			this.tbFilename.Validated += new System.EventHandler(
				this.tbFilename_Validated
			);
			//
			// label19
			//
			resources.ApplyResources(this.label19, "label19");
			this.label19.Name = "label19";
			//
			// ObjfForm
			//
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.objfPanel);
			this.FormBorderStyle = System
				.Windows
				.Forms
				.FormBorderStyle
				.SizableToolWindow;
			this.Name = "ObjfForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.objfPanel.ResumeLayout(false);
			this.objfPanel.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion

		private void lvObjfItem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.internalchg)
			{
				return;
			}

			if (
				lvObjfItem.SelectedIndices.Count > 0
				&& lvObjfItem.SelectedIndices[0] >= 0
			)
			{
				currentItem = wrapper[lvObjfItem.SelectedIndices[0]];
				setLabel(lvObjfItem.SelectedIndices[0]);
				origItem = currentItem.Clone();

				internalchg = true;

				setBHAV(0, currentItem.Action, false);
				setBHAV(1, currentItem.Guardian, false);
				tbGuardian.Enabled = tbAction.Enabled = true;

				internalchg = false;
			}
			else
			{
				internalchg = true;

				tbGuardian.Text = tbAction.Text = lbGuardian.Text = lbAction.Text = "";
				tbGuardian.Enabled = tbAction.Enabled = false;

				internalchg = false;
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

		private void btnCommit_Click(object sender, System.EventArgs e)
		{
			try
			{
				wrapper.SynchronizeUserData();
				btnCommit.Enabled = wrapper.Changed;
				lvObjfItem_SelectedIndexChanged(null, null);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					pjse.Localization.GetString("errwritingfile"),
					ex
				);
			}
		}

		private void GetObjfAction(object sender, System.EventArgs e)
		{
			pjse.FileTable.Entry item = new pjse.ResourceChooser().Execute(
				SimPe.Data.MetaData.BHAV_FILE,
				wrapper.FileDescriptor.Group,
				objfPanel.Parent,
				false
			);
			if (item != null)
			{
				setBHAV(0, (ushort)item.Instance, false);
			}
		}

		private void GetObjfGuard(object sender, System.EventArgs e)
		{
			pjse.FileTable.Entry item = new pjse.ResourceChooser().Execute(
				SimPe.Data.MetaData.BHAV_FILE,
				wrapper.FileDescriptor.Group,
				objfPanel.Parent,
				false
			);
			if (item != null)
			{
				setBHAV(1, (ushort)item.Instance, false);
			}
		}

		private void tbFilename_TextChanged(object sender, System.EventArgs e)
		{
			wrapper.FileName = tbFilename.Text;
		}

		private void tbFilename_Validated(object sender, System.EventArgs e)
		{
			tbFilename.SelectAll();
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
	}
}
