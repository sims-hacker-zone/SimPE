// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
// $Id: CRCParameters.cs 9 2005-03-20 16:05:29Z ambertation $

#region License
/* ***** BEGIN LICENSE BLOCK *****
 * Version: MPL 1.1
 *
 * The contents of this file are subject to the Mozilla Public License Version
 * 1.1 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS" basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 * The Original Code is Classless.Hasher - C#/.NET Hash and Checksum Algorithm Library.
 *
 * The Initial Developer of the Original Code is Classless.net.
 * Portions created by the Initial Developer are Copyright (C) 2004 the Initial
 * Developer. All Rights Reserved.
 *
 * Contributor(s):
 *		Jason Simeone (jay@classless.net)
 *
 * ***** END LICENSE BLOCK ***** */
#endregion

using System;

namespace Classless.Hasher
{
	/// <summary>A class that contains the parameters necessary to initialize a CRC algorithm.</summary>
	public class CRCParameters : HashAlgorithmParameters
	{
		private int order;

		/// <summary>Gets or sets the order of the CRC (e.g., how many bits).</summary>
		public int Order
		{
			get => order;
			set
			{
				order = ((value % 8) != 0) || (value < 8) || (value > 64)
					? throw new ArgumentOutOfRangeException(
						"Order",
						value,
						"CRC Order must represent full bytes and be between 8 and 64."
					)
					: value;
			}
		}

		/// <summary>Gets or sets the polynomial to use in the CRC calculations.</summary>
		public long Polynomial
		{
			get; set;
		}

		/// <summary>Gets or sets the initial value of the CRC.</summary>
		public long InitialValue
		{
			get; set;
		}

		/// <summary>Gets or sets the final value to XOR with the CRC.</summary>
		public long FinalXORValue
		{
			get; set;
		}

		/// <summary>Gets or sets the value dictating whether or not to reflect the incoming data before calculating. (UART)</summary>
		public bool ReflectInput
		{
			get; set;
		}

		/// <summary>Initializes a new instance of the CRCParamters class.</summary>
		/// <param name="order">The order of the CRC (e.g., how many bits).</param>
		/// <param name="polynomial">The polynomial to use in the calculations.</param>
		/// <param name="initial">The initial value of the CRC.</param>
		/// <param name="finalXOR">The final value to XOR with the CRC.</param>
		/// <param name="reflectIn">Whether or not to reflect the incoming data before calculating.</param>
		public CRCParameters(
			int order,
			long polynomial,
			long initial,
			long finalXOR,
			bool reflectIn
		)
		{
			Order = order;
			Polynomial = polynomial;
			InitialValue = initial;
			FinalXORValue = finalXOR;
			ReflectInput = reflectIn;
		}

		/// <summary>Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.</summary>
		/// <returns>A hash code for the current Object.</returns>
		public override int GetHashCode()
		{
			string temp =
				Polynomial.ToString()
				+ ":"
				+ Order.ToString()
				+ ":"
				+ ReflectInput.ToString();
			return temp.GetHashCode();
		}

		/// <summary>Retrieves a standard set of CRC parameters.</summary>
		/// <param name="standard">The name of the standard parameter set to retrieve.</param>
		/// <returns>The CRC Parameters for the given standard.</returns>
		public static CRCParameters GetParameters(CRCStandard standard)
		{
			CRCParameters temp;

			switch (standard)
			{
				case CRCStandard.CRC8:
					temp = new CRCParameters(8, 0xE0, 0, 0, false);
					break;
				case CRCStandard.CRC8_REVERSED:
					temp = new CRCParameters(8, 0x07, 0, 0, true);
					break;
				case CRCStandard.CRC16:
					temp = new CRCParameters(16, 0x8005, 0, 0, false);
					break;
				case CRCStandard.CRC16_REVERSED:
					temp = new CRCParameters(16, 0xA001, 0, 0, true);
					break;
				case CRCStandard.CRC16_CCITT:
					temp = new CRCParameters(16, 0x1021, 0xFFFF, 0, false);
					break;
				case CRCStandard.CRC16_CCITT_REVERSED:
					temp = new CRCParameters(16, 0x8408, 0, 0, true);
					break;
				case CRCStandard.CRC16_ARC:
					temp = new CRCParameters(16, 0x8005, 0, 0, true);
					break;
				case CRCStandard.CRC16_ZMODEM:
					temp = new CRCParameters(16, 0x1021, 0, 0, false);
					break;
				case CRCStandard.CRC24:
					temp = new CRCParameters(24, 0x1864CFB, 0xB704CE, 0, false);
					break;
				case CRCStandard.CRC32:
					temp = new CRCParameters(
						32,
						0xEDB88320,
						0xFFFFFFFF,
						0xFFFFFFFF,
						false
					);
					break;
				case CRCStandard.CRC32_REVERSED:
					temp = new CRCParameters(
						32,
						0x04C11DB7,
						0xFFFFFFFF,
						0xFFFFFFFF,
						true
					);
					break;
				case CRCStandard.CRC32_JAMCRC:
					temp = new CRCParameters(32, 0x04C11DB7, 0xFFFFFFFF, 0, true);
					break;
				case CRCStandard.CRC32_BZIP2:
					temp = new CRCParameters(
						32,
						0x04C11DB7,
						0xFFFFFFFF,
						0xFFFFFFFF,
						false
					);
					break;
				case CRCStandard.CRC32_CAS:
					temp = new CRCParameters(32, 0xEDB88320, 0, 0xFFFFFFFF, false);
					break;
				default:
					temp = new CRCParameters(
						32,
						0x04C11DB7,
						0xFFFFFFFF,
						0xFFFFFFFF,
						true
					);
					break;
			}
			// (32, 0x04C11DB7, 0xffffffff, 0, false)
			return temp;
		}
	}
}
