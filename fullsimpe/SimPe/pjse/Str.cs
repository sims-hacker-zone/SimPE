// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;

using SimPe.Data;
using SimPe.PackedFiles.Wrapper;

namespace pjse
{
	/// <summary>
	/// Summary description for Str.
	/// </summary>
	public class Str : IDisposable
	{
		private static ArrayList ValidTypes = null;

		static Str()
		{
			FileTypes[] aui = { FileTypes.CTSS, FileTypes.STR, FileTypes.TTAs };
			ValidTypes = new ArrayList(aui);
		}

		public Scope Scope { get; } = Scope.Private;
		public ExtendedWrapper Parent { get; private set; } = null;
		public uint Group { get; } = 0;
		public uint Instance { get; } = 0;
		public FileTypes Type { get; } = 0;

		public Str(Scope scope, ExtendedWrapper parent, uint instance, bool fallback)
			: this(
				scope,
				fallback ? parent : null,
				parent.GroupForScope(scope),
				instance,
				SimPe.Data.FileTypes.STR
			)
		{
		}

		public Str(Scope scope, ExtendedWrapper parent, uint instance)
			: this(
				scope,
				parent,
				parent.GroupForScope(scope),
				instance,
				FileTypes.STR
			)
		{
		}

		public Str(GS.BhavStr instance)
			: this(
				Scope.Private,
				null,
				(uint)pjse.Group.Parsing,
				(uint)instance,
				FileTypes.STR
			)
		{
		}

		public Str(ExtendedWrapper parent, uint instance, FileTypes type)
			: this(Scope.Private, parent, parent.PrivateGroup, instance, type) { }

		protected Str(
			Scope scope,
			ExtendedWrapper parent,
			uint group,
			uint instance,
			FileTypes type
		)
		{
			if (!ValidTypes.Contains(type))
			{
				throw new InvalidOperationException("type must be CTSS, STR# or TTAs");
			}

			Scope = scope;
			Parent = parent;
			Group = group;
			Instance = instance;
			Type = type;
		}

		private static myHT strHashtable = new myHT();

		class myHT : Hashtable, IDisposable
		{
			public myHT()
			{
				FileTable.GFT.FiletableRefresh += new EventHandler(
					GFT_FiletableRefresh
				);
			}

			private Hashtable groupHash = new Hashtable();
			public Str this[uint group, uint instance]
			{
				get => this[group, instance, SimPe.Data.FileTypes.STR];
				set => this[group, instance, SimPe.Data.FileTypes.STR] = value;
			}

			public Str this[uint group, uint instance, FileTypes type]
			{
				get
				{
					Hashtable instanceHash = (Hashtable)groupHash[group];
					if (instanceHash == null)
					{
						return null;
					}

					Hashtable typeHash = (Hashtable)instanceHash[type];
					return typeHash == null ? null : (Str)typeHash[type];
				}
				set
				{
					if (groupHash[group] == null)
					{
						groupHash[group] = new Hashtable();
					}

					Hashtable instanceHash = (Hashtable)groupHash[group];

					if (instanceHash[instance] == null)
					{
						instanceHash[instance] = new Hashtable();
					}

					Hashtable typeHash = (Hashtable)instanceHash[instance];

					if (typeHash[type] != value)
					{
						if (typeHash[type] != null)
						{
							StrWrapper wrapper = ((Str)typeHash[type]).wrapper;
							if (wrapper != null && wrapper.FileDescriptor != null)
							{
								wrapper.FileDescriptor.ChangedData -=
									new SimPe.Events.PackedFileChanged(
										FileDescriptor_ChangedData
									);
							}
						}
						typeHash[type] = value;
						if (typeHash[type] != null)
						{
							StrWrapper wrapper = ((Str)typeHash[type]).wrapper;
							if (wrapper != null && wrapper.FileDescriptor != null)
							{
								wrapper.FileDescriptor.ChangedData +=
									new SimPe.Events.PackedFileChanged(
										FileDescriptor_ChangedData
									);
							}
						}
					}
				}
			}

			private void FileDescriptor_ChangedData(
				SimPe.Interfaces.Files.IPackedFileDescriptor pfd
			)
			{
				if (pfd == null)
				{
					return;
				}

				if (!ValidTypes.Contains(pfd.Type))
				{
					return;
				}

				if (this[pfd.Group, pfd.Instance, pfd.Type] != null)
				{
					this[pfd.Group, pfd.Instance, pfd.Type] = null;
				}
			}

			private void GFT_FiletableRefresh(object sender, EventArgs e)
			{
				foreach (Hashtable iht in groupHash.Values)
				{
					foreach (Hashtable tht in iht.Values)
					{
						foreach (Str s in tht.Values)
						{
							s.Dispose(); // just in case
						}
						tht.Clear();
					}
					iht.Clear();
				}
				groupHash.Clear();
				groupHash = new Hashtable();
			}

			#region IDisposable Members

			public void Dispose()
			{
				GFT_FiletableRefresh(null, null);
				FileTable.GFT.FiletableRefresh -= new EventHandler(
					GFT_FiletableRefresh
				);
			}

			#endregion
		}

		private StrWrapper wrapper = null;
		private StrWrapper Wrapper
		{
			get
			{
				if (wrapper == null)
				{
					FileTable.Entry[] items = FileTable.GFT[
						Type,
						Group,
						Instance
					];

					if (items != null && items.Length != 0)
					{
						wrapper = new StrWrapper();
						wrapper.ProcessData(items[0].PFD, items[0].Package);
						strHashtable[Group, Instance, Type] = this;
					}
				}
				return wrapper;
			}
		}

		private Str semiGlobalStr = null;
		private Str SemiGlobalStr
		{
			get
			{
				if (semiGlobalStr == null)
				{
					semiGlobalStr = new Str(
						Scope.SemiGlobal,
						null,
						Parent.SemiGroup,
						Instance,
						Type
					);
				}

				return semiGlobalStr;
			}
		}

		private Str globalStr = null;
		private Str GlobalStr
		{
			get
			{
				if (globalStr == null)
				{
					globalStr = new Str(
						Scope.Global,
						null,
						Parent.GlobalGroup,
						Instance,
						Type
					);
				}

				return globalStr;
			}
		}

		private bool rejectStrItem(FallbackStrItem fsi)
		{
			return fsi == null || fsi.strItem == null || fsi.strItem.Title.Trim().Length.Equals(0);
		}

		public List<StrItem> this[byte lid]
		{
			get
			{
				StrWrapper w = Wrapper;
				if (Parent != null && Group != Parent.GlobalGroup)
				{
					if (w == null && Group != Parent.SemiGroup && SemiGlobalStr != null)
					{
						w = SemiGlobalStr.Wrapper;
					}

					if (w == null && GlobalStr != null)
					{
						w = GlobalStr.Wrapper;
					}
				}
				return (w == null) ? new List<StrItem>() : w[lid];
			}
		}

		public FallbackStrItem this[int sid] => this[1, sid];

		public FallbackStrItem this[byte lid, int sid]
		{
			get
			{
				FallbackStrItem fsi = new FallbackStrItem();

				if (Group == 0)
				{
					fsi.strItem = null;
					fsi.fallback.Add(
						Localization.GetString("strContext")
					//+ ": " + pjse.Localization.GetString(parent.Context.ToString())
					);
					return fsi;
				}

				if (Wrapper != null)
				{
					fsi.strItem = Wrapper[lid, sid]; // try to find instance/lid/sid at scope
					if (!rejectStrItem(fsi))
					{
						return fsi;
					}

					if (lid != 1)
					{
						fsi.strItem = Wrapper[1, sid]; // try to find instance/1/sid at scope
						if (!rejectStrItem(fsi))
						{
							if (fsi.fallback.Count == 0) // ignore unless this is the first / only fallback
							{
								fsi.lidFallback = true;
							}

							return fsi;
						}
					}
				}

				if (Parent != null)
				{
					if (Group != Parent.GlobalGroup)
					{
						if (Group != Parent.SemiGroup && SemiGlobalStr != null)
						{
							fsi = SemiGlobalStr[lid, sid];
							if (!rejectStrItem(fsi))
							{
								if (fsi.fallback.Count == 0)
								{
									fsi.fallback.Add(
										Localization.GetString("Fallback")
											+ ": "
											+ Localization.GetString("SemiGlobal")
									);
								}

								return fsi;
							}
						}

						if (GlobalStr != null)
						{
							fsi = GlobalStr[lid, sid];
							if (!rejectStrItem(fsi))
							{
								if (fsi.fallback.Count == 0)
								{
									fsi.fallback.Add(
										Localization.GetString("Fallback")
											+ ": "
											+ Localization.GetString("Global")
									);
								}

								return fsi;
							}
						}
					}
				}

				return null;
			}
		}

		public static FallbackStrItem getFallbackStrItem(
			ExtendedWrapper parent,
			uint group,
			uint instance,
			int sid
		)
		{
			return getFallbackStrItem(parent, group, instance, 1, sid);
		}

		public static FallbackStrItem getFallbackStrItem(
			ExtendedWrapper parent,
			uint group,
			uint instance,
			byte lid,
			int sid
		)
		{
			Str str = new Str(parent, group, (FileTypes)instance);
			return str?[lid, sid];
		}

		#region IDisposable Members

		public void Dispose()
		{
			Parent = null;
			wrapper = null;
			semiGlobalStr = null;
			globalStr = null;
		}

		#endregion
	}

	public class FallbackStrItem
	{
		public ArrayList fallback = new ArrayList();
		public bool lidFallback = false;
		public StrItem strItem = null;
	}
}
