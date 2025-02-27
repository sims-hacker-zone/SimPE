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
	public partial class MainForm : Form
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
			Text = String.Format(
				"Colour Binning Tool {0}",
				System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
			);
			InitializeTabControl();
			SetupViewContextMenu();
			ResetSession();
			tcMain_Selected(null, null);
		}

		#region Initial Setup

		void InitializeTabControl()
		{
			Array values = Enum.GetValues(typeof(HairColor));
			SuspendLayout();
			int i = -1;
			while (++i < values.Length)
			{
				HairColor key = (HairColor)values.GetValue(i);
				System.Windows.Forms.TabPage tp = new System.Windows.Forms.TabPage
				{
					Text = key.ToString(),
					Tag = key,
					ImageIndex = i
				};
				tcMain.TabPages.Add(tp);
				ListView lv = CreateListView();
				lv.ContextMenu = cmListActions;
				lv.Dock = DockStyle.Fill;
				tp.Controls.Add(lv);
			}
			ResumeLayout();
		}

		ListView CreateListView()
		{
			ListView ret = new ListView
			{
				FullRowSelect = true,
				CheckBoxes = true,
				View = View.Details,
				HideSelection = false,
				LabelEdit = true
			};
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
				MenuItem item = new MenuItem
				{
					Index = i,
					Text = key.ToString()
				};
				item.Click += new EventHandler(MovePackage_Command);
				miMoveTo.MenuItems.Add(item);
			}
		}

		public void ResetSession()
		{
			/*
			if (this.box.Settings != null)
				this.SaveOutputPreferences(this.box.Settings);
			*/
			if (!box.IsEmpty)
			{
				foreach (System.Windows.Forms.TabPage tp in tcMain.TabPages)
				{
					((ListView)tp.Controls[0]).Items.Clear();
					tp.Enabled = true;
				}
			}

			lvTxmt.Items.Clear();
			lvCresShpe.Items.Clear();
			box.Clear();
			txtrRef.Clear();
			tbFamGuid.Text = "";
			tbDescription.Text = "";
			pbTexturePreview.Image = DefaultPreviewImage;
			numericUpDown1.Value = 0;
			UpdateMainListContextMenu();
			tpClothing.Enabled =
				llGuid.Enabled =
				numericUpDown1.Enabled =
					false;
		}

		void UpdateMainListContextMenu()
		{
			bool hasPackage = box.Contains(CurrentKey);
			miMoveTo.Enabled = hasPackage;
			miClear.Enabled = hasPackage;
			miOpenPackage.Enabled = !hasPackage;
			saveToolStripMenuItem.Enabled = saveAsToolStripMenuItem.Enabled =
				!box.IsEmpty;
			if (CurrentView != null)
			{
				miLoadMesh.Enabled = true;
				miApplyMesh.Enabled = (CurrentView.SelectedItems.Count > 0);
				UpdateMoveToList();
			}
		}

		void UpdateMoveToList()
		{
			if (box.Contains(CurrentKey))
			{
				Array values = Enum.GetValues(typeof(HairColor));
				int i = -1;
				while (++i < values.Length)
				{
					MenuItem item = miMoveTo.MenuItems[i];
					HairColor key = (HairColor)values.GetValue(i);
					item.Visible = key != CurrentKey && !box.Contains(key);
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
			if (lvCresShpe.SelectedItems.Count > 0)
			{
				foreach (ListViewItem item in lvCresShpe.SelectedItems)
				{
					MeshTable.MeshInfo mesh = item.Tag as MeshTable.MeshInfo;
					MenuItem mi = new MenuItem(mesh.Description);
					miApplyMesh.MenuItems.Add(mi);
					miApplyMesh.Visible = true;
					mi.Click += new EventHandler(Handle_ApplyMeshItem_Click);
				}
			}
		}

		private void miLoadMesh_Click(object sender, EventArgs e)
		{
			fileType = OpenFileType.Mesh;
			dlgOpenPackageFile.ShowDialog();
		}

		private void miMatCopyTxtrRef_Click(object sender, EventArgs e)
		{
			if (lvTxmt.SelectedItems.Count == 1)
			{
				ListViewItem li = lvTxmt.SelectedItems[0];
				MaterialDefinitionRcol rcol = li.Tag as MaterialDefinitionRcol;
				Hashtable txtr = rcol.GetTextureDescriptorNames();
				if (txtr != null)
				{
					txtrRef.Remove(ClipboardKey);
					txtrRef.Add(ClipboardKey, txtr);
					miMatUseTxtrRef.Enabled = true;
					miMatUseTxtrRef.Text = String.Format(
						"Use {0}",
						txtr[TextureType.Base]
					);
				}
			}
		}

		private void miMatUseTxtrRef_Click(object sender, EventArgs e)
		{
			if (txtrRef.ContainsKey(ClipboardKey))
			{
				Hashtable txtr = txtrRef[ClipboardKey] as Hashtable;
				foreach (ListViewItem li in lvTxmt.SelectedItems)
				{
					MaterialDefinitionRcol rcol = li.Tag as MaterialDefinitionRcol;
					rcol.SetTextureDescriptorNames(txtr);
					box.ReloadTextureDescriptor(rcol);
					UpdateMaterialItem(li, rcol);
					OnSelectMaterialItem();
				}
			}
		}

		private void miMatUseBaseTxtr_Click(object sender, EventArgs e)
		{
			if (lvTxmt.SelectedItems.Count > 0)
			{
				RcolTable materials = new RcolTable();
				foreach (ListViewItem item in lvTxmt.SelectedItems)
				{
					materials.Add((Rcol)item.Tag);
				}
				box.RevertToBaseTextures(materials);
				UpdateMaterialsList(CurrentView);
			}
		}

		private void lvTxmt_SelectedIndexChanged(object sender, EventArgs e)
		{
			OnSelectMaterialItem();
		}

		void OnSelectMaterialItem()
		{
			if (lvTxmt.SelectedItems.Count == 0)
			{
				lvTxmt.ContextMenu = null;
			}
			else
			{
				lvTxmt.ContextMenu = cmTxmtListActions;
				if (lvTxmt.SelectedItems.Count == 1)
				{
					Cursor = Cursors.WaitCursor;
					ListViewItem item = lvTxmt.SelectedItems[0];
					GenericRcol rcolInfo = item.Tag as GenericRcol;
					if (cbEnablePreview.Checked)
					{
						Image img = box.GetImage(
							rcolInfo,
							pbTexturePreview.Size
						);
						pbTexturePreview.Image = img != null ? img : DefaultPreviewImage;
					}
					miMatCopyTxtrRef.Enabled = true;
					Cursor = Cursors.Default;
				}
				else
				{
					pbTexturePreview.Image = DefaultPreviewImage;
					miMatCopyTxtrRef.Enabled = false;
				}
			}
		}

		private void Handle_ClearPackage_Command(object sender, EventArgs e)
		{
			box.Clear(CurrentKey);
			CurrentView.Items.Clear();
			UpdateMainListContextMenu();
			UpdateMaterialsList(CurrentView);
			UpdateFormTitle();
		}

		private void Handle_ResetSession_Command(object sender, EventArgs e)
		{
			ResetSession();
			UpdateFormTitle();
		}

		private void Handle_OpenPackage_Command(object sender, EventArgs e)
		{
			dlgOpenPackageFile.ShowDialog();
		}

		private void dlgOpenPackageFile_FileOk(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (!e.Cancel)
			{
				switch (fileType)
				{
					case OpenFileType.Recolor:
						OpenPackageFile(
							dlgOpenPackageFile.FileName,
							CurrentKey
						);
						break;
					case OpenFileType.Mesh:
						OpenMeshPackage(dlgOpenPackageFile.FileName);
						break;
				}
				fileType = OpenFileType.Recolor;
			}
		}

		private void cbEnablePreview_CheckedChanged(object sender, EventArgs e)
		{
			if (!cbEnablePreview.Checked)
			{
				pbTexturePreview.Image = DefaultPreviewImage;
			}

			UpdateMaterialsList(CurrentView);
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ResetSession();
			UpdateFormTitle();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dlgOpenPackageFile.ShowDialog();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SavePackageFiles(dlgSavePackageFile.FileName, false);
			ResetSession();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dlgSavePackageFile.ShowDialog() == DialogResult.OK)
			{
				SavePackageFiles(dlgSavePackageFile.FileName, true);
				ResetSession();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void llGuid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (box.Settings != null)
			{
				box.Settings.FamilyGuid = Guid.NewGuid();
				tbFamGuid.Text = box.Settings.FamilyGuid.ToString();
			}
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (box.Settings.PackageType == RecolorType.Skintone)
			{
				((SkintoneSettings)box.Settings).GeneticWeight = Convert.ToSingle(
					numericUpDown1.Value
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
			if (sender is MenuItem item)
			{
				HairColor newKey = (HairColor)Enum.Parse(typeof(HairColor), item.Text);
				if (!IsTabEnabled(newKey))
				{
					return;
				}

				if (box.MovePackage(CurrentKey, newKey))
				{
					CurrentView.Items.Clear();
					LoadItems(newKey);
					UpdateMainListContextMenu();
					UpdateMaterialsList(CurrentView);
					UpdateMeshList(CurrentView);
					UpdateFormTitle();
				}
			}
		}

		void tcMain_Selected(object sender, EventArgs e)
		{
			miMatUseTxtrRef.Enabled = txtrRef.ContainsKey(ClipboardKey);
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
			ListView lv = CurrentView;
			if (lv != null)
			{
				if (lv.SelectedItems.Count > 0)
				{
					ListViewItem li = lv.SelectedItems[0];
					RecolorItem item = (RecolorItem)li.Tag;
					ClothingSettings cset = tpClothing.Settings;
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
			if (sender is ListView lv)
			{
				CheckState state = e.NewValue;
				ListViewItem li = lv.Items[e.Index];
				RecolorItem rcolItem = li.Tag as RecolorItem;
				rcolItem.Enabled = state != CheckState.Unchecked;
			}
		}

		void Handle_ListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (sender is ListView lv)
			{
				miApplyMesh.Enabled = (lv.SelectedItems.Count > 0);
				UpdateMaterialsList(lv);
				UpdateMeshList(lv);
				UpdatePropertiesPanel(lv);
			}
		}

		private void Handle_ListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (sender is ListView lv)
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
			foreach (System.Windows.Forms.TabPage tp in tcMain.TabPages)
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
			ListViewItem li = new ListViewItem
			{
				Text = item.Name
			};
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
			foreach (System.Windows.Forms.TabPage tp in tcMain.TabPages)
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
			RecolorItem[] rcolItems = box.GetRecolorItems(key);
			if (!Utility.IsNullOrEmpty(rcolItems))
			{
				ListView lv = GetView(key);
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
			PackageInfo pnfo = box.GetPackageInfo(CurrentKey);
			if (pnfo != null)
			{
				title.AppendFormat(
					" - {0}",
					System.IO.Path.GetFileName(pnfo.Package.FileName)
				);
			}

			Text = title.ToString();
		}

		public void OpenPackageFile(string fileName, HairColor key)
		{
			ListView lv = CurrentView;
			if (lv != null)
			{
				Wait.Start();
				Wait.Message = "Loading...";
				if (box.Settings == null)
				{
					box.Settings = new PackageSettings();
				}
				if (box.AddPackage(key, fileName))
				{
					RecolorItem[] rcolItems = box.GetRecolorItems(key);
					foreach (RecolorItem item in rcolItems)
					{
						if (box.Settings.FamilyGuid == Guid.Empty)
						{
							box.Settings.FamilyGuid = item.Family;
						}

						ListViewItem li = CreateListItem(item);
						lv.Items.Add(li);
						if (!item.Enabled)
						{
							li.ForeColor = Color.Gray;
						}

						switch (box.Settings.PackageType)
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
				tbFamGuid.Text = box.Settings.FamilyGuid.ToString();
				tbDescription.Text = box.Settings.Description;
				tpClothing.Tipe = box.Settings.PackageType;
				InitDisableControls();
			}
		}

		public void OpenMeshPackage(string fileName)
		{
			bool newItem = !meshTable.IsLoaded(fileName);
			if (meshTable.LoadMesh(fileName) != null)
			{
				if (newItem)
				{
					MeshTable.MeshInfo[] meshes = meshTable.FindMeshes(fileName);
					foreach (MeshTable.MeshInfo mesh in meshes)
					{
						MenuItem mi = new MenuItem(mesh.Description);
						miApplyMesh.MenuItems.Add(mi);
						miApplyMesh.Visible = true;
						mi.Click += new EventHandler(Handle_ApplyMeshItem_Click);
					}
				}
			}
		}

		bool ApplyMesh(string fileName)
		{
			ListView view = CurrentView;
			if (view != null && view.SelectedItems.Count > 0)
			{
				MeshTable.MeshInfo mesh = meshTable.FindMeshByName(fileName);
				if (mesh != null)
				{
					foreach (ListViewItem li in view.SelectedItems)
					{
						RecolorItem item = li.Tag as RecolorItem;
						meshTable.ApplyMesh(item, mesh);
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
			if (!box.IsEmpty)
			{
				if (box.Settings != null)
				{
					box.Settings.CompressTextures = cbCompress.Checked;
					box.Settings.KeepDisabledItems = !cbDeleter.Checked;
				}
				Cursor = Cursors.WaitCursor;
				box.ProcessPackages(fileName, namechange);
				Cursor = Cursors.Default;
			}
		}

		HairColor CurrentKey
		{
			get
			{
				System.Windows.Forms.TabPage tp = tcMain.SelectedTab;
				return tp != null ? (HairColor)tp.Tag : HairColor.Unbinned;
			}
		}

		ListView CurrentView
		{
			get
			{
				System.Windows.Forms.TabPage tp = tcMain.SelectedTab;
				return tp.Controls[0] as ListView;
			}
		}

		void UpdateMeshList(ListView owner)
		{
			if (owner != null)
			{
				lvCresShpe.SuspendLayout();
				lvCresShpe.Items.Clear();
				ArrayList items = new ArrayList();
				foreach (ListViewItem item in owner.SelectedItems)
				{
					items.Add(item.Tag);
				}

				MeshTable.MeshInfo[] meshes = meshTable.GetMeshReferences(
					(RecolorItem[])items.ToArray(typeof(RecolorItem))
				);
				foreach (MeshTable.MeshInfo mesh in meshes)
				{
					ListViewItem li = new ListViewItem();
					UpdateMeshItem(li, mesh);
					lvCresShpe.Items.Add(li);
				}
				lvCresShpe.ResumeLayout();
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
				ArrayList selectedIndices = new ArrayList(lvTxmt.SelectedIndices);
				int count = lvTxmt.Items.Count;
				lvTxmt.SuspendLayout();
				lvTxmt.Items.Clear();
				foreach (ListViewItem item in owner.SelectedItems)
				{
					RecolorItem rcolInfo = item.Tag as RecolorItem;
					foreach (Rcol rcol in rcolInfo.Materials)
					{
						ListViewItem li = new ListViewItem();
						UpdateMaterialItem(li, rcol);
						lvTxmt.Items.Add(li);
					}
				}
				if (count == lvTxmt.Items.Count)
				{
					foreach (int index in selectedIndices)
					{
						lvTxmt.Items[index].Selected = true;
					}
				}

				if (lvTxmt.Items.Count == 0)
				{
					pbTexturePreview.Image = DefaultPreviewImage;
				}
				else if (lvTxmt.SelectedIndices.Count == 0)
				{
					lvTxmt.Items[0].Selected = true;
				}

				lvTxmt.ResumeLayout();
			}
		}

		void UpdateMaterialItem(ListViewItem li, Rcol rcol)
		{
			li.SubItems.Clear();
			li.Text = rcol.ResourceName;
			li.ImageIndex = 0;
			li.Tag = rcol;
			string txtrID = "<not found in FileTable>";
			IPackedFileDescriptor[] pfd = box.GetTextureDescriptor(rcol);
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
				ClothingSettings cset = new ClothingSettings
				{
					Age = item.Age,
					Gender = item.Gender,
					OutfitCat = (OutfitCats)item.GetProperty("category").UIntegerValue,
					OutfitType = item.OutfitType,
					ShoeType = (ShoeType)item.GetProperty("shoe").UIntegerValue,
					Species = (SpeciesType)item.GetProperty("species").UIntegerValue,
					OverlayType = item.TextureOverlayType,
					Figure = item.Figure,
					Flaggery = item.Flaggery
				};
				tpClothing.Enabled = true;
				tpClothing.Settings = cset;
			}
			else
			{
				tpClothing.Enabled = false;
			}
		}

		void OnSelectMeshItem()
		{
			lvCresShpe.ContextMenu = lvCresShpe.SelectedItems.Count == 0 ? null : cmMeshListActions;
		}

		void InitDisableControls()
		{
			llGuid.Enabled = (box.Settings.PackageType != RecolorType.Skin);
			if (box.Settings.PackageType == RecolorType.Skintone)
			{
				numericUpDown1.Value = Convert.ToDecimal(
					((SkintoneSettings)box.Settings).GeneticWeight
				);
				numericUpDown1.Enabled = true;
			}
			else
			{
				numericUpDown1.Enabled = false;
			}
		}

		#endregion
	}
}
