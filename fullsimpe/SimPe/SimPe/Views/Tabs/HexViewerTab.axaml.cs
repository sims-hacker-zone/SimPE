// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;

namespace SimPe.Views.Tabs
{
	public enum HexComboBoxDataType
	{
		RawData,
		UncompressedData,
		UserData
	}
	public partial class HexViewerTab : UserControl
	{
		public HexViewerTab()
		{
			InitializeComponent();
			foreach (HexComboBoxDataType item in Enum.GetValues<HexComboBoxDataType>())
			{
				DataComboBox.Items.Add(item);
			}
			DataComboBox.SelectedItem = HexComboBoxDataType.RawData;
			HexTextBox[!TextBox.TextProperty] = new Binding("RawDataHexString");
		}

		internal void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
		{
			switch ((HexComboBoxDataType)DataComboBox.SelectedItem)
			{
				case HexComboBoxDataType.RawData:
					HexTextBox[!TextBox.TextProperty] = new Binding("RawDataHexString");
					break;
				case HexComboBoxDataType.UncompressedData:
					HexTextBox[!TextBox.TextProperty] = new Binding("UncompressedDataHexString");
					break;
				case HexComboBoxDataType.UserData:
					HexTextBox[!TextBox.TextProperty] = new Binding("UserDataHexString");
					break;
				default:
					break;
			}
		}
	}
}
