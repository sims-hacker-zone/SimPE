// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using Ambertation.Scenes;

using SimPe.Extensions;
using SimPe.Geometry;
using SimPe.Plugin.Gmdc;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class contains the Geometric Data of an Object
	/// </summary>
	public class GeometryDataContainerExt : IDisposable
	{
		bool joints;

		public GeometryDataContainerExt(GeometryDataContainer gmdc)
			: this(gmdc, true) { }

		public GeometryDataContainerExt(GeometryDataContainer gmdc, bool withjoints)
		{
			joints = withjoints;
			Gmdc = gmdc;
			UserTxtrMap = new Hashtable();
			UserTxmtMap = new Hashtable();
		}

		public GeometryDataContainer Gmdc
		{
			get; private set;
		}

		/// <summary>
		/// Used as a User Override for the automatically created List of TXMTs, which is used for
		/// the Objects Textures
		/// </summary>
		/// <remarks>Keyas are the SubSet Names, the Values are <see cref="GenericRcol"/> Instances,
		/// that hold the TXMT for that Subset</remarks>
		public Hashtable UserTxtrMap
		{
			get;
		}

		/// <summary>
		/// Used as a User Override for the automatically created List of TXTRs, which is used for
		/// the Objects Textures
		/// </summary>
		/// <remarks>Keyas are the SubSet Names, the Values are <see cref="GenericRcol"/> Instances,
		/// that hold the TXTR for that Subset</remarks>
		public Hashtable UserTxmtMap
		{
			get;
		}

		public Scene GetScene(
			string absimgpath,
			string imgfolder,
			ElementOrder component
		)
		{
			return GetScene(Gmdc.Groups, absimgpath, imgfolder, component);
		}

		public Scene GetScene(
			string absimgpath,
			ElementOrder component
		)
		{
			return GetScene(Gmdc.Groups, absimgpath, null, component);
		}

		public Scene GetScene(ElementOrder component)
		{
			return GetScene(Gmdc.Groups, null, null, component);
		}

		void AddJoint(
			Joint parent,
			int index,
			Hashtable jointmap,
			ElementOrder component
		)
		{
			if (!joints)
			{
				return;
			}

			if (index < 0 || index >= Gmdc.Joints.Count)
			{
				return;
			}

			GmdcJoint j = Gmdc.Joints[index];
			Joint nj = parent.CreateChild(j.Name);
			jointmap[index] = nj;

			if (j.AssignedTransformNode != null)
			{
				Vector3 tmp = j.AssignedTransformNode.Transformation.Translation;
				tmp = component.TransformScaled(tmp);
				//tmp = component.ScaleMatrix * tmp;

				nj.Translation.X = tmp.X;
				nj.Translation.Y = tmp.Y;
				nj.Translation.Z = tmp.Z;

				System.Numerics.Quaternion q = component.TransformRotation(
					j.AssignedTransformNode.Transformation.Rotation
				);
				tmp = q.GetEulerAnglesZYX();

				//Console.WriteLine("        "+q.ToLinedString());
				nj.Rotation.X = tmp.X;
				nj.Rotation.Y = tmp.Y;
				nj.Rotation.Z = tmp.Z;

				List<int> li = j.AssignedTransformNode.ChildBlocks;
				foreach (int i in li)
				{
					Interfaces.Scenegraph.ICresChildren cld =
						j.AssignedTransformNode.GetBlock(i);
					if (cld is TransformNode)
					{
						TransformNode tn = cld as TransformNode;
						if (tn.JointReference != TransformNode.NO_JOINT)
						{
							AddJoint(nj, tn.JointReference, jointmap, component);
						}
					}
				}
			}
		}

		Hashtable AddJointsToScene(Scene scn, ElementOrder component)
		{
			if (!joints)
			{
				return new Hashtable();
			}

			List<int> js = new List<int>();
			Hashtable relationmap = Gmdc.LoadJointRelationMap();

			foreach (int k in relationmap.Keys)
			{
				if ((int)relationmap[k] == -1)
				{
					js.Add(k);
				}
			}

			System.Numerics.Quaternion r = System.Numerics.Quaternion.CreateFromRotationMatrix(component.TransformMatrix);
			Vector3 tmp = r.GetEulerAnglesZYX();
			scn.RootJoint.Name = "SIMPE_ROOT_IGNORE";
			//scn.RootJoint.Rotation.X = tmp.X; scn.RootJoint.Rotation.Y = tmp.Y; scn.RootJoint.Rotation.Z = tmp.Z;

			Hashtable jointmap = new Hashtable();
			foreach (int index in js)
			{
				AddJoint(scn.RootJoint, index, jointmap, component);
			}

			return jointmap;
		}

		public Scene GetScene(
			List<GmdcGroup> groups,
			ElementOrder component
		)
		{
			return GetScene(groups, null, null, component);
		}

		public Scene GetScene(
			List<GmdcGroup> groups,
			string absimgpath,
			ElementOrder component
		)
		{
			return GetScene(groups, absimgpath, null, component);
		}

		public Scene GetScene(
			List<GmdcGroup> groups,
			string absimgpath,
			string imgfolder,
			ElementOrder component
		)
		{
			if (absimgpath != null)
			{
				if (imgfolder == null)
				{
					imgfolder = absimgpath;
				}

				imgfolder = imgfolder.Trim();
				if (imgfolder.Length > 0 && !imgfolder.EndsWith(@"\"))
				{
					imgfolder += @"\";
				}

				if (!System.IO.Directory.Exists(absimgpath))
				{
					System.IO.Directory.CreateDirectory(absimgpath);
				}
			}

			Scene scn = new Scene();

			Hashtable jointmap = new Hashtable();
			try
			{
				jointmap = AddJointsToScene(scn, component);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
			}

			TextureLocator tl = new TextureLocator(Gmdc.Parent.Package);
			Hashtable txmts = tl.FindMaterials(Gmdc.Parent);
			foreach (string key in UserTxmtMap.Keys)
			{
				object o = UserTxmtMap[key];
				if (o != null)
				{
					txmts[key] = UserTxmtMap[key];
				}
			}

			Hashtable txtrs = tl.FindReferencedTXTR(txmts, null);
			foreach (string key in UserTxtrMap.Keys)
			{
				object o = UserTxtrMap[key];
				if (o != null)
				{
					txtrs[key] = o;
				}
			}

			txtrs = tl.GetLargestImages(txtrs);
			txmts = tl.GetMaterials(txmts, scn);
			tl.Dispose();

			foreach (GmdcGroup g in groups)
			{
				if (!(txmts[g.Name] is Material mat))
				{
					mat = scn.CreateMaterial("mat_" + g.Name);
				}
				else
				{
					mat.Name = "mat_" + g.Name;
				}

				if (txtrs[g.Name] is System.IO.MemoryStream s)
				{
					try
					{
						System.Drawing.Image img = System.Drawing.Image.FromStream(s);
						if (absimgpath != null)
						{
							img.Save(
								System.IO.Path.Combine(absimgpath, g.Name + ".png"),
								System.Drawing.Imaging.ImageFormat.Png
							);
						}

						mat.Texture.FileName = imgfolder + g.Name + ".png";
						mat.Texture.Size = img.Size;
						mat.Texture.TextureImage = img;
					}
					catch { }
				}
				Mesh m = scn.CreateMesh(g.Name, mat);

				GmdcElement vertexe = g.Link.FindElementType(ElementIdentity.Vertex);
				//	GmdcElement vertexme = g.Link.FindElementType(ElementIdentity.MorphVertexDelta);
				GmdcElement normale = g.Link.FindElementType(ElementIdentity.Normal);
				GmdcElement texte = g.Link.FindElementType(
					ElementIdentity.UVCoordinate
				);
				GmdcElement bonee = g.Link.FindElementType(
					ElementIdentity.BoneAssignment
				);
				GmdcElement bonewighte = g.Link.FindElementType(
					ElementIdentity.BoneWeights
				);
				GmdcElement bumpnormal = g.Link.FindElementType(
					ElementIdentity.BumpMapNormal
				);

				int nr = g.Link.GetElementNr(vertexe);
				//	int mnr = g.Link.GetElementNr(vertexme);
				for (int i = 0; i < g.Link.ReferencedSize; i++)
				{
					Vector3 v = new Vector3(
						g.Link.GetValue(nr, i).Data[0],
						g.Link.GetValue(nr, i).Data[1],
						g.Link.GetValue(nr, i).Data[2]
					);
					/*Vector3f vm = new Vector3f(g.Link.GetValue(mnr, i).Data[0], g.Link.GetValue(mnr, i).Data[1], g.Link.GetValue(mnr, i).Data[2]);
					v += vm;*/
					v = component.TransformScaled(v);

					m.Vertices.Add(v.X, v.Y, v.Z);
				}

				if (normale != null)
				{
					nr = g.Link.GetElementNr(normale);
					for (int i = 0; i < g.Link.ReferencedSize; i++)
					{
						Vector3 v = new Vector3(
							g.Link.GetValue(nr, i).Data[0],
							g.Link.GetValue(nr, i).Data[1],
							g.Link.GetValue(nr, i).Data[2]
						);
						v = component.TransformNormal(v);
						m.Normals.Add(v.X, v.Y, v.Z);
					}
				}

				if (bumpnormal != null)
				{
					nr = g.Link.GetElementNr(bumpnormal);
					for (int i = 0; i < g.Link.ReferencedSize; i++)
					{
						Vector3 v = new Vector3(
							g.Link.GetValue(nr, i).Data[0],
							g.Link.GetValue(nr, i).Data[1],
							g.Link.GetValue(nr, i).Data[2]
						);
						v = component.TransformNormal(v);
						m.BumpMapNormalDelta.Add(v.X, v.Y, v.Z);
					}
				}

				if (texte != null)
				{
					nr = g.Link.GetElementNr(texte);
					for (int i = 0; i < g.Link.ReferencedSize; i++)
					{
						Vector2 v = new Vector2(
							g.Link.GetValue(nr, i).Data[0],
							g.Link.GetValue(nr, i).Data[1]
						);
						m.TextureCoordinates.Add(v.X, 1 - v.Y);
					}
				}

				for (int i = 0; i < g.Faces.Count - 2; i += 3)
				{
					m.FaceIndices.Add(g.Faces[i], g.Faces[i + 1], g.Faces[i + 2]);
				}

				AddEnvelopes(g, m, bonee, bonewighte, jointmap);
			}

			return scn;
		}

		void AddEnvelopes(
			GmdcGroup g,
			Mesh m,
			GmdcElement bonee,
			GmdcElement bonewighte,
			Hashtable jointmap
		)
		{
			if (bonee != null && true)
			{
				int pos = 0;
				foreach (GmdcElementValueOneInt vi in bonee.Values)
				{
					byte[] data = vi.Bytes;
					List<int> used = new List<int>();

					for (int datapos = 0; datapos < 3; datapos++) //we can only store 3 bone weights
					{
						byte b = data[datapos];
						if (b != 0xff && b < g.UsedJoints.Count)
						{
							int bnr = g.UsedJoints[b];
							if (used.Contains(bnr))
							{
								continue;
							}

							used.Add(bnr);
							if (jointmap[bnr] is Joint nj)
							{
								double w = 1;
								if (bonewighte != null)
								{
									if (bonewighte.Values.Count > pos)
									{
										GmdcElementValueBase v =
											bonewighte.Values[pos];
										if (datapos < v.Data.Length)
										{
											w = v.Data[datapos];
										}
									}
								}

								//if there is no envelope for nj, make sure we get a new one
								//with pos 0-Weights inserted
								Envelope e = m.GetJointEnvelope(
									nj,
									pos
								);
								e.Weights.Add(w);
								//added = true;
							}
						}
					}

					pos++;
					m.SyncEnvelopeLenghts(pos); //fill all unset EnvelopeWeights with 0
				} // bonee.Values
			}
		}

		#region IDisposable Member

		public void Dispose()
		{
			UserTxtrMap.Clear();
			UserTxmtMap.Clear();
			Gmdc = null;
		}

		#endregion
	}
}
