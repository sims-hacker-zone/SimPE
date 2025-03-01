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
	public class NrefUI : IPackedFileUI
	{
		#region Code to Startup the UI

		/// <summary>
		/// Holds a reference to the Form containing the UI Panel
		/// </summary>
		private Elements2 form;

		/// <summary>
		/// Constructor for the Class
		/// </summary>
		public NrefUI()
		{
			form = new Elements2();
		}
		#endregion

		#region IPackedFileUI Member

		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle => form.NrefPanel;

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <param name="wrapper">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrapper)
		{
			form.wrapper = (IFileWrapperSaveExtension)wrapper;
			Nref wrp = (Nref)wrapper;

			form.tbNref.Tag = true;
			form.tbNref.Text = wrp.FileName;
			form.tbNref.Tag = null;
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
