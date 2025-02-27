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
using System;
using System.Collections;

using SimPe.Geometry;
using SimPe.Plugin.Anim;

namespace SimPe.Plugin.Gmdc.Exporter
{
	/// <summary>
	/// This class provides the functionality to Export Data to the .txt FileFormat
	/// </summary>
	public class GmdcExportToMilkShapeAscii : AbstractGmdcExporter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="gmdc">The Gmdc File the Export is based on</param>
		/// <param name="groups">The list of Groups you want to export</param>
		/// <remarks><see cref="AbstractGmdcExporter.FileContent"/> will contain the Exported .txt File</remarks>
		public GmdcExportToMilkShapeAscii(GeometryDataContainer gmdc, GmdcGroups groups)
			: base(gmdc, groups) { }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="gmdc">The Gmdc File the Export is based on</param>
		/// <remarks><see cref="AbstractGmdcExporter.FileContent"/> will contain the Exported .txt File</remarks>
		public GmdcExportToMilkShapeAscii(GeometryDataContainer gmdc)
			: base(gmdc) { }

		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <remarks>The export has to be started Manual through a call to <see cref="AbstractGmdcExporter.Process"/></remarks>
		public GmdcExportToMilkShapeAscii()
			: base() { }

		int modelnr,
			vertexoffset;

		/// <summary>
		/// Returns the suggested File Extension (including the . like .obj or .3ds)
		/// </summary>
		public override string FileExtension => ".txt";

		/// <summary>
		/// Returns the File Description (the Name of the exported FileType)
		/// </summary>
		public override string FileDescription => "Milkshape 3D ASCII";

		/// <summary>
		/// Returns the name of the Author
		/// </summary>
		public override string Author => "Emily";

		/// <summary>
		/// Called when a new File is started
		/// </summary>
		/// <remarks>
		/// you should use this to write Header Informations.
		/// Use the writer member to write to the File
		/// </remarks>
		protected override void InitFile()
		{
			modelnr = 0;
			vertexoffset = 0;

			//When we have a Animation, we need to Set the Frame Count
			if (Gmdc.LinkedAnimation != null)
			{
				int maxframe = 1;
				//foreach (AnimBlock2 ab2 in Gmdc.LinkedAnimation.Part2)
				//	foreach (AnimationFrame af in ab2.Frames)
				maxframe = Math.Max(maxframe, Gmdc.LinkedAnimation.Animation.TotalTime);

				writer.WriteLine("Frames: " + maxframe.ToString());
				writer.WriteLine("Frame: 1");
			}

			writer.WriteLine("Meshes: " + Groups.Count.ToString());
		}

		/// <summary>
		/// This is called whenever a Group (=subSet) needs to processed
		/// </summary>
		/// <remarks>
		/// You can use the UVCoordinateElement, NormalElement,
		/// VertexElement, Group and Link Members in this Method.
		///
		/// This Method is only called, when the Group, Link and
		/// Vertex Members are set (not null). The other still can
		/// be Null!
		///
		/// Use the writer member to write to the File.
		/// </remarks>
		protected override void ProcessGroup()
		{
			//Find the BoneAssignment
			GmdcElement boneelement = Link.FindElementType(
				ElementIdentity.BoneAssignment
			);
			//List of ordered Joints
			IntArrayList js = Gmdc.SortJoints();

			writer.WriteLine("\"" + Group.Name + "\" 0 -1");

			//first, write the availabel Vertices
			int vertexcount = 0;
			int nr = Link.GetElementNr(VertexElement);
			int nnr = -1;
			if (UVCoordinateElement != null)
			{
				nnr = Link.GetElementNr(UVCoordinateElement);
			}

			writer.WriteLine(Link.ReferencedSize.ToString());

			for (int i = 0; i < Link.ReferencedSize; i++)
			{
				//Make sure we transform to the desired Coordinate-System
				Vector3f v = new Vector3f(
					Link.GetValue(nr, i).Data[0],
					Link.GetValue(nr, i).Data[1],
					Link.GetValue(nr, i).Data[2]
				);
				v = Component.TransformScaled(v);

				writer.Write(
					"0 "
						+ v.X.ToString("N12", DefaultCulture)
						+ " "
						+ v.Y.ToString("N12", DefaultCulture)
						+ " "
						+ v.Z.ToString("N12", DefaultCulture)
						+ " "
				);

				if (nnr != -1)
				{
					writer.Write(
						Link.GetValue(nnr, i).Data[0].ToString(
							"N6",
							DefaultCulture
						)
							+ " "
							+ Link.GetValue(nnr, i).Data[1].ToString(
								"N6",
								DefaultCulture
							)
							+ " "
					);
				}
				else
				{
					writer.Write(" 0.000000 0.000000 ");
				}

				if (boneelement == null)
				{
					writer.WriteLine("-1");
				}
				else
				{
					int bnr = Link.GetRealIndex(nr, i);
					if (bnr == -1)
					{
						writer.WriteLine("-1");
					}
					else
					{
						bnr = (
							(GmdcElementValueOneInt)
								boneelement.Values[bnr]
						).Value;
						if (bnr == -1)
						{
							writer.WriteLine("-1");
						}
						else
						{
							bnr &= 0xff;
							bnr = Group.UsedJoints[bnr];
							for (int ij = 0; ij < js.Count; ij++)
							{
								if (js[ij] == bnr)
								{
									bnr = ij;
									break;
								}
							}

							writer.WriteLine(bnr.ToString());
						}
					}
				}
			}

			//Add a MeshNormal Section if available
			if (NormalElement != null)
			{
				nr = Link.GetElementNr(NormalElement);
				writer.WriteLine(Link.ReferencedSize.ToString());
				for (int i = 0; i < Link.ReferencedSize; i++)
				{
					Vector3f v = new Vector3f(
						Link.GetValue(nr, i).Data[0],
						Link.GetValue(nr, i).Data[1],
						Link.GetValue(nr, i).Data[2]
					);
					v = Component.TransformNormal(v);

					writer.WriteLine(
						v.X.ToString("N12", DefaultCulture)
							+ " "
							+ v.Y.ToString("N12", DefaultCulture)
							+ " "
							+ v.Z.ToString("N12", DefaultCulture)
					);
				}
			}
			else
			{
				writer.WriteLine("0");
			}

			//Export Faces
			writer.WriteLine(Group.FaceCount.ToString());
			for (int i = 0; i < Group.Faces.Count; i += 3)
			{
				writer.WriteLine(
					"0 "
						+ Group.Faces[i + 0].ToString()
						+ " "
						+ Group.Faces[i + 1].ToString()
						+ " "
						+ Group.Faces[i + 2].ToString()
						+ " "
						+ Group.Faces[i + 0].ToString()
						+ " "
						+ Group.Faces[i + 1].ToString()
						+ " "
						+ Group.Faces[i + 2].ToString()
						+ " 1"
				);
			}

			vertexoffset += vertexcount;
			modelnr++;
		}

		Vector3f Correct(Vector3f t, object cor)
		{
			return cor == null || cor is Quaternion || !(cor is Vector3f f) ? t : t + f;
		}

		Quaternion Correct(Quaternion t, object cor)
		{
			return cor == null || !(cor is Quaternion quaternion) ? t : t * quaternion;
		}

		/// <summary>
		/// Called when the export was finished
		/// </summary>
		/// <remarks>you should use this to write Footer Informations.
		/// Use the writer member to write to the File</remarks>
		protected override void FinishFile()
		{
			writer.WriteLine("Materials: 0");

			Hashtable relationmap = Gmdc.LoadJointRelationMap();
			IntArrayList js = Gmdc.SortJoints(relationmap);
			ArrayList animbname = new ArrayList();

			Hashtable correct_rot = new Hashtable();
			Hashtable correct_trans = new Hashtable();
			if (CorrectJointSetup)
			{
				//Correct the Exported Joint Definitions in a way that _trans
				//Joint sonly conatin Translations and _rot Joints only contain Rotations

				foreach (int i in js)
				{
					if (i >= Gmdc.Model.Transformations.Length)
					{
						break;
					}

					string name = Gmdc.Joints[i].Name;
					if (name.EndsWith("_rot"))
					{
						string aname = name.Substring(0, name.Length - 4) + "_trans";
						if (Gmdc.Joints.Contains(aname))
						{
							correct_trans[name] = Gmdc.Joints[i]
								.AssignedTransformNode.Translation.GetInverse();
							correct_trans[aname] = Gmdc.Joints[i]
								.AssignedTransformNode
								.Translation;
						}
					}
					else if (name.EndsWith("_trans"))
					{
						string aname = name.Substring(0, name.Length - 6) + "_rot";
						if (Gmdc.Joints.Contains(aname))
						{
							correct_rot[name] = Gmdc.Joints[i]
								.AssignedTransformNode.Rotation.GetInverse();
							correct_rot[aname] = Gmdc.Joints[i]
								.AssignedTransformNode
								.Rotation;
						}
					}
				}
			}

			//Export Bones
			writer.WriteLine("Bones: " + js.Count.ToString());
			foreach (int i in js)
			{
				if (i >= Gmdc.Model.Transformations.Length)
				{
					break;
				}

				writer.WriteLine("\"" + Gmdc.Joints[i].Name + "\"");

				if (relationmap.ContainsKey(i))
				{
					int parent = (int)relationmap[i];
					if (parent != -1)
					{
						writer.WriteLine("\"" + Gmdc.Joints[parent].Name + "\"");
					}
					else
					{
						writer.WriteLine("\"\"");
					}
				}
				else
				{
					writer.WriteLine("\"\"");
				}

				if (Gmdc.Joints[i].AssignedTransformNode != null)
				{
					Vector3f t = Gmdc.Joints[i].AssignedTransformNode.Translation;
					if (CorrectJointSetup)
					{
						t = Correct(t, correct_trans[Gmdc.Joints[i].Name]);
					}
					//t = Gmdc.Joints[i].AssignedTransformNode.Rotation.Rotate(t);
					t = Component.TransformScaled(t);

					Quaternion q = Gmdc.Joints[i].AssignedTransformNode.Rotation;
					if (CorrectJointSetup)
					{
						q = Correct(q, correct_rot[Gmdc.Joints[i].Name]);
					}

					Vector3f r = q.Axis;
					r = Component.Transform(r);
					q = Quaternion.FromAxisAngle(r, q.Angle);
					//q.W = -q.W;
					r = q.GetEulerAngles();

					writer.WriteLine(
						"8 "
							+ t.X.ToString("N12", DefaultCulture)
							+ " "
							+ t.Y.ToString("N12", DefaultCulture)
							+ " "
							+ t.Z.ToString("N12", DefaultCulture)
							+ " "
							+ r.X.ToString("N12", DefaultCulture)
							+ " "
							+ r.Y.ToString("N12", DefaultCulture)
							+ " "
							+ r.Z.ToString("N12", DefaultCulture)
					);
				}
				else
				{
					writer.WriteLine("8 0 0 0 0 0 0");
				}

				if (Gmdc.LinkedAnimation != null)
				{
					//get the correction Vector
					Vector3f cv = AbstractGmdcImporter.GetCorrectionVector(
						Gmdc.Joints[i].Name
					);

					//get Translation Frames
					AnimationFrameBlock ab =
						Gmdc.LinkedAnimation.GetJointTransformation(
							Gmdc.Joints[i].Name,
							FrameType.Translation
						);
					if (ab != null)
					{
						if (ab.AxisCount > 0)
						{
							animbname.Add("trn: " + Gmdc.Joints[i].Name);
							AnimationFrame[] afs = ab.InterpolateMissingFrames();

							int ct = afs.Length;
							if (ab.AxisSet[0].Locked)
							{
								ct += 2;
							}

							writer.WriteLine(ct.ToString());

							//bool first = true;
							foreach (AnimationFrame af in afs)
							{
								Vector3f v = af.Vector;

								//if (first)
								v += cv; //corect static Values

								v = Component.TransformScaled(v);

								int tc = af.TimeCode + 1;
								if (ab.AxisSet[0].Locked && tc == 1)
								{
									tc = -1;
								}

								writer.WriteLine(
									tc.ToString()
										+ " "
										+ v.X.ToString(
											"N12",
											DefaultCulture
										)
										+ " "
										+ v.Y.ToString(
											"N12",
											DefaultCulture
										)
										+ " "
										+ v.Z.ToString(
											"N12",
											DefaultCulture
										)
								);

								if (ab.AxisSet[0].Locked && tc == -1)
								{
									writer.WriteLine("0 0 0 0");
									writer.WriteLine("1 0 0 0");
								}
								//first = false;
							}
						}
						else
						{
							writer.WriteLine("0");
						}
					}
					else
					{
						writer.WriteLine("0");
					}

					//Get Rotation Frames
					ab = Gmdc.LinkedAnimation.GetJointTransformation(
						Gmdc.Joints[i].Name,
						FrameType.Rotation
					);
					if (ab != null)
					{
						animbname.Add("rot: " + Gmdc.Joints[i].Name);
						AnimationFrame[] afs = ab.InterpolateMissingFrames();

						int ct = afs.Length;
						if (ab.AxisSet[0].Locked)
						{
							ct += 2;
						}

						writer.WriteLine(ct.ToString());
						//bool first = true;
						foreach (AnimationFrame af in afs)
						{
							Vector3f v = af.Vector;
							//Transform the Angles in their Axis/Angle Form
							Quaternion q = Quaternion.FromEulerAngles(v);
							v = q.Axis;
							v = Component.Transform(v);
							q = Quaternion.FromAxisAngle(v, q.Angle);
							v = q.GetEulerAngles();

							//if (first)
							v += Component.Transform(cv); //correct static Values

							int tc = af.TimeCode + 1;
							if (ab.AxisSet[0].Locked && tc == 1)
							{
								tc = -1;
							}

							writer.WriteLine(
								(af.TimeCode + 1).ToString()
									+ " "
									+ v.X.ToString(
										"N12",
										DefaultCulture
									)
									+ " "
									+ v.Y.ToString(
										"N12",
										DefaultCulture
									)
									+ " "
									+ v.Z.ToString(
										"N12",
										DefaultCulture
									)
							);

							if (ab.AxisSet[0].Locked && tc == -1)
							{
								writer.WriteLine("0 0 0 0");
								writer.WriteLine("1 0 0 0");
							}

							//first = false;
						}
					}
					else
					{
						writer.WriteLine("0");
					}
				}
				else
				{
					writer.WriteLine("0");
					writer.WriteLine("0");
				}
			}

			//Write Footer
			writer.WriteLine("GroupComments: 0");
			writer.WriteLine("MaterialComments: 0");
			writer.WriteLine("BoneComments: 0");
			writer.WriteLine("ModelComment: 0");
		}
	}
}
