// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Packages
{
	/// <summary>
	/// Index Informations stored in the Header
	/// </summary>
	public class HeaderIndex
		: HeaderHole,
			Interfaces.Files.IPackageHeaderIndex,
			IDisposable
	{
		internal HeaderIndex(Interfaces.Files.IPackageHeader hd)
		{
			Parent = hd;
		}

		/// <summary>
		/// IndexType of the File
		/// </summary>
		internal int type;

		/// <summary>
		/// returns the Index Type of the File
		/// </summary>
		/// <remarks>This value should be 7</remarks>
		public int Type
		{
			get => type;
			set => type = value;
		}

		public override int ItemSize
		{
			get
			{
				if (Parent.IndexType == Data.IndexTypes.ptLongFileIndex)
				{
					return 6 * 4;
				}
				else if (
					Parent.IndexType == Data.IndexTypes.ptShortFileIndex
				)
				{
					return 5 * 4;
				}

				return base.ItemSize;
			}
		}

		internal Interfaces.Files.IPackageHeader Parent
		{
			get;
		}

		internal void UseInParent()
		{
			if (Parent == null)
			{
				return;
			}

			if (Parent is HeaderData)
			{
				HeaderData hd = Parent as HeaderData;
				hd.index = this;
			}
		}

		public virtual void Dispose()
		{
		}
	}
}
