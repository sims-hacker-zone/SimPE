using System.Drawing;
using System.Windows.Forms;

namespace SimPe.PackedFiles.Wrapper
{
	public partial class SimInfo : Form
	{
		public SimInfo(ExtSDesc Sim, Image img)
		{
			InitializeComponent();
			this.pbImage.Image = img;
			//this.pnheader.HeaderText = Sim.SimName + "\'s Profile";
			this.lbshead.Text = Sim.SimName + " " + Sim.SimFamilyName + ",";
			this.lbshead.Text += "\r\n  From the " + Sim.HouseholdName + " family";
			if (
				Sim.CharacterDescription.ServiceTypes
				!= Data.MetaData.ServiceTypes.Normal
			)
			{
				this.lbshead.Text +=
					",\r\n  A "
					+ Localization.GetString(
						Sim.CharacterDescription.ServiceTypes.ToString()
					);
			}
			else if (
				Sim.CharacterDescription.Career
				!= Data.MetaData.Careers.Unemployed
			)
			{
				this.lbshead.Text +=
					",\r\n  Works in the "
					+ (Data.LocalizedCareers)Sim.CharacterDescription.Career
					+ " career";
			}
			else if (
				Sim.CharacterDescription.Retired
					!= Data.MetaData.Careers.Unemployed
				&& Sim.CharacterDescription.Realage > 19
			)
			{
				this.lbshead.Text +=
					",\r\n  Retired from the "
					+ (Data.LocalizedCareers)Sim.CharacterDescription.Retired
					+ " career";
			}
			else if (
				Sim.University.OnCampus == 0x1
				&& Sim.University.Major != Data.Majors.Unset
			)
			{
				this.lbshead.Text +=
					",\r\n  Studying " + (Data.Majors)Sim.University.Major;
			}
			else if (
				Sim.CharacterDescription.Realage < 17
				&& Sim.CharacterDescription.SchoolType
					!= Data.MetaData.SchoolTypes.NoSchool
			)
			{
				if (Sim.CharacterDescription.Realage < 3)
				{
					this.lbshead.Text +=
						",\r\n  Will attend "
						+ (Data.LocalizedSchoolType)Sim.CharacterDescription.SchoolType;
				}
				else
				{
					this.lbshead.Text +=
						",\r\n  Attends "
						+ (Data.LocalizedSchoolType)Sim.CharacterDescription.SchoolType;
				}

				if (!this.lbshead.Text.EndsWith("School"))
				{
					this.lbshead.Text += " School";
				}
			}
			this.lbInform.Text = UserInterface.SimOriGuid.AboutSim(
				Sim
			);
		}
	}
}
