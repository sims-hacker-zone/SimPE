// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for RenameForm.
	/// </summary>
	public class RenameForm : Form
	{
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private ListView lv;
		private Label label1;
		private TextBox tbname;
		private LinkLabel llname;
		private Button button1;
		private CheckBox cbv2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RenameForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			cbv2.Visible = Helper.WindowsRegistry.HiddenMode;
		}

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(RenameForm));
			lv = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			columnHeader3 = new ColumnHeader();
			label1 = new Label();
			tbname = new TextBox();
			llname = new LinkLabel();
			button1 = new Button();
			cbv2 = new CheckBox();
			SuspendLayout();
			//
			// lv
			//
			lv.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lv.Columns.AddRange(
				new ColumnHeader[]
				{
					columnHeader1,
					columnHeader2,
					columnHeader3,
				}
			);
			lv.FullRowSelect = true;
			lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			lv.HideSelection = false;
			lv.LabelEdit = true;
			lv.Location = new System.Drawing.Point(16, 88);
			lv.MultiSelect = false;
			lv.Name = "lv";
			lv.Size = new System.Drawing.Size(682, 208);
			lv.TabIndex = 0;
			lv.View = View.Details;
			//
			// columnHeader1
			//
			columnHeader1.Text = "Name";
			columnHeader1.Width = 336;
			//
			// columnHeader2
			//
			columnHeader2.Text = "Type";
			//
			// columnHeader3
			//
			columnHeader3.Text = "original Name";
			columnHeader3.Width = 256;
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(16, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(83, 17);
			label1.TabIndex = 1;
			label1.Text = "ModelName:";
			//
			// tbname
			//
			tbname.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbname.Location = new System.Drawing.Point(24, 32);
			tbname.Name = "tbname";
			tbname.Size = new System.Drawing.Size(674, 21);
			tbname.TabIndex = 2;
			tbname.Text = "";
			//
			// llname
			//
			llname.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			llname.AutoSize = true;
			llname.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			llname.Location = new System.Drawing.Point(647, 56);
			llname.Name = "llname";
			llname.Size = new System.Drawing.Size(49, 17);
			llname.TabIndex = 4;
			llname.TabStop = true;
			llname.Text = "Update";
			llname.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					UpdateNames
				);
			//
			// button1
			//
			button1.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			button1.FlatStyle = FlatStyle.System;
			button1.Location = new System.Drawing.Point(623, 304);
			button1.Name = "button1";
			button1.TabIndex = 5;
			button1.Text = "OK";
			button1.Click += new EventHandler(button1_Click);
			//
			// cbv2
			//
			cbv2.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Left


			;
			cbv2.FlatStyle = FlatStyle.System;
			cbv2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbv2.Location = new System.Drawing.Point(16, 304);
			cbv2.Name = "cbv2";
			cbv2.Size = new System.Drawing.Size(280, 24);
			cbv2.TabIndex = 6;
			cbv2.Text = "University Ready v2 (sug. by Numenor)";
			//
			// RenameForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(712, 332);
			Controls.Add(cbv2);
			Controls.Add(button1);
			Controls.Add(llname);
			Controls.Add(tbname);
			Controls.Add(label1);
			Controls.Add(lv);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			FormBorderStyle =
				FormBorderStyle
				.SizableToolWindow;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Name = "RenameForm";
			Text = "Scenegraph rename Wizard";
			ResumeLayout(false);
		}
		#endregion

		/// <summary>
		/// Find the Modelname of the Original Object
		/// </summary>
		/// <param name="package">The Package containing the Data</param>
		/// <returns>The Modelname</returns>
		public static string FindMainOldName(
			Interfaces.Files.IPackageFile package
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFiles(
				Data.MetaData.STRING_FILE
			);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				if (pfd.Instance == 0x85)
				{
					PackedFiles.Wrapper.Str str =
						new PackedFiles.Wrapper.Str();
					str.ProcessData(pfd, package);

					PackedFiles.Wrapper.StrItemList sil = str.LanguageItems(1);
					if (sil.Length > 1)
					{
						return sil[1].Title;
					}
					else if (str.Items.Length > 1)
					{
						return str.Items[1].Title;
					}
				}
			}

			pfds = package.FindFiles(0x4C697E5A);
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
			{
				PackedFiles.Wrapper.Cpf cpf = new PackedFiles.Wrapper.Cpf();
				cpf.ProcessData(pfd, package);

				if (cpf.GetSaveItem("modelName").StringValue.Trim() != "")
				{
					return cpf.GetSaveItem("modelName").StringValue.Trim();
				}
			}

			return "SimPe";
		}

		/// <summary>
		/// Replaces an old unique portion with a new Name
		/// </summary>
		/// <param name="name"></param>
		/// <param name="newunique"></param>
		/// <param name="force">if true, the unique name will be added, even if no unique item was found</param>
		/// <returns></returns>
		public static string ReplaceOldUnique(string name, string newunique, bool force)
		{
			newunique = newunique.Replace("_", ".");
			string[] parts = name.Split("[".ToCharArray(), 2);
			if (parts.Length > 1)
			{
				string[] ends = parts[1].Split("]".ToCharArray(), 2);
				if (ends.Length > 1)
				{
					return parts[0] + newunique + ends[1];
				}
			}

			//make sure the uniqe part is added to the ModelName
			if (force)
			{
				parts = name.Split("_".ToCharArray(), 2);

				name = "";
				bool first = true;
				foreach (string s in parts)
				{
					if (!first)
					{
						name += "_";
					}

					name += s;
					if (first)
					{
						first = false;
						name += "-" + newunique;
					}
				}
			}

			return name;
		}

		/// <summary>
		/// Creates a Name Map
		/// </summary>
		/// <param name="auto"></param>
		/// <param name="package"></param>
		/// <param name="lv"></param>
		/// <param name="username"></param>
		/// <returns></returns>
		public static Hashtable GetNames(
			bool auto,
			Interfaces.Files.IPackageFile package,
			ListView lv,
			string username
		)
		{
			username = username.Replace("_", ".");

			lv?.Items.Clear();

			Hashtable ht = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
			string old = Hashes.StripHashFromName(
				FindMainOldName(package).ToLower().Trim()
			);
			if (old.EndsWith("_cres"))
			{
				old = old.Substring(0, old.Length - 5);
			}

			//load all Rcol Files
			foreach (uint type in Data.MetaData.RcolList)
			{
				Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFiles(type);
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					Rcol rcol = new GenericRcol(null, false);
					rcol.ProcessData(pfd, package);
					string newname = Hashes.StripHashFromName(
						rcol.FileName.Trim().ToLower()
					);
					if (newname == "")
					{
						newname = "SimPE_dummy_" + username;
					}

					if (old == null)
					{
						old = "";
					}

					if (old == "")
					{
						old = " ";
					}

					if (auto)
					{
						string secname = "";
						if (newname.EndsWith("_anim"))
						{
							string mun = username;
							//mun = mun.Replace("[", "").Replace("]", "").Replace(".", "").Replace("-", "");
							secname = newname.Replace(old, "");
							int pos = secname.IndexOf("-");
							if (pos >= 0 && pos < secname.Length - 1)
							{
								pos = secname.IndexOf("-", pos + 1);
							}

							secname = pos >= 0 && pos < secname.Length - 1
								? secname.Substring(0, pos + 1)
									+ mun
									+ "-"
									+ secname.Substring(pos + 1)
								: "";
						}
						if (secname == "")
						{
							secname = newname.Replace(old, username);
						}

						if ((secname == newname) && (old != username.Trim().ToLower()))
						{
							secname = username + "-" + secname;
						}

						newname = secname;
					}

					if (lv != null)
					{
						ListViewItem lvi = new ListViewItem(
							Hashes.StripHashFromName(newname)
						);
						lvi.SubItems.Add(Data.MetaData.FindTypeAlias(type).shortname);
						lvi.SubItems.Add(Hashes.StripHashFromName(rcol.FileName));

						lv.Items.Add(lvi);
					}

					ht[Hashes.StripHashFromName(rcol.FileName.Trim().ToLower())] =
						Hashes.StripHashFromName(newname);
				}
			}

			return ht;
		}

		protected Hashtable GetReplacementMap()
		{
			Hashtable ht = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
			foreach (ListViewItem lvi in lv.Items)
			{
				string oldname = lvi.SubItems[2].Text.Trim().ToLower();
				string newname = lvi.Text.Trim();

				string ext = "_" + lvi.SubItems[1].Text.Trim().ToLower();
				if (!newname.ToLower().EndsWith(ext))
				{
					newname += ext;
				}

				try
				{
					ht.Add(
						Hashes.StripHashFromName(oldname),
						Hashes.StripHashFromName(newname)
					);
				}
				catch (ArgumentException ex)
				{
					throw new Warning(
						ex.Message,
						"Two or more Resources in the package have the same name, which is not allowed! See http://ambertation.de/simpeforum/viewtopic.php?t=1078 for Details.",
						ex
					);
				}
			}

			return ht;
		}

		/// <summary>
		/// Creates a unique Name
		/// </summary>
		/// <returns>a Unique String</returns>
		public static string GetUniqueName()
		{
			return GetUniqueName(false);
		}

		/// <summary>
		/// Creates a unique Name
		/// </summary>
		/// <param name="retnull">Return null, if no GUID-DB-username was available</param>
		/// <returns>a Unique String or null</returns>
		public static string GetUniqueName(bool retnull)
		{
			string uname = Helper.WindowsRegistry.Username.Trim();
			if (uname == "")
			{
				if (retnull)
				{
					return null;
				}

				uname = Guid.NewGuid().ToString();
			}
			else
			{
				uname = uname
					.Replace(" ", "-")
					.Replace("_", "-")
					.Replace("~", "-")
					.Replace("!", ".")
					.Replace("#", ".")
					.Replace("[", "(");
				DateTime now = DateTime.Now;
				string time =
					now.Day.ToString()
					+ "."
					+ now.Month.ToString()
					+ "."
					+ now.Year.ToString()
					+ "-"
					+ now.Hour.ToString("x")
					+ now.Minute.ToString("x")
					+ now.Second.ToString("x");
				uname += "-" + time;
			}

			return "[" + uname.Trim() + "]";
		}

		Interfaces.Files.IPackageFile package;
		static string current_unique;

		public static Hashtable Execute(
			Interfaces.Files.IPackageFile package,
			bool uniquename,
			ref FixVersion ver
		)
		{
			RenameForm rf = new RenameForm
			{
				ok = false,
				package = package
			};
			rf.cbv2.Checked = ver == FixVersion.UniversityReady2;

			string old = Hashes.StripHashFromName(
				FindMainOldName(package).ToLower().Trim()
			);
			current_unique = GetUniqueName();
			if (old.EndsWith("_cres"))
			{
				old = old.Substring(0, old.Length - 5);
			}

			if (uniquename)
			{
				string name = ReplaceOldUnique(old, current_unique, true);
				if (name == old)
				{
					name = old + current_unique;
				}

				rf.tbname.Text = name;
			}
			else
			{
				rf.tbname.Text = old;
			}

			GetNames(uniquename, package, rf.lv, rf.tbname.Text);
			rf.ShowDialog();

			if (rf.ok)
			{
				ver = rf.cbv2.Checked ? FixVersion.UniversityReady2 : FixVersion.UniversityReady;

				return rf.GetReplacementMap();
			}
			else
			{
				return null;
			}
		}

		private void UpdateNames(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			GetNames(true, package, lv, tbname.Text);
		}

		bool ok;

		private void button1_Click(object sender, EventArgs e)
		{
			ok = true;
			Close();
		}
	}
}
