// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Runtime.CompilerServices;

namespace SimPe.Sims1;

public static class Init
{
	public static void Initialize()
	{
		// Register file loaders
		Common.Models.FileLoader.RegisterFileLoader(Models.IFFFile.IFFFile.Open);
		Common.Models.FileLoader.FileTypeFilter.Add(new("Sims 1 IFF")
		{
			Patterns = ["*.iff"]
		});
	}
}
