/***************************************************************************
 *   Copyright (C) 2005-2008 by Peter L Jones                              *
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

using Ambertation.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.guidtool
{
	/// <summary>
	/// Summary description for GUIDForm.
	/// </summary>
	public class GUIDForm : Form
	{
		#region Form variables

		private ExtProgressBar progressBar1;
		private Label lbStatus;
		private RichTextBox rtbReport;
		private TextBox tbNumber;
		private Label lbName;
		private TextBox tbName;
		private Label lbNumber;
		private Button btnSearch;
		private Button btnClose;
		private GroupBox groupBox1;
		private CheckBox ckbObjdGUID;
		private CheckBox ckbObjdName;
		private CheckBox ckbNrefName;
		private CheckBox ckbBhavName;
		private CheckBox ckbBconName;
		private GroupBox groupBox2;
		private RadioButton rb1default;
		private RadioButton rb1CPOnly;
		private Button btnHelp;
		private CheckBox ckbCallsToBHAV;
		private SimPe.Plugin.GUIDChooser gcGroup;
		private Button btnClearFilter;
		private CheckBox ckbSGSearch;
		private Label label1;
		private CheckBox ckbFromBHAV;
		private CheckBox ckbFromObjf;
		private CheckBox ckbFromTtab;
		private CheckBox ckbGLOB;
		private Label label2;
		private CheckBox ckbSTR;
		private CheckBox ckbCTSS;
		private CheckBox ckbTTAs;
		private CheckBox ckbDefLang;
		private Panel pnFixer;
		private Button btclipb;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		#endregion

		public GUIDForm(bool packageloaded)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			rb1CPOnly.Enabled = packageloaded;
			if (!rb1CPOnly.Enabled && rb1CPOnly.Checked)
			{
				rb1default.Checked = true;
			}

			if (FileTable.gft == null)
			{
				FileTable.GFT.Refresh();
			}

			lHex32 = new List<TextBox>(new TextBox[] { tbNumber });
			rbGroup = new List<RadioButton>(
				new RadioButton[] { rb1default, rb1CPOnly }
			);

			oldText = btnSearch.Text;

			SearchComplete += new EventHandler(Complete);

			#region Group filter
			sgNames = new List<string>();
			sgGroups = new List<uint>();
			sgNames.Add("Globals");
			sgGroups.Add(0x7FD46CD0);
			sgNames.Add("Behaviour");
			sgGroups.Add(0x7FE59FD0);
			foreach (SimPe.Data.SemiGlobalAlias sga in SimPe.Data.MetaData.SemiGlobals)
			{
				if (sga.Known)
				{
					sgNames.Add(sga.Name);
					sgGroups.Add(sga.Id);
				}
			}

			gcGroup.KnownObjects = new object[] { sgNames, sgGroups };
			gcGroup.ComboBoxWidth = 420;
			#endregion
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool searching = false;
		private int matches = 0;
		private string oldText = null;

		//private string prompt = null;
		private Thread searchThread = null;

		private List<String> sgNames = null;
		private List<UInt32> sgGroups = null;

		private List<RadioButton> rbGroup = null;

		private static bool Selected(RadioButton rb)
		{
			return rb.Checked;
		}

		private static int byPackageGroupTypeInstance(
			FileTable.Entry x,
			FileTable.Entry y
		)
		{
			int result = x.Package.FileName.CompareTo(y.Package.FileName);
			if (result == 0)
			{
				result = x.Group.CompareTo(y.Group);
			}

			if (result == 0)
			{
				result = x.Type.CompareTo(y.Type);
			}

			if (result == 0)
			{
				result = x.Instance.CompareTo(y.Instance);
			}

			return result;
		}

		private void Search(object o)
		{
			bool[] type = (bool[])((object[])o)[0];
			FileTable.Source where = (FileTable.Source)((object[])o)[1];
			uint searchNumber = (uint)((object[])o)[2];
			string searchText = (string)((object[])o)[3];
			uint group = (uint)((object[])o)[4];

			SetProgressCallback setProgress = new SetProgressCallback(SetProgress);
			AddResultCallback addResult = new AddResultCallback(AddResult);
			StopSearchCallback stopSearch = new StopSearchCallback(StopSearch);
			EventHandler onSearchComplete = new EventHandler(OnSearchComplete);

			try
			{
				List<FileTable.Entry> results = new List<FileTable.Entry>();
				if (group != 0)
				{
					if (type[6])
					#region Focus on SemiGlobal group
					{
						List<FileTable.Entry> globs = new List<FileTable.Entry>(
							FileTable.GFT[SimPe.Data.MetaData.GLOB_FILE, where]
						);
						foreach (FileTable.Entry fte in globs)
						{
							SimPe.Plugin.Glob glob = (SimPe.Plugin.Glob)fte.Wrapper;
							if (glob == null)
							{
								continue;
							}

							if (group != glob.SemiGlobalGroup)
							{
								continue;
							}

							List<FileTable.Entry> temp =
								new List<FileTable.Entry>();
							if (type[7])
							{
								temp.AddRange(
									FileTable.GFT[Bhav.Bhavtype, fte.Group, where]
								);
							}

							if (type[8])
							{
								temp.AddRange(
									FileTable.GFT[Objf.Objftype, fte.Group, where]
								);
							}

							if (type[9])
							{
								temp.AddRange(
									FileTable.GFT[Ttab.Ttabtype, fte.Group, where]
								);
							}

							if (fte.Group == 0xffffffff)
							{
								foreach (FileTable.Entry entry in temp)
								{
									if (entry.Package == fte.Package)
									{
										results.Add(entry);
									}
								}
							}
							else
							{
								results.AddRange(temp);
							}
						}
						if (type[7])
						{
							results.AddRange(
								FileTable.GFT[Bhav.Bhavtype, group, where]
							);
						}

						if (type[8])
						{
							results.AddRange(
								FileTable.GFT[Objf.Objftype, group, where]
							);
						}

						if (type[9])
						{
							results.AddRange(
								FileTable.GFT[Ttab.Ttabtype, group, where]
							);
						}
					}
					#endregion
					else if (type[10])
					#region References to GLOB
					{
						List<FileTable.Entry> globs = new List<FileTable.Entry>(
							FileTable.GFT[SimPe.Data.MetaData.GLOB_FILE, where]
						);
						foreach (FileTable.Entry fte in globs)
						{
							SimPe.Plugin.Glob glob = (SimPe.Plugin.Glob)fte.Wrapper;
							if (glob == null)
							{
								continue;
							}

							if (group != glob.SemiGlobalGroup)
							{
								continue;
							}

							FileTable.Entry[] objds = FileTable.GFT[
								SimPe.Data.MetaData.OBJD_FILE,
								fte.Group,
								where
							];

							if (objds.Length == 0)
							{
								results.Add(fte);
							}
							else
							{
								if (fte.Group == 0xffffffff)
								{
									foreach (FileTable.Entry entry in objds)
									{
										if (entry.Package == fte.Package)
										{
											results.Add(entry);
											break;
										}
									}
								}
								else
								{
									results.Add(objds[0]);
								}
							}
						}
					}
					#endregion
					else
					#region Search within group
					{
						if (type[0] || type[1])
						{
							results.AddRange(
								FileTable.GFT[
									SimPe.Data.MetaData.OBJD_FILE,
									group,
									where
								]
							);
						}

						if (type[2])
						{
							results.AddRange(
								FileTable.GFT[0x4E524546, group, where]
							); // NREF
						}

						if (type[3])
						{
							results.AddRange(
								FileTable.GFT[Bhav.Bhavtype, group, where]
							);
						}

						if (type[4])
						{
							results.AddRange(
								FileTable.GFT[Bcon.Bcontype, group, where]
							);
						}

						if (type[5])
						{
							if (type[7])
							{
								results.AddRange(
									FileTable.GFT[Bhav.Bhavtype, group, where]
								);
							}

							if (type[8])
							{
								results.AddRange(
									FileTable.GFT[Objf.Objftype, group, where]
								);
							}

							if (type[9])
							{
								results.AddRange(
									FileTable.GFT[Ttab.Ttabtype, group, where]
								);
							}
						}
						if (type[11])
						{
							results.AddRange(
								FileTable.GFT[StrWrapper.Strtype, group, where]
							);
						}

						if (type[12])
						{
							results.AddRange(
								FileTable.GFT[StrWrapper.CTSStype, group, where]
							);
						}

						if (type[13])
						{
							results.AddRange(
								FileTable.GFT[StrWrapper.TTAstype, group, where]
							);
						}
					}
					#endregion
				}
				else // group == 0
				{
					if (type[6] || type[10])
					{
					} // no results for group == 0
					else
					#region Search without group
					{
						if (type[0] || type[1])
						{
							results.AddRange(
								FileTable.GFT[SimPe.Data.MetaData.OBJD_FILE, where]
							);
						}

						if (type[2])
						{
							results.AddRange(FileTable.GFT[0x4E524546, where]); // NREF
						}

						if (type[3])
						{
							results.AddRange(FileTable.GFT[Bhav.Bhavtype, where]);
						}

						if (type[4])
						{
							results.AddRange(FileTable.GFT[Bcon.Bcontype, where]);
						}

						if (type[5])
						{
							if (type[7])
							{
								results.AddRange(
									FileTable.GFT[Bhav.Bhavtype, where]
								);
							}

							if (type[8])
							{
								results.AddRange(
									FileTable.GFT[Objf.Objftype, where]
								);
							}

							if (type[9])
							{
								results.AddRange(
									FileTable.GFT[Ttab.Ttabtype, where]
								);
							}
						}
						if (type[11])
						{
							results.AddRange(
								FileTable.GFT[StrWrapper.Strtype, where]
							);
						}

						if (type[12])
						{
							results.AddRange(
								FileTable.GFT[StrWrapper.CTSStype, where]
							);
						}

						if (type[13])
						{
							results.AddRange(
								FileTable.GFT[StrWrapper.TTAstype, where]
							);
						}
					}
					#endregion
				}

				results.Sort(byPackageGroupTypeInstance);

				Invoke(setProgress, new object[] { false, results.Count });

				int j = 0;
				FileTable.Entry previtem = null;
				foreach (FileTable.Entry item in results)
				{
					if (item != previtem)
					{
						previtem = item;

						uint itemguid = 0;

						System.IO.BinaryReader reader = item.Wrapper.StoredData;
						if (item.Type == SimPe.Data.MetaData.OBJD_FILE)
						{
							if (reader.BaseStream.Length > 0x5c + 4) // sizeof(uint)
							{
								reader.BaseStream.Seek(
									0x5c,
									System.IO.SeekOrigin.Begin
								);
								itemguid = reader.ReadUInt32();
							}
						}

						if (
							(type[0] && itemguid == searchNumber)
							|| (
								(type[1] || type[2] || type[3])
								&& item.ToString().ToLower().Contains(searchText)
							)
							|| type[10]
						)
						{
							Invoke(addResult, new object[] { itemguid, item });
						}
						else if (type[5])
						{
							switch (item.Type)
							{
								case Bhav.Bhavtype:
									foreach (Instruction i in (Bhav)item.Wrapper)
									{
										if (i.OpCode == searchNumber)
										{
											Invoke(
												addResult,
												new object[] { itemguid, item }
											);
										}
									}

									break;
								case Objf.Objftype:
									foreach (ObjfItem i in (Objf)item.Wrapper)
									{
										if (
											i.Action == searchNumber
											|| i.Guardian == searchNumber
										)
										{
											Invoke(
												addResult,
												new object[] { itemguid, item }
											);
										}
									}

									break;
								case Ttab.Ttabtype:
									foreach (TtabItem i in (Ttab)item.Wrapper)
									{
										if (
											i.Action == searchNumber
											|| i.Guardian == searchNumber
										)
										{
											Invoke(
												addResult,
												new object[] { itemguid, item }
											);
										}
									}

									break;
							}
						}
						else if (

								(type[11] && item.Type == StrWrapper.Strtype)
								|| (type[12] && item.Type == StrWrapper.CTSStype)
								|| (type[13] && item.Type == StrWrapper.TTAstype)

						)
						{
							if (type[14])
							{
								foreach (
									StrItem si in ((StrWrapper)item.Wrapper)[1]
								)
								{
									if (
										si
											.Title.ToString()
											.ToLower()
											.Contains(searchText)
									)
									{
										Invoke(
											addResult,
											new object[] { itemguid, item }
										);
										break;
									}
								}
							}
							else
							{
								foreach (StrItem si in (StrWrapper)item.Wrapper)
								{
									if (
										si
											.Title.ToString()
											.ToLower()
											.Contains(searchText)
									)
									{
										Invoke(
											addResult,
											new object[] { itemguid, item }
										);
										break;
									}
								}
							}
						}
					}
					//DealtWith:
					Invoke(setProgress, new object[] { true, ++j });
					Thread.Sleep(0);
					if ((bool)Invoke(stopSearch))
					{
						break;
					}
				}
			}
			catch (ThreadInterruptedException) { }
			finally
			{
				Thread.Sleep(0);
				BeginInvoke(onSearchComplete, new object[] { this, EventArgs.Empty });
			}
		}

		private delegate void SetProgressCallback(bool maxOrValue, int progress);

		private void SetProgress(bool maxOrValue, int progress)
		{
			if (maxOrValue == false)
			{
				SimPe.WaitingScreen.Stop();
				progressBar1.Maximum = progress;
			}
			else
			{
				progressBar1.Value = progress;
			}
		}

		private delegate void AddResultCallback(
			uint itemguid,
			FileTable.Entry item
		);

		private void AddResult(uint itemguid, FileTable.Entry item)
		{
			//string report_line = "Group {0}: [{1} guid: {2}] {3} ({4})";
			if (item.Type == SimPe.Data.MetaData.OBJD_FILE)
			{
				rtbReport.AppendText(
					Localization.GetString(
						"gt_reportOBJD",
						SimPe.Helper.HexString(item.PFD.Group),
						item.PFD.TypeName.Name,
						"0x" + SimPe.Helper.HexString(itemguid),
						item.ToString(),
						item.Package.FileName
					) + "\r\n"
				);
			}
			else
			//string report_line = "Group {0}: [{1} {2}] {3} ({4})";
			{
				rtbReport.AppendText(
					Localization.GetString(
						"gt_report",
						SimPe.Helper.HexString(item.PFD.Group),
						item.PFD.TypeName.Name,
						item.ToString(),
						item.Package.FileName
					) + "\r\n"
				);
			}

			rtbReport.ScrollToCaret();
			matches++;
		}

		private delegate bool StopSearchCallback();

		private bool StopSearch()
		{
			return !searching;
		}

		private event EventHandler SearchComplete;

		private void OnSearchComplete(object sender, EventArgs e)
		{
			if (SearchComplete != null)
			{
				SearchComplete(sender, e);
			}
		}

		private void Start()
		{
			bool[] type = new bool[]
			{
				/*0*/ckbObjdGUID.Checked,
				ckbObjdName.Checked,
				ckbNrefName.Checked,
				ckbBhavName.Checked,
				ckbBconName.Checked,
				/*5*/ckbCallsToBHAV.Checked,
				ckbSGSearch.Checked,
				ckbFromBHAV.Checked,
				ckbFromObjf.Checked,
				ckbFromTtab.Checked,
				/*10*/ckbGLOB.Checked,
				ckbSTR.Checked,
				ckbCTSS.Checked,
				ckbTTAs.Checked,
				ckbDefLang.Checked,
			};
			uint number = 0;
			try
			{
				number = Convert.ToUInt32(tbNumber.Text.Trim(), 16);
			}
			catch (FormatException)
			{
				number = 0;
			}
			tbNumber.Text = "0x" + SimPe.Helper.HexString(number);
			if (number == 0)
			{
				type[0] = type[5] = false;
			} // don't search for 0 GUID...
			if (number < 0x2000 || number > 0x2fff)
			{
				type[6] = false;
			} // don't do SG search except for SG BHAVs...
			if (gcGroup.Value == 0)
			{
				type[6] = type[10] = false;
			} // don't search with no Group filter
			tbName.Text = tbName.Text.Trim().ToLower();
			if (tbName.Text.Length == 0)
			{
				type[1] =
					type[2] =
					type[3] =
					type[4] =
					type[11] =
					type[12] =
					type[13] =
						false;
			} // don't search for empty string
			SimPe.WaitingScreen.Wait();
			Cursor = Cursors.WaitCursor;
			btnSearch.Cursor = Cursors.Default;
			groupBox1.Enabled = false;
			ckbObjdGUID.Enabled =
				ckbCallsToBHAV.Enabled =
				ckbFromBHAV.Enabled =
				ckbFromObjf.Enabled =
				ckbFromTtab.Enabled =
					false;
			gcGroup.Enabled =
				ckbSGSearch.Enabled =
				btnClearFilter.Enabled =
				tbNumber.Enabled =
				tbName.Enabled =
				btnClose.Enabled =
					false;
			btnSearch.Text = Localization.GetString("gt_Stop");
			lbStatus.Visible = btclipb.Visible = false;
			progressBar1.Value = 0;
			progressBar1.Visible = true;
			rtbReport.Text = "";

			searching = true;
			matches = 0;

			FileTable.Source[] aS = new FileTable.Source[]
			{
				FileTable.Source.Any,
				FileTable.Source.Local,
			};
			FileTable.Source s;
			int rbS = rbGroup.FindIndex(Selected);

			s = (rbS >= 0 && rbS < aS.Length) ? aS[rbS] : FileTable.Source.Any;

			searchThread = new Thread(new ParameterizedThreadStart(Search));
			searchThread.Start(
				new object[] { type, s, number, tbName.Text, gcGroup.Value }
			);
		}

		private void Stop()
		{
			if (!searching)
			{
				Complete(null, null);
			}
			else
			{
				btnSearch.Enabled = false;
				btnSearch.Cursor = Cursors.WaitCursor;
				searching = false;
			}
		}

		internal void Complete(object sender, EventArgs e)
		{
			searching = false;
			while (searchThread != null && searchThread.IsAlive)
			{
				searchThread.Join(10);
			}

			searchThread = null;
			Cursor = btnSearch.Cursor = Cursors.Default;
			ckbObjdGUID.Enabled =
				ckbCallsToBHAV.Enabled =
				ckbFromBHAV.Enabled =
				ckbFromObjf.Enabled =
				ckbFromTtab.Enabled =
				gcGroup.Enabled =
					true;
			ckbSGSearch.Enabled =
				btnClearFilter.Enabled =
				tbNumber.Enabled =
				tbName.Enabled =
				btnClose.Enabled =
				btnSearch.Enabled =
					true;
			groupBox1.Enabled = true;
			btnSearch.Text = oldText;
			progressBar1.Value = 0;
			progressBar1.Visible = false;
			lbStatus.Visible = true;
			if (matches > 0)
			{
				lbStatus.Text =
					Localization.GetString("gt_MatchesFound")
					+ ": "
					+ matches.ToString();
				btclipb.Visible = true;
			}
			else
			{
				lbStatus.Text = Localization.GetString("gt_NoMatchesFound");
				btclipb.Visible = false;
			}
		}

		List<TextBox> lHex32 = null;

		private bool hex32_IsValid(object sender)
		{
			if (!(sender is TextBox) || lHex32.IndexOf((TextBox)sender) < 0)
			{
				throw new Exception(
					"hex32_IsValid not applicable to control " + sender.ToString()
				);
			}

			try
			{
				Convert.ToUInt32(((TextBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			ComponentResourceManager resources =
				new ComponentResourceManager(typeof(GUIDForm));
			progressBar1 = new ExtProgressBar();
			lbStatus = new Label();
			rtbReport = new RichTextBox();
			lbNumber = new Label();
			tbNumber = new TextBox();
			lbName = new Label();
			tbName = new TextBox();
			gcGroup = new SimPe.Plugin.GUIDChooser();
			ckbSGSearch = new CheckBox();
			btnClearFilter = new Button();
			btnSearch = new Button();
			btnClose = new Button();
			groupBox1 = new GroupBox();
			label2 = new Label();
			ckbObjdName = new CheckBox();
			ckbGLOB = new CheckBox();
			ckbSTR = new CheckBox();
			ckbObjdGUID = new CheckBox();
			ckbCallsToBHAV = new CheckBox();
			ckbCTSS = new CheckBox();
			ckbNrefName = new CheckBox();
			label1 = new Label();
			ckbTTAs = new CheckBox();
			ckbFromTtab = new CheckBox();
			ckbBhavName = new CheckBox();
			ckbDefLang = new CheckBox();
			ckbFromObjf = new CheckBox();
			ckbFromBHAV = new CheckBox();
			ckbBconName = new CheckBox();
			groupBox2 = new GroupBox();
			rb1default = new RadioButton();
			rb1CPOnly = new RadioButton();
			btnHelp = new Button();
			pnFixer = new Panel();
			btclipb = new Button();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			pnFixer.SuspendLayout();
			SuspendLayout();
			//
			// progressBar1
			//
			resources.ApplyResources(progressBar1, "progressBar1");
			progressBar1.BackColor = System.Drawing.Color.Transparent;
			progressBar1.BorderColor = System.Drawing.Color.Black;
			progressBar1.Gradient = System
				.Drawing
				.Drawing2D
				.LinearGradientMode
				.Vertical;
			progressBar1.Maximum = 100;
			progressBar1.Minimum = 0;
			progressBar1.Name = "progressBar1";
			progressBar1.Quality = true;
			progressBar1.TokenCount = 34;
			progressBar1.UnselectedColor = System.Drawing.Color.Black;
			progressBar1.UseTokenBuffer = false;
			progressBar1.Value = 0;
			progressBar1.Visible = false;
			//
			// lbStatus
			//
			resources.ApplyResources(lbStatus, "lbStatus");
			lbStatus.BackColor = System.Drawing.Color.Transparent;
			lbStatus.Name = "lbStatus";
			//
			// rtbReport
			//
			resources.ApplyResources(rtbReport, "rtbReport");
			rtbReport.BackColor = System.Drawing.SystemColors.Window;
			rtbReport.DetectUrls = false;
			rtbReport.Name = "rtbReport";
			rtbReport.ReadOnly = true;
			rtbReport.ShowSelectionMargin = true;
			//
			// lbNumber
			//
			resources.ApplyResources(lbNumber, "lbNumber");
			lbNumber.Name = "lbNumber";
			//
			// tbNumber
			//
			resources.ApplyResources(tbNumber, "tbNumber");
			tbNumber.Name = "tbNumber";
			//
			// lbName
			//
			resources.ApplyResources(lbName, "lbName");
			lbName.Name = "lbName";
			//
			// tbName
			//
			resources.ApplyResources(tbName, "tbName");
			tbName.Name = "tbName";
			//
			// gcGroup
			//
			resources.ApplyResources(gcGroup, "gcGroup");
			gcGroup.BackColor = System.Drawing.Color.Transparent;
			gcGroup.ComboBoxWidth = 420;
			gcGroup.DropDownHeight = 250;
			gcGroup.DropDownStyle = ComboBoxStyle.DropDown;
			gcGroup.DropDownWidth = 420;
			gcGroup.Label = "Group Filter:";
			gcGroup.MaximumSize = new System.Drawing.Size(587, 23);
			gcGroup.Name = "gcGroup";
			gcGroup.Value = 0u;
			//
			// ckbSGSearch
			//
			resources.ApplyResources(ckbSGSearch, "ckbSGSearch");
			ckbSGSearch.BackColor = System.Drawing.Color.Transparent;
			ckbSGSearch.Name = "ckbSGSearch";
			ckbSGSearch.UseVisualStyleBackColor = false;
			//
			// btnClearFilter
			//
			resources.ApplyResources(btnClearFilter, "btnClearFilter");
			btnClearFilter.BackColor = System.Drawing.Color.Transparent;
			btnClearFilter.Name = "btnClearFilter";
			btnClearFilter.UseVisualStyleBackColor = false;
			btnClearFilter.Click += new EventHandler(
				btnClearFilter_Click
			);
			//
			// btnSearch
			//
			resources.ApplyResources(btnSearch, "btnSearch");
			btnSearch.BackColor = System.Drawing.Color.Transparent;
			btnSearch.Name = "btnSearch";
			btnSearch.UseVisualStyleBackColor = false;
			btnSearch.Click += new EventHandler(btnSearch_Click);
			//
			// btnClose
			//
			resources.ApplyResources(btnClose, "btnClose");
			btnClose.BackColor = System.Drawing.Color.Transparent;
			btnClose.DialogResult = DialogResult.OK;
			btnClose.Name = "btnClose";
			btnClose.UseVisualStyleBackColor = false;
			btnClose.Click += new EventHandler(btnClose_Click);
			//
			// groupBox1
			//
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.BackColor = System.Drawing.Color.Transparent;
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(ckbObjdName);
			groupBox1.Controls.Add(ckbGLOB);
			groupBox1.Controls.Add(ckbSTR);
			groupBox1.Controls.Add(ckbObjdGUID);
			groupBox1.Controls.Add(ckbCallsToBHAV);
			groupBox1.Controls.Add(ckbCTSS);
			groupBox1.Controls.Add(ckbNrefName);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(ckbTTAs);
			groupBox1.Controls.Add(ckbFromTtab);
			groupBox1.Controls.Add(ckbBhavName);
			groupBox1.Controls.Add(ckbDefLang);
			groupBox1.Controls.Add(ckbFromObjf);
			groupBox1.Controls.Add(ckbFromBHAV);
			groupBox1.Controls.Add(ckbBconName);
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// ckbObjdName
			//
			resources.ApplyResources(ckbObjdName, "ckbObjdName");
			ckbObjdName.Name = "ckbObjdName";
			ckbObjdName.CheckedChanged += new EventHandler(
				ckbSomeName_CheckedChanged
			);
			//
			// ckbGLOB
			//
			resources.ApplyResources(ckbGLOB, "ckbGLOB");
			ckbGLOB.Name = "ckbGLOB";
			ckbGLOB.CheckedChanged += new EventHandler(
				ckbGLOB_CheckedChanged
			);
			//
			// ckbSTR
			//
			resources.ApplyResources(ckbSTR, "ckbSTR");
			ckbSTR.Name = "ckbSTR";
			ckbSTR.UseVisualStyleBackColor = true;
			ckbSTR.CheckedChanged += new EventHandler(
				ckbSomeName_CheckedChanged
			);
			//
			// ckbObjdGUID
			//
			resources.ApplyResources(ckbObjdGUID, "ckbObjdGUID");
			ckbObjdGUID.Name = "ckbObjdGUID";
			ckbObjdGUID.CheckedChanged += new EventHandler(
				ckbObjdGUID_CheckedChanged
			);
			//
			// ckbCallsToBHAV
			//
			resources.ApplyResources(ckbCallsToBHAV, "ckbCallsToBHAV");
			ckbCallsToBHAV.Name = "ckbCallsToBHAV";
			ckbCallsToBHAV.UseVisualStyleBackColor = true;
			ckbCallsToBHAV.CheckedChanged += new EventHandler(
				ckbCallsToBHAV_CheckedChanged
			);
			//
			// ckbCTSS
			//
			resources.ApplyResources(ckbCTSS, "ckbCTSS");
			ckbCTSS.Name = "ckbCTSS";
			ckbCTSS.UseVisualStyleBackColor = true;
			ckbCTSS.CheckedChanged += new EventHandler(
				ckbSomeName_CheckedChanged
			);
			//
			// ckbNrefName
			//
			resources.ApplyResources(ckbNrefName, "ckbNrefName");
			ckbNrefName.Name = "ckbNrefName";
			ckbNrefName.CheckedChanged += new EventHandler(
				ckbSomeName_CheckedChanged
			);
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// ckbTTAs
			//
			resources.ApplyResources(ckbTTAs, "ckbTTAs");
			ckbTTAs.Name = "ckbTTAs";
			ckbTTAs.UseVisualStyleBackColor = true;
			ckbTTAs.CheckedChanged += new EventHandler(
				ckbSomeName_CheckedChanged
			);
			//
			// ckbFromTtab
			//
			resources.ApplyResources(ckbFromTtab, "ckbFromTtab");
			ckbFromTtab.Name = "ckbFromTtab";
			//
			// ckbBhavName
			//
			resources.ApplyResources(ckbBhavName, "ckbBhavName");
			ckbBhavName.Name = "ckbBhavName";
			ckbBhavName.CheckedChanged += new EventHandler(
				ckbSomeName_CheckedChanged
			);
			//
			// ckbDefLang
			//
			resources.ApplyResources(ckbDefLang, "ckbDefLang");
			ckbDefLang.Name = "ckbDefLang";
			ckbDefLang.UseVisualStyleBackColor = true;
			//
			// ckbFromObjf
			//
			resources.ApplyResources(ckbFromObjf, "ckbFromObjf");
			ckbFromObjf.Name = "ckbFromObjf";
			//
			// ckbFromBHAV
			//
			resources.ApplyResources(ckbFromBHAV, "ckbFromBHAV");
			ckbFromBHAV.Name = "ckbFromBHAV";
			//
			// ckbBconName
			//
			resources.ApplyResources(ckbBconName, "ckbBconName");
			ckbBconName.Name = "ckbBconName";
			ckbBconName.CheckedChanged += new EventHandler(
				ckbSomeName_CheckedChanged
			);
			//
			// groupBox2
			//
			resources.ApplyResources(groupBox2, "groupBox2");
			groupBox2.BackColor = System.Drawing.Color.Transparent;
			groupBox2.Controls.Add(rb1default);
			groupBox2.Controls.Add(rb1CPOnly);
			groupBox2.Name = "groupBox2";
			groupBox2.TabStop = false;
			//
			// rb1default
			//
			resources.ApplyResources(rb1default, "rb1default");
			rb1default.Checked = true;
			rb1default.Name = "rb1default";
			rb1default.TabStop = true;
			//
			// rb1CPOnly
			//
			resources.ApplyResources(rb1CPOnly, "rb1CPOnly");
			rb1CPOnly.Name = "rb1CPOnly";
			//
			// btnHelp
			//
			resources.ApplyResources(btnHelp, "btnHelp");
			btnHelp.BackColor = System.Drawing.Color.Transparent;
			btnHelp.Name = "btnHelp";
			btnHelp.UseVisualStyleBackColor = false;
			btnHelp.Click += new EventHandler(btnHelp_Click);

			Controls.Add(btclipb);
			Controls.Add(pnFixer);
			Controls.Add(tbName);
			Controls.Add(lbNumber);
			Controls.Add(lbName);
			Controls.Add(btnClearFilter);
			Controls.Add(ckbSGSearch);
			Controls.Add(tbNumber);
			Controls.Add(groupBox1);
			Controls.Add(btnHelp);
			Controls.Add(btnSearch);
			Controls.Add(btnClose);
			Controls.Add(lbStatus);
			Controls.Add(progressBar1);
			Controls.Add(rtbReport);
			Controls.Add(groupBox2);
			//
			// pnFixer
			//
			pnFixer.Controls.Add(gcGroup);
			resources.ApplyResources(pnFixer, "pnFixer");
			pnFixer.Name = "pnFixer";
			//
			// btclipb
			//
			resources.ApplyResources(btclipb, "btclipb");
			btclipb.Name = "btclipb";
			btclipb.UseVisualStyleBackColor = true;
			btclipb.Click += new EventHandler(btclipb_Click);
			//
			// GUIDForm
			//
			AcceptButton = btnSearch;
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnClose;
			Name = "GUIDForm";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			pnFixer.ResumeLayout(false);
			pnFixer.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		protected override void OnClosing(CancelEventArgs e)
		{
			// PersistantHeight = this.Height;
			// PersistantWidth = this.Width;
			searching = false;
			if (searchThread != null && searchThread.IsAlive)
			{
				searchThread.Interrupt();
				searchThread.Join();
				searchThread = null;
			}
			e.Cancel = true;
			Hide();
		}

		private void hex32_Validating(
			object sender,
			CancelEventArgs e
		)
		{
			if (hex32_IsValid(sender))
			{
				return;
			}

			e.Cancel = true;

			uint val = 0;
			switch (lHex32.IndexOf((TextBox)sender))
			{
				case 0:
					val = 0;
					break;
			}

			((TextBox)sender).Text = "0x" + SimPe.Helper.HexString(val);
			((TextBox)sender).SelectAll();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			if (searching)
			{
				Stop();
			}
			else
			{
				Start();
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			string protocol = "file://";
			string relativePathToHelp = "pjse.coder.plugin/PJSE_Help";

			SimPe.RemoteControl.ShowHelp(
				protocol
					+ SimPe.Helper.SimPePluginPath
					+ "/"
					+ relativePathToHelp
					+ "/Finder.htm"
			);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
			//Hide();
		}

		private bool isCkbObjdGUIDEnabled => !ckbCallsToBHAV.Checked && !ckbGLOB.Checked;
		private bool isCkbCallsToBHAVEnabled => !ckbObjdGUID.Checked
					&& !ckbGLOB.Checked
					&& !isCkbSomeTextChecked;
		private bool isCkbGLOBEnabled => !ckbObjdGUID.Checked
					&& !ckbCallsToBHAV.Checked
					&& !isCkbSomeTextChecked;
		private bool isFlpNamesEnabled => !ckbCallsToBHAV.Checked && !ckbGLOB.Checked;

		private static bool isChecked(CheckBox cb)
		{
			return cb.Checked;
		}

		private bool isCkbSomeTextChecked => isCkbSomeNameChecked || isCkbSomeStringChecked;
		private bool isCkbSomeNameChecked
		{
			get
			{
				List<CheckBox> lcb = new List<CheckBox>(
					new CheckBox[]
					{
						ckbObjdName,
						ckbNrefName,
						ckbBhavName,
						ckbBconName,
					}
				);
				return lcb.Find(isChecked) != null;
			}
		}
		private bool isCkbSomeStringChecked
		{
			get
			{
				List<CheckBox> lcb = new List<CheckBox>(
					new CheckBox[] { ckbSTR, ckbCTSS, ckbTTAs }
				);
				return lcb.Find(isChecked) != null;
			}
		}

		private void ckbObjdGUID_CheckedChanged(object sender, EventArgs e)
		{
			ckbCallsToBHAV.Enabled = isCkbCallsToBHAVEnabled;
			ckbGLOB.Enabled = isCkbGLOBEnabled;
			ckbSTR.Enabled =
				ckbCTSS.Enabled =
				ckbTTAs.Enabled =
				ckbDefLang.Enabled =
				ckbObjdName.Enabled =
				ckbNrefName.Enabled =
				ckbBhavName.Enabled =
				ckbBconName.Enabled =
					isFlpNamesEnabled;

			if (ckbObjdGUID.Checked)
			{
				ckbCallsToBHAV.Checked = ckbGLOB.Checked = false;
			}

			tbNumber.Enabled = ckbObjdGUID.Checked;
			lbNumber.Text = ckbObjdGUID.Checked
				? Localization.GetString("GUID")
				: "";
		}

		private void ckbCallsToBHAV_CheckedChanged(object sender, EventArgs e)
		{
			ckbGLOB.Enabled = isCkbGLOBEnabled;
			ckbObjdGUID.Enabled = isCkbObjdGUIDEnabled;
			ckbSTR.Enabled =
				ckbCTSS.Enabled =
				ckbTTAs.Enabled =
				ckbDefLang.Enabled =
				ckbObjdName.Enabled =
				ckbNrefName.Enabled =
				ckbBhavName.Enabled =
				ckbBconName.Enabled =
					isFlpNamesEnabled;

			if (ckbCallsToBHAV.Checked)
			{
				ckbObjdGUID.Checked = ckbGLOB.Checked = false;
			}

			tbNumber.Enabled =
				ckbSGSearch.Enabled =
				ckbFromBHAV.Enabled =
				ckbFromObjf.Enabled =
				ckbFromTtab.Enabled =
					ckbCallsToBHAV.Checked;
			lbNumber.Text = ckbCallsToBHAV.Checked
				? Localization.GetString("OpCode")
				: "";
		}

		private void ckbGLOB_CheckedChanged(object sender, EventArgs e)
		{
			ckbCallsToBHAV.Enabled = isCkbObjdGUIDEnabled;
			ckbObjdGUID.Enabled = isCkbObjdGUIDEnabled;
			ckbSTR.Enabled =
				ckbCTSS.Enabled =
				ckbTTAs.Enabled =
				ckbDefLang.Enabled =
				ckbObjdName.Enabled =
				ckbNrefName.Enabled =
				ckbBhavName.Enabled =
				ckbBconName.Enabled =
					isFlpNamesEnabled;

			if (ckbGLOB.Checked)
			{
				ckbObjdGUID.Checked = ckbCallsToBHAV.Checked = false;
			}
		}

		private void ckbSomeName_CheckedChanged(object sender, EventArgs e)
		{
			ckbCallsToBHAV.Enabled = isCkbCallsToBHAVEnabled;
			ckbGLOB.Enabled = isCkbGLOBEnabled;
			ckbObjdGUID.Enabled = isCkbObjdGUIDEnabled;

			lbName.Enabled = tbName.Enabled = isCkbSomeTextChecked;
			ckbDefLang.Enabled = isCkbSomeStringChecked;
		}

		private void btnClearFilter_Click(object sender, EventArgs e)
		{
			gcGroup.Value = 0;
		}

		private void btclipb_Click(object sender, EventArgs e)
		{
			string text = "";
			foreach (string clit in rtbReport.Lines)
			{
				text += clit + "\r\n";
			}

			Clipboard.SetDataObject(text, true);
		}
	}
}
