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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces;
using SimPe.PackedFiles.Wrapper.Supporting;
using SimPe.Data;
using SimPe;
using Ambertation.Windows.Forms;
// using Ambertation.Windows.Forms;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for ExtSrelUI.
	/// </summary>
	public class CommonSrel : System.Windows.Forms.UserControl
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
				ControlStyles.SupportsTransparentBackColor |
				ControlStyles.AllPaintingInWmPaint |
				//ControlStyles.Opaque |
				ControlStyles.UserPaint |
				ControlStyles.ResizeRedraw 
				| ControlStyles.DoubleBuffer
				,true);

			InitComboBox();

            ltcb = new List<CheckBox>(new CheckBox[] {
                cbcrush, cblove, cbengaged, cbmarried, cbfriend, cbbuddie, cbsteady, cbenemy,
                null, null, null, null, null, null, cbfamily, cbbest,
                cbBFF, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null,
            });
        }

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommonSrel));
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label91 = new System.Windows.Forms.Label();
            this.cbfamtype = new System.Windows.Forms.ComboBox();
            this.pbDay = new ExtProgressBar();
            this.pbLife = new ExtProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbcrush = new System.Windows.Forms.CheckBox();
            this.cbfriend = new System.Windows.Forms.CheckBox();
            this.cbsteady = new System.Windows.Forms.CheckBox();
            this.cblove = new System.Windows.Forms.CheckBox();
            this.cbbuddie = new System.Windows.Forms.CheckBox();
            this.cbfamily = new System.Windows.Forms.CheckBox();
            this.cbengaged = new System.Windows.Forms.CheckBox();
            this.cbbest = new System.Windows.Forms.CheckBox();
            this.cbenemy = new System.Windows.Forms.CheckBox();
            this.cbmarried = new System.Windows.Forms.CheckBox();
            this.cbBFF = new System.Windows.Forms.CheckBox();
            this.tbRel = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Controls.Add(this.pbDay);
            this.flowLayoutPanel2.Controls.Add(this.pbLife);
            this.flowLayoutPanel2.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.label91);
            this.flowLayoutPanel1.Controls.Add(this.cbfamtype);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // label91
            // 
            resources.ApplyResources(this.label91, "label91");
            this.label91.Name = "label91";
            // 
            // cbfamtype
            // 
            resources.ApplyResources(this.cbfamtype, "cbfamtype");
            this.cbfamtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfamtype.Name = "cbfamtype";
            this.cbfamtype.SelectedIndexChanged += new System.EventHandler(this.ChangedRelation);
            // 
            // pbDay
            // 
            resources.ApplyResources(this.pbDay, "pbDay");
            this.pbDay.BackColor = System.Drawing.Color.Transparent;
            this.pbDay.Maximum = 200;
            this.pbDay.Name = "pbDay";
            this.pbDay.SelectedColor = System.Drawing.Color.Lime;
            this.pbDay.TokenCount = 30;
            this.pbDay.UnselectedColor = System.Drawing.Color.Black;
            this.pbDay.Value = 90;
            // 
            // pbLife
            // 
            resources.ApplyResources(this.pbLife, "pbLife");
            this.pbLife.BackColor = System.Drawing.Color.Transparent;
            this.pbLife.Maximum = 200;
            this.pbLife.Name = "pbLife";
            this.pbLife.SelectedColor = System.Drawing.Color.Lime;
            this.pbLife.TokenCount = 30;
            this.pbLife.UnselectedColor = System.Drawing.Color.Black;
            this.pbLife.Value = 90;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.cbcrush, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbfriend, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbsteady, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cblove, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbbuddie, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbfamily, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbengaged, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbbest, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbenemy, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbmarried, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbBFF, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbRel, 3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // cbcrush
            // 
            resources.ApplyResources(this.cbcrush, "cbcrush");
            this.cbcrush.Name = "cbcrush";
            this.cbcrush.UseVisualStyleBackColor = false;
            this.cbcrush.CheckedChanged += new System.EventHandler(this.ChangedState);
            // 
            // cbfriend
            // 
            resources.ApplyResources(this.cbfriend, "cbfriend");
            this.cbfriend.Name = "cbfriend";
            this.cbfriend.UseVisualStyleBackColor = false;
            this.cbfriend.CheckedChanged += new System.EventHandler(this.ChangedState);
            // 
            // cbsteady
            // 
            resources.ApplyResources(this.cbsteady, "cbsteady");
            this.cbsteady.Name = "cbsteady";
            this.cbsteady.UseVisualStyleBackColor = false;
            this.cbsteady.CheckedChanged += new System.EventHandler(this.ChangedState);
            // 
            // cblove
            // 
            resources.ApplyResources(this.cblove, "cblove");
            this.cblove.Name = "cblove";
            this.cblove.UseVisualStyleBackColor = false;
            this.cblove.CheckedChanged += new System.EventHandler(this.ChangedState);
            // 
            // cbbuddie
            // 
            resources.ApplyResources(this.cbbuddie, "cbbuddie");
            this.cbbuddie.Name = "cbbuddie";
            this.cbbuddie.UseVisualStyleBackColor = false;
            this.cbbuddie.CheckedChanged += new System.EventHandler(this.ChangedState);
            // 
            // cbfamily
            // 
            resources.ApplyResources(this.cbfamily, "cbfamily");
            this.cbfamily.Name = "cbfamily";
            this.cbfamily.UseVisualStyleBackColor = false;
            this.cbfamily.CheckedChanged += new System.EventHandler(this.ChangedState);
            // 
            // cbengaged
            // 
            resources.ApplyResources(this.cbengaged, "cbengaged");
            this.cbengaged.Name = "cbengaged";
            this.cbengaged.UseVisualStyleBackColor = false;
            this.cbengaged.CheckedChanged += new System.EventHandler(this.ChangedState);
            // 
            // cbbest
            // 
            resources.ApplyResources(this.cbbest, "cbbest");
            this.cbbest.Name = "cbbest";
            this.cbbest.UseVisualStyleBackColor = false;
            this.cbbest.CheckedChanged += new System.EventHandler(this.ChangedState);
            // 
            // cbenemy
            // 
            resources.ApplyResources(this.cbenemy, "cbenemy");
            this.cbenemy.Name = "cbenemy";
            this.cbenemy.UseVisualStyleBackColor = false;
            this.cbenemy.CheckedChanged += new System.EventHandler(this.ChangedState);
            // 
            // cbmarried
            // 
            resources.ApplyResources(this.cbmarried, "cbmarried");
            this.cbmarried.Name = "cbmarried";
            this.cbmarried.UseVisualStyleBackColor = false;
            this.cbmarried.CheckedChanged += new System.EventHandler(this.ChangedState);
            // 
            // cbBFF
            // 
            resources.ApplyResources(this.cbBFF, "cbBFF");
            this.cbBFF.Name = "cbBFF";
            this.cbBFF.UseVisualStyleBackColor = false;
            this.cbBFF.CheckedChanged += new System.EventHandler(this.ChangedState);
            // 
            // tbRel
            // 
            this.tbRel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tbRel, "tbRel");
            this.tbRel.Name = "tbRel";
            this.tbRel.TextChanged += new System.EventHandler(this.ChangedRelationText);
            // 
            // CommonSrel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "CommonSrel";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


        SimPe.PackedFiles.Wrapper.ExtSrel srel;
		public SimPe.PackedFiles.Wrapper.ExtSrel Srel
		{
			get {return srel;}
			set 
			{
				srel = value;
				UpdateContent();
			}
		}

		public event EventHandler ChangedContent;
		protected void InitComboBox()
		{
			this.cbfamtype.Items.Clear();
			this.cbfamtype.Items.Add(new LocalizedRelationshipTypes(Data.MetaData.RelationshipTypes.Unset_Unknown));
			this.cbfamtype.Items.Add(new LocalizedRelationshipTypes(Data.MetaData.RelationshipTypes.Aunt));
			this.cbfamtype.Items.Add(new LocalizedRelationshipTypes(Data.MetaData.RelationshipTypes.Child));
			this.cbfamtype.Items.Add(new LocalizedRelationshipTypes(Data.MetaData.RelationshipTypes.Cousin));
			this.cbfamtype.Items.Add(new LocalizedRelationshipTypes(Data.MetaData.RelationshipTypes.Grandchild));
			this.cbfamtype.Items.Add(new LocalizedRelationshipTypes(Data.MetaData.RelationshipTypes.Gradparent));
			this.cbfamtype.Items.Add(new LocalizedRelationshipTypes(Data.MetaData.RelationshipTypes.Nice_Nephew));
			this.cbfamtype.Items.Add(new LocalizedRelationshipTypes(Data.MetaData.RelationshipTypes.Parent));
			this.cbfamtype.Items.Add(new LocalizedRelationshipTypes(Data.MetaData.RelationshipTypes.Sibling));
			this.cbfamtype.Items.Add(new LocalizedRelationshipTypes(Data.MetaData.RelationshipTypes.Spouses));
		}

		bool intern;
        List<CheckBox> ltcb;

        protected void UpdateContent()
        {
            if (Srel == null)
            {
                intern = true;
                this.pbDay.Value = this.pbLife.Value = 0;
                this.pbDay.SelectedColor = this.pbLife.SelectedColor = Color.Lime;
                this.cbfamtype.SelectedIndex = 0;
                this.Enabled = false;
                return;
            }
            this.Enabled = true;
            intern = true;
            this.pbDay.Value = Srel.Shortterm;
            this.pbLife.Value = Srel.Longterm;
            Boolset bs = Srel.RelationState.Value;
            for (int i = 0; i < bs.Length; i++) if (ltcb[i] != null) ltcb[i].Checked = bs[i];
            if (Srel.RelationState2 != null)
            {
                bs = Srel.RelationState2.Value;
                for (int i = 0; i < bs.Length; i++) if (ltcb[i + 16] != null)
                    {
                        ltcb[i + 16].Enabled = true;
                        ltcb[i + 16].Checked = bs[i];
                    }
            }
            else
                for (int i = 0; i < bs.Length; i++) if (ltcb[i + 16] != null) ltcb[i + 16].Enabled = false;

            this.cbfamtype.SelectedIndex = 0;
            for (int i = 1; i < this.cbfamtype.Items.Count; i++)
                if (this.cbfamtype.Items[i] == new Data.LocalizedRelationshipTypes(srel.FamilyRelation))
                {
                    this.cbfamtype.SelectedIndex = i;
                    break;
                }

            this.tbRel.Text = "0x" + Helper.HexString((uint)srel.FamilyRelation);

            if (this.cblove.Checked)
            {
                if (pbLife.Value > 90)
                    pbLife.SelectedColor = Color.HotPink;
                if (pbDay.Value > 90)
                    pbDay.SelectedColor = Color.HotPink;
            }
            else
            {
                if (pbLife.Value > 90)
                    pbLife.SelectedColor = Color.Lime;
                if (pbDay.Value > 90)
                    pbDay.SelectedColor = Color.Lime;
            }
            intern = false;

            if (ChangedContent != null) ChangedContent(this, new EventArgs());
        }

		private void ChangedLife(object sender, System.EventArgs e)
		{
			if (pbLife.Value<0) 
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
                            pbLife.SelectedColor = Color.HotPink;
                    }
                    else
                    {
                        if (pbLife.SelectedColor != Color.Lime)
                            pbLife.SelectedColor = Color.Lime;
                    }
                /*
                    if (pbLife.SelectedColor != Color.Lime)                    
				{					
					pbLife.SelectedColor = Color.Lime;
					pbLife.CompleteRedraw();
				}*/
			}

			if (intern) return;
			Srel.Longterm = pbLife.Value;
			Srel.Changed = true;
		}

		private void ChangedDay(object sender, System.EventArgs e)
		{
            if (pbDay.Value < 0)
            {
                if (pbDay.SelectedColor != Color.OrangeRed)
                    pbDay.SelectedColor = Color.OrangeRed;
            }
            else
            {
                if (cblove.Checked && pbDay.Value > 90)
                {
                    if (pbDay.SelectedColor != Color.HotPink)
                        pbDay.SelectedColor = Color.HotPink;
                }
                else
                {
                    if (pbDay.SelectedColor != Color.Lime)
                        pbDay.SelectedColor = Color.Lime;
                }
            }

			if (intern) return;
			Srel.Shortterm = pbDay.Value;
			Srel.Changed = true;
		}

        private void ChangedRelation(object sender, System.EventArgs e)
        {
            if (intern) return;
            if (this.cbfamtype.SelectedIndex >= 0)
                this.tbRel.Text = "0x" + Helper.HexString((uint)((Data.MetaData.RelationshipTypes)((Data.LocalizedRelationshipTypes)cbfamtype.SelectedItem)));
        }

		private void ChangedRelationText(object sender, System.EventArgs e)
		{
			if (intern) return;
			Srel.FamilyRelation = (Data.LocalizedRelationshipTypes)Helper.StringToUInt32(this.tbRel.Text, (uint)Srel.FamilyRelation, 16);
			Srel.Changed = true;
		}

        private void ChangedState(object sender, System.EventArgs e)
        {
            if (intern) return;

            int i = ltcb.IndexOf((CheckBox)sender);
            if (i >= 0)
            {
                Boolset val = (i < 16) ? Srel.RelationState.Value : Srel.RelationState2.Value;
                val[i & 0x0f] = ((CheckBox)sender).Checked;
                if (i < 16) Srel.RelationState.Value = val;
                else Srel.RelationState2.Value = val;
                Srel.Changed = true;
            }

            if (this.cblove.Checked)
            {
                if (pbLife.Value > 90)
                {
                    if (pbLife.SelectedColor != Color.HotPink)
                        pbLife.SelectedColor = Color.HotPink;
                }
                if (pbDay.Value > 90)
                {
                    if (pbDay.SelectedColor != Color.HotPink)
                        pbDay.SelectedColor = Color.HotPink;
                }
            }
            else                
            {
                if (pbLife.Value > 90)
                {
                    if (pbLife.SelectedColor != Color.Lime)
                        pbLife.SelectedColor = Color.Lime;
                }
                if (pbDay.Value > 90)
                {
                    if (pbDay.SelectedColor != Color.Lime)
                        pbDay.SelectedColor = Color.Lime;
                }
            }
        }

		public SimPe.PackedFiles.Wrapper.ExtSDesc SourceSim
		{
			get { 
				if (Srel==null) return null;
				return Srel.SourceSim; 
			}
		}

		public SimPe.PackedFiles.Wrapper.ExtSDesc TargetSim
		{
			get { 
				if (Srel==null) return null;
				return Srel.TargetSim; 
			}
		}

		
		public string SourceSimName
		{
			get { 
				if (Srel==null) return SimPe.Localization.GetString("Unknown");
				return Srel.SourceSimName; 
			}
		}

		public string TargetSimName
		{
			get { 
				if (Srel==null) return SimPe.Localization.GetString("Unknown");
				return Srel.TargetSimName; 
			}
		}

		public Image Image
		{
			get { 
				if (Srel==null) return null;
				return Srel.Image;
			}
		}
	}
}
