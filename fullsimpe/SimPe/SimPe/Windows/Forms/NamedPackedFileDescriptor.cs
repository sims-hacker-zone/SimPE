namespace SimPe.Windows.Forms
{
	public class NamedPackedFileDescriptor
	{
		Interfaces.Files.IPackageFile pkg;
		string realname;

		public NamedPackedFileDescriptor(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile pkg
		)
		{
			Descriptor = pfd;
			this.pkg = pkg;
			Resource = new Plugin.FileIndexItem(pfd, pkg);
			realname = null;
		}

		public Plugin.FileIndexItem Resource
		{
			get;
		}

		public Interfaces.Files.IPackedFileDescriptor Descriptor
		{
			get;
		}

		public bool RealNameLoaded => realname != null;

		public void ResetRealName()
		{
			realname = null;
		}

		public string GetRealName()
		{
			if (realname == null)
			{
				if (Helper.WindowsRegistry.DecodeFilenamesState)
				{
					Interfaces.Plugin.Internal.IPackedFileWrapper wrp =
						FileTableBase.WrapperRegistry.FindHandler(Descriptor.Type);
					if (wrp != null)
					{
						lock (wrp)
						{
							//System.Diagnostics.Debug.WriteLine("Processing " + pfd.Type.ToString("X")+" "+pfd.Offset.ToString("X"));
							Interfaces.Files.IPackedFileDescriptor bakpfd = null;
							Interfaces.Files.IPackageFile bakpkg = null;
							if (wrp is Interfaces.Plugin.AbstractWrapper)
							{
								Interfaces.Plugin.AbstractWrapper awrp =
									(Interfaces.Plugin.AbstractWrapper)wrp;
								if (!awrp.AllowMultipleInstances)
								{
									bakpfd = awrp.FileDescriptor;
									bakpkg = awrp.Package;
								}

								awrp.FileDescriptor = Descriptor;
								awrp.Package = pkg;
							}
							try
							{
								realname = wrp.ResourceName;
							}
							catch
							{
								realname = Descriptor.ToResListString();
							}
							finally
							{
								if (bakpfd != null || bakpkg != null)
								{
									if (wrp is Interfaces.Plugin.AbstractWrapper)
									{
										Interfaces.Plugin.AbstractWrapper awrp =
											(Interfaces.Plugin.AbstractWrapper)wrp;
										if (!awrp.AllowMultipleInstances)
										{
											awrp.FileDescriptor = bakpfd;
											awrp.Package = bakpkg;
										}
									}
								}
							}
						} //lock
					}
				}
				if (realname == null)
				{
					realname = Descriptor.ToResListString();
				}
			}

			return realname;
		}
	}
}
