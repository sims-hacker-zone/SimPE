// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Summary description for ExtSDesc.
	/// </summary>
	public class ExtSDesc : SDesc /*, SimPe.Interfaces.Plugin.IMultiplePackedFileWrapper*/
	{
		public ExtSDesc()
			: base()
		{
			crmap = new Hashtable();
			locked = false;
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Extended Sim Description Wrapper",
				"Quaxi",
				"This File contains Settings (like interests, friendships, money, age, gender...) for one Sim.",
				8,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.sdsc.png")
				)
			);
		}

		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.ExtSDesc();
		}

		/// <summary>
		/// Returns the Name of the File the Character is stored in
		/// </summary>
		/// <remarks>null, if no File was found</remarks>
		public bool IsNPC
		{
			get
			{
				if (FileTableBase.ProviderRegistry.SimNameProvider != null)
				{
					object o = FileTableBase
						.ProviderRegistry.SimNameProvider.FindName(SimId)
						.Tag;
					if (o != null)
					{
						object[] tags = (object[])o;
						return tags[4] != null;
					}
				}
				return false;
			}
		}

		/// <summary>
		/// Returns the Name of the File the Character is stored in
		/// </summary>
		/// <remarks>null, if no File was found</remarks>
		public bool IsTownie => (
						((FamilyInstance & 0x7f00) == 0x7f00)
						|| FamilyInstance == 0
					) && !IsNPC;

		public override string CharacterFileName
		{
			get
			{
				if (IsNPC)
				{
					object o = FileTableBase
						.ProviderRegistry.SimNameProvider.FindName(SimId)
						.Tag;
					if (o != null)
					{
						object[] tags = (object[])o;
						return tags[4].ToString();
					}
				}
				return base.CharacterFileName;
			}
		}

		bool chgname;
		string sname,
			sfname;
		public override string SimFamilyName
		{
			get => sfname ?? base.SimFamilyName;
			set
			{
				chgname = true;
				sfname = value;
			}
		}

		public override string SimName
		{
			get => sname ?? base.SimName;
			set
			{
				chgname = true;
				sname = value;
			}
		}

		bool locked;

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			//lock (SimPe.Helper.WindowsRegistry)
			{
				if (locked)
				{
					return;
				}
				base.Unserialize(reader);
				chgname = false;
				crmap.Clear();
			}
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			//lock (SimPe.Helper.WindowsRegistry)
			{
				if (locked)
				{
					return;
				}
				base.Serialize(writer);
				if (chgname)
				{
					ChangeName();
				}

				SaveRelations();
			}
		}

		protected virtual void ChangeName()
		{
			if (!IsNPC)
			{
				if (ChangeNames(SimName, SimFamilyName))
				{
					chgname = false;
				}
			}

			if (!chgname)
			{
				sname = null;
				sfname = null;
			}
		}

		public bool HasRelationWith(ExtSDesc sdsc)
		{
			foreach (uint inst in Relations.SimInstances)
			{
				if (sdsc.FileDescriptor.Instance == inst)
				{
					return true;
				}
			}

			return false;
		}

		#region Changed Relations
		public void AddRelation(ExtSDesc sdesc)
		{
			foreach (ushort inst in Relations.SimInstances)
			{
				if (inst == (ushort)sdesc.FileDescriptor.Instance)
				{
					return;
				}
			}

			Relations.SimInstances.Add((ushort)sdesc.FileDescriptor.Instance);
			Changed = true;
		}

		public void RemoveRelation(ExtSDesc sdesc)
		{
			Relations.SimInstances.Remove((ushort)sdesc.FileDescriptor.Instance);
			Changed = true;
		}

		public override bool Changed
		{
			get
			{
				foreach (ExtSrel srel in crmap.Values)
				{
					if (srel.Changed)
					{
						return true;
					}
				}

				return base.Changed;
			}
			set
			{
				base.Changed = value;

				foreach (ExtSrel srel in crmap.Values)
				{
					srel.Changed = value;
				}
			}
		}

		Hashtable crmap;

		void SaveRelations()
		{
			if (locked)
			{
				return;
			}

			Collections.PackedFileDescriptors pfds =
				new Collections.PackedFileDescriptors();
			locked = true;

			try
			{
				foreach (ExtSrel srel in crmap.Values)
				{
					if (srel.Package != null)
					{
						srel.SynchronizeUserData();
					}
					else
					{
						srel.Package = Package;
						srel.SynchronizeUserData();
						pfds.Add(srel.FileDescriptor);
					}

					if (!Equals(srel.SourceSim))
					{
						if (srel.SourceSim != null)
						{
							if (srel.SourceSim.Changed)
							{
								srel.SourceSim.SynchronizeUserData();
							}
						}
					}
				}

				crmap.Clear();

				locked = false;

				Package.BeginUpdate();
				try
				{
					for (int i = pfds.Count - 1; i >= 0; i--)
					{
						if (i == 0)
						{
							Package.ForgetUpdate();
						}

						Package.Add(pfds[i], true);
					}
				}
				finally
				{
					Package.EndUpdate();
				}
			}
			finally
			{
				locked = false;
			}
		}

		internal ExtSrel GetCachedRelation(uint inst)
		{
			return crmap.ContainsKey(inst) ? (ExtSrel)crmap[inst] : null;
		}

		internal ExtSrel GetCachedRelation(ExtSDesc sdesc)
		{
			return GetCachedRelation(GetRelationInstance(sdesc));
		}

		internal void AddRelationToCache(ExtSrel srel)
		{
			if (srel == null)
			{
				return;
			}

			if (srel.FileDescriptor == null)
			{
				return;
			}

			if (!crmap.ContainsKey(srel.FileDescriptor.Instance))
			{
				crmap[srel.FileDescriptor.Instance] = srel;
			}
		}

		internal void RemoveRelationFromCache(ExtSrel srel)
		{
			if (srel == null)
			{
				return;
			}

			if (srel.FileDescriptor == null)
			{
				return;
			}

			if (crmap.ContainsKey(srel.FileDescriptor.Instance))
			{
				crmap.Remove(srel.FileDescriptor.Instance);
			}
		}

		public static ExtSrel FindRelation(ExtSDesc src, ExtSDesc dst)
		{
			return FindRelation(src, src, dst);
		}

		public static ExtSrel FindRelation(ExtSDesc cache, ExtSDesc src, ExtSDesc dst)
		{
			uint sinst = src.GetRelationInstance(dst);
			ExtSrel srel = cache.GetCachedRelation(sinst);
			if (srel == null)
			{
				Interfaces.Files.IPackedFileDescriptor spfd =
					cache.Package.FindFile(
						Data.FileTypes.SREL,
						0,
						cache.FileDescriptor.Group,
						sinst
					);

				if (spfd != null)
				{
					srel = new ExtSrel();
					srel.ProcessData(spfd, cache.Package);
				}
			}

			return srel;
		}

		public ExtSrel FindRelation(ExtSDesc sdesc)
		{
			return FindRelation(this, sdesc);
		}

		public uint GetRelationInstance(ExtSDesc sdesc)
		{
			return ((FileDescriptor.Instance & 0xffff) << 16)
				| (sdesc.FileDescriptor.Instance & 0xffff);
		}

		public ExtSrel CreateRelation(ExtSDesc sdesc)
		{
			ExtSrel srel = new ExtSrel();
			uint inst = GetRelationInstance(sdesc);
			srel.FileDescriptor = package.NewDescriptor(
				Data.FileTypes.SREL,
				0,
				FileDescriptor.Group,
				inst
			);
			srel.RelationState.IsKnown = true;

			return srel;
		}
		#endregion

		public override int GetHashCode()
		{
			return (int)SimId;
		}

		public override bool Equals(object obj)
		{
			return obj != null && (obj is SDesc s ? s.SimId == SimId : base.Equals(obj));
		}

		public override string DescriptionHeader
		{
			get
			{
				ArrayList list = new ArrayList
				{
					"GUID",
					"Filename",
					"Name",
					"Household ",
					"isNPC",
					"isTownie",
					Serializer.SerializeTypeHeader(CharacterDescription),
					Serializer.SerializeTypeHeader(Character),
					"Genetic"
						+ Serializer.SerializeTypeHeader(GeneticCharacter),
					Serializer.SerializeTypeHeader(Interests),
					Serializer.SerializeTypeHeader(Skills),
					"Version"
				};

				if ((int)Version >= (int)SDescVersions.University)
				{
					list.Add(Serializer.SerializeTypeHeader(University));
				}

				if ((int)Version >= (int)SDescVersions.Nightlife)
				{
					list.Add(Serializer.SerializeTypeHeader(Nightlife));
				}

				return Serializer.ConcatHeader(Serializer.ConvertArrayList(list));
			}
		}

		public override string Description
		{
			get
			{
				/** still Missing:
				 *		DNA
				 *		Lifetime Want
				 *		Alive/Dead
				 *		Traits, turnon, turnoff
				 *		Personality, Skills, User Character File, Mother, Father, Children, Best Friends, Household Wealth, Household Funds
				**/

				ArrayList list = new ArrayList
				{
					Serializer.Property("GUID", "0x" + Helper.HexString(SimId)),
					Serializer.Property("Filename", CharacterFileName),
					Serializer.Property("Name", SimName + " " + SimFamilyName),
					Serializer.Property("Household ", HouseholdName),
					Serializer.Property("isNPC", IsNPC.ToString()),
					Serializer.Property("isTownie", IsTownie.ToString()),
					CharacterDescription.ToString(),
					Character.ToString(),
					GeneticCharacter.ToString(),
					Interests.ToString(),
					Skills.ToString(),
					Serializer.Property("Version", Version.ToString())
				};

				if ((int)Version >= (int)SDescVersions.University)
				{
					list.Add(University.ToString());
				}

				if ((int)Version >= (int)SDescVersions.Nightlife)
				{
					list.Add(Nightlife.ToString());
				}

				return Serializer.Concat(Serializer.ConvertArrayList(list));
			}
		}
	}

	public class LinkedSDesc : ExtSDesc
	{
		public LinkedSDesc()
			: base() { }

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			base.Unserialize(reader);

			sdna = null;
		}

		SimDNA sdna;
		public SimDNA SimDNA
		{
			get
			{
				if (sdna == null)
				{
					Interfaces.Files.IPackedFileDescriptor pfd = package.FindFile(
						Data.FileTypes.SDNA,
						0,
						Data.MetaData.LOCAL_GROUP,
						FileDescriptor.Instance
					);
					if (pfd != null)
					{
						sdna = new SimDNA();
						sdna.ProcessData(pfd, package, true);
					}
				}

				return sdna;
			}
		}

		public Interfaces.Providers.ILotItem[] BusinessList => (uint)Version < (uint)SDescVersions.Business
					? (new Interfaces.Providers.ILotItem[0])
					: FileTableBase.ProviderRegistry.LotProvider.FindLotsOwnedBySim(
					Instance
				);

		public override string DescriptionHeader
		{
			get
			{
				ArrayList list = new ArrayList
				{
					base.DescriptionHeader
				};
				if (SimDNA != null)
				{
					list.Add(SimDNA.DescriptionHeader);
				}

				if ((int)Version >= (int)SDescVersions.Business)
				{
					list.Add(Serializer.SerializeTypeHeader(Business));
				}

				if ((int)Version >= (int)SDescVersions.Pets)
				{
					list.Add(Serializer.SerializeTypeHeader(Pets));
				}

				if ((int)Version >= (int)SDescVersions.Voyage)
				{
					list.Add(Serializer.SerializeTypeHeader(Voyage));
				}

				return Serializer.ConcatHeader(Serializer.ConvertArrayList(list));
			}
		}

		public override string Description
		{
			get
			{
				ArrayList list = new ArrayList
				{
					base.Description
				};
				if (SimDNA != null)
				{
					list.Add(Serializer.SubProperty("DNA", SimDNA.Description));
				}

				if ((int)Version >= (int)SDescVersions.Business)
				{
					list.Add(Business.ToString());
				}

				if ((int)Version >= (int)SDescVersions.Pets)
				{
					list.Add(Pets.ToString());
				}

				if ((int)Version >= (int)SDescVersions.Voyage)
				{
					list.Add(Voyage.ToString());
				}

				return Serializer.Concat(Serializer.ConvertArrayList(list));
			}
		}
	}
}
