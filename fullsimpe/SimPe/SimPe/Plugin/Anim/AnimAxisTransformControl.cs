/***************************************************************************
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
using System.Windows.Forms;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// Summary description for AnimAxisTransformControl.
	/// </summary>
	public class AnimAxisTransformControl : UserControl
	{
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private CheckBox cbEvent;
		private TextBox tbTimeCode;
		private TextBox tbParameter;
		private TextBox tbU1;
		private TextBox tbU2;
		private TextBox tbU2Float;
		private TextBox tbU1Float;
		private TextBox tbParameterFloat;
		private TextBox tbU2Hex;
		private TextBox tbU1Hex;
		private TextBox tbParameterHex;
		private TextBox tbU2Bin;
		private TextBox tbU1Bin;
		private TextBox tbParameterBin;
		private LinkLabel llDelete;
		private LinkLabel llAdd;
		private CheckBox cbParentLock;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AnimAxisTransformControl()
		{
			SetStyle(
				ControlStyles.SupportsTransparentBackColor
					| ControlStyles.AllPaintingInWmPaint
					|
					//ControlStyles.Opaque |
					ControlStyles.UserPaint
					| ControlStyles.ResizeRedraw
					| ControlStyles.DoubleBuffer,
				true
			);

			// Required designer variable.
			InitializeComponent();

			CanCreate = false;
			Clear();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(AnimAxisTransformControl));
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			cbEvent = new CheckBox();
			tbTimeCode = new TextBox();
			tbParameter = new TextBox();
			tbU1 = new TextBox();
			tbU2 = new TextBox();
			tbU2Float = new TextBox();
			tbU1Float = new TextBox();
			tbParameterFloat = new TextBox();
			tbU2Hex = new TextBox();
			tbU1Hex = new TextBox();
			tbParameterHex = new TextBox();
			tbU2Bin = new TextBox();
			tbU1Bin = new TextBox();
			tbParameterBin = new TextBox();
			llDelete = new LinkLabel();
			llAdd = new LinkLabel();
			cbParentLock = new CheckBox();
			SuspendLayout();
			//
			// label1
			//
			label1.AccessibleDescription = resources.GetString(
				"label1.AccessibleDescription"
			);
			label1.AccessibleName = resources.GetString("label1.AccessibleName");
			label1.Anchor = (
				(AnchorStyles)(
					resources.GetObject("label1.Anchor")
				)
			);
			label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			label1.Dock = (
				(DockStyle)(resources.GetObject("label1.Dock"))
			);
			label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
			label1.Font = (
				(System.Drawing.Font)(resources.GetObject("label1.Font"))
			);
			label1.Image = (
				(System.Drawing.Image)(resources.GetObject("label1.Image"))
			);
			label1.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label1.ImageAlign")
				)
			);
			label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			label1.ImeMode = (
				(ImeMode)(resources.GetObject("label1.ImeMode"))
			);
			label1.Location = (
				(System.Drawing.Point)(resources.GetObject("label1.Location"))
			);
			label1.Name = "label1";
			label1.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("label1.RightToLeft")
				)
			);
			label1.Size = (
				(System.Drawing.Size)(resources.GetObject("label1.Size"))
			);
			label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			label1.Text = resources.GetString("label1.Text");
			label1.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label1.TextAlign")
				)
			);
			label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
			//
			// label2
			//
			label2.AccessibleDescription = resources.GetString(
				"label2.AccessibleDescription"
			);
			label2.AccessibleName = resources.GetString("label2.AccessibleName");
			label2.Anchor = (
				(AnchorStyles)(
					resources.GetObject("label2.Anchor")
				)
			);
			label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			label2.Dock = (
				(DockStyle)(resources.GetObject("label2.Dock"))
			);
			label2.Enabled = ((bool)(resources.GetObject("label2.Enabled")));
			label2.Font = (
				(System.Drawing.Font)(resources.GetObject("label2.Font"))
			);
			label2.Image = (
				(System.Drawing.Image)(resources.GetObject("label2.Image"))
			);
			label2.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label2.ImageAlign")
				)
			);
			label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			label2.ImeMode = (
				(ImeMode)(resources.GetObject("label2.ImeMode"))
			);
			label2.Location = (
				(System.Drawing.Point)(resources.GetObject("label2.Location"))
			);
			label2.Name = "label2";
			label2.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("label2.RightToLeft")
				)
			);
			label2.Size = (
				(System.Drawing.Size)(resources.GetObject("label2.Size"))
			);
			label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			label2.Text = resources.GetString("label2.Text");
			label2.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label2.TextAlign")
				)
			);
			label2.Visible = ((bool)(resources.GetObject("label2.Visible")));
			//
			// label3
			//
			label3.AccessibleDescription = resources.GetString(
				"label3.AccessibleDescription"
			);
			label3.AccessibleName = resources.GetString("label3.AccessibleName");
			label3.Anchor = (
				(AnchorStyles)(
					resources.GetObject("label3.Anchor")
				)
			);
			label3.AutoSize = ((bool)(resources.GetObject("label3.AutoSize")));
			label3.Dock = (
				(DockStyle)(resources.GetObject("label3.Dock"))
			);
			label3.Enabled = ((bool)(resources.GetObject("label3.Enabled")));
			label3.Font = (
				(System.Drawing.Font)(resources.GetObject("label3.Font"))
			);
			label3.Image = (
				(System.Drawing.Image)(resources.GetObject("label3.Image"))
			);
			label3.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label3.ImageAlign")
				)
			);
			label3.ImageIndex = ((int)(resources.GetObject("label3.ImageIndex")));
			label3.ImeMode = (
				(ImeMode)(resources.GetObject("label3.ImeMode"))
			);
			label3.Location = (
				(System.Drawing.Point)(resources.GetObject("label3.Location"))
			);
			label3.Name = "label3";
			label3.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("label3.RightToLeft")
				)
			);
			label3.Size = (
				(System.Drawing.Size)(resources.GetObject("label3.Size"))
			);
			label3.TabIndex = ((int)(resources.GetObject("label3.TabIndex")));
			label3.Text = resources.GetString("label3.Text");
			label3.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label3.TextAlign")
				)
			);
			label3.Visible = ((bool)(resources.GetObject("label3.Visible")));
			//
			// label4
			//
			label4.AccessibleDescription = resources.GetString(
				"label4.AccessibleDescription"
			);
			label4.AccessibleName = resources.GetString("label4.AccessibleName");
			label4.Anchor = (
				(AnchorStyles)(
					resources.GetObject("label4.Anchor")
				)
			);
			label4.AutoSize = ((bool)(resources.GetObject("label4.AutoSize")));
			label4.Dock = (
				(DockStyle)(resources.GetObject("label4.Dock"))
			);
			label4.Enabled = ((bool)(resources.GetObject("label4.Enabled")));
			label4.Font = (
				(System.Drawing.Font)(resources.GetObject("label4.Font"))
			);
			label4.Image = (
				(System.Drawing.Image)(resources.GetObject("label4.Image"))
			);
			label4.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label4.ImageAlign")
				)
			);
			label4.ImageIndex = ((int)(resources.GetObject("label4.ImageIndex")));
			label4.ImeMode = (
				(ImeMode)(resources.GetObject("label4.ImeMode"))
			);
			label4.Location = (
				(System.Drawing.Point)(resources.GetObject("label4.Location"))
			);
			label4.Name = "label4";
			label4.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("label4.RightToLeft")
				)
			);
			label4.Size = (
				(System.Drawing.Size)(resources.GetObject("label4.Size"))
			);
			label4.TabIndex = ((int)(resources.GetObject("label4.TabIndex")));
			label4.Text = resources.GetString("label4.Text");
			label4.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("label4.TextAlign")
				)
			);
			label4.Visible = ((bool)(resources.GetObject("label4.Visible")));
			//
			// cbEvent
			//
			cbEvent.AccessibleDescription = resources.GetString(
				"cbEvent.AccessibleDescription"
			);
			cbEvent.AccessibleName = resources.GetString("cbEvent.AccessibleName");
			cbEvent.Anchor = (
				(AnchorStyles)(
					resources.GetObject("cbEvent.Anchor")
				)
			);
			cbEvent.Appearance = (
				(Appearance)(
					resources.GetObject("cbEvent.Appearance")
				)
			);
			cbEvent.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("cbEvent.BackgroundImage"))
			);
			cbEvent.CheckAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("cbEvent.CheckAlign")
				)
			);
			cbEvent.Dock = (
				(DockStyle)(resources.GetObject("cbEvent.Dock"))
			);
			cbEvent.Enabled = ((bool)(resources.GetObject("cbEvent.Enabled")));
			cbEvent.FlatStyle = (
				(FlatStyle)(
					resources.GetObject("cbEvent.FlatStyle")
				)
			);
			cbEvent.Font = (
				(System.Drawing.Font)(resources.GetObject("cbEvent.Font"))
			);
			cbEvent.Image = (
				(System.Drawing.Image)(resources.GetObject("cbEvent.Image"))
			);
			cbEvent.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("cbEvent.ImageAlign")
				)
			);
			cbEvent.ImageIndex = (
				(int)(resources.GetObject("cbEvent.ImageIndex"))
			);
			cbEvent.ImeMode = (
				(ImeMode)(resources.GetObject("cbEvent.ImeMode"))
			);
			cbEvent.Location = (
				(System.Drawing.Point)(resources.GetObject("cbEvent.Location"))
			);
			cbEvent.Name = "cbEvent";
			cbEvent.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("cbEvent.RightToLeft")
				)
			);
			cbEvent.Size = (
				(System.Drawing.Size)(resources.GetObject("cbEvent.Size"))
			);
			cbEvent.TabIndex = ((int)(resources.GetObject("cbEvent.TabIndex")));
			cbEvent.Text = resources.GetString("cbEvent.Text");
			cbEvent.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("cbEvent.TextAlign")
				)
			);
			cbEvent.Visible = ((bool)(resources.GetObject("cbEvent.Visible")));
			cbEvent.CheckedChanged += new EventHandler(
				cbEvent_CheckedChanged
			);
			//
			// tbTimeCode
			//
			tbTimeCode.AccessibleDescription = resources.GetString(
				"tbTimeCode.AccessibleDescription"
			);
			tbTimeCode.AccessibleName = resources.GetString(
				"tbTimeCode.AccessibleName"
			);
			tbTimeCode.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbTimeCode.Anchor")
				)
			);
			tbTimeCode.AutoSize = (
				(bool)(resources.GetObject("tbTimeCode.AutoSize"))
			);
			tbTimeCode.BackgroundImage = (
				(System.Drawing.Image)(
					resources.GetObject("tbTimeCode.BackgroundImage")
				)
			);
			tbTimeCode.Dock = (
				(DockStyle)(resources.GetObject("tbTimeCode.Dock"))
			);
			tbTimeCode.Enabled = (
				(bool)(resources.GetObject("tbTimeCode.Enabled"))
			);
			tbTimeCode.Font = (
				(System.Drawing.Font)(resources.GetObject("tbTimeCode.Font"))
			);
			tbTimeCode.ImeMode = (
				(ImeMode)(
					resources.GetObject("tbTimeCode.ImeMode")
				)
			);
			tbTimeCode.Location = (
				(System.Drawing.Point)(resources.GetObject("tbTimeCode.Location"))
			);
			tbTimeCode.MaxLength = (
				(int)(resources.GetObject("tbTimeCode.MaxLength"))
			);
			tbTimeCode.Multiline = (
				(bool)(resources.GetObject("tbTimeCode.Multiline"))
			);
			tbTimeCode.Name = "tbTimeCode";
			tbTimeCode.PasswordChar = (
				(char)(resources.GetObject("tbTimeCode.PasswordChar"))
			);
			tbTimeCode.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbTimeCode.RightToLeft")
				)
			);
			tbTimeCode.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbTimeCode.ScrollBars")
				)
			);
			tbTimeCode.Size = (
				(System.Drawing.Size)(resources.GetObject("tbTimeCode.Size"))
			);
			tbTimeCode.TabIndex = (
				(int)(resources.GetObject("tbTimeCode.TabIndex"))
			);
			tbTimeCode.Text = resources.GetString("tbTimeCode.Text");
			tbTimeCode.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbTimeCode.TextAlign")
				)
			);
			tbTimeCode.Visible = (
				(bool)(resources.GetObject("tbTimeCode.Visible"))
			);
			tbTimeCode.WordWrap = (
				(bool)(resources.GetObject("tbTimeCode.WordWrap"))
			);
			tbTimeCode.TextChanged += new EventHandler(
				tbTimeCode_TextChanged
			);
			//
			// tbParameter
			//
			tbParameter.AccessibleDescription = resources.GetString(
				"tbParameter.AccessibleDescription"
			);
			tbParameter.AccessibleName = resources.GetString(
				"tbParameter.AccessibleName"
			);
			tbParameter.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbParameter.Anchor")
				)
			);
			tbParameter.AutoSize = (
				(bool)(resources.GetObject("tbParameter.AutoSize"))
			);
			tbParameter.BackgroundImage = (
				(System.Drawing.Image)(
					resources.GetObject("tbParameter.BackgroundImage")
				)
			);
			tbParameter.Dock = (
				(DockStyle)(
					resources.GetObject("tbParameter.Dock")
				)
			);
			tbParameter.Enabled = (
				(bool)(resources.GetObject("tbParameter.Enabled"))
			);
			tbParameter.Font = (
				(System.Drawing.Font)(resources.GetObject("tbParameter.Font"))
			);
			tbParameter.ImeMode = (
				(ImeMode)(
					resources.GetObject("tbParameter.ImeMode")
				)
			);
			tbParameter.Location = (
				(System.Drawing.Point)(resources.GetObject("tbParameter.Location"))
			);
			tbParameter.MaxLength = (
				(int)(resources.GetObject("tbParameter.MaxLength"))
			);
			tbParameter.Multiline = (
				(bool)(resources.GetObject("tbParameter.Multiline"))
			);
			tbParameter.Name = "tbParameter";
			tbParameter.PasswordChar = (
				(char)(resources.GetObject("tbParameter.PasswordChar"))
			);
			tbParameter.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbParameter.RightToLeft")
				)
			);
			tbParameter.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbParameter.ScrollBars")
				)
			);
			tbParameter.Size = (
				(System.Drawing.Size)(resources.GetObject("tbParameter.Size"))
			);
			tbParameter.TabIndex = (
				(int)(resources.GetObject("tbParameter.TabIndex"))
			);
			tbParameter.Text = resources.GetString("tbParameter.Text");
			tbParameter.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbParameter.TextAlign")
				)
			);
			tbParameter.Visible = (
				(bool)(resources.GetObject("tbParameter.Visible"))
			);
			tbParameter.WordWrap = (
				(bool)(resources.GetObject("tbParameter.WordWrap"))
			);
			tbParameter.TextChanged += new EventHandler(
				tbParameter_TextChanged
			);
			//
			// tbU1
			//
			tbU1.AccessibleDescription = resources.GetString(
				"tbU1.AccessibleDescription"
			);
			tbU1.AccessibleName = resources.GetString("tbU1.AccessibleName");
			tbU1.Anchor = (
				(AnchorStyles)(resources.GetObject("tbU1.Anchor"))
			);
			tbU1.AutoSize = ((bool)(resources.GetObject("tbU1.AutoSize")));
			tbU1.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("tbU1.BackgroundImage"))
			);
			tbU1.Dock = (
				(DockStyle)(resources.GetObject("tbU1.Dock"))
			);
			tbU1.Enabled = ((bool)(resources.GetObject("tbU1.Enabled")));
			tbU1.Font = ((System.Drawing.Font)(resources.GetObject("tbU1.Font")));
			tbU1.ImeMode = (
				(ImeMode)(resources.GetObject("tbU1.ImeMode"))
			);
			tbU1.Location = (
				(System.Drawing.Point)(resources.GetObject("tbU1.Location"))
			);
			tbU1.MaxLength = ((int)(resources.GetObject("tbU1.MaxLength")));
			tbU1.Multiline = ((bool)(resources.GetObject("tbU1.Multiline")));
			tbU1.Name = "tbU1";
			tbU1.PasswordChar = ((char)(resources.GetObject("tbU1.PasswordChar")));
			tbU1.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbU1.RightToLeft")
				)
			);
			tbU1.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbU1.ScrollBars")
				)
			);
			tbU1.Size = ((System.Drawing.Size)(resources.GetObject("tbU1.Size")));
			tbU1.TabIndex = ((int)(resources.GetObject("tbU1.TabIndex")));
			tbU1.Text = resources.GetString("tbU1.Text");
			tbU1.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbU1.TextAlign")
				)
			);
			tbU1.Visible = ((bool)(resources.GetObject("tbU1.Visible")));
			tbU1.WordWrap = ((bool)(resources.GetObject("tbU1.WordWrap")));
			tbU1.TextChanged += new EventHandler(tbU1_TextChanged);
			//
			// tbU2
			//
			tbU2.AccessibleDescription = resources.GetString(
				"tbU2.AccessibleDescription"
			);
			tbU2.AccessibleName = resources.GetString("tbU2.AccessibleName");
			tbU2.Anchor = (
				(AnchorStyles)(resources.GetObject("tbU2.Anchor"))
			);
			tbU2.AutoSize = ((bool)(resources.GetObject("tbU2.AutoSize")));
			tbU2.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("tbU2.BackgroundImage"))
			);
			tbU2.Dock = (
				(DockStyle)(resources.GetObject("tbU2.Dock"))
			);
			tbU2.Enabled = ((bool)(resources.GetObject("tbU2.Enabled")));
			tbU2.Font = ((System.Drawing.Font)(resources.GetObject("tbU2.Font")));
			tbU2.ImeMode = (
				(ImeMode)(resources.GetObject("tbU2.ImeMode"))
			);
			tbU2.Location = (
				(System.Drawing.Point)(resources.GetObject("tbU2.Location"))
			);
			tbU2.MaxLength = ((int)(resources.GetObject("tbU2.MaxLength")));
			tbU2.Multiline = ((bool)(resources.GetObject("tbU2.Multiline")));
			tbU2.Name = "tbU2";
			tbU2.PasswordChar = ((char)(resources.GetObject("tbU2.PasswordChar")));
			tbU2.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbU2.RightToLeft")
				)
			);
			tbU2.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbU2.ScrollBars")
				)
			);
			tbU2.Size = ((System.Drawing.Size)(resources.GetObject("tbU2.Size")));
			tbU2.TabIndex = ((int)(resources.GetObject("tbU2.TabIndex")));
			tbU2.Text = resources.GetString("tbU2.Text");
			tbU2.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbU2.TextAlign")
				)
			);
			tbU2.Visible = ((bool)(resources.GetObject("tbU2.Visible")));
			tbU2.WordWrap = ((bool)(resources.GetObject("tbU2.WordWrap")));
			tbU2.TextChanged += new EventHandler(tbU2_TextChanged);
			//
			// tbU2Float
			//
			tbU2Float.AccessibleDescription = resources.GetString(
				"tbU2Float.AccessibleDescription"
			);
			tbU2Float.AccessibleName = resources.GetString(
				"tbU2Float.AccessibleName"
			);
			tbU2Float.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbU2Float.Anchor")
				)
			);
			tbU2Float.AutoSize = (
				(bool)(resources.GetObject("tbU2Float.AutoSize"))
			);
			tbU2Float.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("tbU2Float.BackgroundImage"))
			);
			tbU2Float.Dock = (
				(DockStyle)(resources.GetObject("tbU2Float.Dock"))
			);
			tbU2Float.Enabled = ((bool)(resources.GetObject("tbU2Float.Enabled")));
			tbU2Float.Font = (
				(System.Drawing.Font)(resources.GetObject("tbU2Float.Font"))
			);
			tbU2Float.ImeMode = (
				(ImeMode)(resources.GetObject("tbU2Float.ImeMode"))
			);
			tbU2Float.Location = (
				(System.Drawing.Point)(resources.GetObject("tbU2Float.Location"))
			);
			tbU2Float.MaxLength = (
				(int)(resources.GetObject("tbU2Float.MaxLength"))
			);
			tbU2Float.Multiline = (
				(bool)(resources.GetObject("tbU2Float.Multiline"))
			);
			tbU2Float.Name = "tbU2Float";
			tbU2Float.PasswordChar = (
				(char)(resources.GetObject("tbU2Float.PasswordChar"))
			);
			tbU2Float.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbU2Float.RightToLeft")
				)
			);
			tbU2Float.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbU2Float.ScrollBars")
				)
			);
			tbU2Float.Size = (
				(System.Drawing.Size)(resources.GetObject("tbU2Float.Size"))
			);
			tbU2Float.TabIndex = (
				(int)(resources.GetObject("tbU2Float.TabIndex"))
			);
			tbU2Float.Text = resources.GetString("tbU2Float.Text");
			tbU2Float.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbU2Float.TextAlign")
				)
			);
			tbU2Float.Visible = ((bool)(resources.GetObject("tbU2Float.Visible")));
			tbU2Float.WordWrap = (
				(bool)(resources.GetObject("tbU2Float.WordWrap"))
			);
			tbU2Float.TextChanged += new EventHandler(
				tbU2Float_TextChanged
			);
			//
			// tbU1Float
			//
			tbU1Float.AccessibleDescription = resources.GetString(
				"tbU1Float.AccessibleDescription"
			);
			tbU1Float.AccessibleName = resources.GetString(
				"tbU1Float.AccessibleName"
			);
			tbU1Float.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbU1Float.Anchor")
				)
			);
			tbU1Float.AutoSize = (
				(bool)(resources.GetObject("tbU1Float.AutoSize"))
			);
			tbU1Float.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("tbU1Float.BackgroundImage"))
			);
			tbU1Float.Dock = (
				(DockStyle)(resources.GetObject("tbU1Float.Dock"))
			);
			tbU1Float.Enabled = ((bool)(resources.GetObject("tbU1Float.Enabled")));
			tbU1Float.Font = (
				(System.Drawing.Font)(resources.GetObject("tbU1Float.Font"))
			);
			tbU1Float.ImeMode = (
				(ImeMode)(resources.GetObject("tbU1Float.ImeMode"))
			);
			tbU1Float.Location = (
				(System.Drawing.Point)(resources.GetObject("tbU1Float.Location"))
			);
			tbU1Float.MaxLength = (
				(int)(resources.GetObject("tbU1Float.MaxLength"))
			);
			tbU1Float.Multiline = (
				(bool)(resources.GetObject("tbU1Float.Multiline"))
			);
			tbU1Float.Name = "tbU1Float";
			tbU1Float.PasswordChar = (
				(char)(resources.GetObject("tbU1Float.PasswordChar"))
			);
			tbU1Float.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbU1Float.RightToLeft")
				)
			);
			tbU1Float.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbU1Float.ScrollBars")
				)
			);
			tbU1Float.Size = (
				(System.Drawing.Size)(resources.GetObject("tbU1Float.Size"))
			);
			tbU1Float.TabIndex = (
				(int)(resources.GetObject("tbU1Float.TabIndex"))
			);
			tbU1Float.Text = resources.GetString("tbU1Float.Text");
			tbU1Float.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbU1Float.TextAlign")
				)
			);
			tbU1Float.Visible = ((bool)(resources.GetObject("tbU1Float.Visible")));
			tbU1Float.WordWrap = (
				(bool)(resources.GetObject("tbU1Float.WordWrap"))
			);
			tbU1Float.TextChanged += new EventHandler(
				tbU1Float_TextChanged
			);
			//
			// tbParameterFloat
			//
			tbParameterFloat.AccessibleDescription = resources.GetString(
				"tbParameterFloat.AccessibleDescription"
			);
			tbParameterFloat.AccessibleName = resources.GetString(
				"tbParameterFloat.AccessibleName"
			);
			tbParameterFloat.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbParameterFloat.Anchor")
				)
			);
			tbParameterFloat.AutoSize = (
				(bool)(resources.GetObject("tbParameterFloat.AutoSize"))
			);
			tbParameterFloat.BackgroundImage = (
				(System.Drawing.Image)(
					resources.GetObject("tbParameterFloat.BackgroundImage")
				)
			);
			tbParameterFloat.Dock = (
				(DockStyle)(
					resources.GetObject("tbParameterFloat.Dock")
				)
			);
			tbParameterFloat.Enabled = (
				(bool)(resources.GetObject("tbParameterFloat.Enabled"))
			);
			tbParameterFloat.Font = (
				(System.Drawing.Font)(resources.GetObject("tbParameterFloat.Font"))
			);
			tbParameterFloat.ImeMode = (
				(ImeMode)(
					resources.GetObject("tbParameterFloat.ImeMode")
				)
			);
			tbParameterFloat.Location = (
				(System.Drawing.Point)(resources.GetObject("tbParameterFloat.Location"))
			);
			tbParameterFloat.MaxLength = (
				(int)(resources.GetObject("tbParameterFloat.MaxLength"))
			);
			tbParameterFloat.Multiline = (
				(bool)(resources.GetObject("tbParameterFloat.Multiline"))
			);
			tbParameterFloat.Name = "tbParameterFloat";
			tbParameterFloat.PasswordChar = (
				(char)(resources.GetObject("tbParameterFloat.PasswordChar"))
			);
			tbParameterFloat.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbParameterFloat.RightToLeft")
				)
			);
			tbParameterFloat.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbParameterFloat.ScrollBars")
				)
			);
			tbParameterFloat.Size = (
				(System.Drawing.Size)(resources.GetObject("tbParameterFloat.Size"))
			);
			tbParameterFloat.TabIndex = (
				(int)(resources.GetObject("tbParameterFloat.TabIndex"))
			);
			tbParameterFloat.Text = resources.GetString("tbParameterFloat.Text");
			tbParameterFloat.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbParameterFloat.TextAlign")
				)
			);
			tbParameterFloat.Visible = (
				(bool)(resources.GetObject("tbParameterFloat.Visible"))
			);
			tbParameterFloat.WordWrap = (
				(bool)(resources.GetObject("tbParameterFloat.WordWrap"))
			);
			tbParameterFloat.TextChanged += new EventHandler(
				tbParameterFloat_TextChanged
			);
			//
			// tbU2Hex
			//
			tbU2Hex.AccessibleDescription = resources.GetString(
				"tbU2Hex.AccessibleDescription"
			);
			tbU2Hex.AccessibleName = resources.GetString("tbU2Hex.AccessibleName");
			tbU2Hex.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbU2Hex.Anchor")
				)
			);
			tbU2Hex.AutoSize = ((bool)(resources.GetObject("tbU2Hex.AutoSize")));
			tbU2Hex.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("tbU2Hex.BackgroundImage"))
			);
			tbU2Hex.Dock = (
				(DockStyle)(resources.GetObject("tbU2Hex.Dock"))
			);
			tbU2Hex.Enabled = ((bool)(resources.GetObject("tbU2Hex.Enabled")));
			tbU2Hex.Font = (
				(System.Drawing.Font)(resources.GetObject("tbU2Hex.Font"))
			);
			tbU2Hex.ImeMode = (
				(ImeMode)(resources.GetObject("tbU2Hex.ImeMode"))
			);
			tbU2Hex.Location = (
				(System.Drawing.Point)(resources.GetObject("tbU2Hex.Location"))
			);
			tbU2Hex.MaxLength = ((int)(resources.GetObject("tbU2Hex.MaxLength")));
			tbU2Hex.Multiline = ((bool)(resources.GetObject("tbU2Hex.Multiline")));
			tbU2Hex.Name = "tbU2Hex";
			tbU2Hex.PasswordChar = (
				(char)(resources.GetObject("tbU2Hex.PasswordChar"))
			);
			tbU2Hex.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbU2Hex.RightToLeft")
				)
			);
			tbU2Hex.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbU2Hex.ScrollBars")
				)
			);
			tbU2Hex.Size = (
				(System.Drawing.Size)(resources.GetObject("tbU2Hex.Size"))
			);
			tbU2Hex.TabIndex = ((int)(resources.GetObject("tbU2Hex.TabIndex")));
			tbU2Hex.Text = resources.GetString("tbU2Hex.Text");
			tbU2Hex.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbU2Hex.TextAlign")
				)
			);
			tbU2Hex.Visible = ((bool)(resources.GetObject("tbU2Hex.Visible")));
			tbU2Hex.WordWrap = ((bool)(resources.GetObject("tbU2Hex.WordWrap")));
			tbU2Hex.TextChanged += new EventHandler(
				tbU2Hex_TextChanged
			);
			//
			// tbU1Hex
			//
			tbU1Hex.AccessibleDescription = resources.GetString(
				"tbU1Hex.AccessibleDescription"
			);
			tbU1Hex.AccessibleName = resources.GetString("tbU1Hex.AccessibleName");
			tbU1Hex.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbU1Hex.Anchor")
				)
			);
			tbU1Hex.AutoSize = ((bool)(resources.GetObject("tbU1Hex.AutoSize")));
			tbU1Hex.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("tbU1Hex.BackgroundImage"))
			);
			tbU1Hex.Dock = (
				(DockStyle)(resources.GetObject("tbU1Hex.Dock"))
			);
			tbU1Hex.Enabled = ((bool)(resources.GetObject("tbU1Hex.Enabled")));
			tbU1Hex.Font = (
				(System.Drawing.Font)(resources.GetObject("tbU1Hex.Font"))
			);
			tbU1Hex.ImeMode = (
				(ImeMode)(resources.GetObject("tbU1Hex.ImeMode"))
			);
			tbU1Hex.Location = (
				(System.Drawing.Point)(resources.GetObject("tbU1Hex.Location"))
			);
			tbU1Hex.MaxLength = ((int)(resources.GetObject("tbU1Hex.MaxLength")));
			tbU1Hex.Multiline = ((bool)(resources.GetObject("tbU1Hex.Multiline")));
			tbU1Hex.Name = "tbU1Hex";
			tbU1Hex.PasswordChar = (
				(char)(resources.GetObject("tbU1Hex.PasswordChar"))
			);
			tbU1Hex.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbU1Hex.RightToLeft")
				)
			);
			tbU1Hex.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbU1Hex.ScrollBars")
				)
			);
			tbU1Hex.Size = (
				(System.Drawing.Size)(resources.GetObject("tbU1Hex.Size"))
			);
			tbU1Hex.TabIndex = ((int)(resources.GetObject("tbU1Hex.TabIndex")));
			tbU1Hex.Text = resources.GetString("tbU1Hex.Text");
			tbU1Hex.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbU1Hex.TextAlign")
				)
			);
			tbU1Hex.Visible = ((bool)(resources.GetObject("tbU1Hex.Visible")));
			tbU1Hex.WordWrap = ((bool)(resources.GetObject("tbU1Hex.WordWrap")));
			tbU1Hex.TextChanged += new EventHandler(
				tbU1Hex_TextChanged
			);
			//
			// tbParameterHex
			//
			tbParameterHex.AccessibleDescription = resources.GetString(
				"tbParameterHex.AccessibleDescription"
			);
			tbParameterHex.AccessibleName = resources.GetString(
				"tbParameterHex.AccessibleName"
			);
			tbParameterHex.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbParameterHex.Anchor")
				)
			);
			tbParameterHex.AutoSize = (
				(bool)(resources.GetObject("tbParameterHex.AutoSize"))
			);
			tbParameterHex.BackgroundImage = (
				(System.Drawing.Image)(
					resources.GetObject("tbParameterHex.BackgroundImage")
				)
			);
			tbParameterHex.Dock = (
				(DockStyle)(
					resources.GetObject("tbParameterHex.Dock")
				)
			);
			tbParameterHex.Enabled = (
				(bool)(resources.GetObject("tbParameterHex.Enabled"))
			);
			tbParameterHex.Font = (
				(System.Drawing.Font)(resources.GetObject("tbParameterHex.Font"))
			);
			tbParameterHex.ImeMode = (
				(ImeMode)(
					resources.GetObject("tbParameterHex.ImeMode")
				)
			);
			tbParameterHex.Location = (
				(System.Drawing.Point)(resources.GetObject("tbParameterHex.Location"))
			);
			tbParameterHex.MaxLength = (
				(int)(resources.GetObject("tbParameterHex.MaxLength"))
			);
			tbParameterHex.Multiline = (
				(bool)(resources.GetObject("tbParameterHex.Multiline"))
			);
			tbParameterHex.Name = "tbParameterHex";
			tbParameterHex.PasswordChar = (
				(char)(resources.GetObject("tbParameterHex.PasswordChar"))
			);
			tbParameterHex.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbParameterHex.RightToLeft")
				)
			);
			tbParameterHex.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbParameterHex.ScrollBars")
				)
			);
			tbParameterHex.Size = (
				(System.Drawing.Size)(resources.GetObject("tbParameterHex.Size"))
			);
			tbParameterHex.TabIndex = (
				(int)(resources.GetObject("tbParameterHex.TabIndex"))
			);
			tbParameterHex.Text = resources.GetString("tbParameterHex.Text");
			tbParameterHex.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbParameterHex.TextAlign")
				)
			);
			tbParameterHex.Visible = (
				(bool)(resources.GetObject("tbParameterHex.Visible"))
			);
			tbParameterHex.WordWrap = (
				(bool)(resources.GetObject("tbParameterHex.WordWrap"))
			);
			tbParameterHex.TextChanged += new EventHandler(
				tbParameterHex_TextChanged
			);
			//
			// tbU2Bin
			//
			tbU2Bin.AccessibleDescription = resources.GetString(
				"tbU2Bin.AccessibleDescription"
			);
			tbU2Bin.AccessibleName = resources.GetString("tbU2Bin.AccessibleName");
			tbU2Bin.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbU2Bin.Anchor")
				)
			);
			tbU2Bin.AutoSize = ((bool)(resources.GetObject("tbU2Bin.AutoSize")));
			tbU2Bin.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("tbU2Bin.BackgroundImage"))
			);
			tbU2Bin.Dock = (
				(DockStyle)(resources.GetObject("tbU2Bin.Dock"))
			);
			tbU2Bin.Enabled = ((bool)(resources.GetObject("tbU2Bin.Enabled")));
			tbU2Bin.Font = (
				(System.Drawing.Font)(resources.GetObject("tbU2Bin.Font"))
			);
			tbU2Bin.ImeMode = (
				(ImeMode)(resources.GetObject("tbU2Bin.ImeMode"))
			);
			tbU2Bin.Location = (
				(System.Drawing.Point)(resources.GetObject("tbU2Bin.Location"))
			);
			tbU2Bin.MaxLength = ((int)(resources.GetObject("tbU2Bin.MaxLength")));
			tbU2Bin.Multiline = ((bool)(resources.GetObject("tbU2Bin.Multiline")));
			tbU2Bin.Name = "tbU2Bin";
			tbU2Bin.PasswordChar = (
				(char)(resources.GetObject("tbU2Bin.PasswordChar"))
			);
			tbU2Bin.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbU2Bin.RightToLeft")
				)
			);
			tbU2Bin.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbU2Bin.ScrollBars")
				)
			);
			tbU2Bin.Size = (
				(System.Drawing.Size)(resources.GetObject("tbU2Bin.Size"))
			);
			tbU2Bin.TabIndex = ((int)(resources.GetObject("tbU2Bin.TabIndex")));
			tbU2Bin.Text = resources.GetString("tbU2Bin.Text");
			tbU2Bin.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbU2Bin.TextAlign")
				)
			);
			tbU2Bin.Visible = ((bool)(resources.GetObject("tbU2Bin.Visible")));
			tbU2Bin.WordWrap = ((bool)(resources.GetObject("tbU2Bin.WordWrap")));
			//
			// tbU1Bin
			//
			tbU1Bin.AccessibleDescription = resources.GetString(
				"tbU1Bin.AccessibleDescription"
			);
			tbU1Bin.AccessibleName = resources.GetString("tbU1Bin.AccessibleName");
			tbU1Bin.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbU1Bin.Anchor")
				)
			);
			tbU1Bin.AutoSize = ((bool)(resources.GetObject("tbU1Bin.AutoSize")));
			tbU1Bin.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("tbU1Bin.BackgroundImage"))
			);
			tbU1Bin.Dock = (
				(DockStyle)(resources.GetObject("tbU1Bin.Dock"))
			);
			tbU1Bin.Enabled = ((bool)(resources.GetObject("tbU1Bin.Enabled")));
			tbU1Bin.Font = (
				(System.Drawing.Font)(resources.GetObject("tbU1Bin.Font"))
			);
			tbU1Bin.ImeMode = (
				(ImeMode)(resources.GetObject("tbU1Bin.ImeMode"))
			);
			tbU1Bin.Location = (
				(System.Drawing.Point)(resources.GetObject("tbU1Bin.Location"))
			);
			tbU1Bin.MaxLength = ((int)(resources.GetObject("tbU1Bin.MaxLength")));
			tbU1Bin.Multiline = ((bool)(resources.GetObject("tbU1Bin.Multiline")));
			tbU1Bin.Name = "tbU1Bin";
			tbU1Bin.PasswordChar = (
				(char)(resources.GetObject("tbU1Bin.PasswordChar"))
			);
			tbU1Bin.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbU1Bin.RightToLeft")
				)
			);
			tbU1Bin.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbU1Bin.ScrollBars")
				)
			);
			tbU1Bin.Size = (
				(System.Drawing.Size)(resources.GetObject("tbU1Bin.Size"))
			);
			tbU1Bin.TabIndex = ((int)(resources.GetObject("tbU1Bin.TabIndex")));
			tbU1Bin.Text = resources.GetString("tbU1Bin.Text");
			tbU1Bin.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbU1Bin.TextAlign")
				)
			);
			tbU1Bin.Visible = ((bool)(resources.GetObject("tbU1Bin.Visible")));
			tbU1Bin.WordWrap = ((bool)(resources.GetObject("tbU1Bin.WordWrap")));
			//
			// tbParameterBin
			//
			tbParameterBin.AccessibleDescription = resources.GetString(
				"tbParameterBin.AccessibleDescription"
			);
			tbParameterBin.AccessibleName = resources.GetString(
				"tbParameterBin.AccessibleName"
			);
			tbParameterBin.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbParameterBin.Anchor")
				)
			);
			tbParameterBin.AutoSize = (
				(bool)(resources.GetObject("tbParameterBin.AutoSize"))
			);
			tbParameterBin.BackgroundImage = (
				(System.Drawing.Image)(
					resources.GetObject("tbParameterBin.BackgroundImage")
				)
			);
			tbParameterBin.Dock = (
				(DockStyle)(
					resources.GetObject("tbParameterBin.Dock")
				)
			);
			tbParameterBin.Enabled = (
				(bool)(resources.GetObject("tbParameterBin.Enabled"))
			);
			tbParameterBin.Font = (
				(System.Drawing.Font)(resources.GetObject("tbParameterBin.Font"))
			);
			tbParameterBin.ImeMode = (
				(ImeMode)(
					resources.GetObject("tbParameterBin.ImeMode")
				)
			);
			tbParameterBin.Location = (
				(System.Drawing.Point)(resources.GetObject("tbParameterBin.Location"))
			);
			tbParameterBin.MaxLength = (
				(int)(resources.GetObject("tbParameterBin.MaxLength"))
			);
			tbParameterBin.Multiline = (
				(bool)(resources.GetObject("tbParameterBin.Multiline"))
			);
			tbParameterBin.Name = "tbParameterBin";
			tbParameterBin.PasswordChar = (
				(char)(resources.GetObject("tbParameterBin.PasswordChar"))
			);
			tbParameterBin.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbParameterBin.RightToLeft")
				)
			);
			tbParameterBin.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbParameterBin.ScrollBars")
				)
			);
			tbParameterBin.Size = (
				(System.Drawing.Size)(resources.GetObject("tbParameterBin.Size"))
			);
			tbParameterBin.TabIndex = (
				(int)(resources.GetObject("tbParameterBin.TabIndex"))
			);
			tbParameterBin.Text = resources.GetString("tbParameterBin.Text");
			tbParameterBin.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbParameterBin.TextAlign")
				)
			);
			tbParameterBin.Visible = (
				(bool)(resources.GetObject("tbParameterBin.Visible"))
			);
			tbParameterBin.WordWrap = (
				(bool)(resources.GetObject("tbParameterBin.WordWrap"))
			);
			tbParameterBin.TextChanged += new EventHandler(
				tbParameterBin_TextChanged
			);
			//
			// llDelete
			//
			llDelete.AccessibleDescription = resources.GetString(
				"llDelete.AccessibleDescription"
			);
			llDelete.AccessibleName = resources.GetString(
				"llDelete.AccessibleName"
			);
			llDelete.Anchor = (
				(AnchorStyles)(
					resources.GetObject("llDelete.Anchor")
				)
			);
			llDelete.AutoSize = ((bool)(resources.GetObject("llDelete.AutoSize")));
			llDelete.Dock = (
				(DockStyle)(resources.GetObject("llDelete.Dock"))
			);
			llDelete.Enabled = ((bool)(resources.GetObject("llDelete.Enabled")));
			llDelete.Font = (
				(System.Drawing.Font)(resources.GetObject("llDelete.Font"))
			);
			llDelete.Image = (
				(System.Drawing.Image)(resources.GetObject("llDelete.Image"))
			);
			llDelete.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llDelete.ImageAlign")
				)
			);
			llDelete.ImageIndex = (
				(int)(resources.GetObject("llDelete.ImageIndex"))
			);
			llDelete.ImeMode = (
				(ImeMode)(resources.GetObject("llDelete.ImeMode"))
			);
			llDelete.LinkArea = (
				(LinkArea)(
					resources.GetObject("llDelete.LinkArea")
				)
			);
			llDelete.Location = (
				(System.Drawing.Point)(resources.GetObject("llDelete.Location"))
			);
			llDelete.Name = "llDelete";
			llDelete.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("llDelete.RightToLeft")
				)
			);
			llDelete.Size = (
				(System.Drawing.Size)(resources.GetObject("llDelete.Size"))
			);
			llDelete.TabIndex = ((int)(resources.GetObject("llDelete.TabIndex")));
			llDelete.TabStop = true;
			llDelete.Text = resources.GetString("llDelete.Text");
			llDelete.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llDelete.TextAlign")
				)
			);
			llDelete.Visible = ((bool)(resources.GetObject("llDelete.Visible")));
			llDelete.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llDelete_LinkClicked
				);
			//
			// llAdd
			//
			llAdd.AccessibleDescription = resources.GetString(
				"llAdd.AccessibleDescription"
			);
			llAdd.AccessibleName = resources.GetString("llAdd.AccessibleName");
			llAdd.Anchor = (
				(AnchorStyles)(resources.GetObject("llAdd.Anchor"))
			);
			llAdd.AutoSize = ((bool)(resources.GetObject("llAdd.AutoSize")));
			llAdd.Dock = (
				(DockStyle)(resources.GetObject("llAdd.Dock"))
			);
			llAdd.Enabled = ((bool)(resources.GetObject("llAdd.Enabled")));
			llAdd.Font = (
				(System.Drawing.Font)(resources.GetObject("llAdd.Font"))
			);
			llAdd.Image = (
				(System.Drawing.Image)(resources.GetObject("llAdd.Image"))
			);
			llAdd.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llAdd.ImageAlign")
				)
			);
			llAdd.ImageIndex = ((int)(resources.GetObject("llAdd.ImageIndex")));
			llAdd.ImeMode = (
				(ImeMode)(resources.GetObject("llAdd.ImeMode"))
			);
			llAdd.LinkArea = (
				(LinkArea)(resources.GetObject("llAdd.LinkArea"))
			);
			llAdd.Location = (
				(System.Drawing.Point)(resources.GetObject("llAdd.Location"))
			);
			llAdd.Name = "llAdd";
			llAdd.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("llAdd.RightToLeft")
				)
			);
			llAdd.Size = (
				(System.Drawing.Size)(resources.GetObject("llAdd.Size"))
			);
			llAdd.TabIndex = ((int)(resources.GetObject("llAdd.TabIndex")));
			llAdd.TabStop = true;
			llAdd.Text = resources.GetString("llAdd.Text");
			llAdd.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llAdd.TextAlign")
				)
			);
			llAdd.Visible = ((bool)(resources.GetObject("llAdd.Visible")));
			llAdd.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llAdd_LinkClicked
				);
			//
			// cbParentLock
			//
			cbParentLock.AccessibleDescription = resources.GetString(
				"cbParentLock.AccessibleDescription"
			);
			cbParentLock.AccessibleName = resources.GetString(
				"cbParentLock.AccessibleName"
			);
			cbParentLock.Anchor = (
				(AnchorStyles)(
					resources.GetObject("cbParentLock.Anchor")
				)
			);
			cbParentLock.Appearance = (
				(Appearance)(
					resources.GetObject("cbParentLock.Appearance")
				)
			);
			cbParentLock.BackgroundImage = (
				(System.Drawing.Image)(
					resources.GetObject("cbParentLock.BackgroundImage")
				)
			);
			cbParentLock.CheckAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("cbParentLock.CheckAlign")
				)
			);
			cbParentLock.Dock = (
				(DockStyle)(
					resources.GetObject("cbParentLock.Dock")
				)
			);
			cbParentLock.Enabled = (
				(bool)(resources.GetObject("cbParentLock.Enabled"))
			);
			cbParentLock.FlatStyle = (
				(FlatStyle)(
					resources.GetObject("cbParentLock.FlatStyle")
				)
			);
			cbParentLock.Font = (
				(System.Drawing.Font)(resources.GetObject("cbParentLock.Font"))
			);
			cbParentLock.Image = (
				(System.Drawing.Image)(resources.GetObject("cbParentLock.Image"))
			);
			cbParentLock.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("cbParentLock.ImageAlign")
				)
			);
			cbParentLock.ImageIndex = (
				(int)(resources.GetObject("cbParentLock.ImageIndex"))
			);
			cbParentLock.ImeMode = (
				(ImeMode)(
					resources.GetObject("cbParentLock.ImeMode")
				)
			);
			cbParentLock.Location = (
				(System.Drawing.Point)(resources.GetObject("cbParentLock.Location"))
			);
			cbParentLock.Name = "cbParentLock";
			cbParentLock.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("cbParentLock.RightToLeft")
				)
			);
			cbParentLock.Size = (
				(System.Drawing.Size)(resources.GetObject("cbParentLock.Size"))
			);
			cbParentLock.TabIndex = (
				(int)(resources.GetObject("cbParentLock.TabIndex"))
			);
			cbParentLock.Text = resources.GetString("cbParentLock.Text");
			cbParentLock.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("cbParentLock.TextAlign")
				)
			);
			cbParentLock.Visible = (
				(bool)(resources.GetObject("cbParentLock.Visible"))
			);
			cbParentLock.CheckedChanged += new EventHandler(
				cbParentLock_CheckedChanged
			);
			//
			// AnimAxisTransformControl
			//
			AccessibleDescription = resources.GetString(
				"$this.AccessibleDescription"
			);
			AccessibleName = resources.GetString("$this.AccessibleName");
			AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin"))
			);
			AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize"))
			);
			BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("$this.BackgroundImage"))
			);
			Controls.Add(cbParentLock);
			Controls.Add(llAdd);
			Controls.Add(llDelete);
			Controls.Add(tbU2Bin);
			Controls.Add(tbU1Bin);
			Controls.Add(tbParameterBin);
			Controls.Add(tbU2Hex);
			Controls.Add(tbU1Hex);
			Controls.Add(tbParameterHex);
			Controls.Add(tbU2Float);
			Controls.Add(tbU1Float);
			Controls.Add(tbParameterFloat);
			Controls.Add(tbU2);
			Controls.Add(tbU1);
			Controls.Add(tbParameter);
			Controls.Add(tbTimeCode);
			Controls.Add(cbEvent);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			ImeMode = (
				(ImeMode)(resources.GetObject("$this.ImeMode"))
			);
			Location = (
				(System.Drawing.Point)(resources.GetObject("$this.Location"))
			);
			Name = "AnimAxisTransformControl";
			RightToLeft = (
				(RightToLeft)(
					resources.GetObject("$this.RightToLeft")
				)
			);
			Size = ((System.Drawing.Size)(resources.GetObject("$this.Size")));
			ResumeLayout(false);
		}
		#endregion

		#region Public properties
		AnimationAxisTransform aat;
		public AnimationAxisTransform AxisTransform
		{
			get => aat;
			set
			{
				aat = value;
				if (aat != null)
				{
					if (aat.Parent == null)
					{
						aat = null;
					}
				}

				RefreshData();
			}
		}

		public bool CanCreate
		{
			get => llAdd.Visible;
			set => llAdd.Visible = value;
		}
		#endregion

		internal void Clear()
		{
			intern = true;
			refresh = true;
			cbParentLock.Checked = true;
			cbEvent.Checked = false;
			tbTimeCode.Text = "0";
			tbParameter.Text = "0";
			tbU1.Text = "0";
			tbU2.Text = "0";

			EnableTimeCode(false);
			EnableParameter(false);
			EnableU1(false);
			EnableU2(false);

			llAdd.Enabled = true;

			if (Cleared != null)
			{
				Cleared(this, new EventArgs());
			}

			intern = false;
			refresh = false;
		}

		protected void EnableTimeCode(bool enabled)
		{
			cbEvent.Enabled = enabled;
			tbTimeCode.Enabled = enabled;
		}

		protected void EnableParameter(bool enabled)
		{
			cbParentLock.Enabled = enabled;
			llDelete.Enabled = enabled;

			tbParameter.Enabled = enabled;
			tbParameterFloat.Enabled = enabled;
			tbParameterHex.Enabled = enabled;
			tbParameterBin.Enabled = enabled;
		}

		protected void EnableU1(bool enabled)
		{
			tbU1.Enabled = enabled;
			tbU1Float.Enabled = enabled;
			tbU1Hex.Enabled = enabled;
			tbU1Bin.Enabled = enabled;
		}

		protected void EnableU2(bool enabled)
		{
			tbU2.Enabled = enabled;
			tbU2Float.Enabled = enabled;
			tbU2Hex.Enabled = enabled;
			tbU2Bin.Enabled = enabled;
		}

		public void RefreshData()
		{
			Clear();
			if (aat != null)
			{
				llAdd.Enabled = false;
				intern = true;
				refresh = true;
				if (aat.Parent.Type == AnimationTokenType.TwoByte)
				{
					EnableParameter(true);
				}
				else if (aat.Parent.Type == AnimationTokenType.SixByte)
				{
					EnableTimeCode(true);
					EnableParameter(true);
					EnableU1(true);
				}
				else
				{
					EnableTimeCode(true);
					EnableParameter(true);
					EnableU1(true);
					EnableU2(true);
				}

				cbEvent.Checked = aat.Linear;
				cbParentLock.Checked = aat.ParentLocked;
				tbTimeCode.Text = aat.TimeCode.ToString();
				tbParameter.Text = aat.Parameter.ToString();
				tbU1.Text = aat.Unknown1.ToString();
				tbU2.Text = aat.Unknown2.ToString();

				refresh = false;
				intern = false;
			}
		}

		bool intern,
			refresh;

		private void tbParameter_TextChanged(object sender, EventArgs e)
		{
			if (intern && !refresh)
			{
				return;
			}

			intern = true;

			short val = 0;
			if (aat != null)
			{
				val = Helper.StringToInt16(tbParameter.Text, aat.Parameter, 10);
			}

			tbParameterFloat.Text = val.ToString();
			if (aat != null)
			{
				if (aat.Parent.Parent != null)
				{
					float f = aat.GetCompressedFloat(val);
					if (aat.Parent.Parent.TransformationType == FrameType.Rotation)
					{
						f = (float)Geometry.Quaternion.RadToDeg(f);
					}

					tbParameterFloat.Text = f.ToString("N8");
				}
			}

			tbParameterHex.Text = "0x" + Helper.HexString(val);
			tbParameterBin.Text = Convert.ToString(val, 2);

			if (!refresh)
			{
				intern = false;
			}

			if (intern || aat == null)
			{
				return;
			}

			aat.Parameter = val;
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void tbU2_TextChanged(object sender, EventArgs e)
		{
			if (intern && !refresh)
			{
				return;
			}

			intern = true;

			short val = 0;
			if (aat != null)
			{
				val = Helper.StringToInt16(tbU2.Text, aat.Unknown2, 10);
			}

			tbU2Float.Text = val.ToString();
			if (aat != null)
			{
				if (aat.Parent.Parent != null)
				{
					tbU2Float.Text = aat.GetCompressedFloat(val).ToString("N8");
				}
			}

			tbU2Hex.Text = "0x" + Helper.HexString(val);
			tbU2Bin.Text = Convert.ToString(val, 2);

			if (!refresh)
			{
				intern = false;
			}

			if (intern || aat == null)
			{
				return;
			}

			aat.Unknown2 = val;
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void tbU1_TextChanged(object sender, EventArgs e)
		{
			if (intern && !refresh)
			{
				return;
			}

			intern = true;

			short val = 0;
			if (aat != null)
			{
				val = Helper.StringToInt16(tbU1.Text, aat.Unknown1, 10);
			}

			tbU1Float.Text = val.ToString();
			if (aat != null)
			{
				tbU1Float.Text = aat.GetCompressedFloat(val).ToString("N8");
			}

			tbU1Hex.Text = "0x" + Helper.HexString(val);
			tbU1Bin.Text = Convert.ToString(val, 2);

			if (!refresh)
			{
				intern = false;
			}

			if (intern || aat == null)
			{
				return;
			}

			aat.Unknown1 = val;
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void tbTimeCode_TextChanged(object sender, EventArgs e)
		{
			if (intern || aat == null)
			{
				return;
			}

			aat.TimeCode = Helper.StringToInt16(tbTimeCode.Text, aat.TimeCode, 10);
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void cbEvent_CheckedChanged(object sender, EventArgs e)
		{
			if (intern || aat == null)
			{
				return;
			}

			aat.Linear = cbEvent.Checked;
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void tbParameterFloat_TextChanged(object sender, EventArgs e)
		{
			if (intern || aat == null)
			{
				return;
			}

			intern = true;
			short val = 0;
			if (aat != null)
			{
				try
				{
					if (aat.Parent.Parent != null)
					{
						float f = Convert.ToSingle(tbParameterFloat.Text);
						if (aat.Parent.Parent.TransformationType == FrameType.Rotation)
						{
							f = (float)Geometry.Quaternion.DegToRad(f);
						}

						val = aat.FromCompressedFloat(f);
					}
				}
				catch { }

				tbParameter.Text = val.ToString();
				tbParameterHex.Text = "0x" + Helper.HexString(val);
				tbParameterBin.Text = Convert.ToString(val, 2);
			}

			intern = false;
			aat.Parameter = val;
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void tbU1Float_TextChanged(object sender, EventArgs e)
		{
			if (intern || aat == null)
			{
				return;
			}

			intern = true;
			short val = 0;
			if (aat != null)
			{
				try
				{
					if (aat.Parent.Parent != null)
					{
						val = aat.FromCompressedFloat(Convert.ToSingle(tbU1Float.Text));
					}
				}
				catch { }

				tbU1.Text = val.ToString();
				tbU1Hex.Text = "0x" + Helper.HexString(val);
				tbU1Bin.Text = Convert.ToString(val, 2);
			}

			intern = false;
			aat.Unknown1 = val;
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void tbU2Float_TextChanged(object sender, EventArgs e)
		{
			if (intern || aat == null)
			{
				return;
			}

			intern = true;
			short val = 0;
			if (aat != null)
			{
				try
				{
					if (aat.Parent.Parent != null)
					{
						val = aat.FromCompressedFloat(Convert.ToSingle(tbU2Float.Text));
					}
				}
				catch { }

				tbU2.Text = val.ToString();
				tbU2Hex.Text = "0x" + Helper.HexString(val);
				tbU2Bin.Text = Convert.ToString(val, 2);
			}

			intern = false;
			aat.Unknown2 = val;
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void tbParameterHex_TextChanged(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			intern = true;

			short val = 0;
			if (aat != null)
			{
				val = Helper.StringToInt16(tbParameterHex.Text, aat.Parameter, 16);
			}

			tbParameterFloat.Text = val.ToString();
			if (aat != null)
			{
				if (aat.Parent.Parent != null)
				{
					float f = aat.GetCompressedFloat(val);
					if (aat.Parent.Parent.TransformationType == FrameType.Rotation)
					{
						f = (float)Geometry.Quaternion.RadToDeg(f);
					}

					tbParameterFloat.Text = f.ToString("N8");
				}
			}

			tbParameter.Text = val.ToString();
			tbParameterBin.Text = Convert.ToString(val, 2);

			intern = false;
			if (aat == null)
			{
				return;
			}

			aat.Parameter = val;
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void tbU1Hex_TextChanged(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			intern = true;

			short val = 0;
			if (aat != null)
			{
				val = Helper.StringToInt16(tbU1Hex.Text, aat.Unknown1, 16);
			}

			tbU1Float.Text = val.ToString();
			if (aat != null)
			{
				tbU1Float.Text = aat.GetCompressedFloat(val).ToString("N8");
			}

			tbU1.Text = val.ToString();
			tbU1Bin.Text = Convert.ToString(val, 2);

			intern = false;
			if (aat == null)
			{
				return;
			}

			aat.Unknown1 = val;
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void tbU2Hex_TextChanged(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			intern = true;

			short val = 0;
			if (aat != null)
			{
				val = Helper.StringToInt16(tbU2Hex.Text, aat.Unknown2, 16);
			}

			tbU2Float.Text = val.ToString();
			if (aat != null)
			{
				tbU2Float.Text = aat.GetCompressedFloat(val).ToString("N8");
			}

			tbU2.Text = val.ToString();
			tbU2Bin.Text = Convert.ToString(val, 2);

			intern = false;
			if (aat == null)
			{
				return;
			}

			aat.Unknown2 = val;
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void tbParameterBin_TextChanged(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			intern = true;

			short val = 0;
			if (aat != null)
			{
				val = Helper.StringToInt16(tbParameterBin.Text, aat.Parameter, 2);
			}

			tbParameterFloat.Text = val.ToString();
			if (aat != null)
			{
				if (aat.Parent.Parent != null)
				{
					float f = aat.GetCompressedFloat(val);
					if (aat.Parent.Parent.TransformationType == FrameType.Rotation)
					{
						f = (float)Geometry.Quaternion.RadToDeg(f);
					}

					tbParameterFloat.Text = f.ToString("N8");
				}
			}

			tbParameter.Text = val.ToString();
			tbParameterHex.Text = "0x" + Helper.HexString(val);

			intern = false;
			if (aat == null)
			{
				return;
			}

			aat.Parameter = val;
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void tbU1Bin_TextChanged(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			intern = true;

			short val = 0;
			if (aat != null)
			{
				val = Helper.StringToInt16(tbU1Bin.Text, aat.Unknown1, 2);
			}

			tbU1Float.Text = val.ToString();
			if (aat != null)
			{
				tbU1Float.Text = aat.GetCompressedFloat(val).ToString("N8");
			}

			tbU1.Text = val.ToString();
			tbU1Hex.Text = "0x" + Helper.HexString(val);

			intern = false;
			if (aat == null)
			{
				return;
			}

			aat.Unknown1 = val;
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void tbU2Bin_TextChanged(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			intern = true;

			short val = 0;
			if (aat != null)
			{
				val = Helper.StringToInt16(tbU2Bin.Text, aat.Unknown2, 2);
			}

			tbU2Float.Text = val.ToString();
			if (aat != null)
			{
				tbU2Float.Text = aat.GetCompressedFloat(val).ToString("N8");
			}

			tbU2.Text = val.ToString();
			tbU2Hex.Text = "0x" + Helper.HexString(val);

			intern = false;
			if (aat == null)
			{
				return;
			}

			aat.Unknown2 = val;
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		private void llDelete_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (aat == null)
			{
				return;
			}

			aat.Parent.Remove(aat);
			aat = null;
			if (Deleted != null)
			{
				Deleted(this, new EventArgs());
			}
		}

		private void llAdd_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (CreateClicked != null)
			{
				CreateClicked(this, new EventArgs());
			}
		}

		private void cbParentLock_CheckedChanged(object sender, EventArgs e)
		{
			if (intern || aat == null)
			{
				return;
			}

			aat.ParentLocked = cbParentLock.Checked;

			RefreshData();
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		#region Events
		public event EventHandler Deleted;
		public event EventHandler Changed;
		public event EventHandler Cleared;
		public event EventHandler CreateClicked;
		#endregion
	}
}
