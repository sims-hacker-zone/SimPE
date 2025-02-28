// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Lists all Plugins (=FileType Wrappers) available in this Package
	/// </summary>
	/// <remarks>
	/// GetWrappers() has to return a list of all Plugins provided by this Library.
	/// If a Plugin isn't returned, SimPe won't recognize it!
	/// </remarks>
	public class DownloadsToolFactory
		: Interfaces.Plugin.AbstractWrapperFactory,
			Interfaces.Plugin.IToolFactory,
			Interfaces.Plugin.ISettingsFactory
	{
		static Interfaces.Scenegraph.IScenegraphFileIndex fii,
			tfii;
		internal static Interfaces.Scenegraph.IScenegraphFileIndex FileIndex
		{
			get
			{
				if (fii == null)
				{
					fii = FileTableBase.FileIndex.AddNewChild();
				}

				return fii;
			}
		}
		internal static Interfaces.Scenegraph.IScenegraphFileIndex TeleportFileIndex
		{
			get
			{
				if (tfii == null)
				{
					tfii = FileIndex.AddNewChild();
				}

				return tfii;
			}
		}

		public DownloadsToolFactory()
		{
			Packages.StreamFactory.CleanupTeleport();
		}

		~DownloadsToolFactory()
		{
			Packages.StreamFactory.CleanupTeleport();
		}

		#region AbstractWrapperFactory Member
		/// <summary>
		/// Returns a List of all available Plugins in this Package
		/// </summary>
		/// <returns>A List of all provided Plugins (=FileType Wrappers)</returns>
		public override IWrapper[] KnownWrappers =>
				// TODO:  You can add more Wrappers here
				new IWrapper[] { };

		#endregion

		#region IToolFactory Member

		public IToolPlugin[] KnownTools => new IToolPlugin[] { };
		#endregion

		#region ISettingsFactory Member
		static Downloads.DownloadsSettings settings;
		public static Downloads.DownloadsSettings Settings
		{
			get
			{
				if (settings == null)
				{
					settings = new Downloads.DownloadsSettings();
				}

				return settings;
			}
		}

		public ISettings[] KnownSettings => new ISettings[] { Settings };

		#endregion
	}
}
