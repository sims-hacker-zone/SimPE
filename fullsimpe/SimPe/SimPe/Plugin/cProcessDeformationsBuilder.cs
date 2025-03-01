// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for cProcessDeformationsBuilder.
	/// </summary>
	public class ProcessDeformationsBuilder : AbstractRcolBlock
	{
		#region Attributes
		GeometryBuilder gb;
		Interfaces.Files.IPackedFileDescriptor pfd;

		public short Unknown1
		{
			get; set;
		}

		public int Unknown2
		{
			get; set;
		}
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public ProcessDeformationsBuilder(Rcol parent)
			: base(parent)
		{
			gb = new GeometryBuilder(null);
			BlockID = 0x5ce7e026;

			pfd = new Packages.PackedFileDescriptor();
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

			pfd.Group = reader.ReadUInt32();
			pfd.Instance = reader.ReadUInt32();
			if (Parent.Count == 0xffff0001)
			{
				pfd.SubType = reader.ReadUInt32();
			}

			pfd.Type = reader.ReadUInt32();

			Unknown1 = reader.ReadInt16();
			Unknown2 = reader.ReadInt32();
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

			writer.Write(pfd.Group);
			writer.Write(pfd.Instance);
			if (Parent.Count == 0xffff0001)
			{
				writer.Write(pfd.SubType);
			}

			writer.Write(pfd.Type);

			writer.Write(Unknown1);
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
