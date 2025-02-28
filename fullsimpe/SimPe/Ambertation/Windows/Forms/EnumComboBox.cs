// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
				return o is EnumComboBoxItem item ? item.Content : o;
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
