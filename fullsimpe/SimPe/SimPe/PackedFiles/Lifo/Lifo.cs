// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.Plugin;

namespace SimPe.PackedFiles.Lifo
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Lifo : Rcol
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public Lifo(Interfaces.IProviderRegistry provider, bool fast)
			: base(provider, fast) { }

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new LifoUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"LIFO Wrapper",
				"Pumuckl, Quaxi",
				"This File is part of the Scenegraph. It contains a large image for a Texture.",
				5,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.lifo.png")
				)
			);
		}
		#endregion


		#region IFileWrapper Member

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public override FileTypes[] AssignableTypes => new FileTypes[]
				{
					FileTypes.LIFO,
				};

		#endregion
	}
}
