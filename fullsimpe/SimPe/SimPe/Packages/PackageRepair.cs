// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using SimPe.Data;

namespace SimPe.Packages
{
	public class IndexDetails
	{
		protected Interfaces.Files.IPackageHeader hd;

		internal IndexDetails(Interfaces.Files.IPackageHeader hd)
		{
			this.hd = hd;
		}

		/// <summary>
		/// Returns the Identifier of the File
		/// </summary>
		/// <remarks>This value should be DBPF</remarks>
		public string Identifier => hd.Identifier;

		/// <summary>
		/// Returns the Overall Version of this Package
		/// </summary>
		public string Version => $"0x{hd.Version:X16}";

		/// <summary>
		/// Returns or Sets the Type of the Package
		/// </summary>
		public Data.IndexTypes IndexType
		{
			get => hd.IndexType;
			set => hd.IndexType = value;
		}

		/// <summary>
		/// This is missused in SimPe as a Unique Creator ID
		/// </summary>
		public string Ident => "0x" + Helper.HexString(hd.Created);

		/// <summary>
		/// Expansion Pack Icon Used by Lots in the Lot Catalogue
		/// </summary>
		public short EPIcon
		{
			get => hd.Epicon;
			set => hd.Epicon = value;
		}

		/// <summary>
		/// Used by Lots in the Lot Catalogue, true (1) determines the Icon value is valid
		/// </summary>
		public short ShowIcon
		{
			get => hd.Showicon;
			set
			{
				hd.Showicon = value > 0 ? (short)1 : (short)0;
			}
		}
	}

	public class IndexDetailsAdvanced : IndexDetails
	{
		internal IndexDetailsAdvanced(Interfaces.Files.IPackageHeader hd)
			: base(hd) { }

		public string IndexOffset => "0x" + Helper.HexString(hd.Index.Offset);

		public string IndexSize => "0x" + Helper.HexStringInt(hd.Index.Size);

		public int ResourceCount => hd.Index.Count;

		public string IndexVersion => "0x" + Helper.HexStringInt(hd.Index.Type);

		public string IndexItemSize => "0x"
					+ Helper.HexStringInt(hd.Index.ItemSize)
					+ " (0x"
					+ Helper.HexStringInt(hd.Index.Size / hd.Index.Count)
					+ ")";

		/// <summary>
		/// Returns the Major Version of The Packages FileFormat
		/// </summary>
		/// <remarks>This value should be 1</remarks>
		public int MajorVersion => hd.MajorVersion;

		/// <summary>
		/// Returns the Minor Version of The Packages FileFormat
		/// </summary>
		/// <remarks>This value should be 0 or 1</remarks>
		public int MinorVersion => hd.MinorVersion;
	}

	/// <summary>
	/// This offers some Repair Methods for .packages
	/// </summary>
	public class PackageRepair : System.IDisposable
	{
		Interfaces.Files.IPackageFile pkg;
		static IEnumerable<FileTypes> types = (IEnumerable<FileTypes>)Enum.GetValues(typeof(FileTypes));

		public PackageRepair(Interfaces.Files.IPackageFile pkg)
		{
			this.pkg = pkg;
			InitTypes();
		}

		void InitTypes()
		{
		}

		bool CouldBeIndexItem(BinaryReader br, long pos, int step, bool strict)
		{
			if (pos < 0)
			{
				return false;
			}

			for (int i = 0; i < 4; i++)
			{
				br.BaseStream.Seek(pos + (i * step), SeekOrigin.Begin);
				PackedFileDescriptor pfd = new PackedFileDescriptor();
				pfd.LoadFromStream(pkg.Header, br);

				if (!types.Contains(pfd.Type))
				{
					return false;
				}

				if (pfd.Size <= 0)
				{
					return false;
				}

				if (pfd.Offset <= 0 || pfd.Offset >= br.BaseStream.Length)
				{
					return false;
				}

				if (strict)
				{
					if (pfd.Type == 0x00000000)
					{
						return false;
					}

					if (pfd.Type == FileTypes.ALL_TYPES)
					{
						return false;
					}
				}
			}

			return true;
		}

		/// <summary>
		/// Returns the Offset of the ResourceIndex in the current package
		/// </summary>
		/// <returns></returns>
		public HeaderIndex FindIndexOffset()
		{
			HeaderIndex hi = new HeaderIndex(pkg.Header);

			if (pkg is File)
			{
				((File)pkg).ReloadReader();
			}

			BinaryReader br = pkg.Reader;
			int step = 0x18;
			if (pkg.Header.IndexType == Data.IndexTypes.ptShortFileIndex)
			{
				step = 0x14;
			}

			long pos = br.BaseStream.Length - ((4 * step) + 1);

			long lastitem = -1;
			long firstitem = -1;
			WaitingScreen.Wait();

			try
			{
				while (pos > 0x04)
				{
					WaitingScreen.UpdateMessage(
						"0x"
							+ $"{pos:X16}"
							+ " / 0x"
							+ $"{br.BaseStream.Length:X16}"
					);

					bool hit = CouldBeIndexItem(br, pos, step, lastitem == -1);
					if (hit && lastitem == -1)
					{
						lastitem = br.BaseStream.Position;
					}

					if (!hit && lastitem != -1)
					{
						firstitem = pos + step;
						break;
					}

					if (lastitem == -1)
					{
						pos--;
					}
					else
					{
						pos -= step;
					}
				}
			}
			finally
			{
				WaitingScreen.Stop();
			}

			hi.offset = (uint)firstitem;
			hi.size = (int)(lastitem - firstitem);
			hi.count = hi.size / step;

			if (firstitem == -1)
			{
				hi = pkg.Header.Index as HeaderIndex;
			}

			return hi;
		}

		public void UseIndexData(HeaderIndex hi)
		{
			if (hi.Parent == pkg.Header && Package != null)
			{
				hi.UseInParent();
				((HeaderData)hi.Parent).LockIndexDuringLoad = true;
				Package.Reload();
				((HeaderData)hi.Parent).LockIndexDuringLoad = false;
			}
		}

		public IndexDetails IndexDetails => new IndexDetails(pkg.Header);

		public IndexDetailsAdvanced IndexDetailsAdvanced => new IndexDetailsAdvanced(pkg.Header);

		public GeneratableFile Package => pkg is GeneratableFile file ? file : null;

		#region IDisposable Member

		public void Dispose()
		{
			pkg = null;
		}

		#endregion
	}
}
