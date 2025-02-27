using System;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for IdnoForm.
	/// </summary>
	public class IdnoForm : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public IdnoForm()
		{
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
			pnidno = new Panel();
			cbquadd = new ComboBox();
			cbquadc = new ComboBox();
			cbquadb = new ComboBox();
			cbquada = new ComboBox();
			label9 = new Label();
			tbidflags = new TextBox();
			label8 = new Label();
			tbsubep = new TextBox();
			cbsubtp = new ComboBox();
			label7 = new Label();
			tbreqep = new TextBox();
			cbreqtp = new ComboBox();
			label6 = new Label();
			lbVer = new Label();
			llunique = new LinkLabel();
			label5 = new Label();
			tbversion = new TextBox();
			tbsubname = new TextBox();
			tbname = new TextBox();
			tbid = new TextBox();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			tbtype = new TextBox();
			cbtype = new ComboBox();
			label1 = new Label();
			panel2 = new Panel();
			pnidno.SuspendLayout();
			SuspendLayout();
			//
			// pnidno
			//
			pnidno.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			pnidno.AutoScroll = true;
			pnidno.BackColor = System.Drawing.Color.Transparent;
			pnidno.Controls.Add(cbquadd);
			pnidno.Controls.Add(cbquadc);
			pnidno.Controls.Add(cbquadb);
			pnidno.Controls.Add(cbquada);
			pnidno.Controls.Add(label9);
			pnidno.Controls.Add(tbidflags);
			pnidno.Controls.Add(label8);
			pnidno.Controls.Add(tbsubep);
			pnidno.Controls.Add(cbsubtp);
			pnidno.Controls.Add(label7);
			pnidno.Controls.Add(tbreqep);
			pnidno.Controls.Add(cbreqtp);
			pnidno.Controls.Add(label6);
			pnidno.Controls.Add(lbVer);
			pnidno.Controls.Add(llunique);
			pnidno.Controls.Add(label5);
			pnidno.Controls.Add(tbversion);
			pnidno.Controls.Add(tbsubname);
			pnidno.Controls.Add(tbname);
			pnidno.Controls.Add(tbid);
			pnidno.Controls.Add(label4);
			pnidno.Controls.Add(label3);
			pnidno.Controls.Add(label2);
			pnidno.Controls.Add(tbtype);
			pnidno.Controls.Add(cbtype);
			pnidno.Controls.Add(label1);
			pnidno.Controls.Add(panel2);
			pnidno.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			pnidno.Location = new System.Drawing.Point(6, 20);
			pnidno.Name = "pnidno";
			pnidno.Size = new System.Drawing.Size(877, 304);
			pnidno.TabIndex = 21;
			//
			// cbquadd
			//
			cbquadd.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbquadd.Location = new System.Drawing.Point(384, 241);
			cbquadd.Name = "cbquadd";
			cbquadd.Size = new System.Drawing.Size(68, 21);
			cbquadd.TabIndex = 42;
			cbquadd.SelectedIndexChanged += new EventHandler(
				ChangSeasod
			);
			//
			// cbquadc
			//
			cbquadc.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbquadc.Location = new System.Drawing.Point(312, 241);
			cbquadc.Name = "cbquadc";
			cbquadc.Size = new System.Drawing.Size(68, 21);
			cbquadc.TabIndex = 41;
			cbquadc.SelectedIndexChanged += new EventHandler(
				ChangSeasoc
			);
			//
			// cbquadb
			//
			cbquadb.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbquadb.Location = new System.Drawing.Point(240, 241);
			cbquadb.Name = "cbquadb";
			cbquadb.Size = new System.Drawing.Size(68, 21);
			cbquadb.TabIndex = 40;
			cbquadb.SelectedIndexChanged += new EventHandler(
				ChangSeasob
			);
			//
			// cbquada
			//
			cbquada.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbquada.Location = new System.Drawing.Point(168, 241);
			cbquada.Name = "cbquada";
			cbquada.Size = new System.Drawing.Size(68, 21);
			cbquada.TabIndex = 39;
			cbquada.SelectedIndexChanged += new EventHandler(
				ChangSeasoa
			);
			//
			// label9
			//
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label9.Location = new System.Drawing.Point(6, 241);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(156, 21);
			label9.TabIndex = 38;
			label9.Text = "Season Quadrants :";
			label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbidflags
			//
			tbidflags.Location = new System.Drawing.Point(368, 77);
			tbidflags.Name = "tbidflags";
			tbidflags.Size = new System.Drawing.Size(84, 21);
			tbidflags.TabIndex = 37;
			tbidflags.TextChanged += new EventHandler(Change);
			//
			// label8
			//
			label8.BackColor = System.Drawing.Color.Transparent;
			label8.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label8.Location = new System.Drawing.Point(316, 79);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(46, 17);
			label8.TabIndex = 36;
			label8.Text = "Flags:";
			label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbsubep
			//
			tbsubep.Location = new System.Drawing.Point(368, 207);
			tbsubep.Name = "tbsubep";
			tbsubep.ReadOnly = true;
			tbsubep.Size = new System.Drawing.Size(84, 21);
			tbsubep.TabIndex = 35;
			tbsubep.Text = "0x00000000";
			//
			// cbsubtp
			//
			cbsubtp.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbsubtp.Location = new System.Drawing.Point(168, 207);
			cbsubtp.Name = "cbsubtp";
			cbsubtp.Size = new System.Drawing.Size(190, 21);
			cbsubtp.TabIndex = 44;
			cbsubtp.SelectedIndexChanged += new EventHandler(
				SelectAtp
			);
			//
			// label7
			//
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label7.Location = new System.Drawing.Point(6, 207);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(156, 21);
			label7.TabIndex = 33;
			label7.Text = "Affiliated EP:";
			label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbreqep
			//
			tbreqep.Location = new System.Drawing.Point(368, 173);
			tbreqep.Name = "tbreqep";
			tbreqep.ReadOnly = true;
			tbreqep.Size = new System.Drawing.Size(84, 21);
			tbreqep.TabIndex = 32;
			tbreqep.Text = "0x00000000";
			//
			// cbreqtp
			//
			cbreqtp.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbreqtp.Location = new System.Drawing.Point(168, 173);
			cbreqtp.Name = "cbreqtp";
			cbreqtp.Size = new System.Drawing.Size(190, 21);
			cbreqtp.TabIndex = 45;
			cbreqtp.SelectedIndexChanged += new EventHandler(
				SelectRtp
			);
			//
			// label6
			//
			label6.BackColor = System.Drawing.Color.Transparent;
			label6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label6.Location = new System.Drawing.Point(6, 173);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(156, 21);
			label6.TabIndex = 30;
			label6.Text = "Required EP:";
			label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lbVer
			//
			lbVer.BackColor = System.Drawing.Color.Transparent;
			lbVer.Location = new System.Drawing.Point(256, 46);
			lbVer.Name = "lbVer";
			lbVer.Size = new System.Drawing.Size(176, 23);
			lbVer.TabIndex = 29;
			lbVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			// llunique
			//
			llunique.BackColor = System.Drawing.Color.Transparent;
			llunique.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			llunique.Location = new System.Drawing.Point(215, 77);
			llunique.Name = "llunique";
			llunique.Size = new System.Drawing.Size(93, 21);
			llunique.TabIndex = 28;
			llunique.TabStop = true;
			llunique.Text = "make unique";
			llunique.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					MakeUnique
				);
			//
			// label5
			//
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label5.Location = new System.Drawing.Point(29, 109);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(133, 17);
			label5.TabIndex = 27;
			label5.Text = "(parent) Name:";
			label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbversion
			//
			tbversion.Location = new System.Drawing.Point(168, 47);
			tbversion.Name = "tbversion";
			tbversion.ReadOnly = true;
			tbversion.Size = new System.Drawing.Size(88, 21);
			tbversion.TabIndex = 26;
			tbversion.Text = "0x00000000";
			//
			// tbsubname
			//
			tbsubname.Location = new System.Drawing.Point(368, 107);
			tbsubname.Name = "tbsubname";
			tbsubname.Size = new System.Drawing.Size(84, 21);
			tbsubname.TabIndex = 25;
			tbsubname.Text = "U000";
			tbsubname.TextChanged += new EventHandler(Change);
			//
			// tbname
			//
			tbname.Location = new System.Drawing.Point(168, 107);
			tbname.Name = "tbname";
			tbname.Size = new System.Drawing.Size(88, 21);
			tbname.TabIndex = 23;
			tbname.Text = "N000";
			tbname.TextChanged += new EventHandler(Change);
			//
			// tbid
			//
			tbid.Location = new System.Drawing.Point(168, 77);
			tbid.Name = "tbid";
			tbid.Size = new System.Drawing.Size(40, 21);
			tbid.TabIndex = 22;
			tbid.Text = "0";
			tbid.TextChanged += new EventHandler(Change);
			//
			// label4
			//
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label4.Location = new System.Drawing.Point(274, 109);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(88, 17);
			label4.TabIndex = 21;
			label4.Text = "Subname:";
			label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// label3
			//
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label3.Location = new System.Drawing.Point(29, 79);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(133, 17);
			label3.TabIndex = 20;
			label3.Text = "UID:";
			label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// label2
			//
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label2.Location = new System.Drawing.Point(29, 49);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(133, 17);
			label2.TabIndex = 19;
			label2.Text = "Version:";
			label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbtype
			//
			tbtype.Location = new System.Drawing.Point(368, 139);
			tbtype.Name = "tbtype";
			tbtype.ReadOnly = true;
			tbtype.Size = new System.Drawing.Size(84, 21);
			tbtype.TabIndex = 18;
			tbtype.Text = "0x00000000";
			//
			// cbtype
			//
			cbtype.DropDownStyle = ComboBoxStyle.DropDownList;
			cbtype.Location = new System.Drawing.Point(168, 139);
			cbtype.Name = "cbtype";
			cbtype.Size = new System.Drawing.Size(190, 21);
			cbtype.TabIndex = 17;
			cbtype.SelectedIndexChanged += new EventHandler(
				SelectType
			);
			//
			// label1
			//
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label1.Location = new System.Drawing.Point(6, 139);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(156, 21);
			label1.TabIndex = 4;
			label1.Text = "Neighbourhood Type:";
			label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// panel2
			//
			panel2.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			panel2.Location = new System.Drawing.Point(0, 0);
			panel2.Margin = new Padding(0);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(877, 24);
			panel2.TabIndex = 0;
			//
			// IdnoForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(889, 333);
			Controls.Add(pnidno);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			Name = "IdnoForm";
			Text = "IdnoForm";
			pnidno.ResumeLayout(false);
			pnidno.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		internal Panel pnidno;
		internal TextBox tbtype;
		internal ComboBox cbtype;
		private Label label1;
		private Panel panel2;
		private Label label2;
		private Label label3;
		internal Label label4;
		internal TextBox tbid;
		internal TextBox tbname;
		internal TextBox tbsubname;
		internal TextBox tbversion;
		private Label label5;
		internal LinkLabel llunique;
		internal Label lbVer;
		internal TextBox tbsubep;
		internal ComboBox cbsubtp;
		internal Label label7;
		internal TextBox tbreqep;
		internal ComboBox cbreqtp;
		internal Label label6;
		internal Label label8;
		internal TextBox tbidflags;
		internal Label label9;
		internal ComboBox cbquadd;
		internal ComboBox cbquadc;
		internal ComboBox cbquadb;
		internal ComboBox cbquada;

		internal Idno wrapper;

		private void SelectType(object sender, EventArgs e)
		{
			if (cbtype.SelectedIndex < 0)
			{
				return;
			}

			NeighborhoodType nt = (NeighborhoodType)cbtype.Items[cbtype.SelectedIndex];
			if (nt != NeighborhoodType.Unknown)
			{
				tbtype.Text = "0x" + Helper.HexString((uint)nt);
			}

			tbsubname.Enabled = (nt == NeighborhoodType.University);

			if (Tag != null)
			{
				return;
			}

			wrapper.Type = nt;
			wrapper.Changed = true;
		}

		private void SelectRtp(object sender, EventArgs e)
		{
			if (cbreqtp.SelectedIndex < 0)
			{
				return;
			}

			Data.MetaData.NeighbourhoodEP nr = (Data.LocalizedNeighbourhoodEP)
				cbreqtp.Items[cbreqtp.SelectedIndex];
			tbreqep.Text = "0x" + Helper.HexString((uint)nr);

			if (Tag != null)
			{
				return;
			}

			wrapper.Reqep = nr;
			wrapper.Changed = true;
			// SelectRep(sender, e);
		}

		private void SelectAtp(object sender, EventArgs e)
		{
			if (cbsubtp.SelectedIndex < 0)
			{
				return;
			}

			Data.MetaData.NeighbourhoodEP ns = (Data.LocalizedNeighbourhoodEP)
				cbsubtp.Items[cbsubtp.SelectedIndex];
			tbsubep.Text = "0x" + Helper.HexString((uint)ns);

			if (Tag != null)
			{
				return;
			}

			wrapper.Subep = ns;
			wrapper.Changed = true;
		}

		private void ChangSeasoa(object sender, EventArgs e)
		{
			if (cbquada.SelectedIndex < 0)
			{
				return;
			}

			NhSeasons sa = (NhSeasons)cbquada.Items[cbquada.SelectedIndex];
			if (Tag != null)
			{
				return;
			}

			wrapper.Quada = sa;
			wrapper.Changed = true;
		}

		private void ChangSeasob(object sender, EventArgs e)
		{
			if (cbquadb.SelectedIndex < 0)
			{
				return;
			}

			NhSeasons sb = (NhSeasons)cbquadb.Items[cbquadb.SelectedIndex];
			if (Tag != null)
			{
				return;
			}

			wrapper.Quadb = sb;
			wrapper.Changed = true;
		}

		private void ChangSeasoc(object sender, EventArgs e)
		{
			if (cbquadc.SelectedIndex < 0)
			{
				return;
			}

			NhSeasons sc = (NhSeasons)cbquadc.Items[cbquadc.SelectedIndex];
			if (Tag != null)
			{
				return;
			}

			wrapper.Quadc = sc;
			wrapper.Changed = true;
		}

		private void ChangSeasod(object sender, EventArgs e)
		{
			if (cbquadd.SelectedIndex < 0)
			{
				return;
			}

			NhSeasons sd = (NhSeasons)cbquadd.Items[cbquadd.SelectedIndex];
			if (Tag != null)
			{
				return;
			}

			wrapper.Quadd = sd;
			wrapper.Changed = true;
		}

		private void MakeUnique(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			try
			{
				wrapper.MakeUnique();
				tbid.Text = wrapper.Uid.ToString();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void Change(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			try
			{
				wrapper.OwnerName = tbname.Text;
				wrapper.SubName = tbsubname.Text;
				wrapper.Changed = true;
				wrapper.Uid = Convert.ToUInt32(tbid.Text);
				wrapper.Idflags = Helper.StringToUInt32(
					tbidflags.Text,
					wrapper.Idflags,
					16
				);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			wrapper.SynchronizeUserData();
		}
	}
}
