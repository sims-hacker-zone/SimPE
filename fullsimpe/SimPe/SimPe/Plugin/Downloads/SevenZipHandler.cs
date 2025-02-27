namespace SimPe.Plugin.Downloads
{
	/// <summary>
	/// Summary description for SevenZipHandler.
	/// </summary>
	public class SevenZipHandler : ArchiveHandler
	{
		public SevenZipHandler(string filename)
			: base(filename) { }

		protected override StringArrayList ExtractArchive()
		{
			StringArrayList ret = new StringArrayList();
			Ambertation.SevenZip.IO.CommandlineArchive a =
				new Ambertation.SevenZip.IO.CommandlineArchive(ArchiveName);
			Ambertation.SevenZip.IO.ArchiveFile[] content = a.ListContent();
			a.Extract(Helper.SimPeTeleportPath, false);

			foreach (Ambertation.SevenZip.IO.ArchiveFile desc in content)
			{
				string rname = System.IO.Path.Combine(
					Helper.SimPeTeleportPath,
					desc.Name
				);
				if (System.IO.File.Exists(rname))
				{
					ret.Add(rname);
				}
			}
			return ret;
		}
	}
}
