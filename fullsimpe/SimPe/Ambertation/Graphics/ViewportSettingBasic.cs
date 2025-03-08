// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.ComponentModel;
using Microsoft.DirectX.Direct3D;

namespace Ambertation.Graphics
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class ViewportSettingBasic
	{
		public enum FillModes
		{
			Default,
			Solid,
			WireframeOverlay,
			Wireframe,
			Point
		}

		protected bool autoaxismesh;

		protected bool usespec;

		protected bool uselight;

		protected bool joints;

		protected bool allowscr;

		protected bool txtr;

		protected bool bb;

		protected ShadeMode smode;

		protected FillModes fm;

		protected float jsz;

		private bool fstate;

		private bool fattr;

		private bool eventpause;

		[Category("Settings")]
		public bool EnableTextures
		{
			get
			{
				return txtr;
			}
			set
			{
				if (txtr != value)
				{
					txtr = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Settings")]
		public bool RenderBoundingBoxes
		{
			get
			{
				return bb;
			}
			set
			{
				if (bb != value)
				{
					bb = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Settings")]
		public FillModes FillMode
		{
			get
			{
				return fm;
			}
			set
			{
				if (fm != value)
				{
					fm = value;
					FireStateChangeEvent();
				}
			}
		}

		[Browsable(false)]
		[Category("Settings")]
		public bool AllowSettingsDialog
		{
			get
			{
				return allowscr;
			}
			set
			{
				if (allowscr != value)
				{
					allowscr = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Settings")]
		public bool RenderJoints
		{
			get
			{
				return joints;
			}
			set
			{
				if (joints != value)
				{
					joints = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Settings")]
		public bool EnableSpecularHighlights
		{
			get
			{
				return usespec;
			}
			set
			{
				if (usespec != value)
				{
					usespec = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Settings")]
		public bool EnableLights
		{
			get
			{
				return uselight;
			}
			set
			{
				if (uselight != value)
				{
					uselight = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Settings")]
		public ShadeMode ShadeMode
		{
			get
			{
				return smode;
			}
			set
			{
				if (smode != value)
				{
					smode = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Settings")]
		public bool AddAxis
		{
			get
			{
				return autoaxismesh;
			}
			set
			{
				if (autoaxismesh != value)
				{
					autoaxismesh = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Settings")]
		public float JointScale
		{
			get
			{
				return jsz;
			}
			set
			{
				if (jsz != value)
				{
					jsz = value;
					FireStateChangeEvent();
				}
			}
		}

		public event EventHandler ChangedAttribute;

		public event EventHandler ChangedState;

		internal ViewportSettingBasic(DirectXPanel parent)
		{
			txtr = true;
			fm = FillModes.Default;
			allowscr = true;
			joints = true;
			uselight = true;
			usespec = true;
			smode = ShadeMode.Phong;
			autoaxismesh = true;
			jsz = 10f;
			bb = false;
			eventpause = false;
		}

		protected void FireStateChangeEvent()
		{
			if (!eventpause)
			{
				if (this.ChangedState != null)
				{
					this.ChangedState(this, new EventArgs());
				}
			}
			else
			{
				fstate = true;
			}
		}

		protected void FireAttributeChangeEvent()
		{
			if (!eventpause)
			{
				if (this.ChangedAttribute != null)
				{
					this.ChangedAttribute(this, new EventArgs());
				}
			}
			else
			{
				fattr = true;
			}
		}

		public void BeginUpdate()
		{
			fstate = false;
			fattr = false;
			eventpause = true;
		}

		public void EndUpdate()
		{
			EndUpdate(fattr, fstate);
		}

		public void EndUpdate(bool fireattr, bool firestat)
		{
			eventpause = false;
			fstate = false;
			fattr = false;
			if (fireattr && firestat)
			{
				FireStateChangeEvent();
			}
			else if (fireattr)
			{
				FireAttributeChangeEvent();
			}
			else if (firestat)
			{
				FireStateChangeEvent();
			}
		}
	}
}
