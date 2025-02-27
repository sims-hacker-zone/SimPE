using System;
using System.Windows.Forms;

namespace SimPe.Plugin.UI
{
	/// <summary>
	/// Summary description for HairtonePreferences.
	/// </summary>
	public class HairtonePreferences : PreferencesPanel // System.Windows.Forms.Form // PreferencesPanel //
	{
		private ComboBox cbDefaultProxy;
		private Panel pnackground;
		private Label label1;

		public HairtonePreferences()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			BuildProxyItemList();
			Text = "Hair";
		}

		void BuildProxyItemList()
		{
			Array values = Enum.GetValues(typeof(HairColor));
			SuspendLayout();
			int i = -1;
			cbDefaultProxy.Items.Add("<unchanged>");
			while (++i < values.Length - 2)
			{
				HairColor key = (HairColor)values.GetValue(i);
				cbDefaultProxy.Items.Add(key);
			}
			cbDefaultProxy.SelectedIndex = 0;
			ResumeLayout();
		}

		protected override void OnSettingsChanged()
		{
			if (Settings is HairtoneSettings hset)
			{
				SetProxyGuid(hset.DefaultProxy);
			}
		}

		public override void OnCommitSettings()
		{
			if (Settings is HairtoneSettings hset)
			{
				if (cbDefaultProxy.SelectedIndex == 0)
				{
					hset.DefaultProxy = Guid.Empty;
				}
				else
				{
					object key = cbDefaultProxy.SelectedItem;
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
				if (index < cbDefaultProxy.Items.Count)
				{
					cbDefaultProxy.SelectedIndex = (int)index;
				}
			}
			else
			{
				cbDefaultProxy.SelectedIndex = 0;
			}
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			cbDefaultProxy = new ComboBox();
			label1 = new Label();
			pnackground = new Panel();
			pnackground.SuspendLayout();
			SuspendLayout();
			//
			// cbDefaultProxy
			//
			cbDefaultProxy.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbDefaultProxy.Location = new System.Drawing.Point(40, 58);
			cbDefaultProxy.Name = "cbDefaultProxy";
			cbDefaultProxy.Size = new System.Drawing.Size(146, 21);
			cbDefaultProxy.TabIndex = 13;
			//
			// label1
			//
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Location = new System.Drawing.Point(37, 28);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(134, 13);
			label1.TabIndex = 12;
			label1.Text = "Proxy for Unbinned colours";
			//
			// pnackground
			//
			pnackground.Controls.Add(cbDefaultProxy);
			pnackground.Controls.Add(label1);
			pnackground.Dock = DockStyle.Fill;
			pnackground.Location = new System.Drawing.Point(0, 0);
			pnackground.Name = "pnackground";
			pnackground.Size = new System.Drawing.Size(515, 186);
			pnackground.TabIndex = 14;
			//
			// HairtonePreferences
			//
			ClientSize = new System.Drawing.Size(515, 186);
			Controls.Add(pnackground);
			Name = "HairtonePreferences";
			pnackground.ResumeLayout(false);
			pnackground.PerformLayout();
			ResumeLayout(false);
		}
		#endregion
	}
}
