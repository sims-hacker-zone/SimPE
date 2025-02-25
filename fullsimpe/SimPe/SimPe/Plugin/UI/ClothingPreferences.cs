using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SimPe.Data;

namespace SimPe.Plugin.UI
{
	/// <summary>
	/// Summary description for SkintonePreferences.
	/// </summary>
	public class ClothingPreferences : PreferencesPanel // System.Windows.Forms.Form //
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.CheckedListBox clbCategories;
		private System.Windows.Forms.CheckedListBox clbAges;
		private System.Windows.Forms.CheckedListBox clbGender;
		private System.Windows.Forms.ComboBox cbOutfitType;
		private System.Windows.Forms.ComboBox cbShoeType;
		private System.Windows.Forms.ComboBox cbSpeciesType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private ComboBox cbOverlayType;
		private Label label5;
		private Label lbBody;
		private ComboBox cbBody;
		private CheckBox cbavail;
		private CheckBox cbhat;
		private CheckBox cbhide;

		private bool fireSettingsChangedEvent;

		//private ToolTip toolTip1;
		//private IContainer components;
		public event EventHandler SettingsChanged;
		public new ClothingSettings Settings
		{
			get { return base.Settings as ClothingSettings; }
			set { base.Settings = value; }
		}
		public RecolorType Tipe = RecolorType.Unsupported;

		public ClothingPreferences()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			this.Text = "Properties";
			BuildListItems();
			InitDropDown();
		}

		#region Initial Setup

		protected override void OnSettingsChanged()
		{
			if (this.Settings != null)
			{
				this.SuspendLayout();
				ClothingSettings sset = this.Settings;
				this.fireSettingsChangedEvent = false;
				this.SelectEnumItems(this.clbCategories, sset.OutfitCat);
				this.SelectEnumItems(this.clbAges, sset.Age);
				this.SelectEnumItems(this.clbGender, sset.Gender);
				this.SelectEnumItem(this.cbOutfitType, sset.OutfitType);
				this.SelectEnumItem(this.cbShoeType, sset.ShoeType);
				this.SelectEnumItem(this.cbSpeciesType, sset.Species);
				this.SelectSingleEnumItem(this.cbOverlayType, sset.OverlayType);
				Boolset flug = sset.Flaggery;
				this.cbhide.Checked = flug[0];
				this.cbhat.Checked = flug[1];
				this.cbavail.Checked = flug[3];
				this.cbBody.SelectedIndex = 0;
				for (int i = 0; i < this.cbBody.Items.Count; i++)
				{
					object o = this.cbBody.Items[i];
					Data.MetaData.Bodyshape at;
					if (o.GetType() == typeof(Alias))
						at = (Data.LocalizedBodyshape)((uint)((Alias)o).Id);
					else
						at = (Data.LocalizedBodyshape)o;
					if (at == sset.Figure)
					{
						this.cbBody.SelectedIndex = i;
						break;
					}
				}
				InitDisableControls();
			}
			this.fireSettingsChangedEvent = true;
			this.ResumeLayout(false);
		}

		public override void OnCommitSettings()
		{
			if (this.Settings != null)
			{
				this.Settings.OutfitCat = (OutfitCats)BuildListValue(
					this.clbCategories
				);
				this.Settings.Age = (Ages)BuildListValue(this.clbAges);
				this.Settings.Gender = (SimGender)BuildListValue(this.clbGender);
				if (this.cbOutfitType.SelectedItem != null)
					this.Settings.OutfitType = (OutfitType)
						this.cbOutfitType.SelectedItem;
				if (this.cbShoeType.SelectedItem != null)
					this.Settings.ShoeType = (ShoeType)this.cbShoeType.SelectedItem;
				if (this.cbSpeciesType.SelectedItem != null)
					this.Settings.Species = (SpeciesType)
						this.cbSpeciesType.SelectedItem;
				if (this.cbOverlayType.SelectedItem != null)
					this.Settings.OverlayType = (TextureOverlayTypes)
						this.cbOverlayType.SelectedItem;
			}
		}

		void InitDisableControls()
		{
			if (Tipe == RecolorType.Skin)
				this.cbShoeType.Enabled = this.cbBody.Enabled = true;
			else
				this.cbShoeType.Enabled = this.cbBody.Enabled = false;
			if (Tipe == RecolorType.Hairtone)
				this.cbhat.Enabled = true;
			else
				this.cbhat.Enabled = false;
			if (Tipe == RecolorType.TextureOverlay || Tipe == RecolorType.MeshOverlay)
				this.cbSpeciesType.Enabled = this.cbOverlayType.Enabled = true;
			else
				this.cbSpeciesType.Enabled = this.cbOverlayType.Enabled = false;
			if (Tipe == RecolorType.Skintone)
				this.cbavail.Enabled = this.cbhide.Enabled = false;
			else
				this.cbavail.Enabled = this.cbhide.Enabled = true;
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			//this.components = new System.ComponentModel.Container();
			this.clbCategories = new System.Windows.Forms.CheckedListBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.clbAges = new System.Windows.Forms.CheckedListBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.cbhat = new System.Windows.Forms.CheckBox();
			this.cbhide = new System.Windows.Forms.CheckBox();
			this.cbavail = new System.Windows.Forms.CheckBox();
			this.lbBody = new System.Windows.Forms.Label();
			this.cbBody = new System.Windows.Forms.ComboBox();
			this.cbOverlayType = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbSpeciesType = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.clbGender = new System.Windows.Forms.CheckedListBox();
			this.cbShoeType = new System.Windows.Forms.ComboBox();
			this.cbOutfitType = new System.Windows.Forms.ComboBox();
			//this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			//
			// clbCategories
			//
			this.clbCategories.CheckOnClick = true;
			this.clbCategories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clbCategories.Location = new System.Drawing.Point(0, 0);
			this.clbCategories.MultiColumn = true;
			this.clbCategories.Name = "clbCategories";
			this.clbCategories.Size = new System.Drawing.Size(507, 154);
			this.clbCategories.TabIndex = 0;
			this.clbCategories.SelectedIndexChanged += new System.EventHandler(
				this.Handle_SettingsControl_Changed
			);
			//
			// tabControl1
			//
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(515, 186);
			this.tabControl1.TabIndex = 1;
			//
			// tabPage1
			//
			this.tabPage1.Controls.Add(this.clbCategories);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(507, 160);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Categories";
			//
			// tabPage2
			//
			this.tabPage2.Controls.Add(this.clbAges);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(507, 160);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Ages";
			//
			// clbAges
			//
			this.clbAges.CheckOnClick = true;
			this.clbAges.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clbAges.Location = new System.Drawing.Point(0, 0);
			this.clbAges.MultiColumn = true;
			this.clbAges.Name = "clbAges";
			this.clbAges.Size = new System.Drawing.Size(507, 154);
			this.clbAges.TabIndex = 0;
			this.clbAges.SelectedIndexChanged += new System.EventHandler(
				this.Handle_SettingsControl_Changed
			);
			//
			// tabPage3
			//
			this.tabPage3.AutoScroll = true;
			this.tabPage3.Controls.Add(this.cbhat);
			this.tabPage3.Controls.Add(this.cbhide);
			this.tabPage3.Controls.Add(this.cbavail);
			this.tabPage3.Controls.Add(this.lbBody);
			this.tabPage3.Controls.Add(this.cbBody);
			this.tabPage3.Controls.Add(this.cbOverlayType);
			this.tabPage3.Controls.Add(this.label5);
			this.tabPage3.Controls.Add(this.cbSpeciesType);
			this.tabPage3.Controls.Add(this.label4);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Controls.Add(this.label1);
			this.tabPage3.Controls.Add(this.clbGender);
			this.tabPage3.Controls.Add(this.cbShoeType);
			this.tabPage3.Controls.Add(this.cbOutfitType);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(507, 160);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Other";
			//
			// cbhat
			//
			this.cbhat.AutoSize = true;
			this.cbhat.BackColor = System.Drawing.Color.Transparent;
			this.cbhat.Location = new System.Drawing.Point(284, 101);
			this.cbhat.Name = "cbhat";
			this.cbhat.Size = new System.Drawing.Size(95, 17);
			this.cbhat.TabIndex = 15;
			this.cbhat.Text = "Includes a Hat";
			this.cbhat.UseVisualStyleBackColor = false;
			this.cbhat.CheckedChanged += new System.EventHandler(
				this.cbflags_CheckedChanged
			);
			//
			// cbhide
			//
			this.cbhide.AutoSize = true;
			this.cbhide.BackColor = System.Drawing.Color.Transparent;
			this.cbhide.Location = new System.Drawing.Point(284, 77);
			this.cbhide.Name = "cbhide";
			this.cbhide.Size = new System.Drawing.Size(105, 17);
			this.cbhide.TabIndex = 14;
			this.cbhide.Text = "Not in Catalogue";
			this.cbhide.UseVisualStyleBackColor = false;
			this.cbhide.CheckedChanged += new System.EventHandler(
				this.cbflags_CheckedChanged
			);
			//
			// cbavail
			//
			this.cbavail.AutoSize = true;
			this.cbavail.BackColor = System.Drawing.Color.Transparent;
			this.cbavail.Location = new System.Drawing.Point(284, 125);
			this.cbavail.Name = "cbavail";
			this.cbavail.Size = new System.Drawing.Size(131, 17);
			this.cbavail.TabIndex = 13;
			this.cbavail.Text = "Not Available to NPCs";
			this.toolTip1.SetToolTip(
				this.cbavail,
				"Paticularly for Outfits\r\nThe game won\'t automatically assign the outfit when this"
					+ " flag is set\r\nNot sure how well it works for other file types"
			);
			this.cbavail.UseVisualStyleBackColor = false;
			this.cbavail.CheckedChanged += new System.EventHandler(
				this.cbflags_CheckedChanged
			);
			//
			// lbBody
			//
			this.lbBody.AutoSize = true;
			this.lbBody.Font = new System.Drawing.Font(
				"Comic Sans MS",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.lbBody.Location = new System.Drawing.Point(180, 109);
			this.lbBody.Name = "lbBody";
			this.lbBody.Size = new System.Drawing.Size(79, 18);
			this.lbBody.TabIndex = 12;
			this.lbBody.Text = "Body Shape";
			//
			// cbBody
			//
			this.cbBody.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBody.Location = new System.Drawing.Point(6, 106);
			this.cbBody.Name = "cbBody";
			this.cbBody.Size = new System.Drawing.Size(168, 21);
			this.cbBody.TabIndex = 11;
			this.toolTip1.SetToolTip(
				this.cbBody,
				"For users of the BSOK, Angels & Nurses Stuff or T&A"
			);
			this.cbBody.SelectedIndexChanged += new System.EventHandler(
				this.cbBody_SelectedIndexChanged
			);
			//
			// cbOverlayType
			//
			this.cbOverlayType.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbOverlayType.Enabled = false;
			this.cbOverlayType.Location = new System.Drawing.Point(140, 20);
			this.cbOverlayType.Name = "cbOverlayType";
			this.cbOverlayType.Size = new System.Drawing.Size(120, 21);
			this.cbOverlayType.TabIndex = 10;
			//
			// label5
			//
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label5.Location = new System.Drawing.Point(137, 4);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Overlay Type";
			//
			// cbSpeciesType
			//
			this.cbSpeciesType.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbSpeciesType.Enabled = false;
			this.cbSpeciesType.Location = new System.Drawing.Point(140, 64);
			this.cbSpeciesType.Name = "cbSpeciesType";
			this.cbSpeciesType.Size = new System.Drawing.Size(120, 21);
			this.cbSpeciesType.TabIndex = 8;
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label4.Location = new System.Drawing.Point(137, 47);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Species";
			//
			// label3
			//
			this.label3.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label3.Location = new System.Drawing.Point(268, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 11);
			this.label3.TabIndex = 5;
			this.label3.Text = "Gender";
			//
			// label2
			//
			this.label2.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label2.Location = new System.Drawing.Point(3, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "Shoe Type";
			//
			// label1
			//
			this.label1.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label1.Location = new System.Drawing.Point(4, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Outfit Type";
			//
			// clbGender
			//
			this.clbGender.CheckOnClick = true;
			this.clbGender.Location = new System.Drawing.Point(271, 20);
			this.clbGender.Name = "clbGender";
			this.clbGender.Size = new System.Drawing.Size(91, 49);
			this.clbGender.TabIndex = 2;
			this.clbGender.ThreeDCheckBoxes = true;
			this.clbGender.SelectedIndexChanged += new System.EventHandler(
				this.Handle_SettingsControl_Changed
			);
			//
			// cbShoeType
			//
			this.cbShoeType.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbShoeType.Location = new System.Drawing.Point(7, 64);
			this.cbShoeType.Name = "cbShoeType";
			this.cbShoeType.Size = new System.Drawing.Size(120, 21);
			this.cbShoeType.TabIndex = 1;
			this.cbShoeType.SelectedIndexChanged += new System.EventHandler(
				this.Handle_SettingsControl_Changed
			);
			//
			// cbOutfitType
			//
			this.cbOutfitType.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbOutfitType.Location = new System.Drawing.Point(7, 20);
			this.cbOutfitType.Name = "cbOutfitType";
			this.cbOutfitType.Size = new System.Drawing.Size(120, 21);
			this.cbOutfitType.TabIndex = 0;
			this.cbOutfitType.SelectedIndexChanged += new System.EventHandler(
				this.Handle_SettingsControl_Changed
			);
			//
			// toolTip1
			//
			//this.toolTip1.IsBalloon = true;
			//this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			//
			// ClothingPreferences
			//
			this.ClientSize = new System.Drawing.Size(515, 186);
			this.Controls.Add(this.tabControl1);
			this.Name = "ClothingPreferences";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion

		void InitDropDown()
		{
			this.cbBody.Items.Clear();
			foreach (uint i in Enum.GetValues(typeof(Data.MetaData.Bodyshape)))
				this.cbBody.Items.Add(
					new LocalizedBodyshape((Data.MetaData.Bodyshape)i)
				);
		}

		#endregion

		#region Control Calls

		private void cbBody_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.fireSettingsChangedEvent)
			{
				this.Settings.Figure = (LocalizedBodyshape)this.cbBody.SelectedItem;
				OnSettingsChanged(e);
			}
		}

		private void cbflags_CheckedChanged(object sender, EventArgs e)
		{
			if (this.fireSettingsChangedEvent)
			{
				Boolset flug = this.Settings.Flaggery;
				flug[0] = cbhide.Checked;
				flug[1] = cbhat.Checked;
				flug[3] = cbavail.Checked;
				this.Settings.Flaggery = flug;
				OnSettingsChanged(e);
			}
		}

		void Handle_SettingsControl_Changed(object sender, ItemCheckEventArgs e)
		{
			Handle_SettingsControl_Changed(sender, EventArgs.Empty);
		}

		void Handle_SettingsControl_Changed(object sender, EventArgs e)
		{
			if (this.fireSettingsChangedEvent)
			{
				OnCommitSettings();
				OnSettingsChanged(e);
				InitDisableControls();
			}
		}

		#endregion

		#region SubRoutines

		protected void OnSettingsChanged(EventArgs e)
		{
			if (this.SettingsChanged != null && this.fireSettingsChangedEvent)
				SettingsChanged(this, e);
		}

		void SelectEnumItems(CheckedListBox list, Enum values)
		{
			list.ClearSelected();
			for (int i = 0; i < list.Items.Count; i++)
			{
				Enum value = (Enum)list.Items[i];
				list.SetItemChecked(i, Utility.EnumTest(values, value));
			}
		}

		void SelectEnumItem(ComboBox list, Enum values)
		{
			for (int i = 0; i < list.Items.Count; i++)
			{
				Enum value = (Enum)list.Items[i];
				if (Utility.EnumCheck(values, value))
				{
					list.SelectedIndex = i;
					return;
				}
			}
			list.SelectedIndex = -1;
		}

		void SelectSingleEnumItem(ComboBox list, Enum values)
		{
			for (int i = 0; i < list.Items.Count; i++)
			{
				Enum value = (Enum)list.Items[i];
				if (value.Equals(values))
				{
					list.SelectedIndex = i;
					return;
				}
			}
			list.SelectedIndex = -1;
		}

		ulong BuildListValue(CheckedListBox list)
		{
			ulong ret = 0;
			foreach (Enum value in list.CheckedItems)
				ret |= Convert.ToUInt64(value);
			return ret;
		}

		void BuildListItems()
		{
			AddItems(cbShoeType.Items, typeof(ShoeType));
			AddItems(cbOutfitType.Items, typeof(OutfitType));
			AddItems(cbSpeciesType.Items, typeof(SpeciesType));
			AddItems(cbOverlayType.Items, typeof(TextureOverlayTypes));
			AddItems(clbAges.Items, typeof(Ages));
			AddItems(clbCategories.Items, typeof(OutfitCats));
			// AddItems(clbCategories.Items, typeof(SkinCategories));
			this.clbGender.Items.Add(SimGender.Female);
			this.clbGender.Items.Add(SimGender.Male);
		}

		static void AddItems(IList target, Type enumType)
		{
			foreach (Enum e in Enum.GetValues(enumType))
				target.Add(e);
		}

		#endregion
	}
}
