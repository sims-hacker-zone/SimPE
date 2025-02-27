/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for WantItemContainer.
	/// </summary>
	public class WantItemContainer
	{
		uint guid;

		public WantItem[] Items
		{
			get; set;
		}

		/// <summary>
		/// Returns Informations about the Selected want
		/// </summary>
		public WantInformation Information => WantInformation.LoadWant(guid);

		public Interfaces.IProviderRegistry Provider
		{
			get;
		}

		public WantItemContainer(Interfaces.IProviderRegistry provider)
		{
			Items = new WantItem[0];
			this.Provider = provider;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			guid = reader.ReadUInt32();
			Items = new WantItem[reader.ReadUInt32()];

			for (int i = 0; i < Items.Length; i++)
			{
				Items[i] = new WantItem(Provider);
				Items[i].Unserialize(reader);
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
			writer.Write(guid);
			writer.Write((uint)Items.Length);

			for (int i = 0; i < Items.Length; i++)
			{
				Items[i].Serialize(writer);
			}
		}

		public override string ToString()
		{
			return Information.Name + " (count=" + Items.Length.ToString() + ")";
		}
	}
}
