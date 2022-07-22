using Logger.LogModels.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Logger
{
    public class Logger
    {

        private int _idCounter = 1;
        private readonly LoggerDirectory _directory = new LoggerDirectory();

        public Logger() { }
        
        public LoggerDirectory Directory => _directory;

        public void CreateLog(BaseLogModel logModel)
        {
            if (_directory.TodayLogExists()) _idCounter = 1;
            logModel.DateTime = DateTime.Now.ToString("F");
            if (logModel.Type == default) logModel.Type = LogType.Trace;
            logModel.ModelName = logModel.GetType().Name;
            logModel.Id = _idCounter;
            _idCounter++;
            SaveLog(logModel);
        }

        private void SaveLog(BaseLogModel logModel)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(logModel);
            Console.WriteLine(json);
        }
    }

    public enum LogType
    {
        Trace,
        Info,
        Warning,
        Error
    }
}
