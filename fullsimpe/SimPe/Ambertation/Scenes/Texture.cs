// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Ambertation.Scenes
{
	public class Texture : IDisposable
	{
		private string flname;

		private Size sz;

		private Image img;

		private object tag;

		public bool Available => flname != null;

		public string FileName
		{
			get
			{
				return flname;
			}
			set
			{
				flname = value;
			}
		}

		public Size Size
		{
			get
			{
				return sz;
			}
			set
			{
				sz = value;
			}
		}

		public Image TextureImage
		{
			get
			{
				return img;
			}
			set
			{
				img = value;
				if (img != null)
				{
					Size = img.Size;
				}
			}
		}

		public object Tag
		{
			get
			{
				return tag;
			}
			set
			{
				tag = value;
			}
		}

		internal Texture(string filename, Size sz)
		{
			flname = filename;
			this.sz = sz;
		}

		public void ImportTextureImage()
		{
			LoadTexture(flname);
		}

		public static ImageFormat GetImageFormatFromName(string flname)
		{
			switch (Path.GetExtension(flname).Trim().ToLower())
			{
				case ".png":
					return ImageFormat.Png;
				case ".jpg":
				case ".jpeg":
					return ImageFormat.Jpeg;
				case ".tif":
				case ".tiff":
					return ImageFormat.Tiff;
				case ".gif":
					return ImageFormat.Gif;
				default:
					return ImageFormat.Bmp;
			}
		}

		public void ExportTextureImage()
		{
			ExportTextureImage(img, flname);
		}

		public override string ToString()
		{
			if (Available)
			{
				return flname + " (" + sz.ToString() + ")";
			}

			return GetType().Name;
		}

		protected bool ExportTextureImage(Image img, string flname)
		{
			if (img != null && flname != null)
			{
				ImageFormat imageFormatFromName = GetImageFormatFromName(flname);
				string directoryName = Path.GetDirectoryName(flname);
				try
				{
					if (!Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}

					img.Save(flname, imageFormatFromName);
					return true;
				}
				catch
				{
				}
			}

			return false;
		}

		protected void LoadTexture(string flname)
		{
			if (flname == null)
			{
				return;
			}

			if (!File.Exists(flname))
			{
				flname = Path.GetFileName(flname);
			}

			if (File.Exists(flname))
			{
				img = null;
				try
				{
					img = Image.FromFile(flname);
					Size = img.Size;
				}
				catch
				{
				}
			}
		}

		public void Dispose()
		{
			img = null;
			flname = null;
		}
	}
}
