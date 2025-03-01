// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Reflection;

namespace SimPe
{
	/// <summary>
	/// This is the default descriptive Serializer
	/// </summary>
	public class DescriptiveSerializer : AbstractSerializer
	{
		public DescriptiveSerializer()
			: base() { }

		public override string Seperator => ";";

		public override string SaveStr(string val)
		{
			return val.Replace(";", ",").Replace("{", "[").Replace("}", "]");
		}

		public override string SubProperty(string name, string val)
		{
			if (val == null)
			{
				val = "";
			}

			return name + "={" + val + "}";
		}

		public override string Property(string name, string val)
		{
			if (val == null)
			{
				val = "";
			}

			return name + "=" + SaveStr(val) + "";
		}

		public override string NullProperty(string name)
		{
			return Property(name, "NULL");
		}

		public override string SerializeHeader(object o, Type t, PropertyInfo[] ps)
		{
			return "";
		}

		public override string SerializeTGIHeader()
		{
			return "";
		}

		public override string ConcatHeader(string[] props)
		{
			return "";
		}
	}
}
