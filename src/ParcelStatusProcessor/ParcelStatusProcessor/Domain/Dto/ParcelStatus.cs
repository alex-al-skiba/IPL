namespace ParcelStatusProcessor.Domain.Dto
{
    /// <summary>
    ///     Enumeration of defined parcel statuses.
    /// </summary>
    public enum ParcelStatus
    {
        Labeled = 1,
        Accepted = 10,
        InTransit = 20,
        ArrivedAtFacility = 30,
        DepartedFacility = 40,
        ReadyForPickUp = 50,
        OutForDelivery = 60,
        Delivered = 70,
        DeliveryAttemptFailed = 80,
        ReturnToSender = 90,
        DeliveredToSender = 100
    }
}