// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Drawing;

namespace SimPe
{
	/// <summary>
	/// This calass can be used to interface the StatusBar of the Main GUI, which will display
	/// something like the WaitingScreen
	/// </summary>
	public interface IWaitingBarControl
	{
		bool Running
		{
			get;
		}

		string Message
		{
			get; set;
		}

		Image Image
		{
			get; set;
		}

		int MaxProgress
		{
			get; set;
		}

		int Progress
		{
			get; set;
		}

		void Wait();
		void Wait(int max);
		void Stop();

		bool ShowProgress
		{
			get; set;
		}
	}
}
