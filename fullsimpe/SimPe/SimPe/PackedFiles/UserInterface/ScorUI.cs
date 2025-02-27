/***************************************************************************
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
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for ScorUI.
	/// </summary>
	public class ScorUI
		:
		//System.Windows.Forms.UserControl
		Windows.Forms.WrapperBaseControl,
			Interfaces.Plugin.IPackedFileUI
	{
		private Label label1;
		private TextBox tbunk1;
		private TextBox tbunk2;
		private Label label2;
		private ListBox lb;
		private Panel pnContainer;
		private Button btAdd;
		private Button btRem;
		private ComboBox cbType;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ScorUI()
		{
			// Required designer variable.
			InitializeComponent();
			btAdd.Enabled = false;
			btRem.Enabled = false;
			UpdateTypeSelector();

			Text = "Sim Scores";
			Commited += new EventHandler(ScorUI_Commited);
			CanCommit = Helper.WindowsRegistry.HiddenMode;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label1 = new Label();
			tbunk1 = new TextBox();
			tbunk2 = new TextBox();
			label2 = new Label();
			lb = new ListBox();
			pnContainer = new Panel();
			cbType = new ComboBox();
			btAdd = new Button();
			btRem = new Button();
			SuspendLayout();
			//
			// label1
			//
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(8, 40);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(80, 23);
			label1.TabIndex = 0;
			label1.Text = "Unknown 1:";
			label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbunk1
			//
			tbunk1.Location = new System.Drawing.Point(96, 40);
			tbunk1.Name = "tbunk1";
			tbunk1.ReadOnly = true;
			tbunk1.Size = new System.Drawing.Size(141, 21);
			tbunk1.TabIndex = 1;
			//
			// tbunk2
			//
			tbunk2.Location = new System.Drawing.Point(96, 64);
			tbunk2.Name = "tbunk2";
			tbunk2.ReadOnly = true;
			tbunk2.Size = new System.Drawing.Size(141, 21);
			tbunk2.TabIndex = 3;
			//
			// label2
			//
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(8, 64);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(80, 23);
			label2.TabIndex = 2;
			label2.Text = "Unknown 2:";
			label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// lb
			//
			lb.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			lb.BorderStyle = BorderStyle.None;
			lb.HorizontalScrollbar = true;
			lb.IntegralHeight = false;
			lb.Location = new System.Drawing.Point(8, 96);
			lb.Name = "lb";
			lb.Size = new System.Drawing.Size(229, 104);
			lb.TabIndex = 4;
			lb.SelectedIndexChanged += new EventHandler(
				lb_SelectedIndexChanged
			);
			//
			// pnContainer
			//
			pnContainer.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			pnContainer.Location = new System.Drawing.Point(243, 40);
			pnContainer.Name = "pnContainer";
			pnContainer.Size = new System.Drawing.Size(431, 228);
			pnContainer.TabIndex = 5;
			//
			// cbType
			//
			cbType.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			cbType.DropDownStyle = ComboBoxStyle.DropDownList;
			cbType.FormattingEnabled = true;
			cbType.Location = new System.Drawing.Point(11, 217);
			cbType.Name = "cbType";
			cbType.Size = new System.Drawing.Size(157, 21);
			cbType.TabIndex = 6;
			cbType.SelectedIndexChanged += new EventHandler(
				comboBox1_SelectedIndexChanged
			);
			//
			// btAdd
			//
			btAdd.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			btAdd.Location = new System.Drawing.Point(174, 216);
			btAdd.Name = "btAdd";
			btAdd.Size = new System.Drawing.Size(63, 23);
			btAdd.TabIndex = 7;
			btAdd.Text = "Add";
			btAdd.UseVisualStyleBackColor = true;
			btAdd.Click += new EventHandler(btAdd_Click);
			//
			// btRem
			//
			btRem.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			btRem.Location = new System.Drawing.Point(174, 245);
			btRem.Name = "btRem";
			btRem.Size = new System.Drawing.Size(63, 23);
			btRem.TabIndex = 8;
			btRem.Text = "Remove";
			btRem.UseVisualStyleBackColor = true;
			btRem.Click += new EventHandler(btRem_Click);
			//
			// ScorUI
			//
			Controls.Add(btRem);
			Controls.Add(btAdd);
			Controls.Add(cbType);
			Controls.Add(lb);
			Controls.Add(pnContainer);
			Controls.Add(tbunk2);
			Controls.Add(label2);
			Controls.Add(tbunk1);
			Controls.Add(label1);
			Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Name = "ScorUI";
			Size = new System.Drawing.Size(678, 272);
			Controls.SetChildIndex(label1, 0);
			Controls.SetChildIndex(tbunk1, 0);
			Controls.SetChildIndex(label2, 0);
			Controls.SetChildIndex(tbunk2, 0);
			Controls.SetChildIndex(pnContainer, 0);
			Controls.SetChildIndex(lb, 0);
			Controls.SetChildIndex(cbType, 0);
			Controls.SetChildIndex(btAdd, 0);
			Controls.SetChildIndex(btRem, 0);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		#region IPackedFileUI Member

		protected override void OnWrapperChanged(
			WrapperChangedEventArgs e
		)
		{
			if (e.OldWrapper != null)
			{
				(e.OldWrapper as Scor).AddedItem -= new Scor.ChangedListHandler(
					ScorUI_AddedItem
				);
				(e.OldWrapper as Scor).RemovedItem -= new Scor.ChangedListHandler(
					ScorUI_RemovedItem
				);
			}
			if (e.NewWrapper != null)
			{
				(e.NewWrapper as Scor).AddedItem += new Scor.ChangedListHandler(
					ScorUI_AddedItem
				);
				(e.NewWrapper as Scor).RemovedItem += new Scor.ChangedListHandler(
					ScorUI_RemovedItem
				);
			}
		}

		void ScorUI_RemovedItem(Scor sender, Scor.ChangedListEventArgs e)
		{
			int index = Math.Max(0, lb.SelectedIndex);
			lb.Items.Remove(e.Item);
			index = Math.Min(lb.Items.Count - 1, index);
			if (lb.Items.Count > index)
			{
				lb.SelectedIndex = index;
			}
		}

		void ScorUI_AddedItem(Scor sender, Scor.ChangedListEventArgs e)
		{
			lb.Items.Add(e.Item);
			lb.SelectedIndex = lb.Items.Count - 1;
		}

		public Scor Scor => (Scor)Wrapper;

		protected override void RefreshGUI()
		{
			pnContainer.Controls.Clear();
			tbunk1.Text = Helper.HexString(Scor.Unknown1);
			tbunk2.Text = Helper.HexString(Scor.Unknown2);

			btRem.Enabled = false;
			lb.Items.Clear();
			foreach (ScorItem si in Scor)
			{
				lb.Items.Add(si);
			}

			if (lb.Items.Count > 0)
			{
				lb.SelectedIndex = 0;
			}
		}

		#endregion

		void UpdateTypeSelector()
		{
			cbType.Items.Clear();
			//if (Scor != null)
			{
				foreach (string s in ScorItem.GuiElements.Keys)
				{
					cbType.Items.Add(s);
				}

				if (cbType.Items.Count > 0)
				{
					cbType.SelectedIndex = 0;
				}
			}
		}

		private void ScorUI_Commited(object sender, EventArgs e)
		{
			Scor.SynchronizeUserData();
		}

		private void lb_SelectedIndexChanged(object sender, EventArgs e)
		{
			pnContainer.Controls.Clear();
			if (lb.SelectedItem is ScorItem si)
			{
				if (si.Gui != null)
				{
					pnContainer.Controls.Add(si.Gui);
					si.Gui.Dock = DockStyle.Fill;
				}
			}
			btRem.Enabled =
				lb.SelectedItem != null && Helper.WindowsRegistry.HiddenMode;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			btAdd.Enabled =
				cbType.SelectedItem != null && Helper.WindowsRegistry.HiddenMode;
		}

		private void btAdd_Click(object sender, EventArgs e)
		{
			if (Scor != null)
			{
				if (cbType.SelectedItem != null)
				{
					Scor.Add(cbType.SelectedItem.ToString());
				}
			}
		}

		private void btRem_Click(object sender, EventArgs e)
		{
			Scor?.Remove(lb.SelectedItem as ScorItem);
		}
	}
}
