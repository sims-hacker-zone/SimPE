// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Swaf;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for MmatWrapper.
	/// </summary>
	public class XWant : Cpf
	{
		static Hashtable wanttypelookup;
		static Hashtable wantnamelookup;

		/// <summary>
		/// creates a new Instance
		/// </summary>
		public XWant()
			: base()
		{
			if (wanttypelookup == null)
			{
				wanttypelookup = new Hashtable();
				wantnamelookup = new Hashtable
				{
					[(byte)WantType.Career] = "Career"
				};
				wanttypelookup["career"] = WantType.Career;

				wantnamelookup[(byte)WantType.Category] = "Category";
				wanttypelookup["category"] = WantType.Category;

				wantnamelookup[(byte)WantType.None] = "Guid";
				wanttypelookup["guid"] = WantType.None;

				wantnamelookup[(byte)WantType.Object] = "None";
				wanttypelookup["none"] = WantType.Object;

				wantnamelookup[(byte)WantType.Sim] = "Sim";
				wanttypelookup["sim"] = WantType.Sim;

				wantnamelookup[(byte)WantType.Skill] = "Skill";
				wanttypelookup["skill"] = WantType.Skill;
			}
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override Interfaces.Plugin.IWrapperInfo CreateWrapperInfo()
		{
			return new Interfaces.Plugin.AbstractWrapperInfo(
				"XWNT Wrapper",
				"Quaxi",
				"---",
				2
			);
		}

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public override FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.XWNT };

		#region Default Attribute
		public uint StringInstance
		{
			get => GetSaveItem("stringSet").UIntegerValue;
			set => GetSaveItem("stringSet").UIntegerValue = value;
		}

		public uint Guid
		{
			get => GetSaveItem("id").UIntegerValue;
			set => GetSaveItem("id").UIntegerValue = value;
		}

		public uint IconInstance
		{
			get => GetSaveItem("primaryIcon").UIntegerValue;
			set => GetSaveItem("primaryIcon").UIntegerValue = value;
		}

		public uint SecondaryIconInstance
		{
			get => GetSaveItem("secondaryIcon").UIntegerValue;
			set => GetSaveItem("secondaryIcon").UIntegerValue = value;
		}

		public string Folder
		{
			get => GetSaveItem("folder").StringValue;
			set => GetSaveItem("folder").StringValue = value;
		}

		public int Score
		{
			get => GetSaveItem("score").IntegerValue;
			set => GetSaveItem("score").IntegerValue = value;
		}

		public int Influence
		{
			get => GetSaveItem("influence").IntegerValue;
			set => GetSaveItem("influence").IntegerValue = value;
		}

		public string ObjectType
		{
			get => GetSaveItem("objectType").StringValue;
			set => GetSaveItem("objectType").StringValue = value;
		}

		public string NodeText
		{
			get => GetSaveItem("nodeText").StringValue;
			set => GetSaveItem("nodeText").StringValue = value;
		}

		public WantType WantType
		{
			get
			{
				object o = wanttypelookup[ObjectType.Trim().ToLower()];
				if (o != null)
				{
					if (o.GetType() != typeof(string))
					{
						return (WantType)o;
					}
				}

				return WantType.None;
			}
			set
			{
				object o = wantnamelookup[(byte)value];
				if (o != null)
				{
					if (o.GetType() == typeof(string))
					{
						ObjectType = (string)o;
					}
				}

				ObjectType = "None";
			}
		}

		public Interfaces.Files.IPackedFileDescriptor IconFileDescriptor
		{
			get
			{
				Packages.PackedFileDescriptor pfd =
					new Packages.PackedFileDescriptor
					{
						Type = FileTypes.IMG,
						LongInstance = IconInstance
					};
				if (pfd.Instance == 0)
				{
					pfd.Instance = SecondaryIconInstance;
				}

				pfd.Group = 0x499DB772;

				return pfd;
			}
		}
		#endregion

		public override string Description => "GUID=0x"
					+ Helper.HexString(FileDescriptor.Instance)
					+ ", Folder="
					+ Folder
					+ ", ObjectType="
					+ ObjectType;

		protected override string GetResourceName(FileTypeInformation fti)
		{
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package);
			}

			return Folder + " / " + NodeText + " (" + ObjectType + ")";
		}
	}
}
