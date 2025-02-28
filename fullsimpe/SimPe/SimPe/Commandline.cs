// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.IO;

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

		static void CheckFile(
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
					System.Windows.Forms.MessageBox.Show(
						"The "
							+ filename
							+ " file was not valid XML.\n"
							+ file
							+ "\n"
							+ "SimPe can generate a new one ("
							+ msg
							+ ").\n\nShould SimPe delete the "
							+ filename
							+ " File?",
						"Error",
						System.Windows.Forms.MessageBoxButtons.YesNo,
						System.Windows.Forms.MessageBoxIcon.Error
					) == System.Windows.Forms.DialogResult.Yes
				)
				{
					File.Delete(file);
				}
			}
		}

		public static void CheckFiles()
		{
			//check if installation for user is done
			if (
				(
					!File.Exists(Helper.DataFolder.ExpansionsXREG)
					|| !File.Exists(
						Path.Combine(Helper.SimPeDataPath, "tgi.xml")
					)
					|| Helper.WindowsRegistry.GetPreviousVersion()
						!= Helper.SimPeVersionLong
				)
				&& Helper.Profile.Length == 0
			)
			{
				if (
					!File.Exists(
						Path.Combine(Helper.SimPeDataPath, "additional_careers.xml")
					)
				)
				{
					CompleteSetup("additional_careers.xml");
				}

				if (
					!File.Exists(
						Path.Combine(Helper.SimPeDataPath, "additional_majors.xml")
					)
				)
				{
					CompleteSetup("additional_majors.xml");
				}

				if (
					!File.Exists(
						Path.Combine(Helper.SimPeDataPath, "additional_schools.xml")
					)
				)
				{
					CompleteSetup("additional_schools.xml");
				}

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
				CompleteSetup("release.nfo");
				CompleteSetup("semiglobals.xml");
				CompleteSetup("tgi.xml");
				CompleteSetup("txmtdefinition.xml");
				CompleteSetup("guidindex.txt");
				CompleteSetup("GLOBALS-AO.package");
				CompleteSetup("GLOBALS.package");
				CompleteSetup("Private.package");
				CompleteSetup("RelLabels.package");
				CompleteSetup("SemiGlobals.package");
			}

			//check if the settings File is valid
			CheckFile(
				Helper.DataFolder.SimPeXREG,
				"registry",
				"Settings",
				"your settings made in \"Extra->Preferences\" be reset"
			);

			//check if the layout File is valid
			CheckFile(
				Helper.DataFolder.Layout2XREG,
				"registry",
				"Window Layout",
				"your window layout will be reset"
			);

			//replace file table if needed
			if (Helper.WindowsRegistry.UseExpansions2 != Helper.ECCorNewSEfound)
			{
				if (
					File.Exists(Helper.DataFolder.FoldersXREGW)
					&& Helper.Profile.Length == 0
				)
				{
					File.Delete(Helper.DataFolder.FoldersXREGW);
					if (Helper.ECCorNewSEfound)
					{
						Message.Show(
							"The Newest Stuff Packs have been found,"
								+ "\r\n"
								+ "Your file table folder settings had to be reset!",
							"Warning",
							System.Windows.Forms.MessageBoxButtons.OK
						);
					}
					else
					{
						Message.Show(
							"Newest Stuff Packs are gone!"
								+ "\r\n"
								+ "Your file table folder settings had to be reset!",
							"Warning",
							System.Windows.Forms.MessageBoxButtons.OK
						);
					}
				}
				Helper.WindowsRegistry.UseExpansions2 = Helper.ECCorNewSEfound;
				Helper.WindowsRegistry.Flush();
			}
			else
			{
				//check if the file table is valid
				CheckFile(
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
			new MakeClassic(),
			new MakeModern(),
		};

		public static bool PreSplash(List<string> argv)
		{
			foreach (ICommandLine cmd in preSplashCommands)
			{
				if (cmd.Parse(argv))
				{
					return true;
				}
			}

			return false;
		}

		class Splash : ICommandLine
		{
			#region ICommandLine Members
			public bool Parse(List<string> argv)
			{
				if (
					ArgParser.Parse(argv, "--splash") >= 0
					|| ArgParser.Parse(argv, "-splash") >= 0
				)
				{
					Helper.WindowsRegistry.ShowStartupSplash = true;
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
			public bool Parse(List<string> argv)
			{
				if (
					ArgParser.Parse(argv, "--nosplash") >= 0
					|| ArgParser.Parse(argv, "-nosplash") >= 0
				)
				{
					Helper.WindowsRegistry.ShowStartupSplash = false;
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

			public bool Parse(List<string> argv)
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
						Message.Show(Help()[0]);
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
								Message.Show(Help()[0]);
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

					Message.Show(
						s,
						"Notice",
						System.Windows.Forms.MessageBoxButtons.OK
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
			public bool Parse(List<string> argv)
			{
				int index = ArgParser.Parse(argv, "-profile");
				if (index < 0)
				{
					return false;
				}

				if (index >= argv.Count || argv[index].Length == 0)
				{
					Message.Show(Help()[0]);
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
					Helper.WindowsRegistry.Reload();
					Helper.WindowsRegistry.ReloadLayout();
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

		#region Theme Presets
		public static void ForceModernLayout()
		{
			Overridelayout("modern_layout.xreg");

			Helper.WindowsRegistry.Layout.SelectedTheme = 2;
			Helper.WindowsRegistry.AsynchronLoad = false;
			Helper.WindowsRegistry.DecodeFilenamesState = true;
			Helper.WindowsRegistry.DeepSimScan = true;
			Helper.WindowsRegistry.DeepSimTemplateScan = false;
			Helper.WindowsRegistry.HiddenMode = false;
			Helper.WindowsRegistry.SimpleResourceSelect = true;
			Helper.WindowsRegistry.MultipleFiles = true;
			Helper.WindowsRegistry.FirefoxTabbing = true;
			Helper.WindowsRegistry.ShowStartupSplash = true;
			Helper.WindowsRegistry.Layout.IsClassicPreset = false;
			Helper.WindowsRegistry.LockDocks = false;
			Helper.WindowsRegistry.ShowWaitBarPermanent = true;
			Helper.WindowsRegistry.UseBigIcons = false;
			Helper.WindowsRegistry.LoadOnlySimsStory = 0;
			Helper.WindowsRegistry.Flush();
		}

		public static void ForceDefaultLayout()
		{
			Overridelayout("original_layout.xreg");

			Helper.WindowsRegistry.Layout.IsClassicPreset = false;
			Helper.WindowsRegistry.Layout.SelectedTheme = 1;
			Helper.WindowsRegistry.Layout.AutoStoreLayout = true;
			Helper.WindowsRegistry.AsynchronLoad = false;
			Helper.WindowsRegistry.DecodeFilenamesState = true;
			Helper.WindowsRegistry.DeepSimScan = true;
			Helper.WindowsRegistry.DeepSimTemplateScan = false;
			Helper.WindowsRegistry.HiddenMode = false;
			Helper.WindowsRegistry.LoadOWFast = false;
			Helper.WindowsRegistry.ShowStartupSplash = true;
			Helper.WindowsRegistry.SimpleResourceSelect = true;
			Helper.WindowsRegistry.MultipleFiles = true;
			Helper.WindowsRegistry.FirefoxTabbing = true;
			Helper.WindowsRegistry.LockDocks = false;
			Helper.WindowsRegistry.ShowWaitBarPermanent = true;
			Helper.WindowsRegistry.WaitingScreen = true;
			Helper.WindowsRegistry.UseBigIcons = false;
			Helper.WindowsRegistry.LoadOnlySimsStory = 0;
			Helper.WindowsRegistry.Flush();
		}

		static void Overridelayout(string name)
		{
			Stream s = typeof(Commandline).Assembly.GetManifestResourceStream(
				"SimPe.data." + name
			);
			if (s != null)
			{
				try
				{
					StreamWriter sw = File.CreateText(
						Helper.DataFolder.Layout2XREGW
					);
					sw.BaseStream.SetLength(0);
					try
					{
						StreamReader sr = new StreamReader(s);
						sw.Write(sr.ReadToEnd());
						sw.Flush();
					}
					finally
					{
						sw.Close();
						sw.Dispose();
						sw = null;
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(ex);
				}
			}

			string name2 = name.Replace("_layout.xreg", ".layout");
			s = typeof(Commandline).Assembly.GetManifestResourceStream(
				"SimPe.data." + name2
			);
			if (s != null)
			{
				try
				{
					FileStream fs = File.OpenWrite(
						Helper.DataFolder.SimPeLayoutW
					);
					BinaryWriter sw = new BinaryWriter(fs);
					sw.BaseStream.SetLength(0);
					try
					{
						BinaryReader sr = new BinaryReader(s);
						sw.Write(sr.ReadBytes((int)sr.BaseStream.Length));
						sw.Flush();
					}
					finally
					{
						sw.Close();
						sw = null;
						fs.Close();
						fs.Dispose();
						fs = null;
						s.Close();
						s.Dispose();
						s = null;
					}

					Helper.WindowsRegistry.ReloadLayout();
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(ex);
				}
			}
		}

		#endregion

		class MakeClassic : ICommandLine
		{
			#region ICommandLine Members
			public bool Parse(List<string> argv)
			{
				if (ArgParser.Parse(argv, "-classicpreset") < 0)
				{
					return false;
				}

				Overridelayout("classic_layout.xreg");

				Helper.WindowsRegistry.Layout.SelectedTheme = 0;
				Helper.WindowsRegistry.Layout.AutoStoreLayout = true;
				Helper.WindowsRegistry.AsynchronLoad = false;
				Helper.WindowsRegistry.DecodeFilenamesState = false;
				Helper.WindowsRegistry.DeepSimScan = false;
				Helper.WindowsRegistry.DeepSimTemplateScan = false;
				Helper.WindowsRegistry.SimpleResourceSelect = true;
				Helper.WindowsRegistry.MultipleFiles = false;
				Helper.WindowsRegistry.FirefoxTabbing = false;
				Helper.WindowsRegistry.ShowWaitBarPermanent = false;
				Helper.WindowsRegistry.Layout.IsClassicPreset = true;
				Helper.WindowsRegistry.ShowStartupSplash = true;
				Helper.WindowsRegistry.WaitingScreen = true;
				Helper.WindowsRegistry.LockDocks = true;
				Helper.WindowsRegistry.UseBigIcons = false;
				Helper.WindowsRegistry.LoadOnlySimsStory = 0;
				Helper.WindowsRegistry.Flush();

				System.Windows.Forms.DialogResult dr = Message.Show(

						Localization.GetString("PresetChanged")
						.Replace(
							"{name}",
							Localization.GetString("PresetClassic")
						),
					Localization.GetString("Information"),
					System.Windows.Forms.MessageBoxButtons.YesNo
				);
				return dr != System.Windows.Forms.DialogResult.Yes;
			}

			public string[] Help()
			{
				return new string[] { "-classicpreset", null };
			}
			#endregion
		}

		class MakeModern : ICommandLine
		{
			#region ICommandLine Members
			public bool Parse(List<string> argv)
			{
				if (ArgParser.Parse(argv, "-modernpreset") < 0)
				{
					return false;
				}

				ForceModernLayout();

				System.Windows.Forms.DialogResult dr = Message.Show(

						Localization.GetString("PresetChanged")
						.Replace(
							"{name}",
							Localization.GetString("PresetModern")
						),
					Localization.GetString("Information"),
					System.Windows.Forms.MessageBoxButtons.YesNo
				);
				return dr != System.Windows.Forms.DialogResult.Yes;
			}

			public string[] Help()
			{
				return new string[] { "-modernpreset", null };
			}
			#endregion
		}

		/// <summary>
		/// Loaded just befor the GUI is started
		/// </summary>
		/// <param name="args"></param>
		/// <returns>true if the GUI should <b>NOT</b> show up</returns>
		public static bool FullEnvStart(List<string> argv)
		{
			if (argv.Count < 1)
			{
				return false;
			}

			try
			{
				SimPe.Splash.Screen.SetMessage(
					Localization.GetString("Checking commandline parameters")
				);
				foreach (
					ICommandLine cmdline in
						FileTable
						.CommandLineRegistry
						.CommandLines
				)
				{
					if (cmdline.Parse(argv))
					{
						return true;
					}
				}

				return false;
			}
			finally
			{
				SimPe.Splash.Screen.SetMessage(
					Localization.GetString("Checked commandline parameters")
				);
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
				"SimPe.data." + namer
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
		public bool Parse(List<string> argv)
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

			Splash.Screen.Stop();

			// System.Windows.Forms.MessageBox.Show(""
			Message.Show(
				"" + "  -load filename" + pluginHelp + "\r\n",
				"SimPe Commandline Parameters",
				System.Windows.Forms.MessageBoxButtons.OK
			// , System.Windows.Forms.MessageBoxIcon.Information
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
