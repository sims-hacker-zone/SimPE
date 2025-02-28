// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Dockable Tool that displays Wrapper specific Informations
	/// </summary>
	public class WrapperDockTool : Interfaces.IDockableTool
	{
		ResourceDock rd;

		public WrapperDockTool(ResourceDock rd)
		{
			this.rd = rd;
		}

		#region IDockableTool Member

		public Ambertation.Windows.Forms.DockPanel GetDockableControl()
		{
			return rd.dcWrapper;
		}

		public event Events.ChangedResourceEvent ShowNewResource;

		public void RefreshDock(object sender, Events.ResourceEventArgs es)
		{
			if (!es.Empty)
			{
				if (es.HasFileDescriptor)
				{
					Interfaces.IWrapper wrp =
						FileTableBase.WrapperRegistry.FindHandler(
							es[0].Resource.FileDescriptor.Type
						);

					if (wrp != null)
					{
						rd.lbName.Text = wrp.WrapperDescription.Name;
						rd.lbAuthor.Text = wrp.WrapperDescription.Author;
						rd.lbVersion.Text = wrp.WrapperDescription.Version.ToString();
						rd.lbDesc.Text = wrp.WrapperDescription.Description;
						rd.pb.Image = wrp.WrapperDescription.Icon;
						rd.lbName.Left = rd.pb.Image != null ? rd.pb.Right + 4 : rd.pb.Left;

						return;
					}
				}
			}

			rd.lbName.Text = Localization.GetString("Unknown");
			rd.lbAuthor.Text = Localization.GetString("Unknown");
			rd.lbVersion.Text = Localization.GetString("Unknown");
			rd.lbDesc.Text = Localization.GetString("");
			rd.pb.Image = null;
			rd.lbName.Left = rd.pb.Left;
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return rd.dcWrapper.Text;
		}

		#endregion

		#region IToolExt Member

		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => rd.dcWrapper.TabImage;

		public virtual bool Visible => GetDockableControl().IsDocked || GetDockableControl().IsFloating;

		#endregion
	}
}
