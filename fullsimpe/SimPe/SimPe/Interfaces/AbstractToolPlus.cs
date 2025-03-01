// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces
{
	/// <summary>
	/// Abstract Implementation for <see cref="IToolExt"/> classes
	/// </summary>
	public abstract class AbstractToolPlus : AbstractTool, IToolPlus
	{
		#region ITool Member

		public abstract Plugin.IToolResult ShowDialog(
			ref Files.IPackedFileDescriptor pfd,
			ref Files.IPackageFile package
		);
		public abstract bool IsEnabled(
			Files.IPackedFileDescriptor pfd,
			Files.IPackageFile package
		);

		#endregion

		public static Files.IPackedFileDescriptor ExtractFileDescriptor(
			Events.ResourceEventArgs e
		)
		{
			if (e == null)
			{
				return null;
			}

			Files.IPackedFileDescriptor pfd = null;
			if (e.Count > 0)
			{
				if (e[0].HasFileDescriptor)
				{
					pfd = e[0].Resource.FileDescriptor;
				}
			}

			return pfd;
		}

		public static Files.IPackageFile ExtractPackage(
			Events.ResourceEventArgs e
		)
		{
			if (e == null)
			{
				return null;
			}

			Files.IPackageFile pkg = null;
			if (e.Count > 0)
			{
				if (e[0].HasPackage)
				{
					pkg = e[0].Resource.Package;
				}
			}

			if (pkg == null && e.Loaded)
			{
				pkg = e.LoadedPackage.Package;
			}

			return pkg;
		}

		#region IToolPlus Member

		public virtual void Execute(object sender, Events.ResourceEventArgs e)
		{
			Files.IPackedFileDescriptor pfd = ExtractFileDescriptor(e);
			Files.IPackageFile pkg = ExtractPackage(e);

			if (!IsEnabled(pfd, pkg))
			{
				return;
			}

			Plugin.IToolResult ires = ShowDialog(ref pfd, ref pkg);

			if (e.Count > 0)
			{
				e[0].ChangedFile = ires.ChangedFile;
				e[0].ChangedPackage = ires.ChangedPackage;
			}
		}

		public virtual bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs e
		)
		{
			Files.IPackedFileDescriptor pfd = ExtractFileDescriptor(e);
			Files.IPackageFile pkg = ExtractPackage(e);

			return IsEnabled(pfd, pkg);
		}

		#endregion
	}
}
