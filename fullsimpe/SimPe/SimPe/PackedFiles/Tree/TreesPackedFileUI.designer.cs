using System;
using System.Collections.Generic;
using System.Text;

using SteepValley.Windows.Forms.ThemedControls;

namespace SimPe.PackedFiles.Tree
{
	partial class TreesPackedFileUI
	{

		private void InitializeComponent()
		{
			this.btMove = new System.Windows.Forms.Button();
			this.btRemove = new System.Windows.Forms.Button();
			this.pnhidim = new System.Windows.Forms.Panel();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.tbheader = new System.Windows.Forms.TextBox();
			this.tbunk5 = new System.Windows.Forms.TextBox();
			this.tbunk0 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.tbunk4 = new System.Windows.Forms.TextBox();
			this.tbunk1 = new System.Windows.Forms.TextBox();
			this.tbunk3 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.tbunk2 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.btAdder = new System.Windows.Forms.Button();
			this.tbversion = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbcount = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbfilename = new System.Windows.Forms.Label();
			this.tbfilename = new System.Windows.Forms.TextBox();
			this.listList = new System.Windows.Forms.ListView();
			this.Comment = new System.Windows.Forms.ColumnHeader();
			this.Zero2 = new System.Windows.Forms.ColumnHeader();
			this.Block1 = new System.Windows.Forms.ColumnHeader();
			this.Block2 = new System.Windows.Forms.ColumnHeader();
			this.Block3 = new System.Windows.Forms.ColumnHeader();
			this.Block4 = new System.Windows.Forms.ColumnHeader();
			this.Block5 = new System.Windows.Forms.ColumnHeader();
			this.Block6 = new System.Windows.Forms.ColumnHeader();
			this.Block7 = new System.Windows.Forms.ColumnHeader();
			this.Block8 = new System.Windows.Forms.ColumnHeader();
			this.Block9 = new System.Windows.Forms.ColumnHeader();
			this.listLast = new System.Windows.Forms.ListView();
			this.Indecks = new System.Windows.Forms.ColumnHeader();
			this.Comment2 = new System.Windows.Forms.ColumnHeader();
			this.taskBox1 = new XPTaskBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbComment = new System.Windows.Forms.TextBox();
			this.lbComment = new System.Windows.Forms.Label();
			this.taskBox2 = new XPTaskBox();
			this.tbComment2 = new System.Windows.Forms.TextBox();
			this.lbComment2 = new System.Windows.Forms.Label();
			this.btDown = new System.Windows.Forms.Button();
			this.btBhave = new System.Windows.Forms.Button();
			this.pnhidim.SuspendLayout();
			this.taskBox1.SuspendLayout();
			this.taskBox2.SuspendLayout();
			this.SuspendLayout();

			this.Controls.Add(this.btBhave);
			this.Controls.Add(this.btDown);
			this.Controls.Add(this.btMove);
			this.Controls.Add(this.btRemove);
			this.Controls.Add(this.pnhidim);
			this.Controls.Add(this.btAdder);
			this.Controls.Add(this.tbversion);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbcount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbfilename);
			this.Controls.Add(this.tbfilename);
			this.Controls.Add(this.listList);
			this.Controls.Add(this.listLast);
			this.Controls.Add(this.taskBox1);
			this.Controls.Add(this.taskBox2);
			//
			// btMove
			//
			this.btMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btMove.Location = new System.Drawing.Point(1136, 384);
			this.btMove.Name = "btMove";
			this.btMove.Size = new System.Drawing.Size(73, 23);
			this.btMove.TabIndex = 27;
			this.btMove.Text = "Move Up";
			this.btMove.UseVisualStyleBackColor = true;
			this.btMove.Click += new System.EventHandler(this.btMove_Click);
			//
			// btRemove
			//
			this.btRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btRemove.Location = new System.Drawing.Point(999, 384);
			this.btRemove.Name = "btRemove";
			this.btRemove.Size = new System.Drawing.Size(96, 23);
			this.btRemove.TabIndex = 26;
			this.btRemove.Text = "Delete a Line";
			this.btRemove.UseVisualStyleBackColor = true;
			this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
			//
			// pnhidim
			//
			this.pnhidim.Controls.Add(this.label19);
			this.pnhidim.Controls.Add(this.label18);
			this.pnhidim.Controls.Add(this.tbheader);
			this.pnhidim.Controls.Add(this.tbunk5);
			this.pnhidim.Controls.Add(this.tbunk0);
			this.pnhidim.Controls.Add(this.label13);
			this.pnhidim.Controls.Add(this.label16);
			this.pnhidim.Controls.Add(this.tbunk4);
			this.pnhidim.Controls.Add(this.tbunk1);
			this.pnhidim.Controls.Add(this.tbunk3);
			this.pnhidim.Controls.Add(this.label15);
			this.pnhidim.Controls.Add(this.label17);
			this.pnhidim.Controls.Add(this.tbunk2);
			this.pnhidim.Controls.Add(this.label14);
			this.pnhidim.Location = new System.Drawing.Point(8, 27);
			this.pnhidim.Name = "pnhidim";
			this.pnhidim.Size = new System.Drawing.Size(895, 23);
			this.pnhidim.TabIndex = 25;
			//
			// label19
			//
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label19.Location = new System.Drawing.Point(186, 5);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(33, 14);
			this.label19.TabIndex = 22;
			this.label19.Text = "U0 :";
			//
			// label18
			//
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.Location = new System.Drawing.Point(305, 5);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(33, 14);
			this.label18.TabIndex = 16;
			this.label18.Text = "U1 :";
			//
			// tbheader
			//
			this.tbheader.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tbheader.Location = new System.Drawing.Point(63, 1);
			this.tbheader.Name = "tbheader";
			this.tbheader.ReadOnly = true;
			this.tbheader.Size = new System.Drawing.Size(101, 21);
			this.tbheader.TabIndex = 11;
			//
			// tbunk5
			//
			this.tbunk5.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tbunk5.Location = new System.Drawing.Point(822, 1);
			this.tbunk5.Name = "tbunk5";
			this.tbunk5.ReadOnly = true;
			this.tbunk5.Size = new System.Drawing.Size(73, 21);
			this.tbunk5.TabIndex = 21;
			//
			// tbunk0
			//
			this.tbunk0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tbunk0.Location = new System.Drawing.Point(219, 1);
			this.tbunk0.Name = "tbunk0";
			this.tbunk0.ReadOnly = true;
			this.tbunk0.Size = new System.Drawing.Size(73, 21);
			this.tbunk0.TabIndex = 23;
			//
			// label13
			//
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(1, 5);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(62, 14);
			this.label13.TabIndex = 9;
			this.label13.Text = "Header :";
			//
			// label16
			//
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(789, 5);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(33, 14);
			this.label16.TabIndex = 14;
			this.label16.Text = "U5 :";
			//
			// tbunk4
			//
			this.tbunk4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tbunk4.Location = new System.Drawing.Point(697, 1);
			this.tbunk4.Name = "tbunk4";
			this.tbunk4.ReadOnly = true;
			this.tbunk4.Size = new System.Drawing.Size(73, 21);
			this.tbunk4.TabIndex = 20;
			//
			// tbunk1
			//
			this.tbunk1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tbunk1.Location = new System.Drawing.Point(338, 1);
			this.tbunk1.Name = "tbunk1";
			this.tbunk1.ReadOnly = true;
			this.tbunk1.Size = new System.Drawing.Size(73, 21);
			this.tbunk1.TabIndex = 17;
			//
			// tbunk3
			//
			this.tbunk3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tbunk3.Location = new System.Drawing.Point(581, 1);
			this.tbunk3.Name = "tbunk3";
			this.tbunk3.ReadOnly = true;
			this.tbunk3.Size = new System.Drawing.Size(73, 21);
			this.tbunk3.TabIndex = 19;
			//
			// label15
			//
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(664, 5);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(33, 14);
			this.label15.TabIndex = 13;
			this.label15.Text = "U4 :";
			//
			// label17
			//
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.Location = new System.Drawing.Point(427, 5);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(33, 14);
			this.label17.TabIndex = 15;
			this.label17.Text = "U2 :";
			//
			// tbunk2
			//
			this.tbunk2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tbunk2.Location = new System.Drawing.Point(460, 1);
			this.tbunk2.Name = "tbunk2";
			this.tbunk2.ReadOnly = true;
			this.tbunk2.Size = new System.Drawing.Size(73, 21);
			this.tbunk2.TabIndex = 18;
			//
			// label14
			//
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(548, 5);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(33, 14);
			this.label14.TabIndex = 12;
			this.label14.Text = "U3 :";
			//
			// btAdder
			//
			this.btAdder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btAdder.Location = new System.Drawing.Point(911, 384);
			this.btAdder.Name = "btAdder";
			this.btAdder.Size = new System.Drawing.Size(82, 23);
			this.btAdder.TabIndex = 24;
			this.btAdder.Text = "Add a Line";
			this.btAdder.UseVisualStyleBackColor = true;
			this.btAdder.Click += new System.EventHandler(this.btAdder_Click);
			//
			// tbversion
			//
			this.tbversion.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tbversion.Location = new System.Drawing.Point(863, 3);
			this.tbversion.Name = "tbversion";
			this.tbversion.ReadOnly = true;
			this.tbversion.Size = new System.Drawing.Size(40, 21);
			this.tbversion.TabIndex = 10;
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(799, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 14);
			this.label2.TabIndex = 8;
			this.label2.Text = "Version :";
			//
			// tbcount
			//
			this.tbcount.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tbcount.Location = new System.Drawing.Point(738, 3);
			this.tbcount.Name = "tbcount";
			this.tbcount.ReadOnly = true;
			this.tbcount.Size = new System.Drawing.Size(40, 21);
			this.tbcount.TabIndex = 7;
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(680, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 14);
			this.label1.TabIndex = 6;
			this.label1.Text = "Count :";
			//
			// lbfilename
			//
			this.lbfilename.AutoSize = true;
			this.lbfilename.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbfilename.Location = new System.Drawing.Point(13, 5);
			this.lbfilename.Name = "lbfilename";
			this.lbfilename.Size = new System.Drawing.Size(73, 14);
			this.lbfilename.TabIndex = 5;
			this.lbfilename.Text = "FileName :";
			//
			// tbfilename
			//
			this.tbfilename.Location = new System.Drawing.Point(92, 3);
			this.tbfilename.MaxLength = 40;
			this.tbfilename.Name = "tbfilename";
			this.tbfilename.Size = new System.Drawing.Size(570, 21);
			this.tbfilename.TabIndex = 4;
			this.tbfilename.TextChanged += new System.EventHandler(this.tbfilename_TextChanged);
			//
			// listList
			//
			this.listList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.Comment,
			this.Zero2,
			this.Block1,
			this.Block2,
			this.Block3,
			this.Block4,
			this.Block5,
			this.Block6,
			this.Block7,
			this.Block8,
			this.Block9});
			this.listList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listList.FullRowSelect = true;
			this.listList.GridLines = true;
			this.listList.Location = new System.Drawing.Point(10, 54);
			this.listList.MultiSelect = false;
			this.listList.Name = "listList";
			this.listList.Size = new System.Drawing.Size(895, 353);
			this.listList.TabIndex = 2;
			this.listList.UseCompatibleStateImageBehavior = false;
			this.listList.View = System.Windows.Forms.View.Details;
			this.listList.SelectedIndexChanged += new System.EventHandler(this.listList_SelectedIndexChanged);
			//
			// Comment
			//
			this.Comment.Text = "Comment";
			this.Comment.Width = 400;
			//
			// Zero2
			//
			this.Zero2.Text = "Zero2";
			this.Zero2.Width = 88;
			//
			// Block1
			//
			this.Block1.Text = "Block1";
			this.Block1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			// Block2
			//
			this.Block2.Text = "Block2";
			this.Block2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			// Block3
			//
			this.Block3.Text = "Block3";
			this.Block3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			// Block4
			//
			this.Block4.Text = "Block4";
			this.Block4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			// Block5
			//
			this.Block5.Text = "Block5";
			this.Block5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			// Block6
			//
			this.Block6.Text = "Block6";
			this.Block6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			// Block7
			//
			this.Block7.Text = "Block7";
			this.Block7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			// Block8
			//
			this.Block8.Text = "Block8";
			this.Block8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			// Block9
			//
			this.Block9.Text = "Block9";
			this.Block9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			// listLast
			//
			this.listLast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listLast.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.Indecks,
			this.Comment2});
			this.listLast.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listLast.FullRowSelect = true;
			this.listLast.GridLines = true;
			this.listLast.Location = new System.Drawing.Point(10, 54);
			this.listLast.MultiSelect = false;
			this.listLast.Name = "listLast";
			this.listLast.Size = new System.Drawing.Size(895, 353);
			this.listLast.TabIndex = 2;
			this.listLast.UseCompatibleStateImageBehavior = false;
			this.listLast.View = System.Windows.Forms.View.Details;
			this.listLast.Visible = false;
			this.listLast.SelectedIndexChanged += new System.EventHandler(this.listLast_SelectedIndexChanged);
			//
			// Indecks
			//
			this.Indecks.Text = "Index";
			this.Indecks.Width = 100;
			//
			// Comment2
			//
			this.Comment2.Text = "Comment";
			this.Comment2.Width = 810;
			//
			// taskBox1
			//
			this.taskBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.taskBox1.BackColor = System.Drawing.Color.Transparent;
			this.taskBox1.Controls.Add(this.textBox11);
			this.taskBox1.Controls.Add(this.textBox10);
			this.taskBox1.Controls.Add(this.textBox9);
			this.taskBox1.Controls.Add(this.textBox8);
			this.taskBox1.Controls.Add(this.textBox7);
			this.taskBox1.Controls.Add(this.textBox6);
			this.taskBox1.Controls.Add(this.textBox5);
			this.taskBox1.Controls.Add(this.textBox4);
			this.taskBox1.Controls.Add(this.textBox3);
			this.taskBox1.Controls.Add(this.textBox2);
			this.taskBox1.Controls.Add(this.label12);
			this.taskBox1.Controls.Add(this.label11);
			this.taskBox1.Controls.Add(this.label10);
			this.taskBox1.Controls.Add(this.label9);
			this.taskBox1.Controls.Add(this.label8);
			this.taskBox1.Controls.Add(this.label7);
			this.taskBox1.Controls.Add(this.label6);
			this.taskBox1.Controls.Add(this.label5);
			this.taskBox1.Controls.Add(this.label4);
			this.taskBox1.Controls.Add(this.label3);
			this.taskBox1.Controls.Add(this.tbComment);
			this.taskBox1.Controls.Add(this.lbComment);
			this.taskBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.taskBox1.HeaderText = "Editer";
			this.taskBox1.Location = new System.Drawing.Point(911, 10);
			this.taskBox1.Name = "taskBox1";
			this.taskBox1.Padding = new System.Windows.Forms.Padding(4, 44, 4, 4);
			this.taskBox1.Size = new System.Drawing.Size(386, 371);
			this.taskBox1.TabIndex = 3;
			//
			// textBox11
			//
			this.textBox11.Location = new System.Drawing.Point(82, 340);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(71, 23);
			this.textBox11.TabIndex = 23;
			this.textBox11.TextChanged += new System.EventHandler(this.textbox_TextChanged);
			//
			// textBox10
			//
			this.textBox10.Location = new System.Drawing.Point(82, 313);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(71, 23);
			this.textBox10.TabIndex = 22;
			this.textBox10.TextChanged += new System.EventHandler(this.textbox_TextChanged);
			//
			// textBox9
			//
			this.textBox9.Location = new System.Drawing.Point(82, 286);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(71, 23);
			this.textBox9.TabIndex = 21;
			this.textBox9.TextChanged += new System.EventHandler(this.textbox_TextChanged);
			//
			// textBox8
			//
			this.textBox8.Location = new System.Drawing.Point(82, 259);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(71, 23);
			this.textBox8.TabIndex = 20;
			this.textBox8.TextChanged += new System.EventHandler(this.textbox_TextChanged);
			//
			// textBox7
			//
			this.textBox7.Location = new System.Drawing.Point(82, 232);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(71, 23);
			this.textBox7.TabIndex = 19;
			this.textBox7.TextChanged += new System.EventHandler(this.textbox_TextChanged);
			//
			// textBox6
			//
			this.textBox6.Location = new System.Drawing.Point(82, 205);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(71, 23);
			this.textBox6.TabIndex = 18;
			this.textBox6.TextChanged += new System.EventHandler(this.textbox_TextChanged);
			//
			// textBox5
			//
			this.textBox5.Location = new System.Drawing.Point(82, 178);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(71, 23);
			this.textBox5.TabIndex = 17;
			this.textBox5.TextChanged += new System.EventHandler(this.textbox_TextChanged);
			//
			// textBox4
			//
			this.textBox4.Location = new System.Drawing.Point(82, 151);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(71, 23);
			this.textBox4.TabIndex = 16;
			this.textBox4.TextChanged += new System.EventHandler(this.textbox_TextChanged);
			//
			// textBox3
			//
			this.textBox3.Location = new System.Drawing.Point(82, 124);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(71, 23);
			this.textBox3.TabIndex = 15;
			this.textBox3.TextChanged += new System.EventHandler(this.textbox_TextChanged);
			//
			// textBox2
			//
			this.textBox2.Location = new System.Drawing.Point(82, 97);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(114, 23);
			this.textBox2.TabIndex = 14;
			this.textBox2.TextChanged += new System.EventHandler(this.textbox_TextChanged);
			//
			// label12
			//
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(26, 343);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(50, 16);
			this.label12.TabIndex = 12;
			this.label12.Text = "Block9";
			//
			// label11
			//
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(26, 316);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(50, 16);
			this.label11.TabIndex = 11;
			this.label11.Text = "Block8";
			//
			// label10
			//
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(26, 289);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(50, 16);
			this.label10.TabIndex = 10;
			this.label10.Text = "Block7";
			//
			// label9
			//
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(26, 262);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(50, 16);
			this.label9.TabIndex = 9;
			this.label9.Text = "Block6";
			//
			// label8
			//
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(26, 235);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(50, 16);
			this.label8.TabIndex = 8;
			this.label8.Text = "Block5";
			//
			// label7
			//
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(26, 208);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(50, 16);
			this.label7.TabIndex = 7;
			this.label7.Text = "Block4";
			//
			// label6
			//
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(26, 181);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 16);
			this.label6.TabIndex = 6;
			this.label6.Text = "Block3";
			//
			// label5
			//
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(26, 154);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Block2";
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(26, 127);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Block1";
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(30, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Zero2";
			//
			// tbComment
			//
			this.tbComment.Location = new System.Drawing.Point(82, 41);
			this.tbComment.Multiline = true;
			this.tbComment.Name = "tbComment";
			this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbComment.Size = new System.Drawing.Size(297, 50);
			this.tbComment.TabIndex = 1;
			this.tbComment.TextChanged += new System.EventHandler(this.textbox_TextChanged);
			//
			// lbComment
			//
			this.lbComment.AutoSize = true;
			this.lbComment.Location = new System.Drawing.Point(7, 44);
			this.lbComment.Name = "lbComment";
			this.lbComment.Size = new System.Drawing.Size(69, 16);
			this.lbComment.TabIndex = 0;
			this.lbComment.Text = "Comment";
			//
			// taskBox2
			//
			this.taskBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.taskBox2.BackColor = System.Drawing.Color.Transparent;
			this.taskBox2.Controls.Add(this.tbComment2);
			this.taskBox2.Controls.Add(this.lbComment2);
			this.taskBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.taskBox2.HeaderText = "Editer";
			this.taskBox2.Location = new System.Drawing.Point(911, 10);
			this.taskBox2.Name = "taskBox2";
			this.taskBox2.Padding = new System.Windows.Forms.Padding(4, 44, 4, 4);
			this.taskBox2.Size = new System.Drawing.Size(386, 371);
			this.taskBox2.TabIndex = 3;
			this.taskBox2.Visible = false;
			//
			// tbComment2
			//
			this.tbComment2.Location = new System.Drawing.Point(10, 71);
			this.tbComment2.Multiline = true;
			this.tbComment2.Name = "tbComment2";
			this.tbComment2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbComment2.Size = new System.Drawing.Size(366, 290);
			this.tbComment2.TabIndex = 1;
			this.tbComment2.TextChanged += new System.EventHandler(this.textbox2_TextChanged);
			//
			// lbComment2
			//
			this.lbComment2.AutoSize = true;
			this.lbComment2.Location = new System.Drawing.Point(7, 44);
			this.lbComment2.Name = "lbComment2";
			this.lbComment2.Size = new System.Drawing.Size(75, 16);
			this.lbComment2.TabIndex = 0;
			this.lbComment2.Text = "Comment:";
			this.tbComment2.ReadOnly = true;
			//
			// btBhave
			//
			this.btBhave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btBhave.Location = new System.Drawing.Point(1215, 2);
			this.btBhave.Name = "btBhave";
			this.btBhave.Size = new System.Drawing.Size(78, 23);
			this.btBhave.TabIndex = 29;
			this.btBhave.Text = "BHAV";
			this.btBhave.UseVisualStyleBackColor = true;
			this.btBhave.Click += new System.EventHandler(this.btBhave_Click);
			this.btBhave.Visible = false;
			//
			// btDown
			//
			this.btDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btDown.Location = new System.Drawing.Point(1215, 384);
			this.btDown.Name = "btDown";
			this.btDown.Size = new System.Drawing.Size(82, 23);
			this.btDown.TabIndex = 28;
			this.btDown.Text = "Move Down";
			this.btDown.UseVisualStyleBackColor = true;
			this.btDown.Click += new System.EventHandler(this.btDown_Click);
			//
			// TreesPackedFileUI
			//
			this.CanCommit = false;
			this.DoubleBuffered = true;
			this.HeaderText = "Op-Code Comments";
			this.Name = "TreesPackedFileUI";
			this.Size = new System.Drawing.Size(1300, 442);
			this.pnhidim.ResumeLayout(false);
			this.pnhidim.PerformLayout();
			this.taskBox1.ResumeLayout(false);
			this.taskBox1.PerformLayout();
			this.taskBox2.ResumeLayout(false);
			this.taskBox2.PerformLayout();
			this.ResumeLayout(false);
		}

		internal System.Windows.Forms.ListView listList;
		internal System.Windows.Forms.ListView listLast;
		private System.Windows.Forms.ColumnHeader Zero2;
		private System.Windows.Forms.ColumnHeader Block1;
		private System.Windows.Forms.ColumnHeader Block2;
		private System.Windows.Forms.ColumnHeader Block3;
		private System.Windows.Forms.ColumnHeader Block4;
		private System.Windows.Forms.ColumnHeader Block5;
		private System.Windows.Forms.ColumnHeader Block6;
		private System.Windows.Forms.ColumnHeader Block7;
		private System.Windows.Forms.ColumnHeader Block8;
		private System.Windows.Forms.ColumnHeader Block9;
		private System.Windows.Forms.ColumnHeader Comment;
		private System.Windows.Forms.ColumnHeader Comment2;
		private System.Windows.Forms.ColumnHeader Indecks;
		private XPTaskBox taskBox1;
		private XPTaskBox taskBox2;
		private System.Windows.Forms.Label lbComment;
		private System.Windows.Forms.Label lbComment2;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbComment;
		private System.Windows.Forms.TextBox tbComment2;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label lbfilename;
		private System.Windows.Forms.TextBox tbfilename;
		private System.Windows.Forms.TextBox tbcount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbheader;
		private System.Windows.Forms.TextBox tbversion;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbunk5;
		private System.Windows.Forms.TextBox tbunk4;
		private System.Windows.Forms.TextBox tbunk3;
		private System.Windows.Forms.TextBox tbunk2;
		private System.Windows.Forms.TextBox tbunk1;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbunk0;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button btAdder;
		private System.Windows.Forms.Panel pnhidim;
		private System.Windows.Forms.Button btMove;
		private System.Windows.Forms.Button btRemove;
		private System.Windows.Forms.Button btDown;
		private System.Windows.Forms.Button btBhave;
	}
}
