// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

using SimPe.Extensions;
using SimPe.Geometry;
using SimPe.Plugin.Anim;

namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// Implement this abstract class to create a new Gmdc Importer Plugin, however
	/// you can also base your new Importer on <see cref="GmdcImporterBase"/>, which
	/// offers a more simple Interface, as you only have to implement the
	/// reading of the vertice, normals... Data
	/// </summary>
	/// <remarks>
	/// SimPe offers diffrent Importer Abstraction classes. The most common
	/// one is AbstractGmdcImporter. It is used whenever you just want to
	/// import/overwrite Mesh Groups (vertext data...) but want to leave the
	/// rest of the Gmdc File alone.
	///
	/// However, if you want to create a complete new (or altered) gmdc File
	/// you need to implement the IGmdcReplacementImporter.
	/// </remarks>
	public abstract class AbstractGmdcImporter : IGmdcImporter
	{
		/// <summary>
		/// what is a small Number?
		/// </summary>
		public const double SMALLNUMBER = 1e-300;

		/// <summary>
		/// Returns the Culture that should be used during the Import
		/// </summary>
		/// <remarks>The Culure is needed whenever you read floatingpoint
		/// Values from a Text File</remarks>
		public static CultureInfo DefaultCulture => AbstractGmdcExporter.DefaultCulture;

		/// <summary>
		/// Good Objects should not have more than this number of Faces
		/// </summary>
		public const int CRITICAL_FACE_AMOUNT = 5000;

		/// <summary>
		/// Good Objects should not have more than this number of Vertices
		/// </summary>
		public const int CRITICAL_VERTEX_AMOUNT = 2000;

		/// <summary>
		/// Returns a Version Number for the used Interface
		/// </summary>
		public int Version => 1;

		/// <summary>
		/// Convert the passed string to a double Value
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		protected static float ToSingle(string s)
		{
			float d = Convert.ToSingle(s, DefaultCulture);
			if (Math.Abs(d) < SMALLNUMBER)
			{
				d = 0;
			}

			return d;
		}

		/// <summary>
		/// Which Order is used for the Components
		/// </summary>
		public ElementOrder Component
		{
			get; set;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public AbstractGmdcImporter()
		{
			Component = new ElementOrder(ElementSorting.XZY);
			AnimationBlocks = new ImportedFrameBlocks
			{
				AuskelCorrection = Helper
				.WindowsRegistry
				.Config.CorrectJointDefinitionOnExport
			};
		}

		#region abstract Methods
		/// <summary>
		/// Returns the suggested File Extension (including the . like .obj or .3ds)
		/// </summary>
		public abstract string FileExtension
		{
			get;
		}

		/// <summary>
		/// Returns the File Description (the Name of the exported FileType)
		/// </summary>
		public abstract string FileDescription
		{
			get;
		}

		/// <summary>
		/// Returns the name of the Author
		/// </summary>
		public abstract string Author
		{
			get;
		}

		/// <summary>
		/// This Method is called during the Import to process the input Data and
		/// generate a vaild Groups ArrayList.
		/// </summary>
		/// <returns>A List of all available Groups</returns>
		/// <remarks>You can use the <see cref="Input"/> and <see cref="Gmdc"/> Member to acces the Stream and
		/// the Gmdc File that should be changed</remarks>
		protected abstract List<ImportedGroup> LoadGroups();

		/// <summary>
		/// This Method is called during the Import to process the input Data and
		/// showl generate a List of all Joints that should be Imported.
		/// </summary>
		/// <returns>A List of all available Joints</returns>
		/// <remarks>You can use the <see cref="Input"/> and <see cref="Gmdc"/> Member to acces the Stream and
		/// the Gmdc File that should be changed. This Method is allways called AFTER <see cref="LoadGroups"/>.</remarks>
		protected virtual List<ImportedBone> LoadBones()
		{
			return new List<ImportedBone>();
		}
		#endregion

		/// <summary>
		/// stores the Error Message that should be presented
		/// </summary>
		protected string error;

		/// <summary>
		/// Returns the Error Message Produced by the Last Parsing attempt
		/// </summary>
		public string ErrorMessage => error;

		/// <summary>
		/// The current Input (when LoadGroups() or ChangeGmdc() is called, this is never null)
		/// </summary>
		protected System.IO.StreamReader Input
		{
			get; private set;
		}

		/// <summary>
		/// The Gmdc that should be changed (when LoadGroups() or ChangeGmdc() is called, this is never null)
		/// </summary>
		protected GeometryDataContainer Gmdc
		{
			get; private set;
		}

		protected ImportedFrameBlocks AnimationBlocks
		{
			get;
		}

		/// <summary>
		/// Process the Data stored in the passed Stream, and change/replace the passed Gmdc
		/// </summary>
		/// <param name="input">A Stream with the Input Data</param>
		/// <param name="gmdc">The Gmdc that should receive the Data</param>
		/// <param name="animationonly">true, if only the Animation Data should be imported</param>
		public virtual bool Process(
			System.IO.Stream input,
			GeometryDataContainer gmdc,
			bool animationonly
		)
		{
			AnimationOnly = animationonly;

			Input = new System.IO.StreamReader(input);
			Gmdc = gmdc;
			SetUpAnimationData();

			if (gmdc == null || input == null)
			{
				return false;
			}

			List<ImportedGroup> g = LoadGroups();
			List<ImportedBone> b = LoadBones();

			if (!AnimationOnly)
			{
				if (ValidateImportedGroups(g, b))
				{
					ChangeGmdc(g, b);
				}
			}

			ChangeAnim();

			return true;
		}

		public bool AnimationOnly
		{
			get; private set;
		}
		ImportOptions importoptionsresult;

		/// <summary>
		/// Returns Global Import Options
		/// </summary>
		/// <remarks>
		/// This Member is usually set in the <see cref="ValidateImportedGroups"/> Method
		/// </remarks>
		protected ImportOptions Options
		{
			get
			{
				if (importoptionsresult == null)
				{
					importoptionsresult = new ImportOptions(
						System.Windows.Forms.DialogResult.Cancel,
						false,
						false,
						false
					);
				}

				return importoptionsresult;
			}
			set => importoptionsresult = value;
		}

		/// <summary>
		/// This is called after the Groups were Imported to validate the Content
		/// </summary>
		/// <param name="grps">The imported Groups</param>
		/// <param name="bns">The imported Joints</param>
		/// <returns>true, if the Import should be continued</returns>
		/// <remarks>This Implementation will show the ImportGmdcGroups Dialog to
		/// let the User validate the Content. Override this Method, if you want a
		/// diffrent Import Dialog</remarks>
		protected virtual bool ValidateImportedGroups(
			List<ImportedGroup> grps,
			List<ImportedBone> bns
		)
		{
			foreach (ImportedGroup g in grps)
			{
				//add all populated Element Lists
				for (int k = 0; k < g.Elements.Count; k++)
				{
					g.Elements[k].Number = g.Elements[k].Values.Count;
					if (g.Elements[k].Values.Count > 0)
					{
						g.Link.ReferencedElement.Add(k);
					}
				} // for k
				  //if (minct==int.MaxValue) minct=0;
			}

			if (Helper.WindowsRegistry.Config.ShowJointNames)
			{
				foreach (ImportedBone bn in bns)
				{
					Console.WriteLine(bn.ImportedName + " -- " + bn.ParentName);
				}
			}

			importoptionsresult = ImportGmdcGroupsForm.Execute(Gmdc, grps, bns);
			return importoptionsresult.Result == System.Windows.Forms.DialogResult.OK;
		}

		/// <summary>
		/// This Method is called when the Imported Data should be written to the
		/// passed Gmdc File
		/// </summary>
		/// <param name="grps">The imported Groups</param>
		/// <param name="bns">The imported Joints</param>
		/// <remarks>
		/// Override This Method if you want a diffrent Behaviour when writing the Data
		/// to the Gmdc. Override AddGroup(), ReplaceGroup() or RenameGroup() if you just
		/// want to alter a specific Behaviuour.
		/// </remarks>
		protected virtual void ChangeGmdc(List<ImportedGroup> grps, List<ImportedBone> bns)
		{
			//remove all existing Groups and Elements
			if (Options.CleanGroups)
			{
				for (int i = Gmdc.Groups.Count - 1; i >= 0; i--)
				{
					Gmdc.RemoveGroup(i);
				}
			}

			//Add the Joints
			Hashtable boneIndexMap = new Hashtable();
			for (int i = 0; i < bns.Count; i++)
			{
				ImportedBone b = bns[i];
				boneIndexMap[i] = b.Action == GmdcImporterAction.Add
					? AddBone(grps, bns, b, i)
					: b.Action == GmdcImporterAction.Rename
						? AddBone(grps, bns, b, i)
						: b.Action == GmdcImporterAction.Replace
											? ReplaceBone(grps, bns, b, i)
											: b.Action == GmdcImporterAction.Update ? UpdateBone(grps, b, i) : (object)NothingBone(grps, b, i);

				//make sure the Target Index is set correct, and the parrent is set up
				b.TargetIndex = (int)boneIndexMap[i];
				b.Bone.Parent = Gmdc;
			}

			//Update the Bone Indices
			foreach (ImportedGroup g in grps)
			{
				for (int i = 0; i < g.Group.UsedJoints.Count; i++)
				{
					int index = g.Group.UsedJoints[i];
					if (boneIndexMap.ContainsKey(index))
					{
						g.Group.UsedJoints[i] = (int)boneIndexMap[index];
					}
				}
			}

			bool clearbmesh = false;

			//Add the Groups
			foreach (ImportedGroup g in grps)
			{
				if (g.Action == GmdcImporterAction.Add)
				{
					AddGroup(g);
				}
				else if (g.Action == GmdcImporterAction.Rename)
				{
					RenameGroup(g);
				}
				else if (g.Action == GmdcImporterAction.Replace)
				{
					ReplaceGroup(grps, g);
				}
				else if (g.Action == GmdcImporterAction.Update)
				{
					UpdateGroup(g);
				}

				if (g.Action != GmdcImporterAction.Nothing)
				{
					g.Link.Flatten();
				}

				if (g.UseInBoundingMesh)
				{
					clearbmesh = true;
				}
			}

			//Now Update the BoundingMesh if needed
			if (Gmdc.Joints.Count != 0)
			{
				Gmdc.Model.ClearBoundingMesh();
			}
			else
			{
				if (clearbmesh)
				{
					Gmdc.Model.ClearBoundingMesh();
					foreach (ImportedGroup g in grps)
					{
						if (g.UseInBoundingMesh)
						{
							Gmdc.Model.AddGroupToBoundingMesh(g.Group);
						}
					}
				}
			}

			//Make sure the Elements are assigned to the correct Bones
			for (int i = 0; i < bns.Count; i++)
			{
				ImportedBone b = bns[i];
				if (
					b.Action == GmdcImporterAction.Add
					|| b.Action == GmdcImporterAction.Rename
					|| b.Action == GmdcImporterAction.Replace
				)
				{
					b.Bone.CollectVertices();

					//Update the Hirarchy if wanted
					if (Options.UpdateCres)
					{
						//Update the effective Transformation
						TransformNode tn = Gmdc.Joints[
							b.TargetIndex
						].AssignedTransformNode;
						if (tn != null)
						{
							Gmdc.Model.Transformations[b.TargetIndex] =
								tn.GetEffectiveTransformation();
						}

						if (
							Gmdc.ParentResourceNode != null
							&& tn != null
							&& IsLocalCres()
						)
						{
							//first delete the reference to this Node from the current parent
							Interfaces.Scenegraph.ICresChildren icc =
								tn.GetFirstParent();
							if (icc != null)
							{
								icc.StoredTransformNode?.RemoveChild(tn.Index);
							}

							//second, add this Joint to it's new Parent (if one is available)
							if (b.GetParentFrom(bns) != null)
							{
								TransformNode np = b.GetParentFrom(
									bns
								).Bone.AssignedTransformNode;
								np?.AddChild(tn.Index);
							}
						}
					}
				}
			}

			if (Options.CleanBones)
			{
				Gmdc.CleanupBones();
			}

			if (Options.UpdateCres)
			{
				if (!IsLocalCres())
				{
					error +=
						"\n\nThe referenced CRES and this GMDC are not in the same Package File. For security reasons, SimPe did not Update the Bone Hirarchy and locations!";
				}
				else
				{
					Gmdc.ParentResourceNode.Parent.SynchronizeUserData();
				}
			}
		}

		#region Mesh
		/// <summary>
		/// Add the passed Group to the Gmdc
		/// </summary>
		/// <param name="g"></param>
		protected virtual void AddGroup(ImportedGroup g)
		{
			for (int i = 0; i < g.Link.ReferencedElement.Count; i++)
			{
				GmdcElement e = g.Elements[g.Link.ReferencedElement[i]];
				//foreach (GmdcElementValueBase evb in e.Values) evb *= g.Scale;

				Gmdc.Elements.Add(e);
				g.Link.ReferencedElement[i] = Gmdc.Elements.Count - 1;
			}
			g.Group.LinkIndex = Gmdc.Links.Count;
			Gmdc.Links.Add(g.Link);
			Gmdc.Groups.Add(g.Group);

			g.Link.ReferencedSize = g.Link.GetReferencedSize();
			g.Link.ActiveElements = g.Link.ReferencedElement.Count;
		}

		/// <summary>
		/// Replace an existing Group with  the passed Group in the current Gmdc
		/// </summary>
		/// <param name="gs">List of all available Groups</param>
		/// <param name="g"></param>
		protected virtual void ReplaceGroup(List<ImportedGroup> gs, ImportedGroup g)
		{
			int index = g.Target.Index;
			if (index < 0 || index >= Gmdc.Groups.Count)
			{
				index = Gmdc.FindGroupByName(g.Target.Name);
			}

			if (index >= 0)
			{
				Gmdc.RemoveGroup(index);
			}

			//make sure to update the Groups
			foreach (ImportedGroup ig in gs)
			{
				if (ig.Target.Index > index)
				{
					ig.Target.Index--;
				}
			}

			RenameGroup(g);
		}

		/// <summary>
		/// RUpdate an existing Group with  the passed Group in the current Gmdc
		/// </summary>
		/// <param name="g"></param>
		protected virtual void UpdateGroup(ImportedGroup g)
		{
			int index = g.Target.Index;
			if (index < 0 || index >= Gmdc.Groups.Count)
			{
				index = Gmdc.FindGroupByName(g.Target.Name);
			}

			GmdcGroup grp = Gmdc.Groups[index];
			GmdcLink lnk = Gmdc.Links[grp.LinkIndex];

			g.Group.LinkIndex = grp.LinkIndex;
			g.Group.UsedJoints = grp.UsedJoints;

			for (int i = 0; i < g.Link.ReferencedElement.Count; i++)
			{
				GmdcElement e = g.Elements[g.Link.ReferencedElement[i]];
				//foreach (GmdcElementValueBase evb in e.Values) evb *= g.Scale;
				GmdcElement old = lnk.FindElementType(e.Identity);

				//found an existing Element?
				if (old == null)
				{
					Gmdc.Elements.Add(e);
					lnk.ReferencedElement.Add(Gmdc.Elements.Count - 1);
				}
				else
				{
					int id = lnk.GetElementNr(old);
					Gmdc.Elements[lnk.ReferencedElement[id]] = e;
				}
			}

			Gmdc.Groups[index] = g.Group;
			lnk.ReferencedSize = lnk.GetReferencedSize();
			lnk.ActiveElements = lnk.ReferencedElement.Count;
		}

		/// <summary>
		/// set the Name of the Group to a diffrent Value and Add it to the Gmdc
		/// </summary>
		/// <param name="g"></param>
		protected virtual void RenameGroup(ImportedGroup g)
		{
			g.Group.Name = g.Target.Name;
			AddGroup(g);
		}
		#endregion

		/// <summary>
		/// Is the Cres within the same package than the GMDC is?
		/// </summary>
		/// <returns></returns>
		bool IsLocalCres()
		{
			return Gmdc.ParentResourceNode != null && Gmdc.ParentResourceNode.Parent.Package.FileName.Trim().ToLower()
					== Gmdc.Parent.Package.FileName.Trim().ToLower();
		}

		#region Bone
		/// <summary>
		/// Add the passed Bone to the Gmdc and Fix the UseBone Indices to apropriate Values
		/// </summary>
		/// <param name="grps">List of all Imported Groups (needed to fix the UseBone Indices)</param>
		/// <param name="bns">List of all Bones</param>
		/// <param name="b"></param>
		/// <param name="index">The Number of the Bone that should be added</param>
		/// <returns>the real Bone Index</returns>
		protected virtual int AddBone(
			List<ImportedGroup> grps,
			List<ImportedBone> bns,
			ImportedBone b,
			int index
		)
		{
			int nindex = Gmdc.Joints.Count;
			Gmdc.Joints.Add(b.Bone);

			VectorTransformation t = new VectorTransformation(
				VectorTransformation.TransformOrder.RotateTranslate
			);
			Gmdc.Model.Transformations.Add(t);

			//Create a TransformNode for the New Bone
			if (Options.UpdateCres)
			{
				if ((Gmdc.ParentResourceNode != null) && IsLocalCres())
				{
					TransformNode tn = new TransformNode(
						Gmdc.ParentResourceNode.Parent
					);
					tn.Transformation = b.Transformation.Clone();
					tn.JointReference = nindex;
					tn.ObjectGraphNode.FileName = b.ImportedName;

					Gmdc.ParentResourceNode.Parent.Blocks.Add(tn);
				}
			}

			return nindex;
		}

		/// <summary>
		/// Replace an exiting bone with the passed one
		/// </summary>
		/// <param name="grps">List of all Imported Groups (needed to fix the UseBone Indices)</param>
		/// <param name="bns">List of all Bones</param>
		/// <param name="b"></param>
		/// <param name="index">The Number of the Bone that should be added</param>
		/// <returns>the real Bone Index</returns>
		protected virtual int ReplaceBone(
			List<ImportedGroup> grps,
			List<ImportedBone> bns,
			ImportedBone b,
			int index
		)
		{
			int nindex = b.TargetIndex;
			Gmdc.Joints[nindex] = b.Bone;

			VectorTransformation t = new VectorTransformation(
				VectorTransformation.TransformOrder.RotateTranslate
			);
			Gmdc.Model.Transformations[nindex] = t;

			//Change the TransformNode for the New Bone
			if (Options.UpdateCres)
			{
				if (Gmdc.ParentResourceNode != null)
				{
					TransformNode tn = Gmdc.Joints[nindex].AssignedTransformNode;
					tn.ObjectGraphNode.FileName = b.ImportedName;
					if (tn != null)
					{
						tn.Transformation = b.Transformation.Clone();
					}
				}
			}

			return nindex;
		}

		/// <summary>
		/// Replace an exiting bone with the passed one
		/// </summary>
		/// <param name="grps">List of all Imported Groups (needed to fix the UseBone Indices)</param>
		/// <param name="b"></param>
		/// <param name="index">The Number of the Bone that should be added</param>
		/// <returns>the real Bone Index</returns>
		protected virtual int UpdateBone(List<ImportedGroup> grps, ImportedBone b, int index)
		{
			int nindex = b.TargetIndex;
			return nindex;
		}

		/// <summary>
		/// Remove the Links to the NothingBones
		/// </summary>
		/// <param name="grps">List of all Imported Groups (needed to fix the UseBone Indices)</param>
		/// <param name="b"></param>
		/// <param name="index">The Number of the Bone that should be added</param>
		/// <returns>the real Bone Index</returns>
		protected virtual int NothingBone(
			List<ImportedGroup> grps,
			ImportedBone b,
			int index
		)
		{
			return -1;
		}
		#endregion

		/// <summary>
		/// Creates a new <see cref="ImportedGroup"/> Instance with Default Settings
		/// </summary>
		/// <returns>a new Container for an Imported MeshGroup</returns>
		/// <remarks>
		/// You should use this whenever you have to add a new Group!
		/// </remarks>
		protected ImportedGroup PrepareGroup()
		{
			ImportedGroup g = new ImportedGroup(Gmdc);

			//Vertex Element-----
			GmdcElement e = new GmdcElement(Gmdc);
			g.Elements.Add(e);
			e.Identity = ElementIdentity.Vertex;
			e.BlockFormat = BlockFormat.ThreeFloat;
			e.SetFormat = SetFormat.Secondary;

			//Normal Element-----
			e = new GmdcElement(Gmdc);
			g.Elements.Add(e);
			e.Identity = ElementIdentity.Normal;
			e.BlockFormat = BlockFormat.ThreeFloat;
			e.SetFormat = SetFormat.Normals;

			//UVCoord Element-----
			e = new GmdcElement(Gmdc);
			g.Elements.Add(e);
			e.Identity = ElementIdentity.UVCoordinate;
			e.BlockFormat = BlockFormat.TwoFloat;
			e.SetFormat = SetFormat.Mapping;

			g.Group.PrimitiveType = PrimitiveType.Triangle;
			g.Group.Opacity = 0xffffffff;

			return g;
		}

		#region Animation
		/// <summary>
		/// This Map contains static correction Values used for specific animation Joints
		/// </summary>
		static Dictionary<string, Vector3> ajcor;

		protected static void BuildCorrectionMap()
		{
			if (ajcor != null)
			{
				return;
			}

			ajcor = new Dictionary<string, Vector3>
			{
				["l_thigh"] = new Vector3(-(180f.DegreesToRadians()), 0, 0),
				["r_thigh"] = new Vector3(-(180f.DegreesToRadians()), 0, 0),
				["l_clavicle"] = new Vector3(0, 0, (90f.DegreesToRadians())),
				["r_clavicle"] = new Vector3(0, 0, -(90f.DegreesToRadians()))
			};
		}

		/// <summary>
		/// Returns a Vector that contains Correction Data for a Animation Joint
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		/// <remarks>The vector should be added during Export,
		/// and will be substracted during Import</remarks>
		public static Vector3 GetCorrectionVector(string name)
		{
			if (ajcor == null)
			{
				BuildCorrectionMap();
			}


			return ajcor.ContainsKey(name) ? ajcor[name] : new Vector3(0, 0, 0);
		}

		/// <summary>
		/// This is called whenever a Animation is sored in
		/// <see cref="Gmdc.LinkedAnimation"/>, and it should import the Values stored in
		/// <see cref="AnimationBlocks"/> to <see cref="Gmdc.LinkedAnimation"/>.
		/// </summary>
		protected void ChangeAnim()
		{
			if (Gmdc.LinkedAnimation == null)
			{
				return;
			}

			foreach (ImportedFrameBlock ifb in AnimationBlocks)
			{
				ifb.FindTarget(Gmdc.LinkedAnimation);
			}

			if (ImportJointAnim.Execute(AnimationBlocks, Gmdc))
			{
				//correct some transformation in special Joints, don't know yet
				//why they work diffrent
				if (AnimationBlocks.AuskelCorrection)
				{
					foreach (ImportedFrameBlock ifb in AnimationBlocks)
					{
						if (ifb.Action != AnimImporterAction.Nothing)
						{
							foreach (AnimationFrame af in ifb.FrameBlock.Frames)
							{
								Vector3 v = GetCorrectionVector(ifb.ImportedName);

								af.Float_X -= (float)v.X;
								af.Float_Y -= (float)v.Y;
								af.Float_Z -= (float)v.Z;
							}
						}
					}
				}

				foreach (ImportedFrameBlock ifb in AnimationBlocks)
				{
					if (ifb.Action == AnimImporterAction.Replace)
					{
						ifb.ReplaceFrames();
					}
					else if (ifb.Action == AnimImporterAction.Add)
					{
						ifb.AddFrameBlock(Gmdc.LinkedAnimation);
					}
				}
			}
		}

		/// <summary>
		/// Called in order to Setup the Animation Data
		/// </summary>
		protected virtual void SetUpAnimationData()
		{
			AnimationBlocks.Clear();
		}
		#endregion

		string flname;
		public string FileName
		{
			get
			{
				if (flname == null)
				{
					flname = "";
				}

				return flname;
			}
			set => flname = value;
		}
	}
}
