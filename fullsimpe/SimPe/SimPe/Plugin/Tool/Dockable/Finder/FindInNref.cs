// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Nref;

namespace SimPe.Plugin.Tool.Dockable.Finder
{
	public partial class FindInNref : FindInStr
	{
		public FindInNref(Interfaces.IFinderResultGui rgui)
			: base(rgui)
		{
			InitializeComponent();
		}

		public FindInNref()
			: this(null) { }

		public override bool ProcessParalell => true;

		public override void SearchPackage(
			Interfaces.Files.IPackageFile pkg,
			Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			if (pfd.Type != FileTypes.NREF)
			{
				return;
			}


			bool found = false;
			string n = new Nref().ProcessFile(pfd, pkg).FileName.Trim().ToLower();
			switch (compareType)
			{
				case CompareType.Equal:
					found = n == name;
					break;
				case CompareType.Start:
					found = n.StartsWith(name);
					break;
				case CompareType.End:
					found = n.EndsWith(name);
					break;
				case CompareType.Contain:
					found = n.IndexOf(name) > -1;
					break;
				case CompareType.RegExp when reg != null:
					found = reg.IsMatch(n);
					break;
			}

			//we have a match, so add the result item
			if (found)
			{
				ResultGui.AddResult(pkg, pfd);
			}
		}
	}
}
