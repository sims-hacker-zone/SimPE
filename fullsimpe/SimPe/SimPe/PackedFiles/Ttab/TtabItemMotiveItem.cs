// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.PackedFiles.Ttab
{
	public abstract class TtabItemMotiveItem
	{
		#region Attributes
		protected TtabItemMotiveGroup parent = null;
		#endregion

		#region Accessor Methods
		public Ttab Wrapper => parent?.Wrapper;
		public TtabItemMotiveGroup Parent
		{
			get => parent;
			set => parent = value;
		}
		#endregion

		public TtabItemMotiveItem(TtabItemMotiveGroup parent)
		{
			this.parent = parent;
		}

		public TtabItemMotiveItem(
			TtabItemMotiveGroup parent,
			System.IO.BinaryReader reader
		)
			: this(parent)
		{
			Unserialize(reader);
		}

		protected abstract void CopyTo(TtabItemMotiveItem target, bool doEvent);

		public void CopyTo(TtabItemMotiveItem target)
		{
			CopyTo(target, true);
		}

		public abstract TtabItemMotiveItem Clone(TtabItemMotiveGroup parent);

		public TtabItemMotiveItem Clone()
		{
			return Clone(parent);
		}

		protected abstract void Unserialize(System.IO.BinaryReader reader);
		internal abstract void Serialize(System.IO.BinaryWriter writer);
		public abstract bool InUse
		{
			get;
		}
	}
}
