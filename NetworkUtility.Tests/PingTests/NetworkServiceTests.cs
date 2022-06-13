using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _pingService;

        // SUT - System Under Test
        public NetworkServiceTests()
        {
            /* We've got our object for the NetworkService inside of our constructor here, which will then initialize it up on line 14 so then it can be globally accessed
               That means we won't have to make a new object every time we write a test, because it's already been initialized up here */
            
            // SUT
            _pingService = new NetworkService();
        }

        [Fact] // Fact tells the system that it's true this test should be run by the test runner
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange - variables, classes, mocks

            //Act
            var result = _pingService.SendPing();

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

            // Act
            var result = _pingService.PingTimeout(a, b);

            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }

        [Fact] 
        public void NetworkService_LastPingDate_ReturnDate()
        {
            //Arrange - variables, classes, mocks

            //Act
            var result = _pingService.LastPingDate();

            //Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnsObject()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
            //Act
            var result = _pingService.GetPingOptions();

            //Assert WARNING: "Be" careful Video #2 10:20 Teddy Smith Unit Testing, watch for reference of "Be"
            // Whenever checking inside of an object, use BeEquivalentTo, and not just "Be"
            // When asserting objects, usually check for type first
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected); // BeEquivalentTo - you're comparing an object
            result.Ttl.Should().Be(1);
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnsObjectList()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
            //Act
            var result = _pingService.MostRecentPings();

            //Assert WARNING: "Be" careful Video #2 10:20 Teddy Smith Unit Testing, watch for reference of "Be"
            // Whenever checking inside of an object, use BeEquivalentTo, and not just "Be"
            // When asserting objects, usually check for type first

            //result.Should().BeOfType<IEnumerable<PingOptions>>();
            result.Should().ContainEquivalentOf(expected); // - You're comparing a list of objects
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}
