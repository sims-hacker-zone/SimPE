// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Forms.MainUI;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Swaf
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public class SwafUI : IPackedFileUI
	{
		#region Code to Startup the UI

		/// <summary>
		/// Holds a reference to the Form containing the UI Panel
		/// </summary>
		internal static WantsForm form;

		/// <summary>
		/// Constructor for the Class
		/// </summary>
		public SwafUI()
		{
			//form = WrapperFactory.form;
			if (form == null)
			{
				form = new WantsForm();

				form.cbtype.Items.Add(WantType.Undefined);
				form.cbtype.Items.Add(WantType.None);
				form.cbtype.Items.Add(WantType.Sim);
				form.cbtype.Items.Add(WantType.Object);
				form.cbtype.Items.Add(WantType.Category);
				form.cbtype.Items.Add(WantType.Skill);
				form.cbtype.Items.Add(WantType.Career);

				form.ListWants();

				WantLoader.WantNameLoader.AddObjects(
					Wrapper.ObjectComboBox.ObjectCache.List
				);
			}
		}
		#endregion

		#region IPackedFileUI Member

		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public System.Windows.Forms.Control GUIHandle => form.wantsPanel;

		private static string oldpkg = "";

		/// <summary>
		/// true if the package was changed since the last run
		/// </summary>
		/// <param name="wrp">The File that will be loaded (contains a valid Package witha FileName)</param>
		/// <returns>true, if the package Name changed</returns>
		public static bool ChangedNeighborhood(Swaf wrp)
		{
			string newpkg = wrp.Package.FileName.Trim().ToString();
			if (newpkg != oldpkg)
			{
				oldpkg = newpkg;
				return true;
			}

			return false;
		}

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <param name="wrapper">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrapper)
		{
			Swaf wrp = (Swaf)wrapper;
			form.wrapper = wrp;
			form.Tag = true;

			try
			{
				if (ChangedNeighborhood(wrp))
				{
					WantLoader.WantNameLoader.AddSimNames();
				}

				Interfaces.Wrapper.ISDesc sdsc = wrp.SimDescription;
				form.lbsimname.Text = sdsc != null ? sdsc.SimName + " " + sdsc.SimFamilyName : Localization.Manager.GetString("Unknown");

				form.lastwi = null;
				form.lastlvi = null;

				Wait.SubStart();
				form.lvwant.Items.Clear();
				form.iwant.Images.Clear();
				foreach (WantItem wi in wrp.Wants)
				{
					form.AddWantToList(form.lvwant, form.iwant, wi);
				}

				form.lvfear.Items.Clear();
				form.ifear.Images.Clear();
				foreach (WantItem wi in wrp.Fears)
				{
					form.AddWantToList(form.lvfear, form.ifear, wi);
				}

				form.lvlife.Items.Clear();
				form.ilife.Images.Clear();
				foreach (WantItem wi in wrp.LifetimeWants)
				{
					form.AddWantToList(form.lvlife, form.ilife, wi);
				}

				form.tvhist.Nodes.Clear();
				form.ihist.Images.Clear();
				form.ihist.Images.Add(
					new System.Drawing.Bitmap(
						GetType()
							.Assembly.GetManifestResourceStream("SimPe.img.nothumb.png")
					)
				);

				if (wrp.Version >= 0x06)
				{
					if (!form.tabControl1.TabPages.Contains(form.tblife))
					{
						form.tabControl1.TabPages.Add(form.tblife);
						form.tabControl1.SelectedIndex = 3;
					}
				}
				else
				{
					if (form.tabControl1.TabPages.Contains(form.tblife))
					{
						form.tabControl1.TabPages.Remove(form.tblife);
						form.tabControl1.SelectedIndex = 0;
					}
				}

				WantInformation.SaveCache();
			}
			catch (Exception ex)
			{
				Message.Show(ex.Message + "\n" + ex.StackTrace);
			}
			finally
			{
				form.Tag = null;
				Wait.SubStop();
			}
		}

		#endregion

		#region IDisposable Member
		public virtual void Dispose()
		{
		}
		#endregion
	}
}
