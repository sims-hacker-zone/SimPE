using System.Collections.ObjectModel;
using System.IO;
using System.Text;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Data;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Ttab;

namespace SimPe.Models.PackedFile.Ttab
{
	public partial class Ttab(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		[ObservableProperty]
		private string fileName;

		public static uint Header_0 => 0xFFFF_FFFF;

		[ObservableProperty]
		private uint version;

		[ObservableProperty]
		private uint unknown_00;

		[ObservableProperty]
		private ObservableCollection<TtabItem> items = [];

		public UserControl Panel
		{
			get;
			private set;
		}

		public static Ttab Unserialize(BinaryReader reader, PackedFile file)
		{
			Ttab ttab = new(file)
			{
				FileName = Encoding.ASCII.GetString(reader.ReadBytes(64))
			};
			if (Header_0 != reader.ReadUInt32())
			{
				throw new InvalidDataException($"Invalid TTAB header!");
			}
			ttab.Version = reader.ReadUInt32();
			ttab.Unknown_00 = reader.ReadUInt32();

			ushort itemCount = reader.ReadUInt16();
			for (int i = 0; i < itemCount; i++)
			{
				ttab.Items.Add(TtabItem.Unserialize(reader, ttab));
			}

			ttab.Panel = new TtabPanel(ttab);

			return ttab;
		}

		public void Serialize(BinaryWriter writer)
		{
			throw new System.NotImplementedException();
		}
	}
}
