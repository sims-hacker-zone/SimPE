/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace Ambertation
{
	/// <summary>
	/// Meta Descriptions for a Property
	/// </summary>
	public class PropertyDescription
	{
		/// <summary>
		/// The Description of the Property (=Help Text)
		/// </summary>
		public string Description
		{
			get;
		}

		/// <summary>
		/// The Category of the Property
		/// </summary>
		public string Category
		{
			get;
		}

		/// <summary>
		/// Tru iof this Property is ReadOnly
		/// </summary>
		public bool ReadOnly
		{
			get;
		}

		object prop;

		/// <summary>
		/// The Property (=Content)
		/// </summary>
		public object Property
		{
			get
			{
				if (
					prop.GetType() == typeof(byte)
					|| prop.GetType() == typeof(short)
					|| prop.GetType() == typeof(ushort)
					|| prop.GetType() == typeof(int)
					|| prop.GetType() == typeof(uint)
					|| prop.GetType() == typeof(long)
					|| prop.GetType() == typeof(ulong)
				)
				{
					return new BaseChangeableNumber(prop);
				}
				/*else if (prop.GetType()==typeof(Ambertation.FloatColor))
				{
					return ((FloatColor)prop).Color;
				}*/
				return prop;
			}
			set
			{
				if (value.GetType() == typeof(BaseChangeableNumber))
				{
					prop = ((BaseChangeableNumber)value).ObjectValue;
				}
				else
				{
					try
					{
						if (Type.IsEnum)
						{
							if (value.GetType() == typeof(int))
							{
								prop = Enum.ToObject(
									Type,
									Convert.ToInt32(value)
								);
							}
							/*else if (value.GetType()==typeof(uint))
	prop = System.Enum.ToObject(type, System.Convert.ToInt32(value));
else if (value.GetType()==typeof(short))
	prop = System.Enum.ToObject(type, System.Convert.ToInt32(value));
else if (value.GetType()==typeof(ushort))
	prop = System.Enum.ToObject(type, System.Convert.ToInt32(value));*/
							else
							{
								prop = Enum.ToObject(
									Type,
									Type.GetField(value.ToString()).GetValue(null)
								);
							}
						}
						else if (
							(Type == typeof(FloatColor))
							&& (value.GetType() == typeof(string))
						)
						{
							prop = FloatColor.FromString(value.ToString());
						}
						else if (
							(Type == typeof(FloatColor))
							&& (value.GetType() == typeof(Color))
						)
						{
							prop = FloatColor.FromColor((Color)value);
						}
						else if (
							Type.GetInterface("Ambertation.IPropertyClass")
							== typeof(IPropertyClass)
						)
						{
							prop = Activator.CreateInstance(
								Type,
								new object[] { value }
							);
						}
						else
						{
							prop = Convert.ChangeType(value, Type);
						}
					}
					catch
					{
						//this is a special Handle for Booleans
						if (Type == typeof(bool) && value.GetType() == typeof(string))
						{
							string s = (string)value;
							s = s.Trim();
							if (s == "0")
							{
								prop = false;
							}
							else
							{
								prop = true;
							}
						}
						else
						{
							prop = value;
							Type = value.GetType();
						}
					}
				}
			}
		}

		/// <summary>
		/// Returns the Type of the Object
		/// </summary>
		public Type Type
		{
			get; private set;
		}

		/// <summary>
		/// Creates a new Instance
		/// </summary>
		/// <param name="category"></param>
		/// <param name="description"></param>
		/// <param name="property"></param>
		public PropertyDescription(string category, string description, object property)
			: this(category, description, property, property.GetType(), false) { }

		/// <summary>
		/// Creates a new Instance
		/// </summary>
		/// <param name="category"></param>
		/// <param name="description"></param>
		/// <param name="property"></param>
		public PropertyDescription(
			string category,
			string description,
			object property,
			bool ro
		)
			: this(category, description, property, property.GetType(), ro) { }

		/// <summary>
		/// Creates a new Instance
		/// </summary>
		/// <param name="category"></param>
		/// <param name="description"></param>
		/// <param name="property"></param>
		/// <param name="type">type of the Object</param>
		/// <param name="ro">ReadOnly?</param>
		public PropertyDescription(
			string category,
			string description,
			object property,
			Type type,
			bool ro
		)
		{
			Description = description;
			Category = category;
			prop = property;
			ReadOnly = ro;
			Type = type;
		}

		/// <summary>
		/// Create a clone (this will NOT copy the property, but set it to null!!!)
		/// </summary>
		/// <returns>The cloned Object</returns>
		public PropertyDescription Clone()
		{
			return new PropertyDescription(Category, Description, null, Type, ReadOnly);
		}
	}

	/// <summary>
	/// Used to Dynamicaly create an Object Displayed in a PropertyGrid
	/// </summary>
	public class PropertyObjectBuilderExt
	{
		Type custDataType;
		Hashtable ht;

		public PropertyObjectBuilderExt(Hashtable ht)
		{
			this.ht = ht;
			AppDomain myDomain = Thread.GetDomain();
			AssemblyName myAsmName = new AssemblyName
			{
				Name = "EmittedAssembly"
			};

			AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(
				myAsmName,
				AssemblyBuilderAccess.Run
			);

			ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule(
				"EmittedModule"
			);

			TypeBuilder myTypeBuilder = myModBuilder.DefineType(
				"Ambertation",
				TypeAttributes.Public
			);

			//Add all properties
			foreach (string k in ht.Keys)
			{
				object o = ht[k];
				if (o.GetType() == typeof(PropertyDescription))
				{
					PropertyDescription pd = (PropertyDescription)o;
					o = pd.Property;
					if (o.GetType() == typeof(FloatColor))
					{
						o = ((FloatColor)o).Color;
					}

					AddProperty(
						k,
						myTypeBuilder,
						o,
						pd.Description,
						pd.Category,
						pd.ReadOnly
					);
				}
				else
				{
					AddProperty(k, myTypeBuilder, o, "[Unknown Property]", null, false);
				}
			}

			//Creat type and an Instance
			custDataType = myTypeBuilder.CreateType();
			Instance = Activator.CreateInstance(custDataType);

			foreach (string k in ht.Keys)
			{
				Object val = ht[k];

				if (val.GetType() == typeof(PropertyDescription))
				{
					PropertyDescription pd = (PropertyDescription)val;
					val = pd.Property;
					if (val.GetType() == typeof(FloatColor))
					{
						val = ((FloatColor)val).Color;
					}
				}

				custDataType.InvokeMember(
					k,
					BindingFlags.SetProperty,
					null,
					Instance,
					new object[] { val }
				);
			}
		}

		/// <summary>
		/// Add an Attribute
		/// </summary>
		/// <param name="custNamePropBldr"></param>
		/// <param name="attrType"></param>
		/// <param name="val"></param>
		internal static void AddAttribute(
			PropertyBuilder custNamePropBldr,
			Type attrType,
			string val
		)
		{
			ConstructorInfo classCtorCat = attrType.GetConstructor(
				new Type[] { typeof(string) }
			);
			CustomAttributeBuilder myCABuilder = new CustomAttributeBuilder(
				classCtorCat,
				new object[] { val }
			);
			custNamePropBldr.SetCustomAttribute(myCABuilder);
		}

		/// <summary>
		/// Add an Attribute
		/// </summary>
		/// <param name="custNamePropBldr"></param>
		/// <param name="attrType"></param>
		/// <param name="val"></param>
		internal static void AddAttribute(
			PropertyBuilder custNamePropBldr,
			Type attrType,
			bool val
		)
		{
			ConstructorInfo classCtorCat = attrType.GetConstructor(
				new Type[] { typeof(bool) }
			);
			CustomAttributeBuilder myCABuilder = new CustomAttributeBuilder(
				classCtorCat,
				new object[] { val }
			);
			custNamePropBldr.SetCustomAttribute(myCABuilder);
		}

		/// <summary>
		/// Add an Attribute
		/// </summary>
		/// <param name="custNamePropBldr"></param>
		/// <param name="attrType"></param>
		/// <param name="val"></param>
		internal static void AddAttribute(
			PropertyBuilder custNamePropBldr,
			Type attrType,
			object val,
			bool a
		)
		{
			ConstructorInfo classCtorCat = attrType.GetConstructor(
				new Type[] { val.GetType() }
			);
			CustomAttributeBuilder myCABuilder = new CustomAttributeBuilder(
				classCtorCat,
				new object[] { val }
			);
			custNamePropBldr.SetCustomAttribute(myCABuilder);
		}

		/// <summary>
		/// Add a Property To the new Type
		/// </summary>
		/// <param name="name">name of the Property</param>
		/// <param name="myTypeBuilder">The TypeBuidler Object</param>
		/// <param name="o">The default value for that Property</param>
		/// <param name="category">Category the Property is assigned to</param>
		/// <param name="description">Description for this Category</param>
		/// <param name="ro">true if this Item should be ReadOnly</param>
		public static void AddProperty(
			string name,
			TypeBuilder myTypeBuilder,
			object o,
			string description,
			string category,
			bool ro
		)
		{
			Type type = o.GetType();
			FieldBuilder customerNameBldr = myTypeBuilder.DefineField(
				"_" + name.ToLower(),
				type,
				FieldAttributes.Private
			);

			PropertyBuilder custNamePropBldr = myTypeBuilder.DefineProperty(
				name,
				PropertyAttributes.HasDefault,
				type,
				new Type[] { }
			);

			//Define Category-Attribute
			if (category != null)
			{
				if (category != "")
				{
					AddAttribute(custNamePropBldr, typeof(CategoryAttribute), category);
				}
			}

			//Define Description-Attribute
			if (description != null)
			{
				AddAttribute(
					custNamePropBldr,
					typeof(DescriptionAttribute),
					description
				);
			}

			AddAttribute(custNamePropBldr, typeof(ReadOnlyAttribute), ro);
			//AddAttribute(custNamePropBldr, typeof(DefaultValueAttribute), o, true);


			// First, we'll define the behavior of the "get" property for CustomerName as a method.
			MethodBuilder custNameGetPropMthdBldr = myTypeBuilder.DefineMethod(
				"Get" + name,
				MethodAttributes.Public,
				type,
				new Type[] { }
			);

			ILGenerator custNameGetIL = custNameGetPropMthdBldr.GetILGenerator();

			custNameGetIL.Emit(OpCodes.Ldarg_0);
			custNameGetIL.Emit(OpCodes.Ldfld, customerNameBldr);
			custNameGetIL.Emit(OpCodes.Ret);

			// Now, we'll define the behavior of the "set" property for CustomerName.
			MethodBuilder custNameSetPropMthdBldr = myTypeBuilder.DefineMethod(
				"Set" + name,
				MethodAttributes.Public,
				null,
				new Type[] { type }
			);

			ILGenerator custNameSetIL = custNameSetPropMthdBldr.GetILGenerator();

			custNameSetIL.Emit(OpCodes.Ldarg_0);
			custNameSetIL.Emit(OpCodes.Ldarg_1);
			custNameSetIL.Emit(OpCodes.Stfld, customerNameBldr);
			custNameSetIL.Emit(OpCodes.Ret);

			// Last, we must map the two methods created above to our PropertyBuilder to
			// their corresponding behaviors, "get" and "set" respectively.
			custNamePropBldr.SetGetMethod(custNameGetPropMthdBldr);
			custNamePropBldr.SetSetMethod(custNameSetPropMthdBldr);
		}

		/// <summary>
		/// All Properties stored in the object
		/// </summary>
		public Hashtable Properties
		{
			get
			{
				if (Instance == null)
				{
					return new Hashtable();
				}

				Hashtable ret = new Hashtable();
				foreach (string k in ht.Keys)
				{
					object val = custDataType.InvokeMember(
						k,
						BindingFlags.GetProperty,
						null,
						Instance,
						new object[] { }
					);

					if (val.GetType() == typeof(BaseChangeableNumber))
					{
						val = ((BaseChangeableNumber)val).ObjectValue;
					}
					else if (val is Color)
					{
						val = FloatColor.FromColor((Color)val);
					}

					ret[k] = val;
				}

				return ret;
			}
		}

		/// <summary>
		/// Returns the created Object
		/// </summary>
		public object Instance { get; } = null;
	}
}
