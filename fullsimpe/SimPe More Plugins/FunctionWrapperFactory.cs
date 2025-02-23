#define WRAPPER_PLUGIN

using System;
using SimPe.Interfaces;

namespace SimPe.Plugin
{
    public class FunctionWrapperFactory : SimPe.Interfaces.Plugin.AbstractWrapperFactory
	{
		#region AbstractWrapperFactory Member
		public override SimPe.Interfaces.IWrapper[] KnownWrappers
		{
			get 
			{
				IWrapper[] wrappers = {
										  new FunctionPackedFileWrapper()
									  };
				return wrappers;
			}
		}
		#endregion
    }
}
