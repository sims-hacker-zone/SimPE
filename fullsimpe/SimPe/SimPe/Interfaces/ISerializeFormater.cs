// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Reflection;

namespace SimPe.Interfaces
{
	/// <summary>
	/// This defines Methods that a concrete Serializer has to implement
	/// </summary>
	public interface ISerializeFormater
	{
		string Seperator
		{
			get;
		}

		string SaveStr(string val);

		/// <summary>
		/// Format a SubProerty of the Object (a Property that contains another serializable Object)
		/// </summary>
		/// <param name="name">Name of the Property</param>
		/// <param name="val">Value of the Property</param>
		/// <returns></returns>
		string SubProperty(string name, string val);

		/// <summary>
		/// Format a Property of the Object (a Peroperty that does not contain a serializable Object
		/// </summary>
		/// <param name="name"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		string Property(string name, string val);

		/// <summary>
		/// Format a Property with the Value null
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		string NullProperty(string name);

		/// <summary>
		/// Serialize the passed Object of the given Type with the given List of Properties
		/// </summary>
		/// <param name="o"></param>
		/// <param name="t"></param>
		/// <param name="ps"></param>
		/// <returns></returns>
		string Serialize(object o, Type t, PropertyInfo[] ps);

		/// <summary>
		/// Serialize the passed Header Information for the passed Object
		/// </summary>
		/// <param name="o"></param>
		/// <param name="t"></param>
		/// <param name="ps"></param>
		/// <returns></returns>
		string SerializeHeader(object o, Type t, PropertyInfo[] ps);

		/// <summary>
		/// Serializes the given Wrapper,Descriptor Information
		/// </summary>
		/// <param name="wrapper"></param>
		/// <param name="pfd"></param>
		/// <returns></returns>
		string SerializeTGI(
			Plugin.Internal.IPackedFileName wrapper,
			Files.IPackedFileDescriptorBasic pfd
		);

		string SerializeTGIHeader();

		string Concat(string[] props);

		string ConcatHeader(string[] props);
	}
}
