/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
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
 *   59 Temple Place - Suite 330, Boston, MA  32111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x001b
{
    /// <summary>
    /// Summary description for StrBig.
    /// </summary>
    internal class UI : System.Windows.Forms.Form, iBhavOperandWizForm
	{
		#region Form variables

        internal System.Windows.Forms.Panel pnWiz0x001b;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox gbLocation;
        private ComboBox cbLocation;
        private GroupBox gbDirection;
        private ComboBox cbDirection;
        private CheckBox ckbNoFailureTrees;
        private CheckBox ckbDifferentAltitudes;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public UI()
		{
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            cbLocation.Items.AddRange(BhavWiz.readStr(GS.BhavStr.RelativeLocations).ToArray());
            cbDirection.Items.AddRange(BhavWiz.readStr(GS.BhavStr.RelativeDirections).ToArray());
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );

			inst = null;
		}


		private Instruction inst = null;
        //private bool internalchg = false;

        #region iBhavOperandWizForm
        public Panel WizPanel { get { return this.pnWiz0x001b; } }

        public void Execute(Instruction inst)
        {
            this.inst = inst;

            wrappedByteArray ops1 = inst.Operands;
            wrappedByteArray ops2 = inst.Reserved1;
            Boolset ops16 = ops1[6];

            //internalchg = true;

            cbLocation.SelectedIndex = ((byte)(ops1[2] + 2) < cbLocation.Items.Count) ? (byte)(ops1[2] + 2) : -1;
            cbDirection.SelectedIndex = ((byte)(ops1[3] + 2) < cbDirection.Items.Count) ? (byte)(ops1[3] + 2) : -1;

            ckbNoFailureTrees.Checked = ops16[1];
            ckbDifferentAltitudes.Checked = ops16[2];

            //internalchg = false;
        }

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
                wrappedByteArray ops1 = inst.Operands;
                wrappedByteArray ops2 = inst.Reserved1;
                Boolset ops16 = ops1[6];

                if (cbLocation.SelectedIndex >= 0) ops1[2] = ((byte)(cbLocation.SelectedIndex - 2));
                if (cbDirection.SelectedIndex >= 0) ops1[3] = ((byte)(cbDirection.SelectedIndex - 2));

                ops16[1] = ckbNoFailureTrees.Checked;
                ops16[2] = ckbDifferentAltitudes.Checked;
                ops1[6] = ops16;

            }
			return inst;
		}

		#endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            this.pnWiz0x001b = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbLocation = new System.Windows.Forms.GroupBox();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.gbDirection = new System.Windows.Forms.GroupBox();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.ckbNoFailureTrees = new System.Windows.Forms.CheckBox();
            this.ckbDifferentAltitudes = new System.Windows.Forms.CheckBox();
            this.pnWiz0x001b.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbLocation.SuspendLayout();
            this.gbDirection.SuspendLayout();
            this.SuspendLayout();
            //
            // pnWiz0x001b
            //
            resources.ApplyResources(this.pnWiz0x001b, "pnWiz0x001b");
            this.pnWiz0x001b.Controls.Add(this.flowLayoutPanel1);
            this.pnWiz0x001b.Name = "pnWiz0x001b";
            //
            // flowLayoutPanel1
            //
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.gbLocation);
            this.flowLayoutPanel1.Controls.Add(this.gbDirection);
            this.flowLayoutPanel1.Controls.Add(this.ckbNoFailureTrees);
            this.flowLayoutPanel1.Controls.Add(this.ckbDifferentAltitudes);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            //
            // gbLocation
            //
            resources.ApplyResources(this.gbLocation, "gbLocation");
            this.gbLocation.Controls.Add(this.cbLocation);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.TabStop = false;
            //
            // cbLocation
            //
            this.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocation.FormattingEnabled = true;
            resources.ApplyResources(this.cbLocation, "cbLocation");
            this.cbLocation.Name = "cbLocation";
            //
            // gbDirection
            //
            resources.ApplyResources(this.gbDirection, "gbDirection");
            this.gbDirection.Controls.Add(this.cbDirection);
            this.gbDirection.Name = "gbDirection";
            this.gbDirection.TabStop = false;
            //
            // cbDirection
            //
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirection.FormattingEnabled = true;
            resources.ApplyResources(this.cbDirection, "cbDirection");
            this.cbDirection.Name = "cbDirection";
            //
            // ckbNoFailureTrees
            //
            resources.ApplyResources(this.ckbNoFailureTrees, "ckbNoFailureTrees");
            this.ckbNoFailureTrees.Name = "ckbNoFailureTrees";
            this.ckbNoFailureTrees.UseVisualStyleBackColor = true;
            //
            // ckbDifferentAltitudes
            //
            resources.ApplyResources(this.ckbDifferentAltitudes, "ckbDifferentAltitudes");
            this.ckbDifferentAltitudes.Name = "ckbDifferentAltitudes";
            this.ckbDifferentAltitudes.UseVisualStyleBackColor = true;
            //
            // UI
            //
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pnWiz0x001b);
            this.Name = "UI";
            this.pnWiz0x001b.ResumeLayout(false);
            this.pnWiz0x001b.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.gbLocation.ResumeLayout(false);
            this.gbDirection.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


    }

}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x001b : pjse.ABhavOperandWiz
	{
        public BhavOperandWiz0x001b(Instruction i) : base(i) { myForm = new Wiz0x001b.UI(); }

		#region IDisposable Members
		public override void Dispose()
		{
			if (myForm != null) myForm = null;
		}
		#endregion

	}

}
