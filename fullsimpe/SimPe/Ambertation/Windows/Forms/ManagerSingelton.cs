// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Ambertation.Renderer;

namespace Ambertation.Windows.Forms
{
	public class ManagerSingelton : IMessageFilter
	{
		private static ManagerSingelton glob;

		private DockPanel startdrag;

		private NCMouseEventArgs events;

		private DockButtonBar.DockPanelList known;

		private List<DockPanelFloatingForm> knownf;

		private bool topmostfloats;

		private BaseRenderer dock;

		private BaseRenderer tab;

		private DockManager dm;

		private int pnid;

		public static ManagerSingelton Global
		{
			get
			{
				if (glob == null)
				{
					glob = new ManagerSingelton();
				}

				return glob;
			}
		}

		public bool TopmostFloats
		{
			get
			{
				return topmostfloats;
			}
			set
			{
				topmostfloats = value;
			}
		}

		public BaseRenderer DockRenderer => dock;

		public BaseRenderer TabRenderer => tab;

		public DockManager MainDockManager => dm;

		public bool HasDragPanelForMouseMove => startdrag != null;

		private ManagerSingelton()
		{
			topmostfloats = false;
			pnid = 0;
			dm = null;
			known = new DockButtonBar.DockPanelList();
			startdrag = null;
			Application.AddMessageFilter(this);
			dock = new GlossyRenderer();
			knownf = new List<DockPanelFloatingForm>();
			tab = new WhidbeyTabRenderer();
		}

		~ManagerSingelton()
		{
			Application.RemoveMessageFilter(this);
		}

		internal void SetMainManager(DockManager m)
		{
			if (dm == null)
			{
				dm = m;
			}
		}

		internal void AddFloatForm(DockPanelFloatingForm f)
		{
			if (!knownf.Contains(f))
			{
				knownf.Add(f);
				f.Disposed += f_Disposed;
			}
		}

		private void f_Disposed(object sender, EventArgs e)
		{
			DockPanelFloatingForm f = sender as DockPanelFloatingForm;
			RemoveFloatForm(f);
		}

		internal void RemoveFloatForm(DockPanelFloatingForm f)
		{
			if (knownf.Contains(f))
			{
				f.Disposed -= f_Disposed;
				knownf.Remove(f);
			}
		}

		internal void AddPanel(DockPanel dp)
		{
			if (!known.Contains(dp))
			{
				known.Add(dp);
				dp.Disposed += dp_Disposed;
				if (dp.Name == "")
				{
					dp.Name = "ManagedDockPanel" + pnid;
					pnid++;
				}
			}
		}

		private void dp_Disposed(object sender, EventArgs e)
		{
			DockPanel dp = sender as DockPanel;
			RemovePanel(dp);
		}

		internal void RemovePanel(DockPanel dp)
		{
			if (known.Contains(dp))
			{
				dp.Disposed -= dp_Disposed;
				known.Remove(dp);
			}
		}

		public DockPanel GetPanelWithName(string name)
		{
			foreach (DockPanel item in known)
			{
				if (item.Name == name)
				{
					return item;
				}
			}

			return null;
		}

		public void SetDragPanelOnMouseMove(DockPanel p, NCMouseEventArgs e)
		{
			events = e;
			if (startdrag == null)
			{
				startdrag = p;
			}
		}

		public void ResetDragPanelOnMouseMove()
		{
			startdrag = null;
			events = null;
		}

		public bool PreFilterMessage(ref Message m)
		{
			if (m.Msg == 28)
			{
				Console.WriteLine(m.Msg.ToString("X") + " " + m.WParam + " " + m.LParam);
				foreach (DockPanelFloatingForm item in knownf)
				{
					item.SendeActivateEvent((int)m.WParam != 0);
				}
			}
			else if (m.Msg == 49395)
			{
				Console.WriteLine(m.Msg.ToString("X") + " " + m.WParam + " " + m.LParam);
				if (m.LParam.ToInt32() == 0 && (m.WParam.ToInt32() == 1 || m.WParam.ToInt32() == 0))
				{
					foreach (DockPanelFloatingForm item2 in knownf)
					{
						item2.SendeActivateEvent((int)m.WParam == 0);
					}
				}
			}

			if (startdrag != null)
			{
				if (m.Msg == 514 || m.Msg == 162)
				{
					ResetDragPanelOnMouseMove();
				}

				if (m.Msg == 512)
				{
					startdrag.StartDockModeFloat(events);
					ResetDragPanelOnMouseMove();
				}
			}

			return false;
		}
	}
}
