// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.ComponentModel;

namespace Ambertation.Windows.Forms
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class NCResizeBorders
	{
		private bool left;

		private bool right;

		private bool top;

		private bool bottom;

		public bool Left
		{
			get
			{
				return left;
			}
			set
			{
				left = value;
			}
		}

		public bool Right
		{
			get
			{
				return right;
			}
			set
			{
				right = value;
			}
		}

		public bool Top
		{
			get
			{
				return top;
			}
			set
			{
				top = value;
			}
		}

		public bool Bottom
		{
			get
			{
				return bottom;
			}
			set
			{
				bottom = value;
			}
		}

		public NCResizeBorders()
			: this(l: false, t: false, r: true, b: true)
		{
		}

		public NCResizeBorders(bool l, bool t, bool r, bool b)
		{
			left = l;
			top = t;
			right = r;
			bottom = b;
		}

		public void SetAll(bool val)
		{
			bottom = val;
			top = val;
			left = val;
			right = val;
		}

		public override string ToString()
		{
			string text = "";
			if (Left)
			{
				text += "[Left] ";
			}

			if (Bottom)
			{
				text += "[Bottom] ";
			}

			if (Top)
			{
				text += "[Top] ";
			}

			if (Right)
			{
				text += "[Right] ";
			}

			text = text.Trim();
			if (text == "")
			{
				text = "[None]";
			}

			return text;
		}
	}
}
