// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Files
{
	public interface IPackedFileDescriptorSimple
	{
		uint Group
		{
			get;
		}
		uint Instance
		{
			get;
		}
		uint SubType
		{
			get;
		}
		uint Type
		{
			get;
		}
		Data.TypeAlias TypeName
		{
			get;
		}
	}
}
