using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Sims1.Models.Configuration;

public partial class Sims1Config : ObservableObject
{
	[ObservableProperty] private ObservableCollection<InstalledGame> installedGames = [];
}
