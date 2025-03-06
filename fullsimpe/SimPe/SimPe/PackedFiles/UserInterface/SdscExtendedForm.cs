// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Collections.Generic;

using SimPe.Data;
using SimPe.PackedFiles.Swaf;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for SdscExtendedForm.
	/// </summary>
	public class SdscExtendedForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PropertyGrid pg;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton rbhex;
		private System.Windows.Forms.RadioButton rbdec;
		private System.Windows.Forms.RadioButton rbbin;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SdscExtendedForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();
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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(SdscExtendedForm)
				);
			pg = new System.Windows.Forms.PropertyGrid();
			panel1 = new System.Windows.Forms.Panel();
			rbhex = new System.Windows.Forms.RadioButton();
			rbdec = new System.Windows.Forms.RadioButton();
			rbbin = new System.Windows.Forms.RadioButton();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			SuspendLayout();
			//
			// pg
			//
			pg.Anchor =




								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							 | System.Windows.Forms.AnchorStyles.Left
						 | System.Windows.Forms.AnchorStyles.Right


			;
			pg.HelpVisible = false;
			pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			pg.Location = new System.Drawing.Point(8, 40);
			pg.Name = "pg";
			pg.Size = new System.Drawing.Size(688, 379);
			pg.TabIndex = 0;
			pg.ToolbarVisible = false;
			pg.PropertyValueChanged +=
				new System.Windows.Forms.PropertyValueChangedEventHandler(
					PropChanged
				);
			//
			// panel1
			//
			panel1.BackColor = System.Drawing.SystemColors.Control;
			panel1.Controls.Add(rbhex);
			panel1.Controls.Add(rbdec);
			panel1.Controls.Add(rbbin);
			panel1.Dock = System.Windows.Forms.DockStyle.Top;
			panel1.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold
			);
			//this.panel1.HeaderText = "";
			panel1.Location = new System.Drawing.Point(8, 8);
			panel1.Margin = new System.Windows.Forms.Padding(0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(688, 32);
			//this.panel1.StartColor = System.Drawing.SystemColors.Control;
			panel1.TabIndex = 1;
			//
			// rbhex
			//
			rbhex.Anchor =


						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right


			;
			rbhex.AutoSize = true;
			rbhex.BackColor = System.Drawing.Color.Transparent;
			rbhex.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			rbhex.ForeColor = System.Drawing.Color.Black;
			rbhex.Location = new System.Drawing.Point(576, 8);
			rbhex.Name = "rbhex";
			rbhex.Size = new System.Drawing.Size(107, 20);
			rbhex.TabIndex = 6;
			rbhex.Text = "Hexadecimal";
			rbhex.UseVisualStyleBackColor = false;
			rbhex.CheckedChanged += new EventHandler(DigitChanged);
			//
			// rbdec
			//
			rbdec.Anchor =


						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right


			;
			rbdec.AutoSize = true;
			rbdec.BackColor = System.Drawing.Color.Transparent;
			rbdec.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			rbdec.ForeColor = System.Drawing.Color.Black;
			rbdec.Location = new System.Drawing.Point(484, 8);
			rbdec.Name = "rbdec";
			rbdec.Size = new System.Drawing.Size(76, 20);
			rbdec.TabIndex = 5;
			rbdec.Text = "Decimal";
			rbdec.UseVisualStyleBackColor = false;
			rbdec.CheckedChanged += new EventHandler(DigitChanged);
			//
			// rbbin
			//
			rbbin.Anchor =


						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right


			;
			rbbin.AutoSize = true;
			rbbin.BackColor = System.Drawing.Color.Transparent;
			rbbin.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			rbbin.ForeColor = System.Drawing.Color.Black;
			rbbin.Location = new System.Drawing.Point(402, 8);
			rbbin.Name = "rbbin";
			rbbin.Size = new System.Drawing.Size(66, 20);
			rbbin.TabIndex = 4;
			rbbin.Text = "Binary";
			rbbin.UseVisualStyleBackColor = false;
			rbbin.CheckedChanged += new EventHandler(DigitChanged);
			//
			// button1
			//
			button1.Anchor =


						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right


			;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			button1.Location = new System.Drawing.Point(536, 427);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 2;
			button1.Text = "OK";
			button1.Click += new EventHandler(button1_Click);
			//
			// button2
			//
			button2.Anchor =


						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right


			;
			button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			button2.Location = new System.Drawing.Point(621, 427);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(75, 23);
			button2.TabIndex = 3;
			button2.Text = "Cancel";
			button2.Click += new EventHandler(button2_Click);
			//
			// SdscExtendedForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			ClientSize = new System.Drawing.Size(704, 457);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(panel1);
			Controls.Add(pg);
			Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Name = "SdscExtendedForm";
			Padding = new System.Windows.Forms.Padding(8);
			Text = "Extended Sdsc Browser";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		Ambertation.PropertyObjectBuilder pob;
		Hashtable names;
		bool propchanged;
		WantNameLoader wnl;
		short[] shortdata;

		string GetName(int i)
		{
			//string name = Helper.MinStrLength(i.ToString(), 4) + ": ";
			string name = Helper.HexString(0x0a + (2 * i));
			if (i > 0)
			{
				name += "; 0x" + Helper.HexString((ushort)(i - 1));
			}

			name += ": ";
			name += (string)names[i];

			return name;
		}

		void LoadWantTable(SDescVersions version)
		{
			wnl = null;
			if (version == SDescVersions.BaseGame)
			{
				string flname = System.IO.Path.Combine(
					PathProvider.Global.GetExpansion(Expansions.BaseGame).InstallFolder,
					@"TSData\Res\Objects\objects.package"
				);
				if (System.IO.File.Exists(flname))
				{
					Packages.File fl = Packages.File.LoadFromFile(flname);
					Interfaces.Files.IPackedFileDescriptor pfd = fl.FindFile(
						FileTypes.STR,
						0,
						0x7FE59FD0,
						0xc8
					);

					if (pfd != null)
					{
						Str str = new Str();
						str.ProcessData(pfd, fl);

						StrItemList list = str.LanguageItems(
							1
						);
						string xml = "<wantSimulator>" + Helper.lbr;
						xml += "  <persondata>" + Helper.lbr;
						for (int sid = 0; sid < list.Length; sid++)
						{
							StrToken si = list[sid];
							xml +=
								"    <persondata id=\""
								+ (sid + 1).ToString()
								+ "\" name=\""
								+ si.Title
								+ "\" /> "
								+ Helper.lbr;
						}
						xml += "  </persondata>" + Helper.lbr;
						xml += "</wantSimulator>" + Helper.lbr;

						wnl = new WantNameLoader(xml);
					}
				}
			}

			if (wnl == null)
			{
				// FileTable.FileIndex.Load(); // don't need this anymore
				wnl = new WantNameLoader(version);
			}
		}

		void ShowData(byte[] data)
		{
			shortdata = new short[((data.Length - 0xA) / 2) + 1];
			int j = 0;
			for (int i = 0xa; i < data.Length - 1; i += 2)
			{
				try
				{
					shortdata[j++] = BitConverter.ToInt16(data, i);
				}
				catch
				{
					break;
				}
			}

			// FileTable.FileIndex.Load(); // don't need this anymore

			propchanged = false;
			pg.SelectedObject = null;

			names = new Hashtable();
			IEnumerable<Data.Alias> ns = wnl.GetNames(WantType.Undefined);

			int max = -1;
			foreach (Interfaces.IAlias a in ns)
			{
				max = (int)Math.Max(a.Id, max);
				names[(int)a.Id] = a.Name;
			}
			max++;

			Hashtable ht = new Hashtable();
			for (int i = 0; i < Math.Min(max, shortdata.Length); i++)
			{
				string name = GetName(i);
				if (!ht.Contains(name))
				{
					ht.Add(name, shortdata[i]);
				}
			}

			pob = new Ambertation.PropertyObjectBuilder(ht);
			pg.SelectedObject = pob.Instance;
		}

		void UpdateData(byte[] data)
		{
			if (!propchanged)
			{
				return;
			}

			propchanged = false;

			try
			{
				Hashtable ht = pob.Properties;

				for (int i = 0; i < shortdata.Length; i++)
				{
					string name = GetName(i);
					if (ht.Contains(name))
					{
						shortdata[i] = (short)ht[name];
					}
				}

				int j = 0;
				for (int i = 0xa; i < data.Length - 1; i += 2)
				{
					try
					{
						byte[] d = BitConverter.GetBytes(shortdata[j++]);
						data[i] = d[0];
						data[i + 1] = d[1];
					}
					catch
					{
						break;
					}
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void DigitChanged(object sender, EventArgs e)
		{
			Ambertation.BaseChangeShort.DigitBase = rbhex.Checked ? 16 : rbbin.Checked ? 2 : 10;

			pg.Refresh();
		}

		private void PropChanged(
			object s,
			System.Windows.Forms.PropertyValueChangedEventArgs e
		)
		{
			propchanged = true;
		}

		/// <summary>
		/// Execute the Extended Form
		/// </summary>
		/// <param name="wrp">the sdsc you want to show</param>
		/// <returns>true, if something was changed</returns>
		public static bool Execute(SDesc wrp)
		{
			SdscExtendedForm f = new SdscExtendedForm();
			f.LoadWantTable(wrp.Version);
			byte[] data = wrp.CurrentStateData.ToArray();

			f.rbhex.Checked = Ambertation.BaseChangeShort.DigitBase == 16;
			f.rbbin.Checked = Ambertation.BaseChangeShort.DigitBase == 2;
			f.rbdec.Checked = !f.rbhex.Checked && !f.rbbin.Checked;
			f.propchanged = false;

			f.ShowData(data);
			f.ok = false;
			f.Text += " (version=" + wrp.Version.ToString() + ")";
			f.ShowDialog();

			if (f.ok)
			{
				f.UpdateData(data);
				wrp.FileDescriptor.UserData = data;
				wrp.ProcessData(wrp.FileDescriptor, wrp.Package);
			}
			return f.ok;
		}

		bool ok;

		private void button1_Click(object sender, EventArgs e)
		{
			ok = true;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
