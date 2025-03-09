// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.UserInterface;

namespace SimPe.PackedFiles.Srel
{
	/// <summary>
	/// handles Packed SRel Files
	/// </summary>
	public class SRelUI : UIBase, IPackedFileUI
	{
		/// <summary>
		/// Creates a new Instance and fills the aspiration Types into the correct Form
		/// </summary>
		public SRelUI()
		{
			form.cbfamtype.Items.Clear();
			form.cbfamtype.Items.AddRange((from RelationshipTypes type in Enum.GetValues(typeof(RelationshipTypes))
										   select new LocalizedRelationshipTypes(type)).ToArray());
		}

		#region IPackedFileHandler Member

		public Control GUIHandle => form.realPanel;

		public void UpdateGUI(IFileWrapper wrapper)
		{
			SRel srel = (SRel)wrapper;
			form.wrapper = srel;

			form.tbshortterm.Text = srel.Shortterm.ToString();
			form.tblongterm.Text = srel.Longterm.ToString();
			form.cbBFF.Visible =
				form.cbplatonic.Visible =
				form.cbsecret.Visible =
					srel.RelationState2 != null;

			List<CheckBox> ltcb = new List<CheckBox>(
				new CheckBox[]
				{
					form.cbcrush,
					form.cblove,
					form.cbengaged,
					form.cbmarried,
					form.cbfriend,
					form.cbbuddie,
					form.cbsteady,
					form.cbenemy,
					null,
					null,
					null,
					null,
					null,
					null,
					form.cbfamily,
					form.cbbest,
					form.cbBFF,
					null,
					form.cbplatonic,
					form.cbsecret,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
				}
			);

			if (srel.RelationState2 != null)
			{
				Boolset bs1 = srel.RelationState.Value;
				Boolset bs2 = srel.RelationState2.Value;
				for (int i = 0; i < ltcb.Count; i++)
				{
					if (ltcb[i] != null)
					{
						ltcb[i].Checked = (i < 16 ? bs1 : bs2)[i & 0x0f];
					}
				}
			}
			else
			{
				Boolset bs1 = srel.RelationState.Value;
				for (int i = 0; i < 16; i++)
				{
					if (ltcb[i] != null)
					{
						ltcb[i].Checked = bs1[i & 0x0f];
					}
				}
			}

			form.cbfamtype.SelectedIndex = 0;
			for (int i = 1; i < form.cbfamtype.Items.Count; i++)
			{
				if (
					form.cbfamtype.Items[i]
					== new LocalizedRelationshipTypes(srel.FamilyRelation)
				)
				{
					form.cbfamtype.SelectedIndex = i;
					break;
				}
			}
		}

		#endregion
	}
}
