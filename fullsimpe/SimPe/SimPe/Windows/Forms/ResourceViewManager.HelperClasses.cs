// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;

namespace SimPe.Windows.Forms
{
	partial class ResourceViewManager
	{
		public enum SortColumn
		{
			Name = 0,
			Group = 1,
			InstanceHi = 2,
			InstanceLo = 3,
			Offset = 4,
			Size = 5,
			Type = 6,
			Instance = 7,
			Extension = 8,
		}

		public class ResourceList
			: List<Interfaces.Files.IPackedFileDescriptor>
		{
		}

		public class ResourceNameList : List<NamedPackedFileDescriptor>
		{
			DescriptorSort sorter;

			public ResourceNameList()
				: base()
			{
				sorter = new DescriptorSort();
			}

			class DescriptorSort : IComparer<NamedPackedFileDescriptor>
			{
				public DescriptorSort()
				{
					Column = SortColumn.Offset;
					Asc = true;
				}

				public SortColumn Column
				{
					get; set;
				}

				public bool Asc
				{
					get; set;
				}

				#region IComparer<NamedPackedFileDescriptor> Member

				public int Compare(
					NamedPackedFileDescriptor x,
					NamedPackedFileDescriptor y
				)
				{
					if (Asc)
					{
						if (Column == SortColumn.Name)
						{
							return x.GetRealName().CompareTo(y.GetRealName());
						}

						if (Column == SortColumn.Type || Column == SortColumn.Extension)
						{
							return x.Descriptor.Type.CompareTo(y.Descriptor.Type);
						}

						if (Column == SortColumn.Group)
						{
							return x.Descriptor.Group.CompareTo(y.Descriptor.Group);
						}

						if (Column == SortColumn.InstanceHi)
						{
							return x.Descriptor.SubType.CompareTo(y.Descriptor.SubType);
						}

						if (Column == SortColumn.InstanceLo)
						{
							return x.Descriptor.Instance.CompareTo(
								y.Descriptor.Instance
							);
						}

						if (Column == SortColumn.Instance)
						{
							return x.Descriptor.LongInstance.CompareTo(
								y.Descriptor.LongInstance
							);
						}

						if (Column == SortColumn.Offset)
						{
							return x.Descriptor.Offset.CompareTo(y.Descriptor.Offset);
						}

						if (Column == SortColumn.Size)
						{
							return x.Descriptor.Size.CompareTo(y.Descriptor.Size);
						}
					}
					else
					{
						if (Column == SortColumn.Name)
						{
							return y.GetRealName().CompareTo(x.GetRealName());
						}

						if (Column == SortColumn.Type || Column == SortColumn.Extension)
						{
							return y.Descriptor.Type.CompareTo(x.Descriptor.Type);
						}

						if (Column == SortColumn.Group)
						{
							return y.Descriptor.Group.CompareTo(x.Descriptor.Group);
						}

						if (Column == SortColumn.InstanceHi)
						{
							return y.Descriptor.SubType.CompareTo(x.Descriptor.SubType);
						}

						if (Column == SortColumn.InstanceLo)
						{
							return y.Descriptor.Instance.CompareTo(
								x.Descriptor.Instance
							);
						}

						if (Column == SortColumn.Instance)
						{
							return y.Descriptor.LongInstance.CompareTo(
								x.Descriptor.LongInstance
							);
						}

						if (Column == SortColumn.Offset)
						{
							return y.Descriptor.Offset.CompareTo(x.Descriptor.Offset);
						}

						if (Column == SortColumn.Size)
						{
							return y.Descriptor.Size.CompareTo(x.Descriptor.Size);
						}
					}
					return 0;
				}

				#endregion
			}

			public void SortByColumn(SortColumn col, bool asc)
			{
				sorter.Column = col;
				sorter.Asc = asc;
				Sort(sorter);
			}
		}
	}
}
