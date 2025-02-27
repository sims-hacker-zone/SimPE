namespace SimPe.Windows.Forms
{
	public class ListViewDoubleBuffered : System.Windows.Forms.ListView
	{
		public ListViewDoubleBuffered()
			: base()
		{
			SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
		}
	}
}
