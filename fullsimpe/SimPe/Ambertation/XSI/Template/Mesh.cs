// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Ambertation.Scenes;

using SimPe.Plugin;

namespace Ambertation.XSI.Template
{
	public sealed class Mesh : JoinedArgumentContainer
	{
		public enum Types
		{
			Unknown,
			TriangleList
		}

		public string MeshName
		{
			get
			{
				return base.JoinedArgument2;
			}
			set
			{
				base.JoinedArgument2 = value;
			}
		}

		public Types Type => GetMeshType();

		public Mesh(Container parent, string args)
			: base(parent, args)
		{
		}

		protected override void ResetArgs()
		{
			base.ResetArgs("MSH", "Scene_Root");
		}

		protected override void CustomClear()
		{
		}

		private Types GetMeshType()
		{
			if (!(base.Parent is Model))
			{
				return Types.Unknown;
			}

			foreach (ITemplate child in childs)
			{
				if (child is TriangleList)
				{
					return Types.TriangleList;
				}
			}

			return Types.Unknown;
		}

		internal override void ToScene(Ambertation.Scenes.Scene scn)
		{
			Ambertation.Scenes.Mesh val = scn.SceneRoot;
			if (!((Model)base.Parent).IsRoot)
			{
				Ambertation.Scenes.Mesh val2 = scn.SceneRoot.FindMesh((base.Parent.Parent as Model).ModelName);
				if (val2 != null)
				{
					val = val2;
				}
			}

			if (Type != Types.TriangleList)
			{
				return;
			}

			Shape shape = base[typeof(Shape)] as Shape;
			TriangleList triangleList = base[typeof(TriangleList)] as TriangleList;
			if (shape != null && triangleList != null)
			{
				Ambertation.Scenes.Mesh val3 = val.CreateMesh(MeshName);
				val3.BuildData(shape.Vertices, shape.Normals, shape.TextureCoords, shape.Colors, triangleList.Vertices, triangleList.Normals, triangleList.TextureCoords, triangleList.Colors);
				val3.Material = scn.MaterialCollection[triangleList.MaterialName];
				Transform transform = FindTransform(base.Parent, Transform.Types.BASEPOSE);
				if (transform != null)
				{
					Transformation val4 = transform.ToSceneTransform();
					((Node)val3).WorldPosition.Translation = val4.Translation;
					((Node)val3).WorldPosition.Rotation = val4.Rotation;
					((Node)val3).WorldPosition.Scaling = val4.Scaling;
				}

				transform = FindTransform(base.Parent, Transform.Types.SRT);
				if (transform != null)
				{
					Transformation val5 = transform.ToSceneTransform();
					((Transformation)val3).Translation = val5.Translation;
					((Transformation)val3).Rotation = val5.Rotation;
					((Transformation)val3).Scaling = val5.Scaling;
				}
			}
		}
	}
}
