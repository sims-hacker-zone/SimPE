// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Linq;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.ThreeIdr
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public class ThreeIdrUI : IPackedFileUI
	{
		#region Code to Startup the UI

		/// <summary>
		/// Holds a reference to the Form containing the UI Panel
		/// </summary>
		internal ThreeIdrForm form;

		/// <summary>
		/// Constructor for the Class
		/// </summary>
		public ThreeIdrUI()
		{
			//form = WrapperFactory.form;
			form = new ThreeIdrForm();

			form.cbtypes.Items.AddRange((from FileTypes type in Enum.GetValues(typeof(FileTypes))
										 select type.ToFileTypeInformation()).Cast<object>().ToArray());
		}
		#endregion

		#region IPackedFileUI Member

		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle => form.wrapperPanel;

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <param name="wrapper">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrapper)
		{
			FileTableBase.FileIndex.Load();
			form.wrapper = (IFileWrapperSaveExtension)wrapper;

			ThreeIdr mywrapper = (ThreeIdr)wrapper;

			form.llcommit.Enabled = false;
			form.lldelete.Enabled = false;
			form.btup.Enabled = false;
			form.btdown.Enabled = false;
			form.miRem.Enabled = false;
			form.lblist.Items.Clear();
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in mywrapper.Items)
			{
				form.lblist.Items.Add(pfd);
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
