using System;
using System.Collections.Generic;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public partial class StringMapPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new StringMapPackedFileWrapper Wrapper => base.Wrapper as StringMapPackedFileWrapper;
		public StringMapPackedFileWrapper TPFW => (StringMapPackedFileWrapper)Wrapper;

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
			this.CanCommit = false;
			this.rtbnames.Visible = false;
			this.btshowim.Text = "Show Names";
			this.BackgroundImageLocation = new System.Drawing.Point(730, 0);
			this.tbfilenm.Text = Wrapper.FileName;
			if (Wrapper.FileDescriptor.Instance == 13)
			{
				this.lbType.Text = "Type: Walls";
			}
			else if (Wrapper.FileDescriptor.Instance == 14)
			{
				this.lbType.Text = "Type: Floor Coverings";
			}
			else
			{
				this.lbType.Text = "";
			}

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
			this.TPFW.Dispose();
		}
		#endregion

		private void tbfilenm_TextChanged(object sender, EventArgs e)
		{
			if (holde)
			{
				return;
			}

			Wrapper.FileName = tbfilenm.Text;
			this.CanCommit = true;
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
			this.CanCommit = true;
			Wrapper.Changed = true;
		}

		private void btshowim_Click(object sender, EventArgs e)
		{
			if (holde)
			{
				return;
			}

			if (this.rtbnames.Visible)
			{
				this.rtbnames.Visible = false;
				this.BackgroundImageLocation = new System.Drawing.Point(730, 0);
				this.btshowim.Text = "Show Names";
			}
			else
			{
				holde = true;
				this.rtbnames.Text = "";
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
				this.BackgroundImageLocation = new System.Drawing.Point(930, 0);
				this.rtbnames.Visible = true;
				this.btshowim.Text = "Hide Names";
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
			FileTable.FileIndex.Load();
			Interfaces.Scenegraph.IScenegraphFileIndexItem[] items =
				FileTable.FileIndex.FindFile(0xCCA8E925, true);
			Wait.SubStart(items.Length);
			Wait.Message = "Loading Wall & Floor Names";
			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in items)
			{
				try
				{
					PackedFiles.Wrapper.Cpf colour =
						new PackedFiles.Wrapper.Cpf();
					colour.ProcessData(item);
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
