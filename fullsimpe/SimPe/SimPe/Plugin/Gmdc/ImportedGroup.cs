/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System.Collections;

namespace SimPe.Plugin.Gmdc
{
	public class GroupDescriptor
	{
		public GroupDescriptor(string name)
			: this(name, -1) { }

		public GroupDescriptor(string name, int index)
		{
			Name = name;
			Index = index;
		}

		public string Name
		{
			get; set;
		}

		public int Index
		{
			get; set;
		}

		public bool HasIndex => (Index >= 0);
	}

	/// <summary>
	/// Enumerates possible action for Mesh Groups
	/// </summary>
	public enum GmdcImporterAction : byte
	{
		/// <summary>
		/// Ignore the Mesh-Group
		/// </summary>
		Nothing = 0x00,

		/// <summary>
		/// Replace the existing Group with the one stored in the <see cref="ImportedGroup.Group"/> Member
		/// </summary>
		Replace = 0x01,

		/// <summary>
		/// Add the Group stored in the <see cref="ImportedGroup.Group"/> Member
		/// </summary>
		Add = 0x02,

		/// <summary>
		/// Add the Group stored in <see cref="ImportedGroup.Group"/> and assign a new Name.
		/// </summary>
		Rename = 0x03,

		/// <summary>
		/// Will only change the newly Imported Data in the stored <see cref="ImportedGroup.Group"/>.
		/// </summary>
		Update = 0x04,
	}

	/// <summary>
	/// This class is generated for each available and imported Group,
	/// and determins the Behaviour during the Import
	/// </summary>
	public class GmdcGroupImporterAction
	{
		/// <summary>
		/// If action is <see cref="GmdcImporterAction.Replace"/>, <see cref="GmdcImporterAction.Update"/> or
		/// <see cref="GmdcImporterAction.Rename"/>, this Member stores the
		/// new Name for the current Group. (read/write)
		/// </summary>
		public GroupDescriptor Target
		{
			get; set;
		}

		/// <summary>
		/// Returns/Sets the action that should be performed
		/// </summary>
		public GmdcImporterAction Action
		{
			get; set;
		}

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
		public GmdcGroupImporterAction()
		{
			Action = GmdcImporterAction.Add;
			Scale = (float)(1.0);

			Target = new GroupDescriptor("");
		}
	}

	/// <summary>
	/// This class contains all Data Needed to import one Mesh Group
	/// </summary>
	public class ImportedGroup : GmdcGroupImporterAction
	{
		/// <summary>
		/// The new MeshGroup
		/// </summary>
		public GmdcGroup Group
		{
			get;
		}

		/// <summary>
		/// The new Link Section
		/// </summary>
		public GmdcLink Link
		{
			get;
		}

		/// <summary>
		/// All Elements used by this Group
		/// </summary>
		public GmdcElements Elements
		{
			get;
		}

		/// <summary>
		/// Returns the Number of faces stored in the Group
		/// </summary>
		public int VertexCount
		{
			get
			{
				int vc = 0;
				foreach (int i in Link.ReferencedElement)
				{
					if (Elements[i].Identity == ElementIdentity.Vertex)
					{
						vc += Elements[i].Values.Count;
					}
				}

				return vc;
			}
		}

		/// <summary>
		/// Returns the Number of stored Faces
		/// </summary>
		/// <returns></returns>
		public int FaceCount => Group.Faces.Length / 3;

		/// <summary>
		/// True, if this MEshGroup sould be added to the BoundingMesh
		/// </summary>
		public bool UseInBoundingMesh
		{
			get; set;
		}

		internal void SetKeepOrder(bool val)
		{
			KeepOrder = val;
		}

		public bool KeepOrder
		{
			get; private set;
		}

		/// <summary>
		/// Returns the color that should be used to display this Group in the "Import Groups" ListView
		/// </summary>
		public System.Drawing.Color MarkColor => Action == GmdcImporterAction.Nothing
					? System.Drawing.Color.Silver
					: VertexCount > AbstractGmdcImporter.CRITICAL_VERTEX_AMOUNT || FaceCount > AbstractGmdcImporter.CRITICAL_FACE_AMOUNT
					? System.Drawing.Color.Red
					: System.Drawing.SystemColors.WindowText;

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="parent">The gmdc that should act as Parent</param>
		public ImportedGroup(GeometryDataContainer parent)
			: base()
		{
			KeepOrder = true;
			Group = new GmdcGroup(parent);
			Link = new GmdcLink(parent);
			Elements = new GmdcElements();
			UseInBoundingMesh = false;
		}
	}

	#region Container
	/// <summary>
	/// Typesave ArrayList for <see cref="ImportedGroup"/> Objects
	/// </summary>
	public class ImportedGroups : ArrayList
	{
		/// <summary>
		/// Integer Indexer
		/// </summary>
		public new ImportedGroup this[int index]
		{
			get => ((ImportedGroup)base[index]);
			set => base[index] = value;
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public ImportedGroup this[uint index]
		{
			get => ((ImportedGroup)base[(int)index]);
			set => base[(int)index] = value;
		}

		/// <summary>
		/// add a new Element
		/// </summary>
		/// <param name="item">The object you want to add</param>
		/// <returns>The index it was added on</returns>
		public int Add(ImportedGroup item)
		{
			return base.Add(item);
		}

		/// <summary>
		/// insert a new Element
		/// </summary>
		/// <param name="index">The Index where the Element should be stored</param>
		/// <param name="item">The object that should be inserted</param>
		public void Insert(int index, ImportedGroup item)
		{
			base.Insert(index, item);
		}

		/// <summary>
		/// remove an Element
		/// </summary>
		/// <param name="item">The object that should be removed</param>
		public void Remove(ImportedGroup item)
		{
			base.Remove(item);
		}

		/// <summary>
		/// Checks wether or not the object is already stored in the List
		/// </summary>
		/// <param name="item">The Object you are looking for</param>
		/// <returns>true, if it was found</returns>
		public bool Contains(ImportedGroup item)
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
			ImportedGroups list = new ImportedGroups();
			foreach (ImportedGroup item in this)
			{
				list.Add(item);
			}

			return list;
		}
	}
	#endregion
}
