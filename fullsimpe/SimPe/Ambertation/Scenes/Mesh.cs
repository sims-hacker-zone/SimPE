// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Ambertation.Collections;
using Ambertation.Geometry;
using Ambertation.Geometry.Collections;
using Ambertation.Scenes.Collections;

namespace Ambertation.Scenes
{
	public class Mesh : Node
	{
		private Material m;

		private Vector4Collection c;

		private Vector3Collection v;

		private Vector3Collection n;

		private Vector3Collection bmn;

		private Vector2Collection t;

		private Vector3iCollection fcs;

		private EnvelopeCollection es;

		private Hashtable indexmap;

		public EnvelopeCollection Envelopes => es;

		public Material Material
		{
			get
			{
				return m;
			}
			set
			{
				if (value != null)
				{
					m = value;
				}
				else
				{
					m = base.Owner.DefaultMaterial;
				}
			}
		}

		public Vector3iCollection FaceIndices => fcs;

		public Vector3Collection Vertices => v;

		public Vector4Collection Colors => c;

		public Vector3Collection Normals => n;

		public Vector3Collection BumpMapNormalDelta => bmn;

		public Vector2Collection TextureCoordinates => t;

		public MeshCollection Childs => childs as MeshCollection;

		internal Mesh(Mesh parent, string name, Material m, Scene owner)
			: base(parent, name, owner)
		{
			this.m = m;
			childs = new MeshCollection();
			es = new EnvelopeCollection();
			v = new Vector3Collection();
			c = new Vector4Collection();
			n = new Vector3Collection();
			bmn = new Vector3Collection();
			t = new Vector2Collection();
			fcs = new Vector3iCollection();
			indexmap = new Hashtable();
		}

		public BoundingBox GetUntransformedBoundingBox()
		{
			return new BoundingBox(Vertices);
		}

		public BoundingBox GetTransformedBoundingBox()
		{
			Vector3Collection vector3Collection = new Vector3Collection();
			Ambertation.Geometry.Matrix matrix = ToMatrix();
			foreach (Vector3 vertex in Vertices)
			{
				vector3Collection.Add(matrix * vertex);
			}

			return new BoundingBox(vector3Collection);
		}

		public Envelope CreateEnvelope(Joint j)
		{
			Envelope envelope = new Envelope(j, this);
			es.Add(envelope);
			return envelope;
		}

		public Envelope GetJointEnvelope(Joint j)
		{
			return GetJointEnvelope(j, 0);
		}

		public Envelope GetJointEnvelope(Joint j, int count)
		{
			foreach (Envelope envelope3 in Envelopes)
			{
				if (envelope3.Joint == j)
				{
					return envelope3;
				}
			}

			Envelope envelope2 = CreateEnvelope(j);
			envelope2.ForceLength(count);
			return envelope2;
		}

		public void SyncEnvelopeLenghts(int mincount)
		{
			int num = 0;
			foreach (Envelope envelope3 in Envelopes)
			{
				if (envelope3.Weights.Count > num)
				{
					num = envelope3.Weights.Count;
				}
			}

			num = Math.Max(num, mincount);
			foreach (Envelope envelope4 in Envelopes)
			{
				envelope4.ForceLength(num);
			}
		}

		public override string ToString()
		{
			return base.Name + " [" + GetType().Name + "]";
		}

		internal void ClearTags()
		{
			base.Tag = null;
			foreach (Envelope envelope in Envelopes)
			{
				envelope.Tag = null;
			}
		}

		public bool BuildData(Vector3Collection vs, Vector3Collection ns, Vector2Collection ts, Vector4Collection cs, Vector3iCollection vf, Vector3iCollection nf, Vector3iCollection tf, Vector3iCollection cf)
		{
			indexmap.Clear();
			FaceIndices.Clear();
			Vertices.Clear();
			Normals.Clear();
			TextureCoordinates.Clear();
			Colors.Clear();
			try
			{
				for (int i = 0; i < vf.Count; i++)
				{
					Vector3i vector3i = new Vector3i(0, 0, 0);
					Vector3i importindex = vf[i];
					Vector2[] array = AddElement(vs, vf, i);
					Vector2[] array2 = AddElement(ns, nf, i);
					Vector2[] array3 = AddElement(ts, tf, i);
					Vector2[] array4 = AddElement(cs, cf, i);
					for (int j = 0; j < 3; j++)
					{
						int num;
						for (num = Vertices.ContainsAt(array[j] as Vector3); num > -1; num = Vertices.ContainsAt(array[j] as Vector3, num + 1))
						{
							bool flag = true;
							if (nf.Count > 0 && flag && !Normals[num].Equals(array2[j]))
							{
								flag = false;
							}

							if (tf.Count > 0 && flag && !TextureCoordinates[num].Equals(array3[j]))
							{
								flag = false;
							}

							if (cf.Count > 0 && flag && !Colors[num].Equals(array4[j]))
							{
								flag = false;
							}

							if (flag)
							{
								vector3i[j] = num;
								break;
							}
						}

						if (num == -1)
						{
							vector3i[j] = Vertices.Count;
							Vertices.Add(array[j]);
							if (nf.Count > 0)
							{
								Normals.Add(array2[j]);
							}

							if (tf.Count > 0)
							{
								TextureCoordinates.Add(array3[j]);
							}

							if (cf.Count > 0)
							{
								Colors.Add(array4[j]);
							}
						}
					}

					FaceIndices.Add(vector3i);
					AddToIndexMap(importindex, vector3i);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}

			return true;
		}

		public IntCollection MappedIndices(int index)
		{
			if (indexmap == null)
			{
				IntCollection intCollection = new IntCollection();
				intCollection.Add(index);
				return intCollection;
			}

			IntCollection intCollection2 = indexmap[index] as IntCollection;
			if (intCollection2 == null)
			{
				intCollection2 = new IntCollection();
				intCollection2.Add(index);
			}

			return intCollection2;
		}

		public void ClearIndexMap()
		{
			indexmap.Clear();
		}

		private void AddToIndexMap(Vector3i importindex, Vector3i currentindex)
		{
			for (int i = 0; i < 3; i++)
			{
				AddToIndexMap(importindex[i], currentindex[i]);
			}
		}

		private void AddToIndexMap(int iindex, int cindex)
		{
			object obj = indexmap[iindex];
			if (obj == null)
			{
				obj = new IntCollection();
				indexmap[iindex] = obj;
			}

			(obj as IntCollection).Add(cindex);
		}

		protected Vector2[] AddElement(IElementCollection src, Vector3iCollection list, int index)
		{
			if (list.Count == 0)
			{
				return new Vector2[0];
			}

			try
			{
				Vector3i vector3i = list[index];
				return new Vector2[3]
				{
				src.GetItem(vector3i.X) as Vector2,
				src.GetItem(vector3i.Y) as Vector2,
				src.GetItem(vector3i.Z) as Vector2
				};
			}
			catch
			{
				return new Vector2[0];
			}
		}

		public Mesh CreateMesh(string name)
		{
			return Childs.CreateMesh(this, owner, name);
		}

		public Mesh CreateMesh(string name, Material mat)
		{
			return Childs.CreateMesh(this, owner, name, mat);
		}

		public Mesh FindMesh(string name)
		{
			foreach (Mesh child in childs)
			{
				if (child.Name == name)
				{
					return child;
				}

				Mesh mesh2 = child.FindMesh(name);
				if (mesh2 != null)
				{
					return mesh2;
				}
			}

			return null;
		}

		public Image CreateNormalMap()
		{
			if (Material.Texture.Available)
			{
				return CreateNormalMap(Material.Texture.Size, tangentspace: true);
			}

			return CreateNormalMap(new Size(512, 512), tangentspace: true);
		}

		private int Clamp(double d, int max)
		{
			if (d < 0.0)
			{
				return 0;
			}

			if (d > (double)max)
			{
				return max;
			}

			return (int)d;
		}

		private void PrepareTangentSpace(Vector3Collection tan1, Vector3Collection tan2)
		{
			while (tan1.Count < v.Count)
			{
				tan1.Add(Vector3.Zero);
				tan2.Add(Vector3.Zero);
			}

			foreach (Vector3i faceIndex in FaceIndices)
			{
				Vector3 vector = v[faceIndex.X];
				Vector3 vector2 = v[faceIndex.Y];
				Vector3 vector3 = v[faceIndex.Z];
				Vector2 vector4 = t[faceIndex.X];
				Vector2 vector5 = t[faceIndex.Y];
				Vector2 vector6 = t[faceIndex.Z];
				Vector3 vector7 = vector - vector2;
				Vector3 vector8 = vector3 - vector;
				double num = vector4.Y - vector5.Y;
				double num2 = vector6.Y - vector4.Y;
				Vector3 vector9 = vector7 * num2 - vector8 * num;
				vector9 = vector9.UnitVector;
				double num3 = vector4.X - vector5.X;
				double num4 = vector6.X - vector4.X;
				Vector3 vector10 = vector7 * num4 - vector7 * num3;
				vector10 = vector9.UnitVector;
				tan1[faceIndex.X] = vector9;
				tan2[faceIndex.X] = vector10;
				tan1[faceIndex.Y] = vector9;
				tan2[faceIndex.Y] = vector10;
				tan1[faceIndex.Z] = vector9;
				tan2[faceIndex.Z] = vector10;
			}
		}

		public Image CreateNormalMap(Size sz, bool tangentspace)
		{
			if (t.Count == 0 || bmn.Count == 0)
			{
				return null;
			}

			Bitmap bitmap = new Bitmap(sz.Width, sz.Height, PixelFormat.Format32bppArgb);
			System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.None;
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(127, 127, 255)), 0, 0, bitmap.Width - 1, bitmap.Height - 1);
			Color[] array = new Color[3];
			Point[] array2 = new Point[3];
			Vector3Collection vector3Collection = new Vector3Collection();
			Vector3Collection vector3Collection2 = new Vector3Collection();
			if (tangentspace)
			{
				PrepareTangentSpace(vector3Collection, vector3Collection2);
			}

			foreach (Vector3i faceIndex in FaceIndices)
			{
				for (int i = 0; i < 3; i++)
				{
					int index = faceIndex[i];
					Vector3 vector = bmn[index];
					if (Normals.Count >= 0 && tangentspace)
					{
						Vector3 vector2 = n[index];
						Vector3 unitVector = (vector2 + vector).UnitVector;
						Vector3 vector3 = vector3Collection[index];
						Vector3 vector4 = vector3Collection2[index];
						Ambertation.Geometry.Matrix matrix = new Ambertation.Geometry.Matrix();
						matrix.MakeIdentity();
						Vector3.SetMatrixRow(matrix, 0, vector3.UnitVector);
						Vector3.SetMatrixRow(matrix, 1, vector4.UnitVector);
						Vector3.SetMatrixRow(matrix, 2, unitVector.UnitVector);
						vector = matrix * unitVector;
					}

					ref Color reference = ref array[i];
					reference = Color.FromArgb(Clamp((vector.X + 1.0) * 0.5 * 255.0, 255), Clamp((vector.Y + 1.0) * 0.5 * 255.0, 255), Clamp((vector.Z + 1.0) * 0.5 * 255.0, 255));
					int x = Clamp(t[index].X * (double)bitmap.Width, bitmap.Width);
					int y = bitmap.Height - Clamp(t[index].Y * (double)bitmap.Height, bitmap.Height);
					ref Point reference2 = ref array2[i];
					reference2 = new Point(x, y);
				}

				Interpolate(graphics, array, array2);
			}

			vector3Collection.Dispose();
			vector3Collection2.Dispose();
			graphics.Dispose();
			return bitmap;
		}

		protected static void Interpolate(System.Drawing.Graphics g, Color[] cl, Point[] pos)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLines(pos);
			graphicsPath.CloseFigure();
			PathGradientBrush pathGradientBrush = new PathGradientBrush(pos);
			pathGradientBrush.SurroundColors = cl;
			pathGradientBrush.CenterPoint = pos[0];
			pathGradientBrush.CenterColor = cl[0];
			g.DrawPath(new Pen(pathGradientBrush, 2f), graphicsPath);
			g.FillPath(pathGradientBrush, graphicsPath);
		}

		public override void Dispose()
		{
			base.Dispose();
			m = null;
			if (v != null)
			{
				v.Clear();
			}

			if (n != null)
			{
				n.Clear();
			}

			if (bmn != null)
			{
				bmn.Clear();
			}

			if (t != null)
			{
				t.Clear();
			}

			if (c != null)
			{
				c.Clear();
			}

			v = null;
			n = null;
			t = null;
			c = null;
			if (indexmap != null)
			{
				indexmap.Clear();
			}

			indexmap = null;
			if (fcs != null)
			{
				fcs.Clear();
			}

			fcs = null;
			if (es != null)
			{
				for (int i = 0; i < es.Count; i++)
				{
					es[i].Dispose();
				}

				es.Clear();
			}

			es = null;
		}
	}
}
