// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Xml;

namespace SimPe
{
	/// <summary>
	/// Represents one Key in the XML Registry
	/// </summary>
	public class XmlRegistryKey
	{
		Hashtable tree;

		/// <summary>
		/// Returns the Name of this Key
		/// </summary>
		public string Name
		{
			get; private set;
		}

		/// <summary>
		/// Create a new Instance
		/// </summary>
		internal XmlRegistryKey()
		{
			tree = new Hashtable();
		}

		#region SubKey Management
		/// <summary>
		/// Returns the complete Path to the specified SubKey
		/// </summary>
		/// <param name="key">The Key in Path Form</param>
		/// <returns>list of all SubKeys</returns>
		string[] GetPath(string key)
		{
			string[] res = key.Split("\\".ToCharArray());
			return res;
		}

		/// <summary>
		/// Add a new SubKey
		/// </summary>
		/// <param name="name">Name of the SubKey</param>
		/// <returns>the created SubKey</returns>
		public XmlRegistryKey CreateSubKey(string name)
		{
			XmlRegistryKey xrk = OpenSubKey(name, true);
			return xrk;
		}

		/// <summary>
		/// Open the SubKey with the given Name
		/// </summary>
		/// <param name="name">Name of the Key</param>
		/// <param name="create">create it if it does not exist</param>
		/// <returns>the opened/created subKey (null if created is false and the key does not exist)</returns>
		/// <exception cref="Exception">Thrown if the passed Element is not a Key but a value</exception>
		XmlRegistryKey OpenLocalSubKey(string name, bool create)
		{
			if (tree.ContainsKey(name))
			{
				object o = tree[name];
				if (o != null)
				{
					if (o.GetType() != typeof(XmlRegistryKey))
					{
						throw new Exception(
							"The SubElement " + name + " is not a Key!"
						);
					}
				}

				return (XmlRegistryKey)o;
			}

			if (create)
			{
				XmlRegistryKey xrk = new XmlRegistryKey
				{
					Name = name
				};
				tree[name] = xrk;
				return CreateSubKey(name);
			}

			return null;
		}

		/// <summary>
		/// Open the SubKey with the given Name
		/// </summary>
		/// <param name="name">Name of the Key</param>
		/// <param name="create">create it if it does not exist</param>
		/// <returns>the opened/created subKey (null if created is false and the key does not exist)</returns>
		/// <exception cref="Exception">Thrown if the passed Element is not a Key but a value</exception>
		public XmlRegistryKey OpenSubKey(string name, bool create)
		{
			return OpenSubKey(GetPath(name), create);
		}

		/// <summary>
		/// Open the SubKey with the given Name
		/// </summary>
		/// <param name="name">Name of the Key</param>
		/// <param name="create">create it if it does not exist</param>
		/// <returns>the opened/created subKey (null if created is false and the key does not exist)</returns>
		/// <exception cref="Exception">Thrown if the passed Element is not a Key but a value</exception>
		XmlRegistryKey OpenSubKey(string[] path, bool create)
		{
			XmlRegistryKey key = this;

			string curkey = "";
			for (int i = 0; i < path.Length; i++)
			{
				key = key.OpenLocalSubKey(path[i], create);
				curkey += "\\" + path[i];
				if (key == null)
				{
					return null; //throw new Exception("The Key "+curkey+" was not found!");
				}
			}

			return key;
		}

		/// <summary>
		/// Remove a SubKey
		/// </summary>
		/// <param name="name"></param>
		/// <param name="throwOnException"></param>
		public void DeleteSubKey(string name, bool throwOnException)
		{
			DeleteSubKey(GetPath(name), throwOnException);
		}

		/// <summary>
		/// Remove a SubKey
		/// </summary>
		/// <param name="path"></param>
		/// <param name="throwOnException"></param>
		void DeleteSubKey(string[] path, bool throwOnException)
		{
			if (path.Length < 1)
			{
				return;
			}

			XmlRegistryKey key = this;

			string curkey = "";
			for (int i = 0; i < path.Length - 1; i++)
			{
				key = key.OpenLocalSubKey(path[i], false);
				curkey += "\\" + path[i];
				if (key == null)
				{
					if (throwOnException)
					{
						throw new Exception("The Key " + curkey + " was not found!");
					}
					else
					{
						return;
					}
				}
			}

			string name = path[path.Length - 1];
			if (!key.tree.Contains(name) && throwOnException)
			{
				throw new Exception("The Key " + curkey + " was not found!");
			}

			if (key.tree.Contains(name))
			{
				key.tree.Remove(name);
			}
		}
		#endregion

		#region values
		/// <summary>
		/// Set a value
		/// </summary>
		/// <param name="name">Name of the value</param>
		/// <param name="o">the value</param>
		public void SetValue(string name, object o)
		{
			tree[name] = o;
		}

		/// <summary>
		/// Returns the value stored in the passed Element
		/// </summary>
		/// <param name="name">name of the Value</param>
		/// <returns>null or the stored value</returns>
		/// <exception cref="Exception">Thrown if the specified Value is a SubKey</exception>
		public object GetValue(string name)
		{
			return GetValue(name, null);
		}

		/// <summary>
		/// Returns the value stored in the passed Element
		/// </summary>
		/// <param name="name">name of the Value</param>
		/// <param name="def">Default Value</param>
		/// <returns>null or the stored value</returns>
		/// <exception cref="Exception">Thrown if the specified Value is a SubKey</exception>
		public object GetValue(string name, object def)
		{
			object o = tree[name];
			if (def != null && o == null)
			{
				o = def;
			}

			if (o != null)
			{
				if (o.GetType() == typeof(XmlRegistryKey))
				{
					throw new Exception("The SubElement " + name + " is a Key!");
				}
			}

			return o;
		}
		#endregion

		/// <summary>
		/// returns a list of names for all SubKeys
		/// </summary>
		/// <returns></returns>
		public string[] GetSubKeyNames()
		{
			ArrayList l = new ArrayList();

			foreach (string s in tree.Keys)
			{
				if (tree[s] is XmlRegistryKey)
				{
					l.Add(s);
				}
			}

			string[] res = new string[l.Count];
			l.CopyTo(res);
			return res;
		}

		/// <summary>
		/// returns a list of names for all Values
		/// </summary>
		/// <returns></returns>
		public string[] GetValueNames()
		{
			ArrayList l = new ArrayList();

			foreach (string s in tree.Keys)
			{
				if (!(tree[s] is XmlRegistryKey))
				{
					l.Add(s);
				}
			}

			string[] res = new string[l.Count];
			l.CopyTo(res);
			return res;
		}
	}

	/// <summary>
	/// This is a Platform independent Replacement for the <see cref="Microsoft.Win32.Registry"/> Class
	/// </summary>
	public class XmlRegistry
	{
		string filename;

		/// <summary>
		/// Returns the CurrentUser Registry Key
		/// </summary>
		public XmlRegistryKey CurrentUser
		{
			get;
		}

		/// <summary>
		/// Load the Registry from the passed File
		/// </summary>
		/// <param name="xmlfilename">Name of the Registry</param>
		/// <param name="create">true, if you want to create the File if it does not exist</param>
		public XmlRegistry(string infilename, string outfilename, bool create)
		{
			CurrentUser = new XmlRegistryKey();
			if (create)
			{
				if (
					!System.IO.Directory.Exists(
						System.IO.Path.GetDirectoryName(outfilename)
					)
				)
				{
					System.IO.Directory.CreateDirectory(
						System.IO.Path.GetDirectoryName(outfilename)
					);
				}

				if (!System.IO.File.Exists(outfilename))
				{
					Flush(outfilename);
				}
			}

			filename = outfilename;

			//read XML File
			XmlDocument xmlfile = new XmlDocument();
			xmlfile.Load(infilename);

			//seek Root Node
			XmlNodeList XMLData = xmlfile.GetElementsByTagName("registry");

			//Process all Root Node Entries
			for (int i = 0; i < XMLData.Count; i++)
			{
				XmlNode node = XMLData.Item(i);
				ParseSubNode(node, CurrentUser);
			}
		}

		/// <summary>
		/// Parse the passed Values
		/// </summary>
		/// <param name="subnode"></param>
		/// <param name="subkey"></param>
		void ParseValues(XmlNode subnode, XmlRegistryKey subkey)
		{
			if (subnode.Name == "string")
			{
				ParseStringValue(subnode, subkey);
			}

			if (subnode.Name == "int")
			{
				ParseIntValue(subnode, subkey);
			}

			if (subnode.Name == "uint")
			{
				ParseUIntValue(subnode, subkey);
			}

			if (subnode.Name == "long")
			{
				ParseLongValue(subnode, subkey);
			}

			if (subnode.Name == "ulong")
			{
				ParseULongValue(subnode, subkey);
			}

			if (subnode.Name == "bool")
			{
				ParseBoolValue(subnode, subkey);
			}

			if (subnode.Name == "float")
			{
				ParseFloatValue(subnode, subkey);
			}

			if (subnode.Name == "datetime")
			{
				ParseDateTimeValue(subnode, subkey);
			}
		}

		/// <summary>
		/// Parse a certain SubNode Level of the XML File
		/// </summary>
		/// <param name="node">The current Node</param>
		/// <param name="key">The current SubTree</param>
		void ParseSubNode(XmlNode node, XmlRegistryKey key)
		{
			XmlRegistryKey subkey = key;

			//Remember the Name of the Node
			if (node.Name == "key")
			{
				subkey = key.CreateSubKey(node.Attributes["name"].Value);
			}

			foreach (XmlNode subnode in node)
			{
				if (subnode.Name == "key")
				{
					ParseSubNode(subnode, subkey);
				}

				ParseValues(subnode, subkey);
				if (subnode.Name == "list")
				{
					ParseListNode(subnode, subkey, false);
				}

				if (subnode.Name == "cilist")
				{
					ParseListNode(subnode, subkey, true);
				}
			}
		}

		/// <summary>
		/// Parse a certain SubNode Level of the XML File
		/// </summary>
		/// <param name="node">The current Node</param>
		/// <param name="key">The current SubTree</param>
		/// <param name="caseinvariant">true if you want a case Invariant List</param>
		void ParseListNode(XmlNode node, XmlRegistryKey key, bool caseinvariant)
		{
			XmlRegistryKey subkey = new XmlRegistryKey();
			ArrayList names = new ArrayList();
			foreach (XmlNode subnode in node)
			{
				if (subnode.Attributes == null)
				{
					continue;
				}

				names.Add(subnode.Attributes["name"].Value);
				ParseValues(subnode, subkey);
			}

			ArrayList list = !caseinvariant ? new ArrayList() : new Ambertation.CaseInvariantArrayList();

			foreach (string s in names)
			{
				list.Add(subkey.GetValue(s));
			}

			key.SetValue(node.Attributes["name"].Value, list);
		}

		#region Parse Values
		/// <summary>
		/// Add an Date Value
		/// </summary>
		/// <param name="node">The current Node</param>
		/// <param name="key">The current SubTree</param>
		void ParseDateTimeValue(XmlNode node, XmlRegistryKey key)
		{
			DateTime val = DateTime.Now;
			try
			{
				val = Convert.ToDateTime(node.InnerText);
			}
			catch { }
			key.SetValue(node.Attributes["name"].Value, val);
		}

		/// <summary>
		/// Add an Integer Value
		/// </summary>
		/// <param name="node">The current Node</param>
		/// <param name="key">The current SubTree</param>
		void ParseIntValue(XmlNode node, XmlRegistryKey key)
		{
			int val = 0;
			try
			{
				val = Convert.ToInt32(node.InnerText);
			}
			catch { }
			key.SetValue(node.Attributes["name"].Value, val);
		}

		/// <summary>
		/// Add an Integer Value
		/// </summary>
		/// <param name="node">The current Node</param>
		/// <param name="key">The current SubTree</param>
		void ParseUIntValue(XmlNode node, XmlRegistryKey key)
		{
			uint val = 0;
			try
			{
				val = Convert.ToUInt32(node.InnerText);
			}
			catch { }
			key.SetValue(node.Attributes["name"].Value, val);
		}

		/// <summary>
		/// Add an LongInteger Value
		/// </summary>
		/// <param name="node">The current Node</param>
		/// <param name="key">The current SubTree</param>
		void ParseLongValue(XmlNode node, XmlRegistryKey key)
		{
			long val = 0;
			try
			{
				val = Convert.ToInt64(node.InnerText);
			}
			catch { }
			key.SetValue(node.Attributes["name"].Value, val);
		}

		/// <summary>
		/// Add an LongInteger Value
		/// </summary>
		/// <param name="node">The current Node</param>
		/// <param name="key">The current SubTree</param>
		void ParseULongValue(XmlNode node, XmlRegistryKey key)
		{
			ulong val = 0;
			try
			{
				val = Convert.ToUInt64(node.InnerText);
			}
			catch { }
			key.SetValue(node.Attributes["name"].Value, val);
		}

		/// <summary>
		/// Add an Float Value
		/// </summary>
		/// <param name="node">The current Node</param>
		/// <param name="key">The current SubTree</param>
		void ParseFloatValue(XmlNode node, XmlRegistryKey key)
		{
			float val = 0;
			try
			{
				val = Convert.ToSingle(node.InnerText);
			}
			catch { }
			key.SetValue(node.Attributes["name"].Value, val);
		}

		/// <summary>
		/// Add an Boolean Value
		/// </summary>
		/// <param name="node">The current Node</param>
		/// <param name="key">The current SubTree</param>
		void ParseBoolValue(XmlNode node, XmlRegistryKey key)
		{
			bool val = false;
			try
			{
				string s = node.InnerText.Trim().ToLower();
				val = s != "false" && s != "no" && s != "off" && s != "0";
			}
			catch { }
			key.SetValue(node.Attributes["name"].Value, val);
		}

		/// <summary>
		/// Add an String Value
		/// </summary>
		/// <param name="node">The current Node</param>
		/// <param name="key">The current SubTree</param>
		void ParseStringValue(XmlNode node, XmlRegistryKey key)
		{
			string val = node.InnerText;
			key.SetValue(node.Attributes["name"].Value, val);
		}
		#endregion

		#region writing
		/// <summary>
		/// Write changes to the File
		/// </summary>
		public void Flush()
		{
			Flush(filename);
		}

		/// <summary>
		/// Write changes to the File
		/// </summary>
		/// <param name="filename">The name of the File you want to flush to</param>
		void Flush(string filename)
		{
			try
			{
				string dir = System.IO.Path.GetDirectoryName(filename);
				if (!System.IO.Directory.Exists(dir))
				{
					throw new Exception("Directory \"" + dir + "\"not found!");
				}

				System.IO.StreamWriter sw = System.IO.File.CreateText(filename);

				try
				{
					//root.CreateSubKey("META").SetValue("Version", (int)1);
					sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
					sw.WriteLine("<registry>");

					WriteKey(sw, CurrentUser);

					sw.WriteLine("</registry>");
				}
				finally
				{
					sw.Flush();
					sw.Close();
					sw.Dispose();
					sw = null;
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					"",
					new Warning(
						"Unable to create settings File.",
						"SimPe was unable to create the file "
							+ filename
							+ ".\n\nYour Settings won't not be saved!",
						ex
					)
				);
			}
		}

		/// <summary>
		/// Write a SubKey
		/// </summary>
		/// <param name="sw"></param>
		/// <param name="key"></param>
		void WriteKey(System.IO.StreamWriter sw, XmlRegistryKey key)
		{
			if (key != CurrentUser)
			{
				sw.WriteLine("<key name=\"" + key.Name + "\">");
			}

			string[] keys = key.GetSubKeyNames();
			foreach (string s in keys)
			{
				WriteKey(sw, key.OpenSubKey(s, false));
			}

			string[] values = key.GetValueNames();
			foreach (string s in values)
			{
				WriteValue(sw, s, key.GetValue(s));
			}

			if (key != CurrentUser)
			{
				sw.WriteLine("</key>");
			}
		}

		/// <summary>
		/// Write a Value
		/// </summary>
		/// <param name="sw"></param>
		/// <param name="name"></param>
		/// <param name="o"></param>
		void WriteValue(System.IO.StreamWriter sw, string name, object o)
		{
			if (o == null)
			{
				return;
			}

			string tag = "string";
			string val = o.ToString();

			if (o is int || o is short || o is byte)
			{
				tag = "int";
			}
			else if (o is uint || o is ushort)
			{
				tag = "uint";
			}
			else if (o is long)
			{
				tag = "long";
			}
			else if (o is ulong)
			{
				tag = "ulong";
			}
			else if (o is bool)
			{
				tag = "bool";
				val = (bool)o ? "true" : "false";
			}
			else if (o is float)
			{
				tag = "float";
			}
			else if (o is DateTime)
			{
				tag = "datetime";
			}
			else if (o is Ambertation.CaseInvariantArrayList)
			{
				WriteList(sw, name, (ArrayList)o, true);
				return;
			}
			else if (o is ArrayList)
			{
				WriteList(sw, name, (ArrayList)o, false);
				return;
			}

			val = val.Replace("&", "&amp;");
			val = val.Replace("<", "&lt;").Replace(">", "&gt;");
			sw.WriteLine(
				"<" + tag + " name=\"" + name + "\">" + val + "</" + tag + ">"
			);
		}

		/// <summary>
		/// Write a Value
		/// </summary>
		/// <param name="sw"></param>
		/// <param name="name"></param>
		/// <param name="list"></param>
		/// <param name="caseinvariant"></param>
		void WriteList(
			System.IO.StreamWriter sw,
			string name,
			ArrayList list,
			bool caseinvariant
		)
		{
			if (!caseinvariant)
			{
				sw.WriteLine("<list name=\"" + name + "\">");
			}
			else
			{
				sw.WriteLine("<cilist name=\"" + name + "\">");
			}

			int ct = -1;
			foreach (object o in list)
			{
				ct++;
				if (o == null)
				{
					continue;
				}

				if (o is ArrayList)
				{
					continue;
				}

				WriteValue(sw, ct.ToString(), o);
			}
			if (!caseinvariant)
			{
				sw.WriteLine("</list>");
			}
			else
			{
				sw.WriteLine("</cilist>");
			}
		}
		#endregion
	}
}
