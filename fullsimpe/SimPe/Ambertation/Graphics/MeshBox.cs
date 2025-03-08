// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Ambertation.Geometry;
using Ambertation.Scenes;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

using static System.Resources.ResXFileRef;

using Converter = Ambertation.Scenes.Converter;

namespace Ambertation.Graphics
{
	public class MeshBox : MeshList, IDisposable
	{
		public enum Cull
		{
			Default,
			None,
			Clockwise,
			CounterClockwise
		}

		private MeshBox parent;

		private Microsoft.DirectX.Direct3D.Mesh mesh;

		private Microsoft.DirectX.Direct3D.Material mat;

		private Microsoft.DirectX.Matrix trans;

		private int ssc;

		private bool wire;

		private bool opaque;

		private bool billboard;

		private bool sort;

		private bool ztest;

		private Cull cull;

		private Stream txtrstream;

		private bool ignoreforcam;

		private bool isjointmesh;

		private Ambertation.Scenes.Material.TextureModes blend;

		private Microsoft.DirectX.Direct3D.Texture txtr;

		private Device txtrdev;

		private MeshBox txtrmb;

		private Microsoft.DirectX.Matrix wrld;

		private double dist;

		public bool SpecialMesh
		{
			get
			{
				if (!JointMesh)
				{
					return IgnoreDuringCameraReset;
				}

				return true;
			}
		}

		public bool JointMesh
		{
			get
			{
				return isjointmesh;
			}
			set
			{
				isjointmesh = value;
			}
		}

		public bool Billboard
		{
			get
			{
				return billboard;
			}
			set
			{
				billboard = value;
			}
		}

		public bool Sort
		{
			get
			{
				return sort;
			}
			set
			{
				sort = value;
			}
		}

		public bool ZTest
		{
			get
			{
				return ztest;
			}
			set
			{
				ztest = value;
			}
		}

		public MeshBox Parent => parent;

		public Ambertation.Scenes.Material.TextureModes TextureMode
		{
			get
			{
				return blend;
			}
			set
			{
				blend = value;
			}
		}

		public bool IgnoreDuringCameraReset
		{
			get
			{
				return ignoreforcam;
			}
			set
			{
				ignoreforcam = value;
			}
		}

		public Stream TextureStream => txtrstream;

		public Microsoft.DirectX.Direct3D.Texture Texture
		{
			get
			{
				if (txtrmb != null)
				{
					return txtrmb.Texture;
				}

				return txtr;
			}
		}

		public Cull CullMode
		{
			get
			{
				return cull;
			}
			set
			{
				cull = value;
			}
		}

		public bool Opaque
		{
			get
			{
				if (TextureMode == Ambertation.Scenes.Material.TextureModes.MaterialWithAlpha)
				{
					return false;
				}

				if (mat.Diffuse.A != byte.MaxValue)
				{
					return mat.Diffuse.A == 0;
				}

				return true;
			}
			set
			{
				opaque = value;
			}
		}

		public bool Wire
		{
			get
			{
				return wire;
			}
			set
			{
				wire = value;
			}
		}

		public Microsoft.DirectX.Direct3D.Mesh Mesh => mesh;

		public Microsoft.DirectX.Direct3D.Material Material
		{
			get
			{
				return mat;
			}
			set
			{
				mat = value;
			}
		}

		public Microsoft.DirectX.Matrix Transform
		{
			get
			{
				return trans;
			}
			set
			{
				trans = value;
			}
		}

		public int SubSetCount => ssc;

		internal Microsoft.DirectX.Matrix World => wrld;

		internal double Distance => dist;

		public MeshBox(Microsoft.DirectX.Direct3D.Mesh mesh, int subsetcount)
			: this(mesh, subsetcount, new Microsoft.DirectX.Direct3D.Material(), Microsoft.DirectX.Matrix.Identity)
		{
		}

		public MeshBox(Microsoft.DirectX.Direct3D.Mesh mesh)
			: this(mesh, new Microsoft.DirectX.Direct3D.Material(), Microsoft.DirectX.Matrix.Identity)
		{
		}

		public MeshBox(Microsoft.DirectX.Direct3D.Mesh mesh, Microsoft.DirectX.Direct3D.Material mat)
			: this(mesh, mat, Microsoft.DirectX.Matrix.Identity)
		{
		}

		public MeshBox(Microsoft.DirectX.Direct3D.Mesh mesh, int subsetcount, Microsoft.DirectX.Direct3D.Material mat)
			: this(mesh, subsetcount, mat, Microsoft.DirectX.Matrix.Identity)
		{
		}

		public MeshBox(Microsoft.DirectX.Direct3D.Mesh mesh, Microsoft.DirectX.Direct3D.Material mat, Microsoft.DirectX.Matrix transform)
			: this(mesh, mesh.NumberAttributes, mat, transform)
		{
		}

		public MeshBox(Microsoft.DirectX.Direct3D.Mesh mesh, int subsetcount, Microsoft.DirectX.Direct3D.Material mat, Microsoft.DirectX.Matrix transform)
			: this(mesh, subsetcount, mat, transform, wire: true, opaque: true)
		{
		}

		public MeshBox(Microsoft.DirectX.Direct3D.Mesh mesh, int subsetcount, Microsoft.DirectX.Direct3D.Material mat, Microsoft.DirectX.Matrix transform, bool wire, bool opaque)
		{
			billboard = false;
			sort = false;
			ztest = true;
			this.mesh = mesh;
			this.mat = mat;
			trans = transform;
			ssc = subsetcount;
			this.wire = wire;
			this.opaque = opaque;
			cull = Cull.Default;
			txtrstream = null;
			ignoreforcam = false;
			parent = null;
			isjointmesh = false;
			blend = Ambertation.Scenes.Material.TextureModes.Default;
		}

		protected void SetParent(MeshBox parent)
		{
			this.parent = parent;
		}

		public void PrepareTexture(Device dev)
		{
			if (txtrmb != null)
			{
				txtrmb.PrepareTexture(dev);
			}
			else if (!(txtr != null) || txtr.Disposed || !(dev == txtrdev))
			{
				txtrdev = dev;
				if (txtr != null)
				{
					txtr.Dispose();
				}

				txtr = null;
				if (TextureStream != null && TextureStream.CanSeek && TextureStream.CanRead)
				{
					TextureStream.Seek(0L, SeekOrigin.Begin);
					txtr = TextureLoader.FromStream(dev, TextureStream);
				}
			}
		}

		public void SetTexture(Image img)
		{
			if (txtrstream != null)
			{
				txtrstream.Close();
			}

			txtrdev = null;
			txtrmb = null;
			if (img != null)
			{
				txtrstream = new MemoryStream();
				img.Save(txtrstream, ImageFormat.Bmp);
				txtrstream.Seek(0L, SeekOrigin.Begin);
			}
			else
			{
				txtrstream = null;
			}
		}

		public void SetTexture(MeshBox txtrmb)
		{
			if (txtrstream != null)
			{
				txtrstream.Close();
			}

			txtrstream = null;
			txtrdev = null;
			this.txtrmb = txtrmb;
		}

		internal Microsoft.DirectX.Direct3D.Cull GetCullMode(Microsoft.DirectX.Direct3D.Cull def)
		{
			if (cull == Cull.Default)
			{
				return def;
			}

			if (cull == Cull.None)
			{
				return Microsoft.DirectX.Direct3D.Cull.None;
			}

			if (cull == Cull.Clockwise)
			{
				return Microsoft.DirectX.Direct3D.Cull.Clockwise;
			}

			if (cull == Cull.CounterClockwise)
			{
				return Microsoft.DirectX.Direct3D.Cull.CounterClockwise;
			}

			return def;
		}

		internal Microsoft.DirectX.Vector3[] GetBoundingBoxVectors()
		{
			Microsoft.DirectX.Vector3[] array = new Microsoft.DirectX.Vector3[2]
			{
			new Microsoft.DirectX.Vector3(float.MaxValue, float.MaxValue, float.MaxValue),
			new Microsoft.DirectX.Vector3(float.MinValue, float.MinValue, float.MinValue)
			};
			if (mesh != null)
			{
				int[] ranks = new int[1] { mesh.NumberVertices };
				CustomVertex.PositionNormal[] array2 = (CustomVertex.PositionNormal[])mesh.LockVertexBuffer(typeof(CustomVertex.PositionNormal), LockFlags.None, ranks);
				try
				{
					CustomVertex.PositionNormal[] array3 = array2;
					for (int i = 0; i < array3.Length; i++)
					{
						CustomVertex.PositionNormal positionNormal = array3[i];
						if (positionNormal.X < array[0].X)
						{
							array[0].X = positionNormal.X;
						}

						if (positionNormal.Y < array[0].Y)
						{
							array[0].Y = positionNormal.Y;
						}

						if (positionNormal.Z < array[0].Z)
						{
							array[0].Z = positionNormal.Z;
						}

						if (positionNormal.X > array[1].X)
						{
							array[1].X = positionNormal.X;
						}

						if (positionNormal.Y > array[1].Y)
						{
							array[1].Y = positionNormal.Y;
						}

						if (positionNormal.Z > array[1].Z)
						{
							array[1].Z = positionNormal.Z;
						}
					}
				}
				finally
				{
					mesh.UnlockVertexBuffer();
				}
			}

			return array;
		}

		protected override void OnAdd(MeshBox m)
		{
			base.OnAdd(m);
			m?.SetParent(this);
		}

		protected override void OnRemove(MeshBox m)
		{
			base.OnRemove(m);
			m?.SetParent(null);
		}

		public override void Dispose()
		{
			base.Dispose();
			txtrmb = null;
			txtrdev = null;
			parent = null;
			try
			{
				if (mesh != null)
				{
					mesh.Dispose();
				}
			}
			catch
			{
			}

			try
			{
				if (txtrstream != null && txtrstream.CanRead)
				{
					txtrstream.Close();
				}
			}
			catch
			{
			}

			if (txtr != null)
			{
				txtr.Dispose();
			}

			txtr = null;
			txtrstream = null;
			mesh = null;
		}

		public static BoundingBox BoundingBoxFromMesh(Microsoft.DirectX.Direct3D.Mesh mesh, Ambertation.Geometry.Matrix m)
		{
			Ambertation.Geometry.Vector3 vector = new Ambertation.Geometry.Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
			Ambertation.Geometry.Vector3 vector2 = new Ambertation.Geometry.Vector3(double.MinValue, double.MinValue, double.MinValue);
			if (mesh != null)
			{
				int[] ranks = new int[1] { mesh.NumberVertices };
				if (mesh.VertexBuffer.Description.VertexFormat == (VertexFormats.PositionNormal | VertexFormats.Texture1))
				{
					CustomVertex.PositionNormalTextured[] array = (CustomVertex.PositionNormalTextured[])mesh.LockVertexBuffer(typeof(CustomVertex.PositionNormalTextured), LockFlags.None, ranks);
					try
					{
						CustomVertex.PositionNormalTextured[] array2 = array;
						for (int i = 0; i < array2.Length; i++)
						{
							CustomVertex.PositionNormalTextured positionNormalTextured = array2[i];
							Ambertation.Geometry.Vector3 vector3 = new Ambertation.Geometry.Vector3(positionNormalTextured.X, positionNormalTextured.Y, positionNormalTextured.Z);
							if (m != null)
							{
								vector3 = m * vector3;
							}

							if (vector3.X < vector.X)
							{
								vector.X = vector3.X;
							}

							if (vector3.Y < vector.Y)
							{
								vector.Y = vector3.Y;
							}

							if (vector3.Z < vector.Z)
							{
								vector.Z = vector3.Z;
							}

							if (vector3.X > vector2.X)
							{
								vector2.X = vector3.X;
							}

							if (vector3.Y > vector2.Y)
							{
								vector2.Y = vector3.Y;
							}

							if (vector3.Z > vector2.Z)
							{
								vector2.Z = vector3.Z;
							}
						}
					}
					finally
					{
						mesh.UnlockVertexBuffer();
					}
				}
				else if (mesh.VertexBuffer.Description.VertexFormat == VertexFormats.PositionNormal)
				{
					CustomVertex.PositionNormal[] array3 = (CustomVertex.PositionNormal[])mesh.LockVertexBuffer(typeof(CustomVertex.PositionNormal), LockFlags.None, ranks);
					try
					{
						CustomVertex.PositionNormal[] array4 = array3;
						for (int j = 0; j < array4.Length; j++)
						{
							CustomVertex.PositionNormal positionNormal = array4[j];
							Ambertation.Geometry.Vector3 vector4 = new Ambertation.Geometry.Vector3(positionNormal.X, positionNormal.Y, positionNormal.Z);
							if (m != null)
							{
								vector4 = m * vector4;
							}

							if (vector4.X < vector.X)
							{
								vector.X = vector4.X;
							}

							if (vector4.Y < vector.Y)
							{
								vector.Y = vector4.Y;
							}

							if (vector4.Z < vector.Z)
							{
								vector.Z = vector4.Z;
							}

							if (vector4.X > vector2.X)
							{
								vector2.X = vector4.X;
							}

							if (vector4.Y > vector2.Y)
							{
								vector2.Y = vector4.Y;
							}

							if (vector4.Z > vector2.Z)
							{
								vector2.Z = vector4.Z;
							}
						}
					}
					finally
					{
						mesh.UnlockVertexBuffer();
					}
				}
				else if (mesh.VertexBuffer.Description.VertexFormat == (VertexFormats.PositionNormal | VertexFormats.Diffuse))
				{
					CustomVertex.PositionNormalColored[] array5 = (CustomVertex.PositionNormalColored[])mesh.LockVertexBuffer(typeof(CustomVertex.PositionNormalColored), LockFlags.None, ranks);
					try
					{
						CustomVertex.PositionNormalColored[] array6 = array5;
						for (int k = 0; k < array6.Length; k++)
						{
							CustomVertex.PositionNormalColored positionNormalColored = array6[k];
							Ambertation.Geometry.Vector3 vector5 = new Ambertation.Geometry.Vector3(positionNormalColored.X, positionNormalColored.Y, positionNormalColored.Z);
							if (m != null)
							{
								vector5 = m * vector5;
							}

							if (vector5.X < vector.X)
							{
								vector.X = vector5.X;
							}

							if (vector5.Y < vector.Y)
							{
								vector.Y = vector5.Y;
							}

							if (vector5.Z < vector.Z)
							{
								vector.Z = vector5.Z;
							}

							if (vector5.X > vector2.X)
							{
								vector2.X = vector5.X;
							}

							if (vector5.Y > vector2.Y)
							{
								vector2.Y = vector5.Y;
							}

							if (vector5.Z > vector2.Z)
							{
								vector2.Z = vector5.Z;
							}
						}
					}
					finally
					{
						mesh.UnlockVertexBuffer();
					}
				}
				else if (mesh.VertexBuffer.Description.VertexFormat == (VertexFormats.Diffuse | VertexFormats.Position))
				{
					CustomVertex.PositionColored[] array7 = (CustomVertex.PositionColored[])mesh.LockVertexBuffer(typeof(CustomVertex.PositionColored), LockFlags.None, ranks);
					try
					{
						CustomVertex.PositionColored[] array8 = array7;
						for (int l = 0; l < array8.Length; l++)
						{
							CustomVertex.PositionColored positionColored = array8[l];
							Ambertation.Geometry.Vector3 vector6 = new Ambertation.Geometry.Vector3(positionColored.X, positionColored.Y, positionColored.Z);
							if (m != null)
							{
								vector6 = m * vector6;
							}

							if (vector6.X < vector.X)
							{
								vector.X = vector6.X;
							}

							if (vector6.Y < vector.Y)
							{
								vector.Y = vector6.Y;
							}

							if (vector6.Z < vector.Z)
							{
								vector.Z = vector6.Z;
							}

							if (vector6.X > vector2.X)
							{
								vector2.X = vector6.X;
							}

							if (vector6.Y > vector2.Y)
							{
								vector2.Y = vector6.Y;
							}

							if (vector6.Z > vector2.Z)
							{
								vector2.Z = vector6.Z;
							}
						}
					}
					finally
					{
						mesh.UnlockVertexBuffer();
					}
				}
			}

			if (vector.X > vector2.X)
			{
				vector.X = 0.0;
				vector2.X = 0.0;
			}

			if (vector.Y > vector2.Y)
			{
				vector.Y = 0.0;
				vector2.Y = 0.0;
			}

			if (vector.Z > vector2.Z)
			{
				vector.Z = 0.0;
				vector2.Z = 0.0;
			}

			return new BoundingBox(vector, vector2);
		}

		public BoundingBox GetBoundingBox(bool rec, bool all)
		{
			return GetBoundingBox(Converter.FromDx(trans), rec, all);
		}

		public BoundingBox GetBoundingBox(Ambertation.Geometry.Matrix basem, bool rec, bool all)
		{
			if (mesh == null)
			{
				return new BoundingBox(Ambertation.Geometry.Vector3.Zero, new Ambertation.Geometry.Vector3(0.0001, 0.0001, 0.0001));
			}

			if (mesh.Disposed)
			{
				return new BoundingBox(Ambertation.Geometry.Vector3.Zero, new Ambertation.Geometry.Vector3(0.0001, 0.0001, 0.0001));
			}

			BoundingBox result = BoundingBoxFromMesh(mesh, basem);
			foreach (MeshBox item in (IEnumerable)this)
			{
				if (all || !item.SpecialMesh)
				{
					result += item.GetBoundingBox(basem, rec: true, all);
				}
			}

			return result;
		}

		internal void SetupSortWorld(Microsoft.DirectX.Matrix world, Microsoft.DirectX.Vector3 campos)
		{
			wrld = world;
			dist = GetDistance(campos);
		}

		internal Microsoft.DirectX.Vector3 GetCenterOfMass()
		{
			BoundingBox boundingBox = GetBoundingBox(Converter.FromDx(wrld), rec: false, all: true);
			Ambertation.Geometry.Vector3 v = (boundingBox.Min + boundingBox.Max) / 2.0;
			return Converter.ToDx(v);
		}

		internal double GetDistance(Microsoft.DirectX.Vector3 v)
		{
			Microsoft.DirectX.Vector3 centerOfMass = GetCenterOfMass();
			v -= centerOfMass;
			return v.Length();
		}
	}
}
