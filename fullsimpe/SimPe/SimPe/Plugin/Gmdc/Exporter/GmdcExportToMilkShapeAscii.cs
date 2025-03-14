// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

using SimPe.Extensions;
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
		public GmdcExportToMilkShapeAscii(GeometryDataContainer gmdc, List<GmdcGroup> groups)
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
			List<int> js = Gmdc.SortJoints();

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
				Vector3 v = new Vector3(
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
					Vector3 v = new Vector3(
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

		Vector3 Correct(Vector3 t, object cor)
		{
			return cor == null || cor is Quaternion || !(cor is Vector3 f) ? t : t + f;
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
			List<int> js = Gmdc.SortJoints(relationmap);
			ArrayList animbname = new ArrayList();

			Hashtable correct_rot = new Hashtable();
			Hashtable correct_trans = new Hashtable();
			if (CorrectJointSetup)
			{
				//Correct the Exported Joint Definitions in a way that _trans
				//Joint sonly conatin Translations and _rot Joints only contain Rotations

				foreach (int i in js)
				{
					if (i >= Gmdc.Model.Transformations.Count)
					{
						break;
					}

					string name = Gmdc.Joints[i].Name;
					if (name.EndsWith("_rot"))
					{
						string aname = name.Substring(0, name.Length - 4) + "_trans";
						if (Gmdc.Joints.Any(joint => joint.Name.Trim().ToLower() == aname))
						{
							correct_trans[name] = Gmdc.Joints[i]
								.AssignedTransformNode.Translation * -1f;
							correct_trans[aname] = Gmdc.Joints[i]
								.AssignedTransformNode
								.Translation;
						}
					}
					else if (name.EndsWith("_trans"))
					{
						string aname = name.Substring(0, name.Length - 6) + "_rot";
						if (Gmdc.Joints.Any(joint => joint.Name.Trim().ToLower() == aname))
						{
							correct_rot[name] = Gmdc.Joints[i]
								.AssignedTransformNode.Rotation * -1f;
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
				if (i >= Gmdc.Model.Transformations.Count)
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
					Vector3 t = Gmdc.Joints[i].AssignedTransformNode.Translation;
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

					Vector3 r = q.GetAxis();
					r = Component.Transform(r);
					q = Quaternion.CreateFromAxisAngle(r, q.GetAngle());
					//q.W = -q.W;
					r = q.GetEulerAnglesZYX();

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
					Vector3 cv = AbstractGmdcImporter.GetCorrectionVector(
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
								Vector3 v = af.Vector;

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
							Vector3 v = af.Vector;
							//Transform the Angles in their Axis/Angle Form
							Quaternion q = Quaternion.CreateFromYawPitchRoll(v.X, v.Y, v.Z);
							v = q.GetAxis();
							v = Component.Transform(v);
							q = Quaternion.CreateFromAxisAngle(v, q.GetAngle());
							v = q.GetEulerAnglesZYX();

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
