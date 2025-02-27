using System;
using System.Collections.Generic;
using System.Text;

using SimPe.Data;
using SimPe.Interfaces;
using SimPe.Interfaces.Files;
using SimPe.Packages;
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
				return this.colorBin;
			}
			set
			{
				this.colorBin = value;
				if (!Utility.IsNullOrEmpty(this.Materials))
					foreach (MaterialDefinitionRcol mmat in this.Materials)
						mmat.ColorBin = value;
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
				this.SetValue("product", Convert.ToUInt32(value));
				if (Convert.ToUInt32(value) > 0)
					this.SetValue("creator", "00000000-0000-0000-0000-000000000000");
			}
		}

		public uint Flaggery
		{
			get
			{
				return this.CpfItem("flags").UIntegerValue;
			}
			set
			{
				this.CpfItem("flags").UIntegerValue = value;
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
				this.SetValue("hairtone", value.ToString());
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
				this.SetValue("age", Convert.ToUInt32(value));
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
				this.SetValue("gender", Convert.ToUInt32(value));
			}
		}

		public TextureOverlayTypes TextureOverlayType
		{
			get
			{
				if (this.ContainsItem("subtype"))
					return (TextureOverlayTypes)CpfItem("subtype").UIntegerValue;
				return TextureOverlayTypes.EyeBrow;
			}
			set
			{
				this.SetValue("subtype", Convert.ToUInt32(value));
			}
		}

		public OutfitType OutfitType
		{
			get
			{
				if (this.ContainsItem("outfit"))
					return (OutfitType)CpfItem("outfit").UIntegerValue;
				else if (this.ContainsItem("parts"))
					return (OutfitType)CpfItem("parts").UIntegerValue;
				return OutfitType.None;
			}
			set
			{
				this.SetValue("outfit", Convert.ToUInt32(value));
				if (this.Version >= 4) // Pests?
					this.SetValue("parts", Convert.ToUInt32(value));
			}
		}

		/// <summary>
		/// Gets or sets the integer value of the "version" property.
		/// </summary>
		public uint Version
		{
			get
			{
				return this.CpfItem("version").UIntegerValue;
			}
			set
			{
				this.CpfItem("version").UIntegerValue = value;
			}
		}

		#endregion


		public RecolorItem(Cpf propertySet)
			: base(propertySet)
		{
			this.Materials = new RcolTable();
			this.colorBin = (HairColor)0;
		}

		public RecolorItem(Cpf propertySet, RcolTable txmt)
			: base(propertySet)
		{
			this.Materials = txmt;
		}

		public override void CommitChanges()
		{
			base.CommitChanges();
			if (this.Materials != null)
			{
				if (!this.Enabled)
				{
					if (!this.Pinned)
					{
						foreach (Rcol rcol in this.Materials)
							rcol.FileDescriptor.MarkForDelete = true;
						return;
					}
				}

				this.Materials.SynchronizeAll();
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
