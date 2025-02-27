using System;

namespace SimPe
{
	/// <summary>
	/// An Item in the Help Menu
	/// </summary>
	class HelpTopicMenuItem : System.Windows.Forms.ToolStripMenuItem
	{
		Interfaces.IHelp topic;

		public HelpTopicMenuItem(Interfaces.IHelp topic)
			: base()
		{
			this.topic = topic;
			this.Text = GetName();
			this.Image = topic.Icon;

			this.Click += new EventHandler(HelpTopicMenuItem_Activate);
		}

		public string GetName()
		{
			string[] path = GetMenuPath();
			if (path.Length > 0)
			{
				return Localization.GetString(path[path.Length - 1]);
			}

			return Localization.GetString("Unknown");
		}

		public string[] GetMenuPath()
		{
			return topic.ToString().Split(new char[] { '\\' });
		}

		private void HelpTopicMenuItem_Activate(object sender, EventArgs e)
		{
			topic.ShowHelp(new ShowHelpEventArgs());
		}
	}

	/// <summary>
	/// Used to add HelpTopics to a Menu
	/// </summary>
	public class LoadHelpTopics
	{
		System.Windows.Forms.ToolStripMenuItem mbi;

		public LoadHelpTopics(System.Windows.Forms.ToolStripMenuItem parentmenu)
		{
			mbi = parentmenu;
			AddItems(FileTable.HelpTopicRegistry);
			SetupImages(parentmenu);
		}

		void SetupImages(System.Windows.Forms.ToolStripMenuItem parent)
		{
			foreach (System.Windows.Forms.ToolStripMenuItem m in parent.DropDownItems)
			{
				SetupImages(m);
				if (parent.Image == null && m.Image != null)
				{
					parent.Image = m.Image;
				}
			}

			if (parent.Image == null)
			{
				parent.Image = GetIcon.Support;
			}
		}

		void AddItems(Interfaces.IHelpRegistry reg)
		{
			foreach (Interfaces.IHelp topic in reg.HelpTopics)
			{
				AddItem(topic);
			}
		}

		void AddItem(Interfaces.IHelp topic)
		{
			HelpTopicMenuItem htmi = new HelpTopicMenuItem(topic);
			string[] path = htmi.GetMenuPath();

			System.Windows.Forms.ToolStripMenuItem parent = mbi;
			for (int i = 0; i < path.Length - 1; i++)
			{
				string n = Localization.GetString(path[i]);

				System.Windows.Forms.ToolStripMenuItem m = null;
				foreach (
					System.Windows.Forms.ToolStripMenuItem item in parent.DropDownItems
				)
				{
					if (item.Text.Trim().ToLower() == n.Trim().ToLower())
					{
						m = item;
						break;
					}
				}
				if (m == null)
				{
					m = new System.Windows.Forms.ToolStripMenuItem(n);
					parent.DropDownItems.Add(m);
				}
				parent = m;
			}
			parent.DropDownItems.Add(htmi);
		}
	}
}
