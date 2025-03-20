using Avalonia.Controls;

namespace SimPe.Views.PackedFile.Ltxt
{
	public partial class LtxtPanel : UserControl
	{
		public LtxtPanel(Models.PackedFile.Ltxt.Ltxt ltxt)
		{
			DataContext = ltxt;
			InitializeComponent();
		}
	}
}
