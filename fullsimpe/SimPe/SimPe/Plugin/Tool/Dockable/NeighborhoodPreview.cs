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
			ComponentResourceManager resources =
				new ComponentResourceManager(
					typeof(NeighborhoodPreview)
				);
			this.pb = new PictureBox();
			this.label1 = new Label();
			this.label3 = new Label();
			this.lbName = new Label();
			this.lbAbout = new Label();
			this.label2 = new Label();
			this.lbPop = new Label();
			this.label4 = new Label();
			this.lbUni = new Label();
			this.label5 = new Label();
			this.lbVer = new Label();
			this.lbType = new Label();
			this.label6 = new Label();
			this.label7 = new Label();
			this.lbholi = new Label();
			((ISupportInitialize)(this.pb)).BeginInit();
			this.SuspendLayout();
			//
			// pb
			//
			this.pb.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.pb, "pb");
			this.pb.Name = "pb";
			this.pb.TabStop = false;
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// label3
			//
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			//
			// lbName
			//
			resources.ApplyResources(this.lbName, "lbName");
			this.lbName.Name = "lbName";
			//
			// lbAbout
			//
			resources.ApplyResources(this.lbAbout, "lbAbout");
			this.lbAbout.MaximumSize = new Size(800, 0);
			this.lbAbout.Name = "lbAbout";
			//
			// label2
			//
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			//
			// lbPop
			//
			resources.ApplyResources(this.lbPop, "lbPop");
			this.lbPop.Name = "lbPop";
			//
			// label4
			//
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			//
			// lbUni
			//
			resources.ApplyResources(this.lbUni, "lbUni");
			this.lbUni.Name = "lbUni";
			//
			// label5
			//
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			//
			// lbVer
			//
			resources.ApplyResources(this.lbVer, "lbVer");
			this.lbVer.Name = "lbVer";
			//
			// lbType
			//
			resources.ApplyResources(this.lbType, "lbType");
			this.lbType.Name = "lbType";
			//
			// label6
			//
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			//
			// label7
			//
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			//
			// lbholi
			//
			resources.ApplyResources(this.lbholi, "lbholi");
			this.lbholi.Name = "lbholi";
			//
			// NeighborhoodPreview
			//
			this.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.lbholi);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.pb);
			this.Controls.Add(this.lbType);
			this.Controls.Add(this.lbVer);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lbUni);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lbPop);
			this.Controls.Add(this.lbAbout);
			this.Controls.Add(this.lbName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.DoubleBuffered = true;
			this.Name = "NeighborhoodPreview";
			((ISupportInitialize)(this.pb)).EndInit();
			this.ResumeLayout(false);
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

			if (this.CatalogDescription != null)
			{
				ctss.ChangedData -= new Events.PackedFileChanged(
					ctss_ChangedUserData
				);
				ctss = null;
			}
			pb.Image = defimg;
			this.lbAbout.Text = "";
			this.lbName.Text = "";
			this.lbPop.Text = "???";
			this.lbUni.Text = "???";
			this.lbholi.Text = "???";
		}

		public void SetFromPackage(Interfaces.Files.IPackageFile pkg)
		{
			Loaded = false;
			ClearScreen();
			this.Package = pkg;
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
						this.lbName.Text = strs[0].Title;
					}

					if (strs.Count > 1)
					{
						this.lbAbout.Text = strs[1].Title;
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
						pb.Image = ObjectPreview.GenerateImage(
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

				Idno idno = SimPe.Plugin.Idno.FromPackage(pkg);
				if (idno != null)
				{
					if (idno.Type == SimPe.Plugin.NeighborhoodType.Normal)
					{
						this.label2.Visible = true;
						this.lbPop.Visible = true;
						lbPop.Text = pkg.FindFiles(Data.MetaData.SIM_DESCRIPTION_FILE)
							.Length.ToString();
					}
					else
					{
						this.label2.Visible = false;
						this.lbPop.Visible = false;
					}

					if (
						idno.Type == SimPe.Plugin.NeighborhoodType.Normal
						|| (
							idno.Type == SimPe.Plugin.NeighborhoodType.Suburb
							&& (
								idno.Subep == Data.MetaData.NeighbourhoodEP.Business
								|| idno.Subep
									== Data.MetaData.NeighbourhoodEP.MansionGarden
							)
						)
					)
					{
						this.label4.Visible = true;
						this.label7.Visible = true;
						this.lbUni.Visible = true;
						this.lbholi.Visible = true;
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
						this.label4.Visible = false;
						this.label7.Visible = false;
						this.lbUni.Visible = false;
						this.lbholi.Visible = false;
					}

					if (
						idno.Type == SimPe.Plugin.NeighborhoodType.Suburb
						&& idno.Subep != Data.MetaData.NeighbourhoodEP.Business
					)
					{
						this.lbType.Text =
							"Hidden " + idno.Type.ToString().Replace("_", " ");
					}
					else
					{
						this.lbType.Text = idno.Type.ToString().Replace("_", " ");
					}

					if (Helper.WindowsRegistry.HiddenMode)
					{
						ShowVersion();
					}
				}
				else
				{
					this.label2.Visible = false;
					this.label4.Visible = false;
					this.label7.Visible = false;
					this.lbPop.Visible = false;
					this.lbUni.Visible = false;
					this.lbholi.Visible = false;
					if (pkg.FileName.Contains("Tutorial"))
					{
						this.lbType.Text = "Tutorial Neighbourhood";
						this.lbVer.Text = "Every EP";
						this.lbName.Text = "Tutorial";
						this.lbAbout.Text =
							"This neighbourhood is for you to learn with, don't make changes here but in game you may do whatever you like.";
					}
					else
					{
						this.lbType.Text =
							SimPe.Plugin.NeighborhoodType.Unknown.ToString();
						this.lbVer.Text =
							SimPe.Plugin.NeighborhoodVersion.Unknown.ToString();
					}
				}
			}
			catch (Exception ex)
			{
				this.lbAbout.Text = ex.Message;
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
			Idno idno = SimPe.Plugin.Idno.FromPackage(Package);
			if (idno != null)
			{
				this.lbVer.Text = idno.Version.ToString().Replace("_", " ");
			}
			else
			{
				this.lbVer.Text = SimPe.Plugin.NeighborhoodVersion.Unknown.ToString();
			}
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
			defimg = SimPe.GetImage.Demo;
		}

		private void ctss_ChangedUserData(
			Interfaces.Files.IPackedFileDescriptor sender
		)
		{
			SetFromPackage(this.Package);
		}
	}
}
