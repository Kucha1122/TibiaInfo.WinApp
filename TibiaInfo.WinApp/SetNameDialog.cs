using System;
using System.Windows.Forms;

namespace TibiaInfo.WinApp
{
    public partial class SetNameDialog : Form
    {
        public string CharacterName { get; set; }
        public SetNameDialog()
        {
            CharacterName = "";
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
        private void OkButton_Enter(object sender, EventArgs e)
        {
            CharacterName = characterNameTextBox.Text;
            OkButton.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Enter(object sender, EventArgs e)
        {
            CancelButton.DialogResult = DialogResult.Cancel;
        }
    }
}