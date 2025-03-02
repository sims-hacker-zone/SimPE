// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Cache;
using SimPe.PackedFiles.Cpf;
using SimPe.Plugin;

namespace SimPe.PackedFiles.Swaf
{
	/// <summary>
	/// This basically is a Class describing the Wants (loaded from the Cache)
	/// </summary>
	public class WantCacheInformation : WantInformation
	{
		/// <summary>
		/// Use WantInformation::LoadWant() to create a new Instance
		/// </summary>
		/// <param name="guid">The guid of the Want</param>
		WantCacheInformation(uint guid)
			: base(guid)
		{
			name = "";
		}

		/// <summary>
		/// Use WantInformation::LoadWant() to create a new Instance
		/// </summary>
		private WantCacheInformation()
			: base()
		{
			name = "";
		}

		/// <summary>
		/// Load Informations about a specific Want
		/// </summary>
		/// <param name="guid">The GUID of the want</param>
		/// <returns>A Want Information Structure</returns>
		public static WantCacheInformation LoadWant(WantCacheItem wci)
		{
			WantCacheInformation ret = new WantCacheInformation
			{
				icon = wci.Icon,
				name = wci.Name,
				guid = wci.Guid
			};

			XWant w = new XWant();
			CpfItem i =
				new CpfItem
				{
					Name = "id",
					UIntegerValue = wci.Guid
				};
			w.AddItem(i, true);
			i = new CpfItem
			{
				Name = "folder",
				StringValue = wci.Folder
			};
			w.AddItem(i, true);
			i = new CpfItem
			{
				Name = "score",
				IntegerValue = wci.Score
			};
			w.AddItem(i, true);
			i = new CpfItem
			{
				Name = "influence",
				IntegerValue = wci.Influence
			};
			w.AddItem(i, true);
			i = new CpfItem
			{
				Name = "objectType",
				StringValue = wci.ObjectType
			};
			w.AddItem(i, true);

			ret.wnt = w;

			return ret;
		}

		System.Drawing.Image icon;
		public override System.Drawing.Image Icon => icon;

		string name;
		public override string Name => name;
	}
}
