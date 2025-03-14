// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for cTSFaceGeometryBuilder.
	/// </summary>
	public class TSFaceGeometryBuilder : AbstractRcolBlock
	{
		#region Attributes
		GeometryBuilder gb;

		public int Unknown1
		{
			get; set;
		}

		public byte Unknown2
		{
			get; set;
		}

		public int Unknown3
		{
			get; set;
		}

		public List<TSFaceGeometryBuilderItem> Items
		{
			get;
		}
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public TSFaceGeometryBuilder(Rcol parent)
			: base(parent)
		{
			gb = new GeometryBuilder(null);
			BlockID = 0x2b70b86e;

			Items = new List<TSFaceGeometryBuilderItem>();
		}

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public override void Unserialize(System.IO.BinaryReader reader)
		{
			version = reader.ReadUInt32();

			string name = reader.ReadString();
			uint myid = reader.ReadUInt32();
			gb.Unserialize(reader);
			gb.BlockID = myid;

			Unknown1 = reader.ReadInt32();
			Unknown2 = reader.ReadByte();
			Unknown3 = reader.ReadInt32();

			for (int i = 0; i < 10; i++)
			{
				TSFaceGeometryBuilderItem o = new TSFaceGeometryBuilderItem();
				o.Unserialize(reader);
				if (Items.Count <= i)
				{
					Items.Add(o);
				}
				else
				{
					Items[i] = o;
				}
			}
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

			writer.Write(gb.BlockName);
			writer.Write(gb.BlockID);
			gb.Serialize(writer);

			writer.Write(Unknown1);
			writer.Write(Unknown2);
			writer.Write(Unknown3);

			for (int i = 0; i < 10; i++)
			{
				if (i < Items.Count)
				{
					Items[i].Serialize(writer);
				}
				else
				{
					TSFaceGeometryBuilderItem o = new TSFaceGeometryBuilderItem();
					o.Serialize(writer);
				}
			}
		}

		//fShapeRefNode form = null;
		TabPage.GenericRcol tGenericRcol;
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (tGenericRcol == null)
				{
					tGenericRcol = new TabPage.GenericRcol();
				}

				return tGenericRcol;
			}
		}
		#endregion

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			if (tGenericRcol == null)
			{
				tGenericRcol = new TabPage.GenericRcol();
			}

			tGenericRcol.tb_ver.Text = "0x" + Helper.HexString(version);
			tGenericRcol.gen_pg.SelectedObject = this;
		}

		public override void ExtendTabControl(System.Windows.Forms.TabControl tc)
		{
			base.ExtendTabControl(tc);
			gb.AddToTabControl(tc);
		}

		#region IDisposable Member

		public override void Dispose()
		{
			tGenericRcol?.Dispose();

			tGenericRcol = null;
		}

		#endregion
	}
}
