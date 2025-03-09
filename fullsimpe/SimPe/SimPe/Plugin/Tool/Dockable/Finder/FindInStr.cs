// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Str;

namespace SimPe.Plugin.Tool.Dockable.Finder
{
	public partial class FindInStr : Interfaces.AFinderTool
	{
		public enum CompareType
		{
			Unknown = -1,
			Equal = 0,
			Start = 1,
			End = 2,
			Contain = 3,
			RegExp = 4,
		}

		public FindInStr(Interfaces.IFinderResultGui rgui)
			: base(rgui)
		{
			InitializeComponent();

			cbType.SelectedIndex = 3;
			reg = null;
			name = "";
			compareType = CompareType.Unknown;
		}

		public FindInStr()
			: this(null) { }

		protected System.Text.RegularExpressions.Regex reg;
		protected string name;
		protected CompareType compareType;

		protected override bool OnPrepareStart()
		{
			compareType = (CompareType)cbType.SelectedIndex;
			name = tbMatch.Text.Trim().ToLower();
			reg = null;

			if (compareType == CompareType.Unknown || name == "")
			{
				return false;
			}

			try
			{
				reg = new System.Text.RegularExpressions.Regex(
					tbMatch.Text,
					System.Text.RegularExpressions.RegexOptions.IgnoreCase
				);
			}
			catch (Exception ex)
			{
				if (cbType.SelectedIndex == 4)
				{
					Helper.ExceptionMessage(ex);
				}
			}

			return true;
		}

		public override void SearchPackage(
			Interfaces.Files.IPackageFile pkg,
			Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			if (
				pfd.Type != Data.FileTypes.STR
				&& pfd.Type != Data.FileTypes.CTSS
			)
			{
				return;
			}


			//check all stored nMap entries for a match
			foreach (StrToken item in new PackedFiles.Str.Str().ProcessFile(pfd, pkg).Items)
			{
				bool found = false;
				string n = item.Title.Trim().ToLower();
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
					break;
				}
			}
		}
	}
}
