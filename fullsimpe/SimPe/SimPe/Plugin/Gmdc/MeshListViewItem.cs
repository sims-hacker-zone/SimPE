using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin.Gmdc
{
	class MeshListViewItem : ListViewItem, IDisposable
	{
		protected Ambertation.Scenes.Mesh mesh;
		protected GenericMeshImport gmi;
		ListViewEx parent;
		ComboBox cbact,
			cbgroup;
		CheckBox cbenv;
		public delegate void ActionChangedEvent(MeshListViewItem sender);
		ActionChangedEvent fkt;

		public MeshListViewItem(
			ListViewEx lv,
			Ambertation.Scenes.Mesh mesh,
			GenericMeshImport gmi,
			ActionChangedEvent fkt
		)
			: base()
		{
			this.fkt = fkt;
			parent = lv;
			this.mesh = mesh;
			this.gmi = gmi;

			cbact = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			cbact.SelectedIndexChanged += new EventHandler(cbact_SelectedIndexChanged);
			GenericMeshImport.ImportAction[] acts = (GenericMeshImport.ImportAction[])
				Enum.GetValues(typeof(GenericMeshImport.ImportAction));
			foreach (GenericMeshImport.ImportAction a in acts)
			{
				cbact.Items.Add(a);
			}

			cbact.SelectedItem = GenericMeshImport.ImportAction.Add;

			cbgroup = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			cbgroup.Items.Add("[" + Localization.GetString("none") + "]");
			foreach (GmdcGroup g in gmi.Gmdc.Groups)
			{
				cbgroup.Items.Add(g);
			}

			cbgroup.SelectedItem = 0;

			cbenv = new CheckBox
			{
				BackColor = Color.Transparent,
				Checked = mesh.Envelopes.Count > 0
			};

			int i = gmi.Gmdc.FindGroupByName(mesh.Name);
			if (i >= 0)
			{
				Group = gmi.Gmdc.Groups[i];
				Action = GenericMeshImport.ImportAction.Replace;
			}

			Setup();
			parent.Items.Add(this);
			parent.AddEmbeddedControl(cbact, 1, parent.Items.Count - 1);
			parent.AddEmbeddedControl(cbgroup, 2, parent.Items.Count - 1);
			parent.AddEmbeddedControl(cbenv, 5, parent.Items.Count - 1);
		}

		~MeshListViewItem()
		{
			Dispose();
		}

		public bool ImportEnvelope
		{
			get
			{
				return cbenv.Checked;
			}
			set
			{
				cbenv.Checked = value;
			}
		}

		public bool Shadow
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public GenericMeshImport.ImportAction Action
		{
			get
			{
				return (GenericMeshImport.ImportAction)cbact.SelectedItem;
			}
			set
			{
				cbact.SelectedItem = value;
			}
		}

		public new GmdcGroup Group
		{
			get
			{
				if (cbgroup.SelectedItem == null)
				{
					return null;
				}

				if (!(cbgroup.SelectedItem is GmdcGroup))
				{
					return null;
				}

				return cbgroup.SelectedItem as GmdcGroup;
			}
			set
			{
				if (value == null)
				{
					cbgroup.SelectedIndex = 0;
				}
				else
				{
					cbgroup.SelectedItem = value;
				}

				if (cbgroup.SelectedIndex < 0)
				{
					cbgroup.SelectedIndex = 0;
				}
			}
		}

		void Setup()
		{
			SubItems.Clear();
			Text = mesh.Name;
			SubItems.Add(Action.ToString()); //action
			if (Group != null)
			{
				SubItems.Add(Group.Name); //target
			}
			else
			{
				SubItems.Add("[" + Localization.GetString("none") + "]");
			}

			SubItems.Add(mesh.FaceIndices.Count.ToString());
			SubItems.Add(mesh.Vertices.Count.ToString());
			SubItems.Add("");
			SubItems.Add(mesh.Envelopes.Count.ToString());

			ForeColor = MyColor();
		}

		Color MyColor()
		{
			if (
				mesh.Vertices.Count
				> AbstractGmdcImporter.CRITICAL_VERTEX_AMOUNT
			)
			{
				return Color.Red;
			}

			if (
				mesh.FaceIndices.Count
				> AbstractGmdcImporter.CRITICAL_FACE_AMOUNT
			)
			{
				return Color.Red;
			}

			return Color.Black;
		}

		#region IDisposable Member

		public virtual void Dispose()
		{
			if (cbact != null)
			{
				cbact.SelectedIndexChanged -= new EventHandler(
					cbact_SelectedIndexChanged
				);
				cbact.Dispose();
			}
			cbact = null;

			if (cbgroup != null)
			{
				cbgroup.Dispose();
			}

			if (cbenv != null)
			{
				cbenv.Dispose();
			}

			parent = null;
			mesh = null;
			gmi = null;
			fkt = null;
		}

		#endregion


		private void cbact_SelectedIndexChanged(object sender, EventArgs e)
		{
			fkt(this);
		}
	}
}
