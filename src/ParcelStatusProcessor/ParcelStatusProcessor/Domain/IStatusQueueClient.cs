using ParcelStatusProcessor.Domain.Dto;

namespace ParcelStatusProcessor.Domain
{
    internal interface IStatusQueueClient
    {
        /// <summary>
        ///     Sends the specified event to the application queue to update the application state.
        /// </summary>
        void DispatchEventToApplicationQueue(StatusEvent statusEvent);

        /// <summary>
        ///     Initiates a status update notification procedure.
        /// </summary>
        /// <param name="update"></param>
        void DispatchStatusUpdateNotification(StatusUpdate update);
    }
}