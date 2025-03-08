// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;

using Ambertation.Geometry;
using Ambertation.Geometry.Collections;
using Ambertation.Scenes;
using Ambertation.Scenes.Collections;
using Ambertation.XSI.IO;
using Ambertation.XSI.Template;
using Microsoft.DirectX.Direct3D;

using SimPe.Plugin;

using FileInfo = Ambertation.XSI.Template.FileInfo;
using Light = Ambertation.XSI.Template.Light;
using Mesh = Ambertation.Scenes.Mesh;
using Scene = Ambertation.XSI.Template.Scene;

namespace Ambertation.XSI
{
	public class SceneToXsi : IConvertScene
	{
		private Ambertation.Scenes.Scene scn;

		public SceneToXsi(Ambertation.Scenes.Scene scn)
		{
			this.scn = scn;
		}

		public object Convert()
		{
			return ConvertToXsi();
		}

		public AsciiFile ConvertToXsi()
		{
			AsciiFile asciiFile = new AsciiFile("");
			Scene s = AddMeta(asciiFile);
			AddMaterial(asciiFile, s);
			Container root = asciiFile.Root;
			AddJoints(asciiFile.Root, scn.RootJoint);
			AddMeshes(root);
			AddEnvelope(asciiFile);
			return asciiFile;
		}

		private void AddEnvelope(AsciiFile xsi)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			EnvelopeList elist = null;
			foreach (Mesh item in scn.MeshCollection)
			{
				Mesh val = item;
				foreach (Ambertation.Scenes.Envelope envelope in val.Envelopes)
				{
					Ambertation.Scenes.Envelope env = envelope;
					elist = AddEnvelope(xsi, elist, env);
				}
			}
		}

		private double SetWeight(double i)
		{
			i *= 1.0;
			if (i < 0.0)
			{
				i = 0.0;
			}

			if (i > 100.0)
			{
				i = 100.0;
			}

			return i;
		}

		private EnvelopeList AddEnvelope(AsciiFile xsi, EnvelopeList elist, Ambertation.Scenes.Envelope env)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			IndexedWeightCollection val = new IndexedWeightCollection();
			for (int i = 0; i < env.Weights.Count; i++)
			{
				if (env.Weights[i] > 0.0)
				{
					val.Add(new IndexedWeight(i, SetWeight(env.Weights[i])));
				}
			}

			if (val.Count > 0)
			{
				if (elist == null)
				{
					elist = (EnvelopeList)xsi.Root.CreateChild("SI_EnvelopeList");
				}

				Ambertation.XSI.Template.Envelope envelope = (Ambertation.XSI.Template.Envelope)elist.CreateChild("SI_Envelope");
				val.CopyTo(envelope.Weights, true);
				envelope.Deformer = ((Node)env.Joint).Name;
				envelope.EnvelopModel = ((Node)env.Mesh).Name;
			}

			return elist;
		}

		private void AddJoints(Container model, Joint joint)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			foreach (Joint item in (NodeCollectionBase)joint.Childs)
			{
				Joint joint2 = item;
				AddJoint(model, joint2);
			}
		}

		private void AddJoint(Container model, Joint joint)
		{
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Expected O, but got Unknown
			Model model2 = (Model)model.CreateChild("SI_Model");
			model2.ModelName = ((Node)joint).Name;
			Transform transform = (Transform)model2.CreateChild("SI_Transform");
			transform.Type = Transform.Types.SRT;
			transform.ModelName = model2.ModelName;
			transform.Rotate = ((Transformation)joint).Rotation.RadiantsToDegrees();
			transform.Translate = ((Transformation)joint).Translation;
			transform.Scale = ((Transformation)joint).Scaling;
			Visibility visibility = (Visibility)model2.CreateChild("SI_Visibility");
			visibility.State = Visibility.States.Visible;
			Null @null = (Null)model2.CreateChild("SI_Null");
			@null.NullName = model2.ModelName;
			foreach (Joint item in (Node)joint)
			{
				Joint joint2 = item;
				AddJoint(model2, joint2);
			}
		}

		private void AddMeshes(Container model)
		{
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			foreach (Mesh item in (NodeCollectionBase)scn.SceneRoot.Childs)
			{
				Mesh msh = item;
				AddMesh(model, msh);
			}
		}

		private void AddMesh(Container model, Mesh msh)
		{
			//IL_0270: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Expected O, but got Unknown
			Model model2 = (Model)model.CreateChild("SI_Model");
			model2.ModelName = ((Node)msh).Name;
			GlobalMaterial globalMaterial = (GlobalMaterial)model2.CreateChild("SI_GlobalMaterial");
			globalMaterial.ReferencedMaterialName = msh.Material.Name;
			Transform transform = (Transform)model2.CreateChild("SI_Transform");
			transform.Type = Transform.Types.SRT;
			transform.ModelName = model2.ModelName;
			transform.Rotate = ((Transformation)msh).Rotation.RadiantsToDegrees();
			transform.Translate = ((Transformation)msh).Translation;
			transform.Scale = ((Transformation)msh).Scaling;
			Transform transform2 = (Transform)model2.CreateChild("SI_Transform");
			transform2.Type = Transform.Types.BASEPOSE;
			transform2.ModelName = model2.ModelName;
			transform2.Rotate = ((Node)msh).WorldPosition.Rotation.RadiantsToDegrees();
			transform2.Translate = ((Node)msh).WorldPosition.Translation;
			transform2.Scale = ((Node)msh).WorldPosition.Scaling;
			Visibility visibility = (Visibility)model2.CreateChild("SI_Visibility");
			visibility.State = Visibility.States.Visible;
			if (msh.Vertices.Count > 0)
			{
				Ambertation.XSI.Template.Mesh mesh = (Ambertation.XSI.Template.Mesh)model2.CreateChild("SI_Mesh");
				mesh.MeshName = ((Node)msh).Name;
				Ambertation.XSI.Template.Shape shape = (Ambertation.XSI.Template.Shape)mesh.CreateChild("SI_Shape");
				shape.PrimitiveName = ((Node)msh).Name;
				shape.MaterialName = msh.Material.Name;
				msh.Vertices.CopyTo(shape.Vertices, true);
				msh.Normals.CopyTo(shape.Normals, true);
				msh.TextureCoordinates.CopyTo(shape.TextureCoords, true);
				msh.Colors.CopyTo(shape.Colors, true);
				TriangleList triangleList = (TriangleList)mesh.CreateChild("SI_TriangleList");
				msh.FaceIndices.CopyTo(triangleList.Vertices, true);
				if (shape.Normals.Count > 0)
				{
					msh.FaceIndices.CopyTo(triangleList.Normals, true);
				}

				if (shape.TextureCoords.Count > 0)
				{
					msh.FaceIndices.CopyTo(triangleList.TextureCoords, true);
				}

				triangleList.MaterialName = msh.Material.Name;
				triangleList.PrimitiveName = ((Node)msh).Name;
			}
			else
			{
				Null @null = (Null)model2.CreateChild("SI_Null");
				@null.NullName = ((Node)msh).Name;
			}

			foreach (Mesh item in (NodeCollectionBase)msh.Childs)
			{
				Mesh msh2 = item;
				AddMesh(model2, msh2);
			}
		}

		private Light SetLight(Container model)
		{
			Light light = (Light)model.CreateChild("SI_Light");
			light.LightName = "light";
			return light;
		}

		private Camera SetCamera(Container model)
		{
			Model model2 = (Model)model.CreateChild("SI_Model");
			model2.ModelName = "Camera_Root";
			Transform transform = (Transform)model2.CreateChild("SI_Transform");
			transform.Type = Transform.Types.SRT;
			transform.ModelName = model2.ModelName;
			Visibility visibility = (Visibility)model2.CreateChild("SI_Visibility");
			visibility.State = Visibility.States.NotVisible;
			Null @null = (Null)model2.CreateChild("SI_Null");
			@null.NullName = model2.ModelName;
			return (Camera)model2.CreateChild("SI_Camera");
		}

		private Model PrepareModel(AsciiFile xsi)
		{
			Model model = (Model)xsi.Root.CreateChild("SI_Model");
			model.ModelName = "Mesh_Root";
			GlobalMaterial globalMaterial = (GlobalMaterial)model.CreateChild("SI_GlobalMaterial");
			globalMaterial.ReferencedMaterialName = scn.DefaultMaterial.Name;
			Transform transform = (Transform)model.CreateChild("SI_Transform");
			transform.Type = Transform.Types.SRT;
			transform.ModelName = model.ModelName;
			Visibility visibility = (Visibility)model.CreateChild("SI_Visibility");
			visibility.State = Visibility.States.Visible;
			return model;
		}

		private void AddMaterial(AsciiFile xsi, Scene s)
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Expected O, but got Unknown
			MaterialLibrary materialLibrary = (MaterialLibrary)xsi.Root.CreateChild("SI_MaterialLibrary");
			materialLibrary.SceneName = s.SceneName;
			foreach (Ambertation.Scenes.Material item in scn.MaterialCollection)
			{
				Ambertation.Scenes.Material val = item;
				Ambertation.XSI.Template.Material material = (Ambertation.XSI.Template.Material)materialLibrary.Materials.CreateChild("SI_Material");
				material.Diffuse = val.Diffuse;
				material.Emmissive = val.Emmissive;
				material.Ambient = val.Ambient;
				material.Specular = val.Specular;
				material.SpecularPower = val.SpecularPower;
				material.MaterialName = val.Name;
				if (val.Texture.Available)
				{
					Texture2D texture2D = (Texture2D)material.Textures.CreateChild("SI_Texture2D");
					texture2D.TextureName = val.Name;
					texture2D.ImageFileName = val.Texture.FileName;
					texture2D.ImageDimension = val.Texture.Size;
					texture2D.UVCropMax.U = val.Texture.Size.Width - 1;
					texture2D.UVCropMax.V = val.Texture.Size.Height - 1;
				}
			}
		}

		private Scene AddMeta(AsciiFile xsi)
		{
			_ = (FileInfo)xsi.Root.CreateChild("SI_FileInfo");
			Scene result = (Scene)xsi.Root.CreateChild("SI_Scene");
			_ = (CoordinateSystem)xsi.Root.CreateChild("SI_CoordinateSystem");
			Angle angle = (Angle)xsi.Root.CreateChild("SI_Angle");
			angle.Representation = Angle.Representations.Degrees;
			_ = (Ambience)xsi.Root.CreateChild("SI_Ambience");
			return result;
		}
	}
}
