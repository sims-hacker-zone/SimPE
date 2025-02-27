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
using System.Collections;

using SimPe.Interfaces.Scenegraph;

namespace SimPe.Plugin
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class DataListExtension : AbstractRcolBlock, IScenegraphBlock
	{
		#region Attributes
		public Extension Extension
		{
			get;
		}

		#endregion




		/// <summary>
		/// Constructor
		/// </summary>
		public DataListExtension(Rcol parent)
			: base(parent)
		{
			Extension = new Extension(null);
			version = 0x01;
			BlockID = 0x6a836d56;
		}

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public override void Unserialize(System.IO.BinaryReader reader)
		{
			version = reader.ReadUInt32();
			string fldsc = reader.ReadString();
			uint myid = reader.ReadUInt32();

			Extension.Unserialize(reader, version);
			Extension.BlockID = myid;
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

			string name = Extension.Register(null);
			writer.Write(name);
			writer.Write(Extension.BlockID);
			Extension.Serialize(writer, version);
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
			Extension.AddToTabControl(tc);
			tc.SelectedIndex = tc.TabPages.Count - 1;
		}

		public override string ToString()
		{
			return Extension.VarName + " (" + base.ToString() + ")";
		}

		#region IScenegraphItem Member

		public void ReferencedItems(Hashtable refmap, uint parentgroup)
		{
			if (Extension.VarName.Trim().ToLower() == "tsmaterialsmeshname")
			{
				ArrayList list = new ArrayList();
				foreach (ExtensionItem ei in Extension.Items)
				{
					string name = ei.String.Trim();
					if (!name.ToLower().EndsWith("_cres"))
					{
						name += "_cres";
					}

					list.Add(
						ScenegraphHelper.BuildPfd(
							name,
							ScenegraphHelper.CRES,
							parentgroup
						)
					);
				}

				refmap["tsMaterialsMeshName"] = list;
			}
		}

		#endregion

		#region IDisposable Member

		public override void Dispose()
		{
			if (tGenericRcol != null)
			{
				tGenericRcol.Dispose();
			}

			tGenericRcol = null;
		}

		#endregion
	}
}
