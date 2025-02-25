using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin.UI
{
	/// <summary>
	/// Summary description for HairtonePreferences.
	/// </summary>
	public class HairtonePreferences : PreferencesPanel // System.Windows.Forms.Form // PreferencesPanel //
	{
		private System.Windows.Forms.ComboBox cbDefaultProxy;
		private Panel pnackground;
		private System.Windows.Forms.Label label1;

		public HairtonePreferences()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			this.BuildProxyItemList();
			this.Text = "Hair";
		}

		void BuildProxyItemList()
		{
			Array values = Enum.GetValues(typeof(HairColor));
			this.SuspendLayout();
			int i = -1;
			this.cbDefaultProxy.Items.Add("<unchanged>");
			while (++i < values.Length - 2)
			{
				HairColor key = (HairColor)values.GetValue(i);
				this.cbDefaultProxy.Items.Add(key);
			}
			this.cbDefaultProxy.SelectedIndex = 0;
			this.ResumeLayout();
		}

		protected override void OnSettingsChanged()
		{
			if (this.Settings is HairtoneSettings)
			{
				HairtoneSettings hset = (HairtoneSettings)this.Settings;
				this.SetProxyGuid(hset.DefaultProxy);
			}
		}

		public override void OnCommitSettings()
		{
			if (this.Settings is HairtoneSettings)
			{
				HairtoneSettings hset = (HairtoneSettings)this.Settings;
				if (this.cbDefaultProxy.SelectedIndex == 0)
				{
					hset.DefaultProxy = Guid.Empty;
				}
				else
				{
					object key = this.cbDefaultProxy.SelectedItem;
					hset.DefaultProxy = new Guid(
						Convert.ToUInt32(key),
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0
					);
				}
			}
		}

		void SetProxyGuid(Guid id)
		{
			if (id != Guid.Empty)
			{
				uint index = BitConverter.ToUInt32(id.ToByteArray(), 0); // dirty trick
				if (index < this.cbDefaultProxy.Items.Count)
					this.cbDefaultProxy.SelectedIndex = (int)index;
			}
			else
			{
				this.cbDefaultProxy.SelectedIndex = 0;
			}
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cbDefaultProxy = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pnackground = new System.Windows.Forms.Panel();
			this.pnackground.SuspendLayout();
			this.SuspendLayout();
			//
			// cbDefaultProxy
			//
			this.cbDefaultProxy.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbDefaultProxy.Location = new System.Drawing.Point(40, 58);
			this.cbDefaultProxy.Name = "cbDefaultProxy";
			this.cbDefaultProxy.Size = new System.Drawing.Size(146, 21);
			this.cbDefaultProxy.TabIndex = 13;
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(37, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Proxy for Unbinned colours";
			//
			// pnackground
			//
			this.pnackground.Controls.Add(this.cbDefaultProxy);
			this.pnackground.Controls.Add(this.label1);
			this.pnackground.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnackground.Location = new System.Drawing.Point(0, 0);
			this.pnackground.Name = "pnackground";
			this.pnackground.Size = new System.Drawing.Size(515, 186);
			this.pnackground.TabIndex = 14;
			//
			// HairtonePreferences
			//
			this.ClientSize = new System.Drawing.Size(515, 186);
			this.Controls.Add(this.pnackground);
			this.Name = "HairtonePreferences";
			this.pnackground.ResumeLayout(false);
			this.pnackground.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion
	}
}
