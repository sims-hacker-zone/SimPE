using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Sims2.Data;
using SimPe.Sims2.Models.Package;
using SimPe.Sims2.Models.Resource.Ltxt;
using SimPe.Sims2.Models.Resource.Picture;

namespace SimPe.Sims2.Models.Game;

public partial class Lot(PackageFile neighborhoodFile, PackageFile lotFile, Ltxt ltxt) : ObservableObject
{
	public uint LotInstance => LotDescription.LotInstance;

	[ObservableProperty] private PackageFile neighborhoodFile = neighborhoodFile;

	[ObservableProperty] private PackageFile lotFile = lotFile;

	public Ltxt LotDescription { get; } = ltxt;

	public string LotName => LotDescription.Name;

	public Bitmap LotImage => LotFile.FindFile(FileTypes.IMG, 0xFFFFFFFF, 0, 0x35CA0002)?.Wrapper?.As<Picture>().Image;

	public override string ToString()
	{
		return $"{LotName} (0x{LotInstance:X8})";
	}
}
