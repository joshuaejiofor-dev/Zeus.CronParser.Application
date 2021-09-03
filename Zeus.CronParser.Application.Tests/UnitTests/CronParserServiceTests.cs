using Xunit;
using Zeus.CronParser.Application.Services;
using Zeus.CronParser.Application.Services.Interfaces;

namespace Zeus.CronParser.Application.Tests.UnitTests
{
    public class CronParserServiceTests : UnitTestBase
    {
        private readonly ICronParserService _cronParserService;
        private readonly string[] parts;

        public CronParserServiceTests()
        {
            // Arrange. (this is re-initialized for each test)
            parts = "*/15 0 1,15 * 1-5 /usr/bin/find".Replace("  ", " ").Split(" ");
            _cronParserService = new CronParserService(_cronParserProviderFactory);
        }
        

        [Fact]
        public void ParseMinuteTest()
        {
            // Act.
            var result = _cronParserService.ParseMinute(parts[0]);

            // Assert.
            AssertTest(result, "0 15 30 45", 4);
        }

        [Fact]
        public void ParseHourTest()
        {
            // Act.
            var result = _cronParserService.ParseHour(parts[1]);

            // Assert.
            AssertTest(result, "0", 1);
        }

        [Fact]
        public void ParseDayOfMonthTest()
        {
            // Act.
            var result = _cronParserService.ParseDayOfMonth(parts[2]);

            // Assert.
            AssertTest(result, "1 15", 2);
        }

        [Fact]
        public void ParseMonthTest()
        {
            // Act.
            var result = _cronParserService.ParseMonth(parts[3]);

            // Assert.
            AssertTest(result, "1 2 3 4 5 6 7 8 9 10 11 12", 12);
        }


        [Fact]
        public void ParseDayOfWeekTest()
        {
            // Act.
            var result = _cronParserService.ParseDayOfWeek(parts[4]);

            // Assert.
            AssertTest(result, "1 2 3 4 5", 5);
        }

    }
}
