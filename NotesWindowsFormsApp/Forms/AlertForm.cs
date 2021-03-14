using System;
using System.Media;
using System.Windows.Forms;

namespace NotesWindowsFormsApp
{
    public partial class AlertForm : Form
    {
        SoundPlayer player = new SoundPlayer();
        
        public AlertForm()
        {
            InitializeComponent();
        }

        private void AlertForm_Load(object sender, EventArgs e)
        {
            player.SoundLocation = "1584903395_NationalMelody-16.wav";           
            player.Play();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            player.Stop();
            OkButton.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
