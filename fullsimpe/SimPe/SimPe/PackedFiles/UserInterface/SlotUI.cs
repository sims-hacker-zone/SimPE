// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Forms.PackedFileEditors;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// UI Handler for a Str Wrapper
	/// </summary>
	public class SlotUI : IPackedFileUI
	{
		#region Code to Startup the UI

		/// <summary>
		/// Holds a reference to the Form containing the UI Panel
		/// </summary>
		static SlotForm form;

		/// <summary>
		/// Constructor for the Class
		/// </summary>
		public SlotUI()
		{
			if (form == null)
			{
				form = new SlotForm();
			}

			SlotItemType[] vals = (SlotItemType[])
				System.Enum.GetValues(typeof(SlotItemType));
			foreach (SlotItemType v in vals)
			{
				form.cbtype.Items.Add(v);
			}
		}
		#endregion

		#region IPackedFileUI Member

		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle => form.pnslot;

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <param name="wrapper">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrapper)
		{
			Slot wrp = (Slot)wrapper;
			form.wrapper = wrp;
			form.Tag = true;
			int unyt = 10;

			form.tabControl1.Controls.Remove(form.tabPage1);
			form.tabControl1.Controls.Remove(form.tabPage2);
			form.tabControl1.Controls.Remove(form.tabPage3);
			form.tabControl1.Controls.Remove(form.tabPage4);
			form.tabControl1.Controls.Remove(form.tabPage5);
			form.tabControl1.Controls.Remove(form.tabPageA);
			form.tabControl1.Controls.Remove(form.tabPage6);
			form.tabControl1.Controls.Remove(form.tabPage7);

			if (wrp.Version >= 5)
			{
				form.tabControl1.Controls.Add(form.tabPage1);
			}

			if (wrp.Version >= 6)
			{
				form.tabControl1.Controls.Add(form.tabPage2);
			}

			if (wrp.Version >= 7)
			{
				form.tabControl1.Controls.Add(form.tabPage3);
			}

			if (wrp.Version >= 8)
			{
				form.tabControl1.Controls.Add(form.tabPage4);
			}

			if (wrp.Version >= 9)
			{
				form.tabControl1.Controls.Add(form.tabPage5);
			}

			if (wrp.Version == 10)
			{
				form.tabControl1.Controls.Add(form.tabPageA);
			}

			if (wrp.Version >= 0x10)
			{
				form.tabControl1.Controls.Add(form.tabPage6);
			}

			if (wrp.Version >= 0x40)
			{
				form.tabControl1.Controls.Add(form.tabPage7);
			}

			try
			{
				unyt = (form.lv.Width - 100) / 75;
				form.tbver.Text = "0x" + Helper.HexString(wrp.Version);
				form.tbname.Text = wrp.FileName;

				form.lv.BeginUpdate();
				form.lv.Items.Clear();
				form.lv.Columns.Clear();

				// x40 = 9
				// x30 = 9
				// x60 = 2 = 750 so width / 75 is units of ten
				// + 1 @ 100 = 850 so width / 85 is units of ten

				System.Windows.Forms.ColumnHeader c =
					new System.Windows.Forms.ColumnHeader
					{
						Text = "Type",
						Width = 100
					};
				form.lv.Columns.Add(c);
				c = new System.Windows.Forms.ColumnHeader
				{
					Text = "Float1",
					Width = unyt * 4
				};
				form.lv.Columns.Add(c);
				c = new System.Windows.Forms.ColumnHeader
				{
					Text = "Float2",
					Width = unyt * 4
				};
				form.lv.Columns.Add(c);
				c = new System.Windows.Forms.ColumnHeader
				{
					Text = "Float3",
					Width = unyt * 4
				};
				form.lv.Columns.Add(c);
				c = new System.Windows.Forms.ColumnHeader
				{
					Text = "Int1",
					Width = unyt * 3
				};
				form.lv.Columns.Add(c);
				c = new System.Windows.Forms.ColumnHeader
				{
					Text = "Int2",
					Width = unyt * 3
				};
				form.lv.Columns.Add(c);
				c = new System.Windows.Forms.ColumnHeader
				{
					Text = "Int3",
					Width = unyt * 3
				};
				form.lv.Columns.Add(c);
				c = new System.Windows.Forms.ColumnHeader
				{
					Text = "Int4",
					Width = unyt * 4
				};
				form.lv.Columns.Add(c);
				c = new System.Windows.Forms.ColumnHeader
				{
					Text = "Int5",
					Width = unyt * 3
				};
				form.lv.Columns.Add(c);
				if (wrp.Version >= 5)
				{
					c = new System.Windows.Forms.ColumnHeader
					{
						Text = "Float4",
						Width = unyt * 4
					};
					form.lv.Columns.Add(c);
					c = new System.Windows.Forms.ColumnHeader
					{
						Text = "Float5",
						Width = unyt * 4
					};
					form.lv.Columns.Add(c);
					c = new System.Windows.Forms.ColumnHeader
					{
						Text = "Float6",
						Width = unyt * 4
					};
					form.lv.Columns.Add(c);
					c = new System.Windows.Forms.ColumnHeader
					{
						Text = "Int6",
						Width = unyt * 3
					};
					form.lv.Columns.Add(c);
				}
				if (wrp.Version >= 6)
				{
					c = new System.Windows.Forms.ColumnHeader
					{
						Text = "Shrt1",
						Width = unyt * 3
					};
					form.lv.Columns.Add(c);
					c = new System.Windows.Forms.ColumnHeader
					{
						Text = "Shrt2",
						Width = unyt * 3
					};
					form.lv.Columns.Add(c);
				}
				if (wrp.Version >= 7)
				{
					c = new System.Windows.Forms.ColumnHeader
					{
						Text = "Float7",
						Width = unyt * 6
					};
					form.lv.Columns.Add(c);
				}
				if (wrp.Version >= 8)
				{
					c = new System.Windows.Forms.ColumnHeader
					{
						Text = "Int7",
						Width = unyt * 3
					};
					form.lv.Columns.Add(c);
				}
				if (wrp.Version >= 9)
				{
					c = new System.Windows.Forms.ColumnHeader
					{
						Text = "Int8",
						Width = unyt * 4
					};
					form.lv.Columns.Add(c);
				}
				if (wrp.Version == 10)
				{
					c = new System.Windows.Forms.ColumnHeader
					{
						Text = "Shrt3",
						Width = unyt * 3
					};
					form.lv.Columns.Add(c);
				}
				if (wrp.Version >= 0x10)
				{
					c = new System.Windows.Forms.ColumnHeader
					{
						Text = "Float8",
						Width = unyt * 6
					};
					form.lv.Columns.Add(c);
				}
				if (wrp.Version >= 0x40)
				{
					c = new System.Windows.Forms.ColumnHeader
					{
						Text = "Int9",
						Width = unyt * 3
					};
					form.lv.Columns.Add(c);
					c = new System.Windows.Forms.ColumnHeader
					{
						Text = "Int10",
						Width = unyt * 4
					};
					form.lv.Columns.Add(c);
				}

				foreach (SlotItem i in wrp.Items)
				{
					form.ShowItem(i);
				}

				form.lv.EndUpdate();
			}
			finally
			{
				form.Tag = null;
			}
		}

		#endregion

		#region IDisposable Member
		public virtual void Dispose()
		{
		}
		#endregion
	}
}
