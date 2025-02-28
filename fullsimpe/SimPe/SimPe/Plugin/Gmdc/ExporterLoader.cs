// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// Manages the dynamic loading of Exporter Plugins
	/// </summary>
	public class ExporterLoader
	{
		static IGmdcExporter[] exporters;

		/// <summary>
		/// Return a List of all available Exporters
		/// </summary>
		public static IGmdcExporter[] Exporters
		{
			get
			{
				if (exporters == null)
				{
					LoadExporters();
				}

				return exporters;
			}
		}

		static IGmdcImporter[] importers;

		/// <summary>
		/// Return a List of all available Importers
		/// </summary>
		public static IGmdcImporter[] Importers
		{
			get
			{
				if (importers == null)
				{
					LoadExporters();
				}

				return importers;
			}
		}

		/// <summary>
		/// Returns a list of Exporters stored in th epassed file
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		public static List<IGmdcExporter> GetExporters(string file)
		{
			List<IGmdcExporter> list = new List<IGmdcExporter>();

			object[] plugs = LoadFileWrappers.LoadPlugins(
				file,
				typeof(IGmdcExporter)
			);
			foreach (IGmdcExporter p in plugs)
			{
				list.Add(p);
			}

			return list;
		}

		/// <summary>
		/// Returns a list of Exporters stored in th epassed file
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		public static List<IGmdcImporter> GetImporters(string file)
		{
			List<IGmdcImporter> list = new List<IGmdcImporter>();

			object[] plugs = LoadFileWrappers.LoadPlugins(
				file,
				typeof(IGmdcImporter)
			);
			foreach (IGmdcImporter p in plugs)
			{
				list.Add(p);
			}

			return list;
		}

		/// <summary>
		/// Find all available Exporters in the Plugin Folder (everything with the Extension *.exporter.dll)
		/// </summary>
		static void LoadExporters()
		{
			string[] files = System.IO.Directory.GetFiles(
				Helper.SimPePluginPath,
				"*.exporter.dll"
			);

			System.Collections.ArrayList list = new System.Collections.ArrayList();
			System.Collections.ArrayList imlist = new System.Collections.ArrayList();
			foreach (string file in files)
			{
				object[] plugs = LoadFileWrappers.LoadPlugins(
					file,
					typeof(IGmdcExporter)
				);
				foreach (IGmdcExporter p in plugs)
				{
					if (p.Version == 1)
					{
						list.Add(p);
					}
				} //foreach

				plugs = LoadFileWrappers.LoadPlugins(
					file,
					typeof(IGmdcImporter)
				);
				foreach (IGmdcImporter p in plugs)
				{
					if (p.Version == 1)
					{
						imlist.Add(p);
					}
				} //foreach
			}

			exporters = new IGmdcExporter[list.Count];
			list.CopyTo(exporters);

			importers = new IGmdcImporter[imlist.Count];
			imlist.CopyTo(importers);
		}

		/// <summary>
		/// Returns null or the Exporter that can create a File with teh given Extension
		/// </summary>
		/// <param name="fileext"></param>
		/// <returns>null or an IGmdcExporter Instance</returns>
		public static IGmdcExporter FindExporterByExtension(string fileext)
		{
			int res = FindFirstIndexByExtension(fileext);
			return res == -1 ? null : Exporters[res];
		}

		/// <summary>
		/// Finds the first Exporter that registred for the passed File Extension
		/// </summary>
		/// <param name="fileext">The File Extension</param>
		/// <returns>The Index of the Exporter or -1</returns>
		public static int FindFirstIndexByExtension(string fileext)
		{
			int[] res = FindIndexByExtension(fileext);
			return res.Length == 0 ? -1 : res[0];
		}

		/// <summary>
		/// Finds the Exporter that registred for the passed File Extension
		/// </summary>
		/// <param name="fileext"></param>
		/// <returns>An Array of all Exporters that Registred for that Extension</returns>
		public static int[] FindIndexByExtension(string fileext)
		{
			fileext = fileext.Trim().ToLower();
			if (!fileext.StartsWith("."))
			{
				fileext = "." + fileext;
			}

			System.Collections.ArrayList list = new System.Collections.ArrayList();
			for (int i = 0; i < Exporters.Length; i++)
			{
				IGmdcExporter e = Exporters[i];
				if (e.FileExtension.Trim().ToLower() == fileext)
				{
					list.Add(i);
				}
			}

			int[] res = new int[list.Count];
			list.CopyTo(res);

			return res;
		}

		/// <summary>
		/// Finds the first Exporter that registred for the passed File Extension
		/// </summary>
		/// <param name="fileext">The File Extension</param>
		/// <returns>The Index of the Exporter or -1</returns>
		public static int FindFirstImporterIndexByExtension(string fileext)
		{
			int[] res = FindImporterIndexByExtension(fileext);
			return res.Length == 0 ? -1 : res[0];
		}

		/// <summary>
		/// Finds the Exporter that registred for the passed File Extension
		/// </summary>
		/// <param name="fileext"></param>
		/// <returns>An Array of all Exporters that Registred for that Extension</returns>
		public static int[] FindImporterIndexByExtension(string fileext)
		{
			fileext = fileext.Trim().ToLower();
			if (!fileext.StartsWith("."))
			{
				fileext = "." + fileext;
			}

			System.Collections.ArrayList list = new System.Collections.ArrayList();
			for (int i = 0; i < Importers.Length; i++)
			{
				IGmdcImporter e = Importers[i];
				if (e.FileExtension.Trim().ToLower() == fileext)
				{
					list.Add(i);
				}
			}

			int[] res = new int[list.Count];
			list.CopyTo(res);

			return res;
		}
	}
}
