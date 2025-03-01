// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.IO;
using System.Windows.Forms;

namespace SimPe.Plugin.Tool
{
	/// <summary>
	/// Zusammenfassung für Report.
	/// </summary>
	internal class Report : Form
	{
		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel1;
		private RichTextBox rtb;
		private LinkLabel linkLabel1;
		private SaveFileDialog sfd;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Report()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

			//
			// TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
			}
			base.Dispose(disposing);
			if (csv != null)
			{
				csv.Close();
				csv.Dispose();
				csv = null;
			}
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(Report));
			xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			linkLabel1 = new LinkLabel();
			rtb = new RichTextBox();
			sfd = new SaveFileDialog();
			xpGradientPanel1.SuspendLayout();
			SuspendLayout();
			//
			// xpGradientPanel1
			//
			xpGradientPanel1.AccessibleDescription = resources.GetString(
				"xpGradientPanel1.AccessibleDescription"
			);
			xpGradientPanel1.AccessibleName = resources.GetString(
				"xpGradientPanel1.AccessibleName"
			);
			xpGradientPanel1.Anchor =
				(AnchorStyles)
					resources.GetObject("xpGradientPanel1.Anchor")

			;
			xpGradientPanel1.AutoScroll =
				(bool)resources.GetObject("xpGradientPanel1.AutoScroll")
			;
			xpGradientPanel1.AutoScrollMargin =
				(System.Drawing.Size)
					resources.GetObject("xpGradientPanel1.AutoScrollMargin")

			;
			xpGradientPanel1.AutoScrollMinSize =
				(System.Drawing.Size)
					resources.GetObject("xpGradientPanel1.AutoScrollMinSize")

			;
			xpGradientPanel1.BackgroundImage =
				(System.Drawing.Image)
					resources.GetObject("xpGradientPanel1.BackgroundImage")

			;
			xpGradientPanel1.Controls.Add(linkLabel1);
			xpGradientPanel1.Controls.Add(rtb);
			xpGradientPanel1.Dock =
				(DockStyle)
					resources.GetObject("xpGradientPanel1.Dock")

			;
			xpGradientPanel1.Enabled =
				(bool)resources.GetObject("xpGradientPanel1.Enabled")
			;
			xpGradientPanel1.Font =
				(System.Drawing.Font)resources.GetObject("xpGradientPanel1.Font")
			;
			xpGradientPanel1.ImeMode =
				(ImeMode)
					resources.GetObject("xpGradientPanel1.ImeMode")

			;
			xpGradientPanel1.Location =
				(System.Drawing.Point)resources.GetObject("xpGradientPanel1.Location")
			;
			xpGradientPanel1.Name = "xpGradientPanel1";
			xpGradientPanel1.RightToLeft =
				(RightToLeft)
					resources.GetObject("xpGradientPanel1.RightToLeft")

			;
			xpGradientPanel1.Size =
				(System.Drawing.Size)resources.GetObject("xpGradientPanel1.Size")
			;
			xpGradientPanel1.TabIndex =
				(int)resources.GetObject("xpGradientPanel1.TabIndex")
			;
			xpGradientPanel1.Text = resources.GetString("xpGradientPanel1.Text");
			xpGradientPanel1.Visible =
				(bool)resources.GetObject("xpGradientPanel1.Visible")
			;
			xpGradientPanel1.Watermark =
				(System.Drawing.Image)
					resources.GetObject("xpGradientPanel1.Watermark")

			;
			xpGradientPanel1.WatermarkSize =
				(System.Drawing.Size)
					resources.GetObject("xpGradientPanel1.WatermarkSize")

			;
			//
			// linkLabel1
			//
			linkLabel1.AccessibleDescription = resources.GetString(
				"linkLabel1.AccessibleDescription"
			);
			linkLabel1.AccessibleName = resources.GetString(
				"linkLabel1.AccessibleName"
			);
			linkLabel1.Anchor =
				(AnchorStyles)
					resources.GetObject("linkLabel1.Anchor")

			;
			linkLabel1.AutoSize =
				(bool)resources.GetObject("linkLabel1.AutoSize")
			;
			linkLabel1.BackColor = System.Drawing.Color.Transparent;
			linkLabel1.Dock =
				(DockStyle)resources.GetObject("linkLabel1.Dock")
			;
			linkLabel1.Enabled =
				(bool)resources.GetObject("linkLabel1.Enabled")
			;
			linkLabel1.Font =
				(System.Drawing.Font)resources.GetObject("linkLabel1.Font")
			;
			linkLabel1.Image =
				(System.Drawing.Image)resources.GetObject("linkLabel1.Image")
			;
			linkLabel1.ImageAlign =
				(System.Drawing.ContentAlignment)
					resources.GetObject("linkLabel1.ImageAlign")

			;
			linkLabel1.ImageIndex =
				(int)resources.GetObject("linkLabel1.ImageIndex")
			;
			linkLabel1.ImeMode =
				(ImeMode)
					resources.GetObject("linkLabel1.ImeMode")

			;
			linkLabel1.LinkArea =
				(LinkArea)
					resources.GetObject("linkLabel1.LinkArea")

			;
			linkLabel1.Location =
				(System.Drawing.Point)resources.GetObject("linkLabel1.Location")
			;
			linkLabel1.Name = "linkLabel1";
			linkLabel1.RightToLeft =
				(RightToLeft)
					resources.GetObject("linkLabel1.RightToLeft")

			;
			linkLabel1.Size =
				(System.Drawing.Size)resources.GetObject("linkLabel1.Size")
			;
			linkLabel1.TabIndex =
				(int)resources.GetObject("linkLabel1.TabIndex")
			;
			linkLabel1.TabStop = true;
			linkLabel1.Text = resources.GetString("linkLabel1.Text");
			linkLabel1.TextAlign =
				(System.Drawing.ContentAlignment)
					resources.GetObject("linkLabel1.TextAlign")

			;
			linkLabel1.Visible =
				(bool)resources.GetObject("linkLabel1.Visible")
			;
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel1_LinkClicked
				);
			//
			// rtb
			//
			rtb.AccessibleDescription = resources.GetString(
				"rtb.AccessibleDescription"
			);
			rtb.AccessibleName = resources.GetString("rtb.AccessibleName");
			rtb.Anchor =
				(AnchorStyles)resources.GetObject("rtb.Anchor")
			;
			rtb.AutoSize = (bool)resources.GetObject("rtb.AutoSize");
			rtb.BackgroundImage =
				(System.Drawing.Image)resources.GetObject("rtb.BackgroundImage")
			;
			rtb.BorderStyle = BorderStyle.None;
			rtb.BulletIndent = (int)resources.GetObject("rtb.BulletIndent");
			rtb.Dock =
				(DockStyle)resources.GetObject("rtb.Dock")
			;
			rtb.Enabled = (bool)resources.GetObject("rtb.Enabled");
			rtb.Font = (System.Drawing.Font)resources.GetObject("rtb.Font");
			rtb.ImeMode =
				(ImeMode)resources.GetObject("rtb.ImeMode")
			;
			rtb.Location =
				(System.Drawing.Point)resources.GetObject("rtb.Location")
			;
			rtb.MaxLength = (int)resources.GetObject("rtb.MaxLength");
			rtb.Multiline = (bool)resources.GetObject("rtb.Multiline");
			rtb.Name = "rtb";
			rtb.ReadOnly = true;
			rtb.RightMargin = (int)resources.GetObject("rtb.RightMargin");
			rtb.RightToLeft =
				(RightToLeft)
					resources.GetObject("rtb.RightToLeft")

			;
			rtb.ScrollBars =
				(RichTextBoxScrollBars)
					resources.GetObject("rtb.ScrollBars")

			;
			rtb.ShowSelectionMargin = true;
			rtb.Size = (System.Drawing.Size)resources.GetObject("rtb.Size");
			rtb.TabIndex = (int)resources.GetObject("rtb.TabIndex");
			rtb.Text = resources.GetString("rtb.Text");
			rtb.Visible = (bool)resources.GetObject("rtb.Visible");
			rtb.WordWrap = (bool)resources.GetObject("rtb.WordWrap");
			rtb.ZoomFactor =
				(float)resources.GetObject("rtb.ZoomFactor")
			;
			//
			// sfd
			//
			sfd.Filter = resources.GetString("sfd.Filter");
			sfd.Title = resources.GetString("sfd.Title");
			//
			// Report
			//
			AccessibleDescription = resources.GetString(
				"$this.AccessibleDescription"
			);
			AccessibleName = resources.GetString("$this.AccessibleName");
			AutoScaleBaseSize =
				(System.Drawing.Size)resources.GetObject("$this.AutoScaleBaseSize")
			;
			AutoScroll = (bool)resources.GetObject("$this.AutoScroll");
			AutoScrollMargin =
				(System.Drawing.Size)resources.GetObject("$this.AutoScrollMargin")
			;
			AutoScrollMinSize =
				(System.Drawing.Size)resources.GetObject("$this.AutoScrollMinSize")
			;
			BackgroundImage =
				(System.Drawing.Image)resources.GetObject("$this.BackgroundImage")
			;
			ClientSize =
				(System.Drawing.Size)resources.GetObject("$this.ClientSize")
			;
			Controls.Add(xpGradientPanel1);
			Enabled = (bool)resources.GetObject("$this.Enabled");
			Font = (System.Drawing.Font)resources.GetObject("$this.Font");
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			ImeMode =
				(ImeMode)resources.GetObject("$this.ImeMode")
			;
			Location =
				(System.Drawing.Point)resources.GetObject("$this.Location")
			;
			MaximumSize =
				(System.Drawing.Size)resources.GetObject("$this.MaximumSize")
			;
			MinimumSize =
				(System.Drawing.Size)resources.GetObject("$this.MinimumSize")
			;
			Name = "Report";
			RightToLeft =
				(RightToLeft)
					resources.GetObject("$this.RightToLeft")

			;
			StartPosition =
				(FormStartPosition)
					resources.GetObject("$this.StartPosition")

			;
			Text = resources.GetString("$this.Text");
			xpGradientPanel1.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		StreamWriter csv;

		public void Execute(StreamWriter csv)
		{
			csv.Flush();
			csv.BaseStream.Seek(0, SeekOrigin.Begin);
			StreamReader sr = new StreamReader(csv.BaseStream);
			sr.BaseStream.Seek(0, SeekOrigin.Begin);

			this.csv = csv;
			rtb.Text = sr.ReadToEnd();
			ShowDialog();
		}

		private void linkLabel1_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				csv.BaseStream.Seek(0, SeekOrigin.Begin);
				StreamReader sr = new StreamReader(csv.BaseStream);
				sr.BaseStream.Seek(0, SeekOrigin.Begin);

				StreamWriter sw = File.CreateText(sfd.FileName);
				try
				{
					sw.Write(sr.ReadToEnd());
				}
				finally
				{
					sw.Close();
					sw.Dispose();
					sw = null;
					sr = null;
				}
			}
		}
	}
}
