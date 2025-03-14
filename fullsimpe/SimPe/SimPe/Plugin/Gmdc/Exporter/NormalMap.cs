// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace SimPe.Plugin.Gmdc.Exporter
{
	/// <summary>
	/// This class provides the functionality to Export Data to the .obj FileFormat
	/// </summary>
	///
	public class GmdcExportToNorm : AbstractGmdcExporter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="gmdc">The Gmdc File the Export is based on</param>
		/// <param name="groups">The list of Groups you want to export</param>
		/// <remarks><see cref="AbstractGmdcExporter.FileContent"/> will contain the Exported .obj File</remarks>
		public GmdcExportToNorm(GeometryDataContainer gmdc, List<GmdcGroup> groups)
			: base(gmdc, groups) { }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="gmdc">The Gmdc File the Export is based on</param>
		/// <remarks><see cref="AbstractGmdcExporter.FileContent"/> will contain the Exported .obj File</remarks>
		public GmdcExportToNorm(GeometryDataContainer gmdc)
			: base(gmdc) { }

		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <remarks>The export has to be started Manual through a call to <see cref="AbstractGmdcExporter.Process"/></remarks>
		public GmdcExportToNorm()
			: base() { }

		//int modelnr, vertexoffset;

		/// <summary>
		/// Returns the suggested File Extension (including the . like .obj or .3ds)
		/// </summary>
		public override string FileExtension => ".map";

		/// <summary>
		/// Returns the File Description (the Name of the exported FileType)
		/// </summary>
		public override string FileDescription => "BumpMapNormals";

		/// <summary>
		/// Returns the name of the Author
		/// </summary>
		public override string Author => "Skankyboy";

		/// <summary>
		/// Called when a new File is started
		/// </summary>
		/// <remarks>
		/// you should use this to write Header Informations.
		/// Use the writer member to write to the File
		/// </remarks>
		///

		protected override void InitFile()
		{
			if (Groups.Count > 1)
			{
				throw new Warning(
					"Too Many Meshes Selected",
					"You've selected too many meshes\nSmd File only support 1 mesh per file"
				);
			}
			else if (Groups.Count < 1)
			{
				throw new Warning(
					"No Mesh Selected",
					"You need to select one mesh"
				);
			}
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
		///

		//Return a string array with twin values removed
		string[] RemoveDuplicates(string[] tokens)
		{
			ArrayList tempa = new ArrayList();
			for (int i = 0; i < tokens.Length - 1; i++)
			{
				if (!tempa.Contains(tokens[i]))
				{
					tempa.Add(tokens[i]);
				}
			}

			string[] result = new string[tempa.Count];
			for (int i = 0; i < tempa.Count; i++)
			{
				result[i] = tempa[i].ToString();
			}

			return result;
		}

		//This function create a Vector3f array named verttangent which contain bumpmapnormal value for each vertex
		protected override void ProcessGroup()
		{
			int nr = Link.GetElementNr(VertexElement);
			int nn = Link.GetElementNr(NormalElement);
			int nm = Link.GetElementNr(UVCoordinateElement);

			int nbfaces = Group.Faces.Count / 3;
			int nbvert = Link.ReferencedSize;

			string[] faceforvert = new string[nbvert];

			Vector3[] facetangent = new Vector3[nbfaces];
			Vector3[] verttangent = new Vector3[nbvert];

			int facenumber = 0;
			for (int i = 0; i < Group.Faces.Count; i += 3)
			{
				int j1 = Group.Faces[i]; // get vertex 1 index number
				int j2 = Group.Faces[i + 1]; // get vertex 2 index number
				int j3 = Group.Faces[i + 2]; // get vertex 3 index number
				faceforvert[j1] += facenumber.ToString() + " "; // add this face number to vert num array
				faceforvert[j2] += facenumber.ToString() + " "; // add this face number to vert num array
				faceforvert[j3] += facenumber.ToString() + " "; // add this face number to vert num array

				//get vert position v1,v2,v3 and vert uvmap uv1,uv2,uv3
				Vector3 v1 = new Vector3(
					Link.GetValue(nr, j1).Data[0],
					Link.GetValue(nr, j1).Data[1],
					Link.GetValue(nr, j1).Data[2]
				);
				Vector3 uv1 = new Vector3(
					Link.GetValue(nm, j1).Data[0],
					1 - Link.GetValue(nm, j1).Data[1],
					0
				);

				Vector3 v2 = new Vector3(
					Link.GetValue(nr, j2).Data[0],
					Link.GetValue(nr, j2).Data[1],
					Link.GetValue(nr, j2).Data[2]
				);
				Vector3 uv2 = new Vector3(
					Link.GetValue(nm, j2).Data[0],
					1 - Link.GetValue(nm, j2).Data[1],
					0
				);

				Vector3 v3 = new Vector3(
					Link.GetValue(nr, j3).Data[0],
					Link.GetValue(nr, j3).Data[1],
					Link.GetValue(nr, j3).Data[2]
				);
				Vector3 uv3 = new Vector3(
					Link.GetValue(nm, j3).Data[0],
					1 - Link.GetValue(nm, j3).Data[1],
					0
				);

				//calculate vectors v1,v2 and uv1 and uv2
				v3 -= v1;
				v1 = v2 - v1;
				v2 = v3;

				uv3 -= uv1;
				uv1 = uv2 - uv1;
				uv2 = uv3;

				//Calculate Face Tangent "Factor"
				float r = 1f / ((uv1.X * uv2.Y) - (uv2.X * uv1.Y));

				//correct extrem values of "Factor"
				if (r > 10000000000000000)
				{
					r = 10000000000000000;
				}

				if (r < -10000000000000000)
				{
					r = -10000000000000000;
				}

				//Calculate Face Tangent
				Vector3 tangent = (uv2.Y * v1) - (uv1.Y * v2);
				tangent *= r;
				facetangent[facenumber] = tangent;

				facenumber++;
			}

			//Search doubled vertices (this algo is very slow but I didn't found other way to do this)
			for (int i = 0; i < nbvert; i++)
			{
				for (int j = 0; j < nbvert; j++)
				{
					if (
						i != j
						&& Link.GetValue(nr, i).Data[0].ToString("N5")
							== Link.GetValue(nr, j).Data[0].ToString("N5")
						&& Link.GetValue(nr, i).Data[1].ToString("N5")
							== Link.GetValue(nr, j).Data[1].ToString("N5")
						&& Link.GetValue(nr, i).Data[2].ToString("N5")
							== Link.GetValue(nr, j).Data[2].ToString("N5")
						&& Link.GetValue(nn, i).Data[0].ToString("N5")
							== Link.GetValue(nn, j).Data[0].ToString("N5")
						&& Link.GetValue(nn, i).Data[1].ToString("N5")
							== Link.GetValue(nn, j).Data[1].ToString("N5")
						&& Link.GetValue(nn, i).Data[2].ToString("N5")
							== Link.GetValue(nn, j).Data[2].ToString("N5")
						&& Link.GetValue(nm, i).Data[0].ToString("N5")
							== Link.GetValue(nm, j).Data[0].ToString("N5")
						&& Link.GetValue(nm, i).Data[1].ToString("N5")
							== Link.GetValue(nm, j).Data[1].ToString("N5")
					)
					{
						faceforvert[i] += faceforvert[j];
					}
				}
			}

			//Convert Faces Tangent to Vertices Tangent
			for (int i = 0; i < nbvert; i++)
			{
				//Get Gmdc Vertex Normal Informations
				Vector3 vertnormalgmdc = new Vector3(
					Link.GetValue(nn, i).Data[0],
					Link.GetValue(nn, i).Data[1],
					Link.GetValue(nn, i).Data[2]
				);

				//Get faces numbers used by this vertex in array faceused
				string[] tokens = faceforvert[i].Split(" ".ToCharArray());
				tokens = RemoveDuplicates(tokens);
				int nbfaceused = tokens.Length;
				int[] faceused = new int[nbfaceused];
				for (int j = 0; j < nbfaceused; j++)
				{
					faceused[j] = Convert.ToInt16(tokens[j]);
				}

				//Add face tangent for each face used
				Vector3 tangent = new Vector3(0, 0, 0);
				for (int j = 0; j < nbfaceused; j++)
				{
					tangent += facetangent[faceused[j]];
				}

				//Finalize tangent calculation
				tangent = Vector3.Normalize(tangent);
				tangent -= vertnormalgmdc * (tangent * vertnormalgmdc);
				tangent = Vector3.Normalize(tangent);

				verttangent[i] = tangent;
			}

			/* Not needed for internal usage ;)
			//
			//Write each vert tangent in c;\bumpcheck.txt file
			//like this : "VertNumber TangentX TangentY TangentZ"
			StreamWriter sr = new StreamWriter(File.Create("c:\\bumpcheck.txt"));
			for(int i=0; i< nbvert;i++)
				sr.WriteLine(i.ToString()+" "+verttangent[i].ToString2());
			sr.Close();
			//
			*/

			//Note :
			//Algo creation inspired by the one found here : http://www.c4engine.com/code/tangent.html
		}

		protected override void FinishFile()
		{
		}
	}
}
