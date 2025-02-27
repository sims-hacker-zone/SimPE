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
using System.Collections.Generic;
using System.ComponentModel;

namespace System.Windows.Forms
{
	public partial class LabelledBoolsetControl : UserControl
	{
		private Boolset boolset = (ushort)0;
		private List<string> labels = new List<string>();

		public LabelledBoolsetControl()
		{
			InitializeComponent();
		}

		private void btnAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < cklbBoolset.Items.Count; i++)
			{
				cklbBoolset.SetSelected(i, true);
			}

			boolset = (ushort)0xffff;
		}

		private void btnNone_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < cklbBoolset.Items.Count; i++)
			{
				cklbBoolset.SetSelected(i, false);
			}

			boolset = (ushort)0;
		}

		[Browsable(true)]
		[EditorBrowsable(0)]
		[Description("Show or Hide the All/None buttons")]
		public bool ButtonsVisible
		{
			get
			{
				return btnAll.Visible && btnNone.Visible;
			}
			set
			{
				btnAll.Visible = btnNone.Visible = value;
			}
		}

		[Browsable(true)]
		[EditorBrowsable(0)]
		[Description("The unsigned short value representing the bit set to be edited")]
		public ushort Value
		{
			get
			{
				return (ushort)boolset;
			}
			set
			{
				ushort oldvalue = boolset;
				boolset = value;
				while (labels.Count < boolset.Length)
				{
					labels.Add(labels.Count.ToString());
				}

				cklbBoolset.Items.Clear();
				cklbBoolset.Items.AddRange(labels.ToArray());
				for (int i = 0; i < boolset.Length; i++)
				{
					cklbBoolset.SetItemChecked(i, boolset[i]);
				}

				if (oldvalue != boolset)
				{
					OnValueChanged(this, new EventArgs());
				}
			}
		}

		/// <summary>
		/// Indicates the Value changed
		/// </summary>
		[Description("Indicates the Value changed")]
		public event EventHandler ValueChanged;

		public virtual void OnValueChanged(object sender, EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(sender, e);
			}
		}

		[Browsable(true)]
		[EditorBrowsable(0)]
		[Description("The collection representing the labels for the bits")]
		public List<string> Labels
		{
			get
			{
				return labels;
			}
			set
			{
				labels = value;
				while (labels.Count < boolset.Length)
				{
					labels.Add(labels.Count.ToString());
				}

				cklbBoolset.Items.Clear();
				cklbBoolset.Items.AddRange(labels.ToArray());
				for (int i = 0; i < boolset.Length; i++)
				{
					cklbBoolset.SetItemChecked(i, boolset[i]);
				}
			}
		}

		private void cklbBoolset_SelectedIndexChanged(object sender, EventArgs e)
		{
			ushort oldvalue = boolset;
			if (cklbBoolset.SelectedIndex >= 0)
			{
				boolset[cklbBoolset.SelectedIndex] = cklbBoolset.GetItemChecked(
					cklbBoolset.SelectedIndex
				);
			}

			if (oldvalue != boolset)
			{
				OnValueChanged(this, new EventArgs());
			}
		}
	}
}
