using System;
using System.IO;
using System.Reflection;
using System.Text;

using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

using CommunityToolkit.Mvvm.ComponentModel;

using Pfim;

using SimPe.Media;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Picture;

namespace SimPe.Models.PackedFile.Picture
{
	public partial class Picture(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		[ObservableProperty]
		private string fileName;

		[ObservableProperty]
		private Bitmap image;

		public UserControl Panel
		{
			get; private set;
		}

		public string FriendlyName => FileName;

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			Picture picture = new(file);
			byte[] buffer;
			if (file.Type == Data.FileTypes.BMP)
			{
				picture.FileName = Encoding.ASCII.GetString(reader.ReadBytes(64));
				buffer = reader.ReadBytes((int)reader.BaseStream.Length - 64);
				picture.Image = new(new MemoryStream(buffer));
			}
			else
			{
				buffer = reader.ReadBytes((int)reader.BaseStream.Length);
				picture.Image = Tga.ReadTGA(new MemoryStream(buffer)) ?? new(new MemoryStream(buffer));
			}
			picture.Panel = new PicturePanel() { DataContext = picture };
			return picture;
		}

		public void Serialize(BinaryWriter writer)
		{
			throw new NotImplementedException();
		}
	}
}
