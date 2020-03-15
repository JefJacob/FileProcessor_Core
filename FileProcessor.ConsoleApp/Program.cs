using System;
using NLog;
using NLog.Config;

namespace FileProcessor.ConsoleApp
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            //LogManager.Configuration = new XmlLoggingConfiguration($"{AppContext.BaseDirectory}nlog.config");
            logger.Info("Application Started");
            //DataReader.ProcessFile(@"J:\Courses\Capstone\FileUpload\AOAccessImport-master\AOAccessImport-master\AODB.mdb");
            DataReader.ProcessFile(@"J:\Courses\Capstone\FileUpload\Source\InputFiles\GenericData-Athletics Ontario Outdoor Championship Series #3- U20 - Open Championships-12Jul2019-002.mdb");
            logger.Info("Application Completed");
        }
    }
}
