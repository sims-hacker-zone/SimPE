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
			this.pnidno = new Panel();
			this.cbquadd = new ComboBox();
			this.cbquadc = new ComboBox();
			this.cbquadb = new ComboBox();
			this.cbquada = new ComboBox();
			this.label9 = new Label();
			this.tbidflags = new TextBox();
			this.label8 = new Label();
			this.tbsubep = new TextBox();
			this.cbsubtp = new ComboBox();
			this.label7 = new Label();
			this.tbreqep = new TextBox();
			this.cbreqtp = new ComboBox();
			this.label6 = new Label();
			this.lbVer = new Label();
			this.llunique = new LinkLabel();
			this.label5 = new Label();
			this.tbversion = new TextBox();
			this.tbsubname = new TextBox();
			this.tbname = new TextBox();
			this.tbid = new TextBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.tbtype = new TextBox();
			this.cbtype = new ComboBox();
			this.label1 = new Label();
			this.panel2 = new Panel();
			this.pnidno.SuspendLayout();
			this.SuspendLayout();
			//
			// pnidno
			//
			this.pnidno.Anchor = (
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
			this.pnidno.AutoScroll = true;
			this.pnidno.BackColor = System.Drawing.Color.Transparent;
			this.pnidno.Controls.Add(this.cbquadd);
			this.pnidno.Controls.Add(this.cbquadc);
			this.pnidno.Controls.Add(this.cbquadb);
			this.pnidno.Controls.Add(this.cbquada);
			this.pnidno.Controls.Add(this.label9);
			this.pnidno.Controls.Add(this.tbidflags);
			this.pnidno.Controls.Add(this.label8);
			this.pnidno.Controls.Add(this.tbsubep);
			this.pnidno.Controls.Add(this.cbsubtp);
			this.pnidno.Controls.Add(this.label7);
			this.pnidno.Controls.Add(this.tbreqep);
			this.pnidno.Controls.Add(this.cbreqtp);
			this.pnidno.Controls.Add(this.label6);
			this.pnidno.Controls.Add(this.lbVer);
			this.pnidno.Controls.Add(this.llunique);
			this.pnidno.Controls.Add(this.label5);
			this.pnidno.Controls.Add(this.tbversion);
			this.pnidno.Controls.Add(this.tbsubname);
			this.pnidno.Controls.Add(this.tbname);
			this.pnidno.Controls.Add(this.tbid);
			this.pnidno.Controls.Add(this.label4);
			this.pnidno.Controls.Add(this.label3);
			this.pnidno.Controls.Add(this.label2);
			this.pnidno.Controls.Add(this.tbtype);
			this.pnidno.Controls.Add(this.cbtype);
			this.pnidno.Controls.Add(this.label1);
			this.pnidno.Controls.Add(this.panel2);
			this.pnidno.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.pnidno.Location = new System.Drawing.Point(6, 20);
			this.pnidno.Name = "pnidno";
			this.pnidno.Size = new System.Drawing.Size(877, 304);
			this.pnidno.TabIndex = 21;
			//
			// cbquadd
			//
			this.cbquadd.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbquadd.Location = new System.Drawing.Point(384, 241);
			this.cbquadd.Name = "cbquadd";
			this.cbquadd.Size = new System.Drawing.Size(68, 21);
			this.cbquadd.TabIndex = 42;
			this.cbquadd.SelectedIndexChanged += new EventHandler(
				this.ChangSeasod
			);
			//
			// cbquadc
			//
			this.cbquadc.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbquadc.Location = new System.Drawing.Point(312, 241);
			this.cbquadc.Name = "cbquadc";
			this.cbquadc.Size = new System.Drawing.Size(68, 21);
			this.cbquadc.TabIndex = 41;
			this.cbquadc.SelectedIndexChanged += new EventHandler(
				this.ChangSeasoc
			);
			//
			// cbquadb
			//
			this.cbquadb.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbquadb.Location = new System.Drawing.Point(240, 241);
			this.cbquadb.Name = "cbquadb";
			this.cbquadb.Size = new System.Drawing.Size(68, 21);
			this.cbquadb.TabIndex = 40;
			this.cbquadb.SelectedIndexChanged += new EventHandler(
				this.ChangSeasob
			);
			//
			// cbquada
			//
			this.cbquada.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbquada.Location = new System.Drawing.Point(168, 241);
			this.cbquada.Name = "cbquada";
			this.cbquada.Size = new System.Drawing.Size(68, 21);
			this.cbquada.TabIndex = 39;
			this.cbquada.SelectedIndexChanged += new EventHandler(
				this.ChangSeasoa
			);
			//
			// label9
			//
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label9.Location = new System.Drawing.Point(6, 241);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(156, 21);
			this.label9.TabIndex = 38;
			this.label9.Text = "Season Quadrants :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbidflags
			//
			this.tbidflags.Location = new System.Drawing.Point(368, 77);
			this.tbidflags.Name = "tbidflags";
			this.tbidflags.Size = new System.Drawing.Size(84, 21);
			this.tbidflags.TabIndex = 37;
			this.tbidflags.TextChanged += new EventHandler(this.Change);
			//
			// label8
			//
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label8.Location = new System.Drawing.Point(316, 79);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(46, 17);
			this.label8.TabIndex = 36;
			this.label8.Text = "Flags:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbsubep
			//
			this.tbsubep.Location = new System.Drawing.Point(368, 207);
			this.tbsubep.Name = "tbsubep";
			this.tbsubep.ReadOnly = true;
			this.tbsubep.Size = new System.Drawing.Size(84, 21);
			this.tbsubep.TabIndex = 35;
			this.tbsubep.Text = "0x00000000";
			//
			// cbsubtp
			//
			this.cbsubtp.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbsubtp.Location = new System.Drawing.Point(168, 207);
			this.cbsubtp.Name = "cbsubtp";
			this.cbsubtp.Size = new System.Drawing.Size(190, 21);
			this.cbsubtp.TabIndex = 44;
			this.cbsubtp.SelectedIndexChanged += new EventHandler(
				this.SelectAtp
			);
			//
			// label7
			//
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label7.Location = new System.Drawing.Point(6, 207);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(156, 21);
			this.label7.TabIndex = 33;
			this.label7.Text = "Affiliated EP:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbreqep
			//
			this.tbreqep.Location = new System.Drawing.Point(368, 173);
			this.tbreqep.Name = "tbreqep";
			this.tbreqep.ReadOnly = true;
			this.tbreqep.Size = new System.Drawing.Size(84, 21);
			this.tbreqep.TabIndex = 32;
			this.tbreqep.Text = "0x00000000";
			//
			// cbreqtp
			//
			this.cbreqtp.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbreqtp.Location = new System.Drawing.Point(168, 173);
			this.cbreqtp.Name = "cbreqtp";
			this.cbreqtp.Size = new System.Drawing.Size(190, 21);
			this.cbreqtp.TabIndex = 45;
			this.cbreqtp.SelectedIndexChanged += new EventHandler(
				this.SelectRtp
			);
			//
			// label6
			//
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label6.Location = new System.Drawing.Point(6, 173);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(156, 21);
			this.label6.TabIndex = 30;
			this.label6.Text = "Required EP:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lbVer
			//
			this.lbVer.BackColor = System.Drawing.Color.Transparent;
			this.lbVer.Location = new System.Drawing.Point(256, 46);
			this.lbVer.Name = "lbVer";
			this.lbVer.Size = new System.Drawing.Size(176, 23);
			this.lbVer.TabIndex = 29;
			this.lbVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			// llunique
			//
			this.llunique.BackColor = System.Drawing.Color.Transparent;
			this.llunique.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.llunique.Location = new System.Drawing.Point(215, 77);
			this.llunique.Name = "llunique";
			this.llunique.Size = new System.Drawing.Size(93, 21);
			this.llunique.TabIndex = 28;
			this.llunique.TabStop = true;
			this.llunique.Text = "make unique";
			this.llunique.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.MakeUnique
				);
			//
			// label5
			//
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label5.Location = new System.Drawing.Point(29, 109);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(133, 17);
			this.label5.TabIndex = 27;
			this.label5.Text = "(parent) Name:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbversion
			//
			this.tbversion.Location = new System.Drawing.Point(168, 47);
			this.tbversion.Name = "tbversion";
			this.tbversion.ReadOnly = true;
			this.tbversion.Size = new System.Drawing.Size(88, 21);
			this.tbversion.TabIndex = 26;
			this.tbversion.Text = "0x00000000";
			//
			// tbsubname
			//
			this.tbsubname.Location = new System.Drawing.Point(368, 107);
			this.tbsubname.Name = "tbsubname";
			this.tbsubname.Size = new System.Drawing.Size(84, 21);
			this.tbsubname.TabIndex = 25;
			this.tbsubname.Text = "U000";
			this.tbsubname.TextChanged += new EventHandler(this.Change);
			//
			// tbname
			//
			this.tbname.Location = new System.Drawing.Point(168, 107);
			this.tbname.Name = "tbname";
			this.tbname.Size = new System.Drawing.Size(88, 21);
			this.tbname.TabIndex = 23;
			this.tbname.Text = "N000";
			this.tbname.TextChanged += new EventHandler(this.Change);
			//
			// tbid
			//
			this.tbid.Location = new System.Drawing.Point(168, 77);
			this.tbid.Name = "tbid";
			this.tbid.Size = new System.Drawing.Size(40, 21);
			this.tbid.TabIndex = 22;
			this.tbid.Text = "0";
			this.tbid.TextChanged += new EventHandler(this.Change);
			//
			// label4
			//
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label4.Location = new System.Drawing.Point(274, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 17);
			this.label4.TabIndex = 21;
			this.label4.Text = "Subname:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// label3
			//
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label3.Location = new System.Drawing.Point(29, 79);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(133, 17);
			this.label3.TabIndex = 20;
			this.label3.Text = "UID:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// label2
			//
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label2.Location = new System.Drawing.Point(29, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(133, 17);
			this.label2.TabIndex = 19;
			this.label2.Text = "Version:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbtype
			//
			this.tbtype.Location = new System.Drawing.Point(368, 139);
			this.tbtype.Name = "tbtype";
			this.tbtype.ReadOnly = true;
			this.tbtype.Size = new System.Drawing.Size(84, 21);
			this.tbtype.TabIndex = 18;
			this.tbtype.Text = "0x00000000";
			//
			// cbtype
			//
			this.cbtype.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbtype.Location = new System.Drawing.Point(168, 139);
			this.cbtype.Name = "cbtype";
			this.cbtype.Size = new System.Drawing.Size(190, 21);
			this.cbtype.TabIndex = 17;
			this.cbtype.SelectedIndexChanged += new EventHandler(
				this.SelectType
			);
			//
			// label1
			//
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label1.Location = new System.Drawing.Point(6, 139);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(156, 21);
			this.label1.TabIndex = 4;
			this.label1.Text = "Neighbourhood Type:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// panel2
			//
			this.panel2.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(877, 24);
			this.panel2.TabIndex = 0;
			//
			// IdnoForm
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(889, 333);
			this.Controls.Add(this.pnidno);
			this.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.Name = "IdnoForm";
			this.Text = "IdnoForm";
			this.pnidno.ResumeLayout(false);
			this.pnidno.PerformLayout();
			this.ResumeLayout(false);
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
				this.tbtype.Text = "0x" + Helper.HexString((uint)nt);
			}

			tbsubname.Enabled = (nt == NeighborhoodType.University);

			if (this.Tag != null)
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
			this.tbreqep.Text = "0x" + Helper.HexString((uint)nr);

			if (this.Tag != null)
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
			this.tbsubep.Text = "0x" + Helper.HexString((uint)ns);

			if (this.Tag != null)
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
			if (this.Tag != null)
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
			if (this.Tag != null)
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
			if (this.Tag != null)
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
			if (this.Tag != null)
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
				this.tbid.Text = wrapper.Uid.ToString();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void Change(object sender, EventArgs e)
		{
			if (this.Tag != null)
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
