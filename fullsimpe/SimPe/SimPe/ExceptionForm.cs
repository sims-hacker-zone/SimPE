using System;
using System.Windows.Forms;

namespace SimPe
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
				new System.ComponentModel.ComponentResourceManager(
					typeof(ExceptionForm)
				);
			this.lberr = new Label();
			this.gbdetail = new GroupBox();
			this.rtb = new RichTextBox();
			this.linkLabel1 = new LinkLabel();
			this.pictureBox1 = new PictureBox();
			this.lldetail = new LinkLabel();
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.linkLabel2 = new LinkLabel();
			this.panel3 = new Panel();
			this.button1 = new Button();
			this.tbsup = new TextBox();
			this.gbdetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			//
			// lberr
			//
			resources.ApplyResources(this.lberr, "lberr");
			this.lberr.BackColor = System.Drawing.Color.Transparent;
			this.lberr.ForeColor = System.Drawing.Color.Black;
			this.lberr.Name = "lberr";
			//
			// gbdetail
			//
			resources.ApplyResources(this.gbdetail, "gbdetail");
			this.gbdetail.Controls.Add(this.rtb);
			this.gbdetail.Controls.Add(this.linkLabel1);
			this.gbdetail.FlatStyle = FlatStyle.System;
			this.gbdetail.Name = "gbdetail";
			this.gbdetail.TabStop = false;
			//
			// rtb
			//
			resources.ApplyResources(this.rtb, "rtb");
			this.rtb.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.rtb.BorderStyle = BorderStyle.None;
			this.rtb.ForeColor = System.Drawing.Color.FromArgb(
				((int)(((byte)(64)))),
				((int)(((byte)(64)))),
				((int)(((byte)(64))))
			);
			this.rtb.Name = "rtb";
			this.rtb.ReadOnly = true;
			//
			// linkLabel1
			//
			resources.ApplyResources(this.linkLabel1, "linkLabel1");
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabStop = true;
			this.linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.CopyToClipboard
				);
			//
			// pictureBox1
			//
			resources.ApplyResources(this.pictureBox1, "pictureBox1");
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.TabStop = false;
			//
			// lldetail
			//
			resources.ApplyResources(this.lldetail, "lldetail");
			this.lldetail.Name = "lldetail";
			this.lldetail.TabStop = true;
			this.lldetail.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.ShowDetail
				);
			//
			// panel1
			//
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.lberr);
			this.panel1.Controls.Add(this.lldetail);
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Name = "panel1";
			//
			// panel2
			//
			this.panel2.Controls.Add(this.linkLabel2);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Controls.Add(this.tbsup);
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.Name = "panel2";
			//
			// linkLabel2
			//
			resources.ApplyResources(this.linkLabel2, "linkLabel2");
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.TabStop = true;
			this.linkLabel2.UseCompatibleTextRendering = true;
			this.linkLabel2.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(this.Support);
			//
			// panel3
			//
			this.panel3.BackColor = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.panel3, "panel3");
			this.panel3.Name = "panel3";
			//
			// button1
			//
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.Click += new EventHandler(this.button1_Click);
			//
			// tbsup
			//
			resources.ApplyResources(this.tbsup, "tbsup");
			this.tbsup.Name = "tbsup";
			//
			// ExceptionForm
			//
			resources.ApplyResources(this, "$this");
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.gbdetail);
			this.FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			this.Name = "ExceptionForm";
			this.gbdetail.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
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
				Help.ShowHelp(this, this.tbsup.Text);
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
			this.Location = new System.Drawing.Point(
				this.Location.X - 168,
				this.Location.Y - 186
			);
			this.Size = new System.Drawing.Size(800, 600);
			this.Refresh();
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
