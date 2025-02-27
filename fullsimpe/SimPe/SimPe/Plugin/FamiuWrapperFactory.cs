#define WRAPPER_PLUGIN

using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Lists all Plugins (=FileType Wrappers) available in this Package
	/// </summary>
	/// <remarks>
	/// GetWrappers() has to return a list of all Plugins provided by this Library.
	/// If a Plugin isn't returned, SimPe won't recognize it!
	/// </remarks>
	public class FamiuWrapperFactory : SimPe.Interfaces.Plugin.AbstractWrapperFactory //This Interface allows your Plugin to offer packed File Wrappers
	{
		#region AbstractWrapperFactory Member
		/// <summary>
		/// Returns a List of all available Plugins in this Package
		/// </summary>
		/// <returns>A List of all provided Plugins (=FileType Wrappers)</returns>
		public override SimPe.Interfaces.IWrapper[] KnownWrappers
		{
			get
			{
				if (
					Helper.StartedGui == Executable.Classic
					|| Helper.SimPeVersionLong < 330717003785
				) // requires updated GDF
				{
					return new IWrapper[0];
				}
				else
				{
					IWrapper[] wrappers = { new FamiuPackedFileWrapper() };
					return wrappers;
				}
			}
		}

		#endregion
	}
}
