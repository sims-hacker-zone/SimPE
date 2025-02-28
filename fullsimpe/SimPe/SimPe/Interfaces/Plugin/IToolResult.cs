// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Plugin
{
	/// <summary>
	/// Returned by  Tool when executed
	/// </summary>
	public interface IToolResult
	{
		bool ChangedPackage
		{
			get;
		}

		bool ChangedFile
		{
			get;
		}

		bool ChangedAny
		{
			get;
		}
	}
}
