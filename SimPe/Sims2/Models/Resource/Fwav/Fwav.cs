// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.IO;
using System.Text;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Extensions;
using SimPe.Sims2.Views.Resource.Fwav;

namespace SimPe.Sims2.Models.Resource.Fwav;

public partial class Fwav(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	[ObservableProperty] private string resourceName;

	[ObservableProperty] private string content;

	public UserControl Panel { get; private set; }

	public string FriendlyName => ResourceName;

	public static IWrapper Unserialize(BinaryReader reader, Resource file)
	{
		Fwav fwav = new(file)
		{
			ResourceName = Encoding.ASCII.GetString(reader.ReadBytes(64)),
			Content = reader.ReadUtf8CString()
		};

		fwav.Panel = new FwavPanel(fwav);

		return fwav;
	}

	public void Serialize(BinaryWriter writer)
	{
		byte[] buffer = Encoding.ASCII.GetBytes(ResourceName);
		Array.Resize(ref buffer, 64);
		writer.Write(buffer);
		writer.Write(Encoding.UTF8.GetBytes(Content));
		writer.Write((byte)0);
	}
}
