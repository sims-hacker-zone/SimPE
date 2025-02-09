/***************************************************************************
 *   Copyright (C) 2007 Peter L Jones                                      *
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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SimPe.Plugin
{
    public partial class EffectPanel : UserControl
    {
        public EffectPanel()
        {
            InitializeComponent();
        }
        public void setValues(ushort maxLevel, ushort level, SimPe.PackedFiles.Wrapper.Bcon[] bcon, string male, string female)
        {
            IsPetCareer = (bcon[0] == null);
            IsCastaway = (bcon[9] != null);
            if (!isPetCareer)
            {
                lnudCooking.Value = bcon[0][level] / 100;
                lnudMechanical.Value = bcon[1][level] / 100;
                lnudBody.Value = bcon[2][level] / 100;
                lnudCharisma.Value = bcon[3][level] / 100;
                lnudCreativity.Value = bcon[4][level] / 100;
                lnudLogic.Value = bcon[5][level] / 100;
                lnudCleaning.Value = bcon[6][level] / 100;
            }
            lnudMoney.Value = bcon[7][level];
            lnudJobLevels.Minimum = level * -1;
            lnudJobLevels.Maximum = maxLevel - level;
            if (bcon[8][level] < lnudJobLevels.Minimum)
                lnudJobLevels.Value = lnudJobLevels.Minimum;
            else if (bcon[8][level] > lnudJobLevels.Maximum)
                lnudJobLevels.Value = lnudJobLevels.Maximum;
            else
                lnudJobLevels.Value = bcon[8][level];
            if (isCastaway)
                lnudFood.Value = bcon[9][level];
            tbMale.Text = male;
            tbFemale.Text = female;
        }
        public void getValues(SimPe.PackedFiles.Wrapper.Bcon[] bcon, ushort level, ref string male, ref string female)
        {
            IsPetCareer = (bcon[0] == null);
            IsCastaway = (bcon[9] != null);
            if (!isPetCareer)
            {
                bcon[0][level] = (short)(lnudCooking.Value * 100);
                bcon[1][level] = (short)(lnudMechanical.Value * 100);
                bcon[2][level] = (short)(lnudBody.Value * 100);
                bcon[3][level] = (short)(lnudCharisma.Value * 100);
                bcon[4][level] = (short)(lnudCreativity.Value * 100);
                bcon[5][level] = (short)(lnudLogic.Value * 100);
                bcon[6][level] = (short)(lnudCleaning.Value * 100);
            }
            bcon[7][level] = (short)lnudMoney.Value;
            bcon[8][level] = (short)lnudJobLevels.Value;
            if (isCastaway)
                bcon[9][level] = (short)lnudFood.Value; ;
            male = tbMale.Text;
            female = tbFemale.Text;
        }

        public decimal Cooking { get { return lnudCooking.Value; } set { lnudCooking.Value = value; } }
        public decimal Mechanical { get { return lnudMechanical.Value; } set { lnudMechanical.Value = value; } }
        public decimal Charisma { get { return lnudCharisma.Value; } set { lnudCharisma.Value = value; } }
        public decimal Body { get { return lnudBody.Value; } set { lnudBody.Value = value; } }
        public decimal Creativity { get { return lnudCreativity.Value; } set { lnudCreativity.Value = value; } }
        public decimal Logic { get { return lnudLogic.Value; } set { lnudLogic.Value = value; } }
        public decimal Cleaning { get { return lnudCleaning.Value; } set { lnudCleaning.Value = value; } }
        public decimal Money { get { return lnudMoney.Value; } set { lnudMoney.Value = value; } }
        public decimal JobLevels { get { return lnudJobLevels.Value; } set { lnudJobLevels.Value = value; } }
        public decimal Food { get { return lnudMoney.Value; } set { lnudMoney.Value = value; } }

        public string Male { get { return tbMale.Text; } set { tbMale.Text = value; } }
        public string Female { get { return tbFemale.Text; } set { tbFemale.Text = value; } }
        //public Size TextSize { get { return tbMale.Size; } set { tbFemale.Size = tbMale.Size = value; } }

        private bool isPetCareer = false;
        public bool IsPetCareer
        {
            get { return isPetCareer; }
            set
            {
                isPetCareer = value;
                lnudCooking.Visible = lnudMechanical.Visible = lnudCharisma.Visible = lnudBody.Visible =
                    lnudCreativity.Visible = lnudLogic.Visible = lnudCleaning.Visible = !isPetCareer;
            }
        }
        private bool isCastaway = false;
        public bool IsCastaway
        {
            get { return isCastaway; }
            set
            {
                isCastaway = value;
                lnudFood.Visible = isCastaway;
                if (isCastaway)
                    lnudMoney.Label = "Resource";
                else
                    lnudMoney.Label = "Money";
            }
        }

        private void llCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbMale.Text = tbFemale.Text;
        }
    }
}
