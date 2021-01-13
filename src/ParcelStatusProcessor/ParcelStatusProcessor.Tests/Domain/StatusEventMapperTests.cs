using AutoFixture;

using FluentAssertions;

using NUnit.Framework;

using ParcelStatusProcessor.Domain;
using ParcelStatusProcessor.Domain.Dto;

using Shouldly;

namespace ParcelStatusProcessor.Tests.Domain
{
    [TestFixture]
    public class StatusEventMapperTests
    {
        [Test]
        public void ShouldMapAllProperties()
        {
            var update = new Fixture().Create<StatusUpdate>();
            var mapper = new StatusEventMapper();

            StatusEvent actual = mapper.MapToEvent(update);

            actual.Should()
                  .BeEquivalentTo(
                      update,
                      opt => opt.Excluding(u => u.MessageId));
        }

        [Test]
        public void WhenNamesDontMatch_ShouldMapCorrectly()
        {
            var update = new Fixture().Create<StatusUpdate>();
            var mapper = new StatusEventMapper();

            StatusEvent actual = mapper.MapToEvent(update);

            actual.Id.ShouldBe(update.MessageId);
        }
    }
}
