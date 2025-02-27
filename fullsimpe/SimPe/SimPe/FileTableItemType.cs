using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe
{
	public enum FileTablePaths : uint
	{
		Absolute = 0x8FFF0000,
		SaveGameFolder = 0x8FFF0001,
		SimPEFolder = 0x8FFE0000,
		SimPEDataFolder = 0x8FFE0001,
		SimPEPluginFolder = 0x8FFE0002,
	}

	public class FileTableItemType : IComparable
	{
		public FileTableItemType(Expansions e)
			: this((uint)e) { }

		public FileTableItemType(FileTablePaths f)
			: this((uint)f) { }

		public FileTableItemType(int i)
		{
			AsUint = (uint)i;
		}

		public FileTableItemType(uint i)
		{
			AsUint = i;
		}

		public static implicit operator FileTableItemType(Expansions e)
		{
			return new FileTableItemType(e);
		}

		public static implicit operator FileTableItemType(FileTablePaths f)
		{
			return new FileTableItemType(f);
		}

		public static implicit operator FileTableItemType(int i)
		{
			return new FileTableItemType(i);
		}

		public static implicit operator FileTableItemType(uint i)
		{
			return new FileTableItemType(i);
		}

		public Expansions AsExpansions
		{
			get
			{
				if (AsUint <= 0x80000000)
					return (Expansions)AsUint;
				else
					return Expansions.Custom;
			}
		}

		public FileTablePaths AsFileTablePaths
		{
			get
			{
				if (AsUint > 0x80000000)
					return (FileTablePaths)AsUint;
				else
					return FileTablePaths.Absolute;
			}
		}

		public uint AsUint { get; } = 0;

		public string GetRoot()
		{
			string ret = null;
			if (AsUint <= 0x80000000)
				ret = PathProvider.Global.GetExpansion(AsExpansions).InstallFolder;
			else if (this == FileTablePaths.SaveGameFolder)
				ret = PathProvider.SimSavegameFolder;
			else if (this == FileTablePaths.SimPEDataFolder)
				ret = Helper.SimPeDataPath;
			else if (this == FileTablePaths.SimPEFolder)
				ret = Helper.SimPePath;
			else if (this == FileTablePaths.SimPEPluginFolder)
				ret = Helper.SimPePluginPath;
			//            else ret = PathProvider.Global.GetExpansion(AsExpansions).InstallFolder;

			return ret;
		}

		public int GetEPVersion()
		{
			if (AsUint > 0x80000000)
				return -1;
			ExpansionItem ei = PathProvider.Global[AsExpansions];
			if (ei.Flag.Class == ExpansionItem.Classes.Story)
				return -1;
			return ei.Version;

			//return -1;
		}

		#region IComparable Member

		public int CompareTo(object obj)
		{
			if (obj is Expansions)
				return AsUint.CompareTo((uint)((Expansions)obj));
			if (obj is FileTablePaths)
				return AsUint.CompareTo((uint)((FileTablePaths)obj));
			if (obj is int)
				return AsUint.CompareTo((uint)((int)obj));
			if (obj is uint)
				return AsUint.CompareTo((uint)obj);
			if (obj is FileTableItemType)
				return AsUint.CompareTo(((FileTableItemType)obj).AsUint);

			return ((object)AsUint) == obj ? 0 : 1; // random objects are not equal
		}

		#endregion

		public override bool Equals(object obj)
		{
			int res = CompareTo(obj);
			return (res == 0);
			//return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return AsUint.GetHashCode();
		}

		public static bool operator ==(FileTableItemType a, Expansions b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(FileTableItemType a, Expansions b)
		{
			return !a.Equals(b);
		}

		public static bool operator ==(FileTableItemType a, FileTableItemType b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(FileTableItemType a, FileTableItemType b)
		{
			return !a.Equals(b);
		}

		public static bool operator ==(FileTableItemType a, FileTablePaths b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(FileTableItemType a, FileTablePaths b)
		{
			return !a.Equals(b);
		}

		public override string ToString()
		{
			if (AsUint > 0x80000000)
				return AsFileTablePaths.ToString();
			else
				return AsExpansions.ToString();
		}
	}
}
