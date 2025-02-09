/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Wrapper;
using SimPe.Data;
using SimPe.PackedFiles.Wrapper;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for BconForm.
	/// </summary>
	public class StrForm : System.Windows.Forms.Form, IPackedFileUI
	{
		#region Form elements
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btcommit;
		private System.Windows.Forms.ComboBox cblanguage;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox gbstr;
		private System.Windows.Forms.LinkLabel lldelall;
		private System.Windows.Forms.LinkLabel lldelete;
		private System.Windows.Forms.LinkLabel llchangeall;
		private System.Windows.Forms.LinkLabel lladdall;
		private System.Windows.Forms.LinkLabel lladd;
		private System.Windows.Forms.LinkLabel llcommit;
		private System.Windows.Forms.RichTextBox rtbdesc;
		private System.Windows.Forms.RichTextBox rtbvalue;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListBox lbtexts;
		private System.Windows.Forms.TextBox tbformat;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.LinkLabel llcreate;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Panel strPanel;
        private Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public StrForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			this.llcreate.Visible = Helper.WindowsRegistry.HiddenMode;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Str
		internal Str wrapper;
		#endregion

		#region IPackedFileUI Member
		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle
		{
			get
			{
				return strPanel;
			}
		}

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <remarks>this.Tag is used to let TextChanged event handlers know the change is being
		/// made internally rather than by the users.</remarks>
		/// <param name="wrp">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrp)
		{
			wrapper = (Str)wrp;
			Tag = true;

			tbformat.Text = "0x"+Helper.HexString((ushort)wrapper.Format);

			lbtexts.Items.Clear();

			llcommit.Enabled = false;
            llchangeall.Enabled = false;
            btcommit.Enabled = false;

			rtbvalue.Text = "";
			rtbdesc.Text = "";
			gbstr.Text = "";

			cblanguage.Items.Clear();
			cblanguage.Sorted = false;

			foreach (StrLanguage s in wrapper.Languages)
				cblanguage.Items.Add(s);

			cblanguage.Sorted = true;
            if (cblanguage.Items.Count > 0) cblanguage.SelectedIndex = 0;

			Tag = null;
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StrForm));
            this.strPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btcommit = new System.Windows.Forms.Button();
            this.cblanguage = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbstr = new System.Windows.Forms.GroupBox();
            this.lldelall = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.lldelete = new System.Windows.Forms.LinkLabel();
            this.llchangeall = new System.Windows.Forms.LinkLabel();
            this.lladdall = new System.Windows.Forms.LinkLabel();
            this.lladd = new System.Windows.Forms.LinkLabel();
            this.llcommit = new System.Windows.Forms.LinkLabel();
            this.rtbdesc = new System.Windows.Forms.RichTextBox();
            this.rtbvalue = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbtexts = new System.Windows.Forms.ListBox();
            this.tbformat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.llcreate = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.strPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbstr.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // strPanel
            // 
            resources.ApplyResources(this.strPanel, "strPanel");
            this.strPanel.BackColor = System.Drawing.Color.Transparent;
            this.strPanel.Controls.Add(this.button2);
            this.strPanel.Controls.Add(this.btcommit);
            this.strPanel.Controls.Add(this.cblanguage);
            this.strPanel.Controls.Add(this.label4);
            this.strPanel.Controls.Add(this.groupBox1);
            this.strPanel.Controls.Add(this.tbformat);
            this.strPanel.Controls.Add(this.label1);
            this.strPanel.Controls.Add(this.panel2);
            this.strPanel.Controls.Add(this.llcreate);
            this.strPanel.Controls.Add(this.linkLabel1);
            this.strPanel.Name = "strPanel";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.Click += new System.EventHandler(this.CleanFile);
            // 
            // btcommit
            // 
            resources.ApplyResources(this.btcommit, "btcommit");
            this.btcommit.Name = "btcommit";
            this.btcommit.Click += new System.EventHandler(this.CommitStr);
            // 
            // cblanguage
            // 
            this.cblanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cblanguage, "cblanguage");
            this.cblanguage.Name = "cblanguage";
            this.cblanguage.SelectedIndexChanged += new System.EventHandler(this.LanguageChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.gbstr);
            this.groupBox1.Controls.Add(this.splitter1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // gbstr
            // 
            this.gbstr.BackColor = System.Drawing.Color.Transparent;
            this.gbstr.Controls.Add(this.lldelall);
            this.gbstr.Controls.Add(this.button1);
            this.gbstr.Controls.Add(this.lldelete);
            this.gbstr.Controls.Add(this.llchangeall);
            this.gbstr.Controls.Add(this.lladdall);
            this.gbstr.Controls.Add(this.lladd);
            this.gbstr.Controls.Add(this.llcommit);
            this.gbstr.Controls.Add(this.rtbdesc);
            this.gbstr.Controls.Add(this.rtbvalue);
            this.gbstr.Controls.Add(this.label3);
            this.gbstr.Controls.Add(this.label2);
            resources.ApplyResources(this.gbstr, "gbstr");
            this.gbstr.Name = "gbstr";
            this.gbstr.TabStop = false;
            // 
            // lldelall
            // 
            resources.ApplyResources(this.lldelall, "lldelall");
            this.lldelall.Name = "lldelall";
            this.lldelall.TabStop = true;
            this.lldelall.UseCompatibleTextRendering = true;
            this.lldelall.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DelInAll);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.Click += new System.EventHandler(this.ClearStr);
            // 
            // lldelete
            // 
            resources.ApplyResources(this.lldelete, "lldelete");
            this.lldelete.Name = "lldelete";
            this.lldelete.TabStop = true;
            this.lldelete.UseCompatibleTextRendering = true;
            this.lldelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.StrDelete);
            // 
            // llchangeall
            // 
            resources.ApplyResources(this.llchangeall, "llchangeall");
            this.llchangeall.Name = "llchangeall";
            this.llchangeall.TabStop = true;
            this.llchangeall.UseCompatibleTextRendering = true;
            this.llchangeall.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChangeInAllLanguages);
            // 
            // lladdall
            // 
            resources.ApplyResources(this.lladdall, "lladdall");
            this.lladdall.Name = "lladdall";
            this.lladdall.TabStop = true;
            this.lladdall.UseCompatibleTextRendering = true;
            this.lladdall.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddToAll);
            // 
            // lladd
            // 
            resources.ApplyResources(this.lladd, "lladd");
            this.lladd.Name = "lladd";
            this.lladd.TabStop = true;
            this.lladd.UseCompatibleTextRendering = true;
            this.lladd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.StrAdd);
            // 
            // llcommit
            // 
            resources.ApplyResources(this.llcommit, "llcommit");
            this.llcommit.Name = "llcommit";
            this.llcommit.TabStop = true;
            this.llcommit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CommitChanges);
            // 
            // rtbdesc
            // 
            resources.ApplyResources(this.rtbdesc, "rtbdesc");
            this.rtbdesc.Name = "rtbdesc";
            this.rtbdesc.TextChanged += new System.EventHandler(this.ChangeText);
            // 
            // rtbvalue
            // 
            resources.ApplyResources(this.rtbvalue, "rtbvalue");
            this.rtbvalue.Name = "rtbvalue";
            this.rtbvalue.TextChanged += new System.EventHandler(this.ChangeText);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lbtexts);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // lbtexts
            // 
            resources.ApplyResources(this.lbtexts, "lbtexts");
            this.lbtexts.Name = "lbtexts";
            this.lbtexts.SelectedIndexChanged += new System.EventHandler(this.StringSelected);
            // 
            // tbformat
            // 
            resources.ApplyResources(this.tbformat, "tbformat");
            this.tbformat.Name = "tbformat";
            this.tbformat.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // llcreate
            // 
            resources.ApplyResources(this.llcreate, "llcreate");
            this.llcreate.Name = "llcreate";
            this.llcreate.TabStop = true;
            this.llcreate.UseCompatibleTextRendering = true;
            this.llcreate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateTextFile);
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // StrForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.strPanel);
            this.Name = "StrForm";
            this.strPanel.ResumeLayout(false);
            this.strPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gbstr.ResumeLayout(false);
            this.gbstr.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}


		private void StrDelete(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (lbtexts.SelectedIndex<0) return;

			try
			{
				Str wrp = (Str)wrapper;
				StrToken item = (StrToken)lbtexts.Items[lbtexts.SelectedIndex];
				wrp.Remove(item);

				lbtexts.Items.Remove(item);
                LanguageChanged(null, null);
                btcommit.Enabled = true;

				wrp.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void DelInAll(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (lbtexts.SelectedIndex<0) return;

			try
			{
				Str wrp = (Str)wrapper;

				foreach (StrItemList list in wrp.Lines.Values)
				{
					if (list.Count>lbtexts.SelectedIndex)
						list.RemoveAt(lbtexts.SelectedIndex);
				}

				lbtexts.Items.Remove(lbtexts.Items[lbtexts.SelectedIndex]);
                LanguageChanged(null, null);
                btcommit.Enabled = true;
				wrp.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void CreateTextFile(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				string list = "";
				for (int i=0; i < lbtexts.Items.Count; i++)
				{
					StrToken item = (StrToken)this.lbtexts.Items[i];
					list += "0x" + i.ToString("X") +": " + item.Title + " ("+item.Description+")"+Helper.lbr;
				}

                this.btcommit.Enabled = true;
				Clipboard.SetDataObject(list, true);
			}
			catch (Exception) { }
		}

		private void ClearStr(object sender, System.EventArgs e)
		{

			try
			{
				Str wrp = (Str)wrapper;
				wrp.Items = new StrItemList();
				this.cblanguage.Items.Clear();

				StrLanguageList lngs = new StrLanguageList();
				for (int i=1; i<45; i++)
				{
					StrLanguage lng = new StrLanguage((byte)i);
					cblanguage.Items.Add(lng);
					lngs.Add(lng);
				}
				wrp.Languages = lngs;
                this.cblanguage.SelectedIndex = 0;
                this.btcommit.Enabled = true;
				LanguageChanged(null, null);
			}
			catch (Exception) { }
        }

        private void CleanFile(object sender, System.EventArgs e)
        {
            try
            {
                StrLanguageList ls = new StrLanguageList();
                this.cblanguage.Items.Clear();
                this.cblanguage.Sorted = false;
                for (byte i = 1; i < 45; i++)
                {
                    ls.Add(new StrLanguage(i));
                    this.cblanguage.Items.Add(ls[ls.Count - 1]);
                }
                Str wrp = (Str)wrapper;
                wrp.Languages = ls;
                wrp.Changed = true;
                this.cblanguage.Sorted = true;

                for (int i = 0; i < cblanguage.Items.Count; i++)
                {
                    this.cblanguage.SelectedIndex = i;
                    foreach (StrToken s in wrp.LanguageItems((StrLanguage)cblanguage.Items[cblanguage.SelectedIndex])) lbtexts.Items.Add(s);
                    if (i < 11 || i == 12 || i == 13 || i == 14 || i == 15 || i == 16 || i == 17 || i == 18 || i == 19 || i == 25 || i == 27 || i == 34)
                    {
                        for (int f = 0; f < lbtexts.Items.Count; f++)
                        {
                            lbtexts.SelectedIndex = f;
                            StrToken b = (StrToken)lbtexts.Items[lbtexts.SelectedIndex];
                            b.Description = null;
                        }
                    }
                    else
                    {
                        for (int f = 0; f < lbtexts.Items.Count; f++)
                        {
                            lbtexts.SelectedIndex = f;
                            StrToken b = (StrToken)lbtexts.Items[lbtexts.SelectedIndex];
                            b.Title = null;
                            b.Description = null;
                        }
                    }
                }
                this.cblanguage.SelectedIndex = 0;
                this.lbtexts.SelectedIndex = 0;
                CommitStr(null, null);
            }
            catch (Exception) { }
            
        }

		private void LanguageChanged(object sender, System.EventArgs e)
		{
			llcommit.Enabled = false;
			lbtexts.Items.Clear();
			if (this.cblanguage.SelectedIndex<0) return;

			try
			{
				Str wrp = (Str)wrapper;
				foreach (StrToken s in wrp.LanguageItems((StrLanguage)cblanguage.Items[cblanguage.SelectedIndex])) lbtexts.Items.Add(s);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}

		}

		private void StringSelected(object sender, System.EventArgs e)
		{
			if (this.Tag!=null) return;
			llcommit.Enabled = false;
			llchangeall.Enabled = false;
			lldelete.Enabled = false;
			lldelall.Enabled = false;
			if (lbtexts.SelectedIndex<0) return;

			this.Tag = true;
			try
			{
				StrToken s = (StrToken)lbtexts.Items[lbtexts.SelectedIndex];

				rtbvalue.Text = s.Title;
				rtbdesc.Text = s.Description;
				llcommit.Enabled = true;
				llchangeall.Enabled = true;
				lldelete.Enabled = true;
                lldelall.Enabled = true;
                btcommit.Enabled = true;

				gbstr.Text = "0x"+Helper.HexString((ushort)lbtexts.SelectedIndex);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
			finally
			{
				this.Tag = null;
			}
		}

		private void StrAdd(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			lbtexts.SelectedIndex = -1;
			CommitChanges(null, null);
            lbtexts.SelectedIndex = lbtexts.Items.Count - 1;
            btcommit.Enabled = true;
		}

		private void CommitChanges(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (this.Tag!=null) return;


			llcommit.Enabled = (lbtexts.SelectedIndex<0);
            if (this.cblanguage.SelectedIndex < 0) return;

			this.Tag = true;
			try
			{
				Str wrp = (Str)wrapper;

				if (lbtexts.SelectedIndex < 0)
				{
					StrToken s = new StrToken(lbtexts.Items.Count, (StrLanguage)cblanguage.Items[cblanguage.SelectedIndex]
						,rtbvalue.Text
						,rtbdesc.Text
						);
					wrp.Add(s);
					lbtexts.Items.Add(s);
				}
				else
				{
					StrToken s = (StrToken)lbtexts.Items[lbtexts.SelectedIndex];
					s.Title = rtbvalue.Text;
					s.Description = rtbdesc.Text;
					lbtexts.Items[lbtexts.SelectedIndex] = s;	// is that needed?
				}

				wrp.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
			finally
			{
                this.Tag = null;
                this.btcommit.Enabled = false;
			}
		}

		private void CommitStr(object sender, System.EventArgs e)
		{
			try
			{
				if (this.lbtexts.SelectedIndex>=0) CommitChanges(null, null);
				Str wrp = (Str)wrapper;
				//foreach (StrItem s in wrp.LanguageItems((StrLanguage)cblanguage.Items[cblanguage.SelectedIndex])) lbtexts.Items.Add(s);
				wrp.SynchronizeUserData();
				MessageBox.Show(Localization.Manager.GetString("commited"));
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errwritingfile"), ex);
			}
		}

		private void ChangeInAllLanguages(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			int curIndex = lbtexts.SelectedIndex;			// The current language string index
			if (curIndex < 0) return;
			try
			{
				Str wrp = (Str)wrapper;
				StrToken s = (StrToken)lbtexts.Items[curIndex];	// The StrItem in the current language (lbtexts.Items)

				s.Title = rtbvalue.Text;
				s.Description = rtbdesc.Text;

				foreach (StrLanguage lng in wrp.Languages)
				{
					if (lng == null) continue;

					// Add empty StrItem entries to pad to the string index we want to change, if needed
					while (wrp.LanguageItems(lng).Length <= curIndex)
						wrp.Add(new StrToken(wrp.LanguageItems(lng).Length, lng, "", ""));

					StrItemList sis = wrp.LanguageItems(lng);
					sis[curIndex].Title = s.Title;
					sis[curIndex].Description = s.Description;
				}

                LanguageChanged(null, null);
                btcommit.Enabled = true;
				wrp.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void AddToAll(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Str wrp = (Str)wrapper;

				//find longest String List
				int count = 0;
				foreach (StrLanguage lng in wrp.Languages) count = Math.Max(count, wrp.LanguageItems(lng).Length);

				foreach (StrLanguage lng in wrp.Languages)
				{
					if (lng == null) continue;
					while (wrp.LanguageItems(lng).Length < count)
						wrp.Add(new StrToken(wrp.LanguageItems(lng).Length, lng, "", ""));

					wrp.Add(new StrToken(wrp.LanguageItems(lng).Length, lng, rtbvalue.Text, rtbdesc.Text));
				}

                LanguageChanged(null, null);
                btcommit.Enabled = true;
				wrp.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errconvert"), ex);
			}
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			StrLanguageList ls = new StrLanguageList();
			this.cblanguage.Items.Clear();
			this.cblanguage.Sorted = false;
			for (byte i=1; i<45; i++)
			{
				ls.Add(new StrLanguage(i));
				this.cblanguage.Items.Add(ls[ls.Count-1]);
			}

			Str wrp = (Str)wrapper;
			wrp.Languages = ls;
			wrp.Changed = true;

			this.cblanguage.Sorted = true;
            if (this.cblanguage.Items.Count > 0) this.cblanguage.SelectedIndex = 0;
		}

		private void ChangeText(object sender, System.EventArgs e)
		{
			if (lbtexts.SelectedIndex<0) return;
            CommitChanges(null, null);
            btcommit.Enabled = true;
		}
		#endregion

    }
}
