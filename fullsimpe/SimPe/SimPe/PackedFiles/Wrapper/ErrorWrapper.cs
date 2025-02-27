/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
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
