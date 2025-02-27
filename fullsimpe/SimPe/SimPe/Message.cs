using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe
{
	/// <summary>
	/// Summary description for Message.
	/// </summary>
	public class Message : Form
	{
		private Panel panel1;
		private Label label1;
		private SteepValley.Windows.Forms.XPGradientPanel panel2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Message()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			panel1.Tag = 1;
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
				new System.ComponentModel.ComponentResourceManager(typeof(Message));
			panel1 = new Panel();
			panel2 = new SteepValley.Windows.Forms.XPGradientPanel();
			label1 = new Label();
			panel2.SuspendLayout();
			SuspendLayout();
			//
			// panel1
			//
			panel1.BackColor = SystemColors.Highlight;
			panel1.Location = new Point(0, 32);
			panel1.Name = "panel1";
			panel1.Size = new Size(548, 40);
			panel1.TabIndex = 0;
			//
			// panel2
			//
			panel2.BackColor = Color.Transparent;
			panel2.Controls.Add(label1);
			panel2.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			panel2.Location = new Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new Size(548, 32);
			panel2.TabIndex = 1;
			//
			// label1
			//
			label1.AutoSize = true;
			label1.BackColor = Color.Transparent;
			label1.Font = new Font(
				"Microsoft Sans Serif",
				9.75F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			label1.Location = new Point(8, 8);
			label1.MaximumSize = new Size(524, 0);
			label1.Name = "label1";
			label1.Size = new Size(45, 16);
			label1.TabIndex = 0;
			label1.Text = "label1";
			//
			// Message
			//
			AutoScaleBaseSize = new Size(5, 13);
			BackColor = SystemColors.AppWorkspace;
			ClientSize = new Size(542, 72);
			ControlBox = false;
			Controls.Add(panel1);
			Controls.Add(panel2);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Icon = ((Icon)(resources.GetObject("$this.Icon")));
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "Message";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Message";
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		public static DialogResult Show(string message)
		{
			return Show(message, null, MessageBoxButtons.OK);
		}

		public static DialogResult Show(
			string message,
			string caption,
			MessageBoxButtons mbb
		)
		{
			bool run = WaitingScreen.Running;
			bool spl = Splash.Running;
			if (run)
			{
				WaitingScreen.Stop();
			}

			if (spl)
			{
				Splash.Screen.Stop();
			}

			try
			{
				caption = Localization.GetString(caption);
				Message m = new Message();
				if (mbb == MessageBoxButtons.YesNoCancel)
				{
					m.AddButton(
						Localization.Manager.GetString("cancel"),
						DialogResult.Cancel
					);
					m.AddButton(
						Localization.Manager.GetString("no"),
						DialogResult.No
					);
					m.AddButton(
						Localization.Manager.GetString("yes"),
						DialogResult.Yes
					);
				}
				else if (mbb == MessageBoxButtons.OKCancel)
				{
					m.AddButton(
						Localization.Manager.GetString("cancel"),
						DialogResult.Cancel
					);
					m.AddButton(
						Localization.Manager.GetString("ok"),
						DialogResult.OK
					);
				}
				else if (mbb == MessageBoxButtons.YesNo)
				{
					m.AddButton(
						Localization.Manager.GetString("no"),
						DialogResult.No
					);
					m.AddButton(
						Localization.Manager.GetString("yes"),
						DialogResult.Yes
					);
				}
				else
				{
					m.AddButton(
						Localization.Manager.GetString("ok"),
						DialogResult.OK
					);
				}

				if (caption != null)
				{
					m.Text = caption;
				}

				m.label1.AutoSize = true;
				m.panel1.Width = m.ClientRectangle.Width;
				m.panel2.Width = m.panel1.Width;
				m.label1.Width = m.panel2.Width - (2 * m.label1.Left);
				m.label1.Text = message;

				string text = m.label1.Text;
				Font textFont = m.label1.Font;

				//Specify a fixed width, but let the height be "unlimited"
				SizeF layoutSize = new SizeF(m.label1.Width, 5000.0F);
				Graphics g = Graphics.FromHwnd(m.label1.Handle);
				SizeF stringSize = g.MeasureString(text, textFont, layoutSize);
				g.Dispose();
				m.label1.Height = (int)stringSize.Height;
				int newsize = m.label1.Height + 10 + (2 * m.label1.Top);

				m.panel2.Height = newsize;
				m.panel1.Top = m.panel2.Height;

				m.Height =
					m.panel2.Height
					+ m.panel1.Height
					+ SystemInformation.CaptionHeight;

				ThemeManager.Global.Theme(m.panel2);
				m.panel1.BackColor = ThemeManager.Global.ThemeColorDark;

				m.ShowDialog();

				return m.DialogResult;
			}
			catch
			{
				return MessageBox.Show(message, caption, mbb);
			}
			finally
			{
				if (run)
				{
					WaitingScreen.Wait();
				}

				if (spl)
				{
					Splash.Screen.SetMessage("");
				}
			}
		}

		void AddButton(string caption, DialogResult dr)
		{
			Button bn = new Button
			{
				Parent = panel1
			};
			int pos = (int)panel1.Tag;
			panel1.Tag = pos + 1;

			bn.Left = panel1.Width - (bn.Width + 8) * pos;
			bn.Top = 8;
			bn.FlatStyle = FlatStyle.System;

			bn.Text = caption;
			bn.DialogResult = dr;

			bn.Click += new EventHandler(ButtonClick);
		}

		private void ButtonClick(object sender, EventArgs e)
		{
			DialogResult = ((Button)sender).DialogResult;
			Close();
		}
	}
}
