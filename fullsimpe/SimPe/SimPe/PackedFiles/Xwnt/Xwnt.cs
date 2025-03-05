// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Cpf;

namespace SimPe.PackedFiles.Xwnt
{
	public class Xwnt
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region Attributes
		public XwntVersion Version { get; set; } = XwntVersion.Version7;

		public uint Id { get; set; } = 0;

		public string Folder { get; set; } = "folder";

		public string NodeText { get; set; } = "nodeText";

		public uint PrimaryIcon { get; set; } = 0;

		public uint SecondaryIcon { get; set; } = 0;
		public uint GameVersionFlags { get; set; } = 1;
		public uint StringSet { get; set; } = 0x0B36;
		public string CheckTree { get; set; } = "checkTree";
		public string FeedbackTree { get; set; } = "feedbackTree";
		public string SimArrayTree { get; set; } = "simArrayTree";
		public XwntLevel Level { get; set; } = XwntLevel.Memorable;
		public int Score { get; set; } = 0;
		public int Influence { get; set; } = 0;
		public Swaf.WantType ObjectType { get; set; } = Swaf.WantType.None;
		public XwntIntegerType IntegerType { get; set; } = XwntIntegerType.None;
		public int IntegerMultiplier { get; set; } = 1;
		public XwntIntegerOperator IntegerOperator { get; set; } = XwntIntegerOperator.None;
		public bool EventRequiresObject { get; set; } = false;
		public bool EventRequiresSim { get; set; } = false;
		public bool Deprecated { get; set; } = false;



		#endregion


		public Xwnt()
			: base()
		{
			SynchronizeUserData();
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			#region Un-break Quaxified XWNTs
			// Because Quaxi's CPF wrapper rewrites XML as binary, we handle that case here
			byte[] hdr = reader.ReadBytes(6);
			reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

			bool isCpf = hdr.SequenceEqual(new byte[] { 0xE0, 0x50, 0xE7, 0xCB, 0x02, 0x00 });

			if (isCpf)
			{
				Cpf.Cpf cpf = new Cpf.Cpf();
				cpf.ProcessData(FileDescriptor, Package);
				Xwnt xwnt = new Xwnt();
				foreach (CpfItem item in cpf.Items)
				{
					switch (item.Name)
					{
						case "id":
							Id = item.UIntegerValue;
							break;
						case "folder":
							Folder = item.StringValue;
							break;
						case "nodeText":
							NodeText = item.StringValue;
							break;
						case "primaryIcon":
							PrimaryIcon = item.UIntegerValue;
							break;
						case "secondaryIcon":
							SecondaryIcon = item.UIntegerValue;
							break;
						case "gameVersionFlags":
							GameVersionFlags = item.UIntegerValue;
							break;
						case "stringSet":
							StringSet = item.UIntegerValue;
							break;
						case "checkTree":
							CheckTree = item.StringValue;
							break;
						case "feedbackTree":
							FeedbackTree = item.StringValue;
							break;
						case "simArrayTree":
							SimArrayTree = item.StringValue;
							break;
						case "level":
							Level = (XwntLevel)Enum.Parse(typeof(XwntLevel), item.StringValue);
							break;
						case "score":
							Score = item.IntegerValue;
							break;
						case "influence":
							Influence = item.IntegerValue;
							break;
						case "objectType":
							ObjectType = (Swaf.WantType)Enum.Parse(typeof(Swaf.WantType), item.StringValue);
							break;
						case "integerType":
							IntegerType = (XwntIntegerType)Enum.Parse(typeof(XwntIntegerType), item.StringValue);
							break;
						case "integerMultiplier":
							IntegerMultiplier = item.IntegerValue;
							break;
						case "integerOperator":
							IntegerOperator = (XwntIntegerOperator)Enum.Parse(typeof(XwntIntegerOperator), item.StringValue);
							break;
						case "eventRequiresObject":
							EventRequiresObject = item.BooleanValue;
							break;
						case "eventRequiresSim":
							EventRequiresSim = item.BooleanValue;
							break;
						case "deprecated":
							Deprecated = item.BooleanValue;
							break;
						default:
							continue;
					}
				}
				return;
			}
			#endregion

			XmlReader xr = XmlReader.Create(reader.BaseStream, new XmlReaderSettings
			{
				IgnoreProcessingInstructions = true,
				IgnoreWhitespace = true
			});
			while (xr.NodeType != XmlNodeType.Element)
			{
				xr.Read();
			}
			System.ComponentModel.UInt32Converter uintconverter = new System.ComponentModel.UInt32Converter();
			System.ComponentModel.Int32Converter intconverter = new System.ComponentModel.Int32Converter();

			XDocument doc = XDocument.Load(xr);
			Version = (XwntVersion)(uint)doc.Root.Attribute("version");

			foreach (XElement el in doc.Root.Elements())
			{
				if (el.Attribute("key") != null)
				{
					switch ((string)el.Attribute("key"))
					{
						case "id":
							Id = (uint)uintconverter.ConvertFrom(el.Value);
							break;
						case "folder":
							Folder = el.Value;
							break;
						case "nodeText":
							NodeText = el.Value;
							break;
						case "primaryIcon":
							PrimaryIcon = (uint)uintconverter.ConvertFrom(el.Value);
							break;
						case "secondaryIcon":
							SecondaryIcon = (uint)uintconverter.ConvertFrom(el.Value);
							break;
						case "gameVersionFlags":
							GameVersionFlags = (uint)uintconverter.ConvertFrom(el.Value);
							break;
						case "stringSet":
							StringSet = (uint)uintconverter.ConvertFrom(el.Value);
							break;
						case "checkTree":
							CheckTree = el.Value;
							break;
						case "feedbackTree":
							FeedbackTree = el.Value;
							break;
						case "simArrayTree":
							SimArrayTree = el.Value;
							break;
						case "level":
							Level = (XwntLevel)Enum.Parse(typeof(XwntLevel), el.Value);
							break;
						case "score":
							Score = (int)intconverter.ConvertFrom(el.Value);
							break;
						case "influence":
							Influence = (int)intconverter.ConvertFrom(el.Value);
							break;
						case "objectType":
							ObjectType = (Swaf.WantType)Enum.Parse(typeof(Swaf.WantType), el.Value);
							break;
						case "integerType":
							IntegerType = (XwntIntegerType)Enum.Parse(typeof(XwntIntegerType), el.Value);
							break;
						case "integerMultiplier":
							IntegerMultiplier = (int)intconverter.ConvertFrom(el.Value);
							break;
						case "integerOperator":
							IntegerOperator = (XwntIntegerOperator)Enum.Parse(typeof(XwntIntegerOperator), el.Value);
							break;
						case "eventRequiresObject":
							EventRequiresObject = (bool)el;
							break;
						case "eventRequiresSim":
							EventRequiresSim = (bool)el;
							break;
						case "deprecated":
							Deprecated = (bool)el;
							break;
						default:
							continue;
					}
				}
			}
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			new XElement("cGZPropertySetString",
				new XAttribute("version", Version),
				new XComment("editor parameters"),
				new XElement("AnyUint32",
					new XAttribute("key", "id"),
					new XAttribute("type", "0xeb61e4f7"),
					$"0x{Id:x8}"),
				new XElement("AnyString",
					new XAttribute("key", "folder"),
					new XAttribute("type", "0x0b8bea18"),
					Folder),
				new XElement("AnyString",
					new XAttribute("key", "nodeText"),
					new XAttribute("type", "0x0b8bea18"),
					NodeText),
				new XComment("primaryIcon: used in UI when there is a single icon shown"),
				new XElement("AnyUint32",
					new XAttribute("key", "primaryIcon"),
					new XAttribute("type", "0xeb61e4f7"),
					$"0x{PrimaryIcon:x8}"),
				new XComment("secondaryIcon: used in UI when there are two icons, e.g., if a person is the primary icon"),
				new XElement("AnyUint32",
					new XAttribute("key", "secondaryIcon"),
					new XAttribute("type", "0xeb61e4f7"),
					$"0x{SecondaryIcon:x8}"),
				new XComment("secondaryIcon: used in UI when there are two icons, e.g., if a person is the primary icon"),
				new XElement("AnyUint32",
					new XAttribute("key", "gameVersionFlags"),
					new XAttribute("type", "0xeb61e4f7"),
					GameVersionFlags),
				new XComment("stringSet: a 15 bit GUID that points to a string set resource."),
				new XElement("AnyUint32",
					new XAttribute("key", "stringSet"),
					new XAttribute("type", "0xeb61e4f7"),
					StringSet),
				new XElement("AnyString",
					new XAttribute("key", "checkTree"),
					new XAttribute("type", "0x0b8bea18"),
					CheckTree),
				new XElement("AnyString",
					new XAttribute("key", "feedbackTree"),
					new XAttribute("type", "0x0b8bea18"),
					FeedbackTree),
				new XElement("AnyString",
					new XAttribute("key", "simArrayTree"),
					new XAttribute("type", "0x0b8bea18"),
					SimArrayTree),
				new XElement("AnyString",
					new XAttribute("key", "level"),
					new XAttribute("type", "0x0b8bea18"),
					Level.ToString()),
				new XElement("AnySint32",
					new XAttribute("key", "score"),
					new XAttribute("type", "0x0c264712"),
					Score),
				new XElement("AnySint32",
					new XAttribute("key", "influence"),
					new XAttribute("type", "0x0c264712"),
					Influence),
				new XComment("Node Properties"),
				new XElement("AnyString",
					new XAttribute("key", "objectType"),
					new XAttribute("type", "0x0b8bea18"),
					ObjectType.ToString()),
				new XElement("AnyString",
					new XAttribute("key", "integerType"),
					new XAttribute("type", "0x0b8bea18"),
					IntegerType.ToString()),
				new XElement("AnySint32",
					new XAttribute("key", "integerMultiplier"),
					new XAttribute("type", "0x0c264712"),
					IntegerMultiplier),
				new XElement("AnyString",
					new XAttribute("key", "integerOperator"),
					new XAttribute("type", "0x0b8bea18"),
					IntegerOperator.ToString()),
				new XComment("Event Properties"),
				new XElement("AnyBoolean",
					new XAttribute("key", "eventRequiresObject"),
					new XAttribute("type", "0xcba908e1"),
					EventRequiresObject),
				new XElement("AnyBoolean",
					new XAttribute("key", "eventRequiresSim"),
					new XAttribute("type", "0xcba908e1"),
					EventRequiresSim),
				new XElement("AnyBoolean",
					new XAttribute("key", "deprecated"),
					new XAttribute("type", "0xcba908e1"),
					Deprecated)
			).WriteTo(XmlWriter.Create(writer.BaseStream, new XmlWriterSettings
			{
				Encoding = Encoding.ASCII,
				Indent = true
			}));
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

		public const uint XWNTType = 0xED7D7B4D;

		#region IFileWrapper Member
		/// <summary>
		/// Returns a list of File Types this Plugin can process
		/// </summary>
		public uint[] AssignableTypes => new uint[] { XWNTType, 0xBEEF7B4D };

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		#endregion

		#region IFileWrapperSaveExtension Member
		protected override string GetResourceName(Data.TypeAlias ta)
		{
			//if (!SimPe.Helper.FileFormat) return base.GetResourceName(ta);
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package);
			}

			string s = "";
			if (Helper.FileFormat)
			{
				s += Version + ":";
			}

			if (ObjectType != Swaf.WantType.None)
			{
				s += (s.Length > 0 ? " " : "") + "(" + ObjectType.ToString() + ")";
			}

			if (Folder != null)
			{
				s += (s.Length > 0 ? " " : "") + Folder;
			}

			if (NodeText != null)
			{
				s += (s.Length > 0 ? " / " : "") + NodeText;
			}

			return s;
		}
		#endregion
	}
}
