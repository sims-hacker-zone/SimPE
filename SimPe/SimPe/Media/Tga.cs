using System;
using System.IO;
using System.Runtime.InteropServices;

using Avalonia.Media.Imaging;

using Pfim;

using SkiaSharp;

namespace SimPe.Media
{
	public static class Tga
	{
		public static Bitmap ReadTGA(Stream stream)
		{
			SKColorType colorType;
			try
			{
				using IImage image = Pfimage.FromStream(stream);
				byte[] newData = image.Data;
				int newDataLen = image.DataLen;
				int stride = image.Stride;
				switch (image.Format)
				{
					case ImageFormat.Rgb8:
						colorType = SKColorType.Gray8;
						break;
					case ImageFormat.R5g6b5:
						// color channels still need to be swapped
						colorType = SKColorType.Rgb565;
						break;
					case ImageFormat.Rgba16:
						// color channels still need to be swapped
						colorType = SKColorType.Argb4444;
						break;
					case ImageFormat.Rgb24:
						// Skia has no 24bit pixels, so we upscale to 32bit
						int pixels = image.DataLen / 3;
						newDataLen = pixels * 4;
						newData = new byte[newDataLen];
						for (int i = 0; i < pixels; i++)
						{
							newData[i * 4] = image.Data[i * 3];
							newData[(i * 4) + 1] = image.Data[i * 3 + 1];
							newData[(i * 4) + 2] = image.Data[i * 3 + 2];
							newData[(i * 4) + 3] = 255;
						}

						stride = image.Width * 4;
						colorType = SKColorType.Bgra8888;
						break;
					case ImageFormat.Rgba32:
						colorType = SKColorType.Bgra8888;
						break;
					default:
						throw new ArgumentException($"Skia unable to interpret pfim format: {image.Format}");
				}

				SKImageInfo imageInfo = new(image.Width, image.Height, colorType);
				GCHandle handle = GCHandle.Alloc(newData, GCHandleType.Pinned);
				nint ptr = Marshal.UnsafeAddrOfPinnedArrayElement(newData, 0);
				using SKData data = SKData.Create(ptr, newDataLen, (address, context) => handle.Free());
				using SKImage skImage = SKImage.FromPixels(imageInfo, data, stride);
				using SKBitmap bitmap = SKBitmap.FromImage(skImage);
				using MemoryStream stream1 = new();
				if (bitmap.Encode(stream1, SKEncodedImageFormat.Png, 100))
				{
					stream1.Seek(0, SeekOrigin.Begin);
					return new(stream1);
				}
				else
				{
					return null;
				}
			}
			catch (ArgumentException)
			{
				return null;
			}
		}
	}
}
