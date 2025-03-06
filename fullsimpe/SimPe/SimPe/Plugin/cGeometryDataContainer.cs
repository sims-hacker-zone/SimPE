// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using SimPe.Data;
using SimPe.Forms.MainUI;
using SimPe.Geometry;
using SimPe.Plugin.Anim;
using SimPe.Plugin.Gmdc;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class contains the Geometric Data of an Object
	/// </summary>
	public class GeometryDataContainer : AbstractRcolBlock
	{
		#region Attributes

		/// <summary>
		/// Returns a List of stored Elements
		/// </summary>
		public GmdcElements Elements
		{
			get; set;
		}

		/// <summary>
		/// Returns a List of stored Links
		/// </summary>
		public GmdcLinks Links
		{
			get; set;
		}

		/// <summary>
		/// Returns a List of stored Groups
		/// </summary>
		public GmdcGroups Groups
		{
			get; set;
		}

		/// <summary>
		/// Returns the stored Model
		/// </summary>
		public GmdcModel Model
		{
			get; set;
		}

		/// <summary>
		/// Returns a List of stored Joints
		/// </summary>
		public GmdcJoints Joints
		{
			get; set;
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public GeometryDataContainer(Rcol parent)
			: base(parent)
		{
			sgres = new SGResource(null);

			version = 0x04;
			BlockID = (uint)FileTypes.GMDC;

			Elements = new GmdcElements();
			Links = new GmdcLinks();
			Groups = new GmdcGroups();

			Model = new GmdcModel(this);

			Joints = new GmdcJoints();
			TriedToLoadParentResourceNode = false;
		}

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public override void Unserialize(BinaryReader reader)
		{
			TriedToLoadParentResourceNode = false;
			version = reader.ReadUInt32();

			string name = reader.ReadString();
			uint myid = reader.ReadUInt32();
			sgres.Unserialize(reader);
			sgres.BlockID = myid;

			if (Parent.Fast)
			{
				Elements.Clear();
				Links.Clear();
				Groups.Clear();
				Joints.Clear();
				return;
			}

			int count = reader.ReadInt32();
			Elements.Clear();
			for (int i = 0; i < count; i++)
			{
				GmdcElement e = new GmdcElement(this);
				e.Unserialize(reader);
				Elements.Add(e);
			}

			count = reader.ReadInt32();
			Links.Clear();
			for (int i = 0; i < count; i++)
			{
				GmdcLink l = new GmdcLink(this);
				l.Unserialize(reader);
				Links.Add(l);
			}

			count = reader.ReadInt32();
			Groups.Clear();
			for (int i = 0; i < count; i++)
			{
				GmdcGroup g = new GmdcGroup(this);
				g.Unserialize(reader);
				Groups.Add(g);
			}

			Model.Unserialize(reader);

			count = reader.ReadInt32();
			Joints.Clear();
			for (int i = 0; i < count; i++)
			{
				GmdcJoint s = new GmdcJoint(this);
				s.Unserialize(reader);
				Joints.Add(s);
			}
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public override void Serialize(BinaryWriter writer)
		{
			writer.Write(version);

			writer.Write(sgres.BlockName);
			writer.Write(sgres.BlockID);
			sgres.Serialize(writer);

			writer.Write(Elements.Length);
			for (int i = 0; i < Elements.Length; i++)
			{
				Elements[i].Parent = this;
				Elements[i].Serialize(writer);
			}

			writer.Write(Links.Length);
			for (int i = 0; i < Links.Length; i++)
			{
				Links[i].Parent = this;
				Links[i].Serialize(writer);
			}

			writer.Write(Groups.Length);
			for (int i = 0; i < Groups.Length; i++)
			{
				Groups[i].Parent = this;
				Groups[i].Serialize(writer);
			}

			Model.Parent = this;
			Model.Serialize(writer);

			writer.Write(Joints.Length);
			for (int i = 0; i < Joints.Length; i++)
			{
				Joints[i].Parent = this;
				Joints[i].Serialize(writer);
			}
		}

		fGeometryDataContainer form = null;

		/// <summary>
		/// Returns null or the Instance of a <see cref="System.Windows.Forms.TabPage"/> that
		/// should be displayed as Primary Interface
		/// </summary>
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (form == null)
				{
					form = new fGeometryDataContainer();
				}

				return form.tMesh;
			}
		}
		#endregion

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			if (form == null)
			{
				form = new fGeometryDataContainer();
			}

			form.ResetPreview();
			form.tb_ver.Text = "0x" + Helper.HexString(version);

			if (UserVerification.HaveUserId)
			{
				form.label_elements.Text = "Elements: " + Elements.Length.ToString();
				form.list_elements.Items.Clear();
				foreach (GmdcElement e in Elements)
				{
					CountedListItem.Add(form.list_elements, e);
				}

				form.label_links.Text = "Links: " + Links.Length.ToString();
				form.list_links.Items.Clear();
				foreach (GmdcLink l in Links)
				{
					CountedListItem.Add(form.list_links, l);
				}

				form.label_groups.Text = "Groups: " + Groups.Length.ToString();
				form.list_groups.Items.Clear();
				foreach (GmdcGroup g in Groups)
				{
					CountedListItem.Add(form.list_groups, g);
				}

				form.label_subsets.Text = "Joints: " + Joints.Length.ToString();
				form.list_subsets.Items.Clear();
				foreach (GmdcJoint s in Joints)
				{
					CountedListItem.Add(form.list_subsets, s);
				}
			}

			try
			{
				form.lb_models.Text =
					"Models (Faces="
					+ TotalFaceCount.ToString()
					+ ", Vertices="
					+ TotalUsedVertices.ToString()
					+ "):";
				form.lb_itemsc2.Items.Clear();
				form.lb_itemsc3.Items.Clear();
				form.lb_itemsc.Items.Clear();
				form.lbmodel.Items.Clear();
				foreach (GmdcGroup g in Groups)
				{
					form.lbmodel.Items.Add(g, g.Opacity >= 0x10);
					form.lb_itemsc.Items.Add(g);
				}

				form.lb_itemsa2.Items.Clear();
				form.lb_itemsa.Items.Clear();
				foreach (GmdcElement i in Elements)
				{
					CountedListItem.Add(form.lb_itemsa, i);
				}

				form.lb_itemsb2.Items.Clear();
				form.lb_itemsb3.Items.Clear();
				form.lb_itemsb4.Items.Clear();
				form.lb_itemsb5.Items.Clear();
				form.lb_itemsb.Items.Clear();
				foreach (GmdcLink i in Links)
				{
					CountedListItem.Add(form.lb_itemsb, i);
				}

				form.lb_subsets.Items.Clear();
				form.lb_sub_faces.Items.Clear();
				form.lb_sub_items.Items.Clear();
				form.cbGroupJoint.Items.Clear();
				foreach (GmdcJoint i in Joints)
				{
					CountedListItem.Add(form.lb_subsets, i);
					CountedListItem.Add(form.cbGroupJoint, i);
				}

				form.lb_model_faces.Items.Clear();
				foreach (Vector3f i in Model.BoundingMesh.Vertices)
				{
					CountedListItem.Add(form.lb_model_faces, i);
				}

				form.lb_model_items.Items.Clear();
				foreach (int i in Model.BoundingMesh.Items)
				{
					CountedListItem.Add(form.lb_model_items, i);
				}

				form.lb_model_names.Items.Clear();
				foreach (GmdcNamePair i in Model.BlendGroupDefinition)
				{
					CountedListItem.Add(form.lb_model_names, i);
				}

				form.lb_model_trans.Items.Clear();
				foreach (VectorTransformation i in Model.Transformations)
				{
					CountedListItem.Add(form.lb_model_trans, i);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		/// <summary>
		/// Add Additional <see cref="System.Windows.Forms.TabPage"/> to show more Informations
		/// </summary>
		/// <param name="tc">The TabPage will be added here.</param>
		public override void ExtendTabControl(System.Windows.Forms.TabControl tc)
		{
			form.tGeometryDataContainer.Tag = this;
			tc.TabPages.Add(form.tGeometryDataContainer);

			form.tGeometryDataContainer2.Tag = this;
			tc.TabPages.Add(form.tGeometryDataContainer2);

			form.tGeometryDataContainer3.Tag = this;
			tc.TabPages.Add(form.tGeometryDataContainer3);

			form.tModel.Tag = this;
			tc.TabPages.Add(form.tModel);

			form.tSubset.Tag = this;
			tc.TabPages.Add(form.tSubset);

			if (UserVerification.HaveUserId)
			{
				form.tAdvncd.Tag = this;
				tc.TabPages.Add(form.tAdvncd);
			}
		}

		#region .x-Files
		/// <summary>
		/// Creates a .x File for all Models stored in the GMDC
		/// </summary>
		/// <param name="models">List of all P3Models you want to export</param>
		/// <returns>The content of the x File</returns>
		public MemoryStream GenerateX(GmdcGroups models)
		{
			IGmdcExporter exporter = ExporterLoader.FindExporterByExtension(".x") ?? throw new Exception("No valid Direct X Exporter plugin was found!");

			exporter.Component.Sorting = ElementSorting.Preview;
			exporter.Process(this, models);
			return (MemoryStream)exporter.FileContent.BaseStream;
		}
		#endregion


		/// <summary>
		/// Remove the Group with the given Index from the File
		/// </summary>
		/// <param name="index">The index of the Element</param>
		public void RemoveGroup(int index)
		{
			if (index < Groups.Count)
			{
				GmdcGroup g = Groups[index];
				int n = g.LinkIndex;
				g.LinkIndex = -1;
				RemoveLink(n);

				Groups.RemoveAt(index);
			}
		}

		/// <summary>
		/// Remove the Link with the given Index from the File
		/// </summary>
		/// <param name="index">The index of the Element</param>
		/// <returns>true if the link was removed</returns>
		/// <remarks>
		/// A Link will not be removed, if it is still referenced
		/// in one or more Groups!
		/// </remarks>
		public bool RemoveLink(int index)
		{
			foreach (GmdcGroup g in Groups)
			{
				if (g.LinkIndex == index)
				{
					return false;
				}
			}

			GmdcLink l = Links[index];
			foreach (GmdcGroup g in Groups)
			{
				if (g.LinkIndex > index)
				{
					g.LinkIndex--;
				}
			}

			for (int i = 0; i < l.ReferencedElement.Count; i++)
			{
				int n = l.ReferencedElement[i];
				l.ReferencedElement[i] = -1; //make sure the reference is removed first
				RemoveElement(n);
			}
			Links.RemoveAt(index);
			return true;
		}

		/// <summary>
		/// Remove the Element with the given Index from the File
		/// </summary>
		/// <param name="index">The index of the Element</param>
		/// <returns>true if the element was removed</returns>
		/// <remarks>
		/// A Element will not be removed, if it is still referenced
		/// in one or more Links!
		/// </remarks>
		public bool RemoveElement(int index)
		{
			//Can we remove this Element?
			foreach (GmdcLink l in Links)
			{
				foreach (int i in l.ReferencedElement)
				{
					if (i == index)
					{
						return false;
					}
				}
			}

			//Adjust the References
			foreach (GmdcLink l in Links)
			{
				for (int i = 0; i < l.ReferencedElement.Count; i++)
				{
					if (l.ReferencedElement[i] > index)
					{
						l.ReferencedElement[i]--;
					}
				}
			}

			Elements.RemoveAt(index);
			return true;
		}

		/// <summary>
		/// Returns the total Face Count for this Mesh
		/// </summary>
		public int TotalFaceCount
		{
			get
			{
				int ct = 0;
				foreach (GmdcGroup g in Groups)
				{
					ct += g.FaceCount;
				}

				return ct;
			}
		}

		/// <summary>
		/// Returns the number of used Vertices in this Mshe
		/// </summary>
		public int TotalUsedVertices
		{
			get
			{
				int ct = 0;
				foreach (GmdcGroup g in Groups)
				{
					ct += g.UsedVertexCount;
				}

				return ct;
			}
		}

		/// <summary>
		/// Returns the number of referenced Vertices in this Mesh
		/// </summary>
		public int TotalReferencedVertices
		{
			get
			{
				int ct = 0;
				foreach (GmdcGroup g in Groups)
				{
					ct += g.ReferencedVertexCount;
				}

				return ct;
			}
		}

		/// <summary>
		/// Call this Method to remove all unreferenced Joints
		/// </summary>
		public void CleanupBones()
		{
			ArrayList usebones = new ArrayList();

			///Assemble a List of used Joints
			foreach (GmdcElement e in Elements)
			{
				if (e.Identity == ElementIdentity.BoneAssignment)
				{
					foreach (GmdcElementValueOneInt v in e.Values)
					{
						if (!usebones.Contains(v.Value & 0xff))
						{
							usebones.Add(v.Value & 0xff);
						}
					}
				}
			}

			for (int i = Joints.Length - 1; i >= 0; i--)
			{
				if (!usebones.Contains(i))
				{
					RemoveBone(i);
				}
			}
		}

		/// <summary>
		/// Removes a Bone from this File
		/// </summary>
		/// <remarks>Vertices referencing this Bone will be unassigned! </remarks>
		/// <param name="index"></param>
		public void RemoveBone(int index)
		{
			//Update the Assignments
			foreach (GmdcElement e in Elements)
			{
				if (e.Identity == ElementIdentity.BoneAssignment)
				{
					foreach (GmdcElementValueOneInt v in e.Values)
					{
						if (v.Bytes[0] == index)
						{
							byte[] b = v.Bytes;
							b[0] = 0xff;
							v.Bytes = b;
						}
						/*else if ((int)v.Bytes[0]>index)
						{
							byte[]b = v.Bytes;
							b[0]--;
							v.Bytes = b;
						}*/
					}
				}
			}

			//Update the Bone List in the Groups Section
			foreach (GmdcGroup g in Groups)
			{
				for (int i = g.UsedJoints.Count - 1; i >= 0; i--)
				{
					if (g.UsedJoints[i] == index)
					{
						g.UsedJoints.RemoveAt(i);
					}
					else if (g.UsedJoints[i] > index)
					{
						g.UsedJoints[i]--;
					}
				}
			}

			Model.Transformations.RemoveAt(index);
			Joints.RemoveAt(index);
		}

		/// <summary>
		/// Returns the Index of the Group in <see cref="Groups"/>.
		/// </summary>
		/// <param name="name">The name of the Group</param>
		/// <returns>-1 if the Grou is not foudn or the Index in <see cref="Groups"/></returns>
		public int FindGroupByName(string name)
		{
			name = name.Trim().ToLower();
			for (int i = 0; i < Groups.Count; i++)
			{
				if (Groups[i].Name.Trim().ToLower() == name)
				{
					return i;
				}
			}

			return -1;
		}

		/// <summary>
		/// Returns the Index of the Joint in <see cref="Joints"/>.
		/// </summary>
		/// <param name="name">The name of the Joint</param>
		/// <returns>-1 if the Joint is not found or the Index in <see cref="Joints"/></returns>
		public int FindJointByName(string name)
		{
			name = name.Trim().ToLower();
			for (int i = 0; i < Joints.Count; i++)
			{
				if (Joints[i].Name.Trim().ToLower() == name)
				{
					return i;
				}
			}

			return -1;
		}

		#region LinkedCRES

		Rcol cres;

		public bool TriedToLoadParentResourceNode
		{
			get; set;
		}

		/// <summary>
		/// Get the attached ResourceNode
		/// </summary>
		public ResourceNode ParentResourceNode
		{
			get
			{
				if (!TriedToLoadParentResourceNode)
				{
					if (cres == null)
					{
						cres = FindReferencingCRES();
					}

					TriedToLoadParentResourceNode = true;
				}

				return cres == null ? null : (ResourceNode)cres.Blocks[0];
			}
		}

		/// <summary>
		/// Returns the RCOL which lists this Resource in it's ReferencedFiles Attribute
		/// </summary>
		/// <returns>null or the RCOl Ressource</returns>
		public Rcol FindReferencingCRES()
		{
			Wait.SubStart();
			//WaitingScreen.Wait();
			try
			{
				Interfaces.Scenegraph.IScenegraphFileIndex nfi =
					FileTableBase.FileIndex.AddNewChild();
				nfi.AddIndexFromPackage(Parent.Package);
				Rcol cres = FindReferencingCRES_Int();
				FileTableBase.FileIndex.RemoveChild(nfi);
				nfi.Clear();

				if (cres == null && !FileTableBase.FileIndex.Loaded)
				{
					FileTableBase.FileIndex.Load();
					cres = FindReferencingCRES_Int();
				}

				return cres;
			}
			finally
			{
				Wait.SubStop(); /*WaitingScreen.Stop();*/
			}
		}

		/// <summary>
		/// Returns the RCOL which lists this Resource in it's ReferencedFiles Attribute
		/// </summary>
		/// <returns>null or the RCOl Ressource</returns>
		Rcol FindReferencingCRES_Int()
		{
			//WaitingScreen.UpdateMessage("Loading Geometry Node");
			Wait.Message = "Loading Geometry Node";
			Rcol step = FindReferencingParent_NoLoad(Data.FileTypes.GMND);
			if (step == null)
			{
				return null;
			}

			//WaitingScreen.UpdateMessage("Loading Shape");
			Wait.Message = "Loading Shape";
			step = ((GeometryNode)step.Blocks[0]).FindReferencingSHPE_NoLoad();
			if (step == null)
			{
				return null;
			}

			//WaitingScreen.UpdateMessage("Loading ResourceNode");
			Wait.Message = "Loading ResourceNode";
			step = ((AbstractRcolBlock)step.Blocks[0]).FindReferencingParent_NoLoad(
				Data.FileTypes.CRES
			);
			return step ?? null;
		}

		/// <summary>
		/// Build the Parent Map
		/// </summary>
		/// <param name="parentmap">Hasttable that will contain the Child (key) -> Parent (value) Relation</param>
		/// <param name="parent">the current Parent id (-1=none)</param>
		/// <param name="c">the current Block we process</param>
		protected void LoadJointRelationRec(
			Hashtable parentmap,
			int parent,
			Interfaces.Scenegraph.ICresChildren c
		)
		{
			if (c == null)
			{
				return;
			}

			if (c.GetType() == typeof(TransformNode))
			{
				TransformNode tn = (TransformNode)c;
				if (tn.JointReference != TransformNode.NO_JOINT)
				{
					parentmap[tn.JointReference] = parent;
					parent = tn.JointReference;
				}
			}

			//process the childs of this Block
			foreach (int i in c.ChildBlocks)
			{
				Interfaces.Scenegraph.ICresChildren cl = c.GetBlock(i);
				LoadJointRelationRec(parentmap, parent, cl);
			}
		}

		/// <summary>
		/// Creates a Map, that contains a mapping from each Joint to it's parent
		/// </summary>
		/// <returns>The JointRelation Map</returns>
		/// <remarks>key=ChildJoint ID, value=ParentJoint ID (-1=top Level Joint)</remarks>
		public virtual Hashtable LoadJointRelationMap()
		{
			//Get the Cres for the Bone Hirarchy
			ResourceNode rn = ParentResourceNode;

			Hashtable parentmap = new Hashtable();
			if (rn == null)
			{
				Message.Show(
					Localization.GetString("NO_CRES_FOUND"),
					Localization.GetString("Information"),
					System.Windows.Forms.MessageBoxButtons.OK
				);
				return parentmap;
			}
			else
			{
				LoadJointRelationRec(parentmap, -1, rn);
			}

			//make sure Bones not defined in the CRES are listed here too
			for (int i = 0; i < Joints.Count; i++)
			{
				if (parentmap[i] == null)
				{
					parentmap[i] = -1;
				}
			}

			return parentmap;
		}

		/// <summary>
		/// Recusrivley add all SubJoints
		/// </summary>
		/// <param name="start"></param>
		/// <param name="relmap"></param>
		/// <param name="l"></param>
		static void SortJointsRec(
			int start,
			Hashtable relmap,
			List<int> l
		)
		{
			if (start == -1)
			{
				return;
			}

			if (l.Contains(start))
			{
				return;
			}

			l.Add(start);

			foreach (int k in relmap.Keys)
			{
				if ((int)relmap[k] == start)
				{
					SortJointsRec(k, relmap, l);
				}
			}
		}

		/// <summary>
		/// Sort the passed list of Joints so that parent joints allways come first
		/// </summary>
		/// <param name="joints"><see cref="Joints"/></param>
		/// <param name="relmap"><see cref="LoadJointRelationMap"/></param>
		/// <returns></returns>
		public static List<int> SortJoints(
			GmdcJoints joints,
			Hashtable relmap
		)
		{
			int start = -1;
			foreach (int k in relmap.Keys)
			{
				if ((int)relmap[k] == -1)
				{
					start = k;
					break;
				}
			}

			if (start != -1)
			{
				List<int> l = new List<int>();
				SortJointsRec(start, relmap, l);

				//check if there are some Joint's that were not added so far
				Hashtable nrelmap = (Hashtable)
					relmap.Clone();
				foreach (int v in l)
				{
					if (nrelmap.ContainsKey(v))
					{
						nrelmap.Remove(v);
					}
				}

				//recursivley process remaing joints
				if (nrelmap.Count > 0)
				{
					List<int> l2 = SortJoints(joints, nrelmap);
					foreach (int i in l2)
					{
						l.Add(i);
					}
				}

				return l;
			}

			List<int> ls = new List<int>();
			foreach (GmdcJoint j in joints)
			{
				ls.Add(j.Index);
			}

			return ls;
		}

		/// <summary>
		/// Sort the passed list of Joints so that parent joints allways come first
		/// </summary>
		/// <returns></returns>
		public List<int> SortJoints()
		{
			return SortJoints(Joints, LoadJointRelationMap());
		}

		/// <summary>
		/// Sort the passed list of Joints so that parent joints allways come first
		/// </summary>
		/// <param name="relmap"></param>
		/// <returns></returns>
		public List<int> SortJoints(Hashtable relmap)
		{
			return SortJoints(Joints, relmap);
		}
		#endregion

		public AnimationMeshBlock LinkedAnimation
		{
			get; set;
		}

		#region IDisposable Member

		public override void Dispose()
		{
			form?.Dispose();
		}

		#endregion
	}
}
