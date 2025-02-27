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
				if (Helper.WindowsRegistry.Layout.SelectedTheme == 6)
				{
					return Properties.Resources.blNew;
				}
				else if (Helper.WindowsRegistry.Layout.SelectedTheme == 8)
				{
					return Properties.Resources.psNew;
				}
				else
				{
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
				if (Helper.WindowsRegistry.Layout.SelectedTheme == 6)
				{
					return Properties.Resources.blOpen;
				}
				else if (Helper.WindowsRegistry.Layout.SelectedTheme == 8)
				{
					return Properties.Resources.psOpen;
				}
				else
				{
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
				if (Helper.WindowsRegistry.Layout.SelectedTheme == 6)
				{
					return Properties.Resources.blSave;
				}
				else if (Helper.WindowsRegistry.Layout.SelectedTheme == 8)
				{
					return Properties.Resources.psSave;
				}
				else
				{
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
				if (Helper.WindowsRegistry.Layout.SelectedTheme == 6)
				{
					return Properties.Resources.blSaveAs;
				}
				else if (Helper.WindowsRegistry.Layout.SelectedTheme == 8)
				{
					return Properties.Resources.psSave;
				}
				else
				{
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
				if (Helper.WindowsRegistry.Layout.SelectedTheme == 6)
				{
					return Properties.Resources.blDelete;
				}
				else if (Helper.WindowsRegistry.Layout.SelectedTheme == 8)
				{
					return Properties.Resources.psDelete;
				}
				else
				{
					return Properties.Resources.bgDelete;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image Reset
		{
			get
			{
				if (Helper.WindowsRegistry.Layout.SelectedTheme == 6)
				{
					return Properties.Resources.blReset;
				}
				else
				{
					return Properties.Resources.bgReset;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionClone
		{
			get
			{
				if (
					Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
				)
				{
					return Properties.Resources.acbgclone;
				}
				else
				{
					return Properties.Resources.acclone;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionCreate
		{
			get
			{
				if (
					Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
				)
				{
					return Properties.Resources.acbgcreate;
				}
				else
				{
					return Properties.Resources.accreate;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionDelete
		{
			get
			{
				if (
					Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
				)
				{
					return Properties.Resources.acbgdelete;
				}
				else
				{
					return Properties.Resources.acdelete;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionExport
		{
			get
			{
				if (
					Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
				)
				{
					return Properties.Resources.acbgexport;
				}
				else
				{
					return Properties.Resources.acexport;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionFilter
		{
			get
			{
				if (
					Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
				)
				{
					return Properties.Resources.acbgfilter;
				}
				else
				{
					return Properties.Resources.acfilter;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionImport
		{
			get
			{
				if (
					Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
				)
				{
					return Properties.Resources.acbgimport;
				}
				else
				{
					return Properties.Resources.acimport;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionReplace
		{
			get
			{
				if (
					Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
				)
				{
					return Properties.Resources.acbgreplace;
				}
				else
				{
					return Properties.Resources.acreplace;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionRestore
		{
			get
			{
				if (
					Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
				)
				{
					return Properties.Resources.acbgrestore;
				}
				else
				{
					return Properties.Resources.acrestore;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionStart
		{
			get
			{
				if (
					Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
				)
				{
					return Properties.Resources.acbgstart;
				}
				else
				{
					return Properties.Resources.acstart;
				}
			}
		}

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image actionFixTGI
		{
			get
			{
				if (
					Helper.WindowsRegistry.UseBigIcons
					&& Helper.WindowsRegistry.Layout.SelectedTheme >= 4
				)
				{
					return Properties.Resources.acbgfixtgi;
				}
				else
				{
					return Properties.Resources.acfixtgi;
				}
			}
		}

		/// <summary>
		/// Dockbox Icons
		/// </summary>
		public static Image dbUnique
		{
			get
			{
				if (
					Helper.WindowsRegistry.UseBigIcons
					|| Helper.WindowsRegistry.Layout.SelectedTheme >= 4
				)
				{
					return Properties.Resources.dbbgagent;
				}
				else
				{
					return Properties.Resources.dbagent;
				}
			}
		}

		/// <summary>
		/// Dockbox Icons
		/// </summary>
		public static Image dbPackage
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.dbbgpackage;
				}
				else
				{
					return Properties.Resources.dbpackage;
				}
			}
		}

		/// <summary>
		/// Dockbox Icons
		/// </summary>
		public static Image dbRecure
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.dbbgrecur;
				}
				else
				{
					return Properties.Resources.dbrecur;
				}
			}
		}

		/// <summary>
		/// Tool Icons
		/// </summary>
		public static Image S2pack
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.dbbgS2pack;
				}
				else
				{
					return Properties.Resources.dbS2pack;
				}
			}
		}

		/// <summary>
		/// Tool Icons
		/// </summary>
		public static Image S2pc
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.dbbgs2pc;
				}
				else
				{
					return Properties.Resources.dbs2pc;
				}
			}
		}

		/// <summary>
		/// Tool Icons
		/// </summary>
		public static Image S2packOpen
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.dbbgoS2pack;
				}
				else
				{
					return Properties.Resources.dbS2pack;
				}
			}
		}

		/// <summary>
		/// Tool Icons
		/// </summary>
		public static Image S2pcOpen
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.dbbgos2pc;
				}
				else
				{
					return Properties.Resources.dbs2pc;
				}
			}
		}

		/// <summary>
		/// Dockbox Icons
		/// </summary>
		public static Image Selection
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.dbbgselected;
				}
				else
				{
					return Properties.Resources.dbselected;
				}
			}
		}

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image Camera
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.tbbgcamera;
				}
				else
				{
					return Properties.Resources.tbcamera;
				}
			}
		}

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image NameMap
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.tbbgcontents;
				}
				else
				{
					return Properties.Resources.tbcontents;
				}
			}
		}

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image CreatePackage
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.tbbgcreatepackage;
				}
				else
				{
					return Properties.Resources.tbcreatepackage;
				}
			}
		}

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image CreatePackageW
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.tbbgwcreatepackage;
				}
				else
				{
					return Properties.Resources.tbcreatepackage;
				}
			}
		}

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image tbNeighboorhood
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.tbbgneighboorhood;
				}
				else
				{
					return Properties.Resources.tbneighboorhood;
				}
			}
		}

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image SimBrowser
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.tbbgsimbrowser;
				}
				else
				{
					return Properties.Resources.tbsimbrowser;
				}
			}
		}

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image SimSurgery
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.tbbgsurg;
				}
				else
				{
					return Properties.Resources.tbsurg;
				}
			}
		}

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image SkinWorkshop
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.tbbgskinn;
				}
				else
				{
					return Properties.Resources.tbskinn;
				}
			}
		}

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image HashGenerator
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.tbbggenerator;
				}
				else
				{
					return Properties.Resources.tbgenerator;
				}
			}
		}

		/// <summary>
		/// Tool Box Icons
		/// </summary>
		public static Image FixIntegrity
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.tbbgintegrity;
				}
				else
				{
					return Properties.Resources.tbintegrit;
				}
			}
		}

		/// <summary>
		/// Generic Icon
		/// </summary>
		public static Image DeleteSim
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bgdeletesim;
				}
				else
				{
					return Properties.Resources.deletesim;
				}
			}
		}

		/// <summary>
		/// for optional.simpe.3d.plugin (anim preview)
		/// </summary>
		public static Image AnimCamera
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.anibgcamera;
				}
				else
				{
					return Properties.Resources.anicamera;
				}
			}
		}

		/// <summary>
		/// for pj Hood Tool
		/// </summary>
		public static Image HoodTool
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bghoodtool;
				}
				else
				{
					return Properties.Resources.hoodtool;
				}
			}
		}

		/// <summary>
		/// for Bhav Plugin
		/// </summary>
		public static Image OpenLua
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bhbglua;
				}
				else
				{
					return Properties.Resources.bhlua;
				}
			}
		}

		/// <summary>
		/// for Bhav Plugin
		/// </summary>
		public static Image ImportSemi
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bhbgimport;
				}
				else
				{
					return Properties.Resources.bhimport;
				}
			}
		}

		/// <summary>
		/// for Copyright Plugin
		/// </summary>
		public static Image Copyright
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.copyrightbg;
				}
				else
				{
					return Properties.Resources.copyright;
				}
			}
		}

		/// <summary>
		/// for Downloads Plugin (Content Preview)
		/// </summary>
		public static Image ContentPreview
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.cbgpreview;
				}
				else
				{
					return Properties.Resources.cpreview;
				}
			}
		}

		/// <summary>
		/// for Check File Table (Content Preview)
		/// </summary>
		public static Image CheckTable
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bgacchecktable;
				}
				else
				{
					return Properties.Resources.acchecktable;
				}
			}
		}

		/// <summary>
		/// for Action Build GUID List
		/// </summary>
		public static Image BuildPhpGuid
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bgPhpGuid;
				}
				else
				{
					return Properties.Resources.tbPhpGuid;
				}
			}
		}

		/// <summary>
		/// Dockbox Icons
		/// </summary>
		public static Image pjSearch
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bgfinder;
				}
				else
				{
					return Properties.Resources.pjfinder;
				}
			}
		}

		/// <summary>
		/// pjOBJDTool Icon
		/// </summary>
		public static Image pjOBJDtool
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bgpjobjdtool;
				}
				else
				{
					return Properties.Resources.pjobjdtool;
				}
			}
		}

		/// <summary>
		/// Bnfo Icon
		/// </summary>
		public static Image BnfoIco
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bgbookmark;
				}
				else
				{
					return Properties.Resources.bookmark;
				}
			}
		}

		/// <summary>
		/// Misc Icon
		/// </summary>
		public static Image GameTit => Properties.Resources.gametip;

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
		public static Image Butterfly
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bgbutflie;
				}
				else
				{
					return Properties.Resources.butflie;
				}
			}
		}

		/// <summary>
		/// PJSE Body Mesh Icons
		/// </summary>
		public static Image BMExtract
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bgExtractSt;
				}
				else
				{
					return Properties.Resources.ExtractSt;
				}
			}
		}

		/// <summary>
		/// PJSE Body Mesh Icons
		/// </summary>
		public static Image BMlinker
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bgLinkSt;
				}
				else
				{
					return Properties.Resources.LinkSt;
				}
			}
		}

		/// <summary>
		/// PJSE ObjKeyTool Icon
		/// </summary>
		public static Image ObjKeyTool
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bgKey;
				}
				else
				{
					return Properties.Resources.pjkey;
				}
			}
		}

		/// <summary>
		/// Information Icon
		/// </summary>
		public static Image Information
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.Infobg;
				}
				else
				{
					return Properties.Resources.Info;
				}
			}
		}

		/// <summary>
		/// Debug Icon
		/// </summary>
		public static Image Debug
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return Properties.Resources.bgdebug;
				}
				else
				{
					return Properties.Resources.debug;
				}
			}
		}
	}
}
