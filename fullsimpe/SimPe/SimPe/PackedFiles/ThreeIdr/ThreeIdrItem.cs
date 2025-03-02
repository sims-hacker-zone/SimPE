// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.PackedFiles.ThreeIdr
{

	/// <summary>
	/// A Item in a 3IDR File
	/// </summary>
	public class ThreeIdrItem : Packages.PackedFileDescriptor
	{
		private readonly ThreeIdr parent;

		public ThreeIdrItem(ThreeIdr parent)
		{
			this.parent = parent;
		}

		public ThreeIdrItem(Interfaces.Files.IPackedFileDescriptor pfd, ThreeIdr parent)
		{
			this.parent = parent;
			Group = pfd.Group;
			Type = pfd.Type;
			SubType = pfd.SubType;
			Instance = pfd.Instance;
		}

		private SkinChain skin;
		public SkinChain Skin
		{
			get
			{
				if (
					skin == null
					&& (
						Type == Data.MetaData.GZPS
						|| Type == Data.MetaData.AGED
						|| Type == Data.MetaData.XSTN
					)
					&& parent != null
				)
				{
					try
					{
						FileTableBase.FileIndex.Load();
						Interfaces.Scenegraph.IScenegraphFileIndexItem[] items =
							FileTableBase.FileIndex.FindFile(this, parent.Package);
						if (items.Length > 0)
						{
							Wrapper.Cpf cpff =
								new Wrapper.Cpf();
							cpff.ProcessData(items[0]);

							skin = new SkinChain(cpff);
						}
					}
					catch { }
				}
				return skin;
			}
			set => skin = value;
		}

		public override string ToString()
		{
			string name = base.ToString();
			if (Skin != null)
			{
				if (Skin.PartNames != "")
				{
					name += "; Part=" + Skin.PartNames;
				}

				if (Skin.CategoryNames != "")
				{
					name += "; Category=" + Skin.CategoryNames;
				}

				if (Skin.AgeNames != "")
				{
					name += "; Age=" + Skin.AgeNames;
				}

				if (Skin.GenderNames != "")
				{
					name += "; Gender=" + Skin.GenderNames;
				}

				if (Skin.Name != "")
				{
					name += "; Name=" + Skin.Name;
				}

				if (Skin.Bodyshape != "Unknown" && !Skin.Bodyshape.Contains("Maxis"))
				{
					name += "; Body=" + Skin.Bodyshape;
				}
				// name = "Category="+Skin.CategoryNames+"; Age="+Skin.AgeNames+"; Name="+Skin.Name;
				// name += " ("+base.ToString()+")";
			}
			return name;
		}
	}
}
