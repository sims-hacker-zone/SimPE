// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Plugin;

namespace SimPe.Interfaces.Plugin.Scanner
{
	/// <summary>
	/// Implements one scanner
	/// </summary>
	public interface IScanner : IScannerPluginBase
	{
		/// <summary>
		/// Set the Delegate that should be called when a ControlClick (from an OperationControl) was executed
		/// </summary>
		/// <param name="fkt">The delegate</param>
		void SetFinishCallback(SimPe.Plugin.Scanner.AbstractScanner.UpdateList fkt);

		/// <summary>
		/// Caleed before a new Scan is stared
		/// </summary>
		void InitScan(System.Windows.Forms.ListView lv);

		/// <summary>
		/// Called if a non Cached Item was found that should be displayed
		/// </summary>
		/// <param name="si">The Object representing the ScannedFile</param>
		/// <param name="ps">The State of this File for this Scanner</param>
		/// <param name="lvi">The ListView Item that is used to display</param>
		/// <remarks>This needs to update the cache Item!</remarks>
		void ScanPackage(
			ScannerItem si,
			Cache.PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		);

		/// <summary>
		/// Called if a Cached Item was found that should be displayed
		/// </summary>
		/// <param name="si">The Object representing the ScannedFile</param>
		/// <param name="ps">The State of this File for this Scanner</param>
		/// <param name="lvi">The ListView Item that is used to display</param>
		void UpdateState(
			ScannerItem si,
			Cache.PackageState ps,
			System.Windows.Forms.ListViewItem lvi
		);

		/// <summary>
		/// Called after the Scan was Finished completley
		/// </summary>
		void FinishScan();

		/// <summary>
		/// The uid that was assigned to the scanner
		/// </summary>
		uint Uid
		{
			get;
		}

		/// <summary>
		/// Returns true, if this scanner should be activated by Default
		/// </summary>
		bool IsActiveByDefault
		{
			get;
		}

		/// <summary>
		/// Returns true, if this Scanner should be listed on the Top of the List
		/// </summary>
		bool OnTop
		{
			get;
		}

		/// <summary>
		/// Returns null or a valid Control, that will be displayed on the Controls Tab
		/// </summary>
		System.Windows.Forms.Control OperationControl
		{
			get;
		}

		/// <summary>
		/// This is called, when the Selection of the ListView was changed, or a Scan was started
		/// </summary>
		/// <param name="active">true, if the Scanner was used in the last scan</param>
		void EnableControl(bool active);

		/// <summary>
		/// This is called, when the Selection of the ListView was changed, or a Scan was started
		/// </summary>
		/// <param name="item">a Scanner item (or null)</param>
		/// <param name="active">true, if the Scanner was used in the last scan</param>
		void EnableControl(ScannerItem item, bool active);

		/// <summary>
		/// This is called, when the Selection of the ListView was changed, or a Scan was started
		/// </summary>
		/// <param name="items">All selected ScannerItems</param>
		/// <param name="active">true, if the Scanner was used in the last scan</param>
		void EnableControl(ScannerItem[] items, bool active);
	}
}
