using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public partial class LastEPusePackedFileUI
		: Windows.Forms.WrapperBaseControl,
			IPackedFileUI
	{
		protected new LastEPusePackedFileWrapper Wrapper => base.Wrapper as LastEPusePackedFileWrapper;
		public LastEPusePackedFileWrapper TPFW => (LastEPusePackedFileWrapper)Wrapper;

		Dictionary<uint, uint> Chap01 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap02 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap03 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap04 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap05 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap06 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap07 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap08 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap09 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap10 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap11 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap12 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap13 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap14 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap15 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap16 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap17 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap18 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap19 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap20 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap21 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap22 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap23 = new Dictionary<uint, uint>();
		Dictionary<uint, uint> Chap24 = new Dictionary<uint, uint>();
		PictureBox pbx;
		Label lbl;

		ushort lastep;
		ushort vergin;
		int mis = 1;

		#region WrapperBaseControl Member

		public LastEPusePackedFileUI()
		{
			InitializeComponent();
			if (PathProvider.Global.GetExpansion(SimPe.Expansions.IslandStories).Exists) // && Helper.WindowsRegistry.LoadOnlySimsStory == 28)
			{
				Wait.Start(117);
				Wait.Message = "Loading Castaway Goals...";
				int ct = 0;
				Chap01.Clear();
				Chap01.Add(5, 0x00010005);
				Chap01.Add(6, 0x00000000); // not used, time to get the hatchet
				Chap01.Add(0xA, 0x00010010);
				Chap01.Add(0x14, 0x00010020);
				Chap01.Add(0x1E, 0x00010030);
				Chap01.Add(0x28, 0x00010040);
				Chap01.Add(0x2D, 0x00010045);
				Chap01.Add(0x32, 0x00010050); // yep
				Chap01.Add(0x3C, 0x00010060);
				Chap01.Add(0x46, 0x00010070); // yep
				Chap01.Add(0x50, 0x00010080); // yep
				Chap02.Clear();
				Chap02.Add(0x0A, 0x00020010);
				Chap02.Add(0x14, 0x00020020);
				Chap02.Add(0x1E, 0x00020030);
				Chap02.Add(0x28, 0x00020040);
				Chap02.Add(0x32, 0x00020050);
				Chap02.Add(0x46, 0x00020060);
				Chap02.Add(0x50, 0x00020070);
				Chap03.Clear();
				Chap03.Add(0x0A, 0x00030010);
				Chap03.Add(0x14, 0x00030020);
				Chap03.Add(0x1E, 0x00030030);
				Chap03.Add(0x21, 0x00030033);
				Chap03.Add(0x25, 0x00030037);
				Chap03.Add(0x28, 0x00030040);
				Chap03.Add(0x32, 0x00030050);
				Chap03.Add(0x3C, 0x00030060);
				Chap03.Add(0x46, 0x00030070);
				Chap03.Add(0x50, 0x00030080);
				Chap04.Clear();
				Chap04.Add(0x0A, 0x00040010);
				Chap04.Add(0x14, 0x00040020);
				Chap04.Add(0x1E, 0x00040030);
				Chap04.Add(0x05, 0x00040035); // not used - 0x28 gets used twice
				Chap04.Add(0x28, 0x00040040);
				Chap04.Add(0x32, 0x00040050);
				Chap04.Add(0x3c, 0x00040060);
				Chap05.Clear();
				Chap05.Add(0x0A, 0x00050010);
				Chap05.Add(0x14, 0x00050020);
				Chap05.Add(0x1E, 0x00050030);
				Chap05.Add(0x28, 0x00050040);
				Chap06.Clear();
				Chap06.Add(0x0A, 0x00060010);
				Chap06.Add(0x14, 0x00060020);
				Chap06.Add(0x1E, 0x00060030);
				Chap06.Add(0x28, 0x00060040);
				Chap07.Clear();
				Chap07.Add(0x0A, 0x00070010);
				Chap07.Add(0x14, 0x00070020);
				Chap07.Add(0x1E, 0x00070030);
				Chap07.Add(0x28, 0x00070040);
				Chap07.Add(0x32, 0x00070050);
				Chap08.Clear();
				Chap08.Add(0x0A, 0x00080010);
				Chap08.Add(0x14, 0x00080020);
				Chap08.Add(0x1E, 0x00080030);
				Chap08.Add(0x28, 0x00080040);
				Chap08.Add(0x32, 0x00080050);
				Chap09.Clear();
				Chap09.Add(0x0A, 0x00090010);
				Chap09.Add(0x14, 0x00090020);
				Chap10.Clear();
				Chap10.Add(0x0A, 0x00100010);
				Chap10.Add(0x14, 0x00100020);
				Chap10.Add(0x1E, 0x00100030);
				Chap10.Add(0x28, 0x00100040);
				Chap11.Clear();
				Chap11.Add(0x0A, 0x00110010);
				Chap11.Add(0x14, 0x00110020);
				Chap11.Add(0x1E, 0x00110030);
				Chap11.Add(0x28, 0x00110040);
				Chap12.Clear();
				Chap12.Add(0x0A, 0x00120010);
				Chap12.Add(0x14, 0x00120020);
				Chap12.Add(0x1E, 0x00120030);
				Chap13.Clear();
				Chap13.Add(0x0A, 0x00130010);
				Chap13.Add(0x14, 0x00130020);
				Chap13.Add(0x1E, 0x00130030);
				Chap13.Add(0x28, 0x00130040);
				Chap13.Add(0x32, 0x00130050);
				Chap14.Clear();
				Chap14.Add(0x0A, 0x00140010);
				Chap14.Add(0x14, 0x00140020);
				Chap14.Add(0x1E, 0x00140030);
				Chap15.Clear();
				Chap15.Add(0x0A, 0x00150010);
				Chap15.Add(0x14, 0x00150020);
				Chap15.Add(0x1E, 0x00150030);
				Chap16.Clear();
				Chap16.Add(0x0A, 0x00160010);
				Chap16.Add(0x14, 0x00160020);
				Chap16.Add(0x1E, 0x00160030);
				Chap17.Clear();
				Chap17.Add(0x0A, 0x00170010);
				Chap17.Add(0x14, 0x00170020);
				Chap17.Add(0x1E, 0x00170030);
				Chap18.Clear();
				Chap18.Add(0x0A, 0x00180010);
				Chap18.Add(0x14, 0x00180020);
				Chap18.Add(0x1E, 0x00180030);
				Chap18.Add(0x28, 0x00180040);
				Chap18.Add(0x32, 0x00180050);
				Chap19.Clear();
				Chap19.Add(0x0A, 0x00190010);
				Chap19.Add(0x14, 0x00190020);
				Chap19.Add(0x1E, 0x00190030);
				Chap19.Add(0x28, 0x00190040);
				Chap19.Add(0x32, 0x00190050);
				Chap19.Add(0x3C, 0x00190060);
				Chap19.Add(0x46, 0x00190070);
				// all thses goal ids are correct but the keys have to be done
				Chap20.Clear();
				Chap20.Add(0x0A, 0x00200010);
				Chap20.Add(0x14, 0x00200020);
				Chap20.Add(0x1E, 0x00200030);
				Chap20.Add(0x28, 0x00200040);
				Chap21.Clear();
				Chap21.Add(0x0A, 0x00210010);
				Chap21.Add(0x14, 0x00210020);
				Chap21.Add(0x1E, 0x00210030);
				Chap22.Clear();
				Chap22.Add(0x0A, 0x00220010);
				Chap22.Add(0x14, 0x00220020);
				Chap22.Add(0x1E, 0x00220030);
				Chap22.Add(0x28, 0x00220040);
				Chap22.Add(0x32, 0x00220050);
				Chap22.Add(0x3C, 0x00220060);
				Chap23.Clear();
				Chap23.Add(0x0A, 0x00230010);
				Chap23.Add(0x14, 0x00230020);
				Chap23.Add(0x1E, 0x00230030);
				Chap23.Add(0x28, 0x00230040);
				Chap23.Add(0x32, 0x00230050);
				Chap24.Clear();
				Chap24.Add(0x0A, 0x00240010); // yep
				Chap24.Add(0x14, 0x00240020);
				Chap24.Add(0x1E, 0x00240030);
				Chap24.Add(0x28, 0x00240040);

				foreach (uint guid in GoalLoader.Goals.Keys) // builds the cache
				{
					GoalInformation gi = GoalInformation.LoadGoal(guid);
					Wait.Progress = ct++;
				}
				Wait.Message = "Saving Cache...";
				GoalInformation.SaveCache();
				Wait.Stop(true);
			}
		}

		protected override void RefreshGUI()
		{
			base.RefreshGUI();

			lastep = Wrapper.Prevep;
			vergin = Wrapper.Vershin;
			previep.Text = "0x" + Helper.HexString(lastep);
			if (lastep == 0)
			{
				if (vergin == 2)
				{
					previep.Text = "The Sims Life Stories";
				}
				else
				{
					previep.Text = "The Sims 2 (Base Game)";
				}
			}
			if (lastep == 1)
			{
				previep.Text = "The Sims 2 University";
			}

			if (lastep == 2)
			{
				previep.Text = "The Sims 2 Nightlife";
			}

			if (lastep == 3)
			{
				previep.Text = "The Sims 2 Business";
			}

			if (lastep == 4)
			{
				previep.Text = "The Sims 2 Family Fun";
			}

			if (lastep == 5)
			{
				previep.Text = "The Sims 2 Glamour Life";
			}

			if (lastep == 6)
			{
				if (vergin == 3)
				{
					previep.Text = "The Sims Pet Stories";
				}
				else
				{
					previep.Text = "The Sims 2 Pets";
				}
			}
			if (lastep == 7)
			{
				if (vergin == 9)
				{
					previep.Text = "The Sims Castaway Stories";
				}
				else
				{
					previep.Text = "The Sims 2 Seasons";
				}
			}
			if (lastep == 8)
			{
				previep.Text = "The Sims 2 Celebration";
			}

			if (lastep == 9)
			{
				previep.Text = "The Sims 2 Fashion";
			}

			if (lastep == 10)
			{
				previep.Text = "The Sims 2 Bon Voyage";
			}

			if (lastep == 11)
			{
				previep.Text = "The Sims 2 Teen Style";
			}

			if (lastep == 12)
			{
				previep.Text = "Sims 2 StoreEdition_old";
			}

			if (lastep == 13)
			{
				previep.Text = "The Sims 2 Freetime";
			}

			if (lastep == 14)
			{
				previep.Text = "The Sims 2 Kitchen & Bath";
			}

			if (lastep == 15)
			{
				previep.Text = "The Sims 2 Ikea Home";
			}

			if (lastep == 16)
			{
				previep.Text = "The Sims 2 Apartment Life";
			}

			if (lastep == 17)
			{
				previep.Text = "Sims 2 Mansion & Garden";
			}
			if (lastep == 31)
			{
				previep.Text = "The Sims 2 Store Edition";
			}

			if (
				PathProvider.Global.GetExpansion(SimPe.Expansions.IslandStories).Exists
				&& Wrapper.GotMore == true
			)
			{
				mis = 1;
				CatawayPnl.Visible = true;
				setChapter(Chap01, 1, "Almost Paradise");
			}
			else
			{
				CatawayPnl.Visible = false;
			}
		}

		public override void OnCommit()
		{
			// base.OnCommit();
			// TPFW.SynchronizeUserData(true, false);
		}
		#endregion

		#region IPackedFileUI Member
		Control IPackedFileUI.GUIHandle => this;
		#endregion

		#region IDisposable Member

		void IDisposable.Dispose()
		{
			this.TPFW.Dispose();
		}
		#endregion

		private void setChapter(Dictionary<uint, uint> dict, int chapter, string headr)
		{
			ClearCastaway(headr);
			int ex = 3;
			int wy = 53;
			chapter--;
			// if (chapter < 0 || chapter > 23) return;
			for (int i = 0; i < 12; i++)
			{
				if (dict.ContainsKey((uint)Wrapper.vdata.GetValue(chapter, i)))
				{
					pbx = new PictureBox();
					pbx.Location = new System.Drawing.Point(ex, wy);
					pbx.Size = new System.Drawing.Size(64, 64);
					lbl = new Label();
					lbl.AutoSize = true;
					lbl.Location = new System.Drawing.Point(ex + 64, wy + 20);
					GoalInformation goll = GoalInformation.LoadGoal(
						dict[(uint)Wrapper.vdata.GetValue(chapter, i)]
					);
					lbl.Text = goll.Name;
					pbx.Image = goll.Icon;
					CatawayPnl.Controls.Add(pbx);
					CatawayPnl.Controls.Add(lbl);
					wy += 64;
					if (wy > CatawayPnl.Height - 64)
					{
						wy = 53;
						ex += 300;
					}
				}
			}
		}

		private void ClearCastaway(string mission)
		{
			CatawayPnl.Controls.Clear();
			lbMission.Text = "(Goals Achieved) " + mission;
			CatawayPnl.Controls.Add(lbMission);
			CatawayPnl.Controls.Add(btfore);
			CatawayPnl.Controls.Add(btBack);
		}

		private void btBack_Click(object sender, EventArgs e)
		{
			if (mis > 1)
			{
				mis -= 1;
			}
			else
			{
				mis = 24;
			}

			SubSetCapter();
		}

		private void btfore_Click(object sender, EventArgs e)
		{
			if (mis < 24)
			{
				mis += 1;
			}
			else
			{
				mis = 1;
			}

			SubSetCapter();
		}

		private void SubSetCapter()
		{
			if (mis == 1)
			{
				setChapter(Chap01, mis, "Almost Paradise");
			}

			if (mis == 2)
			{
				setChapter(Chap02, mis, "I Will Survive");
			}

			if (mis == 3)
			{
				setChapter(Chap03, mis, "Still Haven't Found What I'm Looking For");
			}

			if (mis == 4)
			{
				setChapter(Chap04, mis, "Idol Hands");
			}

			if (mis == 5)
			{
				setChapter(Chap05, mis, "The Eye That Binds");
			}

			if (mis == 6)
			{
				setChapter(Chap06, mis, "A Brand New Day");
			}

			if (mis == 7)
			{
				setChapter(Chap07, mis, "The Shady Lagoon");
			}

			if (mis == 8)
			{
				setChapter(Chap08, mis, "A Class Act");
			}

			if (mis == 9)
			{
				setChapter(Chap09, mis, "You Got Served");
			}

			if (mis == 10)
			{
				setChapter(Chap10, mis, "A Fresh Start");
			}

			if (mis == 11)
			{
				setChapter(Chap11, mis, "A Social Networking Site");
			}

			if (mis == 12)
			{
				setChapter(Chap12, mis, "A Tribal Affair");
			}

			if (mis == 13)
			{
				setChapter(Chap13, mis, "Hot Times");
			}

			if (mis == 14)
			{
				setChapter(Chap14, mis, "Full Court Press");
			}

			if (mis == 15)
			{
				setChapter(Chap15, mis, "Village People");
			}

			if (mis == 16)
			{
				setChapter(Chap16, mis, "Idol Fancy");
			}

			if (mis == 17)
			{
				setChapter(Chap17, mis, "The Cat's Meow");
			}

			if (mis == 18)
			{
				setChapter(Chap18, mis, "Spirit Quest");
			}

			if (mis == 19)
			{
				setChapter(Chap19, mis, "Luau Time");
			}

			if (mis == 20)
			{
				setChapter(Chap20, mis, "Home Is Where The Hut Is");
			}

			if (mis == 21)
			{
				setChapter(Chap21, mis, "The Tides Turn");
			}

			if (mis == 22)
			{
				setChapter(Chap22, mis, "Eruption");
			}

			if (mis == 23)
			{
				setChapter(Chap23, mis, "Let My Love Open The Door");
			}

			if (mis == 24)
			{
				setChapter(Chap24, mis, "The Power Of Love");
			}
		}
	}
}
