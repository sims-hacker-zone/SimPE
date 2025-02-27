/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
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
using System.Collections;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for TtabSingleMotive.
	/// </summary>
	public class TtabSingleMotiveUI : UserControl
	{
		#region Form variables
		private TextBox Min;
		private TextBox Delta;
		private TextBox Type;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public TtabSingleMotiveUI()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			TextBox[] tb = { Min, Delta, Type };
			alHex16 = new ArrayList(tb);
			Enabled = false;
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
		private TtabItemSingleMotiveItem item = null;

		private ArrayList alHex16;
		private bool internalchg;

		public TtabItemSingleMotiveItem Motive
		{
			get => item;
			set
			{
				if (item != value)
				{
					if (item != null && item.Wrapper != null)
					{
						item.Wrapper.WrapperChanged -= new EventHandler(
							WrapperChanged
						);
					}

					item = value;
					setText();
					if (item != null && item.Wrapper != null)
					{
						item.Wrapper.WrapperChanged += new EventHandler(
							WrapperChanged
						);
					}
				}
			}
		}

		private void WrapperChanged(object sender, EventArgs e)
		{
			if (internalchg || sender != item)
			{
				return;
			}

			setText();
		}

		private void setText()
		{
			bool prev = internalchg;
			internalchg = true;
			Min.Text = item == null ? "" : Helper.HexString(item.Min);
			Delta.Text = item == null ? "" : Helper.HexString(item.Delta);
			Type.Text = item == null ? "" : Helper.HexString(item.Type);
			internalchg = prev;
			Enabled = (item != null);
		}

		public void Clear()
		{
			bool prev = internalchg;
			internalchg = true;
			item.Min = item.Delta = item.Type = 0;
			setText();
			internalchg = prev;
		}

		private bool hex16_IsValid(object sender)
		{
			if (alHex16.IndexOf(sender) < 0)
			{
				throw new Exception(
					"hex16_IsValid not applicable to control " + sender.ToString()
				);
			}

			try
			{
				Convert.ToInt16(((TextBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
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
					typeof(TtabSingleMotiveUI)
				);
			Min = new TextBox();
			Delta = new TextBox();
			Type = new TextBox();
			SuspendLayout();
			//
			// Min
			//
			resources.ApplyResources(Min, "Min");
			Min.Name = "Min";
			Min.Validated += new EventHandler(hex16_Validated);
			Min.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			Min.TextChanged += new EventHandler(hex16_TextChanged);
			//
			// Delta
			//
			resources.ApplyResources(Delta, "Delta");
			Delta.Name = "Delta";
			Delta.Validated += new EventHandler(hex16_Validated);
			Delta.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			Delta.TextChanged += new EventHandler(hex16_TextChanged);
			//
			// Type
			//
			resources.ApplyResources(Type, "Type");
			Type.Name = "Type";
			Type.Validated += new EventHandler(hex16_Validated);
			Type.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			Type.TextChanged += new EventHandler(hex16_TextChanged);
			//
			// TtabSingleMotiveUI
			//
			Controls.Add(Min);
			Controls.Add(Delta);
			Controls.Add(Type);
			Name = "TtabSingleMotiveUI";
			resources.ApplyResources(this, "$this");
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		private void hex16_TextChanged(object sender, EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!hex16_IsValid(sender))
			{
				return;
			}

			internalchg = true;
			short val = Convert.ToInt16(((TextBox)sender).Text, 16);
			switch (alHex16.IndexOf(sender))
			{
				case 0:
					item.Min = val;
					break;
				case 1:
					item.Delta = val;
					break;
				case 2:
					item.Type = val;
					break;
			}
			internalchg = false;
		}

		private void hex16_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (hex16_IsValid(sender))
			{
				return;
			}

			e.Cancel = true;

			short val = 0;
			switch (alHex16.IndexOf(sender))
			{
				case 0:
					val = item.Min;
					break;
				case 1:
					val = item.Delta;
					break;
				case 2:
					val = item.Type;
					break;
			}
			internalchg = true;
			((TextBox)sender).Text = Helper.HexString(val);
			((TextBox)sender).SelectAll();
			internalchg = false;
		}

		private void hex16_Validated(object sender, EventArgs ev)
		{
			internalchg = true;
			short val = Convert.ToInt16(((TextBox)sender).Text, 16);
			((TextBox)sender).Text = Helper.HexString(val);
			((TextBox)sender).SelectAll();
			internalchg = false;
		}
	}
}
