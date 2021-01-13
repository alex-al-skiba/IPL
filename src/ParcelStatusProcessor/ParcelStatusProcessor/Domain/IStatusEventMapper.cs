using ParcelStatusProcessor.Domain.Dto;

namespace ParcelStatusProcessor.Domain
{
    internal interface IStatusEventMapper
    {
        /// <summary>
        ///     Converts <see cref="StatusUpdate" /> object to <see cref="StatusEvent" />.
        /// </summary>
        StatusEvent MapToEvent(StatusUpdate update);
    }
}