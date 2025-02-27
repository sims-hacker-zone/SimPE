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
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.UserInterface
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

			this.button2.Enabled = Helper.QARelease;
			if (SimPe.Helper.WindowsRegistry.UseBigIcons)
			{
				this.tv.Font = new System.Drawing.Font("Tahoma", 12F);
			}
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
			this.tv = new TreeView();
			this.btSave = new Button();
			this.btLoad = new Button();
			this.label1 = new Label();
			this.tbName = new TextBox();
			this.button1 = new Button();
			this.button2 = new Button();
			this.SuspendLayout();
			//
			// tv
			//
			this.tv.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tv.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tv.Location = new System.Drawing.Point(8, 40);
			this.tv.Name = "tv";
			this.tv.Size = new System.Drawing.Size(552, 320);
			this.tv.TabIndex = 0;
			//
			// btSave
			//
			this.btSave.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Left
					)
				)
			);
			this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btSave.Location = new System.Drawing.Point(96, 368);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(75, 25);
			this.btSave.TabIndex = 1;
			this.btSave.Text = "Export...";
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			//
			// btLoad
			//
			this.btLoad.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Left
					)
				)
			);
			this.btLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btLoad.Location = new System.Drawing.Point(8, 368);
			this.btLoad.Name = "btLoad";
			this.btLoad.Size = new System.Drawing.Size(75, 25);
			this.btLoad.TabIndex = 2;
			this.btLoad.Text = "Import...";
			this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font(
				"Tahoma",
				9.75F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label1.Location = new System.Drawing.Point(8, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			// tbName
			//
			this.tbName.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbName.Location = new System.Drawing.Point(62, 8);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(498, 23);
			this.tbName.TabIndex = 4;
			this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
			//
			// button1
			//
			this.button1.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(485, 368);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 25);
			this.button1.TabIndex = 5;
			this.button1.Text = "Commit";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			//
			// button2
			//
			this.button2.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Left
					)
				)
			);
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(176, 368);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(120, 25);
			this.button2.TabIndex = 6;
			this.button2.Text = "Export to Source...";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			//
			// ObjLua
			//
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btLoad);
			this.Controls.Add(this.btSave);
			this.Controls.Add(this.tv);
			this.Font = new System.Drawing.Font(
				"Tahoma",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.Name = "ObjLua";
			this.Size = new System.Drawing.Size(568, 400);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		void AddFunction(
			TreeNodeCollection nodes,
			Wrapper.ObjLuaFunction fkt
		)
		{
			TreeNode tn = new TreeNode(fkt.ToString());
			tn.Tag = fkt;
			nodes.Add(tn);

			TreeNode ctn = new TreeNode("Constants");
			tn.Nodes.Add(ctn);
			foreach (Wrapper.ObjLuaConstant olc in fkt.Constants)
			{
				TreeNode sctn = new TreeNode(olc.ToString());
				sctn.Tag = olc;

				ctn.Nodes.Add(sctn);
			}

			TreeNode cltn = new TreeNode("Locals");
			tn.Nodes.Add(cltn);
			int ct = 0;
			foreach (Wrapper.ObjLuaLocalVar c in fkt.Locals)
			{
				TreeNode scltn = new TreeNode(
					Helper.HexString(ct++) + ": " + c.ToString()
				);
				scltn.Tag = c;

				cltn.Nodes.Add(scltn);
			}

			TreeNode cutn = new TreeNode("UpValues");
			tn.Nodes.Add(cutn);
			ct = 0;
			foreach (Wrapper.ObjLuaUpValue c in fkt.UpValues)
			{
				TreeNode scutn = new TreeNode(
					Helper.HexString(ct++) + ": " + c.ToString()
				);
				scutn.Tag = c;

				cutn.Nodes.Add(scutn);
			}

			TreeNode cstn = new TreeNode("SourceLines");
			tn.Nodes.Add(cstn);
			ct = 0;
			foreach (Wrapper.ObjLuaSourceLine c in fkt.SourceLine)
			{
				TreeNode scstn = new TreeNode(
					Helper.HexString(ct++) + ": " + c.ToString()
				);
				scstn.Tag = c;

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
				);
				scdtn.Tag = c;

				cdtn.Nodes.Add(scdtn);
			}
		}

		protected Wrapper.ObjLua Wrapper
		{
			get; private set;
		}

		#region IPackedFileUI Member

		public void UpdateGUI(IFileWrapper wrapper)
		{
			Wrapper = (Wrapper.ObjLua)wrapper;

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
			this.Dispose(true);
		}

		#endregion

		private void btSave_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = SimPe.ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					SimPe.ExtensionType.LuaScript,
					SimPe.ExtensionType.AllFiles,
				}
			);
			sfd.FileName = Wrapper.FileName;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				Wrapper.ExportLua(sfd.FileName);
			}
		}

		private void btLoad_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = SimPe.ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					SimPe.ExtensionType.LuaScript,
					SimPe.ExtensionType.AllFiles,
				}
			);
			ofd.FileName = Wrapper.FileName;
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
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = SimPe.ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					SimPe.ExtensionType.LuaScript,
					SimPe.ExtensionType.AllFiles,
				}
			);
			sfd.FileName = Wrapper.FileName;
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
