// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// This Interface must be implemented by Exporter Plugins
	/// </summary>
	/// <remarks>
	/// It is probably a good Idea, to not implement this Interface
	/// direct, but reuse the AbstractGmdcExporter class.
	/// </remarks>
	public interface IGmdcExporter
	{
		/// <summary>
		/// Create the export for all available Groups
		/// </summary>
		/// <param name="gmdc"></param>
		/// <returns>The created Stream</returns>
		System.IO.Stream Process(GeometryDataContainer gmdc);

		/// <summary>
		/// Create the export for the given Groups
		/// </summary>
		/// <param name="gmdc"></param>
		/// <param name="groups"></param>
		/// <returns>The created Stream</returns>
		System.IO.Stream Process(GeometryDataContainer gmdc, GmdcGroups groups);

		/// <summary>
		/// Retunrs or sets the FileName that is used to create the File
		/// </summary>
		string FileName
		{
			get; set;
		}

		/// <summary>
		/// Returns the Content of the File base on the last loaded GroupSet
		/// </summary>
		System.IO.StreamWriter FileContent
		{
			get;
		}

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
		/// Which Order is used for the Components (determins the Transformation that should be applied on export)
		/// </summary>
		ElementOrder Component
		{
			get; set;
		}

		/// <summary>
		/// true, if you want SimPe to correct the Joint definitions, moving all rotations to the _root node,
		/// and all translations to the _trans node of a Joint pair.
		/// </summary>
		bool CorrectJointSetup
		{
			get; set;
		}
	}
}
