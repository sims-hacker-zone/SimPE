using System.IO;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Apartment Life specific Data
	/// </summary>
	public class SdscApartment : Serializer
	{
		internal SdscApartment(SDesc dsc)
		{
			parent = dsc;
		}

		SDesc parent;

		public short Reputation
		{
			get; set;
		}
		public short ProbabilityToAppear
		{
			get; set;
		}
		public short TitlePostName
		{
			get; set;
		}

		internal void Unserialize(BinaryReader reader)
		{
			reader.BaseStream.Seek(0x1D4, SeekOrigin.Begin);
			Reputation = reader.ReadInt16();
			ProbabilityToAppear = reader.ReadInt16();
			TitlePostName = reader.ReadInt16();
		}

		internal void Serialize(BinaryWriter writer)
		{
			writer.BaseStream.Seek(0x1D4, SeekOrigin.Begin);
			writer.Write(Reputation);
			writer.Write(ProbabilityToAppear);
			writer.Write(TitlePostName);
		}
	}
}
