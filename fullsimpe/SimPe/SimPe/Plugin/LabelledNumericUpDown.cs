// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
