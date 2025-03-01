// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.IO;

namespace SimPe.Plugin.Gmdc.Importer
{
	/// <summary>
	/// This class provides the functionality to Import Data from the .obj FileFormat
	/// </summary>
	public class GmdcImportFromXsi : IGmdcImporter
	{
		#region IGmdcImporter Member

		public int Version => 1;

		public string FileExtension => ".xsi";

		public string FileDescription => "Softimage/3D dotXSI";

		public string Author => "Quaxi";

		public string ErrorMessage => "";

		string flname;
		public string FileName
		{
			get => flname ?? "";
			set => flname = value;
		}

		ElementOrder cmp;
		public ElementOrder Component
		{
			get
			{
				if (cmp == null)
				{
					cmp = new ElementOrder(ElementSorting.XZY);
				}

				return cmp;
			}
			set => cmp = value;
		}

		public bool Process(
			Stream input,
			GeometryDataContainer gmdc,
			bool animationonly
		)
		{
			StreamReader sr = new StreamReader(input);
			Ambertation.XSI.IO.AsciiFile xsi = Ambertation.XSI.IO.AsciiFile.FromStream(
				sr,
				FileName
			);

			GenericMeshImport gmi = new GenericMeshImport(
				xsi.ToScene(),
				gmdc,
				Component
			);
			return gmi.Run();
		}

		#endregion
	}
}
