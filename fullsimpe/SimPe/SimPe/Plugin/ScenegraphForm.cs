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
using System.Windows.Forms;

using Ambertation.Windows.Forms.Graph;

using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Zusammenfassung f�r ScenegraphForm.
	/// </summary>
	public class ScenegraphForm : Form
	{
		private Panel panel2;
		private GroupBox groupBox1;
		private ComboBox cbrefnames;
		private TextBox tbflname;
		private Label label2;
		private Label label1;
		private Panel panel1;
		private LinkLabel llopen;
		private GroupBox groupBox2;
		private Label label3;
		private ComboBox cbLineStyle;
		private CheckBox cbQuality;
		private CheckBox cbPriority;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ScenegraphForm()
		{
			//
			// Erforderlich f�r die Windows Form-Designerunterst�tzung
			//
			InitializeComponent();

			gb = new GraphBuilder(panel1, new EventHandler(GraphItemClick));
			LinkControlLineMode[] ls =
				(LinkControlLineMode[])
					Enum.GetValues(
						typeof(LinkControlLineMode)
					);
			foreach (LinkControlLineMode l in ls)
			{
				cbLineStyle.Items.Add(l);
				if ((int)l == Helper.WindowsRegistry.GraphLineMode)
				{
					cbLineStyle.SelectedIndex = cbLineStyle.Items.Count - 1;
				}
			}
			//			if (cbLineStyle.SelectedIndex==-1) cbLineStyle.SelectedIndex = 2;

			cbQuality.Checked = Helper.WindowsRegistry.GraphQuality;
			cbPriority.Checked = Helper.WindowsRegistry.CresPrioritize;

			cbQuality_CheckedChanged(cbQuality, null);
			cbLineStyle_SelectedIndexChanged(cbLineStyle, null);
			ThemeManager tm = ThemeManager.Global.CreateChild();
			tm.AddControl(panel2);
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
		/// Erforderliche Methode f�r die Designerunterst�tzung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(ScenegraphForm)
				);
			panel2 = new Panel();
			groupBox2 = new GroupBox();
			cbPriority = new CheckBox();
			cbLineStyle = new ComboBox();
			label3 = new Label();
			cbQuality = new CheckBox();
			groupBox1 = new GroupBox();
			llopen = new LinkLabel();
			cbrefnames = new ComboBox();
			tbflname = new TextBox();
			label2 = new Label();
			label1 = new Label();
			panel1 = new Panel();
			panel2.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			//
			// panel2
			//
			panel2.BackColor = System.Drawing.Color.Transparent;
			panel2.Controls.Add(groupBox2);
			panel2.Controls.Add(groupBox1);
			panel2.Dock = DockStyle.Bottom;
			panel2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			panel2.Location = new System.Drawing.Point(0, 350);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(800, 120);
			panel2.TabIndex = 4;
			//
			// groupBox2
			//
			groupBox2.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			groupBox2.BackColor = System.Drawing.Color.Transparent;
			groupBox2.Controls.Add(cbPriority);
			groupBox2.Controls.Add(cbLineStyle);
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(cbQuality);
			groupBox2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			groupBox2.Location = new System.Drawing.Point(568, 8);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(224, 108);
			groupBox2.TabIndex = 2;
			groupBox2.TabStop = false;
			groupBox2.Text = "Graph";
			//
			// cbPriority
			//
			cbPriority.AutoSize = true;
			cbPriority.Font = new System.Drawing.Font("Verdana", 8.25F);
			cbPriority.Location = new System.Drawing.Point(134, 25);
			cbPriority.Name = "cbPriority";
			cbPriority.Size = new System.Drawing.Size(86, 17);
			cbPriority.TabIndex = 3;
			cbPriority.Text = "CRES First";
			cbPriority.UseVisualStyleBackColor = true;
			cbPriority.CheckedChanged += new EventHandler(
				cbPriority_CheckedChanged
			);
			//
			// cbLineStyle
			//
			cbLineStyle.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbLineStyle.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			cbLineStyle.Location = new System.Drawing.Point(32, 64);
			cbLineStyle.Name = "cbLineStyle";
			cbLineStyle.Size = new System.Drawing.Size(184, 21);
			cbLineStyle.TabIndex = 2;
			cbLineStyle.SelectedIndexChanged += new EventHandler(
				cbLineStyle_SelectedIndexChanged
			);
			//
			// label3
			//
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label3.Location = new System.Drawing.Point(16, 48);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(104, 13);
			label3.TabIndex = 1;
			label3.Text = "Connector Style:";
			//
			// cbQuality
			//
			cbQuality.AutoSize = true;
			cbQuality.FlatStyle = FlatStyle.System;
			cbQuality.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			cbQuality.Location = new System.Drawing.Point(16, 24);
			cbQuality.Name = "cbQuality";
			cbQuality.Size = new System.Drawing.Size(101, 18);
			cbQuality.TabIndex = 0;
			cbQuality.Text = "High Quality";
			cbQuality.CheckedChanged += new EventHandler(
				cbQuality_CheckedChanged
			);
			//
			// groupBox1
			//
			groupBox1.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			groupBox1.BackColor = System.Drawing.Color.Transparent;
			groupBox1.Controls.Add(llopen);
			groupBox1.Controls.Add(cbrefnames);
			groupBox1.Controls.Add(tbflname);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			groupBox1.Location = new System.Drawing.Point(0, 8);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(560, 108);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Properties";
			//
			// llopen
			//
			llopen.AutoSize = true;
			llopen.Location = new System.Drawing.Point(88, 0);
			llopen.Name = "llopen";
			llopen.Size = new System.Drawing.Size(39, 13);
			llopen.TabIndex = 4;
			llopen.TabStop = true;
			llopen.Text = "open";
			llopen.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(OpenPfd);
			//
			// cbrefnames
			//
			cbrefnames.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			cbrefnames.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			cbrefnames.Location = new System.Drawing.Point(24, 80);
			cbrefnames.Name = "cbrefnames";
			cbrefnames.Size = new System.Drawing.Size(528, 21);
			cbrefnames.TabIndex = 3;
			//
			// tbflname
			//
			tbflname.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			tbflname.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			tbflname.Location = new System.Drawing.Point(24, 40);
			tbflname.Name = "tbflname";
			tbflname.ReadOnly = true;
			tbflname.Size = new System.Drawing.Size(528, 21);
			tbflname.TabIndex = 2;
			//
			// label2
			//
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label2.Location = new System.Drawing.Point(16, 64);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(107, 13);
			label2.TabIndex = 1;
			label2.Text = "Reference Name:";
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label1.Location = new System.Drawing.Point(16, 24);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(64, 13);
			label1.TabIndex = 0;
			label1.Text = "FileName:";
			//
			// panel1
			//
			panel1.AutoScroll = true;
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(800, 350);
			panel1.TabIndex = 5;
			//
			// ScenegraphForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			BackColor = System.Drawing.Color.White;
			ClientSize = new System.Drawing.Size(800, 470);
			Controls.Add(panel1);
			Controls.Add(panel2);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			Name = "ScenegraphForm";
			Text = "Scenegrapher";
			panel2.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}
		#endregion


		public void GraphItemClick(object sender, EventArgs e)
		{
			GraphItem gi = (GraphItem)sender;
			Hashtable ht = null;
			llopen.Enabled = false;
			selpfd = null;
			if (gi.Tag.GetType() == typeof(string))
			{
				tbflname.Text = (string)gi.Tag;
				cbrefnames.Items.Clear();
				cbrefnames.Text = "";
			}
			else if (gi.Tag.GetType() == typeof(GenericRcol))
			{
				GenericRcol rcol = (GenericRcol)gi.Tag;
				tbflname.Text = rcol.FileName;
				cbrefnames.Items.Clear();
				cbrefnames.Text = "";
				ht = rcol.ReferenceChains;

				if (rcol.Package.FileName == open_pkg.FileName)
				{
					selpfd = rcol.FileDescriptor;
				}
			}
			else if (gi.Tag.GetType() == typeof(MmatWrapper))
			{
				MmatWrapper mmat = (MmatWrapper)gi.Tag;
				tbflname.Text = mmat.SubsetName;
				cbrefnames.Items.Clear();
				cbrefnames.Text = "";
				ht = mmat.ReferenceChains;

				if (mmat.Package.FileName == open_pkg.FileName)
				{
					selpfd = mmat.FileDescriptor;
				}
			}

			llopen.Enabled = (selpfd != null);

			if (ht != null)
			{
				foreach (string s in ht.Keys)
				{
					foreach (Interfaces.Files.IPackedFileDescriptor pfd in (ArrayList)ht[s])
					{
						cbrefnames.Items.Add(pfd.Filename);
					}
				}
			}

			if (cbrefnames.Items.Count > 0)
			{
				cbrefnames.SelectedIndex = 0;
			}
		}

		Interfaces.Files.IPackedFileDescriptor pfd,
			selpfd;
		Interfaces.Files.IPackageFile open_pkg;
		GraphBuilder gb;

		/// <summary>
		/// Build the SceneGraph
		/// </summary>
		/// <param name="prov"></param>
		/// <param name="simpe_pkg"></param>
		public void Execute(
			IProviderRegistry prov,
			Interfaces.Files.IPackageFile simpe_pkg,
			ref Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			this.pfd = pfd;
			open_pkg = simpe_pkg;
			WaitingScreen.Wait();
			try
			{
				llopen.Enabled = false;
				Interfaces.Files.IPackageFile orgpkg = simpe_pkg;

				DateTime start = DateTime.Now;
				FileTableBase.FileIndex.Load();
				Interfaces.Scenegraph.IScenegraphFileIndex fileindex =
					FileTableBase.FileIndex.Clone();
				fileindex.AddIndexFromPackage(simpe_pkg);

				Interfaces.Scenegraph.IScenegraphFileIndex oldfileindex =
					FileTableBase.FileIndex;
				FileTableBase.FileIndex = fileindex;

				//find txtr File
				/*WaitingScreen.UpdateMessage("Collecting Global Files");
				string[] modelnames = Scenegraph.FindModelNames(simpe_pkg);
				try
				{
					ObjectCloner oc = new ObjectCloner();
					oc.RcolModelClone(modelnames, false, false);
					simpe_pkg = oc.Package;
				}
				catch (ScenegraphException) {}*/

				FileTableBase.FileIndex = oldfileindex;

				gb.BuildGraph(simpe_pkg, fileindex);
				gb.FindUnused(orgpkg);

				WaitingScreen.Stop();
				TimeSpan runtime = DateTime.Now.Subtract(start);
				if (Helper.WindowsRegistry.HiddenMode)
				{
					Text =
						"Runtime: "
						+ runtime.TotalSeconds
						+ " sek. = "
						+ runtime.TotalMinutes
						+ " min.";
				}

				RemoteControl.ShowSubForm(this);

				pfd = this.pfd;
			}
#if !DEBUG
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
#endif
			finally
			{
				WaitingScreen.Stop();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void OpenPfd(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			pfd = selpfd;
			Close();
		}

		private void cbQuality_CheckedChanged(object sender, EventArgs e)
		{
			gb.Graph.Quality = cbQuality.Checked;
			Helper.WindowsRegistry.GraphQuality = gb.Graph.Quality;
		}

		private void cbLineStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbLineStyle.SelectedIndex < 0)
			{
				return;
			}

			gb.Graph.LineMode = (LinkControlLineMode)
				cbLineStyle.Items[cbLineStyle.SelectedIndex];
			Helper.WindowsRegistry.GraphLineMode = (int)gb.Graph.LineMode;
		}

		private void cbPriority_CheckedChanged(object sender, EventArgs e)
		{
			Helper.WindowsRegistry.CresPrioritize = cbPriority.Checked;
		}
	}
}
