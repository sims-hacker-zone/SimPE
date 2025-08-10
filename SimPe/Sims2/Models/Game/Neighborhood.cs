// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Sims2.Data;
using SimPe.Sims2.Models.Package;
using SimPe.Sims2.Models.Resource.Fami;
using SimPe.Sims2.Models.Resource.Lotd;
using SimPe.Sims2.Models.Resource.Ltxt;
using SimPe.Sims2.Models.Resource.Objd;
using SimPe.Sims2.Models.Resource.Picture;
using SimPe.Sims2.Models.Resource.Sdsc;

namespace SimPe.Sims2.Models.Game;

public partial class Neighborhood(PackageFile neighborhoodFile) : ObservableObject
{
	[ObservableProperty] private PackageFile neighborhoodFile = neighborhoodFile;

	[ObservableProperty] private ObservableCollection<Lot> lots = [];

	[ObservableProperty] private ObservableCollection<Sim> sims = [];

	[ObservableProperty] private ObservableCollection<Family> families = [];

	public static async Task<Neighborhood> LoadNeighborhood(PackageFile neighborhoodFile)
	{
		Neighborhood neighborhood = new(neighborhoodFile);

		// Load all character files

		IStorageFolder? folder = await neighborhoodFile.StorageFile.GetParentAsync();
		folder = (IStorageFolder?)folder?.GetItemsAsync().ToBlockingEnumerable()
		                                .FirstOrDefault(x => x.Name == "Characters");
		if (folder == null)
		{
			throw new FileNotFoundException("Characters folder not found");
		}

		await foreach (IStorageItem item in folder.GetItemsAsync())
		{
			if (item is IStorageFile file && file.Name.EndsWith(".package"))
			{
				PackageFile characterFile = await Common.Models.FileLoader.LoadFile(file) as PackageFile ??
				                            throw new FileNotFoundException(
					                            $"Could not load character file {file.Name}");
				// Get Sim GUID from OBJD
				Objd? objd = characterFile.FindFiles(FileTypes.OBJD, 0xFFFFFFFF, null, null).FirstOrDefault()?.Wrapper
				                          ?.As<Objd>();
				if (objd == null)
				{
					continue;
				}

				uint simGuid = objd.Guid;

				// Find Sim description of the GUID

				Sdsc? sdsc = neighborhoodFile.FindFiles(FileTypes.SDSC, null, null, null)
				                             .Where(x => x.Wrapper.As<Sdsc>().SimGUID == simGuid)
				                             .Select(x => x.Wrapper.As<Sdsc>())
				                             .FirstOrDefault();
				if (sdsc == null)
				{
					continue;
				}

				ushort simInstance = sdsc.SimInstance;

				// Add Sim to the neighborhood
				neighborhood.Sims.Add(new Sim(neighborhoodFile, characterFile, simGuid, simInstance));
				Console.WriteLine(
					$"Sim loaded: 0x{neighborhood.Sims[^1].SimInstance:X4} (0x{neighborhood.Sims[^1].SimGuid:X8})");
			}
		}

		// Load all lots

		folder = await neighborhoodFile.StorageFile.GetParentAsync();
		folder = (IStorageFolder?)folder?.GetItemsAsync().ToBlockingEnumerable().FirstOrDefault(x => x.Name == "Lots");
		if (folder == null)
		{
			throw new FileNotFoundException("Lots folder not found");
		}

		await foreach (IStorageItem item in folder.GetItemsAsync())
		{
			if (item is IStorageFile file && file.Name.EndsWith(".package"))
			{
				PackageFile lotFile = await Common.Models.FileLoader.LoadFile(file) as PackageFile ??
				                      throw new FileNotFoundException($"Could not load lot file {file.Name}");

				// Get the Lot name from the LOTD of the lot file
				Lotd lotd = lotFile.FindFile(FileTypes.LOTD, 0xFFFFFFFF, 0, 0)?.Wrapper.As<Lotd>();
				if (lotd == null)
				{
					continue;
				}

				string lotName = lotd.Name;

				// Get the Lot name from the LTXT of the neighborhood file
				Ltxt ltxt = neighborhoodFile.FindFiles(FileTypes.LTXT, 0xFFFFFFFF, null, null)
				                            .Where(x => x.Wrapper.As<Ltxt>().Name == lotName)
				                            .Select(x => x.Wrapper.As<Ltxt>())
				                            .FirstOrDefault();
				if (ltxt == null)
				{
					continue;
				}

				neighborhood.Lots.Add(new Lot(neighborhoodFile, lotFile, ltxt));
				Console.WriteLine($"Lot loaded: 0x{neighborhood.Lots[^1].LotInstance:X4}");
			}
		}

		// Load family thumbnails

		folder = await neighborhoodFile.StorageFile.GetParentAsync();
		folder = (IStorageFolder)folder.GetItemsAsync().ToBlockingEnumerable()
		                               .FirstOrDefault(x => x.Name == "Thumbnails");
		if (folder == null)
		{
			throw new FileNotFoundException("Thumbnails folder not found");
		}

		IStorageFile thumbnailFile =
			(IStorageFile)folder.GetItemsAsync().ToBlockingEnumerable()
			                    .FirstOrDefault(x => x.Name.EndsWith("FamilyThumbnails.package")) ??
			throw new FileNotFoundException("FamilyThumbnails file not found");
		PackageFile familyThumbnailFile = await Common.Models.FileLoader.LoadFile(thumbnailFile) as PackageFile ??
		                                  throw new FileNotFoundException(
			                                  $"Could not load family thumbnail file {thumbnailFile.Name}");

		foreach (Fami fami in neighborhoodFile.FindFiles(FileTypes.FAMI, 0xFFFFFFFF, null, null)
		                                      .Select(x => x.Wrapper.As<Fami>()))
		{
			Picture thumbnail = familyThumbnailFile
			                    .FindFiles(FileTypes.THUMB_FAMILY, 0xFFFFFFFF, 0,
			                               (fami.Resource as Resource.Resource).Instance)
			                    .FirstOrDefault()?.Wrapper
			                    ?.As<Picture>();
			neighborhood.Families.Add(new Family(neighborhoodFile, fami, thumbnail));
			Console.WriteLine($"Family loaded: {neighborhood.Families[^1].Name}");
		}

		neighborhood.Sims =
			new ObservableCollection<Sim>(Enumerable.OrderBy<Sim, ushort>(neighborhood.Sims, x => x.SimInstance));
		neighborhood.Lots =
			new ObservableCollection<Lot>(Enumerable.OrderBy<Lot, uint>(neighborhood.Lots, x => x.LotInstance));
		neighborhood.Families =
			new ObservableCollection<Family>(Enumerable.OrderBy<Family, uint>(neighborhood.Families,
			                                                                  x => x.FamilyInstance));
		return neighborhood;
	}
}
