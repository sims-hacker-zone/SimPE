// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using SimPe.Data;

namespace SimPe
{
	/// <summary>
	/// just a Little class with a shorter ToString output
	/// </summary>
	public class ToolLoaderListBoxItemExt : ToolLoaderItemExt
	{
		public ToolLoaderListBoxItemExt(ToolLoaderItemExt tli)
			: base(tli.Name)
		{
			name = tli.Name;
			filename = tli.FileName;
			arguments = tli.Attributes;
			type = tli.Type;
		}

		public override string ToString()
		{
			return Name;
		}
	}

	/// <summary>
	/// This class contains all Information neede for one ExternalTool
	/// </summary>
	public class ToolLoaderItemExt
	{
		/// <summary>
		/// Creates a new Instance
		/// </summary>
		/// <param name="name">Name of this Tool</param>
		public ToolLoaderItemExt(string name)
		{
			this.name = name;
			filename = "";
			arguments = "{tempfile}";
			type = FileTypes.ALL_TYPES;
		}

		protected string name;

		/// <summary>
		/// Returnsthe Name of a Plugin
		/// </summary>
		public string Name => name;

		protected string filename;

		/// <summary>
		/// Returns/sets the FileName of the External Application
		/// </summary>
		public string FileName
		{
			get => filename;
			set => filename = value;
		}

		/// <summary>
		/// Returns/sets the FileName of the External Application
		/// </summary>
		/// <remarks>the Palceholder {simple} will be replaced with the real Simpe Installation Path</remarks>
		public string RealFileName => filename.Replace("{simpe}", Helper.SimPePath);

		protected string arguments;

		/// <summary>
		/// Returns/sets the Arguments we have to send to the Application
		/// </summary>
		/// <remarks>use "{tempname}" as a Plcaeholder for the Filename simPe uses to store the Temporary File</remarks>
		public string Attributes
		{
			get => arguments;
			set => arguments = value;
		}

		protected FileTypes type;

		/// <summary>
		/// Returns the Type of the Packged File this Application can be used with
		/// </summary>
		/// <remarks>0xfffffff for all Types</remarks>
		public FileTypes Type
		{
			get => type;
			set => type = value;
		}

		/// <summary>
		/// saves the packed File
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="dscfile"></param>
		public static void SavePackedFile(
			string filename,
			bool dscfile,
			Packages.PackedFileDescriptor pfd,
			Packages.GeneratableFile package
		)
		{
#if !DEBUG
			try
#endif
			{
				pfd.Path = System.IO.Path.GetDirectoryName(filename);
				pfd.Path = ".\\";
				pfd.Filename = System.IO.Path.GetFileName(filename);
				package.SavePackedFile(filename, null, pfd, dscfile);
			}
#if !DEBUG
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errwritingfile") + filename,
					ex
				);
			}
#endif
		}

		/// <summary>
		/// Open a Packed File and add it to the package
		/// </summary>
		/// <param name="filename">Name of the File</param>
		/// <param name="pfd">Descriptor of the Target File</param>
		/// <param name="package">The package the Fille sould be added to</param>
		/// <returns>true if succesfull</returns>
		public static bool OpenPackedFile(
			string filename,
			ref Packages.PackedFileDescriptor pfd
		)
		{
			try
			{
				try
				{
					if (filename.ToLower().EndsWith(".xml"))
					{
						pfd = XmlPackageReader.OpenExtractedPackedFile(filename);
						filename = System.IO.Path.Combine(pfd.Path, pfd.Filename);
					}
					else
					{
						string[] part = System
							.IO.Path.GetFileNameWithoutExtension(filename)
							.Split("-".ToCharArray(), 4);
						try
						{
							pfd.Type = (FileTypes)Convert.ToUInt32(part[0].Trim(), 16);
							pfd.SubType = Convert.ToUInt32(part[1].Trim(), 16);
							pfd.Group = Convert.ToUInt32(part[2].Trim(), 16);
							pfd.Instance = Convert.ToUInt32(part[3].Trim(), 16);
						}
						catch (Exception)
						{
							part = System
								.IO.Path.GetFileNameWithoutExtension(filename)
								.Split("-".ToCharArray(), 5);

							try
							{
								pfd.Type = (FileTypes)Convert.ToUInt32(part[0].Trim(), 16);
								pfd.SubType = Convert.ToUInt32(part[2].Trim(), 16);
								pfd.Group = Convert.ToUInt32(part[3].Trim(), 16);
								pfd.Instance = Convert.ToUInt32(part[4].Trim(), 16);
							}
							catch (Exception) { }
						}

						try
						{
							part = System
								.IO.Path.GetDirectoryName(filename)
								.Split("\\".ToCharArray());
							if (part.Length > 0)
							{
								string last = part[part.Length - 1];
								part = last.Split("-".ToCharArray(), 2);
								pfd.Type = (FileTypes)Convert.ToUInt32(part[0].Trim(), 16);
							}
						}
						catch (Exception) { }
					}
				}
				catch (Exception) { }

				System.IO.FileStream fs = System.IO.File.OpenRead(filename);

				try
				{
					System.IO.BinaryReader mbr = new System.IO.BinaryReader(fs);
					byte[] data = new byte[mbr.BaseStream.Length];
					for (int i = 0; i < data.Length; i++)
					{
						data[i] = mbr.ReadByte();
					}

					pfd.UserData = data;
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(
						Localization
							.Manager.GetString("err003")
							.Replace("{0}", filename),
						ex
					);
					return false;
				}
				finally
				{
					fs.Close();
					fs.Dispose();
					fs = null;
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("erropenfile") + " " + filename,
					ex
				);
				return false;
			}
			return true;
		}

		/// <summary>
		/// Starts the external Plugin
		/// </summary>
		/// <param name="pfd">File Descriptor of the Selected File</param>
		/// <param name="package">The package the File is stored in</param>
		public void Execute(Interfaces.Scenegraph.IScenegraphFileIndexItem item)
		{
			if (item == null)
			{
				return;
			}

			if (item.FileDescriptor == null)
			{
				return;
			}

			if (item.Package == null)
			{
				return;
			}

			string extfile = System.IO.Path.Combine(
				System.IO.Path.GetTempPath(),
				"simpe"
			);
			uint ct = 0;
			while (System.IO.File.Exists(extfile + Helper.HexString(ct) + ".tmp"))
			{
				ct++;
			}

			extfile = extfile + Helper.HexString(ct) + ".tmp";

			try
			{
				SavePackedFile(
					extfile,
					false,
					(Packages.PackedFileDescriptor)item.FileDescriptor,
					(Packages.GeneratableFile)item.Package
				);

				Process p = new Process();
				p.StartInfo.FileName = RealFileName;
				p.StartInfo.Arguments = Attributes
					.Replace("{tempname}", "\"" + extfile + "\"")
					.Replace("{tempfile}", "\"" + extfile + "\"");

				p.Start();

				p.WaitForExit();
				p.Close();

				Packages.PackedFileDescriptor pfd =
					(Packages.PackedFileDescriptor)item.FileDescriptor;
				OpenPackedFile(extfile, ref pfd);
				pfd.Filename = null;
				pfd.Path = null;
			}
			finally
			{
				try
				{
					System.IO.File.Delete(extfile);
				}
				catch (Exception) { }
			}
		}

		/// <summary>
		/// Remove the Registry Settings
		/// </summary>
		public void DeleteSettings()
		{
			Helper.WindowsRegistry.Config.ExtTools.Remove(Helper.HexString(type) + "-" + name);
		}

		/// <summary>
		/// Put the Settings to the Registry
		/// </summary>
		public void SaveSettings()
		{
			Dictionary<string, Dictionary<string, string>> exttools = Helper.WindowsRegistry.Config.ExtTools;
			if (!exttools.ContainsKey(Helper.HexString(type) + "-" + name))
			{
				exttools[Helper.HexString(type) + "-" + name] = new Dictionary<string, string>();
			}
			exttools[Helper.HexString(type) + "-" + name]["name"] = Name;
			exttools[Helper.HexString(type) + "-" + name]["type"] = Type.ToString();
			exttools[Helper.HexString(type) + "-" + name]["filename"] = FileName;
			exttools[Helper.HexString(type) + "-" + name]["attributes"] = Attributes;

			Helper.WindowsRegistry.SaveConfig();
		}

		/// <summary>
		/// Retunrs the real Name
		/// </summary>
		/// <param name="regname">Name of the Registry SubKey</param>
		/// <returns></returns>
		public static string SplitName(string regname)
		{
			string[] str = regname.Split("-".ToCharArray(), 2);
			return str.Length > 1 ? str[1] : Localization.Manager.GetString("Unknown");
		}

		/// <summary>
		/// Override
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Name
				+ " (0x"
				+ Helper.HexString(type)
				+ ", "
				+ FileName
				+ " "
				+ Attributes
				+ ")";
		}
	}

	/// <summary>
	/// This calass provides some Methods that can be used to handle external Tools
	/// </summary>
	public class ToolLoaderExt
	{
		static List<ToolLoaderItemExt> items = new List<ToolLoaderItemExt>();

		/// <summary>
		/// List of all available Items
		/// </summary>
		public static List<ToolLoaderItemExt> Items
		{
			get
			{
				if (items == null)
				{
					Load();
				}

				return items;
			}
			set => items = value;
		}

		/// <summary>
		/// Add the Passed item
		/// </summary>
		/// <param name="tli"></param>
		public static void Add(ToolLoaderItemExt tli)
		{
			if (items == null)
			{
				Load();
			}

			items.Add(tli);
		}

		/// <summary>
		/// Remove the passed Item
		/// </summary>
		/// <param name="tli"></param>
		public static void Remove(ToolLoaderItemExt tli)
		{
			if (items == null)
			{
				Load();
			}

			items.Remove(tli);
		}

		/// <summary>
		/// Save the Toollist
		/// </summary>
		public static void StoreTools()
		{
			if (items == null)
			{
				return;
			}

			Helper.WindowsRegistry.Config.ExtTools.Clear();

			foreach (ToolLoaderItemExt tli in items)
			{
				tli.SaveSettings();
			}
		}

		protected static void Load()
		{
			items.Clear();

			foreach (KeyValuePair<string, Dictionary<string, string>> name in Helper.WindowsRegistry.Config.ExtTools)
			{
				items.Add(new ToolLoaderItemExt(ToolLoaderItemExt.SplitName(name.Key))
				{
					Type = (FileTypes)Enum.Parse(typeof(FileTypes), name.Value["type"]),
					FileName = name.Value["filename"],
					Attributes = name.Value["attributes"]
				});
			}
		}

		/// <summary>
		/// Returns the List of all known Tools for this Type
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static ToolLoaderItemExt[] UsableItems(FileTypes type)
		{
			if (items == null)
			{
				Load();
			}

			ArrayList list = new ArrayList();
			if (type != FileTypes.ALL_TYPES)
			{
				foreach (ToolLoaderItemExt tli in items)
				{
					if (tli.Type == type)
					{
						list.Add(tli);
					}
				}
			}

			foreach (ToolLoaderItemExt tli in items)
			{
				if (tli.Type == FileTypes.ALL_TYPES)
				{
					list.Add(tli);
				}
			}

			ToolLoaderItemExt[] ret = new ToolLoaderItemExt[list.Count];
			list.CopyTo(ret);

			return ret;
		}
	}
}
