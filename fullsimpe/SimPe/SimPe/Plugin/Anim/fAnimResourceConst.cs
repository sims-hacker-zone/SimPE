// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Windows.Forms;

using Message = SimPe.Forms.MainUI.Message;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// Summary description for fAnimResourceConst.
	/// </summary>
	public class fAnimResourceConst : Form
	{
		internal TabControl tabControl1;
		internal System.Windows.Forms.TabPage tAnimResourceConst;
		private GroupBox groupBox12;
		internal TextBox tb_arc_ver;
		private Label label30;
		private GroupBox groupBox2;
		internal TreeView tv;
		private PropertyGrid pg;
		private LinkLabel llAdd;
		private CheckBox checkBox1;
		internal System.Windows.Forms.TabPage tMisc;
		private LinkLabel llClear;
		private LinkLabel llTxt;
		private LinkLabel llInTxt;
		internal AnimMeshBlockControl ambc;
		internal System.Windows.Forms.TabPage tMesh;
		private RichTextBox rtbnotes;
		private CheckBox cbshnote;
		private Panel gradpanel;

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

			llInTxt.Visible = llTxt.Visible = UserVerification.HaveUserId;

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
			ambc = new AnimMeshBlockControl
			{
				BackColor = System.Drawing.Color.Transparent,
				Dock = DockStyle.Fill,
				Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			),
				Location = new System.Drawing.Point(8, 8),
				MeshBlock = null,
				MeshBlocks = null,
				Name = "ambc",
				Size = new System.Drawing.Size(776, 246),
				TabIndex = 1
			};
			ambc.Changed += new EventHandler(ambc_Changed);
			tMesh.Controls.Add(ambc);
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
					typeof(fAnimResourceConst)
				);
			tabControl1 = new TabControl();
			tAnimResourceConst = new System.Windows.Forms.TabPage();
			groupBox2 = new GroupBox();
			cbshnote = new CheckBox();
			rtbnotes = new RichTextBox();
			llTxt = new LinkLabel();
			llInTxt = new LinkLabel();
			llClear = new LinkLabel();
			checkBox1 = new CheckBox();
			tv = new TreeView();
			llAdd = new LinkLabel();
			pg = new PropertyGrid();
			tMisc = new System.Windows.Forms.TabPage();
			groupBox12 = new GroupBox();
			tb_arc_ver = new TextBox();
			label30 = new Label();
			tMesh = new System.Windows.Forms.TabPage();
			gradpanel = new Panel();
			tabControl1.SuspendLayout();
			tAnimResourceConst.SuspendLayout();
			groupBox2.SuspendLayout();
			tMisc.SuspendLayout();
			groupBox12.SuspendLayout();
			gradpanel.SuspendLayout();
			SuspendLayout();
			//
			// tabControl1
			//
			tabControl1.Controls.Add(tAnimResourceConst);
			tabControl1.Controls.Add(tMisc);
			tabControl1.Controls.Add(tMesh);
			tabControl1.Location = new System.Drawing.Point(8, 8);
			tabControl1.Multiline = true;
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(920, 288);
			tabControl1.TabIndex = 2;
			//
			// tAnimResourceConst
			//
			tAnimResourceConst.BackColor = System
				.Drawing
				.SystemColors
				.ControlLightLight;
			tAnimResourceConst.Controls.Add(groupBox2);
			tAnimResourceConst.Location = new System.Drawing.Point(4, 22);
			tAnimResourceConst.Name = "tAnimResourceConst";
			tAnimResourceConst.Size = new System.Drawing.Size(912, 262);
			tAnimResourceConst.TabIndex = 6;
			tAnimResourceConst.Text = "Raw View";
			tAnimResourceConst.UseVisualStyleBackColor = true;
			tAnimResourceConst.Visible = false;
			//
			// groupBox2
			//
			groupBox2.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			groupBox2.Controls.Add(cbshnote);
			groupBox2.Controls.Add(rtbnotes);
			groupBox2.Controls.Add(llTxt);
			groupBox2.Controls.Add(llInTxt);
			groupBox2.Controls.Add(llClear);
			groupBox2.Controls.Add(checkBox1);
			groupBox2.Controls.Add(tv);
			groupBox2.Controls.Add(llAdd);
			groupBox2.Controls.Add(pg);
			groupBox2.FlatStyle = FlatStyle.System;
			groupBox2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox2.Location = new System.Drawing.Point(8, 8);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(896, 248);
			groupBox2.TabIndex = 39;
			groupBox2.TabStop = false;
			groupBox2.Text = "Content";
			//
			// cbshnote
			//
			cbshnote.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			cbshnote.AutoSize = true;
			cbshnote.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbshnote.Location = new System.Drawing.Point(758, 0);
			cbshnote.Name = "cbshnote";
			cbshnote.Size = new System.Drawing.Size(125, 17);
			cbshnote.TabIndex = 46;
			cbshnote.Text = "\'From Text\' Notes";
			cbshnote.UseVisualStyleBackColor = true;
			cbshnote.Visible = false;
			cbshnote.CheckedChanged += new EventHandler(
				cbshnote_CheckedChanged
			);
			//
			// rtbnotes
			//
			rtbnotes.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			rtbnotes.BorderStyle = BorderStyle.FixedSingle;
			rtbnotes.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			rtbnotes.Location = new System.Drawing.Point(412, 24);
			rtbnotes.Name = "rtbnotes";
			rtbnotes.Size = new System.Drawing.Size(476, 216);
			rtbnotes.TabIndex = 45;
			rtbnotes.Text = resources.GetString("rtbnotes.Text");
			rtbnotes.Visible = false;
			//
			// llTxt
			//
			llTxt.AutoSize = true;
			llTxt.Enabled = false;
			llTxt.Location = new System.Drawing.Point(684, 30);
			llTxt.Name = "llTxt";
			llTxt.Size = new System.Drawing.Size(56, 13);
			llTxt.TabIndex = 44;
			llTxt.TabStop = true;
			llTxt.Text = "To Text";
			llTxt.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llTxt_LinkClicked
				);
			//
			// llInTxt
			//
			llInTxt.AutoSize = true;
			llInTxt.Enabled = false;
			llInTxt.Location = new System.Drawing.Point(746, 30);
			llInTxt.Name = "llInTxt";
			llInTxt.Size = new System.Drawing.Size(74, 13);
			llInTxt.TabIndex = 44;
			llInTxt.TabStop = true;
			llInTxt.Text = "From Text";
			llInTxt.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llInTxt_LinkClicked
				);
			//
			// llClear
			//
			llClear.AutoSize = true;
			llClear.Enabled = false;
			llClear.Location = new System.Drawing.Point(584, 30);
			llClear.Name = "llClear";
			llClear.Size = new System.Drawing.Size(94, 13);
			llClear.TabIndex = 43;
			llClear.TabStop = true;
			llClear.Text = "Clear Frames";
			llClear.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llClear_LinkClicked
				);
			//
			// checkBox1
			//
			checkBox1.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(828, 30);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(55, 17);
			checkBox1.TabIndex = 42;
			checkBox1.Text = "Help";
			checkBox1.UseVisualStyleBackColor = false;
			checkBox1.CheckedChanged += new EventHandler(
				checkBox1_CheckedChanged
			);
			//
			// tv
			//
			tv.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Bottom
						 | AnchorStyles.Left


			;
			tv.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tv.FullRowSelect = true;
			tv.HideSelection = false;
			tv.Location = new System.Drawing.Point(8, 24);
			tv.Name = "tv";
			tv.Size = new System.Drawing.Size(396, 216);
			tv.TabIndex = 0;
			tv.AfterSelect += new TreeViewEventHandler(
				tv_AfterSelect
			);
			//
			// llAdd
			//
			llAdd.AutoSize = true;
			llAdd.Enabled = false;
			llAdd.Location = new System.Drawing.Point(500, 30);
			llAdd.Name = "llAdd";
			llAdd.Size = new System.Drawing.Size(78, 13);
			llAdd.TabIndex = 2;
			llAdd.TabStop = true;
			llAdd.Text = "Add Frame";
			llAdd.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llAdd_LinkClicked
				);
			//
			// pg
			//
			pg.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			pg.CommandsBackColor = System.Drawing.SystemColors.ControlLightLight;
			pg.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			pg.HelpVisible = false;
			pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			pg.Location = new System.Drawing.Point(412, 24);
			pg.Name = "pg";
			pg.Size = new System.Drawing.Size(476, 216);
			pg.TabIndex = 1;
			//
			// tMisc
			//
			tMisc.BackColor = System.Drawing.SystemColors.ControlLightLight;
			tMisc.Controls.Add(gradpanel);
			tMisc.Location = new System.Drawing.Point(4, 22);
			tMisc.Name = "tMisc";
			tMisc.Size = new System.Drawing.Size(912, 262);
			tMisc.TabIndex = 7;
			tMisc.Text = "Misc.";
			tMisc.UseVisualStyleBackColor = true;
			//
			// groupBox12
			//
			groupBox12.Controls.Add(tb_arc_ver);
			groupBox12.Controls.Add(label30);
			groupBox12.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox12.Location = new System.Drawing.Point(8, 8);
			groupBox12.Name = "groupBox12";
			groupBox12.Size = new System.Drawing.Size(120, 72);
			groupBox12.TabIndex = 12;
			groupBox12.TabStop = false;
			groupBox12.Text = "Settings";
			//
			// tb_arc_ver
			//
			tb_arc_ver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_arc_ver.Location = new System.Drawing.Point(16, 40);
			tb_arc_ver.Name = "tb_arc_ver";
			tb_arc_ver.Size = new System.Drawing.Size(88, 21);
			tb_arc_ver.TabIndex = 24;
			tb_arc_ver.Text = "0x00000000";
			tb_arc_ver.TextChanged += new EventHandler(
				tb_arc_ver_TextChanged
			);
			//
			// label30
			//
			label30.AutoSize = true;
			label30.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label30.Location = new System.Drawing.Point(8, 24);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(54, 13);
			label30.TabIndex = 23;
			label30.Text = "Version:";
			//
			// tMesh
			//
			tMesh.BackColor = System.Drawing.SystemColors.ControlLightLight;
			tMesh.Location = new System.Drawing.Point(4, 22);
			tMesh.Name = "tMesh";
			tMesh.Size = new System.Drawing.Size(912, 262);
			tMesh.TabIndex = 8;
			tMesh.Text = "Mesh Animations";
			tMesh.UseVisualStyleBackColor = true;
			//
			// gradpanel
			//
			gradpanel.BackColor = System.Drawing.Color.Transparent;
			gradpanel.Controls.Add(groupBox12);
			gradpanel.Dock = DockStyle.Fill;
			gradpanel.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			gradpanel.Location = new System.Drawing.Point(0, 0);
			gradpanel.Name = "gradpanel";
			gradpanel.Size = new System.Drawing.Size(912, 262);
			gradpanel.TabIndex = 13;
			//
			// fAnimResourceConst
			//
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(936, 350);
			Controls.Add(tabControl1);
			Name = "fAnimResourceConst";
			Text = "fAnimResourceConst";
			tabControl1.ResumeLayout(false);
			tAnimResourceConst.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			tMisc.ResumeLayout(false);
			groupBox12.ResumeLayout(false);
			groupBox12.PerformLayout();
			gradpanel.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		private void tv_AfterSelect(
			object sender,
			TreeViewEventArgs e
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
			cbshnote.Visible = llInTxt.Enabled && UserVerification.HaveUserId;
			rtbnotes.Visible = llInTxt.Enabled && cbshnote.Checked;
		}

		private void tb_arc_ver_TextChanged(object sender, EventArgs e)
		{
			if (tb_arc_ver.Tag == null)
			{
				return;
			}

			try
			{
				AbstractRcolBlock arb = (AbstractRcolBlock)tAnimResourceConst.Tag;

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
			LinkLabelLinkClickedEventArgs e
		)
		{
			AnimationFrameBlock ab2 = tv.SelectedNode.Tag is AnimationFrameBlock
				? (AnimationFrameBlock)tv.SelectedNode.Tag
				: (AnimationFrameBlock)tv.SelectedNode.Parent.Tag;

			if (ab2.AxisCount != 3)
			{
				return;
			}

			ab2.AddFrame((short)(ab2.GetDuration() + 1), 0, 0, 0, false);

			AnimResourceConst arc = (AnimResourceConst)tAnimResourceConst.Tag;
			arc.Refresh();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			pg.HelpVisible = checkBox1.Checked;
		}

		private void llClear_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			AnimationFrameBlock ab2 = tv.SelectedNode.Tag is AnimationFrameBlock
				? (AnimationFrameBlock)tv.SelectedNode.Tag
				: (AnimationFrameBlock)tv.SelectedNode.Parent.Tag;

			ab2.ClearFrames();

			AnimResourceConst arc = (AnimResourceConst)tAnimResourceConst.Tag;
			arc.Refresh();
		}

		private void llTxt_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			AnimationMeshBlock ab1 = (AnimationMeshBlock)tv.SelectedNode.Tag;
			SaveFileDialog ofd = new SaveFileDialog
			{
				Filter = "TextFile (*.txt)|*.txt|All Files (*.*)|*.*"
			};
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
			LinkLabelLinkClickedEventArgs e
		)
		{
			nah = true;
			AnimationMeshBlock ab1 = (AnimationMeshBlock)tv.SelectedNode.Tag;
			OpenFileDialog ofd = new OpenFileDialog
			{
				Filter = "Text files (*.txt)|*.txt"
			};
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
							Message.Show(
								"Not all values imported properly",
								"Warning",
								MessageBoxButtons.OK
							);
						}
					}
					else
					{
						Message.Show(
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
				en = readline.Contains(",") ? readline.IndexOf(",") : readline.IndexOf(")");

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

		private void ambc_Changed(object sender, EventArgs e)
		{
			AnimResourceConst arc = (AnimResourceConst)tMesh.Tag;
			arc.Parent.Changed = true;
		}

		private void cbshnote_CheckedChanged(object sender, EventArgs e)
		{
			rtbnotes.Visible = cbshnote.Checked;
		}
	}
}
