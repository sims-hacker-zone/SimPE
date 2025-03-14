// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.Numerics;

namespace SimPe.Plugin.Gmdc.Exporter
{
	/// <summary>
	/// This class provides the functionality to Export Data to the .obj FileFormat
	/// </summary>
	public class GmdcExportToObj : AbstractGmdcExporter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="gmdc">The Gmdc File the Export is based on</param>
		/// <param name="groups">The list of Groups you want to export</param>
		/// <remarks><see cref="AbstractGmdcExporter.FileContent"/> will contain the Exported .obj File</remarks>
		public GmdcExportToObj(GeometryDataContainer gmdc, List<GmdcGroup> groups)
			: base(gmdc, groups) { }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="gmdc">The Gmdc File the Export is based on</param>
		/// <remarks><see cref="AbstractGmdcExporter.FileContent"/> will contain the Exported .obj File</remarks>
		public GmdcExportToObj(GeometryDataContainer gmdc)
			: base(gmdc) { }

		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <remarks>The export has to be started Manual through a call to <see cref="AbstractGmdcExporter.Process"/></remarks>
		public GmdcExportToObj()
			: base() { }

		int modelnr,
			vertexoffset;

		/// <summary>
		/// Returns the suggested File Extension (including the . like .obj or .3ds)
		/// </summary>
		public override string FileExtension => ".obj";

		/// <summary>
		/// Returns the File Description (the Name of the exported FileType)
		/// </summary>
		public override string FileDescription => "Maya Object";

		/// <summary>
		/// Returns the name of the Author
		/// </summary>
		public override string Author => "Delphy";

		/// <summary>
		/// Called when a new File is started
		/// </summary>
		/// <remarks>
		/// you should use this to write Header Informations.
		/// Use the writer member to write to the File
		/// </remarks>
		protected override void InitFile()
		{
			modelnr = 0;
			vertexoffset = 0;
			writer.WriteLine("# File based on the GMDC plugin by Delphy");
		}

		/// <summary>
		/// This is called whenever a Group (=subSet) needs to processed
		/// </summary>
		/// <remarks>
		/// You can use the UVCoordinateElement, NormalElement,
		/// VertexElement, Group and Link Members in this Method.
		///
		/// This Method is only called, when the Group, Link and
		/// Vertex Members are set (not null). The other still can
		/// be Null!
		///
		/// Use the writer member to write to the File.
		/// </remarks>
		protected override void ProcessGroup()
		{
			//Find the Vertex Reference Number
			int vertref = Link.GetElementNr(VertexElement);

			writer.WriteLine("# Object number: " + modelnr);
			writer.WriteLine("# VertexList ref: " + vertref);
			writer.WriteLine("g " + Group.Name);

			//first, write the availabel Vertices
			int vertexcount = 0;
			int nr = Link.GetElementNr(VertexElement);
			for (int i = 0; i < Link.ReferencedSize; i++)
			{
				vertexcount++;
				Vector3 v = new Vector3(
					Link.GetValue(nr, i).Data[0],
					Link.GetValue(nr, i).Data[1],
					Link.GetValue(nr, i).Data[2]
				);
				v = Component.TransformScaled(v);
				writer.WriteLine(
					"v "
						+ v.X.ToString("N12", DefaultCulture)
						+ " "
						+ v.Y.ToString("N12", DefaultCulture)
						+ " "
						+ v.Z.ToString("N12", DefaultCulture)
				);
			}

			//Add a MeshNormal Section if available
			if (NormalElement != null)
			{
				nr = Link.GetElementNr(NormalElement);
				for (int i = 0; i < Link.ReferencedSize; i++)
				{
					Vector3 v = new Vector3(
						Link.GetValue(nr, i).Data[0],
						Link.GetValue(nr, i).Data[1],
						Link.GetValue(nr, i).Data[2]
					);
					v = Component.TransformNormal(v);
					writer.WriteLine(
						"vn "
							+ v.X.ToString("N12", DefaultCulture)
							+ " "
							+ v.Y.ToString("N12", DefaultCulture)
							+ " "
							+ v.Z.ToString("N12", DefaultCulture)
					);
				}
			}

			//now the Texture Cords //iv available
			if (UVCoordinateElement != null)
			{
				nr = Link.GetElementNr(UVCoordinateElement);
				for (int i = 0; i < Link.ReferencedSize; i++)
				{
					writer.WriteLine(
						"vt "
							+ Link.GetValue(nr, i)
								.Data[0]
								.ToString("N6", DefaultCulture)
							+ " "
							+ (-Link.GetValue(nr, i).Data[1]).ToString(
								"N6",
								DefaultCulture
							)
					);
				}
			}

			writer.WriteLine("# number of polygons: " + (Group.Faces.Count / 3));
			if (modelnr > 0)
			{
				writer.WriteLine(
					"# vertsSoFar: " + (vertexoffset + vertexcount - 2).ToString()
				);
			}
			else
			{
				writer.WriteLine("# vertsSoFar: 0");
			}

			writer.WriteLine("# totalVertices: " + (vertexoffset + vertexcount));
			writer.WriteLine("# vertGroupStart: " + vertexoffset);

			for (int i = 0; i < Group.Faces.Count; i++)
			{
				int vertexnr = Group.Faces[i] + 1 + vertexoffset;
				if (i % 3 == 0)
				{
					writer.Write(
						"f "
							+ vertexnr.ToString()
							+ "/"
							+ vertexnr.ToString()
							+ "/"
							+ vertexnr.ToString()
					);
				}
				else if (i % 3 == 1)
				{
					writer.Write(
						" "
							+ vertexnr.ToString()
							+ "/"
							+ vertexnr.ToString()
							+ "/"
							+ vertexnr.ToString()
					);
				}
				else
				{
					writer.WriteLine(
						" "
							+ vertexnr.ToString()
							+ "/"
							+ vertexnr.ToString()
							+ "/"
							+ vertexnr.ToString()
					);
				}
			}

			vertexoffset += vertexcount;
			modelnr++;
		}

		/// <summary>
		/// Called when the export was finished
		/// </summary>
		/// <remarks>you should use this to write Footer Informations.
		/// Use the writer member to write to the File</remarks>
		protected override void FinishFile()
		{
			//nothing to do here
		}
	}
}
