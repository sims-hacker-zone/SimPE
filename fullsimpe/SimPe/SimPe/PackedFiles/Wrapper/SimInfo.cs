using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimPe.PackedFiles.Wrapper
{
    public partial class SimInfo : Form
    {
        public SimInfo(Wrapper.ExtSDesc Sim, Image img)
        {
            InitializeComponent();
            this.pbImage.Image = img;
            //this.pnheader.HeaderText = Sim.SimName + "\'s Profile";
            this.lbshead.Text = Sim.SimName + " " + Sim.SimFamilyName + ",";
            this.lbshead.Text += "\r\n  From the " + Sim.HouseholdName + " family";
            if (Sim.CharacterDescription.ServiceTypes != SimPe.Data.MetaData.ServiceTypes.Normal)
            {
                this.lbshead.Text += ",\r\n  A " + Localization.GetString(Sim.CharacterDescription.ServiceTypes.ToString());
            }
            else if (Sim.CharacterDescription.Career != SimPe.Data.MetaData.Careers.Unemployed)
                this.lbshead.Text += ",\r\n  Works in the " + (Data.LocalizedCareers)Sim.CharacterDescription.Career + " career";
            else if (Sim.CharacterDescription.Retired != SimPe.Data.MetaData.Careers.Unemployed && Sim.CharacterDescription.Realage > 19)
                this.lbshead.Text += ",\r\n  Retired from the " + (Data.LocalizedCareers)Sim.CharacterDescription.Retired + " career";
            else if (Sim.University.OnCampus == 0x1 && Sim.University.Major != SimPe.Data.Majors.Unset)
                this.lbshead.Text += ",\r\n  Studying " + (Data.Majors)Sim.University.Major;
            else if (Sim.CharacterDescription.Realage < 17 && Sim.CharacterDescription.SchoolType != SimPe.Data.MetaData.SchoolTypes.NoSchool)
            {
                if (Sim.CharacterDescription.Realage < 3)
                    this.lbshead.Text += ",\r\n  Will attend " + (Data.LocalizedSchoolType)Sim.CharacterDescription.SchoolType;
                else
                    this.lbshead.Text += ",\r\n  Attends " + (Data.LocalizedSchoolType)Sim.CharacterDescription.SchoolType;
                if (!this.lbshead.Text.EndsWith("School")) this.lbshead.Text += " School";
            }
            this.lbInform.Text = SimPe.PackedFiles.UserInterface.SimOriGuid.AboutSim(Sim);
        }
    }
}