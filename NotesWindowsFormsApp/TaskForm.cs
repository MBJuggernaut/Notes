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
    public partial class TaskForm : Form
    {
        public TaskForm()
        {
            InitializeComponent();
            HoursComboBox.Text = "00";
            MinutesComboBox.Text = "00";
            OkButton.Enabled = false;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CommentTextBox_TextChanged(object sender, EventArgs e)
        {
            if(CommentTextBox.Text.Length<3)
            {
                OkButton.Enabled = false;
            }
            else
            {
                OkButton.Enabled = true;
            }
        }
    }
}
