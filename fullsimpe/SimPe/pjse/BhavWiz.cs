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
using System.Collections;
using System.Collections.Generic;

using pjse.BhavNameWizards;

using SimPe.PackedFiles.Wrapper;
using SimPe.Plugin;

using Bhav = SimPe.PackedFiles.Wrapper.Bhav;

namespace pjse
{
	public enum Scope : int
	{
		Global = 0x00,
		SemiGlobal = 0x01,
		Private = 0x02,
	}

	public enum Detail : int
	{
		ValueOnly = 0x00,
		Errors = 0x01,
		ErrorNames = 0x02,
		Normal = 0x03,
		Full = 0x04,
	}

	public enum Group : uint
	{
		Global = 0x7FD46CD0,
		Parsing = 0xFEEDF00D,
	}

	#region Previously known as GlobalStr.cs
	public class GS
	{
		public enum BhavStr : uint
		{
			//Str0x0080 = 0x80, // behavior strings
			GlobalLabels = 0x81, // SimulatorGlobal
			RelativeLocations = 0x0082,
			RelativeDirections = 0x0083,
			DataOwners = 0x84,

			//Str0x0085 - there is no Str0x0085
			Motives = 0x86,

			//Str0x0087 = 0x87, // miscellaneous strings
			Operators = 0x88,

			//Str0x0089 = 0x89, // unused - search types
			//Str0x008a - there is no Str0x008a
			Primitives = 0x8b,

			//Str0x008c - there is no Str0x008c
			DataLabels = 0x8d, // Data labels +EP1 +EP2
			Flags1 = 0x8e, // ObjectData 0x08 - flag field 1
			BodyFlags = 0x8f, // PersonData 0x51 - Body Flags

			//Str0x0090..95 - there are no Str0x0090..95
			//Str0x0096 unused
			//Str0x0097..98 - there are no Str0x0097..98
			ShortOwner = 0x99, // see Find 5 worst motives prim

			//Str0x009a unused
			//Str0x009b unused
			//Str0x009c kill object options
			//Str0x009d tree types
			//Str0x009e .. a3 unused
			NextObject = 0xa4,
			MotiveType = 0xa5, // motive search types

			//Str0x00a6 - there is no Str0x00a6
			CreatePlace = 0xa7, // where to create object
			CreateHow = 0xa8, // how to create object

			//Str0x00a9 unused
			RelVar = 0xaa, // relationship between objects

			//Str0x00ab unused
			//Str0x00ac Interrupt (idle for input?)
			//Str0x00ad .. ae unused
			//Str0x00af - there is no Str0x00af
			//Str0x00b0 0123
			//Str0x00b1 unused
			CensorFlags = 0xb2, // PersonData 0x1e - censorship flags

			//Str0x00b3..c7 - there are no Str0x00b3..c7
			PersonData = 0xc8,
			FunctionTable = 0xc9,
			PlacementFlags = 0xca, // ObjectData 0x2a - placement flags
			MoveFlags = 0xcb, // ObjectData 0x2b - Movement Flags
			OBJDDescs = 0xcc, // Object Definitions
			RoomSortFlags = 0xcd, // ObjectDefinition 0x27 - Room sort flags
			FunctionSortFlags = 0xce, // ObjectDefinition 0x28 - Function sort flags
			SnapType = 0xcf, // How To Snap
			WallAdjFlags = 0xd0, // ObjectData 0x05 - wall adjacency flags 24e

			//Str0x00d1 .. d2 unused
			UpdateWho = 0xd3, // See Refresh prim
			UpdateWhat = 0xd4, // See Refresh prim

			//Str0x00d5 unused
			Flags2 = 0xd6, // ObjectData 0x28 - Flag Field 2

			//Str0x00d7 Routing slot param types (Go To Routing slot - not used here)
			TurnBody = 0xd8,
			Dialog = 0xd9,
			DialogDesc = 0xda,
			RoomValues = 0xdb,
			Generics = 0xdc,
			NeighborData = 0xdd,
			RTBNType = 0xde, // how to call named tree

			//Str0x00df - there is no Str0x00df
			Priorities = 0xe0, // See Push Interaction prim

			//Str0x00e1 times of day
			//Str0x00e2 tree categories
			//Str0x00e3 .. e4 unused
			WallRequirementFlags = 0xe5, // ObjectData 0x0d - Wall/Fence Requirement Flags

			//Str0x00e6 entry types
			//Str0x00e7 unused
			//Str0x00e8 personality ads
			Attenuations = 0xe9,

			//Str0x00ea .. ec unused
			//Str0x00ed dialog behavior (Dialog - not used here)
			//Str0x00ee situation action descriptions
			FindGLB = 0xef, // find good location behaviors
			ExpenseType = 0xf0,

			//Str0x00f1 route results
			//Str0x00f2 add subtract
			JobData = 0xf3, // for Data owner 0x21
			DialogIcon = 0xf4,
			OBJFDescs = 0xf5, // entry points

			//Str0x00f6 object types
			//Str0x00f7 .. f8 unused
			NeighborhoodData = 0xf9, // for Data owner 0x22
			PersonOutfits = 0xfa, // see Change Outfit prim
			ExclPlacementFlags = 0xfb, // ObjectData 0x3f - exclusive placement flags
			InventoryDialog = 0xfc, // for Data owners 0x27 and 0x28
			WallCutoutFlags = 0xfd, // ObjectData 0x45 - wall cutout flags

			//Str0x00fe unused
			SemesterInfoFlags = 0xff, // PersonData 0xad - Semester Info Flags 24e

			//Str0x0100..010d - there are no Str0x0100..010d
			PlacementFlags2 = 0x10e, // ObjectData 0x52 - placement flags 2 24e

			//Str0x010f..01f3 - there are no Str0x010f..01f3
			BuildModeType = 0x10f, // PJSE: ObjectDefinition 0x45 - build mode type
			FuncSort0Flags = 0x110, // PJSE: ObjectDefinition 0x5e - Function Sub-sort, ObjDef 0x28 bit 1 set
			FuncSort1Flags = 0x111, // ..
			FuncSort2Flags = 0x112, // ..
			FuncSort3Flags = 0x113, // ..
			FuncSort4Flags = 0x114, // ..
			FuncSort5Flags = 0x115, // ..
			FuncSort6Flags = 0x116, // ..
			FuncSort7Flags = 0x117, // ..
			FuncSort8Flags = 0x118, // ..
			FuncSort9Flags = 0x119, // ..
			FuncSortAFlags = 0x11a, // ..
			FuncSortBFlags = 0x11b, // ..
			FuncSortCFlags = 0x11c, // ..
			FuncSortDFlags = 0x11d, // ..
			FuncSortEFlags = 0x11e, // ..
			FuncSortFFlags = 0x11f, // PJSE: ObjectDefinition 0x5e - Function Sub-sort, ObjDef 0x28 bit 16 set
			BuildModeSort0Flags = 0x120, // PJSE: ObjectDefinition 0x4a - Build Mode Sub-sort, ObjDef 0x45 bit 1 set
			BuildModeSort1Flags = 0x121, // ..
			BuildModeSort2Flags = 0x122, // ..
			BuildModeSort3Flags = 0x123, // ..
			BuildModeSort4Flags = 0x124, // ..
			BuildModeSort5Flags = 0x125, // ..
			BuildModeSort6Flags = 0x126, // ..
			BuildModeSort7Flags = 0x127, // ..
			BuildModeSort8Flags = 0x128, // ..
			BuildModeSort9Flags = 0x129, // ..
			BuildModeSortAFlags = 0x12a, // ..
			BuildModeSortBFlags = 0x12b, // ..
			BuildModeSortCFlags = 0x12c, // ..
			BuildModeSortDFlags = 0x12d, // ..
			BuildModeSortEFlags = 0x12e, // ..
			BuildModeSortFFlags = 0x12f, // PJSE: ObjectDefinition 0x4a - Build Mode Sub-sort, ObjDef 0x45 bit 16 set
			ValidEPFlags1 = 0x130, // PJSE: ObjectDefinition 0x40 - valid EP flags 1
			ValidEPFlags2 = 0x131, // PJSE: ObjectDefinition 0x41 - valid EP flags 2
			GameEditionFlags2 = 0x132, // PJSE: SimulatorGlobals 0x3a - game edition flags 2

			//Str0x0133..1dd unused
			CommunitySortFlags = 0x1dd, // PJSE: ObjectDefinition 0x64 - Community Lot Sort Flags
			AttractionFlags3 = 0x1de, // PJSE: PersonData Attraction Flags3 - 0xc9, 0xca, 0xcb
			AttractionFlags2 = 0x1df, // PJSE: PersonData Attraction Flags2 - 0xb5, 0xb7, 0xb9
			AttractionFlags1 = 0x1e0, // PJSE: PersonData Attraction Flags1 - 0xb4, 0xb6, 0xb8
			GameEditionFlags = 0x1e1, // PJSE: SimulatorGlobals 0x14 - game edition flags
			AllowedHeightFlags = 0x1e2, // PJSE: ObjectData 0x04 - allowed height flags
			UnknownFlags = 0x1e3, // PJSE: string number stolen (for flag fields with unknown flag labels)
			TokenOpsCounted = 0x1e4, // PJSE: string number stolen (opcode 0x33)
			TokenOpsSingular = 0x1e5, // PJSE: string number stolen (opcode 0x33)
			Languages = 0x1e6, // PJSE: string number stolen
			PetDecayIndices = 0x1e7, // PJSE: string number stolen (unused)
			SpeciesValues = 0x1e8, // PJSE: PersonData 0xba - Species Values (unused)
			PetTraitFlags = 0x1e9, // PJSE: PersonData 0xc7 - Pet Trait Flags
			TTABAges = 0x1ea, // PJSE: string number stolen
			DebugType = 0x1eb, // PJSE: string number stolen
			EffectSSType = 0x1ec, // PJSE: string number stolen
			StopAnimType = 0x1ed, // PJSE: string number stolen
			TokenType = 0x1ee, // PJSE: string number stolen
			InventoryType = 0x1ef, // PJSE: string number stolen
			UIEffectType = 0x1f0, // PJSE: string number stolen
			FuncLocationFlags = 0x1f1, // PJSE: string number stolen
			GenericsDesc = 0x1f2, // PJSE: string number stolen
			TnsStyle = 0x1f3, // PJSE: string number stolen
			AgePrimAges = 0x1f4, // PJSE: string number stolen

			//Str0x01f5 .. 1fd unused
			GosubAction = 0x1fe, // See Gosub Action prim

			//Str0x01ff Routing slot directions
			HiddenFlags = 0x200, // ObjectData 0x22 - Hidden Flags
			GhostFlags = 0x201, // PersonData 0x44 - Ghost Flags
			SelectionFlags = 0x202, // PersonData 0x9e - Sim Selectable Flags

			//Str0x0203 unused
			PersonFlags2 = 0x204, // PersonData 0x9f - Person Flags
			Flags3 = 0x205, // ObjectData 0x62 - Flag Field 3
			PersonFlags1 = 0x206, // PersonData 0x54 - Person Flags 1
		}

		public enum GlobalStr : uint
		{
			//Slots = 0x0080, // one occurrance in objects.package(7F029114)
			AdultAnims = 0x0081,
			ChildAnims = 0x0082,
			SocialAnims = 0x0083,
			LocoAnims = 0x0084,
			ObjectName3D = 0x0085, // no Global ones
			ObjectAnims = 0x0086, // "Adult" = default
			MeshGroup = 0x0087,
			MaterialName = 0x0088,
			ToddlerAnims = 0x0089,
			TeenAnims = 0x008a,
			ElderAnims = 0x008b,
			CatAnims = 0x008c,
			DogAnims = 0x008d,
			LightSource = 0x008e,
			Effect = 0x008f,
			Bones = 0x0090, // no Global ones
			BabyAnims = 0x0091,
			ReachAnims = 0x0092,
			CareerLevels = 0x0093, // no Global ones - and some other random-ish stuff, too
			SoundInfo = 0x0094, // no Global ones
			IconTexture = 0x0095, // Balloon Icon Texture Names
			UIEffect = 0x0096,
			CineCam = 0x0097,
			CannotPlace = 0x0098, // See 7FA815EA and 7F12A804
			PuppyAnims = 0x0099,
			KittenAnims = 0x009a,
			SmallDogAnims = 0x009b, //EP4(Pets)
			ElderLargeDogAnims = 0x009c, // no Global ones
			ElderSmallDogAnims = 0x009d, // no Global ones
			ElderCatAnims = 0x009e, // no Global ones

			//no 0x009F..0x00C7
			MaleBody = 0x00C8, // no Global ones
			FemaleBody = 0x00C9, // no Global ones

			//no 0x00CA..0x00FF
			AttributeLabels = 0x0100,

			//no 0x0101
			Relationship = 0x0102,

			//no 0x0103..0x117
			ArrayName = 0x0118,

			//no 0x119..0x012c
			DialogString = 0x012d,
			MakeAction = 0x012e,
			NamedTree = 0x012f,
			LuaScript = 0x0130,
			PipMessages = 0x0131,
			DebugString = 0x0132,
			LuaProperty = 0x0133,

			//no 0x0134..0x018f
			ObjectElderAnims = 0x0190, // no Global ones
			ObjectTeenAnims = 0x0191, // no Global ones
			ObjectChildAnims = 0x0192,
			ObjectToddlerAnims = 0x0193, // no Global ones

			//no 0x0194
			ObjectLargeDogAnims = 0x0195, // no Global ones
			ObjectCatAnims = 0x0196, // no Global ones
			ObjectPuppyAnims = 0x0197, // no Global ones
			ObjectKittenAnims = 0x0198, // no Global ones
			ObjectSmallDogAnims = 0x0199, // no Global ones

			//no 0x019A..0x0225
			ElderHappyCurve = 0x0226,
			AdultHappyCurve = 0x0227,
			TeenHappyCurve = 0x0228,
			ChildHappyCurve = 0x0229,
			ToddlerHappyCurve = 0x022A,
			BabyHappyCurve = 0x022B,
			ElderLargeDogHappyCurve = 0x022C,
			AdultLargeDogHappyCurve = 0x022D,
			ElderSmallDogHappyCurve = 0x022E,
			AdultSmallDogHappyCurve = 0x022F,
			PuppieHappyCurve = 0x0230,
			ElderCatHappyCurve = 0x0231,
			AdultCatHappyCurve = 0x0232,
			KittenHappyCurve = 0x0233,

			//no 0x0234..0x0289
			ElderInteractionCurve = 0x028A,
			AdultInteractionCurve = 0x028B,
			TeenInteractionCurve = 0x028C,
			ChildInteractionCurve = 0x028D,
			ToddlerInteractionCurve = 0x028E,
			BabyInteractionCurve = 0x028F,
			ElderLargeDogInteractionCurve = 0x0290,
			AdultLargeDogInteractionCurve = 0x0291,
			ElderSmallDogInteractionCurve = 0x0292,
			AdultSmallDogInteractionCurve = 0x0293,
			PuppieInteractionCurve = 0x0294,
			ElderCatInteractionCurve = 0x0295,
			AdultCatInteractionCurve = 0x0296,
			KittenInteractionCurve = 0x0297,

			//no 0x0298..0x02B1
			SnapFailure = 0x02B2,
			RouteFailure = 0x02B3,

			//no 0x02B4..0x02BB
			EnvironmentScoreCurve = 0x02BC,
			HairOverrides = 0x3039,
			Sound = 0x4132,
		}
	}
	#endregion

	/// <summary>
	/// Abstract wrapper that extends the SimPe Bhav Instruction class for display purposes
	/// </summary>
	/// <remarks>Remember - an Instruction() is the call to a primitive or BHAV...</remarks>
	public abstract class BhavWiz : IDisposable
	{
		protected Instruction instruction = null;
		protected string prefix = null;

		protected BhavWiz(Instruction instruction)
		{
			this.instruction = instruction;
		}

		public static implicit operator BhavWiz(Instruction i)
		{
			return i.OpCode < 0x0100 ? (BhavWizPrim)i : (BhavWiz)(BhavWizBhav)i;
		}

		public static implicit operator Instruction(BhavWiz b)
		{
			return b.instruction;
		}

		#region IDisposable Members
		public void Dispose()
		{
			instruction = null;
		}

		#endregion

		public Instruction Instruction => instruction;

		public override string ToString()
		{
			return LongName;
		}

		public virtual string ShortName => Name + " (" + Operands(false) + ")";

		public virtual string LongName => Name + " (" + Operands(true) + ")";

		public virtual ABhavOperandWiz Wizard()
		{
			return null;
		}

		protected virtual string Name => "["
					+ Prefix
					+ " 0x"
					+ SimPe.Helper.HexString(instruction.OpCode)
					+ "] "
					+ OpcodeName;

		protected virtual string Prefix => prefix;

		protected abstract string OpcodeName
		{
			get;
		}

		protected abstract string Operands(bool lng);

		#region Utilities

		#region DataOwner routines
		public static String DoidName(byte doid)
		{
			return readStr(GS.BhavStr.DataOwners, doid);
		}

		public static String dnTemp()
		{
			return DoidName(0x08);
		}

		public static String dnParam()
		{
			return DoidName(0x09);
		}

		public static String dnLocal()
		{
			return DoidName(0x19);
		}

		public static String dnConst()
		{
			return DoidName(0x1a);
		}

		public static String dnStkOb()
		{
			return Localization.GetString("stackobj");
		}

		public static String dnMe()
		{
			return Localization.GetString("me");
		}

		public static String dnNeigh()
		{
			return Localization.GetString("neigh");
		}

		protected string dataOwner(byte doid, ushort instance)
		{
			ushort[] bcon;
			string doidName = DoidName(doid);

			string s = "0x" + SimPe.Helper.HexString(instance);
			string temp = "";

			if (doidGStr[doid] != null)
			{
				s += " (" + readStr((GS.BhavStr)doidGStr[doid], instance) + ")";
			}

			switch (doid)
			{
				case 0x00:
				case 0x01:
					temp = readStr(
						new Str(
							Scope.Private,
							instruction.Parent,
							(uint)GS.GlobalStr.AttributeLabels,
							false
						),
						instance,
						-1,
						Detail.ValueOnly,
						true,
						false
					);
					if (temp != null && temp.Length > 0)
					{
						s += " (" + temp + ")";
					}

					break;
				case 0x02:
				case 0x05:
					temp = readStr(
						new Str(
							Scope.SemiGlobal,
							instruction.Parent,
							(uint)GS.GlobalStr.AttributeLabels,
							false
						),
						instance,
						-1,
						Detail.ValueOnly,
						true,
						false
					);
					if (temp != null && temp.Length > 0)
					{
						s += " (" + temp + ")";
					}

					break;
				case 0x09:
				case 0x19:
					temp =
						doid == 0x09
							? readParam(
								instruction.Parent,
								instance,
								Detail.Errors
							)
							: readLocal(
								instruction.Parent,
								instance,
								Detail.Errors
							);
					if (temp.Length > 0)
					{
						s += " (" + temp + ")";
					}

					break;
				case 0x0b:
				case 0x11:
				case 0x1e:
				case 0x1f:
				case 0x30:
				case 0x31:
					doidName = doidName.Replace(
						"[temp]",
						"[" + dataOwner(0x08, instance) + "]"
					);
					s = "";
					break;
				case 0x16:
				case 0x32:
					doidName = doidName.Replace(
						"[param]",
						"[" + dataOwner(0x09, instance) + "]"
					);
					s = "";
					break;
				case 0x1a:
					bcon = ExpandBCON(instance, false);
					s =
						"0x"
						+ SimPe.Helper.HexString(bcon[0])
						+ ":0x"
						+ SimPe.Helper.HexString((byte)bcon[1]);
					temp = readBcon(bcon[0], bcon[1], false);
					if (temp.Length > 0)
					{
						s += " (" + temp + ")";
					}

					break;
				case 0x29:
				case 0x2a:
				case 0x2b:
				case 0x2c:
				case 0x2d:
				case 0x2e:
					doidName = doidName.Replace("[array]", ArrayName(true, instance));
					s = "";
					break;
				case 0x2f:
					doidName = dnConst();
					bcon = ExpandBCON(instance, true);
					s =
						"0x"
						+ SimPe.Helper.HexString(bcon[0])
						+ ":["
						+ dataOwner(0x08, bcon[1])
						+ "]";
					temp = readBcon(bcon[0], bcon[1], true);
					if (temp.Length > 0)
					{
						s += " (" + temp + ")";
					}

					break;
			}

			return doidName + (s.Length > 0 ? " " + s : "");
		}

		protected string dataOwner(byte doid, byte lo, byte hi)
		{
			return dataOwner(doid, ToShort(lo, hi));
		}

		protected string dataOwner(bool lng, byte doid, ushort instance)
		{
			if (lng)
			{
				return dataOwner(doid, instance);
			}

			ushort[] bcon;
			switch (doid)
			{
				case 0x03:
				case 0x0c:
				case 0x0e:
				case 0x0f:
				case 0x17:
				case 0x18:
				case 0x1c:
				case 0x1d:
				case 0x21:
				case 0x22:
				case 0x23:
				case 0x33:
					return DoidName(doid)
						+ " "
						+ readStr((GS.BhavStr)doidGStr[doid], instance);
				case 0x04:
					if (instance == 0x0b)
					{
						return DoidName(0x0a);
					}

					return DoidName(doid)
						+ " "
						+ readStr((GS.BhavStr)doidGStr[doid], instance);
				case 0x06:
					return readStr((GS.BhavStr)doidGStr[doid], instance);
				case 0x0a:
					return DoidName(doid)
						+ (
							instance == 0x00
								? ""
								: " 0x" + SimPe.Helper.HexString(instance)
						);
				case 0x0b:
				case 0x11:
				case 0x1e:
				case 0x1f:
				case 0x30:
				case 0x31:
					return dataOwner(doid, instance);
				case 0x12:
					return DoidName(0x03)
						+ " "
						+ readStr((GS.BhavStr)doidGStr[doid], instance);
				case 0x13:
				case 0x15:
					return DoidName(0x04)
						+ " "
						+ readStr((GS.BhavStr)doidGStr[doid], instance);
				case 0x16:
				case 0x32:
					return DoidName(doid)
						.Replace(
							"[param]",
							"["
								+ dnParam()
								+ " 0x"
								+ SimPe.Helper.HexString(instance)
								+ "]"
						);
				case 0x1a:
					bcon = ExpandBCON(instance, false);
					return dnConst()
						+ " 0x"
						+ SimPe.Helper.HexString(bcon[0])
						+ ":0x"
						+ SimPe.Helper.HexString((byte)bcon[1]);
				case 0x20:
				case 0x26:
					return dnNeigh()
						+ " "
						+ readStr((GS.BhavStr)doidGStr[doid], instance);
				case 0x29:
				case 0x2a:
				case 0x2b:
				case 0x2c:
				case 0x2d:
				case 0x2e:
					return DoidName(doid)
						.Replace(
							"[array]",
							"[0x" + SimPe.Helper.HexString(instance) + "]"
						);
				case 0x2f:
					bcon = ExpandBCON(instance, true);
					return dnConst()
						+ " 0x"
						+ SimPe.Helper.HexString(bcon[0])
						+ ":["
						+ dataOwner(0x08, bcon[1])
						+ "]";
			}
			return DoidName(doid) + " 0x" + SimPe.Helper.HexString(instance);
		}

		protected string dataOwner(bool lng, byte doid, byte lo, byte hi)
		{
			return dataOwner(lng, doid, ToShort(lo, hi));
		}

		public static Hashtable doidGStr = staticInitialiser();

		private static Hashtable staticInitialiser()
		{
			Hashtable t = new Hashtable
			{
				{ (byte)0x03, GS.BhavStr.DataLabels },
				{ (byte)0x04, GS.BhavStr.DataLabels },
				{ (byte)0x06, GS.BhavStr.GlobalLabels },
				{ (byte)0x0c, GS.BhavStr.Motives },
				{ (byte)0x0e, GS.BhavStr.Motives },
				{ (byte)0x0f, GS.BhavStr.Motives },
				{ (byte)0x1c, GS.BhavStr.Motives },
				{ (byte)0x1d, GS.BhavStr.Motives },
				{ (byte)0x12, GS.BhavStr.PersonData },
				{ (byte)0x13, GS.BhavStr.PersonData },
				{ (byte)0x20, GS.BhavStr.PersonData },
				{ (byte)0x15, GS.BhavStr.OBJDDescs },
				{ (byte)0x26, GS.BhavStr.OBJDDescs },
				{ (byte)0x33, GS.BhavStr.OBJDDescs },
				{ (byte)0x17, GS.BhavStr.RoomValues },
				{ (byte)0x18, GS.BhavStr.NeighborData },
				{ (byte)0x21, GS.BhavStr.JobData },
				{ (byte)0x22, GS.BhavStr.NeighborhoodData },
				{ (byte)0x23, GS.BhavStr.OBJFDescs },
				{ (byte)0x27, GS.BhavStr.InventoryDialog },
				{ (byte)0x28, GS.BhavStr.InventoryDialog }
			};
			return t;
		}
		// for Data Owners 0x12, 0x13, 0x20:
		// o.Add((ushort)0xba, GS.BhavStr.SpeciesValues);


		#endregion


		#region STR# routines
		public string readStr(
			GS.GlobalStr instance,
			ushort sid,
			int maxlen,
			Detail detail
		)
		{
			return readStr(Scope.Private, (uint)instance, sid, maxlen, detail, false);
		}

		public string readStr(
			Scope scope,
			GS.GlobalStr instance,
			ushort sid,
			int maxlen,
			Detail detail
		)
		{
			return readStr(scope, (uint)instance, sid, maxlen, detail, false);
		}

		protected string readStr(
			Scope scope,
			uint instance,
			ushort sid,
			int maxlen,
			Detail detail,
			bool showLngFB
		)
		{
			return readStr(
				new Str(scope, instruction.Parent, instance),
				sid,
				maxlen,
				detail,
				true,
				showLngFB
			);
		}

		public static string readStr(GS.BhavStr instance, ushort sid)
		{
			return readStr(new Str(instance), sid, -1, Detail.ErrorNames, false, false);
		}

		private static string readStr(
			Str str,
			ushort sid,
			int maxlen,
			Detail detail,
			bool addQuotes,
			bool showLngFB
		)
		{
			String pfname = "";
			if (detail != Detail.ValueOnly)
			{
				if (detail != Detail.Errors)
				{
					if (str.Group == (uint)Group.Parsing)
					{
						try
						{
							if (
								((GS.BhavStr)str.Instance).ToString()
								!= str.Instance.ToString()
							)
							{
								pfname += (GS.BhavStr)str.Instance;
							}
							else
							{
								pfname +=
									"["
									+ Localization.GetString("unk")
									+ ": 0x"
									+ SimPe.Helper.HexString(str.Instance)
									+ "]";
							}
						}
						catch { }
					}
					else
					{
						try
						{
							if (
								((GS.GlobalStr)str.Instance).ToString()
								!= str.Instance.ToString()
							)
							{
								pfname += (GS.GlobalStr)str.Instance;
							}
						}
						catch { }
					}
				}
				if (pfname.Length == 0 && detail != Detail.Normal)
				{
					pfname +=
						"STR# 0x"
						+ (
							str.Instance >= 0x10000
								? SimPe.Helper.HexString(str.Instance)
								: SimPe.Helper.HexString((ushort)str.Instance)
						);
				}

				if (pfname.Length != 0)
				{
					pfname += ":";
				}

				pfname +=
					"0x"
					+ (
						sid >= 0x0100
							? SimPe.Helper.HexString(sid)
							: SimPe.Helper.HexString((byte)sid)
					);
				if (detail == Detail.Full || detail == Detail.Normal)
				{
					pfname +=
						" (" + Localization.GetString(str.Scope.ToString()) + ")";
				}
			}

			if (str != null)
			{
				FallbackStrItem fsi = str[
					(byte)SimPe.Helper.WindowsRegistry.LanguageCode,
					sid
				];
				if (fsi != null)
				{
					String s = "";
					if (
						detail != Detail.ValueOnly
						&& fsi.fallback != null
						&& fsi.fallback.Count != 0
					)
					{
						s += "[";
						for (int i = 0; i < fsi.fallback.Count; i++)
						{
							s += (i == 0 ? "" : "; ") + fsi.fallback[i];
						}

						s += "] ";
					}
					if (fsi.strItem != null)
					{
						if (showLngFB && (s.Length == 0) && fsi.lidFallback)
						{
							s +=
								"["
								+ Localization.GetString("Fallback")
								+ ": LID=1] ";
						}

						return addQuotes
							? s
								+ "\""
								+ myLeft(fsi.strItem.Title.Trim(), maxlen)
								+ "\""
								+ (
									detail == Detail.Full || detail == Detail.Normal
										? " [" + pfname + "]"
										: ""
								)
							: s
								+ myLeft(fsi.strItem.Title.Trim(), maxlen)
								+ (
									detail == Detail.Full || detail == Detail.Normal
										? " [" + pfname + "]"
										: ""
								);
					}
					else
					{
						return (detail == Detail.ValueOnly) ? null : s + pfname;
					}
				}
			}
			return detail == Detail.ValueOnly ? null : "[" + Localization.GetString("unk") + ": " + pfname + "]";
		}

		private static Dictionary<GS.BhavStr, List<String>> gString = null;
		private static Dictionary<GS.BhavStr, List<String>> GString
		{
			get
			{
				if (gString == null && FileTable.GFT != null)
				{
					FileTable.GFT.FiletableRefresh -= new EventHandler(
						GFT_FiletableRefresh
					);
					gString = new Dictionary<GS.BhavStr, List<String>>();
					FileTable.GFT.FiletableRefresh += new EventHandler(
						GFT_FiletableRefresh
					);
				}
				return gString;
			}
		}

		static void GFT_FiletableRefresh(object sender, EventArgs e)
		{
			gString = new Dictionary<GS.BhavStr, List<String>>();
		}

		public static List<String> readStr(GS.BhavStr instance)
		{
			if (GString == null)
			{
				return new List<String>();
			}

			if (!GString.ContainsKey(instance))
			{
				List<String> list = new List<String>();
				String s;
				Str str = new Str(instance);
				for (
					ushort i = 0;
					(s = readStr(str, i, -1, Detail.ValueOnly, false, false)) != null;
					i++
				)
				{
					list.Add(s);
				}

				GString.Add(instance, list);
			}
			return GString[instance];
		}

		private List<String> readStr(Scope s, GS.GlobalStr instance)
		{
			if (
				instruction == null
				|| instruction.Parent == null
				|| instruction.Parent.FileDescriptor == null
			)
			{
				throw new InvalidOperationException(
					"Can't read STR# for instruction with no parent"
				);
			}

			if (
				instruction.Parent.Context == Scope.Global && s != Scope.Global
				|| instruction.Parent.Context == Scope.SemiGlobal && s == Scope.Private
			)
			{
				return null;
			}

			List<String> al = new List<String>();
			Str str = new Str(s, instruction.Parent, (uint)instance);
			int n = (str == null) ? 0 : str[(byte)1].Count;
			String st;
			for (ushort i = 0; i < n; i++)
			{
				al.Add(
					(st = readStr(str, i, -1, Detail.ValueOnly, false, false)) == null
						? ""
						: st
				);
			}

			return al;
		}

		public List<String> GetAttrNames(Scope s)
		{
			return readStr(s, GS.GlobalStr.AttributeLabels);
		}

		public List<String> GetArrayNames()
		{
			return readStr(Scope.Private, GS.GlobalStr.ArrayName);
		}

		public String ArrayName(bool lng, ushort instance)
		{
			string s = "0x" + SimPe.Helper.HexString(instance);
			if (lng)
			{
				string temp = readStr(
					GS.GlobalStr.ArrayName,
					instance,
					lng ? -1 : 60,
					Detail.ValueOnly
				);
				if (temp != null && temp.Length > 0)
				{
					s += " (" + temp + ")";
				}
			}
			return s;
		}

		private static string myLeft(string str, int len)
		{
			return (len < 0)
				? str
				: str.PadRight(len).Substring(0, len).Trim()
					+ (str.Length > len ? "..." : "");
		}
		#endregion


		#region Flag parsing
		public static List<String> flagNames(byte flagOwner, ushort flagType)
		{
			Hashtable flagTypes = (Hashtable)flagOwners[flagOwner];
			return (flagTypes == null || flagTypes[flagType] == null)
				? null
				: readStr((GS.BhavStr)flagTypes[flagType]);
		}

		public static string flagname(byte flagOwner, ushort flagType, ushort flagValue)
		{
			if (flagValue == 0)
			{
				return "[0: " + Localization.GetString("invalid") + "]";
			}

			Hashtable flagTypes = (Hashtable)flagOwners[flagOwner];
			return (flagTypes == null || flagTypes[flagType] == null)
				? null
				: readStr((GS.BhavStr)flagTypes[flagType], (ushort)(flagValue - 1));
		}

		private static Hashtable flagOwners = flagInitaliser();

		private static Hashtable flagInitaliser()
		{
			Hashtable f = new Hashtable();

			// ObjectData flags
			Hashtable o = new Hashtable
			{
				{ (ushort)0x04, GS.BhavStr.AllowedHeightFlags }, // allowed height flags
				{ (ushort)0x05, GS.BhavStr.WallAdjFlags },
				{ (ushort)0x08, GS.BhavStr.Flags1 },
				{ (ushort)0x0d, GS.BhavStr.WallRequirementFlags },
				{ (ushort)0x16, GS.BhavStr.UnknownFlags }, // Door route blocker flags
				{ (ushort)0x22, GS.BhavStr.HiddenFlags },
				{ (ushort)0x28, GS.BhavStr.Flags2 },
				{ (ushort)0x2a, GS.BhavStr.PlacementFlags },
				{ (ushort)0x2b, GS.BhavStr.MoveFlags },
				{ (ushort)0x3f, GS.BhavStr.ExclPlacementFlags },
				{ (ushort)0x45, GS.BhavStr.WallCutoutFlags },
				{ (ushort)0x47, GS.BhavStr.UnknownFlags }, // Render Flags
				{ (ushort)0x52, GS.BhavStr.PlacementFlags2 },
				{ (ushort)0x62, GS.BhavStr.Flags3 },
				{ (ushort)0x65, GS.BhavStr.UnknownFlags }, // UI Icon Flags
				{ (ushort)0x67, GS.BhavStr.UnknownFlags }, // Invisible wall placement flags
				{ (ushort)0x6a, GS.BhavStr.UnknownFlags } // For Sale Flags
			};
			f.Add((byte)0x03, o); // 0x03 "My"
			f.Add((byte)0x04, o); // 0x04 "Stack Object's"

			// PersonData flags
			o = new Hashtable
			{
				{ (ushort)0x13, GS.BhavStr.UnknownFlags }, // Group Talk State Flags
				{ (ushort)0x1e, GS.BhavStr.CensorFlags },
				{ (ushort)0x34, GS.BhavStr.UnknownFlags }, // Sim UI Icon Flags
				{ (ushort)0x44, GS.BhavStr.GhostFlags },
				{ (ushort)0x4a, GS.BhavStr.UnknownFlags }, // Render Display Flags
				{ (ushort)0x51, GS.BhavStr.BodyFlags },
				{ (ushort)0x54, GS.BhavStr.PersonFlags1 },
				{ (ushort)0x9e, GS.BhavStr.SelectionFlags },
				{ (ushort)0x9f, GS.BhavStr.PersonFlags2 },
				{ (ushort)0xad, GS.BhavStr.SemesterInfoFlags },
				{ (ushort)0xb4, GS.BhavStr.AttractionFlags1 }, // Traits1
				{ (ushort)0xb5, GS.BhavStr.AttractionFlags2 }, // Traits2
				{ (ushort)0xb6, GS.BhavStr.AttractionFlags1 }, // TurnOns1
				{ (ushort)0xb7, GS.BhavStr.AttractionFlags2 }, // TurnOns2
				{ (ushort)0xb8, GS.BhavStr.AttractionFlags1 }, // TurnOffs1
				{ (ushort)0xb9, GS.BhavStr.AttractionFlags2 }, // TurnOffs2
				{ (ushort)0xc7, GS.BhavStr.PetTraitFlags },
				{ (ushort)0xc9, GS.BhavStr.AttractionFlags3 }, // Traits3
				{ (ushort)0xca, GS.BhavStr.AttractionFlags3 }, // TurnOns3
				{ (ushort)0xcb, GS.BhavStr.AttractionFlags3 } // TurnOffs3
			};
			f.Add((byte)0x12, o); // 0x12 "My Person Data"
			f.Add((byte)0x13, o); // 0x13 "Stack Object's Person Data"
			f.Add((byte)0x20, o); // 0x20 "Neighbour's Person Data"

			// ObjectDefinition flags
			o = new Hashtable
			{
				{ (ushort)0x03, GS.BhavStr.WallAdjFlags }, // Default Wall Adjacent Flags (guess same as WallAdjFlags)
				{ (ushort)0x04, GS.BhavStr.PlacementFlags }, // Default Placement Flags (guess same as PlacementFlags)
				{ (ushort)0x05, GS.BhavStr.WallRequirementFlags }, // Default Wall Placement Flags (guess same as WallPlacementFlags)
				{ (ushort)0x06, GS.BhavStr.UnknownFlags }, // Default Allowed Height Flags
				{ (ushort)0x11, GS.BhavStr.UnknownFlags }, // Catalog Use Flags
				{ (ushort)0x19, GS.BhavStr.UnknownFlags }, // Object ownership flags
				{ (ushort)0x20, GS.BhavStr.UnknownFlags }, // Aspiration Flags
				{ (ushort)0x27, GS.BhavStr.RoomSortFlags },
				{ (ushort)0x28, GS.BhavStr.FunctionSortFlags },
				{ (ushort)0x3c, GS.BhavStr.UnknownFlags }, // For Sale Flags
				{ (ushort)0x40, GS.BhavStr.ValidEPFlags1 }, // Valid EPs 1 bit field
				{ (ushort)0x41, GS.BhavStr.ValidEPFlags2 }, // Valid EPs 2 bit field
				{ (ushort)0x42, GS.BhavStr.UnknownFlags }, // chair entry flags
				{ (ushort)0x45, GS.BhavStr.BuildModeType },
				{ (ushort)0x4a, GS.BhavStr.UnknownFlags }, // Build Sub-sort flags (depends on ObjDef 0x45)
				{ (ushort)0x59, GS.BhavStr.UnknownFlags }, // ratingSkillFlags
				{ (ushort)0x5b, GS.BhavStr.CommunitySortFlags },
				{ (ushort)0x5e, GS.BhavStr.UnknownFlags }, // Function Sub-sort flags (depends on ObjDef 0x28)
				{ (ushort)0x64, GS.BhavStr.UnknownFlags } // misc flags
			};
			f.Add((byte)0x15, o); // 0x15 "stack object's definition"
			f.Add((byte)0x26, o); // 0x26 "Neighbor's Object Definition"
			f.Add((byte)0x33, o); // 0x33 "Stack Object's Master Definition"

			// SimulatorGlobal flags
			o = new Hashtable
			{
				{ (ushort)0x14, GS.BhavStr.GameEditionFlags }, // Game edition flags
				{ (ushort)0x19, GS.BhavStr.UnknownFlags }, // Debug flags
				{ (ushort)0x21, GS.BhavStr.UnknownFlags }, // Demo flags
				{ (ushort)0x25, GS.BhavStr.UnknownFlags }, // Utility available flags
				{ (ushort)0x33, GS.BhavStr.UnknownFlags }, // Object error flags
				{ (ushort)0x35, GS.BhavStr.UnknownFlags }, // Instant write once flags
				{ (ushort)0x3a, GS.BhavStr.GameEditionFlags2 } // Game edition flags 2
			};
			f.Add((byte)0x06, o); // 0x81 "Global"

			return f;
		}
		#endregion


		#region BHAV and TPRP routines
		/// <summary>
		/// Returns the name of a BHAV or Primitive for a given instance number.
		/// <br/>
		/// Scope etc are taken from the provided ExtendedWrapper.
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="instance">Which BHAV to find</param>
		/// <param name="found">Indicates that a BHAV was found</param>
		/// <returns>Name of BHAV found</returns>
		public static String bhavName(
			ExtendedWrapper parent,
			uint instance,
			ref bool found
		)
		{
			found = false;
			string s = "0x" + SimPe.Helper.HexString((ushort)instance) + ": ";

			if (instance == 0)
			{
				return "---";
			}
			else if (instance < 0x0100)
			{
				return s + readStr(GS.BhavStr.Primitives, (ushort)instance);
			}

			FileTable.Entry ftEntry = parent.ResourceByInstance(
				SimPe.Data.MetaData.BHAV_FILE,
				instance
			);
			found = ftEntry != null;
			return s
				+ (
					found
						? "\"" + ftEntry + "\""
						: Localization.GetString("bhavnotfound")
				);
		}

		public String bhavName(uint instance, ref bool found)
		{
			return bhavName(instruction.Parent, instance, ref found);
		}

		protected string readParam(Bhav instance, int pno, Detail detail)
		{
			return readParamLocal(false, instance, pno, detail);
		}

		protected string readLocal(Bhav instance, int lno, Detail detail)
		{
			return readParamLocal(true, instance, lno, detail);
		}

		private string readParamLocal(bool local, Bhav bhav, int sid, Detail detail)
		{
			TPRP tprp = (TPRP)bhav.SiblingResource(TPRP.TPRPtype);
			return (
				tprp != null
				&& !tprp.TextOnly
				&& sid < (local ? tprp.LocalCount : tprp.ParamCount)
			)
				? tprp[local, sid]
				: ""
			/*(detail == Detail.ValueOnly ? ""
			: "[No TPRP label for BHAV 0x" + SimPe.Helper.HexString((ushort)bhav.FileDescriptor.Instance)
			+ " " + (local ? "Local" : "Param") + " 0x" + SimPe.Helper.HexString((ushort)sid) + "]")*/
			;
		}

		/// <summary>
		/// Returns a list of Param or Local labels
		/// </summary>
		/// <param name="local">True to retrieve Local labels, false for Params</param>
		/// <returns></returns>
		public List<String> GetTPRPnames(bool local)
		{
			if (
				instruction == null
				|| instruction.Parent == null
				|| instruction.Parent.FileDescriptor == null
			)
			{
				throw new InvalidOperationException(
					"Can't read TPRP for instruction with no parent"
				);
			}

			uint group = instruction.Parent.FileDescriptor.Group;
			uint instance = instruction.Parent.FileDescriptor.Instance;
			FileTable.Entry[] items = FileTable.GFT[
				0x54505250,
				group,
				instance
			];

			if (items == null || items.Length == 0)
			{
				return null;
			}

			List<String> TPRPnames = new List<String>();

			TPRP tprp = new TPRP();
			tprp.ProcessData(items[0].PFD, items[0].Package);
			foreach (TPRPItem i in tprp)
			{
				if ((local && i is TPRPLocalLabel) || (!local && i is TPRPParamLabel))
				{
					TPRPnames.Add(i.Label);
				}
			}

			int limit = local
				? instruction.Parent.Header.LocalVarCount
				: instruction.Parent.Header.ArgumentCount;
			while (TPRPnames.Count < limit)
			{
				TPRPnames.Add(
					"("
						+ (local ? dnLocal() : dnParam())
						+ TPRPnames.Count.ToString()
						+ ")"
				);
			}

			return TPRPnames;
		}
		#endregion


		protected static string Slot(byte t, byte s)
		{
			string f = "";
			switch (t)
			{
				case 0:
					f += Localization.GetString("bw_defHeight");
					break;
				case 1:
					f += Localization.GetString("bw_targetingSlot");
					break;
				case 2:
					f += Localization.GetString("bw_routingSlot");
					break;
				case 3:
					f += Localization.GetString("bw_containmentSlot");
					break;
				default:
					f +=
						Localization.GetString("unk")
						+ ": 0x"
						+ SimPe.Helper.HexString(t);
					break;
			}
			return f + (t != 0 ? ": 0x" + SimPe.Helper.HexString(s) : "");
		}

		public static Glob GlobByGroup(uint group)
		{
			FileTable.Entry[] items = FileTable.GFT[
				SimPe.Data.MetaData.GLOB_FILE,
				group
			];
			if (items == null || items.Length == 0)
			{
				return null;
			}

			Glob glob = new Glob();
			glob.ProcessData(items[0].PFD, items[0].Package);
			return glob;
		}

		public static String FormatGUID(bool lng, UInt32 guid)
		{
			String objName = GUIDIndex.TheGUIDIndex[guid];

			return objName != null && objName.Length > 0
				? lng
					? "GUID 0x"
						+ SimPe.Helper.HexString(guid)
						+ " (\""
						+ objName
						+ "\")"
					: "\"" + myLeft(objName, 60) + "\""
				: (lng ? "GUID " : "") + "0x" + SimPe.Helper.HexString(guid);
		}

		public static String FormatGUID(bool lng, byte[] o, int op)
		{
			return FormatGUID(
				lng,
				(UInt32)(o[op] | (o[op + 1] << 8) | (o[op + 2] << 16) | (o[op + 3] << 24))
			);
		}

		#region Constant parsing
		public string readBcon(uint instance, int bid, bool temp)
		{
			return readBcon(instance, bid, temp, false);
		}

		public string readBcon(uint instance, int bid, bool temp, bool useDecimal)
		{
			bool inDecimal = useDecimal ? Settings.PJSE.DecimalDOValue : false;

			if (
				instruction == null
				|| instruction.Parent == null
				|| instruction.Parent.FileDescriptor == null
			)
			{
				throw new InvalidOperationException(
					"Can't read BCON for instruction with no parent"
				);
			}

			Scope s = Scope.Private;
			if (instance < 0x1000)
			{
				s = Scope.Global;
			}
			else if (instance >= 0x2000)
			{
				s = Scope.SemiGlobal;
			}

			if (
				instruction.Parent.Context == Scope.Global && s != Scope.Global
				|| instruction.Parent.Context == Scope.SemiGlobal && s == Scope.Private
			)
			{
				return "";
			}

			FileTable.Entry[] items = FileTable.GFT[
				0x42434F4E,
				instruction.Parent.GroupForScope(s),
				instance
			];

			if (items == null || items.Length == 0)
			{
				return "[" + Localization.GetString("notfound") + "]";
			}

			SimPe.PackedFiles.Wrapper.Bcon bcon = new SimPe.PackedFiles.Wrapper.Bcon();
			bcon.ProcessData(items[0].PFD, items[0].Package);

			if (temp)
			{
				return ""; //"Filename: " + bcon.FileName;
			}

			Trcn trcn = (Trcn)bcon.SiblingResource(Trcn.Trcntype);
			string label = (
				(trcn != null && !trcn.TextOnly && bid < trcn.Count) ? trcn[bid] : ""
			).Trim();
			label = label.Length > 0 ? "\"" + label + "\" " : "";

			return bid >= bcon.Count
				? label + "[" + Localization.GetString("notset") + "]"
				: label
				+ Localization.GetString("Value")
				+ ": "
				+ (
					inDecimal
						? ((short)bcon[bid]).ToString()
						: "0x" + SimPe.Helper.HexString((short)bcon[bid])
				);
		}

		// not temp:
		// x = baabbbbb bccccccc, where a is scope, b is BCON instance and c is constant id
		// temp:
		// x = baabbbbb bbbbbccc, where a is scope, b is BCON instance and c is temp #
		public static ushort[] ExpandBCON(ushort instance, bool temp)
		{
			ushort[] result = new ushort[2];
			result[1] = (ushort)(instance & (!temp ? 0x7f : 0x07)); // ........ .ccccccc -or- ........ .....ccc

			int b;
			if (!temp)
			{
				b = ((instance >> 9) & 0x0040) | ((instance >> 7) & 0x003f); // b..bbbbb b.......
			}
			else
			{
				b = ((instance >> 5) & 0x0400) | ((instance >> 3) & 0x03ff); // b..bbbbb bbbbb...
			}

			int a = (instance >> 13) & 0x03; // .aa..... ........
			switch (a)
			{
				case 0:
					b += 0x1000;
					break; // private
				case 1:
					b += 0x2000;
					break; // semi-global
				case 2:
					b += 0x0100;
					break; // global
						   //case 3: b |= 0xF5BA; break; // do nothing
			}

			result[0] = (ushort)b;
			return result;
		}

		public static ushort ExpandBCON(ushort[] values, bool temp)
		{
			int output = 0;

			int b = values[0];
			if (!temp)
			{
				output = (b & 0x0040) << 9;
				b -= b & 0x0040;
			} // b....... ........
			else
			{
				output = (b & 0x0400) << 5;
				b -= b & 0x0400;
			} // b....... ........

			int a;
			if ((b & 0x2000) != 0)
			{
				b -= 0x2000;
				a = 1;
			} // Semi-Global
			else if ((b & 0x1000) != 0)
			{
				b -= 0x1000;
				a = 0;
			} // Private
			else if ((b & 0x0300) == 0x0100)
			{
				b -= 0x0100;
				a = 2;
			} // Global
			else
			{
				a = 3;
			} // do nothing
			output |= a << 13; // .aa..... ........

			if (!temp)
			{
				output |= (b & 0x003f) << 7; // ...bbbbb b.......
			}
			else
			{
				output |= (b & 0x03ff) << 3; // ...bbbbb bbbbb...
			}

			output |= values[1] & (!temp ? 0x7f : 0x07); // ........ .ccccccc -or- ........ .....ccc

			return (ushort)output;
		}

		public static string ExpandBCONtoString(ushort instance, bool temp)
		{
			ushort[] result = ExpandBCON(instance, temp);
			return !temp
				? "0x"
					+ SimPe.Helper.HexString(result[0])
					+ ":0x"
					+ SimPe.Helper.HexString((byte)result[1])
				: "0x"
					+ SimPe.Helper.HexString(result[0])
					+ ":["
					+ dnTemp()
					+ " "
					+ result[1].ToString()
					+ "]";
		}

		public static ushort StringtoExpandBCON(string text, bool temp)
		{
			string[] s = text.Split(":".ToCharArray(), 2);
			if (
				s.Length != 2
				|| (
					temp
					&& !(
						s[1].StartsWith("[" + dnTemp() + " ")
						&& s[1].EndsWith("]")
						&& s[1].Length.Equals(8)
					)
				)
			)
			{
				throw new InvalidCastException();
			}

			ushort[] b = new ushort[2];
			b[0] = Convert.ToUInt16(s[0], 16);
			b[1] = !temp
				? Convert.ToUInt16(s[1], 16)
				: Convert.ToUInt16(s[1].Substring(6, 1));

			ushort c = ExpandBCON(b, temp);

			ushort[] d = ExpandBCON(c, temp);
			return d[0] != b[0] || d[1] != b[1] ? throw new InvalidCastException() : c;
		}

		#endregion


		public static ushort ToShort(byte lower, byte higher)
		{
			return (ushort)((higher << 8) + lower);
		}

		public static void FromShort(ref byte[] ary, int index, ushort value)
		{
			ary[index] = (byte)(value & 0xff);
			ary[index + 1] = (byte)(value >> 8);
		}

		public static void FromShort(ref wrappedByteArray ary, int index, ushort value)
		{
			ary[index] = (byte)(value & 0xff);
			ary[index + 1] = (byte)(value >> 8);
		}

		#endregion
	}

	public interface IDataOwner
	{
		byte DataOwner
		{
			get;
		}
		ushort Value
		{
			get;
		}
		event EventHandler DataOwnerControlChanged;
	}
}
