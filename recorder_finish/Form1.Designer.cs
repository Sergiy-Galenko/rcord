namespace recorder_finish
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.createFileButton = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.timeLabel = new System.Windows.Forms.Label();
            this.timeInput = new System.Windows.Forms.TextBox();
            this.goToTimeButton = new System.Windows.Forms.Button();

            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 250);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Text = "КАСЕТНИЙ МАГНІТОФОН";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // 
            // tableLayout
            // 
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.ColumnCount = 3;
            this.tableLayout.RowCount = 2;
            this.tableLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayout.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayout.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayout.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.Controls.Add(this.tableLayout);

            // 
            // flowButtons
            // 
            this.flowButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowButtons.WrapContents = true;
            this.flowButtons.AutoScroll = true;
            this.tableLayout.Controls.Add(this.flowButtons, 0, 0);
            this.tableLayout.SetColumnSpan(this.flowButtons, 3);

            // 
            // playButton
            // 
            this.playButton.Text = "▶ Відтворити";
            this.playButton.AutoSize = true;
            this.playButton.Click += new System.EventHandler(this.Play_Click);
            this.flowButtons.Controls.Add(this.playButton);

            // 
            // pauseButton
            // 
            this.pauseButton.Text = "⏸ Пауза";
            this.pauseButton.AutoSize = true;
            this.pauseButton.Click += new System.EventHandler(this.Pause_Click);
            this.flowButtons.Controls.Add(this.pauseButton);

            // 
            // stopButton
            // 
            this.stopButton.Text = "⏹ Стоп";
            this.stopButton.AutoSize = true;
            this.stopButton.Click += new System.EventHandler(this.Stop_Click);
            this.flowButtons.Controls.Add(this.stopButton);

            // 
            // recordButton
            // 
            this.recordButton.Text = "🔴 Запис";
            this.recordButton.AutoSize = true;
            this.recordButton.Click += new System.EventHandler(this.Record_Click);
            this.flowButtons.Controls.Add(this.recordButton);

            // 
            // deleteButton
            // 
            this.deleteButton.Text = "🗑 Очистити";
            this.deleteButton.AutoSize = true;
            this.deleteButton.Click += new System.EventHandler(this.Delete_Click);
            this.flowButtons.Controls.Add(this.deleteButton);

            // 
            // saveButton
            // 
            this.saveButton.Text = "💾 Скопіювати";
            this.saveButton.AutoSize = true;
            this.saveButton.Click += new System.EventHandler(this.Save_Click);
            this.flowButtons.Controls.Add(this.saveButton);

            // 
            // openButton
            // 
            this.openButton.Text = "📂 Відкрити";
            this.openButton.AutoSize = true;
            this.openButton.Click += new System.EventHandler(this.Open_Click);
            this.flowButtons.Controls.Add(this.openButton);

            // 
            // createFileButton
            // 
            this.createFileButton.Text = "➕ Створити";
            this.createFileButton.AutoSize = true;
            this.createFileButton.Click += new System.EventHandler(this.CreateFile_Click);
            this.flowButtons.Controls.Add(this.createFileButton);

            // 
            // trackBar
            // 
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar.Minimum = 0;
            this.trackBar.Maximum = 1;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            this.tableLayout.Controls.Add(this.trackBar, 0, 1);

            // 
            // timeLabel
            // 
            this.timeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeLabel.Text = "00:00 / 00:00";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tableLayout.Controls.Add(this.timeLabel, 1, 1);

            // 
            // timeInput
            // 
            this.timeInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeInput.Text = "00:00.00";
            this.timeInput.TextChanged += new System.EventHandler(this.timeInput_TextChanged);
            this.tableLayout.Controls.Add(this.timeInput, 2, 1);

            // 
            // goToTimeButton
            // 
            this.goToTimeButton.Text = "Перейти";
            this.goToTimeButton.AutoSize = true;
            this.goToTimeButton.Click += new System.EventHandler(this.GoToTime_Click);
            // Додаємо її в ту ж клітинку, що й timeInput (док- та паддінги за бажанням)
            this.tableLayout.Controls.Add(this.goToTimeButton, 2, 1);
        }
    }
}
