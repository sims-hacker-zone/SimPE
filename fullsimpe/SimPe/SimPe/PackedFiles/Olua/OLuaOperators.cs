// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;

namespace SimPe.PackedFiles.Olua
{
	class Convert
	{
		public static double ToDouble(object o)
		{
			try
			{
				return System.Convert.ToDouble(o);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex + "\n\t Value was " + o.ToString());
			}
			return 0;
		}

		public static bool ToBoolean(object o)
		{
			try
			{
				return System.Convert.ToBoolean(o);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex + "\n\t Value was " + o.ToString());
			}
			return false;
		}
	}

	class Global
	{
		string name;

		public Global(string name, object val)
		{
			this.name = name;
			Value = val;
		}

		public object Value
		{
			get; set;
		}

		public override string ToString()
		{
			return name;
		}
	}

	class Table
	{
		Hashtable data;
		int sz0,
			sz1;

		public Table(int sz0, int sz1)
		{
			this.sz0 = sz0;
			this.sz1 = sz1;
			data = new Hashtable();
		}

		public override string ToString()
		{
			return "{}";
		}

		public object this[object index]
		{
			get => data[index];
			set
			{
				object o = value ?? Context.Nil;

				data[index] = o;
			}
		}
	}

	class Context : IDisposable
	{
		class NULL
		{
			public override string ToString()
			{
				return "nil";
			}
		}

		public Context CreateSubContext(ObjLuaFunction fkt, out string paramlist)
		{
			Context c = new Context(globals, Indent + "\t");

			paramlist = "";
			if (fkt != null)
			{
				int lc = 0;
				for (int i = 0; i < fkt.ArgumentCount; i++)
				{
					if (i > 0)
					{
						paramlist += ", ";
					}

					paramlist += "param" + i;

					c.ForceDefineLocal((ushort)lc, "param" + i);
					c.SetLocal((ushort)lc, 0.0);
					lc++;
				}

				/*for (int i=0; i<fkt.StackSize; i++)
				{
					c.ForceDefineLocal((ushort)lc, "stack"+i);
					c.SetLocal((ushort)lc, 0.0);
					lc++;
				}*/
			}

			return c;
		}

		static NULL nil = new NULL();
		public static object Nil => nil;

		object[] regs;
		string[] sregs;
		Hashtable globals,
			localnames;

		public string Indent
		{
			get;
		}

		public Context()
			: this(new Hashtable(), "") { }

		Context(Hashtable globals, string indent)
		{
			PC = 0;
			regs = new object[0xff];
			sregs = new string[regs.Length];

			for (int i = 0; i < regs.Length; i++)
			{
				sregs[i] = "{R" + i + "}";
				regs[i] = nil;
			}

			this.globals = globals;
			localnames = new Hashtable();
			Indent = indent;
		}

		public void SetSReg(ushort nr, string val)
		{
			if (val == null)
			{
				val = "{R" + nr + "}";
			}

			sregs[nr] = val;
		}

		public void SetReg(ushort nr, object val)
		{
			if (val == null)
			{
				val = nil;
			}

			regs[nr] = val;
		}

		public Table LoadTable(ushort regnr)
		{
			object o = R(regnr);
			if (o is Global)
			{
				o = ((Global)o).Value;
			}

			return o as Table;
		}

		public object LoadTable(ushort regnr, object index)
		{
			Table tbl = LoadTable(regnr);
			return tbl == null ? Nil : tbl[index];
		}

		public void SetTable(ushort regnr, object index, object val)
		{
			Table tbl = LoadTable(regnr);
			if (tbl != null)
			{
				tbl[index] = val;
			}
		}

		public void SetGlobal(string name, object val)
		{
			if (val == null)
			{
				val = nil;
			}

			object o = globals[name];
			if (o == null)
			{
				globals[name] = new Global(name, val);
			}
			else
			{
				((Global)o).Value = val;
			}
		}

		public void DefineLocal(ushort regnr)
		{
			DefineLocal(regnr, "myvar_" + regnr);
		}

		public void DefineLocal(ushort regnr, string name)
		{
			if (parent.IsLocalRegister(regnr, this))
			{
				ForceDefineLocal(regnr, name);
			}
		}

		void ForceDefineLocal(ushort regnr, string name)
		{
			localnames[name] = regnr;
			localnames[regnr] = name;
		}

		public void SetLocal(ushort regnr, object val)
		{
			if (!IsLocal(regnr))
			{
				DefineLocal(regnr);
			}

			if (IsLocal(regnr))
			{
				SetSReg(regnr, LocalName(regnr));
			}

			SetReg(regnr, val);
		}

		public bool IsLocal(ushort regnr)
		{
			return localnames[regnr] != null;
		}

		public string LocalName(ushort regnr)
		{
			if (!IsLocal(regnr))
			{
				DefineLocal(regnr);
			}

			return localnames[regnr].ToString();
		}

		public string SR(ushort val)
		{
			return IsLocal(val) ? LocalName(val) : sregs[val];
		}

		public string SRK(ushort v)
		{
			return v < ObjLuaCode.RK_OFFSET ? SR(v) : SKst((uint)(v - ObjLuaCode.RK_OFFSET));
		}

		public object R(ushort val)
		{
			//if (IsLocal(val)) return LocalName(val);
			return regs[val];
		}

		public object RK(ushort v)
		{
			return v < ObjLuaCode.RK_OFFSET ? R(v) : Kst((uint)(v - ObjLuaCode.RK_OFFSET));
		}

		public object Gbl(object name)
		{
			if (name == null)
			{
				name = nil;
			}

			return globals[name] == null ? name.ToString() : ((Global)globals[name]).Value;
		}

		public string SKst(uint v)
		{
			if (v >= 0 && v < parent.Constants.Count)
			{
				ObjLuaConstant oci = (ObjLuaConstant)parent.Constants[(int)v];
				return oci.InstructionType == ObjLuaConstant.Type.String
					? "\"" + oci.String.Replace("\\", "\\\\") + "\""
					: oci.InstructionType == ObjLuaConstant.Type.Number ? oci.Value.ToString() : nil.ToString();
			}
			return v.ToString();
			;
		}

		public bool Bool(ushort v)
		{
			return v != 0;
		}

		public object Kst(uint v)
		{
			if (v >= 0 && v < parent.Constants.Count)
			{
				ObjLuaConstant oci = (ObjLuaConstant)parent.Constants[(int)v];
				return oci.InstructionType == ObjLuaConstant.Type.String
					? oci.String
					: oci.InstructionType == ObjLuaConstant.Type.Number ? oci.Value : (object)nil;
			}
			return v.ToString();
		}

		public static int TblFbp(ushort v)
		{
			int m = (v & 0x00F8) >> 3;
			int b = v & 0x0007;

			double d = b * Math.Pow(2, m);
			return (int)Math.Round(d);
		}

		public static int TblSz(ushort v)
		{
			return (int)(Math.Log(5, 2) + 1);
		}

		public bool HasUpValue(ushort v)
		{
			return v >= 0 && v < parent.UpValues.Count;
		}

		public double UpValue(ushort v)
		{
			return HasUpValue(v) ? Convert.ToDouble(parent.UpValues[v]) : 0;
		}

		public string ListR(int start, int end, string prefix)
		{
			return ListR(start, end, ", ", prefix);
		}

		public string ListR(int start, int end, string infix, string prefix)
		{
			if (end < start)
			{
				return "";
			}
			else
			{
				string ret = "";
				for (int i = start; i <= end; i++)
				{
					if (i > start)
					{
						ret += infix;
					}

					ret += R((ushort)i);
				}

				return ret + prefix;
			}
		}

		public string ListSR(int start, int end, string prefix)
		{
			return ListSR(start, end, ", ", prefix);
		}

		public string ListSR(int start, int end, string infix, string prefix)
		{
			if (end < start)
			{
				return "";
			}
			else
			{
				string ret = "";
				for (int i = start; i <= end; i++)
				{
					if (i > start)
					{
						ret += infix;
					}

					ret += SR((ushort)i);
				}

				return ret + prefix;
			}
		}

		public ObjLuaFunction KProto(uint nr)
		{
			return nr < 0 || nr >= parent.Functions.Count ? null : parent.Functions[(int)nr] as ObjLuaFunction;
		}

		#region Used to iterate through the Codelines
		ObjLuaFunction parent;

		internal void Init(ObjLuaFunction parent)
		{
			this.parent = parent;
			PC = -1;
		}

		public int PC
		{
			get; private set;
		}

		public ObjLuaCode CurrentLine => PC >= 0 && PC < parent.Codes.Count ? parent.Codes[PC] as ObjLuaCode : null;

		public ObjLuaCode NextLine()
		{
			PC++;
			return CurrentLine;
		}

		public void PrepareJumpToEnd()
		{
			PC = GoToLastLine();
		}

		public void PrepareJumpToLine(int linenr)
		{
			PC = GoToLine(linenr) - 1;
		}

		internal int GoToLastLine()
		{
			return GoToLine(parent.Codes.Count - 1);
		}

		internal int GoToLine(int linenr)
		{
			PC = linenr;
			return PC;
		}
		#endregion

		#region IDisposable Member

		public void Dispose()
		{
			regs = null;
			globals = null;
			localnames = null;
			sregs = null;
		}

		#endregion
	}

	interface IOperator
	{
		void Run(Context cx);
		string ToString(Context cx);
	}

	interface ILoadOperator
	{
		bool LoadsRegister(ushort regnr);
	}

	interface IIfOperator
	{
	}

	interface IAddEnd
	{
		int Offset
		{
			get;
		}
	}

	abstract class Operator : ObjLuaCode
	{
		public Operator(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public virtual string ToString(Context cx)
		{
			return ToString();
		}

		protected string Assign(ushort reg, Context cx, object val)
		{
			return cx.IsLocal(reg)
				? cx.LocalName(reg) + " = " + val
				: R(reg).ToString().StartsWith("{R") ? !ObjLuaFunction.DEBUG ? "" : "// " + R(reg) + " = " + val : R(reg) + " = " + val;
		}

		protected string AssignA(Context cx, object val)
		{
			return Assign(A, cx, val);
		}

		protected abstract string ToAsmString();

		public override string ToString()
		{
			return Helper.WindowsRegistry.Config.HiddenMode ? GetType().Name + ": " + ToAsmString() : ToAsmString();
		}
	}

	class MOVE : Operator, IOperator
	{
		public MOVE(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetReg(A, cx.R(B));
			cx.SetSReg(A, cx.SR(B));
		}

		public override string ToString(Context cx)
		{
			return A == B ? !ObjLuaFunction.DEBUG ? "" : "/// " + AssignA(cx, cx.SR(B)) : AssignA(cx, cx.SR(B));
		}

		protected override string ToAsmString()
		{
			return R(A) + " = " + R(B);
		}
	}

	class LOADNIL : Operator, IOperator
	{
		public LOADNIL(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			for (ushort i = A; i <= B; i++)
			{
				cx.SetReg(i, Context.Nil);
				cx.SetSReg(i, Context.Nil.ToString());
			}
		}

		public override string ToString(Context cx)
		{
			bool haslocal = false;
			for (ushort i = A; i <= B; i++)
			{
				if (cx.IsLocal(i))
				{
					haslocal = true;
					break;
				}
			}

			if (!ObjLuaFunction.DEBUG && !haslocal)
			{
				return "";
			}

			string pref = "";
			if (!haslocal)
			{
				pref = "// ";
			}

			return pref + cx.ListSR(A, B, " = ") + Context.Nil.ToString();
		}

		protected override string ToAsmString()
		{
			return ListR(A, B, " = ", " , ..., ") + Context.Nil.ToString();
		}

		#region ILoadOperator Member

		public bool LoadsRegister(ushort regnr)
		{
			return regnr == A || regnr > A && regnr <= B;
		}
		#endregion
	}

	class LOADK : Operator, IOperator, ILoadOperator
	{
		public LOADK(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetLocal(A, cx.Kst(BX));
			cx.SetSReg(A, cx.SKst(BX));
		}

		public override string ToString(Context cx)
		{
			if (!cx.IsLocal(A))
			{
				cx.DefineLocal(A); //this fails, if this Register is used otherwise later
			}

			return cx.IsLocal(A) ? "local " + cx.SR(A) + " = " + cx.SKst(BX) : !ObjLuaFunction.DEBUG ? "" : "// " + R(A) + " = " + cx.SKst(BX);
		}

		protected override string ToAsmString()
		{
			return R(A) + " = " + Kst(BX);
		}

		#region ILoadOperator Member

		public bool LoadsRegister(ushort regnr)
		{
			return A == regnr;
		}

		#endregion
	}

	class SETGLOBAL : Operator, IOperator
	{
		public SETGLOBAL(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetGlobal(Kst(BX), cx.R(A));
		}

		public override string ToString(Context cx)
		{
			object o = cx.R(A);
			return o is ObjLuaFunction ? cx.SR(A).Replace("{{name}}", Kst(BX)) : Kst(BX) + " = " + cx.SR(A);
		}

		protected override string ToAsmString()
		{
			return Gbl(Kst(BX)) + " = " + R(A);
		}
	}

	class GETGLOBAL : Operator, IOperator, ILoadOperator
	{
		public GETGLOBAL(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetReg(A, cx.Gbl(cx.Kst(BX)));
			cx.SetSReg(A, Kst(BX));
		}

		public override string ToString(Context cx)
		{
			return !ObjLuaFunction.DEBUG ? "" : "// " + R(A) + " = " + cx.Kst(BX);
		}

		protected override string ToAsmString()
		{
			return R(A) + " = " + Gbl(Kst(BX));
		}

		#region ILoadOperator Member

		public bool LoadsRegister(ushort regnr)
		{
			return A == regnr;
		}

		#endregion
	}

	class NEWTABLE : Operator, IOperator, ILoadOperator
	{
		public NEWTABLE(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetReg(A, new Table(Context.TblFbp(B), Context.TblSz(C)));
			if (cx.IsLocal(A))
			{
				cx.SetSReg(A, cx.LocalName(A) + "[]");
			}
			else
			{
				cx.SetSReg(A, "{}");
			}
		}

		public override string ToString(Context cx)
		{
			return !ObjLuaFunction.DEBUG ? "" : "// " + R(A) + " =new table[" + TblFbp(B) + ", " + TblSz(C) + "]";
		}

		protected override string ToAsmString()
		{
			return R(A) + " =new table[" + TblFbp(B) + ", " + TblSz(C) + "]";
		}

		#region ILoadOperator Member

		public bool LoadsRegister(ushort regnr)
		{
			return A == regnr;
		}

		#endregion
	}

	class SETTABLE : Operator, IOperator, ILoadOperator
	{
		public SETTABLE(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetTable(A, cx.RK(B), cx.RK(C));
		}

		public override string ToString(Context cx)
		{
			object o = cx.RK(C);
			if (o is ObjLuaFunction)
			{
				string s = cx.SRK(C).Replace("{{name}}", "function_" + cx.PC);
				s += "\n" + cx.Indent;
				s += cx.SR(A) + "[" + cx.SRK(B) + "]" + " = " + "function_" + cx.PC;
				return s;
			}
			else
			{
				return cx.SR(A) + "[" + cx.SRK(B) + "]" + " = " + cx.SRK(C);
			}
		}

		protected override string ToAsmString()
		{
			return R(A) + "[" + RK(B) + "]" + " = " + RK(C);
		}

		#region ILoadOperator Member

		public bool LoadsRegister(ushort regnr)
		{
			return A == regnr;
		}

		#endregion
	}

	class GETTABLE : Operator, IOperator, ILoadOperator
	{
		public GETTABLE(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetReg(A, cx.LoadTable(B, cx.RK(C)));
			cx.SetSReg(A, cx.SR(B) + "[" + cx.SRK(C) + "]");
		}

		public override string ToString(Context cx)
		{
			/*if (!ObjLuaFunction.DEBUG)	return "";
			return "// " + R(A) + " = " + cx.SR(B)+"["+cx.SRK(C)+"]";*/

			return AssignA(cx, cx.SR(B) + "[" + cx.SRK(C) + "]");
		}

		protected override string ToAsmString()
		{
			return R(A) + " = " + R(B) + "[" + RK(C) + "]";
		}

		#region ILoadOperator Member

		public bool LoadsRegister(ushort regnr)
		{
			return A == regnr;
		}

		#endregion
	}

	class CALL : Operator, IOperator
	{
		public CALL(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			//cx.SetReg(this.A, cx.R(this.B));
			for (int i = A; i <= A + C - 2; i++)
			{
				cx.SetReg((ushort)i, Context.Nil);
				cx.SetSReg(
					(ushort)i,
					cx.SR(A) + "(" + cx.ListSR(A + 1, A + B - 1, "") + ")" /*+".Result["+i+"]"*/
				);
			}
		}

		public override string ToString(Context cx)
		{
			string content = cx.SR(A) + "(" + cx.ListSR(A + 1, A + B - 1, "") + ")";
			bool haslocal = false;
			for (ushort i = A; i <= A + C - 2; i++)
			{
				if (!cx.IsLocal(i))
				{
					cx.DefineLocal(i); //this fails, if this Register is used otherwise later
				}

				if (cx.IsLocal(i))
				{
					haslocal = true;
				}
			}

			if (A <= A + C - 2)
			{
				if (!haslocal)
				{
					return !ObjLuaFunction.DEBUG ? "" : "// " + ListR(A, A + C - 2, " = ", ", ... ,") + content;
				}
				else
				{
					string ret = "";
					for (ushort i = A; i <= A + C - 2; i++)
					{
						if (i > A)
						{
							ret += ",";
						}

						if (cx.IsLocal(i))
						{
							ret += cx.LocalName(i);
						}
						else
						{
							ret += R(i);
						}
					}

					return ret + " = " + content;
				}
			}

			return content;
		}

		protected override string ToAsmString()
		{
			return ListR(A, A + C - 2, " = ", ", ..., ")
				+ R(A)
				+ "("
				+ ListR(A + 1, A + B - 1, "", ", ..., ")
				+ ")";
		}

		#region ILoadOperator Member

		public bool LoadsRegister(ushort regnr)
		{
			return regnr == A || regnr == A + 1 || A <= regnr && A + C - 2 >= regnr || A + 1 <= regnr && A + B - 1 >= regnr || true;
		}

		#endregion
	}

	class RETURN : Operator, IOperator
	{
		public RETURN(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.PrepareJumpToEnd();
		}

		public override string ToString(Context cx)
		{
			return "return " + cx.ListSR(A, A + B - 2, "");
		}

		protected override string ToAsmString()
		{
			return "return " + ListR(A, A + B - 2, "", ", ..., ");
		}
	}

	class CLOSURE : Operator, IOperator
	{
		public CLOSURE(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			ObjLuaFunction fkt = cx.KProto(BX);
			cx.SetReg(A, fkt);

			System.IO.StreamWriter sw = new System.IO.StreamWriter(
				new System.IO.MemoryStream()
			);
			Context scx = cx.CreateSubContext(fkt, out string paramlist);
			sw.WriteLine();
			sw.WriteLine(cx.Indent + "function {{name}}(" + paramlist + ")");
			fkt.ToSource(sw, scx);
			sw.Write(cx.Indent + "end");
			sw.WriteLine();

			sw.Flush();
			sw.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
			System.IO.StreamReader sr = new System.IO.StreamReader(sw.BaseStream);
			cx.SetSReg(A, sr.ReadToEnd());
			sw.Close();
		}

		public override string ToString(Context cx)
		{
			return !ObjLuaFunction.DEBUG ? "" : "// " + R(A) + " = closure(KPROTO[" + BX.ToString() + "])";
		}

		protected override string ToAsmString()
		{
			return R(A) + " = closure(KPROTO[" + BX.ToString() + "])";
		}
	}

	class ADD : Operator, IOperator
	{
		public ADD(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetReg(
				A,
				Convert.ToDouble(cx.RK(B)) + Convert.ToDouble(cx.RK(C))
			);
			cx.SetSReg(A, "(" + cx.SRK(B) + " + " + cx.SRK(C) + ")");
		}

		public override string ToString(Context cx)
		{
			return cx.IsLocal(A)
				? cx.LocalName(A) + " = " + cx.SRK(B) + " + " + cx.SRK(C)
				: !ObjLuaFunction.DEBUG ? "" : "// " + R(A) + " = " + cx.SRK(B) + " + " + cx.SRK(C);
		}

		protected override string ToAsmString()
		{
			return R(A) + " = " + RK(B) + " + " + RK(C);
		}
	}

	class SUB : Operator, IOperator
	{
		public SUB(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetReg(
				A,
				Convert.ToDouble(cx.RK(B)) - Convert.ToDouble(cx.RK(C))
			);
			cx.SetSReg(A, "(" + cx.SRK(B) + " - " + cx.SRK(C) + ")");
		}

		public override string ToString(Context cx)
		{
			return cx.IsLocal(A)
				? cx.LocalName(A) + " = " + cx.SRK(B) + " - " + cx.SRK(C)
				: !ObjLuaFunction.DEBUG ? "" : "// " + R(A) + " = " + cx.SRK(B) + " - " + cx.SRK(C);
		}

		protected override string ToAsmString()
		{
			return R(A) + " = " + RK(B) + " - " + RK(C);
		}
	}

	class MUL : Operator, IOperator
	{
		public MUL(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetReg(
				A,
				Convert.ToDouble(cx.RK(B)) * Convert.ToDouble(cx.RK(C))
			);
			cx.SetSReg(A, "(" + cx.SRK(B) + " * " + cx.SRK(C) + ")");
		}

		public override string ToString(Context cx)
		{
			return cx.IsLocal(A)
				? cx.LocalName(A) + " = " + cx.SRK(B) + " * " + cx.SRK(C)
				: !ObjLuaFunction.DEBUG ? "" : "// " + R(A) + " = " + cx.SRK(B) + " * " + cx.SRK(C);
		}

		protected override string ToAsmString()
		{
			return R(A) + " = " + RK(B) + " * " + RK(C);
		}
	}

	class POW : Operator, IOperator
	{
		public POW(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetReg(
				A,
				Math.Pow(
					Convert.ToDouble(cx.RK(B)),
					Convert.ToDouble(cx.RK(C))
				)
			);
			cx.SetSReg(A, "(" + cx.SRK(B) + " ^ " + cx.SRK(C) + ")");
		}

		public override string ToString(Context cx)
		{
			return cx.IsLocal(A)
				? cx.LocalName(A) + " = " + cx.SRK(B) + " ^ " + cx.SRK(C)
				: !ObjLuaFunction.DEBUG ? "" : "// " + R(A) + " = " + cx.SRK(B) + " ^ " + cx.SRK(C);
		}

		protected override string ToAsmString()
		{
			return R(A) + " = " + RK(B) + " ^ " + RK(C);
		}
	}

	class DIV : Operator, IOperator
	{
		public DIV(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetReg(
				A,
				Convert.ToDouble(cx.RK(B)) / Convert.ToDouble(cx.RK(C))
			);
			cx.SetSReg(A, "(" + cx.SRK(B) + " / " + cx.SRK(C) + ")");
		}

		public override string ToString(Context cx)
		{
			return cx.IsLocal(A)
				? cx.LocalName(A) + " = " + cx.SRK(B) + " / " + cx.SRK(C)
				: !ObjLuaFunction.DEBUG ? "" : "// " + R(A) + " = " + cx.SRK(B) + " / " + cx.SRK(C);
		}

		protected override string ToAsmString()
		{
			return R(A) + " = " + RK(B) + " / " + RK(C);
		}
	}

	class UNM : Operator, IOperator
	{
		public UNM(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetReg(A, -1 * Convert.ToDouble(cx.R(B)));
			cx.SetSReg(A, "-" + cx.SR(B));
		}

		public override string ToString(Context cx)
		{
			return cx.IsLocal(A) ? cx.LocalName(A) + " = -" + cx.SR(B) : !ObjLuaFunction.DEBUG ? "" : "// " + R(A) + " = -" + cx.SR(B);
		}

		protected override string ToAsmString()
		{
			return R(A) + " = -" + R(B);
		}
	}

	class NOT : Operator, IOperator
	{
		public NOT(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetReg(A, !Convert.ToBoolean(cx.R(B)));
			cx.SetSReg(A, "!" + cx.SR(B));
		}

		public override string ToString(Context cx)
		{
			return cx.IsLocal(A) ? cx.LocalName(A) + " = !" + cx.SR(B) : !ObjLuaFunction.DEBUG ? "" : "// " + R(A) + " = !" + cx.SR(B);
		}

		protected override string ToAsmString()
		{
			return R(A) + " = !" + R(B);
		}
	}

	class GETUPVAL : Operator, IOperator, ILoadOperator
	{
		public GETUPVAL(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetReg(A, cx.Gbl(cx.Kst(BX)));
			cx.SetSReg(A, Kst(BX));
		}

		public override string ToString(Context cx)
		{
			return !cx.HasUpValue(B) ? !ObjLuaFunction.DEBUG ? "" : "/// " + AssignA(cx, cx.UpValue(B)) : AssignA(cx, cx.UpValue(B));
		}

		protected override string ToAsmString()
		{
			return R(A) + " = " + UpValue(B);
		}

		#region ILoadOperator Member

		public bool LoadsRegister(ushort regnr)
		{
			return A == regnr;
		}

		#endregion
	}

	class JMP : Operator, IOperator
	{
		public JMP(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.PrepareJumpToLine(cx.PC + SBX);
		}

		public override string ToString(Context cx)
		{
			return !ObjLuaFunction.DEBUG ? "" : "// " + "PC += " + SBX.ToString() + "//{CPC=" + cx.PC + "}";
		}

		protected override string ToAsmString()
		{
			return "PC += " + SBX.ToString();
		}
	}

	class IF : Operator, IIfOperator
	{
		string symb,
			nsymb;

		public IF(string symb, string nsymb, uint val, ObjLuaFunction parent)
			: base(val, parent)
		{
			this.symb = symb;
			this.nsymb = nsymb;
		}

		public override string ToString(Context cx)
		{
			return Bool(A) == "true"
				? "if (" + cx.SRK(B) + " " + nsymb + " " + cx.SRK(C) + ") then"
				: "if (" + cx.SRK(B) + " " + symb + " " + cx.SRK(C) + ") then";
		}

		protected override string ToAsmString()
		{
			return "if (("
				+ RK(B)
				+ " "
				+ symb
				+ " "
				+ RK(C)
				+ ") == "
				+ Bool(A)
				+ ") then PC++";
		}
	}

	class EQ : IF, IOperator
	{
		public EQ(uint val, ObjLuaFunction parent)
			: base("==", "~=", val, parent) { }

		public void Run(Context cx)
		{
		}
	}

	class LE : IF, IOperator
	{
		public LE(uint val, ObjLuaFunction parent)
			: base("<=", ">", val, parent) { }

		public void Run(Context cx)
		{
		}
	}

	class GE : IF, IOperator
	{
		public GE(uint val, ObjLuaFunction parent)
			: base(">=", "<", val, parent) { }

		public void Run(Context cx)
		{
		}
	}

	class LT : IF, IOperator
	{
		public LT(uint val, ObjLuaFunction parent)
			: base("<", ">=", val, parent) { }

		public void Run(Context cx)
		{
		}
	}

	class GT : IF, IOperator
	{
		public GT(uint val, ObjLuaFunction parent)
			: base(">", "<=", val, parent) { }

		public void Run(Context cx)
		{
		}
	}

	class SELF : Operator, IOperator
	{
		public SELF(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetReg((ushort)(A + 1), cx.R(B));
			cx.SetReg(A, cx.LoadTable(B, cx.RK(C)));

			cx.SetSReg((ushort)(A + 1), cx.SR(B));
			cx.SetSReg(A, cx.SR(B) + "[" + cx.SRK(C) + "]");
		}

		public override string ToString(Context cx)
		{
			return Assign((ushort)(A + 1), cx, cx.SR(B))
				+ "\n"
				+ cx.Indent
				+ AssignA(cx, cx.SR(B) + "[" + cx.SRK(C) + "]");
		}

		protected override string ToAsmString()
		{
			return R((ushort)(A + 1))
				+ " = "
				+ R(B)
				+ "; "
				+ R(A)
				+ " = "
				+ R(B)
				+ "["
				+ RK(C)
				+ "]";
		}
	}

	class TEST : Operator, IOperator, IIfOperator
	{
		public TEST(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			if (!cx.R(A).Equals(C))
			{
				cx.SetReg(A, cx.R(B));
			}

			//else cx.NextLine();
		}

		public override string ToString(Context cx)
		{
			return "if ("
				+ cx.SR(A)
				+ " ~= "
				+ C
				+ ") then \n"
				+ cx.Indent
				+ AssignA(cx, cx.SR(B))
				+ "\n";
		}

		protected override string ToAsmString()
		{
			return "if ("
				+ R(B)
				+ " ~= "
				+ C
				+ ") then "
				+ R(A)
				+ " = "
				+ R(B)
				+ " else PC++";
		}

		public int Offset => 1;
	}

	class TFORREP : Operator, IOperator
	{
		public TFORREP(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
		}

		public override string ToString(Context cx)
		{
			if (TFORLOOP == null)
			{
				return "";
			}

			string str = "for ";

			str += cx.ListSR(TFORLOOP.A + 2, TFORLOOP.A + 2 + TFORLOOP.C, "") + " in ";
			str += cx.SR(A) + " do ";

			return str;
		}

		public TFORLOOP TFORLOOP
		{
			get; set;
		}

		protected override string ToAsmString()
		{
			return "if type("
				+ R(A)
				+ ") == table then "
				+ R((ushort)(A + 1))
				+ " = "
				+ R(A)
				+ "; "
				+ R(A)
				+ "= next; PC += "
				+ SBX.ToString();
		}
	}

	class TFORLOOP : Operator, IOperator
	{
		public TFORLOOP(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
		}

		public void Setup(Context cx)
		{
			int ct = 0;
			for (int i = A + 1; i <= A + 2 + C; i++)
			{
				cx.SetSReg((ushort)i, "loopvar" + ct.ToString());
				ct++;
			}
		}

		public override string ToString(Context cx)
		{
			return "end";
		}

		protected override string ToAsmString()
		{
			return R((ushort)(A + 2))
				+ ", ..., "
				+ R((ushort)(A + 2 + C))
				+ " = "
				+ R(A)
				+ "("
				+ R(A)
				+ ", "
				+ R((ushort)(A + 2))
				+ "); if "
				+ R((ushort)(A + 2))
				+ " == null then PC++";
		}
	}

	class FORLOOP : Operator, IOperator
	{
		public FORLOOP(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
		}

		public bool IsStart
		{
			get; set;
		}

		public override string ToString(Context cx)
		{
			return !IsStart
				? "end"
				: "for "
					+ cx.SR(A)
					+ "="
					+ cx.R(A).ToString()
					+ ", "
					+ cx.SR((ushort)(A + 1))
					+ ", "
					+ cx.SR((ushort)(A + 2))
					+ " do ";
		}

		protected override string ToAsmString()
		{
			return R(A)
				+ " += "
				+ R((ushort)(A + 2))
				+ "; if "
				+ R(A)
				+ " <= "
				+ R((ushort)(A + 1))
				+ " then PC += "
				+ SBX.ToString();
		}
	}

	class TextLine : Operator, IOperator
	{
		string txt;

		public TextLine(uint val, ObjLuaFunction parent, string txt)
			: base(val, parent)
		{
			this.txt = txt;
		}

		public void Run(Context cx)
		{
		}

		public override string ToString(Context cx)
		{
			return txt;
		}

		protected override string ToAsmString()
		{
			return txt;
		}
	}

	class LOADBOOL : Operator, IOperator, ILoadOperator
	{
		public LOADBOOL(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			cx.SetLocal(A, cx.Bool(B));
			cx.SetSReg(A, cx.Bool(B).ToString());
		}

		public override string ToString(Context cx)
		{
			if (!cx.IsLocal(A))
			{
				cx.DefineLocal(A); //this fails, if this Register is used otherwise later
			}

			return cx.IsLocal(A)
				? "local " + cx.SR(A) + " = " + cx.Bool(B).ToString()
				: !ObjLuaFunction.DEBUG ? "" : "// " + R(A) + " = " + cx.Bool(B).ToString();
		}

		protected override string ToAsmString()
		{
			return R(A) + " = " + Bool(B) + "; if (" + Bool(C) + ") PC++";
		}

		#region ILoadOperator Member

		public bool LoadsRegister(ushort regnr)
		{
			return A == regnr;
		}

		#endregion
	}

	class CONCAT : Operator, IOperator
	{
		public CONCAT(uint val, ObjLuaFunction parent)
			: base(val, parent) { }

		public void Run(Context cx)
		{
			string v = "";
			string sv = "";
			for (ushort i = B; i <= C; i++)
			{
				v += cx.R(i).ToString();
				if (i != B)
				{
					v += " .. ";
				}

				sv += cx.SR(i).ToString();
			}

			cx.SetReg(A, v);
			cx.SetSReg(A, sv);
		}

		public override string ToString(Context cx)
		{
			return A == B
				? !ObjLuaFunction.DEBUG ? "" : "/// " + AssignA(cx, cx.ListSR(B, C, " .. ", ""))
				: AssignA(cx, cx.ListSR(B, C, " .. ", ""));
		}

		protected override string ToAsmString()
		{
			return R(A) + " = " + ListR(B, C, "", " .. ");
		}
	}
}
