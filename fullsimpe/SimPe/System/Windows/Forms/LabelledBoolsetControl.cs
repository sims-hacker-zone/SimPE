// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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

			boolset = 0xffff;
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
			get => btnAll.Visible && btnNone.Visible;
			set => btnAll.Visible = btnNone.Visible = value;
		}

		[Browsable(true)]
		[EditorBrowsable(0)]
		[Description("The unsigned short value representing the bit set to be edited")]
		public ushort Value
		{
			get => (ushort)boolset;
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
			get => labels;
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
