// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Windows.Forms;

namespace SimPe.Windows.Forms
{
	partial class ResourceListViewExt
	{
		const int WAIT_SELECT = 400;
		System.Threading.Timer seltimer;

		private void lv_SelectedIndexChanged(object sender, EventArgs e)
		{
			//PrintStats("SelectedIndexChanged");
			SignalSelectionChanged();
		}

		private void lv_VirtualItemsSelectionRangeChanged(
			object sender,
			ListViewVirtualItemsSelectionRangeChangedEventArgs e
		)
		{
			//PrintStats("VirtualItemsSelectionRangeChanged");
			SignalSelectionChanged();
		}

		protected void SignalSelectionChanged()
		{
			if (noselectevent > 0)
			{
				DoSignalSelectionChanged(myhandle);
			}
			else
			{
				seltimer.Change(WAIT_SELECT, System.Threading.Timeout.Infinite);
			}
		}

		void DoSignalSelectionChanged(IntPtr handle)
		{
			Ambertation.Windows.Forms.APIHelp.SendMessage(
				handle,
				WM_USER_FIRE_SELECTION,
				0,
				0
			);
		}

		void SelectionTimerCallback(object state)
		{
			DoSignalSelectionChanged((IntPtr)state);
		}

		public ResourceViewManager.ResourceNameList SelectedItems
		{
			get
			{
				lock (names)
				{
					ResourceViewManager.ResourceNameList ret =
						new ResourceViewManager.ResourceNameList();
					foreach (int i in lv.SelectedIndices)
					{
						ret.Add(names[i]);
					}

					return ret;
				}
			}
		}

		protected virtual void OnResourceSelectionChanged()
		{
			resselchgea = new EventArgs();
			if (SelectionChanged != null)
			{
				if (noselectevent == 0)
				{
					SelectionChanged(this, resselchgea);
				}
			}
			if (noselectevent == 0)
			{
				resselchgea = null;
			}
			//PrintStats("***OnResourceSelectionChanged");
		}

		private void lv_Click(object sender, EventArgs e)
		{
			if (Helper.WindowsRegistry.Config.SimpleResourceSelect)
			{
				OnSelectResource();
			}
		}

		private void lv_MouseUp(object sender, MouseEventArgs e)
		{
			if (
				e.Button == MouseButtons.Middle /*&& names.Count>0*/
			)
			{
				bool old = ctrldown;
				ctrldown = true;
				ListViewItem lvi = lv.GetItemAt(e.X, e.Y);
				if (lvi != null)
				{
					BeginUpdate();
					lv.EnsureVisible(lvi.Index);
					lv.SelectedIndices.Clear();
					lv.SelectedIndices.Add(lvi.Index);
					OnSelectResource();
					EndUpdate();
				}

				ctrldown = old;
			}
		}

		private void lv_DoubleClick(object sender, EventArgs e)
		{
			if (!Helper.WindowsRegistry.Config.SimpleResourceSelect)
			{
				OnSelectResource();
			}
		}

		bool ctrldown = false;

		private void lv_KeyDown(object sender, KeyEventArgs e)
		{
			ctrldown = e.Alt;
		}

		public event KeyEventHandler ListViewKeyUp;

		private void lv_KeyUp(object sender, KeyEventArgs e)
		{
			ctrldown = e.Alt;

			if (
				!ctrldown
				&& (
					e.KeyCode == Keys.Up
					|| e.KeyCode == Keys.Down
					|| e.KeyCode == Keys.PageDown
					|| e.KeyCode == Keys.PageUp
					|| e.KeyCode == Keys.Home
					|| e.KeyCode == Keys.End
				)
			)
			{
				OnSelectResource();
			}

			if (e.KeyCode == Keys.Enter)
			{
				OnSelectResource();
			}

			if (e.KeyCode == Keys.A && e.Control)
			{
				SelectAll();
			}

			if (ListViewKeyUp != null)
			{
				ListViewKeyUp(this, e);
			}
		}

		public void SelectAll()
		{
			lock (names)
			{
				BeginUpdate();
				lv.SelectedIndices.Clear();
				for (int i = 0; i < names.Count; i++)
				{
					lv.SelectedIndices.Add(i);
				}

				EndUpdate();
			}
		}

		protected void OnSelectResource()
		{
			bool rctrl = ctrldown;
			if (!Helper.WindowsRegistry.Config.FirefoxTabbing)
			{
				rctrl = false;
			}

			selresea = new SelectResourceEventArgs(rctrl);
			if (SelectedResource != null)
			{
				if (noselectevent == 0)
				{
					SelectedResource(this, selresea);
				}
			}
			if (noselectevent == 0)
			{
				selresea = null;
			}
			//System.Diagnostics.Debug.WriteLine("Selection changed " + rctrl);
		}

		public class SelectResourceEventArgs : EventArgs
		{
			public bool CtrlDown
			{
				get;
			}

			internal SelectResourceEventArgs(bool ctrldn)
				: base()
			{
				CtrlDown = ctrldn;
			}
		}

		public delegate void SelectResourceHandler(
			ResourceListViewExt sender,
			SelectResourceEventArgs e
		);
		public event SelectResourceHandler SelectedResource;

		public Plugin.FileIndexItem SelectedItem
		{
			get
			{
				lock (names)
				{
					return lv.SelectedIndices.Count == 0 ? null : names[lv.SelectedIndices[0]].Resource;
				}
			}
		}

		public bool SelectResource(
			Interfaces.Scenegraph.IScenegraphFileIndexItem resource
		)
		{
			lock (names)
			{
				int ct = 0;
				foreach (NamedPackedFileDescriptor pfd in names)
				{
					if (pfd.Resource.FileDescriptor.Equals(resource.FileDescriptor))
					{
						BeginUpdate();
						lv.SelectedIndices.Clear();
						lv.SelectedIndices.Add(ct);
						lv.EnsureVisible(ct);
						EndUpdate();
						return true;
					}
					ct++;
				}
			}
			return false;
		}
	}
}
