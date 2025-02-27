namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for TileItem.
	/// </summary>
	public class NhtrBridgeItem : NhtrRoadItem
	{
		internal NhtrBridgeItem(NhtrList parent)
			: base(parent)
		{
			Marker3 = 3;
			Data2 = new byte[40];
		}

		public byte[] Data2
		{
			get; private set;
		}

		public byte Marker3
		{
			get; private set;
		}

		protected override void DoUnserialize(System.IO.BinaryReader reader)
		{
			base.DoUnserialize(reader);

			Marker3 = reader.ReadByte();
			Data2 = reader.ReadBytes(Data2.Length);
		}

		protected override void DoSerialize(System.IO.BinaryWriter writer)
		{
			base.DoSerialize(writer);

			writer.Write(Marker3);
			writer.Write(Data2);
		}

		public override string ToLongString()
		{
			string s = base.ToLongString() + Helper.lbr;
			s += "Marker 3: " + Helper.HexString(Marker3) + Helper.lbr;
			s += Helper.BytesToHexList(Data2, 4);
			return s;
		}

		public override string ToString()
		{
			string s = base.ToString() + "   ";
			s += Helper.HexString(Marker3) + "   ";
			s += Helper.BytesToHexList(Data2);

			if (s.Length > 0xff)
			{
				s = s.Substring(0, 0xff) + "...";
			}

			return s;
		}
	}
}
