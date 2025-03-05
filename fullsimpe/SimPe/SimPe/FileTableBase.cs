// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

using SimPe.Interfaces.Wrapper;

namespace SimPe
{
	/// <summary>
	/// Do not use this class direct, use <see cref="FileTable"/> instead!
	/// </summary>
	public class FileTableBase
	{
		/// <summary>
		/// Returns the FileIndex
		/// </summary>
		/// <remarks>This will be initialized by the RCOL Factory</remarks>
		public static Interfaces.Scenegraph.IScenegraphFileIndex FileIndex
		{
			get; set;
		}

		private static List<FileTableItem> defaultFolders;

		/// <summary>
		/// Returns a List of all Folders, even those the User doesn't want to scan for Content
		/// </summary>
		public static List<FileTableItem> DefaultFolders
		{
			get
			{
				if (defaultFolders == null)
				{
					string filename = Helper.DataFolder.FoldersXREG;
					if (!System.IO.File.Exists(filename))
					{
						BuildFolderXml();
						filename = Helper.DataFolder.FoldersXREGW;
					} // as that's what we just wrote

					Dictionary<string, ExpansionItem> shortmap =
						new Dictionary<string, ExpansionItem>();
					foreach (ExpansionItem ei in PathProvider.Global.Expansions)
					{
						shortmap[ei.ShortId.ToLower()] = ei;
					}

					XElement doc = XElement.Load(filename);

					List<FileTableItem> list = new List<FileTableItem>();

					foreach (XElement el in doc.Element("filetable").Elements())
					{
						FileTableItemType ftitype = FileTablePaths.Absolute;
						XAttribute root = el.Attribute("root");
						if (root != null)
						{
							switch ((string)root)
							{
								case "save":
									ftitype = FileTablePaths.SaveGameFolder;
									break;
								case "simpe":
									ftitype = FileTablePaths.SimPEFolder;
									break;
								case "simpedata":
									ftitype = FileTablePaths.SimPEDataFolder;
									break;
								case "simpeplugin":
									ftitype = FileTablePaths.SimPEPluginFolder;
									break;
								default:
									if (shortmap.ContainsKey((string)root))
									{
										ftitype = shortmap[(string)root].Expansion;
									}
									break;
							}
						}
						XAttribute version = el.Attribute("version");
						int ftiver = version != null ? (int)version : -1;
						XAttribute ignore = el.Attribute("ignore");
						bool ftiignore = ignore != null && (int)ignore == 1;
						XAttribute recursive = el.Attribute("recursive");
						bool ftirec = recursive != null && (int)recursive == 1;
						if (el.Name == "file")
						{
							list.Add(new FileTableItem(
									el.Value,
									ftitype,
									false,
									true,
									ftiver,
									ftiignore
								));
						}
						else
						{
							list.Add(new FileTableItem(
									el.Value,
									ftitype,
									ftirec,
									false,
									ftiver,
									ftiignore
								));
						}
					}
					defaultFolders = list;
				}
				return defaultFolders;
			}
		}

		/// <summary>
		/// Creates a default Folder xml
		/// </summary>
		public static void BuildFolderXml()
		{
			try
			{
				XmlWriterSettings xws = new XmlWriterSettings
				{
					CloseOutput = true,
					Indent = true,
					Encoding = System.Text.Encoding.UTF8
				};
				XmlWriter xw = XmlWriter.Create(Helper.DataFolder.FoldersXREGW, xws);

				try
				{
					xw.WriteStartElement("folders");
					xw.WriteStartElement("filetable");
					if (PathProvider.Global.GameVersion < 18)
					{
						xw.WriteStartElement("file");
						xw.WriteAttributeString("root", "save");
						xw.WriteAttributeString("ignore", "1");
						xw.WriteValue(
							"Downloads"
								+ Helper.PATH_SEP
								+ "_EnableColorOptionsGMND.package"
						);
						xw.WriteEndElement();

						xw.WriteStartElement("file");
						xw.WriteAttributeString("root", "game");
						xw.WriteAttributeString("ignore", "1");
						xw.WriteValue(
							"TSData"
								+ Helper.PATH_SEP
								+ "Res"
								+ Helper.PATH_SEP
								+ "Sims3D"
								+ Helper.PATH_SEP
								+ "_EnableColorOptionsMMAT.package"
						);
						xw.WriteEndElement();

						xw.WriteStartElement("path");
						xw.WriteAttributeString("root", "save");
						xw.WriteAttributeString("recursive", "1");
						xw.WriteAttributeString("ignore", "1");
						xw.WriteValue("zCEP-EXTRA");
						xw.WriteEndElement();

						xw.WriteStartElement("path");
						xw.WriteAttributeString("root", "game");
						xw.WriteAttributeString("recursive", "1");
						xw.WriteAttributeString("ignore", "1");
						xw.WriteValue(
							"TSData"
								+ Helper.PATH_SEP
								+ "Res"
								+ Helper.PATH_SEP
								+ "Catalog"
								+ Helper.PATH_SEP
								+ "zCEP-EXTRA"
						);
						xw.WriteEndElement();
					}

					for (int i = PathProvider.Global.Expansions.Count - 1; i >= 0; i--)
					{
						ExpansionItem ei = PathProvider.Global.Expansions[i];
						string s = ei.ShortId.ToLower();
						{
							foreach (string folder in ei.PreObjectFileTableFolders)
							{
								writenode(xw, shouldignor(ei, folder), s, null, folder);
							}

							if (
								ei.Flag.Class == ExpansionItem.Classes.Story
								|| !ei.Flag.FullObjectsPackage
							)
							{
								writenode(
									xw,
									shouldignor(ei, ei.ObjectsSubFolder),
									s,
									null,
									ei.ObjectsSubFolder
								);
							}
							else
							{
								writenode(
									xw,
									shouldignor(ei, ei.ObjectsSubFolder),
									s,
									ei.Version.ToString(),
									ei.ObjectsSubFolder
								);
							}

							foreach (string folder in ei.FileTableFolders)
							{
								writenode(xw, shouldignor(ei, folder), s, null, folder);
							}
						}
					}

					xw.WriteEndElement();
					xw.WriteEndElement();
				}
				finally
				{
					xw.Close();
					xw = null;
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("Unable to create default Folder File!", ex);
			}
		}

		private static bool shouldignor(ExpansionItem ei, string folder)
		{
			return (PathProvider.Global.GameVersion < 21 && ei.Flag.SimStory)
				|| (!ei.Exists && ei.InstallFolder == "")
|| ((ei.Version != PathProvider.Global.GameVersion
				|| (!folder.EndsWith("\\Objects")
					&& !folder.EndsWith("\\Overrides")
					&& !folder.EndsWith("\\UI")
					&& !folder.EndsWith("\\Wants")))
					&& !folder.EndsWith("\\3D")
				&& !folder.EndsWith("\\Sims3D")
				&& !folder.EndsWith("\\Stuffpack\\Objects")
				&& !folder.EndsWith("\\Materials"));
		}

		/// <summary>
		/// Write folders.xreg
		/// </summary>
		/// <param name="lfti">A <typeparamref name="List&lt;&gt;"/> of <typeparamref name="FileTableItem"/> entries</param>
		public static void StoreFoldersXml(List<FileTableItem> lfti)
		{
			try
			{
				XmlWriterSettings xws = new XmlWriterSettings
				{
					CloseOutput = true,
					Indent = true,
					Encoding = System.Text.Encoding.UTF8
				};
				XmlWriter xw = XmlWriter.Create(Helper.DataFolder.FoldersXREGW, xws);

				try
				{
					xw.WriteStartElement("folders");
					xw.WriteStartElement("filetable");
					foreach (FileTableItem fti in lfti)
					{
						xw.WriteStartElement(fti.IsFile ? "file" : "path");

						if (fti.Type != FileTablePaths.Absolute)
						{
							bool ok = false;
							foreach (ExpansionItem ei in PathProvider.Global.Expansions)
							{
								if (fti.Type == ei.Expansion)
								{
									xw.WriteAttributeString(
										"root",
										ei.ShortId.ToLower()
									);
									ok = true;
									break;
								}
							}
							if (!ok)
							{
								switch (fti.Type.AsUint)
								{
									case (uint)FileTablePaths.SaveGameFolder:
									{
										xw.WriteAttributeString("root", "save");
										break;
									}
									case (uint)FileTablePaths.SimPEFolder:
									{
										xw.WriteAttributeString("root", "simpe");
										break;
									}
									case (uint)FileTablePaths.SimPEDataFolder:
									{
										xw.WriteAttributeString("root", "simpeData");
										break;
									}
									case (uint)FileTablePaths.SimPEPluginFolder:
									{
										xw.WriteAttributeString("root", "simpePlugin");
										break;
									}
								} //switch
							}
						}

						if (fti.IsRecursive)
						{
							xw.WriteAttributeString("recursive", "1");
						}

						if (fti.EpVersion >= 0)
						{
							xw.WriteAttributeString(
								"version",
								fti.EpVersion.ToString()
							);
						}

						if (fti.Ignore)
						{
							xw.WriteAttributeString("ignore", "1");
						}

						xw.WriteValue(fti.RelativePath);
						xw.WriteEndElement();
					}
					xw.WriteEndElement();
					xw.WriteEndElement();
				}
				finally
				{
					xw.Close();
					xw = null;
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private static void writenode(
			XmlWriter xw,
			bool ign,
			string root,
			string version,
			string folder
		)
		{
			xw.WriteStartElement("path");
			if (ign)
			{
				xw.WriteAttributeString("ignore", "1");
			}

			xw.WriteAttributeString("root", root);
			if (version != null)
			{
				xw.WriteAttributeString("version", version);
			}

			xw.WriteValue(folder);
			xw.WriteEndElement();
		}

		/// <summary>
		/// Returns/Sets a WrapperRegistry (can be null)
		/// </summary>
		public static Interfaces.IWrapperRegistry WrapperRegistry
		{
			get; set;
		}

		/// <summary>
		/// Returns/Sets a ProviderRegistry (can be null)
		/// </summary>
		public static Interfaces.IProviderRegistry ProviderRegistry
		{
			get; set;
		}

		/// <summary>
		/// Returns The Group Cache used to determin local Groups
		/// </summary>
		public static IGroupCache GroupCache
		{
			get; set;
		}
	}
}
