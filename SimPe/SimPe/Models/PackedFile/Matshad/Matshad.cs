// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;
using System.Text;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Matshad;

namespace SimPe.Models.PackedFile.Matshad
{
	public partial class Matshad(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		[ObservableProperty]
		private string content;

		public UserControl Panel
		{
			get; private set;
		}

		public string FriendlyName => null;

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			Matshad matshad = new(file)
			{
				Content = Encoding.UTF8.GetString(reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position)))
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
}
