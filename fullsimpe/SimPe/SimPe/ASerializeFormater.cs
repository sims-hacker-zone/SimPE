// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Reflection;

using SimPe.Interfaces.Plugin.Internal;

namespace SimPe
{
	/// <summary>
	/// This is the default descriptive Serializer
	/// </summary>
	public abstract class AbstractSerializer : Interfaces.ISerializeFormater
	{
		public abstract string Seperator
		{
			get;
		}

		public abstract string SaveStr(string val);

		/// <summary>
		/// Format a SubProerty of the Object (a Property that contains another serializable Object)
		/// </summary>
		/// <param name="name">Name of the Property</param>
		/// <param name="val">Value of the Property</param>
		/// <returns></returns>
		public abstract string SubProperty(string name, string val);

		/// <summary>
		/// Format a Property of the Object (a Peroperty that does not contain a serializable Object
		/// </summary>
		/// <param name="name"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		public abstract string Property(string name, string val);

		/// <summary>
		/// Format a Property with the Value null
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public abstract string NullProperty(string name);

		public virtual string SerializeTGIHeader()
		{
			return "Name"
				+ Seperator
				+ "Type"
				+ Seperator
				+ "Group"
				+ Seperator
				+ "InstanceHi"
				+ Seperator
				+ "Instance"
				+ Seperator;
		}

		public virtual string SerializeHeader(object o, Type t, PropertyInfo[] ps)
		{
			string s = "";

			foreach (PropertyInfo p in ps)
			{
				if (!p.CanRead)
				{
					continue;
				}

				try
				{
					if (s != "")
					{
						s += Seperator;
					}

					s += p.Name;

					object v = p.GetValue(o, null);
					string ss = "";
					if (v is IPackedFileName)
					{
						ss = ((IPackedFileName)v).DescriptionHeader;
						s += ss;
					}
					if ((v is Serializer) && ss == "")
					{
						s += Serializer.SerializeTypeHeader(v);
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(ex);
				}
				finally { }
			}
			return s;
		}

		public virtual string Serialize(object o, Type t, PropertyInfo[] ps)
		{
			string s = "";
			foreach (PropertyInfo p in ps)
			{
				if (!p.CanRead)
				{
					continue;
				}

				try
				{
					if (s != "")
					{
						s += Seperator;
					}

					object v = p.GetValue(o, null);
					if (v == null)
					{
						s += NullProperty(p.Name);
					}

					if (v is Serializer)
					{
						s += ((Serializer)v).ToString(p.Name);
					}
					else
					{
						s += Property(p.Name, v.ToString());
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(ex);
				}
				finally { }
			}

			return s;
		}

		public virtual string SerializeTGI(
			IPackedFileName wrapper,
			Interfaces.Files.IPackedFileDescriptorBasic pfd
		)
		{
			string s = "";
			if (wrapper != null)
			{
				s += SaveStr(wrapper.ResourceName) + Seperator;
			}
			else
			{
				s += SaveStr(pfd.TypeName.ToString()) + Seperator;
			}

			s += "0x" + Helper.HexString(pfd.Type) + Seperator;
			s += "0x" + Helper.HexString(pfd.Group) + Seperator;
			s += "0x" + Helper.HexString(pfd.SubType) + Seperator;
			s += "0x" + Helper.HexString(pfd.Instance) + Seperator;

			return s;
		}

		public virtual string Concat(string[] props)
		{
			string s = "";
			foreach (string p in props)
			{
				if (s != "")
				{
					s += Seperator;
				}

				s += p;
			}
			return s;
		}

		public virtual string ConcatHeader(string[] props)
		{
			return Concat(props);
		}
	}
}
