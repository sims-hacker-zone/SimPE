

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Avalonia.Platform.Storage;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Models.Package;
using SimPe.Models.PackedFile.Lotd;
using SimPe.Models.PackedFile.Ltxt;
using SimPe.Models.PackedFile.Objd;
using SimPe.Models.PackedFile.Sdsc;
using SimPe.ViewModels;

namespace SimPe.Models.Game
{
	public partial class Neighborhood(PackageFile neighborhoodFile) : ObservableObject
	{
		[ObservableProperty]
		private PackageFile neighborhoodFile = neighborhoodFile;

		[ObservableProperty]
		private ObservableCollection<Lot> lots = [];

		[ObservableProperty]
		private ObservableCollection<Sim> sims = [];

		public static async Task<Neighborhood> LoadNeighborhood(PackageFile neighborhoodFile)
		{
			Neighborhood neighborhood = new(neighborhoodFile);

			// Load all character files

			IStorageFolder folder = await neighborhoodFile.StorageFile.GetParentAsync();
			folder = (IStorageFolder)folder.GetItemsAsync().ToBlockingEnumerable().FirstOrDefault(x => x.Name == "Characters");
			if (folder == null)
			{
				throw new FileNotFoundException("Characters folder not found");
			}
			await foreach (IStorageItem item in folder.GetItemsAsync())
			{
				if (item is IStorageFile file && file.Name.EndsWith(".package"))
				{
					PackageFile characterFile = await (Program.MainWindow.DataContext as MainWindowViewModel).GetOrLoadPackage(file) ?? throw new FileNotFoundException($"Could not load character file {file.Name}");
					// Get Sim GUID from OBJD
					Objd objd = characterFile.FindFiles(Data.FileTypes.OBJD, 0xFFFFFFFF, null, null).FirstOrDefault()?.Wrapper?.As<Objd>();
					if (objd == null)
					{
						continue;
					}
					uint simGuid = objd.Guid;

					// Find Sim description of the GUID

					Sdsc sdsc = neighborhoodFile.FindFiles(Data.FileTypes.SDSC, null, null, null).Where(x => x.Wrapper.As<Sdsc>().SimGUID == simGuid).Select(x => x.Wrapper.As<Sdsc>()).FirstOrDefault();
					if (sdsc == null)
					{
						continue;
					}
					ushort simInstance = sdsc.SimInstance;

					// Add Sim to the neighborhood
					neighborhood.Sims.Add(new Sim(neighborhoodFile, characterFile, simGuid, simInstance));
					Console.WriteLine($"Sim loaded: 0x{neighborhood.Sims[^1].SimInstance:X4} (0x{neighborhood.Sims[^1].SimGuid:X8})");
				}
			}

			// Load all lots

			folder = await neighborhoodFile.StorageFile.GetParentAsync();
			folder = (IStorageFolder)folder.GetItemsAsync().ToBlockingEnumerable().FirstOrDefault(x => x.Name == "Lots");
			if (folder == null)
			{
				throw new FileNotFoundException("Lots folder not found");
			}
			await foreach (IStorageItem item in folder.GetItemsAsync())
			{
				if (item is IStorageFile file && file.Name.EndsWith(".package"))
				{
					PackageFile lotFile = await (Program.MainWindow.DataContext as MainWindowViewModel).GetOrLoadPackage(file) ?? throw new FileNotFoundException($"Could not load lot file {file.Name}");

					// Get the Lot name from the LOTD of the lot file
					Lotd lotd = lotFile.FindFile(Data.FileTypes.LOTD, 0xFFFFFFFF, 0, 0)?.Wrapper.As<Lotd>();
					if (lotd == null)
					{
						continue;
					}
					string lotName = lotd.Name;

					// Get the Lot name from the LTXT of the neighborhood file
					Ltxt ltxt = neighborhoodFile.FindFiles(Data.FileTypes.LTXT, 0xFFFFFFFF, null, null).Where(x => x.Wrapper.As<Ltxt>().Name == lotName).Select(x => x.Wrapper.As<Ltxt>()).FirstOrDefault();
					if (ltxt == null)
					{
						continue;
					}

					neighborhood.Lots.Add(new Lot(neighborhoodFile, lotFile, ltxt));
					Console.WriteLine($"Lot loaded: 0x{neighborhood.Lots[^1].LotInstance:X4}");

				}
			}

			neighborhood.Sims = new ObservableCollection<Sim>(neighborhood.Sims.OrderBy(x => x.SimInstance));
			neighborhood.Lots = new ObservableCollection<Lot>(neighborhood.Lots.OrderBy(x => x.LotInstance));
			return neighborhood;
		}
	}
}
