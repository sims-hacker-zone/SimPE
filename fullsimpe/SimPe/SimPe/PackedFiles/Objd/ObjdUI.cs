// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.UserInterface;

namespace SimPe.PackedFiles.Objd
{
	/// <summary>
	/// handles Packed SDSC Files
	/// </summary>
	public class ObjdUI : UIBase, IPackedFileUI
	{
		#region IPackedFileHandler Member

		public Control GUIHandle => form.objdPanel;

		public void UpdateGUI(IFileWrapper wrapper)
		{
			Objd objd = (Objd)wrapper;
			form.wrapper = objd;

			form.tbsimid.Text = "0x" + Helper.HexString(objd.SimId);
			form.tbsimname.Text = objd.FileName;
			form.tblottype.Text = "0x" + Helper.HexString(objd.Type);
			form.lbtypename.Text = ((Data.ObjectTypes)objd.Type).ToString().Trim();
			form.tborgguid.Text = "0x" + Helper.HexString(objd.OriginalGuid);
			form.tbproxguid.Text = "0x" + Helper.HexString(objd.ProxyGuid);

			Hashtable list = objd.Attributes;
			form.pnelements.Controls.Clear();

			int top = 4;
			ArrayList keys = new ArrayList();
			foreach (string k in list.Keys)
			{
				keys.Add(
					"0x"
						+ Helper.HexString((ushort)objd.GetAttributePosition(k))
						+ ": "
						+ k
				);
			}

			keys.Sort();

			foreach (string k in keys)
			{
				string[] s = k.Split(":".ToCharArray(), 2);
				Label lb = new Label
				{
					Parent = form.pnelements,
					AutoSize = true,
					Text = k + " = ",
					Top = top,
					Visible = true
				};

				TextBox tb = new TextBox
				{
					BorderStyle = BorderStyle.None,
					Parent = form.pnelements,
					Left = lb.Left + lb.Width
				};
				tb.Top = lb.Bottom - tb.Height;
				tb.Width = 50;
				tb.Text = "0x" + Helper.HexString(objd.GetAttributeShort(s[1].Trim()));
				tb.Tag = s[1].Trim();
				tb.Visible = true;
				tb.TextChanged += new EventHandler(HexTextChanged);

				TextBox tb2 = new TextBox
				{
					BorderStyle = BorderStyle.None,
					Parent = form.pnelements,
					Left = tb.Left + tb.Width + 4,
					Top = lb.Bottom - tb.Height,
					Width = 100,
					Text = ((short)objd.GetAttributeShort(s[1].Trim())).ToString(),
					Tag = null,
					Visible = true
				};
				tb2.TextChanged += new EventHandler(DecTextChanged);

				top += Math.Max(lb.Height, tb.Height) + 2;
			}
		}

		#endregion

		bool systentextupdate = false;

		/// <summary>
		/// Updates the Decimal View
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HexTextChanged(object sender, EventArgs e)
		{
			if (systentextupdate)
			{
				return;
			}

			systentextupdate = true;
			TextBox tb = (TextBox)sender;

			foreach (Control c in tb.Parent.Controls)
			{
				if (c.GetType() == typeof(TextBox))
				{
					TextBox tb2 = (TextBox)c;
					if (tb2.Top == tb.Top && tb2 != tb)
					{
						try
						{
							tb2.Text = Convert.ToInt16(tb.Text, 16).ToString();
						}
						catch (Exception) { }
						break;
					}
				}
			} //foreach
			systentextupdate = false;
		}

		/// <summary>
		/// Updates the Hex View
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DecTextChanged(object sender, EventArgs e)
		{
			if (systentextupdate)
			{
				return;
			}

			systentextupdate = true;
			TextBox tb = (TextBox)sender;

			foreach (Control c in tb.Parent.Controls)
			{
				if (c.GetType() == typeof(TextBox))
				{
					TextBox tb2 = (TextBox)c;
					if (tb2.Top == tb.Top && tb2 != tb)
					{
						try
						{
							tb2.Text =
								"0x"
								+ Helper.HexString((ushort)Convert.ToInt16(tb.Text));
						}
						catch (Exception) { }
						break;
					}
				}
			} //foreach
			systentextupdate = false;
		}
	}
}
