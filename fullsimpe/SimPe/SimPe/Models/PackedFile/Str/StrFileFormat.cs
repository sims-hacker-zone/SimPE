// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Str
{
	public enum StrFileFormat : ushort
	{
		[DisplayName("No language support")]
		NoLanguage = 0x0000,
		[DisplayName("Language support, w/o descriptions")]
		NoDescriptions = 0xFFFE,
		[DisplayName("Language support, with descriptions")]
		WithDescriptions = 0xFFFD
	}
}
