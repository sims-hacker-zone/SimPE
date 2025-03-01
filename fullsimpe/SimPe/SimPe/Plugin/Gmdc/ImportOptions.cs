// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Windows.Forms;

namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// Contains the Globla Import Options as specified by the User
	/// </summary>
	public class ImportOptions
	{
		/// <summary>
		/// Creates an Instance of the Optiosn class
		/// </summary>
		/// <param name="res">Result of the Import Dialog</param>
		/// <param name="cg">Want to clean the Groups</param>
		/// <param name="cb">Want to clean the Joints</param>
		/// <param name="uc">Want to Update the Crew, with the new Bone Hirarchy and Location</param>
		public ImportOptions(DialogResult res, bool cg, bool cb, bool uc)
		{
			Result = res;
			CleanBones = cb;
			CleanGroups = cg;
			UpdateCres = uc;
		}

		/// <summary>
		/// Should the Import be continued?
		/// </summary>
		public DialogResult Result
		{
			get;
		}

		/// <summary>
		/// Should we clean available Groups before the Import?
		/// </summary>
		public bool CleanGroups
		{
			get;
		}

		/// <summary>
		/// Should we remove unreferenced Joints after the Import?
		/// </summary>
		public bool CleanBones
		{
			get;
		}

		/// <summary>
		/// Writes the Bone Locationa and Hirarchy to the CRES
		/// </summary>
		public bool UpdateCres
		{
			get;
		}
	}
}
