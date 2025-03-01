// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SimPe.Forms.MainUI;
using SimPe.Forms.MainUI.CustomControls;

namespace SimPe
{
	/// <summary>
	/// Summary description for OptionForm.
	/// </summary>
	public partial class OptionForm : Form
	{
		public OptionForm()
		{
			Application.UseWaitCursor = true;
			try
			{
				Application.DoEvents();
				InitializeComponent();

				tbFolders.Tag = hcFolders;
				tbFileTable.Tag = hcFileTable;
				tbCheck.Tag = hcCheck;
				tbSettings.Tag = hcSettings;
				tbCustom.Tag = hcCustom;
				tbSceneGraph.Tag = hcSceneGraph;
				tbPlugins.Tag = hcPlugins;
				tbTools.Tag = hcTools;
				tbIdent.Tag = hcIdent;

				Registry.ResourceListExtensionFormats[] rls =
					(Registry.ResourceListExtensionFormats[])
						Enum.GetValues(
							typeof(Registry.ResourceListExtensionFormats)
						);
				foreach (Registry.ResourceListExtensionFormats rl in rls)
				{
					cbRLExt.Items.Add(rl);
				}

				cbRLExt.SelectedIndex = 0;

				Registry.ResourceListFormats[] rlf =
					(Registry.ResourceListFormats[])
						Enum.GetValues(
							typeof(Registry.ResourceListFormats)
						);
				foreach (Registry.ResourceListFormats ri in rlf)
				{
					cbRLNames.Items.Add(ri);
				}

				cbRLNames.SelectedIndex = 0;

				Registry.ResourceListUnnamedFormats[] rlu =
					(Registry.ResourceListUnnamedFormats[])
						Enum.GetValues(
							typeof(Registry.ResourceListUnnamedFormats)
						);
				foreach (Registry.ResourceListUnnamedFormats ru in rlu)
				{
					cbRLTGI.Items.Add(ru);
				}

				cbRLTGI.SelectedIndex = 0;

				pgPaths.SelectedObject = PathSettings.Global;

				for (byte i = 1; i < 0x2d; i++)
				{
					cblang.Items.Add(new PackedFiles.Wrapper.StrLanguage(i)); // CJH
				}

				Registry.ReportFormats[] rfs = (Registry.ReportFormats[])
					Enum.GetValues(typeof(Registry.ReportFormats));
				foreach (Registry.ReportFormats rf in rfs)
				{
					cbReport.Items.Add(rf);
				}

				cbReport.SelectedIndex = 0;

				foreach (
					Interfaces.ISettings settings in FileTable
						.SettingsRegistry
						.Settings
				)
				{
					cbCustom.Items.Add(settings);
				}

				if (cbCustom.Items.Count > 0)
				{
					cbCustom.SelectedIndex = 0;
				}

				//if (Helper.WindowsRegistry.UseExpansions2) this.hdFileTable.HeaderText = "File Table (High Level Expansions)";

				toolTip1.SetToolTip(
					cblang,
					"Game Language is " + PathProvider.Global.InGameLang
				);

				CreateFileTableCheckboxes();
			}
			finally
			{
				Application.UseWaitCursor = false;
			}
		}

		void Execute()
		{
			Tag = true;
			tbdds.Text = PathProvider.Global.NvidiaDDSPath;
			cbdebug.Checked = Helper.WindowsRegistry.GameDebug;
			cbautobak.Checked = Helper.WindowsRegistry.AutoBackup;
			cbblur.Checked = Helper.WindowsRegistry.BlurNudity;
			cbsound.Checked = Helper.WindowsRegistry.EnableSound;
			cbwait.Checked = Helper.WindowsRegistry.WaitingScreen;
			cbow.Checked = Helper.WindowsRegistry.LoadOWFast;
			//cbsilent.Checked = Helper.WindowsRegistry.Silent;
			cbcache.Checked = Helper.WindowsRegistry.UseCache;
			cbshowobjd.Checked = Helper.WindowsRegistry.ShowObjdNames;
			cbhidden.Checked = Helper.WindowsRegistry.HiddenMode;
			cbjointname.Checked = Helper.WindowsRegistry.ShowJointNames;
			tbthumb.Text = Helper.WindowsRegistry.OWThumbSize.ToString();
			cbshowalls.Checked = Helper.WindowsRegistry.OWincludewalls;
			cbtrimname.Checked = Helper.WindowsRegistry.OWtrimnames;
			tbscale.Text = Helper.WindowsRegistry.ImportExportScaleFactor.ToString();
			cbpkgmaint.Checked = Helper.WindowsRegistry.UsePackageMaintainer;
			cbmulti.Checked = Helper.WindowsRegistry.MultipleFiles;
			cbSimple.Checked = Helper.WindowsRegistry.SimpleResourceSelect;
			cbFirefox.Checked = Helper.WindowsRegistry.FirefoxTabbing;
			cbDeep.Checked = Helper.WindowsRegistry.DeepSimScan;
			cbSimTemp.Checked = Helper.WindowsRegistry.DeepSimTemplateScan;
			cbAsync.Checked = Helper.WindowsRegistry.AsynchronLoad;
			cbLock.Checked = Helper.WindowsRegistry.LockDocks;
			cbsplash.Checked = Helper.WindowsRegistry.ShowStartupSplash;
			cbAsyncSort.Checked = Helper.WindowsRegistry.AsynchronSort;
			//cbexthemes.Checked = Helper.WindowsRegistry.ThemedForms;
			cbBigIcons.Checked = Helper.WindowsRegistry.UseBigIcons;
			cbautostore.Checked = Helper.WindowsRegistry.Layout.AutoStoreLayout;
			cbmoreskills.Checked = Helper.WindowsRegistry.ShowMoreSkills;
			cbpetability.Checked = Helper.WindowsRegistry.ShowPetAbilities;

			cbLock_CheckedChanged(cbLock, null);

			tbUsername.Text = Helper.WindowsRegistry.Username;
			tbPassword.Text = Helper.WindowsRegistry.Password;
			tbUserid.Text =
				"0x" + Helper.HexString(Helper.WindowsRegistry.CachedUserId);
			if (!UserVerification.HaveValidUserId)
			{
				btcreateid.Visible = true;
			}

			cbblur.Visible = PathProvider.Global.EPInstalled < 18;
			cbIncCep.Enabled = PathProvider.Global.GameVersion < 18;
			cbIncCep.Visible = PathProvider.Global.GameVersion < 18;

			toolTip1.SetToolTip(panel1, "");

			groupBox5.Visible = !Helper.WindowsRegistry.Layout.IsClassicPreset;
			cbBigIcons.Visible = !Helper.WindowsRegistry.Layout.IsClassicPreset;

			if (
				((byte)Helper.WindowsRegistry.LanguageCode <= cblang.Items.Count)
				&& ((byte)Helper.WindowsRegistry.LanguageCode > 0)
			)
			{
				cblang.SelectedIndex = (byte)Helper.WindowsRegistry.LanguageCode - 1;
			}

			lbext.Items.Clear();
			foreach (ToolLoaderItemExt tli in ToolLoaderExt.Items)
			{
				lbext.Items.Add(tli);
			}

			//FileTable
			ArrayList folders = FileTableBase.DefaultFolders;
			lbfolder.Items.Clear();
			foreach (FileTableItem fti in folders)
			{
				lbfolder.Items.Add(fti, !fti.Ignore);
			}
			lbfolder.SelectedIndex = lbfolder.Items.Count > 0 ? 0 : -1;

			//Report Format
			Registry.ReportFormats rf =
				Helper.WindowsRegistry.ReportFormat;
			for (int i = 0; i < cbReport.Items.Count; i++)
			{
				if ((Registry.ReportFormats)cbReport.Items[i] == rf)
				{
					cbReport.SelectedIndex = i;
				}
			}

			Registry.ResourceListExtensionFormats rlf =

					Helper.WindowsRegistry.ResourceListExtensionFormat;
			for (int i = 0; i < cbRLExt.Items.Count; i++)
			{
				if (
					(Registry.ResourceListExtensionFormats)cbRLExt.Items[i] == rlf
				)
				{
					cbRLExt.SelectedIndex = i;
				}
			}

			Registry.ResourceListFormats rif =

					Helper.WindowsRegistry.ResourceListFormat;
			for (int i = 0; i < cbRLNames.Items.Count; i++)
			{
				if ((Registry.ResourceListFormats)cbRLNames.Items[i] == rif)
				{
					cbRLNames.SelectedIndex = i;
				}
			}

			Registry.ResourceListUnnamedFormats ruf =

					Helper.WindowsRegistry.ResourceListUnknownDescriptionFormat;
			for (int i = 0; i < cbRLTGI.Items.Count; i++)
			{
				if ((Registry.ResourceListUnnamedFormats)cbRLTGI.Items[i] == ruf)
				{
					cbRLTGI.SelectedIndex = i;
				}
			}
			// ****************************

			//state
			cbSimTemp.Enabled = cbDeep.Checked;

			if (!Helper.WindowsRegistry.FileTableSimpleSelectUseGroups)
			{
				groupBox8.Visible = false;
				groupBox9.Location = groupBox8.Location;
				groupBox9.Height += groupBox8.Height;
			}

			Tag = null;
			btReload.Enabled = Helper.LocalMode; // When in LocalMode, default the Reload button to enabled.
			SetupFileTableCheckboxes();

			ShowDialog();
		}

		private void SaveOptionsClick(object sender, EventArgs e)
		{
			PathProvider.Global.NvidiaDDSPath = tbdds.Text;
			Helper.WindowsRegistry.LanguageCode =
				(Data.MetaData.Languages)cblang.SelectedIndex + 1;
			Helper.WindowsRegistry.GameDebug = cbdebug.Checked;
			Helper.WindowsRegistry.AutoBackup = cbautobak.Checked;
			Helper.WindowsRegistry.BlurNudity = PathProvider.Global.EPInstalled >= 18 || cbblur.Checked;

			Helper.WindowsRegistry.EnableSound = cbsound.Checked;
			Helper.WindowsRegistry.WaitingScreen = cbwait.Checked;
			Helper.WindowsRegistry.LoadOWFast = cbow.Checked;
			//Helper.WindowsRegistry.Silent = cbsilent.Checked;
			Helper.WindowsRegistry.UseCache = cbcache.Checked;
			Helper.WindowsRegistry.ShowObjdNames = cbshowobjd.Checked;
			Helper.WindowsRegistry.HiddenMode = cbhidden.Checked;
			Helper.WindowsRegistry.ShowJointNames = cbjointname.Checked;
			Helper.WindowsRegistry.UsePackageMaintainer = cbpkgmaint.Checked;
			Helper.WindowsRegistry.MultipleFiles = cbmulti.Checked;
			// Helper.WindowsRegistry.Layout.SelectedTheme = (byte)
			// 	cbThemes.Items[cbThemes.SelectedIndex];
			Helper.WindowsRegistry.SimpleResourceSelect = cbSimple.Checked;
			Helper.WindowsRegistry.FirefoxTabbing = cbFirefox.Checked;
			Helper.WindowsRegistry.DeepSimScan = cbDeep.Checked;
			Helper.WindowsRegistry.DeepSimTemplateScan = cbSimTemp.Checked;
			Helper.WindowsRegistry.AsynchronLoad = cbAsync.Checked;
			Helper.WindowsRegistry.ReportFormat = (Registry.ReportFormats)
				cbReport.SelectedItem;
			Helper.WindowsRegistry.LockDocks = cbLock.Checked;
			Helper.WindowsRegistry.ShowStartupSplash = cbsplash.Checked;
			Helper.WindowsRegistry.AsynchronSort = cbAsyncSort.Checked;
			Helper.WindowsRegistry.ResourceListExtensionFormat =
				(Registry.ResourceListExtensionFormats)cbRLExt.SelectedIndex;
			Helper.WindowsRegistry.ResourceListFormat = (Registry.ResourceListFormats)
				cbRLNames.SelectedIndex;
			Helper.WindowsRegistry.ResourceListUnknownDescriptionFormat =
				(Registry.ResourceListUnnamedFormats)cbRLTGI.SelectedIndex;
			Helper.WindowsRegistry.Username = tbUsername.Text;
			Helper.WindowsRegistry.Password = tbPassword.Text;
			Helper.WindowsRegistry.FileTableSimpleSelectUseGroups = !cbhidden.Checked;

			List<FileTableItem> lfti =
				new List<FileTableItem>();
			foreach (FileTableItem fti in lbfolder.Items)
			{
				lfti.Add(fti);
			}

			FileTableBase.StoreFoldersXml(lfti);
			try
			{
				Helper.WindowsRegistry.OWThumbSize = Convert.ToInt32(tbthumb.Text);
				Helper.WindowsRegistry.ImportExportScaleFactor = Convert.ToSingle(
					tbscale.Text
				);
			}
			catch { }

			ToolLoaderExt.Items = new ToolLoaderItemExt[0];
			foreach (ToolLoaderItemExt tli in lbext.Items)
			{
				ToolLoaderExt.Add(tli);
			};
			ToolLoaderExt.StoreTools();

			Helper.WindowsRegistry.Flush();

			FileTableBase.FileIndex.BaseFolders.Clear();
			FileTableBase.FileIndex.BaseFolders = FileTableBase.DefaultFolders;
			Close();
		}

		private void DeleteExt(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lbext.SelectedIndex < 0)
			{
				return;
			}

			lbext.Items.Remove(lbext.Items[lbext.SelectedIndex]);
		}

		private void AddExt(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			AddExtTool aet = new AddExtTool();
			ToolLoaderItemExt tli = aet.Execute();

			if (tli != null)
			{
				lbext.Items.Add(tli);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (System.IO.Directory.Exists(tbdds.Text))
			{
				ofd.InitialDirectory = tbdds.Text;
			}

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbdds.Text = System.IO.Path.GetDirectoryName(ofd.FileName);
			}
		}

		private void ClearCaches(object sender, EventArgs e)
		{
			CheckControl.ClearCache();
		}

		private void DDSChanged(object sender, EventArgs e)
		{
			string name = System.IO.Path.Combine(tbdds.Text, "nvdxt.exe");
			lldds.Visible = !System.IO.File.Exists(name);
			lldds2.Visible = lldds.Visible;
		}

		private void LoadDDS(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			Help.ShowHelp(
				this,
				"https://developer.nvidia.com/legacy-texture-tools"
			);
		}

		private void ChangedThemeHandler(object sender, EventArgs e)
		{
		}

		private void cbexthemes_CheckedChanged(object sender, EventArgs e)
		{
			//Helper.WindowsRegistry.ThemedForms = this.cbexthemes.Checked;
			if (Tag == null)
			{
				lbBigIconNote.Visible = true;
			}
		}

		private void ResetLayoutClick(object sender, EventArgs e)
		{
			if (ResetLayout != null)
			{
				ResetLayout(this, e);
			}
		}

		private void LockDocksClick(object sender, EventArgs e)
		{
			if (LockDocks != null)
			{
				LockDocks(this, e);
			}
		}

		private void UnlockDocksClick(object sender, EventArgs e)
		{
			if (UnlockDocks != null)
			{
				UnlockDocks(this, e);
			}
		}

		#region Events
		public event EventHandler ResetLayout;
		public event EventHandler LockDocks;
		public event EventHandler UnlockDocks;
		#endregion

		#region Plugins
		public Image GetImage(Interfaces.IWrapper wrapper)
		{
			return uids.Contains(wrapper.WrapperDescription.UID)
				? Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.error.png")
				)
				: wrapper.Priority >= 0
				? Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.enabled.png")
				)
				: Image.FromStream(
				GetType()
					.Assembly.GetManifestResourceStream("SimPe.img.disabled.png")
			);
		}

		public void SetPanel(
			Interfaces.IWrapper wrapper,
			TD.Eyefinder.HeaderControl pn
		)
		{
			if (wrapper.Priority < 0)
			{
				pn.Text = "(" + wrapper.WrapperDescription.Name + ")";
				pn.ForeColor = SystemColors.ControlDarkDark;
			}
			else
			{
				pn.Text = wrapper.WrapperDescription.Name;
				pn.ForeColor = SystemColors.ControlText;
			}
			pn.Text = "     " + pn.Text;
		}

		public Image GetShrinkImage(TD.Eyefinder.HeaderControl pn)
		{
			return pn.Height == pn.DisplayRectangle.Top + 1
				? Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.expand.png")
				)
				: Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.shrink.png")
				);
		}

		public bool ThumbnailCallback()
		{
			return false;
		}

		ArrayList uids;
		ArrayList wrappers;

		int height = 116;

		public Control BuildPanel(Interfaces.IWrapper wrapper, int index)
		{
			if (Helper.WindowsRegistry.HiddenMode)
			{
				height = 148;
			}

			if (uids == null)
			{
				uids = new ArrayList();
			}

			if (wrappers == null)
			{
				wrappers = new ArrayList();
			}

			wrapper.Priority = wrapper.Priority >= 0 ? index + 1 : -1 * (index + 1);

			const int imgwidth = 22;
			int top = 4 + (index * (height + 4));
			TD.Eyefinder.HeaderControl pn = new TD.Eyefinder.HeaderControl
			{
				Parent = cnt,
				Top = top,
				Left = 4
			};
			pn.Width =
				cnt.Width
				- SystemInformation.VerticalScrollBarWidth
				- 2
				- (2 * pn.Left);
			pn.Height = height;
			pn.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
			pn.HeaderStyle = TD.Eyefinder.HeaderStyle.SubHeading;
			pn.Click += new EventHandler(pn_Click);
			pn.LostFocus += new EventHandler(pn_LostFocus);
			pn.GotFocus += new EventHandler(pn_Focused);
			pn.Enter += new EventHandler(pn_Focused);
			pn.Leave += new EventHandler(pn_LostFocus);
			pn_LostFocus(pn, null);
			SetPanel(wrapper, pn);
			pn.Tag = wrapper;
			pn.Dock = DockStyle.Top;

			wrappers.Add(pn);

			#region Author
			Label lbauthor = new Label
			{
				Parent = pn,
				Top = pn.DisplayRectangle.Top + 8,
				Left = 8,
				Text = "Author:",
				Width = 85,
				Font = new Font(
				cnt.Font.Name,
				cnt.Font.Size,
				FontStyle.Bold,
				cnt.Font.Unit
			)
			};
			lbauthor.Height = (int)lbauthor.Font.SizeInPoints * 2;
			lbauthor.ForeColor = SystemColors.ControlDarkDark;
			lbauthor.TextAlign = ContentAlignment.TopRight;
			lbauthor.Click += new EventHandler(pn_Click);

			Label lb = new Label
			{
				Parent = pn,
				Top = lbauthor.Top,
				Left = lbauthor.Right + 4,
				AutoSize = true,
				Text = wrapper.WrapperDescription.Author,
				Font = new Font(
				cnt.Font.Name,
				cnt.Font.Size,
				FontStyle.Regular,
				cnt.Font.Unit
			),
				Height = lbauthor.Height,
				ForeColor = lbauthor.ForeColor
			};
			lb.Click += new EventHandler(pn_Click);
			#endregion

			#region Version
			Label lbversion = new Label
			{
				Parent = pn,
				Top = lbauthor.Top,
				Left = lb.Right + 16,
				Width = lbauthor.Width,
				Height = lbauthor.Height,
				Text = "Version:",
				Font = lbauthor.Font,
				ForeColor = lbauthor.ForeColor,
				TextAlign = lbauthor.TextAlign
			};
			lbversion.Click += new EventHandler(pn_Click);

			lb = new Label
			{
				Parent = pn,
				Top = lbversion.Top,
				Left = lbversion.Right + 4,
				AutoSize = true,
				Text = wrapper.WrapperDescription.Version.ToString(),
				Font = new Font(
				cnt.Font.Name,
				cnt.Font.Size,
				FontStyle.Regular,
				cnt.Font.Unit
			),
				Height = lbauthor.Height,
				ForeColor = lbauthor.ForeColor
			};
			lb.Click += new EventHandler(pn_Click);
			#endregion

			#region FileName
			Label lbfile = new Label
			{
				Parent = pn,
				Top = lbversion.Bottom,
				Left = lbauthor.Left,
				Width = lbauthor.Width,
				Height = lbauthor.Height,
				Text = "Filename:",
				Font = lbauthor.Font,
				ForeColor = lbauthor.ForeColor,
				TextAlign = lbauthor.TextAlign
			};
			lbfile.Click += new EventHandler(pn_Click);

			lb = new Label
			{
				Parent = pn,
				Top = lbfile.Top,
				Left = lbfile.Right + 4,
				AutoSize = true,
				Text = wrapper.WrapperFileName,
				Font = new Font(
				cnt.Font.Name,
				cnt.Font.Size,
				FontStyle.Regular,
				cnt.Font.Unit
			),
				Height = lbauthor.Height,
				ForeColor = lbauthor.ForeColor
			};
			lb.Click += new EventHandler(pn_Click);
			#endregion

			#region UID
			Label lbui = new Label
			{
				Parent = pn,
				Top = lbfile.Bottom,
				Left = lbauthor.Left,
				Width = lbauthor.Width,
				Height = lbauthor.Height,
				Text = "UID:",
				Font = lbauthor.Font,
				ForeColor = lbauthor.ForeColor,
				TextAlign = lbauthor.TextAlign
			};
			lbui.Click += new EventHandler(pn_Click);

			lb = new Label
			{
				Parent = pn,
				Top = lbui.Top,
				Left = lbui.Right + 4,
				AutoSize = true,
				Text = "0x" + Helper.HexString(wrapper.WrapperDescription.UID),
				Font = new Font(
				cnt.Font.Name,
				cnt.Font.Size,
				FontStyle.Regular,
				cnt.Font.Unit
			),
				Height = lbauthor.Height,
				ForeColor = lbauthor.ForeColor
			};
			lb.Click += new EventHandler(pn_Click);
			#endregion

			#region Description
			Label lbdesc = new Label
			{
				Parent = pn,
				Top = lbui.Bottom,
				Left = lbauthor.Left,
				Width = lbauthor.Width,
				Height = lbauthor.Height,
				Text = "Description:",
				Font = lbauthor.Font,
				ForeColor = lbauthor.ForeColor,
				TextAlign = lbauthor.TextAlign
			};
			lbdesc.Click += new EventHandler(pn_Click);

			TextBox tb = new TextBox
			{
				Parent = pn,
				Top = lbdesc.Top,
				Left = lbdesc.Right + 4,
				Width = pn.Width - lb.Left - imgwidth - 12,
				Anchor =
				AnchorStyles.Top
				| AnchorStyles.Left
				| AnchorStyles.Bottom
				| AnchorStyles.Right,
				Text = wrapper.WrapperDescription.Description
			};
			if (Helper.WindowsRegistry.HiddenMode)
			{
				tb.Text +=
					Helper.lbr
					+ wrapper.GetType().FullName
					+ " "
					+ wrapper.GetType().Assembly.FullName;
			}

			tb.Multiline = true;
			tb.WordWrap = true;
			tb.ScrollBars = ScrollBars.Vertical;
			tb.BorderStyle = BorderStyle.None;
			tb.BackColor = pn.BackColor;

			tb.Font = new Font(
				cnt.Font.Name,
				cnt.Font.Size,
				FontStyle.Regular,
				cnt.Font.Unit
			);
			tb.Height = pn.Height - tb.Top - 8;
			tb.ForeColor = lbauthor.ForeColor;
			tb.GotFocus += new EventHandler(tb_GotFocus);
			tb.Enter += new EventHandler(tb_GotFocus);
			tb.ReadOnly = true;
			#endregion

			PictureBox pb = null;

			if (wrapper.AllowMultipleInstances)
			{
				pb = new PictureBox
				{
					Parent = pn,
					Width = imgwidth,
					Height = imgwidth
				};
				pb.Left = pn.Width - (2 * pb.Width) - 16;
				pb.Top = pn.DisplayRectangle.Top + 4; //pn.DisplayRectangle.Top + 4 + pb.Height + 4; //pn.Height - 2*pb.Height -16;
				pb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
				pb.Image = Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream(
							"SimPe.img.multienabled.png"
						)
				);
				pb.Click += new EventHandler(pn_Click);
				toolTip1.SetToolTip(pb, "Allows Multiple instance");

				pb = new PictureBox
				{
					Parent = pn,
					Width = pn.DisplayRectangle.Top + 1,
					Height = pn.DisplayRectangle.Top,
					SizeMode = PictureBoxSizeMode.CenterImage
				};
				pb.Top = (pn.DisplayRectangle.Top + 1 - pb.Height) / 2;
				pb.Left = pn.Width - (3 * pb.Width) - pb.Top;
				pb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
				pb.Image = Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream(
							"SimPe.img.smallmultienabled.png"
						)
				);
				pb.BackColor = Color.Transparent;

				toolTip1.SetToolTip(pb, "Allows Multiple instance.");
			}

			if (wrapper is PackedFiles.Wrapper.ErrorWrapper)
			{
				pb = new PictureBox
				{
					Parent = pn,
					Width = pn.DisplayRectangle.Top + 1,
					Height = pn.DisplayRectangle.Top,
					SizeMode = PictureBoxSizeMode.CenterImage
				};
				pb.Top = (pn.DisplayRectangle.Top + 1 - pb.Height) / 2;
				pb.Left = wrapper.AllowMultipleInstances ? pn.Width - (4 * pb.Width) - pb.Top : pn.Width - (3 * pb.Width) - pb.Top;

				pb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
				pb.Image = Image.FromStream(
						GetType()
							.Assembly.GetManifestResourceStream("SimPe.img.error.png")
					)
					.GetThumbnailImage(
						16,
						16,
						new Image.GetThumbnailImageAbort(ThumbnailCallback),
						IntPtr.Zero
					);
				;
				pb.BackColor = Color.Transparent;
				toolTip1.SetToolTip(
					pb,
					"This wrapper caused an Error while loading."
				);
			}

			PictureBox ipb = new PictureBox
			{
				Parent = pn,
				Left = 2,
				Top = 1,
				BackColor = Color.Transparent,
				SizeMode = PictureBoxSizeMode.StretchImage
			};
			if (wrapper.WrapperDescription.Icon != null)
			{
				ipb.Height = Math.Min(
					wrapper.WrapperDescription.Icon.Height,
					pn.DisplayRectangle.Top - 2
				);
				ipb.Width = Math.Min(
					wrapper.WrapperDescription.Icon.Width,
					pn.DisplayRectangle.Top - 2
				);
				ipb.Image = wrapper.WrapperDescription.Icon;
			}
			else
			{
				ipb.Height = 16;
				ipb.Width = 16;
				//				ipb.Image = FileTable.WrapperRegistry.WrapperImageList.Images[1];
			}

			PictureBox pbe = new PictureBox
			{
				Parent = pn,
				Width = pn.DisplayRectangle.Top + 1,
				Height = pn.DisplayRectangle.Top,
				SizeMode = PictureBoxSizeMode.CenterImage
			};
			pbe.Top = (pn.DisplayRectangle.Top + 1 - pbe.Height) / 2;
			pbe.Left = pn.Width - pbe.Width - pbe.Top;
			pbe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			pbe.Image = GetShrinkImage(pn);
			pbe.Tag = pn;
			pbe.BackColor = Color.Transparent;
			pbe.Click += new EventHandler(pb_ExpandClick);
			toolTip1.SetToolTip(pbe, "Collapse/Expand");

			pb = new PictureBox
			{
				Parent = pn,
				Width = imgwidth,
				Height = imgwidth
			};
			pb.Left = pn.Width - pb.Width - 8;
			pb.Top = pn.DisplayRectangle.Top + 4; //pn.Height - pb.Height -8;
			pb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			pb.Image = GetImage(wrapper);
			pb.Tag = pn;
			pb.BackColor = Color.Transparent;
			pb.Click += new EventHandler(pb_Click);
			toolTip1.SetToolTip(pb, "Enable/Disable");

			pb = new PictureBox
			{
				Parent = pn,
				Width = pn.DisplayRectangle.Top + 1,
				Height = pn.DisplayRectangle.Top,
				SizeMode = PictureBoxSizeMode.CenterImage
			};
			pb.Top = (pn.DisplayRectangle.Top + 1 - pb.Height) / 2;
			pb.Left = pn.Width - (2 * pb.Width) - pb.Top;
			pb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			pb.Image = GetImage(wrapper)
				.GetThumbnailImage(
					16,
					16,
					new Image.GetThumbnailImageAbort(ThumbnailCallback),
					IntPtr.Zero
				);
			pb.BackColor = Color.Transparent;
			pb.Tag = pn;
			pb.Click += new EventHandler(pb_Click);
			toolTip1.SetToolTip(pb, "Enable/Disable");

			Panel pan = new Panel
			{
				BackColor = cnt.BackColor,
				Parent = pn,
				Height = 4,
				Dock = DockStyle.Bottom
			};

			uids.Add(wrapper.WrapperDescription.UID);
			pb_ExpandClick(pbe, null);
			return pn;
		}

		public void Execute(Icon icon)
		{
			if (icon != null)
			{
				Icon = icon;
			}

			IEnumerable<Interfaces.IWrapper> wrappers = FileTableBase
				.WrapperRegistry
				.AllWrappers;

			cnt.Controls.AddRange(wrappers.Select((wrapper, ct) => BuildPanel(wrapper, ct)).ToArray());

			uids.Clear();
			if (cnt.Controls.Count > 0)
			{
				cnt.Controls[0].Focus();
			}

			Execute();

			foreach (Interfaces.IWrapper wrapper in wrappers)
			{
				if (!(wrapper is PackedFiles.Wrapper.ErrorWrapper))
				{
					Helper.WindowsRegistry.SetWrapperPriority(
						wrapper.WrapperDescription.UID,
						wrapper.Priority
					);
				}
			}
		}

		private void pn_Click(object sender, EventArgs e)
		{
			if (sender is TD.Eyefinder.HeaderControl)
			{
				TD.Eyefinder.HeaderControl pn = (TD.Eyefinder.HeaderControl)sender;
				pn.Focus();
			}
			else if (sender is Control)
			{
				TD.Eyefinder.HeaderControl pn = (TD.Eyefinder.HeaderControl)
					((Control)sender).Parent;
				pn.Focus();
			}
		}

		TD.Eyefinder.HeaderControl lastpn;

		private void pn_Focused(object sender, EventArgs e)
		{
			TD.Eyefinder.HeaderControl pn = (TD.Eyefinder.HeaderControl)sender;
			pn.BackColor = SystemColors.Window;
			pn.Font = new Font(
				pn.Font.Name,
				pn.Font.Size,
				FontStyle.Bold,
				pn.Font.Unit
			);

			btpup.Enabled = wrappers[0] != pn;
			btpdown.Enabled = wrappers[wrappers.Count - 1] != pn;

			lastpn = pn;
			if (pn.Controls.Count > 9)
			{
				pn.Controls[9].BackColor = pn.BackColor;
			}
		}

		private void pn_LostFocus(object sender, EventArgs e)
		{
			TD.Eyefinder.HeaderControl pn = (TD.Eyefinder.HeaderControl)sender;
			pn.BackColor = SystemColors.ControlLight;
			pn.Font = new Font(
				pn.Font.Name,
				pn.Font.Size,
				FontStyle.Regular,
				pn.Font.Unit
			);
			if (pn.Controls.Count > 9)
			{
				pn.Controls[9].BackColor = pn.BackColor;
			}
		}

		private void pb_Click(object sender, EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			TD.Eyefinder.HeaderControl pn = (TD.Eyefinder.HeaderControl)pb.Tag;
			Interfaces.IWrapper wrapper = (Interfaces.IWrapper)pn.Tag;

			wrapper.Priority *= -1;
			SetPanel(wrapper, pn);

			Image i = GetImage(wrapper);

			SetBackgroundColor(pn.Controls[pn.Controls.Count - 2], i, true);
			SetBackgroundColor(pn.Controls[pn.Controls.Count - 3], i, false);
		}

		int FindPanelIndex(TD.Eyefinder.HeaderControl pn)
		{
			for (int i = 0; i < wrappers.Count; i++)
			{
				if (wrappers[i] == pn)
				{
					return i;
				}
			}

			return -1;
		}

		void Exchange(int index, int o)
		{
			TD.Eyefinder.HeaderControl pn1 = (TD.Eyefinder.HeaderControl)
				wrappers[index];
			TD.Eyefinder.HeaderControl pn2 = (TD.Eyefinder.HeaderControl)
				wrappers[index + o];

			(pn2.Top, pn1.Top) = (pn1.Top, pn2.Top);
			Interfaces.IWrapper w1 = (Interfaces.IWrapper)pn1.Tag;
			Interfaces.IWrapper w2 = (Interfaces.IWrapper)pn2.Tag;

			int p1 = w1.Priority;
			int p2 = w2.Priority;

			w1.Priority = p1 >= 0 ? Math.Abs(p2) : -1 * Math.Abs(p2);

			w2.Priority = p2 >= 0 ? Math.Abs(p1) : -1 * Math.Abs(p1);

			wrappers[index] = pn2;
			wrappers[index + o] = pn1;

			cnt.Controls.SetChildIndex(pn1, index + o);
		}

		private void btpup_Click(object sender, EventArgs e)
		{
			if (lastpn == null)
			{
				return;
			}

			int index = FindPanelIndex(lastpn);
			if (index < 1)
			{
				return;
			}

			Exchange(index, -1);

			lastpn.Focus();
		}

		private void btpdown_Click(object sender, EventArgs e)
		{
			if (lastpn == null)
			{
				return;
			}

			int index = FindPanelIndex(lastpn);
			if (index < 0)
			{
				return;
			}

			if (index >= wrappers.Count - 1)
			{
				return;
			}

			Exchange(index, 1);

			lastpn.Focus();
		}

		void SetBackgroundColor(object sender, Image i, bool small)
		{
			PictureBox pb = (PictureBox)sender;
			pb.Image = small
				? i.GetThumbnailImage(
					16,
					16,
					new Image.GetThumbnailImageAbort(ThumbnailCallback),
					IntPtr.Zero
				)
				: i;
		}

		private void pb_ExpandClick(object sender, EventArgs e)
		{
			PictureBox pb = (PictureBox)sender;
			TD.Eyefinder.HeaderControl pn = (TD.Eyefinder.HeaderControl)pb.Tag;

			if (pn.Height == pn.DisplayRectangle.Top + 1)
			{
				pn.Controls[pn.Controls.Count - 1].Visible = true;
				pn.Height = height;
			}
			else
			{
				pn.Controls[pn.Controls.Count - 1].Visible = false;
				pn.Height = pn.DisplayRectangle.Top + 1;
			}

			pb.Image = GetShrinkImage(pn);
			Interfaces.IWrapper wrapper = (Interfaces.IWrapper)pn.Tag;
			//SetBackgroundColor(pb, wrapper);
		}

		private void tb_GotFocus(object sender, EventArgs e)
		{
			if (lastpn != null)
			{
				pn_Focused(lastpn, null);
			}
		}

		#endregion

		private void cbmulti_CheckedChanged(object sender, EventArgs e)
		{
			cbFirefox.Enabled = cbmulti.Checked;
			cbFirefox.Refresh();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			Helper.WindowsRegistry.ClearRecentFileList();
		}

		private void tbPassword_Leave(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			if (
				tbUserid.Text
				!= "0x"
					+ Helper.HexString(
						UserVerification.GenerateUserId(
							0,
							tbUsername.Text,
							tbPassword.Text
						)
					)
			)
			{
				if (tbUserid.Text != "0x00000000")
				{
					btcreateid.Text = "Update Id";
				}

				btcreateid.Visible = true;
			}
		}

		private void btcreateid_Click(object sender, EventArgs e)
		{
			Helper.WindowsRegistry.CachedUserId = UserVerification.GenerateUserId(
				0,
				tbUsername.Text,
				tbPassword.Text
			);
			tbUserid.Text =
				"0x" + Helper.HexString(Helper.WindowsRegistry.CachedUserId);
			btcreateid.Visible = false;
		}

		private void cbblur_CheckedChanged(object sender, EventArgs e)
		{
			Helper.WindowsRegistry.BlurNudity = cbblur.Checked;
			cbblur.Checked = Helper.WindowsRegistry.BlurNudity;
		}

		private void cbDeep_CheckedChanged(object sender, EventArgs e)
		{
			cbSimTemp.Enabled = cbDeep.Checked;
		}

		#region Simpe FileTable Settings
		private Dictionary<string, CheckBox> lcb = null;

		private CheckBox CreateFileTableCheckbox(
			ref int left,
			ref int top,
			string key,
			string text
		)
		{
			if (left + cbIncCep.Width > cbIncCep.Parent.Width - cbIncCep.Left)
			{
				left = cbIncCep.Left;
				top += cbIncCep.Height - 2;
			}

			CheckBox cb = new CheckBox();

			cb.SetBounds(left, top, cbIncCep.Width, cbIncCep.Height);
			left += cb.Width + 4;

			lcb.Add(key, cb);
			cb.Text = text;
			cb.CheckedChanged += new EventHandler(
				cbIncNightlife_CheckedChanged
			);

			cb.Visible = true;
			cb.Parent = cbIncCep.Parent;
			cb.Font = cbIncCep.Font;

			return cb;
		}

		private void CreateFileTableCheckboxes()
		{
			Enabled = false;
			try
			{
				lcb = new Dictionary<string, CheckBox>();

				int cwd = cbIncCep.Parent.Width - (2 * cbIncCep.Left) + 4;
				cbIncCep.Width = (cwd / 4) - 4;
				int left = cbIncCep.Right + 4;
				if (PathProvider.Global.GameVersion >= 18)
				{
					left = cbIncCep.Left;
				}

				int top = cbIncCep.Top;

				CreateFileTableCheckbox(
					ref left,
					ref top,
					"cbIncGraphics",
					Localization.GetString("FileTableIncludeGraphics")
				);
				/* if (!ei.Exists && ei.InstallFolder == "")
				 * ei.Exists only checks if SimPe found the Window registary entries
				 * ei.InstallFolder has a value if the user had to manually set the path
				 * This handles the UC better*/
				foreach (ExpansionItem ei in PathProvider.Global.Expansions)
				{
					CheckBox cb = CreateFileTableCheckbox(
						ref left,
						ref top,
						ei.NameShort,

							Localization.GetString("FileTableSectionInclude")
							.Replace("{what}", ei.NameShort)
					);
					cb.Tag = ei;

					if (!ei.Exists && ei.InstallFolder == "")
					{
						cb.CheckState = CheckState.Unchecked;
						cb.Enabled = false;
					}
				}
				top += cbIncCep.Height + 2;
				groupBox8.Height = top;
				groupBox9.Top = groupBox8.Bottom + 8;
				groupBox9.Height = hcFileTable.Height - groupBox9.Top - 8;
			}
			finally
			{
				Application.DoEvents();
				Enabled = true;
			}
		}

		private void btReload_Click(object sender, EventArgs e)
		{
			Enabled = false;
			try
			{
				Helper.LocalMode = btReload.Enabled = false; // We're no longer in LocalMode after a filetable reload
				List<FileTableItem> lfti =
					new List<FileTableItem>();
				foreach (FileTableItem fti in lbfolder.Items)
				{
					lfti.Add(fti);
				}

				FileTableBase.StoreFoldersXml(lfti);
				FileTable.Reload();
			}
			finally
			{
				Application.DoEvents();
				Enabled = true;
			}
		}

		private void linkLabel6_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			Enabled = false;
			try
			{
				FileTableBase.BuildFolderXml();
				FileTableBase.FileIndex.BaseFolders.Clear();
				FileTableBase.FileIndex.BaseFolders = FileTableBase.DefaultFolders;

				RebuildFileTableList();

				btReload.Enabled = true;
				SetupFileTableCheckboxes();
			}
			finally
			{
				Application.DoEvents();
				Enabled = true;
			}
		}

		void RebuildFileTableList()
		{
			lbfolder.Items.Clear();
			foreach (FileTableItem fti in FileTableBase.FileIndex.BaseFolders)
			{
				lbfolder.Items.Add(fti, !fti.Ignore);
			}
		}

		// may be faulty - remove the if / else

		private static bool isCEP(FileTableItem fti)
		{
			if (fti.IsFile)
			{
				if (
					Helper.CompareableFileName(fti.Name)
						== Helper.CompareableFileName(Data.MetaData.GMND_PACKAGE)
					|| Helper.CompareableFileName(fti.Name)
						== Helper.CompareableFileName(Data.MetaData.MMAT_PACKAGE)
				)
				{
					return true;
				}
			}
			else
			{
				if (fti.Type.AsExpansions == Expansions.Custom)
				{
					if (
						Helper.CompareableFileName(fti.Name)
						== Helper.CompareableFileName(Data.MetaData.ZCEP_FOLDER)
					)
					{
						return true;
					}
				}
				else
				{
					if (
						Helper.CompareableFileName(fti.Name)
						== Helper.CompareableFileName(Data.MetaData.CTLG_FOLDER)
					)
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool IsFtiGraphic(FileTableItem fti)
		{
			ExpansionItem ei = PathProvider.Global[fti.Type.AsExpansions];
			if (ei == null || PathProvider.Nil.Equals(ei))
			{
				return false;
			}

			CheckBox cb = lcb[ei.NameShort];
			if (cb == null)
			{
				return false;
			}

			if (
				(PathProvider.Global.GameVersion < 21 && ei.Flag.SimStory)
				|| (!ei.Exists && ei.InstallFolder == "")
				|| neveruse(ei)
			)
			{
				return false;
			}

			string cfn = Helper.CompareableFileName(fti.Name);
			return (ei.Version == PathProvider.Global.GameVersion
				&& (cfn.EndsWith("\\objects") || cfn.EndsWith("\\overrides")))
|| cfn.EndsWith("\\3d")
				|| cfn.EndsWith("\\sims3d")
				|| cfn.EndsWith("\\stuffpack\\objects")
				|| cfn.EndsWith("\\materials");
		}

		private bool IsEP(FileTableItem fti, FileTableItemType epver)
		{
			// string cfn = Helper.CompareableFileName(fti.Name);
			// bool isFtiGraphic = cfn.EndsWith("\\3d") || cfn.EndsWith("\\sims3d") || cfn.EndsWith("\\stuffpack\\objects") || cfn.EndsWith("\\materials");
			bool state = fti.Type == epver;
			/* // All thise nonsense was causing the include graphics setting to overide our choice of using a whole EP or not
			if (isFtiGraphic)
			{
				ExpansionItem ei = PathProvider.Global[fti.Type.AsExpansions];
				if (ei == null || PathProvider.Nil.Equals(ei)) return state;
				CheckBox cb = lcb["cbIncGraphics"];
				if (cb == null) return state;
				if (cb.CheckState == CheckState.Unchecked) return false;
			}
			 */
			return state;
		}

		private bool IsMatch(CheckBox cb, FileTableItem fti, FileTableItemType epver)
		{
			return isCEP(fti) ? cb == cbIncCep : cb == lcb["cbIncGraphics"] ? IsFtiGraphic(fti) : IsEP(fti, epver);
		}

		private bool neveruse(ExpansionItem ti)
		{
			return (PathProvider.Global.GameVersion == 19
				&& (ti.Version == 18 || ti.Version == 17))
|| PathProvider.Global.GameVersion == 18 && ti.Version == 17;
		}

		private void SetupFileTableCheckboxes(CheckBox cb, FileTableItemType epver)
		{
			if (cbIncCep.Tag != null)
			{
				return;
			}

			int found = 0;
			int ignored = 0;

			foreach (FileTableItem fti in lbfolder.Items)
			{
				if (IsMatch(cb, fti, epver))
				{
					found++;
					if (fti.Ignore)
					{
						ignored++;
					}
				}
			}

			cbIncCep.Tag = true;
			cb.CheckState =
				ignored == 0 ? CheckState.Checked
				: ignored == found ? CheckState.Unchecked
				: CheckState.Indeterminate;
			cbIncCep.Tag = null;
		}

		private void SetupFileTableCheckboxes()
		{
			SetupFileTableCheckboxes(cbIncCep, null);
			foreach (CheckBox cb in lcb.Values)
			{
				if (cb.Tag is ExpansionItem ei)
				{
					SetupFileTableCheckboxes(cb, ei.Expansion);
				}
			}
			SetupFileTableCheckboxes(lcb["cbIncGraphics"], null); // Must be last as refs back to expansion CBs
		}

		private void lbfolder_ItemCheck(
			object sender,
			ItemCheckEventArgs e
		)
		{
			if (Tag != null)
			{
				return;
			}

			if (lbfolder.SelectedItem == null)
			{
				return;
			}

			Enabled = false;
			try
			{
				((FileTableItem)lbfolder.SelectedItem).Ignore =
					e.NewValue != CheckState.Checked;
				btReload.Enabled = true;
				SetupFileTableCheckboxes();
			}
			finally
			{
				Application.DoEvents();
				Enabled = true;
			}
		}

		private void lbfolder_SelectedIndexChanged(
			object sender,
			EventArgs e
		)
		{
		}

		void ChangeFileTable(CheckBox cb, FileTableItemType epver)
		{
			bool firstobjpkg = true;
			cbIncCep.Tag = true;
			for (int i = 0; i < lbfolder.Items.Count; i++)
			{
				FileTableItem fti = (FileTableItem)lbfolder.Items[i];

				if (IsMatch(cb, fti, epver))
				{
					lbfolder.SetItemChecked(i, cb.CheckState != CheckState.Unchecked);
				}

				fti.Ignore = !lbfolder.GetItemChecked(i);

				#region I have no idea what this section of code does
				ExpansionItem ei = null;
				bool fullobj = true;
				int thisepver = FileTableItem.GetEPVersion(fti.Type);
				if (thisepver > 0)
				{
					ei = PathProvider.Global.GetExpansion(thisepver);
					fullobj = ei.Flag.FullObjectsPackage;
				}
				if (
					fti.Exists
					&& !fti.Ignore
					&& fullobj
					&& Helper.CompareableFileName(fti.Name).EndsWith("\\objects")
				)
				{
					if (firstobjpkg)
					{
						firstobjpkg = false;
						fti.EpVersion = -1;
					}
					else
					{
						fti.EpVersion = FileTableItem.GetEPVersion(fti.Type);
					}

					if (
						FileTableItem.GetEPVersion(fti.Type)
						== PathProvider.Global.GameVersion
					)
					{
						fti.EpVersion = FileTableItem.GetEPVersion(fti.Type);
					}

					lbfolder.Items[i] = fti;
				}
				#endregion
			}
			cbIncCep.Tag = null;
		}

		private void cbIncNightlife_CheckedChanged(object sender, EventArgs e)
		{
			if (speady)
			{
				return;
			}

			if (cbIncCep.Tag != null)
			{
				return;
			}

			Enabled = false;
			try
			{
				CheckBox cb = (CheckBox)sender;

				Tag = true;

				btReload.Enabled = true;
				if (cb == cbIncCep)
				{
					ChangeFileTable(cb, null);
				}
				else if (cb == lcb["cbIncGraphics"])
				{
					ChangeFileTable(cb, null);
				}
				else
				{
					#region FileTableSimpleSelectUseGroups
					ExpansionItem ei = cb.Tag as ExpansionItem;
					if (
						cb.Checked
						&& Helper.WindowsRegistry.FileTableSimpleSelectUseGroups
					)
					{
						foreach (Control c in groupBox8.Controls)
						{
							if (c is CheckBox cbs)
							{
								if (cbs.Tag is ExpansionItem eis)
								{
									if (cbs.Checked && !ei.ShareOneGroup(eis))
									{
										cbs.Checked = false;
									}
								}
							}
						}
					}
					#endregion
					ChangeFileTable(cb, ei.Expansion);
				}

				Tag = null;
				SetupFileTableCheckboxes();
			}
			finally
			{
				Application.DoEvents();
				Enabled = true;
			}
		}

		private void lladddown_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			Enabled = false;
			try
			{
				FileTableItem fti = new FileTableItem("Downloads", true, false, -1);
				fti.Name = PathProvider.Global.GetSaveGamePathForGroup(
							PathProvider.Global.CurrentGroup
						)
						.Count > 0
					? System.IO.Path.Combine(
						PathProvider.Global.GetSaveGamePathForGroup(
							PathProvider.Global.CurrentGroup
						)[0],
						"Downloads"
					)
					: System.IO.Path.Combine(
						PathProvider.SimSavegameFolder,
						"Downloads"
					);

				fti.Type = FileTablePaths.SaveGameFolder;
				lbfolder.Items.Insert(0, fti);
				btReload.Enabled = true;
				SetupFileTableCheckboxes();
			}
			finally
			{
				Application.DoEvents();
				Enabled = true;
			}
		}

		private void lldel_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lbfolder.SelectedIndex < 0)
			{
				return;
			}

			Enabled = false;
			try
			{
				lbfolder.Items.RemoveAt(lbfolder.SelectedIndex);
				btReload.Enabled = true;
				SetupFileTableCheckboxes();
			}
			finally
			{
				Application.DoEvents();
				Enabled = true;
			}
		}

		private void lladd_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			FileTableItem fti = FileTableItemForm.Execute();
			if (fti != null)
			{
				Enabled = false;
				try
				{
					lbfolder.Items.Insert(0, fti);
					btReload.Enabled = true;
					SetupFileTableCheckboxes();
				}
				finally
				{
					Application.DoEvents();
					Enabled = true;
				}
			}
		}

		private void llchg_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lbfolder.SelectedItem != null)
			{
				if (FileTableItemForm.Execute((FileTableItem)lbfolder.SelectedItem))
				{
					Enabled = false;
					try
					{
						lbfolder.Items[lbfolder.SelectedIndex] = (FileTableItem)
							lbfolder.SelectedItem;
						btReload.Enabled = true;
						SetupFileTableCheckboxes();
					}
					finally
					{
						Application.DoEvents();
						Enabled = true;
					}
				}
			}
		}
		#endregion

		private void cbLock_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox cb = sender as CheckBox;

			if (cb.Checked)
			{
				LockDocksClick(sender, e);
			}
			else
			{
				UnlockDocksClick(sender, e);
			}
		}

		private void checkControl1_FixedFileTable(object sender, EventArgs e)
		{
			RebuildFileTableList();
		}

		private void cbCustom_SelectedIndexChanged(object sender, EventArgs e)
		{
			pgcustom.SelectedObject = cbCustom.SelectedItem;
		}

		void cbautobak_CheckedChanged(object sender, EventArgs e)
		{
			if (
				cbautobak.CheckState == CheckState.Checked
				&& !Helper.WindowsRegistry.AutoBackup)
			{
				MessageBox.Show(
					Localization.GetString("cbautobak_CheckedChanged"),
					Text,
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);
			}
		}

		class MyPropertyGrid : PropertyGrid
		{
		}

		private void lbAboot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			About.ShowFileTable();
			lbAboot.LinkVisited = true;
		}

		private void cbBigIcons_CheckedChanged(object sender, EventArgs e)
		{
			if (Helper.WindowsRegistry.UseBigIcons != cbBigIcons.Checked)
			{
				Helper.WindowsRegistry.UseBigIcons = cbBigIcons.Checked;
				lbBigIconNote.Visible = true;
			}
		}

		private void cbhidden_CheckedChanged(object sender, EventArgs e)
		{
			if (cbhidden.Checked)
			{
				groupBox8.Visible = false;
				cbsilent.Checked = false;
				cbsilent.Enabled = false;
			}
			else
			{
				cbsilent.Enabled = true;
			}
		}

		private void cbautostore_CheckedChanged(object sender, EventArgs e)
		{
			if (Helper.WindowsRegistry.Layout.AutoStoreLayout != cbautostore.Checked)
			{
				Helper.WindowsRegistry.Layout.AutoStoreLayout = cbautostore.Checked;
			}
		}

		private void cbpetability_CheckedChanged(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			Helper.WindowsRegistry.ShowPetAbilities = cbpetability.Checked;
		}

		private void cbmoreskills_CheckedChanged(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			Helper.WindowsRegistry.ShowMoreSkills = cbmoreskills.Checked;
		}

		private void btNuffing_Click(object sender, EventArgs e)
		{
			Enabled = false;
			Tag = true;
			speady = true;
			try
			{
				foreach (Control c in groupBox8.Controls)
				{
					if (c is CheckBox cbs)
					{
						if (cbs.CheckState != 0)
						{
							cbs.CheckState = 0;
							cbs.Checked = false;
							if (cbs != lcb["cbIncGraphics"])
							{
								if (cbs.Tag is ExpansionItem eis)
								{
									ChangeFileTable(cbs, eis.Expansion);
								}
							}
							else
							{
								ChangeFileTable(cbs, null);
							}
						}
					}
				}
				Tag = null;
				SetupFileTableCheckboxes();
			}
			finally
			{
				speady = false;
				Application.DoEvents();
				Enabled = true;
			}
		}

		private void btevryfing_Click(object sender, EventArgs e)
		{
			Enabled = false;
			Tag = true;
			speady = true;
			try
			{
				foreach (Control c in groupBox8.Controls)
				{
					if (c is CheckBox cbs)
					{
						if (!(cbs.Tag is ExpansionItem eis))
						{
							if (cbs.CheckState != CheckState.Checked)
							{
								cbs.CheckState = CheckState.Checked;
								cbs.Checked = true;
								ChangeFileTable(cbs, null);
							}
						}
						else
						{
							if (
								(
									PathProvider.Global.GameVersion > 20
									|| !eis.Flag.SimStory
								)
								&& (eis.Exists || eis.InstallFolder != "")
								&& !neveruse(eis)
							)
							{
								if (cbs.CheckState != CheckState.Checked)
								{
									cbs.CheckState = CheckState.Checked;
									cbs.Checked = true;
									ChangeFileTable(cbs, eis.Expansion);
								}
							}
						}
					}
				}
				Tag = null;
				SetupFileTableCheckboxes();
			}
			finally
			{
				speady = false;
				Application.DoEvents();
				Enabled = true;
			}
		}

		private void ChoosePage(object sender, EventArgs e)
		{
			SelectButton((ToolStripButton)sender);
		}

		public void SelectButton(ToolStripButton b)
		{
			for (int i = 0; i < toolBar1.Items.Count; i++)
			{
				if (toolBar1.Items[i] is ToolStripButton item)
				{
					item.Checked = item == b;
					if (item.Tag != null)
					{
						Panel pn = (Panel)item.Tag;
						pn.Visible = item.Checked;
					}
				}
			}
		}

		private void cbtrimname_CheckedChanged(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			Helper.WindowsRegistry.OWtrimnames = cbtrimname.Checked;
		}

		private void cbshowalls_CheckedChanged(object sender, EventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			Helper.WindowsRegistry.OWincludewalls = cbshowalls.Checked;
		}
	}
}
