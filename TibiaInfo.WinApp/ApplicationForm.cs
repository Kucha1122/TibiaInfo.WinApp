using System;
using System.IO;
using System.Windows.Forms;

namespace TibiaInfo.WinApp
{
    public partial class ApplicationForm : Form
    {
        private readonly FileSystemWatcher _fileSystemWatcher;
        public ApplicationForm()
        {
            _fileSystemWatcher = new FileSystemWatcher();
            InitializeComponent();
            CenterToParent();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showApplicationForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
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


        private void showApplicationForm()
        {
            Show();
            ShowInTaskbar = true;
            notifyIcon1.Visible = true;
            WindowState = FormWindowState.Normal;
        }
    }
}