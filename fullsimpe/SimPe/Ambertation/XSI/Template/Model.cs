// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using Ambertation.Scenes;

namespace Ambertation.XSI.Template
{
	public sealed class Model : JoinedArgumentContainer
	{
		public enum Types
		{
			MDL,
			SRT,
			BASEPOSE
		}

		public enum ContainedTypes
		{
			Mesh,
			Joint,
			Camera,
			SceneRoot
		}

		public ContainedTypes ContainedType => GetContainedType();

		public bool IsRoot => !(base.Parent is Model);

		public Types Type
		{
			get
			{
				return (Types)ExtendedContainer.EnumValue(typeof(Types), base.JoinedArgument1);
			}
			set
			{
				base.JoinedArgument1 = value.ToString();
			}
		}

		public string ModelName
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

		public Model(Container parent, string args)
			: base(parent, args)
		{
		}

		private ContainedTypes GetContainedType()
		{
			foreach (ITemplate child in childs)
			{
				if (child is Mesh)
				{
					return ContainedTypes.Mesh;
				}

				if (child is Camera)
				{
					return ContainedTypes.Camera;
				}
			}

			if (base[typeof(Null)] != null)
			{
				return ContainedTypes.Joint;
			}

			return ContainedTypes.SceneRoot;
		}

		protected override void ResetArgs()
		{
			base.ResetArgs("MDL", "Scene_Root");
		}

		protected override void CustomClear()
		{
		}

		internal override void ToScene(Ambertation.Scenes.Scene scn)
		{
			if (ContainedType == ContainedTypes.Joint)
			{
				JointToScene(scn);
			}

			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ITemplate template = (ITemplate)enumerator.Current;
					if (template is Mesh && template is Container)
					{
						((Container)template).ToScene(scn);
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}

			IEnumerator enumerator2 = GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					ITemplate template2 = (ITemplate)enumerator2.Current;
					if (template2 is Model && ((Model)template2).ContainedType == ContainedTypes.SceneRoot)
					{
						((Model)template2).ToScene(scn);
					}
				}
			}
			finally
			{
				IDisposable disposable2 = enumerator2 as IDisposable;
				if (disposable2 != null)
				{
					disposable2.Dispose();
				}
			}

			IEnumerator enumerator3 = GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					ITemplate template3 = (ITemplate)enumerator3.Current;
					if (template3 is Model && ((Model)template3).ContainedType == ContainedTypes.Camera)
					{
						((Model)template3).ToScene(scn);
					}
				}
			}
			finally
			{
				IDisposable disposable3 = enumerator3 as IDisposable;
				if (disposable3 != null)
				{
					disposable3.Dispose();
				}
			}

			IEnumerator enumerator4 = GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					ITemplate template4 = (ITemplate)enumerator4.Current;
					if (template4 is Model && ((Model)template4).ContainedType == ContainedTypes.Joint)
					{
						((Model)template4).ToScene(scn);
					}
				}
			}
			finally
			{
				IDisposable disposable4 = enumerator4 as IDisposable;
				if (disposable4 != null)
				{
					disposable4.Dispose();
				}
			}

			IEnumerator enumerator5 = GetEnumerator();
			try
			{
				while (enumerator5.MoveNext())
				{
					ITemplate template5 = (ITemplate)enumerator5.Current;
					if (template5 is Model && ((Model)template5).ContainedType == ContainedTypes.Mesh)
					{
						((Model)template5).ToScene(scn);
					}
				}
			}
			finally
			{
				IDisposable disposable5 = enumerator5 as IDisposable;
				if (disposable5 != null)
				{
					disposable5.Dispose();
				}
			}

			IEnumerator enumerator6 = GetEnumerator();
			try
			{
				while (enumerator6.MoveNext())
				{
					ITemplate template6 = (ITemplate)enumerator6.Current;
					if (!(template6 is Model) && !(template6 is Mesh) && template6 is Container)
					{
						((Container)template6).ToScene(scn);
					}
				}
			}
			finally
			{
				IDisposable disposable6 = enumerator6 as IDisposable;
				if (disposable6 != null)
				{
					disposable6.Dispose();
				}
			}
		}

		private void JointToScene(Ambertation.Scenes.Scene scn)
		{
			Joint val = scn.RootJoint;
			if (!IsRoot)
			{
				Joint val2 = scn.RootJoint.FindJoint((base.Parent as Model).ModelName);
				if (val2 != null)
				{
					val = val2;
				}
			}

			Joint val3 = val.CreateChild(ModelName);
			Transform transform = FindTransform(this, Transform.Types.BASEPOSE);
			if (transform != null)
			{
				Transformation val4 = transform.ToSceneTransform();
				((Node)val3).WorldPosition.Translation = val4.Translation;
				((Node)val3).WorldPosition.Rotation = val4.Rotation;
				((Node)val3).WorldPosition.Scaling = val4.Scaling;
			}

			transform = FindTransform(this, Transform.Types.SRT);
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
