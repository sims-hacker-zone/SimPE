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
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	public partial class LabelledNumericUpDown : UserControl
	{
		public LabelledNumericUpDown()
		{
			InitializeComponent();
			lbLabel.Visible = !noLabel;
		}

		public FlowDirection FlowDirection
		{
			get => flpMain.FlowDirection;
			set => flpMain.FlowDirection = value;
		}

		/// <summary>
		/// Hides the label
		/// </summary>
		private bool noLabel = false;
		public bool NoLabel
		{
			get => noLabel;
			set
			{
				if (noLabel != value)
				{
					noLabel = value;
					if (noLabel)
					{
						flpMain.Controls.Remove(lbLabel);
					}
					else
					{
						flpMain.Controls.Add(lbLabel);
						flpMain.Controls.SetChildIndex(lbLabel, 0);
					}
				}
			}
		}

		public string Label
		{
			get => lbLabel.Text;
			set => lbLabel.Text = value;
		}

		public AnchorStyles LabelAnchor
		{
			get => lbLabel.Anchor;
			set => lbLabel.Anchor = value;
		}

		public decimal Value
		{
			get => nudValue.Value;
			set => nudValue.Value = value;
		}

		public Size ValueSize
		{
			get => nudValue.Size;
			set => nudValue.Size = value;
		}

		public bool ReadOnly
		{
			get => nudValue.ReadOnly;
			set => nudValue.ReadOnly = value;
		}

		public decimal Maximum
		{
			get => nudValue.Maximum;
			set => nudValue.Maximum = value;
		}

		public decimal Minimum
		{
			get => nudValue.Minimum;
			set => nudValue.Minimum = value;
		}

		/// <summary>
		/// Raised when the Value changes
		/// </summary>
		public event EventHandler ValueChanged;
		public virtual void OnValueChanged(object sender, EventArgs e)
		{
			ValueChanged?.Invoke(sender, e);
		}
		private void nudValue_ValueChanged(object sender, EventArgs e)
		{
			OnValueChanged(this, e);
		}
	}
}
