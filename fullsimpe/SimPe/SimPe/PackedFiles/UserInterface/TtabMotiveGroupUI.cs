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
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for TtabMotiveGroupUI.
	/// </summary>
	public class TtabMotiveGroupUI : System.Windows.Forms.UserControl
	{
		#region Form variables
		private System.Windows.Forms.GroupBox gbMotiveGroup;
		private System.Windows.Forms.Label lbMin;
		private System.Windows.Forms.Label lbDelta;
		private System.Windows.Forms.Label lbType;
		private System.Windows.Forms.Button btnClear;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public TtabMotiveGroupUI()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

			int muiW,
				muiH;
			{
				TtabSingleMotiveUI c = new TtabSingleMotiveUI();
				muiW = c.Width;
				muiH = c.Height;
			}

			this.lbMin.Left = muiW / 6 - this.lbMin.Width / 2;
			this.lbDelta.Left = muiW / 2 - this.lbDelta.Width / 2;
			this.lbType.Left = (5 * muiW) / 6 - this.lbType.Width / 2;
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

		#region Extra attributes
		private TtabItemMotiveGroup item = null;
		public String MGName
		{
			get
			{
				return this.gbMotiveGroup.Text;
			}
			set
			{
				this.gbMotiveGroup.Text = value;
			}
		}

		private ArrayList tops = new ArrayList();
		public int[] Tops
		{
			get
			{
				return (int[])tops.ToArray(typeof(Int32));
			}
		}
		#endregion

		#region TtabMotiveGroupUI

		public TtabItemMotiveGroup MotiveGroup
		{
			get
			{
				return item;
			}
			set
			{
				if (this.item != value)
				{
					if (item != null)
						item.Wrapper.WrapperChanged -= new System.EventHandler(
							this.WrapperChanged
						);
					this.item = value;
					setData();
					if (item != null)
						item.Wrapper.WrapperChanged += new System.EventHandler(
							this.WrapperChanged
						);
				}
			}
		}

		private void WrapperChanged(object sender, System.EventArgs e)
		{
			if (sender != item)
				return;
			setData();
		}

		private void setData()
		{
			this.SuspendLayout();

			this.gbMotiveGroup.Controls.Clear();
			tops = new ArrayList();

			int nextTop = this.lbMin.Bottom + 2;
			int width = this.Width;

			if (item != null)
			{
				if (item.Parent.Type == TtabItemMotiveTableType.Human)
				{
					this.gbMotiveGroup.Controls.Add(this.lbMin);
					this.gbMotiveGroup.Controls.Add(this.lbDelta);
					this.gbMotiveGroup.Controls.Add(this.lbType);

					for (int i = 0; i < item.Count; i++)
					{
						TtabSingleMotiveUI c = new TtabSingleMotiveUI();
						c.Motive = (TtabItemSingleMotiveItem)item[i];

						this.gbMotiveGroup.Controls.Add(c);
						c.Location = new Point(2, nextTop);
						tops.Add(nextTop);
						nextTop += c.Height + 2;
						width = c.Width;
					}
				}
				else
				{
					for (int i = 0; i < item.Count; i++)
					{
						TtabAnimalMotiveUI c = new TtabAnimalMotiveUI();
						c.Motive = (TtabItemAnimalMotiveItem)item[i];

						this.gbMotiveGroup.Controls.Add(c);
						c.Location = new Point(2, nextTop);
						tops.Add(nextTop);
						nextTop += c.Height + 2;
						width = c.Width;
					}
				}
			}

			this.Width = 2 + width + 2;
			this.gbMotiveGroup.Controls.Add(this.btnClear);
			this.btnClear.Location = new Point(
				(this.Width - this.btnClear.Width) / 2,
				nextTop + 2
			);
			this.Height = this.btnClear.Bottom + 4;

			this.ResumeLayout();
		}

		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(TtabMotiveGroupUI)
				);
			this.gbMotiveGroup = new System.Windows.Forms.GroupBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.lbMin = new System.Windows.Forms.Label();
			this.lbDelta = new System.Windows.Forms.Label();
			this.lbType = new System.Windows.Forms.Label();
			this.gbMotiveGroup.SuspendLayout();
			this.SuspendLayout();
			//
			// gbMotiveGroup
			//
			this.gbMotiveGroup.Controls.Add(this.btnClear);
			this.gbMotiveGroup.Controls.Add(this.lbMin);
			this.gbMotiveGroup.Controls.Add(this.lbDelta);
			this.gbMotiveGroup.Controls.Add(this.lbType);
			resources.ApplyResources(this.gbMotiveGroup, "gbMotiveGroup");
			this.gbMotiveGroup.Name = "gbMotiveGroup";
			this.gbMotiveGroup.TabStop = false;
			//
			// btnClear
			//
			this.btnClear.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.btnClear, "btnClear");
			this.btnClear.Name = "btnClear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			//
			// lbMin
			//
			resources.ApplyResources(this.lbMin, "lbMin");
			this.lbMin.Name = "lbMin";
			//
			// lbDelta
			//
			resources.ApplyResources(this.lbDelta, "lbDelta");
			this.lbDelta.Name = "lbDelta";
			//
			// lbType
			//
			resources.ApplyResources(this.lbType, "lbType");
			this.lbType.Name = "lbType";
			//
			// TtabMotiveGroupUI
			//
			this.Controls.Add(this.gbMotiveGroup);
			this.Name = "TtabMotiveGroupUI";
			resources.ApplyResources(this, "$this");
			this.gbMotiveGroup.ResumeLayout(false);
			this.gbMotiveGroup.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			item.Clear();
		}
	}

	#region MotiveClickEvent
	public class MotiveClickEventArgs : System.EventArgs
	{
		private int motive;

		public MotiveClickEventArgs(int m)
			: base()
		{
			motive = m;
		}

		public int Motive
		{
			get
			{
				return motive;
			}
		}
	}

	public delegate void MotiveClickEventHandler(object sender, MotiveClickEventArgs e);
	#endregion
}
