/***************************************************************************
 *   Copyright (C) 2008 by Peter L Jones                                   *
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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

using SimPe;
using SimPe.Interfaces;
using SimPe.Interfaces.Files;
using SimPe.PackedFiles.Wrapper;
using SimPe.Plugin;

namespace pjHoodTool
{
	class cHoodTool : AbstractTool, ITool, ICommandLine
	{
		string q(string u)
		{
			return u == null ? u : "\"" + u.Replace("\"", "\"\"") + "\"";
		}

		Settims getim = new Settims();
		internal static bool incbas = true;
		internal static bool incint = true;
		internal static bool inccha = true;
		internal static bool incski = true;
		internal static bool incuni =
			PathProvider.Global.GetExpansion(Expansions.University)
			.Exists;
		internal static bool incbus =
			PathProvider.Global.GetExpansion(Expansions.Business)
			.Exists;
		internal static bool incfre =
			PathProvider.Global.GetExpansion(Expansions.FreeTime)
			.Exists;
		internal static bool incapa =
			PathProvider.Global.GetExpansion(Expansions.Apartments)
			.Exists;
		internal static bool incnpc = true;
		internal static bool incdes = true;
		internal static bool incpet = true;
		internal static bool inclot = true;
		internal static string outptype = ".txt";
		string[] lotfams = new string[5000];

		delegate void Splash(string message);
		Splash splash;

		void Rufio(string output, string hood, int group)
		{
			int ct = 1;
			string foldim = "Rufio";
			if (output.Length == 0)
			{
				while (
					Directory.Exists(
						Path.Combine(PathProvider.SimSavegameFolder, foldim)
					)
				)
				{
					ct++;
					foldim = "Rufio" + Convert.ToString(ct);
				}
				output = Path.Combine(
					Path.Combine(PathProvider.SimSavegameFolder, foldim),
					"ExportedSims" + outptype
				);
			}
			else
			{
				while (Directory.Exists(Path.Combine(output, foldim)))
				{
					ct++;
					foldim = "Rufio" + Convert.ToString(ct);
				}
				output = Path.Combine(
					Path.Combine(output, foldim),
					"ExportedSims" + outptype
				);
			}

			string outPath = Path.GetDirectoryName(output);
			if (!Directory.Exists(outPath))
			{
				Directory.CreateDirectory(outPath);
			}

			if (group < 1)
			{
				group = PathProvider.Global.CurrentGroup;
			}

			for (int i = 0; i < lotfams.Length; i++)
			{
				lotfams[i] = "";
			}

			//StreamWriter w1 = new StreamWriter(output);
			StreamWriter w1 = new StreamWriter(output, false, Encoding.Default)
			{
				AutoFlush = true
			};
			StreamWriter w2 = null;
			if (inclot)
			{
				w2 = new StreamWriter(
					Path.Combine(outPath, "ExportedLots" + outptype),
					false,
					Encoding.Default
				)
				{
					AutoFlush = true
				};
			}

			splash("Export Neighbourhoods...");
			try
			{
				#region ExportedSims header
				string heady = "";
				if (incbas)
				{
					heady = "hood,Hood Name,";
				}

				heady += "NID,First Name,Last Name";
				if (incdes)
				{
					heady += ",Sim Description";
				}

				heady += ",FamilyInstance,Household Name,HouseNumber";
				if (incbas)
				{
					heady +=
						",AvailableCharacterData,Unlinked,ParentA,ParentB,Spouse,Body Condition";
				}

				heady += ",NPC Type";
				if (incbas)
				{
					heady +=
						",School Type,Grade,CareerPerformance,Career,CareerLevel,Zodiac Sign";
				}

				heady += ",Gender,LifeSection";
				if (incbas)
				{
					heady +=
						",AgeDaysLeft,PrevAgeDays,AgeDuration,BlizLifelinePoints,LifelinePoints,LifelineScore";
				}

				if (inccha)
				{
					heady +=
						",GenActive,GenNeat,GenNice,GenOutgoing,GenPlayful,Active,Neat,Nice,Outgoing,Playful"; // Character
				}

				if (incint)
				{
					heady +=
						",Animals,Crime,Culture,Entertainment,Environment,Fashion,Food,Health,Money,Paranormal,Politics,School,Scifi,Sports,Toys,Travel,Weather,Work"; //Interests
				}

				heady += ",FemalePreference,MalePreference";
				if (incski)
				{
					heady +=
						",Body,Charisma,Cleaning,Cooking,Creativity,Fatness,Logic,Mechanical"; //Skills
					if (Helper.WindowsRegistry.ShowMoreSkills)
					{
						heady += ",Art,Music";
					}
				}
				if (incuni)
				{
					heady +=
						",IsAtUniversity,UniEffort,UniGrade,UniTime,UniSemester,UniInfluence,UniMajor"; // University
				}

				if (incpet && incbas)
				{
					heady += ",Species";
				}

				if (incbus)
				{
					heady += ",Job Assignment,Lot ID,Salary"; // Business
				}

				if (incfre)
				{
					heady +=
						",PrimaryAspiration,SecondaryAspiration,Natural Talent,LongtermAspiration"; // FreeTime
				}

				if (incapa)
				{
					heady += ",Reputation,Title"; // Aparments
				}

				heady += "";

				w1.WriteLine(heady);
				#endregion

				#region ExportedLots header
				if (inclot)
				{
					w2.WriteLine(
						"hood"
							+ ",Hood Name"
							+ ",Hood Type"
							+ ",House Number,House Name"
							+ ",Lot Type"
							+ ",Family"
							+ ",Lot Flags"
							+ ""
					);
				}
				#endregion

				ExpansionItem.NeighborhoodPaths paths =
					PathProvider.Global.GetNeighborhoodsForGroup(group);
				foreach (ExpansionItem.NeighborhoodPath path in paths)
				{
					string sourcepath = path.Path;
					string[] dirs = Directory.GetDirectories(
						sourcepath,
						hood.Length > 0 ? hood : "????"
					);
					foreach (string dir in dirs)
					{
						AddHood(outPath, dir, w1, w2);
					}
				}
			}
			finally
			{
				w1.Close();
				if (inclot)
				{
					w2.Close();
				}
			}
		}

		ExtFamilyTies eft = null;

		void SetProvider(IPackageFile pkg)
		{
			FileTableBase.ProviderRegistry.SimFamilynameProvider.BasePackage = pkg;
			FileTableBase.ProviderRegistry.SimDescriptionProvider.BasePackage = pkg;
			FileTableBase.ProviderRegistry.SimNameProvider.BaseFolder =
				Path.Combine(
					Path.GetDirectoryName(pkg.FileName),
					"Characters"
				);
			FileTableBase.ProviderRegistry.LotProvider.BaseFolder = Path.Combine(
				Path.GetDirectoryName(pkg.FileName),
				"Lots"
			);
			eft = new ExtFamilyTies();
			IPackedFileDescriptor[] pfds = pkg.FindFiles(
				SimPe.Data.MetaData.FAMILY_TIES_FILE
			);
			if (pfds != null && pfds.Length > 0)
			{
				eft.ProcessData(pfds[0], pkg);
			}
		}

		DateTime dt = new DateTime(0);
		bool wasUnk = true;

		void AddHood(string outPath, string dir, StreamWriter w1, StreamWriter w2)
		{
			string hood = Path.GetFileName(dir);
			string hoodFile = Path.Combine(dir, hood + "_Neighborhood.package");
			if (!File.Exists(hoodFile))
			{
				return;
			}

			SimPe.Packages.File pkg = SimPe.Packages.File.LoadFromFile(hoodFile);
			if (pkg == null)
			{
				return;
			}

			string hoodtipe = "Primary";
			string hoodName = Localization.GetString("Unknown");
			IPackedFileDescriptor[] pfds = pkg.FindFiles(SimPe.Data.MetaData.CTSS_FILE);
			StrWrapper ctss = null;
			Idno ntype = null;
			if (pfds.Length == 1)
			{
				ctss = new StrWrapper();
				ctss.ProcessData(pfds[0], pkg);
				hoodName = ctss[(byte)Helper.WindowsRegistry.LanguageCode, 0] == null
					? q(ctss[1, 0])
					: q(ctss[(byte)Helper.WindowsRegistry.LanguageCode, 0]);
			}
			else
			{
				hoodName = hood; // Tutorial Hood has no CTSS
			}

			if (!Directory.Exists(Path.Combine(outPath, "SimImage")))
			{
				Directory.CreateDirectory(Path.Combine(outPath, "SimImage"));
			}

			System.Windows.Forms.Application.DoEvents();
			splash("Loading Neighborhood " + hood + ": " + hoodName);
			SetProvider(pkg);

			dt = new DateTime(0);
			wasUnk = true;
			pfds = pkg.FindFiles(SimPe.Data.MetaData.SIM_DESCRIPTION_FILE);
			foreach (IPackedFileDescriptor spfd in pfds)
			{
				ExtSDesc sdsc = new ExtSDesc();
				sdsc.ProcessData(spfd, pkg);
				if (
					(
						incnpc
						|| (sdsc.FamilyInstance != 0 && sdsc.FamilyInstance < 0x7f00)
					)
					&& (
						incpet
						|| sdsc.Nightlife.Species == SdscNightlife.SpeciesType.Human
					)
				)
				{
					AddSim(outPath, hood, hoodName, w1, sdsc);
				}
			}

			if (inclot)
			{
				if (!Directory.Exists(Path.Combine(outPath, "LotImage")))
				{
					Directory.CreateDirectory(Path.Combine(outPath, "LotImage"));
				}

				dt = new DateTime(0);
				wasUnk = true;
				pfds = pkg.FindFiles(Ltxt.Ltxttype);
				foreach (IPackedFileDescriptor spfd in pfds)
				{
					Ltxt ltxt = new Ltxt();
					ltxt.ProcessData(spfd, pkg);

					AddLot(outPath, hood, hoodName, w2, ltxt, hoodtipe);
				}
				// try to add all lots
				try
				{
					string[] overs = Directory.GetFiles(
						Path.GetDirectoryName(hoodFile),
						hood + "*.package",
						SearchOption.TopDirectoryOnly
					);
					foreach (string file in overs)
					{
						if (file != hoodFile)
						{
							pkg = SimPe.Packages.File.LoadFromFile(file);
							hoodName = Localization.GetString("Unknown");
							pfds = pkg.FindFiles(SimPe.Data.MetaData.CTSS_FILE);
							if (pfds.Length == 1)
							{
								ctss = new StrWrapper();
								ctss.ProcessData(pfds[0], pkg);
								hoodName = ctss[(byte)Helper.WindowsRegistry.LanguageCode, 0]
									== null
									? q(ctss[1, 0])
									: q(
										ctss[
											(byte)Helper.WindowsRegistry.LanguageCode,
											0
										]
									);

								System.Windows.Forms.Application.DoEvents();
								splash("Loading Subhood : " + hoodName);
							}
							pfds = pkg.FindFiles(SimPe.Data.MetaData.IDNO);
							if (pfds.Length == 1)
							{
								ntype = new Idno();
								ntype.ProcessData(pfds[0], pkg);
								hoodtipe = Enum.GetName(
									typeof(NeighborhoodType),
									ntype.Type
								);
								if (
									ntype.Subep
										!= SimPe.Data.MetaData.NeighbourhoodEP.Business
									&& hoodtipe == "Suburb"
								)
								{
									hoodtipe = "Hidden Suburb";
								}
							}

							SetProvider(pkg);
							pfds = pkg.FindFiles(Ltxt.Ltxttype);
							foreach (IPackedFileDescriptor spfd in pfds)
							{
								Ltxt ltxt = new Ltxt();
								ltxt.ProcessData(spfd, pkg);
								AddLot(outPath, hood, hoodName, w2, ltxt, hoodtipe);
							}
						}
					}
				}
				catch { }
				Array.Clear(lotfams, 0, 5000);
			}
		}

		void AddSim(
			string outPath,
			string hood,
			string hoodName,
			StreamWriter w,
			ExtSDesc sdsc
		)
		{
			#region desc
			string desc = ",";
			if (incdes)
			{
				desc = ",,";
			}

			IPackageFile pkg = SimPe.Packages.File.LoadFromFile(
				sdsc.CharacterFileName
			);
			if (pkg == null)
			{
				if (SimPe.Data.MetaData.GetKnownNPC(sdsc.SimId) != "not found")
				{
					desc =
						q(SimPe.Data.MetaData.GetKnownNPC(sdsc.SimId)) + desc + "(NPC)";
				}
				else
				{
					return;
				}
			}
			else
			{
				IPackedFileDescriptor[] pfds = pkg.FindFiles(StrWrapper.CTSStype);
				if (pfds == null || pfds.Length == 0)
				{
					if (SimPe.Data.MetaData.GetKnownNPC(sdsc.SimId) != "not found")
					{
						desc =
							q(SimPe.Data.MetaData.GetKnownNPC(sdsc.SimId))
							+ desc
							+ "(NPC)";
					}
					else
					{
						return;
					}
				}
				else
				{
					try
					{
						StrWrapper ctss = new StrWrapper();
						ctss.ProcessData(pfds[0], pkg);
						if (ctss[(byte)Helper.WindowsRegistry.LanguageCode, 0] == null)
						{
							desc = q(ctss[1, 0]) + ",";
						}
						else
						{
							desc =
								q(ctss[(byte)Helper.WindowsRegistry.LanguageCode, 0])
								+ ","; // firstname
						}

						if (ctss[(byte)Helper.WindowsRegistry.LanguageCode, 2] == null)
						{
							desc += q(ctss[1, 2]) + "";
						}
						else
						{
							desc +=
								q(ctss[(byte)Helper.WindowsRegistry.LanguageCode, 2])
								+ ""; // lastname
						}

						if (incdes)
						{
							if (
								ctss[(byte)Helper.WindowsRegistry.LanguageCode, 1]
								== null
							)
							{
								desc +=
									","
									+ q(ctss[1, 1])
										.Replace(",", " ")
										.Replace("\r", "")
										.Replace("\n", " ")
									+ "";
							}
							else
							{
								desc +=
									","
									+ q(
											ctss[
												(byte)
													Helper.WindowsRegistry.LanguageCode,
												1
											]
										)
										.Replace(",", " ")
										.Replace("\r", "")
										.Replace("\n", " ")
									+ ""; // description
							}
						}
					}
					catch
					{
						if (SimPe.Data.MetaData.GetKnownNPC(sdsc.SimId) != "not found")
						{
							desc = incdes
								? q(SimPe.Data.MetaData.GetKnownNPC(sdsc.SimId))
									+ ",,(NPC)"
								: q(SimPe.Data.MetaData.GetKnownNPC(sdsc.SimId))
									+ ",(NPC)";
						}
						if (desc.EndsWith(",") && incdes)
						{
							desc += ","; // if the CTSS does not have three lines, will throw trying to read lastname so we need a nuver comma
						}
					}
				}
			}
			#endregion

			#region family
			string family = ",,";
			IPackedFileDescriptor pfd = sdsc.Package.FindFile(
				0x46414D49,
				0x00000000,
				0xffffffff,
				sdsc.FamilyInstance
			); // FAMI
			if (pfd != null)
			{
				Fami fami = null;
				fami = new Fami(FileTableBase.ProviderRegistry.SimNameProvider);
				fami.ProcessData(pfd, sdsc.Package);

				family =
					sdsc.FamilyInstance
					+ ","
					+ q(sdsc.HouseholdName)
					+ ","
					+ fami.LotInstance
					+ "";
				if (fami.LotInstance != 0)
				{
					lotfams[fami.LotInstance] = sdsc.HouseholdName;
				}
			}
			#endregion

			#region ties
			string ties = ",,";
			if (eft != null)
			{
				SDesc[] p = eft.ParentSims(sdsc);
				SDesc[] s = eft.SpouseSims(sdsc);
				ties =
					(
						p == null || p.Length < 2
							? ","
							: p[0].Instance
								+ " ("
								+ p[0].SimName
								+ ")"
								+ ","
								+ p[1].Instance
								+ " ("
								+ p[1].SimName
								+ ")"
					)
					+ ","
					+ (
						s == null || s.Length < 1
							? ""
							: s[0].Instance + " (" + s[0].SimName + ")" + ""
					)
					+ "";
			}
			#endregion

			#region genetics
			string genetics =
				sdsc.GeneticCharacter.Active
				+ ","
				+ sdsc.GeneticCharacter.Neat
				+ ","
				+ sdsc.GeneticCharacter.Nice
				+ ","
				+ sdsc.GeneticCharacter.Outgoing
				+ ","
				+ sdsc.GeneticCharacter.Playful
				+ "";
			#endregion

			#region character
			string character =
				sdsc.Character.Active
				+ ","
				+ sdsc.Character.Neat
				+ ","
				+ sdsc.Character.Nice
				+ ","
				+ sdsc.Character.Outgoing
				+ ","
				+ sdsc.Character.Playful
				+ "";
			#endregion

			#region interests
			string interests =
				sdsc.Interests.Animals
				+ ","
				+ sdsc.Interests.Crime
				+ ","
				+ sdsc.Interests.Culture
				+ ","
				+ sdsc.Interests.Entertainment
				+ ","
				+ sdsc.Interests.Environment
				+ ","
				+ sdsc.Interests.Fashion
				+ ","
				+ sdsc.Interests.Food
				+ ","
				+ sdsc.Interests.Health
				+ ","
				+ sdsc.Interests.Money
				+ ","
				+ sdsc.Interests.Paranormal
				+ ","
				+ sdsc.Interests.Politics
				+ ","
				+ sdsc.Interests.School
				+ ","
				+ sdsc.Interests.Scifi
				+ ","
				+ sdsc.Interests.Sports
				+ ","
				+ sdsc.Interests.Toys
				+ ","
				+ sdsc.Interests.Travel
				+ ","
				+ sdsc.Interests.Weather
				+ ","
				+ sdsc.Interests.Work
				+ "";
			#endregion

			#region skills
			string skills =
				sdsc.Skills.Body
				+ ","
				+ sdsc.Skills.Charisma
				+ ","
				+ sdsc.Skills.Cleaning
				+ ","
				+ sdsc.Skills.Cooking
				+ ","
				+ sdsc.Skills.Creativity
				+ ","
				+ sdsc.Skills.Fatness
				+ ","
				+ sdsc.Skills.Logic
				+ ","
				+ sdsc.Skills.Mechanical;
			if (Helper.WindowsRegistry.ShowMoreSkills)
			{
				skills += "," + sdsc.Skills.Art + "," + sdsc.Skills.Music;
			}

			skills += "";
			#endregion

			#region university
			string university = "N,,,,,,";
			if (sdsc.University != null)
			{
				if (sdsc.University.OnCampus == 0x1)
				{
					university =
						"Y"
						+ ","
						+ sdsc.University.Effort
						+ ","
						+ sdsc.University.Grade
						+ ","
						+ sdsc.University.Time
						+ ","
						+ sdsc.University.Semester
						+ ","
						+ sdsc.University.Influence
						+ ","
						+ sdsc.University.Major;
				}
				else if (
					sdsc.University.Major != SimPe.Data.Majors.Unknown
					&& sdsc.University.Major != SimPe.Data.Majors.Undeclared
					&& sdsc.University.Major != SimPe.Data.Majors.Unset
				)
				{
					university = "N,,,,,," + sdsc.University.Major;
				}
			}
			#endregion

			#region business
			string business = ",,";
			if (sdsc.Business != null)
			{
				if (sdsc.Business.Salary > 0)
				{
					business = Localization.GetString(
						"SimPe.PackedFiles.Wrapper.JobAssignf."
							+ Enum.GetName(
								typeof(JobAssignment),
								(ushort)sdsc.Business.Assignment
							)
					);
					business += "," + sdsc.Business.LotID;
					business += "," + sdsc.Business.Salary;
				}
			}
			#endregion

			#region freetime
			string freetime = ",,,";
			if (sdsc.Freetime != null)
			{
				freetime =
					new SimPe.Data.LocalizedAspirationTypes(
						sdsc.Freetime.PrimaryAspiration
					).ToString()
					+ ","
					+ new SimPe.Data.LocalizedAspirationTypes(
						sdsc.Freetime.SecondaryAspiration
					).ToString()
					+ ","
					+ sdsc.Freetime.HobbyPredistined
					+ ","
					+ sdsc.Freetime.LongtermAspiration // LifetimeWant ? - NO
				;
				//sdsc.Freetime.BugCollection -- no...
			}
			#endregion

			#region apartments
			string apartments = ",";
			if (sdsc.Apartment != null)
			{
				apartments = sdsc.Apartment.Reputation + ",";
				if (sdsc.Apartment.TitlePostName > 0)
				{
					apartments += SimPe.Data.MetaData.GetTitleName(
						sdsc.Apartment.TitlePostName
					);
				}
			}
			#endregion

			#region Species
			string species = "Human";
			if (sdsc.Nightlife != null)
			{
				if (
					(int)sdsc.Version
						== (int)SDescVersions.Castaway
					&& sdsc.Castaway.Subspecies > 0
				)
				{
					if (sdsc.Castaway.Subspecies == 2)
					{
						species = "Orang-utan";
					}

					if (
						sdsc.Castaway.Subspecies == 1
						&& (int)sdsc.Nightlife.Species == 3
					)
					{
						species = "Leopard";
					}

					if (
						sdsc.Castaway.Subspecies == 1
						&& (int)sdsc.Nightlife.Species < 3
					)
					{
						species = "Wild Dog";
					}
				}
				else
				{
					species = sdsc.Nightlife.Species.ToString();
				}
			}

			#endregion

			//sdsc.Business.LotID

			if (
				dt.Equals(new DateTime(0))
				|| wasUnk
				|| dt.AddMilliseconds(200).CompareTo(DateTime.UtcNow) < 0
			)
			{
				System.Windows.Forms.Application.DoEvents();
				if (
					!(sdsc.SimName + " " + sdsc.SimFamilyName)
						.Trim()
						.ToLower()
						.Equals("unknown")
				)
				{
					dt = new DateTime(DateTime.UtcNow.Ticks);
					wasUnk = false;
					splash("Saving " + sdsc.SimName + " " + sdsc.SimFamilyName);
				}
				else
				{
					wasUnk = true;
				}
			}

			string csv = "";
			if (incbas)
			{
				csv = hood + "," + hoodName + ",";
			}

			csv += sdsc.Instance + "," + desc + "," + family;
			if (incbas)
			{
				csv +=
					","
					+ (sdsc.AvailableCharacterData ? "Y" : "N")
					+ ","
					+ (sdsc.Unlinked != 0x00 ? "Y" : "N")
					+ ","
					+ ties
					+ ","
					+ bodycondiion(sdsc);
			}

			csv +=
				","
				+ new SimPe.Data.LocalizedServiceTypes(
					sdsc.CharacterDescription.ServiceTypes
				).ToString();
			if (incbas)
			{
				csv +=
					","
					+ new SimPe.Data.LocalizedSchoolType(
						sdsc.CharacterDescription.SchoolType
					).ToString()
					+ ","
					+ new SimPe.Data.LocalizedGrades(
						sdsc.CharacterDescription.Grade
					).ToString()
					+ ","
					+ sdsc.CharacterDescription.CareerPerformance
					+ ","
					+ new SimPe.Data.LocalizedCareers(
						sdsc.CharacterDescription.Career
					).ToString()
					+ ","
					+ sdsc.CharacterDescription.CareerLevel
					+ ","
					+ sdsc.CharacterDescription.ZodiacSign;
			}

			csv +=
				","
				+ sdsc.CharacterDescription.Gender
				+ ","
				+ sdsc.CharacterDescription.LifeSection;
			if (incbas)
			{
				csv +=
					","
					+ sdsc.CharacterDescription.Age
					+ ","
					+ sdsc.CharacterDescription.PrevAgeDays
					+ ","
					+ sdsc.CharacterDescription.AgeDuration
					+ ","
					+ sdsc.CharacterDescription.BlizLifelinePoints
					+ ","
					+ sdsc.CharacterDescription.LifelinePoints
					+ ","
					+ sdsc.CharacterDescription.LifelineScore;
			}

			if (inccha)
			{
				csv += "," + genetics + "," + character;
			}

			if (incint)
			{
				csv += "," + interests;
			}

			csv +=
				","
				+ sdsc.Interests.FemalePreference
				+ ","
				+ sdsc.Interests.MalePreference;
			if (incski)
			{
				csv += "," + skills;
			}

			if (incuni)
			{
				csv += "," + university;
			}

			if (incpet && incbas)
			{
				csv += "," + species;
			}

			if (incbus)
			{
				csv += "," + business;
			}

			if (incfre)
			{
				csv += "," + freetime;
			}

			if (incapa)
			{
				csv += "," + apartments;
			}

			csv += "";
			w.WriteLine(csv);

			if (!sdsc.HasImage)
			{
				AddImage(
					GetImage.NoOne,
					Path.Combine(
						Path.Combine(outPath, "SimImage"),
						hood + "_" + sdsc.Instance + ".png"
					)
				);
			}
			else
			{
				AddImage(
					sdsc.Image,
					Path.Combine(
						Path.Combine(outPath, "SimImage"),
						hood + "_" + sdsc.Instance + ".jpg"
					)
				);
			}
		}

		void AddLot(
			string outPath,
			string hood,
			string hoodName,
			StreamWriter w,
			Ltxt ltxt,
			string hoodtype
		)
		{
			string perv = "";
			Boolset bby = ltxt.Unknown0;
			if (bby[7])
			{
				perv = "Has Beach";
			}

			if (bby[4])
			{
				perv += " - Hidden";
			}

			Boolset tty = ltxt.Unknown4;
			if (ltxt.Type == Ltxt.LotType.Hobby)
			{
				if (tty[9])
				{
					perv += " (Music)";
				}

				if (tty[8])
				{
					perv += " (Science)";
				}

				if (tty[7])
				{
					perv += " (Fitness)";
				}

				if (tty[6])
				{
					perv += " (Tinkering)";
				}

				if (tty[5])
				{
					perv += " (Nature)";
				}

				if (tty[4])
				{
					perv += " (Games)";
				}

				if (tty[3])
				{
					perv += " (Sport)";
				}

				if (tty[2])
				{
					perv += " (Films)";
				}

				if (tty[1])
				{
					perv += " (Art)";
				}

				if (tty[0])
				{
					perv += " (Cooking)";
				}
			}

			if (
				dt.Equals(new DateTime(0))
				|| wasUnk
				|| dt.AddMilliseconds(200).CompareTo(DateTime.UtcNow) < 0
			)
			{
				dt = new DateTime(DateTime.UtcNow.Ticks);
				wasUnk = false;
				splash("Saving " + ltxt.LotName.Trim());
			}
			if (hoodtype != "Village" && hoodtype != "Lakes" && hoodtype != "Island")
			{
				if (
					lotfams[ltxt.LotDescription.Instance] == ""
					&& ltxt.Type == Ltxt.LotType.Residential
				)
				{
					lotfams[ltxt.LotDescription.Instance] = "*For Sale*";
				}
			}
			w.WriteLine(
				hood
					+ ","
					+ hoodName
					+ ","
					+ hoodtype
					+ ","
					+ (
						ltxt.LotDescription == null
							? ","
							: ltxt.LotDescription.Instance
								+ ","
								+ q(ltxt.LotName.Replace("\r", "").Replace("\n", ""))
					)
					+ ","
					+ q(Enum.GetName(typeof(Ltxt.LotType), ltxt.Type))
					+ ","
					+ lotfams[ltxt.LotDescription.Instance]
					+ ","
					+ perv
					+ ""
			); //ltxt.LotDescription.LotName
			if (ltxt.LotDescription != null)
			{
				if (ltxt.LotDescription.Image != null)
				{
					AddImage(
						ltxt.LotDescription.Image,
						Path.Combine(
							Path.Combine(outPath, "LotImage"),
							hood + "_Lot" + ltxt.FileDescriptor.Instance + ".jpg"
						)
					);
				}
				else
				{
					AddImage(
						GetImage.Network,
						Path.Combine(
							Path.Combine(outPath, "LotImage"),
							hood + "_Lot" + ltxt.FileDescriptor.Instance + ".png"
						)
					);
				}
			}
			else
			{
				AddImage(
					GetImage.Network,
					Path.Combine(
						Path.Combine(outPath, "LotImage"),
						hood + "_Lot" + ltxt.FileDescriptor.Instance + ".png"
					)
				);
			}
		}

		string bodycondiion(ExtSDesc simdsc)
		{
			string bodyflugs = "";
			if (simdsc.CharacterDescription.GhostFlag.IsGhost)
			{
				bodyflugs = "Deceased";
			}
			else
			{
				if (simdsc.CharacterDescription.BodyFlag.Value == 0)
				{
					bodyflugs = "Normal";
				}

				if (simdsc.CharacterDescription.BodyFlag.BirthControl)
				{
					bodyflugs = "BirthControl";
				}

				if (simdsc.CharacterDescription.BodyFlag.Hospital)
				{
					bodyflugs += " Hospital";
				}

				if (simdsc.CharacterDescription.BodyFlag.Fit)
				{
					bodyflugs += " Fit";
				}

				if (simdsc.CharacterDescription.BodyFlag.Fat)
				{
					bodyflugs += " Fat";
				}

				if (simdsc.CharacterDescription.BodyFlag.PregnantHidden)
				{
					bodyflugs += " Pregnant";
				}

				if (simdsc.CharacterDescription.BodyFlag.PregnantHalf)
				{
					bodyflugs += " PregnantHalf";
				}

				if (simdsc.CharacterDescription.BodyFlag.PregnantFull)
				{
					bodyflugs += " PregnantFull";
				}
			}
			return bodyflugs;
		}

		void AddImage(Image img, string f)
		{
			if (img != null)
			{
				if (img.Size.Width > 16 && img.Size.Height > 16)
				{
					img.Save(f);
				}
				else
				{
					System.Diagnostics.Trace.WriteLine(
						"img too small: "
							+ Path.GetFileNameWithoutExtension(f)
							+ ";w="
							+ img.Width
							+ ";h="
							+ img.Height
					);
				}
			}
		}

		#region ITool Members

		SimPe.Interfaces.Plugin.IToolResult ITool.ShowDialog(
			ref IPackedFileDescriptor pfd,
			ref IPackageFile package
		)
		{
			if (!Directory.Exists(PathProvider.Global.NeighborhoodFolder))
			{
				System.Windows.Forms.MessageBox.Show(
					"The Folder "
						+ PathProvider.Global.NeighborhoodFolder
						+ " was not found.\n"
						+ "Please specify the correct SaveGame Folder in the Options Dialog."
				);
				return new ToolResult(false, false);
			}

			System.Windows.Forms.FolderBrowserDialog fbd =
				new System.Windows.Forms.FolderBrowserDialog
				{
					Description = "Choose the folder for extracted Sim data",
					SelectedPath = PathProvider.SimSavegameFolder,
					ShowNewFolderButton = true
				};
			System.Windows.Forms.DialogResult dr = fbd.ShowDialog();
			if (dr != System.Windows.Forms.DialogResult.OK)
			{
				return new ToolResult(false, false);
			}

			NeighborhoodForm nfm = new NeighborhoodForm
			{
				LoadNgbh = false,
				ShowBackupManager = false,
				ShowSubHoods = false,
				Text = "Close window without selection to extract all"
			};
			SimPe.Interfaces.Plugin.IToolResult ret = nfm.Execute(ref package, null);

			string hood = "";
			if (
				nfm.DialogResult == System.Windows.Forms.DialogResult.OK
				&& nfm.SelectedNgbh != null
			)
			{
				hood = Path.GetFileName(Path.GetDirectoryName(nfm.SelectedNgbh));
			}

			Settims sf = new Settims
			{
				Text = hood
			};
			sf.ShowDialog();

			try
			{
				WaitingScreen.Wait();
				splash = delegate (string message)
				{
					WaitingScreen.UpdateMessage(message);
				};
				Rufio(fbd.SelectedPath, hood, 0);
				return new ToolResult(false, false);
			}
			finally
			{
				WaitingScreen.UpdateImage(null);
				WaitingScreen.Stop();
			}
		}

		bool ITool.IsEnabled(
			IPackedFileDescriptor pfd,
			IPackageFile package
		)
		{
			return true;
		}

		#endregion

		#region IToolPlugin Members

		string IToolPlugin.ToString()
		{
			return "Neighborhood\\Export Neighborhoods...";
		}

		#endregion

		#region IToolExt Member
		public override Image Icon => GetIcon.HoodTool;
		#endregion

		#region ICommandLine Members

		public bool Parse(List<string> argv)
		{
			int i = ArgParser.Parse(argv, "-rufio");
			if (i < 0)
			{
				return false;
			}

			string outpath = "";
			string hood = "";
			string group = "";
			int groupno = 0;
			bool dun = getim.Settings;
			bool previ = Helper.WindowsRegistry.LoadTableAtStartup;
			Helper.WindowsRegistry.LoadTableAtStartup = false;
			while (argv.Count > i)
			{
				if (ArgParser.Parse(argv, i, "-out", ref outpath))
				{
					continue;
				}

				if (ArgParser.Parse(argv, i, "-hood", ref hood))
				{
					continue;
				}

				if (ArgParser.Parse(argv, i, "-group", ref group))
				{
					continue;
				}

				Message.Show(Help()[0]);
				return true;
			}

			if (outpath.Length > 0 && !Directory.Exists(outpath))
			{
				Message.Show("Use -out specify an existing folder");
				return true;
			}

			if (!Directory.Exists(PathProvider.Global.NeighborhoodFolder))
			{
				Message.Show(
					"The Folder "
						+ PathProvider.Global.NeighborhoodFolder
						+ " was not found.\r\n"
						+ "Please specify the correct SaveGame Folder in the Options Dialog."
				);
				return false;
			}

			if (group.Length > 0)
			{
				try
				{
					groupno = Convert.ToInt32(group);
					if (
						groupno < 1
						|| (groupno & PathProvider.Global.AvailableGroups) == 0
					)
					{
						throw new FormatException();
					}
				}
				catch (FormatException)
				{
					Message.Show(
						"Invalid group.  Please specify a group from expansions.xreg."
					);
					return false;
				}
			}

			splash = delegate (string message)
			{
				SimPe.Splash.Screen.SetMessage(message);
			};
			Rufio(outpath, hood, groupno);
			splash("");
			Helper.WindowsRegistry.LoadTableAtStartup = previ;
			return true;
		}

		public string[] Help()
		{
			return new string[]
			{
				"-rufio -out {outpath} {-hood hood} {-group group}",
				"Export Neighborhood data",
			};
		}

		#endregion
	}
}
