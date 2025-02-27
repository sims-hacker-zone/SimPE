/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavNameWizards
{
	/// <summary>
	/// Abstract class for BHAV name providers (global, local, semiglobal)
	/// </summary>
	public class BhavWizBhav : BhavWiz, IDisposable
	{
		public BhavWizBhav(Instruction i)
			: base(i)
		{
			if (i.OpCode < 0x0100)
			{
				throw new InvalidOperationException("OpCode not a BHAV");
			}

			if (i.OpCode < 0x1000)
			{
				prefix = Localization.GetString("lcGlobal");
				group = i.Parent.GlobalGroup;
			}
			else if (i.OpCode < 0x2000)
			{
				prefix = Localization.GetString("lcPrivate");
				group = i.Parent.PrivateGroup;
			}
			else
			{
				prefix = Localization.GetString("lcSemiGlobal");
				group = i.Parent.SemiGroup;
			}
		}

		public static implicit operator BhavWizBhav(Instruction i)
		{
			if (i.OpCode < 0x0100)
			{
				throw new InvalidCastException("OpCode not a BHAV");
			}

			return new BhavWizBhav(i);
		}

		protected override string OpcodeName
		{
			get
			{
				FileTable.Entry ftEntry = instruction.Parent.ResourceByInstance(
					SimPe.Data.MetaData.BHAV_FILE,
					instruction.OpCode
				);
				return (ftEntry != null)
					? ftEntry
					: Localization.GetString("bhavnotfound");
			}
		}

		public override ABhavOperandWiz Wizard()
		{
			return /*Wrapper == null ? null :*/
			new BhavOperandWizards.BhavOperandWizBhav(instruction);
		}

		internal enum dataFormat
		{
			useTemps,
			oldFormat,
			newFormat,
			useParams,
		}

		internal static dataFormat opFormat(byte nodeVersion, byte[] operands)
		{
			if (nodeVersion > 0 && (operands[12] & 0x03) == 0x02)
			{
				return dataFormat.useParams;
			}

			if (
				(operands[12] & 0x01) == 0x01
				&& !(nodeVersion > 0 && operands[12] == 0xff)
			)
			{
				return dataFormat.newFormat;
			}

			for (int i = 0; i < 8; i++)
			{
				if (operands[i] != 0xFF)
				{
					return dataFormat.oldFormat;
				}
			}

			return dataFormat.useTemps;
		}

		/// <summary>
		/// Returns a description of the operands of the call to another BHAV
		/// </summary>
		/// <param name="lng">true to get long description</param>
		/// <returns>description of the BHAV call operands</returns>
		/// <remarks>See http://www.modthesims2.com/showthread.php?t=117411 for more info</remarks>
		protected override string Operands(bool lng)
		{
			Bhav bhav = Wrapper;
			if (bhav == null)
			{
				return "???";
			}

			int myArgc = instruction.Parent.Header.ArgumentCount;
			int thisArgc = bhav.Header.ArgumentCount;

			if (thisArgc == 0)
			{
				return lng ? Localization.GetString("noargs") : "";
			}

			string s = "";
			if (lng)
			{
				s +=
					thisArgc.ToString()
					+ " "
					+ (
						thisArgc == 1
							? Localization.GetString("oneArg")
							: Localization.GetString("manyArgs")
					)
					+ ": ";
			}

			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			TPRP tprp = (TPRP)bhav.SiblingResource(TPRP.TPRPtype);

			switch (opFormat(instruction.NodeVersion, o))
			{
				case dataFormat.useTemps:
					s += doTemps(thisArgc, lng, tprp);
					break;
				case dataFormat.oldFormat:
					s += do8Cx(
						thisArgc,
						lng,
						tprp,
						o,
						instruction.NodeVersion == 0
					);
					break;
				case dataFormat.newFormat:
					if (thisArgc < 9)
					{
						s += do4OI(thisArgc, lng, tprp, o);
					}
					else
					{
						s += doZero(thisArgc, lng, tprp);
					}

					break;
				case dataFormat.useParams:
					if (thisArgc < 9)
					{
						s += doParams(thisArgc, myArgc, lng, tprp);
					}
					else
					{
						s += doZero(thisArgc, lng, tprp);
					}

					break;
			}

			return s;
		}

		private Bhav Wrapper
		{
			get
			{
				if (wrapper != null)
				{
					return wrapper;
				}

				if (ftEntry == null)
				{
					if (instruction == null || instruction.Parent == null)
					{
						throw new Exception(
							"Can't find wrapper for instruction with no parent"
						);
					}

					ftEntry = instruction.Parent.ResourceByInstance(
						SimPe.Data.MetaData.BHAV_FILE,
						instruction.OpCode
					);
					if (ftEntry == null)
					{
						return null;
					}
				}

				wrapper = new Bhav();
				wrapper.ProcessData(ftEntry.PFD, ftEntry.Package);
				FileTable.GFT.FiletableRefresh += new EventHandler(
					GFT_FiletableRefresh
				);
				return wrapper;
			}
		}

		private FileTable.Entry ftEntry = null;
		private Bhav wrapper = null;

		/// <summary>
		/// Which group to look in for the BHAV
		/// </summary>
		private uint group = 0;

		#region IDisposable Members

		public new void Dispose()
		{
			GFT_FiletableRefresh(null, null);
		}

		#endregion

		void GFT_FiletableRefresh(object sender, EventArgs e)
		{
			FileTable.GFT.FiletableRefresh -= new EventHandler(GFT_FiletableRefresh);
			ftEntry = null;
			wrapper = null;
		}

		private string do4OI(int thisArgc, bool lng, TPRP tprp, byte[] o)
		{
			string s = "";
			for (int i = 0; thisArgc > 0 && i < 4; i++, thisArgc--)
			{
				string pn =
					(lng && tprp != null && !tprp.TextOnly && tprp.ParamCount > i)
						? tprp[false, i]
						: "";
				s +=
					(i > 0 ? ", " : "")
					+ ((pn != null && pn != "") ? pn + "=" : "")
					+ dataOwner(lng, o[i * 3], o[(i * 3) + 1], o[(i * 3) + 2]);
			}
			if (thisArgc > 0)
			{
				s += doZero(thisArgc, lng, tprp, 4);
			}

			return s;
		}

		private string do8Cx(int thisArgc, bool lng, TPRP tprp, byte[] o, bool z12)
		{
			string s = "";
			for (int i = 0; thisArgc > 0 && i < 8; i++, thisArgc--)
			{
				string pn =
					(lng && tprp != null && !tprp.TextOnly && tprp.ParamCount > i)
						? tprp[false, i]
						: "";
				s +=
					(i > 0 ? ", " : "")
					+ ((pn != null && pn != "") ? pn + "=" : "")
					+ "0x"
					+ SimPe.Helper.HexString(
						ToShort((z12 && i == 6) ? (byte)0 : o[(i * 2)], o[(i * 2) + 1])
					);
			}
			if (thisArgc > 0)
			{
				s += doZero(thisArgc, lng, tprp, 8);
			}

			return s;
		}

		private string doParams(int thisArgc, int myArgc, bool lng, TPRP tprp)
		{
			if (!lng)
			{
				return Localization.GetString("bw_callerparams");
			}

			string s = "";
			for (int i = 0; thisArgc > 0 && i < myArgc; i++, thisArgc--)
			{
				string pn =
					(lng && tprp != null && !tprp.TextOnly && tprp.ParamCount > i)
						? tprp[false, i]
						: "";
				s +=
					(i > 0 ? ", " : "")
					+ ((pn != null && pn != "") ? pn + "=" : "")
					+ dataOwner(9, (ushort)i);
			}
			if (thisArgc > 0)
			{
				s += doZero(thisArgc, lng, tprp, myArgc);
			}

			return s;
		}

		private string doTemps(int thisArgc, bool lng, TPRP tprp)
		{
			if (!lng)
			{
				return Localization.GetString("bwb_useTemps");
			}

			string s = "";
			for (int i = 0; thisArgc > 0 && i < 8; i++, thisArgc--)
			{
				string pn =
					(lng && tprp != null && !tprp.TextOnly && tprp.ParamCount > i)
						? tprp[false, i]
						: "";
				s +=
					(i > 0 ? ", " : "")
					+ ((pn != null && pn != "") ? pn + "=" : "")
					+ dataOwner(8, (ushort)i);
			}
			if (thisArgc > 0)
			{
				s += doZero(thisArgc, lng, tprp, 8);
			}

			return s;
		}

		private string doZero(int thisArgc, bool lng, TPRP tprp)
		{
			return doZero(thisArgc, lng, tprp, 0);
		}

		private string doZero(int thisArgc, bool lng, TPRP tprp, int start)
		{
			if (start >= 8)
			{
				return doUnknown(thisArgc, lng, tprp, start);
			}

			if (!lng)
			{
				return (start > 0 ? "," : Localization.GetString("allZeros"));
			}

			string s = "";
			for (int i = start; thisArgc > 0 && i < 8; i++, thisArgc--)
			{
				string pn =
					(lng && tprp != null && !tprp.TextOnly && tprp.ParamCount > i)
						? tprp[false, i]
						: "";
				s +=
					(i > 0 ? ", " : "")
					+ ((pn != null && pn != "") ? pn + "=" : "")
					+ dataOwner(7, 0);
			}
			if (thisArgc > 0)
			{
				s += doUnknown(thisArgc, lng, tprp, 8);
			}

			return s;
		}

		private string doUnknown(int thisArgc, bool lng, TPRP tprp)
		{
			return doUnknown(thisArgc, lng, tprp, 0);
		}

		private string doUnknown(int thisArgc, bool lng, TPRP tprp, int start)
		{
			if (!lng)
			{
				return (start > 0 ? ", " : "") + Localization.GetString("unkops");
			}

			string s = "";
			for (int i = start; thisArgc > 0; i++, thisArgc--)
			{
				string pn =
					(lng && tprp != null && !tprp.TextOnly && tprp.ParamCount > i)
						? tprp[false, i]
						: "";
				s +=
					(i > 0 ? ", " : "")
					+ ((pn != null && pn != "") ? pn + "=" : "")
					+ "????";
			}
			return s;
		}
	}
}
