using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace recorder_finish
{
    partial class Form1
    {
        private IContainer components = null;

        private Button playButton;
        private Button pauseButton;
        private Button stopButton;
        private Button recordButton;
        private Button deleteButton;
        private Button saveButton;
        private Button openButton;
        private Button createFileButton;
        private TrackBar trackBar;
        private Label timeLabel;
        private TextBox timeInput;
        private Button goToTimeButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.playButton = new Button();
            this.pauseButton = new Button();
            this.stopButton = new Button();
            this.recordButton = new Button();
            this.deleteButton = new Button();
            this.saveButton = new Button();
            this.openButton = new Button();
            this.createFileButton = new Button();
            this.trackBar = new TrackBar();
            this.timeLabel = new Label();
            this.timeInput = new TextBox();
            this.goToTimeButton = new Button();
            ((ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Text = "КАСЕТНИЙ МАГНІТОФОН";
            // Забираємо фіксовану границю
            this.FormBorderStyle = FormBorderStyle.Sizable;
            // Щоб відразу розгортати на весь екран
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            // 
            // playButton
            // 
            this.playButton.Location = new Point(20, 20);
            this.playButton.Name = "playButton";
            this.playButton.Size = new Size(90, 35);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "▶ Відтворити";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new EventHandler(this.Play_Click);
            // Анкоримо відстань від лівої та верхньої границі
            this.playButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new Point(115, 20);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new Size(90, 35);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "⏸ Пауза";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new EventHandler(this.Pause_Click);
            this.pauseButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // stopButton
            // 
            this.stopButton.Location = new Point(210, 20);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new Size(90, 35);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "⏹ Стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new EventHandler(this.Stop_Click);
            this.stopButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // recordButton
            // 
            this.recordButton.Location = new Point(305, 20);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new Size(90, 35);
            this.recordButton.TabIndex = 3;
            this.recordButton.Text = "🔴 Запис";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new EventHandler(this.Record_Click);
            this.recordButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new Point(401, 20);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new Size(120, 35);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "🗑 Очистити";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new EventHandler(this.Delete_Click);
            this.deleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // saveButton
            // 
            this.saveButton.Location = new Point(530, 20);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new Size(124, 35);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "💾 Скопіювати";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new EventHandler(this.Save_Click);
            this.saveButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // openButton
            // 
            this.openButton.Location = new Point(658, 20);
            this.openButton.Name = "openButton";
            this.openButton.Size = new Size(140, 35);
            this.openButton.TabIndex = 6;
            this.openButton.Text = "📂 Відкрити";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new EventHandler(this.Open_Click);
            this.openButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // createFileButton
            // 
            this.createFileButton.Location = new Point(804, 20);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new Size(134, 35);
            this.createFileButton.TabIndex = 7;
            this.createFileButton.Text = "➕ Створити";
            this.createFileButton.UseVisualStyleBackColor = true;
            this.createFileButton.Click += new EventHandler(this.CreateFile_Click);
            this.createFileButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            // 
            // trackBar
            // 
            // Щоб трекбар розтягувався по ширині вікна
            this.trackBar.Location = new Point(20, 70);
            this.trackBar.Name = "trackBar";
            // Ширина «зразу» не важлива – вона оновиться в момент завантаження форми,
            // бо ми анкоримо праву та ліву межі
            this.trackBar.Size = new Size(600, 56);
            this.trackBar.TabIndex = 8;
            this.trackBar.Scroll += new EventHandler(this.trackBar_Scroll);
            this.trackBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // timeLabel
            // 
            // Ярлик розташований праворуч від трекбару
            this.timeLabel.Location = new Point(640, 77);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new Size(200, 30);
            this.timeLabel.TabIndex = 9;
            this.timeLabel.Text = "00:00 / 00:00";
            this.timeLabel.TextAlign = ContentAlignment.MiddleLeft;
            this.timeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            // 
            // timeInput
            // 
            // Поле вводу розташоване праворуч угорі
            this.timeInput.Location = new Point(640, 20);
            this.timeInput.Name = "timeInput";
            this.timeInput.Size = new Size(100, 27);
            this.timeInput.TabIndex = 10;
            this.timeInput.Text = "00:00.00";
            this.timeInput.TextChanged += new EventHandler(this.timeInput_TextChanged);
            this.timeInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            // 
            // goToTimeButton
            // 
            this.goToTimeButton.Location = new Point(750, 20);
            this.goToTimeButton.Name = "goToTimeButton";
            this.goToTimeButton.Size = new Size(80, 25);
            this.goToTimeButton.TabIndex = 11;
            this.goToTimeButton.Text = "Перейти";
            this.goToTimeButton.UseVisualStyleBackColor = true;
            this.goToTimeButton.Click += new EventHandler(this.GoToTime_Click);
            this.goToTimeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            // 
            // Form1 (продовження)
            // 
            // Вимикаємо фіксацію розмірів, дозволяємо користувачу змінювати розмір, і розгортаємо відразу на весь екран
            this.ClientSize = new Size(900, 200);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.createFileButton);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.timeInput);
            this.Controls.Add(this.goToTimeButton);
            ((ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
