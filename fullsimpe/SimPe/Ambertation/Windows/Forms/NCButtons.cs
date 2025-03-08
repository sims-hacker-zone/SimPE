// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	public class NCButtons
	{
		private bool left;

		private bool right;

		private bool mid;

		internal bool LeftInt
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

		internal bool RightInt
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

		internal bool MiddleInt
		{
			get
			{
				return mid;
			}
			set
			{
				mid = value;
			}
		}

		public bool Left => left;

		public bool Right => right;

		public bool Middle => mid;

		internal MouseButtons ToMouseButtons()
		{
			if (Left)
			{
				return MouseButtons.Left;
			}

			if (Right)
			{
				return MouseButtons.Right;
			}

			if (Middle)
			{
				return MouseButtons.Middle;
			}

			return MouseButtons.None;
		}

		internal void Reset()
		{
			left = false;
			right = false;
			mid = false;
		}

		public override string ToString()
		{
			if (!Left && !Right && !Middle)
			{
				return "None";
			}

			string text = "";
			if (Left)
			{
				text += "Left ";
			}

			if (Right)
			{
				text += "Right ";
			}

			if (Middle)
			{
				text += "Middele ";
			}

			return text;
		}
	}
}
