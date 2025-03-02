// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Collections.Specialized;

using SimPe.Interfaces.Files;
using SimPe.Interfaces.Scenegraph;
using SimPe.Packages;
using SimPe.PackedFiles.ThreeIdr;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for MeshTable.
	/// </summary>
	public class MeshTable : System.ComponentModel.Component
	{
		Hashtable loadedMeshes;
		Hashtable loadedReferences;

		public StringCollection FileNames
		{
			get
			{
				StringCollection ret = new StringCollection();
				foreach (string s in loadedMeshes.Keys)
				{
					ret.Add(System.IO.Path.GetFileName(s));
				}

				return ret;
			}
		}

		public MeshTable()
		{
			loadedMeshes = new Hashtable();
			loadedReferences = new Hashtable();
		}

		public MeshTable(System.ComponentModel.IContainer container)
			: this()
		{
			container?.Add(this);
		}

		public IPackageFile LoadMesh(string filePath)
		{
			IPackageFile file = null;
			if (!loadedMeshes.ContainsKey(filePath))
			{
				file = File.LoadFromFile(filePath);
				MeshInfo[] meshes = GetMeshReferences(file);
				if (meshes.Length > 0)
				{
					loadedMeshes[filePath] = file;
					loadedReferences[filePath] = meshes;
				}
			}
			else
			{
				file = FindPackage(filePath);
			}

			return file;
		}

		public bool ValidatePackage(IPackageFile meshPackage)
		{
			return GetMeshReferences(meshPackage).Length > 0;
		}

		public bool IsLoaded(string filePath)
		{
			return loadedMeshes.ContainsKey(filePath);
		}

		public bool IsLoaded(IPackageFile meshPackage)
		{
			return loadedMeshes.ContainsValue(meshPackage);
		}

		public void ApplyMesh(RecolorItem item, MeshInfo mesh)
		{
			if (item.PropertySet == null)
			{
				return;
			}

			if (
				!item.ContainsItem("resourcekeyidx")
				|| !item.ContainsItem("shapekeyidx")
			)
			{
				return;
			}

			//MeshInfo nodes = this.GetMeshReferences(meshPackage);
			if (mesh != null)
			{
				IPackedFileDescriptor pfd = Get3IDRResource(item);
				if (pfd != null)
				{
					ThreeIdr refFile = new ThreeIdr();
					refFile.ProcessData(pfd, item.PropertySet.Package, false);

					int idxCres = item.GetProperty("resourcekeyidx").IntegerValue;
					int idxShpe = item.GetProperty("shapekeyidx").IntegerValue;

					refFile.Items[idxCres] = mesh.ResourceNode;
					refFile.Items[idxShpe] = mesh.ShapeFile;

					refFile.SynchronizeUserData();
				}
			}
		}

		public void Clear()
		{
			loadedMeshes.Clear();
			loadedReferences.Clear();
		}

		public IPackageFile FindPackage(string filePathOrName)
		{
			if (!loadedMeshes.ContainsKey(filePathOrName))
			{
				foreach (DictionaryEntry de in loadedMeshes)
				{
					if (
						string.Compare(
							System.IO.Path.GetFileName(Convert.ToString(de.Key)),
							System.IO.Path.GetFileName(filePathOrName),
							true
						) == 0
					)
					{
						return (IPackageFile)de.Value;
					}
				}
			}
			else
			{
				return (IPackageFile)loadedMeshes[filePathOrName];
			}
			return null;
		}

		public MeshInfo[] FindMeshes(string filePathOrName)
		{
			if (!loadedReferences.ContainsKey(filePathOrName))
			{
				foreach (DictionaryEntry de in loadedReferences)
				{
					if (
						string.Compare(
							System.IO.Path.GetFileName(Convert.ToString(de.Key)),
							System.IO.Path.GetFileName(filePathOrName),
							true
						) == 0
					)
					{
						return (MeshInfo[])de.Value;
					}
				}
			}
			else
			{
				return (MeshInfo[])loadedReferences[filePathOrName];
			}
			return null;
		}

		public MeshInfo FindMeshByName(string name)
		{
			foreach (MeshInfo[] meshes in loadedReferences.Values)
			{
				foreach (MeshInfo mesh in meshes)
				{
					if (string.Compare(mesh.Description, name, true) == 0)
					{
						return mesh;
					}
				}
			}

			return null;
		}

		IPackedFileDescriptor Get3IDRResource(RecolorItem item)
		{
			if (item.PropertySet != null)
			{
				IPackedFileDescriptor[] pfds = Utility.FindFiles(
					item.PropertySet.Package,
					Data.MetaData.REF_FILE,
					item.PropertySet.FileDescriptor.Group,
					item.PropertySet.FileDescriptor.Instance
				);
				if (pfds.Length == 1)
				{
					return pfds[0];
				}
			}
			return null;
		}

		/// <summary>
		/// Gets the mesh references.
		/// </summary>
		/// <param name="items">Items.</param>
		public MeshInfo[] GetMeshReferences(RecolorItem[] items)
		{
			ArrayList ret = new ArrayList();

			ArrayList tidr = new ArrayList();
			foreach (RecolorItem item in items)
			{
				if (
					!item.ContainsItem("resourcekeyidx")
					|| !item.ContainsItem("shapekeyidx")
				)
				{
					continue;
				}

				IPackedFileDescriptor idr = Get3IDRResource(item);
				if (idr != null)
				{
					ThreeIdr refFile = new ThreeIdr();
					refFile.ProcessData(idr, item.PropertySet.Package, false);

					MeshInfo mi = new MeshInfo();
					//mi.Description = "<not found in FileTable>";

					int idxCres = item.GetProperty("resourcekeyidx").IntegerValue;
					int idxShpe = item.GetProperty("shapekeyidx").IntegerValue;

					mi.ResourceNode = refFile.Items[idxCres];
					mi.ShapeFile = refFile.Items[idxShpe];

					if (mi.ResourceNode != null && mi.ShapeFile != null)
					{
						ret.Add(mi);
						mi.Description = new ResourceReference(
							mi.ResourceNode
						).ToString();

						IScenegraphFileIndexItem idx = FindFileByReference(
							mi.ResourceNode
						);
						if (idx != null)
						{
							mi.FileName = idx.Package.FileName;
							using (GenericRcol rcol = new GenericRcol())
							{
								rcol.ProcessData(
									idx.FileDescriptor,
									idx.Package,
									false
								);
								mi.Description = rcol.FileName.Replace("_cres", "");
							}
						}
					}
				}
			}

			return (MeshInfo[])ret.ToArray(typeof(MeshInfo));
		}

		public MeshInfo[] GetMeshReferences(IPackageFile meshPackage)
		{
			if (meshPackage == null)
			{
				return null;
			}

			ArrayList ret = new ArrayList();

			IPackedFileDescriptor[] cresFiles = meshPackage.FindFiles(
				Data.MetaData.CRES
			);
			using (GenericRcol rcol = new GenericRcol())
			{
				foreach (IPackedFileDescriptor cresFile in cresFiles)
				{
					try
					{
						rcol.ProcessData(cresFile, meshPackage, false);
						if (!Utility.IsNullOrEmpty(rcol.ReferencedFiles))
						{
							IPackedFileDescriptor shpeFile = rcol.ReferencedFiles[0];

							MeshInfo rp = new MeshInfo
							{
								ResourceNode = cresFile,
								ShapeFile = shpeFile,
								Description = rcol.FileName.Replace("_cres", ""),
								FileName = meshPackage.FileName
							};
							ret.Add(rp);
						}
					}
					finally
					{
						rcol.FileDescriptor = null;
						rcol.Package = null;
					}
				}
			}

			return (MeshInfo[])ret.ToArray(typeof(MeshInfo));
		}

		IScenegraphFileIndexItem FindFileByReference(IPackedFileDescriptor reference)
		{
			/*if (!FileTable.FileIndex.Loaded && WrapperFactory.Settings.ForceTableLoad)
				FileTable.FileIndex.Load();*/
			IScenegraphFileIndexItem ret = null;

			// find in all packages
			IScenegraphFileIndexItem[] items =
				FileTableBase.FileIndex.FindFileByGroupAndInstance(
					reference.Group,
					reference.LongInstance
				);
			if (!Utility.IsNullOrEmpty(items))
			{
				foreach (IScenegraphFileIndexItem sfi in items)
				{
					if (sfi.FileDescriptor.Type == reference.Type)
					{
						ret = sfi;
						break;
					}
				}
			}

			if (ret == null)
			{
				IScenegraphFileIndexItem[] sfi =
					FileTableBase.FileIndex.FindFileDiscardingGroup(reference); //, pnfo.Package);
				if (!Utility.IsNullOrEmpty(sfi))
				{
					ret = sfi[0];
				}
			}

			return ret;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				// dispose loaded package files
				foreach (IDisposable file in loadedMeshes.Values)
				{
					file.Dispose();
				}

				Clear();
			}
			base.Dispose(disposing);
		}

		public class MeshInfo
		{
			public IPackedFileDescriptor ResourceNode { get; set; } = null;

			public IPackedFileDescriptor ShapeFile { get; set; } = null;

			public string Description
			{
				get; set;
			}

			public string FileName
			{
				get; set;
			}
		}
	}
}
