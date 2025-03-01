// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Xml;

using Ambertation;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Read an XML Description File and create a List of available Properties
	/// </summary>
	public class ObjdPropertyParser : PropertyParser
	{
		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="filename">Name of the File to parse</param>
		/// <remarks>If the File is not available, an empty
		/// Proprties hashtable will be returned!</remarks>
		public ObjdPropertyParser(string filename)
			: base(filename)
		{
			typemap = new Hashtable();
		}

		Hashtable typemap;

		public PropertyDescription GetDescriptor(ushort index)
		{
			if (props == null)
			{
				Load();
			}

			return (PropertyDescription)typemap[index];
		}

		/// <summary>
		/// Creat an object of a given type
		/// </summary>
		/// <param name="typename"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		protected override object BuildValue(string typename, string value)
		{
			return base.BuildValue(typename, value);
		}

		protected override void HandleProperty(XmlNode node, PropertyDescription pd)
		{
			base.HandleProperty(node, pd);

			foreach (XmlNode subnode in node)
			{
				if (subnode.Name == "index")
				{
					try
					{
						ushort index = Convert.ToUInt16(subnode.InnerText);
						if (!typemap.Contains(index))
						{
							typemap[index] = pd;
						}
					}
					catch { }
				}
			}
		}
	}
}
