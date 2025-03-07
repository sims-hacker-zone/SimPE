// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Geometry;

namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// This class contains all Data Needed to import one Bone (Joint)
	/// </summary>
	public class ImportedBone
	{
		/// <summary>
		/// Returns/Sets the action that should be performed
		/// </summary>
		public GmdcImporterAction Action
		{
			get; set;
		}

		/// <summary>
		/// If action is <see cref="GmdcImporterAction.Replace"/> or
		/// <see cref="GmdcImporterAction.Update"/> this Member stores the
		/// Index of the Target Joint (read/write)
		/// </summary>
		public int TargetIndex
		{
			get; set;
		}

		/// <summary>
		/// The name of the Imported Bone
		/// </summary>
		public string ImportedName
		{
			get; set;
		}

		/// <summary>
		/// The name of the Parent Bone
		/// </summary>
		public string ParentName
		{
			get; set;
		}

		/// <summary>
		/// The new Bone
		/// </summary>
		public GmdcJoint Bone
		{
			get;
		}

		/// <summary>
		/// The initial Transformation for this Joint
		/// </summary>
		public VectorTransformation Transformation
		{
			get; set;
		}

		/// <summary>
		/// Returns the color that should be used to display this Group in the "Import Groups" ListView
		/// </summary>
		public System.Drawing.Color MarkColor => Action == GmdcImporterAction.Nothing ? System.Drawing.Color.Silver : System.Drawing.Color.DarkBlue;

		/// <summary>
		/// Returns/Sets the scale Factor that should be applied to this group
		/// </summary>
		public float Scale
		{
			get; set;
		}

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="parent">The gmdc that should act as Parent</param>
		public ImportedBone(GeometryDataContainer parent)
		{
			Bone = new GmdcJoint(parent);
			ImportedName = "";
			ParentName = "";
			TargetIndex = -1;
			Action = GmdcImporterAction.Add;
			Transformation = new VectorTransformation(
				VectorTransformation.TransformOrder.TranslateRotate
			);

			Scale = (float)1.0;
		}

		/// <summary>
		/// Returns the PArent Bone or null if none was found
		/// </summary>
		/// <param name="bones">List of Bones, where we should look for Parents</param>
		/// <returns>null if no Parent is available or the Parent Bone</returns>
		public ImportedBone GetParentFrom(ImportedBones bones)
		{
			ParentName = ParentName.Trim();
			if (ParentName.Trim() == "")
			{
				return null;
			}

			foreach (ImportedBone b in bones)
			{
				if (b.ImportedName.Trim() == ParentName)
				{
					return b;
				}
			}

			return null;
		}

		/// <summary>
		/// Find a Joint with the same name as this one in tha passed GMDC, and set it as import Target
		/// </summary>
		/// <param name="gmdc"></param>
		public void FindBestFitJoint(GeometryDataContainer gmdc)
		{
			FindBestFitJoint(gmdc.Joints);
		}

		protected void FindBestFitJoint(GmdcJoints joints)
		{
			int ct = 0;
			foreach (GmdcJoint j in joints)
			{
				if (j.Name == ImportedName)
				{
					TargetIndex = ct;
					return;
				}
				ct++;
			}
		}
	}

	#region Container
	/// <summary>
	/// Typesave ArrayList for <see cref="ImportedGroup"/> Objects
	/// </summary>
	public class ImportedBones : ArrayList
	{
		/// <summary>
		/// Integer Indexer
		/// </summary>
		public new ImportedBone this[int index]
		{
			get => (ImportedBone)base[index];
			set => base[index] = value;
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public ImportedBone this[uint index]
		{
			get => (ImportedBone)base[(int)index];
			set => base[(int)index] = value;
		}

		/// <summary>
		/// add a new Element
		/// </summary>
		/// <param name="item">The object you want to add</param>
		/// <returns>The index it was added on</returns>
		public int Add(ImportedBone item)
		{
			return base.Add(item);
		}

		/// <summary>
		/// insert a new Element
		/// </summary>
		/// <param name="index">The Index where the Element should be stored</param>
		/// <param name="item">The object that should be inserted</param>
		public void Insert(int index, ImportedBone item)
		{
			base.Insert(index, item);
		}

		/// <summary>
		/// remove an Element
		/// </summary>
		/// <param name="item">The object that should be removed</param>
		public void Remove(ImportedBone item)
		{
			base.Remove(item);
		}

		/// <summary>
		/// Checks wether or not the object is already stored in the List
		/// </summary>
		/// <param name="item">The Object you are looking for</param>
		/// <returns>true, if it was found</returns>
		public bool Contains(ImportedBone item)
		{
			return base.Contains(item);
		}

		/// <summary>
		/// Number of stored Elements
		/// </summary>
		public int Length => Count;

		/// <summary>
		/// Create a clone of this Object
		/// </summary>
		/// <returns>The clone</returns>
		public override object Clone()
		{
			ImportedBones list = new ImportedBones();
			foreach (ImportedBone item in this)
			{
				list.Add(item);
			}

			return list;
		}
	}
	#endregion
}
