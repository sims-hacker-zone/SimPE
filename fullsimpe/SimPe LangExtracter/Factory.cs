using System;
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	public class WrapperFactory : SimPe.Interfaces.Plugin.AbstractWrapperFactory, SimPe.Interfaces.Plugin.IToolFactory
	{
		#region AbstractWrapperFactory Member
		public override SimPe.Interfaces.IWrapper[] KnownWrappers
		{
			get 
			{
				IWrapper[] wrappers = {};
				return wrappers;
			}
		}
		#endregion

		#region IToolFactory Member
		public IToolPlugin[] KnownTools
		{
			get
            {
                return new IToolPlugin[] { new ExtractTool(this.LinkedRegistry, this.LinkedProvider) };
			}
		}
        #endregion
	}
}