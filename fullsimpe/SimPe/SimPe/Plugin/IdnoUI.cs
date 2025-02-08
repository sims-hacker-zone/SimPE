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
using SimPe.Interfaces.Plugin;
using System.Windows.Forms;

namespace SimPe.Plugin
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

			NeighborhoodType[] vals = (NeighborhoodType[])System.Enum.GetValues(typeof(NeighborhoodType));
            foreach (NeighborhoodType v in vals) form.cbtype.Items.Add(v);
            form.cbreqtp.Items.Clear();
            form.cbsubtp.Items.Clear();
            foreach (uint i in Enum.GetValues(typeof(Data.MetaData.NeighbourhoodEP)))
            {
                form.cbreqtp.Items.Add(new Data.LocalizedNeighbourhoodEP((Data.MetaData.NeighbourhoodEP)i));
                form.cbsubtp.Items.Add(new Data.LocalizedNeighbourhoodEP((Data.MetaData.NeighbourhoodEP)i));
            }

            NhSeasons[] valf = (NhSeasons[])System.Enum.GetValues(typeof(NhSeasons));
            foreach (NhSeasons v in valf) form.cbquada.Items.Add(v);

            NhSeasons[] valu = (NhSeasons[])System.Enum.GetValues(typeof(NhSeasons));
            foreach (NhSeasons v in valu) form.cbquadb.Items.Add(v);

            NhSeasons[] valc = (NhSeasons[])System.Enum.GetValues(typeof(NhSeasons));
            foreach (NhSeasons v in valc) form.cbquadc.Items.Add(v);

            NhSeasons[] valk = (NhSeasons[])System.Enum.GetValues(typeof(NhSeasons));
            foreach (NhSeasons v in valk) form.cbquadd.Items.Add(v);
		}
		#endregion

		#region IPackedFileUI Member

		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle
		{
			get
			{
				return form.pnidno;
			}
		}

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <param name="wrapper">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrapper)
		{
			Idno wrp = (Idno) wrapper;
			form.wrapper = null;
			form.Tag=true;

			try 
			{
				form.cbtype.SelectedIndex = 0;
				for(int i=0; i<form.cbtype.Items.Count; i++)
				{
					NeighborhoodType lt = (NeighborhoodType)form.cbtype.Items[i];
					if (lt==wrp.Type) 
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
                    Data.MetaData.NeighbourhoodEP le;
                    le = (Data.LocalizedNeighbourhoodEP)o;
                    // NeighbourhoodEP le = (NeighbourhoodEP)form.cbreqtp.Items[i];
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
                    Data.MetaData.NeighbourhoodEP ls;
                    ls = (Data.LocalizedNeighbourhoodEP)o;
                    // NeighbourhoodEP ls = (NeighbourhoodEP)form.cbsubtp.Items[i];
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
                    NhSeasons fa = (NhSeasons)form.cbquada.Items[i];
                    if (fa == wrp.Quada)
                    {
                        form.cbquada.SelectedIndex = i;
                        break;
                    }
                }
                form.cbquadb.SelectedIndex = 0;
                for (int i = 0; i < form.cbquadb.Items.Count; i++)
                {
                    NhSeasons fb = (NhSeasons)form.cbquadb.Items[i];
                    if (fb == wrp.Quadb)
                    {
                        form.cbquadb.SelectedIndex = i;
                        break;
                    }
                }
                form.cbquadc.SelectedIndex = 0;
                for (int i = 0; i < form.cbquadc.Items.Count; i++)
                {
                    NhSeasons fc = (NhSeasons)form.cbquadc.Items[i];
                    if (fc == wrp.Quadc)
                    {
                        form.cbquadc.SelectedIndex = i;
                        break;
                    }
                }
                form.cbquadd.SelectedIndex = 0;
                for (int i = 0; i < form.cbquadd.Items.Count; i++)
                {
                    NhSeasons fd = (NhSeasons)form.cbquadd.Items[i];
                    if (fd == wrp.Quadd)
                    {
                        form.cbquadd.SelectedIndex = i;
                        break;
                    }
                }

				form.tbversion.Text = "0x"+Helper.HexString((uint)wrp.Version);
				form.lbVer.Text = wrp.Version.ToString().Replace("_", " ");

				form.tbid.Text = wrp.Uid.ToString();
				form.tbname.Text = wrp.OwnerName;
                form.tbsubname.Text = wrp.SubName;
                form.tbidflags.Text = "0x" + Helper.HexString((uint)wrp.Idflags);
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
                if (wrp.Version < NeighborhoodVersion.Sims2_Seasons || Helper.StartedGui == Executable.Classic)
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
			this.form.Dispose();
		}
		#endregion
	}
}
