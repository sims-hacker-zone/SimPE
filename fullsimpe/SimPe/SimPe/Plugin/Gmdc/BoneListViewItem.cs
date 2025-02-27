using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin.Gmdc
{
	class BoneListViewItem : ListViewItem, IDisposable
	{
		protected Ambertation.Scenes.Joint joint;
		protected GenericMeshImport gmi;
		ListViewEx parent;
		ComboBox cbact,
			cbgroup;

		public delegate void ActionChangedEvent(BoneListViewItem sender);
		ActionChangedEvent fkt;

		public BoneListViewItem(
			ListViewEx lv,
			Ambertation.Scenes.Joint joint,
			GenericMeshImport gmi,
			ActionChangedEvent fkt
		)
			: base()
		{
			this.fkt = fkt;
			parent = lv;
			this.joint = joint;
			this.gmi = gmi;

			cbact = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			cbact.SelectedIndexChanged += new EventHandler(cbact_SelectedIndexChanged);
			GenericMeshImport.JointImportAction[] acts =
				(GenericMeshImport.JointImportAction[])
					Enum.GetValues(typeof(GenericMeshImport.JointImportAction));
			foreach (GenericMeshImport.JointImportAction a in acts)
			{
				cbact.Items.Add(a);
			}

			cbact.SelectedItem = GenericMeshImport.JointImportAction.Ignore;

			cbgroup = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			cbgroup.Items.Add("[" + Localization.GetString("none") + "]");
			foreach (GmdcJoint j in gmi.Gmdc.Joints)
			{
				cbgroup.Items.Add(j);
			}

			cbgroup.SelectedItem = 0;

			int i = gmi.Gmdc.FindJointByName(joint.Name);
			if (i >= 0)
			{
				Joint = gmi.Gmdc.Joints[i];
				Action = GenericMeshImport.JointImportAction.Update;
			}

			Setup();
			parent.Items.Add(this);
			parent.AddEmbeddedControl(cbact, 1, parent.Items.Count - 1);
			parent.AddEmbeddedControl(cbgroup, 2, parent.Items.Count - 1);
		}

		~BoneListViewItem()
		{
			Dispose();
		}

		public GenericMeshImport.JointImportAction Action
		{
			get
			{
				return (GenericMeshImport.JointImportAction)cbact.SelectedItem;
			}
			set
			{
				cbact.SelectedItem = value;
			}
		}

		public GmdcJoint Joint
		{
			get
			{
				if (cbgroup.SelectedItem == null)
				{
					return null;
				}

				if (!(cbgroup.SelectedItem is GmdcJoint))
				{
					return null;
				}

				return cbgroup.SelectedItem as GmdcJoint;
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
			Text = joint.Name;
			SubItems.Add(Action.ToString()); //action
			if (Joint != null)
			{
				SubItems.Add(Joint.Name); //target
			}
			else
			{
				SubItems.Add("[" + Localization.GetString("none") + "]");
			}

			SubItems.Add(joint.GetAssignedVertexCount().ToString());

			ForeColor = MyColor();
		}

		Color MyColor()
		{
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

			parent = null;
			joint = null;
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
