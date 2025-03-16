// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Threading.Tasks;

using SimPe.Data;

namespace SimPe
{
	/// <summary>
	/// This calss can be used to control SimPe from a Plugin.
	/// </summary>
	public class RemoteControl
	{
		public class ControlEventArgs : EventArgs
		{
			object[] data;

			public ControlEventArgs(FileTypes target)
				: this(target, new object[0]) { }

			public ControlEventArgs(FileTypes target, object data)
				: this(target, new object[] { data }) { }

			public ControlEventArgs(FileTypes target, object[] data)
			{
				if (data == null)
				{
					data = new object[0];
				}

				this.data = data;

				TargetType = target;
			}

			public FileTypes TargetType
			{
				get;
			}

			public object Item => data.Length == 0 ? null : data[0];

			public object Items => data;
		}

		struct MessageQueueItemInfo
		{
			public FileTypes target;
			public ControlEvent fkt;
		}

		public delegate void ControlEvent(object sender, ControlEventArgs e);
		static System.Collections.ArrayList events = new System.Collections.ArrayList();

		public static void HookToMessageQueue(FileTypes type, ControlEvent fkt)
		{
			MessageQueueItemInfo mqi = new MessageQueueItemInfo
			{
				target = type,
				fkt = fkt
			};

			events.Add(mqi);
		}

		public static void UnhookFromMessageQueue(FileTypes type, ControlEvent fkt)
		{
			for (int i = events.Count - 1; i >= 0; i--)
			{
				MessageQueueItemInfo mqi = (MessageQueueItemInfo)events[i];
				if (mqi.target == type)
				{
					if (mqi.fkt == fkt)
					{
						events.RemoveAt(i);
					}
				}
			}
		}

		public static void AddMessage(object sender, ControlEventArgs e)
		{
			foreach (MessageQueueItemInfo mqi in events)
			{
				if (
					mqi.target == e.TargetType
					|| mqi.target == FileTypes.ALL_TYPES
					|| e.TargetType == FileTypes.ALL_TYPES
				)
				{
					mqi.fkt(sender, e);
				}
			}
		}

		/// <summary>
		/// Delegate you have to implement for the remote Package opener
		/// </summary>
		public delegate bool OpenPackageDelegate(string filename);

		/// <summary>
		/// Delegate you have to implement for the remote Package opener
		/// </summary>
		public delegate bool OpenMemPackageDelegate(
			Interfaces.Files.IPackageFile pkg
		);

		/// <summary>
		/// Delegate you have to implement for the Remote PackedFile Opener
		/// </summary>
		public delegate Task<bool> OpenPackedFileDelegate(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii
		);

		/// <summary>
		/// Returns/Sets the Function that should be called if you want to open a PackedFile
		/// </summary>
		public static OpenPackedFileDelegate OpenPackedFileFkt
		{
			get; set;
		}

		/// <summary>
		/// Returns/Sets the Function that should be called if you want to open a PackedFile
		/// </summary>
		public static OpenPackageDelegate OpenPackageFkt
		{
			get; set;
		}

		/// <summary>
		/// Open a Package in the main SimPe Gui
		/// </summary>
		/// <param name="filename">The Filename of the package</param>
		/// <returns>true, if the package was opened</returns>
		public static async Task<bool> OpenPackage(string filename)
		{
			if (OpenPackageFkt == null)
			{
				return false;
			}

			try
			{
				return OpenPackageFkt(filename);
			}
			catch (Exception ex)
			{
				await Helper.ExceptionMessage(
					"Unable to open a Package in the SimPe GUI. (file="
						+ filename
						+ ")",
					ex
				);
			}
			return false;
		}

		/// <summary>
		/// Returns/Sets the Function that should be called if you want to open a PackedFile
		/// </summary>
		public static OpenMemPackageDelegate OpenMemoryPackageFkt
		{
			get; set;
		}

		/// <summary>
		/// Open a Package in the main SimPe Gui
		/// </summary>
		/// <param name="filename">The Filename of the package</param>
		/// <returns>true, if the package was opened</returns>
		public static async Task<bool> OpenMemoryPackage(Interfaces.Files.IPackageFile pkg)
		{
			if (OpenMemoryPackageFkt == null)
			{
				return false;
			}

			try
			{
				return OpenMemoryPackageFkt(pkg);
			}
			catch (Exception ex)
			{
				await Helper.ExceptionMessage(
					"Unable to open a Package in the SimPe GUI. (package="
						+ pkg.ToString()
						+ ")",
					ex
				);
			}
			return false;
		}

		/// <summary>
		/// Open a Package in the main SimPe Gui
		/// </summary>
		/// <param name="pfd">The FileDescriptor</param>
		/// <param name="pkg">The package the descriptor is in</param>
		/// <returns>true, if the package was opened</returns>
		public static async Task<bool> OpenPackedFile(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile pkg
		)
		{
			return await OpenPackedFile(FileTableBase.FileIndex.CreateFileIndexItem(pfd, pkg));
		}

		/// <summary>
		/// Open a Package in the main SimPe Gui
		/// </summary>
		/// <param name="pfd">The FileDescriptor</param>
		/// <returns>true, if the package was opened</returns>
		public static async Task<bool> OpenPackedFile(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii
		)
		{
			if (OpenPackedFileFkt == null)
			{
				return false;
			}

			try
			{
				return await OpenPackedFileFkt(fii);
			}
			catch (Exception ex)
			{
				await Helper.ExceptionMessage(
					"Unable to open a resource in the SimPe GUI. ("
						+ fii.ToString()
						+ ")",
					ex
				);
			}
			return false;
		}

		public delegate void ResourceListSelectionChangedHandler(
			object sender,
			Events.ResourceEventArgs e
		);

		public static void FireResourceListSelectionChangedHandler(
			object sender,
			Events.ResourceEventArgs e
		)
		{
			if (ResourceListSelectionChanged != null)
			{
				ResourceListSelectionChanged(sender, e);
			}
		}

		public static event ResourceListSelectionChangedHandler ResourceListSelectionChanged;
	}
}
