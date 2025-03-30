using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Avalonia.Media.Imaging;

using SkiaSharp;

namespace SimPe.Media
{
	public static class JpegAlfa
	{
		public static Bitmap LoadJpegAlfa(byte[] buffer)
		{
			Bitmap bitmap = new(new MemoryStream(buffer));
			if (!buffer[..2].SequenceEqual(new byte[] { 0xFF, 0xD8 }))
			{
				return bitmap;
			}
			if (!buffer[2..4].SequenceEqual(new byte[] { 0xFF, 0xE0 }))
			{
				return bitmap;
			}
			ushort pos = (ushort)(BinaryPrimitives.ReadUInt16BigEndian(buffer[4..6].AsSpan()) + 4);
			if (!buffer[pos..(pos + 2)].SequenceEqual(new byte[] { 0xFF, 0xE0 }))
			{
				return bitmap;
			}
			ushort len = BinaryPrimitives.ReadUInt16BigEndian(buffer[(pos + 2)..(pos + 4)].AsSpan());
			if (!buffer[(pos + 4)..(pos + 8)].AsSpan().SequenceEqual("ALFA"u8))
			{
				return bitmap;
			}
			List<byte> alphaChannel = [];
			using BinaryReader reader = new(new MemoryStream(buffer[(pos + 8)..(pos + len + 2)]));
			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				sbyte rleByte = reader.ReadSByte();
				if (rleByte < 0)
				{
					// The next transparency byte repeats ((-n) + 1) times
					int numRepeats = (-rleByte) + 1;
					byte transparency = reader.ReadByte();
					for (int i = 0; i < numRepeats; i++)
					{
						alphaChannel.Add(transparency);
					}
				}
				else
				{
					// There are n unique transparency bytes coming.
					int numRepeats = rleByte + 1;
					for (int i = 0; i < numRepeats; i++)
					{
						alphaChannel.Add(reader.ReadByte());
					}
				}
			}
			SKBitmap b = SKBitmap.Decode(buffer, new((int)bitmap.Size.Width, (int)bitmap.Size.Height, SKColorType.Rgba8888, SKAlphaType.Premul));
			nint ptr = b.GetPixels();
			unsafe
			{
				byte* unsafePtr = (byte*)ptr.ToPointer();
				for (int i = 0; i < alphaChannel.Count; i++)
				{
					unsafePtr[(i * 4) + 3] = alphaChannel[i];
				}
			}
			using MemoryStream stream1 = new();
			if (b.Encode(stream1, SKEncodedImageFormat.Png, 100))
			{
				stream1.Seek(0, SeekOrigin.Begin);
				return new(stream1);
			}
			else
			{
				return bitmap;
			}
		}
	}
}
