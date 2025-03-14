// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Providers;
using SimPe.PackedFiles.Picture;
using SimPe.PackedFiles.Sdsc;
using SimPe.PackedFiles.Str;
using SimPe.PackedFiles.Xml;

namespace SimPe.Providers
{
	/// <summary>
	/// Summary description for SimDescription.
	/// </summary>
	public class SimDescriptions : SimCommonPackage, ISimDescriptions
	{

		List<Interfaces.Wrapper.ISDesc> sdescs = new List<Interfaces.Wrapper.ISDesc>();
		/// <summary>
		/// Holds all Descriptions by SimId
		/// </summary>
		Hashtable bysimid;

		/// <summary>
		/// Returns availabl SDSC Files by SimGUID
		/// </summary>
		public ILookup<uint, Interfaces.Wrapper.ISDesc> SimGuidMap => sdescs.ToLookup(item => item.SimId);

		/// <summary>
		/// Holds all Descriptions by Instance
		/// </summary>
		Hashtable byinstance;

		/// <summary>
		/// Returns availabl SDSC Files by Instance
		/// </summary>
		public ILookup<ushort, Interfaces.Wrapper.ISDesc> SimInstance => sdescs.ToLookup(item => item.Instance);

		/// <summary>
		/// Null or a Nameprovider
		/// </summary>
		ISimNames names;

		/// <summary>
		/// Nullor a FamilyName Provider
		/// </summary>
		ISimFamilyNames famnames;

		/// <summary>
		/// Creates the List for the specific Package
		/// </summary>
		/// <param name="folder">The Base Package</param>
		/// <param name="names">null or a valid SimNames Provider</param>
		/// <param name="famnames">nullr or a valid SimFamilyNames Provider</param>
		public SimDescriptions(
			IPackageFile package,
			ISimNames names,
			ISimFamilyNames famnames
		)
			: base(package)
		{
			this.names = names;
			this.famnames = famnames;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="names">null or a valid SimNames Provider</param>
		/// <param name="famnames">nullr or a valid SimFamilyNames Provider</param>
		internal SimDescriptions(ISimNames names, ISimFamilyNames famnames)
			: base(null)
		{
			this.names = names;
			this.famnames = famnames;
		}

		/// <summary>
		/// Loads all Available Description Files in the Package
		/// </summary>
		protected void LoadDescriptions()
		{
			sdescs.Clear();
			bool didwarndoubleguid = false;
			if (BasePackage == null)
			{
				return;
			}

			foreach (IPackedFileDescriptor pfd in BasePackage.FindFiles(FileTypes.SDSC))
			{
				LinkedSDesc sdesc = new LinkedSDesc().ProcessFile(pfd, BasePackage);

				if (!didwarndoubleguid)
				{
					if (sdescs.Any(item => item.SimId == sdesc.SimId))
					{
						Helper.ExceptionMessage(
							new Warning(
								"A Sim was found Twice!",
								"The Sim with GUID 0x"
									+ Helper.HexString(sdesc.SimId)
									+ " (instance=0x"
									+ Helper.HexString(pfd.Instance)
									+ ") exists more than once. This could result in Problems during the Gameplay!"
							)
						);
						didwarndoubleguid = true;
					}
					if (sdescs.Any(item => item.Instance == sdesc.Instance))
					{
						Helper.ExceptionMessage(
							new Warning(
								"A Sim was found Twice!",
								"The Sim with nid=0x"
									+ Helper.HexString(sdesc.Instance)
									+ " (instance=0x"
									+ Helper.HexString(pfd.Instance)
									+ ") exists more than once. This could result in Problems during the Gameplay!"
							)
						);
						didwarndoubleguid = true;
					}
				}
				sdescs.Add(sdesc);
			}
		}

		public IEnumerable<string> GetHouseholdNames()
		{
			return GetHouseholdNames(out string fc);
		}

		public IEnumerable<string> GetHouseholdNames(out string firstcustom)
		{
			ILookup<ushort, Interfaces.Wrapper.ISDesc> ht = FileTableBase.ProviderRegistry
															.SimDescriptionProvider.SimInstance;
			firstcustom = ht.SelectMany(item => item)
				   .Cast<LinkedSDesc>()
				   .Where(sdesc => !sdesc.IsNPC && !sdesc.IsTownie)
				   .Select(sdesc => sdesc.HouseholdName ?? Localization.GetString("Unknown"))
				   .FirstOrDefault();
			return ht.SelectMany(item => item)
				.Select(sdesc => sdesc.HouseholdName
								?? Localization.GetString("Unknown"));
		}

		#region ISimDescription Member

		public Interfaces.Wrapper.ISDesc FindSim(uint simid)
		{
			if (sdescs.Count == 0)
			{
				LoadDescriptions();
			}

			return SimGuidMap[simid].FirstOrDefault();
		}

		Interfaces.Wrapper.ISDesc ISimDescriptions.FindSim(ushort instance)
		{
			if (sdescs.Count == 0)
			{
				LoadDescriptions();
			}

			return SimInstance[instance].FirstOrDefault();
		}

		public ushort GetInstance(uint simid)
		{
			Interfaces.Wrapper.ISDesc d = FindSim(simid);
			return d != null ? d.Instance : (ushort)0xffff;
		}

		public uint GetSimId(ushort instance)
		{
			Interfaces.Wrapper.ISDesc d = FindSim(instance);
			return d != null ? d.SimId : 0xffffffff;
		}

		#endregion


		#region Nightlife Turn On/Off Extension
		int to1 = 13;
		Dictionary<int, string> turnons;

		void LoadTurnOns()
		{
			if (turnons != null)
			{
				return;
			}

			turnons = new Dictionary<int, string>();
			if (
				PathProvider.Global.EPInstalled < 2
				&& PathProvider.Global.STInstalled < 28
			)
			{
				return;
			}
			else if (Helper.WindowsRegistry.Config.LoadOnlySimsStory > 0)
			{
				to1 = 12;
			}

			Packages.File pkg = Packages.File.LoadFromFile(
				System.IO.Path.Combine(
					PathProvider.Global.Latest.InstallFolder,
					@"TSData\Res\Text\UIText.package"
				)
			);
			Str str = new Str();
			IPackedFileDescriptor pfd = pkg.FindFile(
				FileTypes.STR,
				0,
				MetaData.LOCAL_GROUP,
				0xe1
			);

			if (pfd != null)
			{
				str.ProcessData(pfd, pkg);
				List<StrToken> strs =
					str.FallbackedLanguageItems(Helper.WindowsRegistry.Config.LanguageCode);
				if (to1 == 12)
				{
					for (int i = 0; i < strs.Count; i++)
					{
						if (i != 13)
						{
							turnons[i] = strs[i].Title;
						}
					}
				}
				else
				{
					for (int i = 0; i < strs.Count; i++)
					{
						turnons[i] = strs[i].Title;
					}
				}
			}
		}

		public TraitAlias[] GetAllTurnOns()
		{
			if (turnons == null)
			{
				LoadTurnOns();
			}

			TraitAlias[] a = new TraitAlias[turnons.Count];

			int ct = 0;
			int j = 15 - to1;
			foreach (int k in turnons.Keys)
			{
				string s = turnons[k];
				int e = k;
				if (e > to1)
				{
					e += j; // Fuck - only 14 bits in traits 1. If A&N's Nudity were anabled this would need to be altered just for A&N
				}

				a[ct++] = new TraitAlias((ulong)Math.Pow(2, e), s);
			}

			return a;
		}

		public ulong BuildTurnOnIndex(ushort val1, ushort val2, ushort val3)
		{
			ulong res = val1;
			res |= (ulong)val2 << 16;
			res |= (ulong)val3 << 32; // BonVoyage

			return res;
		}

		public ushort[] GetFromTurnOnIndex(ulong index)
		{
			ushort[] ret = new ushort[3];
			ret[2] = (ushort)((index >> 32) & 0xFFFF); // BonVoyage
			ret[1] = (ushort)((index >> 16) & 0xFFFF);
			ret[0] = (ushort)(index & 0xFFFF);

			return ret;
		}

		public string GetTurnOnName(ushort val1, ushort val2, ushort val3)
		{
			if (turnons == null)
			{
				LoadTurnOns();
			}

			ulong v = BuildTurnOnIndex(val1, val2, val3);
			string ret = "";
			int ct = 0;
			while (v > 0)
			{
				ulong s = v & 1;
				if (s == 1)
				{
					string o = turnons[ct];
					if (o == null)
					{
						return Localization.GetString("Unknown");
					}

					if (ret != "")
					{
						ret += ", ";
					}

					ret += o;
				}

				v >>= 1;
			}

			return ret;
		}
		#endregion

		#region Voyage Vacation Collectibles
		Dictionary<int, CollectibleAlias> collectibles;

		void LoadCollectibles()
		{
			if (collectibles != null)
			{
				return;
			}

			collectibles = new Dictionary<
				int,
				CollectibleAlias
			>();
			if (PathProvider.Global.EPInstalled < 10)
			{
				return;
			}

			Packages.File pkg = Packages.File.LoadFromFile(
				System.IO.Path.Combine(
					PathProvider.Global.Latest.InstallFolder,
					@"TSData\Res\Text\UIText.package"
				)
			);
			Str str = new Str();
			IPackedFileDescriptor pfd = pkg.FindFile(
				FileTypes.STR,
				0,
				MetaData.LOCAL_GROUP,
				0xb7
			);
			if (pfd != null)
			{
				str.ProcessData(pfd, pkg);
				List<StrToken> strs =
					str.FallbackedLanguageItems(Helper.WindowsRegistry.Config.LanguageCode);

				pkg = Packages.File.LoadFromFile(
					System.IO.Path.Combine(
						PathProvider.Global.Latest.InstallFolder,
						@"TSData\Res\UI\ui.package"
					)
				);
				pfd = pkg.FindFile(0, 0, 0xA99D8A11, 0xACDC6300);
				if (pfd != null)
				{
					try
					{

						string[] lines = new Xml().ProcessFile(pfd, pkg).Text.Split(new char[] { '\r' });
						Picture pic = new Picture();
						// SimPe.FileTable.FileIndex.Load();
						foreach (string fulline in lines)
						{
							string line = fulline.ToLower().Trim();
							if (
								line.StartsWith("<legacy")
								&& line.IndexOf("enabled\"") > 0
								&& line.IndexOf("tipres=") >= 0
							)
							{
								line = line.Replace("<legacy", "")
									.Replace(">", "")
									.Trim();
								string tipres = GetUIListAttribute(line, "tipres");
								int index =
									Helper.StringToInt32(
										tipres.Split(new char[] { ',' })[1],
										0,
										16
									) & 0xFFFF;
								int testnr = (int)(
									(
										Helper.StringToInt32(
											tipres.Split(new char[] { ',' })[1],
											0,
											16
										) & 0xFFFF0000
									) >> 16
								);

								if (index > 0 && testnr == 0xb7)
								{
									index = CreateCollectibleAlias(
										strs,
										pic,
										line,
										index
									);
								}
							}
						}
					}
					catch (Exception e)
					{
						System.Diagnostics.Debug.WriteLine(
							"ERROR during Voyage Collectible Image Parsing:\n"
								+ e.ToString()
						);
						if (Helper.WindowsRegistry.Config.HiddenMode)
						{
							Helper.ExceptionMessage(e);
						}
					}
				}
			}
		}

		private int CreateCollectibleAlias(
			List<StrToken> strs,
			Picture pic,
			string line,
			int index
		)
		{
			index--;
			string image = GetUIListAttribute(line, "image");
			string id = GetUIAttribute(line, "id");
			int nr = (Helper.StringToInt32(id, 0, 16) / 2) - 1;
			string[] stgi = image.Split(new char[] { ',' });
			uint g = Helper.StringToUInt32(stgi[0], 0, 16);
			uint i = Helper.StringToUInt32(stgi[1], 0, 16);
			string name = GetUITextAttribute(line, "tiptext");
			if (index < strs.Count)
			{
				name = strs[index].Title;
			}

			System.Drawing.Image img = null;

			img = LoadCollectibleIcon(pic, g, i);

			collectibles[nr] = new CollectibleAlias(
				(ulong)Math.Pow(2, nr),
				nr,
				name,
				img
			);
			return index;
		}

		/* This required he whole file table but since we know where to find the images that is obsolete.
		private static System.Drawing.Image LoadCollectibleIcon(SimPe.PackedFiles.Wrapper.Picture pic, UInt32 g, UInt32 i)
		{
			SimPe.Interfaces.Scenegraph.IScenegraphFileIndexItem[] items = SimPe.FileTable.FileIndex.FindFileByGroupAndInstance(g, i);
			if (items.Length > 0)
			{
				pic.ProcessData(items[0]);
				System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(pic.Image.Width / 4, pic.Image.Height);
				System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
				gr.DrawImage(pic.Image, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.GraphicsUnit.Pixel);
				gr.Dispose();
				return bmp;
			}
			return null;
		}
		*/
		private static System.Drawing.Image LoadCollectibleIcon(
			Picture pic,
			uint g,
			uint i
		)
		{
			Packages.File pkg = Packages.File.LoadFromFile(
				System.IO.Path.Combine(
					PathProvider.Global.GetExpansion(10).InstallFolder,
					"TSData\\Res\\UI\\ui.package"
				)
			);
			if (pkg != null)
			{
				IPackedFileDescriptor pfd = pkg.FindFile(
					FileTypes.IMG,
					0,
					g,
					i
				);
				if (pfd != null)
				{
					pic.ProcessData(pfd, pkg);
					System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(
						pic.Image.Width / 4,
						pic.Image.Height
					);
					System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
					gr.DrawImage(
						pic.Image,
						new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
						new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
						System.Drawing.GraphicsUnit.Pixel
					);
					gr.Dispose();
					return bmp;
				}
			}
			return null;
		}

		private static string GetUIListAttribute(string line, string name)
		{
			line = " " + line + " ";
			int p = line.IndexOf(" " + name + "={");
			string tipres = line.Substring(p + (" " + name + "={").Length);
			p = tipres.IndexOf("} ");
			tipres = tipres.Substring(0, p);

			return tipres;
		}

		private static string GetUIAttribute(string line, string name)
		{
			line = " " + line + " ";
			int p = line.IndexOf(" " + name + "=");
			string tipres = line.Substring(p + (" " + name + "=").Length);
			p = tipres.IndexOf(' ');
			tipres = tipres.Substring(0, p);

			return tipres;
		}

		private static string GetUITextAttribute(string line, string name)
		{
			line = " " + line + " ";
			int p = line.IndexOf(" " + name + "=\"");
			string tipres = line.Substring(p + (" " + name + "=\"").Length);
			p = tipres.IndexOf("\" ");
			tipres = tipres.Substring(0, p);

			return tipres;
		}

		public CollectibleAlias[] GetAllCollectibles()
		{
			if (collectibles == null)
			{
				LoadCollectibles();
			}

			CollectibleAlias[] a = new CollectibleAlias[
				collectibles.Count
			];

			int ct = 0;
			foreach (int k in collectibles.Keys)
			{
				a[ct++] = collectibles[k];
			}

			return a;
		}

		public ulong BuildCollectibleIndex(
			ushort val1,
			ushort val2,
			ushort val3,
			ushort val4
		)
		{
			return (uint)(((((val4 << 16) + val3) << 16) + val2) << 16) + val1;
		}

		public ushort[] GetFromCollectibleIndex(ulong index)
		{
			ushort[] ret = new ushort[2];
			ret[3] = (ushort)((index >> 48) & 0xFFFF);
			ret[2] = (ushort)((index >> 32) & 0xFFFF);
			ret[1] = (ushort)((index >> 16) & 0xFFFF);
			ret[0] = (ushort)(index & 0xFFFF);

			return ret;
		}

		public string GetCollectibleName(
			ushort val1,
			ushort val2,
			ushort val3,
			ushort val4
		)
		{
			if (collectibles == null)
			{
				LoadCollectibles();
			}

			ulong v = BuildCollectibleIndex(val1, val2, val3, val4);
			string ret = "";
			int ct = 0;
			while (v > 0)
			{
				ulong s = v & 1;
				if (s == 1)
				{
					object o = collectibles[ct];
					if (o == null)
					{
						return Localization.GetString("Unknown");
					}

					if (ret != "")
					{
						ret += ", ";
					}

					ret += o.ToString();
				}

				v >>= 1;
			}

			return ret;
		}
		#endregion

		/// <summary>
		/// Called if the BaseBackae was changed
		/// </summary>
		protected override void OnChangedPackage()
		{
			sdescs.Clear();
			names = null;
			famnames = null;
		}
	}
}
