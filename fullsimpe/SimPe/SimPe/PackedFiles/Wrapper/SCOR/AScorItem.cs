using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimPe.PackedFiles.Wrapper.SCOR
{
	[System.ComponentModel.ToolboxItem(false)]
	public partial class AScorItem : UserControl
	{
		public string TokenName
		{
			get; private set;
		}
		public ScorItem ParentItem
		{
			get;
		}

		[
			DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
			Browsable(false)
		]
		public bool Changed
		{
			get
			{
				if (ParentItem != null)
					if (ParentItem.Parent != null)
						return ParentItem.Parent.Changed;

				return false;
			}
			set
			{
				if (ParentItem != null)
					if (ParentItem.Parent != null)
						ParentItem.Parent.Changed = value;
			}
		}

		internal AScorItem()
			: this(new ScorItem(null))
		{
			TokenName = "";
		}

		internal AScorItem(ScorItem si)
		{
			this.ParentItem = si;
			InitializeComponent();
		}

		internal void SetData(string name, System.IO.BinaryReader reader)
		{
			this.TokenName = name;
			if (reader != null)
				DoSetData(name, reader);
		}

		protected virtual void DoSetData(string name, System.IO.BinaryReader reader)
		{
		}

		internal virtual void Serialize(System.IO.BinaryWriter writer, bool last)
		{
			StreamHelper.WriteString(writer, TokenName);
		}
	}
}
