// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Data;
using System.Reflection;
using Ambertation.XSI.Template;

namespace Ambertation.XSI
{
	public sealed class TemplateRegistry
	{
		private static TemplateRegistry reg;

		private Hashtable map;

		private Type generictemplate;

		public static TemplateRegistry Global
		{
			get
			{
				if (reg == null)
				{
					reg = new TemplateRegistry();
				}

				return reg;
			}
		}

		private TemplateRegistry()
		{
			map = new Hashtable();
			generictemplate = typeof(Container);
			RegisterTemplate(typeof(Ambience));
			RegisterTemplate(typeof(Angle));
			RegisterTemplate(typeof(Camera));
			RegisterTemplate(typeof(Cluster));
			RegisterTemplate(typeof(Constraint));
			RegisterTemplate(typeof(CoordinateSystem));
			RegisterTemplate(typeof(Envelope));
			RegisterTemplate(typeof(EnvelopeList));
			RegisterTemplate(typeof(FileInfo));
			RegisterTemplate(typeof(GlobalMaterial));
			RegisterTemplate(typeof(Light));
			RegisterTemplate(typeof(Material));
			RegisterTemplate(typeof(MaterialLibrary));
			RegisterTemplate(typeof(Mesh));
			RegisterTemplate(typeof(Model));
			RegisterTemplate(typeof(Null));
			RegisterTemplate(typeof(Scene));
			RegisterTemplate(typeof(Shape));
			RegisterTemplate(typeof(Texture2D));
			RegisterTemplate(typeof(Transform));
			RegisterTemplate(typeof(TriangleList));
			RegisterTemplate(typeof(Visibility));
		}

		public bool RegisterTemplate(Type template)
		{
			return RegisterTemplate(template, "SI_" + template.Name);
		}

		public bool RegisterTemplate(Type template, string name)
		{
			if (name == null)
			{
				return false;
			}

			if (template.IsAbstract || template.IsInterface)
			{
				return false;
			}

			if ((object)template.GetInterface(typeof(ITemplate).Namespace + "." + typeof(ITemplate).Name) == null)
			{
				return false;
			}

			name = name.Trim();
			if (map.ContainsKey(name))
			{
				return false;
			}

			map[name] = template;
			return true;
		}

		internal Container ActivateTemplateClass(Container parent, string name)
		{
			string[] array = name.Split(' ');
			string text = name;
			if (array.Length > 1)
			{
				text = array[0];
			}

			text = text.Trim();
			object obj = map[text];
			Type t = generictemplate;
			if (obj != null)
			{
				t = obj as Type;
			}

			return ActivateTemplateClass(parent, name, t);
		}

		private Container ActivateTemplateClass(Container parent, string name, Type t)
		{
			ConstructorInfo constructor = t.GetConstructor(new Type[2]
			{
			typeof(Container),
			typeof(string)
			});
			if ((object)constructor != null)
			{
				return (Container)Activator.CreateInstance(t, parent, name);
			}

			constructor = t.GetConstructor(new Type[2]
			{
			typeof(string),
			typeof(Container)
			});
			if ((object)constructor != null)
			{
				return (Container)Activator.CreateInstance(t, name, parent);
			}

			constructor = t.GetConstructor(new Type[0]);
			if ((object)constructor != null)
			{
				return (Container)Activator.CreateInstance(t, new object[0]);
			}

			return null;
		}
	}
}
