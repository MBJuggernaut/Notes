using System;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    public partial class TagsForm : Form
    {
        readonly TagDatabaseRepository tagManager;

        public TagsForm(TagDatabaseRepository tagDatabaseRepository)
        {
            InitializeComponent();
            tagManager = tagDatabaseRepository;

            var allTags = tagManager.GetAll();
            foreach (var tag in allTags)
            {
                tagsDataGridView.Rows.Add(tag.Text);
            }

        }
        private void AddTagButton_Click(object sender, EventArgs e)
        {
            if (newTagTextBox.Text != "")
            {
                var tagToAdd = new Tag { Text = newTagTextBox.Text };
                tagManager.Add(tagToAdd);
                tagsDataGridView.Rows.Add(newTagTextBox.Text);
                newTagTextBox.Text = null;
            }
        }
        private void NewTagTextBox_Click(object sender, EventArgs e)
        {
            if (newTagTextBox.Text == "Введите текст своего тэга")
                newTagTextBox.Text = null;
        }
        private void TagsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tagsDataGridView.Columns[e.ColumnIndex] == tagsFormDeleteButton)
            {
                var textOfTagToDelete = tagsDataGridView.Rows[e.RowIndex]?.Cells[0]?.Value?.ToString();
                if (textOfTagToDelete != null)
                {
                    if (MessageBox.Show("Вы точно хотите удалить этот тэг?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tagManager.Delete(textOfTagToDelete);
                        tagsDataGridView.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    MessageBox.Show("Такой тэг не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
