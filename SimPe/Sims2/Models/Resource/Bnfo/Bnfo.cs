// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Extensions;
using SimPe.Sims2.Views.Resource.Bnfo;

namespace SimPe.Sims2.Models.Resource.Bnfo;

public partial class Bnfo(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	[ObservableProperty] private EnumDisplayNameItem<BnfoVersion> version;

	[ObservableProperty] private uint currentBusinessState;

	[ObservableProperty] private uint highestBusinessState;

	[ObservableProperty] private uint unknown_00;

	[ObservableProperty] private float unknown_01;

	[ObservableProperty] private uint unknown_02;

	[ObservableProperty] private ObservableCollection<BnfoCustomer> customers = [];

	[ObservableProperty] private ObservableCollection<BnfoEmployee> employees = [];

	[ObservableProperty] private ObservableCollection<BnfoHistory> histories = [];

	[ObservableProperty] private uint unknown_03;

	public UserControl Panel { get; set; }

	public string FriendlyName => null;

	public static Bnfo Unserialize(BinaryReader reader, Resource file)
	{
		Bnfo bnfo = new(file)
		{
			Version = new((BnfoVersion)reader.ReadUInt32()),
			CurrentBusinessState = reader.ReadUInt32(),
			HighestBusinessState = reader.ReadUInt32(),
			Unknown_00 = reader.ReadUInt32(),
			Unknown_01 = reader.ReadSingle(),
			Unknown_02 = reader.ReadUInt32()
		};
		uint customerCount = reader.ReadUInt32();
		for (int i = 0; i < customerCount; i++)
		{
			bnfo.Customers.Add(BnfoCustomer.Unserialize(reader, bnfo));
		}

		uint employeeCount = reader.ReadUInt32();
		for (int i = 0; i < employeeCount; i++)
		{
			bnfo.Employees.Add(BnfoEmployee.Unserialize(reader, bnfo));
		}

		uint historyCount = reader.ReadUInt32();
		for (int i = 0; i < historyCount; i++)
		{
			bnfo.Histories.Add(BnfoHistory.Unserialize(reader, bnfo));
		}

		bnfo.Unknown_03 = reader.ReadUInt32();
		bnfo.Panel = new BnfoPanel() { DataContext = bnfo };
		return bnfo;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write((uint)Version.Item);
		writer.Write(CurrentBusinessState);
		writer.Write(HighestBusinessState);
		writer.Write(Unknown_00);
		writer.Write(Unknown_01);
		writer.Write(Unknown_02);
		writer.Write(Customers.Count);
		foreach (BnfoCustomer item in Customers)
		{
			item.Serialize(writer);
		}

		writer.Write(Employees.Count);
		foreach (BnfoEmployee item in Employees)
		{
			item.Serialize(writer);
		}

		writer.Write(Histories.Count);
		foreach (BnfoHistory item in Histories)
		{
			item.Serialize(writer);
		}

		writer.Write(Unknown_03);
	}
}
