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
using System.Drawing;

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

			lbMin.Left = muiW / 6 - lbMin.Width / 2;
			lbDelta.Left = muiW / 2 - lbDelta.Width / 2;
			lbType.Left = (5 * muiW) / 6 - lbType.Width / 2;
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
			get => gbMotiveGroup.Text;
			set => gbMotiveGroup.Text = value;
		}

		private ArrayList tops = new ArrayList();
		public int[] Tops => (int[])tops.ToArray(typeof(Int32));
		#endregion

		#region TtabMotiveGroupUI

		public TtabItemMotiveGroup MotiveGroup
		{
			get => item;
			set
			{
				if (item != value)
				{
					if (item != null)
					{
						item.Wrapper.WrapperChanged -= new EventHandler(
							WrapperChanged
						);
					}

					item = value;
					setData();
					if (item != null)
					{
						item.Wrapper.WrapperChanged += new EventHandler(
							WrapperChanged
						);
					}
				}
			}
		}

		private void WrapperChanged(object sender, EventArgs e)
		{
			if (sender != item)
			{
				return;
			}

			setData();
		}

		private void setData()
		{
			SuspendLayout();

			gbMotiveGroup.Controls.Clear();
			tops = new ArrayList();

			int nextTop = lbMin.Bottom + 2;
			int width = Width;

			if (item != null)
			{
				if (item.Parent.Type == TtabItemMotiveTableType.Human)
				{
					gbMotiveGroup.Controls.Add(lbMin);
					gbMotiveGroup.Controls.Add(lbDelta);
					gbMotiveGroup.Controls.Add(lbType);

					for (int i = 0; i < item.Count; i++)
					{
						TtabSingleMotiveUI c = new TtabSingleMotiveUI
						{
							Motive = (TtabItemSingleMotiveItem)item[i]
						};

						gbMotiveGroup.Controls.Add(c);
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
						TtabAnimalMotiveUI c = new TtabAnimalMotiveUI
						{
							Motive = (TtabItemAnimalMotiveItem)item[i]
						};

						gbMotiveGroup.Controls.Add(c);
						c.Location = new Point(2, nextTop);
						tops.Add(nextTop);
						nextTop += c.Height + 2;
						width = c.Width;
					}
				}
			}

			Width = 2 + width + 2;
			gbMotiveGroup.Controls.Add(btnClear);
			btnClear.Location = new Point(
				(Width - btnClear.Width) / 2,
				nextTop + 2
			);
			Height = btnClear.Bottom + 4;

			ResumeLayout();
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
			gbMotiveGroup = new System.Windows.Forms.GroupBox();
			btnClear = new System.Windows.Forms.Button();
			lbMin = new System.Windows.Forms.Label();
			lbDelta = new System.Windows.Forms.Label();
			lbType = new System.Windows.Forms.Label();
			gbMotiveGroup.SuspendLayout();
			SuspendLayout();
			//
			// gbMotiveGroup
			//
			gbMotiveGroup.Controls.Add(btnClear);
			gbMotiveGroup.Controls.Add(lbMin);
			gbMotiveGroup.Controls.Add(lbDelta);
			gbMotiveGroup.Controls.Add(lbType);
			resources.ApplyResources(gbMotiveGroup, "gbMotiveGroup");
			gbMotiveGroup.Name = "gbMotiveGroup";
			gbMotiveGroup.TabStop = false;
			//
			// btnClear
			//
			btnClear.BackColor = Color.Transparent;
			resources.ApplyResources(btnClear, "btnClear");
			btnClear.Name = "btnClear";
			btnClear.UseVisualStyleBackColor = false;
			btnClear.Click += new EventHandler(btnClear_Click);
			//
			// lbMin
			//
			resources.ApplyResources(lbMin, "lbMin");
			lbMin.Name = "lbMin";
			//
			// lbDelta
			//
			resources.ApplyResources(lbDelta, "lbDelta");
			lbDelta.Name = "lbDelta";
			//
			// lbType
			//
			resources.ApplyResources(lbType, "lbType");
			lbType.Name = "lbType";
			//
			// TtabMotiveGroupUI
			//
			Controls.Add(gbMotiveGroup);
			Name = "TtabMotiveGroupUI";
			resources.ApplyResources(this, "$this");
			gbMotiveGroup.ResumeLayout(false);
			gbMotiveGroup.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		private void btnClear_Click(object sender, EventArgs e)
		{
			item.Clear();
		}
	}

	#region MotiveClickEvent
	public class MotiveClickEventArgs : EventArgs
	{
		public MotiveClickEventArgs(int m)
			: base()
		{
			Motive = m;
		}

		public int Motive
		{
			get;
		}
	}

	public delegate void MotiveClickEventHandler(object sender, MotiveClickEventArgs e);
	#endregion
}
