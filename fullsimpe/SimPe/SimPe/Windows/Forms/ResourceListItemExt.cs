namespace SimPe.Windows.Forms
{
	public class ResourceListItemExt : System.Windows.Forms.ListViewItem
	{
		static System.Drawing.Font regular = null;
		static System.Drawing.Font strike = null;

		bool vis;
		NamedPackedFileDescriptor pfd;
		ResourceViewManager manager;

		internal ResourceListItemExt(
			NamedPackedFileDescriptor pfd,
			ResourceViewManager manager,
			bool visible
		)
			: base()
		{
			vis = visible;
			if (regular == null)
			{
				regular = new System.Drawing.Font(
					Font.FontFamily,
					Font.Size,
					System.Drawing.FontStyle.Regular,
					Font.Unit
				);
				strike = new System.Drawing.Font(
					Font.FontFamily,
					Font.Size,
					System.Drawing.FontStyle.Strikeout,
					Font.Unit
				);
			}

			this.manager = manager;
			this.pfd = pfd;

			string[] subitems = new string[7];
			subitems[0] = visible
				? pfd.GetRealName()
				: pfd.Descriptor.ToResListString(); // Name
			subitems[1] = GetExtText(); // Type
			subitems[2] = "0x" + Helper.HexString(pfd.Descriptor.Group); // Group
			subitems[3] = "0x" + Helper.HexString(pfd.Descriptor.SubType); // InstHi

			// Inst
			subitems[4] = Helper.WindowsRegistry.ResourceListInstanceFormatHexOnly
				? "0x" + Helper.HexString(pfd.Descriptor.Instance)
				: Helper.WindowsRegistry.ResourceListInstanceFormatDecOnly
					? ((int)pfd.Descriptor.Instance).ToString()
					: "0x"
									+ Helper.HexString(pfd.Descriptor.Instance)
									+ " ("
									+ ((int)pfd.Descriptor.Instance).ToString()
									+ ")";

			subitems[5] = "0x" + Helper.HexString(pfd.Descriptor.Offset);
			subitems[6] = "0x" + Helper.HexString(pfd.Descriptor.Size);

			SubItems.Clear();
			Text = subitems[0];
			for (int i = 1; i < subitems.Length; i++)
			{
				SubItems.Add(subitems[i]);
			}

			ImageIndex = ResourceViewManager.GetIndexForResourceType(
				pfd.Descriptor.Type
			);

			/*pfd.Descriptor.ChangedData += new SimPe.Events.PackedFileChanged(Descriptor_ChangedData);
			pfd.Descriptor.ChangedUserData += new SimPe.Events.PackedFileChanged(Descriptor_ChangedUserData);
			pfd.Descriptor.DescriptionChanged += new EventHandler(Descriptor_DescriptionChanged);*/

			ChangeDescription(true);
		}

		string GetExtText()
		{
			switch (
				Helper.WindowsRegistry.ResourceListExtensionFormat
			)
			{
				case Registry.ResourceListExtensionFormats.Short:
					return pfd.Descriptor.TypeName.shortname;
				case Registry.ResourceListExtensionFormats.Long:
					return pfd.Descriptor.TypeName.Name;
				case Registry.ResourceListExtensionFormats.Hex:
					return "0x" + Helper.HexString(pfd.Descriptor.Type);
				default:
					return "";
			}
		}

		/*void Descriptor_DescriptionChanged(object sender, EventArgs e)
		{
			ChangeDescription(false);
		}

		void Descriptor_ChangedUserData(SimPe.Interfaces.Files.IPackedFileDescriptor sender)
		{
			ChangeDescription(false);
		}

		void Descriptor_ChangedData(SimPe.Interfaces.Files.IPackedFileDescriptor sender)
		{
			ChangeDescription(false);
		}        */

		~ResourceListItemExt()
		{
			FreeResources();
		}

		internal bool Visible
		{
			get => vis;
			set
			{
				if (vis != value)
				{
					vis = value;
					if (vis)
					{
						ChangeDescription(false);
					}
				}
			}
		}

		internal void FreeResources()
		{
			/*pfd.Descriptor.ChangedData -= new SimPe.Events.PackedFileChanged(Descriptor_ChangedData);
			pfd.Descriptor.ChangedUserData -= new SimPe.Events.PackedFileChanged(Descriptor_ChangedUserData);
			pfd.Descriptor.DescriptionChanged -= new EventHandler(Descriptor_DescriptionChanged);*/
		}

		/// <summary>
		/// Set the Description for this ListViewItem
		/// </summary>
		void ChangeDescription(bool justfont)
		{
			if (!justfont)
			{
				pfd.ResetRealName();
				Text = Visible ? pfd.GetRealName() : pfd.Descriptor.ToResListString();

				if (Helper.WindowsRegistry.ResourceListShowExtensions)
				{
					SubItems[1].Text = GetExtText();
				}

				SubItems[2].Text = "0x" + Helper.HexString(pfd.Descriptor.Group);
				SubItems[3].Text = "0x" + Helper.HexString(pfd.Descriptor.SubType);
				SubItems[4].Text = Helper.WindowsRegistry.ResourceListInstanceFormatHexOnly
					? "0x" + Helper.HexString(pfd.Descriptor.Instance)
					: Helper.WindowsRegistry.ResourceListInstanceFormatDecOnly
						? ((int)pfd.Descriptor.Instance).ToString()
						: "0x"
											+ Helper.HexString(pfd.Descriptor.Instance)
											+ " ("
											+ ((int)pfd.Descriptor.Instance).ToString()
											+ ")";

				SubItems[5].Text = "0x" + Helper.HexString(pfd.Descriptor.Offset);
				SubItems[6].Text = "0x" + Helper.HexString(pfd.Descriptor.Size);
			}

			System.Drawing.Color fg = System.Drawing.SystemColors.WindowText;
			System.Drawing.Font font = regular;

			if (pfd.Descriptor.MarkForDelete)
			{
				fg = System.Drawing.SystemColors.GrayText;
				font = strike;
			}
			if (
				pfd.Descriptor.MarkForReCompress
				|| (pfd.Descriptor.WasCompressed && !pfd.Descriptor.HasUserdata)
			)
			{
				fg = System.Drawing.SystemColors.Highlight;
				//font = new System.Drawing.Font(font.FontFamily, font.Size, font.Style, font.Unit);
			}

			if (pfd.Descriptor.MarkForReCompress)
			{
				font = new System.Drawing.Font(
					font.FontFamily,
					font.Size,
					font.Style | System.Drawing.FontStyle.Bold,
					font.Unit
				);
			}

			if (pfd.Descriptor.Changed)
			{
				font = new System.Drawing.Font(
					font.FontFamily,
					font.Size,
					font.Style | System.Drawing.FontStyle.Italic,
					font.Unit
				);
			}

			Font = font;
			ForeColor = fg;
		}
	}
}
