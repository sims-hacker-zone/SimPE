/***************************************************************************
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SimPe.Data;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Wrapper;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Summary description for Elements2.
	/// </summary>
	public class Elements2 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Elements2()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			if (Helper.WindowsRegistry.UseBigIcons)
			{
				this.lbcpf.Font = new System.Drawing.Font("Verdana", 12F);
				this.rtbcpfname.Font = this.rtbcpf.Font = new System.Drawing.Font(
					"Verdana",
					11F
				);
			}
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
				new System.ComponentModel.ComponentResourceManager(typeof(Elements2));
			this.btprev = new System.Windows.Forms.Button();
			this.cbtype = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.rtbcpfname = new System.Windows.Forms.RichTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.rtbcpf = new System.Windows.Forms.RichTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.lbcpf = new System.Windows.Forms.ListBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.tbNref = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbnrefhash = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.NrefPanel = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.CpfPanel = new System.Windows.Forms.Panel();
			this.pbicon = new System.Windows.Forms.PictureBox();
			this.llcpfadd = new System.Windows.Forms.LinkLabel();
			this.llcpfchange = new System.Windows.Forms.LinkLabel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.NrefPanel.SuspendLayout();
			this.CpfPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbicon)).BeginInit();
			this.SuspendLayout();
			//
			// btprev
			//
			resources.ApplyResources(this.btprev, "btprev");
			this.btprev.Name = "btprev";
			this.btprev.Click += new System.EventHandler(this.btprev_Click);
			//
			// cbtype
			//
			resources.ApplyResources(this.cbtype, "cbtype");
			this.cbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbtype.Name = "cbtype";
			this.cbtype.SelectedIndexChanged += new System.EventHandler(
				this.CpfAutoChange
			);
			//
			// label8
			//
			resources.ApplyResources(this.label8, "label8");
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Name = "label8";
			//
			// rtbcpfname
			//
			resources.ApplyResources(this.rtbcpfname, "rtbcpfname");
			this.rtbcpfname.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbcpfname.Name = "rtbcpfname";
			this.rtbcpfname.TextChanged += new System.EventHandler(this.CpfAutoChange);
			//
			// label7
			//
			resources.ApplyResources(this.label7, "label7");
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Name = "label7";
			//
			// rtbcpf
			//
			resources.ApplyResources(this.rtbcpf, "rtbcpf");
			this.rtbcpf.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbcpf.Name = "rtbcpf";
			this.rtbcpf.TextChanged += new System.EventHandler(this.CpfAutoChange);
			//
			// label6
			//
			resources.ApplyResources(this.label6, "label6");
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Name = "label6";
			//
			// lbcpf
			//
			resources.ApplyResources(this.lbcpf, "lbcpf");
			this.lbcpf.Name = "lbcpf";
			this.lbcpf.SelectedIndexChanged += new System.EventHandler(
				this.CpfItemSelect
			);
			//
			// panel5
			//
			resources.ApplyResources(this.panel5, "panel5");
			//this.panel5.CanCommit = true;
			this.panel5.Name = "panel5";
			//this.panel5.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.CpfCommit);
			//
			// tbNref
			//
			resources.ApplyResources(this.tbNref, "tbNref");
			this.tbNref.Name = "tbNref";
			this.tbNref.TextChanged += new System.EventHandler(this.tbnref_TextChanged);
			//
			// label10
			//
			resources.ApplyResources(this.label10, "label10");
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.Name = "label10";
			//
			// tbnrefhash
			//
			resources.ApplyResources(this.tbnrefhash, "tbnrefhash");
			this.tbnrefhash.Name = "tbnrefhash";
			this.tbnrefhash.ReadOnly = true;
			//
			// label9
			//
			resources.ApplyResources(this.label9, "label9");
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Name = "label9";
			//
			// NrefPanel
			//
			this.NrefPanel.BackColor = System.Drawing.Color.Transparent;
			//this.NrefPanel.BackgroundImageAnchor = System.Windows.Forms.Panel.ImageLayout.CenterTop;
			//this.NrefPanel.BackgroundImageLocation = new System.Drawing.Point(0, 24);
			//this.NrefPanel.BackgroundImageZoomToFit = true;
			this.NrefPanel.Controls.Add(this.panel4);
			this.NrefPanel.Controls.Add(this.tbnrefhash);
			this.NrefPanel.Controls.Add(this.tbNref);
			this.NrefPanel.Controls.Add(this.label9);
			this.NrefPanel.Controls.Add(this.label10);
			resources.ApplyResources(this.NrefPanel, "NrefPanel");
			this.NrefPanel.Name = "NrefPanel";
			//
			// panel4
			//
			resources.ApplyResources(this.panel4, "panel4");
			//this.panel4.CanCommit = true;
			this.panel4.Name = "panel4";
			//this.panel4.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.NrefCommit);
			//
			// CpfPanel
			//
			this.CpfPanel.BackColor = System.Drawing.Color.Transparent;
			this.CpfPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CpfPanel.Controls.Add(this.pbicon);
			this.CpfPanel.Controls.Add(this.lbcpf);
			this.CpfPanel.Controls.Add(this.panel5);
			this.CpfPanel.Controls.Add(this.btprev);
			this.CpfPanel.Controls.Add(this.rtbcpf);
			this.CpfPanel.Controls.Add(this.llcpfadd);
			this.CpfPanel.Controls.Add(this.llcpfchange);
			this.CpfPanel.Controls.Add(this.linkLabel1);
			this.CpfPanel.Controls.Add(this.rtbcpfname);
			this.CpfPanel.Controls.Add(this.cbtype);
			this.CpfPanel.Controls.Add(this.label6);
			this.CpfPanel.Controls.Add(this.label8);
			this.CpfPanel.Controls.Add(this.label7);
			//this.CpfPanel.EndColour = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.CpfPanel, "CpfPanel");
			//this.CpfPanel.MiddleColour = System.Drawing.SystemColors.Control;
			this.CpfPanel.Name = "CpfPanel";
			//this.CpfPanel.StartColour = System.Drawing.SystemColors.Control;
			//
			// pbicon
			//
			resources.ApplyResources(this.pbicon, "pbicon");
			this.pbicon.Name = "pbicon";
			this.pbicon.TabStop = false;
			//
			// llcpfadd
			//
			resources.ApplyResources(this.llcpfadd, "llcpfadd");
			this.llcpfadd.BackColor = System.Drawing.Color.Transparent;
			this.llcpfadd.Name = "llcpfadd";
			this.llcpfadd.TabStop = true;
			this.llcpfadd.UseCompatibleTextRendering = true;
			this.llcpfadd.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddCpf);
			//
			// llcpfchange
			//
			resources.ApplyResources(this.llcpfchange, "llcpfchange");
			this.llcpfchange.BackColor = System.Drawing.Color.Transparent;
			this.llcpfchange.Name = "llcpfchange";
			this.llcpfchange.TabStop = true;
			this.llcpfchange.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.CpfChange
				);
			//
			// linkLabel1
			//
			resources.ApplyResources(this.linkLabel1, "linkLabel1");
			this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabStop = true;
			this.linkLabel1.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.DeleteCpf
				);
			//
			// Elements2
			//
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.NrefPanel);
			this.Controls.Add(this.CpfPanel);
			this.Name = "Elements2";
			this.NrefPanel.ResumeLayout(false);
			this.NrefPanel.PerformLayout();
			this.CpfPanel.ResumeLayout(false);
			this.CpfPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbicon)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private System.Windows.Forms.Panel panel5;
		internal System.Windows.Forms.ListBox lbcpf;
		internal System.Windows.Forms.RichTextBox rtbcpf;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		internal System.Windows.Forms.RichTextBox rtbcpfname;
		private System.Windows.Forms.Label label8;
		internal System.Windows.Forms.ComboBox cbtype;
		private System.Windows.Forms.Panel panel4;
		internal System.Windows.Forms.Label label9;
		internal System.Windows.Forms.TextBox tbnrefhash;
		internal System.Windows.Forms.Label label10;
		internal System.Windows.Forms.Button btprev;
		internal System.Windows.Forms.TextBox tbNref;
		internal System.Windows.Forms.Panel NrefPanel;
		internal System.Windows.Forms.Panel CpfPanel;
		internal System.Windows.Forms.LinkLabel linkLabel1;
		internal System.Windows.Forms.LinkLabel llcpfadd;
		internal System.Windows.Forms.LinkLabel llcpfchange;
		private PictureBox pbicon;

		#region Str Attributes
		internal IFileWrapperSaveExtension wrapper;

		#endregion

		#region CPF
		private void CpfItemSelect(object sender, System.EventArgs e)
		{
			if (rtbcpfname.Tag != null)
				return;
			this.llcpfchange.Enabled = false;
			if (this.lbcpf.SelectedIndex < 0)
				return;
			this.llcpfchange.Enabled = true;

			rtbcpfname.Tag = true;
			try
			{
				CpfItem item = (CpfItem)lbcpf.Items[lbcpf.SelectedIndex];
				this.rtbcpfname.Text = item.Name;
				for (int i = 0; i < cbtype.Items.Count; i++)
				{
					cbtype.SelectedIndex = -1;
					Data.MetaData.DataTypes type = (Data.MetaData.DataTypes)
						cbtype.Items[i];
					if (type == item.Datatype)
					{
						cbtype.SelectedIndex = i;
						break;
					}
				}

				switch (item.Datatype)
				{
					case Data.MetaData.DataTypes.dtSingle:
					{
						rtbcpf.Text = item.SingleValue.ToString();
						break;
					}
					case Data.MetaData.DataTypes.dtInteger:
					{
						rtbcpf.Text = "0x" + Helper.HexString((uint)item.IntegerValue);
						break;
					}
					case Data.MetaData.DataTypes.dtUInteger:
					{
						rtbcpf.Text = "0x" + Helper.HexString((uint)item.UIntegerValue);
						break;
					}
					case Data.MetaData.DataTypes.dtBoolean:
					{
						if (item.BooleanValue)
							rtbcpf.Text = "1";
						else
							rtbcpf.Text = "0";
						break;
					}
					default:
					{
						rtbcpf.Text = item.StringValue;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
			finally
			{
				rtbcpfname.Tag = null;
			}
		}

		private void CpfChange(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			if (cbtype.SelectedIndex < 0)
				cbtype.SelectedIndex = cbtype.Items.Count - 1;
			CpfItem item;
			if (lbcpf.SelectedIndex < 0)
				item = new CpfItem();
			else
				item = (CpfItem)lbcpf.Items[lbcpf.SelectedIndex];

			item.Name = rtbcpfname.Text;
			item.Datatype = (Data.MetaData.DataTypes)cbtype.Items[cbtype.SelectedIndex];

			switch (item.Datatype)
			{
				case Data.MetaData.DataTypes.dtInteger:
				{
					try
					{
						item.IntegerValue = Convert.ToInt32(rtbcpf.Text, 16);
					}
					catch (Exception)
					{
						item.IntegerValue = 0;
					}
					break;
				}
				case Data.MetaData.DataTypes.dtUInteger:
				{
					try
					{
						item.UIntegerValue = Convert.ToUInt32(rtbcpf.Text, 16);
					}
					catch (Exception)
					{
						item.UIntegerValue = 0;
					}
					break;
				}
				case Data.MetaData.DataTypes.dtSingle:
				{
					try
					{
						item.SingleValue = Convert.ToSingle(rtbcpf.Text);
					}
					catch (Exception)
					{
						item.SingleValue = 0;
					}
					break;
				}
				case Data.MetaData.DataTypes.dtBoolean:
				{
					try
					{
						item.BooleanValue = (Convert.ToByte(rtbcpf.Text) != 0);
					}
					catch (Exception)
					{
						item.BooleanValue = false;
					}
					break;
				}
				default:
				{
					item.StringValue = rtbcpf.Text;
					break;
				}
			} //switch

			if (lbcpf.SelectedIndex < 0)
				lbcpf.Items.Add(item);
			else
				lbcpf.Items[lbcpf.SelectedIndex] = item;

			if (wrapper != null)
				wrapper.Changed = true;
		}

		private void AddCpf(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			lbcpf.SelectedIndex = -1;
			CpfChange(null, null);
			lbcpf.SelectedIndex = lbcpf.Items.Count - 1;
			CpfUpdate();
		}

		private void CpfUpdate()
		{
			Cpf wrp = (Cpf)wrapper;

			CpfItem[] items = new CpfItem[lbcpf.Items.Count];
			for (int i = 0; i < items.Length; i++)
				items[i] = (CpfItem)lbcpf.Items[i];
			wrp.Items = items;
		}

		private void CpfCommit(object sender, System.EventArgs e)
		{
			try
			{
				if (this.lbcpf.SelectedIndex >= 0)
					CpfChange(null, null);
				CpfUpdate();
				Cpf wrp = (Cpf)wrapper;

				wrp.SynchronizeUserData();
				MessageBox.Show(Localization.Manager.GetString("commited"));
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errwritingfile"),
					ex
				);
			}
		}

		#endregion

		private void tbnref_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				Nref wrp = (Nref)wrapper;
				tbnrefhash.Text = "0x" + Helper.HexString(wrp.Group);
				if (tbNref.Tag == null) // allow event execution
				{
					wrp.FileName = tbNref.Text;
					wrp.Changed = true;
				}
				tbnrefhash.Text = "0x" + Helper.HexString(wrp.Group);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void NrefCommit(object sender, System.EventArgs e)
		{
			try
			{
				wrapper.SynchronizeUserData();
				MessageBox.Show(Localization.Manager.GetString("commited"));
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errwritingfile"),
					ex
				);
			}
		}

		private void CpfAutoChange()
		{
			if (rtbcpfname.Tag != null)
				return;
			if (lbcpf.SelectedIndex < 0)
				return;
			rtbcpfname.Tag = true;
			try
			{
				CpfChange(null, null);
			}
			finally
			{
				rtbcpfname.Tag = null;
			}
		}

		internal SimPe.PackedFiles.UserInterface.CpfUI.ExecutePreview fkt;

		private void btprev_Click(object sender, System.EventArgs e)
		{
			if (fkt == null)
				return;
			try
			{
				Cpf cpf = (Cpf)wrapper;
				fkt(cpf, cpf.Package);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void DeleteCpf(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			if (lbcpf.SelectedIndex < 0)
				return;
			CpfItem item = (CpfItem)lbcpf.Items[lbcpf.SelectedIndex];
			lbcpf.Items.Remove(item);
			CpfUpdate();
			wrapper.Changed = true;
		}

		private void CpfAutoChange(object sender, System.EventArgs e)
		{
			CpfAutoChange();
		}
	}
}
