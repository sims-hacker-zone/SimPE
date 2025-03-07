// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;

namespace SimPe
{
	public class PackageArg : EventArgs
	{
		public Interfaces.Files.IPackageFile Package
		{
			get; set;
		}

		public Interfaces.Files.IPackedFileDescriptor FileDescriptor
		{
			get; set;
		}

		public IToolResult Result
		{
			get; set;
		}
	}

	public class ToolMenuItem : System.Windows.Forms.MenuItem
	{
		ITool tool;
		Interfaces.Files.IPackedFileDescriptor pfd;
		Interfaces.Files.IPackageFile package;

		EventHandler ChangeHandler
		{
			get; set;
		}

		public ToolMenuItem(ITool tool, EventHandler chghnd)
		{
			this.tool = tool;

			string name = tool.ToString();
			string[] parts = name.Split("\\".ToCharArray());
			name = Localization.GetString(parts[parts.Length - 1]);
			Text = name;

			Click += new EventHandler(ClickItem);
			ChangeHandler = chghnd;
		}

		private void ClickItem(object sender, EventArgs e)
		{
			try
			{
				if (tool.IsEnabled(pfd, package))
				{
					IToolResult tr = tool.ShowDialog(
						ref pfd,
						ref package
					);
					WaitingScreen.Stop();
					if (tr.ChangedAny)
					{
						PackageArg p = new PackageArg
						{
							Package = package,
							FileDescriptor = pfd,
							Result = tr
						};
						if (ChangeHandler != null)
						{
							ChangeHandler(this, p);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("Unable to Start ToolPlugin.", ex);
			}
		}

		public override string ToString()
		{
			try
			{
				return tool.ToString();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("Unable to Load ToolPlugin.", ex);
			}

			return "Plugin Error";
		}

		public Interfaces.Files.IPackedFileDescriptor FileDescriptor
		{
			get => pfd;
			set => pfd = value;
		}

		public Interfaces.Files.IPackageFile Package
		{
			get => package;
			set => package = value;
		}

		public void UpdateEnabledState()
		{
			try
			{
				Enabled = tool.IsEnabled(pfd, package);
			}
			catch (Exception)
			{
				Enabled = false;
			}
		}
	}

	/// <summary>
	/// Class that can be used to Load external Filewrappers int the given Registry
	/// </summary>
	public class LoadFileWrappers
	{
		/// <summary>
		/// The Type Registry
		/// </summary>
		IWrapperRegistry reg;

		/// <summary>
		/// The Tool Registry
		/// </summary>
		IToolRegistry treg;

		//this is a manual List of Wrappers that are known to cause Problems
		private readonly HashSet<string> ignore = new HashSet<string>
			{
				"simpe.3d.plugin.dll",
				"pjse.filetable.plugin.dll",
				"pjse.guidtool.plugin.dll",
				"pjse.coder.plugin.dll",
				"simpe.actiondeletesim.plugin.dll",
				"theos.simsurgery.plugin.dll",
				"theo.meshscanner.plugin.dll",
				"simpe.ngbh.plugin.dll"
			};

		/// <summary>
		/// Constructor of The class
		/// </summary>
		/// <param name="registry">
		/// Registry the External Data should be added to
		/// </param>
		/// <param name="toolreg">Registry the tools should be added to</param>
		public LoadFileWrappers(IWrapperRegistry registry, IToolRegistry toolreg)
		{
			reg = registry;
			treg = toolreg;
		}

		/// <summary>
		/// Tries to load the IWrapperFactory from the passed File
		/// </summary>
		/// <param name="file">The File where to look in</param>
		/// <returns>null or a Wrapper Factory</returns>
		public static void LoadWrapperFactory(string file, LoadFileWrappersExt lfw)
		{
			object o = LoadPlugin(file, typeof(IWrapperFactory), lfw);

			if (o != null)
			{
				lfw.reg.Register((IWrapperFactory)o);
			}
		}

		public static void LoadErrorWrapper(
			PackedFiles.Wrapper.ErrorWrapper w,
			LoadFileWrappersExt lfw
		)
		{
			lfw.reg.Register(w);
		}

		/// <summary>
		/// Tries to load the IWrapperFactory from the passed File
		/// </summary>
		/// <param name="file">The File where to look in</param>
		/// <returns>null or a Wrapper Factory</returns>
		public static void LoadToolFactory(string file, LoadFileWrappersExt lfw)
		{
			object o = LoadPlugin(file, typeof(IToolFactory), lfw);

			if (o != null)
			{
				lfw.treg.Register((IToolFactory)o);
			}
		}

		/// <summary>
		/// Loads the First Class form a File implementing the passed Interface
		/// </summary>
		/// <param name="file">The File the Class is stored in</param>
		/// <param name="interfaceType">The Type of the FIle</param>
		/// <returns>The Class Implementing the given type or null if none was found</returns>
		public static object LoadPlugin(
			string file,
			Type interfaceType,
			LoadFileWrappersExt lfw
		)
		{
			if (lfw.ignore.Contains(Path.GetFileName(file).Trim().ToLower()) || !File.Exists(file) || !Helper.CanLoadPlugin(file))
			{
				return null;
			}

			try
			{
				AssemblyName myAssemblyName = AssemblyName.GetAssemblyName(file);
			}
			catch
			{
				return null;
			}

			Assembly a = Assembly.LoadFrom(file);
			try
			{
				Type[] mytypes = a.GetTypes();

				foreach (Type t in mytypes)
				{
					Type mit = t.GetInterface(interfaceType.FullName);
					if (mit != null)
					{
						object obj = Activator.CreateInstance(t);
						return obj;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			return null;
		}

		/// <summary>
		/// Loads the First Class form a File implementing the passed Interface
		/// </summary>
		/// <param name="file">The File the Class is stored in</param>
		/// <param name="interfaceType">The Type of the FIle</param>
		/// <returns>All Classes implementing the given interface</returns>
		public static object[] LoadPlugins(string file, Type interfaceType)
		{
			return LoadPlugins(file, interfaceType, new object[0]);
		}

		/// <summary>
		/// Loads the First Class form a File implementing the passed Interface
		/// </summary>
		/// <param name="file">The File the Class is stored in</param>
		/// <param name="interfaceType">The Type of the FIle</param>
		/// <param name="args">nlist of argument you want to pass to the constructor</param>
		/// <returns>All Classes implementing the given interface</returns>
		public static object[] LoadPlugins(
			string file,
			Type interfaceType,
			object[] args
		)
		{
			if (!File.Exists(file))
			{
				return new object[0];
			}

			if (!Helper.CanLoadPlugin(file))
			{
				return new object[0];
			}

			AssemblyName myAssemblyName;
			try
			{
				myAssemblyName = AssemblyName.GetAssemblyName(file);
			}
			catch
			{
				return new object[0];
			}

			Assembly a = Assembly.LoadFrom(file);
			return LoadPlugins(a, interfaceType, args);
		}

		/// <summary>
		/// Loads the First Class form a File implementing the passed Interface
		/// </summary>
		/// <param name="file">The File the Class is stored in</param>
		/// <param name="interfaceType">The Type of the FIle</param>
		/// <param name="args">nlist of argument you want to pass to the constructor</param>
		/// <returns>All Classes implementing the given interface</returns>
		public static object[] LoadPlugins(
			Assembly a,
			Type interfaceType,
			object[] args
		)
		{
			if (a == null)
			{
				return new object[0];
			}

			ArrayList list = new ArrayList();
			try
			{
				Type[] mytypes = a.GetTypes();

				foreach (Type t in mytypes)
				{
					if (t.IsInterface || t.IsAbstract)
					{
						continue;
					}

					try
					{
						Type mit = t.GetInterface(interfaceType.FullName);
						if (mit != null)
						{
							try
							{
								object obj = null;
								try
								{
									obj = Activator.CreateInstance(t, args);
								}
								catch
								{
									//could crtea the Object with the passed Argument List,
									//try to call the default Cosntructor
									obj = Activator.CreateInstance(t);
								}

								if (obj != null)
								{
									list.Add(obj);
								}
							}
							catch (Exception ex)
							{
								Helper.ExceptionMessage(
									"Unable to load " + t.Name + ".",
									new Exception(
										"Unable to load "
											+ t.Name
											+ " from '"
											+ a.ToString()
											+ "'.",
										ex
									)
								);
							}
						}
					}
					catch (Exception ex)
					{
						Helper.ExceptionMessage(
							"Unable to get Interface for " + t.Name + ".",
							ex
						);
					}
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					"Unable to load Plugin \"" + a.FullName + "\".",
					ex
				);
			}

			object[] o = new object[list.Count];
			list.CopyTo(o);
			return o;
		}

		#region Old GUI
		/// <summary>
		/// Adds the Tool Plugins to the passed menu
		/// </summary>
		/// <param name="mi">The Menu you want to add Items to</param>
		/// <param name="chghandler">A Function to call when the Package was chaged by a Tool</param>
		public void AddMenuItems(
			System.Windows.Forms.MenuItem mi,
			EventHandler chghandler
		)
		{
			mi.MenuItems.AddRange(treg.Tools.Select((tool) => new ToolMenuItem(tool, chghandler)).ToArray());
			mi.MenuItems.AddRange(treg.Docks.Where((tool) => tool is ITool).Select((tool) => new ToolMenuItem(tool as ITool, chghandler)).ToArray());
			EnableMenuItems(mi, null, null);
		}

		/// <summary>
		/// Set the Enabled state of the Toll MenuItems
		/// </summary>
		/// <param name="mi"></param>
		/// <param name="pfd"></param>
		/// <param name="package"></param>
		public void EnableMenuItems(
			System.Windows.Forms.MenuItem mi,
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			foreach (System.Windows.Forms.MenuItem item in mi.MenuItems)
			{
				try
				{
					ToolMenuItem tmi = (ToolMenuItem)item;
					tmi.Package = package;
					tmi.FileDescriptor = pfd;
					tmi.UpdateEnabledState();
				}
				catch (Exception) { }
			}
		}
		#endregion
	}
}
