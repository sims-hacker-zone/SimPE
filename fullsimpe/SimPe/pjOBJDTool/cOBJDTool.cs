/***************************************************************************
 *   Copyright (C) 2008 by Peter L Jones                                   *
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
using System.Windows.Forms;

using pjse.BhavOperandWizards;

using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;

namespace pjOBJDTool
{
	public partial class cOBJDTool : Form //, ITool
	{
		bool initialised = false;

		public cOBJDTool()
		{
			InitializeComponent();
			initialised = false;
		}

		private void InitializeForm()
		{
			initialised = true;

			SimPe.Wait.Start(6);

			docCTSSInstance = new DataOwnerControl(
				null,
				null,
				null,
				tbCTSSInstance,
				null,
				null,
				null,
				7,
				(ushort)0
			)
			{
				Decimal = false,
				Use0xPrefix = true
			};
			docCTSSInstance.DataOwnerControlChanged += new EventHandler(
				docCTSSInstance_DataOwnerControlChanged
			);
			SimPe.Wait.Progress++;

			InitializeValueMotive();
			SimPe.Wait.Progress++;
			InitializeValue();
			SimPe.Wait.Progress++;
			InitializeEPs();
			SimPe.Wait.Progress++;
			InitializeRoomComm();
			SimPe.Wait.Progress++;
			InitializeFuncBuild();
			SimPe.Wait.Progress++;

			SimPe.Wait.Stop();
		}

		DataOwnerControl docCTSSInstance = null;

		void docCTSSInstance_DataOwnerControlChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			pjse.FileTable.Entry[] actss = pjse.FileTable.GFT[
				SimPe.Data.MetaData.CTSS_FILE,
				wrapper.FileDescriptor.Group,
				docCTSSInstance.Value
			];
			wrapper[0x29] = docCTSSInstance.Value;

			SimPe.PackedFiles.Wrapper.StrWrapper ctss =
				new SimPe.PackedFiles.Wrapper.StrWrapper();
			if (actss.Length > 0)
			{
				ctss.ProcessData(actss[0].PFD, actss[0].Package);
				tbCTSSName.Text = ctss[1, 0].Title;
				tbCTSSDesc.Text = ctss[1, 1].Title;
			}
			else
			{
				tbCTSSName.Text = tbCTSSDesc.Text = "";
			}
		}

		#region ValueMotive shorts
		// price, sale price, initial dep, daily dep, dep limit
		// and Motive Ratings
		List<DataOwnerControl> adocValueMotive = null;
		short[] asValueMotive = new short[]
		{
			0x12,
			0x22,
			0x23,
			0x24,
			0x26,
			0x52,
			0x53,
			0x54,
			0x55,
			0x56,
			0x57,
			0x58,
			0x59,
			0x67,
			0x68,
		};

		void InitializeValueMotive()
		{
			atbValueMotive = new TextBox[]
			{
				tbPrice,
				tbSalePrice,
				tbInitialDep,
				tbDailyDep,
				tbDepLimit,
				tbMotive1,
				tbMotive2,
				tbMotive3,
				tbMotive4,
				tbMotive5,
				tbMotive6,
				tbMotive7,
				tbMotive8,
				tbMotive9,
				tbMotiveA,
			};
			adocValueMotive = new List<DataOwnerControl>();
			foreach (TextBox tb in atbValueMotive)
			{
				adocValueMotive.Add(
					new DataOwnerControl(
						null,
						null,
						null,
						tb,
						null,
						null,
						null,
						7,
						(ushort)0
					)
				);
			}

			foreach (DataOwnerControl doc in adocValueMotive)
			{
				doc.Decimal = true;
				doc.DataOwnerControlChanged += new EventHandler(
					adocValueMotive_DataOwnerControlChanged
				);
			}
		}

		TextBox[] atbValueMotive = null;

		void adocValueMotive_DataOwnerControlChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			int i = adocValueMotive.IndexOf((DataOwnerControl)sender);
			if (i < 0)
			{
				return;
			}

			wrapper[asValueMotive[i]] = adocValueMotive[i].Value;
		}
		#endregion

		#region Value bool
		// self-dep
		List<CheckBox> ackbValue = null;
		short[] abValue = new short[] { 0x25 };

		void InitializeValue()
		{
			ackbValue = new List<CheckBox>(new CheckBox[] { ckbSelfDep });
			foreach (CheckBox ckb in ackbValue)
			{
				ckb.CheckedChanged += new EventHandler(ackbValue_CheckedChanged);
			}
		}

		void ackbValue_CheckedChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			int i = ackbValue.IndexOf((CheckBox)sender);
			if (i < 0)
			{
				return;
			}

			wrapper[abValue[i]] = (ushort)(ackbValue[i].Checked ? 1 : 0);
		}
		#endregion


		#region EPs flags

		List<LabelledBoolsetControl> albcValidEPs = null;
		pjse.GS.BhavStr[] abhsEPs = new pjse.GS.BhavStr[]
		{
			pjse.GS.BhavStr.ValidEPFlags1,
			pjse.GS.BhavStr.ValidEPFlags2,
		};

		short[] absEPs = new short[] { 0x40, 0x41 };

		void InitializeEPs()
		{
			albcValidEPs = new List<LabelledBoolsetControl>(
				new LabelledBoolsetControl[] { lbcValidEPs1, lbcValidEPs2 }
			);
			foreach (LabelledBoolsetControl lbc in albcValidEPs)
			{
				lbc.ValueChanged += new EventHandler(rb_CheckedChanged);
			}

			List<string> l = new List<string>();
			for (int i = 0; i < abhsEPs.Length; i++)
			{
				l = pjse.BhavWiz.readStr(abhsEPs[i]);
				while (l.Count < 16)
				{
					l.Add("-");
				}

				albcValidEPs[i].Labels = l;
			}
		}

		void rb_CheckedChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			int i = albcValidEPs.IndexOf((LabelledBoolsetControl)sender);
			if (i < 0)
			{
				return;
			}

			wrapper[absEPs[i]] = albcValidEPs[i].Value;
		}

		#endregion

		#region RoomComm boolsets
		List<LabelledBoolsetControl> albcRoomCommm = null;
		pjse.GS.BhavStr[] abhsRoomComm = new pjse.GS.BhavStr[]
		{
			pjse.GS.BhavStr.RoomSortFlags,
			pjse.GS.BhavStr.CommunitySortFlags,
		};
		short[] absRoomComm = new short[] { 0x27, 0x64 };

		void InitializeRoomComm()
		{
			albcRoomCommm = new List<LabelledBoolsetControl>(
				new LabelledBoolsetControl[] { lbcRoom, lbcCommunity }
			);
			foreach (LabelledBoolsetControl lbc in albcRoomCommm)
			{
				lbc.ValueChanged += new EventHandler(albcRoomCommm_ValueChanged);
			}

			List<string> l = new List<string>();
			for (int i = 0; i < abhsRoomComm.Length; i++)
			{
				l = pjse.BhavWiz.readStr(abhsRoomComm[i]);
				while (l.Count < 16)
				{
					//l.Add((l.Count + 1).ToString());
					l.Add("-");
				}

				albcRoomCommm[i].Labels = l;
			}
		}

		void albcRoomCommm_ValueChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			int i = albcRoomCommm.IndexOf((LabelledBoolsetControl)sender);
			if (i < 0)
			{
				return;
			}

			wrapper[absRoomComm[i]] = albcRoomCommm[i].Value;
		}
		#endregion

		#region FuncBuild Flags
		// Function, Build Mode
		// Function Sub-sort, Build Mode Sub-sort
		List<ComboBox> acbFuncBuild = null;
		pjse.GS.BhavStr[] abhsFuncBuild = new pjse.GS.BhavStr[]
		{
			pjse.GS.BhavStr.FunctionSortFlags,
			pjse.GS.BhavStr.BuildModeType,
		};
		short[] afFuncBuild = new short[] { 0x28, 0x45 }; // Function, Build mode type

		List<LabelledBoolsetControl> albcFuncBuild = null;
		short[] absFuncBuild = new short[] { 0x5e, 0x4a }; // Function sub-sort, Build sub-sort

		void InitializeFuncBuild()
		{
			acbFuncBuild = new List<ComboBox>(new ComboBox[] { cbFunction, cbBuild });
			for (int i = 0; i < acbFuncBuild.Count; i++)
			{
				acbFuncBuild[i].Items.Add("None");
				foreach (string label in pjse.BhavWiz.readStr(abhsFuncBuild[i]))
				{
					acbFuncBuild[i]
						.Items.Add(
							acbFuncBuild[i].Items.Count.ToString() + ". " + label
						);
				}

				while (acbFuncBuild[i].Items.Count < 16)
				{
					acbFuncBuild[i]
						.Items.Add(acbFuncBuild[i].Items.Count.ToString() + ".");
				}

				acbFuncBuild[i].SelectedIndexChanged += new EventHandler(
					acbFuncBuild_SelectedIndexChanged
				);
			}

			albcFuncBuild = new List<LabelledBoolsetControl>(
				new LabelledBoolsetControl[] { lbcFunction, lbcBuild }
			);
			for (int i = 0; i < albcFuncBuild.Count; i++)
			{
				albcFuncBuild[i].ValueChanged += new EventHandler(
					albcFuncBuild_ValueChanged
				);
			}
		}

		void acbFuncBuild_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			int i = acbFuncBuild.IndexOf((ComboBox)sender);
			if (i < 0 || acbFuncBuild[i].SelectedIndex < 0)
			{
				return;
			}

			List<string> l = new List<string>();
			if (acbFuncBuild[i].SelectedIndex == 0)
			{
				wrapper[afFuncBuild[i]] = 0;
				while (l.Count < 16)
				{
					//l.Add((l.Count + 1).ToString());
					l.Add("-");
				}

				albcFuncBuild[i].Labels = l;
				return;
			}

			int j = acbFuncBuild[i].SelectedIndex - 1;
			wrapper[afFuncBuild[i]] = (ushort)(1 << j);
			l = pjse.BhavWiz.readStr((pjse.GS.BhavStr)(0x110 + 16 * i + j));
			while (l.Count < 16)
			{
				//l.Add((l.Count + 1).ToString());
				l.Add("-");
			}

			albcFuncBuild[i].Labels = l;
		}

		void albcFuncBuild_ValueChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			int i = albcFuncBuild.IndexOf((LabelledBoolsetControl)sender);
			if (i < 0)
			{
				return;
			}

			wrapper[absFuncBuild[i]] = albcFuncBuild[i].Value;
		}
		#endregion


		private bool changed = false; // indicates whether the tool updated the packed file
		SimPe.Interfaces.Files.IPackedFileDescriptor pfd; // the PFD that was current at the start
		private pfOBJD wrapper = null; // what we're editing

		pfOBJD CurrentOBJD
		{
			get => wrapper;
			set
			{
				if (wrapper == value)
				{
					return;
				}

				if (!SaveAbandonCancel())
				{
					return;
				}

				if (wrapper != null)
				{
					wrapper.WrapperChanged -= new EventHandler(
						WrapperChanged
					);
				}

				wrapper = value;

				LoadOBJD();
			}
		}

		/// <summary>
		/// If there are uncommitted changes to the current PFD, prompts the user to Save or Abandon.
		/// If they choose Save, calls SaveOBJD().
		/// Cancel means return to editing.
		/// </summary>
		/// <returns>True for Save or Abandon (or when nothing needed saving); False for Cancel</returns>
		private bool SaveAbandonCancel()
		{
			if (wrapper == null || !wrapper.Changed)
			{
				return true; // nothing to worry about
			}

			DialogResult dr = MessageBox.Show(
				"You have uncommitted changes to the Object Definition you are editing. Do you want to save these changes?",
				"PJ OBJD Tool",
				MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button3
			);
			switch (dr)
			{
				case DialogResult.Yes:
					SaveOBJD();
					return true;
				case DialogResult.No:
					wrapper.Changed = false;
					return true;
				default:
					return false;
			}
		}

		private void LoadOBJD()
		{
			if (wrapper == null)
			{
				tbOBJDName.Text =
					tbOBJDGroup.Text =
					tbOBJDInstance.Text =
					tbCTSSInstance.Text =
					tbCTSSName.Text =
					tbCTSSDesc.Text =
						"";
				cbOBJDvsn.SelectedIndex = -1;
				for (int i = 0; i < adocValueMotive.Count; i++)
				{
					atbValueMotive[i].Text = "";
				}

				for (int i = 0; i < ackbValue.Count; i++)
				{
					ackbValue[i].CheckState = CheckState.Indeterminate;
				}

				for (int i = 0; i < albcRoomCommm.Count; i++)
				{
					albcRoomCommm[i].Value = 0;
				}

				for (int i = 0; i < acbFuncBuild.Count; i++)
				{
					acbFuncBuild[i].SelectedIndex = -1;
				}

				for (int i = 0; i < albcFuncBuild.Count; i++)
				{
					albcFuncBuild[i].Value = 0;
				}

				cbOBJDvsn.Enabled =
					tbCTSSInstance.Enabled =
					gbValue.Enabled =
					gbMotiveRs.Enabled =
					gbValidEPs1.Enabled =
					gbValidEPs2.Enabled =
					gbRoomSort.Enabled =
					gbCommSort.Enabled =
					gbFuncSort.Enabled =
					gbBuildSort.Enabled =
						false;
			}
			else
			{
				wrapper.WrapperChanged += new EventHandler(WrapperChanged);
				cbOBJDvsn.Enabled =
					tbCTSSInstance.Enabled =
					gbValue.Enabled =
					gbMotiveRs.Enabled =
					gbValidEPs1.Enabled =
					gbValidEPs2.Enabled =
					gbRoomSort.Enabled =
					gbCommSort.Enabled =
					gbFuncSort.Enabled =
					gbBuildSort.Enabled =
						true;

				tbOBJDName.Text = wrapper.Filename;
				tbOBJDGroup.Text =
					"0x" + SimPe.Helper.HexString(wrapper.FileDescriptor.Group);
				tbOBJDInstance.Text =
					"0x" + SimPe.Helper.HexString(wrapper.FileDescriptor.Instance);

				cbOBJDvsn.SelectedIndex =
					wrapper[0x00] <= 0x8b ? 0
					: wrapper[0x00] >= 0x8d ? 2
					: 1;
				cbOBJDvsn_SelectedIndexChanged(null, null);

				//tbCTSSGroup.Text = "0x" + SimPe.Helper.HexString(wrapper.FileDescriptor.Group);
				tbCTSSInstance.Text = "0x" + SimPe.Helper.HexString(wrapper[0x29]);
				docCTSSInstance_DataOwnerControlChanged(null, null);

				for (int i = 0; i < adocValueMotive.Count; i++)
				{
					atbValueMotive[i].Text = wrapper[asValueMotive[i]].ToString();
				}

				for (int i = 0; i < ackbValue.Count; i++)
				{
					ackbValue[i].Checked = wrapper[abValue[i]] != 0;
				}

				for (int i = 0; i < albcRoomCommm.Count; i++)
				{
					albcRoomCommm[i].Value = (ushort)wrapper[absRoomComm[i]];
				}

				for (int i = 0; i < albcValidEPs.Count; i++)
				{
					albcValidEPs[i].Value = (ushort)wrapper[absEPs[i]];
				}

				for (int i = 0; i < acbFuncBuild.Count; i++)
				{
					ushort j = wrapper[afFuncBuild[i]];
					int k = ((String)(Boolset)j).IndexOf("1");
					acbFuncBuild[i].SelectedIndex = k < 0 ? 0 : 16 - k;
				}
				for (int i = 0; i < albcFuncBuild.Count; i++)
				{
					albcFuncBuild[i].Value = (ushort)wrapper[absFuncBuild[i]];
				}
			}
		}

		private void SaveOBJD()
		{
			if (wrapper == null)
			{
				return; // will never happen
			}

			changed |=
				pfd != null
				&& wrapper.FileDescriptor != null
				&& pfd == wrapper.FileDescriptor
				&& wrapper.Changed; // can only become true, never false.

			wrapper.SynchronizeUserData();
			btnCommit.Enabled = wrapper.Changed;
		}

		private void WrapperChanged(object sender, EventArgs e)
		{
			btnCommit.Enabled = wrapper.Changed;
		}

		private List<pfOBJD> availableOBJDs = null;
		private List<pfOBJD> AvailableOBJDs
		{
			get
			{
				if (availableOBJDs != null)
				{
					return availableOBJDs;
				}

				List<pfOBJD> lpfo = new List<pfOBJD>();
				pjse.FileTable.Entry[] items = pjse.FileTable.GFT[
					SimPe.Data.MetaData.OBJD_FILE,
					pjse.FileTable.Source.Local
				];
				SimPe.Wait.Start(items.Length);
				foreach (pjse.FileTable.Entry item in items)
				{
					pfOBJD pfo = new pfOBJD();
					pfo.ProcessData(item.PFD, item.Package);
					lpfo.Add(pfo);
					SimPe.Wait.Progress++;
				}
				SimPe.Wait.Stop();

				availableOBJDs = lpfo;
				return lpfo;
			}
		}

		#region ITool Members

		// IToolResult ITool.ShowDialog(ref SimPe.Interfaces.Files.IPackedFileDescriptor pfd, ref SimPe.Interfaces.Files.IPackageFile package)

		internal IToolResult Execute(
			ref SimPe.Interfaces.Files.IPackedFileDescriptor pfd,
			ref SimPe.Interfaces.Files.IPackageFile package,
			IProviderRegistry prov
		)
		{
			Application.OpenForms[0].Cursor = Cursors.AppStarting;

			if (!initialised)
			{
				InitializeForm();
			}

			availableOBJDs = null;

			this.pfd = pfd;
			changed = false;

			List<pfOBJD> apfs = AvailableOBJDs;
			btnSelectOBJD.Enabled = apfs.Count > 1;

			Application.OpenForms[0].Cursor = Cursors.Default;

			if (apfs.Count > 1 || apfs.Count == 0)
			{
				btnSelectOBJD_Click(null, null);
			}
			else
			{
				CurrentOBJD = apfs[0];
			}

			if (wrapper != null)
			{
				btnCommit.Enabled = wrapper.Changed;
				ShowDialog();
			}

			return new SimPe.Plugin.ToolResult(changed, false);
		}

		#endregion

		private void btnSelectOBJD_Click(object sender, EventArgs e)
		{
			cOBJDChooser coc = new cOBJDChooser();
			DialogResult dr = coc.Execute(AvailableOBJDs);
			if (dr == DialogResult.OK && coc.Value != null)
			{
				CurrentOBJD = coc.Value;
			}

			coc.Dispose();
		}

		private void btnCommit_Click(object sender, EventArgs e)
		{
			SaveOBJD();
		}

		private void cbOBJDvsn_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			ushort value = (ushort)(
				cbOBJDvsn.SelectedIndex < 1 ? 0x8b
				: cbOBJDvsn.SelectedIndex > 1 ? 0x8d
				: 0x8c
			);
			wrapper[0x00] = value;

			value = wrapper[absEPs[1]];
			if (wrapper[0x00] < 0x8c)
			{
				wrapper[absEPs[1]] = 0;
				gbValidEPs2.Enabled = false;
				if (value != 0)
				{
					wrapper[absEPs[0]] = 0x01;
				}
			}
			else
			{
				gbValidEPs2.Enabled = true;
			}
			// if (wrapper[0x00] < 0x8c) wrapper[absEPs[0]] = 0;
		}

		private void cOBJDTool_FormClosing(object sender, FormClosingEventArgs e)
		{
			CurrentOBJD = null;
			e.Cancel = CurrentOBJD != null;
		}
	}
}
