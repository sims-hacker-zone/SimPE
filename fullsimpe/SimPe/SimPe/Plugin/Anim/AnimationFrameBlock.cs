// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;

using SimPe.Geometry;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// Data is unknown
	/// </summary>
	public class AnimationFrameBlock : AnimBlock, ICloneable
	{
		#region Attributes
		[Browsable(false)]
		public AnimationMeshBlock Parent
		{
			get;
		}

		[Browsable(false)]
		public List<AnimationAxisTransformBlock> AxisSet
		{
			get; private set;
		}

		[
			Description("Number of loaded AnimationAxisTransformBlock Items"),
			Category("Information")
		]
		public int AxisCount => AxisSet.Count;

		internal int MaxAxisFrameCount
		{
			get
			{
				int ct = 0;
				foreach (AnimationAxisTransformBlock ab in AxisSet)
				{
					ct = Math.Max(ct, ab.Count);
				}

				return ct;
			}
		}

		[
			Description("Number of loaded Frames"),
			Category("Information")
		]
		public int FrameCount => Frames.Length;

		public void InterpolateMissingBlocks(AnimationFrame[] frames, short maxtime)
		{
			if (frames.Length == 0)
			{
				return;
			}

			for (int i = 0; i < frames.Length; i++)
			{
				for (int j = 0; j < frames[i].Blocks.Length; j++)
				{
					if (frames[i].Blocks[j] == null)
					{
						Interpolate(frames, i, j, maxtime);
					}
				}
			}
		}

		public AnimationFrame[] InterpolateMissingFrames()
		{
			AnimationFrame[] frames = UnlockedFrames;
			if (frames.Length != 0)
			{
				InterpolateMissingBlocks(frames, frames[frames.Length - 1].TimeCode);
			}

			return frames;
		}

		public AnimationFrame[] GetFrames(bool exludelocked)
		{
			ArrayList tclist = new ArrayList();
			Hashtable ht = new Hashtable();
			ArrayList list = new ArrayList();

			//get a List of all TimeCodes
			for (int i = 0; i < MaxAxisFrameCount; i++)
			{
				foreach (AnimationAxisTransformBlock ab in AxisSet)
				{
					List<int> tcs = ab.GetTimeCodes(true, true);

					if (ab.Locked && exludelocked && ab.Count <= 1)
					{
						tcs.Clear();
					}

					foreach (int rtc in tcs)
					{
						short tc = (short)rtc;
						if (!tclist.Contains(tc))
						{
							tclist.Add(tc);
							ht[tc] = new AnimationFrame(tc, TransformationType);
						}
					}
				}
			}

			tclist.Sort();
			for (int part = 0; part < AxisSet.Count; part++)
			{
				AnimationAxisTransformBlock ab = AxisSet[part];
				if (ab.Locked && exludelocked && ab.Count <= 1)
				{
					continue;
				}

				for (int i = 0; i < ab.Count; i++)
				{
					//if ((ab[i].Event && !events) || (!ab[i].Event && events)) continue;

					short tc = ab.GetTimeCode(i);
					AnimationFrame af = (AnimationFrame)ht[tc];
					if (af != null)
					{
						if (part == 0)
						{
							af.XBlock = ab[i];
						}
						else if (part == 1)
						{
							af.YBlock = ab[i];
						}
						else if (part == 2)
						{
							af.ZBlock = ab[i];
						}
					}
				}
			}

			//build ordered List
			foreach (short tc in tclist)
			{
				list.Add(ht[tc]);
			}

			AnimationFrame[] afs = new AnimationFrame[list.Count];
			list.CopyTo(afs);
			return afs;
		}

		[
			Description("Available Frames"),
			Category("Information"),
			Browsable(false)
		]
		public AnimationFrame[] Frames => GetFrames(false);

		[
			Description("Available Frames"),
			Category("Information"),
			Browsable(false)
		]
		public AnimationFrame[] UnlockedFrames => GetFrames(false); //should be true normaly, but that seems not to work!

		uint[] datai;

		[
			Description("Reserved"),
			Category("Reserved"),
			DefaultValue(0x11BA05F0)
		]
		public uint Unknown1
		{
			get => datai[0];
			set => datai[0] = value;
		}

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

		[
			Description("CRC32 over the Name."),
			Category("Information"),
			ReadOnly(true)
		]
		public uint NameChecksum
		{
			get => datai[2];
			set => datai[2] = value;
		}

#if DEBUG
#else
		[Browsable(false)]
#endif
		public uint GeneratedNameChecksum
		{
			get
			{
				byte[] rt = Hashes.Crc32.ComputeHash(Helper.ToBytes(Name, 0)); //CRC24Seed, CRC24Poly, filename.ToCharArray());

				return (uint)Hashes.ToLong(rt);
			}
		}

		[
			Description("Reserved"),
			Category("Reserved"),
			DefaultValue(0x11BA05F0)
		]
		public uint Unknown4
		{
			get => datai[3];
			set => datai[3] = value;
		}

		[
			Description("What kind of Transformation is performed."),
			Category("Information")
		]
		public FrameType TransformationType
		{
			get
			{
				uint i = Unknown5 & 0x01F00000;
				i >>= 20;
				return (FrameType)(byte)i;
			}
			set
			{
				uint i = (uint)value;
				i <<= 20;
				i &= 0x01F00000;
				Unknown5 = (Unknown5 & 0xFE0FFFFF) | i;
			}
		}

		[
			Description("The duration of this animation Block."),
			Category("Information"),
			ReadOnly(true)
		]
		public short Duration
		{
			get
			{
				uint i = Unknown5 & 0x00007FFF;
				return (short)i;
			}
			set
			{
				uint i = (uint)value;
				i &= 0x00007FFF;
				i |= 0x00008000;
				Unknown5 = (Unknown5 & 0xFFFF0000) | i;
			}
		}

		public override string Name
		{
			get => base.Name;
			set
			{
				base.Name = value;
				NameChecksum = GeneratedNameChecksum;
			}
		}

		[Description(
			"Highest 3 Bits (Bit 31-29) contain the Number of assigned AnimationAxisTransformBlock Items, Bits 16-23 describe the Transformation Type (0=Translation, C=Rotation). Bits 0-15 Decode the Time this Animation Runs."
		)]
		public uint Unknown5
		{
			get => datai[4];
			set => datai[4] = value;
		}

		[Description("Bits 24-28 of Unknown5")]
		public byte Unknown5Bits
		{
			get
			{
				uint i = Unknown5 & 0x1E000000;
				i >>= 25;
				return (byte)i;
			}
			set
			{
				uint i = ((uint)value << 24) & 0x1E000000;
				Unknown5 = (Unknown5 & 0xE1FFFFFF) | i;
			}
		}

		[Description(
			"Highest 3 Bits contain the Number of assigned AnimationAxisTransformBlock Items"
		)]
		public string Unknown5Binary
		{
			get
			{
				string s = Convert.ToString(Unknown5, 2);
				s = Helper.MinStrLength(s, 32);
				int p = s.Length - 4;
				while (p >= 0)
				{
					s = s.Insert(p, " ");
					p -= 4;
				}
				return s.Trim();
			}
		}

		[Description(
			"Highest 3 Bits contain the Number of assigned AnimationAxisTransformBlock Items"
		)]
		public string Unknown5Hex => "0x" + Helper.HexString(Unknown5);

		[
			Description("Reserved"),
			Category("Reserved"),
			DefaultValue(0x11BA05F0)
		]
		public uint Unknown6
		{
			get => datai[5];
			set => datai[5] = value;
		}
		#endregion

		public AnimationFrameBlock CloneBase(bool fullclone)
		{
			AnimationFrameBlock ab = new AnimationFrameBlock(Parent)
			{
				datai = (uint[])datai.Clone(),
				name = name
			};
			if (fullclone)
			{
				ab.AxisSet = new List<AnimationAxisTransformBlock>();
				for (int i = 0; i < AxisCount; i++)
				{
					ab.AxisSet.Add(AxisSet[i].CloneBase());
				}
			}

			return ab;
		}

		/// <summary>
		/// Creat an additional Part3 Item
		/// </summary>
		public void AddNewAxis()
		{
			AxisSet.Add(new AnimationAxisTransformBlock(this));
		}

		public void CreateBaseAxisSet()
		{
			CreateBaseAxisSet(AnimationTokenType.SixByte);
		}

		public void CreateBaseAxisSet(AnimationTokenType t)
		{
			AxisSet = new List<AnimationAxisTransformBlock>();
			for (int i = 0; i < 3; i++)
			{
				AxisSet.Add(new AnimationAxisTransformBlock(this)
				{
					Type = t
				});
			}
		}

		/// <summary>
		/// Change the TokenType of all AxisSets to t
		/// </summary>
		/// <param name="t">The new TokenType</param>
		public void ChangeTokenType(AnimationTokenType t)
		{
			for (int i = 0; i < AxisCount; i++)
			{
				AxisSet[i].Type = t;
			}
		}

		/// <summary>
		/// Change the TokenType of all AxisSets to t, if the currently are set to current. Otherwise do not change
		/// </summary>
		/// <param name="current">The current TokenType</param>
		/// <param name="t">The new TokenType</param>
		public void ChangeTokenType(AnimationTokenType current, AnimationTokenType t)
		{
			for (int i = 0; i < AxisCount; i++)
			{
				if (AxisSet[i].Type == current)
				{
					AxisSet[i].Type = t;
				}
			}
		}

		public void SortByTimeCode()
		{
			for (int i = 0; i < AxisCount; i++)
			{
				AxisSet[i].Sort();
			}
		}

		public void ClearFrames()
		{
			ClearFrames(true, true);
		}

		public void ClearFrames(bool clearlinear, bool clearnonlinear)
		{
			for (int i = 0; i < AxisCount; i++)
			{
				AxisSet[i].Clear(clearlinear, clearnonlinear);
			}
		}

		/// <summary>
		/// Return the value matching the id
		/// </summary>
		/// <param name="id">Id of the Component you want to write</param>
		/// <param name="x">returned when id=0</param>
		/// <param name="y">returned when id=1</param>
		/// <param name="z">returned when id=2</param>
		/// <returns>0, x, y, or z</returns>
		public static short GetAxisValue(int id, short x, short y, short z)
		{
			if (id == 0)
			{
				return x;
			}
			else if (id == 1)
			{
				return y;
			}
			else if (id == 2)
			{
				return z;
			}

			return 0;
		}

		public AnimationFrame GetFrameAtTimeCode(short tc)
		{
			AnimationFrame[] frames = Frames;
			foreach (AnimationFrame f in frames)
			{
				if (f.TimeCode == tc)
				{
					return f;
				}
			}

			return null;
		}

		public AnimationFrame AddFrame(short tc, short x, short y, short z, bool linear)
		{
			AnimationFrame af = new AnimationFrame(tc, TransformationType);
			//af.Blocks = new AnimationAxisTransform[AxisCount];
			for (int i = 0; i < AxisCount; i++)
			{
				AnimationAxisTransformBlock b = AxisSet[i];
				AnimationAxisTransform aat = b.Add(
					tc,
					GetAxisValue(i, x, y, z),
					0,
					0,
					linear
				);

				if (i < 4)
				{
					af.Blocks[i] = aat;
				}
			}

			return af;
		}

		public void AddFrame(short tc, float x, float y, float z, bool linear)
		{
			for (int i = 0; i < AxisCount; i++)
			{
				AnimationAxisTransformBlock b = AxisSet[i];
				b.Add(
					tc,
					GetAxisValue(
						i,
						b.FromCompressedFloat(x),
						b.FromCompressedFloat(y),
						b.FromCompressedFloat(z)
					),
					0,
					0,
					linear
				);
			}
		}

		public void AddFrame(short tc, Vector3 v, bool linear)
		{
			AddFrame(tc, v.X, v.Y, v.Z, linear);
		}

		public AnimationFrameBlock(AnimationMeshBlock parent)
		{
			Parent = parent;
			datai = new uint[6];
			datai[0] = 297403888;
			datai[1] = 297403888;
			datai[3] = 297403888;
			datai[5] = 297403888;
			Unknown5Bits = 15;
			AxisSet = new List<AnimationAxisTransformBlock>();
			TransformationType = FrameType.Unknown;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializeData(System.IO.BinaryReader reader)
		{
			datai[0] = reader.ReadUInt32();
			datai[1] = reader.ReadUInt32();
			datai[2] = reader.ReadUInt32(); // unknown Data
			datai[3] = reader.ReadUInt32();
			datai[4] = reader.ReadUInt32(); // contains the part3 count and unknown data
			datai[5] = reader.ReadUInt32();
		}

		/// <summary>
		/// Returns the Higest available TimeCode
		/// </summary>
		/// <returns></returns>
		public short GetDuration()
		{
			short tc = 0;
			foreach (AnimationAxisTransformBlock ab in AxisSet)
			{
				tc = Math.Max(tc, ab.LastTimeCode);
			}

			return tc;
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializeData(System.IO.BinaryWriter writer)
		{
			SetPart3Count(AxisSet.Count);

			writer.Write(datai[0]);
			writer.Write(datai[1]);
			writer.Write(datai[2]);
			writer.Write(datai[3]);
			writer.Write(datai[4]);
			writer.Write(datai[5]);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializePart3Data(System.IO.BinaryReader reader)
		{
			AxisSet = new List<AnimationAxisTransformBlock>();
			for (int i = 0; i < GetPart3Count(); i++)
			{
				AxisSet.Add(new AnimationAxisTransformBlock(this));
				AxisSet[i].UnserializeData(reader);
			}
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializePart3Data(System.IO.BinaryWriter writer)
		{
			for (int i = 0; i < AxisSet.Count; i++)
			{
				AxisSet[i].SerializeData(writer);
			}
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializePart3AddonData(System.IO.BinaryReader reader)
		{
			for (int i = 0; i < AxisSet.Count; i++)
			{
				AxisSet[i].UnserializeAddonData(reader);
			}
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializePart3AddonData(System.IO.BinaryWriter writer)
		{
			for (int i = 0; i < AxisSet.Count; i++)
			{
				AxisSet[i].SerializeAddonData(writer);
			}
		}

		/// <summary>
		/// Returns the Number of Items for Part 3 assigned to this Object
		/// </summary>
		/// <returns>Number of Items</returns>
		int GetPart3Count()
		{
			//using highest 3-Bits xxx0 0000 0000 0000 0000 0000 0000 0000
			return ((int)datai[4] >> 0x1D) & 0x7;
		}

		/// <summary>
		/// Set the count for Part 5 Items
		/// </summary>
		/// <param name="ct">The New Count</param>
		void SetPart3Count(int ct)
		{
			if (ct > 7)
			{
				ct = 7;
			}

			ct &= 0x00000007;
			ct <<= 0x1D;
			datai[4] = datai[4] & 0x1FFFFFFF;

			datai[4] = (uint)((ulong)datai[4] | (uint)ct);
		}

		#region ICloneable Member

		object ICloneable.Clone()
		{
			return CloneBase(true);
		}

		#endregion

		public AnimationAxisTransform InterpolateFrame(
			AnimationAxisTransform first,
			AnimationAxisTransform last,
			short timecode
		)
		{
			AnimationAxisTransform b = new AnimationAxisTransform(null, -1)
			{
				TimeCode = timecode,
				Linear = first.Linear || last.Linear
			};

			if (first.TimeCode == last.TimeCode)
			{
				b.Parameter = first.Parameter;
			}
			else
			{
				//swap first and last?
				if (first.TimeCode > last.TimeCode)
				{
					(last, first) = (first, last);
				}

				float pos =
					(b.TimeCode - first.TimeCode)
					/ (float)(last.TimeCode - first.TimeCode);
				short val = (short)(
					((last.Parameter - first.Parameter) * pos) + first.Parameter
				);

				b.Parameter = val;
			}

			if (AxisCount > 0)
			{
				b.SetParent(AxisSet[0]);
			}

			return b;
		}

		void Interpolate(AnimationFrame[] frames, int index, int blid, short maxtime)
		{
			int last = index - 1;
			int next = index + 1;

			while (last >= 0)
			{
				if (frames[last].Blocks[blid] != null)
				{
					break;
				}

				last--;
			}

			while (next < frames.Length)
			{
				if (frames[next].Blocks[blid] != null)
				{
					break;
				}

				next++;
			}

			AnimationAxisTransform lb = new AnimationAxisTransform(null, -1)
			{
				TimeCode = Math.Min((short)0, frames[index].TimeCode),
				Linear = frames[index].Linear
			};

			//if (last<0 && next<frames.Length) last=next; //if the first Frame is missing, use the Position of the next Frame
			if (last >= 0)
			{
				lb.TimeCode = frames[last].TimeCode;
				lb.Parameter = frames[last].Blocks[blid].Parameter;
				if (frames[last].Blocks[blid].Parent != null)
				{
					if (lb.TimeCode == 0 && frames[last].Blocks[blid].Parent.Locked)
					{
						lb.Parameter = 0;
					}
				}
			}

			AnimationAxisTransform nb = new AnimationAxisTransform(null, -1)
			{
				TimeCode = Math.Max(maxtime, frames[index].TimeCode),
				Parameter = lb.Parameter,
				Linear = frames[index].Linear
			};

			if (next < frames.Length)
			{
				nb.TimeCode = frames[next].TimeCode;
				nb.Parameter = frames[next].Blocks[blid].Parameter;
			}

			frames[index].Blocks[blid] = InterpolateFrame(
				lb,
				nb,
				frames[index].TimeCode
			);
		}

		/// <summary>
		/// This Operation will remove all Frames, that are not needed to perform the Animation
		/// </summary>
		/// <remarks>
		/// Unneeded Frames are ones, that can be interpolated by
		/// the previous and following Frame
		/// </remarks>
		public void RemoveUnneededFrames()
		{
			const float DELTA = float.Epsilon * 10;
			for (int blid = AxisSet.Count - 1; blid >= 0; blid--)
			{
				List<int> remlist = new List<int>();
				for (int nr = 1; nr < AxisSet[blid].Count - 1; nr++)
				{
					AnimationAxisTransform iframe = null;
					/*if (nr==0) iframe = this.AxisSet[blid][nr+1];
					else if (nr==this.AxisSet[blid].Count-1) iframe = this.AxisSet[blid][nr+1];
					else*/
					iframe = InterpolateFrame(
						AxisSet[blid][nr - 1],
						AxisSet[blid][nr + 1],
						AxisSet[blid][nr].TimeCode
					);

					if (
						Math.Abs(iframe.Parameter - AxisSet[blid][nr].Parameter)
						< DELTA
					)
					{
						remlist.Add(nr);
					}
				}

				//sort the List and remove the marked Transformations
				remlist.Sort();
				for (int i = remlist.Count - 1; i >= 0; i--)
				{
					AxisSet[blid].Remove(AxisSet[blid][remlist[i]]);
				}

				//two or more remaining Frames, where the last two have the same Parameter ==> delete the last one
				if (AxisSet[blid].Count >= 2)
				{
					if (
						AxisSet[blid][AxisSet[blid].Count - 2].Parameter
						== AxisSet[blid][AxisSet[blid].Count - 1].Parameter
					)
					{
						AxisSet[blid].Remove(AxisSet[blid][AxisSet[blid].Count - 1]);
					}
				}

				//Now set the suggested Type that should be used
				if (AxisSet[blid].Count == 1)
				{
					if (AxisSet[blid].FirstTimeCode == 0)
					{
						AxisSet[blid].Type = AnimationTokenType.TwoByte;
					}
				}
				else if (AxisSet[blid].Count == 0)
				{
					AxisSet.Remove(AxisSet[blid]);
				}
			}
		}

		public override string ToString()
		{
			string s = Name + " (";
			if (TransformationType == FrameType.Translation)
			{
				s += "trn";
			}
			else
			{
				s += "rot";
			}
			//s += ", "+this.FrameCount.ToString();
			for (int i = 0; i < AxisSet.Count; i++)
			{
				s += ", " + AxisSet[i].Count.ToString();
			}

			s += ")";
			return s;
		}
	}
}
