// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Geometry;
using SimPe.Interfaces.Scenegraph;

namespace SimPe.Plugin
{
	/// <summary>
	/// Implemented common Methods of the ICresChildren Interface
	/// </summary>
	public abstract class AbstractCresChildren
		: AbstractRcolBlock,
			ICresChildren,
			IEnumerable,
			IEnumerator
	{
		public abstract string GetName();

		/// <summary>
		/// Constructor
		/// </summary>
		public AbstractCresChildren(Rcol parent)
			: base(parent)
		{
			Reset();
		}

		/// <summary>
		/// Returns the Child Block with the given Index from the Parent Rcol
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public ICresChildren GetBlock(int index)
		{
			return Parent != null
					&& index >= 0
					&& index < Parent.Blocks.Count
					&& Parent.Blocks[index] is ICresChildren children
				? children
				: null;
		}

		/// <summary>
		/// Get the Index Number of this Block in the Parent
		/// </summary>
		public int Index => parent != null ? parent.Blocks.IndexOf(this) : -1;

		/// <summary>
		/// Get List of al parent Blocks
		/// </summary>
		/// <returns></returns>
		public List<int> GetParentBlocks()
		{
			List<int> l = new List<int>();
			for (int i = 0; i < parent.Blocks.Count; i++)
			{
				if (parent.Blocks[i] is ICresChildren icc && icc.ChildBlocks.Contains(Index))
				{
					l.Add(i);
				}
			}
			return l;
		}

		/// <summary>
		/// Get the first Block that references this Block as a Child
		/// </summary>
		/// <returns></returns>
		public ICresChildren GetFirstParent()
		{
			List<int> l = GetParentBlocks();
			return l.Count == 0 ? null : (ICresChildren)parent.Blocks[l[0]];
		}

		/// <summary>
		/// Returns a List of all Child Blocks referenced by this Element
		/// </summary>
		public abstract List<int> ChildBlocks
		{
			get;
		}

		/// <summary>
		/// Returns an ImageIndex used to display the CRES Hirarchy
		/// </summary>
		public abstract int ImageIndex
		{
			get;
		}

		/// <summary>
		/// Returns the stored Transformation Node
		/// </summary>
		public abstract TransformNode StoredTransformNode
		{
			get;
		}

		/// <summary>
		/// Contains all bones that were seen during the recursin
		/// </summary>
		ArrayList seenbones;

		/// <summary>
		/// Walks the parent Hirarchy to calculate the absolute POsition for thsi Bone
		/// </summary>
		/// <param name="bs">List of known Bones</param>
		/// <param name="b">The bone you want o get the Absolute position for</param>
		/// <param name="v">The offset for the calculation</param>
		/// <param name="eo">ElementOrder we want to use</param>
		VectorTransformations GetAbsoluteTransformation(
			ICresChildren node,
			VectorTransformations v
		)
		{
			if (v == null)
			{
				v = new VectorTransformations();
			}

			if (node == null)
			{
				return v;
			}

			if (node.StoredTransformNode == null)
			{
				return v;
			}

			if (seenbones.Contains(node.Index))
			{
				return v;
			}

			seenbones.Add(node.Index);

			/*v.Rotation = node.StoredTransformNode.Rotation * v.Rotation;
			v.Rotation.MakeUnitQuaternion();

			v.Translation =
				node.StoredTransformNode.Rotation.Rotate(v.Translation + node.StoredTransformNode.Translation);					 */


			v.Add(node.StoredTransformNode.Transformation);
			v = GetAbsoluteTransformation(node.GetFirstParent(), v);

			return v;
		}

		/// <summary>
		/// Returns the effective Transformation, that is described by the CresHirarchy
		/// </summary>
		/// <returns></returns>
		public VectorTransformations GetHirarchyTransformations()
		{
			seenbones = new ArrayList();
			return GetAbsoluteTransformation(this, null);
		}

		/// <summary>
		/// Returns the effective Transformation, that is described by the CresHirarchy
		/// </summary>
		/// <returns></returns>
		public VectorTransformation GetEffectiveTransformation()
		{
			VectorTransformations list = GetHirarchyTransformations();
			VectorTransformation v = new VectorTransformation();

#if DEBUG
			System.IO.StreamWriter sw = System.IO.File.CreateText(@"G:\effect.txt");
#endif
			try
			{
#if DEBUG
				sw.WriteLine("-----------------------------------");
				sw.WriteLine("    " + v.ToString());
#endif
				VectorTransformation l = null;
				for (int i = list.Length - 1; i >= 0; i--)
				{
					VectorTransformation t = list[i];
					t.Rotation.MakeUnitQuaternion();

					v.Rotation *= t.Rotation;
					v.Translation =
						t.Rotation.Rotate(v.Translation)
						- t.Rotation.Rotate(t.Translation);
					//v.Rotation.MakeUnitQuaternion();


#if DEBUG
					sw.WriteLine("++++" + t.ToString() + " " + t.Name);
					sw.WriteLine("    " + v.ToString());
#endif

					l = t;
				}
			}
			finally
			{
#if DEBUG
				sw.Close();
				sw.Dispose();
				sw = null;
#endif
			}

			return v;
		}

		#region IEnumerable Member

		public IEnumerator GetEnumerator()
		{
			return this;
		}

		#endregion

		#region IEnumerator Member

		int pos;

		public void Reset()
		{
			pos = -1;
		}

		public object Current => pos < ChildBlocks.Count && pos >= 0 ? GetBlock(ChildBlocks[pos]) : (object)null;

		public bool MoveNext()
		{
			pos++;
			return pos < ChildBlocks.Count;
		}

		#endregion
	}
}
