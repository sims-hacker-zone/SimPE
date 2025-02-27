using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

using SimPe.Data;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.Plugin
{
	[Serializable]
	public class PackageSettings : IPackageSettings
	{
		Guid familyGuid;
		string description;
		bool pinheadMode = false;
		bool reCompressTextures = false;
		RecolorType mode = RecolorType.Unsupported;

		[Category("Package")]
		public Guid FamilyGuid
		{
			get
			{
				return this.familyGuid;
			}
			set
			{
				this.familyGuid = value;
			}
		}

		[Category("Package")]
		public string Description
		{
			get
			{
				return this.description;
			}
			set
			{
				this.description = value;
			}
		}

		[Category("Package")]
		public bool KeepDisabledItems
		{
			get
			{
				return this.pinheadMode;
			}
			set
			{
				this.pinheadMode = value;
			}
		}

		[Category("Package")]
		public bool CompressTextures
		{
			get
			{
				return this.reCompressTextures;
			}
			set
			{
				this.reCompressTextures = value;
			}
		}

		public virtual RecolorType PackageType => this.mode;

		public PackageSettings()
		{
		}

		public PackageSettings(PackageSettings settings)
		{
			if (settings != null)
			{
				this.description = settings.description;
				this.familyGuid = settings.familyGuid;
				this.pinheadMode = settings.pinheadMode;
				this.reCompressTextures = settings.reCompressTextures;
				this.mode = settings.mode;
			}
		}

		public PackageSettings(PackageSettings settings, RecolorType type)
			: this(settings)
		{
			this.mode = type;
		}
	}

	public class HairtoneSettings : PackageSettings
	{
		Guid defaultProxy;

		/// <summary>
		/// Gets or sets the value that is applied to the proxy property
		/// of the HairtoneXML resource of custom hair packages.
		/// </summary>
		[Category("Hairtone")]
		public Guid DefaultProxy
		{
			get
			{
				return this.defaultProxy;
			}
			set
			{
				this.defaultProxy = value;
			}
		}

		/// <summary>
		/// Gets or sets a flag indicating if the respective hairtone
		/// package refers to a hat. Used mainly for turn-on / turn-off
		/// in NL.
		/// </summary>

		public override RecolorType PackageType => RecolorType.Hairtone;

		public HairtoneSettings()
		{
		}

		public HairtoneSettings(PackageSettings settings)
			: base(settings)
		{
			if (settings is HairtoneSettings)
			{
				this.defaultProxy = ((HairtoneSettings)settings).defaultProxy;
			}
		}
	}

	public class SkintoneSettings : PackageSettings
	{
		[Category("Skintone")]
		public float GeneticWeight
		{
			get; set;
		}

		public override RecolorType PackageType => RecolorType.Skintone;

		public SkintoneSettings()
		{
		}

		public SkintoneSettings(PackageSettings settings)
			: base(settings)
		{
			if (settings is SkintoneSettings)
			{
				this.GeneticWeight = ((SkintoneSettings)settings).GeneticWeight;
			}
		}
	}

	public class ClothingSettings : PackageSettings
	{
		public TextureOverlayTypes OverlayType
		{
			get; set;
		}

		public SpeciesType Species
		{
			get; set;
		}

		public ShoeType ShoeType
		{
			get; set;
		}

		public OutfitType OutfitType
		{
			get; set;
		}

		public SkinCategories Category
		{
			get; set;
		}

		public OutfitCats OutfitCat
		{
			get; set;
		}

		public MetaData.Bodyshape Figure
		{
			get; set;
		}

		public SimGender Gender
		{
			get; set;
		}

		public Ages Age
		{
			get; set;
		}

		public uint Flaggery
		{
			get; set;
		}

		public override RecolorType PackageType => RecolorType.Skin;

		public ClothingSettings()
		{
		}

		public ClothingSettings(PackageSettings settings)
			: base(settings)
		{
			if (settings is ClothingSettings)
			{
				ClothingSettings cSettings = (ClothingSettings)settings;
				this.Age = cSettings.Age;
				this.Category = cSettings.Category;
				this.OutfitCat = cSettings.OutfitCat;
				this.Gender = cSettings.Gender;
				this.ShoeType = cSettings.ShoeType;
				this.OutfitType = cSettings.OutfitType;
				this.Species = cSettings.Species;
				this.Figure = cSettings.Figure;
				this.Flaggery = cSettings.Flaggery;
			}
		}
	}

	public interface IPackageSettings
	{
		Guid FamilyGuid
		{
			get; set;
		}
		string Description
		{
			get; set;
		}
		RecolorType PackageType
		{
			get;
		}
	}
}
