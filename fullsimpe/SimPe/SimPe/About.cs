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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe
{
	/// <summary>
	/// Summary description for About.
	/// </summary>
	public class About : SimPe.Windows.Forms.HelpForm
	{
		private System.Windows.Forms.RichTextBox rtb;
		private System.Windows.Forms.Button button1;
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
			this.FormBorderStyle = FormBorderStyle.None;

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
				System.Windows.Forms.Help.ShowHelp(wb, e.Url.OriginalString);
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
			this.rtb = new System.Windows.Forms.RichTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.wb = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			//
			// rtb
			//
			this.rtb.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.rtb.BackColor = System.Drawing.Color.White;
			this.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtb.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.rtb.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.rtb.Location = new System.Drawing.Point(30, 130);
			this.rtb.Name = "rtb";
			this.rtb.ReadOnly = true;
			this.rtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.rtb.Size = new System.Drawing.Size(975, 484);
			this.rtb.TabIndex = 2;
			this.rtb.Text = "";
			this.rtb.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(
				this.rtb_LinkClicked
			);
			this.rtb.Enter += new System.EventHandler(this.rtb_Enter);
			//
			// button1
			//
			this.button1.Location = new System.Drawing.Point(342, 170);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "button1";
			//
			// button2
			//
			this.button2.Image = (
				(System.Drawing.Image)(resources.GetObject("button2.Image"))
			);
			this.button2.Location = new System.Drawing.Point(938, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(64, 23);
			this.button2.TabIndex = 4;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			//
			// wb
			//
			this.wb.AllowNavigation = false;
			this.wb.AllowWebBrowserDrop = false;
			this.wb.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.wb.IsWebBrowserContextMenuEnabled = false;
			this.wb.Location = new System.Drawing.Point(30, 130);
			this.wb.MinimumSize = new System.Drawing.Size(20, 20);
			this.wb.Name = "wb";
			this.wb.Size = new System.Drawing.Size(975, 484);
			this.wb.TabIndex = 5;
			this.wb.WebBrowserShortcutsEnabled = false;
			//
			// About
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(1024, 661);
			this.Controls.Add(this.wb);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.rtb);
			this.Controls.Add(this.button1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "About";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About";
			this.ResumeLayout(false);
		}
		#endregion

		void LoadResource(string flname)
		{
			rtb.Visible = true;
			System.Diagnostics.FileVersionInfo v = Helper.SimPeVersion;
			System.IO.Stream s = this.GetType()
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
				s = this.GetType()
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
			System.IO.Stream s = this.GetType()
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
			f.Text = SimPe.Localization.GetString("About");

			f.LoadResource("about");
			SimPe.Splash.Screen.Stop();
			f.ShowDialog();
		}

		/// <summary>
		/// Display the Welcome Screen
		/// </summary>
		public static void ShowWelcome()
		{
			About f = new About();
			f.Text = SimPe.Localization.GetString("Welcome");

			f.LoadResource("welcome");
			SimPe.Splash.Screen.Stop();

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
			SimPe.Splash.Screen.Stop();
			f.ShowDialog();
		}

		private void rtb_LinkClicked(
			object sender,
			System.Windows.Forms.LinkClickedEventArgs e
		)
		{
			try
			{
				System.Windows.Forms.Help.ShowHelp(
					this,
					e.LinkText.Replace("http://localhost", Helper.SimPePath)
				);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		private void rtb_Enter(object sender, System.EventArgs e)
		{
			button1.Focus();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
