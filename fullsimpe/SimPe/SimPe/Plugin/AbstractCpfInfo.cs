// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.PackedFiles.Cpf;

namespace SimPe.Plugin
{
	public abstract class AbstractCpfInfo
	{
		private Cpf propertySet;

		public Cpf PropertySet
		{
			get => propertySet;
			set => propertySet = value ?? throw new ArgumentNullException(
						"PropertySet",
						"The provided Cpf instance cannot be null"
					);
		}

		public bool Enabled
		{
			get; set;
		}

		public bool HasChanges
		{
			get; set;
		}

		/// <summary>
		/// If pinned, PropertySet cannot be deleted.
		/// </summary>
		public bool Pinned
		{
			get; set;
		}

		#region Lazy properties, use them sparingly

		public RecolorType Type
		{
			get
			{
				RecolorType ret = RecolorType.Unsupported;
				if (propertySet != null)
				{
					try
					{
						ret = (RecolorType)
							Enum.Parse(
								typeof(RecolorType),
								CpfItem("type").StringValue,
								true
							);
					}
					catch { }
				}
				return ret;
			}
		}

		public Guid Family
		{
			get => propertySet != null ? ParseGuidValue(CpfItem("family")) : Guid.Empty;
			set => SetValue("family", value.ToString());
		}

		public string Name
		{
			get => propertySet != null ? CpfItem("name").StringValue : null;
			set => SetValue("name", value);
		}

		#endregion

		protected AbstractCpfInfo()
		{
			Enabled = true;
		}

		public AbstractCpfInfo(Cpf propertySet)
			: this()
		{
			PropertySet = propertySet;
		}

		public bool ContainsItem(string name)
		{
			return propertySet.GetItem(name) != null;
		}

		public CpfItem GetProperty(string name)
		{
			return propertySet?.GetSaveItem(name);
		}

		protected CpfItem CpfItem(string name)
		{
			if (propertySet == null)
			{
				return null;
			}

			CpfItem ret = propertySet.GetItem(name);
			if (ret == null)
			{
				ret = new CpfItem
				{
					Name = name
				};
				propertySet.AddItem(ret);
			}
			return ret;
		}

		public void SetValue(string propertyName, string value)
		{
			if (propertySet != null)
			{
				CpfItem item = CpfItem(propertyName);
				if (item.StringValue != value)
				{
					item.StringValue = value;
					HasChanges = true;
				}
			}
		}

		public void SetValue(string propertyName, uint value)
		{
			if (propertySet != null)
			{
				CpfItem item = CpfItem(propertyName);
				if (item.UIntegerValue != value)
				{
					item.UIntegerValue = value;
					HasChanges = true;
				}
			}
		}

		public void SetValue(string propertyName, float value)
		{
			if (propertySet != null)
			{
				CpfItem item = CpfItem(propertyName);
				if (item.SingleValue != value)
				{
					item.SingleValue = value;
					HasChanges = true;
				}
			}
		}

		public static Guid ParseGuidValue(CpfItem item)
		{
			Guid ret = Guid.Empty;
			if (item != null)
			{
				try
				{
					string guid = item.StringValue;
					if (!Utility.IsNullOrEmpty(guid))
					{
						ret = new Guid(guid);
					}
				}
				catch { }
			}
			return ret;
		}

		public virtual void CommitChanges()
		{
			if (propertySet != null)
			{
				if (Enabled)
				{
					propertySet.SynchronizeUserData();
				}
				else
				{
					if (!Pinned)
					{
						propertySet.FileDescriptor.MarkForDelete = true;
					}
					else
					{
						propertySet.SynchronizeUserData();
					}
				}
			}
		}
	}
}
