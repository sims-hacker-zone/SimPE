// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for cTagExtension.
	/// </summary>
	public class TagExtension : AbstractRcolBlock
	{
		#region Attributes
		string en;
		uint eid;
		uint ever;

		public string Name
		{
			get; set;
		}
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public TagExtension(Rcol parent)
			: base(parent)
		{
			en = "cExtension";
			eid = 0;
			ever = 3;
			BlockID = 0x9a809646;
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

			en = reader.ReadString();
			eid = reader.ReadUInt32();
			ever = reader.ReadUInt32();
			Name = reader.ReadString();
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

			writer.Write(en);
			writer.Write(eid);
			writer.Write(ever);
			writer.Write(Name);
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

		#region IDisposable Member

		public override void Dispose()
		{
			tGenericRcol?.Dispose();

			tGenericRcol = null;
		}

		#endregion
	}
}
