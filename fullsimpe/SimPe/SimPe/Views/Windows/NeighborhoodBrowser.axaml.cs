using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Forms.MainUI;
using SimPe.Models.Configuration;
using SimPe.Models.Package;
using SimPe.Models.PackedFile;
using SimPe.Models.PackedFile.Idno;
using SimPe.ViewModels;
using SimPe.ViewModels.NeighborhoodBrowser;

namespace SimPe.Views.Windows
{
	public partial class NeighborhoodBrowser : Window
	{
		public NeighborhoodBrowser()
		{
			InitializeComponent();
		}

		public async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			MainWindowViewModel vm = DataContext as MainWindowViewModel;
			List<(EnumDisplayNameItem<PackageFolders> game, string profile, IStorageFolder folder)> result_folders = [];
			foreach (EnumDisplayNameItem<PackageFolders> item in new EnumDisplayNameItem<PackageFolders>(PackageFolders.BaseGame).Values.Where(item => item.Item >= PackageFolders.SaveGameSims2))
			{
				InstalledExpansionConfig path = vm.Configuration.ExpansionInstallPaths.FirstOrDefault(x => x.Item == item);
				if (path != null && path.Path != "")
				{
					IStorageFolder neighborhoods = await StorageProvider.TryGetFolderFromPathAsync(new(Path.Combine(path.Path, "Neighborhoods")));
					if (neighborhoods != null)
					{
						IEnumerable<IStorageItem> neighborhood_items = neighborhoods.GetItemsAsync().ToBlockingEnumerable();
						if (neighborhood_items.Any(x => x.Name.ToLower() == "profiles.ini"))
						{
							foreach (IStorageFolder x1 in neighborhood_items.OfType<IStorageFolder>())
							{
								result_folders.AddRange(x1.GetItemsAsync().ToBlockingEnumerable().OfType<IStorageFolder>().Select(x => (item, x1.Name, x)));
							}
						}
						else
						{
							result_folders.AddRange(neighborhood_items.OfType<IStorageFolder>().Select(x => (item, null as string, x)));
						}
					}
				}
			}
			if (result_folders.Count == 0)
			{
				await Message.Show("No Neighborhood folders found! Make sure that you have the folders set up correctly in the Configuration!");
				Close();
			}
			ObservableCollection<TreeViewItem> tvitems = [];
			foreach (IGrouping<EnumDisplayNameItem<PackageFolders>, (string profile, IStorageFolder folder)> game in result_folders.ToLookup(x => x.game, x => (x.profile, x.folder)))
			{
				TreeViewItem tv1 = new()
				{
					Header = game.Key.ToString()
				};
				ObservableCollection<TreeViewItem> subitems = [];
				foreach (IGrouping<string, IStorageFolder> profile in game.ToLookup(x => x.profile, x => x.folder))
				{
					if (profile.Key == null)
					{
						tv1.ItemsSource = (await Task.WhenAll(from IStorageFolder nbg in profile select ProcessNeighborhood(nbg))).Where(item => item != null).OrderBy(x => x.ShortName);
						break;
					}
					subitems.Add(new()
					{
						Header = $"Profile 0x{profile.Key}",
						ItemsSource = (await Task.WhenAll(from IStorageFolder nbg in profile select ProcessNeighborhood(nbg))).Where(item => item != null).OrderBy(x => x.ShortName)
					});
				}
				if (subitems.Any())
				{
					tv1.ItemsSource = subitems.OrderBy(x => x.Header);
				}
				tvitems.Add(tv1);
			}
			NeighborhoodTreeView.Items.Clear();
			NeighborhoodTreeView.ItemsSource = tvitems;
		}

		public async Task<NeighborhoodViewModel> ProcessNeighborhood(IStorageFolder folder)
		{
			MainWindowViewModel vm = DataContext as MainWindowViewModel;
			NeighborhoodViewModel nbg = new();
			IEnumerable<IStorageFile> folder_items = folder.GetItemsAsync().ToBlockingEnumerable().OfType<IStorageFile>();
			IStorageFile neighborhood_package = folder_items.FirstOrDefault(x => x.Name.Contains("_Neighborhood.package", System.StringComparison.InvariantCultureIgnoreCase));
			if (neighborhood_package == null)
			{
				return null;
			}
			string prefix = neighborhood_package.Name.Split('_')[0];
			nbg.PackageFile = await vm.GetOrLoadPackage(neighborhood_package);
			if (nbg.PackageFile == null)
			{
				return null;
			}
			IStorageFile neighborhood_png = folder_items.FirstOrDefault(x => x.Name.Contains(neighborhood_package.Name.Replace(".package", ".png", System.StringComparison.InvariantCultureIgnoreCase), System.StringComparison.InvariantCultureIgnoreCase));
			if (neighborhood_png != null)
			{
				nbg.Thumbnail = new(await neighborhood_png.OpenReadAsync());
			}
			Models.PackedFile.PackedFile idno = nbg.PackageFile.FindFiles(FileTypes.IDNO).FirstOrDefault();
			if (idno == null)
			{
				return null;
			}
			idno.ReadContent();
			nbg.Idno = idno.Wrapper as Idno;
			nbg.ShortName = nbg.Idno.Name;
			Models.PackedFile.PackedFile ctss = nbg.PackageFile.FindFiles(FileTypes.CTSS).FirstOrDefault();
			if (ctss == null)
			{
				return null;
			}
			ctss.ReadContent();
			ILookup<int, Models.PackedFile.Str.StrItem> indices = (ctss.Wrapper as Models.PackedFile.Str.Str).ByIndex;
			if (indices.Contains(0))
			{
				nbg.DisplayName = indices[0].First().Title;
			}
			if (indices.Contains(1))
			{
				nbg.Description = indices[1].First().Title;
			}
			nbg.FilePath = Uri.UnescapeDataString(neighborhood_package.Path.AbsolutePath);

			IEnumerable<IStorageFile> subhood_files = folder_items.Where(x => !x.Name.Contains("_Neighborhood.package", System.StringComparison.InvariantCultureIgnoreCase) && x.Name.StartsWith(prefix) && x.Name.EndsWith(".package", System.StringComparison.InvariantCultureIgnoreCase));
			foreach (IStorageFile file in subhood_files)
			{
				nbg.Subhoods.Add(await ProcessSubNeighborhood(folder_items, file));
			}
			nbg.Subhoods = new(nbg.Subhoods.OrderBy(x => x.Idno.AffiliatedEP.Item).ThenBy(x => x.ShortName));


			return nbg;
		}

		public async Task<NeighborhoodViewModel> ProcessSubNeighborhood(IEnumerable<IStorageFile> folder_items, IStorageFile file)
		{
			MainWindowViewModel vm = DataContext as MainWindowViewModel;
			NeighborhoodViewModel nbg = new();
			IStorageFile subhood_package = file;
			if (subhood_package == null)
			{
				return null;
			}
			nbg.PackageFile = await vm.GetOrLoadPackage(subhood_package);
			if (nbg.PackageFile == null)
			{
				return null;
			}
			IStorageFile subhood_png = folder_items.FirstOrDefault(x => x.Name.Contains(subhood_package.Name.Replace(".package", ".png", System.StringComparison.InvariantCultureIgnoreCase), System.StringComparison.InvariantCultureIgnoreCase));
			if (subhood_png != null)
			{
				nbg.Thumbnail = new(await subhood_png.OpenReadAsync());
			}
			Models.PackedFile.PackedFile idno = nbg.PackageFile.FindFiles(FileTypes.IDNO).FirstOrDefault();
			if (idno == null)
			{
				return null;
			}
			idno.ReadContent();
			nbg.Idno = idno.Wrapper as Idno;
			nbg.ShortName = nbg.Idno.SubhoodName;
			Models.PackedFile.PackedFile ctss = nbg.PackageFile.FindFiles(FileTypes.CTSS).FirstOrDefault();
			if (ctss == null)
			{
				return null;
			}
			ctss.ReadContent();
			ILookup<int, Models.PackedFile.Str.StrItem> indices = (ctss.Wrapper as Models.PackedFile.Str.Str).ByIndex;
			if (indices.Contains(0))
			{
				nbg.DisplayName = indices[0].First().Title;
			}
			if (indices.Contains(1))
			{
				nbg.Description = indices[1].First().Title;
			}
			nbg.FilePath = Uri.UnescapeDataString(subhood_package.Path.AbsolutePath);
			return nbg;
		}

		public void Select_Click(object sender, RoutedEventArgs e)
		{
			if (NeighborhoodTreeView.SelectedItem is NeighborhoodViewModel)
			{
				Close(NeighborhoodTreeView.SelectedItem);
			}
		}

		public void Cancel_Click(object sender, RoutedEventArgs e)
		{
			Close(null);
		}
	}
}
