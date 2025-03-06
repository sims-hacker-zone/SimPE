// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// this interface must be implemented by Result Items in order to be handled by the Result Browser
	/// </summary>
	internal interface IFinderResultItem
	{
		/// <summary>
		/// Open the Resource in SimPE
		/// </summary>
		/// <returns>true, if the Resource was opened</returns>
		bool OpenResource();
	}

	/// <summary>
	/// Represents one found Resource, you need to override <see cref="Open"/> with a specific Implementation.
	/// </summary>
	internal class FinderResultItem
		: SteepValley.Windows.Forms.XPListViewItem,
			IFinderResultItem
	{
		public FinderResultItem()
			: this("") { }

		public FinderResultItem(string text)
			: base()
		{
			Text = text;
		}

		public virtual bool OpenResource()
		{
			return true;
		}
	}

	/// <summary>
	/// Represents a found <see cref="Interfaces.Scenegraph.IScenegraphFileIndexItem"/> Resource.
	/// </summary>
	internal class ScenegraphResultItem : FinderResultItem
	{
		Interfaces.Scenegraph.IScenegraphFileIndexItem fii;

		public ScenegraphResultItem(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii
		)
			: base(Localization.GetString("Unknown"))
		{
			this.fii = fii;
			Interfaces.Plugin.Internal.IPackedFileWrapper wrp =
				FileTableBase.WrapperRegistry.FindHandler(fii.FileDescriptor.Type);
			if (wrp != null)
			{
				((Interfaces.Plugin.AbstractWrapper)wrp).Package = fii.Package;
				((Interfaces.Plugin.AbstractWrapper)wrp).FileDescriptor =
					fii.FileDescriptor;
				Text = wrp.ResourceName;
			}
			else
			{
				Text = fii.FileDescriptor.ToString();
			}

			SubItems.Add("0x" + Helper.HexString(fii.FileDescriptor.Type));
			SubItems.Add("0x" + Helper.HexString(fii.FileDescriptor.Group));
			SubItems.Add($"0x{fii.FileDescriptor.LongInstance:X16}");
			SubItems.Add("0x" + Helper.HexString(fii.FileDescriptor.Offset));
			SubItems.Add("0x" + Helper.HexStringInt(fii.FileDescriptor.Size));
			SubItems.Add(fii.Package.SaveFileName);
			/*this.SubItems.Add("    Type: 0x"+Helper.HexString(fii.FileDescriptor.Type));
			this.SubItems.Add("    Group: 0x"+Helper.HexString(fii.FileDescriptor.Group));
			this.SubItems.Add("    Instance: 0x"+Helper.HexString(fii.FileDescriptor.LongInstance));
			this.SubItems.Add("    Offset: 0x"+Helper.HexString(fii.FileDescriptor.Offset));
			this.SubItems.Add("    Size: 0x"+Helper.HexString(fii.FileDescriptor.Size));
			this.SubItems.Add("    "+fii.Package.SaveFileName);*/
		}

		public ScenegraphResultItem(
			Interfaces.Files.IPackageFile pkg,
			Interfaces.Files.IPackedFileDescriptor pfd
		)
			: this(new FileIndexItem(pfd, pkg)) { }

		public override bool OpenResource()
		{
			return RemoteControl.OpenPackedFileFkt(fii);
		}
	}
}
