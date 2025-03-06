// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Data;

namespace SimPe.PackedFiles.Cpf
{
	/// <summary>
	/// An Item stored in a CPF File
	/// </summary>
	public class CpfItem : IDisposable
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public CpfItem()
		{
		}

		/// <summary>
		/// Returns the
		/// </summary>
		public DataTypes Datatype
		{
			get; set;
		}

		/// <summary>
		/// Returns the Name
		/// </summary>
		public string Name
		{
			get => Helper.ToString(PlainName);
			set => PlainName = Helper.ToBytes(value, 0);
		}

		/// <summary>
		/// Returns the Name as a Byte Array
		/// </summary>
		public byte[] PlainName
		{
			get; set;
		} = new byte[0];

		#region value Handling

		/// <summary>
		/// Returns the
		/// </summary>
		public byte[] Value
		{
			get; set;
		} = new byte[0];

		/// <summary>
		/// Returns the value as a String
		/// </summary>
		public string StringValue
		{
			get
			{
				switch (Datatype)
				{
					case DataTypes.dtSingle:
					{
						return AsSingle().ToString();
					}
					case DataTypes.dtInteger:
					case DataTypes.dtUInteger:
					{
						return "0x" + Helper.HexStringInt(AsInteger());
					}
					case DataTypes.dtString:
					{
						return AsString();
					}
					default:
					{
						return "";
					}
				} //switch;
			}
			set
			{
				Datatype = DataTypes.dtString;
				Value = Helper.ToBytes(value, 0);
			}
		}

		/// <summary>
		/// Returns the value as a String
		/// </summary>
		public uint UIntegerValue
		{
			get
			{
				switch (Datatype)
				{
					case DataTypes.dtSingle:
					{
						return Convert.ToUInt32(AsSingle());
					}
					case DataTypes.dtInteger:
					case DataTypes.dtUInteger:
					{
						return AsUInteger();
					}
					case DataTypes.dtString:
					{
						uint ret = 0;
						try
						{
							ret = uint.Parse(AsString());
						}
						catch (Exception) { }
						return ret;
					}
					default:
					{
						return 0;
					}
				} //switch;
			}
			set
			{
				Datatype = DataTypes.dtUInteger;
				System.IO.BinaryWriter bw = new System.IO.BinaryWriter(
					new System.IO.MemoryStream()
				);
				bw.Write(value);
				System.IO.BinaryReader br = new System.IO.BinaryReader(bw.BaseStream);
				br.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
				Value = br.ReadBytes((int)br.BaseStream.Length);
			}
		}

		/// <summary>
		/// Returns the value as a String
		/// </summary>
		public int IntegerValue
		{
			get
			{
				switch (Datatype)
				{
					case DataTypes.dtSingle:
					{
						return Convert.ToInt32(AsSingle());
					}
					case DataTypes.dtInteger:
					case DataTypes.dtUInteger:
					{
						return AsInteger();
					}
					case DataTypes.dtString:
					{
						int ret = 0;
						try
						{
							ret = int.Parse(AsString());
						}
						catch (Exception) { }
						return ret;
					}
					default:
					{
						return 0;
					}
				} //switch;
			}
			set
			{
				Datatype = DataTypes.dtInteger;
				System.IO.BinaryWriter bw = new System.IO.BinaryWriter(
					new System.IO.MemoryStream()
				);
				bw.Write(value);
				System.IO.BinaryReader br = new System.IO.BinaryReader(bw.BaseStream);
				br.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
				Value = br.ReadBytes((int)br.BaseStream.Length);
			}
		}

		/// <summary>
		/// Returns the value as a Single Floatingpoint (4Bytes)
		/// </summary>
		public float SingleValue
		{
			get
			{
				switch (Datatype)
				{
					case DataTypes.dtSingle:
					{
						return AsSingle();
					}
					case DataTypes.dtInteger:
					case DataTypes.dtUInteger:
					{
						return AsInteger();
					}
					case DataTypes.dtString:
					{
						float ret = 0;
						try
						{
							ret = float.Parse(AsString());
						}
						catch (Exception) { }
						return ret;
					}
					default:
					{
						return 0;
					}
				} //switch;
			}
			set
			{
				Datatype = DataTypes.dtSingle;
				System.IO.BinaryWriter bw = new System.IO.BinaryWriter(
					new System.IO.MemoryStream()
				);
				bw.Write(value);
				System.IO.BinaryReader br = new System.IO.BinaryReader(bw.BaseStream);
				br.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
				Value = br.ReadBytes((int)br.BaseStream.Length);
			}
		}

		/// <summary>
		/// Returns the value as a Boolean
		/// </summary>
		public bool BooleanValue
		{
			get
			{
				switch (Datatype)
				{
					case DataTypes.dtSingle:
					{
						return AsSingle() != 0.0;
					}
					case DataTypes.dtInteger:
					case DataTypes.dtUInteger:
					{
						return AsInteger() != 0;
					}
					case DataTypes.dtString:
					{
						bool ret = false;
						try
						{
							ret = byte.Parse(AsString()) != 0;
						}
						catch (Exception) { }
						return ret;
					}
					case DataTypes.dtBoolean:
					{
						return AsBoolean();
					}
					default:
					{
						return false;
					}
				} //switch;
			}
			set
			{
				Datatype = DataTypes.dtBoolean;
				System.IO.BinaryWriter bw = new System.IO.BinaryWriter(
					new System.IO.MemoryStream()
				);
				bw.Write(value);
				System.IO.BinaryReader br = new System.IO.BinaryReader(bw.BaseStream);
				br.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
				Value = br.ReadBytes((int)br.BaseStream.Length);
			}
		}

		/// <summary>
		/// Returns Value as an Object of the defined type
		/// </summary>
		public object ObjectValue
		{
			get
			{
				switch (Datatype)
				{
					case DataTypes.dtUInteger:
					{
						return UIntegerValue;
					}
					case DataTypes.dtInteger:
					{
						return IntegerValue;
					}
					case DataTypes.dtSingle:
					{
						return SingleValue;
					}
					case DataTypes.dtBoolean:
					{
						return BooleanValue;
					}
					default:
					{
						return StringValue;
					}
				}
			}
		}
		#endregion

		#region internal value Handling
		/// <summary>
		/// Interpretes the data as an Integer Value
		/// </summary>
		/// <returns>The Value interpreted as Integer</returns>
		protected int AsInteger()
		{
			try
			{
				System.IO.BinaryReader br = new System.IO.BinaryReader(
					new System.IO.MemoryStream(Value)
				);
				return br.ReadInt32();
			}
			catch (Exception)
			{
				return 0;
			}
		}

		/// <summary>
		/// Interpretes the data as an Integer Value
		/// </summary>
		/// <returns>The Value interpreted as Integer</returns>
		protected uint AsUInteger()
		{
			try
			{
				System.IO.BinaryReader br = new System.IO.BinaryReader(
					new System.IO.MemoryStream(Value)
				);
				return br.ReadUInt32();
			}
			catch (Exception)
			{
				return 0;
			}
		}

		/// <summary>
		/// Interpretes the data as a Boolean Value
		/// </summary>
		/// <returns>The Value interpreted as Boolean</returns>
		protected bool AsBoolean()
		{
			return Value.Length >= 1 && Value[0] == 1;
		}

		/// <summary>
		/// Interpretes the data as an String Value
		/// </summary>
		/// <returns>The Value interpreted as String</returns>
		protected string AsString()
		{
			System.IO.BinaryReader br = new System.IO.BinaryReader(
				new System.IO.MemoryStream(Value)
			);
			try
			{
				string ret = "";
				while (br.PeekChar() != -1)
				{
					ret += br.ReadChar();
				}

				return ret;
			}
			catch (Exception)
			{
				return "";
			}
		}

		/// <summary>
		/// Interpretes the data as a SingleFloat Value
		/// </summary>
		/// <returns>The Value interpreted as Singel</returns>
		protected float AsSingle()
		{
			System.IO.BinaryReader br = new System.IO.BinaryReader(
				new System.IO.MemoryStream(Value)
			);
			try
			{
				return br.ReadSingle();
			}
			catch (Exception)
			{
				return 0;
			}
		}
		#endregion

		#region serialize/unserialize
		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void Unserialize(System.IO.BinaryReader reader)
		{
			//Load Datatype
			Datatype = (DataTypes)reader.ReadUInt32();

			//Load the Name
			int namelength = reader.ReadInt32();
			PlainName = reader.ReadBytes(namelength);

			//Load Value
			int valuelength;
			switch (Datatype)
			{
				case DataTypes.dtString:
				{
					valuelength = reader.ReadInt32();
					break;
				}
				case DataTypes.dtBoolean:
				{
					valuelength = 1;
					break;
				}
				default:
				{
					valuelength = 4;
					break;
				}
			} //switch
			Value = reader.ReadBytes(valuelength);
		}

		/// <summary>
		/// Stores the Data in a Stream
		/// </summary>
		/// <param name="writer"></param>
		internal void Serialize(System.IO.BinaryWriter writer)
		{
			//Store Datatype
			writer.Write((uint)Datatype);

			//Store the Name
			writer.Write((uint)PlainName.Length);
			writer.Write(PlainName);

			//Store the Value
			switch (Datatype)
			{
				case DataTypes.dtString:
				{
					writer.Write((uint)Value.Length);
					writer.Write(Value);
					break;
				}
				default:
				{
					writer.Write(Value);
					break;
				}
			} //switch
		}
		#endregion

		public override string ToString()
		{
			string ret = Name + " (" + Datatype.ToString() + ") = ";

			switch (Datatype)
			{
				case DataTypes.dtUInteger:
				case DataTypes.dtInteger:
				{
					ret += "0x" + Helper.HexString(UIntegerValue);
					break;
				}
				default:
				{
					if (ObjectValue != null)
					{
						ret += ObjectValue.ToString();
					}

					break;
				}
			}

			return ret;
		}

		public void Dispose()
		{
			Value = new byte[0];
			Value = null;
			PlainName = new byte[0];
			PlainName = null;
		}
	}
}
