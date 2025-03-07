// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Scenegraph;

namespace SimPe.Plugin
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class MaterialDefinition : AbstractRcolBlock, IScenegraphBlock
	{
		#region Attributes


		public string FileDescription
		{
			get; set;
		}

		public string MatterialType
		{
			get; set;
		}

		public List<MaterialDefinitionProperty> Properties
		{
			get; set;
		}

		public List<string> Listing
		{
			get; set;
		}
		#endregion



		/// <summary>
		/// Constructor
		/// </summary>
		public MaterialDefinition(Rcol parent)
			: base(parent)
		{
			Properties = new List<MaterialDefinitionProperty>();
			Listing = new List<string>();
			sgres = new SGResource(null);
			BlockID = (uint)FileTypes.TXMT;
			FileDescription = "";
			MatterialType = "";
		}

		/// <summary>
		/// Returns the Property Item
		/// </summary>
		/// <param name="name">The Property name</param>
		/// <returns>The Item or an Item with no Name if the property dies not exits</returns>
		public MaterialDefinitionProperty FindProperty(string name)
		{
			name = name.Trim().ToLower();
			foreach (MaterialDefinitionProperty mdp in Properties)
			{
				if (mdp.Name.Trim().ToLower() == name)
				{
					return mdp;
				}
			}

			return new MaterialDefinitionProperty();
		}

		public MaterialDefinitionProperty GetProperty(string name)
		{
			return FindProperty(name);
			/*name = name.ToLower();
			foreach (MaterialDefinitionProperty mdp in properties)
			{
				if (name==mdp.Name.ToLower()) return mdp;
			}
			return new MaterialDefinitionProperty();*/
		}

		/// <summary>
		/// Add a new Property
		/// </summary>
		/// <param name="prop">The propery to add</param>
		/// <remarks>If the property already exists, it's value will be overwritten</remarks>
		public void Add(MaterialDefinitionProperty prop)
		{
			Add(prop, false);
		}

		/// <summary>
		/// Add a new Property
		/// </summary>
		/// <param name="prop">The propery to add</param>
		/// <param name="duplicate">true, if you want to allow two occurences of the same Property</param>
		/// <remarks>If duplicate is false, and the property already exists, it's value will be overwritten</remarks>
		public void Add(MaterialDefinitionProperty prop, bool duplicate)
		{
			if (!duplicate)
			{
				MaterialDefinitionProperty ex = null;
				foreach (MaterialDefinitionProperty mdp in Properties)
				{
					if (mdp.Name.Trim().ToLower() == prop.Name.Trim().ToLower())
					{
						ex = mdp;
						break;
					}
				}

				if (ex != null)
				{
					ex.Value = prop.Value;
				}
				else
				{
					Properties.Add(prop);
				}
			}
			else
			{
				Properties.Add(prop);
			}
		}

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public override void Unserialize(System.IO.BinaryReader reader)
		{
			version = reader.ReadUInt32();
			/*byte len = reader.ReadByte();
			fldsc = Helper.ToString(reader.ReadBytes(len));*/
			FileDescription = reader.ReadString();
			uint myid = reader.ReadUInt32();
			sgres.Unserialize(reader);
			sgres.BlockID = myid;

			/*len = reader.ReadByte();
			fldsc = Helper.ToString(reader.ReadBytes(len));*/
			FileDescription = reader.ReadString();
			/*len = reader.ReadByte();
			mattype = Helper.ToString(reader.ReadBytes(len));*/
			MatterialType = reader.ReadString();

			uint count = reader.ReadUInt32();

			Properties = new List<MaterialDefinitionProperty>();
			for (int i = 0; i < count; i++)
			{
				Properties.Add(new MaterialDefinitionProperty());
				Properties[i].Unserialize(reader);
			}

			if (version == 8)
			{
				Listing = new List<string>();
			}
			else
			{
				count = reader.ReadUInt32();
				Listing = new List<string>();
				for (int i = 0; i < count; i++)
				{
					/*len = reader.ReadByte();
					listing[i] = Helper.ToString(reader.ReadBytes(len));*/
					Listing.Add(reader.ReadString());
				}
			}
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(version);
			string name = sgres.Register(null);
			/*writer.Write((byte)name.Length);
			writer.Write(Helper.ToBytes(name, (byte)name.Length));*/
			writer.Write(name);
			writer.Write(sgres.BlockID);
			sgres.Serialize(writer);

			/*writer.Write((byte)fldsc.Length);
			writer.Write(Helper.ToBytes(fldsc, (byte)fldsc.Length));
			writer.Write((byte)mattype.Length);
			writer.Write(Helper.ToBytes(mattype, (byte)mattype.Length));*/
			writer.Write(FileDescription);
			writer.Write(MatterialType);

			writer.Write((uint)Properties.Count);
			for (int i = 0; i < Properties.Count; i++)
			{
				Properties[i].Serialize(writer);
			}

			if (version != 8)
			{
				writer.Write((uint)Listing.Count);
				for (int i = 0; i < Listing.Count; i++)
				{
					/*writer.Write((byte)listing[i].Length);
					writer.Write(Helper.ToBytes(listing[i], (byte)listing[i].Length));*/
					writer.Write(Listing[i]);
				}
			}
		}

		TabPage.MaterialDefinition tMaterialDefinition;
		TabPage.MatdForm tMaterialDefinitionProperties;
		TabPage.MaterialDefinitionCategories tMaterialDefinitionCat;
		TabPage.MaterialDefinitionFiles tMaterialDefinitionFiles;
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (tMaterialDefinition == null)
				{
					tMaterialDefinition = new TabPage.MaterialDefinition();
				}

				return tMaterialDefinition;
			}
		}
		#endregion

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			if (tMaterialDefinition == null)
			{
				tMaterialDefinition = new TabPage.MaterialDefinition();
			}

			if (tMaterialDefinitionProperties == null)
			{
				tMaterialDefinitionProperties = new TabPage.MatdForm();
			}

			if (tMaterialDefinitionCat == null)
			{
				tMaterialDefinitionCat =
					new TabPage.MaterialDefinitionCategories();
			}

			if (tMaterialDefinitionFiles == null)
			{
				tMaterialDefinitionFiles =
					new TabPage.MaterialDefinitionFiles();
			}

			tMaterialDefinitionProperties.tbname.Tag = true;
			tMaterialDefinition.tbdsc.Tag = true;
			try
			{
				tMaterialDefinition.tb_ver.Text = "0x" + Helper.HexString(version);

				tMaterialDefinitionProperties.lldel.Enabled = false;
				tMaterialDefinitionProperties.lbprop.Items.Clear();
				foreach (MaterialDefinitionProperty mdp in Properties)
				{
					tMaterialDefinitionProperties.lbprop.Items.Add(mdp);
				}

				tMaterialDefinition.tbdsc.Text = FileDescription;
				tMaterialDefinition.tbtype.Text = MatterialType;

				tMaterialDefinitionFiles.lbfl.Items.Clear();
				foreach (string fl in Listing)
				{
					tMaterialDefinitionFiles.lbfl.Items.Add(fl);
				}

				tMaterialDefinitionCat.SetupGrid(this);
			}
			finally
			{
				tMaterialDefinitionProperties.tbname.Tag = null;
				tMaterialDefinition.tbdsc.Tag = null;
			}
		}

		public override void ExtendTabControl(System.Windows.Forms.TabControl tc)
		{
			tMaterialDefinitionProperties.Tag = this;
			tc.TabPages.Add(tMaterialDefinitionProperties);

			tMaterialDefinitionFiles.Tag = this;
			tc.TabPages.Add(tMaterialDefinitionFiles);
			{
				tMaterialDefinitionCat.Tag = this;
				tc.TabPages.Add(tMaterialDefinitionCat);
			}

			tc.SelectedIndex = 1;
			if (parent != null)
			{
				parent.TabPageChanged += new EventHandler(
					tMaterialDefinitionProperties.TxmtChangeTab
				);
				parent.TabPageChanged += new EventHandler(
					tMaterialDefinitionCat.TxmtChangeTab
				);
			}
		}

		#region IScenegraphBlock Member

		public void ReferencedItems(Dictionary<string, List<IPackedFileDescriptor>> refmap, uint parentgroup)
		{
			List<IPackedFileDescriptor> list = new List<IPackedFileDescriptor>();
			refmap["TXTR"] = (from name in Listing
							  select ScenegraphHelper.BuildPfd(
										  name + "_txtr",
										  FileTypes.TXTR,
										  parentgroup
									  )).ToList();

			string refname = GetProperty("stdMatBaseTextureName").Value;
			if (refname.Trim() != "")
			{
				refmap["stdMatBaseTextureName"] = new List<IPackedFileDescriptor>
				{
					ScenegraphHelper.BuildPfd(
						refname + "_txtr",
						FileTypes.TXTR,
						parentgroup
					)
				};
			}

			refname = GetProperty("stdMatNormalMapTextureName").Value;
			if (refname.Trim() != "")
			{
				refmap["stdMatNormalMapTextureName"] = new List<IPackedFileDescriptor>
				{
					ScenegraphHelper.BuildPfd(
						refname + "_txtr",
						FileTypes.TXTR,
						parentgroup
					)
				};
			}

			refname = GetProperty("stdMatEnvCubeTextureName").Value;
			if (refname.Trim() != "")
			{
				refmap["stdMatEnvCubeTextureName"] = new List<IPackedFileDescriptor>
				{
					ScenegraphHelper.BuildPfd(
						refname + "_txtr",
						FileTypes.TXTR,
						parentgroup
					)
				};
			}

			//for characters
			int count = 0;
			try
			{
				string s = GetProperty("numTexturesToComposite").Value;
				if (s != "")
				{
					count = Convert.ToInt32(
						GetProperty("numTexturesToComposite").Value
					);
				}
			}
			catch { }
			list = new List<IPackedFileDescriptor>();
			refmap["baseTexture"] = list;
			for (int i = 0; i < count; i++)
			{
				refname = GetProperty("baseTexture" + i.ToString()).Value.Trim();
				if (refname != "")
				{
					if (!refname.EndsWith("_txtr"))
					{
						refname += "_txtr";
					}

					list.Add(
						ScenegraphHelper.BuildPfd(
							refname,
							FileTypes.TXTR,
							parentgroup
						)
					);
				}
			}
		}

		#endregion

		#region Property Grid
		static Ambertation.PropertyParser tpp;

		/// <summary>
		/// Return a PropertyParser, that enumerates all known Properties as <see cref="Ambertation.PropertyDescription"/> Objects
		/// </summary>
		public static Ambertation.PropertyParser PropertyParser
		{
			get
			{
				if (tpp == null)
				{
					tpp = new Ambertation.PropertyParser(
						System.IO.Path.Combine(
							Helper.SimPeDataPath,
							"txmtdefinition.xml"
						)
					);
				}

				return tpp;
			}
		}

		#endregion

		/// <summary>
		/// Sort the Properties in Alphabetic Order
		/// </summary>
		public void Sort()
		{
			for (int i = 0; i < Properties.Count - 1; i++)
			{
				for (int j = i + 1; j < Properties.Count; j++)
				{
					if (Properties[i].Name.CompareTo(Properties[j].Name) > 0)
					{
						(Properties[j], Properties[i]) = (Properties[i], Properties[j]);
					}
				}
			}
		}

		/// <summary>
		/// Creates a Material Object form this Block
		/// </summary>
		/// <returns></returns>
		public Ambertation.Scenes.Material ToSceneMaterial(
			Ambertation.Scenes.Scene scn,
			string name
		)
		{
			MaterialDefinitionProperty p;
			Ambertation.Scenes.Material mat = scn.CreateMaterial(name);
			p = GetProperty("stdMatSpecCoef");
			if (p != null)
			{
				mat.Specular = p.ToARGB();
			}

			p = GetProperty("stdMatDiffCoef");
			if (p != null)
			{
				mat.Diffuse = p.ToARGB();
			}

			p = GetProperty("stdMatEmissiveCoef");
			if (p != null)
			{
				mat.Emmissive = p.ToARGB();
			}

			p = GetProperty("stdMatSpecPower");
			if (p != null)
			{
				mat.SpecularPower = p.ToValue();
			}

			p = GetProperty("stdMatAlphaBlendMode");

			if (p != null)
			{
				if (p.Value == "blend")
				{
					MaterialDefinitionProperty p2 = GetProperty(
						"stdMatLightingEnabled"
					);
					if (p2 != null)
					{
						if (p2.ToValue() == 0)
						{
							mat.Mode = Ambertation
								.Scenes
								.Material
								.TextureModes
								.ShadowTexture;
						}
					}
				}
				//if (mat.Texture.AlphaBlend) mat.Diffuse = System.Drawing.Color.FromArgb(0x10, mat.Diffuse);
			}
			return mat;
		}

		/// <summary>
		/// Exports the Material Definition Properties to an xml file
		/// </summary>
		/// <param name="filename">The filename to write to</param>
		public void ExportProperties(string filename)
		{
			System.Xml.XmlWriterSettings xws = new System.Xml.XmlWriterSettings
			{
				CloseOutput = true,
				Indent = true,
				Encoding = System.Text.Encoding.UTF8
			};
			System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(filename, xws);

			try
			{
				xw.WriteStartElement("materialDefinition");
				xw.WriteComment("Source: " + Parent.FileDescriptor.ExportFileName);
				xw.WriteComment("Block name: " + BlockName);
				xw.WriteComment("File description: " + FileDescription);
				xw.WriteComment("Material Type: " + MatterialType);
				foreach (MaterialDefinitionProperty p in Properties)
				{
					xw.WriteStartElement("materialDefinitionProperty");
					xw.WriteAttributeString("name", p.Name);
					xw.WriteValue(p.Value);
					xw.WriteEndElement();
				}
				xw.WriteEndElement();
			}
			finally
			{
				xw.Close();
				xw = null;
			}
		}

		/// <summary>
		/// Imports the Material Definition Properties, replacing the current ones
		/// </summary>
		/// <param name="filename">The name of the file to import</param>
		public void ImportProperties(string filename)
		{
			Properties = new List<MaterialDefinitionProperty>();
			MergeProperties(filename);
		}

		/// <summary>
		/// Merges the Material Definition Properties - adds, overwrites or retains as appropriate
		/// </summary>
		/// <param name="filename">The name of the file to merge</param>
		public void MergeProperties(string filename)
		{
			System.Xml.XmlReaderSettings xrs = new System.Xml.XmlReaderSettings
			{
				CloseInput = true,
				IgnoreComments = true,
				IgnoreProcessingInstructions = true,
				IgnoreWhitespace = true
			};
			System.Xml.XmlReader xr = System.Xml.XmlReader.Create(filename, xrs);

			try
			{
				xr.ReadStartElement("materialDefinition");
				while (xr.IsStartElement())
				{
					if (xr.Name != "materialDefinitionProperty")
					{
						xr.Skip();
						continue;
					}
					MaterialDefinitionProperty p = new MaterialDefinitionProperty();
					while (xr.MoveToNextAttribute())
					{
						if (xr.Name == "name")
						{
							p.Name = xr.Value;
						}
					}
					xr.MoveToElement();
					p.Value = xr.ReadString();
					Add(p, false);
					xr.ReadEndElement();
				}
				xr.ReadEndElement();
			}
			finally
			{
				xr.Close();
				xr = null;
			}
		}

		#region IDisposable Member

		public override void Dispose()
		{
			tMaterialDefinition?.Dispose();

			tMaterialDefinitionProperties?.Dispose();

			tMaterialDefinitionCat?.Dispose();

			tMaterialDefinitionFiles?.Dispose();

			tMaterialDefinitionFiles = null;
			tMaterialDefinitionCat = null;
			tMaterialDefinitionProperties = null;
			tMaterialDefinition = null;
		}

		#endregion
	}

	public class MaterialDefinitionProperty
	{
		#region Attributes

		public string Name
		{
			get; set;
		}

		public string Value
		{
			get; set;
		}
		#endregion

		public MaterialDefinitionProperty()
		{
			Name = "";
			Value = "";
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			Name = reader.ReadString();
			Value = reader.ReadString();
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(Name);
			writer.Write(Value);
		}

		public double ToValue()
		{
			double[] list = ToFloat();
			return list.Length > 0 ? list[0] : 0;
		}

		public Ambertation.Geometry.Vector2 ToVector2()
		{
			double[] list = ToFloat();
			Ambertation.Geometry.Vector2 v = Ambertation.Geometry.Vector2.Zero;
			if (list.Length > 0)
			{
				v.X = list[0];
			}

			if (list.Length > 1)
			{
				v.Y = list[1];
			}

			return v;
		}

		public System.Drawing.Color ToRGB()
		{
			Ambertation.Geometry.Vector3 v = ToVector3();
			Clamp(v);
			return System.Drawing.Color.FromArgb(
				(int)(v.X * 0xff),
				(int)(v.Y * 0xff),
				(int)(v.Z * 0xff)
			);
		}

		void Clamp(Ambertation.Geometry.Vector4 v)
		{
			v.X = Math.Max(0, Math.Min(1, v.X));
			v.Y = Math.Max(0, Math.Min(1, v.Y));
			v.Z = Math.Max(0, Math.Min(1, v.Z));
			v.W = Math.Max(0, Math.Min(1, v.W));
		}

		void Clamp(Ambertation.Geometry.Vector3 v)
		{
			v.X = Math.Max(0, Math.Min(1, v.X));
			v.Y = Math.Max(0, Math.Min(1, v.Y));
			v.Z = Math.Max(0, Math.Min(1, v.Z));
		}

		public System.Drawing.Color ToARGB()
		{
			if (ToFloat().Length < 4)
			{
				return ToRGB();
			}

			Ambertation.Geometry.Vector4 v = ToVector4();
			Clamp(v);
			return System.Drawing.Color.FromArgb(
				(int)(v.W * 0xff),
				(int)(v.X * 0xff),
				(int)(v.Y * 0xff),
				(int)(v.Z * 0xff)
			);
		}

		public Ambertation.Geometry.Vector3 ToVector3()
		{
			double[] list = ToFloat();
			Ambertation.Geometry.Vector3 v = Ambertation.Geometry.Vector3.Zero;
			if (list.Length > 0)
			{
				v.X = list[0];
			}

			if (list.Length > 1)
			{
				v.Y = list[1];
			}

			if (list.Length > 2)
			{
				v.Z = list[2];
			}

			return v;
		}

		public Ambertation.Geometry.Vector4 ToVector4()
		{
			double[] list = ToFloat();
			Ambertation.Geometry.Vector4 v = new Ambertation.Geometry.Vector4(
				0,
				0,
				0,
				0
			);
			if (list.Length > 0)
			{
				v.X = list[0];
			}

			if (list.Length > 1)
			{
				v.Y = list[1];
			}

			if (list.Length > 2)
			{
				v.Z = list[2];
			}

			if (list.Length > 3)
			{
				v.W = list[3];
			}

			return v;
		}

		public double[] ToFloat()
		{
			Ambertation.Collections.DoubleCollection dc =
				new Ambertation.Collections.DoubleCollection();
			string[] parts = Value.Split(new char[] { ',' });
			foreach (string s in parts)
			{
				try
				{
					dc.Add(
						Convert.ToDouble(
							s,
							System.Globalization.CultureInfo.InvariantCulture
						)
					);
				}
				catch { }
			}

			double[] ret = new double[dc.Count];
			for (int i = 0; i < dc.Count; i++)
			{
				ret[i] = dc[i];
			}

			return ret;
		}

		public override string ToString()
		{
			return Name + ": " + Value;
		}
	}
}
