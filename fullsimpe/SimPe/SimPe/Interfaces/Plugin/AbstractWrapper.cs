// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Extensions;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin.Internal;

namespace SimPe.Interfaces.Plugin
{
	/// <summary>
	/// The Abstarct Handler implements some common Methods of the
	/// SimPe.Interfaces.IPackedFileWrapper and SimPe.Interfaces.IPackedFileSaveExtension
	/// Interface. This is the easiest Way to Implement a Plugin.
	/// </summary>
	public abstract class AbstractWrapper
		: IWrapper,
			IPackedFileWrapper,
			IPackedFileSaveExtension
	{
		protected bool processed;

		/// <summary>
		/// true if <see cref="ProcessData"/> was called once
		/// </summary>
		public bool Processed => processed;

		/// <summary>
		/// Stores the FileDescriptor
		/// </summary>
		protected IPackedFileDescriptor pfd;

		/// <summary>
		/// Stores the Package
		/// </summary>
		protected IPackageFile package;

		/// <summary>
		/// Stores the UI Handler
		/// </summary>
		protected IPackedFileUI ui;

		/// <summary>
		/// Stors Human readable Informations about the Wrapper
		/// </summary>
		private IWrapperInfo wrapperinfo;

		/// <summary>
		/// Called By ProcessData() when the File nedds to update its Data Storage (Attributes, not the UserData)
		/// </summary>
		/// <param name="data">The Data to process</param>
		protected abstract void Unserialize(System.IO.BinaryReader reader);

		/// <summary>
		/// Creates the default UI Handler Object
		/// </summary>
		/// <returns>the default UI Handler Object is needed when the UIHandler is set to null</returns>
		protected abstract IPackedFileUI CreateDefaultUIHandler();

		/// <summary>
		/// Called when the data Stored in the Wrappers Attributes must be written to a Stream
		/// </summary>
		/// <param name="writer">The Stream the Data should be written to</param>
		/// <remarks>This implemenation wont save anything, you have to reimplement
		/// this in your class. </remarks>
		protected virtual void Serialize(System.IO.BinaryWriter writer)
		{
		}

		/// <summary>
		/// Creates a new Wrapper Infor Object
		/// </summary>
		/// <returns></returns>
		protected virtual IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				Localization.Manager.GetString("unnamed"),
				Localization.Manager.GetString("unknown"),
				base.ToString(),
				1
			);
		}

		/// <summary>
		/// Creates a new Instance
		/// </summary>
		public AbstractWrapper()
		{
			processed = false;
			changed = false;
			ui = null;
		}

		private string ExceptionMessage(string msg)
		{
			if (msg == null)
			{
				msg = "";
			}

			msg += "\n\nPackage: ";
			if (Package != null)
			{
				msg += Package.FileName;
			}
			else
			{
				msg += "null";
			}

			msg += "\nFile: ";
			if (FileDescriptor != null)
			{
				msg += FileDescriptor.ExceptionString;
			}
			else
			{
				msg += "null";
			}

			return msg;
		}

		private void ExceptionMessage(string msg, Exception ex)
		{
			msg = ExceptionMessage(msg);
			Helper.ExceptionMessage(msg, ex);
		}

		#region IWrapper Member

		public void Register(IWrapperRegistry registry)
		{
			registry.Register(this);
		}

		public virtual bool CheckVersion(uint version)
		{
			return false;
		}

		public IWrapperInfo WrapperDescription
		{
			get
			{
				if (wrapperinfo == null)
				{
					wrapperinfo = CreateWrapperInfo();
				}

				return wrapperinfo;
			}
		}

		public override string ToString()
		{
			return WrapperDescription.Name
				+ " (Author="
				+ WrapperDescription.Author
				+ ", Version="
				+ WrapperDescription.Version.ToString()
				+ ", GUID="
				+ $"{WrapperDescription.UID:X16}"
				+ ", FileName="
				+ WrapperFileName
				+ ", Type="
				+ GetType()
				+ ")";
		}

		public string WrapperFileName
		{
			get
			{
				string[] p = GetType().Assembly.FullName.Split(",".ToCharArray(), 2);

				return p.Length > 0 ? p[0].Trim() : Localization.GetString("unknown");
			}
		}

		#endregion

		#region IPackedFileSaveExtension Member

		public System.IO.MemoryStream CurrentStateData
		{
			get
			{
				System.IO.MemoryStream ms = new System.IO.MemoryStream();
				Serialize(new System.IO.BinaryWriter(ms));
				return ms;
			}
		}

		public void SynchronizeUserData()
		{
			SynchronizeUserData(true);
		}

		public void SynchronizeUserData(bool catchex)
		{
			SynchronizeUserData(catchex, false);
		}

		public void SynchronizeUserData(bool catchex, bool fire)
		{
			if (pfd == null)
			{
				changed = false;
				return;
			}

			if (catchex)
			{
				try
				{
					//set UserData, but do not fire a change Event!
					pfd.SetUserData(CurrentStateData.ToArray(), fire);
					changed = false;
				}
				catch (Exception ex)
				{
					ExceptionMessage(
						Localization.Manager.GetString("errwritingfile"),
						ex
					);
				}
			}
			else
			{
				//set UserData, but do not fire a change Event!
				pfd.SetUserData(CurrentStateData.ToArray(), false);
				changed = false;
			}
		}

		public void Save(IPackedFileDescriptor pfd)
		{
			try
			{
				System.IO.BinaryWriter bw = new System.IO.BinaryWriter(
					new System.IO.MemoryStream()
				);
				int size = Save(bw);
				System.IO.BinaryReader br = new System.IO.BinaryReader(bw.BaseStream);
				br.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
				pfd.UserData = br.ReadBytes(size);
			}
			catch (Exception ex)
			{
				ExceptionMessage(Localization.Manager.GetString("errwritingfile"), ex);
			}
		}

		public int Save(System.IO.BinaryWriter writer)
		{
			long pos = writer.BaseStream.Position;
			try
			{
				Serialize(writer);
			}
			catch (Exception ex)
			{
				ExceptionMessage(Localization.Manager.GetString("errwritingfile"), ex);
			}
			return (int)(writer.BaseStream.Position - pos);
		}

		bool changed;
		public virtual bool Changed
		{
			get => changed;
			set => changed = value;
		}
		#endregion

		#region IPackedFileLoadExtension Member
		public virtual void Fix(IWrapperRegistry registry)
		{
		}

		public IPackedFileDescriptor FileDescriptor
		{
			get => pfd;
			set
			{
				processed = false;
				pfd = value;
			}
		}

		public IPackedFileUI UIHandler
		{
			get
			{
				if (ui == null)
				{
					ui = CreateDefaultUIHandler();
				}

				return ui;
			}
			set => ui = value;
		}

		public IPackageFile Package
		{
			get => package;
			set
			{
				processed = false;
				package = value;
			}
		}

		public void ProcessData(
			IPackedFileDescriptor pfd,
			IPackageFile package,
			IPackedFile file
		)
		{
			ProcessData(pfd, package, file, true);
		}

		public void ProcessData(Scenegraph.IScenegraphFileIndexItem item)
		{
			ProcessData(item, true);
		}

		public void ProcessData(IPackedFileDescriptor pfd, IPackageFile package)
		{
			ProcessData(pfd, package, true);
		}

		public void ProcessData(
			IPackedFileDescriptor pfd,
			IPackageFile package,
			IPackedFile file,
			bool catchex
		)
		{
			changed = false;
			if (pfd == null || package == null)
			{
				return;
			}

			if (catchex)
			{
				try
				{
					if (file != null)
					{
						this.pfd = pfd;
						this.package = package;
						file = package.Read(pfd);
						System.IO.MemoryStream ms = new System.IO.MemoryStream(
							file.UncompressedData
						);
						if (ms.Length > 0)
						{
							Unserialize(new System.IO.BinaryReader(ms));
							processed = true;
						}
					}
					else
					{
						ProcessData(pfd, package);
					}
				}
				catch (Exception ex)
				{
					ExceptionMessage(Localization.Manager.GetString("erropenfile"), ex);
				}
			}
			else
			{
				if (file != null)
				{
					this.pfd = pfd;
					this.package = package;
					file = package.Read(pfd);
					System.IO.MemoryStream ms = new System.IO.MemoryStream(
						file.UncompressedData
					);
					if (ms.Length > 0)
					{
						Unserialize(new System.IO.BinaryReader(ms));
						processed = true;
					}
				}
				else
				{
					ProcessData(pfd, package);
				}
			}
		}

		public void ProcessData(
			Scenegraph.IScenegraphFileIndexItem item,
			bool catchex
		)
		{
			ProcessData(item.FileDescriptor, item.Package, catchex);
		}

		public void ProcessData(
			IPackedFileDescriptor pfd,
			IPackageFile package,
			bool catchex
		)
		{
			if (pfd == null || package == null)
			{
				return;
			}

			if (catchex)
			{
				try
				{
					this.pfd = pfd;
					this.package = package;
					if (StoredData.BaseStream.Length > 0)
					{
						Unserialize(StoredData);
						processed = true;
					}
				}
				catch (Exception ex)
				{
					ExceptionMessage(Localization.Manager.GetString("erropenfile"), ex);
				}
			}
			else
			{
				this.pfd = pfd;
				this.package = package;
				if (StoredData.BaseStream.Length > 0)
				{
					Unserialize(StoredData);
					processed = true;
				}
			}
		}

		public System.IO.BinaryReader StoredData
		{
			get
			{
				if ((pfd != null) && (package != null))
				{
					IPackedFile file = package.Read(pfd);
					return new System.IO.BinaryReader(
						new System.IO.MemoryStream(file.UncompressedData)
					);

					/*IPackedFile file = package.GetStream(pfd);
					return new System.IO.BinaryReader(file.UncompressedStream);*/
				}
				else
				{
					return new System.IO.BinaryReader(new System.IO.MemoryStream());
				}
			}
		}

		public virtual bool AllowMultipleInstances =>
					GetType()
						.GetInterface(
							"SimPe.Interfaces.Plugin.IMultiplePackedFileWrapper",
							false
						) == typeof(IMultiplePackedFileWrapper)
				;

		public virtual bool ReferencesResources =>
					GetType()
						.GetInterface(
							"SimPe.Interfaces.Plugin.IWrapperReferencedResources",
							false
						) == typeof(IWrapperReferencedResources)
				;

		public void RefreshUI()
		{
			UIHandler?.UpdateGUI((IFileWrapper)this);
		}

		public void Refresh()
		{
			ProcessData(FileDescriptor, Package);
			RefreshUI();
		}

		public void LoadUI()
		{
			RefreshUI();
		}

		/// <summary>
		/// The Priority of a Wrapper in the Registry
		/// </summary>
		public int Priority
		{
			get; set;
		}

		/// <summary>
		/// Get a Description for this Resource
		/// </summary>
		public virtual string Description => "";

		/// <summary>
		/// Get the Header for this Description(i.e. Fieldnames)
		/// </summary>
		public virtual string DescriptionHeader => "";

		/// <summary>
		/// Returns the 64 Character Long embedded Filename
		/// </summary>
		/// <param name="ta">The Current Type</param>
		/// <returns></returns>
		string GetEmbeddedFileName(FileTypeInformation fti)
		{
			return Package != null && FileDescriptor != null && fti.ContainsFileName
				? Helper.ToString(Package.Read(FileDescriptor).GetUncompressedData(0x40))
				: null;
		}

		/// <summary>
		/// Override this to add your own Implementation for <see cref="ResourceName"/>
		/// </summary>
		/// <param name="ta">The Current Type</param>
		/// <returns>null, if the Default Name should be generated</returns>
		protected virtual string GetResourceName(FileTypeInformation fti)
		{
			return null;
		}

		/// <summary>
		/// Get this Resource
		/// </summary>
		public string ResourceName
		{
			get
			{
				string res;
				if (FileDescriptor != null)
				{
					FileTypeInformation typeinfo = FileDescriptor.Type.ToFileTypeInformation();
					res = Helper.WindowsRegistry.Config.ResourceListFormat
						== Registry.ResourceListFormats.JustLongType
						? typeinfo.LongName
						: GetResourceName(typeinfo);

					if (res == null)
					{
						res = GetEmbeddedFileName(typeinfo);
					}

					if (res == null)
					{
						res = FileDescriptor.ToResListString();
					}
					else
					{
						if (
							Helper.WindowsRegistry.Config.ResourceListFormat
							== Registry.ResourceListFormats.LongTypeNames
						)
						{
							res = typeinfo.LongName + ": " + res;
						}
						else if (
							Helper.WindowsRegistry.Config.ResourceListFormat
							== Registry.ResourceListFormats.ShortTypeNames
						)
						{
							res = typeinfo.ShortName + ": " + res;
						}
						else if (res.Trim() == "")
						{
							res = "[" + typeinfo.LongName + "]";
						}
					}
				}
				else
				{
					res = Localization.GetString("Unknown");
				}

				return res;
			}
		}

		/// <summary>
		/// Return the content of the Files
		/// </summary>
		public virtual System.IO.MemoryStream Content => null;

		/// <summary>
		/// Returns the default Extension for this File
		/// </summary>
		public virtual string FileExtension => FileDescriptor.Type.ToFileTypeInformation().Extension;
		#endregion

		IFileWrapper guiwrapper;

		/// <summary>
		/// This is used to initialize single Gui Wrappers, in
		/// order to not corrupted when ResourceName is called
		/// </summary>
		public IFileWrapper SingleGuiWrapper
		{
			set => guiwrapper = value;
		}

		#region IMultiplePackedFileWrapper Member


		/// <summary>
		/// Create a new Instance of the Wrapper
		/// </summary>
		/// <returns>the new Instance</returns>
		public virtual IFileWrapper Activate()
		{
			if (!AllowMultipleInstances)
			{
				if (guiwrapper == null)
				{
					guiwrapper = (IFileWrapper)Activator.CreateInstance(GetType());
				}

				return guiwrapper;
			}
			else
			{
				IMultiplePackedFileWrapper me =
					(IMultiplePackedFileWrapper)this;
				return (IFileWrapper)
					Activator.CreateInstance(
						GetType(),
						me.GetConstructorArguments()
					);
			}
		}

		/// <summary>
		/// Returns a list of Arguments that should be passed to the Constructor during <see cref="Activate"/>.
		/// </summary>
		/// <returns></returns>
		public virtual object[] GetConstructorArguments()
		{
			return new object[0];
		}
		#endregion

		#region IDisposable Member
		public virtual void Dispose()
		{
			wrapperinfo?.Dispose();

			ui?.Dispose();

			ui = null;
			package = null;
			pfd = null;
		}
		#endregion
	}
}
