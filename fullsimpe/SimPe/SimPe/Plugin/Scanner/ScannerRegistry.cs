// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.Interfaces.Plugin.Scanner;

namespace SimPe.Plugin.Scanner
{
	/// <summary>
	/// This is a Registry , that contains all available Scanners and Identifiers
	/// </summary>
	public class ScannerRegistry
	{
		public static ScannerRegistry Global { get; } = new ScannerRegistry();

		private ScannerRegistry()
		{
		}

		public SortedSet<IScanner> Scanners
		{
			get;
		} = new SortedSet<IScanner>(new Identifiers.PluginScannerBaseComparer())
		{
			new NameScanner(),
			new ImageScanner(),
			new GuidScanner(),
			new CompressionScanner(),
			new ShelveScanner(),
			new EPReadyScanner(),
			new ClothingScanner(),
			new NeighborhoodScanner(),
			new SkinScanner(),
			new MeshScanner(),
			new RecolorBasemeshScanner(),
		};

		public SortedSet<IIdentifier> Identifiers
		{
			get;
		} = new SortedSet<IIdentifier>(new Identifiers.PluginScannerBaseComparer())
		{
			new Identifiers.CepIdentifier(),
			new Identifiers.ReColorIdentifier(),
			new Identifiers.SimIdentifier(),
			new Identifiers.CpfIdentifier(),
			new NeighborhoodIdentifier(),
			new Identifiers.ObjectIdentifier()
		};
	}
}
