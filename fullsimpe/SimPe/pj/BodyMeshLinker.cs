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
			OpenFileDialog ofd = new OpenFileDialog
			{
				AddExtension = true,
				CheckFileExists = true,
				CheckPathExists = true,
				DefaultExt = ".package",
				DereferenceLinks = true,
				FileName = "",
				Filter = L.Get("pkgFilter"),
				FilterIndex = 0,
				InitialDirectory = System.IO.Path.Combine(
				SimPe.PathProvider.SimSavegameFolder,
				"SavedSims"
			),
				Multiselect = false,
				ReadOnlyChecked = true
			};
			ofd.ShowHelp = ofd.ShowReadOnly = false;
			ofd.Title = L.Get("selectPkgMesh");
			ofd.ValidateNames = true;
			DialogResult dr = ofd.ShowDialog();
			return DialogResult.OK.Equals(dr) ? ofd.FileName : null;
		}

		private void Main()
		{
			if (
				!MessageBox
					.Show(
						L.Get("pjSMLbegin"),
						L.Get("pjSML"),
						MessageBoxButtons.OKCancel,
						MessageBoxIcon.Information
					)
					.Equals(DialogResult.OK)
			)
			{
				return;
			}

			ThreeIdr refFile = new ThreeIdr();
			refFile.ProcessData(refFilePFD, currentPackage);

			if (LinkBodyMesh(refFile))
			{
				refFile.SynchronizeUserData();
				MessageBox.Show(
					L.Get("pjSMLdone"),
					L.Get("pjSML"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
			}
		}

		public bool LinkBodyMesh(ThreeIdr refFile)
		{
			if (
				refFile.Items[0].Type != SimPe.Data.MetaData.CRES
				|| refFile.Items[1].Type != SimPe.Data.MetaData.SHPE
			)
			{
				MessageBox.Show(
					L.Get("noCRESSHPE"),
					L.Get("pjSML"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
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
				MessageBox.Show(
					L.Get("didNotOpen") + "\r\n" + meshPackage,
					L.Get("pjSML"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
				return false;
			}

			IPackedFileDescriptor[] pfa = p.FindFiles(SimPe.Data.MetaData.CRES);
			IPackedFileDescriptor[] pfb = p.FindFiles(SimPe.Data.MetaData.SHPE);
			if (pfa == null || pfa.Length != 1 || pfb == null || pfb.Length != 1)
			{
				MessageBox.Show(
					L.Get("badMeshPackage") + "\r\n" + meshPackage,
					L.Get("pjSML"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
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
			refFilePFD = pfd != null && pfd.Type == SimPe.Data.MetaData.REF_FILE ? pfd : null;

			return package != null && refFilePFD != null;
		}

		public SimPe.Interfaces.Plugin.IToolResult ShowDialog(
			ref IPackedFileDescriptor pfd,
			ref IPackageFile package
		)
		{
			if (!IsReallyEnabled(pfd, package))
			{
				MessageBox.Show(
					SimPe.Localization.GetString(
						"This is not an appropriate context in which to use this tool"
					),
					L.Get("pjSML")
				);
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
