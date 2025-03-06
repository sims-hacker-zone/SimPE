// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Data;
using SimPe.Extensions;

namespace SimPe.Plugin.Tool.Dockable.Finder
{
	public partial class FindInSG : FindInStr
	{
		public FindInSG(Interfaces.IFinderResultGui rgui)
			: base(rgui)
		{
			InitializeComponent();

			cbtypes.Items.Add("--- All ---");
			foreach (FileTypes t in MetaData.RcolList)
			{
				cbtypes.Items.Add(t.ToFileTypeInformation());
			}
			cbtypes.SelectedIndex = 0;
		}

		public FindInSG()
			: this(null) { }

		public override bool ProcessParalell => false;

		FileTypes type;

		protected override bool OnPrepareStart()
		{
			type = 0;
			if (cbtypes.SelectedIndex > 0)
			{
				type = (FileTypes)cbtypes.SelectedItem;
			}
			return base.OnPrepareStart();
		}

		public override void SearchPackage(
			Interfaces.Files.IPackageFile pkg,
			Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			bool found = false;

			if (type == 0)
			{
				foreach (FileTypes tt in MetaData.RcolList)
				{
					if (tt == pfd.Type)
					{
						found = true;
						break;
					}
				}
			}
			else
			{
				found = type == pfd.Type;
			}

			if (!found)
			{
				return;
			}

			GenericRcol rcol = new GenericRcol(null, true);
			rcol.ProcessData(pfd, pkg);

			found = false;
			string n = rcol.FileName.Trim().ToLower();
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
