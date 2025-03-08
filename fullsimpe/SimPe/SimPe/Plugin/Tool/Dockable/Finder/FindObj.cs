// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin.Tool.Dockable.Finder
{
	public partial class FindObj : FindInStr
	{
		public FindObj(Interfaces.IFinderResultGui rgui)
			: base(rgui)
		{
			InitializeComponent();
			name = "";
			guid = 0;
		}

		public FindObj()
			: this(null) { }

		uint guid;

		protected override bool OnPrepareStart()
		{
			base.OnPrepareStart();

			guid = Helper.StringToUInt32(tbGUID.Text, 0, 16);

			return name != "" || guid > 0;
		}

		public override void SearchPackage(
			Interfaces.Files.IPackageFile pkg,
			Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			if (pfd.Type != Data.FileTypes.OBJD)
			{
				return;
			}

			DoSearchPackage(pkg, pfd);
		}

		public void DoSearchPackage(
			Interfaces.Files.IPackageFile pkg,
			Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			PackedFiles.Wrapper.ExtObjd obj =
				new PackedFiles.Wrapper.ExtObjd().ProcessFile(pfd, pkg);

			bool found = false;

			if (name != "")
			{
				string n = obj.FileName.Trim().ToLower();
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
			}

			if (guid > 0 && (found || name == ""))
			{
				found = obj.Guid == guid;
			}

			//we have a match, so add the result item
			if (found)
			{
				ResultGui.AddResult(pkg, pfd);
			}
		}
	}
}
