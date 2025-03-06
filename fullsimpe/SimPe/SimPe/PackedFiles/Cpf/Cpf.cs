// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Linq;
using System.Xml;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Cpf
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Cpf
		: AbstractWrapper //Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
			,
			IFileWrapper //This Interface is used when loading a File
			,
			IFileWrapperSaveExtension //This Interface (if available) will be used to store a File
			,
			IMultiplePackedFileWrapper //Allow Multiple Instances
	{
		#region Attributes
		/// <summary>
		/// Contains the Filename
		/// </summary>
		/// <summary>
		/// Returns the Filename
		/// </summary>
		public byte[] Id
		{
			get; private set;
		}

		/// <summary>
		/// Returns/Sets the Constants
		/// </summary>
		public CpfItem[] Items
		{
			get; set;
		} = new CpfItem[0];
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Cpf()
			: base()
		{
			Id = FileSignature;
		}

		/// <summary>
		/// Add a new CPF Item
		/// </summary>
		/// <param name="item">The item you want to add</param>
		public void AddItem(CpfItem item)
		{
			AddItem(item, true);
		}

		/// <summary>
		/// Add a new CPF Item
		/// </summary>
		/// <param name="item">The item you want to add</param>
		/// <param name="duplicate">true if you want to add the item even if a similar one already exists</param>
		public void AddItem(CpfItem item, bool duplicate)
		{
			if (item != null)
			{
				CpfItem ex = null;
				if (!duplicate)
				{
					ex = GetItem(item.Name);
				}

				if (ex != null)
				{
					ex.Datatype = item.Datatype;
					ex.Value = item.Value;
				}
				else
				{
					Items = (CpfItem[])Helper.Add(Items, item);
				}
			}
		}

		/// <summary>
		/// returns the Item with the given Name o rnull if not found
		/// </summary>
		/// <param name="name"></param>
		/// <returns>null or the Item</returns>
		public CpfItem GetItem(string name)
		{
			foreach (CpfItem item in Items)
			{
				if (item.Name == name)
				{
					return item;
				}
			}

			return null;
		}

		/// <summary>
		/// returns the Item with the given Name or null if not found
		/// </summary>
		/// <param name="name"></param>
		/// <returns>the Item</returns>
		public CpfItem GetSaveItem(string name)
		{
			CpfItem res = GetItem(name);
			return res ?? new CpfItem();
		}

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return version == 0009 //0.00
				|| version == 0010; //0.10
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new CpfUI(null);
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"CPF Wrapper",
				"Quaxi",
				"This File is a structured Text File (like an .ini or .xml File), that contains Key Value Pairs.",
				8,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.cpf.png")
				)
			);
		}

		protected override string GetResourceName(FileTypeInformation fti)
		{
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package);
			}

			CpfItem item = GetItem("name");
			return item == null ? base.GetResourceName(fti) : item.StringValue;
		}

#if DEBUG
		public override string Description
		{
			get
			{
				string s = "";

				s += GetSaveItem("name").StringValue + "; ";
				s += GetSaveItem("age").StringValue + "; ";
				s += GetSaveItem("gender").StringValue + "; ";
				s += GetSaveItem("fitness").StringValue + "; ";
				s += GetSaveItem("override0subset").StringValue + "; ";
				s += GetSaveItem("category").StringValue + "; ";
				s += GetSaveItem("outfit").StringValue + "; ";
				s += GetSaveItem("flags").StringValue + "; ";
				return s;
			}
		}
#endif

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected void UnserializeXml(System.IO.BinaryReader reader)
		{
			reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
			System.IO.StreamReader sr = new System.IO.StreamReader(reader.BaseStream);
			string s = sr.ReadToEnd();
			s = s.Replace("& ", "&amp; ");
			System.IO.StringReader strr = new System.IO.StringReader(s);
			XmlDocument xmlfile = new XmlDocument();
			xmlfile.Load(strr);

			XmlNodeList XMLData = xmlfile.GetElementsByTagName("cGZPropertySetString");
			ArrayList list = new ArrayList();

			//Process all Root Node Entries
			for (int i = 0; i < XMLData.Count; i++)
			{
				XmlNode node = XMLData.Item(i);

				foreach (XmlNode subnode in node)
				{
					CpfItem item = new CpfItem();

					if (subnode.LocalName.Trim().ToLower() == "anyuint32")
					{
						item.Datatype = Data.DataTypes.dtUInteger;
						item.UIntegerValue = subnode.InnerText.IndexOf("-") != -1
							? (uint)
								Convert.ToInt32(subnode.InnerText)
							: subnode.InnerText.IndexOf("0x") == -1
								? Convert.ToUInt32(subnode.InnerText)
								: Convert.ToUInt32(
															subnode.InnerText,
															16
														);
					}
					else if (
						subnode.LocalName.Trim().ToLower() == "anyint32"
						|| subnode.LocalName.Trim().ToLower() == "anysint32"
					)
					{
						item.Datatype = Data.DataTypes.dtInteger;
						item.IntegerValue = subnode.InnerText.IndexOf("0x") == -1 ? Convert.ToInt32(subnode.InnerText) : Convert.ToInt32(subnode.InnerText, 16);
					}
					else if (subnode.LocalName.Trim().ToLower() == "anystring")
					{
						item.Datatype = Data.DataTypes.dtString;
						item.StringValue = subnode.InnerText;
					}
					else if (subnode.LocalName.Trim().ToLower() == "anyfloat32")
					{
						item.Datatype = Data.DataTypes.dtSingle;
						item.SingleValue = Convert.ToSingle(
							subnode.InnerText,
							System.Globalization.CultureInfo.InvariantCulture
						);
					}
					else if (subnode.LocalName.Trim().ToLower() == "anyboolean")
					{
						item.Datatype = Data.DataTypes.dtBoolean;
						item.BooleanValue = subnode.InnerText.Trim().ToLower() == "true" || subnode.InnerText.Trim().ToLower() != "false" && Convert.ToInt32(subnode.InnerText) != 0;
					}
					else if (subnode.LocalName.Trim().ToLower() == "#comment")
					{
						continue;
					}
					/*else
					{
						item.Datatype = (Data.MetaData.DataTypes)Convert.ToUInt32(subnode.Attributes["type"].Value, 16);
					}*/

					try
					{
						item.Name = subnode.Attributes["key"].Value;
						list.Add(item);
					}
					catch { }
				}
			} //for i

			Items = new CpfItem[list.Count];
			list.CopyTo(Items);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			Id = reader.ReadBytes(0x06);
			if (Id[0] != SIGNATURE[0])
			{
				Id = SIGNATURE;
				UnserializeXml(reader);

				return;
			}
			Items = new CpfItem[reader.ReadUInt32()];

			for (int i = 0; i < Items.Length; i++)
			{
				Items[i] = new CpfItem();
				Items[i].Unserialize(reader);
			}
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			if (Id.Length != 0x06)
			{
				Id = SIGNATURE;
			}

			writer.Write(Id);
			writer.Write((uint)Items.Length);

			for (int i = 0; i < Items.Length; i++)
			{
				Items[i].Serialize(writer);
			}
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member
		protected static byte[] SIGNATURE = new byte[]
		{
			0xE0,
			0x50,
			0xE7,
			0xCB,
			0x02,
			0x00,
		};

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public virtual byte[] FileSignature => SIGNATURE;

		public bool CanHandleType(FileTypes type)
		{
			return AssignableTypes.Contains(type);
		}

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public virtual FileTypes[] AssignableTypes => new FileTypes[]
				{
					FileTypes.AGED,
					FileTypes.VERS,
					FileTypes.GZPS,
					FileTypes.BINX,
					FileTypes.SDNA,
					FileTypes.XTOL,
					FileTypes.XOBJ,
					FileTypes.XSTN,
					FileTypes.XMOL,
					FileTypes.XHTN,
					FileTypes.XFRG,
					FileTypes.XFNU,
					FileTypes.XFMD,
					FileTypes.XFCH,
					FileTypes.XROF,
					FileTypes.XFLR,
					FileTypes.XFNC,
					FileTypes.XNGB,
					FileTypes.PBOP,
					FileTypes.COLL,
				};

		#endregion

		#region IMultiplePackedFileWrapper
		public override object[] GetConstructorArguments()
		{
			object[] o = new object[0];
			return o;
		}
		#endregion

		public override void Dispose()
		{
			base.Dispose();

			if (Items != null)
			{
				for (int i = Items.Length - 1; i >= 0; i--)
				{
					Items[i]?.Dispose();
				}
			}

			Items = new CpfItem[0];
			Items = null;
		}
	}
}
