// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for StandardLightBase.
	/// </summary>
	public class PointLight : DirectionalLight
	{
		#region Attributes
		public float Val6
		{
			get; set;
		}

		public float Val7
		{
			get; set;
		}

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public PointLight(Rcol parent)
			: base(parent)
		{
			version = 1;
			BlockID = 0xc9c81ba9;
		}

		public override void Unserialize(System.IO.BinaryReader reader)
		{
			base.Unserialize(reader);
			Val6 = reader.ReadSingle();
			Val7 = reader.ReadSingle();
		}

		public override void Serialize(System.IO.BinaryWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Val6);
			writer.Write(Val7);
		}

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			base.InitTabPage();
			tDirectionalLight.tb_l_6.Text = Val6.ToString();
			tDirectionalLight.tb_l_7.Text = Val7.ToString();

			tDirectionalLight.label39.Visible = true;
			tDirectionalLight.label44.Visible = true;

			tDirectionalLight.tb_l_6.Visible = true;
			tDirectionalLight.tb_l_7.Visible = true;
		}
	}
}
