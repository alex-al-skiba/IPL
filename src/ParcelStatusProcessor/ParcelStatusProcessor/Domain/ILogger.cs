using System;

namespace ParcelStatusProcessor.Domain
{
    internal interface ILogger
    {
        /// <summary>
        ///     Logs the specified message in a single line as DEBUG.
        /// </summary>
        void LogDebug(string message);

        /// <summary>
        ///     Logs the specified message in a single line as ERROR.
        /// </summary>
        void LogError(string message);

        /// <summary>
        ///     Logs the specified message in a single line as ERROR, appending the exception information.
        /// </summary>
        void LogError(string message, Exception exception);
    }
}