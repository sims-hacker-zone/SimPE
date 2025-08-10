// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Sims2.Data;

namespace SimPe.Sims2.Extensions;

public partial class FileTypeInformation : ObservableObject
{
	[ObservableProperty] private FileTypes type;
	[ObservableProperty] private string shortName;
	[ObservableProperty] private string longName;
	[ObservableProperty] private string extension;
	[ObservableProperty] private bool containsFileName;

	public static bool operator ==(FileTypeInformation a, FileTypeInformation b)
	{
		return a.Type == b.Type;
	}

	public static bool operator !=(FileTypeInformation a, FileTypeInformation b)
	{
		return a.Type != b.Type;
	}

	public override bool Equals(object? obj)
	{
		return obj is FileTypeInformation fti && Type == fti.Type;
	}

	public override string ToString()
	{
		return LongName;
	}

	public override int GetHashCode()
	{
		return Type.GetHashCode();
	}
}
