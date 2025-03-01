// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for ObjfForm.
	/// </summary>
	public class ObjfForm : Form, IPackedFileUI
	{
		#region Form variables

		private Label label19;
		private Panel objfPanel;
		private Label lbFilename;
		private TextBox tbFilename;
		private LinkLabel llGuardian;
		private LinkLabel llAction;
		private Button btnAction;
		private Button btnGuardian;
		private TextBox tbGuardian;
		private TextBox tbAction;
		private Button btnCommit;
		private Label lbAction;
		private Label lbGuardian;
		private ListView lvObjfItem;
		private ColumnHeader chFunction;
		private ColumnHeader chGuardian;
		private ColumnHeader chAction;
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
				components?.Dispose();
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
				|| funcDescs[index] == null
			)
			{
				return;
			}

			StrItem s = funcDescs[index].strItem;
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
			lvObjfItem.SelectedItems[0].SubItems[1 + which].Text = lbaAG[
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

			lvObjfItem.Items.Clear();
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
				lvObjfItem.Items.Add(
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
			ComponentResourceManager resources =
				new ComponentResourceManager(typeof(ObjfForm));
			objfPanel = new Panel();
			tableLayoutPanel1 = new TableLayoutPanel();
			llAction = new LinkLabel();
			llGuardian = new LinkLabel();
			flowLayoutPanel1 = new FlowLayoutPanel();
			tbAction = new TextBox();
			btnAction = new Button();
			flowLayoutPanel2 = new FlowLayoutPanel();
			tbGuardian = new TextBox();
			btnGuardian = new Button();
			lbAction = new Label();
			lbGuardian = new Label();
			pjse_banner1 = new pjse.pjse_banner();
			lbFunction = new Label();
			lvObjfItem = new ListView();
			chFunction = new ColumnHeader();
			chAction = new ColumnHeader();
			chGuardian = new ColumnHeader();
			btnCommit = new Button();
			lbFilename = new Label();
			tbFilename = new TextBox();
			label19 = new Label();
			objfPanel.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			flowLayoutPanel2.SuspendLayout();
			SuspendLayout();
			//
			// objfPanel
			//
			resources.ApplyResources(objfPanel, "objfPanel");
			objfPanel.BackColor = System.Drawing.SystemColors.Control;
			objfPanel.Controls.Add(tableLayoutPanel1);
			objfPanel.Controls.Add(pjse_banner1);
			objfPanel.Controls.Add(lbFunction);
			objfPanel.Controls.Add(lvObjfItem);
			objfPanel.Controls.Add(btnCommit);
			objfPanel.Controls.Add(lbFilename);
			objfPanel.Controls.Add(tbFilename);
			objfPanel.Controls.Add(label19);
			objfPanel.Name = "objfPanel";
			//
			// tableLayoutPanel1
			//
			resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
			tableLayoutPanel1.Controls.Add(llAction, 0, 0);
			tableLayoutPanel1.Controls.Add(llGuardian, 0, 3);
			tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 0);
			tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 1, 3);
			tableLayoutPanel1.Controls.Add(lbAction, 0, 1);
			tableLayoutPanel1.Controls.Add(lbGuardian, 0, 4);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
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
			// flowLayoutPanel1
			//
			resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
			flowLayoutPanel1.Controls.Add(tbAction);
			flowLayoutPanel1.Controls.Add(btnAction);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			//
			// tbAction
			//
			resources.ApplyResources(tbAction, "tbAction");
			tbAction.Name = "tbAction";
			tbAction.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			tbAction.Validated += new EventHandler(hex16_Validated);
			tbAction.Validating += new CancelEventHandler(
				hex16_Validating
			);
			//
			// btnAction
			//
			resources.ApplyResources(btnAction, "btnAction");
			btnAction.Name = "btnAction";
			btnAction.UseCompatibleTextRendering = true;
			btnAction.Click += new EventHandler(GetObjfAction);
			//
			// flowLayoutPanel2
			//
			resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
			flowLayoutPanel2.Controls.Add(tbGuardian);
			flowLayoutPanel2.Controls.Add(btnGuardian);
			flowLayoutPanel2.Name = "flowLayoutPanel2";
			//
			// tbGuardian
			//
			resources.ApplyResources(tbGuardian, "tbGuardian");
			tbGuardian.Name = "tbGuardian";
			tbGuardian.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			tbGuardian.Validated += new EventHandler(hex16_Validated);
			tbGuardian.Validating += new CancelEventHandler(
				hex16_Validating
			);
			//
			// btnGuardian
			//
			resources.ApplyResources(btnGuardian, "btnGuardian");
			btnGuardian.Name = "btnGuardian";
			btnGuardian.UseCompatibleTextRendering = true;
			btnGuardian.Click += new EventHandler(GetObjfGuard);
			//
			// lbAction
			//
			tableLayoutPanel1.SetColumnSpan(lbAction, 2);
			resources.ApplyResources(lbAction, "lbAction");
			lbAction.Name = "lbAction";
			lbAction.UseMnemonic = false;
			//
			// lbGuardian
			//
			tableLayoutPanel1.SetColumnSpan(lbGuardian, 2);
			resources.ApplyResources(lbGuardian, "lbGuardian");
			lbGuardian.Name = "lbGuardian";
			lbGuardian.UseMnemonic = false;
			//
			// pjse_banner1
			//
			resources.ApplyResources(pjse_banner1, "pjse_banner1");
			pjse_banner1.Name = "pjse_banner1";
			//
			// lbFunction
			//
			resources.ApplyResources(lbFunction, "lbFunction");
			lbFunction.AutoEllipsis = true;
			lbFunction.Name = "lbFunction";
			//
			// lvObjfItem
			//
			resources.ApplyResources(lvObjfItem, "lvObjfItem");
			lvObjfItem.Columns.AddRange(
				new ColumnHeader[]
				{
					chFunction,
					chAction,
					chGuardian,
				}
			);
			lvObjfItem.FullRowSelect = true;
			lvObjfItem.GridLines = true;
			lvObjfItem.HeaderStyle =
				ColumnHeaderStyle
				.Nonclickable;
			lvObjfItem.HideSelection = false;
			lvObjfItem.MultiSelect = false;
			lvObjfItem.Name = "lvObjfItem";
			lvObjfItem.UseCompatibleStateImageBehavior = false;
			lvObjfItem.View = View.Details;
			lvObjfItem.SelectedIndexChanged += new EventHandler(
				lvObjfItem_SelectedIndexChanged
			);
			//
			// chFunction
			//
			resources.ApplyResources(chFunction, "chFunction");
			//
			// chAction
			//
			resources.ApplyResources(chAction, "chAction");
			//
			// chGuardian
			//
			resources.ApplyResources(chGuardian, "chGuardian");
			//
			// btnCommit
			//
			resources.ApplyResources(btnCommit, "btnCommit");
			btnCommit.Name = "btnCommit";
			btnCommit.Click += new EventHandler(btnCommit_Click);
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
			tbFilename.Validated += new EventHandler(
				tbFilename_Validated
			);
			//
			// label19
			//
			resources.ApplyResources(label19, "label19");
			label19.Name = "label19";
			//
			// ObjfForm
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(objfPanel);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "ObjfForm";
			WindowState = FormWindowState.Maximized;
			objfPanel.ResumeLayout(false);
			objfPanel.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			flowLayoutPanel2.ResumeLayout(false);
			flowLayoutPanel2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private void lvObjfItem_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
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

		private void btnCommit_Click(object sender, EventArgs e)
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

		private void GetObjfAction(object sender, EventArgs e)
		{
			pjse.FileTable.Entry item = new pjse.ResourceChooser().Execute(
				Data.MetaData.BHAV_FILE,
				wrapper.FileDescriptor.Group,
				objfPanel.Parent,
				false
			);
			if (item != null)
			{
				setBHAV(0, (ushort)item.Instance, false);
			}
		}

		private void GetObjfGuard(object sender, EventArgs e)
		{
			pjse.FileTable.Entry item = new pjse.ResourceChooser().Execute(
				Data.MetaData.BHAV_FILE,
				wrapper.FileDescriptor.Group,
				objfPanel.Parent,
				false
			);
			if (item != null)
			{
				setBHAV(1, (ushort)item.Instance, false);
			}
		}

		private void tbFilename_TextChanged(object sender, EventArgs e)
		{
			wrapper.FileName = tbFilename.Text;
		}

		private void tbFilename_Validated(object sender, EventArgs e)
		{
			tbFilename.SelectAll();
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
			}
			internalchg = false;
		}

		private void hex16_Validating(
			object sender,
			CancelEventArgs e
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

		private void hex16_Validated(object sender, EventArgs e)
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
