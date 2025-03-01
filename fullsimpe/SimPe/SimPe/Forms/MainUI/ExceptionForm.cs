// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Windows.Forms;

namespace SimPe.Forms.MainUI
{
	/// <summary>
	/// Summary description for ExceptionForm.
	/// </summary>
	public class ExceptionForm : Form
	{
		internal Label lberr;
		private RichTextBox rtb;
		private PictureBox pictureBox1;
		private LinkLabel lldetail;
		private Panel panel1;
		private GroupBox gbdetail;
		private Panel panel2;
		private Button button1;
		private LinkLabel linkLabel1;
		private Panel panel3;
		private LinkLabel linkLabel2;
		private TextBox tbsup;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ExceptionForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			//
			// TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(ExceptionForm)
				);
			lberr = new Label();
			gbdetail = new GroupBox();
			rtb = new RichTextBox();
			linkLabel1 = new LinkLabel();
			pictureBox1 = new PictureBox();
			lldetail = new LinkLabel();
			panel1 = new Panel();
			panel2 = new Panel();
			linkLabel2 = new LinkLabel();
			panel3 = new Panel();
			button1 = new Button();
			tbsup = new TextBox();
			gbdetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			//
			// lberr
			//
			resources.ApplyResources(lberr, "lberr");
			lberr.BackColor = System.Drawing.Color.Transparent;
			lberr.ForeColor = System.Drawing.Color.Black;
			lberr.Name = "lberr";
			//
			// gbdetail
			//
			resources.ApplyResources(gbdetail, "gbdetail");
			gbdetail.Controls.Add(rtb);
			gbdetail.Controls.Add(linkLabel1);
			gbdetail.FlatStyle = FlatStyle.System;
			gbdetail.Name = "gbdetail";
			gbdetail.TabStop = false;
			//
			// rtb
			//
			resources.ApplyResources(rtb, "rtb");
			rtb.BackColor = System.Drawing.SystemColors.ControlLightLight;
			rtb.BorderStyle = BorderStyle.None;
			rtb.ForeColor = System.Drawing.Color.FromArgb(
				64,
				64,
				64
			);
			rtb.Name = "rtb";
			rtb.ReadOnly = true;
			//
			// linkLabel1
			//
			resources.ApplyResources(linkLabel1, "linkLabel1");
			linkLabel1.Name = "linkLabel1";
			linkLabel1.TabStop = true;
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					CopyToClipboard
				);
			//
			// pictureBox1
			//
			resources.ApplyResources(pictureBox1, "pictureBox1");
			pictureBox1.Name = "pictureBox1";
			pictureBox1.TabStop = false;
			//
			// lldetail
			//
			resources.ApplyResources(lldetail, "lldetail");
			lldetail.Name = "lldetail";
			lldetail.TabStop = true;
			lldetail.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					ShowDetail
				);
			//
			// panel1
			//
			panel1.Controls.Add(pictureBox1);
			panel1.Controls.Add(lberr);
			panel1.Controls.Add(lldetail);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			//
			// panel2
			//
			panel2.Controls.Add(linkLabel2);
			panel2.Controls.Add(panel3);
			panel2.Controls.Add(button1);
			panel2.Controls.Add(tbsup);
			resources.ApplyResources(panel2, "panel2");
			panel2.Name = "panel2";
			//
			// linkLabel2
			//
			resources.ApplyResources(linkLabel2, "linkLabel2");
			linkLabel2.Name = "linkLabel2";
			linkLabel2.TabStop = true;
			linkLabel2.UseCompatibleTextRendering = true;
			linkLabel2.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Support);
			//
			// panel3
			//
			panel3.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(panel3, "panel3");
			panel3.Name = "panel3";
			//
			// button1
			//
			resources.ApplyResources(button1, "button1");
			button1.Name = "button1";
			button1.Click += new EventHandler(button1_Click);
			//
			// tbsup
			//
			resources.ApplyResources(tbsup, "tbsup");
			tbsup.Name = "tbsup";
			//
			// ExceptionForm
			//
			resources.ApplyResources(this, "$this");
			BackColor = System.Drawing.SystemColors.ControlLightLight;
			Controls.Add(panel2);
			Controls.Add(panel1);
			Controls.Add(gbdetail);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "ExceptionForm";
			gbdetail.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		/// <summary>
		/// Show an Exception Message
		/// </summary>
		/// <param name="ex">The Exception that as thrown</param>
		public static void Execute(Exception ex)
		{
			Execute(ex.Message, ex);
		}

		private void Support(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			try
			{
				Help.ShowHelp(this, tbsup.Text);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		[STAThread]
		private void CopyToClipboard(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			string text = "";
			foreach (string line in rtb.Lines)
			{
				text += line + "\r\n"; // RichTextBox converts line breaks to seperate arrays, we need to put the line breaks back (CJH)
			}

			Clipboard.SetDataObject(text, true);
			// Clipboard.SetDataObject(rtb.Text, true);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ShowDetail(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			lldetail.Visible = false;
			gbdetail.Visible = true;
			Location = new System.Drawing.Point(
				Location.X - 168,
				Location.Y - 186
			);
			Size = new System.Drawing.Size(800, 600);
			Refresh();
		}

		/// <summary>
		/// Show an Exception Message
		/// </summary>
		/// <param name="message">The Message you want to display</param>
		/// <param name="ex">The Exception that as thrown</param>
		public static void Execute(string message, Exception ex)
		{
			if (Helper.NoErrors)
			{
				return;
			}

			if (message == null)
			{
				message = "";
			}

			if (message.Trim() == "")
			{
				message = ex.Message;
			}

			if (message.Contains("Microsoft.DirectX"))
			{
				ex = new Warning(
					"You need to install MANAGED DirectX",
					"In order to perfrom some Operations, you need to install Managed DirectX (which is an additional set of libraries for the DirectX you installed with The Sims 2).\n\nPlease read http://www.modthesims2.com/index.php? for more Details.",
					ex
				);
				message = ex.Message;
			}

			Exception myex = ex;
			string extrace = "";
			while (myex != null)
			{
				extrace +=
					myex.ToString() /*+": "+myex.Message*/
					+ Helper.lbr;
				myex = myex.InnerException;
			}

			ExceptionForm frm = new ExceptionForm();

			frm.lberr.Text = message.Trim();

			string text = "";
			text +=
				@"{\rtf1\ansi\ansicpg1252\deff0\deflang1031{\fonttbl{\f0\fswiss\fprq2\fcharset0 Verdana;}}";
			text += @"{\colortbl ;\red90\green90\blue90;}";
			if (ex.GetType() == typeof(Warning))
			{
				frm.Text = "Warning";
				frm.lberr.Text = "Warning: " + frm.lberr.Text;
				frm.linkLabel2.Visible = false;
				text +=
					@"\viewkind4\uc1\pard\cf1\b\f0\fs16 This is just a Warning. It is supposed to keep you informed about a Problem. Most of the time this is not a Bug!\b0\par";
				text += @"\pard\par";
				text +=
					@"\pard\li284 "
					+ ((Warning)ex)
						.Details.Trim()
						.Replace("\\", "\\\\")
						.Replace("\n", @"\par\pard\li284")
					+ @"\par";
			}
#if DEBUG
#else
			else
#endif
			{
				text += @"\viewkind4\uc1\pard\cf1\b\f0\fs16 Message:\b0\par";
				text +=
					@"\pard\li284 "
					+ message
						.Trim()
						.Replace("\\", "\\\\")
						.Replace("\n", @"\par\pard\li284")
					+ @"\par";

				try
				{
					text += @"\pard\par";
					text += @"\b SimPe Version:\par";
					text +=
						@"\pard\li284\b0 "
						+ Helper.StartedGui.ToString()
						+ " ("
						+ Helper.SimPeVersion.ProductMajorPart.ToString()
						+ "."
						+ Helper.SimPeVersion.ProductMinorPart.ToString()
						+ "."
						+ Helper.SimPeVersion.ProductBuildPart.ToString()
						+ "."
						+ Helper.SimPeVersion.ProductPrivatePart.ToString()
						+ ")."
						+ @"\par";
				}
				catch { }

				text += @"\pard\par";
				text += @"\b Exception Stack:\par";
				text +=
					@"\pard\li284\b0 "
					+ extrace
						.Trim()
						.Replace("\\", "\\\\")
						.Replace("\n", @"\par\pard\li284")
					+ @"\par";

				if (ex.Source != null)
				{
					text += @"\pard\par";
					text += @"\b Source:\par";
					text +=
						@"\pard\li284\b0 "
						+ ex.Source.Trim()
							.Replace("\\", "\\\\")
							.Replace("\n", @"\par\pard\li284")
						+ @"\par";
				}

				if (ex.StackTrace != null)
				{
					text += @"\pard\par";
					text += @"\b Execution Stack:\par";
					text +=
						@"\pard\li284\b0 "
						+ ex.StackTrace.Trim()
							.Replace("\\", "\\\\")
							.Replace("\n", @"\par\pard\li284")
						+ @"\par";
				}
			}

			try
			{
				text += @"\pard\par";
				text += @"\b Windows Version:\par";
				text +=
					@"\pard\li284\b0 "
					+ Ambertation.Windows.Forms.APIHelp.GetVersionEx()
					+ @"\par";
			}
			catch { }

			try
			{
				text += @"\pard\par";
				text += @"\b .NET Version:\par";
				text +=
					@"\pard\li284\b0 "
					+
						Environment.Version.ToString()
						.Replace("\\", "\\\\")
						.Replace("\n", @"\par\pard\li284")
					+ @"\par";
			}
			catch { }

			text += @"}";

			text = text.Replace("\n", @"\par\pard");
			frm.rtb.Rtf = text;

			if (Helper.WindowsRegistry.HiddenMode)
			{
				frm.lldetail.Visible = false;
			}
			else
			{
				frm.gbdetail.Visible = false;
				frm.Height -= frm.gbdetail.Height;
			}

			frm.ShowDialog();
		}
	}
}
