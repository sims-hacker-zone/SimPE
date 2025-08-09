using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.ViewModels;

public partial class TabItemViewModel : ObservableObject
{
	[ObservableProperty] private string header;
	[ObservableProperty] private UserControl content;

	public TabItemViewModel(string header, UserControl content)
	{
		Header = header;
		Content = content;
	}
}
