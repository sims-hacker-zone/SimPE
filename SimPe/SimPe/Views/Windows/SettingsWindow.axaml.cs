using System.Linq;

using Avalonia.Controls;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Models;
using SimPe.Models.Configuration;

namespace SimPe.Views.Windows
{
	public partial class SettingsWindow : Window
	{
		public SettingsWindow(Configuration configuration)
		{
			DataContext = configuration;
			InitializeComponent();
			foreach (EnumDisplayNameItem<PackageFolders> value in new EnumDisplayNameItem<PackageFolders>(PackageFolders.BaseGame).Values)
			{
				if (!configuration.ExpansionInstallPaths.Any(x => x.Item == value))
				{
					configuration.ExpansionInstallPaths.Add(new()
					{
						Item = value,
						Path = ""
					});
				}
			}
		}
	}
}
