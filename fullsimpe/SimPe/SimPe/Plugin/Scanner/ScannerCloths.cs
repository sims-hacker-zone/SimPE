// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using SimPe.Cache;
using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Plugin.Scanner;
using SimPe.PackedFiles.Cpf;

namespace SimPe.Plugin.Scanner
{
	/// <summary>
	/// This class is retriving the Name of a Package
	/// </summary>
	internal class ClothingScanner : AbstractScanner, IScanner
	{
		public ClothingScanner()
			: base() { }

		#region IScannerBase Member
		public uint Version => 1;

		public int Index => 600;
		#endregion

		#region IScanner Member

		protected override void DoInitScan()
		{
			AddColumn("Ages", 150);
			AddColumn("Categories", 150);
			AddColumn("Gender", 50);
		}

		public void ScanPackage(
			ScannerItem si,
			PackageState ps
		)
		{
			if (
				si.PackageCacheItem.Type == PackageType.Clothing
				|| si.PackageCacheItem.Type == PackageType.Skin
				|| (
					(uint)si.PackageCacheItem.Type
					& (uint)PackageType.Makeup
				) == (uint)PackageType.Makeup
				|| (
					(uint)si.PackageCacheItem.Type
					& (uint)PackageType.Accessory
				) == (uint)PackageType.Accessory
				|| si.PackageCacheItem.Type == PackageType.Hair
			)
			{
				Interfaces.Files.IPackedFileDescriptor[] pfds = si.Package.FindFiles(
					Data.FileTypes.GZPS
				);
				if (pfds.Length == 0)
				{
					pfds = si.Package.FindFiles(FileTypes.XOBJ); //Object XML
				}

				if (pfds.Length == 0)
				{
					pfds = si.Package.FindFiles(FileTypes.XTOL); //TextureOverlay XML
				}

				if (pfds.Length == 0)
				{
					pfds = si.Package.FindFiles(FileTypes.XHTN); //Hairtone XML
				}

				if (pfds.Length == 0)
				{
					pfds = si.Package.FindFiles(FileTypes.XMOL); //Mesh Overlay XML
				}

				List<uint> data = new List<uint>();
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					Cpf cpf = new Cpf().ProcessFile(pfd, si.Package, false);

					data.Add(cpf.GetSaveItem("age").UIntegerValue);
					data.Add(cpf.GetSaveItem("category").UIntegerValue);
					data.Add(cpf.GetSaveItem("gender").UIntegerValue);
				}

				ps.Data = new List<uint>(data);
				ps.State = TriState.True;
			}
			else
			{
				ps.State = TriState.False;
			}

			UpdateState(si, ps);
		}

		public void UpdateState(
			ScannerItem si,
			PackageState ps
		)
		{
			if (ps.State == TriState.True)
			{
				uint f = 0;
				uint c = 0;
				uint a = 0;
				for (int i = 0; i < ps.Data.Count - 2; i += 3)
				{
					f |= ps.Data[i + 2];
					c |= ps.Data[i + 1];
					a |= ps.Data[i];
				}

				string age = "";
				Data.Ages[] ages = (Data.Ages[])
					Enum.GetValues(typeof(Data.Ages));
				foreach (Data.Ages ag in ages)
				{
					if ((a & (uint)ag) != 0)
					{
						if (age != "")
						{
							age += ", ";
						}

						age += ag.ToString();
					}
				}

				string sex = "";
				Data.Gender[] sexs = (Data.Gender[])Enum.GetValues(typeof(Data.Gender));
				foreach (Data.Gender sx in sexs)
				{
					if ((f & (uint)sx) != 0)
					{
						if (sex != "")
						{
							sex += ", ";
						}

						sex += sx.ToString();
					}
				}

				if (si.PackageCacheItem.Type != PackageType.Skin)
				{
					string category = "";
					Data.OutfitCats[] cats = (Data.OutfitCats[])
						Enum.GetValues(typeof(Data.OutfitCats));
					foreach (Data.OutfitCats cat in cats)
					{
						if ((c & (uint)cat) != 0)
						{
							if (category != "")
							{
								category += ", ";
							}

							category += cat.ToString();
						}
					}
				}
			}
		}

		public void FinishScan()
		{
		}

		public override bool IsActiveByDefault => true;

		ScannerItem[] selection;

		public override void EnableControl(ScannerItem[] items, bool active)
		{
			selection = items;
			int maxagecount = 0;
			foreach (ScannerItem si in items)
			{
				PackageState ps = si.PackageCacheItem.FindState(
					Uid,
					true
				);
				for (int ct = 0; ct < ps.Data.Count - 2; ct += 3)
				{
					maxagecount++;
				} //for ct
			}
		}

		#endregion

		void AddUniversityFields(Cpf cpf)
		{
			if (cpf.GetItem("product") == null)
			{
				CpfItem i =
					new CpfItem
					{
						Name = "product",
						UIntegerValue = 1
					};
				cpf.AddItem(i);
			}

			if (cpf.GetItem("version") == null)
			{
				CpfItem i =
					new CpfItem
					{
						Name = "version",
						UIntegerValue = 2
					};
				cpf.AddItem(i);
			}
		}

		/// <summary>
		/// Set the Age of the Files
		/// </summary>
		/// <param name="name"></param>
		/// <param name="cbs"></param>
		/// <param name="yacheck">true, if you want to perform a check for YoungAdulst and add apropriate Filds to the cpf</param>
		async Task SetProperty(string name, bool yacheck)
		{
			if (selection == null)
			{
				return;
			}

			try
			{
				bool chg = false;
				foreach (ScannerItem si in selection)
				{
					if (
						si.PackageCacheItem.Type == PackageType.Clothing
						|| si.PackageCacheItem.Type == PackageType.Skin
						|| (
							(uint)si.PackageCacheItem.Type
							& (uint)PackageType.Makeup
						) == (uint)PackageType.Makeup
						|| (
							(uint)si.PackageCacheItem.Type
							& (uint)PackageType.Accessory
						) == (uint)PackageType.Accessory
						|| si.PackageCacheItem.Type == PackageType.Hair
					)
					{

						//make sure, the file is rescanned on the next Cache Update
						PackageState ps = si.PackageCacheItem.FindState(
							Uid,
							true
						);
						ps.State = TriState.Null;

						Interfaces.Files.IPackedFileDescriptor[] pfds =
							si.Package.FindFiles(Data.FileTypes.GZPS);
						if (pfds.Length == 0)
						{
							pfds = si.Package.FindFiles(FileTypes.XOBJ);
						}

						if (pfds.Length == 0)
						{
							pfds = si.Package.FindFiles(FileTypes.XTOL);
						}

						if (pfds.Length == 0)
						{
							pfds = si.Package.FindFiles(FileTypes.XHTN);
						}

						if (pfds.Length == 0)
						{
							pfds = si.Package.FindFiles(FileTypes.XMOL);
						}

						ArrayList data = new ArrayList();
						foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
						{
							Cpf cpf = new Cpf().ProcessFile(pfd, si.Package, false);

							uint age = cpf.GetSaveItem(name).UIntegerValue;

							if (yacheck)
							{
								//when Young Adult is set, we need to make sure that the Version is updated accordingly!
								if ((age & (uint)Data.Ages.YoungAdult) != 0)
								{
									AddUniversityFields(cpf);
								}
							}

							if (cpf.GetSaveItem(name).UIntegerValue != age)
							{
								chg = true;
							}

							cpf.GetSaveItem(name).UIntegerValue = age;

							cpf.SynchronizeUserData();
						}

						si.Package.Save();
					}
				} //foreach
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

		public override string ToString()
		{
			return "Clothing Scanner";
		}
	}
}
