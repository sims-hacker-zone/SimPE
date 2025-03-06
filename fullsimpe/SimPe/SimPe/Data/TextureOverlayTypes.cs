// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Data
{
	/// <summary>
	/// Determins the concrete Type of an Overlay Item (texture or mesh overlay)
	/// </summary>
	public enum TextureOverlayTypes : uint
	{
		Beard = 0x00,
		EyeBrow = 0x01,
		Lipstick = 0x02,
		Eye = 0x03,
		Mask = 0x04,
		Glasses = 0x05,
		Blush = 0x06,
		EyeShadow = 0x07,
	}
}
