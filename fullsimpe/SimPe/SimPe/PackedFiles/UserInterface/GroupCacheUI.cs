// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// UI Handler for a Str Wrapper
	/// </summary>
	public class GroupCacheUI : IPackedFileUI
	{
		#region Code to Startup the UI

		/// <summary>
		/// Holds a reference to the Form containing the UI Panel
		/// </summary>
		static GroupCacheForm form;

		/// <summary>
		/// Constructor for the Class
		/// </summary>
		public GroupCacheUI()
		{
			if (form == null)
			{
				form = new GroupCacheForm();
			}
		}
		#endregion

		#region IPackedFileUI Member

		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle => form.GropPanel;

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <param name="wrapper">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrapper)
		{
			//form.wrapper = (IFileWrapperSaveExtension)wrapper;
			GroupCache wrp = (GroupCache)wrapper;

			form.lbgroup.BeginUpdate();
			form.lbgroup.Items.Clear();
			form.lbgroup.Sorted = false;
			foreach (GroupCacheItem i in wrp.Items)
			{
				form.lbgroup.Items.Add(i);
			}

			form.lbgroup.Sorted = true;
			form.lbgroup.EndUpdate();
		}

		#endregion



		#region IDisposable Member
		public virtual void Dispose()
		{
		}
		#endregion
	}
}
