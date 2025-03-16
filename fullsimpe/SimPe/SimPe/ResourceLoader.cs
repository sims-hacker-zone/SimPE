// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;

using SimPe.Interfaces.Plugin;

using Message = SimPe.Forms.MainUI.Message;

namespace SimPe
{
	/// <summary>
	/// This class can be used to Load a Resource into the Plugin Area(s)
	/// </summary>
	public class ResourceLoader
	{
		private readonly LoadedPackage pkg;

		/// <summary>
		/// keeps a list of Resources that can only handle a single Instance
		/// </summary>
		private readonly Dictionary<string, Interfaces.Scenegraph.IScenegraphFileIndexItem> single
			= new Dictionary<string, Interfaces.Scenegraph.IScenegraphFileIndexItem>();


		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="dc">The document Container that receives the Plugins</param>
		/// <param name="lp">The Container for the currently loaded package</param>
		public ResourceLoader(LoadedPackage lp)
		{
			pkg = lp;
		}

		/// <summary>
		/// Load the assigned Wrapper, and initiate the Resource
		/// </summary>
		/// <param name="fii"></param>
		/// <returns></returns>
		public Interfaces.Plugin.IFileWrapper GetWrapper(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii
		)
		{
			if (fii == null)
			{
				return null;
			}

			//try by Type

			return (Interfaces.Plugin.IFileWrapper)
					FileTableBase.WrapperRegistry.FindHandler(fii.FileDescriptor.Type)
					?? FileTableBase.WrapperRegistry.FindHandler(pkg.Package.Read(
					fii.FileDescriptor).GetUncompressedData(0x40));
		}

		/// <summary>
		/// Load the assigned Wrapper, and initiate the Resource
		/// </summary>
		/// <param name="fii"></param>
		/// <returns></returns>
		public void LoadWrapper(ref IFileWrapper wrapper,
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii
		)
		{
			if (wrapper != null)
			{
				wrapper = wrapper.Activate().ProcessFile(
					fii.Package.FindExactFile(fii.FileDescriptor),
					fii.Package
				);
			}
		}

		/// <summary>
		/// The resource that should be added to the Container
		/// </summary>
		/// <param name="fii"></param>
		/// <param name="overload">Replace the currently active Document Tab with the new one</param>
		/// <returns>true, if the Plugin was loaded</returns>
		public bool AddResource(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii,
			bool overload
		)
		{
			return AddResource(fii, false, overload);
		}

		/// <summary>
		/// If the Resource was already Loaded, this Method Wil Focus it and optional Reload the Content
		/// </summary>
		/// <param name="fii"></param>
		/// <param name="reload"></param>
		/// <returns>true, if a Document was highlighted</returns>
		private bool FocusResource(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii,
			bool reload
		)
		{
			//already in List
			if (SelectResource(fii))
			{
				if (reload)
				{
				}
				return true;
			}

			return false;
		}

		/// <summary>
		/// Unload Documents handled by the Same Wrapper when the Wrapper
		/// is not able to present Multiple Resources
		/// </summary>
		/// <param name="wrapper"></param>
		/// <returns>true, if the Wrapper was unloaded or allows Multiple Instances</returns>
		private bool UnloadSingleInstanceWrappers(
			Interfaces.Plugin.IFileWrapper wrapper,
			ref bool overload
		)
		{
			if (wrapper == null)
			{
				return false;
			}

			if (!wrapper.AllowMultipleInstances)
			{
				string id = wrapper.GetType().ToString();
				if (single.ContainsKey(id))
				{
					Interfaces.Scenegraph.IScenegraphFileIndexItem oldfii = single[id];

					single.Remove(id);
					overload = false;
				}
			}

			return true;
		}

		/// <summary>
		/// Add the passed Wrapper (it's UI) as a new Document
		/// </summary>
		/// <param name="fii"></param>
		/// <param name="wrapper"></param>
		/// <param name="overload">Replace the currently active Document Tab with the new one</param>
		/// <returns>true, if the Resource was Presented succesfull</returns>
		private bool Present(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii,
			Interfaces.Plugin.IFileWrapper wrapper,
			bool overload
		)
		{
			if (wrapper != null)
			{
				if (wrapper.FileDescriptor == null || wrapper.Package == null)
				{
					return false;
				}

				//do not open Wrappers for deleted Descriptors
				if (wrapper.FileDescriptor != null && wrapper.FileDescriptor.MarkForDelete)
				{
					return false;
				}

				bool add = !overload;

				return true;
			}

			return false;
		}

		/// <summary>
		/// The resource that should be added to the Container
		/// </summary>
		/// <param name="fii"></param>
		/// <param name="reload">
		/// when the Resource is already visible, and this Argument is true, the Gui
		/// will be reloaded. This means, that all unsaved changes will get lost!
		/// </param>
		/// <param name="overload">Replace the currently active Document Tab with the new one</param>
		/// <returns>true, if the Plugin was loaded</returns>
		public bool AddResource(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii,
			bool reload,
			bool overload
		)
		{
			if (!pkg.Loaded)
			{
				return false;
			}

			//already Loaded?
			if (FocusResource(fii, reload))
			{
				return true;
			}

			//only one File at a Time?
			if (!Helper.WindowsRegistry.Config.MultipleFiles)
			{
				Clear();
			}

			//get the Wrapper
			Interfaces.Plugin.IFileWrapper wrapper = GetWrapper(fii);

			//unload if only one instance can be loaded
			if (!UnloadSingleInstanceWrappers(wrapper, ref overload))
			{
				return false;
			}

			try
			{
				//load the new Data into the Wrapper
				LoadWrapper(ref wrapper, fii);

				//Present the passed Wrapper
				return Present(fii, wrapper, overload);
			}
#if !DEBUG
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
				return false;
			}
#endif
			finally { }
		}

		/// <summary>
		/// Selects the Document that shows the selected Resource
		/// </summary>
		/// <param name="fii">The Resource you want to select</param>
		/// <returns>true, if that resource was found</returns>
		public bool SelectResource(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii
		)
		{
			if (fii == null)
			{
				return false;
			}

			return false;
		}

		/// <summary>
		/// Removes the Resource from the internal storage
		/// </summary>
		/// <param name="fii"></param>
		/// <param name="wrapper"></param>
		public void RemoveResource(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii,
			Interfaces.Plugin.IFileWrapper wrapper
		)
		{
			if (fii != null)
			{
				if (wrapper != null)
				{
					single.Remove(wrapper.GetType().ToString());
				}
			}
		}

		/// <summary>
		/// Cleanup Container
		/// </summary>
		/// <returns>true if all documents were closed</returns>
		public bool Clear()
		{
			return true;
		}

		/// <summary>
		/// Make sure all uncommited Changes are stored
		/// </summary>
		/// <returns>true if all documents were either commited or ignored</returns>
		public bool Flush()
		{
			bool commited = true;
			return commited;
		}
	}
}
