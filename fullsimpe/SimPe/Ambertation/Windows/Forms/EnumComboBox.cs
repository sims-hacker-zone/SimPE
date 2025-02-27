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

namespace Ambertation.Windows.Forms
{
	internal class EnumComboBoxItem
	{
		public object Content
		{
			get;
		}

		public string Name
		{
			get;
		}

		internal EnumComboBoxItem(
			Type type,
			object obj,
			System.Resources.ResourceManager rm
		)
		{
			Name = obj.ToString();
			if (rm != null)
			{
				string nname = rm.GetString(
					type.Namespace + "." + type.Name + "." + obj.ToString()
				);
				if (nname != null)
				{
					Name = nname;
				}
			}
			Content = obj;
		}

		public override string ToString()
		{
			return Name;
		}
	}

	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	[ToolboxBitmap(typeof(ComboBox))]
	public class EnumComboBox : ComboBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EnumComboBox()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		#region public Properties
		Type myenum;
		public Type Enum
		{
			get => myenum;
			set
			{
				if (value != myenum)
				{
					myenum = value;
					UpdateContent(false);
				}
			}
		}

		System.Resources.ResourceManager rm;
		public System.Resources.ResourceManager ResourceManager
		{
			get => rm;
			set
			{
				if (value != rm)
				{
					rm = value;
					UpdateContent(true);
				}
			}
		}

		public new object SelectedValue
		{
			get
			{
				if (SelectedIndex < 0)
				{
					return null;
				}

				object o = Items[SelectedIndex];
				if (o is EnumComboBoxItem)
				{
					return ((EnumComboBoxItem)o).Content;
				}

				return o;
			}
			set
			{
				if (value == null)
				{
					SelectedIndex = -1;
				}
				else
				{
					Type vtype = value.GetType();
					int sel = -1;
					if (vtype.IsEnum)
					{
						for (int i = 0; i < Items.Count; i++)
						{
							object o = Items[i];
							if (o is EnumComboBoxItem)
							{
								o = ((EnumComboBoxItem)o).Content;
							}

							if (((Enum)o).CompareTo(value) == 0)
							{
								sel = i;
								break;
							}
						}
					}
					SelectedIndex = sel;
				}
			}
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			//
			// EnumComboBox
			//
			Name = "EnumComboBox";
		}
		#endregion

		public void UpdateContent(bool keepselection)
		{
			Items.Clear();
			int last = SelectedIndex;
			if (myenum != null)
			{
				Array ls = System.Enum.GetValues(myenum);

				foreach (object o in ls)
				{
					Items.Add(new EnumComboBoxItem(myenum, o, rm));
				}
			}

			if (keepselection)
			{
				SelectedIndex = last < Items.Count ? last : Items.Count - 1;
			}
		}
	}
}
