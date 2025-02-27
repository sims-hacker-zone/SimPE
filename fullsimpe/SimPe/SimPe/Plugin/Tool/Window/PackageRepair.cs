using System.Drawing;

namespace SimPe.Plugin.Tool.Window
{
	/// <summary>
	/// Tool that should automatically repair corrupted packages
	/// </summary>
	public class PackageRepairTool : SimPe.Interfaces.IToolPlus
	{
		public PackageRepairTool()
		{
		}

		#region IToolPlus Member

		public void Execute(object sender, SimPe.Events.ResourceEventArgs e)
		{
			PackageRepairForm f = new PackageRepairForm();
			if (e.Loaded)
			{
				string flname = e.LoadedPackage.Package.SaveFileName;
				e.LoadedPackage.Package.Close(true);
				f.Setup(flname);
			}
			RemoteControl.ShowSubForm(f);
		}

		public bool ChangeEnabledStateEventHandler(
			object sender,
			SimPe.Events.ResourceEventArgs e
		)
		{
			// return !e.Loaded;
			return true;
		}

		#endregion

		#region IToolExt Member

		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public bool Visible => true;

		public Image Icon => System.Drawing.Image.FromStream(
					this.GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.repair.png")
				);

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return "Object Tools\\Repair Package Index...";
		}

		#endregion
	}
}
