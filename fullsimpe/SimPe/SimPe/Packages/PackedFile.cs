// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

using SimPe.Interfaces.Files;

namespace SimPe.Packages
{
	/// <summary>
	/// A File within a Package
	/// </summary>
	public class PackedFile : IPackedFile, IDisposable
	{
		System.IO.Stream src;
		System.IO.Stream dst;

		/// <summary>
		/// Constructor for the class
		/// </summary>
		/// <param name="content">The Content of the Packed File</param>
		internal PackedFile(byte[] content)
		{
			data = content;
			headersize = 0;
			uncdata = null;
			src = null;
		}

		internal PackedFile(System.IO.Stream s)
		{
			data = null;
			headersize = 0;
			uncdata = null;
			datastart = 0;
			src = s;
			dst = null;
		}

		/// <summary>
		/// The Size of the PackedFile Header
		/// </summary>
		public int headersize;

		/// <summary>
		/// Returns true if the PackedFile is compressed
		/// </summary>
		public bool IsCompressed =>
					(headersize != 0)
					&& (Signature == SimPe.Data.MetaData.COMPRESS_SIGNATURE)
				;

		/// <summary>
		/// Size of the compressed File
		/// </summary>
		internal int size;

		/// <summary>
		/// Returns the Size of the File
		/// </summary>
		public int Size => size;

		/// <summary>
		/// Compression Signature
		/// </summary>
		internal ushort signature;

		/// <summary>
		/// Returns the Size of the File
		/// </summary>
		public ushort Signature => signature;

		internal uint datastart;
		public uint DataStart => datastart;

		/// <summary>
		/// Filesize
		/// </summary>
		internal uint datasize;

		/// <summary>
		/// Returns the Filesize
		/// </summary>
		public uint DataSize => datasize;

		/// <summary>
		/// the File Data
		/// </summary>
		public byte[] data;

		/// <summary>
		/// the uncompressed Data
		/// </summary>
		internal byte[] uncdata;

		internal uint uncsize;
		public uint UncompressedSize => uncsize;

		/// <summary>
		/// Returns the Plain File Data (might be compressed)
		/// </summary>
		/// <remarks>
		/// All Header Informations are Cut from the Data, so you really
		/// get the Data Stored in the PackedFile
		/// </remarks>
		public byte[] Data
		{
			get
			{
				if (headersize > 0)
				{
					byte[] sub = new byte[data.Length - headersize];
					for (int i = headersize; i < data.Length; i++)
					{
						sub[i - headersize] = data[i];
					}

					return sub;
				}
				else
				{
					return data;
				}
			}
		}

		/// <summary>
		/// Returns the Plain File Data (might be compressed)
		/// </summary>
		public byte[] PlainData => data;

		class OffsetStream : System.IO.Stream
		{
			System.IO.Stream s;
			int o;
			int sz;

			public OffsetStream(System.IO.Stream src, uint offset, int size)
			{
				o = (int)offset;
				s = src;
				sz = size;
			}

			public override bool CanRead => s.CanRead;

			public override bool CanSeek => s.CanSeek;

			public override bool CanWrite => s.CanWrite;

			public override void Flush()
			{
				s.Flush();
			}

			public override long Length => sz;

			public override long Position
			{
				get => s.Position - o;
				set => s.Position = value + o;
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				return s.Read(buffer, offset, count);
			}

			public override long Seek(long offset, System.IO.SeekOrigin origin)
			{
				switch (origin)
				{
					case System.IO.SeekOrigin.Current:
						return s.Seek(offset, origin);
					case System.IO.SeekOrigin.Begin:
						return s.Seek(offset + o, origin);
					default:
						return s.Seek(sz - offset + 0, System.IO.SeekOrigin.Begin);
				}
			}

			public override void SetLength(long value)
			{
				throw new Exception("The method or operation is not implemented.");
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				Write(buffer, offset, count);
			}
		}

		/// <summary>
		/// Returns the Plain File Data. If the Packed File is compress it will be decompressed
		/// </summary>
		public System.IO.Stream UncompressedStream
		{
			get
			{
				if (dst == null)
				{
					lock (src)
					{
						src.Seek(DataStart, System.IO.SeekOrigin.Begin);
						if (IsCompressed)
						{
							dst = UncompressStream(
								src,
								Size,
								UncompressedSize,
								headersize
							);
						}
						else
						{
							byte[] data = new byte[DataSize];
							src.Read(data, 0, (int)DataSize);
							dst = new System.IO.MemoryStream(data);
						}
					}
				}

				dst.Seek(0, System.IO.SeekOrigin.Begin);
				return dst;
			}
		}

		/// <summary>
		/// Returns the Plain File Data. If the Packed File is compress it will be decompressed
		/// </summary>
		public byte[] UncompressedData
		{
			get
			{
				if (IsCompressed)
				{
					if (uncdata == null)
					{
						uncdata = Uncompress(data, UncompressedSize, headersize);
					}

					return uncdata;
				}
				else
				{
					return Data;
				}
			}
		}

		/// <summary>
		/// Returns the Uncompressed Data
		/// </summary>
		/// <param name="maxsize">Maximum Number of Bytes that should be returned</param>
		/// <returns></returns>
		public byte[] GetUncompressedData(int maxsize)
		{
			if (IsCompressed)
			{
				lock (data)
				{
					byte[] uncdata = Uncompress(
						data,
						UncompressedSize,
						headersize,
						maxsize
					);
					return uncdata;
				}
			}
			else
			{
				return Data;
			}
		}

		/// <summary>
		/// Returns a part of the decompresed File
		/// </summary>
		/// <param name="size">max number of bytes to decompress</param>
		/// <returns>trhe decompressed Value</returns>
		public byte[] Decompress(long size)
		{
			size = Math.Max(size, UncompressedSize);
			lock (data)
			{
				return Uncompress(data, (uint)size, headersize);
			}
		}

		#region decompression

		/// <summary>
		/// Uncompresses the File Data passed
		/// </summary>
		/// <param name="data">Relevant File Data</param>
		/// <param name="targetSize">Size of the uncompressed Data</param>
		/// <param name="offset">File offset, where we should start to decompress from</param>
		/// <returns>The uncompressed FileData</returns>
		public byte[] Uncompress(byte[] data, uint targetSize, int offset)
		{
			byte[] uncdata = null;
			int index = offset;

			try
			{
				uncdata = new byte[targetSize];
			}
			catch (Exception)
			{
				uncdata = new byte[0];
			}

			int uncindex = 0;
			int plaincount = 0;
			int copycount = 0;
			int copyoffset = 0;
			byte cc = 0;
			byte cc1 = 0;
			byte cc2 = 0;
			byte cc3 = 0;
			int source;

			try
			{
				while ((index < data.Length) && (data[index] < 0xfc))
				{
					cc = data[index++];

					if ((cc & 0x80) == 0)
					{
						cc1 = data[index++];
						plaincount = cc & 0x03;
						copycount = ((cc & 0x1C) >> 2) + 3;
						copyoffset = ((cc & 0x60) << 3) + cc1 + 1;
					}
					else if ((cc & 0x40) == 0)
					{
						cc1 = data[index++];
						cc2 = data[index++];
						plaincount = (cc1 & 0xC0) >> 6;
						copycount = (cc & 0x3F) + 4;
						copyoffset = ((cc1 & 0x3F) << 8) + cc2 + 1;
					}
					else if ((cc & 0x20) == 0)
					{
						cc1 = data[index++];
						cc2 = data[index++];
						cc3 = data[index++];
						plaincount = cc & 0x03;
						copycount = ((cc & 0x0C) << 6) + cc3 + 5;
						copyoffset = ((cc & 0x10) << 12) + (cc1 << 8) + cc2 + 1;
					}
					else
					{
						plaincount = (cc - 0xDF) << 2;
						copycount = 0;
						copyoffset = 0;
					}

					for (int i = 0; i < plaincount; i++)
					{
						uncdata[uncindex++] = data[index++];
					}

					source = uncindex - copyoffset;
					for (int i = 0; i < copycount; i++)
					{
						uncdata[uncindex++] = uncdata[source++];
					}
				} //while
			} //try
			catch (Exception ex)
			{
				//Helper.ExceptionMessage("", ex);
				throw ex;
			}

			if (index < data.Length)
			{
				plaincount = data[index++] & 0x03;
				for (int i = 0; i < plaincount; i++)
				{
					if (uncindex >= uncdata.Length)
					{
						break;
					}

					uncdata[uncindex++] = data[index++];
				}
			}
			return uncdata;
		}

		/// <summary>
		/// Uncompresses the File Data passed
		/// </summary>
		/// <param name="data">Relevant File Data</param>
		/// <param name="targetSize">Size of the uncompressed Data</param>
		/// <param name="offset">File offset, where we should start to decompress from</param>
		/// <returns>The uncompressed FileData</returns>
		public unsafe byte[] UncompressUnsafe(byte[] data, uint targetSize, int offset)
		{
			byte[] uncdata = null;

			try
			{
				uncdata = new byte[targetSize];
			}
			catch (Exception)
			{
				uncdata = new byte[0];
			}
			fixed (byte* uncdataarraystart = uncdata)
			fixed (byte* dataarraystart = data)
			{
				int plaincount = 0;
				int copycount = 0;
				int copyoffset = 0;

				byte* datapt = dataarraystart + offset;
				byte* dataarrayend = dataarraystart + data.Length;

				byte* uncdatapt = uncdataarraystart;
				byte* uncdataarrayend = uncdataarraystart + targetSize;

				try
				{
					while (datapt < dataarrayend && (*datapt < 0xfc))
					{
						if ((*datapt & 0x80) == 0)
						{
							plaincount = *datapt & 0x03;
							copycount = ((*datapt & 0x1C) >> 2) + 3;
							copyoffset = (*datapt & 0x60) << 3;
							datapt++;
							copyoffset += *datapt + 1;
						}
						else if ((*datapt & 0x40) == 0)
						{
							copycount = (*datapt & 0x3F) + 4;
							datapt++;
							plaincount = (*datapt & 0xC0) >> 6;
							copyoffset = (*datapt & 0x3F) << 8;
							datapt++;
							copyoffset += *datapt + 1;
						}
						else if ((*datapt & 0x20) == 0)
						{
							plaincount = *datapt & 0x03;
							copycount = (*datapt & 0x0C) << 6;
							copyoffset = (*datapt & 0x10) << 12;
							datapt++;
							copyoffset += *datapt << 8;
							datapt++;
							copyoffset += *datapt + 1;
							datapt++;
							copycount += *datapt + 5;
						}
						else
						{
							plaincount = (*datapt - 0xDF) << 2;
							copycount = 0;
							copyoffset = 0;
						}

						datapt++;

						for (int i = 0; i < plaincount; i++)
						{
							*uncdatapt = *datapt;
							uncdatapt++;
							datapt++;
						}

						byte* source = uncdatapt - copyoffset;

						for (int i = 0; i < copycount; i++)
						{
							*uncdatapt = *source;
							uncdatapt++;
							source++;
						}
					} //while
				} //try
				catch (Exception ex)
				{
					//Helper.ExceptionMessage("", ex);
					throw ex;
				}

				if (datapt < dataarrayend)
				{
					plaincount = *datapt & 0x03;
					datapt++;
					for (int i = 0; i < plaincount; i++)
					{
						if (uncdatapt >= uncdataarrayend)
						{
							break;
						}

						*uncdatapt = *datapt;
						datapt++;
						uncdatapt++;
					}
				}
			}
			return uncdata;
		}

		/// <summary>
		/// Uncompresses the File Data passed
		/// </summary>
		/// <param name="data">Relevant File Data</param>
		/// <param name="targetSize">Size of the uncompressed Data</param>
		/// <param name="size">Maximum number of Bytes that should be read from the Resource</param>
		/// <param name="offset">File offset, where we should start to decompress from</param>
		/// <returns>The uncompressed FileData</returns>
		public byte[] Uncompress(byte[] data, uint targetSize, int offset, int size)
		{
			byte[] uncdata = null;
			int index = offset;

			try
			{
				uncdata = new byte[targetSize];
			}
			catch (Exception)
			{
				uncdata = new byte[0];
			}

			int uncindex = 0;
			int plaincount = 0;
			int copycount = 0;
			int copyoffset = 0;
			byte cc = 0;
			byte cc1 = 0;
			byte cc2 = 0;
			byte cc3 = 0;
			int source;
			try
			{
				while ((index < data.Length) && (data[index] < 0xfc))
				{
					cc = data[index++];

					if ((cc & 0x80) == 0)
					{
						cc1 = data[index++];
						plaincount = cc & 0x03;
						copycount = ((cc & 0x1C) >> 2) + 3;
						copyoffset = ((cc & 0x60) << 3) + cc1 + 1;
					}
					else if ((cc & 0x40) == 0)
					{
						cc1 = data[index++];
						cc2 = data[index++];
						plaincount = (cc1 & 0xC0) >> 6;
						copycount = (cc & 0x3F) + 4;
						copyoffset = ((cc1 & 0x3F) << 8) + cc2 + 1;
					}
					else if ((cc & 0x20) == 0)
					{
						cc1 = data[index++];
						cc2 = data[index++];
						cc3 = data[index++];
						plaincount = cc & 0x03;
						copycount = ((cc & 0x0C) << 6) + cc3 + 5;
						copyoffset = ((cc & 0x10) << 12) + (cc1 << 8) + cc2 + 1;
					}
					else
					{
						plaincount = (cc - 0xDF) << 2;
						copycount = 0;
						copyoffset = 0;
					}

					for (int i = 0; i < plaincount; i++)
					{
						uncdata[uncindex++] = data[index++];
					}

					source = uncindex - copyoffset;
					for (int i = 0; i < copycount; i++)
					{
						uncdata[uncindex++] = uncdata[source++];
					}

					if (size != -1)
					{
						if (uncindex >= size)
						{
							byte[] newdata = new byte[uncindex];
							for (int i = 0; i < uncindex; i++)
							{
								newdata[i] = uncdata[i];
							}

							return newdata;
						}
					}
				} //while
			} //try
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally { }

			if (index < data.Length)
			{
				plaincount = data[index++] & 0x03;
				for (int i = 0; i < plaincount; i++)
				{
					if (uncindex >= uncdata.Length)
					{
						break;
					}

					uncdata[uncindex++] = data[index++];
				}
			}
			return uncdata;
		}

		/// <summary>
		/// Returns the Stream that holds the given Resource
		/// </summary>
		/// <param name="pfd">The PackedFileDescriptor</param>
		/// <returns>The stream containing the resource. Be carfull, this is not at all Thread Save!!!</returns>
		public static System.IO.MemoryStream UncompressStream(
			System.IO.Stream s,
			int datalength,
			uint targetSize,
			int offset
		)
		{
			byte[] uncdata;

			int end = (int)(s.Position + datalength);
			s.Seek(offset, System.IO.SeekOrigin.Current);

			try
			{
				uncdata = new byte[targetSize];
			}
			catch (Exception)
			{
				uncdata = new byte[0];
			}

			int uncindex = 0;
			int plaincount = 0;
			int copycount = 0;
			int copyoffset = 0;
			byte cc = 0;
			byte cc1 = 0;
			byte cc2 = 0;
			byte cc3 = 0;

			try
			{
				while (s.Position < end)
				{
					cc = (byte)s.ReadByte();
					if (cc >= 0xfc)
					{
						s.Seek(-1, System.IO.SeekOrigin.Current);
						break;
					}

					if ((cc & 0x80) == 0)
					{
						cc1 = (byte)s.ReadByte();
						plaincount = cc & 0x03;
						copycount = ((cc & 0x1C) >> 2) + 3;
						copyoffset = ((cc & 0x60) << 3) + cc1 + 1;
					}
					else if ((cc & 0x40) == 0)
					{
						cc1 = (byte)s.ReadByte();
						cc2 = (byte)s.ReadByte();
						plaincount = (cc1 & 0xC0) >> 6;
						copycount = (cc & 0x3F) + 4;
						copyoffset = ((cc1 & 0x3F) << 8) + cc2 + 1;
					}
					else if ((cc & 0x20) == 0)
					{
						cc1 = (byte)s.ReadByte();
						cc2 = (byte)s.ReadByte();
						cc3 = (byte)s.ReadByte();
						plaincount = cc & 0x03;
						copycount = ((cc & 0x0C) << 6) + cc3 + 5;
						copyoffset = ((cc & 0x10) << 12) + (cc1 << 8) + cc2 + 1;
					}
					else
					{
						plaincount = (cc - 0xDF) << 2;
						copycount = 0;
						copyoffset = 0;
					}

					for (int i = 0; i < plaincount; i++)
					{
						uncdata[uncindex++] = (byte)s.ReadByte();
					}

					int source = uncindex - copyoffset;
					for (int i = 0; i < copycount; i++)
					{
						uncdata[uncindex++] = uncdata[source++];
					}
				} //while
			} //try
			catch (Exception ex)
			{
				//Helper.ExceptionMessage("", ex);
				throw ex;
			}

			if (s.Position < end)
			{
				plaincount = s.ReadByte() & 0x03;
				for (int i = 0; i < plaincount; i++)
				{
					if (uncindex >= uncdata.Length)
					{
						break;
					}

					uncdata[uncindex++] = (byte)s.ReadByte();
				}
			}
			return new System.IO.MemoryStream(uncdata);
		}

		#endregion

		#region compression
		//some Compression Data
		const int MAX_OFFSET = 0x20000;
		const int MAX_COPY_COUNT = 0x404;

		/// <summary>
		/// Returns /Sets the compression Strength
		/// </summary>
		public static int CompressionStrength { get; set; } = 0x80;

		/// <summary>
		/// Compresses the passed content
		/// </summary>
		/// <param name="data">The content</param>
		/// <param name="pkgver">The Version of the package the compressed Data will be stored in</param>
		/// <returns>the compressed Data (including the header)</returns>
		public static byte[] Compress(byte[] data)
		{
			try
			{
				//return Comp(data, true);
				#region Init Variables
				//contains the latest offset for a combination of two characters
				ArrayList[] cmpmap = new ArrayList[0x1000000];

				//will contain the compressed Data
				byte[] cdata = new byte[data.Length];

				//init some vars
				int writeindex = 0;
				int lastreadindex = 0;
				ArrayList indexlist = null;
				int copyoffset = 0;
				int copycount = 0;
				writeindex = 0;
				int index = -1;
				lastreadindex = 0;
				byte[] retdata;
				bool end = false;
				#endregion
				try
				{
					//begin main Compression Loop
					while (index < data.Length - 3)
					{
						#region get all Compression Candidates (list of offsets for all occurances of the current 3 bytes)
						do
						{
							index++;
							if (index >= data.Length - 2)
							{
								end = true;
								break;
							}
							int mapindex =
								data[index]
								| (data[index + 1] << 0x08)
								| (data[index + 2] << 0x10);

							indexlist = cmpmap[mapindex];
							if (indexlist == null)
							{
								indexlist = new ArrayList();
								cmpmap[mapindex] = indexlist;
							}
							indexlist.Add(index);
						} while (index < lastreadindex);
						if (end)
						{
							break;
						}

						#endregion

						#region find the longest repeating byte sequence in the index List (for offset copy)
						int offsetcopycount = 0;
						int loopcount = 1;
						while (
							(loopcount < indexlist.Count) && (loopcount < CompressionStrength)
						)
						{
							int foundindex = (int)
								indexlist[indexlist.Count - 1 - loopcount];
							if ((index - foundindex) >= MAX_OFFSET)
							{
								break;
							}

							loopcount++;
							copycount = 3;
							while (
								(data.Length > index + copycount)
								&& (
									data[index + copycount]
									== data[foundindex + copycount]
								)
								&& (copycount < MAX_COPY_COUNT)
							)
							{
								copycount++;
							}

							if (copycount > offsetcopycount)
							{
								int cof = index - foundindex;
								offsetcopycount = copycount;
								copyoffset = index - foundindex;
							}
						}
						#endregion

						#region Compression

						//check if we can compress this
						if (offsetcopycount < 3)
						{
							offsetcopycount = 0;
						}
						else if ((offsetcopycount < 4) && (copyoffset > 0x400))
						{
							offsetcopycount = 0;
						}
						else if ((offsetcopycount < 5) && (copyoffset > 0x4000))
						{
							offsetcopycount = 0;
						}

						//this is offset-compressable? so do the compression
						if (offsetcopycount > 0)
						{
							//plaincopy
							while ((index - lastreadindex) > 3)
							{
								copycount = index - lastreadindex;
								while (copycount > 0x71)
								{
									copycount -= 0x71;
								}

								copycount &= 0xfc;
								int realcopycount = copycount >> 2;

								cdata[writeindex++] = (byte)(0xdf + realcopycount);
								for (int i = 0; i < copycount; i++)
								{
									cdata[writeindex++] = data[lastreadindex++];
								}
							}

							//offsetcopy
							copycount = index - lastreadindex;
							copyoffset--;
							if ((offsetcopycount <= 0xa) && (copyoffset < 0x400))
							{
								cdata[writeindex++] = (byte)(

										((copyoffset >> 3) & 0x60)
										| ((offsetcopycount - 3) << 2)
									 | copycount
								);
								cdata[writeindex++] = (byte)(copyoffset & 0xff);
							}
							else if ((offsetcopycount <= 0x43) && (copyoffset < 0x4000))
							{
								cdata[writeindex++] = (byte)(
									0x80 | (offsetcopycount - 4)
								);
								cdata[writeindex++] = (byte)(
									(copycount << 6) | (copyoffset >> 8)
								);
								cdata[writeindex++] = (byte)(copyoffset & 0xff);
							}
							else if (
								(offsetcopycount <= MAX_COPY_COUNT)
								&& (copyoffset < MAX_OFFSET)
							)
							{
								cdata[writeindex++] = (byte)(
									(
										(0xc0 | ((copyoffset >> 0x0c) & 0x10))
										+ (((offsetcopycount - 5) >> 6) & 0x0c)
									) | copycount
								);
								cdata[writeindex++] = (byte)((copyoffset >> 8) & 0xff);
								cdata[writeindex++] = (byte)(copyoffset & 0xff);
								cdata[writeindex++] = (byte)(
									(offsetcopycount - 5) & 0xff
								);
							}
							else
							{
								copycount = 0;
								offsetcopycount = 0;
							}

							//do the offset copy
							for (int i = 0; i < copycount; i++)
							{
								cdata[writeindex++] = data[lastreadindex++];
							}

							lastreadindex += offsetcopycount;
						}
						#endregion
					} //while (main Loop)
					#region Add remaining Data
					//add the End Record
					index = data.Length;
					lastreadindex = Math.Min(index, lastreadindex);
					while ((index - lastreadindex) > 3)
					{
						copycount = index - lastreadindex;
						while (copycount > 0x71)
						{
							copycount -= 0x71;
						}

						copycount &= 0xfc;
						int realcopycount = copycount >> 2;

						cdata[writeindex++] = (byte)(0xdf + realcopycount);
						for (int i = 0; i < copycount; i++)
						{
							cdata[writeindex++] = data[lastreadindex++];
						}
					}

					copycount = index - lastreadindex;
					cdata[writeindex++] = (byte)(0xfc + copycount);
					for (int i = 0; i < copycount; i++)
					{
						cdata[writeindex++] = data[lastreadindex++];
					}
					#endregion

					#region Trim Data & and add Header
					//make a resulting Array of the apropriate size
					retdata = new byte[writeindex + 9];

					byte[] sz = BitConverter.GetBytes((uint)retdata.Length);
					for (int i = 0; i < 4; i++)
					{
						retdata[i] = sz[i];
					}

					sz = BitConverter.GetBytes(SimPe.Data.MetaData.COMPRESS_SIGNATURE);
					for (int i = 0; i < 2; i++)
					{
						retdata[i + 4] = sz[i];
					}

					sz = BitConverter.GetBytes((uint)data.Length);
					for (int i = 0; i < 3; i++)
					{
						retdata[i + 6] = sz[2 - i];
					}

					for (int i = 0; i < writeindex; i++)
					{
						retdata[i + 9] = cdata[i];
					}
					#endregion
					return retdata;
				}
				finally
				{
					foreach (ArrayList a in cmpmap)
					{
						a?.Clear();
					}

					cmpmap = null;
					cdata = null;
					retdata = null;
					indexlist?.Clear();

					indexlist = null;
				}
			}
			catch (Exception ex)
			{
#if DEBUG
				Helper.ExceptionMessage(ex);
#endif
				throw ex;
			}
		}
		#endregion

		#region IDisposable Member

		public void Dispose()
		{
			data = null;
			uncdata = null;
		}

		#endregion
	}
}
