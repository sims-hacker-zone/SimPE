/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;

namespace SimPe.Plugin
{
	public class SkinChain
	{
		protected PackedFiles.Wrapper.Cpf cpf;

		public SkinChain(PackedFiles.Wrapper.Cpf cpf)
		{
			this.cpf = cpf;
		}

		public PackedFiles.Wrapper.Cpf Cpf => cpf;

		public uint Category
		{
			get
			{
				try
				{
					if (Cpf != null)
					{
						PackedFiles.Wrapper.CpfItem citem = Cpf.GetItem(
							"category"
						);
						if (citem != null)
						{
							if (
								(citem.UIntegerValue & (uint)Data.SkinCategories.Skin)
								== (uint)Data.SkinCategories.Skin
							)
							{
								citem.UIntegerValue = (uint)Data.SkinCategories.Skin;
							}

							if (citem.UIntegerValue != 128 && OutfitPart == 1)
							{
								citem.UIntegerValue = (uint)Data.SkinCategories.Hair;
							}

							return citem.UIntegerValue;
						}
					}
				}
				catch (Exception) { }
				return 0;
			}
		}

		public uint Age
		{
			get
			{
				try
				{
					if (Cpf != null)
					{
						PackedFiles.Wrapper.CpfItem citem = Cpf.GetItem("age");
						if (citem != null)
						{
							return citem.UIntegerValue;
						}
					}
				}
				catch (Exception) { }
				return 0;
			}
		}

		public string Name
		{
			get
			{
				try
				{
					if (Cpf != null)
					{
						PackedFiles.Wrapper.CpfItem citem = Cpf.GetItem("name");
						if (citem != null)
						{
							return citem.StringValue;
						}
					}
				}
				catch (Exception) { }
				return "";
			}
		}

		public uint Gender
		{
			get
			{
				try
				{
					if (Cpf != null)
					{
						PackedFiles.Wrapper.CpfItem citem = Cpf.GetItem("gender");
						if (citem != null)
						{
							return citem.UIntegerValue;
						}
					}
				}
				catch (Exception) { }
				return 0;
			}
		}

		public string Bodyshape
		{
			get
			{
				try
				{
					if (Cpf != null)
					{
						PackedFiles.Wrapper.CpfItem citem = Cpf.GetItem(
							"product"
						);
						if (citem != null)
						{
							if (citem.UIntegerValue > 0 && citem.UIntegerValue < 255)
							{
								return Data.MetaData.GetBodyName(
									citem.UIntegerValue
								);
							}
						}
						citem = Cpf.GetItem("skintone");
						if (citem == null)
						{
							citem = Cpf.GetItem("skincolor");
						}

						if (citem != null)
						{
							return Data.MetaData.GetBodyName(
								Data.MetaData.GetBodyShapeid(citem.StringValue)
							);
						}
					}
				}
				catch (Exception) { }
				return "Unknown";
			}
		}

		public uint OutfitPart
		{
			get
			{
				try
				{
					if (Cpf != null)
					{
						PackedFiles.Wrapper.CpfItem citem = Cpf.GetItem("outfit") ?? Cpf.GetItem("parts");

						if (citem != null)
						{
							return citem.UIntegerValue;
						}
					}
				}
				catch (Exception) { }
				return 0;
			}
		}

		public RefFile ReferenceFile
		{
			get
			{
				if (Cpf != null)
				{
					try
					{
						Interfaces.Files.IPackedFileDescriptor pfd =
							Cpf.Package.FindFile(
								0xAC506764,
								Cpf.FileDescriptor.SubType,
								Cpf.FileDescriptor.Group,
								Cpf.FileDescriptor.Instance
							);
						if (pfd != null)
						{
							RefFile reffile = new RefFile();
							reffile.ProcessData(pfd, Cpf.Package);

							return reffile;
						}
					}
					catch { }
				}
				return null;
			}
		}

		protected GenericRcol LoadRcol(
			uint type,
			Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			if (pfd.Type == type)
			{
				Interfaces.Scenegraph.IScenegraphFileIndexItem[] items =
					FileTableBase.FileIndex.FindFile(pfd, null);
				if (items.Length > 0)
				{
					GenericRcol rcol = new GenericRcol(null, false);
					rcol.ProcessData(items[0], false);

					return rcol;
				}
			}

			return null;
		}

		protected GenericRcol LoadTXTR(GenericRcol txmt)
		{
			if (txmt == null)
			{
				return null;
			}

			try
			{
				MaterialDefinition md = (MaterialDefinition)txmt.Blocks[0];
				string txtrname = md.FindProperty("stdMatBaseTextureName")
					.Value.Trim()
					.ToLower();
				if (!txtrname.EndsWith("_txtr"))
				{
					txtrname += "_txtr";
				}

				Interfaces.Scenegraph.IScenegraphFileIndexItem item =
					FileTableBase.FileIndex.FindFileByName(
						txtrname,
						Data.MetaData.TXTR,
						Data.MetaData.LOCAL_GROUP,
						true
					);
				if (item != null)
				{
					GenericRcol rcol = new GenericRcol(null, false);
					rcol.ProcessData(item, false);

					return rcol;
				}
			}
			catch { }

			return null;
		}

		public GenericRcol[] TXMTs
		{
			get
			{
				RefFile reffile = ReferenceFile;
				System.Collections.ArrayList list = new System.Collections.ArrayList();
				if (reffile != null)
				{
					try
					{
						foreach (
							Interfaces.Files.IPackedFileDescriptor pfd in reffile.Items
						)
						{
							GenericRcol rcol = LoadRcol(
								Data.MetaData.TXMT,
								pfd
							);
							if (rcol != null)
							{
								list.Add(rcol);
							}
						}
					}
					catch { }
				}

				GenericRcol[] ret = new GenericRcol[list.Count];
				list.CopyTo(ret);
				return ret;
			}
		}

		public GenericRcol[] TXTRs
		{
			get
			{
				GenericRcol[] txmts = TXMTs;
				System.Collections.ArrayList list = new System.Collections.ArrayList();
				foreach (GenericRcol txmt in txmts)
				{
					GenericRcol rcol = LoadTXTR(txmt);
					if (rcol != null)
					{
						list.Add(rcol);
					}
				}

				GenericRcol[] ret = new GenericRcol[list.Count];
				list.CopyTo(ret);
				return ret;
			}
		}

		public GenericRcol TXMT
		{
			get
			{
				RefFile reffile = ReferenceFile;
				if (reffile != null && cpf != null)
				{
					if (cpf.GetItem("override0resourcekeyidx") != null)
					{
						uint rki = cpf.GetSaveItem(
							"override0resourcekeyidx"
						).UIntegerValue;
						if (rki >= 0 && rki < reffile.Items.Length)
						{
							Interfaces.Files.IPackedFileDescriptor pfd = reffile.Items[
								rki
							];
							return LoadRcol(Data.MetaData.TXMT, pfd);
						}
					}
				}

				GenericRcol[] txmts = TXMTs;
				return txmts.Length > 0 ? txmts[0] : null;
			}
		}

		public GenericRcol TXTR
		{
			get
			{
				GenericRcol rcol = LoadTXTR(TXMT);
				if (rcol != null)
				{
					return rcol;
				}

				GenericRcol[] txtrs = TXTRs;
				return txtrs.Length > 0 ? txtrs[0] : null;
			}
		}

		public string CategoryNames
		{
			get
			{
				string scat = "";
				uint cat = Category;
				Array a = Enum.GetValues(typeof(Data.SkinCategories));
				foreach (Data.SkinCategories k in a)
				{
					if ((cat & (uint)k) == (uint)k)
					{
						if (scat != "")
						{
							scat += ", ";
						}

						scat += k.ToString();
					}
				}

				return scat;
			}
		}

		public string PartNames
		{
			get
			{
				string spart = "";
				uint part = OutfitPart;
				Array a = Enum.GetValues(typeof(Data.SkinParts));
				foreach (Data.SkinParts k in a)
				{
					if ((part & (uint)k) == (uint)k)
					{
						if (spart != "")
						{
							spart += ", ";
						}

						spart += k.ToString();
					}
				}

				return spart;
			}
		}

		public string AgeNames
		{
			get
			{
				string sage = "";
				uint age = Age;
				Array a = Enum.GetValues(typeof(Data.Ages));
				foreach (Data.Ages k in a)
				{
					if ((age & (uint)k) == (uint)k)
					{
						if (sage != "")
						{
							sage += ", ";
						}

						sage += k.ToString();
					}
				}

				return sage;
			}
		}

		public string GenderNames
		{
			get
			{
				string ssex = "";
				uint sex = Gender;
				Array a = Enum.GetValues(typeof(Data.Sex));
				foreach (Data.Sex k in a)
				{
					if ((sex & (uint)k) == (uint)k)
					{
						if (ssex != "")
						{
							ssex += ", ";
						}

						ssex += k.ToString();
					}
				}

				return ssex;
			}
		}

		public override string ToString()
		{
			return "Category=" + CategoryNames + "; Age=" + AgeNames + "; Name=" + Name;
		}
	}

	/// <summary>
	/// A Item in a 3IDR File
	/// </summary>
	public class RefFileItem : Packages.PackedFileDescriptor
	{
		RefFile parent;

		public RefFileItem(RefFile parent)
		{
			this.parent = parent;
		}

		public RefFileItem(Interfaces.Files.IPackedFileDescriptor pfd, RefFile parent)
		{
			this.parent = parent;
			Group = pfd.Group;
			Type = pfd.Type;
			SubType = pfd.SubType;
			Instance = pfd.Instance;
		}

		SkinChain skin;
		public SkinChain Skin
		{
			get
			{
				if (
					(skin == null)
					&& (
						Type == Data.MetaData.GZPS
						|| Type == Data.MetaData.AGED
						|| Type == Data.MetaData.XSTN
					)
					&& (parent != null)
				)
				{
					try
					{
						FileTableBase.FileIndex.Load();
						Interfaces.Scenegraph.IScenegraphFileIndexItem[] items =
							FileTableBase.FileIndex.FindFile(this, parent.Package);
						if (items.Length > 0)
						{
							PackedFiles.Wrapper.Cpf cpff =
								new PackedFiles.Wrapper.Cpf();
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

	internal class CpfListItem : SkinChain
	{
		uint category;

		internal CpfListItem(PackedFiles.Wrapper.Cpf cpf)
			: base(cpf)
		{
			this.cpf = cpf;
			Name = Localization.Manager.GetString("Unknown");
			category = 0;
			if (cpf != null)
			{
				foreach (PackedFiles.Wrapper.CpfItem citem in cpf.Items)
				{
					if (citem.Name.ToLower() == "name")
					{
						Name = citem.StringValue;
					}
				}

				foreach (PackedFiles.Wrapper.CpfItem citem in cpf.Items)
				{
					if (citem.Name.ToLower() == "category")
					{
						category = citem.UIntegerValue;
					}
				}
			}

			Name = Name.Replace("CASIE_", "");
		}

		public new string Name
		{
			get;
		}

		internal PackedFiles.Wrapper.Cpf File => cpf;

		public override string ToString()
		{
			return "0x" + Helper.HexString((ushort)category) + ": " + Name;
		}
	}
}
