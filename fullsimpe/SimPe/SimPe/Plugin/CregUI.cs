using System;
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
    public partial class CregPackedFileUI : SimPe.Windows.Forms.WrapperBaseControl, IPackedFileUI
    {
        protected new CregPackedFileWrapper Wrapper
        {
            get { return base.Wrapper as CregPackedFileWrapper; }
        }
        public CregPackedFileWrapper TPFW
        {
            get { return (CregPackedFileWrapper)Wrapper; }
        }

        #region WrapperBaseControl Member

        bool intern;

        public CregPackedFileUI()
        {
            InitializeComponent();
        }

        protected override void RefreshGUI()
        {
            base.RefreshGUI();
            intern = true;
            if (Helper.WindowsRegistry.UseBigIcons)
            {
                this.rtbContent.Size = new System.Drawing.Size(530, this.rtbContent.Size.Height);
                this.rtbContent.Font = new System.Drawing.Font(this.rtbContent.Font.FontFamily, 12F);
            }

            this.rtbContent.Text = "";
            this.tbGuid.Text = Wrapper.GooiVal;
            this.tbCrc.Text = Wrapper.CRCVal;
            this.tbVer.Text = Wrapper.VersVal;

            if (Wrapper.Vesion == 1)
            {
                this.CanCommit = false;
                this.rtbContent.Visible = true;
                for (int i = 0; i < Wrapper.Qunty; i++)
                {
                    this.rtbContent.Text += Wrapper.Conent[i] + "\r\n";
                }
            }
            else
            {
                this.CanCommit = true;
                this.rtbContent.Visible = false;
            }
            intern = false;
        }

        public override void OnCommit()
        {
            base.OnCommit();
            TPFW.SynchronizeUserData(true, false);
        }
        #endregion

        #region IPackedFileUI Member
        System.Windows.Forms.Control IPackedFileUI.GUIHandle
        {
            get { return this; }
        }
        #endregion

        #region IDisposable Member

        void IDisposable.Dispose()
        {
            this.TPFW.Dispose();
        }
        #endregion

        private void tbVer_TextChanged(object sender, EventArgs e)
        {
            if (!intern) Wrapper.VersVal = this.tbVer.Text;
        }

    }
}
