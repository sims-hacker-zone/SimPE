// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace SimPe.Forms.PackedFileEditors.CustomControls
{
	/// <summary>
	/// Summary description for BhavInstListItemUI.
	/// </summary>
	public class BhavInstListItemUI : UserControl
	{
		#region Control variables
		private Label instrText;
		private LinkLabel trueTarget;
		private LinkLabel falseTarget;
		private TextBox bhavInstListItem;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public BhavInstListItemUI()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			Height = rowHeight;
			MakeUnselected();
			pjse.FileTable.GFT.FiletableRefresh += new EventHandler(FiletableRefresh);

			if (strTrue == null)
			{
				strTrue = trueTarget.Text;
			}

			if (strFalse == null)
			{
				strFalse = falseTarget.Text;
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

			pjse.FileTable.GFT.FiletableRefresh -= new EventHandler(FiletableRefresh);
			Index = -1;
			Wrapper = null;
		}

		#region BhavInstListItemUI
		public const int rowHeight = 32;
		public event EventHandler Selected;
		public event EventHandler Unselected;
		public event LinkLabelLinkClickedEventHandler TargetClick;
		public event EventHandler MoveUp;
		public event EventHandler MoveDown;

		protected virtual void OnSelected(EventArgs e)
		{
			if (Selected != null)
			{
				Selected(this, e);
			}
		}

		protected virtual void OnUnselected(EventArgs e)
		{
			if (Unselected != null)
			{
				Unselected(this, e);
			}
		}

		protected virtual void OnTargetClick(LinkLabelLinkClickedEventArgs e)
		{
			if (TargetClick != null)
			{
				TargetClick(this, e);
			}
		}

		protected virtual void OnMoveUp(EventArgs e)
		{
			if (MoveUp != null)
			{
				MoveUp(this, e);
			}
		}

		protected virtual void OnMoveDown(EventArgs e)
		{
			if (MoveDown != null)
			{
				MoveDown(this, e);
			}
		}

		private Bhav wrapper = null;
		private int index = -1;

		private static string strTrue = null;
		private static string strFalse = null;

		public Bhav Wrapper
		{
			set
			{
				if (wrapper != value)
				{
					if (wrapper != null)
					{
						wrapper.WrapperChanged -= new EventHandler(WrapperChanged);
					}

					wrapper = value;
					if (wrapper != null)
					{
						if (index != -1)
						{
							WrapperChanged(wrapper[index], null);
						}

						wrapper.WrapperChanged += new EventHandler(WrapperChanged);
					}
				}
			}
		}

		public int Index
		{
			set
			{
				if (index != value)
				{
					index = value;
					if (wrapper != null && index != -1)
					{
						WrapperChanged(wrapper[index], null);
					}
				}
			}
		}

		public void MakeSelected()
		{
			BackColor = bhavInstListItem.BackColor = System
				.Drawing
				.Color
				.LightGray; // .PowderBlue;
		}

		public void MakeUnselected()
		{
			BackColor = bhavInstListItem.BackColor = System
				.Drawing
				.Color
				.White;
		}

		private static string fmt = "0x{0} ({1}): {2}";

		private static string Content(int index, pjse.BhavWiz inst)
		{
			return Format(
				fmt,
				index.ToString("X"),
				index.ToString(),
				cleanup(inst.ShortName)
			);
		}

		private static string Format(string res, params string[] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				res = res.Replace("{" + i.ToString() + "}", args[i]);
			}

			return res;
		}

		private static string cleanup(string str)
		{
			for (char c = Convert.ToChar(1); c < ' '; c++)
			{
				str = str.Replace(c, ' ');
			}

			return str;
		}

		private void WrapperChanged(object sender, EventArgs e)
		{
			if (wrapper == null || index == -1)
			{
				return;
			}

			if (
				!(sender is Instruction)
				|| wrapper.IndexOf((Instruction)sender) != index
			)
			{
				return;
			}

			Instruction inst = (Instruction)sender;

			bhavInstListItem.Text = "";
			instrText.Text = Content(index, inst); //LongName;

			trueTarget.Text = strTrue + ": " + inst.Target1.ToString("X");
			trueTarget.LinkArea = new LinkArea(0, 0);
			if (inst.Target1 < wrapper.Count)
			{
				trueTarget.Links.Add(6, trueTarget.Text.Length - 6, inst.Target1);
			}

			falseTarget.Text = strFalse + ": " + inst.Target2.ToString("X");
			falseTarget.LinkArea = new LinkArea(0, 0);
			if (inst.Target2 < wrapper.Count)
			{
				falseTarget.Links.Add(7, falseTarget.Text.Length - 7, inst.Target2);
			}
		}

		private void FiletableRefresh(object sender, EventArgs e)
		{
			if (wrapper == null || index == -1)
			{
				return;
			}

			instrText.Text = Content(index, wrapper[index]); //LongName;
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(BhavInstListItemUI));
			instrText = new Label();
			trueTarget = new LinkLabel();
			falseTarget = new LinkLabel();
			bhavInstListItem = new TextBox();
			bhavInstListItem.SuspendLayout();
			SuspendLayout();
			//
			// instrText
			//
			instrText.AccessibleDescription = resources.GetString(
				"instrText.AccessibleDescription"
			);
			instrText.AccessibleName = resources.GetString(
				"instrText.AccessibleName"
			);
			instrText.Anchor =
				(AnchorStyles)
					resources.GetObject("instrText.Anchor")

			;
			instrText.AutoSize =
				(bool)resources.GetObject("instrText.AutoSize")
			;
			instrText.BorderStyle = BorderStyle.FixedSingle;
			instrText.Dock =
				(DockStyle)resources.GetObject("instrText.Dock")
			;
			instrText.Enabled = (bool)resources.GetObject("instrText.Enabled");
			instrText.Font =
				(System.Drawing.Font)resources.GetObject("instrText.Font")
			;
			instrText.Image =
				(System.Drawing.Image)resources.GetObject("instrText.Image")
			;
			instrText.ImageAlign =
				(System.Drawing.ContentAlignment)
					resources.GetObject("instrText.ImageAlign")

			;
			instrText.ImageIndex =
				(int)resources.GetObject("instrText.ImageIndex")
			;
			instrText.ImeMode =
				(ImeMode)resources.GetObject("instrText.ImeMode")
			;
			instrText.Location =
				(System.Drawing.Point)resources.GetObject("instrText.Location")
			;
			instrText.Name = "instrText";
			instrText.RightToLeft =
				(RightToLeft)
					resources.GetObject("instrText.RightToLeft")

			;
			instrText.Size =
				(System.Drawing.Size)resources.GetObject("instrText.Size")
			;
			instrText.TabIndex =
				(int)resources.GetObject("instrText.TabIndex")
			;
			instrText.Text = resources.GetString("instrText.Text");
			instrText.TextAlign =
				(System.Drawing.ContentAlignment)
					resources.GetObject("instrText.TextAlign")

			;
			instrText.UseMnemonic = false;
			instrText.Visible = (bool)resources.GetObject("instrText.Visible");
			instrText.Click += new EventHandler(Control_Click);
			//
			// trueTarget
			//
			trueTarget.AccessibleDescription = resources.GetString(
				"trueTarget.AccessibleDescription"
			);
			trueTarget.AccessibleName = resources.GetString(
				"trueTarget.AccessibleName"
			);
			trueTarget.Anchor =
				(AnchorStyles)
					resources.GetObject("trueTarget.Anchor")

			;
			trueTarget.AutoSize =
				(bool)resources.GetObject("trueTarget.AutoSize")
			;
			trueTarget.Dock =
				(DockStyle)resources.GetObject("trueTarget.Dock")
			;
			trueTarget.Enabled =
				(bool)resources.GetObject("trueTarget.Enabled")
			;
			trueTarget.Font =
				(System.Drawing.Font)resources.GetObject("trueTarget.Font")
			;
			trueTarget.Image =
				(System.Drawing.Image)resources.GetObject("trueTarget.Image")
			;
			trueTarget.ImageAlign =
				(System.Drawing.ContentAlignment)
					resources.GetObject("trueTarget.ImageAlign")

			;
			trueTarget.ImageIndex =
				(int)resources.GetObject("trueTarget.ImageIndex")
			;
			trueTarget.ImeMode =
				(ImeMode)
					resources.GetObject("trueTarget.ImeMode")

			;
			trueTarget.LinkArea =
				(LinkArea)
					resources.GetObject("trueTarget.LinkArea")

			;
			trueTarget.Location =
				(System.Drawing.Point)resources.GetObject("trueTarget.Location")
			;
			trueTarget.Name = "trueTarget";
			trueTarget.RightToLeft =
				(RightToLeft)
					resources.GetObject("trueTarget.RightToLeft")

			;
			trueTarget.Size =
				(System.Drawing.Size)resources.GetObject("trueTarget.Size")
			;
			trueTarget.TabIndex =
				(int)resources.GetObject("trueTarget.TabIndex")
			;
			trueTarget.Text = resources.GetString("trueTarget.Text");
			trueTarget.TextAlign =
				(System.Drawing.ContentAlignment)
					resources.GetObject("trueTarget.TextAlign")

			;
			trueTarget.Visible =
				(bool)resources.GetObject("trueTarget.Visible")
			;
			trueTarget.Click += new EventHandler(Control_Click);
			trueTarget.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					Target_LinkClicked
				);
			//
			// falseTarget
			//
			falseTarget.AccessibleDescription = resources.GetString(
				"falseTarget.AccessibleDescription"
			);
			falseTarget.AccessibleName = resources.GetString(
				"falseTarget.AccessibleName"
			);
			falseTarget.Anchor =
				(AnchorStyles)
					resources.GetObject("falseTarget.Anchor")

			;
			falseTarget.AutoSize =
				(bool)resources.GetObject("falseTarget.AutoSize")
			;
			falseTarget.Dock =
				(DockStyle)
					resources.GetObject("falseTarget.Dock")

			;
			falseTarget.Enabled =
				(bool)resources.GetObject("falseTarget.Enabled")
			;
			falseTarget.Font =
				(System.Drawing.Font)resources.GetObject("falseTarget.Font")
			;
			falseTarget.Image =
				(System.Drawing.Image)resources.GetObject("falseTarget.Image")
			;
			falseTarget.ImageAlign =
				(System.Drawing.ContentAlignment)
					resources.GetObject("falseTarget.ImageAlign")

			;
			falseTarget.ImageIndex =
				(int)resources.GetObject("falseTarget.ImageIndex")
			;
			falseTarget.ImeMode =
				(ImeMode)
					resources.GetObject("falseTarget.ImeMode")

			;
			falseTarget.LinkArea =
				(LinkArea)
					resources.GetObject("falseTarget.LinkArea")

			;
			falseTarget.Location =
				(System.Drawing.Point)resources.GetObject("falseTarget.Location")
			;
			falseTarget.Name = "falseTarget";
			falseTarget.RightToLeft =
				(RightToLeft)
					resources.GetObject("falseTarget.RightToLeft")

			;
			falseTarget.Size =
				(System.Drawing.Size)resources.GetObject("falseTarget.Size")
			;
			falseTarget.TabIndex =
				(int)resources.GetObject("falseTarget.TabIndex")
			;
			falseTarget.Text = resources.GetString("falseTarget.Text");
			falseTarget.TextAlign =
				(System.Drawing.ContentAlignment)
					resources.GetObject("falseTarget.TextAlign")

			;
			falseTarget.Visible =
				(bool)resources.GetObject("falseTarget.Visible")
			;
			falseTarget.Click += new EventHandler(Control_Click);
			falseTarget.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					Target_LinkClicked
				);
			//
			// bhavInstListItem
			//
			bhavInstListItem.AccessibleDescription = resources.GetString(
				"bhavInstListItem.AccessibleDescription"
			);
			bhavInstListItem.AccessibleName = resources.GetString(
				"bhavInstListItem.AccessibleName"
			);
			bhavInstListItem.Anchor =
				(AnchorStyles)
					resources.GetObject("bhavInstListItem.Anchor")

			;
			bhavInstListItem.AutoSize =
				(bool)resources.GetObject("bhavInstListItem.AutoSize")
			;
			bhavInstListItem.BackColor = System.Drawing.Color.White;
			bhavInstListItem.BackgroundImage =
				(System.Drawing.Image)
					resources.GetObject("bhavInstListItem.BackgroundImage")

			;
			bhavInstListItem.BorderStyle = BorderStyle.None;
			bhavInstListItem.Controls.Add(falseTarget);
			bhavInstListItem.Controls.Add(trueTarget);
			bhavInstListItem.Controls.Add(instrText);
			bhavInstListItem.Cursor = Cursors.Default;
			bhavInstListItem.Dock =
				(DockStyle)
					resources.GetObject("bhavInstListItem.Dock")

			;
			bhavInstListItem.Enabled =
				(bool)resources.GetObject("bhavInstListItem.Enabled")
			;
			bhavInstListItem.Font =
				(System.Drawing.Font)resources.GetObject("bhavInstListItem.Font")
			;
			bhavInstListItem.ImeMode =
				(ImeMode)
					resources.GetObject("bhavInstListItem.ImeMode")

			;
			bhavInstListItem.Location =
				(System.Drawing.Point)resources.GetObject("bhavInstListItem.Location")
			;
			bhavInstListItem.MaxLength =
				(int)resources.GetObject("bhavInstListItem.MaxLength")
			;
			bhavInstListItem.Multiline =
				(bool)resources.GetObject("bhavInstListItem.Multiline")
			;
			bhavInstListItem.Name = "bhavInstListItem";
			bhavInstListItem.PasswordChar =
				(char)resources.GetObject("bhavInstListItem.PasswordChar")
			;
			bhavInstListItem.RightToLeft =
				(RightToLeft)
					resources.GetObject("bhavInstListItem.RightToLeft")

			;
			bhavInstListItem.ScrollBars =
				(ScrollBars)
					resources.GetObject("bhavInstListItem.ScrollBars")

			;
			bhavInstListItem.Size =
				(System.Drawing.Size)resources.GetObject("bhavInstListItem.Size")
			;
			bhavInstListItem.TabIndex =
				(int)resources.GetObject("bhavInstListItem.TabIndex")
			;
			bhavInstListItem.Text = resources.GetString("bhavInstListItem.Text");
			bhavInstListItem.TextAlign =
				(HorizontalAlignment)
					resources.GetObject("bhavInstListItem.TextAlign")

			;
			bhavInstListItem.Visible =
				(bool)resources.GetObject("bhavInstListItem.Visible")
			;
			bhavInstListItem.WordWrap =
				(bool)resources.GetObject("bhavInstListItem.WordWrap")
			;
			bhavInstListItem.KeyDown += new KeyEventHandler(
				bhavInstListItem_KeyDown
			);
			//
			// BhavInstListItemUI
			//
			AccessibleDescription = resources.GetString(
				"$this.AccessibleDescription"
			);
			AccessibleName = resources.GetString("$this.AccessibleName");
			AutoScroll = (bool)resources.GetObject("$this.AutoScroll");
			AutoScrollMargin =
				(System.Drawing.Size)resources.GetObject("$this.AutoScrollMargin")
			;
			AutoScrollMinSize =
				(System.Drawing.Size)resources.GetObject("$this.AutoScrollMinSize")
			;
			BackColor = System.Drawing.SystemColors.Control;
			BackgroundImage =
				(System.Drawing.Image)resources.GetObject("$this.BackgroundImage")
			;
			Controls.Add(bhavInstListItem);
			Enabled = (bool)resources.GetObject("$this.Enabled");
			Font = (System.Drawing.Font)resources.GetObject("$this.Font");
			ImeMode =
				(ImeMode)resources.GetObject("$this.ImeMode")
			;
			Location =
				(System.Drawing.Point)resources.GetObject("$this.Location")
			;
			Name = "BhavInstListItemUI";
			RightToLeft =
				(RightToLeft)
					resources.GetObject("$this.RightToLeft")

			;
			Size = (System.Drawing.Size)resources.GetObject("$this.Size");
			Enter += new EventHandler(bhavInstListItemUI_Enter);
			Leave += new EventHandler(bhavInstListItemUI_Leave);
			bhavInstListItem.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		private void bhavInstListItemUI_Enter(object sender, EventArgs e)
		{
			//MakeSelected();
			BackColor = bhavInstListItem.BackColor = System
				.Drawing
				.Color
				.PowderBlue;
			OnSelected(e);
		}

		private void bhavInstListItemUI_Leave(object sender, EventArgs e)
		{
			BackColor = bhavInstListItem.BackColor = System
				.Drawing
				.Color
				.LightGray;
			OnUnselected(e);
		}

		private void bhavInstListItem_KeyDown(
			object sender,
			KeyEventArgs e
		)
		{
			OnKeyDown(e);
		}

		private void Control_Click(object sender, EventArgs e)
		{
			Focus();
		}

		private void Target_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			OnTargetClick(e);
		}

		private void moveUp_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			OnMoveUp(e);
		}

		private void moveDown_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			OnMoveDown(e);
		}
	}
}
