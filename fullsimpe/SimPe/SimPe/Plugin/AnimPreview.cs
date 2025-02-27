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
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for AnimPreview.
	/// </summary>
	public class AnimPreview : Form
	{
		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel1;
		private Panel panel1;
		private Ambertation.Graphics.DirectXPanel dx;
		private ListBox lb;
		private TreeView tv;
		private Button btPlay;
		private Timer timer1;
		private ProgressBar pb;
		private System.ComponentModel.IContainer components;

		AnimPreview()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			dx = new Ambertation.Graphics.DirectXPanel();
			dx.Parent = this.panel1;
			dx.Dock = DockStyle.Fill;
			//dx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));

			dx.ResetDevice += new EventHandler(dx_ResetDevice);
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(AnimPreview));
			this.xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			this.pb = new ProgressBar();
			this.btPlay = new Button();
			this.tv = new TreeView();
			this.lb = new ListBox();
			this.panel1 = new Panel();
			this.timer1 = new Timer(this.components);
			this.xpGradientPanel1.SuspendLayout();
			this.SuspendLayout();
			//
			// xpGradientPanel1
			//
			this.xpGradientPanel1.Controls.Add(this.pb);
			this.xpGradientPanel1.Controls.Add(this.btPlay);
			this.xpGradientPanel1.Controls.Add(this.tv);
			this.xpGradientPanel1.Controls.Add(this.lb);
			this.xpGradientPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.xpGradientPanel1.Location = new Point(496, 0);
			this.xpGradientPanel1.Name = "xpGradientPanel1";
			this.xpGradientPanel1.Size = new Size(280, 454);
			this.xpGradientPanel1.TabIndex = 0;
			//
			// pb
			//
			this.pb.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pb.Location = new Point(0, 438);
			this.pb.Name = "pb";
			this.pb.Size = new Size(280, 16);
			this.pb.TabIndex = 3;
			//
			// btPlay
			//
			this.btPlay.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.btPlay.Location = new Point(200, 408);
			this.btPlay.Name = "btPlay";
			this.btPlay.Size = new Size(75, 23);
			this.btPlay.TabIndex = 2;
			this.btPlay.Text = "Play";
			this.btPlay.Click += new EventHandler(this.btPlay_Click);
			//
			// tv
			//
			this.tv.Location = new Point(8, 80);
			this.tv.Name = "tv";
			this.tv.Size = new Size(264, 322);
			this.tv.TabIndex = 1;
			this.tv.AfterSelect += new TreeViewEventHandler(
				this.tv_AfterSelect
			);
			//
			// lb
			//
			this.lb.Location = new Point(8, 8);
			this.lb.Name = "lb";
			this.lb.Size = new Size(264, 69);
			this.lb.TabIndex = 0;
			this.lb.SelectedIndexChanged += new EventHandler(
				this.lb_SelectedIndexChanged
			);
			//
			// panel1
			//
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(496, 454);
			this.panel1.TabIndex = 1;
			//
			// timer1
			//
			this.timer1.Tick += new EventHandler(this.timer1_Tick);
			//
			// AnimPreview
			//
			this.AutoScaleBaseSize = new Size(5, 14);
			this.ClientSize = new Size(776, 454);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.xpGradientPanel1);
			this.Font = new Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AnimPreview";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Animation Preview";
			this.xpGradientPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		public static void Execute(
			Interfaces.Scenegraph.IScenegraphFileIndexItem animitem
		)
		{
			GenericRcol rcol = new GenericRcol();
			rcol.ProcessData(animitem);

			Execute(rcol);
		}

		public static void Execute(Rcol anim)
		{
			if (anim.Blocks.Length > 0)
			{
				if (anim.Blocks[0] is Anim.AnimResourceConst)
				{
					Execute((Anim.AnimResourceConst)anim.Blocks[0]);
				}
			}
		}

		public static void Execute(Anim.AnimResourceConst anim)
		{
			AnimPreview f = new AnimPreview();

			WaitingScreen.Wait();
			Wait.SubStart(anim.MeshBlock.Length);
			try
			{
				WaitingScreen.UpdateMessage(
					SimPe.Localization.GetString("Loading Meshes")
				);
				int ct = 0;
				foreach (Anim.AnimationMeshBlock amb in anim.MeshBlock)
				{
					f.lb.Items.Add(new ListedMeshBlocks(amb));
					Wait.Progress = ct++;
				}
			}
			finally
			{
				Wait.SubStop();
				WaitingScreen.Stop();
			}

			f.ShowDialog();

			f.timer1.Enabled = false;
		}

		Gmdc.ElementOrder eo = new Gmdc.ElementOrder(
			SimPe.Plugin.Gmdc.ElementSorting.XYZ
		);

		void AddJoint(
			ListedMeshBlocks lmb,
			Interfaces.Scenegraph.ICresChildren bl,
			Ambertation.Graphics.MeshList parent,
			TreeNodeCollection nodes
		)
		{
			TransformNode tn = bl.StoredTransformNode;

			if (tn != null)
			{
				Ambertation.Graphics.MeshBox mb = new Ambertation.Graphics.MeshBox(
					Microsoft.DirectX.Direct3D.Mesh.Sphere(dx.Device, 0.02f, 12, 24),
					1,
					Ambertation.Graphics.DirectXPanel.GetMaterial(Color.Wheat)
				);
				mb.Wire = false;

				Ambertation.Scenes.Transformation trans =
					new Ambertation.Scenes.Transformation();
				trans.Rotation.X = tn.Rotation.GetEulerAngles().X;
				trans.Rotation.Y = tn.Rotation.GetEulerAngles().Y;
				trans.Rotation.Z = tn.Rotation.GetEulerAngles().Z;

				trans.Translation.X = tn.TransformX;
				trans.Translation.Y = tn.TransformY;
				trans.Translation.Z = tn.TransformZ;

				mb.Transform = Ambertation.Scenes.Converter.ToDx(trans);

				TreeNode tnode = new TreeNode(tn.ToString());
				tnode.Tag = mb;
				nodes.Add(tnode);
				jointmap[bl.GetName()] = mb;

				parent.Add(mb);

				foreach (Interfaces.Scenegraph.ICresChildren cld in bl)
				{
					AddJoint(lmb, cld, mb, tnode.Nodes);
				}
			}
			else
			{
				foreach (Interfaces.Scenegraph.ICresChildren cld in bl)
				{
					AddJoint(lmb, cld, parent, nodes);
				}
			}
		}

		private void dx_ResetDevice(object sender, EventArgs e)
		{
			if (!inter)
			{
				dx.Meshes.Clear(true);
				inter = true;
				lb_SelectedIndexChanged(null, null);
				inter = false;
			}
			else
			{
				dx.Meshes.Clear(false);
			}

			if (root != null)
			{
				foreach (Ambertation.Graphics.MeshBox mb in root)
				{
					dx.Meshes.Add(mb);
				}
			}
		}

		Ambertation.Graphics.MeshList root;
		Hashtable jointmap = new Hashtable();
		bool inter;

		private void lb_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lb.SelectedItem == null)
			{
				return;
			}

			jointmap.Clear();

			ListedMeshBlocks lmb = (ListedMeshBlocks)lb.SelectedItem;
			if (lmb.CRES == null || lmb.GMDC == null)
			{
				return;
			}

			ResourceNode rn = (ResourceNode)
				lmb.CRES.Blocks[0];

			if (root != null)
			{
				root.Dispose();
			}

			root = new Ambertation.Graphics.MeshList();

			AddJoint(lmb, rn, root, tv.Nodes);

			animdata.Clear();
			foreach (Anim.AnimationFrameBlock afb in lmb.ANIMBlock.Part2)
			{
				Anim.AnimationFrameBlock afb2 = afb.CloneBase(true);
				object o = jointmap[afb.Name];
				if (o == null)
				{
					continue;
				}

				Ambertation.Graphics.MeshBox mb = (Ambertation.Graphics.MeshBox)o;

				animdata.Add(
					new AnimationData(afb2, mb, lmb.ANIMBlock.Animation.TotalTime)
				);
			}

			if (inter)
			{
				return;
			}

			inter = true;
			//dx.Reset();
			dx.ResetViewport(
				new Microsoft.DirectX.Vector3(-2, -2, -2),
				new Microsoft.DirectX.Vector3(2, 2, 2)
			);
			dx.Render();
			inter = false;
		}

		//Ambertation.Graphics.MeshBox lastmb;
		private void tv_AfterSelect(
			object sender,
			TreeViewEventArgs e
		)
		{
			if (e.Node == null)
			{
				return;
			}

			if (e.Node.Tag == null)
			{
				return;
			}

			/*if (lastmb!=null) lastmb.Material = mat;
			Teichion.Graphics.MeshBox mb = (Teichion.Graphics.MeshBox)e.Node.Tag;
			mb.Material = smat;

			Microsoft.DirectX.Vector3 v = new Microsoft.DirectX.Vector3(0, 0, 0);
			v.TransformCoordinate(mb.GetEffectiveTransform());
			label1.Text = v.ToString();

			dx.Render();

			lastmb = mb;*/
		}

		ArrayList animdata = new ArrayList();

		private void btPlay_Click(object sender, EventArgs e)
		{
			if (lb.SelectedItem == null)
			{
				return;
			}

			ListedMeshBlocks lmb = (ListedMeshBlocks)lb.SelectedItem;

			timer1.Interval = 1000 / 25;
			timecode = 0;
			pb.Value = 0;
			pb.Maximum = lmb.ANIMBlock.Animation.TotalTime;

			timer1.Enabled = true;
		}

		int timecode;

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (lb.SelectedItem == null)
			{
				timer1.Enabled = false;
				return;
			}

			ListedMeshBlocks lmb = (ListedMeshBlocks)lb.SelectedItem;
			if (timecode > lmb.ANIMBlock.Animation.TotalTime)
			{
				timer1.Enabled = false;
				pb.Value = 0;
				return;
			}

			pb.Value = timecode;

			foreach (AnimationData ad in animdata)
			{
				ad.SetFrame(timecode);
			}

			dx.Render();
			//Application.DoEvents();

			timecode += 40;
		}
	}
}
