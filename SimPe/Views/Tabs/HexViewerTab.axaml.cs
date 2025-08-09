// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Platform.Storage;
using AvaloniaHex;
using AvaloniaHex.Document;
using AvaloniaHex.Editing;
using AvaloniaHex.Rendering;


namespace SimPe.Views.Tabs;

public enum HexComboBoxDataType
{
	Data,
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

		DataComboBox.SelectedItem = HexComboBoxDataType.Data;
		Editor[!HexEditor.DocumentProperty] = new Binding("DataDocument");
		Editor.HexView.BytesPerLine = 32;
		CellGroupsLayer layer = Editor.HexView.Layers.Get<CellGroupsLayer>();
		layer.BytesPerGroup = 8;
		layer.Backgrounds.Add(new SolidColorBrush(Colors.Gray, 0.3D));
		layer.Backgrounds.Add(null);
		layer.Border = new Pen(Brushes.Gray, dashStyle: DashStyle.Dash);
		// Editor.Document = new MemoryBinaryDocument((DataContext as Models.Resource.Resource).RawData);
		// HexTextBox[!TextBox.TextProperty] = new Binding("RawDataHexString");
	}

	internal void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
	{
		switch ((HexComboBoxDataType)DataComboBox.SelectedItem)
		{
			case HexComboBoxDataType.Data:
				Editor[!HexEditor.DocumentProperty] = new Binding("DataDocument");
				break;
			case HexComboBoxDataType.UncompressedData:
				Editor[!HexEditor.DocumentProperty] = new Binding("UncompressedDataDocument");
				break;
			case HexComboBoxDataType.UserData:
				Editor[!HexEditor.DocumentProperty] = new Binding("UserDataDocument");
				break;
			default:
				break;
		}
	}

	internal async void ExtractButton_Click(object sender, RoutedEventArgs e)
	{
		// IStorageFile result = await TopLevel.GetTopLevel(this).StorageProvider.SaveFilePickerAsync(new()
		// {
		// 	SuggestedFileName = (DataContext as Models.Resource.Resource).ExportFileName,
		// 	Title = "Extract Data",
		// 	DefaultExtension = $".{(DataContext as Models.Resource.Resource).TypeInfo.Extension}",
		// 	FileTypeChoices = [new FilePickerFileType("Extracted File") { Patterns = [$"*.{(DataContext as Models.Resource.Resource).TypeInfo.Extension}"] }]
		// });
		// if (result != null)
		// {
		// 	using Stream stream = await result.OpenWriteAsync();
		// 	using BinaryWriter writer = new(stream);
		// 	switch ((HexComboBoxDataType)DataComboBox.SelectedItem)
		// 	{
		// 		case HexComboBoxDataType.RawData:
		// 			writer.Write((DataContext as Models.Resource.Resource).RawData);
		// 			break;
		// 		case HexComboBoxDataType.UncompressedData:
		// 			writer.Write((DataContext as Models.Resource.Resource).UncompressedData);
		// 			break;
		// 		case HexComboBoxDataType.UserData:
		// 			writer.Write((DataContext as Models.Resource.Resource).UserData);
		// 			break;
		// 		default:
		// 			break;
		// 	}
		// }
	}
}
