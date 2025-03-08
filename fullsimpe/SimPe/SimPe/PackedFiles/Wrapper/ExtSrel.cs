// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Drawing;

using SimPe.Extensions;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Summary description for ExtSDesc.
	/// </summary>
	public class ExtSrel : SRel, IMultiplePackedFileWrapper
	{
		public ExtSrel()
			: base() { }

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Extended Sim Relation Wrapper",
				"Quaxi",
				"This File Contians the Relationship states for two Sims.",
				2,
				Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.srel.png")
				)
			);
		}

		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.ExtSrel();
		}

		#region Descriptions
		protected ExtSDesc GetDescriptionByInstance(uint inst)
		{
			ExtSDesc ret =
				(ExtSDesc)
					FileTableBase.ProviderRegistry.SimDescriptionProvider.FindSim(
						(ushort)inst
					);
			return ret;
#if UNREACHABLE
			if (ret == null)
			{
				if (Package == null)
					return null;
				if (this.FileDescriptor == null)
					return null;
				SimPe.Interfaces.Files.IPackedFileDescriptor pfd = Package.FindFile(
					Data.FileTypes.SDSC,
					0,
					FileDescriptor.Group,
					inst
				);
				if (pfd == null)
					return null;

				ret = new SimPe.PackedFiles.Wrapper.ExtSDesc().ProcessFile(pfd, Package);
			}
			return ret;
#endif
		}

		public uint TargetSimInstance => FileDescriptor == null ? 0 : FileDescriptor.Instance & 0xffff;

		public uint SourceSimInstance => FileDescriptor == null ? 0 : (FileDescriptor.Instance >> 16) & 0xffff;

		ExtSDesc src,
			dst;
		public ExtSDesc SourceSim
		{
			get
			{
				if (src == null)
				{
					src = GetDescriptionByInstance(SourceSimInstance);
				}
				else if (src.FileDescriptor.Instance != SourceSimInstance)
				{
					src = GetDescriptionByInstance(SourceSimInstance);
				}

				return src;
			}
		}

		public ExtSDesc TargetSim
		{
			get
			{
				if (dst == null)
				{
					dst = GetDescriptionByInstance(TargetSimInstance);
				}
				else if (dst.FileDescriptor.Instance != TargetSimInstance)
				{
					dst = GetDescriptionByInstance(TargetSimInstance);
				}

				return dst;
			}
		}

		public string SourceSimName => SourceSim != null ? SourceSim.SimName + " " + SourceSim.SimFamilyName : Localization.GetString("Unknown");

		public string TargetSimName => TargetSim != null ? TargetSim.SimName + " " + TargetSim.SimFamilyName : Localization.GetString("Unknown");

		public Image Image
		{
			get
			{
				Bitmap b = new Bitmap(356, 256);
				Graphics g = Graphics.FromImage(b);

				Image isrc = null;
				if (SourceSim != null)
				{
					if (SourceSim.Image != null)
					{
						if (SourceSim.Image.Width > 8)
						{
							isrc = SourceSim.Image;
						}
					}
				}

				isrc = isrc == null
					? SourceSim != null ? GetImage.NoOne : GetImage.NoOne
					: Ambertation.Drawing.GraphicRoutines.KnockoutImage(
						isrc,
						new Point(0, 0),
						Color.Magenta
					);

				Image idst = null;
				if (TargetSim != null)
				{
					if (TargetSim.Image != null)
					{
						if (TargetSim.Image.Width > 8)
						{
							idst = TargetSim.Image;
						}
					}
				}

				idst = idst == null
					? TargetSim != null ? GetImage.NoOne : GetImage.NoOne
					: Ambertation.Drawing.GraphicRoutines.KnockoutImage(
						idst,
						new Point(0, 0),
						Color.Magenta
					);

				const int offsety = 32;
				g.DrawImage(
					isrc,
					new Rectangle(0, offsety, 256, 256 - offsety),
					new Rectangle(0, 0, isrc.Width, isrc.Height - offsety),
					GraphicsUnit.Pixel
				);
				g.DrawImage(
					idst,
					new Rectangle(100, 0, 256, 256),
					new Rectangle(0, 0, idst.Width, idst.Height),
					GraphicsUnit.Pixel
				);
				g.Dispose();
				return b;
			}
		}
		#endregion

		protected override string GetResourceName(FileTypeInformation fti)
		{
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package);
			}

			return SourceSimName
				+ " "
				+ Localization.GetString("towards")
				+ " "
				+ TargetSimName;
		}
	}
}
