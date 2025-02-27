using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// Summary description for GenericImport.
	/// </summary>
	class GenericImportForm : Form
	{
		private SteepValley.Windows.Forms.XPGradientPanel Gradientpanel1;
		private System.ComponentModel.IContainer components;
		private ListViewEx lvmesh;
		private ImageList imageList1;
		private ColumnHeader chMeshName;
		private ColumnHeader chMeshAction;
		private ColumnHeader chMeshTarget;
		private ColumnHeader chFaces;
		private ColumnHeader chVertices;
		private ColumnHeader chImportEnvelope;
		private SteepValley.Windows.Forms.XPLine xpLine1;
		private Label label1;
		private ColumnHeader chJointCount;
		private Label label2;
		private SteepValley.Windows.Forms.XPLine xpLine2;
		private ListViewEx lvbones;
		private ColumnHeader clBoneName;
		private ColumnHeader clBoneAction;
		private ColumnHeader clImportBone;
		private ColumnHeader clAssignedVertices;
		private Label label3;
		private SteepValley.Windows.Forms.XPLine xpLine3;
		private Panel panel1;
		private Button button1;
		private CheckBox cbClear;

		GenericImportForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			ComboBox cb = new ComboBox();
			imageList1.ImageSize = new Size(1, cb.Height + 2);
			cb.Dispose();
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
			components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(GenericImportForm));
			Gradientpanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			panel1 = new Panel();
			cbClear = new CheckBox();
			button1 = new Button();
			label3 = new Label();
			xpLine3 = new SteepValley.Windows.Forms.XPLine();
			lvbones = new ListViewEx();
			clBoneName = new ColumnHeader();
			clBoneAction = new ColumnHeader();
			clImportBone = new ColumnHeader();
			clAssignedVertices = new ColumnHeader();
			imageList1 = new ImageList(components);
			label2 = new Label();
			xpLine2 = new SteepValley.Windows.Forms.XPLine();
			label1 = new Label();
			xpLine1 = new SteepValley.Windows.Forms.XPLine();
			lvmesh = new ListViewEx();
			chMeshName = new ColumnHeader();
			chMeshAction = new ColumnHeader();
			chMeshTarget = new ColumnHeader();
			chFaces = new ColumnHeader();
			chVertices = new ColumnHeader();
			chImportEnvelope = new ColumnHeader();
			chJointCount = new ColumnHeader();
			Gradientpanel1.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// Gradientpanel1
			//
			Gradientpanel1.BackColor = Color.Transparent;
			Gradientpanel1.Controls.Add(panel1);
			Gradientpanel1.Controls.Add(label3);
			Gradientpanel1.Controls.Add(xpLine3);
			Gradientpanel1.Controls.Add(lvbones);
			Gradientpanel1.Controls.Add(label2);
			Gradientpanel1.Controls.Add(xpLine2);
			Gradientpanel1.Controls.Add(label1);
			Gradientpanel1.Controls.Add(xpLine1);
			Gradientpanel1.Controls.Add(lvmesh);
			Gradientpanel1.Dock = DockStyle.Fill;
			Gradientpanel1.Location = new Point(0, 0);
			Gradientpanel1.Name = "Gradientpanel1";
			Gradientpanel1.Size = new Size(752, 486);
			Gradientpanel1.TabIndex = 0;
			//
			// panel1
			//
			panel1.Anchor =

					(
						(
							AnchorStyles.Bottom
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			panel1.BackColor = Color.Transparent;
			panel1.Controls.Add(cbClear);
			panel1.Controls.Add(button1);
			panel1.Location = new Point(0, 384);
			panel1.Name = "panel1";
			panel1.Size = new Size(752, 100);
			panel1.TabIndex = 10;
			//
			// cbClear
			//
			cbClear.Location = new Point(8, 8);
			cbClear.Name = "cbClear";
			cbClear.Size = new Size(192, 24);
			cbClear.TabIndex = 1;
			cbClear.Text = "Clear Meshgroups before Import";
			//
			// button1
			//
			button1.FlatStyle = FlatStyle.System;
			button1.Location = new Point(672, 72);
			button1.Name = "button1";
			button1.TabIndex = 0;
			button1.Text = "Import";
			button1.Click += new System.EventHandler(button1_Click);
			//
			// label3
			//
			label3.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			label3.BackColor = Color.Transparent;
			label3.Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label3.ForeColor = Color.FromArgb(
				64,
				64,
				64
			);
			label3.Location = new Point(648, 352);
			label3.Name = "label3";
			label3.TabIndex = 9;
			label3.Text = "Options";
			label3.TextAlign = ContentAlignment.BottomRight;
			//
			// xpLine3
			//
			xpLine3.Anchor =

					(
						(
							AnchorStyles.Bottom
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			xpLine3.BackColor = Color.Transparent;
			xpLine3.Location = new Point(9, 376);
			xpLine3.Name = "xpLine3";
			xpLine3.Size = new Size(740, 4);
			xpLine3.TabIndex = 8;
			//
			// lvbones
			//
			lvbones.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lvbones.BorderStyle = BorderStyle.None;
			lvbones.Columns.AddRange(
				new ColumnHeader[]
				{
					clBoneName,
					clBoneAction,
					clImportBone,
					clAssignedVertices,
				}
			);
			lvbones.FullRowSelect = true;
			lvbones.HeaderStyle =
				ColumnHeaderStyle
				.Nonclickable;
			lvbones.HideSelection = false;
			lvbones.Location = new Point(8, 216);
			lvbones.Name = "lvbones";
			lvbones.Size = new Size(736, 128);
			lvbones.SmallImageList = imageList1;
			lvbones.TabIndex = 7;
			lvbones.View = View.Details;
			//
			// clBoneName
			//
			clBoneName.Text = "Name";
			clBoneName.Width = 106;
			//
			// clBoneAction
			//
			clBoneAction.Text = "";
			clBoneAction.Width = 102;
			//
			// clImportBone
			//
			clImportBone.Text = "Import as";
			clImportBone.Width = 277;
			//
			// clAssignedVertices
			//
			clAssignedVertices.Text = "Vertices";
			clAssignedVertices.Width = 67;
			//
			// imageList1
			//
			imageList1.ImageSize = new Size(1, 16);
			imageList1.TransparentColor = Color.Transparent;
			//
			// label2
			//
			label2.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label2.BackColor = Color.Transparent;
			label2.Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label2.ForeColor = Color.FromArgb(
				64,
				64,
				64
			);
			label2.Location = new Point(648, 184);
			label2.Name = "label2";
			label2.TabIndex = 6;
			label2.Text = "Skeleton";
			label2.TextAlign = ContentAlignment.BottomRight;
			//
			// xpLine2
			//
			xpLine2.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			xpLine2.BackColor = Color.Transparent;
			xpLine2.Location = new Point(9, 208);
			xpLine2.Name = "xpLine2";
			xpLine2.Size = new Size(740, 4);
			xpLine2.TabIndex = 5;
			//
			// label1
			//
			label1.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label1.BackColor = Color.Transparent;
			label1.Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label1.ForeColor = Color.FromArgb(
				64,
				64,
				64
			);
			label1.Location = new Point(648, 8);
			label1.Name = "label1";
			label1.TabIndex = 4;
			label1.Text = "Mesh Groups";
			label1.TextAlign = ContentAlignment.BottomRight;
			//
			// xpLine1
			//
			xpLine1.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			xpLine1.BackColor = Color.Transparent;
			xpLine1.Location = new Point(9, 32);
			xpLine1.Name = "xpLine1";
			xpLine1.Size = new Size(740, 4);
			xpLine1.TabIndex = 3;
			//
			// lvmesh
			//
			lvmesh.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lvmesh.BorderStyle = BorderStyle.None;
			lvmesh.Columns.AddRange(
				new ColumnHeader[]
				{
					chMeshName,
					chMeshAction,
					chMeshTarget,
					chFaces,
					chVertices,
					chImportEnvelope,
					chJointCount,
				}
			);
			lvmesh.FullRowSelect = true;
			lvmesh.HeaderStyle =
				ColumnHeaderStyle
				.Nonclickable;
			lvmesh.HideSelection = false;
			lvmesh.Location = new Point(8, 40);
			lvmesh.Name = "lvmesh";
			lvmesh.Size = new Size(736, 136);
			lvmesh.SmallImageList = imageList1;
			lvmesh.TabIndex = 2;
			lvmesh.View = View.Details;
			//
			// chMeshName
			//
			chMeshName.Text = "Name";
			chMeshName.Width = 106;
			//
			// chMeshAction
			//
			chMeshAction.Text = "";
			chMeshAction.Width = 102;
			//
			// chMeshTarget
			//
			chMeshTarget.Text = "Import as";
			chMeshTarget.Width = 277;
			//
			// chFaces
			//
			chFaces.Text = "Faces";
			chFaces.Width = 67;
			//
			// chVertices
			//
			chVertices.Text = "Vertices";
			chVertices.Width = 67;
			//
			// chImportEnvelope
			//
			chImportEnvelope.Text = "Boneweight Import";
			chImportEnvelope.Width = 20;
			//
			// chJointCount
			//
			chJointCount.Text = "Joint Count";
			chJointCount.Width = 79;
			//
			// GenericImportForm
			//
			AutoScaleBaseSize = new Size(5, 14);
			ClientSize = new Size(752, 486);
			Controls.Add(Gradientpanel1);
			Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Icon = ((Icon)(resources.GetObject("$this.Icon")));
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "GenericImportForm";
			ShowInTaskbar = false;
			Text = "Mesh Import";
			Gradientpanel1.ResumeLayout(false);
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion



		GenericMeshImport gmi;

		public static void Execute(GenericMeshImport gmi)
		{
			GenericImportForm f = new GenericImportForm
			{
				gmi = gmi
			};
			f.Setup();
			f.ShowDialog();
			f.Dispose();
		}

		MeshListViewItem.ActionChangedEvent chg;
		BoneListViewItem.ActionChangedEvent bonechg;

		void Setup()
		{
			cbClear.Checked = gmi.ClearGroupsOnImport;
			if (chg == null)
			{
				chg = new MeshListViewItem.ActionChangedEvent(ActionChangedEvent);
			}

			if (bonechg == null)
			{
				bonechg = new BoneListViewItem.ActionChangedEvent(
					BoneActionChangedEvent
				);
			}

			foreach (Ambertation.Scenes.Mesh m in gmi.Scene.MeshCollection)
			{
				new MeshListViewItemExt(lvmesh, m, gmi, chg);
			}

			foreach (Ambertation.Scenes.Joint j in gmi.Scene.JointCollection)
			{
				new BoneListViewItemExt(lvbones, j, gmi, bonechg);
			}
		}

		bool ignore = false;

		void ActionChangedEvent(MeshListViewItem sender)
		{
			if (ignore)
			{
				return;
			}

			ignore = true;
			foreach (MeshListViewItem mlvi in lvmesh.SelectedItems)
			{
				if (mlvi == sender)
				{
					continue;
				}

				mlvi.Action = sender.Action;
			}
			ignore = false;
		}

		void BoneActionChangedEvent(BoneListViewItem sender)
		{
			if (ignore)
			{
				return;
			}

			ignore = true;
			foreach (BoneListViewItem blvi in lvbones.SelectedItems)
			{
				if (blvi == sender)
				{
					continue;
				}

				blvi.Action = sender.Action;
			}
			ignore = false;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			MeshListViewItemExt[] meshes = new MeshListViewItemExt[lvmesh.Items.Count];
			lvmesh.Items.CopyTo(meshes, 0);
			gmi.SetMeshList(meshes);

			BoneListViewItemExt[] bones = new BoneListViewItemExt[lvbones.Items.Count];
			lvbones.Items.CopyTo(bones, 0);
			gmi.SetBoneList(bones);

			gmi.ClearGroupsOnImport = cbClear.Checked;

			Close();
		}
	}
}
