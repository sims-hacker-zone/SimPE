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
using System.Drawing;
using System.Windows.Forms;

namespace SimPe
{
	/// <summary>
	/// Summary description for About.
	/// </summary>
	public class About : Windows.Forms.HelpForm
	{
		private RichTextBox rtb;
		private Button button1;
		private Button button2;
		private WebBrowser wb;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public About()
			: this(false) { }

		public About(bool html)
		{
			InitializeComponent();
			button2.BackColor = SystemColors.Control;
			FormBorderStyle = FormBorderStyle.None;

			wb.Navigating += new WebBrowserNavigatingEventHandler(wb_Navigating);
			wb.Navigated += new WebBrowserNavigatedEventHandler(wb_Navigated);
			wb.IsWebBrowserContextMenuEnabled = Helper.QARelease;
			wb.AllowNavigation = true;

			wb.Visible = html;
			rtb.Visible = !html;
		}

		void wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
		}

		void wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.OriginalString.StartsWith("about:"))
			{
				return;
			}

			if (e.TargetFrameName != "_blank")
			{
				e.Cancel = true;
				Help.ShowHelp(wb, e.Url.OriginalString);
				//wb.Navigate(e.Url, true);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(About));
			rtb = new RichTextBox();
			button1 = new Button();
			button2 = new Button();
			wb = new WebBrowser();
			SuspendLayout();
			//
			// rtb
			//
			rtb.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			rtb.BackColor = Color.White;
			rtb.BorderStyle = BorderStyle.None;
			rtb.Cursor = Cursors.Arrow;
			rtb.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			rtb.Location = new Point(30, 130);
			rtb.Name = "rtb";
			rtb.ReadOnly = true;
			rtb.ScrollBars = RichTextBoxScrollBars.Vertical;
			rtb.Size = new Size(975, 484);
			rtb.TabIndex = 2;
			rtb.Text = "";
			rtb.LinkClicked += new LinkClickedEventHandler(
				rtb_LinkClicked
			);
			rtb.Enter += new EventHandler(rtb_Enter);
			//
			// button1
			//
			button1.Location = new Point(342, 170);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 3;
			button1.Text = "button1";
			//
			// button2
			//
			button2.Image = (
				(Image)(resources.GetObject("button2.Image"))
			);
			button2.Location = new Point(938, 12);
			button2.Name = "button2";
			button2.Size = new Size(64, 23);
			button2.TabIndex = 4;
			button2.UseVisualStyleBackColor = false;
			button2.Click += new EventHandler(button2_Click);
			//
			// wb
			//
			wb.AllowNavigation = false;
			wb.AllowWebBrowserDrop = false;
			wb.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			wb.IsWebBrowserContextMenuEnabled = false;
			wb.Location = new Point(30, 130);
			wb.MinimumSize = new Size(20, 20);
			wb.Name = "wb";
			wb.Size = new Size(975, 484);
			wb.TabIndex = 5;
			wb.WebBrowserShortcutsEnabled = false;
			//
			// About
			//
			AutoScaleDimensions = new SizeF(6F, 13F);
			ClientSize = new Size(1024, 661);
			Controls.Add(wb);
			Controls.Add(button2);
			Controls.Add(rtb);
			Controls.Add(button1);
			Icon = ((Icon)(resources.GetObject("$this.Icon")));
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "About";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "About";
			ResumeLayout(false);
		}
		#endregion

		void LoadResource(string flname)
		{
			rtb.Visible = true;
			System.Diagnostics.FileVersionInfo v = Helper.SimPeVersion;
			System.IO.Stream s = GetType()
				.Assembly.GetManifestResourceStream(
					"SimPe.docs."
						+ flname
						+ "-"
						+ System
							.Globalization
							.CultureInfo
							.CurrentCulture
							.TwoLetterISOLanguageName
						+ ".rtf"
				);
			if (s == null)
			{
				s = GetType()
					.Assembly.GetManifestResourceStream(
						"SimPe.docs." + flname + "-en.rtf"
					);
			}

			if (s != null)
			{
				System.IO.StreamReader sr = new System.IO.StreamReader(s);
				string vtext = Helper.VersionToString(v); //v.FileMajorPart +"."+v.FileMinorPart;
				if (Helper.QARelease)
				{
					vtext = "QA " + vtext;
				}

				if (Helper.WindowsRegistry.HiddenMode)
				{
					vtext += " [debug]";
				}
				else
				{
					if (Helper.Profile.Length > 0)
					{
						vtext += " [" + Helper.Profile + "]"; //CJH
					}
					else if (Helper.StartedGui == Executable.Classic)
					{
						vtext += " [Classic]"; //CJH
					}
				}
				rtb.Rtf = sr.ReadToEnd().Replace("\\{Version\\}", vtext);
			}
			else
			{
				rtb.Text = "Error: Unknown Resource " + flname + ".";
			}
		}

		void LoadHtmResource(string flname)
		{
			rtb.Visible = false;
			wb.Visible = true;
			System.IO.Stream s = GetType()
				.Assembly.GetManifestResourceStream("SimPe.docs." + flname + ".htm");
			if (s != null)
			{
				wb.DocumentStream = s;
			}
			else
			{
				wb.DocumentText = "Error: Unknown Resource " + flname + ".";
			}
		}

		/// <summary>
		/// Display the About Screen
		/// </summary>
		public static void ShowAbout()
		{
			About f = new About();
			f.Text = Localization.GetString("About");

			f.LoadResource("about");
			Splash.Screen.Stop();
			f.ShowDialog();
		}

		/// <summary>
		/// Display the Welcome Screen
		/// </summary>
		public static void ShowWelcome()
		{
			About f = new About();
			f.Text = Localization.GetString("Welcome");

			f.LoadResource("welcome");
			Splash.Screen.Stop();

			f.ShowDialog();
		}

		/// <summary>
		/// Display the FileTable Screen
		/// </summary>
		public static void ShowFileTable()
		{
			About f = new About(true);
			f.Text = "File Table and Profiles";

			f.LoadHtmResource("FileTable");
			Splash.Screen.Stop();
			f.ShowDialog();
		}

		private void rtb_LinkClicked(
			object sender,
			LinkClickedEventArgs e
		)
		{
			try
			{
				Help.ShowHelp(
					this,
					e.LinkText.Replace("http://localhost", Helper.SimPePath)
				);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		private void rtb_Enter(object sender, EventArgs e)
		{
			button1.Focus();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
