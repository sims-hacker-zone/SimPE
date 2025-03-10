// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.ComponentModel;

using SimPe.Forms.MainUI;

namespace SimPe
{
	/// <summary>
	/// This is used to display Paths in the Options Dialog
	/// </summary>
	public class PathSettings : GlobalizedObject
	{
		Registry r;
		static PathSettings ps;
		public static PathSettings Global
		{
			get
			{
				if (ps == null)
				{
					ps = CreateInstance();
				}
				return ps;
			}
		}

		static PathSettings CreateInstance()
		{
			string src = "using System;\n";
			src += "using System.ComponentModel;\n";
			src += "namespace SimPe{\n";
			src += "public class RuntimePathSettings : PathSettings { \n";
			src += "\tpublic RuntimePathSettings() : base(Helper.WindowsRegistry){\n";
			src += "\t}\n\n\n";

			foreach (ExpansionItem ei in PathProvider.Global.Expansions)
			{
				src +=
					"\t[Category(\""
					+ ei.Flag.Class
					+ "\"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),\n";
				src +=
					"\tDescription(\""
					+
						Localization.GetString("[Description:]")
						.Replace("{LongName}", ei.Name)
						.Trim()
						.Replace(Helper.lbr, "\\n")
					+ "\"), ";
				src +=
					"DisplayName(\""
					+ ei.NameSortNumber
					+ ": "
					+ ei.NameShorter
					+ "\")]\n";
				src += "\tpublic string " + ei.ShortId + "Path\n";
				src += "\t{\n";
				src += "\t\tget {\n";
				src +=
					"\t\t\treturn GetPath(PathProvider.Global.GetExpansion("
					+ ei.Version
					+ "));\n";
				src += "\t\t}\n";
				src +=
					"\t\tset {PathProvider.Global.GetExpansion("
					+ ei.Version
					+ ").InstallFolder = value;}\n";
				src += "\t}\n\n";
			}

			src += "}}\n";

			try
			{
				System.Reflection.Assembly a = RuntimeCompiler.Compile(
					src,
					new string[]
					{
						System.IO.Path.Combine(Helper.SimPePath, "SimPe.exe"),
						"system.drawing.dll",
					}
				);
				return (PathSettings)
					RuntimeCompiler.CreateInstance(
						a,
						"SimPe.RuntimePathSettings",
						new object[0]
					);
			}
			catch (Exception ex)
			{
				if (Helper.WindowsRegistry.Config.HiddenMode || Helper.QARelease)
				{
					System.IO.StreamWriter sw = new System.IO.StreamWriter(
						System.IO.Path.Combine(
							Helper.SimPeDataPath,
							"RuntimePathSettings.cs"
						)
					);
					sw.Write(src);
					sw.Close();
					sw.Dispose();
					sw = null;
					Helper.ExceptionMessage(ex);
				}
				return null;
			}
		}

		protected PathSettings(Registry r)
		{
			this.r = r;
		}

		protected string GetPath(ExpansionItem ei)
		{
			return ei.InstallFolder == null ? ei.RealInstallFolder : ei.InstallFolder.Trim() == "" ? ei.RealInstallFolder : ei.InstallFolder;
		}

		protected string GetPath(string userpath, string defpath)
		{
			if (userpath == null)
			{
				userpath = "";
			}

			return userpath.Trim() == "" ? defpath : userpath;
		}

		[
			Category("BaseGame"),
			Editor(
				typeof(SelectSimFolderUITypeEditor),
				typeof(System.Drawing.Design.UITypeEditor)
			)
		]
		public string SaveGamePath
		{
			get => GetPath(
					PathProvider.SimSavegameFolder,
					PathProvider.RealSavegamePath
				);
			set => PathProvider.SimSavegameFolder = value;
		}
	}
}
