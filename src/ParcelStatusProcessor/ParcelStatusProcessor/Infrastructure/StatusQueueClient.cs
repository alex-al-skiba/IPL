using System;

using ParcelStatusProcessor.Domain;
using ParcelStatusProcessor.Domain.Dto;

namespace ParcelStatusProcessor.Infrastructure
{
    public class StatusQueueClient : IStatusQueueClient
    {
        /// <inheritdoc />
        public void DispatchEventToApplicationQueue(StatusEvent statusEvent)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void DispatchStatusUpdateNotification(StatusUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}