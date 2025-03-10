// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Smap;

namespace SimPe.PackedFiles.Smap
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public partial class StringMapPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new StringMapPackedFileWrapper Wrapper => base.Wrapper as StringMapPackedFileWrapper;
		public StringMapPackedFileWrapper TPFW => Wrapper;

		#region WrapperBaseControl Member

		bool holde = true;
		Dictionary<uint, string> wallsandfloors = new Dictionary<uint, string>();

		public StringMapPackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			holde = true;
			base.RefreshGUI();
			CanCommit = false;
			rtbnames.Visible = false;
			btshowim.Text = "Show Names";
			BackgroundImageLocation = new System.Drawing.Point(730, 0);
			tbfilenm.Text = Wrapper.FileName;
			lbType.Text = Wrapper.FileDescriptor.Instance == 13 ? "Type: Walls" : Wrapper.FileDescriptor.Instance == 14 ? "Type: Floor Coverings" : "";

			fillimup();
			holde = false;
		}

		public override void OnCommit()
		{
			base.OnCommit();
			TPFW.SynchronizeUserData(true, false);
		}
		#endregion

		#region IPackedFileUI Member
		System.Windows.Forms.Control IPackedFileUI.GUIHandle => this;
		#endregion

		#region IDisposable Member

		void IDisposable.Dispose()
		{
			TPFW.Dispose();
		}
		#endregion

		private void tbfilenm_TextChanged(object sender, EventArgs e)
		{
			if (holde)
			{
				return;
			}

			Wrapper.FileName = tbfilenm.Text;
			CanCommit = true;
			Wrapper.Changed = true;
		}

		private void rtbStrings_TextChanged(object sender, EventArgs e)
		{
			if (holde)
			{
				return;
			}

			int i = 0;
			foreach (string clit in rtbStrings.Lines)
			{
				if (i == Wrapper.Strings.Length)
				{
					break;
				}

				Wrapper.Strings[i] = clit;
				i++;
			}
			CanCommit = true;
			Wrapper.Changed = true;
		}

		private void btshowim_Click(object sender, EventArgs e)
		{
			if (holde)
			{
				return;
			}

			if (rtbnames.Visible)
			{
				rtbnames.Visible = false;
				BackgroundImageLocation = new System.Drawing.Point(730, 0);
				btshowim.Text = "Show Names";
			}
			else
			{
				holde = true;
				rtbnames.Text = "";
				uint tmpy = 0;
				if (wallsandfloors.Count < 1)
				{
					fildictionary();
				}

				foreach (string clit in rtbStrings.Lines)
				{
					if (clit.Length < 9)
					{
						try
						{
							tmpy = Helper.HexStringToUInt(clit);
							if (wallsandfloors.ContainsKey(tmpy) && tmpy > 0)
							{
								rtbnames.Text += wallsandfloors[tmpy] + "\r\n";
							}
							else
							{
								rtbnames.Text += clit + "\r\n";
							}
						}
						catch
						{
							rtbnames.Text += clit + "\r\n";
						}
					}
					else
					{
						rtbnames.Text += clit + "\r\n";
					}
				}
				BackgroundImageLocation = new System.Drawing.Point(930, 0);
				rtbnames.Visible = true;
				btshowim.Text = "Hide Names";
				holde = false;
			}
		}

		private void fillimup()
		{
			rtbStrings.Text = rtbDatas.Text = "";
			for (int i = 0; i < Wrapper.Strings.Length; i++)
			{
				rtbStrings.Text += Wrapper.Strings[i] + "\r\n";
				rtbDatas.Text +=
					"index "
					+ Convert.ToString(Wrapper.Datas[i])
					+ " - data 0x"
					+ Helper.HexString(Wrapper.TyPes[i])
					+ "\r\n";
			}
		}

		private void fildictionary()
		{
			wallsandfloors.Add(0x00000000, "none"); //ensure dictionary is no longer empty even if none of the catpatterns are available
			FileTableBase.FileIndex.Load();
			IEnumerable<Interfaces.Scenegraph.IScenegraphFileIndexItem> items =
				FileTableBase.FileIndex.FindFile(FileTypes.XOBJ, true);
			Wait.SubStart(items.Count());
			Wait.Message = "Loading Wall & Floor Names";
			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in items)
			{
				try
				{
					Cpf.Cpf colour =
						new Cpf.Cpf().ProcessFile(item);
					if (
						!wallsandfloors.ContainsKey(
							colour.GetSaveItem("guid").UIntegerValue
						)
					)
					{
						wallsandfloors.Add(
							colour.GetSaveItem("guid").UIntegerValue,
							colour.GetSaveItem("name").StringValue
						);
					}
				}
				catch { }
				Wait.Progress += 1;
			}
			Wait.SubStop();
		}
	}
}
