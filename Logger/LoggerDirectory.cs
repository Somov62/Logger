using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Logger
{
    public class LoggerDirectory
    {
        private readonly string _pathToFolder;

        public LoggerDirectory()
        {
            string projectName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            _pathToFolder = HttpRuntime.AppDomainAppPath.Replace(projectName, "Logger");
            _pathToFolder = Path.Combine(_pathToFolder, "LogsStorage");

            DirectoryInfo directoryInfo = new DirectoryInfo(_pathToFolder);
            if (!directoryInfo.Exists)
            {
                Directory.CreateDirectory(_pathToFolder);
            }
        }

        public byte[] GetLog(string logname)
        {
            string pathToFile = Path.Combine(_pathToFolder, logname);
            if (!File.Exists(pathToFile)) return null;
            return File.ReadAllBytes("pathToFile");
        }

        internal void AddLog(string text)
        {
            string pathToFile = Path.Combine(_pathToFolder, DateTime.Now.ToString("d"));

            Task.Run(() => WriteTextAsync(pathToFile, text));
        }

        internal bool TodayLogExists()
        {
            string pathToFile = Path.Combine(_pathToFolder, DateTime.Now.ToString("d"));
            return File.Exists(pathToFile);
        }

        public void ClearAll()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_pathToFolder);
            directoryInfo.Delete();
            directoryInfo.Create();
        }

        private async Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }
    }
}
