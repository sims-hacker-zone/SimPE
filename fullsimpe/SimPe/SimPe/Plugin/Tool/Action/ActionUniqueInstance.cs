// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin.Tool.Action
{
	/*public class TestListener  : SimPe.Interfaces.IListener, SimPe.Interfaces.ITool
	{
		#region IListener Member

		public void SelectionChangedHandler(object sender, SimPe.Events.ResourceEventArgs e)
		{
			Message.Show("Notified new Interface");
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return "Test Listener";
		}

		#endregion

		#region ITool Member

		public bool IsEnabled(SimPe.Interfaces.Files.IPackedFileDescriptor pfd, SimPe.Interfaces.Files.IPackageFile package)
		{
			System.Windows.Forms.MessageBox.Show("Notified old Interface");
			return false;
		}

		public SimPe.Interfaces.Plugin.IToolResult ShowDialog(ref SimPe.Interfaces.Files.IPackedFileDescriptor pfd, ref SimPe.Interfaces.Files.IPackageFile package)
		{

			return null;
		}

		#endregion
	}*/

	/// <summary>
	/// The UniqueInstance Action
	/// </summary>
	public class ActionUniqueInstance : Interfaces.IToolAction
	{
		#region IToolAction Member

		public virtual bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			return true;
		}

		private bool RealChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			return es.HasFileDescriptor;
		}

		public void ExecuteEventHandler(object sender, Events.ResourceEventArgs e)
		{
			if (!RealChangeEnabledStateEventHandler(null, e))
			{
				System.Windows.Forms.MessageBox.Show(
					Localization.GetString(
						"This is not an appropriate context in which to use this tool"
					),
					Localization.GetString(ToString())
				);
				return;
			}

			SimPe.Collections.PackedFileDescriptors pfds = e.GetDescriptors();
			bool first = true;
			uint inst = 0x8000;
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				if (first)
				{
					first = false;
					inst = pfd.Instance;
				}
				else
				{
					pfd.Instance = inst;
				}

				inst++;
			}
		}

		#endregion


		#region IToolPlugin Member
		public override string ToString()
		{
			return "Unique Instances";
		}
		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.agent.png")
				);

		public virtual bool Visible => true;

		#endregion
	}
}
