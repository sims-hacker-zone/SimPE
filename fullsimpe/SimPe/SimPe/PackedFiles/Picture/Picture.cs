// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Picture
{
	/// <summary>
	/// Represents a PacjedFile in JPEG Format
	/// </summary>
	public class Picture
		: AbstractWrapper,
			IFileWrapper,
			IDisposable
	{
		/// <summary>
		/// Stores the Image
		/// </summary>
		protected Image image;

		/// <summary>
		/// Returns the Stored Image
		/// </summary>
		public Image Image => image;

		#region IWrapper Member
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Picture Wrapper",
				"Quaxi",
				"---",
				2,
				Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.pic.png")
				)
			);
		}
		#endregion

		public static Image SetAlpha(Image img)
		{
			Bitmap bmp = new Bitmap(
				img.Size.Width,
				img.Size.Height,
				System.Drawing.Imaging.PixelFormat.Format32bppArgb
			);

			for (int y = 0; y < bmp.Size.Height; y++)
			{
				for (int x = 0; x < bmp.Size.Width; x++)
				{
					Color basecol = ((Bitmap)img).GetPixel(x, y);
					int a = 0xFF - (basecol.R + basecol.G + basecol.B) / 3;
					if (a > 0x10)
					{
						a = 0xff;
					}

					Color col = Color.FromArgb(a, basecol);
					bmp.SetPixel(x, y, col);
				}
			}

			return bmp;
		}

		protected bool DoLoad(System.IO.BinaryReader reader, bool errmsg)
		{
			try
			{
				image = Image.FromStream(reader.BaseStream);
				return true;
			}
			catch (Exception)
			{
				try
				{
					image = Ambertation.Viewer.LoadTGAClass.LoadTGA(reader.BaseStream);

					return true;
				}
				catch (Exception ex)
				{
					if (errmsg)
					{
						Helper.ExceptionMessage(
							Localization.Manager.GetString("errunsupportedimage"),
							ex
						);
					}
				}
			}

			return false;
		}

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new PictureUI();
		}

		public Picture()
			: base() { }

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			if (!DoLoad(reader, false))
			{
				System.IO.BinaryReader br = new System.IO.BinaryReader(
					new System.IO.MemoryStream()
				);
				System.IO.BinaryWriter bw = new System.IO.BinaryWriter(br.BaseStream);
				reader.BaseStream.Seek(0x40, System.IO.SeekOrigin.Begin);

				bw.Write(reader.ReadBytes((int)(reader.BaseStream.Length - 0x40)));
				DoLoad(br, true);
			}
		}
		#endregion

		#region IPackedFileWrapper Member

		public FileTypes[] AssignableTypes => new FileTypes[]
				{
					FileTypes.JPG,
					FileTypes.IMG,
					FileTypes.BMP,
					FileTypes.THUB,
					FileTypes.THUMB_NHOBJ,
					FileTypes.THUB,
					FileTypes.THUMB_FARC,
					FileTypes.THUMB_POOL,
					FileTypes.THUMB_DORM,
					FileTypes.THUMB_WALL,
					FileTypes.THUMB_FLOOR,
					FileTypes.THUMB_FENCE,
					FileTypes.THUMB_MODST,
					FileTypes.THUMB_ROOF,
					FileTypes.THUMB_CHIM,
					FileTypes.THUMB_FAMILY,
					FileTypes.THUMB_TERRAIN,
					FileTypes.THUMB_AWN,
				};

		public byte[] FileSignature => new byte[0];

		#endregion

		#region IDisposable Member

		public override void Dispose()
		{
			image?.Dispose();

			image = null;

			base.Dispose();
		}

		#endregion
	}
}
