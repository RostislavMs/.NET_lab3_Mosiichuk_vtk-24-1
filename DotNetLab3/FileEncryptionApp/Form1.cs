using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileEncryptionApp
{
    public partial class Form1 : Form
    {
        private FileEncryptor fileEncryptor = new FileEncryptor();
        private BackgroundWorker worker = new BackgroundWorker();
        private string selectedFilePath;
        public Form1()
        {
            InitializeComponent();
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            FileOperationArgs operationArgs = (FileOperationArgs)e.Argument;
            string mode = operationArgs.Mode;
            string inputFilePath = operationArgs.InputFilePath;
            string outputFilePath = operationArgs.OutputFilePath;
            string key = operationArgs.Key;

            var stopwatch = Stopwatch.StartNew();
            try
            {
                long totalBytes = new FileInfo(inputFilePath).Length;
                long processedBytes = 0;

                using (FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
                using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if (operationArgs.Mode == "encrypt")
                        {
                            fileEncryptor.EncryptFile(operationArgs.InputFilePath, operationArgs.OutputFilePath, operationArgs.Key, (BackgroundWorker)sender);
                        }
                        else if (operationArgs.Mode == "decrypt")
                        {
                            fileEncryptor.DecryptFile(operationArgs.InputFilePath, operationArgs.OutputFilePath, operationArgs.Key, (BackgroundWorker)sender);
                        }

                        processedBytes += bytesRead;
                        int progress = (int)((double)processedBytes / totalBytes * 100);
                        worker.ReportProgress(progress);
                    }
                }

                stopwatch.Stop();
                operationArgs.Time = stopwatch.Elapsed;
                operationArgs.FilePath = outputFilePath;
                operationArgs.ErrorMessage = null;
            }
            catch (Exception ex)
            {
                operationArgs.ErrorMessage = ex.Message;
            }

            e.Result = operationArgs;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FileOperationArgs result = (FileOperationArgs)e.Result;

            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                MessageBox.Show($"Помилка: {result.ErrorMessage}");
            }
            else
            {
                TimeLabel.Text = $"Час: {result.Time.TotalSeconds} секунд";

                string message = result.Mode == "encrypt"
                    ? $"Шифрування завершено! Файл: {result.FilePath}\nРозмір: {new FileInfo(result.FilePath).Length} байт\nЧас: {result.Time}"
                    : $"Дешифрування завершено! Файл: {result.FilePath}\nРозмір: {new FileInfo(result.FilePath).Length} байт\nЧас: {result.Time}";

                MessageBox.Show(message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                MessageBox.Show("Вибрано файл: " + selectedFilePath);
            }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(KeyTextBox.Text) || KeyTextBox.Text.Length < 8)
            {
                MessageBox.Show("Будь ласка, введіть ключ (мінімум 8 символів)!");
                return;
            }
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Будь ласка, оберіть файл для дешифрування.");
                return;
            }

            string outputFilePath = Path.ChangeExtension(selectedFilePath, ".dec");
            var args = new FileOperationArgs
            {
                Mode = "decrypt",
                InputFilePath = selectedFilePath,
                OutputFilePath = outputFilePath,
                Key = KeyTextBox.Text
            };
            worker.RunWorkerAsync(args);
        }

        private void EncryptButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(KeyTextBox.Text) || KeyTextBox.Text.Length < 8)
            {
                MessageBox.Show("Будь ласка, введіть ключ (мінімум 8 символів)!");
                return;
            }
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Будь ласка, оберіть файл для шифрування.");
                return;
            }

            string outputFilePath = Path.ChangeExtension(selectedFilePath, ".enc");
            var args = new FileOperationArgs
            {
                Mode = "encrypt",
                InputFilePath = selectedFilePath,
                OutputFilePath = outputFilePath,
                Key = KeyTextBox.Text
            };
            worker.RunWorkerAsync(args);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
            TimeLabel.Text = $"{e.ProgressPercentage}%";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"Помилка: {e.Error.Message}");
            }
            else
            {
                var result = (dynamic)e.Result;
                MessageBox.Show($"Шифрування завершено! Файл: {result.FilePath}, Розмір: {result.FileSize} байт, Час: {result.Time} сек.");
            }
        }
    }
}
