using System;
using System.Drawing;

namespace SimPe.Plugin.Downloads
{
	/// <summary>
	/// Summary description for PackageInfo.
	/// </summary>
	public class PackageInfo : IPackageInfo, IDisposable
	{
		public const int IMAGESIZE = 128;

		protected static Image defimg;
		public static Image DefaultImage
		{
			get
			{
				if (defimg == null)
				{
					BuildDefaultImage();
				}

				return defimg;
			}
		}

		protected static void BuildDefaultImage()
		{
			if (defimg == null)
			{
				defimg = GetImage.Demo;
			}
		}

		/// <summary>
		/// Returns the Type of a given Package.
		/// </summary>
		/// <param name="filename">The package you want to classify</param>
		/// <returns>The Type of the Package</returns>
		public static Cache.PackageType ClassifyPackage(string filename)
		{
			if (
				!System.IO.File.Exists(filename)
				|| !System.IO.File.Exists(
					System.IO.Path.Combine(
						Helper.SimPePluginPath,
						"simpe.scanfolder.plugin.dll"
					)
				)
			)
			{
				return Cache.PackageType.Undefined;
			}

			Interfaces.Files.IPackageFile pkg =
				Packages.File.LoadFromFile(filename);
			return ClassifyPackage(pkg);
		}

		/// <summary>
		/// Returns the Type of a given Package.
		/// </summary>
		/// <param name="pkg">The package you want to classify</param>
		/// <returns>The Type of the Package</returns>
		public static Cache.PackageType ClassifyPackage(
			Interfaces.Files.IPackageFile pkg
		)
		{
			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(
						Helper.SimPePluginPath,
						"simpe.scanfolder.plugin.dll"
					)
				)
			)
			{
				return Cache.PackageType.Undefined;
			}

			Cache.PackageType type = Cache.PackageType.Undefined;
			foreach (
				Interfaces.Plugin.Scanner.IIdentifier ident in

					Scanner
					.ScannerRegistry
					.Global
					.Identifiers
			) // depends on simpe.scanfolder.plugin.dll, pity as that may not always exist
			{
				if (
					type != Cache.PackageType.Unknown
					&& type != Cache.PackageType.Undefined
				)
				{
					break; // this makes no sense, type always is Undefined as we just set it
				}

				type = ident.GetType(pkg);
			}

			return type;
		}

		/// <summary>
		/// Returns the Game package the File is associated with
		/// </summary>
		/// <param name="pfd">Resource Descriptor</param>
		/// <returns>The expansion which madkes this File available (according to the FileTable, <see cref="Expansion.Custom"/> marks a Custom File from the Downloads Folder)</returns>
		public static Expansions FileFrom(
			Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			Interfaces.Scenegraph.IScenegraphFileIndexItem[] fiis =
				FileTableBase.FileIndex.FindFile(pfd, null);
			uint min = (uint)Expansions.None;
			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem fii in fiis)
			{
				try
				{
					min = Math.Min((uint)FileFrom(fii.Package.FileName), min);
				}
				catch { }
			}

			return (Expansions)min;
		}

		/// <summary>
		/// Returns the Game package the File is associated with
		/// </summary>
		/// <param name="flname">The Filename</param>
		/// <returns>The expansion which madkes this File available (<see cref="Expansion.Custom"/> marks a Custom File from the Downloads Folder)</returns>
		public static Expansions FileFrom(string flname)
		{
			flname = flname == null ? "" : Helper.CompareableFileName(flname);

			foreach (ExpansionItem ei in PathProvider.Global.Expansions)
			{
				if (flname.StartsWith(Helper.CompareableFileName(ei.InstallFolder)))
				{
					return ei.Expansion;
				}
			}
			return flname.StartsWith(
					Helper.CompareableFileName(
						System.IO.Path.Combine(
							PathProvider.SimSavegameFolder,
							"Downloads"
						)
					)
				)
				? Expansions.Custom
				: Expansions.None;
		}

		string flname;

		public PackageInfo(Interfaces.Files.IPackageFile pkg)
		{
			Guids = new uint[0];
			flname = pkg.SaveFileName;
			KnockoutThumbnail = true;
			BuildDefaultImage();
			Reset();
		}

		public Expansions FirstExpansion
		{
			get; set;
		}

		public string Name
		{
			get; set;
		}

		public string Description
		{
			get; set;
		}

		public string Category
		{
			get; set;
		}

		Image img;

		public Image Image
		{
			get
			{
				if (img == null)
				{
					/*if (myrender==null) return defimg;
					else*/
					return RenderedImage;
				}

				return img;
			}
			set => img = value;
		}

		public bool HasThumbnail => img != null;
		public Image RenderedImage
		{
			get; set;
		}

		public int VertexCount
		{
			get; set;
		}
		public bool HighVertexCount => VertexCount > 8000;

		public int FaceCount
		{
			get; set;
		}
		public bool HighFaceCount => FaceCount > 8000;

		public int Price
		{
			get; set;
		}

		public uint[] Guids
		{
			get; set;
		}

		internal void ClearGuidList()
		{
			Guids = new uint[0];
		}

		public void AddGuid(uint guid)
		{
			Guids = Helper.Add(Guids, guid) as uint[];
		}

		public Cache.PackageType Type
		{
			get; set;
		}

		public void Reset()
		{
			RenderData = null;
			PostponedRenderer = null;
			Description = "";
			Name = "";
			Price = 0;
			Category = "";
			VertexCount = 0;
			FaceCount = 0;
			Image = null;
			Type = Cache.PackageType.Undefined;
			FirstExpansion = Expansions.None;
			ClearGuidList();
		}

		public static Image GeneratePreviewImage(
			Size sz,
			Image img,
			bool knockout,
			bool aspect
		)
		{
			if (img == null)
			{
				return null;
			}

			if (aspect)
			{
				double a = img.Width / (double)img.Height;
				sz = img.Height > img.Width ? new Size((int)(a * sz.Height), sz.Height) : new Size(sz.Width, (int)(sz.Width / a));
			}
			if (knockout)
			{
				img = Ambertation.Drawing.GraphicRoutines.KnockoutImage(
					img,
					new Point(0, 0),
					Color.Magenta
				);
				return Ambertation.Windows.Forms.Graph.ImagePanel.CreateThumbnail(
					img,
					sz,
					8,
					Color.FromArgb(90, Color.Black),
					Color.FromArgb(10, 10, 40),
					Color.White,
					Color.FromArgb(80, Color.White),
					true,
					3,
					3
				);
			}
			else
			{
				return Ambertation.Windows.Forms.Graph.ImagePanel.CreateThumbnail(
					img,
					sz,
					8,
					Color.FromArgb(90, Color.Black),
					Color.FromArgb(10, 10, 40),
					Color.White,
					Color.FromArgb(80, Color.White),
					true,
					3,
					3
				);
			}
		}

		/// <summary>
		///
		/// </summary>
		public bool KnockoutThumbnail
		{
			get; set;
		}

		public Image GetThumbnail()
		{
			return GetThumbnail(new Size(IMAGESIZE, IMAGESIZE));
		}

		public Image GetThumbnail(Size sz)
		{
			return Image == null ? null : GeneratePreviewImage(sz, Image, KnockoutThumbnail, true);
		}

		public override string ToString()
		{
			return Type.ToString() + ": " + Name;
		}

		#region postponed 3dPreview
		internal object RenderData
		{
			get; set;
		}
		internal EventHandler PostponedRenderer;

		public void CreatePostponed3DPreview()
		{
			if (RenderData == null)
			{
				return;
			}

			if (PostponedRenderer == null)
			{
				return;
			}

			PostponedRenderer(this, new EventArgs());
			PostponedRenderer = null;
			RenderData = null;
		}
		#endregion

		#region IDisposable Member

		public virtual void Dispose()
		{
			Name = null;
			Description = null;
			Category = null;
			img = null;
			RenderedImage = null;
			flname = null;

			RenderData = null;
			PostponedRenderer = null;
		}

		#endregion
	}
}
