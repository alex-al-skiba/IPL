using AutoFixture;

using NSubstitute;

using NUnit.Framework;

using ParcelStatusProcessor.Domain;
using ParcelStatusProcessor.Domain.Dto;

namespace ParcelStatusProcessor.Tests.Domain
{
    [TestFixture]
    public class StatusProcessorTests
    {
        [SetUp]
        public void SetUp()
        {
            _statusEventMapperMock = Substitute.For<IStatusEventMapper>();
            _statusEventLogMock = Substitute.For<IStatusEventLog>();
            _queueClientMock = Substitute.For<IStatusQueueClient>();
            _loggerMock = Substitute.For<ILogger>();
        }

        private IStatusEventMapper _statusEventMapperMock;
        private IStatusEventLog _statusEventLogMock;
        private IStatusQueueClient _queueClientMock;
        private ILogger _loggerMock;

        [Test]
        public void ShouldSaveMappedEvent()
        {
            var mappedEvent = new Fixture().Create<StatusEvent>();
            _statusEventMapperMock.MapToEvent(Arg.Any<StatusUpdate>()).Returns(mappedEvent);
            var statusProcessor = new StatusProcessor(_statusEventMapperMock, _statusEventLogMock, _queueClientMock, _loggerMock);

            statusProcessor.ProcessStatusUpdate(new StatusUpdate());

            _statusEventLogMock.Received(1).Save(mappedEvent);
        }

        [Test]
        public void ShouldDispatchNewStatusNotificationAfterSavingTheEvent()
        {
            var statusUpdate = new StatusUpdate();
            var statusProcessor = new StatusProcessor(_statusEventMapperMock, _statusEventLogMock, _queueClientMock, _loggerMock);

            statusProcessor.ProcessStatusUpdate(statusUpdate);

            Received.InOrder(
                () =>
                {
                    _statusEventLogMock.Save(Arg.Any<StatusEvent>());
                    _queueClientMock.DispatchStatusUpdateNotification(statusUpdate);
                });
        }

        [Test]
        public void ShouldDispatchEventToApplicationAfterSavingTheEvent()
        {
            var mappedEvent = new Fixture().Create<StatusEvent>();
            _statusEventMapperMock.MapToEvent(Arg.Any<StatusUpdate>()).Returns(mappedEvent);
            var statusProcessor = new StatusProcessor(_statusEventMapperMock, _statusEventLogMock, _queueClientMock, _loggerMock);

            statusProcessor.ProcessStatusUpdate(new StatusUpdate());

            Received.InOrder(
                () =>
                {
                    _statusEventLogMock.Save(Arg.Any<StatusEvent>());
                    _queueClientMock.DispatchEventToApplicationQueue(mappedEvent);
                });
        }

        [Test]
        public void WhenDuplicateDetected_ShouldNotDispatchNewStatusNotification()
        {
            _statusEventLogMock.Save(Arg.Any<StatusEvent>()).Returns(EventSaveResult.Duplicate);
            var statusProcessor = new StatusProcessor(_statusEventMapperMock, _statusEventLogMock, _queueClientMock, _loggerMock);

            statusProcessor.ProcessStatusUpdate(new StatusUpdate());

            _queueClientMock.Received(0).DispatchStatusUpdateNotification(Arg.Any<StatusUpdate>());
        }

        [Test]
        public void WhenDuplicateDetected_ShouldNotDispatchEventToApplication()
        {
            _statusEventLogMock.Save(Arg.Any<StatusEvent>()).Returns(EventSaveResult.Duplicate);
            var statusProcessor = new StatusProcessor(_statusEventMapperMock, _statusEventLogMock, _queueClientMock, _loggerMock);

            statusProcessor.ProcessStatusUpdate(new StatusUpdate());

            _queueClientMock.Received(0).DispatchEventToApplicationQueue(Arg.Any<StatusEvent>());
        }
    }
}
