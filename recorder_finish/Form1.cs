using System;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Lame;
using System.Timers;

namespace recorder_finish
{
    public partial class Form1 : Form
    {
        // Constants
        private const int SampleRate = 44100;
        private const int Channels = 1;
        private const int BitRate = 128;
        private const int TimerIntervalMs = 200;
        private const int BufferSize = 4096;
        private const string DefaultFilePath = "cassette.mp3";

        private WaveInEvent waveIn;
        private LameMP3FileWriter writer;
        private WaveOutEvent waveOut;
        private WaveStream reader;
        private string filePath = DefaultFilePath;

        private bool isRecording = false;
        private DateTime recordingStart;
        private double recordOffsetSec = 0;

        private System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();
            InitTimer();

            // Забороняємо вводити нецифрові символи у поле вводу часу
            timeInput.KeyPress += TimeInput_KeyPress;

            trackBar.Enabled = true; // дозволити повзунок спочатку
        }

        private void InitTimer()
        {
            timer = new System.Timers.Timer(TimerIntervalMs);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Invoke(() =>
            {
                if (isRecording)
                {
                    var recTime = DateTime.Now - recordingStart;
                    int totalSec = (int)(recordOffsetSec + recTime.TotalSeconds);

                    if (totalSec > trackBar.Maximum)
                        trackBar.Maximum = totalSec + 1;

                    trackBar.Value = totalSec;
                    timeLabel.Text = $"{TimeSpan.FromSeconds(totalSec):mm\\:ss} (Запис)";
                }
                else if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                {
                    var pos = reader.CurrentTime;
                    trackBar.Value = Math.Min(trackBar.Maximum, (int)pos.TotalSeconds);
                    timeLabel.Text = $"{pos:mm\\:ss} / {reader.TotalTime:mm\\:ss}";
                }
            });
        }

        private void Play_Click(object sender, EventArgs e)
        {
            StopAll();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var mp3 = new Mp3FileReader(filePath);
                reader = WaveFormatConversionStream.CreatePcmStream(mp3);
                waveOut = new WaveOutEvent();
                waveOut.Init(reader);

                int startSec = trackBar.Value;
                if (startSec > 0 && startSec < (int)reader.TotalTime.TotalSeconds)
                    reader.CurrentTime = TimeSpan.FromSeconds(startSec);

                trackBar.Maximum = (int)reader.TotalTime.TotalSeconds;
                waveOut.Play();
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося відкрити файл: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Pause();
                timer.Stop();
            }
            else if (waveIn != null && isRecording)
            {
                waveIn.StopRecording();
                timer.Stop();
                isRecording = false;
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            StopAll();
        }

        private void Record_Click(object sender, EventArgs e)
        {
            // Якщо файл не існує, не дозволяємо записувати
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Немає файлу для запису. Спочатку створіть або відкрийте файл.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StopAll();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            recordOffsetSec = trackBar.Value;
            if (File.Exists(filePath) && recordOffsetSec > 0)
            {
                var temp = Path.GetTempFileName();
                using (var readerMp3 = new Mp3FileReader(filePath))
                using (var pcm = WaveFormatConversionStream.CreatePcmStream(readerMp3))
                using (var trimWriter = new LameMP3FileWriter(temp, pcm.WaveFormat, BitRate))
                {
                    byte[] buffer = new byte[BufferSize];
                    while (pcm.CurrentTime.TotalSeconds < recordOffsetSec)
                    {
                        int bytesNeeded = (int)Math.Min(buffer.Length,
                            (recordOffsetSec - pcm.CurrentTime.TotalSeconds) * pcm.WaveFormat.AverageBytesPerSecond);
                        int read = pcm.Read(buffer, 0, bytesNeeded);
                        if (read == 0) break;
                        trimWriter.Write(buffer, 0, read);
                    }
                    trimWriter.Flush();
                }
                File.Delete(filePath);
                File.Move(temp, filePath);
            }

            waveIn = new WaveInEvent { WaveFormat = new WaveFormat(SampleRate, Channels) };

            var fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            writer = new LameMP3FileWriter(fs, waveIn.WaveFormat, BitRate);

            waveIn.DataAvailable += (s, a) => writer.Write(a.Buffer, 0, a.BytesRecorded);
            waveIn.RecordingStopped += (s, a) =>
            {
                writer?.Dispose();
                waveIn?.Dispose();
                fs.Dispose();
            };

            isRecording = true;
            recordingStart = DateTime.Now;
            trackBar.Maximum = (int)recordOffsetSec + 1;
            trackBar.Value = (int)recordOffsetSec;
            trackBar.Enabled = false; // вимкнути повзунок під час запису
            timer.Start();
            waveIn.StartRecording();
        }

        private void CreateFile_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "MP3 files (*.mp3)|*.mp3";
                dlg.FileName = "new_file.mp3";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    filePath = dlg.FileName;
                    // Якщо файл уже існує, видаляємо, щоб створити новий порожній
                    if (File.Exists(filePath))
                        File.Delete(filePath);

                    // Створюємо порожній MP3-файл (щоб File.Exists став true)
                    using (var fs = File.Create(filePath))
                    {
                        // Просто закриваємо потік—файл існує, але порожній
                    }

                    this.Text = $"КАСЕТНИЙ МАГНІТОФОН — {Path.GetFileName(filePath)}";
                    MessageBox.Show($"Файл для запису встановлено: {Path.GetFileName(filePath)}");
                }
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "MP3 files (*.mp3)|*.mp3";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    filePath = dlg.FileName;
                    this.Text = $"КАСЕТНИЙ МАГНІТОФОН — {Path.GetFileName(filePath)}";
                    MessageBox.Show($"Відкрито файл: {Path.GetFileName(filePath)}");
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            StopAll();
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                MessageBox.Show("Файл очищено.");
                trackBar.Value = 0;
                trackBar.Maximum = 1;
                timeLabel.Text = "00:00 / 00:00";

                // Очищаємо назву файлу в заголовку форми
                this.Text = "КАСЕТНИЙ МАГНІТОФОН";
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            StopAll();
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Немає файлу для збереження.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "MP3 files (*.mp3)|*.mp3";
                dlg.FileName = "saved_cassette.mp3";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(filePath, dlg.FileName, true);
                    this.Text = $"КАСЕТНИЙ МАГНІТОФОН — {Path.GetFileName(dlg.FileName)}";
                    MessageBox.Show("Запис збережено.");
                }
            }
        }

        private void GoToTime_Click(object sender, EventArgs e)
        {
            // Перевірка: якщо файл не створено або не відкрито, забороняємо перехід
            if (!File.Exists(filePath) || reader == null)
            {
                MessageBox.Show("Спочатку створіть або відкрийте файл.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TimeSpan.TryParseExact(timeInput.Text, @"mm\:ss\.ff", null, out TimeSpan ts))
            {
                double seconds = ts.TotalSeconds;
                double maxSec = reader.TotalTime.TotalSeconds;
                seconds = Math.Clamp(seconds, 0, maxSec);

                int secInt = (int)Math.Round(seconds);
                reader.CurrentTime = TimeSpan.FromSeconds(secInt);
                timeLabel.Text = $"{TimeSpan.FromSeconds(secInt):mm\\:ss} / {reader.TotalTime:mm\\:ss}";
                trackBar.Value = secInt;
            }
            else
            {
                MessageBox.Show("Неправильний формат часу. Приклад: 0123 (тільки цифри).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timeInput_TextChanged(object sender, EventArgs e)
        {
            // за потреби валідація вводу
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            // Перевірка: якщо файл не створено або не відкрито, забороняємо скрол
            if (!File.Exists(filePath) || reader == null)
            {
                trackBar.Value = 0;
                return;
            }

            reader.CurrentTime = TimeSpan.FromSeconds(trackBar.Value);
            timeLabel.Text = $"{reader.CurrentTime:mm\\:ss} / {reader.TotalTime:mm\\:ss}";
        }

        private void StopAll()
        {
            try
            {
                waveIn?.StopRecording();
                waveOut?.Stop();
            }
            catch { }

            timer.Stop();

            reader?.Dispose();
            writer?.Dispose();
            waveOut?.Dispose();
            waveIn?.Dispose();

            reader = null;
            writer = null;
            waveOut = null;
            waveIn = null;
            isRecording = false;
            trackBar.Enabled = true; // знову ввімкнути повзунок після зупинки
        }

        // Обробник, який забороняє вводити нецифрові символи
        private void TimeInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Дозволяємо лише цифри та клавіші керування (Backspace тощо)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
