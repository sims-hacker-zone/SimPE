// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ToolResult.
	/// </summary>
	public class ToolResult : Interfaces.Plugin.IToolResult
	{
		public ToolResult(bool pfd, bool package)
		{
			ChangedFile = pfd;
			ChangedPackage = package;
		}

		#region IToolResult Member
		public bool ChangedPackage
		{
			get;
		}

		public bool ChangedFile
		{
			get;
		}

		public bool ChangedAny => ChangedPackage || ChangedFile;
		#endregion
	}
}
