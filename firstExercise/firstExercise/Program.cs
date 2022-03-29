using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace firstExercise
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Users\sasas\Desktop\LastExerciseBarsGroup\firstEx.txt";

            Exception exception = new FileLoadException();

            var firstLogger = new firstExLogger<int>(path);
            firstLogger.LogInfo("Start!");
            firstLogger.LogWarning("Warning!");
            firstLogger.LogError("Error!", exception);

            var secondLogger = new firstExLogger<char>(path);
            secondLogger.LogInfo("Start!");
            secondLogger.LogWarning("Warning!");
            secondLogger.LogError("Error!", exception);

            var thirdLogger = new firstExLogger<bool>(path);
            thirdLogger.LogInfo("Start!");
            thirdLogger.LogWarning("Warning!");
            thirdLogger.LogError("Error!", exception);

            Console.ReadLine();
        }
    }

    public class firstExLogger<TLogger> : ILogger
    {
        private string _path;
        private string GenericTypeName = typeof(TLogger).Name;

        public firstExLogger(string path)
        {
            _path = path;
            
            if(true)
            {

                if(!File.Exists(path))
                {
                    string startingLogger = "We starting our logger\n";
                    File.WriteAllText(path, startingLogger);
                }

            }   
            
        }

        public void LogInfo(string message)
        {
            File.AppendAllText(_path, $"[Info] : [{GenericTypeName}] : {message}\n");
            Console.WriteLine("Info  logger conducted successfully");
        }
        public void LogWarning(string message)
        {
            File.AppendAllText(_path, $"[Warning] : [{GenericTypeName}] : {message}\n");
            Console.WriteLine("Warning  logger conducted successfully");
        }

        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(_path, $"[Error] : [{GenericTypeName}] : {message}.{ex.Message}\n");
            Console.WriteLine("Warning  logger conducted successfully");
        }

    }

    public interface ILogger
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex);
    }

}