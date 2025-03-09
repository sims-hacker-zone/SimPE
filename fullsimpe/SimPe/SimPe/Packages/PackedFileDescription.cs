// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Data;
using SimPe.Events;
using SimPe.Extensions;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin.Internal;

namespace SimPe.Packages
{
	public class PackedFileDescriptorSimple
		: IPackedFileDescriptorSimple
	{
		public PackedFileDescriptorSimple()
			: this(0, 0, 0, 0) { }

		public PackedFileDescriptorSimple(FileTypes type, uint grp, uint ihi, uint ilo)
		{
			this.type = type;
			group = grp;
			subtype = ihi;
			instance = ilo;
		}

		/// <summary>
		/// Type of the referenced File
		/// </summary>
		internal FileTypes type;

		/// <summary>
		/// Returns/Sets the Type of the referenced File
		/// </summary>
		public FileTypes Type
		{
			get => type;
			set
			{
				if (type != value)
				{
					type = value;
					DescriptionChangedFkt();
				}
			}
		}

		/// <summary>
		/// Returns the Information of the represented Type
		/// </summary>
		public FileTypeInformation TypeInfo => Type.ToFileTypeInformation();

		/// <summary>
		/// Group the referenced file is assigned to
		/// </summary>
		internal uint group;

		/// <summary>
		/// Returns/Sets the Group the referenced file is assigned to
		/// </summary>
		public uint Group
		{
			get => group;
			set
			{
				if (group != value)
				{
					group = value;
					DescriptionChangedFkt();
				}
			}
		}

		/// <summary>
		/// Instance Data
		/// </summary>
		internal uint instance;

		/// <summary>
		/// Returns or sets the Instance Data
		/// </summary>
		public uint Instance
		{
			get => instance;
			set
			{
				if (instance != value)
				{
					instance = value;
					DescriptionChangedFkt();
				}
			}
		}

		/// <summary>
		/// An yet unknown Type
		/// </summary>
		/// <remarks>Only in Version 1.1 of package Files</remarks>
		internal uint subtype;

		/// <summary>
		/// Returns/Sets an yet unknown Type
		/// </summary>
		/// <remarks>Only in Version 1.1 of package Files</remarks>
		public uint SubType
		{
			get => subtype;
			set
			{
				if (subtype != value)
				{
					subtype = value;
					DescriptionChangedFkt();
				}
			}
		}

		protected virtual void DescriptionChangedFkt()
		{
		}
	}

	/// <summary>
	/// Structure of a FileIndex Item
	/// </summary>
	public class PackedFileDescriptor
		: PackedFileDescriptorSimple,
			IPackedFileDescriptor,
			IDisposable
	{
		/// <summary>
		/// Creates a clone of this Object
		/// </summary>
		/// <returns>The Cloned Object</returns>
		public IPackedFileDescriptor Clone()
		{
			PackedFileDescriptor pfd = new PackedFileDescriptor
			{
				filename = filename,
				group = group,
				instance = instance,
				offset = offset,
				size = size,
				subtype = subtype,
				type = type,
				changed = changed,
				wascomp = wascomp,

				markcompress = markcompress,
				markdeleted = markdeleted
			};

			return pfd;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public PackedFileDescriptor()
		{
			subtype = 0;
			markdeleted = false;
			markcompress = false;
			changed = false;
			valid = true;
			wascomp = false;
			offset = 0;
			size = 0;
		}

		/// <summary>
		/// Returns the Size of the File
		/// </summary>
		public int Size
		{
			get => userdata == null ? size : userdata.Length;
			set => size = value;
		}

		/// <summary>
		/// Returns the size stored in teh index
		/// </summary>
		public int IndexedSize => size;

		/// <summary>
		/// Location of the File within the Package
		/// </summary>
		internal uint offset;

		/// <summary>
		/// Returns the Location of the File within the Package
		/// </summary>
		public uint Offset
		{
			get => offset;
			set => offset = value;
		}

		/// <summary>
		/// Size of the compressed File
		/// </summary>
		internal int size;

		/// <summary>
		/// Returns the Long Instance
		/// </summary>
		/// <remarks>Combination of SubType and Instance</remarks>
		public ulong LongInstance
		{
			get
			{
				ulong ret = instance;
				ret = (((ulong)subtype << 32) & 0xffffffff00000000) | ret;
				return ret;
			}
			set
			{
				uint ninstance = (uint)(value & 0xffffffff);
				uint nsubtype = (uint)((value >> 32) & 0xffffffff);
				if (ninstance != instance || nsubtype != subtype)
				{
					instance = ninstance;
					subtype = nsubtype;
					DescriptionChangedFkt();
				}
			}
		}

		/// <summary>
		/// The proposed Filename
		/// </summary>
		/// <remarks>This is mostly of intrest when you extract packedFiles</remarks>
		private string filename = null;

		/// <summary>
		/// Returns or Sets the Filename
		/// </summary>
		/// <remarks>This is mostly of intrest when you extract packedFiles</remarks>
		public string Filename
		{
			get
			{
				if (filename == null)
				{
					filename =
						Helper.HexString(SubType)
						+ "-"
						+ Helper.HexString(Group)
						+ "-"
						+ Helper.HexString(Instance);
					filename += "." + TypeInfo.Extension;
				}

				return filename;
			}
			set => filename = value;
		}

		public string ExportFileName => Helper.HexString(Type) + "-" + Filename;

		/// <summary>
		/// The proposed FilePath
		/// </summary>
		/// <remarks>This is mostly of intrest when you extract packedFiles</remarks>
		private string path = null;

		/// <summary>
		/// Returns or Setst the File Path
		/// </summary>
		/// <remarks>This is mostly of intrest when you extract packedFiles</remarks>
		public string Path
		{
			get
			{
				if (path == null)
				{
					path = Helper.HexString(Type);
					path +=
						" - "
						+ Helper.RemoveUnlistedCharacters(
							TypeInfo.LongName,
							Helper.PATH_CHARACTERS
						);
				}

				return path;
			}
			set => path = value;
		}

		/// <summary>
		/// Generates MetInformations about a Packed File
		/// </summary>
		/// <param name="pfd">The description of the File</param>
		/// <returns>A String representing the Description as XML output</returns>
		public string GenerateXmlMetaInfo()
		{
			string xml = "";
			xml +=
				Helper.tab
				+ "<packedfile path=\""
				+ Path.Replace("&", "&amp;")
				+ "\" name=\""
				+ Filename
				+ "\">"
				+ Helper.lbr;
			/*xml += Helper.tab + Helper.tab + "<offset>"+this.Offset.ToString()+"</offset>" + Helper.lbr;
			xml += Helper.tab + Helper.tab + "<size>"+this.Size.ToString()+"</size>" + Helper.lbr;*/
			xml += Helper.tab + Helper.tab + "<type>" + Helper.lbr;
			/*Data.TypeAlias a = this.TypeName;
			xml += Helper.tab + Helper.tab + Helper.tab + "<name>"+a.Name+"</name>" + Helper.lbr;
			xml += Helper.tab + Helper.tab + Helper.tab + "<short>"+a.shortname+"</short>" + Helper.lbr;			*/
			/*xml += Helper.tab + Helper.tab + Helper.tab + "<name></name>" + Helper.lbr;
			xml += Helper.tab + Helper.tab + Helper.tab + "<short></short>" + Helper.lbr;*/
			xml +=
				Helper.tab
				+ Helper.tab
				+ Helper.tab
				+ "<number>"
				+ Type.ToString()
				+ "</number>"
				+ Helper.lbr;
			xml += Helper.tab + Helper.tab + "</type>" + Helper.lbr;
			xml +=
				Helper.tab
				+ Helper.tab
				+ "<classid>"
				+ SubType.ToString()
				+ "</classid>"
				+ Helper.lbr;
			xml +=
				Helper.tab
				+ Helper.tab
				+ "<group>"
				+ Group.ToString()
				+ "</group>"
				+ Helper.lbr;
			xml +=
				Helper.tab
				+ Helper.tab
				+ "<instance>"
				+ Instance.ToString()
				+ "</instance>"
				+ Helper.lbr;
			xml += Helper.tab + "</packedfile>" + Helper.lbr;
			return xml;
		}

		public override string ToString()
		{
			string name =
				TypeInfo.LongName
				+ ": "
				+ Helper.HexString(Type)
				+ " - "
				+ Helper.HexString(SubType)
				+ " - "
				+ Helper.HexString(Group)
				+ " - "
				+ Helper.HexString(Instance);

			//if ((this.Size==0) && (this.Offset==0)) name += " [UserFile]";
			return name;
		}

		string GetResDescString()
		{
			switch (
				Helper.WindowsRegistry.Config.ResourceListUnknownDescriptionFormat
			)
			{
				case Registry.ResourceListUnnamedFormats.FullTGI:
					return Helper.HexString(Type)
																					+ " - "
																					+ Helper.HexString(SubType)
																					+ " - "
																					+ Helper.HexString(Group)
																					+ " - "
																					+ Helper.HexString(Instance);
				case Registry.ResourceListUnnamedFormats.Instance:
					return Helper.HexString(SubType)
																					 + " - "
																					 + Helper.HexString(Instance);
				default:
					return Helper.HexString(SubType)
						+ " - "
						+ Helper.HexString(Group)
						+ " - "
						+ Helper.HexString(Instance);
			}
		}

		public string ToResListString()
		{
			if (
				Helper.WindowsRegistry.Config.ResourceListFormat
				== Registry.ResourceListFormats.ShortTypeNames
			)
			{
				return TypeInfo.ShortName + ": " + GetResDescString();
			}

			if (
				Helper.WindowsRegistry.Config.ResourceListFormat
				== Registry.ResourceListFormats.JustNames
			)
			{
				return TypeInfo.ToString();
			}

			if (
				Helper.WindowsRegistry.Config.ResourceListFormat
				== Registry.ResourceListFormats.JustLongType
			)
			{
				return TypeInfo.ToString();
			}

			//if ((this.Size==0) && (this.Offset==0)) name += " [UserFile]";
			return TypeInfo + ": " + GetResDescString();
		}

		#region Compare Methods
		/// <summary>
		/// Same Equals, except this Version is also checking the Offset
		/// </summary>
		/// <param name="obj">The Object to compare to</param>
		/// <returns>true if the TGI Values are the same</returns>
		public bool SameAs(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			//passed a FileWrapper, so extract the FileDescriptor
			if (
				typeof(IPackedFileWrapper)
				== obj.GetType().GetInterface("IPackedFileWrapper")
			)
			{
				IPackedFileWrapper pfw = (IPackedFileWrapper)obj;
				obj = pfw.FileDescriptor;
			}
			else
			{
				// Check for null values and compare run-time types.
				if (

						(
							typeof(IPackedFileDescriptor)
							!= obj.GetType().GetInterface("IPackedFileDescriptor")
						) && (GetType() != obj.GetType())

				)
				{
					return false;
				}
			}

			IPackedFileDescriptor pfd = (IPackedFileDescriptor)obj;
			return
				(Type == pfd.Type)
				&& (LongInstance == pfd.LongInstance)
				&& (Group == pfd.Group)
				&& (Offset == pfd.Offset)
			;
		}

		/// <summary>
		/// Allow compare with IPackedFileWrapper and IPackedFileDescriptor Objects
		/// </summary>
		/// <param name="obj">The Object to compare to</param>
		/// <returns>true if the TGI Values are the same</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			//passed a FileWrapper, so extract the FileDescriptor
			if (
				typeof(IPackedFileWrapper)
				== obj.GetType().GetInterface("IPackedFileWrapper")
			)
			{
				IPackedFileWrapper pfw = (IPackedFileWrapper)obj;
				obj = pfw.FileDescriptor;
			}
			else
			{
				// Check for null values and compare run-time types.
				if (

						(
							typeof(IPackedFileDescriptor)
							!= obj.GetType().GetInterface("IPackedFileDescriptor")
						) && (GetType() != obj.GetType())

				)
				{
					return false;
				}
			}

			IPackedFileDescriptor pfd = (IPackedFileDescriptor)obj;
			return
				(Type == pfd.Type)
				&& (LongInstance == pfd.LongInstance)
				&& (Group == pfd.Group)
			;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/*public static bool operator ==(PackedFileDescriptor x, IPackedFileDescriptor y)
		{
			if (x==null) return (y==null);
			return x.Equals(y);
		}

		public static bool operator !=(PackedFileDescriptor x, IPackedFileDescriptor y)
		{
			if (x==null) return (y!=null);
			return !x.Equals(y);
		}*/

		/*public static bool operator ==(PackedFileDescriptor x, IPackedFileWrapper y)
		{
			return x.Equals(y);
		}

		public static bool operator !=(PackedFileDescriptor x, IPackedFileWrapper y)
		{
			return !x.Equals(y);
		}*/
		#endregion

		public object Tag
		{
			get; set;
		}

		#region UserData Extensions
		/// <summary>
		/// true if this file should be marked as deleted
		/// </summary>
		bool markdeleted;

		/// <summary>
		/// Returns/sets if this file should be keept in the Index for the next Save
		/// </summary>
		public bool MarkForDelete
		{
			get => markdeleted;
			set
			{
				if (value != markdeleted)
				{
					markdeleted = value;
					DescriptionChangedFkt();
					if (Deleted != null && markdeleted)
					{
						Deleted(this, new EventArgs());
					}
				}
			}
		}

		bool markcompress;

		/// <summary>
		/// Returns/sets if this File should be Recompressed during the next Save Operation
		/// </summary>
		public bool MarkForReCompress
		{
			get => markcompress;
			set
			{
				if (markcompress != value)
				{
					markcompress = value;
					DescriptionChangedFkt();
				}
			}
		}

		bool wascomp;

		/// <summary>
		/// Returns true if the Resource was Compressed
		/// </summary>
		public bool WasCompressed
		{
			get => wascomp;
			set
			{
				if (wascomp != value)
				{
					wascomp = value;
					DescriptionChangedFkt();
				}
			}
		}

		/// <summary>
		/// Returns true, if Userdate is available
		/// </summary>
		/// <remarks>This happens when a user assigns new Data</remarks>
		public bool HasUserdata => userdata != null;

		/// <summary>
		/// contains alternative Userdata
		/// </summary>
		private byte[] userdata = null;

		/// <summary>
		/// Puts Userdefined Data into the File
		/// </summary>
		public byte[] UserData
		{
			get => userdata;
			set => SetUserData(value, true);
		}

		public void SetUserData(byte[] data, bool fire)
		{
			changed = true;
			userdata = data;
			if (PackageInternalUserDataChange != null)
			{
				PackageInternalUserDataChange(this);
			}

			if (ChangedUserData != null && fire)
			{
				ChangedUserData(this);
			}

			ChangedDataFkt();
		}

		/// <summary>
		/// true if changed
		/// </summary>
		bool changed;

		/// <summary>
		/// Returns true if theis File was changed since the last Save
		/// </summary>
		/// <remarks>Fires the <see cref="ChangedData"/> Event</remarks>
		public bool Changed
		{
			get => changed;
			set
			{
				if (value != changed)
				{
					changed = value;
					ChangedDataFkt();
				}
			}
		}

		/// <summary>
		/// Used during saving Operations to qickly determin the umcompressed Size
		/// </summary>
		internal PackedFile fldata;
		#endregion

		bool valid;

		/// <summary>
		/// Close this Descriptor (make it invalid)
		/// </summary>
		public void MarkInvalid()
		{
			if (Closed != null)
			{
				Closed(this);
			}

			valid = false;
		}

		/// <summary>
		/// true, if this Descriptor is Invalid
		/// </summary>
		public bool Invalid => !valid;

		#region Events
		bool pause;
		bool changedataevent,
			changeddescriptionevent;

		public void BeginUpdate()
		{
			changedataevent = false;
			changeddescriptionevent = false;
			pause = true;
		}

		public void EndUpdate()
		{
			pause = false;
			if (changedataevent)
			{
				ChangedDataFkt();
			}

			if (changeddescriptionevent)
			{
				DescriptionChangedFkt();
			}
		}

		/// <summary>
		/// Called whenever the content represented by this descripotr was changed
		/// </summary>
		/// <remarks>
		/// This should be used by the Pacakges containing the Descriptor, to
		/// get notified on a Change. Every other Listener has to register with <see cref="ChangedUserData"/>
		/// </remarks>
		internal PackedFileChanged PackageInternalUserDataChange
		{
			get; set;
		}

		/// <summary>
		/// Called whenever the content represented by this descripotr was changed
		/// </summary>
		/// <remarks>
		/// This is the public Change Listener. Developers can control in
		/// <see cref="SetUserData"/>if this Event is fired. This Event will not fire if <see cref="Interfaces.Plugin.Internal.SynchronizeUserData"/>
		/// is called (which changes the UserData).
		/// </remarks>
		public event PackedFileChanged ChangedUserData;

		/// <summary>
		/// Called whenever the content represented by this descripotr was changed
		/// </summary>
		/// <remarks>
		/// This is the public Change Listener. Unlike <see cref="ChangedUserData"/>, this event allways fires when the USerData Changes
		/// </remarks>
		public event PackedFileChanged ChangedData;

		/// <summary>
		/// Called whenever the Desciptor get's invalid
		/// </summary>
		public event PackedFileChanged Closed;

		/// <summary>
		/// Triggered whenever the Content of the Descriptor was changed
		/// </summary>
		public event EventHandler DescriptionChanged;

		/// <summary>
		/// Triggered whenever the Descriptor get's AMrked for Deletion
		/// </summary>
		public event EventHandler Deleted;

		void ChangedDataFkt()
		{
			if (pause)
			{
				changedataevent = true;
				return;
			}

			if (ChangedData != null)
			{
				ChangedData(this);
			}
		}

		protected override void DescriptionChangedFkt()
		{
			if (pause)
			{
				changeddescriptionevent = true;
				return;
			}

			if (DescriptionChanged != null)
			{
				DescriptionChanged(this, new EventArgs());
			}
		}
		#endregion

		public string ExceptionString
		{
			get
			{
				string msg = "";
				msg +=
					TypeInfo.LongName
					+ " ("
					+ Helper.HexString(Type)
					+ ") - "
					+ Helper.HexString(SubType)
					+ " - "
					+ Helper.HexString(Group)
					+ " - "
					+ Helper.HexString(Instance);

				return msg;
			}
		}

		internal void LoadFromStream(
			IPackageHeader header,
			System.IO.BinaryReader reader
		)
		{
			type = (FileTypes)reader.ReadUInt32();
			group = reader.ReadUInt32();
			instance = reader.ReadUInt32();
			if (header.IsVersion0101 && (header.Index.ItemSize >= 24))
			{
				subtype = reader.ReadUInt32();
			}

			offset = reader.ReadUInt32();
			size = reader.ReadInt32();
		}

		#region IDisposable Member

		public void Dispose()
		{
			userdata = null;
			filename = null;
			path = null;

			ChangedData = null;
			ChangedUserData = null;
			Closed = null;
			Deleted = null;
			DescriptionChanged = null;
		}

		#endregion
	}
}
