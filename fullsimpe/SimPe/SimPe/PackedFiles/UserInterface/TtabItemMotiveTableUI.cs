/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for TtabItemMotiveTableUI.
	/// </summary>
	public class TtabItemMotiveTableUI : UserControl
	{
		#region Form variables

		private Label lbMotive0;
		private Label lbMotive1;
		private Label lbMotive2;
		private Label lbMotive3;
		private Label lbMotive4;
		private Label lbMotive5;
		private Label lbMotive6;
		private Label lbMotive7;
		private Label lbMotive9;
		private Label lbMotive11;
		private Label lbMotive8;
		private Label lbMotive10;
		private Label lbMotive14;
		private Label lbMotive15;
		private Label lbMotive13;
		private Label lbMotive12;
		private Panel pnAllGroups;
		private CheckBox cbShowAll;
		private Panel pnCopyButtons;
		private Button btnCpyM0;
		private Button btnCpyM1;
		private Button btnCpyM2;
		private Button btnCpyM3;
		private Button btnCpyM4;
		private Button btnCpyM5;
		private Button btnCpyM7;
		private Button btnCpyM6;
		private Button btnCpyM9;
		private Button btnCpyM12;
		private Button btnCpyM11;
		private Button btnCpyM10;
		private Button btnCpyM15;
		private Button btnCpyM14;
		private Button btnCpyM13;
		private Button btnCpyM8;
		private Label lbCBM0;
		private Label lbCBM1;
		private Label lbCBM2;
		private Label lbCBM3;
		private Label lbCBM4;
		private Label lbCBM5;
		private Label lbCBM6;
		private Label lbCBM7;
		private Label lbCBM15;
		private Label lbCBM11;
		private Label lbCBM14;
		private Label lbCBM8;
		private Label lbCBM9;
		private Label lbCBM13;
		private Label lbCBM10;
		private Label lbCBM12;
		private Button btnCopyAll;
		private Label lbNrGroups;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public TtabItemMotiveTableUI()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			pnCopyButtons.Visible = pnAllGroups.Visible = false;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		#region TtabItemMotiveTableUI
		private TtabItemMotiveTable item = null;

		private Button[] aButtons;
		private int maxWidth = 0;

		public TtabItemMotiveTable MotiveTable
		{
			get => item;
			set
			{
				if (item != value)
				{
					if (item != null && item.Wrapper != null)
					{
						item.Wrapper.WrapperChanged -= new System.EventHandler(
							WrapperChanged
						);
					}

					item = value;
					setData();
					if (item != null)
					{
						item.Wrapper.WrapperChanged += new System.EventHandler(
							WrapperChanged
						);
					}
				}
			}
		}

		private void WrapperChanged(object sender, System.EventArgs e)
		{
			if (sender != item)
			{
				return;
			}

			setData();
		}

		private void setData()
		{
			cbShowAll.Enabled = false;
			pnAllGroups.Controls.Clear();

			if (item != null && item.Count > 0)
			{
				lbNrGroups.Text =
					lbNrGroups.Text.Split(new char[] { ':' })[0] + ": " + item.Count.ToString();

				TtabMotiveGroupUI c = new TtabMotiveGroupUI
				{
					MotiveGroup = item[0]
				};
				c.MGName = item.Type == TtabItemMotiveTableType.Human ? pjse.BhavWiz.readStr(pjse.GS.BhavStr.TTABAges, 0) : "[0]";

				setLocations(c);

				if (item.Count > 1)
				{
					cbShowAll.Enabled = true;
					int nextLeft = 0;
					for (int i = 1; i < item.Count; i++)
					{
						c = new TtabMotiveGroupUI();
						pnAllGroups.Controls.Add(c);
						c.MotiveGroup = item[i];
						c.MGName = item.Type == TtabItemMotiveTableType.Human
							? pjse.BhavWiz.readStr(
								pjse.GS.BhavStr.TTABAges,
								(ushort)i
							)
							: "[" + i.ToString() + "]";

						c.Location = new Point(nextLeft, 0);
						nextLeft += c.Width + 2;
					}
				}
			}
			else
			{
				lbNrGroups.Text = (lbNrGroups.Text.Split(new char[] { ':' })[0]) + ": 0";
			}

			cbShowAll_CheckedChanged(null, null);
		}

		private void setLocations(TtabMotiveGroupUI c)
		{
			Button[] b =
			{
				btnCpyM0,
				btnCpyM1,
				btnCpyM2,
				btnCpyM3,
				btnCpyM4,
				btnCpyM5,
				btnCpyM6,
				btnCpyM7,
				btnCpyM8,
				btnCpyM9,
				btnCpyM10,
				btnCpyM11,
				btnCpyM12,
				btnCpyM13,
				btnCpyM14,
				btnCpyM15,
			};
			aButtons = b;

			Label[] lbCBM =
			{
				lbCBM0,
				lbCBM1,
				lbCBM2,
				lbCBM3,
				lbCBM4,
				lbCBM5,
				lbCBM6,
				lbCBM7,
				lbCBM8,
				lbCBM9,
				lbCBM10,
				lbCBM11,
				lbCBM12,
				lbCBM13,
				lbCBM14,
				lbCBM15,
			};

			Label[] aMotiveLabels =
			{
				lbMotive0,
				lbMotive1,
				lbMotive2,
				lbMotive3,
				lbMotive4,
				lbMotive5,
				lbMotive6,
				lbMotive7,
				lbMotive8,
				lbMotive9,
				lbMotive10,
				lbMotive11,
				lbMotive12,
				lbMotive13,
				lbMotive14,
				lbMotive15,
			};

			Controls.Clear();
			Controls.Add(cbShowAll);
			Controls.Add(lbNrGroups);
			Controls.Add(pnAllGroups);
			Controls.Add(pnCopyButtons);
			Controls.Add(c);

			maxWidth = lbNrGroups.Width;

			int cbW = 0;
			for (ushort m = 0; m < aMotiveLabels.Length; m++)
			{
				Controls.Add(aMotiveLabels[m]);
				aMotiveLabels[m].Text = pjse.BhavWiz.readStr(
					pjse.GS.BhavStr.Motives,
					m
				);
				if (aMotiveLabels[m].Width > maxWidth)
				{
					maxWidth = aMotiveLabels[m].Width;
				}

				cbW = b[m].Width;
			}

			for (ushort m = 0; m < aMotiveLabels.Length; m++)
			{
				aMotiveLabels[m].Location = new Point(
					maxWidth - aMotiveLabels[m].Width,
					c.Tops[m] + 2
				);
				aButtons[m].Location = new Point(0, c.Tops[m]);
				lbCBM[m].Location = new Point(cbW + 2, c.Tops[m] + 2);
			}

			cbShowAll.Location = new Point(maxWidth - cbShowAll.Width, 2);

			c.Location = new Point(maxWidth + 2, 0);
			Height = c.Height + 24;

			btnCopyAll.Location = new Point(0, c.Tops[15] + c.Tops[1] - c.Tops[0]);
			lbNrGroups.Location = new Point(4, btnCopyAll.Top + 2);

			pnCopyButtons.Anchor = AnchorStyles.None;
			pnCopyButtons.Location = new Point(c.Right + 2, 0);
			pnCopyButtons.Size = new Size(lbCBM0.Right + 4, Height);
			pnCopyButtons.Anchor =
				AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;

			pnAllGroups.Anchor = AnchorStyles.None;
			pnAllGroups.Location = new Point(c.Right + 2, 0);
			pnAllGroups.Size = new Size(
				Width - pnAllGroups.Left,
				c.Bottom + 24
			);
			pnAllGroups.Anchor =
				AnchorStyles.Left
				| AnchorStyles.Right
				| AnchorStyles.Top
				| AnchorStyles.Bottom;
		}

		private void doCopyMotive(int m)
		{
			for (int i = 1; i < item.Count; i++)
			{
				item[0][m].CopyTo(item[i][m]);
			}
		}

		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(TtabItemMotiveTableUI)
				);
			lbMotive0 = new Label();
			lbMotive1 = new Label();
			lbMotive2 = new Label();
			lbMotive3 = new Label();
			lbMotive4 = new Label();
			lbMotive5 = new Label();
			lbMotive6 = new Label();
			lbMotive7 = new Label();
			lbMotive9 = new Label();
			lbMotive11 = new Label();
			lbMotive8 = new Label();
			lbMotive10 = new Label();
			lbMotive14 = new Label();
			lbMotive15 = new Label();
			lbMotive13 = new Label();
			lbMotive12 = new Label();
			pnAllGroups = new Panel();
			cbShowAll = new CheckBox();
			pnCopyButtons = new Panel();
			btnCopyAll = new Button();
			lbCBM0 = new Label();
			btnCpyM0 = new Button();
			btnCpyM1 = new Button();
			btnCpyM2 = new Button();
			btnCpyM3 = new Button();
			btnCpyM4 = new Button();
			btnCpyM5 = new Button();
			btnCpyM7 = new Button();
			btnCpyM6 = new Button();
			btnCpyM9 = new Button();
			btnCpyM12 = new Button();
			btnCpyM11 = new Button();
			btnCpyM10 = new Button();
			btnCpyM15 = new Button();
			btnCpyM14 = new Button();
			btnCpyM13 = new Button();
			btnCpyM8 = new Button();
			lbCBM1 = new Label();
			lbCBM2 = new Label();
			lbCBM3 = new Label();
			lbCBM4 = new Label();
			lbCBM5 = new Label();
			lbCBM6 = new Label();
			lbCBM7 = new Label();
			lbCBM15 = new Label();
			lbCBM11 = new Label();
			lbCBM14 = new Label();
			lbCBM8 = new Label();
			lbCBM9 = new Label();
			lbCBM13 = new Label();
			lbCBM10 = new Label();
			lbCBM12 = new Label();
			lbNrGroups = new Label();
			pnCopyButtons.SuspendLayout();
			SuspendLayout();
			//
			// lbMotive0
			//
			resources.ApplyResources(lbMotive0, "lbMotive0");
			lbMotive0.BackColor = Color.Transparent;
			lbMotive0.Name = "lbMotive0";
			//
			// lbMotive1
			//
			resources.ApplyResources(lbMotive1, "lbMotive1");
			lbMotive1.BackColor = Color.Transparent;
			lbMotive1.Name = "lbMotive1";
			//
			// lbMotive2
			//
			resources.ApplyResources(lbMotive2, "lbMotive2");
			lbMotive2.BackColor = Color.Transparent;
			lbMotive2.Name = "lbMotive2";
			//
			// lbMotive3
			//
			resources.ApplyResources(lbMotive3, "lbMotive3");
			lbMotive3.BackColor = Color.Transparent;
			lbMotive3.Name = "lbMotive3";
			//
			// lbMotive4
			//
			resources.ApplyResources(lbMotive4, "lbMotive4");
			lbMotive4.BackColor = Color.Transparent;
			lbMotive4.Name = "lbMotive4";
			//
			// lbMotive5
			//
			resources.ApplyResources(lbMotive5, "lbMotive5");
			lbMotive5.BackColor = Color.Transparent;
			lbMotive5.Name = "lbMotive5";
			//
			// lbMotive6
			//
			resources.ApplyResources(lbMotive6, "lbMotive6");
			lbMotive6.BackColor = Color.Transparent;
			lbMotive6.Name = "lbMotive6";
			//
			// lbMotive7
			//
			resources.ApplyResources(lbMotive7, "lbMotive7");
			lbMotive7.BackColor = Color.Transparent;
			lbMotive7.Name = "lbMotive7";
			//
			// lbMotive9
			//
			resources.ApplyResources(lbMotive9, "lbMotive9");
			lbMotive9.BackColor = Color.Transparent;
			lbMotive9.Name = "lbMotive9";
			//
			// lbMotive11
			//
			resources.ApplyResources(lbMotive11, "lbMotive11");
			lbMotive11.BackColor = Color.Transparent;
			lbMotive11.Name = "lbMotive11";
			//
			// lbMotive8
			//
			resources.ApplyResources(lbMotive8, "lbMotive8");
			lbMotive8.BackColor = Color.Transparent;
			lbMotive8.Name = "lbMotive8";
			//
			// lbMotive10
			//
			resources.ApplyResources(lbMotive10, "lbMotive10");
			lbMotive10.BackColor = Color.Transparent;
			lbMotive10.Name = "lbMotive10";
			//
			// lbMotive14
			//
			resources.ApplyResources(lbMotive14, "lbMotive14");
			lbMotive14.BackColor = Color.Transparent;
			lbMotive14.Name = "lbMotive14";
			//
			// lbMotive15
			//
			resources.ApplyResources(lbMotive15, "lbMotive15");
			lbMotive15.BackColor = Color.Transparent;
			lbMotive15.Name = "lbMotive15";
			//
			// lbMotive13
			//
			resources.ApplyResources(lbMotive13, "lbMotive13");
			lbMotive13.BackColor = Color.Transparent;
			lbMotive13.Name = "lbMotive13";
			//
			// lbMotive12
			//
			resources.ApplyResources(lbMotive12, "lbMotive12");
			lbMotive12.BackColor = Color.Transparent;
			lbMotive12.Name = "lbMotive12";
			//
			// pnAllGroups
			//
			resources.ApplyResources(pnAllGroups, "pnAllGroups");
			pnAllGroups.BackColor = Color.Transparent;
			pnAllGroups.Name = "pnAllGroups";
			//
			// cbShowAll
			//
			resources.ApplyResources(cbShowAll, "cbShowAll");
			cbShowAll.BackColor = Color.Transparent;
			cbShowAll.Name = "cbShowAll";
			cbShowAll.UseVisualStyleBackColor = false;
			cbShowAll.CheckedChanged += new System.EventHandler(
				cbShowAll_CheckedChanged
			);
			//
			// pnCopyButtons
			//
			pnCopyButtons.BackColor = Color.Transparent;
			pnCopyButtons.Controls.Add(btnCopyAll);
			pnCopyButtons.Controls.Add(lbCBM0);
			pnCopyButtons.Controls.Add(btnCpyM0);
			pnCopyButtons.Controls.Add(btnCpyM1);
			pnCopyButtons.Controls.Add(btnCpyM2);
			pnCopyButtons.Controls.Add(btnCpyM3);
			pnCopyButtons.Controls.Add(btnCpyM4);
			pnCopyButtons.Controls.Add(btnCpyM5);
			pnCopyButtons.Controls.Add(btnCpyM7);
			pnCopyButtons.Controls.Add(btnCpyM6);
			pnCopyButtons.Controls.Add(btnCpyM9);
			pnCopyButtons.Controls.Add(btnCpyM12);
			pnCopyButtons.Controls.Add(btnCpyM11);
			pnCopyButtons.Controls.Add(btnCpyM10);
			pnCopyButtons.Controls.Add(btnCpyM15);
			pnCopyButtons.Controls.Add(btnCpyM14);
			pnCopyButtons.Controls.Add(btnCpyM13);
			pnCopyButtons.Controls.Add(btnCpyM8);
			pnCopyButtons.Controls.Add(lbCBM1);
			pnCopyButtons.Controls.Add(lbCBM2);
			pnCopyButtons.Controls.Add(lbCBM3);
			pnCopyButtons.Controls.Add(lbCBM4);
			pnCopyButtons.Controls.Add(lbCBM5);
			pnCopyButtons.Controls.Add(lbCBM6);
			pnCopyButtons.Controls.Add(lbCBM7);
			pnCopyButtons.Controls.Add(lbCBM15);
			pnCopyButtons.Controls.Add(lbCBM11);
			pnCopyButtons.Controls.Add(lbCBM14);
			pnCopyButtons.Controls.Add(lbCBM8);
			pnCopyButtons.Controls.Add(lbCBM9);
			pnCopyButtons.Controls.Add(lbCBM13);
			pnCopyButtons.Controls.Add(lbCBM10);
			pnCopyButtons.Controls.Add(lbCBM12);
			resources.ApplyResources(pnCopyButtons, "pnCopyButtons");
			pnCopyButtons.Name = "pnCopyButtons";
			//
			// btnCopyAll
			//
			btnCopyAll.BackColor = Color.Transparent;
			resources.ApplyResources(btnCopyAll, "btnCopyAll");
			btnCopyAll.Name = "btnCopyAll";
			btnCopyAll.UseVisualStyleBackColor = false;
			btnCopyAll.Click += new System.EventHandler(copy_Click);
			//
			// lbCBM0
			//
			resources.ApplyResources(lbCBM0, "lbCBM0");
			lbCBM0.BackColor = Color.Transparent;
			lbCBM0.Name = "lbCBM0";
			//
			// btnCpyM0
			//
			btnCpyM0.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM0, "btnCpyM0");
			btnCpyM0.Name = "btnCpyM0";
			btnCpyM0.UseVisualStyleBackColor = false;
			btnCpyM0.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM1
			//
			btnCpyM1.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM1, "btnCpyM1");
			btnCpyM1.Name = "btnCpyM1";
			btnCpyM1.UseVisualStyleBackColor = false;
			btnCpyM1.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM2
			//
			btnCpyM2.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM2, "btnCpyM2");
			btnCpyM2.Name = "btnCpyM2";
			btnCpyM2.UseVisualStyleBackColor = false;
			btnCpyM2.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM3
			//
			btnCpyM3.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM3, "btnCpyM3");
			btnCpyM3.Name = "btnCpyM3";
			btnCpyM3.UseVisualStyleBackColor = false;
			btnCpyM3.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM4
			//
			btnCpyM4.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM4, "btnCpyM4");
			btnCpyM4.Name = "btnCpyM4";
			btnCpyM4.UseVisualStyleBackColor = false;
			btnCpyM4.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM5
			//
			btnCpyM5.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM5, "btnCpyM5");
			btnCpyM5.Name = "btnCpyM5";
			btnCpyM5.UseVisualStyleBackColor = false;
			btnCpyM5.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM7
			//
			btnCpyM7.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM7, "btnCpyM7");
			btnCpyM7.Name = "btnCpyM7";
			btnCpyM7.UseVisualStyleBackColor = false;
			btnCpyM7.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM6
			//
			btnCpyM6.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM6, "btnCpyM6");
			btnCpyM6.Name = "btnCpyM6";
			btnCpyM6.UseVisualStyleBackColor = false;
			btnCpyM6.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM9
			//
			btnCpyM9.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM9, "btnCpyM9");
			btnCpyM9.Name = "btnCpyM9";
			btnCpyM9.UseVisualStyleBackColor = false;
			btnCpyM9.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM12
			//
			btnCpyM12.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM12, "btnCpyM12");
			btnCpyM12.Name = "btnCpyM12";
			btnCpyM12.UseVisualStyleBackColor = false;
			btnCpyM12.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM11
			//
			btnCpyM11.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM11, "btnCpyM11");
			btnCpyM11.Name = "btnCpyM11";
			btnCpyM11.UseVisualStyleBackColor = false;
			btnCpyM11.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM10
			//
			btnCpyM10.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM10, "btnCpyM10");
			btnCpyM10.Name = "btnCpyM10";
			btnCpyM10.UseVisualStyleBackColor = false;
			btnCpyM10.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM15
			//
			btnCpyM15.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM15, "btnCpyM15");
			btnCpyM15.Name = "btnCpyM15";
			btnCpyM15.UseVisualStyleBackColor = false;
			btnCpyM15.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM14
			//
			btnCpyM14.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM14, "btnCpyM14");
			btnCpyM14.Name = "btnCpyM14";
			btnCpyM14.UseVisualStyleBackColor = false;
			btnCpyM14.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM13
			//
			btnCpyM13.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM13, "btnCpyM13");
			btnCpyM13.Name = "btnCpyM13";
			btnCpyM13.UseVisualStyleBackColor = false;
			btnCpyM13.Click += new System.EventHandler(copy_Click);
			//
			// btnCpyM8
			//
			btnCpyM8.BackColor = Color.Transparent;
			resources.ApplyResources(btnCpyM8, "btnCpyM8");
			btnCpyM8.Name = "btnCpyM8";
			btnCpyM8.UseVisualStyleBackColor = false;
			btnCpyM8.Click += new System.EventHandler(copy_Click);
			//
			// lbCBM1
			//
			resources.ApplyResources(lbCBM1, "lbCBM1");
			lbCBM1.BackColor = Color.Transparent;
			lbCBM1.Name = "lbCBM1";
			//
			// lbCBM2
			//
			resources.ApplyResources(lbCBM2, "lbCBM2");
			lbCBM2.BackColor = Color.Transparent;
			lbCBM2.Name = "lbCBM2";
			//
			// lbCBM3
			//
			resources.ApplyResources(lbCBM3, "lbCBM3");
			lbCBM3.BackColor = Color.Transparent;
			lbCBM3.Name = "lbCBM3";
			//
			// lbCBM4
			//
			resources.ApplyResources(lbCBM4, "lbCBM4");
			lbCBM4.BackColor = Color.Transparent;
			lbCBM4.Name = "lbCBM4";
			//
			// lbCBM5
			//
			resources.ApplyResources(lbCBM5, "lbCBM5");
			lbCBM5.BackColor = Color.Transparent;
			lbCBM5.Name = "lbCBM5";
			//
			// lbCBM6
			//
			resources.ApplyResources(lbCBM6, "lbCBM6");
			lbCBM6.BackColor = Color.Transparent;
			lbCBM6.Name = "lbCBM6";
			//
			// lbCBM7
			//
			resources.ApplyResources(lbCBM7, "lbCBM7");
			lbCBM7.BackColor = Color.Transparent;
			lbCBM7.Name = "lbCBM7";
			//
			// lbCBM15
			//
			resources.ApplyResources(lbCBM15, "lbCBM15");
			lbCBM15.BackColor = Color.Transparent;
			lbCBM15.Name = "lbCBM15";
			//
			// lbCBM11
			//
			resources.ApplyResources(lbCBM11, "lbCBM11");
			lbCBM11.BackColor = Color.Transparent;
			lbCBM11.Name = "lbCBM11";
			//
			// lbCBM14
			//
			resources.ApplyResources(lbCBM14, "lbCBM14");
			lbCBM14.BackColor = Color.Transparent;
			lbCBM14.Name = "lbCBM14";
			//
			// lbCBM8
			//
			resources.ApplyResources(lbCBM8, "lbCBM8");
			lbCBM8.BackColor = Color.Transparent;
			lbCBM8.Name = "lbCBM8";
			//
			// lbCBM9
			//
			resources.ApplyResources(lbCBM9, "lbCBM9");
			lbCBM9.BackColor = Color.Transparent;
			lbCBM9.Name = "lbCBM9";
			//
			// lbCBM13
			//
			resources.ApplyResources(lbCBM13, "lbCBM13");
			lbCBM13.BackColor = Color.Transparent;
			lbCBM13.Name = "lbCBM13";
			//
			// lbCBM10
			//
			resources.ApplyResources(lbCBM10, "lbCBM10");
			lbCBM10.BackColor = Color.Transparent;
			lbCBM10.Name = "lbCBM10";
			//
			// lbCBM12
			//
			resources.ApplyResources(lbCBM12, "lbCBM12");
			lbCBM12.BackColor = Color.Transparent;
			lbCBM12.Name = "lbCBM12";
			//
			// lbNrGroups
			//
			resources.ApplyResources(lbNrGroups, "lbNrGroups");
			lbNrGroups.BackColor = Color.Transparent;
			lbNrGroups.Name = "lbNrGroups";
			//
			// TtabItemMotiveTableUI
			//
			Controls.Add(lbNrGroups);
			Controls.Add(pnCopyButtons);
			Controls.Add(cbShowAll);
			Controls.Add(pnAllGroups);
			Controls.Add(lbMotive0);
			Controls.Add(lbMotive1);
			Controls.Add(lbMotive2);
			Controls.Add(lbMotive3);
			Controls.Add(lbMotive4);
			Controls.Add(lbMotive5);
			Controls.Add(lbMotive6);
			Controls.Add(lbMotive7);
			Controls.Add(lbMotive9);
			Controls.Add(lbMotive11);
			Controls.Add(lbMotive8);
			Controls.Add(lbMotive10);
			Controls.Add(lbMotive14);
			Controls.Add(lbMotive15);
			Controls.Add(lbMotive13);
			Controls.Add(lbMotive12);
			Name = "TtabItemMotiveTableUI";
			resources.ApplyResources(this, "$this");
			pnCopyButtons.ResumeLayout(false);
			pnCopyButtons.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		private void copy_Click(object sender, System.EventArgs e)
		{
			ArrayList alBtnCopy = new ArrayList(aButtons);
			int bn = alBtnCopy.IndexOf(sender);
			if (bn >= 0)
			{
				doCopyMotive(bn);
			}
			else
			{
				for (int i = 0; i < aButtons.Length; i++)
				{
					doCopyMotive(i);
				}
			}
		}

		private void cbShowAll_CheckedChanged(object sender, System.EventArgs e)
		{
			pnAllGroups.Visible = cbShowAll.Enabled && cbShowAll.Checked;
			pnCopyButtons.Visible = cbShowAll.Enabled && !cbShowAll.Checked;
		}
	}
}
