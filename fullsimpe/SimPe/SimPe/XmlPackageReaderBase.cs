// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe
{
	/// <summary>
	/// Handles Extracted Pakage Files
	/// </summary>
	public abstract class XmlPackageReaderBase
	{
		protected void ClearFileIndex(Packages.GeneratableFile file)
		{
			file.ClearFileIndex();
		}

		protected void AddToFileIndex(
			Packages.GeneratableFile file,
			Packages.PackedFileDescriptor pfd
		)
		{
			file.Add(pfd);
		}
	}
}
