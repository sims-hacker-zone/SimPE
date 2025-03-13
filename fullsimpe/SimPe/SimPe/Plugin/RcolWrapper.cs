// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Interfaces.Files;
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
	public abstract class Rcol : AbstractWrapper, IFileWrapper,
			IFileWrapperSaveExtension, IMultiplePackedFileWrapper, IDisposable
	{
		#region Attributes
		byte[] oversize;
		List<uint> index;

		List<IPackedFileDescriptor> reffiles;
		public List<IPackedFileDescriptor> ReferencedFiles
		{
			get => Duff ? new List<IPackedFileDescriptor>() : reffiles;
			set
			{
				if (Duff)
				{
					return;
				}

				reffiles = value;
			}
		}

		List<IRcolBlock> blocks;
		public List<IRcolBlock> Blocks
		{
			get => Duff ? new List<IRcolBlock>() : blocks;
			set
			{
				if (Duff)
				{
					return;
				}

				blocks = value;
			}
		}

		public uint Count
		{
			get; private set;
		}

		Exception e = null;
		public bool Duff { get; private set; } = false;
		#endregion

		/// <summary>
		/// contains null or a delegate that should be called when the TabPage did change
		/// </summary>
		public event EventHandler TabPageChanged;

		internal void ClearTabPageChanged()
		{
			if (TabPageChanged == null)
			{
				return;
			}

			Delegate[] list = TabPageChanged.GetInvocationList();
			foreach (EventHandler d in list)
			{
				TabPageChanged -= d;
			}
		}

		internal void ChildTabPageChanged(object sender, EventArgs e)
		{
			if (TabPageChanged != null)
			{
				TabPageChanged(sender, e);
			}
		}

		public static Dictionary<string, Type> Tokens => new Dictionary<string, Type>
		{
			["cAmbientLight"] = typeof(AmbientLight),
			["cBoneDataExtension"] = typeof(BoneDataExtension),
			["cBoundedNode"] = typeof(BoundedNode),
			["cBoundingVolumeBuilder"] = typeof(BoundingVolumeBuilder),
			["cCinematicScene"] = typeof(CinematicScene),
			["cCompactorBuilder"] = typeof(CompactorBuilder),
			["cCompositionTreeNode"] = typeof(CompositionTreeNode),
			["cDataListExtension"] = typeof(DataListExtension),
			["cDirectionalLight"] = typeof(DirectionalLight),
			["cExtension"] = typeof(Extension),
			["cGeometryBuilder"] = typeof(GeometryBuilder),
			["cGeometryDataContainer"] = typeof(GeometryDataContainer),
			["cGeometryNode"] = typeof(GeometryNode),
			["cImageData"] = typeof(ImageData),
			["cIndexedMeshBuilder"] = typeof(IndexedMeshBuilder),
			["cLevelInfo"] = typeof(LevelInfo),
			["cLightRefNode"] = typeof(LightRefNode),
			["cLightT"] = typeof(LightT),
			["cMaterialDefinition"] = typeof(MaterialDefinition),
			["cObjectGraphNode"] = typeof(ObjectGraphNode),
			["cPointLight"] = typeof(PointLight),
			["cProcessDeformationsBuilder"] = typeof(ProcessDeformationsBuilder),
			["cReferentNode"] = typeof(ReferentNode),
			["cRenderableNode"] = typeof(RenderableNode),
			["cResourceNode"] = typeof(ResourceNode),
			["cSGResource"] = typeof(SGResource),
			["cShape"] = typeof(Shape),
			["cShapeRefNode"] = typeof(ShapeRefNode),
			["cSpotLight"] = typeof(SpotLight),
			["cStandardLightBase"] = typeof(StandardLightBase),
			["cTagExtension"] = typeof(TagExtension),
			["cTangentSpaceBuilder"] = typeof(TangentSpaceBuilder),
			["cViewerRefNode"] = typeof(ViewerRefNode),
			["cViewerRefNodeBase"] = typeof(ViewerRefNodeBase),
			["cViewerRefNodeRecursive"] = typeof(ViewerRefNodeRecursive),
			["cTransformNode"] = typeof(TransformNode),
			["cTSFaceGeometryBuilder"] = typeof(TSFaceGeometryBuilder),
			["cAnimResourceConst"] = typeof(Anim.AnimResourceConst),
		};

		public Interfaces.IProviderRegistry Provider
		{
			get;
		}

		/// <summary>
		/// Filename of the First Block (or an empty string)
		/// </summary>
		public string FileName
		{
			get => Duff
					? Localization.GetString("InvalidCRES").Replace("{0}", e.Message)
					: blocks.FirstOrDefault()?.NameResource?.FileName ?? "";
			set
			{
				if (!Duff && blocks.FirstOrDefault()?.NameResource != null)
				{
					blocks[0].NameResource.FileName = value;
				}
			}
		}

		public bool Fast
		{
			get; set;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public Rcol(Interfaces.IProviderRegistry provider, bool fast)
			: base()
		{
			Fast = fast;
			Provider = provider;
			reffiles = new List<IPackedFileDescriptor>();
			index = new List<uint>();
			blocks = new List<IRcolBlock>();
			oversize = new byte[0];
			Duff = false;
		}

		public Rcol()
			: this(null, false) { }

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return (version == 0012) //0.10
				|| (version == 0013); //0.12
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new RcolUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"RCOL Wrapper",
				"Quaxi",
				"This File is part of the Scenegraph. The Scenegraph is used to build the 3D Objects in \"The Sims 2\".",
				10,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.resource.png")
				)
			);
		}

		/// <summary>
		/// Read a RCOl Block
		/// </summary>
		/// <param name="id">expected ID</param>
		/// <param name="reader">the reader</param>
		internal IRcolBlock ReadBlock(uint id, System.IO.BinaryReader reader)
		{
			long pos = reader.BaseStream.Position;
			string s = reader.ReadString();
			Type tp = (Type)Tokens[s] ?? throw new Exception(
					"Unknown embedded RCOL Block Name at Offset=0x"
						+ Helper.HexString((uint)pos),
					new Exception("RCOL Block Name: " + s)
				);

			pos = reader.BaseStream.Position;
			uint myid = reader.ReadUInt32();
			if (myid == 0xffffffff)
			{
				return null;
			}

			if (id != myid)
			{
				throw new Exception(
					"Unexpected embedded RCOL Block ID at Offset=0x"
						+ Helper.HexString((uint)pos),
					new Exception(
						"Read: 0x"
							+ Helper.HexString(myid)
							+ "; Expected: 0x"
							+ Helper.HexString(id)
					)
				);
			}

			IRcolBlock wrp = AbstractRcolBlock.Create(tp, this, myid);
			wrp.Unserialize(reader);
			return wrp;
		}

		/// <summary>
		/// Write a Rcol Block
		/// </summary>
		/// <param name="wrp">The content of the Block</param>
		/// <param name="writer">the writer</param>
		internal void WriteBlock(IRcolBlock wrp, System.IO.BinaryWriter writer)
		{
			writer.Write(wrp.BlockName);
			writer.Write(wrp.BlockID);
			wrp.Serialize(writer);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			Duff = false;
			e = null;

			Count = reader.ReadUInt32();

			try
			{
				uint filecount = Count == 0xffff0001 ? reader.ReadUInt32() : Count;
				reffiles = new List<IPackedFileDescriptor>();
				for (int i = 0; i < filecount; i++)
				{
					reffiles.Add(new Packages.PackedFileDescriptor
					{
						Group = reader.ReadUInt32(),
						Instance = reader.ReadUInt32(),
						SubType = (Count == 0xffff0001) ? reader.ReadUInt32() : 0,
						Type = (FileTypes)reader.ReadUInt32()
					});
				}

				uint nn = reader.ReadUInt32();
				index = new List<uint>();
				blocks = new List<IRcolBlock>();
				for (int i = 0; i < nn; i++)
				{
					index.Add(reader.ReadUInt32());
				}

				for (int i = 0; i < nn; i++)
				{
					IRcolBlock wrp = ReadBlock(index[i], reader);
					if (wrp == null)
					{
						break;
					}

					blocks.Add(wrp);
				}

				if (!Fast)
				{
					long size = reader.BaseStream.Length - reader.BaseStream.Position;
					oversize = size > 0 ? reader.ReadBytes((int)size) : (new byte[0]);
				}
			}
			catch (Exception e)
			{
				Duff = true;
				this.e = e;
				//SimPe.Helper.ExceptionMessage(e);
			}
			finally { }
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			if (Duff)
			{
				return;
			}

			writer.Write(Count == 0xffff0001 ? Count : (uint)reffiles.Count);
			writer.Write((uint)reffiles.Count);
			for (int i = 0; i < reffiles.Count; i++)
			{
				Packages.PackedFileDescriptor pfd =
					(Packages.PackedFileDescriptor)reffiles[i];
				writer.Write(pfd.Group);
				writer.Write(pfd.Instance);
				if (Count == 0xffff0001)
				{
					writer.Write(pfd.SubType);
				}

				writer.Write((uint)pfd.Type);
			}

			writer.Write((uint)blocks.Count);
			for (int i = 0; i < blocks.Count; i++)
			{
				writer.Write(blocks[i].BlockID);
			}

			for (int i = 0; i < blocks.Count; i++)
			{
				IRcolBlock wrp = blocks[i];
				WriteBlock(wrp, writer);
			}

			writer.Write(oversize);
		}

		public static ArrayList list;

		/// <summary>
		/// Fixes SubType and Instance hashes of the RCOL
		/// </summary>
		public override void Fix(Interfaces.IWrapperRegistry registry)
		{
			if (list == null)
			{
				list = new ArrayList();
			}

			base.Fix(registry);

			//first we need to fix all referenced Files
			for (int i = 0; i < ReferencedFiles.Count; i++)
			{
				IPackedFileDescriptor lpfd = ReferencedFiles[i];
				IPackedFileDescriptor pfd = Package.FindFile(
					lpfd
				);
				if (pfd != null)
				{
					//make sure we don't get into an Endless Loop
					if (list.Contains(pfd))
					{
						continue;
					}

					list.Add(pfd);
					IFileWrapper wrapper =
						(IFileWrapper)
							registry.FindHandler(pfd.Type);
					if (wrapper != null)
					{
						wrapper.ProcessData(pfd, package);
						wrapper.Fix(registry);
						lpfd.SubType = wrapper.FileDescriptor.SubType;
						lpfd.Group = wrapper.FileDescriptor.Group;
						lpfd.Instance = wrapper.FileDescriptor.Instance;
					}
					list.Remove(pfd);
				}
			}

			//so now we do fix the Instances
			FileDescriptor.SubType = Hashes.SubTypeHash(
				Hashes.StripHashFromName(FileName)
			);
			FileDescriptor.Instance = Hashes.InstanceHash(
				Hashes.StripHashFromName(FileName)
			);

			//commit
			SynchronizeUserData();
		}

		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public virtual byte[] FileSignature => new byte[0];

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public virtual FileTypes[] AssignableTypes => new FileTypes[] { };

		/// <summary>
		/// Override this to add your own Implementation for <see cref="ResourceName"/>
		/// </summary>
		/// <returns>null, if the Default Name should be generated</returns>
		protected override string GetResourceName(FileTypeInformation fti)
		{
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package, false);
			}

			return FileName;
		}

		#endregion

		#region IMultiplePackedFileWrapper
		public override object[] GetConstructorArguments()
		{
			object[] o = new object[2];
			o[0] = Provider;
			o[1] = Fast;
			return o;
		}
		#endregion

		public override void Dispose()
		{
			foreach (IRcolBlock irb in blocks)
			{
				if (irb is IDisposable)
				{
					irb.Dispose();
				}
			}

			base.Dispose();
		}
	}
}
