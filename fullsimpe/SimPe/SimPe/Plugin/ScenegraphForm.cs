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

using Ambertation.Windows.Forms;
using Ambertation.Windows.Forms.Graph;

using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Zusammenfassung f�r ScenegraphForm.
	/// </summary>
	public class ScenegraphForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cbrefnames;
		private System.Windows.Forms.TextBox tbflname;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.LinkLabel llopen;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbLineStyle;
		private System.Windows.Forms.CheckBox cbQuality;
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
			Ambertation.Windows.Forms.Graph.LinkControlLineMode[] ls =
				(Ambertation.Windows.Forms.Graph.LinkControlLineMode[])
					System.Enum.GetValues(
						typeof(Ambertation.Windows.Forms.Graph.LinkControlLineMode)
					);
			foreach (Ambertation.Windows.Forms.Graph.LinkControlLineMode l in ls)
			{
				this.cbLineStyle.Items.Add(l);
				if ((int)l == Helper.WindowsRegistry.GraphLineMode)
				{
					this.cbLineStyle.SelectedIndex = cbLineStyle.Items.Count - 1;
				}
			}
			//			if (cbLineStyle.SelectedIndex==-1) cbLineStyle.SelectedIndex = 2;

			cbQuality.Checked = Helper.WindowsRegistry.GraphQuality;
			cbPriority.Checked = Helper.WindowsRegistry.CresPrioritize;

			cbQuality_CheckedChanged(cbQuality, null);
			cbLineStyle_SelectedIndexChanged(cbLineStyle, null);
			SimPe.ThemeManager tm = SimPe.ThemeManager.Global.CreateChild();
			tm.AddControl(this.panel2);
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbPriority = new System.Windows.Forms.CheckBox();
			this.cbLineStyle = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbQuality = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.llopen = new System.Windows.Forms.LinkLabel();
			this.cbrefnames = new System.Windows.Forms.ComboBox();
			this.tbflname = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			//
			// panel2
			//
			this.panel2.BackColor = System.Drawing.Color.Transparent;
			this.panel2.Controls.Add(this.groupBox2);
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.panel2.Location = new System.Drawing.Point(0, 350);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(800, 120);
			this.panel2.TabIndex = 4;
			//
			// groupBox2
			//
			this.groupBox2.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.cbPriority);
			this.groupBox2.Controls.Add(this.cbLineStyle);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.cbQuality);
			this.groupBox2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.groupBox2.Location = new System.Drawing.Point(568, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(224, 108);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Graph";
			//
			// cbPriority
			//
			this.cbPriority.AutoSize = true;
			this.cbPriority.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.cbPriority.Location = new System.Drawing.Point(134, 25);
			this.cbPriority.Name = "cbPriority";
			this.cbPriority.Size = new System.Drawing.Size(86, 17);
			this.cbPriority.TabIndex = 3;
			this.cbPriority.Text = "CRES First";
			this.cbPriority.UseVisualStyleBackColor = true;
			this.cbPriority.CheckedChanged += new System.EventHandler(
				this.cbPriority_CheckedChanged
			);
			//
			// cbLineStyle
			//
			this.cbLineStyle.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbLineStyle.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbLineStyle.Location = new System.Drawing.Point(32, 64);
			this.cbLineStyle.Name = "cbLineStyle";
			this.cbLineStyle.Size = new System.Drawing.Size(184, 21);
			this.cbLineStyle.TabIndex = 2;
			this.cbLineStyle.SelectedIndexChanged += new System.EventHandler(
				this.cbLineStyle_SelectedIndexChanged
			);
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label3.Location = new System.Drawing.Point(16, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Connector Style:";
			//
			// cbQuality
			//
			this.cbQuality.AutoSize = true;
			this.cbQuality.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbQuality.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbQuality.Location = new System.Drawing.Point(16, 24);
			this.cbQuality.Name = "cbQuality";
			this.cbQuality.Size = new System.Drawing.Size(101, 18);
			this.cbQuality.TabIndex = 0;
			this.cbQuality.Text = "High Quality";
			this.cbQuality.CheckedChanged += new System.EventHandler(
				this.cbQuality_CheckedChanged
			);
			//
			// groupBox1
			//
			this.groupBox1.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.llopen);
			this.groupBox1.Controls.Add(this.cbrefnames);
			this.groupBox1.Controls.Add(this.tbflname);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.groupBox1.Location = new System.Drawing.Point(0, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(560, 108);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Properties";
			//
			// llopen
			//
			this.llopen.AutoSize = true;
			this.llopen.Location = new System.Drawing.Point(88, 0);
			this.llopen.Name = "llopen";
			this.llopen.Size = new System.Drawing.Size(39, 13);
			this.llopen.TabIndex = 4;
			this.llopen.TabStop = true;
			this.llopen.Text = "open";
			this.llopen.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenPfd);
			//
			// cbrefnames
			//
			this.cbrefnames.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.cbrefnames.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbrefnames.Location = new System.Drawing.Point(24, 80);
			this.cbrefnames.Name = "cbrefnames";
			this.cbrefnames.Size = new System.Drawing.Size(528, 21);
			this.cbrefnames.TabIndex = 3;
			//
			// tbflname
			//
			this.tbflname.Anchor = (
				(System.Windows.Forms.AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbflname.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbflname.Location = new System.Drawing.Point(24, 40);
			this.tbflname.Name = "tbflname";
			this.tbflname.ReadOnly = true;
			this.tbflname.Size = new System.Drawing.Size(528, 21);
			this.tbflname.TabIndex = 2;
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Reference Name:";
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "FileName:";
			//
			// panel1
			//
			this.panel1.AutoScroll = true;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 350);
			this.panel1.TabIndex = 5;
			//
			// ScenegraphForm
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(800, 470);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ScenegraphForm";
			this.Text = "Scenegrapher";
			this.panel2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
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
				this.tbflname.Text = (string)gi.Tag;
				this.cbrefnames.Items.Clear();
				cbrefnames.Text = "";
			}
			else if (gi.Tag.GetType() == typeof(GenericRcol))
			{
				GenericRcol rcol = (GenericRcol)gi.Tag;
				this.tbflname.Text = rcol.FileName;
				this.cbrefnames.Items.Clear();
				cbrefnames.Text = "";
				ht = rcol.ReferenceChains;

				if (rcol.Package.FileName == open_pkg.FileName)
				{
					selpfd = rcol.FileDescriptor;
				}
			}
			else if (gi.Tag.GetType() == typeof(SimPe.Plugin.MmatWrapper))
			{
				SimPe.Plugin.MmatWrapper mmat = (SimPe.Plugin.MmatWrapper)gi.Tag;
				this.tbflname.Text = mmat.SubsetName;
				this.cbrefnames.Items.Clear();
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
						this.cbrefnames.Items.Add(pfd.Filename);
					}
				}
			}

			if (cbrefnames.Items.Count > 0)
			{
				cbrefnames.SelectedIndex = 0;
			}
		}

		SimPe.Interfaces.Files.IPackedFileDescriptor pfd,
			selpfd;
		SimPe.Interfaces.Files.IPackageFile open_pkg;
		GraphBuilder gb;

		/// <summary>
		/// Build the SceneGraph
		/// </summary>
		/// <param name="prov"></param>
		/// <param name="simpe_pkg"></param>
		public void Execute(
			IProviderRegistry prov,
			SimPe.Interfaces.Files.IPackageFile simpe_pkg,
			ref SimPe.Interfaces.Files.IPackedFileDescriptor pfd
		)
		{
			this.pfd = pfd;
			this.open_pkg = simpe_pkg;
			WaitingScreen.Wait();
			try
			{
				llopen.Enabled = false;
				SimPe.Interfaces.Files.IPackageFile orgpkg = simpe_pkg;

				DateTime start = DateTime.Now;
				FileTable.FileIndex.Load();
				SimPe.Interfaces.Scenegraph.IScenegraphFileIndex fileindex =
					FileTable.FileIndex.Clone();
				fileindex.AddIndexFromPackage(simpe_pkg);

				SimPe.Interfaces.Scenegraph.IScenegraphFileIndex oldfileindex =
					FileTable.FileIndex;
				FileTable.FileIndex = fileindex;

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

				FileTable.FileIndex = oldfileindex;

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

		private void button1_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void OpenPfd(
			object sender,
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
		)
		{
			pfd = selpfd;
			Close();
		}

		private void cbQuality_CheckedChanged(object sender, System.EventArgs e)
		{
			gb.Graph.Quality = cbQuality.Checked;
			Helper.WindowsRegistry.GraphQuality = gb.Graph.Quality;
		}

		private void cbLineStyle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cbLineStyle.SelectedIndex < 0)
			{
				return;
			}

			gb.Graph.LineMode = (Ambertation.Windows.Forms.Graph.LinkControlLineMode)
				cbLineStyle.Items[cbLineStyle.SelectedIndex];
			Helper.WindowsRegistry.GraphLineMode = (int)gb.Graph.LineMode;
		}

		private void cbPriority_CheckedChanged(object sender, EventArgs e)
		{
			Helper.WindowsRegistry.CresPrioritize = cbPriority.Checked;
		}
	}
}
