namespace SimPe.Windows.Forms
{
	public interface IResourceTreeNodeBuilder
	{
		ResourceTreeNodeExt BuildNodes(ResourceMaps maps);
		ulong LastSelectedId
		{
			get; set;
		}
	}
}
