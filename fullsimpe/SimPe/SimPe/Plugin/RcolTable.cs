// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Interfaces.Files;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for RcolTable.
	/// </summary>
	public class RcolTable : List<Rcol>
	{
		public RcolTable() : base()
		{
		}

		public Rcol FindByReference(string reference)
		{
			return FindByReference(ResourceReference.Parse(reference));
		}

		public Rcol FindByReference(ResourceReference reference)
		{
			return (from rcol in this
					where rcol.FileDescriptor != null
					let rcolRef = new ResourceReference(rcol.FileDescriptor)
					where rcolRef == reference
					select rcol).FirstOrDefault();
		}

		public Rcol FindByInstance(uint instance)
		{
			return (from rcol in this
					where rcol.FileDescriptor != null
					where rcol.FileDescriptor.Instance == instance
					select rcol).FirstOrDefault();
		}

		public IEnumerable<IPackedFileDescriptor> GetFileDescriptor()
		{
			return from rcol in this
				   select rcol.FileDescriptor;
		}

		public void SynchronizeAll()
		{
			foreach (Rcol rcol in this)
			{
				rcol.SynchronizeUserData();
			}
		}
	}
}
