namespace SimPe.Plugin.Downloads
{
	/// <summary>
	/// Summary description for LotTypeHandler.
	/// </summary>
	public abstract class SimpleTypeHandler : ITypeHandler, System.IDisposable
	{
		protected PackageInfo nfo;

		public SimpleTypeHandler()
		{
		}

		protected abstract void SetName(Interfaces.Files.IPackageFile pkg);
		protected abstract void SetImage(Interfaces.Files.IPackageFile pkg);

		protected void SetName(uint type, Interfaces.Files.IPackageFile pkg)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(type);

			if (pfds.Length > 0)
			{
				PackedFiles.Wrapper.StrItemList items =
					DefaultTypeHandler.GetCtssItems(pfds[0], pkg);
				if (items.Length > 0)
				{
					nfo.Name = items[0].Title;
				}
			}
		}

		protected void SetImage(uint type, Interfaces.Files.IPackageFile pkg)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(type);
			if (pfds.Length > 0)
			{
				PackedFiles.Wrapper.Picture pic =
					new PackedFiles.Wrapper.Picture();
				pic.ProcessData(pfds[0], pkg);
				nfo.Image = pic.Image;
			}

			nfo.KnockoutThumbnail = false;
		}

		protected virtual void BeforeLoadContent(
			Cache.PackageType type,
			Interfaces.Files.IPackageFile pkg
		)
		{
		}

		protected virtual void AfterLoadContent(
			Cache.PackageType type,
			Interfaces.Files.IPackageFile pkg
		)
		{
		}

		#region ITypeHandler Member



		public void LoadContent(
			Cache.PackageType type,
			Interfaces.Files.IPackageFile pkg
		)
		{
			nfo = new PackageInfo(pkg);
			BeforeLoadContent(type, pkg);
			SetName(pkg);
			SetImage(pkg);
			AfterLoadContent(type, pkg);
		}

		public IPackageInfo[] Objects => new IPackageInfo[] { nfo };

		#endregion

		#region IDisposable Member

		public virtual void Dispose()
		{
			this.nfo = null;
		}

		#endregion
	}
}
