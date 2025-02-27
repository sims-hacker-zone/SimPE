/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// handles Packed SRel Files
	/// </summary>
	public class SRel : UIBase, IPackedFileUI
	{
		/// <summary>
		/// Creates a new Instance and fills the aspiration Types into the correct Form
		/// </summary>
		public SRel()
		{
			form.cbfamtype.Items.Clear();
			form.cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(
					MetaData.RelationshipTypes.Unset_Unknown
				)
			);
			form.cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(MetaData.RelationshipTypes.Aunt)
			);
			form.cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(MetaData.RelationshipTypes.Child)
			);
			form.cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(MetaData.RelationshipTypes.Cousin)
			);
			form.cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(
					MetaData.RelationshipTypes.Grandchild
				)
			);
			form.cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(
					MetaData.RelationshipTypes.Gradparent
				)
			);
			form.cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(
					MetaData.RelationshipTypes.Nice_Nephew
				)
			);
			form.cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(MetaData.RelationshipTypes.Parent)
			);
			form.cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(MetaData.RelationshipTypes.Sibling)
			);
			form.cbfamtype.Items.Add(
				new LocalizedRelationshipTypes(MetaData.RelationshipTypes.Spouses)
			);
		}

		#region IPackedFileHandler Member

		public Control GUIHandle => form.realPanel;

		public void UpdateGUI(IFileWrapper wrapper)
		{
			Wrapper.SRel srel = (Wrapper.SRel)wrapper;
			form.wrapper = srel;

			form.tbshortterm.Text = srel.Shortterm.ToString();
			form.tblongterm.Text = srel.Longterm.ToString();
			form.cbBFF.Visible =
				form.cbplatonic.Visible =
				form.cbsecret.Visible =
					(srel.RelationState2 != null);

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
