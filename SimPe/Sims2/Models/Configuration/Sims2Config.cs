using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Sims2.Models.Configuration;

public partial class Sims2Config : ObservableObject
{
	[ObservableProperty] private ObservableCollection<InstalledGame> installedGames = [];
}
