// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// handles Packed XmlFiles
	/// </summary>
	public class Xml : UIBase, IPackedFileUI
	{
		#region IPackedFileHandler Member

		public Control GUIHandle => form.xmlPanel;

		public void UpdateGUI(IFileWrapper wrapper)
		{
			Wrapper.Xml xml = (Wrapper.Xml)wrapper;
			form.wrapper = xml;
			form.rtb.Text = xml.Text;
		}

		#endregion
	}
}
