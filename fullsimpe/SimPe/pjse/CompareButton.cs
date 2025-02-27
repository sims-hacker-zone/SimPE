/***************************************************************************
 *   Copyright (C) 2008 by Peter L Jones                                   *
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
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using pjse;

using SimPe.Interfaces;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Scenegraph;
using SimPe.PackedFiles.Wrapper;

namespace pjse
{
	public partial class CompareButton : Button
	{
		private pjse.ExtendedWrapper wrapper = null;
		public pjse.ExtendedWrapper Wrapper
		{
			get
			{
				return wrapper;
			}
			set
			{
				wrapper = value;
				Enabled =
					(wrapper != null) && (wrapper.FileDescriptor.Group != 0xffffffff);
			}
		}

		private string wrapperName;
		public string WrapperName
		{
			get
			{
				return wrapperName;
			}
			set
			{
				wrapperName = value;
			}
		}

		/// <summary>
		/// Contains the pjse Filetable Entry to be displayed
		/// </summary>
		public class CompareWithEventArgs : EventArgs
		{
			private pjse.FileTable.Entry item = null;
			private SimPe.ExpansionItem exp = null;
			public pjse.FileTable.Entry Item => item;
			public SimPe.ExpansionItem ExpansionItem => exp;

			public CompareWithEventArgs(
				pjse.FileTable.Entry item,
				SimPe.ExpansionItem exp
			)
				: base()
			{
				this.item = item;
				this.exp = exp;
			}
		}

		public delegate void CompareWithEventHandler(
			object sender,
			CompareWithEventArgs e
		);

		[Category("Action")]
		[Description("Raised when an EP is selected to compare with.")]
		public event CompareWithEventHandler CompareWith;

		protected virtual void OnCompareWith(object sender, CompareWithEventArgs e)
		{
			if (CompareWith != null)
			{
				CompareWith(sender, e);
			}
		}

		public CompareButton()
			: base()
		{
			InitializeComponent();
		}

		private void btnCompare_Click(object sender, EventArgs e)
		{
			if (wrapper != null)
				this.cmenuCompare.Show((Control)sender, new Point(3, 3));
		}

		private void cmenuCompare_Opening(object sender, CancelEventArgs e)
		{
			while (cmenuCompare.Items.Count > 1)
				cmenuCompare.Items.RemoveAt(1);
			foreach (SimPe.ExpansionItem exp in SimPe.PathProvider.Global.Expansions)
			{
				if (exp.Exists && exp.Flag.FullObjectsPackage)
				{
					ToolStripMenuItem tsmi = new ToolStripMenuItem();
					tsmi.Click += new EventHandler(tsmi_Click);
					tsmi.Tag = exp;
					tsmi.Text = exp.Name;
					cmenuCompare.Items.Add(tsmi);
				}
			}
		}

		private void tsmi_Click(object sender, EventArgs e)
		{
			pjse.FileTable.Entry fe;
			SimPe.ExpansionItem exp;
			int i = cmenuCompare.Items.IndexOf((ToolStripItem)sender);
			if (i < 0)
				throw new ArgumentOutOfRangeException(
					"menuItem",
					"Unrecognised object triggered event"
				);
			else if (i == 0)
			{
				pjse.FileTable.Entry[] items = pjse.FileTable.GFT[
					wrapper.FileDescriptor.Type,
					wrapper.FileDescriptor.Group,
					wrapper.FileDescriptor.Instance,
					pjse.FileTable.Source.Maxis
				];
				if (items == null || items.Length == 0)
				{
					MessageBox.Show(
						pjse.Localization.GetString("cmpNFCurrent", wrapperName),
						this.Text,
						MessageBoxButtons.OK,
						MessageBoxIcon.Stop
					);
					return;
				}
				fe = items[0];
				exp = null;
			}
			else
			{
				exp = (SimPe.ExpansionItem)cmenuCompare.Items[i].Tag;
				SimPe.Packages.GeneratableFile op =
					SimPe.Packages.GeneratableFile.LoadFromFile(
						System.IO.Path.Combine(
							System.IO.Path.Combine(
								exp.InstallFolder,
								exp.ObjectsSubFolder
							),
							"objects.package"
						)
					);
				if (op == null)
					throw new Exception(
						"Could not read " + exp.Name + " objects.package"
					);
				IPackedFileDescriptor pfd = op.FindFile(wrapper.FileDescriptor);
				if (pfd == null)
				{
					MessageBox.Show(
						pjse.Localization.GetString("cmpNFExp", wrapperName, exp.Name),
						this.Text,
						MessageBoxButtons.OK,
						MessageBoxIcon.Stop
					);
					return;
				}
				fe = new pjse.FileTable.Entry(op, pfd, true, false);
			}

			OnCompareWith(this, new CompareWithEventArgs(fe, exp));
		}
	}
}
