/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class BhavInstListControl : System.Windows.Forms.UserControl
	{
		#region Form variables
		private System.Windows.Forms.PictureBox pnflow;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public BhavInstListControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
			if (setHandler && wrapper != null)
			{
				wrapper.WrapperChanged -= new System.EventHandler(this.WrapperChanged);
				setHandler = false;
			}
			wrapper = null;
			if (flowitems != null)
				for(int i = 0; i < flowitems.Length; i++) if (flowitems[i] != null) { flowitems[i].Dispose(); flowitems[i] = null; }
			flowitems = null;
			pnflow = null;
		}


		#region BhavInstListControl
		/// <summary>
		/// Indicates the value of SelectedIndex has changed
		/// </summary>
		public event EventHandler SelectedInstChanged;

		private Bhav wrapper = null;
		private int csel = -1;
		private bool setHandler = false;
		private BhavInstListItemUI[] flowitems = null;
		private bool internalchg = false;

		public void UpdateGUI(Bhav wrp)
		{
			wrapper = wrp;
			csel = -1;
			internalchg = false;
			this.AutoScrollPosition = new Point(0, 0);
            this.WrapperChanged(new List<Instruction>(), null);
			if (flowitems != null && flowitems.Length > 0)
			{
				flowitems[0].MakeSelected(); // but don't focus!
				SelectedIndex = 0;
			}

			if (!setHandler)
			{
				wrapper.WrapperChanged += new System.EventHandler(this.WrapperChanged);
				setHandler = true;
			}
		}

		private void WrapperChanged(object sender, System.EventArgs e)
		{
			if (wrapper == null) return;

			if (internalchg) return;

			// Handler for instructions list
			if (sender is List<Instruction>)
			{
				if (csel >= wrapper.Count) csel = wrapper.Count - 1;
				myrepaint();
				OnSelectedInstChanged(new EventArgs());
			}

			// if any instruction updated, redraw the connectors
			if (sender is Instruction && wrapper.IndexOf((Instruction)sender) >= 0)
			{
				pnflow.Image = DrawConnectors();
			}
		}


		/// <summary>
		/// Returns or sets the index of the currently selected instruction
		/// </summary>
		public int SelectedIndex
		{
			get { return csel; }
			set
			{
				if (value != -1 && (flowitems == null || value < -1 || value >= flowitems.Length))
					throw new Exception("Internal failure: SelectedIndex out of range: " + value.ToString());

				if (csel != value)
				{
					if (csel >= 0) flowitems[csel].MakeUnselected();
					csel = value;
					pnflow.Image = DrawConnectors();
					OnSelectedInstChanged(new EventArgs());
				}
			}
		}

		protected virtual void OnSelectedInstChanged(EventArgs e) { if (SelectedInstChanged != null) { SelectedInstChanged(this, e); } }


		public void Add(BhavUIAddType type)
		{
			if (csel >= wrapper.Count) throw new Exception("Internal failure: csel out of range");
			bool savedstate = internalchg;
			internalchg = true;

			Instruction i = (csel >= 0) ? wrapper[csel].Clone() : new Instruction(wrapper);
			int newLine = (type == BhavUIAddType.Default) ? wrapper.Count : csel + 1;

            try
            {
                wrapper.Add(i);

                int index = wrapper.Count - 1;
                if (index != newLine)
                    wrapper.Move(index, newLine);
                if (csel >= 0)
                    switch (type)
                    {
                        case BhavUIAddType.Default: break;
                        case BhavUIAddType.Unlinked: break;
                        case BhavUIAddType.ViaTrue: ((Instruction)wrapper[csel]).Target1 = (ushort)newLine; break;
                        case BhavUIAddType.ViaFalse: ((Instruction)wrapper[csel]).Target2 = (ushort)newLine; break;
                    }
            }
            catch
            {
                MessageBox.Show(
                    pjse.Localization.GetString("toomanylines")
                    , "PJSE: Behaviour Editor"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                newLine = csel;
            }

			internalchg = savedstate;

			myrepaint();
			flowitems[newLine].Focus();
		}

		public void Delete(BhavUIDeleteType type)
		{
			if (csel < 0) throw new Exception("No current instruction");
			if (csel >= wrapper.Count) throw new Exception("Internal failure: csel out of range");

			bool savedstate = internalchg;
			internalchg = true;
			if (type == BhavUIDeleteType.Pescado && csel < wrapper.Count - 1)
			{
				foreach (Instruction i in wrapper)
				{
					ushort t = (ushort)(csel + 1);
					if (i.Target1 == csel) i.Target1 = t;
					if (i.Target2 == csel) i.Target2 = t;
				}
			}
			wrapper.RemoveAt(csel);
			internalchg = savedstate;

			int oldCsel = csel;
			csel = -1;
			myrepaint();
			if (oldCsel >= wrapper.Count)
				flowitems[wrapper.Count - 1].Focus();
			else if (oldCsel >= 0) flowitems[oldCsel].Focus();
		}

		public void MoveInst(int delta)
		{
			if (csel < 0) throw new Exception("No current instruction");
			if (csel >= wrapper.Count) throw new Exception("Internal failure: csel out of range");

			int to = csel + delta;
			if (to < 0) to = 0;
			if (to >= wrapper.Count) to = wrapper.Count - 1;
			if (csel == to) return;

			bool savedstate = internalchg;
			internalchg = true;
			wrapper.Move(csel, to);
			internalchg = savedstate;

			csel = -1;
			myrepaint();
			flowitems[to].Focus();
		}

		public void Sort()
		{
			Instruction inst = null;
			if (csel > -1)
				inst = wrapper[csel];

			bool savedstate = internalchg;
			internalchg = true;
			this.Parent.Cursor = Cursors.WaitCursor;
			wrapper.Sort();
			this.Parent.Cursor = Cursors.Default;
			internalchg = savedstate;

			csel = -1;
			myrepaint();
			int index = -1;
			if (inst != null) index = wrapper.IndexOf(inst);
			if (index >= 0) flowitems[index].Focus();
		}

		public void Relink()
		{
			if (wrapper.Count == 0) return;

			bool savedstate = internalchg;
			internalchg = true;
			this.Parent.Cursor = Cursors.WaitCursor;
			for (ushort i = 0; i < wrapper.Count - 1; i++)
			{
				wrapper[i].Target1 = (ushort)(i+1);
				wrapper[i].Target2 = 0xFFFC;
			}
			wrapper[wrapper.Count - 1].Target1 = 0xFFFD;
			wrapper[wrapper.Count - 1].Target2 = 0xFFFC;
			this.Parent.Cursor = Cursors.Default;
			internalchg = savedstate;
			myrepaint();
			if (csel >= 0)
				flowitems[csel].Focus();
		}

		public void Append(pjse.FileTable.Entry item)
		{
			if (item == null || !(item.Wrapper is Bhav))
				return;

			Bhav b = (Bhav)item.Wrapper;
			if (b == null) return;

			bool savedstate = internalchg;
			internalchg = true;

			this.Parent.Cursor = Cursors.WaitCursor;
			try
			{
				ushort offset = (ushort)wrapper.Count;
				foreach (Instruction bi in b)
				{
                    try
                    {
                        wrapper.Add(bi);
                        int i = wrapper.Count - 1;
                        if (wrapper[i].Target1 < 0xFFFC)
                            wrapper[i].Target1 += offset;
                        if (wrapper[i].Target2 < 0xFFFC)
                            wrapper[i].Target2 += offset;
                    }
                    catch { break; }
				}
			}
			finally
			{
				this.Parent.Cursor = Cursors.Default;
			}

			internalchg = savedstate;
			myrepaint();
			if (csel >= 0)
				flowitems[csel].Focus();
		}

		public void DeleteUnlinked()
		{
			if (csel < 0) return;

			bool savedstate = internalchg;
			internalchg = true;
			this.Parent.Cursor = Cursors.WaitCursor;

			while(csel < wrapper.Count && wrapper.Count > 1)
				wrapper.RemoveAt(wrapper.Count-1);

			this.Parent.Cursor = Cursors.Default;
			internalchg = savedstate;

			csel = -1;
			myrepaint();
			int index = wrapper.Count - 1;
			if (index >= 0) flowitems[index].Focus();
		}


		private void myrepaint()
		{
            SimPe.RemoteControl.ApplicationForm.Cursor = Cursors.WaitCursor;
            //this.Parent.Cursor = Cursors.WaitCursor;
			//SimPe.Wait.Start(wrapper.Count);
			try
			{
				this.SuspendLayout();
				bool v = this.Visible;
				this.Visible = false;

				this.Controls.Clear();
				if (flowitems != null)
					for(int i = 0; i < flowitems.Length; i++) if (flowitems[i] != null) { flowitems[i].Dispose(); flowitems[i] = null; }
				flowitems = new BhavInstListItemUI[wrapper.Count];

				for (int i = 0; i < wrapper.Count; i++)
				{
					flowitems[i] = makeBhavInstListItemUI(i);
					//SimPe.Wait.Progress = i;
				}

				if (csel >= 0) flowitems[csel].MakeSelected();

				pnflow.Image = DrawConnectors();
				this.Controls.Add(pnflow);

				this.Visible = true;
				this.ResumeLayout(true);
			}
			finally
			{
                SimPe.RemoteControl.ApplicationForm.Cursor = Cursors.Default;
                //this.Parent.Cursor = Cursors.Default;
                //SimPe.Wait.Stop();
			}
		}

		private BhavInstListItemUI makeBhavInstListItemUI(int ct)
		{
			bool isTarget = false;
			for (int j = 0; j < wrapper.Count && !isTarget; j++)
				if (ct == 0 || (j != ct && (
					(wrapper[j].Target1 == ct) ||
					(wrapper[j].Target2 == ct)
					)))
					isTarget = true;

			BhavInstListItemUI i = new BhavInstListItemUI();

			i.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			i.Left = this.AutoScrollPosition.X;
			i.Top = ct*(i.Height+4) + this.AutoScrollPosition.Y;
			i.Width = this.ClientRectangle.Width - pnflow.Width;
			i.Index = ct;
			i.TabIndex = ct;
			i.TabStop = true;

			i.MoveUp += new EventHandler(bhavInst_MoveUp);
			i.MoveDown += new EventHandler(bhavInst_MoveDown);
			i.Selected += new EventHandler(bhavInst_Selected);
			i.Unselected += new EventHandler(bhavInst_Unselected);
			i.TargetClick += new LinkLabelLinkClickedEventHandler(bhavInst_TargetClick);
			i.KeyDown += new KeyEventHandler(bhavInst_KeyDown);

			this.Controls.Add(i);
			this.Controls.SetChildIndex(i, ct);

			i.Wrapper = wrapper;

			return i;
		}

		private Bitmap DrawConnectors()
		{
			if (flowitems == null || flowitems.Length == 0)
				return null;
			if (this.ClientRectangle.Width < pnflow.Width)
				return null;

			Bitmap img = new Bitmap(pnflow.Width, flowitems.Length * (BhavInstListItemUI.rowHeight + 4));
			Graphics gr = Graphics.FromImage(img);
			gr.SmoothingMode =  System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			gr.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
			gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

			Pen tpen = new Pen(Color.FromArgb(0, 128, 0), 1);
			Pen fpen = new Pen(Color.FromArgb(128, 0, 0), 1);
			Pen tpeni = new Pen(Color.FromArgb(0, 220, 0), 3);
			Pen fpeni = new Pen(Color.FromArgb(220, 0, 0), 3);
			Pen tpeno = tpen, fpeno = fpen, pen;
			Point[] points;

			int yUnit = BhavInstListItemUI.rowHeight / 8;

			foreach (Connector c in Connector.Connectors(wrapper))
			{
				if (c==null) continue;
				//if (c.start == c.stop) continue; // skip go to self
				if (c.start >= flowitems.Length) continue;

				if (c.truerule) pen = tpen; else pen = fpen;
				if (c.stop == csel)  if (c.truerule) pen = tpeni; else pen = fpeni;
				if (c.start == csel) if (c.truerule) pen = tpeno; else pen = fpeno;

				int yPosStart = (BhavInstListItemUI.rowHeight + 4) * c.start + (yUnit * 4) + (yUnit * (c.truerule ? 3 : 1));
				int xPosLeft = 0;
				int xPosRight;

				if (c.stop < flowitems.Length)
				{
					const int laneWidth = 5;
					xPosRight = 7 + (c.lane * laneWidth);

					int yPosStop = (BhavInstListItemUI.rowHeight + 4) * c.stop + (yUnit * (c.truerule ? 1 : 3));

					gr.DrawLine( pen, xPosLeft,  yPosStart, xPosRight, yPosStart );
					gr.DrawLine( pen, xPosRight, yPosStart, xPosRight, yPosStop );
					gr.DrawLine( pen, xPosRight, yPosStop,  xPosLeft,  yPosStop );

					points = new Point[3];
					points[0] = new Point(xPosLeft, yPosStop);
					points[1] = new Point(points[0].X + 4, points[0].Y - 4);
					points[2] = new Point(points[0].X + 4, points[0].Y + 4);
					gr.FillPolygon(pen.Brush, points);
				}
				else
				{
					xPosRight = img.Width - (c.truerule ? 20 : 10);
					string glyph;
					string font = "Verdana";
					float pts = 8.25F;

					switch (c.stop)
					{
						case 0xFFFC: glyph = "E"; break; // Error
						case 0xFFFD: glyph = "T"; break; // True
						case 0xFFFE: glyph = "F"; break; // False
						default:     glyph = "?"; break; // Off the end
					}

					gr.DrawLine( pen, xPosLeft, yPosStart, xPosRight, yPosStart );
					gr.DrawString( glyph, new System.Drawing.Font(font, pts), pen.Brush, xPosRight, yPosStart - 8 );
				}
			}
			AddUnlinked(gr);
			return img;
		}

		private void AddUnlinked(Graphics gr)
		{
			Pen pen = new Pen(Color.FromArgb(64, 64, 64), 1);
			Pen penc = new Pen(pen.Color, 3);
			for (int ct = 1; ct < flowitems.Length; ct++)
			{
				if (isTarget(ct)) continue;

				int xPosLeft = 0;
				int xPosRight = pnflow.Width - 1;
				int yPos = (BhavInstListItemUI.rowHeight + 4) * ct + (BhavInstListItemUI.rowHeight / 4);

				gr.DrawLine(
					(ct == csel) ? penc : pen,
					xPosLeft, yPos,
					xPosRight, yPos
					);
				Point[] points = new Point[3];
				points[0] = new Point(xPosLeft, yPos);
				points[1] = new Point(points[0].X + 4, points[0].Y - 4);
				points[2] = new Point(points[0].X + 4, points[0].Y + 4);
				gr.FillPolygon(pen.Brush, points);
			}
		}

		private bool isTarget(int ct)
		{
			for (int i = 0; i < wrapper.Count; i++)
				if (wrapper[i].Target1 == ct || wrapper[i].Target2 == ct)
					return true;
			return false;
		}

		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BhavInstListControl));
			this.pnflow = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			//
			// pnflow
			//
			this.pnflow.AccessibleDescription = resources.GetString("pnflow.AccessibleDescription");
			this.pnflow.AccessibleName = resources.GetString("pnflow.AccessibleName");
			this.pnflow.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("pnflow.Anchor")));
			this.pnflow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnflow.BackgroundImage")));
			this.pnflow.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("pnflow.Dock")));
			this.pnflow.Enabled = ((bool)(resources.GetObject("pnflow.Enabled")));
			this.pnflow.Font = ((System.Drawing.Font)(resources.GetObject("pnflow.Font")));
			this.pnflow.Image = ((System.Drawing.Image)(resources.GetObject("pnflow.Image")));
			this.pnflow.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("pnflow.ImeMode")));
			this.pnflow.Location = ((System.Drawing.Point)(resources.GetObject("pnflow.Location")));
			this.pnflow.Name = "pnflow";
			this.pnflow.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("pnflow.RightToLeft")));
			this.pnflow.Size = ((System.Drawing.Size)(resources.GetObject("pnflow.Size")));
			this.pnflow.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode)(resources.GetObject("pnflow.SizeMode")));
			this.pnflow.TabIndex = ((int)(resources.GetObject("pnflow.TabIndex")));
			this.pnflow.TabStop = false;
			this.pnflow.Text = resources.GetString("pnflow.Text");
			this.pnflow.Visible = ((bool)(resources.GetObject("pnflow.Visible")));
			//
			// BhavInstListControl
			//
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.Controls.Add(this.pnflow);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.Name = "BhavInstListControl";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.Size = ((System.Drawing.Size)(resources.GetObject("$this.Size")));
			this.ResumeLayout(false);

		}

		#endregion

		private void bhavInst_MoveUp(object sender, System.EventArgs e) { MoveInst(-1); }
		private void bhavInst_MoveDown(object sender, System.EventArgs e) { MoveInst(1); }
		private void bhavInst_Selected(object sender, System.EventArgs e)
		{
			if (internalchg) return;
			SelectedIndex = (new ArrayList(flowitems)).IndexOf(sender);
		}
		private void bhavInst_Unselected(object sender, System.EventArgs e) {/* SelectedIndex = -1; */}
		private void bhavInst_TargetClick(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			int index = (UInt16)e.Link.LinkData;
			if (index >= 0) flowitems[index].Focus();
		}
		private void bhavInst_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case System.Windows.Forms.Keys.Up:
					if (csel > 0) flowitems[csel - 1].Focus();
					break;
				case System.Windows.Forms.Keys.Down:
					if (csel < flowitems.Length - 1) flowitems[csel + 1].Focus();
					break;
				case System.Windows.Forms.Keys.Delete:
					if (csel > -1 && flowitems.Length > 1) Delete(BhavUIDeleteType.Default);
					break;
				case System.Windows.Forms.Keys.Home:
					flowitems[0].Focus();
					break;
				case System.Windows.Forms.Keys.End:
					flowitems[flowitems.Length - 1].Focus();
					break;
			}
		}


	}


	#region Connector
	/// <summary>
	/// Used for Instruction Connectors
	/// </summary>
	internal class Connector : IComparable
	{
		/// <summary>
		/// Instruction number for start of connector
		/// </summary>
		public int start;
		/// <summary>
		/// Instruction number for end of connector
		/// </summary>
		public int stop;
		/// <summary>
		/// avoid collisions by keeping to lane
		/// </summary>
		public int lane = -1;
		/// <summary>
		/// True if this is connection from a True link
		/// </summary>
		public bool truerule;

		protected Connector(int start, int stop, bool truerule)
		{
			this.start = start;
			this.stop = stop;
			this.truerule = truerule;
		}


		/// <summary>
		/// Returns an array of pairs of Connector()s for the true and false targets of each instruction
		/// </summary>
		/// <param name="items">BhavInstList from wrapper</param>
		/// <returns></returns>
		public static Connector[] Connectors(Bhav bhav)
		{
			if (bhav == null || bhav == null) return new Connector[0];

			Connector[] cs = new Connector[bhav.Count*2];
			for (int i=0; i<bhav.Count; i++)
			{
				cs[i*2] = new Connector(i, bhav[i].Target1, true);
				cs[i*2+1] = new Connector(i, bhav[i].Target2, false);
			}

			Connector.ResolveCollisions(cs);
			return cs;
		}


		#region ResolveCollisions
		/// <summary>
		/// Returns "connector number" for inwards connector (to stop)
		/// </summary>
		private int InOffset
		{
			get
			{
				return 0 + (truerule ? 0 : 1);
			}
		}

		/// <summary>
		/// Returns "connector number" for outwards connector (from start)
		/// </summary>
		private int OutOffset
		{
			get
			{
				return 2 + (truerule ? 1 : 0);
			}
		}

		/// <summary>
		/// Which of 'start' and 'stop' is the earlier instruction
		/// </summary>
		private int Top
		{
			get { return Math.Min(start * 4 + OutOffset, stop * 4 + InOffset); }
		}

		/// <summary>
		/// Which of 'start' and 'stop' is the later instruction
		/// </summary>
		private int Bottom
		{
			get { return Math.Max(start * 4 + OutOffset, stop * 4 + InOffset); }
		}

		/// <summary>
		/// Resolves all lane Collisions
		/// </summary>
		/// <param name="connectors">List of connectors</param>
		private static void ResolveCollisions(Connector[] connectors)
		{
			ArrayList ac = new ArrayList(connectors);
			ac.Sort();
			foreach (Connector c1 in ac)
			{
				c1.lane = -1;
				if (c1.stop * 2 > connectors.Length) continue; // off end, doesn't use a lane
				//if (c1.stop == c1.start + 1) continue; // next line, doesn't use a lane
				//if (c1.stop == c1.start) continue; // same line, doesn't use a lane

				ArrayList used = new ArrayList();
				foreach (Connector c2 in connectors)
				{
					if (c2.lane == -1) continue; // it's not using a lane

					if (c2.Top > c1.Bottom) continue; // c1 completely before c2 - skip
					if (c2.Bottom < c1.Top) continue; // c1 completely after c2 - skip
					//if (c2.truerule == c1.truerule && c2.stop == c1.stop) continue; // same target - skip

					// At this point c2 could be using a lane c1 wants to use
					used.Add((Int16) c2.lane);
				}
				used.Sort();
				c1.lane = 0;
				foreach (Int16 i in used)
					if (c1.lane == i) c1.lane++;
			}
		}
		#endregion

		#region IComparable Members

		public int CompareTo(object obj)
		{
			if (obj.GetType() != typeof(Connector))
				return this.GetHashCode().CompareTo(base.GetHashCode());

			Connector c = (Connector)obj;
			int i = c.Bottom - c.Top;
			int j = this.Bottom - this.Top;
			return j.CompareTo(i);
		}

		#endregion
	}

	#endregion

	#region Enums for readability
	public enum BhavUIAddType : int
	{
		 Default = 0
		,ViaTrue = 1
		,ViaFalse = 2
        ,Unlinked = 3
	}

	public enum BhavUIDeleteType : int
	{
		 Default = 0
		,Pescado = 1
	}
	#endregion
}
