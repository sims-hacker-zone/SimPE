// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.Plugin;

namespace SimPe.Interfaces.Scenegraph
{
	/// <summary>
	/// Implemented by Blocks available in a CRES Hirarchy to link to child Blocks
	/// </summary>
	public interface ICresChildren : System.Collections.IEnumerable
	{
		/// <summary>
		/// Returns a List of all Child Blocks referenced by this Element
		/// </summary>
		List<int> ChildBlocks
		{
			get;
		}

		/// <summary>
		/// Returns the Index of this node within it's Parent (-1 if not found)
		/// </summary>
		int Index
		{
			get;
		}

		/// <summary>
		/// Returns a List of all Parent Nodes
		/// </summary>
		List<int> GetParentBlocks();

		/// <summary>
		/// Returns the First Block that is holds this Node as a Child
		/// </summary>
		/// <returns></returns>
		ICresChildren GetFirstParent();

		/// <summary>
		/// Returns the TransformNode Object of this Node (can be null!)
		/// </summary>
		TransformNode StoredTransformNode
		{
			get;
		}

		/// <summary>
		/// Returns the parent RCol Container
		/// </summary>
		Rcol Parent
		{
			get;
		}

		/// <summary>
		/// Returns the Child Block with the given Index from the Parent Rcol
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		ICresChildren GetBlock(int index);

		/// <summary>
		/// Returns the Index of the Image that should be displayed in the TreeView
		/// </summary>
		/// <remarks>
		/// 0 = Nothing
		/// 1 = Joint
		/// 2 = Light
		/// 3 = Shape
		/// 4 = Error
		/// </remarks>
		int ImageIndex
		{
			get;
		}

		/// <summary>
		/// Returns the effective Transformation, that is described by the CresHirarchy
		/// </summary>
		/// <returns>Effective Transformation</returns>
		Geometry.VectorTransformation GetEffectiveTransformation();

		string GetName();
	}
}
