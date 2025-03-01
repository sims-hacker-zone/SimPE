// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

using SimPe.Forms.MainUI;

using Message = SimPe.Forms.MainUI.Message;

namespace SimPe
{
	[ToolboxBitmap(typeof(Panel))]
	public partial class infocheck : UserControl
	{
		public ArrayList listing;
		internal string[] extracrap = new string[50];
		internal bool allexist = true;
		internal bool allthere = true;
		internal bool allgoody = true;
		internal bool allsame = true;

		public infocheck()
		{
			InitializeComponent();

			if (ProductVirsion != null)
			{
				lbQaVer.Text = ProductVirsion;
				button2.Visible = System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "release.nfo")
				);
				button1.Visible = !button2.Visible;
				if (button1.Visible)
				{
					lbRelease.Text =
						"\r\n\r\nFile Info doesn\'t exist, Update Info to generate one";
				}
			}
			else
			{
				pictureBox1.Image = GetIcon.Fail;
				button1.Visible =
					button2.Visible =
					lbRelease.Visible =
						false;
				lbVedict.ForeColor = Color.Maroon;
				lbVedict.Text = "Can't Find SimPe at All!";
				lbVedict.Visible = true;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			lbRelease.Font = new Font("Tahoma", 10F);
			lbRelease.TextAlign = ContentAlignment.TopLeft;
			lbRelease.Text = ReleaseDir;
			allgoody = allsame = true;
			lv2.Visible = label5.Visible = lbVedict.Visible = true;
			label1.Visible = label3.Visible = lbQaVer.Visible = true;
			button2.Visible = false;
			lv2.Items.Clear();

			XmlDocument xmlfile = new XmlDocument();
			xmlfile.Load(System.IO.Path.Combine(Helper.SimPeDataPath, "release.nfo"));
			XmlNodeList XMLData = xmlfile.GetElementsByTagName("simperelease");
			for (int i = 0; i < XMLData.Count; i++)
			{
				XmlNode node = XMLData.Item(i);
				ParseSubNode(node);
			}
			shouldexist(false);
			confirmothers();
			if (!allexist)
			{
				pictureBox1.Image = GetIcon.Fail;
				button1.Visible = false;
				lbVedict.ForeColor = Color.Maroon;
				lbVedict.Text =
					"Critical Files Missing!\n SimPe needs to be re-installed under the current user profile";
			}
			else if (!allgoody)
			{
				pictureBox1.Image = GetIcon.Fail;
				button1.Visible = true;
				lbVedict.ForeColor = Color.Maroon;
				lbVedict.Text = "File(s) Missing or Wrong Version!\n";
				if (!allthere)
				{
					lbVedict.Text += "+ Unknown File(s) found! ";
				}

				if (!allsame)
				{
					lbVedict.Text += "+ File(s) Have changed Size! ";
				}
			}
			else if (!allsame)
			{
				pictureBox1.Image = GetIcon.Warn;
				button1.Visible = true;
				lbVedict.ForeColor = Color.Indigo;
				lbVedict.Text = "File(s) Have changed Size!";
				if (!allthere)
				{
					lbVedict.Text += "\nUnknown File(s) found!";
				}
			}
			else if (!allthere)
			{
				pictureBox1.Image = GetIcon.Warn;
				button1.Visible = true;
				lbVedict.ForeColor = Color.MediumVioletRed;
				lbVedict.Text = "Unknown File(s) found!";
			}
			else
			{
				pictureBox1.Image = GetIcon.OK;
				lbVedict.ForeColor = Color.Black;
				lbVedict.Text = "Everything appears normal";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			removecrap();
			lbRelease.Font = new Font("Tahoma", 10F);
			lbRelease.TextAlign = ContentAlignment.TopLeft;
			lbRelease.Text = ReleaseDir;
			label1.Visible =
				label3.Visible =
				lbQaVer.Visible =
				label5.Visible =
				lv.Visible =
					true;
			button1.Visible =
				lbVedict.Visible =
				button2.Visible =
				lv2.Visible =
					false;
			System.Diagnostics.FileVersionInfo cver;
			cver = null;
			long csize = 0;
			listing = new ArrayList();
			listing.Clear();
			lv.Items.Clear();
			string[] files = System.IO.Directory.GetFiles(ReleaseDir, "*.dll");
			foreach (string file in files)
			{
				if (file.Contains("7zecmd") || file.Contains("whse.primitivewizards"))
				{
					continue;
				}

				listing.Add(new FileDescriptor(ReleaseDir, file));
			}
			files = System.IO.Directory.GetFiles(
				System.IO.Path.Combine(ReleaseDir, "Plugins"),
				"*.dll"
			);
			foreach (string file in files)
			{
				if (
					file.Contains("simpe.null.plugin")
					|| file.Contains("simpe.dnaupd.plugin")
				)
				{
					continue;
				}

				listing.Add(new FileDescriptor(ReleaseDir + "Plugins", file));
			}
			files = System.IO.Directory.GetFiles(ReleaseDir, "*.exe");
			foreach (string file in files)
			{
				if (
					file.Contains("Setup")
					|| file.Contains("ASCIIart")
					|| file.Contains("unins00")
				)
				{
					continue;
				}

				listing.Add(new FileDescriptor(ReleaseDir, file));
			}

			foreach (FileDescriptor f in listing)
			{
				ListViewItem lvi = new ListViewItem
				{
					Text = f.FileName
				};
				csize = f.Size;
				cver = f.Version;
				lvi.SubItems.Add(f.Size.ToString());
				lvi.SubItems.Add(VersionToString(f.Version));
				lv.Items.Add(lvi);
			}

			System.IO.StreamWriter sw = System.IO.File.CreateText(
				System.IO.Path.Combine(Helper.SimPeDataPath, "release.nfo")
			);
			try
			{
				sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
				sw.WriteLine("<simperelease version=\"" + ProductVirsion + "\">");
				foreach (FileDescriptor f in listing)
				{
					sw.Write(f.ToString());
				}
				sw.WriteLine("</simperelease>");
			}
			finally
			{
				pictureBox1.Image = GetIcon.OK;
				sw.Close();
			}
		}

		public static string ReleaseDir => Helper.SimPePath;

		/// <summary>
		/// Returns the the overall SimPe Version
		/// </summary>
		private string ProductVirsion
		{
			get
			{
				if (
					System.IO.File.Exists(
						System.IO.Path.Combine(ReleaseDir, "SimPe.exe")
					)
				)
				{
					System.Diagnostics.FileVersionInfo bver =
						System.Diagnostics.FileVersionInfo.GetVersionInfo(
							System.IO.Path.Combine(ReleaseDir, "SimPe.exe")
						);
					return bver.FileVersion;
				}
				return null;
			}
		}

		/// <summary>
		/// Formats the Version and returns it
		/// </summary>
		/// <param name="ver"></param>
		public static string VersionToString(System.Diagnostics.FileVersionInfo ver)
		{
			return ver.FileMajorPart
				+ "."
				+ ver.FileMinorPart
				+ "."
				+ ver.FileBuildPart
				+ "."
				+ ver.FilePrivatePart;
		}

		/// <summary>
		/// Formats a Long Version Number to a String
		/// </summary>
		/// <param name="l"></param>
		/// <returns></returns>
		public static string LongVersionToString(long l)
		{
			string res = "";
			res = (l & 0xffff).ToString();
			l >>= 16;
			res = (l & 0xffff).ToString() + "." + res;
			l >>= 16;
			res = (l & 0xffff).ToString() + "." + res;
			l >>= 16;
			res = (l & 0xffff).ToString() + "." + res;
			return res;
		}

		/// <summary>
		/// Parse the various Release Fields
		/// </summary>
		/// <param name="node"></param>
		void ParseSubNode(XmlNode node)
		{
			foreach (XmlNode subnode in node)
			{
				if (subnode.Name == "file")
				{
					LoadFile(subnode);
				}
			}
		}

		/// <summary>
		/// Parse the various Release Fields
		/// </summary>
		/// <param name="node"></param>
		void LoadFile(XmlNode node)
		{
			System.Diagnostics.FileVersionInfo cver;
			cver = null;
			string name = "";
			try
			{
				name = node.Attributes["name"].InnerText;
			}
			catch { }
			string vir = "";
			string sise = "";
			foreach (XmlNode subnode in node)
			{
				if (subnode.Name == "version")
				{
					vir = subnode.InnerText;
				}

				if (subnode.Name == "size")
				{
					sise = subnode.InnerText;
				}
			}
			long virsin = Convert.ToInt64(vir);
			ListViewItem lvi = new ListViewItem();

			if (System.IO.File.Exists(System.IO.Path.Combine(ReleaseDir, name)))
			{
				lvi.Text = name;
				lvi.SubItems.Add(LongVersionToString(virsin));
				cver = System.Diagnostics.FileVersionInfo.GetVersionInfo(
					System.IO.Path.Combine(ReleaseDir, name)
				);
				lvi.SubItems.Add(cver.FileVersion);
				System.IO.Stream s = System.IO.File.OpenRead(name);
				lvi.SubItems.Add(sise);
				lvi.SubItems.Add(Convert.ToString(s.Length));
				if (cver.FileVersion != LongVersionToString(virsin))
				{
					lvi.ForeColor = Color.DarkRed;
					allgoody = false;
				}
				else if (s.Length != Convert.ToInt32(sise))
				{
					lvi.ForeColor = Color.Indigo;
					allsame = false;
				}
				else
				{
					lvi.ForeColor = Color.Black;
				}

				s.Close();
				lv2.Items.Add(lvi);
			}
			else
			{
				lvi.Text = name;
				lvi.SubItems.Add(LongVersionToString(virsin));
				lvi.SubItems.Add("Missing!");
				lvi.SubItems.Add(sise);
				lvi.SubItems.Add("0");
				lvi.ForeColor = Color.Red;
				allgoody = false;
				lv2.Items.Add(lvi);
			}
		}

		private void confirmothers()
		{
			ListViewItem lvt = new ListViewItem();
			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(
						Helper.SimPeDataPath,
						"additional_careers.xml"
					)
				)
			)
			{
				allexist = false;
			}

			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(
						Helper.SimPeDataPath,
						"additional_majors.xml"
					)
				)
			)
			{
				allexist = false;
			}

			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(
						Helper.SimPeDataPath,
						"additional_schools.xml"
					)
				)
			)
			{
				allexist = false;
			}

			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "expansions.xreg")
				)
			)
			{
				allexist = false;
			}

			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "expansions2.xreg")
				)
			)
			{
				allexist = false;
			}

			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "objddefinition.xml")
				)
			)
			{
				allexist = false;
			}

			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "semiglobals.xml")
				)
			)
			{
				allexist = false;
			}

			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "tgi.xml")
				)
			)
			{
				allexist = false;
			}

			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "txmtdefinition.xml")
				)
			)
			{
				allexist = false;
			}

			if (!allexist)
			{
				lvt.Text = "Critical Data Files";
				lvt.SubItems.Add("0");
				lvt.SubItems.Add("Missing!");
				lvt.SubItems.Add("0");
				lvt.SubItems.Add("0");
				lvt.ForeColor = Color.Red;
				lv2.Items.Add(lvt);
			}
		}

		private void shouldexist(bool founde)
		{
			listing = new ArrayList();
			listing.Clear();
			int i = 0;
			string[] files = System.IO.Directory.GetFiles(ReleaseDir, "*.dll");
			foreach (string file in files)
			{
				if (file.Contains("7zecmd") || file.Contains("whse.primitivewizards"))
				{
					continue;
				}

				listing.Add(new FileDescriptor(ReleaseDir, file));
			}

			files = System.IO.Directory.GetFiles(
				System.IO.Path.Combine(ReleaseDir, "Plugins"),
				"*.dll"
			);
			foreach (string file in files)
			{
				if (
					file.Contains("simpe.null.plugin")
					|| file.Contains("simpe.dnaupd.plugi")
				)
				{
					continue;
				}

				listing.Add(new FileDescriptor(ReleaseDir + "Plugins", file));
			}

			files = System.IO.Directory.GetFiles(ReleaseDir, "*.exe");
			foreach (string file in files)
			{
				if (
					file.Contains("Setup")
					|| file.Contains("ASCIIart")
					|| file.Contains("unins0")
				)
				{
					continue;
				}

				listing.Add(new FileDescriptor(ReleaseDir, file));
			}

			foreach (FileDescriptor f in listing)
			{
				if (lv2.FindItemWithText(f.FileName) == null)
				{
					ListViewItem lvi = new ListViewItem
					{
						Text = f.FileName
					};
					lvi.SubItems.Add("New File");
					lvi.SubItems.Add(VersionToString(f.Version));
					lvi.SubItems.Add("0");
					lvi.SubItems.Add(f.Size.ToString());
					lvi.ForeColor = Color.MediumVioletRed;
					allthere = false;
					lv2.Items.Add(lvi);
					i++;
					if (i < 50)
					{
						extracrap[i] = f.FileName;
					}
				}
			}
		}

		private void removecrap()
		{
			if (!allthere)
			{
				if (
					Message.Show(
						"Settings Manager will either add the unknown files to the known file list or try to remove them.  Do you want Settings Manager to try to remove the Unknown File(s) ?",
						"Unknown File(s) Found",
						MessageBoxButtons.YesNo
					) == DialogResult.Yes
				)
				{
					foreach (string crap in extracrap)
					{
						if (
							crap != null
							&& System.IO.File.Exists(
								System.IO.Path.Combine(ReleaseDir, crap)
							)
						)
						{
							try
							{
								System.IO.File.Delete(
									System.IO.Path.Combine(ReleaseDir, crap)
								);
							}
							catch { }
						}
					}
					if (
						System.IO.Directory.Exists(
							System.IO.Path.Combine(ReleaseDir, "Data")
						)
					)
					{
						try
						{
							string[] files = System.IO.Directory.GetFiles(
								System.IO.Path.Combine(ReleaseDir, "Data"),
								"*.*"
							);
							foreach (string file in files)
							{
								System.IO.File.Delete(file);
							}
							System.IO.Directory.Delete(
								System.IO.Path.Combine(ReleaseDir, "Data"),
								true
							);
						}
						catch { }
					}
				}
			}
		}
	}

	/// <summary>
	/// Summary description for FileDescriptor.
	/// </summary>
	public class FileDescriptor
	{
		string flname;
		string bp;
		public string FileName => flname.Replace(infocheck.ReleaseDir.Trim() + @"\", "");

		public System.Diagnostics.FileVersionInfo Version
		{
			get; private set;
		}

		public long Size
		{
			get; private set;
		}

		public bool Exists
		{
			get; private set;
		}

		public FileDescriptor(string basepath, string filename)
		{
			flname = filename.Trim();
			bp = basepath.Trim();
			if (!bp.EndsWith(@"\"))
			{
				bp += @"\";
			}

			Exists = false;
			LoadInfo();
		}

		void LoadInfo()
		{
			if (!System.IO.File.Exists(flname))
			{
				return;
			}

			Exists = true;

			System.IO.Stream s = System.IO.File.OpenRead(flname);
			Size = s.Length;
			s.Close();

			Version = System.Diagnostics.FileVersionInfo.GetVersionInfo(flname);
		}

		public override string ToString()
		{
			string res = "\t<file name=\"" + FileName + "\">" + "\r\n";
			res += "\t\t<version>" + VersionToLong(Version) + "</version>" + "\r\n";
			res += "\t\t<size>" + Size.ToString() + "</size>" + "\r\n";
			res += "\t</file>" + "\r\n" + "\r\n";
			return res;
		}

		/// <summary>
		/// Returns the long Version Number
		/// </summary>
		public static long VersionToLong(System.Diagnostics.FileVersionInfo ver)
		{
			long lver = ver.FileMajorPart;
			lver = (lver << 16) + ver.FileMinorPart;
			lver = (lver << 16) + ver.FileBuildPart;
			lver = (lver << 16) + ver.FilePrivatePart;
			return lver;
		}
	}
}
