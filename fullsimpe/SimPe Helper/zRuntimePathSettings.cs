using System;
using System.ComponentModel;
namespace SimPe{
public class RuntimePathSettings : PathSettings { 
	public RuntimePathSettings() : base(Helper.WindowsRegistry){
	}


	[Category("BaseGame"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 1: Original")]
	public string GamePath
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(0));
		}
		set {PathProvider.Global.GetExpansion(0).InstallFolder = value;}
	}

	[Category("ExpansionPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - University'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 1: University")]
	public string EP1Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(1));
		}
		set {PathProvider.Global.GetExpansion(1).InstallFolder = value;}
	}

	[Category("ExpansionPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Nightlife'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 2: Nightlife")]
	public string EP2Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(2));
		}
		set {PathProvider.Global.GetExpansion(2).InstallFolder = value;}
	}

	[Category("ExpansionPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Open For Business'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 3: Business")]
	public string EP3Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(3));
		}
		set {PathProvider.Global.GetExpansion(3).InstallFolder = value;}
	}

	[Category("StuffPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Family Fun Stuff'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 1: Family Fun Stuff")]
	public string SP1Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(4));
		}
		set {PathProvider.Global.GetExpansion(4).InstallFolder = value;}
	}

	[Category("StuffPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Glamour Stuff'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 2: Glamour Stuff")]
	public string SP2Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(5));
		}
		set {PathProvider.Global.GetExpansion(5).InstallFolder = value;}
	}

	[Category("ExpansionPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Pets'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 4: Pets")]
	public string EP4Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(6));
		}
		set {PathProvider.Global.GetExpansion(6).InstallFolder = value;}
	}

	[Category("ExpansionPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Seasons'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 5: Seasons")]
	public string EP5Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(7));
		}
		set {PathProvider.Global.GetExpansion(7).InstallFolder = value;}
	}

	[Category("StuffPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Celebration! Stuff'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 3: Celebration! Stuff")]
	public string SP4Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(8));
		}
		set {PathProvider.Global.GetExpansion(8).InstallFolder = value;}
	}

	[Category("StuffPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - H&M Fashion Stuff'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 4: H&M Fashion Stuff")]
	public string SP5Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(9));
		}
		set {PathProvider.Global.GetExpansion(9).InstallFolder = value;}
	}

	[Category("ExpansionPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Bon Voyage'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 6: Bon Voyage")]
	public string EP6Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(10));
		}
		set {PathProvider.Global.GetExpansion(10).InstallFolder = value;}
	}

	[Category("StuffPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Teen Style Stuff'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 5: Teen Style Stuff")]
	public string SP6Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(11));
		}
		set {PathProvider.Global.GetExpansion(11).InstallFolder = value;}
	}

	[Category("StuffPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Extra Stuff'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 6: Extra Stuff")]
	public string ECCPath
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(12));
		}
		set {PathProvider.Global.GetExpansion(12).InstallFolder = value;}
	}

	[Category("ExpansionPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - FreeTime'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 7: FreeTime")]
	public string EP7Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(13));
		}
		set {PathProvider.Global.GetExpansion(13).InstallFolder = value;}
	}

	[Category("StuffPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Kitchen & Bath Interior Design Stuff'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 7: Kitchen & Bath Interior Design Stuff")]
	public string SP7Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(14));
		}
		set {PathProvider.Global.GetExpansion(14).InstallFolder = value;}
	}

	[Category("StuffPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - IKEA Home Stuff'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 8: IKEA Home Stuff")]
	public string SP8Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(15));
		}
		set {PathProvider.Global.GetExpansion(15).InstallFolder = value;}
	}

	[Category("ExpansionPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Apartment Life'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 8: Apartments")]
	public string EP8Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(16));
		}
		set {PathProvider.Global.GetExpansion(16).InstallFolder = value;}
	}

	[Category("ExpansionPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Mansions and Gardens Stuff'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 9: Mansions and Gardens Stuff")]
	public string EP9Path
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(17));
		}
		set {PathProvider.Global.GetExpansion(17).InstallFolder = value;}
	}

	[Category("StuffPack"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Store Edition'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 9: Store Edition")]
	public string SCPath
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(20));
		}
		set {PathProvider.Global.GetExpansion(20).InstallFolder = value;}
	}

	[Category("Story"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Castaway Stories'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 3: Castaway Stories")]
	public string SIMSCSPath
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(28));
		}
		set {PathProvider.Global.GetExpansion(28).InstallFolder = value;}
	}

	[Category("Story"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Pet Stories'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 2: Pet Stories")]
	public string SIMSPSPath
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(29));
		}
		set {PathProvider.Global.GetExpansion(29).InstallFolder = value;}
	}

	[Category("Story"), System.ComponentModel.Editor(typeof(SimPe.SelectSimFolderUITypeEditor), typeof(System.Drawing.Design.UITypeEditor)),
	Description("This should contain the installation directory of 'The Sims 2 - Life Stories'. The given Folder must contain a subfolder called 'TSData'. If this is empty, SimPe will use the default Folder."), DisplayName(" 1: Life Stories")]
	public string SIMSLSPath
	{
		get {
			return GetPath(PathProvider.Global.GetExpansion(30));
		}
		set {PathProvider.Global.GetExpansion(30).InstallFolder = value;}
	}

}}
