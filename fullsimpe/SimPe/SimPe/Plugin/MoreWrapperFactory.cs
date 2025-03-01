// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Interfaces;

namespace SimPe.Plugin
{
	public class MoreWrapperFactory : Interfaces.Plugin.AbstractWrapperFactory
	{
		#region AbstractWrapperFactory Member
		public override IWrapper[] KnownWrappers => new IWrapper[0];
		#endregion
	}
}
