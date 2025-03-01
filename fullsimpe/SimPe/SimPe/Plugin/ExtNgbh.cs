// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This links to the eextended GUI for the Neighbourhood Wrapper
	/// </summary>
	public class ExtNgbh : Ngbh
	{
		#region Value Descriptors, used for Badges and Hiden Skills
		static NgbhValueDescriptor[] vd;
		public static NgbhValueDescriptor[] ValueDescriptors
		{
			get
			{
				if (vd == null)
				{
					CreateValueDescriptors();
				}

				return vd;
			}
		}

		protected static void CreateValueDescriptors()
		{
			ArrayList list = new ArrayList();
			foreach (
				Cache.MemoryCacheItem mci in
					PackedFiles
					.Wrapper
					.ObjectComboBox
					.ObjectCache
					.List
			)
			{
				if (mci.IsBadge)
				{
					list.Add(
						new NgbhValueDescriptor(
							mci.Name,
							true,
							NgbhValueDescriptorType.Badge,
							mci.Guid,
							0,
							0,
							1000
						)
					);
				}
			}

			list.AddRange(
				new NgbhValueDescriptor[]
				{
					new NgbhValueDescriptor(
						"Dance Skill",
						true,
						NgbhValueDescriptorType.Skill,
						0xda265f4,
						0,
						0,
						1000
					),
					new NgbhValueDescriptor(
						"Dance Experience",
						true,
						NgbhValueDescriptorType.Skill,
						0x6fe7e453,
						0,
						0,
						1000
					),
					new NgbhValueDescriptor(
						"Meditation Skill",
						false,
						NgbhValueDescriptorType.Skill,
						0x4d8b0cc3,
						2,
						0,
						1000
					),
					new NgbhValueDescriptor(
						"Study Skill",
						false,
						NgbhValueDescriptorType.Skill,
						0x4d8b0cc3,
						3,
						0,
						1000
					),
					//new NgbhValueDescriptor("Swimming Skill", false, NgbhValueDescriptorType.Skill, 0x4d8b0cc3, 4, 0, 1000),
					new NgbhValueDescriptor(
						"Learned to walk",
						false,
						NgbhValueDescriptorType.ToddlerSkill,
						0x4ddf0e12,
						1,
						0,
						1000,
						4
					),
					new NgbhValueDescriptor(
						"Learned to talk",
						false,
						NgbhValueDescriptorType.ToddlerSkill,
						0x4ddf0e12,
						2,
						0,
						1000,
						4
					),
					new NgbhValueDescriptor(
						"Pottytrained",
						false,
						NgbhValueDescriptorType.ToddlerSkill,
						0x4ddf0e12,
						3,
						0,
						1000,
						4
					),
				}
			);

			if (PathProvider.Global.EPInstalled >= 13)
			{
				list.AddRange(
					new NgbhValueDescriptor[]
					{
						new NgbhValueDescriptor(
							"Nursery Rhyme",
							false,
							NgbhValueDescriptorType.ToddlerSkill,
							0x4ddf0e12,
							7,
							0,
							600,
							7
						),
					}
				);
			}

			if (PathProvider.Global.GetExpansion(Expansions.IslandStories).Exists)
			{
				list.AddRange(
					new NgbhValueDescriptor[]
					{
						new NgbhValueDescriptor(
							"Limbo Skill",
							false,
							NgbhValueDescriptorType.Skill,
							0x33fbe0b7,
							0,
							0,
							200
						),
					}
				);
			}

			vd = new NgbhValueDescriptor[list.Count];
			list.CopyTo(vd);
		}
		#endregion

		public ExtNgbh()
			: base(FileTableBase.ProviderRegistry) { }

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new ExtNgbhUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Extended Neighborhood/Memory Wrapper",
				"Quaxi",
				"This File contains the Memories and Inventories of all Sims and Lots that Live in this Neighborhood.",
				2,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.ngbh.png")
				)
			);
		}
		#endregion
	}
}
