// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Linq;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin.Tool.Action
{
	/// <summary>
	/// The ReloadFileTable Action
	/// </summary>
	public class ActionBuildPhpGuidList : Interfaces.IToolAction
	{
		#region IToolAction Member

		public virtual bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			return true;
		}

		public void ExecuteEventHandler(object sender, Events.ResourceEventArgs e)
		{
			if (!ChangeEnabledStateEventHandler(null, e))
			{
				return;
			}

			FileTableBase.FileIndex.Load();

			System.IO.StreamWriter sw = new System.IO.StreamWriter(
				new System.IO.MemoryStream()
			);
			try
			{
				System.Collections.ArrayList guids = new System.Collections.ArrayList();
				var items =
					FileTableBase.FileIndex.FindFile(Data.FileTypes.OBJD, true);
				sw.WriteLine("<?");
				sw.WriteLine("$guids = array(");
				sw.Write("    ");
				Wait.SubStart(items.Count());
				int ct = 0;
				foreach (
					Interfaces.Scenegraph.IScenegraphFileIndexItem item in items
				)
				{
					PackedFiles.Wrapper.ExtObjd objd =
						new PackedFiles.Wrapper.ExtObjd().ProcessFile(item);

					if (guids.Contains(objd.Guid) || objd.Type == Data.ObjectTypes.Memory || objd.Type == Data.ObjectTypes.Person)
					{
						continue;
					}

					if (ct > 0)
					{
						sw.Write(",");
					}

					ct++;
					Wait.Progress = ct;
					sw.Write("array(");
					sw.Write("0x" + Helper.HexString(objd.Guid));
					guids.Add(objd.Guid);
					sw.Write(", '");
					sw.Write(
						"Maxis: "
							+ objd.FileName.Replace("'", "")
								.Replace("\\", "")
								.Replace("\"", "")
					);
					/*SimPe.Interfaces.Scenegraph.IScenegraphFileIndexItem[] list = SimPe.FileTable.FileIndex.FindFile(Data.FileTypes.CTSS, objd.FileDescriptor.Group, objd.CTSSInstance, null);
					if (list.Length==0) sw.Write(objd.FileName.Replace("'", "").Replace("\\", "").Replace("\"", ""));
					else
					{
						SimPe.PackedFiles.Wrapper.Str str = new SimPe.PackedFiles.Wrapper.Str(1);
						str.ProcessData(list[0]);
						SimPe.PackedFiles.Wrapper.StrItemList strs = str.LanguageItems(SimPe.Data.MetaData.Languages.English);
						if (strs.Count==0) sw.Write(objd.FileName.Replace("'", "").Replace("\\", "").Replace("\"", ""));
						else sw.Write(strs[0].Title.Replace("'", "").Replace("\\", "").Replace("\"", ""));
					}*/
					sw.WriteLine("')");
				}
				Wait.SubStop();
				sw.WriteLine(");");
				sw.WriteLine("?>");

				Report f = new Report();
				f.Execute(sw);
			}
			finally
			{
				sw.Close();
			}
		}

		#endregion


		#region IToolPlugin Member
		public override string ToString()
		{
			return "Build GUID List";
		}
		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => null;

		public virtual bool Visible => true;

		#endregion
	}
}
