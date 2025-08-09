using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Sims2.Models.Resource.Sdsc;

public partial class SdscPersonality : ObservableObject
{
	[ObservableProperty] private ushort nice;

	[ObservableProperty] private ushort active;

	[ObservableProperty] private ushort playful;

	[ObservableProperty] private ushort outgoing;

	[ObservableProperty] private ushort neat;
}
