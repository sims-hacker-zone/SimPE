using System.Windows.Forms;

namespace SimPe
{
	/// <summary>
	/// Summary description for FileTableItemForm.
	/// </summary>
	public class FileTableItemForm : Form
	{
		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel1;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Label label1;
		private Label label2;
		private Label label3;
		private CheckBox cbRec;
		private TextBox tbName;
		private TextBox tbRoot;
		private ComboBox cbEpVer;
		private Button button1;
		private Button button2;
		private Button button3;
		private FolderBrowserDialog fbd;
		private OpenFileDialog ofd;

		public FileTableItemForm()
		{
			InitializeComponent();

			ofd.Filter = ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					ExtensionType.Package,
					ExtensionType.AllFiles,
				}
			);

			cbEpVer.Items.Clear();
			cbEpVer.Items.Add(Localization.GetString("All"));
			foreach (ExpansionItem ei in PathProvider.Global.Expansions)
			{
				cbEpVer.Items.Add(ei.Name);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(FileTableItemForm)
				);
			xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			button3 = new Button();
			button2 = new Button();
			button1 = new Button();
			cbEpVer = new ComboBox();
			tbRoot = new TextBox();
			tbName = new TextBox();
			cbRec = new CheckBox();
			label3 = new Label();
			label2 = new Label();
			label1 = new Label();
			fbd = new FolderBrowserDialog();
			ofd = new OpenFileDialog();
			xpGradientPanel1.SuspendLayout();
			SuspendLayout();
			//
			// xpGradientPanel1
			//
			xpGradientPanel1.BackColor = System.Drawing.Color.Transparent;
			xpGradientPanel1.Controls.Add(button3);
			xpGradientPanel1.Controls.Add(button2);
			xpGradientPanel1.Controls.Add(button1);
			xpGradientPanel1.Controls.Add(cbEpVer);
			xpGradientPanel1.Controls.Add(tbRoot);
			xpGradientPanel1.Controls.Add(tbName);
			xpGradientPanel1.Controls.Add(cbRec);
			xpGradientPanel1.Controls.Add(label3);
			xpGradientPanel1.Controls.Add(label2);
			xpGradientPanel1.Controls.Add(label1);
			resources.ApplyResources(xpGradientPanel1, "xpGradientPanel1");
			xpGradientPanel1.Name = "xpGradientPanel1";
			//
			// button3
			//
			resources.ApplyResources(button3, "button3");
			button3.Name = "button3";
			button3.Click += new System.EventHandler(button3_Click);
			//
			// button2
			//
			resources.ApplyResources(button2, "button2");
			button2.Name = "button2";
			button2.Click += new System.EventHandler(button2_Click);
			//
			// button1
			//
			resources.ApplyResources(button1, "button1");
			button1.Name = "button1";
			button1.Click += new System.EventHandler(button1_Click);
			//
			// cbEpVer
			//
			cbEpVer.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			resources.ApplyResources(cbEpVer, "cbEpVer");
			cbEpVer.Name = "cbEpVer";
			//
			// tbRoot
			//
			resources.ApplyResources(tbRoot, "tbRoot");
			tbRoot.Name = "tbRoot";
			tbRoot.ReadOnly = true;
			//
			// tbName
			//
			resources.ApplyResources(tbName, "tbName");
			tbName.Name = "tbName";
			tbName.TextChanged += new System.EventHandler(tbName_TextChanged);
			//
			// cbRec
			//
			resources.ApplyResources(cbRec, "cbRec");
			cbRec.Name = "cbRec";
			cbRec.UseVisualStyleBackColor = false;
			//
			// label3
			//
			label3.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// label2
			//
			label2.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// label1
			//
			label1.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// FileTableItemForm
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(xpGradientPanel1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Name = "FileTableItemForm";
			xpGradientPanel1.ResumeLayout(false);
			xpGradientPanel1.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		bool ok;
		bool file;

		public static FileTableItem Execute()
		{
			FileTableItem fti = new FileTableItem("", false, false);

			if (Execute(fti))
			{
				return fti;
			}
			else
			{
				return null;
			}
		}

		public static bool Execute(FileTableItem fti)
		{
			FileTableItemForm f = new FileTableItemForm();
			f.tbName.Text = fti.Name;
			f.tbRoot.Text = fti.Type.ToString();
			if (fti.EpVersion + 1 < f.cbEpVer.Items.Count)
			{
				f.cbEpVer.SelectedIndex = fti.EpVersion + 1;
			}
			else
			{
				ExpansionItem ei = PathProvider.Global[fti.EpVersion];
				for (int i = 0; i < f.cbEpVer.Items.Count; i++)
				{
					if (f.cbEpVer.Items[i].ToString() == ei.Name)
					{
						f.cbEpVer.SelectedIndex = i;
						break;
					}
				}
			}
			f.cbRec.Checked = fti.IsRecursive;
			f.ok = false;
			f.file = fti.IsFile;
			f.UpdateRec();

			f.ShowDialog();

			if (f.ok)
			{
				fti.Type = FileTablePaths.Absolute;
				fti.Name = f.tbName.Text.Trim();
				fti.IsRecursive = f.cbRec.Checked;
				string epname = f.cbEpVer.Text;
				foreach (ExpansionItem ei in PathProvider.Global.Expansions)
				{
					if (ei.Name == epname)
					{
						fti.EpVersion = ei.Version;
					}
				}

				fti.IsFile = f.file;

				return true;
			}

			return false;
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			ok = true;
			Close();
		}

		void UpdateType()
		{
			FileTableItem fti = new FileTableItem(tbName.Text, false, file)
			{
				Name = tbName.Text
			};

			tbRoot.Text = fti.Type.ToString();
		}

		void UpdateRec()
		{
			cbRec.Enabled = !file;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				file = false;
				tbName.Text = fbd.SelectedPath;

				UpdateType();
				UpdateRec();
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				file = true;
				tbName.Text = ofd.FileName;

				UpdateType();
				UpdateRec();
			}
		}

		private void tbName_TextChanged(object sender, System.EventArgs e)
		{
		}
	}
}
