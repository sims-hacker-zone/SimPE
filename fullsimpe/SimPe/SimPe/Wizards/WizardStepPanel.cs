// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Wizards
{
	/// <summary>
	/// Abstract Implementaion of a Wizard Step
	/// </summary>
	[ToolboxBitmap(typeof(Panel))]
	public class WizardStepPanel : Panel
	{
		public WizardStepPanel()
		{
			BackColor = Color.Transparent;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (DesignMode)
			{
				SizeF sz = e.Graphics.MeasureString(HintName, Font);
				e.Graphics.DrawString(
					HintName,
					Font,
					new SolidBrush(Color.FromArgb(130, ForeColor)),
					(int)(Width - sz.Width) - 2,
					(int)(Height - sz.Height) - 2
				);
			}
		}

		internal string HintName => "Step "
					+ Index.ToString()
					+ " ("
					+ Name /*+" in "+this.ParentWizard.Text*/
					+ ")";

		#region IWizardStep Member

		[Browsable(false)]
		public Control Client => this;

		internal void SetupParent(Wizard parent)
		{
			ParentWizard = parent;
			Index = 0;
			if (parent == null)
			{
				return;
			}

			Index = parent.Controls.Count - 1;
			First = Index == 0;

			parent.Aborted += new WizardHandle(OnAborted);
			parent.Finished += new WizardHandle(OnFinished);
			parent.Loaded += new WizardHandle(OnLoaded);
		}

		internal void RemoveParent(Wizard parent)
		{
			if (parent == null)
			{
				return;
			}

			parent.Aborted -= new WizardHandle(OnAborted);
			parent.Finished -= new WizardHandle(OnFinished);
			parent.Loaded -= new WizardHandle(OnLoaded);
		}

		public Wizard ParentWizard
		{
			get; private set;
		}

		public bool First
		{
			get; set;
		}

		public bool Last
		{
			get; set;
		}

		public int Index
		{
			get; private set;
		}

		protected void OnLoaded(Wizard sender)
		{
			if (Loaded != null)
			{
				Loaded(sender, this);
			}
		}

		protected void OnAborted(Wizard sender)
		{
			if (Aborted != null)
			{
				Aborted(sender, this);
			}
		}

		protected void OnFinished(Wizard sender)
		{
			if (Finished != null)
			{
				Finished(sender, this);
			}
		}

		internal void OnPrepare(Wizard sender, int target)
		{
			if (Prepare != null)
			{
				Prepare(sender, this, target);
			}
		}

		internal void OnRollback(Wizard sender, int target)
		{
			if (Rollback != null)
			{
				Rollback(sender, this, target);
			}
		}

		internal void OnShow(Wizard sender, WizardEventArgs e)
		{
			if (Activate != null)
			{
				Activate(sender, e);
			}
		}

		internal void OnShowed(Wizard sender)
		{
			if (Activated != null)
			{
				Activated(sender, this);
			}
		}

		public event WizardStepHandle Loaded;
		public event WizardStepHandle Aborted;
		public event WizardStepHandle Finished;

		public event WizardStepChangeHandle Prepare;
		public event WizardStepChangeHandle Rollback;
		public event WizardChangeHandle Activate;
		public event WizardStepHandle Activated;

		#endregion
	}
}
