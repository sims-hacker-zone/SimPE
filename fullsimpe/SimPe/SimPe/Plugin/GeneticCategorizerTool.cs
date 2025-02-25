using System;
using System.Drawing;
using System.Threading;
using SimPe.Interfaces;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.Plugin.UI;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for GeneticCategorizerTool.
	/// </summary>
	public class GeneticCategorizerTool : AbstractTool, IToolPlugin, ITool
	{
		#region IToolPlugin Members

		public override string ToString()
		{
			return "Object Creation\\Colour Binning Tool";
		}

		#endregion

		public override bool Visible
		{
			get { return true; }
		}

		#region ITool Members

		public bool IsEnabled(IPackedFileDescriptor pfd, IPackageFile package)
		{
			return true;
		}

		public IToolResult ShowDialog(
			ref IPackedFileDescriptor pfd,
			ref IPackageFile package
		)
		{
			// EnsureFileTable();
			MainForm form = new MainForm();
			form.Show();

			return new ToolResult(false, false);
		}

		#endregion

		public override System.Drawing.Image Icon
		{
			get
			{
				return System.Drawing.Image.FromStream(
					this.GetType()
						.Assembly.GetManifestResourceStream(
							"SimPe.img.ColorBinningTool.png"
						)
				);
			}
		}
	}
}
