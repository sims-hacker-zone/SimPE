// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.Wants
{
	public class SWAFWrapper
		: pjse.ExtendedWrapper<SWAFItem, SWAFWrapper>,
			IFileWrapper,
			IFileWrapperSaveExtension,
			IDictionary<uint, List<SWAFItem>>
	{
		#region Attributes
		private uint version = 0x01;
		private uint maxWants = 0;
		private uint maxFears = 0;
		private uint unknown1 = 0x00;
		private uint unknown2 = 0x00;
		private uint unknown3 = 0x00;
		private Dictionary<uint, List<SWAFItem>> history =
			new Dictionary<uint, List<SWAFItem>>();
		private byte[] unknown4 = new byte[0];
		#endregion

		#region Accessor Methods
		public uint Version
		{
			get => version;
			set
			{
				if (version != value)
				{
					setVersion(value);
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		private void setVersion(uint value)
		{
			if (!IsValidVersion(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}

			version = value;
		}

		private static List<uint> lValidVersions = null;
		public static List<uint> ValidVersions
		{
			get
			{
				if (lValidVersions == null)
				{
					lValidVersions = new List<uint>(
						new uint[] { 0x01, 0x05, 0x06, 0x07 }
					);
				}

				return lValidVersions;
			}
		} // CJH

		private static bool IsValidVersion(uint value)
		{
			return ValidVersions.Contains(value);
		}

		public uint MaxWants
		{
			get => maxWants;
			set
			{
				if (maxWants != value)
				{
					setMaxWants(value);
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		private void setMaxWants(uint value)
		{
			if (version < 0x05)
			{
				throw new InvalidOperationException();
			}

			maxWants = value;
		}

		public uint MaxFears
		{
			get => maxFears;
			set
			{
				if (maxFears != value)
				{
					setMaxFears(value);
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		private void setMaxFears(uint value)
		{
			if (version < 0x05)
			{
				throw new InvalidOperationException();
			}

			maxFears = value;
		}

		public uint Unknown1
		{
			get => unknown1;
			set
			{
				if (unknown1 != value)
				{
					unknown1 = value;
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public uint Unknown2
		{
			get => unknown2;
			set
			{
				if (unknown2 != value)
				{
					unknown2 = value;
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public uint Unknown3
		{
			get => unknown3;
			set
			{
				if (unknown3 != value)
				{
					unknown3 = value;
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public byte[] Unknown4
		{
			get => unknown4;
			set
			{
				bool same = true;
				same = unknown4.Length == value.Length;
				for (int i = 0; same && i < unknown4.Length; i++)
				{
					same = unknown4[i] == value[i];
				}

				if (!same)
				{
					unknown4 = new byte[value.Length];
					value.CopyTo(unknown4, 0);
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public List<SWAFItem> LifetimeWants => this[SWAFItem.SWAFItemType.LifetimeWants];
		public List<SWAFItem> Wants => this[SWAFItem.SWAFItemType.Wants];
		public List<SWAFItem> Fears => this[SWAFItem.SWAFItemType.Fears];
		private List<SWAFItem> this[SWAFItem.SWAFItemType value]
		{
			get
			{
				List<SWAFItem> res = new List<SWAFItem>();
				foreach (SWAFItem item in items)
				{
					if (item.ItemType == value)
					{
						res.Add(item);
					}
				}

				return res;
			}
		}

		#endregion


		public SWAFWrapper()
			: base() { }

		const int oldMaxWants = 4;
		const int oldMaxFears = 3;

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			uint count;

			setVersion(reader.ReadUInt32());

			count = version >= 0x05 ? reader.ReadUInt32() : 0;
			for (int i = 0; i < count; i++)
			{
				items.Add(
					new SWAFItem(this, SWAFItem.SWAFItemType.LifetimeWants, reader)
				);
			}

			maxWants = version >= 0x05 ? reader.ReadUInt32() : oldMaxWants;

			count = reader.ReadUInt32();
			for (int i = 0; i < count; i++)
			{
				items.Add(new SWAFItem(this, SWAFItem.SWAFItemType.Wants, reader));
			}

			maxFears = version >= 0x05 ? reader.ReadUInt32() : oldMaxFears;

			count = reader.ReadUInt32();
			for (int i = 0; i < count; i++)
			{
				items.Add(new SWAFItem(this, SWAFItem.SWAFItemType.Fears, reader));
			}

			unknown3 = version >= 0x05 ? reader.ReadUInt32() : 0;
			unknown1 = reader.ReadUInt32();
			unknown2 = reader.ReadUInt32();

			count = reader.ReadUInt32();
			for (int i = 0; i < count; i++)
			{
				uint key = reader.ReadUInt32();
				List<SWAFItem> value = new List<SWAFItem>();
				uint hcount = reader.ReadUInt32();
				for (int j = 0; j < hcount; j++)
				{
					value.Add(
						new SWAFItem(this, SWAFItem.SWAFItemType.History, reader)
					);
				}

				history.Add(key, value);
			}

			unknown4 = reader.ReadBytes(
				(int)(reader.BaseStream.Length - reader.BaseStream.Position)
			);
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(version);

			List<SWAFItem> l = LifetimeWants;
			if (version >= 0x05)
			{
				writer.Write(l.Count);
			}

			foreach (SWAFItem i in l)
			{
				i.Serialize(writer);
			}

			if (version >= 0x05)
			{
				writer.Write(maxWants);
			}

			l = Wants;
			writer.Write(l.Count);
			foreach (SWAFItem i in l)
			{
				i.Serialize(writer);
			}

			if (version >= 0x05)
			{
				writer.Write(maxFears);
			}

			l = Fears;
			writer.Write(l.Count);
			foreach (SWAFItem i in l)
			{
				i.Serialize(writer);
			}

			if (version >= 0x05)
			{
				writer.Write(unknown3);
			}

			writer.Write(unknown1);
			writer.Write(unknown2);

			writer.Write(history.Count);
			foreach (KeyValuePair<uint, List<SWAFItem>> kvp in history)
			{
				writer.Write(kvp.Key);
				writer.Write(kvp.Value.Count);
				foreach (SWAFItem i in kvp.Value)
				{
					i.Serialize(writer);
				}
			}

			writer.Write(unknown4);
		}

		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new SWAFEditor();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo("PJSE SWAF Wrapper", "Peter L Jones", "", 1);
		}

		#region IFileWrapper Member
		/// <summary>
		/// Returns a list of File Types this Plugin can process
		/// </summary>
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.SWAF };

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		#endregion

		#region IFileWrapperSaveExtension Member
		protected override string GetResourceName(FileTypeInformation fti)
		{
			return !(FileTableBase.ProviderRegistry.SimDescriptionProvider.FindSim(
					(ushort)FileDescriptor.Instance
				) is ExtSDesc sdsc)
				? base.GetResourceName(fti)
				: sdsc.SimName + " " + sdsc.SimFamilyName + " (Wants/Fears)";
		}
		#endregion

		int LimitForType(SWAFItem.SWAFItemType type)
		{
			switch (type)
			{
				case SWAFItem.SWAFItemType.LifetimeWants:
					return version < 0x05 ? 0 : -1;
				case SWAFItem.SWAFItemType.Wants:
					return (int)maxWants;
				case SWAFItem.SWAFItemType.Fears:
					return (int)maxFears;
				default:
					return -1;
			}
		}

		int CountForType(SWAFItem.SWAFItemType type)
		{
			switch (type)
			{
				case SWAFItem.SWAFItemType.LifetimeWants:
					return LifetimeWants.Count;
				case SWAFItem.SWAFItemType.Wants:
					return Wants.Count;
				case SWAFItem.SWAFItemType.Fears:
					return Fears.Count;
				default:
					return -1;
			}
		}

		public new void Add(SWAFItem item)
		{
			int limit = LimitForType(item.ItemType);
			if (limit >= 0 && CountForType(item.ItemType) >= limit)
			{
				throw new InvalidOperationException();
			}

			base.Add(item);
		}

		public new void Insert(int index, SWAFItem item)
		{
			int limit = LimitForType(item.ItemType);
			if (limit >= 0)
			{
				Insert(index, item, limit);
			}
			else
			{
				base.Insert(index, item);
			}
		}

		#region IDictionary<uint,List<SWAFItem>> Members
		public void Add(uint key, List<SWAFItem> value)
		{
			history.Add(key, value);
			OnWrapperChanged(this, new EventArgs());
		}

		public bool ContainsKey(uint key)
		{
			return history.ContainsKey(key);
		}

		public ICollection<uint> Keys => history.Keys;

		public bool Remove(uint key)
		{
			bool res = history.Remove(key);
			OnWrapperChanged(this, new EventArgs());
			return res;
		}

		public bool TryGetValue(uint key, out List<SWAFItem> value)
		{
			return history.TryGetValue(key, out value);
		}

		public ICollection<List<SWAFItem>> Values => history.Values;
		public List<SWAFItem> this[uint key]
		{
			get => history[key];
			set
			{
				if (!history[key].Equals(value))
				{
					history[key] = value;
					OnWrapperChanged(items, new EventArgs());
				}
			}
		}
		#endregion

		#region ICollection<KeyValuePair<uint,List<SWAFItem>>> Members
		public void Add(KeyValuePair<uint, List<SWAFItem>> item)
		{
			Add(item.Key, item.Value);
		}

		public bool Contains(KeyValuePair<uint, List<SWAFItem>> item)
		{
			return ContainsKey(item.Key)
				&& this[item.Key].Equals(item.Value);
		}

		public void CopyTo(KeyValuePair<uint, List<SWAFItem>>[] array, int arrayIndex)
		{
			foreach (uint i in history.Keys)
			{
				array[arrayIndex++] = new KeyValuePair<uint, List<SWAFItem>>(
					i,
					this[i]
				);
			}
		}

		public bool Remove(KeyValuePair<uint, List<SWAFItem>> item)
		{
			return Contains(item) && history.Remove(item.Key);
		}
		#endregion

		#region IEnumerable<KeyValuePair<uint,List<SWAFItem>>> Members
		public new IEnumerator<KeyValuePair<uint, List<SWAFItem>>> GetEnumerator()
		{
			return history.GetEnumerator();
		}
		#endregion
	}

	public class SWAFItem : pjse.ExtendedWrapperItem<SWAFWrapper, SWAFItem>
	{
		public enum SWAFItemType
		{
			Wants,
			Fears,
			LifetimeWants,
			History,
		}

		public enum ArgTypes : uint
		{
			None = 0,
			Sim,
			Guid,
			Category,
			Skill,
			Career,
			Badge,
		}

		#region Attributes

		private uint version = 0x07;
		private ushort simId = 0x0000;
		private uint wantId = 0x00000000;
		private ArgTypes argType = ArgTypes.None;
		private object arg = null;
		private ushort arg2 = 0;
		private uint counter = 0;
		private int score = 0;
		private int influence = 0; // version >= 0x09
		private Boolset flags = 0;
		#endregion

		#region Accessor Methods
		public SWAFItemType ItemType
		{
			get;
		}

		public uint Version
		{
			get => version;
			set
			{
				if (version != value)
				{
					setVersion(value);
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		private void setVersion(uint value)
		{
			if (!IsValidVersion(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}

			version = value;
		}

		private static List<uint> lValidVersions = null;
		public static List<uint> ValidVersions
		{
			get
			{
				if (lValidVersions == null)
				{
					lValidVersions = new List<uint>(
						new uint[] { 0x04, 0x07, 0x08, 0x09, 0x0a }
					);
				}

				return lValidVersions;
			}
		}

		private static bool IsValidVersion(uint value)
		{
			return ValidVersions.Contains(value);
		}

		public ushort SimID
		{
			get => simId;
			set
			{
				if (simId != value)
				{
					simId = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public uint WantId
		{
			get => wantId;
			set
			{
				if (wantId != value)
				{
					wantId = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public ArgTypes ArgType
		{
			get => argType;
			set
			{
				if (argType != value)
				{
					setArgType(value);
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		private void setArgType(ArgTypes value)
		{
			if (!Enum.IsDefined(ArgType.GetType(), value))
			{
				throw new ArgumentOutOfRangeException("value");
			}

			argType = value;
		}

		#region Arg
		public ushort Sim
		{
			get => getArgUshort(ArgTypes.Sim, 0x08);
			set
			{
				if (!sameUshort(value))
				{
					setArgUshort(ArgTypes.Sim, 0x08, value);
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public uint Guid
		{
			get => getArgUint(ArgTypes.Guid);
			set
			{
				if (!sameUint(value))
				{
					setArgUint(ArgTypes.Guid, value);
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public uint Category
		{
			get => getArgUint(ArgTypes.Category);
			set
			{
				if (!sameUint(value))
				{
					setArgUint(ArgTypes.Category, value);
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public ushort Skill
		{
			get => getArgUshort(ArgTypes.Skill, 0);
			set
			{
				if (!sameUshort(value))
				{
					setArgUshort(ArgTypes.Skill, 0, value);
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public uint Career
		{
			get => getArgUint(ArgTypes.Career);
			set
			{
				if (!sameUint(value))
				{
					setArgUint(ArgTypes.Career, value);
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public uint Badge
		{
			get => getArgUint(ArgTypes.Badge);
			set
			{
				if (!sameUint(value))
				{
					setArgUint(ArgTypes.Badge, value);
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		private ushort getArgUshort(ArgTypes type, uint minVer)
		{
			return argType != type || version < minVer ? throw new InvalidOperationException() : (ushort)arg;
		}

		private void setArgUshort(ArgTypes type, uint minVer, ushort value)
		{
			if (argType != type || version < minVer)
			{
				throw new InvalidOperationException();
			}

			arg = value;
		}

		private uint getArgUint(ArgTypes type)
		{
			return argType != type ? throw new InvalidOperationException() : (uint)arg;
		}

		private void setArgUint(ArgTypes type, uint value)
		{
			if (argType != type)
			{
				throw new InvalidOperationException();
			}

			arg = value;
		}

		private bool sameUshort(ushort value)
		{
			try
			{
				return (ushort)arg == value;
			}
			catch
			{
				return false;
			}
		}

		private bool sameUint(uint value)
		{
			try
			{
				return (uint)arg == value;
			}
			catch
			{
				return false;
			}
		}
		#endregion

		public ushort Arg2
		{
			get => arg2;
			set
			{
				if (arg2 != value)
				{
					arg2 = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public uint Counter
		{
			get => counter;
			set
			{
				if (counter != value)
				{
					counter = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public int Score
		{
			get => score;
			set
			{
				if (score != value)
				{
					score = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public int Influence
		{
			get => influence;
			set
			{
				if (influence != value)
				{
					setInfluence(value);
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		private void setInfluence(int value)
		{
			if (version < 0x09)
			{
				throw new InvalidOperationException();
			}

			influence = value;
		}

		public Boolset Flags
		{
			get => flags;
			set
			{
				if (flags != value)
				{
					flags = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		#endregion

		public SWAFItem(SWAFWrapper parent, SWAFItemType type)
		{
			this.parent = parent;
			if (!Enum.IsDefined(type.GetType(), type))
			{
				throw new ArgumentOutOfRangeException("type");
			}

			ItemType = type;
		}

		internal SWAFItem(
			SWAFWrapper parent,
			SWAFItemType type,
			System.IO.BinaryReader reader
		)
		{
			this.parent = parent;
			if (!Enum.IsDefined(type.GetType(), type))
			{
				throw new ArgumentOutOfRangeException("type");
			}

			ItemType = type;
			Unserialize(reader);
		}

		private void Unserialize(System.IO.BinaryReader reader)
		{
			setVersion(reader.ReadUInt32());
			simId = reader.ReadUInt16();
			wantId = reader.ReadUInt32();
			setArgType((ArgTypes)reader.ReadByte());
			switch (argType)
			{
				case ArgTypes.Sim:
					if (version >= 0x08)
					{
						setArgUshort(argType, 0x08, reader.ReadUInt16());
					}

					break;
				case ArgTypes.Guid:
					setArgUint(argType, reader.ReadUInt32());
					break;
				case ArgTypes.Category:
					setArgUint(argType, reader.ReadUInt32());
					break;
				case ArgTypes.Skill:
					setArgUshort(argType, 0, reader.ReadUInt16());
					break;
				case ArgTypes.Career:
					setArgUint(argType, reader.ReadUInt32());
					break;
				case ArgTypes.Badge:
					setArgUint(argType, reader.ReadUInt32());
					break;
				default:
					arg = null;
					break;
			}
			arg2 = reader.ReadUInt16();
			counter = reader.ReadUInt32();
			score = reader.ReadInt32();
			influence = version >= 0x09 ? reader.ReadInt32() : 0;
			flags = reader.ReadByte();
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(version);
			writer.Write(simId);
			writer.Write(wantId);
			writer.Write((byte)argType);
			switch (argType)
			{
				case ArgTypes.Sim:
					if (version >= 0x08)
					{
						writer.Write((ushort)arg);
					}

					break;
				case ArgTypes.Guid:
					writer.Write((uint)arg);
					break;
				case ArgTypes.Category:
					writer.Write((uint)arg);
					break;
				case ArgTypes.Skill:
					writer.Write((ushort)arg);
					break;
				case ArgTypes.Career:
					writer.Write((uint)arg);
					break;
				case ArgTypes.Badge:
					writer.Write((uint)arg);
					break;
				default:
					break;
			}
			writer.Write(arg2);
			writer.Write(counter);
			writer.Write(score);
			if (version >= 0x09)
			{
				writer.Write(influence);
			}

			writer.Write((byte)flags);
		}
	}
}
