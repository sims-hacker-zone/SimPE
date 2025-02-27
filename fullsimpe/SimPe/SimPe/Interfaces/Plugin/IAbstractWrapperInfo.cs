/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;

namespace SimPe.Interfaces.Plugin
{
	/// <summary>
	/// Summary description for AbstractWrapperInfo.
	/// </summary>
	public class AbstractWrapperInfo : IWrapperInfo
	{

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name">Name of the Wrapper</param>
		/// <param name="author">The Author of the Wrapper</param>
		/// <param name="description">Description of the Wrapper</param>
		/// <param name="version">Version of the Wrapper</param>
		/// <param name="icon">Icon that represents this Resource</param>
		public AbstractWrapperInfo(
			string name,
			string author,
			string description,
			int version,
			System.Drawing.Image icon
		)
		{
			this.Name = name;
			this.Author = author;
			this.Description = description;
			this.Version = version;
			this.Icon = icon;

			IconIndex = -1;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name">Name of the Wrapper</param>
		/// <param name="author">The Author of the Wrapper</param>
		/// <param name="description">Description of the Wrapper</param>
		/// <param name="version">Version of the Wrapper</param>
		public AbstractWrapperInfo(
			string name,
			string author,
			string description,
			int version
		)
			: this(name, author, description, version, null) { }

		#region IWrapperInfor Member
		/// <summary>
		/// The Name of this Wrapper
		/// </summary>
		public string Name
		{
			get; private set;
		}

		/// <summary>
		/// The Description of this Wrapper
		/// </summary>
		public string Description
		{
			get;
		}

		/// <summary>
		/// The Author of this Wrapper
		/// </summary>
		public string Author
		{
			get; private set;
		}

		/// <summary>
		/// The Version of this Wrapper
		/// </summary>
		public int Version
		{
			get;
		}

		/// <summary>
		/// Returns a Icon that should be presented for that resource
		/// </summary>
		public System.Drawing.Image Icon
		{
			get; set;
		}

		/// <summary>
		/// Returns / Setst the Index of the Wrapepr icon in the ImageList of the Registry
		/// </summary>
		/// <remarks>Do nover set this yourself, it is set automatically by the Registry</remarks>
		public int IconIndex
		{
			get; set;
		}

		// <summary>
		/// Returns a Unique ID for this Wrapper
		/// </summary>
		public ulong UID
		{
			get
			{
				uint guid0 = 0;
				foreach (char c in Name)
					guid0 += (byte)c * ((guid0 % 27) + 1);
				foreach (char c in Author)
					guid0 += (byte)c * ((guid0 % 17) + 1);

				uint guid1 = 0;
				foreach (char c in Name)
					guid1 += (byte)c * ((guid1 % 33) + 1);
				foreach (char c in Author)
					guid1 += (byte)c * ((guid1 % 45) + 1);

				uint guid2 = 0;
				foreach (char c in Name)
					guid2 += (byte)c * ((guid2 % 13) + 1);
				foreach (char c in Author)
					guid2 += (byte)c * ((guid2 % 9) + 1);

				uint guid3 = 0;
				foreach (char c in Name)
					guid3 += (byte)c * ((guid3 % 19) + 1);
				foreach (char c in Author)
					guid3 += (byte)c * ((guid3 % 41) + 1);

				return guid0 + (guid1 << 16) + (guid2 << 32) + (guid3 << 48);
			}
		}
		#endregion

		#region IDisposable Member
		public virtual void Dispose()
		{
			if (this.Icon != null)
				Icon.Dispose();
			this.Icon = null;
			this.Name = null;
			this.Author = null;
		}
		#endregion
	}
}
