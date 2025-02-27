using System.Windows.Forms;

namespace SimPe.Plugin.UI
{
	public class PreferencesPanel : System.Windows.Forms.TabPage
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		protected System.ComponentModel.Container components = null;
		internal ToolTip toolTip1;

		private PackageSettings settings;

		public PackageSettings Settings
		{
			get => settings;
			set
			{
				settings = value;
				OnSettingsChanged();
			}
		}

		protected ToolTip ToolTipControl => toolTip1;

		public PreferencesPanel()
		{
			components = new System.ComponentModel.Container();
			toolTip1 = new ToolTip(components)
			{
				IsBalloon = true,
				ToolTipIcon = ToolTipIcon.Info
			};
		}

		protected virtual void OnSettingsChanged()
		{
		}

		public virtual void OnCommitSettings()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
