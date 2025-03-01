// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Bhav : PackedFiles.Wrapper.Bhav
	{
		public Bhav(Interfaces.Providers.IOpcodeProvider prv)
			: base() { }

		public Bhav()
			: base() { }
	}
}
