// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms.Debug
{
	public class StructureTreeView : UserControl
	{
		private class MyLayerdForm : LayeredForm
		{
			public MyLayerdForm(Color cl)
				: base(cl, new Size(2048, 2048))
			{
			}

			protected override void OnCreateBitmap(System.Drawing.Graphics g, Bitmap bmp)
			{
				int num = Math.Max(bmp.Width, bmp.Height);
				int num2 = 20;
				Pen pen = new Pen(Color.White, 2f);
				for (int i = num2; i < 2 * num; i += num2)
				{
					g.DrawLine(pen, new Point(i, -5), new Point(-5, i));
				}

				pen = new Pen(Color.White, 5f);
				g.DrawRectangle(pen, 0, 0, bmp.Width - 1, bmp.Height - 1);
				pen = new Pen(Color.Black, 1f);
				g.DrawRectangle(pen, 0, 0, bmp.Width - 1, bmp.Height - 1);
			}
		}

		private class ContainerNode : TreeNode
		{
			private DockContainer dc;

			public DockContainer DockContainer => dc;

			public ContainerNode(DockContainer c)
			{
				dc = c;
				base.Text = string.Concat(c.Name, " (", c.GetType().Name, ") - ", c.Dock, " ", c.Visible, " ", c.Location, " ", c.Size);
			}
		}

		private class PanelNode : TreeNode
		{
			private DockPanel dp;

			public DockPanel DockPanel => dp;

			public PanelNode(DockPanel c)
			{
				dp = c;
				base.Text = string.Concat(c.TabText, ", ", c.CaptionText, ", ", c.Name, " (", c.GetType().Name, ") - ", c.Dock, " ", c.Visible, " ", c.Location, " ", c.Size);
			}
		}

		private class BarNode : TreeNode
		{
			private DockButtonBar dbb;

			public DockButtonBar DockButtonBar => dbb;

			public BarNode(DockButtonBar c)
			{
				dbb = c;
				base.Text = string.Concat(c.Name, " (", c.GetType().Name, ") - ", c.Dock, " ", c.Visible, " ", c.Location, " ", c.Size);
			}
		}

		private IContainer components;

		private TreeView tv;

		private MyLayerdForm lf;

		private Form f;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.tv = new System.Windows.Forms.TreeView();
			base.SuspendLayout();
			this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tv.Location = new System.Drawing.Point(0, 0);
			this.tv.Name = "tv";
			this.tv.Size = new System.Drawing.Size(150, 150);
			this.tv.TabIndex = 0;
			this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(tv_AfterSelect);
			base.Controls.Add(this.tv);
			base.Name = "StructureTreeView";
			base.ResumeLayout(false);
		}

		public StructureTreeView(DockManager manager)
		{
			InitializeComponent();
			lf = new MyLayerdForm(Color.FromArgb(144, Color.Red));
			lf.Visible = false;
			TreeNode treeNode = new TreeNode(manager.Name);
			AddNodes(treeNode, manager);
			tv.Nodes.Add(treeNode);
			tv.ExpandAll();
		}

		~StructureTreeView()
		{
			HideOverlay();
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (!base.Visible)
			{
				HideOverlay();
			}
		}

		public void HideOverlay()
		{
			lf.Hide();
		}

		private void AddNodes(TreeNode parent, DockContainer main)
		{
			foreach (Control control in main.Controls)
			{
				DockPanel dockPanel = control as DockPanel;
				DockContainer dockContainer = control as DockContainer;
				if (control is DockButtonBar c)
				{
					parent.Nodes.Add(new BarNode(c));
				}
				else if (dockPanel != null)
				{
					parent.Nodes.Add(new PanelNode(dockPanel));
				}
				else if (dockContainer != null)
				{
					TreeNode treeNode = new ContainerNode(dockContainer);
					parent.Nodes.Add(treeNode);
					AddNodes(treeNode, dockContainer);
				}
			}
		}

		private void RegForm(Form f)
		{
			this.f = f;
			f.FormClosed += f_FormClosed;
		}

		private void UnRegForm()
		{
			f.FormClosed -= f_FormClosed;
		}

		public static void Execute(DockManager manager)
		{
			Form form = new Form();
			form.Text = manager.Name + " Structure";
			form.TopMost = true;
			StructureTreeView structureTreeView = new StructureTreeView(manager);
			form.Controls.Add(structureTreeView);
			structureTreeView.Dock = DockStyle.Fill;
			structureTreeView.RegForm(form);
			form.Show();
		}

		private void f_FormClosed(object sender, FormClosedEventArgs e)
		{
			HideOverlay();
			UnRegForm();
		}

		private void tv_AfterSelect(object sender, TreeViewEventArgs e)
		{
			ContainerNode containerNode = e.Node as ContainerNode;
			PanelNode panelNode = e.Node as PanelNode;
			BarNode barNode = e.Node as BarNode;
			if (containerNode != null)
			{
				lf.Location = containerNode.DockContainer.ScreenLocation;
				lf.Size = containerNode.DockContainer.Size;
				lf.Show();
			}
			else if (panelNode != null)
			{
				lf.Location = panelNode.DockPanel.Parent.PointToScreen(panelNode.DockPanel.Location);
				lf.Size = panelNode.DockPanel.Size;
				lf.Show();
			}
			else if (barNode != null)
			{
				lf.Location = barNode.DockButtonBar.Parent.PointToScreen(barNode.DockButtonBar.Location);
				lf.Size = barNode.DockButtonBar.Size;
				lf.Show();
			}
			else
			{
				HideOverlay();
			}
		}
	}
}
