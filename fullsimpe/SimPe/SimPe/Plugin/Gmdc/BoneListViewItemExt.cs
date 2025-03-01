// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Windows.Forms;

namespace SimPe.Plugin.Gmdc
{
	class BoneListViewItemExt : BoneListViewItem
	{
		public BoneListViewItemExt(
			ListViewEx lv,
			Ambertation.Scenes.Joint joint,
			GenericMeshImport gmi,
			ActionChangedEvent fkt
		)
			: base(lv, joint, gmi, fkt) { }

		public void AssignVertices()
		{
			joint.Tag = -1;
			if (
				Joint == null
				&& Action == GenericMeshImport.JointImportAction.Update
			)
			{
				Action = GenericMeshImport.JointImportAction.Ignore;
			}

			if (Action == GenericMeshImport.JointImportAction.Ignore)
			{
				return;
			}

			joint.Tag = Joint.Index;
		}

		#region IDisposable Member

		public override void Dispose()
		{
			base.Dispose();
		}

		#endregion
	}
}
