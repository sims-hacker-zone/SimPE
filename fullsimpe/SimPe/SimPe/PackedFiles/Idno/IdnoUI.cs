// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Idno
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public class IdnoUI : IPackedFileUI
	{
		#region Code to Startup the UI

		/// <summary>
		/// Holds a reference to the Form containing the UI Panel
		/// </summary>
		internal IdnoForm form;

		/// <summary>
		/// Constructor for the Class
		/// </summary>
		public IdnoUI()
		{
			//form = WrapperFactory.form;
			form = new IdnoForm();

			NeighborhoodType[] vals = (NeighborhoodType[])
				Enum.GetValues(typeof(NeighborhoodType));
			foreach (NeighborhoodType v in vals)
			{
				form.cbtype.Items.Add(v);
			}

			form.cbreqtp.Items.Clear();
			form.cbsubtp.Items.Clear();
			foreach (uint i in Enum.GetValues(typeof(NeighborhoodEP)))
			{
				form.cbreqtp.Items.Add(
					new LocalizedNeighborhoodEP((NeighborhoodEP)i)
				);
				form.cbsubtp.Items.Add(
					new LocalizedNeighborhoodEP((NeighborhoodEP)i)
				);
			}

			NeighborhoodSeason[] valf = (NeighborhoodSeason[])Enum.GetValues(typeof(NeighborhoodSeason));
			foreach (NeighborhoodSeason v in valf)
			{
				form.cbquada.Items.Add(v);
			}

			NeighborhoodSeason[] valu = (NeighborhoodSeason[])Enum.GetValues(typeof(NeighborhoodSeason));
			foreach (NeighborhoodSeason v in valu)
			{
				form.cbquadb.Items.Add(v);
			}

			NeighborhoodSeason[] valc = (NeighborhoodSeason[])Enum.GetValues(typeof(NeighborhoodSeason));
			foreach (NeighborhoodSeason v in valc)
			{
				form.cbquadc.Items.Add(v);
			}

			NeighborhoodSeason[] valk = (NeighborhoodSeason[])Enum.GetValues(typeof(NeighborhoodSeason));
			foreach (NeighborhoodSeason v in valk)
			{
				form.cbquadd.Items.Add(v);
			}
		}
		#endregion

		#region IPackedFileUI Member

		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle => form.pnidno;

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <param name="wrapper">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrapper)
		{
			Idno wrp = (Idno)wrapper;
			form.wrapper = null;
			form.Tag = true;

			try
			{
				form.cbtype.SelectedIndex = 0;
				for (int i = 0; i < form.cbtype.Items.Count; i++)
				{
					NeighborhoodType lt = (NeighborhoodType)form.cbtype.Items[i];
					if (lt == wrp.Type)
					{
						form.cbtype.SelectedIndex = i;
						break;
					}
				}
				form.tbtype.Text = "0x" + Helper.HexString((byte)wrp.Type);

				form.cbreqtp.SelectedIndex = 0;
				for (int i = 0; i < form.cbreqtp.Items.Count; i++)
				{
					object o = form.cbreqtp.Items[i];
					NeighborhoodEP le;
					le = (LocalizedNeighborhoodEP)o;
					// NeighborhoodEP le = (NeighborhoodEP)form.cbreqtp.Items[i];
					if (le == wrp.Reqep)
					{
						form.cbreqtp.SelectedIndex = i;
						break;
					}
				}
				form.tbreqep.Text = "0x" + Helper.HexString((byte)wrp.Reqep);

				form.cbsubtp.SelectedIndex = 0;
				for (int i = 0; i < form.cbsubtp.Items.Count; i++)
				{
					object o = form.cbsubtp.Items[i];
					NeighborhoodEP ls;
					ls = (LocalizedNeighborhoodEP)o;
					// NeighborhoodEP ls = (NeighborhoodEP)form.cbsubtp.Items[i];
					if (ls == wrp.Subep)
					{
						form.cbsubtp.SelectedIndex = i;
						break;
					}
				}
				form.tbsubep.Text = "0x" + Helper.HexString((byte)wrp.Subep);

				form.cbquada.SelectedIndex = 0;
				for (int i = 0; i < form.cbquada.Items.Count; i++)
				{
					NeighborhoodSeason fa = (NeighborhoodSeason)form.cbquada.Items[i];
					if (fa == wrp.Quada)
					{
						form.cbquada.SelectedIndex = i;
						break;
					}
				}
				form.cbquadb.SelectedIndex = 0;
				for (int i = 0; i < form.cbquadb.Items.Count; i++)
				{
					NeighborhoodSeason fb = (NeighborhoodSeason)form.cbquadb.Items[i];
					if (fb == wrp.Quadb)
					{
						form.cbquadb.SelectedIndex = i;
						break;
					}
				}
				form.cbquadc.SelectedIndex = 0;
				for (int i = 0; i < form.cbquadc.Items.Count; i++)
				{
					NeighborhoodSeason fc = (NeighborhoodSeason)form.cbquadc.Items[i];
					if (fc == wrp.Quadc)
					{
						form.cbquadc.SelectedIndex = i;
						break;
					}
				}
				form.cbquadd.SelectedIndex = 0;
				for (int i = 0; i < form.cbquadd.Items.Count; i++)
				{
					NeighborhoodSeason fd = (NeighborhoodSeason)form.cbquadd.Items[i];
					if (fd == wrp.Quadd)
					{
						form.cbquadd.SelectedIndex = i;
						break;
					}
				}

				form.tbversion.Text = "0x" + Helper.HexString((uint)wrp.Version);
				form.lbVer.Text = wrp.Version.ToString().Replace("_", " ");

				form.tbid.Text = wrp.Uid.ToString();
				form.tbname.Text = wrp.OwnerName;
				form.tbsubname.Text = wrp.SubName;
				form.tbidflags.Text = "0x" + Helper.HexString(wrp.Idflags);
				if (wrp.Subtype == 0)
				{
					form.tbsubname.Visible = false;
					form.label4.Visible = false;
				}
				else
				{
					form.tbsubname.Visible = true;
					form.label4.Visible = true;
				}
				if (
					wrp.Version < NeighborhoodVersion.Sims2_Seasons
					|| Helper.StartedGui == Executable.Classic
				)
				{
					form.cbsubtp.Visible = false;
					form.tbsubep.Visible = false;
					form.cbreqtp.Visible = false;
					form.tbreqep.Visible = false;
					form.label7.Visible = false;
					form.label6.Visible = false;
					form.label9.Visible = false;
					form.label8.Visible = false;
					form.tbidflags.Visible = false;
					form.cbquada.Visible = false;
					form.cbquadb.Visible = false;
					form.cbquadc.Visible = false;
					form.cbquadd.Visible = false;
				}
				else
				{
					form.cbsubtp.Visible = true;
					form.tbsubep.Visible = true;
					form.cbreqtp.Visible = true;
					form.tbreqep.Visible = true;
					form.label7.Visible = true;
					form.label6.Visible = true;
					form.label9.Visible = true;
					form.label8.Visible = true;
					form.tbidflags.Visible = true;
					form.cbquada.Visible = true;
					form.cbquadb.Visible = true;
					form.cbquadc.Visible = true;
					form.cbquadd.Visible = true;
				}

				form.wrapper = wrp;
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
			form.Dispose();
		}
		#endregion
	}
}
