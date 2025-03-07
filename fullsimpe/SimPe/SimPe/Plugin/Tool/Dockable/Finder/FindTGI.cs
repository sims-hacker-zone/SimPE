// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace SimPe.Plugin.Tool.Dockable.Finder
{
	public partial class FindTGI : Interfaces.AFinderTool
	{
		public FindTGI(Interfaces.IFinderResultGui rgui)
			: base(rgui)
		{
			InitializeComponent();
		}

		public FindTGI()
			: this(null) { }

		private void tbName_TextChanged(object sender, EventArgs e)
		{
			tbInstHi.Text =
				"0x"
				+ Helper.HexString(
					Hashes.SubTypeHash(
						Hashes.StripHashFromName(tbName.Text)
					)
				);
			tbInstLo.Text =
				"0x"
				+ Helper.HexString(
					Hashes.InstanceHash(
						Hashes.StripHashFromName(tbName.Text)
					)
				);
		}

		struct Descriptor
		{
			public bool use;
			public uint val;
		};

		Descriptor t,
			g,
			hi,
			li;

		protected override bool OnPrepareStart()
		{
			t.val = Helper.StringToUInt32(tbType.Text, 0, 16);
			t.use = tbType.Text.Trim() != "";

			g.val = Helper.StringToUInt32(tbGroup.Text, 0, 16);
			g.use = tbGroup.Text.Trim() != "";

			hi.val = Helper.StringToUInt32(tbInstHi.Text, 0, 16);
			hi.use = tbInstHi.Text.Trim() != "";

			li.val = Helper.StringToUInt32(tbInstLo.Text, 0, 16);
			li.use = tbInstLo.Text.Trim() != "";

			return t.use || g.use || hi.use || li.use;
		}

		public override void SearchPackage(
			Interfaces.Files.IPackageFile pkg,
			Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			if (
				(t.val == (uint)pfd.Type || !t.use)
				&& (g.val == pfd.Group || !g.use)
				&& (hi.val == pfd.SubType || !hi.use)
				&& (li.val == pfd.Instance || !li.use)
			)
			{
				ResultGui.AddResult(pkg, pfd);
			}
		}
	}
}
