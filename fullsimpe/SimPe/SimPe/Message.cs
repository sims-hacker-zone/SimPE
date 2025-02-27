using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe
{
	/// <summary>
	/// Summary description for Message.
	/// </summary>
	public class Message : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
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
				new System.ComponentModel.ComponentResourceManager(typeof(Message));
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new SteepValley.Windows.Forms.XPGradientPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			//
			// panel1
			//
			this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
			this.panel1.Location = new System.Drawing.Point(0, 32);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(548, 40);
			this.panel1.TabIndex = 0;
			//
			// panel2
			//
			this.panel2.BackColor = System.Drawing.Color.Transparent;
			this.panel2.Controls.Add(this.label1);
			this.panel2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(548, 32);
			this.panel2.TabIndex = 1;
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.MaximumSize = new System.Drawing.Size(524, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			//
			// Message
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.ClientSize = new System.Drawing.Size(542, 72);
			this.ControlBox = false;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Message";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Message";
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
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
				caption = SimPe.Localization.GetString(caption);
				Message m = new Message();
				if (mbb == MessageBoxButtons.YesNoCancel)
				{
					m.AddButton(
						SimPe.Localization.Manager.GetString("cancel"),
						DialogResult.Cancel
					);
					m.AddButton(
						SimPe.Localization.Manager.GetString("no"),
						DialogResult.No
					);
					m.AddButton(
						SimPe.Localization.Manager.GetString("yes"),
						DialogResult.Yes
					);
				}
				else if (mbb == MessageBoxButtons.OKCancel)
				{
					m.AddButton(
						SimPe.Localization.Manager.GetString("cancel"),
						DialogResult.Cancel
					);
					m.AddButton(
						SimPe.Localization.Manager.GetString("ok"),
						DialogResult.OK
					);
				}
				else if (mbb == MessageBoxButtons.YesNo)
				{
					m.AddButton(
						SimPe.Localization.Manager.GetString("no"),
						DialogResult.No
					);
					m.AddButton(
						SimPe.Localization.Manager.GetString("yes"),
						DialogResult.Yes
					);
				}
				else
				{
					m.AddButton(
						SimPe.Localization.Manager.GetString("ok"),
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
					+ System.Windows.Forms.SystemInformation.CaptionHeight;

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
			Button bn = new Button();
			bn.Parent = this.panel1;
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
			this.DialogResult = ((Button)sender).DialogResult;
			Close();
		}
	}
}
