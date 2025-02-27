using System;
using System.Collections;
using System.Windows.Forms;

using SimPe.Data;

namespace SimPe.Plugin.UI
{
	/// <summary>
	/// Summary description for SkintonePreferences.
	/// </summary>
	public class ClothingPreferences : PreferencesPanel // System.Windows.Forms.Form //
	{
		private TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private CheckedListBox clbCategories;
		private CheckedListBox clbAges;
		private CheckedListBox clbGender;
		private ComboBox cbOutfitType;
		private ComboBox cbShoeType;
		private ComboBox cbSpeciesType;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
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
			get
			{
				return base.Settings as ClothingSettings;
			}
			set
			{
				base.Settings = value;
			}
		}
		public RecolorType Tipe = RecolorType.Unsupported;

		public ClothingPreferences()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			Text = "Properties";
			BuildListItems();
			InitDropDown();
		}

		#region Initial Setup

		protected override void OnSettingsChanged()
		{
			if (Settings != null)
			{
				SuspendLayout();
				ClothingSettings sset = Settings;
				fireSettingsChangedEvent = false;
				SelectEnumItems(clbCategories, sset.OutfitCat);
				SelectEnumItems(clbAges, sset.Age);
				SelectEnumItems(clbGender, sset.Gender);
				SelectEnumItem(cbOutfitType, sset.OutfitType);
				SelectEnumItem(cbShoeType, sset.ShoeType);
				SelectEnumItem(cbSpeciesType, sset.Species);
				SelectSingleEnumItem(cbOverlayType, sset.OverlayType);
				Boolset flug = sset.Flaggery;
				cbhide.Checked = flug[0];
				cbhat.Checked = flug[1];
				cbavail.Checked = flug[3];
				cbBody.SelectedIndex = 0;
				for (int i = 0; i < cbBody.Items.Count; i++)
				{
					object o = cbBody.Items[i];
					MetaData.Bodyshape at;
					if (o.GetType() == typeof(Alias))
					{
						at = (LocalizedBodyshape)((uint)((Alias)o).Id);
					}
					else
					{
						at = (LocalizedBodyshape)o;
					}

					if (at == sset.Figure)
					{
						cbBody.SelectedIndex = i;
						break;
					}
				}
				InitDisableControls();
			}
			fireSettingsChangedEvent = true;
			ResumeLayout(false);
		}

		public override void OnCommitSettings()
		{
			if (Settings != null)
			{
				Settings.OutfitCat = (OutfitCats)BuildListValue(
					clbCategories
				);
				Settings.Age = (Ages)BuildListValue(clbAges);
				Settings.Gender = (SimGender)BuildListValue(clbGender);
				if (cbOutfitType.SelectedItem != null)
				{
					Settings.OutfitType = (OutfitType)
						cbOutfitType.SelectedItem;
				}

				if (cbShoeType.SelectedItem != null)
				{
					Settings.ShoeType = (ShoeType)cbShoeType.SelectedItem;
				}

				if (cbSpeciesType.SelectedItem != null)
				{
					Settings.Species = (SpeciesType)
						cbSpeciesType.SelectedItem;
				}

				if (cbOverlayType.SelectedItem != null)
				{
					Settings.OverlayType = (TextureOverlayTypes)
						cbOverlayType.SelectedItem;
				}
			}
		}

		void InitDisableControls()
		{
			if (Tipe == RecolorType.Skin)
			{
				cbShoeType.Enabled = cbBody.Enabled = true;
			}
			else
			{
				cbShoeType.Enabled = cbBody.Enabled = false;
			}

			if (Tipe == RecolorType.Hairtone)
			{
				cbhat.Enabled = true;
			}
			else
			{
				cbhat.Enabled = false;
			}

			if (Tipe == RecolorType.TextureOverlay || Tipe == RecolorType.MeshOverlay)
			{
				cbSpeciesType.Enabled = cbOverlayType.Enabled = true;
			}
			else
			{
				cbSpeciesType.Enabled = cbOverlayType.Enabled = false;
			}

			if (Tipe == RecolorType.Skintone)
			{
				cbavail.Enabled = cbhide.Enabled = false;
			}
			else
			{
				cbavail.Enabled = cbhide.Enabled = true;
			}
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			//this.components = new System.ComponentModel.Container();
			clbCategories = new CheckedListBox();
			tabControl1 = new TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tabPage2 = new System.Windows.Forms.TabPage();
			clbAges = new CheckedListBox();
			tabPage3 = new System.Windows.Forms.TabPage();
			cbhat = new CheckBox();
			cbhide = new CheckBox();
			cbavail = new CheckBox();
			lbBody = new Label();
			cbBody = new ComboBox();
			cbOverlayType = new ComboBox();
			label5 = new Label();
			cbSpeciesType = new ComboBox();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			label1 = new Label();
			clbGender = new CheckedListBox();
			cbShoeType = new ComboBox();
			cbOutfitType = new ComboBox();
			//this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			tabPage3.SuspendLayout();
			SuspendLayout();
			//
			// clbCategories
			//
			clbCategories.CheckOnClick = true;
			clbCategories.Dock = DockStyle.Fill;
			clbCategories.Location = new System.Drawing.Point(0, 0);
			clbCategories.MultiColumn = true;
			clbCategories.Name = "clbCategories";
			clbCategories.Size = new System.Drawing.Size(507, 154);
			clbCategories.TabIndex = 0;
			clbCategories.SelectedIndexChanged += new EventHandler(
				Handle_SettingsControl_Changed
			);
			//
			// tabControl1
			//
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.Location = new System.Drawing.Point(0, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(515, 186);
			tabControl1.TabIndex = 1;
			//
			// tabPage1
			//
			tabPage1.Controls.Add(clbCategories);
			tabPage1.Location = new System.Drawing.Point(4, 22);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new System.Drawing.Size(507, 160);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Categories";
			//
			// tabPage2
			//
			tabPage2.Controls.Add(clbAges);
			tabPage2.Location = new System.Drawing.Point(4, 22);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new System.Drawing.Size(507, 160);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Ages";
			//
			// clbAges
			//
			clbAges.CheckOnClick = true;
			clbAges.Dock = DockStyle.Fill;
			clbAges.Location = new System.Drawing.Point(0, 0);
			clbAges.MultiColumn = true;
			clbAges.Name = "clbAges";
			clbAges.Size = new System.Drawing.Size(507, 154);
			clbAges.TabIndex = 0;
			clbAges.SelectedIndexChanged += new EventHandler(
				Handle_SettingsControl_Changed
			);
			//
			// tabPage3
			//
			tabPage3.AutoScroll = true;
			tabPage3.Controls.Add(cbhat);
			tabPage3.Controls.Add(cbhide);
			tabPage3.Controls.Add(cbavail);
			tabPage3.Controls.Add(lbBody);
			tabPage3.Controls.Add(cbBody);
			tabPage3.Controls.Add(cbOverlayType);
			tabPage3.Controls.Add(label5);
			tabPage3.Controls.Add(cbSpeciesType);
			tabPage3.Controls.Add(label4);
			tabPage3.Controls.Add(label3);
			tabPage3.Controls.Add(label2);
			tabPage3.Controls.Add(label1);
			tabPage3.Controls.Add(clbGender);
			tabPage3.Controls.Add(cbShoeType);
			tabPage3.Controls.Add(cbOutfitType);
			tabPage3.Location = new System.Drawing.Point(4, 22);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new System.Drawing.Size(507, 160);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Other";
			//
			// cbhat
			//
			cbhat.AutoSize = true;
			cbhat.BackColor = System.Drawing.Color.Transparent;
			cbhat.Location = new System.Drawing.Point(284, 101);
			cbhat.Name = "cbhat";
			cbhat.Size = new System.Drawing.Size(95, 17);
			cbhat.TabIndex = 15;
			cbhat.Text = "Includes a Hat";
			cbhat.UseVisualStyleBackColor = false;
			cbhat.CheckedChanged += new EventHandler(
				cbflags_CheckedChanged
			);
			//
			// cbhide
			//
			cbhide.AutoSize = true;
			cbhide.BackColor = System.Drawing.Color.Transparent;
			cbhide.Location = new System.Drawing.Point(284, 77);
			cbhide.Name = "cbhide";
			cbhide.Size = new System.Drawing.Size(105, 17);
			cbhide.TabIndex = 14;
			cbhide.Text = "Not in Catalogue";
			cbhide.UseVisualStyleBackColor = false;
			cbhide.CheckedChanged += new EventHandler(
				cbflags_CheckedChanged
			);
			//
			// cbavail
			//
			cbavail.AutoSize = true;
			cbavail.BackColor = System.Drawing.Color.Transparent;
			cbavail.Location = new System.Drawing.Point(284, 125);
			cbavail.Name = "cbavail";
			cbavail.Size = new System.Drawing.Size(131, 17);
			cbavail.TabIndex = 13;
			cbavail.Text = "Not Available to NPCs";
			toolTip1.SetToolTip(
				cbavail,
				"Paticularly for Outfits\r\nThe game won\'t automatically assign the outfit when this"
					+ " flag is set\r\nNot sure how well it works for other file types"
			);
			cbavail.UseVisualStyleBackColor = false;
			cbavail.CheckedChanged += new EventHandler(
				cbflags_CheckedChanged
			);
			//
			// lbBody
			//
			lbBody.AutoSize = true;
			lbBody.Font = new System.Drawing.Font(
				"Comic Sans MS",
				9.75F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			lbBody.Location = new System.Drawing.Point(180, 109);
			lbBody.Name = "lbBody";
			lbBody.Size = new System.Drawing.Size(79, 18);
			lbBody.TabIndex = 12;
			lbBody.Text = "Body Shape";
			//
			// cbBody
			//
			cbBody.DropDownStyle = ComboBoxStyle.DropDownList;
			cbBody.Location = new System.Drawing.Point(6, 106);
			cbBody.Name = "cbBody";
			cbBody.Size = new System.Drawing.Size(168, 21);
			cbBody.TabIndex = 11;
			toolTip1.SetToolTip(
				cbBody,
				"For users of the BSOK, Angels & Nurses Stuff or T&A"
			);
			cbBody.SelectedIndexChanged += new EventHandler(
				cbBody_SelectedIndexChanged
			);
			//
			// cbOverlayType
			//
			cbOverlayType.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbOverlayType.Enabled = false;
			cbOverlayType.Location = new System.Drawing.Point(140, 20);
			cbOverlayType.Name = "cbOverlayType";
			cbOverlayType.Size = new System.Drawing.Size(120, 21);
			cbOverlayType.TabIndex = 10;
			//
			// label5
			//
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label5.Location = new System.Drawing.Point(137, 4);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(72, 13);
			label5.TabIndex = 9;
			label5.Text = "Overlay Type";
			//
			// cbSpeciesType
			//
			cbSpeciesType.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbSpeciesType.Enabled = false;
			cbSpeciesType.Location = new System.Drawing.Point(140, 64);
			cbSpeciesType.Name = "cbSpeciesType";
			cbSpeciesType.Size = new System.Drawing.Size(120, 21);
			cbSpeciesType.TabIndex = 8;
			//
			// label4
			//
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label4.Location = new System.Drawing.Point(137, 47);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(43, 13);
			label4.TabIndex = 7;
			label4.Text = "Species";
			//
			// label3
			//
			label3.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label3.Location = new System.Drawing.Point(268, 4);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(42, 11);
			label3.TabIndex = 5;
			label3.Text = "Gender";
			//
			// label2
			//
			label2.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label2.Location = new System.Drawing.Point(3, 47);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(59, 12);
			label2.TabIndex = 4;
			label2.Text = "Shoe Type";
			//
			// label1
			//
			label1.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			label1.Location = new System.Drawing.Point(4, 3);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(72, 13);
			label1.TabIndex = 3;
			label1.Text = "Outfit Type";
			//
			// clbGender
			//
			clbGender.CheckOnClick = true;
			clbGender.Location = new System.Drawing.Point(271, 20);
			clbGender.Name = "clbGender";
			clbGender.Size = new System.Drawing.Size(91, 49);
			clbGender.TabIndex = 2;
			clbGender.ThreeDCheckBoxes = true;
			clbGender.SelectedIndexChanged += new EventHandler(
				Handle_SettingsControl_Changed
			);
			//
			// cbShoeType
			//
			cbShoeType.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbShoeType.Location = new System.Drawing.Point(7, 64);
			cbShoeType.Name = "cbShoeType";
			cbShoeType.Size = new System.Drawing.Size(120, 21);
			cbShoeType.TabIndex = 1;
			cbShoeType.SelectedIndexChanged += new EventHandler(
				Handle_SettingsControl_Changed
			);
			//
			// cbOutfitType
			//
			cbOutfitType.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbOutfitType.Location = new System.Drawing.Point(7, 20);
			cbOutfitType.Name = "cbOutfitType";
			cbOutfitType.Size = new System.Drawing.Size(120, 21);
			cbOutfitType.TabIndex = 0;
			cbOutfitType.SelectedIndexChanged += new EventHandler(
				Handle_SettingsControl_Changed
			);
			//
			// toolTip1
			//
			//this.toolTip1.IsBalloon = true;
			//this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			//
			// ClothingPreferences
			//
			ClientSize = new System.Drawing.Size(515, 186);
			Controls.Add(tabControl1);
			Name = "ClothingPreferences";
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			tabPage3.ResumeLayout(false);
			tabPage3.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		void InitDropDown()
		{
			cbBody.Items.Clear();
			foreach (uint i in Enum.GetValues(typeof(MetaData.Bodyshape)))
			{
				cbBody.Items.Add(
					new LocalizedBodyshape((MetaData.Bodyshape)i)
				);
			}
		}

		#endregion

		#region Control Calls

		private void cbBody_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (fireSettingsChangedEvent)
			{
				Settings.Figure = (LocalizedBodyshape)cbBody.SelectedItem;
				OnSettingsChanged(e);
			}
		}

		private void cbflags_CheckedChanged(object sender, EventArgs e)
		{
			if (fireSettingsChangedEvent)
			{
				Boolset flug = Settings.Flaggery;
				flug[0] = cbhide.Checked;
				flug[1] = cbhat.Checked;
				flug[3] = cbavail.Checked;
				Settings.Flaggery = flug;
				OnSettingsChanged(e);
			}
		}

		void Handle_SettingsControl_Changed(object sender, ItemCheckEventArgs e)
		{
			Handle_SettingsControl_Changed(sender, EventArgs.Empty);
		}

		void Handle_SettingsControl_Changed(object sender, EventArgs e)
		{
			if (fireSettingsChangedEvent)
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
			if (SettingsChanged != null && fireSettingsChangedEvent)
			{
				SettingsChanged(this, e);
			}
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
			{
				ret |= Convert.ToUInt64(value);
			}

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
			clbGender.Items.Add(SimGender.Female);
			clbGender.Items.Add(SimGender.Male);
		}

		static void AddItems(IList target, Type enumType)
		{
			foreach (Enum e in Enum.GetValues(enumType))
			{
				target.Add(e);
			}
		}

		#endregion
	}
}
