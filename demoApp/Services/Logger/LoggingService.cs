using System;
using System.Runtime.CompilerServices;
using demoApp.Interfaces.Logger;

namespace demoApp.Services.Logger
{
    public class LoggingService : ILoggingService
    {
        public void LogDebug(string message, [CallerMemberName] string caller = "", [CallerLineNumber] int lineNumber = 0)
        {
            LogDetails("DEBUG", message, lineNumber, caller);
        }
        public void LogError(string message, [CallerMemberName] string caller = "", [CallerLineNumber] int lineNumber = 0)
        {
            LogDetails("ERROR", message, lineNumber, caller);
        }
        public void LogFatal(string message, [CallerMemberName] string caller = "", [CallerLineNumber] int lineNumber = 0)
        {
            LogDetails("FATAL", message, lineNumber, caller);
        }
        public void LogWarning(string message, [CallerMemberName] string caller = "", [CallerLineNumber] int lineNumber = 0)
        {
            LogDetails("WARNING", message, lineNumber, caller);
        }

        private void LogDetails(string type, string message, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = "")
        {
            // Implement the required logger service here.
            Console.WriteLine($"\n.{type}..\nLog :\nLine No : {lineNumber}\nCaller : {caller}\nMessage : {message}\n...\n");
        }
    }
}
