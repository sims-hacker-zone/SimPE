// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using SimPe.ViewModels;

namespace SimPe.Views.Windows;

public partial class FindInFiles : Window
{
	public FindInFiles()
	{
		InitializeComponent();
	}


	private void Search_Click(object sender, RoutedEventArgs e)
	{
		// FindInFilesViewModel vm = DataContext as FindInFilesViewModel;
		// vm.FoundFiles.Clear();
		// foreach (Models.Resource.Resource item in from package in vm.Parent.LoadedPackages
		// 										  from file in package.FindFiles(
		// 											  typeCheckbox.IsChecked == true ? vm.Type.Item : null,
		// 											  groupCheckbox.IsChecked == true ? vm.Group : null,
		// 											  instanceHighCheckbox.IsChecked == true ? vm.InstanceHigh : null,
		// 											  instanceCheckbox.IsChecked == true ? vm.Instance : null
		// 										  )
		// 										  select file)
		// {
		// 	vm.FoundFiles.Add(item);
		// }
	}
}
