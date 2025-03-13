// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

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
		public ImportedBone GetParentFrom(List<ImportedBone> bones)
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

		protected void FindBestFitJoint(List<GmdcJoint> joints)
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
}
