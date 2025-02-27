using System;

using SimPe.Interfaces.Plugin.Scanner;

namespace SimPe.Plugin.Scanner
{
	/// <summary>
	/// This is a Registry , that contains all available Scanners and Identifiers
	/// </summary>
	public class ScannerRegistry
	{
		static ScannerRegistry glob;
		public static ScannerRegistry Global
		{
			get
			{
				if (glob == null)
					glob = new ScannerRegistry();
				return glob;
			}
		}

		ScannerRegistry()
		{
			Scanners = new ScannerCollection();
			Identifiers = new ScannerCollection();
			LoadScanners();
		}

		/// <summary>
		/// Load all available Scanners in the plugins Folder (everything with the Extension *.plugin.dll)
		/// </summary>
		void LoadScanners()
		{
			CreateIgnoreList();
			string[] files = System.IO.Directory.GetFiles(
				Helper.SimPePluginPath,
				"*.plugin.dll"
			);
			Scanners.Clear();
			foreach (string file in files)
			{
				if (ignore.Contains(System.IO.Path.GetFileName(file).ToLower()))
					continue;
				object[] args = new object[0];
				object[] scnrs = SimPe.LoadFileWrappers.LoadPlugins(
					file,
					typeof(SimPe.Interfaces.Plugin.Scanner.IScannerPluginBase),
					args
				);
				foreach (IScannerPluginBase isb in scnrs)
				{
					if (isb.Version == 1)
					{
						if (
							((byte)isb.PluginType & (byte)ScannerPluginType.Scanner)
							!= 0
						)
						{
							try
							{
								IScanner sc = (IScanner)isb;
								Scanners.Add(sc);
							}
							catch (Exception ex)
							{
								Helper.ExceptionMessage("Unable to load Scanner.", ex);
							}
						}
						else
						{
							try
							{
								IIdentifier i = (IIdentifier)isb;
								Identifiers.Add(i);
							}
							catch (Exception ex)
							{
								Helper.ExceptionMessage(
									"Unable to load Identifier.",
									ex
								);
							}
						}
					}
				}
			}

			Scanners.Sort(new SimPe.Plugin.Identifiers.PluginScannerBaseComparer());
			Identifiers.Sort(new SimPe.Plugin.Identifiers.PluginScannerBaseComparer());
		}

		//this is a manual List of Wrappers that are known to cause Problems
		System.Collections.ArrayList ignore;

		void CreateIgnoreList()
		{
			ignore = new System.Collections.ArrayList();
			ignore.Add("simpe.3d.plugin.dll");
			ignore.Add("pjse.filetable.plugin.dll");
			ignore.Add("pjse.guidtool.plugin.dll");
			ignore.Add("pjse.coder.plugin.dll");
			ignore.Add("simpe.actiondeletesim.plugin.dll");
			ignore.Add("theos.simsurgery.plugin.dll");
			ignore.Add("theo.meshscanner.plugin.dll");
			ignore.Add("simpe.ngbh.plugin.dll");
		}

		public ScannerCollection Scanners
		{
			get;
		}

		public ScannerCollection Identifiers
		{
			get;
		}
	}
}
