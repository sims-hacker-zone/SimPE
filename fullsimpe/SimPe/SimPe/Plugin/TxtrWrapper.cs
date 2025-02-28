// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Txtr : Rcol
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public Txtr(Interfaces.IProviderRegistry provider, bool fast)
			: base(provider, fast) { }

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new TxtrUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"TXTR Wrapper",
				"Pumuckl, Quaxi",
				"This File is part of the Scenegraph. It contains the Texture for a Mesh Group/Subset.",
				13,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.txtr.png")
				)
			);
		}
		#endregion


		#region IFileWrapper Member

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public override uint[] AssignableTypes
		{
			get
			{
				uint[] types =
				{
					0x1C4A276C, //TXTR Files
				};
				return types;
			}
		}

		#endregion
	}
}
