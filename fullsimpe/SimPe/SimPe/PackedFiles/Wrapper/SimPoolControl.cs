// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Ambertation.Windows.Forms.Graph;

using SimPe.PackedFiles.Sdsc;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// You can use this Control whenever you need to display a SimPool
	/// </summary>
	[System.ComponentModel.DefaultEvent("SelectedSimChanged")]
	public class SimPoolControl : System.Windows.Forms.UserControl
	{
		public SimPoolControl()
		{
			details = false;
			RightClickSelect = false;
			InitializeComponent();
		}

		protected SimListView gp;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader chHouse;
		internal System.Windows.Forms.ComboBox cbhousehold;
		private System.ComponentModel.IContainer components;

		public SDesc SelectedElement
		{
			get => gp.SelectedItems.Count < 1 ? null : (SDesc)(ExtSDesc)gp.SelectedItems[0].Tag;
			set => FindItem(value);
		}

		public ExtSDesc SelectedSim
		{
			get => gp.SelectedItems.Count < 1 ? null : (ExtSDesc)gp.SelectedItems[0].Tag;
			set => FindItem(value);
		}

		Interfaces.Files.IPackageFile pkg;
		public Interfaces.Files.IPackageFile Package
		{
			get => pkg;
			set
			{
				if (pkg != value)
				{
					if (value == null)
					{
						pkg = value;
					}
					else if (Helper.IsNeighborhoodFile(value.FileName))
					{
						pkg = value;
					}
					else
					{
						return;
					}

					UpdateContent();
				}
			}
		}

		protected void UpdateContent()
		{
			ExtSDesc selectedSim = SelectedSim;
			string house = selectedSim == null ? "" : selectedSim.HouseholdName;

			cbhousehold.Items.Clear();
			cbhousehold.Items.Add(
				Localization.GetString("[All Households]")
			);

			if (pkg == null)
			{
				cbhousehold.SelectedIndex = 0;
				return;
			}

			List<string> names = FileTableBase
						.ProviderRegistry.SimDescriptionProvider.GetHouseholdNames(
							out string chouse
						).ToList();
			cbhousehold.Items.AddRange(names.ToArray());

			int index = names.IndexOf(house);
			if (index < 0)
			{
				index = names.IndexOf(chouse);
			}

			cbhousehold.SelectedIndex = index + 1;
			SelectedSim = selectedSim;
		}

		bool details;
		public bool SimDetails
		{
			get => details;
			set
			{
				if (details != value)
				{
					details = value;
					SetViewMode();
				}
			}
		}

		public class AddSimToPoolEventArgs : EventArgs
		{
			public ExtSDesc SimDescription
			{
				get;
			}

			public string Name
			{
				get;
			}

			public string Household
			{
				get;
			}

			public bool Cancel
			{
				get; set;
			}

			public System.Drawing.Image Image
			{
				get;
			}
			public int GroupIndex
			{
				get; set;
			}

			internal AddSimToPoolEventArgs(
				ExtSDesc sdsc,
				string name,
				string household,
				System.Drawing.Image img,
				int groupindex
			)
			{
				SimDescription = sdsc;
				Name = name;
				Image = img;
				Household = household;
				GroupIndex = groupindex;

				Cancel = false;
			}

			public override string ToString()
			{
				return Name;
			}
		}

		public delegate void AddSimToPoolEvent(object sender, AddSimToPoolEventArgs e);
		public event AddSimToPoolEvent AddSimToPool;

		protected virtual void OnAddSimToPool(AddSimToPoolEventArgs e)
		{
		}

		AddSimToPoolEventArgs DoAddSimToPool(
			ExtSDesc sdsc,
			string name,
			string household,
			System.Drawing.Image img
		)
		{
			AddSimToPoolEventArgs e = new AddSimToPoolEventArgs(
				sdsc,
				name,
				household,
				img,
				0
			);
			OnAddSimToPool(e);
			if (AddSimToPool != null)
			{
				AddSimToPool(this, e);
			}

			return e;
		}

		protected virtual System.Drawing.Color GetBackgroundColor(
			ExtSDesc sdsc
		)
		{
			return GetImagePanelColor(sdsc);
		}

		void UpdateSimList(string household)
		{
			ExtSDesc selectedSim = SelectedSim;
			if (
				household != null
				&& selectedSim != null
				&& selectedSim.HouseholdName != household
			)
			{
				selectedSim = null;
			}

			gp.BeginUpdate();
			gp.Clear();
			lastsel = null;

			IEnumerable<Interfaces.Wrapper.ISDesc> ht = FileTableBase
				.ProviderRegistry
				.SimDescriptionProvider
				.SimInstance.SelectMany(item => item);
			Wait.SubStart(ht.Count());
			int ct = 0;

			SortedList map = new SortedList();

			foreach (ExtSDesc sdsc in ht)
			{
				if (household != null && household != sdsc.HouseholdName)
				{
					continue;
				}

				string name = sdsc.SimName + " " + sdsc.SimFamilyName;
				System.Drawing.Image simimg = gp.GetSimIcon(
					sdsc,
					GetBackgroundColor(sdsc)
				);
				AddSimToPoolEventArgs ret = DoAddSimToPool(
					sdsc,
					name,
					household,
					simimg
				);

				if (!ret.Cancel)
				{
					SteepValley.Windows.Forms.XPListViewItem eip = gp.Add(sdsc, simimg);
					eip.Tag = sdsc;
					eip.GroupIndex = ret.GroupIndex;

					if (map.ContainsKey(name))
					{
						name += " (" + sdsc.FileDescriptor.Instance.ToString() + ")";
					}

					map[name] = eip;
					Wait.Message = eip.Text;
				}

				Wait.Progress = ct++;
			}

			SetViewMode();

			if (gp.Items.Count > 0)
			{
				if (selectedSim != null)
				{
					SelectedSim = selectedSim;
				}
				else
				{
					gp.Items[0].Selected = true;
				}

				try
				{
					SelectedSimChanged?.Invoke(this, ((ExtSDesc)gp.Items[0].Tag).Image, (ExtSDesc)gp.Items[0].Tag);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			}

			gp.EndUpdate();
			Wait.SubStop();
		}

		private void SetViewMode()
		{
			gp.TileSize = new System.Drawing.Size(00, 00);

			gp.TileColumns = new int[] { 1, 2, 6, 3, 4, 5 };
			gp.SetColumnStyle(1, gp.Font, System.Drawing.Color.Gray);
			gp.SetColumnStyle(2, gp.Font, System.Drawing.Color.Gray);
			gp.SetColumnStyle(3, gp.Font, System.Drawing.Color.Gray);
			gp.SetColumnStyle(4, gp.Font, System.Drawing.Color.Gray);

			gp.View = details ? SteepValley.Windows.Forms.ExtendedView.Tile : SteepValley.Windows.Forms.ExtendedView.LargeIcon;
		}

		public static System.Drawing.Color GetImagePanelColor(SDesc sdesc)
		{
			if (sdesc.Unlinked != 0)
			{
				return !sdesc.AvailableCharacterData ? System.Drawing.Color.FromArgb(72, 0, 72) : System.Drawing.Color.DarkBlue;
			}
			else if (!sdesc.AvailableCharacterData && !sdesc.IsCharSplit)
			{
				return System.Drawing.Color.DarkRed;
			}
			else if (
				System.IO.Path.GetFileNameWithoutExtension(sdesc.CharacterFileName)
				== "objects"
			)
			{
				return System.Drawing.Color.DarkGoldenrod;
			}
			else if (
				sdesc.CharacterDescription.GhostFlag.IsGhost
				&& sdesc.FamilyInstance == 0
			)
			{
				return System.Drawing.Color.Black;
			}

			return System.Drawing.SystemColors.ControlDarkDark;
		}

		internal static void CreateItem(ImagePanel eip, SDesc sdesc)
		{
			eip.ImagePanelColor = System.Drawing.Color.Black;
			eip.Fade = 0.5f;
			eip.FadeColor = System.Drawing.Color.Transparent;

			eip.Tag = sdesc;
			try
			{
				eip.Text = sdesc.SimName + " " + sdesc.SimFamilyName;

				System.Drawing.Image img = sdesc.Image;
				if (img.Width < 8)
				{
					img = null;
				}

				if (img == null)
				{
					img = GetImage.NoOne;
				}
				else if (Helper.WindowsRegistry.Config.GraphQuality)
				{
					img = Ambertation.Drawing.GraphicRoutines.KnockoutImage(
						img,
						new System.Drawing.Point(0, 0),
						System.Drawing.Color.Magenta
					);
				}

				eip.Image = Ambertation.Drawing.GraphicRoutines.ScaleImage(
					img,
					48,
					48,
					Helper.WindowsRegistry.Config.GraphQuality
				);

				eip.ImagePanelColor = GetImagePanelColor(sdesc);
			}
			catch { }
			/*
			if (sdesc.CharacterDescription.Gender==Data.MetaData.Gender.Female)
				eip.PanelColor = System.Drawing.Color.LightPink;
			else
				eip.PanelColor = System.Drawing.Color.PowderBlue;
			*/
		}

		public static ExtendedImagePanel CreateItem(SDesc sdesc)
		{
			ExtendedImagePanel eip = new ExtendedImagePanel();
			eip.SetBounds(0, 0, 216, 80);
			eip.BeginUpdate();
			PrepareItem(eip, sdesc);
			eip.EndUpdate();

			return eip;
		}

		static void PrepareItem(ExtendedImagePanel eip, SDesc sdesc)
		{
			eip.ImagePanelColor = System.Drawing.Color.Black;
			eip.Fade = 0.5f;
			eip.FadeColor = System.Drawing.Color.Transparent;

			eip.Tag = sdesc;
			try
			{
				eip.Properties["GUID"].Value = "0x" + Helper.HexString(sdesc.SimId);
				eip.Properties["Instance"].Value =
					"0x" + Helper.HexString(sdesc.FileDescriptor.Instance);
				eip.Properties["Household"].Value = sdesc.HouseholdName;
				/*eip.Properties["Life Stage"].Value = ((Data.LocalizedLifeSections)sdesc.CharacterDescription.LifeSection).ToString();
				eip.Properties["Career"].Value = ((Data.LocalizedCareers)sdesc.CharacterDescription.Career).ToString();
				eip.Properties["Zodiac Sign"].Value = ((Data.LocalizedZodiacSignes)sdesc.CharacterDescription.ZodiacSign).ToString();*/
			}
			catch (Exception ex)
			{
				eip.Properties["Error"].Value = ex.Message;
			}

			CreateItem(eip, sdesc);
		}

		protected ExtendedImagePanel CreateItem(
			Interfaces.Files.IPackedFileDescriptor pfd,
			int left,
			int top
		)
		{
			ExtendedImagePanel eip = new ExtendedImagePanel();
			eip.BeginUpdate();
			eip.SetBounds(left, top, 216, 80);
			SDesc sdesc = new SDesc();
			try
			{
				sdesc.ProcessData(pfd, pkg);

				PrepareItem(eip, sdesc);
			}
			catch (Exception ex)
			{
				eip.Properties["Error"].Value = ex.Message;
			}
			return eip;
		}

		#region Events
		public delegate void SelectedSimHandler(
			object sender,
			System.Drawing.Image thumb,
			SDesc sdesc
		);
		public event SelectedSimHandler SelectedSimChanged;
		public event SelectedSimHandler ClickOverSim;
		public event SelectedSimHandler DoubleClickSim;
		#endregion

		private void gp_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedSimChanged != null && gp.SelectedItems.Count > 0)
			{
				//SelectedSimChanged(this, gp.LargeImageList.Images[gp.SelectedItems[0].ImageIndex], (Wrapper.SDesc)((SimPe.PackedFiles.Wrapper.ExtSDesc)gp.SelectedItems[0].Tag));
			}
		}

		private void gp_DoubleClick(object sender, EventArgs e)
		{
			if (DoubleClickSim != null && gp.SelectedItems.Count > 0)
			{
				DoubleClickSim(
					this,
					gp.LargeImageList.Images[gp.SelectedItems[0].ImageIndex],

						(ExtSDesc)gp.SelectedItems[0].Tag

				);
			}
		}

		SteepValley.Windows.Forms.XPListViewItem lastsel;

		public bool RightClickSelect
		{
			get; set;
		}

		private void gp_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			SteepValley.Windows.Forms.XPListViewItem item =
				(SteepValley.Windows.Forms.XPListViewItem)gp.GetItemAt(e.X, e.Y);
			if (ClickOverSim != null && item != null)
			{
				ClickOverSim(
					this,
					((ExtSDesc)item.Tag).Image,
					(ExtSDesc)item.Tag
				);
			}

			if (
				SelectedSimChanged != null
				&& item != null
				&& (
					e.Button == System.Windows.Forms.MouseButtons.Left
					|| (
						e.Button == System.Windows.Forms.MouseButtons.Right
						&& RightClickSelect
					)
				)
			)
			{
				gp.SelectedItems.Clear();
				item.Selected = true;
				lastsel = item;
				SelectedSimChanged(
					this,
					((ExtSDesc)item.Tag).Image,
					(ExtSDesc)item.Tag
				);
			}
			//if (lastsel!=null && e.Button!=System.Windows.Forms.MouseButtons.Left) lastsel.Selected = true;
		}

		#region Designer
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(SimPoolControl)
				);
			SteepValley.Windows.Forms.XPListViewGroup xpListViewGroup1 =
				new SteepValley.Windows.Forms.XPListViewGroup("Unrelated", 0);
			SteepValley.Windows.Forms.XPListViewGroup xpListViewGroup2 =
				new SteepValley.Windows.Forms.XPListViewGroup("Related", 1);
			cbhousehold = new System.Windows.Forms.ComboBox();
			gp = new SimListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			chHouse = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			columnHeader3 = new System.Windows.Forms.ColumnHeader();
			columnHeader4 = new System.Windows.Forms.ColumnHeader();
			SuspendLayout();
			//
			// cbhousehold
			//
			resources.ApplyResources(cbhousehold, "cbhousehold");
			cbhousehold.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			cbhousehold.ForeColor = System.Drawing.SystemColors.ControlText;
			cbhousehold.Name = "cbhousehold";
			cbhousehold.SelectedIndexChanged += new EventHandler(
				cbhousehold_SelectedIndexChanged
			);
			//
			// gp
			//
			gp.BackColor = System.Drawing.SystemColors.Info;
			gp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			gp.Columns.AddRange(
				new System.Windows.Forms.ColumnHeader[]
				{
					columnHeader1,
					chHouse,
					columnHeader2,
					columnHeader3,
					columnHeader4,
				}
			);
			resources.ApplyResources(gp, "gp");
			gp.FullRowSelect = true;
			xpListViewGroup1.GroupIndex = 0;
			xpListViewGroup1.GroupText = "Unrelated";
			xpListViewGroup2.GroupIndex = 1;
			xpListViewGroup2.GroupText = "Related";
			gp.Groups.Add(xpListViewGroup1);
			gp.Groups.Add(xpListViewGroup2);
			gp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			gp.HideSelection = false;
			gp.MultiSelect = false;
			gp.Name = "gp";
			gp.TileColumns = new int[] { 1 };
			gp.UseCompatibleStateImageBehavior = false;
			gp.SelectedIndexChanged += new EventHandler(
				gp_SelectedIndexChanged
			);
			gp.DoubleClick += new EventHandler(gp_DoubleClick);
			gp.MouseDown += new System.Windows.Forms.MouseEventHandler(
				gp_MouseDown
			);
			//
			// columnHeader1
			//
			resources.ApplyResources(columnHeader1, "columnHeader1");
			//
			// chHouse
			//
			resources.ApplyResources(chHouse, "chHouse");
			//
			// columnHeader2
			//
			resources.ApplyResources(columnHeader2, "columnHeader2");
			//
			// columnHeader3
			//
			resources.ApplyResources(columnHeader3, "columnHeader3");
			//
			// columnHeader4
			//
			resources.ApplyResources(columnHeader4, "columnHeader4");
			//
			// SimPoolControl
			//
			Controls.Add(gp);
			Controls.Add(cbhousehold);
			resources.ApplyResources(this, "$this");
			Name = "SimPoolControl";
			ResumeLayout(false);
		}
		#endregion

		/// <summary>
		/// Returns the <see cref="ImagePanel"/> that contains the passed Sim
		/// </summary>
		/// <param name="sdsc"></param>
		/// <returns></returns>
		public void FindItem(SDesc sdsc)
		{
			if (sdsc == null)
			{
				gp.SelectedItems.Clear();
				return;
			}

			foreach (SteepValley.Windows.Forms.XPListViewItem gpe in gp.Items)
			{
				if (gpe.Tag is SDesc)
				{
					if (sdsc.Equals((SDesc)gpe.Tag))
					{
						gpe.Selected = true;
						gpe.EnsureVisible();
						SelectedSimChanged(
							this,
							((SDesc)gpe.Tag).Image,
							(SDesc)gpe.Tag
						);
					}
					else
					{
						gpe.Selected = false;
					}
				}
			}
		}

		/// <summary>
		/// Refresh the LIst of displayed Sims
		/// </summary>
		public void UpdateSimList()
		{
			if (cbhousehold.SelectedIndex > 0)
			{
				UpdateSimList(cbhousehold.Text);
			}
			else
			{
				UpdateSimList(null);
			}
		}

		private void cbhousehold_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateSimList();
		}

		public void SelectHousehold(string name)
		{
			int index = 0;
			for (int i = 1; i < cbhousehold.Items.Count; i++)
			{
				if (cbhousehold.Items[i].ToString() == name)
				{
					index = i;
					break;
				}
			}
			cbhousehold.SelectedIndex = index;
		}

		public new void Refresh()
		{
			Refresh(true);
		}

		public void Refresh(bool full)
		{
			if (full)
			{
				UpdateContent();
			}

			base.Refresh();
		}

		internal SteepValley.Windows.Forms.XPListViewItemCollection Items => gp.Items;

		internal System.Windows.Forms.ListView.SelectedIndexCollection SelectedIndices => gp.SelectedIndices;

		internal System.Windows.Forms.ListView.SelectedListViewItemCollection SelectedItems => gp.SelectedItems;

		internal void Sort()
		{
		}

		internal SteepValley.Windows.Forms.XPListViewItem Add(
			ExtSDesc o
		)
		{
			return gp.Add(o);
		}

		public void SetColumnStyle(
			int column,
			System.Drawing.Font font,
			System.Drawing.Color cl
		)
		{
			gp.SetColumnStyle(column, font, cl);
		}

		public int[] TileColumns
		{
			get => gp.TileColumns;
			set => gp.TileColumns = value;
		}

		public void EnsureVisible(int index)
		{
			gp.EnsureVisible(index);
		}
	}
}
