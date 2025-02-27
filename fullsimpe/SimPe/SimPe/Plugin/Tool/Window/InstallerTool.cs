using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin.Tool.Window
{
	/// <summary>
	/// Tool that should automatically repair corrupted packages
	/// </summary>
	public class InstallerTool : SimPe.Interfaces.IToolPlus
	{
		public InstallerTool()
		{
		}

		#region IToolPlus Member

		public void Execute(object sender, SimPe.Events.ResourceEventArgs e)
		{
			InstallerForm f = new InstallerForm();
			f.ShowDialog();
		}

		public bool ChangeEnabledStateEventHandler(
			object sender,
			SimPe.Events.ResourceEventArgs e
		)
		{
			return true;
		}

		#endregion

		#region IToolExt Member

		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.CtrlShiftI;

		public bool Visible => true;

		public Image Icon => SimPe.GetIcon.ContentPreview;

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return "Content Preview...";
		}

		#endregion
	}
}
