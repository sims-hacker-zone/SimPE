/***************************************************************************
 *   Copyright (C) 2006 by Peter L Jones                                   *
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
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for TtabSingleMotive.
	/// </summary>
	public class TtabAnimalMotiveUI : UserControl
	{
		#region Form variables
		private TextBox tbValue;
		private Button btnPopup;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public TtabAnimalMotiveUI()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region TtabSingleMotiveUI
		private TtabItemAnimalMotiveItem item = null;

		public TtabItemAnimalMotiveItem Motive
		{
			get
			{
				return item;
			}
			set
			{
				if (this.item != value)
				{
					if (item != null)
					{
						item.Wrapper.WrapperChanged -= new EventHandler(
							this.WrapperChanged
						);
					}

					this.item = value;
					setText();
					if (item != null)
					{
						item.Wrapper.WrapperChanged += new EventHandler(
							this.WrapperChanged
						);
					}
				}
			}
		}

		private void WrapperChanged(object sender, EventArgs e)
		{
			if (sender != item)
			{
				return;
			}

			setText();
		}

		private void setText()
		{
			this.tbValue.Text =
				"0x"
				+ (
					(item.Count < 0x100) ? Helper.HexString((byte)item.Count)
					: (item.Count < 0x10000) ? Helper.HexString((ushort)item.Count)
					: Helper.HexString(item.Count)
				);
			for (int i = 0; i < item.Count; i++)
			{
				this.tbValue.Text +=
					"; "
					+ Helper.HexString(item[i].Min)
					+ " "
					+ Helper.HexString(item[i].Delta)
					+ " "
					+ Helper.HexString(item[i].Type);
			}
		}

		public void Clear()
		{
			TtabItemAnimalMotiveItem newItem = new TtabItemAnimalMotiveItem(
				item.Parent
			);
			newItem.CopyTo(item);
			setText();
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(TtabAnimalMotiveUI)
				);
			this.tbValue = new TextBox();
			this.btnPopup = new Button();
			this.SuspendLayout();
			//
			// tbValue
			//
			resources.ApplyResources(this.tbValue, "tbValue");
			this.tbValue.Name = "tbValue";
			this.tbValue.ReadOnly = true;
			//
			// btnPopup
			//
			this.btnPopup.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.btnPopup, "btnPopup");
			this.btnPopup.Name = "btnPopup";
			this.btnPopup.UseVisualStyleBackColor = false;
			this.btnPopup.Click += new EventHandler(this.btnPopup_Click);
			//
			// TtabAnimalMotiveUI
			//
			this.Controls.Add(this.btnPopup);
			this.Controls.Add(this.tbValue);
			this.Name = "TtabAnimalMotiveUI";
			resources.ApplyResources(this, "$this");
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		private void btnPopup_Click(object sender, EventArgs e)
		{
			pjse.TtabAnimalMotiveWiz amw = new pjse.TtabAnimalMotiveWiz();
			amw.MotiveSet = item;
			if (amw.ShowDialog() == DialogResult.OK)
			{
				amw.MotiveSet.CopyTo(item);
			}
			else
			{
				setText();
			}
		}
	}
}
