// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// This Interface is the base for all Importers
	/// </summary>
	/// <remarks>
	/// It is probably a good Idea, to not implement this Interface
	/// direct, but reuse the GmdcImporterBase class.
	/// </remarks>
	public interface IGmdcImporter
	{
		/// <summary>
		/// Returns a Version Number for the used Interface
		/// </summary>
		int Version
		{
			get;
		}

		/// <summary>
		/// Returns the suggested File Extension (including the . like .obj or .3ds)
		/// </summary>
		string FileExtension
		{
			get;
		}

		/// <summary>
		/// Returns the File Description (the Name of the exported FileType)
		/// </summary>
		string FileDescription
		{
			get;
		}

		/// <summary>
		/// Returns the name of the Author
		/// </summary>
		string Author
		{
			get;
		}

		/// <summary>
		/// Returns the Error Message Produced by the Last Parsing attempt
		/// </summary>
		string ErrorMessage
		{
			get;
		}

		/// <summary>
		/// Returns the FileName that is used to create the File. Changing the FileName has no effect
		/// </summary>
		string FileName
		{
			get; set;
		}

		/// <summary>
		/// Process the Data stored in the passed Stream, and change/replace the passed Gmdc
		/// </summary>
		/// <param name="input">A Stream with the Input Data</param>
		/// <param name="gmdc">The Gmdc that should receive the Data</param>
		/// <param name="animationonly">True if you only want to import the Animation Data</param>
		bool Process(
			System.IO.Stream input,
			GeometryDataContainer gmdc,
			bool animationonly
		);

		/// <summary>
		/// Which Order is used for the Components (determins the Transformation that should be applied on import)
		/// </summary>
		ElementOrder Component
		{
			get; set;
		}
	}
}
