// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Cpf
{
	/// <summary>
	/// UI Handler for a Str Wrapper
	/// </summary>
	public class CpfUI : IPackedFileUI
	{
		public delegate void ExecutePreview(
			Cpf mmat,
			Interfaces.Files.IPackageFile package
		);

		#region Code to Startup the UI

		/// <summary>
		/// Holds a reference to the Form containing the UI Panel
		/// </summary>
		private CpfForm form;
		ExecutePreview fkt;

		/// <summary>
		/// Constructor for the Class
		/// </summary>
		public CpfUI(ExecutePreview fkt)
		{
			form = new CpfForm();
			form.cbtype.Items.AddRange((object[])Enum.GetValues(typeof(Data.DataTypes)));

			form.cbtype.SelectedIndex = 0;

			this.fkt = fkt;
		}
		#endregion

		#region IPackedFileUI Member

		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle => form.CpfPanel;

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <param name="wrapper">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrapper)
		{
			form.wrapper = (IFileWrapperSaveExtension)wrapper;
			Cpf wrp = (Cpf)wrapper;

			form.lbcpf.Items.Clear();
			foreach (CpfItem item in wrp.Items)
			{
				form.lbcpf.Items.Add(item);
			}

			form.llcpfchange.Enabled = false;
			form.btprev.Visible = fkt != null;

			form.fkt = fkt;
		}

		#endregion

		#region IDisposable Member
		public virtual void Dispose()
		{
			form.Dispose();
			fkt = null;
		}
		#endregion
	}
}
