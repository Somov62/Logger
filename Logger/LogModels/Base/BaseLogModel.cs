namespace Logger.LogModels.Base
{
    public class BaseLogModel
    {
        internal string DateTime { get; set; }

        internal string ModelName { get; set; }

        internal int Id { get; set; }

        public string Message { get; set; }

        public LogType Type { get; set; }
    }
}
