// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces.Plugin;
using SimPe.Plugin;

namespace SimPe.PackedFiles.Lifo
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public class LifoUI : IPackedFileUI
	{
		#region Code to Startup the UI

		/// <summary>
		/// Holds a reference to the Form containing the UI Panel
		/// </summary>
		internal LifoForm form;

		/// <summary>
		/// Constructor for the Class
		/// </summary>
		public LifoUI()
		{
			form = new LifoForm();

			form.cbformats.Items.Add(ImageLoader.TxtrFormats.Unknown);
			form.cbformats.Items.Add(ImageLoader.TxtrFormats.DXT1Format);
			form.cbformats.Items.Add(ImageLoader.TxtrFormats.DXT3Format);
			form.cbformats.Items.Add(ImageLoader.TxtrFormats.DXT5Format);
			form.cbformats.Items.Add(ImageLoader.TxtrFormats.Raw8Bit);
			form.cbformats.Items.Add(ImageLoader.TxtrFormats.Raw24Bit);
			form.cbformats.Items.Add(ImageLoader.TxtrFormats.Raw32Bit);
		}
		#endregion

		#region IPackedFileUI Member

		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle => form.LifoPanel;

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <param name="wrapper">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrapper)
		{
			Lifo wrp = (Lifo)wrapper;
			form.wrapper = wrp;

			form.cbitem.Items.Clear();
			foreach (LevelInfo id in wrp.Blocks)
			{
				form.cbitem.Items.Add(id);
			}

			if (form.cbitem.Items.Count >= 0)
			{
				form.cbitem.SelectedIndex = 0;
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
