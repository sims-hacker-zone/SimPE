// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.IO;
using System.Linq;
using System.Text;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Media;
using SimPe.Sims2.Views.Resource.Picture;

namespace SimPe.Sims2.Models.Resource.Picture;

public partial class Picture(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	[ObservableProperty] private string resourceName;

	[ObservableProperty] private Bitmap image;

	public UserControl Panel { get; private set; }

	public string FriendlyName => ResourceName;

	public static IWrapper Unserialize(BinaryReader reader, Resource file)
	{
		Picture picture = new(file);
		byte[] buffer;
		if (file.Type == Data.FileTypes.BMP)
		{
			picture.ResourceName = Encoding.ASCII.GetString(reader.ReadBytes(64));
			buffer = reader.ReadBytes((int)reader.BaseStream.Length - 64);
			picture.Image = new(new MemoryStream(buffer));
		}
		else
		{
			buffer = reader.ReadBytes((int)reader.BaseStream.Length);
			picture.Image = buffer[^18..].AsSpan().SequenceEqual("TRUEVISION-XFILE.\x00"u8)
				? Tga.ReadTGA(new MemoryStream(buffer))
				: JpegAlfa.LoadJpegAlfa(buffer);
		}

		picture.Panel = new PicturePanel() { DataContext = picture };
		return picture;
	}

	public void Serialize(BinaryWriter writer)
	{
		throw new NotImplementedException();
	}
}
