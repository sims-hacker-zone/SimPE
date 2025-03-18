using System;
using System.Formats.Asn1;
using System.IO;
using System.Text;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Fwav;

namespace SimPe.Models.PackedFile.Fwav
{
	public partial class Fwav(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		[ObservableProperty]
		private string fileName;

		[ObservableProperty]
		private string content;

		public UserControl Panel
		{
			get;
			private set;
		}

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			Fwav fwav = new(file)
			{
				FileName = Encoding.ASCII.GetString(reader.ReadBytes(64)),
				Content = reader.ReadUTF8CString()
			};

			fwav.Panel = new FwavPanel(fwav);

			return fwav;
		}

		public void Serialize(BinaryWriter writer)
		{
			byte[] buffer = Encoding.ASCII.GetBytes(FileName);
			Array.Resize(ref buffer, 64);
			writer.Write(buffer);
			writer.Write(Encoding.UTF8.GetBytes(Content));
			writer.Write((byte)0);
		}
	}
}
