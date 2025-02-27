/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
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

using SimPe.Cache;
using SimPe.Interfaces.Plugin.Scanner;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.Plugin.Scanner
{
	/// <summary>
	/// This class is retriving the Name of a Package
	/// </summary>
	internal class CompressionScanner : AbstractScanner, IScanner
	{
		public enum HealthState : uint
		{
			Ok = 0x0,
			UnknownVersion = 0x1,
			IncompleteDirectory = 0x02,
			WrongCompressionSize = 0x04,
			WrongDirectory = 0x08,
			NonDefaultObjd = 0x10,
			FaultyNamedObjd = 0x20,
			FaultySizedObjd = 0x40,
			BigMeshGeometry = 0x80,
		}

		public CompressionScanner()
			: base() { }

		#region IScannerBase Member
		public uint Version => 1;

		public int Index => 400;
		#endregion

		#region IScanner Member

		protected override void DoInitScan()
		{
			AddColumn(ListView, "Health", 100);
		}

		public void ScanPackage(
			ScannerItem si,
			PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		)
		{
			ps.Data = new uint[1];
			ps.State = TriState.True;
			ps.Data[0] = (uint)HealthState.Ok;
			if (
				si.Package.Header.Version != 0x100000001
				&& si.Package.Header.Version != 0x100000002
			)
			{
				ps.Data[0] = (uint)HealthState.UnknownVersion;
			}
			else
			{
				if (si.Package.FileListFile != null)
				{
					foreach (
						ClstItem item in si.Package
							.FileListFile
							.Items
					)
					{
						Interfaces.Files.IPackedFileDescriptor p =
							si.Package.FindFile(
								item.Type,
								item.SubType,
								item.Group,
								item.Instance
							);
						if (p == null)
						{
							ps.Data[0] = (uint)HealthState.WrongDirectory;
							break;
						}
					}

					if (ps.Data[0] == (uint)HealthState.Ok)
					{
						foreach (
							Interfaces.Files.IPackedFileDescriptor pfd in si.Package.Index
						)
						{
							Interfaces.Files.IPackedFile fl = si.Package.Read(
								pfd
							);

							if (pfd.Type == Data.MetaData.OBJD_FILE)
							{
								ExtObjd obj = new ExtObjd();
								obj.ProcessData(pfd, si.Package);
								if (obj.Ok != ObjdHealth.Ok)
								{
									ps.Data[0] = (uint)HealthState.NonDefaultObjd;
								}
								//if (obj.Ok == SimPe.PackedFiles.Wrapper.ObjdHealth.UnmatchingFilenames && UserVerification.HaveUserId) ps.Data[0] = (uint)HealthState.FaultyNamedObjd;
								if (obj.Ok == ObjdHealth.OverLength)
								{
									ps.Data[0] = (uint)HealthState.FaultySizedObjd;
								}
							}

							if (pfd.Type == Data.MetaData.GMDC)
							{
								GenericRcol rcol = new GenericRcol();
								rcol.ProcessData(pfd, si.Package);

								GeometryDataContainer gmdc =
									(GeometryDataContainer)rcol.Blocks[0];
								foreach (Gmdc.GmdcGroup g in gmdc.Groups)
								{
									if (
										g.FaceCount
											>

												Gmdc
												.AbstractGmdcImporter
												.CRITICAL_FACE_AMOUNT
										|| g.UsedVertexCount
											>

												Gmdc
												.AbstractGmdcImporter
												.CRITICAL_VERTEX_AMOUNT
									)
									{
										ps.Data[0] = (uint)HealthState.BigMeshGeometry;
									}
								}
							}

							if (!fl.IsCompressed)
							{
								continue;
							}

							int pos = si.Package.FileListFile.FindFile(pfd);
							if (pos == -1)
							{
								ps.Data[0] = (uint)HealthState.IncompleteDirectory;
								break;
							}

							ClstItem item = si.Package
								.FileListFile
								.Items[pos];
							if (fl.UncompressedSize != item.UncompressedSize)
							{
								ps.Data[0] = (uint)HealthState.WrongCompressionSize;
								break;
							}
						}
					}
				}
				if (ps.Data[0] != (uint)HealthState.Ok)
				{
					ps.State = TriState.False;
				}
			}

			UpdateState(si, ps, lvi);
		}

		public void UpdateState(
			ScannerItem si,
			PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		)
		{
			if (ps.State != TriState.Null)
			{
				HealthState cs = (HealthState)ps.Data[0];
				SetSubItem(lvi, StartColum, cs.ToString(), ps);

				//if (ps.Data.Length>1) AbstractScanner.SetSubItem(lvi, this.StartColum+1, ps.Data[1].ToString(), ps);
			}
		}

		public void FinishScan()
		{
		}

		public override bool IsActiveByDefault => true;

		ScannerItem[] selection;

		public override void EnableControl(ScannerItem[] items, bool active)
		{
			selection = items;
			if (!active)
			{
				OperationControl.Enabled = false;
				return;
			}

			foreach (ScannerItem item in items)
			{
				PackageState ps = item.PackageCacheItem.FindState(
					Uid,
					true
				);
				if ((ps.State != TriState.Null) && (ps.Data.Length > 0))
				{
					if ((HealthState)ps.Data[0] == HealthState.WrongCompressionSize) // if ((HealthState)ps.Data[0]!=HealthState.Ok)
					{
						OperationControl.Enabled = true;
						return;
					}
				}
			} //foreach
			OperationControl.Enabled = false;
		}

		protected override System.Windows.Forms.Control CreateOperationControl()
		{
			System.Windows.Forms.LinkLabel ll = new System.Windows.Forms.LinkLabel
			{
				AutoSize = true,
				Text = "fix unhealthy Package"
			};
			ll.Font = new System.Drawing.Font(
				"Verdana",
				ll.Font.Size,
				System.Drawing.FontStyle.Bold
			);

			ll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
				FixCompression
			);
			return ll;
		}

		#endregion

		public override string ToString()
		{
			return "Health Scanner";
		}

		/// <summary>
		/// this Operation is fixing selected Packages that wer marked as problematic
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FixCompression(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			if (selection == null)
			{
				return;
			}

			WaitingScreen.Wait();
			bool chg = false;
			try
			{
				foreach (ScannerItem si in selection)
				{
					WaitingScreen.UpdateMessage(si.FileName);

					PackageState ps = si.PackageCacheItem.FindState(
						Uid,
						true
					);
					if ((ps.State != TriState.Null) && (ps.Data.Length > 0))
					{
						if ((HealthState)ps.Data[0] != HealthState.Ok)
						{
							ps.State = TriState.True;
							ps.Data[0] = (uint)HealthState.Ok;
							foreach (
								Interfaces.Files.IPackedFileDescriptor pfd in si.Package.Index
							)
							{
								Interfaces.Files.IPackedFile file =
									si.Package.Read(pfd);
								pfd.UserData = file.UncompressedData;
								pfd.MarkForReCompress = (
									file.IsCompressed
									|| Data.MetaData.CompressionCandidates.Contains(
										pfd.Type
									)
								);

								if (pfd.Type == Data.MetaData.OBJD_FILE)
								{
									ExtObjd objd =
										new ExtObjd();
									objd.ProcessData(pfd, si.Package);

									if (
										objd.Ok
										!= ObjdHealth.Ok
									)
									{
										objd.SynchronizeUserData();
										objd.ProcessData(pfd, si.Package);

										if (objd.Ok != ObjdHealth.Ok)
										{
											ps.State = TriState.False;
											ps.Data[0] = (uint)
												HealthState.NonDefaultObjd;
											//if (objd.Ok == SimPe.PackedFiles.Wrapper.ObjdHealth.UnmatchingFilenames && UserVerification.HaveUserId) ps.Data[0] = (uint)HealthState.FaultyNamedObjd;
											if (objd.Ok == ObjdHealth.OverLength)
											{
												ps.Data[0] = (uint)
													HealthState.FaultySizedObjd;
											}
										}
									}
								}
							}

							si.Package.Save();
							chg = true;
							si.ListViewItem.ForeColor = System.Drawing.Color.Black;
							ScanPackage(si, ps, si.ListViewItem);
						}
					}
				}

				if (chg && CallbackFinish != null)
				{
					CallbackFinish(false, false);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				WaitingScreen.UpdateImage(null);
				WaitingScreen.Stop();
			}
		}
	}
}
