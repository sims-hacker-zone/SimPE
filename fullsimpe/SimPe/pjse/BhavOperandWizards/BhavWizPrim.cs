/*
 * The majority of the code in this file would not be possible without
 * disaSim2 by dizzy2 and Shy.
 *
 * disaSim2 is public domain code and, in that spirit, so is the code
 * here (unlike the rest of this project, which is restricted by the
 * GPL).
 *
 * dizzy2 has the following statement at the start of disaSim2.cpp:
 */

//==============================================================================
// disassemble Sims 2 "SimAntics" (ver 2.4a)
//
// This file is PUBLIC DOMAIN (free as in "freestyle" or "freeway")
//==============================================================================
// dizzy2 (lead bug-inserter, project mascot) would like to thank the following
// individuals for their contributions:
//
// Shy (for lots of bug-squishing, and lots and lots of shiny, new code)
// Tom Bombadil (for pretty html text-rendering routines)
// T.Rowland (for some nice string and output improvements)
//==============================================================================

/*
 * The C# code here was converted by Peter L Jones <peter@drealm.info> from
 * the C source of disaSim2, mostly using some quick global replaces.  I (plj)
 * cannot claim any intellectual property rights over that!  Of course, if you
 * find something that this code gets wrong - whether disaSim2 gets it right
 * or not - please let us know by posting here:
 * http://forums.modthesims2.com/showthread.php?t=33537
 */

using System;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavNameWizards
{
	/// <summary>
	/// Abstract class for primitive name providers
	/// </summary>
	public abstract class BhavWizPrim : BhavWiz
	{
		protected BhavWizPrim(Instruction i)
			: base(i)
		{
			prefix = pjse.Localization.GetString("lcPrim");
		}

		public static implicit operator BhavWizPrim(Instruction i)
		{
			if (i.OpCode >= 0x0100)
			{
				throw new Exception("OpCode not a primative");
			}

			switch (i.OpCode)
			{
				case 0x0000:
					return new WizPrim0x0000(i);
				case 0x0001:
					return new WizPrim0x0001(i);
				case 0x0002:
					return new WizPrim0x0002(i);
				case 0x0003:
					return new WizPrim0x0003(i);
				case 0x0004:
				case 0x0005:
				case 0x0006:
					return new WizPrimUnused(i);
				case 0x0007:
					return new WizPrim0x0007(i);
				case 0x0008:
					return new WizPrim0x0008(i);
				case 0x0009:
				case 0x000a:
					return new WizPrimUnused(i);
				case 0x000b:
					return new WizPrim0x000b(i);
				case 0x000c:
					return new WizPrim0x000c(i);
				case 0x000d:
					return new WizPrim0x000d(i);
				case 0x000e:
					return new WizPrim0x000e(i);
				case 0x000f:
					return new WizPrim0x000f(i);
				case 0x0010:
					return new WizPrim0x0010(i);
				case 0x0011:
					return new WizPrim0x0011(i);
				case 0x0012:
					return new WizPrim0x0012(i);
				case 0x0013:
					return new WizPrim0x0013(i);
				case 0x0014:
					return new WizPrim0x0014(i);
				case 0x0015:
					return new WizPrimUnused(i);
				case 0x0016:
					return new WizPrim0x0016(i);
				case 0x0017:
					return new WizPrim0x0017(i);
				case 0x0018:
					return new WizPrimUnused(i);
				case 0x0019:
					return new WizPrim0x0019(i);
				case 0x001a:
					return new WizPrim0x001a(i);
				case 0x001b:
					return new WizPrim0x001b(i);
				case 0x001c:
					return new WizPrim0x001c(i);
				case 0x001d:
					return new WizPrim0x001d(i);
				case 0x001e:
					return new WizPrim0x001e(i);
				case 0x001f:
					return new WizPrim0x001f(i);
				case 0x0020:
					return new WizPrim0x0020(i);
				case 0x0021:
					return new WizPrim0x0021(i);
				case 0x0022:
					return new WizPrim0x0022(i);
				case 0x0023:
					return new WizPrim0x0023(i);
				case 0x0024:
					return new WizPrim0x0024(i);
				case 0x0025:
					return new WizPrim0x0025(i);
				case 0x0026:
				case 0x0027:
				case 0x0028:
				case 0x0029:
					return new WizPrimUnused(i);
				case 0x002a:
					return new WizPrim0x002a(i);
				case 0x002b:
				case 0x002c:
					return new WizPrimUnused(i);
				case 0x002d:
					return new WizPrim0x002d(i);
				case 0x002e:
					return new WizPrim0x002e(i);
				case 0x002f:
					return new WizPrimUnused(i);
				case 0x0030:
					return new WizPrim0x0030(i);
				case 0x0031:
					return new WizPrim0x0031(i);
				case 0x0032:
					return new WizPrim0x0032(i);
				case 0x0033:
					return new WizPrim0x0033(i);
				case 0x0069:
					return new WizPrim0x0069(i);
				case 0x006a:
					return new WizPrim0x006a(i);
				case 0x006b:
					return new WizPrim0x006b(i);
				case 0x006c:
					return new WizPrim0x006c(i);
				case 0x006d:
					return new WizPrim0x006d(i);
				case 0x006e:
					return new WizPrim0x006e(i);
				case 0x006f:
					return new WizPrim0x006f(i);
				case 0x0070:
					return new WizPrim0x0070(i);
				case 0x0071:
					return new WizPrim0x0071(i);
				case 0x0072:
					return new WizPrim0x0072(i);
				case 0x0073:
					return new WizPrim0x0073(i);
				case 0x0074:
					return new WizPrim0x0074(i);
				case 0x0075:
					return new WizPrim0x0075(i);
				case 0x0076:
					return new WizPrim0x0076(i);
				case 0x0077:
					return new WizPrim0x0077(i);
				case 0x0078:
					return new WizPrim0x0078(i);
				case 0x0079:
					return new WizPrim0x0079(i);
				case 0x007a:
					return new WizPrim0x007a(i);
				case 0x007b:
					return new WizPrim0x007b(i);
				case 0x007c:
					return new WizPrim0x007c(i);
				case 0x007d:
					return new WizPrim0x007d(i);
				case 0x007e:
					return new WizPrim0x007e(i);
			}

			if (i.OpCode >= 0x0034 && i.OpCode <= 0x0068 || i.OpCode >= 0x007f)
			{
				return new WizPrimUnused(i);
			}

			throw new Exception("OpCode defies understanding");
		}

		protected override string OpcodeName => readStr(GS.BhavStr.Primitives, instruction.OpCode);
	}

	public class WizPrimUnused : BhavWizPrim
	{
		public WizPrimUnused(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			return "-";
		}
	}

	public class WizPrim0x0000 : BhavWizPrim // Sleep
	{
		public WizPrim0x0000(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			return dataOwner(
				lng,
				0x09,
				instruction.Operands[0],
				instruction.Operands[1]
			); // Param
#if DISASIM
			// case 0x00:  // Sleep (false = error)
			//     ht_fprintf(outFile,TYPE_NORMAL,"for ");
			//     data2(9, b[x]);
			//     ht_fprintf(outFile,TYPE_NORMAL," ticks");
			//     break;
#endif
		}
	}

	public class WizPrim0x0001 : BhavWizPrim // Generic Sims Call
	{
		public WizPrim0x0001(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWiz0x0001(instruction);
		}

		protected override string Operands(bool lng)
		{
			return readStr(GS.BhavStr.Generics, instruction.Operands[0])
				+ (
					lng
						? " ("
							+ readStr(GS.BhavStr.GenericsDesc, instruction.Operands[0])
							+ ")"
						: ""
				);
#if DISASIM
			// case 0x01:  // Generic Sims Call
			//     c1 = b[x];
			//     CHECK_RANGE("Generic Sims Call", gStringDC, c1);
			//     ht_fprintf(outFile,TYPE_FUNCTION,"%s", gStringDC[c1]);
			//     switch (c1) {
			//         case 0:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:neighborhood, Temp 1:evict, Temp 2:save lot, Temp 3:reset tutorial");
			//             break;
			//         case 4:
			//             ht_fprintf(outFile,TYPE_NORMAL," Stack Obj:nID, Temp 0:familyID");
			//             break;
			//         case 5:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:familyID");
			//             break;
			//         case 6:
			//             ht_fprintf(outFile,TYPE_NORMAL," Stack Obj:nID");
			//             break;
			//         case 0x0D:
			//             ht_fprintf(outFile,TYPE_NORMAL," Stack Obj");
			//             break;
			//         case 0x11:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:lotID");
			//             break;
			//         case 0x12:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:speed");
			//             break;
			//         case 0x15:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:child nID, Temp 1:parent nID");
			//             break;
			//         case 0x16:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:new spouse nID, Temp 1:initial spouse nID");
			//             break;
			//         case 0x17:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:remove nID, Temp 1:relative nID");
			//             break;
			//         case 0x18:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:age");
			//             break;
			//         case 0x19:
			//         case 0x28:
			//         case 0x29:
			//         case 0x2C:
			//         case 0x31:
			//         case 0x33:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0");
			//             break;
			//         case 0x1C:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:amount, Temp 2:multiplier");
			//             break;
			//         case 0x1D:
			//         case 0x26:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:nID");
			//             break;
			//         case 0x1E:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:outfit");
			//             break;
			//         case 0x1F:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0,1:GUID");
			//             break;
			//         case 0x20:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:outfit, Temp 1:result value");
			//             break;
			//         case 0x22:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:source, Temp 1:destination, Temp 2:result value");
			//             break;
			//         case 0x23:
			//         case 0x24:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:lotID, Temp 1:result value");
			//             break;
			//         case 0x2D:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:source, Stack Obj:destination");
			//             break;
			//         case 0x2E:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:tableID, Temp 1:index, Temp 3:fallback");
			//             break;
			//         case 0x30:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:nID, Temp 1:result value");
			//             break;
			//         case 0x32:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:take, Temp 1:target nID, Temp 2:percent, Temp 3,4:amount, Temp 5:from assets");
			//             break;
			//         case 0x34:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:direction, Temp 1:result wall obj");
			//             break;
			//         case 0x35:
			//             ht_fprintf(outFile,TYPE_NORMAL," Temp 0:tableID, Temp 1:index, Temp 2:state, Temp 3:fallback");
			//             break;
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x0002 : BhavWizPrim // Expression
	{
		public WizPrim0x0002(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWiz0x0002(instruction);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = instruction.Operands;

			byte lhs_data_owner = o[6]; // c2
			ushort lhs_value_word = ToShort(o[0], o[1]); // w1
			byte _operator = o[5]; // c1
			byte rhs_data_owner = o[7]; // b[x+7]
			ushort rhs_value_word = ToShort(o[2], o[3]); // w2

			string s = "";

			s +=
				dataOwner(lng, lhs_data_owner, lhs_value_word)
				+ " "
				+ readStr(GS.BhavStr.Operators, _operator)
				+ " ";

			if (lng && _operator >= 8 && _operator <= 10) // Flag operation
			{
				s +=
					pjse.Localization.GetString("flagnr")
					+ " "
					+ dataOwner(rhs_data_owner, rhs_value_word);
				if (
					rhs_data_owner == 7
					&& flagname(lhs_data_owner, lhs_value_word, rhs_value_word) != null
				)
				{
					s +=
						" ("
						+ flagname(lhs_data_owner, lhs_value_word, rhs_value_word)
						+ ")";
				}
			}
			else
			{
				s += dataOwner(lng, rhs_data_owner, rhs_value_word);
			}

			return s;
#if DISASIM
			//                 case 0x02:  // (Evaluate) Expression (non-comparison operators return false if error)
			//                     w1 = *(UINT16 *) (&b[x]);
			//                     w2 = *(UINT16 *) (&b[x+2]);
			//                     c1 = b[x+5];
			//                     c2 = b[x+6];
			//                     data2(c2, w1);            // target data
			//                     if (c1 == 0x14)           // abs(rhs)
			//                         ht_fprintf(outFile,TYPE_OPERATOR," := abs(");
			//                     else if (c1 == 0x15)      // Assign 32bit Value (both target and source are contiguous 32-bit)
			//                         ht_fprintf(outFile,TYPE_OPERATOR," := int32(");
			//                     else {
			//                         CHECK_RANGE("Operator", gString88, c1);
			//                         ht_fprintf(outFile,TYPE_OPERATOR," %s ",gString88[c1]);
			//                     }

			//                     if (b[x+7] == 7 && c1 > 7 && c1 < 11 && w2 > 0) {   // literal (non-0), flag operator
			//                         if ((c2 == 3 || c2 == 4) && (w1 == 5 || w1 == 8 || w1 == 0x0D ||
			//                                 w1 == 0x22 || w1 == 0x28 || w1 == 0x2A ||
			//                                 w1 == 0x2B || w1 == 0x3F || w1 == 0x45)) {
			//                             switch (w1) {
			//                                 case 5:
			//                                     CHECK_RANGE("Wall adj. flags", gStringD0, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringD0[w2 - 1]);
			//                                     break;
			//                                 case 8:
			//                                     CHECK_RANGE("Flags 1", gString8E, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gString8E[w2 - 1]);
			//                                     break;
			//                                 case 0x0D:
			//                                     CHECK_RANGE("Wall placement flags", gStringE5, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringE5[w2 - 1]);
			//                                     break;
			//                                 case 0x22:
			//                                     CHECK_RANGE("Hidden Flags", gString200, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gString200[w2 - 1]);
			//                                     break;
			//                                 case 0x28:
			//                                     CHECK_RANGE("Flags 2", gStringD6, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringD6[w2 - 1]);
			//                                     break;
			//                                 case 0x2A:
			//                                     CHECK_RANGE("Placement flags", gStringCA, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringCA[w2 - 1]);
			//                                     break;
			//                                 case 0x2B:
			//                                     CHECK_RANGE("Movement flags", gStringCB, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringCB[w2 - 1]);
			//                                     break;
			//                                 case 0x3F:
			//                                     CHECK_RANGE("Exclusive placement flags", gStringFB, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringFB[w2 - 1]);
			//                                     break;
			//                                 case 0x45:
			//                                     CHECK_RANGE("Wall cutout flags", gStringFD, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringFD[w2 - 1]);
			//                                     break;
			//                             }
			//                         } else if ((c2 == 0x12 || c2 == 0x13 || c2 == 0x20) &&
			//                         (w1 == 0x1E || w1 == 0x44 || w1 == 0x51 || w1 == 0x9E || w1 == 0x9F)) {
			//                             switch (w1) {
			//                                 case 0x1E:
			//                                     CHECK_RANGE("Censorship flags", gStringB2, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringB2[w2 - 1]);
			//                                     break;
			//                                 case 0x44:
			//                                     CHECK_RANGE("Ghost flags", gString201, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gString201[w2 - 1]);
			//                                     break;
			//                                 case 0x51:
			//                                     CHECK_RANGE("Body flags", gString8F, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gString8F[w2 - 1]);
			//                                     break;
			//                                 case 0x9E:
			//                                     CHECK_RANGE("Selection flags", gString202, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gString202[w2 - 1]);
			//                                     break;
			//                                 case 0x9F:
			//                                     CHECK_RANGE("Person flags", gString204, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gString204[w2 - 1]);
			//                                     break;
			//                             }
			//                         } else if ((c2 == 0x15 || c2 == 0x26 || c2 == 0x33) &&
			//                         (w1 == 0x27 || w1 == 0x28)) {
			//                             switch (w1) {
			//                                 case 0x27:
			//                                     CHECK_RANGE("Room sort flags", gStringCD, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringCD[w2 - 1]);
			//                                     break;
			//                                 case 0x28:
			//                                     CHECK_RANGE("Function sort flags", gStringCE, w2 - 1);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringCE[w2 - 1]);
			//                                     break;
			//                             }
			//                         } else {
			//                             data2(b[x+7], w2);  // unknown flag
			//                         }
			//                     } else {
			//                         data2(b[x+7], w2);      // not a literal flag

			//                         // flag, BCON 0x101:x (Standard Heights)
			// /*
			//                         if (c1 > 7 && c1 < 11 && b[x+7] == 0x1A && (w2 & 0xFF80) == 0x4080 && (w2 & 0x7F)) {
			//                             CHECK_RANGE("Allowed height flags", gStringAH, (w2 & 0x7F) - 1);
			//                             ht_fprintf(outFile,TYPE_NORMAL," %s", gStringAH[(w2 & 0x7F) - 1]);
			//                         }
			// */
			//                         if (c1 == 0x14 || c1 == 0x15)    // abs(rhs) or Assign 32bit Value
			//                             ht_fprintf(outFile,TYPE_OPERATOR,")");
			//                     }
			//                     break;
#endif
		}
	}

	public class WizPrim0x0003 : BhavWizPrim // Find Best Interaction
	{
		public WizPrim0x0003(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			if (o[2] == 0)
			{
				s += pjse.Localization.GetString("bwp03_nworst");
			}
			else
			{
				int motives = ToShort(o[0], o[1]);
				s += pjse.Localization.GetString("bwp03_formotive") + ": ";
				bool found = false;
				for (ushort i = 0; i < 16; i++) // this should only find 1 motive (if any)
				{
					if ((motives & (1 << i)) != 0)
					{
						s += (found ? "; " : "") + readStr(GS.BhavStr.Motives, i);
						found = true;
					}
				}

				if (!found)
				{
					s += "(" + pjse.Localization.GetString("none") + ")";
				}

				if (lng)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp03_remworst")
						+ ": "
						+ ((o[2] & 0x01) != 0).ToString();
				}
			}
			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp03_inroom")
					+ " "
					+ this.dataOwner(0x08, 0) // Temp
					+ ": "
					+ ((o[3] & 0x02) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp03_oow")
					+ ": "
					+ ((o[3] & 0x04) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp03_nested")
					+ ": "
					+ ((o[3] & 0x08) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp03_oninteraction")
					+ ": "
					+ ((o[3] & 0x10) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp03_locntemp1")
					+ ": "
					+ ((o[3] & 0x20) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x03:  // Find Best Interaction
			//     w1 = *(UINT16 *) (&b[x]);   // motive
			//     w2 = *(UINT16 *) (&b[x+2]); // flags
			//     if (w2 == 0)
			//         ht_fprintf(outFile,TYPE_NORMAL,"for the N current worst motives.");
			//     else {
			//         w3 = 1;
			//         for (c1 = 0; c1 < 16; c1++) {   // this should only find 1 motive (if any)
			//             if (w1 & w3) {
			//                 CHECK_RANGE("Motives", gString86, c1);
			//                 ht_fprintf(outFile,TYPE_NORMAL," for %s", gString86[c1]);;
			//             }
			//             w3 = w3 << 1;
			//         }
			//         ht_fprintf(outFile,TYPE_NORMAL,".");
			//         if (w2 & 1)
			//             ht_fprintf(outFile,TYPE_NORMAL," Choose remaining motives from the worst.");
			//     }
			//     if (w2 & 0x200) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", Only test objects in room held in temp 0");
			//         if (w2 & 0x400)
			//             ht_fprintf(outFile,TYPE_NORMAL," including Out Of World Objects");
			//         ht_fprintf(outFile,TYPE_NORMAL,".");
			//     }
			//     if (w2 & 0x800) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", Find Nested Interactions Only");
			//         if (w2 & 0x1000)
			//             ht_fprintf(outFile,TYPE_NORMAL," and only on current Interaction object");
			//         ht_fprintf(outFile,TYPE_NORMAL,".");
			//     }
			//     if (w2 & 0x2000)
			//         ht_fprintf(outFile,TYPE_NORMAL," Use location of object in Temp 1.");
			//     break;
#endif
		}
	}

	public class WizPrim0x0007 : BhavWizPrim // Refresh
	{
		public WizPrim0x0007(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				readStr(GS.BhavStr.UpdateWho, ToShort(o[0], o[1]))
				+ " "
				+ readStr(GS.BhavStr.UpdateWhat, ToShort(o[2], o[3]));

			return s;
#if DISASIM
			// case 0x07:  // Refresh (false = error)
			//     if (b[x] == 0)
			//         ht_fprintf(outFile,TYPE_NORMAL,"My ");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,"Stack Object's ");
			//     if (b[x+2] == 0)
			//         ht_fprintf(outFile,TYPE_NORMAL,"graphic");
			//     else if (b[x+2] == 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,"lighting contribution");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,"room score contribution");
			//     break;
#endif
		}
	}

	public class WizPrim0x0008 : BhavWizPrim // Random
	{
		public WizPrim0x0008(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWiz0x0008(instruction);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			return dataOwner(lng, o[2], o[0], o[1])
				+ " := 0 .. < "
				+ dataOwner(lng, o[6], o[4], o[5]);
#if DISASIM
			// case 0x08:  // Random Number (false = error)
			//     w1 = *(UINT16 *) (&b[x]);
			//     w2 = *(UINT16 *) (&b[x+4]);
			//     data2(b[x+2], w1);
			//     ht_fprintf(outFile,TYPE_OPERATOR," := random from 0 to < ");
			//     data2(b[x+6], w2);
			//     break;
#endif
		}
	}

	public class WizPrim0x000b : BhavWizPrim // Get Distance To
	{
		public WizPrim0x000b(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += dataOwner(lng, 0x08, o[0], o[1]); // temp
			s += " := ";
			s += (
				(o[2] & 0x01) != 0 ? dataOwner(lng, o[3], o[4], o[5]) : dnMe() // Me
			);
			s += " .. " + dnStkOb(); // Stack Object
			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp0b_100tile")
					+ ": "
					+ ((o[6] & 0x02) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x0B:  // Get Distance To (false = error)
			//     w1 = *(UINT16 *) (&b[x]);
			//     w2 = *(UINT16 *) (&b[x+4]);
			//     data2(8, w1);   // temp
			//     ht_fprintf(outFile,TYPE_OPERATOR," := distance from ");
			//     if (b[x+2] & 1)
			//         data2(b[x+3], w2);
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,"Me");
			//     ht_fprintf(outFile,TYPE_NORMAL," to Stack Object");
			//     if (b[x+6] & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL," in 1/100ths of a tile");
			//     break;
#endif
		}
	}

	public class WizPrim0x000c : BhavWizPrim // Get Direction To
	{
		public WizPrim0x000c(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += dataOwner(lng, o[2], o[0], o[1]);
			s += " := ";
			s += (
				(o[4] & 0x01) != 0 ? dataOwner(lng, o[5], o[6], o[7]) : dnMe() // Me
			);
			s += " .. " + dnStkOb(); // Stack Object
			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp0c_degrees")
					+ ": "
					+ ((o[8] & 0x02) == 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x0C:  // Get Direction To (false = error)
			//     w1 = *(UINT16 *) (&b[x]);
			//     w2 = *(UINT16 *) (&b[x+6]);
			//     data2(b[x+2], w1);
			//     ht_fprintf(outFile,TYPE_OPERATOR," := direction from ");
			//     if (b[x+4] & 1)
			//         data2(b[x+5], w2);
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,"Me");
			//     ht_fprintf(outFile,TYPE_NORMAL," to Stack Object");
			//     if ((b[x+8] & 2) == 0)
			//         ht_fprintf(outFile,TYPE_NORMAL," in degrees");
			//     break;
#endif
		}
	}

	public class WizPrim0x000d : BhavWizPrim // Push Interaction -- for wizard, see edithWiki FunWithControllers
	{
		public WizPrim0x000d(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			if (lng)
			{
				s += pjse.Localization.GetString("Target") + ": " + dnStkOb() + ", "; // Stack Object
			}

			s +=
				(lng ? pjse.Localization.GetString("Object") + ": " : "")
				+ dataOwner(lng, (byte)((o[3] & 0x02) != 0 ? 0x19 : 0x09), o[1]); // local | param

			s += ", " + (lng ? pjse.Localization.GetString("Interaction") + ": " : "");
			if ((o[3] & 0x10) != 0)
			{
				s += dataOwner(lng, o[5], o[6], o[7]);
			}
			else if ((o[14] & 2) != 0)
			{
				s += pjse.Localization.GetString("bwp0d_lastfba");
			}
			else
			{
				s += dataOwner(lng, 0x07, o[0]); // Literal
			}

			s += ", " + readStr(GS.BhavStr.Priorities, o[2]);

			if (lng)
			{
				if ((o[3] & 0x01) != 0)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp0d_IconObject")
						+ ": "
						+ dataOwner(0x19, o[4]); // Local
				}
				else if ((o[14] & 4) != 0)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp0d_IconObject")
						+ ": "
						+ dataOwner(0x08, 0x04)
						+ ",5"; // Temp
				}

				s +=
					", "
					+ pjse.Localization.GetString("bwp0d_IconIndex")
					+ ": "
					+ (
						(o[14] & 0x08) != 0
							? dataOwner(0x08, 0x06) // Temp
							: dataOwner(0x07, o[15]) // Literal
					);

				if ((o[14] & 0x01) != 0)
				{
					s += ", " + pjse.Localization.GetString("bwp0d_callersparams");
				}
				// if (o[3] & 4) ht_fprintf(outFile,TYPE_NORMAL,", continue as current");
				if ((o[3] & 0x08) != 0)
				{
					s += ", " + pjse.Localization.GetString("bwp0d_usename");
				}

				if ((o[3] & 0x20) != 0)
				{
					s += ", " + pjse.Localization.GetString("bwp0d_forcerun");
				}

				if ((o[3] & 0x40) != 0)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp0d_linkto")
						+ " "
						+ dataOwner(o[8], o[9], o[10]);
				}

				if ((o[3] & 0x80) != 0)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp0d_returnID")
						+ " "
						+ dataOwner(o[11], o[12], o[13]);
				}
			}

			return s;
#if DISASIM
			// case 0x0D:  // Push Interaction
			//     w1 = *(UINT16 *) (&b[x+6]);
			//     w2 = *(UINT16 *) (&b[x+9]);
			//     w3 = *(UINT16 *) (&b[x+12]);
			//     if (b[x+3] & 0x10) {
			//         ht_fprintf(outFile,TYPE_NORMAL,"getting interaction # from ");
			//         data2(b[x+5],w1);
			//         ht_fprintf(outFile,TYPE_NORMAL," of ");
			//     } else if (b[x+14] & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,"getting interaction # from results of last FBA call ");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,"#0x%X of ", b[x]);
			//     if (b[x+3] & 2)
			//         data2(0x19, b[x+1]);    // local
			//     else
			//         data2(9, b[x+1]);       // param
			//     ht_fprintf(outFile,TYPE_NORMAL," onto the stack object's queue, ");
			//     CHECK_RANGE("Priorities", gStringE0, b[x+2]);
			//     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringE0[b[x+2]]);
			//     if (b[x+3] & 1) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", use icon from ");
			//         data2(0x19, b[x+4]);
			//     } else if (b[x+14] & 4)
			//         ht_fprintf(outFile,TYPE_NORMAL," use Icon from selector GUID in temp4/5");
			//     if (b[x+14] & 8)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Getting Icon Index from Temp6");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,", Icon Index is 0x%X", b[x+15]);
			//     // if (b[x+3] & 4) ht_fprintf(outFile,TYPE_NORMAL,", continue as current");
			//     if (b[x+3] & 8) ht_fprintf(outFile,TYPE_NORMAL,", use name");
			//     if (b[x+3] & 0x20) ht_fprintf(outFile,TYPE_NORMAL,", Force run check tree");
			//     if (b[x+14] & 1) ht_fprintf(outFile,TYPE_NORMAL,", Passing first 4 params in");
			//     if (b[x+3] & 0x40) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", Linking to interaction with ID in ");
			//         data2(b[x+8],w2);
			//     }
			//     if (b[x+3] & 0x80) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", Returing ID in ");
			//         data2(b[x+11],w3);
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x000e : BhavWizPrim // Find Best Object for Function
	{
		public WizPrim0x000e(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += readStr(GS.BhavStr.FunctionTable, o[0]);
			if (lng)
			{
				byte[] flags = { 0x01, 0x02, 0x04, 0x00, 0x10, 0x00, 0x40, 0x00 };
				for (int i = 0; i < flags.Length; i++)
				{
					if (flags[i] != 0)
					{
						s +=
							", "
							+ readStr(GS.BhavStr.FuncLocationFlags, (ushort)(i + 1))
							+ ": "
							+ ((o[2] & flags[i]) != 0).ToString();
					}
				}

				s +=
					", "
					+ readStr(GS.BhavStr.FuncLocationFlags, 4)
					+ ": "
					+ ((o[2] & 0x08) != 0 ? dataOwner(o[3], o[4], o[5]) : dnMe()); // Me
			}

			return s;
#if DISASIM
			// case 0x0E:  // Find Best Object for Function
			//     w1 = *(UINT16 *) (&b[x+4]);
			//     CHECK_RANGE("Function table", gStringC9, b[x]);
			//     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringC9[b[x]]);
			//     if (b[x+2] & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Outside Only");
			//     else if (b[x+2] & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Inside Only");
			//     else if (b[x+2] & 4)
			//         ht_fprintf(outFile,TYPE_NORMAL,", In Room Only");
			//     if (b[x+2] & 0x10)
			//         ht_fprintf(outFile,TYPE_NORMAL,", In Line Of Site");
			//     if (b[x+2] & 0x40)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Ignoring Lockout");
			//     if (b[x+2] & 8) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", Relative to object in ");
			//         data2(b[x+3],w1);
			//     }

			//     break;
#endif
		}
	}

	public class WizPrim0x000f : BhavWizPrim // Break Point (disaSim2 24b)
	{
		public WizPrim0x000f(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			return ((o[4] & 0x01) != 0)
				? pjse.Localization.GetString("bwp0f_ignored")
				: pjse.Localization.GetString("bwp0f_if")
					+ " "
					+ dataOwner(lng, o[2], o[0], o[1])
					+ " != 0";
#if DISASIM
			// case 0x0F:  // Break Point (false = error)
			//     if (b[x+4] & 1)
			//       ht_fprintf(outFile,TYPE_NORMAL,"(IGNORE IN RELEASE)");
			//     else {
			//       w1 = *(UINT16 *) (&b[x]);
			//       w2 = *(UINT16 *) (&b[x+2]);
			//       ht_fprintf(outFile,TYPE_NORMAL,"if (");
			//       data2(b[x+2], w1);
			//       ht_fprintf(outFile,TYPE_NORMAL," != 0)");
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x0010 : BhavWizPrim // Find location for -- for wizard, see edithWiki AkeaPostMortem
	{
		public WizPrim0x0010(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			if ((o[2] & 0x01) != 0)
			{
				s += dnStkOb(); // Stack Object
				if (lng)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp10_startAt")
						+ " "
						+ dataOwner(0x19, o[1]); // Local
				}
			}
			else
			{
				s += dataOwner(lng, o[4], o[5], o[6]);
				if (lng)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp10_relativeTo")
						+ " "
						+ dataOwner(o[7], o[8], o[9]);
				}
			}

			if (lng)
			{
				if ((o[2] & 0x08) != 0)
				{
					s += ", " + pjse.Localization.GetString("bwp10_facing");
					if ((o[3] & 0x01) != 0)
					{
						s += " " + pjse.Localization.GetString("compassN");
					}

					if ((o[3] & 0x02) != 0)
					{
						s += " " + pjse.Localization.GetString("compassNE");
					}

					if ((o[3] & 0x04) != 0)
					{
						s += " " + pjse.Localization.GetString("compassE");
					}

					if ((o[3] & 0x08) != 0)
					{
						s += " " + pjse.Localization.GetString("compassSE");
					}

					if ((o[3] & 0x10) != 0)
					{
						s += " " + pjse.Localization.GetString("compassS");
					}

					if ((o[3] & 0x20) != 0)
					{
						s += " " + pjse.Localization.GetString("compassSW");
					}

					if ((o[3] & 0x40) != 0)
					{
						s += " " + pjse.Localization.GetString("compassW");
					}

					if ((o[3] & 0x80) != 0)
					{
						s += " " + pjse.Localization.GetString("compassNW");
					}
				}

				s += ", " + readStr(GS.BhavStr.FindGLB, o[0]);
				if (o[0] >= 5 && o[0] <= 8)
				{
					s += " 0x" + SimPe.Helper.HexString(o[10]);
				}

				s +=
					", "
					+ pjse.Localization.GetString("bwp10_preferEmpty")
					+ ": "
					+ ((o[2] & 0x02) == 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp10_userEditable")
					+ ": "
					+ ((o[2] & 0x04) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp10_onLevelGround")
					+ ": "
					+ ((o[2] & 0x10) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp10_withEmptyBorder")
					+ ": "
					+ ((o[2] & 0x20) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp10_beginInFrontOfRefobj")
					+ ": "
					+ ((o[2] & 0x40) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp10_withLineOfSightToCenter")
					+ ": "
					+ ((o[2] & 0x80) != 0).ToString();
			}

			return s;
#if DISASIM
			//                 case 0x10:  // Find Location For
			//                     w1 = *(UINT16 *) (&b[x+5]);
			//                     w2 = *(UINT16 *) (&b[x+8]);
			//                     if (b[x+2] & 8) {
			//                         data2(b[x+4], w1);
			//                         ht_fprintf(outFile,TYPE_NORMAL," relative to ");
			//                         data2(b[x+7], w2);
			//                         switch (b[x]) {
			//                             case 5:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", routing slot in stack var %d",b[x+10]);
			//                                 break;
			//                             case 6:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", routing slot in local var %d",b[x+10]);
			//                                 break;
			//                             case 7:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", literal routing slot %d",b[x+10]);
			//                                 break;
			//                             case 8:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", global routing slot %d",b[x+10]);
			//                                 break;
			//                         }
			//                         ht_fprintf(outFile,TYPE_NORMAL,", facing");
			//                         if ((b[x+3] & 1) == 0)
			//                             ht_fprintf(outFile,TYPE_NORMAL," N");
			//                         if ((b[x+3] & 2) == 0)
			//                             ht_fprintf(outFile,TYPE_NORMAL," NE");
			//                         if ((b[x+3] & 4) == 0)
			//                             ht_fprintf(outFile,TYPE_NORMAL," E");
			//                         if ((b[x+3] & 8) == 0)
			//                             ht_fprintf(outFile,TYPE_NORMAL," SE");
			//                         if ((b[x+3] & 0x10) == 0)
			//                             ht_fprintf(outFile,TYPE_NORMAL," S");
			//                         if ((b[x+3] & 0x20) == 0)
			//                             ht_fprintf(outFile,TYPE_NORMAL," SW");
			//                         if ((b[x+3] & 0x40) == 0)
			//                             ht_fprintf(outFile,TYPE_NORMAL," W");
			//                         if ((b[x+3] & 0x80) == 0)
			//                             ht_fprintf(outFile,TYPE_NORMAL," NW");
			//                     }
			//                     else if (b[x+2] & 1) {
			//                         ht_fprintf(outFile,TYPE_NORMAL,"Stack Object, start at ");       // (this seems to make a bit more sense)
			//                         data2(0x19,b[x+1]);       // local
			//                     }
			//                     if (b[x] != 0) {
			//                         if (b[x+2] & 8) ht_fprintf(outFile,TYPE_NORMAL,", ");
			//                         CHECK_RANGE("Find GLB", gStringEF, b[x]);
			//                         ht_fprintf(outFile,TYPE_NORMAL," %s", gStringEF[b[x]]);
			//                     }
			// //                    if (b[x+2] & 1) {
			// //                        if (b[x] != 0 || (b[x+2] & 8)) ht_fprintf(outFile,TYPE_NORMAL,", ");
			// //                        ht_fprintf(outFile,TYPE_NORMAL,"start at ");
			// //                        data2(0x19, b[x+1]);    // local
			// //                    }
			//                     if (b[x+2] & 4) ht_fprintf(outFile,TYPE_NORMAL,", user editable");
			//                     if ((b[x+2] & 2) == 0) ht_fprintf(outFile,TYPE_NORMAL,", prefer empty");
			//                     if (b[x+2] & 0x10) ht_fprintf(outFile,TYPE_NORMAL,", on level ground");
			//                     if (b[x+2] & 0x20) ht_fprintf(outFile,TYPE_NORMAL,", with empty border");
			//                     if (b[x+2] & 0x40) ht_fprintf(outFile,TYPE_NORMAL,", begin in front of refobj");
			//                     if (b[x+2] & 0x80) ht_fprintf(outFile,TYPE_NORMAL,", with line of site to center");
			//                     break;
#endif
		}
	}

	public class WizPrim0x0011 : BhavWizPrim // Idle for Input
	{
		public WizPrim0x0011(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			if ((o[4] & 0x01) != 0)
			{
				s += pjse.Localization.GetString("bwp11_handleSubQueueInteractions");
			}
			else
			{
				s +=
					pjse.Localization.GetString("bwp_ticks")
					+ ": "
					+ dataOwner(lng, 0x09, o[0]) // Param
					+ ", "
					+ pjse.Localization.GetString("bwp11_allowPush")
					+ ": "
					+ (ToShort(o[2], o[3]) == 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x11:  // Idle for Input
			//     w1 = *(UINT16 *) (&b[x+2]);
			//     if (b[x+4] & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,"Handle Sub Queue Interactions");
			//     else {
			//         ht_fprintf(outFile,TYPE_NORMAL,"for ");
			//         data2(9, b[x]);
			//         ht_fprintf(outFile,TYPE_NORMAL," ticks, ");
			//         if (w1 == 0) ht_fprintf(outFile,TYPE_NORMAL,"do not ");
			//         ht_fprintf(outFile,TYPE_NORMAL,"allow push");
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x0012 : BhavWizPrim // Remove Object Instance -- for wizard, see edithWiki AkeaPostMortem
	{
		public WizPrim0x0012(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += (o[0] == 0 ? dnMe() : dnStkOb()); // Me | Stack Object
			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp12_returnImmediately")
					+ ": "
					+ ((o[2] & 1) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp12_cleanupAll")
					+ ": "
					+ ((o[2] & 2) == 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x12:  // Remove Object Instance
			//     if (b[x] == 0)
			//         ht_fprintf(outFile,TYPE_NORMAL,"Me");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,"Stack Object");
			//     if (b[x+2] & 1) ht_fprintf(outFile,TYPE_NORMAL,", return immediately");
			//     if ((b[x+2] & 2) == 0) ht_fprintf(outFile,TYPE_NORMAL,", cleanup all");
			//     break;
#endif
		}
	}

	public class WizPrim0x0013 : BhavWizPrim // Make New Character
	{
		public WizPrim0x0013(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			if ((o[9] & 0x01) != 0)
			{
				s +=
					pjse.Localization.GetString("Parent")
					+ " 1"
					+ (
						(o[9] & 0x02) != 0
							? " " + pjse.Localization.GetString("NeighborID")
							: ""
					)
					+ ": "
					+ dataOwner(lng, o[6], o[7], o[8]);
				s += ", ";
				s +=
					pjse.Localization.GetString("Parent")
					+ " 2"
					+ (
						(o[9] & 0x04) != 0
							? " " + pjse.Localization.GetString("NeighborID")
							: ""
					)
					+ ": "
					+ dataOwner(lng, o[3], o[4], o[5]);
			}
			else
			{
				s += pjse.Localization.GetString("bwp13_noParents");
			}

			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp13_personDataSource")
					+ ": (GUID) "
					+ dataOwner(0x08, 0x00)
					+ ",1: "
					+ ((o[9] & 0x08) != 0).ToString(); // Temp
				s +=
					", "
					+ pjse.Localization.GetString("bwp13_personDataSource")
					+ ": (GUID) "
					+ "temp Token"
					+ ": "
					+ ((o[9] & 0x10) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp13_characterFromBin")
					+ ": "
					+ ((o[9] & 0x20) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp13_thumbnailOutfit")
					+ ": "
					+ (
						((o[9] & 0x40) != 0)
							? "(GUID) "
								+ (
									((o[9] & 0x80) != 0)
										? dataOwner(0x08, 0x02) + ",3" // Temp
										: dataOwner(o[10], o[11], o[12])
								)
							: pjse.Localization.GetString("default")
					);

				if (o[0] != 0 && o[0] != 0xFF)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp13_skinColor")
						+ ": "
						+ dataOwner(0x19, o[0]); // Local
					s +=
						", "
						+ pjse.Localization.GetString("bwp13_age")
						+ ": "
						+ dataOwner(0x19, o[1]); // Local
					s +=
						", "
						+ pjse.Localization.GetString("bwp13_gender")
						+ ": "
						+ dataOwner(0x19, o[2]); // Local
				}
				else
				{
					s += ", " + pjse.Localization.GetString("bwp13_defAgeGenderSkin");
				}
			}

			return s;
#if DISASIM
			// case 0x13:  // Make New Character
			//     w1 = *(UINT16 *) (&b[x+4]);
			//     w2 = *(UINT16 *) (&b[x+7]);
			//     w3 = *(UINT16 *) (&b[x+11]);

			//     if (b[x+9] & 8)
			//         ht_fprintf(outFile,TYPE_NORMAL,"getting data from object with GUID in temp 0/1 ");
			//     else if (b[x+9] & 0x10)
			//         ht_fprintf(outFile,TYPE_NORMAL,"getting data from object with GUID in temp Token ");
			//     else if (b[x+9] & 1) {
			//         if (b[x+9] & 2)
			//             ht_fprintf(outFile,TYPE_NORMAL,"using Neighbor ID in ");
			//         else
			//             ht_fprintf(outFile,TYPE_NORMAL,"using ID in ");
			//         data2(b[x+6],w2);
			//         if (b[x+9] & 4)
			//             ht_fprintf(outFile,TYPE_NORMAL," as parent 1 and Neighbor ID in ");
			//         else
			//             ht_fprintf(outFile,TYPE_NORMAL," as parent 1 and ID in ");
			//         data2(b[x+3],w1);
			//         ht_fprintf(outFile,TYPE_NORMAL," as parent 2 ");
			//     }
			//     if (b[x] != 0 && b[x] != 0xFF) {
			//         ht_fprintf(outFile,TYPE_NORMAL,"age in ");
			//         data2(0x19, b[x+1]);
			//         ht_fprintf(outFile,TYPE_NORMAL,", gender in ");
			//         data2(0x19, b[x+2]);
			//         ht_fprintf(outFile,TYPE_NORMAL,", skin color in ");
			//         data2(0x19, b[x]);
			//     }
			//     if (b[x+9] & 0x20)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Getting character from Bin"); // ?
			//     if (b[x+9] & 0x40) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", Using external guid for Thumbnail Outfit from ");
			//         if (b[x+9] & 0x80)
			//             ht_fprintf(outFile,TYPE_NORMAL,"GUID in temp 2/3");
			//         else
			//             data2(b[x+10],w3);
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x0014 : BhavWizPrim // Run Functional Tree
	{
		public WizPrim0x0014(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += readStr(GS.BhavStr.FunctionTable, o[0]);
			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp14_changeIcon")
					+ ": "
					+ ((o[2] & 0x01) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp14_callersParams")
					+ ": "
					+ ((o[2] & 0x02) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp14_CTonly")
					+ ": "
					+ ((o[2] & 0x04) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x14:  // Run Functional Tree
			//     CHECK_RANGE("Functional table", gStringC9, b[x]);
			//     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringC9[b[x]]);
			//     c1 = b[x+2];
			//     if (c1 & 1) ht_fprintf(outFile,TYPE_NORMAL,", change icon");
			//     if (c1 & 2) ht_fprintf(outFile,TYPE_NORMAL,", passing parameters from calling tree");
			//     if (c1 & 4) ht_fprintf(outFile,TYPE_NORMAL,", running check tree only");
			//     break;
#endif
		}
	}

	public class WizPrim0x0016 : BhavWizPrim // Turn Body
	{
		public WizPrim0x0016(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += readStr(GS.BhavStr.TurnBody, o[0]);

			return s;
#if DISASIM
			// case 0x16:  // Turn Body Towards
			//     CHECK_RANGE("Turn body", gStringD8, b[x]);
			//     ht_fprintf(outFile,TYPE_FUNCTION,"%s", gStringD8[b[x]]);
			//     break;
#endif
		}
	}

	public class WizPrim0x0017 : BhavWizPrim // Play / Stop Sound Event -- for wizard, see edithWiki CreatingAChair
	{
		public WizPrim0x0017(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += (
				(o[4] & 0x40) != 0
					? pjse.Localization.GetString("Stop")
					: pjse.Localization.GetString("Play")
			);

			int instance = ToShort(o[0], o[1]);
			Scope scope = Scope.Private;
			if (instance >= 10000 && instance < 20000)
			{
				scope = Scope.Global;
				instance -= 10000;
			}
			else if (instance >= 20000)
			{
				scope = Scope.SemiGlobal;
				instance -= 20000;
			}
			string temp = readStr(
				scope,
				GS.GlobalStr.Sound,
				(ushort)(instance),
				lng ? -1 : 60,
				lng ? Detail.Normal : Detail.ErrorNames
			);
			if (temp.Length > 0)
			{
				s += " " + temp;
			}

			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp_source")
					+ ": "
					+ dataOwner((byte)((o[4] & 0x02) == 0 ? 0x03 : 0x04), 0x0b);
				s +=
					", "
					+ pjse.Localization.GetString("bwp17_autoVary")
					+ ": "
					+ ((o[4] & 0x10) != 0).ToString();

				s +=
					", "
					+ pjse.Localization.GetString("bwp17_sampleRate")
					+ ": 0x"
					+ SimPe.Helper.HexString(ToShort(o[2], o[3]));
				s +=
					", "
					+ pjse.Localization.GetString("bwp17_volume")
					+ ": 0x"
					+ SimPe.Helper.HexString(o[5]);
			}

			return s;
#if DISASIM
			// case 0x17:  // Play / Stop Sound Event (false = error)
			//     w1 = *(UINT16 *) (&b[x]);
			//     w2 = *(UINT16 *) (&b[x+2]);
			//     if (b[x+4] & 0x40)
			//         ht_fprintf(outFile,TYPE_NORMAL,"Stop Sound ");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,"Play Sound ");
			//     if (w1 < 10000)
			//         ht_fprintf(outFile,TYPE_NORMAL,"Private id = 0x%X", w1);
			//     else if (w1 < 20000)
			//         ht_fprintf(outFile,TYPE_NORMAL,"Global id = 0x%X", w1-10000);
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,"SemiGlobal id = 0x%X", w1-20000);
			//     if (b[x+4] & 2) ht_fprintf(outFile,TYPE_NORMAL,", with stack obj as source");
			//     if ((b[x+4] & 2) == 0) {
			//         if (b[x+4] & 0x10)
			//             ht_fprintf(outFile,TYPE_NORMAL,", auto vary");
			//         if (w2 != 0)
			//             ht_fprintf(outFile,TYPE_NORMAL,", sampled at %d, w2"); // ?
			//         if (b[x+5] != 0)
			//             ht_fprintf(outFile,TYPE_NORMAL,", volume %d", b[x+5]); // ?
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x0019 : BhavWizPrim // Alter Budget -- for wizard, see edithWiki WorkAndSchool, Chance Card - Results
	{
		public WizPrim0x0019(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			// expense type | operator | amount

			if ((o[4] & 0x01) != 0)
			{
				s += pjse.Localization.GetString("bwp19_test") + ": ";
			}

			s +=
				readStr(GS.BhavStr.ExpenseType, o[6])
				+ " "
				+ readStr(
					GS.BhavStr.Operators,
					(ushort)(((o[4] & 0x02) != 0) ? 0x03 : 0x04)
				) // -= | +=
				+ " (";

			byte owner = o[1];
			switch (o[0])
			{
				case 0:
					owner = 0x07;
					break; // literal
				case 1:
					owner = 0x09;
					break; // param
				case 2:
					owner = 0x19;
					break; // local
			}
			if ((o[4] & 0x08) != 0 && instruction.NodeVersion != 0)
			{
				s += dataOwner(0x08, 2) + ",3"; // was "temp 3 and 4"  (SimAntics error)
			}
			else
			{
				s += dataOwner(lng, owner, o[2], o[3]);
			}

			s += " * ";
			s +=
				((o[4] & 0x04) != 0) ? dataOwner(0x08, 2)
				: (ToShort(o[7], o[8]) == 0) ? "1"
				: "0x" + SimPe.Helper.HexString(ToShort(o[7], o[8]));
			s += ")";

			return s;
#if DISASIM
			// case 0x19:  // Alter Budget
			//     c1 = b[x+1];
			//     switch (b[x]) {
			//         case 0:
			//             c1 = 7;     // literal
			//             break;
			//         case 1:
			//             c1 = 9;     // param
			//             break;
			//         case 2:
			//             c1 = 0x19;  // local
			//             break;
			//     }
			//     w1 = *(UINT16 *) (&b[x+2]);
			//     w2 = *(UINT16 *) (&b[x+7]);
			//     switch (b[x+4] & 3) {
			//         case 0:
			//             ht_fprintf(outFile,TYPE_NORMAL,"subtract ");
			//             break;
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL,"test if ");
			//             break;
			//         case 2:
			//             ht_fprintf(outFile,TYPE_NORMAL,"add ");
			//             break;
			//         case 3:
			//             ht_fprintf(outFile,TYPE_NORMAL,"test if ");
			//             break;
			//     }
			//     if ((b[x+4] & 8) && nodeVersion)
			//         ht_fprintf(outFile,TYPE_NORMAL,"amount in temp 2 and 3");
			//     else
			//         data2(c1, w1);
			//     if (b[x+4] & 4)
			//         ht_fprintf(outFile,TYPE_NORMAL," Multiplied by value in Temp2");
			//     else if (w2 != 0)
			//         ht_fprintf(outFile,TYPE_NORMAL," Multiplied by %d", w2);
			//     switch (b[x+4] & 3) {
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL," may be subtracted");
			//             break;
			//         case 3:
			//             ht_fprintf(outFile,TYPE_NORMAL," may be added");
			//             break;
			//     }
			//     CHECK_RANGE("Expenses", gStringF0, b[x+6]);
			//     ht_fprintf(outFile,TYPE_NORMAL," as %s", gStringF0[b[x+6]]);
			//     break;
#endif
		}
	}

	public class WizPrim0x001a : BhavWizPrim // Relationship
	{
		public WizPrim0x001a(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			if ((o[1] & 0x04) == 0)
			{
				if (instruction.NodeVersion == 0) // old-style parameter usage
				{
					s += dataOwner(o[4], ToShort(o[6], o[7]));
				}
				else
				{
					s += dataOwner(o[8], ToShort(o[9], o[10]));
				}

				s += " := ";
			}

			s += readStr(
				Scope.Global,
				GS.GlobalStr.Relationship,
				o[0],
				-1,
				Detail.ErrorNames
			); // fixed scope and file

			if ((o[1] & 0x04) != 0)
			{
				s += " := ";
				if (instruction.NodeVersion == 0) // old-style parameter usage
				{
					s += dataOwner(o[4], ToShort(o[6], o[7]));
				}
				else
				{
					s += dataOwner(o[8], ToShort(o[9], o[10]));
				}
			}

			s += ", " + pjse.Localization.GetString("bwp1a_relationship") + ": ";
			if (instruction.NodeVersion == 0) // old-style parameter usage
			{
				s += readStr(GS.BhavStr.RelVar, (ushort)(o[1] & 3));
			}
			else // new-style parameter usage
			{
				s +=
					dataOwner(lng, o[2], ToShort(o[3], o[4]))
					+ " .. "
					+ dataOwner(lng, o[5], ToShort(o[6], o[7]));
			}

			if (lng)
			{
				if (instruction.NodeVersion == 0) // old-style parameter usage
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp1a_failTooSmall")
						+ ": "
						+ ((o[2] & 0x01) != 0).ToString();
					s +=
						", "
						+ pjse.Localization.GetString("bwp1a_useNIDs")
						+ ": "
						+ ((o[2] & 0x02) != 0).ToString();
				}
				else
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp1a_failTooSmall")
						+ ": "
						+ ((o[1] & 0x01) != 0).ToString();
					s +=
						", "
						+ pjse.Localization.GetString("bwp1a_useNIDs")
						+ ": "
						+ ((o[1] & 0x02) != 0).ToString();
					s +=
						", "
						+ pjse.Localization.GetString("bwp1a_noCheckObj2")
						+ ": "
						+ ((o[1] & 0x08) != 0).ToString(); // "object to sim" relationship
				}
			}

			return s;
#if DISASIM
			// case 0x1A:  // Relationship
			//     c1 = b[x];      // var
			//     c2 = b[x+1];    // flags
			//     w2 = *(UINT16 *) (&b[x+6]);
			//     if (nodeVersion == 0) {   // old-style parameter usage
			//         if ((c2 & 4) == 0) {
			//             data2(b[x+4], w2);
			//             ht_fprintf(outFile,TYPE_NORMAL," := ");
			//         }
			//         ht_fprintf(outFile,TYPE_NORMAL,"var %d of ", c1);
			//         switch (c2 & 3) {
			//             case 0:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Me to Stack Object");
			//                 break;
			//             case 1:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Stack Object to Me");
			//                 break;
			//             case 2:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Stack Object to ");
			//                 data2(0x19, b[x+3]);
			//                 break;
			//             case 3:
			//                 data2(0x19, b[x+3]);
			//                 ht_fprintf(outFile,TYPE_NORMAL," to Stack Object");
			//                 break;
			//         }
			//         if (c2 & 4) {
			//             ht_fprintf(outFile,TYPE_NORMAL," := ");
			//             data2(b[x+4], w2);
			//         }
			//         if (b[x+2] & 1) ht_fprintf(outFile,TYPE_NORMAL,", fail if too small");
			//         if (b[x+2] & 2) ht_fprintf(outFile,TYPE_NORMAL,", use neighbor IDs");
			//     } else {            // new-style parameter usage
			//         w1 = *(UINT16 *) (&b[x+9]);
			//         w3 = *(UINT16 *) (&b[x+3]);

			//         ht_fprintf(outFile,TYPE_NORMAL,"Access var %d ", c1);
			//         if (c2 & 2) {
			//             CHECK_RANGE("Relation Labels", gRelLabels, c1);
			//             ht_fprintf(outFile,TYPE_NORMAL,"(%s) ", gRelLabels[c1]);
			//         }
			//         ht_fprintf(outFile,TYPE_NORMAL,"of ");
			//         data2(b[x+2],w3);

			//         ht_fprintf(outFile,TYPE_NORMAL," to ");
			//         data2(b[x+5],w2);
			//         ht_fprintf(outFile,TYPE_NORMAL,". ");
			//         if (c2 & 4)
			//             ht_fprintf(outFile,TYPE_NORMAL,"Get value from ");
			//         else
			//             ht_fprintf(outFile,TYPE_NORMAL,"Put value into ");
			//         data2(b[x+8], w1);
			//         if (c2 & 1) ht_fprintf(outFile,TYPE_NORMAL,", fail if too small");
			//         if (c2 & 2)
			//             ht_fprintf(outFile,TYPE_NORMAL,", use neighbor IDs");
			//         else if (c2 & 8)
			//             ht_fprintf(outFile,TYPE_NORMAL,", don't check presence of second object"); // "object to sim" relationship
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x001b : BhavWizPrim // Go To Relative Position
	{
		public WizPrim0x001b(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWiz0x001b(instruction);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				(lng ? pjse.Localization.GetString("bwp_Location") + ": " : "")
				+ readStr(GS.BhavStr.RelativeLocations, (byte)(o[2] + 2));
			s +=
				", "
				+ (lng ? pjse.Localization.GetString("Direction") + ": " : "")
				+ readStr(GS.BhavStr.RelativeDirections, (byte)(o[3] + 2));
			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp_noFailureTrees")
					+ ": "
					+ ((o[6] & 0x02) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp1b_differentAltitudes")
					+ ": "
					+ ((o[6] & 0x04) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x1B:  // Go To Relative Position
			//     c1 = (b[x+2] + 2) & 0xFF;
			//     c2 = (b[x+3] + 2) & 0xFF;
			//     CHECK_RANGE("Relative locations", gString82, c1);
			//     ht_fprintf(outFile,TYPE_NORMAL,"Location = %s, ", gString82[c1]);
			//     CHECK_RANGE("Relative directions", gString83, c2);
			//     ht_fprintf(outFile,TYPE_NORMAL,"Direction = %s", gString83[c2]);
			//     c3 = b[x+6];
			//     if (c3 & 2) ht_fprintf(outFile,TYPE_NORMAL,", no failure trees");
			//     if (c3 & 4) ht_fprintf(outFile,TYPE_NORMAL,", allow different altitudes");
			//     break;
#endif
		}
	}

	public class WizPrim0x001c : BhavWizPrim // Run Tree By Name
	{
		public WizPrim0x001c(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWiz0x001c(instruction);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);
			Boolset options = (byte)(o[2] & 0x3f);

			string s = "";

			Scope scope = Scope.Private;
			if (options[0])
			{
				scope = Scope.Global;
			}
			else if (options[1])
			{
				scope = Scope.SemiGlobal;
			}

			if (lng)
			{
				s += pjse.Localization.GetString("bwp1c_treeName") + ": ";
			}

			s += readStr(
				scope,
				GS.GlobalStr.NamedTree,
				(ushort)(ToShort(o[4], (byte)(o[2] >> 6)) - 1),
				lng ? -1 : 60,
				lng ? Detail.Normal : Detail.ErrorNames
			);

			if (lng)
			{
				s += ", " + pjse.Localization.GetString("bwp1c_search") + ": ";
				s += pjse.Localization.GetString("Private");
				s += !options[3] ? " " + pjse.Localization.GetString("SemiGlobal") : "";
				s += !options[2] ? " " + pjse.Localization.GetString("Global") : "";

				s += ", " + readStr(GS.BhavStr.RTBNType, o[5]);

				if ((o[2] & 0x30) != 0)
				{
					s += ", " + pjse.Localization.GetString("manyArgs") + ": ";
				}

				if (options[5])
				{
					s += pjse.Localization.GetString("bw_callerparams");
				}

				if ((o[2] & 0x30) == 0x30)
				{
					s += ", ";
				}

				if (options[4]) // Data Owner format
				{
					for (int i = 0; i < 3; i++)
					{
						s +=
							(i == 0 ? "" : ", ")
							+ dataOwner(
								o[6 + i * 3],
								o[6 + (i * 3) + 1],
								o[6 + (i * 3) + 2]
							);
					}
				}
			}

			return s;
#if DISASIM
			//                 case 0x1C:  // Run Tree by Name
			//                     c1 = b[x+4] - 1;
			//                     w1 = *(UINT16 *) (&b[x+7]);
			//                     w2 = *(UINT16 *) (&b[x+10]);
			//                     w3 = *(UINT16 *) (&b[x+13]);
			//                     if (b[x+2] & 1) {
			//                         ht_fprintf(outFile,TYPE_NORMAL,"%s", gNamedTreePrim[c1]);
			//                     } else if (b[x+2] & 2) {
			//                         if (readString2(gGlobGroup, 0x12F, c1) == 0)
			//                             ht_fprintf(outFile,TYPE_NORMAL,"[SemiGlobal STR# 0x12F:0x%X]", c1);
			//                     } else {
			//                         if (readString2(gGroup, 0x12F, c1) == 0)
			//                             ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x12F:0x%X]", c1);
			//                     }

			// //                    if ((b[x+2] & 4) == 0) ht_fprintf(outFile,TYPE_NORMAL,", only if idle");   // ?

			//                     // How to look for tree with given name:
			//                     // private -> semiglobal -> global -> "false" if not found
			//                     if (b[x+2] & 8)
			//                         ht_fprintf(outFile,TYPE_NORMAL,", ignore semiglobal trees");
			//                     if (b[x+2] & 4)
			//                         ht_fprintf(outFile,TYPE_NORMAL,", ignore global trees");

			//                     if (b[x+2] & 0x20) {
			//                         ht_fprintf(outFile,TYPE_NORMAL,", Passing in params from the current tree");
			//                     } else if (b[x+2] & 0x10) {
			//                         ht_fprintf(outFile,TYPE_NORMAL,", Passing in params where param 0 = ");
			//                         data2(b[x+6], w1);
			//                         ht_fprintf(outFile,TYPE_NORMAL,", param 1 = ");
			//                         data2(b[x+9], w2);
			//                         ht_fprintf(outFile,TYPE_NORMAL,", param 2 = ");
			//                         data2(b[x+12], w3);
			//                     }
			//                     switch (b[x+5]) { // Behavior string 0xDE
			//                         case 0:
			//                             ht_fprintf(outFile,TYPE_NORMAL,", run in my stack");
			//                             break;
			//                         case 1:
			//                             ht_fprintf(outFile,TYPE_NORMAL,", run in Stack Object's stack");
			//                             break;
			//                         case 2:
			//                             ht_fprintf(outFile,TYPE_NORMAL,", push onto my stack");
			//                             break;
			//                     }
			//                     break;
#endif
		}
	}

	public class WizPrim0x001d : BhavWizPrim // Set Motive Change -- for wizard, see edithWiki CreatingAChair
	{
		public WizPrim0x001d(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += (
				(o[3] & 0x01) != 0
					? pjse.Localization.GetString("bwp1d_clearAll")
					: dataOwner(lng, 0x0E, o[2]) // My Motives
						+ " += "
						+ dataOwner(lng, o[0], o[4], o[5])
						+ " "
						+ (
							lng
								? pjse.Localization.GetString("bwp1d_perHour")
									+ ", "
									+ pjse.Localization.GetString("bwp1d_stopAt")
									+ ":"
								: ".."
						)
						+ " "
						+ dataOwner(lng, o[1], o[6], o[7])
			);

			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp1d_autoClear")
					+ ": "
					+ ((o[3] & 0x02) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x1D:  // Set Motive Change (false = error)
			//     w1 = *(UINT16 *) (&b[x+4]);
			//     w2 = *(UINT16 *) (&b[x+6]);
			//     if (b[x+3] & 1) {
			//         ht_fprintf(outFile,TYPE_NORMAL,"clear all");
			//     } else {
			//         data2(0xE, b[x+2]);     // my motives
			//         ht_fprintf(outFile,TYPE_NORMAL," += ");
			//         data2(b[x], w1);
			//         ht_fprintf(outFile,TYPE_NORMAL," per hour, stop at ");
			//         data2(b[x+1], w2);
			//     }
			//     if (b[x+3] & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Auto Clearing the Person Data Motive Decay value");
			//     break;
#endif
		}
	}

	public class WizPrim0x001e : BhavWizPrim // Gosub Action
	{
		public WizPrim0x001e(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += readStr(GS.BhavStr.GosubAction, o[0]);

			return s;
#if DISASIM
			// case 0x1E:  // Gosub Found Action
			//     CHECK_RANGE("Gosub Found Action", gString1FE, b[x]);
			//     ht_fprintf(outFile,TYPE_FUNCTION,"%s",gString1FE[b[x]]);
			//     break;
#endif
		}
	}

	public class WizPrim0x001f : BhavWizPrim // Set to Next
	{
		public WizPrim0x001f(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWiz0x001f(instruction);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				(
					(o[4] & 0x80) == 0
						? dnStkOb() // Stack Object
						: dataOwner(lng, o[5], o[7])
				) + ", "; // ":=" didn't look right here.

			s += readStr(GS.BhavStr.NextObject, (ushort)(o[4] & 0x7f));
			switch (o[4] & 0x7f)
			{
				case 0x04:
				case 0x07:
					s += ": " + BhavWiz.FormatGUID(lng, o, 0);
					break;
				case 0x09:
				case 0x22:
					s = s.Replace("[local]", dataOwner(lng, 0x19, o[6])); // local
					break;
			}

			if (lng && instruction.NodeVersion != 0)
			{
				if ((o[8] & 0x02) != 0)
				{
					s +=
						" && "
						+ readStr(GS.BhavStr.DataLabels, ToShort(o[9], o[10]))
						+ " == 0x"
						+ SimPe.Helper.HexString(ToShort(o[11], o[12]));
				}

				s +=
					", "
					+ pjse.Localization.GetString("bwp1f_disabledObjects")
					+ ": "
					+ ((o[8] & 0x01) != 0).ToString();
			}
			return s;
#if DISASIM
			// case 0x1F:  // Set to Next (false = next not found)
			//     w1 = *(UINT16 *) (&b[x+9]);
			//     w2 = *(UINT16 *) (&b[x+11]);
			//     if (b[x+5] != 0xA || b[x+7] != 0 && (b[x+4] & 0x80) != 0) {
			//         data2(b[x+5], b[x+7]);
			//         ht_fprintf(outFile,TYPE_NORMAL," := next ");
			//     }
			//     c1 = (b[x+4] & 0x7F);
			//     CHECK_RANGE("Next object", gStringA4, c1);
			//     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringA4[c1]);
			//     d1 = *(UINT32 *) (&b[x]);
			//     if (c1 == 4 || c1 == 7) ht_fprintf(outFile,TYPE_NORMAL," GUID 0x%08X", d1);
			//     readGUID(d1);
			//     if (c1 == 9 || c1 == 0x22) data2(0x19, b[x+6]);   // local
			//     if ((b[x+8] & 2) && nodeVersion) ht_fprintf(outFile,TYPE_NORMAL," where %s := %d", gString8D[w1], w2);
			//     if ((b[x+8] & 1) && nodeVersion) ht_fprintf(outFile,TYPE_NORMAL," [including disabled objects]");
			//     break;
#endif
		}
	}

	public class WizPrim0x0020 : BhavWizPrim // Test Object Type
	{
		public WizPrim0x0020(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWiz0x0020(instruction);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += dataOwner(lng, o[6], o[4], o[5]);

			s += ", " + pjse.Localization.GetString("bwp20_isInstanceOf");

			s += ": " + BhavWiz.FormatGUID(lng, o, 0);
			if (lng)
			{
				//if (d1 == 0x4C7CAB2B)
				//	s += " (temporary inventory token)";

				s +=
					", "
					+ pjse.Localization.GetString("bwp20_originalGUID")
					+ ": "
					+ ((o[7] & 0x01) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp20_neighbourID")
					+ ": "
					+ ((o[7] & 0x02) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp20_returnTemp01")
					+ ": "
					+ ((o[7] & 0x04) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x20:  // Test Object Type
			//     w1 = *(UINT16 *) (&b[x+4]);
			//     d1 = *(UINT32 *) (&b[x]);
			//     if (b[x+7] & 4)
			//         ht_fprintf(outFile,TYPE_NORMAL,"Return GUID selected in Temp0/1 ");
			//     else {
			//         ht_fprintf(outFile,TYPE_NORMAL,"type of ");
			//         data2(b[x+6], w1);
			//     }
			//     if (d1 == 0x4C7CAB2B)
			//         ht_fprintf(outFile,TYPE_NORMAL,"the GUID of the temporary inventory token");
			//     else {
			//         ht_fprintf(outFile,TYPE_NORMAL," == GUID 0x%08X", d1);
			//         readGUID(d1);
			//     }
			//     if ((b[x+7] & 4) == 0) {
			//         if (b[x+7] & 1)
			//             ht_fprintf(outFile,TYPE_NORMAL," Checking against original, not current GUID");
			//         if (b[x+7] & 2)
			//             ht_fprintf(outFile,TYPE_NORMAL,", incoming ID is a neighbor ID");
			//     }

			//     break;
#endif
		}
	}

	public class WizPrim0x0021 : BhavWizPrim // Find 5 Worst Motives
	{
		public WizPrim0x0021(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += dataOwner(0x08, 0) + "..4 :=";

			s += " " + readStr(GS.BhavStr.ShortOwner, ToShort(o[4], o[5]));
			s += " " + readStr(GS.BhavStr.MotiveType, ToShort(o[6], o[7]));

			return s;
#if DISASIM
			// case 0x21:  // Find 5 Worst Motives (false = error)
			//     w1 = *(UINT16 *) (&b[x+4]);
			//     w2 = *(UINT16 *) (&b[x+6]);

			//     CHECK_RANGE("Short owner", gString99, w1);
			//     ht_fprintf(outFile,TYPE_NORMAL,"%s lowest ", gString99[w1]);

			//     CHECK_RANGE("Motive type", gStringA5, w2);
			//     ht_fprintf(outFile,TYPE_NORMAL,"%s into temps 0-4", gStringA5[w2]);
			//     break;
#endif
		}
	}

	public class WizPrim0x0022 : BhavWizPrim // UI Effect
	{
		public WizPrim0x0022(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += readStr(GS.BhavStr.UIEffectType, o[0]);

			if (o[0] < 5 || o[0] > 8)
			{
				Scope scope = Scope.Private;
				if ((o[5] & 0x04) != 0)
				{
					scope = Scope.Global;
				}
				else if ((o[5] & 0x08) != 0)
				{
					scope = Scope.SemiGlobal;
				}

				s +=
					" "
					+ readStr(
						scope,
						GS.GlobalStr.UIEffect,
						ToShort(o[3], o[4]),
						lng ? -1 : 60,
						lng ? Detail.Normal : Detail.ErrorNames
					);
			}

			if (lng)
			{
				if (o[0] != 8)
				{
					Scope scope = Scope.Private;
					if ((o[5] & 0x01) != 0)
					{
						scope = Scope.Global;
					}
					else if ((o[5] & 0x02) != 0)
					{
						scope = Scope.SemiGlobal;
					}

					s +=
						", "
						+ pjse.Localization.GetString("bwp22_windowID")
						+ ": "
						+ readStr(
							scope,
							GS.GlobalStr.UIEffect,
							ToShort(o[1], o[2]),
							-1,
							lng ? Detail.Normal : Detail.ErrorNames
						);
				}
				else
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp_TNSID")
						+ ": "
						+ dataOwner(o[13], o[11], o[12]);
				}

				if (o[0] == 3)
				{
					s +=
						", "
						+ (
							ToShort(o[6], o[7]) != 0
								? pjse.Localization.GetString("bwp22_startingEffect")
								: pjse.Localization.GetString("bwp22_stoppingEffect")
						);
				}

				if (o[0] == 4 || o[0] == 8)
				{
					Scope scope = Scope.Global;
					if (o[10] == 0)
					{
						scope = Scope.Private;
					}
					else if (o[10] == 1)
					{
						scope = Scope.SemiGlobal;
					}

					bool found = false;
					s +=
						", "
						+ pjse.Localization.GetString("bwp_eventTree")
						+ ": "
						+ bhavName(ToShort(o[8], o[9]), ref found);
					s += " (" + pjse.Localization.GetString(scope.ToString()) + ")";
				}
			}

			return s;
#if DISASIM
			// case 0x22:  // UI Effect (false = error)
			//     c1 = b[x];
			//     c2 = b[x+5]; // flags
			//     w1 = *(UINT16 *) (&b[x+1]);
			//     w2 = *(UINT16 *) (&b[x+3]);
			//     w3 = *(UINT16 *) (&b[x+6]);
			//     w4 = *(UINT16 *) (&b[x+8]);
			//     w5 = *(UINT16 *) (&b[x+11]);

			//     switch (c1) {
			//         case 0:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Press Control ");
			//             break;
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Disable Control ");
			//             break;
			//         case 2:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Enable Control ");
			//             break;
			//         case 3:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Play Effect on Control ");
			//             break;
			//         case 4:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Set Event tree on Control ");
			//             break;
			//         case 5:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Reset State on All Controls ");
			//             break;
			//         case 6:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Disable All Controls ");
			//             break;
			//         case 7:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Reset event trees on All Controls ");
			//             break;
			//         case 8:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Set Event Tree on TNS node ");
			//             break;
			//         case 9:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Set Control Visible ");
			//             break;
			//         case 0xA:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Set Control Hidden ");
			//             break;
			//     }
			//     if (c1 < 5 || c1 > 8)
			//         if (c2 & 4) {
			//             if (readString2(GROUP_GLOBAL, 0x96, w2) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[Global STR# 0x96:0x%X]", w2);
			//         }
			//         else if (c2 & 8){
			//             if (readString2(gGlobGroup, 0x96, w2) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[SemiGlobal STR# 0x96:0x%X]", w2);
			//         }
			//         else {
			//             if (readString2(gGroup, 0x96, w2) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[Private STR# 0x96:0x%X]", w2);
			//         }
			//     if (c1 != 8) {
			//         ht_fprintf(outFile,TYPE_NORMAL," in window ");
			//         if (c2 & 1) {
			//             if (readString2(GROUP_GLOBAL, 0x96, w1) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[Global STR# 0x96:0x%X]", w1);
			//         }
			//         else if (c2 & 2){
			//             if (readString2(gGlobGroup, 0x96, w1) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[SemiGlobal STR# 0x96:0x%X]", w1);
			//         }
			//         else {
			//             if (readString2(gGroup, 0x96, w1) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[Private STR# 0x96:0x%X]", w1);
			//         }
			//     }
			//     if (c1 == 3)
			//         if (w3 != 0)
			//             ht_fprintf(outFile,TYPE_NORMAL," Starting Effect ");
			//         else
			//             ht_fprintf(outFile,TYPE_NORMAL," Stopping Effect ");
			//     if (c1 == 4 || c1 == 8)
			//         if (w4 == 0)
			//             ht_fprintf(outFile,TYPE_NORMAL," No Event Tree");
			//         else {
			//             switch (b[x+10]) {
			//                 case 0:
			//                     ht_fprintf(outFile,TYPE_NORMAL," Using Private Event Tree: ");
			//                     break;
			//                 case 1:
			//                     ht_fprintf(outFile,TYPE_NORMAL," Using SemiGlobal Event Tree: ");
			//                     break;
			//                 default:
			//                     ht_fprintf(outFile,TYPE_NORMAL," Using Global Event Tree: ");
			//                     break;
			//             }
			//             ht_fprintf(outFile,TYPE_NORMAL,"0x%X (",w4);
			//             readFn2(w4);
			//             ht_fprintf(outFile,TYPE_NORMAL,")");
			//         }
			//     if (c1 == 8) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", Getting TNS ID from ");
			//         data2(b[x+13],w5);
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x0023 : BhavWizPrim // Camera Control
	{
		public WizPrim0x0023(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				dnStkOb()
				+ ": "
				+ (
					(o[4] & 1) != 0
						? pjse.Localization.GetString("bwp23_visible")
						: pjse.Localization.GetString("bwp23_notVisible")
				);

			s +=
				", "
				+ pjse.Localization.GetString("bwp23_zoom")
				+ ": 0x"
				+ SimPe.Helper.HexString(o[3])
				+ " (";
			switch (o[3])
			{
				case 1:
					s += pjse.Localization.GetString("bwp23_far");
					break;
				case 2:
					s += pjse.Localization.GetString("bwp23_mid");
					break;
				case 3:
					s += pjse.Localization.GetString("bwp23_near");
					break;
				default:
					s += pjse.Localization.GetString("unk");
					break;
			}
			s += ")";

			s +=
				", "
				+ pjse.Localization.GetString("bwp23_center")
				+ ": "
				+ ((o[4] & 0x08) != 0).ToString();
			s +=
				", "
				+ pjse.Localization.GetString("bwp_timeout")
				+ ": "
				+ (
					(o[4] & 0x20) != 0
						? dataOwner(0x08, 0)
						: "0x" + SimPe.Helper.HexString(ToShort(o[0], o[1]))
				);
			s +=
				", "
				+ pjse.Localization.GetString("bwp23_slowDown")
				+ ": "
				+ ((o[4] & 0x40) == 0).ToString();

			return s;
#if DISASIM
			// case 0x23:  // Camera Control (false = error)
			//     c1 = b[x+4];    // flags
			//     w1 = *(UINT16 *) (&b[x]);
			//     if (c1 & 1) {
			//         ht_fprintf(outFile,TYPE_NORMAL,"show stack obj");
			//         switch (b[x+3]) {
			//             case 1:
			//                 ht_fprintf(outFile,TYPE_NORMAL,", far");
			//                 break;
			//             case 2:
			//                 ht_fprintf(outFile,TYPE_NORMAL,", mid");
			//                 break;
			//             case 3:
			//                 ht_fprintf(outFile,TYPE_NORMAL,", near");
			//                 break;
			//         }
			//         ht_fprintf(outFile,TYPE_NORMAL," zoom");
			//         if ((c1 & 0x40) == 0)
			//             ht_fprintf(outFile,TYPE_NORMAL,", slow down");
			//         if (c1 & 8)
			//             ht_fprintf(outFile,TYPE_NORMAL,", center");
			//         if (c1 & 0x20)
			//             ht_fprintf(outFile,TYPE_NORMAL,", using timeout in temp 0");
			//         else {
			//             ht_fprintf(outFile,TYPE_NORMAL,", using timeout of ");
			//             if (w1 < 10)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"%d", w1);
			//             else
			//                 ht_fprintf(outFile,TYPE_NORMAL,"%d (0x%X)", w1, w1);
			//         }
			//     } else
			//         ht_fprintf(outFile,TYPE_NORMAL,"un-show stack obj");
			//     break;
#endif
		}
	}

	public class WizPrim0x0024 : BhavWizPrim // Dialog
	{
		public WizPrim0x0024(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWiz0x0024(instruction);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			bool tvState = false;
			bool tnsState = false;
			bool lvState = false;
			bool[] states = { false, false, false, false, false }; // message, yes, no, cancel, title

			switch (o[5])
			{
				case 0x00:
				case 0x03:
				case 0x04:
					states[0] = states[1] = states[4] = true; // message, button 1, title
					break;
				case 0x02:
					tvState =
						states[0] =
						states[1] =
						states[2] =
						states[3] =
						states[4] =
							true; // message, button 1, button 2, button 3, title
					break;
				case 0x08:
				case 0x0a: // TNS, TNS modify
					tnsState = tvState = states[0] = true; // message
					break;
				case 0x09: // TNS stop
					tvState = true;
					break;
				case 0x0e:
					lvState = states[0] = states[1] = states[2] = states[4] = true; // message, button 1, button 2, title
					break;
				case 0x0f:
					states[1] = states[2] = true; // button 1, button 2
					break;
				case 0x13:
					states[1] = states[2] = states[4] = true; // button 1, button 2, title
					break;
				case 0x0b:
				case 0x0c:
				case 0x0d:
				case 0x10:
				case 0x11:
				case 0x12:
				case 0x14:
				case 0x15:
					break;
				case 0x16:
				case 0x19:
					states[0] = states[4] = true; // message, title
					break;
				case 0x1c: // TNS append
					tvState = states[0] = true; // message
					break;
				default:
					states[0] = states[1] = states[2] = states[4] = true; // message, button 1, button 2, title
					break;
			}

			ushort msg,
				cnc;
			if (instruction.NodeVersion == 0)
			{
				msg = o[2]; // message
				cnc = o[0]; // cancel
			}
			else
			{
				msg = ToShort(o[13], o[14]); // message
				cnc = ToShort(o[0], o[2]); // cancel
			}

			Scope scope;
			if ((o[8] & 0x01) != 0)
			{
				scope = Scope.SemiGlobal;
			}
			else if ((o[8] & 0x40) != 0)
			{
				scope = Scope.Global;
			}
			else
			{
				scope = Scope.Private;
			}

			string s = "";

			s += readStr(GS.BhavStr.Dialog, o[5]);

			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp24_strings")
					+ ": "
					+ pjse.Localization.GetString(scope.ToString());
			}

			if (states[4])
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp24_title")
					+ ": "
					+ dialogStr(scope, (o[8] & 0x10) != 0, o[6], lng ? -1 : 60);
			}

			if (states[0])
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp_message")
					+ ": "
					+ dialogStr(scope, (o[8] & 0x02) != 0, msg, lng ? -1 : 60);
			}

			if (lng)
			{
				if (states[1])
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp24_button1")
						+ ": "
						+ dialogStr(scope, (o[8] & 0x04) != 0, o[3]);
				}

				if (states[2])
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp24_button2")
						+ ": "
						+ dialogStr(scope, (o[8] & 0x08) != 0, o[4]);
				}

				if (states[3])
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp24_button3")
						+ ": "
						+ dialogStr(scope, (o[8] & 0x20) != 0, cnc);
				}
			}

			if (tnsState)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp24_TNSStyle")
					+ ": "
					+ readStr(GS.BhavStr.TnsStyle, o[12]);
				if (lng)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp_priority")
						+ ": 0x"
						+ SimPe.Helper.HexString((byte)(o[9] + 1));
					s +=
						", "
						+ pjse.Localization.GetString("bwp_timeout")
						+ ": 0x"
						+ SimPe.Helper.HexString(o[10]);
				}
			}

			if (lng)
			{
				byte tempVar = (byte)((o[7] >> 4) & 0x07);
				if (tvState)
				{
					s +=
						", "
						+ (
							o[5] == 0x02
								? pjse.Localization.GetString("bwp_resultIn")
								: pjse.Localization.GetString("bwp_TNSID")
						)
						+ ": "
						+ dataOwner(0x08, tempVar); // temp
				}

				if (lvState)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp24_Locals")
						+ ": "
						+ dataOwner(0x19, o[11]); // local
				}

				byte iconType = (byte)((o[7] >> 1) & 0x07);
				s +=
					", "
					+ pjse.Localization.GetString("bwp_icon")
					+ ": "
					+ readStr(GS.BhavStr.DialogIcon, iconType);
				switch (iconType)
				{
					case 3:
						s +=
							": BMP = 0x"
							+ SimPe.Helper.HexString((ushort)(o[1] + 5000));
						break;
					case 4:
						s += " " + dialogStr(scope, false, o[1]);
						break;
				}

				s +=
					", "
					+ pjse.Localization.GetString("bwp24_waitForUser")
					+ ": "
					+ ((o[7] & 0x01) == 0);
				s +=
					", "
					+ pjse.Localization.GetString("bwp24_blockSimulation")
					+ ": "
					+ ((o[7] & 0x80) == 0);

				s += ".  (" + readStr(GS.BhavStr.DialogDesc, o[5]) + ")";
			}

			return s;
#if DISASIM
			//                 case 0x24:  // Dialog
			//                     c1 = b[x+5];                 // prim
			//                     c2 = (b[x+7] >> 4) & 7;      // temp
			//                     c3 = b[x+8];                 // flags
			//                     if (nodeVersion) {
			//                         w1 = *(UINT16 *) (&b[x+13]); // message
			//                         w2 = b[x+2] << 8 + b[x]; // cancel
			//                     } else {
			//                         w1 = b[x+2];             // message
			//                         w2 = b[x];               // cancel
			//                     }
			//                     CHECK_RANGE("Dialog primitives", gStringD9, c1);
			//                     if (c1 == 2) {
			//                         data2(8, c2); // Temp
			//                         ht_fprintf(outFile,TYPE_NORMAL," := tri choice: ");
			//                     } else
			//                         ht_fprintf(outFile,TYPE_NORMAL,"%s: ", gStringD9[c1]);

			//                     if (c1 == 9) {
			//                         ht_fprintf(outFile,TYPE_NORMAL,", Getting Text Notification ID from temp %d", c2);
			//                         switch (b[x+12]) {
			//                             case 0:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", TNS Sim Type");
			//                                 break;
			//                             case 1:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", TNS System Type");
			//                                 break;
			//                         }
			//                     }
			//                     if (c1 == 0xE)
			//                         ht_fprintf(outFile,TYPE_NORMAL,"passing through data starting with local var %d", b[x+11]);

			//                     if (c1 < 9 || c1 == 0xA || c1 == 0xF || c1 == 0x13 || c1 > 0x14) {

			//                         if (c3 & 2) // ?
			//                             ht_fprintf(outFile,TYPE_NORMAL,", expecting message Index in temp 0");
			//                         else if (c3 & 1)
			//                             ht_fprintf(outFile,TYPE_NORMAL,"[SemiGlobal STR# 0x12D:0x%X]", w1 - 1);
			//                         else if (c3 & 0x40) {
			//                             CHECK_RANGE("Global Dialog Primitives", gDialogPrim, w1 - 1);
			//                             ht_fprintf(outFile,TYPE_NORMAL,"%s", gDialogPrim[w1 - 1]);
			//                         } else
			//                             ht_fprintf(outFile,TYPE_NORMAL,"[Private STR# 0x12D:0x%X]", w1 - 1);


			//                         if (c1 == 8 || c1 == 0xA) {
			//                             switch (b[x+12]) {
			//                                 case 0:
			//                                     ht_fprintf(outFile,TYPE_NORMAL,", TNS Sim Type");
			//                                     break;
			//                                 case 1:
			//                                     ht_fprintf(outFile,TYPE_NORMAL,", TNS System Type");
			//                                     break;
			//                                 case 2:
			//                                     ht_fprintf(outFile,TYPE_NORMAL,", TNS System Dialog Type");
			//                                     break;
			//                                 case 3:
			//                                     ht_fprintf(outFile,TYPE_NORMAL,", TNS Birthday Type");
			//                                     break;
			//                                 case 4:
			//                                     ht_fprintf(outFile,TYPE_NORMAL,", TNS Sim (about Object ID in Temp 1) Type");
			//                                     break;

			//                             }
			//                             ht_fprintf(outFile,TYPE_NORMAL,", priority %d", b[x+9] + 1);
			//                             ht_fprintf(outFile,TYPE_NORMAL,", timeout %d", b[x+10]);
			//                             if (c1 == 0xA)
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", getting Text ID in temp ");
			//                             else
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", putting Text ID in temp ");
			//                             ht_fprintf(outFile,TYPE_NORMAL,"%d",c2);

			//                         } else {

			//                             if (c3 & 4) // ?
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", expecting Yes button Index in temp 0");
			//                             else if (b[x+3] != 0) {
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", Yes: ");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x12D:0x%X]", b[x+3] - 1);
			//                             }
			//                             if (c3 & 8) // ?
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", expecting No button Index in temp 0");
			//                             else if (b[x+4] != 0) {
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", No: ");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x12D:0x%X]", b[x+4] - 1);
			//                             }
			//                             if (c3 & 0x10) // ?
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", expecting Title Index in temp 0");
			//                             else if (b[x+6] != 0) {
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", Title: ");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x12D:0x%X]", b[x+6] - 1);
			//                             }
			//                             if (c3 & 0x20) // ?
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", expecting Cancel Index in temp 0");
			//                             else if (w2 != 0) {
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", Cancel: ");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x12D:0x%X]", w2 - 1);
			//                             }
			// //                            if ((b[x+7] & 0x81) != 0) {
			// //                                if (b[x+7] & 1)
			// //                                    ht_fprintf(outFile,TYPE_NORMAL," return");
			// //                                else
			// //                                    ht_fprintf(outFile,TYPE_NORMAL," engage");
			// //                                ht_fprintf(outFile,TYPE_NORMAL," and ");
			// //                                if (b[x+7] & 0x80)
			// //                                    ht_fprintf(outFile,TYPE_NORMAL,"continue sim");
			// //                                else
			// //                                    ht_fprintf(outFile,TYPE_NORMAL,"block sim");
			// //                            }
			//                         }
			//                         if (w1 != 0x16 && w1 != 0x19 && (b[x+7] & 0xE) != 2) {
			//                             ht_fprintf(outFile,TYPE_NORMAL,", icon: ");
			//                             switch ((b[x+7] >> 1)& 7) {
			//                                 case 3:
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"BMP = 0x%X", (b[x+1] + 5000));
			//                                     break;
			//                                 case 4:
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x12D:0x%X]", b[x+1] - 1);
			//                                     break;
			//                                 default:
			//                                     CHECK_RANGE("Icon types", gStringF4, (b[x+7] >> 1) & 7);
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringF4[(b[x+7] >> 1) & 7]);
			//                                     break;
			//                             }
			//                         }

			//                     }
			//                     break;
#endif
		}

		private string dialogStr(Scope scope, bool temp, ushort instance, int len)
		{
			string s = "";
			if (temp)
			{
				s +=
					GS.GlobalStr.DialogString.ToString()
					+ ":["
					+ dataOwner(false, 0x08, instance)
					+ "]"; // temp
			}
			else
			{
				if (instance != 0)
				{
					s += readStr(
						scope,
						(uint)GS.GlobalStr.DialogString,
						(ushort)(instance - 1),
						len,
						Detail.ErrorNames,
						true
					);
				}
				else
				{
					s += "[" + pjse.Localization.GetString("none") + "]";
				}
			}
			return s;
		}

		private string dialogStr(Scope scope, bool temp, ushort instance)
		{
			return dialogStr(scope, temp, instance, -1);
		}
	}

	public class WizPrim0x0025 : BhavWizPrim // Test Sim Interacting With
	{
		public WizPrim0x0025(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			return dnMe() + " .. " + dnStkOb();
#if DISASIM
			// case 0x25:  // Test Sim Interacting With
			//     ht_fprintf(outFile,TYPE_NORMAL,"me with stack obj.");
			//     break;
#endif
		}
	}

	public class WizPrim0x002a : BhavWizPrim // Create new object instance -- for wizard, see edithWiki AkeaPostMortem
	{
		public WizPrim0x002a(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			if ((o[5] & 0x04) != 0)
			{
				s += DoidName(0x18);
			}
			else if ((o[5] & 0x40) != 0)
			{
				s += (lng ? "GUID: " : "") + DoidName(0x27);
			}
			else if ((o[5] & 0x80) != 0)
			{
				s += (lng ? "GUID: " : "") + dataOwner(0x08, 0x00) + ",1";
			}
			else
			{
				s += BhavWiz.FormatGUID(lng, o, 0);
			}

			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp2a_place")
					+ ": "
					+ readStr(GS.BhavStr.CreatePlace, o[4]);
				switch (o[4])
				{
					case 0x04:
						s = s.Replace(DoidName(0x10), dataOwner(0x10, o[9]));
						break;
					case 0x08:
					case 0x09:
						s = s.Replace(dnLocal(), dataOwner(0x19, o[6]));
						break;
					case 0x0A:
						s = s.Replace("[slot]", "0x" + SimPe.Helper.HexString(o[9]));
						break;
				}

				s += ", " + readStr(GS.BhavStr.CreateHow, (ushort)(o[5] & 0x03));
				s +=
					", "
					+ pjse.Localization.GetString("bwp2a_failNonEmpty")
					+ ": "
					+ ((o[5] & 0x08) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp2a_passTemp0")
					+ ": "
					+ ((o[5] & 0x10) != 0).ToString();

				s +=
					", "
					+ pjse.Localization.GetString("bwp2a_moveInNewSim")
					+ ": "
					+ ((o[10] & 0x01) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp2a_copyTemp5")
					+ ": "
					+ ((o[10] & 0x02) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x2A:  // Create New Object Instance
			//     if (b[x+5] & 4)
			//         ht_fprintf(outFile,TYPE_NORMAL,"neighbor in stack obj");
			//     else if (b[x+5] & 0x40)
			//         ht_fprintf(outFile,TYPE_NORMAL,"from GUID in temp Inventory Token");
			//     else if (b[x+5] & 0x80)
			//         ht_fprintf(outFile,TYPE_NORMAL,"from GUID in temp0/1");
			//     else {
			//         d1 = *(UINT32 *) (&b[x]);
			//         if (d1 == 0)
			//             ht_fprintf(outFile,TYPE_NORMAL,"GUID 0");
			//         else {
			//             ht_fprintf(outFile,TYPE_NORMAL,"GUID 0x%08X", d1);
			//             readGUID(d1);
			//         }
			//     }
			//     ht_fprintf(outFile,TYPE_NORMAL,", place ");
			//     c1 = b[x+4];
			//     switch (c1) {
			//         case 4:
			//             ht_fprintf(outFile,TYPE_NORMAL,"in stack objs slot %d", b[x+9]);
			//             break;
			//         case 0xA:
			//             ht_fprintf(outFile,TYPE_NORMAL,"in obj in temp 0's slot %d", b[x+9]);
			//             break;
			//         default:
			//             CHECK_RANGE("Object place", gStringA7, c1);
			//             ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringA7[c1]);
			//             break;
			//     }
			//     if (c1 == 8 || c1 == 9) {
			//         ht_fprintf(outFile,TYPE_NORMAL," ");
			//         data2(0x19, b[x+6]);     // local
			//     }
			//     c2 = b[x+5];
			//     if (c2 & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,", pass object ids to main");
			//     else if (c2 & 0x10)
			//         ht_fprintf(outFile,TYPE_NORMAL,", pass temp 0 to main");
			//     if (c2 & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", do not duplicate");
			//     if (c2 & 8)
			//         ht_fprintf(outFile,TYPE_NORMAL,", fail if tile is non-empty");
			//     if (b[x+10] & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Moving in a new Sim");
			//     if (b[x+10] & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,", copying design mode materials from object in temp5");
			//     break;
#endif
		}
	}

	public class WizPrim0x002d : BhavWizPrim // Go To Routing Slot -- for wizard, see edithWiki CreatingAChair
	{
		public WizPrim0x002d(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWiz0x002d(instruction);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			if ((o[4] & 0x02) == 0)
			{
				switch (ToShort(o[2], o[3]))
				{
					case 0:
						s += dataOwner(lng, 0x09, o[0], o[1]); // Param
						break;
					case 1:
						s += "0x" + SimPe.Helper.HexString(ToShort(o[0], o[1]));
						break;
					case 2:
						s +=
							pjse.Localization.GetString("lcGlobal")
							+ " 0x"
							+ SimPe.Helper.HexString(ToShort(o[0], o[1]));
						break;
					case 3:
						s += dataOwner(lng, 0x19, o[0], o[1]); // Local
						break;
					default:
						s += "??? 0x" + SimPe.Helper.HexString(ToShort(o[0], o[1]));
						break;
				}
			}
			else
			{
				s += dataOwner(lng, 0x08, o[0], o[1]); // Temp
			}

			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp_noFailureTrees")
					+ ": "
					+ ((o[4] & 0x01) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp2d_ignoreDestObjFootprint")
					+ ": "
					+ ((o[4] & 0x04) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp2d_allowDiffAltitudes")
					+ ": "
					+ ((o[4] & 0x08) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x2D:  // Go To Routing Slot
			//     w1 = *(UINT16 *) (&b[x]);
			//     w2 = *(UINT16 *) (&b[x+2]);
			//     switch (w2) {
			//         case 0:
			//             ht_fprintf(outFile,TYPE_NORMAL,"in ");
			//             data2(9, w1);   // param
			//             break;
			//         case 1:
			//             if (b[x+4] & 2)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"From Slot index in Temp 0", w1);
			//             else
			//                 ht_fprintf(outFile,TYPE_NORMAL,"0x%X", w1);
			//             break;
			//         case 2:
			//             ht_fprintf(outFile,TYPE_NORMAL,"global 0x%X", w1);
			//             break;
			//         case 3:
			//             ht_fprintf(outFile,TYPE_NORMAL,"in ");
			//             data2(0x19, w1);   // local
			//             break;
			//         default:
			//             ht_fprintf(outFile,TYPE_NORMAL,"??? 0x%X", w1);
			//     }
			//     if (b[x+4] & 1) ht_fprintf(outFile,TYPE_NORMAL,", no failure trees");
			//     if (b[x+4] & 4) ht_fprintf(outFile,TYPE_NORMAL,", ignoring dest obj footprint");
			//     if (b[x+4] & 8) ht_fprintf(outFile,TYPE_NORMAL,", allow different altitudes");
			//     break;
#endif
		}
	}

	public class WizPrim0x002e : BhavWizPrim // Snap -- for wizard, see edithWiki CreatingAChair (assume this is s/t/r/s)
	{
		public WizPrim0x002e(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			ushort snapType = ToShort(o[2], o[3]);

			s += readStr(GS.BhavStr.SnapType, snapType);

			if ((o[4] & 0x08) != 0)
			{
				if (snapType == 0)
				{
					s += " [" + dataOwner(0x08, 0x00) + "]"; // Temp
				}
				else if (snapType == 3 || snapType == 4)
				{
					s = s.Replace("[slot]", "[" + dataOwner(0x08, 0x00) + "]");
				}
			}
			else
			{
				if (snapType == 0)
				{
					s = s.Replace(dnParam(), dataOwner(lng, 0x09, o[0], o[1])); // Param
				}
				else if (snapType == 3 || snapType == 4)
				{
					s = s.Replace(
						"[slot]",
						"0x" + SimPe.Helper.HexString(ToShort(o[0], o[1]))
					);
				}
			}

			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp2e_fromTemp1")
					+ ": "
					+ (ToShort(o[8], o[9]) == 1).ToString();

				s +=
					", "
					+ pjse.Localization.GetString("bwp2e_askSimToMove")
					+ ": "
					+ ((o[4] & 0x02) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_testOnly")
					+ ": "
					+ ((o[4] & 0x10) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x2E:  // Snap
			//     w1 = *(UINT16 *) (&b[x]);
			//     w2 = *(UINT16 *) (&b[x+2]);
			//     w3 = *(UINT16 *) (&b[x+8]);
			//     CHECK_RANGE("Snap mode", gStringCF, w2);
			//     ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringCF[w2]);
			//     if (w2 == 0 || w2 == 3 || w2 == 4)
			//         if (b[x+4] & 8)
			//             ht_fprintf(outFile,TYPE_NORMAL," to slot in temp 0");
			//         else
			//             ht_fprintf(outFile,TYPE_NORMAL," 0x%X", w1);
			//     if (w3 == 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", from slot in temp 1");
			//     if (b[x+4] & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,", ask person to move");
			//     if (b[x+4] & 0x10)
			//         ht_fprintf(outFile,TYPE_NORMAL,", TEST ONLY");
			//     break;
#endif
		}
	}

	public class WizPrim0x0030 : BhavWizPrim // Stop ALL Sounds
	{
		public WizPrim0x0030(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			return (ToShort(o[0], o[1]) == 0 ? dnMe() : dnStkOb());
#if DISASIM
			// case 0x30:  // Stop ALL Sounds (false = error)
			//     w1 = *(UINT16 *) (&b[x]);
			//     if (w1 == 0)
			//         ht_fprintf(outFile,TYPE_NORMAL,"of Me");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,"of Stack Object");
			//     break;
#endif
		}
	}

	public class WizPrim0x0031 : BhavWizPrim // Notify the Stack Object out of Idle
	{
		public WizPrim0x0031(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			return "-";
#if DISASIM
			// case 0x31:  // Notify the Stack Object out of Idle (implied, false = error)
			//     break;
#endif
		}
	}

	public class WizPrim0x0032 : BhavWizPrim // Add/Change action string (disaSim2 24b)
	{
		public WizPrim0x0032(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWiz0x0032(instruction);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			if (o[9] == 0)
			{
				Scope scope = Scope.Private;
				if ((o[2] & 0x04) != 0)
				{
					scope = Scope.Global;
				}
				else if ((o[2] & 0x08) != 0)
				{
					scope = Scope.SemiGlobal;
				}

				if (lng)
				{
					s += pjse.Localization.GetString("bwp32_addChange");
					if (instruction.NodeVersion != 0)
					{
						s +=
							", " + pjse.Localization.GetString("bwp32_disabled") + ": ";
						if ((o[3] & 0x01) != 0)
						{
							s += pjse.Localization.GetString("bwp32_propagating");
						}
						else if ((o[3] & 0x02) != 0)
						{
							s += pjse.Localization.GetString("bwp32_nonPropagating");
						}
						else
						{
							s += false.ToString();
						}
					}
					if (instruction.NodeVersion > 2)
					{
						s +=
							", "
							+ pjse.Localization.GetString("bwp32_subqueue")
							+ ": "
							+ ((o[3] & 0x10) != 0);
					}

					s += ", ";
				}

				if ((o[2] & 0x10) != 0)
				{
					s +=
						GS.GlobalStr.MakeAction.ToString()
						+ ":["
						+ dataOwner(false, 0x08, 0)
						+ "]"; // Temp 0
				}
				else
				{
					s += readStr(
						scope,
						GS.GlobalStr.MakeAction,
						(ushort)(
							(
								instruction.NodeVersion < 2
									? o[0x04]
									: ToShort(o[0x0e], o[0x0f])
							) - 1
						),
						lng ? -1 : 60,
						lng ? Detail.Normal : Detail.ErrorNames
					);
				}
			}
			else
			{
				s += pjse.Localization.GetString("bwp32_iconChange");

				s +=
					", "
					+ pjse.Localization.GetString("bwp32_iconIndex")
					+ ": "
					+ (
						((o[2] & 0x80) != 0)
							? dataOwner(false, 0x08, 1) // Temp 1
							: "0x" + SimPe.Helper.HexString(o[10])
					);

				if (lng)
				{
					if ((o[2] & 0x20) != 0)
					{
						s +=
							", "
							+ pjse.Localization.GetString("bwp32_thumbnailOutfit")
							+ ": "
							+ (
								((o[2] & 0x40) != 0)
									? "GUID " + dataOwner(false, 0x08, 2) + ",3" // Temp 2,3
									: BhavWiz.FormatGUID(lng, o, 5)
							);
					}
					else
					{
						s +=
							", "
							+ pjse.Localization.GetString("Object")
							+ ": "
							+ dataOwner(lng, o[11], o[12], o[13]);
					}
				}
			}

			return s;
#if DISASIM
			// case 0x32:  // Add/Change the Action String (false = error)
			//     c2 = b[x+2]; // flags
			//     if (b[x+9] == 0) {
			//         if (nodeVersion < 2)
			//             c1 = b[x+4] - 1;
			//         else
			//             c1 = b[x+14] - 1;
			//         ht_fprintf(outFile,TYPE_NORMAL,"Add / Change Interaction string Mode, ");
			//         if ((b[x+3] & 0x10) && (nodeVersion > 2))
			//             ht_fprintf(outFile,TYPE_NORMAL,"To Sub Queue, ");
			//         if ((b[x+3] & 1) && nodeVersion)
			//             ht_fprintf(outFile,TYPE_NORMAL,"Disabled (Propagating), ");
			//         if (b[x+3] & 2)
			//             ht_fprintf(outFile,TYPE_NORMAL,"Disabled (NonPropagating), ");
			//         if (c2 & 0x10) {
			//             ht_fprintf(outFile,TYPE_NORMAL,"Getting index from temp 0");
			//             if (c2 & 4) {
			//                 ht_fprintf(outFile,TYPE_NORMAL,", getting string from globals");
			//             } else if (c2 & 8) {
			//                 ht_fprintf(outFile,TYPE_NORMAL,", getting string from semiglobals");
			//             } else
			//                 ht_fprintf(outFile,TYPE_NORMAL,", getting string from privates");
			//         }
			//         else if (c2 & 4) {
			//             CHECK_RANGE("Action string", gActionString, c1);
			//             ht_fprintf(outFile,TYPE_NORMAL,"%s", gActionString[c1]);
			//         } else if (c2 & 8) {
			//             if (readString2(gGlobGroup, 0x12E, c1) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[SemiGlobal STR# 0x12E:0x%X]", c1);
			//         }
			//         else if (readString2(gGroup, 0x12E, c1) == 0)
			//             ht_fprintf(outFile,TYPE_NORMAL,"[Private STR# 0x12E:0x%X]", c1);
			//     } else {
			//         ht_fprintf(outFile,TYPE_NORMAL,"Interaction Icon Change Mode");
			//         if (c2 & 0x20) {
			//             ht_fprintf(outFile,TYPE_NORMAL,", Using external guid for Thumbnail Outfit from ");
			//             if (c2 & 0x40)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"GUID in temp2/3");
			//             else {
			//                 d1 = *(UINT32 *) (&b[x+5]);
			//                 if (d1 == 0)
			//                     ht_fprintf(outFile,TYPE_NORMAL,"GUID 0");
			//                 else {
			//                    ht_fprintf(outFile,TYPE_NORMAL,"GUID 0x%08X", d1);
			//                    readGUID(d1);
			//                 }
			//             }
			//         } else {
			//             w1 = *(UINT16 *) (&b[x+12]);
			//             ht_fprintf(outFile,TYPE_NORMAL,", Using object ID in ");
			//             data2(b[x+11], w1);
			//         }
			//         if (c2 & 0x80)
			//             ht_fprintf(outFile,TYPE_NORMAL,", Getting icon index into model table from temp 1");
			//         else
			//             ht_fprintf(outFile,TYPE_NORMAL,", Using index of %d",b[x+10]);
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x0033 : BhavWizPrim // Manage Inventory -- for wizard, see edithWiki WorkAndSchool, Career rewards (disaSim2 24b)
	{
		public WizPrim0x0033(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWiz0x0033(instruction);
		}

		private string tokenType(int i, int j, bool all)
		{
			//string[] tokType = { "any", "all", "non-visible", "visible", "non-memory", "memory", "non-shopping", "shopping", };

			string s = "";
			if ((i & 0x04) != 0)
			{
				s +=
					readStr(
						GS.BhavStr.TokenType,
						(ushort)(2 + ((j & 0x10) == 0 ? 0 : 1))
					) + " ";
			}

			if ((i & 0x08) != 0)
			{
				s +=
					readStr(
						GS.BhavStr.TokenType,
						(ushort)(4 + ((j & 0x20) == 0 ? 0 : 1))
					) + " ";
			}

			if ((i & 0x20) != 0)
			{
				s +=
					readStr(
						GS.BhavStr.TokenType,
						(ushort)(6 + ((i & 0x01) == 0 ? 0 : 1))
					) + " ";
			}

			if ((i & 0x2c) == 0)
			{
				s += readStr(GS.BhavStr.TokenType, (ushort)(all ? 1 : 0)) + " ";
			}

			return s.Trim();
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			byte c1 =
				(instruction.NodeVersion >= 1)
					? o[0]
					: (byte)(((o[0] & 0x3C) << 1) | (o[0] & 0x83));
			byte c2 = (instruction.NodeVersion >= 2) ? o[9] : (byte)0x0c;

			bool byGUID,
				index2,
				index,
				count,
				frominv,
				reversed,
				propno,
				propval,
				ignoreinv;
			byGUID =
				index2 =
				index =
				count =
				frominv =
				reversed =
				propno =
				propval =
				ignoreinv =
					false;
			int toktype = 0;

			if ((c1 & 0x08) != 0) // Counted
			{
				s += readStr(GS.BhavStr.TokenOpsCounted, o[4]);
				switch (o[4])
				{
					case 0x00:
						byGUID = count = true;
						toktype = 2;
						break;
					case 0x01:
						index = count = true;
						break;
					case 0x02:
						byGUID = count = true;
						toktype = 2;
						break;
					case 0x03:
						index = count = true;
						break;

					case 0x04:
						byGUID = true;
						toktype = 2;
						break;
					case 0x05:
						index = true;
						break;
					case 0x06:
						byGUID = index = true;
						toktype = 2;
						break;
					case 0x07:
						byGUID = true;
						toktype = 2;
						break;

					case 0x08:
						index = true;
						break;
					case 0x09:
						index = true;
						toktype = 1;
						break;
					case 0x0a:
						byGUID = count = true;
						toktype = 2;
						break;
					case 0x0b:
						index = true;
						frominv = lng;
						toktype = 2;
						break;
				}
			}
			else // Singular
			{
				s += readStr(GS.BhavStr.TokenOpsSingular, o[4]);
				switch (o[4])
				{
					case 0x00:
						byGUID = true;
						toktype = 2;
						break;
					case 0x01:
						index = true;
						break;
					case 0x02:
						byGUID = true;
						toktype = 2;
						break;
					case 0x03:
						byGUID = true;
						toktype = 2;
						index = reversed = true;
						break;

					case 0x04:
						index = propval = true;
						break;
					case 0x05:
						index = propval = true;
						break;
					case 0x06:
						index = true;
						break;
					case 0x07:
						propno = propval = ignoreinv = true;
						break;

					case 0x08:
						propno = propval = ignoreinv = true;
						break;
					case 0x09:
						ignoreinv = true;
						break;
					case 0x0a:
						count = true;
						break;
					case 0x0b:
						toktype = 2;
						break;

					case 0x0c:
						toktype = 2;
						index = reversed = true;
						break;
					case 0x0d:
						toktype = 1;
						count = true;
						break;
					case 0x0e:
						index2 = propno = propval = true;
						break;
					case 0x0f:
						index2 = propno = propval = true;
						break;

					case 0x10:
						toktype = 2;
						break;
					case 0x11:
						index = true;
						break;
					case 0x12:
						toktype = 2;
						frominv = lng;
						index = true;
						break;
					case 0x13:
						toktype = 2;
						break;
				}
			}

			if (byGUID)
			{
				uint d1 = (uint)(o[5] | (o[6] << 8) | (o[7] << 16) | (o[8] << 24));
				s +=
					(lng ? ", " + pjse.Localization.GetString("bwp33_token") + ":" : "")
					+ " "
					+ (d1 == 0 ? dnStkOb() : BhavWiz.FormatGUID(lng, d1));
			}

			if (toktype != 0)
			{
				s +=
					(lng ? ", " + pjse.Localization.GetString("bwp33_category") : "")
					+ ": "
					+ (
						(instruction.NodeVersion >= 2)
							? "0x" + SimPe.Helper.HexString(o[9]) + " - "
							: ""
					)
					+ tokenType(c2, c1, toktype == 1);
			}

			if (lng)
			{
				if (reversed)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp33_reversed")
						+ ": "
						+ ((c1 & 0x80) != 0).ToString();
				}

				if (!ignoreinv)
				{
					s += ", " + pjse.Localization.GetString("bwp33_Inventory");
					s +=
						" ("
						+ (
							(c1 & 0x08) != 0
								? pjse.Localization.GetString("bwp33_counted")
								: pjse.Localization.GetString("bwp33_singular")
						)
						+ ")";
					s += ": " + readStr(GS.BhavStr.InventoryType, (ushort)(c1 & 0x07));
					if ((c1 & 0x07) >= 1 && (c1 & 0x07) <= 3)
					{
						s += /*", " + "ID" +*/
							": " + dataOwner(o[1], o[2], o[3]);
					}

					if (frominv)
					{
						s +=
							", "
							+ pjse.Localization.GetString("bwp33_fromInventory")
							+ ": "
							+ readStr(GS.BhavStr.InventoryType, (ushort)(o[6] & 0x07));
						if ((o[6] & 0x07) >= 1 && (o[6] & 0x07) <= 3)
						{
							s += /*", " + "ID" +*/
								": " + dataOwner(lng, o[13], o[14], o[15]);
						}
					}

					if (index)
					{
						s +=
							", "
							+ pjse.Localization.GetString("bwp33_index")
							+ ": "
							+ dataOwner(lng, o[10], o[11], o[12]);
					}

					if (index2)
					{
						s +=
							", "
							+ pjse.Localization.GetString("bwp33_index")
							+ ": "
							+ dataOwner(lng, o[6], o[7], o[8]);
					}
				}

				if (propno)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp33_property")
						+ ": "
						+ dataOwner(lng, o[10], o[11], o[12]);
				}

				if (propval)
				{
					s +=
						", "
						+ pjse.Localization.GetString("Value")
						+ ": "
						+ dataOwner(lng, o[13], o[14], o[15]);
				}

				if (count)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp33_count")
						+ ": "
						+ dataOwner(lng, o[13], o[14], o[15]);
				}
			}

			return s;
#if DISASIM
			//                 case 0x33:  // Manage Inventory
			//                     w1 = *(UINT16 *) (&b[x+14]);
			//                     w2 = *(UINT16 *) (&b[x+11]);
			//                     w3 = *(UINT16 *) (&b[x+2]);
			//                     w4 = *(UINT16 *) (&b[x+7]);
			//                     c1 = b[x];
			//                     if (nodeVersion == 0)
			//                         c1 = ((c1 & 0x3C) << 1) | (c1 & 0x83);
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Access the ");
			//                     switch (c1 & 7) {
			//                         case 0:
			//                             ht_fprintf(outFile,TYPE_NORMAL,"Global ");
			//                             break;
			//                         case 1:
			//                             ht_fprintf(outFile,TYPE_NORMAL,"Lot ");
			//                             break;
			//                         case 2:
			//                             ht_fprintf(outFile,TYPE_NORMAL,"Family ");
			//                             break;
			//                         case 3:
			//                             ht_fprintf(outFile,TYPE_NORMAL,"Neighbor ");
			//                             break;
			//                         case 4:
			//                             ht_fprintf(outFile,TYPE_NORMAL,"Game-Wide ");
			//                             break;
			//                     }
			//                     if (c1 & 8)
			//                         ht_fprintf(outFile,TYPE_NORMAL,"Counted Inventory");
			//                     else
			//                         ht_fprintf(outFile,TYPE_NORMAL,"Singular Inventory");
			//                     if ((c1 & 7) != 0) {
			//                         ht_fprintf(outFile,TYPE_NORMAL," from ID ");
			//                         data2(b[x+1], w3);
			//                     }
			//                     ht_fprintf(outFile,TYPE_NORMAL,". with category %d",b[x+9]);
			//                     if ((c1 & 8) && (b[x+4] != 0xB) || ((c1 & 8) == 0) && (b[x+4] != 0xE) && (b[x+4] != 0xF) && (b[x+4] != 0x12)) { //??
			// //                    if ((b[x+4] != 0xE) && (b[x+4] != 0xF)) { //??
			//                         d1 = *(UINT32 *) (&b[x+5]);
			//                         if (d1 != 0) {
			//                             ht_fprintf(outFile,TYPE_NORMAL," GUID 0x%08X", d1);
			//                             readGUID(d1);
			//                             ht_fprintf(outFile,TYPE_NORMAL,". "); //?
			//                         }
			//                         else
			//                             ht_fprintf(outFile,TYPE_NORMAL," of GUID from Stack Object. ");
			//                     } else
			//                         ht_fprintf(outFile,TYPE_NORMAL,". ");
			//                     if (c1 & 8)
			//                         switch (b[x+4]) {
			//                             case 0:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Add token");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,". Pull count from ");
			//                                 data2(b[x+13], w1);
			//                                 break;
			//                             case 1:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Add to token at index from ");
			//                                 data2(b[x+10], w2);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,". Pull count from ");
			//                                 data2(b[x+13], w1);
			//                                 break;
			//                             case 2:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Remove token");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,". Pull count from ");
			//                                 data2(b[x+13], w1);
			//                                 break;
			//                             case 3:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Remove to token at index from");
			//                                 data2(b[x+10], w2);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,". Pull count from ");
			//                                 data2(b[x+13], w1);
			//                                 break;
			//                             case 4:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Remove all tokens");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 5:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Remove all tokens from token at index from");
			//                                 data2(b[x+10], w2);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 6:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Find the token");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,". Put count into ");
			//                                 data2(b[x+13], w1);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 7:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Read token");
			//                                 ht_fprintf(outFile,TYPE_NORMAL," into My Temp Token.");
			//                                 break;
			//                             case 8:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Read token at index from ");
			//                                 data2(b[x+10], w2);
			//                                 ht_fprintf(outFile,TYPE_NORMAL," into My Temp Token.");
			//                                 break;
			//                             case 9:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Set To Next token");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,". Starting at index from ");
			//                                 data2(b[x+10], w2);
			//                                 break;
			//                             case 0xA:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Store the count of the tokens in this inventory into ");
			//                                 data2(b[x+13], w1);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 0xB:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Copy token at index ");
			//                                 data2(b[x+10], w2);
			//                                 ht_fprintf(outFile,TYPE_NORMAL," from the ");
			//                                 switch (b[x+6] & 7) {
			//                                     case 0:
			//                                         ht_fprintf(outFile,TYPE_NORMAL,"Global ");
			//                                         break;
			//                                     case 1:
			//                                         ht_fprintf(outFile,TYPE_NORMAL,"Lot ");
			//                                         break;
			//                                     case 2:
			//                                         ht_fprintf(outFile,TYPE_NORMAL,"Family ");
			//                                         break;
			//                                     case 3:
			//                                         ht_fprintf(outFile,TYPE_NORMAL,"Neighbor ");
			//                                         break;
			//                                     case 4:
			//                                         ht_fprintf(outFile,TYPE_NORMAL,"Game-Wide ");
			//                                         break;
			//                                 }

			//                                 if ((b[x+6] & 7) > 0 && (b[x+6] & 7) <= 3) {
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"inventory with id ");
			//                                     data2(b[x+13], w1);
			//                                 } else ht_fprintf(outFile,TYPE_NORMAL,"inventory");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                         }
			//                     else {
			//                         if (nodeVersion < 2)
			//                             c2 = 0xC;
			//                         else
			//                             c2 = b[x+9];
			//                         switch (b[x+4]) {
			//                             case 0:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Add token");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 1:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Remove token at index from ");
			//                                 data2(b[x+10], w2);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 2:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Remove ");
			//                                 if (c2 & 4)
			//                                     if (c1 & 0x10) ht_fprintf(outFile,TYPE_NORMAL,"visible ");
			//                                     else ht_fprintf(outFile,TYPE_NORMAL,"hidden ");
			//                                 if (c2 & 8)
			//                                     if (c1 & 0x10) ht_fprintf(outFile,TYPE_NORMAL,"memory ");
			//                                     else ht_fprintf(outFile,TYPE_NORMAL,"non-memory ");
			//                                 if (c2 & 0x20)
			//                                     if (c2 & 1) ht_fprintf(outFile,TYPE_NORMAL,"shopping ");
			//                                     else ht_fprintf(outFile,TYPE_NORMAL,"non-shopping ");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"tokens");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 3:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Set To Next ");
			//                                 if (c2 & 4)
			//                                     if (c1 & 0x10) ht_fprintf(outFile,TYPE_NORMAL,"visible ");
			//                                     else ht_fprintf(outFile,TYPE_NORMAL,"hidden ");
			//                                 if (c2 & 8)
			//                                     if (c1 & 0x10) ht_fprintf(outFile,TYPE_NORMAL,"memory ");
			//                                     else ht_fprintf(outFile,TYPE_NORMAL,"non-memory ");
			//                                 if (c2 & 0x20)
			//                                     if (c2 & 1) ht_fprintf(outFile,TYPE_NORMAL,"shopping ");
			//                                     else ht_fprintf(outFile,TYPE_NORMAL,"non-shopping ");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"token. Starting at index from ");
			//                                 data2(b[x+10], w2);
			//                                 if (c1 & 0x80)
			//                                     ht_fprintf(outFile,TYPE_NORMAL,", Reversed.");
			//                                 else
			//                                     ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 4:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Push property on token at index from ");
			//                                 data2(b[x+10], w2);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,". Get property value from ");
			//                                 data2(b[x+13], w1);
			//                                 break;
			//                             case 5:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Pop property off token at index from ");
			//                                 data2(b[x+10], w2);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,". Put property value into ");
			//                                 data2(b[x+13], w1);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 6:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Read token into My Temp Token at index from ");
			//                                 data2(b[x+10], w2);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 7:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Get property from token in My Temp Token at index from ");
			//                                 data2(b[x+10], w2);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,". Put property value into ");
			//                                 data2(b[x+13], w1);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 8:
			//                                 break;
			//                             case 9:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Save My Temp Token back to the location it was loaded from.");
			//                                 break;
			//                             case 0xA:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Store the count of the tokens in this inventory into ");
			//                                 data2(b[x+13], w1);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 0xB:
			//                                 break;
			//                             case 0xC:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Set To Next ");
			//                                 if (c2 & 4)
			//                                     if (c1 & 0x10) ht_fprintf(outFile,TYPE_NORMAL,"visible ");
			//                                     else ht_fprintf(outFile,TYPE_NORMAL,"hidden ");
			//                                 if (c2 & 8)
			//                                     if (c1 & 0x10) ht_fprintf(outFile,TYPE_NORMAL,"memory ");
			//                                     else ht_fprintf(outFile,TYPE_NORMAL,"non-memory ");
			//                                 if (c2 & 0x20)
			//                                     if (c2 & 1) ht_fprintf(outFile,TYPE_NORMAL,"shopping ");
			//                                     else ht_fprintf(outFile,TYPE_NORMAL,"non-shopping ");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"token. Starting at index from ");
			//                                 data2(b[x+10], w2);
			//                                 if (c1 & 0x80)
			//                                     ht_fprintf(outFile,TYPE_NORMAL,", Reversed.");
			//                                 else
			//                                     ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 0xD:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Store the count of the ");
			//                                 if (c2 & 4)
			//                                     if (c1 & 0x10) ht_fprintf(outFile,TYPE_NORMAL,"visible ");
			//                                     else ht_fprintf(outFile,TYPE_NORMAL,"hidden ");
			//                                 if (c2 & 8)
			//                                     if (c1 & 0x10) ht_fprintf(outFile,TYPE_NORMAL,"memory ");
			//                                     else ht_fprintf(outFile,TYPE_NORMAL,"non-memory ");
			//                                 if (c2 & 0x20)
			//                                     if (c2 & 1) ht_fprintf(outFile,TYPE_NORMAL,"shopping ");
			//                                     else ht_fprintf(outFile,TYPE_NORMAL,"non-shopping ");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"tokens in this inventory into ");
			//                                 data2(b[x+13], w1);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 0xE:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Token Index ");
			//                                 data2(b[x+6], w4);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", Property ");
			//                                 data2(b[x+10], w2);
			//                                 ht_fprintf(outFile,TYPE_NORMAL," Assign to: ");
			//                                 data2(b[x+13], w1);
			//                                 break;
			//                             case 0xF:
			//                                 data2(b[x+13], w1);
			//                                 ht_fprintf(outFile,TYPE_NORMAL," Assign to: Token Index ");
			//                                 data2(b[x+6], w4);
			//                                 ht_fprintf(outFile,TYPE_NORMAL,", Property ");
			//                                 data2(b[x+10], w2);
			//                                 break;
			//                             case 0x10:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Add Token And Instance Info of Stack Object.");
			//                                 break;
			//                             case 0x11:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Create Object from Token at Index.");
			//                                 break;
			//                             case 0x12:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Copy token at index ");
			//                                 data2(b[x+10], w2);
			//                                 ht_fprintf(outFile,TYPE_NORMAL," from the ");
			//                                 switch (b[x+6] & 7) {
			//                                     case 0:
			//                                         ht_fprintf(outFile,TYPE_NORMAL,"Global ");
			//                                         break;
			//                                     case 1:
			//                                         ht_fprintf(outFile,TYPE_NORMAL,"Lot ");
			//                                         break;
			//                                     case 2:
			//                                         ht_fprintf(outFile,TYPE_NORMAL,"Family ");
			//                                         break;
			//                                     case 3:
			//                                         ht_fprintf(outFile,TYPE_NORMAL,"Neighbor ");
			//                                         break;
			//                                     case 4:
			//                                         ht_fprintf(outFile,TYPE_NORMAL,"Game-Wide ");
			//                                         break;
			//                                 }

			//                                 if ((b[x+6] & 7) > 0 && (b[x+6] & 7) <= 3) {
			//                                     ht_fprintf(outFile,TYPE_NORMAL,"inventory with id ");
			//                                     data2(b[x+13], w1);
			//                                 } else ht_fprintf(outFile,TYPE_NORMAL,"inventory");
			//                                 ht_fprintf(outFile,TYPE_NORMAL,".");
			//                                 break;
			//                             case 0x13:
			//                                 ht_fprintf(outFile,TYPE_NORMAL,"Add Token And Instance Info of Stack Object excluding contained objects.");
			//                                 break;
			//                         }
			//                     }
			//                     break;
#endif
		}
	}

	public class WizPrim0x0069 : BhavWizPrim // Animate Object
	{
		public WizPrim0x0069(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWizAnimate(
				instruction,
				"bwp_Object"
			);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				(lng ? pjse.Localization.GetString("Object") + ": " : "")
				+ dataOwner(lng, o[6], o[7], o[8]); // target object

			s +=
				", "
				+ (lng ? pjse.Localization.GetString("bwp_animation") + ": " : "")
				+ (
					(o[2] & 0x04) != 0
						? "ObjectAnims:[" + dataOwner(lng, 0x09, o[0], o[1]) + "]" // Param
						: readStr(
							GS.GlobalStr.ObjectAnims,
							ToShort(o[0], o[1]),
							lng ? -1 : 60,
							lng ? Detail.Normal : Detail.ErrorNames
						)
				);

			if (lng)
			{
				bool found = false;
				s +=
					", "
					+ pjse.Localization.GetString("bwp_eventTree")
					+ ": "
					+ bhavName(ToShort(o[4], o[5]), ref found);

				Scope scope = Scope.Global;
				if (o[9] == 0)
				{
					scope = Scope.Private;
				}
				else if (o[9] == 1)
				{
					scope = Scope.SemiGlobal;
				}

				s += " (" + pjse.Localization.GetString(scope.ToString()) + ")";

				s +=
					", "
					+ pjse.Localization.GetString("bwp_animSpeed")
					+ ": "
					+ ((o[2] & 0x02) != 0 ? dataOwner(0x08, 2) : "---"); // Temp 2
				s +=
					", "
					+ pjse.Localization.GetString("bwp_interruptible")
					+ ": "
					+ ((o[2] & 0x08) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_startTag")
					+ ": "
					+ ((o[2] & 0x10) != 0 ? dataOwner(0x08, 0) : "---"); // Temp 0
				s +=
					", "
					+ pjse.Localization.GetString("bwp_loopCount")
					+ ": "
					+ ((o[2] & 0x20) != 0 ? dataOwner(0x08, 1) : "---");
				s +=
					", "
					+ pjse.Localization.GetString("bwp_blendOut")
					+ ": "
					+ ((o[2] & 0x40) == 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_blendIn")
					+ ": "
					+ ((o[2] & 0x80) == 0).ToString();

				s +=
					", "
					+ pjse.Localization.GetString("bwp_flipFlag")
					+ ": "
					+ (
						(o[10] & 0x01) != 0
							? dataOwner(0x08, 3) // Temp 3
							: ((o[2] & 0x01) != 0).ToString()
					);
				s +=
					", "
					+ pjse.Localization.GetString("bwp_sync")
					+ ": "
					+ ((o[10] & 0x04) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_alignBlend")
					+ ": "
					+ ((o[10] & 0x08) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_notHurryable")
					+ ": "
					+ ((o[10] & 0x80) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x69:  // Animate Object (false = error)
			//     c1 = b[x+2];
			//     c2 = b[x+10];
			//     w1 = *(UINT16 *) (&b[x+7]);
			//     w2 = *(UINT16 *) (&b[x]);
			//     w3 = *(UINT16 *) (&b[x+4]);
			//     if (c1 & 4)
			//         ht_fprintf(outFile,TYPE_NORMAL,"anim id in STR# 0x86:[Param %d]", w2);
			//     else {
			//         if (readString2(gGroup, 0x86, w2) == 0)
			//             ht_fprintf(outFile,TYPE_NORMAL,"anim id in STR# 0x86:%X", w2);
			//     }
			//     ht_fprintf(outFile,TYPE_NORMAL," affecting ");
			//     data2(b[x+6],w1);       // target object
			//     if (w3 == 0)
			//         ht_fprintf(outFile,TYPE_NORMAL,", No Event Tree");
			//     else {
			//         switch (b[x+9]) {
			//             case 0:
			//                 ht_fprintf(outFile,TYPE_NORMAL,", Private Event Tree: ");
			//                 break;
			//             case 1:
			//                 ht_fprintf(outFile,TYPE_NORMAL,", SemiGlobal Event Tree: ");
			//                 break;
			//             default:
			//                 ht_fprintf(outFile,TYPE_NORMAL,", Global Event Tree: ");
			//                 break;
			//         }
			//         ht_fprintf(outFile,TYPE_NORMAL,"0x%X (",w3);
			//         readFn2(w3);
			//         ht_fprintf(outFile,TYPE_NORMAL,")");
			//     }
			//     if (c1 & 8)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Interruptible");
			//     if (c1 & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Flipped");
			//     if (c1 & 0x10)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Start at tag in Temp 0");
			//     if (c1 & 0x20)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Loop Count in Temp 1");
			//     if (c1 & 0x80)
			//         ht_fprintf(outFile,TYPE_NORMAL,", No Blend in");
			//     if (c1 & 0x40)
			//         ht_fprintf(outFile,TYPE_NORMAL,", No Blend out");
			//     if (c1 & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Anim Speed in Temp2");
			//     if (c2 & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Flip Flag in Temp 3");
			//     if (c2 & 4)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Sync to calling objects Anim");
			//     if (c2 & 8)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Align blend out with to calling objects Anim");
			//     if (c2 & 0x80)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Not Hurryable");
			//     break;
#endif
		}
	}

	public class WizPrim0x006a : BhavWizPrim // Animate Sim -- for wizard, see edithWiki CreatingAChair
	{
		public WizPrim0x006a(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWizAnimate(
				instruction,
				"bwp_Sim"
			);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			Scope scope = Scope.Private;
			GS.GlobalStr instance = GS.GlobalStr.ObjectAnims;
			if (o[6] == 0x80)
			{
				instance = GS.GlobalStr.AdultAnims;
				scope = Scope.Global;
			}
			else
			{
				try
				{
					instance = (GS.GlobalStr)o[6];
					if (!instance.ToString().EndsWith("Anims"))
					{
						instance = GS.GlobalStr.ObjectAnims;
					}
				}
				catch
				{
					instance = GS.GlobalStr.ObjectAnims;
				}
			}

			s +=
				(lng ? pjse.Localization.GetString("bwp_animation") + ": " : "")
				+ (
					(o[2] & 0x04) != 0
						? instance.ToString()
							+ ":["
							+ dataOwner(lng, 0x09, o[0], o[1])
							+ "]" // Param
							+ " ("
							+ pjse.Localization.GetString(scope.ToString())
							+ ")"
						: readStr(
							scope,
							instance,
							ToShort(o[0], o[1]),
							lng ? -1 : 60,
							lng ? Detail.Normal : Detail.ErrorNames
						)
				);

			if (lng)
			{
				bool found = false;
				s +=
					", "
					+ pjse.Localization.GetString("bwp_eventTree")
					+ ": "
					+ bhavName(ToShort(o[4], o[5]), ref found);

				scope = Scope.Global;
				if (o[7] == 0)
				{
					scope = Scope.Private;
				}
				else if (o[7] == 1)
				{
					scope = Scope.SemiGlobal;
				}

				s += " (" + pjse.Localization.GetString(scope.ToString()) + ")";

				s +=
					", "
					+ pjse.Localization.GetString("bwp_animSpeed")
					+ ": "
					+ ((o[2] & 0x02) != 0 ? dataOwner(0x08, 2) : "---"); // Temp 2
				s +=
					", "
					+ pjse.Localization.GetString("bwp_interruptible")
					+ ": "
					+ ((o[2] & 0x08) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_startTag")
					+ ": "
					+ ((o[2] & 0x10) != 0 ? dataOwner(0x08, 0) : "---"); // Temp 0
				s +=
					", "
					+ pjse.Localization.GetString("bwp6a_transToIdle")
					+ ": "
					+ ((o[2] & 0x20) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_blendOut")
					+ ": "
					+ ((o[2] & 0x40) == 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_blendIn")
					+ ": "
					+ ((o[2] & 0x80) == 0).ToString();

				s +=
					", "
					+ pjse.Localization.GetString("bwp_flipFlag")
					+ ": "
					+ (
						(o[8] & 0x01) != 0
							? dataOwner(0x08, 3) // Temp 3
							: ((o[2] & 0x01) != 0).ToString()
					);
				s +=
					", "
					+ pjse.Localization.GetString("bwp6a_sync")
					+ ": "
					+ ((o[8] & 0x02) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp6a_controllerIsSource")
					+ ": "
					+ ((o[8] & 0x10) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_notHurryable")
					+ ": "
					+ ((o[8] & 0x20) != 0).ToString();

				s +=
					", "
					+ pjse.Localization.GetString("bwp6a_IK")
					+ ": "
					+ dataOwner(o[9], ToShort(o[10], o[11]));
				s +=
					", "
					+ pjse.Localization.GetString("bwp_priority")
					+ ": 0x"
					+ SimPe.Helper.HexString(o[12])
					+ " (";
				switch (o[12])
				{
					case 0:
						s += pjse.Localization.GetString("bwp_low");
						break;
					case 1:
						s += pjse.Localization.GetString("bwp_medium");
						break;
					case 2:
						s += pjse.Localization.GetString("bwp_high");
						break;
					default:
						s += pjse.Localization.GetString("unk");
						break;
				}
				s += ")";
			}

			return s;
#if DISASIM
			// case 0x6A:  // Animate Sim
			//     c1 = b[x+2];
			//     c2 = b[x+8];
			//     w1 = *(UINT16 *) (&b[x]);
			//     w2 = *(UINT16 *) (&b[x+4]);
			//     w3 = *(UINT16 *) (&b[x+10]);
			//     if (c1 & 4)
			//         ht_fprintf(outFile,TYPE_NORMAL,"anim id in Param %d", w1);
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,"anim id %X", w1);
			//     ht_fprintf(outFile,TYPE_NORMAL," from ");
			//     switch (b[x+6]) {
			//         case 0x80:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Global list");
			//             break;
			//         case 0x81:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Adult list");
			//             break;
			//         case 0x82:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Child list");
			//             break;
			//         case 0x83:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Social Interaction list");
			//             break;
			//         case 0x89:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Toddler list");
			//             break;
			//         case 0x8A:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Teen list");
			//             break;
			//         case 0x8B:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Elder list");
			//             break;
			//         case 0x8C:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Cat list");
			//             break;
			//         case 0x8D:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Dog list");
			//             break;
			//         case 0x91:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Baby list");
			//             break;
			//         case 0x99:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Puppy list");
			//             break;
			//         case 0x9A:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Kitten list");
			//             break;
			//         default:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Object list");
			//             break;
			//     }
			//     if ((c1 & 4) == 0) {
			//         ht_fprintf(outFile,TYPE_NORMAL," (");
			//         if (b[x+6] == 0x80) {
			//             if (readString2(GROUP_GLOBAL, 0x81, w1) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Global STR# 0x81:%X", 0x81, w1);
			//         } else if ((b[x+6] > 0x80 && b[x+6] < 0x84) || (b[x+6] > 0x88 && b[x+6] < 0x8E) || b[x+6] == 91) {
			//             if (readString2(gGroup, b[x+6], w1) == 0)
			//                   ht_fprintf(outFile,TYPE_NORMAL,"STR# 0x%X:%X", b[x+6], w1);
			//         } else
			//             if (readString2(gGroup, 0x86, w1) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"STR# 0x86:%X", 0x86, w1);
			//         ht_fprintf(outFile,TYPE_NORMAL,")");
			//     }
			//     if (w2 == 0)
			//         ht_fprintf(outFile,TYPE_NORMAL,", No Event Tree");
			//     else {
			//         switch (b[x+7]) {
			//             case 0:
			//                 ht_fprintf(outFile,TYPE_NORMAL,", Private Event Tree: ");
			//                 break;
			//             case 1:
			//                 ht_fprintf(outFile,TYPE_NORMAL,", SemiGlobal Event Tree: ");
			//                 break;
			//             default:
			//                 ht_fprintf(outFile,TYPE_NORMAL,", Global Event Tree: ");
			//                 break;
			//         }
			//         ht_fprintf(outFile,TYPE_NORMAL,"0x%X (",w2);
			//         readFn2(w2);
			//         ht_fprintf(outFile,TYPE_NORMAL,")");
			//     }
			//     if (c1 & 8)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Interruptible");
			//     if (c1 & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Flipped");
			//     if (c1 & 0x20)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Trans to Idle");
			//     if (c1 & 0x80)
			//         ht_fprintf(outFile,TYPE_NORMAL,", No Blend in");
			//     if (c1 & 0x40)
			//         ht_fprintf(outFile,TYPE_NORMAL,", No Blend out");
			//     if (c1 & 0x10)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Start at tag in Temp 0");
			//     if (c1 & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Anim Speed in Temp2");
			//     if (c2 & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Flip Flag in Temp 3");
			//     if (c2 & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Synching Anim to last Anim Run");
			//     if (c2 & 0x10)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Using Controlling Object as Anim Source");
			//     if (c2 & 0x20)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Not Hurryable");
			//     ht_fprintf(outFile,TYPE_NORMAL,", IK Object ");
			//     data2(b[x+9],w3);
			//     switch (b[x+12]) {
			//         case 0:
			//             ht_fprintf(outFile,TYPE_NORMAL,", low priority");
			//             break;
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL,", medium priority");
			//             break;
			//         case 2:
			//             ht_fprintf(outFile,TYPE_NORMAL,", high priority");
			//             break;
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x006b : BhavWizPrim // Animate Overlay
	{
		public WizPrim0x006b(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWizAnimate(
				instruction,
				"bwp_Overlay"
			);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				(lng ? pjse.Localization.GetString("Object") + ": " : "")
				+ dataOwner(lng, o[6], o[7], o[8]); // target object

			Scope scope = Scope.Private;
			GS.GlobalStr instance = GS.GlobalStr.ObjectAnims;
			if (o[9] == 0x80)
			{
				instance = GS.GlobalStr.AdultAnims;
				scope = Scope.Global;
			}
			else
			{
				try
				{
					instance = (GS.GlobalStr)o[9];
					if (!instance.ToString().EndsWith("Anims"))
					{
						instance = GS.GlobalStr.ObjectAnims;
					}
				}
				catch
				{
					instance = GS.GlobalStr.ObjectAnims;
				}
			}

			s +=
				", "
				+ (lng ? pjse.Localization.GetString("bwp_animation") + ": " : "")
				+ (
					(o[2] & 0x04) != 0
						? instance.ToString()
							+ ":["
							+ dataOwner(lng, 0x09, o[0], o[1])
							+ "]" // Param
							+ (
								lng
									? " ("
										+ pjse.Localization.GetString(scope.ToString())
										+ ")"
									: ""
							)
						: readStr(
							scope,
							instance,
							ToShort(o[0], o[1]),
							lng ? -1 : 60,
							lng ? Detail.Full : Detail.ErrorNames
						) // variable instance
				);

			if (lng)
			{
				bool found = false;
				s +=
					", "
					+ pjse.Localization.GetString("bwp_eventTree")
					+ ": "
					+ bhavName(ToShort(o[4], o[5]), ref found);

				scope = Scope.Global;
				if (o[14] == 0)
				{
					scope = Scope.Private;
				}
				else if (o[14] == 1)
				{
					scope = Scope.SemiGlobal;
				}

				s += " (" + pjse.Localization.GetString(scope.ToString()) + ")";

				s +=
					", "
					+ pjse.Localization.GetString("bwp_animSpeed")
					+ ": "
					+ ((o[2] & 0x02) != 0 ? dataOwner(0x08, 2) : "---"); // Temp 2
				s +=
					", "
					+ pjse.Localization.GetString("bwp_interruptible")
					+ ": "
					+ ((o[2] & 0x08) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_startTag")
					+ ": "
					+ ((o[2] & 0x10) != 0 ? dataOwner(0x08, 0) : "---"); // Temp 0
				s +=
					", "
					+ pjse.Localization.GetString("bwp_loopCount")
					+ ": "
					+ ((o[2] & 0x20) != 0 ? dataOwner(0x08, 1) : "---");
				s +=
					", "
					+ pjse.Localization.GetString("bwp_blendOut")
					+ ": "
					+ ((o[2] & 0x40) == 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_blendIn")
					+ ": "
					+ ((o[2] & 0x80) == 0).ToString();

				s +=
					", "
					+ pjse.Localization.GetString("bwp_flipFlag")
					+ ": "
					+ (
						(o[15] & 0x01) != 0
							? dataOwner(0x08, 3) // Temp 3
							: ((o[2] & 0x01) != 0).ToString()
					);
				s +=
					", "
					+ pjse.Localization.GetString("bwp_sync")
					+ ": "
					+ ((o[15] & 0x10) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_alignBlend")
					+ ": "
					+ ((o[15] & 0x20) != 0).ToString();

				byte priority;
				if (instruction.NodeVersion != 0)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp_notHurryable")
						+ ": "
						+ ((o[12] & 0x01) != 0).ToString();
					priority = o[11];
				}
				else
				{
					priority = o[12];
				}

				s +=
					", "
					+ pjse.Localization.GetString("bwp_priority")
					+ ": 0x"
					+ SimPe.Helper.HexString(priority)
					+ " (";
				switch (priority)
				{
					case 0:
						s += pjse.Localization.GetString("bwp_low");
						break;
					case 1:
						s += pjse.Localization.GetString("bwp_medium");
						break;
					case 2:
						s += pjse.Localization.GetString("bwp_high");
						break;
					default:
						s += pjse.Localization.GetString("unk");
						break;
				}
				s += ")";
			}

			return s;
#if DISASIM
			// case 0x6B:  // Animate Overlay (false = error)
			//     c1 = b[x+2];
			//     c2 = b[x+15];
			//     w1 = *(UINT16 *) (&b[x]);
			//     w2 = *(UINT16 *) (&b[x+4]);
			//     w3 = *(UINT16 *) (&b[x+7]);
			//     if (c1 & 4)
			//         ht_fprintf(outFile,TYPE_NORMAL,"anim id in Param %d", w1);
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,"anim id %X", w1);
			//     ht_fprintf(outFile,TYPE_NORMAL," from ");
			//     switch (b[x+9]) {
			//         case 0x80:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Global list");
			//             break;
			//         case 0x81:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Adult list");
			//             break;
			//         case 0x82:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Child list");
			//             break;
			//         case 0x83:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Social Interaction list");
			//             break;
			//         case 0x89:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Toddler list");
			//             break;
			//         case 0x8A:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Teen list");
			//             break;
			//         case 0x8B:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Elder list");
			//             break;
			//         case 0x8C:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Cat list");
			//             break;
			//         case 0x8D:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Dog list");
			//             break;
			//         case 0x91:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Baby list");
			//             break;
			//         case 0x99:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Puppy list");
			//             break;
			//         case 0x9A:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Kitten list");
			//             break;
			//         default:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Object list");
			//             break;
			//     }
			//     if ((c1 & 4) == 0) {
			//         ht_fprintf(outFile,TYPE_NORMAL," (");
			//         if (b[x+9] == 0x80) {
			//             if (readString2(GROUP_GLOBAL, 0x81, w1) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Global STR# 0x81:%X", 0x81, w1);
			//         } else if ((b[x+9] > 0x80 && b[x+9] < 0x84) || (b[x+9] > 0x88 && b[x+9] < 0x8E) || b[x+9] == 91) {
			//             if (readString2(gGroup, b[x+9], w1) == 0)
			//                   ht_fprintf(outFile,TYPE_NORMAL,"STR# 0x%X:%X", b[x+9], w1);
			//         } else
			//             if (readString2(gGroup, 0x86, w1) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"STR# 0x86:%X", 0x86, w1);
			//         ht_fprintf(outFile,TYPE_NORMAL,")");
			//     }
			//     ht_fprintf(outFile,TYPE_NORMAL," affecting ");
			//     data2(b[x+6],w3);       // target object
			//     if (w2 == 0)
			//         ht_fprintf(outFile,TYPE_NORMAL,", No Event Tree");
			//     else {
			//         switch (b[x+14]) {
			//             case 0:
			//                 ht_fprintf(outFile,TYPE_NORMAL,", Private Event Tree: ");
			//                 break;
			//             case 1:
			//                 ht_fprintf(outFile,TYPE_NORMAL,", SemiGlobal Event Tree: ");
			//                 break;
			//             default:
			//                 ht_fprintf(outFile,TYPE_NORMAL,", Global Event Tree: ");
			//                 break;
			//         }
			//         ht_fprintf(outFile,TYPE_NORMAL,"0x%X (",w2);
			//         readFn2(w2);
			//         ht_fprintf(outFile,TYPE_NORMAL,")");
			//     }
			//     if (c1 & 8)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Interruptible");
			//     if (c1 & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Flipped");
			//     if (c1 & 0x80)
			//         ht_fprintf(outFile,TYPE_NORMAL,", No Blend in");
			//     if (c1 & 0x40)
			//         ht_fprintf(outFile,TYPE_NORMAL,", No Blend out");
			//     if (c1 & 0x10)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Start at tag in Temp 0");
			//     if (c1 & 0x20)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Loop Count in Temp 1");
			//     if (c1 & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Anim Speed in Temp2");
			//     if (c2 & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Flip Flag in Temp 3");
			//     if (c2 & 0x10)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Sync to calling objects Anim");
			//     if (c2 & 0x20)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Align blend out with to calling objects Anim");
			//     if (c2 & 0x40)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Using tree owners anim list");
			//     if ((b[x+12] & 1) && nodeVersion)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Not Hurryable");
			//     if (nodeVersion)
			//         c3 = b[x+11];
			//     else
			//         c3 = b[x+12];
			//     switch (c3) {
			//         case 0:
			//             ht_fprintf(outFile,TYPE_NORMAL,", low priority");
			//             break;
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL,", medium priority");
			//             break;
			//         case 2:
			//             ht_fprintf(outFile,TYPE_NORMAL,", high priority");
			//             break;
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x006c : BhavWizPrim // Animate Stop (disaSim2 24b)
	{
		public WizPrim0x006c(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				(lng ? pjse.Localization.GetString("Object") + ": " : "")
				+ dataOwner(lng, o[3], o[4], o[5]); // target object

			s +=
				", " + (lng ? pjse.Localization.GetString("bwp_animation") + ": " : "");
			if (o[7] == 0)
			{
				Scope scope = Scope.Private;
				GS.GlobalStr instance = GS.GlobalStr.ObjectAnims;
				if (o[6] == 0x80)
				{
					instance = GS.GlobalStr.AdultAnims;
					scope = Scope.Global;
				}
				else
				{
					try
					{
						instance = (GS.GlobalStr)o[6];
						if (!instance.ToString().EndsWith("Anims"))
						{
							instance = GS.GlobalStr.ObjectAnims;
						}
					}
					catch
					{
						instance = GS.GlobalStr.ObjectAnims;
					}
				}

				s += (
					(o[2] & 0x04) != 0
						? instance.ToString()
							+ ":["
							+ dataOwner(lng, 0x09, o[0], o[1])
							+ "]" // Param
							+ (
								lng
									? " ("
										+ pjse.Localization.GetString(scope.ToString())
										+ ")"
									: ""
							)
						: readStr(
							scope,
							instance,
							ToShort(o[0], o[1]),
							lng ? -1 : 60,
							lng ? Detail.Full : Detail.ErrorNames
						) // variable instance
				);
			}
			else
			{
				s += readStr(GS.BhavStr.StopAnimType, o[7]);
			}

			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp_blendOut")
					+ ": "
					+ ((o[2] & 0x02) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_flipFlag")
					+ ": "
					+ (
						(o[2] & 0x08) != 0
							? dataOwner(0x08, 3) // Temp 3
							: ((o[2] & 0x01) != 0).ToString()
					);
				s +=
					", "
					+ pjse.Localization.GetString("bwp6c_shortBlendOut")
					+ ": "
					+ ((o[2] & 0x20) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp6c_normalAndFlipped")
					+ ": "
					+ ((o[2] & 0x40) != 0).ToString();

				s +=
					", "
					+ pjse.Localization.GetString("bwp_priority")
					+ ": 0x"
					+ SimPe.Helper.HexString(o[8])
					+ " (";
				switch (o[8])
				{
					case 0:
						s += pjse.Localization.GetString("bwp_low");
						break;
					case 1:
						s += pjse.Localization.GetString("bwp_medium");
						break;
					case 2:
						s += pjse.Localization.GetString("bwp_high");
						break;
					default:
						s += pjse.Localization.GetString("unk");
						break;
				}
				s += ")";
			}

			return s;
#if DISASIM
			// case 0x6C:  // Animate Stop (false = error)
			//     c1 = b[x+2];
			//     w1 = *(UINT16 *) (&b[x]);
			//     w2 = *(UINT16 *) (&b[x+4]);
			//     switch (b[x+7]) {
			//         case 0:
			//             if (c1 & 4)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"anim id in Param %d", w1);
			//             else
			//                 ht_fprintf(outFile,TYPE_NORMAL,"anim id %X", w1);
			//             ht_fprintf(outFile,TYPE_NORMAL," from ");
			//             switch (b[x+6]) {
			//                 case 0x80:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Global list");
			//                     break;
			//                 case 0x81:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Adult list");
			//                     break;
			//                 case 0x82:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Child list");
			//                     break;
			//                 case 0x83:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Social Interaction list");
			//                     break;
			//                 case 0x89:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Toddler list");
			//                     break;
			//                 case 0x8A:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Teen list");
			//                     break;
			//                 case 0x8B:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Elder list");
			//                     break;
			//                 case 0x8C:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Cat list");
			//                     break;
			//                 case 0x8D:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Dog list");
			//                     break;
			//                 case 0x91:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Baby list");
			//                     break;
			//                 case 0x99:
			//                    ht_fprintf(outFile,TYPE_NORMAL,"Puppy list");
			//                    break;
			//                 case 0x9A:
			//                    ht_fprintf(outFile,TYPE_NORMAL,"Kitten list");
			//                    break;
			//                 default:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Object list");
			//                     break;
			//             }
			//             if ((c1 & 4) == 0) {
			//                 ht_fprintf(outFile,TYPE_NORMAL," (");
			//                 if (b[x+6] == 0x80) {
			//                     if (readString2(GROUP_GLOBAL, 0x81, w1) == 0)
			//                         ht_fprintf(outFile,TYPE_NORMAL,"Global STR# 0x81:%X", 0x81, w1);
			//                 } else if ((b[x+6] > 0x80 && b[x+6] < 0x84) || (b[x+6] > 0x88 && b[x+6] < 0x8E) || b[x+6] == 91) {
			//                     if (readString2(gGroup, b[x+6], w1) == 0)
			//                           ht_fprintf(outFile,TYPE_NORMAL,"STR# 0x%X:%X", b[x+6], w1);
			//                 } else
			//                     if (readString2(gGroup, 0x86, w1) == 0)
			//                         ht_fprintf(outFile,TYPE_NORMAL,"STR# 0x86:%X", 0x86, w1);
			//                 ht_fprintf(outFile,TYPE_NORMAL,")");
			//             }
			//             break;
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL,"All Overlay animations");
			//             break;
			//         case 2:
			//             ht_fprintf(outFile,TYPE_NORMAL,"All Full Body Animations");
			//             break;
			//         case 3:
			//             ht_fprintf(outFile,TYPE_NORMAL,"All Animations");
			//             break;
			//         case 4:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Carry Poses");
			//             break;
			//         case 5:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Idle Animations");
			//             break;
			//         case 6:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Gesture Animations");
			//             break;
			//         case 7:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Reaction Animations");
			//             break;
			//         case 8:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Normal Animations");
			//             break;
			//         case 9:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Facial Animations");
			//             break;
			//         case 10:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Facial Idle Animations");
			//             break;
			//         case 11:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Receptivity Animations");
			//             break;
			//         default:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Unknown Type");
			//     }
			//     ht_fprintf(outFile,TYPE_NORMAL," affecting ");
			//     data2(b[x+3],w2);       // target object
			//     if (c1 & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Flipped");
			//     if (c1 & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,", blended Out");
			//     if (c1 & 0x20)
			//         ht_fprintf(outFile,TYPE_NORMAL,", short blended Out");
			//     if (c1 & 8)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Flip Flag in Temp 3");
			//     if (c1 & 0x40)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Stopping normal AND flipped anims");
			//     ht_fprintf(outFile,TYPE_NORMAL,", Priority ");
			//     switch (b[x+8]) {
			//         case 0:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Any");
			//             break;
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Low");
			//             break;
			//         case 2:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Medium");
			//             break;
			//         default:
			//             ht_fprintf(outFile,TYPE_NORMAL,"High");
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x006d : BhavWizPrim // Change Material
	{
		public WizPrim0x006d(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWiz0x006d(instruction);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				(lng ? pjse.Localization.GetString("Target") + ": " : "")
				+ dataOwner(lng, o[5], o[6], o[7]); // target object

			Scope matScope = Scope.Private;
			if ((o[2] & 0x02) != 0)
			{
				matScope = Scope.Global;
			}
			else if ((o[2] & 0x04) != 0)
			{
				matScope = Scope.SemiGlobal;
			}

			s +=
				", "
				+ (lng ? pjse.Localization.GetString("bwp6d_materialFrom") + ": " : "");
			if ((o[13] & 0x02) == 0)
			{
				s += (
					(o[2] & 0x08) != 0
						? pjse.Localization.GetString("bwp_source")
						: dnMe()
				);
				s +=
					" ("
					+ (
						lng
							? (
								(o[13] & 0x01) != 0
									? pjse.Localization.GetString("bwp6d_movingTexture")
									: pjse.Localization.GetString("bwp6d_material")
							) + ": "
							: ""
					);
				if ((o[2] & 0x10) != 0)
				{
					s +=
						GS.GlobalStr.MaterialName.ToString()
						+ ":["
						+ dataOwner(lng, 0x08, 0) // Temp 0
						+ "]"
						+ (lng ? " (" + matScope.ToString() + ")" : "");
				}
				else if ((o[2] & 0x08) == 0)
				{
					s += readStr(
						matScope,
						GS.GlobalStr.MaterialName,
						ToShort(o[0], o[1]),
						lng ? -1 : 30,
						lng ? Detail.Normal : Detail.ErrorNames
					);
				}
				else
				{
					s +=
						GS.GlobalStr.MaterialName.ToString()
						+ ":[0x"
						+ SimPe.Helper.HexString(ToShort(o[0], o[1]))
						+ "]"
						+ (lng ? " (" + matScope.ToString() + ")" : "");
				}

				s += ")";
			}
			else
			{
				s += pjse.Localization.GetString("bwp6d_screenShot");
			}

			Scope mgScope = Scope.Private;
			if ((o[2] & 0x40) != 0)
			{
				mgScope = Scope.Global;
			}
			else if ((o[2] & 0x80) != 0)
			{
				mgScope = Scope.SemiGlobal;
			}

			s +=
				", "
				+ (lng ? pjse.Localization.GetString("bwp6d_meshFrom") + ": " : "")
				+ (
					(o[2] & 0x01) != 0
						? pjse.Localization.GetString("bwp_source")
						: dnMe()
				);
			if ((o[4] & 0x80) == 0) // w3 < 0
			{
				s +=
					" ("
					+ (
						lng ? pjse.Localization.GetString("bwp6d_meshGroup") + ": " : ""
					);
				if ((o[2] & 0x20) != 0)
				{
					s +=
						GS.GlobalStr.MeshGroup.ToString()
						+ ":["
						+ dataOwner(lng, 0x08, 1) // Temp 1
						+ "]"
						+ (lng ? " (" + mgScope.ToString() + ")" : "");
				}
				else if ((o[2] & 0x01) == 0)
				{
					s += readStr(
						mgScope,
						GS.GlobalStr.MeshGroup,
						ToShort(o[3], o[4]),
						lng ? -1 : 30,
						lng ? Detail.Normal : Detail.ErrorNames
					);
				}
				else
				{
					s +=
						GS.GlobalStr.MeshGroup.ToString()
						+ ":[0x"
						+ SimPe.Helper.HexString(ToShort(o[3], o[4]))
						+ "]"
						+ (lng ? " (" + mgScope.ToString() + ")" : "");
				}

				s += ")";
			}
			else
			{
				s += " (" + pjse.Localization.GetString("bwp6d_allOver") + ")";
			}

			if (((o[13] & 0x02) == 0 && (o[2] & 0x08) != 0) || (o[2] & 0x01) != 0)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp_source")
					+ ": "
					+ dataOwner(lng, o[8], o[9], o[10]);
			}

			return s;
#if DISASIM
			// case 0x6D:  // Change Material (false = error)
			//     w1 = *(UINT16 *) (&b[x+6]);
			//     w2 = *(UINT16 *) (&b[x+9]);
			//     w3 = *(UINT16 *) (&b[x+3]);
			//     w4 = *(UINT16 *) (&b[x]);
			//     c1 = b[x+2];
			//     if (b[x+13] & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,"using snap shot generated material");
			//     else if (c1 & 8) {
			//         ht_fprintf(outFile,TYPE_NORMAL,"found in obj in ");
			//         data2(b[x+8],w2);
			//         if (c1 & 0x10)
			//             if (b[x+13] & 1)
			//                 ht_fprintf(outFile,TYPE_NORMAL,", using Moving Texture Name index from temp 0");
			//             else
			//                 ht_fprintf(outFile,TYPE_NORMAL,", using material index from temp 0");
			//         else
			//             if (b[x+13] & 1)
			//                 ht_fprintf(outFile,TYPE_NORMAL,", using Moving Texture Name index %d", w4);
			//             else
			//                 ht_fprintf(outFile,TYPE_NORMAL,", using material index %d", w4);
			//     } else {
			//         ht_fprintf(outFile,TYPE_NORMAL,"found in me, to: ");
			//         if (c1 & 0x10)
			//             if (b[x+13] & 1)
			//                 ht_fprintf(outFile,TYPE_NORMAL,", using Moving Texture Name index from temp 0");
			//             else
			//                 ht_fprintf(outFile,TYPE_NORMAL,", using material index from temp 0");
			//         else
			//             if (c1 & 2) {
			//                 if (readString2(GROUP_GLOBAL, 0x88, w4) == 0)
			//                     ht_fprintf(outFile,TYPE_NORMAL,"[Global STR# 0x88:0x%X]", w4);
			//             } else if (c1 & 4) {
			//                 if (readString2(gGlobGroup, 0x88, w4) == 0)
			//                     ht_fprintf(outFile,TYPE_NORMAL,"[SemiGlobal STR# 0x88:0x%X]", w4);
			//             } else if (readString2(gGroup, 0x88, w4) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[Private STR# 0x88:0x%X]", w4);
			//     }
			//     if (c1 & 1) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", mesh found in obj in");
			//         data2(b[x+8],w2);
			//         if (c1 & 0x20)
			//             ht_fprintf(outFile,TYPE_NORMAL,", using mesh group index from temp 1");
			//         else
			//             ht_fprintf(outFile,TYPE_NORMAL,", using mesh group index %d", w3);
			//     } else if (c1 & 0x20)
			//         ht_fprintf(outFile,TYPE_NORMAL,", using mesh group index from temp 1");
			//     else if (b[x+4] & 0x80) // w3 < 0
			//         ht_fprintf(outFile,TYPE_NORMAL,", over all model");
			//     else {
			//         ht_fprintf(outFile,TYPE_NORMAL,", On Mesh Group: ");
			//         if (c1 & 0x40) {
			//             if (readString2(GROUP_GLOBAL, 0x87, w3) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[Global STR# 0x87:0x%X]", w3);
			//         } else if (c1 & 0x80) {
			//             if (readString2(gGlobGroup, 0x87, w3) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[SemiGlobal STR# 0x87:0x%X]", w3);
			//         } else if (readString2(gGroup, 0x87, w3) == 0)
			//             ht_fprintf(outFile,TYPE_NORMAL,"[Private STR# 0x87:0x%X]", w3);
			//     }
			//     ht_fprintf(outFile,TYPE_NORMAL,", affecting ID in ");
			//     data2(b[x+5],w1);       // target object
			//     break;
#endif
		}
	}

	public class WizPrim0x006e : BhavWizPrim // Look At
	{
		public WizPrim0x006e(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				(lng ? pjse.Localization.GetString("Target") + ": " : "")
				+ (
					(o[0] & 0x80) == 0
						? dataOwner(lng, o[1], o[2], o[3])
						: pjse.Localization.GetString("bwp6e_camera")
				);

			s += ", " + Slot(o[14], o[8]);

			if ((o[0] & 0x01) == 0)
			{
				if (lng)
				{
					bool found = false;
					s +=
						", "
						+ pjse.Localization.GetString("bwp_eventTree")
						+ ": "
						+ bhavName(ToShort(o[9], o[10]), ref found);

					Scope scope = Scope.Global;
					if (o[11] == 0)
					{
						scope = Scope.Private;
					}
					else if (o[11] == 1)
					{
						scope = Scope.SemiGlobal;
					}

					s += " (" + pjse.Localization.GetString(scope.ToString()) + ")";

					s +=
						", "
						+ pjse.Localization.GetString("bwp6e_earlyExit")
						+ ": "
						+ ((o[0] & 0x02) == 0).ToString();
					s +=
						", "
						+ pjse.Localization.GetString("bwp6e_includeSpine")
						+ ": "
						+ ((o[0] & 0x04) != 0).ToString();
					s +=
						", "
						+ pjse.Localization.GetString("bwp6e_duration")
						+ ": "
						+ ((o[0] & 0x10) != 0 ? dataOwner(0x08, 0) : "---"); // Temp 0
				}
			}
			else
			{
				s += ": " + pjse.Localization.GetString("bwp6e_STOP");
			}

			if (lng)
			{
				if (instruction.NodeVersion != 0)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp6e_turnTowards")
						+ ": "
						+ (
							(o[0] & 0x08) != 0
								? dataOwner(0x08, 1) // Temp 1
								: (2 * o[4]).ToString()
									+ " "
									+ pjse.Localization.GetString("bwp6e_deg_s")
						);
					s += ", " + pjse.Localization.GetString("bwp6e_turnAway") + ": ";
					if ((o[15] & 0x02) != 0)
					{
						s += dataOwner(0x08, 1); // Temp 1
					}
					else if ((o[15] & 0x01) != 0)
					{
						s += dataOwner(0x08, 2); // Temp 2
					}
					else
					{
						s +=
							(2 * o[5]).ToString()
							+ " "
							+ pjse.Localization.GetString("bwp6e_deg_s");
					}

					s +=
						", "
						+ pjse.Localization.GetString("bwp_notHurryable")
						+ ": "
						+ ((o[15] & 0x04) != 0).ToString();
				}
				else
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp6e_speed")
						+ ": "
						+ (
							(o[0] & 0x08) != 0
								? dataOwner(0x08, 1) // Temp 1
								: o[4].ToString()
									+ " "
									+ pjse.Localization.GetString("bwp6e_deg_s")
						);
				}

				s +=
					", "
					+ pjse.Localization.GetString("bwp6e_ignoreRoom")
					+ ": "
					+ ((o[0] & 0x20) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp6e_ignoreFrustrum")
					+ ": "
					+ ((o[0] & 0x40) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x6E:  // Look At
			//     w1 = *(UINT16 *) (&b[x+2]);
			//     w2 = *(UINT16 *) (&b[x+9]);
			//     c1 = b[x];
			//     if ((b[x] & 1) == 0) {
			//         if (w2 == 0)
			//             ht_fprintf(outFile,TYPE_NORMAL,"No Event Tree");
			//         else {
			//             switch (b[x+11]) {
			//                 case 0:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Private Event Tree: ");
			//                     break;
			//                 case 1:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"SemiGlobal Event Tree: ");
			//                     break;
			//                 default:
			//                     ht_fprintf(outFile,TYPE_NORMAL,"Global Event Tree: ");
			//                     break;
			//             }
			//             ht_fprintf(outFile,TYPE_NORMAL,"0x%X (",w2);
			//             readFn2(w2);
			//             ht_fprintf(outFile,TYPE_NORMAL,")");
			//         }
			//         if ((b[x] & 0x80) == 0) {
			//             ht_fprintf(outFile,TYPE_NORMAL,", Targeting ID in ");
			//             data2(b[x+1],w1);
			//         } else
			//             ht_fprintf(outFile,TYPE_NORMAL,", Targeting Camera ");
			//         ht_fprintf(outFile,TYPE_NORMAL," using ");
			//         switch (b[x+14]) {
			//             case 0:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"default 3/4 height");
			//                 break;
			//             case 1:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"targeting slot"," number %d",b[x+8]);
			//                 break;
			//             case 2:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"routing slot"," number %d",b[x+8]);
			//                 break;
			//             default:
			//                 ht_fprintf(outFile,TYPE_NORMAL," containment slot"," number %d",b[x+8]);
			//                 break;
			//         }
			//         if (c1 & 4)
			//             ht_fprintf(outFile,TYPE_NORMAL,", including Spine");
			//         if (c1 & 0x10)
			//             ht_fprintf(outFile,TYPE_NORMAL,", using duration in temp 0");
			//         if (c1 & 2)
			//             ht_fprintf(outFile,TYPE_NORMAL,", no early exit");
			//     } else
			//         ht_fprintf(outFile,TYPE_NORMAL,"STOP");
			//     if (c1 & 8)
			//         ht_fprintf(outFile,TYPE_NORMAL,", using turnTowardsSpeed in temp 1");
			//     else if (nodeVersion)
			//         ht_fprintf(outFile,TYPE_NORMAL,", turn towards speed of %d  degrees per second",2*b[x+4]);
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,", turn towards speed of %d  degrees per second",b[x+4]);
			//     if ((b[x+15] & 2) && nodeVersion || (c1 & 8) && (nodeVersion == 0))
			//         ht_fprintf(outFile,TYPE_NORMAL,", using turnAwaySpeed in temp 1");
			//     else if (b[x+15] & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", using turnAwaySpeed in temp 2");
			//     else if (nodeVersion)
			//         ht_fprintf(outFile,TYPE_NORMAL,", turn away speed of %d  degrees per second",2*b[x+5]);
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,", turn away speed of %d  degrees per second",b[x+4]);
			//     if (c1 & 0x20)
			//         ht_fprintf(outFile,TYPE_NORMAL,", ignoring Room");
			//     if (c1 & 0x40)
			//         ht_fprintf(outFile,TYPE_NORMAL,", ignoring Frustrum");
			//     if (b[x+15] & 4)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Not Hurryable");
			//     break;
#endif
		}
	}

	public class WizPrim0x006f : BhavWizPrim // Change Light
	{
		public WizPrim0x006f(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				(lng ? pjse.Localization.GetString("Target") + ": " : "")
				+ dataOwner(lng, o[2], o[3], o[4]); // target object
			s +=
				", "
				+ pjse.Localization.GetString("bwp6f_light")
				+ ": "
				+ (
					o[8] == 0xFF
						? pjse.Localization.GetString("bwp6f_all")
						: readStr(
							GS.GlobalStr.LightSource,
							o[8],
							lng ? -1 : 60,
							Detail.ErrorNames
						)
				); // Fixed instance and scope
			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp6f_ticks")
					+ ": "
					+ (
						(o[1] & 0x01) != 0
							? dataOwner(0x08, 1)
							: "0x" + SimPe.Helper.HexString(ToShort(o[5], o[6]))
					);
				s +=
					", "
					+ pjse.Localization.GetString("bwp6f_intensity")
					+ ": "
					+ ((o[1] & 0x02) != 0 ? dataOwner(0x08, 0) : o[7].ToString() + "%");
			}

			return s;
#if DISASIM
			// case 0x6F:  // Change Light (false = error)
			//     w1 = *(UINT16 *) (&b[x+3]);
			//     w2 = *(UINT16 *) (&b[x+5]);
			//     ht_fprintf(outFile,TYPE_NORMAL,"on object in ");
			//     data2(b[x+2],w1);       // target object
			//     if (b[x+8] != 0xFF) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", Targeting light ");
			//         if (readString2(gGroup, 0x8E, b[x+8]) == 0)
			//             ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x8E:0x%X]", b[x+8]);
			//     } else
			//         ht_fprintf(outFile,TYPE_NORMAL,", Targeting all lights on Object");
			//     if (b[x+1] & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Fade duration in Temp 1,");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,", Fading over a duration of %d ticks,", w2);
			//     if (b[x+1] & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL," Intensity in Temp 0");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL," Intensity of %d percent", b[x+7]);
			//     break;
#endif
		}
	}

	public class WizPrim0x0070 : BhavWizPrim // Effect Stop/Start
	{
		public WizPrim0x0070(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += readStr(GS.BhavStr.EffectSSType, o[0]);

			s +=
				", "
				+ (lng ? pjse.Localization.GetString("Target") + ": " : "")
				+ dataOwner(lng, o[1], o[2], o[3]); // target object

			if (lng && o[0] != 0x9 && o[0] != 0xE)
			{
				s += ", " + Slot(o[9], o[6]);
			}

			Scope scope = Scope.Private;
			if ((o[10] & 0x01) != 0)
			{
				scope = Scope.Global;
			}
			else if ((o[10] & 0x02) != 0)
			{
				scope = Scope.SemiGlobal;
			}

			if (o[0] == 0x04 || o[0] == 0x05)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp70_effectID")
					+ ": "
					+ ((o[10] & 0x40) != 0 ? dataOwner(0x08, 1) : "---"); // Temp 1
			}
			else if (o[0] < 0x04 || o[0] == 0x06 || o[0] == 0x0E)
			{
				if (o[4] != 0xFF)
				{
					s +=
						", "
						+ readStr(
							scope,
							pjse.GS.GlobalStr.Effect,
							o[4],
							lng ? -1 : 60,
							lng ? Detail.Normal : Detail.ErrorNames
						);
				}
				else
				{
					s += ", " + pjse.Localization.GetString("bwp70_defaultEffect");
				}
			}

			if (lng)
			{
				s += ", " + pjse.Localization.GetString("bwp_icon") + ": ";
				if ((o[10] & 0x04) != 0)
				{
					s += dataOwner(o[12], o[13], o[14]);
				}
				else if ((o[10] & 0x10) != 0)
				{
					s +=
						dataOwner(o[12], o[13], o[14])
						+ " ("
						+ pjse.Localization.GetString("NeighborID")
						+ ")";
				}
				else if ((o[10] & 0x20) != 0)
				{
					s +=
						dataOwner(o[12], o[13], o[14])
						+ " ("
						+ pjse.Localization.GetString("bwp70_conversation")
						+ ")"
						+ ", "
						+ pjse.Localization.GetString("bwp70_sheet")
						+ ": "
						+ readStr(
							scope,
							pjse.GS.GlobalStr.IconTexture,
							o[15],
							-1,
							lng ? Detail.Normal : Detail.ErrorNames
						);
				}
				else if ((o[11] & 0x04) != 0)
				{
					s += "GUID [" + dataOwner(0x08, 4) + ",5]"; // Temp 4
				}
				else if ((o[11] & 0x10) != 0)
				{
					s += dataOwner(0x08, 6); // Temp 6
				}
				else
				{
					s += pjse.Localization.GetString("bwp70_noIcon");
				}

				s +=
					", "
					+ pjse.Localization.GetString("bwp_priority")
					+ ": "
					+ ((o[10] & 0x80) != 0).ToString();

				s +=
					", "
					+ pjse.Localization.GetString("bwp70_model")
					+ ": "
					+ (
						(o[11] & 0x08) != 0
							? dataOwner(0x08, 6) // Temp 6
							: pjse.Localization.GetString("default")
					);
			}

			return s;
#if DISASIM
			// case 0x70:  // Effect Stop/Start (false = error)
			//     w1 = *(UINT16 *) (&b[x+2]);
			//     w2 = *(UINT16 *) (&b[x+13]);
			//     switch (b[x]) {
			//         case 0:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Soft Start Effect on object in ");
			//             break;
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Hard start effect on object in ");
			//             break;
			//         case 2:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Soft stop effect on object in ");
			//             break;
			//         case 3:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Hard stop effect on object in ");
			//             break;
			//         case 4:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Soft stop all effects on object in ");
			//             break;
			//         case 5:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Hard stop all effects on object in ");
			//             break;
			//         case 6:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Fire and Forget Effect on object in ");
			//             break;
			//         case 7:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Interrogate Bone for effects on object in ");
			//             break;
			//         case 8:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Hard stop all effects and clear Queue on object in ");
			//             break;
			//         case 9:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Hard stop ALL effects on object in ");
			//             break;
			//         case 0xA:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Set State 1 for all effects on object in ");
			//             break;
			//         case 0xB:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Set State 2 for all effects on object in ");
			//             break;
			//         case 0xC:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Set State 3 for all effects on object in ");
			//             break;
			//         case 0xD:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Set State 4 for all effects on object in ");
			//             break;
			//         case 0xE:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Soft stop ALL effects on object in ");
			//             break;
			//     }
			//     data2(b[x+1],w1);       // target object
			//     if (b[x] == 4 || b[x] == 5) {
			//         if (b[x+10] & 0x40)
			//             ht_fprintf(outFile,TYPE_NORMAL,", Passing in effect ID in temp 1");
			//     } else if (b[x] < 7 || b[x] == 0xE)
			//         if (b[x+4] != 0xFF) {
			//             ht_fprintf(outFile,TYPE_NORMAL,", ");
			//             if (b[x+10] & 1)
			//                 readString2(GROUP_GLOBAL, 0x8F, b[x+4]); // !!!
			//             else if (b[x+10] & 2) {
			//                 if (readString2(gGlobGroup, 0x8F, b[x+4]) == 0)
			//                     ht_fprintf(outFile,TYPE_NORMAL,"[SemiGlobal STR# 0x8F:0x%X]", b[x+4]);
			//             }
			//             else if (readString2(gGroup, 0x8F, b[x+4]) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[Private STR# 0x8F:0x%X]", b[x+4]);
			//         } else
			//             ht_fprintf(outFile,TYPE_NORMAL,", Affecting default effect");
			//     if (b[x] != 9) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", of Slot Type ");
			//         switch (b[x+9]) {
			//             case 0:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Target");
			//                 break;
			//             case 1:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Routing");
			//                 break;
			//             default:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Containment");
			//                 break;
			//         }
			//         ht_fprintf(outFile,TYPE_NORMAL,", using slot number %d", b[x+6]);
			//     }
			//     if (b[x+11] & 0x10)
			//         ht_fprintf(outFile,TYPE_NORMAL,", getting icon value from Temp6");
			//     else if (b[x+11] & 4) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", putting in Icon with GUID in temp4/5 ");
			//         if (b[x+11] & 8)
			//             ht_fprintf(outFile,TYPE_NORMAL," getting model name index from Temp6");
			//         else
			//             ht_fprintf(outFile,TYPE_NORMAL," using default object model");
			//     } else if (b[x+10] & 0x10) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", putting in Icon from neighbor ID in ");
			//         data2(b[x+12],w2);
			//     } else if (b[x+10] & 0x20) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", putting in Conversation Icon index found in ");
			//         data2(b[x+12],w2);
			//         ht_fprintf(outFile,TYPE_NORMAL," using sheet ");
			//         if (readString2(gGroup, 0x95, b[x+15]) == 0) // ??
			//             ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x95:0x%X]", b[x+15]);
			//     } else if (b[x+10] & 4) {
			//         ht_fprintf(outFile,TYPE_NORMAL,", putting in Icon from object in ");
			//         data2(b[x+12],w2);
			//         if (b[x+11] & 8)
			//             ht_fprintf(outFile,TYPE_NORMAL," getting model name index from Temp6");
			//         else
			//             ht_fprintf(outFile,TYPE_NORMAL," using default object model");
			//     }
			//     if (b[x+10] & 0x80)
			//         ht_fprintf(outFile,TYPE_NORMAL,", putting effect in priority Queue");
			//     break;
#endif
		}
	}

	public class WizPrim0x0071 : BhavWizPrim // Snap Into -- for wizard, see edithWiki CreatingAChair
	{
		public WizPrim0x0071(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				(lng ? pjse.Localization.GetString("Object") + ": " : "")
				+ dataOwner(lng, o[0], o[1], o[2])
				+ ", "
				+ (lng ? pjse.Localization.GetString("Target") + ": " : "")
				+ dataOwner(lng, o[3], o[4], o[5]);
			s +=
				", "
				+ (lng ? pjse.Localization.GetString("bwp_slot") + ": " : "")
				+ (
					(o[9] & 0x01) != 0
						? dataOwner(0x08, 0)
						: "0x" + SimPe.Helper.HexString(o[6])
				);
			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp_testOnly")
					+ ": "
					+ ((o[9] & 0x02) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp71_resetRootBones")
					+ ": "
					+ ((o[9] & 0x04) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x71:  // Snap Into
			//     w1 = *(UINT16 *) (&b[x+1]);
			//     w2 = *(UINT16 *) (&b[x+4]);
			//     ht_fprintf(outFile,TYPE_NORMAL,"Snap Object in ");
			//     data2(b[x],w1);
			//     ht_fprintf(outFile,TYPE_NORMAL," into Object in ");
			//     data2(b[x+3],w2);
			//     if (b[x+9] & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", using slot # in temp 0");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,", using slot number %d", b[x+6]);
			//     if (b[x+9] & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,", TEST ONLY");
			//     if (b[x+9] & 4)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Reset root bones");
			//     break;
#endif
		}
	}

	public class WizPrim0x0072 : BhavWizPrim // Assign Locomotion Animations
	{
		public WizPrim0x0072(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			switch (ToShort(o[0], o[1]))
			{
				case 0:
					s += pjse.Localization.GetString("bwp72_popAll");
					break;
				case 1:
					s += pjse.Localization.GetString("bwp72_pop");
					break;
				default:
					Scope scope = Scope.Private;
					if ((o[2] & 0x04) != 0)
					{
						scope = Scope.Global;
					}
					else if ((o[2] & 0x02) != 0)
					{
						scope = Scope.SemiGlobal;
					}

					s +=
						pjse.Localization.GetString("bwp72_push")
						+ ": "
						+ readStr(
							scope,
							GS.GlobalStr.LocoAnims,
							(ushort)(ToShort(o[0], o[1]) - 2),
							lng ? -1 : 60,
							lng ? Detail.Normal : Detail.ErrorNames
						);
					break;
			}

			return s;
#if DISASIM
			// case 0x72:  // Assign Locomotion Animations (false = error)
			//     w1 = *(UINT16 *) (&b[x]);
			//     switch (w1) {
			//         case 0:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Pop all entries from Stack.");
			//             break;
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Pop last entry from Stack.");
			//             break;
			//         default:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Push group #%d onto Stack", w1-2);
			//             ht_fprintf(outFile,TYPE_NORMAL,", getting group from ");
			//             if (b[x+2] & 4)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Global.");
			//             else if (b[x+2] & 2)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"SemiGlobal.");
			//             else
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Private.");
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x0073 : BhavWizPrim // Debug
	{
		public WizPrim0x0073(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			Scope scope = Scope.Private;
			if ((o[14] & 0x04) != 0)
			{
				scope = Scope.Global;
			}
			else if ((o[14] & 0x02) != 0)
			{
				scope = Scope.SemiGlobal;
			}

			if (o[13] == 0)
			{
				s += readStr(
					scope,
					GS.GlobalStr.DebugString,
					o[12],
					lng ? -1 : 60,
					lng ? Detail.Normal : Detail.ErrorNames
				);
				if (lng)
				{
					s += " (";
					for (int i = 0; i < 4; i++)
					{
						s +=
							(i == 0 ? "" : ", ")
							+ dataOwner(o[i * 3], o[i * 3 + 1], o[i * 3 + 2]);
					}

					s += ")";
				}
			}
			else
			{
				s += readStr(GS.BhavStr.DebugType, o[13]);
				if (o[13] == 6)
				{
					s +=
						": "
						+ readStr(
							scope,
							GS.GlobalStr.DebugString,
							o[12],
							lng ? -1 : 60,
							lng ? Detail.Normal : Detail.ErrorNames
						);
				}
			}

			return s;
#if DISASIM
			// case 0x73:  // Debug (false = error)
			//     switch (b[x+13]) {
			//         case 0:
			//             if (b[x+14] & 4)
			//                 readString2(GROUP_GLOBAL, 0x132, b[x+12]);
			//             else if (b[x+14] & 2) {
			//                 if (readString2(gGlobGroup, 0x132, b[x+12]) == 0)
			//                     ht_fprintf(outFile,TYPE_NORMAL,"[SemiGlobal STR# 0x132:0x%X]", b[x+12]);
			//             }
			//             else if (readString2(gGroup, 0x132, b[x+12]) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[Private STR# 0x132:0x%X]", b[x+12]);
			//             w1 = *(UINT16 *) (&b[x+1]);
			//             w2 = *(UINT16 *) (&b[x+4]);
			//             w3 = *(UINT16 *) (&b[x+7]);
			//             w4 = *(UINT16 *) (&b[x+10]);
			//             ht_fprintf(outFile,TYPE_NORMAL,", param 0: ");
			//             data2(b[x], w1);
			//             ht_fprintf(outFile,TYPE_NORMAL,", param 1: ");
			//             data2(b[x+3], w2);
			//             ht_fprintf(outFile,TYPE_NORMAL,", param 2: ");
			//             data2(b[x+6], w3);
			//             ht_fprintf(outFile,TYPE_NORMAL,", param 3: ");
			//             data2(b[x+9], w4);
			//             break;
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Toggle Window Open/Close");
			//             break;
			//         case 2:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Open Animation Ticker");
			//             break;
			//         case 3:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Show Slots");
			//             break;
			//         case 4:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Show Bones");
			//             break;
			//         case 5:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Toggle Anim Info to Debug Window");
			//             break;
			//         case 6:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Perform Cheat ");
			//             if (b[x+14] & 4)
			//                 readString2(GROUP_GLOBAL, 0x132, b[x+12]);
			//             else if (b[x+14] & 2) {
			//                 if (readString2(gGlobGroup, 0x132, b[x+12]) == 0)
			//                     ht_fprintf(outFile,TYPE_NORMAL,"[SemiGlobal STR# 0x132:0x%X]", b[x+12]);
			//             } else if (readString2(gGroup, 0x132, b[x+12]) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[Private STR# 0x132:0x%X]", b[x+12]);
			//             break;
			//         case 7:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Dump Happy Log");
			//             break;
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x0074 : BhavWizPrim // Reach/Put
	{
		public WizPrim0x0074(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			switch (o[10])
			{
				case 0:
					s +=
						pjse.Localization.GetString("bwp74_pickUp")
						+ ": "
						+ dataOwner(lng, o[3], ToShort(o[4], o[5]));
					break;
				case 1:
					s +=
						pjse.Localization.GetString("bwp74_dropOnto")
						+ ": "
						+ pjse.Localization.GetString("bwp74_floor");
					break;
				default:
					s +=
						pjse.Localization.GetString("bwp74_dropOnto")
						+ ": "
						+ dataOwner(lng, o[3], ToShort(o[4], o[5]));
					break;
			}

			s +=
				", "
				+ pjse.Localization.GetString("bwp_slot")
				+ ": "
				+ (
					(o[9] & 0x01) != 0
						? dataOwner(0x08, 0) // Temp 0
						: "0x" + SimPe.Helper.HexString(o[6])
				);

			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp74_objectAnim")
					+ ": "
					+ (
						ToShort(o[13], o[14]) != 0xFFFF
							? readStr(
								GS.GlobalStr.ObjectAnims,
								ToShort(o[13], o[14]),
								-1,
								Detail.ErrorNames
							)
							: pjse.Localization.GetString("none")
					);

				s +=
					", "
					+ pjse.Localization.GetString("bwp74_graspAnim")
					+ ": "
					+ (
						ToShort(o[11], o[12]) != 0xFFFF
							? readStr(
								GS.GlobalStr.AdultAnims,
								ToShort(o[11], o[12]),
								-1,
								Detail.ErrorNames
							)
							: pjse.Localization.GetString("none")
					);

				s +=
					", "
					+ pjse.Localization.GetString("bwp74_handedness")
					+ ": "
					+ ((o[9] & 0x02) != 0 ? dataOwner(0x08, 3) : "---"); // Temp 3
				s +=
					", "
					+ pjse.Localization.GetString("bwp74_agedAnim")
					+ ": "
					+ ((o[9] & 0x04) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x74:  // Reach/Put
			//     w1 = *(UINT16 *) (&b[x+4]);
			//     w2 = *(UINT16 *) (&b[x+13]);
			//     w3 = *(UINT16 *) (&b[x+11]);
			//     switch (b[x+10]) {
			//         case 0:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Pick up Object in ");
			//             data2(b[x+3],w1);
			//             break;
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Drop object onto Floor");
			//             break;
			//         default:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Drop onto Object in ");
			//             data2(b[x+3],w1);
			//     }
			//     if (b[x+10]!= 1 && b[x+10]!= 2)
			//         if (b[x+9] & 1)
			//             ht_fprintf(outFile,TYPE_NORMAL,", using slot # in temp 0");
			//         else
			//             ht_fprintf(outFile,TYPE_NORMAL,", using slot number %d", b[x+6]);
			//     ht_fprintf(outFile,TYPE_NORMAL,", object anim: ");
			//     if (w2 != 0xFFFF) {
			//         if (readString2(gGroup, 0x86, w2) == 0) // ?
			//             ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x86:0x%X]", w2);
			//     } else
			//         ht_fprintf(outFile,TYPE_NORMAL,"none");
			//     if (b[x+9] & 4)
			//         ht_fprintf(outFile,TYPE_NORMAL,", using Sim age as filter on object Anim");
			//     ht_fprintf(outFile,TYPE_NORMAL,", grasp anim: ");
			//     if (w3 != 0xFFFF) {
			//         if (readString2(gGroup, 0x81, w3) == 0) // ?
			//             ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x81:0x%X]", w3);
			//     } else
			//         ht_fprintf(outFile,TYPE_NORMAL,"none");
			//     if (b[x+9] & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,", expecting handedness in temp 3");
			//     break;
#endif
		}
	}

	public class WizPrim0x0075 : BhavWizPrim // Age
	{
		public WizPrim0x0075(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			if ((o[1] & 0x01) != 0)
			{
				s += dataOwner(0x08, 0);
			}
			else
			{
				s += readStr(pjse.GS.BhavStr.AgePrimAges, o[0]);
			}

			return s;
#if DISASIM
			// case 0x75:  // Age (false = error)
			//     if (b[x+1] & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,"Expect Age in Temp 0");
			//     else {
			//         ht_fprintf(outFile,TYPE_NORMAL,"Set Age to ");
			//         switch (b[x]) {
			//             case 1:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Child");
			//                 break;
			//             case 2:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Toddler");
			//                 break;
			//             case 3:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Teen");
			//                 break;
			//             case 4:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Elder");
			//                 break;
			//             case 7:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Baby");
			//                 break;
			//             case 9:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Young Adult");
			//                 break;
			//             default:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Adult");
			//         }
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x0076 : BhavWizPrim // Array Operation
	{
		public WizPrim0x0076(Instruction i)
			: base(i) { }

		public override ABhavOperandWiz Wizard()
		{
			return new pjse.BhavOperandWizards.BhavOperandWiz0x0076(instruction);
		}

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s += pjse.Localization.GetString(
				o[2] == 0 ? "bwp_myArray" : "bwp_stackObjectArray"
			);
			// See discussion around whether this is a bit vs boolean:
			// http://simlogical.com/SMF/index.php?topic=917.msg6641#msg6641
			s = s.Replace("[array]", ArrayName(lng, ToShort(o[3], o[4])));
			s += ", ";

			switch (o[1])
			{
				case 0x00:
					s += pjse.Localization.GetString("bwp76_clearContents");
					break;
				case 0x01:
					s +=
						pjse.Localization.GetString("bwp76_getSize")
						+ ": "
						+ dataOwner(lng, o[5], o[6], o[7]);
					break;
				case 0x02:
					s +=
						pjse.Localization.GetString("bwp76_setSize")
						+ ": "
						+ dataOwner(lng, o[5], o[6], o[7]);
					break;
				case 0x03:
					s +=
						pjse.Localization.GetString("bwp76_setAll")
						+ ": "
						+ dataOwner(lng, o[5], o[6], o[7]);
					break;
				case 0x04:
					s +=
						pjse.Localization.GetString("bwp76_unshift")
						+ ": "
						+ dataOwner(lng, o[5], o[6], o[7]);
					break;
				case 0x05:
					s +=
						pjse.Localization.GetString("bwp76_push")
						+ ": "
						+ dataOwner(lng, o[5], o[6], o[7]);
					break;
				case 0x06:
					s +=
						pjse.Localization.GetString("bwp76_insert")
						+ ": "
						+ dataOwner(lng, o[5], o[6], o[7])
						+ ", "
						+ pjse.Localization.GetString("bwp76_at")
						+ ": "
						+ dataOwner(lng, o[8], o[9], o[10]);
					break;
				case 0x07:
					s += pjse.Localization.GetString("bwp76_shift");
					s +=
						", ?"
						+ pjse.Localization.GetString("bwp76_into")
						+ ": "
						+ dataOwner(lng, o[5], o[6], o[7])
						+ "?";
					break;
				case 0x08:
					s += pjse.Localization.GetString("bwp76_pop");
					s +=
						", ?"
						+ pjse.Localization.GetString("bwp76_into")
						+ ": "
						+ dataOwner(lng, o[5], o[6], o[7])
						+ "?";
					break;
				case 0x09:
					s +=
						pjse.Localization.GetString("bwp76_remove")
						+ ": "
						+ dataOwner(lng, o[8], o[9], o[10]);
					s +=
						", ?"
						+ pjse.Localization.GetString("bwp76_into")
						+ ": "
						+ dataOwner(lng, o[5], o[6], o[7])
						+ "?";
					break;
				case 0x0a:
					s +=
						pjse.Localization.GetString("bwp76_set")
						+ ": "
						+ dataOwner(lng, o[8], o[9], o[10])
						+ ", "
						+ pjse.Localization.GetString("bwp76_toNext")
						+ ": "
						+ dataOwner(lng, o[5], o[6], o[7]);
					break;
				case 0x0b:
					s +=
						pjse.Localization.GetString("bwp76_swap")
						+ ": "
						+ dataOwner(lng, o[5], o[6], o[7])
						+ ", "
						+ dataOwner(lng, o[8], o[9], o[10]);
					break;
				case 0x0c:
					s += pjse.Localization.GetString("bwp76_sortHiLo");
					break;
				case 0x0d:
					s += pjse.Localization.GetString("bwp76_sortLoHi");
					break;
				default:
					s +=
						pjse.Localization.GetString("unk")
						+ ": 0x"
						+ SimPe.Helper.HexString(o[1]);
					break;
			}

			return s;
#if DISASIM
			// case 0x76:  // Array Operation
			//     w1 = *(UINT16 *) (&b[x+6]);
			//     w2 = *(UINT16 *) (&b[x+9]);
			//     w3 = *(UINT16 *) (&b[x+3]);
			//     if (b[x+2] == 0)
			//         ht_fprintf(outFile,TYPE_NORMAL,"My Object Array: ");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,"Stack Object's Object Array: ");
			//     if (readString2(gGroup, 0x118, w3) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x118:0x%X]", w3);
			//     ht_fprintf(outFile,TYPE_NORMAL,". Operation: ");
			//     switch (b[x+1]) {
			//         case 0:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Clear contents of array.");
			//             break;
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Return size of array into ");
			//             data2(b[x+5],w1);
			//             ht_fprintf(outFile,TYPE_NORMAL,".");
			//             break;
			//         case 2:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Resize array to size from ");
			//             data2(b[x+5],w1);
			//             ht_fprintf(outFile,TYPE_NORMAL,".");
			//             break;
			//         case 3:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Init all elements of the array with value from ");
			//             data2(b[x+5],w1);
			//             ht_fprintf(outFile,TYPE_NORMAL,".");
			//             break;
			//         case 4:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Insert element to array from ");
			//             data2(b[x+5],w1);
			//             ht_fprintf(outFile,TYPE_NORMAL," to the front of the array.");
			//             break;
			//         case 5:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Insert element to array from ");
			//             data2(b[x+5],w1);
			//             ht_fprintf(outFile,TYPE_NORMAL," to the back of the array.");
			//             break;
			//         case 6:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Insert element to array from ");
			//             data2(b[x+5],w1);
			//             ht_fprintf(outFile,TYPE_NORMAL," to the position indicated by iterator in ");
			//             data2(b[x+8],w2);
			//             ht_fprintf(outFile,TYPE_NORMAL,".");
			//             break;
			//         case 7:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Remove front element from array.");
			//             break;
			//         case 8:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Remove back element from array.");
			//             break;
			//         case 9:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Remove element from array at position given by iterator in ");
			//             data2(b[x+8],w2);
			//             ht_fprintf(outFile,TYPE_NORMAL,".");
			//             break;
			//         case 0xA:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Advance iterator in ");
			//             data2(b[x+8],w2);
			//             ht_fprintf(outFile,TYPE_NORMAL," to next occurance of element from ");
			//             data2(b[x+5],w1);
			//             ht_fprintf(outFile,TYPE_NORMAL,".");
			//             break;
			//         case 0xB:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Swap elements of array at iterator ");
			//             data2(b[x+5],w1);
			//             ht_fprintf(outFile,TYPE_NORMAL," and iterator ");
			//             data2(b[x+8],w2);
			//             ht_fprintf(outFile,TYPE_NORMAL,".");
			//             break;
			//         case 0xC:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Sort array into highest to lowest order.");
			//             break;
			//         case 0xD:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Sort array into lowest to highest order.");
			//             break;
			//         default:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Alex Fennell's magic array operation. If you see this string....be afraid.");
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x0077 : BhavWizPrim // Message
	{
		public WizPrim0x0077(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				(lng ? pjse.Localization.GetString("bwp_message") + ": " : "")
				+ dataOwner(lng, o[15], o[1], o[2]);

			s += ", " + (lng ? pjse.Localization.GetString("Target") + ": " : "");
			if ((o[4] & 0x04) != 0)
			{
				s += dataOwner(lng, o[5], o[6], o[7]);
			}
			else
			{
				switch (o[3])
				{
					case 0:
						s += pjse.Localization.GetString("bwp77_selectableSims");
						break;
					case 1:
						s +=
							pjse.Localization.GetString("bwp77_selectableSims")
							+ " + "
							+ pjse.Localization.GetString("bwp77_neighbors");
						break;
					case 2:
						s +=
							pjse.Localization.GetString("bwp77_selectableSims")
							+ " + "
							+ pjse.Localization.GetString("bwp77_npcs");
						break;
					case 3:
						s += pjse.Localization.GetString("bwp77_neighbors");
						break;
					case 4:
						s += pjse.Localization.GetString("bwp77_npcs");
						break;
					case 5:
						s += pjse.Localization.GetString("bwp77_allSims");
						break;
					case 6:
						s += pjse.Localization.GetString("bwp77_objects");
						break;
					case 7:
						s += pjse.Localization.GetString("bwp77_everything");
						break;
					default:
						s +=
							pjse.Localization.GetString("unk")
							+ ": 0x"
							+ SimPe.Helper.HexString(o[3]);
						break;
				}
			}

			if (lng)
			{
				s +=
					", "
					+ (lng ? pjse.Localization.GetString("bwp_Location") + ": " : "");
				switch (o[0])
				{
					case 0:
						s +=
							pjse.Localization.GetString("bwp77_room")
							+ ": "
							+ (
								(o[4] & 0x01) == 0
									? pjse.Localization.GetString("bwp77_same")
									: dataOwner(o[5], o[6], o[7])
							);
						break;
					case 1:
						s += pjse.Localization.GetString("bwp77_onSameLevel");
						break;
					case 2:
						s += pjse.Localization.GetString("bwp77_onLot");
						break;
					case 3:
						s += pjse.Localization.GetString("bwp77_insideBuilding");
						break;
					case 4:
						s += pjse.Localization.GetString("bwp77_outsideBuilding");
						break;
					default:
						s +=
							pjse.Localization.GetString("unk")
							+ ": 0x"
							+ SimPe.Helper.HexString(o[0]);
						break;
				}

				s +=
					", "
					+ pjse.Localization.GetString("bwp_priority")
					+ ": 0x"
					+ SimPe.Helper.HexString(o[8]);

				s +=
					", "
					+ pjse.Localization.GetString("bwp77_userData")
					+ ": ("
					+ dataOwner(o[9], o[10], o[11])
					+ ", "
					+ dataOwner(o[12], o[13], o[14])
					+ ")";
			}

			return s;
#if DISASIM
			// case 0x77:  // Message
			//     w1 = *(UINT16 *) (&b[x+1]);
			//     w2 = *(UINT16 *) (&b[x+6]);
			//     w3 = *(UINT16 *) (&b[x+10]);
			//     w4 = *(UINT16 *) (&b[x+13]);
			//     ht_fprintf(outFile,TYPE_NORMAL,"Sending Message ID inside ");
			//     data2(b[x+15],w1);
			//     ht_fprintf(outFile,TYPE_NORMAL,", priority %d",b[x+8]);
			//     if (b[x+4] & 4) {
			//         ht_fprintf(outFile,TYPE_NORMAL," Targetting specific target in ");
			//         data2(b[x+5],w2);
			//     } else {
			//         ht_fprintf(outFile,TYPE_NORMAL," Targetting ");
			//         switch (b[x+3]) {
			//             case 0:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Selectable Sims");
			//                 break;
			//             case 1:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Selectable Sims + Neighbors");
			//                 break;
			//             case 2:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Selectable Sims + NPCS");
			//                 break;
			//             case 3:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Neighbors Only");
			//                 break;
			//             case 4:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"NPCS Only");
			//                 break;
			//             case 5:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"All Sims");
			//                 break;
			//             case 6:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Objects");
			//                 break;
			//             case 7:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Everything");
			//                 break;
			//         }
			//         ht_fprintf(outFile,TYPE_NORMAL," using filter ");
			//         switch (b[x]) {
			//             case 0:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"In Same Room Only");
			//                 if (b[x+4] & 1) {
			//                     ht_fprintf(outFile,TYPE_NORMAL," targeting room in ");
			//                     data2(b[x+5],w2);
			//                 }
			//                 break;
			//             case 1:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"On Same Level Only");
			//                 break;
			//             case 2:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"On Lot");
			//                 break;
			//             case 3:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"Inside building Only");
			//                 break;
			//             case 4:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"OutSide Building Only");
			//                 break;
			//         }
			//         ht_fprintf(outFile,TYPE_NORMAL,", getting user data from ");
			//         data2(b[x+9],w3);
			//         ht_fprintf(outFile,TYPE_NORMAL,", and ");
			//         data2(b[x+12],w4);
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x0078 : BhavWizPrim // RayTrace
	{
		public WizPrim0x0078(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				(lng ? pjse.Localization.GetString("Object") + ": " : "")
				+ dataOwner(lng, o[1], o[2], o[3])
				+ ", "
				+ Slot(o[4], o[5]);
			s +=
				", "
				+ (lng ? pjse.Localization.GetString("Target") + ": " : "")
				+ dataOwner(lng, o[8], o[9], o[10])
				+ ", "
				+ Slot(o[11], o[12]);

			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp78_windowsIgnored")
					+ ": "
					+ ((o[15] & 0x01) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp_resultIn")
					+ ": "
					+ dataOwner(0x08, 0); // Temp 0
			}

			return s;
#if DISASIM
			// case 0x78:  // RayTrace
			//     w1 = *(UINT16 *) (&b[x+2]);
			//     w2 = *(UINT16 *) (&b[x+9]);
			//     ht_fprintf(outFile,TYPE_NORMAL,"From Object in ");
			//     data2(b[x+1],w1);
			//     ht_fprintf(outFile,TYPE_NORMAL," using ");
			//     switch (b[x+4]) {
			//         case 0:
			//             ht_fprintf(outFile,TYPE_NORMAL,"point at 3/4 height of object.");
			//             break;
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL,"targeting slot");
			//             break;
			//         case 2:
			//             ht_fprintf(outFile,TYPE_NORMAL,"routing slot");
			//             break;
			//         default:
			//             ht_fprintf(outFile,TYPE_NORMAL,"containment slot");
			//     }
			//     if (b[x+4] != 0)
			//         ht_fprintf(outFile,TYPE_NORMAL,", slot number %d into the world. Object hit stored in Temp 0.", b[x+5]);
			//     else {
			//         ht_fprintf(outFile,TYPE_NORMAL," To Object in ");
			//         data2(b[x+8],w2);
			//         ht_fprintf(outFile,TYPE_NORMAL," using ");
			//         switch (b[x+11]) {
			//             case 0:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"point at 3/4 height of object.");
			//                 break;
			//             case 1:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"targeting slot");
			//                 break;
			//             case 2:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"routing slot");
			//                 break;
			//             default:
			//                 ht_fprintf(outFile,TYPE_NORMAL,"containment slot");
			//         }
			//         if (b[x+11] != 0)
			//             ht_fprintf(outFile,TYPE_NORMAL,", slot number %d.", b[x+12]);
			//     }
			//     if (b[x+15] & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL," Windows Ignored.");
			//     break;
#endif
		}
	}

	public class WizPrim0x0079 : BhavWizPrim // Change Outfit
	{
		public WizPrim0x0079(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			if ((o[0] & 0x10) != 0)
			{
				s += pjse.Localization.GetString("bwp79_rebuild") + ", ";
			}
			//else s += "change outfit";

			s +=
				(lng ? pjse.Localization.GetString("Target") + ": " : "")
				+ dataOwner(lng, o[9], o[10], o[11]);

			if (lng)
			{
				s += ", " + pjse.Localization.GetString("bwp_source") + ": ";
				if ((o[0] & 0x01) != 0)
				{
					s += dnStkOb();
				}
				else if ((o[0] & 0x02) != 0)
				{
					s += BhavWiz.FormatGUID(lng, o, 4);
				}
				else if ((o[0] & 0x40) != 0)
				{
					s += "GUID [" + dataOwner(0x08, 0) + ",1]";
				}
				else
				{
					s += pjse.Localization.GetString("bwp79_self");
				}

				s += ", ";
				if ((o[0] & 4) == 0)
				{
					s +=
						pjse.Localization.GetString("bwp79_outfit")
						+ ": "
						+ readStr(GS.BhavStr.PersonOutfits, o[8]);
				}
				else
				{
					s +=
						pjse.Localization.GetString("bwp79_outfitIndex")
						+ ": "
						+ dataOwner(o[1], o[2], o[3]);
				}

				s +=
					", "
					+ pjse.Localization.GetString("bwp79_personData")
					+ ": "
					+ ((o[0] & 0x20) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp79_save")
					+ ": "
					+ ((o[0] & 0x08) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x79:  // Change Outfit (false = error)
			//     c1 = b[x];
			//     w1 = *(UINT16 *) (&b[x+10]);
			//     w2 = *(UINT16 *) (&b[x+2]);
			//     d1 = *(UINT32 *) (&b[x+4]);
			//     if (c1 & 0x10)
			//         ht_fprintf(outFile,TYPE_NORMAL,"Rebuild current outfit on sim in ");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL,"Change Outfit on sim in ");
			//     data2(b[x+9],w1);
			//     if (c1 & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL," using Stack Object");
			//     else if (c1 & 2) {
			//         ht_fprintf(outFile,TYPE_NORMAL," using GUID of 0x%08X", d1);
			//         readGUID(d1);
			//     } else if (c1 & 0x40)
			//         ht_fprintf(outFile,TYPE_NORMAL,", using GUID in Temp 0/1");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL," using that sims outfits");
			//     ht_fprintf(outFile,TYPE_NORMAL," as source, using outfit ");
			//     if (c1 & 4) {
			//         ht_fprintf(outFile,TYPE_NORMAL,"index from ");
			//         data2(b[x+1],w2);
			//     } else {
			//         CHECK_RANGE("Person outfits", gStringFA, b[x+8]);
			//         ht_fprintf(outFile,TYPE_NORMAL,"%s", gStringFA[b[x+8]]);
			//     }
			//     if (c1 & 0x20)
			//         ht_fprintf(outFile,TYPE_NORMAL,", clearing GUID pointers in person data fields");
			//     if (c1 & 8)
			//         ht_fprintf(outFile,TYPE_NORMAL,", writing changes to the .iff");
			//     break;
#endif
		}
	}

	public class WizPrim0x007a : BhavWizPrim // Timer
	{
		public WizPrim0x007a(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			switch (o[15])
			{
				case 0:
					s += pjse.Localization.GetString("bwp7a_start");
					break;
				case 1:
					s += pjse.Localization.GetString("bwp7a_modify");
					break;
				case 2:
					s += pjse.Localization.GetString("bwp7a_delete");
					break;
				default:
					s +=
						pjse.Localization.GetString("unk")
						+ ": 0x"
						+ SimPe.Helper.HexString(o[15]);
					break;
			}

			if (o[15] != 2)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp_ticks")
					+ ": "
					+ (
						(o[5] & 0x08) != 0
							? dataOwner(0x08, 1) // Temp 1
							: "0x" + SimPe.Helper.HexString(ToShort(o[0], o[1]))
					);

				if (lng)
				{
					bool found = false;
					s +=
						", "
						+ pjse.Localization.GetString("bwp_eventTree")
						+ ": "
						+ bhavName(ToShort(o[3], o[4]), ref found);

					Scope scope = Scope.Global;
					if (o[14] == 0)
					{
						scope = Scope.Private;
					}
					else if (o[14] == 1)
					{
						scope = Scope.SemiGlobal;
					}

					s += " (" + pjse.Localization.GetString(scope.ToString()) + ")";

					s += ", " + pjse.Localization.GetString("manyArgs") + ": ";
					if ((o[5] & 0x01) != 0)
					{
						s += pjse.Localization.GetString("bw_callerparams");
					}
					else
					{
						for (int i = 0; i < 3; i++)
						{
							s +=
								(i == 0 ? "" : ", ")
								+ dataOwner(o[3 * i + 6], o[3 * i + 7], o[3 * i + 8]);
						}
					}

					s +=
						", "
						+ pjse.Localization.GetString("bwp7a_looping")
						+ ": "
						+ ((o[5] & 0x02) != 0).ToString();

					if (o[15] == 1)
					{
						s +=
							", "
							+ pjse.Localization.GetString("bwp7a_reset")
							+ ": "
							+ ((o[5] & 0x04) != 0).ToString();
					}
				}
			}

			return s;
#if DISASIM
			// case 0x7A:  // On Timer (false = error)
			//     w1 = *(UINT16 *) (&b[x+7]);
			//     w2 = *(UINT16 *) (&b[x+10]);
			//     w3 = *(UINT16 *) (&b[x+13]);
			//     w4 = *(UINT16 *) (&b[x]);
			//     w5 = *(UINT16 *) (&b[x+3]);
			//     switch (b[x+15]) {
			//         case 0:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Start Timer");
			//             break;
			//         case 1:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Modify Timer");
			//             break;
			//         case 2:
			//             ht_fprintf(outFile,TYPE_NORMAL,"Delete Timer");
			//             break;
			//     }
			//     if (b[x+15] != 2) {
			//         if (b[x+5] & 8)
			//             ht_fprintf(outFile,TYPE_NORMAL,", Getting ticks till fire from temp 1");
			//         else
			//             ht_fprintf(outFile,TYPE_NORMAL,", Ticks till fire %d", w4);

			//         if (w5 == 0)
			//             ht_fprintf(outFile,TYPE_NORMAL," No Event Tree");
			//         else {
			//             switch (b[x+2]) {
			//                 case 0:
			//                     ht_fprintf(outFile,TYPE_NORMAL," Using Private Event Tree: ");
			//                     break;
			//                 case 1:
			//                     ht_fprintf(outFile,TYPE_NORMAL," Using SemiGlobal Event Tree: ");
			//                     break;
			//                 default:
			//                     ht_fprintf(outFile,TYPE_NORMAL," Using Global Event Tree: ");
			//                     break;
			//             }
			//             ht_fprintf(outFile,TYPE_NORMAL,"0x%X (",w5);
			//             readFn2(w5);
			//             ht_fprintf(outFile,TYPE_NORMAL,")");
			//         }
			//         if (b[x+5] & 2)
			//             ht_fprintf(outFile,TYPE_NORMAL,", Looping");
			//         if (b[x+5] & 1)
			//             ht_fprintf(outFile,TYPE_NORMAL,", using current params as event tree params");
			//         else {
			//             ht_fprintf(outFile,TYPE_NORMAL,", passing in params found in  ");
			//             data2(b[x+6],w1);
			//             ht_fprintf(outFile,TYPE_NORMAL,", ");
			//             data2(b[x+9],w2);
			//             ht_fprintf(outFile,TYPE_NORMAL,", ");
			//             data2(b[x+12],w3);
			//         }
			//         if (b[x+15] == 1)
			//             if (b[x+5] & 4)
			//                 ht_fprintf(outFile,TYPE_NORMAL,", Reset Timer Ticks");
			//     }
			//     break;
#endif
		}
	}

	public class WizPrim0x007b : BhavWizPrim // Cinematic
	{
		public WizPrim0x007b(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			Scope scope = Scope.Private;
			if ((o[5] & 0x20) != 0)
			{
				scope = Scope.Global;
			}
			else if ((o[5] & 0x40) != 0)
			{
				scope = Scope.SemiGlobal;
			}

			s +=
				(lng ? pjse.Localization.GetString("bwp7b_scene") + ": " : "")
				+ (
					(o[5] & 0x10) != 0
						? dataOwner(lng, o[6], o[7], o[8])
						: readStr(
							scope,
							GS.GlobalStr.CineCam,
							ToShort(o[0], o[1]),
							lng ? -1 : 60,
							lng ? Detail.Normal : Detail.ErrorNames
						)
				);

			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp7b_array")
					+ ": "
					+ dataOwner(lng, o[9], o[10], o[11]);

				s +=
					", "
					+ pjse.Localization.GetString("bwp_flipFlag")
					+ ": "
					+ (
						(o[5] & 0x02) != 0
							? dataOwner(0x08, 0) // Temp 0
							: ((o[5] & 0x01) != 0).ToString()
					);
				s +=
					", "
					+ pjse.Localization.GetString("bwp7b_start")
					+ ": "
					+ ((o[5] & 0x04) != 0).ToString();
				s +=
					", "
					+ pjse.Localization.GetString("bwp7b_showHouse")
					+ ": "
					+ ((o[5] & 0x08) != 0).ToString();
			}

			return s;
#if DISASIM
			// case 0x7B:  // Cinematic
			//     c1 = b[x+5];
			//     w1 = *(UINT16 *) (&b[x+7]);
			//     w2 = *(UINT16 *) (&b[x]);
			//     w3 = *(UINT16 *) (&b[x+10]);
			//     if (c1 & 0x10) {
			//         ht_fprintf(outFile,TYPE_NORMAL,"Using scene name index found in ");
			//         data2(b[x+6],w1);
			//     } else {
			//         ht_fprintf(outFile,TYPE_NORMAL,"Using Scene ");
			//         if (c1 & 0x20)
			//             readString2(GROUP_GLOBAL, 0x97, w2);
			//         else if (c1 & 0x40) {
			//             if (readString2(gGlobGroup, 0x97, w2) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[SemiGlobal STR# 0x97:0x%X]", w2);
			//         }
			//         else if (readString2(gGroup, 0x97, w2) == 0)
			//             ht_fprintf(outFile,TYPE_NORMAL,"[Private STR# 0x97:0x%X]", w2);
			//     }
			//     ht_fprintf(outFile,TYPE_NORMAL,", Using array found in objID in ");
			//     data2(b[x+9],w3);
			//     if (c1 & 1)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Flip Cinematic Anims Horizontally");
			//     if (c1 & 2)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Pass in Flip Cinematic Anims Horizontally value in temp 0");
			//     if (c1 & 4)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Start Animations Now");
			//     if (c1 & 8)
			//         ht_fprintf(outFile,TYPE_NORMAL,", Show Entire House");
			//     break;
#endif
		}
	}

	public class WizPrim0x007c : BhavWizPrim // Want Satisfy -- for wizard, see edithWiki WantSatisfacton
	{
		public WizPrim0x007c(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				(lng ? pjse.Localization.GetString("Target") + ": " : "")
				+ dataOwner(lng, o[7], o[8], o[9]);
			// Mmm, wants don't appear to use OBJDs, so GUID lookups don't work...
			uint want = (uint)(o[3] | o[4] << 8 | o[5] << 16 | o[6] << 24);
			s +=
				", "
				+ pjse.Localization.GetString("bwp7c_want")
				+ ": 0x"
				+ SimPe.Helper.HexString(want);
			if (lng)
			{
				s +=
					", "
					+ pjse.Localization.GetString("bwp7c_level")
					+ ": "
					+ dataOwner(o[10], o[11], o[12]);
			}

			return s;
#if DISASIM
			// case 0x7C:  // Want Satisfy
			//     d1 = *(UINT32 *) (&b[x+3]);
			//     ht_fprintf(outFile,TYPE_NORMAL,"GUID 0x%08X ", d1);

			//     w2 = 0xFFFF;
			//     w3 = GET_ASIZE(gWants);
			//     for (w1 = 0; w1 < w3; w1++) if (d1 == gWants[w1].guid)  w2 = w1;
			//     if (w2 != 0xFFFF) {
			//         ht_fprintf(outFile,TYPE_NORMAL,"(%s) ", gWants[w2].name);

			//         w3 = *(UINT16 *) (&b[x+8]);
			//         w4 = *(UINT16 *) (&b[x+11]);
			//         w5 = *(UINT16 *) (&b[x+1]);

			//         switch (gWants[w2].type) {
			//             case 0:        // None
			//                 ht_fprintf(outFile,TYPE_NORMAL,"with value ");
			//                 break;
			//             case 1:        // Sim
			//                 ht_fprintf(outFile,TYPE_NORMAL,"with person in ");
			//                 break;
			//             case 2:        // Guid
			//             case 3:        // Category
			//                 ht_fprintf(outFile,TYPE_NORMAL,"with object in ");
			//                 break;
			//             case 4:        // Skill
			//                 ht_fprintf(outFile,TYPE_NORMAL,"with skill ");
			//                 break;
			//             case 5:        // Career
			//                 ht_fprintf(outFile,TYPE_NORMAL,"with career ");
			//                 break;
			//             case 6:        // Badge
			//                 ht_fprintf(outFile,TYPE_NORMAL,"with badge ");
			//                 break;
			//         }

			//         data2(b[x+7],w3);
			//         if (gWants[w2].type >= 4 && gWants[w2].type <= 6) {
			//             ht_fprintf(outFile,TYPE_NORMAL," and level ");
			//             data2(b[x+10],w4);
			//         }
			//     }
			//     break;

#endif
		}
	}

	public class WizPrim0x007d : BhavWizPrim // Influence
	{
		public WizPrim0x007d(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			string s = "";

			s +=
				(lng ? pjse.Localization.GetString("Target") + ": " : "")
				+ dataOwner(lng, o[0], o[1], o[2]);

			if (lng)
			{
				s += ", " + pjse.Localization.GetString("bwp_resultIn") + ": ";
				s += pjse.Localization.GetString(
					o[5] == 0 ? "bwp_myArray" : "bwp_stackObjectArray"
				);
				s = s.Replace("[array]", ArrayName(lng, ToShort(o[3], o[4])));
			}

			return s;
#if DISASIM
			// case 0x7D:  // Influence (Uni)
			//     w1 = *(UINT16 *) (&b[x+1]);
			//     w2 = *(UINT16 *) (&b[x+6]);
			//     ht_fprintf(outFile,TYPE_NORMAL,"Follow Sim in ");
			//     data2(b[x],w1);
			//     ht_fprintf(outFile,TYPE_NORMAL,", output result to");
			//     if (b[x+5])
			//         ht_fprintf(outFile,TYPE_NORMAL," stack object's object array: ");
			//     else
			//         ht_fprintf(outFile,TYPE_NORMAL," my object array: ");
			//     if (readString2(gGroup, 0x118, w2) == 0)
			//         ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x118:0x%X]", w2);
			//     break;

#endif
		}
	}

	public class WizPrim0x007e : BhavWizPrim // Lua (disaSim2 24b)
	{
		public WizPrim0x007e(Instruction i)
			: base(i) { }

		protected override string Operands(bool lng)
		{
			byte[] o = new byte[16];
			((byte[])instruction.Operands).CopyTo(o, 0);
			((byte[])instruction.Reserved1).CopyTo(o, 8);

			ushort o4_5 = ToShort(o[4], o[5]);

			string s = "";

			if (lng)
			{
				s += pjse.Localization.GetString("bwp7e_script") + ": ";
			}

			if (ToShort(o[2], o[3]) != 0)
			{
				Scope scope = Scope.Global;
				if ((o4_5 & 0x02) != 0)
				{
					scope = Scope.Private;
				}
				else if ((o4_5 & 0x04) != 0)
				{
					scope = Scope.SemiGlobal;
				}

				s += readStr(
					scope,
					ToShort(o[0], o[1]),
					(ushort)(ToShort(o[2], o[3]) - 1),
					lng ? -1 : 60,
					lng ? Detail.Full : Detail.Errors,
					false
				);

				if ((o4_5 & 0x08) != 0)
				{
					s += lng
						? ", " + pjse.Localization.GetString("manyArgs") + ": "
						: ", ";
					for (int i = 0; i < 3; i++)
					{
						s +=
							(i != 0 ? ", " : "")
							+ dataOwner(lng, o[6 + 3 * i], o[7 + 3 * i], o[8 + 3 * i]);
					}
				}

				if (lng)
				{
					s +=
						", "
						+ pjse.Localization.GetString("bwp7e_type")
						+ ": "
						+ (
							(o4_5 & 0x01) != 0
								? pjse.Localization.GetString("bwp7e_definition")
								: pjse.Localization.GetString("bwp7e_dynamic")
						);
					s +=
						", "
						+ pjse.Localization.GetString("bwp7e_definitionIn")
						+ ": "
						+ (
							((o4_5 & 0x01) != 0)
								? pjse.Localization.GetString("bwp7e_objLuaFile")
								: pjse.Localization.GetString("bwp7e_description")
						);
				}
			}
			else
			{
				s += pjse.Localization.GetString("none");
			}

			return s;
#if DISASIM
			// case 0x7E:  // Lua (NL)
			//     w1 = *(UINT16 *) (&b[x]);   // STR#
			//     w2 = *(UINT16 *) (&b[x+2]); // index + 1
			//     w3 = *(UINT16 *) (&b[x+4]); // flags
			//     w4 = *(UINT16 *) (&b[x+7]);
			//     w5 = *(UINT16 *) (&b[x+10]);
			//     w6 = *(UINT16 *) (&b[x+13]);
			//     if (w2 != 0) {
			//         w2--;
			//         if (w3 & 2) {
			//             ht_fprintf(outFile,TYPE_NORMAL,"Private - \"");
			//             if (readString2(gGroup, w1, w2) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x%X:0x%X]", w1, w2);

			//         } else if (w3 & 4) {
			//             ht_fprintf(outFile,TYPE_NORMAL,"Semi-Global - \"");
			//             if (readString2(gGlobGroup, w1, w2) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x%X:0x%X]", w1, w2);
			//         } else {
			//             ht_fprintf(outFile,TYPE_NORMAL,"Global - \"");
			//             if (readString2(GROUP_GLOBAL, w1, w2) == 0)
			//                 ht_fprintf(outFile,TYPE_NORMAL,"[STR# 0x%X:0x%X]", w1, w2);
			//         }
			//         if (w3 & 1)
			//             ht_fprintf(outFile,TYPE_NORMAL,"\", defined in objLua file");
			//         else
			//             ht_fprintf(outFile,TYPE_NORMAL,"\", defined in description");
			//         if (w3 & 8) {
			//             ht_fprintf(outFile,TYPE_NORMAL,", Passing in params where param 0 = ");
			//             data2(b[x+6],w4);
			//             ht_fprintf(outFile,TYPE_NORMAL,", param 1 = ");
			//             data2(b[x+9],w5);
			//             ht_fprintf(outFile,TYPE_NORMAL,", param 2 = ");
			//             data2(b[x+12],w6);
			//         }

			//     }
			//     break;
#endif
		}
	}
}
