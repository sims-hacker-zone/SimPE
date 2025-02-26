using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using System.Xml;

namespace SimPe
{
	[ToolboxBitmapAttribute(typeof(Panel))]
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
				this.lbQaVer.Text = ProductVirsion;
				this.button2.Visible = System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "release.nfo")
				);
				this.button1.Visible = !this.button2.Visible;
				if (this.button1.Visible)
					this.lbRelease.Text =
						"\r\n\r\nFile Info doesn\'t exist, Update Info to generate one";
			}
			else
			{
				this.pictureBox1.Image = GetIcon.Fail;
				this.button1.Visible =
					this.button2.Visible =
					this.lbRelease.Visible =
						false;
				this.lbVedict.ForeColor = System.Drawing.Color.Maroon;
				this.lbVedict.Text = "Can't Find SimPe at All!";
				this.lbVedict.Visible = true;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.lbRelease.Font = new System.Drawing.Font("Tahoma", 10F);
			this.lbRelease.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lbRelease.Text = ReleaseDir;
			allgoody = allsame = true;
			this.lv2.Visible = this.label5.Visible = this.lbVedict.Visible = true;
			this.label1.Visible = this.label3.Visible = this.lbQaVer.Visible = true;
			this.button2.Visible = false;
			this.lv2.Items.Clear();

			System.Xml.XmlDocument xmlfile = new XmlDocument();
			xmlfile.Load(System.IO.Path.Combine(Helper.SimPeDataPath, "release.nfo"));
			XmlNodeList XMLData = xmlfile.GetElementsByTagName("simperelease");
			for (int i = 0; i < XMLData.Count; i++)
			{
				XmlNode node = XMLData.Item(i);
				ParseSubNode(node);
			}
			shouldexist(false);
			confirmothers();
			if (allexist == false)
			{
				this.pictureBox1.Image = GetIcon.Fail;
				this.button1.Visible = false;
				this.lbVedict.ForeColor = System.Drawing.Color.Maroon;
				this.lbVedict.Text =
					"Critical Files Missing!\n SimPe needs to be re-installed under the current user profile";
			}
			else if (allgoody == false)
			{
				this.pictureBox1.Image = GetIcon.Fail;
				this.button1.Visible = true;
				this.lbVedict.ForeColor = System.Drawing.Color.Maroon;
				this.lbVedict.Text = "File(s) Missing or Wrong Version!\n";
				if (allthere == false)
					this.lbVedict.Text += "+ Unknown File(s) found! ";
				if (allsame == false)
					this.lbVedict.Text += "+ File(s) Have changed Size! ";
			}
			else if (allsame == false)
			{
				this.pictureBox1.Image = GetIcon.Warn;
				this.button1.Visible = true;
				this.lbVedict.ForeColor = System.Drawing.Color.Indigo;
				this.lbVedict.Text = "File(s) Have changed Size!";
				if (allthere == false)
					this.lbVedict.Text += "\nUnknown File(s) found!";
			}
			else if (allthere == false)
			{
				this.pictureBox1.Image = GetIcon.Warn;
				this.button1.Visible = true;
				this.lbVedict.ForeColor = System.Drawing.Color.MediumVioletRed;
				this.lbVedict.Text = "Unknown File(s) found!";
			}
			else
			{
				this.pictureBox1.Image = GetIcon.OK;
				this.lbVedict.ForeColor = System.Drawing.Color.Black;
				this.lbVedict.Text = "Everything appears normal";
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			removecrap();
			this.lbRelease.Font = new System.Drawing.Font("Tahoma", 10F);
			this.lbRelease.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lbRelease.Text = ReleaseDir;
			this.label1.Visible =
				this.label3.Visible =
				this.lbQaVer.Visible =
				this.label5.Visible =
				this.lv.Visible =
					true;
			this.button1.Visible =
				this.lbVedict.Visible =
				this.button2.Visible =
				this.lv2.Visible =
					false;
			System.Diagnostics.FileVersionInfo cver;
			cver = null;
			long csize = 0;
			listing = new ArrayList();
			listing.Clear();
			this.lv.Items.Clear();
			string[] files = System.IO.Directory.GetFiles(ReleaseDir, "*.dll");
			foreach (string file in files)
			{
				if (file.Contains("7zecmd") || file.Contains("whse.primitivewizards"))
					continue;
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
					continue;
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
					continue;
				listing.Add(new FileDescriptor(ReleaseDir, file));
			}

			foreach (FileDescriptor f in listing)
			{
				ListViewItem lvi = new ListViewItem();
				lvi.Text = f.FileName;
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
				this.pictureBox1.Image = GetIcon.OK;
				sw.Close();
			}
		}

		public static string ReleaseDir
		{
			get
			{
				return Helper.SimPePath;
			}
		}

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
			l = l >> 16;
			res = (l & 0xffff).ToString() + "." + res;
			l = l >> 16;
			res = (l & 0xffff).ToString() + "." + res;
			l = l >> 16;
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
				if (subnode.Name == "file")
					LoadFile(subnode);
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
					vir = subnode.InnerText;
				if (subnode.Name == "size")
					sise = subnode.InnerText;
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
					lvi.ForeColor = System.Drawing.Color.DarkRed;
					allgoody = false;
				}
				else if (s.Length != Convert.ToInt32(sise))
				{
					lvi.ForeColor = System.Drawing.Color.Indigo;
					allsame = false;
				}
				else
					lvi.ForeColor = System.Drawing.Color.Black;
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
				lvi.ForeColor = System.Drawing.Color.Red;
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
				allexist = false;
			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(
						Helper.SimPeDataPath,
						"additional_majors.xml"
					)
				)
			)
				allexist = false;
			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(
						Helper.SimPeDataPath,
						"additional_schools.xml"
					)
				)
			)
				allexist = false;
			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "expansions.xreg")
				)
			)
				allexist = false;
			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "expansions2.xreg")
				)
			)
				allexist = false;
			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "objddefinition.xml")
				)
			)
				allexist = false;
			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "semiglobals.xml")
				)
			)
				allexist = false;
			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "tgi.xml")
				)
			)
				allexist = false;
			if (
				!System.IO.File.Exists(
					System.IO.Path.Combine(Helper.SimPeDataPath, "txmtdefinition.xml")
				)
			)
				allexist = false;
			if (allexist == false)
			{
				lvt.Text = "Critical Data Files";
				lvt.SubItems.Add("0");
				lvt.SubItems.Add("Missing!");
				lvt.SubItems.Add("0");
				lvt.SubItems.Add("0");
				lvt.ForeColor = System.Drawing.Color.Red;
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
					continue;
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
					continue;
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
					continue;
				listing.Add(new FileDescriptor(ReleaseDir, file));
			}

			foreach (FileDescriptor f in listing)
			{
				if (this.lv2.FindItemWithText(f.FileName) == null)
				{
					ListViewItem lvi = new ListViewItem();
					lvi.Text = f.FileName;
					lvi.SubItems.Add("New File");
					lvi.SubItems.Add(VersionToString(f.Version));
					lvi.SubItems.Add("0");
					lvi.SubItems.Add(f.Size.ToString());
					lvi.ForeColor = System.Drawing.Color.MediumVioletRed;
					allthere = false;
					this.lv2.Items.Add(lvi);
					i++;
					if (i < 50)
						extracrap[i] = f.FileName;
				}
			}
		}

		private void removecrap()
		{
			if (allthere == false)
			{
				if (
					SimPe.Message.Show(
						"Settings Manager will either add the unknown files to the known file list or try to remove them.  Do you want Settings Manager to try to remove the Unknown File(s) ?",
						"Unknown File(s) Found",
						System.Windows.Forms.MessageBoxButtons.YesNo
					) == System.Windows.Forms.DialogResult.Yes
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
							try
							{
								System.IO.File.Delete(
									System.IO.Path.Combine(ReleaseDir, crap)
								);
							}
							catch { }
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
		public string FileName
		{
			get
			{
				return flname.Replace(infocheck.ReleaseDir.Trim() + @"\", "");
			}
		}

		System.Diagnostics.FileVersionInfo ver;
		public System.Diagnostics.FileVersionInfo Version
		{
			get
			{
				return ver;
			}
		}

		long size;
		public long Size
		{
			get
			{
				return size;
			}
		}

		bool exists;
		public bool Exists
		{
			get
			{
				return exists;
			}
		}

		public FileDescriptor(string basepath, string filename)
		{
			this.flname = filename.Trim();
			this.bp = basepath.Trim();
			if (!bp.EndsWith(@"\"))
				bp += @"\";
			exists = false;
			LoadInfo();
		}

		void LoadInfo()
		{
			if (!System.IO.File.Exists(flname))
				return;
			exists = true;

			System.IO.Stream s = System.IO.File.OpenRead(flname);
			size = s.Length;
			s.Close();

			ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(flname);
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
