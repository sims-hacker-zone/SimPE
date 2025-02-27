using System;

namespace SimPe.Windows.Forms
{
	public interface IResourceViewFilter
	{
		bool Active
		{
			get;
		}
		bool IsFiltered(Interfaces.Files.IPackedFileDescriptor pfd);
		event EventHandler ChangedFilter;
	}
}
