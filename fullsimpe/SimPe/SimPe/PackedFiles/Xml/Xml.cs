// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Xml
{
	/// <summary>
	/// Represents a PackedFile in XmlFormat
	/// </summary>
	public class Xml : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		/// <summary>
		/// The XML Text
		/// </summary>
		public string Text
		{
			get;
			set;
		}

		#region IWrapper Member
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo("Default XML Wrapper", "Quaxi", "---", 1);
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new XmlUI();
		}

		public Xml()
			: base() { }

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			Text = new System.IO.StreamReader(reader.BaseStream).ReadToEnd();
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			byte[] data = new byte[Text.Length];
			for (int i = 0; i < Text.Length; i++)
			{
				data[i] = (byte)Text[i];
			}

			writer.Write(data);
		}
		#endregion

		#region IPackedFileWrapper Member

		public uint[] AssignableTypes => new uint[]
				{
					0x00000000, //UI Data
					0xCD7FE87A, //Material Shaders
					0x7181C501, //Pet Unknown
					0x0B9EB87E, // Track Settings
				};

		public byte[] FileSignature => new byte[] { (byte)'<', (byte)'?', (byte)'x', (byte)'m', (byte)'l' };

		#endregion
	}
}
