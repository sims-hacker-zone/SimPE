// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections;

namespace Ambertation.Scenes.Collections
{
	public class JointHierarchyIteration : IEnumerator, IEnumerable
	{
		private Scene scn;

		private Stack jstack;

		private Stack jindex;

		protected Joint CurrentJoint
		{
			get
			{
				if (jstack.Count == 0)
				{
					return null;
				}

				return jstack.Peek() as Joint;
			}
		}

		protected int CurrentIndex
		{
			get
			{
				if (jindex.Count == 0)
				{
					return 0;
				}

				return (int)jindex.Peek();
			}
		}

		public object Current => CurrentJoint;

		internal JointHierarchyIteration(Scene s)
		{
			scn = s;
			jstack = new Stack();
			jindex = new Stack();
			Reset();
		}

		public bool MoveNext()
		{
			int currentIndex = CurrentIndex;
			if (CurrentJoint == null)
			{
				Reset();
				return false;
			}

			if (currentIndex >= CurrentJoint.Childs.Count)
			{
				jstack.Pop();
				jindex.Pop();
				if (jindex.Count == 0)
				{
					Reset();
					return false;
				}

				return MoveNext();
			}

			jindex.Pop();
			jindex.Push(currentIndex + 1);
			Joint obj = CurrentJoint.Childs[currentIndex];
			jstack.Push(obj);
			jindex.Push(0);
			return true;
		}

		public void Reset()
		{
			jstack.Clear();
			jindex.Clear();
			jstack.Push(scn.RootJoint);
			jindex.Push(0);
		}

		public IEnumerator GetEnumerator()
		{
			return this;
		}
	}
}
