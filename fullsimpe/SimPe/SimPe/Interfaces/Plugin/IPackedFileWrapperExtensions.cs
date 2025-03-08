// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
//.ProcessFile
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin.Internal;

namespace SimPe.Interfaces.Plugin
{
	public static class IPackedFileWrapperExtensions
	{
		public static T ProcessFile<T>(this T instance, Scenegraph.IScenegraphFileIndexItem item) where T : IPackedFileWrapper
		{
			instance.ProcessData(item);
			return instance;
		}

		public static T ProcessFile<T>(this T instance, Scenegraph.IScenegraphFileIndexItem item, bool catchex) where T : IPackedFileWrapper
		{
			instance.ProcessData(item, catchex);
			return instance;
		}

		public static T ProcessFile<T>(this T instance, IPackedFileDescriptor pfd, IPackageFile package) where T : IPackedFileWrapper
		{
			instance.ProcessData(pfd, package);
			return instance;
		}

		public static T ProcessFile<T>(this T instance, IPackedFileDescriptor pfd, IPackageFile package, bool catchex) where T : IPackedFileWrapper
		{
			instance.ProcessData(pfd, package, catchex);
			return instance;
		}

		public static T ProcessFile<T>(this T instance, IPackedFileDescriptor pfd,
			IPackageFile package,
			IPackedFile file,
			bool catchex) where T : IPackedFileWrapper
		{
			instance.ProcessData(pfd, package, file, catchex);
			return instance;
		}

		public static T ProcessFile<T>(this T instance, IPackedFileDescriptor pfd,
			IPackageFile package,
			IPackedFile file) where T : IPackedFileWrapper
		{
			instance.ProcessData(pfd, package, file);
			return instance;
		}
	}
}
