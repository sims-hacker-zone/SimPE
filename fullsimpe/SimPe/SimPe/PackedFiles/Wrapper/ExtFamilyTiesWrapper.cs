// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Zusammenfassung für ExtFamilyTiesWrapper.
	/// </summary>
	public class ExtFamilyTies : FamilyTies
	{
		public ExtFamilyTies()
			: base(FileTableBase.ProviderRegistry.SimNameProvider)
		{
			//
			// TODO: Fügen Sie hier die Konstruktorlogik hinzu
			//
		}

		#region IWrapper Member
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Extended Family Ties Wrapper",
				"Quaxi",
				"Contains all Familyties that are stored in a Neighborhood.",
				2,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.familyties.png")
				)
			);
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.ExtFamilyTies();
		}
		#endregion

		/// <summary>
		/// returns a List of Parent Sims
		/// </summary>
		/// <param name="sdsc"></param>
		/// <returns></returns>
		public SDesc[] ParentSims(SDesc sdsc)
		{
			ArrayList list = new ArrayList();
			Supporting.FamilyTieSim fts = FindTies(sdsc);
			if (fts != null)
			{
				foreach (
					Supporting.FamilyTieItem fti in fts.Ties
				)
				{
					if (fti.SimDescription == null)
					{
						continue;
					}

					if (
						fti.Type == Data.MetaData.FamilyTieTypes.MyMotherIs
						|| fti.Type == Data.MetaData.FamilyTieTypes.MyFatherIs
					)
					{
						list.Add(fti.SimDescription);
					}
				}
			}

			SDesc[] ret = new SDesc[list.Count];
			list.CopyTo(ret);
			return ret;
		}

		/// <summary>
		/// returns a List of Parent Sims
		/// </summary>
		/// <param name="sdsc"></param>
		/// <returns></returns>
		public SDesc[] SiblingSims(SDesc sdsc)
		{
			ArrayList list = new ArrayList();
			Supporting.FamilyTieSim fts = FindTies(sdsc);

			if (fts != null)
			{
				foreach (
					Supporting.FamilyTieItem fti in fts.Ties
				)
				{
					if (fti.SimDescription == null)
					{
						continue;
					}

					if (
						fti.Type == Data.MetaData.FamilyTieTypes.ImMarriedTo
						|| fti.Type == Data.MetaData.FamilyTieTypes.MySiblingIs
					)
					{
						list.Add(fti.SimDescription);
					}
				}
			}

			SDesc[] ret = new SDesc[list.Count];
			list.CopyTo(ret);
			return ret;
		}

		/// <summary>
		/// returns a List of Parent Sims
		/// </summary>
		/// <param name="sdsc"></param>
		/// <returns></returns>
		public SDesc[] ChildSims(SDesc sdsc)
		{
			ArrayList list = new ArrayList();
			Supporting.FamilyTieSim fts = FindTies(sdsc);

			if (fts != null)
			{
				foreach (
					Supporting.FamilyTieItem fti in fts.Ties
				)
				{
					if (fti.SimDescription == null)
					{
						continue;
					}

					if (fti.Type == Data.MetaData.FamilyTieTypes.MyChildIs)
					{
						list.Add(fti.SimDescription);
					}
				}
			}

			SDesc[] ret = new SDesc[list.Count];
			list.CopyTo(ret);
			return ret;
		}

		/// <summary>
		/// returns a List of Spouse Sims
		/// </summary>
		/// <param name="sdsc"></param>
		/// <returns></returns>
		public SDesc[] SpouseSims(SDesc sdsc)
		{
			ArrayList list = new ArrayList();
			Supporting.FamilyTieSim fts = FindTies(sdsc);

			if (fts != null)
			{
				foreach (
					Supporting.FamilyTieItem fti in fts.Ties
				)
				{
					if (fti.SimDescription == null)
					{
						continue;
					}

					if (fti.Type == Data.MetaData.FamilyTieTypes.ImMarriedTo)
					{
						list.Add(fti.SimDescription);
					}
				}
			}

			SDesc[] ret = new SDesc[list.Count];
			list.CopyTo(ret);
			return ret;
		}
	}
}
