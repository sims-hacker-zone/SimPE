// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Drawing;
using System.Windows.Forms;

using SimPe.Cache;
using SimPe.Interfaces.Plugin;
using System.Linq;
using SimPe.PackedFiles.Sdsc;

namespace SimPe.PackedFiles.Ngbh
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public class NgbhUI : IPackedFileUI
	{
		/// <summary>
		/// Returns the MemoryObject Cache
		/// </summary>
		internal static Cache.Cache ObjectCache => Wrapper.ObjectComboBox.ObjectCache;

		#region Code to Startup the UI

		/// <summary>
		/// Holds a reference to the Form containing the UI Panel
		/// </summary>
		internal static NgbhForm form;

		/// <summary>
		/// Constructor for the Class
		/// </summary>
		public NgbhUI()
		{
			//form = WrapperFactory.form;
			if (form == null)
			{
				form = new NgbhForm();
				form.cbguid.Items.Clear();
				form.cbguid.Sorted = false;

				form.cbguid.Items.Add(
					new Data.Alias(
						0,
						"-: " + Localization.Manager.GetString("Unknown"),
						"{name}"
					)
				);

				Wait.Message = "Load Memories from Cache";
				form.cbguid.Items.AddRange((from container in Cache.Cache.GlobalCache.Items[ContainerType.Memory].Values
											from MemoryCacheItem mci in container
											where mci.ObjectType == Data.ObjectTypes.Memory
												|| mci.ObjectType == Data.ObjectTypes.Normal
													&& mci.ObjdName.ToLower().IndexOf("token") != -1
											select new Data.Alias(mci.Guid, mci.Name)
											{
												Tag = (new object[3] { mci.FileDescriptor, mci.ObjectType, mci.Icon })
											}).ToArray());

				form.cbguid.Sorted = true;
			}
		}
		#endregion

		#region IPackedFileUI Member

		/// <summary>
		/// Returns the Panel that will be displayed within SimPe
		/// </summary>
		public Control GUIHandle => form.ngbhPanel;

		/// <summary>
		/// Is called by SimPe (through the Wrapper) when the Panel is going to be displayed, so
		/// you should updatet the Data displayed by the Panel with the Attributes stored in the
		/// passed Wrapper.
		/// </summary>
		/// <param name="wrapper">The Attributes of this Wrapper have to be displayed</param>
		public void UpdateGUI(IFileWrapper wrapper)
		{
			form.wrapper = (IFileWrapperSaveExtension)wrapper;

			Ngbh wrp = (Ngbh)wrapper;

			form.lv.BeginUpdate();
			form.lv.Items.Clear();
			form.ilist.Images.Clear();
			form.cbsub.Items.Clear();
			form.cbown.Items.Clear();
			form.gbmem.Enabled = false;
			form.lbmem.Items.Clear();

			Interfaces.Files.IPackedFileDescriptor[] pfds = wrp.Package.FindFiles(
				Data.FileTypes.SDSC
			);
			form.cbsub.Items.Add(new Data.Alias(0, "---", "{name}"));
			form.cbsub.Sorted = false;
			form.cbown.Items.Add(new Data.Alias(0, "---", "{name}"));
			form.cbown.Sorted = false;
			foreach (Interfaces.Files.IPackedFileDescriptor spfd in pfds)
			{
				SDesc sdesc = new SDesc(
					wrp.Provider.SimNameProvider,
					wrp.Provider.SimFamilynameProvider,
					null
				);

				Wait.SubStart();

				sdesc.ProcessData(spfd, wrp.Package);

				ListViewItem lvi = new ListViewItem
				{
					Text = sdesc.SimName + " " + sdesc.SimFamilyName
				};

#if DEBUG
				Data.Alias a = new Data.Alias(sdesc.SimId, lvi.Text);
				lvi.Text += " (0x" + Helper.HexString(sdesc.Instance) + ")";
#else
				Data.Alias a = new Data.Alias(sdesc.SimId, lvi.Text, "{name}");
#endif

				lvi.Tag = sdesc;

				a.Tag = new object[1];
				a.Tag[0] = sdesc.Instance;
				form.cbsub.Items.Add(a);
				form.cbown.Items.Add(a);

				if (sdesc.HasImage)
				{
					/*if (sdesc.Unlinked!=0x00)
					{
						Image img = (Image)sdesc.Image.Clone();
						System.Drawing.Graphics g = Graphics.FromImage(img);
						g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
						g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;

						Pen pen = new Pen(Color.FromArgb(0xD0, Color.DarkGreen), 3);

						g.FillRectangle(pen.Brush, 0, 0, img.Width, img.Height);

						form.ilist.Images.Add(img);
					} */
					if (sdesc.Unlinked != 0x00 || !sdesc.AvailableCharacterData)
					{
						Image img = (Image)sdesc.Image.Clone();
						Graphics g = Graphics.FromImage(img);
						g.CompositingQuality = System
							.Drawing
							.Drawing2D
							.CompositingQuality
							.HighQuality;
						g.CompositingMode = System
							.Drawing
							.Drawing2D
							.CompositingMode
							.SourceOver;

						Pen pen = new Pen(Data.MetaData.SpecialSimColor, 3);

						g.FillRectangle(pen.Brush, 0, 0, img.Width, img.Height);

						int pos = 2;
						if (sdesc.Unlinked != 0x00)
						{
							g.FillRectangle(
								new Pen(Data.MetaData.UnlinkedSim, 1).Brush,
								pos,
								2,
								25,
								25
							);
							pos += 28;
						}
						if (!sdesc.AvailableCharacterData)
						{
							g.FillRectangle(
								new Pen(Data.MetaData.InactiveSim, 1).Brush,
								pos,
								2,
								25,
								25
							);
							pos += 28;
						}

						form.ilist.Images.Add(img);
					}
					else
					{
						form.ilist.Images.Add(sdesc.Image);
					}

					lvi.ImageIndex = form.ilist.Images.Count - 1;
				}

				form.lv.Items.Add(lvi);
			}
			form.cbsub.Sorted = true;
			form.cbown.Sorted = true;
			form.lv.Sort();

			form.lv.EndUpdate();

			Wait.SubStop();
		}

		#endregion

		#region IDisposable Member
		public virtual void Dispose()
		{
		}
		#endregion
	}
}
