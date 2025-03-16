// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using SimPe.Forms.MainUI;
using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;

namespace SimPe
{
	/// <summary>
	/// This class handles the Comandline Arguments of SimPe
	/// </summary>
	public class Commandline
	{
		#region Import Data
		static void CheckXML(string file, string elementName)
		{
			if (File.Exists(file))
			{
				System.Xml.XmlDocument xmlfile = new System.Xml.XmlDocument();
				xmlfile.Load(file);
				System.Xml.XmlNodeList XMLData = xmlfile.GetElementsByTagName(
					elementName
				);
			}
		}

		static async Task CheckFile(
			string file,
			string elementName,
			string filename,
			string msg
		)
		{
			if (Helper.Profile.Length > 0)
			{
				msg += " and you will need to re-save profile " + Helper.Profile;
			}

			try
			{
				CheckXML(file, elementName);
			}
			catch
			{
				if (
					await MsBox.Avalonia.MessageBoxManager.GetMessageBoxStandard("Error", "The "
							+ filename
							+ " file was not valid XML.\n"
							+ file
							+ "\n"
							+ "SimPe can generate a new one ("
							+ msg
							+ ").\n\nShould SimPe delete the "
							+ filename
							+ " File?",
							MsBox.Avalonia.Enums.ButtonEnum.YesNo,
							MsBox.Avalonia.Enums.Icon.Error).ShowAsync()
							== MsBox.Avalonia.Enums.ButtonResult.Yes
				)
				{
					File.Delete(file);
				}
			}
		}

		public static async Task CheckFiles()
		{
			//check if installation for user is done
			if (
				(
					!File.Exists(Helper.DataFolder.ExpansionsXREG)
					|| Helper.WindowsRegistry.PreviousVersion
						!= Helper.SimPeVersionLong
				)
				&& Helper.Profile.Length == 0
			)
			{
				if (
					File.Exists(
						Path.Combine(Helper.SimPeDataPath, "vport.set")
					)
				)
				{
					File.Delete(
						Path.Combine(Helper.SimPeDataPath, "vport.set")
					);
				}

				CompleteSetup("beauty");
				CompleteSetup("expansions.xreg");
				CompleteSetup("expansions2.xreg");
				CompleteSetup("objddefinition.xml");
				CompleteSetup("txmtdefinition.xml");
				CompleteSetup("guidindex.txt");
				CompleteSetup("GLOBALS-AO.package");
				CompleteSetup("GLOBALS.package");
				CompleteSetup("Private.package");
				CompleteSetup("RelLabels.package");
				CompleteSetup("SemiGlobals.package");
			}

			//replace file table if needed
			if (Helper.WindowsRegistry.Config.UseExpansions2 != Helper.ECCorNewSEfound)
			{
				if (
					File.Exists(Helper.DataFolder.FoldersXREGW)
					&& Helper.Profile.Length == 0
				)
				{
					File.Delete(Helper.DataFolder.FoldersXREGW);
					if (Helper.ECCorNewSEfound)
					{
						await MsBox.Avalonia.MessageBoxManager.GetMessageBoxStandard("Warning", "The Newest Stuff Packs have been found,"
								+ "\r\n"
								+ "Your file table folder settings had to be reset!").ShowAsync();
					}
					else
					{
						await MsBox.Avalonia.MessageBoxManager.GetMessageBoxStandard("Warning", "Newest Stuff Packs are gone!"
								+ "\r\n"
								+ "Your file table folder settings had to be reset!").ShowAsync();
					}
				}
				Helper.WindowsRegistry.Config.UseExpansions2 = Helper.ECCorNewSEfound;
				Helper.WindowsRegistry.Flush();
			}
			else
			{
				//check if the file table is valid
				await CheckFile(
					Helper.DataFolder.FoldersXREG,
					"folders",
					"File table settings",
					"your file table folder settings will be reset"
				);
			}
		}
		#endregion

		internal static ICommandLine[] preSplashCommands = new ICommandLine[]
		{
			new Profile(),
			new Splash(),
			new NoSplash(),
			new EnableFlags(),
		};

		public static async Task<bool> PreSplash(List<string> argv)
		{
			foreach (ICommandLine cmd in preSplashCommands)
			{
				if (await cmd.Parse(argv))
				{
					return true;
				}
			}

			return false;
		}

		class Splash : ICommandLine
		{
			#region ICommandLine Members
			public async Task<bool> Parse(List<string> argv)
			{
				if (
					ArgParser.Parse(argv, "--splash") >= 0
					|| ArgParser.Parse(argv, "-splash") >= 0
				)
				{
					Helper.WindowsRegistry.Config.ShowStartupSplash = true;
				}

				return false;
			}

			public string[] Help()
			{
				return new string[] { "-splash", null };
			}
			#endregion
		}

		class NoSplash : ICommandLine
		{
			#region ICommandLine Members
			public async Task<bool> Parse(List<string> argv)
			{
				if (
					ArgParser.Parse(argv, "--nosplash") >= 0
					|| ArgParser.Parse(argv, "-nosplash") >= 0
				)
				{
					Helper.WindowsRegistry.Config.ShowStartupSplash = false;
				}

				return false;
			}

			public string[] Help()
			{
				return new string[] { "-nosplash\r\n", null };
			}
			#endregion
		}

		class EnableFlags : ICommandLine
		{
			#region ICommandLine Members

			public async Task<bool> Parse(List<string> argv)
			{
				int i = ArgParser.Parse(argv, "-localmode");
				if (i >= 0)
				{
					argv.InsertRange(i, new string[] { "-enable", "localmode" });
				}
				i = ArgParser.Parse(argv, "-noplugins");
				if (i >= 0)
				{
					argv.InsertRange(i, new string[] { "-enable", "noplugins" });
				}

				bool haveEnable = false;
				bool needEnable = true;
				i = ArgParser.Parse(argv, "-enable");
				if (i >= 0)
				{
					haveEnable = true;
					needEnable = false;
				}
				else
				{
					return false;
				}

				List<string> flags = new List<string>(
					new string[]
					{
						"localmode",
						"noplugins",
						"fileformat",
						"noerrors",
						"anypackage",
					}
				);
				while (!needEnable)
				{
					if (argv.Count <= i)
					{
						await Message.Show(Help()[0]);
						return true;
					} // -enable {nothing}
					switch (ArgParser.Parse(argv, i, flags))
					{
						case 0:
							Helper.LocalMode = true;
							haveEnable = false;
							break;
						case 1:
							Helper.NoPlugins = true;
							haveEnable = false;
							break;
						case 2:
							Helper.FileFormat = true;
							haveEnable = false;
							break;
						case 3:
							Helper.NoErrors = true;
							haveEnable = false;
							break;
						case 4:
							Helper.AnyPackage = true;
							haveEnable = false;
							break;
						default:
							if (haveEnable)
							{
								await Message.Show(Help()[0]);
								return true;
							} // -enable {unknown}
							else
							{
								needEnable = true;
								break;
							} // done one lot of -enables
					}
					if (needEnable)
					{
						i = ArgParser.Parse(argv, "-enable");
						if (i >= 0)
						{
							haveEnable = true;
							needEnable = false;
						}
					}
					if (!haveEnable && argv.Count <= i)
					{
						break; // processed everything
					}
				}

				if (
					(Helper.LocalMode || Helper.NoPlugins || Helper.NoErrors)
					&& Helper.StartedGui != Executable.Other
				)
				{
					string s = "";
					if (Helper.LocalMode)
					{
						s += Localization.GetString("InLocalMode") + "\r\n";
					}

					if (Helper.NoPlugins)
					{
						s += "\r\n" + Localization.GetString("NoPlugins") + "\r\n";
					}

					if (Helper.NoErrors)
					{
						s += "\r\n" + Localization.GetString("NoErrors");
					}

					await Message.Show(
						s,
						"Notice",
						MsBox.Avalonia.Enums.ButtonEnum.Ok
					);
				}

				return false; // Don't exit SimPe!
			}

			public string[] Help()
			{
				return new string[]
				{
					"-enable localmode  -enable noplugins  -enable fileformat"
						+ "\r\n"
						+ "-enable noerrors  -enable anypackage\r\n",
					null,
				};
			}

			#endregion
		}

		class Profile : ICommandLine
		{
			#region ICommandLine Members
			public async Task<bool> Parse(List<string> argv)
			{
				int index = ArgParser.Parse(argv, "-profile");
				if (index < 0)
				{
					return false;
				}

				if (index >= argv.Count || argv[index].Length == 0)
				{
					await Message.Show(Help()[0]);
					return true;
				}
				if (
					Directory.Exists(
						Path.Combine(
							Path.Combine(Helper.SimPeDataPath, "Profiles"),
							argv[index]
						)
					)
				)
				{
					Helper.Profile = argv[index];
					// if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(Helper.DataFolder.SimPeXREG))) { Message.Show(Help()[0]); return true; }
					if (Helper.Profile == "Short")
					{
						Helper.LocalMode = true;
						Helper.NoPlugins = true;
					}
				}
				argv.RemoveAt(index);
				return false;
			}

			public string[] Help()
			{
				return new string[] { "-profile savedprofilename\r\n", null };
			}
			#endregion
		}

		/// <summary>
		/// Loaded just befor the GUI is started
		/// </summary>
		/// <param name="args"></param>
		/// <returns>true if the GUI should <b>NOT</b> show up</returns>
		public static async Task<bool> FullEnvStart(List<string> argv)
		{
			if (argv.Count < 1)
			{
				return false;
			}

			try
			{
				foreach (
					ICommandLine cmdline in
						FileTable
						.CommandLineRegistry
						.CommandLines
				)
				{
					if (await cmdline.Parse(argv))
					{
						return true;
					}
				}

				return false;
			}
			finally
			{
			}
		}

		public static void CompleteSetup(string namer)
		{
			try
			{
				if (
					!Directory.Exists(
						Path.Combine(Helper.SimPePluginDataPath, "pjse.coder.plugin")
					)
				)
				{
					Directory.CreateDirectory(
						Path.Combine(Helper.SimPePluginDataPath, "pjse.coder.plugin")
					);
					Directory.CreateDirectory(
						Path.Combine(
							Helper.SimPePluginDataPath,
							"pjse.coder.plugin\\Includes"
						)
					);
				}
			}
			catch { }

			string path;
			Stream s = typeof(Commandline).Assembly.GetManifestResourceStream(
				"SimPe.files." + namer
			);
			path = namer == "guidindex.txt"
				? Path.Combine(
					Helper.SimPePluginDataPath,
					"pjse.coder.plugin\\guidindex.txt"
				)
				: namer.Contains(".package")
					? Path.Combine(
									Path.Combine(
										Helper.SimPePluginDataPath,
										"pjse.coder.plugin\\Includes"
									),
									namer
								)
					: Path.Combine(Helper.SimPeDataPath, namer);

			if (s != null)
			{
				try
				{
					BinaryReader br = new BinaryReader(s);
					try
					{
						FileStream fs = File.Create(path);
						BinaryWriter bw = new BinaryWriter(fs);
						try
						{
							bw.Write(br.ReadBytes((int)br.BaseStream.Length));
						}
						finally
						{
							bw.Close();
							bw = null;
							fs.Close();
							fs.Dispose();
							fs = null;
						}
					}
					finally
					{
						br.Close();
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(ex);
				}
			}
		}
	}

	public class CommandlineHelp : ICommandLine
	{
		#region ICommandLine Members
		public async Task<bool> Parse(List<string> argv)
		{
			if (ArgParser.Parse(argv, "-help") < 0)
			{
				return false;
			}

			string pluginHelp = "";
			foreach (ICommandLine cmdline in Commandline.preSplashCommands)
			{
				string[] help = cmdline.Help();
				pluginHelp += "\r\n" + "  " + help[0];
				if (help[1] != null && help[1].Length > 0)
				{
					pluginHelp += "\r\n" + "      " + help[1];
				}
			}
			foreach (
				ICommandLine cmdline in FileTable.CommandLineRegistry.CommandLines
			)
			{
				string[] help = cmdline.Help();
				pluginHelp += "\r\n" + "  " + help[0];
				if (help[1] != null && help[1].Length > 0)
				{
					pluginHelp += "\r\n" + "      " + help[1];
				}
			}

			await Message.Show(
				"" + "  -load filename" + pluginHelp + "\r\n",
				"SimPe Commandline Parameters",
				MsBox.Avalonia.Enums.ButtonEnum.Ok
			);

			return true;
		}

		public string[] Help()
		{
			return new string[] { "\r\n  -help\r\n", null };
		}
		#endregion
	}

	public class CommandlineHelpFactory : AbstractWrapperFactory, ICommandLineFactory
	{
		#region ICommandLineFactory Members

		public ICommandLine[] KnownCommandLines => new ICommandLine[] { new CommandlineHelp() };

		#endregion
	}
}
