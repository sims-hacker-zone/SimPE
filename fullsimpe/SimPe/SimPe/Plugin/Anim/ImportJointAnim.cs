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
using System.Windows.Forms;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// Summary description for ImportJointAnim.
	/// </summary>
	public class ImportJointAnim : Form
	{
		private Panel Gradientpanel1;
		private Button button1;
		private ListView lv;
		private Label label1;
		private ColumnHeader chName;
		private ColumnHeader chAction;
		private ColumnHeader chTarget;
		private ColumnHeader chCount;
		private GroupBox gbgroups;
		private ComboBox cbnames;
		private Label label2;
		private Label label3;
		private Label lbname;
		private ComboBox cbaction;
		private CheckBox cbDiscard;
		private ColumnHeader chDuration;
		private ColumnHeader chDiscardZero;
		private CheckBox cbRemove;
		private GroupBox gbsettings;
		private CheckBox cbCorrect;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ImportJointAnim()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			cbaction.Items.Add(AnimImporterAction.Nothing);
			cbaction.Items.Add(AnimImporterAction.Add);
			cbaction.Items.Add(AnimImporterAction.Replace);
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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(ImportJointAnim)
				);
			Gradientpanel1 = new Panel();
			gbsettings = new GroupBox();
			cbCorrect = new CheckBox();
			gbgroups = new GroupBox();
			cbRemove = new CheckBox();
			cbDiscard = new CheckBox();
			cbnames = new ComboBox();
			label2 = new Label();
			label3 = new Label();
			lbname = new Label();
			cbaction = new ComboBox();
			button1 = new Button();
			lv = new ListView();
			chName = new ColumnHeader();
			chAction = new ColumnHeader();
			chTarget = new ColumnHeader();
			chCount = new ColumnHeader();
			chDuration = new ColumnHeader();
			chDiscardZero = new ColumnHeader();
			label1 = new Label();
			Gradientpanel1.SuspendLayout();
			gbsettings.SuspendLayout();
			gbgroups.SuspendLayout();
			SuspendLayout();
			//
			// Gradientpanel1
			//
			Gradientpanel1.BackColor = System.Drawing.Color.Transparent;
			Gradientpanel1.Controls.Add(gbsettings);
			Gradientpanel1.Controls.Add(gbgroups);
			Gradientpanel1.Controls.Add(button1);
			Gradientpanel1.Controls.Add(lv);
			Gradientpanel1.Controls.Add(label1);
			Gradientpanel1.Dock = DockStyle.Fill;
			Gradientpanel1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Gradientpanel1.Location = new System.Drawing.Point(0, 0);
			Gradientpanel1.Name = "Gradientpanel1";
			Gradientpanel1.Size = new System.Drawing.Size(824, 438);
			Gradientpanel1.TabIndex = 13;
			//
			// gbsettings
			//
			gbsettings.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			gbsettings.BackColor = System.Drawing.Color.Transparent;
			gbsettings.Controls.Add(cbCorrect);
			gbsettings.Location = new System.Drawing.Point(536, 16);
			gbsettings.Name = "gbsettings";
			gbsettings.Padding = new Padding(4, 44, 4, 4);
			gbsettings.Size = new System.Drawing.Size(280, 72);
			gbsettings.TabIndex = 15;
			//
			// cbCorrect
			//
			cbCorrect.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbCorrect.Location = new System.Drawing.Point(16, 40);
			cbCorrect.Name = "cbCorrect";
			cbCorrect.Size = new System.Drawing.Size(256, 24);
			cbCorrect.TabIndex = 0;
			cbCorrect.Text = "auskel Joint correction (by Pinhead)";
			//
			// gbgroups
			//
			gbgroups.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			gbgroups.BackColor = System.Drawing.Color.Transparent;
			gbgroups.Controls.Add(cbRemove);
			gbgroups.Controls.Add(cbDiscard);
			gbgroups.Controls.Add(cbnames);
			gbgroups.Controls.Add(label2);
			gbgroups.Controls.Add(label3);
			gbgroups.Controls.Add(lbname);
			gbgroups.Controls.Add(cbaction);
			gbgroups.Enabled = false;
			gbgroups.Location = new System.Drawing.Point(536, 88);
			gbgroups.Name = "gbgroups";
			gbgroups.Padding = new Padding(4, 44, 4, 4);
			gbgroups.Size = new System.Drawing.Size(280, 168);
			gbgroups.TabIndex = 14;
			//
			// cbRemove
			//
			cbRemove.Checked = true;
			cbRemove.CheckState = CheckState.Checked;
			cbRemove.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbRemove.Location = new System.Drawing.Point(112, 84);
			cbRemove.Name = "cbRemove";
			cbRemove.Size = new System.Drawing.Size(160, 24);
			cbRemove.TabIndex = 7;
			cbRemove.Text = "Remove unneeded Frames";
			cbRemove.CheckedChanged += new System.EventHandler(
				cbRemove_CheckedChanged
			);
			//
			// cbDiscard
			//
			cbDiscard.Checked = true;
			cbDiscard.CheckState = CheckState.Checked;
			cbDiscard.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbDiscard.Location = new System.Drawing.Point(112, 64);
			cbDiscard.Name = "cbDiscard";
			cbDiscard.Size = new System.Drawing.Size(128, 24);
			cbDiscard.TabIndex = 6;
			cbDiscard.Text = "Discard Keyframe 0";
			cbDiscard.CheckedChanged += new System.EventHandler(
				cbDiscard_CheckedChanged
			);
			//
			// cbnames
			//
			cbnames.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbnames.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbnames.Location = new System.Drawing.Point(112, 136);
			cbnames.Name = "cbnames";
			cbnames.Size = new System.Drawing.Size(160, 21);
			cbnames.TabIndex = 5;
			cbnames.Visible = false;
			cbnames.SelectedIndexChanged += new System.EventHandler(
				cbnames_SelectedIndexChanged
			);
			//
			// label2
			//
			label2.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(16, 40);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(88, 23);
			label2.TabIndex = 0;
			label2.Text = "Joint Name:";
			label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label3
			//
			label3.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label3.Location = new System.Drawing.Point(16, 112);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(88, 23);
			label3.TabIndex = 1;
			label3.Text = "Action:";
			label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// lbname
			//
			lbname.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbname.Location = new System.Drawing.Point(112, 40);
			lbname.Name = "lbname";
			lbname.Size = new System.Drawing.Size(160, 23);
			lbname.TabIndex = 2;
			lbname.Text = "---";
			lbname.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// cbaction
			//
			cbaction.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbaction.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbaction.Location = new System.Drawing.Point(112, 112);
			cbaction.Name = "cbaction";
			cbaction.Size = new System.Drawing.Size(160, 21);
			cbaction.TabIndex = 3;
			cbaction.SelectedIndexChanged += new System.EventHandler(
				cbaction_SelectedIndexChanged
			);
			//
			// button1
			//
			button1.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			button1.FlatStyle = FlatStyle.System;
			button1.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			button1.Location = new System.Drawing.Point(739, 406);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(80, 27);
			button1.TabIndex = 3;
			button1.Text = "OK";
			button1.Click += new System.EventHandler(button1_Click);
			//
			// lv
			//
			lv.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lv.BorderStyle = BorderStyle.None;
			lv.Columns.AddRange(
				new ColumnHeader[]
				{
					chName,
					chAction,
					chTarget,
					chCount,
					chDuration,
					chDiscardZero,
				}
			);
			lv.FullRowSelect = true;
			lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			lv.HideSelection = false;
			lv.Location = new System.Drawing.Point(8, 32);
			lv.Name = "lv";
			lv.Size = new System.Drawing.Size(520, 400);
			lv.TabIndex = 0;
			lv.UseCompatibleStateImageBehavior = false;
			lv.View = View.Details;
			lv.SelectedIndexChanged += new System.EventHandler(
				lv_SelectedIndexChanged
			);
			//
			// chName
			//
			chName.Text = "Name";
			chName.Width = 150;
			//
			// chAction
			//
			chAction.Text = "Action";
			chAction.Width = 69;
			//
			// chTarget
			//
			chTarget.Text = "Target";
			chTarget.Width = 118;
			//
			// chCount
			//
			chCount.Text = "Frames";
			chCount.TextAlign = HorizontalAlignment.Right;
			//
			// chDuration
			//
			chDuration.Text = "Duration";
			chDuration.Width = 66;
			//
			// chDiscardZero
			//
			chDiscardZero.Text = "Zero";
			chDiscardZero.Width = 50;
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
			label1.Location = new System.Drawing.Point(8, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(176, 23);
			label1.TabIndex = 1;
			label1.Text = "Importable Joints:";
			//
			// ImportJointAnim
			//
			AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			ClientSize = new System.Drawing.Size(824, 438);
			Controls.Add(Gradientpanel1);
			Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			Name = "ImportJointAnim";
			Text = "Import Animation";
			Gradientpanel1.ResumeLayout(false);
			gbsettings.ResumeLayout(false);
			gbgroups.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		public static bool Execute(ImportedFrameBlocks amb, GeometryDataContainer gmdc)
		{
			ImportJointAnim f = new ImportJointAnim();
			f.cbCorrect.Checked = amb.AuskelCorrection;
			f.ok = false;
			f.cbnames.Items.Clear();
			foreach (AnimationFrameBlock afb in gmdc.LinkedAnimation.Part2)
			{
				f.cbnames.Items.Add(afb);
			}

			f.lv.Items.Clear();
			foreach (ImportedFrameBlock ifb in amb)
			{
				ListViewItem lvi = new ListViewItem
				{
					Text = ifb.ImportedName
				};
				lvi.SubItems.Add(ifb.Action.ToString());
				if (ifb.Target != null)
				{
					lvi.SubItems.Add(ifb.Target.ToString());
				}
				else
				{
					lvi.SubItems.Add("---");
				}

				lvi.SubItems.Add(ifb.FrameBlock.FrameCount.ToString());
				lvi.SubItems.Add(ifb.FrameBlock.GetDuration().ToString());
				if (ifb.DiscardZeroFrame)
				{
					lvi.SubItems.Add("no");
				}
				else
				{
					lvi.SubItems.Add("yes");
				}

				lvi.ForeColor = ifb.MarkColor;
				lvi.Tag = ifb;

				if (ifb.Target != null)
				{
					f.lv.Items.Insert(0, lvi);
				}
				else
				{
					f.lv.Items.Add(lvi);
				}
			}
			f.ShowDialog();

			amb.AuskelCorrection = f.cbCorrect.Checked;
			return f.ok;
		}

		private void lv_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			gbgroups.Enabled = false;
			if (lv.SelectedItems.Count > 0)
			{
				object o = lv.SelectedItems[0].Tag;
				if (o is ImportedFrameBlock)
				{
					SelectJoint();
				}
			}
		}

		/// <summary>
		/// A Bone was selected
		/// </summary>
		void SelectJoint()
		{
			gbgroups.Enabled = true;
			Tag = true;
			try
			{
				ImportedFrameBlock a = (ImportedFrameBlock)lv.SelectedItems[0].Tag;

				cbDiscard.Checked = a.DiscardZeroFrame;
				cbRemove.Checked = a.RemoveUnneeded;

				cbaction.SelectedIndex = 0;
				for (int i = 0; i < cbaction.Items.Count; i++)
				{
					AnimImporterAction ea = (AnimImporterAction)cbaction.Items[i];
					if (ea == a.Action)
					{
						cbaction.SelectedIndex = i;
						break;
					}
				}
				lbname.Text = a.ImportedName;

				cbnames.SelectedIndex = -1;
				if (a.Target != null)
				{
					for (int i = 0; i < cbnames.Items.Count; i++)
					{
						AnimationFrameBlock afb = (AnimationFrameBlock)cbnames.Items[i];
						if (afb == a.Target)
						{
							cbnames.SelectedIndex = i;
							break;
						}
					}
				}
			}
			finally
			{
				Tag = null;
			}
		}

		private void cbaction_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cbnames.Visible =
				((AnimImporterAction)cbaction.SelectedItem)
				== AnimImporterAction.Replace;
			if (Tag != null)
			{
				return;
			}

			for (int i = 0; i < lv.SelectedItems.Count; i++)
			{
				ImportedFrameBlock a = (ImportedFrameBlock)lv.SelectedItems[i].Tag;
				a.Action = (AnimImporterAction)cbaction.SelectedItem;
				lv.SelectedItems[i].SubItems[1].Text = a.Action.ToString();
				lv.SelectedItems[i].ForeColor = a.MarkColor;
			}
		}

		private void cbnames_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			for (int i = 0; i < lv.SelectedItems.Count; i++)
			{
				ImportedFrameBlock a = (ImportedFrameBlock)lv.SelectedItems[i].Tag;
				a.Target = (AnimationFrameBlock)cbnames.SelectedItem;
				lv.SelectedItems[i].SubItems[2].Text = a.Target.ToString();
				lv.SelectedItems[i].ForeColor = a.MarkColor;
			}
		}

		private void cbDiscard_CheckedChanged(object sender, System.EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			for (int i = 0; i < lv.SelectedItems.Count; i++)
			{
				ImportedFrameBlock a = (ImportedFrameBlock)lv.SelectedItems[i].Tag;
				a.DiscardZeroFrame = cbDiscard.Checked;
				if (a.DiscardZeroFrame)
				{
					lv.SelectedItems[i].SubItems[5].Text = "no";
				}
				else
				{
					lv.SelectedItems[i].SubItems[5].Text = "yes";
				}

				lv.SelectedItems[i].ForeColor = a.MarkColor;
			}
		}

		bool ok;

		private void button1_Click(object sender, System.EventArgs e)
		{
			ok = true;
			Close();
		}

		private void cbRemove_CheckedChanged(object sender, System.EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			for (int i = 0; i < lv.SelectedItems.Count; i++)
			{
				ImportedFrameBlock a = (ImportedFrameBlock)lv.SelectedItems[i].Tag;
				a.RemoveUnneeded = cbRemove.Checked;
			}
		}
	}
}
