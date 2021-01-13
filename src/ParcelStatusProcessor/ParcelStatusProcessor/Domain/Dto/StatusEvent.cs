using System;

namespace ParcelStatusProcessor.Domain.Dto
{
    /// <summary>
    ///     Parcel status update event.
    /// </summary>
    public readonly struct StatusEvent
    {
        public StatusEvent(string id, DateTimeOffset timestamp, string trackingCode, ParcelStatus parcelStatus, string additionalInfo)
        {
            Id = id;
            Timestamp = timestamp;
            TrackingCode = trackingCode;
            ParcelStatus = parcelStatus;
            AdditionalInfo = additionalInfo;
        }

        public string Id { get; }
        public DateTimeOffset Timestamp { get; }
        public string TrackingCode { get; }
        public ParcelStatus ParcelStatus { get; }
        public string AdditionalInfo { get; }
    }
}
