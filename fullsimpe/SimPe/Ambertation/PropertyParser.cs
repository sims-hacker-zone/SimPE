// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using System.Xml;

namespace Ambertation
{
	/// <summary>
	/// Read an XML Description File and create a List of available Properties
	/// </summary>
	public class PropertyParser
	{
		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="filename">Name of the File to parse</param>
		/// <remarks>If the File is not available, an empty
		/// Proprties hashtable will be returned!</remarks>
		public PropertyParser(string filename)
		{
			props = null;
			flname = filename;
		}

		string flname;
		protected Hashtable props;
		protected Hashtable enums;

		/// <summary>
		/// Return all known Properties
		/// </summary>
		public Hashtable Properties
		{
			get
			{
				if (props == null)
				{
					Load();
				}

				return props;
			}
		}

		/// <summary>
		/// Creat an object of a given type
		/// </summary>
		/// <param name="typename"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		protected virtual object BuildValue(string typename, string value)
		{
			object o = 0;

			if (typename == "int")
			{
				o = value == null ? 0 : (object)Convert.ToInt32(value);
			}
			else if (typename == "short")
			{
				o = value == null ? 0 : (object)Convert.ToInt16(value);
			}
			else if (typename == "bool")
			{
				o = value == null ? false : (object)(Convert.ToInt16(value) != 0);
			}
			else if (typename == "color")
			{
				o = value == null ? FloatColor.FromColor(System.Drawing.Color.Black) : (object)FloatColor.FromString(value);
			}
			else if ((typename == "float") || (typename == "transparence"))
			{
				o = value == null
					? 1.0
					: (object)Convert.ToDouble(
							value,
							System.Globalization.CultureInfo.InvariantCulture
						);
			}
			else if (
				(typename == "string")
				|| (typename == "txtrref")
				|| (typename == "guid")
				|| (typename == "vector2f")
				|| (typename == "vector3f")
			)
			{
				o = value == null ? "" : (object)value;
			}
			else if (typename.StartsWith("enum:"))
			{
				string[] parts = typename.Split(":".ToCharArray(), 2);
				typename = parts[1];

				if (enums.ContainsKey(typename))
				{
					Type t = (Type)enums[typename];
					o = value == null ? Enum.ToObject(t, t.GetFields()[0].GetValue(null)) : Enum.ToObject(t, Convert.ToInt32(value));
				}
				else
				{
					parts = typename.Split(",".ToCharArray(), 2);
					Assembly a = GetType().Assembly;
					if (parts.Length > 1)
					{
						a = Assembly.LoadFrom(parts[0]);
						typename = parts[1];
					}

					Type t = a.GetType(typename);
					if (t != null)
					{
						if (t.IsEnum)
						{
							o = value == null
								? Enum.ToObject(t, Convert.ToInt32(0))
								: Enum.ToObject(
									t,
									Convert.ToInt32(value)
								);
						}
					}
				}
			}
			else if (typename.StartsWith("class:"))
			{
				string[] parts = typename.Split(":".ToCharArray(), 2);
				typename = parts[1];

				parts = typename.Split(",".ToCharArray(), 2);
				Assembly a = GetType().Assembly;
				if (parts.Length > 1)
				{
					a = Assembly.LoadFrom(parts[0]);
					typename = parts[1];
				}

				Type t = a.GetType(typename);
				if (t != null)
				{
					if (
						t.GetInterface("Ambertation.IPropertyClass")
						== typeof(IPropertyClass)
					)
					{
						o = Activator.CreateInstance(
							t,
							new object[] { value }
						);
					}
				}
			}

			return o;
		}

		/// <summary>
		/// Read a Category Node
		/// </summary>
		/// <param name="node">the node that stores a category</param>
		protected virtual void HandleCategory(XmlNode node)
		{
			string cat = node.Attributes["name"].Value;
			foreach (XmlNode subnode in node)
			{
				if (subnode.Name == "property")
				{
					HandleProperty(subnode, cat);
				}
			}
		}

		/// <summary>
		/// Read additional Data
		/// </summary>
		/// <param name="node"></param>
		/// <param name="node"></param>
		/// <param name="pd"></param>
		protected virtual void HandleProperty(XmlNode node, PropertyDescription pd)
		{
		}

		/// <summary>
		/// Read a Property Node
		/// </summary>
		/// <param name="node">the node that stores the Propery</param>
		protected virtual void HandleProperty(XmlNode node, string cat)
		{
			object def = 0;
			string desc = null;
			string name = "Unknown";

			string typename = node.Attributes["type"].Value;
			def = BuildValue(typename, null);
			bool ro = false;

			foreach (XmlNode subnode in node)
			{
				if (subnode.Name == "name")
				{
					name = subnode.InnerText;
				}

				if (subnode.Name == "help")
				{
					desc = subnode.InnerText;
				}

				if (subnode.Name == "default")
				{
					def = BuildValue(typename, subnode.InnerText);
				}

				if (subnode.Name == "readonly")
				{
					ro = true;
				}
			}

			PropertyDescription pd = new PropertyDescription(cat, desc, def, ro);
			HandleProperty(node, pd);

			if (props.ContainsKey(name))
			{
				props[name] = pd;
			}
			else
			{
				props.Add(name, pd);
			}
		}

		/// <summary>
		/// Read a Enum Node
		/// </summary>
		/// <param name="node">the node that stores the Propery</param>
		protected virtual void HandleEnum(ModuleBuilder myModBuilder, XmlNode node)
		{
			string name = node.Attributes["name"].Value;

			// Create a dynamic Enum.
			EnumBuilder myEnumBuilder = myModBuilder.DefineEnum(
				"SimPe.Plugins.Dinamic.Enums." + name,
				TypeAttributes.Public,
				typeof(int)
			);

			foreach (XmlNode subnode in node)
			{
				if (subnode.Name == "field")
				{
					myEnumBuilder.DefineLiteral(
						subnode.InnerText,

							Convert.ToInt32(subnode.Attributes["value"].Value)
					);
				}
			}

			Type t = myEnumBuilder.CreateType();
			enums[name] = t;
		}

		/// <summary>
		/// Load the Properties from the File
		/// </summary>
		protected void Load()
		{
			AppDomain myDomain = Thread.GetDomain();
			AssemblyName myAsmName = new AssemblyName
			{
				Name = "SaveEmittedAssembly"
			};

			AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(
				myAsmName,
				AssemblyBuilderAccess.Run
			);

			// Create a dynamic module.
			ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule(
				"EmittedModule"
			);

			props = new Hashtable();
			enums = new Hashtable();
			if (!System.IO.File.Exists(flname))
			{
				return;
			}

			//read XML File
			XmlDocument xmlfile = new XmlDocument();
			xmlfile.Load(flname);

			//seek Root Node
			XmlNodeList XMLData = xmlfile.GetElementsByTagName("properties");

			//Process all Root Node Entries
			for (int i = 0; i < XMLData.Count; i++)
			{
				XmlNode node = XMLData.Item(i);
				foreach (XmlNode subnode in node)
				{
					if (subnode.Name == "property")
					{
						HandleProperty(subnode, (string)null);
					}

					if (subnode.Name == "category")
					{
						HandleCategory(subnode);
					}

					if (subnode.Name == "enum")
					{
						HandleEnum(myModBuilder, subnode);
					}
				}
			}
		}
	}
}
