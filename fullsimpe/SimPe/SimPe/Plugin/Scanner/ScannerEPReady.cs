// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;

using SimPe.Cache;
using SimPe.Interfaces.Plugin.Scanner;

namespace SimPe.Plugin.Scanner
{
	/// <summary>
	/// This class is retriving the Name of a Package
	/// </summary>
	internal class EPReadyScanner : AbstractScanner, IScanner
	{
		public enum ReadyState : uint
		{
			Yes = 0x0,
			NotUniversityReady = 0x1,
			Indetermined = 0x2,
		}

		public EPReadyScanner()
			: base() { }

		#region IScannerBase Member
		public uint Version => 1;

		public int Index => 500;
		#endregion

		#region IScanner Member

		protected override void DoInitScan()
		{
			AddColumn(ListView, "Ready?", 80);
		}

		public void ScanPackage(
			ScannerItem si,
			PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		)
		{
			ps.Data = new List<uint>
			{
				[0] = (uint)ReadyState.Yes
			};
			ps.State = TriState.True;

			if (
				si.PackageCacheItem.Type == PackageType.CustomObject
				|| si.PackageCacheItem.Type == PackageType.Object
				|| si.PackageCacheItem.Type == PackageType.Recolour
			)
			{
				//this package does not contain a File in a Global Group, so it is probably not a Maxis Object!
				if (si.Package.FindFilesByGroup(Data.MetaData.GLOBAL_GROUP).Length == 0)
				{
					//all Files in the Local Group, this is not EP-Ready
					if (
						si.Package.FindFilesByGroup(Data.MetaData.LOCAL_GROUP).Length
						== si.Package.Index.Length
					)
					{
						ps.State = TriState.False;
						ps.Data[0] = (uint)ReadyState.NotUniversityReady;
					}

					//no Files in our Custom Group, so this might be a unready File (but it's not Sure!)
					if (
						si.Package.FindFilesByGroup(Data.MetaData.CUSTOM_GROUP).Length
						== 0
					)
					{
						ps.State = TriState.False;
						ps.Data[0] = (uint)ReadyState.Indetermined;
					}
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
				ReadyState cs = (ReadyState)ps.Data[0];
				SetSubItem(lvi, StartColum, cs.ToString(), ps);
			}
		}

		public void FinishScan()
		{
		}

		public override bool IsActiveByDefault => false;

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
				if ((ps.State != TriState.Null) && (ps.Data.Count > 0))
				{
					if ((ReadyState)ps.Data[0] != ReadyState.Yes)
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
			ScannerPanelForm.Form.pnep.Tag = this;
			return ScannerPanelForm.Form.pnep;
		}

		#endregion

		public override string ToString()
		{
			return "University-Ready Scanner";
		}

		/// <summary>
		/// this Operation is fixing selected Packages that wer marked as problematic
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Fix(string name)
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
					if (ps.Data.Count < 1)
					{
						continue;
					}

					if ((ReadyState)ps.Data[0] == ReadyState.Yes)
					{
						continue;
					}

					string mname = name;
					DateTime now = DateTime.Now;
					mname += now.Date.ToShortDateString();
					mname += "-" + now.Hour.ToString("x");
					mname += now.Minute.ToString("x");
					mname += now.Second.ToString("x");
					mname += now.Millisecond.ToString("x");

					ps.State = TriState.Null;
					try
					{
						FixPackage.Fix(
							si.FileName,
							mname,
							FixVersion.UniversityReady
						);
					}
					catch (Exception ex)
					{
						Helper.ExceptionMessage("", ex);
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
