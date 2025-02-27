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
		public static Image Fail => global::SimPe.Properties.Resources.whfail;

		/// <summary>
		/// Workplace Helper Icon
		/// </summary>
		public static Image OK => global::SimPe.Properties.Resources.whok;

		/// <summary>
		/// Workplace Helper Icon
		/// </summary>
		public static Image Unk => global::SimPe.Properties.Resources.whunk;

		/// <summary>
		/// Workplace Helper Icon
		/// </summary>
		public static Image Warn => global::SimPe.Properties.Resources.whwarn;

		/// <summary>
		/// Workplace Helper Icon
		/// </summary>
		public static Image Support => global::SimPe.Properties.Resources.support;

		/// <summary>
		/// Standard Toolbar Icon
		/// </summary>
		public static Image New
		{
			get
			{
				if (Helper.WindowsRegistry.Layout.SelectedTheme == 6)
				{
					return global::SimPe.Properties.Resources.blNew;
				}
				else if (Helper.WindowsRegistry.Layout.SelectedTheme == 8)
				{
					return global::SimPe.Properties.Resources.psNew;
				}
				else
				{
					return global::SimPe.Properties.Resources.bgNew;
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
					return global::SimPe.Properties.Resources.blOpen;
				}
				else if (Helper.WindowsRegistry.Layout.SelectedTheme == 8)
				{
					return global::SimPe.Properties.Resources.psOpen;
				}
				else
				{
					return global::SimPe.Properties.Resources.bgOpen;
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
					return global::SimPe.Properties.Resources.blSave;
				}
				else if (Helper.WindowsRegistry.Layout.SelectedTheme == 8)
				{
					return global::SimPe.Properties.Resources.psSave;
				}
				else
				{
					return global::SimPe.Properties.Resources.bgSave;
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
					return global::SimPe.Properties.Resources.blSaveAs;
				}
				else if (Helper.WindowsRegistry.Layout.SelectedTheme == 8)
				{
					return global::SimPe.Properties.Resources.psSave;
				}
				else
				{
					return global::SimPe.Properties.Resources.bgSaveAs;
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
					return global::SimPe.Properties.Resources.blDelete;
				}
				else if (Helper.WindowsRegistry.Layout.SelectedTheme == 8)
				{
					return global::SimPe.Properties.Resources.psDelete;
				}
				else
				{
					return global::SimPe.Properties.Resources.bgDelete;
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
					return global::SimPe.Properties.Resources.blReset;
				}
				else
				{
					return global::SimPe.Properties.Resources.bgReset;
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
					return global::SimPe.Properties.Resources.acbgclone;
				}
				else
				{
					return global::SimPe.Properties.Resources.acclone;
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
					return global::SimPe.Properties.Resources.acbgcreate;
				}
				else
				{
					return global::SimPe.Properties.Resources.accreate;
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
					return global::SimPe.Properties.Resources.acbgdelete;
				}
				else
				{
					return global::SimPe.Properties.Resources.acdelete;
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
					return global::SimPe.Properties.Resources.acbgexport;
				}
				else
				{
					return global::SimPe.Properties.Resources.acexport;
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
					return global::SimPe.Properties.Resources.acbgfilter;
				}
				else
				{
					return global::SimPe.Properties.Resources.acfilter;
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
					return global::SimPe.Properties.Resources.acbgimport;
				}
				else
				{
					return global::SimPe.Properties.Resources.acimport;
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
					return global::SimPe.Properties.Resources.acbgreplace;
				}
				else
				{
					return global::SimPe.Properties.Resources.acreplace;
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
					return global::SimPe.Properties.Resources.acbgrestore;
				}
				else
				{
					return global::SimPe.Properties.Resources.acrestore;
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
					return global::SimPe.Properties.Resources.acbgstart;
				}
				else
				{
					return global::SimPe.Properties.Resources.acstart;
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
					return global::SimPe.Properties.Resources.acbgfixtgi;
				}
				else
				{
					return global::SimPe.Properties.Resources.acfixtgi;
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
					return global::SimPe.Properties.Resources.dbbgagent;
				}
				else
				{
					return global::SimPe.Properties.Resources.dbagent;
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
					return global::SimPe.Properties.Resources.dbbgpackage;
				}
				else
				{
					return global::SimPe.Properties.Resources.dbpackage;
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
					return global::SimPe.Properties.Resources.dbbgrecur;
				}
				else
				{
					return global::SimPe.Properties.Resources.dbrecur;
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
					return global::SimPe.Properties.Resources.dbbgS2pack;
				}
				else
				{
					return global::SimPe.Properties.Resources.dbS2pack;
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
					return global::SimPe.Properties.Resources.dbbgs2pc;
				}
				else
				{
					return global::SimPe.Properties.Resources.dbs2pc;
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
					return global::SimPe.Properties.Resources.dbbgoS2pack;
				}
				else
				{
					return global::SimPe.Properties.Resources.dbS2pack;
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
					return global::SimPe.Properties.Resources.dbbgos2pc;
				}
				else
				{
					return global::SimPe.Properties.Resources.dbs2pc;
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
					return global::SimPe.Properties.Resources.dbbgselected;
				}
				else
				{
					return global::SimPe.Properties.Resources.dbselected;
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
					return global::SimPe.Properties.Resources.tbbgcamera;
				}
				else
				{
					return global::SimPe.Properties.Resources.tbcamera;
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
					return global::SimPe.Properties.Resources.tbbgcontents;
				}
				else
				{
					return global::SimPe.Properties.Resources.tbcontents;
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
					return global::SimPe.Properties.Resources.tbbgcreatepackage;
				}
				else
				{
					return global::SimPe.Properties.Resources.tbcreatepackage;
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
					return global::SimPe.Properties.Resources.tbbgwcreatepackage;
				}
				else
				{
					return global::SimPe.Properties.Resources.tbcreatepackage;
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
					return global::SimPe.Properties.Resources.tbbgneighboorhood;
				}
				else
				{
					return global::SimPe.Properties.Resources.tbneighboorhood;
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
					return global::SimPe.Properties.Resources.tbbgsimbrowser;
				}
				else
				{
					return global::SimPe.Properties.Resources.tbsimbrowser;
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
					return global::SimPe.Properties.Resources.tbbgsurg;
				}
				else
				{
					return global::SimPe.Properties.Resources.tbsurg;
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
					return global::SimPe.Properties.Resources.tbbgskinn;
				}
				else
				{
					return global::SimPe.Properties.Resources.tbskinn;
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
					return global::SimPe.Properties.Resources.tbbggenerator;
				}
				else
				{
					return global::SimPe.Properties.Resources.tbgenerator;
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
					return global::SimPe.Properties.Resources.tbbgintegrity;
				}
				else
				{
					return global::SimPe.Properties.Resources.tbintegrit;
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
					return global::SimPe.Properties.Resources.bgdeletesim;
				}
				else
				{
					return global::SimPe.Properties.Resources.deletesim;
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
					return global::SimPe.Properties.Resources.anibgcamera;
				}
				else
				{
					return global::SimPe.Properties.Resources.anicamera;
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
					return global::SimPe.Properties.Resources.bghoodtool;
				}
				else
				{
					return global::SimPe.Properties.Resources.hoodtool;
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
					return global::SimPe.Properties.Resources.bhbglua;
				}
				else
				{
					return global::SimPe.Properties.Resources.bhlua;
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
					return global::SimPe.Properties.Resources.bhbgimport;
				}
				else
				{
					return global::SimPe.Properties.Resources.bhimport;
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
					return global::SimPe.Properties.Resources.copyrightbg;
				}
				else
				{
					return global::SimPe.Properties.Resources.copyright;
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
					return global::SimPe.Properties.Resources.cbgpreview;
				}
				else
				{
					return global::SimPe.Properties.Resources.cpreview;
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
					return global::SimPe.Properties.Resources.bgacchecktable;
				}
				else
				{
					return global::SimPe.Properties.Resources.acchecktable;
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
					return global::SimPe.Properties.Resources.bgPhpGuid;
				}
				else
				{
					return global::SimPe.Properties.Resources.tbPhpGuid;
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
					return global::SimPe.Properties.Resources.bgfinder;
				}
				else
				{
					return global::SimPe.Properties.Resources.pjfinder;
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
					return global::SimPe.Properties.Resources.bgpjobjdtool;
				}
				else
				{
					return global::SimPe.Properties.Resources.pjobjdtool;
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
					return global::SimPe.Properties.Resources.bgbookmark;
				}
				else
				{
					return global::SimPe.Properties.Resources.bookmark;
				}
			}
		}

		/// <summary>
		/// Misc Icon
		/// </summary>
		public static Image GameTit => global::SimPe.Properties.Resources.gametip;

		/// <summary>
		/// Misc Icon
		/// </summary>
		public static Image ReadOnly => global::SimPe.Properties.Resources.readim;

		/// <summary>
		/// Misc Icon
		/// </summary>
		public static Image Writable => global::SimPe.Properties.Resources.stxt;

		/// <summary>
		/// Butterfly Icon
		/// </summary>
		public static Image Butterfly
		{
			get
			{
				if (Helper.WindowsRegistry.UseBigIcons)
				{
					return global::SimPe.Properties.Resources.bgbutflie;
				}
				else
				{
					return global::SimPe.Properties.Resources.butflie;
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
					return global::SimPe.Properties.Resources.bgExtractSt;
				}
				else
				{
					return global::SimPe.Properties.Resources.ExtractSt;
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
					return global::SimPe.Properties.Resources.bgLinkSt;
				}
				else
				{
					return global::SimPe.Properties.Resources.LinkSt;
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
					return global::SimPe.Properties.Resources.bgKey;
				}
				else
				{
					return global::SimPe.Properties.Resources.pjkey;
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
					return global::SimPe.Properties.Resources.Infobg;
				}
				else
				{
					return global::SimPe.Properties.Resources.Info;
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
					return global::SimPe.Properties.Resources.bgdebug;
				}
				else
				{
					return global::SimPe.Properties.Resources.debug;
				}
			}
		}
	}
}
