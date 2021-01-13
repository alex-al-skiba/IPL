using System;

using ParcelStatusProcessor.Domain;
using ParcelStatusProcessor.Domain.Dto;

namespace ParcelStatusProcessor.Infrastructure
{
    public class StatusEventLog : IStatusEventLog
    {
        /// <inheritdoc />
        public EventSaveResult Save(StatusEvent statusEvent)
        {
            throw new NotImplementedException();
        }
    }
}