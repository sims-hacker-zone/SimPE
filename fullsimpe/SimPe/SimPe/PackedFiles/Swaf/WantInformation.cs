// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
		Str.Str str;
		Picture.Picture primicon;
		protected uint guid;
		internal string prefix = "";

		static ILookup<uint, WantCacheItem> wantcache => (from container in Cache.Cache.GlobalCache.Items[ContainerType.Want].Values
														  from WantCacheItem wci in container
														  select wci).ToLookup(wci => wci.Guid);

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
		static Cache.Cache cachefile => Cache.Cache.GlobalCache;

		/// <summary>
		/// Save the Cache to the FileSystem
		/// </summary>
		public static void SaveCache()
		{
			if (!Helper.WindowsRegistry.Config.UseCache)
			{
				return;
			}

			Wait.SubStart();
			Wait.Message = "Saving Cache";
			cachefile.Save();
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
			if (wantcache.Contains(guid))
			{
				return WantCacheInformation.LoadWant(wantcache[guid].First());
			}
			else
			{
				WantInformation wf = new WantInformation(guid);
				cachefile.AddWantItem(wf);
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
					Helper.WindowsRegistry.Config.LanguageCode,
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
