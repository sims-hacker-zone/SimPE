// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Threading.Tasks;

using SimPe.Cache;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Plugin.Scanner;
using SimPe.PackedFiles.Objd;

namespace SimPe.Plugin.Scanner
{
	/// <summary>
	/// This class is retriving the Name of a Package
	/// </summary>
	internal class ShelveScanner : AbstractScanner, IScanner
	{
		public ShelveScanner()
			: base() { }

		#region IScannerBase Member
		public uint Version => 1;

		public int Index => 490;
		#endregion

		#region IScanner Member

		protected override void DoInitScan()
		{
			AddColumn("Shelve Dimension", 80);
		}

		public void ScanPackage(
			ScannerItem si,
			PackageState ps
		)
		{
			ps.Data = new System.Collections.Generic.List<uint> { (uint)ShelveDimension.Indetermined };
			ps.State = TriState.True;

			if (
				si.PackageCacheItem.Type == PackageType.CustomObject
				|| si.PackageCacheItem.Type == PackageType.Object
			)
			{
				Interfaces.Files.IPackedFileDescriptor[] pfds =
					si.Package.FindFiles(Data.FileTypes.OBJD);

				if (pfds.Length > 1)
				{
					ps.Data[0] = (uint)
						ShelveDimension.Multitile;
				}
				else if (pfds.Length > 0)
				{
					ShelveDimension sd = new ExtObjd().ProcessFile(pfds[0], si.Package).ShelveDimension;
					if (
						sd == ShelveDimension.Unknown1
						|| sd == ShelveDimension.Indetermined
						|| sd == ShelveDimension.Unknown2
					)
					{
						ps.State = TriState.False;
					}

					ps.Data[0] = (uint)sd;
				}
			}

			UpdateState(si, ps);
		}

		public void UpdateState(
			ScannerItem si,
			PackageState ps
		)
		{
		}

		public void FinishScan()
		{
		}

		public override bool IsActiveByDefault => false;

		ScannerItem[] selection;

		public override void EnableControl(ScannerItem[] items, bool active)
		{
			selection = items;
			if (!active)
			{
				return;
			}

			if (items.Length == 0)
			{
			}
			else if (items.Length == 1)
			{
				PackageState ps = items[0]
					.PackageCacheItem.FindState(Uid, true);
				if (ps.Data.Count > 0)
				{
				}
			}
			else
			{
			}
		}

		#endregion

		public override string ToString()
		{
			return "OFB Shelve Scanner (by Numenor)";
		}

		/// <summary>
		/// this Operation is fixing selected Packages that wer marked as problematic
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async Task Set(ShelveDimension sd)
		{
			if (selection == null)
			{
				return;
			}

			bool chg = false;
			try
			{
				foreach (ScannerItem si in selection)
				{

					PackageState ps = si.PackageCacheItem.FindState(
						Uid,
						true
					);
					if (ps.Data.Count < 1)
					{
						continue;
					}

					if (ps.State == TriState.True && selection.Length > 1)
					{
						continue;
					}

					ps.State = TriState.Null;
					try
					{
						Interfaces.Files.IPackedFileDescriptor[] pfds =
							si.Package.FindFiles(Data.FileTypes.OBJD);

						foreach (
							Interfaces.Files.IPackedFileDescriptor pfd in pfds
						)
						{
							ExtObjd objd = new ExtObjd().ProcessFile(pfd, si.Package);
							objd.ShelveDimension = sd;
							objd.SynchronizeUserData();
						}

						si.Package.Save();
					}
					catch (Exception ex)
					{
						await Helper.ExceptionMessage("", ex);
					}
				}

				if (chg && CallbackFinish != null)
				{
					CallbackFinish(false, false);
				}
			}
			catch (Exception ex)
			{
				await Helper.ExceptionMessage("", ex);
			}
		}
	}
}
