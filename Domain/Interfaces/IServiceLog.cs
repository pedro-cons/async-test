using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Service interface responsible for handling file logs
    /// </summary>
    public interface IServiceLog
    {
        /// <summary>
        /// Method responsible for logging errors in the console and in the error file
        /// </summary>
        /// <param name="message">Error message</param>
        /// <returns></returns>
        Task LogError(string message);
    }
}
