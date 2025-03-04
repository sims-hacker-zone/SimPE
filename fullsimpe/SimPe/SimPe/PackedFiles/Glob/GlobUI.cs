// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces.Plugin;
using SimPe.Plugin;

namespace SimPe.PackedFiles.Glob
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
			foreach (Data.SemiGlobalAlias sga in Data.MetaData.SemiGlobals)
			{
				if (!names.Contains(sga.Name.Trim().ToLower()))
				{
					if (sga.Known)
					{
						form.cbseminame.Items.Add(sga);
					}

					names.Add(sga.Name.Trim().ToLower());
				}
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
				"0x" + Helper.HexString(wrp.SemiGlobalGroup);
			form.lbBug.Visible = wrp.Faulty;
			form.lbBloat.Visible = wrp.Bloaty && !wrp.Faulty;
			for (int i = 0; i < form.cbseminame.Items.Count; i++)
			{
				Data.SemiGlobalAlias a =
					form.cbseminame.Items[i] as Data.SemiGlobalAlias;
				if (a.Name.ToLower() == form.cbseminame.Text.ToLower())
				{
					form.cbseminame.SelectedIndex = i;
					form.tbgroup.Text = "0x" + Helper.HexString(a.Id);
					form.tbgroup.ForeColor = a.Id == wrp.SemiGlobalGroup ? System.Drawing.SystemColors.WindowText : System.Drawing.Color.Red;

					break;
				}
			}
			form.cbseminame.Tag = null;
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
