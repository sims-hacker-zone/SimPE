// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

using SimPe.Cache;
using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Plugin.Scanner;
using SimPe.PackedFiles.Idno;
using SimPe.Plugin.Scanner;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is retriving the Name of a Package
	/// </summary>
	internal class NeighborhoodScanner : AbstractScanner, IScanner
	{
		ArrayList ids;

		public NeighborhoodScanner()
			: base()
		{
			ids = new ArrayList();
		}

		public void LoadThumbnail(ScannerItem si, PackageState ps)
		{
			if (si.PackageCacheItem.Type == PackageType.Neighbourhood)
			{
				string name =
					System.IO.Path.Combine(
						System.IO.Path.GetDirectoryName(si.FileName),
						System.IO.Path.GetFileNameWithoutExtension(si.FileName)
					) + ".png";
				if (System.IO.File.Exists(name))
				{
					Image img = Image.FromFile(name);
					si.PackageCacheItem.Thumbnail = ImageLoader.Preview(
						img,
						ThumbnailSize
					);
				}
			}
		}

		#region IScannerBase Member
		public uint Version => 1;

		public int Index => 700;
		#endregion

		#region IScanner Member
		protected override void DoInitScan()
		{
			ids.Clear();
		}

		public void ScanPackage(
			ScannerItem si,
			PackageState ps
		)
		{
			LoadThumbnail(si, ps);
			if (si.PackageCacheItem.Type == PackageType.Neighbourhood)
			{
				Interfaces.Files.IPackedFileDescriptor[] pfds = si.Package.FindFiles(
					Data.FileTypes.IDNO
				);
				if (pfds.Length > 0)
				{
					Idno idno = new Idno().ProcessFile(pfds[0], si.Package);

					ps.Data = new List<uint>
					{
						[0] = (uint)idno.Type,
						[1] = idno.Uid
					};

					//check for duplicates
					ps.State = ids.Contains(idno.Uid)
						&& PathProvider.Global.EPInstalled < 18
						? TriState.False
						: TriState.True;
				}
				else
				{
					ps.Data = new List<uint>
					{
						[0] = 0,
						[1] = 0
					};
					ps.State = TriState.True;
				}
			}

			UpdateState(si, ps);
		}

		public void UpdateState(
			ScannerItem si,
			PackageState ps
		)
		{
			if (si.PackageCacheItem.Type == PackageType.Neighbourhood)
			{
				if (si.PackageCacheItem.Thumbnail == null)
				{
					LoadThumbnail(si, ps);
				}

				//Add the Thumbnail if available
				if (si.PackageCacheItem.Thumbnail != null)
				{
				}

				if (ps.Data.Count > 1)
				{
					ids.Add(ps.Data[1]);
				}
			}
		}

		public void FinishScan()
		{
		}

		ScannerItem[] selection;

		public override void EnableControl(ScannerItem[] items, bool active)
		{
			selection = items;
			if (!active)
			{
				return;
			}

			bool en = false;
			foreach (ScannerItem si in items)
			{
				if (si.PackageCacheItem.Type == PackageType.Neighbourhood)
				{
					en = true;
					break;
				}
			}
		}

		#endregion

		public override string ToString()
		{
			return "Neighbourhood Scanner";
		}

		private async Task MakeUnique(
			object sender
		)
		{
			if (selection == null || PathProvider.Global.EPInstalled >= 18)
			{
				return;
			}

			bool chg = false;
			try
			{
				Hashtable ids = Idno.FindUids(PathProvider.SimSavegameFolder, true);
				foreach (ScannerItem si in selection)
				{

					PackageState ps = si.PackageCacheItem.FindState(
						Uid,
						true
					);
					if (si.PackageCacheItem.Type == PackageType.Neighbourhood)
					{
						Interfaces.Files.IPackedFileDescriptor[] pfds =
							si.Package.FindFiles(FileTypes.IDNO);
						if (pfds.Length > 0)
						{
							Idno idno = new Idno().ProcessFile(pfds[0], si.Package);
							idno.MakeUnique(ids);

							if (ps.Data.Count < 2)
							{
								ps.Data = new List<uint> { 0, 0 };
							}

							if (idno.Uid != ps.Data[1])
							{
								idno.SynchronizeUserData();
								si.Package.Save();
								chg = true;

								ps.Data[1] = idno.Uid;
								ps.State = TriState.True;
							}
						}
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
