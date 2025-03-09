// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Data;
using SimPe.PackedFiles.Sdsc;

namespace SimPe.PackedFiles.Famt
{
	/// <summary>
	/// This Class handles the instance -> Name assignemnet
	/// </summary>
	public class FamilyTieCommon
	{
		/// <summary>
		/// The Parent Wrapper
		/// </summary>
		protected Famt famt;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="siminstance">Instance of the Sim</param>
		/// <param name="famt">The Parent Wrapper</param>
		public FamilyTieCommon(ushort siminstance, Famt famt)
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
							FileTypes.SDSC,
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
}
