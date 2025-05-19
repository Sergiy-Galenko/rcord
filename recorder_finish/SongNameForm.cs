using System;
using System.Windows.Forms;

namespace recorder_finish
{
    public partial class SongNameForm : Form
    {
        public string SongName => textBoxSongName.Text;

        public SongNameForm()
        {
            SetupUI();
        }

        private void SetupUI()
        {
            this.label = new Label();
            this.textBoxSongName = new TextBox();
            this.buttonOK = new Button();

            this.label.Text = "Введіть назву пісні:";
            this.label.Location = new System.Drawing.Point(15, 15);

            this.textBoxSongName.Location = new System.Drawing.Point(18, 40);
            this.textBoxSongName.Width = 240;

            this.buttonOK.Text = "OK";
            this.buttonOK.Location = new System.Drawing.Point(100, 75);
            this.buttonOK.Click += new EventHandler(ButtonOK_Click);

            this.ClientSize = new System.Drawing.Size(280, 120);
            this.Controls.Add(this.label);
            this.Controls.Add(this.textBoxSongName);
            this.Controls.Add(this.buttonOK);
            this.Text = "Назва пісні";
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SongName))
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Будь ласка, введіть назву пісні.");
        }

        private Label label;
        private TextBox textBoxSongName;
        private Button buttonOK;
    }
}
