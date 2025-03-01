// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe
{
	/// <summary>
	/// use this Class to access the FileIndex
	/// </summary>
	public class FileTable : FileTableBase
	{
		/// <summary>
		/// Returns/Sets a ToolRegistry (can be null)
		/// </summary>
		public static Interfaces.IToolRegistry ToolRegistry
		{
			get; set;
		}

		/// <summary>
		/// Returns/Sets a HelpTopicRegistry (can be null)
		/// </summary>
		public static Interfaces.IHelpRegistry HelpTopicRegistry
		{
			get; set;
		}

		/// <summary>
		/// Returns/Sets a SettingsRegistry (can be null)
		/// </summary>
		public static Interfaces.ISettingsRegistry SettingsRegistry
		{
			get; set;
		}

		public static Interfaces.ICommandLineRegistry CommandLineRegistry
		{
			get; set;
		}

		public static void Reload()
		{
			FileIndex.BaseFolders.Clear();
			FileIndex.BaseFolders = DefaultFolders;
			FileIndex.ForceReload();
		}
	}
}
