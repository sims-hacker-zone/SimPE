// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace SimPe
{
	/// <summary>
	/// Handles Extracted Pakage Files
	/// </summary>
	public class XmlPackageReader
	{
		/// <summary>
		/// Creates a Package File from a previously extracted Package
		/// </summary>
		/// <param name="filename">Filename of package.xml File describing the Package</param>
		/// <param name="pb">A Progressbar indicating the progress</param>
		/// <returns>Binary Reader representing the Package File</returns>
		public static BinaryReader OpenExtractedPackage(
			ProgressBar pb,
			string filename
		)
		{
			string path = Path.GetDirectoryName(filename);
			XmlDocument xmlfile = new XmlDocument();
			xmlfile.Load(filename);

			//Root Node suchen
			XmlNodeList XMLData = xmlfile.GetElementsByTagName("package");

			ArrayList list = new ArrayList();
			//Alle Eintr&auml;ge im Root Node verarbeiten
			Data.MetaData.IndexTypes type = Data.MetaData.IndexTypes.ptShortFileIndex;
			for (int i = 0; i < XMLData.Count; i++)
			{
				XmlNode node = XMLData.Item(i);

				object o = node.Attributes["type"].Value ?? "1";

				type = (Data.MetaData.IndexTypes)uint.Parse(o.ToString());

				if (pb != null)
				{
					pb.Maximum = node.ChildNodes.Count;
				}

				int count = 0;
				foreach (XmlNode subnode in node)
				{
					if (pb != null)
					{
						pb.Value = count++;
						Application.DoEvents();
					}
					///a New FileItem
					if (subnode.LocalName == "packedfile")
					{
						list.Add(CreateDescriptor(path, subnode));
					}
				}
			}

			Packages.GeneratableFile file =
				Packages.File.CreateNew();
			file.BeginUpdate();
			file.Header.IndexType = type;

			foreach (Packages.PackedFileDescriptor pfd in list)
			{
				file.Add(pfd);
				if (pfd.Type == Packages.File.FILELIST_TYPE)
				{
					file.FileList = pfd;
				}
			}

			MemoryStream ms = file.Build();
			file.EndUpdate();
			if (pb != null)
			{
				pb.Value = pb.Maximum;
			}

			return new BinaryReader(ms);
		}

		/// <summary>
		/// Loads a previously extracted File
		/// </summary>
		/// <param name="filename">name of the xml Description File</param>
		/// <returns>a FileDescription where you have to put the UserData in</returns>
		public static Packages.PackedFileDescriptor OpenExtractedPackedFile(
			string filename
		)
		{
			string path = Path.GetDirectoryName(filename);
			XmlDocument xmlfile = new XmlDocument();
			xmlfile.Load(filename);

			//Root Node suchen
			XmlNodeList XMLData = xmlfile.GetElementsByTagName("package");

			for (int i = 0; i < XMLData.Count; i++)
			{
				XmlNode node = XMLData.Item(i);

				object o = node.Attributes["type"].Value ?? "1";

				foreach (XmlNode subnode in node)
				{
					///a New FileItem
					if (subnode.LocalName == "packedfile")
					{
						return CreateDescriptor(path, subnode);
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Creates a new File Descriptor (with Userdata) as defined by the XmlNode
		/// </summary>
		/// <param name="parentpath">The Path where the Package xml is located</param>
		/// <param name="node">packedfile XML-Node</param>
		/// <returns>A PackedFile Descriptor</returns>
		protected static Packages.PackedFileDescriptor CreateDescriptor(
			string parentpath,
			XmlNode node
		)
		{
			Packages.PackedFileDescriptor pfd =
				new Packages.PackedFileDescriptor();
			foreach (XmlNode subnode in node)
			{
				switch (subnode.Name)
				{
					case "type":
					{
						foreach (XmlNode typenode in subnode)
						{
							switch (typenode.Name)
							{
								case "number":
								{
									pfd.Type = Convert.ToUInt32(typenode.InnerText);
									break;
								}
							}
						}
						break;
					}
					case "classid":
					{
						pfd.SubType = Convert.ToUInt32(subnode.InnerText);
						break;
					}
					case "group":
					{
						pfd.Group = Convert.ToUInt32(subnode.InnerText);
						break;
					}
					case "instance":
					{
						pfd.Instance = Convert.ToUInt32(subnode.InnerText);
						break;
					}
				}
			}

			//now load the Files Data
			object flname = node.Attributes["name"].Value ?? "";

			object path = node.Attributes["path"].Value ?? "";

			pfd.Path = path.ToString();
			pfd.Filename = flname.ToString();

			flname = Path.Combine(
				parentpath,
				Path.Combine(path.ToString(), flname.ToString())
			);

			if (File.Exists(flname.ToString()))
			{
				FileStream fs = File.OpenRead(flname.ToString());
				BinaryReader mbr = new BinaryReader(fs);
				try
				{
					byte[] data = new byte[mbr.BaseStream.Length];
					for (int i = 0; i < data.Length; i++)
					{
						data[i] = mbr.ReadByte();
					}

					pfd.UserData = data;
				}
				finally
				{
					mbr.Close();
					mbr = null;
					fs.Close();
					fs.Dispose();
					fs = null;
				}
			}

			return pfd;
		}
	}
}
