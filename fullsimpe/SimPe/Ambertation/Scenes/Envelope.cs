// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using Ambertation.Collections;

namespace Ambertation.Scenes
{
	public class Envelope : IDisposable
	{
		private DoubleCollection w;

		private Joint j;

		private Mesh m;

		private object tag;

		public Mesh Mesh => m;

		public Joint Joint => j;

		public DoubleCollection Weights => w;

		public object Tag
		{
			get
			{
				return tag;
			}
			set
			{
				tag = value;
			}
		}

		internal Envelope(Joint j, Mesh m)
		{
			this.j = j;
			this.m = m;
			w = new DoubleCollection();
		}

		internal void ForceLength(int len)
		{
			while (w.Count < len)
			{
				w.Add(0.0);
			}
		}

		public void Dispose()
		{
			j = null;
			m = null;
			if (w != null)
			{
				w.Clear();
			}

			w = null;
		}
	}
}
