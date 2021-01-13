using System;

using Amazon.Lambda.Core;

using ParcelStatusProcessor.Domain;

namespace ParcelStatusProcessor.Infrastructure
{
    public class LambdaLogWrapper : ILogger
    {
        private readonly ILambdaLogger _lambdaLogger;

        public LambdaLogWrapper(ILambdaLogger lambdaLogger)
        {
            _lambdaLogger = lambdaLogger;
        }

        /// <inheritdoc />
        public void LogDebug(string message)
        {
            _lambdaLogger.LogLine($"DEBUG {message}");
        }

        /// <inheritdoc />
        public void LogError(string message)
        {
            _lambdaLogger.LogLine($"ERROR {message}");
        }

        /// <inheritdoc />
        public void LogError(string message, Exception exception)
        {
            _lambdaLogger.LogLine($"ERROR {message} {exception}");
        }
    }
}