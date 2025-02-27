using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for InstallerControl.
	/// </summary>
	public class InstallerControl : UserControl
	{
		private Panel pndrop;
		private PictureBox pb;
		Ambertation.Windows.Forms.XPTaskBoxSimple tbs;
		private ComboBox cb;
		private RichTextBox rtb;
		private Label lbCat;
		private Label label1;
		private Label lbFace;
		private Label label7;
		private Label lbVert;
		private Label label5;
		private Label lbPrice;
		private Label label3;
		private Label lbGuid;
		private Label label4;
		private Label label6;
		private Label lbType;
		private LinkLabel llOptions;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InstallerControl()
		{
			// Required designer variable.
			InitializeComponent();

			Clear();
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
					typeof(InstallerControl)
				);
			this.pndrop = new Panel();
			this.pb = new PictureBox();
			this.tbs = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			this.lbType = new Label();
			this.label6 = new Label();
			this.lbGuid = new Label();
			this.label4 = new Label();
			this.lbVert = new Label();
			this.label5 = new Label();
			this.lbCat = new Label();
			this.label1 = new Label();
			this.rtb = new RichTextBox();
			this.cb = new ComboBox();
			this.lbPrice = new Label();
			this.label3 = new Label();
			this.lbFace = new Label();
			this.label7 = new Label();
			this.llOptions = new LinkLabel();
			this.pndrop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
			this.tbs.SuspendLayout();
			this.SuspendLayout();
			//
			// pndrop
			//
			this.pndrop.AllowDrop = true;
			this.pndrop.BackColor = Color.Transparent;
			this.pndrop.Controls.Add(this.pb);
			resources.ApplyResources(this.pndrop, "pndrop");
			this.pndrop.Name = "pndrop";
			this.pndrop.DragDrop += new DragEventHandler(
				this.DragDropFile
			);
			this.pndrop.DragEnter += new DragEventHandler(
				this.DragEnterFile
			);
			//
			// pb
			//
			resources.ApplyResources(this.pb, "pb");
			this.pb.Name = "pb";
			this.pb.TabStop = false;
			//
			// tbs
			//
			resources.ApplyResources(this.tbs, "tbs");
			this.tbs.BackColor = Color.Transparent;
			this.tbs.BodyColor = SystemColors.Window;
			this.tbs.BorderColor = SystemColors.Window;
			this.tbs.Controls.Add(this.lbType);
			this.tbs.Controls.Add(this.label6);
			this.tbs.Controls.Add(this.lbGuid);
			this.tbs.Controls.Add(this.label4);
			this.tbs.Controls.Add(this.lbVert);
			this.tbs.Controls.Add(this.label5);
			this.tbs.Controls.Add(this.lbCat);
			this.tbs.Controls.Add(this.label1);
			this.tbs.Controls.Add(this.rtb);
			this.tbs.Controls.Add(this.cb);
			this.tbs.Controls.Add(this.lbPrice);
			this.tbs.Controls.Add(this.label3);
			this.tbs.Controls.Add(this.lbFace);
			this.tbs.Controls.Add(this.label7);
			this.tbs.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				FontStyle.Bold
			);
			this.tbs.HeaderTextColor = SystemColors.ActiveCaptionText;
			this.tbs.IconLocation = new Point(4, 12);
			this.tbs.IconSize = new Size(32, 32);
			this.tbs.LeftHeaderColor = Color.Transparent;
			this.tbs.Name = "tbs";
			this.tbs.RightHeaderColor = Color.Transparent;
			//
			// lbType
			//
			this.lbType.BackColor = Color.Transparent;
			resources.ApplyResources(this.lbType, "lbType");
			this.lbType.Name = "lbType";
			//
			// label6
			//
			this.label6.BackColor = Color.Transparent;
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			//
			// lbGuid
			//
			this.lbGuid.BackColor = Color.Transparent;
			resources.ApplyResources(this.lbGuid, "lbGuid");
			this.lbGuid.Name = "lbGuid";
			//
			// label4
			//
			this.label4.BackColor = Color.Transparent;
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			//
			// lbVert
			//
			this.lbVert.BackColor = Color.Transparent;
			resources.ApplyResources(this.lbVert, "lbVert");
			this.lbVert.Name = "lbVert";
			//
			// label5
			//
			this.label5.BackColor = Color.Transparent;
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			//
			// lbCat
			//
			this.lbCat.BackColor = Color.Transparent;
			resources.ApplyResources(this.lbCat, "lbCat");
			this.lbCat.Name = "lbCat";
			//
			// label1
			//
			this.label1.BackColor = Color.Transparent;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// rtb
			//
			resources.ApplyResources(this.rtb, "rtb");
			this.rtb.BackColor = SystemColors.Window;
			this.rtb.BorderStyle = BorderStyle.None;
			this.rtb.Name = "rtb";
			this.rtb.ReadOnly = true;
			//
			// cb
			//
			resources.ApplyResources(this.cb, "cb");
			this.cb.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cb.Name = "cb";
			this.cb.SelectedIndexChanged += new EventHandler(this.SelectedInfo);
			//
			// lbPrice
			//
			this.lbPrice.BackColor = Color.Transparent;
			resources.ApplyResources(this.lbPrice, "lbPrice");
			this.lbPrice.Name = "lbPrice";
			//
			// label3
			//
			this.label3.BackColor = Color.Transparent;
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			//
			// lbFace
			//
			this.lbFace.BackColor = Color.Transparent;
			resources.ApplyResources(this.lbFace, "lbFace");
			this.lbFace.Name = "lbFace";
			//
			// label7
			//
			this.label7.BackColor = Color.Transparent;
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			//
			// llOptions
			//
			this.llOptions.ActiveLinkColor = Color.LightCoral;
			resources.ApplyResources(this.llOptions, "llOptions");
			this.llOptions.BackColor = Color.Transparent;
			this.llOptions.LinkColor = Color.FromArgb(
				((int)(((byte)(224)))),
				((int)(((byte)(224)))),
				((int)(((byte)(224))))
			);
			this.llOptions.Name = "llOptions";
			this.llOptions.TabStop = true;
			this.llOptions.VisitedLinkColor = Color.Silver;
			this.llOptions.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.ShowOptions
				);
			//
			// InstallerControl
			//
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.llOptions);
			this.Controls.Add(this.pndrop);
			this.Controls.Add(this.tbs);
			this.ForeColor = SystemColors.ControlText;
			this.Name = "InstallerControl";
			this.pndrop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
			this.tbs.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		public static void Cleanup()
		{
			DownloadsToolFactory.TeleportFileIndex.CloseAssignedPackages();
			Packages.StreamFactory.CleanupTeleport();
		}

		public void LoadFiles(string[] files)
		{
			Wait.Start(files.Length);
			foreach (Downloads.IPackageInfo nfo in cb.Items)
			{
				nfo.Dispose();
			}

			this.cb.Items.Clear();
			Cleanup();

			int ct = 0;
			foreach (string file in files)
			{
				Wait.Progress = ct++;
				Downloads.IPackageHandler hnd =
					Downloads.HandlerRegistry.Global.LoadFileHandler(file);
				if (hnd != null)
				{
					foreach (Downloads.IPackageInfo nfo in hnd.Objects)
					{
						cb.Items.Add(nfo);
					}
				}
				hnd.FreeResources();
			}
			if (cb.Items.Count > 0)
			{
				cb.SelectedIndex = 0;
			}

			Wait.Stop();
		}

		#region Drag&Drop

		/// <summary>
		/// Returns the Names of the Dropped Files
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		string[] DragDropNames(DragEventArgs e)
		{
			Array a = (Array)e.Data.GetData(DataFormats.FileDrop);

			if (a != null)
			{
				string[] res = new string[a.Length];
				for (int i = 0; i < a.Length; i++)
				{
					res[i] = a.GetValue(i).ToString();
				}

				return res;
			}

			return new string[0];
		}

		/// <summary>
		/// Returns the Effect that should be displayed based on the Files
		/// </summary>
		/// <param name="flname"></param>
		/// <returns></returns>
		DragDropEffects DragDropEffect(string[] names)
		{
			foreach (string name in names)
			{
				if (Downloads.HandlerRegistry.Global.HasFileHandler(name))
				{
					return DragDropEffects.Copy;
				}
			}

			return DragDropEffects.None;
		}

		/// <summary>
		/// Someone tries to throw a File
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DragEnterFile(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				try
				{
					e.Effect = DragDropEffect(DragDropNames(e));
				}
				catch (Exception) { }
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		/// <summary>
		/// A File has been dropped
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DragDropFile(object sender, DragEventArgs e)
		{
			try
			{
				string[] files = DragDropNames(e);
				LoadFiles(files);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}
		#endregion

		protected void Clear()
		{
			pb.Image = null;
			this.tbs.HeaderText = "";
			this.rtb.Text = "";
			lbCat.Text = "";
			lbPrice.Text = "";
			lbVert.Text = "0";
			lbFace.Text = "0";
			lbGuid.Text = "";
			lbType.Text = "";
		}

		protected Downloads.IPackageInfo SelectedPackageInfo => cb.SelectedItem as Downloads.IPackageInfo;

		private void SelectedInfo(object sender, EventArgs e)
		{
			SelectedInfo(SelectedPackageInfo);
		}

		private void ShowOptions(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			RemoteControl.ShowCustomSettings(
				DownloadsToolFactory.Settings
			);
		}

		protected void SelectedInfo(Downloads.IPackageInfo nfo)
		{
			Clear();
			if (nfo != null)
			{
				nfo.CreatePostponed3DPreview();
				if (nfo.Image != null)
				{
					pb.Image = nfo.GetThumbnail();
				}

				tbs.HeaderText = nfo.Name;
				rtb.Text = nfo.Description;
				lbCat.Text = nfo.Category;
				lbPrice.Text = "$" + nfo.Price.ToString();
				lbVert.Text = nfo.VertexCount.ToString();
				lbFace.Text = nfo.FaceCount.ToString();
				lbGuid.Text = "";
				lbType.Text = nfo.Type.ToString();
				foreach (uint guid in nfo.Guids)
				{
					lbGuid.Text += "0x" + Helper.HexString(guid) + " ";
				}

				lbVert.ForeColor = Color.Black;
				if (nfo.HighVertexCount)
				{
					lbVert.ForeColor = Color.Red;
				}

				lbFace.ForeColor = Color.Black;
				if (nfo.HighFaceCount)
				{
					lbFace.ForeColor = Color.Red;
				}
			}
		}
	}
}
