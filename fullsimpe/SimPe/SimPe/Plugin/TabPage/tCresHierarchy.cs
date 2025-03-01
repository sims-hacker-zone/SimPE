// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

namespace SimPe.Plugin.TabPage
{
	/// <summary>
	/// Summary description for fShapeRefNode.
	/// </summary>
	public class Cres : System.Windows.Forms.TabPage
	//System.Windows.Forms.UserControl
	{
		private ToolTip toolTip1;
		internal TreeView cres_tv;
		public ImageList iCres;
		private Label label58;
		internal TextBox tbfjoint;
		private System.ComponentModel.IContainer components;

		public Cres()
		{
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

			//
			// Required designer variable.
			//
			InitializeComponent();

			Text = Localization.GetString("CRES Hierarchie");
			UseVisualStyleBackColor = true;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				ClearCresTv();
				Tag = null;
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
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(Cres));
			tbfjoint = new TextBox();
			label58 = new Label();
			cres_tv = new TreeView();
			iCres = new ImageList(components);
			toolTip1 = new ToolTip(components);
			SuspendLayout();
			//
			// tbfjoint
			//
			tbfjoint.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbfjoint.Location = new System.Drawing.Point(88, 8);
			tbfjoint.Name = "tbfjoint";
			tbfjoint.Size = new System.Drawing.Size(696, 20);
			tbfjoint.TabIndex = 2;
			tbfjoint.Text = "";
			tbfjoint.TextChanged += new EventHandler(
				tbfjoint_TextChanged
			);
			//
			// label58
			//
			label58.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label58.Location = new System.Drawing.Point(8, 8);
			label58.Name = "label58";
			label58.Size = new System.Drawing.Size(72, 23);
			label58.TabIndex = 1;
			label58.Text = "Find Joint:";
			label58.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// cres_tv
			//
			cres_tv.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			cres_tv.FullRowSelect = true;
			cres_tv.HideSelection = false;
			cres_tv.ImageList = iCres;
			cres_tv.Location = new System.Drawing.Point(8, 32);
			cres_tv.Name = "cres_tv";
			cres_tv.Size = new System.Drawing.Size(776, 226);
			cres_tv.TabIndex = 0;
			cres_tv.DoubleClick += new EventHandler(
				cres_tv_DoubleClick
			);
			cres_tv.AfterSelect += new TreeViewEventHandler(
				SelectCresTv
			);
			//
			// iCres
			//
			iCres.ColorDepth = ColorDepth.Depth32Bit;
			iCres.ImageSize = new System.Drawing.Size(16, 16);
			iCres.ImageStream =
				(ImageListStreamer)
					resources.GetObject("iCres.ImageStream")

			;
			iCres.TransparentColor = System.Drawing.Color.Transparent;
			//
			// Cres
			//
			BackColor = System.Drawing.SystemColors.ControlLightLight;
			Controls.Add(tbfjoint);
			Controls.Add(label58);
			Controls.Add(cres_tv);
			Location = new System.Drawing.Point(4, 22);
			Name = "Cres";
			Size = new System.Drawing.Size(792, 262);
			ResumeLayout(false);
		}
		#endregion

		private void cres_tv_DoubleClick(object sender, EventArgs e)
		{
			TreeNode sel = cres_tv.SelectedNode;
			cres_tv.SelectedNode = null;
			cres_tv.SelectedNode = sel;
		}

		internal void ClearCresTv()
		{
			if (cres_tv == null)
			{
				return;
			}

			try
			{
				cres_tv.BeginUpdate();
				ClearCresTv(cres_tv.Nodes);
				cres_tv.EndUpdate();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		void ClearCresTv(TreeNodeCollection nodes)
		{
			foreach (TreeNode n in nodes)
			{
				n.Tag = null;
				ClearCresTv(n.Nodes);
			}

			nodes.Clear();
		}

		private void tbfjoint_TextChanged(object sender, EventArgs e)
		{
			tbfjoint.Tag = true;
			try
			{
				string name = tbfjoint.Text.Trim().ToLower();
				if (name != "")
				{
					SelectJoint(cres_tv.Nodes, name);
				}
			}
			finally
			{
				tbfjoint.Tag = null;
			}
		}

		private void SelectCresTv(
			object sender,
			TreeViewEventArgs e
		)
		{
			if (tbfjoint.Tag != null)
			{
				return;
			}

			if (e == null)
			{
				return;
			}

			if (e.Node == null)
			{
				return;
			}

			if (e.Node.Tag == null)
			{
				return;
			}

			int index = (int)e.Node.Tag;
			if (index < 0)
			{
				return;
			}

			ComboBox cb = (ComboBox)((TabControl)Parent).Tag;
			cb.SelectedIndex = index;
			((TabControl)Parent).SelectedIndex = 0;
		}

		bool SelectJoint(TreeNodeCollection nodes, string name)
		{
			foreach (TreeNode tn in nodes)
			{
				if (tn.Tag != null)
				{
					ComboBox cb = (ComboBox)((TabControl)Parent).Tag;

					object o = (cb.Items[(int)tn.Tag] as CountedListItem).Object;
					if (o is AbstractCresChildren)
					{
						if (
							((AbstractCresChildren)o)
								.GetName()
								.Trim()
								.ToLower()
								.StartsWith(name)
						)
						{
							cres_tv.SelectedNode = tn;
							tn.EnsureVisible();
							return true;
						}
					}
				}
				if (SelectJoint(tn.Nodes, name))
				{
					return true;
				}
			}

			return false;
		}
	}
}
