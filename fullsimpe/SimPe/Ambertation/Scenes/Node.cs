// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using Ambertation.Scenes.Collections;

namespace Ambertation.Scenes
{
	public class Node : Transformation, IEnumerable, IDisposable
	{
		protected Node parent;

		protected NodeCollectionBase childs;

		protected string name;

		protected Scene owner;

		private Transformation abspos;

		public Scene Owner => owner;

		public Transformation WorldPosition => abspos;

		public string Name
		{
			get
			{
				if (name == null)
				{
					return "";
				}

				return name;
			}
			set
			{
				name = value;
			}
		}

		public bool Root => parent == null;

		internal NodeCollectionBase NodeChilds => childs;

		internal Node(Node parent, Scene owner)
			: this(parent, "", owner)
		{
		}

		internal Node(Node parent, string name, Scene owner)
		{
			this.owner = owner;
			this.name = name;
			this.parent = parent;
			abspos = new Transformation();
		}

		internal void SetOwner(Scene scn)
		{
			foreach (Node child in childs)
			{
				child.SetOwner(scn);
			}

			owner = scn;
		}

		public IEnumerator GetEnumerator()
		{
			return childs.GetEnumerator();
		}

		internal void Clear(bool childs, bool dispose)
		{
			if (childs)
			{
				for (int i = 0; i < this.childs.Count; i++)
				{
					this.childs.GetItem(i).Clear(childs: true, dispose);
					this.childs.GetItem(i).Dispose();
				}
			}

			this.childs.Clear();
		}

		public virtual void Dispose()
		{
			owner = null;
			parent = null;
			parent = null;
			name = null;
			abspos = null;
			childs.Clear();
		}
	}
}
