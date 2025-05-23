

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Models.Package;

namespace SimPe.Models.Game
{
	public partial class Lot(PackageFile neighborhoodFile, PackageFile lotFile) : ObservableObject
	{
		[ObservableProperty]
		private uint lotInstance;

		[ObservableProperty]
		private PackageFile neighborhoodFile = neighborhoodFile;

		[ObservableProperty]
		private PackageFile lotFile = lotFile;
	}
}
