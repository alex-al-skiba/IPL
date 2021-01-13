using System;

using AutoFixture;

using NUnit.Framework;

using ParcelStatusProcessor.Domain.Dto;
using ParcelStatusProcessor.Infrastructure;

using Shouldly;

namespace ParcelStatusProcessor.Tests.Infrastructure
{
    [TestFixture]
    public class StatusEventLogTests
    {
        [Test, Category("Integration")]
        public void WhenEventWithTheSameIdIsSaved_ShouldReturnDuplicateResult()
        {
            var firstEvent = new Fixture().Create<StatusEvent>();
            var secondEvent = new StatusEvent(firstEvent.Id, DateTimeOffset.MinValue, null, ParcelStatus.Accepted, null);
            var eventLog = new StatusEventLog();

            eventLog.Save(firstEvent);
            EventSaveResult actual = eventLog.Save(secondEvent);

            actual.ShouldBe(EventSaveResult.Duplicate);
        }
    }
}
