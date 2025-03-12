// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Ambertation.Scenes;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

using Scene = Ambertation.Scenes.Scene;

namespace Ambertation.Graphics
{
	public class DirectXPanel : UserControl, IDisposable
	{
		private Device device;

		private PresentParameters presentParams = new PresentParameters();

		private ViewportSetting vp;

		private Effect effect;

		private MeshList meshes;

		private bool ignorechangeevent;

		private MeshList sortedlist;

		private Vector3 lastcampos;

		private Matrix world = Matrix.Identity;

		private MatrixStack mstack;

		private MouseEventArgs last;

		private ViewPortSetup vpsf;

		public MeshList Meshes => meshes;

		public Device Device
		{
			get
			{
				if (device == null)
				{
					InitializeGraphics(force: true);
				}

				return device;
			}
		}

		public Effect Effect
		{
			get
			{
				return effect;
			}
			set
			{
				effect = value;
			}
		}

		public ViewportSetting Settings => vp;

		public override Color BackColor
		{
			get
			{
				return vp.BackgroundColor;
			}
			set
			{
				vp.BackgroundColor = value;
			}
		}

		public virtual Matrix ProjectionMatrix
		{
			get
			{
				float num = vp.FarPlane / vp.NearPlane;
				float num2 = Math.Max(vp.BoundingSphereRadius / 30f, vp.NearPlane + vp.Z);
				Math.Max(num2 * num, num2 * 1000f);
				num2 = vp.NearPlane + vp.Z;
				if (Settings.UseLefthandedCoordinates)
				{
					return Matrix.PerspectiveFovLH(vp.FoV, vp.Aspect, vp.NearPlane, vp.FarPlane);
				}

				return Matrix.PerspectiveFovRH(vp.FoV, vp.Aspect, vp.NearPlane, vp.FarPlane);
			}
		}

		public virtual Matrix BillboardMatrix
		{
			get
			{
				Matrix result = Matrix.Multiply(vp.Rotation, vp.AngelRotation);
				result.Invert();
				return result;
			}
		}

		public virtual Matrix ViewMatrix => Matrix.Multiply(vp.Rotation, Matrix.Multiply(vp.AngelRotation, Matrix.Translation(vp.RealCameraPosition)));

		public Matrix WorldMatrix
		{
			get
			{
				return world;
			}
			set
			{
				world = value;
			}
		}

		public event EventHandler ResetDevice;

		public event PrepareEffectEventHandler PrepareEffect;

		public event EventHandler ChangedLights;

		public event EventHandler RotationChanged;

		public DirectXPanel()
			: this(0.1)
		{
		}

		public DirectXPanel(double linewd)
		{
			vp = new ViewportSetting(this);
			vp.ChangedState += vp_ChangedState;
			vp.ChangedAttribute += vp_ChangedAttribute;
			Settings.BeginUpdate();
			Settings.LineWidth = Settings.LineWidth;
			meshes = new MeshList();
			base.ClientSize = new Size(400, 300);
			Text = "Direct3D Panel";
			BackColor = Color.Gray;
			ResetView();
			Settings.EndUpdate(fireattr: false, firestat: false);
		}

		public void LoadSettings(string flname)
		{
			vp.Load(flname);
		}

		private void vp_ChangedAttribute(object sender, EventArgs e)
		{
			if (!ignorechangeevent)
			{
				ignorechangeevent = true;
				Render();
				ignorechangeevent = false;
			}
		}

		private void vp_ChangedState(object sender, EventArgs e)
		{
			if (!ignorechangeevent)
			{
				ignorechangeevent = true;
				Reset();
				ignorechangeevent = false;
			}
		}

		protected static bool IsDeviceMultiSampleOK(MultiSampleType multisampleType, DepthFormat depthFmt, Format backbufferFmt, out int result, out int qualityLevels)
		{
			AdapterInformation @default = Manager.Adapters.Default;
			if ((backbufferFmt == Format.Unknown || Manager.CheckDeviceMultiSampleType(@default.Adapter, DeviceType.Hardware, backbufferFmt, windowed: false, multisampleType, out result, out qualityLevels)) && Manager.CheckDeviceMultiSampleType(@default.Adapter, DeviceType.Hardware, (Format)depthFmt, windowed: false, multisampleType, out result, out qualityLevels))
			{
				return true;
			}

			return false;
		}

		protected void SetMultiSampleIfAvail(MultiSampleType multisampleType)
		{
			int result = 0;
			int qualityLevels = 0;
			if (IsDeviceMultiSampleOK(multisampleType, presentParams.AutoDepthStencilFormat, presentParams.BackBufferFormat, out result, out qualityLevels) && result == 0)
			{
				presentParams.MultiSample = multisampleType;
				presentParams.MultiSampleQuality = qualityLevels - 1;
			}
		}

		protected bool InitializeGraphics(bool force)
		{
			try
			{
				presentParams.Windowed = true;
				presentParams.SwapEffect = SwapEffect.Discard;
				presentParams.EnableAutoDepthStencil = true;
				presentParams.AutoDepthStencilFormat = DepthFormat.D16;
				SetMultiSampleIfAvail(MultiSampleType.NonMaskable);
				SetMultiSampleIfAvail(MultiSampleType.TwoSamples);
				SetMultiSampleIfAvail(MultiSampleType.ThreeSamples);
				SetMultiSampleIfAvail(MultiSampleType.FourSamples);
				SetMultiSampleIfAvail(MultiSampleType.FiveSamples);
				SetMultiSampleIfAvail(MultiSampleType.SixSamples);
				SetMultiSampleIfAvail(MultiSampleType.SevenSamples);
				SetMultiSampleIfAvail(MultiSampleType.EightSamples);
				SetMultiSampleIfAvail(MultiSampleType.NineSamples);
				SetMultiSampleIfAvail(MultiSampleType.TenSamples);
				SetMultiSampleIfAvail(MultiSampleType.ElevenSamples);
				SetMultiSampleIfAvail(MultiSampleType.TwelveSamples);
				SetMultiSampleIfAvail(MultiSampleType.ThirteenSamples);
				SetMultiSampleIfAvail(MultiSampleType.FourteenSamples);
				SetMultiSampleIfAvail(MultiSampleType.FifteenSamples);
				SetMultiSampleIfAvail(MultiSampleType.SixteenSamples);
				device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentParams);
				device.DeviceReset += OnResetDevice;
				device.DeviceLost += device_DeviceLost;
				OnCreateDevice(device, null);
				OnResetDevice(device, null);
				SetDeviceSize();
				Settings.Paused = false;
				return true;
			}
			catch (DirectXException)
			{
				return false;
			}
		}

		private void device_DeviceLost(object sender, EventArgs e)
		{
		}

		protected void OnCreateDevice(object sender, EventArgs e)
		{
			_ = (Device)sender;
		}

		public void ReloadMeshes()
		{
			OnResetDevice(device, new EventArgs());
			Render();
		}

		public void AddScene(Scene scn)
		{
			SceneToMesh sceneToMesh = new SceneToMesh(scn, this);
			meshes.AddRange(sceneToMesh.ConvertToDx());
		}

		public void AddLightMesh()
		{
			Microsoft.DirectX.Direct3D.Material mat = new Microsoft.DirectX.Direct3D.Material();
			mat.Diffuse = Color.Yellow;
			mat.Ambient = Color.Yellow;
			mat.Specular = Color.Yellow;
			mat.SpecularSharpness = 1f;
			Microsoft.DirectX.Direct3D.Material mat2 = new Microsoft.DirectX.Direct3D.Material();
			mat2.Diffuse = Color.DarkGray;
			mat2.Ambient = Color.DarkGray;
			mat2.Specular = Color.DarkGray;
			mat2.SpecularSharpness = 1f;
			Microsoft.DirectX.Direct3D.Mesh mesh = Microsoft.DirectX.Direct3D.Mesh.Sphere(Device, 2f * Settings.LineWidth, 10, 4);
			Microsoft.DirectX.Direct3D.Mesh mesh2 = Microsoft.DirectX.Direct3D.Mesh.Box(Device, 2f * Settings.LineWidth, 2f * Settings.LineWidth, 2f * Settings.LineWidth);
			for (int i = 0; i < Device.Lights.Count; i++)
			{
				Light light = Device.Lights[i];
				MeshBox meshBox = (light.Enabled ? new MeshBox(mesh, 1, mat) : new MeshBox(mesh, 1, mat2));
				Vector3 position = light.Position;
				meshBox.Transform = Matrix.Translation(position);
				meshBox.IgnoreDuringCameraReset = true;
				Meshes.Add(meshBox);
				meshBox = (light.Enabled ? new MeshBox(mesh2, 1, mat) : new MeshBox(mesh2, 1, mat2));
				meshBox.Transform = Matrix.Translation(light.Position + 0.4f * light.Direction);
				meshBox.IgnoreDuringCameraReset = true;
				Meshes.Add(meshBox);
				meshBox = (light.Enabled ? new MeshBox(mesh2, 1, mat) : new MeshBox(mesh2, 1, mat2));
				meshBox.Transform = Matrix.Translation(light.Position + 0.5f * light.Direction);
				meshBox.IgnoreDuringCameraReset = true;
				Meshes.Add(meshBox);
			}
		}

		protected void AddAxisMesh()
		{
			System.Drawing.Font f = new System.Drawing.Font("Tahoma", 8.25f);
			AddAxisMesh(f, "X", Color.Green, new Vector3(1f, 0f, 0f));
			AddAxisMesh(f, "Y", Color.Blue, new Vector3(0f, 1f, 0f));
			AddAxisMesh(f, "Z", Color.Brown, new Vector3(0f, 0f, 1f));
		}

		protected void AddBoundingBoxMesh()
		{
			Scene owner = new Scene();
			for (int num = meshes.Count - 1; num >= 0; num--)
			{
				if (!meshes[num].SpecialMesh)
				{
					Ambertation.Scenes.Mesh m = meshes[num].GetBoundingBox(rec: false, all: false).ToMesh(owner);
					MeshBox meshBox = SceneToMesh.CreateDxMesh(device, m, isbb: true);
					if (meshBox != null)
					{
						meshes.Add(meshBox);
					}
				}
			}
		}

		protected void AddAxisMesh(System.Drawing.Font f, string txt, Color cl, Vector3 dir)
		{
			Vector3 vector = (0f - Settings.AxisScale) * Settings.LineWidth * dir;
			MeshBox[] array = CreateLineMesh(vector, dir, 2f * Settings.AxisScale * Settings.LineWidth, GetMaterial(cl), wire: false, arrow: true);
			MeshBox[] array2 = array;
			foreach (MeshBox meshBox in array2)
			{
				meshBox.IgnoreDuringCameraReset = true;
			}

			Meshes.AddRange(array);
			Matrix rotationMatrix = GetRotationMatrix(new Vector3(0f, 0f, 1f), dir);
			vector = 1.01f * vector;
			MeshBox meshBox2 = CreateTextMesh(vector.X, vector.Y, vector.Z, 10f * Settings.LineWidth, txt, Darken(cl, 0.5), rotationMatrix);
			meshBox2.IgnoreDuringCameraReset = true;
			Meshes.Add(meshBox2);
		}

		protected virtual void OnResetDevice(object sender, EventArgs e)
		{
			ignorechangeevent = true;
			try
			{
				Device device = (Device)sender;
				device.RenderState.Lighting = Settings.EnableLights;
				device.RenderState.AlphaBlendEnable = Settings.EnableAlphaBlendPass;
				device.RenderState.LocalViewer = true;
				device.RenderState.ShadeMode = Settings.ShadeMode;
				device.RenderState.SpecularEnable = Settings.EnableSpecularHighlights;
				device.RenderState.Ambient = Settings.AmbientColor;
				SetupLights();
				if (mstack != null)
				{
					mstack.Dispose();
				}

				mstack = new MatrixStack();
				if (this.ResetDevice != null)
				{
					this.ResetDevice(this, new EventArgs());
				}

				if (Settings.AddAxis)
				{
					AddAxisMesh();
				}

				if (Settings.AddLightIndicators)
				{
					AddLightMesh();
				}

				if (Settings.RenderBoundingBoxes)
				{
					AddBoundingBoxMesh();
				}
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
			}
			finally
			{
				ignorechangeevent = false;
			}
		}

		public void Render()
		{
			if (device == null)
			{
				InitializeGraphics(force: false);
			}

			if (device == null || Settings.Paused)
			{
				return;
			}

			if (sortedlist == null)
			{
				sortedlist = new MeshList();
			}
			else
			{
				sortedlist.Clear(dispose: false);
			}

			device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, BackColor, 1f, 0);
			device.BeginScene();
			int ct = 1;
			if (effect != null && Settings.EnableShaderEffectPass)
			{
				ct = effect.Begin(FX.None);
			}

			SetupLights();
			SetupMatrices();
			SetLastCameraPos();
			RenderMeshList(ct, Meshes, alphapass: false, sorted: false);
			if (Settings.EnableAlphaBlendPass)
			{
				RenderMeshList(ct, Meshes, alphapass: true, sorted: false);
			}

			RenderMeshList(ct, sortedlist, alphapass: true, sorted: true);
			if (effect != null && Settings.EnableShaderEffectPass)
			{
				effect.End();
			}

			device.EndScene();
			try
			{
				device.Present();
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
			}
		}

		private void SetLastCameraPos()
		{
			lastcampos = new Vector3(0f, 0f, 0f);
			Matrix viewMatrix = ViewMatrix;
			viewMatrix.Invert();
			lastcampos.TransformCoordinate(viewMatrix);
		}

		private void RenderMeshList(int ct, MeshList meshes, bool alphapass, bool sorted)
		{
			if (meshes == null || meshes.Count == 0)
			{
				return;
			}

			if (!alphapass && !sorted)
			{
				device.RenderState.ZBufferWriteEnable = true;
				device.RenderState.AlphaBlendEnable = true;
				{
					foreach (MeshBox item in (IEnumerable)meshes)
					{
						if (item.Opaque || !Settings.EnableAlphaBlendPass)
						{
							RenderMeshBox(ct, item, Settings.MeshPassCullMode, alphapass, sorted);
						}
					}

					return;
				}
			}

			if (!Settings.EnableAlphaBlendPass && !sorted)
			{
				return;
			}

			device.RenderState.ZBufferWriteEnable = false;
			device.RenderState.AlphaBlendEnable = true;
			foreach (MeshBox item2 in (IEnumerable)meshes)
			{
				if (sorted || !item2.Opaque)
				{
					RenderMeshBox(ct, item2, Settings.AlphaPassCullMode, alphapass, sorted);
				}
			}
		}

		private void RenderMeshBox(int ct, MeshBox box, Cull cull, bool alphapass, bool sorted)
		{
			device.RenderState.ZBufferEnable = box.ZTest;
			SetupTextures(box.TextureMode);
			if (!sorted)
			{
				mstack.Push();
				mstack.MultiplyMatrixLocal(box.Transform);
				if (box.Billboard)
				{
					mstack.MultiplyMatrixLocal(BillboardMatrix);
				}

				device.Transform.World = mstack.Top;
				if (box.Sort)
				{
					box.SetupSortWorld(device.Transform.World, lastcampos);
					AddToSortedList(box);
				}
			}
			else
			{
				device.Transform.World = box.World;
			}

			if ((!box.JointMesh || Settings.RenderJoints) && (sorted || !box.Sort))
			{
				DoRenderMeshBox(ct, box, cull, 0);
			}

			RenderMeshList(ct, box, alphapass, sorted: false);
			mstack.Pop();
		}

		private void DoRenderMeshBox(int ct, MeshBox box, Cull cull, int pass)
		{
			if (box.Mesh == null)
			{
				return;
			}

			device.RenderState.FillMode = Settings.GetFillMode(box, pass);
			device.RenderState.CullMode = box.GetCullMode(cull);
			if (pass == 0 && Settings.FillMode == ViewportSettingBasic.FillModes.WireframeOverlay)
			{
				device.Material = GetMaterial(255, Color.Black);
			}
			else
			{
				device.Material = box.Material;
				if (Settings.EnableTextures)
				{
					if (box.Texture == null)
					{
						box.PrepareTexture(device);
					}

					device.SetTexture(0, box.Texture);
				}
			}

			if (effect != null && this.PrepareEffect != null && Settings.EnableShaderEffectPass)
			{
				this.PrepareEffect(this, new PrepareEffectEventArgs(box));
			}

			for (int i = 0; i < ct; i++)
			{
				if (effect != null && Settings.EnableShaderEffectPass)
				{
					effect.BeginPass(i);
				}

				try
				{
					for (int j = 0; j < box.SubSetCount; j++)
					{
						box.Mesh.DrawSubset(j);
					}
				}
				catch
				{
				}

				if (effect != null && Settings.EnableShaderEffectPass)
				{
					effect.EndPass();
				}
			}

			if (Settings.FillMode == ViewportSettingBasic.FillModes.WireframeOverlay && pass == 0 && !box.SpecialMesh)
			{
				DoRenderMeshBox(ct, box, cull, 1);
			}
		}

		private void AddToSortedList(MeshBox box)
		{
			int index = sortedlist.Count;
			int num = 0;
			foreach (MeshBox item in (IEnumerable)sortedlist)
			{
				if (item.Distance < box.Distance)
				{
					index = num;
					break;
				}

				num++;
			}

			sortedlist.Insert(index, box);
		}

		protected virtual void SetupLights()
		{
			Vector3 cameraPosition = vp.CameraPosition;
			cameraPosition.TransformCoordinate(Matrix.RotationY(-(float)Math.PI / 6f));
			Vector3 vector = -vp.CameraPosition;
			vector.TransformCoordinate(Matrix.RotationY(-0.9239978f));
			vector.TransformCoordinate(Matrix.RotationZ(-0.9239978f));
			Vector3 vector2 = -1f * vp.CameraPosition;
			vector2.TransformCoordinate(Matrix.RotationZ(0.9817477f));
			vector2.TransformCoordinate(Matrix.RotationX(0.747998238f));
			vector2.TransformCoordinate(Matrix.RotationY(0.8975979f));
			device.Lights[0].Type = LightType.Directional;
			device.Lights[0].Attenuation0 = 0.1f;
			device.Lights[0].Attenuation1 = 0.1f;
			device.Lights[0].Attenuation2 = 0.1f;
			device.Lights[0].Diffuse = Settings.LightColorDiffuse;
			device.Lights[0].Specular = Settings.LightColorSpecular;
			device.Lights[0].Position = 2f * cameraPosition;
			device.Lights[0].Direction = vp.CameraTarget - device.Lights[0].Position;
			device.Lights[0].Range = 1f * (vp.ObjectCenter - device.Lights[0].Position).Length();
			device.Lights[0].Enabled = true;
			device.Lights[1].Type = device.Lights[0].Type;
			device.Lights[1].Attenuation0 = 0.1f;
			device.Lights[1].Attenuation1 = 0.1f;
			device.Lights[1].Attenuation2 = 0.1f;
			device.Lights[1].Falloff = device.Lights[0].Falloff;
			device.Lights[1].Diffuse = device.Lights[0].Diffuse;
			device.Lights[1].Specular = device.Lights[0].Specular;
			device.Lights[1].Position = 4f * vector;
			device.Lights[1].Direction = vp.CameraTarget - device.Lights[1].Position;
			device.Lights[1].Range = 1f * (vp.ObjectCenter - device.Lights[1].Position).Length();
			device.Lights[1].Enabled = true;
			device.Lights[2].Type = LightType.Directional;
			device.Lights[2].Attenuation0 = 0.1f;
			device.Lights[2].Attenuation1 = 0.1f;
			device.Lights[2].Attenuation2 = 0.1f;
			device.Lights[2].Falloff = device.Lights[0].Falloff;
			device.Lights[2].Diffuse = device.Lights[0].Diffuse;
			device.Lights[2].Specular = device.Lights[0].Specular;
			device.Lights[2].Position = 2f * vector2;
			device.Lights[2].Direction = vp.CameraTarget - device.Lights[2].Position;
			device.Lights[2].Range = 1f * (vp.ObjectCenter - device.Lights[2].Position).Length();
			device.Lights[2].Enabled = true;
			if (this.ChangedLights != null)
			{
				this.ChangedLights(this, new EventArgs());
			}
		}

		private void SetupMatrices()
		{
			device.Transform.World = world;
			device.Transform.View = ViewMatrix;
			device.Transform.Projection = ProjectionMatrix;
			mstack.LoadMatrix(world);
		}

		private void SetupTextures(Ambertation.Scenes.Material.TextureModes mode)
		{
			switch (mode)
			{
				case Ambertation.Scenes.Material.TextureModes.Default:
					device.RenderState.SourceBlend = Blend.SourceAlpha;
					device.RenderState.AlphaSourceBlend = Blend.SourceAlpha;
					device.RenderState.DestinationBlend = Blend.InvSourceAlpha;
					device.RenderState.AlphaDestinationBlend = Blend.InvSourceAlpha;
					device.RenderState.AlphaBlendOperation = BlendOperation.Add;
					device.TextureState[0].ColorOperation = TextureOperation.BlendCurrentAlpha;
					device.TextureState[0].ColorArgument0 = TextureArgument.Diffuse;
					device.TextureState[0].ColorArgument1 = TextureArgument.TextureColor;
					device.TextureState[0].ColorArgument2 = TextureArgument.Diffuse;
					device.TextureState[0].AlphaOperation = TextureOperation.Modulate;
					device.TextureState[0].AlphaArgument0 = TextureArgument.Diffuse;
					device.TextureState[0].AlphaArgument1 = TextureArgument.TextureColor;
					device.TextureState[0].AlphaArgument2 = TextureArgument.Current;
					break;
				case Ambertation.Scenes.Material.TextureModes.ShadowTexture:
					device.RenderState.SourceBlend = Blend.Zero;
					device.RenderState.DestinationBlend = Blend.InvSourceColor;
					device.RenderState.AlphaSourceBlend = Blend.SourceColor;
					device.RenderState.AlphaDestinationBlend = Blend.One;
					device.RenderState.AlphaBlendOperation = BlendOperation.Add;
					device.TextureState[0].ColorOperation = TextureOperation.Subtract;
					device.TextureState[0].ColorArgument0 = TextureArgument.Current;
					device.TextureState[0].ColorArgument1 = TextureArgument.TextureColor;
					device.TextureState[0].ColorArgument2 = TextureArgument.Diffuse;
					device.TextureState[0].AlphaOperation = TextureOperation.Disable;
					device.TextureState[0].AlphaArgument0 = TextureArgument.Current;
					device.TextureState[0].AlphaArgument1 = TextureArgument.Current;
					device.TextureState[0].AlphaArgument2 = TextureArgument.TextureColor;
					break;
				case Ambertation.Scenes.Material.TextureModes.MaterialWithTexture:
					device.RenderState.SourceBlend = Blend.SourceAlpha;
					device.RenderState.AlphaSourceBlend = Blend.SourceAlpha;
					device.RenderState.DestinationBlend = Blend.InvSourceAlpha;
					device.RenderState.AlphaDestinationBlend = Blend.InvSourceAlpha;
					device.RenderState.AlphaBlendOperation = BlendOperation.Add;
					device.TextureState[0].ColorOperation = TextureOperation.BlendTextureAlpha;
					device.TextureState[0].ColorArgument0 = TextureArgument.Diffuse;
					device.TextureState[0].ColorArgument1 = TextureArgument.TextureColor;
					device.TextureState[0].ColorArgument2 = TextureArgument.Current;
					device.TextureState[0].AlphaOperation = TextureOperation.Disable;
					device.TextureState[0].AlphaArgument0 = TextureArgument.Diffuse;
					device.TextureState[0].AlphaArgument1 = TextureArgument.TextureColor;
					device.TextureState[0].AlphaArgument2 = TextureArgument.Current;
					break;
				default:
					device.RenderState.SourceBlend = Blend.SourceAlpha;
					device.RenderState.DestinationBlend = Blend.SourceColor;
					device.RenderState.AlphaSourceBlend = Blend.SourceAlpha;
					device.RenderState.AlphaDestinationBlend = Blend.SourceAlpha;
					device.RenderState.AlphaBlendOperation = BlendOperation.Add;
					device.TextureState[0].ColorOperation = TextureOperation.SelectArg1;
					device.TextureState[0].ColorArgument0 = TextureArgument.Current;
					device.TextureState[0].ColorArgument1 = TextureArgument.Diffuse;
					device.TextureState[0].ColorArgument2 = TextureArgument.Current;
					device.TextureState[0].AlphaOperation = TextureOperation.Disable;
					device.TextureState[0].AlphaArgument0 = TextureArgument.Diffuse;
					device.TextureState[0].AlphaArgument1 = TextureArgument.Diffuse;
					device.TextureState[0].AlphaArgument2 = TextureArgument.Current;
					break;
			}

			device.TextureState[1].ColorOperation = TextureOperation.Disable;
			device.TextureState[1].AlphaOperation = TextureOperation.Disable;
		}

		public void Reset()
		{
			if (device != null)
			{
				device.EvictManagedResources();
				try
				{
					OnResize(null);
					device.Reset(presentParams);
				}
				catch (Exception value)
				{
					Console.WriteLine(value);
				}
			}

			Render();
		}

		public void ResetDefaultViewport()
		{
			ResetView();
			OnResetDevice(device, null);
			Render();
		}

		public void ResetViewport(Vector3 min, Vector3 max)
		{
			ResetView(min, max);
			OnResetDevice(device, null);
			Render();
		}

		protected void ResetView()
		{
			vp.Reset();
			BoundingBox boundingBox = new BoundingBox();
			try
			{
				foreach (MeshBox item in (IEnumerable)Meshes)
				{
					if (!item.SpecialMesh)
					{
						boundingBox += item.GetBoundingBox(rec: true, all: false);
					}
				}

				ResetView(Converter.ToDx(boundingBox.Min), Converter.ToDx(boundingBox.Max));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
			}
		}

		protected void ResetView(Vector3 min, Vector3 max)
		{
			try
			{
				Settings.BeginUpdate();
				ignorechangeevent = true;
				if (!(min.X > max.X))
				{
					Vector3 objectCenter = new Vector3((float)((double)(max.X + min.X) / 2.0), (float)((double)(max.Y + min.Y) / 2.0), (float)((double)(max.Z + min.Z) / 2.0));
					double num = new Vector3(min.X - objectCenter.X, min.Y - objectCenter.Y, min.Z - objectCenter.Z).Length();
					double num2 = num / Math.Sin(vp.FoV / 2f);
					vp.ObjectCenter = objectCenter;
					vp.X = 0f - objectCenter.X;
					vp.Y = 0f - objectCenter.Y;
					vp.Z = 0f - objectCenter.Z;
					vp.CameraTarget = new Vector3(0f, 0f, 0f);
					if (Settings.UseLefthandedCoordinates)
					{
						vp.CameraPosition = new Vector3(0f, 0f, (float)num2 * Settings.InitialCameraOffsetScale);
					}
					else
					{
						vp.CameraPosition = new Vector3(0f, 0f, (0f - (float)num2) * Settings.InitialCameraOffsetScale);
					}

					vp.NearPlane = (float)(num2 - num);
					vp.FarPlane = (float)(num2 + num);
					vp.NearPlane = 1f;
					vp.FarPlane = 10000f;
					vp.BoundingSphereRadius = (float)num;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
			}
			finally
			{
				Settings.EndUpdate();
				ignorechangeevent = false;
			}
		}

		public void UpdateRotation()
		{
			OnMouseUp(null);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			ignorechangeevent = true;
			vp.Rotation = Matrix.Multiply(vp.Rotation, vp.AngelRotation);
			vp.ResetAngle();
			ignorechangeevent = false;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			ignorechangeevent = true;
			try
			{
				base.OnMouseMove(e);
				if (last != null)
				{
					int num = e.X - last.X;
					int num2 = e.Y - last.Y;
					float num3 = 1f;
					if (!Settings.UseLefthandedCoordinates)
					{
						num3 = -1f;
					}

					if (e.Button == MouseButtons.Right)
					{
						vp.AngelY -= num3 * ((float)num / vp.InputRotationScale);
						vp.AngelX -= num3 * ((float)num2 / vp.InputRotationScale);
						if (this.RotationChanged != null)
						{
							this.RotationChanged(this, new EventArgs());
						}
					}

					if (e.Button == MouseButtons.Left)
					{
						vp.X += (float)num / ((float)base.Width * vp.InputTranslationScale / vp.BoundingSphereRadius);
						vp.Y -= (float)num2 / ((float)base.Height * vp.InputTranslationScale / vp.BoundingSphereRadius);
					}

					if (e.Button == MouseButtons.Middle)
					{
						vp.Z += num3 * ((float)num2 / ((float)base.Height * vp.InputTranslationScale / vp.BoundingSphereRadius));
						vp.AngelZ -= (float)num / vp.InputRotationScale;
						if (this.RotationChanged != null)
						{
							this.RotationChanged(this, new EventArgs());
						}
					}

					Render();
				}

				last = e;
			}
			finally
			{
				ignorechangeevent = false;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Render();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.Width = Math.Max(1, base.Width);
			base.Height = Math.Max(1, base.Height);
			base.OnSizeChanged(e);
		}

		protected override void OnResize(EventArgs e)
		{
			base.Width = Math.Max(1, base.Width);
			base.Height = Math.Max(1, base.Height);
			Settings.Paused = Math.Min(base.Width, base.Height) <= 0;
			SetDeviceSize();
			if (base.Height != 0)
			{
				vp.Aspect = (float)base.Width / (float)base.Height;
			}
			else
			{
				vp.Aspect = 1f;
			}

			base.OnResize(e);
		}

		private void SetDeviceSize()
		{
			if (device != null)
			{
				Viewport viewport = new Viewport();
				viewport.Width = base.Width;
				viewport.Height = base.Height;
				device.Viewport = viewport;
			}
		}

		public Image Screenshot()
		{
			return Screenshot(ImageFileFormat.Png);
		}

		public Image Screenshot(ImageFileFormat format)
		{
			Surface backBuffer = device.GetBackBuffer(0, 0, BackBufferType.Mono);
			Stream stream = SurfaceLoader.SaveToStream(format, backBuffer);
			Image result = Image.FromStream(stream);
			backBuffer.Dispose();
			return result;
		}

		private static double Sign(double v)
		{
			return v / Math.Abs(v);
		}

		public static Matrix GetRotationMatrix(Vector3 src, Vector3 dst)
		{
			Quaternion rotationQuaternion = GetRotationQuaternion(src, dst);
			return Matrix.RotationQuaternion(rotationQuaternion);
		}

		public static Quaternion GetRotationQuaternion(Vector3 src, Vector3 dst)
		{
			src.Normalize();
			dst.Normalize();
			Vector3 vector = Vector3.Cross(src, dst);
			_ = Math.Asin(vector.Length()) / 2.0;
			double num = Math.Acos(Vector3.Dot(src, dst)) / 2.0;
			vector.Normalize();
			vector = (float)Math.Sin(num) * vector;
			return new Quaternion(vector.X, vector.Y, vector.Z, (float)Math.Cos(num));
		}

		public Microsoft.DirectX.Direct3D.Mesh CreatePyramidMesh(double width, double height)
		{
			float num = (float)(width / 2.0);
			float num2 = (float)(height / 2.0);
			CustomVertex.PositionNormal[] array = new CustomVertex.PositionNormal[5]
			{
			new CustomVertex.PositionNormal(0f - num, 0f - num, 0f - num2, 0f, 0f, 0f),
			new CustomVertex.PositionNormal(num, 0f - num, 0f - num2, 0f, 0f, 0f),
			new CustomVertex.PositionNormal(num, num, 0f - num2, 0f, 0f, 0f),
			new CustomVertex.PositionNormal(0f - num, num, 0f - num2, 0f, 0f, 0f),
			new CustomVertex.PositionNormal(0f, 0f, num2, 0f, 0f, 0f)
			};
			short[] array2 = new short[18]
			{
			2, 1, 0, 0, 3, 2, 0, 1, 4, 1,
			2, 4, 2, 3, 4, 3, 0, 4
			};
			Microsoft.DirectX.Direct3D.Mesh mesh = new Microsoft.DirectX.Direct3D.Mesh(array2.Length / 3, array.Length, (MeshFlags)0, VertexFormats.PositionNormal, device);
			mesh.SetVertexBufferData(array, LockFlags.None);
			mesh.SetIndexBufferData(array2, LockFlags.None);
			int[] array3 = new int[mesh.NumberFaces * 3];
			mesh.GenerateAdjacency(0.01f, array3);
			mesh.OptimizeInPlace(MeshFlags.OptimizeVertexCache, array3);
			mesh.ComputeNormals(array3);
			return mesh;
		}

		public MeshBox[] CreateLineMesh(Vector3 start, Vector3 stop, Microsoft.DirectX.Direct3D.Material mat, bool wire, bool arrow)
		{
			Vector3 dir = stop - start;
			return CreateLineMesh(start, dir, dir.Length(), mat, wire, arrow);
		}

		public MeshBox[] CreateLineMesh(Vector3 start, Vector3 stop, Microsoft.DirectX.Direct3D.Material mat, bool wire, bool arrow, double linewd)
		{
			Vector3 dir = stop - start;
			return CreateLineMesh(start, dir, dir.Length(), mat, wire, arrow, linewd);
		}

		public MeshBox[] CreateLineMesh(Vector3 dir, double len, Microsoft.DirectX.Direct3D.Material mat, bool wire, bool arrow)
		{
			return CreateLineMesh(new Vector3(0f, 0f, 0f), dir, len, mat, wire, arrow);
		}

		public MeshBox[] CreateLineMesh(Vector3 start, Vector3 dir, double len, Microsoft.DirectX.Direct3D.Material mat, bool wire, bool arrow)
		{
			return CreateLineMesh(start, dir, len, mat, wire, arrow, Settings.LineWidth);
		}

		public MeshBox[] CreateLineMesh(Vector3 start, Vector3 dir, double len, Microsoft.DirectX.Direct3D.Material mat, bool wire, bool arrow, double linewd)
		{
			float num = (float)linewd;
			Microsoft.DirectX.Direct3D.Mesh mesh = Microsoft.DirectX.Direct3D.Mesh.Cylinder(device, num, num, (float)len, 8, 2);
			Matrix rotationMatrix = GetRotationMatrix(new Vector3(0f, 0f, 1f), dir);
			Vector3 v = new Vector3(0f, 0f, (float)(len / 2.0));
			Matrix left = Matrix.Translation(v);
			Matrix transform = Matrix.Multiply(left, rotationMatrix);
			transform.Multiply(Matrix.Translation(start));
			MeshBox meshBox = new MeshBox(mesh, 1, mat, transform);
			meshBox.Wire = wire;
			if (arrow)
			{
				mesh = CreatePyramidMesh(7f * num, 7f * num);
				v = new Vector3(0f, 0f, (float)len);
				left = Matrix.Translation(v);
				transform = Matrix.Multiply(left, rotationMatrix);
				transform.Multiply(Matrix.Translation(start));
				MeshBox meshBox2 = new MeshBox(mesh, 1, mat, transform);
				meshBox.Opaque = mat.Diffuse.A == byte.MaxValue || mat.Diffuse.A != 0;
				meshBox2.Opaque = meshBox.Opaque;
				meshBox2.Wire = wire;
				return new MeshBox[2] { meshBox, meshBox2 };
			}

			return new MeshBox[1] { meshBox };
		}

		public MeshBox[] CreateNamedCube(double sz, Color bcl)
		{
			return CreateNamedCube(sz, bcl, GetTextColor(bcl), Matrix.Identity);
		}

		public MeshBox[] CreateNamedCube(double sz, Color bcl, Color tcl)
		{
			return CreateNamedCube(sz, bcl, tcl, Matrix.Identity);
		}

		public MeshBox[] CreateNamedCube(double sz, Color bcl, Color tcl, Matrix basetrans)
		{
			MeshBox[] array = new MeshBox[7];
			double num = sz / 2.0;
			array[0] = CreateCube(sz, bcl);
			array[0].Transform = basetrans;
			array[1] = CreateTextMesh(0.0, 0.0, num, sz * 0.5, "+pz", tcl, Matrix.RotationY((float)Math.PI));
			array[1].Transform = Matrix.Multiply(array[1].Transform, array[0].Transform);
			array[2] = CreateTextMesh(0.0, 0.0, 0.0 - num, sz * 0.5, "-pz", tcl, Matrix.Identity);
			array[2].Transform = Matrix.Multiply(array[2].Transform, array[0].Transform);
			array[3] = CreateTextMesh(0.0, num, 0.0, sz * 0.5, "+py", tcl, Matrix.RotationX((float)Math.PI / 2f));
			array[3].Transform = Matrix.Multiply(array[3].Transform, array[0].Transform);
			array[4] = CreateTextMesh(0.0, 0.0 - num, 0.0, sz * 0.5, "-py", tcl, Matrix.RotationX(-(float)Math.PI / 2f));
			array[4].Transform = Matrix.Multiply(array[4].Transform, array[0].Transform);
			array[5] = CreateTextMesh(num, 0.0, 0.0, sz * 0.5, "+px", tcl, Matrix.RotationY(-(float)Math.PI / 2f));
			array[5].Transform = Matrix.Multiply(array[5].Transform, array[0].Transform);
			array[6] = CreateTextMesh(0.0 - num, 0.0, 0.0, sz * 0.5, "-px", tcl, Matrix.RotationY((float)Math.PI / 2f));
			array[6].Transform = Matrix.Multiply(array[6].Transform, array[0].Transform);
			return array;
		}

		public MeshBox CreateCube(double sz, Color cl)
		{
			Microsoft.DirectX.Direct3D.Mesh mesh = Microsoft.DirectX.Direct3D.Mesh.Box(Device, (float)sz, (float)sz, (float)sz);
			MeshBox meshBox = new MeshBox(mesh, 1, GetMaterial(cl));
			meshBox.Wire = false;
			return meshBox;
		}

		public MeshBox CreateBillboard(double width, double height, Image img)
		{
			float num = (float)(width / 2.0);
			float num2 = (float)(height / 2.0);
			CustomVertex.PositionNormalTextured[] array = new CustomVertex.PositionNormalTextured[5]
			{
			new CustomVertex.PositionNormalTextured(0f - num, 0f - num2, 0f, 0f, 0f, 0f, 0f, 0f),
			new CustomVertex.PositionNormalTextured(0f - num, num2, 0f, 0f, 0f, 0f, 0f, -1f),
			new CustomVertex.PositionNormalTextured(num, num2, 0f, 0f, 0f, 0f, 1f, -1f),
			new CustomVertex.PositionNormalTextured(num, 0f - num2, 0f, 0f, 0f, 0f, 1f, 0f),
			default(CustomVertex.PositionNormalTextured)
			};
			short[] array2 = new short[6] { 2, 1, 0, 0, 3, 2 };
			Microsoft.DirectX.Direct3D.Mesh mesh = new Microsoft.DirectX.Direct3D.Mesh(array2.Length / 3, array.Length, (MeshFlags)0, VertexFormats.PositionNormal | VertexFormats.Texture1, device);
			mesh.SetVertexBufferData(array, LockFlags.None);
			mesh.SetIndexBufferData(array2, LockFlags.None);
			int[] array3 = new int[mesh.NumberFaces * 3];
			mesh.GenerateAdjacency(0.01f, array3);
			mesh.OptimizeInPlace(MeshFlags.OptimizeVertexCache, array3);
			mesh.ComputeNormals(array3);
			MeshBox meshBox = new MeshBox(mesh, 1, GetMaterial(Color.FromArgb(255, Color.White)));
			meshBox.Wire = false;
			meshBox.Billboard = true;
			meshBox.Sort = true;
			meshBox.CullMode = MeshBox.Cull.None;
			meshBox.SetTexture(img);
			return meshBox;
		}

		public MeshBox CreateTextMesh(double x, double y, double z, double textsz, string text, Color cl)
		{
			return CreateTextMesh(x, y, z, textsz, text, cl, Matrix.Identity);
		}

		public MeshBox CreateTextMesh(double x, double y, double z, double textsz, string text, Color cl, Matrix trans)
		{
			if (double.IsNaN(textsz))
			{
				textsz = 1.0;
			}

			System.Drawing.Font font = new System.Drawing.Font("Tahoma", (float)textsz);
			Microsoft.DirectX.Direct3D.Mesh mesh = Microsoft.DirectX.Direct3D.Mesh.TextFromFont(Device, font, text, Settings.LineWidth, Settings.LineWidth);
			MeshBox meshBox = new MeshBox(mesh, 1, GetMaterial(cl));
			Vector3[] boundingBoxVectors = meshBox.GetBoundingBoxVectors();
			double num = (double)Math.Abs(boundingBoxVectors[1].X - boundingBoxVectors[0].X) / -2.0;
			double num2 = (double)Math.Abs(boundingBoxVectors[1].Y - boundingBoxVectors[0].Y) / -2.0;
			double num3 = (double)Math.Abs(boundingBoxVectors[1].Z - boundingBoxVectors[0].Z) / -2.0;
			meshBox.Transform = Matrix.Multiply(Matrix.Translation(new Vector3((float)num, (float)num2, (float)num3)), Matrix.Multiply(Matrix.Scaling((float)textsz, (float)textsz, 1f), Matrix.Multiply(trans, Matrix.Translation(new Vector3((float)x, (float)y, (float)z)))));
			meshBox.Wire = false;
			return meshBox;
		}

		public MeshBox[] CreateLayerMesh(Vector3 start, Vector3 dir1, Vector3 dir2, double width, double height, Microsoft.DirectX.Direct3D.Material mat, bool wire)
		{
			Vector3 n = Vector3.Cross(dir1, dir2);
			return CreateLayerMesh(start, n, width, height, mat, wire);
		}

		public MeshBox[] CreateLayerMesh(Vector3 start, Vector3 n, double width, double height, Microsoft.DirectX.Direct3D.Material mat, bool wire)
		{
			Microsoft.DirectX.Direct3D.Mesh mesh = Microsoft.DirectX.Direct3D.Mesh.Box(device, (float)width, (float)height, Settings.LineWidth * 0.3f);
			try
			{
				int[] array = new int[mesh.NumberFaces * 3];
				mesh.GenerateAdjacency(Settings.LineWidth, array);
				mesh = Microsoft.DirectX.Direct3D.Mesh.TessellateNPatches(mesh, array, 32f, quadraticInterpNormals: true);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Matrix rotationMatrix = GetRotationMatrix(new Vector3(0f, 0f, 1f), n);
			Matrix right = Matrix.Translation(start);
			Matrix transform = Matrix.Multiply(rotationMatrix, right);
			MeshBox meshBox = new MeshBox(mesh, 1, mat, transform);
			meshBox.Opaque = mat.Diffuse.A == byte.MaxValue || mat.Diffuse.A == 0;
			meshBox.Wire = wire;
			return new MeshBox[1] { meshBox };
		}

		public static Microsoft.DirectX.Direct3D.Material GetMaterial(int alpha, Color cl)
		{
			return GetMaterial(Color.FromArgb(alpha, cl));
		}

		public static Microsoft.DirectX.Direct3D.Material GetMaterial(Color cl)
		{
			Microsoft.DirectX.Direct3D.Material result = new Microsoft.DirectX.Direct3D.Material();
			result.Diffuse = cl;
			result.Ambient = Color.FromArgb(cl.A, (int)Math.Floor((double)(int)cl.R * 0.1), (int)Math.Floor((double)(int)cl.G * 0.1), (int)Math.Floor((double)(int)cl.B * 0.1));
			result.Specular = cl;
			result.SpecularSharpness = 100f;
			return result;
		}

		public static int Clamp(double comp)
		{
			int num = (int)comp;
			if (num < 0)
			{
				num = 0;
			}

			if (num > 255)
			{
				num = 255;
			}

			return num;
		}

		public static Color ChangeBrightness(Color cl, double fact)
		{
			return Color.FromArgb(cl.A, Clamp((double)(int)cl.R * fact), Clamp((double)(int)cl.G * fact), Clamp((double)(int)cl.B * fact));
		}

		public static Color Brighten(Color cl, double fact)
		{
			fact += 1.0;
			return ChangeBrightness(cl, fact);
		}

		public static Color Darken(Color cl, double fact)
		{
			return ChangeBrightness(cl, fact);
		}

		public static Color GetTextColor(Color cl)
		{
			if (cl.GetBrightness() >= 0.5f)
			{
				return Darken(cl, 0.5);
			}

			return Brighten(cl, 0.5);
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);
			if (Settings.AllowSettingsDialog)
			{
				if (vpsf == null)
				{
					vpsf = ViewPortSetup.Execute(Settings, this);
					return;
				}

				ViewPortSetup.Hide(vpsf);
				vpsf.Dispose();
				vpsf = null;
			}
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			base.OnHandleDestroyed(e);
			if (vpsf != null)
			{
				vpsf.Dispose();
				vpsf = null;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				try
				{
					if (device != null)
					{
						device.DeviceReset -= OnResetDevice;
						device.DeviceLost -= device_DeviceLost;
						device.EvictManagedResources();
						device.Dispose();
					}
				}
				catch
				{
				}

				device = null;
				vp = null;
				if (meshes != null)
				{
					meshes.Clear(dispose: true);
				}

				meshes = null;
			}

			base.Dispose(disposing);
		}
	}
}
