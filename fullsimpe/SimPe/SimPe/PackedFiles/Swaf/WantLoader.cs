// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.Plugin;

namespace SimPe.PackedFiles.Swaf
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public static class WantLoader
	{
		private static Dictionary<uint, Interfaces.Scenegraph.IScenegraphFileIndexItem> wants = null;
		private static Packages.File txtpkg = null;

		// static SimPe.Packages.File imgpkg = null; // Never used ??

		/// <summary>
		/// Returns a Hashtable of all available Wants
		/// </summary>
		/// <remarks>key is the want GUID, value is a XWant object</remarks>
		public static Dictionary<uint, Interfaces.Scenegraph.IScenegraphFileIndexItem> Wants
		{
			get
			{
				if (wants == null)
				{
					LoadWants();
				}

				return wants;
			}
		}

		/// <summary>
		/// Returns a WantNameLoader you can use to determine Names
		/// </summary>
		public static WantNameLoader WantNameLoader { get; } = new WantNameLoader();

		/// <summary>
		/// Loads the Text Package File
		/// </summary>
		private static void LoadTextPackage()
		{
			Wait.SubStart();
			txtpkg = Packages.File.LoadFromFile(
				System.IO.Path.Combine(
					PathProvider.Global.Latest.InstallFolder,
					"TSData\\Res\\Text\\Wants.package"
				)
			);

			FileTableBase.FileIndex.AddIndexFromPackage(
				System.IO.Path.Combine(
					PathProvider.Global[Expansions.BaseGame].InstallFolder,
					"TSData\\Res\\UI\\ui.package"
				));
			foreach (ExpansionItem ei in PathProvider.Global.Expansions)
			{
				if (ei.Exists)
				{
					FileTableBase.FileIndex.AddIndexFromPackage(
						System.IO.Path.Combine(
							ei.InstallFolder,
							"TSData\\Res\\UI\\ui.package"
						));
				}
			}

			Wait.SubStop();
		}

		/// <summary>
		/// Load the available Wants
		/// </summary>
		private static void LoadWants()
		{
			Wait.SubStart();
			wants = new Dictionary<uint, Interfaces.Scenegraph.IScenegraphFileIndexItem>();

			FileTableBase.FileIndex.Load();

			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem wts in FileTableBase.FileIndex.FindFile(Data.MetaData.XWNT, true))
			{
				wants.Add(wts.FileDescriptor.Instance, wts);
			}

			Wait.SubStop();
		}

		/// <summary>
		/// Returns a XWAnt File for this Item or null
		/// </summary>
		/// <param name="guid">The GUID of the Want</param>
		/// <returns>The Xant Object representing That want (or null if not found)</returns>
		public static XWant GetWant(uint guid)
		{
			Interfaces.Scenegraph.IScenegraphFileIndexItem wts = Wants[guid];
			if (wts != null)
			{
				XWant xwnt = new XWant();
				wts.FileDescriptor.UserData = wts
					.Package.Read(wts.FileDescriptor)
					.UncompressedData;
				xwnt.ProcessData(wts);

				return xwnt;
			}
			return null;
		}

		/// <summary>
		/// Returns the String File describing that want
		/// </summary>
		/// <param name="wnt">The Want File</param>
		/// <returns>The Str File or null if none was found</returns>
		public static Wrapper.Str LoadText(XWant wnt)
		{
			if (wnt == null)
			{
				return null;
			}

			if (txtpkg == null)
			{
				LoadTextPackage();
			}

			Interfaces.Files.IPackedFileDescriptor[] pfds = txtpkg.FindFile(
				Data.MetaData.STRING_FILE,
				0,
				wnt.StringInstance
			);
			if (pfds.Length > 0)
			{
				Wrapper.Str str = new Wrapper.Str();
				pfds[0].UserData = txtpkg.Read(pfds[0]).UncompressedData;
				str.ProcessData(pfds[0], txtpkg);

				return str;
			}
			return null;
		}

		/// <summary>
		/// Returns the Icon File for the passed Want
		/// </summary>
		/// <param name="wnt">The Want File</param>
		/// <returns>The Picture File or null if none was found</returns>
		public static Wrapper.Picture LoadIcon(XWant wnt)
		{
			if (wnt == null)
			{
				return null;
			}

			if (txtpkg == null)
			{
				LoadTextPackage();
			}

			Interfaces.Scenegraph.IScenegraphFileIndexItem[] items =
				FileTableBase.FileIndex.FindFile(wnt.IconFileDescriptor, null);
			if (items.Length > 0)
			{
				Wrapper.Picture pic =
					new Wrapper.Picture();
				items[0].FileDescriptor.UserData = items[0]
					.Package.Read(items[0].FileDescriptor)
					.UncompressedData;
				pic.ProcessData(items[0]);

				return pic;
			}
			return null;
		}
	}
}
