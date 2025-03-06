// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Data;
using SimPe.Extensions;

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
		FileTypes Type
		{
			get;
		}
		FileTypeInformation TypeInfo
		{
			get;
		}
	}
}
