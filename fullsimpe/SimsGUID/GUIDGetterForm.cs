// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Sims.GUID
{
	/// <summary>
	/// Zusammenfassung für GUIDGetterForm.
	/// </summary>
	public class GUIDGetterForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox tbusername;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox tbpassword;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tbUserGUID;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.ListBox lbnames;
		private System.Windows.Forms.LinkLabel lluse;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.TextBox tbobject;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbFree;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox tbemail;
		private System.Windows.Forms.LinkLabel linkLabel2;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GUIDGetterForm()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

			//
			// TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
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

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(GUIDGetterForm));
			this.label1 = new System.Windows.Forms.Label();
			this.tbusername = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbFree = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.tbUserGUID = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tbpassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lbnames = new System.Windows.Forms.ListBox();
			this.lluse = new System.Windows.Forms.LinkLabel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button2 = new System.Windows.Forms.Button();
			this.tbobject = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbemail = new System.Windows.Forms.TextBox();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			//
			// label1
			//
			this.label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label1.Location = new System.Drawing.Point(13, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbusername
			//
			this.tbusername.Location = new System.Drawing.Point(136, 24);
			this.tbusername.MaxLength = 200;
			this.tbusername.Name = "tbusername";
			this.tbusername.Size = new System.Drawing.Size(264, 21);
			this.tbusername.TabIndex = 1;
			this.tbusername.Text = "";
			this.tbusername.TextChanged += new System.EventHandler(
				this.tbusername_TextChanged
			);
			//
			// groupBox1
			//
			this.groupBox1.Controls.Add(this.linkLabel2);
			this.groupBox1.Controls.Add(this.tbemail);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.lbFree);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.linkLabel1);
			this.groupBox1.Controls.Add(this.tbUserGUID);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.tbpassword);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbusername);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(408, 168);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "User Data";
			//
			// lbFree
			//
			this.lbFree.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.lbFree.Location = new System.Drawing.Point(136, 144);
			this.lbFree.Name = "lbFree";
			this.lbFree.Size = new System.Drawing.Size(112, 17);
			this.lbFree.TabIndex = 10;
			this.lbFree.Text = "0";
			this.lbFree.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// label4
			//
			this.label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label4.Location = new System.Drawing.Point(16, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 17);
			this.label4.TabIndex = 9;
			this.label4.Text = "Available GUIDs:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// button3
			//
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button3.Location = new System.Drawing.Point(272, 136);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(128, 23);
			this.button3.TabIndex = 8;
			this.button3.Text = "Add GUID Block";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			//
			// linkLabel1
			//
			this.linkLabel1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(5, 4);
			this.linkLabel1.Location = new System.Drawing.Point(16, 112);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(112, 17);
			this.linkLabel1.TabIndex = 7;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "User GUID:";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.linkLabel1.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.UpdateGUID
				);
			//
			// tbUserGUID
			//
			this.tbUserGUID.Enabled = false;
			this.tbUserGUID.Location = new System.Drawing.Point(136, 112);
			this.tbUserGUID.MaxLength = 200;
			this.tbUserGUID.Name = "tbUserGUID";
			this.tbUserGUID.Size = new System.Drawing.Size(96, 21);
			this.tbUserGUID.TabIndex = 6;
			this.tbUserGUID.Text = "";
			//
			// button1
			//
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(272, 104);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Register new User";
			this.button1.Click += new System.EventHandler(this.RegisterNewUser);
			//
			// tbpassword
			//
			this.tbpassword.Location = new System.Drawing.Point(136, 48);
			this.tbpassword.MaxLength = 200;
			this.tbpassword.Name = "tbpassword";
			this.tbpassword.PasswordChar = '*';
			this.tbpassword.Size = new System.Drawing.Size(264, 21);
			this.tbpassword.TabIndex = 3;
			this.tbpassword.Text = "";
			//
			// label2
			//
			this.label2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label2.Location = new System.Drawing.Point(16, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Password:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// lbnames
			//
			this.lbnames.Location = new System.Drawing.Point(8, 8);
			this.lbnames.Name = "lbnames";
			this.lbnames.Size = new System.Drawing.Size(352, 134);
			this.lbnames.TabIndex = 3;
			this.lbnames.SelectedIndexChanged += new System.EventHandler(
				this.SelectedObject
			);
			//
			// lluse
			//
			this.lluse.AutoSize = true;
			this.lluse.Enabled = false;
			this.lluse.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.lluse.Location = new System.Drawing.Point(368, 128);
			this.lluse.Name = "lluse";
			this.lluse.Size = new System.Drawing.Size(26, 17);
			this.lluse.TabIndex = 4;
			this.lluse.TabStop = true;
			this.lluse.Text = "use";
			this.lluse.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.UseSelection
				);
			//
			// tabControl1
			//
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(8, 184);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(408, 176);
			this.tabControl1.TabIndex = 5;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(
				this.tabControl1_SelectedIndexChanged
			);
			//
			// tabPage1
			//
			this.tabPage1.Controls.Add(this.lbnames);
			this.tabPage1.Controls.Add(this.lluse);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(400, 150);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Existing Objects";
			//
			// tabPage2
			//
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Controls.Add(this.tbobject);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(400, 150);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "New Object";
			//
			// button2
			//
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(256, 56);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(128, 23);
			this.button2.TabIndex = 10;
			this.button2.Text = "Register Object";
			this.button2.Click += new System.EventHandler(this.RegisterObject);
			//
			// tbobject
			//
			this.tbobject.Location = new System.Drawing.Point(24, 32);
			this.tbobject.MaxLength = 200;
			this.tbobject.Name = "tbobject";
			this.tbobject.Size = new System.Drawing.Size(360, 21);
			this.tbobject.TabIndex = 9;
			this.tbobject.Text = "";
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label3.Location = new System.Drawing.Point(8, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 17);
			this.label3.TabIndex = 8;
			this.label3.Text = "Object Name:";
			//
			// label5
			//
			this.label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label5.Location = new System.Drawing.Point(16, 76);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 17);
			this.label5.TabIndex = 11;
			this.label5.Text = "eMail (optional):";
			this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbemail
			//
			this.tbemail.Location = new System.Drawing.Point(136, 72);
			this.tbemail.MaxLength = 200;
			this.tbemail.Name = "tbemail";
			this.tbemail.Size = new System.Drawing.Size(232, 21);
			this.tbemail.TabIndex = 12;
			this.tbemail.Text = "";
			this.tbemail.TextChanged += new System.EventHandler(
				this.tbemail_TextChanged
			);
			//
			// linkLabel2
			//
			this.linkLabel2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.linkLabel2.Location = new System.Drawing.Point(368, 72);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(32, 23);
			this.linkLabel2.TabIndex = 13;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Set";
			this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.linkLabel2.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.SetEmail
				);
			//
			// GUIDGetterForm
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(426, 368);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "GUIDGetterForm";
			this.Text = "Register Object GUID";
			this.Load += new System.EventHandler(this.GUIDGetterForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		Sims.GUID.Service.SimGUIDService service;
		uint retguid = 0;

		public static uint BuildGUID(uint userguid, uint objguid)
		{
			return (uint)(((userguid << 8) & 0xffffff00) + (objguid & 0x000000ff));
		}

		public static uint GetUserGuid(string username, string password)
		{
			Sims.GUID.Service.SimGUIDService service =
				new Sims.GUID.Service.SimGUIDService();
			uint userguid = 0xf000000;
			if (username.Trim() != "")
				userguid = (uint)service.loginUser(username, password);

			return userguid;
		}

		public uint GetNewGUID(string user, string password, uint defguid)
		{
			return GetNewGUID(user, password, defguid, null);
		}

		public uint GetNewGUID(string user, string password, uint defguid, string name)
		{
			lluse.Enabled = false;
			this.retguid = defguid;

			service = new Sims.GUID.Service.SimGUIDService();

			this.tbusername.Text = user;
			this.tbpassword.Text = password;
			this.tabControl1.SelectedIndex = 1;
			if (name == null)
				name = "";
			this.tbobject.Text = name;

			UpdateGUID(false);
			this.ShowDialog();

			return retguid;
		}

		void FreeGuids()
		{
			int free = 0;
			try
			{
				free = service.freeGuids(tbusername.Text, tbpassword.Text);
			}
			catch (Exception ex)
			{
				SimPe.Helper.ExceptionMessage(ex);
			}
			this.lbFree.Text = free.ToString();
			button2.Enabled = (free > 0);
			button3.Enabled = (free <= 0);
		}

		private void UpdateGUID(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			UpdateGUID(true);
		}

		private void UpdateGUID(bool all)
		{
			try
			{
				button2.Enabled = false;
				button3.Enabled = false;
				linkLabel2.Enabled = false;

				this.lbFree.Text = "0";
				uint userguid = 0xf000000;
				if (tbusername.Text != "")
					userguid = (uint)
						service.loginUser(tbusername.Text, tbpassword.Text);

				this.lbnames.Items.Clear();
				if (userguid != 0xf000000)
				{
					this.tbUserGUID.Text = "0x" + userguid.ToString("X");
					LoadProfile();

					button1.Enabled = (userguid == 0xf000000);
					linkLabel2.Enabled = true;
					FreeGuids();
					button3.Enabled = button3.Enabled && (!button1.Enabled);

					if (all)
					{
						//string res = service.listRegistredObjects(tbusername.Text, tbpassword.Text);
						string res = service.extEnumerateRegistredObjects(
							tbusername.Text,
							tbpassword.Text,
							0
						);
						System.Collections.Hashtable ht =
							Ambertation.Soap.PhpSerialized.GetHashtableFromSerializedArray(
								res
							);

						//this.lbnames.BeginUpdate();
						try
						{
							foreach (string s in ht.Values)
							{
								string[] parts = s.Split(" ".ToCharArray(), 3);
								if (parts.Length == 3)
								{
									//res = service.describeRegistredObjects(tbusername.Text, tbpassword.Text, guid);
									//System.Collections.Hashtable data = Ambertation.Soap.PhpSerialized.GetHashtableFromSerializedArray(res);
									uint objguid = Convert.ToUInt32(parts[0]);
									uint uguid = Convert.ToUInt32(parts[1]);
									objguid = BuildGUID(uguid, objguid);
									this.lbnames.Items.Add(
										new ObjectListItem(objguid, parts[2])
									);
									Application.DoEvents();
								}
								else
									throw new Exception(
										"Invalid Result while retriving Object Informations."
									);
							}
						}
						finally
						{
							//this.lbnames.EndUpdate();
						}
					}
				}
				else
					this.tbUserGUID.Text = "0x0";
			}
			catch (Exception ex)
			{
				SimPe.Helper.ExceptionMessage("", ex);
			}
		}

		void LoadProfile()
		{
			Hashtable ht =
				Ambertation.Soap.PhpSerialized.GetHashtableFromSerializedArray(
					service.getUserProfile(tbusername.Text, tbpassword.Text)
				);
			if (ht["email"] != null)
				this.tbemail.Text = ht["email"].ToString();
		}

		bool HaveEmail()
		{
			return (this.tbemail.Text.Trim() != "");
		}

		bool ValidEmail()
		{
			return ValidEmail(this.tbemail.Text);
		}

		bool ValidEmail(string email)
		{
			if (email.IndexOf("@") < 0)
				return false;
			if (email.IndexOf(":") >= 0)
				return false;
			if (email.IndexOf("/") >= 0)
				return false;
			if (email.IndexOf("\"") >= 0)
				return false;
			if (email.IndexOf("\\") >= 0)
				return false;
			if (email.IndexOf("'") >= 0)
				return false;

			return true;
		}

		private void RegisterNewUser(object sender, System.EventArgs e)
		{
			if (!HaveEmail())
				System.Windows.Forms.MessageBox.Show(
					"Giving an eMail Address is optional! However, you will not be able to recover your Password, if you do not specifiy a valid EMail address!"
				);
			else if (!ValidEmail())
			{
				System.Windows.Forms.MessageBox.Show(
					"The specified eMail Addess is not valid."
				);
				return;
			}

			if (
				System.Windows.Forms.MessageBox.Show(
					"You will only need one User Account int the GUID-Database from now on.\nWhenever you run out of GUIDs, you can simply add another GUID-Block.\n\nAre you sure you want to create a new User?",
					"Confirm",
					MessageBoxButtons.YesNo
				) == DialogResult.No
			)
				return;
			try
			{
				bool res = this.service.registerUser(tbusername.Text, tbpassword.Text);
				if (!res)
					System.Windows.Forms.MessageBox.Show(
						"Could not Register the specified User!\n\nPlease try another Username."
					);
				else
				{
					MessageBox.Show("Welcome " + tbusername.Text + ".");

					if (HaveEmail())
						this.SetEmail(null, null);
				}

				UpdateGUID(null, null);
			}
			catch (Exception ex)
			{
				SimPe.Helper.ExceptionMessage("", ex);
			}
		}

		private void UseSelection(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			if (this.lbnames.SelectedIndex < 0)
				return;
			ObjectListItem obj = (ObjectListItem)lbnames.Items[lbnames.SelectedIndex];
			retguid = obj.GUID;
			Close();
		}

		private void SelectedObject(object sender, System.EventArgs e)
		{
			lluse.Enabled = false;
			if (this.lbnames.SelectedIndex < 0)
				return;
			lluse.Enabled = true;
		}

		private void RegisterObject(object sender, System.EventArgs e)
		{
			try
			{
				uint userguid = 0xf000000;
				if (tbusername.Text != "")
					userguid = (uint)
						service.loginUser(tbusername.Text, tbpassword.Text);

				if (userguid == 0xf000000)
				{
					MessageBox.Show(
						"Your Login Data was not accepted by the GUID Database!"
					);
					return;
				}

				uint res = (uint)
					this.service.extRegisterObject(
						tbusername.Text,
						tbpassword.Text,
						this.tbobject.Text,
						0
					);
				if (res == 0x00)
				{
					MessageBox.Show(
						"Failed to register a new Object.\n\nMaybe you have no more free GUIDs?"
					);
					return;
				}

				this.retguid = res; //BuildGUID(userguid, res);
				Close();
			}
			catch (Exception ex)
			{
				SimPe.Helper.ExceptionMessage("", ex);
			}
		}

		private void GUIDGetterForm_Load(object sender, System.EventArgs e) { }

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (tabControl1.SelectedIndex == 0 && lbnames.Items.Count == 0)
			{
				this.BeginInvoke(
					new LinkLabelLinkClickedEventHandler(UpdateGUID),
					new object[2]
				);
			}
		}

		private void tbusername_TextChanged(object sender, System.EventArgs e)
		{
			/*if (tbusername.Text.Trim()!="") button1.Enabled = false;
			else button1.Enabled = true;*/
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!service.addUserRange(tbusername.Text, tbpassword.Text))
				{
					MessageBox.Show("Failed to register a new Range for this User.");
				}

				FreeGuids();
			}
			catch (Exception ex)
			{
				SimPe.Helper.ExceptionMessage(ex);
			}
		}

		private void tbemail_TextChanged(object sender, System.EventArgs e) { }

		private void SetEmail(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			if (!this.ValidEmail())
			{
				System.Windows.Forms.MessageBox.Show(
					"The specified eMail Addess is not valid."
				);
				return;
			}

			Hashtable ht = new Hashtable();
			ht["email"] = this.tbemail.Text.Trim();
			if (
				!service.changeUserProfile(
					tbusername.Text,
					tbpassword.Text,
					Ambertation.Soap.PhpSerialized.SerializeToArray(ht)
				)
			)
				System.Windows.Forms.MessageBox.Show("Could not set eMail Address!");
		}
	}
}
