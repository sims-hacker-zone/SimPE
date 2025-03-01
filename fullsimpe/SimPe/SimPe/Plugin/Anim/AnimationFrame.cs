// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.ComponentModel;

using SimPe.Geometry;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// Assembles the Data Read from the ANIM Resource in a Frame
	/// </summary>
	public class AnimationFrame
	{
		short tc;

		public AnimationFrame(short tc, FrameType tp)
		{
			this.tc = tc;
			Type = tp;
			Blocks = new AnimationAxisTransform[3];
		}

		internal AnimationAxisTransform[] Blocks
		{
			get;
		}

		public AnimationAxisTransform XBlock
		{
			get => Blocks[0];
			set => Blocks[0] = value;
		}

		public AnimationAxisTransform YBlock
		{
			get => Blocks[1];
			set => Blocks[1] = value;
		}

		public AnimationAxisTransform ZBlock
		{
			get => Blocks[2];
			set => Blocks[2] = value;
		}

		AnimationAxisTransform GetFrameAddonData(int part)
		{
			AnimationAxisTransform b = GetBlock((byte)(part % 3));

			return b ?? new AnimationAxisTransform(null, -1);
		}

		public AnimationAxisTransform GetBlock(byte nr)
		{
			return Blocks[nr];
		}

		[
			Description("The X Value for this Transformation"),
			Category("Data"),
			DefaultValue(0)
		]
		public short X
		{
			get => GetFrameAddonData(0).Parameter;
			set => GetFrameAddonData(0).Parameter = value;
		}

		[
			Description("The Y Value for this Transformation"),
			Category("Data"),
			DefaultValue(0)
		]
		public short Y
		{
			get => GetFrameAddonData(1).Parameter;
			set => GetFrameAddonData(1).Parameter = value;
		}

		[
			Description("The Z Value for this Transformation"),
			Category("Data"),
			DefaultValue(0)
		]
		public short Z
		{
			get => GetFrameAddonData(2).Parameter;
			set => GetFrameAddonData(2).Parameter = value;
		}

		[
			Description(
				"The X Value (as Floating Point) for this Transformation"
			),
			Category("Data"),
			DefaultValue(0)
		]
		public float Float_X
		{
			get => GetFrameAddonData(0).ParameterFloat;
			set => GetFrameAddonData(0).ParameterFloat = value;
		}

		[
			Description(
				"The Y Value (as Floating Point) for this Transformation"
			),
			Category("Data"),
			DefaultValue(0)
		]
		public float Float_Y
		{
			get => GetFrameAddonData(1).ParameterFloat;
			set => GetFrameAddonData(1).ParameterFloat = value;
		}

		[
			Description(
				"The Z Value (as Floating Point) for this Transformation"
			),
			Category("Data"),
			DefaultValue(0)
		]
		public float Float_Z
		{
			get => GetFrameAddonData(2).ParameterFloat;
			set => GetFrameAddonData(2).ParameterFloat = value;
		}

		[
			Description(
				"The TimeCode the X Transformation should be finished"
			),
			Category("Data"),
			DefaultValue(0)
		]
		public short TimeCode
		{
			get => tc;
			set
			{
				if (tc != value)
				{
					tc = value;
					if (Blocks[0] != null)
					{
						Blocks[0].TimeCode = value;
					}

					if (Blocks[1] != null)
					{
						Blocks[1].TimeCode = value;
					}

					if (Blocks[2] != null)
					{
						Blocks[2].TimeCode = value;
					}
				}
			}
		}

		[
			Description(
				"True if Frames are interpolated linear fro this KeyFrame"
			),
			Category("Data"),
			DefaultValue(false)
		]
		public bool Linear
		{
			get => Blocks[0] != null ? Blocks[0].Linear : Blocks[1] != null ? Blocks[1].Linear : Blocks[2] != null && Blocks[2].Linear;
			set
			{
				if (Blocks[0] != null)
				{
					Blocks[0].Linear = value;
				}

				if (Blocks[1] != null)
				{
					Blocks[1].Linear = value;
				}

				if (Blocks[2] != null)
				{
					Blocks[2].Linear = value;
				}
			}
		}

		public short Unknown1_X
		{
			get => GetFrameAddonData(0).Unknown1;
			set => GetFrameAddonData(0).Unknown1 = value;
		}

		public short Unknown1_Y
		{
			get => GetFrameAddonData(1).Unknown1;
			set => GetFrameAddonData(1).Unknown1 = value;
		}

		public short Unknown1_Z
		{
			get => GetFrameAddonData(2).Unknown1;
			set => GetFrameAddonData(2).Unknown1 = value;
		}

		public short Unknown2_X
		{
			get => GetFrameAddonData(0).Unknown2;
			set => GetFrameAddonData(0).Unknown2 = value;
		}

		public short Unknown2_Y
		{
			get => GetFrameAddonData(1).Unknown2;
			set => GetFrameAddonData(1).Unknown2 = value;
		}

		public short Unknown2_Z
		{
			get => GetFrameAddonData(2).Unknown2;
			set => GetFrameAddonData(2).Unknown2 = value;
		}

		public override string ToString()
		{
			return tc.ToString();
		}

		[
			Description("Data interpreted as Vector"),
			Category("Information"),
			DefaultValue(0x11BA05F0)
		]
		public Vector3f Vector
		{
			get
			{
				double x = Float_X;
				double y = Float_Y;
				double z = Float_Z;

				return new Vector3f(Float_X, Float_Y, Float_Z);
			}
		}

		[
			Description(
				"What kind of Transformation is performed. You can changes this in the Parent Node!"
			),
			Category("Information")
		]
		public FrameType Type
		{
			get;
		}
	}
}
