// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Cpf;

namespace SimPe.Wants
{
	public class XWNTWrapper
		: pjse.ExtendedWrapper<XWNTItem, XWNTWrapper>,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region Attributes
		private string version;
		#endregion

		#region Accessor Methods
		public string Version
		{
			get => version;
			set
			{
				if (version != value)
				{
					setVersion(value);
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		void setVersion(string value)
		{
			version = IsValidVersion(value) ? value : throw new ArgumentOutOfRangeException("version");
		}
		#endregion

		#region ValidVersions
		static List<string> lValidVersions = null;
		public static List<string> ValidVersions
		{
			get
			{
				if (lValidVersions == null)
				{
					lValidVersions = new List<string>(new string[] { "5", "6", "7" });
				}

				return lValidVersions;
			}
		}

		static bool IsValidVersion(string value)
		{
			return ValidVersions.Contains(value);
		}
		#endregion


		public XWNTWrapper()
			: base()
		{
			version = "7";
			items.Add(new XWNTItem(this, "<!--editor parameters-->", ""));
			items.Add(new XWNTItem(this, "id", "0x00000000"));
			items.Add(new XWNTItem(this, "folder", "folder"));
			items.Add(new XWNTItem(this, "nodeText", "nodeText"));
			items.Add(
				new XWNTItem(
					this,
					"<!--primaryIcon: used in UI when there is a single icon shown-->",
					""
				)
			);
			items.Add(new XWNTItem(this, "primaryIcon", "0x00000000"));
			items.Add(
				new XWNTItem(
					this,
					"<!--secondaryIcon: used in UI when there are two icons, e.g., if a person is the primary icon-->",
					""
				)
			);
			items.Add(new XWNTItem(this, "secondaryIcon", "0x00000000"));
			items.Add(
				new XWNTItem(
					this,
					"<!--Game Edition Flag to determine if the Want should be loaded by the Simulator-->",
					""
				)
			);
			items.Add(new XWNTItem(this, "gameVersionFlags", "1"));
			items.Add(
				new XWNTItem(
					this,
					"<!--stringSet: a 15 bit GUID that points to a string set resource.-->",
					""
				)
			);
			items.Add(new XWNTItem(this, "stringSet", "0x0B36"));
			items.Add(new XWNTItem(this, "checkTree", "checkTree"));
			items.Add(new XWNTItem(this, "feedbackTree", "feedbackTree"));
			items.Add(new XWNTItem(this, "simArrayTree", "simArrayTree"));
			items.Add(new XWNTItem(this, "level", XWNTItem.ValidLevels[0]));
			items.Add(new XWNTItem(this, "score", "0"));
			items.Add(new XWNTItem(this, "influence", "0"));
			items.Add(new XWNTItem(this, "<!--Node Properties-->", ""));
			items.Add(new XWNTItem(this, "objectType", XWNTItem.ValidObjectTypes[0]));
			items.Add(new XWNTItem(this, "integerType", XWNTItem.ValidIntegerTypes[0]));
			items.Add(new XWNTItem(this, "integerMultiplier", "1"));
			items.Add(
				new XWNTItem(this, "integerOperator", XWNTItem.ValidIntegerOperators[0])
			);
			items.Add(new XWNTItem(this, "<!--Event Properties-->", ""));
			items.Add(new XWNTItem(this, "eventRequiresObject", bool.FalseString));
			items.Add(new XWNTItem(this, "eventRequiresSim", bool.FalseString));
			items.Add(new XWNTItem(this, "deprecated", bool.FalseString));
			SynchronizeUserData();
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			items = new List<XWNTItem>();

			#region Un-break Quaxified XWNTs
			// Because Quaxi's CPF wrapper rewrites XML as binary, we handle that case here
			byte[] hdr = reader.ReadBytes(6);
			reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

			bool isCpf = true;
			byte[] id = new byte[] { 0xE0, 0x50, 0xE7, 0xCB, 0x02, 0x00 };
			for (int i = 0; i < hdr.Length && isCpf; i++)
			{
				isCpf = hdr[i] == id[i];
			}

			if (isCpf)
			{
				Cpf cpf = new Cpf();
				cpf.ProcessData(FileDescriptor, Package);
				XWNTWrapper xwnt = new XWNTWrapper();
				foreach (XWNTItem item in xwnt)
				{
					if (item.Key.StartsWith("<!"))
					{
						Add(new XWNTItem(this, item.Key, ""));
					}
					else
					{
						CpfItem cpfitem = cpf.GetItem(
							item.Key
						);
						if (cpfitem != null)
						{
							string value = "";
							switch (cpfitem.Datatype) // Argh... So broken...
							{
								case DataTypes.dtInteger:
									value = cpfitem.IntegerValue.ToString();
									break;
								case DataTypes.dtBoolean:
									value = cpfitem.BooleanValue.ToString();
									break;
								default:
									value = cpfitem.StringValue;
									break;
							}
							items.Add(new XWNTItem(this, item.Key, value));
						}
						else
						{
							items.Add(new XWNTItem(this, item.Key, item.Value));
						}
					}
				}
				return;
			}
			#endregion

			XmlReaderSettings xrs = new XmlReaderSettings
			{
				//xrs.IgnoreComments = true;
				IgnoreProcessingInstructions = true,
				IgnoreWhitespace = true
			};
			XmlReader xr = XmlReader.Create(reader.BaseStream, xrs);

			if (
				xr.IsStartElement()
				&& xr.NodeType.Equals(XmlNodeType.Element)
				&& xr.Name.Equals("cGZPropertySetString")
			)
			{
				setVersion(xr["version"]);
			}
			else
			{
				throw new Exception("Invalid XWNT format");
			}

			xr.Read();

			while (xr.IsStartElement())
			{
				items.Add(new XWNTItem(this, xr));

				if (!xr.IsEmptyElement)
				{
					xr.ReadEndElement();
				}
				else
				{
					xr.Skip();
				}
			}
			xr.ReadEndElement();
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			XmlWriterSettings xws = new XmlWriterSettings
			{
				Encoding = Encoding.ASCII,
				Indent = true
			};
			XmlWriter xw = XmlWriter.Create(writer.BaseStream);

			xw.WriteStartElement("cGZPropertySetString");
			xw.WriteAttributeString("version", version);
			foreach (XWNTItem xi in this)
			{
				if (xi.Key.StartsWith("<"))
				{
					xw.WriteRaw("  " + xi.Key);
				}
				else
				{
					xw.WriteStartElement(xi.Stype);
					xw.WriteAttributeString("key", xi.Key);
					xw.WriteAttributeString("type", xi.Utype);
					if (xi.Value.Length > 0)
					{
						xw.WriteValue(xi.Value);
					}

					xw.WriteEndElement();
				}
			}
			xw.WriteEndElement();
			xw.Flush();
		}

		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new XWNTEditor();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo("PJSE XWNT Wrapper", "Peter L Jones", "", 1);
		}

		#region IFileWrapper Member
		/// <summary>
		/// Returns a list of File Types this Plugin can process
		/// </summary>
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.XWNT, FileTypes.GOAL };

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		#endregion

		#region IFileWrapperSaveExtension Member
		protected override string GetResourceName(FileTypeInformation fti)
		{
			//if (!SimPe.Helper.FileFormat) return base.GetResourceName(ta);
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package);
			}

			string s = "";
			if (Helper.FileFormat)
			{
				s += version + ":";
			}

			if (this["objectType"] != null)
			{
				s += (s.Length > 0 ? " " : "") + "(" + this["objectType"].Value + ")";
			}

			if (this["folder"] != null)
			{
				s += (s.Length > 0 ? " " : "") + this["folder"].Value;
			}

			if (this["nodeText"] != null)
			{
				s += (s.Length > 0 ? " / " : "") + this["nodeText"].Value;
			}

			return s;
		}
		#endregion

		public XWNTItem this[string value]
		{
			get
			{
				foreach (XWNTItem xi in this)
				{
					if (xi.Key.Equals(value))
					{
						return xi;
					}
				}

				return null;
			}
		}
	}

	public class XWNTItem : pjse.ExtendedWrapperItem<XWNTWrapper, XWNTItem>
	{
		#region Attributes
		string key;
		string type;
		string utype;
		string value;
		#endregion

		#region Accessor Methods
		public string Key
		{
			get => key;
			set
			{
				if (key != value)
				{
					setKey(value);
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		void setKey(string value)
		{
			key = value.StartsWith("<!") || IsValidKey(value) ? value : throw new ArgumentOutOfRangeException("key");
		}

		public string Stype
		{
			get => type;
			set
			{
				if (type != value)
				{
					setType(value);
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		void setType(string value)
		{
			type = IsValidType(value) ? value : throw new ArgumentOutOfRangeException("type");
		}

		public string Utype
		{
			get => utype;
			set
			{
				if (utype != value)
				{
					setUtype(value);
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		void setUtype(string value)
		{
			utype = IsValidUtype(type, value) ? value : throw new ArgumentOutOfRangeException("utype");
		}

		public string Value
		{
			get => value;
			set
			{
				if (this.value != value)
				{
					setValue(value);
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		void setValue(string value)
		{
			switch (key)
			{
				case "integerOperator":
					if (!IsValidIntegerOperator(value))
					{
						throw new ArgumentOutOfRangeException(
							"value (integerOperator)"
						);
					}

					break;
				case "integerType":
					if (!IsValidIntegerType(value))
					{
						throw new ArgumentOutOfRangeException("value (integerType)");
					}

					break;
				case "level":
					if (!IsValidLevel(value))
					{
						throw new ArgumentOutOfRangeException("value (level)");
					}

					break;
				case "objectType":
					if (!IsValidObjectType(value))
					{
						throw new ArgumentOutOfRangeException("value (objectType)");
					}

					break;
				default:
					switch (type)
					{
						case "AnyBoolean":
							Convert.ToBoolean(value);
							break;
						case "AnySint32":
							Convert.ToInt32(value);
							break;
						case "AnyString":
							break;
						case "AnyUint32":
							Convert.ToUInt32(value, value.StartsWith("0x") ? 16 : 10);
							break;
					}
					break;
			}
			this.value = value;
		}
		#endregion

		/// <summary>
		/// Create a new XWNTItem from an XML stream
		/// </summary>
		/// <param name="parent">The XWNT owning this XWNTItem</param>
		/// <param name="xr">The XML stream</param>
		/// <remarks>Set item&apos;s <paramref name="parent"/> and calls <see cref="Unserialize"/> with <paramref name="xr"/></remarks>
		public XWNTItem(XWNTWrapper parent, XmlReader xr)
		{
			this.parent = parent;
			Unserialize(xr);
		}

		/// <summary>
		/// Create an XWNTItem
		/// </summary>
		/// <param name="parent">The XWNT owning this XWNTItem</param>
		/// <param name="key">Either an XML comment or a valid XWNTItem key</param>
		/// <param name="value">A valid value for this key and type</param>
		public XWNTItem(XWNTWrapper parent, string key, string value)
		{
			this.parent = parent;
			setKey(key);
			if (key.StartsWith("<!"))
			{
				return;
			}

			setType(StypeForKey(key));
			setUtype(TypeUtype[type]);
			setValue(value);
		}

		private void Unserialize(XmlReader xr)
		{
			if (!xr.NodeType.Equals(XmlNodeType.Element))
			{
				setKey(xr.ReadOuterXml());
			}
			else
			{
				setKey(xr["key"]);
				setType(xr.Name);
				setUtype(xr["type"]);
				setValue(xr.ReadString());
			}
		}

		#region IsUint32Long
		private static Dictionary<string, bool> lLongUint32 = null;
		private static Dictionary<string, bool> LongUint32
		{
			get
			{
				if (lLongUint32 == null)
				{
					lLongUint32 = new Dictionary<string, bool>
					{
						{ "id", true },
						{ "primaryIcon", true },
						{ "secondaryIcon", true }
					};
				}
				return lLongUint32;
			}
		}

		public static bool IsUint32Long(string value)
		{
			return LongUint32.ContainsKey(value) && LongUint32[value];
		}
		#endregion

		#region ValidKeys
		private static Dictionary<string, string> lKeyType = null;
		private static Dictionary<string, string> KeyType
		{
			get
			{
				if (lKeyType == null)
				{
					lKeyType = new Dictionary<string, string>
					{
						{ "checkTree", "AnyString" },
						{ "deprecated", "AnyBoolean" },
						{ "eventRequiresObject", "AnyBoolean" },
						{ "eventRequiresSim", "AnyBoolean" },
						{ "feedbackTree", "AnyString" },
						{ "folder", "AnyString" },
						{ "gameVersionFlags", "AnyUint32" },
						{ "id", "AnyUint32" },
						{ "influence", "AnySint32" },
						{ "integerMultiplier", "AnySint32" },
						{ "integerOperator", "AnyString" },
						{ "integerType", "AnyString" },
						{ "level", "AnyString" },
						{ "nodeText", "AnyString" },
						{ "objectType", "AnyString" },
						{ "primaryIcon", "AnyUint32" },
						{ "score", "AnySint32" },
						{ "secondaryIcon", "AnyUint32" },
						{ "simArrayTree", "AnyString" },
						{ "stringSet", "AnyUint32" }
					};
				}
				return lKeyType;
			}
		}
		public static List<string> ValidKeys => new List<string>(KeyType.Keys);

		private static bool IsValidKey(string value)
		{
			return KeyType.ContainsKey(value);
		}

		public static string StypeForKey(string key)
		{
			return KeyType.TryGetValue(key, out string stype) ? stype : throw new ArgumentOutOfRangeException("key");
		}
		#endregion

		#region Valid Types and Utypes
		private static Dictionary<string, string> lTypeUtype = null;
		private static Dictionary<string, string> TypeUtype
		{
			get
			{
				if (lTypeUtype == null)
				{
					lTypeUtype = new Dictionary<string, string>
					{
						{ "AnyBoolean", "0xcba908e1" },
						{ "AnySint32", "0x0c264712" },
						{ "AnyString", "0x0b8bea18" },
						{ "AnyUint32", "0xeb61e4f7" }
					};
				}
				return lTypeUtype;
			}
		}
		public static List<string> ValidTypes => new List<string>(TypeUtype.Keys);
		public static List<string> ValidUtypes => new List<string>(TypeUtype.Values);

		private static bool IsValidType(string value)
		{
			return TypeUtype.ContainsKey(value);
		}

		private static bool IsValidUtype(string type, string value)
		{
			return IsValidType(type) && TypeUtype[type].Equals(value);
		}
		#endregion

		#region ValidIntegerOperators
		static List<string> lValidIntegerOperators = null;
		public static List<string> ValidIntegerOperators
		{
			get
			{
				if (lValidIntegerOperators == null)
				{
					lValidIntegerOperators = new List<string>(
						new string[]
						{
							"None",
							"Equals",
							"Greater_Then_Or_Equals",
							"Less_Then",
						}
					);
				}

				return lValidIntegerOperators;
			}
		}

		static bool IsValidIntegerOperator(string value)
		{
			return ValidIntegerOperators.Contains(value);
		}
		#endregion

		#region ValidIntegerTypes
		static List<string> lValidIntegerTypes = null;
		public static List<string> ValidIntegerTypes
		{
			get
			{
				if (lValidIntegerTypes == null)
				{
					lValidIntegerTypes = new List<string>(
						new string[] { "None", "Number" }
					);
				}

				return lValidIntegerTypes;
			}
		}

		static bool IsValidIntegerType(string value)
		{
			return ValidIntegerTypes.Contains(value);
		}
		#endregion

		#region ValidLevels
		static List<string> lValidLevels = null;
		public static List<string> ValidLevels
		{
			get
			{
				if (lValidLevels == null)
				{
					lValidLevels = new List<string>(
						new string[]
						{
							"Memorable",
							"Power",
							"Transitory",
							"Story",
							"Generational",
						}
					);
				}

				return lValidLevels;
			}
		}

		static bool IsValidLevel(string value)
		{
			return ValidLevels.Contains(value);
		}
		#endregion

		#region ValidObjectTypes
		static List<string> lValidObjectTypes = null;
		public static List<string> ValidObjectTypes
		{
			get
			{
				if (lValidObjectTypes == null)
				{
					lValidObjectTypes = new List<string>(
						new string[]
						{
							"Badge",
							"Career",
							"Category",
							"Guid",
							"None",
							"Sim",
							"Skill",
						}
					);
				}

				return lValidObjectTypes;
			}
		}

		static bool IsValidObjectType(string value)
		{
			return ValidObjectTypes.Contains(value);
		}
		#endregion
	}
}
