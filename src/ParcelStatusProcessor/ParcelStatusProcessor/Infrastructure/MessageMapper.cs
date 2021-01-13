using System;

using Amazon.Lambda.SQSEvents;

using ParcelStatusProcessor.Domain.Dto;

namespace ParcelStatusProcessor.Infrastructure
{
    public static class MessageMapper
    {
        public static StatusUpdate MapToStatusUpdate(SQSEvent.SQSMessage message)
        {
            throw new NotImplementedException();
        }
    }
}