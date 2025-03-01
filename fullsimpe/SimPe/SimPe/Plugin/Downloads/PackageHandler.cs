// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Plugin.Downloads
{
	/// <summary>
	/// Summary description for TypedPackageHandler.
	/// </summary>
	public class PackageHandler : IPackageHandler, System.IDisposable
	{
		Cache.PackageType type;
		string flname;
		ITypeHandler hnd;

		public PackageHandler(string filename)
			: this(Packages.File.LoadFromFile(filename)) { }

		public PackageHandler(Interfaces.Files.IPackageFile pkg)
		{
			flname = pkg.SaveFileName;
			type = Cache.PackageType.Undefined;
			DeterminType(pkg);
			Reset();

			if (
				type == Cache.PackageType.CustomObject
				|| type == Cache.PackageType.Sim
				|| type == Cache.PackageType.Object
			)
			{
				PackedFiles.Wrapper.ObjectComboBox.ObjectCache.ReloadCache(
					DownloadsToolFactory.FileIndex,
					false
				);
			}

			hnd = HandlerRegistry.Global.LoadTypeHandler(type, pkg);
			LoadContent(pkg);
		}

		protected virtual void DeterminType(Interfaces.Files.IPackageFile pkg)
		{
			type = System.IO.File.Exists(
					System.IO.Path.Combine(
						Helper.SimPePluginPath,
						"simpe.scanfolder.plugin.dll"
					)
				)
				? PackageInfo.ClassifyPackage(pkg)
				: Cache.PackageType.Undefined;
		}

		protected virtual void OnLoadContent(
			Interfaces.Files.IPackageFile pkg,
			Cache.PackageType type
		)
		{
		}

		protected virtual void OnReset(Cache.PackageType type)
		{
		}

		protected void LoadContent(Interfaces.Files.IPackageFile pkg)
		{
			hnd.LoadContent(type, pkg);
			foreach (IPackageInfo nfo in hnd.Objects)
			{
				if (nfo is PackageInfo)
				{
					((PackageInfo)nfo).Type = type;
				}
			}

			OnLoadContent(pkg, type);
		}

		protected void Reset()
		{
			OnReset(type);
		}

		#region IPackageHandler Member
		public void FreeResources()
		{
			Packages.StreamFactory.CloseStream(flname);
		}

		public IPackageInfo[] Objects => hnd.Objects;

		#endregion

		#region IDisposable Member

		public void Dispose()
		{
			flname = null;
			hnd = null;
		}

		#endregion
	}
}
