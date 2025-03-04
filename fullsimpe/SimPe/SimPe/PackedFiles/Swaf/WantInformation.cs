// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;

using SimPe.Cache;
using SimPe.Plugin;

namespace SimPe.PackedFiles.Swaf
{
	/// <summary>
	/// This basically is a Class describing the Wants
	/// </summary>
	public class WantInformation
	{
		protected XWant wnt;
		Wrapper.Str str;
		Picture.Picture primicon;
		protected uint guid;
		internal string prefix = "";

		static Dictionary<uint, WantCacheItem> wantcache;

		/// <summary>
		/// Use WantInformation::LoadWant() to create a new Instance
		/// </summary>
		protected WantInformation()
		{
		}

		/// <summary>
		/// Use WantInformation::LoadWant() to create a new Instance
		/// </summary>
		/// <param name="guid">The guid of the Want</param>
		protected WantInformation(uint guid)
		{
			this.guid = guid;

			wnt = WantLoader.GetWant(guid);
			str = WantLoader.LoadText(wnt);
			primicon = WantLoader.LoadIcon(wnt);
		}

		#region Cache
		static WantCacheFile cachefile;

		static void LoadCache()
		{
			if (cachefile != null || !Helper.WindowsRegistry.UseCache)
			{
				return;
			}

			cachefile = new WantCacheFile();

			Wait.SubStart();
			Wait.Message = "Loading Cache";
			try
			{
				cachefile.Load(Helper.SimPeLanguageCache, true);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			Wait.SubStop();
		}

		/// <summary>
		/// Save the Cache to the FileSystem
		/// </summary>
		public static void SaveCache()
		{
			if (!Helper.WindowsRegistry.UseCache || cachefile == null)
			{
				return;
			}

			Wait.SubStart();
			Wait.Message = "Saving Cache";
			cachefile.Save(Helper.SimPeLanguageCache);
			Wait.SubStop();
		}
		#endregion

		/// <summary>
		/// Load Informations about a specific Want
		/// </summary>
		/// <param name="guid">The GUID of the want</param>
		/// <returns>A Want Information Structure</returns>
		public static WantInformation LoadWant(uint guid)
		{
			LoadCache();
			if (wantcache == null)
			{
				wantcache = cachefile.Map;
			}

			if (wantcache.ContainsKey(guid))
			{
				return WantCacheInformation.LoadWant(wantcache[guid]);
			}
			else
			{
				WantInformation wf = new WantInformation(guid);
				cachefile.AddItem(wf);
				return wf;
			}
		}

		/// <summary>
		/// Returns the XWant File
		/// </summary>
		public XWant XWant => wnt;

		/// <summary>
		/// Returns the Name of this Want
		/// </summary>
		public virtual string Name => str == null
					? "0x" + Helper.HexString(guid)
					: str.FallbackedLanguageItem(
					Helper.WindowsRegistry.LanguageCode,
					0).Title;

		/// <summary>
		/// Returns Icon for this want or null
		/// </summary>
		public virtual System.Drawing.Image Icon => primicon?.Image;

		/// <summary>
		/// The guid of the current Want
		/// </summary>
		public uint Guid => guid;

		public override string ToString()
		{
			return prefix + Name;
		}
	}
}
