using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            notesPanel.Dock = DockStyle.Fill;
            notesTextBox.Dock = DockStyle.Fill;
            todolistPanel.Hide();
        }

        private void notesTextBox_TextChanged(object sender, EventArgs e)
        {
            myNote.Text = notesTextBox.Text;
            myNote.Save();
        }
    }
}
