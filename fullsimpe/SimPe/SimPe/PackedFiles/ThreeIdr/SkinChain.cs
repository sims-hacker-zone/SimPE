// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.Plugin;

namespace SimPe.PackedFiles.ThreeIdr
{
	public class SkinChain
	{
		protected Cpf.Cpf cpf;

		public SkinChain(Cpf.Cpf cpf)
		{
			this.cpf = cpf;
		}

		public Cpf.Cpf Cpf => cpf;

		public uint Category
		{
			get
			{
				try
				{
					if (Cpf != null)
					{
						Cpf.CpfItem citem = Cpf.GetItem(
							"category"
						);
						if (citem != null)
						{
							if (
								(citem.UIntegerValue & (uint)SkinCategories.Skin)
								== (uint)SkinCategories.Skin
							)
							{
								citem.UIntegerValue = (uint)SkinCategories.Skin;
							}

							if (citem.UIntegerValue != 128 && OutfitPart == 1)
							{
								citem.UIntegerValue = (uint)SkinCategories.Hair;
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
						Cpf.CpfItem citem = Cpf.GetItem("age");
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
						Cpf.CpfItem citem = Cpf.GetItem("name");
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
						Cpf.CpfItem citem = Cpf.GetItem("gender");
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
						Cpf.CpfItem citem = Cpf.GetItem(
							"product"
						);
						if (citem != null)
						{
							if (citem.UIntegerValue > 0 && citem.UIntegerValue < 255)
							{
								return MetaData.GetBodyName(
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
							return MetaData.GetBodyName(
								MetaData.GetBodyShapeid(citem.StringValue)
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
						Cpf.CpfItem citem = Cpf.GetItem("outfit") ?? Cpf.GetItem("parts");

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

		public ThreeIdr ReferenceFile
		{
			get
			{
				if (Cpf != null)
				{
					try
					{
						Interfaces.Files.IPackedFileDescriptor pfd =
							Cpf.Package.FindFile(
								FileTypes.THREE_IDR,
								Cpf.FileDescriptor.SubType,
								Cpf.FileDescriptor.Group,
								Cpf.FileDescriptor.Instance
							);
						if (pfd != null)
						{

							return new ThreeIdr().ProcessFile(pfd, Cpf.Package);
						}
					}
					catch { }
				}
				return null;
			}
		}

		protected GenericRcol LoadRcol(
			FileTypes type,
			Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			if (pfd.Type == type)
			{
				Interfaces.Scenegraph.IScenegraphFileIndexItem item =
					FileTableBase.FileIndex.FindFile(pfd, null).FirstOrDefault();
				if (item != null)
				{
					return new GenericRcol(null, false).ProcessFile(item, false);
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
						FileTypes.TXTR,
						MetaData.LOCAL_GROUP,
						true
					);
				if (item != null)
				{
					return new GenericRcol(null, false).ProcessFile(item, false);
				}
			}
			catch { }

			return null;
		}

		public GenericRcol[] TXMTs
		{
			get
			{
				ThreeIdr reffile = ReferenceFile;
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
								FileTypes.TXMT,
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
				ThreeIdr reffile = ReferenceFile;
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
							return LoadRcol(FileTypes.TXMT, pfd);
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
				Array a = Enum.GetValues(typeof(SkinCategories));
				foreach (SkinCategories k in a)
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
				Array a = Enum.GetValues(typeof(SkinParts));
				foreach (SkinParts k in a)
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
				Array a = Enum.GetValues(typeof(Ages));
				foreach (Ages k in a)
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
				Array a = Enum.GetValues(typeof(Gender));
				foreach (Gender k in a)
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
}
