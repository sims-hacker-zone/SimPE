// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

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
						ChangeHandler?.Invoke(this, new PackageArg
						{
							Package = package,
							FileDescriptor = pfd,
							Result = tr
						});
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
	}
}
