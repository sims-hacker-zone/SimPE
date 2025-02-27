using System;
using System.Collections;

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
				if (components != null)
				{
					components.Dispose();
				}
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
			this.pg = new System.Windows.Forms.PropertyGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rbhex = new System.Windows.Forms.RadioButton();
			this.rbdec = new System.Windows.Forms.RadioButton();
			this.rbbin = new System.Windows.Forms.RadioButton();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			//
			// pg
			//
			this.pg.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.pg.HelpVisible = false;
			this.pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pg.Location = new System.Drawing.Point(8, 40);
			this.pg.Name = "pg";
			this.pg.Size = new System.Drawing.Size(688, 379);
			this.pg.TabIndex = 0;
			this.pg.ToolbarVisible = false;
			this.pg.PropertyValueChanged +=
				new System.Windows.Forms.PropertyValueChangedEventHandler(
					this.PropChanged
				);
			//
			// panel1
			//
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.rbhex);
			this.panel1.Controls.Add(this.rbdec);
			this.panel1.Controls.Add(this.rbbin);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold
			);
			//this.panel1.HeaderText = "";
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(688, 32);
			//this.panel1.StartColor = System.Drawing.SystemColors.Control;
			this.panel1.TabIndex = 1;
			//
			// rbhex
			//
			this.rbhex.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.rbhex.AutoSize = true;
			this.rbhex.BackColor = System.Drawing.Color.Transparent;
			this.rbhex.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.rbhex.ForeColor = System.Drawing.Color.Black;
			this.rbhex.Location = new System.Drawing.Point(576, 8);
			this.rbhex.Name = "rbhex";
			this.rbhex.Size = new System.Drawing.Size(107, 20);
			this.rbhex.TabIndex = 6;
			this.rbhex.Text = "Hexadecimal";
			this.rbhex.UseVisualStyleBackColor = false;
			this.rbhex.CheckedChanged += new EventHandler(this.DigitChanged);
			//
			// rbdec
			//
			this.rbdec.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.rbdec.AutoSize = true;
			this.rbdec.BackColor = System.Drawing.Color.Transparent;
			this.rbdec.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.rbdec.ForeColor = System.Drawing.Color.Black;
			this.rbdec.Location = new System.Drawing.Point(484, 8);
			this.rbdec.Name = "rbdec";
			this.rbdec.Size = new System.Drawing.Size(76, 20);
			this.rbdec.TabIndex = 5;
			this.rbdec.Text = "Decimal";
			this.rbdec.UseVisualStyleBackColor = false;
			this.rbdec.CheckedChanged += new EventHandler(this.DigitChanged);
			//
			// rbbin
			//
			this.rbbin.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.rbbin.AutoSize = true;
			this.rbbin.BackColor = System.Drawing.Color.Transparent;
			this.rbbin.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.rbbin.ForeColor = System.Drawing.Color.Black;
			this.rbbin.Location = new System.Drawing.Point(402, 8);
			this.rbbin.Name = "rbbin";
			this.rbbin.Size = new System.Drawing.Size(66, 20);
			this.rbbin.TabIndex = 4;
			this.rbbin.Text = "Binary";
			this.rbbin.UseVisualStyleBackColor = false;
			this.rbbin.CheckedChanged += new EventHandler(this.DigitChanged);
			//
			// button1
			//
			this.button1.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(536, 427);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "OK";
			this.button1.Click += new EventHandler(this.button1_Click);
			//
			// button2
			//
			this.button2.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(621, 427);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Cancel";
			this.button2.Click += new EventHandler(this.button2_Click);
			//
			// SdscExtendedForm
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(704, 457);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pg);
			this.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SdscExtendedForm";
			this.Padding = new System.Windows.Forms.Padding(8);
			this.Text = "Extended Sdsc Browser";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		Ambertation.PropertyObjectBuilder pob;
		Hashtable names;
		bool propchanged;
		Plugin.WantNameLoader wnl;
		short[] shortdata;

		string GetName(int i)
		{
			//string name = Helper.MinStrLength(i.ToString(), 4) + ": ";
			string name = Helper.HexString(0x0a + 2 * i);
			if (i > 0)
			{
				name += "; 0x" + (Helper.HexString((ushort)(i - 1)));
			}

			name += ": ";
			name += ((string)names[i]);

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
						0x53545223,
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

						wnl = new Plugin.WantNameLoader(xml);
					}
				}
			}

			if (wnl == null)
			{
				// FileTable.FileIndex.Load(); // don't need this anymore
				wnl = new Plugin.WantNameLoader(version);
			}
		}

		void ShowData(byte[] data)
		{
			shortdata = new short[(data.Length - 0xA) / 2 + 1];
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
			this.pg.SelectedObject = null;

			names = new Hashtable();
			ArrayList ns = wnl.GetNames(Plugin.WantType.Undefined);

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
			this.pg.SelectedObject = pob.Instance;
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
			if (rbhex.Checked)
			{
				Ambertation.BaseChangeShort.DigitBase = 16;
			}
			else if (rbbin.Checked)
			{
				Ambertation.BaseChangeShort.DigitBase = 2;
			}
			else
			{
				Ambertation.BaseChangeShort.DigitBase = 10;
			}

			this.pg.Refresh();
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

			f.rbhex.Checked = (Ambertation.BaseChangeShort.DigitBase == 16);
			f.rbbin.Checked = (Ambertation.BaseChangeShort.DigitBase == 2);
			f.rbdec.Checked = (!f.rbhex.Checked && !f.rbbin.Checked);
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
