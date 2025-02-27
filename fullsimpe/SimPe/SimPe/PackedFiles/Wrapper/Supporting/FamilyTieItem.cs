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

using SimPe.Data;

namespace SimPe.PackedFiles.Wrapper.Supporting
{
	/// <summary>
	/// This Class handles the instance -> Name assignemnet
	/// </summary>
	public class FamilyTieCommon
	{
		/// <summary>
		/// The Parent Wrapper
		/// </summary>
		protected FamilyTies famt;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="siminstance">Instance of the Sim</param>
		/// <param name="famt">The Parent Wrapper</param>
		public FamilyTieCommon(ushort siminstance, FamilyTies famt)
		{
			this.siminstance = siminstance;
			this.famt = famt;
			sdesc = null;
		}

		/// <summary>
		/// The instance of the Target sim
		/// </summary>
		protected ushort siminstance;

		/// <summary>
		/// Returns / Sets the Instance of the Target Sim
		/// </summary>
		public ushort Instance
		{
			get => siminstance;
			set
			{
				if (siminstance != value)
				{
					sdesc = null;
				}

				siminstance = value;
			}
		}

		/// <summary>
		/// name of the sim
		/// </summary>
		protected SDesc sdesc;

		/// <summary>
		/// Loads the Description File for a Sim
		/// </summary>
		protected void LoadSDesc()
		{
			if (sdesc == null)
			{
				sdesc = new SDesc(famt.NameProvider, null, null);

				try
				{
					Interfaces.Files.IPackedFileDescriptor pfd =
						famt.Package.FindFile(
							MetaData.SIM_DESCRIPTION_FILE,
							0,
							famt.FileDescriptor.Group,
							siminstance
						);
					sdesc.ProcessData(pfd, famt.Package);
				}
				catch (Exception) { }
			}
		}

		/// <summary>
		/// Returns the Name of the sim
		/// </summary>
		public string SimName
		{
			get
			{
				LoadSDesc();
				return sdesc.SimName;
			}
		}

		public SDesc SimDescription
		{
			get
			{
				LoadSDesc();
				return sdesc;
			}
		}

		/// <summary>
		/// Returns the Name of the sim
		/// </summary>
		public string SimFamilyName
		{
			get
			{
				LoadSDesc();
				return sdesc.SimFamilyName;
			}
		}

		/// <summary>
		/// Overrides the default ToString Method
		/// </summary>
		/// <returns>A String describing the Object</returns>
		public override string ToString()
		{
			return SimName
				+ " "
				+ SimFamilyName
				+ " (0x"
				+ Helper.HexString(siminstance)
				+ ")";
		}
	}

	/// <summary>
	/// A Sim that is stored within a FamilyTie File
	/// </summary>
	public class FamilyTieSim : FamilyTieCommon
	{

		/// <summary>
		/// Constructor for a new participation sim
		/// </summary>
		/// <param name="siminstance">Instance of the Sim</param>
		/// <param name="ties">the ties he perticipates in</param>
		/// <param name="famt">The Parent Wrapper</param>
		public FamilyTieSim(
			ushort siminstance,
			FamilyTieItem[] ties,
			FamilyTies famt
		)
			: base(siminstance, famt)
		{
			Ties = ties;
			BlockDelimiter = 0x00000001;
		}

		/// <summary>
		/// Returns / Sets the ties he perticipates in
		/// </summary>
		public FamilyTieItem[] Ties
		{
			get; set;
		}

		/// <summary>
		/// Returns / Sets the Block Delimiter
		/// </summary>
		internal int BlockDelimiter
		{
			get; set;
		}

		/// <summary>
		/// Returns the avaqilable <see cref="FamilyTieItem"/> for the passed Sim
		/// </summary>
		/// <param name="sdsc"></param>
		/// <returns>null or the <see cref="FamilyTieItem"/> for that Sim</returns>
		public FamilyTieItem FindTie(SDesc sdsc)
		{
			if (sdsc == null)
			{
				return null;
			}

			foreach (FamilyTieItem s in Ties)
			{
				if (s.Instance == sdsc.Instance)
				{
					return s;
				}
			}

			return null;
		}

		/// <summary>
		/// Returns the available <see cref="FamilyTieItem"/> for the Sim, or creates a new One
		/// </summary>
		/// <param name="sdsc"></param>
		/// <returns>the <see cref="FamilyTieItem"/> for the passed Sim</returns>
		public FamilyTieItem CreateTie(SDesc sdsc, MetaData.FamilyTieTypes type)
		{
			FamilyTieItem s = FindTie(sdsc);
			if (s == null)
			{
				s = new FamilyTieItem(type, sdsc.Instance, famt);
				Ties = (FamilyTieItem[])Helper.Add(Ties, s);
			}
			s.Type = type;
			return s;
		}

		/// <summary>
		/// Remove the passed Family Tie
		/// </summary>
		/// <param name="fti"></param>
		/// <returns>true, if the Tie was removed</returns>
		public bool RemoveTie(FamilyTieItem fti)
		{
			int len = Ties.Length;
			Ties = (FamilyTieItem[])Helper.Delete(Ties, fti);
			return Ties.Length < len;
		}
	}

	/// <summary>
	/// Contains one FamilyTie
	/// </summary>
	public class FamilyTieItem : FamilyTieCommon
	{

		/// <summary>
		/// Creates a new FamilyTie
		/// </summary>
		/// <param name="type">The Type of the tie</param>
		/// <param name="siminstance">The instance of the Target sim</param>
		/// <param name="famt">The Parent Wrapper</param>
		public FamilyTieItem(
			MetaData.FamilyTieTypes type,
			ushort siminstance,
			FamilyTies famt
		)
			: base(siminstance, famt)
		{
			Type = type;
		}

		/// <summary>
		/// Returns / Sets the Type of the Tie
		/// </summary>
		public MetaData.FamilyTieTypes Type
		{
			get; set;
		}

		/// <summary>
		/// Overrides the default ToString Method
		/// </summary>
		/// <returns>A String describing the Object</returns>
		public override string ToString()
		{
			return ((LocalizedFamilyTieTypes)Type).ToString() + ": " + base.ToString();
		}
	}
}
