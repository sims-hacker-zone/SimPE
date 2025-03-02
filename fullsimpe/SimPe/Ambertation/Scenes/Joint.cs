// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Xml.Linq;

using Ambertation.Scenes.Collections;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Ambertation.Scenes
{
	public class Joint : Node
	{
		public Joint Parent => parent as Joint;

		public JointCollectionBase Childs => childs as JointCollectionBase;

		internal Joint(Joint parent, Scene owner)
			: this(parent, "", owner)
		{
		}

		internal Joint(Joint parent, string name, Scene owner)
			: base(parent, name, owner)
		{
			childs = new JointCollectionBase();
		}

		public Joint CreateChild()
		{
			return CreateChild("");
		}

		public Joint CreateChild(string name)
		{
			Joint joint = new Joint(this, name, owner);
			childs.DoAdd(joint);
			return joint;
		}

		public int GetAssignedVertexCount()
		{
			int num = 0;
			foreach (Mesh item in owner.MeshCollection)
			{
				foreach (Envelope envelope in item.Envelopes)
				{
					if (envelope.Joint != this)
					{
						continue;
					}

					foreach (double weight in envelope.Weights)
					{
						if (weight > 0.0)
						{
							num++;
						}
					}
				}
			}

			return num;
		}

		public override string ToString()
		{
			return base.Name + " [" + GetType().Name + "]";
		}

		public void ClearTag(bool child)
		{
			base.Tag = null;
			if (!child)
			{
				return;
			}

			foreach (Joint child2 in childs)
			{
				child2.ClearTag(child: true);
			}
		}

		public Joint FindJoint(string name)
		{
			foreach (Joint child in childs)
			{
				if (child.Name == name)
				{
					return child;
				}

				Joint joint2 = child.FindJoint(name);
				if (joint2 != null)
				{
					return joint2;
				}
			}

			return null;
		}

		public override int GetHashCode()
		{
			return name.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is Joint)
			{
				return name == ((Joint)obj).name;
			}

			return base.Equals(obj);
		}
	}
}
