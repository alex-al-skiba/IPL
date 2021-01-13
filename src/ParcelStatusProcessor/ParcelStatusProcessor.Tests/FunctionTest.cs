using System.Collections.Generic;

using Amazon.Lambda.SQSEvents;
using Amazon.Lambda.TestUtilities;

using NUnit.Framework;

using Shouldly;

namespace ParcelStatusProcessor.Tests
{
    [TestFixture]
    public class FunctionTest
    {
        [Test]
        public void TestGetMethod()
        {
            var functions = new Functions();
            var request = new SQSEvent { Records = new List<SQSEvent.SQSMessage> { new SQSEvent.SQSMessage() } };
            var context = new TestLambdaContext();

            Should.NotThrow(() => functions.Process(request, context));
        }
    }
}
