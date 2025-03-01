// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.PackedFiles.Ttab
{
	public class TtabItemSingleMotiveItem : TtabItemMotiveItem
	{
		#region Attributes
		private short[] items = new short[3];
		#endregion

		#region Accessor Methods
		public short Min
		{
			get => this[0];
			set => this[0] = value;
		}
		public short Delta
		{
			get => items[1];
			set => this[1] = value;
		}
		public short Type
		{
			get => items[2];
			set => this[2] = value;
		}
		#endregion

		public TtabItemSingleMotiveItem(TtabItemMotiveGroup parent)
			: base(parent) { }

		public TtabItemSingleMotiveItem(
			TtabItemMotiveGroup parent,
			System.IO.BinaryReader reader
		)
			: base(parent, reader) { }

		protected override void CopyTo(TtabItemMotiveItem target, bool doEvent)
		{
			if (!(target is TtabItemSingleMotiveItem))
			{
				throw new ArgumentException("Argument must be of same type", "target");
			}

			items.CopyTo(((TtabItemSingleMotiveItem)target).items, 0);
			if (doEvent && target.Wrapper != null)
			{
				target.Wrapper.OnWrapperChanged(target, new EventArgs());
			}
		}

		public override TtabItemMotiveItem Clone(TtabItemMotiveGroup parent)
		{
			TtabItemSingleMotiveItem clone = new TtabItemSingleMotiveItem(parent);
			CopyTo(clone, false);
			return clone;
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			for (int i = 0; i < items.Length; i++)
			{
				items[i] = reader.ReadInt16();
			}
		}

		internal override void Serialize(System.IO.BinaryWriter writer)
		{
			for (int i = 0; i < items.Length; i++)
			{
				writer.Write(items[i]);
			}
		}

		public override bool InUse => items[0] != 0 || items[1] != 0 || items[2] != 0;

		private short this[int index]
		{
			get => items[index];
			set
			{
				if (items[index] != value)
				{
					items[index] = value;
					Wrapper?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
	}
}
