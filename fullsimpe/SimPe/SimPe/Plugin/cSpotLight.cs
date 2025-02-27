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
using System;

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
			BlockID = 0xc9c81bad;
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
			tDirectionalLight.tb_l_8.Text = Val8.ToString();
			tDirectionalLight.tb_l_9.Text = Val9.ToString();

			tDirectionalLight.label45.Visible = true;
			tDirectionalLight.label46.Visible = true;

			tDirectionalLight.tb_l_8.Visible = true;
			tDirectionalLight.tb_l_9.Visible = true;
		}
	}
}
