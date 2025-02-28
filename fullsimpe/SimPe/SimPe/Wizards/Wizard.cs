// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Wizards
{
	/// <summary>
	/// This implements a basic Wizard
	/// </summary>
	[
		Designer(typeof(WizardDesigner)),
		ToolboxBitmap(typeof(TabControl))
	]
	public class Wizard : Panel
	{
		int cur;

		public Wizard()
		{
			BackColor = Color.Transparent;
			DockPadding.All = 8;

			img = null;
			ControlAdded += new ControlEventHandler(Wizard_ControlAdded);
			ControlRemoved += new ControlEventHandler(Wizard_ControlRemoved);
		}

		internal bool Contains(WizardStepPanel iws)
		{
			return Controls.Contains(iws);
		}

		#region IWizard Member

		[Browsable(false)]
		public Control WizardContainer => this;

		Image img;
		public virtual Image Image
		{
			get => img;
			set => img = value;
		}

		public int StepCount => Controls.Count;

		public int CurrentStepNumber
		{
			get => cur;
			set
			{
				if (value == cur)
				{
					JumpToStep(value);
				}
			}
		}

		[Browsable(false)]
		public WizardStepPanel CurrentStep => (WizardStepPanel)Controls[cur];

		bool ne;

		[Browsable(false)]
		public bool NextEnabled
		{
			get => ne;
			set
			{
				if (value != ne)
				{
					ne = value;
					if (ChangedNextState != null)
					{
						ChangedNextState(this);
					}
				}
			}
		}

		bool pe;

		[Browsable(false)]
		public bool PrevEnabled
		{
			get => pe;
			set
			{
				if (value != pe)
				{
					pe = value;
					if (ChangedNextState != null)
					{
						ChangedPrevState(this);
					}
				}
			}
		}

		bool fe;

		[Browsable(false)]
		public bool FinishEnabled
		{
			get => fe;
			set
			{
				if (value != fe)
				{
					fe = value;
					if (ChangedNextState != null)
					{
						ChangedFinishState(this);
					}
				}
			}
		}

		public bool JumpToStep(int nr)
		{
			if (nr < 0)
			{
				return false;
			}

			if (nr >= Controls.Count)
			{
				return false;
			}

			if (DesignMode)
			{
				CurrentStep.Client.Visible = false;
				cur = nr;
				CurrentStep.Client.Visible = true;
				return false;
			}
			int lastnr = cur;
			if (nr >= cur)
			{
				for (int i = cur + 1; i <= nr; i++)
				{
					((WizardStepPanel)Controls[i]).OnPrepare(this, nr);
					if (PrepareStep != null)
					{
						PrepareStep(this, (WizardStepPanel)Controls[i], nr);
					}
				}
			}
			else
			{
				for (int i = cur; i > nr; i--)
				{
					((WizardStepPanel)Controls[i]).OnRollback(this, nr);
					if (RollbackStep != null)
					{
						RollbackStep(this, (WizardStepPanel)Controls[i], nr);
					}
				}

				((WizardStepPanel)Controls[nr]).OnPrepare(this, nr);
				if (PrepareStep != null)
				{
					PrepareStep(this, (WizardStepPanel)Controls[nr], nr);
				}
			}
			WizardEventArgs e = new WizardEventArgs(
				(WizardStepPanel)Controls[nr],
				!((WizardStepPanel)Controls[nr]).Last,
				!((WizardStepPanel)Controls[nr]).First,
				((WizardStepPanel)Controls[nr]).Last
			);
			((WizardStepPanel)Controls[nr]).OnShow(this, e);

			if (e.Cancel)
			{
				return false;
			}

			if (ShowStep != null)
			{
				ShowStep(this, e);
			}

			if (e.Cancel)
			{
				return false;
			}

			foreach (Control c in Controls)
			{
				c.Visible = false;
			}

			CurrentStep.Client.Visible = false;
			cur = nr;
			CurrentStep.Client.Visible = true;
			NextEnabled = e.EnableNext;
			PrevEnabled = e.EnablePrev;
			FinishEnabled = e.CanFinish;

			((WizardStepPanel)Controls[nr]).OnShowed(this);
			if (ShowedStep != null)
			{
				ShowedStep(this, lastnr);
			}

			return true;
		}

		public void Start()
		{
			if (Loaded != null)
			{
				Loaded(this);
			}

			cur = 0;
			JumpToStep(0);
		}

		public bool GoNext()
		{
			return JumpToStep(CurrentStepNumber + 1);
		}

		public bool GoPrev()
		{
			return JumpToStep(CurrentStepNumber - 1);
		}

		public void Finish()
		{
			if (Finished != null)
			{
				Finished(this);
			}
		}

		public void Abort()
		{
			if (Aborted != null)
			{
				Aborted(this);
			}
		}

		public event WizardHandle Loaded;

		public event WizardHandle Aborted;

		public event WizardHandle Finished;

		public event WizardStepChangeHandle PrepareStep;

		public event WizardStepChangeHandle RollbackStep;

		public event WizardChangeHandle ShowStep;

		public event WizardShowedHandle ShowedStep;

		public event WizardHandle ChangedNextState;

		public event WizardHandle ChangedPrevState;

		public event WizardHandle ChangedFinishState;

		#endregion

		internal string HintName => Text + " (" + Name + ")";

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (DesignMode)
			{
				e.Graphics.DrawRectangle(
					new Pen(Color.FromArgb(90, Color.DarkRed), 1),
					0,
					0,
					Width - 1,
					Height - 1
				);
				SizeF sz = e.Graphics.MeasureString(HintName, Font);
				e.Graphics.DrawString(
					HintName,
					Font,
					new SolidBrush(Color.FromArgb(90, Color.DarkRed)),
					2,
					(int)(Height - sz.Height) - 2
				);
			}
		}

		private void Wizard_ControlAdded(object sender, ControlEventArgs e)
		{
			//MessageBox.Show("adding");
			if (!(e.Control is WizardStepPanel))
			{
				Controls.Remove(e.Control);
				return;
			}
			//MessageBox.Show("doadd");

			WizardStepPanel iws = null;
			for (int i = Controls.Count - 1; i >= 0; i--)
			{
				Control c = Controls[i];
				if (c is WizardStepPanel)
				{
					if (iws == null)
					{
						iws = (WizardStepPanel)c;
					}
					else
					{
						((WizardStepPanel)c).Last = false;
						((WizardStepPanel)c).Visible = false;
					}
				}
			}
			if (iws == null)
			{
				return;
			}

			if (!DesignMode)
			{
				iws.Client.Visible = false;
			}

			iws.SetupParent(this);
			iws.Client.Parent = WizardContainer;
			iws.Dock = DockStyle.Fill;
			iws.Last = true;
			iws.First = Controls.Count == 0;
			iws.Visible = true;
		}

		private void Wizard_ControlRemoved(object sender, ControlEventArgs e)
		{
			//MessageBox.Show("removing");
			if (!(e.Control is WizardStepPanel))
			{
				return;
			}
			//MessageBox.Show("doremoving");
			WizardStepPanel iws = (WizardStepPanel)e.Control;

			iws.RemoveParent(this);
			iws.Parent = null;
		}
	}
}
