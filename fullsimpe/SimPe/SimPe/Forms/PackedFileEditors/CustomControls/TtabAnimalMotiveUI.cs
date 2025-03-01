// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace SimPe.Forms.PackedFileEditors.CustomControls
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
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		#region TtabSingleMotiveUI
		private TtabItemAnimalMotiveItem item = null;

		public TtabItemAnimalMotiveItem Motive
		{
			get => item;
			set
			{
				if (item != value)
				{
					if (item != null)
					{
						item.Wrapper.WrapperChanged -= new EventHandler(
							WrapperChanged
						);
					}

					item = value;
					setText();
					if (item != null)
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
			if (sender != item)
			{
				return;
			}

			setText();
		}

		private void setText()
		{
			tbValue.Text =
				"0x"
				+ (
					item.Count < 0x100 ? Helper.HexString((byte)item.Count)
					: item.Count < 0x10000 ? Helper.HexString((ushort)item.Count)
					: Helper.HexString(item.Count)
				);
			for (int i = 0; i < item.Count; i++)
			{
				tbValue.Text +=
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
			tbValue = new TextBox();
			btnPopup = new Button();
			SuspendLayout();
			//
			// tbValue
			//
			resources.ApplyResources(tbValue, "tbValue");
			tbValue.Name = "tbValue";
			tbValue.ReadOnly = true;
			//
			// btnPopup
			//
			btnPopup.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(btnPopup, "btnPopup");
			btnPopup.Name = "btnPopup";
			btnPopup.UseVisualStyleBackColor = false;
			btnPopup.Click += new EventHandler(btnPopup_Click);
			//
			// TtabAnimalMotiveUI
			//
			Controls.Add(btnPopup);
			Controls.Add(tbValue);
			Name = "TtabAnimalMotiveUI";
			resources.ApplyResources(this, "$this");
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		private void btnPopup_Click(object sender, EventArgs e)
		{
			pjse.TtabAnimalMotiveWiz amw = new pjse.TtabAnimalMotiveWiz
			{
				MotiveSet = item
			};
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
