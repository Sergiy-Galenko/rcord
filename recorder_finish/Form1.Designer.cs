namespace recorder_finish
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button createFileButton;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.TextBox timeInput;
        private System.Windows.Forms.Button goToTimeButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            playButton = new Button();
            pauseButton = new Button();
            stopButton = new Button();
            recordButton = new Button();
            deleteButton = new Button();
            saveButton = new Button();
            openButton = new Button();
            createFileButton = new Button();
            trackBar = new TrackBar();
            timeLabel = new Label();
            timeInput = new TextBox();
            goToTimeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            SuspendLayout();
            // 
            // playButton
            // 
            playButton.Location = new Point(20, 20);
            playButton.Name = "playButton";
            playButton.Size = new Size(90, 35);
            playButton.TabIndex = 0;
            playButton.Text = "▶ Відтворити";
            playButton.Click += Play_Click;
            // 
            // pauseButton
            // 
            pauseButton.Location = new Point(115, 20);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(90, 35);
            pauseButton.TabIndex = 1;
            pauseButton.Text = "⏸ Пауза";
            pauseButton.Click += Pause_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(210, 20);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(90, 35);
            stopButton.TabIndex = 2;
            stopButton.Text = "⏹ Стоп";
            stopButton.Click += Stop_Click;
            // 
            // recordButton
            // 
            recordButton.Location = new Point(305, 20);
            recordButton.Name = "recordButton";
            recordButton.Size = new Size(90, 35);
            recordButton.TabIndex = 3;
            recordButton.Text = "🔴 Запис";
            recordButton.Click += Record_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(400, 20);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(90, 35);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "🗑 Видалити";
            deleteButton.Click += Delete_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(495, 20);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(90, 35);
            saveButton.TabIndex = 5;
            saveButton.Text = "💾 Зберегти";
            saveButton.Click += Save_Click;
            // 
            // openButton
            // 
            openButton.Location = new Point(590, 20);
            openButton.Name = "openButton";
            openButton.Size = new Size(90, 35);
            openButton.TabIndex = 6;
            openButton.Text = "📂 Відкрити";
            openButton.Click += Open_Click;
            // 
            // createFileButton
            // 
            createFileButton.Location = new Point(685, 20);
            createFileButton.Name = "createFileButton";
            createFileButton.Size = new Size(90, 35);
            createFileButton.TabIndex = 7;
            createFileButton.Text = "➕ Створити";
            createFileButton.Click += CreateFile_Click;
            // 
            // trackBar
            // 
            trackBar.Location = new Point(20, 61);
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(500, 56);
            trackBar.TabIndex = 8;
            trackBar.Scroll += trackBar_Scroll;
            // 
            // timeLabel
            // 
            timeLabel.Location = new Point(530, 70);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(150, 30);
            timeLabel.TabIndex = 9;
            timeLabel.Text = "00:00 / 00:00";
            // 
            // timeInput
            // 
            timeInput.Location = new Point(686, 67);
            timeInput.Name = "timeInput";
            timeInput.Size = new Size(100, 27);
            timeInput.TabIndex = 10;
            timeInput.Text = "00:00.00";
            timeInput.TextChanged += timeInput_TextChanged;
            // 
            // goToTimeButton
            // 
            goToTimeButton.Location = new Point(686, 100);
            goToTimeButton.Name = "goToTimeButton";
            goToTimeButton.Size = new Size(80, 25);
            goToTimeButton.TabIndex = 11;
            goToTimeButton.Text = "Перейти";
            goToTimeButton.Click += GoToTime_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(817, 190);
            Controls.Add(playButton);
            Controls.Add(pauseButton);
            Controls.Add(stopButton);
            Controls.Add(recordButton);
            Controls.Add(deleteButton);
            Controls.Add(saveButton);
            Controls.Add(openButton);
            Controls.Add(createFileButton);
            Controls.Add(trackBar);
            Controls.Add(timeLabel);
            Controls.Add(timeInput);
            Controls.Add(goToTimeButton);
            Name = "Form1";
            Text = "КАСЕТНИЙ МАГНІТОФОН";
            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}