// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

/*****************************************************************************/
/* from http://www.thecodeproject.com/cs/miscctrl/globalizedpropertygrid.asp */
/*****************************************************************************/

using System;
using System.ComponentModel;

namespace SimPe
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GlobalizedPropertyAttribute : Attribute
	{
		public GlobalizedPropertyAttribute(string name)
		{
			Name = name;
		}

		public string Name { get; set; } = "";

		public string Description { get; set; } = "";

		public string Table { get; set; } = "";
	}

	#region GlobalizedPropertyDescriptor

	/// <summary>
	/// GlobalizedPropertyDescriptor enhances the base class bay obtaining the display name for a property
	/// from the resource.
	/// </summary>
	public class GlobalizedPropertyDescriptor : PropertyDescriptor
	{
		protected System.Resources.ResourceManager resource;
		private PropertyDescriptor basePropertyDescriptor;
		private string localizedName = "";
		private string localizedDescription = "";
		private string localizedCategory = "";

		public GlobalizedPropertyDescriptor(
			System.Resources.ResourceManager resource,
			PropertyDescriptor basePropertyDescriptor
		)
			: base(basePropertyDescriptor)
		{
			this.resource = resource;
			this.basePropertyDescriptor = basePropertyDescriptor;
		}

		public override bool CanResetValue(object component)
		{
			return basePropertyDescriptor.CanResetValue(component);
		}

		public override Type ComponentType => basePropertyDescriptor.ComponentType;

		public override string DisplayName
		{
			get
			{
				// First lookup the property if GlobalizedPropertyAttribute instances are available.
				// If yes, then try to get resource table name and display name id from that attribute.
				string tableName = "";
				string displayName = "";
				foreach (Attribute oAttrib in basePropertyDescriptor.Attributes)
				{
					if (oAttrib.GetType().Equals(typeof(GlobalizedPropertyAttribute)))
					{
						displayName = ((GlobalizedPropertyAttribute)oAttrib).Name;
						tableName = ((GlobalizedPropertyAttribute)oAttrib).Table;
					}
				}

				// If no resource table specified by attribute, then build it itself by using namespace and class name.
				if (tableName.Length == 0)
				{
					tableName =
						basePropertyDescriptor.ComponentType.Namespace
						+ "."
						+ basePropertyDescriptor.ComponentType.Name;
				}

				// If no display name id is specified by attribute, then construct it by using default display name (usually the property name)
				if (displayName.Length == 0)
				{
					displayName = basePropertyDescriptor.DisplayName;
				}

				// Get the string from the resources.
				// If this fails, then use default display name (usually the property name)
				string s = resource.GetString("[Property:" + displayName + "]");
				localizedName = s ?? basePropertyDescriptor.DisplayName;

				return localizedName;
			}
		}
		public override string Category
		{
			get
			{
				// First lookup the property if there are GlobalizedPropertyAttribute instances
				// are available.
				// If yes, try to get resource table name and display name id from that attribute.
				string tableName = "";
				string displayName = "";
				foreach (Attribute oAttrib in basePropertyDescriptor.Attributes)
				{
					if (oAttrib.GetType().Equals(typeof(GlobalizedPropertyAttribute)))
					{
						displayName = (
							(GlobalizedPropertyAttribute)oAttrib
						).Description;
						tableName = ((GlobalizedPropertyAttribute)oAttrib).Table;
					}
				}

				// If no resource table specified by attribute, then build it itself by using namespace and class name.
				if (tableName.Length == 0)
				{
					tableName =
						basePropertyDescriptor.ComponentType.Namespace
						+ "."
						+ basePropertyDescriptor.ComponentType.Name;
				}

				// If no display name id is specified by attribute, then construct it by using default display name (usually the property name)
				if (displayName.Length == 0)
				{
					displayName = basePropertyDescriptor.Category;
				}

				// Get the string from the resources.
				// If this fails, then use default empty string indictating 'no description'
				string s = resource.GetString("[Category:" + displayName + "]");
				localizedCategory = s ?? "";

				return localizedCategory;
			}
		}

		public override string Description
		{
			get
			{
				// First lookup the property if there are GlobalizedPropertyAttribute instances
				// are available.
				// If yes, try to get resource table name and display name id from that attribute.
				string tableName = "";
				string displayName = "";
				foreach (Attribute oAttrib in basePropertyDescriptor.Attributes)
				{
					if (oAttrib.GetType().Equals(typeof(GlobalizedPropertyAttribute)))
					{
						displayName = (
							(GlobalizedPropertyAttribute)oAttrib
						).Description;
						tableName = ((GlobalizedPropertyAttribute)oAttrib).Table;
					}
				}

				// If no resource table specified by attribute, then build it itself by using namespace and class name.
				if (tableName.Length == 0)
				{
					tableName =
						basePropertyDescriptor.ComponentType.Namespace
						+ "."
						+ basePropertyDescriptor.ComponentType.Name;
				}

				// If no display name id is specified by attribute, then construct it by using default display name (usually the property name)
				if (displayName.Length == 0)
				{
					displayName = basePropertyDescriptor.DisplayName;
				}

				// Get the string from the resources.
				// If this fails, then use default empty string indictating 'no description'
				string s = resource.GetString("[Description:" + displayName + "]");
				localizedDescription = s ?? "";

				return localizedDescription;
			}
		}

		public override object GetValue(object component)
		{
			return basePropertyDescriptor.GetValue(component);
		}

		public override bool IsReadOnly => basePropertyDescriptor.IsReadOnly;

		public override string Name => basePropertyDescriptor.Name;

		public override Type PropertyType => basePropertyDescriptor.PropertyType;

		public override void ResetValue(object component)
		{
			basePropertyDescriptor.ResetValue(component);
		}

		public override bool ShouldSerializeValue(object component)
		{
			return basePropertyDescriptor.ShouldSerializeValue(component);
		}

		public override void SetValue(object component, object value)
		{
			basePropertyDescriptor.SetValue(component, value);
		}
	}
	#endregion

	#region GlobalizedObject

	/// <summary>
	/// GlobalizedObject implements ICustomTypeDescriptor to enable
	/// required functionality to describe a type (class).<br></br>
	/// The main task of this class is to instantiate our own property descriptor
	/// of type GlobalizedPropertyDescriptor.
	/// </summary>
	public class GlobalizedObject : ICustomTypeDescriptor
	{
		System.Resources.ResourceManager resource;

		public GlobalizedObject()
			: this(Localization.Manager) { }

		public GlobalizedObject(System.Resources.ResourceManager resource)
			: base()
		{
			this.resource = resource;
		}

		private PropertyDescriptorCollection globalizedProps;

		public string GetClassName()
		{
			return TypeDescriptor.GetClassName(this, true);
		}

		public AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, true);
		}

		public string GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, true);
		}

		public TypeConverter GetConverter()
		{
			return TypeDescriptor.GetConverter(this, true);
		}

		public EventDescriptor GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this, true);
		}

		public PropertyDescriptor GetDefaultProperty()
		{
			return TypeDescriptor.GetDefaultProperty(this, true);
		}

		public object GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this, attributes, true);
		}

		public EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(this, true);
		}

		/// <summary>
		/// Called to get the properties of a type.
		/// </summary>
		/// <param name="attributes"></param>
		/// <returns></returns>
		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			if (globalizedProps == null)
			{
				// Get the collection of properties
				PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(
					this,
					attributes,
					true
				);

				globalizedProps = new PropertyDescriptorCollection(null);

				// For each property use a property descriptor of our own that is able to be globalized
				foreach (PropertyDescriptor oProp in baseProps)
				{
					globalizedProps.Add(
						new GlobalizedPropertyDescriptor(resource, oProp)
					);
				}
			}
			return globalizedProps;
		}

		public PropertyDescriptorCollection GetProperties()
		{
			// Only do once
			if (globalizedProps == null)
			{
				// Get the collection of properties
				PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(
					this,
					true
				);
				globalizedProps = new PropertyDescriptorCollection(null);

				// For each property use a property descriptor of our own that is able to be globalized
				foreach (PropertyDescriptor oProp in baseProps)
				{
					globalizedProps.Add(
						new GlobalizedPropertyDescriptor(resource, oProp)
					);
				}
			}
			return globalizedProps;
		}

		public object GetPropertyOwner(PropertyDescriptor pd)
		{
			return this;
		}
	}

	#endregion
}
