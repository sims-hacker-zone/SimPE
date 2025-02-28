// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for cGeometryNode.
	/// </summary>
	public class ViewerRefNode : AbstractRcolBlock
	{
		#region Attributes
		ViewerRefNodeBase vrnb;
		RenderableNode rn;
		BoundedNode bn;
		TransformNode tn;

		public short Unknown1
		{
			get; set;
		}

		public string[] Names
		{
			get; set;
		}

		public byte[] Unknown2
		{
			get; set;
		}

		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public ViewerRefNode(Rcol parent)
			: base(parent)
		{
			vrnb = new ViewerRefNodeBase(null);
			rn = new RenderableNode(null);
			bn = new BoundedNode(null);
			tn = new TransformNode(null);

			Names = new string[0];
			Unknown2 = new byte[0xA0];

			version = 0x0c;
			BlockID = 0x7BA3838C;
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
			vrnb.Unserialize(reader);
			vrnb.BlockID = myid;

			name = reader.ReadString();
			myid = reader.ReadUInt32();
			rn.Unserialize(reader);
			rn.BlockID = myid;

			name = reader.ReadString();
			myid = reader.ReadUInt32();
			bn.Unserialize(reader);
			bn.BlockID = myid;

			name = reader.ReadString();
			myid = reader.ReadUInt32();
			tn.Unserialize(reader);
			tn.BlockID = myid;

			Unknown1 = reader.ReadInt16();
			Names = new string[reader.ReadInt32()];
			for (int i = 0; i < Names.Length; i++)
			{
				Names[i] = reader.ReadString();
			}

			Unknown2 = reader.ReadBytes(0xA0);
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

			writer.Write(vrnb.BlockName);
			writer.Write(vrnb.BlockID);
			vrnb.Serialize(writer);

			writer.Write(rn.BlockName);
			writer.Write(rn.BlockID);
			rn.Serialize(writer);

			writer.Write(bn.BlockName);
			writer.Write(bn.BlockID);
			bn.Serialize(writer);

			writer.Write(tn.BlockName);
			writer.Write(tn.BlockID);
			tn.Serialize(writer);

			writer.Write(Unknown1);
			writer.Write(Names.Length);
			for (int i = 0; i < Names.Length; i++)
			{
				writer.Write(Names[i]);
			}

			writer.Write(Unknown2);
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
			vrnb.AddToTabControl(tc);
			rn.AddToTabControl(tc);
			bn.AddToTabControl(tc);
			tn.AddToTabControl(tc);
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
