using System;

using Ambertation.Scenes;

namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// Summary description for GenericMeshImport.
	/// </summary>
	public class GenericMeshImport
	{
		public enum ImportAction
		{
			Ignore,
			Update,
			Replace,
			Add,
		}

		public enum JointImportAction
		{
			Ignore,
			Update,
		}

		MeshListViewItemExt[] meshes;
		BoneListViewItemExt[] bones;
		public bool ClearGroupsOnImport;

		internal void SetMeshList(MeshListViewItemExt[] m)
		{
			meshes = m;
		}

		internal void SetBoneList(BoneListViewItemExt[] b)
		{
			bones = b;
		}

		public GenericMeshImport(
			Scene scn,
			GeometryDataContainer gmdc,
			ElementOrder component
		)
		{
			Component = component;
			this.Scene = scn;
			this.Gmdc = gmdc;
			ClearGroupsOnImport = false;
		}

		public ElementOrder Component
		{
			get;
		}

		public Scene Scene
		{
			get;
		}

		public GeometryDataContainer Gmdc
		{
			get;
		}

		public bool Run()
		{
			Scene.ClearTags();
			meshes = new MeshListViewItemExt[0];
			bones = new BoneListViewItemExt[0];

			GenericImportForm.Execute(this);

			if (meshes.Length == 0)
			{
				return false;
			}

			if (this.ClearGroupsOnImport)
			{
				for (int i = Gmdc.Groups.Length - 1; i >= 0; i--)
				{
					Gmdc.RemoveGroup(i);
				}

				foreach (MeshListViewItemExt m in meshes)
				{
					m.Group = null;
				}
			}

			foreach (BoneListViewItemExt b in bones)
			{
				b.AssignVertices();
			}

			foreach (MeshListViewItemExt m in meshes)
			{
				m.BuildGroup();
			}

			Scene.ClearTags();
			return true;
		}
	}
}
