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
using SimPe.Interfaces.Plugin;

namespace pj
{
	public class cObjKeyTool : AbstractTool, ITool
	{
		// TSData\Res\3D:
		private static List<String> txmtpkg; // Objects02, Sims02, CarryForward.sgfiles
		private static List<String> gmdcpkg; // Objects03, Sims03, CarryForward.sgfiles
		private static List<String> gmndpkg; // Objects04, Sims04, CarryForward.sgfiles
		private static List<String> shpepkg; // Objects06, Sims05, CarryForward.sgfiles
		private static List<String> crespkg; // Objects05, Sims06, CarryForward.sgfiles
		private static List<String> txtrpkg; // Objects07, Sims07, Textures, CarryForward.sgfiles
		private static List<String> lifopkg; // Objects07-09, Sims08/9/11-13, Textures, CarryForward.sgfiles

		// TSData\Res\Catalog:
		private static List<String> objkeys; // Skins\Skins
		private static List<String> fragkeys; // Bins\globalcatbin.bundle
		private static List<String> binkeys; // Bins\globalcatbin.bundle

		private static void addPackages(
			ref List<String> packs,
			String path,
			String[] posspacks
		)
		{
			foreach (String p in posspacks)
			{
				if (File.Exists(p))
				{
					packs.Add(p);
				}
				else if (File.Exists(Path.Combine(path, p)))
				{
					packs.Add(Path.Combine(path, p));
				}
				else if (File.Exists(Path.Combine(path, p + ".package")))
				{
					packs.Add(Path.Combine(path, p + ".package"));
				}
			}
		}

		private static void addPackages(ref List<String> packs, String path, bool rec)
		{
			addPackages(ref packs, path, Directory.GetFiles(path, "*.package"));
			if (rec)
			{
				foreach (String folder in Directory.GetDirectories(path))
				{
					addPackages(ref packs, Path.Combine(path, folder), rec);
				}
			}
		}

		private static void SetPacks()
		{
			txmtpkg = new List<String>();
			gmdcpkg = new List<String>();
			gmndpkg = new List<String>();
			shpepkg = new List<String>();
			crespkg = new List<String>();
			txtrpkg = new List<String>();
			lifopkg = new List<String>();
			objkeys = new List<String>();
			fragkeys = new List<String>();
			binkeys = new List<String>();
			List<String>[] lls = new List<String>[]
			{
				txmtpkg,
				gmdcpkg,
				gmndpkg,
				shpepkg,
				crespkg,
				txtrpkg,
				lifopkg,
				objkeys,
				fragkeys,
				binkeys,
			};

			foreach (SimPe.FileTableItem fii in SimPe.FileTable.DefaultFolders)
			{
				if (!fii.Use)
				{
					continue;
				}

				if (fii.IsFile)
				{
					for (int i = 0; i < lls.Length; i++)
					{
						addPackages(ref lls[i], "", new String[] { fii.Name });
					}
				}
				else if (fii.Type.AsExpansions == SimPe.Expansions.Custom)
				{
					for (int i = 0; i < lls.Length; i++)
					{
						addPackages(ref lls[i], fii.Name, fii.IsRecursive);
					}
				}
				else if (fii.Name.ToLowerInvariant().EndsWith("3d"))
				{
					addPackages(
						ref txmtpkg,
						fii.Name,
						new String[] { "Objects02", "Sims02", "CarryForward.sgfiles" }
					);
					addPackages(
						ref gmdcpkg,
						fii.Name,
						new String[] { "Objects03", "Sims03", "CarryForward.sgfiles" }
					);
					addPackages(
						ref gmndpkg,
						fii.Name,
						new String[] { "Objects04", "Sims04", "CarryForward.sgfiles" }
					);
					addPackages(
						ref shpepkg,
						fii.Name,
						new String[] { "Objects06", "Sims05", "CarryForward.sgfiles" }
					);
					addPackages(
						ref crespkg,
						fii.Name,
						new String[] { "Objects05", "Sims06", "CarryForward.sgfiles" }
					);
					addPackages(
						ref txtrpkg,
						fii.Name,
						new String[]
						{
							"Objects07",
							"Sims07",
							"Textures",
							"CarryForward.sgfiles",
						}
					);
					addPackages(
						ref lifopkg,
						fii.Name,
						new String[]
						{
							"Objects07",
							"Objects08",
							"Objects09",
							"Sims08",
							"Sims09",
							"Sims11",
							"Sims12",
							"Sims13",
							"Textures",
							"CarryForward.sgfiles",
						}
					);
				}
				else if (
					fii
						.Name.ToLowerInvariant()
						.EndsWith(SimPe.Helper.PATH_SEP + "skins")
				)
				{
					addPackages(ref objkeys, fii.Name, new String[] { "Skins" });

					string name = fii.Name.Replace(
						SimPe.Helper.PATH_SEP + "Skins",
						SimPe.Helper.PATH_SEP + "Bins"
					);
					if (Directory.Exists(name))
					{
						foreach (String pkg in Directory.GetFiles(name, "*.package"))
						{
							if (!pkg.ToLowerInvariant().Contains("globalcatbin."))
							{
								fragkeys.Add(pkg);
								binkeys.Add(pkg);
							}
						}

						addPackages(
							ref fragkeys,
							name,
							new String[] { "globalcatbin.bundle" }
						);
						addPackages(
							ref binkeys,
							name,
							new String[] { "globalcatbin.bundle" }
						);
					}
				}
			}
		}

		static void FileIndex_FILoad(object sender, EventArgs e)
		{
			SetPacks();
		}

		private bool has3idr(IPackedFileDescriptor pfd, IPackageFile package)
		{
			if (pfd == null || package == null)
			{
				return false;
			}

			return findInPackagelist(objkeys, SimPe.Data.MetaData.REF_FILE, pfd)
				!= null;
		}

		private bool hasCpf(IPackedFileDescriptor pfd, IPackageFile package)
		{
			if (pfd == null || package == null)
			{
				return false;
			}

			foreach (
				uint t in new uint[]
				{
					0x0C1FE246 /*XMOL*/
					,
					0x2C1FD8A1 /*XTOL*/
					,
					SimPe.Data.MetaData.GZPS,
				}
			)
			{
				if (findInPackagelist(objkeys, t, pfd) != null)
				{
					return true;
				}
			}

			return false;
		}

		private void makeCpf3idrPair()
		{
			objKeyCPF = null;
			objKey3IDR = null;
			if (currentPfd == null || currentPackage == null)
			{
				return;
			}

			if (
				currentPfd.Type == 0x0C1FE246 /*XMOL*/
				|| currentPfd.Type == 0x2C1FD8A1 /*XTOL*/
				|| currentPfd.Type == SimPe.Data.MetaData.GZPS
			)
			{
				AbstractWrapper p3 = findInPackagelist(
					objkeys,
					SimPe.Data.MetaData.REF_FILE,
					currentPfd
				);
				if (p3 != null)
				{
					objKeyCPF = new SimPe.PackedFiles.Wrapper.Cpf();
					objKeyCPF.ProcessData(currentPfd, currentPackage);
					addFile(p3);
					objKey3IDR = new SimPe.Plugin.RefFile();
					objKey3IDR.ProcessData(p3.FileDescriptor, p3.Package);
				}
			}
			else if (
				currentPfd.Type == SimPe.Data.MetaData.REF_FILE /*3IDR*/
			)
			{
				foreach (
					uint t in new uint[]
					{
						0x0C1FE246 /*XMOL*/
						,
						0x2C1FD8A1 /*XTOL*/
						,
						SimPe.Data.MetaData.GZPS,
					}
				)
				{
					AbstractWrapper pc =
						(SimPe.PackedFiles.Wrapper.Cpf)findInPackagelist(
							objkeys,
							t,
							currentPfd
						);
					if (pc != null)
					{
						addFile(pc);
						objKeyCPF = new SimPe.PackedFiles.Wrapper.Cpf();
						objKeyCPF.ProcessData(pc.FileDescriptor, pc.Package);
						objKey3IDR = new SimPe.Plugin.RefFile();
						objKey3IDR.ProcessData(currentPfd, currentPackage);
						break;
					}
				}
			}
		}

		AbstractWrapper findInPackagelist(
			List<string> pkgs,
			uint Filetype,
			IPackedFileDescriptor pfd
		)
		{
			foreach (String pkg in pkgs)
			{
				AbstractWrapper tgt = findInPackage(pkg, Filetype, pfd);
				if (tgt != null)
				{
					return tgt;
				}
			}
			return null;
		}

		AbstractWrapper findInPackage(
			String pkg,
			uint Filetype,
			IPackedFileDescriptor pfd
		)
		{
			IPackageFile p = SimPe.Packages.File.LoadFromFile(pkg);
			if (p == null)
			{
				return null;
			}

			IPackedFileDescriptor pt = p.FindFile(
				Filetype,
				pfd.SubType,
				pfd.Group,
				pfd.Instance
			);
			if (pt == null)
			{
				return null;
			}

			AbstractWrapper tgt;
			if (Filetype == SimPe.Data.MetaData.REF_FILE)
			{
				tgt = new SimPe.Plugin.RefFile();
			}
			else
			{
				tgt = new SimPe.PackedFiles.Wrapper.Cpf();
			}
			tgt.ProcessData(pt, p);
			return tgt;
		}

		private AbstractWrapper[] getCpf3idrPair(
			SimPe.PackedFiles.Wrapper.Cpf srcCpf,
			SimPe.Plugin.RefFile src3idr,
			String cpfItemKey,
			List<String> pkgs
		)
		{
			SimPe.PackedFiles.Wrapper.CpfItem cpfItem = srcCpf.GetItem(cpfItemKey);
			if (
				cpfItem == null
				|| cpfItem.Datatype != SimPe.Data.MetaData.DataTypes.dtUInteger
			)
			{
				return null;
			}

			foreach (String pkg in pkgs)
			{
				AbstractWrapper[] tgt = getCpf3idrPairInPkg(
					src3idr.Items[cpfItem.UIntegerValue],
					pkg
				);
				if (tgt != null)
				{
					return tgt;
				}
			}
			return null;
		}

		private AbstractWrapper[] getCpf3idrPairInPkg(
			IPackedFileDescriptor tgtpfd,
			String pkg
		)
		{
			IPackageFile p = SimPe.Packages.File.LoadFromFile(pkg);
			if (p == null)
			{
				return null;
			}

			IPackedFileDescriptor pc = p.FindFile(tgtpfd);
			if (pc == null)
			{
				return null;
			}

			IPackedFileDescriptor p3 = p.FindFile(
				SimPe
					.Data
					.MetaData
					.REF_FILE /*3IDR*/
				,
				pc.SubType,
				pc.Group,
				pc.Instance
			);
			if (p3 == null)
			{
				return null;
			}

			AbstractWrapper[] tgt = new AbstractWrapper[]
			{
				new SimPe.PackedFiles.Wrapper.Cpf(),
				new SimPe.Plugin.RefFile(),
			};
			tgt[0].ProcessData(pc, p);
			tgt[1].ProcessData(p3, p);

			return tgt;
		}

		private SimPe.Plugin.GenericRcol getRcol(
			SimPe.PackedFiles.Wrapper.Cpf srcCpf,
			SimPe.Plugin.RefFile src3idr,
			String cpfItemKey,
			List<String> pkgs
		)
		{
			SimPe.PackedFiles.Wrapper.CpfItem cpfItem = srcCpf.GetItem(cpfItemKey);
			if (
				cpfItem == null
				|| cpfItem.Datatype != SimPe.Data.MetaData.DataTypes.dtUInteger
			)
			{
				return null;
			}

			foreach (String pkg in pkgs)
			{
				SimPe.Plugin.GenericRcol tgt = getRcolPkg(
					src3idr.Items[cpfItem.UIntegerValue],
					pkg
				);
				if (tgt != null)
				{
					return tgt;
				}
			}
			return null;
		}

		private SimPe.Plugin.GenericRcol getRcol(
			IPackedFileDescriptor tgtpfd,
			List<String> pkgs
		)
		{
			foreach (String pkg in pkgs)
			{
				SimPe.Plugin.GenericRcol tgt = getRcolPkg(tgtpfd, pkg);
				if (tgt != null)
				{
					return tgt;
				}
			}
			return null;
		}

		private SimPe.Plugin.GenericRcol getRcolPkg(
			IPackedFileDescriptor tgtpfd,
			String pkg
		)
		{
			IPackageFile p = SimPe.Packages.File.LoadFromFile(pkg);
			if (p == null)
			{
				return null;
			}

			IPackedFileDescriptor pr = p.FindFile(tgtpfd);
			if (pr == null)
			{
				return null;
			}

			SimPe.Plugin.GenericRcol tgt = new SimPe.Plugin.GenericRcol();
			tgt.ProcessData(pr, p);

			return tgt;
		}

		private SimPe.Plugin.GenericRcol getRcol(String filename, List<String> pkgs)
		{
			foreach (String pkg in pkgs)
			{
				SimPe.Plugin.GenericRcol tgt = getRcolPkg(filename, pkg);
				if (tgt != null)
				{
					return tgt;
				}
			}
			return null;
		}

		private SimPe.Plugin.GenericRcol getRcolPkg(String filename, String pkg)
		{
			IPackageFile p = SimPe.Packages.File.LoadFromFile(pkg);
			if (p == null)
			{
				return null;
			}

			IPackedFileDescriptor[] apr = p.FindFile(filename);
			if (apr == null || apr.Length != 1)
			{
				return null;
			}

			SimPe.Plugin.GenericRcol tgt = new SimPe.Plugin.GenericRcol();
			tgt.ProcessData(apr[0], p);

			return tgt;
		}

		private List<AbstractWrapper[]> findFragKeys()
		{
			List<AbstractWrapper[]> fragKeys = new List<AbstractWrapper[]>();

			foreach (String pkg in fragkeys)
			{
				IPackageFile p = SimPe.Packages.File.LoadFromFile(pkg);
				if (p == null)
				{
					continue;
				}

				IPackedFileDescriptor[] apfd = p.FindFiles(
					0x0C560F39 /*BINX*/
				);
				SimPe.Wait.SubStart(apfd.Length);
				foreach (IPackedFileDescriptor bx in apfd)
				{
					try
					{
						// is there a paired 3idr?
						IPackedFileDescriptor pfd = p.FindFile(
							SimPe
								.Data
								.MetaData
								.REF_FILE /*3IDR*/
							,
							bx.SubType,
							bx.Group,
							bx.Instance
						);
						if (pfd == null)
						{
							continue;
						}

						// load the pair
						SimPe.Plugin.RefFile fk3idr = new SimPe.Plugin.RefFile();
						fk3idr.ProcessData(pfd, p);
						SimPe.PackedFiles.Wrapper.Cpf fkCpf =
							new SimPe.PackedFiles.Wrapper.Cpf();
						fkCpf.ProcessData(bx, p);

						// does the pair point to the object we're working on?
						SimPe.PackedFiles.Wrapper.CpfItem objKeyIdx = fkCpf.GetItem(
							"objectidx"
						);
						if (
							objKeyIdx == null
							|| objKeyIdx.Datatype
								!= SimPe.Data.MetaData.DataTypes.dtUInteger
						)
						{
							continue;
						}

						if (!fk3idr.Items[objKeyIdx.UIntegerValue].Equals(objKeyCPF))
						{
							continue;
						}

						// success - save the fragkey
						fragKeys.Add(new AbstractWrapper[] { fkCpf, fk3idr });
					}
					finally
					{
						SimPe.Wait.Progress++;
					}
				}
				SimPe.Wait.SubStop();
			}
			return fragKeys;
		}

		private List<AbstractWrapper[]> findBinKeys(List<AbstractWrapper[]> fragKeys)
		{
			List<AbstractWrapper[]> binKeys = new List<AbstractWrapper[]>();
			SimPe.Wait.SubStart(fragkeys.Count);
			foreach (AbstractWrapper[] fk in fragKeys)
			{
				AbstractWrapper[] tgt = getCpf3idrPair(
					(SimPe.PackedFiles.Wrapper.Cpf)fk[0],
					(SimPe.Plugin.RefFile)fk[1],
					"binidx",
					binkeys
				);
				if (tgt != null)
				{
					binKeys.Add(tgt);
				}

				SimPe.Wait.Progress++;
			}
			SimPe.Wait.SubStop();
			return binKeys;
		}

		private List<SimPe.Plugin.GenericRcol> findrcolChain()
		{
			List<SimPe.Plugin.GenericRcol> rcolChain =
				new List<SimPe.Plugin.GenericRcol>();

			SimPe.Plugin.GenericRcol tgt = null;

			foreach (String s in new String[] { "shapekeyidx", "maskshapekeyidx" })
			{
				tgt = getRcol(objKeyCPF, objKey3IDR, s, shpepkg);
				if (tgt != null)
				{
					rcolChain.Add(tgt);
					foreach (IPackedFileDescriptor i in tgt.ReferencedFiles)
					{
						if (i.Type == SimPe.Data.MetaData.GMND)
						{
							SimPe.Plugin.GenericRcol gmnd = getRcol(i, gmndpkg);
							if (gmnd != null)
							{
								rcolChain.Add(gmnd);
								foreach (
									IPackedFileDescriptor j in gmnd.ReferencedFiles
								)
								{
									if (j.Type == SimPe.Data.MetaData.GMDC)
									{
										SimPe.Plugin.GenericRcol gmdc = getRcol(
											j,
											gmdcpkg
										);
										if (gmdc != null)
										{
											rcolChain.Add(gmdc);
										}
									}
								}
							}
						}
						else if (i.Type == SimPe.Data.MetaData.TXMT)
						{
							SimPe.Plugin.GenericRcol txmt = getRcol(i, txmtpkg);
							if (txmt != null)
							{
								rcolChain.Add(txmt);
								findMaterials(ref rcolChain, txmt);
							}
						}
					}
				}
			}

			foreach (
				String s in new String[] { "resourcekeyidx", "maskresourcekeyidx" }
			)
			{
				tgt = getRcol(objKeyCPF, objKey3IDR, s, crespkg);
				if (tgt != null)
				{
					rcolChain.Add(tgt);
				}
			}

			uint numOverrides = 0;
			SimPe.PackedFiles.Wrapper.CpfItem cpfItem = objKeyCPF.GetItem(
				"numoverrides"
			);
			if (cpfItem.Datatype == SimPe.Data.MetaData.DataTypes.dtUInteger)
			{
				numOverrides = cpfItem.UIntegerValue;
			}

			for (int i = 0; i < numOverrides; i++)
			{
				tgt = getRcol(
					objKeyCPF,
					objKey3IDR,
					"override" + i.ToString() + "resourcekeyidx",
					txmtpkg
				);
				if (tgt != null)
				{
					rcolChain.Add(tgt);
					findMaterials(ref rcolChain, tgt);
				}
			}

			return rcolChain;
		}

		private void findMaterials(
			ref List<SimPe.Plugin.GenericRcol> rcolChain,
			SimPe.Plugin.GenericRcol txmt
		)
		{
			ArrayList txtrs = (ArrayList)txmt.ReferenceChains["stdMatBaseTextureName"]; //["TXTR"];
			if (txtrs != null && txtrs.Count > 0)
			{
				SimPe.Plugin.GenericRcol txtr = getRcol(
					(IPackedFileDescriptor)txtrs[0],
					txtrpkg
				);
				if (txtr != null)
				{
					rcolChain.Add(txtr);
					foreach (SimPe.Plugin.ImageData id in txtr.Blocks)
					{
						foreach (SimPe.Plugin.MipMapBlock mmb in id.MipMapBlocks)
						{
							foreach (SimPe.Plugin.MipMap mm in mmb.MipMaps)
							{
								if (
									mm.DataType == SimPe.Plugin.MipMapType.LifoReference
									&& mm.LifoFile.Length > 0
								)
								{
									SimPe.Plugin.GenericRcol lifo = getRcol(
										mm.LifoFile,
										lifopkg
									);
									if (lifo != null)
									{
										rcolChain.Add(lifo);
									}
								}
							}
						}
					}
				}
			}
		}

		private void addStr(
			SimPe.PackedFiles.Wrapper.Cpf srcCpf,
			SimPe.Plugin.RefFile src3idr
		)
		{
			SimPe.PackedFiles.Wrapper.CpfItem cpfItem = srcCpf.GetItem("stringsetidx");
			if (
				cpfItem == null
				|| cpfItem.Datatype != SimPe.Data.MetaData.DataTypes.dtUInteger
			)
			{
				return;
			}

			IPackedFileDescriptor ps = srcCpf.Package.FindFile(
				src3idr.Items[cpfItem.UIntegerValue]
			);
			if (ps == null)
			{
				return;
			}

			SimPe.PackedFiles.Wrapper.Str str = new SimPe.PackedFiles.Wrapper.Str();
			str.ProcessData(ps, srcCpf.Package);

			addFile(str);
		}

		private void addFile(AbstractWrapper file)
		{
			addFile(file.Package, file.FileDescriptor);
		}

		private void addFile(IPackageFile p, IPackedFileDescriptor pfd)
		{
			if (isInPFDList(currentPackage.Index, pfd) || p.FindExactFile(pfd) == null)
			{
				return;
			}

			IPackedFileDescriptor npfd = p.FindExactFile(pfd).Clone();
			npfd.UserData = p.Read(pfd).UncompressedData;
			currentPackage.Add(npfd, true);
		}

		private bool isInPFDList(
			IPackedFileDescriptor[] pfdList,
			IPackedFileDescriptor pfd
		)
		{
			foreach (IPackedFileDescriptor i in pfdList)
			{
				if (
					i.Group == pfd.Group
					&& i.Type == pfd.Type
					&& i.LongInstance == pfd.LongInstance
				)
				{
					return true;
				}
			}

			return false;
		}

		private IPackedFileDescriptor currentPfd = null;
		private IPackageFile currentPackage = null;
		private SimPe.PackedFiles.Wrapper.Cpf objKeyCPF = null;
		private SimPe.Plugin.RefFile objKey3IDR = null;

		private void Main(IPackedFileDescriptor pfd, IPackageFile package)
		{
			// objKey3IDR+objKeyCPF = ObjKey
			// currentPackage = package containing ObjKey
			currentPfd = pfd;
			currentPackage = package;
			makeCpf3idrPair();
			if (objKey3IDR == null)
			{
				System.Windows.Forms.MessageBox.Show(
					L.Get("missing3IDR"),
					L.Get("pjObjKeyHelp"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation
				);
				return;
			}
			if (objKeyCPF == null)
			{
				System.Windows.Forms.MessageBox.Show(
					L.Get("missingCPF"),
					L.Get("pjObjKeyHelp"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation
				);
				return;
			}

			SimPe.RemoteControl.ApplicationForm.Cursor = Cursors.WaitCursor;
			SimPe.Wait.Start();

			List<AbstractWrapper[]> fragKeys = findFragKeys();
			List<AbstractWrapper[]> binKeys = findBinKeys(fragKeys);
			List<SimPe.Plugin.GenericRcol> rcolChain = findrcolChain();

			SimPe.Wait.SubStart(fragkeys.Count);
			foreach (AbstractWrapper[] ap in fragKeys)
			{
				addFile(ap[0]);
				addFile(ap[1]);
				addStr(
					(SimPe.PackedFiles.Wrapper.Cpf)ap[0],
					(SimPe.Plugin.RefFile)ap[1]
				);
				SimPe.Wait.Progress++;
			}
			SimPe.Wait.SubStop();

			SimPe.Wait.SubStart(binKeys.Count);
			foreach (AbstractWrapper[] ap in binKeys)
			{
				addFile(ap[0]);
				addFile(ap[1]);
				addStr(
					(SimPe.PackedFiles.Wrapper.Cpf)ap[0],
					(SimPe.Plugin.RefFile)ap[1]
				);
				SimPe.Wait.Progress++;
			}
			SimPe.Wait.SubStop();

			SimPe.Wait.SubStart(rcolChain.Count);
			foreach (SimPe.Plugin.GenericRcol p in rcolChain)
			{
				addFile(p);
				SimPe.Wait.Progress++;
			}
			SimPe.Wait.SubStop();

			if (pfd.Equals(objKey3IDR.FileDescriptor))
			{
				addFile(objKeyCPF);
			}
			else
			{
				addFile(objKey3IDR);
			}

			SimPe.Wait.Stop();
			SimPe.RemoteControl.ApplicationForm.Cursor = Cursors.Default;
		}

		#region ITool Members

		public bool IsEnabled(IPackedFileDescriptor pfd, IPackageFile package)
		{
			if (pfd == null || package == null)
			{
				return false;
			}

			return true;
		}

		private bool IsReallyEnabled(IPackedFileDescriptor pfd, IPackageFile package)
		{
			if (pfd == null || package == null)
			{
				return false;
			}

			if (txmtpkg == null)
			{
				SetPacks();
				SimPe.FileTable.FileIndex.FILoad += new EventHandler(FileIndex_FILoad);
			}
			if (pfd.Type == SimPe.Data.MetaData.REF_FILE)
			{
				return hasCpf(pfd, package);
			}
			else if (
				pfd.Type == 0x0C1FE246 /*XMOL*/
				|| pfd.Type == 0x2C1FD8A1 /*XTOL*/
				|| pfd.Type == SimPe.Data.MetaData.GZPS
			)
			{
				return has3idr(pfd, package);
			}

			return false;
		}

		public IToolResult ShowDialog(
			ref IPackedFileDescriptor pfd,
			ref IPackageFile package
		)
		{
			if (!IsReallyEnabled(pfd, package))
			{
				System.Windows.Forms.MessageBox.Show(
					SimPe.Localization.GetString(
						"This is not an appropriate context in which to use this tool"
					),
					L.Get("pjObjKeyHelp")
				);
				return new SimPe.Plugin.ToolResult(false, false);
			}
			Main(pfd, package);
			return new SimPe.Plugin.ToolResult(false, false);
		}

		#region IToolPlugin Members

		public override string ToString()
		{
			return L.Get("pjCObjKeyTool");
		}

		#endregion
		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => SimPe.GetIcon.ObjKeyTool;
		#endregion
	}
}
