using Dto.Global;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utility
{
    /// <summary>
    /// se genera un singleton para el log
    /// </summary>
    public class LogAtmira
    {
        public Logger logger { get; }

        private readonly static LogAtmira _instance = new LogAtmira();
        
        private LogAtmira()
        {
            string directory = Conexion.Log;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string file = string.Format("{0}Log.txt", directory);

            logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().WriteTo.File(file, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 10).CreateLogger();
        }

        public static LogAtmira Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}
