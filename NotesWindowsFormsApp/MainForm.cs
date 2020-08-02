using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        string date;
        List<Task> listOftasks;
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
                trayIcon.ShowBalloonTip(1000);
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            trayIcon.Visible = false;
        }

        private void myCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            date = myCalendar.SelectionRange.Start.Day.ToString() + myCalendar.SelectionRange.Start.Month.ToString() + myCalendar.SelectionRange.Start.Year.ToString();
            Task task = new Task();
            task.Date = date;
            ToDoListDataGridView.Rows.Clear();
            listOftasks = task.GetAll();


            //listOftasks.Sort(Time);

            if (listOftasks != null)
            {
                foreach (var taskfromlist in listOftasks)
                {
                    ToDoListDataGridView.Rows.Add(taskfromlist.Time, taskfromlist.Text);
                }
            }
        }

        private void ToDoListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var editedTask = new Task();
            editedTask.Time = Convert.ToString(ToDoListDataGridView.CurrentRow.Cells[0].Value);
            editedTask.Text = Convert.ToString(ToDoListDataGridView.CurrentRow.Cells[1].Value);
            editedTask.Date = date;            
            if (listOftasks == null)
            {
                listOftasks = new List<Task>();
            }
            if (listOftasks.Count < ToDoListDataGridView.CurrentRow.Index+1)
                listOftasks.Add(editedTask);
            else
                listOftasks[ToDoListDataGridView.CurrentRow.Index] = editedTask;

            var jsonTasks = JsonConvert.SerializeObject(listOftasks, Formatting.Indented);
            var path = date + ".json";
            FileProvider.Replace(path, jsonTasks);
        }
    }
}
