using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Interfaces.Files;

namespace SimPe.Plugin.UI
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public partial class MainForm : System.Windows.Forms.Form
	{
		enum OpenFileType
		{
			Recolor,
			Mesh,
		}

		private Hashtable txtrRef = new Hashtable();
		private Image DefaultPreviewImage = null;
		const int ClipboardKey = 0;
		OpenFileType fileType = OpenFileType.Recolor;

		public MainForm()
		{
			this.Text = String.Format(
				"Colour Binning Tool {0}",
				System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
			);
			InitializeTabControl();
			SetupViewContextMenu();
			ResetSession();
			this.tcMain_Selected(null, null);
		}

		#region Initial Setup

		void InitializeTabControl()
		{
			Array values = Enum.GetValues(typeof(HairColor));
			this.SuspendLayout();
			int i = -1;
			while (++i < values.Length)
			{
				HairColor key = (HairColor)values.GetValue(i);
				System.Windows.Forms.TabPage tp = new System.Windows.Forms.TabPage();
				tp.Text = key.ToString();
				tp.Tag = key;
				tp.ImageIndex = i;
				this.tcMain.TabPages.Add(tp);
				ListView lv = this.CreateListView();
				lv.ContextMenu = this.cmListActions;
				lv.Dock = DockStyle.Fill;
				tp.Controls.Add(lv);
			}
			this.ResumeLayout();
		}

		ListView CreateListView()
		{
			ListView ret = new ListView();
			ret.FullRowSelect = true;
			ret.CheckBoxes = true;
			ret.View = View.Details;
			ret.HideSelection = false;
			ret.LabelEdit = true;
			ret.AfterLabelEdit += new LabelEditEventHandler(
				Handle_ListView_AfterLabelEdit
			);
			ret.ColumnClick += new ColumnClickEventHandler(Handle_ListView_ColumnClick);
			ret.SelectedIndexChanged += new EventHandler(
				Handle_ListView_SelectedIndexChanged
			);
			ret.ItemCheck += new ItemCheckEventHandler(Handle_ListView_ItemCheck);
			ret.ShowItemToolTips = true;
			ret.Columns.Add("Description", 360);
			ret.Columns.Add("Gender", 70);
			ret.Columns.Add("Age", 110);
			ret.Columns.Add("Materials", 76);
			return ret;
		}

		void SetupViewContextMenu()
		{
			Array values = Enum.GetValues(typeof(HairColor));
			int i = -1;
			while (++i < values.Length)
			{
				HairColor key = (HairColor)values.GetValue(i);
				MenuItem item = new MenuItem();
				item.Index = i;
				item.Text = key.ToString();
				item.Click += new EventHandler(MovePackage_Command);
				this.miMoveTo.MenuItems.Add(item);
			}
		}

		public void ResetSession()
		{
			/*
			if (this.box.Settings != null)
				this.SaveOutputPreferences(this.box.Settings);
			*/
			if (!this.box.IsEmpty)
			{
				foreach (System.Windows.Forms.TabPage tp in this.tcMain.TabPages)
				{
					((ListView)tp.Controls[0]).Items.Clear();
					tp.Enabled = true;
				}
			}

			this.lvTxmt.Items.Clear();
			this.lvCresShpe.Items.Clear();
			this.box.Clear();
			this.txtrRef.Clear();
			this.tbFamGuid.Text = "";
			this.tbDescription.Text = "";
			this.pbTexturePreview.Image = DefaultPreviewImage;
			this.numericUpDown1.Value = 0;
			UpdateMainListContextMenu();
			this.tpClothing.Enabled =
				this.llGuid.Enabled =
				this.numericUpDown1.Enabled =
					false;
		}

		void UpdateMainListContextMenu()
		{
			bool hasPackage = this.box.Contains(this.CurrentKey);
			this.miMoveTo.Enabled = hasPackage;
			this.miClear.Enabled = hasPackage;
			this.miOpenPackage.Enabled = !hasPackage;
			this.saveToolStripMenuItem.Enabled = this.saveAsToolStripMenuItem.Enabled =
				!this.box.IsEmpty;
			if (this.CurrentView != null)
			{
				this.miLoadMesh.Enabled = true;
				this.miApplyMesh.Enabled = (CurrentView.SelectedItems.Count > 0);
				UpdateMoveToList();
			}
		}

		void UpdateMoveToList()
		{
			if (this.box.Contains(this.CurrentKey))
			{
				Array values = Enum.GetValues(typeof(HairColor));
				int i = -1;
				while (++i < values.Length)
				{
					MenuItem item = this.miMoveTo.MenuItems[i];
					HairColor key = (HairColor)values.GetValue(i);
					if (key == this.CurrentKey || this.box.Contains(key))
					{
						item.Visible = false;
					}
					else
					{
						item.Visible = true;
					}
				}
			}
		}

		#endregion

		#region Control Calls

		void lvCresShpe_SelectedIndexChanged(object sender, EventArgs e)
		{
			OnSelectMeshItem();
		}

		void miCresAddToMeshList_Click(object sender, EventArgs e)
		{
			if (this.lvCresShpe.SelectedItems.Count > 0)
			{
				foreach (ListViewItem item in this.lvCresShpe.SelectedItems)
				{
					MeshTable.MeshInfo mesh = item.Tag as MeshTable.MeshInfo;
					MenuItem mi = new MenuItem(mesh.Description);
					this.miApplyMesh.MenuItems.Add(mi);
					this.miApplyMesh.Visible = true;
					mi.Click += new EventHandler(Handle_ApplyMeshItem_Click);
				}
			}
		}

		private void miLoadMesh_Click(object sender, System.EventArgs e)
		{
			this.fileType = OpenFileType.Mesh;
			this.dlgOpenPackageFile.ShowDialog();
		}

		private void miMatCopyTxtrRef_Click(object sender, System.EventArgs e)
		{
			if (this.lvTxmt.SelectedItems.Count == 1)
			{
				ListViewItem li = this.lvTxmt.SelectedItems[0];
				MaterialDefinitionRcol rcol = li.Tag as MaterialDefinitionRcol;
				Hashtable txtr = rcol.GetTextureDescriptorNames();
				if (txtr != null)
				{
					txtrRef.Remove(ClipboardKey);
					txtrRef.Add(ClipboardKey, txtr);
					this.miMatUseTxtrRef.Enabled = true;
					this.miMatUseTxtrRef.Text = String.Format(
						"Use {0}",
						txtr[TextureType.Base]
					);
				}
			}
		}

		private void miMatUseTxtrRef_Click(object sender, System.EventArgs e)
		{
			if (this.txtrRef.ContainsKey(ClipboardKey))
			{
				Hashtable txtr = this.txtrRef[ClipboardKey] as Hashtable;
				foreach (ListViewItem li in this.lvTxmt.SelectedItems)
				{
					MaterialDefinitionRcol rcol = li.Tag as MaterialDefinitionRcol;
					rcol.SetTextureDescriptorNames(txtr);
					this.box.ReloadTextureDescriptor(rcol);
					UpdateMaterialItem(li, rcol);
					OnSelectMaterialItem();
				}
			}
		}

		private void miMatUseBaseTxtr_Click(object sender, System.EventArgs e)
		{
			if (this.lvTxmt.SelectedItems.Count > 0)
			{
				RcolTable materials = new RcolTable();
				foreach (ListViewItem item in lvTxmt.SelectedItems)
				{
					materials.Add((Rcol)item.Tag);
				}
				this.box.RevertToBaseTextures(materials);
				UpdateMaterialsList(this.CurrentView);
			}
		}

		private void lvTxmt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.OnSelectMaterialItem();
		}

		void OnSelectMaterialItem()
		{
			if (this.lvTxmt.SelectedItems.Count == 0)
			{
				this.lvTxmt.ContextMenu = null;
			}
			else
			{
				this.lvTxmt.ContextMenu = this.cmTxmtListActions;
				if (this.lvTxmt.SelectedItems.Count == 1)
				{
					this.Cursor = Cursors.WaitCursor;
					ListViewItem item = this.lvTxmt.SelectedItems[0];
					GenericRcol rcolInfo = item.Tag as GenericRcol;
					if (this.cbEnablePreview.Checked)
					{
						Image img = this.box.GetImage(
							rcolInfo,
							this.pbTexturePreview.Size
						);
						if (img != null)
						{
							this.pbTexturePreview.Image = img;
						}
						else
						{
							this.pbTexturePreview.Image = DefaultPreviewImage;
						}
					}
					this.miMatCopyTxtrRef.Enabled = true;
					this.Cursor = Cursors.Default;
				}
				else
				{
					this.pbTexturePreview.Image = DefaultPreviewImage;
					this.miMatCopyTxtrRef.Enabled = false;
				}
			}
		}

		private void Handle_ClearPackage_Command(object sender, System.EventArgs e)
		{
			this.box.Clear(this.CurrentKey);
			CurrentView.Items.Clear();
			UpdateMainListContextMenu();
			UpdateMaterialsList(this.CurrentView);
			UpdateFormTitle();
		}

		private void Handle_ResetSession_Command(object sender, System.EventArgs e)
		{
			ResetSession();
			UpdateFormTitle();
		}

		private void Handle_OpenPackage_Command(object sender, System.EventArgs e)
		{
			this.dlgOpenPackageFile.ShowDialog();
		}

		private void dlgOpenPackageFile_FileOk(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (!e.Cancel)
			{
				switch (this.fileType)
				{
					case OpenFileType.Recolor:
						this.OpenPackageFile(
							dlgOpenPackageFile.FileName,
							this.CurrentKey
						);
						break;
					case OpenFileType.Mesh:
						this.OpenMeshPackage(dlgOpenPackageFile.FileName);
						break;
				}
				this.fileType = OpenFileType.Recolor;
			}
		}

		private void cbEnablePreview_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!this.cbEnablePreview.Checked)
			{
				this.pbTexturePreview.Image = DefaultPreviewImage;
			}

			this.UpdateMaterialsList(this.CurrentView);
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ResetSession();
			UpdateFormTitle();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.dlgOpenPackageFile.ShowDialog();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SavePackageFiles(this.dlgSavePackageFile.FileName, false);
			ResetSession();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dlgSavePackageFile.ShowDialog() == DialogResult.OK)
			{
				SavePackageFiles(this.dlgSavePackageFile.FileName, true);
				ResetSession();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void llGuid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.box.Settings != null)
			{
				this.box.Settings.FamilyGuid = Guid.NewGuid();
				this.tbFamGuid.Text = this.box.Settings.FamilyGuid.ToString();
			}
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (this.box.Settings.PackageType == RecolorType.Skintone)
			{
				((SkintoneSettings)this.box.Settings).GeneticWeight = Convert.ToSingle(
					this.numericUpDown1.Value
				);
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ClbAbout.ShowToolHelp();
		}

		#endregion

		#region Event handler methods

		void MovePackage_Command(object sender, EventArgs e)
		{
			MenuItem item = sender as MenuItem;
			if (item != null)
			{
				HairColor newKey = (HairColor)Enum.Parse(typeof(HairColor), item.Text);
				if (!this.IsTabEnabled(newKey))
				{
					return;
				}

				if (this.box.MovePackage(this.CurrentKey, newKey))
				{
					CurrentView.Items.Clear();
					LoadItems(newKey);
					UpdateMainListContextMenu();
					UpdateMaterialsList(this.CurrentView);
					UpdateMeshList(this.CurrentView);
					UpdateFormTitle();
				}
			}
		}

		void tcMain_Selected(object sender, EventArgs e)
		{
			this.miMatUseTxtrRef.Enabled = this.txtrRef.ContainsKey(ClipboardKey);
			UpdateMaterialsList(CurrentView);
			UpdateMeshList(CurrentView);
			UpdatePropertiesPanel(CurrentView);
			UpdateMainListContextMenu();
			UpdateFormTitle();
		}

		private void Handle_ApplyMeshItem_Click(object sender, EventArgs e)
		{
			MenuItem mi = sender as MenuItem;
			string filePath = mi.Text;
			ApplyMesh(filePath);
		}

		void Handle_PropertiesTab_SettingsChanged(object sender, EventArgs e)
		{
			ListView lv = this.CurrentView;
			if (lv != null)
			{
				if (lv.SelectedItems.Count > 0)
				{
					ListViewItem li = lv.SelectedItems[0];
					RecolorItem item = (RecolorItem)li.Tag;
					ClothingSettings cset = this.tpClothing.Settings;
					li.SubItems[1].Text = cset.Gender.ToString();
					li.SubItems[2].Text = cset.Age.ToString();
					item.Age = cset.Age;
					item.Gender = cset.Gender;
					item.OutfitType = cset.OutfitType;
					item.SetValue("category", Convert.ToUInt32(cset.OutfitCat));
					item.SetValue("shoe", Convert.ToUInt32(cset.ShoeType));
					item.Figure = cset.Figure;
					item.Flaggery = cset.Flaggery;
				}
			}
		}

		void Handle_ListView_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			ListView lv = sender as ListView;
			if (lv != null)
			{
				CheckState state = e.NewValue;
				ListViewItem li = lv.Items[e.Index];
				RecolorItem rcolItem = li.Tag as RecolorItem;
				if (state == CheckState.Unchecked)
				{
					rcolItem.Enabled = false;
				}
				else
				{
					rcolItem.Enabled = true;
				}
			}
		}

		void Handle_ListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListView lv = sender as ListView;
			if (lv != null)
			{
				this.miApplyMesh.Enabled = (lv.SelectedItems.Count > 0);
				this.UpdateMaterialsList(lv);
				this.UpdateMeshList(lv);
				this.UpdatePropertiesPanel(lv);
			}
		}

		private void Handle_ListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			ListView lv = sender as ListView;
			if (lv != null)
			{
				if (lv.ListViewItemSorter == null)
				{
					lv.ListViewItemSorter = new ColumnSorter();
				}

				ColumnSorter cmp = lv.ListViewItemSorter as ColumnSorter;
				if (cmp.CurrentColumn != e.Column)
				{
					cmp.CurrentColumn = e.Column;
					cmp.Sorting = SortOrder.Descending; // reset order on column change
				}

				cmp.Sorting ^= (SortOrder.Ascending | SortOrder.Descending); // toggle me

				lv.Sort();
			}
		}

		private void Handle_ListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			if (e.CancelEdit || Utility.IsNullOrEmpty(e.Label))
			{
				return;
			}

			if (sender is ListView)
			{
				ListViewItem li = ((ListView)sender).Items[e.Item];
				if (li.Tag is RecolorItem)
				{
					((RecolorItem)li.Tag).Name = e.Label;
				}
			}
		}

		#endregion

		#region SubRoutines

		ListView GetView(HairColor key)
		{
			foreach (System.Windows.Forms.TabPage tp in this.tcMain.TabPages)
			{
				if (tp.Tag.Equals(key))
				{
					return tp.Controls[0] as ListView;
				}
			}

			return null;
		}

		ListViewItem CreateListItem(RecolorItem item)
		{
			ListViewItem li = new ListViewItem();
			li.Text = item.Name;
			li.SubItems.Add(item.Gender.ToString());
			li.SubItems.Add(Enum.Format(typeof(Ages), item.Age, "G"));
			li.SubItems.Add(item.Materials.Count.ToString());
			li.Tag = item;
			li.ToolTipText = String.Format("Original hairtone: {0}", item.Hairtone);
			li.Checked = item.Enabled;
			if (item.HasChanges)
			{
				li.Font = new Font(li.Font, FontStyle.Italic);
			}

			return li;
		}

		bool IsTabEnabled(HairColor key)
		{
			foreach (System.Windows.Forms.TabPage tp in this.tcMain.TabPages)
			{
				HairColor color = (HairColor)tp.Tag;
				if (key == color)
				{
					return tp.Enabled;
				}
			}
			return false;
		}

		void LoadItems(HairColor key)
		{
			RecolorItem[] rcolItems = this.box.GetRecolorItems(key);
			if (!Utility.IsNullOrEmpty(rcolItems))
			{
				ListView lv = this.GetView(key);
				foreach (RecolorItem item in rcolItems)
				{
					lv.Items.Add(CreateListItem(item));
				}
			}
		}

		private void UpdateFormTitle()
		{
			System.Text.StringBuilder title = new System.Text.StringBuilder();
			title.AppendFormat(
				"Colour Binning Tool {0}",
				System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
			);
			PackageInfo pnfo = this.box.GetPackageInfo(this.CurrentKey);
			if (pnfo != null)
			{
				title.AppendFormat(
					" - {0}",
					System.IO.Path.GetFileName(pnfo.Package.FileName)
				);
			}

			this.Text = title.ToString();
		}

		public void OpenPackageFile(string fileName, HairColor key)
		{
			ListView lv = this.CurrentView;
			if (lv != null)
			{
				Wait.Start();
				Wait.Message = "Loading...";
				if (this.box.Settings == null)
				{
					this.box.Settings = new PackageSettings();
				}
				if (this.box.AddPackage(key, fileName))
				{
					RecolorItem[] rcolItems = this.box.GetRecolorItems(key);
					foreach (RecolorItem item in rcolItems)
					{
						if (this.box.Settings.FamilyGuid == Guid.Empty)
						{
							this.box.Settings.FamilyGuid = item.Family;
						}

						ListViewItem li = CreateListItem(item);
						lv.Items.Add(li);
						if (!item.Enabled)
						{
							li.ForeColor = Color.Gray;
						}

						switch (this.box.Settings.PackageType)
						{
							case RecolorType.Hairtone:
							case RecolorType.TextureOverlay:
							case RecolorType.MeshOverlay:
								item.Enabled =
									item.Enabled
									&& !(
										(item.Age == Ages.Elder ^ key == HairColor.Grey)
										&& key != HairColor.Unbinned
									);
								break;
						}
						li.Checked = item.Enabled;
					}
				}
				Wait.Stop();
				UpdateMainListContextMenu();
				UpdateFormTitle();
				this.tbFamGuid.Text = this.box.Settings.FamilyGuid.ToString();
				this.tbDescription.Text = this.box.Settings.Description;
				this.tpClothing.Tipe = this.box.Settings.PackageType;
				InitDisableControls();
			}
		}

		public void OpenMeshPackage(string fileName)
		{
			bool newItem = !this.meshTable.IsLoaded(fileName);
			if (this.meshTable.LoadMesh(fileName) != null)
			{
				if (newItem)
				{
					MeshTable.MeshInfo[] meshes = this.meshTable.FindMeshes(fileName);
					foreach (MeshTable.MeshInfo mesh in meshes)
					{
						MenuItem mi = new MenuItem(mesh.Description);
						this.miApplyMesh.MenuItems.Add(mi);
						this.miApplyMesh.Visible = true;
						mi.Click += new EventHandler(Handle_ApplyMeshItem_Click);
					}
				}
			}
		}

		bool ApplyMesh(string fileName)
		{
			ListView view = this.CurrentView;
			if (view != null && view.SelectedItems.Count > 0)
			{
				MeshTable.MeshInfo mesh = this.meshTable.FindMeshByName(fileName);
				if (mesh != null)
				{
					foreach (ListViewItem li in view.SelectedItems)
					{
						RecolorItem item = li.Tag as RecolorItem;
						this.meshTable.ApplyMesh(item, mesh);
						item.HasChanges = true;
						li.Font = new Font(li.Font, FontStyle.Italic);
					}
					UpdateMeshList(CurrentView);
					return true;
				}
			}
			return false;
		}

		public void SavePackageFiles(string fileName, bool namechange)
		{
			if (!this.box.IsEmpty)
			{
				if (this.box.Settings != null)
				{
					this.box.Settings.CompressTextures = this.cbCompress.Checked;
					this.box.Settings.KeepDisabledItems = !this.cbDeleter.Checked;
				}
				this.Cursor = Cursors.WaitCursor;
				this.box.ProcessPackages(fileName, namechange);
				this.Cursor = Cursors.Default;
			}
		}

		HairColor CurrentKey
		{
			get
			{
				System.Windows.Forms.TabPage tp = this.tcMain.SelectedTab;
				if (tp != null)
				{
					return (HairColor)tp.Tag;
				}

				return HairColor.Unbinned;
			}
		}

		ListView CurrentView
		{
			get
			{
				System.Windows.Forms.TabPage tp = this.tcMain.SelectedTab;
				return tp.Controls[0] as ListView;
			}
		}

		void UpdateMeshList(ListView owner)
		{
			if (owner != null)
			{
				this.lvCresShpe.SuspendLayout();
				this.lvCresShpe.Items.Clear();
				ArrayList items = new ArrayList();
				foreach (ListViewItem item in owner.SelectedItems)
				{
					items.Add(item.Tag);
				}

				MeshTable.MeshInfo[] meshes = this.meshTable.GetMeshReferences(
					(RecolorItem[])items.ToArray(typeof(RecolorItem))
				);
				foreach (MeshTable.MeshInfo mesh in meshes)
				{
					ListViewItem li = new ListViewItem();
					UpdateMeshItem(li, mesh);
					this.lvCresShpe.Items.Add(li);
				}
				this.lvCresShpe.ResumeLayout();
			}
		}

		void UpdateMeshItem(ListViewItem li, MeshTable.MeshInfo mesh)
		{
			li.SubItems.Clear();
			li.Text = mesh.Description;
			li.Tag = mesh;
			li.ImageIndex = 0;
			li.SubItems.Add(String.Format("{0:X8}", mesh.ResourceNode.Group));
			li.SubItems.Add(String.Format("{0:X16}", mesh.ResourceNode.LongInstance));
			li.SubItems.Add(mesh.FileName);
		}

		void UpdateMaterialsList(ListView owner)
		{
			if (owner != null)
			{
				ArrayList selectedIndices = new ArrayList(this.lvTxmt.SelectedIndices);
				int count = this.lvTxmt.Items.Count;
				this.lvTxmt.SuspendLayout();
				this.lvTxmt.Items.Clear();
				foreach (ListViewItem item in owner.SelectedItems)
				{
					RecolorItem rcolInfo = item.Tag as RecolorItem;
					foreach (Rcol rcol in rcolInfo.Materials)
					{
						ListViewItem li = new ListViewItem();
						this.UpdateMaterialItem(li, rcol);
						this.lvTxmt.Items.Add(li);
					}
				}
				if (count == this.lvTxmt.Items.Count)
				{
					foreach (int index in selectedIndices)
					{
						this.lvTxmt.Items[index].Selected = true;
					}
				}

				if (this.lvTxmt.Items.Count == 0)
				{
					this.pbTexturePreview.Image = DefaultPreviewImage;
				}
				else if (this.lvTxmt.SelectedIndices.Count == 0)
				{
					this.lvTxmt.Items[0].Selected = true;
				}

				this.lvTxmt.ResumeLayout();
			}
		}

		void UpdateMaterialItem(ListViewItem li, Rcol rcol)
		{
			li.SubItems.Clear();
			li.Text = rcol.ResourceName;
			li.ImageIndex = 0;
			li.Tag = rcol;
			string txtrID = "<not found in FileTable>";
			IPackedFileDescriptor[] pfd = this.box.GetTextureDescriptor(rcol);
			if (!Utility.IsNullOrEmpty(pfd))
			{
				txtrID = String.Format(
					"Group={0:X8} Instance={1:X16}",
					pfd[0].Group,
					pfd[0].LongInstance
				);
				if (pfd.Length > 1)
				{
					txtrID += String.Format(
						"; BumpMap: Group={0:X8} Instance={1:X16}",
						pfd[1].Group,
						pfd[1].LongInstance
					);
				}
			}
			li.SubItems.Add(txtrID);
		}

		private void UpdatePropertiesPanel(ListView lv)
		{
			if (lv.SelectedItems.Count == 1)
			{
				RecolorItem item = (RecolorItem)lv.SelectedItems[0].Tag;
				ClothingSettings cset = new ClothingSettings();
				cset.Age = item.Age;
				cset.Gender = item.Gender;
				cset.OutfitCat = (OutfitCats)item.GetProperty("category").UIntegerValue;
				cset.OutfitType = item.OutfitType;
				cset.ShoeType = (ShoeType)item.GetProperty("shoe").UIntegerValue;
				cset.Species = (SpeciesType)item.GetProperty("species").UIntegerValue;
				cset.OverlayType = item.TextureOverlayType;
				cset.Figure = item.Figure;
				cset.Flaggery = item.Flaggery;
				this.tpClothing.Enabled = true;
				this.tpClothing.Settings = cset;
			}
			else
			{
				this.tpClothing.Enabled = false;
			}
		}

		void OnSelectMeshItem()
		{
			if (this.lvCresShpe.SelectedItems.Count == 0)
			{
				this.lvCresShpe.ContextMenu = null;
			}
			else
			{
				this.lvCresShpe.ContextMenu = this.cmMeshListActions;
			}
		}

		void InitDisableControls()
		{
			this.llGuid.Enabled = (this.box.Settings.PackageType != RecolorType.Skin);
			if (this.box.Settings.PackageType == RecolorType.Skintone)
			{
				this.numericUpDown1.Value = Convert.ToDecimal(
					((SkintoneSettings)this.box.Settings).GeneticWeight
				);
				this.numericUpDown1.Enabled = true;
			}
			else
			{
				this.numericUpDown1.Enabled = false;
			}
		}

		#endregion
	}
}
