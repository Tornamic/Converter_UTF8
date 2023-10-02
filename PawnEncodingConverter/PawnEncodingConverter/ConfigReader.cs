using System;
using System.IO;

namespace PawnEncodingConverter
{
    internal class ConfigReader
    {
        public string FileName { get; set; }
        public ConfigReader(string _fileName) 
        {
            FileName = _fileName;
        }
        public string Read(string name)
        {
            foreach (var line in File.ReadAllLines(FileName))
            {
                if(line.StartsWith(name)) return line.Remove(0, name.Length + 1);
            }
            return String.Empty;
        }
    }
}
