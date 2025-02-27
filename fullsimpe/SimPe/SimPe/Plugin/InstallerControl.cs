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
			pndrop = new Panel();
			pb = new PictureBox();
			tbs = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			lbType = new Label();
			label6 = new Label();
			lbGuid = new Label();
			label4 = new Label();
			lbVert = new Label();
			label5 = new Label();
			lbCat = new Label();
			label1 = new Label();
			rtb = new RichTextBox();
			cb = new ComboBox();
			lbPrice = new Label();
			label3 = new Label();
			lbFace = new Label();
			label7 = new Label();
			llOptions = new LinkLabel();
			pndrop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(pb)).BeginInit();
			tbs.SuspendLayout();
			SuspendLayout();
			//
			// pndrop
			//
			pndrop.AllowDrop = true;
			pndrop.BackColor = Color.Transparent;
			pndrop.Controls.Add(pb);
			resources.ApplyResources(pndrop, "pndrop");
			pndrop.Name = "pndrop";
			pndrop.DragDrop += new DragEventHandler(
				DragDropFile
			);
			pndrop.DragEnter += new DragEventHandler(
				DragEnterFile
			);
			//
			// pb
			//
			resources.ApplyResources(pb, "pb");
			pb.Name = "pb";
			pb.TabStop = false;
			//
			// tbs
			//
			resources.ApplyResources(tbs, "tbs");
			tbs.BackColor = Color.Transparent;
			tbs.BodyColor = SystemColors.Window;
			tbs.BorderColor = SystemColors.Window;
			tbs.Controls.Add(lbType);
			tbs.Controls.Add(label6);
			tbs.Controls.Add(lbGuid);
			tbs.Controls.Add(label4);
			tbs.Controls.Add(lbVert);
			tbs.Controls.Add(label5);
			tbs.Controls.Add(lbCat);
			tbs.Controls.Add(label1);
			tbs.Controls.Add(rtb);
			tbs.Controls.Add(cb);
			tbs.Controls.Add(lbPrice);
			tbs.Controls.Add(label3);
			tbs.Controls.Add(lbFace);
			tbs.Controls.Add(label7);
			tbs.HeaderFont = new Font(
				"Microsoft Sans Serif",
				10.25F,
				FontStyle.Bold
			);
			tbs.HeaderTextColor = SystemColors.ActiveCaptionText;
			tbs.IconLocation = new Point(4, 12);
			tbs.IconSize = new Size(32, 32);
			tbs.LeftHeaderColor = Color.Transparent;
			tbs.Name = "tbs";
			tbs.RightHeaderColor = Color.Transparent;
			//
			// lbType
			//
			lbType.BackColor = Color.Transparent;
			resources.ApplyResources(lbType, "lbType");
			lbType.Name = "lbType";
			//
			// label6
			//
			label6.BackColor = Color.Transparent;
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			//
			// lbGuid
			//
			lbGuid.BackColor = Color.Transparent;
			resources.ApplyResources(lbGuid, "lbGuid");
			lbGuid.Name = "lbGuid";
			//
			// label4
			//
			label4.BackColor = Color.Transparent;
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// lbVert
			//
			lbVert.BackColor = Color.Transparent;
			resources.ApplyResources(lbVert, "lbVert");
			lbVert.Name = "lbVert";
			//
			// label5
			//
			label5.BackColor = Color.Transparent;
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			//
			// lbCat
			//
			lbCat.BackColor = Color.Transparent;
			resources.ApplyResources(lbCat, "lbCat");
			lbCat.Name = "lbCat";
			//
			// label1
			//
			label1.BackColor = Color.Transparent;
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// rtb
			//
			resources.ApplyResources(rtb, "rtb");
			rtb.BackColor = SystemColors.Window;
			rtb.BorderStyle = BorderStyle.None;
			rtb.Name = "rtb";
			rtb.ReadOnly = true;
			//
			// cb
			//
			resources.ApplyResources(cb, "cb");
			cb.DropDownStyle = ComboBoxStyle.DropDownList;
			cb.Name = "cb";
			cb.SelectedIndexChanged += new EventHandler(SelectedInfo);
			//
			// lbPrice
			//
			lbPrice.BackColor = Color.Transparent;
			resources.ApplyResources(lbPrice, "lbPrice");
			lbPrice.Name = "lbPrice";
			//
			// label3
			//
			label3.BackColor = Color.Transparent;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// lbFace
			//
			lbFace.BackColor = Color.Transparent;
			resources.ApplyResources(lbFace, "lbFace");
			lbFace.Name = "lbFace";
			//
			// label7
			//
			label7.BackColor = Color.Transparent;
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			//
			// llOptions
			//
			llOptions.ActiveLinkColor = Color.LightCoral;
			resources.ApplyResources(llOptions, "llOptions");
			llOptions.BackColor = Color.Transparent;
			llOptions.LinkColor = Color.FromArgb(
				((byte)(224)),
				((byte)(224)),
				((byte)(224))
			);
			llOptions.Name = "llOptions";
			llOptions.TabStop = true;
			llOptions.VisitedLinkColor = Color.Silver;
			llOptions.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					ShowOptions
				);
			//
			// InstallerControl
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(llOptions);
			Controls.Add(pndrop);
			Controls.Add(tbs);
			ForeColor = SystemColors.ControlText;
			Name = "InstallerControl";
			pndrop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(pb)).EndInit();
			tbs.ResumeLayout(false);
			ResumeLayout(false);
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

			cb.Items.Clear();
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
			tbs.HeaderText = "";
			rtb.Text = "";
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
