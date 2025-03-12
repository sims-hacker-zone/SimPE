// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.Numerics;

using SimPe.Extensions;
using SimPe.Plugin.Anim;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for AnimationData.
	/// </summary>
	class AnimationData
	{
		AnimationFrameBlock afb;
		Ambertation.Graphics.MeshBox mb;
		int fct;
		List<Vector3> frames;

		public AnimationData(
			AnimationFrameBlock afb,
			Ambertation.Graphics.MeshBox mb,
			int framecount
		)
		{
			//Console.WriteLine(mb.ToString());
			this.afb = afb;
			this.mb = mb;
			fct = framecount;
			frames = new List<Vector3>();

			AnimationFrame[] iframes = afb.Frames;

			/*scale = new SimPe.Geometry.Vector3f();
			scale.X = nb.Transform.TranslationVector.X / (float)iframes[0].X;
			scale.Y = nb.Transform.TranslationVector.Y / (float)iframes[0].Y;
			scale.Z = nb.Transform.TranslationVector.Z / (float)iframes[0].Z;*/

			AnimationFrameBlock afb2 = new AnimationFrameBlock(
				afb.Parent
			);
			for (int i = 0; i <= framecount; i++)
			{
				frames.Add(new Vector3());
			}

			InterpolateFrames(iframes, 0); //X-Axis
			InterpolateFrames(iframes, 1); //Y-Axis
			InterpolateFrames(iframes, 2); //Z-Axis
		}

		int FindNext(AnimationFrame[] frames, byte axis, int start)
		{
			for (int i = start; i < frames.Length; i++)
			{
				if (frames[i].GetBlock(axis) != null)
				{
					return i;
				}
			}

			return -1;
		}

		AnimationFrame GetFrame(AnimationFrame[] frames, int index)
		{
			return index < 0 || index >= frames.Length ? null : frames[index];
		}

		void InterpolateFrames(AnimationFrame[] iframes, byte axis)
		{
			int index = 0;
			AnimationFrame first = iframes[index];
			AnimationFrame last = null;
			index = FindNext(iframes, axis, index + 1);
			last = GetFrame(iframes, index);

			if (last == null)
			{
				return;
			}

			while (last != null)
			{
				InterpolateFrames(axis, first, last);

				first = last;
				index = FindNext(iframes, axis, index + 1);
				last = GetFrame(iframes, index);
			}

			InterpolateFrames(axis, first, last);
		}

		void InterpolateFrames(byte axis, AnimationFrame first, AnimationFrame last)
		{
			short max = (short)(frames.Count - 1);
			if (last != null)
			{
				max = last.TimeCode;
			}
			else
			{
				last = new AnimationFrame(max, first.Type)
				{
					X = first.X,
					Y = first.Y,
					Z = first.Z
				};
			}

			for (short i = first.TimeCode; i <= max; i++)
			{
				CreateInterpolatedFrame(axis, i, first, last);
			}
		}

		void CreateInterpolatedFrame(
			byte axis,
			short index,
			AnimationFrame first,
			AnimationFrame last
		)
		{
			float pos =
				(index - first.TimeCode) / (float)(last.TimeCode - first.TimeCode);
			float v = Interpolate(
				axis,
				pos,
				first.GetBlock(axis),
				last.GetBlock(axis)
			);

			frames[index] = frames[index].SetComponent(axis, v);
		}

		float Interpolate(
			byte axis,
			float pos,
			AnimationAxisTransform first,
			AnimationAxisTransform last
		)
		{
			float f = 0;
			if (first != null)
			{
				f = AnimationAxisTransformBlock.GetCompressedFloat(
					first.Parameter,
					AnimationAxisTransformBlock.GetScale(
						first.ParentLocked,
						afb.TransformationType
					)
				);
			}

			float l = f;
			if (last != null)
			{
				l = (float)
					AnimationAxisTransformBlock.GetCompressedFloat(
						last.Parameter,
						AnimationAxisTransformBlock.GetScale(
							last.ParentLocked,
							afb.TransformationType
						)
					);
			}

			return f + (pos * (l - f));
		}

		public void SetFrame(int timecode)
		{
			Vector3 v = frames[timecode];
			Ambertation.Scenes.Transformation trans =
				new Ambertation.Scenes.Transformation();
			if (afb.TransformationType == FrameType.Translation)
			{
				if (timecode != 0)
				{
					trans.Translation.X = v.X;
					trans.Translation.Y = v.Y;
					trans.Translation.Z = v.Z;
				}
				//else nb.Transform = mt;
			}
			else
			{
				if (timecode != 0)
				{
					trans.Rotation.X = v.X;
					trans.Rotation.Y = v.Y;
					trans.Rotation.Z = v.Z;
				}
			}

			//mb.Transform = Microsoft.DirectX.Matrix.Multiply(mb.Transform, Ambertation.Scenes.Converter.ToDx(trans));
			mb.Transform = Ambertation.Scenes.Converter.ToDx(trans);
		}
	}
}
