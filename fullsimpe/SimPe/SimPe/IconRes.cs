// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;

namespace SimPe
{
	/// <summary>
	/// Toolbar Icons
	/// This is where the Icons are.
	/// </summary>
	public class GetIcon
	{
		/// <summary>
		/// Workplace Helper Icon
		/// </summary>
		public static Image Fail => Properties.Resources.whfail;

		/// <summary>
		/// Workplace Helper Icon
		/// </summary>
		public static Image OK => Properties.Resources.whok;

		/// <summary>
		/// Workplace Helper Icon
		/// </summary>
		public static Image Unk => Properties.Resources.whunk;

		/// <summary>
		/// Workplace Helper Icon
		/// </summary>
		public static Image Warn => Properties.Resources.whwarn;

		/// <summary>
		/// Workplace Helper Icon
		/// </summary>
		public static Image Support => Properties.Resources.support;

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image New
		{
			get
			{
				switch (Helper.WindowsRegistry.Layout.SelectedTheme)
				{
					case 6:
						return Properties.Resources.blNew;
					case 8:
						return Properties.Resources.psNew;
					default:
						return Properties.Resources.bgNew;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image Open
		{
			get
			{
				switch (Helper.WindowsRegistry.Layout.SelectedTheme)
				{
					case 6:
						return Properties.Resources.blOpen;
					case 8:
						return Properties.Resources.psOpen;
					default:
						return Properties.Resources.bgOpen;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image Save
		{
			get
			{
				switch (Helper.WindowsRegistry.Layout.SelectedTheme)
				{
					case 6:
						return Properties.Resources.blSave;
					case 8:
						return Properties.Resources.psSave;
					default:
						return Properties.Resources.bgSave;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image SaveAs
		{
			get
			{
				switch (Helper.WindowsRegistry.Layout.SelectedTheme)
				{
					case 6:
						return Properties.Resources.blSaveAs;
					case 8:
						return Properties.Resources.psSave;
					default:
						return Properties.Resources.bgSaveAs;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image Delete
		{
			get
			{
				switch (Helper.WindowsRegistry.Layout.SelectedTheme)
				{
					case 6:
						return Properties.Resources.blDelete;
					case 8:
						return Properties.Resources.psDelete;
					default:
						return Properties.Resources.bgDelete;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image Reset => Helper.WindowsRegistry.Layout.SelectedTheme == 6 ? Properties.Resources.blReset : (Image)Properties.Resources.bgReset;

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionClone => Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
					? Properties.Resources.acbgclone
					: (Image)Properties.Resources.acclone;

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionCreate => Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
					? Properties.Resources.acbgcreate
					: (Image)Properties.Resources.accreate;

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionDelete => Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
					? Properties.Resources.acbgdelete
					: (Image)Properties.Resources.acdelete;

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionExport => Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
					? Properties.Resources.acbgexport
					: (Image)Properties.Resources.acexport;

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionFilter => Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
					? Properties.Resources.acbgfilter
					: (Image)Properties.Resources.acfilter;

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionImport => Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
					? Properties.Resources.acbgimport
					: (Image)Properties.Resources.acimport;

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionReplace => Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
					? Properties.Resources.acbgreplace
					: (Image)Properties.Resources.acreplace;

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionRestore => Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
					? Properties.Resources.acbgrestore
					: (Image)Properties.Resources.acrestore;

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionStart => Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
					? Properties.Resources.acbgstart
					: (Image)Properties.Resources.acstart;

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionFixTGI => Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
					? Properties.Resources.acbgfixtgi
					: (Image)Properties.Resources.acfixtgi;

		/// <summary>
		/// Dockbox Icons
		/// </summary>
		public static Image dbUnique => Helper.WindowsRegistry.UseBigIcons
					|| Helper.WindowsRegistry.Layout.SelectedTheme >= 4
					? Properties.Resources.dbbgagent
					: (Image)Properties.Resources.dbagent;

		/// <summary>
		/// Dockbox Icons
		/// </summary>
		public static Image dbPackage => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.dbbgpackage : (Image)Properties.Resources.dbpackage;

		/// <summary>
		/// Dockbox Icons
		/// </summary>
		public static Image dbRecure => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.dbbgrecur : (Image)Properties.Resources.dbrecur;

		/// <summary>
		/// Tool Icons
		/// </summary>
		public static Image S2pack => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.dbbgS2pack : (Image)Properties.Resources.dbS2pack;

		/// <summary>
		/// Tool Icons
		/// </summary>
		public static Image S2pc => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.dbbgs2pc : (Image)Properties.Resources.dbs2pc;

		/// <summary>
		/// Tool Icons
		/// </summary>
		public static Image S2packOpen => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.dbbgoS2pack : (Image)Properties.Resources.dbS2pack;

		/// <summary>
		/// Tool Icons
		/// </summary>
		public static Image S2pcOpen => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.dbbgos2pc : (Image)Properties.Resources.dbs2pc;

		/// <summary>
		/// Dockbox Icons
		/// </summary>
		public static Image Selection => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.dbbgselected : (Image)Properties.Resources.dbselected;

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image Camera => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.tbbgcamera : (Image)Properties.Resources.tbcamera;

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image NameMap => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.tbbgcontents : (Image)Properties.Resources.tbcontents;

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image CreatePackage => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.tbbgcreatepackage : (Image)Properties.Resources.tbcreatepackage;

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image CreatePackageW => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.tbbgwcreatepackage : (Image)Properties.Resources.tbcreatepackage;

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image tbNeighboorhood => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.tbbgneighboorhood : (Image)Properties.Resources.tbneighboorhood;

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image SimBrowser => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.tbbgsimbrowser : (Image)Properties.Resources.tbsimbrowser;

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image SimSurgery => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.tbbgsurg : (Image)Properties.Resources.tbsurg;

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image SkinWorkshop => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.tbbgskinn : (Image)Properties.Resources.tbskinn;

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image HashGenerator => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.tbbggenerator : (Image)Properties.Resources.tbgenerator;

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image FixIntegrity => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.tbbgintegrity : (Image)Properties.Resources.tbintegrit;

		/// <summary>
		/// Generic Icon
		/// </summary>
		public static Image DeleteSim => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bgdeletesim : (Image)Properties.Resources.deletesim;

		/// <summary>
		/// for optional.simpe.3d.plugin (anim preview)
		/// </summary>
		public static Image AnimCamera => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.anibgcamera : (Image)Properties.Resources.anicamera;

		/// <summary>
		/// for pj Hood Tool
		/// </summary>
		public static Image HoodTool => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bghoodtool : (Image)Properties.Resources.hoodtool;

		/// <summary>
		/// for Bhav Plugin
		/// </summary>
		public static Image OpenLua => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bhbglua : (Image)Properties.Resources.bhlua;

		/// <summary>
		/// for Bhav Plugin
		/// </summary>
		public static Image ImportSemi => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bhbgimport : (Image)Properties.Resources.bhimport;

		/// <summary>
		/// for Copyright Plugin
		/// </summary>
		public static Image Copyright => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.copyrightbg : (Image)Properties.Resources.copyright;

		/// <summary>
		/// for Downloads Plugin (Content Preview)
		/// </summary>
		public static Image ContentPreview => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.cbgpreview : (Image)Properties.Resources.cpreview;

		/// <summary>
		/// for Check File Table (Content Preview)
		/// </summary>
		public static Image CheckTable => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bgacchecktable : (Image)Properties.Resources.acchecktable;

		/// <summary>
		/// for Action Build GUID List
		/// </summary>
		public static Image BuildPhpGuid => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bgPhpGuid : (Image)Properties.Resources.tbPhpGuid;

		/// <summary>
		/// Dockbox Icons
		/// </summary>
		public static Image pjSearch => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bgfinder : (Image)Properties.Resources.pjfinder;

		/// <summary>
		/// pjOBJDTool Icon
		/// </summary>
		public static Image pjOBJDtool => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bgpjobjdtool : (Image)Properties.Resources.pjobjdtool;

		/// <summary>
		/// Bnfo Icon
		/// </summary>
		public static Image BnfoIco => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bgbookmark : (Image)Properties.Resources.bookmark;

		/// <summary>
		/// Misc Icon
		/// </summary>
		public static Image GameTip => Properties.Resources.gametip;

		/// <summary>
		/// Misc Icon
		/// </summary>
		public static Image ReadOnly => Properties.Resources.readim;

		/// <summary>
		/// Misc Icon
		/// </summary>
		public static Image Writable => Properties.Resources.stxt;

		/// <summary>
		/// Butterfly Icon
		/// </summary>
		public static Image Butterfly => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bgbutflie : (Image)Properties.Resources.butflie;

		/// <summary>
		/// PJSE Body Mesh Icons
		/// </summary>
		public static Image BMExtract => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bgExtractSt : (Image)Properties.Resources.ExtractSt;

		/// <summary>
		/// PJSE Body Mesh Icons
		/// </summary>
		public static Image BMlinker => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bgLinkSt : (Image)Properties.Resources.LinkSt;

		/// <summary>
		/// PJSE ObjKeyTool Icon
		/// </summary>
		public static Image ObjKeyTool => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bgKey : (Image)Properties.Resources.pjkey;

		/// <summary>
		/// Information Icon
		/// </summary>
		public static Image Information => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.Infobg : (Image)Properties.Resources.Info;

		/// <summary>
		/// Debug Icon
		/// </summary>
		public static Image Debug => Helper.WindowsRegistry.UseBigIcons ? Properties.Resources.bgdebug : (Image)Properties.Resources.debug;
	}
}
