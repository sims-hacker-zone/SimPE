// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using Ambertation.Scenes.Collections;

namespace Ambertation.Scenes
{
	public class Scene : IDisposable
	{
		private Node rm;

		private MaterialCollection mats;

		private Joint rj;

		private Material defmat;

		private JointHierarchyIteration jlist;

		private MeshHierarchyIteration mlist;

		public JointHierarchyIteration JointCollection => jlist;

		public MeshHierarchyIteration MeshCollection => mlist;

		public MaterialCollection MaterialCollection
		{
			get
			{
				if (!mats.Contains(defmat))
				{
					mats.Add(defmat);
				}

				return mats;
			}
		}

		public Material DefaultMaterial => defmat;

		public Joint RootJoint => rj;

		public Mesh SceneRoot => rm as Mesh;

		public Scene()
		{
			mats = new MaterialCollection();
			defmat = new Material("default.material");
			rj = new Joint(null, "root", this);
			jlist = new JointHierarchyIteration(this);
			rm = new Mesh(null, "scene_root", defmat, this);
			mlist = new MeshHierarchyIteration(this);
		}

		public Mesh CreateMesh(string name)
		{
			return SceneRoot.CreateMesh(name);
		}

		public Mesh CreateMesh(string name, Material mat)
		{
			return SceneRoot.CreateMesh(name, mat);
		}

		public Material CreateMaterial(string name)
		{
			Material material = new Material(name);
			mats.Add(material);
			return material;
		}

		public void ClearTags()
		{
			RootJoint.ClearTag(child: true);
			foreach (Material item in MaterialCollection)
			{
				item.Tag = null;
			}

			foreach (Mesh item2 in MeshCollection)
			{
				item2.ClearTags();
			}
		}

		public void Merge(Scene scn, string prefix)
		{
			Merge(scn, prefix, null);
		}

		public void Merge(Scene scn, string prefix, Transformation world)
		{
			RootJoint.SetOwner(scn);
			foreach (Joint item in scn.JointCollection)
			{
				item.Name = prefix + item.Name;
			}

			foreach (Joint child in scn.RootJoint.Childs)
			{
				RootJoint.Childs.DoAdd(child);
			}

			foreach (Material item2 in scn.MaterialCollection)
			{
				item2.Name = prefix + item2.Name;
				MaterialCollection.Add(item2);
			}

			scn.SceneRoot.SetOwner(this);
			if (world == null)
			{
				foreach (Mesh item3 in scn.SceneRoot)
				{
					item3.Name = prefix + item3.Name;
					SceneRoot.Childs.DoAdd(item3);
				}

				return;
			}

			Mesh mesh2 = CreateMesh(prefix + "scene_root");
			mesh2.Translation = world.Translation;
			mesh2.Rotation = world.Rotation;
			mesh2.Scaling = world.Scaling;
			foreach (Mesh item4 in scn.SceneRoot)
			{
				item4.Name = prefix + item4.Name;
				mesh2.Childs.DoAdd(item4);
			}
		}

		public void Dispose()
		{
			if (rm != null)
			{
				rm.Clear(childs: true, dispose: true);
				rm.Dispose();
			}

			rm = null;
			defmat = null;
			if (mats != null)
			{
				for (int i = 0; i < mats.Count; i++)
				{
					mats[i].Dispose();
				}

				mats.Clear();
			}

			mats = null;
			if (rj != null)
			{
				rj.Clear(childs: true, dispose: true);
				rj.Dispose();
			}

			rj = null;
			jlist = null;
		}
	}
}
