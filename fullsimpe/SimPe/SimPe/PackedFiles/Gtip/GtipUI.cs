// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Gtip;
using SimPe.PackedFiles.Picture;
using SimPe.PackedFiles.Str;

namespace SimPe.PackedFiles.Gtip
{
	public partial class GtipUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new Gtip Wrapper => base.Wrapper as Gtip;
		public Gtip TPFW => Wrapper;

		ushort gtipname;
		ushort gtipheader;
		ushort gtipbody;
		bool holde = true;

		#region WrapperBaseControl Member

		public GtipUI()
		{
			InitializeComponent();
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			holde = true;

			gtname.ForeColor =
				gtheader.ForeColor =
				gtbody.ForeColor =
				gtepack.ForeColor =
				gtimagy.ForeColor =
					System.Drawing.SystemColors.WindowText;

			gtnametxt.Text = gtheadtxt.Text = gtbodytxt.Text = "";
			button1.Text = "Show\r\nTexts";
			button1.Enabled = true;
			gtipname = Wrapper.Tipname;
			gtipheader = Wrapper.Tipheader;
			gtipbody = Wrapper.Tipbody;
			gtipname -= 1;
			gtipheader -= 1;
			gtipbody -= 1;
			gtname.Text = "0x" + Helper.HexString(gtipname);
			gtheader.Text = "0x" + Helper.HexString(gtipheader);
			gtbody.Text = "0x" + Helper.HexString(gtipbody);
			gtepack.Text = "0x" + Helper.HexString(Wrapper.Tipep);
			gtimagy.Text = "0x" + Helper.HexString(Wrapper.Tipicon);
			getpbpicture();
			holde = false;
		}

		public override void OnCommit()
		{
			base.OnCommit();
			TPFW.SynchronizeUserData(true, false);
		}
		#endregion

		#region IPackedFileUI Member
		System.Windows.Forms.Control IPackedFileUI.GUIHandle => this;
		#endregion

		#region IDisposable Member

		void IDisposable.Dispose()
		{
			TPFW.Dispose();
		}
		#endregion

		private void gtname_TextChanged(object sender, EventArgs e)
		{
			if (!holde)
			{
				try
				{
					gtipname = Convert.ToUInt16(gtname.Text, 16);
					gtipname += 1;
					if (Wrapper.Tipname != gtipname)
					{
						button1.Text = "Update\r\nText";
					}

					Wrapper.Tipname = gtipname;
					gtname.ForeColor = System.Drawing.SystemColors.WindowText;
				}
				catch
				{
					gtname.ForeColor = System.Drawing.Color.DarkRed;
				}
				disenalbecommit();
			}
		}

		private void gtheader_TextChanged(object sender, EventArgs e)
		{
			if (!holde)
			{
				try
				{
					gtipheader = Convert.ToUInt16(gtheader.Text, 16);
					gtipheader += 1;
					if (Wrapper.Tipheader != gtipheader)
					{
						button1.Text = "Update\r\nText";
					}

					Wrapper.Tipheader = gtipheader;
					gtheader.ForeColor = System.Drawing.SystemColors.WindowText;
				}
				catch
				{
					gtheader.ForeColor = System.Drawing.Color.DarkRed;
				}
				disenalbecommit();
			}
		}

		private void gtbody_TextChanged(object sender, EventArgs e)
		{
			if (!holde)
			{
				try
				{
					gtipbody = Convert.ToUInt16(gtbody.Text, 16);
					gtipbody += 1;
					if (Wrapper.Tipbody != gtipbody)
					{
						button1.Text = "Update\r\nText";
					}

					Wrapper.Tipbody = gtipbody;
					gtbody.ForeColor = System.Drawing.SystemColors.WindowText;
				}
				catch
				{
					gtbody.ForeColor = System.Drawing.Color.DarkRed;
				}
				disenalbecommit();
			}
		}

		private void gtepack_TextChanged(object sender, EventArgs e)
		{
			if (!holde)
			{
				try
				{
					Wrapper.Tipep = Convert.ToUInt16(gtepack.Text, 16);
					gtepack.ForeColor = System.Drawing.SystemColors.WindowText;
				}
				catch
				{
					gtepack.ForeColor = System.Drawing.Color.DarkRed;
				}
				disenalbecommit();
			}
		}

		private void gtimagy_TextChanged(object sender, EventArgs e)
		{
			if (!holde)
			{
				try
				{
					Wrapper.Tipicon = Convert.ToUInt32(gtimagy.Text, 16);
					getpbpicture();
					gtimagy.ForeColor = System.Drawing.SystemColors.WindowText;
				}
				catch
				{
					gtimagy.ForeColor = System.Drawing.Color.DarkRed;
					gtpbimage.Image = null;
				}
				disenalbecommit();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			button1.Text = "-";
			button1.Enabled = false;
			setgttext();
		}

		private void getpbpicture()
		{
			gtpbimage.Image = null;
			Packages.File pkg = Packages.File.LoadFromFile(
				System.IO.Path.Combine(
					PathProvider.Global.Latest.InstallFolder,
					"TSData\\Res\\UI\\ui.package"
				)
			);
			if (pkg != null)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(
					FileTypes.IMG,
					0,
					0x499DB772,
					Wrapper.Tipicon
				);
				if (pfd != null)
				{
					gtpbimage.Image = new Picture.Picture().ProcessFile(pfd, pkg).Image;
				}
			}
		}

		private void setgttext()
		{
			FileTableBase.FileIndex.Load();
			gtnametxt.Text = gtheadtxt.Text = gtbodytxt.Text = "-";
			int gtnm = Convert.ToInt32(Wrapper.Tipname) - 1;
			int gthd = Convert.ToInt32(Wrapper.Tipheader) - 1;
			int gtby = Convert.ToInt32(Wrapper.Tipbody) - 1;
			Packages.File package = Packages.File.LoadFromFile(
				System.IO.Path.Combine(
					PathProvider.Global.Latest.InstallFolder,
					"TSData\\Res\\Objects\\objects.package"
				)
			);
			if (package != null)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = package.FindFile(
					FileTypes.STR,
					0,
					0x7FE066DD,
					0x0000012D
				);
				if (pfd != null)
				{
					List<StrToken> items =
						new PackedFiles.Str.Str().ProcessFile(pfd, package).FallbackedLanguageItems(
							Helper.WindowsRegistry.Config.LanguageCode
						);
					if (items.Count > gtnm)
					{
						gtnametxt.Text = items[gtnm].Title;
					}

					if (items.Count > gthd)
					{
						gtheadtxt.Text = items[gthd].Title;
					}

					if (items.Count > gtby)
					{
						gtbodytxt.Text = items[gtby].Title;
					}
				}
			}
		}

		private void disenalbecommit()
		{
			if (
				gtname.ForeColor == System.Drawing.SystemColors.WindowText
				&& gtheader.ForeColor == System.Drawing.SystemColors.WindowText
				&& gtbody.ForeColor == System.Drawing.SystemColors.WindowText
				&& gtepack.ForeColor == System.Drawing.SystemColors.WindowText
				&& gtimagy.ForeColor == System.Drawing.SystemColors.WindowText
			)
			{
				CanCommit = true;
				if (button1.Text != "-")
				{
					button1.Enabled = true;
				}
			}
			else
			{
				CanCommit = false;
				button1.Enabled = false;
			}
		}
	}
}
