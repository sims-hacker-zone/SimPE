// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.XSI.Template
{
	public sealed class Scene : ArgumentContainer
	{
		public enum Timing
		{
			FRAMES,
			SECONDS
		}

		private Timing t;

		private double start;

		private double stop;

		private double rate;

		public string SceneName
		{
			get
			{
				return base.Argument1;
			}
			set
			{
				base.Argument1 = value;
			}
		}

		public double Start
		{
			get
			{
				return start;
			}
			set
			{
				start = value;
			}
		}

		public double Stop
		{
			get
			{
				return stop;
			}
			set
			{
				stop = value;
			}
		}

		public double FrameRate
		{
			get
			{
				return rate;
			}
			set
			{
				rate = value;
			}
		}

		public Timing TimingType
		{
			get
			{
				return t;
			}
			set
			{
				t = value;
			}
		}

		public Scene(Container parent, string args)
			: base(parent, args)
		{
			start = 1.0;
			stop = 100.0;
			rate = 24.0;
			t = Timing.FRAMES;
			ResetArgs();
		}

		protected override void ResetArgs()
		{
			ResetArgs("Scene");
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			ResetArgs();
			t = (Timing)EnumValue(0, typeof(Timing));
			start = Line(1).GetFloat(0);
			stop = Line(2).GetFloat(0);
			rate = Line(3).GetFloat(0);
			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			Clear(rec: false);
			AddLiteral("\"" + t.ToString() + "\"");
			AddLiteral(start);
			AddLiteral(stop);
			AddLiteral(rate);
		}
	}
}
