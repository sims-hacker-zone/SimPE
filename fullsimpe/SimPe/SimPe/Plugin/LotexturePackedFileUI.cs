// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public partial class LotexturePackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new LotexturePackedFileWrapper Wrapper => base.Wrapper as LotexturePackedFileWrapper;
		public LotexturePackedFileWrapper TPFW => Wrapper;

		string hoodtype;
		int memorees;

		#region WrapperBaseControl Member

		public LotexturePackedFileUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			rtLotTex.ReadOnly = true;
			CanCommit = false;
			memorees = Wrapper.Itemnumber;
			if (memorees == -1)
			{
				rtLotTex.Text = "Unknown Version!";
			}
			else
			{
				if (Wrapper.FileDescriptor.Type == FileTypes.LTTX)
				{
					HeaderText = "Lot Texture Reader";
					hoodtype = Wrapper.Hoodtexture;
					hoodtype = Wrapper.Hoodtexture == "lottexture-test-01"
						? "Lush"
						: Wrapper.Hoodtexture == "lottexture-canvas-dirt"
							? "Dirt"
							: Wrapper.Hoodtexture == "lottexture-canvas-desert"
													? "Desert"
													: Wrapper.Hoodtexture == "lottexture-concrete-01"
																			? "Concrete"
																			: Wrapper.Hoodtexture == "terrain-beach" ? "Castaway" : Localization.GetString("Unknown");

					rtLotTex.Text =
						"Base texture is "
						+ Wrapper.Hoodtexture
						+ "\r\nSo neighbourhood type is "
						+ hoodtype
						+ ".\r\n\r\n";
					if (Wrapper.itemnum > 0)
					{
						rtLotTex.Text += "  ~Other Textures~\r\n";
						foreach (string tecst in Wrapper.texchure)
						{
							if (tecst != null)
							{
								rtLotTex.Text += tecst + "\r\n";
							}
						}
					}
				}
				else if (Wrapper.FileDescriptor.Type == FileTypes.SMEM)
				{
					HeaderText = "Single Sim Memories";
					rtLotTex.Text =
						Wrapper.Hoodtexture
						+ " Memories ("
						+ Convert.ToString(memorees)
						+ ")";
					if (Wrapper.Badges > 0)
					{
						rtLotTex.Text += "\n -- Skills --";
						for (int j = 0; j < Wrapper.Badges; j++)
						{
							rtLotTex.Text +=
								"\n("
								+ Helper.HexString(Wrapper.badgesid[j])
								+ ") "
								+ pjse.GUIDIndex.TheGUIDIndex[Wrapper.badgesid[j]];
							;
						}
						rtLotTex.Text += "\n\n -- Memories --";
					}
					for (int i = 0; i < memorees; i++)
					{
						rtLotTex.Text +=
							"\n("
							+ Helper.HexString(Wrapper.remeberid[i])
							+ ") "
							+ pjse.GUIDIndex.TheGUIDIndex[Wrapper.remeberid[i]];
						;
					}
				}
				else
				{
					HeaderText = "Neighour Id Mapping";
					rtLotTex.Text =
						" Nid Mapping ("
						+ Convert.ToString(memorees - Wrapper.visitnum)
						+ " Family Sims)";
					for (int i = Wrapper.visitnum; i < memorees; i++)
					{
						rtLotTex.Text +=
							"\n"
							+ Wrapper.texchure[i]
							+ " - GUID(0x"
							+ Helper.HexString(Wrapper.badgesid[i])
							+ ") - Nid(0x"
							+ Helper.HexString(Convert.ToUInt16(Wrapper.remeberid[i]))
							+ ")";
					}
					if (Wrapper.visitnum > 0)
					{
						rtLotTex.Text +=
							" \n\n "
							+ Convert.ToString(Wrapper.visitnum)
							+ " Other Sims";
						for (int j = 0; j < Wrapper.visitnum; j++)
						{
							rtLotTex.Text +=
								"\n"
								+ Wrapper.texchure[j]
								+ " - GUID(0x"
								+ Helper.HexString(Wrapper.badgesid[j])
								+ ") - Nid(0x"
								+ Helper.HexString(
									Convert.ToUInt16(Wrapper.remeberid[j])
								)
								+ ")";
						}
					}
				}
			}
		}

		private void Updatey()
		{
			if (rtLotTex.Lines.Length < 5)
			{
				return;
			}

			bool bgine = false;
			int i = 0;
			foreach (string clit in rtLotTex.Lines)
			{
				if (bgine)
				{
					Wrapper.texchure[i] = clit;
					i++;
					if (i >= Wrapper.itemnum)
					{
						break;
					}
				}
				if (clit.Contains("Other Textures"))
				{
					bgine = true;
				}
			}
		}

		public override void OnCommit()
		{
			if (Wrapper.FileDescriptor.Type == FileTypes.LTTX)
			{
				Updatey();
				base.OnCommit();
				TPFW.SynchronizeUserData(true, false);
			}
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
	}
}
