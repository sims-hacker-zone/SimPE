// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Reflection;

namespace SimPe
{
	/// <summary>
	/// Provides Methods to serialize Object Properties
	/// </summary>
	public class Serializer
	{
		#region Formater
		static Interfaces.ISerializeFormater formater;
		public static Interfaces.ISerializeFormater Formater
		{
			get
			{
				if (formater == null)
				{
					ResetFormater();
				}

				return formater;
			}
			set => formater = value;
		}

		public static void ResetFormater()
		{
			formater = new DescriptiveSerializer();
		}
		#endregion

		/*public virtual object[] GetDescriptionData()
		{
			return new object[0];
		}

		public virtual string GetDescriptionHeader()
		{

			object[] elements = GetDescriptionData();

			string s = "";
			foreach (string[] data in elements)
			{
				if (s!="") s += Seperator;
				if (data.Length==2)
				{
					s += data[0];
				} else s += " ";
			}
			return s;
		}


		public virtual string GetDescription()
		{

			object[] elements = GetDescriptionData();

			string s = "";
			foreach (string[] data in elements)
			{
				if (s!="") s += Seperator;
				if (data.Length==1)
				{
					s += data[0];
				}
				else if (data.Length==2)
				{
					s += Property(data[0], data[1]);
				}
				else
				{
					s += " ";
				}
			}
			return s;
		}*/


		public virtual string GetPropertyDescription()
		{
			return Serialize(this);
		}

		public override string ToString()
		{
			return ToString(GetType().Name);
		}

		public string ToString(string name)
		{
			return SubProperty(name, GetPropertyDescription());
		}

		static string SaveStr(string val)
		{
			return Formater.SaveStr(val);
		}

		public static string SubProperty(string name, string val)
		{
			return Formater.SubProperty(name, val);
		}

		public static string Property(string name, string val)
		{
			return Formater.Property(name, val);
		}

		public static string Seperator => Formater.Seperator;

		public static string SerializeTypeHeader(object o)
		{
			if (o == null)
			{
				return "";
			}

			Type t = o.GetType();
			PropertyInfo[] ps = t.GetProperties();

			string s = "";
			s += Formater.SerializeHeader(o, t, ps);

			return s;
		}

		public static string SerializeTypeHeader(
			Interfaces.Plugin.Internal.IPackedFileName wrapper,
			Interfaces.Files.IPackedFileDescriptorBasic pfd
		)
		{
			return SerializeTypeHeader(wrapper, pfd, true);
		}

		public static string SerializeTypeHeader(
			Interfaces.Plugin.Internal.IPackedFileName wrapper,
			Interfaces.Files.IPackedFileDescriptorBasic pfd,
			bool withdesc
		)
		{
			string s = "";
			s += Formater.SerializeTGIHeader();

			if (withdesc && wrapper != null)
			{
				s += wrapper.DescriptionHeader;
			}

			return s;
		}

		public static string Serialize(
			Interfaces.Plugin.Internal.IPackedFileName wrapper,
			Interfaces.Files.IPackedFileDescriptorBasic pfd
		)
		{
			return Serialize(wrapper, pfd, false);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="wrapper"></param>
		/// <param name="pfd"></param>
		/// <param name="withdesc">true, if you want to include the Description of the DAta stored in the passed Wrapper</param>
		/// <returns></returns>
		public static string Serialize(
			Interfaces.Plugin.Internal.IPackedFileName wrapper,
			Interfaces.Files.IPackedFileDescriptorBasic pfd,
			bool withdesc
		)
		{
			string s = Formater.SerializeTGI(wrapper, pfd);
			if (withdesc)
			{
				if (wrapper != null)
				{
					s += wrapper.Description;
				}

				s += Seperator;
			}

			return s;
		}

		public static string Serialize(object o)
		{
			return Serialize(o, false);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="o"></param>
		/// <param name="writeheader">true, if a descriptive Header should be written</param>
		/// <returns></returns>
		public static string Serialize(object o, bool writeheader)
		{
			if (o == null)
			{
				return "";
			}

			Type t = o.GetType();
			PropertyInfo[] ps = t.GetProperties();

			string s = "";
			if (writeheader)
			{
				s += Formater.SerializeHeader(o, t, ps);
			}

			s += Formater.Serialize(o, t, ps);
			return s;
		}

		public static string[] ConvertArrayList(System.Collections.ArrayList list)
		{
			string[] ret = new string[list.Count];
			list.CopyTo(ret);
			return ret;
		}

		public static string Concat(string[] props)
		{
			return Formater.Concat(props);
		}

		public static string ConcatHeader(string[] props)
		{
			return Formater.ConcatHeader(props);
		}
	}
}
