// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.Scenes.Collections
{
	public class MeshCollection : NodeCollectionBase
	{
		public Mesh this[int index] => GetItem(index) as Mesh;

		public Mesh this[string name] => GetItem(name) as Mesh;

		internal Mesh CreateMesh(Mesh parent, Scene scn, string name)
		{
			return CreateMesh(parent, scn, name, scn.DefaultMaterial);
		}

		internal Mesh CreateMesh(Mesh parent, Scene scn, string name, Material mat)
		{
			Mesh mesh = new Mesh(parent, name, mat, scn);
			DoAdd(mesh);
			return mesh;
		}
	}
}
