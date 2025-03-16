// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Linq;

using SimPe.Interfaces;

namespace SimPe
{
	/// <summary>
	/// This class manages the initialization of Various Plugins
	/// </summary>
	public class PluginManager : Ambertation.Threading.StoppableThread
	{
		LoadFileWrappersExt wloader;

		internal PluginManager(
			LoadedPackage lp
		)
			: base(true)
		{
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
			LoadMenuItems();
			wloader.AddListeners(ref ChangedGuiResourceEvent);
			LoadActionTools(
				GetDefaultActions()
			);
			LoadActionTools(
				LoadExternalTools()
			);
			LoadActionTools(null);
			LoadDocks(lp);
		}

		/// <summary>
		/// Load all Static FileWrappers (theese Wrappers are allways available!)
		/// </summary>
		void LoadStaticWrappers()
		{
			FileTableBase.WrapperRegistry.Register(new CommandlineHelpFactory());
		}

		/// <summary>
		/// Load all Wrappers found in the Plugins Folder - this before Static FileWrappers
		/// </summary>
		void LoadDynamicWrappers()
		{
			FileTableBase.WrapperRegistry.Register(new Plugin.WrapperFactory());
		}

		void LoadMenuItems()
		{
			foreach (IToolExt tool in FileTable.ToolRegistry.ToolsPlus)
			{
				string name = tool.ToString();
				string[] parts = name.Split("\\".ToCharArray());
				name = Localization.GetString(parts[parts.Length - 1]);
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
			}
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
		IToolAction[] GetDefaultActions()
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
				new Actions.Default.ActionGroupFilter(),
			};
		}

		/// <summary>
		/// Load all available Action Tools
		/// </summary>
		void LoadActionTools(
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
		void LoadDocks(LoadedPackage lp)
		{
		}
		#endregion
	}
}
