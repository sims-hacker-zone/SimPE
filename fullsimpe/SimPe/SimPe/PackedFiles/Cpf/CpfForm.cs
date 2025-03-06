// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Cpf
{
	/// <summary>
	/// Summary description for Elements2.
	/// </summary>
	public class CpfForm : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CpfForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			if (Helper.WindowsRegistry.UseBigIcons)
			{
				lbcpf.Font = new System.Drawing.Font("Verdana", 12F);
				rtbcpfname.Font = rtbcpf.Font = new System.Drawing.Font(
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
				new System.ComponentModel.ComponentResourceManager(typeof(CpfForm));
			btprev = new Button();
			cbtype = new ComboBox();
			label8 = new Label();
			rtbcpfname = new RichTextBox();
			label7 = new Label();
			rtbcpf = new RichTextBox();
			label6 = new Label();
			lbcpf = new ListBox();
			panel5 = new Panel();
			tbNref = new TextBox();
			label10 = new Label();
			tbnrefhash = new TextBox();
			label9 = new Label();
			NrefPanel = new Panel();
			panel4 = new Panel();
			CpfPanel = new Panel();
			pbicon = new PictureBox();
			llcpfadd = new LinkLabel();
			llcpfchange = new LinkLabel();
			linkLabel1 = new LinkLabel();
			NrefPanel.SuspendLayout();
			CpfPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbicon).BeginInit();
			SuspendLayout();
			//
			// btprev
			//
			resources.ApplyResources(btprev, "btprev");
			btprev.Name = "btprev";
			btprev.Click += new EventHandler(btprev_Click);
			//
			// cbtype
			//
			resources.ApplyResources(cbtype, "cbtype");
			cbtype.DropDownStyle = ComboBoxStyle.DropDownList;
			cbtype.Name = "cbtype";
			cbtype.SelectedIndexChanged += new EventHandler(
				CpfAutoChange
			);
			//
			// label8
			//
			resources.ApplyResources(label8, "label8");
			label8.BackColor = System.Drawing.Color.Transparent;
			label8.Name = "label8";
			//
			// rtbcpfname
			//
			resources.ApplyResources(rtbcpfname, "rtbcpfname");
			rtbcpfname.BorderStyle = BorderStyle.None;
			rtbcpfname.Name = "rtbcpfname";
			rtbcpfname.TextChanged += new EventHandler(CpfAutoChange);
			//
			// label7
			//
			resources.ApplyResources(label7, "label7");
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.Name = "label7";
			//
			// rtbcpf
			//
			resources.ApplyResources(rtbcpf, "rtbcpf");
			rtbcpf.BorderStyle = BorderStyle.None;
			rtbcpf.Name = "rtbcpf";
			rtbcpf.TextChanged += new EventHandler(CpfAutoChange);
			//
			// label6
			//
			resources.ApplyResources(label6, "label6");
			label6.BackColor = System.Drawing.Color.Transparent;
			label6.Name = "label6";
			//
			// lbcpf
			//
			resources.ApplyResources(lbcpf, "lbcpf");
			lbcpf.Name = "lbcpf";
			lbcpf.SelectedIndexChanged += new EventHandler(
				CpfItemSelect
			);
			//
			// panel5
			//
			resources.ApplyResources(panel5, "panel5");
			//this.panel5.CanCommit = true;
			panel5.Name = "panel5";
			//this.panel5.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.CpfCommit);
			//
			// tbNref
			//
			resources.ApplyResources(tbNref, "tbNref");
			tbNref.Name = "tbNref";
			tbNref.TextChanged += new EventHandler(tbnref_TextChanged);
			//
			// label10
			//
			resources.ApplyResources(label10, "label10");
			label10.BackColor = System.Drawing.Color.Transparent;
			label10.Name = "label10";
			//
			// tbnrefhash
			//
			resources.ApplyResources(tbnrefhash, "tbnrefhash");
			tbnrefhash.Name = "tbnrefhash";
			tbnrefhash.ReadOnly = true;
			//
			// label9
			//
			resources.ApplyResources(label9, "label9");
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.Name = "label9";
			//
			// NrefPanel
			//
			NrefPanel.BackColor = System.Drawing.Color.Transparent;
			//this.NrefPanel.BackgroundImageAnchor = System.Windows.Forms.Panel.ImageLayout.CenterTop;
			//this.NrefPanel.BackgroundImageLocation = new System.Drawing.Point(0, 24);
			//this.NrefPanel.BackgroundImageZoomToFit = true;
			NrefPanel.Controls.Add(panel4);
			NrefPanel.Controls.Add(tbnrefhash);
			NrefPanel.Controls.Add(tbNref);
			NrefPanel.Controls.Add(label9);
			NrefPanel.Controls.Add(label10);
			resources.ApplyResources(NrefPanel, "NrefPanel");
			NrefPanel.Name = "NrefPanel";
			//
			// panel4
			//
			resources.ApplyResources(panel4, "panel4");
			//this.panel4.CanCommit = true;
			panel4.Name = "panel4";
			//this.panel4.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.NrefCommit);
			//
			// CpfPanel
			//
			CpfPanel.BackColor = System.Drawing.Color.Transparent;
			CpfPanel.BorderStyle = BorderStyle.FixedSingle;
			CpfPanel.Controls.Add(pbicon);
			CpfPanel.Controls.Add(lbcpf);
			CpfPanel.Controls.Add(panel5);
			CpfPanel.Controls.Add(btprev);
			CpfPanel.Controls.Add(rtbcpf);
			CpfPanel.Controls.Add(llcpfadd);
			CpfPanel.Controls.Add(llcpfchange);
			CpfPanel.Controls.Add(linkLabel1);
			CpfPanel.Controls.Add(rtbcpfname);
			CpfPanel.Controls.Add(cbtype);
			CpfPanel.Controls.Add(label6);
			CpfPanel.Controls.Add(label8);
			CpfPanel.Controls.Add(label7);
			//this.CpfPanel.EndColour = System.Drawing.SystemColors.Control;
			resources.ApplyResources(CpfPanel, "CpfPanel");
			//this.CpfPanel.MiddleColour = System.Drawing.SystemColors.Control;
			CpfPanel.Name = "CpfPanel";
			//this.CpfPanel.StartColour = System.Drawing.SystemColors.Control;
			//
			// pbicon
			//
			resources.ApplyResources(pbicon, "pbicon");
			pbicon.Name = "pbicon";
			pbicon.TabStop = false;
			//
			// llcpfadd
			//
			resources.ApplyResources(llcpfadd, "llcpfadd");
			llcpfadd.BackColor = System.Drawing.Color.Transparent;
			llcpfadd.Name = "llcpfadd";
			llcpfadd.TabStop = true;
			llcpfadd.UseCompatibleTextRendering = true;
			llcpfadd.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(AddCpf);
			//
			// llcpfchange
			//
			resources.ApplyResources(llcpfchange, "llcpfchange");
			llcpfchange.BackColor = System.Drawing.Color.Transparent;
			llcpfchange.Name = "llcpfchange";
			llcpfchange.TabStop = true;
			llcpfchange.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					CpfChange
				);
			//
			// linkLabel1
			//
			resources.ApplyResources(linkLabel1, "linkLabel1");
			linkLabel1.BackColor = System.Drawing.Color.Transparent;
			linkLabel1.Name = "linkLabel1";
			linkLabel1.TabStop = true;
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					DeleteCpf
				);
			//
			// Elements2
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(NrefPanel);
			Controls.Add(CpfPanel);
			Name = "Elements2";
			NrefPanel.ResumeLayout(false);
			NrefPanel.PerformLayout();
			CpfPanel.ResumeLayout(false);
			CpfPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pbicon).EndInit();
			ResumeLayout(false);
		}
		#endregion

		private Panel panel5;
		internal ListBox lbcpf;
		internal RichTextBox rtbcpf;
		private Label label6;
		private Label label7;
		internal RichTextBox rtbcpfname;
		private Label label8;
		internal ComboBox cbtype;
		private Panel panel4;
		internal Label label9;
		internal TextBox tbnrefhash;
		internal Label label10;
		internal Button btprev;
		internal TextBox tbNref;
		internal Panel NrefPanel;
		internal Panel CpfPanel;
		internal LinkLabel linkLabel1;
		internal LinkLabel llcpfadd;
		internal LinkLabel llcpfchange;
		private PictureBox pbicon;

		#region Str Attributes
		internal IFileWrapperSaveExtension wrapper;

		#endregion

		#region CPF
		private void CpfItemSelect(object sender, EventArgs e)
		{
			if (rtbcpfname.Tag != null)
			{
				return;
			}

			llcpfchange.Enabled = false;
			if (lbcpf.SelectedIndex < 0)
			{
				return;
			}

			llcpfchange.Enabled = true;

			rtbcpfname.Tag = true;
			try
			{
				CpfItem item = (CpfItem)lbcpf.Items[lbcpf.SelectedIndex];
				rtbcpfname.Text = item.Name;
				for (int i = 0; i < cbtype.Items.Count; i++)
				{
					cbtype.SelectedIndex = -1;
					Data.DataTypes type = (Data.DataTypes)
						cbtype.Items[i];
					if (type == item.Datatype)
					{
						cbtype.SelectedIndex = i;
						break;
					}
				}

				switch (item.Datatype)
				{
					case Data.DataTypes.dtSingle:
					{
						rtbcpf.Text = item.SingleValue.ToString();
						break;
					}
					case Data.DataTypes.dtInteger:
					{
						rtbcpf.Text = "0x" + Helper.HexString((uint)item.IntegerValue);
						break;
					}
					case Data.DataTypes.dtUInteger:
					{
						rtbcpf.Text = "0x" + Helper.HexString(item.UIntegerValue);
						break;
					}
					case Data.DataTypes.dtBoolean:
					{
						rtbcpf.Text = item.BooleanValue ? "1" : "0";

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
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (cbtype.SelectedIndex < 0)
			{
				cbtype.SelectedIndex = cbtype.Items.Count - 1;
			}

			CpfItem item = lbcpf.SelectedIndex < 0 ? new CpfItem() : (CpfItem)lbcpf.Items[lbcpf.SelectedIndex];

			item.Name = rtbcpfname.Text;
			item.Datatype = (Data.DataTypes)cbtype.Items[cbtype.SelectedIndex];

			switch (item.Datatype)
			{
				case Data.DataTypes.dtInteger:
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
				case Data.DataTypes.dtUInteger:
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
				case Data.DataTypes.dtSingle:
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
				case Data.DataTypes.dtBoolean:
				{
					try
					{
						item.BooleanValue = Convert.ToByte(rtbcpf.Text) != 0;
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
			{
				lbcpf.Items.Add(item);
			}
			else
			{
				lbcpf.Items[lbcpf.SelectedIndex] = item;
			}

			if (wrapper != null)
			{
				wrapper.Changed = true;
			}
		}

		private void AddCpf(
			object sender,
			LinkLabelLinkClickedEventArgs e
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
			{
				items[i] = (CpfItem)lbcpf.Items[i];
			}

			wrp.Items = items;
		}

		private void CpfCommit(object sender, EventArgs e)
		{
			try
			{
				if (lbcpf.SelectedIndex >= 0)
				{
					CpfChange(null, null);
				}

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

		private void tbnref_TextChanged(object sender, EventArgs e)
		{
			try
			{
				Nref.Nref wrp = (Nref.Nref)wrapper;
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

		private void NrefCommit(object sender, EventArgs e)
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
			{
				return;
			}

			if (lbcpf.SelectedIndex < 0)
			{
				return;
			}

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

		internal CpfUI.ExecutePreview fkt;

		private void btprev_Click(object sender, EventArgs e)
		{
			if (fkt == null)
			{
				return;
			}

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
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lbcpf.SelectedIndex < 0)
			{
				return;
			}

			CpfItem item = (CpfItem)lbcpf.Items[lbcpf.SelectedIndex];
			lbcpf.Items.Remove(item);
			CpfUpdate();
			wrapper.Changed = true;
		}

		private void CpfAutoChange(object sender, EventArgs e)
		{
			CpfAutoChange();
		}
	}
}
