// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

using FillMode = Microsoft.DirectX.Direct3D.FillMode;
using Matrix = Microsoft.DirectX.Matrix;

namespace Ambertation.Graphics
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class ViewportSetting : ViewportSettingBasic
	{
		protected DirectXPanel parent;

		protected float angx;

		protected float angy;

		protected float angz;

		protected float rad;

		protected float camoffset;

		protected Vector3 campos;

		protected Vector3 camtarget;

		protected Vector3 pos;

		protected Vector3 center;

		protected float fov;

		protected float aspect;

		protected float near;

		protected float far;

		protected Matrix rotbase;

		protected bool alphablend;

		protected bool paused;

		protected bool useleft;

		protected bool useeff;

		protected bool autolightmesh;

		protected Cull acull;

		protected Cull mcull;

		protected float ascale;

		protected float lscale;

		protected Color amb;

		protected Color lcol;

		protected Color lscol;

		protected Color bg;

		private string flname;

		[Category("Settings")]
		public Color BackgroundColor
		{
			get
			{
				return bg;
			}
			set
			{
				if (bg != value)
				{
					bg = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Settings")]
		public Color AmbientColor
		{
			get
			{
				return amb;
			}
			set
			{
				if (amb != value)
				{
					amb = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Light")]
		public Color LightColorDiffuse
		{
			get
			{
				return lcol;
			}
			set
			{
				if (lcol != value)
				{
					lcol = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Light")]
		public Color LightColorSpecular
		{
			get
			{
				return lscol;
			}
			set
			{
				if (lscol != value)
				{
					lscol = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Settings")]
		public bool AddLightIndicators
		{
			get
			{
				return autolightmesh;
			}
			set
			{
				if (autolightmesh != value)
				{
					autolightmesh = value;
					FireStateChangeEvent();
				}
			}
		}

		[ReadOnly(true)]
		[Category("Settings")]
		public float AxisScale
		{
			get
			{
				return ascale;
			}
			set
			{
				if (ascale != value)
				{
					ascale = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Settings")]
		[ReadOnly(true)]
		public float LineWidth
		{
			get
			{
				return lscale;
			}
			set
			{
				if (lscale != value)
				{
					lscale = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Culling")]
		public Cull MeshPassCullMode
		{
			get
			{
				return mcull;
			}
			set
			{
				if (mcull != value)
				{
					mcull = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Culling")]
		public Cull AlphaPassCullMode
		{
			get
			{
				return acull;
			}
			set
			{
				if (acull != value)
				{
					acull = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Render state")]
		public bool Paused
		{
			get
			{
				return paused;
			}
			set
			{
				if (paused != value)
				{
					paused = value;
				}
			}
		}

		[Category("Render state")]
		public bool EnableShaderEffectPass
		{
			get
			{
				return useeff;
			}
			set
			{
				if (useeff != value)
				{
					useeff = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Render state")]
		public bool UseLefthandedCoordinates
		{
			get
			{
				return useleft;
			}
			set
			{
				if (useleft != value)
				{
					useleft = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Render state")]
		public bool EnableAlphaBlendPass
		{
			get
			{
				return alphablend;
			}
			set
			{
				if (alphablend != value)
				{
					alphablend = value;
					FireStateChangeEvent();
				}
			}
		}

		internal Matrix AngelRotation => Matrix.Multiply(Matrix.RotationY(AngelY), Matrix.Multiply(Matrix.RotationX(AngelX), Matrix.RotationZ(AngelZ)));

		internal Matrix Rotation
		{
			get
			{
				return rotbase;
			}
			set
			{
				rotbase = value;
				FireAttributeChangeEvent();
			}
		}

		[Category("Camera")]
		public float InitialCameraOffsetScale
		{
			get
			{
				return camoffset;
			}
			set
			{
				if (value == camoffset)
				{
					camoffset = value;
					FireStateChangeEvent();
				}
			}
		}

		[Category("Camera")]
		public bool SetDefaultCamera
		{
			get
			{
				return false;
			}
			set
			{
				if (value)
				{
					parent.ResetDefaultViewport();
					NearPlane = BoundingSphereRadius / 10f;
					FarPlane = NearPlane * 10000f;
				}
			}
		}

		[Category("Camera")]
		public float BoundingSphereRadius
		{
			get
			{
				return Math.Max(0.01f, rad);
			}
			set
			{
				rad = value;
				lscale = rad * 0.002f;
				near = rad / 10f;
				far = near * 10000f;
				FireAttributeChangeEvent();
			}
		}

		[Category("Camera")]
		public float FarPlane
		{
			get
			{
				return far;
			}
			set
			{
				far = value;
				FireAttributeChangeEvent();
			}
		}

		[Category("Camera")]
		public float NearPlane
		{
			get
			{
				return near;
			}
			set
			{
				near = value;
				FireAttributeChangeEvent();
			}
		}

		[Browsable(false)]
		[Category("Camera")]
		public Vector3 CameraPosition
		{
			get
			{
				return campos;
			}
			set
			{
				campos = value;
				FireAttributeChangeEvent();
			}
		}

		[Browsable(false)]
		[Category("Camera")]
		public Vector3 RealCameraPosition => new Vector3(X, Y, Z) + CameraPosition;

		[Browsable(false)]
		[Category("Camera")]
		public Vector3 CameraTarget
		{
			get
			{
				return camtarget;
			}
			set
			{
				camtarget = value;
				FireAttributeChangeEvent();
			}
		}

		[Category("Camera")]
		[Browsable(false)]
		public Vector3 ObjectCenter
		{
			get
			{
				return center;
			}
			set
			{
				center = value;
				FireAttributeChangeEvent();
			}
		}

		[Category("Camera")]
		[ReadOnly(true)]
		public float Aspect
		{
			get
			{
				return aspect;
			}
			set
			{
				aspect = value;
				FireAttributeChangeEvent();
			}
		}

		[Category("Camera")]
		public float FoV
		{
			get
			{
				return fov;
			}
			set
			{
				fov = value;
				FireAttributeChangeEvent();
			}
		}

		[Category("Viewpoint")]
		public float AngelX
		{
			get
			{
				return angx;
			}
			set
			{
				angx = value;
				FireAttributeChangeEvent();
			}
		}

		[Category("Viewpoint")]
		public float AngelZ
		{
			get
			{
				return angz;
			}
			set
			{
				angz = value;
				FireAttributeChangeEvent();
			}
		}

		[Category("Viewpoint")]
		public float AngelY
		{
			get
			{
				return angy;
			}
			set
			{
				angy = value;
				FireAttributeChangeEvent();
			}
		}

		[Category("Viewpoint")]
		public float X
		{
			get
			{
				return pos.X;
			}
			set
			{
				pos.X = value;
				FireAttributeChangeEvent();
			}
		}

		[Category("Viewpoint")]
		public float Y
		{
			get
			{
				return pos.Y;
			}
			set
			{
				pos.Y = value;
				FireAttributeChangeEvent();
			}
		}

		[Category("Viewpoint")]
		public float Z
		{
			get
			{
				return pos.Z;
			}
			set
			{
				pos.Z = value;
				FireAttributeChangeEvent();
			}
		}

		[Browsable(false)]
		public float InputTranslationScale => 0.5f;

		[Browsable(false)]
		public float InputRotationScale => 100f;

		[Browsable(false)]
		public float InputScaleScale => 100f;

		internal ViewportSetting(DirectXPanel parent)
			: base(parent)
		{
			flname = null;
			this.parent = parent;
			Reset();
			autolightmesh = false;
			useleft = false;
			useeff = false;
			alphablend = true;
			paused = false;
			acull = Cull.None;
			mcull = Cull.Clockwise;
			ascale = 250f;
			lscale = 0.1f;
			amb = Color.FromArgb(128, 128, 128);
			bg = SystemColors.AppWorkspace;
			lcol = (lscol = Color.White);
			camoffset = 1.2f;
		}

		~ViewportSetting()
		{
			try
			{
				Save();
			}
			catch
			{
			}
		}

		private void Serialize(string flname)
		{
			Stream stream = File.Create(flname);
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(stream);
				binaryWriter.Write(4);
				binaryWriter.Write(base.EnableTextures);
				binaryWriter.Write((int)base.FillMode);
				binaryWriter.Write(base.RenderJoints);
				binaryWriter.Write(base.EnableSpecularHighlights);
				binaryWriter.Write(base.EnableLights);
				binaryWriter.Write((int)base.ShadeMode);
				binaryWriter.Write(base.AddAxis);
				binaryWriter.Write(base.JointScale);
				binaryWriter.Write(InitialCameraOffsetScale);
				binaryWriter.Write(base.RenderBoundingBoxes);
				binaryWriter.Write(bg.ToArgb());
			}
			finally
			{
				stream.Close();
			}
		}

		private void DeSerialize(string flname)
		{
			Stream stream = File.OpenRead(flname);
			try
			{
				BeginUpdate();
				BinaryReader binaryReader = new BinaryReader(stream);
				int num = binaryReader.ReadInt32();
				base.EnableTextures = binaryReader.ReadBoolean();
				base.FillMode = (FillModes)binaryReader.ReadInt32();
				base.RenderJoints = binaryReader.ReadBoolean();
				base.EnableSpecularHighlights = binaryReader.ReadBoolean();
				base.EnableLights = binaryReader.ReadBoolean();
				base.ShadeMode = (ShadeMode)binaryReader.ReadInt32();
				base.AddAxis = binaryReader.ReadBoolean();
				base.JointScale = binaryReader.ReadSingle();
				if (num >= 2)
				{
					InitialCameraOffsetScale = binaryReader.ReadSingle();
				}

				if (num >= 3)
				{
					base.RenderBoundingBoxes = binaryReader.ReadBoolean();
				}

				if (num >= 4)
				{
					BackgroundColor = Color.FromArgb(binaryReader.ReadInt32());
				}

				EndUpdate();
			}
			finally
			{
				stream.Close();
			}
		}

		public void Save()
		{
			if (flname == null)
			{
				return;
			}

			try
			{
				Serialize(flname);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void Load(string flname)
		{
			if (flname == null)
			{
				return;
			}

			this.flname = flname;
			try
			{
				DeSerialize(flname);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		internal FillMode GetFillMode(MeshBox box)
		{
			return GetFillMode(box, 0);
		}

		internal FillMode GetFillMode(MeshBox box, int pass)
		{
			if (fm == FillModes.Default || box.SpecialMesh)
			{
				if (box.Wire)
				{
					return Microsoft.DirectX.Direct3D.FillMode.WireFrame;
				}

				return Microsoft.DirectX.Direct3D.FillMode.Solid;
			}

			if (fm == FillModes.WireframeOverlay)
			{
				if (pass == 1)
				{
					return Microsoft.DirectX.Direct3D.FillMode.Solid;
				}

				return Microsoft.DirectX.Direct3D.FillMode.WireFrame;
			}

			if (fm == FillModes.Point)
			{
				return Microsoft.DirectX.Direct3D.FillMode.Point;
			}

			if (fm == FillModes.Wireframe)
			{
				return Microsoft.DirectX.Direct3D.FillMode.WireFrame;
			}

			return Microsoft.DirectX.Direct3D.FillMode.Solid;
		}

		public void ResetAngle()
		{
			angx = (angy = (angz = 0f));
		}

		public void Reset()
		{
			ResetAngle();
			pos = new Vector3(0f, 0f, 0f);
			center = new Vector3(0f, 0f, 0f);
			fov = (float)Math.PI / 4f;
			near = 1f;
			far = 100f;
			rad = 0.01f;
			campos = new Vector3(0f, 3f, 5f);
			camtarget = new Vector3(0f, 0f, 0f);
			rotbase = Matrix.Identity;
			FireAttributeChangeEvent();
		}
	}
}
