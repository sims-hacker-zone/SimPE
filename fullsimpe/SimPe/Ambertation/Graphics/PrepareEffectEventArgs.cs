// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace Ambertation.Graphics
{
	public class PrepareEffectEventArgs : EventArgs
	{
		private MeshBox mb;

		public MeshBox MeshBox => mb;

		internal PrepareEffectEventArgs(MeshBox mb)
		{
			this.mb = mb;
		}
	}
}
