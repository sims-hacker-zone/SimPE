// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Interfaces.Files;
using SimPe.PackedFiles.Cpf;

namespace SimPe.Plugin
{
	/// <summary>
	/// Set of old and new Guid
	/// </summary>
	public class GuidSet
	{
		public uint oldguid;
		public uint guid;
	}

	/// <summary>
	/// This class can Fix the Integrity of cloned Objects
	/// </summary>
	public class FixGuid
	{
		/// <summary>
		/// The Base Package
		/// </summary>
		protected IPackageFile package;

		/// <summary>
		/// Creates a new Instance of this class
		/// </summary>
		/// <param name="package">The package you want to fix the Integrity in</param>
		public FixGuid(IPackageFile package)
		{
			this.package = package;
		}

		/// <summary>
		/// Changes all guids (Depends on the passed Replacement Map)
		/// </summary>
		/// <param name="guids">List of GuidSet Objects</param>
		public void FixGuids(ArrayList guids)
		{
			IPackedFileDescriptor[] mpfds = package.FindFiles(
				Data.MetaData.MMAT
			);

			foreach (IPackedFileDescriptor pfd in mpfds)
			{
				Cpf mmat =
					new Cpf();
				mmat.ProcessData(pfd, package);

				if (guids != null)
				{
					foreach (GuidSet sget in guids)
					{
						if (
							mmat.GetSaveItem("objectGUID").UIntegerValue == sget.oldguid
						)
						{
							mmat.GetSaveItem("objectGUID").UIntegerValue = sget.guid;
							mmat.SynchronizeUserData();
						}
					}
				}
			}
		}

		/// <summary>
		/// Changes all guids (ignore the current GUID)
		/// </summary>
		/// <param name="newguid">The new GUID</param>
		public void FixGuids(uint newguid)
		{
			IPackedFileDescriptor[] mpfds = package.FindFiles(
				Data.MetaData.MMAT
			);

			foreach (IPackedFileDescriptor pfd in mpfds)
			{
				Cpf mmat =
					new Cpf();
				mmat.ProcessData(pfd, package);

				mmat.GetSaveItem("objectGUID").UIntegerValue = newguid;
				mmat.SynchronizeUserData();
			}
		}
	}
}
