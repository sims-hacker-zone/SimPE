// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.Numerics;

using SimPe.Extensions;

namespace SimPe.Plugin
{
	/// <summary>
	/// Items for the TSFaceGeometryBuilder class
	/// </summary>
	public class TSFaceGeometryBuilderItem
	{
		#region Attributes
		public List<Vector3> Vectors1
		{
			get; set;
		}

		public List<Vector3> Vectors2
		{
			get; set;
		}

		public short Unknown1
		{
			get; set;
		}

		public int Unknown2
		{
			get; set;
		}
		#endregion

		public TSFaceGeometryBuilderItem()
		{
			Vectors1 = new List<Vector3>();
			Vectors2 = new List<Vector3>();
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal virtual void Unserialize(System.IO.BinaryReader reader)
		{
			Unknown1 = reader.ReadInt16();
			Unknown2 = reader.ReadInt32();
			int count = reader.ReadInt32();
			Vectors1.Clear();
			for (int i = 0; i < count; i++)
			{
				Vector3 o = new Vector3();
				o.Unserialize(reader);
				Vectors1.Add(o);
			}

			count = reader.ReadInt32();
			Vectors2.Clear();
			for (int i = 0; i < count; i++)
			{
				Vector3 o = new Vector3();
				o.Unserialize(reader);
				Vectors2.Add(o);
			}
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		internal virtual void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(Unknown1);
			writer.Write(Unknown2);

			writer.Write(Vectors1.Count);
			for (int i = 0; i < Vectors1.Count; i++)
			{
				Vectors1[i].Serialize(writer);
			}

			writer.Write(Vectors2.Count);
			for (int i = 0; i < Vectors2.Count; i++)
			{
				Vectors2[i].Serialize(writer);
			}
		}
	}
}
