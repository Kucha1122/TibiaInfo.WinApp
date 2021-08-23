using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using TibiaInfo.WinApp.Config;

namespace TibiaInfo.WinApp
{
    public partial class ApplicationForm : Form
    {
        private readonly FileSystemWatcher _fileSystemWatcher;
        private readonly ConfigurationFileManager _configurationFileManager;
        private readonly Settings _settings;

        public ApplicationForm()
        {
            InitializeComponent();
            CenterToParent();
            
            _fileSystemWatcher = new FileSystemWatcher();
            _configurationFileManager = new ConfigurationFileManager();
            _settings = _configurationFileManager.loadConfigFile();
            loadConfigurationSettings();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showApplicationForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _configurationFileManager.saveConfigFile(CharacterNameLabel.Text,
                HuntingSessionScannerCheckbox.Checked);
            Application.Exit();
        }

        private void ApplicationForm_Move(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showApplicationForm();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var setNameDialog = new SetNameDialog();

            if (setNameDialog.ShowDialog(this) == DialogResult.OK)
            {
                CharacterNameLabel.Text = setNameDialog.text
            }
        }
        
        private void ApplicationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _configurationFileManager.saveConfigFile(CharacterNameLabel.Text,
                HuntingSessionScannerCheckbox.Checked);
        }
        private void HuntingSessionScannerCheckbox_Click(object sender, EventArgs e)
        {
            _configurationFileManager.setHuntingSessionScanner(HuntingSessionScannerCheckbox.Checked); 
        }
        
        
        private void showApplicationForm()
        {
            Show();
            ShowInTaskbar = true;
            notifyIcon1.Visible = true;
            WindowState = FormWindowState.Normal;
        }
        
        private void loadConfigurationSettings()
        {
            try
            {
                HuntingSessionScannerCheckbox.Checked = _settings.HuntingSessionScanner;
                CharacterNameLabel.Text = _settings.CharacterName;
                DirectoryLocationLabel.Text = _settings.TibiaDirectoryLocation;
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong with configuration file.");
            }
        }

        private void ChangeDirectoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;

            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                DirectoryLocationLabel.Text = folderBrowserDialog.SelectedPath;
                _configurationFileManager.setTibiaDirectoryLocation(folderBrowserDialog.SelectedPath);
            }
        }
    }
}