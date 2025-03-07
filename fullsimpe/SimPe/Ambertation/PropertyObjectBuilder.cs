// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace Ambertation
{
	/// <summary>
	/// This is a typeconverter for the special Short class
	/// </summary>
	public class HexTypeConverter : TypeConverter
	{
		public override bool CanConvertTo(
			ITypeDescriptorContext context,
			Type destinationType
		)
		{
			return destinationType == typeof(BaseChangeShort) || base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(
			ITypeDescriptorContext context,
			CultureInfo culture,
			object value,
			Type destinationType
		)
		{
			if (destinationType == typeof(string) && value is BaseChangeShort)
			{
				BaseChangeShort so = (BaseChangeShort)value;

				return so.ToString();
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override bool CanConvertFrom(
			ITypeDescriptorContext context,
			Type sourceType
		)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(
			ITypeDescriptorContext context,
			CultureInfo culture,
			object value
		)
		{
			if (value is string s)
			{
				try
				{
					return BaseChangeShort.Convert(s);
				}
				catch
				{
					throw new ArgumentException(
						"Can not convert '"
							+ (string)value
							+ "'. This is not a valid "
							+ BaseChangeShort.BaseName
							+ " Number!"
					);
				}
			}
			return base.ConvertFrom(context, culture, value);
		}
	}

	/// <summary>
	/// This is a class that can present short Values in diffrent Ways
	/// </summary>
	[
		TypeConverter(typeof(HexTypeConverter)),
		Description("This Values can be displayed in Dec, Hex and Bin")
	]
	public class BaseChangeShort
	{
		/// <summary>
		/// The Number Base used for Display
		/// </summary>
		public static int DigitBase { get; set; } = 16;

		/// <summary>
		/// Name of this Number Representation
		/// </summary>
		public static string BaseName
		{
			get
			{
				switch (DigitBase)
				{
					case 16:
						return "Hexadecimal";
					case 2:
						return "Binary";
					default:
						return "Decimal";
				}
			}
		}

		/// <summary>
		/// Converts a String Back to a type of this Class
		/// </summary>
		/// <param name="s">The string Representation</param>
		/// <returns>a new Instance</returns>
		public static BaseChangeShort Convert(string s)
		{
			s = s.Trim().ToLower();
			short val = s.StartsWith("0x")
				? System.Convert.ToInt16(s, 16)
				: s.StartsWith("b") ? System.Convert.ToInt16(s.Substring(1), 2) : System.Convert.ToInt16(s, 10);

			return new BaseChangeShort(val);
		}

		public BaseChangeShort(int v)
		{
			IntegerValue = v;
		}

		public BaseChangeShort(uint v)
		{
			IntegerValue = (int)v;
		}

		public BaseChangeShort(short v)
		{
			IntegerValue = v;
		}

		internal BaseChangeShort()
		{
			IntegerValue = 0;
		}

		/// <summary>
		/// The actual Value (as short)
		/// </summary>
		public short Value
		{
			get => (short)(IntegerValue & 0xffff);
			set => IntegerValue = (short)(value & 0xffff);
		}

		/// <summary>
		/// The actual Value (as Integer)
		/// </summary>
		public int IntegerValue
		{
			get; set;
		}

		/// <summary>
		/// Return the String Representation of the stored Value
		/// </summary>
		/// <returns>A String</returns>
		public override string ToString()
		{
			switch (DigitBase)
			{
				case 16:
					return "0x" + IntegerValue.ToString("x");
				case 2:
					return "b" + System.Convert.ToString(IntegerValue, 2);
				default:
					return IntegerValue.ToString();
			}
		}
	}

	/// <summary>
	/// Used to Dynamicaly create an Object Displayed in a PropertyGrid
	/// </summary>
	public class PropertyObjectBuilder
	{
		Type custDataType;
		Hashtable ht;

		public PropertyObjectBuilder(Hashtable ht)
		{
			this.ht = ht;
			AppDomain myDomain = Thread.GetDomain();
			AssemblyName myAsmName = new AssemblyName
			{
				Name = "MyDynamicAssembly"
			};

			AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(
				myAsmName,
				AssemblyBuilderAccess.Run
			);

			ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule("MyModule");

			TypeBuilder myTypeBuilder = myModBuilder.DefineType(
				"CustomerData",
				TypeAttributes.Public
			);

			//Add all properties
			foreach (string k in ht.Keys)
			{
				AddProperty(k, myTypeBuilder);
			}

			//Creat type and an Instance
			custDataType = myTypeBuilder.CreateType();
			Instance = Activator.CreateInstance(custDataType);

			foreach (string k in ht.Keys)
			{
				BaseChangeShort val = new BaseChangeShort((short)ht[k]);
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
		/// Add a Property To the new Type
		/// </summary>
		/// <param name="name">name of the Property</param>
		/// <param name="myTypeBuilder">The TypeBuidler Object</param>
		public static void AddProperty(string name, TypeBuilder myTypeBuilder)
		{
			FieldBuilder customerNameBldr = myTypeBuilder.DefineField(
				"_" + name.ToLower(),
				typeof(BaseChangeShort),
				FieldAttributes.Private
			);

			PropertyBuilder custNamePropBldr = myTypeBuilder.DefineProperty(
				name,
				PropertyAttributes.HasDefault,
				typeof(BaseChangeShort),
				new Type[] { typeof(BaseChangeShort) }
			);

			// First, we'll define the behavior of the "get" property for CustomerName as a method.
			MethodBuilder custNameGetPropMthdBldr = myTypeBuilder.DefineMethod(
				"Get" + name,
				MethodAttributes.Public,
				typeof(BaseChangeShort),
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
				new Type[] { typeof(BaseChangeShort) }
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
					BaseChangeShort val = (BaseChangeShort)
						custDataType.InvokeMember(
							k,
							BindingFlags.GetProperty,
							null,
							Instance,
							new object[] { }
						);
					ret[k] = val.Value;
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
