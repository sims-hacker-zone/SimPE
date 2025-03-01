// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Globalization;
using System.Resources;
using System.Threading;

namespace SimPe
{
	/// <summary>
	/// Supports the Localization
	/// </summary>
	public class Localization
	{
		/// <summary>
		/// The Resource Class
		/// </summary>
		private static ResourceManager resource = null;

		/// <summary>
		/// Initializes the Resource
		/// </summary>
		protected static void Initialize()
		{
			Localization l = new Localization();
			System.Reflection.Assembly myAssembly;
			myAssembly = l.GetType().Assembly;

			resource = new ResourceManager(typeof(Localization));
		}

		/// <summary>
		/// Returns a translated String
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		/// <remarks>If there is no Translation, the passsed string will be returned</remarks>
		public static string GetString(string name)
		{
			return (Manager.GetString(name) ?? Manager.GetString(name.Trim().ToLower())) ?? name;
		}

		/// <summary>
		/// Returns the currrent Resource Manager
		/// </summary>
		public static ResourceManager Manager
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
		/// Returns the current Culture
		/// </summary>
		public static CultureInfo Culture => Thread.CurrentThread.CurrentUICulture;
	}
}
