// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Sdsc;

namespace SimPe.PackedFiles.Wrapper
{
	public partial class SimInfo : Form
	{
		public SimInfo(ExtSDesc Sim, Image img)
		{
			InitializeComponent();
			pbImage.Image = img;
			//this.pnheader.HeaderText = Sim.SimName + "\'s Profile";
			lbshead.Text = Sim.SimName + " " + Sim.SimFamilyName + ",";
			lbshead.Text += "\r\n  From the " + Sim.HouseholdName + " family";
			if (
				Sim.CharacterDescription.ServiceTypes
				!= Data.ServiceTypes.Normal
			)
			{
				lbshead.Text +=
					",\r\n  A "
					+ Localization.GetString(
						Sim.CharacterDescription.ServiceTypes.ToString()
					);
			}
			else if (
				Sim.CharacterDescription.Career
				!= Data.Careers.Unemployed
			)
			{
				lbshead.Text +=
					",\r\n  Works in the "
					+ (Data.LocalizedCareers)Sim.CharacterDescription.Career
					+ " career";
			}
			else if (
				Sim.CharacterDescription.Retired
					!= Data.Careers.Unemployed
				&& Sim.CharacterDescription.Realage > 19
			)
			{
				lbshead.Text +=
					",\r\n  Retired from the "
					+ (Data.LocalizedCareers)Sim.CharacterDescription.Retired
					+ " career";
			}
			else if (
				Sim.University.OnCampus == 0x1
				&& Sim.University.Major != Data.Majors.Unset
			)
			{
				lbshead.Text +=
					",\r\n  Studying " + Sim.University.Major;
			}
			else if (
				Sim.CharacterDescription.Realage < 17
				&& Sim.CharacterDescription.SchoolType
					!= Data.SchoolTypes.NoSchool
			)
			{
				if (Sim.CharacterDescription.Realage < 3)
				{
					lbshead.Text +=
						",\r\n  Will attend "
						+ (Data.LocalizedSchoolType)Sim.CharacterDescription.SchoolType;
				}
				else
				{
					lbshead.Text +=
						",\r\n  Attends "
						+ (Data.LocalizedSchoolType)Sim.CharacterDescription.SchoolType;
				}

				if (!lbshead.Text.EndsWith("School"))
				{
					lbshead.Text += " School";
				}
			}
			lbInform.Text = SimOriGuid.AboutSim(
				Sim
			);
		}
	}
}
