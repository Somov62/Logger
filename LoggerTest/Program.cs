using System;
using LoggerLib;
using LoggerLib.LogModels;

namespace LoggerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new Logger(Environment.CurrentDirectory);
            Logger logger = Logger.GetContext();
            logger.CreateLog(new CustomLogModel() { State = 20, Message = "aboba", Entity = new User() { Age = 18 } });
        }
    }

    class User
    {
        public int Age { get; set; }
    }
}
