// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Drawing;

using Ambertation.Windows.Forms;
using Ambertation.Windows.Forms.Graph;

using SimPe.Extensions;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Mmat;
namespace SimPe.Plugin
{
	/// <summary>
	/// Creates a visual representation of the SceneGraph
	/// </summary>
	public class GraphBuilder
	{
		Hashtable colors;

		public GraphPanel Graph
		{
			get;
		}
		EventHandler click;

		/// <summary>
		/// tracks the left coordinates for each top coordinate (key)
		/// </summary>
		Hashtable coords;

		/// <summary>
		/// Keeps the names of all added Files
		/// </summary>
		Hashtable names;

		/// <summary>
		/// Create a new instance an prepare the some Datatypes
		/// </summary>
		/// <param name="pb"></param>
		/// <param name="click"></param>
		public GraphBuilder(System.Windows.Forms.Control pb, EventHandler click)
		{
			colors = new Hashtable();
			names = new Hashtable();

			colors.Add("CRES", Color.RoyalBlue);
			colors.Add("SHPE", Color.GreenYellow);
			colors.Add("GMND", Color.Yellow);
			colors.Add("GMDC", Color.Thistle);
			colors.Add("TXMT", Color.Orange);
			colors.Add("TXTR", Color.MediumVioletRed);
			colors.Add("LIFO", Color.PaleVioletRed);
			colors.Add("LGHT", Color.White);

			Graph = new GraphPanel
			{
				Parent = pb
			};
			this.click = click;

			coords = new Hashtable();
		}

		Interfaces.Scenegraph.IScenegraphItem BuildRcol(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile pkg,
			GraphItem gi
		)
		{
			GenericRcol rcol = new GenericRcol(null, false).ProcessFile(pfd, pkg);

			gi.Text = Hashes.StripHashFromName(rcol.FileName);
			gi.Tag = rcol;

			if (pfd.Type == Data.FileTypes.TXTR)
			{
				ImageData id = (ImageData)rcol.Blocks[0];
				gi.Size = new Size(gi.Size.Width, 80);
				gi.Thumbnail = ImageLoader.Preview(
					id.LargestTexture.Texture,
					new Size(48, 48)
				);
			}
			return rcol;
		}

		Interfaces.Scenegraph.IScenegraphItem BuildMmat(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile pkg,
			GraphItem gi
		)
		{
			MmatWrapper mmat = new MmatWrapper().ProcessFile(pfd, pkg);

			gi.Text =
				mmat.GetSaveItem("subsetName").StringValue
				+ " (family="
				+ mmat.GetSaveItem("family").StringValue
				+ ", objectStateIndex="
				+ Helper.HexString(mmat.GetSaveItem("objectStateIndex").UIntegerValue)
				+ ", materialStateFlags="
				+ Helper.HexString(mmat.GetSaveItem("materialStateFlags").UIntegerValue)
				+ ", objectGuid="
				+ Helper.HexString(mmat.GetSaveItem("objectGUID").UIntegerValue)
				+ ")";
			gi.Properties["Default"].Value = mmat.GetSaveItem("defaultMaterial")
				.BooleanValue.ToString();
			gi.Properties["cres"].Value = mmat.GetSaveItem("modelName")
				.StringValue.ToString();
			gi.Properties["txmt"].Value = mmat.GetSaveItem("name")
				.StringValue.ToString();

			gi.Size = new Size(gi.Size.Width, 96);
			gi.Tag = mmat;
			return mmat;
		}

		void AddItem(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile pkg,
			GraphItem parent,
			Interfaces.Scenegraph.IScenegraphFileIndex fileindex
		)
		{
			#region Default Setup
			int top = -128;
			int left = 0;

			if (parent != null)
			{
				top = parent.Location.Y;
			}

			do
			{
				top += 128;
				if (coords.ContainsKey(top))
				{
					left = (int)coords[top];
				}
				//if (parent!=null) if (left<parent.Location.X) left = parent.Location.X;
			} while (left > Graph.Parent.Width && false);

			GraphItem gi = new GraphItem(new Ambertation.Collections.PropertyItems())
			{
				Text = Hashes.StripHashFromName(pfd.Filename)
			};
			//gi.BeginUpdate();
			//gi.Location = new Point(left, top);
			gi.SetBounds(left, top, 200, 64);
			gi.GotFocus += new EventHandler(gi_GotFocus);
			gi.Tag = Hashes.StripHashFromName(pfd.Filename);
			gi.Fade = 0.7f;
			//gi.LinkColor = Color.FromArgb(35, Color.Black);
			//gi.SelectedLinkColor = Color.FromArgb(0xff, Color.DarkBlue);

			FileTypeInformation fti = pfd.Type.ToFileTypeInformation();
			gi.Properties["Type"].Value = fti.ShortName;
			gi.Properties["Available"].Value = "false";
			//gi.Parent = gc;
			#endregion

			//check if we already have a reource of that kind
			string name = gi.Text.Trim().ToLower();
			if (names.ContainsKey(name))
			{
				//gi.EndUpdate();
				gi = (GraphItem)names[name];

				parent?.ChildItems.Add(gi);
			}
			else
			{
				#region find File
				Interfaces.Scenegraph.IScenegraphItem item = null;
				Interfaces.Files.IPackedFileDescriptor pkgpfd = pkg.FindFile(pfd);

				//not found in the passed package, look for a global File with that Name
				if (pkgpfd == null)
				{
					Interfaces.Scenegraph.IScenegraphFileIndexItem items =
						FileTableBase.FileIndex.FindFileByName(
							pfd.Filename,
							pfd.Type,
							pfd.Group,
							true
						);
					if (items != null)
					{
						gi.Properties["Available"].Value = "extern";
						gi.Properties["File"].Value = items.Package.FileName;
						gi.Size = new Size(gi.Size.Width, 70);
						gi.PanelColor = Color.Black;
					}
				}
				#endregion

				//the file is available, so add it
				if (pkgpfd != null)
				{
					gi.Properties["Available"].Value = "true";
					if (colors.ContainsKey(fti.ShortName))
					{
						gi.PanelColor = (Color)colors[fti.ShortName];
					}

					if (Data.MetaData.RcolList.Contains(pfd.Type))
					{
						item = BuildRcol(pkgpfd, pkg, gi);
					}
					else if (pfd.Type == Data.FileTypes.MMAT)
					{
						item = BuildMmat(pkgpfd, pkg, gi);
					}
					/*}
else
{
	if (Data.MetaData.RcolList.Contains(pfd.Type)) item = BuildRcol(pkgpfd, altpkg, gi);
	else if (pfd.Type==Data.FileTypes.MMAT) item = BuildMmat(pkgpfd, altpkg, gi);
}*/

					//check again if we still don't have that file
					name = gi.Text.Trim().ToLower();
					if (names.ContainsKey(name))
					{
						//gi.EndUpdate();
						gi = (GraphItem)names[name];
					}
					else
					{
						//now process the Reference Files
						if (item != null)
						{
							foreach (var list in item.ReferenceChains.Values)
							{
								foreach (
									Interfaces.Files.IPackedFileDescriptor spfd in list
								)
								{
									AddItem(spfd, pkg, gi, fileindex);
								}
							}
						}
					}
				}

				gi.Invalidate();

				if (!names.ContainsKey(name))
				{
					names.Add(name, gi);
					gi.Parent = Graph;
					coords[top] = left + 8 + gi.Size.Width;

					if (pkgpfd == null)
					{
						gi.PanelColor = Color.DarkRed;
						gi.ForeColor = Color.White;
						gi.BorderColor = gi.ForeColor;
						if ((string)gi.Properties["Available"].Value == "extern")
						{
							gi.PanelColor = Color.Black;
						}
					}
				}

				parent?.ChildItems.Add(gi);
			}

			//gi.EndUpdate();
		}

		/// <summary>
		/// Show the Graph
		/// </summary>
		/// <param name="pkg"></param>
		/// <param name="fileindex"></param>
		/// <remarks>Do not run twice</remarks>
		public void BuildGraph(
			Interfaces.Files.IPackageFile pkg,
			Interfaces.Scenegraph.IScenegraphFileIndex fileindex
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds;
			Graph.BeginUpdate();
			Graph.Clear();
			Graph.SaveBounds = false;
			Graph.AutoSize = true;
			coords.Clear();
			names.Clear();
			if (Helper.WindowsRegistry.Config.CresPrioritize)
			{
				if (WaitingScreen.Running)
				{
					WaitingScreen.UpdateMessage("Scaning CRES Tree");
				}

				pfds = pkg.FindFiles(Data.FileTypes.CRES);
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					AddItem(pfd, pkg, null, fileindex);
				}
				if (WaitingScreen.Running)
				{
					WaitingScreen.UpdateMessage("Scaning MMAT Tree");
				}

				pfds = pkg.FindFiles(Data.FileTypes.MMAT);
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					AddItem(pfd, pkg, null, fileindex);
				}
			}
			else
			{
				if (WaitingScreen.Running)
				{
					WaitingScreen.UpdateMessage("Scaning MMAT Tree");
				}

				pfds = pkg.FindFiles(Data.FileTypes.MMAT);
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					AddItem(pfd, pkg, null, fileindex);
				}
				if (WaitingScreen.Running)
				{
					WaitingScreen.UpdateMessage("Scaning CRES Tree");
				}

				pfds = pkg.FindFiles(Data.FileTypes.CRES);
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					AddItem(pfd, pkg, null, fileindex);
				}
			}
			Graph.AutoSize = false;
			Graph.SaveBounds = true;
			Graph.EndUpdate();
		}

		/// <summary>
		/// Adds all Orphants to the Tree
		/// </summary>
		/// <param name="pkg"></param>
		public void FindUnused(Interfaces.Files.IPackageFile pkg)
		{
			int top = 0;
			int left = 0;
			foreach (int t in coords.Keys)
			{
				if (t > top)
				{
					top = t;
				}
			}

			top += 128;
			foreach (Interfaces.Files.IPackedFileDescriptor pfd in pkg.Index)
			{
				if (
					(pfd.Type == Data.FileTypes.MMAT)
					|| Data.MetaData.RcolList.Contains(pfd.Type)
				)
				{
					GraphItem gi = new GraphItem(
						new Ambertation.Collections.PropertyItems()
					)
					{
						Text = Hashes.StripHashFromName(pfd.Filename)
					};

					//gi.BeginUpdate();
					gi.SetBounds(left, top, 200, 64);
					//gi.Location = new Point(left, top);
					gi.GotFocus += new EventHandler(gi_GotFocus);

					gi.Tag = Hashes.StripHashFromName(pfd.Filename);
					gi.Fade = 0.7f;
					//gi.LinkColor = Color.FromArgb(35, Color.Black);

					//gi.SelectedLinkColor = Color.FromArgb(0xff, Color.DarkBlue);

					FileTypeInformation fti = pfd.Type.ToFileTypeInformation();
					gi.Properties["Type"].Value = fti.ShortName;
					gi.Properties["Available"].Value = "true (orphan)";
					if (colors.ContainsKey(fti.ShortName))
					{
						gi.PanelColor = (Color)colors[fti.ShortName];
					}

					Interfaces.Scenegraph.IScenegraphItem item = null;
					if (Data.MetaData.RcolList.Contains(pfd.Type))
					{
						item = BuildRcol(pfd, pkg, gi);
					}
					else if (pfd.Type == Data.FileTypes.MMAT)
					{
						item = BuildMmat(pfd, pkg, gi);
					}
					//gi.Parent = gc;
					if (item != null)
					{
						string name = gi.Text.Trim().ToLower();
						if (!names.ContainsKey(name))
						{
							//gc.Add(gi);
							gi.Parent = Graph;
							left += gi.Size.Width + 8;
							//gi.EndUpdate();
						}
					}
				}
			}

			Graph.Update();
		}

		private void gi_GotFocus(object sender, EventArgs e)
		{
			if (click != null)
			{
				click(sender, e);
			}
		}
	}
}
