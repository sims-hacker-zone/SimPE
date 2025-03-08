// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Ambertation.Drawing;
using Ambertation.Scenes;
using Ambertation.Scenes.Collections;

namespace Ambertation.Graphics
{
	public class RenderSelection : UserControl
	{
		private IContainer components;

		private ListBox lb;

		private Scene scn;

		private SceneToMesh stm;

		private DirectXPanel dx;

		public Scene Scene
		{
			get
			{
				return scn;
			}
			set
			{
				scn = value;
				SetContent();
			}
		}

		public DirectXPanel DirectXPanel
		{
			get
			{
				return dx;
			}
			set
			{
				if (dx != null)
				{
					dx.ResetDevice -= dx_ResetDevice;
				}

				dx = value;
				if (dx != null)
				{
					dx.ResetDevice += dx_ResetDevice;
				}

				SetContent();
			}
		}

		protected override void Dispose(bool disposing)
		{
			dx = null;
			scn = null;
			if (stm != null)
			{
				stm.Dispose();
			}

			stm = null;
			if (disposing && components != null)
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.lb = new System.Windows.Forms.ListBox();
			base.SuspendLayout();
			this.lb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lb.IntegralHeight = false;
			this.lb.Location = new System.Drawing.Point(0, 0);
			this.lb.Name = "lb";
			this.lb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lb.Size = new System.Drawing.Size(172, 329);
			this.lb.TabIndex = 0;
			this.lb.SelectedIndexChanged += new System.EventHandler(lb_SelectedIndexChanged);
			base.Controls.Add(this.lb);
			base.Name = "RenderSelection";
			base.Size = new System.Drawing.Size(172, 329);
			base.ResumeLayout(false);
		}

		public RenderSelection()
		{
			InitializeComponent();
			lb.DrawMode = DrawMode.OwnerDrawVariable;
			lb.DrawItem += DrawItemHandler;
			lb.MeasureItem += MeasureItemHandler;
		}

		private void dx_ResetDevice(object sender, EventArgs e)
		{
			if (!(sender is DirectXPanel directXPanel))
			{
				return;
			}

			try
			{
				directXPanel.Meshes.Clear(dispose: true);
				if (lb.SelectedItem == null)
				{
					directXPanel.Meshes.AddRange(stm.ConvertToDx());
				}
				else if (!(lb.SelectedItem is Joint))
				{
					directXPanel.Meshes.AddRange(stm.ConvertToDx());
				}
				else if (lb.SelectedItems.Count == 1)
				{
					directXPanel.Meshes.AddRange(stm.ConvertToDx(lb.SelectedItem as Joint));
				}
				else
				{
					JointCollection jointCollection = new JointCollection();
					foreach (object selectedItem in lb.SelectedItems)
					{
						if (selectedItem is Joint)
						{
							jointCollection.Add(selectedItem as Joint);
						}
					}

					directXPanel.Meshes.AddRange(stm.ConvertToDx(jointCollection));
				}

				if (stm != null)
				{
				}
			}
			catch
			{
			}
		}

		private void SetContent()
		{
			lb.Items.Clear();
			stm = null;
			if (scn == null || dx == null)
			{
				return;
			}

			stm = new SceneToMesh(scn, dx);
			dx.Reset();
			dx.ResetDefaultViewport();
			lb.Items.Add("--- [Display Mesh] ---");
			foreach (Joint item in scn.JointCollection)
			{
				lb.Items.Add(item);
			}
		}

		private void lb_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (dx != null)
			{
				dx.Reset();
			}
		}

		private void DrawItemHandler(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			if (e.Index < lb.Items.Count && e.Index >= 0)
			{
				object obj = lb.Items[e.Index];
				Color foreColor = lb.ForeColor;
				if (obj is Joint)
				{
					e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
					e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
					e.Graphics.InterpolationMode = InterpolationMode.High;
					Joint j = obj as Joint;
					foreColor = stm.GetJointColor(j);
					Routines.FillRoundRect(e.Graphics, new SolidBrush(foreColor), new Rectangle(e.Bounds.Left + 3, e.Bounds.Top + 2, e.Bounds.Width - 6, e.Bounds.Height - 5), e.Bounds.Height / 3);
					e.Graphics.FillEllipse(new SolidBrush(foreColor), new Rectangle(e.Bounds.Left + 1, e.Bounds.Top, e.Bounds.Height + 4, e.Bounds.Height - 1));
					e.Graphics.DrawString(obj.ToString(), new Font(lb.Font.FontFamily, lb.Font.Size, FontStyle.Bold, lb.Font.Unit), new SolidBrush(Color.Black), new Rectangle(e.Bounds.Left + e.Bounds.Height + 4, e.Bounds.Top + 3, e.Bounds.Width - e.Bounds.Height - 5, e.Bounds.Height - 4));
				}
				else
				{
					e.Graphics.DrawString(obj.ToString(), lb.Font, new SolidBrush(foreColor), new Rectangle(e.Bounds.Left + 3, e.Bounds.Top + 4, e.Bounds.Width - 6, e.Bounds.Height - 4));
				}
			}
		}

		private void MeasureItemHandler(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight += 8;
		}
	}
}
