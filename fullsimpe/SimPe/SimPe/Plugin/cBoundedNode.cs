// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for cBoundedNode.
	/// </summary>
	public class BoundedNode : AbstractRcolBlock
	{
		#region Attributes


		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public BoundedNode(Rcol parent)
			: base(parent)
		{
			version = 0x5;
			BlockID = 0;
		}

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public override void Unserialize(System.IO.BinaryReader reader)
		{
			version = reader.ReadUInt32();
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
