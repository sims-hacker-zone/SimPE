// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// handles Packed XmlFiles
	/// </summary>
	public class ExtFamilyTies : IPackedFileUI
	{
		FamilyTiesForm form;

		public ExtFamilyTies()
		{
			form = new FamilyTiesForm();
		}

		#region IPackedFileHandler Member

		public Control GUIHandle => form.pnfamt;

		public void UpdateGUI(IFileWrapper wrapper)
		{
			Wrapper.ExtFamilyTies famt = (Wrapper.ExtFamilyTies)wrapper;
			form.wrapper = famt;

			form.cbLock.Checked = false;
			form.pool.SelectedElement = null;
			form.pool.Package = null;
			form.pool_SelectedSimChanged(null, null, null);
			form.pool.Package = wrapper.Package;
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
