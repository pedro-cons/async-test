using Domain.Constants;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{

    /// <summary>
    /// Service responsible for handling file logs
    /// </summary>
    public class ServiceFileLog : IServiceLog
    {
        #region Constructor

        /// <summary>
        /// ServiceFileLog Constructor responsible for handling file logs
        /// </summary>
        public ServiceFileLog() { }

        #endregion

        #region Methods

        public async Task LogError(string message)
        {
            var logMessage = $"{DateTime.Now}: ERROR - {message}{Environment.NewLine}";
            await File.AppendAllTextAsync($"{CFolder.FolderPath}log.txt", logMessage);

            Console.WriteLine(logMessage);
        }

        #endregion
    }
}
