using System;

using ParcelStatusProcessor.Domain.Dto;

namespace ParcelStatusProcessor.Domain
{
    public class StatusEventMapper : IStatusEventMapper
    {
        /// <inheritdoc />
        public StatusEvent MapToEvent(StatusUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}