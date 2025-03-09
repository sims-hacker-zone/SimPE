// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Ngbh;

namespace SimPe.Plugin
{
	public class NgbhItemsListViewItem : ListViewItem, System.IDisposable
	{
		NgbhItemsListView parent;

		public NgbhItem Item
		{
			get; private set;
		}

		public NgbhItemsListViewItem(NgbhItemsListView parent, NgbhItem item)
			: this(parent, item, true) { }

		public NgbhItemsListViewItem(
			NgbhItemsListView parent,
			NgbhItem item,
			bool autoadd
		)
			: base()
		{
			Item = item;
			this.parent = parent;
			//mci = NgbhUI.ObjectCache.FindItem(item.Guid);



			Update();
			if (autoadd)
			{
				parent.Items.Add(this);
			}
		}

		internal void Update()
		{
			Text = Item.ToString();
			if (!Item.Flags.IsVisible)
			{
				ForeColor = Color.SteelBlue;
			}

			if (Item.Flags.IsControler)
			{
				ForeColor = Color.Gray;
			}

			if (Item.IsInventory)
			{
				ForeColor = Color.MediumSeaGreen;
			}

			if (Item.IsGossip)
			{
				Font = new Font(
					Font.FontFamily,
					Font.Size,
					FontStyle.Italic,
					Font.Unit
				);
			}

			if (parent.SmallImageList != null)
			{
				Image i = Item.Icon;
				if (i != null)
				{
					if (ImageIndex >= 0)
					{
						parent.SmallImageList.Images[ImageIndex] = i;
					}
					else
					{
						parent.SmallImageList.Images.Add(i);
						ImageIndex = parent.SmallImageList.Images.Count - 1;
					}
				}
			}
		}

		#region IDisposable Member

		public void Dispose()
		{
			Item = null;
			parent = null;
		}

		#endregion
	}
}
