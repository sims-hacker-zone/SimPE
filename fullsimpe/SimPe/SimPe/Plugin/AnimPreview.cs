// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Drawing;
using System.Linq;
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

			dx = new Ambertation.Graphics.DirectXPanel
			{
				Parent = panel1,
				Dock = DockStyle.Fill
			};
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(AnimPreview));
			xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			pb = new ProgressBar();
			btPlay = new Button();
			tv = new TreeView();
			lb = new ListBox();
			panel1 = new Panel();
			timer1 = new Timer(components);
			xpGradientPanel1.SuspendLayout();
			SuspendLayout();
			//
			// xpGradientPanel1
			//
			xpGradientPanel1.Controls.Add(pb);
			xpGradientPanel1.Controls.Add(btPlay);
			xpGradientPanel1.Controls.Add(tv);
			xpGradientPanel1.Controls.Add(lb);
			xpGradientPanel1.Dock = DockStyle.Right;
			xpGradientPanel1.Location = new Point(496, 0);
			xpGradientPanel1.Name = "xpGradientPanel1";
			xpGradientPanel1.Size = new Size(280, 454);
			xpGradientPanel1.TabIndex = 0;
			//
			// pb
			//
			pb.Dock = DockStyle.Bottom;
			pb.Location = new Point(0, 438);
			pb.Name = "pb";
			pb.Size = new Size(280, 16);
			pb.TabIndex = 3;
			//
			// btPlay
			//
			btPlay.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			btPlay.Location = new Point(200, 408);
			btPlay.Name = "btPlay";
			btPlay.Size = new Size(75, 23);
			btPlay.TabIndex = 2;
			btPlay.Text = "Play";
			btPlay.Click += new EventHandler(btPlay_Click);
			//
			// tv
			//
			tv.Location = new Point(8, 80);
			tv.Name = "tv";
			tv.Size = new Size(264, 322);
			tv.TabIndex = 1;
			tv.AfterSelect += new TreeViewEventHandler(
				tv_AfterSelect
			);
			//
			// lb
			//
			lb.Location = new Point(8, 8);
			lb.Name = "lb";
			lb.Size = new Size(264, 69);
			lb.TabIndex = 0;
			lb.SelectedIndexChanged += new EventHandler(
				lb_SelectedIndexChanged
			);
			//
			// panel1
			//
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(496, 454);
			panel1.TabIndex = 1;
			//
			// timer1
			//
			timer1.Tick += new EventHandler(timer1_Tick);
			//
			// AnimPreview
			//
			AutoScaleBaseSize = new Size(5, 14);
			ClientSize = new Size(776, 454);
			Controls.Add(panel1);
			Controls.Add(xpGradientPanel1);
			Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "AnimPreview";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Animation Preview";
			xpGradientPanel1.ResumeLayout(false);
			ResumeLayout(false);
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
			if (anim.Blocks.FirstOrDefault() is Anim.AnimResourceConst @const)
			{
				Execute(@const);
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
					Localization.GetString("Loading Meshes")
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
			Gmdc.ElementSorting.XYZ
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
				)
				{
					Wire = false
				};

				Ambertation.Scenes.Transformation trans =
					new Ambertation.Scenes.Transformation();
				trans.Rotation.X = tn.Rotation.GetEulerAngles().X;
				trans.Rotation.Y = tn.Rotation.GetEulerAngles().Y;
				trans.Rotation.Z = tn.Rotation.GetEulerAngles().Z;

				trans.Translation.X = tn.TransformX;
				trans.Translation.Y = tn.TransformY;
				trans.Translation.Z = tn.TransformZ;

				mb.Transform = Ambertation.Scenes.Converter.ToDx(trans);

				TreeNode tnode = new TreeNode(tn.ToString())
				{
					Tag = mb
				};
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

			root?.Dispose();

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
