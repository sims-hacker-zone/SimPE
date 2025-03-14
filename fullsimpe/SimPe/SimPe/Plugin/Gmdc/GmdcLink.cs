// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;

namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// This Section References the Element Data
	/// </summary>
	public class GmdcLink : GmdcLinkBlock
	{
		#region Attributes

		/// <summary>
		/// This returns the List of all used <see cref="GmdcElement"/> Items. The Values are Indices
		/// for the <see cref="GeometryDataContainer.Elements"/> Property.
		/// </summary>
		public List<int> ReferencedElement
		{
			get; set;
		}

		/// <summary>
		/// The Number of Elements that are Referenced by this Link
		/// </summary>
		public int ReferencedSize
		{
			get; set;
		}

		/// <summary>
		/// How many <see cref="GmdcElement"/> Items are referenced by this Link
		/// </summary>
		public int ActiveElements
		{
			get; set;
		}

		/// <summary>
		/// This Array Contains three <see cref="List<int>"/> Items. Each Item has to be interporeted as
		/// Element Index Alias.
		/// The <see cref="GmdcGroup"/> is referencing the Vertices that form a Face by an Index. If one of
		/// this Lists is set, it means, that whenever you pares an Index, read the value stored at that Index
		/// in one of this Lists. The Value read from there is then thge actual <see cref="GmdcElement"/> Index.
		///
		/// The first List store here is an Alias Map for the first referenced <see cref="GmdcElement"/> in the
		/// <see cref="ReferencedElement"/> Property.
		/// </summary>
		public List<int>[] AliasValues
		{
			get;
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public GmdcLink(GeometryDataContainer parent)
			: base(parent)
		{
			ReferencedElement = new List<int>();
			AliasValues = new List<int>[3];
			for (int i = 0; i < AliasValues.Length; i++)
			{
				AliasValues[i] = new List<int>();
			}
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			ReadBlock(reader, ReferencedElement);

			ReferencedSize = reader.ReadInt32();
			ActiveElements = reader.ReadInt32();

			for (int i = 0; i < AliasValues.Length; i++)
			{
				ReadBlock(reader, AliasValues[i]);
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
		public void Serialize(System.IO.BinaryWriter writer)
		{
			WriteBlock(writer, ReferencedElement);

			writer.Write(ReferencedSize);
			writer.Write(ActiveElements);

			for (int i = 0; i < AliasValues.Length; i++)
			{
				WriteBlock(writer, AliasValues[i]);
			}
		}

		/// <summary>
		/// This output is used in the ListBox View
		/// </summary>
		/// <returns>A String Describing the Data</returns>
		public override string ToString()
		{
			string s = ReferencedElement.Count.ToString();
			for (int i = 0; i < AliasValues.Length; i++)
			{
				s += ", " + AliasValues[i].Count;
			}

			return s;
		}

		/// <summary>
		/// Returns the first Element Referenced from this Link that implements
		/// the passed <see cref="ElementIdentity"/>.
		/// </summary>
		/// <param name="id">Identity you are looking for</param>
		/// <returns>null or the First mathcing Element</returns>
		public GmdcElement FindElementType(ElementIdentity id)
		{
			foreach (int i in ReferencedElement)
			{
				if (parent.Elements[i].Identity == id)
				{
					return parent.Elements[i];
				}
			}

			return null;
		}

		/// <summary>
		/// Returns the nr (as it can be used in GetValue() Method) of the passed Element in this Link Section
		/// </summary>
		/// <param name="e">Element you are looking for</param>
		/// <returns>
		/// -1 if the Element is not referenced from this Link or the index of that Element in the
		/// ReferenceElement Member
		/// </returns>
		public int GetElementNr(GmdcElement e)
		{
			if (e == null)
			{
				return -1;
			}

			for (int i = 0; i < ReferencedElement.Count; i++)
			{
				if (parent.Elements[ReferencedElement[i]] == e)
				{
					return i;
				}
			}

			return -1;
		}

		/// <summary>
		/// Returns a specific Value
		/// </summary>
		/// <param name="nr">The Number of the referenced Element (index to the ReferencedElement Member)</param>
		/// <param name="index">The index of the value you want to read from thet Element</param>
		/// <returns>The stored Value or null on error</returns>
		/// <remarks>To retrieve the correct number for an Element, see the GetElementNr() Method</remarks>
		public GmdcElementValueBase GetValue(int nr, int index)
		{
			try
			{
				//if (nr>=this.items1.Length) return null;
				int enr = ReferencedElement[nr];

				//if (enr>=this.parent.Elements.Length) return null;
				GmdcElement e = parent.Elements[enr];

				//Higher Number
				if (nr >= AliasValues.Length)
				{
					//if (index>=e.Values.Length) return null;
					return e.Values[index];
				}

				//Do we have aliases?
				if (AliasValues[nr].Count == 0) //no
				{
					//if (index>=e.Values.Length) return null;
					return e.Values[index];
				}
				else //yes
				{
					//if (index>=this.refs.Length) return null;
					index = AliasValues[nr][index];
					//if (index>=e.Values.Length) return null;
					return e.Values[index];
				}
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// Returns a specific Value
		/// </summary>
		/// <param name="nr">The Number of the referenced Element (index to the ReferencedElement Member)</param>
		/// <param name="index">The index of the value you want to read from thet Element</param>
		/// <returns>-1 or an Element Index</returns>
		/// <remarks>To retrieve the correct number for an Element, see the GetElementNr() Method</remarks>
		public int GetRealIndex(int nr, int index)
		{
			try
			{
				int enr = ReferencedElement[nr];

				GmdcElement e = parent.Elements[enr];

				//Higher Number
				if (nr >= AliasValues.Length)
				{
					return index;
				}

				//Do we have aliases?
				return AliasValues[nr].Count == 0 ? index : AliasValues[nr][index];
			}
			catch
			{
				return -1;
			}
		}

		/// <summary>
		/// Returns the value for <see cref="ReferencedSize"/> for the current Settings
		/// </summary>
		/// <returns>The suggested value for <see cref="ReferencedSize"/></returns>
		public int GetReferencedSize()
		{
			int minct = int.MaxValue;
			//add all populated Element Lists
			for (int k = 0; k < ReferencedElement.Count; k++)
			{
				int id = ReferencedElement[k];
				if (parent.Elements[id].Values.Count > 0)
				{
					minct = Math.Min(minct, parent.Elements[id].Values.Count);
				}
			} // for k
			if (minct == int.MaxValue)
			{
				minct = 0;
			}

			int res = minct;

			//If we have AliasLists, the we need that Number as Reference Count!
			minct = int.MaxValue;
			for (int i = 0; i < AliasValues.Length; i++)
			{
				if (AliasValues[i].Count > 0)
				{
					minct = Math.Min(minct, AliasValues[i].Count);
				}
			}

			if (minct != int.MaxValue)
			{
				res = minct;
			}

			return res;
		}

		/// <summary>
		/// Makes sure that the Aliaslists are not used!
		/// </summary>
		public void Flatten()
		{
			GmdcElement vn = new GmdcElement(parent);
			GmdcElement vt = new GmdcElement(parent);

			GmdcElement ovn = FindElementType(ElementIdentity.Normal);
			GmdcElement ovt = FindElementType(ElementIdentity.UVCoordinate);

			//contains a List of all additional Elements assigned to this Link, which
			//are related to the Vertex Element (like BoneWeights)
			List<GmdcElement> ovelements = new List<GmdcElement>();
			List<GmdcElement> velements = new List<GmdcElement>();
			ovelements.Add(FindElementType(ElementIdentity.Vertex));
			velements.Add(new GmdcElement(Parent));

			int nv = GetElementNr(ovelements[0]);
			int nvn = GetElementNr(ovn);
			int nvt = GetElementNr(ovt);

			//add all other Elements
			foreach (int i in ReferencedElement)
			{
				if (
					ovelements.Contains(parent.Elements[i])
					|| parent.Elements[i] == ovn
					|| parent.Elements[i] == ovt
				)
				{
					continue;
				}

				ovelements.Add(parent.Elements[i]);
				velements.Add(new GmdcElement(Parent));
			}

			for (int i = 0; i < ReferencedSize; i++)
			{
				for (int j = 0; j < velements.Count; j++)
				{
					velements[j]
						.Values.Add(ovelements[j].Values[GetRealIndex(nv, i)]);
				}

				if (ovn != null)
				{
					vn.Values.Add(ovn.Values[GetRealIndex(nvn, i)]);
				}

				if (ovt != null)
				{
					vt.Values.Add(ovt.Values[GetRealIndex(nvt, i)]);
				}
			}

			for (int i = 0; i < velements.Count; i++)
			{
				ovelements[i].Values = velements[i].Values;
				ovelements[i].Number = velements[i].Number;
			}
			if (ovn != null)
			{
				ovn.Values = vn.Values;
				ovn.Number = ReferencedSize;
			}
			if (ovt != null)
			{
				ovt.Values = vt.Values;
				ovt.Number = ReferencedSize;
			}

			for (int i = 0; i < AliasValues.Length; i++)
			{
				AliasValues[i].Clear();
			}
		}
	}
}
