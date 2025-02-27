using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SimPe.PackedFiles.UserInterface
{
	class SimOriGuid
	{
		static string fixresult = "No Changes could be Applied";

		public static void FixOrigGUID(Wrapper.ExtSDesc Sim)
		{
			uint gooee = 0x7FD96B54; // normal sim
			int species = 0; // human
			uint curspec = 0; // current species from character file
			string semig = "PersonGlobals";
			if (Sim.IsNPC)
			{
				return;
			}

			if (!System.IO.File.Exists(Sim.CharacterFileName))
			{
				return;
			}

			if ((int)Sim.Nightlife.Species == 1)
			{
				gooee = 0x0F83C946; // large dog
			}

			if ((int)Sim.Nightlife.Species == 2)
			{
				gooee = 0x111D8FFF; // small dog
			}

			if ((int)Sim.Nightlife.Species == 3)
			{
				gooee = 0x911D900A; // cat
			}

			if (Sim.CharacterDescription.NPCType == 1)
			{
				gooee = 0x0E93A00E;
			}

			if (Sim.CharacterDescription.NPCType == 2)
			{
				gooee = 0x0C8EE246;
			}

			if (Sim.CharacterDescription.NPCType == 3)
			{
				gooee = 0xAC87048A;
			}

			if (Sim.CharacterDescription.NPCType == 4)
			{
				gooee = 0x4C0DE403;
			}

			if (Sim.CharacterDescription.NPCType == 5)
			{
				gooee = 0x4C071B5D;
			}

			if (Sim.CharacterDescription.NPCType == 6)
			{
				gooee = 0x0E67FB80;
			}

			if (Sim.CharacterDescription.NPCType == 7)
			{
				gooee = 0x8E83C01F;
			}

			if (Sim.CharacterDescription.NPCType == 8)
			{
				gooee = 0x0E8507B8;
			}

			if (Sim.CharacterDescription.NPCType == 9)
			{
				gooee = 0xEC0DE507;
			}

			if (Sim.CharacterDescription.NPCType == 10)
			{
				gooee = 0x4CAD4A18;
			}

			if (Sim.CharacterDescription.NPCType == 11)
			{
				gooee = 0x2C31398B;
			}

			if (Sim.CharacterDescription.NPCType == 12)
			{
				gooee = 0xAC3ABE65;
			}

			if (Sim.CharacterDescription.NPCType == 13)
			{
				gooee = 0xACAAB82A;
			}

			if (Sim.CharacterDescription.NPCType == 14)
			{
				gooee = 0xCEAA3CA4;
			}

			if (Sim.CharacterDescription.NPCType == 16)
			{
				gooee = 0x4C6349E3;
			}

			if (Sim.CharacterDescription.NPCType == 17)
			{
				gooee = 0x6CD7D0E3;
			}

			if (Sim.CharacterDescription.NPCType == 18)
			{
				gooee = 0xEF594042;
			}

			if (Sim.CharacterDescription.NPCType == 19)
			{
				gooee = 0x4C5BA139;
			}

			if (Sim.CharacterDescription.NPCType == 20)
			{
				gooee = 0x2C3AD802;
			}

			if (Sim.CharacterDescription.NPCType == 21)
			{
				gooee = 0x4CB50CEB;
			}

			if (Sim.CharacterDescription.NPCType == 22)
			{
				gooee = 0xEC3EA3FF;
			}

			if (Sim.CharacterDescription.NPCType == 23)
			{
				gooee = 0x4CAD5157;
			}

			if (Sim.CharacterDescription.NPCType == 24)
			{
				gooee = 0x8EA1056C;
			}

			if (Sim.CharacterDescription.NPCType == 25)
			{
				gooee = 0xCEC0ADEE;
			}

			if (Sim.CharacterDescription.NPCType == 26)
			{
				gooee = 0xA82892C3;
			}

			if (Sim.CharacterDescription.NPCType == 27)
			{
				gooee = 0x6EAF4A2A;
			}

			if (Sim.CharacterDescription.NPCType == 28)
			{
				gooee = 0x0EAF64B9;
			}

			if (Sim.CharacterDescription.NPCType == 29)
			{
				gooee = 0x2C9BDEB4;
			}

			if (Sim.CharacterDescription.NPCType == 30)
			{
				gooee = 0xACA2F7D8;
			}

			if (Sim.CharacterDescription.NPCType == 31)
			{
				gooee = 0x4C4428BC;
			}

			if (Sim.CharacterDescription.NPCType == 33)
			{
				gooee = 0xEE963CF9;
			}

			if (Sim.CharacterDescription.NPCType == 34)
			{
				gooee = 0xEF2F2878;
			}

			if (Sim.CharacterDescription.NPCType == 35)
			{
				gooee = 0x6F4C183F;
			}

			if (Sim.CharacterDescription.NPCType == 36)
			{
				gooee = 0x2F4C1856;
			}

			if (Sim.CharacterDescription.NPCType == 37)
			{
				gooee = 0x4F583CAD;
			}

			if (Sim.CharacterDescription.NPCType == 39)
			{
				gooee = 0xCF99CB2E;
			}

			if (Sim.CharacterDescription.NPCType == 40)
			{
				gooee = 0xD07B9CE9;
			}

			if (Sim.CharacterDescription.NPCType == 41)
			{
				gooee = 0x508CB1F6;
			}

			if (Sim.CharacterDescription.NPCType == 42)
			{
				gooee = 0x10A49FB6;
			}

			if (Sim.CharacterDescription.NPCType == 43)
			{
				gooee = 0x71259AFD;
				species = 1;
				semig = "PetGlobals";
			} // Wolf
			if (Sim.CharacterDescription.NPCType == 44)
			{
				gooee = 0x117A0466;
				species = 1;
				semig = "PetGlobals";
			} // Wolf
			if (Sim.CharacterDescription.NPCType == 45)
			{
				gooee = 0x51BFB2CD;
				species = 3;
				semig = "PetGlobals";
			} // Skunk
			if (Sim.CharacterDescription.NPCType == 46)
			{
				gooee = 0xD19C6752;
			}

			if (Sim.CharacterDescription.NPCType == 47)
			{
				gooee = 0xB19DD2E4;
			}

			if (Sim.CharacterDescription.NPCType == 48)
			{
				if (
					(int)Sim.Version
					== (int)SimPe.PackedFiles.Wrapper.SDescVersions.Castaway
				)
				{
					gooee = 0x73352057;
					species = 1;
					Sim.Castaway.Subspecies = 1;
					semig = "PetGlobals"; // CS Wild Dog
				}
				else if (Helper.WindowsRegistry.LoadOnlySimsStory == 29)
				{
					gooee = 0x926DF19F; // Dog Show Judge
				}
				else
				{
					gooee = 0xD2EB0210; // Masseuse
				}
			}
			if (Sim.CharacterDescription.NPCType == 49)
			{
				if (
					(int)Sim.Version
					== (int)SimPe.PackedFiles.Wrapper.SDescVersions.Castaway
				)
				{
					gooee = 0x134B4BCC;
					species = 3;
					Sim.Castaway.Subspecies = 1;
					semig = "PetGlobals"; // CS Jaguar
				}
				else
				{
					gooee = 0x53007A0A; // Hotel Bellhop
				}
			}
			if (Sim.CharacterDescription.NPCType == 50)
			{
				if (
					(int)Sim.Version
					== (int)SimPe.PackedFiles.Wrapper.SDescVersions.Castaway
				)
				{
					gooee = 0xB350BB5B;
					Sim.Castaway.Subspecies = 2;
					semig = "OrangutanGlobals"; // CS Orangutan
				}
				else
				{
					gooee = 0xD354CD3C; // Villain
				}
			}
			if (Sim.CharacterDescription.NPCType == 51)
			{
				gooee = 0x530D36B5;
			}

			if (Sim.CharacterDescription.NPCType == 52)
			{
				gooee = 0x73213346;
			}

			if (Sim.CharacterDescription.NPCType == 53)
			{
				gooee = 0x13227F74;
			}

			if (Sim.CharacterDescription.NPCType == 54)
			{
				gooee = 0x13269F2D; // BigFoot
			}

			if (Sim.CharacterDescription.NPCType == 55)
			{
				gooee = 0x5333A638;
			}

			if (Sim.CharacterDescription.NPCType == 56)
			{
				gooee = 0x533508AB;
			}

			if (Sim.CharacterDescription.NPCType == 57)
			{
				gooee = 0x933A6CF6;
			}

			if (Sim.CharacterDescription.NPCType == 58)
			{
				gooee = 0xB38590EB;
			}

			if (Sim.CharacterDescription.NPCType == 59)
			{
				gooee = 0x136B1F2A;
			}

			if (Sim.CharacterDescription.NPCType == 60)
			{
				gooee = 0xD3D1F78D;
			}

			if (Sim.CharacterDescription.NPCType == 61)
			{
				gooee = 0x341FB0E2;
			}

			if (Sim.CharacterDescription.NPCType == 64)
			{
				gooee = 0xD524CAF4;
			}

			if (Sim.CharacterDescription.NPCType == 65)
			{
				gooee = 0x34E17C1B;
			}

			if (Sim.CharacterDescription.NPCType == 66)
			{
				gooee = 0x54E6DF92;
				species = 3;
				semig = "PetGlobals";
			} // Witch Cat
			if (Sim.CharacterDescription.NPCType == 67)
			{
				gooee = 0x95111668;
			}

			if (Sim.CharacterDescription.NPCType == 68)
			{
				gooee = 0x54F6C33B;
			}

			if (Sim.CharacterDescription.NPCType == 69)
			{
				gooee = 0xF520E952;
			}

			if (Sim.CharacterDescription.NPCType == 70)
			{
				gooee = 0xF50F6EE9;
			}

			if (Sim.CharacterDescription.NPCType == 71)
			{
				gooee = 0xF51A5E5B;
			}

			if (Sim.CharacterDescription.NPCType == 75)
			{
				gooee = 0x00845D9B;
			}

			if (Sim.CharacterDescription.NPCType == 76)
			{
				gooee = 0x006D2D3A;
			}

			if (Sim.CharacterDescription.NPCType == 78)
			{
				gooee = 0x008BB25E;
			}

			if (Sim.CharacterDescription.NPCType == 80)
			{
				gooee = 0xF7E4AE00;
			}

			if (Sim.CharacterDescription.NPCType == 233)
			{
				gooee = 0x2C996F9C; // Item controller
			}

			if (Sim.SimId == gooee)
			{
				fixresult = "This is the NPC Template, Changes will not be applied";
				return;
			}

			if (gooee == 0x0F83C946 || gooee == 0x111D8FFF || gooee == 0x911D900A)
			{
				species = (int)Sim.Nightlife.Species;
			}

			SimPe.Packages.GeneratableFile pkg =
				SimPe.Packages.GeneratableFile.LoadFromFile(Sim.CharacterFileName);
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				Data.MetaData.AGED
			);
			if (pfds.Length == 1)
			{
				SimPe.PackedFiles.Wrapper.Cpf ageData =
					new SimPe.PackedFiles.Wrapper.Cpf();
				ageData.ProcessData(pfds[0], pkg);
				curspec = ageData.GetItem("species").UIntegerValue;
				if (curspec == 8)
				{
					curspec = 3; // cat
				}
				else if (curspec == 4)
				{
					curspec = 2; // small dog
				}
				else if (curspec == 2)
				{
					curspec = 1; // large dog
				}
				else
				{
					curspec = 0; // human
				}
			}
			else
			{
				pkg.Close();
				fixresult = "Unable to read Sim's Character File";
				return;
			}
			if (curspec != species)
			{
				Sim.Nightlife.Species =
					(SimPe.PackedFiles.Wrapper.SdscNightlife.SpeciesType)curspec;
				pkg.Close();
				fixresult = "Inconsistant Species, No Changes Applied";
				return;
			}

			pfds = pkg.FindFiles(Data.MetaData.OBJD_FILE);
			if (pfds.Length == 1)
			{
				SimPe.PackedFiles.Wrapper.ExtObjd objd =
					new SimPe.PackedFiles.Wrapper.ExtObjd();
				objd.ProcessData(pfds[0], pkg);
				if (
					objd.OriginalGuid == 0x9985408B
					|| objd.OriginalGuid == 0x00845D42
					|| objd.OriginalGuid == 0x00845DD5
					|| objd.OriginalGuid == 0x00845DD6
				)
				{
					Sim.CharacterDescription.NPCType = 0;
					Sim.Nightlife.Species = 0; // EP9 Angel or Devil, Don't apply gooee
					fixresult = "Angel or Devil Sim, Changes will not be applied";
				}
				else if (
					objd.OriginalGuid == 0x006D2D53
					|| objd.OriginalGuid == 0x006D2D54
					|| objd.OriginalGuid == 0x006D2D5B
				)
				{
					Sim.CharacterDescription.NPCType = 79;
					Sim.Nightlife.Species = 0; // EP9 Tiny Sim, Don't apply gooee and do force age
					Sim.CharacterDescription.LifeSection = SimPe
						.Data
						.MetaData
						.LifeSections
						.Child;
					fixresult = "Tiny Sim, Changes Must Not be applied";
				}
				else
				{
					objd.OriginalGuid = gooee;
					if (
						gooee != 0x0F83C946
						&& gooee != 0x111D8FFF
						&& gooee != 0x911D900A
					) // these are gleened from species
					{
						Sim.Nightlife.Species =
							(SimPe.PackedFiles.Wrapper.SdscNightlife.SpeciesType)species;
					}
					else
					{
						semig = "PetGlobals";
					}

					objd.SynchronizeUserData();

					pfds = pkg.FindFiles(Data.MetaData.GLOB_FILE);
					if (pfds.Length == 1)
					{
						SimPe.Plugin.Glob globy = new SimPe.Plugin.Glob();
						globy.ProcessData(pfds[0], pkg);
						globy.SemiGlobalName = semig;
						globy.SynchronizeUserData();
					}
					pkg.Save();
					fixresult =
						"Changes Have been Applied to "
						+ Sim.SimName
						+ "'s Character File";
				}
				pkg.Close();
				Sim.Changed = true;
				Sim.SynchronizeUserData();
			}
			else
			{
				pkg.Close();
				fixresult = "Unable to read Sim's Character File";
				return;
			}
		}

		public static string FixResult()
		{
			return fixresult;
		}

		internal static System.Drawing.Image LoadTurnOnsIcon(int i) // i can be zero
		{
			uint j;
			int to1 = 13;
			if (Helper.WindowsRegistry.LoadOnlySimsStory > 0)
			{
				to1 = 12; // All Sims Story Editions Don't use Tattoos
			}
			// images don't have a to f, go straight from 0x09 to 0x10
			if (i <= to1)
			{
				j = Convert.ToUInt32(0x30010001 + i);
				if (i > 8)
				{
					j += 6; // 8 not 9 because i can be zero
				}
			}
			else
			{
				i -= to1;
				if (i <= 16)
				{
					j = Convert.ToUInt32(0x30020000 + i); // subtraced 1 from image list, first value here is 1 not 0
					if (i > 9)
					{
						j += 6;
					}
				}
				else
				{
					i -= 16;
					j = Convert.ToUInt32(0x30030000 + i); // subtraced 1 from image list, first value here is 1 not 0
					if (i > 9)
					{
						j += 6;
					}
				}
			}

			SimPe.Packages.File pkg = SimPe.Packages.File.LoadFromFile(
				System.IO.Path.Combine(
					PathProvider.Global.Latest.InstallFolder,
					"TSData\\Res\\UI\\ui.package"
				)
			);
			if (pkg != null)
			{
				SimPe.Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(
					0x856DDBAC,
					0,
					0x499DB772,
					j
				);
				if (pfd != null)
				{
					SimPe.PackedFiles.Wrapper.Picture pic =
						new SimPe.PackedFiles.Wrapper.Picture();
					pic.ProcessData(pfd, pkg);
					return pic.Image;
				}
			}
			return null;
		}

		public static string AboutSim(Wrapper.ExtSDesc Sim)
		{
			string ret = "";
			string hairc = " unusual,";
			ushort tmpa;
			ushort tmpb;
			ushort tmpc;
			ushort tmpd;
			ushort tmpe;
			ushort tmpf;
			short tmpg;
			short tmph;

			ret = " " + Sim.SimName + " is ";
			tmpa = Sim.Character.Playful;
			tmpb = (ushort)(1000 - Sim.Character.Playful); // now we are serious
			tmpc = Sim.Character.Outgoing;
			tmpd = (ushort)(1000 - Sim.Character.Outgoing); // now we are shy
			tmpe = Sim.Character.Nice;
			tmpf = (ushort)(1000 - Sim.Character.Nice); // now we are grumpy
			if (tmpa > tmpb && tmpa > tmpc && tmpa > tmpd && tmpa > tmpe && tmpa > tmpf)
			{
				ret += "a playful,";
			}
			else if (tmpb > tmpc && tmpb > tmpd && tmpb > tmpe && tmpb > tmpf)
			{
				ret += "a serious,";
			}
			else if (tmpc > tmpd && tmpc > tmpe && tmpc > tmpf)
			{
				ret += "an outgoing,";
			}
			else if (tmpd > tmpe && tmpd > tmpf)
			{
				ret += "a shy,";
			}
			else if (tmpe > tmpf)
			{
				ret += "a very pleasant,";
			}
			else
			{
				ret += "a grumpy,";
			}

			if (
				(int)Sim.Version
				>= (int)SimPe.PackedFiles.Wrapper.SDescVersions.Nightlife
			)
			{
				tmpa = Sim.Nightlife.AttractionTraits2;
				if (tmpa > 32768)
				{
					tmpa -= 32768;
				}

				if (tmpa > 16384)
				{
					tmpa -= 16384;
				}

				if (tmpa > 8192)
				{
					tmpa -= 8192;
				}

				if (tmpa > 4096)
				{
					tmpa -= 4096;
				}

				if (tmpa > 2048)
				{
					tmpa -= 2048;
				}

				if (tmpa > 1024)
				{
					tmpa -= 1024;
				}

				if (tmpa > 512)
				{
					tmpa -= 512;
				}

				if (tmpa > 256)
				{
					tmpa -= 256;
				}

				if (tmpa > 128)
				{
					tmpa -= 128;
				}

				if (tmpa > 64)
				{
					tmpa -= 64;
				}

				if (tmpa == 32)
				{
					hairc = " silver,";
				}

				if (tmpa == 16)
				{
					hairc = " spectacular,";
				}

				if (tmpa == 8)
				{
					hairc = " dark haired,";
				}

				if (tmpa == 4)
				{
					hairc = " brunette,";
				}

				if (tmpa == 2)
				{
					hairc = " fiery red-head,";
				}

				if (tmpa == 1)
				{
					hairc = " blonde,";
				}

				ret += hairc;
			}
			if (Sim.CharacterDescription.Gender == Data.MetaData.Gender.Female)
			{
				if (Sim.CharacterDescription.BodyFlag.Fit)
				{
					ret += " athletic female";
				}
				else if (Sim.CharacterDescription.BodyFlag.Fat)
				{
					ret += " overweight female";
				}
				else
				{
					ret += " female";
				}
			}
			else
			{
				if (Sim.CharacterDescription.BodyFlag.Fit)
				{
					ret += " athletic male";
				}
				else if (Sim.CharacterDescription.BodyFlag.Fat)
				{
					ret += " overweight male";
				}
				else
				{
					ret += " male";
				}
			}

			tmpg = Sim.Interests.FemalePreference;
			tmph = Sim.Interests.MalePreference;
			//if (!Sim.CharacterDescription.IsPreTeen)
			{
				ret += ". " + Sim.SimName;
				if (tmpg > tmph)
				{
					tmpg /= 2;
					if (tmpg > tmph)
					{
						ret += " prefers women to men";
					}
					else
					{
						ret += " has no real gender preference";
					}
				}
				else if (tmpg == tmph)
				{
					if (tmpg < 3)
					{
						ret += " likes to spend time alone, reading a good book";
					}
					else
					{
						ret += " has no real gender preference";
					}
				}
				else
				{
					tmph /= 2;
					if (tmph > tmpg)
					{
						ret += " prefers men to women";
					}
					else
					{
						ret += " has no real gender preference";
					}
				}
			}
			//else ret += ".";

			if (Sim.CharacterDescription.Gender == Data.MetaData.Gender.Female)
			{
				ret += " She aspires to ";
			}
			else
			{
				ret += " He aspires to ";
			}

			if (
				Sim.Freetime.PrimaryAspiration
				== SimPe.Data.MetaData.AspirationTypes.Romance
			)
			{
				ret += "get lots of lovers";
			}
			else if (
				Sim.Freetime.PrimaryAspiration
				== SimPe.Data.MetaData.AspirationTypes.Family
			)
			{
				ret += "raise a large, happy family";
			}
			else if (
				Sim.Freetime.PrimaryAspiration
				== SimPe.Data.MetaData.AspirationTypes.Chees
			) //
			{
				ret += "eat grilled cheese";
			}
			else if (
				Sim.Freetime.PrimaryAspiration
				== SimPe.Data.MetaData.AspirationTypes.Fortune
			)
			{
				ret += "be successful";
			}
			else if (
				Sim.Freetime.PrimaryAspiration
				== SimPe.Data.MetaData.AspirationTypes.Knowledge
			)
			{
				ret += "learn all the secrets of the universe";
			}
			else if (
				Sim.Freetime.PrimaryAspiration
				== SimPe.Data.MetaData.AspirationTypes.Pleasure
			)
			{
				ret += "party hard and often";
			}
			else if (
				Sim.Freetime.PrimaryAspiration
				== SimPe.Data.MetaData.AspirationTypes.Reputation
			)
			{
				ret += "make as many friends as possible";
			}
			else if (
				Sim.Freetime.PrimaryAspiration
				== SimPe.Data.MetaData.AspirationTypes.Growup
			)
			{
				ret += "grow up";
			}
			else
			{
				ret += "have inner beauty";
			}

			if (
				(int)Sim.Version
				>= (int)SimPe.PackedFiles.Wrapper.SDescVersions.Freetime
			)
			{
				if (
					Sim.Freetime.SecondaryAspiration
					!= SimPe.Data.MetaData.AspirationTypes.Nothing
				)
				{
					ret += " and ";
					if (
						Sim.Freetime.SecondaryAspiration
						== SimPe.Data.MetaData.AspirationTypes.Romance
					)
					{
						ret += "get lots of lovers.";
					}
					else if (
						Sim.Freetime.SecondaryAspiration
						== SimPe.Data.MetaData.AspirationTypes.Family
					)
					{
						ret += "raise a large, happy family.";
					}
					else if (
						Sim.Freetime.SecondaryAspiration
						== SimPe.Data.MetaData.AspirationTypes.Chees
					) //
					{
						ret += "eat grilled cheese.";
					}
					else if (
						Sim.Freetime.SecondaryAspiration
						== SimPe.Data.MetaData.AspirationTypes.Fortune
					)
					{
						ret += "be successful.";
					}
					else if (
						Sim.Freetime.SecondaryAspiration
						== SimPe.Data.MetaData.AspirationTypes.Knowledge
					)
					{
						ret += "learn all the secrets of the universe.";
					}
					else if (
						Sim.Freetime.SecondaryAspiration
						== SimPe.Data.MetaData.AspirationTypes.Pleasure
					)
					{
						ret += "party hard and often.";
					}
					else if (
						Sim.Freetime.SecondaryAspiration
						== SimPe.Data.MetaData.AspirationTypes.Reputation
					)
					{
						ret += "make as many friends as possible.";
					}
					else
					{
						ret += "have inner beauty.";
					}
				}
				else
				{
					ret += ".";
				}

				ret += "\r\n\r\n " + Sim.SimName + " has ";
				if (
					Sim.Freetime.HobbyPredistined
					== SimPe.PackedFiles.Wrapper.Hobbies.Nature
				)
				{
					ret += "a natural talent for nature and";
				}
				else if (
					Sim.Freetime.HobbyPredistined
					== SimPe.PackedFiles.Wrapper.Hobbies.Arts
				)
				{
					ret += "a natural talent for art and craft and";
				}
				else if (
					Sim.Freetime.HobbyPredistined
					== SimPe.PackedFiles.Wrapper.Hobbies.Cuisine
				)
				{
					ret += "a natural talent for cuisine and";
				}
				else if (
					Sim.Freetime.HobbyPredistined
					== SimPe.PackedFiles.Wrapper.Hobbies.Film
				)
				{
					ret += "a natural talent for film and literature and";
				}
				else if (
					Sim.Freetime.HobbyPredistined
					== SimPe.PackedFiles.Wrapper.Hobbies.Fitness
				)
				{
					ret += "a natural talent for fitness and";
				}
				else if (
					Sim.Freetime.HobbyPredistined
					== SimPe.PackedFiles.Wrapper.Hobbies.Games
				)
				{
					ret += "a natural talent for computer games and";
				}
				else if (
					Sim.Freetime.HobbyPredistined
					== SimPe.PackedFiles.Wrapper.Hobbies.Music
				)
				{
					ret += "a natural talent for music and dance and";
				}
				else if (
					Sim.Freetime.HobbyPredistined
					== SimPe.PackedFiles.Wrapper.Hobbies.Science
				)
				{
					ret += "a natural talent for science and";
				}
				else if (
					Sim.Freetime.HobbyPredistined
					== SimPe.PackedFiles.Wrapper.Hobbies.Sport
				)
				{
					ret += "a natural talent for sport and";
				}
				else if (
					Sim.Freetime.HobbyPredistined
					== SimPe.PackedFiles.Wrapper.Hobbies.Tinkering
				)
				{
					ret += "a natural talent for fixing things and";
				}
				else
				{
					ret += "not discovered a natural talent yet and";
				}
			}
			else
			{
				ret += ".\r\n\r\n " + Sim.SimName;
			}

			ret += " has a keen interest in ";
			tmpa = Sim.Interests.Animals;
			if (Sim.Interests.Crime > tmpa)
			{
				tmpa = Sim.Interests.Crime;
			}

			if (Sim.Interests.Culture > tmpa)
			{
				tmpa = Sim.Interests.Culture;
			}

			if (Sim.Interests.Entertainment > tmpa)
			{
				tmpa = Sim.Interests.Entertainment;
			}

			if (Sim.Interests.Environment > tmpa)
			{
				tmpa = Sim.Interests.Environment;
			}

			if (Sim.Interests.Fashion > tmpa)
			{
				tmpa = Sim.Interests.Fashion;
			}

			if (Sim.Interests.Food > tmpa)
			{
				tmpa = Sim.Interests.Food;
			}

			if (Sim.Interests.Health > tmpa)
			{
				tmpa = Sim.Interests.Health;
			}

			if (Sim.Interests.Money > tmpa)
			{
				tmpa = Sim.Interests.Money;
			}

			if (Sim.Interests.Paranormal > tmpa)
			{
				tmpa = Sim.Interests.Paranormal;
			}

			if (Sim.Interests.Politics > tmpa)
			{
				tmpa = Sim.Interests.Politics;
			}

			if (Sim.Interests.School > tmpa)
			{
				tmpa = Sim.Interests.School;
			}

			if (Sim.Interests.Scifi > tmpa)
			{
				tmpa = Sim.Interests.Scifi;
			}

			if (Sim.Interests.Sports > tmpa)
			{
				tmpa = Sim.Interests.Sports;
			}

			if (Sim.Interests.Toys > tmpa)
			{
				tmpa = Sim.Interests.Toys;
			}

			if (Sim.Interests.Travel > tmpa)
			{
				tmpa = Sim.Interests.Travel;
			}

			if (Sim.Interests.Weather > tmpa)
			{
				tmpa = Sim.Interests.Weather;
			}

			if (Sim.Interests.Work > tmpa)
			{
				tmpa = Sim.Interests.Work;
			}

			if (tmpa == Sim.Interests.Animals)
			{
				ret += "animals";
			}
			else if (tmpa == Sim.Interests.Crime)
			{
				ret += "crime";
			}
			else if (tmpa == Sim.Interests.Culture)
			{
				ret += "culture";
			}
			else if (tmpa == Sim.Interests.Entertainment)
			{
				ret += "entertainment";
			}
			else if (tmpa == Sim.Interests.Environment)
			{
				ret += "the environment";
			}
			else if (tmpa == Sim.Interests.Fashion)
			{
				ret += "fashion";
			}
			else if (tmpa == Sim.Interests.Food)
			{
				ret += "food";
			}
			else if (tmpa == Sim.Interests.Health)
			{
				ret += "health";
			}
			else if (tmpa == Sim.Interests.Money)
			{
				ret += "wealth";
			}
			else if (tmpa == Sim.Interests.Paranormal)
			{
				ret += "the occult";
			}
			else if (tmpa == Sim.Interests.Politics)
			{
				ret += "politics";
			}
			else if (tmpa == Sim.Interests.School)
			{
				ret += "school";
			}
			else if (tmpa == Sim.Interests.Scifi)
			{
				ret += "science fiction";
			}
			else if (tmpa == Sim.Interests.Sports)
			{
				ret += "sports";
			}
			else if (tmpa == Sim.Interests.Toys)
			{
				ret += "toys";
			}
			else if (tmpa == Sim.Interests.Travel)
			{
				ret += "travel";
			}
			else if (tmpa == Sim.Interests.Weather)
			{
				ret += "weather";
			}
			else if (tmpa == Sim.Interests.Work)
			{
				ret += "work";
			}
			else
			{
				ret += "nothing much";
			}

			if (
				(int)Sim.Version
				>= (int)SimPe.PackedFiles.Wrapper.SDescVersions.Apartment
			)
			{
				if (Sim.CharacterDescription.Gender == Data.MetaData.Gender.Female)
				{
					ret += ", she ";
				}
				else
				{
					ret += ", he ";
				}

				if (Sim.Apartment.Reputation > 90)
				{
					ret += "has an impeccable reputation";
				}
				else if (Sim.Apartment.Reputation > 20)
				{
					ret += "has a good reputation";
				}
				else if (Sim.Apartment.Reputation > 0)
				{
					ret += "has a pretty good reputation";
				}
				else if (Sim.Apartment.Reputation < -50)
				{
					ret += "has a really bad reputation";
				}
				else if (Sim.Apartment.Reputation < -20)
				{
					ret += "has a bad reputation";
				}
				else if (Sim.Apartment.Reputation < 0)
				{
					ret += "has a poor reputation";
				}
				else
				{
					ret += "has aquired no reputation yet";
				}
			}
			ret += ".";

			return ret;
		}
	}
}
