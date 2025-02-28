// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Resources;

namespace pjse
{
	/// <summary>
	/// Supports the Localization
	/// </summary>
	public class Localization
	{
		/// <summary>
		/// The ResourceManager singleton object
		/// </summary>
		private static ResourceManager resource = null;

		/// <summary>
		/// Initializes the ResourceManager
		/// </summary>
		private static void Initialize()
		{
			resource = new ResourceManager(typeof(Localization));
		}

		/// <summary>
		/// Returns the current Resource Manager
		/// </summary>
		private static ResourceManager Manager
		{
			get
			{
				if (resource == null)
				{
					Initialize();
				}

				return resource;
			}
		}

		/// <summary>
		/// Returns a translated String
		/// </summary>
		/// <param name="name">string to translate</param>
		/// <returns>translated string</returns>
		/// <remarks>If there is no Translation, the passsed string will be returned</remarks>
		public static string GetString(string name)
		{
			return Manager.GetString(name) ?? name;
		}

		/// <summary>
		/// Returns a translated String with parameter substitution
		/// </summary>
		/// <param name="name">string to translate</param>
		/// <returns>translated string</returns>
		/// <remarks>If there is no Translation, the passsed string will be returned</remarks>
		public static string GetString(string name, params object[] args)
		{
			string res = Manager.GetString(name) ?? name;

			for (int i = 0; i < args.Length; i++)
			{
				res = res.Replace("{" + i.ToString() + "}", args[i].ToString());
			}

			return res;
		}
	}
}
