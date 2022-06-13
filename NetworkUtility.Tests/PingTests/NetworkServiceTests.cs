using FluentAssertions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        [Fact] // Fact tells the system that it's true this test should be run by the test runner
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange - variables, classes, mocks
            var pingService = new NetworkService();

            //Act
            var result = pingService.SendPing();

            // Added Fluent Assertions from the manage NuGet packages to give better exception messages, way more robust, etc
            // X-Unit also has a built in Assert
            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory] // Is not that different from what a Fact does Lets us pass in variables/inline data
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            // Arrange
            var pingService = new NetworkService();

            // Act
            var result = pingService.PingTimeout(a, b);

            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }
    }
}
