using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Avalonia.Platform.Storage;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Data;

namespace SimPe.Models.Package
{
	public partial class PackageFile : ObservableObject
	{
		[ObservableProperty]
		private IStorageFile storageFile;

		[ObservableProperty]
		private PackageHeader header;

		public ObservableCollection<PackedFile.PackedFile> FileIndex
		{
			get;
			private set;
		} = [];

		public static async Task<PackageFile> Open(IStorageFile file)
		{
			PackageFile package = new()
			{
				StorageFile = file
			};

			using Stream stream = await package.StorageFile.OpenReadAsync();
			using BinaryReader reader = new(stream, Encoding.ASCII);
			reader.BaseStream.Seek(0, SeekOrigin.Begin);

			package.Header = PackageHeader.Unserialize(reader);

			package.UnserializeFileIndex(reader);

			package.OnPropertyChanged(nameof(FileIndex));

			return package;
		}

		public void UnserializeFileIndex(BinaryReader reader)
		{
			reader.BaseStream.Seek(Header.Index.Offset, SeekOrigin.Begin);
			for (int i = 0; i < Header.Index.Count; i++)
			{
				FileIndex.Add(PackedFile.PackedFile.Unserialize(reader, this));
			}
		}

		#region File Search

		public PackedFile.PackedFile FindFile(FileTypes type, uint @group, uint instanceHigh, uint instance)
		{
			return (from file in FileIndex
					where file.Type == type
						&& file.Group == @group
						&& file.InstanceHigh == instanceHigh
						&& file.Instance == instance
					select file).FirstOrDefault();
		}

		public IEnumerable<PackedFile.PackedFile> FindFiles(FileTypes? type, uint? @group, uint? instanceHigh, uint? instance)
		{
			return from file in FileIndex
				   where type == null || file.Type == type
				   where @group == null || file.Group == @group
				   where instanceHigh == null || file.InstanceHigh == instanceHigh
				   where instance == null || file.Instance == instance
				   select file;
		}

		#endregion
	}
}
