using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Tests.Runners
{

    public class BaseRunnerTests
    {
        [Fact]
        public async Task RunAsync_ShouldExecuteWithoutErrors_WhenParticipantsArePresent()
        {
            var mockServiceLog = new Mock<IServiceLog>();

            // Adding some mocks

            var runner = new BaseRunner(mockServiceLog.Object);

            // Execution
            await runner.RunAsync();

            // Verify
            mockServiceLog.Verify(sl => sl.LogError(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task RunAsync_ShouldLogError_WhenExceptionIsThrown()
        {
            var mockServiceLog = new Mock<IServiceLog>();

            var runner = new BaseRunner(mockServiceLog.Object);

            // Execution
            await runner.RunAsync();

            // Verify
            mockServiceLog.Verify(sl => sl.LogError(It.Is<string>(msg => msg.Contains("Test exception"))), Times.Once);
        }
    }
}
