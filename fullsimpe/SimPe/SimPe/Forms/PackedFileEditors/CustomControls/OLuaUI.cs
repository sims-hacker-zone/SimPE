// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.Forms.PackedFileEditors.CustomControls
{
	/// <summary>
	/// Summary description for OLuaUI.
	/// </summary>
	public class ObjLua
		: UserControl,
			IPackedFileUI
	{
		private TreeView tv;
		private Button btSave;
		private Button btLoad;
		private Label label1;
		private TextBox tbName;
		private Button button1;
		private Button button2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ObjLua()
		{
			// Required designer variable.
			InitializeComponent();

			button2.Enabled = Helper.QARelease;
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				tv.Font = new System.Drawing.Font("Tahoma", 12F);
			}
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
			tv = new TreeView();
			btSave = new Button();
			btLoad = new Button();
			label1 = new Label();
			tbName = new TextBox();
			button1 = new Button();
			button2 = new Button();
			SuspendLayout();
			//
			// tv
			//
			tv.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tv.BorderStyle = BorderStyle.None;
			tv.Location = new System.Drawing.Point(8, 40);
			tv.Name = "tv";
			tv.Size = new System.Drawing.Size(552, 320);
			tv.TabIndex = 0;
			//
			// btSave
			//
			btSave.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Left


			;
			btSave.FlatStyle = FlatStyle.System;
			btSave.Location = new System.Drawing.Point(96, 368);
			btSave.Name = "btSave";
			btSave.Size = new System.Drawing.Size(75, 25);
			btSave.TabIndex = 1;
			btSave.Text = "Export...";
			btSave.Click += new System.EventHandler(btSave_Click);
			//
			// btLoad
			//
			btLoad.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Left


			;
			btLoad.FlatStyle = FlatStyle.System;
			btLoad.Location = new System.Drawing.Point(8, 368);
			btLoad.Name = "btLoad";
			btLoad.Size = new System.Drawing.Size(75, 25);
			btLoad.TabIndex = 2;
			btLoad.Text = "Import...";
			btLoad.Click += new System.EventHandler(btLoad_Click);
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font(
				"Tahoma",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(8, 11);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(48, 16);
			label1.TabIndex = 3;
			label1.Text = "Name:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// tbName
			//
			tbName.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbName.Location = new System.Drawing.Point(62, 8);
			tbName.Name = "tbName";
			tbName.Size = new System.Drawing.Size(498, 23);
			tbName.TabIndex = 4;
			tbName.TextChanged += new System.EventHandler(tbName_TextChanged);
			//
			// button1
			//
			button1.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			button1.FlatStyle = FlatStyle.System;
			button1.Location = new System.Drawing.Point(485, 368);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 25);
			button1.TabIndex = 5;
			button1.Text = "Commit";
			button1.Click += new System.EventHandler(button1_Click);
			//
			// button2
			//
			button2.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Left


			;
			button2.FlatStyle = FlatStyle.System;
			button2.Location = new System.Drawing.Point(176, 368);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(120, 25);
			button2.TabIndex = 6;
			button2.Text = "Export to Source...";
			button2.Click += new System.EventHandler(button2_Click);
			//
			// ObjLua
			//
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(tbName);
			Controls.Add(label1);
			Controls.Add(btLoad);
			Controls.Add(btSave);
			Controls.Add(tv);
			Font = new System.Drawing.Font(
				"Tahoma",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Name = "ObjLua";
			Size = new System.Drawing.Size(568, 400);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		void AddFunction(
			TreeNodeCollection nodes,
			ObjLuaFunction fkt
		)
		{
			TreeNode tn = new TreeNode(fkt.ToString())
			{
				Tag = fkt
			};
			nodes.Add(tn);

			TreeNode ctn = new TreeNode("Constants");
			tn.Nodes.Add(ctn);
			foreach (ObjLuaConstant olc in fkt.Constants)
			{
				TreeNode sctn = new TreeNode(olc.ToString())
				{
					Tag = olc
				};

				ctn.Nodes.Add(sctn);
			}

			TreeNode cltn = new TreeNode("Locals");
			tn.Nodes.Add(cltn);
			int ct = 0;
			foreach (ObjLuaLocalVar c in fkt.Locals)
			{
				TreeNode scltn = new TreeNode(
					Helper.HexString(ct++) + ": " + c.ToString()
				)
				{
					Tag = c
				};

				cltn.Nodes.Add(scltn);
			}

			TreeNode cutn = new TreeNode("UpValues");
			tn.Nodes.Add(cutn);
			ct = 0;
			foreach (ObjLuaUpValue c in fkt.UpValues)
			{
				TreeNode scutn = new TreeNode(
					Helper.HexString(ct++) + ": " + c.ToString()
				)
				{
					Tag = c
				};

				cutn.Nodes.Add(scutn);
			}

			TreeNode cstn = new TreeNode("SourceLines");
			tn.Nodes.Add(cstn);
			ct = 0;
			foreach (Wrapper.ObjLuaSourceLine c in fkt.SourceLine)
			{
				TreeNode scstn = new TreeNode(
					Helper.HexString(ct++) + ": " + c.ToString()
				)
				{
					Tag = c
				};

				cstn.Nodes.Add(scstn);
			}

			TreeNode ftn = new TreeNode("Functions");
			tn.Nodes.Add(ftn);
			foreach (Wrapper.ObjLuaFunction olf in fkt.Functions)
			{
				AddFunction(ftn.Nodes, olf);
			}

			TreeNode cdtn = new TreeNode("Instructions");
			tn.Nodes.Add(cdtn);
			ct = 0;
			foreach (Wrapper.ObjLuaCode c in fkt.Codes)
			{
				TreeNode scdtn = new TreeNode(
					Helper.HexString(ct++) + ": " + c.ToString()
				)
				{
					Tag = c
				};

				cdtn.Nodes.Add(scdtn);
			}
		}

		protected ObjLua Wrapper
		{
			get; private set;
		}

		#region IPackedFileUI Member

		public void UpdateGUI(IFileWrapper wrapper)
		{
			Wrapper = (ObjLua)wrapper;

			tv.Nodes.Clear();
			AddFunction(tv.Nodes, Wrapper.Root);

			tbName.Text = Wrapper.FileName;
			tv.ExpandAll();
		}

		public Control GUIHandle => this;

		#endregion

		#region IDisposable Member

		void System.IDisposable.Dispose()
		{
			Dispose(true);
		}

		#endregion

		private void btSave_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog
			{
				Filter = ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					ExtensionType.LuaScript,
					ExtensionType.AllFiles,
				}
			),
				FileName = Wrapper.FileName
			};
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				Wrapper.ExportLua(sfd.FileName);
			}
		}

		private void btLoad_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog
			{
				Filter = ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					ExtensionType.LuaScript,
					ExtensionType.AllFiles,
				}
			),
				FileName = Wrapper.FileName
			};
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				Wrapper.ImportLua(ofd.FileName);
			}

			Wrapper.SynchronizeUserData(true, false);
			UpdateGUI(Wrapper);
		}

		private void tbName_TextChanged(object sender, System.EventArgs e)
		{
			Wrapper.FileName = tbName.Text;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Wrapper.SynchronizeUserData(true, false);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog
			{
				Filter = ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					ExtensionType.LuaScript,
					ExtensionType.AllFiles,
				}
			),
				FileName = Wrapper.FileName
			};
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string src = Wrapper.ToSource();
				System.IO.StreamWriter sw = System.IO.File.CreateText(sfd.FileName);
				try
				{
					sw.Write(src);
				}
				finally
				{
					sw.Close();
					sw.Dispose();
					sw = null;
				}
			}
		}
	}
}
