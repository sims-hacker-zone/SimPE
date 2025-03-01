// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace SimPe.Windows.Forms
{
	public interface IResourceViewFilter
	{
		bool Active
		{
			get;
		}
		bool IsFiltered(Interfaces.Files.IPackedFileDescriptor pfd);
		event EventHandler ChangedFilter;
	}
}
