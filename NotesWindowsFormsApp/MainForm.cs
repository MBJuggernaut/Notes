using System;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        Note myNote;
        private void MainForm_Load(object sender, EventArgs e)
        {
            myNote = new Note();
            notesTextBox.Text = myNote.Text;
            notesTextBox.SelectedText = null;
            notesToolStripMenuItem.PerformClick();
        }

        private void notesTextBox_TextChanged(object sender, EventArgs e)
        {
            myNote.Text = notesTextBox.Text;
            myNote.Save();
        }

        private void todolistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            todolistPanel.Show();
            notesPanel.Hide();
        }

        private void notesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notesPanel.Show();
            notesPanel.Dock = DockStyle.Fill;
            notesTextBox.Dock = DockStyle.Fill;
            todolistPanel.Hide();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                trayIcon.Visible = true;
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            trayIcon.Visible = false;
        }
    }
}
