// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Numerics;
using System.Windows.Forms;

using SimPe.Extensions;

namespace SimPe.Plugin.Gmdc
{
	class MeshListViewItemExt : MeshListViewItem
	{
		public MeshListViewItemExt(
			ListViewEx lv,
			Ambertation.Scenes.Mesh mesh,
			GenericMeshImport gmi,
			ActionChangedEvent fkt
		)
			: base(lv, mesh, gmi, fkt) { }

		#region Build Elements
		GmdcElement BuildVertexElement()
		{
			if (mesh.Vertices.Count == 0)
			{
				return null;
			}

			GmdcElement e = new GmdcElement(gmi.Gmdc)
			{
				SetFormat = SetFormat.Secondary,
				BlockFormat = BlockFormat.ThreeFloat,
				Identity = ElementIdentity.Vertex,
				GroupId = 0,

				Number = mesh.Vertices.Count
			};

			foreach (Ambertation.Geometry.Vector3 v in mesh.Vertices)
			{
				Vector3 vt = gmi.Component.InverseTransformScaled(
					v.ToNumericsVector()
				);
				e.Values.Add(
					new GmdcElementValueThreeFloat(
						(float)vt.X,
						(float)vt.Y,
						(float)vt.Z
					)
				);
			}

			return e;
		}

		GmdcElement BuildNormalElement()
		{
			if (mesh.Normals.Count == 0)
			{
				return null;
			}

			GmdcElement e = new GmdcElement(gmi.Gmdc)
			{
				SetFormat = SetFormat.Secondary,
				BlockFormat = BlockFormat.ThreeFloat,
				Identity = ElementIdentity.Normal,
				GroupId = 0,

				Number = mesh.Normals.Count
			};

			foreach (Ambertation.Geometry.Vector3 v in mesh.Normals)
			{
				Vector3 vt = gmi.Component.InverseTransformNormal(
					v.ToNumericsVector()
				);
				e.Values.Add(
					new GmdcElementValueThreeFloat(
						(float)vt.X,
						(float)vt.Y,
						(float)vt.Z
					)
				);
			}

			return e;
		}

		GmdcElement BuildTextureElement()
		{
			if (mesh.TextureCoordinates.Count == 0)
			{
				return null;
			}

			GmdcElement e = new GmdcElement(gmi.Gmdc)
			{
				SetFormat = SetFormat.Secondary,
				BlockFormat = BlockFormat.TwoFloat,
				Identity = ElementIdentity.UVCoordinate,
				GroupId = 0,

				Number = mesh.Normals.Count
			};

			foreach (Ambertation.Geometry.Vector2 v in mesh.TextureCoordinates)
			{
				e.Values.Add(
					new GmdcElementValueTwoFloat((float)v.X, (float)(1 - v.Y))
				);
			}

			return e;
		}

		GmdcElement BuildBoneElement()
		{
			if (mesh.Envelopes.Count == 0)
			{
				return null;
			}

			GmdcElement e = new GmdcElement(gmi.Gmdc)
			{
				SetFormat = SetFormat.Secondary,
				BlockFormat = BlockFormat.OneDword,
				Identity = ElementIdentity.BoneAssignment,
				GroupId = 0,

				Number = mesh.Vertices.Count
			};

			for (int i = 0; i < mesh.Vertices.Count; i++)
			{
				e.Values.Add(new GmdcElementValueOneInt(-1));
			}

			return e;
		}

		GmdcElement BuildWeightElement()
		{
			if (mesh.Envelopes.Count == 0)
			{
				return null;
			}

			GmdcElement e = new GmdcElement(gmi.Gmdc)
			{
				SetFormat = SetFormat.Secondary,
				BlockFormat = BlockFormat.ThreeFloat,
				Identity = ElementIdentity.BoneWeights,
				GroupId = 0,

				Number = mesh.Vertices.Count
			};

			for (int i = 0; i < mesh.Vertices.Count; i++)
			{
				e.Values.Add(new GmdcElementValueThreeFloat(0, 0, 0));
			}

			return e;
		}

		void AddElement(GmdcElement e, GmdcGroup g, bool update)
		{
			if (e == null)
			{
				return;
			}

			if (update)
			{
				GmdcElement eo = g.Link.FindElementType(e.Identity);
				if (eo != null)
				{
					int index = g.Link.GetElementNr(eo);
					index = g.Link.ReferencedElement[index];
					gmi.Gmdc.Elements[index] = eo;

					return;
				}
			}

			gmi.Gmdc.Elements.Add(e);
			g.Link.ReferencedElement.Add(gmi.Gmdc.Elements.Count - 1);
			g.Link.ReferencedSize = g.Link.GetReferencedSize();
			g.Link.ActiveElements = g.Link.ReferencedElement.Count;
		}

		void SetFaces(GmdcGroup g)
		{
			g.Faces.Clear();
			foreach (Ambertation.Geometry.Vector3i v in mesh.FaceIndices)
			{
				g.Faces.Add(v.X);
				g.Faces.Add(v.Y);
				g.Faces.Add(v.Z);
			}
		}

		void SetBones(
			Ambertation.Scenes.Envelope e,
			int index,
			GmdcElement be,
			GmdcElement bw
		)
		{
			for (int i = 0; i < e.Weights.Count; i++)
			{
				if (e.Weights[i] == 0)
				{
					continue;
				}

				GmdcElementValueOneInt a = be.Values[i] as GmdcElementValueOneInt;
				GmdcElementValueThreeFloat w =
					bw.Values[i] as GmdcElementValueThreeFloat;

				int k = -1;
				for (int j = 0; j < 3; j++)
				{
					if (a.Bytes[j] == 0xff)
					{
						k = j;
						break;
					}
				}

				if (k != -1)
				{
					a.SetByte(k, (byte)index);
					w.Data[k] = (float)e.Weights[i];
				}
			}
		}

		void SetUsedJoints(GmdcGroup g)
		{
			g.UsedJoints.Clear();
			GmdcElement be = BuildBoneElement();
			GmdcElement bw = BuildWeightElement();
			AddElement(be, g, Action == GenericMeshImport.ImportAction.Update);
			AddElement(bw, g, Action == GenericMeshImport.ImportAction.Update);
			if (be != null && bw != null)
			{
				foreach (Ambertation.Scenes.Envelope e in mesh.Envelopes)
				{
					if (e.Joint.Tag != null)
					{
						if ((int)e.Joint.Tag >= 0)
						{
							g.UsedJoints.Add((int)e.Joint.Tag);
							SetBones(e, g.UsedJoints.Count - 1, be, bw);
						}
					}
				}
			}
		}
		#endregion

		public void BuildGroup()
		{
			if (
				Group == null
				&& Action == GenericMeshImport.ImportAction.Replace
			)
			{
				Action = GenericMeshImport.ImportAction.Add;
			}

			if (
				Group == null
				&& Action == GenericMeshImport.ImportAction.Update
			)
			{
				Action = GenericMeshImport.ImportAction.Add;
			}

			if (Action == GenericMeshImport.ImportAction.Ignore)
			{
				return;
			}

			GmdcGroup g;
			if (Action == GenericMeshImport.ImportAction.Update)
			{
				g = Group;
			}
			else if (Action == GenericMeshImport.ImportAction.Replace)
			{
				int gindex = gmi.Gmdc.FindGroupByName(Group.Name);
				gmi.Gmdc.RemoveGroup(gindex);

				g = new GmdcGroup(gmi.Gmdc);
				gmi.Gmdc.Groups.Add(g);
			}
			else
			{
				g = new GmdcGroup(gmi.Gmdc);
				gmi.Gmdc.Groups.Add(g);
			}

			//make sure the Group references a Link
			if (g.Link == null)
			{
				GmdcLink l = new GmdcLink(gmi.Gmdc);
				gmi.Gmdc.Links.Add(l);
				g.LinkIndex = gmi.Gmdc.Links.Count - 1;
			}

			g.Name = mesh.Name;
			g.Opacity = Shadow ? 0x10 : 0xffffffff;

			g.PrimitiveType = PrimitiveType.Triangle;

			mesh.Tag = new object[] { this, g };

			AddElement(
				BuildVertexElement(),
				g,
				Action == GenericMeshImport.ImportAction.Update
			);
			AddElement(
				BuildNormalElement(),
				g,
				Action == GenericMeshImport.ImportAction.Update
			);
			AddElement(
				BuildTextureElement(),
				g,
				Action == GenericMeshImport.ImportAction.Update
			);

			SetFaces(g);
			if (ImportEnvelope)
			{
				SetUsedJoints(g);
			}
		}

		#region IDisposable Member

		public override void Dispose()
		{
			base.Dispose();
		}

		#endregion
	}
}
