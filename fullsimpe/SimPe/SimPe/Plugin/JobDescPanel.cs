// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	public partial class JobDescPanel : UserControl
	{
		public JobDescPanel()
		{
			InitializeComponent();
		}

		public string TitleLabel
		{
			get => lbTitle.Text;
			set => lbTitle.Text = value;
		}
		public string TitleValue
		{
			get => tbTitle.Text;
			set => tbTitle.Text = value;
		}

		public string DescLabel
		{
			get => lbDesc.Text;
			set => lbDesc.Text = value;
		}
		public string DescValue
		{
			get => tbDesc.Text;
			set => tbDesc.Text = value;
		}
		/*
        public Size DescSize
        {
            get { return tbDesc.Size; }
            set
            {
                tbDesc.Size = value;
                tbTitle.Width = tbDesc.Width;
            }
        }
        */
		/// <summary>
		/// Raised when the Title text box value changes
		/// </summary>
		public event EventHandler TitleValueChanged;
		public virtual void OnTitleValueChanged(object sender, EventArgs e)
		{
			TitleValueChanged?.Invoke(sender, e);
		}
		private void tbTitle_TextChanged(object sender, EventArgs e)
		{
			OnTitleValueChanged(sender, e);
		}

		/// <summary>
		/// Raised when the Desc text box value changes
		/// </summary>
		public event EventHandler DescValueChanged;
		public virtual void OnDescValueChanged(object sender, EventArgs e)
		{
			DescValueChanged?.Invoke(sender, e);
		}
		private void tbDesc_TextChanged(object sender, EventArgs e)
		{
			OnDescValueChanged(sender, e);
		}
	}
}
