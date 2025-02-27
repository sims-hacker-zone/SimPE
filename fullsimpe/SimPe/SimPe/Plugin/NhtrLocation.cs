using SimPe.Geometry;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for NhtrLocation.
	/// </summary>
	[System.ComponentModel.TypeConverter(
		typeof(System.ComponentModel.ExpandableObjectConverter)
	)]
	public class NhtrLocation
	{
		public NhtrLocation()
		{
			Position = Vector3f.Zero;
		}

		public Vector3f Position
		{
			get; set;
		}

		public float Orientation1
		{
			get; set;
		}

		public float Orientation2
		{
			get; set;
		}

		internal void Unserialize(System.IO.BinaryReader reader)
		{
			Position.Y = reader.ReadSingle();
			Position.X = reader.ReadSingle();
			Position.Z = reader.ReadSingle();

			Orientation1 = reader.ReadSingle();
			Orientation2 = reader.ReadSingle();
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write((float)Position.Y);
			writer.Write((float)Position.X);
			writer.Write((float)Position.Z);

			writer.Write(Orientation1);
			writer.Write(Orientation2);
		}

		public override string ToString()
		{
			return Position.ToString() + " [" + Orientation1.ToString() + ", " + Orientation1.ToString() + "]";
		}
	}
}
