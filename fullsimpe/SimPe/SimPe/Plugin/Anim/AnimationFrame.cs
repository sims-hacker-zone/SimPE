/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
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
			this.Type = tp;
			Blocks = new AnimationAxisTransform[3];
		}

		internal AnimationAxisTransform[] Blocks
		{
			get;
		}

		public AnimationAxisTransform XBlock
		{
			get
			{
				return Blocks[0];
			}
			set
			{
				Blocks[0] = value;
			}
		}

		public AnimationAxisTransform YBlock
		{
			get
			{
				return Blocks[1];
			}
			set
			{
				Blocks[1] = value;
			}
		}

		public AnimationAxisTransform ZBlock
		{
			get
			{
				return Blocks[2];
			}
			set
			{
				Blocks[2] = value;
			}
		}

		AnimationAxisTransform GetFrameAddonData(int part)
		{
			AnimationAxisTransform b = GetBlock((byte)(part % 3));

			if (b == null)
			{
				return new AnimationAxisTransform(null, -1);
			}

			return b;
		}

		public AnimationAxisTransform GetBlock(byte nr)
		{
			return Blocks[nr];
		}

		[
			DescriptionAttribute("The X Value for this Transformation"),
			CategoryAttribute("Data"),
			DefaultValueAttribute(0)
		]
		public short X
		{
			get
			{
				return GetFrameAddonData(0).Parameter;
			}
			set
			{
				GetFrameAddonData(0).Parameter = value;
			}
		}

		[
			DescriptionAttribute("The Y Value for this Transformation"),
			CategoryAttribute("Data"),
			DefaultValueAttribute(0)
		]
		public short Y
		{
			get
			{
				return GetFrameAddonData(1).Parameter;
			}
			set
			{
				GetFrameAddonData(1).Parameter = value;
			}
		}

		[
			DescriptionAttribute("The Z Value for this Transformation"),
			CategoryAttribute("Data"),
			DefaultValueAttribute(0)
		]
		public short Z
		{
			get
			{
				return GetFrameAddonData(2).Parameter;
			}
			set
			{
				GetFrameAddonData(2).Parameter = value;
			}
		}

		[
			DescriptionAttribute(
				"The X Value (as Floating Point) for this Transformation"
			),
			CategoryAttribute("Data"),
			DefaultValueAttribute(0)
		]
		public float Float_X
		{
			get
			{
				return GetFrameAddonData(0).ParameterFloat;
			}
			set
			{
				GetFrameAddonData(0).ParameterFloat = value;
			}
		}

		[
			DescriptionAttribute(
				"The Y Value (as Floating Point) for this Transformation"
			),
			CategoryAttribute("Data"),
			DefaultValueAttribute(0)
		]
		public float Float_Y
		{
			get
			{
				return GetFrameAddonData(1).ParameterFloat;
			}
			set
			{
				GetFrameAddonData(1).ParameterFloat = value;
			}
		}

		[
			DescriptionAttribute(
				"The Z Value (as Floating Point) for this Transformation"
			),
			CategoryAttribute("Data"),
			DefaultValueAttribute(0)
		]
		public float Float_Z
		{
			get
			{
				return GetFrameAddonData(2).ParameterFloat;
			}
			set
			{
				GetFrameAddonData(2).ParameterFloat = value;
			}
		}

		[
			DescriptionAttribute(
				"The TimeCode the X Transformation should be finished"
			),
			CategoryAttribute("Data"),
			DefaultValueAttribute(0)
		]
		public short TimeCode
		{
			get
			{
				return tc;
			}
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
			DescriptionAttribute(
				"True if Frames are interpolated linear fro this KeyFrame"
			),
			CategoryAttribute("Data"),
			DefaultValueAttribute(false)
		]
		public bool Linear
		{
			get
			{
				if (Blocks[0] != null)
				{
					return Blocks[0].Linear;
				}

				if (Blocks[1] != null)
				{
					return Blocks[1].Linear;
				}

				if (Blocks[2] != null)
				{
					return Blocks[2].Linear;
				}

				return false;
			}
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
			get
			{
				return GetFrameAddonData(0).Unknown1;
			}
			set
			{
				GetFrameAddonData(0).Unknown1 = value;
			}
		}

		public short Unknown1_Y
		{
			get
			{
				return GetFrameAddonData(1).Unknown1;
			}
			set
			{
				GetFrameAddonData(1).Unknown1 = value;
			}
		}

		public short Unknown1_Z
		{
			get
			{
				return GetFrameAddonData(2).Unknown1;
			}
			set
			{
				GetFrameAddonData(2).Unknown1 = value;
			}
		}

		public short Unknown2_X
		{
			get
			{
				return GetFrameAddonData(0).Unknown2;
			}
			set
			{
				GetFrameAddonData(0).Unknown2 = value;
			}
		}

		public short Unknown2_Y
		{
			get
			{
				return GetFrameAddonData(1).Unknown2;
			}
			set
			{
				GetFrameAddonData(1).Unknown2 = value;
			}
		}

		public short Unknown2_Z
		{
			get
			{
				return GetFrameAddonData(2).Unknown2;
			}
			set
			{
				GetFrameAddonData(2).Unknown2 = value;
			}
		}

		public override string ToString()
		{
			return tc.ToString();
		}

		[
			DescriptionAttribute("Data interpreted as Vector"),
			CategoryAttribute("Information"),
			DefaultValueAttribute(0x11BA05F0)
		]
		public Vector3f Vector
		{
			get
			{
				double x = this.Float_X;
				double y = this.Float_Y;
				double z = this.Float_Z;

				return new Vector3f(this.Float_X, this.Float_Y, this.Float_Z);
			}
		}

		[
			DescriptionAttribute(
				"What kind of Transformation is performed. You can changes this in the Parent Node!"
			),
			CategoryAttribute("Information")
		]
		public FrameType Type
		{
			get;
		}
	}
}
