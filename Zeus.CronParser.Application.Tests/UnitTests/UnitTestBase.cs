using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;
using Zeus.CronParser.Application.DependencyInjection;
using Zeus.CronParser.Application.Factory;
using Zeus.CronParser.Application.Factory.Interfaces;

namespace Zeus.CronParser.Application.Tests.UnitTests
{
    public class UnitTestBase 
    {
        private readonly IServiceProvider _serviceProvider;
        protected ICronParserProviderFactory _cronParserProviderFactory;
        

        public UnitTestBase()
        {
            var services = new ServiceCollection();
            services.AddProviders();
            _serviceProvider = services.BuildServiceProvider();

            _cronParserProviderFactory = new CronParserProviderFactory(_serviceProvider);
        }

        protected static void AssertTest(List<string> result, string expectedresult, int numberOfRecords)
        {
            Assert.NotNull(result);
            Assert.IsType<List<string>>(result);
            Assert.Equal(numberOfRecords, result.Count);

            var counter = 0;
            foreach (var item in expectedresult.Split(" "))
            {
                Assert.Equal(item, result[counter++]);
            }
        }
    }
    
}
