// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using SimPe.Interfaces;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.ThreeIdr;

namespace pj
{
	public class cObjKeyTool : AbstractTool, ITool
	{
		// TSData\Res\3D:
		private static List<string> txmtpkg; // Objects02, Sims02, CarryForward.sgfiles
		private static List<string> gmdcpkg; // Objects03, Sims03, CarryForward.sgfiles
		private static List<string> gmndpkg; // Objects04, Sims04, CarryForward.sgfiles
		private static List<string> shpepkg; // Objects06, Sims05, CarryForward.sgfiles
		private static List<string> crespkg; // Objects05, Sims06, CarryForward.sgfiles
		private static List<string> txtrpkg; // Objects07, Sims07, Textures, CarryForward.sgfiles
		private static List<string> lifopkg; // Objects07-09, Sims08/9/11-13, Textures, CarryForward.sgfiles

		// TSData\Res\Catalog:
		private static List<string> objkeys; // Skins\Skins
		private static List<string> fragkeys; // Bins\globalcatbin.bundle
		private static List<string> binkeys; // Bins\globalcatbin.bundle

		private static void addPackages(
			ref List<string> packs,
			string path,
			string[] posspacks
		)
		{
			foreach (string p in posspacks)
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

		private static void addPackages(ref List<string> packs, string path, bool rec)
		{
			addPackages(ref packs, path, Directory.GetFiles(path, "*.package"));
			if (rec)
			{
				foreach (string folder in Directory.GetDirectories(path))
				{
					addPackages(ref packs, Path.Combine(path, folder), rec);
				}
			}
		}

		private static void SetPacks()
		{
			txmtpkg = new List<string>();
			gmdcpkg = new List<string>();
			gmndpkg = new List<string>();
			shpepkg = new List<string>();
			crespkg = new List<string>();
			txtrpkg = new List<string>();
			lifopkg = new List<string>();
			objkeys = new List<string>();
			fragkeys = new List<string>();
			binkeys = new List<string>();
			List<string>[] lls = new List<string>[]
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

			foreach (SimPe.FileTableItem fii in SimPe.FileTableBase.DefaultFolders)
			{
				if (!fii.Use)
				{
					continue;
				}

				if (fii.IsFile)
				{
					for (int i = 0; i < lls.Length; i++)
					{
						addPackages(ref lls[i], "", new string[] { fii.Name });
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
						new string[] { "Objects02", "Sims02", "CarryForward.sgfiles" }
					);
					addPackages(
						ref gmdcpkg,
						fii.Name,
						new string[] { "Objects03", "Sims03", "CarryForward.sgfiles" }
					);
					addPackages(
						ref gmndpkg,
						fii.Name,
						new string[] { "Objects04", "Sims04", "CarryForward.sgfiles" }
					);
					addPackages(
						ref shpepkg,
						fii.Name,
						new string[] { "Objects06", "Sims05", "CarryForward.sgfiles" }
					);
					addPackages(
						ref crespkg,
						fii.Name,
						new string[] { "Objects05", "Sims06", "CarryForward.sgfiles" }
					);
					addPackages(
						ref txtrpkg,
						fii.Name,
						new string[]
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
						new string[]
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
					addPackages(ref objkeys, fii.Name, new string[] { "Skins" });

					string name = fii.Name.Replace(
						SimPe.Helper.PATH_SEP + "Skins",
						SimPe.Helper.PATH_SEP + "Bins"
					);
					if (Directory.Exists(name))
					{
						foreach (string pkg in Directory.GetFiles(name, "*.package"))
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
							new string[] { "globalcatbin.bundle" }
						);
						addPackages(
							ref binkeys,
							name,
							new string[] { "globalcatbin.bundle" }
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
			return pfd != null && package != null && findInPackagelist(objkeys, SimPe.Data.MetaData.REF_FILE, pfd)
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
					objKeyCPF = new Cpf();
					objKeyCPF.ProcessData(currentPfd, currentPackage);
					addFile(p3);
					objKey3IDR = new ThreeIdr();
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
						(Cpf)findInPackagelist(
							objkeys,
							t,
							currentPfd
						);
					if (pc != null)
					{
						addFile(pc);
						objKeyCPF = new Cpf();
						objKeyCPF.ProcessData(pc.FileDescriptor, pc.Package);
						objKey3IDR = new ThreeIdr();
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
			foreach (string pkg in pkgs)
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
			string pkg,
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

			AbstractWrapper tgt = Filetype == SimPe.Data.MetaData.REF_FILE ? new ThreeIdr() : (AbstractWrapper)new Cpf();
			tgt.ProcessData(pt, p);
			return tgt;
		}

		private AbstractWrapper[] getCpf3idrPair(
			Cpf srcCpf,
			ThreeIdr src3idr,
			string cpfItemKey,
			List<string> pkgs
		)
		{
			CpfItem cpfItem = srcCpf.GetItem(cpfItemKey);
			if (
				cpfItem == null
				|| cpfItem.Datatype != SimPe.Data.MetaData.DataTypes.dtUInteger
			)
			{
				return null;
			}

			foreach (string pkg in pkgs)
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
			string pkg
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
				new Cpf(),
				new ThreeIdr(),
			};
			tgt[0].ProcessData(pc, p);
			tgt[1].ProcessData(p3, p);

			return tgt;
		}

		private SimPe.Plugin.GenericRcol getRcol(
			Cpf srcCpf,
			ThreeIdr src3idr,
			string cpfItemKey,
			List<string> pkgs
		)
		{
			CpfItem cpfItem = srcCpf.GetItem(cpfItemKey);
			if (
				cpfItem == null
				|| cpfItem.Datatype != SimPe.Data.MetaData.DataTypes.dtUInteger
			)
			{
				return null;
			}

			foreach (string pkg in pkgs)
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
			List<string> pkgs
		)
		{
			foreach (string pkg in pkgs)
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
			string pkg
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

		private SimPe.Plugin.GenericRcol getRcol(string filename, List<string> pkgs)
		{
			foreach (string pkg in pkgs)
			{
				SimPe.Plugin.GenericRcol tgt = getRcolPkg(filename, pkg);
				if (tgt != null)
				{
					return tgt;
				}
			}
			return null;
		}

		private SimPe.Plugin.GenericRcol getRcolPkg(string filename, string pkg)
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

			foreach (string pkg in fragkeys)
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
						ThreeIdr fk3idr = new ThreeIdr();
						fk3idr.ProcessData(pfd, p);
						Cpf fkCpf =
							new Cpf();
						fkCpf.ProcessData(bx, p);

						// does the pair point to the object we're working on?
						CpfItem objKeyIdx = fkCpf.GetItem(
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
					(Cpf)fk[0],
					(ThreeIdr)fk[1],
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

			foreach (string s in new string[] { "shapekeyidx", "maskshapekeyidx" })
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
				string s in new string[] { "resourcekeyidx", "maskresourcekeyidx" }
			)
			{
				tgt = getRcol(objKeyCPF, objKey3IDR, s, crespkg);
				if (tgt != null)
				{
					rcolChain.Add(tgt);
				}
			}

			uint numOverrides = 0;
			CpfItem cpfItem = objKeyCPF.GetItem(
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
			Cpf srcCpf,
			ThreeIdr src3idr
		)
		{
			CpfItem cpfItem = srcCpf.GetItem("stringsetidx");
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
		private Cpf objKeyCPF = null;
		private ThreeIdr objKey3IDR = null;

		private void Main(IPackedFileDescriptor pfd, IPackageFile package)
		{
			// objKey3IDR+objKeyCPF = ObjKey
			// currentPackage = package containing ObjKey
			currentPfd = pfd;
			currentPackage = package;
			makeCpf3idrPair();
			if (objKey3IDR == null)
			{
				MessageBox.Show(
					L.Get("missing3IDR"),
					L.Get("pjObjKeyHelp"),
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation
				);
				return;
			}
			if (objKeyCPF == null)
			{
				MessageBox.Show(
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
					(Cpf)ap[0],
					(ThreeIdr)ap[1]
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
					(Cpf)ap[0],
					(ThreeIdr)ap[1]
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
			return pfd != null && package != null;
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
				SimPe.FileTableBase.FileIndex.FILoad += new EventHandler(FileIndex_FILoad);
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
				MessageBox.Show(
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
