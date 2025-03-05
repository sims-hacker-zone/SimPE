// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Linq;

namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Summary description for DebugDock.
	/// </summary>
	public class DebugDock
		: Ambertation.Windows.Forms.DockPanel,
			Interfaces.IDockableTool
	{
		ThemeManager tm;
		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbMem;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lbft;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DebugDock()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			tm = ThemeManager.Global.CreateChild();
			tm.AddControl(xpGradientPanel1);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				tm.RemoveControl(xpGradientPanel1);
				tm = null;
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(DebugDock));
			xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			lbft = new System.Windows.Forms.ListBox();
			label2 = new System.Windows.Forms.Label();
			lbMem = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			xpGradientPanel1.SuspendLayout();
			SuspendLayout();
			//
			// xpGradientPanel1
			//
			xpGradientPanel1.Controls.Add(lbft);
			xpGradientPanel1.Controls.Add(label2);
			xpGradientPanel1.Controls.Add(lbMem);
			xpGradientPanel1.Controls.Add(label1);
			xpGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			xpGradientPanel1.Location = new System.Drawing.Point(0, 0);
			xpGradientPanel1.Name = "xpGradientPanel1";
			xpGradientPanel1.Size = new System.Drawing.Size(250, 400);
			xpGradientPanel1.TabIndex = 0;
			//
			// lbft
			//
			lbft.Anchor =




								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							 | System.Windows.Forms.AnchorStyles.Left
						 | System.Windows.Forms.AnchorStyles.Right


			;
			lbft.Location = new System.Drawing.Point(16, 72);
			lbft.Name = "lbft";
			lbft.Size = new System.Drawing.Size(224, 316);
			lbft.TabIndex = 3;
			//
			// label2
			//
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(8, 56);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(128, 23);
			label2.TabIndex = 2;
			label2.Text = "FileTable Content:";
			label2.Click += new EventHandler(label2_Click);
			//
			// lbMem
			//
			lbMem.Anchor =



							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						 | System.Windows.Forms.AnchorStyles.Right


			;
			lbMem.BackColor = System.Drawing.Color.Transparent;
			lbMem.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbMem.Location = new System.Drawing.Point(16, 24);
			lbMem.Name = "lbMem";
			lbMem.Size = new System.Drawing.Size(224, 23);
			lbMem.TabIndex = 1;
			lbMem.Text = "0";
			lbMem.Click += new EventHandler(lbMem_Click);
			//
			// label1
			//
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(8, 8);
			label1.Name = "label1";
			label1.TabIndex = 0;
			label1.Text = "Memory Usage:";
			label1.Click += new EventHandler(label1_Click);
			//
			// DebugDock
			//
			Controls.Add(xpGradientPanel1);
			Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Name = "DebugDock";
			TabImage =
				(System.Drawing.Image)resources.GetObject("$this.TabImage")
			;
			TabText = "Debug";
			Text = "Debug Dock";
			xpGradientPanel1.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		public Ambertation.Windows.Forms.DockPanel GetDockableControl()
		{
			return this;
		}

		public event Events.ChangedResourceEvent ShowNewResource;

		public void RefreshDock(object sender, Events.ResourceEventArgs es)
		{
			lbMem.Text = GC.GetTotalMemory(false).ToString("N0") + " Byte";
		}

		#region IToolPlugin Member

		public override string ToString()
		{
			return Text;
		}

		#endregion

		private void lbMem_Click(object sender, EventArgs e)
		{
			RefreshDock(null, null);
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		private void label1_Click(object sender, EventArgs e)
		{
			System.IO.StreamWriter sw = System.IO.File.CreateText(System.IO.Path.Combine(Helper.SimPeDataPath, "replicated.txt"));
			string objname = System
				.IO.Path.Combine(
					PathProvider.Global[Expansions.BaseGame].InstallFolder,
					@"TSData\Res\Objects\objects.package"
				)
				.Trim()
				.ToLower();
			sw.WriteLine(
				System.IO.Path.GetFileName(objname)
					+ "----------------------------------------"
			);
			Interfaces.Files.IPackageFile pkg = Packages.File.LoadFromFile(
				objname
			);
			FileTableBase.FileIndex.Load();
			lbft.Items.Clear();

			Dictionary<int, int> ct = new Dictionary<int, int>();
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pkg.Index)
			{
				IEnumerable<Interfaces.Scenegraph.IScenegraphFileIndexItem> items =
					FileTableBase.FileIndex.FindFile(pfd, null);

				bool copy = false;
				if (!ct.ContainsKey(items.Count()))
				{
					ct[items.Count()] = 0;
				}
				ct[items.Count()]++;

				foreach (
					Interfaces.Scenegraph.IScenegraphFileIndexItem item in items
				)
				{
					if (item.Package.FileName.Trim().ToLower() != objname)
					{
						copy = true;
					}
				}

				if (!copy)
				{
					lbft.Items.Add(items.Count().ToString() + ": " + pfd.ToString());
					sw.WriteLine(items.Count().ToString() + ": " + pfd.ToString());
				}
			}

			lbft.Items.Add(" m: " + pkg.Index.Length.ToString());
			foreach (KeyValuePair<int, int> kv in ct)
			{
				lbft.Items.Add($" {kv.Key}: {kv.Value}");
			}

			sw.Close();
			sw.Dispose();
		}

		#region IToolExt Member

		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => TabImage;

		public new virtual bool Visible => IsDocked || IsFloating;

		#endregion
	}
}
