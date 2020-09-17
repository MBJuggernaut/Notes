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
    public partial class TagsForm : Form
    {
        public TagsForm()
        {
            InitializeComponent();
        }

        private void TagsForm_Load(object sender, EventArgs e)
        {                        

        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            if (newTagTextBox.Text != "")
            {
                tagsDataGridView.Rows.Add(newTagTextBox.Text);

                using (var context = new TaskContext())
                {
                    context.Tags.Add(new Tag { Text = newTagTextBox.Text });
                    context.SaveChanges();
                }
                newTagTextBox.Text = null;
            }
        }

        private void newTagTextBox_Click(object sender, EventArgs e)
        {
            newTagTextBox.Text = null;
        }

        private void tagsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tagsDataGridView.Columns[e.ColumnIndex] == TagsFormDeleteButton)
            {
                var textOfTagToDelete = tagsDataGridView.Rows[e.RowIndex]?.Cells[0]?.Value?.ToString();
                if (textOfTagToDelete != null)
                {
                    if (MessageBox.Show("Вы точно хотите удалить этот тэг?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var context = new TaskContext())
                        {
                            ;
                            var tagToDelete = context.Tags.FirstOrDefault(t => t.Text == textOfTagToDelete);
                            context.Tags.Remove(tagToDelete);
                            context.SaveChanges();
                        }
                        tagsDataGridView.Rows.RemoveAt(e.RowIndex);
                    }
                }

            }
        }
    }
}
