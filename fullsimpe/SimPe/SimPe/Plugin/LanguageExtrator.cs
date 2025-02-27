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
				components?.Dispose();
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

			pntheme.BackgroundImage = GetImage.GetExpansionLogo(
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
			pntheme = new Panel();
			Progress = new LabeledProgressBar();
			Language = new ComboBox();
			btCome = new Button();
			btGo = new Button();
			btclean = new Button();
			lbdone = new Label();
			lbselect = new Label();
			pntheme.SuspendLayout();
			SuspendLayout();
			//
			// Language
			//
			Language.Font = new System.Drawing.Font("Lucida Console", 9.75F);
			Language.Location = new System.Drawing.Point(215, 4);
			Language.Name = "Language";
			Language.Size = new System.Drawing.Size(188, 21);
			Language.TabIndex = 6;
			Language.SelectedIndexChanged += new EventHandler(
				Language_SelectedIndexChanged
			);
			//
			// pntheme
			//
			pntheme.BackColor = System.Drawing.Color.Transparent;
			pntheme.Controls.Add(btclean);
			pntheme.Controls.Add(btCome);
			pntheme.Controls.Add(Progress);
			pntheme.Controls.Add(lbdone);
			pntheme.Controls.Add(btGo);
			pntheme.Controls.Add(lbselect);
			pntheme.Controls.Add(Language);
			pntheme.Dock = DockStyle.Fill;
			pntheme.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			pntheme.Location = new System.Drawing.Point(0, 0);
			pntheme.Name = "pntheme";
			pntheme.Size = new System.Drawing.Size(624, 441);
			pntheme.TabIndex = 15;
			//
			// btCome
			//
			btCome.Location = new System.Drawing.Point(479, 3);
			btCome.Name = "btCome";
			btCome.Size = new System.Drawing.Size(68, 23);
			btCome.TabIndex = 11;
			btCome.Text = "Import";
			btCome.UseVisualStyleBackColor = true;
			btCome.Click += new EventHandler(btCome_Click);
			//
			// Progress
			//
			Progress.Anchor =



							AnchorStyles.Bottom
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			Progress.BackColor = System.Drawing.Color.Transparent;
			Progress.Location = new System.Drawing.Point(4, 422);
			Progress.Maximum = 100;
			Progress.Name = "Progress";
			Progress.SelectedColor = System.Drawing.Color.YellowGreen;
			Progress.Size = new System.Drawing.Size(616, 16);
			Progress.TabIndex = 10;
			Progress.TokenCount = 2;
			Progress.UnselectedColor = System.Drawing.Color.Black;
			Progress.Value = 0;
			//
			// lbdone
			//
			lbdone.AutoSize = true;
			lbdone.Font = new System.Drawing.Font(
				"Lucida Console",
				18F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbdone.Location = new System.Drawing.Point(426, 30);
			lbdone.Name = "lbdone";
			lbdone.Size = new System.Drawing.Size(145, 24);
			lbdone.TabIndex = 9;
			lbdone.Text = "All Done!";
			lbdone.Visible = false;
			//
			// btGo
			//
			btGo.Location = new System.Drawing.Point(407, 3);
			btGo.Name = "btGo";
			btGo.Size = new System.Drawing.Size(68, 23);
			btGo.TabIndex = 8;
			btGo.Text = "Extract";
			btGo.UseVisualStyleBackColor = true;
			btGo.Click += new EventHandler(btGo_Click);
			//
			// lbselect
			//
			lbselect.AutoSize = true;
			lbselect.Font = new System.Drawing.Font(
				"Lucida Console",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbselect.Location = new System.Drawing.Point(4, 4);
			lbselect.Name = "lbselect";
			lbselect.Size = new System.Drawing.Size(207, 26);
			lbselect.TabIndex = 7;
			lbselect.Text = "Select the Language to\r\nExtract from or Import to";
			//
			// btclean
			//
			btclean.Location = new System.Drawing.Point(551, 3);
			btclean.Name = "btclean";
			btclean.Size = new System.Drawing.Size(68, 23);
			btclean.TabIndex = 12;
			btclean.Text = "Clean All";
			btclean.UseVisualStyleBackColor = true;
			btclean.Click += new EventHandler(btclean_Click);
			//
			// LanguageExtrator
			//
			AutoScaleMode = AutoScaleMode.Inherit;
			AutoScroll = true;
			ClientSize = new System.Drawing.Size(624, 441);
			Controls.Add(pntheme);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MinimumSize = new System.Drawing.Size(640, 480);
			Name = "LanguageExtrator";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Single Language Extractor / Importer";
			pntheme.ResumeLayout(false);
			pntheme.PerformLayout();
			ResumeLayout(false);
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
			lbdone.Visible = false;
			saveFiles();
			if (okay)
			{
				lbdone.Text = "All Done!";
				lbdone.Visible = true;
			}
		}

		private void btCome_Click(object sender, EventArgs e)
		{
			Progress.Value = 0;
			lbdone.Visible = false;
			getFiles();
			if (okay)
			{
				lbdone.Text = "All Done!";
				lbdone.Visible = true;
			}
		}

		private void btclean_Click(object sender, EventArgs e)
		{
			cleanim();
			lbdone.Text = "Cleaned!";
			lbdone.Visible = true;
		}

		private void saveFiles()
		{
			string parf;
			FolderBrowserDialog fbd =
				new FolderBrowserDialog();
			if (fbd.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			Language.Enabled =
				btGo.Enabled =
				btCome.Enabled =
				btclean.Enabled =
					false;
			string floder =
				fbd.SelectedPath + "\\" + languageString[currentLanguage - 1];
			if (!Directory.Exists(floder))
			{
				Directory.CreateDirectory(floder);
			}

			Interfaces.Files.IPackedFileDescriptor[] pfdc =
				package.FindFiles(0x43545353); //CTSS
			Interfaces.Files.IPackedFileDescriptor[] pfdm =
				package.FindFiles(0x54544173); //Pie String (TTAB)
			Interfaces.Files.IPackedFileDescriptor[] pfdt =
				package.FindFiles(0x53545223); //STR#
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
				str.ProcessData(pfd, package);
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
				str.ProcessData(pfd, package);
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
				str.ProcessData(pfd, package);
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
			if (fbd.ShowDialog() != DialogResult.OK)
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
				lbdone.Text = "None Found!";
				lbdone.Visible = true;
				return;
			}
			Language.Enabled =
				btGo.Enabled =
				btCome.Enabled =
				btclean.Enabled =
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
					package.FindFile(tipe, 0, groop, insta);
				if (pfd != null)
				{
					PackedFiles.Wrapper.StrWrapper str =
						new PackedFiles.Wrapper.StrWrapper();
					str.ProcessData(pfd, package);
					str.ImportLanguage(currentLanguage, file);
					str.SynchronizeUserData();
				}
			}
			okay = true;
		}

		private void cleanim()
		{
			Language.Enabled =
				btGo.Enabled =
				btCome.Enabled =
				btclean.Enabled =
					false;
			Interfaces.Files.IPackedFileDescriptor[] pfdc =
				package.FindFiles(0x43545353); //CTSS
			Interfaces.Files.IPackedFileDescriptor[] pfdm =
				package.FindFiles(0x54544173); //Pie String (TTAB)
			Interfaces.Files.IPackedFileDescriptor[] pfdt =
				package.FindFiles(0x53545223); //STR#
			Progress.Maximum = pfdc.Length + pfdm.Length + pfdt.Length;

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfdc)
			{
				PackedFiles.Wrapper.StrWrapper str =
					new PackedFiles.Wrapper.StrWrapper();
				str.ProcessData(pfd, package);
				str.CleanHim();
				str.SynchronizeUserData();
				Progress.Value += 1;
			}

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfdm)
			{
				PackedFiles.Wrapper.StrWrapper str =
					new PackedFiles.Wrapper.StrWrapper();
				str.ProcessData(pfd, package);
				str.CleanHim();
				str.SynchronizeUserData();
				Progress.Value += 1;
			}

			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfdt)
			{
				PackedFiles.Wrapper.StrWrapper str =
					new PackedFiles.Wrapper.StrWrapper();
				str.ProcessData(pfd, package);
				str.CleanHim();
				str.SynchronizeUserData();
				Progress.Value += 1;
			}
			Language.Enabled = btGo.Enabled = btCome.Enabled = true;
		}
	}
}
