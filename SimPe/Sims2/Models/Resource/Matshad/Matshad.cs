// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;
using System.Text;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Views.Resource.Matshad;

namespace SimPe.Sims2.Models.Resource.Matshad;

public partial class Matshad(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	[ObservableProperty] private string content;

	public UserControl Panel { get; private set; }

	public string FriendlyName => null;

	public static IWrapper Unserialize(BinaryReader reader, Resource file)
	{
		Matshad matshad = new(file)
		{
			Content = Encoding.UTF8.GetString(
				reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position)))
		};
		matshad.Panel = new MatshadPanel
		{
			DataContext = matshad
		};
		return matshad;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(Encoding.UTF8.GetBytes(Content));
	}
}
