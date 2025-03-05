// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

using SimPe.Interfaces.Scenegraph;

namespace SimPe.Plugin
{
	/// <summary>
	/// This is a Item describing the File
	/// </summary>
	public class FileIndexItem : IScenegraphFileIndexItem, IComparer, IDisposable
	{
		uint localgr;

		/// <summary>
		/// The Descriptor of that File
		/// </summary>
		/// <remarks>Contains the original Group (can be 0xffffffff)</remarks>
		public Interfaces.Files.IPackedFileDescriptor FileDescriptor
		{
			get; set;
		}

		/// <summary>
		/// The Descriptor of that File, with a real Group value
		/// </summary>
		/// <returns>A Clonde FileDescriptor, that contains the correct Group</returns>
		/// <remarks>Contains the local Group (can never be 0xffffffff)</remarks>
		public Interfaces.Files.IPackedFileDescriptor GetLocalFileDescriptor()
		{
			Interfaces.Files.IPackedFileDescriptor p =
				FileDescriptor.Clone();
			p.Group = LocalGroup;
			return p;
		}

		/// <summary>
		/// The package the File is stored in
		/// </summary>
		public Interfaces.Files.IPackageFile Package
		{
			get; private set;
		}

		/// <summary>
		/// Get the Local Group Value used for this Package
		/// </summary>
		public uint LocalGroup => FileDescriptor.Group == Data.MetaData.LOCAL_GROUP ? localgr : FileDescriptor.Group;

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="pfd">the Descriptor</param>
		/// <param name="package">the package</param>
		public FileIndexItem(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			if (pfd == null)
			{
				pfd = new Packages.PackedFileDescriptor();
			}

			if (package == null)
			{
				package = Packages.File.LoadFromStream(
					null
				);
			}

			FileDescriptor = pfd;
			Package = package;

			localgr = FileIndex.GetLocalGroup(package);
		}

		public override string ToString()
		{
			return FileDescriptor != null ? FileDescriptor.Filename : Localization.Manager.GetString("unknown");
		}

		public override int GetHashCode()
		{
			return FileDescriptor.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			if (obj.GetType() == typeof(FileIndexItem))
			{
				FileIndexItem fii = (FileIndexItem)obj;
				if (fii.FileDescriptor == null)
				{
					return FileDescriptor == null;
				}

				if (fii.LocalGroup != LocalGroup)
				{
					return false;
				}

				bool res = fii.FileDescriptor.Equals(FileDescriptor);

				//null Values for Packages
				if (fii.Package == null)
				{
					return Package == null && res;
				}
				else if (Package == null)
				{
					return false;
				}

				//null Values for FileNames
				/*if (fii.Package.FileName==null)
				{
					if (Package.FileName!=null) return false;
					else return true;
				} else if (Package.FileName==null) return false;*/

				return res && fii.Package.Equals(Package);
			}
			else
			{
				return base.Equals(obj);
			}
		}

		/// <summary>
		/// returns a String that can identify this Instance
		/// </summary>
		/// <returns></returns>
		public string GetLongHashCode()
		{
			return FileDescriptor.ToString() + "-" + (Package.FileName ?? "");
		}

		#region IComparer Member

		public int Compare(object x, object y)
		{
			if (
				x.GetType() == typeof(FileIndexItem)
				&& y.GetType() == typeof(FileIndexItem)
			)
			{
				FileIndexItem a = (FileIndexItem)x;
				FileIndexItem b = (FileIndexItem)y;

				return (int)(
					a.FileDescriptor.Instance - (long)b.FileDescriptor.Instance
				);
			}
			return 0;
		}

		#endregion

		public void Dispose()
		{
			FileDescriptor = null;
			Package = null;
		}
	}
}
