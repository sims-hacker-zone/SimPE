// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;

using Ambertation.Geometry;
using Ambertation.Graphics;
using Ambertation.Scenes.Collections;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using SimPe.Geometry;

using static Ambertation.Windows.Forms.APIHelp;

using Vector3i = Ambertation.Geometry.Vector3i;

namespace Ambertation.Scenes
{
	public class SceneToMesh : IConvertScene, IDisposable
	{
		protected static Color[] Colors = new Color[10]
		{
		Color.Orange,
		Color.YellowGreen,
		Color.Magenta,
		Color.Maroon,
		Color.LimeGreen,
		Color.Red,
		Color.Yellow,
		Color.Blue,
		Color.BlueViolet,
		Color.ForestGreen
		};

		protected int index;

		private static Random rnd = new Random();

		private Hashtable colormap;

		private Scene scn;

		private Device dev;

		private float scale;

		internal DirectXPanel dxp;

		protected float Scale
		{
			get
			{
				if (dxp != null)
				{
					return dxp.Settings.LineWidth * dxp.Settings.JointScale;
				}

				return scale;
			}
		}

		public Color GetRandomColor()
		{
			if (index < Colors.Length)
			{
				return Colors[index++];
			}

			return Color.FromArgb(rnd.Next(190) + 30, rnd.Next(190) + 30, rnd.Next(190) + 30);
		}

		public SceneToMesh(Scene scn, DirectXPanel dp)
			: this(scn, dp.Device, dp.Settings.LineWidth)
		{
			dxp = dp;
			colormap = new Hashtable();
		}

		public Color GetJointColor(Joint j)
		{
			if (j == null)
			{
				return Color.Black;
			}

			if (colormap == null)
			{
				colormap = new Hashtable();
			}

			object obj = colormap[j.Name];
			if (obj == null)
			{
				obj = GetRandomColor();
				colormap[j.Name] = obj;
			}

			return (Color)obj;
		}

		public SceneToMesh(Scene scn, Device dev, double scale)
		{
			this.scn = scn;
			this.dev = dev;
			this.scale = (float)scale;
			dxp = null;
		}

		public object Convert()
		{
			return ConvertToDx();
		}

		protected void AddJointMesh(JointCollectionBase selected, MeshList ret, Joint joint)
		{
			float num = Scale;
			if (selected != null && selected.Contains(joint))
			{
				num *= 2f;
			}

			Microsoft.DirectX.Matrix transform = Converter.ToDx(joint);
			MeshBox meshBox = new MeshBox(Microsoft.DirectX.Direct3D.Mesh.Sphere(dev, num, 24, 24), 1, DirectXPanel.GetMaterial(GetJointColor(joint)), transform);
			meshBox.Wire = false;
			meshBox.JointMesh = true;
			ret.Add(meshBox);
			if (dxp != null && !joint.Parent.Root)
			{
				Microsoft.DirectX.Vector3 stop = new Microsoft.DirectX.Vector3(0f, 0f, 0f);
				stop.TransformCoordinate(Converter.ToDx(joint));
				MeshBox[] array = dxp.CreateLineMesh(new Microsoft.DirectX.Vector3(0f, 0f, 0f), stop, DirectXPanel.GetMaterial(Color.LightYellow), wire: false, arrow: false);
				MeshBox[] array2 = array;
				foreach (MeshBox meshBox2 in array2)
				{
					meshBox2.JointMesh = true;
				}

				ret.AddRange(array);
			}

			foreach (Joint item in joint)
			{
				AddJointMesh(selected, meshBox, item);
			}
		}

		protected void AddJointMeshs(JointCollectionBase selected, MeshList ret, Joint root)
		{
			foreach (Joint item in root)
			{
				AddJointMesh(selected, ret, item);
			}
		}

		public MeshList ConvertToDx(JointCollectionBase joints)
		{
			scn.ClearTags();
			Scene scene = new Scene();
			scene.DefaultMaterial.Diffuse = Color.Black;
			scene.DefaultMaterial.Ambient = Color.Black;
			scene.DefaultMaterial.Specular = Color.FromArgb(32, 32, 32);
			scene.DefaultMaterial.SpecularPower = 300.0;
			scene.DefaultMaterial.Mode = Material.TextureModes.Default;
			MeshList meshList = new MeshList();
			AddJointMeshs(joints, meshList, scn.RootJoint);
			if (joints.Count == 0)
			{
				return meshList;
			}

			foreach (Mesh item in scn.SceneRoot)
			{
				Mesh dst = scene.CreateMesh(item.Name);
				for (int i = 0; i < item.FaceIndices.Count; i++)
				{
					CopyElement(joints, item, dst, i);
				}
			}

			scn.ClearTags();
			SceneToMesh sceneToMesh = null;
			sceneToMesh = ((dxp == null) ? new SceneToMesh(scene, dev, Scale) : new SceneToMesh(scene, dxp));
			MeshList m = sceneToMesh.ConvertToDx();
			meshList.AddRange(m);
			scene.Dispose();
			return meshList;
		}

		private int Clamp(int i)
		{
			if (i < 0)
			{
				i = 0;
			}

			if (i > 255)
			{
				i = 255;
			}

			return i;
		}

		private void CopyElement(JointCollectionBase joints, Mesh src, Mesh dst, int findex)
		{
			Vector3i vector3i = new Vector3i(0, 0, 0);
			for (int i = 0; i < 3; i++)
			{
				int num = src.FaceIndices[findex][i];
				vector3i[i] = dst.Vertices.Count;
				dst.Vertices.Add(src.Vertices[num]);
				if (src.Normals.Count > 0)
				{
					dst.Normals.Add(src.Normals[num]);
				}

				Color c = Color.FromArgb(255, Color.Black);
				foreach (Envelope envelope in src.Envelopes)
				{
					if (joints.Contains(envelope.Joint))
					{
						double w = envelope.Weights[num];
						Color color = Blend(w, Color.Black, GetJointColor(envelope.Joint));
						c = Color.FromArgb(Clamp(c.A + color.A), Clamp(c.R + color.R), Clamp(c.G + color.G), Clamp(c.B + color.B));
					}
				}

				dst.Colors.Add(Helpers.ToVector4(c));
			}

			dst.FaceIndices.Add(vector3i);
		}

		public MeshList ConvertToDx(Joint j)
		{
			return ConvertToDx(j, GetJointColor(j));
		}

		public MeshList ConvertToDx(Joint j, Color maxcl)
		{
			return ConvertToDx(j, Color.FromArgb(0, maxcl), maxcl);
		}

		public MeshList ConvertToDx(Joint j, Color mincl, Color maxcl)
		{
			scn.ClearTags();
			Scene scene = new Scene();
			scene.DefaultMaterial.Diffuse = Color.Transparent;
			scene.DefaultMaterial.Ambient = Color.Transparent;
			scene.DefaultMaterial.Specular = Color.Transparent;
			scene.DefaultMaterial.SpecularPower = 100.0;
			scene.DefaultMaterial.Mode = Material.TextureModes.Default;
			MeshList meshList = new MeshList();
			JointCollection jointCollection = new JointCollection();
			jointCollection.Add(j);
			AddJointMeshs(jointCollection, meshList, scn.RootJoint);
			jointCollection.Clear();
			jointCollection.Dispose();
			foreach (Mesh item in scn.SceneRoot)
			{
				Envelope envelope = null;
				foreach (Envelope envelope2 in item.Envelopes)
				{
					if (envelope2.Joint == j)
					{
						envelope = envelope2;
						break;
					}
				}

				if (envelope == null)
				{
					continue;
				}

				Mesh dst = scene.CreateMesh(item.Name);
				for (int i = 0; i < item.FaceIndices.Count; i++)
				{
					if (HasWeight(item, i, envelope))
					{
						CopyElement(item, dst, i, mincl, maxcl, envelope);
					}
				}
			}

			scn.ClearTags();
			SceneToMesh sceneToMesh = null;
			sceneToMesh = ((dxp == null) ? new SceneToMesh(scene, dev, Scale) : new SceneToMesh(scene, dxp));
			MeshList m = sceneToMesh.ConvertToDx();
			meshList.AddRange(m);
			scene.Dispose();
			return meshList;
		}

		private bool HasWeight(Mesh src, int findex, Envelope e)
		{
			for (int i = 0; i < 3; i++)
			{
				int num = src.FaceIndices[findex][i];
				double num2 = e.Weights[num];
				if (num2 != 0.0)
				{
					return true;
				}
			}

			return false;
		}

		private void CopyElement(Mesh src, Mesh dst, int findex, Color mincl, Color maxcl, Envelope e)
		{
			Vector3i vector3i = new Vector3i(0, 0, 0);
			for (int i = 0; i < 3; i++)
			{
				int num = src.FaceIndices[findex][i];
				vector3i[i] = dst.Vertices.Count;
				dst.Vertices.Add(src.Vertices[num]);
				if (src.Normals.Count > 0)
				{
					dst.Normals.Add(src.Normals[num]);
				}

				if (src.Colors.Count > 0 && e == null)
				{
					dst.Colors.Add(src.Colors[num]);
					continue;
				}

				double w = e.Weights[num];
				Color c = Blend(w, mincl, maxcl);
				dst.Colors.Add(Helpers.ToVector4(c));
			}

			dst.FaceIndices.Add(vector3i);
		}

		private Color Blend(double w, Color mincl, Color maxcl)
		{
			return Color.FromArgb(Blend(w, mincl.A, maxcl.A), Blend(w, mincl.R, maxcl.R), Blend(w, mincl.G, maxcl.G), Blend(w, mincl.B, maxcl.B));
		}

		private int Blend(double w, int none, int full)
		{
			return (int)Math.Min(255.0, Math.Max(0.0, w * (double)(float)full + (1.0 - w) * (double)(float)none));
		}

		public MeshList ConvertToDx()
		{
			scn.ClearTags();
			MeshList meshList = new MeshList();
			AddJointMeshs(null, meshList, scn.RootJoint);
			foreach (Mesh item in scn.SceneRoot)
			{
				AddMesh(meshList, item);
			}

			scn.ClearTags();
			return meshList;
		}

		private void AddMesh(MeshList ret, Mesh m)
		{
			MeshBox meshBox = AddMesh(ret, m, isbb: false);
			if (meshBox == null)
			{
				return;
			}

			foreach (Mesh child in m.Childs)
			{
				AddMesh(meshBox, child);
			}
		}

		private MeshBox AddMesh(MeshList ret, Mesh m, bool isbb)
		{
			MeshBox meshBox = CreateDxMesh(dev, m, isbb);
			if (meshBox != null)
			{
				ret.Add(meshBox);
			}

			return meshBox;
		}

		public static MeshBox CreateDxMesh(Device dev, Mesh m, bool isbb)
		{
			short[] data = m.FaceIndices.ToArrayOfShort();
			object vertices = null;
			bool computenormals = true;
			VertexFormats vertexFormat = BuildVertexBuffer(m, ref vertices, ref computenormals);
			if (vertices != null && m.Vertices.Count > 0 && m.FaceIndices.Count > 0)
			{
				Microsoft.DirectX.Direct3D.Mesh mesh = new Microsoft.DirectX.Direct3D.Mesh(m.FaceIndices.Count, m.Vertices.Count, (MeshFlags)0, vertexFormat, dev);
				mesh.SetVertexBufferData(vertices, LockFlags.None);
				mesh.SetIndexBufferData(data, LockFlags.None);
				int[] array = new int[mesh.NumberFaces * 3];
				mesh.GenerateAdjacency(0.01f, array);
				mesh.OptimizeInPlace(MeshFlags.OptimizeVertexCache, array);
				if (computenormals)
				{
					mesh.ComputeNormals(array);
				}

				Microsoft.DirectX.Direct3D.Material mat = LoadMaterial(m);
				MeshBox meshBox = new MeshBox(mesh, 1, mat);
				meshBox.Wire = false;
				if (m.Material.Texture.TextureImage == null)
				{
					m.Material.Texture.ImportTextureImage();
				}

				meshBox.SetTexture(m.Material.Texture.TextureImage);
				meshBox.Transform = Converter.ToDx(m);
				meshBox.TextureMode = m.Material.Mode;
				if (isbb)
				{
					meshBox.CullMode = MeshBox.Cull.None;
					meshBox.Material = DirectXPanel.GetMaterial(Color.Black);
					meshBox.Wire = true;
					meshBox.IgnoreDuringCameraReset = true;
				}

				return meshBox;
			}

			return null;
		}

		private static Microsoft.DirectX.Direct3D.Material LoadMaterial(Mesh m)
		{
			Microsoft.DirectX.Direct3D.Material material = new Microsoft.DirectX.Direct3D.Material();
			m.Material.Tag = material;
			material.Diffuse = m.Material.Diffuse;
			material.Specular = m.Material.Specular;
			material.SpecularSharpness = (float)m.Material.SpecularPower;
			material.Emissive = m.Material.Emmissive;
			material.Ambient = m.Material.Ambient;
			return material;
		}

		private static VertexFormats BuildVertexBuffer(Mesh m, ref object vertices, ref bool computenormals)
		{
			VertexFormats result;
			if (m.Vertices.Count == m.Normals.Count && m.Vertices.Count == m.TextureCoordinates.Count)
			{
				CustomVertex.PositionNormalTextured[] array = (CustomVertex.PositionNormalTextured[])(vertices = new CustomVertex.PositionNormalTextured[m.Vertices.Count]);
				result = VertexFormats.PositionNormal | VertexFormats.Texture1;
				computenormals = false;
				for (int i = 0; i < m.Vertices.Count; i++)
				{
					ref CustomVertex.PositionNormalTextured reference = ref array[i];
					reference = new CustomVertex.PositionNormalTextured(Converter.ToDx(m.Vertices[i]), Converter.ToDx(m.Normals[i]), (float)m.TextureCoordinates[i].X, (float)(0.0 - m.TextureCoordinates[i].Y));
				}
			}
			else if (m.Vertices.Count == m.Normals.Count && m.Vertices.Count == m.Colors.Count)
			{
				CustomVertex.PositionNormalColored[] array2 = (CustomVertex.PositionNormalColored[])(vertices = new CustomVertex.PositionNormalColored[m.Vertices.Count]);
				result = VertexFormats.PositionNormal | VertexFormats.Diffuse;
				computenormals = false;
				for (int j = 0; j < m.Vertices.Count; j++)
				{
					ref CustomVertex.PositionNormalColored reference2 = ref array2[j];
					reference2 = new CustomVertex.PositionNormalColored(Converter.ToDx(m.Vertices[j]), Converter.ToDx(m.Normals[j]), Helpers.ToColor(m.Colors[j]).ToArgb());
				}
			}
			else if (m.Vertices.Count == m.Normals.Count)
			{
				CustomVertex.PositionNormal[] array3 = (CustomVertex.PositionNormal[])(vertices = new CustomVertex.PositionNormal[m.Vertices.Count]);
				result = VertexFormats.PositionNormal;
				computenormals = false;
				for (int k = 0; k < m.Vertices.Count; k++)
				{
					ref CustomVertex.PositionNormal reference3 = ref array3[k];
					reference3 = new CustomVertex.PositionNormal(Converter.ToDx(m.Vertices[k]), Converter.ToDx(m.Normals[k]));
				}
			}
			else if (m.Vertices.Count == m.TextureCoordinates.Count)
			{
				CustomVertex.PositionNormalTextured[] array4 = (CustomVertex.PositionNormalTextured[])(vertices = new CustomVertex.PositionNormalTextured[m.Vertices.Count]);
				result = VertexFormats.PositionNormal | VertexFormats.Texture1;
				for (int l = 0; l < m.Vertices.Count; l++)
				{
					ref CustomVertex.PositionNormalTextured reference4 = ref array4[l];
					reference4 = new CustomVertex.PositionNormalTextured(Converter.ToDx(m.Vertices[l]), Converter.ToDx(Ambertation.Geometry.Vector3.Zero), (float)m.TextureCoordinates[l].X, (float)(0.0 - m.TextureCoordinates[l].Y));
				}
			}
			else if (m.Vertices.Count == m.Colors.Count)
			{
				CustomVertex.PositionColored[] array5 = (CustomVertex.PositionColored[])(vertices = new CustomVertex.PositionColored[m.Vertices.Count]);
				result = VertexFormats.Diffuse | VertexFormats.Position;
				computenormals = false;
				for (int n = 0; n < m.Vertices.Count; n++)
				{
					ref CustomVertex.PositionColored reference5 = ref array5[n];
					reference5 = new CustomVertex.PositionColored(Converter.ToDx(m.Vertices[n]), Helpers.ToColor(m.Colors[n]).ToArgb());
				}
			}
			else
			{
				CustomVertex.PositionNormal[] array6 = (CustomVertex.PositionNormal[])(vertices = new CustomVertex.PositionNormal[m.Vertices.Count]);
				result = VertexFormats.PositionNormal;
				for (int num = 0; num < m.Vertices.Count; num++)
				{
					ref CustomVertex.PositionNormal reference6 = ref array6[num];
					reference6 = new CustomVertex.PositionNormal(Converter.ToDx(m.Vertices[num]), Converter.ToDx(Ambertation.Geometry.Vector3.Zero));
				}
			}

			return result;
		}

		public void Dispose()
		{
			dev = null;
			dxp = null;
			if (colormap != null)
			{
				colormap.Clear();
			}

			colormap = null;
			scn = null;
		}
	}
}
