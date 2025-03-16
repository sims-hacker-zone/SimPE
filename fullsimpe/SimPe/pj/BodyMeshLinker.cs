// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.Interfaces;
using SimPe.Interfaces.Files;
using SimPe.PackedFiles.ThreeIdr;

namespace pj
{
	class BodyMeshLinker : AbstractTool, ITool
	{
		private IPackageFile currentPackage = null;
		private IPackedFileDescriptor refFilePFD = null;

		private string getFilename()
		{
			return null;
		}

		private void Main()
		{
			ThreeIdr refFile = new ThreeIdr();
			refFile.ProcessData(refFilePFD, currentPackage);

			if (LinkBodyMesh(refFile))
			{
				refFile.SynchronizeUserData();
			}
		}

		public bool LinkBodyMesh(ThreeIdr refFile)
		{
			if (
				refFile.Items[0].Type != SimPe.Data.FileTypes.CRES
				|| refFile.Items[1].Type != SimPe.Data.FileTypes.SHPE
			)
			{
				return false;
			}

			string meshPackage = getFilename();
			if (meshPackage == null || meshPackage.Length == 0)
			{
				return false;
			}

			IPackageFile p = null;
			try
			{
				p = SimPe.Packages.File.LoadFromFile(meshPackage);
			}
			catch
			{
				p = null;
			}
			if (p == null)
			{
				return false;
			}

			IPackedFileDescriptor[] pfa = p.FindFiles(SimPe.Data.FileTypes.CRES);
			IPackedFileDescriptor[] pfb = p.FindFiles(SimPe.Data.FileTypes.SHPE);
			if (pfa == null || pfa.Length != 1 || pfb == null || pfb.Length != 1)
			{
				return false;
			}

			refFile.Items[0].Group = pfa[0].Group;
			refFile.Items[0].SubType = pfa[0].SubType;
			refFile.Items[0].Instance = pfa[0].Instance;
			refFile.Items[1].Group = pfb[0].Group;
			refFile.Items[1].SubType = pfb[0].SubType;
			refFile.Items[1].Instance = pfb[0].Instance;

			return true;
		}

		#region ITool Members

		public bool IsEnabled(IPackedFileDescriptor pfd, IPackageFile package)
		{
			return package != null;
		}

		private bool IsReallyEnabled(IPackedFileDescriptor pfd, IPackageFile package)
		{
			currentPackage = package;
			refFilePFD = pfd != null && pfd.Type == SimPe.Data.FileTypes.THREE_IDR ? pfd : null;

			return package != null && refFilePFD != null;
		}

		public SimPe.Interfaces.Plugin.IToolResult ShowDialog(
			ref IPackedFileDescriptor pfd,
			ref IPackageFile package
		)
		{
			if (!IsReallyEnabled(pfd, package))
			{
				return new SimPe.Plugin.ToolResult(false, false);
			}
			Main();
			return new SimPe.Plugin.ToolResult(false, false);
		}

		#region IToolPlugin Members

		public override string ToString()
		{
			return L.Get("pjBMTLink");
		}

		#endregion
		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => SimPe.GetIcon.BMlinker;
		#endregion
	}
}
