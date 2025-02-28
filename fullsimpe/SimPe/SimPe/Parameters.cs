// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

namespace SimPe
{
	/// <summary>
	/// Contains Parameters passed on the Commandline
	/// </summary>
	public class Parameters
	{

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="param">Parameters passed on the Coammandline</param>
		public Parameters(string[] param)
		{
			ArrayList fllist = new ArrayList();
			foreach (string s in param)
			{
				if (System.IO.File.Exists(s))
				{
					fllist.Add(s);
				}
			}

			Files = new string[fllist.Count];
			fllist.CopyTo(Files);
		}

		/// <summary>
		/// Returns the Files passed on the Commandline
		/// </summary>
		public string[] Files
		{
			get;
		}
	}
}
