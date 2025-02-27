using System;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public partial class LoteUI : Windows.Forms.WrapperBaseControl, IPackedFileUI
	{
		protected new Lot Wrapper => base.Wrapper as Lot;
		public Lot TPFW => Wrapper;

		#region WrapperBaseControl Member

		public LoteUI()
		{
			InitializeComponent();

			cbtype.Items.Clear();
			cbtype.Items.Add(Ltxt.LotType.Unknown);
			cbtype.Items.Add(Ltxt.LotType.Residential);
			cbtype.Items.Add(Ltxt.LotType.Community);
			if (PathProvider.Global.EPInstalled > 0)
			{
				cbtype.Items.Add(Ltxt.LotType.Dorm);
				cbtype.Items.Add(Ltxt.LotType.GreekHouse);
				cbtype.Items.Add(Ltxt.LotType.SecretSociety);
			}
			if (PathProvider.Global.EPInstalled > 9)
			{
				cbtype.Items.Add(Ltxt.LotType.Hotel);
				cbtype.Items.Add(Ltxt.LotType.SecretHoliday);
			}
			if (PathProvider.Global.EPInstalled > 11)
			{
				cbtype.Items.Add(Ltxt.LotType.Hobby);
			}
			if (PathProvider.Global.EPInstalled > 15)
			{
				cbtype.Items.Add(Ltxt.LotType.ApartmentBase);
				cbtype.Items.Add(Ltxt.LotType.ApartmentSublot);
				cbtype.Items.Add(Ltxt.LotType.Witches);
			}
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();
			reddy = false;

			cbtype.SelectedIndex = cbtype.Items.Contains(Wrapper.Type) ? cbtype.Items.IndexOf(Wrapper.Type) : 0;

			string Descrpty = Wrapper.LotDesc.Length < 2 ? "  -None Included-" : Wrapper.LotDesc;

			string classy = "";
			string flagery = Convert.ToString(Wrapper.Unknown0);
			Boolset bby = Wrapper.Unknown0;
			if (bby[7])
			{
				flagery += " -(has a beach)";
			}

			if (bby[4])
			{
				flagery += " -(hidden)";
			}

			if (bby[12])
			{
				classy = "\r\n Low Class";
			}
			else if (bby[13])
			{
				classy = "\r\n Medium Class";
			}
			else if (bby[14])
			{
				classy = "\r\n High Class";
			}

			string rotat = "to the Left";
			if (Wrapper.LotRotation == 1)
			{
				rotat = "to the Top";
			}

			if (Wrapper.LotRotation == 3)
			{
				rotat = "to the Right";
			}

			if (Wrapper.LotRotation == 4)
			{
				rotat = "to the Bottom";
			}

			byte rode = Wrapper.LotRoads;
			string roads = "";
			if (rode == 0)
			{
				roads = " gone, it has no Road";
			}
			else
			{
				if (rode >= 8)
				{
					rode -= 8;
					roads = " on the Bottom";
				}
				if (rode >= 4)
				{
					rode -= 4;
					roads += " on the Right";
				}
				if (rode >= 2)
				{
					rode -= 2;
					roads += " on the Top";
				}
				if (rode >= 1)
				{
					roads += " on the Left";
				}
			}

			rtLotDef.Text =
				Wrapper.LotName
				+ " is a "
				+ Enum.GetName(typeof(Ltxt.LotType), Wrapper.Type)
				+ " Lot\r\n\r\n"
				+ "It is "
				+ Convert.ToString(Wrapper.LotSize.Width)
				+ " wide by "
				+ Convert.ToString(Wrapper.LotSize.Height)
				+ " deep.\r\n\r\n"
				+ "Description:\r\n"
				+ Descrpty
				+ classy;
			rtLotDef.Text += "\r\n\r\n" + Wrapper.LotName + "'s flags are " + flagery;
			rtLotDef.Text += "\r\n" + Wrapper.LotName + "'s Rotation is " + rotat;
			rtLotDef.Text += "\r\n" + Wrapper.LotName + "'s Roads are" + roads;

			reddy = true;
		}

		internal bool reddy = false;

		public override void OnCommit()
		{
			base.OnCommit();
			TPFW.SynchronizeUserData(true, false);
		}
		#endregion

		#region IPackedFileUI Member
		System.Windows.Forms.Control IPackedFileUI.GUIHandle => this;
		#endregion

		#region IDisposable Member

		void IDisposable.Dispose()
		{
			TPFW.Dispose();
		}
		#endregion

		private void cbtype_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (reddy == false)
			{
				return;
			}

			Wrapper.Type = Enum.IsDefined(typeof(Ltxt.LotType), cbtype.SelectedItem) ? (Ltxt.LotType)cbtype.SelectedItem : Ltxt.LotType.Unknown;

			RefreshGUI();
		}
	}
}
