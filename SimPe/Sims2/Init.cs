// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Runtime.CompilerServices;

namespace SimPe.Sims2;

public static class Init
{
	public static void Initialize()
	{
		// Register file loaders
		Common.Models.FileLoader.RegisterFileLoader(Sims2.Models.Package.PackageFile.Open);
		Common.Models.FileLoader.FileTypeFilter.Add(new("Sims 2 Package")
		{
			Patterns = ["*.package", "*.sims", "*.cache"]
		});
	}
}
