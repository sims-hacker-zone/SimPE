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
using System;

using SimPe.Cache;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Summary description for SimComboBox.
	/// </summary>
	[System.ComponentModel.DefaultEvent("SelectedObjectChanged")]
	public class ObjectComboBox : System.Windows.Forms.UserControl
	{
		static MemoryCacheFile cachefile;

		/// <summary>
		/// Returns the MemoryObject Cache
		/// </summary>
		public static MemoryCacheFile ObjectCache
		{
			get
			{
				if (cachefile == null)
				{
					cachefile = MemoryCacheFile.InitCacheFile();
				}

				return cachefile;
			}
		}

		private System.Windows.Forms.ComboBox cb;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ObjectComboBox()
		{
			// Required designer variable.
			InitializeComponent();

			loaded = false;
			si = true;
			sm = false;
			st = false;
			sjd = false;
			sa = false;
			sb = false;
			sk = false;
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
			cb.TextChanged += new EventHandler(cb_TextChanged);
			cb.SelectedIndexChanged += new EventHandler(
				cb_SelectedIndexChanged
			);
			//
			// ObjectComboBox
			//
			Controls.Add(cb);
			Name = "ObjectComboBox";
			Size = new System.Drawing.Size(150, 24);
			ResumeLayout(false);
		}
		#endregion

		void SetContent()
		{
			cb.BeginUpdate();
			try
			{
				if (!loaded)
				{
					return;
				}

				if (DesignMode)
				{
					return;
				}

				cb.Items.Clear();
				cb.Sorted = false;
				foreach (MemoryCacheItem mci in ObjectCache.List)
				{
					bool use = false;
					if (
						ShowInventory
						&& mci.IsInventory
						&& !mci.IsToken
						&& !mci.IsMemory
						&& !mci.IsJobData
					)
					{
						use = true;
					}

					if (ShowTokens && mci.IsToken)
					{
						use = true;
					}

					if (ShowMemories && !mci.IsToken && mci.IsMemory)
					{
						use = true;
					}

					if (ShowJobData && mci.IsJobData)
					{
						use = true;
					}

					if (ShowAspiration && mci.IsAspiration)
					{
						use = true;
					}

					if (ShowBadge && mci.IsBadge)
					{
						use = true;
					}

					if (ShowSkill && mci.IsSkill)
					{
						use = true;
					}

					if (!use)
					{
						continue;
					}

					Interfaces.IAlias a = new Data.StaticAlias(
						mci.Guid,
						mci.Name + " {" + mci.ObjdName + "}",
						new object[] { mci }
					);

					cb.Items.Add(a);
				}
				cb.Sorted = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				cb.EndUpdate();
			}
		}

		bool si,
			st,
			sm,
			sjd,
			sa,
			sb,
			sk;
		public bool ShowTokens
		{
			get => st;
			set
			{
				if (st != value)
				{
					st = value;
					SetContent();
				}
			}
		}

		public bool ShowAspiration
		{
			get => sa;
			set
			{
				if (sa != value)
				{
					sa = value;
					SetContent();
				}
			}
		}

		public bool ShowBadge
		{
			get => sb;
			set
			{
				if (sb != value)
				{
					sb = value;
					SetContent();
				}
			}
		}

		public bool ShowSkill
		{
			get => sk;
			set
			{
				if (sk != value)
				{
					sk = value;
					SetContent();
				}
			}
		}

		public bool ShowMemories
		{
			get => sm;
			set
			{
				if (sm != value)
				{
					sm = value;
					SetContent();
				}
			}
		}

		public bool ShowInventory
		{
			get => si;
			set
			{
				if (si != value)
				{
					si = value;
					SetContent();
				}
			}
		}

		public bool ShowJobData
		{
			get => sjd;
			set
			{
				if (sjd != value)
				{
					sjd = value;
					SetContent();
				}
			}
		}

		public uint SelectedGuid
		{
			get
			{
				MemoryCacheItem mci = SelectedItem;

				return mci == null ? 0xffffffff : mci.Guid;
			}
			set
			{
				int id = -1;
				int ct = 0;
				foreach (Interfaces.IAlias a in cb.Items)
				{
					MemoryCacheItem mci =
						a.Tag[0] as MemoryCacheItem;
					if (mci.Guid == value)
					{
						id = ct;
						break;
					}
					ct++;
				}

				cb.SelectedIndex = id;
			}
		}

		public MemoryCacheItem SelectedItem
		{
			get
			{
				if (cb.SelectedItem == null)
				{
					return null;
				}

				Interfaces.IAlias a = cb.SelectedItem as Interfaces.IAlias;
				return a.Tag[0] as MemoryCacheItem;
			}
			set
			{
				int id = -1;
				if (value != null)
				{
					int ct = 0;
					foreach (Interfaces.IAlias a in cb.Items)
					{
						MemoryCacheItem mci =
							a.Tag[0] as MemoryCacheItem;
						if (mci.Guid == value.Guid)
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

		bool loaded;

		public void Reload()
		{
			loaded = true;
			SetContent();
			base.Refresh();
		}

		public event EventHandler SelectedObjectChanged;

		private void cb_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedObjectChanged != null)
			{
				SelectedObjectChanged(this, new EventArgs());
			}
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (!loaded && Visible)
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
