/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using SimPe.Interfaces;
using SimPe.Interfaces.Files;

namespace pj
{
	public class BodyMeshExtractor : AbstractTool, ITool
	{
		private static List<string> packs = null;

		private static void SetPacks()
		{
			packs.Clear();
			foreach (SimPe.FileTableItem fii in SimPe.FileTableBase.DefaultFolders)
			{
				if (!fii.Use)
				{
					continue; // comment this out for errors
				}

				if (fii.IsFile && fii.Name.ToLowerInvariant().EndsWith(".package"))
				{
					packs.Insert(0, fii.Name);
				}
				else if (
					fii.Type.AsExpansions != SimPe.Expansions.Custom
					&& Directory.Exists(fii.Name)
				) // && Directory.Exists(fii.Name) or frows errors
				{
					if (
						fii.Name.ToLowerInvariant()
							.EndsWith(SimPe.Helper.PATH_SEP + "3d")
						|| fii.Name.ToLowerInvariant()
							.EndsWith(SimPe.Helper.PATH_SEP + "sims3d")
					)
					{
						AddPack(fii.Name, fii.IsRecursive);
					}
				}
			}
		}

		static void FileIndex_FILoad(object sender, EventArgs e)
		{
			SetPacks();
		}

		private static void AddPack(string folder, bool rec)
		{
			foreach (string pkg in Directory.GetFiles(folder, "*.package"))
			{
				if (
					pkg.ToLowerInvariant()
						.EndsWith(SimPe.Helper.PATH_SEP + "sims03.package")
					|| pkg.ToLowerInvariant()
						.EndsWith(SimPe.Helper.PATH_SEP + "sims04.package")
					|| pkg.ToLowerInvariant()
						.EndsWith(SimPe.Helper.PATH_SEP + "sims05.package")
					|| pkg.ToLowerInvariant()
						.EndsWith(SimPe.Helper.PATH_SEP + "sims06.package")
				)
				{
					packs.Add(pkg);
				}
			}
		}

		private IPackageFile currentPackage;

		private String getFilename()
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
				InitialDirectory = Path.Combine(
				SimPe.PathProvider.SimSavegameFolder,
				"SavedSims"
			),
				Multiselect = false,
				ReadOnlyChecked = true
			};
			ofd.ShowHelp = ofd.ShowReadOnly = false;
			ofd.Title = L.Get("selectPkgTexture");
			ofd.ValidateNames = true;
			DialogResult dr = ofd.ShowDialog();
			return DialogResult.OK.Equals(dr) ? ofd.FileName : null;
		}

		private bool findAndAdd(String name, uint type, String source)
		{
			foreach (string pkg in packs)
			{
				if (
					pkg.ToLowerInvariant()
						.EndsWith(SimPe.Helper.PATH_SEP + source.ToLowerInvariant())
				)
				{
					if (addFromPkg(name, type, pkg))
					{
						return true;
					}
				}
			}

			return false;
		}

		private bool addFromPkg(String name, uint type, String pkg)
		{
			IPackageFile p = SimPe.Packages.File.LoadFromFile(pkg);
			if (p == null)
			{
				return false;
			}

			IPackedFileDescriptor[] pfa = p.FindFiles(SimPe.Data.MetaData.NAME_MAP);
			if (pfa == null || pfa.Length != 1)
			{
				return false;
			}

			SimPe.Plugin.Nmap nmap = new SimPe.Plugin.Nmap(null);
			nmap.ProcessData(pfa[0], p);
			pfa = nmap.FindFiles(name + "_");
			if (pfa == null || pfa.Length != 1)
			{
				return false;
			}

			IPackedFileDescriptor pfd = null;
			for (int j = 0; j < p.Index.Length && pfd == null; j++)
			{
				if (
					p.Index[j].Type == type
					&& p.Index[j].Group == pfa[0].Group
					&& p.Index[j].Instance == pfa[0].Instance
				)
				{
					pfd = p.Index[j];
				}
			}

			if (pfd == null)
			{
				return false;
			}

			if (isInPFDList(currentPackage.Index, pfd))
			{
				return true;
			}

			IPackedFileDescriptor npfd = pfd.Clone();
			npfd.UserData = p.Read(pfd).UncompressedData;
			currentPackage.Add(npfd, true);
			return true;
		}

		private bool isInPFDList(
			IPackedFileDescriptor[] pfdList,
			IPackedFileDescriptor pfd
		)
		{
			foreach (IPackedFileDescriptor i in pfdList)
			{
				if (i.Filename.Equals(pfd.Filename))
				{
					return true;
				}
			}

			return false;
		}

		private bool linkemall(IPackedFileDescriptor pfd)
		{
			if (isInPFDList(currentPackage.Index, pfd))
			{
				return true; // should prevent doubling up
			}

			IPackageFile p = null;
			IPackedFileDescriptor pfa = null;
			bool found = false;
			// find 'im Cres
			foreach (string pkg in packs)
			{
				p = SimPe.Packages.File.LoadFromFile(pkg);
				pfa = p.FindFile(pfd);
				if (pfa != null)
				{
					IPackedFileDescriptor npfd = pfa.Clone();
					npfd.UserData = p.Read(pfa).UncompressedData;
					currentPackage.Add(npfd, true);
					break; // pfa is now the CRES
				}
			}
			if (pfa == null)
			{
				return found;
			}
			// find 'im Shape
			SimPe.Plugin.GenericRcol grl = new SimPe.Plugin.GenericRcol(null, false);
			grl.ProcessData(pfa, p);
			found = false;
			foreach (IPackedFileDescriptor pfb in grl.ReferencedFiles)
			{
				if (pfb.Type == SimPe.Data.MetaData.SHPE)
				{
					pfa = pfb;
					found = true;
					break; // pfa is now the Shape
				}
			}
			if (!found)
			{
				return false;
			}

			found = false;
			foreach (string pkg in packs)
			{
				p = SimPe.Packages.File.LoadFromFile(pkg);
				IPackedFileDescriptor pfb = p.FindFile(pfa);
				if (pfb != null)
				{
					IPackedFileDescriptor npfd = pfb.Clone();
					npfd.UserData = p.Read(pfb).UncompressedData;
					currentPackage.Add(npfd, true);
					pfa = pfb;
					found = true;
					break; // pfa is now the Shape
				}
			}
			if (!found)
			{
				return false;
			}
			// find 'im GMND
			SimPe.Plugin.GenericRcol grn = new SimPe.Plugin.GenericRcol(null, false);
			grn.ProcessData(pfa, p);
			SimPe.Plugin.Shape shp = (SimPe.Plugin.Shape)grn.Blocks[0];
			string gmndee = null;

			foreach (SimPe.Plugin.ShapeItem si in shp.Items)
			{
				if (si.FileName.ToLower().EndsWith("gmnd"))
				{
					gmndee = si.FileName;
				}
			}

			if (gmndee == null)
			{
				return false;
			}

			SimPe.Interfaces.Scenegraph.IScenegraphFileIndexItem item =
				SimPe.FileTableBase.FileIndex.FindFileByName(
					gmndee,
					SimPe.Data.MetaData.GMND,
					SimPe.Data.MetaData.GLOBAL_GROUP,
					true
				);
			if (item == null)
			{
				return false;
			}

			pfa = item.FileDescriptor; // pfa now is GMND
			p = item.Package;
			IPackedFileDescriptor npfg = pfa.Clone();
			npfg.UserData = p.Read(pfa).UncompressedData;
			currentPackage.Add(npfg, true);
			// find 'im GMDC
			found = false;
			SimPe.Plugin.GenericRcol grd = new SimPe.Plugin.GenericRcol(null, false);
			grd.ProcessData(pfa, p);

			foreach (IPackedFileDescriptor pfb in grd.ReferencedFiles)
			{
				if (pfb.Type == SimPe.Data.MetaData.GMDC)
				{
					pfa = pfb;
					found = true;
					break; // pfa is now the GMDC
				}
			}
			if (!found)
			{
				return false;
			}

			found = false;
			foreach (string pkg in packs)
			{
				p = SimPe.Packages.File.LoadFromFile(pkg);
				IPackedFileDescriptor pfb = p.FindFile(pfa);
				if (pfb != null)
				{
					IPackedFileDescriptor npfd = pfb.Clone();
					npfd.UserData = p.Read(pfb).UncompressedData;
					currentPackage.Add(npfd, true);
					pfa = pfb;
					found = true;
					break; // pfa is now the GMDC
				}
			}
			return found;
		}

		// Entry Point
		private void Main()
		{
			ArrayList al = new ArrayList();
			bool gotem = false;

			#region Prompt for mesh name or browse for package and extract names
			GetMeshName gmn = new GetMeshName();
			DialogResult dr = gmn.ShowDialog();
			if (dr.Equals(DialogResult.OK))
			{
				if (gmn.MeshName.Length > 0)
				{
					al.Add(gmn.MeshName);
				}
				else
				{
					MessageBox.Show(
						L.Get("noMeshName"),
						L.Get("pjSME"),
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
					);
					return;
				}
			}
			else if (dr.Equals(DialogResult.Retry)) // nasty... Result of Browse button which is required
			{
				#region Get body mesh package file name and open the package
				String bodyMeshPackage = getFilename();
				if (bodyMeshPackage == null)
				{
					return;
				}

				IPackageFile p = SimPe.Packages.File.LoadFromFile(bodyMeshPackage);
				if (p == null)
				{
					return;
				}
				#endregion

				#region Find the Property Set or XML Mesh Overlay
				if (Settings.BodyMeshExtractUseCres)
				{
					IPackedFileDescriptor[] pf3d = p.FindFiles(
						SimPe.Data.MetaData.REF_FILE
					);
					if (pf3d != null && pf3d.Length > 0)
					{
						SimPe.Plugin.RefFile refl = new SimPe.Plugin.RefFile();
						for (int i = 0; i < pf3d.Length; i++)
						{
							refl.ProcessData(pf3d[i], p);
							for (int j = 0; j < refl.Items.Length; j++)
							{
								if (refl.Items[j].Type == SimPe.Data.MetaData.CRES)
								{
									gotem = linkemall(refl.Items[j]);
									break;
								}
							}
						}
					}
				}
				if (!gotem)
				{
					IPackedFileDescriptor[] pfa = p.FindFiles(SimPe.Data.MetaData.GZPS);
					IPackedFileDescriptor[] pfb = p.FindFiles(0x0C1FE246); // XMOL?
					if (
						(pfa == null || pfa.Length == 0)
						&& (pfb == null || pfb.Length == 0)
					)
					{
						MessageBox.Show(
							L.Get("noGZPSXMOL"),
							L.Get("pjSME"),
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
						);
						return;
					}
					#endregion

					#region Get the mesh name(s)
					bool prompted = false;
					SimPe.PackedFiles.Wrapper.Cpf cpf =
						new SimPe.PackedFiles.Wrapper.Cpf();
					for (int i = 0; i < pfa.Length + pfb.Length; i++)
					{
						if (i < pfa.Length)
						{
							cpf.ProcessData(pfa[i], p);
						}
						else
						{
							cpf.ProcessData(pfb[i - pfa.Length], p);
						}

						for (int j = 0; j < cpf.Items.Length; j++)
						{
							if (cpf.Items[j].Name.ToLower().Equals("name"))
							{
								al.Add(cpf.Items[j].StringValue);
							}

							if (al.Count > 1 && !prompted)
							{
								if (
									MessageBox.Show(
										L.Get("multipleMeshes"),
										L.Get("pjSME"),
										MessageBoxButtons.YesNo,
										MessageBoxIcon.Warning
									) != DialogResult.Yes
								)
								{
									return;
								}

								prompted = true;
							}
						}
					}
					if (al.Count == 0)
					{
						MessageBox.Show(
							L.Get("noMeshPkg"),
							L.Get("pjSME"),
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
						);
						return;
					}
					#endregion
				}
			}
			else
			{
				return;
			}

			#endregion

			#region For each mesh, find the GMDC, GMND, SHPE and CRES and add them to the current package

			foreach (String m in al)
			{
				String[] ma = m.Split(new char[] { '_' });
				String mesh = ma[ma[0].Equals("CASIE") ? 1 : 0];
				if (mesh.ToLower().StartsWith("ym"))
				{
					mesh = "am" + mesh.Substring(2);
				}

				if (mesh.ToLower().StartsWith("yf"))
				{
					mesh = "af" + mesh.Substring(2);
				}

				bool success = true;
				SimPe.RemoteControl.ApplicationForm.Cursor = Cursors.WaitCursor;
				success =
					success
					&& findAndAdd(mesh, SimPe.Data.MetaData.GMDC, "Sims03.package");
				success =
					success
					&& findAndAdd(mesh, SimPe.Data.MetaData.GMND, "Sims04.package");
				success =
					success
					&& findAndAdd(mesh, SimPe.Data.MetaData.SHPE, "Sims05.package");
				success =
					success
					&& findAndAdd(mesh, SimPe.Data.MetaData.CRES, "Sims06.package");
				SimPe.RemoteControl.ApplicationForm.Cursor = Cursors.Default;
				if (!success)
				{
					MessageBox.Show(
						L.Get("notAllPartsFound") + m,
						L.Get("pjSME"),
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);
				}
			}
			#endregion
		}

		#region ITool Members

		public bool IsEnabled(IPackedFileDescriptor pfd, IPackageFile package)
		{
			return (package != null);
		}

		public SimPe.Interfaces.Plugin.IToolResult ShowDialog(
			ref IPackedFileDescriptor pfd,
			ref IPackageFile package
		)
		{
			currentPackage = package;
			if (packs == null)
			{
				packs = new List<string>();
				SetPacks();
				SimPe.FileTableBase.FileIndex.FILoad += new EventHandler(FileIndex_FILoad);
			}
			Main();
			return new SimPe.Plugin.ToolResult(false, false);
		}

		#region IToolPlugin Members

		public override string ToString()
		{
			return L.Get("pjBMTExtract");
		}

		#endregion
		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => SimPe.GetIcon.BMExtract;
		#endregion
	}
}
