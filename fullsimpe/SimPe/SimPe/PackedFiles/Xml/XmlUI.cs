// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.UserInterface;

namespace SimPe.PackedFiles.Xml
{
	/// <summary>
	/// handles Packed XmlFiles
	/// </summary>
	public class XmlUI : UIBase, IPackedFileUI
	{
		#region IPackedFileHandler Member

		public Control GUIHandle => form.xmlPanel;

		public void UpdateGUI(IFileWrapper wrapper)
		{
			Xml xml = (Xml)wrapper;
			form.wrapper = xml;
			form.rtb.Text = xml.Text;
		}

		#endregion
	}
}
