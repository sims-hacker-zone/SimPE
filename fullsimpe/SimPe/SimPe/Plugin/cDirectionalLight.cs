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
	public class DirectionalLight : AbstractRcolBlock
	{
		#region Attributes

		public StandardLightBase StandardLightBase
		{
			get; set;
		}

		public LightT LightT
		{
			get; set;
		}

		public ReferentNode ReferentNode
		{
			get; set;
		}

		public ObjectGraphNode ObjectGraphNode
		{
			get; set;
		}

		public string Name
		{
			get; set;
		}

		public float Val1
		{
			get; set;
		}

		public float Val2
		{
			get; set;
		}

		public float Red
		{
			get; set;
		}

		public float Green
		{
			get; set;
		}

		public float Blue
		{
			get; set;
		}

		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public DirectionalLight(Rcol parent)
			: base(parent)
		{
			version = 1;
			BlockID = 0xC9C81BA3;

			StandardLightBase = new StandardLightBase(null);
			sgres = new SGResource(null);
			LightT = new LightT(null);
			ReferentNode = new ReferentNode(null);
			ObjectGraphNode = new ObjectGraphNode(null);

			Name = "";
		}

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public override void Unserialize(System.IO.BinaryReader reader)
		{
			version = reader.ReadUInt32();

			StandardLightBase.BlockName = reader.ReadString();
			StandardLightBase.BlockID = reader.ReadUInt32();
			StandardLightBase.Unserialize(reader);

			sgres.BlockName = reader.ReadString();
			sgres.BlockID = reader.ReadUInt32();
			sgres.Unserialize(reader);

			LightT.BlockName = reader.ReadString();
			LightT.BlockID = reader.ReadUInt32();
			LightT.Unserialize(reader);

			ReferentNode.BlockName = reader.ReadString();
			ReferentNode.BlockID = reader.ReadUInt32();
			ReferentNode.Unserialize(reader);

			ObjectGraphNode.BlockName = reader.ReadString();
			ObjectGraphNode.BlockID = reader.ReadUInt32();
			ObjectGraphNode.Unserialize(reader);

			Name = reader.ReadString();
			Val1 = reader.ReadSingle();
			Val2 = reader.ReadSingle();
			Red = reader.ReadSingle();
			Green = reader.ReadSingle();
			Blue = reader.ReadSingle();
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(version);

			writer.Write(StandardLightBase.BlockName);
			writer.Write(StandardLightBase.BlockID);
			StandardLightBase.Serialize(writer);

			writer.Write(sgres.BlockName);
			writer.Write(sgres.BlockID);
			sgres.Serialize(writer);

			writer.Write(LightT.BlockName);
			writer.Write(LightT.BlockID);
			LightT.Serialize(writer);

			writer.Write(ReferentNode.BlockName);
			writer.Write(ReferentNode.BlockID);
			ReferentNode.Serialize(writer);

			writer.Write(ObjectGraphNode.BlockName);
			writer.Write(ObjectGraphNode.BlockID);
			ObjectGraphNode.Serialize(writer);

			writer.Write(Name);
			writer.Write(Val1);
			writer.Write(Val2);
			writer.Write(Red);
			writer.Write(Green);
			writer.Write(Blue);
		}

		protected TabPage.DirectionalLight tDirectionalLight;
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (tDirectionalLight == null)
				{
					tDirectionalLight = new SimPe.Plugin.TabPage.DirectionalLight();
				}

				return tDirectionalLight;
			}
		}
		#endregion

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			if (tDirectionalLight == null)
			{
				tDirectionalLight = new SimPe.Plugin.TabPage.DirectionalLight();
			}

			tDirectionalLight.tb_l_ver.Text = "0x" + Helper.HexString(this.version);
			tDirectionalLight.tb_l_name.Text = Name;

			tDirectionalLight.tb_l_1.Text = Val1.ToString();
			tDirectionalLight.tb_l_2.Text = Val2.ToString();
			tDirectionalLight.tb_l_3.Text = Red.ToString();
			tDirectionalLight.tb_l_4.Text = Green.ToString();
			tDirectionalLight.tb_l_5.Text = Blue.ToString();

			tDirectionalLight.label39.Visible = false;
			tDirectionalLight.label44.Visible = false;
			tDirectionalLight.label45.Visible = false;
			tDirectionalLight.label46.Visible = false;

			tDirectionalLight.tb_l_6.Visible = false;
			tDirectionalLight.tb_l_7.Visible = false;
			tDirectionalLight.tb_l_8.Visible = false;
			tDirectionalLight.tb_l_9.Visible = false;
		}

		public override void ExtendTabControl(System.Windows.Forms.TabControl tc)
		{
			base.ExtendTabControl(tc);
			this.StandardLightBase.AddToTabControl(tc);
			this.LightT.AddToTabControl(tc);
			this.ReferentNode.AddToTabControl(tc);
			this.ObjectGraphNode.AddToTabControl(tc);
		}

		#region IDisposable Member

		public override void Dispose()
		{
			if (this.tDirectionalLight != null)
			{
				this.tDirectionalLight.Dispose();
			}

			tDirectionalLight = null;
		}

		#endregion
	}
}
