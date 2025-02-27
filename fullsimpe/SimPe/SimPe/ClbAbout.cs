using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe
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
			this.FormBorderStyle = FormBorderStyle.None;
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
				new System.ComponentModel.ComponentResourceManager(typeof(ClbAbout));
			this.button2 = new Button();
			this.wb = new WebBrowser();
			this.SuspendLayout();
			//
			// button2
			//
			this.button2.Image = (
				(Image)(resources.GetObject("button2.Image"))
			);
			this.button2.Location = new Point(938, 12);
			this.button2.Name = "button2";
			this.button2.Size = new Size(64, 23);
			this.button2.TabIndex = 4;
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new EventHandler(this.button2_Click);
			//
			// wb
			//
			this.wb.AllowNavigation = false;
			this.wb.AllowWebBrowserDrop = false;
			this.wb.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.wb.IsWebBrowserContextMenuEnabled = false;
			this.wb.Location = new Point(30, 130);
			this.wb.MinimumSize = new Size(20, 20);
			this.wb.Name = "wb";
			this.wb.Size = new Size(975, 484);
			this.wb.TabIndex = 5;
			this.wb.WebBrowserShortcutsEnabled = false;
			//
			// ClbAbout
			//
			this.ClientSize = new Size(1024, 661);
			this.Controls.Add(this.wb);
			this.Controls.Add(this.button2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ClbAbout";
			this.ShowIcon = false;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "About";
			this.ResumeLayout(false);
		}
		#endregion

		void LoadHtmResource(string flname)
		{
			System.IO.Stream s = this.GetType()
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
			ClbAbout f = new ClbAbout(true);
			f.Text = "Colour Binning Tool";

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
