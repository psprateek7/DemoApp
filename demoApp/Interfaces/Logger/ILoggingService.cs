using System;
using System.Runtime.CompilerServices;

namespace demoApp.Interfaces.Logger
{
    public interface ILoggingService
    {
        /// <summary>
        /// Logs the details with WARNING prefix.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="lineNumber">line number of occurence</param>
        /// <param name="caller">caller method</param>
        void LogWarning(string message, [CallerMemberName] string caller = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the details with ERROR prefix.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="lineNumber">line number of occurence</param>
        /// <param name="caller">caller method</param>
        void LogError(string message, [CallerMemberName] string caller = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the details with FATAL prefix.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="lineNumber">line number of occurence</param>
        /// <param name="caller">caller method</param>
        void LogFatal(string message, [CallerMemberName] string caller = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the details with DEBUG prefix.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="lineNumber">line number of occurence</param>
        /// <param name="caller">caller method</param>
        void LogDebug(string message, [CallerMemberName] string caller = "", [CallerLineNumber] int lineNumber = 0);
    }
}
