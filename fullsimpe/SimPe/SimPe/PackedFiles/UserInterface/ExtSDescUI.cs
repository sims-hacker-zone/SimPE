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

			this.biId.Tag = pnId;
			this.biSkill.Tag = pnSkill;
			this.biChar.Tag = pnChar;
			this.biCareer.Tag = pnCareer;
			this.biEP1.Tag = pnEP1;
			this.biEP2.Tag = pnEP2;
			this.biEP3.Tag = pnEP3;
			this.biEP6.Tag = pnVoyage;
			this.biEP7.Tag = pnEP7;
			this.biEP9.Tag = pnEP9;
			this.biInt.Tag = pnInt;
			this.biRel.Tag = pnRel;
			this.biMisc.Tag = pnMisc;

			this.tbsim.ReadOnly = !UserVerification.HaveUserId;
			this.miRelink.Enabled = (UserVerification.HaveUserId);
			this.tbBugColl.ReadOnly = !UserVerification.HaveUserId;

			if (Helper.StartedGui == Executable.Classic)
			{
				this.biId.TextImageRelation = TextImageRelation.Overlay;
				this.biId.Image = null;
				this.biSkill.TextImageRelation = TextImageRelation.Overlay;
				this.biSkill.Image = null;
				this.biChar.TextImageRelation = TextImageRelation.Overlay;
				this.biChar.Image = null;
				this.biCareer.TextImageRelation = TextImageRelation.Overlay;
				this.biCareer.Image = null;
				this.biEP1.TextImageRelation = TextImageRelation.Overlay;
				this.biEP1.Image = null;
				this.biEP2.TextImageRelation = TextImageRelation.Overlay;
				this.biEP2.Image = null;
				this.biEP3.TextImageRelation = TextImageRelation.Overlay;
				this.biEP3.Image = null;
				this.biEP6.TextImageRelation = TextImageRelation.Overlay;
				this.biEP6.Image = null;
				this.biEP7.TextImageRelation = TextImageRelation.Overlay;
				this.biEP7.Image = null;
				this.biEP9.TextImageRelation = TextImageRelation.Overlay;
				this.biEP9.Image = null;
				this.biInt.TextImageRelation = TextImageRelation.Overlay;
				this.biInt.Image = null;
				this.biRel.TextImageRelation = TextImageRelation.Overlay;
				this.biRel.Image = null;
				this.biMisc.TextImageRelation = TextImageRelation.Overlay;
				this.biMisc.Image = null;
				this.biMax.TextImageRelation = TextImageRelation.Overlay;
				this.biMax.Image = null;
				this.biMore.TextImageRelation = TextImageRelation.Overlay;
				this.biMore.Image = null;
				this.biLezby.TextImageRelation = TextImageRelation.Overlay;
				this.biLezby.Image = null;
			}

			InitDropDowns();
			SelectButton(biId);

			InternalChange = true;
			if (
				System
					.Threading
					.Thread
					.CurrentThread
					.CurrentUICulture
					.TwoLetterISOLanguageName == "en"
			)
			{
				pbLastGrade.DisplayOffset = 0;
			}
			else
			{
				pbLastGrade.DisplayOffset = 1;
			}

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
				this.llep3openinfo.Font = new Font(
					"Tahoma",
					12,
					FontStyle.Bold
				);
				this.llep3openinfo.Height = 24;
				this.lbTraits.Font = new Font("Tahoma", 11);
				this.lbTurnOn.Font = new Font("Tahoma", 11);
				this.lbTurnOff.Font = new Font("Tahoma", 11);
				if (Screen.PrimaryScreen.WorkingArea.Width > 1600)
				{
					this.ilCollectibles.ImageSize = new Size(64, 64);
				}
			}
			else
			{
				this.llep3openinfo.Font = new Font(
					"Tahoma",
					this.llep3openinfo.Font.Size,
					FontStyle.Bold
				);
				this.llep3openinfo.Height = 16;
			}
			//this.llep3openinfo.Icon = SimPe.GetIcon.BnfoIco;

			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(ExtSDesc));
			this.Commited += new EventHandler(this.ExtSDesc_Commited);

			this.srcRel = new CommonSrel();
			this.dstRel = new CommonSrel();
			//
			// srcRel
			//
			this.srcRel.Dock = DockStyle.Fill;
			this.srcRel.Enabled = false;
			this.srcRel.Name = "srcRed";
			this.srcRel.Srel = null;
			this.srcRel.Visible = true;
			//
			// dstRel
			//
			this.dstRel.Dock = DockStyle.Fill;
			this.dstRel.Enabled = false;
			this.dstRel.Name = "dstRel";
			this.dstRel.Srel = null;
			this.dstRel.Visible = true;

			this.srcTb.Controls.Add(this.srcRel);
			this.dstTb.Controls.Add(this.dstRel);

			this.dstTb.Top = this.srcTb.Bottom;
		}

		public void SelectButton(ToolStripButton b)
		{
			for (int i = 0; i < this.toolBar1.Items.Count; i++)
			{
				if (toolBar1.Items[i] is ToolStripButton)
				{
					ToolStripButton item = (ToolStripButton)toolBar1.Items[i];
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
			this.miOpenSCOR.Enabled =
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

			this.cblifesection.Items.Clear();
			this.cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Unknown)
			);
			this.cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Baby)
			);
			this.cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Toddler)
			);
			this.cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Child)
			);
			this.cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Teen)
			);
			this.cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Adult)
			);
			this.cblifesection.Items.Add(
				new LocalizedLifeSections(MetaData.LifeSections.Elder)
			);

			this.cbcareer.Items.Clear();
			foreach (
				Interfaces.IAlias a in
					PackedFiles
					.Wrapper
					.SDesc
					.AddonCarrers
			)
			{
				this.cbcareer.Items.Add(a);
			}

			this.cbcareer.Items.Add(
				new LocalizedCareers(MetaData.Careers.Unknown)
			);
			this.cbcareer.Items.Add(
				new LocalizedCareers(MetaData.Careers.Unemployed)
			);
			if (
				Helper.WindowsRegistry.LoadOnlySimsStory == 28
				&& !Helper.WindowsRegistry.HiddenMode
			)
			{
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Crafter)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Gatherer)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Hunter)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.OrangutanCrafter)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.OrangutanGatherer)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.OrangutanHunter)
				);

				for (int j = 0; j < this.cbcareer.Items.Count; j++)
				{
					this.cbRetirement.Items.Add(this.cbcareer.Items[j]);
				}

				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderCrafter)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderGatherer)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderHunter)
				);
			}
			else
			{
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Science)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Medical)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Politics)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Athletic)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.LawEnforcement)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Culinary)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Economy)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Slacker)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Criminal)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.Military)
				);
				if (
					PathProvider.Global.GetExpansion(Expansions.University).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Paranormal)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.NaturalScientist)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.ShowBiz)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Artist)
					);
				}
				if (
					PathProvider
						.Global.GetExpansion(Expansions.IslandStories)
						.Exists || Helper.WindowsRegistry.HiddenMode
				)
				{
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Crafter)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Gatherer)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Hunter)
					);
				}
				if (
					PathProvider.Global.GetExpansion(Expansions.Seasons).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Adventurer)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Education)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Gamer)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Journalism)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Law)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Music)
					);
				}
				if (
					PathProvider.Global.GetExpansion(Expansions.FreeTime).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Construction)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Dance)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Entertainment)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Intelligence)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.Ocenography)
					);
				}
				if (
					PathProvider
						.Global.GetExpansion(Expansions.LifeStories)
						.Exists || Helper.WindowsRegistry.HiddenMode
				)
				{
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.EntertainLS)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.GameDevelopment)
					);
				}
				if (
					PathProvider.Global.GetExpansion(Expansions.Business).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.OwnedBuss)
					);
				}

				for (int i = 0; i < this.cbcareer.Items.Count; i++)
				{
					this.cbRetirement.Items.Add(this.cbcareer.Items[i]);
				}

				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderAthletic)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderBusiness)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderCriminal)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderCulinary)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderLawEnforcement)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderMedical)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderMilitary)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderPolitics)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderScience)
				);
				this.cbcareer.Items.Add(
					new LocalizedCareers(MetaData.Careers.TeenElderSlacker)
				);
				if (
					PathProvider.Global.GetExpansion(Expansions.Seasons).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderAdventurer)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderEducation)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderGamer)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderJournalism)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderLaw)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderMusic)
					);
				}
				if (
					PathProvider
						.Global.GetExpansion(Expansions.IslandStories)
						.Exists || Helper.WindowsRegistry.HiddenMode
				)
				{
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderCrafter)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderGatherer)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderHunter)
					);
				}
				if (
					PathProvider.Global.GetExpansion(Expansions.FreeTime).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					this.cbcareer.Items.Add(
						new LocalizedCareers(
							MetaData.Careers.TeenElderConstruction
						)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderDance)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(
							MetaData.Careers.TeenElderEntertainment
						)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(
							MetaData.Careers.TeenElderIntelligence
						)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.TeenElderOcenography)
					);
				}
				if (
					PathProvider.Global.GetExpansion(Expansions.Business).Exists
					|| (Helper.WindowsRegistry.HiddenMode)
				)
				{
					this.cbcareer.Items.Add(
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
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.PetSecurity)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.PetService)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.PetShowBiz)
					);
					this.cbRetirement.Items.Add(
						new LocalizedCareers(MetaData.Careers.PetSecurity)
					);
					this.cbRetirement.Items.Add(
						new LocalizedCareers(MetaData.Careers.PetService)
					);
					this.cbRetirement.Items.Add(
						new LocalizedCareers(MetaData.Careers.PetShowBiz)
					);
				}
				if (
					PathProvider
						.Global.GetExpansion(Expansions.IslandStories)
						.Exists || Helper.WindowsRegistry.HiddenMode
				)
				{
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.OrangutanCrafter)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.OrangutanGatherer)
					);
					this.cbcareer.Items.Add(
						new LocalizedCareers(MetaData.Careers.OrangutanHunter)
					);
					this.cbRetirement.Items.Add(
						new LocalizedCareers(MetaData.Careers.OrangutanCrafter)
					);
					this.cbRetirement.Items.Add(
						new LocalizedCareers(MetaData.Careers.OrangutanGatherer)
					);
					this.cbRetirement.Items.Add(
						new LocalizedCareers(MetaData.Careers.OrangutanHunter)
					);
				}
			}

			this.cbgrade.Items.Clear();
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.Unknown));
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.APlus));
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.A));
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.AMinus));
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.BPlus));
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.B));
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.BMinus));
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.CPlus));
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.C));
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.CMinus));
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.DPlus));
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.D));
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.DMinus));
			this.cbgrade.Items.Add(new LocalizedGrades(MetaData.Grades.F));

			this.cbmajor.Items.Clear();
			foreach (
				Interfaces.IAlias a in PackedFiles.Wrapper.SDesc.AddonMajors
			)
			{
				this.cbmajor.Items.Add(a);
			}

			Array majors = Enum.GetValues(typeof(Majors));
			foreach (Majors c in majors)
			{
				this.cbmajor.Items.Add(c);
			}

			this.cbschooltype.Items.Clear();
			foreach (
				Interfaces.IAlias a in
					PackedFiles
					.Wrapper
					.SDesc
					.AddonSchools
			)
			{
				this.cbschooltype.Items.Add(a);
			}

			this.cbschooltype.Items.Add(
				new LocalizedSchoolType(MetaData.SchoolTypes.NoSchool)
			);
			this.cbschooltype.Items.Add(
				new LocalizedSchoolType(MetaData.SchoolTypes.PrivateSchool)
			);
			this.cbschooltype.Items.Add(
				new LocalizedSchoolType(MetaData.SchoolTypes.PublicSchool)
			);

			this.cbzodiac.Items.Clear();
			for (ushort i = 0x01; i <= 0x0C; i++)
			{
				this.cbzodiac.Items.Add(
					new LocalizedZodiacSignes((MetaData.ZodiacSignes)i)
				);
			}

			this.cbservice.Items.Clear();
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Normal)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Bartenderb)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Bartenderp)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Boss)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Burglar)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Driver)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Streaker)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Coach)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.LunchLady)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Cop)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Delivery)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Exterminator)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.FireFighter)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Gardener)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Barista)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Grim)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Handy)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Headmistress)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Matchmaker)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Maid)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.MailCarrier)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Nanny)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Paper)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Pizza)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Professor)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.EvilMascot)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Repo)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.CheerLeader)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Mascot)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.SocialBunny)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.SocialWorker)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Register)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Therapist)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Chinese)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Podium)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Waitress)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Chef)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.DJ)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Crumplebottom)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Vampyre)
			);
			if (
				(
					PathProvider.Global.GetExpansion(Expansions.Business).Exists
					|| PathProvider.Global.STInstalled >= 28
				) || Helper.WindowsRegistry.HiddenMode
			)
			{
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Servo)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Reporter)
				);
				this.cbservice.Items.Add(
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
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Wolf)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.WolfLOTP)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Skunk)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.AnimalControl)
				);
				this.cbservice.Items.Add(
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
				this.cbservice.Items.Add(
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
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Bellhop)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Villain)
				);
			}
			if (
				PathProvider.Global.GetExpansion(Expansions.Voyage).Exists
				|| Helper.WindowsRegistry.HiddenMode
			)
			{
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.TourGuide)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Hermit)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Ninja)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.BigFoot)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Housekeeper)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.FoodStandChef)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.FireDancer)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.WitchDoctor)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.GhostCaptain)
				);
			}
			if (
				PathProvider.Global.GetExpansion(Expansions.FreeTime).Exists
				|| (Helper.WindowsRegistry.HiddenMode)
			)
			{
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.FoodJudge)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Genie)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.exDJ)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.exGypsy)
				);
			}
			if (
				PathProvider.Global.GetExpansion(Expansions.Apartments).Exists
				|| (Helper.WindowsRegistry.HiddenMode)
			)
			{
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Witch1)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Breakdancer)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.SpectralCat)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Statue)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Landlord)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.Butler)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.hotdogchef)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.assistant)
				);
				this.cbservice.Items.Add(
					new LocalizedServiceTypes(MetaData.ServiceTypes.exWitch2)
				);
			}

			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.icontrol)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.Pandora)
			);
			this.cbservice.Items.Add(
				new LocalizedServiceTypes(MetaData.ServiceTypes.DMASim)
			);

			this.cbEp3Asgn.ResourceManager = Localization.Manager;
			this.cbEp3Asgn.Enum = typeof(Wrapper.JobAssignment);

			this.cbSpecies.ResourceManager = Localization.Manager;
			this.cbSpecies.Enum =
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
				this.cbpostTitle.Items.Add(kvp.Value);
			}
		}

		#region IPackedFileUI Member
		public Wrapper.ExtSDesc Sdesc => (Wrapper.ExtSDesc)Wrapper;

		Plugin.Subhoods shs = new Plugin.Subhoods();

		protected override void RefreshGUI()
		{
			loadedRel = false;
			this.InternalChange = true;
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
				this.tbsimdescname.ReadOnly = this.tbsimdescfamname.ReadOnly =
					Sdesc.IsNPC;
				this.btOriGuid.Visible = this.lbFixedRes.Visible = false;

				if (System.IO.File.Exists(Sdesc.CharacterFileName))
				{
					miOpenChar.Text =
						strresources.GetString("miOpenChar.Text")
						+ " ("
						+ System.IO.Path.GetFileNameWithoutExtension(
							Sdesc.CharacterFileName
						)
						+ ")";
				}
				else
				{
					miOpenChar.Text = strresources.GetString("miOpenChar.Text");
				}

				if (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.Apartment
					&& Sdesc.Nightlife.Species == 0
					&& Helper.StartedGui == Executable.Default
				)
				{
					this.HeaderText =
						Sdesc.SimName
						+ " "
						+ MetaData.GetTitleName(
							Sdesc.Apartment.TitlePostName
						);
					pnimage = null;
				}
				else
				{
					this.HeaderText = Sdesc.SimName;
					this.biLezby.Visible = false;
					pnimage = null;
				}

				RefreshSkills(Sdesc);
				RefreshId(Sdesc);
				RefreshCareer(Sdesc);
				RefreshCharcter(Sdesc);
				RefreshInterests(Sdesc);
				RefreshMisc(Sdesc);

				this.biRel.Enabled = Helper.IsNeighborhoodFile(Sdesc.Package.FileName);
				this.biEP1.Enabled = (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.University
					&& Sdesc.Nightlife.Species == 0
					&& (int)Sdesc.Version
						!= (int)PackedFiles.Wrapper.SDescVersions.Castaway
				);
				this.biEP2.Enabled = (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.Nightlife
					&& Sdesc.Nightlife.Species == 0
				);
				this.biEP3.Enabled = (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.Business
					&& Sdesc.Nightlife.Species == 0
					&& (int)Sdesc.Version
						!= (int)PackedFiles.Wrapper.SDescVersions.Castaway
				);
				this.biEP6.Enabled = (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.Voyage
					&& Sdesc.Nightlife.Species == 0
					&& PathProvider.Global.EPInstalled > 9
				);
				this.biEP7.Enabled = (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.Freetime
					&& Sdesc.Nightlife.Species == 0
				);
				this.biEP9.Enabled = (
					(int)Sdesc.Version
						>= (int)PackedFiles.Wrapper.SDescVersions.Apartment
					&& Sdesc.Nightlife.Species == 0
				);
				this.cbSpecies.Enabled = (
					(int)Sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Pets
				);
				if (pnRel.Visible && !biRel.Enabled)
				{
					this.SelectButton(biId);
				}

				if (pnEP1.Visible && !biEP1.Enabled)
				{
					this.SelectButton(biId);
				}

				if (pnEP2.Visible && !biEP2.Enabled)
				{
					this.SelectButton(biId);
				}

				if (pnEP3.Visible && !biEP3.Enabled)
				{
					this.SelectButton(biId);
				}

				if (pnVoyage.Visible && !biEP6.Enabled)
				{
					this.SelectButton(biId);
				}

				if (pnEP7.Visible && !biEP7.Enabled)
				{
					this.SelectButton(biId);
				}

				if (pnEP9.Visible && !biEP9.Enabled)
				{
					this.SelectButton(biId);
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
				this.InternalChange = false;
			}
		}

		void RefreshEP1(Wrapper.ExtSDesc sdesc)
		{
			this.cbmajor.SelectedIndex = 0;
			this.tbmajor.Text = "0x" + Helper.HexString((uint)sdesc.University.Major);
			this.cbmajor.SelectedIndex = this.cbmajor.Items.Count - 1;
			for (int i = 0; i < this.cbmajor.Items.Count; i++)
			{
				object o = this.cbmajor.Items[i];
				Majors at;
				if (o.GetType() == typeof(Alias))
				{
					at = (Majors)((uint)((Alias)o).Id);
				}
				else
				{
					at = (Majors)o;
				}

				if (at == sdesc.University.Major)
				{
					this.cbmajor.SelectedIndex = i;
					break;
				}
			}

			this.cboncampus.Checked = (sdesc.University.OnCampus == 0x1);
			this.pbEffort.Value = sdesc.University.Effort;
			this.pbLastGrade.Value = sdesc.University.Grade;

			this.pbUniTime.Value = sdesc.University.Time;
			this.tbinfluence.Text = sdesc.University.Influence.ToString();
			this.tbsemester.Text = sdesc.University.Semester.ToString();

			this.cbfreshman.Checked = Sdesc.University.SemesterFlag.Freshman;
			this.cbSopho.Checked = Sdesc.University.SemesterFlag.Sophomore;
			this.cbJunior.Checked = Sdesc.University.SemesterFlag.Junior;
			this.cbSenior.Checked = Sdesc.University.SemesterFlag.Senior;
			this.cbGoodsem.Checked = Sdesc.University.SemesterFlag.GoodSem;
			this.cbprobation.Checked = Sdesc.University.SemesterFlag.Probation;
			this.cbgraduate.Checked = Sdesc.University.SemesterFlag.Graduated;
			this.cbatclass.Checked = Sdesc.University.SemesterFlag.AtClass;
			this.cbdroped.Checked = Sdesc.University.SemesterFlag.Dropped;
			this.cbexpelled.Checked = Sdesc.University.SemesterFlag.Expelled;

			this.pnEP1.BackgroundImage = pnimage;
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
					this.pbPupbody.Value = sdesc.Skills.Body;
					this.pbPupCharisma.Value = sdesc.Skills.Charisma;
					this.pbPupClean.Value = sdesc.Skills.Cleaning;
					this.pbPupCreative.Value = sdesc.Skills.Creativity;
					this.pbPupLogic.Value = sdesc.Skills.Logic;
					this.pbPupMech.Value = sdesc.Skills.Mechanical;
					this.pbFat.Value = sdesc.Skills.Fatness;
					this.pbBody.Visible = false;
					this.pbCharisma.Visible = false;
					this.pbClean.Visible = false;
					this.pbCreative.Visible = false;
					this.pbMusic.Visible = false;
					this.pbArty.Visible = false;
					this.pbLogic.Visible = false;
					this.pbMech.Visible = false;
					this.pbCooking.Visible = false;
					this.pbReputate.Visible = false;
					this.pbPupbody.Visible = true;
					this.pbPupCharisma.Visible = true;
					this.pbPupClean.Visible = true;
					this.pbPupCreative.Visible = true;
					this.pbPupLogic.Visible = true;
					this.pbPupMech.Visible = true;
				}
				else
				{
					if ((int)Sdesc.Nightlife.Species > 0)
					{
						this.pbFat.Value = sdesc.Skills.Fatness;
						this.pbBody.Visible = false;
						this.pbCharisma.Visible = false;
						this.pbClean.Visible = false;
						this.pbCreative.Visible = false;
						this.pbLogic.Visible = false;
						this.pbMech.Visible = false;
						this.pbCooking.Visible = false;
						this.pbPupbody.Visible = false;
						this.pbPupCharisma.Visible = false;
						this.pbPupClean.Visible = false;
						this.pbPupCreative.Visible = false;
						this.pbPupLogic.Visible = false;
						this.pbPupMech.Visible = false;
						this.pbMusic.Visible = false;
						this.pbArty.Visible = false;
						this.pbReputate.Visible = false;
					}
					else
					{
						this.pbBody.Value = sdesc.Skills.Body;
						this.pbCharisma.Value = sdesc.Skills.Charisma;
						this.pbClean.Value = sdesc.Skills.Cleaning;
						this.pbCooking.Value = sdesc.Skills.Cooking;
						this.pbCreative.Value = sdesc.Skills.Creativity;
						this.pbFat.Value = sdesc.Skills.Fatness;
						this.pbLogic.Value = sdesc.Skills.Logic;
						this.pbMech.Value = sdesc.Skills.Mechanical;
						this.pbMusic.Value = sdesc.Skills.Music;
						this.pbArty.Value = sdesc.Skills.Art;
						this.pbPupbody.Visible = false;
						this.pbPupCharisma.Visible = false;
						this.pbPupClean.Visible = false;
						this.pbPupCreative.Visible = false;
						this.pbPupLogic.Visible = false;
						this.pbPupMech.Visible = false;
						this.pbBody.Visible = true;
						this.pbCharisma.Visible = true;
						this.pbClean.Visible = true;
						this.pbCreative.Visible = true;
						this.pbMusic.Visible = Helper.WindowsRegistry.ShowMoreSkills;
						this.pbArty.Visible = Helper.WindowsRegistry.ShowMoreSkills;
						this.pbLogic.Visible = true;
						this.pbReputate.Visible = true;
						this.pbMech.Visible = true;
						this.pbCooking.Visible = true;
						if (
							(int)Sdesc.Version
							>= (int)PackedFiles.Wrapper.SDescVersions.Apartment
						)
						{
							this.pbReputate.Value = sdesc.Apartment.Reputation;
							this.pbReputate.Visible = true;
						}
						else
						{
							this.pbReputate.Visible = false;
						}
					}
				}
				this.pnSkill.BackgroundImage = pnimage;
			}
			else
			{
				this.pbBody.Value = sdesc.Skills.Body;
				this.pbCharisma.Value = sdesc.Skills.Charisma;
				this.pbClean.Value = sdesc.Skills.Cleaning;
				this.pbCooking.Value = sdesc.Skills.Cooking;
				this.pbCreative.Value = sdesc.Skills.Creativity;
				this.pbFat.Value = sdesc.Skills.Fatness;
				this.pbLogic.Value = sdesc.Skills.Logic;
				this.pbMech.Value = sdesc.Skills.Mechanical;
				this.pbMusic.Value = sdesc.Skills.Music;
				this.pbArty.Value = sdesc.Skills.Art;
				this.pbPupbody.Visible = false;
				this.pbPupCharisma.Visible = false;
				this.pbPupClean.Visible = false;
				this.pbPupCreative.Visible = false;
				this.pbPupLogic.Visible = false;
				this.pbPupMech.Visible = false;
				this.pbBody.Visible = true;
				this.pbCharisma.Visible = true;
				this.pbClean.Visible = true;
				this.pbCreative.Visible = true;
				this.pbMusic.Visible = Helper.WindowsRegistry.ShowMoreSkills;
				this.pbArty.Visible = Helper.WindowsRegistry.ShowMoreSkills;
				this.pbLogic.Visible = true;
				this.pbMech.Visible = true;
				this.pbCooking.Visible = true;
				this.pbReputate.Visible = false;
			}
		}

		void RefreshMisc(Wrapper.ExtSDesc sdesc)
		{
			this.tbdecScratc.Visible = this.lbdecScratc.Visible = (
				sdesc.Nightlife.Species > 0
			);
			this.tbdecShop.Visible = this.lbdecShop.Visible = (
				sdesc.Nightlife.Species == 0
			);

			//ghostflags
			this.cbisghost.Checked = sdesc.CharacterDescription.GhostFlag.IsGhost;
			this.cbpassobject.Checked = sdesc
				.CharacterDescription
				.GhostFlag
				.CanPassThroughObjects;
			this.cbpasswalls.Checked = sdesc
				.CharacterDescription
				.GhostFlag
				.CanPassThroughWalls;
			this.cbpasspeople.Checked = sdesc
				.CharacterDescription
				.GhostFlag
				.CanPassThroughPeople;
			this.cbignoretraversal.Checked = sdesc
				.CharacterDescription
				.GhostFlag
				.IgnoreTraversalCosts;

			//body flags
			this.cbfit.Checked = sdesc.CharacterDescription.BodyFlag.Fit;
			this.cbfat.Checked = sdesc.CharacterDescription.BodyFlag.Fat;
			this.cbpregfull.Checked = sdesc.CharacterDescription.BodyFlag.PregnantFull;
			this.cbpreghalf.Checked = sdesc.CharacterDescription.BodyFlag.PregnantHalf;
			this.cbpreginv.Checked = sdesc.CharacterDescription.BodyFlag.PregnantHidden;

			//misc
			this.tbprevdays.Text = sdesc.CharacterDescription.PrevAgeDays.ToString();
			this.tbagedur.Text = sdesc.CharacterDescription.AgeDuration.ToString();
			this.tbunlinked.Text = "0x" + Helper.HexString(sdesc.Unlinked);
			this.tbvoice.Text =
				"0x" + Helper.HexString(sdesc.CharacterDescription.VoiceType);
			this.tbautonomy.Text =
				"0x" + Helper.HexString(sdesc.CharacterDescription.AutonomyLevel);
			this.tbnpc.Text =
				"0x" + Helper.HexString(sdesc.CharacterDescription.NPCType);
			this.tbstatmot.Text =
				"0x" + Helper.HexString(sdesc.CharacterDescription.MotivesStatic);

			//motive decays
			this.tbdecHunger.Text = Convert.ToString(sdesc.Decay.Hunger);
			this.tbdecComfort.Text = Convert.ToString(sdesc.Decay.Comfort);
			this.tbdecBladder.Text = Convert.ToString(sdesc.Decay.Bladder);
			this.tbdecEnergy.Text = Convert.ToString(sdesc.Decay.Energy);
			this.tbdecHygiene.Text = Convert.ToString(sdesc.Decay.Hygiene);
			this.tbdecSocial.Text = Convert.ToString(sdesc.Decay.Social);
			this.tbdecShop.Text = Convert.ToString(sdesc.Decay.Shopping);
			this.tbdecFun.Text = Convert.ToString(sdesc.Decay.Fun);
			this.tbdecAmor.Text = Convert.ToString(sdesc.Decay.Amorous);
			this.tbdecScratc.Text = Convert.ToString(sdesc.Decay.ScratchC);

			if (
				(int)sdesc.Version
				>= (int)PackedFiles.Wrapper.SDescVersions.Nightlife
			)
			{
				this.tbpersonflags.Visible = tbMotiveDec.Visible = true;
				this.cbpflycar.Visible =
					this.cbpflyact.Visible =
					this.cbpfrunaw.Visible =
					this.cbpfPlant.Visible =
						(
							(int)sdesc.Version
							>= (int)PackedFiles.Wrapper.SDescVersions.Pets
						);
				this.cbpfBigf.Visible = (
					(int)sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Voyage
				);
				this.cbpfwitch.Visible = this.cbpfroomy.Visible = (
					(int)sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Apartment
				);
				this.cbpfZomb.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsZombie;
				this.cbpfperma.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.PermaPlatinum;
				this.cbpfvamp.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsVampire;
				this.cbpfvsmoke.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.VampireSmoke;
				this.cbpfwants.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.WantHistory;
				this.cbpflycar.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.LycanCarrier;
				this.cbpflyact.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.LycanActive;
				this.cbpfrunaw.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsRunaway;
				this.cbpfPlant.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsPlantsim;
				this.cbpfBigf.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsBigfoot;
				this.cbpfwitch.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsWitch;
				this.cbpfroomy.Checked = sdesc
					.CharacterDescription
					.PersonFlags1
					.IsRoomate;
			}
			else
			{
				this.tbpersonflags.Visible = tbMotiveDec.Visible = false;
			}

			this.pnMisc.BackgroundImage = pnimage;
		}

		void RefreshId(Wrapper.ExtSDesc sdesc)
		{
			this.pnId.BackgroundImage = pnimage;
			this.tbage.Text = sdesc.CharacterDescription.Age.ToString();
			this.tbsimdescname.Text = sdesc.SimName;
			this.tbsimdescfamname.Text = sdesc.SimFamilyName;
			this.tbsim.Text = "0x" + Helper.HexString(sdesc.SimId);
			this.tbsim.ReadOnly = !UserVerification.HaveUserId;
			this.tbfaminst.Text = "0x" + Helper.HexString(sdesc.FamilyInstance);
			this.tbsinstance.Text = "0x" + Helper.HexString(sdesc.Instance);
			this.lbHousname.Text = "(" + sdesc.HouseholdName + ")";
			this.btOriGuid.Enabled = (
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
				if (sdesc.CharacterDescription.Gender == MetaData.Gender.Female)
				{
					img = GetImage.SheOne;
				}
				else
				{
					img = GetImage.NoOne;
				}
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
			this.pbImage.Image = img;

			//Lifesection
			this.cblifesection.SelectedIndex = 0;
			for (int i = 0; i < this.cblifesection.Items.Count; i++)
			{
				MetaData.LifeSections at = (LocalizedLifeSections)
					this.cblifesection.Items[i];
				if (at == sdesc.CharacterDescription.LifeSection)
				{
					this.cblifesection.SelectedIndex = i;
					break;
				}
			}

			this.rbfemale.Checked = (
				sdesc.CharacterDescription.Gender == MetaData.Gender.Female
			);
			this.rbmale.Checked = (
				sdesc.CharacterDescription.Gender == MetaData.Gender.Male
			);

			//NPC Type
			this.cbservice.SelectedIndex = 0;
			for (int i = 0; i < this.cbservice.Items.Count; i++)
			{
				object o = this.cbservice.Items[i];
				MetaData.ServiceTypes at;
				if (o.GetType() == typeof(Alias))
				{
					at = (LocalizedServiceTypes)((uint)((Alias)o).Id);
				}
				else
				{
					at = (LocalizedServiceTypes)o;
				}

				if (at == sdesc.CharacterDescription.ServiceTypes)
				{
					this.cbservice.SelectedIndex = i;
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
					this.lbsubspec.Text = "Sub Species: Orang-utan";
					this.lbsubspec.Visible = true;
				}
				if (sdesc.Castaway.Subspecies == 1 && (int)sdesc.Nightlife.Species == 3)
				{
					this.lbsubspec.Text = "Sub Species: Leopard";
					this.lbsubspec.Visible = true;
				}
				if (sdesc.Castaway.Subspecies == 1 && (int)sdesc.Nightlife.Species < 3)
				{
					this.lbsubspec.Text = "Sub Species: Wild Dog";
					this.lbsubspec.Visible = true;
				}
			}
			else
			{
				this.lbsubspec.Visible = false;
			}

			if (sdesc.IsCharSplit)
			{
				this.lbSplitChar.Visible = true;
			}
			else
			{
				this.lbSplitChar.Visible = false;
			}
		}

		void RefreshCareer(Wrapper.ExtSDesc sdesc)
		{
			this.lpRetirement.Enabled =
				this.cbRetirement.Enabled =
				this.tbpension.Enabled =
					sdesc.CharacterDescription.Realage > 19;
			this.pbCareerLevel.Value = sdesc.CharacterDescription.CareerLevel;
			this.lpRetirement.Value = sdesc.CharacterDescription.RetiredLevel;
			this.pbCareerPerformance.Value = sdesc
				.CharacterDescription
				.CareerPerformance;
			this.tbaccholidays.Text = Convert.ToString(
				(float)sdesc.CharacterDescription.PTO / 100
			);
			this.tbpension.Text = sdesc.CharacterDescription.Pension.ToString();

			//Career
			this.tbcareervalue.Text =
				"0x" + Helper.HexString((uint)sdesc.CharacterDescription.Career);
			this.cbcareer.SelectedIndex = 0;
			for (int i = 0; i < this.cbcareer.Items.Count; i++)
			{
				object o = this.cbcareer.Items[i];
				MetaData.Careers at;
				if (o.GetType() == typeof(Alias))
				{
					at = (LocalizedCareers)((uint)((Alias)o).Id);
				}
				else
				{
					at = (LocalizedCareers)o;
				}

				if (at == sdesc.CharacterDescription.Career)
				{
					this.cbcareer.SelectedIndex = i;
					break;
				}
			}

			this.cbRetirement.SelectedIndex = 0;
			for (int i = 0; i < this.cbRetirement.Items.Count; i++)
			{
				object o = this.cbRetirement.Items[i];
				MetaData.Careers at;
				if (o.GetType() == typeof(Alias))
				{
					at = (LocalizedCareers)((uint)((Alias)o).Id);
				}
				else
				{
					at = (LocalizedCareers)o;
				}

				if (at == sdesc.CharacterDescription.Retired)
				{
					this.cbRetirement.SelectedIndex = i;
					break;
				}
			}

			//school
			this.cbschooltype.SelectedIndex = 0;
			this.tbschooltype.Visible = true;
			for (int i = 0; i < this.cbschooltype.Items.Count; i++)
			{
				LocalizedSchoolType type;
				object o = this.cbschooltype.Items[i];
				if (o.GetType() == typeof(Alias))
				{
					type = (LocalizedSchoolType)((uint)((Alias)o).Id);
				}
				else
				{
					type = (LocalizedSchoolType)o;
				}

				if (
					sdesc.CharacterDescription.SchoolType
					== (MetaData.SchoolTypes)type
				)
				{
					this.cbschooltype.SelectedIndex = i;
					break;
				}
			}

			this.tbschooltype.Text =
				"0x" + Helper.HexString((uint)sdesc.CharacterDescription.SchoolType);

			//grades and school
			this.cbgrade.SelectedIndex = 0;
			for (int i = 0; i < this.cbgrade.Items.Count; i++)
			{
				MetaData.Grades grade;
				object o = this.cbgrade.Items[i];
				if (o.GetType() == typeof(Alias))
				{
					grade = (LocalizedGrades)((uint)((Alias)o).Id);
				}
				else
				{
					grade = (LocalizedGrades)o;
				}

				if (sdesc.CharacterDescription.Grade == (MetaData.Grades)grade)
				{
					this.cbgrade.SelectedIndex = i;
					break;
				}
			}
			//Aspiration
			this.pbAspBliz.Value = sdesc.CharacterDescription.BlizLifelinePoints;
			this.pbAspCur.Value = sdesc.CharacterDescription.LifelinePoints;
			SelectAspiration(cbaspiration, sdesc.Freetime.PrimaryAspiration);
			this.tblifelinescore.Text =
				sdesc.CharacterDescription.LifelineScore.ToString();
			this.pnCareer.BackgroundImage = pnimage;
			if (
				(int)sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Freetime
				&& !Helper.WindowsRegistry.AllowChangeOfSecondaryAspiration
			)
			{
				this.cbaspiration.Enabled =
					sdesc.Freetime.SecondaryAspiration
					== MetaData.AspirationTypes.Nothing;
			}
			else
			{
				this.cbaspiration.Enabled = true;
			}
		}

		void RefreshInterests(Wrapper.ExtSDesc sdesc)
		{
			this.pbAnimals.Value = sdesc.Interests.Animals;
			this.pbCrime.Value = sdesc.Interests.Crime;
			this.pbCulture.Value = sdesc.Interests.Culture;
			this.pbEntertainment.Value = sdesc.Interests.Entertainment;
			this.pbEnvironment.Value = sdesc.Interests.Environment;
			this.pbFashion.Value = sdesc.Interests.Fashion;
			this.pbFood.Value = sdesc.Interests.Food;
			this.pbHealth.Value = sdesc.Interests.Health;
			this.pbMoney.Value = sdesc.Interests.Money;
			this.pbParanormal.Value = sdesc.Interests.Paranormal;
			this.pbPolitics.Value = sdesc.Interests.Politics;
			this.pbSchool.Value = sdesc.Interests.School;
			this.pbSciFi.Value = sdesc.Interests.Scifi;
			this.pbSports.Value = sdesc.Interests.Sports;
			this.pbToys.Value = sdesc.Interests.Toys;
			this.pbTravel.Value = sdesc.Interests.Travel;
			this.pbWeather.Value = sdesc.Interests.Weather;
			this.pbWork.Value = sdesc.Interests.Work;

			this.pbPetEating.Value = sdesc.Interests.Environment;
			this.pbPetWeather.Value = sdesc.Interests.Food;
			this.pbPetPlaying.Value = sdesc.Interests.Culture;
			this.pbPetSpooky.Value = sdesc.Interests.Money;
			this.pbPetSleep.Value = sdesc.Interests.Entertainment;
			this.pbPetToy.Value = sdesc.Interests.Health;
			this.pbPetPets.Value = sdesc.Interests.Politics;
			this.pbPetOutside.Value = sdesc.Interests.Crime;
			this.pbPetAnimals.Value = sdesc.Interests.Fashion;

			this.pnInt.BackgroundImage = pnimage;
		}

		void RefreshCharcter(Wrapper.ExtSDesc sdesc)
		{
			this.cbzodiac.SelectedIndex = (
				(ushort)sdesc.CharacterDescription.ZodiacSign - 1
			);

			//Character
			this.pbNeat.Value = sdesc.Character.Neat;
			this.pbOutgoing.Value = sdesc.Character.Outgoing;
			this.pbActive.Value = sdesc.Character.Active;
			this.pbPlayful.Value = sdesc.Character.Playful;
			this.pbNice.Value = sdesc.Character.Nice;

			//Genetic Character
			this.pbGNeat.Value = sdesc.GeneticCharacter.Neat;
			this.pbGOutgoing.Value = sdesc.GeneticCharacter.Outgoing;
			this.pbGActive.Value = sdesc.GeneticCharacter.Active;
			this.pbGPlayful.Value = sdesc.GeneticCharacter.Playful;
			this.pbGNice.Value = sdesc.GeneticCharacter.Nice;

			pbWoman.Value = sdesc.Interests.FemalePreference;
			pbMan.Value = sdesc.Interests.MalePreference;
			this.pnChar.BackgroundImage = pnimage;
		}
		#endregion

		private void Activate_biMax(object sender, EventArgs e)
		{
			if (this.pnSkill.Visible)
			{
				InternalChange = true;
				foreach (Control c in pnSkill.Controls)
				{
					if (c == this.pbFat)
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
				this.ChangedSkill(null, null);
			}
			else if (this.pnChar.Visible)
			{
				InternalChange = true;
				foreach (Control c in this.pnHumanChar.Controls)
				{
					if (c is LabeledProgressBar)
					{
						((LabeledProgressBar)c).Value = ((LabeledProgressBar)c).Maximum;
					}
				}

				InternalChange = false;
				this.ChangedChar(null, null);
			}
			else if (this.pnInt.Visible)
			{
				InternalChange = true;
				foreach (Control c in this.pnPetInt.Controls)
				{
					if (c is LabeledProgressBar)
					{
						((LabeledProgressBar)c).Value = ((LabeledProgressBar)c).Maximum;
					}
				}

				foreach (Control c in this.pnSimInt.Controls)
				{
					if (c is LabeledProgressBar)
					{
						((LabeledProgressBar)c).Value = ((LabeledProgressBar)c).Maximum;
					}
				}

				InternalChange = false;
				this.ChangedInt(null, null);
			}
			else if (this.pnRel.Visible)
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
						if (this.srcRel.Srel != null)
						{
							srcRel.Srel.Longterm = 100;
							srcRel.Srel.Shortterm = 100;
							srcRel.Srel.Changed = true;
						}

						if (this.dstRel.Srel != null)
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
			else if (this.pnEP9.Visible)
			{
				InternalChange = true;
				pbRomance.Value = pbRomance.Maximum;
				//intern = false; this.ChangedVarious(null, null);
			}
		}

		private void Activate_biRand(object sender, EventArgs e)
		{
			Random rnd = new Random();
			if (this.pnSkill.Visible)
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
				this.ChangedSkill(null, null);
			}
			else if (this.pnChar.Visible)
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
				this.ChangedSkill(null, null);
			}
			else if (this.pnInt.Visible)
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
				this.ChangedSkill(null, null);
			}
			else if (this.pnRel.Visible)
			{
				foreach (SteepValley.Windows.Forms.XPListViewItem lvi in lv.Items)
				{
					if (lvi.GroupIndex != 1)
					{
						lvi.Selected = true;
						int baseval = rnd.Next(200) - 100;
						if (this.srcRel.Srel != null)
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

						if (this.dstRel.Srel != null)
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
			Majors v;
			if (o.GetType() == typeof(Alias))
			{
				v = (Majors)((Alias)o).Id;
			}
			else
			{
				v = (Majors)o;
			}

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
				tbcareervalue.Text = "0x" + Helper.HexString((uint)a.Id);
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
				rec = (uint)a.Id;
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
				tbschooltype.Text = "0x" + Helper.HexString((uint)a.Id);
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
				Sdesc.SimId = Helper.StringToUInt32(this.tbsim.Text, Sdesc.SimId, 16);
				Sdesc.FamilyInstance = Helper.StringToUInt16(
					this.tbfaminst.Text,
					Sdesc.FamilyInstance,
					16
				);
				Sdesc.Instance = Helper.StringToUInt16(
					this.tbsinstance.Text,
					Sdesc.Instance,
					16
				);

				Sdesc.CharacterDescription.Age = Helper.StringToUInt16(
					this.tbage.Text,
					Sdesc.CharacterDescription.Age,
					10
				);
				if (Sdesc.SimName != tbsimdescname.Text)
				{
					Sdesc.SimName = this.tbsimdescname.Text;
				}

				if (Sdesc.SimFamilyName != tbsimdescfamname.Text)
				{
					Sdesc.SimFamilyName = this.tbsimdescfamname.Text;
				}

				this.tbsim.ReadOnly = !UserVerification.HaveUserId;

				//Lifesection
				Sdesc.CharacterDescription.LifeSection = (LocalizedLifeSections)
					this.cblifesection.SelectedItem;

				if (this.rbfemale.Checked)
				{
					Sdesc.CharacterDescription.Gender = MetaData.Gender.Female;
				}
				else
				{
					Sdesc.CharacterDescription.Gender = MetaData.Gender.Male;
				}

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
						this.lbsubspec.Text = "Sub Species: Orang-utan";
						this.lbsubspec.Visible = true;
					}
					if (
						Sdesc.Castaway.Subspecies == 1
						&& (int)Sdesc.Nightlife.Species == 3
					)
					{
						this.lbsubspec.Text = "Sub Species: Leopard";
						this.lbsubspec.Visible = true;
					}
					if (
						Sdesc.Castaway.Subspecies == 1
						&& (int)Sdesc.Nightlife.Species < 3
					)
					{
						this.lbsubspec.Text = "Sub Species: Wild Dog";
						this.lbsubspec.Visible = true;
					}
				}
				else
				{
					this.lbsubspec.Visible = false;
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
					(LocalizedServiceTypes)this.cbservice.SelectedItem;
				this.tbnpc.Text =
					"0x" + Helper.HexString(Sdesc.CharacterDescription.NPCType);
				if (this.btOriGuid.Enabled)
				{
					this.btOriGuid.Visible = true;
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
					Sdesc.Interests.Animals = (ushort)this.pbAnimals.Value;
					Sdesc.Interests.Crime = (ushort)this.pbCrime.Value;
					Sdesc.Interests.Culture = (ushort)this.pbCulture.Value;
					Sdesc.Interests.Entertainment = (ushort)this.pbEntertainment.Value;
					Sdesc.Interests.Environment = (ushort)this.pbEnvironment.Value;
					Sdesc.Interests.Fashion = (ushort)this.pbFashion.Value;
					Sdesc.Interests.Food = (ushort)this.pbFood.Value;
					Sdesc.Interests.Health = (ushort)this.pbHealth.Value;
					Sdesc.Interests.Money = (ushort)this.pbMoney.Value;
					Sdesc.Interests.Paranormal = (ushort)this.pbParanormal.Value;
					Sdesc.Interests.Politics = (ushort)this.pbPolitics.Value;
					Sdesc.Interests.School = (ushort)this.pbSchool.Value;
					Sdesc.Interests.Scifi = (ushort)this.pbSciFi.Value;
					Sdesc.Interests.Sports = (ushort)this.pbSports.Value;
					Sdesc.Interests.Toys = (ushort)this.pbToys.Value;
					Sdesc.Interests.Travel = (ushort)this.pbTravel.Value;
					Sdesc.Interests.Weather = (ushort)this.pbWeather.Value;
					Sdesc.Interests.Work = (ushort)this.pbWork.Value;
				}
				else
				{
					Sdesc.Interests.Environment = (ushort)this.pbPetEating.Value;
					Sdesc.Interests.Food = (ushort)this.pbPetWeather.Value;
					Sdesc.Interests.Culture = (ushort)this.pbPetPlaying.Value;
					Sdesc.Interests.Money = (ushort)this.pbPetSpooky.Value;
					Sdesc.Interests.Entertainment = (ushort)this.pbPetSleep.Value;
					Sdesc.Interests.Health = (ushort)this.pbPetToy.Value;
					Sdesc.Interests.Politics = (ushort)this.pbPetPets.Value;
					Sdesc.Interests.Crime = (ushort)this.pbPetOutside.Value;
					Sdesc.Interests.Fashion = (ushort)this.pbPetAnimals.Value;
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
					this.pbCareerLevel.Value;
				Sdesc.CharacterDescription.CareerPerformance = (short)
					this.pbCareerPerformance.Value;
				Sdesc.CharacterDescription.RetiredLevel = (ushort)
					this.lpRetirement.Value;
				Sdesc.CharacterDescription.Pension = Convert.ToUInt16(
					this.tbpension.Text
				);

				//Career
				Sdesc.CharacterDescription.Career = (MetaData.Careers)
					Helper.StringToUInt32(
						this.tbcareervalue.Text,
						(uint)Sdesc.CharacterDescription.Career,
						16
					);

				//school
				Sdesc.CharacterDescription.SchoolType =
					(MetaData.SchoolTypes)
						Helper.StringToUInt32(
							this.tbschooltype.Text,
							(uint)Sdesc.CharacterDescription.SchoolType,
							16
						);

				//grades and school
				Sdesc.CharacterDescription.Grade = (LocalizedGrades)
					cbgrade.SelectedItem;

				// Accrued Hoildays
				Sdesc.CharacterDescription.PTO = (ushort)(
					Helper.StringToFloat(
						this.tbaccholidays.Text,
						Sdesc.CharacterDescription.PTO
					) * 100
				);

				//Aspiration
				Sdesc.CharacterDescription.BlizLifelinePoints = (ushort)
					this.pbAspBliz.Value;
				Sdesc.CharacterDescription.LifelinePoints = (short)this.pbAspCur.Value;
				Sdesc.Freetime.PrimaryAspiration = (LocalizedAspirationTypes)
					this.cbaspiration.SelectedItem;
				Sdesc.CharacterDescription.LifelineScore = Helper.StringToUInt32(
					this.tblifelinescore.Text,
					(uint)Sdesc.CharacterDescription.LifelineScore,
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
					this.cbzodiac.SelectedIndex + 1
				);

				//Character
				Sdesc.Character.Neat = (ushort)this.pbNeat.Value;
				Sdesc.Character.Outgoing = (ushort)this.pbOutgoing.Value;
				Sdesc.Character.Active = (ushort)this.pbActive.Value;
				Sdesc.Character.Playful = (ushort)this.pbPlayful.Value;
				Sdesc.Character.Nice = (ushort)this.pbNice.Value;

				//Genetic Character
				Sdesc.GeneticCharacter.Neat = (ushort)this.pbGNeat.Value;
				Sdesc.GeneticCharacter.Outgoing = (ushort)this.pbGOutgoing.Value;
				Sdesc.GeneticCharacter.Active = (ushort)this.pbGActive.Value;
				Sdesc.GeneticCharacter.Playful = (ushort)this.pbGPlayful.Value;
				Sdesc.GeneticCharacter.Nice = (ushort)this.pbGNice.Value;

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
						Sdesc.Skills.Body = (ushort)this.pbPupbody.Value;
						Sdesc.Skills.Charisma = (ushort)this.pbPupCharisma.Value;
						Sdesc.Skills.Cleaning = (ushort)this.pbPupClean.Value;
						Sdesc.Skills.Creativity = (ushort)this.pbPupCreative.Value;
						Sdesc.Skills.Logic = (ushort)this.pbPupLogic.Value;
						Sdesc.Skills.Mechanical = (ushort)this.pbPupMech.Value;
						Sdesc.Skills.Fatness = (ushort)this.pbFat.Value;
						this.pbBody.Visible = false;
						this.pbCharisma.Visible = false;
						this.pbClean.Visible = false;
						this.pbCreative.Visible = false;
						this.pbLogic.Visible = false;
						this.pbMech.Visible = false;
						this.pbCooking.Visible = false;
						this.pbMusic.Visible = false;
						this.pbArty.Visible = false;
						this.pbReputate.Visible = false;
						this.pbPupbody.Visible = true;
						this.pbPupCharisma.Visible = true;
						this.pbPupClean.Visible = true;
						this.pbPupCreative.Visible = true;
						this.pbPupLogic.Visible = true;
						this.pbPupMech.Visible = true;
					}
					else
					{
						if ((int)Sdesc.Nightlife.Species > 0)
						{
							Sdesc.Skills.Fatness = (ushort)this.pbFat.Value;
							this.pbPupbody.Visible = false;
							this.pbPupCharisma.Visible = false;
							this.pbPupClean.Visible = false;
							this.pbPupCreative.Visible = false;
							this.pbPupLogic.Visible = false;
							this.pbPupMech.Visible = false;
							this.pbBody.Visible = false;
							this.pbCharisma.Visible = false;
							this.pbClean.Visible = false;
							this.pbCreative.Visible = false;
							this.pbMusic.Visible = false;
							this.pbArty.Visible = false;
							this.pbLogic.Visible = false;
							this.pbReputate.Visible = false;
							this.pbMech.Visible = false;
							this.pbCooking.Visible = false;
							this.pbReputate.Visible = false;
						}
						else
						{
							Sdesc.Skills.Body = (ushort)this.pbBody.Value;
							Sdesc.Skills.Charisma = (ushort)this.pbCharisma.Value;
							Sdesc.Skills.Cleaning = (ushort)this.pbClean.Value;
							Sdesc.Skills.Cooking = (ushort)this.pbCooking.Value;
							Sdesc.Skills.Creativity = (ushort)this.pbCreative.Value;
							Sdesc.Skills.Logic = (ushort)this.pbLogic.Value;
							Sdesc.Skills.Mechanical = (ushort)this.pbMech.Value;
							Sdesc.Skills.Fatness = (ushort)this.pbFat.Value;
							if (Helper.WindowsRegistry.ShowMoreSkills)
							{
								Sdesc.Skills.Music = (ushort)this.pbMusic.Value;
							}

							if (Helper.WindowsRegistry.ShowMoreSkills)
							{
								Sdesc.Skills.Art = (ushort)this.pbArty.Value;
							}

							this.pbPupbody.Visible = false;
							this.pbPupCharisma.Visible = false;
							this.pbPupClean.Visible = false;
							this.pbPupCreative.Visible = false;
							this.pbPupLogic.Visible = false;
							this.pbPupMech.Visible = false;
							this.pbBody.Visible = true;
							this.pbCharisma.Visible = true;
							this.pbClean.Visible = true;
							this.pbCreative.Visible = true;
							this.pbLogic.Visible = true;
							this.pbReputate.Visible = true;
							this.pbMech.Visible = true;
							this.pbCooking.Visible = true;
							this.pbMusic.Visible = Helper
								.WindowsRegistry
								.ShowMoreSkills;
							this.pbArty.Visible = Helper.WindowsRegistry.ShowMoreSkills;
							if (
								(int)Sdesc.Version
								>= (int)
									PackedFiles.Wrapper.SDescVersions.Apartment
							)
							{
								Sdesc.Apartment.Reputation = (short)
									this.pbReputate.Value;
								this.pbReputate.Visible = true;
							}
							else
							{
								this.pbReputate.Visible = false;
							}
						}
					}
				}
				else
				{
					Sdesc.Skills.Body = (ushort)this.pbBody.Value;
					Sdesc.Skills.Charisma = (ushort)this.pbCharisma.Value;
					Sdesc.Skills.Cleaning = (ushort)this.pbClean.Value;
					Sdesc.Skills.Cooking = (ushort)this.pbCooking.Value;
					Sdesc.Skills.Creativity = (ushort)this.pbCreative.Value;
					Sdesc.Skills.Logic = (ushort)this.pbLogic.Value;
					Sdesc.Skills.Mechanical = (ushort)this.pbMech.Value;
					Sdesc.Skills.Fatness = (ushort)this.pbFat.Value;
					if (Helper.WindowsRegistry.ShowMoreSkills)
					{
						Sdesc.Skills.Music = (ushort)this.pbMusic.Value;
					}

					if (Helper.WindowsRegistry.ShowMoreSkills)
					{
						Sdesc.Skills.Art = (ushort)this.pbArty.Value;
					}

					this.pbPupbody.Visible = false;
					this.pbPupCharisma.Visible = false;
					this.pbPupClean.Visible = false;
					this.pbPupCreative.Visible = false;
					this.pbPupLogic.Visible = false;
					this.pbPupMech.Visible = false;
					this.pbBody.Visible = true;
					this.pbCharisma.Visible = true;
					this.pbClean.Visible = true;
					this.pbCreative.Visible = true;
					this.pbLogic.Visible = true;
					this.pbReputate.Visible = true;
					this.pbMech.Visible = true;
					this.pbCooking.Visible = true;
					this.pbMusic.Visible = Helper.WindowsRegistry.ShowMoreSkills;
					this.pbArty.Visible = Helper.WindowsRegistry.ShowMoreSkills;
					this.pbReputate.Visible = false;
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
				Sdesc.CharacterDescription.GhostFlag.IsGhost = this.cbisghost.Checked;
				Sdesc.CharacterDescription.GhostFlag.CanPassThroughObjects =
					this.cbpassobject.Checked;
				Sdesc.CharacterDescription.GhostFlag.CanPassThroughWalls =
					this.cbpasswalls.Checked;
				Sdesc.CharacterDescription.GhostFlag.CanPassThroughPeople =
					this.cbpasspeople.Checked;
				Sdesc.CharacterDescription.GhostFlag.IgnoreTraversalCosts =
					this.cbignoretraversal.Checked;

				//body flags
				Sdesc.CharacterDescription.BodyFlag.Fit = this.cbfit.Checked;
				Sdesc.CharacterDescription.BodyFlag.Fat = this.cbfat.Checked;
				Sdesc.CharacterDescription.BodyFlag.PregnantFull =
					this.cbpregfull.Checked;
				Sdesc.CharacterDescription.BodyFlag.PregnantHalf =
					this.cbpreghalf.Checked;
				Sdesc.CharacterDescription.BodyFlag.PregnantHidden =
					this.cbpreginv.Checked;

				//misc
				Sdesc.CharacterDescription.PrevAgeDays = Helper.StringToUInt16(
					this.tbprevdays.Text,
					Sdesc.CharacterDescription.PrevAgeDays,
					10
				);
				Sdesc.CharacterDescription.AgeDuration = Helper.StringToUInt16(
					this.tbagedur.Text,
					Sdesc.CharacterDescription.AgeDuration,
					10
				);
				Sdesc.Unlinked = Helper.StringToUInt16(
					this.tbunlinked.Text,
					Sdesc.Unlinked,
					16
				);
				Sdesc.CharacterDescription.VoiceType = Helper.StringToUInt16(
					this.tbvoice.Text,
					Sdesc.CharacterDescription.VoiceType,
					16
				);
				Sdesc.CharacterDescription.AutonomyLevel = Helper.StringToUInt16(
					this.tbautonomy.Text,
					Sdesc.CharacterDescription.AutonomyLevel,
					16
				);
				Sdesc.CharacterDescription.NPCType = Helper.StringToUInt16(
					this.tbnpc.Text,
					Sdesc.CharacterDescription.NPCType,
					16
				);
				Sdesc.CharacterDescription.MotivesStatic = Helper.StringToUInt16(
					this.tbstatmot.Text,
					Sdesc.CharacterDescription.MotivesStatic,
					16
				);

				// motive decays
				Sdesc.Decay.Hunger = Helper.StringToInt16(
					this.tbdecHunger.Text,
					Sdesc.Decay.Hunger,
					10
				);
				Sdesc.Decay.Comfort = Helper.StringToInt16(
					this.tbdecComfort.Text,
					Sdesc.Decay.Comfort,
					10
				);
				Sdesc.Decay.Bladder = Helper.StringToInt16(
					this.tbdecBladder.Text,
					Sdesc.Decay.Bladder,
					10
				);
				Sdesc.Decay.Energy = Helper.StringToInt16(
					this.tbdecEnergy.Text,
					Sdesc.Decay.Energy,
					10
				);
				Sdesc.Decay.Hygiene = Helper.StringToInt16(
					this.tbdecHygiene.Text,
					Sdesc.Decay.Hygiene,
					10
				);
				Sdesc.Decay.Social = Helper.StringToInt16(
					this.tbdecSocial.Text,
					Sdesc.Decay.Social,
					10
				);
				Sdesc.Decay.Shopping = Helper.StringToInt16(
					this.tbdecShop.Text,
					Sdesc.Decay.Shopping,
					10
				);
				Sdesc.Decay.Fun = Helper.StringToInt16(
					this.tbdecFun.Text,
					Sdesc.Decay.Fun,
					10
				);
				Sdesc.Decay.Amorous = Helper.StringToInt16(
					this.tbdecAmor.Text,
					Sdesc.Decay.Amorous,
					10
				);
				Sdesc.Decay.ScratchC = Helper.StringToInt16(
					this.tbdecScratc.Text,
					Sdesc.Decay.ScratchC,
					10
				);

				//NPC Type
				this.cbservice.SelectedIndex = 0;
				for (int i = 0; i < this.cbservice.Items.Count; i++)
				{
					object o = this.cbservice.Items[i];
					MetaData.ServiceTypes at;
					if (o.GetType() == typeof(Alias))
					{
						at = (LocalizedServiceTypes)((uint)((Alias)o).Id);
					}
					else
					{
						at = (LocalizedServiceTypes)o;
					}

					if (at == Sdesc.CharacterDescription.ServiceTypes)
					{
						this.cbservice.SelectedIndex = i;
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
						this.tbmajor.Text,
						(uint)Sdesc.University.Major,
						16
					);

				if (this.cboncampus.Checked)
				{
					Sdesc.University.OnCampus = 0x1;
				}
				else
				{
					Sdesc.University.OnCampus = 0x0;
				}

				Sdesc.University.Effort = (ushort)this.pbEffort.Value;
				Sdesc.University.Grade = (ushort)this.pbLastGrade.Value;

				Sdesc.University.Time = (ushort)this.pbUniTime.Value;
				Sdesc.University.Influence = Helper.StringToUInt16(
					this.tbinfluence.Text,
					Sdesc.University.Influence,
					10
				);
				Sdesc.University.Semester = Helper.StringToUInt16(
					this.tbsemester.Text,
					Sdesc.University.Semester,
					10
				);
				if (
					!this.cbfreshman.Checked
					&& !this.cbSopho.Checked
					&& !this.cbJunior.Checked
					&& !this.cbSenior.Checked
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
					Sdesc.University.SemesterFlag.Freshman = this.cbfreshman.Checked;
					Sdesc.University.SemesterFlag.Sophomore = this.cbSopho.Checked;
					Sdesc.University.SemesterFlag.Junior = this.cbJunior.Checked;
					Sdesc.University.SemesterFlag.Senior = this.cbSenior.Checked;
				}
				Sdesc.University.SemesterFlag.GoodSem = this.cbGoodsem.Checked;
				Sdesc.University.SemesterFlag.Probation = this.cbprobation.Checked;
				Sdesc.University.SemesterFlag.Graduated = this.cbgraduate.Checked;
				Sdesc.University.SemesterFlag.AtClass = this.cbatclass.Checked;
				Sdesc.University.SemesterFlag.Dropped = this.cbdroped.Checked;
				Sdesc.University.SemesterFlag.Expelled = this.cbexpelled.Checked;

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
			if (this.cbfreshman.Checked)
			{
				this.cbSopho.Checked =
					this.cbJunior.Checked =
					this.cbSenior.Checked =
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
			if (this.cbSopho.Checked)
			{
				this.cbfreshman.Checked =
					this.cbJunior.Checked =
					this.cbSenior.Checked =
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
			if (this.cbJunior.Checked)
			{
				this.cbSopho.Checked =
					this.cbfreshman.Checked =
					this.cbSenior.Checked =
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
			if (this.cbSenior.Checked)
			{
				this.cbSopho.Checked =
					this.cbJunior.Checked =
					this.cbfreshman.Checked =
						false;
			}
			InternalChange = false;
			ChangedEP1(sender, e);
		}

		private void btOriGuid_Click(object sender, EventArgs e)
		{
			SimOriGuid.FixOrigGUID(Sdesc);
			this.lbFixedRes.Text = SimOriGuid.FixResult();
			this.lbFixedRes.Visible = true;
			cbSpecies.SelectedValue = Sdesc.Nightlife.Species;
			if (
				(int)Sdesc.Version
					== (int)PackedFiles.Wrapper.SDescVersions.Castaway
				&& Sdesc.Castaway.Subspecies > 0
			)
			{
				if (Sdesc.Castaway.Subspecies == 2)
				{
					this.lbsubspec.Text = "Sub Species: Orang-utan";
					this.lbsubspec.Visible = true;
				}
				if (Sdesc.Castaway.Subspecies == 1 && (int)Sdesc.Nightlife.Species == 3)
				{
					this.lbsubspec.Text = "Sub Species: Leopard";
					this.lbsubspec.Visible = true;
				}
				if (Sdesc.Castaway.Subspecies == 1 && (int)Sdesc.Nightlife.Species < 3)
				{
					this.lbsubspec.Text = "Sub Species: Wild Dog";
					this.lbsubspec.Visible = true;
				}
			}
			else
			{
				this.lbsubspec.Visible = false;
			}
		}

		private void cbdataflag1_CheckedChanged(object sender, EventArgs e)
		{
			if (InternalChange)
			{
				return;
			}

			Sdesc.CharacterDescription.PersonFlags1.IsZombie = this.cbpfZomb.Checked;
			Sdesc.CharacterDescription.PersonFlags1.PermaPlatinum =
				this.cbpfperma.Checked;
			Sdesc.CharacterDescription.PersonFlags1.IsVampire = this.cbpfvamp.Checked;
			Sdesc.CharacterDescription.PersonFlags1.VampireSmoke =
				this.cbpfvsmoke.Checked;
			Sdesc.CharacterDescription.PersonFlags1.WantHistory =
				this.cbpfwants.Checked;
			Sdesc.CharacterDescription.PersonFlags1.LycanCarrier =
				this.cbpflycar.Checked;
			Sdesc.CharacterDescription.PersonFlags1.LycanActive =
				this.cbpflyact.Checked;
			Sdesc.CharacterDescription.PersonFlags1.IsRunaway = this.cbpfrunaw.Checked;
			Sdesc.CharacterDescription.PersonFlags1.IsPlantsim = this.cbpfPlant.Checked;
			Sdesc.CharacterDescription.PersonFlags1.IsBigfoot = this.cbpfBigf.Checked;
			Sdesc.CharacterDescription.PersonFlags1.IsWitch = this.cbpfwitch.Checked;
			Sdesc.CharacterDescription.PersonFlags1.IsRoomate = this.cbpfroomy.Checked;
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
			SdscExtendedForm.Execute(this.Sdesc);
		}

		private void Activate_biMore(object sender, EventArgs e)
		{
			if (biMore.Text == "More")
			{
				mbiLink.Show(this.toolBar1, new Point(443, toolBar1.Height - 2));
			}
			else
			{
				mbiLink.Show(this.toolBar1, new Point(507, toolBar1.Height - 2));
			}
		}

		private void Activate_miRelink(object sender, EventArgs e)
		{
			this.tbsim.Text = "0x" + Helper.HexString(SimRelinkForm.Execute(Sdesc));
			this.btOriGuid.Visible = true;
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
				uint inst = Convert.ToUInt32(this.tbfaminst.Text, 16);
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
				uint inst = Convert.ToUInt32(this.tbfaminst.Text, 16);
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
			if (Sdesc == null)
			{
				lv.Package = null;
			}
			else
			{
				lv.Package = Sdesc.Package;
			}

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
						new Wrapper.ExtSDesc();
					sdesc.FileDescriptor = Sdesc.Package.NewDescriptor(
						MetaData.SIM_DESCRIPTION_FILE,
						0,
						Sdesc.FileDescriptor.Group,
						inst
					);
					sdesc.Package = Sdesc.Package;
					SteepValley.Windows.Forms.XPListViewItem lvi = lv.Add(sdesc);
					lvi.GroupIndex = 2;

					lvi.Tag = sdesc;
				}
			}
		}

		void ResetLabel()
		{
			this.dstRel.Srel = null;
			this.srcRel.Srel = null;
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
			if (srcRel.TargetSim == null)
			{
				img = null;
			}
			else
			{
				img = (Image)srcRel.Image;
			}

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
			if (dstRel.TargetSim == null)
			{
				img = null;
			}
			else
			{
				img = (Image)dstRel.Image.Clone();
			}

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
				if (Helper.WindowsRegistry.HiddenMode)
				{
					this.miAddRelation.Enabled =
						(
							(SteepValley.Windows.Forms.XPListViewItem)
								lv.SelectedItems[0]
						).GroupIndex == 1;
				}
				else
				{
					this.miAddRelation.Enabled =
						(
							(SteepValley.Windows.Forms.XPListViewItem)
								lv.SelectedItems[0]
						).GroupIndex == 1
						&& !Sdesc.Equals(lv.SelectedItems[0].Tag);
				}

				this.miRemRelation.Enabled =
					(
						(SteepValley.Windows.Forms.XPListViewItem)lv.SelectedItems[0]
					).GroupIndex != 1;

				string name =
					Localization.GetString("AddRelationCaption")
					.Replace("{name}", lv.SelectedItems[0].Text);
				this.miAddRelation.Text = name;

				name =
					Localization.GetString("RemoveRelationCaption")
					.Replace("{name}", lv.SelectedItems[0].Text);
				this.miRemRelation.Text = name;

				name =
					Localization.GetString("Max Relation to this Sim")
					.Replace("{name}", lv.SelectedItems[0].Text);
				this.mbiMaxThisRel.Text = name;
				this.mbiMaxThisRel.Enabled = this.miRemRelation.Enabled;

				this.mbiMaxKnownRel.Enabled = true;
			}
			else
			{
				this.miAddRelation.Enabled = false;
				this.miRemRelation.Enabled = false;
				this.mbiMaxThisRel.Enabled = false;
				this.mbiMaxKnownRel.Enabled = true;

				string name =
					Localization.GetString("AddRelationCaption")
					.Replace("{name}", Localization.GetString("Unknown"));
				this.miAddRelation.Text = name;

				name =
					Localization.GetString("RemoveRelationCaption")
					.Replace("{name}", Localization.GetString("Unknown"));
				this.miRemRelation.Text = name;
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
					if (this.srcRel.Srel != null)
					{
						srcRel.Srel.Longterm = 100;
						srcRel.Srel.Shortterm = 100;
						srcRel.Srel.Changed = true;
					}

					if (this.dstRel.Srel != null)
					{
						dstRel.Srel.Longterm = 100;
						dstRel.Srel.Shortterm = 100;
						dstRel.Srel.Changed = true;
					}
				}
			}

			this.SelectedSimRelationChanged(lv, null);
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
					this.lv_SelectedSimChanged(lv, null, null);
					if (this.srcRel.Srel != null)
					{
						if (srcRel.Srel.RelationState.IsKnown)
						{
							srcRel.Srel.Longterm = 100;
							srcRel.Srel.Shortterm = 100;
							srcRel.Srel.Changed = true;
						}
					}

					if (this.dstRel.Srel != null)
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
					this.lbTraits,
					sdesc.Nightlife.AttractionTraits1,
					sdesc.Nightlife.AttractionTraits2,
					sdesc.Nightlife.AttractionTraits3
				);
				SelectNightlifeItems(
					this.lbTurnOn,
					sdesc.Nightlife.AttractionTurnOns1,
					sdesc.Nightlife.AttractionTurnOns2,
					sdesc.Nightlife.AttractionTurnOns3
				);
				SelectNightlifeItems(
					this.lbTurnOff,
					sdesc.Nightlife.AttractionTurnOffs1,
					sdesc.Nightlife.AttractionTurnOffs2,
					sdesc.Nightlife.AttractionTurnOffs3
				);
				this.tbNTPerfume.Text = sdesc.Nightlife.PerfumeDuration.ToString();
				this.tbNTLove.Text = sdesc.Nightlife.LovePotionDuration.ToString();
				this.pnEP2.BackgroundImage = pnimage;
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
					this.tbNTPerfume.Text,
					Sdesc.Nightlife.PerfumeDuration,
					10
				);
				Sdesc.Nightlife.LovePotionDuration = Helper.StringToUInt16(
					this.tbNTLove.Text,
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
				);
				lvi.Tag = a;
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
			this.tbEp3Flag.Text = Helper.MinStrLength(
				Convert.ToString(sdesc.Business.Flags, 2),
				16
			);
			this.tbEp3Lot.Text = Helper.HexString(sdesc.Business.LotID);
			this.tbEp3Salery.Text = sdesc.Business.Salary.ToString();

			this.cbEp3Asgn.SelectedValue = sdesc.Business.Assignment;
			this.sblb.SimDescription = sdesc;
			this.llep3openinfo.Links[0].Enabled = (sblb.SelectedBusiness != null);
			this.pnEP3.BackgroundImage = pnimage;
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
					this.tbEp3Salery.Text,
					Sdesc.Business.Salary,
					10
				);
				Sdesc.Business.LotID = Helper.StringToUInt16(
					this.tbEp3Lot.Text,
					Sdesc.Business.LotID,
					16
				);
				Sdesc.Business.Flags = Helper.StringToUInt16(
					this.tbEp3Flag.Text,
					Sdesc.Business.Flags,
					2
				);
				Sdesc.Business.Assignment = (Wrapper.JobAssignment)
					this.cbEp3Asgn.SelectedValue;

				Sdesc.Changed = true;
			}
			finally
			{
				InternalChange = false;
			}
		}

		private void sblb_SelectedBusinessChanged(object sender, EventArgs e)
		{
			this.llep3openinfo.Links[0].Enabled = (sblb.SelectedBusiness != null);
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
			this.ptGifted.SetTraitLevel(0, 1, sdesc.Pets.PetTraits);
			this.ptHyper.SetTraitLevel(2, 3, sdesc.Pets.PetTraits);
			this.ptIndep.SetTraitLevel(4, 5, sdesc.Pets.PetTraits);
			this.ptAggres.SetTraitLevel(6, 7, sdesc.Pets.PetTraits);
			this.ptPigpen.SetTraitLevel(8, 9, sdesc.Pets.PetTraits);
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
					this.ptGifted.UpdateTraits(0, 1, Sdesc.Pets.PetTraits);
					this.ptHyper.UpdateTraits(2, 3, Sdesc.Pets.PetTraits);
					this.ptIndep.UpdateTraits(4, 5, Sdesc.Pets.PetTraits);
					this.ptAggres.UpdateTraits(6, 7, Sdesc.Pets.PetTraits);
					this.ptPigpen.UpdateTraits(8, 9, Sdesc.Pets.PetTraits);
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
			if (!InternalChange && this.btOriGuid.Enabled)
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
			bool showsim = true;
			if (Sdesc == null)
			{
				showsim = true;
			}
			else
			{
				if (
					(int)Sdesc.Version
					>= (int)PackedFiles.Wrapper.SDescVersions.Pets
				)
				{
					showsim = Sdesc.Nightlife.IsHuman;
				}
				else
				{
					showsim = true;
				}
			}
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
				this.EnthusiasmIndexChanged(cbHobbyEnth, null);
			}

			cbHobbyPre.SelectedValue = sdesc.Freetime.HobbyPredistined;
			this.tbBugColl.Text = "0x" + Helper.HexString(sdesc.Freetime.BugCollection);
			this.tbLtAsp.Text =
				"0x" + Helper.HexString(sdesc.Freetime.LongtermAspiration);
			this.tbUnlockPts.Text =
				sdesc.Freetime.LongtermAspirationUnlockPoints.ToString();
			this.tbUnlocksUsed.Text =
				sdesc.Freetime.LongtermAspirationUnlocksSpent.ToString();
			this.tb7hunger.Text = sdesc.Freetime.HungerDecayModifier.ToString();
			this.tb7comfort.Text = sdesc.Freetime.ComfortDecayModifier.ToString();
			this.tb7bladder.Text = sdesc.Freetime.BladderDecayModifier.ToString();
			this.tb7energy.Text = sdesc.Freetime.EnergyDecayModifier.ToString();
			this.tb7hygiene.Text = sdesc.Freetime.HygieneDecayModifier.ToString();
			this.tb7fun.Text = sdesc.Freetime.FunDecayModifier.ToString();
			this.tb7social.Text = sdesc.Freetime.SocialPublicDecayModifier.ToString();
			SelectAspiration(cbaspiration2, sdesc.Freetime.SecondaryAspiration);

			this.pnEP7.BackgroundImage = pnimage;
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
						this.tbBugColl.Text,
						Sdesc.Freetime.BugCollection,
						16
					);
					Sdesc.Freetime.LongtermAspiration = Helper.StringToUInt16(
						this.tbLtAsp.Text,
						Sdesc.Freetime.LongtermAspiration,
						16
					);
					Sdesc.Freetime.LongtermAspirationUnlockPoints =
						Helper.StringToUInt16(
							this.tbUnlockPts.Text,
							Sdesc.Freetime.LongtermAspirationUnlockPoints,
							10
						);
					Sdesc.Freetime.LongtermAspirationUnlocksSpent =
						Helper.StringToUInt16(
							this.tbUnlocksUsed.Text,
							Sdesc.Freetime.LongtermAspirationUnlocksSpent,
							10
						);

					Sdesc.Freetime.HungerDecayModifier = Helper.StringToUInt16(
						this.tb7hunger.Text,
						Sdesc.Freetime.HungerDecayModifier,
						10
					);
					Sdesc.Freetime.ComfortDecayModifier = Helper.StringToUInt16(
						this.tb7comfort.Text,
						Sdesc.Freetime.ComfortDecayModifier,
						10
					);
					Sdesc.Freetime.BladderDecayModifier = Helper.StringToUInt16(
						this.tb7bladder.Text,
						Sdesc.Freetime.BladderDecayModifier,
						10
					);
					Sdesc.Freetime.EnergyDecayModifier = Helper.StringToUInt16(
						this.tb7energy.Text,
						Sdesc.Freetime.EnergyDecayModifier,
						10
					);
					Sdesc.Freetime.HygieneDecayModifier = Helper.StringToUInt16(
						this.tb7hygiene.Text,
						Sdesc.Freetime.HygieneDecayModifier,
						10
					);
					Sdesc.Freetime.FunDecayModifier = Helper.StringToUInt16(
						this.tb7fun.Text,
						Sdesc.Freetime.FunDecayModifier,
						10
					);
					Sdesc.Freetime.SocialPublicDecayModifier = Helper.StringToUInt16(
						this.tb7social.Text,
						Sdesc.Freetime.SocialPublicDecayModifier,
						10
					);

					Sdesc.Freetime.HobbyPredistined =
						PackedFiles.Wrapper.SdscFreetime.IndexToHobbies(
							cbHobbyPre.SelectedIndex
						);
					Sdesc.Freetime.SecondaryAspiration = (LocalizedAspirationTypes)
						this.cbaspiration2.SelectedItem;

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
				this.pbhbenth.Value = Sdesc.Freetime.HobbyEnthusiasm[
					cbHobbyEnth.SelectedIndex
				];
				this.pbhbenth.Enabled = true;
			}
			else
			{
				this.pbhbenth.Value = 0;
				this.pbhbenth.Enabled = false;
			}
		}
		#endregion
	}
}
