using System;
using System.Windows.Forms;

namespace pjHoodTool
{
	public partial class Settims : Form
	{
		internal SimPe.XmlRegistryKey xrk = SimPe
			.Helper
			.WindowsRegistry
			.PluginRegistryKey;
		string[] noo = new string[13]
		{
			"1",
			",1",
			",1",
			",1",
			",1",
			",1",
			",1",
			",1",
			",1",
			",1",
			",1",
			",1",
			",.txt",
		}; //default values
		bool dun = true; // dummy variable, never actually used - always true

		public Settims()
		{
			InitializeComponent();

			//SimPe.GetImage.Loadimges(this.simLogo, SimPe.PathProvider.Global.Latest.Version);
			//this.simLogo.Run = true;

			dun = Settings; // Load settings
			cbshowbasic.Checked = cHoodTool.incbas;
			cbshowinterests.Checked = cHoodTool.incint;
			cbshowcharacter.Checked = cHoodTool.inccha;
			cbshowskills.Checked = cHoodTool.incski;
			cbshowuniversity.Checked = cHoodTool.incuni;
			cbshowfreetime.Checked = cHoodTool.incfre;
			cbshowapartments.Checked = cHoodTool.incapa;
			cbshownpcs.Checked = !cHoodTool.incnpc;
			cbshowdesc.Checked = cHoodTool.incdes;
			cbshowpets.Checked = cHoodTool.incpet;
			cbshowbusi.Checked = cHoodTool.incbus;
			cbExcludeLots.Checked = !cHoodTool.inclot;
			rbcsv.Checked = cHoodTool.outptype == ".csv";
		}

		private void btdoned_Click(object sender, EventArgs e)
		{
			cHoodTool.incbas = cbshowbasic.Checked;
			cHoodTool.incint = cbshowinterests.Checked;
			cHoodTool.inccha = cbshowcharacter.Checked;
			cHoodTool.incski = cbshowskills.Checked;
			cHoodTool.incuni = cbshowuniversity.Checked;
			cHoodTool.incfre = cbshowfreetime.Checked;
			cHoodTool.incapa = cbshowapartments.Checked;
			cHoodTool.incnpc = !cbshownpcs.Checked;
			cHoodTool.incdes = cbshowdesc.Checked;
			cHoodTool.incpet = cbshowpets.Checked;
			cHoodTool.incbus = cbshowbusi.Checked;
			cHoodTool.inclot = !cbExcludeLots.Checked;
			cHoodTool.outptype = rbcsv.Checked ? ".csv" : ".txt";

			Settings = dun; // Save settings
			Close();
		}

		internal bool Settings
		{
			get
			{
				if (
					!SimPe
						.PathProvider.Global.GetExpansion(SimPe.Expansions.University)
						.Exists
				)
				{
					noo[4] = ",0";
				}

				if (
					!SimPe
						.PathProvider.Global.GetExpansion(SimPe.Expansions.Business)
						.Exists
				)
				{
					noo[5] = ",0";
				}

				if (
					!SimPe
						.PathProvider.Global.GetExpansion(SimPe.Expansions.FreeTime)
						.Exists
				)
				{
					noo[6] = ",0";
				}

				if (
					!SimPe
						.PathProvider.Global.GetExpansion(SimPe.Expansions.Apartments)
						.Exists
				)
				{
					noo[7] = ",0"; // complete set default values
				}

				string temp = ""; // default settings, if no SavedValue then temp is used
				foreach (string s in noo)
				{
					temp += s;
				}
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						"PJSE\\HoodTool"
					);
				object o = rkf.GetValue("SavedValue", temp);
				string[] now = Convert.ToString(o).Split(",".ToCharArray());
				cHoodTool.incbas = now[0] == "1";
				cHoodTool.incint = now[1] == "1";
				cHoodTool.inccha = now[2] == "1";
				cHoodTool.incski = now[3] == "1";
				cHoodTool.incuni = now[4] == "1";
				cHoodTool.incfre = now[5] == "1";
				cHoodTool.incapa = now[6] == "1";
				cHoodTool.incnpc = now[7] == "1";
				cHoodTool.incdes = now[8] == "1";
				cHoodTool.incpet = now[9] == "1";
				cHoodTool.incbus = now[10] == "1";
				cHoodTool.inclot = now[11] == "1";
				cHoodTool.outptype = now[12];
				return true;
			}
			set
			{
				string temp = cbshowbasic.Checked ? "1" : "0";

				if (cbshowinterests.Checked)
				{
					temp += ",1";
				}
				else
				{
					temp += ",0";
				}

				if (cbshowcharacter.Checked)
				{
					temp += ",1";
				}
				else
				{
					temp += ",0";
				}

				if (cbshowskills.Checked)
				{
					temp += ",1";
				}
				else
				{
					temp += ",0";
				}

				if (cbshowuniversity.Checked)
				{
					temp += ",1";
				}
				else
				{
					temp += ",0";
				}

				if (cbshowfreetime.Checked)
				{
					temp += ",1";
				}
				else
				{
					temp += ",0";
				}

				if (cbshowapartments.Checked)
				{
					temp += ",1";
				}
				else
				{
					temp += ",0";
				}

				if (cbshownpcs.Checked)
				{
					temp += ",0";
				}
				else
				{
					temp += ",1"; // checking switches off
				}

				if (cbshowdesc.Checked)
				{
					temp += ",1";
				}
				else
				{
					temp += ",0";
				}

				if (cbshowpets.Checked)
				{
					temp += ",1";
				}
				else
				{
					temp += ",0";
				}

				if (cbshowbusi.Checked)
				{
					temp += ",1";
				}
				else
				{
					temp += ",0";
				}

				if (cbExcludeLots.Checked)
				{
					temp += ",0";
				}
				else
				{
					temp += ",1"; // checking switches off
				}

				if (rbcsv.Checked)
				{
					temp += ",.csv";
				}
				else
				{
					temp += ",.txt";
				}

				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						"PJSE\\HoodTool"
					);
				rkf.SetValue("SavedValue", temp);
			}
		}
	}
}
