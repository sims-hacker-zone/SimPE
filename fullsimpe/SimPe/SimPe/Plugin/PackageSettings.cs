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
			get { return this.familyGuid; }
			set { this.familyGuid = value; }
		}

		[Category("Package")]
		public string Description
		{
			get { return this.description; }
			set { this.description = value; }
        }

        [Category("Package")]
        public bool KeepDisabledItems
        {
            get { return this.pinheadMode; }
            set { this.pinheadMode = value; }
        }

        [Category("Package")]
        public bool CompressTextures
        {
            get { return this.reCompressTextures; }
            set { this.reCompressTextures = value; }
        }

		public virtual RecolorType PackageType
		{
			get { return this.mode; }
		}

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

		public PackageSettings(PackageSettings settings, RecolorType type) : this(settings)
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
			get { return this.defaultProxy; }
			set { this.defaultProxy = value; }
		}

		/// <summary>
		/// Gets or sets a flag indicating if the respective hairtone
		/// package refers to a hat. Used mainly for turn-on / turn-off
		/// in NL.
		/// </summary>

		public override RecolorType PackageType
		{
			get { return RecolorType.Hairtone; }
		}

		public HairtoneSettings()
		{
		}

		public HairtoneSettings(PackageSettings settings) : base(settings)
		{
			if (settings is HairtoneSettings)
			{
				this.defaultProxy = ((HairtoneSettings)settings).defaultProxy;
			}
		}
	}

	public class SkintoneSettings : PackageSettings
	{
		float genetic;

		[Category("Skintone")]
		public float GeneticWeight
		{
			get { return this.genetic; }
			set { this.genetic = value; }
		}
		
		public override RecolorType PackageType
		{
			get { return RecolorType.Skintone; }
		}

		public SkintoneSettings()
		{
		}

		public SkintoneSettings(PackageSettings settings) : base(settings)
		{
			if (settings is SkintoneSettings)
			{
				this.genetic = ((SkintoneSettings)settings).genetic;
			}
		}
	}

	public class ClothingSettings : PackageSettings
	{
		ShoeType shoe;
		OutfitType outfit;
        SkinCategories category;
        OutfitCats outfitcat;
		SimGender gender;
		Ages age;
		SpeciesType species;
		TextureOverlayTypes overlayType;
        MetaData.Bodyshape figure;
        uint flaggery;

		public TextureOverlayTypes OverlayType
		{
			get { return overlayType; }
			set { overlayType = value; }
		}

		public SpeciesType Species
		{
			get { return species; }
			set { species = value; }
		}

		public ShoeType ShoeType
		{
			get { return this.shoe; }
			set { this.shoe = value; }
		}

		public OutfitType OutfitType
		{
			get { return this.outfit; }
			set { this.outfit = value; }
		}

		public SkinCategories Category
		{
			get { return this.category; }
			set { this.category = value; }
        }

        public OutfitCats OutfitCat
        {
            get { return this.outfitcat; }
            set { this.outfitcat = value; }
        }

        public MetaData.Bodyshape Figure
        {
            get { return this.figure; }
            set { this.figure = value; }
        }

		public SimGender Gender
		{
			get { return this.gender; }
			set { this.gender = value; }
		}

		public Ages Age
		{
			get { return this.age; }
			set { this.age = value; }
		}

        public uint Flaggery
        {
            get { return this.flaggery; }
            set { this.flaggery = value; }
        }

		public override RecolorType PackageType
		{
			get { return RecolorType.Skin; }
		}

		public ClothingSettings()
		{
		}

		public ClothingSettings(PackageSettings settings) : base(settings)
		{
			if (settings is ClothingSettings)
			{
				ClothingSettings cSettings = (ClothingSettings)settings;
				this.age = cSettings.age;
                this.category = cSettings.category;
                this.outfitcat = cSettings.outfitcat;
				this.gender = cSettings.gender;
				this.shoe = cSettings.shoe;
				this.outfit = cSettings.outfit;
                this.species = cSettings.species;
                this.figure = cSettings.figure;
                this.flaggery = cSettings.flaggery;
			}
		}
	}

	public interface IPackageSettings
	{
		Guid FamilyGuid { get; set; }
		string Description	{ get; set; }
		RecolorType PackageType { get; }
	}
}
