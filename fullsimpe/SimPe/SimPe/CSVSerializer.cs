// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe
{
	/// <summary>
	/// This is the default descriptive Serializer
	/// </summary>
	public class CsvSerializer : AbstractSerializer
	{
		public CsvSerializer()
			: base() { }

		public override string Seperator => ",";

		public override string SaveStr(string val)
		{
			return val.Replace(",", ";").Replace("\n", " ");
		}

		public override string SubProperty(string name, string val)
		{
			if (val == null)
			{
				val = "";
			}

			return val;
		}

		public override string Property(string name, string val)
		{
			if (val == null)
			{
				val = "";
			}

			return SaveStr(val);
		}

		public override string NullProperty(string name)
		{
			return "NULL";
		}
	}
}
