// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using SimPe.Forms.MainUI.Components;
using SimPe.Interfaces;

namespace SimPe
{
	/// <summary>
	/// This class manages the initialization of Various Plugins
	/// </summary>
	public class PluginManager : Ambertation.Threading.StoppableThread
	{
		LoadFileWrappersExt wloader;
		LoadHelpTopics lht;

		internal PluginManager(
			ToolStripMenuItem toolmenu,
			ToolStrip tootoolbar,
			TD.SandDock.TabControl dc,
			LoadedPackage lp,
			ContextMenuStrip defaultactionmenu,
			ToolStrip actiontoolbar,
			Ambertation.Windows.Forms.DockContainer docktooldc,
			ToolStripMenuItem helpmenu,
			Windows.Forms.ResourceListViewExt lv
		)
			: base(true)
		{
			Splash.Screen.SetMessage("Loading Type Registry"); // the first message clearly seen
			PackedFiles.TypeRegistry tr = new PackedFiles.TypeRegistry();

			FileTableBase.ProviderRegistry = tr;
			FileTable.ToolRegistry = tr;
			FileTableBase.WrapperRegistry = tr;
			FileTable.CommandLineRegistry = tr;
			FileTable.HelpTopicRegistry = tr;
			FileTable.SettingsRegistry = tr;
			wloader = new LoadFileWrappersExt();

			LoadDynamicWrappers();
			LoadStaticWrappers();
			LoadMenuItems(toolmenu, tootoolbar);

			Splash.Screen.SetMessage("Loading Listeners");
			wloader.AddListeners(ref ChangedGuiResourceEvent);
			//dc.ActiveDocumentChanged += new TD.SandDock.ActiveDocumentEventHandler(wloader.ActiveDocumentChanged);
			//lp.AfterFileLoad += new Events.PackageFileLoadedEvent(wloader.ChangedPackage);


			Splash.Screen.SetMessage("Loading Default Actions");
			LoadActionTools(
				actiontoolbar,
				defaultactionmenu,
				GetDefaultActions(lv)
			);
			Splash.Screen.SetMessage("Loading External Tools");
			LoadActionTools(
				actiontoolbar,
				defaultactionmenu,
				LoadExternalTools()
			);
			Splash.Screen.SetMessage("Loading Default Tools");
			LoadActionTools(actiontoolbar, null, null);

			Splash.Screen.SetMessage("Loading Docks");
			LoadDocks(docktooldc, lp);
			Splash.Screen.SetMessage("Loading Help Topics");
			lht = new LoadHelpTopics(helpmenu);

			Splash.Screen.SetMessage("Loaded Help Topics");
		}

		/// <summary>
		/// fired whenever a (classic) Tool was closed
		/// </summary>
		public event ToolMenuItemExt.ExternalToolNotify ClosedToolPlugin;

		/// <summary>
		/// Event Wrapper
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="pk"></param>
		void ClosedToolPluginHandler(object sender, PackageArg pk)
		{
			ClosedToolPlugin?.Invoke(sender, pk);
		}

		/// <summary>
		/// Load all Static FileWrappers (theese Wrappers are allways available!)
		/// </summary>
		void LoadStaticWrappers()
		{
			Splash.Screen.SetMessage("Loading Static Wrappers");
			FileTableBase.WrapperRegistry.Register(new CommandlineHelpFactory());
		}

		/// <summary>
		/// Load all Wrappers found in the Plugins Folder - this before Static FileWrappers
		/// </summary>
		void LoadDynamicWrappers()
		{
			Splash.Screen.SetMessage("Loading Dynamic Wrappers");
			FileTableBase.WrapperRegistry.Register(new Plugin.WrapperFactory());
		}

		void LoadMenuItems(ToolStripMenuItem toolmenu, ToolStrip tootoolbar)
		{
			Splash.Screen.SetMessage("Loading Menu Items");
			ToolMenuItemExt.ExternalToolNotify chghandler =
				new ToolMenuItemExt.ExternalToolNotify(ClosedToolPluginHandler);
			foreach (IToolExt tool in FileTable.ToolRegistry.ToolsPlus)
			{
				string name = tool.ToString();
				string[] parts = name.Split("\\".ToCharArray());
				name = Localization.GetString(parts[parts.Length - 1]);
				ToolMenuItemExt item = new ToolMenuItemExt(name, tool, chghandler);

				LoadFileWrappersExt.AddMenuItem(
					ref ChangedGuiResourceEvent,
					toolmenu.DropDownItems,
					item,
					parts
				);
			}

			foreach (ITool tool in FileTable.ToolRegistry.Tools)
			{
				string name = tool.ToString().Trim();
				if (name == "")
				{
					continue;
				}

				string[] parts = name.Split("\\".ToCharArray());
				name = Localization.GetString(parts[parts.Length - 1]);
				ToolMenuItemExt item = new ToolMenuItemExt(name, tool, chghandler);

				LoadFileWrappersExt.AddMenuItem(
					ref ChangedGuiResourceEvent,
					toolmenu.DropDownItems,
					item,
					parts
				);
			}

			LoadFileWrappersExt.BuildToolBar(tootoolbar, toolmenu.DropDownItems);
		}

		#region Action Tools
		event Events.ChangedResourceEvent ChangedGuiResourceEvent;

		object thsender;
		Events.ResourceEventArgs the;

		protected override void StartThread()
		{
			foreach (Delegate d in ChangedGuiResourceEvent.GetInvocationList())
			{
				if (HaveToStop)
				{
					break;
				}
				((Events.ChangedResourceEvent)d)(thsender, the);
			}
		}

		/// <summary>
		/// Fires with the same arguments that were used during
		/// the last Time <see cref="ChangedGuiResourceEventHandler"/> was called
		/// </summary>
		public void ChangedGuiResourceEventHandler()
		{
			if (the != null)
			{
				ChangedGuiResourceEventHandler(thsender, the);
			}
		}

		/// <summary>
		/// Fired when a Resource was changed by a ToolPlugin and the Enabled state needs to be changed
		/// </summary>
		public void ChangedGuiResourceEventHandler(
			object sender,
			Events.ResourceEventArgs e
		)
		{
			RemoteControl.FireResourceListSelectionChangedHandler(sender, e);
			if (ChangedGuiResourceEvent != null)
			{
				thsender = sender;
				the = e;

				//this.ExecuteThread(System.Threading.ThreadPriority.Normal, "ActionTool notification");

				//ChangedGuiResourceEvent(sender, e);

				foreach (Delegate d in ChangedGuiResourceEvent.GetInvocationList())
				{
					if (d.Target is IToolExt ext && !ext.Visible)
					{
						continue;
					}
					((Events.ChangedResourceEvent)d)(sender, e);
				}
			}
		}

		/// <summary>
		/// Returns a List of Builtin Actions
		/// </summary>
		/// <returns></returns>
		IToolAction[] GetDefaultActions(Windows.Forms.ResourceListViewExt lv)
		{
			return new IToolAction[]
			{
				new Actions.Default.AddAction(),
				new Actions.Default.ExportAction(),
				new Actions.Default.ReplaceAction(),
				new Actions.Default.DeleteAction(),
				new Actions.Default.RestoreAction(),
				new Actions.Default.CloneAction(),
				new Actions.Default.CreateAction(),
				new Actions.Default.ActionGroupFilter(lv),
			};
		}

		/// <summary>
		/// Load all available Action Tools
		/// </summary>
		void LoadActionTools(
			ToolStrip tb,
			ContextMenuStrip mi,
			IEnumerable<IToolAction> tools
		)
		{
			if (tools == null)
			{
				tools = FileTable.ToolRegistry.Actions;
			}

			bool tfirst = true;
			bool mfirst = true;
			foreach (IToolAction tool in tools)
			{
				ActionToolDescriptor atd = new ActionToolDescriptor(tool);
				ChangedGuiResourceEvent += new Events.ChangedResourceEvent(
					atd.ChangeEnabledStateEventHandler
				);

				if (mi != null)
				{
					bool beggrp = mfirst && mi.Items.Count != 0;
					if (beggrp)
					{
						mi.Items.Add("-");
					}

					mi.Items.Add(atd.MenuButton);

					mfirst = false;
				}

				if (tb != null && atd.ToolBarButton != null)
				{
					if (tfirst && tb.Items.Count != 0)
					{
						tb.Items.Add(new ToolStripSeparator());
					}

					tb.Items.Add(atd.ToolBarButton);

					tfirst = false;
				}
			}
		}
		#endregion

		#region External Program Tools
		private IEnumerable<IToolAction> LoadExternalTools()
		{
			return from item in ToolLoaderExt.Items
				   select new Actions.Default.StartExternalToolAction(item);
		}
		#endregion

		#region dockable Tools
		void LoadDocks(Ambertation.Windows.Forms.DockContainer dc, LoadedPackage lp)
		{
			foreach (IDockableTool idt in FileTable.ToolRegistry.Docks)
			{
				Ambertation.Windows.Forms.DockPanel dctrl = idt.GetDockableControl();

				if (dctrl != null)
				{
					dctrl.Name =
						"dc." + idt.GetType().Namespace + "." + idt.GetType().Name;
					dctrl.Manager = dc.Manager;
					dc.Controls.Add(dctrl);
					//dctrl.DockNextTo(dc);

					ChangedGuiResourceEvent += new Events.ChangedResourceEvent(
						idt.RefreshDock
					);
					dctrl.Tag = idt.Shortcut;
					idt.RefreshDock(this, new Events.ResourceEventArgs(lp));
				}
			}
		}
		#endregion
	}
}
