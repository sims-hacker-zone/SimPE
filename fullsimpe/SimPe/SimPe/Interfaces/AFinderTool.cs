// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Windows.Forms;

namespace SimPe.Interfaces
{
	public partial class AFinderTool : UserControl
	{
		public AFinderTool()
			: this(null) { }

		protected AFinderTool(IFinderResultGui rgui)
			: base()
		{
			ResultGui = rgui;
			InitializeComponent();
			ThemeManager = ThemeManager.Global.CreateChild();
			ThemeManager.AddControl(grp);

			btStart.Enabled = rgui != null;
		}

		protected ThemeManager ThemeManager
		{
			get;
		}

		/// <summary>
		/// The Title of this Control
		/// </summary>
		[System.ComponentModel.Localizable(true)]
		public string Title
		{
			get => grp.HeaderText;
			set => grp.HeaderText = value;
		}

		/// <summary>
		/// This provides acces to the result GUI, enabeling you to start a search, or add a result to the result list
		/// </summary>
		protected IFinderResultGui ResultGui
		{
			get; private set;
		}

		internal void SetResultGui(IFinderResultGui gui)
		{
			ResultGui = gui;
			btStart.Enabled = ResultGui != null;
		}

		/// <summary>
		/// The control returned here should contain all parameters that control the search.
		/// </summary>
		public Control SearchGui => this;

		/// <summary>
		/// This is the search routine
		/// </summary>
		/// <param name="pkg">The package that is going to get searched</param>
		public void SearchPackage(Files.IPackageFile pkg)
		{
			foreach (Files.IPackedFileDescriptor pfd in pkg.Index)
			{
				if (ResultGui.ForcedStop)
				{
					return;
				}

				SearchPackage(pkg, pfd);
			}
		}

		/// <summary>
		/// This is the search routine
		/// </summary>
		/// <param name="fiis">List of resources to search</param>
		public void SearchPackage(
			Scenegraph.IScenegraphFileIndexItem[] fiis
		)
		{
			foreach (Scenegraph.IScenegraphFileIndexItem fii in fiis)
			{
				if (ResultGui.ForcedStop)
				{
					return;
				}

				SearchPackage(fii.Package, fii.FileDescriptor);
			}
		}

		/// <summary>
		/// This is the search routine
		/// </summary>
		/// <param name="fii">Resources to search</param>
		public void SearchPackage(
			Scenegraph.IScenegraphFileIndexItem fii
		)
		{
			SearchPackage(fii.Package, fii.FileDescriptor);
		}

		/// <summary>
		/// True if multiple packages can be searched at once
		/// </summary>
		public virtual bool ProcessParalell => true;

		/// <summary>
		/// This is the search routine you have to implement
		/// </summary>
		/// <param name="pkg">The package that is going to get searched</param>
		/// <param name="pfd">The resource within the package that is to be searched</param>
		public virtual void SearchPackage(
			Files.IPackageFile pkg,
			Files.IPackedFileDescriptor pfd
		)
		{
		}

		protected virtual bool OnPrepareStart()
		{
			return true;
		}

		private void btStart_Click(object sender, EventArgs e)
		{
			if (!ResultGui.Searching)
			{
				if (OnPrepareStart())
				{
					btStart.Text = Localization.GetString("Stop");
					btStart.Tag = true;
					ResultGui.StartSearch(this);
				}
			}
			else
			{
				ResultGui.StopSearch();
			}
		}

		public override string ToString()
		{
			return Title;
		}

		internal void NotifyFinishedSearch()
		{
			btStart.Text = Localization.GetString("Start");
			btStart.Tag = null;

			System.Diagnostics.Debug.WriteLine("Notified search finish");
		}
	}
}
