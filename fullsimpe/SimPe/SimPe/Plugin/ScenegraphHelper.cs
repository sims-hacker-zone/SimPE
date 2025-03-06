// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Data;

namespace SimPe.Plugin
{
	/// <summary>
	/// Some Helper Methods for the Scenegraph Files
	/// </summary>
	public class ScenegraphHelper
	{
		#region Constant Repeat
		public static string GMND_PACKAGE = MetaData.GMND_PACKAGE;
		public static string MMAT_PACKAGE = MetaData.MMAT_PACKAGE;
		#endregion

		/// <summary>
		/// Returns a PackedFile Descriptor for the given filename
		/// </summary>
		/// <param name="flname"></param>
		/// <param name="type"></param>
		/// <param name="defgroup"></param>
		/// <returns></returns>
		public static Interfaces.Files.IPackedFileDescriptor BuildPfd(
			string flname,
			FileTypes type,
			uint defgroup
		)
		{
			string name = Hashes.StripHashFromName(flname);
			Packages.PackedFileDescriptor pfd =
				new Packages.PackedFileDescriptor
				{
					Type = type,
					Group = Hashes.GetHashGroupFromName(flname, defgroup),
					Instance = Hashes.InstanceHash(name),
					SubType = Hashes.SubTypeHash(name),
					Filename = flname,

					UserData = new byte[0]
				};

			return pfd;
		}
	}
}
