// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.PackedFiles.Ttab
{
	/// <summary>
	/// An Item stored in an TTAB
	/// </summary>
	public class TtabItem : pjse.ExtendedWrapperItem<Ttab, TtabItem>
	{
		#region Attributes
		private ushort action = 0;
		private ushort guard = 0;
		private int[] counts = null;

		//private TtabFlags flags = null;
		//private ushort flags2 = 0;
		private ushort flags = 0;
		private ushort flags2 = 0;
		private uint strindex = 0;
		private uint attenuationcode = 0;
		private float attenuationvalue = 0f;
		private uint autonomy = 0;
		private uint joinindex = 0;
		private ushort uidisplaytype = 0;
		private uint facialanimation = 0;
		private float memoryitermult = 0f;
		private uint objecttype = 0;
		private uint modeltableid = 0;
		private TtabItemMotiveTable humanGroups = null;
		private TtabItemMotiveTable animalGroups = null;
		#endregion

		#region Accessor Methods
		public ushort Action
		{
			get => action;
			set
			{
				if (action != value)
				{
					action = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public ushort Guardian
		{
			get => guard;
			set
			{
				if (guard != value)
				{
					guard = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public ushort Flags
		{
			get => flags;
			set
			{
				if (flags != value)
				{
					flags = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public ushort Flags2
		{
			get => flags2;
			set
			{
				if (flags2 != value)
				{
					flags2 = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public uint StringIndex
		{
			get => strindex;
			set
			{
				if (strindex != value)
				{
					strindex = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public uint AttenuationCode
		{
			get => attenuationcode;
			set
			{
				if (attenuationcode != value)
				{
					attenuationcode = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public float AttenuationValue
		{
			get => attenuationvalue;
			set
			{
				if (attenuationvalue != value)
				{
					attenuationvalue = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public uint Autonomy
		{
			get => autonomy;
			set
			{
				if (autonomy != value)
				{
					autonomy = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public uint JoinIndex
		{
			get => joinindex;
			set
			{
				if (joinindex != value)
				{
					joinindex = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public ushort UIDisplayType
		{
			get => uidisplaytype;
			set
			{
				if (uidisplaytype != value)
				{
					uidisplaytype = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public uint FacialAnimationID
		{
			get => facialanimation;
			set
			{
				if (facialanimation != value)
				{
					facialanimation = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public float MemoryIterativeMultiplier
		{
			get => memoryitermult;
			set
			{
				if (!memoryitermult.Equals(value))
				{
					memoryitermult = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public uint ObjectType
		{
			get => objecttype;
			set
			{
				if (objecttype != value)
				{
					objecttype = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public uint ModelTableID
		{
			get => modeltableid;
			set
			{
				if (modeltableid != value)
				{
					modeltableid = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public TtabItemMotiveTable HumanMotives
		{
			get => humanGroups;
			set
			{
				if (humanGroups != value)
				{
					humanGroups = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public TtabItemMotiveTable AnimalMotives
		{
			get => animalGroups;
			set
			{
				if (animalGroups != value)
				{
					animalGroups = value;
					parent?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		#endregion

		public TtabItem(Ttab parent)
		{
			this.parent = parent;

			if (parent.Format < 0x44)
			{
				counts = new int[] { 0x10 };
			}
			else if (parent.Format < 0x54)
			{
				counts = new int[] { 0x10, 0x10, 0x10, 0x10, 0x10, 0x10, 0x10 };
			}

			humanGroups = new TtabItemMotiveTable(
				this,
				counts,
				TtabItemMotiveTableType.Human
			);
			animalGroups = new TtabItemMotiveTable(
				this,
				null,
				TtabItemMotiveTableType.Animal
			);
		}

		public TtabItem(Ttab parent, System.IO.BinaryReader reader)
			: this(parent)
		{
			Unserialize(reader);
		}

		private void CopyTo(TtabItem target)
		{
			target.action = action;
			target.guard = guard;
			target.flags = flags;
			target.flags2 = flags2;
			target.strindex = strindex;
			target.attenuationcode = attenuationcode;
			target.attenuationvalue = attenuationvalue;
			target.autonomy = autonomy;
			target.joinindex = joinindex;
			target.uidisplaytype = uidisplaytype;
			target.facialanimation = facialanimation;
			target.memoryitermult = memoryitermult;
			target.objecttype = objecttype;
			target.modeltableid = modeltableid;
			humanGroups?.CopyTo(target.humanGroups);

			animalGroups?.CopyTo(target.animalGroups);
		}

		public TtabItem Clone(Ttab parent)
		{
			TtabItem clone = new TtabItem(this.parent)
			{
				parent = parent
			};
			CopyTo(clone);
			return clone;
		}

		public TtabItem Clone()
		{
			return Clone(parent);
		}

		/// <summary>
		/// Reads Data from the Stream
		/// </summary>
		/// <param name="reader"></param>
		private void Unserialize(System.IO.BinaryReader reader)
		{
			action = reader.ReadUInt16();
			guard = reader.ReadUInt16();

			if (counts != null)
			{
				for (int i = 0; i < counts.Length; i++)
				{
					counts[i] = reader.ReadInt32();
				}
			}

			flags = reader.ReadUInt16();
			flags2 = reader.ReadUInt16();

			strindex = reader.ReadUInt32();
			attenuationcode = reader.ReadUInt32();
			attenuationvalue = reader.ReadSingle(); //float
			autonomy = reader.ReadUInt32();
			joinindex = reader.ReadUInt32();

			uidisplaytype = 0;
			facialanimation = 0;
			memoryitermult = 0f;
			objecttype = 0;
			modeltableid = 0;
			if (parent.Format >= 0x45)
			{
				uidisplaytype = reader.ReadUInt16();
				if (parent.Format >= 0x46)
				{
					if (parent.Format >= 0x4a)
					{
						facialanimation = reader.ReadUInt32();
						if (parent.Format >= 0x4c)
						{
							memoryitermult = reader.ReadSingle(); //float
							objecttype = reader.ReadUInt32();
						}
					}
					modeltableid = reader.ReadUInt32();
				}
			}

			humanGroups = new TtabItemMotiveTable(
				this,
				counts,
				TtabItemMotiveTableType.Human,
				reader
			);
			if (parent.Format >= 0x54)
			{
				animalGroups = new TtabItemMotiveTable(
					this,
					null,
					TtabItemMotiveTableType.Animal,
					reader
				);
			}
		}

		/// <summary>
		/// Writes Data to the Stream
		/// </summary>
		/// <param name="reader"></param>
		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(action);
			writer.Write(guard);

			uint nGroups = 0;
			if (parent.Format < 0x44)
			{
				nGroups = 1;
			}
			else if (parent.Format < 0x54)
			{
				nGroups = 7;
			}

			for (int i = 0; i < nGroups; i++)
			{
				writer.Write(i < humanGroups.Count ? humanGroups[i].EntriesInUse : 0);
			}

			writer.Write(flags);
			writer.Write(flags2);
			writer.Write(strindex);
			writer.Write(attenuationcode);
			writer.Write(attenuationvalue);
			writer.Write(autonomy);
			writer.Write(joinindex);

			if (parent.Format > 0x44)
			{
				writer.Write(uidisplaytype);
				if (parent.Format >= 0x46)
				{
					if (parent.Format >= 0x4a)
					{
						writer.Write(facialanimation);
						if (parent.Format >= 0x4c)
						{
							writer.Write(memoryitermult);
							writer.Write(objecttype);
						}
					}
					writer.Write(modeltableid);
				}
			}
			humanGroups.Serialize(writer);
			if (parent.Format >= 0x54)
			{
				animalGroups.Serialize(writer);
			}
		}

		public bool InUse => true;
	}
}
