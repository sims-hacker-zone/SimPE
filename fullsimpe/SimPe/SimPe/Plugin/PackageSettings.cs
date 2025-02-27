using System;
using System.ComponentModel;

using SimPe.Data;

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
				return familyGuid;
			}
			set
			{
				familyGuid = value;
			}
		}

		[Category("Package")]
		public string Description
		{
			get
			{
				return description;
			}
			set
			{
				description = value;
			}
		}

		[Category("Package")]
		public bool KeepDisabledItems
		{
			get
			{
				return pinheadMode;
			}
			set
			{
				pinheadMode = value;
			}
		}

		[Category("Package")]
		public bool CompressTextures
		{
			get
			{
				return reCompressTextures;
			}
			set
			{
				reCompressTextures = value;
			}
		}

		public virtual RecolorType PackageType => mode;

		public PackageSettings()
		{
		}

		public PackageSettings(PackageSettings settings)
		{
			if (settings != null)
			{
				description = settings.description;
				familyGuid = settings.familyGuid;
				pinheadMode = settings.pinheadMode;
				reCompressTextures = settings.reCompressTextures;
				mode = settings.mode;
			}
		}

		public PackageSettings(PackageSettings settings, RecolorType type)
			: this(settings)
		{
			mode = type;
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
				return defaultProxy;
			}
			set
			{
				defaultProxy = value;
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
				defaultProxy = ((HairtoneSettings)settings).defaultProxy;
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
				GeneticWeight = ((SkintoneSettings)settings).GeneticWeight;
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
				Age = cSettings.Age;
				Category = cSettings.Category;
				OutfitCat = cSettings.OutfitCat;
				Gender = cSettings.Gender;
				ShoeType = cSettings.ShoeType;
				OutfitType = cSettings.OutfitType;
				Species = cSettings.Species;
				Figure = cSettings.Figure;
				Flaggery = cSettings.Flaggery;
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
