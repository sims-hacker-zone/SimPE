// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SimPe.Interfaces.Files;

namespace pjse
{
	public partial class CompareButton : Button
	{
		private ExtendedWrapper wrapper = null;
		public ExtendedWrapper Wrapper
		{
			get => wrapper;
			set
			{
				wrapper = value;
				Enabled =
					(wrapper != null) && (wrapper.FileDescriptor.Group != 0xffffffff);
			}
		}

		public string WrapperName
		{
			get; set;
		}

		/// <summary>
		/// Contains the pjse Filetable Entry to be displayed
		/// </summary>
		public class CompareWithEventArgs : EventArgs
		{
			public FileTable.Entry Item { get; } = null;
			public SimPe.ExpansionItem ExpansionItem { get; } = null;

			public CompareWithEventArgs(
				FileTable.Entry item,
				SimPe.ExpansionItem exp
			)
				: base()
			{
				Item = item;
				ExpansionItem = exp;
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
			{
				cmenuCompare.Show((Control)sender, new Point(3, 3));
			}
		}

		private void cmenuCompare_Opening(object sender, CancelEventArgs e)
		{
			while (cmenuCompare.Items.Count > 1)
			{
				cmenuCompare.Items.RemoveAt(1);
			}

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
			FileTable.Entry fe;
			SimPe.ExpansionItem exp;
			int i = cmenuCompare.Items.IndexOf((ToolStripItem)sender);
			if (i < 0)
			{
				throw new ArgumentOutOfRangeException(
					"menuItem",
					"Unrecognised object triggered event"
				);
			}
			else if (i == 0)
			{
				FileTable.Entry[] items = FileTable.GFT[
					wrapper.FileDescriptor.Type,
					wrapper.FileDescriptor.Group,
					wrapper.FileDescriptor.Instance,
					FileTable.Source.Maxis
				];
				if (items == null || items.Length == 0)
				{
					MessageBox.Show(
						Localization.GetString("cmpNFCurrent", WrapperName),
						Text,
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
					SimPe.Packages.File.LoadFromFile(
						System.IO.Path.Combine(
							System.IO.Path.Combine(
								exp.InstallFolder,
								exp.ObjectsSubFolder
							),
							"objects.package"
						)
					) ?? throw new Exception(
						"Could not read " + exp.Name + " objects.package"
					);

				IPackedFileDescriptor pfd = op.FindFile(wrapper.FileDescriptor);
				if (pfd == null)
				{
					MessageBox.Show(
						Localization.GetString("cmpNFExp", WrapperName, exp.Name),
						Text,
						MessageBoxButtons.OK,
						MessageBoxIcon.Stop
					);
					return;
				}
				fe = new FileTable.Entry(op, pfd, true, false);
			}

			OnCompareWith(this, new CompareWithEventArgs(fe, exp));
		}
	}
}
