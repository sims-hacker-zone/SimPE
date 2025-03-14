// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace System.Windows.Forms
{
	public partial class pjseMsgBox : Form
	{
		// public pjseMsgBox() : this("", "", "001", null, null, null) { }

		private pjseMsgBox(
			string text,
			string caption,
			Boolset buttonsVisible,
			Boolset bsBtns,
			string[] sBtns,
			DialogResult[] adr
		)
		{
			InitializeComponent();

			tbMessage.Text = text;
			Text = caption;

			if (buttonsVisible.Length < 3)
			{
				throw new ArgumentException(
					"need three (or more) flags",
					"buttonsVisible"
				);
			}

			//button1.Visible = buttonsVisible[0];
			//button2.Visible = buttonsVisible[1];
			//button3.Visible = buttonsVisible[2];
			if (!buttonsVisible[0])
			{
				tlpButtons.Controls.Remove(button1);
			}

			if (!buttonsVisible[1])
			{
				tlpButtons.Controls.Remove(button2);
			}

			if (!buttonsVisible[2])
			{
				tlpButtons.Controls.Remove(button3);
			}

			if (bsBtns != null && sBtns != null)
			{
				if (bsBtns.Length >= 1 && sBtns.Length >= 1 && bsBtns[0])
				{
					button1.Text = sBtns[0];
				}

				if (bsBtns.Length >= 2 && sBtns.Length >= 2 && bsBtns[1])
				{
					button2.Text = sBtns[1];
				}

				if (bsBtns.Length >= 3 && sBtns.Length >= 3 && bsBtns[2])
				{
					button3.Text = sBtns[2];
				}
			}
			if (adr != null)
			{
				if (bsBtns.Length >= 1 && adr.Length >= 1 && bsBtns[0])
				{
					button1.DialogResult = adr[0];
				}

				if (bsBtns.Length >= 2 && adr.Length >= 2 && bsBtns[1])
				{
					button2.DialogResult = adr[1];
				}

				if (bsBtns.Length >= 3 && adr.Length >= 3 && bsBtns[2])
				{
					button3.DialogResult = adr[2];
				}
			}
			else
			{
				button1.DialogResult = DialogResult.OK;
				button2.DialogResult = DialogResult.Cancel;
				button3.DialogResult = DialogResult.None;
			}

			int x = Convert.ToInt32((Width - tlpButtons.Width) / 2);
			tlpButtons.Left = x;

			AcceptButton = CancelButton = null;
			foreach (Button b in new Button[] { button1, button2, button3 })
			{
				if (b.DialogResult == DialogResult.OK)
				{
					AcceptButton = b;
				}

				if (b.DialogResult == DialogResult.Cancel)
				{
					CancelButton = b;
				}
			}
		}

		/// <summary>
		/// Displays a message box in front of the specified object and with specified text, caption, and buttons.
		/// </summary>
		/// <param name="owner">An implementation of System.Windows.Forms.IWin32Window that will own the modal dialog box.</param>
		/// <param name="text">The text to display in the message box.</param>
		/// <param name="caption">The text to display in the title bar of the message box.</param>
		/// <param name="buttonsVisible">A Boolset of flags specifying which buttons should be visible.</param>
		/// <param name="buttonsOverride">A Boolset of flags specifying which buttons should be overriden from buttons.</param>
		/// <param name="buttons">Text for button faces</param>
		/// <param name="resultSet">DialogResult values for buttons</param>
		/// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
		/// <exception cref="ArgumentException">buttonsVisible must contain at least three flags</exception>
		public static DialogResult Show(
			IWin32Window owner,
			string text,
			string caption,
			Boolset buttonsVisible,
			Boolset buttonsOverride,
			string[] buttons,
			DialogResult[] resultSet
		)
		{
			return
				new pjseMsgBox(
					text,
					caption,
					buttonsVisible,
					buttonsOverride,
					buttons,
					resultSet
				)
			.ShowDialog(owner);
		}
	}
}
