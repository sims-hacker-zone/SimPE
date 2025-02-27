using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Ambertation.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for Form.
	/// </summary>
	public class LanguageExtrator : Form
	{
		#region Windows Form Designer generated code

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		public LanguageExtrator()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			languageString = new List<string>(
				pjse.BhavWiz.readStr(pjse.GS.BhavStr.Languages)
			);
			languageString.RemoveAt(0);

			this.pntheme.BackgroundImage = GetImage.GetExpansionLogo(
				PathProvider.Global.Latest.Version
			);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(LanguageExtrator)
				);
			this.pntheme = new Panel();
			this.Progress = new LabeledProgressBar();
			this.Language = new ComboBox();
			this.btCome = new Button();
			this.btGo = new Button();
			this.btclean = new Button();
			this.lbdone = new Label();
			this.lbselect = new Label();
			this.pntheme.SuspendLayout();
			this.SuspendLayout();
			//
			// Language
			//
			this.Language.Font = new System.Drawing.Font("Lucida Console", 9.75F);
			this.Language.Location = new System.Drawing.Point(215, 4);
			this.Language.Name = "Language";
			this.Language.Size = new System.Drawing.Size(188, 21);
			this.Language.TabIndex = 6;
			this.Language.SelectedIndexChanged += new EventHandler(
				this.Language_SelectedIndexChanged
			);
			//
			// pntheme
			//
			this.pntheme.BackColor = System.Drawing.Color.Transparent;
			this.pntheme.Controls.Add(this.btclean);
			this.pntheme.Controls.Add(this.btCome);
			this.pntheme.Controls.Add(this.Progress);
			this.pntheme.Controls.Add(this.lbdone);
			this.pntheme.Controls.Add(this.btGo);
			this.pntheme.Controls.Add(this.lbselect);
			this.pntheme.Controls.Add(this.Language);
			this.pntheme.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pntheme.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.pntheme.Location = new System.Drawing.Point(0, 0);
			this.pntheme.Name = "pntheme";
			this.pntheme.Size = new System.Drawing.Size(624, 441);
			this.pntheme.TabIndex = 15;
			//
			// btCome
			//
			this.btCome.Location = new System.Drawing.Point(479, 3);
			this.btCome.Name = "btCome";
			this.btCome.Size = new System.Drawing.Size(68, 23);
			this.btCome.TabIndex = 11;
			this.btCome.Text = "Import";
			this.btCome.UseVisualStyleBackColor = true;
			this.btCome.Click += new EventHandler(this.btCome_Click);
			//
			// Progress
			//
			this.Progress.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Bottom
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.Progress.BackColor = System.Drawing.Color.Transparent;
			this.Progress.Location = new System.Drawing.Point(4, 422);
			this.Progress.Maximum = 100;
			this.Progress.Name = "Progress";
			this.Progress.SelectedColor = System.Drawing.Color.YellowGreen;
			this.Progress.Size = new System.Drawing.Size(616, 16);
			this.Progress.TabIndex = 10;
			this.Progress.TokenCount = 2;
			this.Progress.UnselectedColor = System.Drawing.Color.Black;
			this.Progress.Value = 0;
			//
			// lbdone
			//
			this.lbdone.AutoSize = true;
			this.lbdone.Font = new System.Drawing.Font(
				"Lucida Console",
				18F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.lbdone.Location = new System.Drawing.Point(426, 30);
			this.lbdone.Name = "lbdone";
			this.lbdone.Size = new System.Drawing.Size(145, 24);
			this.lbdone.TabIndex = 9;
			this.lbdone.Text = "All Done!";
			this.lbdone.Visible = false;
			//
			// btGo
			//
			this.btGo.Location = new System.Drawing.Point(407, 3);
			this.btGo.Name = "btGo";
			this.btGo.Size = new System.Drawing.Size(68, 23);
			this.btGo.TabIndex = 8;
			this.btGo.Text = "Extract";
			this.btGo.UseVisualStyleBackColor = true;
			this.btGo.Click += new EventHandler(this.btGo_Click);
			//
			// lbselect
			//
			this.lbselect.AutoSize = true;
			this.lbselect.Font = new System.Drawing.Font(
				"Lucida Console",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.lbselect.Location = new System.Drawing.Point(4, 4);
			this.lbselect.Name = "lbselect";
			this.lbselect.Size = new System.Drawing.Size(207, 26);
			this.lbselect.TabIndex = 7;
			this.lbselect.Text = "Select the Language to\r\nExtract from or Import to";
			//
			// btclean
			//
			this.btclean.Location = new System.Drawing.Point(551, 3);
			this.btclean.Name = "btclean";
			this.btclean.Size = new System.Drawing.Size(68, 23);
			this.btclean.TabIndex = 12;
			this.btclean.Text = "Clean All";
			this.btclean.UseVisualStyleBackColor = true;
			this.btclean.Click += new EventHandler(this.btclean_Click);
			//
			// LanguageExtrator
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(624, 441);
			this.Controls.Add(this.pntheme);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(640, 480);
			this.Name = "LanguageExtrator";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Single Language Extractor / Importer";
			this.pntheme.ResumeLayout(false);
			this.pntheme.PerformLayout();
			this.ResumeLayout(false);
		}

		private ComboBox Language;
		private Panel pntheme;
		private LabeledProgressBar Progress;
		private Label lbselect;
		private Label lbdone;
		private Button btGo;
		private Button btCome;
		private Button btclean;

		private Packages.GeneratableFile package;
		private List<String> languageString;
		private byte currentLanguage = 1;
		private bool okay = false;
		#endregion

		public Interfaces.Plugin.IToolResult Execute(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package,
			Interfaces.IProviderRegistry prov
		)
		{
			Language.DataSource = languageString;
			Language.SelectedIndex = currentLanguage - 1;
			this.package = (Packages.GeneratableFile)package;
			ShowDialog();
			return new ToolResult(okay, okay);
		}

		private void Language_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = ((ComboBox)sender).SelectedIndex;
			currentLanguage = (byte)(index + 1);
		}

		private void btGo_Click(object sender, EventArgs e)
		{
			Progress.Value = 0;
			this.lbdone.Visible = false;
			saveFiles();
			if (okay)
			{
				this.lbdone.Text = "All Done!";
				this.lbdone.Visible = true;
			}
		}

		private void btCome_Click(object sender, EventArgs e)
		{
			Progress.Value = 0;
			this.lbdone.Visible = false;
			getFiles();
			if (okay)
			{
				this.lbdone.Text = "All Done!";
				this.lbdone.Visible = true;
			}
		}

		private void btclean_Click(object sender, EventArgs e)
		{
			cleanim();
			this.lbdone.Text = "Cleaned!";
			this.lbdone.Visible = true;
		}

		private void saveFiles()
		{
			string parf;
			FolderBrowserDialog fbd =
				new FolderBrowserDialog();
			if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
			{
				return;
			}

			this.Language.Enabled =
				this.btGo.Enabled =
				this.btCome.Enabled =
				this.btclean.Enabled =
					false;
			string floder =
				fbd.SelectedPath + "\\" + languageString[currentLanguage - 1];
			if (!Directory.Exists(floder))
			{
				Directory.CreateDirectory(floder);
			}

			Interfaces.Files.IPackedFileDescriptor[] pfdc =
				this.package.FindFiles(0x43545353); //CTSS
			Interfaces.Files.IPackedFileDescriptor[] pfdm =
				this.package.FindFiles(0x54544173); //Pie String (TTAB)
			Interfaces.Files.IPackedFileDescriptor[] pfdt =
				this.package.FindFiles(0x53545223); //STR#
			Progress.Maximum = pfdc.Length + pfdm.Length + pfdt.Length;

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfdc)
			{
				parf =
					"catalogue-"
					+ Helper.HexString(pfd.Group)
					+ "-"
					+ Helper.HexString(pfd.Instance);
				PackedFiles.Wrapper.StrWrapper str =
					new PackedFiles.Wrapper.StrWrapper();
				str.ProcessData(pfd, this.package);
				if (str.HasLanguage(currentLanguage))
				{
					str.ExportLanguage(currentLanguage, floder + "\\" + parf + ".txt");
				}

				Progress.Value += 1;
			}

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfdm)
			{
				parf =
					"menu-"
					+ Helper.HexString(pfd.Group)
					+ "-"
					+ Helper.HexString(pfd.Instance);
				PackedFiles.Wrapper.StrWrapper str =
					new PackedFiles.Wrapper.StrWrapper();
				str.ProcessData(pfd, this.package);
				if (str.HasLanguage(currentLanguage))
				{
					str.ExportLanguage(currentLanguage, floder + "\\" + parf + ".txt");
				}

				Progress.Value += 1;
			}

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfdt)
			{
				parf =
					"text-"
					+ Helper.HexString(pfd.Group)
					+ "-"
					+ Helper.HexString(pfd.Instance);
				PackedFiles.Wrapper.StrWrapper str =
					new PackedFiles.Wrapper.StrWrapper();
				str.ProcessData(pfd, this.package);
				if (str.HasLanguage(currentLanguage))
				{
					str.ExportLanguage(currentLanguage, floder + "\\" + parf + ".txt");
				}

				Progress.Value += 1;
			}
			okay = true;
		}

		private void getFiles()
		{
			uint tipe;
			uint groop;
			uint insta;
			string twine;
			FolderBrowserDialog fbd =
				new FolderBrowserDialog();
			if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
			{
				return;
			}

			string[] textfiles = Directory.GetFiles(
				fbd.SelectedPath,
				"*.txt",
				SearchOption.TopDirectoryOnly
			);
			if (textfiles.Length < 1)
			{
				this.lbdone.Text = "None Found!";
				this.lbdone.Visible = true;
				return;
			}
			this.Language.Enabled =
				this.btGo.Enabled =
				this.btCome.Enabled =
				this.btclean.Enabled =
					false;
			Progress.Maximum = textfiles.Length;

			foreach (string file in textfiles)
			{
				Progress.Value += 1;
				twine = Path.GetFileNameWithoutExtension(file);
				if (twine.StartsWith("catalogue-"))
				{
					tipe = 0x43545353;
				}
				else if (twine.StartsWith("menu-"))
				{
					tipe = 0x54544173;
				}
				else if (twine.StartsWith("text-"))
				{
					tipe = 0x53545223;
				}
				else
				{
					break;
				}

				string[] bits = twine.Split(new char[] { '-' });
				groop = Helper.HexStringToUInt(bits[1]);
				insta = Helper.HexStringToUInt(bits[2]);
				Interfaces.Files.IPackedFileDescriptor pfd =
					this.package.FindFile(tipe, 0, groop, insta);
				if (pfd != null)
				{
					PackedFiles.Wrapper.StrWrapper str =
						new PackedFiles.Wrapper.StrWrapper();
					str.ProcessData(pfd, this.package);
					str.ImportLanguage(currentLanguage, file);
					str.SynchronizeUserData();
				}
			}
			okay = true;
		}

		private void cleanim()
		{
			this.Language.Enabled =
				this.btGo.Enabled =
				this.btCome.Enabled =
				this.btclean.Enabled =
					false;
			Interfaces.Files.IPackedFileDescriptor[] pfdc =
				this.package.FindFiles(0x43545353); //CTSS
			Interfaces.Files.IPackedFileDescriptor[] pfdm =
				this.package.FindFiles(0x54544173); //Pie String (TTAB)
			Interfaces.Files.IPackedFileDescriptor[] pfdt =
				this.package.FindFiles(0x53545223); //STR#
			Progress.Maximum = pfdc.Length + pfdm.Length + pfdt.Length;

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfdc)
			{
				PackedFiles.Wrapper.StrWrapper str =
					new PackedFiles.Wrapper.StrWrapper();
				str.ProcessData(pfd, this.package);
				str.CleanHim();
				str.SynchronizeUserData();
				Progress.Value += 1;
			}

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfdm)
			{
				PackedFiles.Wrapper.StrWrapper str =
					new PackedFiles.Wrapper.StrWrapper();
				str.ProcessData(pfd, this.package);
				str.CleanHim();
				str.SynchronizeUserData();
				Progress.Value += 1;
			}

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfdt)
			{
				PackedFiles.Wrapper.StrWrapper str =
					new PackedFiles.Wrapper.StrWrapper();
				str.ProcessData(pfd, this.package);
				str.CleanHim();
				str.SynchronizeUserData();
				Progress.Value += 1;
			}
			this.Language.Enabled = this.btGo.Enabled = this.btCome.Enabled = true;
		}
	}
}
