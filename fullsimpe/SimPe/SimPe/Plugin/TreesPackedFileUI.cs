using System;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public partial class TreesPackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new TreesPackedFileWrapper Wrapper => base.Wrapper as TreesPackedFileWrapper;
		public TreesPackedFileWrapper TPFW => (TreesPackedFileWrapper)Wrapper;

		#region WrapperBaseControl Member

		public TreesPackedFileUI()
		{
			InitializeComponent();
			if (
				Helper.WindowsRegistry.UseBigIcons
				&& Screen.PrimaryScreen.WorkingArea.Width > 1600
			)
			{
				listLast.Font = new System.Drawing.Font("Verdana", 12F);
				listList.Font = new System.Drawing.Font("Verdana", 12F);
			}
		}

		bool holde = true;

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			holde = true;
			tbfilename.Text = Wrapper.FileNam;
			tbcount.Text = Convert.ToString(Wrapper.Count);
			tbversion.Text = Convert.ToString(Wrapper.Vershin);
			if (Wrapper.Vershin == 69)
			{
				listList.Visible = taskBox1.Visible = pnhidim.Visible = false;
				listLast.Visible =
					taskBox2.Visible =
					btDown.Visible =
					btMove.Visible =
						true;
				btBhave.Visible = Wrapper.SiblingResource(0x42484156) != null;
				Comment2.Width = listLast.Width - 105;
				this.CanCommit = true;
			}
			else
			{
				listList.Visible = taskBox1.Visible = pnhidim.Visible = true;
				btBhave.Visible =
					listLast.Visible =
					taskBox2.Visible =
					btDown.Visible =
					btMove.Visible =
						false;
				if (listList.Width > 900)
				{
					Comment.Width = listList.Width - 680;
				}

				this.CanCommit = Wrapper.Count < 64;
				tbheader.Text = "0x" + Helper.HexString(Wrapper.Header);
				tbunk0.Text = Helper.HexString(Wrapper.Unk0);
				tbunk1.Text = Helper.HexString(Wrapper.Unk1);
				tbunk2.Text = Helper.HexString(Wrapper.Unk2);
				tbunk3.Text = Helper.HexString(Wrapper.Unk3);
				tbunk4.Text = Helper.HexString(Wrapper.Unk4);
				tbunk5.Text = Helper.HexString(Wrapper.Unk5);
			}
			fillimupList();
			holde = false;
		}

		public override void OnCommit()
		{
			base.OnCommit();
			TPFW.SynchronizeUserData(true, false);
		}
		#endregion

		#region IPackedFileUI Member
		Control IPackedFileUI.GUIHandle => this;
		#endregion

		#region IDisposable Member

		void IDisposable.Dispose()
		{
			this.TPFW.Dispose();
		}
		#endregion

		private void clearimup()
		{
		}

		private void fillimupList()
		{
			if (Wrapper.Vershin == 69)
			{
				listLast.Items.Clear();
				ListViewItem item;
				for (int i = 0; i < Wrapper.Count; i++)
				{
					item = new ListViewItem(
						"0x" + i.ToString("X") + " (" + Convert.ToString(i) + ")"
					);
					item.SubItems.Add(Wrapper.Items[i]);
					item.Tag = i;
					listLast.Items.Add(item);
				}
			}
			else
			{
				listList.Items.Clear();
				string name;
				for (int i = 0; i < Math.Min(64, Wrapper.Count); i++)
				{
					ListViewItem item = new ListViewItem(Wrapper.Items[i]);
					name = Helper.HexString((uint)Wrapper.vdata.GetValue(0, i));
					item.SubItems.Add(name);
					name = Helper.HexString(
						Convert.ToUInt16(Wrapper.vdata.GetValue(1, i))
					);
					item.SubItems.Add(name);
					name = Helper.HexString(
						Convert.ToUInt16(Wrapper.vdata.GetValue(2, i))
					);
					item.SubItems.Add(name);
					name = Helper.HexString(
						Convert.ToUInt16(Wrapper.vdata.GetValue(3, i))
					);
					item.SubItems.Add(name);
					name = Helper.HexString(
						Convert.ToUInt16(Wrapper.vdata.GetValue(4, i))
					);
					item.SubItems.Add(name);
					name = Helper.HexString(
						Convert.ToUInt16(Wrapper.vdata.GetValue(5, i))
					);
					item.SubItems.Add(name);
					name = Helper.HexString(
						Convert.ToUInt16(Wrapper.vdata.GetValue(6, i))
					);
					item.SubItems.Add(name);
					name = Helper.HexString(
						Convert.ToUInt16(Wrapper.vdata.GetValue(7, i))
					);
					item.SubItems.Add(name);
					name = Helper.HexString(
						Convert.ToUInt16(Wrapper.vdata.GetValue(8, i))
					);
					item.SubItems.Add(name);
					name = Helper.HexString(
						Convert.ToUInt16(Wrapper.vdata.GetValue(9, i))
					);
					item.SubItems.Add(name);
					item.Tag = i;
					listList.Items.Add(item);
				}
			}
			ClearEditer();
		}

		private void listList_SelectedIndexChanged(object sender, EventArgs e)
		{
			holde = true;
			if (listList.SelectedItems.Count == 0)
			{
				ClearEditer();
				holde = false;
				return;
			}
			ListViewItem lvi = listList.SelectedItems[0];
			tbComment.Text = lvi.SubItems[0].Text;
			textBox2.Text = lvi.SubItems[1].Text;
			textBox3.Text = lvi.SubItems[2].Text;
			textBox4.Text = lvi.SubItems[3].Text;
			textBox5.Text = lvi.SubItems[4].Text;
			textBox6.Text = lvi.SubItems[5].Text;
			textBox7.Text = lvi.SubItems[6].Text;
			textBox8.Text = lvi.SubItems[7].Text;
			textBox9.Text = lvi.SubItems[8].Text;
			textBox10.Text = lvi.SubItems[9].Text;
			textBox11.Text = lvi.SubItems[10].Text;
			taskBox1.HeaderText = "Editer - Line " + Convert.ToString((int)lvi.Tag);
			holde = false;
		}

		private void listLast_SelectedIndexChanged(object sender, EventArgs e)
		{
			holde = true;
			if (listLast.SelectedItems.Count == 0)
			{
				ClearEditer();
				holde = false;
				return;
			}
			ListViewItem lvi = listLast.SelectedItems[0];
			tbComment2.ReadOnly = false;
			tbComment2.Text = lvi.SubItems[1].Text;
			taskBox2.HeaderText = "Editer - Line " + Convert.ToString((int)lvi.Tag);
			btDown.Enabled = (int)lvi.Tag < listLast.Items.Count - 1;
			btMove.Enabled = (int)lvi.Tag > 0;
			holde = false;
		}

		private void textbox_TextChanged(object sender, EventArgs e)
		{
			if (holde)
			{
				return;
			}

			if (listList.SelectedItems.Count == 0)
			{
				return;
			}

			ListViewItem lvi = listList.SelectedItems[0];
			int indx = (int)lvi.Tag;
			lvi.SubItems[0].Text = tbComment.Text;
			lvi.SubItems[1].Text = textBox2.Text;
			lvi.SubItems[2].Text = textBox3.Text;
			lvi.SubItems[3].Text = textBox4.Text;
			lvi.SubItems[4].Text = textBox5.Text;
			lvi.SubItems[5].Text = textBox6.Text;
			lvi.SubItems[6].Text = textBox7.Text;
			lvi.SubItems[7].Text = textBox8.Text;
			lvi.SubItems[8].Text = textBox9.Text;
			lvi.SubItems[9].Text = textBox10.Text;
			lvi.SubItems[10].Text = textBox11.Text;

			Wrapper.Items[indx] = tbComment.Text;
			Wrapper.vdata.SetValue(
				(uint)Helper.StringToUInt32(textBox2.Text, 0, 16),
				0,
				indx
			);
			Wrapper.vdata.SetValue(
				(uint)Helper.StringToUInt32(textBox3.Text, 0, 16),
				1,
				indx
			);
			Wrapper.vdata.SetValue(
				(uint)Helper.StringToUInt32(textBox4.Text, 0, 16),
				2,
				indx
			);
			Wrapper.vdata.SetValue(
				(uint)Helper.StringToUInt32(textBox5.Text, 0, 16),
				3,
				indx
			);
			Wrapper.vdata.SetValue(
				(uint)Helper.StringToUInt32(textBox6.Text, 0, 16),
				4,
				indx
			);
			Wrapper.vdata.SetValue(
				(uint)Helper.StringToUInt32(textBox7.Text, 0, 16),
				5,
				indx
			);
			Wrapper.vdata.SetValue(
				(uint)Helper.StringToUInt32(textBox8.Text, 0, 16),
				6,
				indx
			);
			Wrapper.vdata.SetValue(
				(uint)Helper.StringToUInt32(textBox9.Text, 0, 16),
				7,
				indx
			);
			Wrapper.vdata.SetValue(
				(uint)Helper.StringToUInt32(textBox10.Text, 0, 16),
				8,
				indx
			);
			Wrapper.vdata.SetValue(
				(uint)Helper.StringToUInt32(textBox11.Text, 0, 16),
				9,
				indx
			);
		}

		private void textbox2_TextChanged(object sender, EventArgs e)
		{
			if (holde)
			{
				return;
			}

			if (listLast.SelectedItems.Count == 0)
			{
				return;
			}

			ListViewItem lvi = listLast.SelectedItems[0];
			int indx = (int)lvi.Tag;
			lvi.SubItems[1].Text = tbComment2.Text;
			Wrapper.Items[indx] = tbComment2.Text;
		}

		private void tbfilename_TextChanged(object sender, EventArgs e)
		{
			if (!holde)
			{
				Wrapper.FileNam = tbfilename.Text;
			}
		}

		private void btAdder_Click(object sender, EventArgs e)
		{
			holde = true;
			Wrapper.AddBlock();
			fillimupList();
			tbcount.Text = Convert.ToString(Wrapper.Count);
			holde = false;
		}

		private void btRemove_Click(object sender, EventArgs e)
		{
			holde = true;
			Wrapper.DeleteBlock();
			fillimupList();
			tbcount.Text = Convert.ToString(Wrapper.Count);
			holde = false;
		}

		private void btMove_Click(object sender, EventArgs e)
		{
			holde = true;
			if (Wrapper.Vershin == 69)
			{
				if (listLast.SelectedItems.Count == 0)
				{
					return;
				}

				ListViewItem lvi = listLast.SelectedItems[0];
				int indx = (int)lvi.Tag;
				Wrapper.MoveComment(indx, indx - 1);
				fillimupList();
				indx--;
				if (indx >= 0)
				{
					lvi = listLast.Items[indx];
					lvi.Focused = true;
					listLast.FocusedItem.Selected = true;
				}
			}
			else
			{
				if (listList.SelectedItems.Count == 0)
				{
					return;
				}

				ListViewItem lvi = listList.SelectedItems[0];
				int indx = (int)lvi.Tag;
				Wrapper.MoveComment(indx, indx - 1);
				fillimupList();
			}
			holde = false;
		}

		private void btBhave_Click(object sender, EventArgs e)
		{
			PackedFiles.Wrapper.Bhav bhave = (PackedFiles.Wrapper.Bhav)
				Wrapper.SiblingResource(0x42484156);
			if (bhave == null)
			{
				return;
			}

			if (bhave.Package != Wrapper.Package)
			{
				return;
			}

			RemoteControl.OpenPackedFile(bhave.FileDescriptor, bhave.Package);
		}

		private void btDown_Click(object sender, EventArgs e)
		{
			holde = true;
			if (Wrapper.Vershin == 69)
			{
				if (listLast.SelectedItems.Count == 0)
				{
					return;
				}

				ListViewItem lvi = listLast.SelectedItems[0];
				int indx = (int)lvi.Tag;
				Wrapper.MoveComment(indx, indx + 1);
				fillimupList();
				indx++;
				if (indx < listLast.Items.Count)
				{
					lvi = listLast.Items[indx];
					lvi.Focused = true;
					listLast.FocusedItem.Selected = true;
				}
			}
			else
			{
				if (listList.SelectedItems.Count == 0)
				{
					return;
				}

				ListViewItem lvi = listList.SelectedItems[0];
				int indx = (int)lvi.Tag;
				Wrapper.MoveComment(indx, indx + 1);
				fillimupList();
			}
			holde = false;
		}

		private void ClearEditer()
		{
			btDown.Enabled = btMove.Enabled = false;
			tbComment2.Text =
				tbComment.Text =
				textBox2.Text =
				textBox3.Text =
				textBox4.Text =
				textBox5.Text =
					"";
			textBox6.Text =
				textBox7.Text =
				textBox8.Text =
				textBox9.Text =
				textBox10.Text =
				textBox11.Text =
					"";
			taskBox2.HeaderText = taskBox1.HeaderText = "Editer";
			tbComment2.ReadOnly = true;
		}
	}
}
