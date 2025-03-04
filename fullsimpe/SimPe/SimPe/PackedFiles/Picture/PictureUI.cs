// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Drawing;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.UserInterface;

namespace SimPe.PackedFiles.Picture
{
	/// <summary>
	/// handles Packed Jpeg Files
	/// </summary>
	public class PictureUI : UIBase, IPackedFileUI
	{
		#region IPackedFileUI Member
		public Control GUIHandle => form.JpegPanel;

		public void UpdateGUI(IFileWrapper wrapper)
		{
			form.picwrapper = wrapper;
			PictureBox pb = form.pb;
			Image img = ((Picture)wrapper).Image;
			pb.Image = img;
		}

		#endregion
	}
}
