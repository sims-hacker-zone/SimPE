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

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Represents a PackedFile in SDsc Format
	/// </summary>
	public class ObjLua
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension,
			IMultiplePackedFileWrapper
	{
		enum Endian : byte
		{
			big = 0x0,
			little = 0x1,
		}

		#region Attributes
		public string FileName
		{
			get; set;
		}
		uint resversion;

		uint id;
		byte version;
		Endian byteorder;
		byte intsz;
		byte sztsz;
		byte instsz;

		public byte OpcodeBits
		{
			get; private set;
		}

		public byte ABits
		{
			get; private set;
		}

		public byte BBits
		{
			get; private set;
		}

		public byte CBits
		{
			get; private set;
		}

		public byte NumberSize
		{
			get; private set;
		}
		byte[] sample;

		public ObjLuaFunction Root
		{
			get;
		}
		#endregion

		#region Code Properties
		internal uint OpcodeMaks => (uint)Math.Pow(2, OpcodeBits) - 1;
		internal byte OpcodeShift => 0;

		internal uint AMaks => (uint)Math.Pow(2, ABits) - 1;
		internal byte AShift => (byte)(BShift + BBits);

		internal uint BMaks => (uint)Math.Pow(2, BBits) - 1;
		internal byte BShift => (byte)(CShift + CBits);

		internal uint CMaks => (uint)Math.Pow(2, CBits) - 1;
		internal byte CShift => (byte)(OpcodeShift + OpcodeBits);

		internal int Bias => ((int)Math.Pow(2, BBits + CBits) - 1) / 2;
		#endregion


		#region IWrapper Member
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Object LUA Wrapper",
				"Quaxi",
				"LUA Resources are external Resources, which contain additional SimAntic Scripts.",
				1,
				GetIcon.OpenLua
			);
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.ObjLua();
		}

		public ObjLua()
			: base()
		{
			resversion = 0;
			version = 0x50;
			byteorder = Endian.little;
			intsz = 4;
			sztsz = 4;
			instsz = 4;
			OpcodeBits = 6;
			ABits = 8;
			BBits = 9;
			CBits = 9;
			NumberSize = 8;
			id = 0x61754C1B;
			sample = new byte[] { 0xb6, 0x09, 0x93, 0x68, 0xe7, 0xf5, 0x7d, 0x41 };

			FileName = "";

			Root = new ObjLuaFunction(this);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			resversion = reader.ReadUInt32();
			int ct = reader.ReadInt32();
			FileName = Helper.ToString(reader.ReadBytes(ct));

			UnserializeLua(reader);
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(resversion);
			int ct = FileName.Length;
			writer.Write(ct);
			writer.Write(Helper.ToBytes(FileName, ct));
			SerializeLua(writer);
		}

		public string ToSource()
		{
			try
			{
				System.IO.StreamWriter sw = new System.IO.StreamWriter(
					new System.IO.MemoryStream()
				);
				try
				{
					string[] regs = new string[0xff];
					for (int i = 0; i < regs.Length; i++)
					{
						regs[i] = "";
					}

					Lua.Context cx = new Lua.Context();
					Root.ToSource(sw, cx);
					sw.Flush();

					System.IO.StreamReader sr = new System.IO.StreamReader(
						sw.BaseStream
					);
					sw.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
					return sr.ReadToEnd();
				}
				finally
				{
					sw.Close();
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}

			return "";
		}

		public void ExportLua(string flname)
		{
			try
			{
				System.IO.FileStream fs = System.IO.File.Create(flname);
				System.IO.BinaryWriter writer = new System.IO.BinaryWriter(fs);
				try
				{
					SerializeLua(writer);
				}
				finally
				{
					writer.Close();
					writer = null;
					fs.Close();
					fs.Dispose();
					fs = null;
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		public void ImportLua(string flname)
		{
			try
			{
				System.IO.FileStream fs = System.IO.File.OpenRead(flname);
				System.IO.BinaryReader reader = new System.IO.BinaryReader(fs);
				try
				{
					UnserializeLua(reader);
				}
				finally
				{
					reader.Close();
					reader = null;
					fs.Close();
					fs.Dispose();
					fs = null;
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		protected void UnserializeLua(System.IO.BinaryReader reader)
		{
			id = reader.ReadUInt32();

			version = reader.ReadByte();
			byteorder = (Endian)reader.ReadByte();

			intsz = reader.ReadByte();
			sztsz = reader.ReadByte();
			instsz = reader.ReadByte();

			OpcodeBits = reader.ReadByte();
			ABits = reader.ReadByte();
			BBits = reader.ReadByte();
			CBits = reader.ReadByte();

			NumberSize = reader.ReadByte();
			sample = reader.ReadBytes(sample.Length);

			Root.Unserialize(reader);
		}

		protected void SerializeLua(System.IO.BinaryWriter writer)
		{
			writer.Write(id);

			writer.Write(version);
			writer.Write((byte)byteorder);

			writer.Write(intsz);
			writer.Write(sztsz);
			writer.Write(instsz);

			writer.Write(OpcodeBits);
			writer.Write(ABits);
			writer.Write(BBits);
			writer.Write(CBits);

			writer.Write(NumberSize);
			writer.Write(sample);

			Root.Serialize(writer);
		}

		internal static string ReadString(System.IO.BinaryReader reader)
		{
			int ct = reader.ReadInt32();
			return Helper.ToString(reader.ReadBytes(ct));
		}

		internal static void WriteString(string s, System.IO.BinaryWriter writer)
		{
			if (s.Length >= 0)
			{
				writer.Write((uint)(s.Length + 1));
				writer.Write(Helper.ToBytes(s, s.Length));
				writer.Write((byte)0);
			}
			else
			{
				writer.Write((uint)0);
			}
		}
		#endregion

		#region IPackedFileWrapper Member

		public uint[] AssignableTypes
		{
			get
			{
				uint[] Types = { Data.MetaData.GLUA, Data.MetaData.OLUA };
				return Types;
			}
		}

		public Byte[] FileSignature
		{
			get
			{
				Byte[] sig = { };
				return sig;
			}
		}

		#endregion

		protected override string GetResourceName(Data.TypeAlias ta)
		{
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package);
			}

			return FileName;
		}
	}

	public class ObjLuaFunction : IDisposable, IEnumerable
	{
		internal static bool DEBUG = false;

		#region Attributes
		public ObjLua Parent
		{
			get; private set;
		}

		string name;
		uint linedef;
		byte nups;

		public byte ArgumentCount
		{
			get; private set;
		}
		byte isinout;

		public byte StackSize
		{
			get; private set;
		}

		public ArrayList Constants
		{
			get; private set;
		}

		public ArrayList UpValues
		{
			get;
		}

		public ArrayList Locals
		{
			get;
		}

		public ArrayList SourceLine
		{
			get;
		}

		public ArrayList Functions
		{
			get;
		}

		public ArrayList Codes
		{
			get;
		}
		#endregion

		public ObjLuaFunction(ObjLua parent)
		{
			Parent = parent;
			name = "";

			Constants = new ArrayList();
			Functions = new ArrayList();
			Codes = new ArrayList();
			SourceLine = new ArrayList();
			Locals = new ArrayList();
			UpValues = new ArrayList();
		}

		#region Source Code
		void PrintLine(ArrayList sw, Lua.Context cx, ObjLuaCode line, string plusindent)
		{
			if (line != null)
			{
				string content = "";
				if (line is Lua.IOperator)
				{
					Lua.IOperator lop = line as Lua.IOperator;
					if (DEBUG)
					{
						content = lop.ToString(cx) + " #" + line.GetType().Name;
					}
					else
					{
						content = lop.ToString(cx);
					}

					lop.Run(cx);
				}
				else
				{
					content = line.ToString();
				}

				if (content.Trim() != "")
				{
					if (DEBUG)
					{
						sw.Add(
							Helper.HexString(cx.PC)
								+ ": "
								+ plusindent
								+ cx.Indent
								+ content
						);
					}
					else
					{
						sw.Add(plusindent + cx.Indent + content);
					}
				}
			}
		}

		void AddIndent(ref string indent)
		{
			indent += "\t";
		}

		void BackIndent(ref string indent)
		{
			if (indent.Length > 0)
			{
				indent = indent.Substring(0, indent.Length - 1);
			}
		}

		internal void ToSource(System.IO.StreamWriter writer, Lua.Context cx)
		{
			cx.Init(this);

			ObjLuaCode line = null;
			ArrayList endline = new ArrayList();
			ArrayList elseline = new ArrayList();
			ArrayList oplines = new ArrayList();
			ArrayList sw = new ArrayList();
			string pindent = "";
			for (int i = 0; i < Codes.Count - 1; i++)
			{
				oplines.Add(sw.Count);
				cx.GoToLine(i);
				line = cx.CurrentLine;

				//for loop check
				if (line is Lua.SUB)
				{
					int pc = cx.PC;
					ObjLuaCode nline = cx.NextLine();
					if (nline is Lua.JMP)
					{
						cx.GoToLine(cx.PC + nline.SBX + 1);
						ObjLuaCode fline = cx.CurrentLine;
						if (fline is Lua.FORLOOP)
						{
							cx.GoToLine(pc);
							Lua.FORLOOP fl = fline as Lua.FORLOOP;
							fl.IsStart = true;
							PrintLine(sw, cx, fline, pindent);
							fl.IsStart = false;

							continue;
						}
					}
					cx.GoToLine(pc);
				}

				if (line is Lua.IAddEnd)
				{
					Lua.IAddEnd end = line as Lua.IAddEnd;
					endline.Add(cx.PC + end.Offset);
				}

				if (line is Lua.IIfOperator)
				{
					AddIndent(ref pindent);
					int pc = cx.PC;
					ObjLuaCode oline = line;
					line = cx.NextLine();
					int ifblsz = line.SBX;
					if (ifblsz < 0) //while block
					{
						int npc = (int)oplines[oplines.Count + line.SBX + 1];
						for (int id = npc; id < sw.Count; id++)
						{
							sw[id] = "\t" + sw[id].ToString();
						}

						oline.A = (ushort)Math.Abs(oline.A - 1);
						sw.Insert(
							npc,
							pindent
								+ "while "
								+ ((Lua.IOperator)oline)
									.ToString(cx)
									.Replace("if ", "")
									.Replace(" then", "")
								+ " do"
						);
						oline.A = (ushort)Math.Abs(oline.A - 1);

						BackIndent(ref pindent);
						PrintLine(sw, cx, new Lua.TextLine(0, this, "end"), pindent);

						continue;
					}
					else
					{
						cx.PrepareJumpToLine(cx.PC + ifblsz);
						line = cx.NextLine();
						if (line is Lua.JMP) //having an else Block
						{
							elseline.Add(cx.PC - 1);
							endline.Add(cx.PC + line.SBX);
						}
						else
						{
							endline.Add(cx.PC);
						}
					}

					cx.GoToLine(pc);
					line = cx.CurrentLine;
				}

				PrintLine(sw, cx, line, pindent);

				if (line is Lua.TFORREP)
				{
					int pc = cx.PC;
					ObjLuaCode eline = line;
					while (!(eline is Lua.TFORLOOP))
					{
						eline = cx.NextLine();
					} ((Lua.TFORLOOP)eline).Setup(cx);
					cx.GoToLine(pc);

					((Lua.TFORREP)line).TFORLOOP = eline as Lua.TFORLOOP;
					PrintLine(sw, cx, line, pindent);
					((Lua.TFORREP)line).TFORLOOP = null;
				}

				while (endline.Contains(i))
				{
					BackIndent(ref pindent);
					sw.Add(pindent + cx.Indent + "end");
					endline.Remove(i);
				}
				if (elseline.Contains(i))
				{
					BackIndent(ref pindent);
					sw.Add(pindent + cx.Indent + "else");
					AddIndent(ref pindent);
				}
			}

			foreach (string ln in sw)
			{
				writer.WriteLine(ln);
			}
		}

		internal bool IsLocalRegister(ushort regnr, Lua.Context cx)
		{
			ObjLuaCode line = null;
			for (int i = cx.PC + 1; i < Codes.Count; i++)
			{
				line = Codes[i] as ObjLuaCode;
				if (line != null)
				{
					if (line is Lua.ILoadOperator)
					{
						Lua.ILoadOperator lop = line as Lua.ILoadOperator;
						if (lop.LoadsRegister(regnr))
						{
							return false;
						}
					}
				}
			}

			return true;
		}
		#endregion

		internal void Unserialize(System.IO.BinaryReader reader)
		{
			Constants.Clear();
			Functions.Clear();
			Codes.Clear();
			SourceLine.Clear();
			Locals.Clear();
			UpValues.Clear();

			name = ObjLua.ReadString(reader);

			linedef = reader.ReadUInt32();
			nups = reader.ReadByte();
			ArgumentCount = reader.ReadByte();
			isinout = reader.ReadByte();
			StackSize = reader.ReadByte();

			uint linenfosz = reader.ReadUInt32();
			for (uint i = 0; i < linenfosz; i++)
			{
				ObjLuaSourceLine item = new ObjLuaSourceLine(this);
				item.Unserialize(reader);

				SourceLine.Add(item);
			}

			uint locvarsz = reader.ReadUInt32();
			for (uint i = 0; i < locvarsz; i++)
			{
				ObjLuaLocalVar item = new ObjLuaLocalVar(this);
				item.Unserialize(reader);

				Locals.Add(item);
			}

			uint upvalsz = reader.ReadUInt32();
			for (uint i = 0; i < upvalsz; i++)
			{
				ObjLuaUpValue item = new ObjLuaUpValue(this);
				item.Unserialize(reader);

				UpValues.Add(item);
			}

			uint constsz = reader.ReadUInt32();
			for (uint i = 0; i < constsz; i++)
			{
				ObjLuaConstant item = new ObjLuaConstant(this);
				item.Unserialize(reader);

				Constants.Add(item);
			}

			uint fncsz = reader.ReadUInt32();
			for (uint i = 0; i < fncsz; i++)
			{
				ObjLuaFunction item = new ObjLuaFunction(Parent);
				item.Unserialize(reader);

				Functions.Add(item);
			}

			uint codesz = reader.ReadUInt32();
			for (uint i = 0; i < codesz; i++)
			{
				ObjLuaCode item = ObjLuaCode.Unserialize(reader, this);

				Codes.Add(item);
			}
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			ObjLua.WriteString(name, writer);

			writer.Write(linedef);
			writer.Write(nups);
			writer.Write(ArgumentCount);
			writer.Write(isinout);
			writer.Write(StackSize);

			writer.Write((uint)SourceLine.Count);
			foreach (ObjLuaSourceLine item in SourceLine)
			{
				item.Serialize(writer);
			}

			writer.Write((uint)Locals.Count);
			foreach (ObjLuaLocalVar item in Locals)
			{
				item.Serialize(writer);
			}

			writer.Write((uint)UpValues.Count);
			foreach (ObjLuaUpValue item in UpValues)
			{
				item.Serialize(writer);
			}

			writer.Write((uint)Constants.Count);
			foreach (ObjLuaConstant item in Constants)
			{
				item.Serialize(writer);
			}

			writer.Write((uint)Functions.Count);
			foreach (ObjLuaFunction item in Functions)
			{
				item.Serialize(writer);
			}

			writer.Write((uint)Codes.Count);
			foreach (ObjLuaCode item in Codes)
			{
				item.Serialize(writer);
			}
		}

		#region IDisposable Member

		public void Dispose()
		{
			Parent = null;
			if (Constants != null)
			{
				Constants.Clear();
			}

			Constants = null;
		}

		#endregion

		public override string ToString()
		{
			return name
				+ ": "
				+ ArgumentCount.ToString()
				+ " Arguments, Stacksize "
				+ StackSize.ToString()
				+ ", "
				+ Constants.Count.ToString()
				+ " Constants, "
				+ Functions.Count.ToString()
				+ " SubFunctions, "
				+ Codes.Count.ToString()
				+ " Instructions";
		}

		#region IEnumerable Member

		public IEnumerator GetEnumerator()
		{
			return Constants.GetEnumerator();
		}

		#endregion
	}

	public class ObjLuaConstant : IDisposable
	{
		public enum Type : byte
		{
			Empty = 0x00,
			Number = 0x03,
			String = 0x04,
		}

		#region Attributes
		public ObjLuaFunction Parent
		{
			get; private set;
		}

		public Type InstructionType
		{
			get; set;
		}

		public string String
		{
			get; set;
		}

		public double Value
		{
			get; set;
		}

		uint[] bdata;
		byte[] badd;
		byte[] bheader;

		#endregion

		public ObjLuaConstant(ObjLuaFunction parent)
		{
			Parent = parent;
			String = "";

			bdata = new uint[0];
			badd = new byte[0];
			bheader = new byte[3];
		}

		internal void Unserialize(System.IO.BinaryReader reader)
		{
			InstructionType = (Type)reader.ReadByte();

			String = "";
			bdata = new uint[0];
			badd = new byte[0];
			if (InstructionType == Type.String)
			{
				String = ObjLua.ReadString(reader);
			}
			else if (InstructionType == Type.Number)
			{
				if (Parent.Parent.NumberSize == 8)
				{
					Value = reader.ReadDouble();
				}
				else if (Parent.Parent.NumberSize == 4)
				{
					Value = reader.ReadSingle();
				}
				else
				{
					throw new Exception(
						"Number Size "
							+ Parent.Parent.NumberSize.ToString()
							+ " is not supported!"
					);
				}
			}
			else if (InstructionType == Type.Empty)
			{
			}
			else
			{
				throw new Exception(
					"Unknown Constant Type: 0x"
						+ Helper.HexString((byte)InstructionType)
						+ ", 0x"
						+ Helper.HexString(reader.BaseStream.Position - 0x40)
				);
			}
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write((byte)InstructionType);

			if (InstructionType == Type.String)
			{
				ObjLua.WriteString(String, writer);
			}
			else if (InstructionType == Type.Number)
			{
				if (Parent.Parent.NumberSize == 8)
				{
					writer.Write((double)Value);
				}
				else if (Parent.Parent.NumberSize == 4)
				{
					writer.Write((float)Value);
				}
				else
				{
					throw new Exception(
						"Number Size "
							+ Parent.Parent.NumberSize.ToString()
							+ " is not supported!"
					);
				}
			}
			else if (InstructionType == Type.Empty)
			{
			}
			else
			{
				throw new Exception(
					"Unknown Constant Type: 0x"
						+ Helper.HexString((byte)InstructionType)
						+ ", 0x"
						+ Helper.HexString(writer.BaseStream.Position - 0x40)
				);
			}
		}

		#region IDisposable Member

		public void Dispose()
		{
			Parent = null;
			String = null;

			badd = null;
			bheader = null;
			bdata = null;
		}

		#endregion

		public override string ToString()
		{
			string s = InstructionType.ToString() + ": ";
			if (InstructionType == Type.String)
			{
				s += String;
			}
			else if (InstructionType == Type.Number)
			{
				s += Value.ToString();
			}

			return s;
		}
	}

	public class ObjLuaSourceLine : IDisposable
	{
		#region Attributes
		ObjLuaFunction parent;

		public uint Value
		{
			get; set;
		}

		#endregion

		public ObjLuaSourceLine(ObjLuaFunction parent)
		{
			this.parent = parent;
		}

		internal void Unserialize(System.IO.BinaryReader reader)
		{
			Value = reader.ReadUInt32();
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(Value);
		}

		#region IDisposable Member

		public void Dispose()
		{
		}

		#endregion

		public override string ToString()
		{
			return "0x" + Helper.HexString(Value);
		}
	}

	public class ObjLuaLocalVar : IDisposable
	{
		#region Attributes
		ObjLuaFunction parent;

		public uint Start
		{
			get; set;
		}

		public uint End
		{
			get; set;
		}

		public string Name
		{
			get; set;
		}

		#endregion

		public ObjLuaLocalVar(ObjLuaFunction parent)
		{
			this.parent = parent;
			Name = "";
		}

		internal void Unserialize(System.IO.BinaryReader reader)
		{
			Name = ObjLua.ReadString(reader);
			Start = reader.ReadUInt32();
			End = reader.ReadUInt32();
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			ObjLua.WriteString(Name, writer);
			writer.Write(Start);
			writer.Write(End);
		}

		#region IDisposable Member

		public void Dispose()
		{
			Name = null;
		}

		#endregion

		public override string ToString()
		{
			return Name
				+ ": 0x"
				+ Helper.HexString(Start)
				+ " - 0x"
				+ Helper.HexString(End);
		}
	}

	public class ObjLuaUpValue : ObjLuaSourceLine
	{
		public ObjLuaUpValue(ObjLuaFunction parent)
			: base(parent) { }
	}

	public class ObjLuaCode : IDisposable
	{
		static Hashtable ocmap;

		protected static void PrepareOpcodeMap()
		{
			ocmap = new Hashtable
			{
				["MOVE"] = typeof(Lua.MOVE),
				["LOADNIL"] = typeof(Lua.LOADNIL),
				["LOADK"] = typeof(Lua.LOADK),
				["LOADBOOL"] = typeof(Lua.LOADBOOL),
				["SETGLOBAL"] = typeof(Lua.SETGLOBAL),
				["GETGLOBAL"] = typeof(Lua.GETGLOBAL),
				["CALL"] = typeof(Lua.CALL),
				["CLOSURE"] = typeof(Lua.CLOSURE),
				["CONCAT"] = typeof(Lua.CONCAT),
				["NEWTABLE"] = typeof(Lua.NEWTABLE),
				["SELF"] = typeof(Lua.SELF),
				["SETTABLE"] = typeof(Lua.SETTABLE),
				["TEST"] = typeof(Lua.TEST),
				["TFORLOOP"] = typeof(Lua.TFORLOOP),
				["TFORREP"] = typeof(Lua.TFORREP),
				["FORLOOP"] = typeof(Lua.FORLOOP),
				["GETTABLE"] = typeof(Lua.GETTABLE),
				["RETURN"] = typeof(Lua.RETURN),
				["ADD"] = typeof(Lua.ADD),
				["SUB"] = typeof(Lua.SUB),
				["MUL"] = typeof(Lua.MUL),
				["POW"] = typeof(Lua.POW),
				["DIV"] = typeof(Lua.DIV),
				["UNM"] = typeof(Lua.UNM),
				["NOT"] = typeof(Lua.NOT),
				["GETUPVAL"] = typeof(Lua.GETUPVAL),

				["JMP"] = typeof(Lua.JMP),
				["EQ"] = typeof(Lua.EQ),
				["LE"] = typeof(Lua.LE),
				["GE"] = typeof(Lua.GE),
				["LT"] = typeof(Lua.LT),
				["GT"] = typeof(Lua.GT)
			};
		}

		protected static Type GetOpcodeType(byte opcode)
		{
			PrepareOpcodeMap();
			string n = GetOpcodeName(opcode);
			Type t = ocmap[n] as Type;

			if (t == null)
			{
				return typeof(ObjLuaCode);
			}

			return t;
		}

		public static ObjLuaCode CreateOperator(uint val, ObjLuaFunction parent)
		{
			byte oc = GetOpCode(val, parent);
			Type t = GetOpcodeType(oc);

			ObjLuaCode ret = (ObjLuaCode)
				Activator.CreateInstance(t, new object[] { val, parent });
			return ret;
		}

		public const int RK_OFFSET = 250;
		#region OpCodes
		static string[] opcodes = new string[]
		{
			"MOVE",
			"LOADK",
			"LOADBOOL",
			"LOADNIL",
			"GETUPVAL",
			"GETGLOBAL",
			"GETTABLE",
			"SETGLOBAL",
			"SETUPVAL",
			"SETTABLE",
			"NEWTABLE",
			"SELF",
			"ADD",
			"SUB",
			"MUL",
			"DIV",
			"POW",
			"UNM",
			"NOT",
			"CONCAT",
			"JMP",
			"EQ",
			"LT",
			"LE",
			"TEST",
			"CALL",
			"TAILCALL",
			"RETURN",
			"FORLOOP",
			"TFORLOOP",
			"TFORREP",
			"SETLIST",
			"SETLISTO",
			"CLOSE",
			"CLOSURE",
		};
		static string[] opcodedesc = new string[]
		{
			"Copy a value between registers",
			"Load a constant into a register",
			"Load a boolean into a register",
			"Load null values into a range of registers",
			"Read an upvalue into a register",
			"Read a global variable into a register",
			"Read a table element into a register",
			"Write a register value into a global variable",
			"Write a register value into an upvalue",
			"Write a register value into a table element",
			"Create a new table",
			"Prepare an object method for calling",
			"Addition",
			"Subtraction",
			"Multiplication",
			"Division",
			"Exponentiation",
			"Unary minus",
			"Logical NOT",
			"Concatenate a range of registers",
			"Unconditional jump",
			"Equality test",
			"Less than test",
			"Less than or equal to test",
			"Test for short-circuit logical and and or evaluation",
			"Call a closure",
			"Perform a tail call",
			"Return from function call",
			"Iterate a numeric for loop",
			"Iterate a generic for loop",
			"Initialization for a generic for loop",
			"Set a range of array elements for a table",
			"Set a variable number of table elements",
			"Close a range of locals being used as upvalues",
			"Create a closure of a function prototype",
		};

		#endregion

		#region Attributes

		protected ObjLuaFunction Parent
		{
			get;
		}

		public uint Value
		{
			get; set;
		}

		protected static byte GetOpCode(uint val, ObjLuaFunction parent)
		{
			return (byte)(
				(val & (parent.Parent.OpcodeMaks << parent.Parent.OpcodeShift))
				>> parent.Parent.OpcodeShift
			);
		}

		protected void SetOpcode(byte oc)
		{
			Value = (

					Value
					& (
						0xFFFFFFFF
						- (Parent.Parent.OpcodeMaks << Parent.Parent.OpcodeShift)
					)
				 | (oc & Parent.Parent.OpcodeMaks) << Parent.Parent.OpcodeShift
			);
		}

		public byte Opcode => GetOpCode(Value, Parent);

		public ushort A
		{
			get => (ushort)(
					(Value & (Parent.Parent.AMaks << Parent.Parent.AShift))
					>> Parent.Parent.AShift
				);
			set => Value = (

						Value
						& (0xFFFFFFFF - (Parent.Parent.AMaks << Parent.Parent.AShift))
					 | (value & Parent.Parent.AMaks) << Parent.Parent.AShift
				);
		}

		public ushort B
		{
			get => (ushort)(
					(Value & (Parent.Parent.BMaks << Parent.Parent.BShift))
					>> Parent.Parent.BShift
				);
			set => Value = (

						Value
						& (0xFFFFFFFF - (Parent.Parent.BMaks << Parent.Parent.BShift))
					 | (value & Parent.Parent.BMaks) << Parent.Parent.BShift
				);
		}

		public ushort C
		{
			get => (ushort)(
					(Value & (Parent.Parent.CMaks << Parent.Parent.CShift))
					>> Parent.Parent.CShift
				);
			set => Value = (

						Value
						& (0xFFFFFFFF - (Parent.Parent.CMaks << Parent.Parent.CShift))
					 | (value & Parent.Parent.CMaks) << Parent.Parent.CShift
				);
		}

		public uint BX => ((B & Parent.Parent.BMaks) << Parent.Parent.CBits)
					| (C & Parent.Parent.CMaks);

		public int SBX => (int)(BX - Parent.Parent.Bias);

		public static string GetOpcodeName(byte oc)
		{
			if (oc >= 0 && oc < opcodes.Length)
			{
				return opcodes[oc];
			}
			else
			{
				return "UNK_" + Helper.HexString(oc);
			}
		}

		public static string GetOpcodeDescription(byte oc)
		{
			if (oc >= 0 && oc < opcodedesc.Length)
			{
				return opcodedesc[oc];
			}
			else
			{
				return Localization.GetString("Unknown");
			}
		}

		#endregion

		#region Opcode Translation

		string TranslateOpcode(byte oc, ushort a, ushort b, ushort c)
		{
			uint bx = BX;
			int sbx = SBX;

			string name = GetOpcodeName(oc);
			string ret = "";
			//if (name=="MOVE") ret =  R(a) + " = " + R(b);
			//else if (name=="LOADNIL") ret = ListR(a, b, " = ", " = ... = ")+"null";
			//else if (name=="LOADK") ret = R(a) +" = " + Kst(bx);
			//if (name=="LOADBOOL") ret = R(a) + " = " + Bool(b) +"; if ("+Bool(c)+") PC++";
			//else if (name=="GETGLOBAL") ret = R(a) + " = " + Gbl(Kst(bx));
			//else if (name=="SETGLOBAL") ret = Gbl(Kst(bx)) + " = " + R(a);
			//else if (name=="GETUPVAL") ret = R(a) + " = " + UpValue(b);
			if (name == "SETUPVAL")
			{
				ret = UpValue(b) + " = " + R(a);
			}
			//else if (name=="GETTABLE") ret = R(a) + " = " + R(b)+"["+RK(c)+"]";
			//else if (name=="SETTABLE") ret = R(a)+"["+RK(b)+"]" + " = " + RK(c);
			//else if (name=="ADD") ret = R(a) + " = " + RK(b) + " + " + RK(c);
			//else if (name=="SUB") ret = R(a) + " = " + RK(b) + " - " + RK(c);
			//else if (name=="MUL") ret = R(a) + " = " + RK(b) + " * " + RK(c);
			//else if (name=="DIV") ret = R(a) + " = " + RK(b) + " / " + RK(c);
			//else if (name=="POW") ret = R(a) + " = " + RK(b) + " ^ " + RK(c);
			//else if (name=="UNM") ret = R(a) + " = -" + R(b);
			//else if (name=="NOT") ret = R(a) + " = !" + R(b);
			//else if (name=="CONCAT") ret = R(a) + " = " + ListR(b, c);
			//else if (name=="JMP") ret = " PC += " + sbx.ToString();
			//else if (name=="CALL") ret = ListR(a, a+c-2, " = ", ", ..., ") + R(a) + "(" + ListR(a+1, a+b-1, "", ", ..., ") + ")";
			//else if (name=="RETURN") ret = "return " + ListR(a, a+b-2, "", ", ..., ");
			else if (name == "TAILCALL")
			{
				ret =
					"return "
					+ R(a)
					+ "("
					+ ListR(a + 1, a + b - 1, "", ", ..., ")
					+ ")";
			}
			//else if (name=="SELF") ret = R((ushort)(a+1)) + " = " + R(b) + "; " + R(a) + " = " + R(b) + "["+RK(c)+"]";
			//else if (name=="EQ") ret = "if ((" + RK(b) + " == " + RK(c) + ") == " + Bool(a) + " then PC++";
			//else if (name=="LT") ret = "if ((" + RK(b) + " < " + RK(c) + ") == " + Bool(a) + " then PC++";
			//else if (name=="LE") ret = "if ((" + RK(b) + " <= " + RK(c) + ") == " + Bool(a) + " then PC++";
			//else if (name=="TEST") ret = "if (" + R(b) + " <=> " + c.ToString() + ") then " + R(a) + " = " + R(b) + " else PC++";
			//else if (name=="FORLOOP") ret = R(a) + " += " + R((ushort)(a+2)) + "; if " + R(a) + " <= " +  R((ushort)(a+1)) + " then PC += " + sbx.ToString();
			//else if (name=="TFORREP") ret = "if type("+R(a)+") == table then " + R((ushort)(a+1)) + " = " + R(a) + "; " + R(a) + "= next; PC += " + sbx.ToString();
			//else if (name=="TFORLOOP") ret = R((ushort)(a+2)) + ", ..., " + R((ushort)(a+2+c)) + " = " + R(a) + "("+R(a)+", "+R((ushort)(a+2))+"); if " +  R((ushort)(a+2)) + " == null then PC++";
			//else if (name=="NEWTABLE") ret = R(a) + " = new table["+TblFbp(b)+", "+TblSz(c)+"]";
			//else if (name=="CLOSURE") ret = R(a) + " = closure(KPROTO["+bx.ToString()+"], "+R(a)+", ...)";
			else if (name == "CLOSE")
			{
				ret = "close all to " + R(a);
			}

			if (ObjLuaFunction.DEBUG)
			{
				if (Helper.WindowsRegistry.HiddenMode)
				{
					return ret + "; //" + name;
				}
				else
				{
					return ret + "; //" + name + ": " + GetOpcodeDescription(oc);
				}
			}
			else
			{
				if (Helper.WindowsRegistry.HiddenMode)
				{
					return ret + "; //" + name;
				}
				else
				{
					return ret + "; //" + GetOpcodeDescription(oc);
				}
			}
			//return ret+"; //"+name+" (a=0x"+Helper.HexString(a)+", b=0x"+Helper.HexString(b)+", c=0x"+Helper.HexString(c)+", bx="+bx.ToString()+", sbx="+sbx.ToString()+") "+GetOpcodeDescription(oc);
		}

		protected static string R(ushort v, string[] regs, bool use)
		{
			if (use)
			{
				return R(v, regs);
			}
			else
			{
				return R(v);
			}
		}

		protected static string R(ushort v)
		{
			return "{R" + v.ToString() + "}";
		}

		protected static string R(ushort v, string[] regs)
		{
			if (regs[v] == null)
			{
				return "null";
			}

			return regs[v];
		}

		protected string RK(ushort v)
		{
			if (v < RK_OFFSET)
			{
				return R(v);
			}
			else
			{
				return (Kst((uint)(v - RK_OFFSET)));
			}
		}

		protected string Kst(uint v)
		{
			if (v >= 0 && v < Parent.Constants.Count)
			{
				ObjLuaConstant oci = (ObjLuaConstant)Parent.Constants[(int)v];
				if (oci.InstructionType == ObjLuaConstant.Type.String)
				{
					return oci.String;
				}
				else if (oci.InstructionType == ObjLuaConstant.Type.Number)
				{
					return oci.Value.ToString();
				}
				else
				{
					return "null";
				}
			}
			return v.ToString();
		}

		protected string UpValue(ushort v)
		{
			if (v >= 0 && v < Parent.UpValues.Count)
			{
				return Parent.UpValues[v].ToString();
			}

			return v.ToString();
		}

		protected static string Bool(ushort v)
		{
			if (v == 0)
			{
				return "false";
			}
			else
			{
				return "true";
			}
		}

		protected static string Gbl(string n)
		{
			return "GLOBAL[" + n + "]";
		}

		protected static string Tbl(ushort v)
		{
			return "Tbl" + v.ToString();
		}

		protected static string TblFbp(ushort v)
		{
			return Lua.Context.TblFbp(v).ToString();
		}

		protected static string TblSz(ushort v)
		{
			return Lua.Context.TblSz(v).ToString();
		}

		protected static string ListR(int start, int end)
		{
			return ListR(start, end, "", " ... ");
		}

		protected static string ListR(int start, int end, string prefix, string infix)
		{
			if (end < start)
			{
				return "";
			}

			if (end == start)
			{
				return R((ushort)start) + prefix;
			}

			return R((ushort)start) + infix + R((ushort)end) + prefix;
		}

		#endregion

		public ObjLuaCode(ObjLuaFunction parent)
			: this(0, parent) { }

		public ObjLuaCode(uint val, ObjLuaFunction parent)
		{
			Parent = parent;
			Value = val;
		}

		internal static ObjLuaCode Unserialize(
			System.IO.BinaryReader reader,
			ObjLuaFunction parent
		)
		{
			uint val = reader.ReadUInt32();
			ObjLuaCode ret = CreateOperator(val, parent);
			return ret;
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(Value);
		}

		#region IDisposable Member

		public void Dispose()
		{
		}

		#endregion

		public override string ToString()
		{
			return /*"0x"+Helper.HexString(val)+": "+*/
			TranslateOpcode(Opcode, A, B, C);
		}
	}
}
