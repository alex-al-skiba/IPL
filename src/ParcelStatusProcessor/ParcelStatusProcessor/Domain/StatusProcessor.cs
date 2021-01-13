using ParcelStatusProcessor.Domain.Dto;

namespace ParcelStatusProcessor.Domain
{
    /// <summary>
    ///     Entry point to the business logic of the function
    /// </summary>
    internal class StatusProcessor
    {
        private readonly ILogger _logger;
        private readonly IStatusQueueClient _queueClient;
        private readonly IStatusEventLog _statusEventLog;
        private readonly IStatusEventMapper _statusEventMapper;

        public StatusProcessor(IStatusEventMapper statusEventMapper, IStatusEventLog statusEventLog, IStatusQueueClient queueClient, ILogger logger)
        {
            _statusEventMapper = statusEventMapper;
            _statusEventLog = statusEventLog;
            _queueClient = queueClient;
            _logger = logger;
        }

        public void ProcessStatusUpdate(StatusUpdate update)
        {
            StatusEvent statusEvent = _statusEventMapper.MapToEvent(update);
            EventSaveResult saveResult = _statusEventLog.Save(statusEvent);

            if (saveResult == EventSaveResult.Duplicate)
            {
                _logger.LogDebug($"Event {statusEvent.Id} ({statusEvent.TrackingCode}) was rejected by the Event Log as a duplicate.");
            }
            else
            {
                _queueClient.DispatchEventToApplicationQueue(statusEvent);
                _queueClient.DispatchStatusUpdateNotification(update);
            }
        }
    }
}
