// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Sims2.Data;
using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Str;

public partial class StrItem(Str parent) : ObservableObject
{
	[ObservableProperty] private Str parent = parent;

	[ObservableProperty] private EnumDisplayNameItem<Languages> language;

	[ObservableProperty] private string title;

	[ObservableProperty] private string description;

	public override string ToString()
	{
		return $"{Language}: {Title} - {Description}";
	}

	public static StrItem Unserialize(BinaryReader reader, Str parent)
	{
		StrItem item = new(parent);

		if (parent.Format == StrFileFormat.NoLanguage)
		{
			item.Language = new(Languages.English);
			item.Title = reader.ReadString();
			item.Description = "";
		}
		else if (parent.Format == StrFileFormat.NoDescriptions)
		{
			item.Language = new((Languages)(reader.ReadByte() + 1));
			item.Title = reader.ReadUtf8CString();
		}
		else if (parent.Format == StrFileFormat.WithDescriptions)
		{
			item.Language = new((Languages)reader.ReadByte());
			item.Title = reader.ReadUtf8CString();
			item.Description = reader.ReadUtf8CString();
		}

		return item;
	}
}
