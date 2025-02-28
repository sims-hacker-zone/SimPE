// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
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
				{
					value.Add(item[i]);
				}

				return value;
			}
			set
			{
				if (value.Count > 16)
				{
					throw new ArgumentException(
						"Argument contains too many SingleMotiveItems",
						"value"
					);
				}

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
			get => nrItems;
			set
			{
				if (value < 0 || value > 16)
				{
					throw new ArgumentOutOfRangeException(
						"value",
						value,
						"must be between zero and sixteen"
					);
				}

				if (nrItems == value)
				{
					return;
				}

				nrItems = value;

				for (int i = 0; i < mUI.Length; i++)
				{
					mUI[i].Enabled = i < nrItems;
				}

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
