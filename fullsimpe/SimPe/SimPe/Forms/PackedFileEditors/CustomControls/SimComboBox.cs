// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.PackedFiles.Wrapper;

namespace SimPe.Forms.PackedFileEditors.CustomControls
{
	/// <summary>
	/// Summary description for SimComboBox.
	/// </summary>
	[System.ComponentModel.DefaultEvent("SelectedSimChanged")]
	public class SimComboBox : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ComboBox cb;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SimComboBox()
		{
			// Required designer variable.
			InitializeComponent();

			cb.Sorted = true;
			try
			{
				if (!DesignMode)
				{

					FileTableBase
					.ProviderRegistry
					.SimDescriptionProvider
						.ChangedPackage += new EventHandler(
						SimDescriptionProvider_ChangedPackage
					);
				}

				needreload = true;
			}
			catch { }
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{

				FileTableBase
				.ProviderRegistry
				.SimDescriptionProvider
					.ChangedPackage -= new EventHandler(
					SimDescriptionProvider_ChangedPackage
				);
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
			cb = new System.Windows.Forms.ComboBox();
			SuspendLayout();
			//
			// cb
			//
			cb.Dock = System.Windows.Forms.DockStyle.Top;
			cb.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cb.Location = new System.Drawing.Point(0, 0);
			cb.Name = "cb";
			cb.Size = new System.Drawing.Size(150, 21);
			cb.TabIndex = 0;
			cb.SelectedIndexChanged += new EventHandler(
				cb_SelectedIndexChanged
			);
			cb.TextChanged += new EventHandler(cb_TextChanged);
			//
			// SimComboBox
			//
			Controls.Add(cb);
			Name = "SimComboBox";
			Size = new System.Drawing.Size(150, 24);
			ResumeLayout(false);
		}
		#endregion

		void SetContent()
		{
			cb.Items.Clear();
			cb.Sorted = false;
			foreach (
				ExtSDesc sdsc in FileTableBase
					.ProviderRegistry
					.SimDescriptionProvider
					.SimInstance
					.Values
			)
			{
				Interfaces.IAlias a = new Data.StaticAlias(
					sdsc.SimId,
					sdsc.SimName + " " + sdsc.SimFamilyName,
					new object[] { sdsc }
				);
				cb.Items.Add(a);
			}
			cb.Sorted = true;
		}

		public ushort SelectedSimInstance
		{
			get
			{
				ExtSDesc sdsc = SelectedSim;
				return sdsc != null ? sdsc.Instance : (ushort)0xffff;
			}
			set
			{
				int id = -1;

				int ct = 0;
				foreach (Interfaces.IAlias a in cb.Items)
				{
					ExtSDesc s =
						a.Tag[0] as ExtSDesc;
					if (s.Instance == value)
					{
						id = ct;
						break;
					}
					ct++;
				}
				cb.SelectedIndex = id;
			}
		}

		public uint SelectedSimId
		{
			get
			{
				ExtSDesc sdsc = SelectedSim;
				return sdsc != null ? sdsc.SimId : 0xffffffff;
			}
			set
			{
				int id = -1;

				int ct = 0;
				foreach (Interfaces.IAlias a in cb.Items)
				{
					ExtSDesc s =
						a.Tag[0] as ExtSDesc;
					if (s.SimId == value)
					{
						id = ct;
						break;
					}
					ct++;
				}
				cb.SelectedIndex = id;
			}
		}

		public ExtSDesc SelectedSim
		{
			get
			{
				if (cb.SelectedItem == null)
				{
					return null;
				}

				Interfaces.IAlias a = cb.SelectedItem as Interfaces.IAlias;
				return a.Tag[0] as ExtSDesc;
			}
			set
			{
				int id = -1;
				if (value != null)
				{
					int ct = 0;
					foreach (Interfaces.IAlias a in cb.Items)
					{
						ExtSDesc s =
							a.Tag[0] as ExtSDesc;
						if (s.Instance == value.Instance)
						{
							id = ct;
							break;
						}
						ct++;
					}
				}

				cb.SelectedIndex = id;
			}
		}

		public void Reload()
		{
			needreload = false;
			SetContent();
			base.Refresh();
		}

		public event EventHandler SelectedSimChanged;

		private void cb_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedSimChanged != null)
			{
				SelectedSimChanged(this, new EventArgs());
			}
		}

		bool needreload;

		private void SimDescriptionProvider_ChangedPackage(object sender, EventArgs e)
		{
			needreload = true;
			if (Visible)
			{
				Reload();
			}
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (needreload && Visible)
			{
				Reload();
			}
		}

		private void cb_TextChanged(object sender, EventArgs e)
		{
			//cb.DroppedDown = true;
		}
	}
}
