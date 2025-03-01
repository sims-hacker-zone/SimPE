// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Interfaces
{
	public interface IFinderResultGui
	{
		void AddResult(
			Files.IPackageFile pkg,
			Files.IPackedFileDescriptor pfd
		);
		void AddResult(
			string group,
			Files.IPackageFile pkg,
			Files.IPackedFileDescriptor pfd
		);

		void StartSearch(AFinderTool sender);
		void StopSearch();

		bool ForcedStop
		{
			get;
		}
		bool Searching
		{
			get;
		}
	}
}
