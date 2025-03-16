// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Threading.Tasks;

namespace SimPe.Forms.MainUI
{
	/// <summary>
	/// Summary description for Message.
	/// </summary>
	public class Message
	{

		public static async Task<MsBox.Avalonia.Enums.ButtonResult> Show(string message)
		{
			return await Show(message, null, MsBox.Avalonia.Enums.ButtonEnum.Ok);
		}

		public static async Task<MsBox.Avalonia.Enums.ButtonResult> Show(string message, string caption)
		{
			return await Show(message, caption, MsBox.Avalonia.Enums.ButtonEnum.Ok);
		}

		public static async Task<MsBox.Avalonia.Enums.ButtonResult> Show(
			string message,
			string caption,
			MsBox.Avalonia.Enums.ButtonEnum mbb
		)
		{
			return await MsBox.Avalonia.MessageBoxManager.GetMessageBoxStandard(caption, message, mbb).ShowAsync();
		}
	}
}
