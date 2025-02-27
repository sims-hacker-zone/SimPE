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
using System.Collections;
using System.ComponentModel;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// contains an Animation Ressource
	/// </summary>
	public class AnimResourceConst : AbstractRcolBlock
	{
		#region Attributes

		internal byte[] Data
		{
			get; set;
		}

		[DescriptionAttribute("The Time the Animation takes to play (probably in ms)")]
		public short TotalTime
		{
			get; set;
		}

		public Ambertation.BaseChangeShort B_Unknown1 => new Ambertation.BaseChangeShort(TotalTime);

		[DescriptionAttribute("Index 0 and 5 contain string Lengths.")]
		public byte[] HeaderBytes
		{
			get; private set;
		}

		public uint[] HeaderInts
		{
			get;
		}

		public float[] HeaderFloats
		{
			get;
		}

		public string ObjName
		{
			get; private set;
		}

		public string ObjMod
		{
			get; private set;
		}

		[Browsable(false)]
		public AnimationMeshBlock[] MeshBlock
		{
			get; private set;
		}

		AnimBlock6[] ab6;
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public AnimResourceConst(Rcol parent)
			: base(parent)
		{
			sgres = new SGResource(null);
			Data = new byte[0];
			BlockID = 0xfb00791e;

			HeaderBytes = new byte[6];
			HeaderInts = new uint[4];
			HeaderFloats = new float[9];

			ObjName = "";
			ObjMod = "";

			MeshBlock = new AnimationMeshBlock[0];
			ab6 = new AnimBlock6[0];
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
			sgres.Unserialize(reader);
			sgres.BlockID = myid;

			int len = reader.ReadInt32();
			byte[] data = reader.ReadBytes(len);

			//now read the Data
			System.IO.BinaryReader br = new System.IO.BinaryReader(
				new System.IO.MemoryStream(data)
			);
			UnserializeData(br);
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

			//now read the Data
			System.IO.BinaryWriter bw = new System.IO.BinaryWriter(
				new System.IO.MemoryStream()
			);
			SerializeData(bw);
			byte[] data = ((System.IO.MemoryStream)bw.BaseStream).ToArray();

			writer.Write((int)data.Length);
			writer.Write(data);
		}

		#region Alignment
		/// <summary>
		/// Calulates how many bytes we need to align the Stream
		/// </summary>
		/// <param name="ct">NUmber of bytes written</param>
		/// <returns>Number of Bytes needed to align</returns>
		static int Align(int ct)
		{
			int add = 0;
			if (ct % 2 == 0) //even
			{
				add = (ct % 4);
			}
			else //uneven
			{
				add = ct % 2;
				if (((add + ct) % 4) == 0)
				{
					add += 2;
				}
			}

			return add;
		}

		/// <summary>
		/// Make sure the String Data is alligned
		/// </summary>
		/// <param name="reader">The reader you want to align</param>
		/// <param name="ct">Number of Characters that were read (including terminating 0)</param>
		static void Align(System.IO.BinaryReader reader, int ct)
		{
			int add = Align(ct);
			for (int i = 0; i < add; i++)
			{
				reader.ReadByte();
			}
		}

		/// <summary>
		/// Make sure the String Data is alligned
		/// </summary>
		/// <param name="reader">The reader you want to align</param>
		/// <param name="ct">Number of Characters that were read (including terminating 0)</param>
		static void Align(System.IO.BinaryWriter writer, int ct)
		{
			int add = Align(ct);
			for (int i = 0; i < add; i++)
			{
				writer.Write((byte)i);
			}
		}
		#endregion

		public void UnserializeData(System.IO.BinaryReader reader)
		{
			TotalTime = reader.ReadInt16();
			short ct1 = reader.ReadInt16();
			short ct2 = reader.ReadInt16();

			HeaderBytes = reader.ReadBytes(HeaderBytes.Length);
			for (int i = 0; i < HeaderInts.Length; i++)
			{
				HeaderInts[i] = reader.ReadUInt32();
			}

			for (int i = 0; i < HeaderFloats.Length; i++)
			{
				HeaderFloats[i] = reader.ReadSingle();
			}

			ObjName = Helper.ToString(reader.ReadBytes(HeaderBytes[5]));
			reader.ReadByte(); //read the terminating 0
			ObjMod = Helper.ToString(reader.ReadBytes(HeaderBytes[0]));
			reader.ReadByte(); //read the terminating 0

			int ct = HeaderBytes[0] + HeaderBytes[5];
			Align(reader, ct + 2);

			//--- part1 ---
			MeshBlock = new AnimationMeshBlock[ct1];
			int len = 0;
			for (int i = 0; i < MeshBlock.Length; i++)
			{
				MeshBlock[i] = new AnimationMeshBlock(this.Parent);
				MeshBlock[i].UnserializeData(reader);
			}
			for (int i = 0; i < MeshBlock.Length; i++)
			{
				len += MeshBlock[i].UnserializeName(reader);
			}

			Align(reader, len);

			//--- part2 ---
			len = 0;
			for (int i = 0; i < MeshBlock.Length; i++)
			{
				MeshBlock[i].UnserializePart2Data(reader);
			}

			for (int i = 0; i < MeshBlock.Length; i++)
			{
				len += MeshBlock[i].UnserializePart2Name(reader);
			}

			Align(reader, len);

			try
			{
				//--- part3 ---
				for (int i = 0; i < MeshBlock.Length; i++)
				{
					MeshBlock[i].UnserializePart3Data(reader);
				}

				for (int i = 0; i < MeshBlock.Length; i++)
				{
					MeshBlock[i].UnserializePart3AddonData(reader);
				}

				//--- part4 ---
				for (int i = 0; i < MeshBlock.Length; i++)
				{
					MeshBlock[i].UnserializePart4Data(reader);
				}

				//--- part5 ---
				for (int i = 0; i < MeshBlock.Length; i++)
				{
					MeshBlock[i].UnserializePart5Data(reader);
				}

				//--- part6 ---
				ab6 = new AnimBlock6[ct2];
				len = 0;
				for (int i = 0; i < ab6.Length; i++)
				{
					ab6[i] = new AnimBlock6();
					ab6[i].UnserializeData(reader);
				}
				for (int i = 0; i < ab6.Length; i++)
				{
					len += ab6[i].UnserializeName(reader);
				}
			}
			catch { }

			Data = reader.ReadBytes(
				(int)(reader.BaseStream.Length - reader.BaseStream.Position)
			);
		}

		public void SerializeData(System.IO.BinaryWriter writer)
		{
			writer.Write(TotalTime);
			writer.Write((short)MeshBlock.Length);
			writer.Write((short)ab6.Length);

			writer.Write(HeaderBytes);

			//write lengths to the Header
			byte[] bobjname = Helper.ToBytes(ObjName);
			byte[] bobjmod = Helper.ToBytes(ObjMod);
			HeaderBytes[0] = (byte)bobjmod.Length;
			HeaderBytes[5] = (byte)bobjname.Length;

			for (int i = 0; i < HeaderInts.Length; i++)
			{
				writer.Write(HeaderInts[i]);
			}

			for (int i = 0; i < HeaderFloats.Length; i++)
			{
				writer.Write(HeaderFloats[i]);
			}

			foreach (byte b in bobjname)
			{
				writer.Write(b);
			}

			writer.Write((byte)0);
			foreach (byte b in bobjmod)
			{
				writer.Write(b);
			}

			writer.Write((byte)0);

			int ct = HeaderBytes[0] + HeaderBytes[5];
			Align(writer, ct + 2);

			//--- part1 ---
			int len = 0;
			for (int i = 0; i < MeshBlock.Length; i++)
			{
				MeshBlock[i].SerializeData(writer);
			}

			for (int i = 0; i < MeshBlock.Length; i++)
			{
				len += MeshBlock[i].SerializeName(writer);
			}

			Align(writer, len);

			//--- part2 ---
			len = 0;
			for (int i = 0; i < MeshBlock.Length; i++)
			{
				MeshBlock[i].SerializePart2Data(writer);
			}

			for (int i = 0; i < MeshBlock.Length; i++)
			{
				len += MeshBlock[i].SerializePart2Name(writer);
			}

			Align(writer, len);

			//--- part3 ---
			for (int i = 0; i < MeshBlock.Length; i++)
			{
				MeshBlock[i].SerializePart3Data(writer);
			}

			for (int i = 0; i < MeshBlock.Length; i++)
			{
				MeshBlock[i].SerializePart3AddonData(writer);
			}

			//--- part4 ---
			for (int i = 0; i < MeshBlock.Length; i++)
			{
				MeshBlock[i].SerializePart4Data(writer);
			}

			//--- part5 ---
			for (int i = 0; i < MeshBlock.Length; i++)
			{
				MeshBlock[i].SerializePart5Data(writer);
			}

			//--- part6 ---
			for (int i = 0; i < ab6.Length; i++)
			{
				ab6[i].SerializeData(writer);
			}

			for (int i = 0; i < ab6.Length; i++)
			{
				ab6[i].SerializeName(writer);
			}

			writer.Write(Data);
		}

		fAnimResourceConst form = null;

		[BrowsableAttribute(false)]
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (form == null)
				{
					form = new fAnimResourceConst();
				}

				return form.tMesh;
			}
		}
		#endregion

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			if (form == null)
			{
				form = new fAnimResourceConst();
			}

			form.tv.Nodes.Clear();
			System.Windows.Forms.TreeNode btn = new System.Windows.Forms.TreeNode(
				"Header"
			);
			btn.Tag = this;
			form.tv.Nodes.Add(btn);
			// can get a null reference exception here, it seems some AnimationMeshBlocks may not be readable
			foreach (AnimationMeshBlock ab in this.MeshBlock)
			{
				try
				{
					System.Windows.Forms.TreeNode tn =
						new System.Windows.Forms.TreeNode(ab.ToString());
					tn.Tag = ab;
					form.tv.Nodes.Add(tn);

					foreach (AnimationFrameBlock ab2 in ab.Part2)
					{
						System.Windows.Forms.TreeNode tn2 =
							new System.Windows.Forms.TreeNode(ab2.ToString());
						tn2.Tag = ab2;
						tn.Nodes.Add(tn2);
						foreach (AnimationAxisTransformBlock ab3 in ab2.AxisSet)
						{
							System.Windows.Forms.TreeNode tn3 =
								new System.Windows.Forms.TreeNode(ab3.ToString());
							tn3.Tag = ab3;
							tn2.Nodes.Add(tn3);

							foreach (AnimationAxisTransform ab4 in ab3)
							{
								System.Windows.Forms.TreeNode tn4 =
									new System.Windows.Forms.TreeNode(ab4.ToString());
								tn4.Tag = ab4;
								tn3.Nodes.Add(tn4);
							}
						}

						//Add a FrameList
						if (ab2.FrameCount > 0)
						{
							System.Windows.Forms.TreeNode frames =
								new System.Windows.Forms.TreeNode("Frames");
							tn2.Nodes.Add(frames);
							AnimationFrame[] afs = ab2.Frames;

							for (int i = 0; i < afs.Length; i++)
							{
								AnimationFrame af = afs[i];
								System.Windows.Forms.TreeNode tnf =
									new System.Windows.Forms.TreeNode(af.ToString());
								tnf.Tag = af;
								frames.Nodes.Add(tnf);
							}
							frames.Tag = afs;
						}

						//Add a FrameList
						if (ab2.FrameCount > 0 && (UserVerification.HaveUserId))
						{
							System.Windows.Forms.TreeNode frames =
								new System.Windows.Forms.TreeNode(
									"Interpolated Frames"
								);
							tn2.Nodes.Add(frames);
							AnimationFrame[] afs = ab2.InterpolateMissingFrames();

							for (int i = 0; i < afs.Length; i++)
							{
								AnimationFrame af = afs[i];
								System.Windows.Forms.TreeNode tnf =
									new System.Windows.Forms.TreeNode(af.ToString());
								tnf.Tag = af;
								frames.Nodes.Add(tnf);
							}
							frames.Tag = afs;
						}
					}

					foreach (AnimBlock4 ab4 in ab.Part4)
					{
						System.Windows.Forms.TreeNode tn4 =
							new System.Windows.Forms.TreeNode(ab4.ToString());
						tn4.Tag = ab4;
						tn.Nodes.Add(tn4);
						foreach (AnimBlock5 ab5 in ab4.Part5)
						{
							System.Windows.Forms.TreeNode tn5 =
								new System.Windows.Forms.TreeNode(ab5.ToString());
							tn5.Tag = ab5;
							tn4.Nodes.Add(tn5);
						}
					}
				}
				catch
				{
					btn.Text = "Header (faulty)";
				}
			}

			foreach (AnimBlock6 ab in this.ab6)
			{
				System.Windows.Forms.TreeNode tn = new System.Windows.Forms.TreeNode(
					ab.ToString()
				);
				tn.Tag = ab;
				form.tv.Nodes.Add(tn);
			}

			form.tb_arc_ver.Tag = true;
			form.tb_arc_ver.Text = "0x" + Helper.HexString(this.version);
			form.tb_arc_ver.Tag = null;

			form.ambc.MeshBlocks = this.MeshBlock;
		}

		public override void ExtendTabControl(System.Windows.Forms.TabControl tc)
		{
			if (form == null)
			{
				form = new fAnimResourceConst();
			}

			base.ExtendTabControl(tc);

			form.tMisc.Tag = this;
			tc.TabPages.Add(form.tMisc);

			form.tAnimResourceConst.Tag = this;
			if (UserVerification.HaveUserId)
			{
				tc.TabPages.Add(form.tAnimResourceConst);
			}
		}

		#region IDisposable Member

		public override void Dispose()
		{
			if (this.form != null)
			{
				this.form.Dispose();
			}
		}

		#endregion
	}
}
