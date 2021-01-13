using System;
using System.Runtime.CompilerServices;

using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using Amazon.Lambda.SQSEvents;

using ParcelStatusProcessor.Domain;
using ParcelStatusProcessor.Domain.Dto;
using ParcelStatusProcessor.Infrastructure;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]
// Assembly attributes to enable access for unit tests and mocks
[assembly: InternalsVisibleTo("ParcelStatusProcessor.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")] 

namespace ParcelStatusProcessor
{
    public class Functions
    {
        /// <summary>
        ///     A Lambda function to process a parcel status update got from SQS queue.
        /// </summary>
        public void Process(SQSEvent request, ILambdaContext context)
        {
            ILogger logger = new LambdaLogWrapper(context.Logger);

            var statusEventMapper = new StatusEventMapper();
            var statusEventLog = new StatusEventLog();
            var queueClient = new StatusQueueClient();
            var statusProcessor = new StatusProcessor(statusEventMapper, statusEventLog, queueClient, logger);

            foreach (SQSEvent.SQSMessage message in request.Records)
            {
                try
                {
                    StatusUpdate statusUpdate = MessageMapper.MapToStatusUpdate(message);
                    statusProcessor.ProcessStatusUpdate(statusUpdate);
                }
                catch (Exception exception)
                {
                    logger.LogError($"Exception while handling message {message.MessageId}", exception);
                    throw;
                }
            }
        }
    }
}
