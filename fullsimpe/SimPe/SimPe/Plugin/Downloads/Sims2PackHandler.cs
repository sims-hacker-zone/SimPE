// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

namespace SimPe.Plugin.Downloads
{
	/// <summary>
	/// Summary description for TypedPackageHandler.
	/// </summary>
	public class Sims2PackHandler : ArchiveHandler
	{
		public Sims2PackHandler(string filename)
			: base(filename) { }

		protected override List<string> ExtractArchive()
		{
			List<string> ret = new List<string>();
			Packages.S2CPDescriptor[] content =
				Packages.Sims2CommunityPack.Open(ArchiveName);

			foreach (Packages.S2CPDescriptor desc in content)
			{
				string name = System.IO.Path.Combine(
					Helper.SimPeTeleportPath,
					desc.Name
				);
				string rname = name;
				int ct = 0;
				while (System.IO.File.Exists(rname))
				{
					rname = System.IO.Path.Combine(
						Helper.SimPeTeleportPath,
						ct.ToString() + "_" + desc.Name
					);
					ct++;
				}
				desc.Package.Save(rname);
				if (System.IO.File.Exists(rname))
				{
					ret.Add(rname);
				}
			}
			return ret;
		}
	}
}
