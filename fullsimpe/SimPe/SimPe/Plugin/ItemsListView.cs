/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
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
using System.Drawing;
using System.Windows.Forms;

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
