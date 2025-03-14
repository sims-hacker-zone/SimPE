// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using SimPe.Data;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Str;
using SimPe.PackedFiles.ThreeIdr;

namespace SimPe.Plugin
{
	public class PackageInfo : AbstractCpfInfo, IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed = false;

		private IPackageFile package;
		private Str stringList;

		public IPackageFile Package
		{
			get => package;
			set
			{
				package = value;
				ProcessPackage(value);
			}
		}

		public string Description
		{
			get
			{
				if (stringList != null)
				{
					List<StrToken> items = stringList.Items;
					if (!Utility.IsNullOrEmpty(items))
					{
						return items[0].Title;
					}
				}
				return string.Empty;
			}
			set
			{
				if (stringList != null)
				{
					List<StrToken> items = stringList.Items;

					if (!Utility.IsNullOrEmpty(items))
					{
						items[0].Title = value;
					}
					else
					{
						StrToken item = new StrToken(
							0,
							Convert.ToByte(Languages.English),
							value,
							string.Empty
						);
						stringList.Add(item);
					}
				}
			}
		}

		public List<RecolorItem> RecolorItems
		{
			get; set;
		}

		public uint PackageHash
		{
			get; set;
		}

		private PackageInfo()
		{
		}

		public PackageInfo(IPackageFile package)
		{
			Package = package;
		}

		void ProcessPackage(IPackageFile package)
		{
			IPackedFileDescriptor[] strList = package.FindFiles(
				FileTypes.STR
			);
			if (Utility.IsNullOrEmpty(strList))
			{
				IPackedFileDescriptor textFile = CreateTextResource(package);
				if (textFile != null)
				{
					strList = new IPackedFileDescriptor[] { textFile };
				}
			}

			if (!Utility.IsNullOrEmpty(strList))
			{
				stringList = new Str().ProcessFile(strList[0], package);
			}

			IPackedFileDescriptor[] keyPfd = package.FindFiles(FileTypes.XHTN);
			if (Utility.IsNullOrEmpty(keyPfd))
			{
				keyPfd = package.FindFiles(FileTypes.XSTN);
			}

			if (!Utility.IsNullOrEmpty(keyPfd))
			{
				PropertySet = new Cpf().ProcessFile(keyPfd[0], package, false);

				//this.packageHash = this.GetPackageHash();
			}
		}

		public IPackedFileDescriptor[] FindFiles(FileTypes type)
		{
			return package != null ? package.FindFiles(type) : (new IPackedFileDescriptor[0]);
		}

		public override void CommitChanges()
		{
			base.CommitChanges();
			stringList?.SynchronizeUserData();
		}

		private uint GetPackageHash()
		{
			Random rn = new Random();
			uint ret = (uint)rn.Next(0xffffff) | 0xff000000u;
			foreach (IPackedFileDescriptor pfd in package.Index)
			{
				///This is a scenegraph Resource so get the Hash from there!
				if (MetaData.RcolList.Contains(pfd.Type))
				{
					using (Rcol rcol = new GenericRcol(null, false).ProcessFile(pfd, package))
					{
						ret = Hashes.GroupHash(rcol.FileName);
					}
					break;
				}
			}
			return ret;
		}

		/// <summary>
		/// Creates an empty text list resource and adds it to the specified package.
		/// </summary>
		/// <param name="package">An <see cref="IPackageFile"/> instance.</param>
		/// <returns>The FileDescriptor for the newly created text list.</returns>
		IPackedFileDescriptor CreateTextResource(IPackageFile package)
		{
			IPackedFileDescriptor ret = null;
			if (package == null)
			{
				return null;
			}

			uint group = GetScenegraphGroup(package);
			if (group != 0)
			{
				ret = package.NewDescriptor(
					FileTypes.STR,
					0x00000000u,
					group,
					0x00000001u
				);

				package.Add(ret, true);

				try
				{
					// link the newly created resource
					foreach (IPackedFileDescriptor pfd in package.FindFiles(
						FileTypes.THREE_IDR
					))
					{
						using (ThreeIdr refFile = new ThreeIdr().ProcessFile(pfd, package, false))
						{
							ArrayList temp = new ArrayList();
							foreach (IPackedFileDescriptor item in refFile.Items)
							{
								temp.Add(item);
								// insert reference node to TextList after the UIData node
								if (item.Type == 0)
								{
									temp.Add(ret);
								}
							}

							refFile.Items = (IPackedFileDescriptor[])
								temp.ToArray(typeof(IPackedFileDescriptor));

							refFile.SynchronizeUserData();
						}
					}
				}
				catch
				{
					package.Remove(ret);
					ret = null;
				}
			}

			return ret;
		}

		uint GetScenegraphGroup(IPackageFile package)
		{
			uint ret = 0;
			foreach (IPackedFileDescriptor pfd in this.package.Index)
			{
				if (MetaData.RcolList.Contains(pfd.Type))
				{
					ret = pfd.Group;
					break;
				}
			}

			return ret;
		}

		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					if (package is IDisposable)
					{
						((IDisposable)package).Dispose();
					}
				}
				disposed = true;
			}
		}

		#endregion
	}

	public class PackageInfoTable : ListDictionary, IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed = false;

		public new PackageInfo this[object key]
		{
			get => base[key] as PackageInfo;
			set => base[key] = value;
		}

		public PackageInfoTable()
		{
		}

		public void Add(object key, PackageInfo pnfo)
		{
			base.Add(key, pnfo);
		}

		public void RemovePackage(object key)
		{
			if (ContainsKey(key))
			{
				PackageInfo pnfo = this[key];
				pnfo.Dispose();
				Remove(key);
			}
		}

		public void RemoveAll()
		{
			foreach (PackageInfo pnfo in Values)
			{
				pnfo.Dispose();
			}

			Clear();
		}

		public bool ContainsKey(object key)
		{
			return Contains(key);
		}

		public bool ContainsValue(PackageInfo pnfo)
		{
			foreach (PackageInfo p in this)
			{
				if (p == pnfo)
				{
					return true;
				}
			}

			return false;
		}

		public bool ContainsPackage(IPackageFile package)
		{
			foreach (PackageInfo pnfo in Values)
			{
				if (ReferenceEquals(pnfo.Package, package))
				{
					return true;
				}
			}

			return false;
		}

		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					// Dispose managed resources.
					foreach (PackageInfo pnfo in Values)
					{
						if (pnfo.Package is IDisposable disposable)
						{
							disposable.Dispose();
						}
					}
				}
			}
			disposed = true;
		}

		#endregion
	}
}
