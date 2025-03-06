// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SimPe.PackedFiles.Wrapper.SCOR
{
	public partial class LearnedBahaviourComboBox : ComboBox
	{
		public LearnedBahaviourComboBox()
		{
			InitializeComponent();
			DropDownStyle = ComboBoxStyle.DropDownList;

			if (!DesignMode)
			{
				try
				{
					foreach (ExtObjd objd in BehaviourObjds)
					{
						Items.Add(new ContainerItem(objd));
					}
				}
				catch { } //this is needed for the stupid Designer >:|
			}
		}

		class ContainerItem
		{
			ExtObjd objd;

			public ContainerItem(uint guid)
			{
				objd = new ExtObjd
				{
					Guid = guid,
					FileName = "0x" + Helper.HexString(guid)
				};
			}

			public ContainerItem(ExtObjd objd)
			{
				this.objd = objd;
			}

			public uint Guid => objd.Guid;

			public override string ToString()
			{
				return objd.FileName;
			}
		}

		#region Behaviours
		static List<ExtObjd> objds;
		internal static List<ExtObjd> BehaviourObjds
		{
			get
			{
				if (objds == null)
				{
					GetPetBehaviours();
				}

				return objds;
			}
		}

		private static void GetPetBehaviours()
		{
			if (objds != null)
			{
				return;
			}

			objds = new List<ExtObjd>();

			FileTableBase.FileIndex.Load();
			IEnumerable<Interfaces.Scenegraph.IScenegraphFileIndexItem> objs =
				FileTableBase.FileIndex.FindFileDiscardingGroup(
					Data.FileTypes.OBJD,
					0x41a7
				);
			Wait.Start(objs.Count());
			Wait.Message = "Loading Behaviours...";
			int ct = 0;
			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem ofii in objs)
			{
				Wait.Progress = ct++;
				ExtObjd obj = new ExtObjd();
				obj.ProcessData(ofii);
				if (obj.FileName.StartsWith("Learned Behavior"))
				{
					objds.Add(obj);
				}
			}
			Wait.Stop();
		}
		#endregion

		[
			DesignerSerializationVisibility(
				DesignerSerializationVisibility.Hidden
			),
			Browsable(false)
		]
		public uint SelectedGuid
		{
			get => !(SelectedItem is ContainerItem ci) ? 0 : ci.Guid;
			set
			{
				SelectedIndex = -1;
				for (int i = 0; i < Items.Count; i++)
				{
					ContainerItem ci = Items[i] as ContainerItem;
					if (ci.Guid == value)
					{
						SelectedIndex = i;
						return;
					}
				}

				Items.Add(new ContainerItem(value));
			}
		}
	}
}
