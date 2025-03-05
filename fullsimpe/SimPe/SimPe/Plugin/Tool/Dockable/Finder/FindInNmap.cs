// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.PackedFiles.Nmap;

namespace SimPe.Plugin.Tool.Dockable.Finder
{
	public partial class FindInNmap : FindInStr
	{
		public FindInNmap(Interfaces.IFinderResultGui rgui)
			: base(rgui)
		{
			InitializeComponent();
		}

		public FindInNmap()
			: this(null) { }

		public override bool ProcessParalell => false;

		public override void SearchPackage(
			Interfaces.Files.IPackageFile pkg,
			Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			if (pfd.Type != Data.MetaData.NAME_MAP)
			{
				return;
			}

			Nmap nmap = new Nmap(FileTableBase.ProviderRegistry);
			nmap.ProcessData(pfd, pkg);

			//check all stored nMap entries for a match
			foreach (Interfaces.Files.IPackedFileDescriptor mypfd in nmap.Items)
			{
				bool found = false;
				string n = mypfd.Filename.Trim().ToLower();
				if (compareType == CompareType.Equal)
				{
					found = n == name;
				}
				else if (compareType == CompareType.Start)
				{
					found = n.StartsWith(name);
				}
				else if (compareType == CompareType.End)
				{
					found = n.EndsWith(name);
				}
				else if (compareType == CompareType.Contain)
				{
					found = n.IndexOf(name) > -1;
				}
				else if (compareType == CompareType.RegExp && reg != null)
				{
					found = reg.IsMatch(n);
				}

				//we have a match, so add the result item
				if (found)
				{

					foreach (
						Interfaces.Scenegraph.IScenegraphFileIndexItem rfii in FileTableBase.FileIndex.FindFileDiscardingHighInstance(
							pfd.Instance,
							mypfd.Group,
							mypfd.Instance,
							null
						)
					)
					{
						ResultGui.AddResult(rfii.Package, rfii.FileDescriptor);
					}
				}
			}
		}
	}
}
