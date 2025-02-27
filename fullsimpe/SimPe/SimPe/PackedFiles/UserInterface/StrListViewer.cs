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
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for StrListViewer.
	/// </summary>
	public class StrListViewer : UserControl
	{
		#region Form elements

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public StrListViewer()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
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

		private TreeView treeView1;
		private Splitter splitter1;
		private ListView listView1;
		private ColumnHeader colLine;
		private ColumnHeader colTitle;
		private ColumnHeader colDesc;
		private ContextMenu cmLangList;
		private MenuItem menuItem1;
		private MenuItem menuItem2;
		private MenuItem menuItem3;
		private ContextMenu cmStrList;
		private MenuItem menuItem4;
		private MenuItem menuItem5;
		private MenuItem menuItem6;

		#region Str
		/// <summary>
		/// The Str wrapper handling the packed file data
		/// </summary>
		private Str wrapper;
		private MenuItem menuItem7;
		private MenuItem menuItem8;
		private MenuItem menuItem9;
		private MenuItem menuItem10;
		private MenuItem menuItem11;
		private MenuItem menuItem12;

		private StrLanguage currentLang = null;

		internal void UpdateGUI(Str wrp)
		{
			wrapper = wrp;
			this.treeView1.Nodes.Clear();
			this.listView1.Items.Clear();
			foreach (StrLanguage l in wrapper.Languages)
			{
				TreeNode node = new TreeNode();
				node.Tag = (object)l;
				node.Text = l.ToString();
				this.treeView1.Nodes.Add(node);
			}
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.treeView1 = new TreeView();
			this.cmLangList = new ContextMenu();
			this.menuItem1 = new MenuItem();
			this.menuItem2 = new MenuItem();
			this.menuItem3 = new MenuItem();
			this.splitter1 = new Splitter();
			this.listView1 = new ListView();
			this.colLine = new ColumnHeader();
			this.colTitle = new ColumnHeader();
			this.colDesc = new ColumnHeader();
			this.cmStrList = new ContextMenu();
			this.menuItem4 = new MenuItem();
			this.menuItem5 = new MenuItem();
			this.menuItem6 = new MenuItem();
			this.menuItem7 = new MenuItem();
			this.menuItem8 = new MenuItem();
			this.menuItem9 = new MenuItem();
			this.menuItem10 = new MenuItem();
			this.menuItem11 = new MenuItem();
			this.menuItem12 = new MenuItem();
			this.SuspendLayout();
			//
			// treeView1
			//
			this.treeView1.ContextMenu = this.cmLangList;
			this.treeView1.Dock = DockStyle.Left;
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(216, 144);
			this.treeView1.Sorted = true;
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new TreeViewEventHandler(
				this.treeView1_AfterSelect
			);
			//
			// cmLangList
			//
			this.cmLangList.MenuItems.AddRange(
				new MenuItem[]
				{
					this.menuItem1,
					this.menuItem2,
					this.menuItem7,
					this.menuItem3,
					this.menuItem8,
					this.menuItem9,
				}
			);
			//
			// menuItem1
			//
			this.menuItem1.Index = 0;
			this.menuItem1.Shortcut = Shortcut.CtrlC;
			this.menuItem1.Text = "&Copy";
			//
			// menuItem2
			//
			this.menuItem2.Index = 1;
			this.menuItem2.Shortcut = Shortcut.CtrlV;
			this.menuItem2.Text = "&Paste";
			//
			// menuItem3
			//
			this.menuItem3.Index = 3;
			this.menuItem3.Text = "&Set all to these";
			//
			// splitter1
			//
			this.splitter1.Location = new System.Drawing.Point(216, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 144);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			//
			// listView1
			//
			this.listView1.Columns.AddRange(
				new ColumnHeader[]
				{
					this.colLine,
					this.colTitle,
					this.colDesc,
				}
			);
			this.listView1.ContextMenu = this.cmStrList;
			this.listView1.Dock = DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HeaderStyle =
				ColumnHeaderStyle
				.Nonclickable;
			this.listView1.Location = new System.Drawing.Point(219, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(621, 144);
			this.listView1.TabIndex = 2;
			this.listView1.View = View.Details;
			//
			// colLine
			//
			this.colLine.Text = "Line";
			this.colLine.Width = 36;
			//
			// colTitle
			//
			this.colTitle.Text = "Title";
			this.colTitle.Width = 246;
			//
			// colDesc
			//
			this.colDesc.Text = "Description";
			this.colDesc.Width = 307;
			//
			// cmStrList
			//
			this.cmStrList.MenuItems.AddRange(
				new MenuItem[]
				{
					this.menuItem10,
					this.menuItem4,
					this.menuItem5,
					this.menuItem6,
					this.menuItem11,
					this.menuItem12,
				}
			);
			//
			// menuItem4
			//
			this.menuItem4.Index = 1;
			this.menuItem4.Shortcut = Shortcut.CtrlC;
			this.menuItem4.Text = "&Copy";
			//
			// menuItem5
			//
			this.menuItem5.Index = 2;
			this.menuItem5.Shortcut = Shortcut.CtrlV;
			this.menuItem5.Text = "&Paste";
			//
			// menuItem6
			//
			this.menuItem6.Index = 3;
			this.menuItem6.Text = "&Set in all languages";
			//
			// menuItem7
			//
			this.menuItem7.Index = 2;
			this.menuItem7.Text = "Pas&te As...";
			//
			// menuItem8
			//
			this.menuItem8.Index = 4;
			this.menuItem8.Shortcut = Shortcut.Ins;
			this.menuItem8.Text = "&Add";
			//
			// menuItem9
			//
			this.menuItem9.Index = 5;
			this.menuItem9.Shortcut = Shortcut.Del;
			this.menuItem9.Text = "&Delete";
			//
			// menuItem10
			//
			this.menuItem10.DefaultItem = true;
			this.menuItem10.Index = 0;
			this.menuItem10.Text = "&Edit";
			//
			// menuItem11
			//
			this.menuItem11.Index = 4;
			this.menuItem11.Shortcut = Shortcut.Ins;
			this.menuItem11.Text = "&Add";
			//
			// menuItem12
			//
			this.menuItem12.Index = 5;
			this.menuItem12.Shortcut = Shortcut.Del;
			this.menuItem12.Text = "&Delete";
			//
			// StrListViewer
			//
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.treeView1);
			this.Name = "StrListViewer";
			this.Size = new System.Drawing.Size(840, 144);
			this.ResumeLayout(false);
		}
		#endregion

		private void treeView1_AfterSelect(
			object sender,
			TreeViewEventArgs e
		)
		{
			this.listView1.Items.Clear();
			StrLanguage l = (StrLanguage)e.Node.Tag;
			StrItemList items = wrapper.LanguageItems(l);
			if (items == null)
			{
				return;
			}

			for (int i = 0; i < items.Length; i++)
			{
				StrToken s = items[i];
				string[] ss = new string[3];
				ss[0] = i.ToString();
				ss[1] = s.Title;
				ss[2] = s.Description;
				ListViewItem v = new ListViewItem(ss);
				this.listView1.Items.Add(v);
			}
			currentLang = l;
		}
	}
}
