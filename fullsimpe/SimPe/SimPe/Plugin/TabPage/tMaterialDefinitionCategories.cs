// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Windows.Forms;

namespace SimPe.Plugin.TabPage
{
	/// <summary>
	/// Summary description for MatdForm.
	/// </summary>
	public class MaterialDefinitionCategories : System.Windows.Forms.TabPage
	//System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MaterialDefinitionCategories()
		{
			SetStyle(
				ControlStyles.SupportsTransparentBackColor
					| ControlStyles.AllPaintingInWmPaint
					|
					//ControlStyles.Opaque |
					ControlStyles.UserPaint
					| ControlStyles.ResizeRedraw
					| ControlStyles.DoubleBuffer,
				true
			);
			//
			// Required designer variable.
			//
			InitializeComponent();

			UseVisualStyleBackColor = true;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Tag = null;
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
			pg = new PropertyGrid();
			SuspendLayout();
			//
			// tMaterialDefinitionCategories
			//
			BackColor = System.Drawing.SystemColors.ControlLightLight;
			Controls.Add(pg);
			Location = new System.Drawing.Point(4, 22);
			Name = "tMaterialDefinitionCategories";
			Size = new System.Drawing.Size(744, 238);
			TabIndex = 3;
			Text = "Categorized Properties";
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
			pg.CommandsVisibleIfAvailable = true;
			pg.HelpVisible = false;
			pg.LargeButtons = false;
			pg.LineColor = System.Drawing.SystemColors.ScrollBar;
			pg.Location = new System.Drawing.Point(8, 8);
			pg.Name = "pg";
			pg.Size = new System.Drawing.Size(728, 224);
			pg.TabIndex = 0;
			pg.Text = "MaterialDefinition Properties";
			pg.ToolbarVisible = false;
			pg.ViewBackColor = System.Drawing.SystemColors.Window;
			pg.ViewForeColor = System.Drawing.SystemColors.WindowText;
			pg.PropertyValueChanged +=
				new PropertyValueChangedEventHandler(
					pg_PropertyValueChanged
				);
			//
			// MatdForm
			//
			ResumeLayout(false);
		}
		#endregion


		private PropertyGrid pg;

		/*private void SelectListFile(object sender, System.EventArgs e)
		{
			if (tblistfile.Tag!=null) return;
			if (lbfl.SelectedIndex<0) return;

			try
			{
				tblistfile.Tag = true;
				tblistfile.Text = (string)lbfl.Items[lbfl.SelectedIndex];
			}
			catch (Exception) {}
			finally
			{
				tblistfile.Tag = null;
			}
		}

		private void ChangeListFile(object sender, System.EventArgs e)
		{
			if (this.tabPage3.Tag==null) return;
			if (tblistfile.Tag!=null) return;
			if (lbfl.SelectedIndex<0) return;

			try
			{
				tblistfile.Tag = true;
				lbfl.Items[lbfl.SelectedIndex] = tblistfile.Text;

				MaterialDefinition md = (MaterialDefinition)this.tabPage3.Tag;
				md.Listing[lbfl.SelectedIndex] = tblistfile.Text;

				md.Changed = true;
			}
			catch (Exception) {}
			finally
			{
				tblistfile.Tag = null;
			}
		}

		private void Delete(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (this.tabPage3.Tag==null) return;
			if (lbfl.SelectedIndex<0) return;
			MaterialDefinition md = (MaterialDefinition)this.tabPage3.Tag;
			md.Listing = (string[])Helper.Delete(md.Listing, lbfl.Items[lbfl.SelectedIndex]);

			lbfl.Items.Remove(lbfl.Items[lbfl.SelectedIndex]);

			md.Changed = true;
		}

		private void Add(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (this.tabPage3.Tag==null) return;
			lbfl.Items.Add(tblistfile.Text);
			lbfl.SelectedIndex = lbfl.Items.Count-1;

			MaterialDefinition md = (MaterialDefinition)this.tabPage3.Tag;
			md.Listing = (string[])Helper.Add(md.Listing, tblistfile.Text);

			md.Changed = true;
		}	*/

		Ambertation.PropertyObjectBuilderExt pob;

		internal void SetupGrid(Plugin.MaterialDefinition md)
		{
			pg.SelectedObject = null;
			/*if (this.tGrid.Tag==null) return;
			MaterialDefinition md = (MaterialDefinition)this.tGrid.Tag;*/

			//Build the table for the current MMAT
			Hashtable ht = new Hashtable();

			foreach (MaterialDefinitionProperty mdp in md.Properties)
			{
				if (
					Plugin.MaterialDefinition.PropertyParser.Properties.ContainsKey(
						mdp.Name
					)
				)
				{
					Ambertation.PropertyDescription pd = (
						(Ambertation.PropertyDescription)
							Plugin.MaterialDefinition.PropertyParser.Properties[
								mdp.Name
							]
					).Clone();
					pd.Property = mdp.Value;
					ht[mdp.Name] = pd;
				}
				else
				{
					ht[mdp.Name] = mdp.Value;
				}
			}

			pob = new Ambertation.PropertyObjectBuilderExt(ht);
			pg.SelectedObject = pob.Instance;
		}

		private void pg_PropertyValueChanged(
			object s,
			PropertyValueChangedEventArgs e
		)
		{
			if (Tag == null)
			{
				return;
			}

			if (pob == null)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				Tag;
			object o = pob.Properties[e.ChangedItem.Label];
			md.GetProperty(e.ChangedItem.Label).Value = o is bool ? (bool)o ? "1" : "0" : o.ToString();

			md.Parent.Changed = true;
		}

		internal void TxmtChangeTab(object sender, EventArgs e)
		{
			if (Tag == null)
			{
				return;
			}

			Plugin.MaterialDefinition md = (Plugin.MaterialDefinition)
				Tag;
			if (Parent == null)
			{
				return;
			}

			if (((TabControl)Parent).SelectedTab == this)
			{
				md.Refresh();
			}
		}
	}
}
