using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;

namespace FileEncryptionApp
{
    public class FileEncryptor
    {
        public void EncryptFile(string inputFilePath, string outputFilePath, string key, BackgroundWorker worker)
        {
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = GenerateKey(key);
                    aes.IV = aes.Key.Take(16).ToArray();

                    using (var fileStream = new FileStream(outputFilePath, FileMode.Create))
                    using (var cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (var inputStream = new FileStream(inputFilePath, FileMode.Open))
                    {
                        long totalBytes = new FileInfo(inputFilePath).Length;
                        long processedBytes = 0;
                        byte[] buffer = new byte[4096];

                        int bytesRead;
                        var stopwatch = Stopwatch.StartNew();
                        while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            cryptoStream.Write(buffer, 0, bytesRead);
                            processedBytes += bytesRead;

                            int progress = (int)((double)processedBytes / totalBytes * 100);
                            worker.ReportProgress(progress);
                        }

                        stopwatch.Stop();

                        Console.WriteLine($"Шифрування завершено! Файл: {outputFilePath}, Розмір: {new FileInfo(outputFilePath).Length} байт, Час: {stopwatch.Elapsed.TotalSeconds} сек.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка шифрування: {ex.Message}");
            }
        }

        public void DecryptFile(string inputFilePath, string outputFilePath, string key, BackgroundWorker worker)
        {
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = GenerateKey(key);
                    aes.IV = aes.Key.Take(16).ToArray();

                    using (var fileStream = new FileStream(outputFilePath, FileMode.Create))
                    using (var cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    using (var inputStream = new FileStream(inputFilePath, FileMode.Open))
                    {
                        long totalBytes = new FileInfo(inputFilePath).Length;
                        long processedBytes = 0;
                        byte[] buffer = new byte[4096];

                        int bytesRead;
                        var stopwatch = Stopwatch.StartNew();
                        while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            cryptoStream.Write(buffer, 0, bytesRead);
                            processedBytes += bytesRead;

                            int progress = (int)((double)processedBytes / totalBytes * 100);
                            worker.ReportProgress(progress);
                        }

                        stopwatch.Stop();

                        Console.WriteLine($"Розшифрування завершено! Файл: {outputFilePath}, Розмір: {new FileInfo(outputFilePath).Length} байт, Час: {stopwatch.Elapsed.TotalSeconds} сек.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка розшифрування: {ex.Message}");
            }
        }

        private byte[] GenerateKey(string key)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
            }
        }
    }
}
