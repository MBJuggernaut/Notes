using System;
using System.Media;
using System.Windows.Forms;

namespace NotesWindowsFormsApp.Forms
{
    public partial class AlertForm : Form
    {
        private readonly SoundPlayer player = new SoundPlayer();

        public AlertForm()
        {
            InitializeComponent();
        }

        private void AlertForm_Load(object sender, EventArgs e)
        {
            //player.SoundLocation = "";           
            //player.Play();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            player.Stop();
            OkButton.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
