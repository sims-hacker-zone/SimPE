// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin.Tool.Action
{
	/// <summary>
	/// The ReloadFileTable Action
	/// </summary>
	public class ActionReloadFiletable : Interfaces.IToolAction
	{
		#region IToolAction Member

		public virtual bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			return true;
		}

		public void ExecuteEventHandler(object sender, Events.ResourceEventArgs e)
		{
			if (!ChangeEnabledStateEventHandler(null, e))
			{
				return;
			}

			// Once you reload the filetable, you're no longer in local mode
			//bool old = SimPe.Helper.LocalMode;
			Helper.LocalMode = false;
			FileTableBase.FileIndex.ForceReload();
			//SimPe.Helper.LocalMode = old;
		}

		#endregion


		#region IToolPlugin Member
		public override string ToString()
		{
			return "Reload FileTable";
		}
		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.recur.png")
				);

		public virtual bool Visible => true;

		#endregion
	}
}
