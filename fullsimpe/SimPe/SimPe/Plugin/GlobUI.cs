/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *   Copyright (C) 2008 by Peter L Jones                                   *
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

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this File Type with Data
	/// </summary>
	public class GlobUI : IPackedFileUI
	{
		#region Code to Startup the UI

		/// <summary>
		/// Holds a reference to the Form containing the UI Panel
		/// </summary>
		private GlobCtrl form;

		/// <summary>
		/// Constructor for the Class
		/// </summary>
		public GlobUI()
		{
			form = new GlobCtrl();
			form.cbseminame.Items.Clear();

			System.Collections.ArrayList names = new System.Collections.ArrayList();
			foreach (SimPe.Data.SemiGlobalAlias sga in SimPe.Data.MetaData.SemiGlobals)
				if (!names.Contains(sga.Name.Trim().ToLower()))
				{
					if (sga.Known)
						form.cbseminame.Items.Add(sga);
					names.Add(sga.Name.Trim().ToLower());
				}
		}
		#endregion

		#region IPackedFileUI Member

		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle => form;

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should update the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <param name="wrapper">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrapper)
		{
			form.wrapper = (IFileWrapperSaveExtension)wrapper;
			Glob wrp = (Glob)wrapper;
			form.cbseminame.Tag = true;
			form.lbglobfile.Text = wrp.FileName;
			form.tbfilenm.Text = wrp.FileName;
			form.cbseminame.Text = wrp.SemiGlobalName;
			form.tbgroup.ForeColor = System.Drawing.Color.BlueViolet;
			form.tbgroup.Text =
				"0x" + Helper.HexString(Hashes.GroupHash(wrp.SemiGlobalName));
			form.lbBug.Visible = wrp.faulty;
			form.lbBloat.Visible = (wrp.bloaty && !wrp.faulty);
			for (int i = 0; i < form.cbseminame.Items.Count; i++)
			{
				Data.SemiGlobalAlias a =
					form.cbseminame.Items[i] as Data.SemiGlobalAlias;
				if (a.Name.ToLower() == form.cbseminame.Text.ToLower())
				{
					form.cbseminame.SelectedIndex = i;
					form.tbgroup.Text = "0x" + Helper.HexString(a.Id);
					if (a.Id == Hashes.GroupHash(wrp.SemiGlobalName))
						form.tbgroup.ForeColor = System.Drawing.SystemColors.WindowText;
					else
						form.tbgroup.ForeColor = System.Drawing.Color.Red;
					break;
				}
			}
			form.cbseminame.Tag = null;
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
