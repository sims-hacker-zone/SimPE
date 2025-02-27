namespace SimPe.Plugin
{
	partial class ChoicePanel
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbChoice = new System.Windows.Forms.Label();
			this.tbChoice = new System.Windows.Forms.TextBox();
			this.lnudCooking = new SimPe.Plugin.LabelledNumericUpDown();
			this.lnudMechanical = new SimPe.Plugin.LabelledNumericUpDown();
			this.lnudCharisma = new SimPe.Plugin.LabelledNumericUpDown();
			this.lnudBody = new SimPe.Plugin.LabelledNumericUpDown();
			this.lnudCreativity = new SimPe.Plugin.LabelledNumericUpDown();
			this.lnudLogic = new SimPe.Plugin.LabelledNumericUpDown();
			this.lnudCleaning = new SimPe.Plugin.LabelledNumericUpDown();
			this.SuspendLayout();
			//
			// lbChoice
			//
			this.lbChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbChoice.AutoSize = true;
			this.lbChoice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbChoice.Location = new System.Drawing.Point(0, 28);
			this.lbChoice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbChoice.Name = "lbChoice";
			this.lbChoice.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.lbChoice.Size = new System.Drawing.Size(47, 17);
			this.lbChoice.TabIndex = 1;
			this.lbChoice.Text = "ChoiceX";
			this.lbChoice.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// tbChoice
			//
			this.tbChoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbChoice.Location = new System.Drawing.Point(55, 24);
			this.tbChoice.Margin = new System.Windows.Forms.Padding(2);
			this.tbChoice.Name = "tbChoice";
			this.tbChoice.Size = new System.Drawing.Size(71, 20);
			this.tbChoice.TabIndex = 2;
			this.tbChoice.Text = "ChoiceX";
			//
			// lnudCooking
			//
			this.lnudCooking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lnudCooking.AutoSize = true;
			this.lnudCooking.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lnudCooking.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.lnudCooking.Label = "Cooking";
			this.lnudCooking.LabelAnchor = System.Windows.Forms.AnchorStyles.Top;
			this.lnudCooking.Location = new System.Drawing.Point(128, 0);
			this.lnudCooking.Margin = new System.Windows.Forms.Padding(0);
			this.lnudCooking.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.lnudCooking.Minimum = new decimal(new int[] {
			10,
			0,
			0,
			-2147483648});
			this.lnudCooking.Name = "lnudCooking";
			this.lnudCooking.NoLabel = false;
			this.lnudCooking.ReadOnly = false;
			this.lnudCooking.Size = new System.Drawing.Size(66, 48);
			this.lnudCooking.TabIndex = 3;
			this.lnudCooking.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			this.lnudCooking.ValueSize = new System.Drawing.Size(60, 20);
			//
			// lnudMechanical
			//
			this.lnudMechanical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lnudMechanical.AutoSize = true;
			this.lnudMechanical.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lnudMechanical.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.lnudMechanical.Label = "Mechanical";
			this.lnudMechanical.LabelAnchor = System.Windows.Forms.AnchorStyles.Top;
			this.lnudMechanical.Location = new System.Drawing.Point(202, 0);
			this.lnudMechanical.Margin = new System.Windows.Forms.Padding(0);
			this.lnudMechanical.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.lnudMechanical.Minimum = new decimal(new int[] {
			10,
			0,
			0,
			-2147483648});
			this.lnudMechanical.Name = "lnudMechanical";
			this.lnudMechanical.NoLabel = false;
			this.lnudMechanical.ReadOnly = false;
			this.lnudMechanical.Size = new System.Drawing.Size(68, 48);
			this.lnudMechanical.TabIndex = 4;
			this.lnudMechanical.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			this.lnudMechanical.ValueSize = new System.Drawing.Size(60, 20);
			//
			// lnudCharisma
			//
			this.lnudCharisma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lnudCharisma.AutoSize = true;
			this.lnudCharisma.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lnudCharisma.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.lnudCharisma.Label = "Charisma";
			this.lnudCharisma.LabelAnchor = System.Windows.Forms.AnchorStyles.Top;
			this.lnudCharisma.Location = new System.Drawing.Point(278, 0);
			this.lnudCharisma.Margin = new System.Windows.Forms.Padding(0);
			this.lnudCharisma.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.lnudCharisma.Minimum = new decimal(new int[] {
			10,
			0,
			0,
			-2147483648});
			this.lnudCharisma.Name = "lnudCharisma";
			this.lnudCharisma.NoLabel = false;
			this.lnudCharisma.ReadOnly = false;
			this.lnudCharisma.Size = new System.Drawing.Size(66, 48);
			this.lnudCharisma.TabIndex = 5;
			this.lnudCharisma.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			this.lnudCharisma.ValueSize = new System.Drawing.Size(60, 20);
			//
			// lnudBody
			//
			this.lnudBody.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lnudBody.AutoSize = true;
			this.lnudBody.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lnudBody.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.lnudBody.Label = "Body";
			this.lnudBody.LabelAnchor = System.Windows.Forms.AnchorStyles.Top;
			this.lnudBody.Location = new System.Drawing.Point(352, 0);
			this.lnudBody.Margin = new System.Windows.Forms.Padding(0);
			this.lnudBody.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.lnudBody.Minimum = new decimal(new int[] {
			10,
			0,
			0,
			-2147483648});
			this.lnudBody.Name = "lnudBody";
			this.lnudBody.NoLabel = false;
			this.lnudBody.ReadOnly = false;
			this.lnudBody.Size = new System.Drawing.Size(66, 48);
			this.lnudBody.TabIndex = 6;
			this.lnudBody.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			this.lnudBody.ValueSize = new System.Drawing.Size(60, 20);
			//
			// lnudCreativity
			//
			this.lnudCreativity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lnudCreativity.AutoSize = true;
			this.lnudCreativity.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lnudCreativity.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.lnudCreativity.Label = "Creativity";
			this.lnudCreativity.LabelAnchor = System.Windows.Forms.AnchorStyles.Top;
			this.lnudCreativity.Location = new System.Drawing.Point(426, 0);
			this.lnudCreativity.Margin = new System.Windows.Forms.Padding(0);
			this.lnudCreativity.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.lnudCreativity.Minimum = new decimal(new int[] {
			10,
			0,
			0,
			-2147483648});
			this.lnudCreativity.Name = "lnudCreativity";
			this.lnudCreativity.NoLabel = false;
			this.lnudCreativity.ReadOnly = false;
			this.lnudCreativity.Size = new System.Drawing.Size(66, 48);
			this.lnudCreativity.TabIndex = 7;
			this.lnudCreativity.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			this.lnudCreativity.ValueSize = new System.Drawing.Size(60, 20);
			//
			// lnudLogic
			//
			this.lnudLogic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lnudLogic.AutoSize = true;
			this.lnudLogic.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lnudLogic.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.lnudLogic.Label = "Logic";
			this.lnudLogic.LabelAnchor = System.Windows.Forms.AnchorStyles.Top;
			this.lnudLogic.Location = new System.Drawing.Point(500, 0);
			this.lnudLogic.Margin = new System.Windows.Forms.Padding(0);
			this.lnudLogic.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.lnudLogic.Minimum = new decimal(new int[] {
			10,
			0,
			0,
			-2147483648});
			this.lnudLogic.Name = "lnudLogic";
			this.lnudLogic.NoLabel = false;
			this.lnudLogic.ReadOnly = false;
			this.lnudLogic.Size = new System.Drawing.Size(66, 48);
			this.lnudLogic.TabIndex = 8;
			this.lnudLogic.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			this.lnudLogic.ValueSize = new System.Drawing.Size(60, 20);
			//
			// lnudCleaning
			//
			this.lnudCleaning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lnudCleaning.AutoSize = true;
			this.lnudCleaning.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lnudCleaning.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.lnudCleaning.Label = "Cleaning";
			this.lnudCleaning.LabelAnchor = System.Windows.Forms.AnchorStyles.Top;
			this.lnudCleaning.Location = new System.Drawing.Point(574, 0);
			this.lnudCleaning.Margin = new System.Windows.Forms.Padding(0);
			this.lnudCleaning.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.lnudCleaning.Minimum = new decimal(new int[] {
			10,
			0,
			0,
			-2147483648});
			this.lnudCleaning.Name = "lnudCleaning";
			this.lnudCleaning.NoLabel = false;
			this.lnudCleaning.ReadOnly = false;
			this.lnudCleaning.Size = new System.Drawing.Size(66, 48);
			this.lnudCleaning.TabIndex = 9;
			this.lnudCleaning.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
			this.lnudCleaning.ValueSize = new System.Drawing.Size(60, 20);
			//
			// ChoicePanel
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.lnudCleaning);
			this.Controls.Add(this.lnudLogic);
			this.Controls.Add(this.lnudCreativity);
			this.Controls.Add(this.lnudBody);
			this.Controls.Add(this.lnudCharisma);
			this.Controls.Add(this.lnudMechanical);
			this.Controls.Add(this.lnudCooking);
			this.Controls.Add(this.tbChoice);
			this.Controls.Add(this.lbChoice);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "ChoicePanel";
			this.Size = new System.Drawing.Size(640, 48);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbChoice;
		private LabelledNumericUpDown lnudCooking;
		private LabelledNumericUpDown lnudMechanical;
		private LabelledNumericUpDown lnudCharisma;
		private LabelledNumericUpDown lnudBody;
		private LabelledNumericUpDown lnudCreativity;
		private LabelledNumericUpDown lnudLogic;
		private LabelledNumericUpDown lnudCleaning;
		private System.Windows.Forms.TextBox tbChoice;


	}
}
