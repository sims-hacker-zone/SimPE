using System;
using System.Collections;
using System.Drawing;

namespace SimPe.Plugin.Downloads
{
	/// <summary>
	/// Reads the Content of a Package
	/// </summary>
	public class DefaultTypeHandler : ITypeHandler, IDisposable
	{
		#region Preview
		static Ambertation.Graphics.DirectXPanel dxp;

		static void InitPreview()
		{
			if (dxp != null)
			{
				return;
			}

			dxp = new Ambertation.Graphics.DirectXPanel
			{
				Width = 128 * 3
			};
			dxp.Height = dxp.Width;
			dxp.BackColor = Color.FromArgb(10, 10, 40);
			dxp.Settings.MeshPassCullMode = Microsoft.DirectX.Direct3D.Cull.Clockwise;

			dxp.Settings.AddAxis = false;
			dxp.Settings.AddLightIndicators = false;
			dxp.Settings.RenderJoints = false;
		}
		#endregion

		protected PackageInfo nfo;
		protected string flname;
		protected PackedFiles.Wrapper.ExtObjd objd;
		bool rendergmdc;
		bool countvert;

		/// <summary>
		/// Creates a new Instance
		/// </summary>
		/// <param name="type">Type of the stored Data in the Package</param>
		/// <param name="pkg">The package</param>
		/// <param name="countvert">false, if you don't need to know the number of
		/// stored vertices (you will not get a Preview if this is set to false!)</param>
		/// <param name="rendergmdc">If true, SimPe will generate a Preview from
		/// the GMDC (only if countvert is also true)</param>
		internal DefaultTypeHandler(
			Cache.PackageType type,
			Interfaces.Files.IPackageFile pkg,
			bool countvert,
			bool rendergmdc
		)
			: this()
		{
			this.rendergmdc = rendergmdc;
			this.countvert = countvert;
			LoadContent(type, pkg);
		}

		internal DefaultTypeHandler()
		{
			rendergmdc = true;
			countvert = true;
		}

		public void LoadContent(
			Cache.PackageType type,
			Interfaces.Files.IPackageFile pkg
		)
		{
			flname = pkg.SaveFileName;
			nfo = new PackageInfo(pkg)
			{
				Type = type
			};
			OnLoadContent();

			SetFromPackage(pkg);
		}

		protected virtual void OnLoadContent()
		{
		}

		protected virtual void UpdateScreen()
		{
		}

		#region Thumbnails
		/// <summary>
		/// Returns the Instance Number for the assigned Thumbnail
		/// </summary>
		/// <param name="group">The Group of the Object</param>
		/// <param name="modelname">The Name of teh Model (inst 0x86)</param>
		/// <returns>Instance of the Thumbnail</returns>
		public static uint ThumbnailHash(uint group, string modelname)
		{
			string name = group.ToString() + modelname;
			return (uint)
				Hashes.ToLong(
					Hashes.Crc32.ComputeHash(Helper.ToBytes(name.Trim().ToLower()))
				);
		}

		static Packages.File thumbs = null;

		/// <summary>
		/// Returns the Thumbnail of an Object
		/// </summary>
		/// <param name="group"></param>
		/// <param name="modelname"></param>
		/// <returns>The Thumbnail</returns>
		public static Image GetThumbnail(uint group, string modelname)
		{
			return GetThumbnail(group, modelname, null);
		}

		/// <summary>
		/// Returns the Thumbnail of an Object
		/// </summary>
		/// <param name="group"></param>
		/// <param name="modelname"></param>
		/// <returns>The Thumbnail</returns>
		public static Image GetThumbnail(uint group, string modelname, string message)
		{
			if (thumbs == null)
			{
				thumbs = Packages.File.LoadFromFile(
					System.IO.Path.Combine(
						PathProvider.SimSavegameFolder,
						"Thumbnails\\ObjectThumbnails.package"
					)
				);
				thumbs.Persistent = true;
			}

			Image img = GetThumbnail(group, modelname, message, thumbs);
			return img;
		}

		/// <summary>
		/// Returns the Thumbnail of an Object
		/// </summary>
		/// <param name="group"></param>
		/// <param name="modelname"></param>
		/// <returns>The Thumbnail</returns>
		public static Image GetThumbnail(
			uint group,
			string modelname,
			string message,
			Packages.File thumbs
		)
		{
			uint inst = ThumbnailHash(group, modelname);
			Image img = GetThumbnail(
				message,
				new uint[] { 0xAC2950C1 },
				group,
				inst,
				thumbs
			);

			return img;
		}

		/// <summary>
		/// Returns the Thumbnail of an Object
		/// </summary>
		/// <param name="group"></param>
		/// <param name="modelname"></param>
		/// <returns>The Thumbnail</returns>
		public static Image GetThumbnail(
			string message,
			uint type,
			uint group,
			uint inst,
			Packages.File thumbs
		)
		{
			return GetThumbnail(message, new uint[] { type }, group, inst, thumbs);
		}

		/// <summary>
		/// Returns the Thumbnail of an Object
		/// </summary>
		/// <param name="group"></param>
		/// <param name="modelname"></param>
		/// <returns>The Thumbnail</returns>
		public static Image GetThumbnail(
			string message,
			uint[] types,
			uint group,
			uint inst,
			Packages.File thumbs
		)
		{
			foreach (uint type in types)
			{
				//0x6C2A22C3
				Interfaces.Files.IPackedFileDescriptor[] pfds = thumbs.FindFile(
					type,
					group,
					inst
				);
				if (pfds.Length == 0)
				{
					pfds = thumbs.FindFile(type, 0, inst);
				}

				if (pfds.Length > 0)
				{
					Interfaces.Files.IPackedFileDescriptor pfd = pfds[0];
					try
					{
						PackedFiles.Wrapper.Picture pic =
							new PackedFiles.Wrapper.Picture();
						pic.ProcessData(pfd, thumbs);
						Bitmap bm = (Bitmap)
							ImageLoader.Preview(pic.Image, WaitingScreen.ImageSize);
						if (WaitingScreen.Running)
						{
							WaitingScreen.Update(bm, message);
						}

						return pic.Image;
					}
					catch (Exception) { }
				}
			}
			return null;
		}
		#endregion


		protected void SetupCategories(string[][] catss)
		{
			nfo.Category = "";
			foreach (string[] cats in catss)
			{
				string res = "";
				foreach (string cat in cats)
				{
					if (res != "")
					{
						res += " / ";
					}

					res += cat.Trim();
				}

				if (res != "")
				{
					nfo.Category = res;
				}
			}
		}

		public virtual void SetFromObjectCacheItem(Cache.ObjectCacheItem oci)
		{
			ClearScreen();
			if (oci == null)
			{
				objd = null;

				return;
			}

			objd = null;
			if (oci.Tag != null)
			{
				if (oci.Tag is Interfaces.Scenegraph.IScenegraphFileIndexItem)
				{
					objd = new PackedFiles.Wrapper.ExtObjd();
					objd.ProcessData(
						(Interfaces.Scenegraph.IScenegraphFileIndexItem)oci.Tag
					);
				}
			}

			UpdateScreen(null, false);
			if (oci.Thumbnail == null)
			{
				nfo.Image = null;
			}
			else
			{
				nfo.Image = oci.Thumbnail;
			}

			nfo.Name = oci.Name;
			nfo.VertexCount = 0;
			nfo.FaceCount = 0;
		}

		static Ambertation.Scenes.Scene scn;

		public virtual void SetFromPackage(Interfaces.Files.IPackageFile pkg)
		{
			ClearScreen();
			if (pkg == null)
			{
				objd = null;
				return;
			}

			GetObjd(pkg);
			UpdateScreen(pkg, false);
		}

		protected void GetObjd(Interfaces.Files.IPackageFile pkg)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				Data.MetaData.OBJD_FILE
			);
			if (pfds.Length > 0)
			{
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					PackedFiles.Wrapper.ExtObjd mobjd =
						new PackedFiles.Wrapper.ExtObjd();
					mobjd.ProcessData(pfd, pkg);

					nfo.AddGuid(mobjd.Guid);

					if (objd == null)
					{
						objd = mobjd;
					}

					if (pfds.Length == 1)
					{
						break;
					}

					if (mobjd.Data.Length > 0xb)
					{
						if (mobjd.Data[0xb] == -1)
						{
							objd = mobjd;
						}
					}
				}
			}
		}

		protected void PostponedRender(object sender, EventArgs e)
		{
			Wait.SubStart();
			Wait.Message = "Building Preview";
			GeometryDataContainerExt ext =
				((sender as PackageInfo).RenderData)
				as GeometryDataContainerExt;
			Ambertation.Scenes.Scene scn = ext.GetScene(
				new Gmdc.ElementOrder(
					Gmdc.ElementSorting.Preview
				)
			);
			nfo.RenderedImage = Get3dPreview(scn);
			scn.Dispose();

			ext.Gmdc.Dispose();
			ext.Dispose();
			Wait.SubStop();
		}

		/// <summary>
		/// Renders the Preview form the GMDC and loads the vertex and face Count for an Object
		/// </summary>
		/// <param name="pkg"></param>
		protected void RenderGmdcPreview(Interfaces.Files.IPackageFile pkg)
		{
			int fct = 0;
			int vct = 0;
			if (countvert)
			{
				Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
					Data.MetaData.GMDC
				);
				bool first = !nfo.HasThumbnail;

				Wait.SubStart();
				System.Windows.Forms.Application.DoEvents();
				Wait.Message = "Counting Vertices";
				System.Windows.Forms.Application.DoEvents();
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					Rcol rcol = new GenericRcol();
					rcol.ProcessData(pfd, pkg, true);

					GeometryDataContainer gmdc =
						rcol.Blocks[0] as GeometryDataContainer;
					bool hasmesh = false;
					foreach (Gmdc.GmdcGroup g in gmdc.Groups)
					{
						if (g.Opacity == 0xFFFFFFFF)
						{
							hasmesh = true;
						}

						fct += g.FaceCount;
						vct += g.UsedVertexCount;
					}

					bool dispose = true;
					if (


							DownloadsToolFactory
							.Settings
							.BuildPreviewForObjects
					)
					{
						if (first && hasmesh && rendergmdc)
						{
							first = false;
							GeometryDataContainerExt ext =
								new GeometryDataContainerExt(gmdc);
							nfo.RenderData = ext;
							nfo.PostponedRenderer = new EventHandler(PostponedRender);
							dispose = false;
						}
					}

					if (dispose)
					{
						gmdc.Dispose();
						rcol.Dispose();
					}
				}
				Wait.SubStop();
				pfds = null;
			}
			nfo.VertexCount = vct;
			nfo.FaceCount = fct;

			if (
				!nfo.HasThumbnail
				&& !DownloadsToolFactory.Settings.BuildPreviewForObjects
			)
			{
				nfo.Image = WallpaperTypeHandler.SetFromTxtr(pkg);
				nfo.KnockoutThumbnail = false;
			}
		}

		public static Image Get3dPreview(Ambertation.Scenes.Scene scene)
		{
			if (scene == null)
			{
				return null;
			}

			scn = scene;
			InitPreview();

			dxp.ResetDevice += new EventHandler(dxp_ResetDevice);

			dxp.Reset();
			dxp.ResetDefaultViewport();
			dxp.Settings.AngelX = (float)(Math.PI / 8.0);
			dxp.Settings.AngelY = (float)(Math.PI / -6.0);
			dxp.Settings.Z *= 0.3f;
			dxp.UpdateRotation();
			dxp.Render();
			Image ret = dxp.Screenshot(Microsoft.DirectX.Direct3D.ImageFileFormat.Png);

			/*System.Windows.Forms.Form f = new System.Windows.Forms.Form();
			f.Controls.Add(dxp);
			f.ShowDialog();*/


			dxp.ResetDevice -= new EventHandler(dxp_ResetDevice);

			return ret;
		}

		protected void ClearScreen()
		{
			Cache.PackageType t = nfo.Type;
			nfo.Reset();
			nfo.Type = t;
		}

		public void UpdateScreen(Interfaces.Files.IPackageFile pkg, bool clear)
		{
			if (clear)
			{
				ClearScreen();
			}

			if (objd == null)
			{
				return;
			}

			nfo.FirstExpansion = PackageInfo.FileFrom(objd.FileDescriptor);

			string[] mn = GetModelnames();
			if (mn.Length > 0)
			{
				uint grp = objd.FileDescriptor.Group;
				nfo.Image = GetThumbnail(objd.FileDescriptor.Group, mn[0]);
			}
			else
			{
				nfo.Image = null;
			}

			if (pkg != null)
			{
				RenderGmdcPreview(pkg);
			}

			SetupCategories(
				Cache.ObjectCacheItem.GetCategory(
					Cache.ObjectCacheItemVersions.DockableOW,
					objd.FunctionSubSort,
					objd.Type,
					Cache.ObjectClass.Object
				)
			);

			PackedFiles.Wrapper.StrItemList strs = GetCtssItems();
			if (strs != null)
			{
				if (strs.Count > 0)
				{
					nfo.Name = strs[0].Title;
				}

				if (strs.Count > 1)
				{
					nfo.Description = strs[1].Title;
				}
			}
			else
			{
				nfo.Name = objd.FileName;
			}

			nfo.Price = objd.Price;
			UpdateScreen();
		}

		protected string[] GetModelnames()
		{
			if (objd == null)
			{
				return new string[0];
			}

			if (objd.Package == null)
			{
				return new string[0];
			}

			Interfaces.Files.IPackedFileDescriptor pfd = objd.Package.FindFile(
				Data.MetaData.STRING_FILE,
				0,
				objd.FileDescriptor.Group,
				0x85
			);
			ArrayList list = new ArrayList();
			if (pfd != null)
			{
				PackedFiles.Wrapper.Str str = new PackedFiles.Wrapper.Str();
				str.ProcessData(pfd, objd.Package);
				PackedFiles.Wrapper.StrItemList items = str.LanguageItems(1);
				for (int i = 1; i < items.Length; i++)
				{
					list.Add(items[i].Title);
				}
			}
			string[] refname = new string[list.Count];
			list.CopyTo(refname);

			return refname;
		}

		internal static PackedFiles.Wrapper.StrItemList GetCtssItems(
			Interfaces.Files.IPackedFileDescriptor ctss,
			Interfaces.Files.IPackageFile pkg
		)
		{
			if (ctss != null)
			{
				PackedFiles.Wrapper.Str str = new PackedFiles.Wrapper.Str();
				str.ProcessData(ctss, pkg);

				return str.FallbackedLanguageItems(Helper.WindowsRegistry.LanguageCode);
			}

			return null;
		}

		protected virtual PackedFiles.Wrapper.StrItemList GetCtssItems()
		{
			if (objd == null)
			{
				return null;
			}

			if (objd.Package == null)
			{
				return null;
			}

			if (objd.FileDescriptor == null)
			{
				return null;
			}

			//Get the Name of the Object
			Interfaces.Files.IPackedFileDescriptor ctss = objd.Package.FindFile(
				Data.MetaData.CTSS_FILE,
				0,
				objd.FileDescriptor.Group,
				objd.CTSSInstance
			);

			return GetCtssItems(ctss, objd.Package);
		}

		#region IPackageHandler Member

		public IPackageInfo[] Objects => new IPackageInfo[] { nfo };

		#endregion

		private static void dxp_ResetDevice(object sender, EventArgs e)
		{
			Ambertation.Graphics.DirectXPanel dxp =
				sender as Ambertation.Graphics.DirectXPanel;
			dxp.Meshes.Clear();
			dxp.AddScene(scn);
		}

		#region IDisposable Member

		public virtual void Dispose()
		{
			nfo = null;
			flname = null;
			objd = null;
		}

		#endregion
	}
}
