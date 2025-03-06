// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces.Files;
using SimPe.PackedFiles.Cpf;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for MmatWrapper.
	/// </summary>
	public class MmatWrapper
		: Cpf,
			Interfaces.Scenegraph.IScenegraphBlock,
			Interfaces.Scenegraph.IScenegraphItem
	{
		public static CpfUI.ExecutePreview GlobalCpfPreview
		{
			get; set;
		}

		#region IScenegraphBlock Member

		public void ReferencedItems(
			Dictionary<string, List<IPackedFileDescriptor>> refmap,
			uint parentgroup
		)
		{
			List<IPackedFileDescriptor> list = new List<IPackedFileDescriptor>();
			string name = GetSaveItem("modelName").StringValue.Trim();
			if (!name.ToLower().EndsWith("_cres"))
			{
				name += "_cres";
			}

			list.Add(
				ScenegraphHelper.BuildPfd(
					name,
					FileTypes.CRES,
					parentgroup
				)
			);
			refmap["CRES"] = list;

			list = new List<IPackedFileDescriptor>();
			name = GetSaveItem("name").StringValue.Trim();
			if (!name.ToLower().EndsWith("_txmt"))
			{
				name += "_txmt";
			}

			list.Add(
				ScenegraphHelper.BuildPfd(
					name,
					FileTypes.TXMT,
					parentgroup
				)
			);
			refmap["TXMT"] = list;
		}

		/// <summary>
		/// Registers the Object in the given Hashtable
		/// </summary>
		/// <param name="listing"></param>
		/// <returns>The Name of the Class Type</returns>
		public string Register(Hashtable listing)
		{
			return "";
		}
		#endregion

		protected override Interfaces.Plugin.IPackedFileUI CreateDefaultUIHandler()
		{
			return new CpfUI(GlobalCpfPreview);
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override Interfaces.Plugin.IWrapperInfo CreateWrapperInfo()
		{
			return new Interfaces.Plugin.AbstractWrapperInfo(
				"MMAT Wrapper",
				"Quaxi",
				"This File describes a ColorOption for a Mesh Group / Subset. It is needed to provide an additional Colour for Objects.",
				4,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.mmat.png")
				)
			);
		}

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public override FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.MMAT };

		/// <summary>
		/// Load and return the referenced CRES File (null if none was available)
		/// </summary>
		/// <remarks>
		/// You should store this value in a temp var if you need it multiple times,
		/// as the File is reloaded with each call
		/// </remarks>
		public GenericRcol CRES
		{
			get
			{
				IPackedFileDescriptor cres = ReferenceChains["CRES"]?.FirstOrDefault();
				if (cres != null)
				{
					IPackedFileDescriptor pfd = package.FindFile(cres)
						?? package.FindFile(cres.Filename, Data.FileTypes.CRES).FirstOrDefault();

					if (pfd != null)
					{
						GenericRcol cresfile = new GenericRcol(null, false);
						cresfile.ProcessData(pfd, package);

						return cresfile;
					}
					else //FileTable fallback code
					{
						Interfaces.Scenegraph.IScenegraphFileIndexItem item =
							FileTableBase.FileIndex.FindFileDiscardingGroup(cres).FirstOrDefault();
						if (item != null)
						{
							GenericRcol cresfile = new GenericRcol(null, false);
							cresfile.ProcessData(
								item.FileDescriptor,
								item.Package
							);

							return cresfile;
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		/// Load and return the referenced TXMT File (null if none was available)
		/// </summary>
		/// <remarks>
		/// You should store this value in a temp var if you need it multiple times,
		/// as the File is reloaded with each call
		/// </remarks>
		public GenericRcol TXMT
		{
			get
			{
				IPackedFileDescriptor txmt = ReferenceChains["TXMT"]?.FirstOrDefault();
				if (txmt != null)
				{
					IPackedFileDescriptor pfd = package.FindFile(txmt)
						?? package.FindFile(txmt.Filename, Data.FileTypes.TXMT).FirstOrDefault();

					if (pfd != null)
					{
						GenericRcol txmtfile = new GenericRcol(null, false);
						txmtfile.ProcessData(pfd, package);

						return txmtfile;
					}
					else //FileTable fallback code
					{
						Interfaces.Scenegraph.IScenegraphFileIndexItem item =
							FileTableBase.FileIndex.FindFileDiscardingGroup(txmt).FirstOrDefault();
						if (item != null)
						{
							GenericRcol txmtfile = new GenericRcol(null, false);
							txmtfile.ProcessData(
								item.FileDescriptor,
								item.Package
							);

							return txmtfile;
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		/// Load a Texture belonging to a TXMT
		/// </summary>
		/// <param name="txmt">a valid txmt</param>
		/// <returns>the Texture or null</returns>
		public GenericRcol GetTxtr(GenericRcol txmt)
		{
			IPackedFileDescriptor txtr = txmt?.ReferenceChains["stdMatBaseTextureName"]?.FirstOrDefault();
			if (txtr != null)
			{
				IPackedFileDescriptor pfd = package.FindFile(txtr)
					?? package.FindFile(txtr.Filename, Data.FileTypes.TXMT).FirstOrDefault();

				if (pfd != null)
				{
					GenericRcol txtrfile = new GenericRcol(null, false);
					txtrfile.ProcessData(pfd, package);

					return txtrfile;
				}
				else //FileTable fallback code
				{
					Interfaces.Scenegraph.IScenegraphFileIndexItem item =
						FileTableBase.FileIndex.FindFileDiscardingGroup(txtr).FirstOrDefault();
					if (item != null)
					{
						GenericRcol txtrfile = new GenericRcol(null, false);
						txtrfile.ProcessData(
							item.FileDescriptor,
							item.Package
						);

						return txtrfile;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Load and return the referenced TXTR File (through the TXMT, null if none was available)
		/// </summary>
		/// <remarks>
		/// You should store this value in a temp var if you need it multiple times,
		/// as the File is reloaded with each call
		/// </remarks>
		public GenericRcol TXTR => GetTxtr(TXMT);

		protected void FindRcolr(IPackedFileDescriptor pfd)
		{
		}

		protected GenericRcol GetGmdc()
		{
			IPackedFileDescriptor shp = CRES?.ReferenceChains["Generic"]?.FirstOrDefault();
			Interfaces.Scenegraph.IScenegraphFileIndexItem item = FileTableBase.FileIndex.FindFile(shp, null).FirstOrDefault();
			if (item != null)
			{
				GenericRcol shpe = new GenericRcol(null, false);
				shpe.ProcessData(item.FileDescriptor, item.Package);
				IPackedFileDescriptor gmnd = shpe.ReferenceChains["Models"]?.FirstOrDefault();
				if (gmnd != null)
				{
					Interfaces.Scenegraph.IScenegraphFileIndexItem item1 = FileTableBase.FileIndex.FindFile(gmnd, null).FirstOrDefault();
					if (item1 != null)
					{
						GenericRcol gmndfile = new GenericRcol(null, false);
						gmndfile.ProcessData(item1.FileDescriptor, item1.Package);
						IPackedFileDescriptor gmdc = gmndfile.ReferenceChains["Generic"]?.FirstOrDefault();
						if (gmdc != null)
						{
							Interfaces.Scenegraph.IScenegraphFileIndexItem item2 = FileTableBase.FileIndex.FindFile(gmdc, null).FirstOrDefault();
							if (item2 != null)
							{
								GenericRcol gmdcfile = new GenericRcol(null, false);
								gmdcfile.ProcessData(item2.FileDescriptor, item2.Package);
								return gmdcfile;
							}
						}
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Load and return the used GMDC File (through the CRES, null if none was available)
		/// </summary>
		/// <remarks>
		/// You should store this value in a temp var if you need it multiple times,
		/// as the File is reloaded with each call
		/// </remarks>
		public GenericRcol GMDC => GetGmdc();

		public override string Description
		{
			get
			{
				string str =
					"objectGUID=0x"
					+ Helper.HexString(ObjectGUID)
					+ "; subset="
					+ SubsetName
					+ "; references=";
				Dictionary<string, List<IPackedFileDescriptor>> map = ReferenceChains;
				foreach (string s in map.Keys)
				{
					str += s + ":";
					foreach (IPackedFileDescriptor pfd in map[s])
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

		#region IScenegraphItem Member

		public Dictionary<string, List<IPackedFileDescriptor>> ReferenceChains
		{
			get
			{
				Dictionary<string, List<IPackedFileDescriptor>> refmap = new Dictionary<string, List<IPackedFileDescriptor>>();
				ReferencedItems(refmap, FileDescriptor.Group);
				return refmap;
			}
		}

		#endregion

		#region Default Attribute
		public string Creator
		{
			get => GetSaveItem("creator").StringValue;
			set => GetSaveItem("creator").StringValue = value;
		}

		public bool DefaultMaterial
		{
			get => GetSaveItem("defaultMaterial").BooleanValue;
			set => GetSaveItem("defaultMaterial").BooleanValue = value;
		}

		public string Family
		{
			get => GetSaveItem("family").StringValue;
			set => GetSaveItem("family").StringValue = value;
		}

		public uint Flags
		{
			get => GetSaveItem("flags").UIntegerValue;
			set => GetSaveItem("flags").UIntegerValue = value;
		}

		public uint MaterialStateFlags
		{
			get => GetSaveItem("materialStateFlags").UIntegerValue;
			set => GetSaveItem("materialStateFlags").UIntegerValue = value;
		}

		public string ModelName
		{
			get => GetSaveItem("modelName").StringValue;
			set => GetSaveItem("modelName").StringValue = value;
		}

		public string Name
		{
			get => GetSaveItem("name").StringValue;
			set => GetSaveItem("name").StringValue = value;
		}

		public uint ObjectGUID
		{
			get => GetSaveItem("objectGUID").UIntegerValue;
			set => GetSaveItem("objectGUID").UIntegerValue = value;
		}

		public int ObjectStateIndex
		{
			get => GetSaveItem("objectStateIndex").IntegerValue;
			set => GetSaveItem("objectStateIndex").IntegerValue = value;
		}

		public string SubsetName
		{
			get => GetSaveItem("subsetName").StringValue;
			set => GetSaveItem("subsetName").StringValue = value;
		}
		#endregion
	}
}
