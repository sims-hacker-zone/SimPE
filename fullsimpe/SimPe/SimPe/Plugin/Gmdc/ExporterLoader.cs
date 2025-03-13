// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.Linq;

using SimPe.Plugin.Gmdc.Exporter;
using SimPe.Plugin.Gmdc.Importer;

namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// Manages the dynamic loading of Exporter Plugins
	/// </summary>
	public class ExporterLoader
	{
		/// <summary>
		/// Return a List of all available Exporters
		/// </summary>
		public static HashSet<IGmdcExporter> Exporters => new HashSet<IGmdcExporter>
		{
			new GmdcExportToMilkShapeAscii(),
			new GmdcExportToNorm(),
			new GmdcExportToObj(),
			new GmdcExportToX(),
			new GmdcExportToXSI()
		};

		/// <summary>
		/// Return a List of all available Importers
		/// </summary>
		public static HashSet<IGmdcImporter> Importers => new HashSet<IGmdcImporter>
		{
			new GmdcImportFromMilkShapeAscii(),
			new GmdcImportFromObj(),
			new GmdcImportFromXsi()
		};

		/// <summary>
		/// Returns null or the Exporter that can create a File with teh given Extension
		/// </summary>
		/// <param name="fileext"></param>
		/// <returns>null or an IGmdcExporter Instance</returns>
		public static IGmdcExporter FindExporterByExtension(string fileext)
		{
			return (from exporter in Exporters
					where fileext.Trim().ToLower() == exporter.FileExtension
					select exporter).FirstOrDefault();
		}

		/// <summary>
		/// Finds the first Exporter that registred for the passed File Extension
		/// </summary>
		/// <param name="fileext">The File Extension</param>
		/// <returns>The Index of the Exporter or -1</returns>
		public static int FindFirstIndexByExtension(string fileext)
		{
			IEnumerable<int> res = FindIndexByExtension(fileext);
			return res.Count() == 0 ? -1 : res.First();
		}

		/// <summary>
		/// Finds the Exporter that registred for the passed File Extension
		/// </summary>
		/// <param name="fileext"></param>
		/// <returns>An Array of all Exporters that Registred for that Extension</returns>
		public static IEnumerable<int> FindIndexByExtension(string fileext)
		{
			return Exporters.Select((item, i) => (item, i))
				.Where(item => item.item.FileExtension == fileext.Trim().ToLower())
				.Select(item => item.i);
		}

		/// <summary>
		/// Finds the first Exporter that registred for the passed File Extension
		/// </summary>
		/// <param name="fileext">The File Extension</param>
		/// <returns>The Index of the Exporter or -1</returns>
		public static int FindFirstImporterIndexByExtension(string fileext)
		{
			IEnumerable<int> res = FindImporterIndexByExtension(fileext);
			return res.Count() == 0 ? -1 : res.First();
		}

		/// <summary>
		/// Finds the Exporter that registred for the passed File Extension
		/// </summary>
		/// <param name="fileext"></param>
		/// <returns>An Array of all Exporters that Registred for that Extension</returns>
		public static IEnumerable<int> FindImporterIndexByExtension(string fileext)
		{
			return Importers.Select((item, i) => (item, i))
				.Where(item => item.item.FileExtension == fileext.Trim().ToLower())
				.Select(item => item.i);
		}
	}
}
