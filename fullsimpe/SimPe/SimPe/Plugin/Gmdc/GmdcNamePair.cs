// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// Stores two String Items
	/// </summary>
	public class GmdcNamePair
	{
		/// <summary>
		/// The Name of the Belnding Group
		/// </summary>
		public string BlendGroupName
		{
			get; set;
		}

		/// <summary>
		/// The Name of the Element that should be assigned to that Group
		/// </summary>
		public string AssignedElementName
		{
			get; set;
		}

		internal GmdcNamePair()
		{
			BlendGroupName = "";
			AssignedElementName = "";
		}

		/// <summary>
		/// Creates a new Instance
		/// </summary>
		/// <param name="blend">Name of the Blendgroup</param>
		/// <param name="element">Name of the Element that should be assigned to that Blend Group</param>
		public GmdcNamePair(string blend, string element)
		{
			BlendGroupName = blend;
			AssignedElementName = element;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal virtual void Unserialize(System.IO.BinaryReader reader)
		{
			BlendGroupName = reader.ReadString();
			AssignedElementName = reader.ReadString();
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
			writer.Write(BlendGroupName);
			writer.Write(AssignedElementName);
		}

		/// <summary>
		/// This output is used in the ListBox View
		/// </summary>
		/// <returns>A String Describing the Data</returns>
		public override string ToString()
		{
			return BlendGroupName + ", " + AssignedElementName;
		}
	}
}
