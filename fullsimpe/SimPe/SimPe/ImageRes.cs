// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;
using System.IO;

namespace SimPe
{
	/// <summary>
	/// Various Images
	/// This is where the Larger Icons are.
	/// </summary>
	public class GetImage
	{
		/// <summary>
		/// Sim Image (missing)
		/// </summary>
		public static Image NoOne => Properties.Resources.noone;

		/// <summary>
		/// Sim Image (missing)
		/// </summary>
		public static Image SheOne => Properties.Resources.sheone;

		/// <summary>
		/// Tool Box Image
		/// </summary>
		public static Image Network => Properties.Resources.network;

		/// <summary>
		/// Tool Box Image
		/// </summary>
		public static Image Demo => Properties.Resources.demo;

		/// <summary>
		/// Tool Box Image
		/// </summary>
		public static Image Cassie => Properties.Resources.CAF;

		/// <summary>
		///  Used in Last EP used and EP Selecter
		/// </summary>
		public static Image GetExpansionLogo(int ep)
		{
			// This is used by the EP selecter which may display the logo for an EP that SimPe sees as not installed.
			if ((ep > 19 && ep < 28) || ep > 30)
			{
				ep = 0; // Store doesn't have a logo, there is no EPs between Store (20) and Castaway Story (28) - Return base game Logo
			}

			ExpansionItem ei = PathProvider.Global.GetExpansion(ep);
			if (ei.InstalledPath(ep) == null)
			{
				return null;
			}

			Packages.File pkg = Packages.File.LoadFromFile(
				ei.InstalledPath(ep) + "\\TSData\\Res\\UI\\ui.package"
			);
			if (pkg != null)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(
					0x856DDBAC,
					0,
					0x499DB772,
					0x8CBB9323
				);
				if (pfd != null)
				{
					// TODO Uncomment when circular dependencies are sorted out.
					// SimPe.PackedFiles.Wrapper.Picture pic = new SimPe.PackedFiles.Wrapper.Picture();
					// pic.ProcessData(pfd, pkg);
					// return pic.Image;
					return null;
				}
			}
			return null;
		}

		/// <summary>
		///  Used in LotCompressor
		/// </summary>
		public static Image GetExpansionIcon(byte ep)
		{
			uint inst = 0xABBB0000 + ep; // 0xABBB0000  0xABBAFFFF
			Packages.File pkg = Packages.File.LoadFromFile(
				Path.Combine(
					PathProvider.Global.Latest.InstallFolder,
					"TSData\\Res\\UI\\ui.package"
				)
			);
			if (pkg != null)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(
					0x856DDBAC,
					0,
					0x499DB772,
					inst
				);
				if (pfd != null)
				{
					// TODO Uncomment when circular dependencies are sorted out.
					// SimPe.PackedFiles.Wrapper.Picture pic = new SimPe.PackedFiles.Wrapper.Picture();
					// pic.ProcessData(pfd, pkg);
					// return pic.Image;
					return null;
				}
			}
			if (
				Directory.Exists(
					Path.Combine(PathProvider.SimSavegameFolder, "Downloads")
				)
			)
			{
				string[] files = Directory.GetFiles(
					Path.Combine(PathProvider.SimSavegameFolder, "Downloads"),
					"Bodyshape Icons.package",
					SearchOption.AllDirectories
				);
				if (files.Length > 0)
				{
					pkg = Packages.File.LoadFromFile(files[0]);
					Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(
						0x856DDBAC,
						0,
						0x499DB772,
						inst
					);
					if (pfd != null)
					{
						// TODO Uncomment when circular dependencies are sorted out.
						// SimPe.PackedFiles.Wrapper.Picture pic = new SimPe.PackedFiles.Wrapper.Picture();
						// pic.ProcessData(pfd, pkg);
						// return pic.Image;
						return null;
					}
				}
			}
			return null;
		}

		//     public static void Loadimges(TS2Logo tsLogo, int ep)
		//     {
		//         // This is used by the EP selecter which may display the logo for an EP that SimPe sees as not installed.
		//         ExpansionItem ei = PathProvider.Global.GetExpansion(ep);
		//         if (ei.InstalledPath(ep) == null) { tsLogo.BackImage = null; return; }
		//         string useown = ei.InstalledPath(ep) + "\\TSData\\Res\\UI\\ui.package";
		//         string usebase = PathProvider.Global[Expansions.BaseGame].InstallFolder + "\\TSData\\Res\\UI\\ui.package";
		//         string bakimge = "";
		//         string forimge = usebase;
		//         uint foimg = 0xccc30200; // the plumbob image intance in ui.package     Both temp set
		//         uint maimg = 0xccc30080; // the logo image intance in ui.package        to Basegame
		//         SimPe.Interfaces.Files.IPackedFileDescriptor pfd;
		//         SimPe.Packages.File pkg;
		//         tsLogo.Speed = 32; // lower value is faster
		//         tsLogo.ImageLocationX = 70;
		//         tsLogo.ImageWidth = 85; // width of each foreground image
		//         tsLogo.OverHead = 8; // space above logo for raised plumbob
		//         tsLogo.ImageLocationY = 0;

		//         switch (ep)
		//         {
		//             case 1: // University
		//                 bakimge = useown;
		//                 break;
		//             case 2: // Nightlife
		//                 bakimge = useown;
		//                 break;
		//             case 3: // Business
		//                 bakimge = useown;
		//                 maimg = 0x0000900D;
		//                 break;
		//             case 6: // Pets
		//                 bakimge = useown;
		//                 maimg = 0x0000900E;
		//                 tsLogo.ImageLocationX = 78;
		//                 break;
		//             case 7: // Seasons
		//                 bakimge = useown;
		//                 maimg = 0x00009010;
		//                 break;
		//             case 8: // Celebrations
		//                 bakimge = useown;
		//                 maimg = 0x00009011;
		//                 tsLogo.OverHead = 12;
		//                 tsLogo.ImageLocationX = 52;
		//                 break;
		//             case 9: // H&M Fashion
		//                 bakimge = useown;
		//                 maimg = 0x00009012;
		//                 tsLogo.OverHead = 12;
		//                 tsLogo.ImageLocationX = 52;
		//                 break;
		//             case 10: // BonVoyage
		//                 bakimge = useown;
		//                 maimg = 0x00009013;
		//                 break;
		//             case 11: // Teen Style
		//                 bakimge = useown;
		//                 maimg = 0x00009014;
		//                 tsLogo.OverHead = 12;
		//                 tsLogo.ImageLocationX = 52;
		//                 break;
		//             case 12: // Extra Stuff
		//                 bakimge = useown;
		//                 maimg = 0x00009015;
		//                 tsLogo.OverHead = 0;
		//                 tsLogo.ImageLocationX = 46;
		//                 break;
		//             case 13: // Freetime
		//                 bakimge = useown;
		//                 maimg = 0x00009016;
		//                 break;
		//             case 14: // Kitchens & Bathrooms
		//                 bakimge = useown;
		//                 maimg = 0x00009017;
		//                 tsLogo.OverHead = 12;
		//                 tsLogo.ImageLocationX = 52;
		//                 break;
		//             case 15: // Ikea
		//                 bakimge = useown;
		//                 maimg = 0x00009018;
		//                 tsLogo.OverHead = 12;
		//                 tsLogo.ImageLocationX = 52;
		//                 break;
		//             case 16: // Apartment Life
		//                 bakimge = useown;
		//                 maimg = 0x00009019;
		//                 break;
		//             case 17: // Mansion & Garden
		//                 bakimge = useown;
		//                 maimg = 0x00009020;
		//                 break;
		//             case 18: // Angel & Nurses
		//                 bakimge = useown;
		//                 forimge = useown;
		//                 foimg = 0xccc30269;
		//                 maimg = 0x00009020;
		//                 break;
		//             case 19: // Tits & Arse
		//                 bakimge = useown;
		//                 forimge = useown;
		//                 foimg = 0xccc30269;
		//                 maimg = 0x00009020;
		//                 tsLogo.ImageLocationY = 0;
		//                 tsLogo.OverHead = 15;
		//                 tsLogo.Speed = 48;
		//                 break;
		//             case 28: // Castaway
		//                 bakimge = useown;
		//                 forimge = useown;
		//                 maimg = 0xBEEF0022;
		//                 tsLogo.OverHead = 0;
		//                 tsLogo.ImageWidth = 42; // Sim Stoies have tiny plumbob
		//                 tsLogo.ImageLocationY = 20; // move plumbob down
		//                 tsLogo.ImageLocationX = 78;
		//                 break;
		//             case 29: // Pet Stories
		//                 bakimge = useown;
		//                 forimge = useown;
		//                 maimg = 0xBEEF0022;
		//                 tsLogo.OverHead = 0;
		//                 tsLogo.ImageWidth = 42;
		//                 tsLogo.ImageLocationY = 20;
		//                 break;
		//             case 30: // Life Stories
		//                 bakimge = useown;
		//                 forimge = useown;
		//                 maimg = 0xBEEF0022;
		//                 tsLogo.OverHead = 0;
		//                 tsLogo.ImageWidth = 42;
		//                 tsLogo.ImageLocationY = 20;
		//                 break;
		//             default: // Basegame
		//                 bakimge = usebase;
		//                 tsLogo.OverHead = 0;
		//                 tsLogo.ImageLocationY = 4;
		//                 break;
		//         }

		//         pkg = SimPe.Packages.File.LoadFromFile(bakimge);
		//         pfd = pkg.FindFile(0x856DDBAC, 0, 0x499DB772, maimg);
		//         if (pfd != null)
		//         {
		//             SimPe.PackedFiles.Wrapper.Picture pic = new SimPe.PackedFiles.Wrapper.Picture();
		//             pic.ProcessData(pfd, pkg);
		//             tsLogo.BackImage = pic.Image;
		//         }
		//         else tsLogo.BackImage = null;
		//         if (forimge != bakimge)
		//             pkg = SimPe.Packages.File.LoadFromFile(forimge);

		//         pfd = pkg.FindFile(0x856DDBAC, 0, 0x499DB772, foimg);
		//         if (pfd != null)
		//         {
		//             SimPe.PackedFiles.Wrapper.Picture pic = new SimPe.PackedFiles.Wrapper.Picture();
		//             pic.ProcessData(pfd, pkg);
		//             tsLogo.ForeImage = pic.Image;
		//         }
		//         else tsLogo.ForeImage = null;
		//     }
	}
}
