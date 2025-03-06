// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Scenegraph;

namespace SimPe.Plugin
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class GenericRcol : Rcol, IScenegraphItem
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public GenericRcol(Interfaces.IProviderRegistry provider, bool fast)
			: base(provider, fast) { }

		public GenericRcol()
			: base() { }

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new RcolUI();
		}
		#endregion


		#region IFileWrapper Member
		public override string Description
		{
			get
			{
				string str = "filename=";
				str += FileName;
				str += ", references=";
				Dictionary<string, List<Interfaces.Files.IPackedFileDescriptor>> map = ReferenceChains;
				foreach (string s in map.Keys)
				{
					str += s + ": ";
					foreach (
						Interfaces.Files.IPackedFileDescriptor pfd in map[s]
					)
					{
						str += pfd.Filename + " (" + pfd.ToString() + ") | ";
					}
					if (map[s].Count > 0)
					{
						str = str.Substring(0, str.Length - 2);
					}

					str += ",";
				}
				if (map.Count > 0)
				{
					str = str.Substring(0, str.Length - 1);
				}

				return str;
			}
		}

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public override FileTypes[] AssignableTypes => new FileTypes[]
				{
					FileTypes.TXMT,
					FileTypes.CRES,
					FileTypes.GMND,
					FileTypes.GMDC,
					FileTypes.SHPE,
					FileTypes.ANIM,
					FileTypes.CINE,
					FileTypes.LDIR,
					FileTypes.LAMB,
					FileTypes.LPNT,
					FileTypes.LSPT,
				};

		#endregion

		/// <summary>
		/// Subcallses can reimplement this Method to add additional References
		/// </summary>
		/// <param name="refmap">The Reference Map, Keys are the name of the Reference type, values are ArrayLists containing IPackedFileDescriptors</param>
		protected virtual void FindReferences(Dictionary<string, List<Interfaces.Files.IPackedFileDescriptor>> refmap)
		{
		}

		/// <summary>
		/// Add te References stored in the Reference Section
		/// </summary>
		/// <param name="refmap">The Reference Map, Keys are the name of the Reference type, values are ArrayLists containing IPackedFileDescriptors</param>
		void FindGenericReferences(Dictionary<string, List<Interfaces.Files.IPackedFileDescriptor>> refmap)
		{
			refmap["Generic"] = new List<Interfaces.Files.IPackedFileDescriptor>(ReferencedFiles);

			//now check each stored block if it implements IScenegraphBlock
			foreach (IRcolBlock irb in Blocks)
			{
				if (irb is IScenegraphBlock sgb)
				{
					sgb.ReferencedItems(refmap, FileDescriptor.Group);
				}
			}
		}

		#region IScenegraphItem Member
		public IScenegraphFileIndexItem FindReferencedType(
			FileTypes type
		)
		{
			foreach (List<Interfaces.Files.IPackedFileDescriptor> list in ReferenceChains.Values)
			{
				foreach (Interfaces.Files.IPackedFileDescriptor o in list)
				{
					Interfaces.Files.IPackedFileDescriptor opfd = o;
					if (opfd.Type == type)
					{
						Interfaces.Files.IPackedFileDescriptor pfd = Package.FindFile(
							opfd
						);
						if (pfd == null)
						{
							opfd.Group = FileDescriptor.Group;
							pfd = Package.FindFile(opfd);
						}
						if (pfd == null)
						{
							opfd.Group = Data.MetaData.LOCAL_GROUP;
							pfd = Package.FindFile(opfd);
						}
						IScenegraphFileIndexItem item;
						if (pfd == null)
						{
							FileTableBase.FileIndex.Load();
							item = FileTableBase.FileIndex.FindFile(
									o,
									null
								).FirstOrDefault();
						}
						else
						{
							item = FileTableBase.FileIndex.CreateFileIndexItem(pfd, Package);
						}

						if (item != null)
						{
							return item;
						}
					}
				}
			}

			return null;
		}

		public Dictionary<string, List<Interfaces.Files.IPackedFileDescriptor>> ReferenceChains
		{
			get
			{
				Dictionary<string, List<Interfaces.Files.IPackedFileDescriptor>> refmap = new Dictionary<string, List<Interfaces.Files.IPackedFileDescriptor>>();
				FindGenericReferences(refmap);
				FindReferences(refmap);
				return refmap;
			}
		}

		#endregion
	}
}
