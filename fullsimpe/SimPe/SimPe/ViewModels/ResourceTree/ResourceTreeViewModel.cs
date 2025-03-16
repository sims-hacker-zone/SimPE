// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

using SimPe.Models.Package;

namespace SimPe.ViewModels.ResourceTree
{
	public partial class ResourceTreeViewModel : INotifyPropertyChanged
	{
		internal MainWindowViewModel parent;
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly PackageFile packageFile;

		public ObservableCollection<ResourceTreeTypeViewModel> Nodes
		{
			get; set;
		}

		public string Caption => $"All Resources ({packageFile.FileIndex.Count})";

		public ResourceTreeViewModel(PackageFile packageFile, MainWindowViewModel parent)
		{
			this.packageFile = packageFile;
			this.parent = parent;
			Nodes = new(packageFile.FileIndex.GroupBy(item => item.Type).Select(item => new ResourceTreeTypeViewModel(packageFile, item.Key, this)).OrderBy(item => item.Caption));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Caption)));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nodes)));
		}
	}
}
