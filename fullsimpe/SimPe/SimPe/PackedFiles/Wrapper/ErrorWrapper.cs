// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// This is A ResourceWrapper, which is added when an external Wrapper could not be loaded
	/// </summary>
	public class ErrorWrapper
		: Interfaces.IWrapper,
			Interfaces.Plugin.IFileWrapper
	{
		string flname;
		Exception e;

		public ErrorWrapper(string filename, Exception e)
		{
			flname = filename;
			this.e = e;
			Priority = -1;
		}

		#region IWrapper Member

		public string WrapperFileName => System.IO.Path.GetFileName(flname);

		public void Register(Interfaces.IWrapperRegistry registry)
		{
			registry.Register(this);
		}

		public int Priority
		{
			get; set;
		}

		public override string ToString()
		{
			return "Error Wrapper";
		}

		public Interfaces.Plugin.IWrapperInfo WrapperDescription => new Interfaces.Plugin.AbstractWrapperInfo(
					WrapperFileName,
					Localization.GetString("Unknown"),
					e.ToString() + ":" + e.Message,
					1
				);

		public bool CheckVersion(uint version)
		{
			return false;
		}

		public bool AllowMultipleInstances => false;

		#endregion

		#region IFileWrapper Member

		public byte[] FileSignature => new byte[0];

		public uint[] AssignableTypes => new uint[0];

		#endregion

		#region IPackedFileWrapper Member

		public void RefreshUI()
		{
		}

		public string ResourceName => "";

		public void ProcessData(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package,
			bool catchex
		)
		{
		}

		void Interfaces.Plugin.Internal.IPackedFileWrapper.ProcessData(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package,
			Interfaces.Files.IPackedFile file,
			bool catchex
		)
		{
		}

		void Interfaces.Plugin.Internal.IPackedFileWrapper.ProcessData(
			Interfaces.Scenegraph.IScenegraphFileIndexItem item,
			bool catchex
		)
		{
		}

		void Interfaces.Plugin.Internal.IPackedFileWrapper.ProcessData(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
		}

		void Interfaces.Plugin.Internal.IPackedFileWrapper.ProcessData(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package,
			Interfaces.Files.IPackedFile file
		)
		{
		}

		void Interfaces.Plugin.Internal.IPackedFileWrapper.ProcessData(
			Interfaces.Scenegraph.IScenegraphFileIndexItem item
		)
		{
		}

		public string Description => "Error Object";

		public string DescriptionHeader => "Error";

		public System.IO.BinaryReader StoredData => null;

		public void LoadUI()
		{
		}

		public void Fix(Interfaces.IWrapperRegistry registry)
		{
		}

		public System.IO.MemoryStream Content => null;

		public Interfaces.Files.IPackageFile Package => null;

		public Interfaces.Plugin.IPackedFileUI UIHandler
		{
			get => null;
			set
			{
			}
		}

		public Interfaces.Plugin.IFileWrapper Activate()
		{
			return this;
		}

		public void Refresh()
		{
		}

		public string FileExtension => ".err";

		public Interfaces.Files.IPackedFileDescriptor FileDescriptor => null;

		#endregion

		#region IDisposable Member
		public virtual void Dispose()
		{
		}
		#endregion
	}
}
