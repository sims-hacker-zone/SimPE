// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
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
					int a = 0xFF - ((basecol.R + basecol.G + basecol.B) / 3);
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
			return new UserInterface.Picture();
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

		public uint[] AssignableTypes
		{
			get
			{
				uint[] Types =
				{
					0x0C7E9A76, //jpeg
					0x856DDBAC, //jpeg
					0x424D505F, //bitmap
					0x856DDBAC, //png
					0x856DDBAC, //tga
					0xAC2950C1, //thumbnail
					0x4D533EDD,
					0xAC2950C1,
					0x2C30E040,
					0x2C43CBD4,
					0x2C488BCA,
					0x8C31125E,
					0x8C311262,
					0xCC30CDF8,
					0xCC44B5EC,
					0xCC489E46,
					0xCC48C51F,
					0x8C3CE95A,
					0xEC3126C4,
					0xF03D464C,
				};
				return Types;
			}
		}

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
