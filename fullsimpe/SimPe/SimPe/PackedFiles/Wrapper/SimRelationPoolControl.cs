using System;
using System.ComponentModel;
using System.Drawing;

namespace SimPe.PackedFiles.Wrapper
{
	[DefaultEvent("SelectedSimChanged")]
	public partial class SimRelationPoolControl : SimPoolControl
	{
		static Image RelatedImage;

		public SimRelationPoolControl()
		{
			if (RelatedImage == null)
			{
				RelatedImage = Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.related.png")
				);
			}

			InitializeComponent();
			showrel = true;
			cbRelation.Checked = showrel;

			shownorel = false;
			cbNoRelation.Checked = shownorel;
			intern = false;

			panel1.SendToBack();
			cbhousehold.SendToBack();
			RightClickSelect = true;
		}

		public void UpdateIcon()
		{
			Image img = UpdateIcon(SelectedSim);
			if (img != null && gp.SelectedItems.Count > 0)
			{
				gp.SelectedItems[0].ImageList.Images[gp.SelectedItems[0].ImageIndex] =
					img;
				gp.Refresh();
			}
		}

		protected Image UpdateIcon(ExtSDesc sdsc)
		{
			if (sim != null && sdsc != null)
			{
				Image img = SimListView.BuildSimPreviewImage(
					sdsc,
					GetBackgroundColor(sdsc)
				);
				bool hr = sim.HasRelationWith(sdsc);
				if (hr)
				{
					MakeRelationIcon(img);
				}

				return img;
			}
			return null;
		}

		protected override void OnAddSimToPool(AddSimToPoolEventArgs e)
		{
			if (sim != null)
			{
				bool hr = sim.HasRelationWith(e.SimDescription);
				bool res = false;
				if (hr && showrel)
				{
					res = true;
				}
				else if (!hr && shownorel)
				{
					res = true;
				}

				if (hr)
				{
					MakeRelationIcon(e.Image);
					e.GroupIndex = 0;
				}
				else
				{
					e.GroupIndex = 1;
				}

				if (
					e.SimDescription.FileDescriptor.Instance
					== sim.FileDescriptor.Instance
				)
				{
					res = false;
				}

				if (!res)
				{
					e.Cancel = true;
				}
			}
			base.OnAddSimToPool(e);
		}

		private static void MakeRelationIcon(Image img)
		{
			Graphics g = Graphics.FromImage(img);
			g.DrawImageUnscaled(RelatedImage, 0, 0, 16, 16);
		}

		bool intern;

		bool showrel,
			shownorel;
		public bool ShowRelatedSims
		{
			get
			{
				return showrel;
			}
			set
			{
				if (value != showrel)
				{
					showrel = value;
					UpdateSimList();
					intern = true;
					cbRelation.Checked = value;
					intern = false;
				}
			}
		}

		public bool ShowNotRelatedSims
		{
			get
			{
				return shownorel;
			}
			set
			{
				if (value != shownorel)
				{
					shownorel = value;
					UpdateSimList();
					intern = true;
					cbNoRelation.Checked = value;
					intern = false;
				}
			}
		}

		[Browsable(false)]
		public bool FilteredBySim => !ShowNotRelatedSims || !ShowRelatedSims;

		ExtSDesc sim;

		[Browsable(false)]
		public ExtSDesc Sim
		{
			get
			{
				return sim;
			}
			set
			{
				// It seems that once set, "sim" somehow tracks "value"
				if (sim != value)
				{
					sim = value;
				}
				// So we do this anyway...
				if (FilteredBySim && Package != null)
				{
					UpdateSimList();
				}
			}
		}

		private void cbNoRelation_CheckedChanged(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			ShowNotRelatedSims = cbNoRelation.Checked;
		}

		private void cbRelation_CheckedChanged(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			ShowRelatedSims = cbRelation.Checked;
		}
	}
}
