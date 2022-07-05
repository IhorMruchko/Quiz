using System;
using System.IO;

namespace Quiz.Standart
{
    public static class Constants
    {
        public static class Time
        {
            public static readonly TimeSpan Hour = new TimeSpan(1, 0, 0);
            public static readonly TimeSpan Minute = new TimeSpan(0, 1, 0);
            public static readonly TimeSpan Second = new TimeSpan(0, 0, 1);
        }

        public static class File
        {
            public static readonly string DataFileName = "Quiz.json";
            public static readonly string DataFilePath = Path.Combine(Environment.CurrentDirectory, DataFileName);
        }
    }
}
