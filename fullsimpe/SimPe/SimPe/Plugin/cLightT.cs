// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// this is basicall te same as StandardLightBase
	/// </summary>
	public class LightT : StandardLightBase, System.IDisposable
	{
		#region Attributes

		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public LightT(Rcol parent)
			: base(parent)
		{
			version = 11;
			BlockID = 0;

			sgres = new SGResource(null);
		}

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public override void Unserialize(System.IO.BinaryReader reader)
		{
			version = reader.ReadUInt32();

			sgres.BlockName = reader.ReadString();
			sgres.BlockID = reader.ReadUInt32();
			sgres.Unserialize(reader);
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

			writer.Write(sgres.BlockName);
			writer.Write(sgres.BlockID);
			sgres.Serialize(writer);
		}

		TabPage.LightT tLightT;
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (tLightT == null)
				{
					tLightT = new TabPage.LightT();
				}

				return tLightT;
			}
		}
		#endregion

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			if (tLightT == null)
			{
				tLightT = new TabPage.LightT();
			}

			tLightT.tb_lt_ver.Text = "0x" + Helper.HexString(version);
			tLightT.tb_lt_name.Text = sgres.FileName;
		}

		#region IDisposable Member

		public override void Dispose()
		{
			tLightT?.Dispose();

			tLightT = null;
		}

		#endregion
	}
}
