// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe
{
	/// <summary>
	/// Describes Values used to Filter the ResourceView
	/// </summary>
	public class ViewFilter : Windows.Forms.IResourceViewFilter
	{
		/// <summary>
		/// Create a new instance
		/// </summary>
		public ViewFilter()
		{
			doinst = false;
			dogrp = false;

			Active = dogrp || doinst;
		}

		uint inst;
		bool doinst;

		/// <summary>
		/// The Filter Instance
		/// </summary>
		public uint Instance
		{
			get => inst;
			set
			{
				if (inst != value)
				{
					inst = value;
					if (ChangedFilter != null && FilterInstance)
					{
						ChangedFilter(this, new EventArgs());
					}
				}
			}
		}

		/// <summary>
		/// true if you want to filter by Instance
		/// </summary>
		public bool FilterInstance
		{
			get => doinst;
			set
			{
				if (doinst != value)
				{
					doinst = value;
					Active = dogrp || doinst;
					if (ChangedFilter != null)
					{
						ChangedFilter(this, new EventArgs());
					}
				}
			}
		}

		uint grp;
		bool dogrp;

		/// <summary>
		/// The Filter Instance
		/// </summary>
		public uint Group
		{
			get => grp;
			set
			{
				if (grp != value)
				{
					grp = value;
					if (ChangedFilter != null && FilterGroup)
					{
						ChangedFilter(this, new EventArgs());
					}
				}
			}
		}

		/// <summary>
		/// true if you want to filter by Instance
		/// </summary>
		public bool FilterGroup
		{
			get => dogrp;
			set
			{
				if (dogrp != value)
				{
					dogrp = value;
					Active = dogrp || doinst;
					if (ChangedFilter != null)
					{
						ChangedFilter(this, new EventArgs());
					}
				}
			}
		}

		/// <summary>
		/// true, if at least one Filter is active
		/// </summary>
		public bool Active
		{
			get; private set;
		}

		/// <summary>
		/// returns true, if the passed Item should be filtered
		/// </summary>
		public bool IsFiltered(Interfaces.Files.IPackedFileDescriptor pfd)
		{
			if (dogrp)
			{
				if (pfd.Group != grp)
				{
					return true;
				}
			}

			if (doinst)
			{
				if (pfd.Instance != inst)
				{
					return true;
				}
			}

			return false;
		}

		public event EventHandler ChangedFilter;
	}
}
