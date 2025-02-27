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

using SimPe.Interfaces;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Scenegraph;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for BhavForm.
	/// </summary>
	public class BhavForm : System.Windows.Forms.Form, IPackedFileUI
	{
		#region Form variables

		private System.Windows.Forms.Label lbFilename;
		private System.Windows.Forms.Label lbFormat;
		private System.Windows.Forms.Label lbType;
		private System.Windows.Forms.Label lbLocalC;
		private System.Windows.Forms.TextBox tbFilename;
		private System.Windows.Forms.TextBox tbType;
		private System.Windows.Forms.TextBox tbArgC;
		private System.Windows.Forms.TextBox tbLocalC;
		private System.Windows.Forms.ComboBox tba1;
		private System.Windows.Forms.ComboBox tba2;
		private System.Windows.Forms.LinkLabel llopenbhav;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbInst_OpCode;
		private System.Windows.Forms.TextBox tbInst_Op7;
		private System.Windows.Forms.TextBox tbInst_Op6;
		private System.Windows.Forms.TextBox tbInst_Op5;
		private System.Windows.Forms.TextBox tbInst_Op4;
		private System.Windows.Forms.TextBox tbInst_Op3;
		private System.Windows.Forms.TextBox tbInst_Op2;
		private System.Windows.Forms.TextBox tbInst_Op1;
		private System.Windows.Forms.TextBox tbInst_Op0;
		private System.Windows.Forms.TextBox tbInst_Unk7;
		private System.Windows.Forms.TextBox tbInst_Unk6;
		private System.Windows.Forms.TextBox tbInst_Unk5;
		private System.Windows.Forms.TextBox tbInst_Unk4;
		private System.Windows.Forms.TextBox tbInst_Unk3;
		private System.Windows.Forms.TextBox tbInst_Unk2;
		private System.Windows.Forms.TextBox tbInst_Unk1;
		private System.Windows.Forms.TextBox tbInst_Unk0;
		private System.Windows.Forms.GroupBox gbInstruction;
		private System.Windows.Forms.Panel bhavPanel;
		private System.Windows.Forms.Button btnCommit;
		private System.Windows.Forms.Button btnOpCode;
		private System.Windows.Forms.Button btnOperandWiz;
		private System.Windows.Forms.Button btnSort;
		private System.Windows.Forms.Label lbUpDown;
		private System.Windows.Forms.TextBox tbLines;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnCancel;
		private SimPe.PackedFiles.UserInterface.BhavInstListControl pnflowcontainer;
		private System.Windows.Forms.GroupBox gbMove;
		private System.Windows.Forms.Label lbArgC;
		private System.Windows.Forms.GroupBox gbSpecial;
		private System.Windows.Forms.Button btnInsTrue;
		private System.Windows.Forms.Button btnInsFalse;
		private System.Windows.Forms.Button btnLinkInge;
		private System.Windows.Forms.Button btnDelPescado;
		private System.Windows.Forms.Button btnAppend;
		private System.Windows.Forms.ComboBox cbFormat;
		private System.Windows.Forms.Button btnDelMerola;
		private System.Windows.Forms.Label lbCacheFlags;
		private System.Windows.Forms.TextBox tbCacheFlags;
		private System.Windows.Forms.Label lbTreeVersion;
		private System.Windows.Forms.TextBox tbTreeVersion;
		private System.Windows.Forms.TextBox tbHeaderFlag;
		private System.Windows.Forms.Label lbHeaderFlag;
		private System.Windows.Forms.Button btnOperandRaw;
		private System.Windows.Forms.TextBox tbInst_NodeVersion;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.CheckBox cbSpecial;
		private System.Windows.Forms.TextBox tbInst_Longname;
		private System.Windows.Forms.Button btnCopyListing;
		private System.Windows.Forms.Button btnTPRPMaker;
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

			this.Tag = "Normal"; // Used by SetReadOnly
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

			this.gbSpecial.Visible = this.cbSpecial.Checked = pjse.Settings
				.PJSE
				.ShowSpecialButtons;

			pjse.FileTable.GFT.FiletableRefresh += new System.EventHandler(
				this.FiletableRefresh
			);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
			if (setHandler && wrapper != null)
			{
				wrapper.FileDescriptor.DescriptionChanged -= new EventHandler(
					FileDescriptor_DescriptionChanged
				);
				wrapper.WrapperChanged -= new System.EventHandler(this.WrapperChanged);
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
			IPackedFileDescriptor npfd = new SimPe.Packages.PackedFileDescriptor();
			npfd.Type = type;
			npfd.Group = group;
			npfd.SubType = subtype;
			npfd.Instance = instance;
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
					return (
						i.Group != pfd.Group
						|| i.Instance < 0x1000
						|| i.Instance >= 0x2000
					);
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
			SimPe.ExpansionItem exp,
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
			string s = this.Tag as string;
			if (s == null)
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

		private bool isPopup => (this.Tag == null || this.Tag as string == null)
					? false
					: ((string)(this.Tag)).StartsWith("Popup");
		private bool isNoOverride => (this.Tag == null || this.Tag as string == null)
					? false
					: ((string)(this.Tag)).Contains(";noOverride");
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
						+ SimPe.Helper.HexString(
							wrapper.FileDescriptor.Group
						) // Group Number
					,
					"0x"
						+ SimPe.Helper.HexString(
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
			if (this.isNoOverride)
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

				this.lbHidesOP.Visible =
					this.tbHidesOP.Visible =
					this.llHidesOP.Visible =
						true;
				llHidesOP.Links[0].Start -= llHidesOP.Text.Length;
				llHidesOP.Text = hidesFmt.Replace(
					"{0}",
					System.IO.Path.GetFileName(item.Package.SaveFileName)
				);
				llHidesOP.Links[0].Start += llHidesOP.Text.Length;
				this.tbHidesOP.Text = wrapper.Package.FileName;
				llHidesOP.Tag = item.IsMaxis
					? pjse.FileTable.Source.Maxis
					: pjse.FileTable.Source.Fixed;
			}
		}

		private void SetReadOnly(bool state)
		{
			//if (this.isPopup) state = true;

			this.tbInst_OpCode.ReadOnly = state;
			this.btnOpCode.Enabled = !state;
			this.tbInst_NodeVersion.ReadOnly = state || wrapper.Header.Format < 0x8005;
			this.tba1.Enabled = !state;
			this.tba2.Enabled = !state;

			/*this.tbInst_Op01_dec.ReadOnly = state;
			this.tbInst_Op23_dec.ReadOnly = state;*/

			this.tbInst_Op0.ReadOnly = state;
			this.tbInst_Op1.ReadOnly = state;
			this.tbInst_Op2.ReadOnly = state;
			this.tbInst_Op3.ReadOnly = state;
			this.tbInst_Op4.ReadOnly = state;
			this.tbInst_Op5.ReadOnly = state;
			this.tbInst_Op6.ReadOnly = state;
			this.tbInst_Op7.ReadOnly = state;

			this.btnOperandWiz.Enabled = !state;
			/*this.btnOperandRaw.Enabled = !state;*/
			this.btnZero.Enabled = !state;

			this.tbInst_Unk0.ReadOnly = state || wrapper.Header.Format < 0x8003;
			this.tbInst_Unk1.ReadOnly = state || wrapper.Header.Format < 0x8003;
			this.tbInst_Unk2.ReadOnly = state || wrapper.Header.Format < 0x8003;
			this.tbInst_Unk3.ReadOnly = state || wrapper.Header.Format < 0x8003;
			this.tbInst_Unk4.ReadOnly = state || wrapper.Header.Format < 0x8003;
			this.tbInst_Unk5.ReadOnly = state || wrapper.Header.Format < 0x8003;
			this.tbInst_Unk6.ReadOnly = state || wrapper.Header.Format < 0x8003;
			this.tbInst_Unk7.ReadOnly = state || wrapper.Header.Format < 0x8003;

			this.btnUp.Enabled = !state;
			this.btnDown.Enabled = !state;
			this.tbLines.ReadOnly = state;
			this.btnDelPescado.Enabled = this.btnDel.Enabled = !state;
			this.btnInsTrue.Enabled =
				this.btnInsFalse.Enabled =
				this.btnAdd.Enabled =
					!state;
		}

		private bool instIsBhav()
		{
			return wrapper.ResourceByInstance(
					SimPe.Data.MetaData.BHAV_FILE,
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
				changed = (
					(new BhavOperandWiz()).Execute(
						btnCommit.Visible ? inst : inst.Clone(),
						type
					) != null
				);
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

					this.btnCancel.Enabled = true;
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
				this.llopenbhav.Enabled = false;
				this.btnInsTrue.Enabled =
					this.btnInsFalse.Enabled =
					this.btnAdd.Enabled =
						true;

				this.tbInst_OpCode.Text = "";
				this.tbInst_NodeVersion.Text = "";
				this.tba1.SelectedIndex = 0;
				this.tba2.SelectedIndex = 0;
				this.tbInst_Op0.Text = "";
				this.tbInst_Op1.Text = "";
				this.tbInst_Op2.Text = "";
				this.tbInst_Op3.Text = "";
				this.tbInst_Op4.Text = "";
				this.tbInst_Op5.Text = "";
				this.tbInst_Op6.Text = "";
				this.tbInst_Op7.Text = "";
				this.tbInst_Unk0.Text = "";
				this.tbInst_Unk1.Text = "";
				this.tbInst_Unk2.Text = "";
				this.tbInst_Unk3.Text = "";
				this.tbInst_Unk4.Text = "";
				this.tbInst_Unk5.Text = "";
				this.tbInst_Unk6.Text = "";
				this.tbInst_Unk7.Text = "";
			}
			else
			{
				Instruction inst = currentInst.Instruction; // saves typing

				SetReadOnly(false);

				this.tbInst_OpCode.Text = "0x" + Helper.HexString(inst.OpCode);
				this.tbInst_NodeVersion.Text =
					"0x" + Helper.HexString(inst.NodeVersion);

				if (inst.Target1 >= 0xFFFC && inst.Target1 < 0xFFFF)
				{
					this.tba1.SelectedIndex = inst.Target1 - 0xFFFC;
				}
				else
				{
					this.tba1.SelectedIndex = -1;
					this.tba1.Text = "0x" + Helper.HexString(inst.Target1);
				}
				if (inst.Target2 >= 0xFFFC && inst.Target2 < 0xFFFF)
				{
					this.tba2.SelectedIndex = inst.Target2 - 0xFFFC;
				}
				else
				{
					this.tba2.SelectedIndex = -1;
					this.tba2.Text = "0x" + Helper.HexString(inst.Target2);
				}

				this.tbInst_Op0.Text = Helper.HexString(inst.Operands[0]);
				this.tbInst_Op1.Text = Helper.HexString(inst.Operands[1]);
				this.tbInst_Op2.Text = Helper.HexString(inst.Operands[2]);
				this.tbInst_Op3.Text = Helper.HexString(inst.Operands[3]);
				this.tbInst_Op4.Text = Helper.HexString(inst.Operands[4]);
				this.tbInst_Op5.Text = Helper.HexString(inst.Operands[5]);
				this.tbInst_Op6.Text = Helper.HexString(inst.Operands[6]);
				this.tbInst_Op7.Text = Helper.HexString(inst.Operands[7]);

				this.tbInst_Unk0.Text = Helper.HexString(inst.Reserved1[0]);
				this.tbInst_Unk1.Text = Helper.HexString(inst.Reserved1[1]);
				this.tbInst_Unk2.Text = Helper.HexString(inst.Reserved1[2]);
				this.tbInst_Unk3.Text = Helper.HexString(inst.Reserved1[3]);
				this.tbInst_Unk4.Text = Helper.HexString(inst.Reserved1[4]);
				this.tbInst_Unk5.Text = Helper.HexString(inst.Reserved1[5]);
				this.tbInst_Unk6.Text = Helper.HexString(inst.Reserved1[6]);
				this.tbInst_Unk7.Text = Helper.HexString(inst.Reserved1[7]);

				this.btnUp.Enabled = pnflowcontainer.SelectedIndex > 0;
				this.btnDown.Enabled =
					pnflowcontainer.SelectedIndex < wrapper.Count - 1;

				this.btnDelPescado.Enabled = this.btnDel.Enabled = wrapper.Count > 1;

				this.llopenbhav.Enabled = instIsBhav();
				this.btnOperandWiz.Enabled = currentInst.Wizard() != null;
			}
			setLongname();
			Application.UseWaitCursor = false;
			internalchg = false;
		}

		private void OpcodeChanged(ushort value)
		{
			currentInst.Instruction.OpCode = value;
			this.currentInst = currentInst.Instruction;
			this.llopenbhav.Enabled = instIsBhav();
			this.btnOperandWiz.Enabled = currentInst.Wizard() != null;
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
				this.tbInst_Longname.Text = "";
			}
			else
			{
				bool state = Application.UseWaitCursor;
				Application.UseWaitCursor = true;
				try
				{
					this.tbInst_Longname.Text = currentInst
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
					operands += SimPe.Helper.HexString(inst.Operands[j]);
				}

				for (int j = 0; j < 8; j++)
				{
					operands += SimPe.Helper.HexString(inst.Reserved1[j]);
				}

				listing += (
					"     "
					+ SimPe.Helper.HexString(i)
					+ " : "
					+ SimPe.Helper.HexString(inst.OpCode)
					+ " : "
					+ SimPe.Helper.HexString(inst.NodeVersion)
					+ " : "
					+ SimPe.Helper.HexString(inst.Target1)
					+ " : "
					+ SimPe.Helper.HexString(inst.Target2)
					+ " : "
					+ operands
					+ "\r\n"
					+ w.LongName
					+ "\r\n\r\n"
				);
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

					Instruction inst = new Instruction(wrapper);

					inst.OpCode = Convert.ToUInt16(args[1].Trim(), 16);
					inst.NodeVersion = Convert.ToByte(args[2].Trim(), 16);
					inst.Target1 = Convert.ToUInt16(args[3].Trim(), 16);
					inst.Target2 = Convert.ToUInt16(args[4].Trim(), 16);
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
							args[5].Trim().Substring(16 + j * 2, 2),
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

						SimPe.Interfaces.Files.IPackedFileDescriptor npfd = newPFD(
							tprp.FileDescriptor
						);
						TPRP ntprp = new TPRP();
						ntprp.FileDescriptor = npfd;
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
					tprp = new TPRP();
					tprp.FileDescriptor = newPFD(
						TPRP.TPRPtype,
						wrapper.FileDescriptor.Group,
						wrapper.FileDescriptor.SubType,
						wrapper.FileDescriptor.Instance
					);
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
			if (uval > 32767)
			{
				return (short)(uval - 65536);
			}
			else
			{
				return (short)uval;
			}
		}

		private byte[] ShortToOps(short val)
		{
			byte[] ops = new byte[2];
			ushort uval;
			if (val < 0)
			{
				uval = (ushort)(65536 + val);
			}
			else
			{
				uval = (ushort)val;
			}

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

		private void FiletableRefresh(object sender, System.EventArgs e)
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
			this.tbLines.Text = "0x0001";
			internalchg = false;

			this.WrapperChanged(wrapper, null);
			pjse_banner1.SiblingEnabled =
				wrapper.SiblingResource(TPRP.TPRPtype) != null;

			currentInst = null;
			origInst = null;
			UpdateInstPanel();
			this.pnflowcontainer.UpdateGUI(wrapper);
			// pnflowcontainer to install its handler before us.
			if (!setHandler)
			{
				wrapper.WrapperChanged += new System.EventHandler(this.WrapperChanged);
				wrapper.FileDescriptor.DescriptionChanged += new EventHandler(
					FileDescriptor_DescriptionChanged
				);
				setHandler = true;
			}

			if (this.isPopup)
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
				btnCopyBHAV.Visible = (currentPackage != wrapper.Package);
				btnImportBHAV.Visible =
					(currentPackage != wrapper.Package)
					&& (callerID != null && callerID.IndexOf("-FFFFFFFF-") == 17); //42484156-00000000-FFFFFFFF-00001003
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

				this.Text = formTitle;
				ttBhavForm.SetToolTip(tbFilename, null);
			}
			else
			{
				this.lbHidesOP.Visible =
					this.tbHidesOP.Visible =
					this.llHidesOP.Visible =
						false;
				this.llHidesOP.Tag = null;
				currentPackage = wrapper.Package;
				ttBhavForm.SetToolTip(
					tbFilename,
					expName
						+ ": 0x"
						+ SimPe.Helper.HexString(
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
				this.Text = formTitle;
			}
			else
			{
				ttBhavForm.SetToolTip(
					tbFilename,
					expName
						+ ": 0x"
						+ SimPe.Helper.HexString(
							(ushort)wrapper.FileDescriptor.Instance
						)
				);
			}
		}

		private void WrapperChanged(object sender, System.EventArgs e)
		{
			if (isPopup)
			{
				wrapper.Changed = false;
			}

			this.btnCommit.Enabled = wrapper.Changed;

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
				tbCacheFlags.Enabled = (wrapper.Header.Format > 0x8008);
				cmpBHAV.Wrapper = wrapper;
				cmpBHAV.WrapperName = wrapper.FileName;
				internalchg = false;
			}

			// Handler for current instruction
			if (currentInst != null && sender == currentInst.Instruction)
			{
				if (internalchg)
				{
					this.btnCancel.Enabled = true;
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(BhavForm));
			this.gbInstruction = new System.Windows.Forms.GroupBox();
			this.btnZero = new System.Windows.Forms.Button();
			this.tbInst_Longname = new System.Windows.Forms.TextBox();
			this.btnOperandRaw = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOperandWiz = new System.Windows.Forms.Button();
			this.llopenbhav = new System.Windows.Forms.LinkLabel();
			this.tba2 = new System.Windows.Forms.ComboBox();
			this.tba1 = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.tbInst_Unk7 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk6 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk5 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk4 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk3 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk2 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk1 = new System.Windows.Forms.TextBox();
			this.tbInst_Unk0 = new System.Windows.Forms.TextBox();
			this.tbInst_Op7 = new System.Windows.Forms.TextBox();
			this.tbInst_Op6 = new System.Windows.Forms.TextBox();
			this.tbInst_Op5 = new System.Windows.Forms.TextBox();
			this.tbInst_Op4 = new System.Windows.Forms.TextBox();
			this.tbInst_Op3 = new System.Windows.Forms.TextBox();
			this.tbInst_Op2 = new System.Windows.Forms.TextBox();
			this.tbInst_Op1 = new System.Windows.Forms.TextBox();
			this.tbInst_Op0 = new System.Windows.Forms.TextBox();
			this.tbInst_NodeVersion = new System.Windows.Forms.TextBox();
			this.tbInst_OpCode = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.btnOpCode = new System.Windows.Forms.Button();
			this.tbFilename = new System.Windows.Forms.TextBox();
			this.lbFilename = new System.Windows.Forms.Label();
			this.tbLocalC = new System.Windows.Forms.TextBox();
			this.tbArgC = new System.Windows.Forms.TextBox();
			this.tbType = new System.Windows.Forms.TextBox();
			this.lbTreeVersion = new System.Windows.Forms.Label();
			this.lbType = new System.Windows.Forms.Label();
			this.lbLocalC = new System.Windows.Forms.Label();
			this.lbArgC = new System.Windows.Forms.Label();
			this.lbFormat = new System.Windows.Forms.Label();
			this.bhavPanel = new System.Windows.Forms.Panel();
			this.pjse_banner1 = new pjse.pjse_banner();
			this.lbHidesOP = new System.Windows.Forms.Label();
			this.gbSpecial = new System.Windows.Forms.GroupBox();
			this.cmpBHAV = new pjse.CompareButton();
			this.btnPasteListing = new System.Windows.Forms.Button();
			this.btnAppend = new System.Windows.Forms.Button();
			this.btnInsTrue = new System.Windows.Forms.Button();
			this.btnInsFalse = new System.Windows.Forms.Button();
			this.btnDelPescado = new System.Windows.Forms.Button();
			this.btnLinkInge = new System.Windows.Forms.Button();
			this.btnGUIDIndex = new System.Windows.Forms.Button();
			this.btnInsUnlinked = new System.Windows.Forms.Button();
			this.btnDelMerola = new System.Windows.Forms.Button();
			this.btnCopyListing = new System.Windows.Forms.Button();
			this.btnTPRPMaker = new System.Windows.Forms.Button();
			this.llHidesOP = new System.Windows.Forms.LinkLabel();
			this.tbHidesOP = new System.Windows.Forms.TextBox();
			this.cbSpecial = new System.Windows.Forms.CheckBox();
			this.btnImportBHAV = new System.Windows.Forms.Button();
			this.btnCopyBHAV = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.tbHeaderFlag = new System.Windows.Forms.TextBox();
			this.lbHeaderFlag = new System.Windows.Forms.Label();
			this.tbCacheFlags = new System.Windows.Forms.TextBox();
			this.cbFormat = new System.Windows.Forms.ComboBox();
			this.pnflowcontainer =
				new SimPe.PackedFiles.UserInterface.BhavInstListControl();
			this.btnDel = new System.Windows.Forms.Button();
			this.gbMove = new System.Windows.Forms.GroupBox();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.lbUpDown = new System.Windows.Forms.Label();
			this.tbLines = new System.Windows.Forms.TextBox();
			this.btnSort = new System.Windows.Forms.Button();
			this.btnCommit = new System.Windows.Forms.Button();
			this.tbTreeVersion = new System.Windows.Forms.TextBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.lbCacheFlags = new System.Windows.Forms.Label();
			this.cmenuGUIDIndex = new System.Windows.Forms.ContextMenuStrip(
				this.components
			);
			this.createAllPackagesToolStripMenuItem =
				new System.Windows.Forms.ToolStripMenuItem();
			this.createCurrentPackageToolStripMenuItem =
				new System.Windows.Forms.ToolStripMenuItem();
			this.loadIndexToolStripMenuItem =
				new System.Windows.Forms.ToolStripMenuItem();
			this.defaultFileToolStripMenuItem =
				new System.Windows.Forms.ToolStripMenuItem();
			this.fromFileToolStripMenuItem =
				new System.Windows.Forms.ToolStripMenuItem();
			this.saveIndexToolStripMenuItem =
				new System.Windows.Forms.ToolStripMenuItem();
			this.defaultFileToolStripMenuItem1 =
				new System.Windows.Forms.ToolStripMenuItem();
			this.toFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ttBhavForm = new System.Windows.Forms.ToolTip(this.components);
			this.gbInstruction.SuspendLayout();
			this.bhavPanel.SuspendLayout();
			this.gbSpecial.SuspendLayout();
			this.gbMove.SuspendLayout();
			this.cmenuGUIDIndex.SuspendLayout();
			this.SuspendLayout();
			//
			// gbInstruction
			//
			resources.ApplyResources(this.gbInstruction, "gbInstruction");
			this.gbInstruction.Controls.Add(this.btnZero);
			this.gbInstruction.Controls.Add(this.tbInst_Longname);
			this.gbInstruction.Controls.Add(this.btnOperandRaw);
			this.gbInstruction.Controls.Add(this.btnCancel);
			this.gbInstruction.Controls.Add(this.btnOperandWiz);
			this.gbInstruction.Controls.Add(this.llopenbhav);
			this.gbInstruction.Controls.Add(this.tba2);
			this.gbInstruction.Controls.Add(this.tba1);
			this.gbInstruction.Controls.Add(this.label13);
			this.gbInstruction.Controls.Add(this.tbInst_Unk7);
			this.gbInstruction.Controls.Add(this.tbInst_Unk6);
			this.gbInstruction.Controls.Add(this.tbInst_Unk5);
			this.gbInstruction.Controls.Add(this.tbInst_Unk4);
			this.gbInstruction.Controls.Add(this.tbInst_Unk3);
			this.gbInstruction.Controls.Add(this.tbInst_Unk2);
			this.gbInstruction.Controls.Add(this.tbInst_Unk1);
			this.gbInstruction.Controls.Add(this.tbInst_Unk0);
			this.gbInstruction.Controls.Add(this.tbInst_Op7);
			this.gbInstruction.Controls.Add(this.tbInst_Op6);
			this.gbInstruction.Controls.Add(this.tbInst_Op5);
			this.gbInstruction.Controls.Add(this.tbInst_Op4);
			this.gbInstruction.Controls.Add(this.tbInst_Op3);
			this.gbInstruction.Controls.Add(this.tbInst_Op2);
			this.gbInstruction.Controls.Add(this.tbInst_Op1);
			this.gbInstruction.Controls.Add(this.tbInst_Op0);
			this.gbInstruction.Controls.Add(this.tbInst_NodeVersion);
			this.gbInstruction.Controls.Add(this.tbInst_OpCode);
			this.gbInstruction.Controls.Add(this.label10);
			this.gbInstruction.Controls.Add(this.label9);
			this.gbInstruction.Controls.Add(this.label12);
			this.gbInstruction.Controls.Add(this.label11);
			this.gbInstruction.Controls.Add(this.btnOpCode);
			this.gbInstruction.Name = "gbInstruction";
			this.gbInstruction.TabStop = false;
			//
			// btnZero
			//
			resources.ApplyResources(this.btnZero, "btnZero");
			this.btnZero.Name = "btnZero";
			this.ttBhavForm.SetToolTip(
				this.btnZero,
				resources.GetString("btnZero.ToolTip")
			);
			this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
			//
			// tbInst_Longname
			//
			resources.ApplyResources(this.tbInst_Longname, "tbInst_Longname");
			this.tbInst_Longname.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbInst_Longname.Name = "tbInst_Longname";
			this.tbInst_Longname.ReadOnly = true;
			this.ttBhavForm.SetToolTip(
				this.tbInst_Longname,
				resources.GetString("tbInst_Longname.ToolTip")
			);
			//
			// btnOperandRaw
			//
			resources.ApplyResources(this.btnOperandRaw, "btnOperandRaw");
			this.btnOperandRaw.Name = "btnOperandRaw";
			this.ttBhavForm.SetToolTip(
				this.btnOperandRaw,
				resources.GetString("btnOperandRaw.ToolTip")
			);
			this.btnOperandRaw.Click += new System.EventHandler(
				this.btnOperandRaw_Click
			);
			//
			// btnCancel
			//
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Clicked);
			//
			// btnOperandWiz
			//
			resources.ApplyResources(this.btnOperandWiz, "btnOperandWiz");
			this.btnOperandWiz.Name = "btnOperandWiz";
			this.ttBhavForm.SetToolTip(
				this.btnOperandWiz,
				resources.GetString("btnOperandWiz.ToolTip")
			);
			this.btnOperandWiz.Click += new System.EventHandler(
				this.btnOperandWiz_Clicked
			);
			//
			// llopenbhav
			//
			resources.ApplyResources(this.llopenbhav, "llopenbhav");
			this.llopenbhav.Name = "llopenbhav";
			this.llopenbhav.TabStop = true;
			this.llopenbhav.UseCompatibleTextRendering = true;
			this.llopenbhav.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.llopenbhav_LinkClicked
				);
			//
			// tba2
			//
			resources.ApplyResources(this.tba2, "tba2");
			this.tba2.Items.AddRange(
				new object[]
				{
					resources.GetString("tba2.Items"),
					resources.GetString("tba2.Items1"),
					resources.GetString("tba2.Items2"),
				}
			);
			this.tba2.Name = "tba2";
			this.tba2.QueryContinueDrag +=
				new System.Windows.Forms.QueryContinueDragEventHandler(
					this.ItemQueryContinueDragTarget
				);
			this.tba2.Validating += new System.ComponentModel.CancelEventHandler(
				this.cbHex16_Validating
			);
			this.tba2.DragOver += new System.Windows.Forms.DragEventHandler(
				this.ItemDragEnter
			);
			this.tba2.SelectedIndexChanged += new System.EventHandler(
				this.cbHex16_SelectedIndexChanged
			);
			this.tba2.Enter += new System.EventHandler(this.cbHex16_Enter);
			this.tba2.DragDrop += new System.Windows.Forms.DragEventHandler(
				this.ItemDrop
			);
			this.tba2.DragEnter += new System.Windows.Forms.DragEventHandler(
				this.ItemDragEnter
			);
			this.tba2.Validated += new System.EventHandler(this.cbHex16_Validated);
			this.tba2.TextChanged += new System.EventHandler(this.cbHex16_TextChanged);
			//
			// tba1
			//
			resources.ApplyResources(this.tba1, "tba1");
			this.tba1.Items.AddRange(
				new object[]
				{
					resources.GetString("tba1.Items"),
					resources.GetString("tba1.Items1"),
					resources.GetString("tba1.Items2"),
				}
			);
			this.tba1.Name = "tba1";
			this.tba1.QueryContinueDrag +=
				new System.Windows.Forms.QueryContinueDragEventHandler(
					this.ItemQueryContinueDragTarget
				);
			this.tba1.Validating += new System.ComponentModel.CancelEventHandler(
				this.cbHex16_Validating
			);
			this.tba1.DragOver += new System.Windows.Forms.DragEventHandler(
				this.ItemDragEnter
			);
			this.tba1.SelectedIndexChanged += new System.EventHandler(
				this.cbHex16_SelectedIndexChanged
			);
			this.tba1.Enter += new System.EventHandler(this.cbHex16_Enter);
			this.tba1.DragDrop += new System.Windows.Forms.DragEventHandler(
				this.ItemDrop
			);
			this.tba1.DragEnter += new System.Windows.Forms.DragEventHandler(
				this.ItemDragEnter
			);
			this.tba1.Validated += new System.EventHandler(this.cbHex16_Validated);
			this.tba1.TextChanged += new System.EventHandler(this.cbHex16_TextChanged);
			//
			// label13
			//
			resources.ApplyResources(this.label13, "label13");
			this.label13.Name = "label13";
			//
			// tbInst_Unk7
			//
			resources.ApplyResources(this.tbInst_Unk7, "tbInst_Unk7");
			this.tbInst_Unk7.Name = "tbInst_Unk7";
			this.tbInst_Unk7.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Unk7.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk7.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk6
			//
			resources.ApplyResources(this.tbInst_Unk6, "tbInst_Unk6");
			this.tbInst_Unk6.Name = "tbInst_Unk6";
			this.tbInst_Unk6.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Unk6.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk6.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk5
			//
			resources.ApplyResources(this.tbInst_Unk5, "tbInst_Unk5");
			this.tbInst_Unk5.Name = "tbInst_Unk5";
			this.tbInst_Unk5.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Unk5.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk5.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk4
			//
			resources.ApplyResources(this.tbInst_Unk4, "tbInst_Unk4");
			this.tbInst_Unk4.Name = "tbInst_Unk4";
			this.tbInst_Unk4.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Unk4.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk4.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk3
			//
			resources.ApplyResources(this.tbInst_Unk3, "tbInst_Unk3");
			this.tbInst_Unk3.Name = "tbInst_Unk3";
			this.tbInst_Unk3.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Unk3.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk3.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk2
			//
			resources.ApplyResources(this.tbInst_Unk2, "tbInst_Unk2");
			this.tbInst_Unk2.Name = "tbInst_Unk2";
			this.tbInst_Unk2.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Unk2.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk2.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk1
			//
			resources.ApplyResources(this.tbInst_Unk1, "tbInst_Unk1");
			this.tbInst_Unk1.Name = "tbInst_Unk1";
			this.tbInst_Unk1.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Unk1.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk1.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Unk0
			//
			resources.ApplyResources(this.tbInst_Unk0, "tbInst_Unk0");
			this.tbInst_Unk0.Name = "tbInst_Unk0";
			this.tbInst_Unk0.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Unk0.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Unk0.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op7
			//
			resources.ApplyResources(this.tbInst_Op7, "tbInst_Op7");
			this.tbInst_Op7.Name = "tbInst_Op7";
			this.tbInst_Op7.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Op7.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op7.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op6
			//
			resources.ApplyResources(this.tbInst_Op6, "tbInst_Op6");
			this.tbInst_Op6.Name = "tbInst_Op6";
			this.tbInst_Op6.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Op6.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op6.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op5
			//
			resources.ApplyResources(this.tbInst_Op5, "tbInst_Op5");
			this.tbInst_Op5.Name = "tbInst_Op5";
			this.tbInst_Op5.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Op5.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op5.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op4
			//
			resources.ApplyResources(this.tbInst_Op4, "tbInst_Op4");
			this.tbInst_Op4.Name = "tbInst_Op4";
			this.tbInst_Op4.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Op4.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op4.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op3
			//
			resources.ApplyResources(this.tbInst_Op3, "tbInst_Op3");
			this.tbInst_Op3.Name = "tbInst_Op3";
			this.tbInst_Op3.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Op3.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op3.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op2
			//
			resources.ApplyResources(this.tbInst_Op2, "tbInst_Op2");
			this.tbInst_Op2.Name = "tbInst_Op2";
			this.tbInst_Op2.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Op2.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op2.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op1
			//
			resources.ApplyResources(this.tbInst_Op1, "tbInst_Op1");
			this.tbInst_Op1.Name = "tbInst_Op1";
			this.tbInst_Op1.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Op1.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op1.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_Op0
			//
			resources.ApplyResources(this.tbInst_Op0, "tbInst_Op0");
			this.tbInst_Op0.Name = "tbInst_Op0";
			this.tbInst_Op0.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_Op0.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbInst_Op0.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbInst_NodeVersion
			//
			resources.ApplyResources(this.tbInst_NodeVersion, "tbInst_NodeVersion");
			this.tbInst_NodeVersion.Name = "tbInst_NodeVersion";
			this.tbInst_NodeVersion.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbInst_NodeVersion.Validated += new System.EventHandler(
				this.hex8_Validated
			);
			this.tbInst_NodeVersion.Validating +=
				new System.ComponentModel.CancelEventHandler(this.hex8_Validating);
			//
			// tbInst_OpCode
			//
			resources.ApplyResources(this.tbInst_OpCode, "tbInst_OpCode");
			this.tbInst_OpCode.Name = "tbInst_OpCode";
			this.tbInst_OpCode.TextChanged += new System.EventHandler(
				this.hex16_TextChanged
			);
			this.tbInst_OpCode.Validated += new System.EventHandler(
				this.hex16_Validated
			);
			this.tbInst_OpCode.Validating +=
				new System.ComponentModel.CancelEventHandler(this.hex16_Validating);
			//
			// label10
			//
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			//
			// label9
			//
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			//
			// label12
			//
			resources.ApplyResources(this.label12, "label12");
			this.label12.Name = "label12";
			//
			// label11
			//
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			//
			// btnOpCode
			//
			resources.ApplyResources(this.btnOpCode, "btnOpCode");
			this.btnOpCode.Name = "btnOpCode";
			this.btnOpCode.Click += new System.EventHandler(this.btnOpCode_Clicked);
			//
			// tbFilename
			//
			resources.ApplyResources(this.tbFilename, "tbFilename");
			this.tbFilename.Name = "tbFilename";
			this.tbFilename.TextChanged += new System.EventHandler(
				this.tbFilename_TextChanged
			);
			this.tbFilename.Validated += new System.EventHandler(
				this.tbFilename_Validated
			);
			//
			// lbFilename
			//
			resources.ApplyResources(this.lbFilename, "lbFilename");
			this.lbFilename.Name = "lbFilename";
			//
			// tbLocalC
			//
			resources.ApplyResources(this.tbLocalC, "tbLocalC");
			this.tbLocalC.Name = "tbLocalC";
			this.ttBhavForm.SetToolTip(
				this.tbLocalC,
				resources.GetString("tbLocalC.ToolTip")
			);
			this.tbLocalC.TextChanged += new System.EventHandler(this.hex8_TextChanged);
			this.tbLocalC.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbLocalC.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbArgC
			//
			resources.ApplyResources(this.tbArgC, "tbArgC");
			this.tbArgC.Name = "tbArgC";
			this.ttBhavForm.SetToolTip(
				this.tbArgC,
				resources.GetString("tbArgC.ToolTip")
			);
			this.tbArgC.TextChanged += new System.EventHandler(this.hex8_TextChanged);
			this.tbArgC.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbArgC.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// tbType
			//
			resources.ApplyResources(this.tbType, "tbType");
			this.tbType.Name = "tbType";
			this.tbType.TextChanged += new System.EventHandler(this.hex8_TextChanged);
			this.tbType.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbType.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			//
			// lbTreeVersion
			//
			resources.ApplyResources(this.lbTreeVersion, "lbTreeVersion");
			this.lbTreeVersion.Name = "lbTreeVersion";
			//
			// lbType
			//
			resources.ApplyResources(this.lbType, "lbType");
			this.lbType.Name = "lbType";
			//
			// lbLocalC
			//
			resources.ApplyResources(this.lbLocalC, "lbLocalC");
			this.lbLocalC.Name = "lbLocalC";
			//
			// lbArgC
			//
			resources.ApplyResources(this.lbArgC, "lbArgC");
			this.lbArgC.Name = "lbArgC";
			//
			// lbFormat
			//
			resources.ApplyResources(this.lbFormat, "lbFormat");
			this.lbFormat.Name = "lbFormat";
			//
			// bhavPanel
			//
			resources.ApplyResources(this.bhavPanel, "bhavPanel");
			this.bhavPanel.BackColor = System.Drawing.SystemColors.Control;
			this.bhavPanel.Controls.Add(this.pjse_banner1);
			this.bhavPanel.Controls.Add(this.lbHidesOP);
			this.bhavPanel.Controls.Add(this.gbSpecial);
			this.bhavPanel.Controls.Add(this.llHidesOP);
			this.bhavPanel.Controls.Add(this.tbHidesOP);
			this.bhavPanel.Controls.Add(this.cbSpecial);
			this.bhavPanel.Controls.Add(this.btnImportBHAV);
			this.bhavPanel.Controls.Add(this.btnCopyBHAV);
			this.bhavPanel.Controls.Add(this.btnClose);
			this.bhavPanel.Controls.Add(this.tbHeaderFlag);
			this.bhavPanel.Controls.Add(this.lbHeaderFlag);
			this.bhavPanel.Controls.Add(this.tbCacheFlags);
			this.bhavPanel.Controls.Add(this.cbFormat);
			this.bhavPanel.Controls.Add(this.pnflowcontainer);
			this.bhavPanel.Controls.Add(this.btnDel);
			this.bhavPanel.Controls.Add(this.gbMove);
			this.bhavPanel.Controls.Add(this.btnSort);
			this.bhavPanel.Controls.Add(this.btnCommit);
			this.bhavPanel.Controls.Add(this.lbFilename);
			this.bhavPanel.Controls.Add(this.tbFilename);
			this.bhavPanel.Controls.Add(this.gbInstruction);
			this.bhavPanel.Controls.Add(this.tbLocalC);
			this.bhavPanel.Controls.Add(this.tbTreeVersion);
			this.bhavPanel.Controls.Add(this.tbArgC);
			this.bhavPanel.Controls.Add(this.tbType);
			this.bhavPanel.Controls.Add(this.lbTreeVersion);
			this.bhavPanel.Controls.Add(this.lbType);
			this.bhavPanel.Controls.Add(this.lbLocalC);
			this.bhavPanel.Controls.Add(this.lbArgC);
			this.bhavPanel.Controls.Add(this.lbFormat);
			this.bhavPanel.Controls.Add(this.btnAdd);
			this.bhavPanel.Controls.Add(this.lbCacheFlags);
			this.bhavPanel.Name = "bhavPanel";
			//
			// pjse_banner1
			//
			resources.ApplyResources(this.pjse_banner1, "pjse_banner1");
			this.pjse_banner1.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pjse_banner1.ExtractVisible = true;
			this.pjse_banner1.FloatVisible = true;
			this.pjse_banner1.Name = "pjse_banner1";
			this.pjse_banner1.SiblingVisible = true;
			this.pjse_banner1.ViewVisible = true;
			this.pjse_banner1.ExtractClick += new System.EventHandler(
				this.pjse_banner1_ExtractClick
			);
			this.pjse_banner1.SiblingClick += new System.EventHandler(
				this.pjse_banner1_SiblingClick
			);
			this.pjse_banner1.ViewClick += new System.EventHandler(
				this.pjse_banner1_ViewClick
			);
			this.pjse_banner1.FloatClick += new System.EventHandler(
				this.btnFloat_Click
			);
			//
			// lbHidesOP
			//
			resources.ApplyResources(this.lbHidesOP, "lbHidesOP");
			this.lbHidesOP.Name = "lbHidesOP";
			//
			// gbSpecial
			//
			resources.ApplyResources(this.gbSpecial, "gbSpecial");
			this.gbSpecial.Controls.Add(this.cmpBHAV);
			this.gbSpecial.Controls.Add(this.btnPasteListing);
			this.gbSpecial.Controls.Add(this.btnAppend);
			this.gbSpecial.Controls.Add(this.btnInsTrue);
			this.gbSpecial.Controls.Add(this.btnInsFalse);
			this.gbSpecial.Controls.Add(this.btnDelPescado);
			this.gbSpecial.Controls.Add(this.btnLinkInge);
			this.gbSpecial.Controls.Add(this.btnGUIDIndex);
			this.gbSpecial.Controls.Add(this.btnInsUnlinked);
			this.gbSpecial.Controls.Add(this.btnDelMerola);
			this.gbSpecial.Controls.Add(this.btnCopyListing);
			this.gbSpecial.Controls.Add(this.btnTPRPMaker);
			this.gbSpecial.Name = "gbSpecial";
			this.gbSpecial.TabStop = false;
			//
			// cmpBHAV
			//
			resources.ApplyResources(this.cmpBHAV, "cmpBHAV");
			this.cmpBHAV.Name = "cmpBHAV";
			this.cmpBHAV.UseVisualStyleBackColor = true;
			this.cmpBHAV.Wrapper = null;
			this.cmpBHAV.WrapperName = null;
			this.cmpBHAV.CompareWith += new pjse.CompareButton.CompareWithEventHandler(
				this.cmpBHAV_CompareWith
			);
			//
			// btnPasteListing
			//
			resources.ApplyResources(this.btnPasteListing, "btnPasteListing");
			this.btnPasteListing.Name = "btnPasteListing";
			this.btnPasteListing.Click += new System.EventHandler(
				this.btnPasteListing_Click
			);
			//
			// btnAppend
			//
			resources.ApplyResources(this.btnAppend, "btnAppend");
			this.btnAppend.Name = "btnAppend";
			this.btnAppend.Click += new System.EventHandler(this.btnAppend_Click);
			//
			// btnInsTrue
			//
			resources.ApplyResources(this.btnInsTrue, "btnInsTrue");
			this.btnInsTrue.Name = "btnInsTrue";
			this.btnInsTrue.Click += new System.EventHandler(this.btnInsVia_Click);
			//
			// btnInsFalse
			//
			resources.ApplyResources(this.btnInsFalse, "btnInsFalse");
			this.btnInsFalse.Name = "btnInsFalse";
			this.btnInsFalse.Click += new System.EventHandler(this.btnInsVia_Click);
			//
			// btnDelPescado
			//
			resources.ApplyResources(this.btnDelPescado, "btnDelPescado");
			this.btnDelPescado.Name = "btnDelPescado";
			this.btnDelPescado.Click += new System.EventHandler(
				this.btnDelPescado_Click
			);
			//
			// btnLinkInge
			//
			resources.ApplyResources(this.btnLinkInge, "btnLinkInge");
			this.btnLinkInge.Name = "btnLinkInge";
			this.btnLinkInge.Click += new System.EventHandler(this.btnLinkInge_Click);
			//
			// btnGUIDIndex
			//
			resources.ApplyResources(this.btnGUIDIndex, "btnGUIDIndex");
			this.btnGUIDIndex.Name = "btnGUIDIndex";
			this.btnGUIDIndex.Click += new System.EventHandler(this.btnGUIDIndex_Click);
			//
			// btnInsUnlinked
			//
			resources.ApplyResources(this.btnInsUnlinked, "btnInsUnlinked");
			this.btnInsUnlinked.Name = "btnInsUnlinked";
			this.btnInsUnlinked.Click += new System.EventHandler(
				this.btnInsUnlinked_Click
			);
			//
			// btnDelMerola
			//
			resources.ApplyResources(this.btnDelMerola, "btnDelMerola");
			this.btnDelMerola.Name = "btnDelMerola";
			this.btnDelMerola.Click += new System.EventHandler(this.btnDelMerola_Click);
			//
			// btnCopyListing
			//
			resources.ApplyResources(this.btnCopyListing, "btnCopyListing");
			this.btnCopyListing.Name = "btnCopyListing";
			this.btnCopyListing.Click += new System.EventHandler(
				this.btnCopyListing_Click
			);
			//
			// btnTPRPMaker
			//
			resources.ApplyResources(this.btnTPRPMaker, "btnTPRPMaker");
			this.btnTPRPMaker.Name = "btnTPRPMaker";
			this.btnTPRPMaker.Click += new System.EventHandler(this.btnTPRPMaker_Click);
			//
			// llHidesOP
			//
			resources.ApplyResources(this.llHidesOP, "llHidesOP");
			this.llHidesOP.Name = "llHidesOP";
			this.llHidesOP.TabStop = true;
			this.llHidesOP.UseCompatibleTextRendering = true;
			this.llHidesOP.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.llHidesOP_LinkClicked
				);
			//
			// tbHidesOP
			//
			resources.ApplyResources(this.tbHidesOP, "tbHidesOP");
			this.tbHidesOP.BackColor = System.Drawing.SystemColors.Control;
			this.tbHidesOP.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbHidesOP.Name = "tbHidesOP";
			this.tbHidesOP.ReadOnly = true;
			//
			// cbSpecial
			//
			resources.ApplyResources(this.cbSpecial, "cbSpecial");
			this.cbSpecial.Name = "cbSpecial";
			this.cbSpecial.CheckStateChanged += new System.EventHandler(
				this.cbSpecial_CheckStateChanged
			);
			//
			// btnImportBHAV
			//
			resources.ApplyResources(this.btnImportBHAV, "btnImportBHAV");
			this.btnImportBHAV.Name = "btnImportBHAV";
			this.btnImportBHAV.Click += new System.EventHandler(
				this.btnImportBHAV_Click
			);
			//
			// btnCopyBHAV
			//
			resources.ApplyResources(this.btnCopyBHAV, "btnCopyBHAV");
			this.btnCopyBHAV.Name = "btnCopyBHAV";
			this.btnCopyBHAV.Click += new System.EventHandler(this.btnCopyBHAV_Click);
			//
			// btnClose
			//
			resources.ApplyResources(this.btnClose, "btnClose");
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Name = "btnClose";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			//
			// tbHeaderFlag
			//
			resources.ApplyResources(this.tbHeaderFlag, "tbHeaderFlag");
			this.tbHeaderFlag.Name = "tbHeaderFlag";
			this.tbHeaderFlag.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbHeaderFlag.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbHeaderFlag.Validating +=
				new System.ComponentModel.CancelEventHandler(this.hex8_Validating);
			//
			// lbHeaderFlag
			//
			resources.ApplyResources(this.lbHeaderFlag, "lbHeaderFlag");
			this.lbHeaderFlag.Name = "lbHeaderFlag";
			//
			// tbCacheFlags
			//
			resources.ApplyResources(this.tbCacheFlags, "tbCacheFlags");
			this.tbCacheFlags.Name = "tbCacheFlags";
			this.tbCacheFlags.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			this.tbCacheFlags.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbCacheFlags.Validating +=
				new System.ComponentModel.CancelEventHandler(this.hex8_Validating);
			//
			// cbFormat
			//
			resources.ApplyResources(this.cbFormat, "cbFormat");
			this.cbFormat.Items.AddRange(
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
			this.cbFormat.Name = "cbFormat";
			this.cbFormat.Validating += new System.ComponentModel.CancelEventHandler(
				this.cbHex16_Validating
			);
			this.cbFormat.SelectedIndexChanged += new System.EventHandler(
				this.cbHex16_SelectedIndexChanged
			);
			this.cbFormat.Enter += new System.EventHandler(this.cbHex16_Enter);
			this.cbFormat.Validated += new System.EventHandler(this.cbHex16_Validated);
			this.cbFormat.TextChanged += new System.EventHandler(
				this.cbHex16_TextChanged
			);
			//
			// pnflowcontainer
			//
			resources.ApplyResources(this.pnflowcontainer, "pnflowcontainer");
			this.pnflowcontainer.Name = "pnflowcontainer";
			this.pnflowcontainer.SelectedIndex = -1;
			this.pnflowcontainer.SelectedInstChanged += new System.EventHandler(
				this.pnflowcontainer_SelectedInstChanged
			);
			//
			// btnDel
			//
			resources.ApplyResources(this.btnDel, "btnDel");
			this.btnDel.Name = "btnDel";
			this.btnDel.Click += new System.EventHandler(this.btnDel_Clicked);
			//
			// gbMove
			//
			resources.ApplyResources(this.gbMove, "gbMove");
			this.gbMove.Controls.Add(this.btnUp);
			this.gbMove.Controls.Add(this.btnDown);
			this.gbMove.Controls.Add(this.lbUpDown);
			this.gbMove.Controls.Add(this.tbLines);
			this.gbMove.Name = "gbMove";
			this.gbMove.TabStop = false;
			//
			// btnUp
			//
			resources.ApplyResources(this.btnUp, "btnUp");
			this.btnUp.Name = "btnUp";
			this.btnUp.Click += new System.EventHandler(this.btnMove_Clicked);
			//
			// btnDown
			//
			resources.ApplyResources(this.btnDown, "btnDown");
			this.btnDown.Name = "btnDown";
			this.btnDown.Click += new System.EventHandler(this.btnMove_Clicked);
			//
			// lbUpDown
			//
			resources.ApplyResources(this.lbUpDown, "lbUpDown");
			this.lbUpDown.Name = "lbUpDown";
			//
			// tbLines
			//
			resources.ApplyResources(this.tbLines, "tbLines");
			this.tbLines.Name = "tbLines";
			this.tbLines.TextChanged += new System.EventHandler(this.hex16_TextChanged);
			this.tbLines.Validated += new System.EventHandler(this.hex16_Validated);
			this.tbLines.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			//
			// btnSort
			//
			resources.ApplyResources(this.btnSort, "btnSort");
			this.btnSort.Name = "btnSort";
			this.btnSort.Click += new System.EventHandler(this.btnSort_Clicked);
			//
			// btnCommit
			//
			resources.ApplyResources(this.btnCommit, "btnCommit");
			this.btnCommit.Name = "btnCommit";
			this.btnCommit.Click += new System.EventHandler(this.btnCommit_Clicked);
			//
			// tbTreeVersion
			//
			resources.ApplyResources(this.tbTreeVersion, "tbTreeVersion");
			this.tbTreeVersion.Name = "tbTreeVersion";
			this.tbTreeVersion.TextChanged += new System.EventHandler(
				this.hex32_TextChanged
			);
			this.tbTreeVersion.Validated += new System.EventHandler(
				this.hex32_Validated
			);
			this.tbTreeVersion.Validating +=
				new System.ComponentModel.CancelEventHandler(this.hex32_Validating);
			//
			// btnAdd
			//
			resources.ApplyResources(this.btnAdd, "btnAdd");
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Clicked);
			//
			// lbCacheFlags
			//
			resources.ApplyResources(this.lbCacheFlags, "lbCacheFlags");
			this.lbCacheFlags.Name = "lbCacheFlags";
			//
			// cmenuGUIDIndex
			//
			this.cmenuGUIDIndex.Items.AddRange(
				new System.Windows.Forms.ToolStripItem[]
				{
					this.createAllPackagesToolStripMenuItem,
					this.createCurrentPackageToolStripMenuItem,
					this.loadIndexToolStripMenuItem,
					this.saveIndexToolStripMenuItem,
				}
			);
			this.cmenuGUIDIndex.Name = "cmenuGUIDIndex";
			resources.ApplyResources(this.cmenuGUIDIndex, "cmenuGUIDIndex");
			this.cmenuGUIDIndex.Opening += new System.ComponentModel.CancelEventHandler(
				this.cmenuGUIDIndex_Opening
			);
			//
			// createAllPackagesToolStripMenuItem
			//
			this.createAllPackagesToolStripMenuItem.Name =
				"createAllPackagesToolStripMenuItem";
			resources.ApplyResources(
				this.createAllPackagesToolStripMenuItem,
				"createAllPackagesToolStripMenuItem"
			);
			this.createAllPackagesToolStripMenuItem.Click += new System.EventHandler(
				this.createToolStripMenuItem_Click
			);
			//
			// createCurrentPackageToolStripMenuItem
			//
			this.createCurrentPackageToolStripMenuItem.Name =
				"createCurrentPackageToolStripMenuItem";
			resources.ApplyResources(
				this.createCurrentPackageToolStripMenuItem,
				"createCurrentPackageToolStripMenuItem"
			);
			this.createCurrentPackageToolStripMenuItem.Click += new System.EventHandler(
				this.createToolStripMenuItem_Click
			);
			//
			// loadIndexToolStripMenuItem
			//
			this.loadIndexToolStripMenuItem.DropDownItems.AddRange(
				new System.Windows.Forms.ToolStripItem[]
				{
					this.defaultFileToolStripMenuItem,
					this.fromFileToolStripMenuItem,
				}
			);
			this.loadIndexToolStripMenuItem.Name = "loadIndexToolStripMenuItem";
			resources.ApplyResources(
				this.loadIndexToolStripMenuItem,
				"loadIndexToolStripMenuItem"
			);
			//
			// defaultFileToolStripMenuItem
			//
			this.defaultFileToolStripMenuItem.Name = "defaultFileToolStripMenuItem";
			resources.ApplyResources(
				this.defaultFileToolStripMenuItem,
				"defaultFileToolStripMenuItem"
			);
			this.defaultFileToolStripMenuItem.Click += new System.EventHandler(
				this.defaultFileToolStripMenuItem_Click
			);
			//
			// fromFileToolStripMenuItem
			//
			this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
			resources.ApplyResources(
				this.fromFileToolStripMenuItem,
				"fromFileToolStripMenuItem"
			);
			this.fromFileToolStripMenuItem.Click += new System.EventHandler(
				this.fileToolStripMenuItem_Click
			);
			//
			// saveIndexToolStripMenuItem
			//
			this.saveIndexToolStripMenuItem.DropDownItems.AddRange(
				new System.Windows.Forms.ToolStripItem[]
				{
					this.defaultFileToolStripMenuItem1,
					this.toFileToolStripMenuItem,
				}
			);
			this.saveIndexToolStripMenuItem.Name = "saveIndexToolStripMenuItem";
			resources.ApplyResources(
				this.saveIndexToolStripMenuItem,
				"saveIndexToolStripMenuItem"
			);
			//
			// defaultFileToolStripMenuItem1
			//
			this.defaultFileToolStripMenuItem1.Name = "defaultFileToolStripMenuItem1";
			resources.ApplyResources(
				this.defaultFileToolStripMenuItem1,
				"defaultFileToolStripMenuItem1"
			);
			this.defaultFileToolStripMenuItem1.Click += new System.EventHandler(
				this.defaultFileToolStripMenuItem_Click
			);
			//
			// toFileToolStripMenuItem
			//
			this.toFileToolStripMenuItem.Name = "toFileToolStripMenuItem";
			resources.ApplyResources(
				this.toFileToolStripMenuItem,
				"toFileToolStripMenuItem"
			);
			this.toFileToolStripMenuItem.Click += new System.EventHandler(
				this.fileToolStripMenuItem_Click
			);
			//
			// ttBhavForm
			//
			this.ttBhavForm.ShowAlways = true;
			//
			// BhavForm
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.CancelButton = this.btnClose;
			this.Controls.Add(this.bhavPanel);
			this.FormBorderStyle = System
				.Windows
				.Forms
				.FormBorderStyle
				.SizableToolWindow;
			this.Name = "BhavForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.gbInstruction.ResumeLayout(false);
			this.gbInstruction.PerformLayout();
			this.bhavPanel.ResumeLayout(false);
			this.bhavPanel.PerformLayout();
			this.gbSpecial.ResumeLayout(false);
			this.gbMove.ResumeLayout(false);
			this.gbMove.PerformLayout();
			this.cmenuGUIDIndex.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		#endregion

		private void pnflowcontainer_SelectedInstChanged(
			object sender,
			System.EventArgs e
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
			this.btnCancel.Enabled = false;
		}

		private void ItemQueryContinueDragTarget(
			object sender,
			QueryContinueDragEventArgs e
		)
		{
			if (e.KeyState == 0)
			{
				e.Action = DragAction.Drop;
			}
			else
			{
				e.Action = DragAction.Continue;
			}
		}

		private void ItemDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(int)))
			{
				e.Effect = DragDropEffects.Link;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void ItemDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			int sel = 0;
			sel = (int)e.Data.GetData(sel.GetType());
			ComboBox cb = ((ComboBox)sender);
			cb.SelectedIndex = -1;
			cb.Text = "0x" + Helper.HexString((ushort)sel);
		}

		private void btnCommit_Clicked(object sender, System.EventArgs e)
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

		private void btnCancel_Clicked(object sender, System.EventArgs e)
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
			SimPe.RemoteControl.OpenPackedFile(tprp.FileDescriptor, tprp.Package);
		}

		private void btnFloat_Click(object sender, EventArgs e)
		{
			Control old = this.bhavPanel.Parent;
			string oldFloatText = this.pjse_banner1.FloatText;

			Form f = new Form();
			f.Text = formTitle;
			f.WindowState = FormWindowState.Maximized;

			f.Controls.Add(this.bhavPanel);
			this.pjse_banner1.FloatText = pjse.Localization.GetString(
				"bhavForm.Unfloat"
			);
			this.pjse_banner1.FloatClick -= new System.EventHandler(
				this.btnFloat_Click
			);
			this.pjse_banner1.SetFormCancelButton(f);

			this.gbSpecial.Visible = true;
			this.cbSpecial.Enabled = false;
			this.btnCopyBHAV.Visible = false;

			handleOverride();

			f.ShowDialog();

			old.Controls.Add(this.bhavPanel);
			this.pjse_banner1.FloatText = oldFloatText;
			this.pjse_banner1.FloatClick += new System.EventHandler(
				this.btnFloat_Click
			);

			this.gbSpecial.Visible = this.cbSpecial.Checked;
			this.cbSpecial.Enabled = true;

			this.lbHidesOP.Visible =
				this.tbHidesOP.Visible =
				this.llHidesOP.Visible =
					false;
			this.llHidesOP.Tag = null;

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
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			common_LinkClicked(
				wrapper.ResourceByInstance(
					SimPe.Data.MetaData.BHAV_FILE,
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
					SimPe.Data.MetaData.BHAV_FILE,
					wrapper.FileDescriptor.Instance,
					(pjse.FileTable.Source)llHidesOP.Tag
				)
			);
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			if (this.isPopup)
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
			pjse.ExtractCurrent.Execute(wrapper, pjse_banner1.TitleText);
		}

		private void btnOpCode_Clicked(object sender, System.EventArgs e)
		{
			pjse.FileTable.Entry item = new ResourceChooser().Execute(
				SimPe.Data.MetaData.BHAV_FILE,
				wrapper.FileDescriptor.Group,
				bhavPanel.Parent,
				false
			);

			if (item != null && item.Instance != currentInst.Instruction.OpCode)
			{
				this.tbInst_OpCode.Text =
					"0x" + SimPe.Helper.HexString((ushort)item.Instance);
			}
		}

		private void btnOperandWiz_Clicked(object sender, System.EventArgs e)
		{
			OperandWiz(1);
		}

		private void btnOperandRaw_Click(object sender, System.EventArgs e)
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
				this.btnCancel.Enabled = true;
				internalchg = false;
			}
		}

		private void tbFilename_TextChanged(object sender, System.EventArgs e)
		{
			wrapper.FileName = tbFilename.Text;
		}

		private void tbFilename_Validated(object sender, System.EventArgs e)
		{
			tbFilename.SelectAll();
		}

		private void cbHex16_Enter(object sender, System.EventArgs e)
		{
			((ComboBox)sender).SelectAll();
		}

		private void cbHex16_TextChanged(object sender, System.EventArgs ev)
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
			System.ComponentModel.CancelEventArgs e
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

		private void cbHex16_Validated(object sender, System.EventArgs e)
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

		private void cbHex16_SelectedIndexChanged(object sender, System.EventArgs e)
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

		private void dec8_TextChanged(object sender, System.EventArgs ev)
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
			System.ComponentModel.CancelEventArgs e
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

		private void hex8_TextChanged(object sender, System.EventArgs ev)
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
			System.ComponentModel.CancelEventArgs e
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

		private void hex8_Validated(object sender, System.EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				((alHex8.IndexOf(sender) >= 16) ? "0x" : "")
				+ Helper.HexString(Convert.ToByte(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex16_TextChanged(object sender, System.EventArgs ev)
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
			System.ComponentModel.CancelEventArgs e
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

		private void hex16_Validated(object sender, System.EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x" + Helper.HexString(Convert.ToUInt16(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex32_TextChanged(object sender, System.EventArgs ev)
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
			System.ComponentModel.CancelEventArgs e
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

		private void hex32_Validated(object sender, System.EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x" + Helper.HexString(Convert.ToUInt32(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void btnSort_Clicked(object sender, System.EventArgs e)
		{
			this.pnflowcontainer.Sort();
		}

		private void btnMove_Clicked(object sender, System.EventArgs e)
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
				this.gbMove.Enabled = false;
				if (sender == this.btnUp)
				{
					this.pnflowcontainer.MoveInst(mv * -1);
				}
				else
				{
					this.pnflowcontainer.MoveInst(mv);
				}
			}
			finally
			{
				this.gbMove.Enabled = true;
			}
		}

		private void btnAdd_Clicked(object sender, System.EventArgs e)
		{
			this.pnflowcontainer.Add(BhavUIAddType.Default);
		}

		private void btnDel_Clicked(object sender, System.EventArgs e)
		{
			this.pnflowcontainer.Delete(BhavUIDeleteType.Default);
		}

		private void cbSpecial_CheckStateChanged(object sender, System.EventArgs e)
		{
			gbSpecial.Visible = pjse.Settings.PJSE.ShowSpecialButtons = (
				(CheckBox)sender
			).Checked;
		}

		private void btnInsVia_Click(object sender, System.EventArgs e)
		{
			this.pnflowcontainer.Add(
				(sender == this.btnInsTrue)
					? BhavUIAddType.ViaTrue
					: BhavUIAddType.ViaFalse
			);
		}

		private void btnDelPescado_Click(object sender, System.EventArgs e)
		{
			this.pnflowcontainer.Delete(BhavUIDeleteType.Pescado);
		}

		private void btnLinkInge_Click(object sender, System.EventArgs e)
		{
			this.pnflowcontainer.Relink();
		}

		private void btnAppend_Click(object sender, System.EventArgs e)
		{
			this.pnflowcontainer.Append(
				new ResourceChooser().Execute(
					SimPe.Data.MetaData.BHAV_FILE,
					wrapper.FileDescriptor.Group,
					bhavPanel.Parent,
					true,
					0x10
				)
			);
		}

		private void btnDelMerola_Click(object sender, System.EventArgs e)
		{
			this.pnflowcontainer.DeleteUnlinked();
		}

		private void btnCopyListing_Click(object sender, System.EventArgs e)
		{
			this.CopyListing();
		}

		private void btnPasteListing_Click(object sender, EventArgs e)
		{
			this.PasteListing();
		}

		private void btnTPRPMaker_Click(object sender, System.EventArgs e)
		{
			this.TPRPMaker();
		}

		private void btnInsUnlinked_Click(object sender, EventArgs e)
		{
			this.pnflowcontainer.Add(BhavUIAddType.Unlinked);
		}

		private void btnGUIDIndex_Click(object sender, EventArgs e)
		{
			this.cmenuGUIDIndex.Show((Control)sender, new Point(3, 3));
		}

		private void cmenuGUIDIndex_Opening(object sender, CancelEventArgs e)
		{
			createCurrentPackageToolStripMenuItem.Enabled = (
				pjse.FileTable.GFT.CurrentPackage != null
				&& pjse.FileTable.GFT.CurrentPackage.FileName != null
				&& !pjse
					.FileTable.GFT.CurrentPackage.FileName.ToLower()
					.EndsWith("objects.package")
			);
		}

		private void createToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.UseWaitCursor = true;
			Application.DoEvents();
			pjse.GUIDIndex.TheGUIDIndex.Create(
				sender.Equals(this.createCurrentPackageToolStripMenuItem)
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
					this.defaultFileToolStripMenuItem1,
					null
				);
			}
			else if (dr == DialogResult.Retry)
			{
				fileToolStripMenuItem_Click(this.toFileToolStripMenuItem, null);
			}
		}

		private void defaultFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (sender.Equals(this.defaultFileToolStripMenuItem))
			{
				pjse.GUIDIndex.TheGUIDIndex.Load();
			}
			else
			{
				pjse.GUIDIndex.TheGUIDIndex.Save();
			}
		}

		private void fileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool load = sender.Equals(this.fromFileToolStripMenuItem);
			FileDialog fd;
			if (load)
			{
				fd = new OpenFileDialog();
			}
			else
			{
				fd = new SaveFileDialog();
			}

			fd.AddExtension = true;
			fd.CheckFileExists = load;
			fd.CheckPathExists = true;
			fd.DefaultExt = "txt";
			fd.DereferenceLinks = true;
			fd.FileName = pjse.GUIDIndex.DefaultGUIDFile;
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
					pjse.GUIDIndex.TheGUIDIndex.Load(fd.FileName);
				}
				else
				{
					pjse.GUIDIndex.TheGUIDIndex.Save(fd.FileName);
				}
			}
		}
	}
}
