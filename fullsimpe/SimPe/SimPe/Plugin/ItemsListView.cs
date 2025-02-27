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
using System;
using System.Drawing;
using System.Windows.Forms;

using SimPe;
using SimPe.Cache;

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
			this.Item = item;
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
			this.Text = Item.ToString();
			if (!Item.Flags.IsVisible)
			{
				this.ForeColor = Color.SteelBlue;
			}

			if (Item.Flags.IsControler)
			{
				this.ForeColor = Color.Gray;
			}

			if (Item.IsInventory)
			{
				this.ForeColor = Color.MediumSeaGreen;
			}

			if (Item.IsGossip)
			{
				this.Font = new Font(
					this.Font.FontFamily,
					this.Font.Size,
					FontStyle.Italic,
					this.Font.Unit
				);
			}

			if (parent.SmallImageList != null)
			{
				Image i = Item.Icon;
				if (i != null)
				{
					if (this.ImageIndex >= 0)
					{
						parent.SmallImageList.Images[this.ImageIndex] = i;
					}
					else
					{
						parent.SmallImageList.Images.Add(i);
						this.ImageIndex = parent.SmallImageList.Images.Count - 1;
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
