using SimPe.Interfaces;

namespace SimPe.Plugin
{
	public class MoreWrapperFactory : SimPe.Interfaces.Plugin.AbstractWrapperFactory
	{
		#region AbstractWrapperFactory Member
		public override SimPe.Interfaces.IWrapper[] KnownWrappers
		{
			get
			{
				if (
					Helper.StartedGui == Executable.Classic
					|| Helper.SimPeVersionLong < 330717003793
				) // requires updated simpe.workspace and GDF
				{
					return new IWrapper[0];
				}
				else
				{
					IWrapper[] wrappers =
					{
						new SimindexPackedFileWrapper(),
						new FunctionPackedFileWrapper(),
						new SimpleTextPackedFileWrapper(),
						new SimmyListPackedFileWrapper(),
						new HugBugPackedFileWrapper(),
						new AudioRefPackedFileWrapper(),
						new InvenIndexPackedFileWrapper(),
						new InventItemPackedFileWrapper(),
						new WinfoPackedFileWrapper(),
						new LotexturePackedFileWrapper(),
						new CregPackedFileWrapper(),
						new WallLayerPackedFileWrapper(),
						new StringMapPackedFileWrapper(),
					};
					return wrappers;
				}
			}
		}
		#endregion
	}
}
