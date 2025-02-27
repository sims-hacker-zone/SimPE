using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// Summary description for fAnimResourceConst.
	/// </summary>
	public class fAnimResourceConst : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.TabControl tabControl1;
		internal System.Windows.Forms.TabPage tAnimResourceConst;
		private System.Windows.Forms.GroupBox groupBox12;
		internal System.Windows.Forms.TextBox tb_arc_ver;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.GroupBox groupBox2;
		internal System.Windows.Forms.TreeView tv;
		private System.Windows.Forms.PropertyGrid pg;
		private System.Windows.Forms.LinkLabel llAdd;
		private System.Windows.Forms.CheckBox checkBox1;
		internal System.Windows.Forms.TabPage tMisc;
		private System.Windows.Forms.LinkLabel llClear;
		private System.Windows.Forms.LinkLabel llTxt;
		private System.Windows.Forms.LinkLabel llInTxt;
		internal SimPe.Plugin.Anim.AnimMeshBlockControl ambc;
		internal System.Windows.Forms.TabPage tMesh;
		private RichTextBox rtbnotes;
		private CheckBox cbshnote;
		private System.Windows.Forms.Panel gradpanel;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public fAnimResourceConst()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			llInTxt.Visible = llTxt.Visible = (UserVerification.HaveUserId);

			if (Helper.WindowsRegistry.UseBigIcons)
			{
				tv.Font = new System.Drawing.Font("Verdana", 12F);
				rtbnotes.Font = new System.Drawing.Font("Verdana", 12F);
			}

			llInTxt.BackColor =
				llAdd.BackColor =
				llClear.BackColor =
				llTxt.BackColor =
				checkBox1.BackColor =
					pg.BackColor;

			//
			// ambc
			//
			this.ambc = new AnimMeshBlockControl();
			this.ambc.BackColor = System.Drawing.Color.Transparent;
			this.ambc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ambc.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.ambc.Location = new System.Drawing.Point(8, 8);
			this.ambc.MeshBlock = null;
			this.ambc.MeshBlocks = null;
			this.ambc.Name = "ambc";
			this.ambc.Size = new System.Drawing.Size(776, 246);
			this.ambc.TabIndex = 1;
			this.ambc.Changed += new System.EventHandler(this.ambc_Changed);
			this.tMesh.Controls.Add(this.ambc);
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
					typeof(fAnimResourceConst)
				);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tAnimResourceConst = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbshnote = new System.Windows.Forms.CheckBox();
			this.rtbnotes = new System.Windows.Forms.RichTextBox();
			this.llTxt = new System.Windows.Forms.LinkLabel();
			this.llInTxt = new System.Windows.Forms.LinkLabel();
			this.llClear = new System.Windows.Forms.LinkLabel();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.tv = new System.Windows.Forms.TreeView();
			this.llAdd = new System.Windows.Forms.LinkLabel();
			this.pg = new System.Windows.Forms.PropertyGrid();
			this.tMisc = new System.Windows.Forms.TabPage();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.tb_arc_ver = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.tMesh = new System.Windows.Forms.TabPage();
			this.gradpanel = new System.Windows.Forms.Panel();
			this.tabControl1.SuspendLayout();
			this.tAnimResourceConst.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tMisc.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.gradpanel.SuspendLayout();
			this.SuspendLayout();
			//
			// tabControl1
			//
			this.tabControl1.Controls.Add(this.tAnimResourceConst);
			this.tabControl1.Controls.Add(this.tMisc);
			this.tabControl1.Controls.Add(this.tMesh);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(920, 288);
			this.tabControl1.TabIndex = 2;
			//
			// tAnimResourceConst
			//
			this.tAnimResourceConst.BackColor = System
				.Drawing
				.SystemColors
				.ControlLightLight;
			this.tAnimResourceConst.Controls.Add(this.groupBox2);
			this.tAnimResourceConst.Location = new System.Drawing.Point(4, 22);
			this.tAnimResourceConst.Name = "tAnimResourceConst";
			this.tAnimResourceConst.Size = new System.Drawing.Size(912, 262);
			this.tAnimResourceConst.TabIndex = 6;
			this.tAnimResourceConst.Text = "Raw View";
			this.tAnimResourceConst.UseVisualStyleBackColor = true;
			this.tAnimResourceConst.Visible = false;
			//
			// groupBox2
			//
			this.groupBox2.Anchor = (
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
			this.groupBox2.Controls.Add(this.cbshnote);
			this.groupBox2.Controls.Add(this.rtbnotes);
			this.groupBox2.Controls.Add(this.llTxt);
			this.groupBox2.Controls.Add(this.llInTxt);
			this.groupBox2.Controls.Add(this.llClear);
			this.groupBox2.Controls.Add(this.checkBox1);
			this.groupBox2.Controls.Add(this.tv);
			this.groupBox2.Controls.Add(this.llAdd);
			this.groupBox2.Controls.Add(this.pg);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.groupBox2.Location = new System.Drawing.Point(8, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(896, 248);
			this.groupBox2.TabIndex = 39;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Content";
			//
			// cbshnote
			//
			this.cbshnote.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.cbshnote.AutoSize = true;
			this.cbshnote.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbshnote.Location = new System.Drawing.Point(758, 0);
			this.cbshnote.Name = "cbshnote";
			this.cbshnote.Size = new System.Drawing.Size(125, 17);
			this.cbshnote.TabIndex = 46;
			this.cbshnote.Text = "\'From Text\' Notes";
			this.cbshnote.UseVisualStyleBackColor = true;
			this.cbshnote.Visible = false;
			this.cbshnote.CheckedChanged += new System.EventHandler(
				this.cbshnote_CheckedChanged
			);
			//
			// rtbnotes
			//
			this.rtbnotes.Anchor = (
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
			this.rtbnotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbnotes.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.rtbnotes.Location = new System.Drawing.Point(412, 24);
			this.rtbnotes.Name = "rtbnotes";
			this.rtbnotes.Size = new System.Drawing.Size(476, 216);
			this.rtbnotes.TabIndex = 45;
			this.rtbnotes.Text = resources.GetString("rtbnotes.Text");
			this.rtbnotes.Visible = false;
			//
			// llTxt
			//
			this.llTxt.AutoSize = true;
			this.llTxt.Enabled = false;
			this.llTxt.Location = new System.Drawing.Point(684, 30);
			this.llTxt.Name = "llTxt";
			this.llTxt.Size = new System.Drawing.Size(56, 13);
			this.llTxt.TabIndex = 44;
			this.llTxt.TabStop = true;
			this.llTxt.Text = "To Text";
			this.llTxt.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.llTxt_LinkClicked
				);
			//
			// llInTxt
			//
			this.llInTxt.AutoSize = true;
			this.llInTxt.Enabled = false;
			this.llInTxt.Location = new System.Drawing.Point(746, 30);
			this.llInTxt.Name = "llInTxt";
			this.llInTxt.Size = new System.Drawing.Size(74, 13);
			this.llInTxt.TabIndex = 44;
			this.llInTxt.TabStop = true;
			this.llInTxt.Text = "From Text";
			this.llInTxt.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.llInTxt_LinkClicked
				);
			//
			// llClear
			//
			this.llClear.AutoSize = true;
			this.llClear.Enabled = false;
			this.llClear.Location = new System.Drawing.Point(584, 30);
			this.llClear.Name = "llClear";
			this.llClear.Size = new System.Drawing.Size(94, 13);
			this.llClear.TabIndex = 43;
			this.llClear.TabStop = true;
			this.llClear.Text = "Clear Frames";
			this.llClear.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.llClear_LinkClicked
				);
			//
			// checkBox1
			//
			this.checkBox1.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(828, 30);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(55, 17);
			this.checkBox1.TabIndex = 42;
			this.checkBox1.Text = "Help";
			this.checkBox1.UseVisualStyleBackColor = false;
			this.checkBox1.CheckedChanged += new System.EventHandler(
				this.checkBox1_CheckedChanged
			);
			//
			// tv
			//
			this.tv.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Bottom
						) | System.Windows.Forms.AnchorStyles.Left
					)
				)
			);
			this.tv.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tv.FullRowSelect = true;
			this.tv.HideSelection = false;
			this.tv.Location = new System.Drawing.Point(8, 24);
			this.tv.Name = "tv";
			this.tv.Size = new System.Drawing.Size(396, 216);
			this.tv.TabIndex = 0;
			this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(
				this.tv_AfterSelect
			);
			//
			// llAdd
			//
			this.llAdd.AutoSize = true;
			this.llAdd.Enabled = false;
			this.llAdd.Location = new System.Drawing.Point(500, 30);
			this.llAdd.Name = "llAdd";
			this.llAdd.Size = new System.Drawing.Size(78, 13);
			this.llAdd.TabIndex = 2;
			this.llAdd.TabStop = true;
			this.llAdd.Text = "Add Frame";
			this.llAdd.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.llAdd_LinkClicked
				);
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
			this.pg.CommandsBackColor = System.Drawing.SystemColors.ControlLightLight;
			this.pg.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.pg.HelpVisible = false;
			this.pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pg.Location = new System.Drawing.Point(412, 24);
			this.pg.Name = "pg";
			this.pg.Size = new System.Drawing.Size(476, 216);
			this.pg.TabIndex = 1;
			//
			// tMisc
			//
			this.tMisc.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tMisc.Controls.Add(this.gradpanel);
			this.tMisc.Location = new System.Drawing.Point(4, 22);
			this.tMisc.Name = "tMisc";
			this.tMisc.Size = new System.Drawing.Size(912, 262);
			this.tMisc.TabIndex = 7;
			this.tMisc.Text = "Misc.";
			this.tMisc.UseVisualStyleBackColor = true;
			//
			// groupBox12
			//
			this.groupBox12.Controls.Add(this.tb_arc_ver);
			this.groupBox12.Controls.Add(this.label30);
			this.groupBox12.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.groupBox12.Location = new System.Drawing.Point(8, 8);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(120, 72);
			this.groupBox12.TabIndex = 12;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Settings";
			//
			// tb_arc_ver
			//
			this.tb_arc_ver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tb_arc_ver.Location = new System.Drawing.Point(16, 40);
			this.tb_arc_ver.Name = "tb_arc_ver";
			this.tb_arc_ver.Size = new System.Drawing.Size(88, 21);
			this.tb_arc_ver.TabIndex = 24;
			this.tb_arc_ver.Text = "0x00000000";
			this.tb_arc_ver.TextChanged += new System.EventHandler(
				this.tb_arc_ver_TextChanged
			);
			//
			// label30
			//
			this.label30.AutoSize = true;
			this.label30.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label30.Location = new System.Drawing.Point(8, 24);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(54, 13);
			this.label30.TabIndex = 23;
			this.label30.Text = "Version:";
			//
			// tMesh
			//
			this.tMesh.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tMesh.Location = new System.Drawing.Point(4, 22);
			this.tMesh.Name = "tMesh";
			this.tMesh.Size = new System.Drawing.Size(912, 262);
			this.tMesh.TabIndex = 8;
			this.tMesh.Text = "Mesh Animations";
			this.tMesh.UseVisualStyleBackColor = true;
			//
			// gradpanel
			//
			this.gradpanel.BackColor = System.Drawing.Color.Transparent;
			this.gradpanel.Controls.Add(this.groupBox12);
			this.gradpanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gradpanel.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.gradpanel.Location = new System.Drawing.Point(0, 0);
			this.gradpanel.Name = "gradpanel";
			this.gradpanel.Size = new System.Drawing.Size(912, 262);
			this.gradpanel.TabIndex = 13;
			//
			// fAnimResourceConst
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(936, 350);
			this.Controls.Add(this.tabControl1);
			this.Name = "fAnimResourceConst";
			this.Text = "fAnimResourceConst";
			this.tabControl1.ResumeLayout(false);
			this.tAnimResourceConst.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tMisc.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			this.gradpanel.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private void tv_AfterSelect(
			object sender,
			System.Windows.Forms.TreeViewEventArgs e
		)
		{
			llAdd.Enabled = llTxt.Enabled = llInTxt.Enabled = llClear.Enabled = false;
			rtbnotes.Visible = cbshnote.Visible = false;
			pg.SelectedObject = null;
			if (e == null)
			{
				return;
			}

			if (e.Node == null)
			{
				return;
			}

			if (e.Node.Tag == null)
			{
				return;
			}

			pg.SelectedObject = e.Node.Tag;

			if (e.Node.Tag is AnimationMeshBlock)
			{
				llInTxt.Enabled = llTxt.Enabled = true;
			}
			if (e.Node.Tag is AnimationFrameBlock)
			{
				llAdd.Enabled = true;
				llClear.Enabled = true;
			}
			if (e.Node.Tag.GetType() == typeof(AnimationFrame[]))
			{
				llAdd.Enabled = true;
				llClear.Enabled = true;
			}
			cbshnote.Visible = (llInTxt.Enabled && (UserVerification.HaveUserId));
			rtbnotes.Visible = (llInTxt.Enabled && cbshnote.Checked);
		}

		private void tb_arc_ver_TextChanged(object sender, System.EventArgs e)
		{
			if (this.tb_arc_ver.Tag == null)
			{
				return;
			}

			try
			{
				AbstractRcolBlock arb = (AbstractRcolBlock)this.tAnimResourceConst.Tag;

				arb.Version = Convert.ToUInt32(tb_arc_ver.Text, 16);
				arb.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
		}

		private void llAdd_LinkClicked(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			AnimationFrameBlock ab2 = null;
			if (tv.SelectedNode.Tag is AnimationFrameBlock)
			{
				ab2 = (AnimationFrameBlock)tv.SelectedNode.Tag;
			}
			else
			{
				ab2 = (AnimationFrameBlock)tv.SelectedNode.Parent.Tag;
			}

			if (ab2.AxisCount != 3)
			{
				return;
			}

			ab2.AddFrame((short)(ab2.GetDuration() + 1), 0, 0, 0, false);

			AnimResourceConst arc = (AnimResourceConst)tAnimResourceConst.Tag;
			arc.Refresh();
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			pg.HelpVisible = checkBox1.Checked;
		}

		private void llClear_LinkClicked(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			AnimationFrameBlock ab2 = null;
			if (tv.SelectedNode.Tag is AnimationFrameBlock)
			{
				ab2 = (AnimationFrameBlock)tv.SelectedNode.Tag;
			}
			else
			{
				ab2 = (AnimationFrameBlock)tv.SelectedNode.Parent.Tag;
			}

			ab2.ClearFrames();

			AnimResourceConst arc = (AnimResourceConst)tAnimResourceConst.Tag;
			arc.Refresh();
		}

		private void llTxt_LinkClicked(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			AnimationMeshBlock ab1 = (AnimationMeshBlock)tv.SelectedNode.Tag;
			SaveFileDialog ofd = new SaveFileDialog();
			ofd.Filter = "TextFile (*.txt)|*.txt|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				System.IO.StreamWriter sw = System.IO.File.CreateText(ofd.FileName);
				try
				{
					sw.WriteLine(ab1.Name + "-----------------------------------");
					foreach (AnimationFrameBlock ab2 in ab1.Part2)
					{
						sw.WriteLine(
							"--------------- " + ab2.ToString() + " ---------------"
						);
						foreach (AnimationAxisTransformBlock aatb in ab2.AxisSet)
						{
							sw.WriteLine("    " + aatb.ToString() + ":");
							foreach (AnimationAxisTransform aat in aatb)
							{
								sw.WriteLine("        " + aat.ToString());
							}
						}
					}
				}
				finally
				{
					sw.Close();
					sw.Dispose();
					sw = null;
				}
			}
		}

		bool nah = true;
		int coun = 0;

		private void llInTxt_LinkClicked(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			nah = true;
			AnimationMeshBlock ab1 = (AnimationMeshBlock)tv.SelectedNode.Tag;
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Text files (*.txt)|*.txt";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				System.IO.StreamReader sr = System.IO.File.OpenText(ofd.FileName);
				try
				{
					if (
						sr.ReadLine()
						== ab1.Name + "-----------------------------------"
					)
					{
						foreach (AnimationFrameBlock ab2 in ab1.Part2)
						{
							if (FromStrung(ab2, sr.ReadLine()))
							{
								foreach (
									AnimationAxisTransformBlock aatb in ab2.AxisSet
								)
								{
									FromTwine(aatb, sr.ReadLine());
									foreach (AnimationAxisTransform aat in aatb)
									{
										FromString(aat, sr.ReadLine());
									}
									if (coun > aatb.Count)
									{
										aatb.Add(coun - aatb.Count, false);
									}
									else if (coun < aatb.Count && coun > 0)
									{
										while (coun < aatb.Count)
										{
											aatb.Remove(aatb.GetLast());
										}
									}
								}
							}
						}
						AnimResourceConst arc = (AnimResourceConst)
							tAnimResourceConst.Tag;
						arc.Refresh();
						tv_AfterSelect(null, null);
						if (!nah)
						{
							SimPe.Message.Show(
								"Not all values imported properly",
								"Warning",
								System.Windows.Forms.MessageBoxButtons.OK
							);
						}
					}
					else
					{
						SimPe.Message.Show(
							ofd.FileName
								+ "\r\nIs not the correct text file for "
								+ ab1.Name
								+ "\r\nNothing was Imported!",
							"Error",
							MessageBoxButtons.OK
						);
					}
				}
				finally
				{
					sr.Close();
					sr.Dispose();
					sr = null;
				}
			}
		}

		private void FromString(AnimationAxisTransform aatfb, string readline)
		{
			try
			{
				aatfb.Linear = readline.Contains("(linear)");
				aatfb.ParentLocked = readline.Contains("(locked)");
				readline = readline.Replace("(linear)", " ");
				readline = readline.Replace("(locked)", " ");
				readline.Trim();
				string[] rline = readline.Split(new char[] { ':' }); // rline[0] is timecode rline[1] is all the rest
				aatfb.TimeCode = Convert.ToInt16(rline[0]);
				rline[1] += ";0;0"; // two extra zeros - if parent.Type has been changed we need data that's not otherwise there
				string[] sline = rline[1].Split(new char[] { ';' });
				if (aatfb.parent == null) // if parent == null then Parameter is immediately followed by comma
				{
					string[] pline = sline[0].Split(new char[] { ',' });
					aatfb.Parameter = Convert.ToInt16(pline[0]);
					aatfb.Unknown1 = Convert.ToInt16(pline[1]);
					aatfb.Unknown2 = Convert.ToInt16(sline[1]);
				}
				else
				{
					aatfb.Parameter = Convert.ToInt16(sline[0]);
					if (aatfb.parent.Type == AnimationTokenType.SixByte)
					{
						aatfb.Unknown1 = Convert.ToInt16(sline[1]);
					}
					else if (aatfb.parent.Type == AnimationTokenType.EightByte)
					{
						aatfb.Unknown1 = Convert.ToInt16(sline[1]);
						aatfb.Unknown2 = Convert.ToInt16(sline[2]);
					}
				}
			}
			catch
			{
				nah = false;
			}
		}

		private void FromTwine(AnimationAxisTransformBlock aatbc, string readline)
		{
			coun = aatbc.Count;
			try
			{
				int en;
				int loc = readline.IndexOf("(") + 1;
				if (readline.Contains(","))
				{
					en = readline.IndexOf(",");
				}
				else
				{
					en = readline.IndexOf(")");
				}

				coun = Convert.ToInt32(readline.Substring(loc, en - loc));
				aatbc.Locked = readline.Contains("locked");
				if (readline.Contains("Two"))
				{
					aatbc.Type = AnimationTokenType.TwoByte;
				}
				else if (readline.Contains("Six"))
				{
					aatbc.Type = AnimationTokenType.SixByte;
				}
				else if (readline.Contains("Eight"))
				{
					aatbc.Type = AnimationTokenType.EightByte;
				}
			}
			catch
			{
				nah = false;
			}
		}

		private bool FromStrung(AnimationFrameBlock afbc, string readline)
		{
			if (!readline.Contains(afbc.Name))
			{
				nah = false;
				return false;
			}
			if (readline.Contains("rot"))
			{
				afbc.TransformationType = FrameType.Rotation;
			}
			else if (readline.Contains("trn"))
			{
				afbc.TransformationType = FrameType.Translation;
			}
			else
			{
				nah = false;
				return false;
			}
			return true;
		}

		private void ambc_Changed(object sender, System.EventArgs e)
		{
			AnimResourceConst arc = (AnimResourceConst)tMesh.Tag;
			arc.Parent.Changed = true;
		}

		private void cbshnote_CheckedChanged(object sender, EventArgs e)
		{
			this.rtbnotes.Visible = cbshnote.Checked;
		}
	}
}
