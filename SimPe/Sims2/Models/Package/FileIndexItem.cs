// SPDX-FileCopyrightText:© SimPE contributors
// SPDX-License-Identifier:GPL-2.0-or-later

namespace SimPe.Sims2.Models.Package;

public record FileIndexItem
{
	public uint Type { get; init; }
	public uint Group { get; init; }
	public uint Instance { get; init; }
	public uint InstanceHigh { get; init; }
	public uint Offset { get; init; }
	public uint Size { get; init; }
}
