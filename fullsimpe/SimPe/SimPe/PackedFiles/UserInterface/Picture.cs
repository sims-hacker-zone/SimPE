// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Drawing;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// handles Packed Jpeg Files
	/// </summary>
	public class Picture : UIBase, IPackedFileUI
	{
		#region IPackedFileUI Member
		public Control GUIHandle => form.JpegPanel;

		public void UpdateGUI(IFileWrapper wrapper)
		{
			form.picwrapper = wrapper;
			PictureBox pb = form.pb;
			Image img = ((Wrapper.Picture)wrapper).Image;
			pb.Image = img;
		}

		#endregion
	}
}
