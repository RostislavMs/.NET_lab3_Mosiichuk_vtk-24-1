using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptionApp
{
    internal class FileOperationArgs
    {
        public string Mode { get; set; }
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }
        public string Key { get; set; }
        public string FilePath { get; set; }
        public TimeSpan Time { get; set; }
        public string ErrorMessage { get; set; }
    }
}
