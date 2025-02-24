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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pjOBJDTool
{
    public partial class cOBJDChooser : Form
    {
        private pfOBJD value = null;
        public pfOBJD Value { get { return value; } }
        List<pfOBJD> items = null;

        public cOBJDChooser()
        {
            InitializeComponent();
        }

        public DialogResult Execute(List<pfOBJD> items)
        {
            this.items = items;
            value = null;

            lbItems.Items.Clear();
            foreach (pfOBJD item in items)
            {
                lbItems.Items.Add((IsLead(item) ? "* " : "   ") + item.Filename);
                if (IsLead(item)) lbItems.SelectedIndex = lbItems.Items.Count - 1;
            }

            return ShowDialog();
        }

        bool IsLead(pfOBJD item)
        {
            return (item[0x0a] == 0 || (item[0x0a] > 0 && (short)item[0x0b] < 0));
        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbItems.SelectedIndex >= 0)
                value = items[lbItems.SelectedIndex];
        }

        private void lbItems_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}