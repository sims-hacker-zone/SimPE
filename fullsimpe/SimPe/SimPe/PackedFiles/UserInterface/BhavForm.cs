/***************************************************************************
 *   Copyright (C) 2008 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using pjse;

using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for BhavForm.
	/// </summary>
	public class BhavForm : Form, IPackedFileUI
	{
		#region Form variables

		private Label lbFilename;
		private Label lbFormat;
		private Label lbType;
		private Label lbLocalC;
		private TextBox tbFilename;
		private TextBox tbType;
		private TextBox tbArgC;
		private TextBox tbLocalC;
		private ComboBox tba1;
		private ComboBox tba2;
		private LinkLabel llopenbhav;
		private Label label9;
		private Label label10;
		private Label label11;
		private Label label12;
		private Label label13;
		private TextBox tbInst_OpCode;
		private TextBox tbInst_Op7;
		private TextBox tbInst_Op6;
		private TextBox tbInst_Op5;
		private TextBox tbInst_Op4;
		private TextBox tbInst_Op3;
		private TextBox tbInst_Op2;
		private TextBox tbInst_Op1;
		private TextBox tbInst_Op0;
		private TextBox tbInst_Unk7;
		private TextBox tbInst_Unk6;
		private TextBox tbInst_Unk5;
		private TextBox tbInst_Unk4;
		private TextBox tbInst_Unk3;
		private TextBox tbInst_Unk2;
		private TextBox tbInst_Unk1;
		private TextBox tbInst_Unk0;
		private GroupBox gbInstruction;
		private Panel bhavPanel;
		private Button btnCommit;
		private Button btnOpCode;
		private Button btnOperandWiz;
		private Button btnSort;
		private Label lbUpDown;
		private TextBox tbLines;
		private Button btnUp;
		private Button btnDown;
		private Button btnDel;
		private Button btnAdd;
		private Button btnCancel;
		private BhavInstListControl pnflowcontainer;
		private GroupBox gbMove;
		private Label lbArgC;
		private GroupBox gbSpecial;
		private Button btnInsTrue;
		private Button btnInsFalse;
		private Button btnLinkInge;
		private Button btnDelPescado;
		private Button btnAppend;
		private ComboBox cbFormat;
		private Button btnDelMerola;
		private Label lbCacheFlags;
		private TextBox tbCacheFlags;
		private Label lbTreeVersion;
		private TextBox tbTreeVersion;
		private TextBox tbHeaderFlag;
		private Label lbHeaderFlag;
		private Button btnOperandRaw;
		private TextBox tbInst_NodeVersion;
		private Button btnClose;
		private CheckBox cbSpecial;
		private TextBox tbInst_Longname;
		private Button btnCopyListing;
		private Button btnTPRPMaker;
		private Button btnGUIDIndex;
		private ContextMenuStrip cmenuGUIDIndex;
		private ToolStripMenuItem createAllPackagesToolStripMenuItem;
		private ToolStripMenuItem createCurrentPackageToolStripMenuItem;
		private ToolStripMenuItem loadIndexToolStripMenuItem;
		private ToolStripMenuItem defaultFileToolStripMenuItem;
		private ToolStripMenuItem fromFileToolStripMenuItem;
		private ToolStripMenuItem saveIndexToolStripMenuItem;
		private ToolStripMenuItem defaultFileToolStripMenuItem1;
		private ToolStripMenuItem toFileToolStripMenuItem;
		private Button btnCopyBHAV;
		private TextBox tbHidesOP;
		private LinkLabel llHidesOP;
		private Label lbHidesOP;
		private Button btnPasteListing;
		private Button btnZero;
		private ToolTip ttBhavForm;
		private pjse_banner pjse_banner1;
		private CompareButton cmpBHAV;
		private Button btnInsUnlinked;
		private Button btnImportBHAV;
		private IContainer components;
		#endregion

		public BhavForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			hidesFmt = llHidesOP.Text;

			Tag = "Normal"; // Used by SetReadOnly
#if DEC16
			TextBox[] iow = { null, null, null };
			alDec16 = new ArrayList(iow);
#endif
			TextBox[] iob =
			{
				tbInst_Op0,
				tbInst_Op1,
				tbInst_Op2,
				tbInst_Op3,
				tbInst_Op4,
				tbInst_Op5,
				tbInst_Op6,
				tbInst_Op7,
				tbInst_Unk0,
				tbInst_Unk1,
				tbInst_Unk2,
				tbInst_Unk3,
				tbInst_Unk4,
				tbInst_Unk5,
				tbInst_Unk6,
				tbInst_Unk7,
				tbInst_NodeVersion,
				tbHeaderFlag,
				tbType,
				tbCacheFlags,
				tbArgC,
				tbLocalC,
			};
			alHex8 = new ArrayList(iob);

			TextBox[] w = { tbInst_OpCode, tbLines };
			alHex16 = new ArrayList(w);

			TextBox[] dw = { tbTreeVersion };
			alHex32 = new ArrayList(dw);

			ComboBox[] cb = { tba1, tba2, cbFormat };
			alHex16cb = new ArrayList(cb);

			gbSpecial.Visible = cbSpecial.Checked = Settings
				.PJSE
				.ShowSpecialButtons;

			pjse.FileTable.GFT.FiletableRefresh += new EventHandler(
				FiletableRefresh
			);
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
			if (setHandler && wrapper != null)
			{
				wrapper.FileDescriptor.DescriptionChanged -= new EventHandler(
					FileDescriptor_DescriptionChanged
				);
				wrapper.WrapperChanged -= new EventHandler(WrapperChanged);
				setHandler = false;
			}
			wrapper = null;
			currentInst = null;
			origInst = null;
#if DEC16
			alDec16 =
#endif
			alHex8 = alHex16 = alHex32 = alDec8 = alHex16cb = null;
		}

		#region BhavForm
		private Bhav wrapper;
		private bool setHandler = false;
		private BhavWiz currentInst;
		private Instruction origInst;
		private bool internalchg;
#if DEC16
		private ArrayList alDec16;
#endif
		private ArrayList alHex8;
		private ArrayList alHex16;
		private ArrayList alHex32;
		private ArrayList alDec8;
		private ArrayList alHex16cb;

		private String hidesFmt = "{0}";

		// These should be on the ExtendedWrapper class or BhavWiz or, indeed, PackedFileDescriptor
		private static IPackedFileDescriptor newPFD(IPackedFileDescriptor oldPFD)
		{
			return newPFD(oldPFD.Type, oldPFD.Group, oldPFD.SubType, oldPFD.Instance);
		}

		private static IPackedFileDescriptor newPFD(
			uint type,
			uint group,
			uint instance
		)
		{
			return newPFD(type, group, 0x00000000, instance);
		}

		private static IPackedFileDescriptor newPFD(
			uint type,
			uint group,
			uint subtype,
			uint instance
		)
		{
			IPackedFileDescriptor npfd = new Packages.PackedFileDescriptor
			{
				Type = type,
				Group = group,
				SubType = subtype,
				Instance = instance
			};
			return npfd;
		}

		private IPackageFile currentPackage = null;

		private void TakeACopy()
		{
			IPackedFileDescriptor npfd = newPFD(wrapper.FileDescriptor);
			npfd.UserData = wrapper
				.Package.Read(wrapper.FileDescriptor)
				.UncompressedData;
			currentPackage.Add(npfd, true);
		}

		private delegate bool ignoreEntry(
			pjse.FileTable.Entry i,
			IPackedFileDescriptor npfd
		);
		private delegate bool matchItem(object o, uint inst);
		private delegate void setter(object o, ushort inst);

		private void doUpdate(
			string typeName,
			uint oldInst,
			IPackedFileDescriptor npfd,
			pjse.FileTable.Entry[] entries,
			ignoreEntry ieDelegate,
			matchItem[] matchDelegates,
			setter[] setDelegates
		)
		{
			if (npfd == null)
			{
				return;
			}

			if (entries == null || entries.Length == 0)
			{
				return;
			}

			if (matchDelegates == null || matchDelegates.Length == 0)
			{
				return;
			}

			if (setDelegates == null || setDelegates.Length != matchDelegates.Length)
			{
				return;
			}

			WaitingScreen.Message = "Updating current package - " + typeName + "s...";
			foreach (pjse.FileTable.Entry i in entries)
			{
				ResourceLoader.Refresh(i); // make sure it's been saved before we search it
				Application.DoEvents();

				AbstractWrapper wrapper = i.Wrapper;
				if (wrapper as IEnumerable == null)
				{
					break;
				}

				if (ieDelegate != null && ieDelegate(i, npfd))
				{
					continue;
				}

				foreach (object o in (IEnumerable)wrapper)
				{
					for (int j = 0; j < matchDelegates.Length; j++)
					{
						matchItem md = matchDelegates[j];
						setter sd = setDelegates[j];
						if (md != null && sd != null && md(o, oldInst))
						{
							sd(o, (ushort)npfd.Instance);
						}
					}
				}
				if (wrapper.Changed)
				{
					wrapper.SynchronizeUserData();
					ResourceLoader.Refresh(i);
				}
			}
		}

		private void ImportBHAV()
		{
			WaitingScreen.Wait();

			#region Finding available BHAV number
			WaitingScreen.Message = "Finding available BHAV number...";
			pjse.FileTable.Entry[] ai = pjse.FileTable.GFT[
				Bhav.Bhavtype,
				pjse.FileTable.Source.Local
			];
			ushort newInst = 0x0fff;
			foreach (pjse.FileTable.Entry i in ai)
			{
				if (i.Instance >= 0x1000 && i.Instance < 0x2000 && i.Instance > newInst)
				{
					newInst = (ushort)i.Instance;
				}
			}

			newInst++;
			#endregion

			currentPackage.BeginUpdate();

			#region Cloning BHAV
			WaitingScreen.Message = "Cloning BHAV...";
			IPackedFileDescriptor npfd = newPFD(Bhav.Bhavtype, 0xffffffff, newInst);
			npfd.UserData = wrapper
				.Package.Read(wrapper.FileDescriptor)
				.UncompressedData;
			currentPackage.Add(npfd, true);
			#endregion

			#region Updating current package - BHAVs
			doUpdate(
				"BHAV",
				wrapper.FileDescriptor.Instance,
				npfd,
				ai,
				delegate (pjse.FileTable.Entry i, IPackedFileDescriptor pfd)
				{
					return
						i.Group != pfd.Group
						|| i.Instance < 0x1000
						|| i.Instance >= 0x2000
					;
				},
				new matchItem[]
				{
					delegate(object o, uint value)
					{
						return ((Instruction)o).OpCode == value;
					},
				},
				new setter[]
				{
					delegate(object o, ushort value)
					{
						((Instruction)o).OpCode = value;
					},
				}
			);
			#endregion

			#region Updating current package - OBJFs
			doUpdate(
				"OBJF",
				wrapper.FileDescriptor.Instance,
				npfd,
				pjse.FileTable.GFT[Objf.Objftype, pjse.FileTable.Source.Local],
				null,
				new matchItem[]
				{
					delegate(object o, uint value)
					{
						return ((ObjfItem)o).Action == value;
					},
					delegate(object o, uint value)
					{
						return ((ObjfItem)o).Guardian == value;
					},
				},
				new setter[]
				{
					delegate(object o, ushort value)
					{
						((ObjfItem)o).Action = value;
					},
					delegate(object o, ushort value)
					{
						((ObjfItem)o).Guardian = value;
					},
				}
			);
			#endregion

			#region Updating current package - TTABs
			doUpdate(
				"TTAB",
				wrapper.FileDescriptor.Instance,
				npfd,
				pjse.FileTable.GFT[Ttab.Ttabtype, pjse.FileTable.Source.Local],
				null,
				new matchItem[]
				{
					delegate(object o, uint value)
					{
						return ((TtabItem)o).Action == value;
					},
					delegate(object o, uint value)
					{
						return ((TtabItem)o).Guardian == value;
					},
				},
				new setter[]
				{
					delegate(object o, ushort value)
					{
						((TtabItem)o).Action = value;
					},
					delegate(object o, ushort value)
					{
						((TtabItem)o).Guardian = value;
					},
				}
			);
			#endregion

			currentPackage.EndUpdate();

			WaitingScreen.Message = "";
			WaitingScreen.Stop();
			MessageBox.Show(
				pjse.Localization.GetString("ml_done"),
				btnImportBHAV.Text,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}

		private void cmpBHAV_CompareWith(
			object sender,
			CompareButton.CompareWithEventArgs e
		)
		{
			common_LinkClicked(e.Item, e.ExpansionItem, true);
		}

		private void common_LinkClicked(pjse.FileTable.Entry item)
		{
			common_LinkClicked(item, null, false);
		}

		private void common_LinkClicked(
			pjse.FileTable.Entry item,
			ExpansionItem exp,
			bool noOverride
		)
		{
			if (item == null)
			{
				return; // this should never happen
			}

			Bhav bhav = new Bhav();
			bhav.ProcessData(item.PFD, item.Package);

			BhavForm ui = (BhavForm)bhav.UIHandler;
			string tag = "Popup"; // tells the SetReadOnly function it's in a popup - so everything locked down
			if (noOverride)
			{
				tag += ";noOverride"; // prevents handleOverride displaying anything
			}

			tag += ";callerID=+" + wrapper.FileDescriptor.ExportFileName + "+";
			if (exp != null)
			{
				tag += ";expName=+" + exp.NameShort + "+";
			}

			ui.Tag = tag;

			bhav.RefreshUI();
			ui.Show();
		}

		private string getValueFromTag(string key)
		{
			if (!(Tag is string s))
			{
				return null;
			}

			key = ";" + key + "=+";
			int i = s.IndexOf(key);
			if (i < 0)
			{
				return null;
			}

			s = s.Substring(i + key.Length);
			i = s.IndexOf("+");
			return (i >= 0) ? s.Substring(0, i) : null;
		}

		private bool isPopup => (Tag == null || Tag as string == null)
					? false
					: ((string)Tag).StartsWith("Popup");
		private bool isNoOverride => (Tag == null || Tag as string == null)
					? false
					: ((string)Tag).Contains(";noOverride");
		private string callerID => getValueFromTag("callerID");
		private string expName
		{
			get
			{
				string s = getValueFromTag("expName");
				if (s != null)
				{
					return s;
				}

				foreach (
					pjse.FileTable.Entry item in pjse.FileTable.GFT[
						wrapper.Package,
						wrapper.FileDescriptor
					]
				)
				{
					if (item.PFD == wrapper.FileDescriptor)
					{
						if (item.IsMaxis)
						{
							return pjse.Localization.GetString("expCurrent");
						}
						else
						{
							break;
						}
					}
				}

				return pjse.Localization.GetString("expCustom");
			}
		}

		private String formTitle => pjse.Localization.GetString(
					"pjseWindowTitle",
					expName // EP Name or Custom
					,
					System.IO.Path.GetFileName(
						wrapper.Package.SaveFileName
					) // package Filename without path
					,
					wrapper
						.FileDescriptor
						.TypeName
						.shortname // Type (short name)
					,
					"0x"
						+ Helper.HexString(
							wrapper.FileDescriptor.Group
						) // Group Number
					,
					"0x"
						+ Helper.HexString(
							(ushort)wrapper.FileDescriptor.Instance
						) // Instance Number
					,
					wrapper.FileName,
					pjse.Localization.GetString(
						isPopup ? "pjseWindowTitleView" : "pjseWindowTitleEdit"
					) // View or Edit
				);

		private void handleOverride()
		{
			lbHidesOP.Visible = tbHidesOP.Visible = llHidesOP.Visible = false;
			llHidesOP.Tag = null;
			if (isNoOverride)
			{
				return;
			}

			pjse.FileTable.Entry[] items = pjse.FileTable.GFT[
				wrapper.Package,
				wrapper.FileDescriptor
			];

			if (items.Length > 1) // currentpkg, other, fixed, maxis
			{
				pjse.FileTable.Entry item = items[items.Length - 1];
				if (item.PFD == wrapper.FileDescriptor)
				{
					return;
				}

				if (!item.IsMaxis && !item.IsFixed)
				{
					return;
				}

				lbHidesOP.Visible =
					tbHidesOP.Visible =
					llHidesOP.Visible =
						true;
				llHidesOP.Links[0].Start -= llHidesOP.Text.Length;
				llHidesOP.Text = hidesFmt.Replace(
					"{0}",
					System.IO.Path.GetFileName(item.Package.SaveFileName)
				);
				llHidesOP.Links[0].Start += llHidesOP.Text.Length;
				tbHidesOP.Text = wrapper.Package.FileName;
				llHidesOP.Tag = item.IsMaxis
					? pjse.FileTable.Source.Maxis
					: pjse.FileTable.Source.Fixed;
			}
		}

		private void SetReadOnly(bool state)
		{
			//if (this.isPopup) state = true;

			tbInst_OpCode.ReadOnly = state;
			btnOpCode.Enabled = !state;
			tbInst_NodeVersion.ReadOnly = state || wrapper.Header.Format < 0x8005;
			tba1.Enabled = !state;
			tba2.Enabled = !state;

			/*this.tbInst_Op01_dec.ReadOnly = state;
			this.tbInst_Op23_dec.ReadOnly = state;*/

			tbInst_Op0.ReadOnly = state;
			tbInst_Op1.ReadOnly = state;
			tbInst_Op2.ReadOnly = state;
			tbInst_Op3.ReadOnly = state;
			tbInst_Op4.ReadOnly = state;
			tbInst_Op5.ReadOnly = state;
			tbInst_Op6.ReadOnly = state;
			tbInst_Op7.ReadOnly = state;

			btnOperandWiz.Enabled = !state;
			/*this.btnOperandRaw.Enabled = !state;*/
			btnZero.Enabled = !state;

			tbInst_Unk0.ReadOnly = state || wrapper.Header.Format < 0x8003;
			tbInst_Unk1.ReadOnly = state || wrapper.Header.Format < 0x8003;
			tbInst_Unk2.ReadOnly = state || wrapper.Header.Format < 0x8003;
			tbInst_Unk3.ReadOnly = state || wrapper.Header.Format < 0x8003;
			tbInst_Unk4.ReadOnly = state || wrapper.Header.Format < 0x8003;
			tbInst_Unk5.ReadOnly = state || wrapper.Header.Format < 0x8003;
			tbInst_Unk6.ReadOnly = state || wrapper.Header.Format < 0x8003;
			tbInst_Unk7.ReadOnly = state || wrapper.Header.Format < 0x8003;

			btnUp.Enabled = !state;
			btnDown.Enabled = !state;
			tbLines.ReadOnly = state;
			btnDelPescado.Enabled = btnDel.Enabled = !state;
			btnInsTrue.Enabled =
				btnInsFalse.Enabled =
				btnAdd.Enabled =
					!state;
		}

		private bool instIsBhav()
		{
			return wrapper.ResourceByInstance(
					Data.MetaData.BHAV_FILE,
					currentInst.Instruction.OpCode
				) != null;
		}

		private void OperandWiz(int type)
		{
			internalchg = true;
			bool changed = false;
			Instruction inst = currentInst.Instruction;
			currentInst = null;
			try
			{
				changed =
					new BhavOperandWiz().Execute(
						btnCommit.Visible ? inst : inst.Clone(),
						type
					) != null
				;
			}
			finally
			{
				currentInst = inst;
				if (btnCommit.Visible)
				{
					if (changed)
					{
						UpdateInstPanel();
					}

					btnCancel.Enabled = true;
				}
				internalchg = false;
			}
		}

		private void UpdateInstPanel()
		{
			internalchg = true;
			Application.UseWaitCursor = true;
			if (currentInst == null || wrapper.IndexOf(currentInst.Instruction) < 0)
			{
				SetReadOnly(true);
				llopenbhav.Enabled = false;
				btnInsTrue.Enabled =
					btnInsFalse.Enabled =
					btnAdd.Enabled =
						true;

				tbInst_OpCode.Text = "";
				tbInst_NodeVersion.Text = "";
				tba1.SelectedIndex = 0;
				tba2.SelectedIndex = 0;
				tbInst_Op0.Text = "";
				tbInst_Op1.Text = "";
				tbInst_Op2.Text = "";
				tbInst_Op3.Text = "";
				tbInst_Op4.Text = "";
				tbInst_Op5.Text = "";
				tbInst_Op6.Text = "";
				tbInst_Op7.Text = "";
				tbInst_Unk0.Text = "";
				tbInst_Unk1.Text = "";
				tbInst_Unk2.Text = "";
				tbInst_Unk3.Text = "";
				tbInst_Unk4.Text = "";
				tbInst_Unk5.Text = "";
				tbInst_Unk6.Text = "";
				tbInst_Unk7.Text = "";
			}
			else
			{
				Instruction inst = currentInst.Instruction; // saves typing

				SetReadOnly(false);

				tbInst_OpCode.Text = "0x" + Helper.HexString(inst.OpCode);
				tbInst_NodeVersion.Text =
					"0x" + Helper.HexString(inst.NodeVersion);

				if (inst.Target1 >= 0xFFFC && inst.Target1 < 0xFFFF)
				{
					tba1.SelectedIndex = inst.Target1 - 0xFFFC;
				}
				else
				{
					tba1.SelectedIndex = -1;
					tba1.Text = "0x" + Helper.HexString(inst.Target1);
				}
				if (inst.Target2 >= 0xFFFC && inst.Target2 < 0xFFFF)
				{
					tba2.SelectedIndex = inst.Target2 - 0xFFFC;
				}
				else
				{
					tba2.SelectedIndex = -1;
					tba2.Text = "0x" + Helper.HexString(inst.Target2);
				}

				tbInst_Op0.Text = Helper.HexString(inst.Operands[0]);
				tbInst_Op1.Text = Helper.HexString(inst.Operands[1]);
				tbInst_Op2.Text = Helper.HexString(inst.Operands[2]);
				tbInst_Op3.Text = Helper.HexString(inst.Operands[3]);
				tbInst_Op4.Text = Helper.HexString(inst.Operands[4]);
				tbInst_Op5.Text = Helper.HexString(inst.Operands[5]);
				tbInst_Op6.Text = Helper.HexString(inst.Operands[6]);
				tbInst_Op7.Text = Helper.HexString(inst.Operands[7]);

				tbInst_Unk0.Text = Helper.HexString(inst.Reserved1[0]);
				tbInst_Unk1.Text = Helper.HexString(inst.Reserved1[1]);
				tbInst_Unk2.Text = Helper.HexString(inst.Reserved1[2]);
				tbInst_Unk3.Text = Helper.HexString(inst.Reserved1[3]);
				tbInst_Unk4.Text = Helper.HexString(inst.Reserved1[4]);
				tbInst_Unk5.Text = Helper.HexString(inst.Reserved1[5]);
				tbInst_Unk6.Text = Helper.HexString(inst.Reserved1[6]);
				tbInst_Unk7.Text = Helper.HexString(inst.Reserved1[7]);

				btnUp.Enabled = pnflowcontainer.SelectedIndex > 0;
				btnDown.Enabled =
					pnflowcontainer.SelectedIndex < wrapper.Count - 1;

				btnDelPescado.Enabled = btnDel.Enabled = wrapper.Count > 1;

				llopenbhav.Enabled = instIsBhav();
				btnOperandWiz.Enabled = currentInst.Wizard() != null;
			}
			setLongname();
			Application.UseWaitCursor = false;
			internalchg = false;
		}

		private void OpcodeChanged(ushort value)
		{
			currentInst.Instruction.OpCode = value;
			currentInst = currentInst.Instruction;
			llopenbhav.Enabled = instIsBhav();
			btnOperandWiz.Enabled = currentInst.Wizard() != null;
			setLongname();
		}

		private void ChangeLongname(byte oldval, byte newval)
		{
			if (oldval != newval)
			{
				setLongname();
			}
		}

		private static string onearg = pjse.Localization.GetString("oneArg");
		private static string manyargs = pjse.Localization.GetString("manyArgs");

		private void setLongname()
		{
			if (currentInst == null || wrapper.IndexOf(currentInst.Instruction) < 0)
			{
				tbInst_Longname.Text = "";
			}
			else
			{
				bool state = Application.UseWaitCursor;
				Application.UseWaitCursor = true;
				try
				{
					tbInst_Longname.Text = currentInst
						.LongName.Replace(", ", ",\r\n  ")
						.Replace(onearg + ": ", onearg + ":\r\n  ")
						.Replace(manyargs + ": ", manyargs + ":\r\n  ");
				}
				finally
				{
					Application.UseWaitCursor = state;
				}
			}
		}

		private void CopyListing()
		{
			string listing = "";

			int lines = wrapper.Count;
			for (short i = 0; i < lines; i++)
			{
				Instruction inst = wrapper[i];
				BhavWiz w = inst;

				string operands = "";
				for (int j = 0; j < 8; j++)
				{
					operands += Helper.HexString(inst.Operands[j]);
				}

				for (int j = 0; j < 8; j++)
				{
					operands += Helper.HexString(inst.Reserved1[j]);
				}

				listing +=
					"     "
					+ Helper.HexString(i)
					+ " : "
					+ Helper.HexString(inst.OpCode)
					+ " : "
					+ Helper.HexString(inst.NodeVersion)
					+ " : "
					+ Helper.HexString(inst.Target1)
					+ " : "
					+ Helper.HexString(inst.Target2)
					+ " : "
					+ operands
					+ "\r\n"
					+ w.LongName
					+ "\r\n\r\n"
				;
			}

			Clipboard.SetDataObject(listing, true);
		}

		private void PasteListing()
		{
			int i = 0;
			int origlen = wrapper.Count;

			string listing = Clipboard.GetText(TextDataFormat.Text);
			foreach (string line in listing.Split('\r', '\n'))
			{
				if (line.Length == 0)
				{
					continue;
				}

				string[] args = line.Split(new char[] { ':' });
				if (args.Length != 6)
				{
					continue;
				}

				try
				{
					if (Convert.ToUInt32(args[0].Trim(), 16) != i)
					{
						throw new Exception("Foo");
					}

					Instruction inst = new Instruction(wrapper)
					{
						OpCode = Convert.ToUInt16(args[1].Trim(), 16),
						NodeVersion = Convert.ToByte(args[2].Trim(), 16),
						Target1 = Convert.ToUInt16(args[3].Trim(), 16),
						Target2 = Convert.ToUInt16(args[4].Trim(), 16)
					};
					for (int j = 0; j < 8; j++)
					{
						inst.Operands[j] = Convert.ToByte(
							args[5].Trim().Substring(j * 2, 2),
							16
						);
					}

					for (int j = 0; j < 8; j++)
					{
						inst.Reserved1[j] = Convert.ToByte(
							args[5].Trim().Substring(16 + (j * 2), 2),
							16
						);
					}

					if (inst.Target1 < 0xfffc)
					{
						inst.Target1 = (ushort)(inst.Target1 + origlen);
					}

					if (inst.Target2 < 0xfffc)
					{
						inst.Target2 = (ushort)(inst.Target2 + origlen);
					}

					wrapper.Add(inst);
				}
				finally
				{
					i++;
				}
			}
		}

		private void TPRPMaker()
		{
			bhavPanel.Cursor = Cursors.WaitCursor;
			Application.UseWaitCursor = true;
			try
			{
				int minArgc = 0;
				int minLocalC = 0;
				TPRP tprp = (TPRP)wrapper.SiblingResource(TPRP.TPRPtype); // find TPRP for this BHAV

				wrapper.Package.BeginUpdate();

				if (tprp != null && tprp.TextOnly)
				{
					// if it exists but is unreadable, as if user wants to overwrite
					DialogResult dr = MessageBox.Show(
						pjse.Localization.GetString("ml_overwriteduff"),
						btnTPRPMaker.Text,
						MessageBoxButtons.OKCancel,
						MessageBoxIcon.Warning
					);
					if (dr != DialogResult.OK)
					{
						return;
					}

					wrapper.Package.Remove(tprp.FileDescriptor);
					tprp = null;
				}
				if (tprp != null)
				{
					// if it exists ask if user wants to preserve content
					DialogResult dr = MessageBox.Show(
						pjse.Localization.GetString("ml_keeplabels"),
						btnTPRPMaker.Text,
						MessageBoxButtons.YesNoCancel,
						MessageBoxIcon.Warning
					);
					if (dr == DialogResult.Cancel)
					{
						return;
					}

					if (!tprp.Package.Equals(wrapper.Package))
					{
						// Clone the original into this package
						if (dr == DialogResult.Yes)
						{
							Wait.MaxProgress = tprp.Count;
						}

						IPackedFileDescriptor npfd = newPFD(
							tprp.FileDescriptor
						);
						TPRP ntprp = new TPRP
						{
							FileDescriptor = npfd
						};
						wrapper.Package.Add(npfd, true);
						if (dr == DialogResult.Yes)
						{
							foreach (TPRPItem item in tprp)
							{
								ntprp.Add(item.Clone());
								Wait.Progress++;
							}
						}

						tprp = ntprp;
						tprp.SynchronizeUserData();
						Wait.MaxProgress = 0;
					}

					if (dr == DialogResult.Yes)
					{
						minArgc = tprp.ParamCount;
						minLocalC = tprp.LocalCount;
					}
					else
					{
						tprp.Clear();
					}
				}
				else
				{
					// create a new TPRP file
					tprp = new TPRP
					{
						FileDescriptor = newPFD(
						TPRP.TPRPtype,
						wrapper.FileDescriptor.Group,
						wrapper.FileDescriptor.SubType,
						wrapper.FileDescriptor.Instance
					)
					};
					wrapper.Package.Add(tprp.FileDescriptor, true);
					tprp.SynchronizeUserData();
				}

				Wait.MaxProgress =
					wrapper.Header.ArgumentCount
					- minArgc
					+ wrapper.Header.LocalVarCount
					- minLocalC;
				tprp.FileName = wrapper.FileName;

				for (int arg = minArgc; arg < wrapper.Header.ArgumentCount; arg++)
				{
					tprp.Add(new TPRPParamLabel(tprp));
					tprp[false, tprp.ParamCount - 1].Label =
						BhavWiz.dnParam() + " " + arg.ToString();
					Wait.Progress++;
				}
				for (
					int local = minLocalC;
					local < wrapper.Header.LocalVarCount;
					local++
				)
				{
					tprp.Add(new TPRPLocalLabel(tprp));
					tprp[true, tprp.LocalCount - 1].Label =
						BhavWiz.dnLocal() + " " + local.ToString();
					Wait.Progress++;
				}
				tprp.SynchronizeUserData();
				wrapper.Package.EndUpdate();
			}
			finally
			{
				Wait.SubStop();
				bhavPanel.Cursor = Cursors.Default;
				Application.UseWaitCursor = false;
			}
			MessageBox.Show(
				pjse.Localization.GetString("ml_done"),
				btnTPRPMaker.Text,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information
			);
		}

		private short OpsToShort(byte lo, byte hi)
		{
			ushort uval = (ushort)(lo + (hi << 8));
			return uval > 32767 ? (short)(uval - 65536) : (short)uval;
		}

		private byte[] ShortToOps(short val)
		{
			byte[] ops = new byte[2];
			ushort uval = val < 0 ? (ushort)(65536 + val) : (ushort)val;

			ops[0] = (byte)(uval & 0xFF);
			ops[1] = (byte)((uval >> 8) & 0xFF);
			return ops;
		}

		private bool cbHex16_IsValid(object sender)
		{
			if (alHex16cb.IndexOf(sender) < 0)
			{
				throw new Exception(
					"cbHex16_IsValid not applicable to control " + sender.ToString()
				);
			}

			if (((ComboBox)sender).Items.IndexOf(((ComboBox)sender).Text) != -1)
			{
				return true;
			}

			try
			{
				Convert.ToUInt16(((ComboBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		private bool dec8_IsValid(object sender)
		{
			if (alDec8.IndexOf(sender) < 0)
			{
				throw new Exception(
					"dec8_IsValid not applicable to control " + sender.ToString()
				);
			}

			try
			{
				Convert.ToByte(((TextBox)sender).Text);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

#if DEC16
		private bool dec16_IsValid(object sender)
		{
			if (alDec16.IndexOf(sender) < 0)
				throw new Exception(
					"dec16_IsValid not applicable to control " + sender.ToString()
				);
			try
			{
				Convert.ToInt16(((TextBox)sender).Text);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}
#endif

		private bool hex8_IsValid(object sender)
		{
			if (alHex8.IndexOf(sender) < 0)
			{
				throw new Exception(
					"hex8_IsValid not applicable to control " + sender.ToString()
				);
			}

			try
			{
				Convert.ToByte(((TextBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		private bool hex16_IsValid(object sender)
		{
			if (alHex16.IndexOf(sender) < 0)
			{
				throw new Exception(
					"hex16_IsValid not applicable to control " + sender.ToString()
				);
			}

			try
			{
				Convert.ToUInt16(((TextBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		private bool hex32_IsValid(object sender)
		{
			if (alHex32.IndexOf(sender) < 0)
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

		private void FiletableRefresh(object sender, EventArgs e)
		{
			pjse_banner1.SiblingEnabled =
				wrapper != null && wrapper.SiblingResource(TPRP.TPRPtype) != null;
			UpdateInstPanel();
		}

		#endregion

		#region IPackedFileUI Member
		/// <summary>
		/// Returns the Control that will be displayed within SimPe
		/// </summary>
		public Control GUIHandle => bhavPanel;

		/// <summary>
		/// Called by the AbstractWrapper when the file should be displayed to the user.
		/// </summary>
		/// <param name="wrp">Reference to the wrapper to be displayed.</param>
		public void UpdateGUI(IFileWrapper wrp)
		{
			wrapper = (Bhav)wrp;

			internalchg = true;
			tbLines.Text = "0x0001";
			internalchg = false;

			WrapperChanged(wrapper, null);
			pjse_banner1.SiblingEnabled =
				wrapper.SiblingResource(TPRP.TPRPtype) != null;

			currentInst = null;
			origInst = null;
			UpdateInstPanel();
			pnflowcontainer.UpdateGUI(wrapper);
			// pnflowcontainer to install its handler before us.
			if (!setHandler)
			{
				wrapper.WrapperChanged += new EventHandler(WrapperChanged);
				wrapper.FileDescriptor.DescriptionChanged += new EventHandler(
					FileDescriptor_DescriptionChanged
				);
				setHandler = true;
			}

			if (isPopup)
			{
				currentPackage = pjse.FileTable.GFT.CurrentPackage;
#if UNDEF
				// make it very clear it's read only
				tbFilename.Enabled =
					cbFormat.Enabled =
					tbType.Enabled =
					tbHeaderFlag.Enabled =
					tbTreeVersion.Enabled =
					tbCacheFlags.Enabled =
					tbArgC.Enabled =
					tbLocalC.Enabled =
						/*btnSort.Visible =*/btnCommit.Visible =
						gbMove.Visible =
						btnDel.Visible =
						btnAdd.Visible =
						btnOpCode.Visible =
						btnOperandWiz.Visible = /*btnOperandRaw.Visible =*/
						btnZero.Visible =
						cbSpecial.Visible =
						btnCancel.Visible =
							false;
#endif
				pjse_banner1.ViewVisible = pjse_banner1.FloatVisible = false;
				btnClose.Visible = true;
				gbSpecial.Visible = true;
				cbSpecial.Enabled = false;
				btnCopyBHAV.Visible = currentPackage != wrapper.Package;
				btnImportBHAV.Visible =
					(currentPackage != wrapper.Package)
					&& callerID != null && callerID.IndexOf("-FFFFFFFF-") == 17; //42484156-00000000-FFFFFFFF-00001003
				btnCopyBHAV.Enabled = currentPackage != null;
				btnImportBHAV.Enabled =
					(currentPackage != null)
					&& (
						(
							wrapper.FileDescriptor.Instance >= 0x100
							&& wrapper.FileDescriptor.Instance < 0x1000
						)
						|| (
							wrapper.FileDescriptor.Instance >= 0x2000
							&& wrapper.FileDescriptor.Instance < 0x3000
						)
					);

				handleOverride();

				Text = formTitle;
				ttBhavForm.SetToolTip(tbFilename, null);
			}
			else
			{
				lbHidesOP.Visible =
					tbHidesOP.Visible =
					llHidesOP.Visible =
						false;
				llHidesOP.Tag = null;
				currentPackage = wrapper.Package;
				ttBhavForm.SetToolTip(
					tbFilename,
					expName
						+ ": 0x"
						+ Helper.HexString(
							(ushort)wrapper.FileDescriptor.Instance
						)
				);
			}
		}

		void FileDescriptor_DescriptionChanged(object sender, EventArgs e)
		{
			pjse_banner1.SiblingEnabled =
				wrapper.SiblingResource(TPRP.TPRPtype) != null;
			if (isPopup)
			{
				Text = formTitle;
			}
			else
			{
				ttBhavForm.SetToolTip(
					tbFilename,
					expName
						+ ": 0x"
						+ Helper.HexString(
							(ushort)wrapper.FileDescriptor.Instance
						)
				);
			}
		}

		private void WrapperChanged(object sender, EventArgs e)
		{
			if (isPopup)
			{
				wrapper.Changed = false;
			}

			btnCommit.Enabled = wrapper.Changed;

			// Handler for header
			if (sender == wrapper && !internalchg)
			{
				internalchg = true;
				/*this.Text = */
				tbFilename.Text = wrapper.FileName;
				cbFormat.Text = "0x" + Helper.HexString(wrapper.Header.Format);
				tbType.Text = "0x" + Helper.HexString(wrapper.Header.Type);
				tbArgC.Text = "0x" + Helper.HexString(wrapper.Header.ArgumentCount);
				tbLocalC.Text = "0x" + Helper.HexString(wrapper.Header.LocalVarCount);
				tbHeaderFlag.Text = "0x" + Helper.HexString(wrapper.Header.HeaderFlag);
				tbTreeVersion.Text =
					"0x" + Helper.HexString(wrapper.Header.TreeVersion);
				tbCacheFlags.Text = "0x" + Helper.HexString(wrapper.Header.CacheFlags);
				tbCacheFlags.Enabled = wrapper.Header.Format > 0x8008;
				cmpBHAV.Wrapper = wrapper;
				cmpBHAV.WrapperName = wrapper.FileName;
				internalchg = false;
			}

			// Handler for current instruction
			if (currentInst != null && sender == currentInst.Instruction)
			{
				if (internalchg)
				{
					btnCancel.Enabled = true;
				}
				else
				{
					pnflowcontainer_SelectedInstChanged(null, null);
				}
			}
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new Container();
			ComponentResourceManager resources =
				new ComponentResourceManager(typeof(BhavForm));
			gbInstruction = new GroupBox();
			btnZero = new Button();
			tbInst_Longname = new TextBox();
			btnOperandRaw = new Button();
			btnCancel = new Button();
			btnOperandWiz = new Button();
			llopenbhav = new LinkLabel();
			tba2 = new ComboBox();
			tba1 = new ComboBox();
			label13 = new Label();
			tbInst_Unk7 = new TextBox();
			tbInst_Unk6 = new TextBox();
			tbInst_Unk5 = new TextBox();
			tbInst_Unk4 = new TextBox();
			tbInst_Unk3 = new TextBox();
			tbInst_Unk2 = new TextBox();
			tbInst_Unk1 = new TextBox();
			tbInst_Unk0 = new TextBox();
			tbInst_Op7 = new TextBox();
			tbInst_Op6 = new TextBox();
			tbInst_Op5 = new TextBox();
			tbInst_Op4 = new TextBox();
			tbInst_Op3 = new TextBox();
			tbInst_Op2 = new TextBox();
			tbInst_Op1 = new TextBox();
			tbInst_Op0 = new TextBox();
			tbInst_NodeVersion = new TextBox();
			tbInst_OpCode = new TextBox();
			label10 = new Label();
			label9 = new Label();
			label12 = new Label();
			label11 = new Label();
			btnOpCode = new Button();
			tbFilename = new TextBox();
			lbFilename = new Label();
			tbLocalC = new TextBox();
			tbArgC = new TextBox();
			tbType = new TextBox();
			lbTreeVersion = new Label();
			lbType = new Label();
			lbLocalC = new Label();
			lbArgC = new Label();
			lbFormat = new Label();
			bhavPanel = new Panel();
			pjse_banner1 = new pjse_banner();
			lbHidesOP = new Label();
			gbSpecial = new GroupBox();
			cmpBHAV = new CompareButton();
			btnPasteListing = new Button();
			btnAppend = new Button();
			btnInsTrue = new Button();
			btnInsFalse = new Button();
			btnDelPescado = new Button();
			btnLinkInge = new Button();
			btnGUIDIndex = new Button();
			btnInsUnlinked = new Button();
			btnDelMerola = new Button();
			btnCopyListing = new Button();
			btnTPRPMaker = new Button();
			llHidesOP = new LinkLabel();
			tbHidesOP = new TextBox();
			cbSpecial = new CheckBox();
			btnImportBHAV = new Button();
			btnCopyBHAV = new Button();
			btnClose = new Button();
			tbHeaderFlag = new TextBox();
			lbHeaderFlag = new Label();
			tbCacheFlags = new TextBox();
			cbFormat = new ComboBox();
			pnflowcontainer =
				new BhavInstListControl();
			btnDel = new Button();
			gbMove = new GroupBox();
			btnUp = new Button();
			btnDown = new Button();
			lbUpDown = new Label();
			tbLines = new TextBox();
			btnSort = new Button();
			btnCommit = new Button();
			tbTreeVersion = new TextBox();
			btnAdd = new Button();
			lbCacheFlags = new Label();
			cmenuGUIDIndex = new ContextMenuStrip(
				components
			);
			createAllPackagesToolStripMenuItem =
				new ToolStripMenuItem();
			createCurrentPackageToolStripMenuItem =
				new ToolStripMenuItem();
			loadIndexToolStripMenuItem =
				new ToolStripMenuItem();
			defaultFileToolStripMenuItem =
				new ToolStripMenuItem();
			fromFileToolStripMenuItem =
				new ToolStripMenuItem();
			saveIndexToolStripMenuItem =
				new ToolStripMenuItem();
			defaultFileToolStripMenuItem1 =
				new ToolStripMenuItem();
			toFileToolStripMenuItem = new ToolStripMenuItem();
			ttBhavForm = new ToolTip(components);
			gbInstruction.SuspendLayout();
			bhavPanel.SuspendLayout();
			gbSpecial.SuspendLayout();
			gbMove.SuspendLayout();
			cmenuGUIDIndex.SuspendLayout();
			SuspendLayout();
			//
			// gbInstruction
			//
			resources.ApplyResources(gbInstruction, "gbInstruction");
			gbInstruction.Controls.Add(btnZero);
			gbInstruction.Controls.Add(tbInst_Longname);
			gbInstruction.Controls.Add(btnOperandRaw);
			gbInstruction.Controls.Add(btnCancel);
			gbInstruction.Controls.Add(btnOperandWiz);
			gbInstruction.Controls.Add(llopenbhav);
			gbInstruction.Controls.Add(tba2);
			gbInstruction.Controls.Add(tba1);
			gbInstruction.Controls.Add(label13);
			gbInstruction.Controls.Add(tbInst_Unk7);
			gbInstruction.Controls.Add(tbInst_Unk6);
			gbInstruction.Controls.Add(tbInst_Unk5);
			gbInstruction.Controls.Add(tbInst_Unk4);
			gbInstruction.Controls.Add(tbInst_Unk3);
			gbInstruction.Controls.Add(tbInst_Unk2);
			gbInstruction.Controls.Add(tbInst_Unk1);
			gbInstruction.Controls.Add(tbInst_Unk0);
			gbInstruction.Controls.Add(tbInst_Op7);
			gbInstruction.Controls.Add(tbInst_Op6);
			gbInstruction.Controls.Add(tbInst_Op5);
			gbInstruction.Controls.Add(tbInst_Op4);
			gbInstruction.Controls.Add(tbInst_Op3);
			gbInstruction.Controls.Add(tbInst_Op2);
			gbInstruction.Controls.Add(tbInst_Op1);
			gbInstruction.Controls.Add(tbInst_Op0);
			gbInstruction.Controls.Add(tbInst_NodeVersion);
			gbInstruction.Controls.Add(tbInst_OpCode);
			gbInstruction.Controls.Add(label10);
			gbInstruction.Controls.Add(label9);
			gbInstruction.Controls.Add(label12);
			gbInstruction.Controls.Add(label11);
			gbInstruction.Controls.Add(btnOpCode);
			gbInstruction.Name = "gbInstruction";
			gbInstruction.TabStop = false;
			//
			// btnZero
			//
			resources.ApplyResources(btnZero, "btnZero");
			btnZero.Name = "btnZero";
			ttBhavForm.SetToolTip(
				btnZero,
				resources.GetString("btnZero.ToolTip")
			);
			btnZero.Click += new EventHandler(btnZero_Click);
			//
			// tbInst_Longname
			//
			resources.ApplyResources(tbInst_Longname, "tbInst_Longname");
			tbInst_Longname.BorderStyle = BorderStyle.None;
			tbInst_Longname.Name = "tbInst_Longname";
			tbInst_Longname.ReadOnly = true;
			ttBhavForm.SetToolTip(
				tbInst_Longname,
				resources.GetString("tbInst_Longname.ToolTip")
			);
			//
			// btnOperandRaw
			//
			resources.ApplyResources(btnOperandRaw, "btnOperandRaw");
			btnOperandRaw.Name = "btnOperandRaw";
			ttBhavForm.SetToolTip(
				btnOperandRaw,
				resources.GetString("btnOperandRaw.ToolTip")
			);
			btnOperandRaw.Click += new EventHandler(
				btnOperandRaw_Click
			);
			//
			// btnCancel
			//
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.Click += new EventHandler(btnCancel_Clicked);
			//
			// btnOperandWiz
			//
			resources.ApplyResources(btnOperandWiz, "btnOperandWiz");
			btnOperandWiz.Name = "btnOperandWiz";
			ttBhavForm.SetToolTip(
				btnOperandWiz,
				resources.GetString("btnOperandWiz.ToolTip")
			);
			btnOperandWiz.Click += new EventHandler(
				btnOperandWiz_Clicked
			);
			//
			// llopenbhav
			//
			resources.ApplyResources(llopenbhav, "llopenbhav");
			llopenbhav.Name = "llopenbhav";
			llopenbhav.TabStop = true;
			llopenbhav.UseCompatibleTextRendering = true;
			llopenbhav.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llopenbhav_LinkClicked
				);
			//
			// tba2
			//
			resources.ApplyResources(tba2, "tba2");
			tba2.Items.AddRange(
				new object[]
				{
					resources.GetString("tba2.Items"),
					resources.GetString("tba2.Items1"),
					resources.GetString("tba2.Items2"),
				}
			);
			tba2.Name = "tba2";
			tba2.QueryContinueDrag +=
				new QueryContinueDragEventHandler(
					ItemQueryContinueDragTarget
				);
			tba2.Validating += new CancelEventHandler(
				cbHex16_Validating
			);
			tba2.DragOver += new DragEventHandler(
				ItemDragEnter
			);
			tba2.SelectedIndexChanged += new EventHandler(
				cbHex16_SelectedIndexChanged
			);
			tba2.Enter += new EventHandler(cbHex16_Enter);
			tba2.DragDrop += new DragEventHandler(
				ItemDrop
			);
			tba2.DragEnter += new DragEventHandler(
				ItemDragEnter
			);
			tba2.Validated += new EventHandler(cbHex16_Validated);
			tba2.TextChanged += new EventHandler(cbHex16_TextChanged);
			//
			// tba1
			//
			resources.ApplyResources(tba1, "tba1");
			tba1.Items.AddRange(
				new object[]
				{
					resources.GetString("tba1.Items"),
					resources.GetString("tba1.Items1"),
					resources.GetString("tba1.Items2"),
				}
			);
			tba1.Name = "tba1";
			tba1.QueryContinueDrag +=
				new QueryContinueDragEventHandler(
					ItemQueryContinueDragTarget
				);
			tba1.Validating += new CancelEventHandler(
				cbHex16_Validating
			);
			tba1.DragOver += new DragEventHandler(
				ItemDragEnter
			);
			tba1.SelectedIndexChanged += new EventHandler(
				cbHex16_SelectedIndexChanged
			);
			tba1.Enter += new EventHandler(cbHex16_Enter);
			tba1.DragDrop += new DragEventHandler(
				ItemDrop
			);
			tba1.DragEnter += new DragEventHandler(
				ItemDragEnter
			);
			tba1.Validated += new EventHandler(cbHex16_Validated);
			tba1.TextChanged += new EventHandler(cbHex16_TextChanged);
			//
			// label13
			//
			resources.ApplyResources(label13, "label13");
			label13.Name = "label13";
			//
			// tbInst_Unk7
			//
			resources.ApplyResources(tbInst_Unk7, "tbInst_Unk7");
			tbInst_Unk7.Name = "tbInst_Unk7";
			tbInst_Unk7.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Unk7.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk7.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk6
			//
			resources.ApplyResources(tbInst_Unk6, "tbInst_Unk6");
			tbInst_Unk6.Name = "tbInst_Unk6";
			tbInst_Unk6.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Unk6.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk6.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk5
			//
			resources.ApplyResources(tbInst_Unk5, "tbInst_Unk5");
			tbInst_Unk5.Name = "tbInst_Unk5";
			tbInst_Unk5.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Unk5.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk5.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk4
			//
			resources.ApplyResources(tbInst_Unk4, "tbInst_Unk4");
			tbInst_Unk4.Name = "tbInst_Unk4";
			tbInst_Unk4.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Unk4.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk4.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk3
			//
			resources.ApplyResources(tbInst_Unk3, "tbInst_Unk3");
			tbInst_Unk3.Name = "tbInst_Unk3";
			tbInst_Unk3.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Unk3.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk3.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk2
			//
			resources.ApplyResources(tbInst_Unk2, "tbInst_Unk2");
			tbInst_Unk2.Name = "tbInst_Unk2";
			tbInst_Unk2.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Unk2.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk2.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk1
			//
			resources.ApplyResources(tbInst_Unk1, "tbInst_Unk1");
			tbInst_Unk1.Name = "tbInst_Unk1";
			tbInst_Unk1.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Unk1.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk1.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Unk0
			//
			resources.ApplyResources(tbInst_Unk0, "tbInst_Unk0");
			tbInst_Unk0.Name = "tbInst_Unk0";
			tbInst_Unk0.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Unk0.Validated += new EventHandler(hex8_Validated);
			tbInst_Unk0.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op7
			//
			resources.ApplyResources(tbInst_Op7, "tbInst_Op7");
			tbInst_Op7.Name = "tbInst_Op7";
			tbInst_Op7.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Op7.Validated += new EventHandler(hex8_Validated);
			tbInst_Op7.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op6
			//
			resources.ApplyResources(tbInst_Op6, "tbInst_Op6");
			tbInst_Op6.Name = "tbInst_Op6";
			tbInst_Op6.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Op6.Validated += new EventHandler(hex8_Validated);
			tbInst_Op6.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op5
			//
			resources.ApplyResources(tbInst_Op5, "tbInst_Op5");
			tbInst_Op5.Name = "tbInst_Op5";
			tbInst_Op5.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Op5.Validated += new EventHandler(hex8_Validated);
			tbInst_Op5.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op4
			//
			resources.ApplyResources(tbInst_Op4, "tbInst_Op4");
			tbInst_Op4.Name = "tbInst_Op4";
			tbInst_Op4.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Op4.Validated += new EventHandler(hex8_Validated);
			tbInst_Op4.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op3
			//
			resources.ApplyResources(tbInst_Op3, "tbInst_Op3");
			tbInst_Op3.Name = "tbInst_Op3";
			tbInst_Op3.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Op3.Validated += new EventHandler(hex8_Validated);
			tbInst_Op3.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op2
			//
			resources.ApplyResources(tbInst_Op2, "tbInst_Op2");
			tbInst_Op2.Name = "tbInst_Op2";
			tbInst_Op2.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Op2.Validated += new EventHandler(hex8_Validated);
			tbInst_Op2.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op1
			//
			resources.ApplyResources(tbInst_Op1, "tbInst_Op1");
			tbInst_Op1.Name = "tbInst_Op1";
			tbInst_Op1.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Op1.Validated += new EventHandler(hex8_Validated);
			tbInst_Op1.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_Op0
			//
			resources.ApplyResources(tbInst_Op0, "tbInst_Op0");
			tbInst_Op0.Name = "tbInst_Op0";
			tbInst_Op0.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_Op0.Validated += new EventHandler(hex8_Validated);
			tbInst_Op0.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbInst_NodeVersion
			//
			resources.ApplyResources(tbInst_NodeVersion, "tbInst_NodeVersion");
			tbInst_NodeVersion.Name = "tbInst_NodeVersion";
			tbInst_NodeVersion.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbInst_NodeVersion.Validated += new EventHandler(
				hex8_Validated
			);
			tbInst_NodeVersion.Validating +=
				new CancelEventHandler(hex8_Validating);
			//
			// tbInst_OpCode
			//
			resources.ApplyResources(tbInst_OpCode, "tbInst_OpCode");
			tbInst_OpCode.Name = "tbInst_OpCode";
			tbInst_OpCode.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			tbInst_OpCode.Validated += new EventHandler(
				hex16_Validated
			);
			tbInst_OpCode.Validating +=
				new CancelEventHandler(hex16_Validating);
			//
			// label10
			//
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			//
			// label9
			//
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			//
			// label12
			//
			resources.ApplyResources(label12, "label12");
			label12.Name = "label12";
			//
			// label11
			//
			resources.ApplyResources(label11, "label11");
			label11.Name = "label11";
			//
			// btnOpCode
			//
			resources.ApplyResources(btnOpCode, "btnOpCode");
			btnOpCode.Name = "btnOpCode";
			btnOpCode.Click += new EventHandler(btnOpCode_Clicked);
			//
			// tbFilename
			//
			resources.ApplyResources(tbFilename, "tbFilename");
			tbFilename.Name = "tbFilename";
			tbFilename.TextChanged += new EventHandler(
				tbFilename_TextChanged
			);
			tbFilename.Validated += new EventHandler(
				tbFilename_Validated
			);
			//
			// lbFilename
			//
			resources.ApplyResources(lbFilename, "lbFilename");
			lbFilename.Name = "lbFilename";
			//
			// tbLocalC
			//
			resources.ApplyResources(tbLocalC, "tbLocalC");
			tbLocalC.Name = "tbLocalC";
			ttBhavForm.SetToolTip(
				tbLocalC,
				resources.GetString("tbLocalC.ToolTip")
			);
			tbLocalC.TextChanged += new EventHandler(hex8_TextChanged);
			tbLocalC.Validated += new EventHandler(hex8_Validated);
			tbLocalC.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbArgC
			//
			resources.ApplyResources(tbArgC, "tbArgC");
			tbArgC.Name = "tbArgC";
			ttBhavForm.SetToolTip(
				tbArgC,
				resources.GetString("tbArgC.ToolTip")
			);
			tbArgC.TextChanged += new EventHandler(hex8_TextChanged);
			tbArgC.Validated += new EventHandler(hex8_Validated);
			tbArgC.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// tbType
			//
			resources.ApplyResources(tbType, "tbType");
			tbType.Name = "tbType";
			tbType.TextChanged += new EventHandler(hex8_TextChanged);
			tbType.Validated += new EventHandler(hex8_Validated);
			tbType.Validating += new CancelEventHandler(
				hex8_Validating
			);
			//
			// lbTreeVersion
			//
			resources.ApplyResources(lbTreeVersion, "lbTreeVersion");
			lbTreeVersion.Name = "lbTreeVersion";
			//
			// lbType
			//
			resources.ApplyResources(lbType, "lbType");
			lbType.Name = "lbType";
			//
			// lbLocalC
			//
			resources.ApplyResources(lbLocalC, "lbLocalC");
			lbLocalC.Name = "lbLocalC";
			//
			// lbArgC
			//
			resources.ApplyResources(lbArgC, "lbArgC");
			lbArgC.Name = "lbArgC";
			//
			// lbFormat
			//
			resources.ApplyResources(lbFormat, "lbFormat");
			lbFormat.Name = "lbFormat";
			//
			// bhavPanel
			//
			resources.ApplyResources(bhavPanel, "bhavPanel");
			bhavPanel.BackColor = SystemColors.Control;
			bhavPanel.Controls.Add(pjse_banner1);
			bhavPanel.Controls.Add(lbHidesOP);
			bhavPanel.Controls.Add(gbSpecial);
			bhavPanel.Controls.Add(llHidesOP);
			bhavPanel.Controls.Add(tbHidesOP);
			bhavPanel.Controls.Add(cbSpecial);
			bhavPanel.Controls.Add(btnImportBHAV);
			bhavPanel.Controls.Add(btnCopyBHAV);
			bhavPanel.Controls.Add(btnClose);
			bhavPanel.Controls.Add(tbHeaderFlag);
			bhavPanel.Controls.Add(lbHeaderFlag);
			bhavPanel.Controls.Add(tbCacheFlags);
			bhavPanel.Controls.Add(cbFormat);
			bhavPanel.Controls.Add(pnflowcontainer);
			bhavPanel.Controls.Add(btnDel);
			bhavPanel.Controls.Add(gbMove);
			bhavPanel.Controls.Add(btnSort);
			bhavPanel.Controls.Add(btnCommit);
			bhavPanel.Controls.Add(lbFilename);
			bhavPanel.Controls.Add(tbFilename);
			bhavPanel.Controls.Add(gbInstruction);
			bhavPanel.Controls.Add(tbLocalC);
			bhavPanel.Controls.Add(tbTreeVersion);
			bhavPanel.Controls.Add(tbArgC);
			bhavPanel.Controls.Add(tbType);
			bhavPanel.Controls.Add(lbTreeVersion);
			bhavPanel.Controls.Add(lbType);
			bhavPanel.Controls.Add(lbLocalC);
			bhavPanel.Controls.Add(lbArgC);
			bhavPanel.Controls.Add(lbFormat);
			bhavPanel.Controls.Add(btnAdd);
			bhavPanel.Controls.Add(lbCacheFlags);
			bhavPanel.Name = "bhavPanel";
			//
			// pjse_banner1
			//
			resources.ApplyResources(pjse_banner1, "pjse_banner1");
			pjse_banner1.BackColor = SystemColors.AppWorkspace;
			pjse_banner1.ExtractVisible = true;
			pjse_banner1.FloatVisible = true;
			pjse_banner1.Name = "pjse_banner1";
			pjse_banner1.SiblingVisible = true;
			pjse_banner1.ViewVisible = true;
			pjse_banner1.ExtractClick += new EventHandler(
				pjse_banner1_ExtractClick
			);
			pjse_banner1.SiblingClick += new EventHandler(
				pjse_banner1_SiblingClick
			);
			pjse_banner1.ViewClick += new EventHandler(
				pjse_banner1_ViewClick
			);
			pjse_banner1.FloatClick += new EventHandler(
				btnFloat_Click
			);
			//
			// lbHidesOP
			//
			resources.ApplyResources(lbHidesOP, "lbHidesOP");
			lbHidesOP.Name = "lbHidesOP";
			//
			// gbSpecial
			//
			resources.ApplyResources(gbSpecial, "gbSpecial");
			gbSpecial.Controls.Add(cmpBHAV);
			gbSpecial.Controls.Add(btnPasteListing);
			gbSpecial.Controls.Add(btnAppend);
			gbSpecial.Controls.Add(btnInsTrue);
			gbSpecial.Controls.Add(btnInsFalse);
			gbSpecial.Controls.Add(btnDelPescado);
			gbSpecial.Controls.Add(btnLinkInge);
			gbSpecial.Controls.Add(btnGUIDIndex);
			gbSpecial.Controls.Add(btnInsUnlinked);
			gbSpecial.Controls.Add(btnDelMerola);
			gbSpecial.Controls.Add(btnCopyListing);
			gbSpecial.Controls.Add(btnTPRPMaker);
			gbSpecial.Name = "gbSpecial";
			gbSpecial.TabStop = false;
			//
			// cmpBHAV
			//
			resources.ApplyResources(cmpBHAV, "cmpBHAV");
			cmpBHAV.Name = "cmpBHAV";
			cmpBHAV.UseVisualStyleBackColor = true;
			cmpBHAV.Wrapper = null;
			cmpBHAV.WrapperName = null;
			cmpBHAV.CompareWith += new CompareButton.CompareWithEventHandler(
				cmpBHAV_CompareWith
			);
			//
			// btnPasteListing
			//
			resources.ApplyResources(btnPasteListing, "btnPasteListing");
			btnPasteListing.Name = "btnPasteListing";
			btnPasteListing.Click += new EventHandler(
				btnPasteListing_Click
			);
			//
			// btnAppend
			//
			resources.ApplyResources(btnAppend, "btnAppend");
			btnAppend.Name = "btnAppend";
			btnAppend.Click += new EventHandler(btnAppend_Click);
			//
			// btnInsTrue
			//
			resources.ApplyResources(btnInsTrue, "btnInsTrue");
			btnInsTrue.Name = "btnInsTrue";
			btnInsTrue.Click += new EventHandler(btnInsVia_Click);
			//
			// btnInsFalse
			//
			resources.ApplyResources(btnInsFalse, "btnInsFalse");
			btnInsFalse.Name = "btnInsFalse";
			btnInsFalse.Click += new EventHandler(btnInsVia_Click);
			//
			// btnDelPescado
			//
			resources.ApplyResources(btnDelPescado, "btnDelPescado");
			btnDelPescado.Name = "btnDelPescado";
			btnDelPescado.Click += new EventHandler(
				btnDelPescado_Click
			);
			//
			// btnLinkInge
			//
			resources.ApplyResources(btnLinkInge, "btnLinkInge");
			btnLinkInge.Name = "btnLinkInge";
			btnLinkInge.Click += new EventHandler(btnLinkInge_Click);
			//
			// btnGUIDIndex
			//
			resources.ApplyResources(btnGUIDIndex, "btnGUIDIndex");
			btnGUIDIndex.Name = "btnGUIDIndex";
			btnGUIDIndex.Click += new EventHandler(btnGUIDIndex_Click);
			//
			// btnInsUnlinked
			//
			resources.ApplyResources(btnInsUnlinked, "btnInsUnlinked");
			btnInsUnlinked.Name = "btnInsUnlinked";
			btnInsUnlinked.Click += new EventHandler(
				btnInsUnlinked_Click
			);
			//
			// btnDelMerola
			//
			resources.ApplyResources(btnDelMerola, "btnDelMerola");
			btnDelMerola.Name = "btnDelMerola";
			btnDelMerola.Click += new EventHandler(btnDelMerola_Click);
			//
			// btnCopyListing
			//
			resources.ApplyResources(btnCopyListing, "btnCopyListing");
			btnCopyListing.Name = "btnCopyListing";
			btnCopyListing.Click += new EventHandler(
				btnCopyListing_Click
			);
			//
			// btnTPRPMaker
			//
			resources.ApplyResources(btnTPRPMaker, "btnTPRPMaker");
			btnTPRPMaker.Name = "btnTPRPMaker";
			btnTPRPMaker.Click += new EventHandler(btnTPRPMaker_Click);
			//
			// llHidesOP
			//
			resources.ApplyResources(llHidesOP, "llHidesOP");
			llHidesOP.Name = "llHidesOP";
			llHidesOP.TabStop = true;
			llHidesOP.UseCompatibleTextRendering = true;
			llHidesOP.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llHidesOP_LinkClicked
				);
			//
			// tbHidesOP
			//
			resources.ApplyResources(tbHidesOP, "tbHidesOP");
			tbHidesOP.BackColor = SystemColors.Control;
			tbHidesOP.BorderStyle = BorderStyle.None;
			tbHidesOP.Name = "tbHidesOP";
			tbHidesOP.ReadOnly = true;
			//
			// cbSpecial
			//
			resources.ApplyResources(cbSpecial, "cbSpecial");
			cbSpecial.Name = "cbSpecial";
			cbSpecial.CheckStateChanged += new EventHandler(
				cbSpecial_CheckStateChanged
			);
			//
			// btnImportBHAV
			//
			resources.ApplyResources(btnImportBHAV, "btnImportBHAV");
			btnImportBHAV.Name = "btnImportBHAV";
			btnImportBHAV.Click += new EventHandler(
				btnImportBHAV_Click
			);
			//
			// btnCopyBHAV
			//
			resources.ApplyResources(btnCopyBHAV, "btnCopyBHAV");
			btnCopyBHAV.Name = "btnCopyBHAV";
			btnCopyBHAV.Click += new EventHandler(btnCopyBHAV_Click);
			//
			// btnClose
			//
			resources.ApplyResources(btnClose, "btnClose");
			btnClose.DialogResult = DialogResult.Cancel;
			btnClose.Name = "btnClose";
			btnClose.Click += new EventHandler(btnClose_Click);
			//
			// tbHeaderFlag
			//
			resources.ApplyResources(tbHeaderFlag, "tbHeaderFlag");
			tbHeaderFlag.Name = "tbHeaderFlag";
			tbHeaderFlag.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbHeaderFlag.Validated += new EventHandler(hex8_Validated);
			tbHeaderFlag.Validating +=
				new CancelEventHandler(hex8_Validating);
			//
			// lbHeaderFlag
			//
			resources.ApplyResources(lbHeaderFlag, "lbHeaderFlag");
			lbHeaderFlag.Name = "lbHeaderFlag";
			//
			// tbCacheFlags
			//
			resources.ApplyResources(tbCacheFlags, "tbCacheFlags");
			tbCacheFlags.Name = "tbCacheFlags";
			tbCacheFlags.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			tbCacheFlags.Validated += new EventHandler(hex8_Validated);
			tbCacheFlags.Validating +=
				new CancelEventHandler(hex8_Validating);
			//
			// cbFormat
			//
			resources.ApplyResources(cbFormat, "cbFormat");
			cbFormat.Items.AddRange(
				new object[]
				{
					resources.GetString("cbFormat.Items"),
					resources.GetString("cbFormat.Items1"),
					resources.GetString("cbFormat.Items2"),
					resources.GetString("cbFormat.Items3"),
					resources.GetString("cbFormat.Items4"),
					resources.GetString("cbFormat.Items5"),
					resources.GetString("cbFormat.Items6"),
					resources.GetString("cbFormat.Items7"),
					resources.GetString("cbFormat.Items8"),
					resources.GetString("cbFormat.Items9"),
				}
			);
			cbFormat.Name = "cbFormat";
			cbFormat.Validating += new CancelEventHandler(
				cbHex16_Validating
			);
			cbFormat.SelectedIndexChanged += new EventHandler(
				cbHex16_SelectedIndexChanged
			);
			cbFormat.Enter += new EventHandler(cbHex16_Enter);
			cbFormat.Validated += new EventHandler(cbHex16_Validated);
			cbFormat.TextChanged += new EventHandler(
				cbHex16_TextChanged
			);
			//
			// pnflowcontainer
			//
			resources.ApplyResources(pnflowcontainer, "pnflowcontainer");
			pnflowcontainer.Name = "pnflowcontainer";
			pnflowcontainer.SelectedIndex = -1;
			pnflowcontainer.SelectedInstChanged += new EventHandler(
				pnflowcontainer_SelectedInstChanged
			);
			//
			// btnDel
			//
			resources.ApplyResources(btnDel, "btnDel");
			btnDel.Name = "btnDel";
			btnDel.Click += new EventHandler(btnDel_Clicked);
			//
			// gbMove
			//
			resources.ApplyResources(gbMove, "gbMove");
			gbMove.Controls.Add(btnUp);
			gbMove.Controls.Add(btnDown);
			gbMove.Controls.Add(lbUpDown);
			gbMove.Controls.Add(tbLines);
			gbMove.Name = "gbMove";
			gbMove.TabStop = false;
			//
			// btnUp
			//
			resources.ApplyResources(btnUp, "btnUp");
			btnUp.Name = "btnUp";
			btnUp.Click += new EventHandler(btnMove_Clicked);
			//
			// btnDown
			//
			resources.ApplyResources(btnDown, "btnDown");
			btnDown.Name = "btnDown";
			btnDown.Click += new EventHandler(btnMove_Clicked);
			//
			// lbUpDown
			//
			resources.ApplyResources(lbUpDown, "lbUpDown");
			lbUpDown.Name = "lbUpDown";
			//
			// tbLines
			//
			resources.ApplyResources(tbLines, "tbLines");
			tbLines.Name = "tbLines";
			tbLines.TextChanged += new EventHandler(hex16_TextChanged);
			tbLines.Validated += new EventHandler(hex16_Validated);
			tbLines.Validating += new CancelEventHandler(
				hex16_Validating
			);
			//
			// btnSort
			//
			resources.ApplyResources(btnSort, "btnSort");
			btnSort.Name = "btnSort";
			btnSort.Click += new EventHandler(btnSort_Clicked);
			//
			// btnCommit
			//
			resources.ApplyResources(btnCommit, "btnCommit");
			btnCommit.Name = "btnCommit";
			btnCommit.Click += new EventHandler(btnCommit_Clicked);
			//
			// tbTreeVersion
			//
			resources.ApplyResources(tbTreeVersion, "tbTreeVersion");
			tbTreeVersion.Name = "tbTreeVersion";
			tbTreeVersion.TextChanged += new EventHandler(
				hex32_TextChanged
			);
			tbTreeVersion.Validated += new EventHandler(
				hex32_Validated
			);
			tbTreeVersion.Validating +=
				new CancelEventHandler(hex32_Validating);
			//
			// btnAdd
			//
			resources.ApplyResources(btnAdd, "btnAdd");
			btnAdd.Name = "btnAdd";
			btnAdd.Click += new EventHandler(btnAdd_Clicked);
			//
			// lbCacheFlags
			//
			resources.ApplyResources(lbCacheFlags, "lbCacheFlags");
			lbCacheFlags.Name = "lbCacheFlags";
			//
			// cmenuGUIDIndex
			//
			cmenuGUIDIndex.Items.AddRange(
				new ToolStripItem[]
				{
					createAllPackagesToolStripMenuItem,
					createCurrentPackageToolStripMenuItem,
					loadIndexToolStripMenuItem,
					saveIndexToolStripMenuItem,
				}
			);
			cmenuGUIDIndex.Name = "cmenuGUIDIndex";
			resources.ApplyResources(cmenuGUIDIndex, "cmenuGUIDIndex");
			cmenuGUIDIndex.Opening += new CancelEventHandler(
				cmenuGUIDIndex_Opening
			);
			//
			// createAllPackagesToolStripMenuItem
			//
			createAllPackagesToolStripMenuItem.Name =
				"createAllPackagesToolStripMenuItem";
			resources.ApplyResources(
				createAllPackagesToolStripMenuItem,
				"createAllPackagesToolStripMenuItem"
			);
			createAllPackagesToolStripMenuItem.Click += new EventHandler(
				createToolStripMenuItem_Click
			);
			//
			// createCurrentPackageToolStripMenuItem
			//
			createCurrentPackageToolStripMenuItem.Name =
				"createCurrentPackageToolStripMenuItem";
			resources.ApplyResources(
				createCurrentPackageToolStripMenuItem,
				"createCurrentPackageToolStripMenuItem"
			);
			createCurrentPackageToolStripMenuItem.Click += new EventHandler(
				createToolStripMenuItem_Click
			);
			//
			// loadIndexToolStripMenuItem
			//
			loadIndexToolStripMenuItem.DropDownItems.AddRange(
				new ToolStripItem[]
				{
					defaultFileToolStripMenuItem,
					fromFileToolStripMenuItem,
				}
			);
			loadIndexToolStripMenuItem.Name = "loadIndexToolStripMenuItem";
			resources.ApplyResources(
				loadIndexToolStripMenuItem,
				"loadIndexToolStripMenuItem"
			);
			//
			// defaultFileToolStripMenuItem
			//
			defaultFileToolStripMenuItem.Name = "defaultFileToolStripMenuItem";
			resources.ApplyResources(
				defaultFileToolStripMenuItem,
				"defaultFileToolStripMenuItem"
			);
			defaultFileToolStripMenuItem.Click += new EventHandler(
				defaultFileToolStripMenuItem_Click
			);
			//
			// fromFileToolStripMenuItem
			//
			fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
			resources.ApplyResources(
				fromFileToolStripMenuItem,
				"fromFileToolStripMenuItem"
			);
			fromFileToolStripMenuItem.Click += new EventHandler(
				fileToolStripMenuItem_Click
			);
			//
			// saveIndexToolStripMenuItem
			//
			saveIndexToolStripMenuItem.DropDownItems.AddRange(
				new ToolStripItem[]
				{
					defaultFileToolStripMenuItem1,
					toFileToolStripMenuItem,
				}
			);
			saveIndexToolStripMenuItem.Name = "saveIndexToolStripMenuItem";
			resources.ApplyResources(
				saveIndexToolStripMenuItem,
				"saveIndexToolStripMenuItem"
			);
			//
			// defaultFileToolStripMenuItem1
			//
			defaultFileToolStripMenuItem1.Name = "defaultFileToolStripMenuItem1";
			resources.ApplyResources(
				defaultFileToolStripMenuItem1,
				"defaultFileToolStripMenuItem1"
			);
			defaultFileToolStripMenuItem1.Click += new EventHandler(
				defaultFileToolStripMenuItem_Click
			);
			//
			// toFileToolStripMenuItem
			//
			toFileToolStripMenuItem.Name = "toFileToolStripMenuItem";
			resources.ApplyResources(
				toFileToolStripMenuItem,
				"toFileToolStripMenuItem"
			);
			toFileToolStripMenuItem.Click += new EventHandler(
				fileToolStripMenuItem_Click
			);
			//
			// ttBhavForm
			//
			ttBhavForm.ShowAlways = true;
			//
			// BhavForm
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			CancelButton = btnClose;
			Controls.Add(bhavPanel);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Name = "BhavForm";
			WindowState = FormWindowState.Maximized;
			gbInstruction.ResumeLayout(false);
			gbInstruction.PerformLayout();
			bhavPanel.ResumeLayout(false);
			bhavPanel.PerformLayout();
			gbSpecial.ResumeLayout(false);
			gbMove.ResumeLayout(false);
			gbMove.PerformLayout();
			cmenuGUIDIndex.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private void pnflowcontainer_SelectedInstChanged(
			object sender,
			EventArgs e
		)
		{
			int index = pnflowcontainer.SelectedIndex;
			if (index < 0 || index >= wrapper.Count)
			{
				currentInst = null;
				origInst = null;
			}
			else
			{
				currentInst = wrapper[index];
				origInst = wrapper[index].Clone();
			}
			UpdateInstPanel();
			btnCancel.Enabled = false;
		}

		private void ItemQueryContinueDragTarget(
			object sender,
			QueryContinueDragEventArgs e
		)
		{
			e.Action = e.KeyState == 0 ? DragAction.Drop : DragAction.Continue;
		}

		private void ItemDragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.Data.GetDataPresent(typeof(int)) ? DragDropEffects.Link : DragDropEffects.None;
		}

		private void ItemDrop(object sender, DragEventArgs e)
		{
			int sel = 0;
			sel = (int)e.Data.GetData(sel.GetType());
			ComboBox cb = (ComboBox)sender;
			cb.SelectedIndex = -1;
			cb.Text = "0x" + Helper.HexString((ushort)sel);
		}

		private void btnCommit_Clicked(object sender, EventArgs e)
		{
			try
			{
				wrapper.SynchronizeUserData();
				btnCommit.Enabled = wrapper.Changed;
				pnflowcontainer_SelectedInstChanged(null, null);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					pjse.Localization.GetString("errwritingfile"),
					ex
				);
			}
		}

		private void btnCancel_Clicked(object sender, EventArgs e)
		{
			wrapper[pnflowcontainer.SelectedIndex] = origInst.Clone();
			pnflowcontainer_SelectedInstChanged(null, null);
		}

		private void pjse_banner1_SiblingClick(object sender, EventArgs e)
		{
			TPRP tprp = (TPRP)wrapper.SiblingResource(TPRP.TPRPtype);
			if (tprp == null)
			{
				return;
			}

			if (tprp.Package != wrapper.Package)
			{
				DialogResult dr = MessageBox.Show(
					Localization.GetString("OpenOtherPkg"),
					pjse_banner1.TitleText,
					MessageBoxButtons.YesNo
				);
				if (dr != DialogResult.Yes)
				{
					return;
				}
			}
			RemoteControl.OpenPackedFile(tprp.FileDescriptor, tprp.Package);
		}

		private void btnFloat_Click(object sender, EventArgs e)
		{
			Control old = bhavPanel.Parent;
			string oldFloatText = pjse_banner1.FloatText;

			Form f = new Form
			{
				Text = formTitle,
				WindowState = FormWindowState.Maximized
			};

			f.Controls.Add(bhavPanel);
			pjse_banner1.FloatText = pjse.Localization.GetString(
				"bhavForm.Unfloat"
			);
			pjse_banner1.FloatClick -= new EventHandler(
				btnFloat_Click
			);
			pjse_banner1.SetFormCancelButton(f);

			gbSpecial.Visible = true;
			cbSpecial.Enabled = false;
			btnCopyBHAV.Visible = false;

			handleOverride();

			f.ShowDialog();

			old.Controls.Add(bhavPanel);
			pjse_banner1.FloatText = oldFloatText;
			pjse_banner1.FloatClick += new EventHandler(
				btnFloat_Click
			);

			gbSpecial.Visible = cbSpecial.Checked;
			cbSpecial.Enabled = true;

			lbHidesOP.Visible =
				tbHidesOP.Visible =
				llHidesOP.Visible =
					false;
			llHidesOP.Tag = null;

			f.Dispose();

			wrapper.RefreshUI();
		}

		private void pjse_banner1_ViewClick(object sender, EventArgs e)
		{
			common_LinkClicked(
				pjse.FileTable.GFT[wrapper.Package, wrapper.FileDescriptor][0]
			);
		}

		private void llopenbhav_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			common_LinkClicked(
				wrapper.ResourceByInstance(
					Data.MetaData.BHAV_FILE,
					currentInst.Instruction.OpCode
				)
			);
		}

		private void llHidesOP_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			common_LinkClicked(
				wrapper.ResourceByInstance(
					Data.MetaData.BHAV_FILE,
					wrapper.FileDescriptor.Instance,
					(pjse.FileTable.Source)llHidesOP.Tag
				)
			);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if (isPopup)
			{
				Close();
			}
		}

		private void btnCopyBHAV_Click(object sender, EventArgs e)
		{
			btnCopyBHAV.Enabled = false;
			TakeACopy();
			btnCopyBHAV.Text = pjse.Localization.GetString("ml_done");
		}

		private void btnImportBHAV_Click(object sender, EventArgs e)
		{
			btnImportBHAV.Enabled = false;
			ImportBHAV();
			btnImportBHAV.Text = pjse.Localization.GetString("ml_done");
		}

		private void pjse_banner1_ExtractClick(object sender, EventArgs e)
		{
			ExtractCurrent.Execute(wrapper, pjse_banner1.TitleText);
		}

		private void btnOpCode_Clicked(object sender, EventArgs e)
		{
			pjse.FileTable.Entry item = new ResourceChooser().Execute(
				Data.MetaData.BHAV_FILE,
				wrapper.FileDescriptor.Group,
				bhavPanel.Parent,
				false
			);

			if (item != null && item.Instance != currentInst.Instruction.OpCode)
			{
				tbInst_OpCode.Text =
					"0x" + Helper.HexString((ushort)item.Instance);
			}
		}

		private void btnOperandWiz_Clicked(object sender, EventArgs e)
		{
			OperandWiz(1);
		}

		private void btnOperandRaw_Click(object sender, EventArgs e)
		{
			OperandWiz(0);
		}

		private void btnZero_Click(object sender, EventArgs e)
		{
			internalchg = true;
			Instruction inst = currentInst.Instruction;
			currentInst = null;
			try
			{
				for (int i = 0; i < 8; i++)
				{
					inst.Operands[i] = 0;
				}

				for (int i = 0; i < 8; i++)
				{
					inst.Reserved1[i] = 0;
				}
			}
			finally
			{
				currentInst = inst;
				UpdateInstPanel();
				btnCancel.Enabled = true;
				internalchg = false;
			}
		}

		private void tbFilename_TextChanged(object sender, EventArgs e)
		{
			wrapper.FileName = tbFilename.Text;
		}

		private void tbFilename_Validated(object sender, EventArgs e)
		{
			tbFilename.SelectAll();
		}

		private void cbHex16_Enter(object sender, EventArgs e)
		{
			((ComboBox)sender).SelectAll();
		}

		private void cbHex16_TextChanged(object sender, EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!cbHex16_IsValid(sender))
			{
				return;
			}

			if (((ComboBox)sender).Items.IndexOf(((ComboBox)sender).Text) != -1)
			{
				return;
			}

			ushort val = Convert.ToUInt16(((ComboBox)sender).Text, 16);
			internalchg = true;
			switch (alHex16cb.IndexOf(sender))
			{
				case 0:
					currentInst.Instruction.Target1 = val;
					break;
				case 1:
					currentInst.Instruction.Target2 = val;
					break;
				case 2:
					wrapper.Header.Format = val;
					break;
			}
			internalchg = false;
		}

		private void cbHex16_Validating(
			object sender,
			CancelEventArgs e
		)
		{
			if (cbHex16_IsValid(sender))
			{
				return;
			}

			int i = alHex16cb.IndexOf(sender);
			if (i < 0)
			{
				throw new Exception(
					"cbHex16_Validating not applicable to control " + sender.ToString()
				);
			}

			e.Cancel = true;

			ushort val = 0;
			switch (i)
			{
				case 0:
					val = origInst.Target1;
					break;
				case 1:
					val = origInst.Target2;
					break;
				case 2:
					val = wrapper.Header.Format;
					break;
			}

			if (i < 2 && val >= 0xfffc && val <= 0xfffe)
			{
				((ComboBox)sender).SelectedIndex = val - 0xfffc;
			}
			else if (i == 2 && val >= 0x8000 && val <= 0x8007)
			{
				((ComboBox)sender).SelectedIndex = val - 0x8000;
			}
			else
			{
				((ComboBox)sender).SelectedIndex = -1;
				((ComboBox)sender).Text = "0x" + Helper.HexString(val);
			}
			((ComboBox)sender).SelectAll();
		}

		private void cbHex16_Validated(object sender, EventArgs e)
		{
			int i = alHex16cb.IndexOf(sender);
			if (i < 0)
			{
				throw new Exception(
					"cbHex16_Validated not applicable to control " + sender.ToString()
				);
			}

			if (((ComboBox)sender).Items.IndexOf(((ComboBox)sender).Text) != -1)
			{
				return;
			}

			ushort val = Convert.ToUInt16(((ComboBox)sender).Text, 16);

			bool origstate = internalchg;
			internalchg = true;
			if (i < 2 && val >= 0xfffc && val <= 0xfffe)
			{
				((ComboBox)sender).SelectedIndex = val - 0xfffc;
			}
			else if (i == 2 && val >= 0x8000 && val <= 0x8007)
			{
				((ComboBox)sender).SelectedIndex = val - 0x8000;
			}
			else
			{
				((ComboBox)sender).SelectedIndex = -1;
				((ComboBox)sender).Text = "0x" + Helper.HexString(val);
			}
			internalchg = origstate;
			((ComboBox)sender).Select(0, 0);
		}

		private void cbHex16_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			int i = alHex16cb.IndexOf(sender);
			if (i < 0)
			{
				throw new Exception(
					"cbHex16_SelectedIndexChanged not applicable to control "
						+ sender.ToString()
				);
			}

			if (((ComboBox)sender).SelectedIndex == -1)
			{
				return;
			}

			ushort val = (ushort)((ComboBox)alHex16cb[i]).SelectedIndex;
			((ComboBox)sender).SelectAll();

			internalchg = true;
			if (i < 2)
			{
				val += 0xFFFC;
				if (i == 0)
				{
					currentInst.Instruction.Target1 = val;
				}
				else
				{
					currentInst.Instruction.Target2 = val;
				}
			}
			else
			{
				val += 0x8000;
				wrapper.Header.Format = val;
			}
			internalchg = false;
		}

		private void dec8_TextChanged(object sender, EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!dec8_IsValid(sender))
			{
				return;
			}

			byte val = Convert.ToByte(((TextBox)sender).Text);
			internalchg = true;
			switch (alDec8.IndexOf(sender))
			{
				default:
					break;
			}
			internalchg = false;
		}

		private void dec8_Validating(
			object sender,
			CancelEventArgs e
		)
		{
			if (dec8_IsValid(sender))
			{
				return;
			}

			e.Cancel = true;

			byte val = 0;
			switch (alDec8.IndexOf(sender))
			{
				default:
					break;
			}

			((TextBox)sender).Text = val.ToString();
			((TextBox)sender).SelectAll();
		}

#if DEC16
		private void dec16_TextChanged(object sender, System.EventArgs ev)
		{
			if (internalchg)
				return;
			if (!dec16_IsValid(sender))
				return;

			byte[] ops = ShortToOps(Convert.ToInt16(((TextBox)sender).Text));
			internalchg = true;
			switch (alDec16.IndexOf(sender))
			{
				case 0:
					currentInst.Instruction.Operands[0] = ops[0];
					currentInst.Instruction.Operands[1] = ops[1];
					this.tbInst_Op0.Text = Helper.HexString(
						currentInst.Instruction.Operands[0]
					);
					this.tbInst_Op1.Text = Helper.HexString(
						currentInst.Instruction.Operands[1]
					);
					break;
				case 1:
					currentInst.Instruction.Operands[2] = ops[0];
					currentInst.Instruction.Operands[3] = ops[1];
					this.tbInst_Op2.Text = Helper.HexString(
						currentInst.Instruction.Operands[2]
					);
					this.tbInst_Op3.Text = Helper.HexString(
						currentInst.Instruction.Operands[3]
					);
					break;
			}
			internalchg = false;
		}

		private void dec16_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (dec16_IsValid(sender))
				return;

			e.Cancel = true;

			short val = 0;
			switch (alDec16.IndexOf(sender))
			{
				case 0:
					val = OpsToShort(origInst.Operands[0], origInst.Operands[1]);
					break;
				case 1:
					val = OpsToShort(origInst.Operands[2], origInst.Operands[3]);
					break;
				case 2:
					val = 1;
					break; // Move
			}

			((TextBox)sender).Text = val.ToString();
			((TextBox)sender).SelectAll();
		}

		private void dec16_Validated(object sender, System.EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}
#endif

		private void hex8_TextChanged(object sender, EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!hex8_IsValid(sender))
			{
				return;
			}

			byte val = Convert.ToByte(((TextBox)sender).Text, 16);
			int i = alHex8.IndexOf(sender);

			internalchg = true;

			byte oldval = val;
			if (i < 8)
			{
				oldval = currentInst.Instruction.Operands[i];
				currentInst.Instruction.Operands[i] = val;
				ChangeLongname(oldval, val);
			}
			else if (i < 16)
			{
				oldval = currentInst.Instruction.Reserved1[i - 8];
				currentInst.Instruction.Reserved1[i - 8] = val;
				ChangeLongname(oldval, val);
			}
			else
			{
				switch (i)
				{
					case 16:
						oldval = currentInst.Instruction.NodeVersion;
						currentInst.Instruction.NodeVersion = val;
						ChangeLongname(oldval, val);
						break;
					case 17:
						wrapper.Header.HeaderFlag = val;
						break;
					case 18:
						wrapper.Header.Type = val;
						break;
					case 19:
						wrapper.Header.CacheFlags = val;
						break;
					case 20:
						oldval = wrapper.Header.ArgumentCount;
						wrapper.Header.ArgumentCount = val;
						ChangeLongname(oldval, val);
						break;
					case 21:
						wrapper.Header.LocalVarCount = val;
						break;
				}
			}

			internalchg = false;
		}

		private void hex8_Validating(
			object sender,
			CancelEventArgs e
		)
		{
			if (hex8_IsValid(sender))
			{
				return;
			}

			e.Cancel = true;

			byte val = 0;
			int i = alHex8.IndexOf(sender);

			if (i < 8)
			{
				val = origInst.Operands[i];
			}
			else if (i < 16)
			{
				val = origInst.Reserved1[i - 8];
			}
			else
			{
				switch (i)
				{
					case 16:
						val = origInst.NodeVersion;
						break;
					case 17:
						val = wrapper.Header.HeaderFlag;
						break;
					case 18:
						val = wrapper.Header.Type;
						break;
					case 19:
						val = wrapper.Header.CacheFlags;
						break;
					case 20:
						val = wrapper.Header.ArgumentCount;
						break;
					case 21:
						val = wrapper.Header.LocalVarCount;
						break;
				}
			} ((TextBox)sender).Text = ((i >= 16) ? "0x" : "") + Helper.HexString(val);
			((TextBox)sender).SelectAll();
		}

		private void hex8_Validated(object sender, EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				((alHex8.IndexOf(sender) >= 16) ? "0x" : "")
				+ Helper.HexString(Convert.ToByte(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex16_TextChanged(object sender, EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!hex16_IsValid(sender))
			{
				return;
			}

			ushort val = Convert.ToUInt16(((TextBox)sender).Text, 16);
			internalchg = true;
			switch (alHex16.IndexOf(sender))
			{
				case 0:
					OpcodeChanged(val);
					break;
			}
			internalchg = false;
		}

		private void hex16_Validating(
			object sender,
			CancelEventArgs e
		)
		{
			if (hex16_IsValid(sender))
			{
				return;
			}

			e.Cancel = true;

			ushort val = 0;
			switch (alHex16.IndexOf(sender))
			{
				case 0:
					val = origInst.OpCode;
					break;
				case 1:
					val = 1;
					break;
			}

			((TextBox)sender).Text = "0x" + Helper.HexString(val);
			((TextBox)sender).SelectAll();
		}

		private void hex16_Validated(object sender, EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x" + Helper.HexString(Convert.ToUInt16(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex32_TextChanged(object sender, EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!hex32_IsValid(sender))
			{
				return;
			}

			uint val = Convert.ToUInt32(((TextBox)sender).Text, 16);
			internalchg = true;
			switch (alHex32.IndexOf(sender))
			{
				case 0:
					wrapper.Header.TreeVersion = val;
					break;
			}
			internalchg = false;
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
			switch (alHex32.IndexOf(sender))
			{
				case 0:
					val = wrapper.Header.TreeVersion;
					break;
			}

			((TextBox)sender).Text = "0x" + Helper.HexString(val);
			((TextBox)sender).SelectAll();
		}

		private void hex32_Validated(object sender, EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x" + Helper.HexString(Convert.ToUInt32(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void btnSort_Clicked(object sender, EventArgs e)
		{
			pnflowcontainer.Sort();
		}

		private void btnMove_Clicked(object sender, EventArgs e)
		{
			int mv;
			try
			{
				mv = Convert.ToInt32(tbLines.Text, 16);
			}
			catch (Exception)
			{
				return;
			}
			try
			{
				gbMove.Enabled = false;
				if (sender == btnUp)
				{
					pnflowcontainer.MoveInst(mv * -1);
				}
				else
				{
					pnflowcontainer.MoveInst(mv);
				}
			}
			finally
			{
				gbMove.Enabled = true;
			}
		}

		private void btnAdd_Clicked(object sender, EventArgs e)
		{
			pnflowcontainer.Add(BhavUIAddType.Default);
		}

		private void btnDel_Clicked(object sender, EventArgs e)
		{
			pnflowcontainer.Delete(BhavUIDeleteType.Default);
		}

		private void cbSpecial_CheckStateChanged(object sender, EventArgs e)
		{
			gbSpecial.Visible = Settings.PJSE.ShowSpecialButtons = (
				(CheckBox)sender
			).Checked;
		}

		private void btnInsVia_Click(object sender, EventArgs e)
		{
			pnflowcontainer.Add(
				(sender == btnInsTrue)
					? BhavUIAddType.ViaTrue
					: BhavUIAddType.ViaFalse
			);
		}

		private void btnDelPescado_Click(object sender, EventArgs e)
		{
			pnflowcontainer.Delete(BhavUIDeleteType.Pescado);
		}

		private void btnLinkInge_Click(object sender, EventArgs e)
		{
			pnflowcontainer.Relink();
		}

		private void btnAppend_Click(object sender, EventArgs e)
		{
			pnflowcontainer.Append(
				new ResourceChooser().Execute(
					Data.MetaData.BHAV_FILE,
					wrapper.FileDescriptor.Group,
					bhavPanel.Parent,
					true,
					0x10
				)
			);
		}

		private void btnDelMerola_Click(object sender, EventArgs e)
		{
			pnflowcontainer.DeleteUnlinked();
		}

		private void btnCopyListing_Click(object sender, EventArgs e)
		{
			CopyListing();
		}

		private void btnPasteListing_Click(object sender, EventArgs e)
		{
			PasteListing();
		}

		private void btnTPRPMaker_Click(object sender, EventArgs e)
		{
			TPRPMaker();
		}

		private void btnInsUnlinked_Click(object sender, EventArgs e)
		{
			pnflowcontainer.Add(BhavUIAddType.Unlinked);
		}

		private void btnGUIDIndex_Click(object sender, EventArgs e)
		{
			cmenuGUIDIndex.Show((Control)sender, new Point(3, 3));
		}

		private void cmenuGUIDIndex_Opening(object sender, CancelEventArgs e)
		{
			createCurrentPackageToolStripMenuItem.Enabled =
				pjse.FileTable.GFT.CurrentPackage != null
				&& pjse.FileTable.GFT.CurrentPackage.FileName != null
				&& !pjse
					.FileTable.GFT.CurrentPackage.FileName.ToLower()
					.EndsWith("objects.package")
			;
		}

		private void createToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.UseWaitCursor = true;
			Application.DoEvents();
			GUIDIndex.TheGUIDIndex.Create(
				sender.Equals(createCurrentPackageToolStripMenuItem)
			);
			Application.UseWaitCursor = false;
			Application.DoEvents();

			DialogResult dr = pjseMsgBox.Show(
				RemoteControl.ApplicationForm,
				pjse.Localization.GetString("guidAskMessage"),
				pjse.Localization.GetString("guidAskTitle"),
				new Boolset("111"),
				new Boolset("111"),
				new string[]
				{
					pjse.Localization.GetString("guidAskDefault"),
					pjse.Localization.GetString("guidAskSpecify"),
					pjse.Localization.GetString("guidAskNoSave"),
				},
				new DialogResult[]
				{
					DialogResult.OK,
					DialogResult.Retry,
					DialogResult.Cancel,
				}
			);
			//DialogResult dr = MessageBox.Show(pjse.Localization.GetString("guidAskMessage"), pjse.Localization.GetString("guidAskTitle"),
			//    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (dr == DialogResult.OK)
			{
				defaultFileToolStripMenuItem_Click(
					defaultFileToolStripMenuItem1,
					null
				);
			}
			else if (dr == DialogResult.Retry)
			{
				fileToolStripMenuItem_Click(toFileToolStripMenuItem, null);
			}
		}

		private void defaultFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (sender.Equals(defaultFileToolStripMenuItem))
			{
				GUIDIndex.TheGUIDIndex.Load();
			}
			else
			{
				GUIDIndex.TheGUIDIndex.Save();
			}
		}

		private void fileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool load = sender.Equals(fromFileToolStripMenuItem);
			FileDialog fd = load ? new OpenFileDialog() : (FileDialog)new SaveFileDialog();

			fd.AddExtension = true;
			fd.CheckFileExists = load;
			fd.CheckPathExists = true;
			fd.DefaultExt = "txt";
			fd.DereferenceLinks = true;
			fd.FileName = GUIDIndex.DefaultGUIDFile;
			fd.Filter = pjse.Localization.GetString("guidFilter");
			fd.FilterIndex = 1;
			fd.RestoreDirectory = false;
			fd.ShowHelp = false;
			// fd.SupportMultiDottedExtensions = false; // Methods missing from Mono
			fd.Title = load
				? pjse.Localization.GetString("guidLoadIndex")
				: pjse.Localization.GetString("guidSaveIndex");
			fd.ValidateNames = true;
			DialogResult dr = fd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				if (load)
				{
					GUIDIndex.TheGUIDIndex.Load(fd.FileName);
				}
				else
				{
					GUIDIndex.TheGUIDIndex.Save(fd.FileName);
				}
			}
		}
	}
}
