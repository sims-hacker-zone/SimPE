// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Common.Extensions;

namespace SimPe.Sims1.Data;

/// <summary>
/// Available EPs and Savegame folders
/// </summary>
public enum GameFolders : uint
{
	[DisplayName("Base Game")] BaseGame = 0x00,
}
