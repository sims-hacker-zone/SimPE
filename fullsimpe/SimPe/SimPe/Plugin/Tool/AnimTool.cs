// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Events;

namespace SimPe.Plugin.Tool
{
	/// <summary>
	/// Toll that can preview Animations
	/// </summary>
	public class AnimTool : Interfaces.IToolPlus
	{
		internal AnimTool()
		{
		}

		#region ITool Member

		public bool ChangeEnabledStateEventHandler(object sender, ResourceEventArgs e)
		{
			return e.Loaded && e.HasResource && e.Count <= 1
				&& e.Items[0].Resource.FileDescriptor.Type
				== Data.FileTypes.ANIM;
		}

		public void Execute(object sender, ResourceEventArgs es)
		{
			if (!ChangeEnabledStateEventHandler(sender, es))
			{
				return;
			}

			try
			{
				AnimPreview.Execute(es.Items[0].Resource);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		public override string ToString()
		{
			return "Object Tool\\Animation Preview";
		}

		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.CtrlShiftA;

		public System.Drawing.Image Icon => GetIcon.AnimCamera;

		public virtual bool Visible => true;

		#endregion
	}
}
