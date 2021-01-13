using System;

namespace ParcelStatusProcessor.Domain.Dto
{
    /// <summary>
    ///     Representation of parcel status update information.
    /// </summary>
    public readonly struct StatusUpdate
    {
        public StatusUpdate(string messageId, DateTimeOffset timestamp, string trackingCode, ParcelStatus parcelStatus, string additionalInfo)
        {
            MessageId = messageId;
            Timestamp = timestamp;
            TrackingCode = trackingCode;
            ParcelStatus = parcelStatus;
            AdditionalInfo = additionalInfo;
        }
        public string MessageId { get; }
        public DateTimeOffset Timestamp { get; }
        public string TrackingCode { get; }
        public ParcelStatus ParcelStatus { get; }
        public string AdditionalInfo { get; }
    }
}