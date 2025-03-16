// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Data;
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for StandardLightBase.
	/// </summary>
	public class SpotLight : PointLight
	{
		#region Attributes
		public float Val8
		{
			get; set;
		}

		public float Val9
		{
			get; set;
		}

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public SpotLight(Rcol parent)
			: base(parent)
		{
			version = 1;
			BlockID = (uint)FileTypes.LSPT;
		}

		public override void Unserialize(System.IO.BinaryReader reader)
		{
			base.Unserialize(reader);
			Val8 = reader.ReadSingle();
			Val9 = reader.ReadSingle();
		}

		public override void Serialize(System.IO.BinaryWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Val8);
			writer.Write(Val9);
		}

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			base.InitTabPage();
		}
	}
}
