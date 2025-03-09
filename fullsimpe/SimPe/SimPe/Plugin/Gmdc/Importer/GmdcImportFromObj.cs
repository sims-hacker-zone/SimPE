// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

using SimPe.Geometry;

namespace SimPe.Plugin.Gmdc.Importer
{
	/// <summary>
	/// This class provides the functionality to Import Data from the .obj FileFormat
	/// </summary>
	public class GmdcImportFromObj : GmdcImporterBase
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		public GmdcImportFromObj()
			: base() { }

		#region AbstractGmdcImporter Implementation
		/// <summary>
		/// Returns the suggested File Extension (including the . like .obj or .3ds)
		/// </summary>
		public override string FileExtension => ".obj";

		/// <summary>
		/// Returns the File Description (the Name of the exported FileType)
		/// </summary>
		public override string FileDescription => "Maya Object File";

		/// <summary>
		/// Returns the name of the Author
		/// </summary>
		public override string Author => "Emily";
		#endregion

		string lineerror;
		string groupname;

		/// <summary>
		/// Initializes the Group, face, vertex, normals and uv Lists
		/// </summary>
		protected override void LoadLists()
		{
			error = "";
			vertices = new ArrayList();
			normals = new ArrayList();
			uvmaps = new ArrayList();

			//Begin with a global Group
			groups = new Hashtable();
			StartGroup("SimPEGlobal");

			int linect = 0;

			while (Input.Peek() != -1)
			{
				linect++;
				string line = Input.ReadLine();
				string oline = line;

				//cut off comments
				int pos = line.IndexOf("#");
				if (pos >= 0)
				{
					line = line.Substring(0, pos);
				}

				line = line.Trim().ToLower();

				pos = line.IndexOf(" ");
				string content = "";
				if (pos != -1)
				{
					content = line.Substring(pos + 1).Trim();
					line = line.Substring(0, pos).Trim();
				}

				if (content.Trim() == "")
				{
					continue;
				}

				//remove double whitespaces
				while (content.IndexOf("  ") != -1)
				{
					content = content.Replace("  ", " ");
				}

				lineerror = null;

				if (line == "v")
				{
					ParseTriplets(vertices, content, false); //Vertex
				}
				else if (line == "vn")
				{
					ParseTriplets(normals, content, true); //Vertex Normal
				}
				else if (line == "vt")
				{
					ParsePair(uvmaps, content); // Vertex Texture
				}
				else if (line == "g")
				{
					StartGroup(content); // new Group
				}
				else if (line == "f")
				{
					ProcessFaceList(content); // Face
				}
				else if (line == "s")
				{
					;
				} //smoothing Group;
				else if (line == "mtllib")
				{
					;
				} //material file;
				else if (line == "usemtl")
				{
					;
				} //material assignement;
				else if (Helper.WindowsRegistry.Config.HiddenMode)
				{
					lineerror = "[Warning:] Unknown token. (will be ignored)";
				}

				if (lineerror != null)
				{
					error +=
						"Line "
						+ linect.ToString()
						+ ": "
						+ lineerror
						+ " ("
						+ oline
						+ ")"
						+ Helper.lbr;
				}
			}
		}

		/// <summary>
		/// Pares a Line containing three Float Values and add them to the given List
		/// </summary>
		/// <param name="list"></param>
		/// <param name="line"></param>
		/// <param name="normal">true, if the triplet represents a Normal Vector</param>
		void ParseTriplets(ArrayList list, string line, bool normal)
		{
			string[] tokens = line.Split(" ".ToCharArray());
			if (tokens.Length >= 3)
			{
				float[] data = new float[3];
				try
				{
					for (int i = 0; i < 3; i++)
					{
						data[i] = Convert.ToSingle(
							tokens[i],
							DefaultCulture
						);
					}

					Vector3f vec = new Vector3f(data[0], data[1], data[2]);
					vec = !normal ? Component.InverseTransformScaled(vec) : Component.InverseTransformNormal(vec);

					GmdcElementValueThreeFloat v =
						new GmdcElementValueThreeFloat(
							(float)vec.X,
							(float)vec.Y,
							(float)vec.Z
						);
					list.Add(v);
				}
				catch
				{
					lineerror = "Unable to pares float Value.";
					return;
				}
			}

			if (
				tokens.Length < 3
				|| (tokens.Length != 3 && Helper.WindowsRegistry.Config.HiddenMode)
			)
			{
				lineerror = "No FloatTriplet line";
			}
		}

		/// <summary>
		/// Pares a Line containing three Float Values and add them to the given List
		/// </summary>
		/// <param name="list"></param>
		/// <param name="line"></param>
		void ParsePair(ArrayList list, string line)
		{
			string[] tokens = line.Split(" ".ToCharArray());
			if (tokens.Length >= 2)
			{
				float[] data = new float[2];
				try
				{
					for (int i = 0; i < 2; i++)
					{
						data[i] = Convert.ToSingle(
							tokens[i],
							DefaultCulture
						);
					}

					GmdcElementValueTwoFloat v =
						new GmdcElementValueTwoFloat(data[0], -data[1]);
					list.Add(v);
				}
				catch
				{
					lineerror = "Unable to pares float Value.";
					return;
				}
			}

			if (
				tokens.Length < 2
				|| (tokens.Length != 2 && Helper.WindowsRegistry.Config.HiddenMode)
			)
			{
				lineerror = "No FloatPair line";
			}
		}

		/// <summary>
		/// Start a new Group
		/// </summary>
		/// <param name="name"></param>
		void StartGroup(string name)
		{
			//make the name unique
			if (groups.Contains(name))
			{
				int i = 1;
				while (groups.Contains(name + "_" + i.ToString()))
				{
					i++;
				}
				lineerror = "Duplicate Groupname. Changed " + name + " to ";
				name += "_" + i.ToString();
				lineerror += name;
			}

			groupname = name;
			faces = new ArrayList();
			groups[groupname] = faces;
		}

		/// <summary>
		/// Pares a Face Line
		/// </summary>
		/// <param name="content"></param>
		void ProcessFaceList(string content)
		{
			string[] tokens = content.Split(" ".ToCharArray());
			if (tokens.Length == 4) //process a Quad (only convex quads are supported)
			{
				string s = tokens[0] + " " + tokens[1] + " " + tokens[2];
				ProcessFaceList(s);

				s = tokens[2] + " " + tokens[3] + " " + tokens[0];
				ProcessFaceList(s);
			}
			else if (tokens.Length == 3) //process triangle
			{
				try
				{
					for (int i = 0; i < 3; i++)
					{
						float[] data = new float[3];
						data[0] = 0;
						data[1] = 0;
						data[2] = 0;

						string[] items = tokens[i].Split("/".ToCharArray());
						for (int j = 0; j < Math.Min(items.Length, 3); j++)
						{
							if (items[j].Trim() == "")
							{
								items[j] = "0";
							}

							data[j] = Convert.ToInt32(items[j]);
						}
						GmdcElementValueThreeFloat v =
							new GmdcElementValueThreeFloat(data[0], data[1], data[2]);
						faces.Add(v);
					}
				}
				catch
				{
					lineerror = "Unable to pares index Value.";
					return;
				}
			}
			else
			{
				lineerror = "No valid Face List.";
			}
		}
	}
}
