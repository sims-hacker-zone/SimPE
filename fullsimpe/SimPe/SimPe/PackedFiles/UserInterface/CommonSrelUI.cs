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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Ambertation.Windows.Forms;

using SimPe.Data;

// using Ambertation.Windows.Forms;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for ExtSrelUI.
	/// </summary>
	public class CommonSrel : UserControl
	{
		#region Form fields
		private FlowLayoutPanel flowLayoutPanel2;
		private FlowLayoutPanel flowLayoutPanel1;
		private Label label91;
		private ComboBox cbfamtype;
		private TextBox tbRel;
		private ExtProgressBar pbDay;
		private ExtProgressBar pbLife;
		private TableLayoutPanel tableLayoutPanel1;
		private CheckBox cblove;
		private CheckBox cbcrush;
		private CheckBox cbengaged;
		private CheckBox cbmarried;
		private CheckBox cbbuddie;
		private CheckBox cbfriend;
		private CheckBox cbsteady;
		private CheckBox cbenemy;
		private CheckBox cbfamily;
		private CheckBox cbbest;
		private CheckBox cbBFF;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion


		public CommonSrel()
		{
			// Required designer variable.
			InitializeComponent();

			SetStyle(
				ControlStyles.SupportsTransparentBackColor
					| ControlStyles.AllPaintingInWmPaint
					|
					//ControlStyles.Opaque |
					ControlStyles.UserPaint
					| ControlStyles.ResizeRedraw
					| ControlStyles.DoubleBuffer,
				true
			);

			InitComboBox();

			ltcb = new List<CheckBox>(
				new CheckBox[]
				{
					cbcrush,
					cblove,
					cbengaged,
					cbmarried,
					cbfriend,
					cbbuddie,
					cbsteady,
					cbenemy,
					null,
					null,
					null,
					null,
					null,
					null,
					cbfamily,
					cbbest,
					cbBFF,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
				}
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
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(CommonSrel));
			flowLayoutPanel2 = new FlowLayoutPanel();
			flowLayoutPanel1 = new FlowLayoutPanel();
			label91 = new Label();
			cbfamtype = new ComboBox();
			pbDay = new ExtProgressBar();
			pbLife = new ExtProgressBar();
			tableLayoutPanel1 = new TableLayoutPanel();
			cbcrush = new CheckBox();
			cbfriend = new CheckBox();
			cbsteady = new CheckBox();
			cblove = new CheckBox();
			cbbuddie = new CheckBox();
			cbfamily = new CheckBox();
			cbengaged = new CheckBox();
			cbbest = new CheckBox();
			cbenemy = new CheckBox();
			cbmarried = new CheckBox();
			cbBFF = new CheckBox();
			tbRel = new TextBox();
			flowLayoutPanel2.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			//
			// flowLayoutPanel2
			//
			resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
			flowLayoutPanel2.Controls.Add(flowLayoutPanel1);
			flowLayoutPanel2.Controls.Add(pbDay);
			flowLayoutPanel2.Controls.Add(pbLife);
			flowLayoutPanel2.Controls.Add(tableLayoutPanel1);
			flowLayoutPanel2.Name = "flowLayoutPanel2";
			//
			// flowLayoutPanel1
			//
			resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
			flowLayoutPanel1.Controls.Add(label91);
			flowLayoutPanel1.Controls.Add(cbfamtype);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			//
			// label91
			//
			resources.ApplyResources(label91, "label91");
			label91.Name = "label91";
			//
			// cbfamtype
			//
			resources.ApplyResources(cbfamtype, "cbfamtype");
			cbfamtype.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbfamtype.Name = "cbfamtype";
			cbfamtype.SelectedIndexChanged += new EventHandler(
				ChangedRelation
			);
			//
			// pbDay
			//
			resources.ApplyResources(pbDay, "pbDay");
			pbDay.BackColor = Color.Transparent;
			pbDay.Maximum = 200;
			pbDay.Name = "pbDay";
			pbDay.SelectedColor = Color.Lime;
			pbDay.TokenCount = 30;
			pbDay.UnselectedColor = Color.Black;
			pbDay.Value = 90;
			//
			// pbLife
			//
			resources.ApplyResources(pbLife, "pbLife");
			pbLife.BackColor = Color.Transparent;
			pbLife.Maximum = 200;
			pbLife.Name = "pbLife";
			pbLife.SelectedColor = Color.Lime;
			pbLife.TokenCount = 30;
			pbLife.UnselectedColor = Color.Black;
			pbLife.Value = 90;
			//
			// tableLayoutPanel1
			//
			resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
			tableLayoutPanel1.Controls.Add(cbcrush, 0, 0);
			tableLayoutPanel1.Controls.Add(cbfriend, 0, 1);
			tableLayoutPanel1.Controls.Add(cbsteady, 0, 2);
			tableLayoutPanel1.Controls.Add(cblove, 1, 0);
			tableLayoutPanel1.Controls.Add(cbbuddie, 1, 1);
			tableLayoutPanel1.Controls.Add(cbfamily, 1, 2);
			tableLayoutPanel1.Controls.Add(cbengaged, 2, 0);
			tableLayoutPanel1.Controls.Add(cbbest, 2, 1);
			tableLayoutPanel1.Controls.Add(cbenemy, 2, 2);
			tableLayoutPanel1.Controls.Add(cbmarried, 3, 0);
			tableLayoutPanel1.Controls.Add(cbBFF, 3, 1);
			tableLayoutPanel1.Controls.Add(tbRel, 3, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			//
			// cbcrush
			//
			resources.ApplyResources(cbcrush, "cbcrush");
			cbcrush.Name = "cbcrush";
			cbcrush.UseVisualStyleBackColor = false;
			cbcrush.CheckedChanged += new EventHandler(ChangedState);
			//
			// cbfriend
			//
			resources.ApplyResources(cbfriend, "cbfriend");
			cbfriend.Name = "cbfriend";
			cbfriend.UseVisualStyleBackColor = false;
			cbfriend.CheckedChanged += new EventHandler(ChangedState);
			//
			// cbsteady
			//
			resources.ApplyResources(cbsteady, "cbsteady");
			cbsteady.Name = "cbsteady";
			cbsteady.UseVisualStyleBackColor = false;
			cbsteady.CheckedChanged += new EventHandler(ChangedState);
			//
			// cblove
			//
			resources.ApplyResources(cblove, "cblove");
			cblove.Name = "cblove";
			cblove.UseVisualStyleBackColor = false;
			cblove.CheckedChanged += new EventHandler(ChangedState);
			//
			// cbbuddie
			//
			resources.ApplyResources(cbbuddie, "cbbuddie");
			cbbuddie.Name = "cbbuddie";
			cbbuddie.UseVisualStyleBackColor = false;
			cbbuddie.CheckedChanged += new EventHandler(ChangedState);
			//
			// cbfamily
			//
			resources.ApplyResources(cbfamily, "cbfamily");
			cbfamily.Name = "cbfamily";
			cbfamily.UseVisualStyleBackColor = false;
			cbfamily.CheckedChanged += new EventHandler(ChangedState);
			//
			// cbengaged
			//
			resources.ApplyResources(cbengaged, "cbengaged");
			cbengaged.Name = "cbengaged";
			cbengaged.UseVisualStyleBackColor = false;
			cbengaged.CheckedChanged += new EventHandler(ChangedState);
			//
			// cbbest
			//
			resources.ApplyResources(cbbest, "cbbest");
			cbbest.Name = "cbbest";
			cbbest.UseVisualStyleBackColor = false;
			cbbest.CheckedChanged += new EventHandler(ChangedState);
			//
			// cbenemy
			//
			resources.ApplyResources(cbenemy, "cbenemy");
			cbenemy.Name = "cbenemy";
			cbenemy.UseVisualStyleBackColor = false;
			cbenemy.CheckedChanged += new EventHandler(ChangedState);
			//
			// cbmarried
			//
			resources.ApplyResources(cbmarried, "cbmarried");
			cbmarried.Name = "cbmarried";
			cbmarried.UseVisualStyleBackColor = false;
			cbmarried.CheckedChanged += new EventHandler(ChangedState);
			//
			// cbBFF
			//
			resources.ApplyResources(cbBFF, "cbBFF");
			cbBFF.Name = "cbBFF";
			cbBFF.UseVisualStyleBackColor = false;
			cbBFF.CheckedChanged += new EventHandler(ChangedState);
			//
			// tbRel
			//
			tbRel.BorderStyle = BorderStyle.None;
			resources.ApplyResources(tbRel, "tbRel");
			tbRel.Name = "tbRel";
			tbRel.TextChanged += new EventHandler(ChangedRelationText);
			//
			// CommonSrel
			//
			AutoScaleMode = AutoScaleMode.Inherit;
			resources.ApplyResources(this, "$this");
			Controls.Add(flowLayoutPanel2);
			Name = "CommonSrel";
			flowLayoutPanel2.ResumeLayout(false);
			flowLayoutPanel2.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion


		Wrapper.ExtSrel srel;
		public Wrapper.ExtSrel Srel
		{
			get
			{
				return srel;
			}
			set
			{
				srel = value;
				UpdateContent();
			}
		}

		public event EventHandler ChangedContent;

		protected void InitComboBox()
		{
			cbfamtype.Items.Clear();
			cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(
					MetaData.RelationshipTypes.Unset_Unknown
				)
			);
			cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(MetaData.RelationshipTypes.Aunt)
			);
			cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(MetaData.RelationshipTypes.Child)
			);
			cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(MetaData.RelationshipTypes.Cousin)
			);
			cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(
					MetaData.RelationshipTypes.Grandchild
				)
			);
			cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(
					MetaData.RelationshipTypes.Gradparent
				)
			);
			cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(
					MetaData.RelationshipTypes.Nice_Nephew
				)
			);
			cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(MetaData.RelationshipTypes.Parent)
			);
			cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(MetaData.RelationshipTypes.Sibling)
			);
			cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(MetaData.RelationshipTypes.Spouses)
			);
		}

		bool intern;
		List<CheckBox> ltcb;

		protected void UpdateContent()
		{
			if (Srel == null)
			{
				intern = true;
				pbDay.Value = pbLife.Value = 0;
				pbDay.SelectedColor = pbLife.SelectedColor = Color.Lime;
				cbfamtype.SelectedIndex = 0;
				Enabled = false;
				return;
			}
			Enabled = true;
			intern = true;
			pbDay.Value = Srel.Shortterm;
			pbLife.Value = Srel.Longterm;
			Boolset bs = Srel.RelationState.Value;
			for (int i = 0; i < bs.Length; i++)
			{
				if (ltcb[i] != null)
				{
					ltcb[i].Checked = bs[i];
				}
			}

			if (Srel.RelationState2 != null)
			{
				bs = Srel.RelationState2.Value;
				for (int i = 0; i < bs.Length; i++)
				{
					if (ltcb[i + 16] != null)
					{
						ltcb[i + 16].Enabled = true;
						ltcb[i + 16].Checked = bs[i];
					}
				}
			}
			else
			{
				for (int i = 0; i < bs.Length; i++)
				{
					if (ltcb[i + 16] != null)
					{
						ltcb[i + 16].Enabled = false;
					}
				}
			}

			cbfamtype.SelectedIndex = 0;
			for (int i = 1; i < cbfamtype.Items.Count; i++)
			{
				if (
					cbfamtype.Items[i]
					== new LocalizedRelationshipTypes(srel.FamilyRelation)
				)
				{
					cbfamtype.SelectedIndex = i;
					break;
				}
			}

			tbRel.Text = "0x" + Helper.HexString((uint)srel.FamilyRelation);

			if (cblove.Checked)
			{
				if (pbLife.Value > 90)
				{
					pbLife.SelectedColor = Color.HotPink;
				}

				if (pbDay.Value > 90)
				{
					pbDay.SelectedColor = Color.HotPink;
				}
			}
			else
			{
				if (pbLife.Value > 90)
				{
					pbLife.SelectedColor = Color.Lime;
				}

				if (pbDay.Value > 90)
				{
					pbDay.SelectedColor = Color.Lime;
				}
			}
			intern = false;

			if (ChangedContent != null)
			{
				ChangedContent(this, new EventArgs());
			}
		}

		private void ChangedLife(object sender, EventArgs e)
		{
			if (pbLife.Value < 0)
			{
				if (pbLife.SelectedColor != Color.OrangeRed)
				{
					pbLife.SelectedColor = Color.OrangeRed;
					// pbLife.CompleteRedraw();
				}
			}
			else
			{
				if (cblove.Checked && pbLife.Value > 90)
				{
					if (pbLife.SelectedColor != Color.HotPink)
					{
						pbLife.SelectedColor = Color.HotPink;
					}
				}
				else
				{
					if (pbLife.SelectedColor != Color.Lime)
					{
						pbLife.SelectedColor = Color.Lime;
					}
				}
				/*
					if (pbLife.SelectedColor != Color.Lime)
				{
					pbLife.SelectedColor = Color.Lime;
					pbLife.CompleteRedraw();
				}*/
			}

			if (intern)
			{
				return;
			}

			Srel.Longterm = pbLife.Value;
			Srel.Changed = true;
		}

		private void ChangedDay(object sender, EventArgs e)
		{
			if (pbDay.Value < 0)
			{
				if (pbDay.SelectedColor != Color.OrangeRed)
				{
					pbDay.SelectedColor = Color.OrangeRed;
				}
			}
			else
			{
				if (cblove.Checked && pbDay.Value > 90)
				{
					if (pbDay.SelectedColor != Color.HotPink)
					{
						pbDay.SelectedColor = Color.HotPink;
					}
				}
				else
				{
					if (pbDay.SelectedColor != Color.Lime)
					{
						pbDay.SelectedColor = Color.Lime;
					}
				}
			}

			if (intern)
			{
				return;
			}

			Srel.Shortterm = pbDay.Value;
			Srel.Changed = true;
		}

		private void ChangedRelation(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			if (cbfamtype.SelectedIndex >= 0)
			{
				tbRel.Text =
					"0x"
					+ Helper.HexString(
						(uint)(
							(MetaData.RelationshipTypes)(
								(LocalizedRelationshipTypes)cbfamtype.SelectedItem
							)
						)
					);
			}
		}

		private void ChangedRelationText(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			Srel.FamilyRelation = (LocalizedRelationshipTypes)
				Helper.StringToUInt32(tbRel.Text, (uint)Srel.FamilyRelation, 16);
			Srel.Changed = true;
		}

		private void ChangedState(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			int i = ltcb.IndexOf((CheckBox)sender);
			if (i >= 0)
			{
				Boolset val =
					(i < 16) ? Srel.RelationState.Value : Srel.RelationState2.Value;
				val[i & 0x0f] = ((CheckBox)sender).Checked;
				if (i < 16)
				{
					Srel.RelationState.Value = val;
				}
				else
				{
					Srel.RelationState2.Value = val;
				}

				Srel.Changed = true;
			}

			if (cblove.Checked)
			{
				if (pbLife.Value > 90)
				{
					if (pbLife.SelectedColor != Color.HotPink)
					{
						pbLife.SelectedColor = Color.HotPink;
					}
				}
				if (pbDay.Value > 90)
				{
					if (pbDay.SelectedColor != Color.HotPink)
					{
						pbDay.SelectedColor = Color.HotPink;
					}
				}
			}
			else
			{
				if (pbLife.Value > 90)
				{
					if (pbLife.SelectedColor != Color.Lime)
					{
						pbLife.SelectedColor = Color.Lime;
					}
				}
				if (pbDay.Value > 90)
				{
					if (pbDay.SelectedColor != Color.Lime)
					{
						pbDay.SelectedColor = Color.Lime;
					}
				}
			}
		}

		public Wrapper.ExtSDesc SourceSim
		{
			get
			{
				if (Srel == null)
				{
					return null;
				}

				return Srel.SourceSim;
			}
		}

		public Wrapper.ExtSDesc TargetSim
		{
			get
			{
				if (Srel == null)
				{
					return null;
				}

				return Srel.TargetSim;
			}
		}

		public string SourceSimName
		{
			get
			{
				if (Srel == null)
				{
					return Localization.GetString("Unknown");
				}

				return Srel.SourceSimName;
			}
		}

		public string TargetSimName
		{
			get
			{
				if (Srel == null)
				{
					return Localization.GetString("Unknown");
				}

				return Srel.TargetSimName;
			}
		}

		public Image Image
		{
			get
			{
				if (Srel == null)
				{
					return null;
				}

				return Srel.Image;
			}
		}
	}
}
