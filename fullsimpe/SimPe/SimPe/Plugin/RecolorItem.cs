using System;

using SimPe.Data;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for RecolorItem.
	/// </summary>
	public class RecolorItem : AbstractCpfInfo
	{
		private HairColor colorBin;

		public RcolTable Materials
		{
			get; set;
		}

		public HairColor ColorBin
		{
			get
			{
				return colorBin;
			}
			set
			{
				colorBin = value;
				if (!Utility.IsNullOrEmpty(Materials))
				{
					foreach (MaterialDefinitionRcol mmat in Materials)
					{
						mmat.ColorBin = value;
					}
				}
			}
		}

		#region Lazy properties...

		public MetaData.Bodyshape Figure
		{
			get
			{
				return (MetaData.Bodyshape)CpfItem("product").UIntegerValue;
			}
			set
			{
				SetValue("product", Convert.ToUInt32(value));
				if (Convert.ToUInt32(value) > 0)
				{
					SetValue("creator", "00000000-0000-0000-0000-000000000000");
				}
			}
		}

		public uint Flaggery
		{
			get
			{
				return CpfItem("flags").UIntegerValue;
			}
			set
			{
				CpfItem("flags").UIntegerValue = value;
			}
		}

		public Guid Hairtone
		{
			get
			{
				return ParseGuidValue(CpfItem("hairtone"));
			}
			set
			{
				SetValue("hairtone", value.ToString());
			}
		}

		public Ages Age
		{
			get
			{
				return (Ages)CpfItem("age").UIntegerValue;
			}
			set
			{
				SetValue("age", Convert.ToUInt32(value));
			}
		}

		public SimGender Gender
		{
			get
			{
				return (SimGender)CpfItem("gender").UIntegerValue;
			}
			set
			{
				SetValue("gender", Convert.ToUInt32(value));
			}
		}

		public TextureOverlayTypes TextureOverlayType
		{
			get
			{
				if (ContainsItem("subtype"))
				{
					return (TextureOverlayTypes)CpfItem("subtype").UIntegerValue;
				}

				return TextureOverlayTypes.EyeBrow;
			}
			set
			{
				SetValue("subtype", Convert.ToUInt32(value));
			}
		}

		public OutfitType OutfitType
		{
			get
			{
				if (ContainsItem("outfit"))
				{
					return (OutfitType)CpfItem("outfit").UIntegerValue;
				}
				else if (ContainsItem("parts"))
				{
					return (OutfitType)CpfItem("parts").UIntegerValue;
				}

				return OutfitType.None;
			}
			set
			{
				SetValue("outfit", Convert.ToUInt32(value));
				if (Version >= 4) // Pests?
				{
					SetValue("parts", Convert.ToUInt32(value));
				}
			}
		}

		/// <summary>
		/// Gets or sets the integer value of the "version" property.
		/// </summary>
		public uint Version
		{
			get
			{
				return CpfItem("version").UIntegerValue;
			}
			set
			{
				CpfItem("version").UIntegerValue = value;
			}
		}

		#endregion


		public RecolorItem(Cpf propertySet)
			: base(propertySet)
		{
			Materials = new RcolTable();
			colorBin = (HairColor)0;
		}

		public RecolorItem(Cpf propertySet, RcolTable txmt)
			: base(propertySet)
		{
			Materials = txmt;
		}

		public override void CommitChanges()
		{
			base.CommitChanges();
			if (Materials != null)
			{
				if (!Enabled)
				{
					if (!Pinned)
					{
						foreach (Rcol rcol in Materials)
						{
							rcol.FileDescriptor.MarkForDelete = true;
						}

						return;
					}
				}

				Materials.SynchronizeAll();
			}
		}
	}

	/// <remarks>
	/// These values are used in different contexts:
	/// Hairtone is used in XHTN resources, Skin and
	/// TextureOverlay/MeshOverlay are used in GZPSsses,
	/// Skintone is used by XSTN
	/// </remarks>
	public enum RecolorType
	{
		Unsupported = 0,
		Hairtone,
		Skintone,
		Skin,
		TextureOverlay,
		MeshOverlay,
	}
}
