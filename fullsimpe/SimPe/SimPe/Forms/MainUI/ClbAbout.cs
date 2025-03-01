// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Forms.MainUI
{
	/// <summary>
	/// Zusammenfassung f�r About.
	/// </summary>
	public class ClbAbout : Windows.Forms.HelpForm
	{
		private Button button2;
		private WebBrowser wb;
		private System.ComponentModel.Container components = null;

		public ClbAbout()
			: this(false) { }

		public ClbAbout(bool html)
		{
			InitializeComponent();
			button2.BackColor = SystemColors.Control;
			FormBorderStyle = FormBorderStyle.None;
			wb.Navigating += new WebBrowserNavigatingEventHandler(wb_Navigating);
			wb.Navigated += new WebBrowserNavigatedEventHandler(wb_Navigated);
			wb.AllowNavigation = true;
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
		/// Die verwendeten Ressourcen bereinigen.
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
				new System.ComponentModel.ComponentResourceManager(typeof(ClbAbout));
			button2 = new Button();
			wb = new WebBrowser();
			SuspendLayout();
			//
			// button2
			//
			button2.Image =
				(Image)resources.GetObject("button2.Image")
			;
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




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			wb.IsWebBrowserContextMenuEnabled = false;
			wb.Location = new Point(30, 130);
			wb.MinimumSize = new Size(20, 20);
			wb.Name = "wb";
			wb.Size = new Size(975, 484);
			wb.TabIndex = 5;
			wb.WebBrowserShortcutsEnabled = false;
			//
			// ClbAbout
			//
			ClientSize = new Size(1024, 661);
			Controls.Add(wb);
			Controls.Add(button2);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "ClbAbout";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "About";
			ResumeLayout(false);
		}
		#endregion

		void LoadHtmResource(string flname)
		{
			System.IO.Stream s = GetType()
				.Assembly.GetManifestResourceStream("SimPe.Plugin." + flname + ".htm");
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
		/// Display the Tool Help Screen
		/// </summary>
		public static void ShowToolHelp()
		{
			ClbAbout f = new ClbAbout(true)
			{
				Text = "Colour Binning Tool"
			};

			f.LoadHtmResource("ColourBin");
			Splash.Screen.Stop();
			f.ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
