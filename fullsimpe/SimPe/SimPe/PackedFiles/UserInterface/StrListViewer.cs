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
			treeView1.Nodes.Clear();
			listView1.Items.Clear();
			foreach (StrLanguage l in wrapper.Languages)
			{
				TreeNode node = new TreeNode
				{
					Tag = l,
					Text = l.ToString()
				};
				treeView1.Nodes.Add(node);
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
			treeView1 = new TreeView();
			cmLangList = new ContextMenu();
			menuItem1 = new MenuItem();
			menuItem2 = new MenuItem();
			menuItem3 = new MenuItem();
			splitter1 = new Splitter();
			listView1 = new ListView();
			colLine = new ColumnHeader();
			colTitle = new ColumnHeader();
			colDesc = new ColumnHeader();
			cmStrList = new ContextMenu();
			menuItem4 = new MenuItem();
			menuItem5 = new MenuItem();
			menuItem6 = new MenuItem();
			menuItem7 = new MenuItem();
			menuItem8 = new MenuItem();
			menuItem9 = new MenuItem();
			menuItem10 = new MenuItem();
			menuItem11 = new MenuItem();
			menuItem12 = new MenuItem();
			SuspendLayout();
			//
			// treeView1
			//
			treeView1.ContextMenu = cmLangList;
			treeView1.Dock = DockStyle.Left;
			treeView1.ImageIndex = -1;
			treeView1.Location = new System.Drawing.Point(0, 0);
			treeView1.Name = "treeView1";
			treeView1.SelectedImageIndex = -1;
			treeView1.Size = new System.Drawing.Size(216, 144);
			treeView1.Sorted = true;
			treeView1.TabIndex = 0;
			treeView1.AfterSelect += new TreeViewEventHandler(
				treeView1_AfterSelect
			);
			//
			// cmLangList
			//
			cmLangList.MenuItems.AddRange(
				new MenuItem[]
				{
					menuItem1,
					menuItem2,
					menuItem7,
					menuItem3,
					menuItem8,
					menuItem9,
				}
			);
			//
			// menuItem1
			//
			menuItem1.Index = 0;
			menuItem1.Shortcut = Shortcut.CtrlC;
			menuItem1.Text = "&Copy";
			//
			// menuItem2
			//
			menuItem2.Index = 1;
			menuItem2.Shortcut = Shortcut.CtrlV;
			menuItem2.Text = "&Paste";
			//
			// menuItem3
			//
			menuItem3.Index = 3;
			menuItem3.Text = "&Set all to these";
			//
			// splitter1
			//
			splitter1.Location = new System.Drawing.Point(216, 0);
			splitter1.Name = "splitter1";
			splitter1.Size = new System.Drawing.Size(3, 144);
			splitter1.TabIndex = 1;
			splitter1.TabStop = false;
			//
			// listView1
			//
			listView1.Columns.AddRange(
				new ColumnHeader[]
				{
					colLine,
					colTitle,
					colDesc,
				}
			);
			listView1.ContextMenu = cmStrList;
			listView1.Dock = DockStyle.Fill;
			listView1.FullRowSelect = true;
			listView1.GridLines = true;
			listView1.HeaderStyle =
				ColumnHeaderStyle
				.Nonclickable;
			listView1.Location = new System.Drawing.Point(219, 0);
			listView1.Name = "listView1";
			listView1.Size = new System.Drawing.Size(621, 144);
			listView1.TabIndex = 2;
			listView1.View = View.Details;
			//
			// colLine
			//
			colLine.Text = "Line";
			colLine.Width = 36;
			//
			// colTitle
			//
			colTitle.Text = "Title";
			colTitle.Width = 246;
			//
			// colDesc
			//
			colDesc.Text = "Description";
			colDesc.Width = 307;
			//
			// cmStrList
			//
			cmStrList.MenuItems.AddRange(
				new MenuItem[]
				{
					menuItem10,
					menuItem4,
					menuItem5,
					menuItem6,
					menuItem11,
					menuItem12,
				}
			);
			//
			// menuItem4
			//
			menuItem4.Index = 1;
			menuItem4.Shortcut = Shortcut.CtrlC;
			menuItem4.Text = "&Copy";
			//
			// menuItem5
			//
			menuItem5.Index = 2;
			menuItem5.Shortcut = Shortcut.CtrlV;
			menuItem5.Text = "&Paste";
			//
			// menuItem6
			//
			menuItem6.Index = 3;
			menuItem6.Text = "&Set in all languages";
			//
			// menuItem7
			//
			menuItem7.Index = 2;
			menuItem7.Text = "Pas&te As...";
			//
			// menuItem8
			//
			menuItem8.Index = 4;
			menuItem8.Shortcut = Shortcut.Ins;
			menuItem8.Text = "&Add";
			//
			// menuItem9
			//
			menuItem9.Index = 5;
			menuItem9.Shortcut = Shortcut.Del;
			menuItem9.Text = "&Delete";
			//
			// menuItem10
			//
			menuItem10.DefaultItem = true;
			menuItem10.Index = 0;
			menuItem10.Text = "&Edit";
			//
			// menuItem11
			//
			menuItem11.Index = 4;
			menuItem11.Shortcut = Shortcut.Ins;
			menuItem11.Text = "&Add";
			//
			// menuItem12
			//
			menuItem12.Index = 5;
			menuItem12.Shortcut = Shortcut.Del;
			menuItem12.Text = "&Delete";
			//
			// StrListViewer
			//
			Controls.Add(listView1);
			Controls.Add(splitter1);
			Controls.Add(treeView1);
			Name = "StrListViewer";
			Size = new System.Drawing.Size(840, 144);
			ResumeLayout(false);
		}
		#endregion

		private void treeView1_AfterSelect(
			object sender,
			TreeViewEventArgs e
		)
		{
			listView1.Items.Clear();
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
				listView1.Items.Add(v);
			}
			currentLang = l;
		}
	}
}
