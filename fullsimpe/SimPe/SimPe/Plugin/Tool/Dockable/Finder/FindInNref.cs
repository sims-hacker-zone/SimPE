// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Data;
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

			Nref nref = new Nref();
			nref.ProcessData(pfd, pkg);

			bool found = false;
			string n = nref.FileName.Trim().ToLower();
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
				ResultGui.AddResult(pkg, pfd);
			}
		}
	}
}
