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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Ambertation.Windows.Forms;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for ExtSDescUI.
	/// </summary>
	public partial class ExtSDesc
		:
		//System.Windows.Forms.UserControl
		Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		System.Resources.ResourceManager strresources;

		public ExtSDesc()
		{
			strresources = new System.Resources.ResourceManager(typeof(ExtSDesc));
			Text = Localization.GetString("Sim Description Editor");

			// Required designer variable.
			InitializeComponent();
			Initialize();

			biId.Tag = pnId;
			biSkill.Tag = pnSkill;
			biChar.Tag = pnChar;
			biCareer.Tag = pnCareer;
			biEP1.Tag = pnEP1;
			biEP2.Tag = pnEP2;
			biEP3.Tag = pnEP3;
			biEP6.Tag = pnVoyage;
			biEP7.Tag = pnEP7;
			biEP9.Tag = pnEP9;
			biInt.Tag = pnInt;
			biRel.Tag = pnRel;
			biMisc.Tag = pnMisc;

			tbsim.ReadOnly = !UserVerification.HaveUserId;
			miRelink.Enabled = (UserVerification.HaveUserId);
			tbBugColl.ReadOnly = !UserVerification.HaveUserId;

			if (Helper.StartedGui == Executable.Classic)
			{
				biId.TextImageRelation = TextImageRelation.Overlay;
				biId.Image = null;
				biSkill.TextImageRelation = TextImageRelation.Overlay;
				biSkill.Image = null;
				biChar.TextImageRelation = TextImageRelation.Overlay;
				biChar.Image = null;
				biCareer.TextImageRelation = TextImageRelation.Overlay;
				biCareer.Image = null;
				biEP1.TextImageRelation = TextImageRelation.Overlay;
				biEP1.Image = null;
				biEP2.TextImageRelation = TextImageRelation.Overlay;
				biEP2.Image = null;
				biEP3.TextImageRelation = TextImageRelation.Overlay;
				biEP3.Image = null;
				biEP6.TextImageRelation = TextImageRelation.Overlay;
				biEP6.Image = null;
				biEP7.TextImageRelation = TextImageRelation.Overlay;
				biEP7.Image = null;
				biEP9.TextImageRelation = TextImageRelation.Overlay;
				biEP9.Image = null;
				biInt.TextImageRelation = TextImageRelation.Overlay;
				biInt.Image = null;
				biRel.TextImageRelation = TextImageRelation.Overlay;
				biRel.Image = null;
				biMisc.TextImageRelation = TextImageRelation.Overlay;
				biMisc.Image = null;
				biMax.TextImageRelation = TextImageRelation.Overlay;
				biMax.Image = null;
				biMore.TextImageRelation = TextImageRelation.Overlay;
				biMore.Image = null;
				biLezby.TextImageRelation = TextImageRelation.Overlay;
				biLezby.Image = null;
			}

			InitDropDowns();
			SelectButton(biId);

			InternalChange = true;
			pbLastGrade.DisplayOffset = System
					.Threading
					.Thread
					.CurrentThread
					.CurrentUICulture
					.TwoLetterISOLanguageName == "en"
				? 0
				: 1;

			InternalChange = false;

			lv.SimDetails = true;
		}

		Image pnimage = null;
		bool loadedRel;
		string CurHood = "";

		void Initialize()
		{
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				llep3openinfo.Font = new Font(
					"Tahoma",
					12,
					FontStyle.Bold
				);
				llep3openinfo.Height = 24;
				lbTraits.Font = new Font("Tahoma", 11);
				lbTurnOn.Font = new Font("Tahoma", 11);
				lbTurnOff.Font = new Font("Tahoma", 11);
				if (Screen.PrimaryScreen.WorkingArea.Width > 1600)
				{
					ilCollectibles.ImageSize = new Size(64, 64);
				}
			}
			else
			{
				llep3openinfo.Font = new Font(
					"Tahoma",
					llep3openinfo.Font.Size,
					FontStyle.Bold
				);
				llep3openinfo.Height = 16;
			}
			//this.llep3openinfo.Icon = SimPe.GetIcon.BnfoIco;

			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(ExtSDesc));
			Commited += new EventHandler(ExtSDesc_Commited);

			srcRel = new CommonSrel();
			dstRel = new CommonSrel();
			//
			// srcRel
			//
			srcRel.Dock = DockStyle.Fill;
			srcRel.Enabled = false;
			srcRel.Name = "srcRed";
			srcRel.Srel = null;
			srcRel.Visible = true;
			//
			// dstRel
			//
			dstRel.Dock = DockStyle.Fill;
			dstRel.Enabled = false;
			dstRel.Name = "dstRel";
			dstRel.Srel = null;
			dstRel.Visible = true;

			srcTb.Controls.Add(srcRel);
			dstTb.Controls.Add(dstRel);

			dstTb.Top = srcTb.Bottom;
		}

		public void SelectButton(ToolStripButton b)
		{
			for (int i = 0; i < toolBar1.Items.Count; i++)
			{
				if (toolBar1.Items[i] is ToolStripButton item)
				{
					item.Checked = (item == b);

					if (item.Tag != null)
					{
						Panel pn = (Panel)item.Tag;

						if (pn == pnChar)
						{
							SetCharacterAttributesVisibility();
						}
						pn.Visible = item.Checked;
					}
				}
			}

			mbiMax.Enabled = miRand.Enabled =
				pnSkill.Visible || pnChar.Visible || pnInt.Visible || pnRel.Visible;
			miOpenSCOR.Enabled =
				(int)PathProvider.Global.Latest.Expansion >= (int)Expansions.Business;
		}

		private void ChoosePage(object sender, EventArgs e)
		{
			SelectButton((ToolStripButton)sender);
		}

		void AddAspiration(
			ComboBox cb,
			MetaData.AspirationTypes exclude,
			MetaData.AspirationTypes asp
		)
		{
			if (
				(ushort)exclude == 0xFFFF
				|| exclude == MetaData.AspirationTypes.Nothing
				|| asp != exclude
			)
			{
				cb.Items.Add(new LocalizedAspirationTypes(asp));
			}
		}

		void SetAspirations(ComboBox cb)
		{
			SetAspirations(cb, (MetaData.AspirationTypes)0xffff);
		}

		void SetAspirations(ComboBox cb, MetaData.AspirationTypes exclude)
		{
			cb.Items.Clear();
			AddAspiration(cb, exclude, MetaData.AspirationTypes.Nothing);
			AddAspiration(cb, exclude, MetaData.AspirationTypes.Fortune);
			AddAspiration(cb, exclude, MetaData.AspirationTypes.Family);
			AddAspiration(cb, exclude, MetaData.AspirationTypes.Knowledge);
			AddAspiration(cb, exclude, MetaData.AspirationTypes.Reputation);
			AddAspiration(cb, exclude, MetaData.AspirationTypes.Romance);
			AddAspiration(cb, exclude, MetaData.AspirationTypes.Growup);
			AddAspiration(cb, exclude, MetaData.AspirationTypes.Pleasure);
			AddAspiration(cb, exclude, MetaData.AspirationTypes.Chees);
			// AddAspiration(cb, exclude, Data.MetaData.AspirationTypes.Power);
		}

		void SelectAspiration(ComboBox cb, MetaData.AspirationTypes val)
		{
			if (cb.Items.Count == 0)
			{
				return;
			}

			cb.SelectedIndex = 0;
			for (int i = 0; i < cb.Items.Count; i++)
			{
				MetaData.AspirationTypes at = (LocalizedAspirationTypes)
					cb.Items[i];
				if (at == val)
				{
					cb.SelectedIndex = i;
					break;
				}
			}
		}

		void InitDropDowns()
		{
			SetAspirations(cbaspiration);
			SetAspirations(cbaspiration2);

			cblifesection.Items.Clear();
			cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Unknown)
			);
			cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Baby)
			);
			cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Toddler)
			);
			cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Child)
			);
			cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Teen)
			);
			cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Adult)
			);
			cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Elder)
			);

			cbcareer.Items.Clear();
			foreach (
				Interfaces.IAlias a in
					PackedFiles
					.Wrapper
					.SDesc
					.AddonCarrers
			)
			{
				cbcareer.Items.Add(a);
			}

			cbcareer.Items.Add(
				new LocalizedCareers(MetaData.Careers.Unknown)
			);
			cbcareer.Items.Add(
				new LocalizedCareers(MetaData.Careers.Unemployed)
			);
			if (
				Helper.WindowsRegistry.LoadOnlySimsStory == 28
				&& !Helper.WindowsRegistry.HiddenMode
			)
			{
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Crafter)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Gatherer)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Hunter)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.OrangutanCrafter)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.OrangutanGatherer)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.OrangutanHunter)
				);

				for (int j = 0; j < cbcareer.Items.Count; j++)
				{
					cbRetirement.Items.Add(cbcareer.Items[j]);
				}

				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderCrafter)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderGatherer)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderHunter)
				);
			}
			else
			{
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Science)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Medical)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Politics)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Athletic)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.LawEnforcement)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Culinary)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Economy)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Slacker)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Criminal)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Military)
				);
				if (
					PathProvider.Global.GetExpansion(Expansions.University).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Paranormal)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.NaturalScientist)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.ShowBiz)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Artist)
					);
				}
				if (
					PathProvider
						.Global.GetExpansion(Expansions.IslandStories)
						.Exists || Helper.WindowsRegistry.HiddenMode
				)
				{
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Crafter)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Gatherer)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Hunter)
					);
				}
				if (
					PathProvider.Global.GetExpansion(Expansions.Seasons).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Adventurer)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Education)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Gamer)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Journalism)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Law)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Music)
					);
				}
				if (
					PathProvider.Global.GetExpansion(Expansions.FreeTime).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Construction)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Dance)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Entertainment)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Intelligence)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Ocenography)
					);
				}
				if (
					PathProvider
						.Global.GetExpansion(Expansions.LifeStories)
						.Exists || Helper.WindowsRegistry.HiddenMode
				)
				{
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.EntertainLS)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.GameDevelopment)
					);
				}
				if (
					PathProvider.Global.GetExpansion(Expansions.Business).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.OwnedBuss)
					);
				}

				for (int i = 0; i < cbcareer.Items.Count; i++)
				{
					cbRetirement.Items.Add(cbcareer.Items[i]);
				}

				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderAthletic)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderBusiness)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderCriminal)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderCulinary)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderLawEnforcement)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderMedical)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderMilitary)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderPolitics)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderScience)
				);
				cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderSlacker)
				);
				if (
					PathProvider.Global.GetExpansion(Expansions.Seasons).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderAdventurer)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderEducation)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderGamer)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderJournalism)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderLaw)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderMusic)
					);
				}
				if (
					PathProvider
						.Global.GetExpansion(Expansions.IslandStories)
						.Exists || Helper.WindowsRegistry.HiddenMode
				)
				{
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderCrafter)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderGatherer)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderHunter)
					);
				}
				if (
					PathProvider.Global.GetExpansion(Expansions.FreeTime).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					cbcareer.Items.Add(
						new LocalizedCareers(
							MetaData.Careers.TeenElderConstruction
						)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderDance)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(
							MetaData.Careers.TeenElderEntertainment
						)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(
							MetaData.Careers.TeenElderIntelligence
						)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderOcenography)
					);
				}
				if (
					PathProvider.Global.GetExpansion(Expansions.Business).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenOwnedBuss)
					);
				}
				if (
					PathProvider.Global.GetExpansion(Expansions.Pets).Exists
					|| PathProvider
						.Global.GetExpansion(Expansions.PetStories)
						.Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.PetSecurity)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.PetService)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.PetShowBiz)
					);
					cbRetirement.Items.Add(
						new LocalizedCareers(MetaData.Careers.PetSecurity)
					);
					cbRetirement.Items.Add(
						new LocalizedCareers(MetaData.Careers.PetService)
					);
					cbRetirement.Items.Add(
						new LocalizedCareers(MetaData.Careers.PetShowBiz)
					);
				}
				if (
					PathProvider
						.Global.GetExpansion(Expansions.IslandStories)
						.Exists || Helper.WindowsRegistry.HiddenMode
				)
				{
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.OrangutanCrafter)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.OrangutanGatherer)
					);
					cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.OrangutanHunter)
					);
					cbRetirement.Items.Add(
						new LocalizedCareers(MetaData.Careers.OrangutanCrafter)
					);
					cbRetirement.Items.Add(
						new LocalizedCareers(MetaData.Careers.OrangutanGatherer)
					);
					cbRetirement.Items.Add(
						new LocalizedCareers(MetaData.Careers.OrangutanHunter)
					);
				}
			}

			cbgrade.Items.Clear();
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.Unknown));
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.APlus));
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.A));
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.AMinus));
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.BPlus));
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.B));
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.BMinus));
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.CPlus));
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.C));
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.CMinus));
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.DPlus));
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.D));
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.DMinus));
			cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.F));

			cbmajor.Items.Clear();
			foreach (
				Interfaces.IAlias a in PackedFiles.Wrapper.SDesc.AddonMajors
			)
			{
				cbmajor.Items.Add(a);
			}

			Array majors = Enum.GetValues(typeof(Majors));
			foreach (Majors c in majors)
			{
				cbmajor.Items.Add(c);
			}

			cbschooltype.Items.Clear();
			foreach (
				Interfaces.IAlias a in
					PackedFiles
					.Wrapper
					.SDesc
					.AddonSchools
			)
			{
				cbschooltype.Items.Add(a);
			}

			cbschooltype.Items.Add(
				new LocalizedSchoolType(MetaData.SchoolTypes.NoSchool)
			);
			cbschooltype.Items.Add(
				new LocalizedSchoolType(MetaData.SchoolTypes.PrivateSchool)
			);
			cbschooltype.Items.Add(
				new LocalizedSchoolType(MetaData.SchoolTypes.PublicSchool)
			);

			cbzodiac.Items.Clear();
			for (ushort i = 0x01; i <= 0x0C; i++)
			{
				cbzodiac.Items.Add(
					new LocalizedZodiacSignes((MetaData.ZodiacSignes)i)
				);
			}

			cbservice.Items.Clear();
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Normal)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Bartenderb)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Bartenderp)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Boss)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Burglar)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Driver)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Streaker)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Coach)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.LunchLady)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Cop)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Delivery)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Exterminator)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.FireFighter)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Gardener)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Barista)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Grim)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Handy)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Headmistress)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Matchmaker)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Maid)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.MailCarrier)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Nanny)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Paper)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Pizza)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Professor)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.EvilMascot)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Repo)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.CheerLeader)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Mascot)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.SocialBunny)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.SocialWorker)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Register)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Therapist)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Chinese)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Podium)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Waitress)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Chef)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.DJ)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Crumplebottom)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Vampyre)
			);
			if (
				(
					PathProvider.Global.GetExpansion(Expansions.Business).Exists
					|| PathProvider.Global.STInstalled >= 28
				) || Helper.WindowsRegistry.HiddenMode
			)
			{
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Servo)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Reporter)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Salon)
				);
			}
			if (
				(
					PathProvider.Global.GetExpansion(Expansions.Pets).Exists
					|| PathProvider.Global.STInstalled >= 28
				) || Helper.WindowsRegistry.HiddenMode
			)
			{
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Wolf)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.WolfLOTP)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Skunk)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.AnimalControl)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Obedience)
				);
			}
			if (
				(
					PathProvider.Global.GetExpansion(Expansions.Voyage).Exists
					|| PathProvider
						.Global.GetExpansion(Expansions.IslandStories)
						.Exists
					|| PathProvider
						.Global.GetExpansion(Expansions.PetStories)
						.Exists
				) || Helper.WindowsRegistry.HiddenMode
			)
			{
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Masseuse)
				);
			}

			if (
				(
					PathProvider.Global.GetExpansion(Expansions.Voyage).Exists
					|| PathProvider
						.Global.GetExpansion(Expansions.IslandStories)
						.Exists
				) || Helper.WindowsRegistry.HiddenMode
			)
			{
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Bellhop)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Villain)
				);
			}
			if (
				PathProvider.Global.GetExpansion(Expansions.Voyage).Exists
				|| Helper.WindowsRegistry.HiddenMode
			)
			{
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.TourGuide)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Hermit)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Ninja)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.BigFoot)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Housekeeper)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.FoodStandChef)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.FireDancer)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.WitchDoctor)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.GhostCaptain)
				);
			}
			if (
				PathProvider.Global.GetExpansion(Expansions.FreeTime).Exists
				|| (Helper.WindowsRegistry.HiddenMode)
			)
			{
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.FoodJudge)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Genie)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.exDJ)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.exGypsy)
				);
			}
			if (
				PathProvider.Global.GetExpansion(Expansions.Apartments).Exists
				|| (Helper.WindowsRegistry.HiddenMode)
			)
			{
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Witch1)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Breakdancer)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.SpectralCat)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Statue)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Landlord)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Butler)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.hotdogchef)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.assistant)
				);
				cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.exWitch2)
				);
			}

			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.icontrol)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Pandora)
			);
			cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.DMASim)
			);

			cbEp3Asgn.ResourceManager = Localization.Manager;
			cbEp3Asgn.Enum = typeof(Wrapper.JobAssignment);

			cbSpecies.ResourceManager = Localization.Manager;
			cbSpecies.Enum =
				typeof(Wrapper.SdscNightlife.SpeciesType);

			cbHobbyPre.ResourceManager = Localization.Manager;
			cbHobbyPre.Enum = typeof(Wrapper.Hobbies);

			for (int i = 0; i < cbHobbyEnth.Items.Count; i++)
			{
				Wrapper.Hobbies hb =
					PackedFiles.Wrapper.SdscFreetime.IndexToHobbies((ushort)i);
				Type type = typeof(Wrapper.Hobbies);
				cbHobbyEnth.Items[i] = Localization.GetString(
					type.Namespace + "." + type.Name + "." + hb.ToString()
				);
			}

			string es = MetaData.GetTitleName(4); // to intialize the dictionary
			foreach (
				KeyValuePair<short, string> kvp in MetaData.TitlePostName
			)
			{
				cbpostTitle.Items.Add(kvp.Value);
			}
		}

		#region IPackedFileUI Member
		public Wrapper.ExtSDesc Sdesc => (Wrapper.ExtSDesc)Wrapper;

		Plugin.Subhoods shs = new Plugin.Subhoods();

		protected override void RefreshGUI()
		{
			loadedRel = false;
			InternalChange = true;
			try
			{
				base.RefreshGUI();

				miOpenChar.Enabled = (
					System.IO.File.Exists(Sdesc.CharacterFileName) && !Sdesc.IsNPC
				);
				miRelink.Enabled = (
					(UserVerification.HaveUserId)
					&& !Sdesc.IsNPC
					&& Helper.IsNeighborhoodFile(Sdesc.Package.FileName)
				);
				miOpenDNA.Enabled = miOpenCloth.Enabled = !Sdesc.IsNPC;
				tbsimdescname.ReadOnly = tbsimdescfamname.ReadOnly =
					Sdesc.IsNPC;
				btOriGuid.Visible = lbFixedRes.Visible = false;

				miOpenChar.Text = System.IO.File.Exists(Sdesc.CharacterFileName)
					? strresources.GetString("miOpenChar.Text")
						+ " ("
						+ System.IO.Path.GetFileNameWithoutExtension(
							Sdesc.CharacterFileName
						)
						+ ")"
					: strresources.GetString("miOpenChar.Text");

				if (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.Apartment
					&& Sdesc.Nightlife.Species == 0
					&& Helper.StartedGui == Executable.Default
				)
				{
					HeaderText =
						Sdesc.SimName
						+ " "
						+ MetaData.GetTitleName(
							Sdesc.Apartment.TitlePostName
						);
					pnimage = null;
				}
				else
				{
					HeaderText = Sdesc.SimName;
					biLezby.Visible = false;
					pnimage = null;
				}

				RefreshSkills(Sdesc);
				RefreshId(Sdesc);
				RefreshCareer(Sdesc);
				RefreshCharcter(Sdesc);
				RefreshInterests(Sdesc);
				RefreshMisc(Sdesc);

				biRel.Enabled = Helper.IsNeighborhoodFile(Sdesc.Package.FileName);
				biEP1.Enabled = (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.University
					&& Sdesc.Nightlife.Species == 0
					&& (int)Sdesc.Version
						!= (int)PackedFiles.Wrapper.SDescVersions.Castaway
				);
				biEP2.Enabled = (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.Nightlife
					&& Sdesc.Nightlife.Species == 0
				);
				biEP3.Enabled = (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.Business
					&& Sdesc.Nightlife.Species == 0
					&& (int)Sdesc.Version
						!= (int)PackedFiles.Wrapper.SDescVersions.Castaway
				);
				biEP6.Enabled = (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.Voyage
					&& Sdesc.Nightlife.Species == 0
					&& PathProvider.Global.EPInstalled > 9
				);
				biEP7.Enabled = (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.Freetime
					&& Sdesc.Nightlife.Species == 0
				);
				biEP9.Enabled = (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.Apartment
					&& Sdesc.Nightlife.Species == 0
				);
				cbSpecies.Enabled = (
					(int)Sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Pets
				);
				if (pnRel.Visible && !biRel.Enabled)
				{
					SelectButton(biId);
				}

				if (pnEP1.Visible && !biEP1.Enabled)
				{
					SelectButton(biId);
				}

				if (pnEP2.Visible && !biEP2.Enabled)
				{
					SelectButton(biId);
				}

				if (pnEP3.Visible && !biEP3.Enabled)
				{
					SelectButton(biId);
				}

				if (pnVoyage.Visible && !biEP6.Enabled)
				{
					SelectButton(biId);
				}

				if (pnEP7.Visible && !biEP7.Enabled)
				{
					SelectButton(biId);
				}

				if (pnEP9.Visible && !biEP9.Enabled)
				{
					SelectButton(biId);
				}

				if (biRel.Enabled)
				{
					pnRel_VisibleChanged(null, null);
				}

				if (biEP1.Enabled)
				{
					RefreshEP1(Sdesc);
				}

				if (biEP2.Enabled || cbSpecies.Enabled)
				{
					RefreshEP2(Sdesc);
				}

				if (biEP3.Enabled)
				{
					RefreshEP3(Sdesc);
				}

				if (cbSpecies.Enabled)
				{
					RefreshEP4(Sdesc);
				}
				else
				{
					cbSpecies.SelectedValue =
						PackedFiles
						.Wrapper
						.SdscNightlife
						.SpeciesType
						.Human;
				}

				if (biEP6.Enabled)
				{
					RefreshEP6(Sdesc);
				}

				if (biEP7.Enabled)
				{
					RefreshEP7(Sdesc);
				}
				//if (biEP9.Enabled) RefreshEP9(Sdesc);
			}
			finally
			{
				SetCharacterAttributesVisibility();
				InternalChange = false;
			}
		}

		void RefreshEP1(Wrapper.ExtSDesc sdesc)
		{
			cbmajor.SelectedIndex = 0;
			tbmajor.Text = "0x" + Helper.HexString((uint)sdesc.University.Major);
			cbmajor.SelectedIndex = cbmajor.Items.Count - 1;
			for (int i = 0; i < cbmajor.Items.Count; i++)
			{
				object o = cbmajor.Items[i];
				Majors at = o.GetType() == typeof(Alias) ? (Majors)((Alias)o).Id : (Majors)o;

				if (at == sdesc.University.Major)
				{
					cbmajor.SelectedIndex = i;
					break;
				}
			}

			cboncampus.Checked = (sdesc.University.OnCampus == 0x1);
			pbEffort.Value = sdesc.University.Effort;
			pbLastGrade.Value = sdesc.University.Grade;

			pbUniTime.Value = sdesc.University.Time;
			tbinfluence.Text = sdesc.University.Influence.ToString();
			tbsemester.Text = sdesc.University.Semester.ToString();

			cbfreshman.Checked = Sdesc.University.SemesterFlag.Freshman;
			cbSopho.Checked = Sdesc.University.SemesterFlag.Sophomore;
			cbJunior.Checked = Sdesc.University.SemesterFlag.Junior;
			cbSenior.Checked = Sdesc.University.SemesterFlag.Senior;
			cbGoodsem.Checked = Sdesc.University.SemesterFlag.GoodSem;
			cbprobation.Checked = Sdesc.University.SemesterFlag.Probation;
			cbgraduate.Checked = Sdesc.University.SemesterFlag.Graduated;
			cbatclass.Checked = Sdesc.University.SemesterFlag.AtClass;
			cbdroped.Checked = Sdesc.University.SemesterFlag.Dropped;
			cbexpelled.Checked = Sdesc.University.SemesterFlag.Expelled;

			pnEP1.BackgroundImage = pnimage;
		}

		void RefreshSkills(Wrapper.ExtSDesc sdesc) // Updated Dog skills only for T&A, A&N or Pet Story
		{
			// should not be reading Nightlife.Species if version is below Pets !!
			if ((int)Sdesc.Version >= (int)PackedFiles.Wrapper.SDescVersions.Pets)
			{
				if (
					(
						(int)Sdesc.Nightlife.Species == 1
						|| (int)Sdesc.Nightlife.Species == 2
					)
					&& (
						(
							Helper.WindowsRegistry.ShowPetAbilities
							&& Helper.WindowsRegistry.LoadOnlySimsStory == 0
						)
						|| Helper.WindowsRegistry.LoadOnlySimsStory == 29
					)
				)
				{
					pbPupbody.Value = sdesc.Skills.Body;
					pbPupCharisma.Value = sdesc.Skills.Charisma;
					pbPupClean.Value = sdesc.Skills.Cleaning;
					pbPupCreative.Value = sdesc.Skills.Creativity;
					pbPupLogic.Value = sdesc.Skills.Logic;
					pbPupMech.Value = sdesc.Skills.Mechanical;
					pbFat.Value = sdesc.Skills.Fatness;
					pbBody.Visible = false;
					pbCharisma.Visible = false;
					pbClean.Visible = false;
					pbCreative.Visible = false;
					pbMusic.Visible = false;
					pbArty.Visible = false;
					pbLogic.Visible = false;
					pbMech.Visible = false;
					pbCooking.Visible = false;
					pbReputate.Visible = false;
					pbPupbody.Visible = true;
					pbPupCharisma.Visible = true;
					pbPupClean.Visible = true;
					pbPupCreative.Visible = true;
					pbPupLogic.Visible = true;
					pbPupMech.Visible = true;
				}
				else
				{
					if ((int)Sdesc.Nightlife.Species > 0)
					{
						pbFat.Value = sdesc.Skills.Fatness;
						pbBody.Visible = false;
						pbCharisma.Visible = false;
						pbClean.Visible = false;
						pbCreative.Visible = false;
						pbLogic.Visible = false;
						pbMech.Visible = false;
						pbCooking.Visible = false;
						pbPupbody.Visible = false;
						pbPupCharisma.Visible = false;
						pbPupClean.Visible = false;
						pbPupCreative.Visible = false;
						pbPupLogic.Visible = false;
						pbPupMech.Visible = false;
						pbMusic.Visible = false;
						pbArty.Visible = false;
						pbReputate.Visible = false;
					}
					else
					{
						pbBody.Value = sdesc.Skills.Body;
						pbCharisma.Value = sdesc.Skills.Charisma;
						pbClean.Value = sdesc.Skills.Cleaning;
						pbCooking.Value = sdesc.Skills.Cooking;
						pbCreative.Value = sdesc.Skills.Creativity;
						pbFat.Value = sdesc.Skills.Fatness;
						pbLogic.Value = sdesc.Skills.Logic;
						pbMech.Value = sdesc.Skills.Mechanical;
						pbMusic.Value = sdesc.Skills.Music;
						pbArty.Value = sdesc.Skills.Art;
						pbPupbody.Visible = false;
						pbPupCharisma.Visible = false;
						pbPupClean.Visible = false;
						pbPupCreative.Visible = false;
						pbPupLogic.Visible = false;
						pbPupMech.Visible = false;
						pbBody.Visible = true;
						pbCharisma.Visible = true;
						pbClean.Visible = true;
						pbCreative.Visible = true;
						pbMusic.Visible = Helper.WindowsRegistry.ShowMoreSkills;
						pbArty.Visible = Helper.WindowsRegistry.ShowMoreSkills;
						pbLogic.Visible = true;
						pbReputate.Visible = true;
						pbMech.Visible = true;
						pbCooking.Visible = true;
						if (
							(int)Sdesc.Version
							>= (int)PackedFiles.Wrapper.SDescVersions.Apartment
						)
						{
							pbReputate.Value = sdesc.Apartment.Reputation;
							pbReputate.Visible = true;
						}
						else
						{
							pbReputate.Visible = false;
						}
					}
				}
				pnSkill.BackgroundImage = pnimage;
			}
			else
			{
				pbBody.Value = sdesc.Skills.Body;
				pbCharisma.Value = sdesc.Skills.Charisma;
				pbClean.Value = sdesc.Skills.Cleaning;
				pbCooking.Value = sdesc.Skills.Cooking;
				pbCreative.Value = sdesc.Skills.Creativity;
				pbFat.Value = sdesc.Skills.Fatness;
				pbLogic.Value = sdesc.Skills.Logic;
				pbMech.Value = sdesc.Skills.Mechanical;
				pbMusic.Value = sdesc.Skills.Music;
				pbArty.Value = sdesc.Skills.Art;
				pbPupbody.Visible = false;
				pbPupCharisma.Visible = false;
				pbPupClean.Visible = false;
				pbPupCreative.Visible = false;
				pbPupLogic.Visible = false;
				pbPupMech.Visible = false;
				pbBody.Visible = true;
				pbCharisma.Visible = true;
				pbClean.Visible = true;
				pbCreative.Visible = true;
				pbMusic.Visible = Helper.WindowsRegistry.ShowMoreSkills;
				pbArty.Visible = Helper.WindowsRegistry.ShowMoreSkills;
				pbLogic.Visible = true;
				pbMech.Visible = true;
				pbCooking.Visible = true;
				pbReputate.Visible = false;
			}
		}

		void RefreshMisc(Wrapper.ExtSDesc sdesc)
		{
			tbdecScratc.Visible = lbdecScratc.Visible = (
				sdesc.Nightlife.Species > 0
			);
			tbdecShop.Visible = lbdecShop.Visible = (
				sdesc.Nightlife.Species == 0
			);

			//ghostflags
			cbisghost.Checked = sdesc.CharacterDescription.GhostFlag.IsGhost;
			cbpassobject.Checked = sdesc
				.CharacterDescription
				.GhostFlag
				.CanPassThroughObjects;
			cbpasswalls.Checked = sdesc
				.CharacterDescription
				.GhostFlag
				.CanPassThroughWalls;
			cbpasspeople.Checked = sdesc
				.CharacterDescription
				.GhostFlag
				.CanPassThroughPeople;
			cbignoretraversal.Checked = sdesc
				.CharacterDescription
				.GhostFlag
				.IgnoreTraversalCosts;

			//body flags
			cbfit.Checked = sdesc.CharacterDescription.BodyFlag.Fit;
			cbfat.Checked = sdesc.CharacterDescription.BodyFlag.Fat;
			cbpregfull.Checked = sdesc.CharacterDescription.BodyFlag.PregnantFull;
			cbpreghalf.Checked = sdesc.CharacterDescription.BodyFlag.PregnantHalf;
			cbpreginv.Checked = sdesc.CharacterDescription.BodyFlag.PregnantHidden;

			//misc
			tbprevdays.Text = sdesc.CharacterDescription.PrevAgeDays.ToString();
			tbagedur.Text = sdesc.CharacterDescription.AgeDuration.ToString();
			tbunlinked.Text = "0x" + Helper.HexString(sdesc.Unlinked);
			tbvoice.Text =
				"0x" + Helper.HexString(sdesc.CharacterDescription.VoiceType);
			tbautonomy.Text =
				"0x" + Helper.HexString(sdesc.CharacterDescription.AutonomyLevel);
			tbnpc.Text =
				"0x" + Helper.HexString(sdesc.CharacterDescription.NPCType);
			tbstatmot.Text =
				"0x" + Helper.HexString(sdesc.CharacterDescription.MotivesStatic);

			//motive decays
			tbdecHunger.Text = Convert.ToString(sdesc.Decay.Hunger);
			tbdecComfort.Text = Convert.ToString(sdesc.Decay.Comfort);
			tbdecBladder.Text = Convert.ToString(sdesc.Decay.Bladder);
			tbdecEnergy.Text = Convert.ToString(sdesc.Decay.Energy);
			tbdecHygiene.Text = Convert.ToString(sdesc.Decay.Hygiene);
			tbdecSocial.Text = Convert.ToString(sdesc.Decay.Social);
			tbdecShop.Text = Convert.ToString(sdesc.Decay.Shopping);
			tbdecFun.Text = Convert.ToString(sdesc.Decay.Fun);
			tbdecAmor.Text = Convert.ToString(sdesc.Decay.Amorous);
			tbdecScratc.Text = Convert.ToString(sdesc.Decay.ScratchC);

			if (
				(int)sdesc.Version
				>= (int)PackedFiles.Wrapper.SDescVersions.Nightlife
			)
			{
				tbpersonflags.Visible = tbMotiveDec.Visible = true;
				cbpflycar.Visible =
					cbpflyact.Visible =
					cbpfrunaw.Visible =
					cbpfPlant.Visible =
						(
							(int)sdesc.Version
							>= (int)PackedFiles.Wrapper.SDescVersions.Pets
						);
				cbpfBigf.Visible = (
					(int)sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Voyage
				);
				cbpfwitch.Visible = cbpfroomy.Visible = (
					(int)sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Apartment
				);
				cbpfZomb.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsZombie;
				cbpfperma.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.PermaPlatinum;
				cbpfvamp.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsVampire;
				cbpfvsmoke.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.VampireSmoke;
				cbpfwants.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.WantHistory;
				cbpflycar.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.LycanCarrier;
				cbpflyact.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.LycanActive;
				cbpfrunaw.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsRunaway;
				cbpfPlant.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsPlantsim;
				cbpfBigf.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsBigfoot;
				cbpfwitch.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsWitch;
				cbpfroomy.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsRoomate;
			}
			else
			{
				tbpersonflags.Visible = tbMotiveDec.Visible = false;
			}

			pnMisc.BackgroundImage = pnimage;
		}

		void RefreshId(Wrapper.ExtSDesc sdesc)
		{
			pnId.BackgroundImage = pnimage;
			tbage.Text = sdesc.CharacterDescription.Age.ToString();
			tbsimdescname.Text = sdesc.SimName;
			tbsimdescfamname.Text = sdesc.SimFamilyName;
			tbsim.Text = "0x" + Helper.HexString(sdesc.SimId);
			tbsim.ReadOnly = !UserVerification.HaveUserId;
			tbfaminst.Text = "0x" + Helper.HexString(sdesc.FamilyInstance);
			tbsinstance.Text = "0x" + Helper.HexString(sdesc.Instance);
			lbHousname.Text = "(" + sdesc.HouseholdName + ")";
			btOriGuid.Enabled = (
				!sdesc.IsNPC && System.IO.File.Exists(sdesc.CharacterFileName)
			); // may need to disable more

			Image img = null;

			if (sdesc.Image != null)
			{
				if (sdesc.Image.Width > 5)
				{
					img = Ambertation.Drawing.GraphicRoutines.KnockoutImage(
						sdesc.Image,
						new Point(0, 0),
						Color.Magenta
					);
				}
			}

			if (img == null)
			{
				img = sdesc.CharacterDescription.Gender == MetaData.Gender.Female ? GetImage.SheOne : GetImage.NoOne;
			}

			img = Ambertation.Windows.Forms.Graph.ImagePanel.CreateThumbnail(
				img,
				pbImage.Size,
				12,
				Color.FromArgb(90, Color.Black),
				PackedFiles.Wrapper.SimPoolControl.GetImagePanelColor(Sdesc),
				Color.White,
				Color.FromArgb(80, Color.White),
				true,
				4,
				0
			);
			pbImage.Image = img;

			//Lifesection
			cblifesection.SelectedIndex = 0;
			for (int i = 0; i < cblifesection.Items.Count; i++)
			{
				MetaData.LifeSections at = (LocalizedLifeSections)
					cblifesection.Items[i];
				if (at == sdesc.CharacterDescription.LifeSection)
				{
					cblifesection.SelectedIndex = i;
					break;
				}
			}

			rbfemale.Checked = (
				sdesc.CharacterDescription.Gender == MetaData.Gender.Female
			);
			rbmale.Checked = (
				sdesc.CharacterDescription.Gender == MetaData.Gender.Male
			);

			//NPC Type
			cbservice.SelectedIndex = 0;
			for (int i = 0; i < cbservice.Items.Count; i++)
			{
				object o = cbservice.Items[i];
				MetaData.ServiceTypes at = o.GetType() == typeof(Alias) ? (MetaData.ServiceTypes)(LocalizedServiceTypes)((Alias)o).Id : (MetaData.ServiceTypes)(LocalizedServiceTypes)o;

				if (at == sdesc.CharacterDescription.ServiceTypes)
				{
					cbservice.SelectedIndex = i;
					break;
				}
			}

			if (
				(int)sdesc.Version
					== (int)PackedFiles.Wrapper.SDescVersions.Castaway
				&& sdesc.Castaway.Subspecies > 0
			)
			{
				if (sdesc.Castaway.Subspecies == 2)
				{
					lbsubspec.Text = "Sub Species: Orang-utan";
					lbsubspec.Visible = true;
				}
				if (sdesc.Castaway.Subspecies == 1 && (int)sdesc.Nightlife.Species == 3)
				{
					lbsubspec.Text = "Sub Species: Leopard";
					lbsubspec.Visible = true;
				}
				if (sdesc.Castaway.Subspecies == 1 && (int)sdesc.Nightlife.Species < 3)
				{
					lbsubspec.Text = "Sub Species: Wild Dog";
					lbsubspec.Visible = true;
				}
			}
			else
			{
				lbsubspec.Visible = false;
			}

			lbSplitChar.Visible = sdesc.IsCharSplit;
		}

		void RefreshCareer(Wrapper.ExtSDesc sdesc)
		{
			lpRetirement.Enabled =
				cbRetirement.Enabled =
				tbpension.Enabled =
					sdesc.CharacterDescription.Realage > 19;
			pbCareerLevel.Value = sdesc.CharacterDescription.CareerLevel;
			lpRetirement.Value = sdesc.CharacterDescription.RetiredLevel;
			pbCareerPerformance.Value = sdesc
				.CharacterDescription
				.CareerPerformance;
			tbaccholidays.Text = Convert.ToString(
				(float)sdesc.CharacterDescription.PTO / 100
			);
			tbpension.Text = sdesc.CharacterDescription.Pension.ToString();

			//Career
			tbcareervalue.Text =
				"0x" + Helper.HexString((uint)sdesc.CharacterDescription.Career);
			cbcareer.SelectedIndex = 0;
			for (int i = 0; i < cbcareer.Items.Count; i++)
			{
				object o = cbcareer.Items[i];
				MetaData.Careers at = o.GetType() == typeof(Alias) ? (MetaData.Careers)(LocalizedCareers)((Alias)o).Id : (MetaData.Careers)(LocalizedCareers)o;

				if (at == sdesc.CharacterDescription.Career)
				{
					cbcareer.SelectedIndex = i;
					break;
				}
			}

			cbRetirement.SelectedIndex = 0;
			for (int i = 0; i < cbRetirement.Items.Count; i++)
			{
				object o = cbRetirement.Items[i];
				MetaData.Careers at = o.GetType() == typeof(Alias) ? (MetaData.Careers)(LocalizedCareers)((Alias)o).Id : (MetaData.Careers)(LocalizedCareers)o;

				if (at == sdesc.CharacterDescription.Retired)
				{
					cbRetirement.SelectedIndex = i;
					break;
				}
			}

			//school
			cbschooltype.SelectedIndex = 0;
			tbschooltype.Visible = true;
			for (int i = 0; i < cbschooltype.Items.Count; i++)
			{
				LocalizedSchoolType type;
				object o = cbschooltype.Items[i];
				type = o.GetType() == typeof(Alias) ? (LocalizedSchoolType)((Alias)o).Id : (LocalizedSchoolType)o;

				if (
					sdesc.CharacterDescription.SchoolType
					== (MetaData.SchoolTypes)type
				)
				{
					cbschooltype.SelectedIndex = i;
					break;
				}
			}

			tbschooltype.Text =
				"0x" + Helper.HexString((uint)sdesc.CharacterDescription.SchoolType);

			//grades and school
			cbgrade.SelectedIndex = 0;
			for (int i = 0; i < cbgrade.Items.Count; i++)
			{
				MetaData.Grades grade;
				object o = cbgrade.Items[i];
				grade = o.GetType() == typeof(Alias) ? (MetaData.Grades)(LocalizedGrades)((Alias)o).Id : (MetaData.Grades)(LocalizedGrades)o;

				if (sdesc.CharacterDescription.Grade == grade)
				{
					cbgrade.SelectedIndex = i;
					break;
				}
			}
			//Aspiration
			pbAspBliz.Value = sdesc.CharacterDescription.BlizLifelinePoints;
			pbAspCur.Value = sdesc.CharacterDescription.LifelinePoints;
			SelectAspiration(cbaspiration, sdesc.Freetime.PrimaryAspiration);
			tblifelinescore.Text =
				sdesc.CharacterDescription.LifelineScore.ToString();
			pnCareer.BackgroundImage = pnimage;
			cbaspiration.Enabled = (int)sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Freetime
				&& !Helper.WindowsRegistry.AllowChangeOfSecondaryAspiration
				? sdesc.Freetime.SecondaryAspiration
					== MetaData.AspirationTypes.Nothing
				: true;
		}

		void RefreshInterests(Wrapper.ExtSDesc sdesc)
		{
			pbAnimals.Value = sdesc.Interests.Animals;
			pbCrime.Value = sdesc.Interests.Crime;
			pbCulture.Value = sdesc.Interests.Culture;
			pbEntertainment.Value = sdesc.Interests.Entertainment;
			pbEnvironment.Value = sdesc.Interests.Environment;
			pbFashion.Value = sdesc.Interests.Fashion;
			pbFood.Value = sdesc.Interests.Food;
			pbHealth.Value = sdesc.Interests.Health;
			pbMoney.Value = sdesc.Interests.Money;
			pbParanormal.Value = sdesc.Interests.Paranormal;
			pbPolitics.Value = sdesc.Interests.Politics;
			pbSchool.Value = sdesc.Interests.School;
			pbSciFi.Value = sdesc.Interests.Scifi;
			pbSports.Value = sdesc.Interests.Sports;
			pbToys.Value = sdesc.Interests.Toys;
			pbTravel.Value = sdesc.Interests.Travel;
			pbWeather.Value = sdesc.Interests.Weather;
			pbWork.Value = sdesc.Interests.Work;

			pbPetEating.Value = sdesc.Interests.Environment;
			pbPetWeather.Value = sdesc.Interests.Food;
			pbPetPlaying.Value = sdesc.Interests.Culture;
			pbPetSpooky.Value = sdesc.Interests.Money;
			pbPetSleep.Value = sdesc.Interests.Entertainment;
			pbPetToy.Value = sdesc.Interests.Health;
			pbPetPets.Value = sdesc.Interests.Politics;
			pbPetOutside.Value = sdesc.Interests.Crime;
			pbPetAnimals.Value = sdesc.Interests.Fashion;

			pnInt.BackgroundImage = pnimage;
		}

		void RefreshCharcter(Wrapper.ExtSDesc sdesc)
		{
			cbzodiac.SelectedIndex = (
				(ushort)sdesc.CharacterDescription.ZodiacSign - 1
			);

			//Character
			pbNeat.Value = sdesc.Character.Neat;
			pbOutgoing.Value = sdesc.Character.Outgoing;
			pbActive.Value = sdesc.Character.Active;
			pbPlayful.Value = sdesc.Character.Playful;
			pbNice.Value = sdesc.Character.Nice;

			//Genetic Character
			pbGNeat.Value = sdesc.GeneticCharacter.Neat;
			pbGOutgoing.Value = sdesc.GeneticCharacter.Outgoing;
			pbGActive.Value = sdesc.GeneticCharacter.Active;
			pbGPlayful.Value = sdesc.GeneticCharacter.Playful;
			pbGNice.Value = sdesc.GeneticCharacter.Nice;

			pbWoman.Value = sdesc.Interests.FemalePreference;
			pbMan.Value = sdesc.Interests.MalePreference;
			pnChar.BackgroundImage = pnimage;
		}
		#endregion

		private void Activate_biMax(object sender, EventArgs e)
		{
			if (pnSkill.Visible)
			{
				InternalChange = true;
				foreach (Control c in pnSkill.Controls)
				{
					if (c == pbFat)
					{
						((LabeledProgressBar)c).Value = 0;
					}
					else if (c is LabeledProgressBar && c.Visible == true)
					{
						((LabeledProgressBar)c).Value =
							((LabeledProgressBar)c).Maximum - 1;
					}
				}
				InternalChange = false;
				ChangedSkill(null, null);
			}
			else if (pnChar.Visible)
			{
				InternalChange = true;
				foreach (Control c in pnHumanChar.Controls)
				{
					if (c is LabeledProgressBar)
					{
						((LabeledProgressBar)c).Value = ((LabeledProgressBar)c).Maximum;
					}
				}

				InternalChange = false;
				ChangedChar(null, null);
			}
			else if (pnInt.Visible)
			{
				InternalChange = true;
				foreach (Control c in pnPetInt.Controls)
				{
					if (c is LabeledProgressBar)
					{
						((LabeledProgressBar)c).Value = ((LabeledProgressBar)c).Maximum;
					}
				}

				foreach (Control c in pnSimInt.Controls)
				{
					if (c is LabeledProgressBar)
					{
						((LabeledProgressBar)c).Value = ((LabeledProgressBar)c).Maximum;
					}
				}

				InternalChange = false;
				ChangedInt(null, null);
			}
			else if (pnRel.Visible)
			{
				int index = -1;
				if (lv.SelectedIndices.Count > 0)
				{
					index = lv.SelectedIndices[0];
				}

				foreach (SteepValley.Windows.Forms.XPListViewItem lvi in lv.Items)
				{
					if (lvi.GroupIndex != 1)
					{
						lvi.Selected = true;
						lv_SelectedSimChanged(lv, null, null);
						if (srcRel.Srel != null)
						{
							srcRel.Srel.Longterm = 100;
							srcRel.Srel.Shortterm = 100;
							srcRel.Srel.Changed = true;
						}

						if (dstRel.Srel != null)
						{
							dstRel.Srel.Longterm = 100;
							dstRel.Srel.Shortterm = 100;
							dstRel.Srel.Changed = true;
						}
					}
				}
				if (index >= 0)
				{
					lv.Items[index].Selected = true;
				}
				else if (lv.Items.Count > 0)
				{
					lv.Items[0].Selected = true;
				}
			}
			else if (pnEP9.Visible)
			{
				InternalChange = true;
				pbRomance.Value = pbRomance.Maximum;
				//intern = false; this.ChangedVarious(null, null);
			}
		}

		private void Activate_biRand(object sender, EventArgs e)
		{
			Random rnd = new Random();
			if (pnSkill.Visible)
			{
				InternalChange = true;
				foreach (Control c in pnSkill.Controls)
				{
					if (c is LabeledProgressBar)
					{
						((LabeledProgressBar)c).Value = rnd.Next(
							((LabeledProgressBar)c).Maximum
						);
					}
				}

				InternalChange = false;
				ChangedSkill(null, null);
			}
			else if (pnChar.Visible)
			{
				InternalChange = true;
				foreach (Control c in pnHumanChar.Controls)
				{
					if (c is LabeledProgressBar)
					{
						((LabeledProgressBar)c).Value = rnd.Next(
							((LabeledProgressBar)c).Maximum
						);
					}
				}

				InternalChange = false;
				ChangedSkill(null, null);
			}
			else if (pnInt.Visible)
			{
				InternalChange = true;
				foreach (Control c in pnPetInt.Controls)
				{
					if (c is LabeledProgressBar)
					{
						((LabeledProgressBar)c).Value = rnd.Next(
							((LabeledProgressBar)c).Maximum
						);
					}
				}

				foreach (Control c in pnSimInt.Controls)
				{
					if (c is LabeledProgressBar)
					{
						((LabeledProgressBar)c).Value = rnd.Next(
							((LabeledProgressBar)c).Maximum
						);
					}
				}

				InternalChange = false;
				ChangedSkill(null, null);
			}
			else if (pnRel.Visible)
			{
				foreach (SteepValley.Windows.Forms.XPListViewItem lvi in lv.Items)
				{
					if (lvi.GroupIndex != 1)
					{
						lvi.Selected = true;
						int baseval = rnd.Next(200) - 100;
						if (srcRel.Srel != null)
						{
							srcRel.Srel.Longterm = Math.Max(
								-100,
								Math.Min(100, baseval + rnd.Next(40) - 20)
							);
							srcRel.Srel.Shortterm = Math.Max(
								-100,
								Math.Min(100, baseval + rnd.Next(40) - 20)
							);
							srcRel.Srel.Changed = true;
						}

						if (dstRel.Srel != null)
						{
							dstRel.Srel.Longterm = Math.Max(
								-100,
								Math.Min(100, baseval + rnd.Next(40) - 20)
							);
							dstRel.Srel.Shortterm = Math.Max(
								-100,
								Math.Min(100, baseval + rnd.Next(40) - 20)
							);
							dstRel.Srel.Changed = true;
						}
					}
				}
				if (lv.Items.Count > 0)
				{
					lv.Items[0].Selected = true;
				}
			}
		}

		private void ExtSDesc_Commited(object sender, EventArgs e)
		{
			Sdesc.SynchronizeUserData();
		}

		private void cbmajor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbmajor.SelectedIndex < 0)
			{
				return;
			}

			object o = cbmajor.Items[cbmajor.SelectedIndex];
			Majors v = o.GetType() == typeof(Alias) ? (Majors)((Alias)o).Id : (Majors)o;

			if (v == Majors.Unknown)
			{
				return;
			}

			tbmajor.Text = "0x" + Helper.HexString((uint)v);
		}

		private void cbcareer_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbcareer.SelectedIndex < 0)
			{
				return;
			}

			object o = cbcareer.Items[cbcareer.SelectedIndex];
			if (o.GetType() != typeof(Alias))
			{
				MetaData.Careers career = (LocalizedCareers)o;
				if (career != MetaData.Careers.Unknown)
				{
					tbcareervalue.Text = "0x" + Helper.HexString((uint)career);
				}
			}
			else
			{
				Alias a = (Alias)o;
				tbcareervalue.Text = "0x" + Helper.HexString(a.Id);
			}
		}

		private void cbRetirement_SelectedIndexChanged(
			object sender,
			EventArgs e
		)
		{
			if (InternalChange)
			{
				return;
			}

			if (cbRetirement.SelectedIndex < 0)
			{
				return;
			}

			uint rec = 0;
			object o = cbRetirement.Items[cbRetirement.SelectedIndex];
			if (o.GetType() != typeof(Alias))
			{
				MetaData.Careers retired = (LocalizedCareers)o;
				if (retired != MetaData.Careers.Unknown)
				{
					rec = (uint)retired;
				}
			}
			else
			{
				Alias a = (Alias)o;
				rec = a.Id;
			}
			Sdesc.CharacterDescription.Retired = (MetaData.Careers)rec;
		}

		private void cbschooltype_SelectedIndexChanged(
			object sender,
			EventArgs e
		)
		{
			if (cbschooltype.SelectedIndex < 0)
			{
				return;
			}

			object o = cbschooltype.Items[cbschooltype.SelectedIndex];
			if (o.GetType() != typeof(Alias))
			{
				MetaData.SchoolTypes st = (LocalizedSchoolType)o;
				if (st != MetaData.SchoolTypes.Unknown)
				{
					tbschooltype.Text = "0x" + Helper.HexString((uint)st);
				}
			}
			else
			{
				Alias a = (Alias)o;
				tbschooltype.Text = "0x" + Helper.HexString(a.Id);
			}
		}

		private void Activate_biLezby(object sender, EventArgs e)
		{
			InternalChange = true;

			Wrapper.SimDNA sdna;
			Random slt = new Random();
			uint booty = 0;
			Interfaces.Files.IPackedFileDescriptor pfd = Sdesc.Package.NewDescriptor(
				MetaData.SDNA,
				Sdesc.FileDescriptor.SubType,
				Sdesc.FileDescriptor.Group,
				Sdesc.FileDescriptor.Instance
			);
			pfd = Sdesc.Package.FindFile(pfd);
			if (pfd != null)
			{
				sdna = new Wrapper.SimDNA();
				sdna.ProcessData(pfd, Sdesc.Package, true);
				booty = MetaData.GetBodyShapeid(sdna.Dominant.Skintone);
			}
			else
			{
				booty = 0;
			}

			Sdesc.Interests.Animals = (ushort)slt.Next(400, 600);
			Sdesc.Interests.Crime = (ushort)slt.Next(400, 600);
			Sdesc.Interests.Culture = (ushort)slt.Next(400, 600);
			Sdesc.Interests.Entertainment = (ushort)slt.Next(600, 1000);
			Sdesc.Interests.Environment = (ushort)slt.Next(400, 600);
			Sdesc.Interests.Fashion = (ushort)slt.Next(700, 1000);
			Sdesc.Interests.Food = (ushort)slt.Next(400, 600);
			Sdesc.Interests.Health = (ushort)slt.Next(400, 600);
			Sdesc.Interests.Money = (ushort)slt.Next(400, 600);
			Sdesc.Interests.Paranormal = 10;
			Sdesc.Interests.Politics = (ushort)slt.Next(400, 600);
			Sdesc.Interests.School = (ushort)slt.Next(400, 600);
			Sdesc.Interests.Scifi = (ushort)slt.Next(100);
			Sdesc.Interests.Sports = (ushort)slt.Next(400, 600);
			Sdesc.Interests.Toys = (ushort)slt.Next(400, 800);
			Sdesc.Interests.Travel = (ushort)slt.Next(600, 1000);
			Sdesc.Interests.Weather = (ushort)slt.Next(400, 600);
			Sdesc.Interests.Work = (ushort)slt.Next(400, 600);
			Sdesc.Skills.Body = 800;
			Sdesc.Skills.Charisma = 800;
			Sdesc.Skills.Cooking = 800;
			Sdesc.Skills.Cleaning = 800;
			Sdesc.Skills.Creativity = 800;
			Sdesc.Skills.Logic = 800;
			Sdesc.Skills.Mechanical = 800;
			Sdesc.Skills.Fatness = 0;
			Sdesc.Skills.Romance = 1000;
			Sdesc.Skills.Art = 800;
			Sdesc.Skills.Music = 800;
			Sdesc.Character.Neat = (ushort)slt.Next(400, 800);
			Sdesc.Character.Outgoing = (ushort)slt.Next(100, 1000);
			Sdesc.Character.Active = (ushort)slt.Next(400, 800);
			Sdesc.Character.Playful = (ushort)slt.Next(800, 1000);
			Sdesc.Character.Nice = (ushort)slt.Next(850, 1000);
			Sdesc.GeneticCharacter.Neat = Sdesc.Character.Neat;
			Sdesc.GeneticCharacter.Outgoing = Sdesc.Character.Outgoing;
			Sdesc.GeneticCharacter.Active = Sdesc.Character.Active;
			Sdesc.GeneticCharacter.Playful = Sdesc.Character.Playful;
			Sdesc.GeneticCharacter.Nice = Sdesc.Character.Nice;
			Sdesc.CharacterDescription.BodyFlag.Fit = true;
			Sdesc.CharacterDescription.BodyFlag.Fat = false;
			Sdesc.Freetime.HobbyPredistined = PackedFiles.Wrapper.Hobbies.Nature;

			//if (Sdesc.CharacterDescription.Gender == Data.MetaData.Gender.Female)
			//{
			//	Sdesc.Interests.FemalePreference = 1000;
			//	Sdesc.Interests.MalePreference = 100;
			//	Sdesc.Nightlife.AttractionTurnOns2 = 32735;
			//	if (booty != 0) // Real NPCs don't have dna so this should save them
			//		Sdesc.CharacterDescription.Bodyshape = (Data.MetaData.Bodyshape)booty;
			//}
			//else
			//{
			//	Sdesc.Interests.FemalePreference = 1000;
			//	Sdesc.Interests.MalePreference = -100;
			//	Sdesc.Nightlife.AttractionTurnOns2 = 32735;
			//	if (booty != 0)
			//	{
			//		if (booty != 0x13 && booty != 0x1e)
			//			Sdesc.CharacterDescription.Bodyshape = Data.MetaData.Bodyshape.LeanBB;
			//		else
			//			Sdesc.CharacterDescription.Bodyshape = (Data.MetaData.Bodyshape)booty;
			//	}
			//}
			Sdesc.Nightlife.AttractionTurnOns1 = 30329;
			Sdesc.Nightlife.AttractionTurnOns3 = 3840;
			Sdesc.Nightlife.AttractionTurnOffs1 = 128;
			Sdesc.Nightlife.AttractionTurnOffs2 = 0;
			Sdesc.Nightlife.AttractionTurnOffs3 = 0;

			if (Sdesc.FamilyInstance > 32512)
			{
				Sdesc.CharacterDescription.PersonFlags1.WantHistory = true;
			}

			RefreshSkills(Sdesc);
			RefreshCharcter(Sdesc);
			RefreshInterests(Sdesc);
			RefreshMisc(Sdesc);
			RefreshEP2(Sdesc);
			RefreshEP7(Sdesc);
			//RefreshEP9(Sdesc);
			InternalChange = false;
		}

		#region Changing Data
		protected bool InternalChange
		{
			get; set;
		}

		private void ChangedId(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
				Sdesc.SimId = Helper.StringToUInt32(tbsim.Text, Sdesc.SimId, 16);
				Sdesc.FamilyInstance = Helper.StringToUInt16(
					tbfaminst.Text,
					Sdesc.FamilyInstance,
					16
				);
				Sdesc.Instance = Helper.StringToUInt16(
					tbsinstance.Text,
					Sdesc.Instance,
					16
				);

				Sdesc.CharacterDescription.Age = Helper.StringToUInt16(
					tbage.Text,
					Sdesc.CharacterDescription.Age,
					10
				);
				if (Sdesc.SimName != tbsimdescname.Text)
				{
					Sdesc.SimName = tbsimdescname.Text;
				}

				if (Sdesc.SimFamilyName != tbsimdescfamname.Text)
				{
					Sdesc.SimFamilyName = tbsimdescfamname.Text;
				}

				tbsim.ReadOnly = !UserVerification.HaveUserId;

				//Lifesection
				Sdesc.CharacterDescription.LifeSection = (LocalizedLifeSections)
					cblifesection.SelectedItem;

				Sdesc.CharacterDescription.Gender = rbfemale.Checked ? MetaData.Gender.Female : MetaData.Gender.Male;

				Sdesc.Nightlife.Species =
					(Wrapper.SdscNightlife.SpeciesType)
						cbSpecies.SelectedValue;

				if (
					(int)Sdesc.Version
						== (int)PackedFiles.Wrapper.SDescVersions.Castaway
					&& Sdesc.Castaway.Subspecies > 0
				)
				{
					if (Sdesc.Castaway.Subspecies == 2)
					{
						lbsubspec.Text = "Sub Species: Orang-utan";
						lbsubspec.Visible = true;
					}
					if (
						Sdesc.Castaway.Subspecies == 1
						&& (int)Sdesc.Nightlife.Species == 3
					)
					{
						lbsubspec.Text = "Sub Species: Leopard";
						lbsubspec.Visible = true;
					}
					if (
						Sdesc.Castaway.Subspecies == 1
						&& (int)Sdesc.Nightlife.Species < 3
					)
					{
						lbsubspec.Text = "Sub Species: Wild Dog";
						lbsubspec.Visible = true;
					}
				}
				else
				{
					lbsubspec.Visible = false;
				}

				Sdesc.Changed = true;

				//if (biEP9.Enabled) RefreshEP9(Sdesc);
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void cbservice_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
				Sdesc.CharacterDescription.NPCType = (ushort)
					(LocalizedServiceTypes)cbservice.SelectedItem;
				tbnpc.Text =
					"0x" + Helper.HexString(Sdesc.CharacterDescription.NPCType);
				if (btOriGuid.Enabled)
				{
					btOriGuid.Visible = true;
				}

				Sdesc.Changed = true;
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void ChangedRel(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void ChangedInt(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
				if (IsHumanoid())
				{
					Sdesc.Interests.Animals = (ushort)pbAnimals.Value;
					Sdesc.Interests.Crime = (ushort)pbCrime.Value;
					Sdesc.Interests.Culture = (ushort)pbCulture.Value;
					Sdesc.Interests.Entertainment = (ushort)pbEntertainment.Value;
					Sdesc.Interests.Environment = (ushort)pbEnvironment.Value;
					Sdesc.Interests.Fashion = (ushort)pbFashion.Value;
					Sdesc.Interests.Food = (ushort)pbFood.Value;
					Sdesc.Interests.Health = (ushort)pbHealth.Value;
					Sdesc.Interests.Money = (ushort)pbMoney.Value;
					Sdesc.Interests.Paranormal = (ushort)pbParanormal.Value;
					Sdesc.Interests.Politics = (ushort)pbPolitics.Value;
					Sdesc.Interests.School = (ushort)pbSchool.Value;
					Sdesc.Interests.Scifi = (ushort)pbSciFi.Value;
					Sdesc.Interests.Sports = (ushort)pbSports.Value;
					Sdesc.Interests.Toys = (ushort)pbToys.Value;
					Sdesc.Interests.Travel = (ushort)pbTravel.Value;
					Sdesc.Interests.Weather = (ushort)pbWeather.Value;
					Sdesc.Interests.Work = (ushort)pbWork.Value;
				}
				else
				{
					Sdesc.Interests.Environment = (ushort)pbPetEating.Value;
					Sdesc.Interests.Food = (ushort)pbPetWeather.Value;
					Sdesc.Interests.Culture = (ushort)pbPetPlaying.Value;
					Sdesc.Interests.Money = (ushort)pbPetSpooky.Value;
					Sdesc.Interests.Entertainment = (ushort)pbPetSleep.Value;
					Sdesc.Interests.Health = (ushort)pbPetToy.Value;
					Sdesc.Interests.Politics = (ushort)pbPetPets.Value;
					Sdesc.Interests.Crime = (ushort)pbPetOutside.Value;
					Sdesc.Interests.Fashion = (ushort)pbPetAnimals.Value;
				}

				Sdesc.Changed = true;
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void ChangedCareer(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
				Sdesc.CharacterDescription.CareerLevel = (ushort)
					pbCareerLevel.Value;
				Sdesc.CharacterDescription.CareerPerformance = (short)
					pbCareerPerformance.Value;
				Sdesc.CharacterDescription.RetiredLevel = (ushort)
					lpRetirement.Value;
				Sdesc.CharacterDescription.Pension = Convert.ToUInt16(
					tbpension.Text
				);

				//Career
				Sdesc.CharacterDescription.Career = (MetaData.Careers)
					Helper.StringToUInt32(
						tbcareervalue.Text,
						(uint)Sdesc.CharacterDescription.Career,
						16
					);

				//school
				Sdesc.CharacterDescription.SchoolType =
					(MetaData.SchoolTypes)
						Helper.StringToUInt32(
							tbschooltype.Text,
							(uint)Sdesc.CharacterDescription.SchoolType,
							16
						);

				//grades and school
				Sdesc.CharacterDescription.Grade = (LocalizedGrades)
					cbgrade.SelectedItem;

				// Accrued Hoildays
				Sdesc.CharacterDescription.PTO = (ushort)(
					Helper.StringToFloat(
						tbaccholidays.Text,
						Sdesc.CharacterDescription.PTO
					) * 100
				);

				//Aspiration
				Sdesc.CharacterDescription.BlizLifelinePoints = (ushort)
					pbAspBliz.Value;
				Sdesc.CharacterDescription.LifelinePoints = (short)pbAspCur.Value;
				Sdesc.Freetime.PrimaryAspiration = (LocalizedAspirationTypes)
					cbaspiration.SelectedItem;
				Sdesc.CharacterDescription.LifelineScore = Helper.StringToUInt32(
					tblifelinescore.Text,
					Sdesc.CharacterDescription.LifelineScore,
					10
				);

				Sdesc.Changed = true;
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void ChangedChar(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
				Sdesc.CharacterDescription.ZodiacSign = (MetaData.ZodiacSignes)(
					cbzodiac.SelectedIndex + 1
				);

				//Character
				Sdesc.Character.Neat = (ushort)pbNeat.Value;
				Sdesc.Character.Outgoing = (ushort)pbOutgoing.Value;
				Sdesc.Character.Active = (ushort)pbActive.Value;
				Sdesc.Character.Playful = (ushort)pbPlayful.Value;
				Sdesc.Character.Nice = (ushort)pbNice.Value;

				//Genetic Character
				Sdesc.GeneticCharacter.Neat = (ushort)pbGNeat.Value;
				Sdesc.GeneticCharacter.Outgoing = (ushort)pbGOutgoing.Value;
				Sdesc.GeneticCharacter.Active = (ushort)pbGActive.Value;
				Sdesc.GeneticCharacter.Playful = (ushort)pbGPlayful.Value;
				Sdesc.GeneticCharacter.Nice = (ushort)pbGNice.Value;

				Sdesc.Interests.FemalePreference = (short)pbWoman.Value;
				Sdesc.Interests.MalePreference = (short)pbMan.Value;

				Sdesc.Changed = true;
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void ChangedSkill(object sender, EventArgs e) // Updated Dog skills only for T&A, A&N or Pet Story
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
				// should not be reading Nightlife.Species if version is below Pets !!
				if (
					(int)Sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Pets
				)
				{
					if (
						(
							(int)Sdesc.Nightlife.Species == 1
							|| (int)Sdesc.Nightlife.Species == 2
						)
						&& (
							(
								Helper.WindowsRegistry.ShowPetAbilities
								&& Helper.WindowsRegistry.LoadOnlySimsStory == 0
							)
							|| Helper.WindowsRegistry.LoadOnlySimsStory == 29
						)
					)
					{
						Sdesc.Skills.Body = (ushort)pbPupbody.Value;
						Sdesc.Skills.Charisma = (ushort)pbPupCharisma.Value;
						Sdesc.Skills.Cleaning = (ushort)pbPupClean.Value;
						Sdesc.Skills.Creativity = (ushort)pbPupCreative.Value;
						Sdesc.Skills.Logic = (ushort)pbPupLogic.Value;
						Sdesc.Skills.Mechanical = (ushort)pbPupMech.Value;
						Sdesc.Skills.Fatness = (ushort)pbFat.Value;
						pbBody.Visible = false;
						pbCharisma.Visible = false;
						pbClean.Visible = false;
						pbCreative.Visible = false;
						pbLogic.Visible = false;
						pbMech.Visible = false;
						pbCooking.Visible = false;
						pbMusic.Visible = false;
						pbArty.Visible = false;
						pbReputate.Visible = false;
						pbPupbody.Visible = true;
						pbPupCharisma.Visible = true;
						pbPupClean.Visible = true;
						pbPupCreative.Visible = true;
						pbPupLogic.Visible = true;
						pbPupMech.Visible = true;
					}
					else
					{
						if ((int)Sdesc.Nightlife.Species > 0)
						{
							Sdesc.Skills.Fatness = (ushort)pbFat.Value;
							pbPupbody.Visible = false;
							pbPupCharisma.Visible = false;
							pbPupClean.Visible = false;
							pbPupCreative.Visible = false;
							pbPupLogic.Visible = false;
							pbPupMech.Visible = false;
							pbBody.Visible = false;
							pbCharisma.Visible = false;
							pbClean.Visible = false;
							pbCreative.Visible = false;
							pbMusic.Visible = false;
							pbArty.Visible = false;
							pbLogic.Visible = false;
							pbReputate.Visible = false;
							pbMech.Visible = false;
							pbCooking.Visible = false;
							pbReputate.Visible = false;
						}
						else
						{
							Sdesc.Skills.Body = (ushort)pbBody.Value;
							Sdesc.Skills.Charisma = (ushort)pbCharisma.Value;
							Sdesc.Skills.Cleaning = (ushort)pbClean.Value;
							Sdesc.Skills.Cooking = (ushort)pbCooking.Value;
							Sdesc.Skills.Creativity = (ushort)pbCreative.Value;
							Sdesc.Skills.Logic = (ushort)pbLogic.Value;
							Sdesc.Skills.Mechanical = (ushort)pbMech.Value;
							Sdesc.Skills.Fatness = (ushort)pbFat.Value;
							if (Helper.WindowsRegistry.ShowMoreSkills)
							{
								Sdesc.Skills.Music = (ushort)pbMusic.Value;
							}

							if (Helper.WindowsRegistry.ShowMoreSkills)
							{
								Sdesc.Skills.Art = (ushort)pbArty.Value;
							}

							pbPupbody.Visible = false;
							pbPupCharisma.Visible = false;
							pbPupClean.Visible = false;
							pbPupCreative.Visible = false;
							pbPupLogic.Visible = false;
							pbPupMech.Visible = false;
							pbBody.Visible = true;
							pbCharisma.Visible = true;
							pbClean.Visible = true;
							pbCreative.Visible = true;
							pbLogic.Visible = true;
							pbReputate.Visible = true;
							pbMech.Visible = true;
							pbCooking.Visible = true;
							pbMusic.Visible = Helper
								.WindowsRegistry
								.ShowMoreSkills;
							pbArty.Visible = Helper.WindowsRegistry.ShowMoreSkills;
							if (
								(int)Sdesc.Version
								>= (int)
									PackedFiles.Wrapper.SDescVersions.Apartment
							)
							{
								Sdesc.Apartment.Reputation = (short)
									pbReputate.Value;
								pbReputate.Visible = true;
							}
							else
							{
								pbReputate.Visible = false;
							}
						}
					}
				}
				else
				{
					Sdesc.Skills.Body = (ushort)pbBody.Value;
					Sdesc.Skills.Charisma = (ushort)pbCharisma.Value;
					Sdesc.Skills.Cleaning = (ushort)pbClean.Value;
					Sdesc.Skills.Cooking = (ushort)pbCooking.Value;
					Sdesc.Skills.Creativity = (ushort)pbCreative.Value;
					Sdesc.Skills.Logic = (ushort)pbLogic.Value;
					Sdesc.Skills.Mechanical = (ushort)pbMech.Value;
					Sdesc.Skills.Fatness = (ushort)pbFat.Value;
					if (Helper.WindowsRegistry.ShowMoreSkills)
					{
						Sdesc.Skills.Music = (ushort)pbMusic.Value;
					}

					if (Helper.WindowsRegistry.ShowMoreSkills)
					{
						Sdesc.Skills.Art = (ushort)pbArty.Value;
					}

					pbPupbody.Visible = false;
					pbPupCharisma.Visible = false;
					pbPupClean.Visible = false;
					pbPupCreative.Visible = false;
					pbPupLogic.Visible = false;
					pbPupMech.Visible = false;
					pbBody.Visible = true;
					pbCharisma.Visible = true;
					pbClean.Visible = true;
					pbCreative.Visible = true;
					pbLogic.Visible = true;
					pbReputate.Visible = true;
					pbMech.Visible = true;
					pbCooking.Visible = true;
					pbMusic.Visible = Helper.WindowsRegistry.ShowMoreSkills;
					pbArty.Visible = Helper.WindowsRegistry.ShowMoreSkills;
					pbReputate.Visible = false;
				}
				Sdesc.Changed = true;
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void ChangedOther(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
				//ghostflags
				Sdesc.CharacterDescription.GhostFlag.IsGhost = cbisghost.Checked;
				Sdesc.CharacterDescription.GhostFlag.CanPassThroughObjects =
					cbpassobject.Checked;
				Sdesc.CharacterDescription.GhostFlag.CanPassThroughWalls =
					cbpasswalls.Checked;
				Sdesc.CharacterDescription.GhostFlag.CanPassThroughPeople =
					cbpasspeople.Checked;
				Sdesc.CharacterDescription.GhostFlag.IgnoreTraversalCosts =
					cbignoretraversal.Checked;

				//body flags
				Sdesc.CharacterDescription.BodyFlag.Fit = cbfit.Checked;
				Sdesc.CharacterDescription.BodyFlag.Fat = cbfat.Checked;
				Sdesc.CharacterDescription.BodyFlag.PregnantFull =
					cbpregfull.Checked;
				Sdesc.CharacterDescription.BodyFlag.PregnantHalf =
					cbpreghalf.Checked;
				Sdesc.CharacterDescription.BodyFlag.PregnantHidden =
					cbpreginv.Checked;

				//misc
				Sdesc.CharacterDescription.PrevAgeDays = Helper.StringToUInt16(
					tbprevdays.Text,
					Sdesc.CharacterDescription.PrevAgeDays,
					10
				);
				Sdesc.CharacterDescription.AgeDuration = Helper.StringToUInt16(
					tbagedur.Text,
					Sdesc.CharacterDescription.AgeDuration,
					10
				);
				Sdesc.Unlinked = Helper.StringToUInt16(
					tbunlinked.Text,
					Sdesc.Unlinked,
					16
				);
				Sdesc.CharacterDescription.VoiceType = Helper.StringToUInt16(
					tbvoice.Text,
					Sdesc.CharacterDescription.VoiceType,
					16
				);
				Sdesc.CharacterDescription.AutonomyLevel = Helper.StringToUInt16(
					tbautonomy.Text,
					Sdesc.CharacterDescription.AutonomyLevel,
					16
				);
				Sdesc.CharacterDescription.NPCType = Helper.StringToUInt16(
					tbnpc.Text,
					Sdesc.CharacterDescription.NPCType,
					16
				);
				Sdesc.CharacterDescription.MotivesStatic = Helper.StringToUInt16(
					tbstatmot.Text,
					Sdesc.CharacterDescription.MotivesStatic,
					16
				);

				// motive decays
				Sdesc.Decay.Hunger = Helper.StringToInt16(
					tbdecHunger.Text,
					Sdesc.Decay.Hunger,
					10
				);
				Sdesc.Decay.Comfort = Helper.StringToInt16(
					tbdecComfort.Text,
					Sdesc.Decay.Comfort,
					10
				);
				Sdesc.Decay.Bladder = Helper.StringToInt16(
					tbdecBladder.Text,
					Sdesc.Decay.Bladder,
					10
				);
				Sdesc.Decay.Energy = Helper.StringToInt16(
					tbdecEnergy.Text,
					Sdesc.Decay.Energy,
					10
				);
				Sdesc.Decay.Hygiene = Helper.StringToInt16(
					tbdecHygiene.Text,
					Sdesc.Decay.Hygiene,
					10
				);
				Sdesc.Decay.Social = Helper.StringToInt16(
					tbdecSocial.Text,
					Sdesc.Decay.Social,
					10
				);
				Sdesc.Decay.Shopping = Helper.StringToInt16(
					tbdecShop.Text,
					Sdesc.Decay.Shopping,
					10
				);
				Sdesc.Decay.Fun = Helper.StringToInt16(
					tbdecFun.Text,
					Sdesc.Decay.Fun,
					10
				);
				Sdesc.Decay.Amorous = Helper.StringToInt16(
					tbdecAmor.Text,
					Sdesc.Decay.Amorous,
					10
				);
				Sdesc.Decay.ScratchC = Helper.StringToInt16(
					tbdecScratc.Text,
					Sdesc.Decay.ScratchC,
					10
				);

				//NPC Type
				cbservice.SelectedIndex = 0;
				for (int i = 0; i < cbservice.Items.Count; i++)
				{
					object o = cbservice.Items[i];
					MetaData.ServiceTypes at = o.GetType() == typeof(Alias) ? (MetaData.ServiceTypes)(LocalizedServiceTypes)((Alias)o).Id : (MetaData.ServiceTypes)(LocalizedServiceTypes)o;

					if (at == Sdesc.CharacterDescription.ServiceTypes)
					{
						cbservice.SelectedIndex = i;
						break;
					}
				}
				Sdesc.Changed = true;
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void ChangedEP1(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
				Sdesc.University.Major = (Majors)
					Helper.StringToUInt32(
						tbmajor.Text,
						(uint)Sdesc.University.Major,
						16
					);

				Sdesc.University.OnCampus = cboncampus.Checked ? (ushort)0x1 : (ushort)0x0;

				Sdesc.University.Effort = (ushort)pbEffort.Value;
				Sdesc.University.Grade = (ushort)pbLastGrade.Value;

				Sdesc.University.Time = (ushort)pbUniTime.Value;
				Sdesc.University.Influence = Helper.StringToUInt16(
					tbinfluence.Text,
					Sdesc.University.Influence,
					10
				);
				Sdesc.University.Semester = Helper.StringToUInt16(
					tbsemester.Text,
					Sdesc.University.Semester,
					10
				);
				if (
					!cbfreshman.Checked
					&& !cbSopho.Checked
					&& !cbJunior.Checked
					&& !cbSenior.Checked
				)
				{
					Sdesc.University.SemesterFlag.Freshman = true;
					Sdesc.University.SemesterFlag.Sophomore =
						Sdesc.University.SemesterFlag.Junior =
						Sdesc.University.SemesterFlag.Senior =
							false;
				}
				else
				{
					Sdesc.University.SemesterFlag.Freshman = cbfreshman.Checked;
					Sdesc.University.SemesterFlag.Sophomore = cbSopho.Checked;
					Sdesc.University.SemesterFlag.Junior = cbJunior.Checked;
					Sdesc.University.SemesterFlag.Senior = cbSenior.Checked;
				}
				Sdesc.University.SemesterFlag.GoodSem = cbGoodsem.Checked;
				Sdesc.University.SemesterFlag.Probation = cbprobation.Checked;
				Sdesc.University.SemesterFlag.Graduated = cbgraduate.Checked;
				Sdesc.University.SemesterFlag.AtClass = cbatclass.Checked;
				Sdesc.University.SemesterFlag.Dropped = cbdroped.Checked;
				Sdesc.University.SemesterFlag.Expelled = cbexpelled.Checked;

				Sdesc.Changed = true;
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void Changedfreshman(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			if (cbfreshman.Checked)
			{
				cbSopho.Checked =
					cbJunior.Checked =
					cbSenior.Checked =
						false;
			}
			InternalChange = false;
			ChangedEP1(sender, e);
		}

		private void ChangedSopho(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			if (cbSopho.Checked)
			{
				cbfreshman.Checked =
					cbJunior.Checked =
					cbSenior.Checked =
						false;
			}
			InternalChange = false;
			ChangedEP1(sender, e);
		}

		private void ChangedJunior(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			if (cbJunior.Checked)
			{
				cbSopho.Checked =
					cbfreshman.Checked =
					cbSenior.Checked =
						false;
			}
			InternalChange = false;
			ChangedEP1(sender, e);
		}

		private void ChangedSenior(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			if (cbSenior.Checked)
			{
				cbSopho.Checked =
					cbJunior.Checked =
					cbfreshman.Checked =
						false;
			}
			InternalChange = false;
			ChangedEP1(sender, e);
		}

		private void btOriGuid_Click(object sender, EventArgs e)
		{
			SimOriGuid.FixOrigGUID(Sdesc);
			lbFixedRes.Text = SimOriGuid.FixResult();
			lbFixedRes.Visible = true;
			cbSpecies.SelectedValue = Sdesc.Nightlife.Species;
			if (
				(int)Sdesc.Version
					== (int)PackedFiles.Wrapper.SDescVersions.Castaway
				&& Sdesc.Castaway.Subspecies > 0
			)
			{
				if (Sdesc.Castaway.Subspecies == 2)
				{
					lbsubspec.Text = "Sub Species: Orang-utan";
					lbsubspec.Visible = true;
				}
				if (Sdesc.Castaway.Subspecies == 1 && (int)Sdesc.Nightlife.Species == 3)
				{
					lbsubspec.Text = "Sub Species: Leopard";
					lbsubspec.Visible = true;
				}
				if (Sdesc.Castaway.Subspecies == 1 && (int)Sdesc.Nightlife.Species < 3)
				{
					lbsubspec.Text = "Sub Species: Wild Dog";
					lbsubspec.Visible = true;
				}
			}
			else
			{
				lbsubspec.Visible = false;
			}
		}

		private void cbdataflag1_CheckedChanged(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			Sdesc.CharacterDescription.PersonFlags1.IsZombie = cbpfZomb.Checked;
			Sdesc.CharacterDescription.PersonFlags1.PermaPlatinum =
				cbpfperma.Checked;
			Sdesc.CharacterDescription.PersonFlags1.IsVampire = cbpfvamp.Checked;
			Sdesc.CharacterDescription.PersonFlags1.VampireSmoke =
				cbpfvsmoke.Checked;
			Sdesc.CharacterDescription.PersonFlags1.WantHistory =
				cbpfwants.Checked;
			Sdesc.CharacterDescription.PersonFlags1.LycanCarrier =
				cbpflycar.Checked;
			Sdesc.CharacterDescription.PersonFlags1.LycanActive =
				cbpflyact.Checked;
			Sdesc.CharacterDescription.PersonFlags1.IsRunaway = cbpfrunaw.Checked;
			Sdesc.CharacterDescription.PersonFlags1.IsPlantsim = cbpfPlant.Checked;
			Sdesc.CharacterDescription.PersonFlags1.IsBigfoot = cbpfBigf.Checked;
			Sdesc.CharacterDescription.PersonFlags1.IsWitch = cbpfwitch.Checked;
			Sdesc.CharacterDescription.PersonFlags1.IsRoomate = cbpfroomy.Checked;
			Sdesc.Changed = true;
		}
		#endregion

		#region More Menu
		private void activate_miOpenScore(object sender, EventArgs e)
		{
			try
			{
				Interfaces.Files.IPackedFileDescriptor pfd =
					Sdesc.Package.NewDescriptor(
						0x3053CF74,
						Sdesc.FileDescriptor.Type,
						Sdesc.FileDescriptor.Group,
						Sdesc.FileDescriptor.Instance
					); //try a SCOR File
				pfd = Sdesc.Package.FindFile(pfd);
				RemoteControl.OpenPackedFile(pfd, Sdesc.Package);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		private void Activate_miMore(object sender, EventArgs e)
		{
			SdscExtendedForm.Execute(Sdesc);
		}

		private void Activate_biMore(object sender, EventArgs e)
		{
			if (biMore.Text == "More")
			{
				mbiLink.Show(toolBar1, new Point(443, toolBar1.Height - 2));
			}
			else
			{
				mbiLink.Show(toolBar1, new Point(507, toolBar1.Height - 2));
			}
		}

		private void Activate_miRelink(object sender, EventArgs e)
		{
			tbsim.Text = "0x" + Helper.HexString(SimRelinkForm.Execute(Sdesc));
			btOriGuid.Visible = true;
		}

		private void Activate_miOpenCHar(object sender, EventArgs e)
		{
			try
			{
				RemoteControl.OpenPackage(Sdesc.CharacterFileName);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		private void Activate_miOpenCloth(object sender, EventArgs e)
		{
			try
			{
				uint inst = Convert.ToUInt32(tbfaminst.Text, 16);
				Interfaces.Files.IPackedFileDescriptor pfd =
					Sdesc.Package.NewDescriptor(
						0x6C4F359D,
						Sdesc.FileDescriptor.SubType,
						Sdesc.FileDescriptor.Group,
						inst
					); //try a Collection File
				pfd = Sdesc.Package.FindFile(pfd);
				if (pfd != null)
				{
					RemoteControl.OpenPackedFile(pfd, Sdesc.Package);
				}
				/*
// this don't work and can never have worked, just opens character file
if (System.IO.File.Exists(Sdesc.CharacterFileName))
{
	uint inst = Convert.ToUInt32(this.tbfaminst.Text, 16);
	SimPe.Packages.GeneratableFile fl = SimPe.Packages.GeneratableFile.LoadFromFile(Sdesc.CharacterFileName);

	Interfaces.Files.IPackedFileDescriptor[] pfds = fl.FindFile(0xAC506764, 0, 0x1);
	if (pfds.Length>0)
	{
		SimPe.RemoteControl.OpenPackage(Sdesc.CharacterFileName);
		SimPe.RemoteControl.OpenPackedFile(pfds[0], fl);
	}
}*/
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		private void Activate_miFamily(object sender, EventArgs e)
		{
			try
			{
				uint inst = Convert.ToUInt32(tbfaminst.Text, 16);
				Interfaces.Files.IPackedFileDescriptor pfd =
					Sdesc.Package.NewDescriptor(
						0x46414D49,
						Sdesc.FileDescriptor.SubType,
						Sdesc.FileDescriptor.Group,
						inst
					); //try a Fami File
				pfd = Sdesc.Package.FindFile(pfd);
				RemoteControl.OpenPackedFile(pfd, Sdesc.Package);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		private void Activate_miOpenWf(object sender, EventArgs e)
		{
			try
			{
				//Open File
				Interfaces.Files.IPackedFileDescriptor pfd =
					Sdesc.Package.NewDescriptor(
						0xCD95548E,
						Sdesc.FileDescriptor.SubType,
						Sdesc.FileDescriptor.Group,
						Sdesc.FileDescriptor.Instance
					); //try a W&f File
				pfd = Sdesc.Package.FindFile(pfd);
				RemoteControl.OpenPackedFile(pfd, Sdesc.Package);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		private void Activate_miOpenMem(object sender, EventArgs e)
		{
			try
			{
				//Open File
				Interfaces.Files.IPackedFileDescriptor pfd =
					Sdesc.Package.NewDescriptor(
						0x4E474248,
						0,
						MetaData.LOCAL_GROUP,
						1
					); //try the memory Resource
				pfd = Sdesc.Package.FindFile(pfd);
				RemoteControl.OpenPackedFile(pfd, Sdesc.Package);

				object[] data = new object[]
				{
					Sdesc.FileDescriptor.Instance,
					NeighborhoodSlots.Sims,
				};
				RemoteControl.AddMessage(
					this,
					new RemoteControl.ControlEventArgs(0x4E474248, data)
				);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		private void Activate_miOpenBadge(object sender, EventArgs e)
		{
			try
			{
				//Open File
				Interfaces.Files.IPackedFileDescriptor pfd =
					Sdesc.Package.NewDescriptor(
						0x4E474248,
						0,
						MetaData.LOCAL_GROUP,
						1
					); //try the memory Resource
				pfd = Sdesc.Package.FindFile(pfd);
				RemoteControl.OpenPackedFile(pfd, Sdesc.Package);

				object[] data = new object[]
				{
					Sdesc.FileDescriptor.Instance,
					NeighborhoodSlots.SimsIntern,
				};
				RemoteControl.AddMessage(
					this,
					new RemoteControl.ControlEventArgs(0x4E474248, data)
				);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		private void Activate_miOpenDNA(object sender, EventArgs e)
		{
			try
			{
				Interfaces.Files.IPackedFileDescriptor pfd =
					Sdesc.Package.NewDescriptor(
						0xEBFEE33F,
						Sdesc.FileDescriptor.SubType,
						Sdesc.FileDescriptor.Group,
						Sdesc.FileDescriptor.Instance
					); //try a DNA File
				pfd = Sdesc.Package.FindFile(pfd);
				RemoteControl.OpenPackedFile(pfd, Sdesc.Package);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}
		#endregion

		#region Relations
		Interfaces.Files.IPackageFile lastpkg;

		private void pnRel_VisibleChanged(object sender, EventArgs e)
		{
			if (pnRel.Visible)
			{
				if (lastpkg == null)
				{
					LoadRelList();
				}
				else if (!lastpkg.Equals(Sdesc.Package))
				{
					LoadRelList();
				}
				else if (!loadedRel)
				{
					UpdateRelList();
				}

				lastpkg = Sdesc.Package;
			}
		}

		void LoadRelList()
		{
			lv.Sim = Sdesc;
			lv.Package = Sdesc == null ? null : Sdesc.Package;

			ResetLabel();
			loadedRel = true;
		}

		void UpdateRelList()
		{
			lv.Sim = Sdesc;
			lv.UpdateSimList();
			loadedRel = true;
		}

		void AddUnknownToRelList(ArrayList insts)
		{
			foreach (ushort inst in Sdesc.Relations.SimInstances)
			{
				if (!insts.Contains(inst))
				{
					Wrapper.ExtSDesc sdesc =
						new Wrapper.ExtSDesc
						{
							FileDescriptor = Sdesc.Package.NewDescriptor(
						MetaData.SIM_DESCRIPTION_FILE,
						0,
						Sdesc.FileDescriptor.Group,
						inst
					),
							Package = Sdesc.Package
						};
					SteepValley.Windows.Forms.XPListViewItem lvi = lv.Add(sdesc);
					lvi.GroupIndex = 2;

					lvi.Tag = sdesc;
				}
			}
		}

		void ResetLabel()
		{
			dstRel.Srel = null;
			srcRel.Srel = null;
			UpdateLabel();
		}

		void UpdateLabel()
		{
			Image img = null;
			srcTb.HeaderText =
				srcRel.SourceSimName
				+ " "
				+ Localization.GetString("towards")
				+ " "
				+ srcRel.TargetSimName;
			img = srcRel.TargetSim == null ? null : srcRel.Image;

			if (img != null)
			{
				//img = Ambertation.Drawing.GraphicRoutines.KnockoutImage(img, new Point(0,0), Color.Magenta);
				img = Ambertation.Drawing.GraphicRoutines.ScaleImage(
					img,
					srcTb.IconSize.Width,
					srcTb.IconSize.Height,
					true
				);
			}
			srcTb.Icon = img;

			dstTb.HeaderText =
				dstRel.SourceSimName
				+ " "
				+ Localization.GetString("towards")
				+ " "
				+ dstRel.TargetSimName;
			img = dstRel.TargetSim == null ? null : (Image)dstRel.Image.Clone();

			if (img != null)
			{
				//img = Ambertation.Drawing.GraphicRoutines.KnockoutImage(img, new Point(0,0), Color.Magenta);
				img = Ambertation.Drawing.GraphicRoutines.ScaleImage(
					img,
					srcTb.IconSize.Width,
					srcTb.IconSize.Height,
					true
				);
			}
			dstTb.Icon = img;
		}

		Wrapper.ExtSrel FindRelation(
			Wrapper.ExtSDesc src,
			Wrapper.ExtSDesc dst
		)
		{
			return PackedFiles.Wrapper.ExtSDesc.FindRelation(Sdesc, src, dst);
		}

		void DiplayRelation(
			Wrapper.ExtSDesc src,
			Wrapper.ExtSDesc dst,
			CommonSrel c
		)
		{
			if (src.Equals(dst) && (c == dstRel || !Helper.WindowsRegistry.HiddenMode))
			{
				c.Srel = null;
			}
			else
			{
				Wrapper.ExtSrel srel = FindRelation(src, dst);
				c.Srel = srel;
				Sdesc.AddRelationToCache(srel);
			}
		}

		void lv_SelectedSimChanged(
			object sender,
			Image thumb,
			Wrapper.SDesc sdesc
		)
		{
			SelectedSimRelationChanged(sender, null);
		}

		private void SelectedSimRelationChanged(object sender, EventArgs e)
		{
			if (lv.SelectedItems.Count != 1)
			{
				return;
			}

			Wrapper.ExtSDesc sdesc = (Wrapper.ExtSDesc)
				lv.SelectedItems[0].Tag;

			DiplayRelation(Sdesc, sdesc, srcRel);
			DiplayRelation(sdesc, Sdesc, dstRel);
			UpdateLabel();
		}

		private void miRel_BeforePopup(object sender, EventArgs e)
		{
			if (lv.SelectedItems.Count == 1)
			{
				miAddRelation.Enabled = Helper.WindowsRegistry.HiddenMode
					? (
							(SteepValley.Windows.Forms.XPListViewItem)
								lv.SelectedItems[0]
						).GroupIndex == 1
					: (
							(SteepValley.Windows.Forms.XPListViewItem)
								lv.SelectedItems[0]
						).GroupIndex == 1
						&& !Sdesc.Equals(lv.SelectedItems[0].Tag);

				miRemRelation.Enabled =
					(
						(SteepValley.Windows.Forms.XPListViewItem)lv.SelectedItems[0]
					).GroupIndex != 1;

				string name =
					Localization.GetString("AddRelationCaption")
					.Replace("{name}", lv.SelectedItems[0].Text);
				miAddRelation.Text = name;

				name =
					Localization.GetString("RemoveRelationCaption")
					.Replace("{name}", lv.SelectedItems[0].Text);
				miRemRelation.Text = name;

				name =
					Localization.GetString("Max Relation to this Sim")
					.Replace("{name}", lv.SelectedItems[0].Text);
				mbiMaxThisRel.Text = name;
				mbiMaxThisRel.Enabled = miRemRelation.Enabled;

				mbiMaxKnownRel.Enabled = true;
			}
			else
			{
				miAddRelation.Enabled = false;
				miRemRelation.Enabled = false;
				mbiMaxThisRel.Enabled = false;
				mbiMaxKnownRel.Enabled = true;

				string name =
					Localization.GetString("AddRelationCaption")
					.Replace("{name}", Localization.GetString("Unknown"));
				miAddRelation.Text = name;

				name =
					Localization.GetString("RemoveRelationCaption")
					.Replace("{name}", Localization.GetString("Unknown"));
				miRemRelation.Text = name;
			}
		}

		private void Activate_miAddRelation(object sender, EventArgs e)
		{
			if (lv.SelectedItems.Count != 1)
			{
				return;
			}

			Wrapper.ExtSDesc sdesc = (Wrapper.ExtSDesc)
				lv.SelectedItems[0].Tag;

			Wrapper.ExtSrel srel = FindRelation(Sdesc, sdesc);
			if (srel == null)
			{
				srel = Sdesc.CreateRelation(sdesc);
			}

			Sdesc.AddRelationToCache(srel);
			Sdesc.AddRelation(sdesc);

			srel = FindRelation(sdesc, Sdesc);
			if (srel == null)
			{
				srel = sdesc.CreateRelation(Sdesc);
			}

			Sdesc.AddRelationToCache(srel);
			sdesc.AddRelation(Sdesc);

			((SteepValley.Windows.Forms.XPListViewItem)lv.SelectedItems[0]).GroupIndex =
				0;
			lv.EnsureVisible(lv.SelectedItems[0].Index);
			lv.UpdateIcon();
			SelectedSimRelationChanged(lv, null);
		}

		private void Activate_miRemRelation(object sender, EventArgs e)
		{
			if (lv.SelectedItems.Count != 1)
			{
				return;
			}

			Wrapper.ExtSDesc sdesc = (Wrapper.ExtSDesc)
				lv.SelectedItems[0].Tag;

			Wrapper.ExtSrel srel = FindRelation(Sdesc, sdesc);
			if (srel != null)
			{
				Sdesc.RemoveRelationFromCache(srel);
			}

			Sdesc.RemoveRelation(sdesc);

			srel = FindRelation(sdesc, Sdesc);
			if (srel != null)
			{
				Sdesc.RemoveRelationFromCache(srel);
			}

			sdesc.RemoveRelation(Sdesc);

			if (
				(
					(SteepValley.Windows.Forms.XPListViewItem)lv.SelectedItems[0]
				).GroupIndex == 2
			)
			{
				lv.Items.Remove(
					(SteepValley.Windows.Forms.XPListViewItem)lv.SelectedItems[0]
				);
			}
			else
			{
				(
					(SteepValley.Windows.Forms.XPListViewItem)lv.SelectedItems[0]
				).GroupIndex = 1;
			}

			lv.EnsureVisible(lv.SelectedItems[0].Index);
			lv.UpdateIcon();
			SelectedSimRelationChanged(lv, null);
		}

		private void Activate_mbiMaxThisRel(object sender, EventArgs e)
		{
			foreach (SteepValley.Windows.Forms.XPListViewItem lvi in lv.SelectedItems)
			{
				if (lvi.GroupIndex != 1)
				{
					if (srcRel.Srel != null)
					{
						srcRel.Srel.Longterm = 100;
						srcRel.Srel.Shortterm = 100;
						srcRel.Srel.Changed = true;
					}

					if (dstRel.Srel != null)
					{
						dstRel.Srel.Longterm = 100;
						dstRel.Srel.Shortterm = 100;
						dstRel.Srel.Changed = true;
					}
				}
			}

			SelectedSimRelationChanged(lv, null);
		}

		private void Activate_mbiMaxKnownRel(object sender, EventArgs e)
		{
			int index = -1;
			if (lv.SelectedIndices.Count > 0)
			{
				index = lv.SelectedIndices[0];
			}

			foreach (SteepValley.Windows.Forms.XPListViewItem lvi in lv.Items)
			{
				if (lvi.GroupIndex != 1)
				{
					lvi.Selected = true;
					lv_SelectedSimChanged(lv, null, null);
					if (srcRel.Srel != null)
					{
						if (srcRel.Srel.RelationState.IsKnown)
						{
							srcRel.Srel.Longterm = 100;
							srcRel.Srel.Shortterm = 100;
							srcRel.Srel.Changed = true;
						}
					}

					if (dstRel.Srel != null)
					{
						if (dstRel.Srel.RelationState.IsKnown)
						{
							dstRel.Srel.Longterm = 100;
							dstRel.Srel.Shortterm = 100;
							dstRel.Srel.Changed = true;
						}
					}
				}
			}

			if (index >= 0)
			{
				lv.Items[index].Selected = true;
			}
		}
		#endregion

		#region Nightlife
		void FillNightlifeListBox(CheckedListBox clb)
		{
			if (clb.Items.Count > 0)
			{
				return;
			}

			Providers.TraitAlias[] al =
				FileTableBase.ProviderRegistry.SimDescriptionProvider.GetAllTurnOns();
			foreach (Providers.TraitAlias a in al)
			{
				clb.Items.Add(a);
			}
		}

		void SelectNightlifeItems(
			CheckedListBox clb,
			ushort v1,
			ushort v2,
			ushort v3
		)
		{
			FillNightlifeListBox(clb);

			ulong cur =
				FileTableBase.ProviderRegistry.SimDescriptionProvider.BuildTurnOnIndex(
					v1,
					v2,
					v3
				);
			for (int i = 0; i < clb.Items.Count; i++)
			{
				ulong val = ((Providers.TraitAlias)clb.Items[i]).Id;
				clb.SetItemChecked(i, ((cur & val) == val) && val != 0);
			}
		}

		void RefreshEP2(Wrapper.ExtSDesc sdesc)
		{
			cbSpecies.SelectedValue = sdesc.Nightlife.Species;
			if (biEP2.Enabled) // sim is not a pet
			{
				SelectNightlifeItems(
					lbTraits,
					sdesc.Nightlife.AttractionTraits1,
					sdesc.Nightlife.AttractionTraits2,
					sdesc.Nightlife.AttractionTraits3
				);
				SelectNightlifeItems(
					lbTurnOn,
					sdesc.Nightlife.AttractionTurnOns1,
					sdesc.Nightlife.AttractionTurnOns2,
					sdesc.Nightlife.AttractionTurnOns3
				);
				SelectNightlifeItems(
					lbTurnOff,
					sdesc.Nightlife.AttractionTurnOffs1,
					sdesc.Nightlife.AttractionTurnOffs2,
					sdesc.Nightlife.AttractionTurnOffs3
				);
				tbNTPerfume.Text = sdesc.Nightlife.PerfumeDuration.ToString();
				tbNTLove.Text = sdesc.Nightlife.LovePotionDuration.ToString();
				pnEP2.BackgroundImage = pnimage;
			}
		}

		ulong SumSelection(
			CheckedListBox clb,
			ItemCheckEventArgs e
		)
		{
			ulong val = 0;
			foreach (int i in clb.CheckedIndices)
			{
				val += ((Providers.TraitAlias)clb.Items[i]).Id;
			}

			if (e.NewValue == CheckState.Checked)
			{
				val += ((Providers.TraitAlias)clb.Items[e.Index]).Id;
			}
			else
			{
				val -= ((Providers.TraitAlias)clb.Items[e.Index]).Id;
			}

			return val;
		}

		void cklb_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			if (e.CurrentValue == e.NewValue)
			{
				return;
			}

			int which = (
				new List<CheckedListBox>(
					new CheckedListBox[] { lbTraits, lbTurnOn, lbTurnOff }
				)
			).IndexOf((CheckedListBox)sender);

			ushort[] v =
				FileTableBase.ProviderRegistry.SimDescriptionProvider.GetFromTurnOnIndex(
					SumSelection((CheckedListBox)sender, e)
				);
			switch (which)
			{
				case 0:
					Sdesc.Nightlife.AttractionTraits1 = v[0];
					Sdesc.Nightlife.AttractionTraits2 = v[1];
					Sdesc.Nightlife.AttractionTraits3 = v[2];
					break;
				case 1:
					Sdesc.Nightlife.AttractionTurnOns1 = v[0];
					Sdesc.Nightlife.AttractionTurnOns2 = v[1];
					Sdesc.Nightlife.AttractionTurnOns3 = v[2];
					break;
				case 2:
					Sdesc.Nightlife.AttractionTurnOffs1 = v[0];
					Sdesc.Nightlife.AttractionTurnOffs2 = v[1];
					Sdesc.Nightlife.AttractionTurnOffs3 = v[2];
					break;
			}
		}

		private void lbTraits_SelectedIndexChanged(object sender, EventArgs e)
		{
			pbtraits.Image = SimOriGuid.LoadTurnOnsIcon(lbTraits.SelectedIndex);
		}

		private void lbTurnOn_SelectedIndexChanged(object sender, EventArgs e)
		{
			pbtraits.Image = SimOriGuid.LoadTurnOnsIcon(lbTurnOn.SelectedIndex);
		}

		private void lbTurnOff_SelectedIndexChanged(object sender, EventArgs e)
		{
			pbtraits.Image = SimOriGuid.LoadTurnOnsIcon(lbTurnOff.SelectedIndex);
		}

		private void ChangedEP2(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
				Sdesc.Nightlife.PerfumeDuration = Helper.StringToUInt16(
					tbNTPerfume.Text,
					Sdesc.Nightlife.PerfumeDuration,
					10
				);
				Sdesc.Nightlife.LovePotionDuration = Helper.StringToUInt16(
					tbNTLove.Text,
					Sdesc.Nightlife.LovePotionDuration,
					10
				);
				Sdesc.Nightlife.Species =
					(Wrapper.SdscNightlife.SpeciesType)
						cbSpecies.SelectedValue;

				Sdesc.Changed = true;
			}
			finally
			{
				InternalChange = false;
			}
		}
		#endregion

		#region Bon Voyage
		void ShowAllCollectibles()
		{
			if (lvCollectibles.Items.Count > 0)
			{
				return;
			}

			Providers.CollectibleAlias[] al =
				FileTableBase.ProviderRegistry.SimDescriptionProvider.GetAllCollectibles();
			foreach (Providers.CollectibleAlias a in al)
			{
				ilCollectibles.Images.Add(a.Image);
				ListViewItem lvi = new ListViewItem(
					a.ToString(),
					ilCollectibles.Images.Count - 1
				)
				{
					Tag = a
				};
				lvCollectibles.Items.Add(lvi);
			}
		}

		void RefreshEP6(Wrapper.ExtSDesc sdesc)
		{
			ShowAllCollectibles();
			tbhdaysleft.Text = sdesc.Voyage.DaysLeft.ToString();

			foreach (ListViewItem lvi in lvCollectibles.Items)
			{
				Providers.CollectibleAlias a = (Providers.CollectibleAlias)
					lvi.Tag;
				lvi.Checked = (a.Id & sdesc.Voyage.CollectiblesPlain) == a.Id;
			}
		}

		private void ChangedEP6(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
				if (
					(int)Sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Voyage
				)
				{
					Sdesc.Voyage.CollectiblesPlain = 0;
					Sdesc.Voyage.DaysLeft = Helper.StringToUInt16(
						tbhdaysleft.Text,
						Sdesc.Voyage.DaysLeft,
						10
					);
					foreach (ListViewItem lvi in lvCollectibles.Items)
					{
						Providers.CollectibleAlias a =
							(Providers.CollectibleAlias)lvi.Tag;
						if (lvi.Checked)
						{
							Sdesc.Voyage.CollectiblesPlain =
								Sdesc.Voyage.CollectiblesPlain | a.Id;
						}
					}

					Sdesc.Changed = true;
				}
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void lvCollectibles_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			ChangedEP6(sender, e);
		}
		#endregion

		#region EP3
		void RefreshEP3(Wrapper.ExtSDesc sdesc)
		{
			tbEp3Flag.Text = Helper.MinStrLength(
				Convert.ToString(sdesc.Business.Flags, 2),
				16
			);
			tbEp3Lot.Text = Helper.HexString(sdesc.Business.LotID);
			tbEp3Salery.Text = sdesc.Business.Salary.ToString();

			cbEp3Asgn.SelectedValue = sdesc.Business.Assignment;
			sblb.SimDescription = sdesc;
			llep3openinfo.Links[0].Enabled = (sblb.SelectedBusiness != null);
			pnEP3.BackgroundImage = pnimage;
		}

		private void ChangedEP3(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
				Sdesc.Business.Salary = Helper.StringToUInt16(
					tbEp3Salery.Text,
					Sdesc.Business.Salary,
					10
				);
				Sdesc.Business.LotID = Helper.StringToUInt16(
					tbEp3Lot.Text,
					Sdesc.Business.LotID,
					16
				);
				Sdesc.Business.Flags = Helper.StringToUInt16(
					tbEp3Flag.Text,
					Sdesc.Business.Flags,
					2
				);
				Sdesc.Business.Assignment = (Wrapper.JobAssignment)
					cbEp3Asgn.SelectedValue;

				Sdesc.Changed = true;
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void sblb_SelectedBusinessChanged(object sender, EventArgs e)
		{
			llep3openinfo.Links[0].Enabled = (sblb.SelectedBusiness != null);
			if (sblb.SelectedBusiness != null)
			{
				if (sblb.SelectedBusiness.BnfoFileIndexItem == null)
				{
					llep3openinfo.Links[0].Enabled = false;
				}
			}
		}

		private void llep3openinfo_LinkClicked(object sender, EventArgs e)
		{
			if (sblb.SelectedBusiness == null)
			{
				return;
			}

			RemoteControl.OpenPackedFile(sblb.SelectedBusiness.BnfoFileIndexItem);
		}
		#endregion

		#region EP4
		void RefreshEP4(Wrapper.ExtSDesc sdesc)
		{
			ptGifted.SetTraitLevel(0, 1, sdesc.Pets.PetTraits);
			ptHyper.SetTraitLevel(2, 3, sdesc.Pets.PetTraits);
			ptIndep.SetTraitLevel(4, 5, sdesc.Pets.PetTraits);
			ptAggres.SetTraitLevel(6, 7, sdesc.Pets.PetTraits);
			ptPigpen.SetTraitLevel(8, 9, sdesc.Pets.PetTraits);
		}

		private void ChangedEP4(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
				if (
					(int)Sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Pets
				)
				{
					ptGifted.UpdateTraits(0, 1, Sdesc.Pets.PetTraits);
					ptHyper.UpdateTraits(2, 3, Sdesc.Pets.PetTraits);
					ptIndep.UpdateTraits(4, 5, Sdesc.Pets.PetTraits);
					ptAggres.UpdateTraits(6, 7, Sdesc.Pets.PetTraits);
					ptPigpen.UpdateTraits(8, 9, Sdesc.Pets.PetTraits);
					//Sdesc.Changed = true;
				}
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void cbSpecies_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool showsim = IsHumanoid();
			pnSimInt.Visible = pnHumanChar.Visible = showsim;
			btProfile.Visible = (showsim && !Helper.WindowsRegistry.HiddenMode);
			pnPetChar.Visible = pnPetInt.Visible = !showsim;
			if (!InternalChange && btOriGuid.Enabled)
			{
				btOriGuid.Visible = true;
			}
		}

		private bool IsHumanoid()
		{
			Wrapper.SdscNightlife.SpeciesType sp =
				(Wrapper.SdscNightlife.SpeciesType)
					cbSpecies.SelectedValue;
			bool showsim =
				sp == PackedFiles.Wrapper.SdscNightlife.SpeciesType.Human;
			return showsim;
		}

		private void SetCharacterAttributesVisibility()
		{
			bool showsim = Sdesc == null
				? true
				: (int)Sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Pets
					? Sdesc.Nightlife.IsHuman
					: true;
			pnSimInt.Visible = pnHumanChar.Visible = showsim;
			btProfile.Visible = (showsim && !Helper.WindowsRegistry.HiddenMode);
			pnPetChar.Visible = pnPetInt.Visible = !showsim;
		}

		private void pnInt_VisibleChanged(object sender, EventArgs e)
		{
			bool showsim = IsHumanoid();
			pnSimInt.Visible = pnHumanChar.Visible = showsim;
			btProfile.Visible = (showsim && !Helper.WindowsRegistry.HiddenMode);
			pnPetChar.Visible = pnPetInt.Visible = !showsim;
		}

		private void pnSimInt_VisibleChanged(object sender, EventArgs e)
		{
		}
		#endregion

		#region Freetime
		void RefreshEP7(Wrapper.ExtSDesc sdesc)
		{
			InternalChange = true;
			cbaspiration2.Enabled = Helper
				.WindowsRegistry
				.AllowChangeOfSecondaryAspiration;

			if (cbHobbyEnth.SelectedIndex < 0)
			{
				cbHobbyEnth.SelectedIndex = 0;
			}
			else
			{
				EnthusiasmIndexChanged(cbHobbyEnth, null);
			}

			cbHobbyPre.SelectedValue = sdesc.Freetime.HobbyPredistined;
			tbBugColl.Text = "0x" + Helper.HexString(sdesc.Freetime.BugCollection);
			tbLtAsp.Text =
				"0x" + Helper.HexString(sdesc.Freetime.LongtermAspiration);
			tbUnlockPts.Text =
				sdesc.Freetime.LongtermAspirationUnlockPoints.ToString();
			tbUnlocksUsed.Text =
				sdesc.Freetime.LongtermAspirationUnlocksSpent.ToString();
			tb7hunger.Text = sdesc.Freetime.HungerDecayModifier.ToString();
			tb7comfort.Text = sdesc.Freetime.ComfortDecayModifier.ToString();
			tb7bladder.Text = sdesc.Freetime.BladderDecayModifier.ToString();
			tb7energy.Text = sdesc.Freetime.EnergyDecayModifier.ToString();
			tb7hygiene.Text = sdesc.Freetime.HygieneDecayModifier.ToString();
			tb7fun.Text = sdesc.Freetime.FunDecayModifier.ToString();
			tb7social.Text = sdesc.Freetime.SocialPublicDecayModifier.ToString();
			SelectAspiration(cbaspiration2, sdesc.Freetime.SecondaryAspiration);

			pnEP7.BackgroundImage = pnimage;
			InternalChange = false;
		}

		void UpdateSecAspDropDown()
		{
			SetAspirations(cbaspiration2, Sdesc.Freetime.PrimaryAspiration);
		}

		void ChangedAspiration(object sender, EventArgs e)
		{
			ChangedCareer(sender, e);
			UpdateSecAspDropDown();
			SelectAspiration(cbaspiration2, Sdesc.Freetime.SecondaryAspiration);
		}

		private void ChangedHobbyEnthProgress(object sender, EventArgs e)
		{
			ChangedEP7(sender, e);
		}

		private void ChangedEP7(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			InternalChange = true;
			try
			{
				if (
					(int)Sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Freetime
				)
				{
					if (
						cbHobbyEnth.SelectedIndex >= 0
						&& cbHobbyEnth.SelectedIndex
							< Sdesc.Freetime.HobbyEnthusiasm.Count
					)
					{
						Sdesc.Freetime.HobbyEnthusiasm[cbHobbyEnth.SelectedIndex] =
							(ushort)pbhbenth.Value;
					}

					Sdesc.Freetime.BugCollection = Helper.StringToUInt32(
						tbBugColl.Text,
						Sdesc.Freetime.BugCollection,
						16
					);
					Sdesc.Freetime.LongtermAspiration = Helper.StringToUInt16(
						tbLtAsp.Text,
						Sdesc.Freetime.LongtermAspiration,
						16
					);
					Sdesc.Freetime.LongtermAspirationUnlockPoints =
						Helper.StringToUInt16(
							tbUnlockPts.Text,
							Sdesc.Freetime.LongtermAspirationUnlockPoints,
							10
						);
					Sdesc.Freetime.LongtermAspirationUnlocksSpent =
						Helper.StringToUInt16(
							tbUnlocksUsed.Text,
							Sdesc.Freetime.LongtermAspirationUnlocksSpent,
							10
						);

					Sdesc.Freetime.HungerDecayModifier = Helper.StringToUInt16(
						tb7hunger.Text,
						Sdesc.Freetime.HungerDecayModifier,
						10
					);
					Sdesc.Freetime.ComfortDecayModifier = Helper.StringToUInt16(
						tb7comfort.Text,
						Sdesc.Freetime.ComfortDecayModifier,
						10
					);
					Sdesc.Freetime.BladderDecayModifier = Helper.StringToUInt16(
						tb7bladder.Text,
						Sdesc.Freetime.BladderDecayModifier,
						10
					);
					Sdesc.Freetime.EnergyDecayModifier = Helper.StringToUInt16(
						tb7energy.Text,
						Sdesc.Freetime.EnergyDecayModifier,
						10
					);
					Sdesc.Freetime.HygieneDecayModifier = Helper.StringToUInt16(
						tb7hygiene.Text,
						Sdesc.Freetime.HygieneDecayModifier,
						10
					);
					Sdesc.Freetime.FunDecayModifier = Helper.StringToUInt16(
						tb7fun.Text,
						Sdesc.Freetime.FunDecayModifier,
						10
					);
					Sdesc.Freetime.SocialPublicDecayModifier = Helper.StringToUInt16(
						tb7social.Text,
						Sdesc.Freetime.SocialPublicDecayModifier,
						10
					);

					Sdesc.Freetime.HobbyPredistined =
						PackedFiles.Wrapper.SdscFreetime.IndexToHobbies(
							cbHobbyPre.SelectedIndex
						);
					Sdesc.Freetime.SecondaryAspiration = (LocalizedAspirationTypes)
						cbaspiration2.SelectedItem;

					Sdesc.Changed = true;
				}
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void PredistinedHobbyIndexChanged(object sender, EventArgs e)
		{
			Wrapper.Hobbies hb =
				PackedFiles.Wrapper.SdscFreetime.IndexToHobbies(
					cbHobbyPre.SelectedIndex
				);
			ChangedEP7(sender, e);
		}

		private void EnthusiasmIndexChanged(object sender, EventArgs e)
		{
			if (
				cbHobbyEnth.SelectedIndex >= 0
				&& cbHobbyEnth.SelectedIndex < Sdesc.Freetime.HobbyEnthusiasm.Count
			)
			{
				pbhbenth.Value = Sdesc.Freetime.HobbyEnthusiasm[
					cbHobbyEnth.SelectedIndex
				];
				pbhbenth.Enabled = true;
			}
			else
			{
				pbhbenth.Value = 0;
				pbhbenth.Enabled = false;
			}
		}
		#endregion
	}
}
