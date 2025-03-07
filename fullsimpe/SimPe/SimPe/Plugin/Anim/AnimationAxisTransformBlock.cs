// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// Data is unknown
	/// </summary>
	public class AnimationAxisTransformBlock
		: ICloneable,
			IEnumerable
	{
		#region Attributes
		[Browsable(false)]
		public AnimationFrameBlock Parent
		{
			get; set;
		}

		uint[] datai;

		[
			Description(
				"Lower 16 Bits contain the count, Bit 16-17 contain the type of the assigned AddonData. Bit 18 seems to Lock the Animation"
			),
			Category("Information")
		]
		public uint Unknown1
		{
			get => datai[0];
			set => datai[0] = value;
		}

		[
			Description(
				"Setting this Bit seems to Lock the Animation. However I am not sure about this!"
			),
			Category("Information")
		]
		public bool Locked
		{
			get => ((Unknown1 >> 0x12) & 1) == 1;
			set
			{
				uint i = 0;
				if (value)
				{
					i = 1;
					i <<= 0x12;
				}

				Unknown1 = (Unknown1 & 0xFFFBFFFF) | i;
			}
		}

		[Description("Unknown Parts of Unknown1.")]
		public uint Unknown1Bits
		{
			get => Unknown1 >> 0x12;
			set => Unknown1 =
					(Unknown1 & 0x0003FFFF) | ((value << 0x12) & 0xFFFC0000)
				;
		}

		public string Unknown1Binary
		{
			get
			{
				string s = Convert.ToString(Unknown1Bits, 2);
				s = Helper.MinStrLength(s, 14);
				int p = s.Length - 4;
				while (p >= 0)
				{
					s = s.Insert(p, " ");
					p -= 4;
				}
				return s.Trim();
			}
		}

		public string Unknown1Hex => "0x" + Helper.HexString(Unknown1Bits);

		[
			Description("Reserved"),
			Category("Reserved"),
			DefaultValue(0x11BA05F0)
		]
		public uint Unknown2
		{
			get => datai[1];
			set => datai[1] = value;
		}

		ArrayList items;

		byte type;

		[
			Description("Propbably some sort of Type Identifier"),
			Category("Information")
		]
		public AnimationTokenType Type
		{
			get => (AnimationTokenType)type;
			set => type = (byte)value;
		}

		[
			Description("The First TimeCode for this Transformation Element"),
			Category("Information")
		]
		public short FirstTimeCode
		{
			get
			{
				short tc = short.MaxValue;
				for (int i = 0; i < Count; i++)
				{
					tc = Math.Min(tc, GetTimeCode(i));
				}

				if (tc == short.MaxValue)
				{
					tc = 0;
				}

				return tc;
			}
		}

		[
			Description("The Last TimeCode for this Transformation Element"),
			Category("Information")
		]
		public short LastTimeCode
		{
			get
			{
				short tc = 0;
				for (int i = 0; i < Count; i++)
				{
					tc = Math.Max(tc, GetTimeCode(i));
				}

				return tc;
			}
		}

		[
			Description("Size (in Bytes) of one Addon Token"),
			Category("Information")
		]
		public byte TokenSize
		{
			get
			{
				byte size = type == 0 ? (byte)1 : type == 1 ? (byte)3 : (byte)4;

				return size;
			}
		}

		[
			Description("Remaining Information stored in Unknown1"),
			Category("Information")
		]
		public uint AddonTokenUnknown => Unknown1 >> 0x13;

		[
			Description("Number of Tokens stored in the Addon Data"),
			Category("Information")
		]
		public int Count => items.Count;
		#endregion

		/// <summary>
		/// Returns the TimeCode for the indexth Frame
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public short GetTimeCode(int index)
		{
			return index < 0 || index >= Count ? (short)0 : this[index].TimeCode;
		}

		public AnimationAxisTransformBlock CloneBase()
		{
			AnimationAxisTransformBlock ab = new AnimationAxisTransformBlock(null)
			{
				datai = (uint[])datai.Clone()
			};
			foreach (AnimationAxisTransform aat in items)
			{
				ab.Add(aat.CloneBase());
			}

			ab.type = type;

			return ab;
		}

		public AnimationAxisTransformBlock(AnimationFrameBlock parent)
		{
			items = new ArrayList();
			datai = new uint[2];
			Parent = parent;

			Type = AnimationTokenType.SixByte;
			Unknown1Bits = 0;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializeData(System.IO.BinaryReader reader)
		{
			datai[0] = reader.ReadUInt32();
			datai[1] = reader.ReadUInt32();
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializeData(System.IO.BinaryWriter writer)
		{
			SetCount(items.Count * TokenSize);
			writer.Write(datai[0]);
			writer.Write(datai[1]);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializeAddonData(System.IO.BinaryReader reader)
		{
			int ct = GetCount() / TokenSize;

			for (int i = 0; i < ct; i++)
			{
				AnimationAxisTransform aat = new AnimationAxisTransform(this, i);
				aat.UnserializeData(reader);
				items.Add(aat);
			}
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializeAddonData(System.IO.BinaryWriter writer)
		{
			//this.Sort();
			for (int i = 0; i < Count; i++)
			{
				((AnimationAxisTransform)items[i]).SerializeData(writer);
			}
		}

		public override string ToString()
		{
			string n = Type.ToString();
			if (n.Length > 4)
			{
				n = n.Substring(0, n.Length - 4);
			}

			string s = n + ": ";

			s += TokenSize.ToString() + " " + Unknown1Bits.ToString();
			s += " (" + Count.ToString();
			if (Locked)
			{
				s += ", locked";
			}

			s += ")";
			return s;
		}

		/// <summary>
		/// Return the number of Additional Word Values
		/// </summary>
		/// <returns>number of additional words to read</returns>
		int GetCount()
		{
			short dum = (short)((int)datai[0] >> 0x10);
			short count = (short)(datai[0] & 0xffff);
			type = (byte)(dum & 3);
			int size = TokenSize;

			return count * size;
		}

		/// <summary>
		/// Set the count for Part 5 Items
		/// </summary>
		/// <param name="ct">The New Count</param>
		void SetCount(int ct)
		{
			int size = TokenSize;
			int count = ct / size;

			count = (type << 0x10) | count;

			datai[0] = (uint)(
				((ulong)datai[0] & 0xFFFC0000) | ((ulong)count & 0x0003FFFF)
			);
		}

		/// <summary>
		/// Returns a List of available TimeCodes
		/// </summary>
		/// <param name="linear">true if you want to have TimeCodes for Linear KeyFrames</param>
		/// <param name="nonlinear">true if you want TimeCodes for Non Linear KeyFrames</param>
		/// <returns>List of TimeCodes</returns>
		public List<int> GetTimeCodes(bool linear, bool nonlinear)
		{
			List<int> list = new List<int>();

			foreach (AnimationAxisTransform aat in items)
			{
				if ((aat.Linear && linear) || (!aat.Linear && nonlinear))
				{
					list.Add(aat.TimeCode);
				}
			}

			return list;
		}

		#region ICloneable Member

		object ICloneable.Clone()
		{
			return CloneBase();
		}

		#endregion

		#region Collection Members
		/// <summary>
		/// Sorts the stored Frames by TimeCode
		/// </summary>
		public void Sort()
		{
			items.Sort();
		}

		/// <summary>
		/// Returns the Last Frame
		/// </summary>
		/// <returns></returns>
		public AnimationAxisTransform GetLast()
		{
			return Count == 0 ? null : this[Count - 1];
		}

		/// <summary>
		/// Returns the First Frame
		/// </summary>
		/// <returns></returns>
		public AnimationAxisTransform GetFirst()
		{
			return Count == 0 ? null : this[0];
		}

		public AnimationAxisTransform BuildAnimationAxisTransform(
			short timecode,
			short param,
			short u1,
			short u2,
			bool islinear,
			int index
		)
		{
			AnimationAxisTransform aat = new AnimationAxisTransform(this, index)
			{
				TimeCode = timecode,
				Linear = islinear,
				Parameter = param,
				Unknown1 = u1,
				Unknown2 = u2
			};

			return aat;
		}

		/// <summary>
		/// Add a new <see cref="AnimationAxisTransform"/> based on a Cloned Object
		/// </summary>
		/// <param name="aat">The Item you want to Add</param>
		/// <exception cref="AxisTransformException">
		/// Thrown, if the Item you triy to add, is a Child of another <see cref="AnimationAxisTransformBlock"/>,
		/// or is already included in the current Listing. Before add a Frame, you have to create a Clone!
		/// </exception>
		public void Add(AnimationAxisTransform aat)
		{
			if ((aat.Parent != this && aat.Parent != null) || aat.Index != -1)
			{
				throw new AxisTransformException(
					"Can't add the passed AnimationAxisTransform!"
				);
			}

			aat.SetIndex(items.Count);
			aat.SetParent(this);
			items.Add(aat);
		}

		public bool ContainsTimeCode(short timecode)
		{
			foreach (AnimationAxisTransform a in items)
			{
				if (a.TimeCode == timecode)
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Add a new <see cref="AnimationAxisTransform"/> Item
		/// </summary>
		/// <param name="timecode"></param>
		/// <param name="param"></param>
		/// <param name="u1"></param>
		/// <param name="u2"></param>
		/// <param name="islinear"></param>
		/// <remarks>The Data does not get added when the timecode already exists, null will be returned in that case</remarks>
		public AnimationAxisTransform Add(
			short timecode,
			short param,
			short u1,
			short u2,
			bool islinear
		)
		{
			AnimationAxisTransform aat = BuildAnimationAxisTransform(
				timecode,
				param,
				u1,
				u2,
				islinear,
				items.Count
			);
			if (ContainsTimeCode(timecode))
			{
				return null;
			}

			items.Add(aat);
			return aat;
		}

		/// <summary>
		/// Add new <see cref="AnimationAxisTransform"/> Items
		/// </summary>
		/// <param name="howmany"></param>
		/// <param name="islinear"></param>
		/// <remarks>Adds the amount of Data blocks according to howmany</remarks>
		public AnimationAxisTransform Add(int howmany, bool islinear)
		{
			while (howmany > 0)
			{
				AnimationAxisTransform aat = BuildAnimationAxisTransform(
					0,
					0,
					0,
					0,
					islinear,
					items.Count
				);
				items.Add(aat);
				howmany--;
			}
			return null;
		}

		/// <summary>
		/// Insert a new <see cref="AnimationAxisTransform"/> based on a Cloned Object
		/// </summary>
		/// <param name="index">The index within the List</param>
		/// <param name="aat">The Item you want to Add</param>
		/// <exception cref="AxisTransformException">
		/// Thrown, if the Item you triy to add, is a Child of another <see cref="AnimationAxisTransformBlock"/>,
		/// or is already included in the current Listing. Before add a Frame, you have to create a Clone!
		/// </exception>
		public void Insert(int index, AnimationAxisTransform aat)
		{
			if ((aat.Parent != this && aat.Parent != null) || aat.Index != -1)
			{
				throw new AxisTransformException(
					"Can't add the passed AnimationAxisTransform!"
				);
			}

			aat.SetIndex(index);
			aat.SetParent(this);
			items.Insert(index, aat);
			ReIndex(index + 1);
		}

		/// <summary>
		/// Insert a new <see cref="AnimationAxisTransform"/> Item
		/// </summary>
		/// <param name="index">The index within the List</param>
		/// <param name="timecode"></param>
		/// <param name="param"></param>
		/// <param name="u1"></param>
		/// <param name="u2"></param>
		/// <param name="islinear"></param>
		public void Insert(
			int index,
			short timecode,
			short param,
			short u1,
			short u2,
			bool islinear
		)
		{
			items.Insert(
				index,
				BuildAnimationAxisTransform(timecode, param, u1, u2, islinear, index)
			);
			ReIndex(index + 1);
		}

		/// <summary>
		/// Remove all Data Stored here
		/// </summary>
		/// <param name="clearlinear">true if you want to clear linear transformations</param>
		/// <param name="clearnonlinear">true if you want to clear non Linear KeyFrames</param>
		public void Clear(bool clearlinear, bool clearnonlinear)
		{
			if (clearlinear && clearnonlinear)
			{
				Clear();
			}
			else
			{
				ArrayList list = new ArrayList();

				foreach (AnimationAxisTransform aat in items)
				{
					if (aat.Linear && !clearlinear)
					{
						list.Add(aat);
					}

					if (!aat.Linear && !clearnonlinear)
					{
						list.Add(aat);
					}
				}

				items.Clear();
				items = list;
				ReIndex();
			}
		}

		/// <summary>
		/// Clear al stored Transformations
		/// </summary>
		public void Clear()
		{
			for (int i = items.Count - 1; i >= 0; i--)
			{
				((AnimationAxisTransform)items[i]).Dispose();
			}

			items.Clear();
		}

		/// <summary>
		/// Remove the passed Item from the Parent
		/// </summary>
		/// <param name="aat"></param>
		public void Remove(AnimationAxisTransform aat)
		{
			int ct = items.Count;
			items.Remove(aat);
			ReIndex();

			if (ct != items.Count)
			{
				aat.SetParent(null);
				aat.SetIndex(-1);
			}
		}

		/// <summary>
		/// Integer Indexer
		/// </summary>
		public AnimationAxisTransform this[int index]
		{
			get => (AnimationAxisTransform)items[index];
			set => items[index] = value;
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public AnimationAxisTransform this[uint index]
		{
			get => (AnimationAxisTransform)items[(int)index];
			set => items[(int)index] = value;
		}

		/// <summary>
		/// Make sure the indices stored in the items Elements are in sync
		/// </summary>
		protected void ReIndex()
		{
			ReIndex(0);
		}

		/// <summary>
		/// Make sure the indices stored in the items Elements are in sync
		/// </summary>
		/// <param name="start">the first Block you want to check</param>
		protected void ReIndex(int start)
		{
			start = Math.Max(0, start);
			for (int i = start; i < items.Count; i++)
			{
				((AnimationAxisTransform)items[i]).SetIndex(i);
			}
		}
		#endregion

		#region IEnumerable Member

		public IEnumerator GetEnumerator()
		{
			return items.GetEnumerator();
		}

		#endregion

		#region Float Converters
		public float GetScale()
		{
			FrameType ft = FrameType.Translation;
			if (Parent != null)
			{
				ft = Parent.TransformationType;
			}

			return GetScale(ft);
		}

		public float GetCompressedFloat(short val)
		{
			return GetCompressedFloat(val, GetScale());
		}

		public short FromCompressedFloat(float val)
		{
			return FromCompressedFloat(val, GetScale());
		}

		public float GetScale(FrameType ft)
		{
			return GetScale(Locked, ft);
		}

		public static float GetScale(bool locked, FrameType ft)
		{
			float scale = SCALE;
			if (!locked)
			{
				scale *= 16f;
			}

			if (ft == FrameType.Rotation)
			{
				scale = SCALEROT;
			}

			return scale;
		}

		public float GetCompressedFloat(short val, FrameType ft)
		{
			return GetCompressedFloat(val, GetScale(ft));
		}

		public short FromCompressedFloat(float val, FrameType ft)
		{
			return FromCompressedFloat(val, GetScale(ft));
		}

		#region statics
		public const float SCALE = 1.0f / 1000f;
		public const float SCALEROT = (float)(1f / 180f * Math.PI / 64f);

		public static float GetCompressedFloat(short v, float scale)
		{
			return v * scale;
		}

		public static short FromCompressedFloat(float v, float scale)
		{
			return (short)(v / scale);
		}
		#endregion
		#endregion
	}
}
