using ParcelStatusProcessor.Domain.Dto;

namespace ParcelStatusProcessor.Domain
{
    internal interface IStatusEventLog
    {
        EventSaveResult Save(StatusEvent statusEvent);
    }
}