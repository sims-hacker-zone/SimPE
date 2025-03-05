// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Interfaces.Files;

namespace SimPe.Plugin
{
	public class MaterialDefinitionRcol : GenericRcol
	{
		RcolTable textures;
		MaterialDefinition mmatd;

		public RcolTable Textures
		{
			get
			{
				if (textures == null)
				{
					textures = new RcolTable();
				}

				return textures;
			}
			set => textures = value;
		}

		public MaterialDefinition MaterialDefinition
		{
			get
			{
				if (mmatd == null)
				{
					if (!Utility.IsNullOrEmpty(Blocks))
					{
						mmatd = Blocks[0] as MaterialDefinition;
					}
				}
				return mmatd;
			}
		}

		public HairColor ColorBin
		{
			get; set;
		}

		public string BaseTextureName
		{
			get => MaterialDefinition != null ? mmatd.GetProperty("stdMatBaseTextureName").Value : string.Empty;
			set
			{
				if (MaterialDefinition != null)
				{
					mmatd.GetProperty("stdMatBaseTextureName").Value = value;
				}
			}
		}

		public string NormalMapTextureName
		{
			get => MaterialDefinition != null ? mmatd.GetProperty("stdMatNormalMapTextureName").Value : string.Empty;
			set
			{
				if (MaterialDefinition != null)
				{
					mmatd.GetProperty("stdMatNormalMapTextureName").Value = value;
				}
			}
		}

		public MaterialDefinitionRcol()
		{
		}

		public Dictionary<TextureType, IPackedFileDescriptor> GetTextureDescriptor()
		{
			Dictionary<TextureType, IPackedFileDescriptor> ret = new Dictionary<TextureType, IPackedFileDescriptor>();

			if (ReferenceChains.ContainsKey("stdMatBaseTextureName"))
			{
				IPackedFileDescriptor item =
					ReferenceChains["stdMatBaseTextureName"].FirstOrDefault();
				if (item != null)
				{
					ret.Add(TextureType.NormalMap, item);
				}
			}

			if (ReferenceChains.ContainsKey("stdMatNormalMapTextureName"))
			{
				IPackedFileDescriptor item =
					ReferenceChains["stdMatNormalMapTextureName"].FirstOrDefault();
				if (item != null)
				{
					ret.Add(TextureType.NormalMap, item);
				}
			}

			return ret;
		}

		public Hashtable GetTextureDescriptorNames()
		{
			Hashtable ret = new Hashtable();

			if (MaterialDefinition != null)
			{
				foreach (MaterialDefinitionProperty mmatp in mmatd.Properties)
				{
					if (string.Compare(mmatp.Name, "stdMatBaseTextureName", true) == 0)
					{
						ret.Add(TextureType.Base, mmatp.Value);
					}
					else if (
						string.Compare(mmatp.Name, "stdMatNormalMapTextureName", true)
						== 0
					)
					{
						ret.Add(TextureType.NormalMap, mmatp.Value);
					}
				}
			}

			return ret;
		}

		public void SetTextureDescriptorNames(Hashtable txtrRef)
		{
			if (MaterialDefinition != null)
			{
				foreach (DictionaryEntry de in txtrRef)
				{
					string key = string.Format("stdMat{0}TextureName", de.Key);
					MaterialDefinitionProperty prop = mmatd.GetProperty(key);
					prop.Value = Convert.ToString(de.Value);
				}
			}
		}
	}

	public enum TextureType
	{
		Base,
		NormalMap,
	}
}
