// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Represents a PackedFile in XmlFormat
	/// </summary>
	public class Xml
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		/// <summary>
		/// the xml text
		/// </summary>
		protected string text;

		/// <summary>
		/// Returns the xml File as String
		/// </summary>
		public string Text
		{
			get => text;
			set => text = value;
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
			return new UserInterface.Xml();
		}

		public Xml()
			: base() { }

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			System.IO.StreamReader sr = new System.IO.StreamReader(reader.BaseStream);
			text = sr.ReadToEnd();
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

		public uint[] AssignableTypes
		{
			get
			{
				uint[] Types =
				{
					0x00000000, //UI Data
					0xCD7FE87A, //Material Shaders
					0x7181C501, //Pet Unknown
					0x0B9EB87E, // Track Settings
				};
				return Types;
			}
		}

		public byte[] FileSignature
		{
			get
			{
				byte[] sig = { (byte)'<', (byte)'?', (byte)'x', (byte)'m', (byte)'l' };
				return sig;
			}
		}

		#endregion
	}
}
