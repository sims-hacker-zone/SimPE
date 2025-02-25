using System;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for TileItem.
	/// </summary>
	public abstract class NhtrItem
	{
		protected byte marker;
		NhtrList parent;

		internal NhtrItem(NhtrList parent)
		{
			this.parent = parent;
			marker = 2;
		}

		public byte Marker
		{
			get { return marker; }
		}

		internal virtual void Unserialize(System.IO.BinaryReader reader)
		{
			marker = reader.ReadByte();
		}

		internal virtual void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(marker);
		}

		public abstract string ToLongString();
	}
}
