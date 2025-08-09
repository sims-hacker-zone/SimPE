using Avalonia.Controls;

namespace SimPe.Sims2.Views.Resource.Ltxt;

public partial class LtxtPanel : UserControl
{
	public LtxtPanel(Models.Resource.Ltxt.Ltxt ltxt)
	{
		DataContext = ltxt;
		InitializeComponent();
	}
}
