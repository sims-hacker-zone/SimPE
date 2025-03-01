// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Summary description for ObjectPreview.
	/// </summary>
	public class NeighborhoodPreview : UserControl
	{
		private Label label1;
		private Label label3;
		private Label lbName;
		private PictureBox pb;
		private Label lbAbout;
		private Label label2;
		private Label lbPop;
		private Label label4;
		private Label lbUni;
		private Label label5;
		private Label lbVer;
		private Label lbType;
		private Label label6;
		private Label label7;
		private Label lbholi;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public NeighborhoodPreview()
		{
			SetStyle(
				ControlStyles.SupportsTransparentBackColor
					| ControlStyles.AllPaintingInWmPaint
					|
					//ControlStyles.Opaque |
					ControlStyles.UserPaint
					| ControlStyles.ResizeRedraw
					| ControlStyles.DoubleBuffer,
				true
			);

			BackColor = Color.Transparent;
			Loaded = false;

			// Required designer variable.
			InitializeComponent();

			BuildDefaultImage();
			ClearScreen();
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
			ComponentResourceManager resources =
				new ComponentResourceManager(
					typeof(NeighborhoodPreview)
				);
			pb = new PictureBox();
			label1 = new Label();
			label3 = new Label();
			lbName = new Label();
			lbAbout = new Label();
			label2 = new Label();
			lbPop = new Label();
			label4 = new Label();
			lbUni = new Label();
			label5 = new Label();
			lbVer = new Label();
			lbType = new Label();
			label6 = new Label();
			label7 = new Label();
			lbholi = new Label();
			((ISupportInitialize)pb).BeginInit();
			SuspendLayout();
			//
			// pb
			//
			pb.BackColor = Color.Transparent;
			resources.ApplyResources(pb, "pb");
			pb.Name = "pb";
			pb.TabStop = false;
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// lbName
			//
			resources.ApplyResources(lbName, "lbName");
			lbName.Name = "lbName";
			//
			// lbAbout
			//
			resources.ApplyResources(lbAbout, "lbAbout");
			lbAbout.MaximumSize = new Size(800, 0);
			lbAbout.Name = "lbAbout";
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// lbPop
			//
			resources.ApplyResources(lbPop, "lbPop");
			lbPop.Name = "lbPop";
			//
			// label4
			//
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// lbUni
			//
			resources.ApplyResources(lbUni, "lbUni");
			lbUni.Name = "lbUni";
			//
			// label5
			//
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			//
			// lbVer
			//
			resources.ApplyResources(lbVer, "lbVer");
			lbVer.Name = "lbVer";
			//
			// lbType
			//
			resources.ApplyResources(lbType, "lbType");
			lbType.Name = "lbType";
			//
			// label6
			//
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			//
			// label7
			//
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			//
			// lbholi
			//
			resources.ApplyResources(lbholi, "lbholi");
			lbholi.Name = "lbholi";
			//
			// NeighborhoodPreview
			//
			BackColor = Color.Transparent;
			resources.ApplyResources(this, "$this");
			Controls.Add(lbholi);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(pb);
			Controls.Add(lbType);
			Controls.Add(lbVer);
			Controls.Add(label5);
			Controls.Add(lbUni);
			Controls.Add(label4);
			Controls.Add(lbPop);
			Controls.Add(lbAbout);
			Controls.Add(lbName);
			Controls.Add(label1);
			Controls.Add(label2);
			Controls.Add(label3);
			DoubleBuffered = true;
			Name = "NeighborhoodPreview";
			((ISupportInitialize)pb).EndInit();
			ResumeLayout(false);
		}
		#endregion

		#region Public Properties


		[Browsable(false)]
		public bool Loaded
		{
			get; private set;
		}

		[Browsable(false)]
		public Interfaces.Files.IPackageFile Package
		{
			get; private set;
		}
		#endregion




		protected void ClearScreen()
		{
			label5.Visible = Helper.WindowsRegistry.HiddenMode;
			lbVer.Visible = Helper.WindowsRegistry.HiddenMode;

			if (CatalogDescription != null)
			{
				ctss.ChangedData -= new Events.PackedFileChanged(
					ctss_ChangedUserData
				);
				ctss = null;
			}
			pb.Image = defimg;
			lbAbout.Text = "";
			lbName.Text = "";
			lbPop.Text = "???";
			lbUni.Text = "???";
			lbholi.Text = "???";
		}

		public void SetFromPackage(Interfaces.Files.IPackageFile pkg)
		{
			Loaded = false;
			ClearScreen();
			Package = pkg;
			if (pkg == null)
			{
				return;
			}

			if (!Helper.IsNeighborhoodFile(pkg.FileName))
			{
				return;
			}

			Loaded = true;

			try
			{
				PackedFiles.Wrapper.StrItemList strs = GetCtssItems();
				if (strs != null)
				{
					if (strs.Count > 0)
					{
						lbName.Text = strs[0].Title;
					}

					if (strs.Count > 1)
					{
						lbAbout.Text = strs[1].Title;
					}
				}

				string tname = System.IO.Path.Combine(
					System.IO.Path.GetDirectoryName(pkg.FileName),
					System.IO.Path.GetFileNameWithoutExtension(pkg.FileName) + ".png"
				);
				pb.Image = null;
				if (System.IO.File.Exists(tname))
				{
					try
					{
						pb.Image = SimpleObjectPreview.GenerateImage(
							pb.Size,
							Image.FromFile(tname),
							false
						);
					}
					catch { }
				}

				if (pb.Image == null)
				{
					pb.Image = defimg;
				}

				Idno idno = Idno.FromPackage(pkg);
				if (idno != null)
				{
					if (idno.Type == NeighborhoodType.Normal)
					{
						label2.Visible = true;
						lbPop.Visible = true;
						lbPop.Text = pkg.FindFiles(Data.MetaData.SIM_DESCRIPTION_FILE)
							.Length.ToString();
					}
					else
					{
						label2.Visible = false;
						lbPop.Visible = false;
					}

					if (
						idno.Type == NeighborhoodType.Normal
						|| (
							idno.Type == NeighborhoodType.Suburb
							&& (
								idno.Subep == Data.MetaData.NeighbourhoodEP.Business
								|| idno.Subep
									== Data.MetaData.NeighbourhoodEP.MansionGarden
							)
						)
					)
					{
						label4.Visible = true;
						label7.Visible = true;
						lbUni.Visible = true;
						lbholi.Visible = true;
						lbUni.Text = System
							.IO.Directory.GetFiles(
								System.IO.Path.GetDirectoryName(pkg.FileName),
								"*_University*.package"
							)
							.Length.ToString();
						lbholi.Text = System
							.IO.Directory.GetFiles(
								System.IO.Path.GetDirectoryName(pkg.FileName),
								"*_Vacation*.package"
							)
							.Length.ToString();
					}
					else
					{
						label4.Visible = false;
						label7.Visible = false;
						lbUni.Visible = false;
						lbholi.Visible = false;
					}

					lbType.Text = idno.Type == NeighborhoodType.Suburb
						&& idno.Subep != Data.MetaData.NeighbourhoodEP.Business
						? "Hidden " + idno.Type.ToString().Replace("_", " ")
						: idno.Type.ToString().Replace("_", " ");

					if (Helper.WindowsRegistry.HiddenMode)
					{
						ShowVersion();
					}
				}
				else
				{
					label2.Visible = false;
					label4.Visible = false;
					label7.Visible = false;
					lbPop.Visible = false;
					lbUni.Visible = false;
					lbholi.Visible = false;
					if (pkg.FileName.Contains("Tutorial"))
					{
						lbType.Text = "Tutorial Neighbourhood";
						lbVer.Text = "Every EP";
						lbName.Text = "Tutorial";
						lbAbout.Text =
							"This neighbourhood is for you to learn with, don't make changes here but in game you may do whatever you like.";
					}
					else
					{
						lbType.Text =
							NeighborhoodType.Unknown.ToString();
						lbVer.Text =
							NeighborhoodVersion.Unknown.ToString();
					}
				}
			}
			catch (Exception ex)
			{
				lbAbout.Text = ex.Message;
			}
		}

		Interfaces.Files.IPackedFileDescriptor ctss;
		protected Interfaces.Files.IPackedFileDescriptor CatalogDescription
		{
			get
			{
				if (Package == null)
				{
					return null;
				}

				if (ctss == null)
				{
					ctss = Package.FindFile(
						Data.MetaData.CTSS_FILE,
						0,
						Data.MetaData.LOCAL_GROUP,
						1
					);
				}

				return ctss;
			}
		}

		protected void ShowVersion()
		{
			Idno idno = Idno.FromPackage(Package);
			lbVer.Text = idno != null ? idno.Version.ToString().Replace("_", " ") : NeighborhoodVersion.Unknown.ToString();
		}

		protected PackedFiles.Wrapper.StrItemList GetCtssItems()
		{
			//Get the Name of the Object
			Interfaces.Files.IPackedFileDescriptor ctss = CatalogDescription;
			if (ctss != null)
			{
				ctss.ChangedData += new Events.PackedFileChanged(
					ctss_ChangedUserData
				);
				PackedFiles.Wrapper.Str str = new PackedFiles.Wrapper.Str();
				str.ProcessData(ctss, Package);

				return str.LanguageItems(Helper.WindowsRegistry.LanguageCode);
			}
			return null;
		}

		Image defimg;

		protected void BuildDefaultImage()
		{
			defimg = GetImage.Demo;
		}

		private void ctss_ChangedUserData(
			Interfaces.Files.IPackedFileDescriptor sender
		)
		{
			SetFromPackage(Package);
		}
	}
}
