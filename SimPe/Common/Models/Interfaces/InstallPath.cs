// SPDX-FileCopyrightText:© SimPE contributors
// SPDX-License-Identifier:GPL-2.0-or-later

using SimPe.Common.Extensions;

namespace SimPe.Common.Models.Interfaces;

public abstract class InstallPath
{
	public EnumDisplayNameItem Item { get; set; }

	public string? Path { get; set; }
}
