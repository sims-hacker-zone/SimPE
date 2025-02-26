/***************************************************************************
 *   Copyright (C) 2006 by Peter L Jones                                   *
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SimPe.PackedFiles.UserInterface;
using SimPe.PackedFiles.Wrapper;

namespace pjse
{
	public partial class TtabAnimalMotiveWiz : Form
	{
		public TtabAnimalMotiveWiz()
		{
			InitializeComponent();

			TtabSingleMotiveUI[] m =
			{
				ttabSingleMotiveUI1,
				ttabSingleMotiveUI2,
				ttabSingleMotiveUI3,
				ttabSingleMotiveUI4,
				ttabSingleMotiveUI5,
				ttabSingleMotiveUI6,
				ttabSingleMotiveUI7,
				ttabSingleMotiveUI8,
				ttabSingleMotiveUI9,
				ttabSingleMotiveUI10,
				ttabSingleMotiveUI11,
				ttabSingleMotiveUI12,
				ttabSingleMotiveUI13,
				ttabSingleMotiveUI14,
				ttabSingleMotiveUI15,
				ttabSingleMotiveUI16,
			};
			mUI = m;

			item = new TtabItemAnimalMotiveItem(null);
			for (int i = 0; i < m.Length; i++)
			{
				item.Add(new TtabItemSingleMotiveItem(null));
				m[i].Motive = item[i];
			}
			nrItems = -1;
			Count = 0;
		}

		private TtabSingleMotiveUI[] mUI = null;

		private TtabItemAnimalMotiveItem item = null;
		public TtabItemAnimalMotiveItem MotiveSet
		{
			get
			{
				TtabItemAnimalMotiveItem value = new TtabItemAnimalMotiveItem(null);
				for (int i = 0; i < nrItems; i++)
					value.Add(item[i]);
				return value;
			}
			set
			{
				if (value.Count > 16)
					throw new ArgumentException(
						"Argument contains too many SingleMotiveItems",
						"value"
					);

				item.Clear();
				for (int i = 0; i < mUI.Length; i++)
				{
					item.Add(
						(i < value.Count)
							? value[i]
							: new TtabItemSingleMotiveItem(null)
					);
					mUI[i].Motive = item[i]; // as there's no wrapper, we need to refresh
				}
				nrItems = -1;
				Count = value.Count;
			}
		}

		private int nrItems = 0;
		public int Count
		{
			get
			{
				return nrItems;
			}
			set
			{
				if (value < 0 || value > 16)
					throw new ArgumentOutOfRangeException(
						"value",
						value,
						"must be between zero and sixteen"
					);
				if (nrItems == value)
					return;

				nrItems = value;

				for (int i = 0; i < mUI.Length; i++)
					mUI[i].Enabled = i < nrItems;
				btnMinus.Enabled = nrItems > 0;
				btnPlus.Enabled = nrItems < 16;
			}
		}

		private void btnPlus_Click(object sender, EventArgs e)
		{
			Count++;
		}

		private void btnMinus_Click(object sender, EventArgs e)
		{
			Count--;
		}
	}
}
