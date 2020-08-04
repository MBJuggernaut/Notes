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
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }       
    }
}
